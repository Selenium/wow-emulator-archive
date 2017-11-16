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

#ifndef WOWSERVER_AIINTERFACE_H
#define WOWSERVER_AIINTERFACE_H

#include "Common.h"
#include "Unit.h"
#include "../script/ScriptCommon.h"

class LuaEngine;

#define M_PI       3.14159265358979323846
#define UNIT_MOVEMENT_INTERPOLATE_INTERVAL 1000 // ms
#define MAX_CREATURE_WAYPOINTS 16
#define TARGET_UPDATE_INTERVAL 200 // ms
#define oocr 100.0f // out of combat range

class Creature;
class Unit;
class Player;
class WorldSession;
class SpellCastTargets;


enum AIType
{
    AITYPE_LONER,
    AITYPE_AGRO,
    AITYPE_SOCIAL,
    AITYPE_PET
};

enum MovementType
{
    MOVEMENTTYPE_NONE,
    MOVEMENTTYPE_ROAM,
    MOVEMENTTYPE_SCRIPT
};


struct AI_Target
{
    Unit* target;
    uint32 threat;
};


enum AI_Agent
{
    AGENT_NULL,
    AGENT_MELEE,
    AGENT_RANGED,
    AGENT_FLEE,
    AGENT_SPELL,
    AGENT_CALLFORHELP
};

enum AI_SpellType
{
    STYPE_NULL,
    STYPE_ROOT,
    STYPE_HEAL,
    STYPE_STUN,
    STYPE_FEAR,
    STYPE_SILENCE,
    STYPE_CURSE,
    STYPE_AOEDAMAGE,
    STYPE_DAMAGE,
    STYPE_SUMMON,
    STYPE_BUFF,
    STYPE_DEBUFF
};

enum AI_SpellTargetType
{
    TTYPE_NULL,
    TTYPE_SINGLETARGET,
    TTYPE_DESTINATION,
    TTYPE_SOURCE
};

enum AI_State
{
    STATE_IDLE,
    STATE_ATTACKING,
    STATE_CASTING,
    STATE_FLEEING,
    STATE_FOLLOWING,
    STATE_EVADE,
    STATE_MOVEWP,
	STATE_FEAR,
	STATE_STOPPED
};

enum MovementState
{
    MOVEMENTSTATE_MOVE,
    MOVEMENTSTATE_FOLLOW,
    MOVEMENTSTATE_STOP,
    MOVEMENTSTATE_FOLLOW_OWNER
};

enum CreatureState
{
    STOPPED,
    MOVING,
    ATTACKING
};

enum AiEvents
{
    EVENT_ENTERCOMBAT,
    EVENT_LEAVECOMBAT,
    EVENT_DAMAGETAKEN,
    EVENT_TARGETCASTSPELL,
    EVENT_TARGETPARRYED,
    EVENT_TARGETDODGED,
    EVENT_TARGETBLOCKED,
    EVENT_TARGETCRITHIT,
    EVENT_TARGETDIED,
    EVENT_UNITPARRYED,
    EVENT_UNITDODGED,
    EVENT_UNITBLOCKED,
    EVENT_UNITCRITHIT,
    EVENT_UNITDIED,
    EVENT_ASSISTTARGETDIED,
    EVENT_FOLLOWOWNER,
    EVENT_FEAR
};

struct SpellEntry;
//enum MOD_TYPES;

struct AI_Spell
{
    uint32 entryId;
    uint16 agent;
    uint32 procEvent;
    uint32 procChance;
    uint32 procCount;
    uint32 spellId;
    uint8 spellType;
    uint8 spelltargetType;
    uint32 spellCooldown;
    float floatMisc1;
    uint32 Misc2;
    
    float minrange;
    float maxrange;
    uint32 procCounter;
    uint32 spellCooldownTimer;
};

struct Waypoint
{
    float x;
    float y;
    float z;
    uint32 time;
};

struct WayPoint
{
	uint32 id;
    float x;
    float y;
    float z;
	uint32 waittime; //ms
	uint32 flags;
	bool forwardemoteoneshot;
	uint32 forwardemoteid;
	bool backwardemoteoneshot;
	uint32 backwardemoteid;
	uint32 forwardskinid;
	uint32 backwardskinid;

};

class AIInterface
{
public:
    
    AIInterface();
    ~AIInterface() { };

