// (c) AbyssX Group
#include "../WorldEnvironment.h"

template <class PlayersHandler> PlayersHandler *Singleton<PlayersHandler>::msSingleton = 0;

PlayersHandler::PlayersHandler()
{
}

PlayersHandler::~PlayersHandler()
{
}

DoubleWord PlayersHandler::HandlePackets(Client *cli, Packet *pack)
{
	switch (pack->GetOpCode())
	{
			case CMSG_CHAR_ENUM:
				HandlerMSG_CHAR_ENUM(cli, pack);
				return 1;
				break;
			case CMSG_CHAR_CREATE:
				HandlerMSG_CHAR_CREATE(cli, pack);
				return 1;
				break;
			case CMSG_CHAR_DELETE:
				HandlerMSG_CHAR_DELETE(cli, pack);
				return 1;
				break;
			case CMSG_PLAYER_LOGIN:
				HandlerMSG_PLAYER_LOGIN(cli, pack);
				return 1;
				break;
			case CMSG_LOGOUT_REQUEST:
				HandlerMSG_LOGOUT_REQUEST(cli, pack);
				return 1;
				break;
			case CMSG_NAME_QUERY:
				HandlerMSG_NAME_QUERY(cli, pack);
				return 1;
				break;
			case CMSG_ZONEUPDATE:
				HandlerMSG_ZONEUPDATE(cli, pack);
				return 1;
				break;
			case MSG_MOVE_WORLDPORT_ACK:
				HandlerMSG_MOVE_WORLDPORT_ACK(cli, pack);
				return 1;
				break;
			case CMSG_REPOP_REQUEST:
				HandlerMSG_REPOP_REQUEST(cli, pack);
				return 1;
				break;
			case CMSG_SETSHEATHED:
				HandlerMSG_SETSHEATHED(cli, pack);
				return 1;
				break;
			case CMSG_WHO:
				HandlerMSG_WHO(cli, pack);
				return 1;
				break;
	}

	return 0;
}

void PlayersHandler::HandlerMSG_CHAR_ENUM(Client *cli, Packet *pack)
{
	Byte cnt;
	ObjectManager<Player *>::ObjectManagerIterator i;
	Player *ply;

	LogManager::GetSingleton().Log("Debug.log", ">>> CMSG_CHAR_ENUM (%s)(%s)\n", cli->GetHost().c_str(), WorldServer::GetSingleton().mUserID[cli].c_str());
	
	cnt = 0;
	for (i = mPlayers.Begin(); i != mPlayers.End(); i++)
	{
		if ((*i).second->mAccount == WorldServer::GetSingleton().mUserID[cli])
			cnt++;
	}

	LogManager::GetSingleton().Log("Debug.log", "Account has %d players\n",
		cnt);
	
	pack->Build(SMSG_CHAR_ENUM);
	pack->AddByte(cnt);  // player count
	
	if (cnt)
	{
		for (i = mPlayers.Begin(); i != mPlayers.End(); i++)
		{
			ply = (*i).second;
			if (ply->mAccount != WorldServer::GetSingleton().mUserID[cli])
				continue;

			LogManager::GetSingleton().Log("Debug.log",
				"Player '%s' with GUID: " I64FMT "\n",
				ply->GetName().c_str(), ply->GetObjectGuid());

			// GUID
			pack->AddQuadWord(ply->GetObjectGuid());
			// Name
			pack->AddBytes((Byte *)ply->GetName().c_str(), (DoubleWord)ply->GetName().length() + 1);
			// Race, Class, Gender, Skin, Face, HairStyle, HairColor, FacialHair
			pack->AddByte(ply->GetRace()); pack->AddByte(ply->GetClass());
			pack->AddByte(ply->GetGender()); pack->AddByte(ply->GetSkinType());
			pack->AddByte(ply->GetFaceType()); pack->AddByte(ply->GetHairStyle());
			pack->AddByte(ply->GetHairColor()); pack->AddByte(ply->GetFacialHairType());
			// Level
			pack->AddByte(ply->GetLevel());
			// ZoneId
			pack->AddDoubleWord(ply->GetCurrentZone());
			// MapId
			pack->AddDoubleWord(ply->GetCurrentMap());
			// PosX, PosY, PosZ
			pack->AddFloat(ply->GetXCoordinate());
			pack->AddFloat(ply->GetYCoordinate());
			pack->AddFloat(ply->GetZCoordinate());
			// GuildId
			pack->AddDoubleWord(0);
			// Locked Out
			pack->AddDoubleWord(0);
			// Rest State
			pack->AddByte(ply->GetRestState());
			// PetDisplayInfo, PetExpLevel, PetFamily
			pack->AddDoubleWord(0); pack->AddDoubleWord(0); pack->AddDoubleWord(0);
			// Inventory
			for (cnt = 0; cnt < 20; cnt++)
			{
#ifdef ITEMS
				Player_Item *pitem = ply->FindPlayerItem(ply->GetInventory(cnt));

				if (pitem)
				{
					Item *itm = Items_Handler::GetSingleton().FindItem(pitem->Entry);
					// DisplayId
					pack->AddDoubleWord(itm->ItemDATA.DisplayID);
					// Type
					pack->AddByte(itm->ItemDATA.InvType);

				}
				else
				{
#endif
					pack->AddDoubleWord(0);
					pack->AddByte(0);
#ifdef ITEMS
				}
#endif
			}
		}
	}

	WorldServer::GetSingleton().WriteData(cli, pack);

	LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_CHAR_ENUM\n");
}

void PlayersHandler::HandlerMSG_CHAR_DELETE(Client *cli, Packet *pack)
{
	ObjectManager<Player *>::ObjectManagerIterator i;
	Packet retpack;
	Player *ply;

	LogManager::GetSingleton().Log("Debug.log", ">>> CMSG_CHAR_DELETE (%s)(%s)\n", cli->GetHost().c_str(), WorldServer::GetSingleton().mUserID[cli].c_str());

	ply = FindPlayer(pack->GetQuadWord(0x00));
	if (!ply)
	{
		LogManager::GetSingleton().Log("Debug.log", "Player not found!\n");
		return;
	}
	if (ply->mAccount != WorldServer::GetSingleton().mUserID[cli])
	{
		LogManager::GetSingleton().Log("Debug.log", "Deleting someone else's player?!\n");
		return;
	}

	for (i = mPlayers.Begin(); i != mPlayers.End(); i++)
	{
		if ((*i).second == ply)
			break;
	}
	mPlayers.RemoveObject(i);

	retpack.Build(SMSG_CHAR_DELETE);
	retpack.AddByte(0x00);
	WorldServer::GetSingleton().WriteData(cli, &retpack);

	LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_CHAR_DELETE\n");
}

