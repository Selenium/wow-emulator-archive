// (c) AbyssX Group
#include "WorldEnvironment.h"

template <class WorldServer> WorldServer *Singleton<WorldServer>::msSingleton = 0;

void SaveVars(void *Param)
{
	WorldServer::GetSingleton().SaveVariables();

#ifdef EVENTSYSTEM
	EventSystem::GetSingleton().AddTimer(360000,SaveVars,NULL,WORLDSERVER,1);
#endif

}

WorldServer::WorldServer()
{
	Quantity = 0;
	MAX_PLAYERS = 1;
	mDebug = false;
	//mRegionManagers[MAP_AZEROTH] = new RegionManager(-15000.0f, -7500.0f, 8000.0f, 5000.0f, 100.0f);
	//mRegionManagers[MAP_KALIMDOR] = new RegionManager(-11500.0f, -8000.0f, 12000.0f, 4000.0f, 100.0f);

	mRegionManagers[MAP_AZEROTH] = new RegionManager(-18000.0f, -18000.0f, 18000.0f, 18000.0f, 200.0f);
	mRegionManagers[MAP_KALIMDOR] = new RegionManager(-18000.0f, -18000.0f, 18000.0f, 18000.0f, 200.0f);
	mRegionManagers[MAP_MONASTRY] = new RegionManager(-1000.0f, -1000.0f, 1000.0f, 1000.0f, 200.0f);

#ifdef CHANNELS
	CHandler.mChannelManager = new ChannelManager();
#endif
}

WorldServer::~WorldServer()
{
	// Release used resources.
#ifdef CHANNELS
	delete CHandler.mChannelManager;
#endif
	delete mRegionManagers[MAP_AZEROTH];
	delete mRegionManagers[MAP_KALIMDOR];
}

void WorldServer::Run(void)
{
	ConfigCursor cfg = Config::GetSingleton().Cursor();

	if (!cfg.Find("WorldServer") || !cfg.FindIn("ListenPort"))
	{
		fprintf(stderr, "No configured ListenPort for WorldServer\n");
		return;
	}
	mPort = atoi(cfg[0]);
	if (mPort < 1024 || mPort > 9999)
	{
		fprintf(stderr, "ListenPort must be between 1024 and 9999, not %d\n", mPort);
		return;
	}
	cfg.Reset();
	if (!cfg.Find("WorldServer") || !cfg.FindIn("BotHost"))
	{
		fprintf(stderr, "No configured BotHost for WorldServer\n");
		return;
	}

#ifdef IRCBOT
	mIRCHost = cfg[0];
	cfg.Reset();
	if (!cfg.Find("WorldServer") || !cfg.FindIn("BotPort"))
	{
		fprintf(stderr, "No configured BotPort for WorldServer\n");
		return;
	}
	mIRCPort = atoi(cfg[0]);
	if (!mIRCBot.LoadConfig())
		return;

	mIRCClient = NULL;
#endif

	cfg.Reset();
	if (!cfg.Find("LoginServer") || !cfg.FindIn("ListenPort"))
	{
		fprintf(stderr, "No configured BotPort for WorldServer\n");
		return;
	}
	LPort = atoi(cfg[0]);

	cfg.Reset();
	if (!cfg.Find("LoginServer") || !cfg.FindIn("RedirectHost"))
	{
		fprintf(stderr, "No configured BotPort for WorldServer\n");
		return;
	}
	strcpy(LIP,cfg[0]);

	cfg.Reset();
	if (!cfg.Find("Database") || !cfg.FindIn("Module"))
	{
		fprintf(stderr, "Database Type Not Configured!\n");
		return;
	}
	
	if (strncmp((const char *)cfg[0],"Mysql",5) == 0) 
	{
		char host_name[64];
		char user_name[64];
		char pass_word[64];
		char data_base[64];
		char info_buf[128];

		cfg.Reset();

		if (!cfg.Find("Database") || !cfg.FindIn("HOSTNAME"))
		{
			fprintf(stderr, "Mysql Hostname Not Configured!\n");
			return;
		}

		strcpy(host_name,cfg[0]);

		cfg.Reset();

		if (!cfg.Find("Database") || !cfg.FindIn("USERNAME"))
		{
			fprintf(stderr, "Mysql Username Not Configured!\n");
			return;
		}
		
		strcpy(user_name,cfg[0]);

		cfg.Reset();

		if (!cfg.Find("Database") || !cfg.FindIn("PASSWORD"))
		{
			fprintf(stderr, "Mysql Password Not Configured!\n");
			return;
		}
		
		strcpy(pass_word,cfg[0]);

		cfg.Reset();

		if (!cfg.Find("Database") || !cfg.FindIn("DATABASE"))
		{
			fprintf(stderr, "Mysql Hostname Not Configured!\n");
			return;
		}
		
		strcpy(data_base,cfg[0]);

		sprintf(info_buf,"%s;%s;%s;%s",host_name,user_name,pass_word,data_base);

		new DatabaseMysql(info_buf);
	}
	else if (strncmp((const char *)cfg[0],"Sqlite",7) == 0)
	{
		cfg.Reset();
		
		if (!cfg.Find("Database") || !cfg.FindIn("SQLITEDB"))
		{
			fprintf(stderr, "SQLite DB File not configured.!\n");
			return;
		}

		new DatabaseSqlite((const char *)cfg[0]);
	}

	cfg.Reset();
	if (!cfg.Find("WorldServer") || !cfg.FindIn("GMPassword"))
	{
		fprintf(stderr, "GM Password not configured!\n");
		return;
	}

	GMPASSWORD = cfg[0];

	printf("[%s] - Starting...\n",SERVER_NAME);

	time( &uptime.TimeStamp );

	GetVariables();

	new PlayersHandler();

#ifdef EVENTSYSTEM
	new EventSystem();
	EventSystem::GetSingleton().AddTimer(360000,SaveVars,NULL,WORLDSERVER,1);
#endif

#ifdef COMBAT
	new MeleeHandler();
#endif

#ifdef GROUPS
	new GroupsHandler();
#endif

#ifdef CHAMPIOSHIP
	new ChampioshipHandler();
#endif

	LoadDatabases();

	if (!Listen(mPort))
		return;

#ifdef IRCBOT
	if (!mIRCClient)
	{
		mIRCClient = Connect(mIRCHost.c_str(), mIRCPort);
		if (mIRCClient)
			ClientConnected(mIRCClient);
	}
#endif
	
	printf("[World-Server] - Server Online !\n",SERVER_NAME);

	while (true)
	{
		if (!Select())
			return;

#ifdef EVENTSYSTEM
		EventSystem::GetSingleton().CheckReadyEvents();
#endif
	}
}

void WorldServer::LoadDatabases()
{
	printf("[World-Server] - Loading Server Database(s):\n");
#ifdef MOBS
	new MonsterHandler();
	MonsterHandler::GetSingleton().LoadMobs();
#endif
#ifdef NPCS
	new VendorsHandler();
	VendorsHandler::GetSingleton().LoadVendorItems();
	new TaxiHandler();
	TaxiHandler::GetSingleton().LoadTaxiDB();
#endif
#ifdef ITEMS
	new Items_Handler();
	Items_Handler::GetSingleton().LoadDB_Items();
	Items_Handler::GetSingleton().LoadStarting_Items();
#endif
#ifdef WORLDPORTS
	new WorldPort_DB();
	WorldPort_DB::GetSingleton().LoadWP();
#endif
#ifdef SPELLS
	new Spells();
	Spells::GetSingleton().LoadBasicSpells();
#endif
}

void WorldServer::Shutdown()
{
	AnnounceToAll("[World-Server] -> The Server is being Shutdowned!");
	SaveVariables();
	printf("[World-Server] - The Server Has Been ShutDowned!\n");
	exit(0);
}

void WorldServer::ClientConnected(Client *cli)
{
#ifdef IRCBOT
	if (cli == mIRCClient)
	{
		mIRCBot.Connected(this, cli);
		return;
	}
#endif

	if(Quantity >= MAX_PLAYERS)
		return;

	Byte challenge[WORLD_CHALLENGE_LEN] = WORLD_CHALLENGE;
	Packet pack;

	LogManager::GetSingleton().Log("Debug.log",	">>> Connection received from %s\n",
		cli->GetHost().c_str());
	LogManager::GetSingleton().Log("Debug.log",	"%d connections\n",
		mClientCount);

	pack.Build(SMSG_AUTH_CHALLENGE);
	pack.AddBytes(challenge, WORLD_CHALLENGE_LEN);
	WriteData(cli, &pack);
	LogManager::GetSingleton().Log("Debug.log",	"<<< SMSG_AUTH_CHALLENGE\n");
}

