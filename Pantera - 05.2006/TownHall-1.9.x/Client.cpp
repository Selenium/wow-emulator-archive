#include "Client.h"
#include "Globals.h"
#include "Creature.h"
#include "Guild.h"
#include "Party.h"
#include "ChatManager.h"
#include "GameObject.h"
#include "MsgHandlers.h"
#include "Packets.h"
#include "DynamicObject.h"
extern fMessageHandler LoginMessageHandlers[];

#define ColorMsg(string,alpha,red,green,blue) "|c" #alpha #red #green #blue #string "|r"

#define COMPRESSED_PLYR_PACKETS 1

CClient::CClient(void)
{
	MessageHandlers = LoginMessageHandlers;
	DataPending.Size=0;
	DataPending.buffer=(char*)malloc(0x4000);
	DestroyMe=false;
	LoggingOut=false;
	LoggedInAndResting=false;
	NextLength=0;
	NextOpCode=0;
	nCharacters=0;
	pPlayer=0;
	pAccount=0;
	LastCast=0;
	memset(&Characters[0],0,sizeof(CPlayer *)*10);
}

CClient::~CClient(void)
{
	if (pPlayer)
	{
		list<CChannel *>::iterator i;
		pPlayer->EventsEligible=false;
		pPlayer->ClearEvents();
		for(i = pPlayer->m_channels.begin(); i != pPlayer->m_channels.end(); i++)
			(*i)->Leave(pPlayer,false);
		pPlayer->m_channels.clear();
		//RegionManager.ObjectRemove(*pPlayer); //no, please no...this ruins the social stuff!
		pPlayer->pClient=0;
	}
	if (pAccount)
	{
		pAccount->pClient=0;
		pAccount=0;
	}
	while(!Outgoing.Empty())
	{
		_OutData Data=Outgoing.Pop();
		free(Data.buffer);
	}
	DataPending.Size=0;
	if (DataPending.buffer)
	{
		free(DataPending.buffer);
		DataPending.buffer=0;
	}
}

void CClient::Send(IPacket *pkg)
{
	_OutData Data;
	Data.Size = pkg->GetLength();
	Data.buffer=(char*)malloc(Data.Size);
	memcpy(Data.buffer, pkg->GetData(), Data.Size);
	Outgoing.Push(Data);
}

void CClient::SendRegion(IPacket *pkg)
{
	CRegion *pPlayerRegion=RegionManager.ObjectRegions[pPlayer->guid];
	if (!pPlayerRegion)
	{
		Send(pkg);
		return;
	}
	for (int i = 0 ; i < 3 ; i++)
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if(pNode->pObject->type == OBJ_PLAYER && (((CPlayer*)pNode->pObject)->pClient))
						((CPlayer*)pNode->pObject)->pClient->Send(pkg);
					pNode=pNode->pNext;
				}
			}
		}
}


void CClient::SendRegion(IPacket *pkg, float maxdist)
{
	CRegion *pPlayerRegion=RegionManager.ObjectRegions[pPlayer->guid];
	if (!pPlayerRegion)
	{
		Send(pkg);
		return;
	}
	for (int i = 0 ; i < 3 ; i++)
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if(pNode->pObject->type == OBJ_PLAYER && pPlayer->Distance(*((CPlayer*)pNode->pObject))<maxdist && (((CPlayer*)pNode->pObject)->pClient))
						((CPlayer*)pNode->pObject)->pClient->Send(pkg);
					pNode=pNode->pNext;
				}
			}
		}
}

void CClient::SendRegionNotMe(IPacket *pkg)
{
	CRegion *pPlayerRegion=RegionManager.ObjectRegions[pPlayer->guid];
	if (!pPlayerRegion)
	{
		return;
	}
	for (int i = 0 ; i < 3 ; i++)
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if(pNode->pObject->type == OBJ_PLAYER && pNode->pObject->guid != pPlayer->guid && (((CPlayer*)pNode->pObject)->pClient))
						((CPlayer*)pNode->pObject)->pClient->Send(pkg);
					pNode=pNode->pNext;
				}
			}
		}
}


void CClient::SendRegionNotMe(IPacket *pkg, float maxdist)
{
	CRegion *pPlayerRegion=RegionManager.ObjectRegions[pPlayer->guid];
	if (!pPlayerRegion)
	{
		return;
	}
	for (int i = 0 ; i < 3 ; i++)
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if(pNode->pObject->type == OBJ_PLAYER && pNode->pObject->guid != pPlayer->guid && (((CPlayer*)pNode->pObject)->pClient) && pPlayer->Distance(*((CPlayer*)pNode->pObject))<maxdist)
						((CPlayer*)pNode->pObject)->pClient->Send(pkg);
					pNode=pNode->pNext;
				}
			}
		}
}

void CClient::OutPacket(unsigned short OpCode, const void *buffer, unsigned short Length)
{
	_OutData Data;
	Data.buffer=(char*)malloc(Length+4);// length + opcode + state (was 6)
	*(unsigned short*)&Data.buffer[0]=ntohs(Length+2); // was 4
	*(unsigned short*)&Data.buffer[2]=OpCode;
	if (Length)
		memcpy(&Data.buffer[4],buffer,Length); //was 6
	Data.Size=Length+4; // was 6
	Outgoing.Push(Data);
}

void CClient::RegionOutPacket(unsigned short OpCode, void *buffer, unsigned short Length)
{
	CRegion *pPlayerRegion=RegionManager.ObjectRegions[pPlayer->guid];
	if (!pPlayerRegion)
	{
		OutPacket(OpCode, buffer, Length);
		return;
	}
	for (int i = 0 ; i < 3 ; i++)
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if(pNode->pObject->type == OBJ_PLAYER && (((CPlayer*)pNode->pObject)->pClient))
						((CPlayer*)pNode->pObject)->pClient->OutPacket(OpCode,buffer,Length);
					pNode=pNode->pNext;
				}
			}
		}
}

void CClient::RegionOutPacket(unsigned short OpCode, void *buffer, unsigned short Length, float maxdist)
{
	CRegion *pPlayerRegion=RegionManager.ObjectRegions[pPlayer->guid];
	if (!pPlayerRegion)
	{
		OutPacket(OpCode, buffer, Length);
		return;
	}
	for (int i = 0 ; i < 3 ; i++)
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if(pNode->pObject->type == OBJ_PLAYER && (((CPlayer*)pNode->pObject)->pClient) && pPlayer->Distance(*((CPlayer*)pNode->pObject))<maxdist)
						((CPlayer*)pNode->pObject)->pClient->OutPacket(OpCode,buffer,Length);
					pNode=pNode->pNext;
				}
			}
		}
}

void CClient::RegionOutPacketNotMe(unsigned short OpCode, void *buffer, unsigned short Length)
{
	CRegion *pPlayerRegion=RegionManager.ObjectRegions[pPlayer->guid];
	if (!pPlayerRegion)
		return;
	for (int i = 0 ; i < 3 ; i++)
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if(pNode->pObject->type == OBJ_PLAYER && (((CPlayer*)pNode->pObject)->pClient) && ((CPlayer*)pNode->pObject)->pClient!=this)
						((CPlayer*)pNode->pObject)->pClient->OutPacket(OpCode,buffer,Length);
					pNode=pNode->pNext;
				}
			}
		}
}

