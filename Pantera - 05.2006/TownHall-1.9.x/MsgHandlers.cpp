// TODO: split this file up into multiple files.  One for combat, one for login, one for
// movement, etc.  Make extern declarations in MsgHandlers.h and/or split the
// InstallGameMessageHandlers up as well
#include <time.h>

#include "MsgHandlers.h"
#include "Defines.h"
#include "Globals.h"
#include "Client.h"
#include "CreatureTemplate.h"
#include "Creature.h"
#include "DBCHandler.h"
#include "EventManager.h"
#include "UpdateBlock.h"
#include "Guild.h"
#include "Party.h"
#include "ChatManager.h"
#include "Packets.h"
#include "GameMechanics.h"
#include "Sha1.h"
#include "BigNumber.h"
#include "WowCrypt.h"
#include "SpellHandler.h"
#include "Debug.h"
#include "Graveyards.h"
#include "LootTable.h"
#include "GameObject.h"
#include "NPCText.h"
#include "Mail.h"
#include "Quest.h"
#include "QuestFunctions.h"
#include "TrainerTemplate.h"
#include "dbc_structs.h"

extern bool LoadAccount(char *name, CClient *pClient, bool createflag = true);

/* ---ADMINISTRATIVE HANDLERS--- */
void MsgPing(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CPacket pkg(SMSG_PONG, 10);
	int ping;
	Data >> ping;
	pkg << ping;
	pClient->Send(&pkg);
}

bool IsBanned(unsigned long ip) {
	if(Settings.Banned[ip]) return true;
	return false;
}

void MsgAuth(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
#ifdef ACCOUNTLESS
	pClient->SendAuthResponse(0xC);
	return;
#endif
	if (pClient->pAccount)
	{
		pClient->DestroyMe=true;
		return;
	}

	// server responses
	// response 1  = failure
	// response 2  = cancelled
	// response 3  = disconnect
	// response 4  = failed to connect
	// response 5  = (connect)
	// response 6  = wrong client version
	// response 7  = connecting to server...
	// response 8  = negotiating security
	// response 9  = security negotiation complete
	// response a  = security negotiation failed
	// response b  = authenticating
	// response c  = authentication successful  (login complete...)
	// response d  = authentication failed
	// response e  = Rejected - Please contact Customer Support
	// response f  = server is not valid
	// response 10 = System unavailable - Please try again later
	// response 11 = system error
	// response 12 = billing system error
	// response 13 = account billing has expired
	// response 14 = wrong client version
	// response 15 = unknown account
	// response 16 = incorrect password
	// response 17 = session expired
	// response 18 = server shutting down
	// response 19 = already logging in
	// response 1a = invalid login server
	// response 1b =
	// response 1c = retrieving realm list
	// response 1d = realm list retrieved
	// response 1e = unable to connect to realm list server
	// response 1f = invalid realm list
	// response 20 = realm is down
	// response 21 = creating account
	// response 22 = account created
	// response 23 = account creation failed
	// response 24 = retrieving character list
	// response 25 = character list retrieved
	// response 26 = error retrieving character list
	// response 27 = creating character
	// response 28 = (character created)
	// response 29 = error creating character
	// response 2A = character creation failed
	// response 2B = name already in use
	// response 2C = creation of that race and/or class is currently disabled
	// response 2d = deleting character
	// response 2e = character deleted
	// response 2f = character deletion failed
	// response 30 = entering the world of warcraft
	// response 31 = login successful

	if (IsBanned(pClient->socket.GetClientIP())) {
		pClient->SendAuthResponse(0x13);
		pClient->DestroyMe=true;
		return;
	}
	string name;
	Data.Get(8, name);
	if (name.length()<3 || name.length()>31)
	{
		pClient->SendAuthResponse(0xE); // auth failed
		pClient->DestroyMe=true;
		return;
	}
	unsigned long cSeed;
	char digest[20];
	Data.Get(9+name.length(),cSeed);
	Data.Get(13+name.length(),digest,20);
	//MakeLower(name);
	// check password
	CAccount *pAccount=0;
	unsigned long AccountID=DataManager.AccountNames[name];
	if (!AccountID) {
		if (LoadAccount((char*)name.c_str(),pClient)) {
			if(pClient->pAccount->Data.LockedToIP)
			{
				long clientip=pClient->socket.GetClientIP();
				if (clientip != pClient->pAccount->Data.ip) {
					pClient->SendAuthResponse(0xD);
					pClient->DestroyMe=true;
					return;
				}
			}
			pAccount=pClient->pAccount;
		}
		else
		{
			//pClient->SendAuthResponse(0x0A);
			//pClient->DestroyMe=true;
			// new account
			CAccount *pNewAccount = new CAccount;
			pNewAccount->New();
			strncpy(pNewAccount->Data.Name,name.data(), 32);
			strncpy(pNewAccount->Data.Password,"nneonneo", 32);
			pNewAccount->Data.ip = pClient->socket.GetClientIP();
			pNewAccount->Create();
			delete pNewAccount;
			LoadAccount((char*)name.c_str(),pClient);
			pAccount=pClient->pAccount;
		}
	}
	else DataManager.RetrieveObject((CWoWObject**)&pAccount,OBJ_ACCOUNT,AccountID);
	if(!pAccount)
	{
		pClient->SendAuthResponse(0xA); // failed
		pClient->DestroyMe=true;
		return;
	}
	if(pAccount->Data.LockedToIP)
	{
		long clientip=pClient->socket.GetClientIP();
		if (clientip != pAccount->Data.ip) {
			pClient->SendAuthResponse(0x0D);
			pClient->DestroyMe=true;
			return;
		}
	}
	if(pAccount->Data.UserLevel < USER_NORMAL) //ooh, time to check for banning!
	{
		if(pAccount->Data.UserLevel == USER_SUSPENDED)
		{
			if(pAccount->Data.SuspendedUntil >= time(0))
			{
				pClient->SendAuthResponse(0x0D);
				pClient->DestroyMe=true;
				return;
			}
			else
			{
				pAccount->Data.UserLevel=USER_NORMAL;
				pAccount->Data.SuspendedUntil=0;
			}
		}
		else
		{
			pClient->SendAuthResponse(0x0D);
			pClient->DestroyMe=true;
			return;
		}
	}
	pClient->pAccount=pAccount;
	pAccount->pClient=pClient;

	std::string senduser="\x22";
	senduser=senduser+name;
	char senddata[64];
	strncpy(senddata,senduser.data(),33);
	char sK[40];
	memset(sK,12,40);
	sK[0]=0;
	for (unsigned long i = 0 ; i < RealmServer.MasterLists.Size ; i++)
	{
		if (Addr* pAddr=RealmServer.MasterLists[i])
		{
			RealmServer.MasterList.SendTo(senddata,33,*pAddr);
			UDPSocket myrecv;
			myrecv.Create(Settings.Port_Sessionkey); //default port 31416
			for(int wait=0;wait<8;wait++)
			{
				if(myrecv.isData())
				{
					myrecv.RecvFrom(sK,40,*pAddr);
					break;
				}
				Sleep(30);
			}
			myrecv.ShutDown();
			if (sK[0]) break;
		}
	}

	BigNumber K;
	K.SetBinary((unsigned char *)sK,40);
	Sha1Hash sha;

	uint32 t = 0;
	uint32 seed = server_seed;

	sha.UpdateData(name);
	sha.UpdateData((uint8 *)&t, 4);
	sha.UpdateData((uint8 *)&cSeed, 4);
	sha.UpdateData((uint8 *)&seed, 4);
	sha.UpdateBigNumbers(&K, NULL);
	sha.Finalize();

	if (memcmp(sha.GetDigest(), digest, 20))
	{
		pClient->SendAuthResponse(0x15); // Bad Auth
		pClient->DestroyMe=true;
		return;
	}

	pClient->Crypter.SetKey((unsigned char *)sK, 40);
	pClient->Crypter.Init();

	// grab characters
	for (int i = 0 ; i < 10 ; i++)
	{
		if (unsigned long CharID=pAccount->Data.Characters[i])
		{
			CPlayer *pPlayer=0;
			if (DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,CharID))
			{
				pClient->Characters[i]=pPlayer;
				pClient->nCharacters++;
			}
		}
	}
	//pClient->SendAuthResponse(0xC); // success
	if ((RealmServer.nClients >= Settings.max_connections) &&
		(pClient->pAccount->Data.UserLevel <= USER_NORMAL)) { //queue him!
			CPacket pkg;
			pkg.Reset(SMSG_AUTH_RESPONSE);
			pkg << (char)0x1B; //You Are Queued!
			//1B 73 2C 00 00 00 00 00 00 00 61 00 00 00
			pkg << (long)0x00002C73; //what is this? miscellaneous garbage
			pkg << (char)0x00;
			pkg << (long)0;
			pkg << (long)(RealmServer.ServerQueue.size()+1); //+1 because you haven't been added yet
			RealmServer.ServerQueue.push_back(pClient);
			pClient->Send(&pkg);
			RealmServer.nClients--;
		}
	else pClient->OutPacket(SMSG_AUTH_RESPONSE,"\x0c\xcf\xd2\x07\x00\x00",6);
	Debug.Logf("%s successfully authed!",name.c_str());
}

/* ---CHARACTER HANDLERS--- */

void MsgCharList(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
#ifndef ACCOUNTLESS
	if (!pClient->pAccount)
		return;
#endif
	pClient->SendCharacterList();
}

void MsgCreateCharacter(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
#ifndef ACCOUNTLESS
	if (!pClient->pAccount)
		return;
#endif
	string Name;
	unsigned char createBytes[9];
	Data >> Name;
	Data.Read(createBytes, 9);
	if (Name.length() <= 2)
	{
		char c=0x42; // name too short!
		pClient->OutPacket(SMSG_CHAR_CREATE,&c,1);
		return;
	}
	if (Name.length()>12)
	{
		// send failure code
		char c=0x43; // name too long
		pClient->OutPacket(SMSG_CHAR_CREATE,&c,1);
		return;
	}
	if (pClient->nCharacters>=10)
	{
		// send failure code
		char c=0x34; // you have max. no. of characters already (10)
		pClient->OutPacket(SMSG_CHAR_CREATE,&c,1);
		return;
	}
	//MakeLower(Name);
	if (DataManager.PlayerNames[Name])
	{
		char c=0x31; // that name is unavailable
		pClient->OutPacket(SMSG_CHAR_CREATE,&c,1);
		return;
	}
	// create character
	for (unsigned long i = 0 ; i < 10 ; i++)
	{
		if (!pClient->Characters[i])
		{
			pClient->Characters[i]=new CPlayer;
			pClient->Characters[i]->New(Name.c_str(),createBytes);
			DataManager.NewObject(*pClient->Characters[i]);
			pClient->nCharacters++;
#ifndef ACCOUNTLESS
			pClient->pAccount->Data.Characters[i]=pClient->Characters[i]->guid;
			pClient->Characters[i]->AccountID = pClient->pAccount->guid;
			pClient->pAccount->Save();
#endif
			break;
		}
	}

	// send accept code
	char c=0x2E; //success
	pClient->OutPacket(SMSG_CHAR_CREATE,&c,1);
}

void MsgDeleteCharacter(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
#ifndef ACCOUNTLESS
	if (!pClient->pAccount)
		return;
#endif
	unsigned long N;
	Data >> N;
	N--;
	if (pClient->Characters[N])
	{
		pClient->Characters[N]->Delete();
		DataManager.DeleteObject(*pClient->Characters[N]);
		pClient->Characters[N]=0;
		pClient->nCharacters--;
#ifndef ACCOUNTLESS
		pClient->pAccount->Data.Characters[N]=0;
		pClient->pAccount->Save();
#endif
		unsigned long N=0x34;
		pClient->OutPacket(SMSG_CHAR_DELETE,&N,4);
		pClient->SendCharacterList();
	}
}

/* ---ENTER/EXIT HANDLERS--- */

extern fMessageHandler GameMessageHandlers[];
extern fMessageHandler LoginMessageHandlers[];

void MsgEnterGame(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
#ifndef ACCOUNTLESS
	if (!pClient->pAccount)
		return;
#endif
	pClient->MessageHandlers = GameMessageHandlers;
	unsigned char id;
	Data >> id;
	pClient->EnterGame(id);
}

void MsgLogoutRequest(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	if (pClient->pPlayer)
	{
		if(pClient->pPlayer->Data.StatusFlags & STATUS_ZZZZ) //at an inn
		{
			pClient->CompleteLogout();
			return;
		}
		_timeb now;
		_ftime(&now);
		if(EventManager.DiffTime(now, pClient->pPlayer->LastAttack) < 2000) // No logout for 2 secs after last attack
		{
			pClient->OutPacket(SMSG_LOGOUT_RESPONSE,"\x01\x00\x00\x00\x00",5);
			return;
		}
		pClient->pDataObject->SetStandState(UNIT_SITTING);
		pClient->UpdateObject();
		pClient->OutPacket(SMSG_LOGOUT_RESPONSE,"\x00\x00\x00\x00\x00",5);
		Packets::Root(pClient);
		EventManager.AddEvent(*(pClient->pPlayer),20000,EVENT_PLAYER_LOGOUT,0,0);
		pClient->LoggingOut=true;
		return;
	}
	pClient->OutPacket(SMSG_LOGOUT_COMPLETE,0,0);
	pClient->MessageHandlers = LoginMessageHandlers;
	pClient->pAccount->Save();
}

void MsgLogout(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	pClient->CompleteLogout();
}

void MsgLogoutCancel(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	if(pClient->pPlayer)
	{
		Packets::UnRoot(pClient);
		pClient->pDataObject->SetStandState(UNIT_STANDING);
		pClient->UpdateObject();
		pClient->pPlayer->ClearEvents(EVENT_PLAYER_LOGOUT);
		pClient->LoggingOut=false;
		pClient->pPlayer->InCombat = false;
	}
	pClient->OutPacket(SMSG_LOGOUT_CANCEL_ACK,0,0); //unknown function?
}

void MsgUpdateAccountData(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long Type;
	Data >> Type;
	unsigned char *pData;
	if(!pClient->pPlayer) return;
	switch(Type)
	{
	case 0:
		pData=pClient->pPlayer->Data.AccountData0;
		if(pClient->NextLength>300)
		{
			Debug.Logf("MsgUpdateAccountData() - Received data too long for Data0: Length %u.",pClient->NextLength);
			return;
		}
		break;
	case 1:
		pData=pClient->pPlayer->Data.AccountData1;
		if(pClient->NextLength>1200)
		{
			Debug.Logf("MsgUpdateAccountData() - Received data too long for Data1: Length %u.",pClient->NextLength);
			return;
		}
		break;
	case 2:
		pData=pClient->pPlayer->Data.AccountData2;
		if(pClient->NextLength>300)
		{
			Debug.Logf("MsgUpdateAccountData() - Received data too long for Data2: Length %u.",pClient->NextLength);
			return;
		}
		break;
	case 3:
		pData=pClient->pPlayer->Data.AccountData3;
		if(pClient->NextLength>300)
		{
			Debug.Logf("MsgUpdateAccountData() - Received data too long for Data3: Length %u.",pClient->NextLength);
			return;
		}
		break;
	case 4:
		pData=pClient->pPlayer->Data.AccountData4;
		if(pClient->NextLength>1350)
		{
			Debug.Logf("MsgUpdateAccountData() - Received data too long for Data4: Length %u.",pClient->NextLength);
			return;
		}
		break;
	default:
		return;
	}
	Data.Get(4,pData,pClient->NextLength-4);
	pClient->pPlayer->Data.AccountDataLen[Type]=pClient->NextLength-4;
}

/*
void MsgWorldPort(CClient *pClient, _InData *pData)
{
if (pClient->pPlayer->Data.bSummoned) {
pClient->Echo("Can't worldport when you've been summoned");
return;
}
char buf[0x11];
memset(buf,0,0x11);
pClient->pPlayer->Data.Continent=buf[0]=pData->Data[4];
memcpy(&buf[1],&pData->Data[5],0x10);
pClient->OutPacket(SMSG_NEW_WORLD,buf,0x11);
memcpy(&pClient->pPlayer->Data.Loc,&buf[1],sizeof(_Location));
pClient->pPlayer->Data.Facing=*(float*)&buf[0x0d];
RegionManager.ObjectRemove(*pClient->pPlayer);
}
*/
void MsgLoadNewWorld(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	pClient->SendPlayerData(true);
	RegionManager.ObjectNew(*pClient->pPlayer,pClient->pPlayer->Data.Continent,pClient->pPlayer->Data.Loc.X,pClient->pPlayer->Data.Loc.Y);
}

/* ---OBJECT QUERY HANDLERS--- */
void MsgPlayerName(CClient *pClient, unsigned int msgID, CDataBuffer &Data) // was unsigned int
{
	CPacket pkg(SMSG_NAME_QUERY_RESPONSE);
	unsigned long guid;
	Data >> guid;
	CPlayer *pPlayer=0;
	if (!DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,guid))
	{
		map<string, unsigned long>::iterator i;
		for (i=DataManager.PlayerNames.begin(); i!=DataManager.PlayerNames.end();i++)
		{
			if(i->second==guid)
			{
				pkg << guid ;
				pkg << PLAYERGUID_HIGH;
				pkg << (i->first).c_str();
				pkg << (unsigned long)1; //we cannot tell, so this is Human
				pkg << (unsigned long)0; //male
				pkg << (unsigned long)1; //warrior
				pClient->Send(&pkg);
				return;
			}
		}
		return;
	}

	pkg << guid ;
	pkg << PLAYERGUID_HIGH;
	pkg << pPlayer->Data.Name;
	pkg << (unsigned long)pPlayer->Data.Race;
	pkg << (unsigned long)pPlayer->Data.Female;
	pkg << (unsigned long)pPlayer->Data.Class;
	pClient->Send(&pkg);
}

void MsgNPCName(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long ID;
	Data >> ID;
	CCreatureTemplate *pCreatureTemplate=0;
	if (!DataManager.RetrieveObject((CWoWObject**)&pCreatureTemplate,OBJ_CREATURETEMPLATE,ID))
		return;
	CPacket pkg(SMSG_CREATURE_QUERY_RESPONSE);
	pkg << ID;
	pkg << pCreatureTemplate->Data.Name;
	pkg << (unsigned char)0;
	pkg << (unsigned char)0;
	pkg << (unsigned char)0;
	pkg << pCreatureTemplate->Data.Guild;
	// pkg << pCreatureTemplate->Data.Flags;	// flags
	pkg << (unsigned long)16;
	pkg << pCreatureTemplate->Data.Type;			// creature type
	pkg << pCreatureTemplate->Data.Family;			// family
	pkg << pCreatureTemplate->Data.Elite;			// elite mob?
	pkg << (unsigned long)0;			// unknown!
	pkg << (unsigned long)pCreatureTemplate->Data.Model;		// model obviously
	pkg << (unsigned short)1;	// civilian
	pClient->Send(&pkg);
}

void MsgItem(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long id;
	Data >> id;
	CItemTemplate *pItemTemplate=0;
	if (!DataManager.RetrieveObject((CWoWObject**)&pItemTemplate,OBJ_ITEMTEMPLATE,id))
		return;
	pItemTemplate->SendTemplate(pClient);
}

void MsgGameObjectQuery(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long guid;
	Data >> guid;
	CGameObjectTemplate *pTemplate=NULL;

	if (!DataManager.RetrieveObject((CWoWObject**)&pTemplate,OBJ_GAMEOBJECTTEMPLATE,DataManager.GameObjectEntries[guid]))
		return; // should we send anything? nah...not worth the effort :P
	CPacket pkg(SMSG_GAMEOBJECT_QUERY_RESPONSE);
	pkg << (unsigned long)guid;
	pkg << (unsigned long)pTemplate->Data.Type;
	pkg << (unsigned long)pTemplate->Data.Model;
	pkg << pTemplate->Data.Name;
	pkg << (unsigned long)0;

	pkg << (unsigned long)pTemplate->Data.Sound0;
	pkg << (unsigned long)pTemplate->Data.Sound1;
	pkg << (unsigned long)pTemplate->Data.Sound2;
	pkg << (unsigned long)pTemplate->Data.Sound3;
	pkg << (unsigned long)pTemplate->Data.Sound4;
	pkg << (unsigned long)pTemplate->Data.Sound5;
	pkg << (unsigned long)pTemplate->Data.Sound6;
	pkg << (unsigned long)pTemplate->Data.Sound7;
	pkg << (unsigned long)pTemplate->Data.Sound8;
	pkg << (unsigned long)pTemplate->Data.Sound9;
	pkg << (unsigned long)pTemplate->Data.Sound10;
	pkg << (unsigned long)0;
	pkg << (unsigned long)0;
	pkg << (unsigned long)0;
	pkg << (unsigned long)0;


	pkg << (unsigned short)(0);
	pkg << (unsigned char)0;
	pClient->Send(&pkg);
}

/* ---MOVE HANDLERS--- */
void MsgMove(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CPacket pkg;
	CPacket swimpkt;

	if(msgID==MSG_MOVE_HEARTBEAT)
	{
		pClient->pPlayer->CheckForNewArea();		// Exploration
	}

	unsigned long MovementFlags, MovementFlagsEx;
	Data >> MovementFlags >> MovementFlagsEx;
	Data >> pClient->pPlayer->Data.Loc;
	Data >> pClient->pPlayer->Data.Facing;

	if(pClient->pPlayer->SwimStartHeight != 0)
	{
		if(pClient->pPlayer->SwimStartHeight < pClient->pPlayer->Data.Loc.Z)
		{
			if(MovementFlags & 0x00200000)
			{
				// we're not underwater but still swimming
				if(pClient->pPlayer->BreathingAir != 1)
				{
					swimpkt.Reset(SMSG_STOP_MIRROR_TIMER);
					swimpkt << (unsigned long)1;	// breath
					pClient->Send(&swimpkt);
					// pClient->Echo("we're not underwater but still swimming");
					pClient->pPlayer->BreathingAir = 1;
					EventManager.AddEvent(*(pClient->pPlayer),10000,EVENT_PLAYER_REGENERATE,0,0);
				}
				pClient->pPlayer->Breath = 20000;
			} else {
				// we're not swimming
				pClient->pPlayer->SwimStartHeight = 0;
				if(pClient->pPlayer->BreathingAir != 1)
				{
					swimpkt.Reset(SMSG_STOP_MIRROR_TIMER);
					swimpkt << (unsigned long)1;	// breath
					pClient->Send(&swimpkt);
					// pClient->Echo("not swimming");
					pClient->pPlayer->BreathingAir = 1;
					EventManager.AddEvent(*(pClient->pPlayer),10000,EVENT_PLAYER_REGENERATE,0,0);
				}
				pClient->pPlayer->Breath = 20000;
			}
		} else {
			// we're underwater
			if(pClient->pPlayer->BreathingAir == 1)
			{
				pClient->pPlayer->BreathingAir = 0;
				CPacket pkg2;
				pkg2.Reset(SMSG_START_MIRROR_TIMER);
				pkg2 << (unsigned long)1;
				pkg2 << (unsigned long)20000;
				pkg2 << (unsigned long)20000;
				pkg2 << (unsigned long)-1;
				pkg2 << (unsigned long)0;
				pClient->Send(&pkg2);
				// pClient->Echo("Underwater");
				EventManager.AddEvent(*(pClient->pPlayer),1000,EVENT_PLAYER_REDUCEBREATH,0,0);
			}
		}
	}

	if(msgID==MSG_MOVE_START_SWIM)
	{
		if (pClient->pPlayer->Data.MountModel > 0)
			ForceDismount(pClient);
		// Mirror
		// Set start swim height
		pClient->pPlayer->SwimStartHeight = pClient->pPlayer->Data.Loc.Z - 0.15f;	// we want a bit of tolerence otherwise it says breath when you can breath fine.
		pClient->pPlayer->Breath = 20000;
	}

	// check this
	if (pClient->LastMoveFlags==0x00000200 && pClient->LastMoveFlags==MovementFlags)
		return; // standing still...still.

	// tell others we're moving
	RegionManager.ObjectMovement(*pClient->pPlayer,pClient->pPlayer->Data.Loc.X,pClient->pPlayer->Data.Loc.Y);
	pkg.Reset(msgID);
	Packets::PackGuid(pkg,pClient->pPlayer->guid,PLAYERGUID_HIGH);
	//pkg << (unsigned char)0xFF << (unsigned long)pClient->pPlayer->guid << (unsigned long)PLAYERGUID_HIGH;
	pkg.Write(Data.Buffer(), pClient->NextLength);//24);
	pClient->SendRegionNotMe(&pkg);
}