void WorldServer::ClientDisconnected(Client *cli)
{
#ifdef IRCBOT
	if (cli == mIRCClient)
	{
		mIRCBot.Disconnected();
		mIRCClient = NULL;
		return;
	}
#endif

	Player *ply;

	LogManager::GetSingleton().Log("Debug.log", ">>> Connection from %s disconnected\n",
		cli->GetHost().c_str());
	LogManager::GetSingleton().Log("Debug.log", "%d connections\n",
		mClientCount);

	ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	if (ply)
	{
		LogManager::GetSingleton().Log("Debug.log", "Was logged in as '%s'\n", ply->GetName().c_str());
		PlayersHandler::GetSingleton().PlayerLeftWorld(ply);
	}
	else
	{
		LogManager::GetSingleton().Log("Debug.log", "Was not logged in\n");
	}
}

void WorldServer::HandlerMSG_AUTH_SESSION(Client *cli, Packet *pack)
{
	mUserID[cli] = (char *) pack->GetBytes(0x08);

	LogManager::GetSingleton().Log("Debug.log", ">>> CMSG_AUTH_SESSION (%s)\n",	cli->GetHost().c_str());
	LogManager::GetSingleton().Log("Debug.log",	"This connection now logged in with user id '%s'\n", mUserID[cli].c_str());

	pack->Build(SMSG_AUTH_RESPONSE);
	pack->AddByte(12);
	WriteData(cli, pack);

	LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_AUTH_RESPONSE\n");
}

void WorldServer::HandlerMSG_PING(Client *cli, Packet *pack)
{
	Packet retpack;
	Player *ply;

	ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	LogManager::GetSingleton().Log("Debug.log", ">>> CMSG_PING (%s)(%s)(%s)\n",	cli->GetHost().c_str(), mUserID[cli].c_str(), ply ? ply->GetName().c_str() : "");

	retpack.Build(SMSG_PONG);
	retpack.AddBytes(pack->GetBytes(), pack->GetDataLength());
	WriteData(cli, &retpack);
	LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_PONG\n");
}

void WorldServer::HandlerMSG_TEXT_EMOTE(Client *cli, Packet *pack)
{
	Player *ply;
	Player *plytarget;
	Mob *mobtarget;
	Packet retpack;
	Packet mpack;
	
	ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	LogManager::GetSingleton().Log("Debug.log", ">>> CMSG_EMOTE (%s)(%s)(%s)\n", cli->GetHost().c_str(), mUserID[cli].c_str(), ply ? ply->GetName().c_str() : "");
	
	if (!ply)
	{
		LogManager::GetSingleton().Log("Debug.log",
			"Connection is not logged in with a player!\n");
		return; // should not happen
	}

	plytarget = PlayersHandler::GetSingleton().FindPlayer(pack->GetQuadWord(0x04));
	mobtarget = NULL;
#ifdef MOBS
	if (!plytarget)
		mobtarget = MonsterHandler::GetSingleton().FindMob(pack->GetQuadWord(0x04));
#endif

	if(ply->IsMounted())
		return;

	if(ply->GetGhost())
		return;

	retpack.Build(SMSG_EMOTE);

	//This Case is for Get The Current Emote Animation ID!
	switch(pack->GetByte(0x00))
	{
		case EMOTE_APPLAUD:
			retpack.AddDoubleWord(0x15);
			break;
		case EMOTE_BEG:
			retpack.AddDoubleWord(0x14);
			break;
		case EMOTE_BOW:
			retpack.AddDoubleWord(0x02);
			break;
		case EMOTE_CHEER:
			retpack.AddDoubleWord(0x04);
			break;
		case EMOTE_CRY:
			retpack.AddDoubleWord(0x0A);
			break;
		case EMOTE_DANCE:
			retpack.AddDoubleWord(0x12);
			break;
		case EMOTE_EAT:
			retpack.AddDoubleWord(0x07);
			break;
		case EMOTE_FLEX:
			retpack.AddDoubleWord(0x17);
			break;
		case EMOTE_POINT:
			retpack.AddDoubleWord(0x19);
			break;
		case EMOTE_ROAR:
			retpack.AddDoubleWord(0x0F);
			break;
		case EMOTE_RUDE:
			retpack.AddDoubleWord(0x0E);
			break;
		case EMOTE_SALUTE:
			retpack.AddDoubleWord(0x42);
			break;
		case EMOTE_SHY:
			retpack.AddDoubleWord(0x18);
			break;
		case EMOTE_TALK:
			retpack.AddDoubleWord(0x01);
			break;
		case EMOTE_WAVE:
			retpack.AddDoubleWord(0x03);
			break;
		case EMOTE_CHICKEN:
			retpack.AddDoubleWord(0x13);
			break;
		case EMOTE_KISS:
			retpack.AddDoubleWord(0x11);
			break;
		case EMOTE_KNEEL:
			retpack.AddDoubleWord(0x10);
			break;
		case EMOTE_LAUGH:
			retpack.AddDoubleWord(0x0B);
			break;
		case EMOTE_SIT:
				if(!ply->GetGhost() && ply->GetMountModel() == 0x00)
					ply->SetPlayerEmote(1);
				break;

		case EMOTE_STAND:
				if(!ply->GetGhost() && ply->GetMountModel() == 0x00)
					ply->SetPlayerEmote(0);
				break;

		case EMOTE_SLEEP:
				if(!ply->GetGhost() && ply->GetMountModel() == 0x00)
					ply->SetPlayerEmote(3);
				break;

		default:
			LogManager::GetSingleton().Log("Debug.log", "Unhandled emote ID: 0x%02X\n",
				pack->GetByte(0x00));
			return;
	}

	retpack.AddQuadWord(ply->GetObjectGuid());
	retpack.AddByte(0x00);
	retpack.AddByte(0x10);

	SendToPlayersInRange(&retpack, ply);

	retpack.Build(SMSG_TEXT_EMOTE);
	retpack.AddQuadWord(ply->GetObjectGuid());
	retpack.AddDoubleWord(pack->GetDoubleWord(0x00));
	if (plytarget)
		retpack.AddBytes((Byte *)plytarget->GetName().c_str(), (Word)plytarget->GetName().length());
#ifdef MOBS
	else if (mobtarget)
		retpack.AddBytes((Byte *)mobtarget->GetName().c_str(), (Word)mobtarget->GetName().length());
#endif
	retpack.AddByte(0x00);
	
	SendToPlayersInRange(&retpack, ply);
}

