// (c) Abyss Group
#include "LoginEnvironment.h"

template <class LoginServer> LoginServer *Singleton<LoginServer>::msSingleton = 0;

void SendRealms(void *Param)
{
	LoginServer::GetSingleton().ListRealms((Client *)Param);
}

LoginServer::LoginServer()
{
	mPlayers = 0;
}

LoginServer::~LoginServer()
{
}

void LoginServer::Run(void)
{
	ConfigCursor cfg = Config::GetSingleton().Cursor();

	if (!cfg.Find("LoginServer") || !cfg.FindIn("ListenPort"))
	{
		fprintf(stderr, "No configured ListenPort for LoginServer\n");
		return;
	}
	mLPort = atoi(cfg[0]);
	if (mLPort < 1024 || mLPort > 9999)
	{
		fprintf(stderr, "ListenPort must be between 1024 and 9999, not %d\n", mLPort);
		return;
	}
	cfg.Reset();
	if (!cfg.Find("LoginServer") || !cfg.FindIn("RedirectHost"))
	{
		fprintf(stderr, "No configured RedirectHost for LoginServer\n");
		return;
	}
	mRHost = cfg[0];
	cfg.Reset();
	if (!cfg.Find("LoginServer") || !cfg.FindIn("RedirectPort"))
	{
		fprintf(stderr, "No configured RedirectPort for LoginServer\n");
		return;
	}
	mRPort = atoi(cfg[0]);
	if (mRPort < 1024 || mRPort > 9999)
	{
		fprintf(stderr, "RedirectPort must be between 1024 and 9999, not %d\n", mRPort);
		return;
	}

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

	if (!Listen(mLPort))
		return;

	new EventSystem();

	while (true)
	{
		if (!Select())
			return;

		EventSystem::GetSingleton().CheckReadyEvents();
	}
}

void LoginServer::ClientConnected(Client *cli)
{
	cli->SetTimeout(60); // client times out in 1 minute
	//mClientMode[cli] = MODE_WAITING;
	LogManager::GetSingleton().Log("Debug.log", "Connection from %s\n", cli->GetHost().c_str());
	LogManager::GetSingleton().Log("Debug.log", "%d clients online\n", mClientCount);
}

void LoginServer::ClientDisconnected(Client *cli)
{
	LogManager::GetSingleton().Log("Debug.log", "Disconnection from %s(%s)\n",
		cli->GetHost().c_str(), mUserID[cli].c_str());
	LogManager::GetSingleton().Log("Debug.log", "%d clients online\n", mClientCount);

	//mClientMode.erase(cli);
	mUserID.erase(cli);
}

void LoginServer::ClientDataRecvd(Client *cli)
{
	const unsigned char challenge1[AUTH_CHALLENGE1_LEN] = AUTH_CHALLENGE1;
	const unsigned char challenge2[AUTH_CHALLENGE2_LEN] = AUTH_CHALLENGE2;

	LPacket pack;

	while (pack.FromInput(cli))
	{
		switch (pack.GetOpCode())
		{

		case CHALLENGE:{

				CheckDATA(pack,cli);
				EventSystem::GetSingleton().AddTimer(100,SendRealms,(void *)cli);

				}break;

		case RECODE_CHALLENGE:{

				CheckDATA(pack,cli);
				EventSystem::GetSingleton().AddTimer(100,SendRealms,(void *)cli);

				}break;

		case REALMLIST_REQUEST: {

				EventSystem::GetSingleton().AddTimer(100,SendRealms,(void *)cli);

				}break;
		case PLAYERS_UPDATE: {

				UpdatePlayers(&pack);

				}break;
		}
	}
}

void LoginServer::StateHandler(DoubleWord STATE, Client *cli)
{
	switch (STATE) {

		case 10:
			WriteData(cli, 3);
			WriteData(cli, 8);
			break;
	}
}


void LoginServer::CheckDATA(LPacket pack, Client *cli)
{
	char nick[128];
	DoubleWord i = 0;

	AccountManager *am = new AccountManager();

	// Verifying Current WoW Version...
	//if (pack.GetByte(0x05)!= 0x07 ||pack.GetByte(0x06) != 0x01 || pack.GetByte(0x07) != 0x76) //<-- old patch (.1 or so)
	//if (pack.GetByte(0x05)!= 0x07 || pack.GetByte(0x06) != 0x06 || pack.GetByte(0x07) != 0x80) //<-- New patch (20040615)
	if (pack.GetByte(0x05)!= 0x08 || pack.GetByte(0x06) != 0x00 || pack.GetByte(0x07) != 0x96) // <-- Newer patch (20040707)
	{
		WriteData(cli, 0x03);
		//WriteData(cli, 6); // account already online
		//WriteData(cli, 5); // wrong username/pass
		//WriteData(cli, 4); // ditto
		//WriteData(cli, 3); // failed
		//WriteData(cli, 7); // prepaid used up
		//WriteData(cli, 8); // try again later
		WriteData(cli, 0x09); // cannot validate game version
		return;
	}

	for(i = 0;i<pack.GetByte(29);i++)
		nick[i] = pack.GetByte(30+i);
	nick[i] = '\0';

	mUserID[cli] = nick;

	printf("[Login-Server] - User: %s Connected into the Realm List!\n",mUserID[cli].c_str());

	DoubleWord state = am->VerifyAccount(mUserID[cli].c_str(), "none");

	StateHandler(state, cli);

	if (state == 50)
	{
		am->CreateNewAccount(mUserID[cli].c_str(),"none");
		printf("[Login-Server] - User: %s Account has been added to DB!\n",mUserID[cli].c_str());
		state = 0;
	}

	if (state == 0)
		printf("[Login-Server] - User: %s Logging in...\n",mUserID[cli].c_str());

	if (state != 0)
		return;

	WriteData(cli, 0x03);
	WriteData(cli, (unsigned char)0x00);

	delete am;
}

void LoginServer::ListRealms(Client *cli)
{
	char buf[64];
	char List[128];

	unsigned char *P = (unsigned char *)&mPlayers;

	sprintf(buf, "%s:%d", mRHost.c_str(), mRPort);
	Word Size = sprintf(List,"%c%c%c%c%c%c%c%c%c%c%s%c%s%c%c%c%c%c",
	0x00,0x00,0x00,0x00,0x01,0x01,0x00,0x00,0x00,0x00,
	SERVER_NAME,0x00,buf,0x00,P[0],P[1],P[2],P[3]);

	Byte *Lenght = (unsigned char *)&Size;

	WriteData(cli, 0x10); // Opcode
	WriteData(cli, Lenght, 2); // Lenght
	WriteData(cli, (Byte *)List, Size); //Data
}

void LoginServer::UpdatePlayers(LPacket *pack)
{
	char recbuf[5];

	recbuf[0] = pack->GetByte(0x00);
	recbuf[1] = pack->GetByte(0x01);
	recbuf[2] = pack->GetByte(0x02);
	recbuf[3] = pack->GetByte(0x03);

	memcpy(&mPlayers,recbuf,4);

	printf("[Login-Server] - The Realm has now: [ %d Players Online]\n",mPlayers);
}