void PlayersHandler::HandlerMSG_CHAR_CREATE(Client *cli, Packet *pack)
{
	char *plyname;
	Byte retcode;
	unsigned int i;

	LogManager::GetSingleton().Log("Debug.log", ">>> CMSG_CHAR_CREATE (%s)(%s)\n", cli->GetHost().c_str(), WorldServer::GetSingleton().mUserID[cli].c_str());

	plyname = (char *) pack->GetBytes(0x00);

	// Check to see if name is valid
	retcode = 40;
	if (strlen(plyname) < 3)
		retcode = 56; // Name must be atleast 3 letters long (handled by client?)
	else if (strlen(plyname) > 12)
		retcode = 57; // Name cannot be longer than 12 letters (handled by client?)
	else
	{
		for (i = 0; i < strlen(plyname); i++)
		{
			if (plyname[i] >= 'a' && plyname[i] <= 'z')
				continue;
			if (plyname[i] >= 'A' && plyname[i] <= 'Z')
				continue;
			retcode = 58; // Name can contain only letters
			break;
		}	
	}
	
	if (retcode != 40)
	{
		LogManager::GetSingleton().Log("Debug.log",
			"Player name '%s' is invalid\n", plyname);
		pack->Build(SMSG_CHAR_CREATE);
		pack->AddByte(retcode);
		WorldServer::GetSingleton().WriteData(cli, pack);
		LogManager::GetSingleton().Log("Debug.log",	"<<< SMSG_CHAR_CREATE\n");
		return;
	}

	if (FindPlayer(plyname))
	{
		LogManager::GetSingleton().Log("Debug.log",
			"Player '%s' already exists\n",
			plyname);

		pack->Build(SMSG_CHAR_CREATE);
		pack->AddByte(43);
		WorldServer::GetSingleton().WriteData(cli, pack);
		LogManager::GetSingleton().Log("Debug.log",	"<<< SMSG_CHAR_CREATE\n");
		return;
	}

	Player *ply;

	ply = new Player(WorldServer::GetSingleton().mNextGUID++, plyname, 0, NULL);
	ply->mAccount = WorldServer::GetSingleton().mUserID[cli];
	ply->SetCommunication(true);
	ply->SetRegenerationStatus(false);
	ply->SetGM(false);
	ply->SetMount(false);
	ply->SetFlying(false);
	ply->SetPvPState(false);
	ply->SetDeadState(false);
	ply->SetResSickness(false);
	ply->SetStatus(STATUS_NORMAL);
	ply->SetLootTarget(0);
	ply->SetMoney(10);
	ply->mDamages.BPhysicalMAX = (10);
	ply->mDamages.BPhysicalMIN = (10/3);
	ply->SetParty(NULL);
	ply->SetUnitFlags(UNIT_FLAG_SHEATHE);
	ply->SetGhost(false);
	ply->SetArmed(false);
	ply->SetAttackState(false);
	ply->SetMoved(false);
	ply->SetPlayerEmote(0);
	ply->SetDynamicFlags(0);
	ply->SetMountModel(0);
	ply->SetLevel(1);
	ply->SetStandState(0);
	ply->SetExperiencePoints(0);
	ply->SetExperienceNextLevel(1000);
	ply->SetHealth(100);
	ply->SetMaximumHealth(100);
	ply->SetRace(pack->GetByte(pack->GetByteAfterString(0x00) + 0));
	ply->SetClass(pack->GetByte(pack->GetByteAfterString(0x00) + 1));
	ply->SetGender(pack->GetByte(pack->GetByteAfterString(0x00) + 2));
	ply->SetSkinType(pack->GetByte(pack->GetByteAfterString(0x00) + 3));
	ply->SetFaceType(pack->GetByte(pack->GetByteAfterString(0x00) + 4));
	ply->SetHairStyle(pack->GetByte(pack->GetByteAfterString(0x00) + 5));
	ply->SetHairColor(pack->GetByte(pack->GetByteAfterString(0x00) + 6));
	ply->SetFacialHairType(pack->GetByte(pack->GetByteAfterString(0x00) + 7));
	ply->SetCurrentZone(ply->GetStartZone()); 
	ply->SetCurrentMap(ply->GetStartMap());
	ply->SetStartCoordinates();
	ply->ClearMoveFlag(0xFFFFFFFF);
	ply->SetScale(1.0f);
	ply->SetRestState(1);
	ply->SetRaceFaction();
	ply->SetMovie(false);
	ply->SetMana(100);
	ply->SetMaximumMana(100);

	ply->mStats.BStrenght = 15;
	ply->mStats.BAgility = 15;
	ply->mStats.BSpirit = 15;
	ply->mStats.BStamina = 15;
	ply->mStats.BIntellect = 15;

#ifdef ITEMS
	ply->GetStartingItems();
#endif

	mPlayers.AddObject(ply->GetObjectGuid(), ply);

	LogManager::GetSingleton().Log("Debug.log",
		"Created player '%s' with GUID: " I64FMT "\n",
		ply->GetName().c_str(), ply->GetObjectGuid());

	pack->Build(SMSG_CHAR_CREATE);
	pack->AddByte(40);
	WorldServer::GetSingleton().WriteData(cli, pack);

	LogManager::GetSingleton().Log("Debug.log",  "<<< SMSG_CHAR_CREATE\n");
}

