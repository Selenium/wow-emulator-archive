#pragma once
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

#ifndef WOWSERVER_CREATURE_H
#define WOWSERVER_CREATURE_H

#include "Unit.h"
#include "UpdateMask.h"
#include "Opcodes.h"
#include "../Shared/Util.h"

class Quest;
class NPCQuestMenu;
class Player;
class WorldSession;

// Milliseconds how often creature rechecks its walking direction
// Differs for combat and passive roaming
#define UNIT_MOVEMENT_INTERPOLATE_AGGROED	500
#define UNIT_MOVEMENT_INTERPOLATE_PASSIVE	1000
#define UNIT_MOVEMENT_INTERPOLATE_INTERVAL (isInCombat() ? UNIT_MOVEMENT_INTERPOLATE_AGGROED : UNIT_MOVEMENT_INTERPOLATE_PASSIVE)

// Max allowed amount of waypoints. Technically not limited, but may be
// source of server stability problems for GM.
#define MAX_CREATURE_WAYPOINTS				200

//#define OPTIMAL_CREATURE_WAYPOINTS_RESERVE	8
//#define MAX_CREATURE_ITEMS 8

enum CreatureFamily
{
	CREATURE_FAMILY_WOLF           = 1,
	CREATURE_FAMILY_CAT            = 2,
	CREATURE_FAMILY_SPIDER         = 3,
	CREATURE_FAMILY_BEAR           = 4,
	CREATURE_FAMILY_BOAR           = 5,
	CREATURE_FAMILY_CROCILISK      = 6,
	CREATURE_FAMILY_CARRION_BIRD   = 7,
	CREATURE_FAMILY_CRAB           = 8,
	CREATURE_FAMILY_GORILLA        = 9,
	CREATURE_FAMILY_RAPTOR         = 11,
	CREATURE_FAMILY_TALLSTRIDER    = 12,
	CREATURE_FAMILY_FELHUNTER      = 15,
	CREATURE_FAMILY_VOIDWALKER     = 16,
	CREATURE_FAMILY_SUCCUBUS       = 17,
	CREATURE_FAMILY_DOOMGUARD      = 19,
	CREATURE_FAMILY_SCORPID        = 20,
	CREATURE_FAMILY_TURTLE         = 21,
	CREATURE_FAMILY_IMP            = 23,
	CREATURE_FAMILY_BAT            = 24,
	CREATURE_FAMILY_HYENA          = 25,
	CREATURE_FAMILY_OWL            = 26,
	CREATURE_FAMILY_WIND_SERPENT   = 27
};

enum CreatureType
{
	CREATURE_TYPE_BEAST            = 1,
	CREATURE_TYPE_DRAGONKIN        = 2,
	CREATURE_TYPE_DEMON            = 3,
	CREATURE_TYPE_ELEMENTAL        = 4,
	CREATURE_TYPE_GIANT            = 5,
	CREATURE_TYPE_UNDEAD           = 6,
	CREATURE_TYPE_HUMANOID         = 7,
	CREATURE_TYPE_CRITTER          = 8,
	CREATURE_TYPE_MECHANICAL       = 9,
	CREATURE_TYPE_UNKNOWN          = 10
};

// we do not need complicated inventory here (probably)
struct CreatureItem
{
    uint32 itemid;
    int amount;
};

typedef vector<CreatureItem> CreatureItemVector;

//-----------------------------------------------------------------------------
// This is loaded from 'creatures_templ' at start and used to spawn
// creatures and send info about them
//-----------------------------------------------------------------------------
struct CreatureTemplate
{
	uint32	Entry;
	string	Name;
	string	Guild;
	uint32	Attack[2];
	uint32	Level[2];
	float	BoundingRadius;
	float	CombatReach;
	uint32	Damage[2];
	uint32	Faction;
	uint32	Flags1;
	uint32	MaxHealth;
	uint32	MaxMana;
	uint32	NPCFlags;
	float	Speed;
	float	Size;
	uint32	Type;
	uint32	Family;
	uint32	Elite;
	uint32	Model;
	uint32	MountModel;
	uint32  EquipModel[3];
	uint32  EquipSlot[3];
	uint32  EquipData[3];
};