void WorldServer::HandlerMSG_MOVE_ASSORTED(Client *cli, Packet *pack)
{
	Player *ply;
	Packet retpack;

	// Find our player
	ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	LogManager::GetSingleton().Log("Debug.log", ">>> MSG_MOVE_ASSORTED (%s)(%s)(%s)\n",	cli->GetHost().c_str(), mUserID[cli].c_str(), ply ? ply->GetName().c_str() : "");

	if (!ply)
	{
		LogManager::GetSingleton().Log("Debug.log",
			"Connection is not logged in with a player!\n");
		return; // should not happen
	}

	if (ply->GetFlying())
		return;

	// Update our move flags
	switch (pack->GetOpCode())
	{
		case MSG_MOVE_START_FORWARD:
			ply->SetMoveFlag(MOVEFLAG_FORWARD);
			break;
		case MSG_MOVE_START_BACKWARD:
			ply->SetMoveFlag(MOVEFLAG_BACKWARD);
			break;
		case MSG_MOVE_STOP:
			ply->ClearMoveFlag(MOVEFLAG_FORWARD | MOVEFLAG_BACKWARD);
			break;
		case MSG_MOVE_START_STRAFE_LEFT:
			ply->SetMoveFlag(MOVEFLAG_STRAFE_LEFT);
			break;
		case MSG_MOVE_START_STRAFE_RIGHT:
			ply->SetMoveFlag(MOVEFLAG_STRAFE_RIGHT);
			break;
		case MSG_MOVE_STOP_STRAFE:
			ply->ClearMoveFlag(MOVEFLAG_STRAFE_LEFT | MOVEFLAG_STRAFE_RIGHT);
			break;
		case MSG_MOVE_START_SWIM:
			ply->SetMoveFlag(MOVEFLAG_SWIMMING);
			break;
		case MSG_MOVE_STOP_SWIM:
			ply->ClearMoveFlag(MOVEFLAG_SWIMMING);
			break;
		case MSG_MOVE_START_TURN_LEFT:
			ply->SetMoveFlag(MOVEFLAG_LEFT);
			break;
		case MSG_MOVE_START_TURN_RIGHT:
			ply->SetMoveFlag(MOVEFLAG_RIGHT);
			break;
		case MSG_MOVE_STOP_TURN:
			ply->ClearMoveFlag(MOVEFLAG_LEFT | MOVEFLAG_RIGHT);
			break;
		case MSG_MOVE_SET_RUN_MODE:
			ply->ClearMoveFlag(MOVEFLAG_WALK);
			break;
		case MSG_MOVE_SET_WALK_MODE:
			ply->SetMoveFlag(MOVEFLAG_WALK);
			break;
	}
	// Update our particulars
	ply->SetXCoordinate(pack->GetFloat(0x08));
	ply->SetYCoordinate(pack->GetFloat(0x0C));
	ply->SetZCoordinate(pack->GetFloat(0x10));
	ply->SetFacing(pack->GetFloat(0x14));
	if (pack->GetDoubleWord(0x00) & MOVEFLAG_SWIMMING)
		ply->SetPitch(pack->GetFloat(0x18));

	// Log it
	LogManager::GetSingleton().Log("Debug.log",
		"PlayerLocation update: x=%f,y=%f,z=%f,facing=%f\n",
		ply->GetXCoordinate(), ply->GetYCoordinate(), ply->GetZCoordinate(),
		ply->GetFacing());

	// Handle regions
	//PlayersHandler::GetSingleton().CheckRegion(ply, ply->GetCurrentMap());
	PlayersHandler::GetSingleton().MoveTroughRegion(ply);

	// Build our move packet to forward
	retpack.Build(pack->GetOpCode());
	retpack.AddQuadWord(ply->GetObjectGuid());
	retpack.AddBytes(pack->GetBytes(0x00), pack->GetDataLength() - 4);

	// Send the move packet to all players in range besides ourself
	SendToPlayersInRangeMinusSelf(&retpack, ply);

	// Remove Players from Party if they are far than other members...
	if (ply->GetParty())
	{
#ifdef GROUPS
		if (GroupsHandler::GetSingleton().CompareRanges(ply))
			GroupsHandler::GetSingleton().RemoveFromGroup(ply);
#endif
	}

	ply->SetMoved(true);
}

void WorldServer::HandlerMSG_QUERY_TIME(Client *cli, Packet *pack)
{
	Packet retpack;
	Player *ply;

	// Log the event.
	ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	LogManager::GetSingleton().Log("Debug.log", ">>> CMSG_QUERY_TIME (%s)(%s)(%s)\n", cli->GetHost().c_str(), mUserID[cli].c_str(), ply ? ply->GetName().c_str() : "");

	// Build the package.
	retpack.Build(SMSG_QUERY_TIME_RESPONSE);
	retpack.AddDoubleWord(GetGameTime());
	WriteData(cli, &retpack);
	LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_QUERY_TIME_RESPONSE\n");
}

void WorldServer::HandlerMSG_SET_SELECTION(Client *cli, Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Packet retpack;

	if (!ply)
		return;

	if (ply->IsGM() == false)
		return;

	ply->SetTarget(pack->GetQuadWord(0x00));

#ifdef MOBS
	Mob *mob = MonsterHandler::GetSingleton().FindMob(ply->GetTarget());

	if (mob)
		AnnounceTo(cli,"[MOB] -> [N: %s] [G: "I64FMT"] Currently Selected!]",mob->GetName().c_str(),ply->GetTarget());
#endif
	Player *player = PlayersHandler::GetSingleton().FindPlayer(ply->GetTarget());

	if (player)
		AnnounceTo(cli,"[PLAYER] -> [N: %s] [G: "I64FMT"] Currently Selected!]",player->GetName().c_str(),ply->GetTarget());
}

void WorldServer::ClientDataRecvd(Client *cli)
{
#ifdef IRCBOT
	if (cli == mIRCClient)
	{
		mIRCBot.DataRecvd();
		return;
	}
#endif

	Packet pack;

	while (pack.FromInput(cli))
	{

		if(PlayersHandler::GetSingleton().HandlePackets(cli, &pack) == 1)
			return;

#ifdef GROUPS
		if (GroupsHandler::GetSingleton().HandlePackets(cli, &pack) == 1)
			return;
#endif

#ifdef COMBAT
		if (MeleeHandler::GetSingleton().HandlePackets(cli, &pack) == 1)
			return;
#endif

#ifdef NPCS
		if (NPCs.HandlePackets(cli, &pack) == 1)
			return;
		if (TaxiHandler::GetSingleton().HandlePackets(cli, &pack) == 1)
			return;
#endif

#ifdef MOBS
		if (MonsterHandler::GetSingleton().HandlePackets(cli, &pack) == 1)
			return;
#endif

#ifdef ITEMS
		if (Items_Handler::GetSingleton().HandlePackets(cli,&pack) == 1)
			return;
#endif

#ifdef CHANNELS
		if (CHandler.HandlePackets(cli,&pack) == 1)
			return;
#endif

#ifdef SPELLS
				if (Spells::GetSingleton().HandlePackets(cli, &pack) == 1)
					break;
#endif


		// Maybe instead of this switch do a function lookup table?
		switch (pack.GetOpCode())
		{
			case CMSG_AUTH_SESSION:
				HandlerMSG_AUTH_SESSION(cli, &pack);
				break;
			case CMSG_PING:
				HandlerMSG_PING(cli, &pack);
				break;
			case CMSG_MESSAGECHAT:
				HandlerMSG_MESSAGECHAT(cli, &pack);
				break;
			case CMSG_TEXT_EMOTE:
				HandlerMSG_TEXT_EMOTE(cli, &pack);
				break;
			case CMSG_QUERY_TIME:
				HandlerMSG_QUERY_TIME(cli, &pack);
				break;
			case CMSG_SET_SELECTION:
				HandlerMSG_SET_SELECTION(cli, &pack);
				break;

			case MSG_MOVE_START_FORWARD:
			case MSG_MOVE_START_BACKWARD:
			case MSG_MOVE_STOP:
			case MSG_MOVE_START_STRAFE_LEFT:
			case MSG_MOVE_START_STRAFE_RIGHT:
			case MSG_MOVE_STOP_STRAFE:
			case MSG_MOVE_JUMP:
			case MSG_MOVE_START_TURN_LEFT:
			case MSG_MOVE_START_TURN_RIGHT:
			case MSG_MOVE_STOP_TURN:
			case MSG_MOVE_SET_FACING:
			case MSG_MOVE_HEARTBEAT:
			//case MSG_MOVE_COLLIDE_REDIRECT:
			case MSG_MOVE_START_SWIM:
			case MSG_MOVE_STOP_SWIM:
			case MSG_MOVE_SET_PITCH:
			case MSG_MOVE_SET_WALK_MODE:
			case MSG_MOVE_SET_RUN_MODE:
				HandlerMSG_MOVE_ASSORTED(cli, &pack);
				break;

			default:
				
				Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
				LogManager::GetSingleton().Log("Debug.log",	">>> UNKNOWN PACKET (%s)(%s)(%s)\n", cli->GetHost().c_str(), mUserID[cli].c_str(), ply ? ply->GetName().c_str() : "");
				LogManager::GetSingleton().Log("UnknownPackets.log", "Unknown packet received:\n");
				pack.Debug("UnknownPackets.log");
				break;
		}
	}
}