void CClient::RegionOutPacketNotMe(unsigned short OpCode, void *buffer, unsigned short Length, float maxdist)
{
	CRegion *pPlayerRegion=RegionManager.ObjectRegions[pPlayer->guid];
	if (!pPlayerRegion)
		return;
	for (int i = 0 ; i < 3 ; i++)
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if(pNode->pObject->type == OBJ_PLAYER && (((CPlayer*)pNode->pObject)->pClient) && ((CPlayer*)pNode->pObject)->pClient!=this &&
						pPlayer->Distance(*((CPlayer*)pNode->pObject))<maxdist)
						((CPlayer*)pNode->pObject)->pClient->OutPacket(OpCode,buffer,Length);
					pNode=pNode->pNext;
				}
			}
		}
}

void CClient::SendCharacterList()
{
	// Burlex: Addons! xD
	CPacket pkg;
	pkg.Reset(SMSG_ADDON_INFO);
	pkg << (unsigned char)10;
	for (int l=0;l<10;l++)
		pkg << (unsigned char)0x02 << (unsigned char)0x01 << (unsigned short)0x00 << (unsigned long)0x00;
	Send(&pkg);

	char buffer[0x700];
	memset(buffer,0,0x700);
	int c=0;
	buffer[c++]=(unsigned char)nCharacters;
	nCharacters=0;
	for (int i = 0 ; i < 10 ; i++)
	{
		CPlayer *pChar=Characters[i];
		if (pChar)
		{
			// because this ID is only used for entering the world,
			// we can have it correspond to the number of character in our list. this way,
			// we dont have to look for it later ;)
			*(unsigned long*)&buffer[c]=i+1;// guid 0 not allowed
			c+=4;
			c+=4;
			c+=pChar->GetCharListData(&buffer[c]);
			nCharacters++;
		}
	}
	buffer[0]=(unsigned char)nCharacters;
	OutPacket(SMSG_CHAR_ENUM,buffer,c);
}

void CClient::EnterGame(unsigned long nCharacter)
{
	LastMoveFlags=0xFFFFFFFF;
	pPlayer=Characters[nCharacter-1];
	if (!pPlayer)
		return;
	pDataObject = &pPlayer->DataObject;
	pPlayer->EventsEligible=true;
	pPlayer->pClient=this;
	pPlayer->ResetFlags();
	CDataBuffer empty;
	SendChatBox();
	MsgSendFriendList(this,CMSG_FRIEND_LIST,empty);
	int k=0;

	while(pPlayer->Data.ExtFriends[k])
	{
		CPlayer *pFriend=0;
		if (DataManager.RetrieveObject((CWoWObject**)&pFriend,OBJ_PLAYER,pPlayer->Data.ExtFriends[k]))
		{
			if(pFriend->pClient)
			{
				CPacket pkg;
				pkg.Reset(SMSG_FRIEND_STATUS);
				pkg << (char)FRIEND_ONLINE;
				Packets::PackGuid(pkg,pPlayer->guid,PLAYERGUID_HIGH);
				pFriend->pClient->Send(&pkg);
			}
		}
		k++;
	}
	MsgSendIgnoreList(this,0,empty);
	pPlayer->duelhost = NULL;
	pPlayer->duelpartner = NULL;
	pPlayer->DuelGuid =0;
	pPlayer->DGuid2 = 0;
	pPlayer->duelstarted = 0;
	GuildInviteID = 0;
	GuildInvitee = 0;

	PartyInviteID = 0;
	PartyInvitee = 0;
	pPlayer->Data.PartyID = 0;
	pPlayer->Data.PartyRank = 0;

	pPlayer->Data.LastLogon=time(0);
	CPacket pkg;
	pkg.Reset(SMSG_SET_REST_START);
	pkg << (long) 0x446;
	Send(&pkg);
	SaveBindPoint();
	SendBuffBar();
	SendBuffBar();
	SendTutorialFlags();
	SendInitialSpells();
	SendActionButtons();
	SendFactionData();
	SendCastResult();
	SendTimeSpeed();
	//SendKeyBindings();
	//SendProficiencies();
	pPlayer->SetFaction();
	//SendContainers();
	//SendItems();
	SendPlayerData(true);
	if (pPlayer->Data.bDead)
	{
		pPlayer->CreateGhost();
		if(pPlayer->Data.CorpseLoc.X && pPlayer->Data.CorpseLoc.Y && pPlayer->Data.CorpseLoc.Z)
		{
			pPlayer->CreateCorpse();
		}
	}

	/*RECV   2312 <- 12.129.233.32:8087 UNKNOWN(0x211) Length = 0x4
	0000   55 75 82 40                                         Uu.@
	RECV   2312 <- 12.129.233.32:8087 SMSG_BINDPOINTUPDATE(0x148) Length = 0x14
	0000   48 59 36 C5 71 FD 80 C3   B9 FC 53 42 01 00 00 00   HY6.q.....SB....
	0010   00 00 00 00                                         ....
	RECV   2312 <- 12.129.233.32:8087 SMSG_EXPLORATION_EXPERIENCE(0x1E9) Length = 0x8
	0000   DD 00 00 00 00 00 00 00                             ........
	*/
	pPlayer->InCombat = false;
	// Rage degeneration

	if (pPlayer->Data.Class == CLASS_WARRIOR)
	{
		int duration = 3000;
		EventManager.AddEvent(*pPlayer, 3000, EVENT_PLAYER_RAGEDEGENERATE, &duration, sizeof(duration));
	}
	/*
	Echo(ColorMsg(Welcome to %s,FF,FF,00,00)", running "ColorMsg(Pantera Server %s,FF,00,FF,00),RealmServer.Name,TOWNHALL_VERSION);
	Echo("This server is run by %s and allows up to %d simultaneous connections.",Settings.server_owner,Settings.max_connections);
	Echo("There are %d users connected, and this server has handled up to %d simultaneous users this session.",RealmServer.nClients,RealmServer.nMaxClients);
	Echo("%s",Settings.server_welcome_message);
	*/
	Echo("Welcome to World of Warcraft!");
	if(pPlayer->Data.GuildID != 0)
	{
		CGuild *pGuild = NULL;
		if(DataManager.RetrieveObject((CWoWObject**)&pGuild, OBJ_GUILD, pPlayer->Data.GuildID))
		{
			pGuild->ShowMotd(this);
		}
		else
		{
			pDataObject->SetGuildID(0);
			pDataObject->SetGuildRank(0);
			pDataObject->SetGuildTimestamp(0);
			pPlayer->Data.GuildOfficerNote[0]=0;
			pPlayer->Data.GuildPublicNote[0]=0;
			UpdateObject();
		}
	}

	RegionManager.ObjectNew(*pPlayer,pPlayer->Data.Continent,pPlayer->Data.Loc.X,pPlayer->Data.Loc.Y);

	pPlayer->isregenning = true;
	EventManager.AddEvent(*pPlayer,2000,EVENT_PLAYER_REGENERATE,0,0); //every two seconds
	EventManager.AddEvent(*pPlayer,600000,EVENT_PLAYER_SAVE,0,0);

	/* TODO: Reenable this upon release!
	if(!pPlayer->Data.PlayedIntro)
	{
	pPlayer->Data.PlayedIntro = 1;
	OutPacket(SMSG_TRIGGER_CINEMATIC, &RaceStartingPoints[pPlayer->Data.Race].Intro, 4);
	}*/
	LoggedInAndResting=false;
	if(pPlayer->Data.StatusFlags & STATUS_ZZZZ)
	{
		RestStart();
		LoggedInAndResting=true;
	}
	else RestStop(); // in case they are resting in the wilderness
	pPlayer->bIsFlying = false;

	pPlayer->ResetAllAuras();

	pPlayer->LoadExploreSystem();
	pPlayer->InitAEvents();
	pPlayer->ClearNextAttackSpell();
}

