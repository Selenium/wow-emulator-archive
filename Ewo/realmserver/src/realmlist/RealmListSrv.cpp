#include "RealmListSrv.h"
#include "Log.h"
#include "Singleton.h"
#include "Sockets.h"
//#include "UserHashes.h"
#include "Debug.h"
#include <sys/stat.h>
#include <string>
#include <math.h>
#include "ByteBuffer.h"

#include "Database.h"
#include "opcodes_realm.h"
#include "version.h"
#include "constants.h"

using namespace std;

createFileSingleton (RealmListSrv);

RealmListSrv::RealmListSrv () 
{
	dbstate = 0;
}

RealmListSrv::~RealmListSrv ()
{
   for (RealmMap::iterator i = mRealms.begin (); i != mRealms.end (); ++ i)
      delete i->second;
   mRealms.clear ();
   DATABASE.removeDatabaseInterface(dbi_r);

   //new
}

void RealmListSrv::addRealm( uint8 realmtype, uint8 flags, uint8 colour, char *name, char *adress, uint32 population, uint8 country, uint8 unk, uint8 online)
{
   //need check if realm name already exists and if it does, add a number
   removeRealm (name);
   mRealms [name] = new Realm ();
   mRealms [name]->RealmType = realmtype;
   mRealms [name]->Flags = flags;
   mRealms [name]->Colour = online ? colour : 2;
   mRealms [name]->Name = name;
   mRealms [name]->Adress = adress;
   mRealms [name]->Chars = 0;
   mRealms [name]->Population = population;
   mRealms [name]->Country = country;
   mRealms [name]->unk = unk;
 
}

void RealmListSrv::setRealm ( char * name, uint8 flags, uint8 colour, uint32 population )
{ 
   if (mRealms.find (name) != mRealms.end ())
   {
      mRealms [name]->Population = population;
      mRealms [name]->Flags = flags;
	  mRealms [name]->Colour = colour;
   }
}

void RealmListSrv::removeRealm (char * name) 
{
   if (mRealms.find (name) != mRealms.end () )
   {
      delete mRealms [name];
      mRealms.erase (name);
   }
}

void RealmListSrv::printRealms()
{
   RealmMap::iterator i;
   for (i = mRealms.begin (); i != mRealms.end(); ++ i)
	   LOG.outString("\tName: %s\n\tAdress: %s\n\tPopulation: %d",i->second->Name.c_str(), i->second->Adress.c_str(), i->second->Population);
}


void RealmListSrv::server_sockevent (nlink *cptr, uint16 revents, void *myNet)
{
   (void)cptr;
   Socket * client;
   nlink *ncptr;
   if(revents & PF_READ)
   {
      client = ( (Socket *) myNet)->AcceptConnection ();
      if (!client) 
         return;
      ulong nonblockingstate = true;
      so_ioctl (client->GetHandle(), FIONBIO, &nonblockingstate);
      ncptr = new nlink;   // client one
      if(ncptr == NULL)
         return;
      memset(ncptr, 0, sizeof(*ncptr));
      ncptr->type = RCLIENT;
      ncptr->fd = client->GetHandle();
      nlink_insert(ncptr);
      RealmClient *pClient = new RealmClient();
      pClient->BindNI(client);
      ncptr->pClient = pClient;
      mClients.insert(pClient);
   }
}

