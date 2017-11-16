#include "stdafx.h"
#include "RealmServer.h"
#include "Globals.h"
#include "Creature.h"
#include "CreatureTemplate.h"
#include "ItemTemplate.h"
#include "SpawnPoint.h"
#include "Container.h"
#include "LootTable.h"
#include "Zone.h"
#include "PathGroup.h"
#include "ChatManager.h"

#ifndef WIN32
void pipesignal(int param)
{
	RealmServer.pTempClient->socket.Close();
	signal(SIGPIPE,pipesignal);
}
#endif

THREAD WINAPI RealmServerThreadFunction( LPVOID pParam )
{
	
	CThread *pThread=(CThread*)pParam;
	CLock L(&pThread->Threading,true);
	pThread->bThreading=true;
	pThread->ThreadReady=true;
	CRealmServer *pServer=(CRealmServer*)pThread->Info;
#ifndef WIN32
	signal(SIGPIPE,pipesignal);
#endif
	pServer->ThreadState=0;
	char Buffer[20480];
	CClient *nextclient=new CClient;
	time_t LastMasterHeartbeat=0;
	TCPSocket Redirect;
	Addr From;
	time_t now=time(0);
	int ServerState=0;
	// seed random number generator for this thread
	srand(time(0));

	while(!pThread->CloseThread)
	{
		int LastState=ServerState;


		now=time(0);
		// handle each client individually
		for (unsigned long i = 0 ; i < pServer->Clients.Size ; i++)
		{
			if (CClient *client=pServer->Clients[i])
			{
				// disconnected?
				if (!client->socket.isConnected())
				{
					// delete and whatnot
					pServer->Clients[i]=0;
					delete client;
					pServer->nClients--;
					continue;
				}
				// outgoing data new
					
				while (!client->Outgoing.Empty() && client->DataPending.Size<1024)
				{
					_OutData data=client->Outgoing.Peek();
					int AddSize=data.Size;
					if (AddSize+client->DataPending.Size>=0x3F00)
					{
						break;
					}
					memcpy(&client->DataPending.buffer[client->DataPending.Size],data.buffer,AddSize);
					client->DataPending.Size+=AddSize;
						free(data.buffer);
						client->Outgoing.Pop();
				}

				if (int SendSize=client->DataPending.Size)
				{
					pServer->pTempClient=client;
//					if (SendSize>1024)
//						SendSize=1024;
					pServer->ThreadState=1;
					int sent=client->socket.Send(client->DataPending.buffer,client->DataPending.Size);
					pServer->ThreadState=2;
					if (sent>0)
					{
						pServer->ThreadState=3;
						if (sent>pServer->MaxSent)
							pServer->MaxSent=sent;

						client->DataPending.Size-=sent;
						memmove(client->DataPending.buffer,&client->DataPending.buffer[sent],client->DataPending.Size);
						pServer->ThreadState=4;
					}
				}

				if (client->DestroyMe)
				{
					pServer->Clients[i]=0;
					delete client;
					pServer->nClients--;
					continue;
				}
				// incoming data?
				pServer->ThreadState=5;
				for (int n = 0 ; n < 6 ; n++)
				{
					int isize=client->socket.isData();
					if (isize>0)
					{
						if (!client->NextLength) 
						{
							if (isize>=2)
							{
								client->socket.Receive((char*)&client->NextLength,2);
								client->NextLength=htons(client->NextLength);
							}
						}
						else
						if (isize>=client->NextLength)
						{
							client->LastIncoming=now;
							isize=client->socket.Receive(Buffer,client->NextLength);
							_InData *Data=(_InData*)&Buffer[0];
							Data->Read=client->NextLength;
							pServer->ThreadState=6;
							if (Data->OpCode<MSG_HANDLERS && client->MessageHandlers[Data->OpCode])
								client->MessageHandlers[Data->OpCode](client,Data);
							pServer->ThreadState=7;
							//client->ProcessIncomingData(Data);
							client->NextLength=0;
						}
					}
					else
						break;
				}
				if (difftime(now,client->LastIncoming)>180.0f)
				{
					client->DestroyMe=true;
				}
			}
		}
		if (pServer->RedirectListener.Accept(Redirect))
		{
			if (pServer->nClients<Settings.max_connections)
			{
				char Out[256];
				sprintf(Out,"%s:8086",pServer->IPAddr);
				Redirect.Send(Out,strlen(Out)+1);
				Redirect.Close();
			}
		}
		if (pServer->MasterList.isData())
		{
/*
			int len=pServer->MasterListener.RecvFrom(buffer,2048,From);
			if (len==sizeof(RealmPacket))
			{
				pServer->AddRealm((RealmPacket*)&buffer[0],From);
			}
/**/
			int len=pServer->MasterList.RecvFrom(Buffer,2048,From);
			pServer->MasterList.SendTo(Buffer,len,From);
		}
		
		pServer->ThreadState=8;
		if (pServer->nClients<Settings.max_connections)
		{
			pServer->ThreadState=9;
			ServerState=0;
			if (pServer->Listener.Accept(nextclient->socket))
			{
				pServer->ThreadState=10;
				nextclient->SendAuthChallenge(0);
				nextclient->LastIncoming=now;
				pServer->Clients+=nextclient;
				nextclient = new CClient;
				pServer->nClients++;
				if (pServer->nClients>pServer->nMaxClients)
				{
					pServer->nMaxClients=pServer->nClients;
				}
			}
		}
		else
			ServerState=1;

		pServer->ThreadState=11;
		if (difftime(now,LastMasterHeartbeat)>60.0f || ServerState!=LastState)
		{
			LastMasterHeartbeat=now;
			pServer->UpdateMasterLists(ServerState);
		}

		pServer->ThreadState=12;
		EventManager.ProcessReadyEvents();
		pServer->ThreadState=13;

		Sleep(5); // 200 per second
	}
	if (difftime(now,LastMasterHeartbeat)<140.0f)
	{
		pServer->UpdateMasterLists(-1);
	}

	if (nextclient)
		delete nextclient;
	pServer->Clients.Cleanup();
	pServer->nClients=0;
	pThread->bThreading=false;
	return 0;
}


