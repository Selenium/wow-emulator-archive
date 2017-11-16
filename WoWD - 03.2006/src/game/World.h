// Copyright (C) 2004 WoW Daemon
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.

//
// World.h
//

#ifndef __WORLD_H
#define __WORLD_H

#include "Timer.h"
#include "AreaTrigger.h"

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

enum Rates
{
    RATE_HEALTH=0,
    RATE_POWER1,	
    RATE_POWER2,	
    RATE_POWER3,	
    RATE_DROP,
    RATE_XP,
	MAX_RATES
};    	


enum EnviromentalDamage
{
	DAMAGE_EXHAUSTED = 0,
	DAMAGE_DROWNING = 1,
	DAMAGE_FALL = 2,
	DAMAGE_LAVA = 3,
	DAMAGE_SLIME = 4,
	DAMAGE_FIRE = 5
};

enum CharCreateErrors
{
	SUCCESS,
	FAILURE,
	CANCELLED,
	DISCONNECT_FROM_SERVER,
	FAILED_TO_CONNECT,
	CONNECTED,
	WRONG_CLIENT_VERSION,
	CONNECTING_TO_SERVER,
	NEGOTIATING_SECURITY,
	NEGOTIATING_SECURITY_COMPLETE,
	NEGOTIATING_SECURITY_COMPLETE_2,
	AUTHENTICATING,
	AUTHENTICATION_SUCCESSFUL,
	AUTHENTICATION_FAILED,
	LOGIN_UNAVAIBLE,
	SERVER_IS_NOT_VALID,
	SYSTEM_UNAVAIBLE,
	SYSTEM_ERROR,
	BILLING_SYSTEM_ERROR,
	ACCOUNT_BILLING_EXPIRED,
	WRONG_CLIENT_VERSION_2,
	UNKNOWN_ACCOUNT,
	INCORRECT_PASSWORD,
	SESSION_EXPIRED,
	SERVER_SHUTTING_DOWN,
	ALREADY_LOGGED_IN,
	INVALID_LOGIN_SERVER,
	POSITION_IN_QUEUE_0,
	THIS_ACCOUNT_HAS_BEEN_BANNED,
	THIS_CHARACTER_STILL_LOGGED_ON,
	YOUR_WOW_SUBSCRIPTION_IS_EXPIRED,
	THIS_SESSION_HAS_TIMED_OUT,
	THIS_ACCOUNT_TEMP_SUSPENDED,
	ACCOUNT_BLOCKED_BY_PARENTAL_CONTROL,
	RETRIEVING_REALMLIST,
	REALMLIST_RETRIEVED,
	UNABLE_TO_CONNECT_REALMLIST_SERVER,
	INVALID_REALMLIST,
	GAME_SERVER_DOWN,
	CREATING_ACCOUNT,
	ACCOUNT_CREATED,
	ACCOUNT_CREATION_FAIL,
	RETRIEVE_CHAR_LIST,
	CHARLIST_RETRIEVED,
	CHARLIST_ERROR,
	CREATING_CHARACTER,
	CHARACTER_CREATED,
	ERROR_CREATING_CHARACTER,
	CHARACTER_CREATION_FAIL,
	NAME_IS_IN_USE,
	CREATION_OF_RACE_DISABLED,
	ALL_CHARS_ON_PVP_REALM_MUST_AT_SAME_SIDE,
	DELETING_CHARACTER,
	CHARACTER_DELETED,
	CHARACTER_DELETION_FAILED,
	ENTERING_WOW,
	LOGIN_SUCCESFUL,
	WORLD_SERVER_DOWN,
	A_CHARACTER_WITH_THAT_NAME_EXISTS,
	NO_INSTANCE_SERVER_AVAIBLE,
	LOGIN_FAILED,
	LOGIN_FOR_THAT_RACE_DISABLED,
	LOGIN_FOR_THAT_RACE_CLASS_DISABLED,
	ENTER_NAME_FOR_CHARACTER,
	NAME_AT_LEAST_TWO_CHARACTER,
	NAME_AT_MOST_12_CHARACTER,
	NAME_CAN_CONTAIN_ONLY_CHAR,
	NAME_CONTAIN_ONLY_ONE_LANG,
	NAME_CONTAIN_PROFANTY,
	NAME_IS_RESERVED,
	YOU_CANNOT_USE_APHOS,
	YOU_CAN_ONLY_HAVE_ONE_APHOS,
	YOU_CANNOT_USE_SAME_LETTER_3_TIMES,
	INVALID_CHARACTER_NAME,
	BLANK
	//All further codes give the number in dec.
};

class World : public Singleton<World>
{
public:
    World();
    ~World();

    WorldSession* FindSession(uint32 id) const;
    void AddSession(WorldSession *s);
	void RemoveSession(uint32 id);

    uint32 GetSessionCount() const { return m_sessions.size(); }
    uint32 GetPlayerLimit() const { return m_playerLimit; }
    void SetPlayerLimit(uint32 limit) { m_playerLimit = limit; }

	bool getAllowMovement() const { return m_allowMovement; }
    void SetAllowMovement(bool allow) { m_allowMovement = allow; }
    bool getGMTicketStatus() { return m_gmTicketSystem; };
    bool toggleGMTicketStatus()
    {
        m_gmTicketSystem = !m_gmTicketSystem;
        return m_gmTicketSystem;
    };

    bool getReqGmClient() { return reqGmClient; }
    std::string getGmClientChannel() { return GmClientChannel; }

    void SetMotd(const char *motd) { m_motd = motd; }
    const char* GetMotd() const { return m_motd.c_str(); }

    time_t GetGameTime() const { return m_gameTime; }

    void SetInitialWorldSettings();

    void SendWorldText(const char *text, WorldSession *self = 0);
    void SendGlobalMessage(WorldPacket *packet, WorldSession *self = 0);

    // update the world server every frame
    void Update(time_t diff);

	void UpdateAuctions();
    void UpdateSessions(uint32 diff);

    //Global objects(not in any map)
    void AddGlobalObject(Object *obj); 
    void RemoveGlobalObject(Object *obj);
    bool HasGlobalObject(Object *obj) { return !(m_globalObjects.find(obj) == m_globalObjects.end()); }

    void setRate(int index,float value)
    {
        if((index>=0)&&(index<MAX_RATES))
        regen_values[index]=value;
    }

    float getRate(int index)
    {
        if((index>=0)&&(index<MAX_RATES))
        return regen_values[index];
        return 1;
    }
      
  
	// map text emote to spell prices
    typedef std::map< uint32, uint32> SpellPricesMap;
    SpellPricesMap mPrices;

	// area trigger
	void LoadAreaTriggerInformation();
	void AddAreaTrigger(AreaTrigger *pArea);
	AreaTrigger *GetAreaTrigger(uint32 id);

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

	typedef HM_NAMESPACE::hash_map<uint32, AreaTrigger*> AreaTriggerMap;
	AreaTriggerMap m_AreaTrigger;

    //Global objects(not in any map)
    typedef std::set<Object*> ObjectSet;
    ObjectSet m_globalObjects;

    float regen_values[5];
    uint32 m_playerLimit;
	bool m_allowMovement;
    bool m_gmTicketSystem;
    std::string m_motd;

    bool reqGmClient;
    std::string GmClientChannel;

    time_t m_gameTime;
    time_t m_lastTick;

};

#define sWorld World::getSingleton()

#endif