void RealmListSrv::client_sockevent (nlink *cptr, unsigned short revents)
{
   if(revents & PF_READ)
   {
      RealmClient *pClient = static_cast < RealmClient * > (cptr->pClient);
      Socket *net = pClient->getNetwork();
      uint8 opcode;
      if (!net->isConnected())
	  {
		  printf("read event on empty socket, closing\n");
         disconnect_client(cptr);
         return;
      }
	  net->ClearRecvq();
	  net->fillRecvQ();//fill network buffer
      if (!net->isConnected())
	  {
		  printf("read event on empty socket, closing\n");
         disconnect_client(cptr);
         return;
      }
#ifdef DEBUG_VERSION
	if (NETWORK.GetRealmLogging ())
	{
		FILE *pFile;
		pFile = fopen("realmlog.txt", "a");
		fprintf(pFile, "CLIENT:\nSOCKET: %d\nLENGTH: %d\nOPCODE: %.2X\nDATA:\n", net->handle, net->recvqlen, net->recvq[0]);
		DebugDump (pFile, net->recvq+1, net->recvqlen);
		fprintf(pFile, "\n\n");
		fclose(pFile);
	}
#endif
	  net->reset_read();
	  opcode = net->get_next_8b();
	  switch (opcode) 
	  {
/////////////////////////////////////////////////////////////////////////////////////
//		  case CMD_AUTH_RECONNECT_CHALLENGE:
//            {
//               LOG.outDebug ("REALMLIST: Recieved CMD_RECONNECT_CHALLENGE");
//            }
/////////////////////////////////////////////////////////////////////////////////////
		  case CMD_AUTH_LOGON_CHALLENGE:
            {
               LOG.outDebug ("REALMLIST: Recieved CMD_AUTH_LOGON_CHALLENGE (len = %d)",net->getRecvqLen());
			   HandleLogonChallenge(cptr);
            }break;
/////////////////////////////////////////////////////////////////////////////////////
//			case CMD_AUTH_RECONNECT_PROOF:
//            {
//               LOG.outDebug ("REALMLIST: Recieved CMD_RECONNECT_PROOF");
//            }
/////////////////////////////////////////////////////////////////////////////////////
			case CMD_AUTH_LOGON_PROOF:
            {
               LOG.outDebug ("REALMLIST: Recieved CMD_AUTH_LOGON_PROOF (len = %d)",net->getRecvqLen());
			   HandleLogonProof(cptr);
            }break;
/////////////////////////////////////////////////////////////////////////////////////
			case CMD_REALM_LIST:
            {
               LOG.outDebug ("REALMLIST: Recieved CMD_REALMLIST request (len = %d)",net->getRecvqLen());
			   HandleRealmList(cptr);
            }break;
/////////////////////////////////////////////////////////////////////////////////////
			default:
            {
               LOG.outString ("WORLDCOMMSRV: Recieved unknown opcode %i and len %d", opcode,net->getRecvqLen());
            }break;
      } //switch opcode
   } // if pfread
}

void RealmListSrv::disconnect_client (struct nlink *cptr)
{
   RealmClient * pClient = static_cast < RealmClient * > (cptr->pClient);
   printf ("REALM: Socket Closed for user %s\n",pClient->username);
   mClients.erase (pClient);
   delete pClient;
   Server::disconnect_client (cptr);
}

void RealmListSrv::clear_realm_list () {
   for (RealmMap::iterator i = mRealms.begin (); i != mRealms.end (); ++ i) {
      delete i->second;
   }
   mRealms.clear ();
}

void RealmListSrv::refresh_realm_list () {
   //dump old realmlist
   clear_realm_list();
   //create a new database link
   if(!dbi_r) dbi_r = DATABASE.createDatabaseInterface_r ();
   //populate with new one
   //foreach line in realms table it will call addrealm with line info
   dbi_r->load_realm_list();
   LOG.outDebug("[REALMLIST] Refreshed realms list.");
}

void RealmListSrv::force_players_in_offline_state()
{
   if(!dbi_r) dbi_r = DATABASE.createDatabaseInterface_r ();
   dbi_r->set_players_offline();
}