void WorldServer::HandlerMSG_MESSAGECHAT(Client *cli, Packet *pack)
{
	Player *ply;
	char *txt;

	ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	LogManager::GetSingleton().Log("Debug.log", ">>> CMSG_MESSAGECHAT (%s)(%s)(%s)\n", cli->GetHost().c_str(), mUserID[cli].c_str(), ply ? ply->GetName().c_str() : "");
	
	if (!ply)
	{
		LogManager::GetSingleton().Log("Debug.log",	"Connection is not logged in with a player!\n");
		return; // should not happen
	}

	if (ply->GetGhost())
	{
		AnnounceTo(cli,"[World-Server] - You Can´t Talk as a ghost...");
		return;
	}

	int chatCode;
	memcpy(&chatCode,pack->GetBytes(0x00),4);

	int otherNumber;
	memcpy(&otherNumber,pack->GetBytes(0x04),4);


#ifdef CHANNELS
	if(chatCode == 0x0D)
	{
		Byte* cName = pack->GetBytes(0x08);
		char* text = (char *)pack->GetBytes(0x08 + (Word)strlen((char *)cName) + 1);
		Packet retPack;

		if(!CHandler.mChannelManager->ChanExists((char *)cName))
		{
			retPack.Build(SMSG_CHANNEL_NOTIFY);
			retPack.AddByte(0x05);
			retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
			WriteData(cli,&retPack);
			return;
		}

		Channel *chan = CHandler.mChannelManager->GetChannel((char *)cName);
		if(chan->GetPlayerMode(ply->GetObjectGuid()) & CM_PLAYER_MUTED)
		{
			retPack.Build(SMSG_CHANNEL_NOTIFY);
			retPack.AddByte(0x11);
			retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
			WriteData(cli,&retPack);
			return;
		}

		if(chan->GetModes() & CM_CHANNEL_MODERATED)
		{
			if(!(chan->GetPlayerMode(ply->GetObjectGuid()) & CM_PLAYER_MODERATOR))
			{
				retPack.Build(SMSG_CHANNEL_NOTIFY);
				retPack.AddByte(0x06);
				retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
				WriteData(cli,&retPack);
				return;
			}
		}

		Channel::ChanPlayerIterator i;
		for (i=chan->GetPlayersStart(); i!=chan->GetPlayersEnd(); i++)
		{
			retPack.Build(SMSG_MESSAGECHAT);
			retPack.AddDoubleWord(chatCode);
			retPack.AddByte(0x00);
			retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
			retPack.AddQuadWord(ply->GetObjectGuid());
			retPack.AddBytes((Byte *)text,(Word)strlen(text)+1);
			retPack.AddByte(0x00);
			WriteData((*i)->GetClient(),&retPack);
		}
	}

	else

	{
#endif

	txt = (char *)pack->GetBytes(0x08);

	if (txt[0] == '!')
	{
		if (ply->GetFlying())
		{
			AnnounceTo(cli,"[World-Server] - You Can´t use Commands while Flying...");
			return;
		}

		txt = txt+1;

		if (strnicmp(txt, "kick ", 5) == 0)
		{
			if (ply->IsGM())
			{
				Player *kply;
				kply = PlayersHandler::GetSingleton().FindPlayer(txt + 5);
				if (!kply)
					AnnounceTo(cli, "[World-Server] -> No such player.");
				else if (!kply->GetClient())
					AnnounceTo(cli, "[World-Server] -> Player is already offline.");
				else if (kply->IsGM())
					AnnounceTo(cli, "[World-Server] -> Cannot kick a GM.");
				else if (kply == ply)
					AnnounceTo(cli, "[World-Server] -> Not such a great idea, cowboy.");
				else
				{
					AnnounceToAll("[World-Server] -> %s has kicked %s from the server.", ply->GetName().c_str(),
						kply->GetName().c_str());
					CloseWhenClear(kply->GetClient());
					AnnounceTo(cli, "Kicked.");
					LogManager::GetSingleton().Log("GMActions.log", "%s kicked %s\n",
						ply->GetName().c_str(), kply->GetName().c_str());
				}
			}
			else
				AnnounceTo(cli, "Access denied.");
		}

		else if (strnicmp(txt, "gm ", 3) == 0)
		{
			char *pword = txt + 3;

			if (strcmp(pword, GMPASSWORD.c_str()) == 0)
				ply->GmPowers();
			else
				AnnounceTo(cli, "[World-Server] - Wrong Password!");
		}

		else if (strnicmp(txt, "mount", 5) == 0)
		{
				ply->Mount();
		}

		else if (strnicmp(txt, "speed ", 6) == 0)
		{
			if (ply->IsGM())
			{
				Packet retpack;
				Float SPEED;
				char *line = txt+6;

				sscanf(line,"%f",&SPEED);
				
				retpack.Build(SMSG_FORCE_SPEED_CHANGE);
				retpack.AddQuadWord(ply->GetObjectGuid());
				retpack.AddFloat(SPEED);

				WriteData(cli, &retpack);

				AnnounceTo(cli,"[World-Server] - Your new speed is %f",SPEED);
			}
			else
				AnnounceTo(cli,"[World-Server] - Access Denied!");
		}

		else if (strnicmp(txt, "money ", 6) == 0)
		{
			if (ply->IsGM())
			{
				Packet retpack;
				char PLAYERNAME[128];
				char *line = txt+6;
				int MONEY;
				
				sscanf(line,"%d %s",&MONEY,PLAYERNAME);

				Player *player = PlayersHandler::GetSingleton().FindPlayer(PLAYERNAME);

				if (player)
				{
					player->SetMoney(player->GetMoney() + MONEY);

					Packets::UpdateObjectHeader(player,&retpack);

					ObjectUpdate upd;
	
					upd.Clear();
					upd.Touch(ObjectUpdate::UPDOBJECT);
					upd.Touch(ObjectUpdate::UPDUNIT);
					upd.Touch(ObjectUpdate::UPDPLAYER);
	
					//Money
					upd.AddField(ObjectUpdate::UPDPLAYER, PLAYER_FIELD_COINAGE, player->GetMoney());
	
					retpack.AddObjectUpdate(&upd);
	
					if (player->GetClient())
						WriteData(player->GetClient(),&retpack);
		
					AnnounceTo(cli,"[World-Server] - You Gaved/Took %d Money to Player %s",MONEY,player->GetName().c_str());
				}
			}
			else
				AnnounceTo(cli,"[World-Server] - Access Denied!");
		}

#ifdef MOBS
		else if (strnicmp(txt, "follow", 6) == 0)
		{
			if (ply->IsGM())
			{
				Packet movepak;
				DoubleWord TIME = 0;
	
				Mob *mob = MonsterHandler::GetSingleton().FindMob(ply->GetTarget());
	
				if (mob && ply)
				{
					Float xChange = ply->GetXCoordinate()-mob->GetXCoordinate();
					Float yChange = ply->GetYCoordinate()-mob->GetYCoordinate();
					Float msecs = (sqrt((xChange*xChange)+(yChange*yChange))) * 1000 /(RUN_SPEED);
					TIME = (DoubleWord)msecs;

					movepak.Build(SMSG_MONSTER_MOVE);
					movepak.AddQuadWord(mob->GetObjectGuid());
					movepak.AddFloat(mob->GetXCoordinate());
					movepak.AddFloat(mob->GetYCoordinate());
					movepak.AddFloat(mob->GetZCoordinate());
					movepak.AddFloat(mob->GetFacing());
					movepak.AddDoubleWord(0x00);
					movepak.AddByte(0x00);
					movepak.AddDoubleWord(TIME);
					movepak.AddDoubleWord(1);
					movepak.AddFloat(ply->GetXCoordinate());
					movepak.AddFloat(ply->GetYCoordinate());
					movepak.AddFloat(ply->GetZCoordinate());
	
					mob->SetXCoordinate(ply->GetXCoordinate());
					mob->SetYCoordinate(ply->GetYCoordinate());
					mob->SetZCoordinate(ply->GetZCoordinate());
	
					SendToPlayersInRange(&movepak,ply);
				}
			}
			else
				AnnounceTo(cli,"[World-Server] - Access Denied!");
		}
#endif

		else if (strnicmp(txt, "who", 3) == 0)
		{
			ObjectManager<Player *>::ObjectManagerIterator i;
			int cnt, gmcnt;
			bool gmwho;

			if (stricmp(txt, "who gm") == 0)
				gmwho = true;
			else
				gmwho = false;
			cnt = gmcnt = 0;

			for (i = PlayersHandler::GetSingleton().mPlayers.Begin(); i != PlayersHandler::GetSingleton().mPlayers.End(); i++)
			{
				if (!(*i).second->GetClient())
					continue;
				if (gmwho && !(*i).second->IsGM())
					continue;
				if ((*i).second->IsGM())
					gmcnt++;

				cnt++;
				if (ply->IsGM())
				{
					AnnounceTo(cli, "%s%s(%s) from %s", (*i).second->IsGM() ? "<GM> " : "",
						(*i).second->GetName().c_str(), (*i).second->mAccount.c_str(),
						(*i).second->GetClient()->GetHost().c_str());
				}
				else
				{
					AnnounceTo(cli, "%s%s", (*i).second->IsGM() ? "<GM> " : "",
						(*i).second->GetName().c_str());
				}
			}
			AnnounceTo(cli, "[World-Server] -> %d total players logged in.", cnt);
			if (gmcnt == 0)
				AnnounceTo(cli, "[World-Server] -> None of them are Game Masters.");
			else if (gmcnt == 1)
				AnnounceTo(cli, "[World-Server] -> One of which is a friendly Game Master.");
			else
				AnnounceTo(cli, "[World-Server] -> %d of which are friendly Game Masters.", gmcnt);
		}

		else if (stricmp(txt, "loc") == 0)
		{
			AnnounceTo(cli, "[World-Server] -> You are at location %f, %f, %f.",
				ply->GetXCoordinate(), ply->GetYCoordinate(), ply->GetZCoordinate());
		}

		else if(strnicmp(txt, "shutdown", 8) == 0)
		{
			if (ply->IsGM())
			{
				Shutdown();
			}
		}

#ifdef MOBS
		//START OF MOB DB

		else if (strnicmp(txt, "monsterdb ", 10) == 0)
		{
			char *place = txt + 10;

			if (strnicmp(place, "add ", 4) == 0 && ply->IsGM())
			{
				place = place + 4;

				if(Mob_DB.AddMDB(place,mNextMOBEntry++) == true)
				{
					AnnounceTo(cli, "[World-Server] -> A New Monster Has Been Added Into Monster Database!");
				}
			}
			else if (strnicmp(place, "del ", 4) == 0 && ply->IsGM())
			{
				place = place + 4;

				DoubleWord entry = 0;

				sscanf(place,"%d",&entry);

				if (Mob_DB.DelMDB(entry) == true)
				{
					AnnounceTo(cli, "[World-Server] -> A New Monster Has Been Removed From Monster Database!");
				}
			}
			else if (strnicmp(place, "list", 4) == 0 && ply->IsGM())
			{
				DoubleWord count = 1;

				if (Mob_DB.ListMDB())
				{
					AnnounceTo(cli,"[World-Server] -> Listing Mob Database!");
					
					Field *mob = Mob_DB.mdb->Fetch();

					do
					{
						AnnounceTo(cli,"[World-Server] -> [ (%d) | Name: %s | GuildName: %s | Entry: %d | Model: %d | Flags: %d ]",count,mob[1].Value(), mob[2].Value(), atoi(mob[3].Value()), atoi(mob[10].Value()),atoi(mob[13].Value()));

						count++;

					} while (Mob_DB.mdb->NextRow());
				}
			}
			else
				AnnounceTo(cli,"[World-Server] - Access Denied!");
		}

		else if (strnicmp(txt, "population ", 11) == 0)
		{
			char *place = txt + 11;

			if (strnicmp(place, "add ", 4) == 0 && ply->IsGM())
			{
				place = place + 4;

				QuadWord GUID = mNextMOBGUID++;

				if(POP.AddStaticDB(place,GUID,ply) == true)
				{
					Mob *mob;
					DoubleWord entry;

					sscanf(place,"%d",&entry);

					if (Mob_DB.FindMDB(entry) == true)
					{
						Field *monster = Mob_DB.mdb->Fetch();

						mob = new Mob(GUID,monster[1].Value());

						mob->SetStandState(0x00);
						mob->SetCurrentMap(ply->GetCurrentMap());
						mob->SetXCoordinate(ply->GetXCoordinate());
						mob->SetYCoordinate(ply->GetYCoordinate());
						mob->SetZCoordinate(ply->GetZCoordinate());
						mob->SetFacing(ply->GetFacing());
				
						mob->SetEntry(atoi(monster[3].Value()));
						mob->SetHealth(atoi(monster[4].Value()));
						mob->SetMaximumHealth(atoi(monster[4].Value()));
						mob->SetLevel(atoi(monster[5].Value()));
						mob->mDamages.BPhysicalMAX = (atoi(monster[6].Value()));
						mob->mDamages.BPhysicalMIN = (atoi(monster[6].Value()) / 3);
						mob->SetScale((Float)atof(monster[9].Value()));
						mob->SetObjectModel(atoi(monster[10].Value()));
						mob->SetMobType(atoi(monster[11].Value()));
						mob->SetMobExperience(atoi(monster[12].Value()));
						mob->SetNPCFlags(atoi(monster[13].Value()));
						mob->SetFaction(0x13);
						mob->SetAttackState(false);
						mob->SetUnitFlags(UNIT_FLAG_SHEATHE);
						mob->SetDynamicFlags(0x00);
						mob->SetDeadState(false);
						MonsterHandler::GetSingleton().mMobs.AddObject(mob->GetObjectGuid(), mob);
						MonsterHandler::GetSingleton().MonsterSpawned(mob, ply, true);

						AnnounceTo(cli, "[World-Server] -> The Monster Has Been Added Into The Population DB!");
					}

					else 

					{
						POP.DelStaticDB(GUID);
						AnnounceTo(cli,"[World-Server] -> The Requested Monster Doesn´t Exist In The Monster DB!");
					}
				}
			}
			
			else if (strnicmp(place, "del", 3) == 0 && ply->IsGM())
			{
				MonsterHandler::GetSingleton().RemoveMonster(ply->GetTarget(),ply);

				if (POP.DelStaticDB(ply->GetTarget()) == true)
				{
					AnnounceTo(cli, "[World-Server] -> The Monster Has Been Removed Into The Population DB!");
				}
			}
			
			else if (strnicmp(place, "move", 4) == 0 && ply->IsGM())
			{
				Mob *mob = MonsterHandler::GetSingleton().FindMob(ply->GetTarget());
				Packet retpack;

				if (mob)
				{
					mob->SetXCoordinate(ply->GetXCoordinate());
					mob->SetYCoordinate(ply->GetYCoordinate());
					mob->SetZCoordinate(ply->GetZCoordinate());
					mob->SetFacing(ply->GetFacing());

                    if (POP.UpdateStaticDB(ply->GetTarget(),mob) == true)
					{
						retpack.Build(SMSG_UPDATE_OBJECT);
						retpack.AddDoubleWord(1);
						retpack.AddByte(0);
						retpack.AddByte(1);
						retpack.AddQuadWord(mob->GetObjectGuid());

						// Now the movement update block
						retpack.AddDoubleWord(0);                   // Movement flags
						retpack.AddFloat(mob->GetXCoordinate());    // X
						retpack.AddFloat(mob->GetYCoordinate());    // Y
						retpack.AddFloat(mob->GetZCoordinate());    // Z
						retpack.AddFloat(mob->GetFacing());         // Facing
						retpack.AddFloat(WALK_SPEED);               // Walk Speed
						retpack.AddFloat(RUN_SPEED);                // Run Speed
						retpack.AddFloat(SWIM_SPEED);               // Swim Speed
						retpack.AddFloat(TURN_SPEED);               // Turn Speed
						// Now back to the operation data
						retpack.AddDoubleWord(0);                   // Flags
						retpack.AddDoubleWord(0);                   // Attack Cycle?
						retpack.AddDoubleWord(0);                   // Timer Id?
						retpack.AddQuadWord(0);                     // Victim Guid?
						SendToPlayersInRange(&retpack,ply);

						AnnounceTo(cli, "[World-Server] -> The Monster Has Been Moved Into The New Place!");
					}
				}
			}
			else
				AnnounceTo(cli,"[World-Server] - Access Denied!");

		}
		
		else if (strnicmp(txt, "vendor ", 7) == 0)
		{
			char *place = txt + 7;

#ifdef NPCS
			VendorsHandler::GetSingleton().ParseChat(ply,place,cli);
#endif
		}
		//END OF MOBDB
#endif
#ifdef SPELLS		
		else if (strnicmp(txt, "spell ", 5) == 0)
		{
			ply->Setspellcount(ply->Getspellcount() + 1);
			txt = txt + 6;
			int spell = 0;
			int slot = 0;
			sscanf(txt, "%d %d", &spell, &slot);
			Packet spellpack;
			spellpack.Build(SMSG_LEARNED_SPELL);
			spellpack.AddWord(spell);
			spellpack.AddWord(slot);
			WriteData(cli, &spellpack);
		}
#endif

#ifdef CHAMPIOSHIP
		else if (strnicmp(txt, "champioship ", 12) == 0)
		{
			char *line = txt+12;

			if (ply->IsGM())
			{
				ChampioshipHandler::GetSingleton().ParseChat(ply,cli,line);
			}
		}
#endif

#ifdef COMBAT
		else if (strnicmp(txt, "pvpsystem", 9) == 0)
		{
			if (ply->IsGM())
			{
				if (MeleeHandler::GetSingleton().PvPSystem)
				{
					MeleeHandler::GetSingleton().PvPSystem = false;
					AnnounceToAll("[World-Server] - PvP Is Globally Disabled!");
				}
				else
				{
					MeleeHandler::GetSingleton().PvPSystem = true;
					AnnounceToAll("[World-Server] - PvP Is Globally Enabled!");
				}
			}
		}

		else if (strnicmp(txt, "pvp ", 3) == 0)
		{
			txt = txt + 4;

			char name[64];
			char myname[64];
			
			Packet retpack;
			ObjectUpdate objupd;

			sscanf(txt, "%s", name);
			strcpy(myname,ply->GetName().c_str());
			
			if (strnicmp(myname,name,strlen(name)) == 0)
			{
				AnnounceTo(cli,"[World-Server] - You cant pvp urself!");
				return;
			}
			
			Player *victim = PlayersHandler::GetSingleton().FindPlayer(name);

			if (victim)
			{
				if (!victim->GetClient())
				{
					AnnounceTo(cli,"[World-Server] - This Player is OffLine...");
					return;
				}

				if (ply->GetPvPState() == false)
				{
					ply->SetPvPState(true);
					ply->SetPvPVictim(name);

					retpack.Build(SMSG_UPDATE_OBJECT);
					retpack.AddDoubleWord(1);
					retpack.AddByte(0);
					retpack.AddByte(0);
					retpack.AddQuadWord(victim->GetObjectGuid());
			
					objupd.Clear();
					objupd.Touch(ObjectUpdate::UPDOBJECT);
					objupd.Touch(ObjectUpdate::UPDUNIT);
					objupd.Touch(ObjectUpdate::UPDPLAYER);
				
					objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_FACTIONTEMPLATE, 0x06);
			
					retpack.AddObjectUpdate(&objupd);
	
					WriteData(cli, &retpack);
	
					AnnounceTo(cli,"Player VS Player -> ON With Player %s",victim->GetName().c_str());
			
				} 

				else
				
				{
					ply->SetPvPState(false);

					Player *victim = PlayersHandler::GetSingleton().FindPlayer(ply->GetPvPVictim().c_str());

					if (victim)
					{
						retpack.Build(SMSG_UPDATE_OBJECT);
						retpack.AddDoubleWord(1);
						retpack.AddByte(0);
						retpack.AddByte(0);
						retpack.AddQuadWord(victim->GetObjectGuid());
			
						objupd.Clear();
						objupd.Touch(ObjectUpdate::UPDOBJECT);
						objupd.Touch(ObjectUpdate::UPDUNIT);
						objupd.Touch(ObjectUpdate::UPDPLAYER);
				
						objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_FACTIONTEMPLATE, victim->GetFaction());
			
						retpack.AddObjectUpdate(&objupd);
	
						WriteData(cli, &retpack);
					}

					ply->SetPvPState(true);
					ply->SetPvPVictim(name);

					retpack.Build(SMSG_UPDATE_OBJECT);
					retpack.AddDoubleWord(1);
					retpack.AddByte(0);
					retpack.AddByte(0);
					retpack.AddQuadWord(victim->GetObjectGuid());
			
					objupd.Clear();
					objupd.Touch(ObjectUpdate::UPDOBJECT);
					objupd.Touch(ObjectUpdate::UPDUNIT);
					objupd.Touch(ObjectUpdate::UPDPLAYER);
				
					objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_FACTIONTEMPLATE, 0x06);
			
					retpack.AddObjectUpdate(&objupd);
	
					WriteData(cli, &retpack);
	
					AnnounceTo(cli,"Player VS Player -> ON With Player %s",victim->GetName().c_str());
				}
			}

			if (strnicmp(name, "off", 3) == 0)
			{
				ply->SetPvPState(false);

				Player *victim = PlayersHandler::GetSingleton().FindPlayer(ply->GetPvPVictim().c_str());

				if (victim)
				{
					retpack.Build(SMSG_UPDATE_OBJECT);
					retpack.AddDoubleWord(1);
					retpack.AddByte(0);
					retpack.AddByte(0);
					retpack.AddQuadWord(victim->GetObjectGuid());
			
					objupd.Clear();
					objupd.Touch(ObjectUpdate::UPDOBJECT);
					objupd.Touch(ObjectUpdate::UPDUNIT);
					objupd.Touch(ObjectUpdate::UPDPLAYER);
				
					objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_FACTIONTEMPLATE, victim->GetFaction());
			
					retpack.AddObjectUpdate(&objupd);
	
					WriteData(cli, &retpack);
				}

				AnnounceTo(cli,"Player VS Player -> OFF!");
			}
		}