void MsgFall(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CPacket pkg;

	unsigned long MovementFlags, Time, FallTime;
	Data >> MovementFlags >> Time;
	Data >> pClient->pPlayer->Data.Loc;
	Data >> pClient->pPlayer->Data.Facing;
	Data >> FallTime;
	if ( FallTime > 1100 && !pClient->pPlayer->dead ) {
		pkg.Reset(SMSG_ENVIRONMENTALDAMAGELOG);
		long dmg=FallTime/100-10;
		Packets::PackGuid(pkg,pClient->pPlayer->guid,PLAYERGUID_HIGH);
		//pkg << (unsigned char)0xFF << pClient->pPlayer->guid << PLAYERGUID_HIGH;
		pkg << 2; //DAMAGE_FALL
		pkg << htonl(dmg); //10 dmg per second, none for the first second
		pClient->Send(&pkg);
		pClient->pPlayer->DataObject.AddHP(-dmg);
		if (!pClient->pPlayer->isregenning) {
			EventManager.AddEvent(*(pClient->pPlayer),2000,EVENT_PLAYER_REGENERATE,0,0);
			pClient->pPlayer->isregenning = true;
		}
		pClient->pPlayer->UpdateObject();
	}
	RegionManager.ObjectMovement(*pClient->pPlayer,pClient->pPlayer->Data.Loc.X,pClient->pPlayer->Data.Loc.Y);
	pkg.Reset(msgID);
	pkg << (unsigned long)pClient->pPlayer->guid << (unsigned long)PLAYERGUID_HIGH;
	pkg.Write(Data.Buffer(), pClient->NextLength);
	pClient->SendRegionNotMe(&pkg);
}

void MsgZone(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long zoneID;
	Data >> zoneID;
	/*
	#ZONE 1537 - Ironforge
	#ZONE 1638 - Thunder Bluff
	#ZONE 1497 - Undercity
	*/
	if(zoneID==1537)
	{
		switch(pClient->pPlayer->Data.Race)
		{
		case RACE_HUMAN:
		case RACE_DWARF:
		case RACE_NIGHTELF:
		case RACE_GNOME:
			pClient->RestStart();
			ForceDismount(pClient);
		}
	}
	else if(zoneID==1638 || zoneID==1497)
	{
		switch(pClient->pPlayer->Data.Race)
		{
		case RACE_ORC:
		case RACE_UNDEAD:
		case RACE_TAUREN:
		case RACE_TROLL:
			pClient->RestStart();
			ForceDismount(pClient);
		}
	}
	else if(pClient->pPlayer->Data.StatusFlags & STATUS_ZZZZ) pClient->RestStop(); // most of the time this'll work
	if(pClient->pPlayer->Data.Zone==zoneID) return;
	pClient->pPlayer->BuybackItems.clear();
	pClient->pPlayer->Data.Zone=zoneID;
	pClient->pPlayer->UpdateObject();
	pClient->pPlayer->LoadExploreSystem();	// we have to load the new zones! :)
}

void MsgAreaTrigger(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long Trigger;
	Data >> Trigger;
	/*
	71	Sentinel Hill Inn - Westfall - Eastern Kingdoms
	562	Lion's Pride Inn - Goldshire - Eastern Kingdoms
	682	Lakeshire Inn - Redridge Mountains - Eastern Kingdoms

	707	Darkshire Scarlet Raven Inn - Duskwood - Eastern Kingdoms
	708	Southshore Tavern - Hillsbrad Foothills - Eastern Kingdoms
	709	Theramore Isle Tavern - Dustwallow Marsh - Kalimdor
	710	Thunderbrew Distillery - Dun Morogh - Eastern Kingdoms
	712	Stourlager Inn - Loch Modan - Eastern Kingdoms
	713	Deepwater Tavern - Wetlands - Eastern Kingdoms
	715	Dolanaar Inn - Teldrassil - Kalimdor
	716	Auderdine Inn - Darkshore - Kalimdor
	717	Astranaar Inn - Ashenvale - Kalimdor
	719	Gallows End Tavern - Tirisfal Glades - Eastern Kingdoms
	720	The Sepulcher Inn - Silverpine Forest - Eastern Kingdoms
	721	Tarren Mill Inn - Hillsbrad Foothills - Eastern Kingdoms
	722	Bloodhoof Village Inn - Mulgore - Kalimdor
	742	The Crossroads Tavern - The Barrens - Kalimdor
	743	Ratchet Inn - The Barrens - Kalimdor

	843	Razor Hill Inn - Durotar - Kalimdor
	844	Stonard Inn - Swamp of Sorrows - Eastern Kingdoms
	862	The Salty Sailor Tavern - Stranglethorn Vale - Eastern Kingdoms

	982  	Camp Taurajo Inn - The Barrens - Kalimdor

	1022?	Sun Rock Retreat - Stonetalon Mountain - Kalimdor
	1023 	Gadgetzan Inn - Tanaris - Kalimdor
	1024 	Feathermoon Stronghold Inn - Feralas - Kalimdor
	1025 	Camp Mojache Inn - Feralas - Kalimdor

	2266 	Nijel's Point Inn - Desolace - Kalimdor
	2267 	Shadowprey Village Inn - Desolace - Kalimdor
	2286 	Freewind Post Inn - Thousand Needles - Kalimdor
	2287 	Everlook Inn - Winterspring - Kalimdor

	2786	Stormwind City Gates - Stormwind City - Eastern Kingdoms
	3546	Darnassus*/
	map<unsigned long,AreaTrigger>::iterator i=RealmServer.AreaTriggers.find(Trigger);
	if(i!=RealmServer.AreaTriggers.end())
	{
		AreaTrigger at=i->second;
		Packets::TeleportOrNewWorld(pClient,at.TargetMap,at.TargetLoc,at.TargetFacing);
	}
	if(Trigger<=743 && Trigger >=707)
	{
		pClient->RestStart(); //large unbroken set of inns
		ForceDismount(pClient);
		return;
	}
	switch(Trigger)
	{
	case 71:
	case 562:
	case 682:
	case 843:
	case 844:
	case 862:
	case 982:
	case 1023:
	case 1024:
	case 1025:
	case 2266:
	case 2267:
	case 2286:
	case 2287:
	case 2786:
	case 3546:
		ForceDismount(pClient);
		pClient->RestStart(); //large unbroken set of inns
		return;
	}
}

void ForceDismount(CClient *pClient)
{
	if (pClient->pPlayer->Data.MountModel && !pClient->pPlayer->bIsFlying)
	{
		pClient->pPlayer->RemoveAura(pClient->pPlayer->MountedAuraSlot);
		pClient->pPlayer->SetSpeed(DEFAULT_PLAYER_RUN_SPEED);
		pClient->pDataObject->SetMountModel(0);
		pClient->pPlayer->Data.MountModel = 0;
		pClient->UpdateObject();
	}
}

/* ---NPC INTERACTION HANDLERS--- */
void MsgPetitionShow(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long guid;
	Data >> guid;
	CPacket pkg;
	pkg.Reset(SMSG_PETITION_SHOWLIST);
	pkg << guid << PLAYERGUID_HIGH;
	pkg << (char)1;
	pkg << (unsigned long)1;
	pkg << (unsigned long)0x16e7;
	pkg << (unsigned long)0x23ef;
	pkg << (unsigned long)1000;
	pkg << (unsigned long)1;
	pClient->Send(&pkg);
}

void MsgPetitionBuy(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long guid, guidhigh;
	unsigned long junk, junk2, junk3;
	string guildname;
	Data >> guid >> guidhigh >> junk >> junk2 >> junk3;
	Data >> guildname;

	string name = guildname;
	MakeLower(name);
	if(CGuild::AllGuilds.find(name) != CGuild::AllGuilds.end())
	{
		pClient->Echo("That guild already exists!");
		return;
	}
	CGuild *pGuild = new CGuild();
	pGuild->New(guildname.c_str(), pClient);
	DataManager.NewObject(*pGuild);
	CGuild::AllGuilds[name] = pGuild->guid;
	pClient->Echo("You created guild %s. Type '!tabard' to get your guild tabard.", guildname.c_str());
	pClient->Echo("As a guildmaster you can go to a tabard vendor and choose your guild emblem.");
}

void MsgBinderActivate(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long guid;
	Data >> guid; //PLAYER!!!!
	CPlayer *pCreature;
	if(!DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_PLAYER,guid)) return;
	if(pClient->pPlayer->Data.BindLoc.X==pCreature->Data.Loc.X && pClient->pPlayer->Data.BindLoc.Y==pCreature->Data.Loc.Y && pClient->pPlayer->Data.BindContinent==pCreature->Data.Continent)
	{
		pClient->OutPacket(SMSG_PLAYERBINDERROR,0,0);
		return;
	}
	pClient->pPlayer->Data.BindLoc=pCreature->Data.Loc;
	pClient->pPlayer->Data.BindContinent=pCreature->Data.Continent;
	pClient->pPlayer->Data.BindZone = pCreature->Data.Zone;
	pClient->SaveBindPoint();
	pClient->OutPacket(SMSG_PLAYERBOUND,0,0); //whoosh sound xD
}

/* ---SOCIAL HANDLERS--- */
void MsgEmote(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long emote_code,unknown, emote_target, emote_targethigh;
	Data >> emote_code >> unknown >> emote_target >> emote_targethigh;

	/*const char *nam = 0;
	unsigned long namlen = 1;
	CCreature *pCreature;
	CPlayer *pPlayer;

	if (DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE,emote_target))
	{
	// creature
	nam = pCreature->pTemplate->Data.Name;
	namlen = strlen(pCreature->pTemplate->Data.Name) + 1;
	} else if (DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,emote_target))
	{
	// player
	nam = pPlayer->Data.Name;
	namlen = strlen(pPlayer->Data.Name) + 1;
	}
	unsigned long animation = DBCManager.Emotes.getValue(emote_code, DBC_EMOTES_ANIM);

	CPacket pkg;
	pkg.Reset(SMSG_EMOTE);
	pkg << (unsigned long)animation;
	pkg << (unsigned long)pClient->pPlayer->guid << PLAYERGUID_HIGH;

	pClient->SendRegion(&pkg);

	pkg.Reset(SMSG_TEXT_EMOTE);
	pkg << (unsigned long)pClient->pPlayer->guid << PLAYERGUID_HIGH;
	pkg << (unsigned long)emote_code;
	pkg << (unsigned long)0xFF;
	pkg << (unsigned long)namlen;
	if (namlen > 1)
	pkg << nam;
	else
	pkg << (unsigned char)0x00;

	pClient->SendRegion(&pkg);*/

	unsigned long animation = DBCManager.Emotes.getValue(emote_code, DBC_EMOTES_ANIM);
	if (emote_code == 0x56 || emote_code == 0x8D) return; //sit, stand do not require emoting
	// Text packet
	char target_name[64];
	if (emote_target && emote_target != pClient->pPlayer->guid)
	{
		CCreature *pCreature = NULL;
		if (DataManager.RetrieveObject((CWoWObject**)&pCreature, OBJ_CREATURE, emote_target))
		{
			CCreatureTemplate *pCreatureTemplate=0;
			if (DataManager.RetrieveObject((CWoWObject**)&pCreatureTemplate, OBJ_CREATURETEMPLATE, pCreature->Data.Template))
			{
				strcpy(&target_name[0], pCreatureTemplate->Data.Name);
			}
		}
		else
		{
			CPlayer *pPlayer = NULL;
			if (DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, emote_target))
			{
				strcpy(&target_name[0], pPlayer->Data.Name);
			}
		}
	}
	pClient->Emote((unsigned long)pClient->pPlayer->guid, (unsigned long)animation, (unsigned long)emote_code, (unsigned long)emote_target, (char *)&target_name, (unsigned long) emote_targethigh);
}

void MsgWho(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long LevelMin,LevelMax,Races,Classes,Continent,Zone;
	string Name,Guild;
	Data >> LevelMin >> LevelMax;
	Data.Read(Name);
	Data.Read(Guild);
	Data >> Races >> Classes >> Continent >> Zone;
	CPacket pkg;
	pkg.Reset(SMSG_WHO);
	long nplayer=0;
	pkg << (long)0 << (long)0;
	for (unsigned long i = 0 ; i < RealmServer.Clients.Size ; i++)
	{
		if (CClient *pClient=RealmServer.Clients[i])
		{
			if(pClient->pPlayer)
			{
				if(Zone && pClient->pPlayer->Data.Zone!=Zone) continue;
				if(pClient->pPlayer->Data.Level<LevelMin || pClient->pPlayer->Data.Level>LevelMax) continue;
				if(!(Classes & (1<<pClient->pPlayer->Data.Class)) || !(Races & (1<<pClient->pPlayer->Data.Race))) continue;
				if(!Name.empty())
				{
					string PlayerName(pClient->pPlayer->Data.Name);
					if(PlayerName.find(Name) == -1) continue;
				}
				CGuild *pGuild=NULL;
				DataManager.RetrieveObject((CWoWObject **)&pGuild,OBJ_GUILD,pClient->pPlayer->Data.GuildID);
				if(!Guild.empty())
				{
					if(!pGuild) continue;
					string PlayerGuild(pGuild->Data.Name);
					if(PlayerGuild.find(Guild) == -1) continue;
				}
				nplayer++;
				pkg.Write(pClient->pPlayer->Data.Name);
				if(pGuild) pkg.Write(pGuild->Data.Name);
				else pkg << (char)0;
				pkg << (unsigned long)pClient->pPlayer->Data.Level;
				pkg << (unsigned long)pClient->pPlayer->Data.Class;
				pkg << (unsigned long)pClient->pPlayer->Data.Race;
				pkg << (unsigned long)pClient->pPlayer->Data.Zone;
				//pkg << (unsigned long)pClient->pPlayer->Data.LFG;
			}
		}
	}
	pkg.Set(4,nplayer); //4=offset of data (first 4 bytes are header)
	pkg.Set(8,nplayer);
	pClient->Send(&pkg);
}

void MsgLFG(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	char buf[0x04];
	memset(buf,0,0x04);
	if (pClient->pPlayer->Data.LFG == 0) {
		pClient->pPlayer->Data.LFG = (unsigned short)1;
	}
	else {
		pClient->pPlayer->Data.LFG = (unsigned short)0;
	}
	pClient->OutPacket(CMSG_SET_LOOKING_FOR_GROUP,buf,0x04);
}

/* ---BATTLE HANDLERS--- */
void MsgPvp(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	if (pClient->pPlayer->Data.RecentPvP) {
		pClient->Echo("PvP was %s recently.  You have to wait 30 seconds to change the setting.",pClient->pPlayer->Data.PvP ? "Enabled" : "Disabled");
	}
	else {
		pClient->pDataObject->TogglePVP();
		pClient->pPlayer->AddUpdateVal(UNIT_FIELD_FLAGS,UNIT_FLAG_ATTACKABLE);
		pClient->UpdateObject/*NotMe*/();
		//disabling next line b/c the setting of PLAYER_FLAGS automatically makes the correct message appear
		//pClient->Echo("PvP %s",pClient->pPlayer->Data.PvP ? "Enabled" : "Disabled");
		EventManager.AddEvent(*(pClient->pPlayer),30000,EVENT_PLAYER_PVP,0,0);
	}
}
void MsgAttackSwing(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	pClient->pPlayer->bIsInCombat = true;
	MsgAttackOn(pClient,msgID,Data);
}

void MsgAttackOn(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	if (!pClient->pPlayer->bIsInCombat) return;
	CPacket pkg;

	_timeb now;
	_ftime(&now);
	unsigned long diff = (unsigned long)EventManager.DiffTime(now, pClient->pPlayer->LastAttack);
	unsigned long delay = pClient->pPlayer->Data.AttackSpeed;
	if (delay > diff) {
		return;
	}

	unsigned long guid, guidhigh;
	Data >> guid >> guidhigh;

	CWoWObject *pVictim;

	CCreature *pCreature = NULL;
	CPlayer *pPlayer = NULL;

	DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,guid);
	DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE,guid);

	DataManager.RetrieveObject(&pVictim,guid);

	if(pVictim->type == OBJ_CREATURE)
	{
		if (!pCreature->bMoving)
		{
			if ((pCreature && pClient->pPlayer->Distance(*pCreature) > 5.0f) || (pPlayer && pClient->pPlayer->Distance(*pPlayer) > 5.0f)) //don't reinvent the wheel :D
			{
				pClient->OutPacket(SMSG_ATTACKSWING_NOTINRANGE,0,0);
				EventManager.AddEvent(*(pClient->pPlayer),pClient->pPlayer->Data.AttackSpeed,EVENT_PLAYER_END_ATTACK,Data.Buffer(),8);
				return;
			}
		} else {
			if ((pCreature && pClient->pPlayer->Distance(*pCreature) > 16.5f) || (pPlayer && pClient->pPlayer->Distance(*pPlayer) > 11.5f)) //don't reinvent the wheel :D
			{
				pClient->OutPacket(SMSG_ATTACKSWING_NOTINRANGE,0,0);
				EventManager.AddEvent(*(pClient->pPlayer),pClient->pPlayer->Data.AttackSpeed,EVENT_PLAYER_END_ATTACK,Data.Buffer(),8);
				return;
			}
		}
	} else {
		if ((pPlayer && pClient->pPlayer->Distance(*pPlayer) > 5.0f)) //don't reinvent the wheel :D
		{
			pClient->OutPacket(SMSG_ATTACKSWING_NOTINRANGE,0,0);
			EventManager.AddEvent(*(pClient->pPlayer),pClient->pPlayer->Data.AttackSpeed,EVENT_PLAYER_END_ATTACK,Data.Buffer(),8);
			return;
		}
	}

	if(pCreature && !pClient->pPlayer->IsFacing(pCreature))
	{
		pClient->OutPacket(SMSG_ATTACKSWING_BADFACING,0,0);
		EventManager.AddEvent(*(pClient->pPlayer),pClient->pPlayer->Data.AttackSpeed,EVENT_PLAYER_END_ATTACK,Data.Buffer(),8);
		return;
	}

	if (pVictim)
		GameMechanics::AttackSwing(((CWoWObject*)pClient->pPlayer),(pVictim));

	_ftime(&pClient->pPlayer->LastAttack);

	if(pClient->pPlayer->bIsInCombat)
	{
		unsigned long diff = (unsigned long)EventManager.DiffTime(now, pClient->pPlayer->LastAttack);
		unsigned long delay = pClient->pPlayer->Data.AttackSpeed;
		EventManager.AddEvent(*(pClient->pPlayer),delay - diff,EVENT_PLAYER_END_ATTACK,Data.Buffer(),8);
	}

	return;
	/*
	// ===== CHECK FOR RESSICKNESS ===== //

	if (pClient->pPlayer->Data.ResurrectionSickness) {
	pkg.Reset(SMSG_ATTACKSTOP);
	pkg << (unsigned char)0xFF << pClient->pPlayer->guid << PLAYERGUID_HIGH
	<< (unsigned char)0xFF << guid << guidhigh
	<< 0;
	pClient->Send(&pkg);
	pClient->Echo("You can't attack while you have resurrection sickness...please wait");
	return;
	}

	CPlayer *pPlayer=NULL;
	CCreature *pCreature=NULL;

	// ===== CHECK FOR PVP ===== //

	DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,guid);
	if (pPlayer != NULL) {
	if (!(pClient->pPlayer->Data.PvP)) {
	pClient->Echo("You can't attack others unless you set PvP (type '/pvp' in the SAY box) and they are also PvP");
	return;
	}
	}

	// ===== CHECK VARIABLES ===== //

	DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE,guid);
	if (pCreature == NULL && pPlayer == NULL)
	{
	pkg.Reset(SMSG_ATTACKSTOP);
	pkg << (unsigned char)0xFF << pClient->pPlayer->guid << PLAYERGUID_HIGH
	<< (unsigned char)0xFF << guid << guidhigh
	<< 0;
	pClient->Send(&pkg);
	return;
	}

	// ===== VENDOR KILL CHECK ===== //

	if ((pCreature != NULL) && (pCreature->pTemplate->Data.NPCFlags))
	{
	pClient->Echo("Attacking vendors is not allowed");	// bur: it is, but counts as a DK
	pkg.Reset(SMSG_ATTACKSTOP);
	pkg << (unsigned char)0xFF << pClient->pPlayer->guid << PLAYERGUID_HIGH
	<< (unsigned char)0xFF << guid << guidhigh
	<< 0;
	pClient->Send(&pkg);
	return;
	}

	// ===== CHECK IF OBJECT IS IN RANGE ===== //

	if (pCreature->bMoving)
	{
	if ((pCreature && pClient->pPlayer->Distance(*pCreature) > 5.0f) || (pPlayer && pClient->pPlayer->Distance(*pPlayer) > 5.0f)) //don't reinvent the wheel :D
	{
	pClient->OutPacket(SMSG_ATTACKSWING_NOTINRANGE,0,0);
	EventManager.AddEvent(*(pClient->pPlayer),pClient->pPlayer->Data.AttackSpeed,EVENT_PLAYER_END_ATTACK,Data.Buffer(),8);
	return;
	}
	} else {
	if ((pCreature && pClient->pPlayer->Distance(*pCreature) > 11.5f) || (pPlayer && pClient->pPlayer->Distance(*pPlayer) > 11.5f)) //don't reinvent the wheel :D
	{
	pClient->OutPacket(SMSG_ATTACKSWING_NOTINRANGE,0,0);
	EventManager.AddEvent(*(pClient->pPlayer),pClient->pPlayer->Data.AttackSpeed,EVENT_PLAYER_END_ATTACK,Data.Buffer(),8);
	return;
	}
	}



	if(pCreature && !pClient->pPlayer->IsFacing(pCreature))
	{
	pClient->OutPacket(SMSG_ATTACKSWING_BADFACING,0,0);
	EventManager.AddEvent(*(pClient->pPlayer),pClient->pPlayer->Data.AttackSpeed,EVENT_PLAYER_END_ATTACK,Data.Buffer(),8);
	return;
	}

	// ===== MISC ===== //

	_ftime(&pClient->pPlayer->LastAttack); // set last attack before it's too late!
	pClient->RestStop(); //you can't rest and attack at the same time.
	ForceDismount(pClient);	// you can't be mounted :P

	Packets::AttackStart(pClient,guid,guidhigh);

	// Temporary way to check if player has a ranged weapon equipped
	// and attack with a ranged weapon
	CItem *pItem = NULL;
	if (DataManager.RetrieveObject((CWoWObject**)&pItem,OBJ_ITEM,pClient->pPlayer->Data.Items[SLOT_RANGED]))
	{
	if (pItem->pTemplateData)
	{
	CWoWObject *pTarget = NULL;
	if (!pCreature)
	DataManager.RetrieveObject((CWoWObject**)&pTarget,OBJ_PLAYER,guid);
	else
	pTarget = pCreature;

	if (pTarget)
	{
	unsigned long abilityID=0;
	switch (pItem->pTemplateData->SubClass)
	{
	case 2: // bow
	abilityID = 0x003B;
	break;
	case 3: // gun
	abilityID = 0x07A7;
	break;
	case 16: // throwing
	abilityID = 0x0ACC;
	break;
	case 19: // wand
	abilityID = 0x139B;
	break;
	}
	if(abilityID)
	{
	pTarget->ApplySpell(*pClient->pPlayer,abilityID,guidhigh);
	return;
	}
	}
	}
	}
	*/
	/*
	int flag=0;
	int victimflags = 0;
	long dmg = pClient->pPlayer->CalculateDmg(DMGTYPE_WEAPON,0, flag, victimflags);
	*/
	// ===== UPDATE SKILLS ===== //
	pClient->pPlayer->CheckForSkillUpdate(false);

	// adjust dmg for difference in levels
	/*if (pCreature != NULL) {
	if (pCreature->Data.Level > pClient->pPlayer->Data.Level) {
	dmg=dmg/(long)(((pCreature->Data.Level - pClient->pPlayer->Data.Level)*1.5f));
	}
	}*/
	/*

	pClient->pPlayer->InCombat = true;
	GameMechanics::RageForHitting(pClient->pPlayer,pCreature,dmg);

	pkg.Reset(SMSG_ATTACKERSTATEUPDATE);

	pkg << flag;
	pkg << (unsigned char)0xFF << pClient->pPlayer->guid << PLAYERGUID_HIGH;
	pkg << (unsigned char)0xFF << guid << guidhigh;
	pkg << dmg;
	pkg << (char)1; //Damage Count

	pkg << (long)0; //Damage Type
	pkg << (float)dmg; // Damage Float
	pkg << dmg; // Damage in Rt. Window
	pkg << (long)0; // Damage Absorbed
	pkg << (long)0; // Spell Link
	pkg << (long)victimflags; // 2 dodge, 3 parry, 4 interrupt, 5 block, 6 evade, 7 immune, 8 deflect
	pkg << (unsigned long)0xFFFFFFFF;		// if blocked damage, this is 0
	pkg << (unsigned long)0;
	pkg << (unsigned long)0;

	pClient->SendRegion(&pkg); //aha!

	bool StopAttack = false;
	if (pCreature != NULL)
	{
	pCreature->TakeDamage(pClient->pPlayer,dmg,false);
	if (pCreature->dead)
	StopAttack = true;
	}
	else
	{  // Try PvP
	CPlayer *pPlayer=NULL;
	DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,guid);
	if (pPlayer && pPlayer->pClient)
	{
	if (pClient->pPlayer->Data.PvP)
	{
	pPlayer->DataObject.AddHP(-dmg);
	if (!pPlayer->isregenning) {
	EventManager.AddEvent(*(pPlayer),2000,EVENT_PLAYER_REGENERATE,0,0);
	pPlayer->isregenning = true;
	}
	if ((long)(pPlayer->Data.CurrentStats.HitPoints) <= 0 && !pPlayer->dead)
	{
	pPlayer->dead = true;
	pPlayer->ClearEvents();
	long Exp = 150;
	CPlayer *tPlayer = (CPlayer *)pClient->pPlayer;
	if (tPlayer->Data.Level > pPlayer->Data.Level) {
	Exp -= (Exp * (tPlayer->Data.Level - pPlayer->Data.Level))/5;
	if (Exp < 0)
	Exp = 0;
	}
	CPacket pkg;
	pkg.Reset(SMSG_LOG_XPGAIN);
	pkg << guid << PLAYERGUID_HIGH;
	pkg << (long)Exp << (char)0;
	pkg << (long)Exp << (float)1.0;
	pClient->Send(&pkg);
	EventManager.AddEvent(*pClient->pPlayer, 0, EVENT_PLAYER_GAINEXP, &Exp, sizeof(Exp));
	pPlayer->pClient->Echo("You have been slain by %s", pClient->pPlayer->Data.Name);
	StopAttack = true;
	}
	pPlayer->UpdateObject();
	}
	else
	pClient->Echo("You can't attack others unless you set PvP");
	}
	}


	if(StopAttack)
	{
	Packets::AttackStop(pClient,guid,guidhigh);
	}
	else
	{
	_timeb now;
	_ftime(&now);
	unsigned long diff = (unsigned long)EventManager.DiffTime(now, pClient->pPlayer->LastAttack);
	unsigned long delay = pClient->pPlayer->Data.AttackSpeed;
	EventManager.AddEvent(*(pClient->pPlayer),delay - diff,EVENT_PLAYER_END_ATTACK,Data.Buffer(),8);
	}*/
}