void CClient::LearnedSpell(unsigned long ID)
{
	if (pPlayer->ValidateSpell(0,(short)ID))
		OutPacket(SMSG_LEARNED_SPELL,&ID,4);
	else
		Echo("You do not have the knowledge to learn this spell or ability");
}

void CClient::RestStart()
{
	pDataObject->SetFlag(STATUS_ZZZZ);
	pDataObject->SetRestState(RESTEDSTATE_RESTED);
	unsigned long time_to_rest=1000*6*48; //4.8 minutes
	EventManager.AddEvent(*pPlayer,time_to_rest,EVENT_PLAYER_REST,&time_to_rest,sizeof(time_to_rest));
	UpdateObject();
}

void CClient::RestStop()
{
	if(LoggedInAndResting) //temp flag to prevent one-time disabling right after login
	{
		LoggedInAndResting=false;
		return;
	}
	if(pPlayer->Data.StatusFlags & STATUS_ZZZZ)
	{
		pDataObject->ClearFlag(STATUS_ZZZZ);
		UpdateObject();
	}
	pPlayer->ClearEvents(EVENT_PLAYER_REST);
}

void CClient::SendChatBox()
{
	unsigned char buf[0x50]={0};
	OutPacket(SMSG_ACCOUNT_DATA_MD5,buf,0x50);
}

void CClient::MsgSendIgnoreList(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CPacket pkg;
	pkg.Reset(SMSG_IGNORE_LIST);
	int count=0;
	while(pClient->pPlayer->Data.Ignore[count]) count++;
	pkg << (char)count;
	for(int i=0;i<count;i++)
	{
		//pkg << (unsigned char)0xFF << pClient->pPlayer->Data.Ignore[i] << PLAYERGUID_HIGH;
		Packets::PackGuid(pkg,pClient->pPlayer->Data.Ignore[i],PLAYERGUID_HIGH);
	}
	pClient->Send(&pkg);
}

void CClient::MsgAddIgnore(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	int count=0;
	CPacket pkg;
	pkg.Reset(SMSG_FRIEND_STATUS); // not sure
	string Who=Data.Buffer();
	MakeLower(Who);
	unsigned long PlayerID=DataManager.PlayerNames[Who];
	if (!PlayerID)
	{
		pkg << (char)FRIEND_IGNORE_NOT_FOUND << PlayerID << PLAYERGUID_HIGH;
		pClient->Send(&pkg);
		return;
	}
	if (PlayerID==pClient->pPlayer->guid)
	{
		pkg << (char)FRIEND_IGNORE_SELF << PlayerID << PLAYERGUID_HIGH;
		pClient->Send(&pkg);
		return;
	}
	while(pClient->pPlayer->Data.Ignore[count])
	{
		if(pClient->pPlayer->Data.Ignore[count]==PlayerID)
		{
			pkg << (char)FRIEND_IGNORE_ALREADY << PlayerID << PLAYERGUID_HIGH;
			pClient->Send(&pkg);
			return;
		}
		count++;
	}
	if(count>=20)
	{
		pkg << (char)FRIEND_IGNORE_FULL << PlayerID << PLAYERGUID_HIGH;
		pClient->Send(&pkg);
		return;
	}
	CPlayer *pIgnore=0;
	if (!DataManager.RetrieveObject((CWoWObject**)&pIgnore,OBJ_PLAYER,PlayerID))
	{
		pkg << (char)FRIEND_IGNORE_NOT_FOUND << PlayerID << PLAYERGUID_HIGH;
		pClient->Send(&pkg);
		return;
	}
	pClient->pPlayer->Data.Ignore[count]=PlayerID; //already figured out last pos from above
	count=0;
	while(pIgnore->Data.ExtIgnore[count])
	{
		if(pIgnore->Data.ExtIgnore[count]==pClient->pPlayer->guid) break;
		count++;
	}
	pIgnore->Data.ExtIgnore[count]=pClient->pPlayer->guid;
	pkg << (char)FRIEND_IGNORE_ADDED << PlayerID << PLAYERGUID_HIGH;
	pClient->Send(&pkg);
	CClient::MsgSendIgnoreList(pClient, msgID, Data);
}

void CClient::MsgDelIgnore(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long PlayerID;
	Data >> PlayerID;
	int count=0;
	CPlayer *pIgnore=0;
	if (DataManager.RetrieveObject((CWoWObject**)&pIgnore,OBJ_PLAYER,PlayerID))
	{
		while(pIgnore->Data.ExtIgnore[count])
		{
			if(pIgnore->Data.ExtIgnore[count]==pClient->pPlayer->guid)
			{
				pIgnore->Data.ExtIgnore[count]=0;
				break;
			}
			count++;
		}
		while(pIgnore->Data.ExtIgnore[count+1])
		{
			pIgnore->Data.ExtIgnore[count]=pIgnore->Data.ExtIgnore[count+1];
			count++;
		}
		pIgnore->Data.ExtIgnore[count+1]=0;
	}
	count=0;
	while(pClient->pPlayer->Data.Ignore[count])
	{
		if(pClient->pPlayer->Data.Ignore[count]==PlayerID)
		{
			pClient->pPlayer->Data.Ignore[count]=0;
			break;
		}
		count++;
	}
	while(pClient->pPlayer->Data.Ignore[count+1])
	{
		pClient->pPlayer->Data.Ignore[count]=pClient->pPlayer->Data.Ignore[count+1];
		count++;
	}
	pClient->pPlayer->Data.Ignore[count+1]=0;
	CPacket pkg;
	pkg.Reset(SMSG_FRIEND_STATUS); // not sure
	pkg << (char)FRIEND_IGNORE_ADDED << PlayerID << PLAYERGUID_HIGH;
	pClient->Send(&pkg);
	CClient::MsgSendIgnoreList(pClient, msgID, Data);
}

void CClient::MsgSendFriendList(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CPacket pkg;
	pkg.Reset(SMSG_FRIEND_LIST);
	int count=0;
	while(pClient->pPlayer->Data.Friends[count]) count++;
	pkg << (char)count;
	for(int i=0;i<count;i++)
	{
		CPlayer *pFriend=0;
		Packets::PackGuid(pkg,pClient->pPlayer->Data.Friends[i],PLAYERGUID_HIGH);
		if (!DataManager.RetrieveObject((CWoWObject**)&pFriend,OBJ_PLAYER,pClient->pPlayer->Data.Friends[i]))
		{
			pkg << (char)0;
			continue;
		}
		if (!pFriend->pClient)
		{
			pkg << (char)0;
			continue;
		}
		pkg << (char)1;
		pkg << (unsigned long)pFriend->Data.Zone << (unsigned long)pFriend->Data.Level << (unsigned long)pFriend->Data.Class;
	}
	pClient->Send(&pkg);
}