void PlayersHandler::HandlerMSG_PLAYER_LOGIN(Client *cli, Packet *pack)
{
	Player *ply;
	Packet retpack;

	LogManager::GetSingleton().Log("Debug.log", ">>> CMSG_PLAYER_LOGIN (%s)(%s)\n",	cli->GetHost().c_str(), WorldServer::GetSingleton().mUserID[cli].c_str());
	LogManager::GetSingleton().Log("Debug.log",	"Logging in following GUID: " I64FMT "\n", pack->GetQuadWord(0x00));

	ply = FindPlayer(pack->GetQuadWord(0x00));
	if (!ply)
	{
		LogManager::GetSingleton().Log("Debug.log", "Could not find GUID!\n");
		return; // should not happen
	}

	LogManager::GetSingleton().Log("Debug.log", "Logging in '%s'\n", ply->GetName().c_str());

	ply->SetClient(cli);

	pack->Build(SMSG_ACCOUNT_DATA_MD5);
	for (DoubleWord cnt = 0; cnt < 80; cnt++)
		pack->AddByte(0x00);
	WorldServer::GetSingleton().WriteData(cli, pack);
	LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_ACCOUNT_DATA_MD5\n");

	for(unsigned long i = 0;i < 5;i++)
	{
		pack->Build(SMSG_UPDATE_ACCOUNT_DATA);
		pack->AddDoubleWord(i);
		pack->AddDoubleWord(0);
		WorldServer::GetSingleton().WriteData(cli, pack);
		LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_ACCOUNT_DATA_MD5\n");
	}

	pack->Build(SMSG_TUTORIAL_FLAGS);
	pack->AddDoubleWord(0x00);
	pack->AddDoubleWord(0x00);
	pack->AddDoubleWord(0x00);
	pack->AddDoubleWord(0x00);
	pack->AddDoubleWord(0x00);
	WorldServer::GetSingleton().WriteData(cli, pack);
	LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_TUTORIAL_FLAGS\n");
	
	pack->Build(SMSG_LOGIN_SETTIMESPEED);
	pack->AddDoubleWord(WorldServer::GetSingleton().GetGameTime());
	pack->AddDoubleWord(0);
	WorldServer::GetSingleton().WriteData(cli, pack);
	LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_LOGIN_SETTIMESPEED\n");

	PlayerJoinedWorld(ply);

	WorldServer::GetSingleton().UpdatePlayers(true);

	time_t now;
	time(&now);

	double elapsed = difftime(now,WorldServer::GetSingleton().uptime.TimeStamp);

	DoubleWord hs =  (DoubleWord)elapsed/3600;
	DoubleWord mns = (DoubleWord)elapsed/60 - (hs * 60);

	WorldServer::GetSingleton().AnnounceTo(cli, "[World-Server] - Welcome to the server: "SERVER_NAME);
	WorldServer::GetSingleton().AnnounceTo(cli, "[World-Server] - "IRC_INFO);
	
	WorldServer::GetSingleton().AnnounceTo(cli, "[World-Server] - Server Status: [%d Users Playing - %d Users Allowed] Uptime: [%d Hours - %d Minutes]",WorldServer::GetSingleton().Quantity,WorldServer::GetSingleton().MAX_PLAYERS,hs,mns);
	WorldServer::GetSingleton().AnnounceTo(cli, "");
	WorldServer::GetSingleton().AnnounceTo(cli, "[World-Server] - Enter !help for look the avaiable commands.");

	retpack.Build(SMSG_FORCE_SPEED_CHANGE);
	retpack.AddQuadWord(ply->GetObjectGuid());

	if (ply->IsMounted() && !ply->GetFlying())
		retpack.AddFloat(RUN_SPEED * 2);
	else
		retpack.AddFloat(RUN_SPEED);

	if (ply->GetClient())
		WorldServer::GetSingleton().WriteData(cli,&retpack);

	if (ply->GetGhost())
	{
		ply->SetResSickness(true);
		ply->RessurectionSickness();
	}
}

void PlayersHandler::HandlerMSG_LOGOUT_REQUEST(Client *cli, Packet *pack)
{
	Player *ply;
	
	ply = FindPlayer(cli);
	LogManager::GetSingleton().Log("Debug.log", ">>> CMSG_LOGOUT_REQUEST (%s)(%s)(%s)\n", cli->GetHost().c_str(), WorldServer::GetSingleton().mUserID[cli].c_str(), ply ? ply->GetName().c_str() : "");
	
	if (!ply)
	{
		LogManager::GetSingleton().Log("Debug.log",
			"Connection is not logged in with a player!\n");
		return; // should not happen
	}

	PlayerLeftWorld(ply);

	pack->Build(SMSG_LOGOUT_COMPLETE);
	WorldServer::GetSingleton().WriteData(cli, pack);
	LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_LOGOUT_COMPLETE\n");
}

void PlayersHandler::HandlerMSG_NAME_QUERY(Client *cli, Packet *pack)
{
	Player *ply;

	ply = FindPlayer(cli);
	LogManager::GetSingleton().Log("Debug.log", ">>> CMSG_NAME_QUERY (%s)(%s)(%s)\n", cli->GetHost().c_str(), WorldServer::GetSingleton().mUserID[cli].c_str(), ply ? ply->GetName().c_str() : "");

	ply = FindPlayer(pack->GetQuadWord(0x00));
	if (!ply)
	{
		LogManager::GetSingleton().Log("Debug.log", "Cannot find GUID!\n");
		return; // should not happen
	}

	LogManager::GetSingleton().Log("Debug.log", "Found: '%s'\n",
		ply->GetName().c_str());

	pack->Build(SMSG_NAME_QUERY_RESPONSE);

	// GUID
	pack->AddQuadWord(ply->GetObjectGuid());

	// Name
	pack->AddBytes((Byte *)ply->GetName().c_str(), (DoubleWord)ply->GetName().length() + 1);
	pack->AddBytes((Byte *)ply->GetName().c_str(), (DoubleWord)ply->GetName().length() + 1);
	pack->AddBytes((Byte *)ply->GetName().c_str(), (DoubleWord)ply->GetName().length() + 1);
	pack->AddBytes((Byte *)ply->GetName().c_str(), (DoubleWord)ply->GetName().length() + 1);

	// Guild Name
	pack->AddBytes((Byte *)ply->GetGuildName().c_str(), (DoubleWord)ply->GetGuildName().length() + 1);

	pack->AddDoubleWord(0);
	pack->AddDoubleWord(0);
	pack->AddDoubleWord(0);
	pack->AddDoubleWord(0);
	WorldServer::GetSingleton().WriteData(cli, pack);
	LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_NAME_QUERY_RESPONSE\n");
}

void PlayersHandler::HandlerMSG_WHO(Client *cli, Packet *pack)
{
	ObjectManager<Player *>::ObjectManagerIterator i;
	Packet retpack;
	int count = 0;
	const char *guild = "Not Available";
	Player *ply;

	ply = FindPlayer(cli);
	LogManager::GetSingleton().Log("Debug.log", ">>> CMSG_WHO (%s)(%s)(%s)\n", cli->GetHost().c_str(), WorldServer::GetSingleton().mUserID[cli].c_str(), ply ? ply->GetName().c_str() : "");

	for (i = mPlayers.Begin(); i != mPlayers.End(); i++)
	{
		if (!(*i).second->GetClient())
			continue;

		count++;
	}

	retpack.Build(SMSG_WHO);
	retpack.AddDoubleWord(count); // Showing Currently Players (NUMBER).
	retpack.AddDoubleWord(count); // Found (NUMBER) of Players.
	// DATA LOOP
	for (i = mPlayers.Begin(); i != mPlayers.End(); i++)
	{
		if (!(*i).second->GetClient())
			continue;
	
		retpack.AddBytes((Byte *)(*i).second->GetName().c_str(),
			(Word)(*i).second->GetName().length()); // NickName in String Format.
		retpack.AddByte(0x00); // Null Padding.
		retpack.AddBytes((Byte *)guild, (Word)strlen(guild)); // Guild Name in String Format.
		retpack.AddByte(0x00); // Null Padding.
		retpack.AddDoubleWord((*i).second->GetLevel()); // Current Player Level.
		retpack.AddDoubleWord((*i).second->GetClass()); // Current Player Class.
		retpack.AddDoubleWord((*i).second->GetRace()); // Current Player Race.
		retpack.AddDoubleWord((*i).second->GetCurrentZone()); // Current Player Zone.
		retpack.AddDoubleWord(0); // Currently Group Status.
	}
	// DATA LOOP

	WorldServer::GetSingleton().WriteData(cli, &retpack);
	LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_WHO\n");
}