void MsgAttackOff(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	Packets::AttackStop(pClient,0,0);
	pClient->pPlayer->ClearEvents(EVENT_PLAYER_END_ATTACK);
	// Start rage degeneration
	EventManager.AddEvent(*(pClient->pPlayer),3000,EVENT_PLAYER_RAGEDEGENERATE,Data.Buffer(),Data.Size());
	pClient->pPlayer->InCombat = false;
}

/* ---DEATH HANDLERS--- */
void MsgRepop(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CPacket pkg;

	pClient->pPlayer->CreateGhost();
	pClient->pPlayer->CreateCorpse();
	pClient->pPlayer->Data.bDead = true;
	pClient->pPlayer->dead = true;  // needs to be removed from checks yet
	pClient->pPlayer->bSheathed = true;

	////// REPOP AT GRAVEYARD
	_Graveyard Grave;

	Grave = GetGraveyard(pClient->pPlayer->Data.Loc,pClient->pPlayer->Data.Continent);
	pClient->pPlayer->Data.Loc.X = Grave.Loc.X;
	pClient->pPlayer->Data.Loc.Y = Grave.Loc.Y;
	pClient->pPlayer->Data.Loc.Z = Grave.Loc.Z;
	Packets::SendTeleport(pClient);

	pkg.Reset(MSG_MOVE_HEARTBEAT);
	Packets::PackGuid(pkg,pClient->pPlayer->guid,PLAYERGUID_HIGH);
	/*pkg << (unsigned char)0xFF;
	pkg << pClient->pPlayer->guid;
	pkg << (unsigned long)0;*/
	pkg << (unsigned long)0;
	pkg << (unsigned long)0;
	pkg << Grave.Loc.X;
	pkg << Grave.Loc.Y;
	pkg << Grave.Loc.Z;
	pkg << pClient->pPlayer->Data.Facing;
	pClient->SendRegionNotMe(&pkg,SAYDIST);

	pClient->pPlayer->DeathDurabilityLoss();
}

void MsgCorpseQuery(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CCorpse *pCorpse =  NULL;

	if(!pClient->pPlayer->Corpse){
		return;
	}

	if(!DataManager.RetrieveObject((CWoWObject**)&pCorpse,OBJ_CORPSE,pClient->pPlayer->Corpse))
	{
		return;
	}

	CPacket pkg(MSG_CORPSE_QUERY);
	pkg << (unsigned char) 1;
	pkg << (unsigned long) pCorpse->Data.Continent;
	pkg << pCorpse->Data.Loc.X;
	pkg << pCorpse->Data.Loc.Y;
	pkg << pCorpse->Data.Loc.Z;
	pkg << (unsigned long) pClient->pPlayer->Data.Continent;

	pClient->Send(&pkg);
}

void MsgReclaimCorpse(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	if(pClient->pPlayer->Data.bDead)
	{
		pClient->pPlayer->Resurrect();
	}
}

void MsgResurrectResponse(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	if(!pClient->pPlayer->Data.bDead)
		return;

	unsigned long Guid;
	unsigned long GuidHigh;
	unsigned char Status;

	Data >> Guid;
	Data >> GuidHigh;
	Data >> Status;

	if(Status != 0)
		return;

	pClient->pPlayer->Resurrect();
}

/* ---LOOT HANDLERS--- */
void MsgLootUnit(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	/*
	DIRECTION UNKNOWN Data len=001F op=0153 int=0000 msglen=001B -- OnLootEvent
	0000:  B8 6A 00 00-00 10 00 F0-01 00 00 00-00 01 00 3C  +j.....=.......<
	0010:  0B 00 00 01-00 00 00 04-1A 00 00   -             ...........
	*/
	CCreature* pCreature = NULL;
	unsigned long CreatureGuid, guidhigh;
	Data >> CreatureGuid;
	Data >> guidhigh;
	pClient->pPlayer->LootID = CreatureGuid;
	DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE,CreatureGuid);
	long money = 0;
	if(pCreature != NULL) {
		money = pCreature->Data.LootMoney;
	}
	else return; //we are NOT going to make items for a nonexistant creature :X
	if(!pCreature->bLooted) CLootTable::GenerateLoot(pCreature); //make only if we haven't made up the loots already
	CPacket pkg(SMSG_LOOT_RESPONSE, 20);
	pkg << CreatureGuid << guidhigh;
	//01: Has money; 02: no money
	pkg << (char)(money?0x01:0x02);//0x03 = fishing loot?
	pkg << money;
	pkg << (char)pCreature->LootedItems.size();
	//pkg << (char)0x00;//itemcount max 16
	for(map<char,CItemTemplate *>::iterator i=pCreature->LootedItems.begin();i!=pCreature->LootedItems.end();i++)
	{
		pkg << (char)i->first;
		pkg << (unsigned long)i->second->guid;
		pkg << (unsigned long)i->second->Data.MaxStack;
		pkg << (unsigned long)i->second->Data.DisplayID;
		pkg << (unsigned long)0;
		pkg << (unsigned long)0;
		pkg << (char)0; // 1="That item is still being rolled for", 2=nothing happens (unlootable?)
	}
	pCreature->bLooted=true;
	/*
	BYTE Slot
	UINT ItemID
	UINT DisplayID
	UINT Quantity
	UINT Unk1
	UINT unk2
	*/
	pClient->Send(&pkg);

	/*memset(buffer,0,0x23);
	*(unsigned long*)&buffer[0x00]=*(unsigned long*)&pData->Data[0];
	*(unsigned long*)&buffer[0x04]=*(unsigned long*)&pData->Data[4];
	*(unsigned char*)&buffer[0x08]=0x01;
	*(unsigned short*)&buffer[0x09]=money;//0x01;   // money
	*(unsigned short*)&buffer[0x0B]=0x00;//0x0A;   // item id
	*(unsigned long*)&buffer[0x0D]=0x01;
	*(unsigned short*)&buffer[0x12]=0x00;//0x1A04;     // model id
	pClient->OutPacket(SMSG_LOOT_RESPONSE,buffer,0x23);*/
}

void MsgLootMoney(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CCreature* pCreature = NULL;
	unsigned long CreatureGuid=pClient->pPlayer->LootID;
	DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE,CreatureGuid);
	short money = 0;
	if(pCreature != NULL) {
		money = (short)pCreature->Data.LootMoney;
		pCreature->Data.LootMoney = 0;
	}
	CParty *pParty = NULL;
	if ((pClient->pPlayer->Data.PartyID == 0) || (!DataManager.RetrieveObject((CWoWObject**)&pParty, OBJ_PARTY, pClient->pPlayer->Data.PartyID)))
	{
		pClient->pPlayer->Data.Copper += money;
		pClient->pPlayer->DataObject.SetCoinage(pClient->pPlayer->Data.Copper);
		pClient->pPlayer->UpdateObject();
	}
	else {
		pParty->ShareLoot(money);
	}
}

void MsgGameObjectUse(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CGameObject* pGO = NULL;
	unsigned long GOGuid;
	Data >> GOGuid;
	pClient->pPlayer->LootID = GOGuid;
	//there's also guidhigh but who cares ;)
	if(!DataManager.RetrieveObject((CWoWObject**)&pGO,OBJ_GAMEOBJECT,GOGuid)) return;
	if(pGO->pTemplate && !pGO->pTemplate->LootTable.empty()) // do we have any items to loot?
	{
		if(!pGO->bLooted) pGO->pTemplate->GenerateLoot(pGO); //make only if we haven't made up the loots already
		CPacket pkg(SMSG_LOOT_RESPONSE);
		pkg << GOGuid << GAMEOBJECTGUID_HIGH;
		pkg << (char)0x02;
		pkg << (unsigned long)0; //no money
		pkg << (char)pGO->LootedItems.size();

		for(map<char,CItemTemplate *>::iterator i=pGO->LootedItems.begin();i!=pGO->LootedItems.end();i++)
		{
			pkg << (char)i->first;
			pkg << (unsigned long)i->second->guid;
			pkg << (unsigned long)i->second->Data.MaxStack;
			pkg << (unsigned long)i->second->Data.DisplayID;
			pkg << (unsigned long)0;
			pkg << (unsigned long)0;
			pkg << (char)0; // 1="Still Rolled For", 2="Unlootable"
		}
		pGO->bLooted=true;
		pClient->Send(&pkg);
	}
}

void MsgStoreLoot(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned char slot;
	Data >> slot;
	/*
	______________________________________________________________
	DIRECTION UNKNOWN Data len=000C op=0195 int=0000 msglen=0008 -- OnQuestUpdate

	0000:  3C 0B 00 00-01 00 00 00-           -             <.......
	~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	______________________________________________________________
	DIRECTION UNKNOWN Data len=0005 op=0155 int=0000 msglen=0001 -- OnLootEvent

	0000:  00         -           -           -             .
	~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	*/
	CCreature *pCreature=NULL;
	CGameObject *pObject=NULL;
	CItemTemplate *pTemplate=NULL;
	if(DataManager.RetrieveObject((CWoWObject **)&pCreature,OBJ_CREATURE,pClient->pPlayer->LootID))
	{
		if(!pCreature->bLooted) return;
		pTemplate=pCreature->LootedItems[slot];
	}
	else if(DataManager.RetrieveObject((CWoWObject **)&pObject,OBJ_GAMEOBJECT,pClient->pPlayer->LootID))
	{
		if(!pObject->bLooted) return;
		pTemplate=pObject->LootedItems[slot];
	}
	else return;

	if(!pTemplate) return;
	if (pClient->pPlayer->AddSetItem(pTemplate, 1)) return;
/*
	unsigned int left = 1;
	if (pTemplate->Data.Stackable > 1)//try stock
	{
		left = pClient->pPlayer->AddItem(pTemplate->Data, left);
	}
	if (left)
	{
		CItem *pItem = new CItem;
		pItem->New(pTemplate, pClient->pPlayer->guid);
		DataManager.NewObject(*pItem);
		pItem->CreateBag();
		int newSlot=pClient->pPlayer->GetOpenBackpackSlot();
		if(newSlot == -1)
		{
			SendInventoryFailure(pClient, BAG_FULL, pItem->guid, 0, 0, 0);
			return;
		}
		pClient->AddKnownItem(*pItem);
	//	pClient->pDataObject->SetItem(newSlot, pItem->guid);
		pClient->pDataObject->SetItem(newSlot, pItem);
	}*/
	if(pCreature) pCreature->LootedItems.erase(slot);
	else if(pObject) pObject->LootedItems.erase(slot);
	else return;

	pClient->UpdateObject();
	char *qualitycolors[]={"808080","FFFFFF","00C400","0000FF","800080","FFA500","FF0000"};
	pClient->ChannelMsgF(CHAT_LOOT,"You receive loot: |cff%s|Hitem:%u:0:0:0|h[%s]|h|r",(pTemplate->Data.OverallQualityID<=6)?qualitycolors[pTemplate->Data.OverallQualityID]:"000000",pTemplate->guid,pTemplate->Data.Name);
	pClient->OutPacket(SMSG_LOOT_REMOVED,&slot,0x01);
	if (pCreature->LootedItems.size() == 0)
	{
		pCreature->DataObject.SetFlags(0x00000);
		pCreature->DataObject.SetDynamicFlags(0);
		pCreature->UpdateObject();
	}
}

void MsgLootResponse(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	/*
	DIRECTION UNKNOWN Data len=0019 op=0159 int=0000 msglen=0015 -- OnPlayerEvent
	0000:  F5 45 01 00-00 00 00 00-00 00 00 00-01 00 00 00  )E..............
	0010:  FF 3C 0B 00-00         -           -              <...

	DIRECTION UNKNOWN Data len=000D op=0154 int=0000 msglen=0009 -- OnLootEvent
	0000:  B8 6A 00 00-00 10 00 F0-01         -             +j.....=.
	*/
	//unsigned char buffer1[0x15];
	unsigned char buffer2[0x09];
	unsigned char buffer3[0x01];

	// this one gives loot message
	/*
	memset(buffer1,0,0x15);
	*(unsigned long*)&buffer1[0x00]=pClient->pPlayer->guid;
	*(unsigned long*)&buffer1[0x0C]=0x01;
	*(unsigned char*)&buffer1[0x10]=0xFF;
	*(unsigned short*)&buffer1[0x11]=0x0A;  // which item
	pClient->OutPacket(SMSG_ITEM_PUSH_RESULT,buffer1,0x15);
	*/


	// These two terminate looting
	unsigned long guid, guidhigh;
	Data >> guid >> guidhigh;

	CGameObject *pObject=NULL;
	if(DataManager.RetrieveObject((CWoWObject **)&pObject,OBJ_GAMEOBJECT,guid))
	{
		EventManager.AddEvent(*pObject,60000,EVENT_GAMEOBJECT_RESPAWN,0,0);
		CPacket pkg(SMSG_DESTROY_OBJECT);
		pkg << guid;
		pkg << GAMEOBJECTGUID_HIGH;
		pObject->SendRegion(&pkg);

		RegionManager.ObjectRemove(*pObject);
	}
	memset(buffer2,0,0x09);
	*(unsigned long*)&buffer2[0x00]=guid;
	*(unsigned long*)&buffer2[0x04]=guidhigh;
	*(unsigned char*)&buffer2[0x08]=0x01;
	pClient->OutPacket(SMSG_LOOT_RELEASE_RESPONSE,buffer2,0x09);

	memset(buffer3,0,0x01);
	pClient->OutPacket(SMSG_LOOT_REMOVED,buffer3,0x01);
}

/* ---ITEM HANDLERS--- */
void MsgListInventory(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CCreature* pCreature = NULL;
	unsigned long CreatureGuid;
	Data >> CreatureGuid;
	DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE,CreatureGuid);
	if(pCreature != NULL)
		pCreature->ListInventory(pClient); // let it call the empty virtual function
	// incase it's not a merchant
}
void MsgRepairItem(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CItem *pItem;
	unsigned long npcguid;
	unsigned long highpart;
	unsigned long itemguid;
	unsigned long itemhighpart;

	Data >> npcguid >> highpart >> itemguid >> itemhighpart;

	if (itemguid)
	{
		// Repair single item
		if(DataManager.RetrieveObject((CWoWObject**)&pItem, itemguid))
		{
			pItem->Data.Durability = pItem->pTemplateData->MaxDurability;
			pItem->AddUpdateVal(ITEM_FIELD_DURABILITY, pItem->Data.Durability);
			pClient->UpdateKnownItem(*pItem);
		}
	} else {
		// Repair all
		for(int i=0;i<120;i++)
		{
//			if (pClient->pPlayer->Data.Items[i])
			if (pItem = pClient->pPlayer->Data.Items[i])
//				if(DataManager.RetrieveObject((CWoWObject**)&pItem, pClient->pPlayer->Data.Items[i])) //add res of dest item
				{
					pItem->Data.Durability = pItem->pTemplateData->MaxDurability;
					pItem->AddUpdateVal(ITEM_FIELD_DURABILITY, pItem->Data.Durability);
					pClient->UpdateKnownItem(*pItem);
				}
		}
	}
}
void MsgSellItem(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	// Error Codes: 0x01 = Item not Found
	//              0x02 = Vendor doesnt want that item
	//              0x03 = Vendor doesnt like you ;P
	//              0x04 = You dont own that item
	//              0x05 = Ok
	//              0x06 = Only with empty Bags !?
	CItem* pItem = NULL;
	unsigned long CreatureGuid;
	unsigned long ItemGuid;
	unsigned long templong;
	Data >> CreatureGuid;
	Data >> templong;
	Data >> ItemGuid;
	Data >> templong;
	DataManager.RetrieveObject((CWoWObject**)&pItem,OBJ_ITEM,ItemGuid);
	if(pItem == NULL) {
		//pClient->Echo("Couldn't find item");
		CPacket pkg;
		pkg.Reset(SMSG_SELL_ITEM);
		pkg << CreatureGuid << CREATUREGUID_HIGH;
		pkg << ItemGuid << ITEMGUID_HIGH;
		pkg << (char)0x01;
		pClient->Send(&pkg);
		return;
	}
	if(!pItem->pTemplateData)
	{
		//pClient->Echo("Couldn't find item template");
		CPacket pkg;
		pkg.Reset(SMSG_SELL_ITEM);
		pkg << CreatureGuid << CREATUREGUID_HIGH;
		pkg << ItemGuid << ITEMGUID_HIGH;
		pkg << (char)0x01;
		pClient->Send(&pkg);
		return;
	}
	int slot = -1;
	for (unsigned long i = 0 ; i < 39 ; i++)
	{
		if (pClient->pPlayer->Data.Items[i] && pClient->pPlayer->Data.Items[i]->guid==ItemGuid)
		{
			slot = i;
		}
	}
	if (slot == -1) {
		pClient->Echo("Couldn't find item on player");
		CPacket pkg;
		pkg.Reset(SMSG_SELL_ITEM);
		pkg << CreatureGuid << CREATUREGUID_HIGH;
		pkg << ItemGuid << ITEMGUID_HIGH;
		pkg << (char)0x04;
		pClient->Send(&pkg);
		return;
	}
	//pClient->pPlayer->Data.Items[slot] = 0x00;
	pClient->pDataObject->SetItem(slot, 0);
	const unsigned long SellPrice = pItem->pTemplateData->SellPrice * pItem->pTemplateData->Stackable;
	pClient->pPlayer->Data.Copper += SellPrice;
	pClient->pPlayer->DataObject.SetCoinage(pClient->pPlayer->Data.Copper);
	BuybackItem bi;
	bi.guid=ItemGuid;
	bi.SellPrice=(SellPrice)?SellPrice:1; //minimum price is one copper.
	while(pClient->pPlayer->BuybackItems.size()>=12) pClient->pPlayer->BuybackItems.pop_front();
	pClient->pPlayer->BuybackItems.push_back(bi);
	int k=0;
	for(std::deque<BuybackItem>::iterator i=pClient->pPlayer->BuybackItems.begin();i!=pClient->pPlayer->BuybackItems.end();i++)
	{
		pClient->pPlayer->AddUpdateVal(PLAYER_FIELD_VENDORBUYBACK_SLOT_1+2*k,(*i).guid,ITEMGUID_HIGH);
		pClient->pPlayer->AddUpdateVal(PLAYER_FIELD_BUYBACK_PRICE_1+k,(*i).SellPrice);
		pClient->pPlayer->AddUpdateVal(PLAYER_FIELD_BUYBACK_TIMESTAMP_1+k,k);
		k++;
		if(k==12) break;
	}
	for(;k<12;k++)
	{
		pClient->pPlayer->AddUpdateVal(PLAYER_FIELD_VENDORBUYBACK_SLOT_1+2*k,0,0);
		pClient->pPlayer->AddUpdateVal(PLAYER_FIELD_BUYBACK_PRICE_1+k,0);
		pClient->pPlayer->AddUpdateVal(PLAYER_FIELD_BUYBACK_TIMESTAMP_1+k,0);
	}
	pClient->pPlayer->UpdateObject();

	CPacket pkg;
	pkg.Reset(SMSG_SELL_ITEM);
	pkg << CreatureGuid << CREATUREGUID_HIGH;
	pkg << ItemGuid << ITEMGUID_HIGH;
	pkg << (char)0x05;

	pClient->Send(&pkg);
}