void CClient::MsgAddFriend(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	int result=FRIEND_NOT_FOUND;
	int count=0;
	CPacket pkg;
	pkg.Reset(SMSG_FRIEND_STATUS);
	string Who=Data.Buffer();
	MakeLower(Who);
	unsigned long PlayerID=DataManager.PlayerNames[Who];
	if (!PlayerID)
	{
		result=FRIEND_NOT_FOUND;
		pkg << (char)result << PlayerID << PLAYERGUID_HIGH;
		pClient->Send(&pkg);
		return;
	}
	while(pClient->pPlayer->Data.Friends[count])
	{
		if(pClient->pPlayer->Data.Friends[count]==PlayerID)
		{
			result=FRIEND_ALREADY;
			pkg << (char)result << PlayerID << PLAYERGUID_HIGH;
			pClient->Send(&pkg);
			return;
		}
		count++;
	}
	if(count>=20)
	{
		result=FRIEND_LIST_FULL;
		pkg << (char)result << PlayerID << PLAYERGUID_HIGH;
		pClient->Send(&pkg);
		return;
	}
	CPlayer *pFriend=0;
	if (!DataManager.RetrieveObject((CWoWObject**)&pFriend,OBJ_PLAYER,PlayerID))
	{
		result=FRIEND_NOT_FOUND;
		pkg << (char)result << PlayerID << PLAYERGUID_HIGH;
		pClient->Send(&pkg);
		return;
	}
	if (!pFriend->pClient) result=FRIEND_ADDED_OFFLINE;
	else result=FRIEND_ADDED_ONLINE;
	if(PlayerID==pClient->pPlayer->guid) result=FRIEND_SELF;
	if (!strcmp(pFriend->Data.Name,pClient->pPlayer->Data.Name)) result=FRIEND_SELF;
	pkg << (char)result << PlayerID << PLAYERGUID_HIGH;
	if (result ==  FRIEND_ADDED_ONLINE || result == FRIEND_ONLINE || result ==  FRIEND_OFFLINE)
		pkg << (unsigned long)pFriend->Data.Zone << (unsigned long)pFriend->Data.Level << (unsigned long)pFriend->Data.Class;
	pClient->Send(&pkg);
	if(result!=FRIEND_SELF)
	{
		pClient->pPlayer->Data.Friends[count]=PlayerID; //already figured out last pos from above
		count=0;
		while(pFriend->Data.ExtFriends[count])
		{
			if(pFriend->Data.ExtFriends[count]==pClient->pPlayer->guid) break;
			count++;
		}
		pFriend->Data.ExtFriends[count]=pClient->pPlayer->guid;
	}
	CClient::MsgSendFriendList(pClient, msgID, Data);
}

void CClient::MsgDelFriend(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long PlayerID;
	Data >> PlayerID;
	CPacket pkg;
	pkg.Reset(SMSG_FRIEND_STATUS);
	pkg << (char)FRIEND_REMOVED << PlayerID << PLAYERGUID_HIGH;
	pClient->Send(&pkg);
	int count=0;
	CPlayer *pFriend=0;
	if (DataManager.RetrieveObject((CWoWObject**)&pFriend,OBJ_PLAYER,PlayerID))
	{
		while(pFriend->Data.ExtFriends[count])
		{
			if(pFriend->Data.ExtFriends[count]==pClient->pPlayer->guid)
			{
				pFriend->Data.ExtFriends[count]=0;
				break;
			}
			count++;
		}
		while(pFriend->Data.ExtFriends[count+1])
		{
			pFriend->Data.ExtFriends[count]=pFriend->Data.ExtFriends[count+1];
			count++;
		}
		pFriend->Data.ExtFriends[count+1]=0;
	}
	count=0;
	while(pClient->pPlayer->Data.Friends[count])
	{
		if(pClient->pPlayer->Data.Friends[count]==PlayerID)
		{
			pClient->pPlayer->Data.Friends[count]=0;
			break;
		}
		count++;
	}
	while(pClient->pPlayer->Data.Friends[count+1])
	{
		pClient->pPlayer->Data.Friends[count]=pClient->pPlayer->Data.Friends[count+1];
		count++;
	}
	pClient->pPlayer->Data.Friends[count+1]=0;
	CClient::MsgSendFriendList(pClient, msgID, Data);
}

void CClient::SendKeyBindings()
{
	char buf2[2048]; // was uncommented
	*(unsigned long*)&buf2[0x00] = 0;
	memcpy(&buf2[4],pPlayer->Data.AccountData0,pPlayer->Data.AccountDataLen[0]+4);
	OutPacket(SMSG_UPDATE_ACCOUNT_DATA,buf2,pPlayer->Data.AccountDataLen[0]+8);
	*(unsigned long*)&buf2[0x00] = 1;
	memcpy(&buf2[4],pPlayer->Data.AccountData1,pPlayer->Data.AccountDataLen[1]+4);
	OutPacket(SMSG_UPDATE_ACCOUNT_DATA,buf2,pPlayer->Data.AccountDataLen[1]+8);
	*(unsigned long*)&buf2[0x00] = 2;
	memcpy(&buf2[4],pPlayer->Data.AccountData2,pPlayer->Data.AccountDataLen[2]+4);
	OutPacket(SMSG_UPDATE_ACCOUNT_DATA,buf2,pPlayer->Data.AccountDataLen[2]+8);
	*(unsigned long*)&buf2[0x00] = 3;
	memcpy(&buf2[4],pPlayer->Data.AccountData3,pPlayer->Data.AccountDataLen[3]+4);
	OutPacket(SMSG_UPDATE_ACCOUNT_DATA,buf2,pPlayer->Data.AccountDataLen[3]+8);
	*(unsigned long*)&buf2[0x00] = 4;
	memcpy(&buf2[4],pPlayer->Data.AccountData4,pPlayer->Data.AccountDataLen[4]+4);
	OutPacket(SMSG_UPDATE_ACCOUNT_DATA,buf2,pPlayer->Data.AccountDataLen[4]+8);
}

void CClient::SendTutorialFlags()
{
	OutPacket(SMSG_TUTORIAL_FLAGS,&pPlayer->Data.TutorialFlags,sizeof(_TutorialFlags));
}

void CClient::SendInitialSpells()
{
	CPacket pkg;
	pkg.Reset(SMSG_INITIAL_SPELLS);
	pkg << (char)1;
	unsigned short numspells=0;
	while(pPlayer->Data.Spells[numspells]) numspells++;
	pkg << (unsigned short)numspells;
	for(short i=0;i<numspells;i++)
	{
		pkg << (unsigned short)(pPlayer->Data.Spells[i]);
		pkg << (unsigned short)(i+1);
	}
	pkg << (short)0;
	Send(&pkg);
}

void CClient::SendBuffBar()
{
	unsigned char buf[5]={0,0,0,0,0};
	OutPacket(SMSG_UPDATE_AURA_DURATION,buf,0x5);
}