CRealmServer::CRealmServer(void):Clients(10),MasterLists(10)
{
	MaxSent=0;
	nMaxClients=0;
	nClients=0;
	/*
	Addr *MainList=new Addr;
	memset(MainList,0,sizeof(Addr));
	MainList->sa_family=2;
//    MainList->IP=inet_addr("192.168.1.69");// private internal lan
	MainList->IP=inet_addr("62.65.143.232"); // private stormcraft (TODO: gethostbyname realmlist.alita.cc)
//	MainList->IP=inet_addr("213.114.164.23");//private stormcraft
//	MainList->IP=inet_addr("66.208.106.16");//public
	MainList->Port=htons(9111);
	MasterLists+=MainList;
	/**/
	strcpy(Name,"StormCraft Town Hall (internal)");
	strcpy(IPAddr,"127.0.0.1");
}

CRealmServer::~CRealmServer(void)
{
	RealmThread.EndThread();
	// Clients are cleaned up by thread
	MasterLists.Cleanup();
}

bool DoAccountNames(ObjectStorage &Storage, unsigned long ID)
{
	string name=((AccountData*)Storage.Data)->Name;
	MakeLower(name);
	DataManager.AccountNames[name]=ID;
	return true;
}

bool DoPlayerNames(ObjectStorage &Storage, unsigned long ID)
{
	string name=((PlayerData*)Storage.Data)->Name;
	MakeLower(name);
	DataManager.PlayerNames[name]=ID;
	return true;
}

bool InitSpawnPoints(unsigned long ID)
{
	CSpawnPoint *pPoint;
	if (DataManager.RetrieveObject((CWoWObject**)&pPoint,OBJ_SPAWNPOINT,ID))
	{
		// does it have a creature spawned?
		if (pPoint->Data.Creature)
		{
			CCreature *pCreature;
			if (DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE,ID))
			{
				// reset it to normal state
				pCreature->Data.CurrentStats=pCreature->Data.NormalStats;
				// and let it appear
				RegionManager.ObjectNew(*pCreature,pCreature->Data.Continent,pCreature->Data.Loc.X,pCreature->Data.Loc.Y);
				return true;
			}
		}
		pPoint->Data.Creature=0;
		pPoint->Spawn();
	}
	return true;
}

bool InitPathGroups(unsigned long ID)
{
	CPathGroup *pGroup;
	if (DataManager.RetrieveObject((CWoWObject**)&pGroup,OBJ_PATHGROUP,ID))
	{
		// TODO: populate some temporary map of every point. the data stored by the map
		// will be a linked list for every point x y and z on a particular continent.
		// once the linked list is complete, iterate through the entire map. for each list
		// that has more nodes than just the head, generate pairs of connected groups.
		// once this is complete, free the map.
	}
	return true;
}

