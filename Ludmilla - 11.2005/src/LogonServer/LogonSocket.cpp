//******************************************************************************
#include "StdAfx.h"
#include "LogonSocket.h"
#include "LogonSocketMgr.h"
#include "RealmList.h"

#include "../Shared/Database/Database.h"

#include "../Game/World.h"
#include "../LudMilla/Version/version.h"

#include "../Shared/Log.h"
#include "../Shared/Util.h"
//==============================================================================
// Shared object of autoupdate system
LogonSocket::CPatcher LogonSocket::Patcher;
//==============================================================================
// Reads data from CircularBuffer but does nott remove it from that buf
void LogonSocket::PeekFromCircularBuffer(CircularBuffer *buf, char *dst, int size)
	// buf must have >= size
{
	size_t buf_size = buf->Space() + buf->GetLength();
	size_t overlapped_size = buf_size - buf->Space() - buf->GetL();
	if (overlapped_size > 0)
	{
		char* buf_end = buf->GetStart() + buf->GetL();
		char* buf_start = buf_end - buf_size;
		memcpy(dst, buf->GetStart(), buf->GetL());
		memcpy(dst+overlapped_size, buf_start, overlapped_size);
	}
	else if (overlapped_size == 0)
	{
		memcpy(dst, buf->GetStart(), size);
	}
	else
		ASSERT(0);
	return;
}
//==============================================================================
LogonSocket::LogonSocket(SocketHandler &h) : TcpSocket(h)
{
	N.SetHexStr("894B645E89E1535BBDAD5B8B290650530801B18EBFBF5E8FAB3C82872A3E9BB7");
	g.SetDword(7);
	_authed = false;
	_challenged = false;
	_pending_error = LOGIN_OK;
	patch = NULL;
	mustdie = false;
	amprocessing = false;
	amsending = false;
	transfering = false;
	pauseoutput = 0;
}
LogonSocket::~LogonSocket()
{
	if (patch != NULL)
		delete patch;
	while (!input.empty())
	{
		delete input.front();
		input.pop();
	}
	while (!output.empty())
	{
		delete output.front();
		output.pop();
	}
}
//------------------------------------------------------------------------------
// Process all queued packets from network
// true if input queue is empty
bool LogonSocket::ProcessInput(uint32 count)
{
	if (this->mustdie)
	{
		if (!this->amsending)
			DeleteThis();
		return true;
	}

	for (uint32 i=0; i<count && !this->input.empty(); i++)
	{
		EClientCommand cmd = (EClientCommand)*( (unsigned char*)&((*(input.front()))[0]) );
		switch (cmd)
		{
			case CMD_AUTH_LOGON_CHALLENGE:
				ProcessLogonChallenge();
				break;
			case CMD_AUTH_LOGON_PROOF:
				ProcessLogonProof();
				break;
			case CMD_AUTH_RECONNECT_CHALLENGE:
				ProcessReconnectChallenge();
				break;
			case CMD_AUTH_RECONNECT_PROOF:
				ProcessReconnectProof();
				break;
			case CMD_REALM_LIST:
				ProcessRealmList();
				break;
			case CMD_XFER_ACCEPT:
				ProcessXferAccept();
				break;
			case CMD_XFER_RESUME:
				ProcessXferResume();
				break;
			case CMD_XFER_CANCEL:
				ProcessXferCancel();
				break;
			default:
				ASSERT(0);
		}
	}
	AddToMgrSendList();
	if (input.empty())
	{
		amprocessing = false;
		return true;
	}
	else
		return false;
}
// Send all queued outgoing packets to network
// true if output queue is empty
bool LogonSocket::SendOutput(time_t diff, uint32 count)
{
	if (transfering)
		if (!output.empty())
			this->Set(true, true);
	if (pauseoutput > 0)
		if ( (pauseoutput-=diff) > 0)
			return false;
	for (uint32 i=0; i<count && !this->output.empty(); i++)
	{
		std::vector<uint8> * buf = output.front();
		SendBuf((char*)&((*buf)[0]), buf->size());
		delete buf;
		output.pop();
	}
	if (output.empty())
	{
		amsending = false;
		if (mustdie)
			if (!this->amprocessing)
				DeleteThis();
		return true;
	}
	else
		return false;
}
// Add LogonSocket to LogonSocketMgr's list for procession
void LogonSocket::AddToMgrProcessList()
{
	if (amprocessing || mustdie)
		return;
	amprocessing = true;
	sLogonSocketMgr.AddToProcessList(this);
}
// Add LogonSocket to LogonSocketMgr's list for sending data
void LogonSocket::AddToMgrSendList()
{
	if (amsending)
		return;
	amsending = true;
	sLogonSocketMgr.AddToSendList(this);
}
// Called when Socket lib deleting this object
void LogonSocket::OnDelete()
{
	if (amsending)
        sLogonSocketMgr.DelFromSendList(this);
	if (amprocessing)
        sLogonSocketMgr.DelFromProcessList(this);
	TcpSocket::OnDelete();
}
// Close connection and mark this for deletion - last action
void LogonSocket::DeleteThis()
{
#ifndef SD_RECEIVE
	#define SD_RECEIVE      0x00
#endif
	shutdown(GetSocket(), SD_RECEIVE);
	SetCloseAndDelete(true);
}
//------------------------------------------------------------------------------
// LogonChallenge: first packets
// Adds new LogonChallenge packet to input queue
LogonSocket::EServerAnswer LogonSocket::QueueLogonChallenge()
{
	static const int head_size = sizeof(SClientLogonChallenge_Header);

	// not even header:
	if (ibuf.GetLength() < head_size)
		return SA_WAITING;

	// header:
	SClientLogonChallenge_Header header;
	PeekFromCircularBuffer(&ibuf, (char*)&header, head_size);
	uint16 remaining = header.size;
	sLog.outDetail("[AuthChallenge] got header, body is %#04x bytes", remaining);

	if (ibuf.GetLength() < remaining+(uint32)head_size)
		return SA_WAITING; // got not full packet
	
	// client packet buffer
	std::vector<uint8> *cpktb = new std::vector<uint8>(head_size + remaining + 1);
	(*cpktb)[cpktb->size() - 1] = 0; // we want name zero-terminated
	ibuf.Read((char*)&((*cpktb)[0]), head_size+remaining);

	SClientLogonChallenge *cpkt = (SClientLogonChallenge*)&((*cpktb)[0]);
	sLog.outDebug("[AuthChallenge] got full packet, %#04x bytes", cpkt->size);

	this->input.push(cpktb);
	return SA_QUEUED;
}
// LogonChallenge: first packets
// help func: checks for errors, fill account name and paassword field
void LogonSocket::ParseLogonChallenge(SClientLogonChallenge *cpkt)
{
// Checking account namelength:
	if (cpkt->acclen >= 30)
	{
		_login = "login";
		_password = "password";
		_pending_error = LOGIN_UNKNOWN_ACCOUNT;
		return;
	}

// Checking account spelling
	if (!CheckName( (char*) (cpkt->acc), cpkt->acclen ) || cpkt->acclen==0)
	{
		_login = "login";
		_password = "password";
		_pending_error = LOGIN_UNKNOWN_ACCOUNT;
		return;
	}
	_login = (const char*)cpkt->acc;

// Chechking client build:
	this->_pending_error = Patcher.CheckClientVersion(cpkt->build, cpkt->localization);
	if (_pending_error == LOGIN_DOWNLOADFILE)
		this->patch = new CPatcher::CPatch(cpkt->build, cpkt->localization);
	if(_pending_error != LOGIN_OK)
		return;

// Checking account:
	// TODO: in the far future should check if the account is expired too
	std::stringstream ss;
	ss << "SELECT password, gm FROM accounts WHERE login='" << _login << "'"; // password
	QueryResult *result = sDatabase.Query(ss.str().c_str());

	if(!result)
	{
		_password = "password";
		_pending_error = LOGIN_UNKNOWN_ACCOUNT;
		return;
	}

	_password = (*result)[0].GetString();
	uint16 security = (*result)[1].GetUInt16();

	delete result;

// Checking players count:
	if (sWorld.GetPlayerLimit() > 0 &&
		sWorld.GetSessionCount() > sWorld.GetPlayerLimit() &&
		security == 0)
	{
		_pending_error = LOGIN_DBBUSY;
		return;
	}
}
// LogonChallenge: first packets
// Makes and queues server's LogonChallenge packet
void LogonSocket::ProcessLogonChallenge()
{
    if (_challenged) // protocol error
	{
		this->mustdie = true;
		return;
	}

	SClientLogonChallenge *cpkt = (SClientLogonChallenge*)&((*(input.front()))[0]);

	ParseLogonChallenge(cpkt);

	// sending ServerLogonChallenge anyway, even if have error
	// we will report in ServerLogonProof, like bliz do

// Calculations:

	std::transform(_password.begin(), _password.end(), _password.begin(), towupper);
	Sha1Hash I;
	std::string sI = _login + ":" + _password;
	I.UpdateData(sI);
	I.Finalize();
	Sha1Hash sha;
	sha.UpdateData(s.AsByteArray(), s.GetNumBytes());
	sha.UpdateData(I.GetDigest(), 20);
	sha.Finalize();
	BigNumber x;
	x.SetBinary(sha.GetDigest(), sha.GetLength());
	v = g.ModExp(x, N);
	b.SetRand(19 * 8);
	BigNumber gmod=g.ModExp(b, N);
	B = ((v * 3) + gmod) % N;
	ASSERT(gmod.GetNumBytes() <= 32);
	BigNumber unk2;
	unk2.SetRand(16*8);

// Sending packet:
	std::vector<uint8> *spktb = new std::vector<uint8>(sizeof(SServerLogonChallenge_Ok));
	SServerLogonChallenge_Ok *spkt =  (SServerLogonChallenge_Ok*)&( (*spktb)[0] );
	spkt->cmd = CMD_AUTH_LOGON_CHALLENGE;
	spkt->error = LOGIN_OK; // no error
	spkt->unk1 = 0;
	memcpy(spkt->B, B.AsByteArray(), 32);
	spkt->g_len = 0x01;
	spkt->g[0] = 0x07;
	spkt->N_len = 0x20;
	memcpy(spkt->N, N.AsByteArray(), 32);
	memcpy(spkt->salt, s.AsByteArray(), 32);
	memcpy(spkt->unk2, unk2.AsByteArray(), 16);

	_challenged = true;
	delete input.front();
	input.pop();
	output.push(spktb);
}
// LogonProof: client second packets he proof, we proof
// Adds new LogonProof packet to input queue
LogonSocket::EServerAnswer LogonSocket::QueueLogonProof()
{
	if (ibuf.GetLength() < sizeof(SClientLogonProof))
		return SA_WAITING;

	// client packet buffer
	std::vector<uint8> *cpktb = new std::vector<uint8>(sizeof(SClientLogonProof));
	ibuf.Read((char*)&((*cpktb)[0]), sizeof(SClientLogonProof));

	sLog.outDebug("[AuthProof] got packet");
	input.push(cpktb);

	return SA_QUEUED;
}
// LogonProof: client second packets he proof, we proof
// help func: queues server's error packet
void LogonSocket::ErrorLogonProof()
{
	std::vector<uint8>* pendingb = new std::vector<uint8>(sizeof(SServerLogonProof_Err));
	SServerLogonProof_Err* pending = (SServerLogonProof_Err*)&((*pendingb)[0]);
	pending->cmd = CMD_AUTH_LOGON_PROOF;
	pending->error = _pending_error;
	output.push(pendingb);
	pauseoutput = 1000; // 1 sec
}
// LogonProof: client second packets he proof, we proof
// Makes and queues server's LogonProof packet
void LogonSocket::ProcessLogonProof()
{
	SClientLogonProof *cpkt = (SClientLogonProof*)&((*(input.front()))[0]);

    if (!_challenged)
		_pending_error = LOGIN_FAILED;

	if (_pending_error != LOGIN_OK)
	{
		ErrorLogonProof();

		if (_pending_error == LOGIN_DOWNLOADFILE)
			output.push(this->patch->CreateInfo());
		else
			this->mustdie = true;

		delete input.front();
		input.pop();
		return;
	}

	sLog.outDetail("[AuthLogonProof] checking...");

	BigNumber A;
	A.SetBinary(cpkt->A, 32);

	Sha1Hash sha;
	sha.UpdateBigNumbers(&A, &B, NULL);
	sha.Finalize();
	BigNumber u;
	u.SetBinary(sha.GetDigest(), 20);
	BigNumber S = (A * (v.ModExp(u, N))).ModExp(b, N);

	uint8 t[32];
	uint8 t1[16];
	uint8 vK[40];
	memcpy(t, S.AsByteArray(), 32);
	for (int i = 0; i < 16; i++)
		t1[i] = t[i*2];
	sha.Initialize();
	sha.UpdateData(t1, 16);
	sha.Finalize();
	for (int i = 0; i < 20; i++)
		vK[i*2] = sha.GetDigest()[i];
	for (int i = 0; i < 16; i++)
		t1[i] = t[i*2+1];
	sha.Initialize();
	sha.UpdateData(t1, 16);
	sha.Finalize();
	for (int i = 0; i < 20; i++)
		vK[i*2+1] = sha.GetDigest()[i];
	K.SetBinary(vK, 40);

	uint8 hash[20];

	sha.Initialize();
	sha.UpdateBigNumbers(&N, NULL);
	sha.Finalize();
	memcpy(hash, sha.GetDigest(), 20);
	sha.Initialize();
	sha.UpdateBigNumbers(&g, NULL);
	sha.Finalize();
	for (int i = 0; i < 20; i++)
		hash[i] ^= sha.GetDigest()[i];
	BigNumber t3;
	t3.SetBinary(hash, 20);

	sha.Initialize();
	sha.UpdateData(_login);
	sha.Finalize();
	BigNumber t4;
	t4.SetBinary(sha.GetDigest(), 20);

	sha.Initialize();
	sha.UpdateBigNumbers(&t3, &t4, &s, &A, &B, &K, NULL);
	sha.Finalize();
	BigNumber M;
	M.SetBinary(sha.GetDigest(), 20);

	if (memcmp(M.AsByteArray(), cpkt->M1, 20) == 0)
	{
		sLog.outBasic("User '%s' successfully authed", _login.c_str());

		//saving session key to database
		std::stringstream ss;
		ss << "UPDATE accounts SET sessionkey = '";
		ss << K.AsHexStr();
		ss<< "' WHERE login='" << _login << "'";
		sDatabase.Execute( ss.str().c_str() );

		std::vector<uint8>* spktb = new std::vector<uint8>(sizeof(SServerLogonProof_Ok));
		SServerLogonProof_Ok* spkt = (SServerLogonProof_Ok*)&((*spktb)[0]);

		spkt->cmd = CMD_AUTH_LOGON_PROOF;
		spkt->error = 0;
		sha.Initialize();
		sha.UpdateBigNumbers(&A, &M, &K, NULL);
		sha.Finalize();
		memcpy(spkt->M2, sha.GetDigest(), 20);
		spkt->unk = 0;

		_authed = true;
		output.push(spktb);
	}
	else
	{
		_pending_error = LOGIN_UNKNOWN_ACCOUNT;
		ErrorLogonProof();
		this->mustdie = true;
		sLog.outBasic("User '%s': invalid password", _login.c_str());
	}
	delete input.front();
	input.pop();
}
// ReconnectChallenge: not discovered. we need info about reconnection.
// Just recalls QueueLogonChallenge()
LogonSocket::EServerAnswer LogonSocket::QueueReconnectChallenge()
{
	sLog.outDebug("[AuthReconnectChallenge] got not implemented packet, tring AuthChallenge");
	return QueueLogonChallenge();
	//throw "not implemented";
}
// ReconnectChallenge: not discovered. we need info about reconnection.
// Just recalls ProcessLogonChallenge()
void LogonSocket::ProcessReconnectChallenge()
{
	ProcessLogonChallenge();
	//throw "not implemented";
}
// ReconnectProof: not discovered. we need info about reconnection.
// Just recalls QueueLogonProof()
LogonSocket::EServerAnswer LogonSocket::QueueReconnectProof()
{
	sLog.outDebug("[AuthReconnectProof] got not implemented packet, tring AuthProof");
	return QueueLogonProof();
	//throw "not implemented";
}
// ReconnectProof: not discovered. we need info about reconnection.
// Just recalls ProcessLogonProof()
void LogonSocket::ProcessReconnectProof()
{
	ProcessLogonProof();
	//throw "not implemented";
}
// RealmList: Called everytime when clien looks on realm list
// Makes and queues server's RealmList packet
LogonSocket::EServerAnswer LogonSocket::QueueRealmList()
{
	if (ibuf.GetLength() < sizeof(SClientRealmList))
		return SA_WAITING;

	// client packet buffer
	std::vector<uint8> *cpktb = new std::vector<uint8>(sizeof(SClientRealmList));
	ibuf.Read((char*)&((*cpktb)[0]), sizeof(SClientRealmList));

	sLog.outDebug("[AuthRealmList] got packet");
	input.push(cpktb);

	return SA_QUEUED;
}
// RealmList: Called everytime when clien looks on realm list
// Adds new RealmList packet to input queue
void LogonSocket::ProcessRealmList()
{
	if (!_authed) // todo: return err to client
	{
		this->mustdie = true;
		return;
	}

	sLog.outDebug ("[RealmList] begin");

// Getting account info:
	std::stringstream ss;
	ss << "SELECT acct FROM accounts WHERE login='" << _login << "'"; // password
	QueryResult *result = sDatabase.Query(ss.str().c_str());

	if (result == NULL) // todo: return err to client
	{
		sLog.outError ("[RealmList] Select account by login '%s' failed", _login.c_str());
		this->mustdie = true;
		return;
	}

	uint32 id = (*result)[0].GetUInt32();
	delete result;

	uint8 chars = 0;

	ss.rdbuf()->str("");
	ss << "SELECT guid FROM characters WHERE acct=" << id;
	result = sDatabase.Query( ss.str().c_str() );
	if( result )
	{
		do
		{
			chars++;
		}
		while( result->NextRow() );

		delete result;
	}

// Building packet:

	// as it has variable length, don't use struc here
	// but plz update struct provided for info with others
	ByteBuffer pkt;

	pkt << (uint32) 0;
	pkt << (uint8) sRealmList.size();
	RealmList::RealmMap::const_iterator i;
	for( i = sRealmList.begin( ); i != sRealmList.end( ); i++ )
	{
		pkt << (uint32) i->second->icon; // icon
		pkt << (uint8) i->second->color;
		sLog.outDebug("[RealmList] put realm '%s' -- '%s'", i->first.c_str(), i->second->address.c_str());
		pkt << i->first;
		pkt << i->second->address;
		pkt << (float) 1.6; // population value. lower == lower population and vice versa
		pkt << (uint8) chars; // number of characters on this server
		pkt << (uint8) i->second->timezone;
		pkt << (uint8) 0; // unknown
	}
	pkt << (uint8) 0x2A; //0; // unknown
	pkt << (uint8) 0x00; //0x2; // unknown

	SServerRealmList_Header hdr;
	hdr.cmd = CMD_REALM_LIST;
	hdr.size = (uint16)pkt.size();

// Building final packet:
	std::vector<uint8> *spktb = new std::vector<uint8>(sizeof(SServerRealmList_Header)+hdr.size);
	memcpy(&((*spktb)[0]), &hdr, sizeof(SServerRealmList_Header));
	memcpy(&((*spktb)[sizeof(SServerRealmList_Header)]), pkt.contents(), pkt.size());
	output.push(spktb);

	sLog.outDebug ("[RealmList] finished");

	delete input.front();
	input.pop();
}
// XferAccept: Client agreed to receive new patch
// Adds new XferAccept packet to input queue
LogonSocket::EServerAnswer LogonSocket::QueueXferAccept()
{
	// client packet buffer
	std::vector<uint8> *cpktb = new std::vector<uint8>(sizeof(SClientXferAccept));
	ibuf.Read((char*)&((*cpktb)[0]), sizeof(SClientXferAccept));

	sLog.outDebug("[AuthXferAccept] got packet");
	input.push(cpktb);
	return SA_QUEUED;
}
// XferAccept: Client agreed to receive new patch
// Makes and queues next patch part, Does not remove input packet until end.
void LogonSocket::ProcessXferAccept()
{
	if (patch == NULL || patch->Done())
	{
		this->mustdie = true;
		return;
	}
	output.push(this->patch->CreateNextPart());
}
// XferAccept: Client want to continue receiving of patch from specified position
// Adds new XferResume packet to input queue
LogonSocket::EServerAnswer LogonSocket::QueueXferResume()
{
	if (ibuf.GetLength() < sizeof(SClientXferResume))
		return SA_WAITING;

	// client packet buffer
	std::vector<uint8> *cpktb = new std::vector<uint8>(sizeof(SClientXferResume));
	ibuf.Read((char*)&((*cpktb)[0]), sizeof(SClientXferResume));

	sLog.outDebug("[AuthXferResume] got packet");
	input.push(cpktb);
	return SA_QUEUED;
}
// XferAccept: Client want to continue receiving of patch from specified position
// Makes and queues next patch part, Does not remove input packet until end.
void LogonSocket::ProcessXferResume()
{
	SClientXferResume *cpkt = (SClientXferResume*)&((*(input.front()))[0]);

	if (patch == NULL || patch->GetSize() <= cpkt->start)
	{
		this->mustdie = true;
		return;
	}
	
	if (patch->Done())
	{
		delete input.front();
		input.pop();
		this->mustdie = true;
		return;
	}

	if (!patch->AmResuming())
		patch->SetPos(cpkt->start);

	output.push(this->patch->CreateNextPart());
}

