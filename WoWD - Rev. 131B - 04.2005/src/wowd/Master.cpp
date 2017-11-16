#include "Master.h"
#include "Network/SocketHandler.h"
#include "Network/ListenSocket.h"
#include "Network/TcpSocket.h"
#include "AuthSocket.h"
#include "WorldSocket.h"
#include "WorldSocketMgr.h"
#include "WorldRunnable.h"
#include "World.h"
#include "RealmList.h"
#include "Log.h"
#include "Timer.h"
#include <signal.h>

createFileSingleton( Master );

volatile bool Master::m_stopEvent = false;

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

Master::Master()
{
}

Master::~Master()
{
}

bool Master::Run()
{
    sLog.outString( "WoWd Server %s", _FULLVERSION );
    sLog.outString( "<Ctrl-C> to stop.\n" );

    //setting up configuration
    if (!Config::getSingleton().SetSource("WoWD.conf"))
    {
        sLog.outError("\nCould not find WoWD.conf configuration.");
    }

    _StartDB();

    loglevel = (uint8)sConfig.GetIntDefault("LogLevel", DEFAULT_LOG_LEVEL);

    std::string host;
    host = sConfig.GetStringDefault( "Host", DEFAULT_HOST );
    sLog.outString( "Server: %s\n", host.c_str() );

    new World;

    sWorld.SetPlayerLimit( sConfig.GetIntDefault("PlayerLimit", DEFAULT_PLAYER_LIMIT) );
    sWorld.SetMotd( sConfig.GetStringDefault("Motd", "WoW Daemon Default MOTD" ).c_str() );
    sWorld.SetInitialWorldSettings();

    std::stringstream ss;
    port_t wsport, rmport;
    rmport = sConfig.GetIntDefault( "RealmServerPort", DEFAULT_REALMSERVER_PORT );
    wsport = sConfig.GetIntDefault( "WorldServerPort", DEFAULT_WORLDSERVER_PORT );
    ss << host << ":" << wsport;

    // Format: Realm_Name, Realm_IP, Icon (0 = Normal, 1 = PVP), Color (0 = Yellow, 1 = Red), TimeZone (1 - 4)
    sRealmList.AddRealm( "**** WoW Daemon ****", ss.str().c_str(), 0, 0, 1 );
    sRealmList.AddRealm( "** WoW Daemon Local Dev **", "127.0.0.1:8129", 0, 0, 1 );

    SocketHandler h;
    ListenSocket<WorldSocket> worldListenSocket(h);
    ListenSocket<AuthSocket> authListenSocket(h);

    if (worldListenSocket.Bind4(wsport) || authListenSocket.Bind4(rmport))
    {
        delete World::getSingletonPtr();
        _StopDB();

        return 0;
    }

    h.Add(&worldListenSocket);
    h.Add(&authListenSocket);

    _HookSignals();

    ZThread::Thread t(new WorldRunnable);

    uint32 realCurrTime, realPrevTime;
    realCurrTime = realPrevTime = getMSTime();
    while (!Master::m_stopEvent)
    {
        // uint32 exceeded
        if (realPrevTime > realCurrTime)
            realPrevTime = 0;

        realCurrTime = getMSTime();
        sWorldSocketMgr.Update( realCurrTime - realPrevTime );
        realPrevTime = realCurrTime;

        h.Select(0, 100000); // 100 ms
    }

    _UnhookSignals();

    t.wait();
    delete World::getSingletonPtr();

    _StopDB();

    sLog.outString( "Halting process..." );
    return 0;
}

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

void Master::_StopDB()
{
    delete Database::getSingletonPtr();
}

void Master::_HookSignals()
{
    signal(SIGINT, _OnSignal);
    signal(SIGTERM, _OnSignal);
    signal(SIGABRT, _OnSignal);
#ifdef _WIN32
    signal(SIGBREAK, _OnSignal);
#endif
}

void Master::_UnhookSignals()
{
    signal(SIGINT, 0);
    signal(SIGTERM, 0);
    signal(SIGABRT, 0);
#ifdef _WIN32
    signal(SIGBREAK, 0);
#endif

}