void CClient::SendCastResult()
{
	unsigned char buf[5]={0x44,0x03,0x00,0x00,0x00};
	OutPacket(SMSG_CAST_RESULT,buf,0x5);
}

void CClient::MsgSetActionButton(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned char button,misc,type;
	unsigned short action;
	Data >> button >> action >> misc >> type;
	if(button>=120) return;
	if(action==0) memset(&(pClient->pPlayer->Data.ActionButtons[button]),0,4);
	else
	{
		pClient->pPlayer->Data.ActionButtons[button].action=action;
		pClient->pPlayer->Data.ActionButtons[button].misc=misc;
		pClient->pPlayer->Data.ActionButtons[button].type=type;
	}
}

void CClient::SendActionButtons()
{
	CPacket pkg;
	pkg.Reset(SMSG_ACTION_BUTTONS);
	for(int i=0;i<120;i++)
	{
		if(pPlayer->Data.ActionButtons[i].action || pPlayer->Data.ActionButtons[i].type || pPlayer->Data.ActionButtons[i].misc)
			pkg << (unsigned short)pPlayer->Data.ActionButtons[i].action\
			<< (unsigned char)pPlayer->Data.ActionButtons[i].misc\
			<< (unsigned char)pPlayer->Data.ActionButtons[i].type;
		else pkg << (unsigned long)0;
	}
	Send(&pkg);
}

void CClient::SendFactionData()
{
	CPacket pkg;
	pkg.Reset(SMSG_INITIALIZE_FACTIONS);
	pkg << (unsigned long)FACTION_ARRAY_COUNT;
	for(int a=0; a<FACTION_ARRAY_COUNT; a++)
	{
		pkg << (unsigned char)pPlayer->Data.factionlist[a].Flags;
		pkg << (unsigned long)pPlayer->Data.factionlist[a].Standing;
	}
	Send(&pkg);
}

void CClient::SendTimeSpeed()
{
	/*
	DIRECTION UNKNOWN Data len=000C op=0042 int=0000 msglen=0008 -- NewTimeSpeed
	0000:  DB 53 01 04-89 88 88 3C-           -             ¦S..ëêê<
	*/
	unsigned char buf[8];
	tm t;
	mktime(&t);
	time_t timer = time(0);
	tm *date = localtime(&timer);
	int gametime = date->tm_year-100;
	gametime <<= 4;
	gametime |= date->tm_mon;
	gametime <<= 6;
	gametime |= date->tm_mday;
	gametime <<= 3;
	gametime |= date->tm_wday;
	gametime <<= 5;
	gametime |= date->tm_hour;
	gametime <<= 6;
	gametime |= date->tm_min;
	float minutesPerSecond = 1.0f/60.0f;
	*(int*)buf = gametime;
	*(float*)&buf[4] = minutesPerSecond;
	OutPacket(SMSG_LOGIN_SETTIMESPEED,(char*)&buf[0],8);
}

void CClient::SendPlayerData(bool Create)
{
	// first, items:
	char buffer[0x1000];
	memset(buffer, 0, 0x1000);
	buffer[0] = 1; // amount of updates?
	buffer[4] = 0;
	buffer[5] = 2*Create+1;
	int oSize = pPlayer->GetPlayerInfoData(&buffer[6], true, Create)+6;
#if COMPRESSED_PLYR_PACKETS
	int nSize = Compressor.Deflate(buffer, oSize);
	if (!nSize)
	{
		Debug.Log("CClient::SendPlayerData() - Deflate failed\n");
		return;
	}

	char *buf=(char*)malloc(nSize+4);
	*(unsigned long*)&buf[0]=oSize;
	Compressor.GetBuffer(&buf[4]);
	OutPacket(SMSG_COMPRESSED_UPDATE_OBJECT,buf,nSize+4);
	free(buf);
#else
	OutPacket(SMSG_UPDATE_OBJECT,buffer,oSize);
#endif

	if (Create)
	{
		for (unsigned long i = 0 ; i < 39 ; i++)
		{
//			if (unsigned long ItemID=pPlayer->Data.Items[i])
			if (CItem *pItem = pPlayer->Data.Items[i])
			{
//				CItem *pItem=0;
//				if (DataManager.RetrieveObject((CWoWObject**)&pItem,OBJ_ITEM,ItemID))
//				{
//					if (pItem == NULL)
//						continue;
					if (pItem->Data.Owner == 0)
						continue;

					AddKnownItem(*pItem);  // 1
					//pPlayer->Data.Items[i]=0;
/*				}
				else
				{
					// error... client will crash if we dont clear this.
					pPlayer->Data.Items[i]=0;
				}*/
			}
		}
	}
}

void CClient::CompleteLogout()
{
	if (pPlayer)
	{
		ClearTradeSettings(this,true);
		//pPlayer->EventsEligible=false;
		CParty *pParty = CParty::GetParty(this,false);
		if (pParty != NULL)
		{
			pParty->Leave(pPlayer->Data.Name);
			pPlayer->Data.PartyID = 0;
		}
		int k=0;
		while(pPlayer->Data.ExtFriends[k])
		{
			CPlayer *pFriend=0;
			if (DataManager.RetrieveObject((CWoWObject**)&pFriend,OBJ_PLAYER,pPlayer->Data.ExtFriends[k]))
			{
				if(pFriend->pClient)
				{
					CPacket pkg;
					pkg.Reset(SMSG_FRIEND_STATUS);
					pkg << (char)FRIEND_OFFLINE << pPlayer->guid << PLAYERGUID_HIGH;
					pFriend->pClient->Send(&pkg);
					//pFriend->pClient->Echo("%s has gone offline.",pPlayer->Data.Name);
				}
			}
			k++;
		}
		list<CChannel *>::iterator i;
		for(i = pPlayer->m_channels.begin(); i != pPlayer->m_channels.end(); i++)
			(*i)->Leave(pPlayer,false);
		pPlayer->m_channels.clear();
		pPlayer->BuybackItems.clear();
		pPlayer->ClearEvents();
		unsigned long time_to_rest=1000*6*48; //4.8 minutes
		if(!(pPlayer->Data.StatusFlags & STATUS_ZZZZ))
			time_to_rest<<=2;// *4 (4x slower resting in wilderness)
		EventManager.AddEvent(*pPlayer,time_to_rest,EVENT_PLAYER_REST,&time_to_rest,sizeof(time_to_rest));
		RegionManager.ObjectRemove(*pPlayer);
		pPlayer->pClient=0;
		pPlayer=0;
	}
	LoggingOut=false;
	OutPacket(SMSG_LOGOUT_COMPLETE,0,0);
	MessageHandlers = LoginMessageHandlers;
	if(pAccount) pAccount->Save();
}