void CRealmServer::Go()
{
	if (CRealmServer::Initialize())
	{
		Settings.LoadSettings();
		DBCManager.Initialize();
		CreateTestData();
		if (Storage.Initialize())
		{
			// convert if necessary
			Storage.SetObjectSize(OBJ_ACCOUNT,sizeof(AccountData));
			Storage.SetObjectSize(OBJ_PLAYER,sizeof(PlayerData));
			Storage.SetObjectSize(OBJ_ITEM,sizeof(ItemData));
			Storage.SetObjectSize(OBJ_ITEMTEMPLATE,sizeof(ItemTemplateData));
			Storage.SetObjectSize(OBJ_CREATURE,sizeof(CreatureData));
			Storage.SetObjectSize(OBJ_CREATURETEMPLATE,sizeof(CreatureTemplateData));
			Storage.SetObjectSize(OBJ_SPAWNPOINT,sizeof(SpawnPointData));
			Storage.SetObjectSize(OBJ_LOOTTABLE,sizeof(LootTableData));
			Storage.SetObjectSize(OBJ_ZONE,sizeof(ZoneData));
//			Storage.SetObjectSize(OBJ_CONTAINER,sizeof(ContainerData));
			Storage.SetObjectSize(OBJ_PATHGROUP,sizeof(PathGroupData));

			// ok, set up the name caches
			Storage.EnumObjects(OBJ_ACCOUNT,DoAccountNames);
			Storage.EnumObjects(OBJ_PLAYER,DoPlayerNames);

			// set up pathing point groups
			Storage.EnumObjectIDs(OBJ_PATHGROUP,InitPathGroups);

			// cache spawn points
			Storage.EnumObjectIDs(OBJ_SPAWNPOINT,InitSpawnPoints);
		}
		RealmThread.BeginThread(RealmServerThreadFunction,this);
	}
}

bool CRealmServer::Initialize()
{
	if (!Listener.Create(8086))
		return false;
	if (!Listener.Listen())
		return false;
	if (!RedirectListener.Create(9090))
		return false;
	if (!RedirectListener.Listen())
		return false;
	if (!MasterList.Create(9112))
		return false;
	return true;
}

void CRealmServer::UpdateMasterLists(int State)
{
	// construct packet
	RealmPacket Packet;
	memset(&Packet,0,sizeof(RealmPacket));
	Packet.Port=9090;
	strcpy(Packet.IPAddr,RealmServer.IPAddr);
	switch(State)
	{
	case -1:
		Packet.Name[0]='*';
		strncpy(&Packet.Name[1],Name,62);
		Packet.Name[63]=0;
		break;
	case 1:
		Packet.nPlayers=nClients;
		Packet.Name[0]='*';
		strncpy(&Packet.Name[1],Name,62);
		Packet.Name[63]=0;
		break;
	case 0:
	default:
		Packet.nPlayers=nClients;
		strcpy(Packet.Name,Name);
		break;
	}

	for (unsigned long i = 0 ; i < MasterLists.Size ; i++)
	{
		if (Addr* pAddr=MasterLists[i])
		{
			MasterList.SendTo(&Packet,sizeof(RealmPacket),*pAddr);
		}
	}
}