void PlayersHandler::HandlerMSG_ZONEUPDATE(Client *cli, Packet *pack)
{
	Player *ply;
	
	ply = FindPlayer(cli);

	LogManager::GetSingleton().Log("Debug.log", ">>> CMSG_ZONEUPDATE (%s)(%s)(%s)\n", cli->GetHost().c_str(), WorldServer::GetSingleton().mUserID[cli].c_str(), ply ? ply->GetName().c_str() : "");

	if (!ply)
	{
		LogManager::GetSingleton().Log("Debug.log",
			"Connection is not logged in with a player!\n");
		return; // should not happen
	}

	ply->SetCurrentZone(pack->GetDoubleWord(0x00));
}

void PlayersHandler::HandlerMSG_MOVE_WORLDPORT_ACK(Client *cli, Packet *pack)
{
	Player *ply;
	Packet retpack;
	
	ply = FindPlayer(cli);
	LogManager::GetSingleton().Log("Debug.log", ">>> MSG_MOVE_WORLDPORT_ACK (%s)(%s)(%s)\n", cli->GetHost().c_str(), WorldServer::GetSingleton().mUserID[cli].c_str(), ply ? ply->GetName().c_str() : "");
	
	if (!ply)
	{
		LogManager::GetSingleton().Log("Debug.log",	"Connection is not logged in with a player!\n");
		return; // should not happen
	}

	Packets::NewObjectHeader(ply,&retpack,true);
	Packets::NewObjectData(ply,&retpack);
	WorldServer::GetSingleton().WriteData(cli, &retpack);

#ifdef ITEMS
	ply->CreateItems(NULL,0);
#endif

	MapChange(ply,0xFF,false);
}

void PlayersHandler::HandlerMSG_REPOP_REQUEST(Client *cli, Packet *pack)
{
	Player *ply = FindPlayer(cli);
	Packet retpack;
	ObjectUpdate objupd;

	if (!ply)
		return;

	ply->SetHealth(1);
	ply->SetDeadState(false);
	ply->SetResSickness(true);
	ply->RessurectionSickness();
	ply->SetStandState(0x00);//Standing
	ply->SetUnitFlags(UNIT_FLAG_GHOST | UNIT_FLAG_SHEATHE);
	ply->SetArmed(false);
	ply->SetGhost(true);
	ply->SetAttackState(false);

	Packets::UpdateObjectHeader(ply,&retpack);

	objupd.Clear();
	objupd.Touch(ObjectUpdate::UPDOBJECT);
	objupd.Touch(ObjectUpdate::UPDUNIT);
	objupd.Touch(ObjectUpdate::UPDPLAYER);
	
	// 0xAABBCCDD where AA == weaponmode, BB == ?, CC == ?, DD == standstate
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_BYTES_1,
		((DoubleWord)0xEE              << 24) |
		((DoubleWord)0x00              << 16) |
		((DoubleWord)0xEE              <<  8) |
		((DoubleWord)ply->GetStandState() <<  0));
	
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_HEALTH, ply->GetHealth());

	// Unit Flags
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_FLAGS, ply->GetUnitFlags());
	
	retpack.AddObjectUpdate(&objupd);

	WorldServer::GetSingleton().SendToPlayersInRange(&retpack, ply);

	WorldServer::GetSingleton().AnnounceTo(cli,"[World-Server] - You have died and now your body need 60 seconds till GOD materialize's it again...");
}

void PlayersHandler::HandlerMSG_SETSHEATHED(Client *cli, Packet *pack)
{
	Player *ply = FindPlayer(cli);

	if (!ply)
		return;

	ply->Sheathe();
}

void PlayersHandler::PlayerJoinedWorld(Player *ply)
{
	Packet pack;
	RegionList regionList;
	RegionList::RegionListIterator i;
	Region::PlayerIterator j;
	Region::ObjectIterator t;
	Player *p;
#ifdef MOBS
	Mob *m;
#endif
	// First, tell us about ourselves
	Packets::NewObjectHeader(ply,&pack,true);
	Packets::NewObjectData(ply,&pack);
	WorldServer::GetSingleton().WriteData(ply->GetClient(), &pack);

#ifdef ITEMS
	ply->CreateItems(NULL,0);
#endif

	LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_UPDATE_OBJECT\n");

	// *******************
	// REGION SYSTEM CODE!
	// *******************
	// Make sure this player is inserted into the region system.
	WorldServer::GetSingleton().mRegionManagers[ply->GetCurrentMap()]->UpdatePlayer(ply);
	ply->SetCurrentRegionList(WorldServer::GetSingleton().mRegionManagers[ply->GetCurrentMap()]->GetRegionsWithinRange(ply, RegionManager::RANGETYPE_3X3));

	// Then, tell the new player about all the others within range.
	regionList = ply->GetCurrentRegionList();

	for (i = regionList.Begin(); i != regionList.End(); i++)
	{
		for (j = (*i)->PlayerBegin(); j != (*i)->PlayerEnd(); j++)
		{
			p = (Player *) *j;
			if (!p->GetClient())
				continue; // don't bother if not logged in
			if (p == ply)
				continue; // don't tell us about ourselves

			Packets::NewObjectHeader(p,&pack,false);
			Packets::NewObjectData(p,&pack);

			ply->AddCreatedPlayer(p);
			WorldServer::GetSingleton().WriteData(ply->GetClient(), &pack);
#ifdef ITEMS
			ply->CreateItems(p,1);
#endif
			LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_UPDATE_OBJECT\n");
		}

#ifdef MOBS
		for (t = (*i)->ObjectBegin(); t != (*i)->ObjectEnd(); t++)
		{
			if (ply->GetClient())
			{
				m = (Mob *) *t;
			
				if (m->GetNPCFlags() != 0)
					m->SetFaction(ply->GetFaction());
	
				Packets::NewObjectHeader(m,&pack);
				Packets::NewObjectData(m,&pack);
				ply->AddCreatedMob(m);

				WorldServer::GetSingleton().WriteData(ply->GetClient(), &pack);

				LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_UPDATE_OBJECT\n");
			}
		}
#endif
	}


	// Then, tell all the other players within range about us, and add them to the new player's
	// created-for list.
	Packets::NewObjectHeader(ply,&pack,false);
	Packets::NewObjectData(ply,&pack);

	for (i = regionList.Begin(); i != regionList.End(); i++)
	{
		for (j = (*i)->PlayerBegin(); j != (*i)->PlayerEnd(); j++)
		{
			p = (Player *) *j;
			if (!p->GetClient())
				continue; // don't bother if not logged in
			if (p == ply)
				continue;
			
			// Add the player to each others lists. They now know of eachother.
			p->AddCreatedPlayer(ply);
			WorldServer::GetSingleton().WriteData(p->GetClient(), &pack);
#ifdef ITEMS
			p->CreateItems(ply,1);
#endif
			LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_UPDATE_OBJECT\n");
		}
	}

	// Announce this join to everyone.
	WorldServer::GetSingleton().AnnounceToAll("[World-Server] -> %s joined world with GUID: " I64FMTD,ply->GetName().c_str(),	ply->GetObjectGuid());

	ply->GetPlayerMovie();
}