// XferCancel: Client want to abort receiving of the patch
// Deletes previous packet and adds XferCancel packet to input queue
LogonSocket::EServerAnswer LogonSocket::QueueXferCancel()
{
	// client packet buffer
	std::vector<uint8> *cpktb = new std::vector<uint8>(sizeof(SClientXferCancel));
	ibuf.Read((char*)&((*cpktb)[0]), sizeof(SClientXferCancel));

	sLog.outDebug("[AuthXferCancel] got packet");
	
	// Need to delete previous packet here, because this packet
	// will not processed until transfering's end.
	EClientCommand cmd = (EClientCommand)*( (unsigned char*)&((*(input.front()))[0]) );
	if (cmd != CMD_XFER_ACCEPT && cmd != CMD_XFER_RESUME) // protocol error
		return SA_ERROR;
	delete input.front();
	input.pop();

	input.push(cpktb);
	return SA_QUEUED;
}
// XferCancel: Client want to abort receiving of the patch
// Clears output queue, mark as dieing connection
void LogonSocket::ProcessXferCancel()
{
	delete input.front();
	input.pop();

	// reject anyway
	if (!transfering)
	{
		this->mustdie = true;
		return;
	}

	this->mustdie = true;

	while (!output.empty())
	{
		delete output.front();
		output.pop();
	}

	transfering = false;
}
//==============================================================================
// Called when Socket lib accepting new connection
void LogonSocket::OnAccept()
{
	TcpSocket::OnAccept();

	sLog.outBasic("Accepting connection from '%s:%d'", GetRemoteAddress().c_str(), GetRemotePort());
	s.SetRand(s_BYTE_SIZE * 8);

	bool val = true;
	setsockopt(GetSocket(), IPPROTO_TCP, TCP_NODELAY, (const char*)&val, sizeof(val));
}