enum UNIT_TYPE
{
    NOUNITTYPE = 0,
    BEAST      = 1,
    DRAGONSKIN = 2,
    DEMON      = 3,
    ELEMENTAL  = 4,
    GIANT      = 5,
    UNDEAD     = 6,
    HUMANOID   = 7,
    CRITTER    = 8,
    MECHANICAL = 9,
};

typedef enum
{
	FLEE_STATE_NONE,
	FLEE_STATE_FLEE,
	FLEE_STATE_CALL_HELP,
	FLEE_STATE_STRIKE_BACK
} FleeState;

#include <vector>

//-----------------------------------------------------------------------------
// Waypoint support data types
//-----------------------------------------------------------------------------
typedef struct {
	uint32	recordId;
	float	x, y, z;
	uint8	Wait1, Wait2;	// How long NPC may stand at this node (seconds)
} Waypoint;

typedef vector<Waypoint> WaypointVector;
typedef hash_map<uint32, WaypointVector *> WaypointVectorMap;	// key -> NPC_guid

//-----------------------------------------------------------------------------
// Loot templates support data types
//-----------------------------------------------------------------------------
typedef struct {
	uint32	ItemId;
	float	Chance;
} LootTemplate;

typedef vector<LootTemplate> LootTemplateVector;
typedef hash_map<uint32, LootTemplateVector *> LootTemplateVectorMap;	// key -> creature_id

// World Loots
typedef struct {
	uint32	monster_level;	
	uint32	elite;
	uint32  item_id;
	float	chance;
} WorldLootTemplate;

typedef vector<WorldLootTemplate> WorldLootTemplateVector;
typedef hash_map<uint32, WorldLootTemplateVector *> WorldLootTemplateVectorMap; // key -> item_id


//-----------------------------------------------------------------------------
// Sell templates support data types
//-----------------------------------------------------------------------------
typedef vector<uint32> SellTemplate;
typedef hash_map<uint32, SellTemplate *> SellTemplateMap; // key -> creature_id

//////////////////////////////////////////////////////////////////////////
// 	Creature object
//
//	This object is very similar to its base by functionality, though it
//  represents objects with abilities not available for players, like CPU
//	driven intelligence.
//-------------------------------------------------------------------------
class Creature : public Unit
{
public:
	friend class ChatHandler;

    Creature();
    virtual ~Creature();

	//-------------------------------------------------
    //  Creation
	//-------------------------------------------------
    void Create (uint32 guidlow, const char* creature_name, uint32 mapid,
        float x, float y, float z, float ang);

	//-------------------------------------------------
    //  Updates
	//-------------------------------------------------
    virtual void UpdateMobMovement (int32 p_time);
    virtual void Update (int32 time);

protected:	
	CreatureTemplate *m_creatureTemplate;
public:
	CreatureTemplate * GetCreatureTemplate() { return m_creatureTemplate; }

	uint32 GetNpcType() { return m_creatureTemplate != NULL ? m_creatureTemplate->Type : 0; }
	uint32 GetElite() { return m_creatureTemplate != NULL ? m_creatureTemplate->Elite : 0; }

protected:
	int32		m_lookForHelpTimer;	// how often mob in combat check place around for family
	FleeState	m_flee;				// True is NPC ignores attackers and runs to target
	int			m_fleeHelpRadius;	// How far related creatures will hear call for help
public:
	// Stops from attacking and runs away looking for help. If someone able
	// to help is found, them must produce emote begging for help and
	// attack with joined forces
	void Flee (Unit *from, int seconds, int helpRadius);

	bool isFleeing() { return m_flee > FLEE_STATE_NONE; }
	bool RelatedByFirstName (Creature *cr);

	// Scan cell(s?) around for family to share hate with
	bool SearchForHelpfulFamily (float senseRadius);

	//-------------------------------------------------
    //  Movement
	//-------------------------------------------------
    bool addWaypoint(float x, float y, float z, uint8 wait1=2, uint8 wait2=5);
	bool insertWaypoint (float x, float y, float z, int pos, uint8 wait1=2, uint8 wait2=5);