void CClient::ChannelMessage(unsigned char Channel, const char *message, unsigned long user, const char *channelname, unsigned long Language, unsigned long userhigh)
{
	/*
	DIRECTION UNKNOWN Data len=008C op=0096 int=0000 msglen=0088 -- ChatHandler
	0000:  0D 00 00 00-00 54 72 61-64 65 00 F9-65 01 00 00  .....Trade.·e...
	0010:  00 00 00 4D-61 6B 69 6E-67 20 7C 48-69 74 65 6D  ...Making |Hitem
	0020:  3A 35 39 36-32 7C 68 5B-47 75 61 72-64 69 61 6E  :5962|h[Guardian
	0030:  20 50 61 6E-74 73 5D 7C-68 20 66 72-65 65 20 66   Pants]|h free f
	0040:  6F 72 20 61-6C 6C 20 6D-79 20 66 72-69 65 6E 64  or all my friend
	0050:  73 20 61 6E-64 20 66 61-6D 69 6C 79-2E 2E 2E 20  s and family...
	0060:  79 61 20 6A-75 73 74 20-67 6F 74 74-61 20 62 72  ya just gotta br
	0070:  69 6E 67 20-74 68 65 20-31 32 20 48-76 79 20 6C  ing the 12 Hvy l
	0080:  65 61 74 68-65 72 00 00-           -             eather..
	*/
	/*
	DIRECTION UNKNOWN Data len=0022 op=0096 int=0000 msglen=001E -- ChatHandler
	0000:  09 00 00 00-00 00 00 00-00 00 00 00-00 45 6E 6A  .............Enj
	0010:  6F 79 20 74-68 65 20 67-61 6D 65 21-00 00        oy the game!..
	*/
	char buffer[2048];
	memset(buffer,0,2048);
	int c = 0;
	buffer[c++]=Channel;
	*(unsigned long*)&buffer[c]=Language;
	c+=4;

	if (channelname)
	{
		strcpy(&buffer[c],channelname);
		c+=strlen(channelname)+1;
	}

	*(unsigned long*)&buffer[c]=user;
	c+=4;
	*(unsigned long*)&buffer[c]=userhigh;  // guid high
	c+=4;

	if (Channel==CHAT_SAY || Channel==CHAT_YELL || Channel==CHAT_PARTY)
	{
		*(unsigned long*)&buffer[c]=user;
		c+=4;
		*(unsigned long*)&buffer[c]=userhigh;  // guid high
		c+=4;
	}

	*(unsigned long*)&buffer[c]= strlen(message)+1;
	c+=4;

	strcpy(&buffer[c],message);
	c+=strlen(message)+1;

	buffer[c] = (char)pPlayer->Data.StatusFlags;
	c++;
	OutPacket(SMSG_MESSAGECHAT,buffer,c);

	/*
	if (channelname)
	{
	strcpy(&buffer[c],channelname);
	c+=strlen(channelname);
	c++;
	*(unsigned long*)&buffer[c]=0;
	c+=4;
	}
	if ( Channel==0)
	{
	*(unsigned long*)&buffer[c]=user;
	c+=4;
	*(unsigned long*)&buffer[c]=0;  // guid high
	c+=4;//
	}

	*(unsigned long*)&buffer[c]=user;
	c+=4;
	*(unsigned long*)&buffer[c]=0;  // guid high
	c+=4;

	*(unsigned long*)&buffer[c]= strlen(message)+1;
	c+=4;
	strcpy(&buffer[c],message);
	c+=strlen(message)+1;
	buffer[c] = pPlayer->Data.StatusFlags;
	c++;
	OutPacket(SMSG_MESSAGECHAT,buffer,c);*/
}
void CClient::AddKnownDynamicObject(class CDynamicObject &GObject)
{
	char buffer[0x300];
	memset(buffer, 0, sizeof(buffer));
	buffer[0]= 1;
	buffer[4]= 0;
	buffer[5]= 2;// create object
	int oSize=GObject.GetDynamicObjectInfoData(&buffer[6])+6;
	if (oSize == 5)
		return;
#if COMPRESSED_PLYR_PACKETS
	int nSize=Compressor.Deflate(buffer,oSize);
	if (!nSize)
	{
		Debug.Log("Deflate failed\n");
		return;
	}
	char *buf=(char*)malloc(nSize+4);
	*(unsigned long*)&buf[0]=oSize;
	Compressor.GetBuffer(&buf[4]);
	OutPacket(SMSG_COMPRESSED_UPDATE_OBJECT,buf,nSize+4);
	free(buf);
#else
	OutPacket(SMSG_UPDATE_OBJECT,buffer,oSize);
#endif
}
void CClient::AddKnownGameObject(class CGameObject &GObject)
{
	char buffer[0x300];
	memset(buffer, 0, sizeof(buffer));
	buffer[0]= 1;
	buffer[4]= 0;
	buffer[5]= 2;// create object
	int oSize=GObject.GetGameObjectInfoData(&buffer[6])+6;
	if (oSize == 5)
		return;
#if COMPRESSED_PLYR_PACKETS
	int nSize=Compressor.Deflate(buffer,oSize);
	if (!nSize)
	{
		Debug.Log("Deflate failed\n");
		return;
	}
	char *buf=(char*)malloc(nSize+4);
	*(unsigned long*)&buf[0]=oSize;
	Compressor.GetBuffer(&buf[4]);
	OutPacket(SMSG_COMPRESSED_UPDATE_OBJECT,buf,nSize+4);
	free(buf);
#else
	OutPacket(SMSG_UPDATE_OBJECT,buffer,oSize);
#endif
}

void CClient::UpdateKnownGameObject(class CGameObject &GObject)
{
	char buffer[0x300];
	memset(buffer,0,sizeof(buffer));
	buffer[0]=1;
	buffer[4]=0;
	buffer[5]=0;// update object
	int oSize=GObject.GetGameObjectInfoData(&buffer[6],false)+6;
	if (oSize == 5)
		return;
#if COMPRESSED_PLYR_PACKETS
	int nSize=Compressor.Deflate(buffer,oSize);
	if (!nSize)
	{
		Debug.Log("Deflate failed\n");
		return;
	}
	char *buf=(char*)malloc(nSize+4);
	*(unsigned long*)&buf[0]=oSize;
	Compressor.GetBuffer(&buf[4]);
	OutPacket(SMSG_COMPRESSED_UPDATE_OBJECT,buf,nSize+4);
	free(buf);
#else
	OutPacket(SMSG_UPDATE_OBJECT,buffer,oSize);
#endif
}

void CClient::AddKnownCorpse(CCorpse &Corpse)
{
	char buffer[0x300];
	memset(buffer, 0, sizeof(buffer));
	buffer[0]= 1;
	buffer[4]= 0;
	buffer[5]= 2;// create object
	int oSize=Corpse.GetCorpseInfoData(&buffer[6])+6;
	if (oSize == 5)
		return;
#if COMPRESSED_PLYR_PACKETS
	int nSize=Compressor.Deflate(buffer,oSize);
	if (!nSize)
	{
		Debug.Log("CClient::AddKnownCorpse() - Deflate failed\n");
		return;
	}
	char *buf=(char*)malloc(nSize+4);
	*(unsigned long*)&buf[0]=oSize;
	Compressor.GetBuffer(&buf[4]);
	OutPacket(SMSG_COMPRESSED_UPDATE_OBJECT,buf,nSize+4);
	free(buf);
#else
	OutPacket(SMSG_UPDATE_OBJECT,buffer,oSize);
#endif
}

