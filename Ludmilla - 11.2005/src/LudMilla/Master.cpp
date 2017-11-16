#include "StdAfx.h"

#include "../LogonServer/LogonSocket.h"
#include "../LogonServer/LogonSocketMgr.h"
#include "../LogonServer/RealmList.h"

#include "../Game/Server/WS/WorldSocket.h"
#include "../Game/Server/WS/WorldSocketMgr.h"


createFileSingleton( Master );

volatile bool Master::m_stopEvent = false;

//-----------------------------------------------------------------------------
void Master::_OnSignal(int s)
{
    switch (s)
    {
    case SIGINT:
        Master::m_stopEvent = true;
        break;
    case SIGTERM:
        Master::m_stopEvent = true;
        break;
    case SIGABRT:
        Master::m_stopEvent = true;
        break;
#ifdef _WIN32
    case SIGBREAK:
        Master::m_stopEvent = true;
        break;
#endif
    }

    signal(s, _OnSignal);
}

//-----------------------------------------------------------------------------
Master::Master()
{
}

//-----------------------------------------------------------------------------
Master::~Master()
{
}

//bool g_restartScripting = false;
//extern void RestartScripting();

//-----------------------------------------------------------------------------
bool Master::Run()
{
    sLog.outString( "Greetings, commander! This is %s", FULLSERVERNAME);
    sLog.outString( "Press Ctrl-C anytime to safely close server.\n" );

    //setting up configuration
    if (!Config::getSingleton().SetSource("ludmilla.conf"))
    {
        sLog.outError("\nCould not find ludmilla.conf configuration (case sensitive on Linux).");
    }

	sLog.outString( "Loading patches..." );
	LogonSocket::Patcher.LoadPatcheIDs();

	//InitScripting();
	_StartDB();

    loglevel = (uint8)sConfig.GetIntDefault("LogLevel", DEFAULT_LOG_LEVEL);

    new World;

	//InitSpellsTable();
    sWorld.SetPlayerLimit( sConfig.GetIntDefault("PlayerLimit", DEFAULT_PLAYER_LIMIT) );
    sWorld.SetMotd( sConfig.GetStringDefault("Motd", "WoW Default MOTD" ).c_str() );
	
	sWorld.SetInitialWorldSettings();

// Network:

	// Settings for LogonServer and WorldServer:
	std::string host;
	host = sConfig.GetStringDefault( "Host", DEFAULT_HOST );
	sLog.outString( "Server Listen at: %s\n", host.c_str() );

	port_t lsport = sConfig.GetIntDefault( "LogonServerPort", DEFAULT_LOGONSERVER_PORT );
	port_t wsport = sConfig.GetIntDefault( "WorldServerPort", DEFAULT_WORLDSERVER_PORT );

	// Settings for Realm:
	std::string rmname = sConfig.GetStringDefault( "RealmName", "WDDG LudMilla" );
	std::string rmhost = sConfig.GetStringDefault( "RealmAddr", host.c_str() );
	port_t rmport = sConfig.GetIntDefault( "RealmPort", wsport );

	// Creating Realm:
	std::stringstream ss;
	ss << rmhost << ":" << rmport;

    // Format: Realm_Name, Realm_IP:Port, Icon (0 = Normal, 1 = PVP), Color (0 = Yellow, 1 = Red), TimeZone (1 - 4)
	sRealmList.AddRealm ( rmname.c_str(), ss.str().c_str(), 0, 0, 1);

	// Begin of listening:
    SocketHandler h;
    ListenSocket<WorldSocket> worldListenSocket(h);
    ListenSocket<LogonSocket> logonListenSocket(h);

    if (worldListenSocket.Bind(host, wsport) || logonListenSocket.Bind(host, lsport))
    {
        delete World::getSingletonPtr();
        _StopDB();

        return 0;
    }

    h.Add(&worldListenSocket);
    h.Add(&logonListenSocket);

	Log::getSingleton( ).outString ("Logon Server started on port %d", lsport);
	Log::getSingleton( ).outString ("World Server started on port %d", wsport);

// World:

    _HookSignals();

    ZThread::Thread t(new WorldRunnable);

	// todo: wait for World thread

    uint32 realCurrTime, realPrevTime;
    realCurrTime = realPrevTime = getMSTime();

	Log::getSingleton( ).outString ("<<<-- Server Ready! -->>>");

	CConsoleCmds ConsoleCmds;
	
	while (!Master::m_stopEvent)
    {
        // uint32 exceeded
        if (realPrevTime > realCurrTime)
            realPrevTime = 0;

        realCurrTime = getMSTime();
        sWorldSocketMgr.Update( realCurrTime - realPrevTime );
		sLogonSocketMgr.Update( realCurrTime - realPrevTime );
        realPrevTime = realCurrTime;

        h.Select(0, 100000); // 100 ms

		ConsoleCmds.Do();

		/*if (g_restartScripting)
		{
			g_restartScripting = false;
			RestartScripting();
		}*/
    }

    _UnhookSignals();

    t.wait();
    delete World::getSingletonPtr();

    _StopDB();

    sLog.outString( "Halting process..." );
    return 0;
}

//-----------------------------------------------------------------------------
bool Master::_StartDB()
{
    ASSERT(new DatabaseMysql);

    std::string dbstring;

    if(!sConfig.GetString("DatabaseInfo", &dbstring))
    {
        sLog.outError("Database not specified");
        return false;
    }

    sLog.outString("Database: %s", dbstring.c_str() );

    if(!sDatabase.Initialize(dbstring.c_str()))
    {
        sLog.outError("Cannot connect to database");
        return false;
    }

    return true;
}

//-----------------------------------------------------------------------------
void Master::_StopDB()
{
    delete Database::getSingletonPtr();
}

//-----------------------------------------------------------------------------
void Master::_HookSignals()
{
    signal(SIGINT, _OnSignal);
    signal(SIGTERM, _OnSignal);
    signal(SIGABRT, _OnSignal);
#ifdef _WIN32
    signal(SIGBREAK, _OnSignal);
#endif
}

//-----------------------------------------------------------------------------
void Master::_UnhookSignals()
{
    signal(SIGINT, 0);
    signal(SIGTERM, 0);
    signal(SIGABRT, 0);
#ifdef _WIN32
    signal(SIGBREAK, 0);
#endif

}

//--- END ---