    inline bool hasWaypoints() { return !m_waypoints.empty(); }
    //inline void setMoveRandomFlag(bool f) { m_moveRandom = f; }
    inline void setMoveRunFlag(bool f) { m_moveRun = f; }
    //inline bool getMoveRandomFlag() { return m_moveRandom; }
    inline bool getMoveRunFlag() { return m_moveRun; }
	
	void LookAt (Unit *target);

	//-------------------------------------------------
    //  Creature inventory
	//-------------------------------------------------
    void setItemId(int slot, uint32 tempitemid) { item_list[slot].itemid = tempitemid; }
    void setItemAmount(int slot, int tempamount) { item_list[slot].amount = tempamount; }

	void setItemAmountById(uint32 tempitemid, int tempamount)
    {
        uint32 i;
        for(i=0; i < item_list.size(); i++)
        {
            if(item_list[i].itemid == tempitemid)
                item_list[i].amount = tempamount;
        }
    }
    
	//void increaseItemCount() { itemcount++; }
    
	void addItem (uint32 itemid, uint32 amount)
    {
		CreatureItem	item;
		item.amount = amount;
        item.itemid = itemid;
		item_list.push_back (item);
    }

    int getItemCount() { return item_list.size(); }
    int getItemAmount (int slot) { return item_list[slot].amount; }
    uint32 getItemId (int slot) { return item_list[slot].itemid; }

	//-------------------------------------------------
    //  Quests
	//-------------------------------------------------
    uint32 getDialogStatus(Player *pPlayer, uint32 defstatus);
	Quest *getNextAvailableQuest(Player *pPlayer, Quest *prevQuest);

    bool hasQuest(uint32 quest_id);
    bool hasInvolvedQuest(uint32 quest_id);

    void addQuest(uint32 quest_id) { mQuestIds.push_back(quest_id); };
    void addInvolvedQuest(uint32 quest_id) { mInvolvedQuestIds.push_back(quest_id); };

	void prepareQuestMenu( Player *pPlayer, NPCQuestMenu *qMenu );

	//---------------------------------------------------
	//  AI Functions
	//---------------------------------------------------
	virtual void AI_Update();
	void AI_AttackReaction (Unit *pAttacker, float damage_dealt);
	void AI_SendMoveToPacket (float x, float y, float z, uint32 time, bool run);

	void AI_ChangeState (CreatureState state) { m_creatureState = state; }
	CreatureState AI_GetState() { return m_creatureState; }

	void AI_MoveTo (float x, float y, float z, bool run, float stopDistance=0);
	void AI_MoveTo (Unit *npc, bool run, float stopDistance=0);
	void AI_Follow (Unit *target);
	void AI_StopFollow ();
	void GuardCheckForViolators();
	
	virtual void OnExitCombat();

	//-------------------------------------
    // Looting
	//-------------------------------------
    void GenerateLoot();
	void GenerateWorldLoot();
	void SetEmptyLoot (uint32 loot_sparkles);

    uint32 getLootMoney() { return m_lootMoney; }
    void setLootMoney(uint32 amount) { m_lootMoney = amount; }

	//-------------------------------------
    // Name
	//-------------------------------------
    const char* GetName() const { return m_name.c_str(); };
    void SetName(const char* name) { m_name = name; } // May not work?

	//-------------------------------------
    // Misc
	//-------------------------------------
	uint32 getDefaultNPCText() { return m_defaultNPCText; }
    inline void setEmoteState(uint8 emote) { m_emoteState = emote; };
    //uint8 getMovementState() { return m_movementState; };
    //uint8 setMovementState(uint8 movement) { m_movementState = movement; };

    virtual void setDeathState(DeathState s) {
        m_deathState = s;
        if(s == JUST_DIED) {
            m_deathTimer = m_corpseDelay;
        }
    };
	// If provided 1 or 2 time parameters - will set spawnTime[0] and [1]
	// and then choose random m_respawnTimer in their range
	void ResetRespawnTimer (uint32 time1=0, uint32 time2=0);