void CClient::UpdateKnownCorpse(CCorpse &Corpse)
{
	char buffer[0x300];
	memset(buffer,0,sizeof(buffer));
	buffer[0]=1;
	buffer[4]=0;
	buffer[5]=0;// update object
	int oSize=Corpse.GetCorpseInfoData(&buffer[6],false)+6;
	if (oSize == 5)
		return;
#if COMPRESSED_PLYR_PACKETS
	int nSize=Compressor.Deflate(buffer,oSize);
	if (!nSize)
	{
		Debug.Log("CClient::UpdateKnownCorpse() - Deflate failed\n");
		return;
	}
	char *buf=(char*)malloc(nSize+4);
	*(unsigned long*)&buf[0]=oSize;
	Compressor.GetBuffer(&buf[4]);
	OutPacket(SMSG_COMPRESSED_UPDATE_OBJECT,buf,nSize+4);
	free(buf);
#else
	OutPacket(SMSG_UPDATE_OBJECT,buffer,oSize);
#endif
}

void CClient::AddKnownCreature(CCreature &Creature)
{
	// Check if SH
	if(Creature.pTemplate->guid == 0x0800195b && pPlayer->dead == false)
		return;	// Is a spirit healer, we don't want to see them if you're alive
	char buffer[300];
	memset(&buffer[0],0,300);
	buffer[0]=1;
	buffer[4]=0;
	buffer[5]=3;
	int oSize=Creature.GetCreatureInfoData(&buffer[6])+6;
#if COMPRESSED_PLYR_PACKETS
	int nSize=Compressor.Deflate(buffer,oSize);
	if (!nSize)
	{
		Debug.Log("CClient::AddKnownCreature() - Deflate failed\n");
		return;
	}
	char *buf=(char*)malloc(nSize+4);
	*(unsigned long*)&buf[0]=oSize;
	Compressor.GetBuffer(&buf[4]);
	OutPacket(SMSG_COMPRESSED_UPDATE_OBJECT,buf,nSize+4);
	free(buf);
#else
	OutPacket(SMSG_UPDATE_OBJECT,buffer,oSize);
#endif
}

void CClient::UpdateKnownCreature(CCreature &Creature)
{
	if(Creature.pTemplate->guid == 0x0800195b && pPlayer->dead == false)
		return;	// Is a spirit healer, we don't want to see them if you're alive
	char buffer[300];
	memset(&buffer[0],0,300);
	buffer[0]=1;
	buffer[4]=0;
	buffer[5]=0;// update object
	int oSize=Creature.GetCreatureInfoData(&buffer[6],false)+6;
#if COMPRESSED_PLYR_PACKETS
	int nSize=Compressor.Deflate(buffer,oSize);
	if (!nSize)
	{
		Debug.Log("CClient::UpdateKnownCreature() - Deflate failed\n");
		return;
	}
	char *buf=(char*)malloc(nSize+4);
	*(unsigned long*)&buf[0]=oSize;
	Compressor.GetBuffer(&buf[4]);
	OutPacket(SMSG_COMPRESSED_UPDATE_OBJECT,buf,nSize+4);
	free(buf);
#else
	OutPacket(SMSG_UPDATE_OBJECT,buffer,oSize);
#endif
}

void CClient::AddKnownItem(class CItem &Item)
{
	unsigned char buffer[0x1000];
	memset(buffer, 0, sizeof(buffer));
	buffer[0]= 1;
	buffer[4]= 0;
	buffer[5]= 3;// create object
	int oSize=Item.GetItemInfoData(&buffer[6])+6;
	if (oSize == 5)
		return;
#if COMPRESSED_PLYR_PACKETS
	int nSize=Compressor.Deflate(buffer,oSize);
	if (!nSize)
	{
		Debug.Log("CClient::AddKnownItem() - Deflate failed\n");
		return;
	}
	char *buf=(char*)malloc(nSize+4);
	*(unsigned long*)&buf[0]=oSize;
	Compressor.GetBuffer(&buf[4]);
	OutPacket(SMSG_COMPRESSED_UPDATE_OBJECT,buf,nSize+4);
	free(buf);
#else
	OutPacket(SMSG_UPDATE_OBJECT,buffer,oSize);
#endif
}

void CClient::UpdateKnownItem(class CItem &Item)
{
	unsigned char buffer[0x1000];
	memset(buffer,0,0x1000);
	buffer[0]=1;
	buffer[4]=0;
	buffer[5]=0;// update object
	int oSize=Item.GetItemInfoData(&buffer[6],false)+6;
	if (oSize == 5)
		return;
#if COMPRESSED_PLYR_PACKETS
	int nSize=Compressor.Deflate(buffer,oSize);
	if (!nSize)
	{
		Debug.Log("CClient::UpdateKnownItem() - Deflate failed\n");
		return;
	}
	char *buf=(char*)malloc(nSize+4);
	*(unsigned long*)&buf[0]=oSize;
	Compressor.GetBuffer(&buf[4]);
	OutPacket(SMSG_COMPRESSED_UPDATE_OBJECT,buf,nSize+4);
	free(buf);
#else
	OutPacket(SMSG_UPDATE_OBJECT,buffer,oSize);
#endif
}

void CClient::AddKnownPlayer(CPlayer &Player)
{
	char buffer[0x1000];

	memset(buffer,0,0x1000);
	buffer[0]=1;
	buffer[4]=0;
	buffer[5]=2;
	int oSize=Player.GetPlayerInfoData(&buffer[6], false)+6; //false = not self
#if COMPRESSED_PLYR_PACKETS
	int nSize=Compressor.Deflate(buffer,oSize);
	if (!nSize)
	{
		Debug.Log("CClient::AddKnownPlayer() - Deflate failed\n");
		return;
	}
	char *buf=(char*)malloc(nSize+4);
	*(unsigned long*)&buf[0]=oSize;
	Compressor.GetBuffer(&buf[4]);
	OutPacket(SMSG_COMPRESSED_UPDATE_OBJECT,buf,nSize+4);
	free(buf);
#else
	OutPacket(SMSG_UPDATE_OBJECT,buffer,oSize);
#endif

	for (unsigned long i = 0 ; i < 19 ; i++)
	{
//		if (unsigned long ItemID=Player.Data.Items[i])
		if (CItem *pItem = Player.Data.Items[i])
		{
			memset(buffer,0,0x1000);
//			CItem *pItem=0;
//			if (DataManager.RetrieveObject((CWoWObject**)&pItem,ItemID))
			{
//				if (pItem == NULL)
//					continue;
				if (pItem->Data.Owner == 0)
					continue;
				if (pItem->Data.Owner != Player.guid)
					continue;
				AddKnownItem(*pItem);  // 2
			}
		}
	}
}

void CClient::UpdateKnownPlayer(CPlayer &Player)
{
	char buffer[0x1000];

	memset(buffer,0,0x1000);
	buffer[0]=1;
	buffer[4]=0;
	buffer[5]=0;
	int oSize=Player.GetPlayerInfoData(&buffer[6],false,false)+6;
#if COMPRESSED_PLYR_PACKETS
	int nSize=Compressor.Deflate(buffer,oSize);
	if (!nSize)
	{
		Debug.Log("CClient::UpdateKnownPlayer() - Deflate failed\n");
		return;
	}
	char *buf=(char*)malloc(nSize+4);
	*(unsigned long*)&buf[0]=oSize;
	Compressor.GetBuffer(&buf[4]);
	OutPacket(SMSG_COMPRESSED_UPDATE_OBJECT,buf,nSize+4);
	free(buf);
#else
	OutPacket(SMSG_UPDATE_OBJECT,buffer,oSize);
#endif
}