void CRealmServer::CreateTestData()
{
	class CItemTemplate *pTemplate;
#define CREATEFOOD(saveto, name, displayid, mana)\
	pTemplate = new CItemTemplate;\
	pTemplate->New();\
	pTemplate->CreateFood(name, displayid, 5, mana);\
	DataManager.NewObject(*pTemplate);\
	saveto = pTemplate->guid;

	CREATEFOOD(STATICITEMS::TOUGH_JERKY, "Tough Jerky", 2473, false);
	CREATEFOOD(STATICITEMS::TOUGH_HUNK_OF_BREAD, "Tough Hunk of Bread", 6399, false);
	CREATEFOOD(STATICITEMS::DARNASSIAN_BLEU, "Darnassius Blue", 6353, false);
	CREATEFOOD(STATICITEMS::FOREST_MUSHROOM_CAP, "Forest Mushroom Cap",6353, false);
	CREATEFOOD(STATICITEMS::SHINY_RED_APPLE, "Shiny Red Apple", 6410, false);
	CREATEFOOD(STATICITEMS::REFRESHING_SPRING_WATER, "Refreshing Spring Water", 6366, true);

	pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->CreateOneHandSword("Worn Shortsword", 1542);
	DataManager.NewObject(*pTemplate);
	STATICITEMS::WARRIOR_SHORTSWORD = pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->CreateShield("Worn Wooden Shield", 2158);
	DataManager.NewObject(*pTemplate);
	STATICITEMS::WARRIOR_SHIELD = pTemplate->guid;

#define CREATESHIRT(saveto, name, displayid)\
	pTemplate = new CItemTemplate;\
	pTemplate->New();\
	pTemplate->CreateShirt(name, displayid);\
	DataManager.NewObject(*pTemplate);\
	saveto = pTemplate->guid;
#define CREATEPANTS(saveto, name, displayid)\
	pTemplate = new CItemTemplate;\
	pTemplate->New();\
	pTemplate->CreatePants(name, displayid);\
	DataManager.NewObject(*pTemplate);\
	saveto = pTemplate->guid;
#define CREATEBOOTS(saveto, name, displayid)\
	pTemplate = new CItemTemplate;\
	pTemplate->New();\
	pTemplate->CreateBoots(name, displayid);\
	DataManager.NewObject(*pTemplate);\
	saveto = pTemplate->guid;
#define CREATEROBE(saveto, name, displayid)\
	pTemplate = new CItemTemplate;\
	pTemplate->New();\
	pTemplate->CreateRobe(name, displayid);\
	DataManager.NewObject(*pTemplate);\
	saveto = pTemplate->guid;


	CREATESHIRT(STATICITEMS::WARRIOR_SHIRT, "Recruit's Shirt", 9891);
	CREATEPANTS(STATICITEMS::WARRIOR_PANTS, "Recruit's Pants", 9892);
	CREATEBOOTS(STATICITEMS::WARRIOR_BOOTS, "Recruit's Boots", 10141);
	CREATESHIRT(STATICITEMS::NE_WARRIOR_SHIRT, "Recruit's Shirt", 9983);
	CREATEPANTS(STATICITEMS::NE_WARRIOR_PANTS, "Recruit's Pants", 9984);
	CREATEBOOTS(STATICITEMS::NE_WARRIOR_BOOTS, "Recruit's Boots", 9985);
	CREATESHIRT(STATICITEMS::EVIL_WARRIOR_SHIRT, "Brawler's Harness", 9995);
	CREATEPANTS(STATICITEMS::EVIL_WARRIOR_PANTS, "Brawler's Pants", 9988);
	CREATEBOOTS(STATICITEMS::EVIL_WARRIOR_BOOTS, "Brawler's Boots", 9992);
	CREATEBOOTS(STATICITEMS::PALADIN_BOOTS, "Squire's Boots", 10272);

	pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->CreateTwoHandBlunt("Battleworn Hammer", 8285);
	DataManager.NewObject(*pTemplate);
	STATICITEMS::PALADIN_HAMMER = pTemplate->guid;

	CREATESHIRT(STATICITEMS::HUMAN_PALADIN_SHIRT, "Squire's Shirt", 3265);
	CREATEPANTS(STATICITEMS::HUMAN_PALADIN_PANTS, "Squire's Pants", 9937);
	CREATESHIRT(STATICITEMS::DWARF_PALADIN_SHIRT, "Squire's Shirt", 9972);
	CREATEPANTS(STATICITEMS::DWARF_PALADIN_PANTS, "Squire's Pants", 9974);

	pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->CreateDagger("Worn Dagger", 6442);
	DataManager.NewObject(*pTemplate);
	STATICITEMS::ROGUE_DAGGER = pTemplate->guid;

	CREATESHIRT(STATICITEMS::GOOD_ROGUE_SHIRT, "Footpad's Shirt", 9906);
	CREATEPANTS(STATICITEMS::GOOD_ROGUE_PANTS, "Footpad's Pants", 9913);
	CREATEBOOTS(STATICITEMS::GOOD_ROGUE_BOOTS, "Footpad's Shoes", 9915);
	
	pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->CreateVest("Footpad's Vest", 10005);
	DataManager.NewObject(*pTemplate);
	STATICITEMS::EVIL_ROGUE_CHEST = pTemplate->guid;

	CREATEPANTS(STATICITEMS::EVIL_ROGUE_PANTS, "Footpad's Pants", 10006);
	CREATEBOOTS(STATICITEMS::EVIL_ROGUE_BOOTS, "Footpad's Shoes", 10008);
	
	pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->CreateVest("Footpad's Vest", 10112);
	DataManager.NewObject(*pTemplate);
	STATICITEMS::TROLL_ROGUE_CHEST = pTemplate->guid;

	CREATEPANTS(STATICITEMS::TROLL_ROGUE_PANTS, "Footpad's Pants", 10114);
	CREATEBOOTS(STATICITEMS::TROLL_ROGUE_BOOTS, "Footpad's Shoes", 10115);

	CREATESHIRT(STATICITEMS::PRIEST_SHIRT, "Neophyte's Shirt", 9944);
	CREATEPANTS(STATICITEMS::PRIEST_PANTS, "Neophyte's Pants", 9945);
	CREATEBOOTS(STATICITEMS::PRIEST_BOOTS, "Neophyte's Boots", 10115);
	
	pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->CreateOneHandBlunt("Worn Mace", 5194);
	DataManager.NewObject(*pTemplate);
	STATICITEMS::PRIEST_MACE = pTemplate->guid;
	
	CREATEROBE(STATICITEMS::HUMAN_DWARF_PRIEST_ROBE, "Neophyte's Robe", 12679);
	CREATEROBE(STATICITEMS::NIGHTELF_PRIEST_ROBE, "Neophyte's Robe", 12681);
	CREATEROBE(STATICITEMS::UNDEAD_TROLL_PRIEST_ROBE, "Neophyte's Robe", 12680);

	CREATESHIRT(STATICITEMS::MAGE_SHIRT, "Apprentice's Shirt", 2163);
	CREATEPANTS(STATICITEMS::MAGE_PANTS, "Apprentice's Pants", 9924);
	CREATEBOOTS(STATICITEMS::MAGE_BOOTS, "Apprentice's Boots", 9929);
	
	pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->CreateStaff("Bent Staff", 472);
	DataManager.NewObject(*pTemplate);
	STATICITEMS::MAGE_STAFF = pTemplate->guid;

	CREATEROBE(STATICITEMS::HUMAN_GNOME_MAGE_ROBE, "Apprentice's Robe", 12647);
	CREATEROBE(STATICITEMS::DWARF_MAGE_ROBE, "Apprentice's Robe", 12648);
	CREATEROBE(STATICITEMS::UNDEAD_TROLL_MAGE_ROBE, "Apprentice's Robe", 12649);

	CREATESHIRT(STATICITEMS::HUMAN_GNOME_WARLOCK_SHIRT, "Acolyte's Shirt", 2470);
	CREATEPANTS(STATICITEMS::WARLOCK_PANTS, "Acolyte's Pants", 3260);
	CREATEBOOTS(STATICITEMS::WARLOCK_BOOTS, "Acolyte's Boots", 3261);
	STATICITEMS::WARLOCK_DAGGER = STATICITEMS::ROGUE_DAGGER;
	CREATEROBE(STATICITEMS::HUMAN_GNOME_WARLOCK_ROBE, "Acolyte's Robe", 12645);
	CREATEROBE(STATICITEMS::ORC_UNDEAD_WARLOCK_ROBE, "Acolyte's Robe", 12646);

	// Shaman item names/stats unknown only display id
	STATICITEMS::SHAMAN_MACE = STATICITEMS::PRIEST_MACE;
	CREATESHIRT(STATICITEMS::ORC_TAUREN_SHAMAN_SHIRT, "Shaman's Shirt", 10058);
	CREATEPANTS(STATICITEMS::ORC_TAUREN_SHAMAN_PANTS, "Shaman's Pants", 10050);
	CREATESHIRT(STATICITEMS::TROLL_SHAMAN_SHIRT, "Shaman's Shirt", 10108);
	CREATEPANTS(STATICITEMS::TROLL_HUNTER_PANTS, "Shaman's Pants", 10109);
	
	CREATEPANTS(STATICITEMS::DRUID_PANTS, "Druid's Pants", 9987);
	CREATEROBE(STATICITEMS::NIGHTELF_DRUID_ROBE, "Druid's Robe", 12683);
	CREATEROBE(STATICITEMS::TAUREN_DRUID_ROBE, "Druid's Robe", 12684);
	pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->CreateStaff("Makeshift Staff", 3949);
	pTemplate->Data.DamageStats[0].Min = 10;
	pTemplate->Data.DamageStats[1].Max = 14;
	pTemplate->Data.WeaponSpeed = 2700;
	DataManager.NewObject(*pTemplate);
	STATICITEMS::NIGHTELF_DRUID_STAFF = pTemplate->guid;
	STATICITEMS::TAUREN_DRUID_STAFF = STATICITEMS::MAGE_STAFF;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->CreateOneHandAxe("Worn Axe", 8483);
	DataManager.NewObject(*pTemplate);
	STATICITEMS::HUNTER_AXE = pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->CreateBuckler("Worn Wooden Buckler", 1680);
	DataManager.NewObject(*pTemplate);
	STATICITEMS::HUNTER_SHIELD = pTemplate->guid;

	CREATESHIRT(STATICITEMS::DWARF_NIGHTELF_HUNTER_SHIRT, "Hunter's Shirt", 9976);
	CREATEPANTS(STATICITEMS::DWARF_NIGHTELF_HUNTER_PANTS, "Hunter's Pants", 9975);
	CREATEBOOTS(STATICITEMS::DWARF_NIGHTELF_HUNTER_BOOTS, "Hunter's Boots", 9977);
	CREATESHIRT(STATICITEMS::ORC_TAUREN_HUNTER_SHIRT, "Hunter's Shirt", 9996);
	CREATEPANTS(STATICITEMS::ORC_TAUREN_HUNTER_PANTS, "Hunter's Pants", 10002);
	CREATEBOOTS(STATICITEMS::ORC_HUNTER_BOOTS, "Hunter's Boots", 10003);
	CREATESHIRT(STATICITEMS::TROLL_HUNTER_SHIRT, "Hunter's Shirt", 10076);
	CREATEPANTS(STATICITEMS::TROLL_HUNTER_PANTS, "Hunter's Pants", 10244);

	pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->CreateAmmoPouch("Ammo Pouch", 1816);
	DataManager.NewObject(*pTemplate);
	STATICITEMS::HUNTER_AMMO_POUCH = pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->CreateArrowQuiver("Quiver", 5560);
	DataManager.NewObject(*pTemplate);
	STATICITEMS::HUNTER_QUIVER = pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->CreateBullet("Bullet", 5998);
	DataManager.NewObject(*pTemplate);
	STATICITEMS::HUNTER_BULLET = pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->CreateArrow("Arrow", 5996);
	DataManager.NewObject(*pTemplate);
	STATICITEMS::HUNTER_ARROW = pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->CreateGun("Rusty Rifle", 6606);
	DataManager.NewObject(*pTemplate);
	STATICITEMS::HUNTER_BULLET = pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->CreateBow("Cracked Shortbow", 8106);
	DataManager.NewObject(*pTemplate);
	STATICITEMS::HUNTER_BOW = pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->CreateTabard("Guild Tabard", 9688);
	DataManager.NewObject(*pTemplate);
	STATICITEMS::GUILD_TABARD = pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->CreateInvItem("Flypath Ticket 1", 0xE0);
	strcpy(pTemplate->Data.Text, "Buy this to activate a flypath");
	pTemplate->Data.OverallQuality = 2;
	DataManager.NewObject(*pTemplate);
	STATICITEMS::FLYPATH_ITEM1 = pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->CreateInvItem("Flypath Ticket 2", 0xE0);
	strcpy(pTemplate->Data.Text, "Buy this to activate a flypath");
	pTemplate->Data.OverallQuality = 2;
	DataManager.NewObject(*pTemplate);
	STATICITEMS::FLYPATH_ITEM2 = pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	pTemplate->CreateInvItem("Flypath Ticket 3", 0xE0);
	strcpy(pTemplate->Data.Text, "Buy this to activate a flypath");
	pTemplate->Data.OverallQuality = 2;
	DataManager.NewObject(*pTemplate);
	STATICITEMS::FLYPATH_ITEM3 = pTemplate->guid;

	CChatManager::InitCloaks();
#undef CREATEROBE
#undef CREATESHIRT
#undef CREATEPANTS
#undef CREATEBOOTS
#undef CREATEFOOD

	STATICITEMS::ITEMWDB_COUNT = 0;
	STATICITEMS::ITEMWDB_FIRST = pTemplate->guid+1;

	FILE *f = fopen("data/itemcache.wdb", STORAGE_READ);
	if(f == NULL)
		return;
	fseek(f, 0, SEEK_END);
	long size = ftell(f);
	if(size < 0x10)
	{
		fclose(f);
		return;
	}
	size -= 0x10;
	fseek(f, 0x10, SEEK_SET);
	char *buffer = (char*)malloc(size);
	if(buffer == NULL || fread(buffer, size, 1, f) != 1)
	{
		fclose(f);
		return;
	}
	fclose(f);
	long c = 0;
	while(c < size)
	{
		if(c+16 >= size)
			break;
		c += 8;
		pTemplate = new CItemTemplate;
		pTemplate->New();
		memcpy(&pTemplate->Data.Type, &buffer[c], 8);
		c += 8;
		strncpy(pTemplate->Data.Name, &buffer[c], 64);
		c += strlen(pTemplate->Data.Name)+1;
		if(c >= size)
			break;
		strncpy(pTemplate->Data.Name1, &buffer[c], 64);
		c += strlen(pTemplate->Data.Name1)+1;
		if(c >= size)
			break;
		strncpy(pTemplate->Data.Name2, &buffer[c], 64);
		c += strlen(pTemplate->Data.Name2)+1;
		if(c >= size)
			break;
		strncpy(pTemplate->Data.Name3, &buffer[c], 64);
		c += strlen(pTemplate->Data.Name3)+1;
		if(c+25*4 + sizeof(ItemAttribute)*10 + sizeof(DamageStat)*5 + sizeof(SpellStat)*5 >= size)
			break;
		memcpy(&pTemplate->Data.DisplayID, &buffer[c], 25*4 + sizeof(ItemAttribute)*10 + sizeof(DamageStat)*5 + sizeof(SpellStat)*5);
		c += 25*4 + sizeof(ItemAttribute)*10 + sizeof(DamageStat)*5 + sizeof(SpellStat)*5;

		strncpy(pTemplate->Data.Text, &buffer[c], 128);
		c += strlen(pTemplate->Data.Text)+1;
		if(c + 8*4 > size)
			break;
		memcpy(&pTemplate->Data.PageText,&buffer[c], 8*4);
		c += 8*4;
		DataManager.NewObject(*pTemplate);
		STATICITEMS::ITEMWDB_COUNT++;
	}

/*
	class CItemTemplate *pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"standard issue shirt");
	pTemplate->Data.Type=4;
	pTemplate->Data.Subtype=1;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_SHIRT;
	pTemplate->Data.Model=0x873; // apprentice shirt
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"standard issue pants");
	pTemplate->Data.Type=4;
	pTemplate->Data.Subtype=1;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_PANTS;
	pTemplate->Data.Model=0x26C4; // apprentice pants
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"standard issue robe");
	pTemplate->Data.Type=4;
	pTemplate->Data.Subtype=1;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_ROBE;
	pTemplate->Data.Model=0x2788; // apprentice robe
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"tan robe");
	pTemplate->Data.Type=4;
	pTemplate->Data.Subtype=1;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_ROBE;
	pTemplate->Data.Model=0xc3e; //
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"red robe");
	pTemplate->Data.Type=4;
	pTemplate->Data.Subtype=1;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_ROBE;
	pTemplate->Data.Model=0xc90; //
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"firey robe");
	pTemplate->Data.Type=4;
	pTemplate->Data.Subtype=1;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_ROBE;
	pTemplate->Data.Model=0x1192; //
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"standard issue cloak");
	pTemplate->Data.Type=4;
	pTemplate->Data.Subtype=1;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_BACK;
	pTemplate->Data.Model=0x2247; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;
	
	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"standard issue boots");
	pTemplate->Data.Type=4;
	pTemplate->Data.Subtype=1;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_BOOTS;
	pTemplate->Data.Model=0x26C9; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"standard issue cap");
	pTemplate->Data.Type=4;
	pTemplate->Data.Subtype=1;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_HEAD;
	pTemplate->Data.Model=0x46B; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"quarterstaff");
	pTemplate->Data.Type=2;
	pTemplate->Data.Subtype=10;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_2H;
	pTemplate->Data.Model=0x2bf3; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"sword");
	pTemplate->Data.Type=2;
	pTemplate->Data.Subtype=7;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_1H;
	pTemplate->Data.Model=0x610; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"katana");
	pTemplate->Data.Type=7;
	pTemplate->Data.Subtype=2;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_1H;
	pTemplate->Data.Model=0xdfb; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"axe");
	pTemplate->Data.Type=2;
	pTemplate->Data.Subtype=0;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_1H;
	pTemplate->Data.Model=0x5e9; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"hammer");
	pTemplate->Data.Type=2;
	pTemplate->Data.Subtype=4;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_1H;
	pTemplate->Data.Model=0x5ed; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"pick");
	pTemplate->Data.Type=0;
	pTemplate->Data.Subtype=2;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_1H;
	pTemplate->Data.Model=0x642; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"mace");
	pTemplate->Data.Type=2;
	pTemplate->Data.Subtype=4;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_1H;
	pTemplate->Data.Model=0x7ff; 
	pTemplate->Data.MinDamage=0x01;
	pTemplate->Data.MaxDamage=0x08;
	pTemplate->Data.MinLevel=0x01;
	pTemplate->Data.ItemLevel=0x04;
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"halberd");
	pTemplate->Data.Subtype=4;
	pTemplate->Data.Type=6;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_2H;
	pTemplate->Data.Model=0x6ae; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"spear");
	pTemplate->Data.Type=2;
	pTemplate->Data.Subtype=17;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_2H;
	pTemplate->Data.Model=0x173d; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"wand");
	pTemplate->Data.Type=2;
	pTemplate->Data.Subtype=19;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_1H;
	pTemplate->Data.Model=0x175a; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"throwing knife");
	pTemplate->Data.Type=2;
	pTemplate->Data.Subtype=16;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_1H;
	pTemplate->Data.Model=0x1246; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"rifle");
	pTemplate->Data.Type=2;
	pTemplate->Data.Subtype=3;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_2H;
	pTemplate->Data.Model=0x969; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"dirk");
	pTemplate->Data.Subtype=15;
	pTemplate->Data.Type=2;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_1H;
	pTemplate->Data.Model=0xa95; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"flowers");
	pTemplate->Data.Type=2;
	pTemplate->Data.Subtype=13;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_1H;
	pTemplate->Data.Model=0xaab; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"bow");
	pTemplate->Data.Type=2;
	pTemplate->Data.Subtype=2;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_1H;
	pTemplate->Data.Model=0xae2; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"chainmail tunic");
	pTemplate->Data.Type=4;
	pTemplate->Data.Subtype=3;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_CHEST;
	pTemplate->Data.Model=0x8ae; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;


	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"scalemail tunic");
	pTemplate->Data.Type=4;
	pTemplate->Data.Subtype=3;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_CHEST;
	pTemplate->Data.Model=0x10ee; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"samurai tunic");
	pTemplate->Data.Type=4;
	pTemplate->Data.Subtype=3;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_CHEST;
	pTemplate->Data.Model=0x1127; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"hawk tunic");
	pTemplate->Data.Type=4;
	pTemplate->Data.Subtype=3;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_CHEST;
	pTemplate->Data.Model=0x117a; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"red chainmail leggings");
	pTemplate->Data.Type=4;
	pTemplate->Data.Subtype=3;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_CHEST;
	pTemplate->Data.Model=0xbfd; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"plate breastplate");
	pTemplate->Data.Type=4;
	pTemplate->Data.Subtype=4;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_CHEST;
	pTemplate->Data.Model=0xb98; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"gold plate breastplate");
	pTemplate->Data.Type=4;
	pTemplate->Data.Subtype=4;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_CHEST;
	pTemplate->Data.Model=0xb9e; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"plate gauntlets");
	pTemplate->Data.Type=4;
	pTemplate->Data.Subtype=4;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_HAND;
	pTemplate->Data.Model=0xc7b; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"chainmail gauntlets");
	pTemplate->Data.Type=4;
	pTemplate->Data.Subtype=3;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_HAND;
	pTemplate->Data.Model=0xcF0; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"bullets");
	pTemplate->Data.Type=6;
	pTemplate->Data.Subtype=3;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_RANGED;
	pTemplate->Data.Model=0xcF0; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"arrows");
	pTemplate->Data.Type=6;
	pTemplate->Data.Subtype=2;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_RANGED;
	pTemplate->Data.Model=0xcF0; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"bolts");
	pTemplate->Data.Type=6;
	pTemplate->Data.Subtype=1;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Worn=WORN_RANGED;
	pTemplate->Data.Model=0xcF0; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"quiver (arrows)");
	pTemplate->Data.Type=0x0B;
	pTemplate->Data.Subtype=2;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Model=0xcF0; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"quiver (bolts)");
	pTemplate->Data.Type=0xB;
	pTemplate->Data.Subtype=1;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Model=0xcF0; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"ammo pouch");
	pTemplate->Data.Type=0xB;
	pTemplate->Data.Subtype=3;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Model=0xcF0; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;

	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"bag");
	pTemplate->Data.Type=1;
	pTemplate->Data.Subtype=0;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Model=0x39d; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;
	
	pTemplate = new CItemTemplate;
	pTemplate->New();
	strcpy(pTemplate->Data.Name,"Guild Tabard");
	pTemplate->Data.Type=1;
	pTemplate->Data.Subtype=0;
	pTemplate->Data.Color = 1;
	pTemplate->Data.Worn = WORN_TABARD;
	pTemplate->Data.ItemLevel=1;
	pTemplate->Data.Model=0x25D8; 
	DataManager.NewObject(*pTemplate);
	DataManager.ItemTemplates[pTemplate->Data.Name]=pTemplate->guid;
*/
	/*
	CCreatureTemplate *CreatureTemplate = new CCreatureTemplate;
	CCreature *Creature = new CCreature;
	CreatureTemplate->New("Lax's Bitch");
	Creature->New(CreatureTemplate->guid);
	DataManager.NewObject(*Creature);
	DataManager.NewObject(*CreatureTemplate);
	Creature->Data.CurrentStats.HitPoints=5000;
	Creature->Data.Level=100;
	Creature->Data.Model=0x466;
	Creature->Data.NormalStats.HitPoints=5000;
	Creature->Data.DamageMax=6;
	Creature->Data.DamageMin=4;
	/**/
}
class CCreature *CRealmServer::GenerateCreature(unsigned long Model, const char *Name, unsigned long Continent,
																								 _Location Loc, float Facing)
{
	CCreatureTemplate *CreatureTemplate = new CCreatureTemplate;
	CCreature *Creature = new CCreature;
	CreatureTemplate->New(Name);
	CreatureTemplate->Generated=true;
	Creature->New(CreatureTemplate->guid);
	strcpy(Creature->Data.Name,Name);
	Creature->Data.CurrentStats.HitPoints=65;
	Creature->Data.Level=1;
	Creature->Data.Model=Model;
	Creature->Data.NormalStats.HitPoints=65;
	Creature->Data.DamageMax=6;
	Creature->Data.DamageMin=4;
	Creature->Data.Exp = 200;
	Creature->Data.Continent=Continent;
	Creature->Data.SpawnLoc=Loc;
	Creature->Data.Loc=Loc;
	Creature->Data.SpawnFacing=Facing;
	Creature->Data.Facing=Facing;
	DataManager.NewObject(*CreatureTemplate);
	DataManager.NewObject(*Creature);
	
	// lets make him despawn.
	// creatures will live for 300 seconds  (5 minutes)
	//EventManager.AddEvent(*Creature,300000,EVENT_CREATURE_DESPAWN,0,0);
	EventManager.AddEvent(*Creature,10000,EVENT_CREATURE_REGENERATE,0,0);
	return Creature;
}

void CRealmServer::BroadcastOutPacket(unsigned short OpCode, void *buffer, unsigned short Length)
{
	CLock L(&Clients.CS);// exclusive lock on clients for this, not guaranteed to be in the realm server thread
	for (unsigned long i = 0 ; i < Clients.Size ; i++)
	{
		if (CClient *pClient=Clients[i])
		{
//			if (pClient->pPlayer)
				pClient->OutPacket(OpCode,buffer,Length);
		}
	}
}