// Called when Socket lib has data for us
void LogonSocket::OnWrite()
{
	if (transfering)
	{
		bool r, w, e;
		this->Handler().Get(GetSocket(), r, w, e);
		if (w)
			TcpSocket::OnWrite();
	}
	else
		TcpSocket::OnWrite();
}
// Called when Socket lib let write to network
void LogonSocket::OnRead()
{
	if (input.size() >= 100)
		return;

	TcpSocket::OnRead();

	while (1)
	{
		if (!ibuf.GetLength())
			break; // No data

		EClientCommand cmd = (EClientCommand) ( *((unsigned char *)(ibuf.GetStart())) );
		EServerAnswer sa;

		switch (cmd)
		{
			case CMD_AUTH_LOGON_CHALLENGE:
				sa = QueueLogonChallenge();
				break;
			case CMD_AUTH_LOGON_PROOF:
				sa = QueueLogonProof();
				break;
			case CMD_AUTH_RECONNECT_CHALLENGE:
				sa = QueueReconnectChallenge();
				break;
			case CMD_AUTH_RECONNECT_PROOF:
				sa = QueueReconnectProof();
				break;
			case CMD_REALM_LIST:
				sa = QueueRealmList();
				break;
			case CMD_XFER_ACCEPT:
				sa = QueueXferAccept();
				break;
			case CMD_XFER_RESUME:
				sa = QueueXferResume();
				break;
			case CMD_XFER_CANCEL:
				sa = QueueXferCancel();
				break;
			default:
				sLog.outError("[Auth] got unknown packet %u", (uint32)cmd);
				sa = SA_ERROR;
		}

		switch (sa)
		{
			case SA_QUEUED: // loop again
				AddToMgrProcessList();
				break;
			case SA_ERROR: // drop connection
				this->mustdie = true;
				return;
			case SA_WAITING: // waiting for next call
				return;
		}
	}
}
//==============================================================================
// auto update system:
// Implements all global logic about patching
// Decide questions about patching
// Holds patch class for packet building inside
LogonSocket::CPatcher::CPatcher()
{
	patches_count = 0;
}
LogonSocket::CPatcher::~CPatcher()
{
	if (patches != NULL)
		delete[] patches;
}
// Check for patch in internal list, loaded at startup
bool LogonSocket::CPatcher::HavePatch(uint16 build, uint8 localization[4])
{
	for (int i=0; i<patches_count; i++)
		if (patches[i].build == build)
			if (memcmp(patches[i].localization, localization, 4)==0)
				return true;
	return false;
}
// Must be called at program startup before any other use of class
// Scan for patches in /patches/ dir
void LogonSocket::CPatcher::LoadPatcheIDs()
{
// have *nix such funcs?
#ifdef _WIN32
	#define slash "\\"
	#ifndef findfirst
		#define findfirst _findfirst
	#endif
	#ifndef findnext
		#define findnext _findnext
	#endif
	#ifndef finddata_t
		#define finddata_t _finddata_t
	#endif
	#ifndef findclose
		#define findclose _findclose
	#endif
	#ifndef A_SUBDIR
		#define A_SUBDIR _A_SUBDIR
	#endif


	struct finddata_t fd;
	intptr_t hFind;

	patches_count = 0;
	patches = NULL;

// find total count of patches:

	if( (hFind = findfirst("patches"slash"*", &fd)) == -1L )
	{
		sLog.outError("[AutoUpdateSystem] Error: patches dir is empty");
		return;
	}
	else
	{
		do
		{
			if ( (fd.attrib & A_SUBDIR) == 0)
				++patches_count;
		}
		while(findnext(hFind, &fd) == 0);
		findclose(hFind);
	}

	sLog.outDebug("[AutoUpdateSystem] found patchs: %d\n", patches_count);
	patches = new PatchID[patches_count];

// loading info:
	
	if( (hFind = findfirst("patches"slash"*", &fd)) == -1L )
		sLog.outError("[AutoUpdateSystem] Error: patches dir is empty");
	else
	{
		for (int i=0; findnext(hFind, &fd)==0;)
			if ( (fd.attrib & A_SUBDIR) == 0)
			{
				patches[i];
				int processed = sscanf(fd.name, "%d%c%c%c%c", &(patches[i].build),
					&(patches[i].localization[3]),
					&(patches[i].localization[2]),
					&(patches[i].localization[1]),
					&(patches[i].localization[0]));
				if (processed != 5)
				{
					sLog.outError("[AutoUpdateSystem] Error: \"%s\" has incorrect name format!", fd.name);
					--patches_count;
					continue;
				}
				sLog.outMenu("[AutoUpdateSystem] found patch for: %d%c%c%c%c\n",
					patches[i].build,
					patches[i].localization[3],
					patches[i].localization[2],
					patches[i].localization[1],
					patches[i].localization[0]);
				++i;
			}
		findclose(hFind);
	}
#else // ndef _WIN32
	patches_count = 0;
	patches		  = NULL;
#endif
}
// Decide is client ok, must we patch him, or reject
ELoginErrorCode LogonSocket::CPatcher::CheckClientVersion(uint16 build, uint8 localization[4])
{
	if (build == VERTARGET)
		return LOGIN_OK;
	if (HavePatch(build, localization))
		return LOGIN_DOWNLOADFILE;
	return LOGIN_BADVERSION;
}
//==============================================================================
// The patch for the client
// Builds specified packets for the client
LogonSocket::CPatcher::CPatch::CPatch(uint16 build, uint8 localization[4])
{
	resuming = false;

	char fname[MAX_PATH];
    sprintf(fname, "patches"slash"%d%c%c%c%c", build, (char)localization[3],
		(char)localization[2], (char)localization[1], (char)localization[0]);
	file = fopen(fname, "rb");

	char buf[BlockSize];

	MD5_CTX ctx;
	MD5_Init(&ctx);

	while (!feof(file))
	{
		size_t read = fread(buf, 1, BlockSize, file);
		MD5_Update(&ctx, buf, read);
	}

	MD5_Final(md5, &ctx);
	this->size = (uint32)ftell(file);

	fseek(file, 0, SEEK_SET);
}
LogonSocket::CPatcher::CPatch::~CPatch()
{
	fclose(file);
}
// Builds packet:
// Creates packet with info about patch
std::vector<uint8>* LogonSocket::CPatcher::CPatch::CreateInfo()
{
	std::vector<uint8> *spktb = new std::vector<uint8>(sizeof(SServerXferInitiate));
	SServerXferInitiate *spkt = (SServerXferInitiate*)&((*spktb)[0]);
	spkt->cmd = CMD_XFER_INITIATE;
	spkt->typelen = 5;
	memcpy(spkt->typestr, "Patch", 5);
	spkt->size = this->size;
	spkt->unk = 0;
	memcpy(spkt->md5, this->md5, MD5_DIGEST_LENGTH);

	return spktb;
}
// Builds packet:
// Create packet with next portion of data
std::vector<uint8>* LogonSocket::CPatcher::CPatch::CreateNextPart()
{
	std::vector<uint8> *spktb = new std::vector<uint8>(sizeof(SServerXferData));
	SServerXferData *spkt = (SServerXferData*)&((*spktb)[0]);

	spkt->cmd = CMD_XFER_DATA;
	spkt->blocksize = (uint16)fread(spkt->buf, 1, BlockSize, file);

	if (spkt->blocksize < BlockSize)
		spktb->resize(sizeof(SServerXferData) - BlockSize + spkt->blocksize);

	return spktb;
}
// Sets needed position for resuming
void LogonSocket::CPatcher::CPatch::SetPos(uint32 pos)
{
	resuming = true;
	fseek(file, pos, SEEK_SET);
}
//******************************************************************************