void CClient::RemoveKnownPlayer(CPlayer &Player)
{
	char buf[8];
	*(unsigned long*)&buf[0]=Player.guid;
	*(unsigned long*)&buf[4]=PLAYERGUID_HIGH;
	OutPacket(SMSG_DESTROY_OBJECT,buf,8);
}

void CClient::RemoveKnownCreature(CCreature &Creature)
{
	if(Creature.pTemplate->guid == 0x0800195b && pPlayer->dead == false)
		return;	// Is a spirit healer, we don't want to see them if you're alive
	char buf[8];
	*(unsigned long*)&buf[0]=Creature.guid;
	*(unsigned long*)&buf[4]=CREATUREGUID_HIGH;
	OutPacket(SMSG_DESTROY_OBJECT,buf,8);
}

void CClient::RemoveKnownItem(CItem &Item)
{
	char buf[8];
	*(unsigned long*)&buf[0]=Item.guid;
	*(unsigned long*)&buf[4]=ITEMGUID_HIGH;
	OutPacket(SMSG_DESTROY_OBJECT,buf,8);
}

void CClient::RemoveKnownCorpse(CCorpse &Corpse)
{
	char buf[8];
	*(unsigned long*)&buf[0]=Corpse.guid;
	*(unsigned long*)&buf[4]=CORPSEGUID_HIGH;
	OutPacket(SMSG_DESTROY_OBJECT,buf,8);
}

void CClient::RemoveKnownGameObject(CGameObject &GObject)
{
	char buf[8];
	*(unsigned long*)&buf[0]=GObject.guid;
	*(unsigned long*)&buf[4]=GAMEOBJECTGUID_HIGH;
	OutPacket(SMSG_DESTROY_OBJECT,buf,8);
}
void CClient::RemoveKnownDynamicObject(CDynamicObject &GObject)
{
	CPacket pkg(SMSG_DESTROY_OBJECT);
	pkg<<GObject.guid;
	pkg<<GAMEOBJECTGUID_HIGH;
	Send(&pkg);
}


void CClient::ChatSay(unsigned long Language,const char *Msg)
{
	CRegion *pPlayerRegion=RegionManager.ObjectRegions[pPlayer->guid];
	if (!pPlayerRegion)
		return;
	for (int i = 0 ; i < 3 ; i++)
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					switch(pNode->pObject->type)
					{
					case OBJ_PLAYER:
						if (pPlayer->Distance(*((CPlayer*)pNode->pObject))<SAYDIST)
							((CPlayer*)pNode->pObject)->pClient->ChannelMessage(CHAT_SAY,Msg,pPlayer->guid,0,Language);
						break;
					}
					pNode=pNode->pNext;
				}
			}
		}
}

void CClient::ChatYell(unsigned long Language,const char *Msg)
{
	CRegion *pPlayerRegion=RegionManager.ObjectRegions[pPlayer->guid];
	if (!pPlayerRegion)
		return;
	for (int i = 0 ; i < 3 ; i++)
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					switch(pNode->pObject->type)
					{
					case OBJ_PLAYER:
						if (pPlayer->Distance(*((CPlayer*)pNode->pObject))<YELLDIST)
							((CPlayer*)pNode->pObject)->pClient->ChannelMessage(CHAT_YELL,Msg,pPlayer->guid,0,Language);
						break;
					}
					pNode=pNode->pNext;
				}
			}
		}
}

void CClient::Echo(const char *format,...)
{
	CHAR szOutput[20480] = {0};
	va_list vaList;
	va_start( vaList, format );
	vsprintf(szOutput,format, vaList);
	ChannelMessage(CHAT_SYSTEM,szOutput,0,0,0);
}

void CClient::ChannelMsgF(unsigned char channel,const char *format,...)
{
	CHAR szOutput[20480] = {0};
	va_list vaList;
	va_start( vaList, format );
	vsprintf(szOutput,format, vaList);
	ChannelMessage(channel,szOutput,0,0,0);
}

void CClient::Emote(unsigned long who, unsigned long animation, unsigned long code, unsigned long target, char *name, unsigned long targettype)
{
	CRegion *pPlayerRegion=RegionManager.ObjectRegions[pPlayer->guid];
	if (!pPlayerRegion)
		return;
	for (int i = 0 ; i < 3 ; i++)
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if(pNode->pObject->type == OBJ_PLAYER && (((CPlayer*)pNode->pObject)->pClient) && pPlayer->Distance(*((CPlayer*)pNode->pObject))<EMOTEDIST)
					{
						((CPlayer*)pNode->pObject)->pClient->EmoteAnim(animation, who, PLAYERGUID_HIGH);
						((CPlayer*)pNode->pObject)->pClient->EmoteText(who, PLAYERGUID_HIGH, target, targettype, code, name);
					}
					pNode=pNode->pNext;
				}
			}
		}
}


void CClient::EmoteAnim(unsigned long animation, unsigned long who, unsigned long whohigh)
{
	CPacket pkg;
	pkg.Reset(SMSG_EMOTE);
	pkg << animation;
	pkg << who << whohigh;
	Send(&pkg);
}

void CClient::EmoteText(unsigned long who, unsigned long whohigh, unsigned long target, unsigned long targethigh, unsigned long code, char *name)
{
	char buffer[86];
	memset(buffer, 0x00, 86);
	int plen;
	*(unsigned long*)&buffer[0] = who;
	*(unsigned long*)&buffer[4] = PLAYERGUID_HIGH;
	*(unsigned long*)&buffer[8] = code;
	*(unsigned long*)&buffer[12] = 0xFFFFFFFF; //-1

	if (target != 0)
	{
		*(unsigned long*)&buffer[16] = strlen(name)+1;
		strcpy(&buffer[20], name);
		plen = 20 + strlen(name)+1;
	}
	else
	{
		*(unsigned long*)&buffer[16] = 0x01;
		*(unsigned long*)&buffer[20] = 0x00;
		plen = 21;
	}
	OutPacket(SMSG_TEXT_EMOTE, buffer, plen);
}

void CClient::InterruptCast(unsigned long spell)
{
	char buffer[0x0D];
	memset(buffer, 0, 0x0D);
	int c;
	c=Packets::PackGuidBuffer(buffer,pPlayer->guid,PLAYERGUID_HIGH);
	*(unsigned long*)&buffer[c]=spell;
	buffer[c+4]=0x11;
	/*
	*(unsigned char*)&buffer[0]=0xFF;
	*(unsigned long*)&buffer[1]=pPlayer->guid;
	*(unsigned long*)&buffer[9]=spell;
	buffer[13]=0x11;
	*/
	OutPacket(SMSG_SPELL_FAILURE,buffer,c+5);
	memset(buffer, 0, 0x06);
	*(unsigned long*)&buffer[0]=spell;
	*(unsigned short*)&buffer[4]=0x1102;
	OutPacket(SMSG_CAST_RESULT,buffer,0x06);
}