    // Serialization
    virtual void SaveToDB();
    void LoadFromDB (uint32 guid, WaypointVectorMap *precache = NULL);
    void DeleteFromDB();

	typedef enum {
		FLAT_RANDOM_ROAM	= 0,
		RANDOM_ROAM			= 1,
		FOLLOW_PATH_FORTH	= 2,
		FOLLOW_PATH_BACK	= 3,
		LOOP_PATH_FORTH		= 4,
		LOOP_PATH_BACK		= 5
	} MovementType;

	MovementType GetMovementType() { return m_movementType; }
	void SetMovementType (MovementType m) { m_movementType = m; }
	
	// True if mob walks along path and its important to keep him not suspended
	// when players leave all surrounding cells
	virtual bool IsPathWalker() { return m_movementType >= 2 && m_movementType <= 5; }

	int GetCurrentWaypoint() { return m_currentWaypoint; }
	void SetCurrentWaypoint (int wp) { m_currentWaypoint = wp; }


protected:
	int		m_alertAtWaypoint;
	int		m_alertAtWaypointValue;
public:
	void CallScriptAtWaypoint (int wp, int value) {
		m_alertAtWaypoint = wp;
		m_alertAtWaypointValue = value;
	}


protected:
    void _LoadGoods();
    void _LoadQuests();
    void _LoadMovement (WaypointVectorMap *precache = NULL);

    /// Looting
    uint32 m_lootMoney;

    /// Movement
    uint8 m_movementState;
	PreciseTime m_lastMoveTo;	// time when last moveto most hated target issued

    /// Timers
    int32 m_deathTimer;    // timer for death or corpse disappearance
    int32 m_respawnTimer;  // timer for respawn to happen
    int32 m_moveTimer;     // timer creature moves
    //int32 m_respawnDelay;  // delay between corpse disappearance and respawning
    int32 m_corpseDelay;   // delay between death and corpse disappearance

    /// Vendor data
    CreatureItemVector item_list;
    //int itemcount;

    /// Taxi data
    //uint32 mTaxiNode;

    /// Quest data
    list<uint32> mQuestIds;
    list<uint32> mInvolvedQuestIds;

    /// Respawn Coordinates
    float respawn_cord[3], respawn_angle;

    /// Movement
    int32	m_currentWaypoint;
    //bool m_moveBackward;
    //bool m_moveRandom;
    bool	m_moveRun;

	MovementType	m_movementType;
    CreatureState m_creatureState;

	// Random roaming radius - valid for MovementType = FLAT_RANDOM_ROAM
	// Spawning radius - valid for all creatures
	float			m_spawnDist;

	// Creature respawn times min...max
	uint32			m_spawnTime[2];

    //uint32 m_nWaypoints;
    //float m_waypoints[MAX_CREATURE_WAYPOINTS][3]; // will be changed to list
	WaypointVector m_waypoints;
    float m_moveSpeed;

    float m_destinationX;
    float m_destinationY;
    float m_destinationZ;

	Unit *UnitToFollow;

    int32 m_timeToMove;
    int32 m_timeMoved;

    /// Misc
    uint8 m_emoteState;
    string m_name;

	// Specials
	uint32 m_defaultNPCText;

	// Equip NPC
	void EquipNPC();
};

//-----------------------------------------------------------------------------
class WaypointIndicator: public Creature 
{
public:
	Creature	*m_wpOwner;
	uint32		m_wpIndex;

	WaypointIndicator() { Creature(); }

	virtual void UpdateMobMovement (int32 p_time) {}
	virtual void SaveToDB() {}
	virtual void AI_Update() {}
};

//-----------------------------------------------------------------------------
#include <list>
typedef list<WaypointIndicator *> WaypointIndicatorList;

#define WAYPOINT_NPC_FLAG	0
#define WAYPOINT_NPC_ID		10000000
#define IS_WAYPOINT(c) (c->GetUInt32Value (OBJECT_FIELD_ENTRY) >= WAYPOINT_NPC_ID && \
						c->GetUInt32Value (OBJECT_FIELD_ENTRY) <= (WAYPOINT_NPC_ID + 10000))

#endif
