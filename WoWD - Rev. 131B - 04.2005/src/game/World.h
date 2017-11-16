//
// World.h
//

#ifndef __WORLD_H
#define __WORLD_H

#include "Timer.h"

class Object;
class WorldPacket;
class WorldSession;
class MapMgr;

enum WorldTimers
{
    WUPDATE_OBJECTS = 0,
    WUPDATE_SESSIONS = 1,
	WUPDATE_AUCTIONS = 2,
    WUPDATE_COUNT = 3
};

class World : public Singleton<World>
{
public:
    World();
    ~World();

    WorldSession* FindSession(uint32 id) const;
    void AddSession(WorldSession *s);

    uint32 GetSessionCount() const { return m_sessions.size(); }
    uint32 GetPlayerLimit() const { return m_playerLimit; }
    void SetPlayerLimit(uint32 limit) { m_playerLimit = limit; }

    void SetMotd(const char *motd) { m_motd = motd; }
    const char* GetMotd() const { return m_motd.c_str(); }

    time_t GetGameTime() const { return m_gameTime; }

    void SetInitialWorldSettings();

    void SendWorldText(const char *text, WorldSession *self = 0);
    void SendGlobalMessage(WorldPacket *packet, WorldSession *self = 0);

    // update the world server every frame
    void Update(time_t diff);

    // get map manager
    MapMgr* GetMap(uint32 id);



	// map text emote to spell prices
    typedef std::map< uint32, uint32> SpellPricesMap;
    SpellPricesMap mPrices;

protected:
    // update Stuff, FIXME: use diff
    time_t _UpdateGameTime()
    {
        // Update Server time
        time_t thisTime = time(NULL);
        m_gameTime += thisTime - m_lastTick;
        m_lastTick = thisTime;

        return m_gameTime;
    }

private:
    //! Timers
    IntervalTimer m_timers[WUPDATE_COUNT];

    typedef HM_NAMESPACE::hash_map<uint32, WorldSession*> SessionMap;
    SessionMap m_sessions;

    typedef HM_NAMESPACE::hash_map<uint32, MapMgr*> MapMgrMap;
    MapMgrMap m_maps;

    uint32 m_playerLimit;
    std::string m_motd;

    time_t m_gameTime;
    time_t m_lastTick;
};

#define sWorld World::getSingleton()

#endif