void PlayersHandler::PlayerLeftWorld(Player *ply)
{
	Packet pack;
	Player::PlayersCreatedIterator i;

	//Deleting all Pending Events of the Player...
	EventSystem::GetSingleton().DeleteTimer(10001,ply->GetObjectGuid());

	if (ply->GetFlying())
	{
		ply->SetFlying(false);
		ply->Mount();
		ply->UnROOT();
	}
	
	//First, and before all else, remove self from all channels
	#ifdef CHANNELS
		ply->ClearChannels();
	#endif
	
	// Send DESTROY-msg to all players that the player logging out knows of. Also remove himself
	// from their created lists so they don't know eachother any more.
	for (i = ply->PlayersCreatedBegin(); i != ply->PlayersCreatedEnd(); i++)
	{
		if (!(*i).second->GetClient() || (*i).second == ply)
			continue;
		
		// Remove the player logging out from this player's created list.
		(*i).second->RemoveCreatedPlayer(ply);

		pack.Build(SMSG_DESTROY_OBJECT);
		pack.AddQuadWord(ply->GetObjectGuid());
		WorldServer::GetSingleton().WriteData((*i).second->GetClient(), &pack);
		LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_DESTROY_OBJECT\n");
	}

	// We need to clear the list of created-for players because the player object is persistent the whole
	// server session.
	ply->ClearCreatedPlayers();
	ply->ClearCreatedMobs();

	// Announce the logout to everyone.
	WorldServer::GetSingleton().AnnounceToAll("[World-Server] -> %s left world with GUID: " I64FMTD, ply->GetName().c_str(), ply->GetObjectGuid());

	
	// *******************
	// REGION SYSTEM CODE!
	// *******************
	// Remove player from region system.
	if (ply->GetCurrentRegion())
		WorldServer::GetSingleton().mRegionManagers[ply->GetCurrentMap()]->RemovePlayer(ply);

	ply->SetClient(NULL);
	ply->SetLastMovePacket(NULL);
	ply->SetLastStrafePacket(NULL);
	ply->SetLastSwimPacket(NULL);
	ply->SetLastTurnPacket(NULL);
	ply->SetLastWalkPacket(NULL);

#ifdef GROUPS
	if (ply->GetParty())
		GroupsHandler::GetSingleton().RemoveFromGroup(ply);
#endif

#ifdef CHANNELS
	// Remove player from all channels
	// Silent Fix That! IT Crashes when the nick is null!
	// I Added an Check But Didnt worked :P
	Player::ChannelsIterator j;
	for(j=ply->ChannelsBegin();j!=ply->ChannelsEnd();j++)
	{
		string cName = (*j)->GetName();
		WorldServer::GetSingleton().CHandler.mChannelManager->PlayerLeftChannel(ply,cName,false);
	}
#endif
	WorldServer::GetSingleton().UpdatePlayers(false);
}