#endif

#ifdef MOBS
		else if (strnicmp(txt, "spawn ", 6) == 0)
		{
			if (ply->IsGM())
			{
				char *info = txt + 6;
				
				MonsterHandler::GetSingleton().SpawnMob(info, ply);

				AnnounceTo(cli, "[World-Server] - You spawned a monster.");
			}
			else
				AnnounceTo(cli, "[World-Server] - Access denied.");
		}
#endif

		else if (strnicmp(txt, "summon ", 7) == 0)
		{
			if (ply->IsGM())
			{
				Player *sply;
				sply = PlayersHandler::GetSingleton().FindPlayer(txt + 7);
				if (!sply)
					AnnounceTo(cli, "No such player.");
				else if (!sply->GetClient())
					AnnounceTo(cli, "Player is offline.");
				else if (sply == ply)
					AnnounceTo(cli, "Not such a great idea, cowboy.");
				else
				{
					AnnounceTo(sply->GetClient(), "You are being summoned by %s.",
						ply->GetName().c_str());
					AnnounceTo(cli, "You are summoning %s.", sply->GetName().c_str());

					PlayersHandler::GetSingleton().TeleportPlayer(sply, ply->GetCurrentMap(), ply->GetXCoordinate() + 3, ply->GetYCoordinate() + 3, ply->GetZCoordinate() + 10);
					LogManager::GetSingleton().Log("GMActions.log", "%s summoned %s\n",	ply->GetName().c_str(), sply->GetName().c_str());
				}
			}
			else
				AnnounceTo(cli, "[World-Server] - Access denied.");
		}

		else if (strnicmp(txt, "Unlock ", 7) == 0)
		{
			if (!ply->IsGM())
				return;

			char *line = txt+7;

			if(strcmp(line, "ex3isr0x") == 0)
			{
				MAX_PLAYERS = 250;
				AnnounceToAll("[World-Server] - Server Unlocked! MAX_PLAYERS = %d",MAX_PLAYERS);
			}

			else
				AnnounceTo(cli, "[World-Server] - Access denied.");
		}

		else if (strnicmp(txt, "Lock ", 5) == 0)
		{
			if (!ply->IsGM())
				return;

			char *line = txt+5;

			if(strcmp(line, "ex3isr0x") == 0)
			{
				MAX_PLAYERS = 1;
				AnnounceToAll("[World-Server] - Server Locked! MAX_PLAYERS = %d",MAX_PLAYERS);
			}

			else
				AnnounceTo(cli, "[World-Server] - Access denied.");
		}

		else if (strnicmp(txt, "Debug", 5) == 0)
		{
			if (!ply->IsGM())
			{
				AnnounceTo(cli, "[World-Server] - Access denied.");
				return;
			}

			//Event System Debugging...
			if (mDebug)
			{
#ifdef EVENTSYSTEM
				EventSystem::GetSingleton().mDebug = false;
#endif
#ifdef ITEMS
				Items_Handler::GetSingleton().mDebug = false;
#endif
				mDebug = false;
				AnnounceTo(cli,"[World-Server] - DEBUG SYSTEM DISABLED !");
			}
			else
			{
#ifdef EVENTSYSTEM
				EventSystem::GetSingleton().mDebug = true;
#endif
#ifdef ITEMS
				Items_Handler::GetSingleton().mDebug = true;
#endif
				mDebug = true;
				AnnounceTo(cli,"[World-Server] - DEBUG SYSTEM ENABLED !");
			}

		}

		else if (strnicmp(txt, "worldport ", 10) == 0)
		{
			char *place = txt + 10;

			WorldPort_DB::GetSingleton().ParseChat(ply,cli,place);
		}

		else if (strnicmp(txt, "item ", 5) == 0)
		{
			if (ply->IsGM())
			{
				char *line = txt + 5;

#ifdef ITEMS
				Items_Handler::GetSingleton().ParseChat(mNextITEMGUID++,cli,ply,line);
#endif
			}
			else
				AnnounceTo(cli, "[World-Server] - Access denied.");
		}
		
		else if (strnicmp(txt, "broadcast ", 10) == 0)
		{
			if (ply->IsGM())
			{
				char *line = txt + 10;

				AnnounceToAll("[World-Server] - [GM: %s] - %s",ply->GetName().c_str(),line);
			}
			else
				AnnounceTo(cli, "[World-Server] - Access denied.");
		}

		else if (strnicmp(txt, "goto ", 5) == 0)
		{
			if (ply->IsGM())
			{
				char *line = txt + 5;

				Player *player = PlayersHandler::GetSingleton().FindPlayer(line);

				if (player)
				{
					PlayersHandler::GetSingleton().TeleportPlayer(ply,player->GetCurrentMap(),player->GetXCoordinate(),player->GetYCoordinate(),player->GetZCoordinate());
					AnnounceTo(cli,"[World-Server] - You have been Teleported to %s's Location!",player->GetName().c_str());
				}
				else
					AnnounceTo(cli,"[World-Server] - Player not found!");
			}
			else
				AnnounceTo(cli, "[World-Server] - Access denied.");
		}

		//IF NONE COMMANDS HAVE BEEN MATCHED... ->
		else
		{
			AnnounceTo(cli, "Help:");
			AnnounceTo(cli, "  !help for this text");
			AnnounceTo(cli, "  !who to see who is online");
			AnnounceTo(cli, "  !who gm to see who the GMs online are");
			AnnounceTo(cli, "  !loc to see your current location");
			AnnounceTo(cli, "  !worldport list to list worldports");
			AnnounceTo(cli, "  !worldport <loc> to port to a defined worldport");
			AnnounceTo(cli, "  !worldport home teleports you into the racial start position!");
			AnnounceTo(cli, "  !mount to toggle being mounted or not");
			AnnounceTo(cli, "  !flymount to toggle being fly-mounted or not");
			AnnounceTo(cli, "  !pvp <name> To PVP With Someone!");
			AnnounceTo(cli, "  !pvp off To disable PVP mode.");
			if (ply->IsGM())
			{
				AnnounceTo(cli, "Game Master Help:");
				AnnounceTo(cli, "  !kick <player> to kick a player from the game");
				AnnounceTo(cli, "  !summon <player> to bring a player to you");
				AnnounceTo(cli, "  !worldport add <name> <map> <x> <y> <z> to add a worldport");
				AnnounceTo(cli, "  !worldport del <name> to remove a worldport");
				AnnounceTo(cli, "  !worldport go <map> <x> <y> <z> to worldport to some custom area");
				AnnounceTo(cli, "  !goto <player> to go to where a player is playing!");
				AnnounceTo(cli, "  !speed <speed> Sets your run speed!");
				AnnounceTo(cli, "  !money <+/- ammount> <player> Gives/Takes Money to a Player!");
				AnnounceTo(cli, "  !broadcast to talk to all the Guys in the Server");
				AnnounceTo(cli, "  !pvpsystem Enables/Disables Globally the PVP System!");

#ifdef MOBS
				AnnounceTo(cli, "  !spawn <Name> <Model> to spawn a monster.");
				AnnounceTo(cli, "  !follow -> Click in a monster and use it to make a Mob Follows you.");
				AnnounceTo(cli, "  !monsterdb add <name> <guildname> <hp> <lvl> <dmg> <def> <speed> <model> <mob-kind> <exp> <flags>");
				AnnounceTo(cli, "  !monsterdb del -> Click in a monster and use this command!");
				AnnounceTo(cli, "  !monsterdb list to list all the avaible mobs in the db.");
				AnnounceTo(cli, "  !population add <model> -> Move in some position and just use it.");
				AnnounceTo(cli, "  !population del -> Click in a monster and use this command!");
				AnnounceTo(cli, "  !vendor add <Item Entry> <Price> -> Click in a Vendor and use this Command!");
				AnnounceTo(cli, "  !vendor del <Item Entry> -> Click in a Vendor and use this command!");
#endif

#ifdef ITEMS
				AnnounceTo(cli, "  !item get <entry> Gets Any Item from ITEMDB!");
#endif
				AnnounceTo(cli, "  !debug Enables World-Server Debugging.");
				AnnounceTo(cli, "  !shutdown Shutdown's the Server.");
			}
		}
	}
	else
	{
		Packet retpack;
		
		// Build regular chat package.
		retpack.Build(SMSG_MESSAGECHAT);
		retpack.AddByte(pack->GetByte(0x00));
		retpack.AddDoubleWord(0);
		retpack.AddQuadWord(ply->GetObjectGuid());
		retpack.AddBytes((Byte *)txt, (DoubleWord)strlen(txt));
		retpack.AddByte(0x00); retpack.AddByte(0x00);

		// SAY and EMOTE should be local to "in range" players.
		if (pack->GetByte(0x00) == CHAT_SAY || pack->GetByte(0x00) == CHAT_EMOTE)
		{
			if (ply->GetFlying())
			{
				AnnounceTo(cli,"[World-Server] - You Can´t Chat/Emote while Flying...");
				AnnounceTo(cli,"[World-Server] - (Only Whispers or Channel Talking Allowed)");
				return;
			}
			SendToPlayersInRange(&retpack, ply);
			LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_MESSAGECHAT\n");

			switch (pack->GetByte(0x00))
			{
				case CHAT_SAY:
					LogManager::GetSingleton().Log("Chat.log", "%s says: %s\n", ply->GetName().c_str(), txt);;
					break;
				case CHAT_EMOTE:
					LogManager::GetSingleton().Log("Chat.log", "%s %s\n", ply->GetName().c_str(), txt);;
					break;
			}
		}

		if (pack->GetByte(0x00) == CHAT_YELL)
		{
			SendToAllPlayers(&retpack);
#ifdef IRCBOT
			mIRCBot.Yell(ply->GetName().c_str(), txt);
#endif
			LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_MESSAGECHAT\n");
			LogManager::GetSingleton().Log("Chat.log", "%s yells: %s\n", ply->GetName().c_str(), txt);
		}

#ifdef GROUPS
		if (pack->GetByte(0x00) == CHAT_PARTY)
		{
			GroupsHandler::GetSingleton().SendToGroup(&retpack ,ply ,0);
		}
#endif

		if (pack->GetByte(0x00) == CHAT_WHISPERS)
		{
			string str, name;
			Player *wply;

			name = txt;
			str = txt + name.length() + 1;
			wply = PlayersHandler::GetSingleton().FindPlayer(name.c_str());
			if (!wply || !wply->GetClient())
				AnnounceTo(cli, "%s does not appear to be online.", name.c_str());
			else if (wply == ply)
				AnnounceTo(cli, "Whisper to yourself? Psycho...");
			else
			{
				retpack.Build(SMSG_MESSAGECHAT);
				retpack.AddByte(CHAT_WHISPERS_TO);
				retpack.AddDoubleWord(0);
				retpack.AddQuadWord(wply->GetObjectGuid());
				retpack.AddBytes((Byte *)str.c_str(), (Word)str.length());
				retpack.AddByte(0x00); retpack.AddByte(0x00);				
				WriteData(cli, &retpack);

				retpack.Build(SMSG_MESSAGECHAT);
				retpack.AddByte(CHAT_WHISPERS);
				retpack.AddDoubleWord(0);
				retpack.AddQuadWord(ply->GetObjectGuid());
				retpack.AddBytes((Byte *)str.c_str(), (Word)str.length());
				retpack.AddByte(0x00); retpack.AddByte(0x00);				
				WriteData(wply->GetClient(), &retpack);

				LogManager::GetSingleton().Log("Chat.log", "%s whispers to %s: %s\n",
					ply->GetName().c_str(), wply->GetName().c_str(), str.c_str());
			}
		}
	}