void MsgBuyItem(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CCreature* pCreature = NULL;
	unsigned long CreatureGuid, highguid, nItem;
	unsigned char Stacks,unknown;
	Data >> CreatureGuid >> highguid >> nItem >> Stacks >> unknown;
	if(highguid!=CREATUREGUID_HIGH)  return;
	DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE,CreatureGuid);
	if(pCreature != NULL)
		pCreature->BuyItem(pClient, nItem, Stacks); // let it call the empty virtual function
	// incase it's not a merchant
}

void MsgBuyBackItem(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CCreature* pCreature = NULL;
	unsigned long CreatureGuid, highguid, nItem, nItemSlot;
	Data >> CreatureGuid >> highguid >> nItem >> nItemSlot;
	if(highguid!=CREATUREGUID_HIGH) return;
	if(DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE,CreatureGuid))
	{
		nItem-=0x45; //this is totally weird, but it works.
		if(nItem>=pClient->pPlayer->BuybackItems.size())
		{
			pClient->OutPacket(SMSG_BUY_FAILED,0,0);
			return;
		}
		BuybackItem bi=pClient->pPlayer->BuybackItems.at(nItem);
		if (bi.SellPrice > pClient->pPlayer->Data.Copper)
		{
			SendInventoryFailure(pClient, BAG_NOT_ENOUGH_GOLD, 0, 0, 0, 0);
			//pClient->Echo("You don't have enough money to buy back that item");
			return;
		}
		int newSlot=pClient->pPlayer->GetOpenBackpackSlot();
		if(newSlot == -1)
		{
			SendInventoryFailure(pClient, BAG_FULL, 0, 0, 0, 0);
			//pClient->Echo("Your backpack is full.");
			return;
		}
		pClient->pPlayer->Data.Copper -= bi.SellPrice;
		pClient->pPlayer->DataObject.SetCoinage(pClient->pPlayer->Data.Copper);
//		pClient->pPlayer->DataObject.SetItem(newSlot, bi.guid);// todo buyback can use CItem* ?
		CItem *pItem;
		DataManager.RetrieveObject((CWoWObject**)&pItem, bi.guid);
		pClient->pPlayer->DataObject.SetItem(newSlot, pItem);
		pClient->pPlayer->BuybackItems.erase(pClient->pPlayer->BuybackItems.begin()+nItem);
		int k=0;
		for(std::deque<BuybackItem>::iterator i=pClient->pPlayer->BuybackItems.begin();i!=pClient->pPlayer->BuybackItems.end();i++)
		{
			pClient->pPlayer->AddUpdateVal(PLAYER_FIELD_VENDORBUYBACK_SLOT_1+2*k,(*i).guid,ITEMGUID_HIGH);
			pClient->pPlayer->AddUpdateVal(PLAYER_FIELD_BUYBACK_PRICE_1+k,(*i).SellPrice);
			pClient->pPlayer->AddUpdateVal(PLAYER_FIELD_BUYBACK_TIMESTAMP_1+k,k);
			k++;
			if(k==12) break;
		}
		for(;k<12;k++)
		{
			pClient->pPlayer->AddUpdateVal(PLAYER_FIELD_VENDORBUYBACK_SLOT_1+2*k,0,0);
			pClient->pPlayer->AddUpdateVal(PLAYER_FIELD_BUYBACK_PRICE_1+k,0);
			pClient->pPlayer->AddUpdateVal(PLAYER_FIELD_BUYBACK_TIMESTAMP_1+k,0);
		}
		pClient->pPlayer->UpdateObject();
	}
}

void SendInventoryFailure(CClient *pClient, int result, unsigned long itemguid1, unsigned long itemguid2, int bagslot, int levelError)
{
	char buffer[0x16];

	buffer[0] = (char)result;
	unsigned short c = 1;
	if(result == BAG_LEVEL_MISMATCH)
	{
		*(unsigned long*)&buffer[c] = levelError;
		c += 4;
	}
	*(unsigned long*)&buffer[c] = itemguid1;
	c += 4;
	*(unsigned long*)&buffer[c] = itemguid1 ? ITEMGUID_HIGH : 0;
	c += 4;

	*(unsigned long*)&buffer[c] = itemguid2;
	c += 4;
	*(unsigned long*)&buffer[c] = itemguid2 ? ITEMGUID_HIGH : 0;
	c += 4;
	buffer[c] = (char)bagslot;
	c++;
	pClient->OutPacket(SMSG_INVENTORY_CHANGE_FAILURE, buffer, c);
}

void MsgDestroyItem(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned char bag, bagslot;
	Data >> bag >> bagslot;
	if(bag == 0xFF)
	{
		pClient->pPlayer->DestroyItem(bagslot);
		pClient->pPlayer->AddUpdateVal(PLAYER_FIELD_INV_SLOT_HEAD+bagslot*2, 0, 0);
		if (bagslot < 19)
		{
			pClient->pPlayer->AddUpdateVal(PLAYER_VISIBLE_ITEM_1_0+bagslot*12, 0);
		}

		pClient->UpdateObject();
	}
	else // BAGSTODO
	{
		pClient->Echo("Destroying in bags not support yet. bag = %d slot = %d", bag, bagslot);
	}
}

void MsgSwapItem(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned char bag1, bag1slot, bag2, bag2slot;
	Data >> bag1 >> bag1slot >> bag2 >> bag2slot;
	const bool Bag1IsBackpack = (bag1 == 0xFF), Bag2IsBackpack = (bag2 == 0xFF);
	CItem *pItem1, *pItem2;
	if (Bag1IsBackpack) {
		pItem1 = pClient->pPlayer->Data.Items[bag1slot];
	} else {
		bag1slot = CPlayer::CPlayerDataObject::GetBagItemSlot(bag1, bag1slot);
		pItem1 = pClient->pPlayer->Data.BagItems[bag1slot];
	}
	if (Bag2IsBackpack) {
		pItem2 = pClient->pPlayer->Data.Items[bag2slot];
	} else {
		bag2slot = CPlayer::CPlayerDataObject::GetBagItemSlot(bag2, bag2slot);
		pItem2 = pClient->pPlayer->Data.BagItems[bag2slot];
	}

	CItem *temp = pClient->pPlayer->Data.Items[bag1slot];
	if(Bag1IsBackpack) {
		pClient->pDataObject->SetItem(bag1slot, pItem2);
	} else {
		pClient->pDataObject->SetBagItem(bag1slot, pItem2);
	}
	if(Bag2IsBackpack) {
		pClient->pDataObject->SetItem(bag2slot, pItem1);
	} else {
		pClient->pDataObject->SetBagItem(bag2slot, pItem1);
	}
	pClient->UpdateObject();
/*
	if(bag1 == 0xFF)
	{
		CItem *temp = pClient->pPlayer->Data.Items[bag1slot];
		if(bag2 == 0xFF)
		{
			pClient->pDataObject->SetItem(bag1slot, pClient->pPlayer->Data.Items[bag2slot]);
			pClient->pDataObject->SetItem(bag2slot, temp);
			pClient->UpdateObject();
		}
		else // BAGSTODO
		{
			// no bags yet
			return;
		}
	}
	else // BAGSTODO
	{
		// no bags yet
		return;
	}*/
}

int ReqSkillWeapon[] = {
	44, //Axes (1H)
		172, //Axes (2H)
		45, //Bows
		46, //Guns
		54, //Maces (1H)
		160, //Maces (2H)
		229, //Polearms
		43, //Swords (1H)
		55, //Swords (2H)
		136, //Staves
		0, //Exotic (1H)
		0, //Exotic (2H)
		473, //Fist Weapons
		0, //Misc Weapons
		173, //Daggers
		176, //Thrown
		227, //Spears
		226, //Crossbows
		228, //Wands
		356 //Fishing
};

int ReqSkillArmor[] = {
	0, //Misc
		415, //Cloth
		414, //Leather
		413, //Mail
		293, //Plate Mail
		0, //Buckler (OBSOLETE)
		433, //Shield
};

unsigned char ReqInventoryType4ItemSlot[] = {//0 for unknown
/*SLOT_HEAD			0*/ 0,
/*SLOT_NECK			1*/ 2,
/*SLOT_SHOULDERS		2*/ 0,
/*SLOT_SHIRT			3*/ 4,
/*SLOT_CHEST			4*/ 5,
/*SLOT_WAIST			5*/ 6,
/*SLOT_LEGS			6*/ 7,
/*SLOT_FEET			7*/ 8,
/*SLOT_WRISTS			8*/ 9,
/*SLOT_HANDS			9*/ 10,
/*SLOT_FINGERL		10*/ 11,
/*SLOT_FINGERR		11*/ 11,
/*SLOT_TRINKETL		12*/ 0,
/*SLOT_TRINKETR		13*/ 0,
/*SLOT_BACK			14*/ 16,
/*SLOT_MAINHAND		15*/ 21,//more values
/*SLOT_OFFHAND		16*/ 14,//more values
/*SLOT_RANGED			17*/ 15,
/*SLOT_TABARD			18*/ 0
};

void MsgSwapInvItem(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned char slot1, slot2, inventoryslot = UCHAR_MAX, noninventoryslot = UCHAR_MAX;
	Data >> slot1 >> slot2;
//	unsigned long temp;
//	temp = pClient->pPlayer->Data.Items[slot1];
	CItem *temp = pClient->pPlayer->Data.Items[slot1];
	CItem *inventoryitem = NULL, *noninventoryitem = NULL;
	const unsigned long guid1 = pClient->pPlayer->Data.Items[slot1] ? pClient->pPlayer->Data.Items[slot1]->guid : 0;
	const unsigned long guid2 = pClient->pPlayer->Data.Items[slot2] ? pClient->pPlayer->Data.Items[slot2]->guid : 0;

	if(slot1 <= SLOT_TABARD) {
		inventoryslot = slot1;
		noninventoryslot = slot2;
		inventoryitem = pClient->pPlayer->Data.Items[slot1];
		noninventoryitem = pClient->pPlayer->Data.Items[slot2];
	} else {
		if(slot2 <= SLOT_TABARD) {
			inventoryslot = slot2;
			noninventoryslot = slot1;
			inventoryitem = pClient->pPlayer->Data.Items[slot2];
			noninventoryitem = pClient->pPlayer->Data.Items[slot1];
		}
	}
/*
	char buf[50];
	if (inventoryitem) {
		sprintf(buf, "inv InventoryType = %i",inventoryitem->pTemplateData->InventoryType);
		pClient->Echo(buf);
	}
	if (noninventoryitem) {
		sprintf(buf, "inv InventoryType = %i",noninventoryitem->pTemplateData->InventoryType);
		pClient->Echo(buf);
	}*/
	//pClient->UpdateObject(); // cant we do this in a single pkt??, moved to end of function
/*
	if (slot1 == SLOT_MAINHAND) {
		pClient->pDataObject->SetMinDamage(0);
		pClient->pDataObject->SetMaxDamage(4);
		pClient->pDataObject->SetAttackSpeed(2000);
		pClient->pPlayer->Data.MeleeWeaponSkillID=162; //Unarmed
	}
	else if (slot1 == SLOT_RANGED) {
		pClient->pDataObject->SetRangedMinDamage(0);
		pClient->pDataObject->SetRangedMaxDamage(0);
		pClient->pDataObject->SetRangedAttackSpeed(2000);
		pClient->pPlayer->Data.RangedWeaponSkillID=0;
	}*/
//	if(slot2 <= SLOT_TABARD)
	if(inventoryslot <= SLOT_TABARD)
	{
//		CItem *pItem = NULL;
//		if(!temp || !DataManager.RetrieveObject((CWoWObject**)&pItem, temp))
//		CItem *pItem = temp;
/*		if(!pItem)
			return; // should be some error reporting
		if(!(pItem->pTemplateData))
			return;
		if(pItem->pTemplateData->RequiredLevel > pClient->pPlayer->Data.Level)
		{
			SendInventoryFailure(pClient,BAG_LEVEL_MISMATCH,guid1,guid2,0,pItem->pTemplateData->RequiredLevel);
			return;
		}
*/
		if(noninventoryitem && noninventoryitem->pTemplateData)
		{
//		}
		/* Apparently none of our items have this field :(
		if(!(pTemplate->Data.AllowableClass & (1<<pClient->pPlayer->Data.Class)))
		{
		SendInventoryFailure(pClient,BAG_CLASS_NOTALLOWED,pClient->pPlayer->Data.Items[slot1],pClient->pPlayer->Data.Items[slot2],0,0);
		return;
		}
		if(!(pTemplate->Data.AllowableRace & (1<<pClient->pPlayer->Data.Race)))
		{
		SendInventoryFailure(pClient,BAG_RACE_NOTALLOWED,pClient->pPlayer->Data.Items[slot1],pClient->pPlayer->Data.Items[slot2],0,0);
		return;
		}
		*/
			if(pClient->pPlayer->Data.StatusFlags & STATUS_DEAD)
			{
				SendInventoryFailure(pClient,BAG_NOT_WHILE_DEAD,guid1,guid2,0,0);
				return;
			}

			if (inventoryslot != SLOT_MAINHAND && inventoryslot != SLOT_OFFHAND) {
				if(noninventoryitem->pTemplateData->InventoryType != ReqInventoryType4ItemSlot[inventoryslot])
				{
					SendInventoryFailure(pClient,BAG_SLOT_MISMATCH,guid1,guid2,0,0);
					return;
				}
			}
			
			if(noninventoryitem->pTemplateData->RequiredLevel > pClient->pPlayer->Data.Level)
			{
				SendInventoryFailure(pClient,BAG_LEVEL_MISMATCH,guid1,guid2,0,noninventoryitem->pTemplateData->RequiredLevel);
				return;
			}

			if (inventoryslot == SLOT_MAINHAND) {
				pClient->pDataObject->SetMinDamage(noninventoryitem->pTemplateData->DamageStats[0].Min);
				pClient->pDataObject->SetMaxDamage(noninventoryitem->pTemplateData->DamageStats[0].Max);
				pClient->pDataObject->SetAttackSpeed(noninventoryitem->pTemplateData->WeaponSpeed);
				if(noninventoryitem->pTemplateData->RequiredSkill) pClient->pPlayer->Data.MeleeWeaponSkillID=noninventoryitem->pTemplateData->RequiredSkill;
			}
			else if (inventoryslot == SLOT_RANGED) {
				pClient->pDataObject->SetRangedMinDamage(noninventoryitem->pTemplateData->DamageStats[0].Min);
				pClient->pDataObject->SetRangedMaxDamage(noninventoryitem->pTemplateData->DamageStats[0].Max);
				pClient->pDataObject->SetRangedAttackSpeed(noninventoryitem->pTemplateData->WeaponSpeed);
				if(noninventoryitem->pTemplateData->RequiredSkill) pClient->pPlayer->Data.RangedWeaponSkillID=noninventoryitem->pTemplateData->RequiredSkill;
			}
	//		if(pItem->pTemplateData->Class==2) //Weapon
			if(noninventoryitem->pTemplateData->Class==2) //Weapon
			{
	//			if(pItem->pTemplateData->SubClass <= 20)
				if(noninventoryitem->pTemplateData->SubClass <= 20)
				{
					int SkillID=ReqSkillWeapon[noninventoryitem->pTemplateData->SubClass];
					if(SkillID)
					{
						if(!pClient->pPlayer->GetSkill(SkillID))
						{
							SendInventoryFailure(pClient,BAG_SKILL_MISMATCH,guid1,guid2,0,0);
							return;
						}
						else if(noninventoryitem->pTemplateData->SubClass == 2 || noninventoryitem->pTemplateData->SubClass == 3)
							pClient->pPlayer->Data.RangedWeaponSkillID=ReqSkillWeapon[noninventoryitem->pTemplateData->SubClass];
						else pClient->pPlayer->Data.MeleeWeaponSkillID=ReqSkillWeapon[noninventoryitem->pTemplateData->SubClass];
					}
				}
			}
	//		else if(pItem->pTemplateData->Class==4) //Armor
			else if(noninventoryitem->pTemplateData->Class==4) //Armor
			{
				if(noninventoryitem->pTemplateData->SubClass <= 6)
				{
					int SkillID=ReqSkillArmor[noninventoryitem->pTemplateData->SubClass];
					if(SkillID)
					{
						if(!pClient->pPlayer->GetSkill(SkillID))
						{
							SendInventoryFailure(pClient,BAG_SKILL_MISMATCH,guid1,guid2,0,0);
							return;
						}
					}
				}
			}
			if(noninventoryitem->pTemplateData->RequiredSkill)
			{
				_SkillInfo *pSkill;
				if(!(pSkill=pClient->pPlayer->GetSkill(noninventoryitem->pTemplateData->RequiredSkill)) || pSkill->CurrentLevel<noninventoryitem->pTemplateData->RequiredSkillRank)
				{
					SendInventoryFailure(pClient,BAG_PROFICIENCY_NEEDED,guid1,guid2,0,0);
					return;
				}
			}
		} else {
			if (inventoryslot == SLOT_MAINHAND) {
				pClient->pDataObject->SetMinDamage(0);
				pClient->pDataObject->SetMaxDamage(4);
				pClient->pDataObject->SetAttackSpeed(2000);
				pClient->pPlayer->Data.MeleeWeaponSkillID=162; //Unarmed
			}
			else if (inventoryslot == SLOT_RANGED) {
				pClient->pDataObject->SetRangedMinDamage(0);
				pClient->pDataObject->SetRangedMaxDamage(0);
				pClient->pDataObject->SetRangedAttackSpeed(2000);
				pClient->pPlayer->Data.RangedWeaponSkillID=0;
			}
		}
	}
/*
	if(slot1 <= SLOT_TABARD)
	{
//		CItem *pItem = NULL;
//		if(!temp || !DataManager.RetrieveObject((CWoWObject**)&pItem, temp))
		CItem *pItem = temp;
		if(!pItem)
			return; // should be some error reporting
		if(!pItem->pTemplateData) return;
	}*/
	pClient->pDataObject->SetItem(slot1, pClient->pPlayer->Data.Items[slot2]);
	pClient->pDataObject->SetItem(slot2, temp);
	pClient->pPlayer->RecomputeAllStats(); //hell, this should actually be easier
	pClient->UpdateObject();
}

int InvTypeToInvSlot[WORN_NUM_TYPES] = {
	SLOT_INBACKPACK, // NONE EQUIP
		SLOT_HEAD,
		SLOT_NECK,
		SLOT_SHOULDERS,
		SLOT_SHIRT,
		SLOT_CHEST,
		SLOT_WAIST,
		SLOT_LEGS,
		SLOT_FEET,
		SLOT_WRISTS,
		SLOT_HANDS,
		SLOT_FINGERL,
		SLOT_TRINKETL,
		SLOT_MAINHAND, // 1h
		SLOT_OFFHAND, // shield
		SLOT_RANGED,
		SLOT_BACK,
		SLOT_MAINHAND, // 2h
		SLOT_BAG1,
		SLOT_TABARD,
		SLOT_CHEST, // ROBE
		SLOT_MAINHAND, // mainhand
		SLOT_OFFHAND, // offhand
		SLOT_MAINHAND, // held
		SLOT_INBACKPACK, // ammo
		SLOT_RANGED, // thrown
		SLOT_RANGED // rangedright
};

void MsgAutoEquipItem(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned char bag, bagslot;
	Data >> bag >> bagslot;
	if(bag != 0xFF) // BAGSTODO
	{
		pClient->Echo("Moving from and to bags not supported yet.");
		return;
	}

//	unsigned long temp;
//	temp = pClient->pPlayer->Data.Items[bagslot];
//	CItem *pItem = NULL;
	CItem *pItem = pClient->pPlayer->Data.Items[bagslot];
//	if(!temp || !DataManager.RetrieveObject((CWoWObject**)&pItem, temp))
	if(!pItem)
		return; // should be some error reporting
	if(!pItem->pTemplateData) return;
	unsigned long newSlot = InvTypeToInvSlot[pItem->pTemplateData->InventoryType];
	if(newSlot == SLOT_INBACKPACK || newSlot == SLOT_BAG1)
	{
		SendInventoryFailure(pClient, BAG_NOT_EQUIPPABLE, pItem->guid, 0, 0, 0);
		return;
	}
	if(pClient->pPlayer->Data.Items[newSlot] != 0)
	{
		if(newSlot == SLOT_MAINHAND)
		{
			if((pItem->pTemplateData->InventoryType == WORN_1H || pItem->pTemplateData->InventoryType == WORN_HELD)
				&& pClient->pPlayer->Data.Items[SLOT_OFFHAND] == 0)
			{
				newSlot = SLOT_OFFHAND;
			}
		}
		else if(newSlot == SLOT_FINGERL)
		{
			if(pClient->pPlayer->Data.Items[SLOT_FINGERR] == 0)
				newSlot = SLOT_FINGERR;
		}
		else if(newSlot == SLOT_TRINKETL)
		{
			if(pClient->pPlayer->Data.Items[SLOT_TRINKETR] == 0)
				newSlot = SLOT_TRINKETR;
		}
	}
	//we can use MsgSwapInvItem for simplicity!
	CDataBuffer mybuffer(2);
	mybuffer << bagslot << (unsigned char)newSlot;
	mybuffer.Position(0); //reset position
	MsgSwapInvItem(pClient,msgID,mybuffer);
}

void MsgAutoStoreBagItem(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned char bag1, bag1slot, bag2;
	Data >> bag1 >> bag1slot >> bag2;
	if(bag1 != 0xFF || bag2 != 0xFF) // BAGSTODO
		return;
	int newSlot = pClient->pPlayer->GetOpenBackpackSlot();
	if(newSlot == -1)
	{
		SendInventoryFailure(pClient, BAG_FULL, pClient->pPlayer->Data.Items[bag1slot]->guid, 0, 0, 0);
		return;
	}
	pClient->pDataObject->SetItem(newSlot, pClient->pPlayer->Data.Items[bag1slot]);
	pClient->pDataObject->SetItem(bag1slot, 0);
	pClient->UpdateObject();
}

/* ---QUEST HANDLERS--- */
void MsgQuestGiverQueryStatus(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	/*
	structure of CMSG_QUESTGIVER_STATUS_QUERY:
	uint64 VendorGUID

	structure of SMSG_QUESTGIVER_STATUS:
	uint64 VendorGUID
	ulong questid
	*/
	unsigned long guid;
	unsigned long guidhigh;
	Data >> guid;
	Data >> guidhigh;

	CWoWObject *pObject = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pObject,guid))
		return;

	switch(pObject->type)
	{
	case OBJ_CREATURE:
		{
			((CCreature *)pObject)->ShowQuestStatus(pClient);
		}
		break;
	case OBJ_CORPSE:
		{
			CPacket pkg;
			pkg << guid;
			pkg << guidhigh;
			pkg << (unsigned long)3;
			pClient->Send(&pkg);
		}
		break;
	}

	/*CCreature* pCreature = NULL;
	unsigned long CreatureGuid;
	Data >> CreatureGuid;
	DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE,CreatureGuid);
	if(pCreature != NULL) {
	pCreature->ShowQuestStatus(pClient);
	}*/
}