//net will contain the received packet(buffered) without first byte = opcode
void RealmListSrv::HandleLogonChallenge(nlink *cptr)
{

    RealmClient *pClient = static_cast < RealmClient * > (cptr->pClient);
    Socket *net = pClient->getNetwork();
	uint32	packet_len=net->getRecvqLen();
	if(packet_len<sizeof(sAuthLogonChallenge_C))
	{
		LOG.outDebug("HandleLogonChallenge : received too small packet!");
		//we received an empty packet, then we reply with an empty packet
//		char buffer[1];
//		buffer[0]=0; //opcode
//        net->sendData (1,buffer);
		return;
	}
	pClient->client_info.error = net->get_next_8b();
	pClient->client_info.size = net->get_next_16b();
	*(uint32*)&pClient->client_info.gamename = net->get_next_32b();
	pClient->client_info.version[0] = net->get_next_8b();
	pClient->client_info.version[1] = net->get_next_8b();
	pClient->client_info.version[2] = net->get_next_8b();
	pClient->client_info.build = net->get_next_16b();
	*(uint32*)&pClient->client_info.platform = net->get_next_32b();
	*(uint32*)&pClient->client_info.os = net->get_next_32b();
	*(uint32*)&pClient->client_info.localization = net->get_next_32b();
	pClient->client_info.timezone_bias = net->get_next_32b();
	*(uint32*)&pClient->client_info.ip = net->get_next_32b();
	pClient->client_info.I_len = net->get_next_8b();
	net->get_next_str(pClient->username);
	pClient->username[pClient->client_info.I_len+1]='\0';
    sprintf(pClient->full_ip,"%d.%d.%d.%d",pClient->client_info.ip[0], pClient->client_info.ip[1], pClient->client_info.ip[2], pClient->client_info.ip[3]);
#ifdef DEBUG_VERSION
	LOG.outDebug ("Username: %s", pClient->username);
    LOG.outDebug ("GameName: %s", pClient->client_info.gamename);
    LOG.outDebug ("Version: %d.%d.%d", pClient->client_info.version[0],pClient->client_info.version[1],pClient->client_info.version[2]);
    LOG.outDebug ("Build: %d", pClient->client_info.build);
    LOG.outDebug ("Platform: %c%c%c", pClient->client_info.platform[2], pClient->client_info.platform[1], pClient->client_info.platform[0]);
    LOG.outDebug ("OS: %c%c%c", pClient->client_info.os[2], pClient->client_info.os[1], pClient->client_info.os[0]);
    LOG.outDebug ("Localisation: %c%c%c%c", pClient->client_info.localization[3], pClient->client_info.localization[2], pClient->client_info.localization[1], pClient->client_info.localization[0]);
    LOG.outDebug ("TimeZone: %d", pClient->client_info.timezone_bias);
	LOG.outDebug ("IP: %s",pClient->full_ip );
#endif
	//check if ip is not firewalled
    sAuthLogonChallenge_S logon;
	memset(&logon,0,sizeof(sAuthLogonChallenge_S));
	logon.cmd = CMD_AUTH_LOGON_CHALLENGE;
	logon.error = LOGIN_OK;
    if(!dbi_r) dbi_r = DATABASE.createDatabaseInterface_r ();
    //client version is the most important bug
    if(pClient->client_info.build<CLIENT_BUILD_MIN || pClient->client_info.build>CLIENT_BUILD_MAX)
	{
		logon.error = LOGIN_BADVERSION;
	    net->sendData (sizeof(sAuthLogonChallenge_S) , (char *)&logon);
        printf ("REALMLIST: Sent LOGIN_BADVERSION ");
		//disconnect_client(cptr);
		return;
	}
	if(dbi_r->check_ip_blocked(pClient->full_ip))
	{
		logon.error = LOGIN_FAILED;
	    net->sendData (sizeof(sAuthLogonChallenge_S) , (char *)&logon);
        printf ("REALMLIST: Sent LOGIN_BANNED\n");
		//disconnect_client(cptr);
		return;
	}
    // check account state
    logon.error = dbi_r->challenge_account_login(pClient->username,pClient->full_ip);
    //inform client about account state
    LOG.outDebug ("REALMLIST: Login State : %d",logon.error);
    //log on console the state
    switch (logon.error)
	{
        case LOGIN_FAILED:   // bad password
            {
			logon.error = LOGIN_FAILED;
            net->sendData (sizeof(sAuthLogonChallenge_S) , (char *)&logon);
			//disconnect_client(cptr);
            printf ("REALMLIST: Sent LOGIN_FAILED \n");
            }return;
        case LOGIN_UNKNOWN_ACCOUNT:   
            {
			logon.error = LOGIN_FAILED;
            net->sendData (sizeof(sAuthLogonChallenge_S) , (char *)&logon);
			//disconnect_client(cptr);
            printf ("REALMLIST: Sent LOGIN_UNKNOWN_ACCOUNT \n");
            }return;
        case LOGIN_ALREADYONLINE:   
            {
			logon.error = LOGIN_FAILED;
            net->sendData (sizeof(sAuthLogonChallenge_S) , (char *)&logon);
			//disconnect_client(cptr);
            printf ("REALMLIST: Sent LOGIN_ALREADYONLINE \n");
            }return;
        case LOGIN_NOTIME:  
            {
			logon.error = LOGIN_FAILED;
            net->sendData (sizeof(sAuthLogonChallenge_S) , (char *)&logon);
			//disconnect_client(cptr);
            printf ("REALMLIST: Sent LOGIN_NOTIME \n");
            }return;
        case LOGIN_DBBUSY:   
            {
			logon.error = LOGIN_FAILED;
            net->sendData (sizeof(sAuthLogonChallenge_S) , (char *)&logon);
			//disconnect_client(cptr);
            printf ("REALMLIST: Sent LOGIN_DBBUSY \n");
            }return;
        case LOGIN_PARENTALCONTROL:   
            {
			logon.error = LOGIN_FAILED;
            net->sendData (sizeof(sAuthLogonChallenge_S) , (char *)&logon);
			//disconnect_client(cptr);
            printf ("REALMLIST: Sent LOGIN_PARENTALCONTROL \n");
            }return;
        case LOGIN_DOWNLOADFILE:   
            {
			logon.error = LOGIN_FAILED;
            net->sendData (sizeof(sAuthLogonChallenge_S) , (char *)&logon);
			//disconnect_client(cptr);
            printf ("REALMLIST: Sent LOGIN_DOWNLOADFILE \n");
            }return;
    }
    //get passwrod for username
    char *passwd = dbi_r->get_account_password(pClient->username);
    strcpy(pClient->username,strupr(pClient->username));
    passwd=strupr(passwd);
    LOG.outString ("REALMLIST: the password for the account is : %s",passwd);
    //got username & pass, let's start SRP
    pClient->challange(pClient->username, passwd);
	memcpy(logon.B, pClient->B.AsByteArray(), 32);
	logon.g_len = 1;
	logon.g[0] = (pClient->g.AsByteArray())[0];
	logon.N_len = 32;
	memcpy(logon.N, pClient->N.AsByteArray(), 32);
	memcpy(logon.s, pClient->s.AsByteArray(), 32);
	net->sendData(sizeof(sAuthLogonChallenge_S), &logon);

	delete [] passwd;

	LOG.outDebug ("REALMLIST: Sent CMD_AUTH_LOGON_CHALLENGE\nLength: %d",sizeof(sAuthLogonChallenge_S));
}