/*void PlayersHandler::CheckRegion(Player *ply, Byte oldmap, bool part2)
{
	if (oldmap != ply->GetCurrentMap())
	{
		// We've switched maps
		// There are two 'parts' to a inter-map change. The first part,
		// we just delete ourself from everybody, the second part has to
		// happen AFTER the WORLDPORT_ACK. This function is a 'two-part'
		// function. The second part is called from WORLDPORT_ACK
		if (!part2)
		{
			//Destroying Objects in Range

			Packet pack;
			Player::PlayersCreatedIterator i;
			Player::MobsCreatedIterator m;
			Region *returnRegion;
	
			// Send DESTROY-msg to all players that the player changing maps
			// knows of. Also remove himself from their created lists so they
			// don't know eachother any more.

			for (i = ply->PlayersCreatedBegin(); i != ply->PlayersCreatedEnd(); i++)
			{
				if (!(*i).second->GetClient() || (*i).second == ply)
					continue;
		
				// Remove the player leaving from this player's created list.
				(*i).second->RemoveCreatedPlayer(ply);

				pack.Build(SMSG_DESTROY_OBJECT);
				pack.AddQuadWord(ply->GetObjectGuid());
				WorldServer::GetSingleton().WriteData((*i).second->GetClient(), &pack);
			}

			// We need to clear the list of created-for players because the player
			// is changing maps
			ply->ClearCreatedPlayers();
#ifdef MOBS
			ply->ClearCreatedMobs();
#endif
			// Remove player from region system.
			WorldServer::GetSingleton().mRegionManagers[oldmap]->RemovePlayer(ply);

			// Add ourselves to the new region system
			returnRegion = WorldServer::GetSingleton().mRegionManagers[ply->GetCurrentMap()]->UpdatePlayer(ply);
			if (returnRegion == RegionManager::BadRegion)
			{
				// We have moved out of bounds. For now, forcibly set the player
				// back to start position and boot the player to avoid hell.
				ply->SetStartCoordinates();
				ply->SetCurrentMap(ply->GetStartMap());
				ply->SetCurrentZone(ply->GetStartZone());
				WorldServer::GetSingleton().AnnounceTo(ply->GetClient(), "[World-Server] - The Server Detected a BAD REGION! Disconnecting Bugged Player!");
				WorldServer::GetSingleton().CloseConnection(ply->GetClient());
				return;
			}
			ply->SetCurrentRegionList(
				WorldServer::GetSingleton().mRegionManagers[ply->GetCurrentMap()]->GetRegionsWithinRange(ply, RegionManager::RANGETYPE_3X3));

		}
		else
		{
			//Create Objects in Range...

			RegionList appearingRegions;
			RegionList::RegionListIterator ri;
			Region::PlayerIterator pi;
			Region::ObjectIterator oi;			
			Player *p;
#ifdef MOBS
			Mob *mob;
#endif
			appearingRegions = ply->GetCurrentRegionList();

			for (ri = appearingRegions.Begin(); ri != appearingRegions.End(); ri++)
			{

#ifdef MOBS
				for (oi = (*ri)->ObjectBegin(); oi != (*ri)->ObjectEnd(); oi++)
				{
					//If there are mobs in the Player Range We Create em in the Player List!
					mob = (Mob *) *oi;
					
					if (mob->GetNPCFlags() != 0)
						mob->SetFaction(ply->GetFaction());

					ply->AddCreatedMob(mob);
					MonsterHandler::GetSingleton().MobInRange(ply->GetClient(), mob);
				}
#endif

				for (pi = (*ri)->PlayerBegin(); pi != (*ri)->PlayerEnd(); pi++)
				{
					//If there are Players in the Player Range We Create em in the Player List!
					p = (Player *) *pi;
					if (p == ply)
						continue;

					p->AddCreatedPlayer(ply);
					PlayerInRange(p->GetClient(), ply);
					ply->AddCreatedPlayer(p);
					PlayerInRange(ply->GetClient(), p);
				}

			}
		}
	}

	else

	{
		// We moved, but did not change maps
		Region *returnRegion;
		RegionList newRegions, oldRegions;
		RegionList disappearingRegions, appearingRegions;
		RegionList::RegionListIterator ri;
		Region::PlayerIterator pi;
		Region::ObjectIterator oi;
		Player *p;

#ifdef MOBS
		Mob *mob;
#endif

		returnRegion = WorldServer::GetSingleton().mRegionManagers[ply->GetCurrentMap()]->UpdatePlayer(ply);
		
		// We did not change regions, do nothing
		if (!returnRegion)
			return;

		if (returnRegion == RegionManager::BadRegion)
		{
			// We have moved out of bounds. For now, forcibly set the player
			// back to start position and boot the player to avoid hell.
			ply->SetStartCoordinates();
			ply->SetCurrentMap(ply->GetStartMap());
			ply->SetCurrentZone(ply->GetStartZone());
			WorldServer::GetSingleton().AnnounceTo(ply->GetClient(), "[World-Server] - The Server Detected a BAD REGION! Disconnecting Bugged Player!");
			WorldServer::GetSingleton().CloseConnection(ply->GetClient());
			return;
		}

		// We now know we moved from a region to a new good region, in the same map
		// Fetch the 'new' regions
		newRegions = WorldServer::GetSingleton().mRegionManagers[ply->GetCurrentMap()]->GetRegionsWithinRange(ply,RegionManager::RANGETYPE_3X3);
		// Fetch the 'old' regions
		oldRegions = ply->GetCurrentRegionList();
		// Figure out which regions are disappearing
		disappearingRegions = oldRegions - newRegions;
		// Figure out which regions are appearing
		appearingRegions = newRegions - oldRegions;

		// Send out-of-range stuff
		for (ri = disappearingRegions.Begin(); ri != disappearingRegions.End(); ri++)
		{
			for (pi = (*ri)->PlayerBegin(); pi != (*ri)->PlayerEnd(); pi++)
			{
				p = (Player *) *pi;
				// Send out of range to player we are leaving behind
				p->RemoveCreatedPlayer(ply);
				PlayerOutOfRange(p->GetClient(), ply);
				
				// Send out of range to ourselves about the player we left behind
				ply->RemoveCreatedPlayer(p);
				PlayerOutOfRange(ply->GetClient(), p);
			}
#ifdef MOBS
			for (oi = (*ri)->ObjectBegin(); oi != (*ri)->ObjectEnd(); oi++)
			{
				mob = (Mob *) *oi;

				// Send out of Range to ourselves about the mob we left behind
				ply->RemoveCreatedMob(mob);
				MonsterHandler::GetSingleton().MobOutOfRange(ply->GetClient(), mob);
			}
#endif
		}

		// Send in-range stuff
		for (ri = appearingRegions.Begin(); ri != appearingRegions.End(); ri++)
		{
			for (pi = (*ri)->PlayerBegin(); pi != (*ri)->PlayerEnd(); pi++)
			{
				p = (Player *) *pi;

				// This Player havent seen me before.. so lets him see me... :)
				p->AddCreatedPlayer(ply);
				PlayerInRange(p->GetClient(), ply);

				// We Havent Seen this Player Before.. so lets see it :)
				ply->AddCreatedPlayer(p);
				PlayerInRange(ply->GetClient(), p);
			}
#ifdef MOBS
			for (oi = (*ri)->ObjectBegin(); oi != (*ri)->ObjectEnd(); oi++)
			{
				mob = (Mob *) *oi;
				
				if (mob->GetNPCFlags() != 0)
					mob->SetFaction(ply->GetFaction());
					
				// We Havent Seen this mob before.. so lets see it :)
				ply->AddCreatedMob(mob);
				MonsterHandler::GetSingleton().MobInRange(ply->GetClient(), mob);
			}
#endif
		}

		// Finally, we update our current region list.
		ply->SetCurrentRegionList(newRegions);
	}
}*/