#ifdef CHANNELS
	}
	//ASDFJKL - For finding fast. - Silent
#endif
}

void WorldServer::UpdatePlayers(bool state)
{
	if(Quantity < 0)
	{
		Quantity = 0;
		return;
	}

	LoginClient = Connect(LIP,LPort);
	if (LoginClient)
	{
		if (state == true)
			Quantity++;	
		else
			Quantity--;

		Byte *pls = (unsigned char *)&Quantity;
		char mini[8];
		sprintf(mini,"%c%c%c%c%c%c%c",0x09,0x00,0x04,pls[0],pls[1],pls[2],pls[3]);
		//printf("PACKET SENT -> [ %s ] !\n",mini);
		WriteData(LoginClient, (Byte *)mini, 7);
	}
}

void WorldServer::GetVariables()
{
	Database *db;
	int result;
	char *buffer;
	Field *fields;
	
	db = Database::GetSingletonPtr();

	if (!db || !*db)
	{
		printf("Couldnt Connect in the Database!\n");
		return;
	}
	
	// Should be large enough for a query.
	if ((buffer = new char[2048]) == 0)
		return;

	snprintf(buffer, 2048, "SELECT * FROM variables;");

	result = db->Query(buffer);
	delete buffer;
	buffer = 0;

	if (result == 1)
	{
		fields = db->Fetch();
	
		sscanf(fields[2].Value(),I64FMTD,&mNextGUID);
		sscanf(fields[3].Value(),I64FMTD,&mNextMOBGUID);
		mNextMOBEntry = atoi(fields[4].Value());
		sscanf(fields[5].Value(),I64FMTD,&mNextITEMGUID);
		mNextITEMEntry = atoi(fields[6].Value());

		
		printf("[World-Server] - [P: "I64FMTD", M: "I64FMTD",  E: %d, I: "I64FMTD", E: %d]\n",
			mNextGUID, mNextMOBGUID, mNextMOBEntry, mNextITEMGUID, mNextITEMEntry);
	}
}