void MsgQuestGiverHello(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	/*
	structure of CMSG_QUESTGIVER_STATUS_QUERY:
	uint64 VendorGUID
	*/
	CCreature* pCreature = NULL;
	unsigned long CreatureGuid;
	Data >> CreatureGuid;
	DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE,CreatureGuid);
	if(pCreature != NULL) {
		pCreature->ShowQuestHello(pClient);
	}
}
void MsgQuestGiverCompleteQuest(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{

	unsigned long guid;
	unsigned long junk;
	unsigned long questid;
	Data >> guid >> junk >> questid;

	CPacket pkg;
	CQuestInfo *pQuest;

	if (!DataManager.RetrieveObject((CWoWObject**)&pQuest, OBJ_QUESTINFO, questid))
	{
		pClient->Echo("Couldn't find quest info? :S");
		return;
	}

	pkg.Reset(SMSG_QUESTGIVER_OFFER_REWARD);
	pkg << guid << CREATUREGUID_HIGH;
	pkg << (unsigned long)questid;
	pkg << pQuest->Data.title;
	pkg << pQuest->Data.details;
	pkg << (unsigned long)0x01;
	pkg << (unsigned long)0x00;

	pkg << (unsigned long)pQuest->Data.choicerewards;
	for (unsigned long i=0; i < pQuest->Data.choicerewards; i++)
	{
		// todo: checking code - if (DataManager.RetrieveObject((CWoWObject**),OBJ_ITEM,
		pkg << (unsigned long)DataManager.ItemTemplates[pQuest->Data.choiceitemid[i]];
		pkg << (unsigned long)pQuest->Data.choiceitemcount[i];
		pkg << (unsigned long)0;
	}

	pkg << (unsigned long)pQuest->Data.itemrewards;
	for (unsigned long i=0; i < pQuest->Data.itemrewards; i++)
	{
		// todo: checking code - if (DataManager.RetrieveObject((CWoWObject**),OBJ_ITEM,
		pkg << (unsigned long)DataManager.ItemTemplates[pQuest->Data.rewarditemid[i]];
		pkg << (unsigned long)pQuest->Data.rewarditemcount[i];
		pkg << (unsigned long)0;
	}

	pkg << (unsigned long)pQuest->Data.rewardgold;
	pkg << (unsigned long)0;
	pkg << (unsigned long)pQuest->Data.learnspell;

	pClient->Send(&pkg);
}

void MsgQuestGiverChooseReward(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long guid;
	unsigned long junk;
	unsigned long questid;
	Data >> guid >> junk >> questid;

	CPacket pkg;
	CQuestInfo *pQuest;

	if (!DataManager.RetrieveObject((CWoWObject**)&pQuest, OBJ_QUESTINFO, questid))
	{
		pClient->Echo("Couldn't find quest info? :S");
		return;
	}

	// Here we remove any items used by the quest, add xp, gold, and add items.
	unsigned long GoldAmount;
	unsigned long XPAmount;			// these need to be calculated via formulas

	GoldAmount = 10;
	XPAmount = 10;

	pClient->pPlayer->Data.Copper += GoldAmount;
	pClient->pPlayer->DataObject.SetCoinage(pClient->pPlayer->Data.Copper);
	pClient->pPlayer->DataObject.AddXP(XPAmount);

	// Add any items, remove any items, etc

	// Construct packet

	pkg.Reset(SMSG_QUESTGIVER_QUEST_COMPLETE);
	pkg << (unsigned long)questid;
	pkg << (unsigned long)0x03;
	pkg << (unsigned long)XPAmount;			// Quest EXP
	pkg << (unsigned long)GoldAmount;			// Quest GOLD
	pkg << (unsigned long)0;			// Number of REWARD items. If more than 0 for each one send an ID.

	// Remove from quest log
	pClient->pPlayer->AddUpdateVal(216, 0);
	pClient->pPlayer->AddUpdateVal(217, 0);
	pClient->pPlayer->AddUpdateVal(218, 0);
	SetQuestStatus(pClient, questid, QUEST_STATUS_COMPLETED);
	pClient->UpdateObject();

	pClient->Send(&pkg);
}

void MsgQuestGiverQueryQuest(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long cguid;
	unsigned long junk;
	unsigned long questid;

	Data >> cguid >> junk >> questid;

	// questid = DataManager.QuestIDs[questid2];

	SendSmallQuestDetails(pClient,cguid,questid);
}

void MsgQuestQuery(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CQuestInfo *pQuest;
	unsigned long questid;

	Data >> questid;

	// questid = DataManager.QuestIDs[questid2];

	if (!DataManager.RetrieveObject((CWoWObject**)&pQuest,OBJ_QUESTINFO, questid))
	{
		questid = 455;				// insert bogus quest here
		pClient->Echo("couldn't find quest");
		DataManager.RetrieveObject((CWoWObject**)&pQuest,OBJ_QUESTINFO, questid);
		return;
	}

	CPacket pkg;
	pkg.Reset(SMSG_QUEST_QUERY_RESPONSE);

	// pkg << pQuest->Data.questid;
	pkg << (unsigned long)questid;
	pkg << (unsigned long)pQuest->Data.reqlevel;
	pkg << (unsigned long)pQuest->Data.questlevel;
	pkg << (unsigned long)pQuest->Data.zoneid;

	pkg << (unsigned long)pQuest->Data.questtype;
	pkg << (unsigned long)pQuest->Data.repfaction[0];
	pkg << (unsigned long)pQuest->Data.repvalue[0];
	pkg << (unsigned long)pQuest->Data.repfaction[1];
	pkg << (unsigned long)pQuest->Data.repvalue[1];

	pkg << (unsigned long)0;						// nextquest
	pkg << (unsigned long)pQuest->Data.rewardgold;
	pkg << (unsigned long)pQuest->Data.learnspell;

	pkg << (unsigned long)(DataManager.ItemTemplates[pQuest->Data.srcitem]);
	pkg << (unsigned long)pQuest->Data.questflags;

	unsigned long iTotals = 8;
	unsigned long i;

	for (i = 0; i < pQuest->Data.itemrewards; i++)
	{
		pkg << (unsigned long)(DataManager.ItemTemplates[pQuest->Data.rewarditemid[i]]);
		pkg << (unsigned long)pQuest->Data.rewarditemcount[i];
		iTotals -= 2;
	}

	for (i = 0; i < iTotals; i++) pkg << (unsigned long)0x00;

	iTotals = 12;

	for (i = 0; i < pQuest->Data.choicerewards; i++)
	{
		pkg << (unsigned long)(DataManager.ItemTemplates[pQuest->Data.choiceitemid[i]]);
		pkg << (unsigned long)pQuest->Data.choiceitemcount[i];
		iTotals -= 2;
	}

	for (i = 0; i < iTotals; i++) pkg << (unsigned long)0x00;

	pkg << (float)pQuest->Data.location[0];
	pkg << (float)pQuest->Data.location[1];
	pkg << (float)pQuest->Data.location[2];
	pkg << (unsigned long)pQuest->Data.location[3];

	string temp;
	temp = pQuest->Data.title;
	pkg << temp;
	temp = pQuest->Data.objectives;
	pkg << temp;
	temp = pQuest->Data.details;
	pkg << temp;
	temp = pQuest->Data.secondtext;
	pkg << temp;

	for (i = 0; i < 3; i++)
	{
		if(pQuest->Data.questmobid[i])
		{
			unsigned long creatureid=pQuest->Data.questmobid[i] | 0x08000000;
			CCreatureTemplate *pTemplate;
			if(!DataManager.RetrieveObject((CWoWObject**)&pTemplate, OBJ_CREATURETEMPLATE,creatureid))
			{
				return;
			}
			pkg << (unsigned long)creatureid << (unsigned long)pQuest->Data.questmobcount[i];
		} else {
			pkg << (unsigned long)0 << (unsigned long)0;
		}

		if(pQuest->Data.questitemid[i])
			pkg << (unsigned long)(DataManager.ItemTemplates[pQuest->Data.questitemid[i]]) << (unsigned long)pQuest->Data.questitemcount[i];
		else
			pkg << (unsigned long)0 << (unsigned long)0;
	}
	pkg << (unsigned long)0 << (unsigned long)0;
	pkg << (unsigned long)0 << (unsigned long)0;	// 4

	temp = pQuest->Data.parttext1;
	pkg << temp;
	temp = pQuest->Data.parttext2;
	pkg << temp;
	temp = pQuest->Data.parttext3;
	pkg << temp;
	temp = pQuest->Data.parttext4;
	pkg << temp;

	pClient->Send(&pkg);
}

void MsgQuestGiverAcceptQuest(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CQuestInfo *pQuest;

	unsigned long cguid;
	unsigned long junk;
	unsigned long questid;

	Data >> cguid >> junk >> questid;

	if (!DataManager.RetrieveObject((CWoWObject**)&pQuest,OBJ_QUESTINFO, questid))
	{
		questid = 455;				// insert bogus quest here
		pClient->Echo("couldn't find quest");
		DataManager.RetrieveObject((CWoWObject**)&pQuest,OBJ_QUESTINFO, questid);
		return;
	}

	unsigned long ns1;
	ns1 = GetQuestStatus(pClient, questid);

	// Update/Add to player's quest statuses
	SetQuestStatus(pClient, questid, QUEST_STATUS_INCOMPLETE);

	/*unsigned long ns;
	ns = GetQuestStatus(pClient, questid);
	*/
	long logslot;
	// need to check quest log slots! ;)
	logslot = pClient->pPlayer->FindOpenQuestSlot();
	if(logslot==-1) return; // Whoops, no free log slots!!

	_QuestLogSlot questslot;
	questslot.QuestID = questid;
	questslot.State = QUEST_STATUS_INCOMPLETE;
	unsigned long p;
	for(p=0;p<3;p++)
	{
		questslot.QuestItemCount[p] = 0;
		questslot.QuestMobCount[p] = 0;
	}

	questslot.Timer = 0;
	questslot.Explored = 0;

	unsigned long logfield=logslot*3+PLAYER_QUEST_LOG_1_1;
	pClient->pPlayer->Data.QuestLogSlots[logslot]=questslot;
	pClient->pPlayer->AddUpdateVal(logfield, questid);
	pClient->pPlayer->AddUpdateVal(logfield+1, 0);
	pClient->pPlayer->AddUpdateVal(logfield+2, 0);

	pClient->UpdateObject();
	// pClient->Echo("Accepted quest %d (%d: %s)", questid, pQuest->Data.questid, pQuest->Data.title);

	CheckForQuestCompletion(pClient, questid);
	return;
}

/* ---TRAINER HANDLERS--- */
void MsgLearnSpell(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long SpellID;
	Data >> SpellID;
	int i=0;
	while(pClient->pPlayer->Data.Spells[i])
	{
		if(SpellID == pClient->pPlayer->Data.Spells[i])
			return;
		i++;
	}
	pClient->LearnedSpell(SpellID);
	pClient->pPlayer->Data.Spells[i]=SpellID;
}

void SendTrainerList(CClient *pClient, CCreature *pCreature, unsigned long CreatureGuid)
{
	SpellRec spellinfo;
	CPacket pkg;
	pkg.Reset(SMSG_TRAINER_LIST);
	pkg << CreatureGuid << CREATUREGUID_HIGH;  //guid
	pkg << (unsigned long)0;

	pkg << (long)DataManager.TrainerTemplates[pCreature->Data.Template].size();  // count of things below
	for (std::list<_TrainerItem>::iterator i=DataManager.TrainerTemplates[pCreature->Data.Template].begin(); i!=DataManager.TrainerTemplates[pCreature->Data.Template].end();i++)
	{
		DBCManager.Spell.fetchRow((*i).SpellID,&spellinfo);
		// Check if player can use
		/*
		int l = 0;
		char hasspell = 0;
		char hasskill = 0;
		
		while(pClient->pPlayer->Data.Spells[l])
		{
			if(pClient->pPlayer->Data.Spells[l] == (*i).ReqSpell)
			{
				hasspell = 1;
				break;
			}
			l++;
		}
		l = 0;
		while(pClient->pPlayer->Data.Skills[l].SkillID)
		{
			if(pClient->pPlayer->Data.Skills[l].SkillID == (*i).SkillLine)
			{
				hasskill = 1;
				break;
			}
			l++;
		}
		*/

		pkg << (long)(*i).SpellID;

		/*if(hasskill == 0 || hasspell == 0)
		{
		*/	pkg << (char)0;	// usable
		//}  else {
		//pkg << (char)1;
		//}

		pkg << (long)(*i).SpellCost;	// moneycost
		pkg << (long)0; // pointcost
		pkg << (long)0; // pointcost2
		pkg << (char)spellinfo.spellLevel;	// reqlevel
		pkg << (long)0; //reqskillline
		pkg << (long)0; //reqskillrank
		pkg << (long)(*i).ReqSpell;	//reqability0
		pkg << (long)0; //reqability1
		pkg << (long)0; //reqability2
	}
	if (strlen(pCreature->pTemplate->Data.QuestGiverText) < 10)
	{
		/*		if (pCreature->pTemplate->Data.TextID > 0)
		{
		CNPCText *pText;
		if (!DataManager.RetrieveObject((CWoWObject**)&pText, OBJ_NPCTEXT, pCreature->pTemplate->Data.TextID))
		pkg << "NPC TextID not found.";
		else
		pkg << pText->Data.text;
		}
		else
		{*/
		pkg << "What can I teach you today, young $N?";
		//}
	}
	else
	{
		pkg << pCreature->pTemplate->Data.QuestGiverText;
	}
	pClient->Send(&pkg);
}

void MsgTrainerList(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long CreatureGuid;
	unsigned long templong;
	Data >> CreatureGuid;
	Data >> templong;

	CCreature* pCreature = NULL;
	DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE,CreatureGuid);

	SendTrainerList(pClient,pCreature,pCreature->guid);
}

void MsgTrainerBuySpell(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long CreatureGuid;
	unsigned long templong;
	unsigned long spellid;
	Data >> CreatureGuid;
	Data >> templong;
	Data >> spellid;
	CCreature* pCreature = NULL;
	DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE,CreatureGuid);
	if(pCreature != NULL)
	{
		int i=0;
		while(pClient->pPlayer->Data.Spells[i])
		{
			if(spellid == pClient->pPlayer->Data.Spells[i])
				return;
			i++;
		}
		//pClient->pPlayer->DataObject.pObject->AddUpdateVal(PLAYER_CHARACTER_POINTS1,50);
		//pClient->pPlayer->DataObject.pObject->AddUpdateVal(PLAYER_CHARACTER_POINTS2,40);
		//pClient->UpdateObject();

		unsigned long skillline = 0;
		for (std::list<_TrainerItem>::iterator ti=DataManager.TrainerTemplates[pCreature->Data.Template].begin(); ti!=DataManager.TrainerTemplates[pCreature->Data.Template].end();ti++)
		{
			if ((*ti).SpellID == spellid)
			{
				skillline = (*ti).SkillLine;
				break;
			}
		}

		if (!skillline)
			Debug.Log("No skill line found!");
		else
		{
			bool hasline = false;
			int l=0;
			while(pClient->pPlayer->Data.Skills[l].SkillID)
			{
				if(pClient->pPlayer->Data.Skills[l].SkillID == skillline)
				{
					hasline = true;
					break;
				}
				l++;
			}

			if (!hasline)
			{
				pClient->pPlayer->AddSkill(skillline,1,1,true);
				pClient->pPlayer->UpdateSkills(true);
			}
		}

		CPacket pkg;
		pkg.Reset(SMSG_SPELL_START);
		pkg << CreatureGuid << CREATUREGUID_HIGH;
		pkg << CreatureGuid << CREATUREGUID_HIGH;
		pkg << spellid;
		pkg << (long)0x00;
		pkg << (short)0x00;
		pkg << (short)0x02;
		pkg << pClient->pPlayer->guid << PLAYERGUID_HIGH;
		pClient->Send(&pkg);

		pkg.Reset(SMSG_LEARNED_SPELL);
		pkg << spellid;
		pClient->Send(&pkg);

		pkg.Reset(SMSG_SPELL_GO);
		pkg << CreatureGuid << CREATUREGUID_HIGH;
		pkg << CreatureGuid << CREATUREGUID_HIGH;
		pkg << spellid;
		pkg << (char)0x00;
		pkg << (char)0x01;
		pkg << (char)0x01;
		pkg << pClient->pPlayer->guid << PLAYERGUID_HIGH;
		pkg << (char)0x00;
		pkg << (short) 0x02;
		pkg << pClient->pPlayer->guid << PLAYERGUID_HIGH;
		pClient->Send(&pkg);

		pkg.Reset(SMSG_SPELLLOGEXECUTE);
		pkg << CreatureGuid << CREATUREGUID_HIGH;
		pkg << spellid;
		pkg << (long)0x01;
		pkg << (long)0x24;
		pkg << (long)0x01;
		pkg << pClient->pPlayer->guid << PLAYERGUID_HIGH;
		pClient->Send(&pkg);

		pkg.Reset(SMSG_TRAINER_BUY_SUCCEEDED);
		pkg << CreatureGuid << CREATUREGUID_HIGH;
		pkg << spellid;
		pClient->Send(&pkg);
		/*int k=0;
		while(pClient->pPlayer->Data.Spells[k]) k++;*/ // don't need to do this
		pClient->pPlayer->Data.Spells[i]=spellid; // i set from above loop; this is the first zero index

		// while(pCreature->trainerinfo.Item[i].SpellID!=spellid) i++;
		// pClient->pPlayer->Data.Copper-=pCreature->trainerinfo.Item[i].MoneyCost;
		// pClient->pPlayer->DataObject.SetCoinage(pClient->pPlayer->Data.Copper);
		pClient->pPlayer->UpdateObject();
	}
}

/* ---TRADE HANDLERS--- */
void TradeExtendedUpdate(CClient *pClient)
{
	CPlayer* pPlayer = NULL;
	CItem* pItem = NULL;

	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,pClient->pPlayer->tradingWith))
		return;

	// Update
	if(pPlayer != NULL)
	{
		CPacket pkg;
		pkg.Reset(SMSG_TRADE_STATUS_EXTENDED);
		// First part of update packet
		pkg << (unsigned char)1;
		pkg << (unsigned long)pClient->pPlayer->tradeNum;
		pkg << (unsigned long)0;
		pkg << (unsigned long)pClient->pPlayer->tradeGold;
		pkg << (unsigned long)0;

		int itemslotid;

		// Now loop through all trade items and add the ids and stuff to the packet
		for(int i=0; i<7; i++)
		{
			pItem = NULL;
			pkg << (unsigned char)i;
			if (pClient->pPlayer->tradeItems[i] != -1)
			{
				itemslotid = pClient->pPlayer->tradeItems[i];		// Slot that item is in

//				if(!DataManager.RetrieveObject((CWoWObject**)&pItem, OBJ_ITEM, pClient->pPlayer->Data.Items[itemslotid]))
				pItem = pClient->pPlayer->Data.Items[itemslotid];
				if(! pItem)
					return;

				pkg << (unsigned long)pItem->Data.nItemTemplate;
				pkg << (unsigned long)0;
				pkg << (unsigned long)pItem->Data.Count;
				// pkg << (unsigned long)1;
			} else {
				pkg << (unsigned long)0;
				pkg << (unsigned long)0;
				pkg << (unsigned long)0;
			}
			for(int j=0; j<12; j++)
				pkg << (unsigned long) 0;
		}
		pPlayer->pClient->Send(&pkg);
	}
	// End trade routine
}

void ClearTradeSettings(CClient *pClient, bool meonly)
{
	if(!meonly)
	{
		CPlayer* pPlayer = NULL;

		if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,pClient->pPlayer->tradingWith))
			return;

		pPlayer->tradeAccepted = false;
		pPlayer->tradeGold = 0;
		pPlayer->tradeNum = 0;
		pPlayer->tradeState = 0;
		pPlayer->tradingWith = 0;
		pPlayer->inTrade = false;
		for(int i=0; i < 7; i++)
			pPlayer->tradeItems[i] = -1;
	}
	pClient->pPlayer->tradeAccepted = false;
	pClient->pPlayer->tradeGold = 0;
	pClient->pPlayer->tradeNum = 0;
	pClient->pPlayer->tradeState = 0;
	pClient->pPlayer->tradingWith = 0;
	pClient->pPlayer->inTrade = false;
	for(int i=0; i < 7; i++)
		pClient->pPlayer->tradeItems[i] = -1;
}

void MsgInitiateTrade(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long PlayerGuid;
	unsigned long templong;
	Data >> PlayerGuid;
	Data >> templong;
	CPacket pkg;
	CPlayer* pPlayer = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,PlayerGuid))
	{
		return; //error
	}
	if(pPlayer != NULL)
	{
		CPlayer *pTarget = NULL;
		if(DataManager.RetrieveObject((CWoWObject**)&pTarget,OBJ_PLAYER,pPlayer->tradingWith))
		{
			if(pPlayer->tradingWith == pClient->pPlayer->guid)
			{
				pkg.Reset(SMSG_TRADE_STATUS);
				pkg << (unsigned long)TRADE_STATUS_ALREADY_TRADING;
				pkg << (unsigned long)pPlayer->guid << PLAYERGUID_HIGH;
				pClient->Send(&pkg);
				return;
			}
			pkg.Reset(SMSG_TRADE_STATUS);
			pkg << (unsigned long)TRADE_STATUS_PLAYER_BUSY;
			pkg << (unsigned long)pPlayer->guid << PLAYERGUID_HIGH;
			pClient->Send(&pkg);
			return;
		}
		ClearTradeSettings(pClient);
		pClient->pPlayer->tradingWith = pPlayer->guid;
		pPlayer->tradingWith = pClient->pPlayer->guid;
		pClient->pPlayer->tradeState = 1;
		pClient->pPlayer->tradeAccepted=false;
		pPlayer->tradeAccepted=false;

		pkg.Reset(SMSG_TRADE_STATUS);
		pkg << (unsigned long)TRADE_STATUS_PROPOSED;
		pkg << (unsigned long)pClient->pPlayer->guid << PLAYERGUID_HIGH;
		pPlayer->pClient->Send(&pkg);

		for(int i = 0; i < 7; i++)
		{
			pClient->pPlayer->tradeItems[i] = -1;
		}
	}
	else
	{
		pkg.Reset(SMSG_TRADE_STATUS);
		pkg << (unsigned long)TRADE_STATUS_PLAYER_NOT_FOUND;
		pkg << (unsigned long)PlayerGuid << PLAYERGUID_HIGH;
		pClient->Send(&pkg);
		return;
	}
}

void MsgBeginTrade(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long templong;
	Data >> templong;

	CPlayer* pPlayer = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,pClient->pPlayer->tradingWith))
	{
		return; //error
	}
	else
	{
		if(pPlayer != NULL)
		{
			pClient->pPlayer->tradeState = 2;
			CPacket pkg;
			pkg.Reset(SMSG_TRADE_STATUS);
			pkg << (unsigned long)TRADE_STATUS_INITIATED;
			pPlayer->pClient->Send(&pkg);
			pClient->Send(&pkg);
			pPlayer->tradeState = 2;
			pClient->pPlayer->tradeNum = 5;
			pPlayer->inTrade=true;
			pClient->pPlayer->inTrade=true;
			for(int i = 0; i < 7; i++)
			{
				pClient->pPlayer->tradeItems[i] = -1;
			}
		}
	}
}

void MsgUnAcceptTrade(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CPlayer* pPlayer = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,pClient->pPlayer->tradingWith))
	{
		return; //error
	}
	else
	{
		if(pPlayer != NULL)
		{
			pClient->pPlayer->tradeState = 9;
			if(pPlayer->tradeState == 9)
			{
				pClient->pPlayer->tradeState = 0;
				for(int i = 0; i < 7; i++)
				{
					pClient->pPlayer->tradeItems[i] = -1;
				}
				pClient->pPlayer->tradingWith = 0x00;
			}
			CPacket pkg;
			pkg.Reset(SMSG_TRADE_STATUS);
			pkg << (long)TRADE_STATUS_UNACCEPTED;
			pPlayer->pClient->Send(&pkg);
			pClient->pPlayer->tradeAccepted=false;
		}
	}
}

void MsgClearTradeItem(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned char slot;
	Data >> slot;
	if(slot >= 7) return; //only 7 slots!

	pClient->pPlayer->tradeItems[slot]=-1;
	TradeExtendedUpdate(pClient);
}