void PlayersHandler::MoveTroughRegion(Player *ply)
{
	// We moved, but did not change maps
	Region *returnRegion;
	RegionList newRegions, oldRegions;
	RegionList disappearingRegions, appearingRegions;
	RegionList::RegionListIterator ri;
	Region::PlayerIterator pi;
	Region::ObjectIterator oi;
	Player *p;

#ifdef MOBS
	Mob *mob;
#endif

	returnRegion = WorldServer::GetSingleton().mRegionManagers[ply->GetCurrentMap()]->UpdatePlayer(ply);
		
	// We did not change regions, do nothing
	if (!returnRegion)
		return;

	if (returnRegion == RegionManager::BadRegion)
	{
		// We have moved out of bounds. For now, forcibly set the player
		// back to start position and boot the player to avoid hell.
		ply->SetStartCoordinates();
		ply->SetCurrentMap(ply->GetStartMap());
		ply->SetCurrentZone(ply->GetStartZone());
		WorldServer::GetSingleton().AnnounceTo(ply->GetClient(), "[World-Server] - The Server Detected a BAD REGION! Disconnecting Bugged Player!");
		WorldServer::GetSingleton().CloseConnection(ply->GetClient());
		return;
	}

	// We now know we moved from a region to a new good region, in the same map
	// Fetch the 'new' regions
	newRegions = WorldServer::GetSingleton().mRegionManagers[ply->GetCurrentMap()]->GetRegionsWithinRange(ply,RegionManager::RANGETYPE_3X3);
	// Fetch the 'old' regions
	oldRegions = ply->GetCurrentRegionList();
	// Figure out which regions are disappearing
	disappearingRegions = oldRegions - newRegions;
	// Figure out which regions are appearing
	appearingRegions = newRegions - oldRegions;

	// Send out-of-range stuff
	for (ri = disappearingRegions.Begin(); ri != disappearingRegions.End(); ri++)
	{
		for (pi = (*ri)->PlayerBegin(); pi != (*ri)->PlayerEnd(); pi++)
		{
			p = (Player *) *pi;
			// Send out of range to player we are leaving behind
			p->RemoveCreatedPlayer(ply);
			PlayerOutOfRange(p->GetClient(), ply);
				
			// Send out of range to ourselves about the player we left behind
			ply->RemoveCreatedPlayer(p);
			PlayerOutOfRange(ply->GetClient(), p);
		}

#ifdef MOBS
		for (oi = (*ri)->ObjectBegin(); oi != (*ri)->ObjectEnd(); oi++)
		{
			mob = (Mob *) *oi;

			// Send out of Range to ourselves about the mob we left behind
			ply->RemoveCreatedMob(mob);
			MonsterHandler::GetSingleton().MobOutOfRange(ply->GetClient(), mob);
		}
#endif

		}

		// Send in-range stuff
		for (ri = appearingRegions.Begin(); ri != appearingRegions.End(); ri++)
		{
			for (pi = (*ri)->PlayerBegin(); pi != (*ri)->PlayerEnd(); pi++)
			{
				p = (Player *) *pi;

				// This Player havent seen me before.. so lets him see me... :)
				p->AddCreatedPlayer(ply);
				PlayerInRange(p->GetClient(), ply);

				// We Havent Seen this Player Before.. so lets see it :)
				ply->AddCreatedPlayer(p);
				PlayerInRange(ply->GetClient(), p);
			}

#ifdef MOBS
			for (oi = (*ri)->ObjectBegin(); oi != (*ri)->ObjectEnd(); oi++)
			{
				mob = (Mob *) *oi;
				
				if (mob->GetNPCFlags() != 0)
					mob->SetFaction(ply->GetFaction());
					
				// We Havent Seen this mob before.. so lets see it :)
				ply->AddCreatedMob(mob);
				MonsterHandler::GetSingleton().MobInRange(ply->GetClient(), mob);
			}
#endif

		}

	// Finally, we update our current region list.
	ply->SetCurrentRegionList(newRegions);
}

//FIXED METHOD FOR CHANGE MAP AND REGION! IN THE WORLD HEH :)
void PlayersHandler::MapChange(Player *ply, Byte oldmap, bool PlayerChangingMap)
{
	Packet pack;
	Player::PlayersCreatedIterator i;
	Player::MobsCreatedIterator m;
	Region *returnRegion;

	RegionList appearingRegions;
	RegionList::RegionListIterator ri;
	Region::PlayerIterator pi;
	Region::ObjectIterator oi;			
	Player *p;
#ifdef MOBS
	Mob *mob;
#endif

	if(PlayerChangingMap == true)
	{
		// LOCKING PLAYER FROM SENDING/RECEIVING DATA !!! (PREVENT TONS OF CRASHES HAHAHAHHA)
		ply->ROOT();
		ply->SetCommunication(false);

		// SEND OUT OF RANGE STUFF!

		for (i = ply->PlayersCreatedBegin(); i != ply->PlayersCreatedEnd(); i++)
		{
			if (!(*i).second->GetClient() || (*i).second == ply)
				continue;
		
			// Remove the player leaving from this player's created list.
			if ( (*i).second->HasReceivedCreate(ply->GetObjectGuid()) )
			{
				(*i).second->RemoveCreatedPlayer(ply);
	
				pack.Build(SMSG_DESTROY_OBJECT);
				pack.AddQuadWord(ply->GetObjectGuid());
				WorldServer::GetSingleton().WriteData((*i).second->GetClient(), &pack);
			}
		}
	
		// We need to clear the list of created-for players because the player
		// is changing maps
		ply->ClearCreatedPlayers();
		
		#ifdef MOBS
		ply->ClearCreatedMobs();
		#endif

		// Remove player from region system.
		WorldServer::GetSingleton().mRegionManagers[oldmap]->RemovePlayer(ply);
	
		// Add ourselves to the new region system
		returnRegion = WorldServer::GetSingleton().mRegionManagers[ply->GetCurrentMap()]->UpdatePlayer(ply);
	
		if (returnRegion == RegionManager::BadRegion)
		{
			// We have moved out of bounds. For now, forcibly set the player
			// back to start position and boot the player to avoid hell.
			ply->SetStartCoordinates();
			ply->SetCurrentMap(ply->GetStartMap());
			ply->SetCurrentZone(ply->GetStartZone());
			WorldServer::GetSingleton().AnnounceTo(ply->GetClient(), "[World-Server] - The Server Detected a BAD REGION! Disconnecting Bugged Player!");
			WorldServer::GetSingleton().CloseConnection(ply->GetClient());
			return;
		}
	
		ply->SetCurrentRegionList(WorldServer::GetSingleton().mRegionManagers[ply->GetCurrentMap()]->GetRegionsWithinRange(ply, RegionManager::RANGETYPE_3X3));
	}
	else
	{
		// SEND IN OF RANGE STUFF!

		appearingRegions = ply->GetCurrentRegionList();

		for (ri = appearingRegions.Begin(); ri != appearingRegions.End(); ri++)
		{
			
			#ifdef MOBS
			for (oi = (*ri)->ObjectBegin(); oi != (*ri)->ObjectEnd(); oi++)
			{
				//If there are mobs in the Player Range We Create em in the Player List!
				mob = (Mob *) *oi;
				
				if (mob->GetNPCFlags() != 0)
					mob->SetFaction(ply->GetFaction());
	
				ply->AddCreatedMob(mob);
				MonsterHandler::GetSingleton().MobInRange(ply->GetClient(), mob);
			}
			#endif

			for (pi = (*ri)->PlayerBegin(); pi != (*ri)->PlayerEnd(); pi++)
			{
				//If there are Players in the Player Range We Create em in the Player List!
				p = (Player *) *pi;
				
				if (p == ply)
					continue;
	
				p->AddCreatedPlayer(ply);
				PlayerInRange(p->GetClient(), ply);
				ply->AddCreatedPlayer(p);
				PlayerInRange(ply->GetClient(), p);
			}
		}

		//ENABLE CLIENT TO SEND/RECEIVE DATA FROM SERVER ( NOW ITS OK HEHHHEHEH )
		ply->UnROOT();
		ply->SetCommunication(true);
	}
}