    // Misc
    void Init(Unit *un, AIType at, MovementType mt, LuaEngine *engine = NULL);
    void Init(Unit *un, AIType at, MovementType mt, Unit *owner, LuaEngine *engine = NULL); // used for pets
    Unit *GetUnit() { return m_Unit; }
    Unit *GetPetOwner() { return m_PetOwner; }
    void SetUnitToFollow(Unit* un) { UnitToFollow = un; };
    void SetUnitToFear(Unit* un)  { UnitToFear = un; };
    void SetFollowDistance(float dist) { FollowDistance = dist; };
    void SendMoveToPacket(float toX, float toY, float toZ, float toO, uint32 time, uint32 MoveFlags);
    void SendMoveToSplinesPacket(std::list<Waypoint> wp, bool run);
	void SendStopPacket();
    void MoveTo(float x, float y, float z, float o);
    bool setInFront(Unit* target);
    Unit* getUnitToFollow() { return UnitToFollow; }
    void setCreatureState(CreatureState state){ m_creatureState = state; }
    uint8 getAIState() { return m_AIState; }
    uint32 getThreatByGUID(uint64 guid);
    bool modThreatByGUID(uint64 guid, int32 mod);
    bool checkFaction(Unit* objA, Unit* objB, uint8 type);
    std::list<Unit*> GetAssistTargets() { return m_assistTargets; };
    void addAssistTargets(Unit* Friends);
    void WipeHateList();
    void WipeTargetList();
    inline uint32 getAITargetsCount() { return m_aiTargets.size(); }

    // Spell
    void CastSpell(Unit* caster, SpellEntry *spellInfo, SpellCastTargets targets);
    SpellEntry *getSpellEntry(uint32 spellId);
    SpellCastTargets setSpellTargets(SpellEntry *spellInfo, Unit* target);
    AI_Spell *getSpellByEvent(uint32 event);
    void resetSpellCounter();
    void increaseProcCounter(uint32 event, AI_Spell *sp);
    void addSpellToList(AI_Spell *sp);

    // Event Handler
    void HandleEvent(uint32 event, Unit* pUnit, uint32 misc1);
    void OnDeath();
    void AttackReaction(Unit *pUnit, uint32 damage_dealt, uint32 state);

    // Update
    void Update(uint32 p_time);

     // Movement
    uint32 getCurrentWaypoint() { return m_currentWaypoint; }
    void changeWayPointID(uint32 oldwpid, uint32 newwpid);
	bool addWayPoint(WayPoint* wp);
	bool saveWayPoints(uint32 wpid);
    bool showWayPoints(uint32 wpid, Player* pPlayer, bool Backwards);
    bool hideWayPoints(uint32 wpid, Player* pPlayer);
	WayPoint* getWayPoint(uint32 wpid);
	void deleteWayPoint(uint32 wpid);
    inline bool hasWaypoints() { return m_nWaypoints > 0; }
    inline void setMoveRandomFlag(bool f) { m_moveRandom = f; }
    inline void setMoveRunFlag(bool f) { m_moveRun = f; }
    inline bool getMoveRandomFlag() { return m_moveRandom; }
    inline bool getMoveRunFlag() { return m_moveRun; }

    // Movement
    bool m_canMove;
    bool m_WayPointsShowing;
    bool m_WayPointsShowBackwards;
    uint32 m_currentWaypoint;
    bool m_moveBackward;
    bool m_moveRandom;
    bool m_moveRun;
    bool m_moveFly;
    CreatureState m_creatureState;
    uint32 m_nWaypoints;

    bool m_canFlee;
    bool m_canCallForHelp;
    bool m_canRangedAttack;

private:
    // Update
    void _UpdateTargets();
    void _UpdateMovement(uint32 p_time);
    void _UpdateCombat(uint32 p_time);
    void _UpdateTimer(uint32 p_time);
    void _UpdateCooldownTimers(uint32 p_time);
    bool m_updateAssist;
    bool m_updateTargets;
    uint32 m_updateAssistTimer;
    uint32 m_updateTargetsTimer;

    // Misc
    Unit* FindTarget();
    Unit* FindTargetForSpell(AI_Spell *sp);
    bool FindFriends(float dist);
    AI_Spell *m_nextSpell;
    Unit* m_nextTarget;
    uint32 m_fleeTimer;
    bool m_hasFleed;
    bool m_hasCalledForHelp;