void RealmListSrv::HandleLogonProof(nlink *cptr)
{
    RealmClient *pClient = static_cast < RealmClient * > (cptr->pClient);
    Socket *net = pClient->getNetwork();
	uint32	packet_len=net->getRecvqLen();
	if(packet_len<sizeof(sAuthLogonProof_C))
	{
		LOG.outDebug("HandleLogonProof : received too small packet!");
		return;
	}
	sAuthLogonProof_S proof;
	memset(&proof,0,sizeof(sAuthLogonProof_S));
    sAuthLogonProof_C proofC;
	memcpy(&proofC,&net->recvq[1],sizeof(sAuthLogonProof_C));
	pClient->proof((char *)proofC.A);
	proof.cmd = (uint8)CMD_AUTH_LOGON_PROOF;
	if (memcmp(proofC.M1, pClient->M.AsByteArray(), 20))
	{
        proof.error = (uint8)0x04; // LOGIN_UNKNOWN_ACCOUNT :|
        net->sendData (2 , &proof);
		LOG.outDebug ("REALMLIST: Sent CMD_AUTH_LOGON_PROOF : wrong password ");
 		disconnect_client(cptr); //he will reply to this wich will be a 0=opcode
        return;

    }
	printf("%s succesfully logged in\n",pClient->username);
	//we save the current hash and make the account to apear as online
	dbi_r->set_account_online(pClient->username, pClient->sessionkey.c_str(), pClient->full_ip);
	memcpy(proof.M2, pClient->sha.GetDigest(), 20);
    net->sendData(sizeof(sAuthLogonProof_S), &proof);
	LOG.outDebug ("REALMLIST: Sent CMD_AUTH_LOGON_PROOF\nLength: %d", sizeof(sAuthLogonProof_S));
}

void RealmListSrv::HandleRealmList(nlink *cptr)
{
    RealmClient *pClient = static_cast < RealmClient * > (cptr->pClient);
    Socket *net = pClient->getNetwork();
	uint32	packet_len=net->getRecvqLen();
	if(packet_len==0)
	{
		LOG.outDebug ("REALMLIST: Sent CMD_AUTH_LOGON_PROOF\nLength: %d", sizeof(sAuthLogonProof_S));
		return;
	}
	refresh_realm_list();
	ByteBuffer realmpacket;
	ByteBuffer realms;
	for (i = mRealms.begin (), TotalRealms = 0; i != mRealms.end (); ++ i, ++ TotalRealms );
	realms << uint32(0);
	realms << (uint8)TotalRealms; // number of realms
	for (i = mRealms.begin (); i != mRealms.end (); ++ i )
	{
		realms << uint8(0); //(uint8)i->second->RealmType;
		realms << i->second->Flags;
		realms << i->second->Colour;
		realms << i->second->Name.c_str();
		realms << i->second->Adress.c_str();
		realms << i->second->Population;
		realms << uint8(0); //(uint8)i->second->Chars; // TODO: get account's chars on the realm
		realms << (uint8)i->second->Country;
		realms << i->second->unk;
		realms << uint8(1);
		realms << uint8(0);
		//LOG.outDebug("Total Realms: %d\nRealmType: %d\nFlags: %d\nColour: %d\nName: %s\nAdress: %s\nPopulation: %d\nChars: %d\nCountry: %d\nUnk: %d",
		//   TotalRealms, i->second->RealmType, i->second->Flags, i->second->Colour, i->second->Name.c_str(), i->second->Adress.c_str(), (float)i->second->Population, i->second->Chars, i->second->Country, i->second->unk);
	};
	realmpacket << uint8(CMD_REALM_LIST);
	realmpacket << uint16(realms.size());
	realmpacket.append(realms);
    net->sendData (realmpacket.size(), realmpacket.contents());
    LOG.outDebug ("REALMLIST: Sent CMD_REALMLIST");
}