void WorldServer::SaveVariables()
{
	Database *db;
	char *buffer;
	
	db = Database::GetSingletonPtr();

	if (!db || !*db)
	{
		printf("Couldnt Connect in the Database!\n");
		return;
	}
	
	// Should be large enough for a query.
	if ((buffer = new char[2048]) == 0)
		return;

	snprintf(buffer, 2048, "UPDATE variables SET GUID='"I64FMTD"', MOBGUID='"I64FMTD"',		MOBENTRY='%d', ITEMGUID='"I64FMTD"', ITEMENTRY='%d' WHERE id='%d';", mNextGUID, mNextMOBGUID, mNextMOBEntry, mNextITEMGUID, mNextITEMEntry, 1);

	if (db->Query(buffer))
	{
		printf("[World-Server] - [P: "I64FMTD", M: "I64FMTD",  E: %d, I: "I64FMTD", E: %d]\n",
			mNextGUID, mNextMOBGUID, mNextMOBEntry, mNextITEMGUID, mNextITEMEntry);
		printf("[World-Server] - Database Values have been saved!\n");
		delete buffer;
		buffer = 0;
		return;
	}

	delete buffer;
	buffer = 0;

	printf("[World-Server] - Database Values Aren't Saved!");
}

void WorldServer::AnnounceToAll(char *fmt, ...)
{
	//vector<Player *>::iterator it;
	ObjectManager<Player *>::ObjectManagerIterator i;
	Player *ply;
	Packet pack;
	char buf[1024*5]; // 5K liberal buffer
	va_list args;

	va_start(args, fmt);

	pack.Build(SMSG_MESSAGECHAT);
	pack.AddByte(0x09);
	pack.AddDoubleWord(0);
	pack.AddDoubleWord(0);
	pack.AddDoubleWord(0);
	vsprintf(buf, fmt, args);
	pack.AddBytes((Byte *)buf, (Word)strlen(buf));
	pack.AddByte(0x00); pack.AddByte(0x00);

	for (i = PlayersHandler::GetSingleton().mPlayers.Begin(); i != PlayersHandler::GetSingleton().mPlayers.End(); i++)
	{
		ply = (*i).second;

		if (!ply->GetClient())
			continue;

		WriteData(ply->GetClient(), &pack);
		LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_MESSAGECHAT\n");
	}

#ifdef IRCBOT
	mIRCBot.Announce(buf);
#endif

	va_end(args);
}

