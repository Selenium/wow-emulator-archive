// (c) Abyss Group
#include "ConfigEnvironment.h"

template <class Config> Config *Singleton<Config>::msSingleton = 0;

Config::Config() : mConfigData(0), mConf(0)
{
}

Config::~Config()
{
	if (mConf)
		delete mConf;
	if (mConfigData)
		delete mConfigData;
}

bool Config::SetSource(const char *file, bool ignorecase)
{
	mConf = new DOTCONFDocument(ignorecase ?
		DOTCONFDocument::CASEINSENSETIVE :
		DOTCONFDocument::CASESENSETIVE);

	if (mConf->setContent(file) == -1)
	{
		delete mConf;
		mConf = NULL;
		return false;
	}

	return true;
}

int Config::Parse(char *error, int errorlen)
{
	char *usedb;
	if (!mConf)
		return 0;
	if (!mConfigData)
	{
		mConfigData = new _ConfigData;
		if (!mConfigData)
		{
			strncpy(error, "could not allocate memory for config data", errorlen);
			return 0;
		}
	}
	ConfigCursor c = Cursor();
	if (!c.Find("LoginServer"))
	{
		strncpy(error, "no LoginServer section", errorlen);
		return 0;
	}
	if (!c.FindIn("ListenPort") || !c[0])
	{
		strncpy(error, "ListenPort unspecified in LoginServer section", errorlen);
		return 0;
	}
	mConfigData->LoginServer.ListenPort = atoi(c[0]);
	c.Parent();
	if (!c.FindIn("RedirectHost") || !c[0])
	{
		strncpy(error, "RedirectHost unspecified in LoginServer section", errorlen);
		return 0;
	}
	mConfigData->LoginServer.RedirectHost = c[0];
	c.Parent();
	if (!c.FindIn("RedirectPort") || !c[0])
	{
		strncpy(error, "RedirectPort unspecified in LoginServer section", errorlen);
		return 0;
	}
	mConfigData->LoginServer.RedirectPort = atoi(c[0]);
	c.Reset();
	if (!c.Find("RedirectServer"))
	{
		strncpy(error, "no RedirectServer section", errorlen);
		return 0;
	}
	if (!c.FindIn("ListenPort") || !c[0])
	{
		strncpy(error, "ListenPort unspecified in RedirectServer section", errorlen);
		return 0;
	}
	mConfigData->RedirectServer.ListenPort = atoi(c[0]);
	c.Parent();
	if (!c.FindIn("RedirectHost") || !c[0])
	{
		strncpy(error, "RedirectHost unspecified in RedirectServer section", errorlen);
		return 0;
	}
	mConfigData->RedirectServer.RedirectHost = c[0];
	c.Parent();
	if (!c.FindIn("RedirectPort") || !c[0])
	{
		strncpy(error, "RedirectPort unspecified in RedirectServer section", errorlen);
		return 0;
	}
	mConfigData->RedirectServer.RedirectPort = atoi(c[0]);
	c.Reset();
	if (!c.Find("WorldServer"))
	{
		strncpy(error, "no WorldServer section", errorlen);
		return 0;
	}
	if (!c.FindIn("ListenPort") || !c[0])
	{
		strncpy(error, "ListenPort unspecified in WorldServer section", errorlen);
		return 0;
	}
	mConfigData->WorldServer.ListenPort = atoi(c[0]);
	c.Reset();
	if (!c.Find("Logging"))
	{
		strncpy(error, "no Logging section", errorlen);
		return 0;
	}
	if (!c.FindIn("LoginServer"))
	{
		strncpy(error, "no LoginServer section in Logging section", errorlen);
		return 0;
	}
	mConfigData->Logging.LoginServer.DatabaseMysql = 0;
	if (c.FindIn("DatabaseMysql.log"))
	{
		if (c[0] && !stricmp("on", c[0]))
			mConfigData->Logging.LoginServer.DatabaseMysql |= LogOn;
		if (c[1] && !stricmp("live", c[1]))
			mConfigData->Logging.LoginServer.DatabaseMysql |= LogLive;
		c.Parent();
	}
	else
	{
		c.Find("Logging");
		c.FindIn("LoginServer");
	}
	mConfigData->Logging.LoginServer.DatabaseSqlite = 0;
	if (c.FindIn("DatabaseSqlite.log"))
	{
		if (c[0] && !stricmp("on", c[0]))
			mConfigData->Logging.LoginServer.DatabaseSqlite |= LogOn;
		if (c[1] && !stricmp("live", c[1]))
			mConfigData->Logging.LoginServer.DatabaseSqlite |= LogLive;
		c.Parent();
	}
	else
	{
		c.Find("Logging");
		c.FindIn("LoginServer");
	}
	mConfigData->Logging.LoginServer.Debug = 0;
	if (c.FindIn("Debug.log"))
	{
		if (c[0] && !stricmp("on", c[0]))
			mConfigData->Logging.LoginServer.Debug |= LogOn;
		if (c[1] && !stricmp("live", c[1]))
			mConfigData->Logging.LoginServer.Debug |= LogLive;
		c.Parent();
	}
	else
	{
		c.Find("Logging");
		c.FindIn("LoginServer");
	}
	mConfigData->Logging.LoginServer.Network = 0;
	if (c.FindIn("Network.log"))
	{
		if (c[0] && !stricmp("on", c[0]))
			mConfigData->Logging.LoginServer.Network |= LogOn;
		if (c[1] && !stricmp("live", c[1]))
			mConfigData->Logging.LoginServer.Network |= LogLive;
		c.Parent();
	}
	else
	{
		c.Find("Logging");
		c.FindIn("LoginServer");
	}
	mConfigData->Logging.LoginServer.Networkbin = 0;
	if (c.FindIn("Network.bin"))
	{
		if (c[0] && !stricmp("on", c[0]))
			mConfigData->Logging.LoginServer.Networkbin |= LogOn;
		if (c[1] && !stricmp("live", c[1]))
			mConfigData->Logging.LoginServer.Networkbin |= LogLive;
		c.Parent();
	}
	else
	{
		c.Find("Logging");
		c.FindIn("LoginServer");
	}
	c.Parent();
	if (!c.FindIn("RedirectServer"))
	{
		strncpy(error, "no RedirectServer section in Logging section", errorlen);
		return 0;
	}
	mConfigData->Logging.RedirectServer.Debug = 0;
	if (c.FindIn("Debug.log"))
	{
		if (c[0] && !stricmp("on", c[0]))
			mConfigData->Logging.RedirectServer.Debug |= LogOn;
		if (c[1] && !stricmp("live", c[1]))
			mConfigData->Logging.RedirectServer.Debug |= LogLive;
		c.Parent();
	}
	else
	{
		c.Find("Logging");
		c.FindIn("RedirectServer");
	}
	mConfigData->Logging.RedirectServer.Network = 0;
	if (c.FindIn("Network.log"))
	{
		if (c[0] && !stricmp("on", c[0]))
			mConfigData->Logging.RedirectServer.Network |= LogOn;
		if (c[1] && !stricmp("live", c[1]))
			mConfigData->Logging.RedirectServer.Network |= LogLive;
		c.Parent();
	}
	else
	{
		c.Find("Logging");
		c.FindIn("RedirectServer");
	}
	mConfigData->Logging.RedirectServer.Networkbin = 0;
	if (c.FindIn("Network.bin"))
	{
		if (c[0] && !stricmp("on", c[0]))
			mConfigData->Logging.RedirectServer.Networkbin |= LogOn;
		if (c[1] && !stricmp("live", c[1]))
			mConfigData->Logging.RedirectServer.Networkbin |= LogLive;
		c.Parent();
	}
	else
	{
		c.Find("Logging");
		c.FindIn("RedirectServer");
	}
	c.Parent();
	if (!c.FindIn("WorldServer"))
	{
		strncpy(error, "no WorldServer section in Logging section", errorlen);
		return 0;
	}
	mConfigData->Logging.WorldServer.Chat = 0;
	if (c.FindIn("Chat.log"))
	{
		if (c[0] && !stricmp("on", c[0]))
			mConfigData->Logging.WorldServer.Chat |= LogOn;
		if (c[1] && !stricmp("live", c[1]))
			mConfigData->Logging.WorldServer.Chat |= LogLive;
		c.Parent();
	}
	else
	{
		c.Find("Logging");
		c.FindIn("WorldServer");
	}
	mConfigData->Logging.WorldServer.DatabaseMysql = 0;
	if (c.FindIn("DatabaseMysql.log"))
	{
		if (c[0] && !stricmp("on", c[0]))
			mConfigData->Logging.WorldServer.DatabaseMysql |= LogOn;
		if (c[1] && !stricmp("live", c[1]))
			mConfigData->Logging.WorldServer.DatabaseMysql |= LogLive;
		c.Parent();
	}
	else
	{
		c.Find("Logging");
		c.FindIn("WorldServer");
	}
	mConfigData->Logging.WorldServer.DatabaseSqlite = 0;
	if (c.FindIn("DatabaseSqlite.log"))
	{
		if (c[0] && !stricmp("on", c[0]))
			mConfigData->Logging.WorldServer.DatabaseSqlite |= LogOn;
		if (c[1] && !stricmp("live", c[1]))
			mConfigData->Logging.WorldServer.DatabaseSqlite |= LogLive;
		c.Parent();
	}
	else
	{
		c.Find("Logging");
		c.FindIn("WorldServer");
	}
	mConfigData->Logging.WorldServer.Debug = 0;
	if (c.FindIn("Debug.log"))
	{
		if (c[0] && !stricmp("on", c[0]))
			mConfigData->Logging.WorldServer.Debug |= LogOn;
		if (c[1] && !stricmp("live", c[1]))
			mConfigData->Logging.WorldServer.Debug |= LogLive;
		c.Parent();
	}
	else
	{
		c.Find("Logging");
		c.FindIn("WorldServer");
	}
	mConfigData->Logging.WorldServer.GMActions = 0;
	if (c.FindIn("GMActions.log"))
	{
		if (c[0] && !stricmp("on", c[0]))
			mConfigData->Logging.WorldServer.GMActions |= LogOn;
		if (c[1] && !stricmp("live", c[1]))
			mConfigData->Logging.WorldServer.GMActions |= LogLive;
		c.Parent();
	}
	else
	{
		c.Find("Logging");
		c.FindIn("WorldServer");
	}
	mConfigData->Logging.WorldServer.Network = 0;
	if (c.FindIn("Network.log"))
	{
		if (c[0] && !stricmp("on", c[0]))
			mConfigData->Logging.WorldServer.Network |= LogOn;
		if (c[1] && !stricmp("live", c[1]))
			mConfigData->Logging.WorldServer.Network |= LogLive;
		c.Parent();
	}
	else
	{
		c.Find("Logging");
		c.FindIn("WorldServer");
	}
	mConfigData->Logging.WorldServer.Networkbin = 0;
	if (c.FindIn("Network.bin"))
	{
		if (c[0] && !stricmp("on", c[0]))
			mConfigData->Logging.WorldServer.Networkbin |= LogOn;
		if (c[1] && !stricmp("live", c[1]))
			mConfigData->Logging.WorldServer.Networkbin |= LogLive;
		c.Parent();
	}
	else
	{
		c.Find("Logging");
		c.FindIn("WorldServer");
	}
	mConfigData->Logging.WorldServer.UnknownPackets = 0;
	if (c.FindIn("UnknownPackets.log"))
	{
		if (c[0] && !stricmp("on", c[0]))
			mConfigData->Logging.WorldServer.UnknownPackets |= LogOn;
		if (c[1] && !stricmp("live", c[1]))
			mConfigData->Logging.WorldServer.UnknownPackets |= LogLive;
		c.Parent();
	}
	else
	{
		c.Find("Logging");
		c.FindIn("WorldServer");
	}
	c.Reset();
	if (!c.Find("UseDatabase") || !c[0])
	{
		strncpy(error, "UseDatabase unspecified", errorlen);
		return 0;
	}
	usedb = (char *)c[0];
	c.Reset();
	/*
	while (1)
	{
		if (!c.Find("Database"))
		{
			strncpy(error, "matching Database section not found", errorlen);
			return 0;
		}
		if (!c[0] || stricmp(usedb, c[0]))
			continue;
		break;
	}
	if (!c.FindIn("DatabaseModule") || !c[0])
	{
		strncpy(error, "DatabaseModule unspecified in Database section", errorlen);
		return 0;
	}
	if (!stricmp("mysql", c[0]))
		mConfigData->Database.DatabaseModule = DbMysql;
	else if (!stricmp("sqlite", c[0]))
		mConfigData->Database.DatabaseModule = DbSqlite;
	else
	{
		strncpy(error, "DatabaseModule unrecognized in Database section", errorlen);
		return 0;
	}
	c.Parent();
	if (!c.FindIn("InfoString") || !c[0])
	{
		strncpy(error, "InfoString unspecified in Database section", errorlen);
		return 0;
	}
	mConfigData->Database.InfoString = c[0];
	c.Parent();
	if (!c.FindIn("TablePrefix"))
	{
		strncpy(error, "TablePrefix unspecified in Database section", errorlen);
		return 0;
	}
	if (c[0])
		mConfigData->Database.TablePrefix = c[0];
	else
		mConfigData->Database.TablePrefix = "";
	c.Reset(); */
	return 1;
}