void MsgSetTradeGold(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long Amount;
	Data >> Amount;

	if(Amount<=pClient->pPlayer->Data.Copper) pClient->pPlayer->tradeGold=Amount;
	TradeExtendedUpdate(pClient);
}

void MsgAcceptTrade(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long templong;
	Data >> templong;

	CPlayer* pPlayer = NULL;
	pClient->pPlayer->tradeAccepted=true;		// Set accepted flag

	DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,pClient->pPlayer->tradingWith);
	if(pPlayer != NULL) {

		if (pPlayer->tradeAccepted)
		{
			CPacket pkg2;
			pkg2.Reset(SMSG_TRADE_STATUS);
			pkg2 << (long)TRADE_STATUS_ACCEPTED;
			pkg2 << pPlayer->pClient->pPlayer->guid << PLAYERGUID_HIGH;
			pPlayer->pClient->Send(&pkg2);
			CPlayer *pPlayer1=pClient->pPlayer;
			CPlayer *pPlayer2=pPlayer;

			// Item ids
//			unsigned long pItems1[6] = { 0, 0, 0, 0, 0, 0 };
//			unsigned long pItems2[6] = { 0, 0, 0, 0, 0, 0 };
			CItem *pItems1[6] = { 0, 0, 0, 0, 0, 0 };
			CItem *pItems2[6] = { 0, 0, 0, 0, 0, 0 };
			/*STEPS
			1) Check for sufficient free slots in backpack (TODO: Containers)
			2) Save items
			3) Delete trade items
			4) Create trade items in free slots
			5) Trade gold
			6) Cleanup and exit
			*/
			unsigned long i; //our counter
			unsigned long free1,free2,total1,total2;
			free1=0;
			free2=0;
			total1=0;
			total2=0;
			//check for free slots
			for(i=0;i<6;i++)
			{
				if(pPlayer1->tradeItems[i]>=SLOT_INBACKPACK) free1++; //if we are trading away backpack items, we get extra slots
				if(pPlayer2->tradeItems[i]>=SLOT_INBACKPACK) free2++;
				if(pPlayer1->tradeItems[i]!=-1) total1++;
				if(pPlayer2->tradeItems[i]!=-1) total2++;
			}
			for(i=SLOT_INBACKPACK;i<SLOT_INBACKPACK+16;i++)
			{
				if(!pPlayer1->Data.Items[i]) free1++;
				if(!pPlayer2->Data.Items[i]) free2++;
			}
			if(free1 < total2 || free2 < total1)
			{
				CPacket pkg;
				pkg.Reset(SMSG_TRADE_STATUS);
				pkg << (long)TRADE_STATUS_FAILED;
				pClient->Send(&pkg);
				pPlayer->pClient->Send(&pkg);
			}
			// Save the item number into the arrays and clear the items off
			for(i=0;i<6;i++)
			{
				if (pPlayer1->tradeItems[i] != -1)
				{
					pItems1[i] = pPlayer1->Data.Items[pPlayer1->tradeItems[i]];
					pPlayer1->DataObject.SetItem(pPlayer1->tradeItems[i],0); //clear
				}
				if (pPlayer2->tradeItems[i] != -1)
				{
					pItems2[i] = pPlayer2->Data.Items[pPlayer2->tradeItems[i]];
					pPlayer2->DataObject.SetItem(pPlayer2->tradeItems[i],0);
				}
			}

			// Add items to inventory
			for(i=0;i<6;i++)
			{
				if(pPlayer2->tradeItems[i] != -1)
				{
//					CItem *pItem;
					CItem *pItem = pItems2[i];
					int newSlot = pPlayer1->GetOpenBackpackSlot();
//					if(newSlot == -1 || !DataManager.RetrieveObject((CWoWObject**)&pItem,OBJ_ITEM,pItems2[i])) //wtf?!
					if(newSlot == -1 || !pItem) //wtf?!
					{
						CPacket pkg;
						pkg.Reset(SMSG_TRADE_STATUS);
						pkg << (long)TRADE_STATUS_FAILED;
						pClient->Send(&pkg);
						pPlayer->pClient->Send(&pkg);
					}
					pPlayer1->DataObject.SetItem(newSlot,pItems2[i]);
					pPlayer1->pClient->AddKnownItem(*pItem);
				}
				if(pPlayer1->tradeItems[i] != -1)
				{
//					CItem *pItem;
					CItem *pItem = pItems1[i];
					int newSlot = pPlayer2->GetOpenBackpackSlot();
//					if(newSlot == -1 || !DataManager.RetrieveObject((CWoWObject**)&pItem,OBJ_ITEM,pItems1[i])) //wtf?!
					if(newSlot == -1 || !pItem) //wtf?!
					{
						CPacket pkg;
						pkg.Reset(SMSG_TRADE_STATUS);
						pkg << (long)TRADE_STATUS_FAILED;
						pClient->Send(&pkg);
						pPlayer->pClient->Send(&pkg);
					}
					pPlayer2->DataObject.SetItem(newSlot,pItems1[i]);
					pPlayer2->pClient->AddKnownItem(*pItem);
				}
			}

			// Subtract/add money to traders
			if (pPlayer1->tradeGold > 0)
			{
				// Subtract from pPlayer1 and add to pPlayer2
				pPlayer1->Data.Copper -= pPlayer1->tradeGold;
				pPlayer2->Data.Copper += pPlayer1->tradeGold;
				pPlayer1->DataObject.SetCoinage(pPlayer1->Data.Copper);
				pPlayer2->DataObject.SetCoinage(pPlayer2->Data.Copper);
				pPlayer1->tradeGold = 0;
			}

			if (pPlayer2->tradeGold > 0)
			{
				// Subtract from pPlayer2 and add to pPlayer1
				pPlayer2->Data.Copper -= pPlayer2->tradeGold;
				pPlayer1->Data.Copper += pPlayer2->tradeGold;
				pPlayer2->DataObject.SetCoinage(pPlayer2->Data.Copper);
				pPlayer1->DataObject.SetCoinage(pPlayer1->Data.Copper);
				pPlayer2->tradeGold = 0;
			}
			// Recompute stats in case equipped items have been traded off
			pPlayer1->RecomputeAllStats();
			pPlayer2->RecomputeAllStats();
			// Send update packets to players
			pClient->UpdateObject();
			pPlayer->UpdateObject();

			ClearTradeSettings(pClient); //clear off all settings
			//cleanup statuses and stuff
			pClient->pPlayer->tradeNum=7;
			pPlayer->tradeNum=7;
			TradeExtendedUpdate(pClient);
			TradeExtendedUpdate(pPlayer->pClient);

			// Send final packet to complete trade
			CPacket pkg;
			pkg.Reset(SMSG_TRADE_STATUS);
			pkg << (long)TRADE_STATUS_COMPLETE;

			// Send away
			pClient->Send(&pkg);
			pPlayer->pClient->Send(&pkg);
		}
		else
		{
			// Acknowledge that they have accepted the trade from their side
			CPacket pkg;
			pkg.Reset(SMSG_TRADE_STATUS);
			pkg << (long)TRADE_STATUS_ACCEPTED;
			pPlayer->pClient->Send(&pkg);
		}
	}
}

void MsgCancelTrade(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CPlayer* pPlayer = NULL;
	if(DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,pClient->pPlayer->tradingWith))
	{
		if (pPlayer->inTrade)
		{
			CPacket pkg;
			pkg.Reset(SMSG_TRADE_STATUS);
			pkg << (long)TRADE_STATUS_CANCELLED;
			pPlayer->pClient->Send(&pkg);
			ClearTradeSettings(pClient);
		}
	}
}

void MsgSetTradeItem(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned char tradeslot;
	unsigned char dummy;
	unsigned char invslot;
	Data >> tradeslot;
	Data >> dummy;
	Data >> invslot;

	pClient->pPlayer->tradeItems[tradeslot] = (int)invslot;		// Set trade item

	TradeExtendedUpdate(pClient);
}

/* ---NPC GOSSIP HANDLERS--- */
void MsgGossipHello(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	// CMSG_GOSSIP_HELLO
	unsigned long CreatureGuid;
	Data >> CreatureGuid;

	SendGossipMenu(pClient, CreatureGuid);
}

void MsgGossipSelectOption(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long guid;
	unsigned long junk;
	unsigned long option;
	Data >> guid >> junk >> option;

	CPacket pkg;

	pkg.Reset(SMSG_GOSSIP_MESSAGE);
	pkg << guid << CREATUREGUID_HIGH;
	pkg << (unsigned long)999999;
	pkg << (unsigned long)3;
	CCreature *pCreature;
	if (!DataManager.RetrieveObject((CWoWObject**)&pCreature, OBJ_CREATURE, guid))
	{
		pClient->Echo("Creature not found");
		return;
	}
	if (option == 90)
	{
		// Trade
		pCreature->ListInventory(pClient);
		return;
	}
	if (option == 91)
	{
		// Train
		SendTrainerList(pClient,pCreature,pCreature->guid);
		return;
	}
	if (option == 92)
	{
		// Taxi, have to grab taxinode.
		CTaxiMob *pTaxi=(CTaxiMob*)pCreature;
		if(pCreature->bIsTaxi)
			SendTaxiNodes(pClient,pTaxi);
		else
			Packets::CloseGossip(pClient);
		return;
	}
	if (option == 93)
	{
		// Guild master
		pkg.Reset(SMSG_PETITION_SHOWLIST);
		pkg << guid << PLAYERGUID_HIGH;
		// Packets::PackGuid(pkg,guid,0);
		pkg << (char)1;
		pkg << (unsigned long)1;
		pkg	<< (unsigned long)0x16e7;
		pkg << (unsigned long)0x23ef;
		pkg << (unsigned long)1000;
		pkg << (unsigned long)1;
		pClient->Send(&pkg);
		return;
	}
	if (option == 94)
	{
		// Tabard Vendor
		pkg.Reset(MSG_TABARDVENDOR_ACTIVATE);
		//Packets::PackGuid(pkg,guid,0);
		pkg << guid << PLAYERGUID_HIGH;
		pClient->Send(&pkg);
		return;
	}		
	if (option == 100)
	{
		// Close gossip.
		Packets::CloseGossip(pClient);
		return;
	}
	if (option == 97)
	{
		// SH Handler, bring the nub back to life
		if(pClient->pPlayer->Data.bDead)
			pClient->pPlayer->Resurrect();
		Packets::CloseGossip(pClient);
		return;
	}
	if (option > 95)
	{
		SendGossipMenu(pClient,guid);
		return;
	}
	char filetoopen[128];
	sprintf(filetoopen, "data/gossipmenus/%s.txt", pCreature->pTemplate->Data.Name);
	FILE *file=NULL; // guess what? ifstream doesn't work in Linux, and it eats resources.
	if(_FileExists(filetoopen))
		file=fopen(filetoopen, "rt"); // open it *only if* we can find the file

	if (!file)
	{
		pClient->Echo("Gossip file not found.");
		return;
	} else {
		char commandtext[256];
		unsigned long l=0;
		while (fgets(commandtext,255,file))
		{
			commandtext[strlen(commandtext)-1]=0;
			if(l==option)
			{
				/* char *itemtitle = */ strtok(commandtext,":");
				char *itemtext = &commandtext[strlen(commandtext)+1];
				pkg << (unsigned long)99;
				pkg << (unsigned char)0;
				pkg << (unsigned char)0;
				pkg << itemtext;
				pkg << (unsigned long)98;
				pkg << (unsigned char)0;
				pkg << (unsigned char)0;
				pkg << "Go back...";
				pkg << (unsigned long)100;
				pkg << (unsigned char)0;
				pkg << (unsigned char)0;
				pkg << "I'm done talking to you.";
				fclose(file);
				pClient->Send(&pkg);
				return;
			} else {
				l++;
			}
		}
		fclose(file);
	}
	/*
	int j = 0;

	for (std::list<_GossipItem>::iterator i=DataManager.GossipMenus[pCreature->guid].begin();i!=DataManager.GossipMenus[pCreature->guid].end();i++)
	{
	if (j=option)
	{
	pkg << (unsigned long)998;
	pkg << (unsigned char)(*i).Icon;
	pkg << (unsigned char)(*i).Inputbox;
	pkg << (*i).Message2;

	pkg << (unsigned long)999;
	pkg << (unsigned char)0;
	pkg << (unsigned char)0;
	pkg << "Go back...";
	pClient->Send(&pkg);
	}
	}
	pkg << (unsigned long)998;
	pkg << (unsigned char)0;
	pkg << (unsigned char)0;
	pkg << "Message not found!";
	pkg << (unsigned long)999;
	pkg << (unsigned char)0;
	pkg << (unsigned char)0;
	pkg << "Go back...";*/
	pClient->Send(&pkg);
}
void MsgNpcTextQuery(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long textid;
	unsigned long value1;
	unsigned long value2;

	Data >> textid;
	Data >> value1 >> value2;

	pClient->pPlayer->AddUpdateVal(UNIT_FIELD_TARGET, value1);
	pClient->pPlayer->AddUpdateVal(UNIT_FIELD_TARGET + 1, value2);

	CPacket pkg;
	pkg.Reset(SMSG_NPC_TEXT_UPDATE);
	pkg << textid;
	pkg << (unsigned long)0;
	if(textid == 580)	// SH
	{
		GameMechanics::SpiritHealerTextQuery(pClient,NULL);
		return;
	}
	CCreatureTemplate *pTemplate;
	if (DataManager.RetrieveObject((CWoWObject**)&pTemplate, OBJ_CREATURETEMPLATE, textid))
	{
		// has a questgivertext field
		pkg << pTemplate->Data.QuestGiverText;
		pkg << pTemplate->Data.QuestGiverText;
	}
	else
	{
		pkg << "Hey there, $N. What can I do for you?";
		pkg << "Hey there, $N. What can I do for you?";
	}

	pClient->Send(&pkg);
}

/* ---TEXT HANDLERS--- */
void MsgPageTextQuery(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long textid,guid;
	Data >> textid >> guid;

	CPageText *pText;
	if(!DataManager.RetrieveObject((CWoWObject**)&pText,OBJ_PAGETEXT,textid|(OBJ_PAGETEXT << 24))) return;
	CPacket pkg;
	pkg.Reset(SMSG_PAGE_TEXT_QUERY_RESPONSE);
	pkg << textid;
	pkg << pText->Data.Text;
	pkg << (unsigned long)0;

	pClient->Send(&pkg);
}

void MsgReadItem(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned char bag, bagslot;
	Data >> bag >> bagslot;
	if(bag == 0xFF)
	{
//		CItem *pItem;
		CItem *pItem = pClient->pPlayer->Data.Items[bagslot];
		CPacket pkg;
//		if(!DataManager.RetrieveObject((CWoWObject**)&pItem,OBJ_ITEM,pClient->pPlayer->Data.Items[bagslot]))
		if(!pItem)
		{
			pkg.Reset(SMSG_READ_ITEM_FAILED);
			pkg << pClient->pPlayer->Data.Items[bagslot] << ITEMGUID_HIGH;
			pClient->Send(&pkg);
			return;
		}
		pkg.Reset(SMSG_READ_ITEM_OK);
		pkg << pClient->pPlayer->Data.Items[bagslot] << ITEMGUID_HIGH;
		pClient->Send(&pkg);
		return;
	}
	else // BAGSTODO
	{
		pClient->Echo("Bags not supported yet. bag = %d slot = %d", bag, bagslot);
	}
}

/* ---CHANNEL HANDLERS--- */
void MsgChannelJoin(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	string channelname,pass;
	Data >> channelname;
	Data >> pass;
	CChannel* pChannel=NULL;
	if(!(pChannel=CChannel::AllChannels[channelname]))
	{
		pChannel = new CChannel;
		pChannel->SetName(channelname);
		if(!strncmp(channelname.c_str(),"General - ",10)
			|| !strncmp(channelname.c_str(),"LocalDefense - ",15)
			|| !strncmp(channelname.c_str(),"WorldDefense",12) // this one doesn't have an area...
			|| !strncmp(channelname.c_str(),"Trade - ",8)
			|| !strncmp(channelname.c_str(),"LookingForGroup - ",18)) pChannel->SetConstant(true);
		CChannel::AllChannels[channelname] = pChannel;
	}
	pChannel->Join(pClient->pPlayer,pass.c_str());
}

void MsgChannelLeave(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	string channelname;
	Data >> channelname;

	if(!channelname.length())
		return;

	CChannel *chn = CChannel::AllChannels[channelname]; if(chn) chn->Leave(pClient->pPlayer);
	if(chn->GetNumPlayers() == 0 && !chn->IsConstant())
	{
		delete chn;
		CChannel::AllChannels.erase(channelname);
	}
}

void MsgChannelList(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	string channelname;
	Data >> channelname;
	CChannel *chn = CChannel::AllChannels[channelname]; if(chn) chn->List(pClient->pPlayer);
}

void MsgChannelPassword(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	string channelname,pass;
	Data >> channelname;
	Data >> pass;
	CChannel *chn = CChannel::AllChannels[channelname]; if(chn) chn->Password(pClient->pPlayer,pass.c_str());
}

void MsgChannelSetOwner(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	string channelname,newp;
	Data >> channelname;
	Data >> newp;
	CChannel *chn = CChannel::AllChannels[channelname]; if(chn) chn->SetOwner(pClient->pPlayer,newp.c_str());
}

void MsgChannelOwner(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	string channelname;
	Data >> channelname;
	CChannel *chn = CChannel::AllChannels[channelname]; if(chn) chn->GetOwner(pClient->pPlayer);
}

void MsgChannelModerator(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	string channelname,otp;
	Data >> channelname;
	Data >> otp;
	CChannel *chn = CChannel::AllChannels[channelname]; if(chn) chn->SetModerator(pClient->pPlayer,otp.c_str());
}

void MsgChannelUnmoderator(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	string channelname,otp;
	Data >> channelname;
	Data >> otp;
	CChannel *chn = CChannel::AllChannels[channelname]; if(chn) chn->UnsetModerator(pClient->pPlayer,otp.c_str());
}

void MsgChannelMute(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	string channelname,otp;
	Data >> channelname;
	Data >> otp;
	CChannel *chn = CChannel::AllChannels[channelname]; if(chn) chn->SetMute(pClient->pPlayer,otp.c_str());
}

void MsgChannelUnmute(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	string channelname,otp;
	Data >> channelname;
	Data >> otp;
	CChannel *chn = CChannel::AllChannels[channelname]; if(chn) chn->UnsetMute(pClient->pPlayer,otp.c_str());
}

void MsgChannelInvite(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	string channelname,otp;
	Data >> channelname;
	Data >> otp;
	CChannel *chn = CChannel::AllChannels[channelname]; if(chn) chn->Invite(pClient->pPlayer,otp.c_str());
}
void MsgChannelKick(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	string channelname,otp;
	Data >> channelname;
	Data >> otp;
	CChannel *chn = CChannel::AllChannels[channelname]; if(chn) chn->Kick(pClient->pPlayer,otp.c_str());
}

void MsgChannelBan(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	string channelname,otp;
	Data >> channelname;
	Data >> otp;
	CChannel *chn = CChannel::AllChannels[channelname]; if(chn) chn->Ban(pClient->pPlayer,otp.c_str());
}

void MsgChannelUnban(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	string channelname,otp;
	Data >> channelname;
	Data >> otp;
	CChannel *chn = CChannel::AllChannels[channelname]; if(chn) chn->UnBan(pClient->pPlayer,otp.c_str());
}

void MsgChannelAnnounce(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	string channelname;
	Data >> channelname;
	CChannel *chn = CChannel::AllChannels[channelname]; if(chn) chn->Announce(pClient->pPlayer);
}

void MsgChannelModerate(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	string channelname;
	Data >> channelname;
	CChannel *chn = CChannel::AllChannels[channelname]; if(chn) chn->Moderate(pClient->pPlayer);
}

/* ---MAIL HANDLERS--- */
void MsgSendMail(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	string sendto, subject, body;
	unsigned long Mailbox, MailboxHigh;
	unsigned long Item,ItemHigh;
	unsigned long Unk1, Unk2;
	unsigned long Money, cod;

	Data >> Mailbox >> MailboxHigh;
	Data >> sendto >> subject >> body;
	Data >> Unk1 >> Unk2; //unk1 default 0x29; unk2 default 0x00
	Data >> Item >> ItemHigh;
	Data >> Money >> cod;

	CPacket pkg;
	pkg.Reset(SMSG_SEND_MAIL_RESULT);
	pkg << (unsigned long)0 << (unsigned long)MAIL_NONE;

	MakeLower(sendto);
	unsigned long receiver=0;
	receiver = DataManager.PlayerNames[sendto];

	if(!receiver)
	{
		pkg << MAIL_ERR_RECIPIENT_NOT_FOUND;
		pClient->Send(&pkg);
		return;
	}
	CPlayer *pTo;
	if (!DataManager.RetrieveObject((CWoWObject**)&pTo, OBJ_PLAYER, receiver))
	{
		pkg << MAIL_ERR_RECIPIENT_NOT_FOUND;
		pClient->Send(&pkg);
		return;
	}
	if(receiver == pClient->pPlayer->guid)
	{
		pkg << MAIL_ERR_CANNOT_SEND_TO_SELF;
		pClient->Send(&pkg);
		return;
	}
	if ((pClient->pPlayer->Data.Copper - Money) < 30)
	{
		pkg << MAIL_ERR_NOT_ENOUGH_MONEY;
		pClient->Send(&pkg);
		return;
	}

	pClient->pPlayer->DataObject.SetCoinage(pClient->pPlayer->Data.Copper-(30+Money));
	pClient->UpdateObject();

	// find the destination player

	CMail *pMail=new CMail;
	pMail->New();

	pMail->Data.Sender = pClient->pPlayer->guid;
	pMail->Data.Recipient = receiver;
	pMail->Data.Unknown = Unk1;
	strcpy(pMail->Data.Text, body.c_str());
	strcpy(pMail->Data.Subject, subject.c_str());
	time(&pMail->Data.TimeSent);
	pMail->Data.Money = Money;
	pMail->Data.COD = cod;

	pMail->Data.AttachmentGuid = Item;
	if(Item) //scan for and delete item
	{
		bool found=false;
		for (int i = SLOT_INBACKPACK ; i < SLOT_INBACKPACK+16 ; i++)
		{
			if (pClient->pPlayer->Data.Items[i]->guid==Item)
			{
				pClient->pDataObject->SetItem(i,0);
				found=true;
				break;
			}
		}
		if(!found)
		{
			pkg << MAIL_ERR_INTERNAL_ERROR;
			pClient->Send(&pkg);
		}
	}

	DataManager.NewObject(*pMail);
	if(Item)
	{
		EventManager.AddEvent(*pMail,3600000,EVENT_MAIL_DELIVER,0,0);
	}
	else
	{
		pTo->Mails.push_back(pMail);			// add to pMail list
		if(pTo->pClient) pTo->pClient->OutPacket(SMSG_RECEIVED_MAIL,"\x01",1);
	}
	pMail->Data.TimeExpire=time(NULL)+30*24*3600; // wait 30 days for expiry
	EventManager.AddEvent(*pMail,3600000,EVENT_MAIL_EXPIRE_CHECK,0,0); // check every hour for expiry
	pkg << MAIL_OK;
	pClient->Send(&pkg);
}