bool PlayersHandler::TeleportPlayer(Player *ply, Byte m, Float x, Float y, Float z)
{
	if (!ply->HasMoved())
	{
		WorldServer::GetSingleton().AnnounceTo(ply->GetClient(),"[World-Server] -> You didnt walked any step yet try again");
		return false;
	}

	ply->SetMoved(false);

	if (ply->GetCurrentMap() == m)
	{
		// If we are just doing a Teleport within a continent
		Packet ppack;

		// Set our particulars
		ply->SetXCoordinate(x);
		ply->SetYCoordinate(y);
		ply->SetZCoordinate(z);
		ply->SetFacing(0.0f);
		ply->SetPitch(0.0f);
		ply->ClearMoveFlag(0xFFFFFFFF);

		// build temeport packet
		ppack.Build(MSG_MOVE_TELEPORT);
		ppack.AddQuadWord(ply->GetObjectGuid());
		ppack.AddDoubleWord(0);
		ppack.AddDoubleWord(0);
		ppack.AddFloat(ply->GetXCoordinate());
		ppack.AddFloat(ply->GetYCoordinate());
		ppack.AddFloat(ply->GetZCoordinate());
		ppack.AddFloat(ply->GetFacing());

		// Change regions
		//CheckRegion(ply, ply->GetCurrentMap());
		MoveTroughRegion(ply);

		// Everyone in range of us now, including ourselves, needs
		// the teleport packet
		if (ply->GetClient())
			WorldServer::GetSingleton().WriteData(ply->GetClient(),&ppack);

		WorldServer::GetSingleton().SendToPlayersInRangeMinusSelf(&ppack, ply);
	}
	else
	{
		// We are teleporting between maps
		Packet ppack;
		Byte oldmap;

		// Set our particulars
		ply->SetXCoordinate(x);
		ply->SetYCoordinate(y);
		ply->SetZCoordinate(z);
		ply->SetFacing(0.0f);
		ply->SetPitch(0.0f);
		ply->ClearMoveFlag(0xFFFFFFFF);
		oldmap = ply->GetCurrentMap();
		ply->SetCurrentMap(m);

		// Region change
		//CheckRegion(ply, oldmap); // no maybe about this one :)
		MapChange(ply, oldmap, true);

		// Build our NEW_WORLD packet
		ppack.Build(SMSG_NEW_WORLD);
		ppack.AddDoubleWord(ply->GetCurrentMap());
		ppack.AddFloat(ply->GetXCoordinate());
		ppack.AddFloat(ply->GetYCoordinate());
		ppack.AddFloat(ply->GetZCoordinate());
		ppack.AddFloat(ply->GetFacing());

		if (ply->GetClient())
			WorldServer::GetSingleton().WriteData(ply->GetClient(),&ppack);

		// The rest of the 'flow' now continues when we receive CMSG_WORLDPORT_ACK
	}

	return true;
}

Float PlayersHandler::DistBetween(Player *p1, Player *p2)
{  
	Float x = fabs(p1->GetXCoordinate() - p2->GetXCoordinate());
	Float y = fabs(p1->GetYCoordinate() - p2->GetYCoordinate());
	Float z = fabs(p1->GetZCoordinate() - p2->GetZCoordinate());
	
	return sqrt(x*x + y*y + z*z);
}

void PlayersHandler::PlayerInRange(Client *cli, Player *ply)
{
	Packet pack;
	Player *ply2 = FindPlayer(cli);

	if (!ply2)
		return;

	Packets::NewObjectHeader(ply,&pack,false);
	Packets::NewObjectData(ply,&pack);
	WorldServer::GetSingleton().WriteData(cli, &pack);
	LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_UPDATE_OBJECT\n");

#ifdef ITEMS
	ply2->CreateItems(ply,1);
#endif

}

void PlayersHandler::PlayerOutOfRange(Client *cli, Player *ply)
{
	Packet pack;

	pack.Build(SMSG_DESTROY_OBJECT);
	pack.AddQuadWord(ply->GetObjectGuid());
	WorldServer::GetSingleton().WriteData(cli, &pack);
	LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_DESTROY_OBJECT\n");
}

Player *PlayersHandler::FindPlayer(const char *name)
{
	ObjectManager<Player *>::ObjectManagerIterator i;

	for (i = mPlayers.Begin(); i != mPlayers.End(); i++)
	{
		if (stricmp((*i).second->GetName().c_str(), name) == 0)
			return (*i).second;
	}
	return NULL;
}

Player *PlayersHandler::FindPlayer(Client *cli)
{
	ObjectManager<Player *>::ObjectManagerIterator i;

	for (i = mPlayers.Begin(); i != mPlayers.End(); i++)
	{
		if ((*i).second->GetClient() == cli)
			return (*i).second;
	}

	return NULL;
}

Player *PlayersHandler::FindPlayer(QuadWord guid)
{
	ObjectManager<Player *>::ObjectManagerIterator i;

	for (i = mPlayers.Begin(); i != mPlayers.End(); i++)
	{
		if ((*i).second->GetObjectGuid() == guid)
			return (*i).second;
	}

	return NULL;
}

int PlayersHandler::NumberPlayers(void)
{
	ObjectManager<Player *>::ObjectManagerIterator i;
	int cnt;

	cnt = 0;
	for (i = mPlayers.Begin(); i != mPlayers.End(); i++)
	{
		if (!(*i).second->GetClient())
			continue;
		cnt++;
	}

	return cnt;
}

int PlayersHandler::NumberGMs(void)
{
	ObjectManager<Player *>::ObjectManagerIterator i;
	int cnt;

	cnt = 0;
	for (i = mPlayers.Begin(); i != mPlayers.End(); i++)
	{
		if (!(*i).second->GetClient())
			continue;
		if (!(*i).second->IsGM())
			continue;
		cnt++;
	}

	return cnt;
}