    // Calculation
    float _CalcAggroRange(Unit* target);
    float* _CalcDestination(Unit* target, float dist);
    float _CalcCombatRange(Unit* target, bool ranged);
    float _CalcDistanceFromHome();


    // Spell lists
    bool m_hasOnEnterCombatSpells;
    bool m_hasOnLeaveCombatSpells;
    bool m_hasOnDamageTakenSpells;
    bool m_hasOnTargetCastSpellSpells;
    bool m_hasOnTargetParryedSpells;
    bool m_hasOnTargetDodgedSpells;
    bool m_hasOnTargetBlockedSpells;
    bool m_hasOnTargetCritHitSpells;
    bool m_hasOnTargetDiedSpells;
    bool m_hasOnUnitParryedSpells;
    bool m_hasOnUnitDodgedSpells;
    bool m_hasOnUnitBlockedSpells;
    bool m_hasOnUnitCritHitSpells;
    bool m_hasOnUnitDiedSpells;
    bool m_hasOnAssistTargetDiedSpells;
	bool m_hasOnFollowOwnerSpells;
    std::list<AI_Spell*> m_OnEnterCombatSpells;
    std::list<AI_Spell*> m_OnLeaveCombatSpells;
    std::list<AI_Spell*> m_OnDamageTakenSpells;
    std::list<AI_Spell*> m_OnTargetCastSpellSpells;
    std::list<AI_Spell*> m_OnTargetParryedSpells;
    std::list<AI_Spell*> m_OnTargetDodgedSpells;
    std::list<AI_Spell*> m_OnTargetBlockedSpells;
    std::list<AI_Spell*> m_OnTargetCritHitSpells;
    std::list<AI_Spell*> m_OnTargetDiedSpells;
    std::list<AI_Spell*> m_OnUnitParryedSpells;
    std::list<AI_Spell*> m_OnUnitDodgedSpells;
    std::list<AI_Spell*> m_OnUnitBlockedSpells;
    std::list<AI_Spell*> m_OnUnitCritHitSpells;
    std::list<AI_Spell*> m_OnUnitDiedSpells;
    std::list<AI_Spell*> m_OnAssistTargetDiedSpells;
	std::list<AI_Spell*> m_OnFollowOwnerSpells;
    // Spell Cooldown Lists
    bool m_hasCooldownOnEnterCombatSpells;
    bool m_hasCooldownOnLeaveCombatSpells;
    bool m_hasCooldownOnDamageTakenSpells;
    bool m_hasCooldownOnTargetCastSpellSpells;
    bool m_hasCooldownOnTargetParryedSpells;
    bool m_hasCooldownOnTargetDodgedSpells;
    bool m_hasCooldownOnTargetBlockedSpells;
    bool m_hasCooldownOnTargetCritHitSpells;
    bool m_hasCooldownOnTargetDiedSpells;
    bool m_hasCooldownOnUnitParryedSpells;
    bool m_hasCooldownOnUnitDodgedSpells;
    bool m_hasCooldownOnUnitBlockedSpells;
    bool m_hasCooldownOnUnitCritHitSpells;
    bool m_hasCooldownOnUnitDiedSpells;
    bool m_hasCooldownOnAssistTargetDiedSpells;
    bool m_hasCooldownOnFollowOwnerSpells;


    Unit *m_Unit;
    Unit *m_PetOwner;
    float FollowDistance;

    std::list<AI_Target> m_aiTargets;
    std::list<Unit*> m_assistTargets;
    AIType m_AIType;
    AI_State m_AIState;
    AI_Agent m_aiCurrentAgent;


    // Movement
    float m_moveSpeed;
    float m_destinationX;
    float m_destinationY;
    float m_destinationZ;
    typedef std::map<uint32, WayPoint*> WayPointMap;
    WayPointMap m_waypoints;
    Unit *UnitToFollow;
    Unit *UnitToFear;
    uint32 m_timeToMove;
    uint32 m_timeMoved;
    uint32 m_moveTimer;

    MovementType m_MovementType;
    MovementState m_MovementState;

    // Lua Engine
	LuaEngine *m_engine;
	void _SendLuaEvent(WOWD_SCRIPTEVENT event);
};
#endif