void MsgGetMailList(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CPacket pkg;
	pkg.Reset(SMSG_MAIL_LIST_RESULT);
	pkg << (unsigned char)pClient->pPlayer->Mails.size(); // Number of messages
	for(std::list<CMail *>::iterator i=pClient->pPlayer->Mails.begin();i!=pClient->pPlayer->Mails.end();i++)
	{
		pkg << (*i)->guid; // Message ID
		pkg << (unsigned char)0; //Unknown
		pkg << (*i)->Data.Sender << PLAYERGUID_HIGH; //Player GUID
		pkg << (*i)->Data.Subject; //Subject
		pkg << (*i)->guid; // TextID
		pkg << (unsigned long)0; //If there is a gift, send 2 instead.
		pkg << (unsigned long)(*i)->Data.Unknown; //Unknown (default 0x29)
		CItem *pItem;
		if((*i)->Data.AttachmentGuid && DataManager.RetrieveObject((CWoWObject**)&pItem,OBJ_ITEM,(*i)->Data.AttachmentGuid))
		{
			pkg << pItem->Data.nItemTemplate;
			pkg << (unsigned long)0 << (unsigned long)0; // Random Property 1 & 2
			pkg << (unsigned long)0; //Unknown
			pkg << (unsigned char)pItem->Data.Count; // Count
			pkg << (long)-1; // Charges?
			pkg << (unsigned long)0 << (unsigned long)0; // MaxDurability & Durability
		}
		else pkg << (long)0 << (long)0 << (long)0 << (long)0 << (char)1 << (long)-1 << (long)0 << (long)0;
		pkg << (*i)->Data.Money;
		pkg << (*i)->Data.COD;
		pkg << (unsigned long)(((*i)->Data.Flags & MAIL_READ)?1:0);
		pkg << float(((*i)->Data.TimeSent - time(NULL)) / 3600.0);	// Time sent
	}
	pClient->Send(&pkg);
}

void MsgItemTextQuery(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long messageid;
	Data >> messageid;

	CMail *pMail;
	if(!DataManager.RetrieveObject((CWoWObject**)&pMail,OBJ_MAIL,messageid)) return;
	CPacket pkg;
	pkg.Reset(SMSG_ITEM_TEXT_QUERY_RESPONSE);
	pkg << messageid;
	pkg << pMail->Data.Text;
	pkg << (unsigned long)0;

	pClient->Send(&pkg);
}

void MsgMailMarkAsRead(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long Mailbox,MailboxHigh,MailID;
	Data >> Mailbox >> MailboxHigh >> MailID;
	CMail *pMail;
	if(!DataManager.RetrieveObject((CWoWObject**)&pMail,OBJ_MAIL,MailID)) return;
	pMail->Data.Flags |= MAIL_READ;
	// now 3 days
	pMail->Data.TimeExpire=time(NULL)+3*24*3600;
	// check should already be progressing
}

void MsgMailTakeMoney(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long Mailbox,MailboxHigh,MailID;
	Data >> Mailbox >> MailboxHigh >> MailID;
	CMail *pMail;
	CPacket pkg;
	pkg.Reset(SMSG_SEND_MAIL_RESULT);
	pkg << MailID;
	pkg << (unsigned long)MAIL_RES_MONEY_TAKEN;
	if(!DataManager.RetrieveObject((CWoWObject**)&pMail,OBJ_MAIL,MailID))
	{
		pkg << MAIL_ERR_INTERNAL_ERROR;
		pClient->Send(&pkg);
		return;
	}
	pClient->pDataObject->SetCoinage(pClient->pPlayer->Data.Copper+pMail->Data.Money);
	pClient->UpdateObject();
	pMail->Data.Money=0;
	pkg << MAIL_OK;
	pClient->Send(&pkg);
}

void MsgMailTakeItem(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long Mailbox,MailboxHigh,MailID;
	Data >> Mailbox >> MailboxHigh >> MailID;
	CMail *pMail;
	CPacket pkg;
	pkg.Reset(SMSG_SEND_MAIL_RESULT);
	pkg << MailID;
	pkg << (unsigned long)MAIL_RES_ITEM_TAKEN;
	if(!DataManager.RetrieveObject((CWoWObject**)&pMail,OBJ_MAIL,MailID))
	{
		pkg << MAIL_ERR_INTERNAL_ERROR;
		pClient->Send(&pkg);
		return;
	}
	int newSlot=pClient->pPlayer->GetOpenBackpackSlot();
	if(newSlot==-1)
	{
		pkg << MAIL_ERR_BAG_FULL;
		pClient->Send(&pkg);
		return;
	}
	if(pMail->Data.COD)
	{
		if(pClient->pPlayer->Data.Copper < pMail->Data.COD)
		{
			pkg << MAIL_ERR_NOT_ENOUGH_MONEY;
			pClient->Send(&pkg);
			return;
		}
		pClient->pDataObject->SetCoinage(pClient->pPlayer->Data.Copper-pMail->Data.COD);
		pClient->UpdateObject();
	}
	CItem *pItem=NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pItem,OBJ_ITEM,pMail->Data.AttachmentGuid))
	{
		pkg << MAIL_ERR_INTERNAL_ERROR; //what? we can't find the damn item...
		pClient->Send(&pkg);
		return;
	}
//	pClient->pDataObject->SetItem(newSlot,pItem->guid);
	pClient->pDataObject->SetItem(newSlot,pItem);
	pClient->AddKnownItem(*pItem);
	pMail->Data.AttachmentGuid=0;
	pkg << MAIL_OK;
	pClient->Send(&pkg);
}

void MsgMailDelete(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long Mailbox,MailboxHigh,MailID;
	Data >> Mailbox >> MailboxHigh >> MailID;
	CMail *pMail;
	CPacket pkg;
	pkg.Reset(SMSG_SEND_MAIL_RESULT);
	pkg << MailID;
	pkg << (unsigned long)MAIL_RES_DELETED;
	if(!DataManager.RetrieveObject((CWoWObject**)&pMail,OBJ_MAIL,MailID))
	{
		pkg << MAIL_ERR_INTERNAL_ERROR;
		pClient->Send(&pkg);
		return;
	}
	pClient->pPlayer->Mails.remove(pMail);
	DataManager.DeleteObject(*pMail);
	pkg << MAIL_OK;
	pClient->Send(&pkg);
}

/* ---TAXI HANDLERS--- */
void MsgTaxiQueryStatus(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	/*
	structure of CMSG_TAXINODE_STATUS_QUERY:
	uint64 VendorGUID

	structure of SMSG_TAXINODE_STATUS:
	uint64 VendorGUID
	byte Status

	enum Status:
	TAXINODE_NONE = 0x0,
	TAXINODE_CURRENT = 0x1,
	TAXINODE_REACHABLE = 0x2,
	TAXINODE_DISTANT = 0x3,
	*/

	CTaxiMob *pCreature = NULL;
	unsigned long CreatureGuid;
	Data >> CreatureGuid;
	if(DataManager.RetrieveObject((CWoWObject**)&pCreature ,OBJ_CREATURE,CreatureGuid ))
	{
		if(!pCreature->bIsTaxi) return;
		CPacket pkg;
		pkg.Reset( SMSG_TAXINODE_STATUS );
		pkg << CreatureGuid << CREATUREGUID_HIGH;
		pkg << uint8( 1 );
		pClient->Send( &pkg );
	}
}
void SendTaxiNodes(CClient *pClient, CTaxiMob *pCreature)
{
	if(!pCreature->bIsTaxi) return;
	unsigned long loop = 0;

	unsigned long TMask[8];

	memset(TMask, 0, sizeof(TMask));

	for ( int tp = 0 ; tp < DBCManager.TaxiPath.rowcount() ; tp++ )
	{
		if( DBCManager.TaxiPath.getIntValueNoKey(tp,1) == pCreature->nodeid )
		{
			unsigned long ToTaxiNode=DBCManager.TaxiPath.getIntValueNoKey(tp,2) - 1;
			TMask[ToTaxiNode >> 5] |= 1 << (ToTaxiNode&31);
			break;
		}
	}

	TMask[(pCreature->nodeid-1)>>5] |= 1 << ((pCreature->nodeid-1)&31);

	CPacket pkg;
	pkg.Reset( SMSG_SHOWTAXINODES );
	pkg << uint32( 1 );
	pkg << pCreature->guid << CREATUREGUID_HIGH;
	pkg << pCreature->nodeid;
	loop = 0;
	while ( loop < 8 )
	{
		TMask[loop] &= CTaxiMob::Mask[loop];
		pkg << TMask[loop];
		loop++;
	}
	pClient->Send( &pkg );
}
void MsgTaxiQueryNodes(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CTaxiMob *pCreature = NULL;
	unsigned long CreatureGuid;
	Data >> CreatureGuid;
	if(DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE,CreatureGuid))
		SendTaxiNodes(pClient,pCreature);
}

void MsgTaxiActivate(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	/*
	structure of CMSG_ACTIVATETAXI:
	uint64 VendorGUID
	uint32 StartNode
	uint32 DestNode

	structure of SMSG_ACTIVATETAXIREPLY:
	uint Code

	Code enum:
	TAXINOERROR = 0x0,
	TAXIUNSPECIFIEDSERVERERROR = 0x1,
	TAXINOSUCHPATH = 0x2,
	TAXINOTENOUGHMONEY = 0x3,
	TAXITOOFARAWAY = 0x4,
	TAXINOVENDORNEARBY = 0x5,
	TAXINOTVISITED = 0x6,
	TAXIPLAYERBUSY = 0x7,
	TAXIPLAYERALREADYMOUNTED = 0x8,
	TAXIPLAYERSHAPESHIFTED = 0x9,
	TAXIPLAYERMOVING = 0xA,
	TAXINOPATHS = 0xB,
	*/

	CTaxiMob *pCreature = NULL;
	unsigned long CreatureGuid = 0;
	int CurrentNode = 0;
	int DestinationNode = 0;
	int loop = 0;
	int PathID = 0;
	unsigned int PathCount = 0;
	unsigned int PathCost = 0;
	int PathNodeIndex = 0;
	unsigned int NotParsed = 0;
	unsigned int SpeedFactor = 32;
	float len = 0, xd = 0, yd = 0, zd = 0;
	CPacket pkg;

	Data >> CreatureGuid >> NotParsed >> CurrentNode >> DestinationNode;

	if(DataManager.RetrieveObject((CWoWObject**)&pCreature ,OBJ_CREATURE,CreatureGuid ))
	{
		if(!pCreature->bIsTaxi) return;

		//pClient->Echo("Source %d | Destiny %d", CurrentNode, DestinationNode);

		for( loop = 0 ; loop < DBCManager.TaxiPath.rowcount() ; loop++ )
		{
			if( DBCManager.TaxiPath.getIntValueNoKey( loop, 1 ) == CurrentNode && DBCManager.TaxiPath.getIntValueNoKey( loop, 2 ) == DestinationNode )
			{
				PathID = DBCManager.TaxiPath.getIntValueNoKey( loop, 0 );
				PathCost = DBCManager.TaxiPath.getIntValueNoKey( loop, 3 );
				break;
			}
		}

		//pClient->Echo("The PathID is : %d | PathCost is : %d", PathID, PathCost);

		//if ( pClient->pPlayer->Data.Copper >= PathCost )
		//{
		pkg.Reset(SMSG_ACTIVATETAXIREPLY);
		pkg << 0x0;
		pClient->Send(&pkg);

		pClient->pDataObject->SetCoinage(pClient->pPlayer->Data.Copper - PathCost);
		pClient->pDataObject->SetMountModel(1147);
		pClient->pDataObject->SetFlag(0x0020);
		pClient->UpdateObject();

		pClient->pPlayer->bIsFlying = true;
		//}
		//else
		//{
		//pkg.Reset(SMSG_ACTIVATETAXIREPLY);
		//pkg << 0x3;
		//pClient->Send(&pkg);
		//return;
		//}

		for ( loop = 0 ; loop < DBCManager.TaxiPathNodes.rowcount() ; loop++  )
		{
			if( DBCManager.TaxiPathNodes.getIntValueNoKey( loop, 1 ) == PathID )
			{
				PathCount++;
			}
		}

		//pClient->Echo("The PathCount is : %d", PathCount);

		_Location *p = new _Location[PathCount];

		for ( loop = 0 ; loop < DBCManager.TaxiPathNodes.rowcount() ; loop++  )
		{
			if( DBCManager.TaxiPathNodes.getIntValueNoKey( loop, 1 ) == PathID )
			{
				p[PathNodeIndex].X = DBCManager.TaxiPathNodes.getFloatValueNoKey( loop, 4 );
				p[PathNodeIndex].Y = DBCManager.TaxiPathNodes.getFloatValueNoKey( loop, 5 );
				p[PathNodeIndex].Z = DBCManager.TaxiPathNodes.getFloatValueNoKey( loop, 6 );
				PathNodeIndex++;
			}
		}

		//pClient->Echo("The PathNodeIndex is : %d", PathNodeIndex);

		for( loop = 0 ; loop < PathNodeIndex ; loop++ )
		{
			xd = p[ loop ].X - p[ loop-1 ].X;
			yd = p[ loop ].Y - p[ loop-1 ].Y;
			zd = p[ loop ].Z - p[ loop-1 ].Z;
			len += (float)sqrt( xd * xd + yd*yd + zd*zd );
		}

		unsigned int Lenght = (unsigned int)len;
		unsigned int TravelTime = Lenght * SpeedFactor;

		//pClient->Echo("Lenght : %d | TravelTime %d", Lenght, TravelTime/3600);

		pkg.Reset(SMSG_MONSTER_MOVE);
		Packets::PackGuid(pkg,pClient->pPlayer->guid,PLAYERGUID_HIGH);
		/*pkg << (char)0xFF;
		pkg << pClient->pPlayer->guid << PLAYERGUID_HIGH;*/
		pkg << pClient->pPlayer->Data.Loc.X;
		pkg << pClient->pPlayer->Data.Loc.Y;
		pkg << pClient->pPlayer->Data.Loc.Z;
		pkg << pClient->pPlayer->Data.Facing;
		pkg << (char)0x00;
		pkg << (int)0x00000300;
		pkg << TravelTime;
		pkg << PathCount;

		for ( loop = 0 ; loop < DBCManager.TaxiPathNodes.rowcount() ; loop++  )
		{
			if( DBCManager.TaxiPathNodes.getIntValueNoKey( loop, 1 ) == PathID )
			{
				pkg << DBCManager.TaxiPathNodes.getFloatValueNoKey( loop, 4 );
				pkg << DBCManager.TaxiPathNodes.getFloatValueNoKey( loop, 5 );
				pkg << DBCManager.TaxiPathNodes.getFloatValueNoKey( loop, 6 );
			}
		}

		pClient->Send(&pkg);

		pClient->pPlayer->Data.Loc.X = p[PathNodeIndex-1].X;
		pClient->pPlayer->Data.Loc.Y = p[PathNodeIndex-1].Y;
		pClient->pPlayer->Data.Loc.Z = p[PathNodeIndex-1].Z;

		delete p;

		EventManager.AddEvent(*(pClient->pPlayer), TravelTime, EVENT_PLAYER_DISMOUNT, 0, 0);

		//!worldport 0 -8840.55957031 489.700012207 109.61000061
	}
}

/* ---FACTION HANDLERS--- */
void SetFactionAtWar(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long FactionID;
	BYTE  Flag;

	Data >> FactionID;
	Data >> Flag;

	if(FactionID < FACTION_ARRAY_COUNT)
	{
		if( Flag )
			pClient->pPlayer->Data.factionlist[FactionID].Flags|=2;
		else if( pClient->pPlayer->Data.factionlist[FactionID].Flags>=2)
			pClient->pPlayer->Data.factionlist[FactionID].Flags-=2;
		pClient->pPlayer->UpdateReputation(FactionID);
	}
	else Debug.Logf("Invalid Faction %i",FactionID);
}

void SetFactionCheat(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long FactionID;
	unsigned long Standing;

	Data >> FactionID;
	Data >> Standing;
	if(FactionID < FACTION_ARRAY_COUNT)
	{
		pClient->pPlayer->Data.factionlist[FactionID].Standing += Standing;
		pClient->pPlayer->Data.factionlist[FactionID].Flags |=1;
		pClient->pPlayer->UpdateReputation(FactionID);
	}
	else Debug.Logf("Invalid Faction %i",FactionID);
}

/* ---MISC HANDLERS--- */
void MsgGMTicket(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	char ReportType;
	long Unknown;
	_Location Loc;
	string Msg,FutureUse;

	Data >> ReportType;
	/*
	1 = Stuck
	2 = Harassment
	3 = Guild
	4 = Item
	5 = Environmental
	6 = Creep
	7 = Quest NPC
	8 = ?
	9 = Account/Billing
	10= Character
	*/
	char *ReportTypes[]=
	{"Unknown","Stuck","Harassment","Guild","Item","Environmental","Creep","Quest NPC","Unknown","Account/Billing","Character"};
	Data >> Unknown;
	Data >> Loc;
	Data >> Msg;
	Data >> FutureUse;

	FILE *file;
	struct tm * timeinfo;
	time_t aclock;
	file = fopen("data/report.log","a+");
	if (file!=NULL)
	{
		time(&aclock);
		timeinfo = localtime(&aclock);
		fprintf(file,"\tCharacter: %s\tReport Type: %s\tTime: %s\tLocation: %.3f %.3f %.3f\tReport: %s\n", pClient->pPlayer->Data.Name, (ReportType<=10)?ReportTypes[ReportType]:"", asctime(timeinfo),Loc.X,Loc.Y,Loc.Z,Msg.c_str());
		fclose(file);
		pClient->Echo("Your report has been recorded into our log file.");
		pClient->OutPacket(SMSG_GMTICKET_CREATE,"\x02\x00\x00\x00",4); //success?
	}
	else {
		//pClient->Echo("Problem opening log file.");
		pClient->OutPacket(SMSG_GMTICKET_CREATE,"\x03\x00\x00\x00",4); //general failure
	}
	/*response codes: 0 - success; 1 - already have a gm ticket; 2 - ?(success?); 3 - general error*/
}
void MsgGMTicketSystemStatus(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	pClient->OutPacket(SMSG_GMTICKET_SYSTEMSTATUS,"\x01\x00\x00\x00",4);
	//0: unavailable 1: available
}
void MsgQueryNextMailTime(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	pClient->OutPacket(MSG_QUERY_NEXT_MAIL_TIME,"\x00\xc0\xa8\xc7",4); //-86400 float
}
void MsgGetTicket(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	pClient->OutPacket(SMSG_GMTICKET_GETTICKET,"\x01\x00\x00\x00",4);
}
void MsgMeetStone(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	char buffer[12];
	memset(buffer,0,12);
	pClient->OutPacket(SMSG_MEETINGSTONE_SETQUEUE,buffer,12);
}
void MsgSetGameUiTarget(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	Data >> pClient->pPlayer->TargetID;
	pClient->pPlayer->ResetCombo();
}
void MsgTime(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long curtime=time(NULL);
	pClient->OutPacket(SMSG_QUERY_TIME_RESPONSE,&curtime,4);
}

void MsgMoveTimeSkipped(CClient *pClient, unsigned int msgID, CDataBuffer &Data) {}

void MsgTutorialClear(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	memset(&pClient->pPlayer->Data.TutorialFlags,0xff,0x20);
}
void MsgHelm(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	pClient->pDataObject->ToggleFlag(STATUS_NOHELM);
	pClient->UpdateObject();
}
void MsgCloak(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	pClient->pDataObject->ToggleFlag(STATUS_NOCLOAK);
	pClient->UpdateObject();
}
void MsgSetWeaponMode(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned char mode;
	Data >> mode;
	pClient->pDataObject->SetWeaponMode(mode);
	pClient->UpdateObject();
}
void MsgStandState(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned char state;
	Data >> state;
	pClient->pDataObject->SetStandState(state);
	pClient->UpdateObject();
}
void MsgSetSheathed(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	pClient->pPlayer->bSheathed = !pClient->pPlayer->bSheathed;

	if (pClient->pPlayer->bSheathed)
	{
		pClient->pPlayer->AddUpdateVal(UNIT_FIELD_FLAGS, UNIT_FLAG_SHEATHE | 0x1008);
	}
	else
	{
		pClient->pPlayer->AddUpdateVal(UNIT_FIELD_FLAGS, 0x1008);
	}
	pClient->pPlayer->UpdateObject();
}
void MsgRoll(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long min;
	unsigned long max;
	unsigned long roll;

	Data >> min;
	Data >> max;

	roll = min + (rand() % max);

	CPacket pkg;
	pkg.Reset(MSG_RANDOM_ROLL);
	pkg << min;
	pkg << max;
	pkg << roll;
	pkg << pClient->pPlayer->guid;
	pkg << (unsigned long)0;
	pClient->SendRegionNotMe(&pkg,SAYDIST);
	pClient->Echo("You rolled %d (%d-%d)",roll,min,max);
}

void MsgLearnTalent(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long talentid;
	unsigned long requestedrank;
	Data >> talentid >> requestedrank;
	// pClient->pPlayer->AddUpdateVal(PLAYER_CHARACTER_POINTS1, 10);
	// pClient->UpdateObject();

	TalentRec talentinfo;
	if (!DBCManager.Talent.fetchRow(talentid,&talentinfo))
	{
		pClient->Echo("Couldn't find talent in data file!");
		return;
	}
	unsigned currentpoints = (pClient->pPlayer->Data.Level-9)-(pClient->pPlayer->Data.UsedTalentPoints);
	if (currentpoints > 0)
	{
		CPacket pkg;int i=0;
		if(requestedrank > 0 )
		{
			unsigned long spellid2=talentinfo.RankID[requestedrank-1];
			pkg.Reset(SMSG_REMOVED_SPELL);
			pkg << (unsigned long)spellid2;
			pClient->Send(&pkg);
			while(pClient->pPlayer->Data.Spells[i])
			{
				if (pClient->pPlayer->Data.Spells[i] == spellid2)
					pClient->pPlayer->Data.Spells[i] = 0;
				i++;
			}
			i=0;
			while(pClient->pPlayer->Data.Talents[i])
			{
				if (pClient->pPlayer->Data.Talents[i] == spellid2)
					pClient->pPlayer->Data.Talents[i] = 0;
				i++;
			}
		}
		unsigned long spellid=talentinfo.RankID[requestedrank];
		pkg.Reset(SMSG_LEARNED_SPELL);
		pkg << (unsigned long)spellid;
		pClient->Send(&pkg);
		while(pClient->pPlayer->Data.Spells[i]) i++;
		pClient->pPlayer->Data.Spells[i]=spellid;
		i=0;
		while(pClient->pPlayer->Data.Talents[i]) i++;
		pClient->pPlayer->Data.Talents[i]=spellid;i=0;
		currentpoints--;
		pClient->pPlayer->AddUpdateVal(PLAYER_CHARACTER_POINTS1,currentpoints);
		pClient->UpdateObject();
		pClient->pPlayer->Data.UsedTalentPoints++;
	}
	return;
}
void MsgCancelAura(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long id;Data>>id;
	for(int i=0;i<64;i++)
	{
		if(pClient->pPlayer->Field_Aura[i] == id)
		{
			pClient->pPlayer->RemoveAura(i);return;
		}
	}
}
// --- PET HANDLERS --- //
void MsgPetAction(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long petguid;
	unsigned short flags;
	unsigned short flags2;
	unsigned long high1;

	if (pClient->pPlayer->SummonGuid == 0)
		return;		// Don't continue if we don't have a pet

	CCreature *pPet;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPet,OBJ_CREATURE,pClient->pPlayer->SummonGuid))
		return;		// Can't find pet? WTF?

	Data >> petguid >> high1 >> flags >> flags2;
	if(flags == 0x0002 && flags2 == 1792)		// attack
	{
		pClient->Echo("PET ACTION RECIEVED: Attack");
		pPet->PetAction1 = 1;	// 1 = attack
		if (pClient->pPlayer->TargetID)		// we don't want to attack if we don't have a target
		{
			pPet->TargetID = pClient->pPlayer->TargetID;
			pPet->Attack();
		}
		return;
	}
	if(flags == 0x0001 && flags2 == 1792)		// follow
	{
		pClient->Echo("PET ACTION RECIEVED: Follow");
		pPet->PetAction1 = 2;	// 2 = follow
		pPet->AI_Update();
		return;
	}
	if(flags == 0x0000 && flags2 == 1792)		// stay
	{
		pPet->PetAction1 = 3;
		pClient->Echo("PET ACTION RECIEVED: Stay");

		return;
	}
	pClient->Echo("PET ACTION RECIEVED: UNKNOWN!");

	// Defensive: flags=0x0002, flags2=0x0600
	// Passive: flags=0x0000, flags2=0x0600
	//
}


