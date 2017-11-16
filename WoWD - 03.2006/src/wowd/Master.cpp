#include "Master.h"
#include "Network/SocketHandler.h"
#include "Network/ListenSocket.h"
#include "Network/TcpSocket.h"
#include "WorldSocket.h"
#include "WorldSocketMgr.h"
#include "WorldRunnable.h"
#include "World.h"
#include "Log.h"
#include "Timer.h"
#include "ObjectMgr.h"
#include "ConsoleCommands/ConsoleCmds.h"
#include "../script/Engine.h"

#include <signal.h>

createFileSingleton(Master);

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
    sLog.outString("WoWd World Server %s", _FULLVERSION);
    sLog.outString("<Ctrl-C> to stop.\n");

    //setting up configuration
    if (!Config::getSingleton().SetSource("wowd.conf"))
    {
        sLog.outError("\nCould not find wowd.conf configuration.");
    }

    _StartDB();

    loglevel = (uint8)sConfig.GetIntDefault("LogLevel", DEFAULT_LOG_LEVEL);

    std::string host;
    host = sConfig.GetStringDefault("Host", DEFAULT_HOST);
    sLog.outString("Server: %s\n", host.c_str());

    new World;
	new LuaManager;
	sLuaManager.getInnerEngine()->runFile("scripts/startup.lua");

    sWorld.SetPlayerLimit(sConfig.GetIntDefault("PlayerLimit", DEFAULT_PLAYER_LIMIT));
    sWorld.SetMotd(sConfig.GetStringDefault("Motd", "WoW Daemon Default MOTD").c_str());
    sWorld.SetInitialWorldSettings();

    std::stringstream ss;
    port_t wsport, rmport;
    rmport = sConfig.GetIntDefault("RealmServerPort", DEFAULT_REALMSERVER_PORT);
    wsport = sConfig.GetIntDefault("WorldServerPort", DEFAULT_WORLDSERVER_PORT);
    
    // load regeneration rates.
    sWorld.setRate(RATE_HEALTH,sConfig.GetFloatDefault("Rate.Health",DEFAULT_REGEN_RATE));
    sWorld.setRate(RATE_POWER1,sConfig.GetFloatDefault("Rate.Power1",DEFAULT_REGEN_RATE));
    sWorld.setRate(RATE_POWER2,sConfig.GetFloatDefault("Rate.Power2",DEFAULT_REGEN_RATE));
    sWorld.setRate(RATE_POWER3,sConfig.GetFloatDefault("Rate.Power4",DEFAULT_REGEN_RATE));
    sWorld.setRate(RATE_DROP,sConfig.GetFloatDefault("Rate.Drop",DEFAULT_DROP_RATE));
    sWorld.setRate(RATE_XP,sConfig.GetFloatDefault("Rate.XP",DEFAULT_XP_RATE));

    ss << host << ":" << wsport;

    SocketHandler h;
    ListenSocket<WorldSocket> worldListenSocket(h);

    if (worldListenSocket.Bind(wsport))
    {
        delete World::getSingletonPtr();
        _StopDB();

        return 0;
    }

    h.Add(&worldListenSocket);

    _HookSignals();

    ZThread::Thread t(new WorldRunnable);
    
    uint32 realCurrTime, realPrevTime;
    realCurrTime = realPrevTime = getMSTime();
    
    Log::getSingleton( ).outString ("WoWd World Server Started.");
    CConsoleCmds ConsoleCmds;

    while (!Master::m_stopEvent)
    {
        // uint32 exceeded
        if (realPrevTime > realCurrTime)
		{
            realPrevTime = 0;
		}

        realCurrTime = getMSTime();
        sWorldSocketMgr.Update(realCurrTime - realPrevTime);
        realPrevTime = realCurrTime;

        h.Select(0, 10000); // 100 ms
        ConsoleCmds.Do();
    }

    _UnhookSignals();

    t.wait();

    sLog.outString("Stopping Database...");
    _StopDB();
    sLog.outString("Stopped Database");
    
    sLog.outString("Deleting World...");
    delete World::getSingletonPtr();
    sLog.outString("Deleted World");

    sLog.outString("Halting process...");
    return 0;
}

bool Master::_StartDB()
{
    ASSERT(new DatabaseMysql);

    std::string dbstring;

    if (!sConfig.GetString("DatabaseInfo", &dbstring))
    {
        sLog.outError("Database not specified");

        return false;
    }

    sLog.outString("Database: %s", dbstring.c_str() );

    if (!sDatabase.Initialize(dbstring.c_str()))
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