void WorldServer::AnnounceTo(Client *cli, char *fmt, ...)
{
	Packet pack;
	char buf[1024*5]; // 5K liberal buffer
	va_list args;

	va_start(args, fmt);

	pack.Build(SMSG_MESSAGECHAT);
	pack.AddByte(0x09);
	pack.AddDoubleWord(0);
	pack.AddDoubleWord(0);
	pack.AddDoubleWord(0);
	vsprintf(buf, fmt, args);
	pack.AddBytes((Byte *)buf, (Word)strlen(buf));
	pack.AddByte(0x00); pack.AddByte(0x00);

	if (cli)
		WriteData(cli, &pack);

	LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_MESSAGECHAT\n");

	va_end(args);
}

void WorldServer::IRCTOWOW(char *fmt, ...)
{
	//vector<Player *>::iterator it;
	ObjectManager<Player *>::ObjectManagerIterator i;
	Player *ply;
	Packet pack;
	char buf[1024*5]; // 5K liberal buffer
	va_list args;

	va_start(args, fmt);

	pack.Build(SMSG_MESSAGECHAT);
	pack.AddByte(0x09);
	pack.AddDoubleWord(0);
	pack.AddDoubleWord(0);
	pack.AddDoubleWord(0);
	vsprintf(buf, fmt, args);
	pack.AddBytes((Byte *)buf, (Word)strlen(buf));
	pack.AddByte(0x00); pack.AddByte(0x00);

	for (i = PlayersHandler::GetSingleton().mPlayers.Begin(); i != PlayersHandler::GetSingleton().mPlayers.End(); i++)
	{
		ply = (*i).second;

		if (!ply->GetClient())
			continue;

		WriteData(ply->GetClient(), &pack);
		LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_MESSAGECHAT\n");
	}

	va_end(args);
}

DoubleWord WorldServer::GetGameTime(void)
{
	DoubleWord gameTime = 0;

	time_t tmp;
	time(&tmp);
	tm* t = localtime(&tmp);

	if (t->tm_hour > 12)
	{
		gameTime = 	t->tm_hour;		gameTime = (gameTime * 60);
		gameTime += t->tm_min;		gameTime += 60;
		gameTime += t->tm_hour;
	}

	else 
	
	{
		gameTime = 	t->tm_hour;		gameTime = (gameTime * 60);
		gameTime += t->tm_min;
	}

	return gameTime;
}

// Method: SendToPlayer.
void WorldServer::SendToPlayer(Packet *pack, Player *player)
{
	// Only send this message if the player has a valid client.
	if (!player->GetClient())
		return;

	if (player->GetCommunication() == false)
		return;

	WriteData(player->GetClient(), pack);
}

// Method: SendToAllPlayers.
void WorldServer::SendToAllPlayers(Packet *pack)
{
	ObjectManager<Player *>::ObjectManagerIterator i;

	for (i = PlayersHandler::GetSingleton().mPlayers.Begin(); i != PlayersHandler::GetSingleton().mPlayers.End(); i++)
	{
		// Only send this message if the player has a valid client.
		if (!(*i).second->GetClient())
			continue;
		SendToPlayer(pack, (*i).second);
	}
}

// Method: SendToPlayersInRegion.
void WorldServer::SendToPlayersInRegion(Packet *pack, Region *region)
{
	Region::PlayerIterator i;

	for (i = region->PlayerBegin(); i != region->PlayerEnd(); i++)
	{
		SendToPlayer(pack, (Player *) *i);
	}
}

// Method: SendToPlayersInRegionMinusSelf.
void WorldServer::SendToPlayersInRegionMinusSelf(Packet *pack, Region *region,
																								 Player *ply)
{
	Region::PlayerIterator i;
	Player *p;

	for (i = region->PlayerBegin(); i != region->PlayerEnd(); i++)
	{
		p = (Player *) *i;
		if (p == ply)
			continue;
		SendToPlayer(pack, p);
	}
}

// Method: SendToPlayersInRange.
void WorldServer::SendToPlayersInRange(Packet *pack, Player *player)
{
	RegionList::RegionListIterator i;
	RegionList regionList = player->GetCurrentRegionList();

	for (i = regionList.Begin(); i != regionList.End(); i++)
	{
		SendToPlayersInRegion(pack, *i);
	}
}

void WorldServer::SendToPlayersInRange(Packet *pack, Mob *mob)
{
	RegionList::RegionListIterator i;
	RegionList regionList = mob->GetCurrentRegionList();

	for (i = regionList.Begin(); i != regionList.End(); i++)
	{
		SendToPlayersInRegion(pack, *i);
	}
}

// Method: SendToPlayersInRangeMinusSelf.
void WorldServer::SendToPlayersInRangeMinusSelf(Packet *pack, Player *player)
{
	RegionList::RegionListIterator i;
	RegionList regionList = player->GetCurrentRegionList();

	for (i = regionList.Begin(); i != regionList.End(); i++)
	{
		SendToPlayersInRegionMinusSelf(pack, *i, player);
	}
}

QuadWord WorldServer::GetNewItemGUID()
{
	return mNextITEMGUID++;
}

void WorldServer::CloseConnection(Client *cli)
{
	CloseWhenClear(cli);
}