/*
WorldPacket data;
uint64 petGUID, TargetGUID;
uint16 flags, flags2;
recvPacket >> petGUID >> flags >> flags2;

Creature *Pet = objmgr.GetObject<Creature>(petGUID);
if(Pet == NULL)
{
Log::getSingleton().outError("Pet action not possible: Pet not found! guid %u", petGUID);
return;
}

Log::getSingleton().outDebug("Pet action called! flags=%u flags2=%u for guid=%u", flags, flags2, petGUID);
if(flags == 0x0002 && flags2 == 1792)
{ // ATTACK
recvPacket >> TargetGUID;
Unit *TargetUnit = objmgr.GetObject<Creature>(TargetGUID);
if(TargetUnit == NULL) TargetUnit = objmgr.GetObject<Player>(TargetGUID);
if(TargetUnit == NULL) return;

data.Initialize(SMSG_AI_REACTION);
data << petGUID << uint32(00000002);
SendPacket(&data);

Pet->AddHate(TargetUnit, 1.0f);
//Pet->AI_AttackReaction(world.GetCreature(unitTarget), 0); //TODO: find out if this is needed
}
else if(flags == 0x0001 && flags2 == 1792)
{ // FOLLOW
Unit *Owner = objmgr.GetObject<Creature>(Pet->GetUInt64Value(UNIT_FIELD_SUMMONEDBY));
if (Owner == NULL) Owner = objmgr.GetObject<Player>(Pet->GetUInt64Value(UNIT_FIELD_SUMMONEDBY));
if (Owner == NULL) return;

Pet->AI_Follow(Owner);

}
else if(flags == 0x0000 && flags2 == 1792)
{ // STAY
Pet->AI_StopFollow();
}
else if(flags2 == 256 || flags2 == 16640)
{
SpellEntry *proto = sSpellStore.LookupEntry( flags );
if (proto == NULL) return;

recvPacket >> TargetGUID;

Unit* unit_target = objmgr.GetObject<Creature>(TargetGUID);
if(unit_target == NULL) unit_target = objmgr.GetObject<Player>(TargetGUID);
if(unit_target)
{
//TODO:check if the minion is allowed and able to cast

Spell *spell = new Spell(Pet, proto, false, 0);
SpellCastTargets targets;
targets.m_unitTarget = TargetGUID;
spell->prepare(&targets);
}
}
else if(flags == 0x0003 && flags2 == 1792)
{
if(GetPlayer()->GetUInt64Value(UNIT_FIELD_SUMMON) != 0)//If there is already a summon
{
Creature *OldSummon = objmgr.GetObject<Creature>(petGUID);
if(!OldSummon)
{
GetPlayer()->SetUInt64Value(UNIT_FIELD_SUMMON, 0);
Log::getSingleton().outError("Warning!Summon could not be found!");
}
else
{
data.clear();
data.Initialize(SMSG_DESTROY_OBJECT);
data << OldSummon->GetGUID();
OldSummon->SendMessageToSet (&data, true);

//for (ObjectSet::iterator it = OldSummon->GetInRangeSetBegin(); it != OldSummon->GetInRangeSetEnd(); it++)
//Object *o;
//for (MapRangeIterator itr (OldSummon); o = itr.Advance(); )
//	o->RemoveInRangeObject (OldSummon);

if (OldSummon->GetMapCell())
{
OldSummon->GetMapCell()->RemoveObject (OldSummon);
//					OldSummon->GetMapCell()->RemoveInactive (OldSummon);
}

OldSummon->RemoveFromMap();
OldSummon->RemoveFromWorld();
OldSummon->DeleteFromDB();

objmgr.RemoveObject_Free(OldSummon);
GetPlayer()->SetUInt64Value(UNIT_FIELD_SUMMON, 0);
}
}

data.clear();
data.Initialize(SMSG_PET_SPELLS);
data << (uint64)0;
SendPacket(&data);
}*/
void MsgPetNameQuery(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long creatureguid;
	Data >> creatureguid;
	std::string petname;
	CCreature *pCreature;
	if(!DataManager.RetrieveObject((CWoWObject**)&pCreature, OBJ_CREATURE, creatureguid))
	{
		petname = "Creature not found";
	} else {
		petname = pCreature->summoner->Data.Name;
		petname += "'s bitch";
	}

	CPacket pkg;
	pkg.Reset(SMSG_PET_NAME_QUERY_RESPONSE);
	// pkg << (unsigned long)0x18088;
	/*pkg << (unsigned char)0x00;
	pkg << (unsigned char)0x0E;
	pkg << (unsigned char)0x53;
	pkg << (unsigned char)0x00;
	pkg << (unsigned char)0x44;
	pkg << (unsigned char)0x25;
	pkg << (unsigned char)0x2B;
	pkg << (unsigned char)0x00;*/
	Packets::PackGuid(pkg,pCreature->guid,CREATUREGUID_HIGH);
	/*pkg << (unsigned char)0xFF;
	pkg << pCreature->guid;
	pkg << CREATUREGUID_HIGH;*/
	pkg << petname.c_str();
	/*pkg << (unsigned char)0x00;
	pkg << (unsigned char)0x7D;
	pkg << (unsigned char)0xD4;
	pkg << (unsigned char)0xF1;
	pkg << (unsigned char)0x43;*/
	//pkg << (unsigned long)0x426D3DC6;
	pClient->Send(&pkg);
}
// This either needs to be absolute last in this file, or the functions need to have
// forward declarations.  To keep it cleaner, leave it last ;)
#define AddMsgHandler(opcode,function) handlers[opcode]=function;
void InstallMessageHandlers(fMessageHandler *handlers)
{
	AddMsgHandler(CMSG_PING,MsgPing);
	AddMsgHandler(CMSG_AUTH_SESSION,MsgAuth);
	AddMsgHandler(CMSG_CHAR_ENUM,MsgCharList);
	AddMsgHandler(CMSG_CHAR_CREATE,MsgCreateCharacter);
	AddMsgHandler(CMSG_CHAR_DELETE,MsgDeleteCharacter);
	AddMsgHandler(CMSG_PLAYER_LOGIN,MsgEnterGame);
}

void InstallGameMessageHandlers(fMessageHandler *handlers)
{
	AddMsgHandler(CMSG_PING, MsgPing);
	AddMsgHandler(CMSG_LOGOUT_REQUEST,MsgLogoutRequest);
	AddMsgHandler(CMSG_LOGOUT_CANCEL,MsgLogoutCancel);
	AddMsgHandler(CMSG_PLAYER_LOGOUT,MsgLogout);
	AddMsgHandler(CMSG_MESSAGECHAT,CChatManager::MsgChat);
	//AddMsgHandler(CMSG_WORLD_TELEPORT,MsgWorldPort);
	AddMsgHandler(MSG_MOVE_WORLDPORT_ACK,MsgLoadNewWorld);
	AddMsgHandler(CMSG_NAME_QUERY,MsgPlayerName);
	AddMsgHandler(CMSG_CREATURE_QUERY,MsgNPCName);
	AddMsgHandler(CMSG_ITEM_QUERY_SINGLE,MsgItem);
	AddMsgHandler(CMSG_GAMEOBJECT_QUERY, MsgGameObjectQuery);
	AddMsgHandler(CMSG_SET_SELECTION,MsgSetGameUiTarget);
	AddMsgHandler(CMSG_CAST_SPELL,CSpellHandler::MsgCastSpell);
	AddMsgHandler(CMSG_CANCEL_CAST,CSpellHandler::MsgCancelCast);
	AddMsgHandler(CMSG_USE_ITEM,CSpellHandler::MsgUseItem);
	AddMsgHandler(CMSG_ZONEUPDATE,MsgZone);
	AddMsgHandler(CMSG_AREATRIGGER,MsgAreaTrigger);
	AddMsgHandler(CMSG_TUTORIAL_CLEAR,MsgTutorialClear);
	AddMsgHandler(CMSG_QUERY_TIME,MsgTime);
	AddMsgHandler(CMSG_MOVE_TIME_SKIPPED,MsgMoveTimeSkipped);
	AddMsgHandler(MSG_MOVE_HEARTBEAT,MsgMove);
	AddMsgHandler(MSG_MOVE_JUMP, MsgMove);
	AddMsgHandler(MSG_MOVE_FALL_LAND, MsgFall);
	AddMsgHandler(MSG_MOVE_START_FORWARD,MsgMove);
	AddMsgHandler(MSG_MOVE_START_BACKWARD,MsgMove);
	AddMsgHandler(MSG_MOVE_SET_FACING,MsgMove);
	AddMsgHandler(MSG_MOVE_STOP,MsgMove);
	AddMsgHandler(MSG_MOVE_START_STRAFE_LEFT,MsgMove);
	AddMsgHandler(MSG_MOVE_START_STRAFE_RIGHT,MsgMove);
	AddMsgHandler(MSG_MOVE_STOP_STRAFE,MsgMove);
	AddMsgHandler(MSG_MOVE_START_TURN_LEFT,MsgMove);
	AddMsgHandler(MSG_MOVE_START_TURN_RIGHT,MsgMove);
	AddMsgHandler(MSG_MOVE_STOP_TURN,MsgMove);
	AddMsgHandler(MSG_MOVE_START_PITCH_UP, MsgMove);
	AddMsgHandler(MSG_MOVE_START_PITCH_DOWN, MsgMove);
	AddMsgHandler(MSG_MOVE_STOP_PITCH, MsgMove);
	AddMsgHandler(MSG_MOVE_SET_RUN_MODE, MsgMove);
	AddMsgHandler(MSG_MOVE_SET_WALK_MODE, MsgMove);
	AddMsgHandler(MSG_MOVE_SET_PITCH, MsgMove);
	AddMsgHandler(MSG_MOVE_START_SWIM, MsgMove);
	AddMsgHandler(MSG_MOVE_STOP_SWIM, MsgMove);
	AddMsgHandler(CMSG_LEARN_SPELL,MsgLearnSpell);
	AddMsgHandler(CMSG_TEXT_EMOTE,MsgEmote);
	AddMsgHandler(MSG_RANDOM_ROLL,MsgRoll);
	AddMsgHandler(CMSG_TOGGLE_PVP,MsgPvp);
	AddMsgHandler(CMSG_TOGGLE_HELM,MsgHelm);
	AddMsgHandler(CMSG_TOGGLE_CLOAK,MsgCloak);
	AddMsgHandler(CMSG_ATTACKSWING,MsgAttackSwing);
	AddMsgHandler(CMSG_ATTACKSTOP,MsgAttackOff);
	AddMsgHandler(CMSG_REPOP_REQUEST,MsgRepop);
	AddMsgHandler(CMSG_RESURRECT_RESPONSE,MsgResurrectResponse);
	AddMsgHandler(MSG_CORPSE_QUERY,MsgCorpseQuery);
	AddMsgHandler(CMSG_RECLAIM_CORPSE,MsgReclaimCorpse);
	AddMsgHandler(CMSG_LOOT,MsgLootUnit);
	AddMsgHandler(CMSG_LOOT_MONEY,MsgLootMoney);
	AddMsgHandler(CMSG_AUTOSTORE_LOOT_ITEM,MsgStoreLoot);
	AddMsgHandler(CMSG_LOOT_RELEASE,MsgLootResponse);
	//AddMsgHandler(CMSG_SETWEAPONMODE,MsgSetWeaponMode);
	AddMsgHandler(CMSG_STANDSTATECHANGE, MsgStandState);
	AddMsgHandler(CMSG_LIST_INVENTORY, MsgListInventory);
	AddMsgHandler(CMSG_BUY_ITEM, MsgBuyItem);
	AddMsgHandler(CMSG_BUY_ITEM_IN_SLOT, MsgBuyItem);
	AddMsgHandler(CMSG_BUYBACK_ITEM, MsgBuyBackItem);
	AddMsgHandler(CMSG_WHO, MsgWho);
	AddMsgHandler(CMSG_UPDATE_ACCOUNT_DATA, MsgUpdateAccountData);
	AddMsgHandler(CMSG_FRIEND_LIST, CClient::MsgSendFriendList);
	AddMsgHandler(CMSG_ADD_FRIEND, CClient::MsgAddFriend);
	AddMsgHandler(CMSG_DEL_FRIEND, CClient::MsgDelFriend);
	AddMsgHandler(CMSG_ADD_IGNORE, CClient::MsgAddIgnore);
	AddMsgHandler(CMSG_DEL_IGNORE, CClient::MsgDelIgnore);
	AddMsgHandler(CMSG_SET_ACTION_BUTTON, CClient::MsgSetActionButton);
	AddMsgHandler(CMSG_GROUP_INVITE, CParty::MsgGroupInvite);
	AddMsgHandler(CMSG_GROUP_CANCEL, CParty::MsgGroupCancel);
	AddMsgHandler(CMSG_GROUP_ACCEPT, CParty::MsgGroupAccept);
	AddMsgHandler(CMSG_GROUP_DECLINE, CParty::MsgGroupDecline);
	AddMsgHandler(CMSG_GROUP_UNINVITE, CParty::MsgGroupUninvite);
	AddMsgHandler(CMSG_GROUP_UNINVITE_GUID, CParty::MsgGroupUninviteGuid);
	AddMsgHandler(CMSG_GROUP_SET_LEADER, CParty::MsgGroupSetLeader);
	AddMsgHandler(CMSG_LOOT_METHOD, CParty::MsgLootMethod);
	AddMsgHandler(CMSG_GROUP_DISBAND, CParty::MsgGroupDisband);
	AddMsgHandler(CMSG_SET_LOOKING_FOR_GROUP,MsgLFG);
	AddMsgHandler(CMSG_GUILD_INVITE, CGuild::MsgGuildInvite);
	AddMsgHandler(CMSG_GUILD_ACCEPT, CGuild::MsgGuildAccept);
	AddMsgHandler(CMSG_GUILD_DECLINE, CGuild::MsgGuildDecline);
	AddMsgHandler(CMSG_GUILD_INFO, CGuild::MsgGuildInfo);
	AddMsgHandler(CMSG_GUILD_ROSTER, CGuild::MsgGuildRoster);
	AddMsgHandler(CMSG_GUILD_PROMOTE, CGuild::MsgGuildPromote);
	AddMsgHandler(CMSG_GUILD_DEMOTE, CGuild::MsgGuildDemote);
	AddMsgHandler(CMSG_GUILD_LEAVE, CGuild::MsgGuildLeave);
	AddMsgHandler(CMSG_GUILD_REMOVE, CGuild::MsgGuildRemove);
	AddMsgHandler(CMSG_GUILD_DISBAND, CGuild::MsgGuildDisband);
	AddMsgHandler(CMSG_GUILD_LEADER, CGuild::MsgGuildLeader);
	AddMsgHandler(CMSG_GUILD_MOTD, CGuild::MsgGuildMotd);
	AddMsgHandler(CMSG_GUILD_QUERY, CGuild::MsgGuildQuery);
	AddMsgHandler(CMSG_GUILD_RANK, CGuild::MsgGuildRank);
	AddMsgHandler(CMSG_GUILD_ADD_RANK, CGuild::MsgGuildAddRank);
	AddMsgHandler(CMSG_GUILD_DEL_RANK, CGuild::MsgGuildDelRank);
	AddMsgHandler(CMSG_GUILD_SET_PUBLIC_NOTE, CGuild::MsgPublicNote);
	AddMsgHandler(CMSG_GUILD_SET_OFFICER_NOTE, CGuild::MsgOfficerNote);
	AddMsgHandler(CMSG_PETITION_SHOWLIST, MsgPetitionShow);
	AddMsgHandler(MSG_TABARDVENDOR_ACTIVATE, CGuild::MsgTabardVendorActivate);
	AddMsgHandler(CMSG_BINDER_ACTIVATE, MsgBinderActivate);
	AddMsgHandler(MSG_SAVE_GUILD_EMBLEM, CGuild::MsgSaveGuildEmblem);
	AddMsgHandler(CMSG_DESTROYITEM, MsgDestroyItem);
	AddMsgHandler(CMSG_SWAP_ITEM, MsgSwapItem);
	AddMsgHandler(CMSG_SWAP_INV_ITEM, MsgSwapInvItem);
	AddMsgHandler(CMSG_AUTOEQUIP_ITEM, MsgAutoEquipItem);
	AddMsgHandler(CMSG_AUTOSTORE_BAG_ITEM, MsgAutoStoreBagItem);
	AddMsgHandler(CMSG_TAXINODE_STATUS_QUERY, MsgTaxiQueryStatus);
	AddMsgHandler(CMSG_TAXIQUERYAVAILABLENODES, MsgTaxiQueryNodes);
	AddMsgHandler(CMSG_ACTIVATETAXI, MsgTaxiActivate);
	AddMsgHandler(CMSG_QUESTGIVER_STATUS_QUERY, MsgQuestGiverQueryStatus);
	AddMsgHandler(CMSG_QUESTGIVER_HELLO, MsgQuestGiverHello);
	AddMsgHandler(CMSG_SELL_ITEM, MsgSellItem);
	AddMsgHandler(CMSG_TRAINER_LIST, MsgTrainerList);
	AddMsgHandler(CMSG_TRAINER_BUY_SPELL, MsgTrainerBuySpell);
	AddMsgHandler(CMSG_INITIATE_TRADE, MsgInitiateTrade);
	AddMsgHandler(CMSG_BEGIN_TRADE, MsgBeginTrade);
	AddMsgHandler(CMSG_UNACCEPT_TRADE, MsgUnAcceptTrade);
	AddMsgHandler(CMSG_ACCEPT_TRADE, MsgAcceptTrade);
	AddMsgHandler(CMSG_CANCEL_TRADE, MsgCancelTrade);
	AddMsgHandler(CMSG_SET_TRADE_GOLD, MsgSetTradeGold);
	AddMsgHandler(CMSG_SET_TRADE_ITEM, MsgSetTradeItem);
	AddMsgHandler(CMSG_CLEAR_TRADE_ITEM, MsgClearTradeItem);
	AddMsgHandler(CMSG_SETSHEATHED, MsgSetSheathed);
	AddMsgHandler(CMSG_GMTICKET_CREATE, MsgGMTicket);
	AddMsgHandler(CMSG_GMTICKET_SYSTEMSTATUS, MsgGMTicketSystemStatus);
	AddMsgHandler(CMSG_JOIN_CHANNEL,MsgChannelJoin);
	AddMsgHandler(CMSG_LEAVE_CHANNEL,MsgChannelLeave);
	AddMsgHandler(CMSG_CHANNEL_LIST,MsgChannelList);
	AddMsgHandler(CMSG_CHANNEL_PASSWORD,MsgChannelPassword);
	AddMsgHandler(CMSG_CHANNEL_SET_OWNER,MsgChannelSetOwner);
	AddMsgHandler(CMSG_CHANNEL_OWNER,MsgChannelOwner);
	AddMsgHandler(CMSG_CHANNEL_MODERATOR,MsgChannelModerator);
	AddMsgHandler(CMSG_CHANNEL_UNMODERATOR,MsgChannelUnmoderator);
	AddMsgHandler(CMSG_CHANNEL_MUTE,MsgChannelMute);
	AddMsgHandler(CMSG_CHANNEL_UNMUTE,MsgChannelUnmute);
	AddMsgHandler(CMSG_CHANNEL_INVITE,MsgChannelInvite);
	AddMsgHandler(CMSG_CHANNEL_KICK,MsgChannelKick);
	AddMsgHandler(CMSG_CHANNEL_BAN,MsgChannelBan);
	AddMsgHandler(CMSG_CHANNEL_UNBAN,MsgChannelUnban);
	AddMsgHandler(CMSG_CHANNEL_ANNOUNCEMENTS,MsgChannelAnnounce);
	AddMsgHandler(CMSG_CHANNEL_MODERATE,MsgChannelModerate);
	AddMsgHandler(CMSG_GOSSIP_HELLO,MsgGossipHello);
	AddMsgHandler(CMSG_NPC_TEXT_QUERY,MsgNpcTextQuery);
	AddMsgHandler(CMSG_GET_MAIL_LIST,MsgGetMailList);
	AddMsgHandler(CMSG_ITEM_TEXT_QUERY,MsgItemTextQuery);
	AddMsgHandler(CMSG_PAGE_TEXT_QUERY,MsgPageTextQuery);
	AddMsgHandler(CMSG_READ_ITEM,MsgReadItem);
	AddMsgHandler(CMSG_GAMEOBJ_USE,MsgGameObjectUse);
	AddMsgHandler(CMSG_SEND_MAIL,MsgSendMail);
	AddMsgHandler(CMSG_GMTICKET_GETTICKET,MsgGetTicket);
	AddMsgHandler(CMSG_MEETINGSTONE_INFO,MsgMeetStone);
	AddMsgHandler(CMSG_MAIL_MARK_AS_READ,MsgMailMarkAsRead);
	AddMsgHandler(CMSG_MAIL_TAKE_MONEY,MsgMailTakeMoney);
	AddMsgHandler(CMSG_MAIL_TAKE_ITEM,MsgMailTakeItem);
	//CMSG_MAIL_RETURN_TO_SENDER
	AddMsgHandler(CMSG_MAIL_DELETE,MsgMailDelete);
	//CMSG_MAIL_CREATE_TEXT_ITEM
	AddMsgHandler(MSG_QUERY_NEXT_MAIL_TIME,MsgQueryNextMailTime);
	AddMsgHandler(CMSG_QUESTGIVER_QUERY_QUEST, MsgQuestGiverQueryQuest);
	AddMsgHandler(CMSG_QUESTGIVER_ACCEPT_QUEST, MsgQuestGiverAcceptQuest);
	AddMsgHandler(CMSG_QUESTGIVER_COMPLETE_QUEST, MsgQuestGiverCompleteQuest);
	AddMsgHandler(CMSG_QUESTGIVER_CHOOSE_REWARD, MsgQuestGiverChooseReward);
	AddMsgHandler(CMSG_QUEST_QUERY, MsgQuestQuery);
	AddMsgHandler(CMSG_GOSSIP_SELECT_OPTION, MsgGossipSelectOption);
	AddMsgHandler(CMSG_SET_FACTION_ATWAR, SetFactionAtWar);
	AddMsgHandler(CMSG_SET_FACTION_CHEAT, SetFactionCheat);
	AddMsgHandler(CMSG_LEARN_TALENT, MsgLearnTalent);
	AddMsgHandler(CMSG_REPAIR_ITEM, MsgRepairItem);
	AddMsgHandler(CMSG_DUEL_ACCEPTED, CPlayer::AcceptDuel);
	AddMsgHandler(CMSG_PET_ACTION, MsgPetAction);
	AddMsgHandler(CMSG_PET_NAME_QUERY, MsgPetNameQuery);
	AddMsgHandler(CMSG_PETITION_BUY, MsgPetitionBuy);
	AddMsgHandler(CMSG_DUEL_CANCELLED, CPlayer::CancelDuel);
	AddMsgHandler(MSG_TALENT_WIPE_CONFIRM, CPlayer::MsgTalentReset);
	AddMsgHandler(CMSG_CANCEL_AURA, MsgCancelAura);
}
#undef AddMsgHandler
