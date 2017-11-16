//////////////////////////////////////////////////////////////////////
//  Unit
//
//  ??
//////////////////////////////////////////////////////////////////////

// Copyright (C) 2004 Team Python
// Copyright (C) 2004, 2005 Team WSD
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

#ifndef WOWPYTHONSERVER_UNIT_H
#define WOWPYTHONSERVER_UNIT_H

#include "Object.h"
#include "UpdateMask.h"
#include <time.h>


struct creepItem{
	uint32 itemid;
	int amount;
};

enum DeathState{
	ALIVE=0,    // Unit is alive and well
	JUST_DIED,  // Unit has JUST died
	CORPSE,     // Unit has died but remains in the world as a corpse
	DEAD        // Unit is dead and his corpse is gone from the world
};

enum CreatureState {
	STOPPED,
	MOVING,
	ATTACKING
};

#define UF_TARGET_DIED  1
#define UF_ATTACKING    2   // this unit is attacking it's selection
#define MAX_CREATURE_WAYPOINTS 16
#define UNIT_MOVEMENT_INTERPOLATE_INTERVAL 300 // ms

class Quest;
class Character;
class Item;
class GameClient;
//====================================================================
//  Unit
//  Base object for Players ? is that all?
//====================================================================
class Unit : public Object
{
	friend class WorldServer;
	friend class DatabaseInterface;
	friend class MiscHandler;
public:
	Unit ( );
	virtual ~Unit ( );

	///////  Creation / Updates  ///////////////////////////////////////////////////////
	virtual void Create (uint32 guidlow);
	virtual void Create (uint32 guidlow, uint8* creature_name,
			     float x, float y, float z, float ang);
	void Update( uint32 time );

	// <WoW Chile Dev Team> Start Change
	void UpdateMobMovement( uint32 p_time);
	// <WoW Chile Dev Team> Stop Change

	//    void SendCreateWithTempNpcFlags(UpdateMask *updateMask, GameClient *pClient);  // kinda hackish function I guess
	int CheckQuestgiverFlag(Character *pPlayer, UpdateMask *unitMask, NetworkPacket * data);

	virtual void BuildUpdateBlock(UpdateMask* updateMask, uint8 * data, int* length);

	// fill UpdateValues with data from a space seperated string of uint32s
	virtual void LoadUpdateValues(uint8* data);
	///////////////////////////////////////////////////////////////////////



	///////  Quests ///////////////////////////////////////////////////////
	uint32 getQuestStatus(Character *pPlayer);
	uint32 getCurrentQuest(Character *pPlayer);

	char* getQuestTitle(uint32 quest_id);
	char* getQuestDetails(uint32 quest_id);
	char* getQuestObjectives(uint32 quest_id);
	char* getQuestCompleteText(uint32 quest_id);
	char* getQuestIncompleteText(uint32 quest_id);

	bool hasQuest(uint32 quest_id);
	void addQuest(uint32 quest_id) { mQuestIds.push_back(quest_id); };
	void removeQuest(uint32 quest_id);
	///////////////////////////////////////////////////////////////////////


	///////  Combat / Death Status /////////////////////////////////////////
	inline bool isAlive() { return m_deathState == ALIVE; };
	inline bool isDead() { return ( m_deathState == DEAD || m_deathState == CORPSE ); };
	inline void setDeathState(DeathState s)
	{
		m_deathState = s;
		if(s == JUST_DIED)
		{
			m_deathTimer = m_corpseDelay;
		}
	};
	inline DeathState getDeathState() { return m_deathState; }
	void setAttackTimer();
	inline bool isAttackReady() { return m_attackTimer == 0; }
	bool canReachWithAttack(Unit *pVictim);
	///////////////////////////////////////////////////////////////////////

	///////  AI  /////////////////////////////////////////////////////////////////////////
	void AI_Update();
	void AI_AttackReaction(Unit *pAttacker, uint32 damage_dealt);
	// <WoW Chile Dev Team> Start Change
	void AI_SendMoveToPacket(float x, float y, float z, uint32 time, bool run);
	void AI_ChangeState(CreatureState state) { m_creatureState = state; }
	void AI_MoveTo(float x, float y, float z, bool run);
	uint32 AI_GetClosestTarget();
	uint32 AI_GetClosestChar();
	uint32 closest_dist;

	//    void AI_Escape(); // escape if health is low
	// <WoW Chile Dev Team> Stop Change
	//////////////////////////////////////////////////////////////////////////////////////
	bool addWaypoint(float x, float y, float z);
	inline bool hasWaypoints() { return m_nWaypoints > 0; }
	inline void setMoveRandomFlag(bool f) { m_moveRandom = f; }
	inline void setMoveRunFlag(bool f) { m_moveRun = f; }
	inline bool getMoveRandomFlag() { return m_moveRandom; }
	inline bool getMoveRunFlag() { return m_moveRun; }

	//////  Items ///////////////////////////////////////////////////////////////////////////////
	void	setItemId(int slot, uint32 tempitemid) { item_list[slot].itemid = tempitemid; }
	void	setItemAmount(int slot, int tempamount) { item_list[slot].amount = tempamount; }
	void	setItemAmountById(uint32 tempitemid, int tempamount)
	{
		int i;
		for(i=0;i<itemcount;i++)
		{
			if(item_list[i].itemid == tempitemid)
				item_list[i].amount = tempamount;
		}
	}
	void	increaseItemCount() { itemcount++; }
	void	addItem(uint32 itemid, uint32 amount)
	{
		item_list[itemcount].amount = amount;
		item_list[itemcount].itemid = itemid;
		itemcount++;
	}
	int		getItemCount() { return itemcount; }
	int		getItemAmount(int slot) { return item_list[slot].amount; }
	uint32	getItemId(int slot) { return item_list[slot].itemid; }
	//////////////////////////////////////////////////////////////////////////////////////////////


	///////  Flags /////////////////////////////////////////////////////////
	inline const uint32 addUnitFlag(uint32 new_flag)
	{
		uint32 flags = getUpdateValue(UNIT_FIELD_FLAGS);
		flags |= new_flag;
		setUpdateValue(UNIT_FIELD_FLAGS, flags);
		return flags;
	};

	inline const uint32 removeUnitFlag(uint32 old_flag)
	{
		uint32 flags = getUpdateValue(UNIT_FIELD_FLAGS);
		flags &= ~old_flag;
		setUpdateValue(UNIT_FIELD_FLAGS, flags);
		return flags;
	};

	inline int hasFlag(uint32 flag) {
		return (getUpdateValue(UNIT_FIELD_FLAGS) & flag);
	};

	// State flags are server-only flags to help me know when to do stuff, like die, or attack
	inline void addStateFlag(uint32 f) { m_state |= f; };
	inline void clearStateFlag(uint32 f) { m_state &= ~f; };
	///////////////////////////////////////////////////////////////////////


	/////////  Misc / Get / Set /////////////////////////////////////
	virtual bool isPlayer()
	{ return false; };
	inline void setEmoteState(uint8 emote)
	{ m_emoteState = emote; };
	void setAnimFrequency (uint32 anim, float frequency);
	char* getCreatureName ()
	{ return (char*)m_creatureName; };
	uint8 getMovementState ()
	{ return m_movementState; };
	void setMovementState (uint8 movement)
	{ m_movementState = movement; };
	inline uint8 getLevel ()
	{ return (uint8)m_updateValues[ UNIT_FIELD_LEVEL ]; };
	inline uint8 getRace ()
	{ return (uint8)m_updateValues[ UNIT_FIELD_BYTES_0 ] & 0xFF; };
	inline uint8 getClass ()
	{ return (uint8)(m_updateValues[ UNIT_FIELD_BYTES_0 ] >> 8) & 0xFF; };
	inline uint8 getGender ()
	{ return (uint8)(m_updateValues[ UNIT_FIELD_BYTES_0 ] >> 16) & 0xFF; };
	inline uint16 getZone ()
	{ return m_zoneId; };
	/////////////////////////////////////////////////////////////////

	/////////  Looting //////////////////////////////////////////////
	void generateLoot();
	uint32 getLootMoney() { return m_lootMoney; };
	void setLootMoney(uint32 amount) { m_lootMoney = amount; };
	/////////////////////////////////////////////////////////////////


	//////////////////////Damage lasts some time/absorb - changed by nothin //////////////
	uint32 m_damageDuration;
	uint32 m_damageTimer;
	uint32 m_damage;
	uint32 m_absorb;
	uint32 m_absorbDuration;
	uint32 m_absorbTimer;
	uint32 m_absorbspell;
	uint32 m_auraTimer;
	uint32 m_aura_found;
	uint32 m_aura_found2;
	uint32 m_auraDuration;
	uint32 m_shieldDuration;
	uint32 m_shieldTimer;
	uint32 m_shield;
	uint32 m_shieldspell;
	bool   m_follow;
	uint32 m_pet_state;
	guid m_Attacker;

	//////////////////////////////////////////////////////////////////////////////////////
	float m_moveSpeed;
	uint8  m_movementState;

	void setCreatureName (char* CreatureName); //LINA @NAME COMMAND PATCH
	inline void setAggressive (uint8 aggr) { m_aggressive =	aggr; };
	inline uint8 getAggressive () { return m_aggressive; };
	inline void setPet () { m_Pet = true; };
	inline bool isPet () { return m_Pet; };

	CreatureState m_creatureState;
	uint32 m_state;         // flags for keeping track of some states

	std::list<Unit*> m_attackers;

	uint32 m_respawnDelay;  // delay between corpse disappearance and respawning
	uint32 m_corpseDelay;   // delay between death and corpse disappearance

protected:

	// Looting
	uint32 m_lootMoney;

	// Creature data
	uint8  m_emoteState;
	uint8  m_creatureName[80];

	uint32 m_deathTimer;    // timer for death or corpse disappearance
	uint32 m_respawnTimer;  // timer for respawn to happen
	uint32 m_attackTimer;   // timer for attack
	uint32 m_moveTimer;     // timer creature moves

	DeathState m_deathState;

	// Quest data
	std::list<uint32> mQuestIds;

	// Anim data for frexxy
	std::map <uint32, float> mAnimFrequencies;

	// Item data
	creepItem item_list[128];
	int itemcount;

	// Taxi data
	uint32 mTaxiNode;

	// movement code
	uint32 m_currentWaypoint;
	bool m_moveBackward;
	bool m_moveRandom;
	bool m_moveRun;

	uint32 m_nWaypoints;
	float m_waypoints[MAX_CREATURE_WAYPOINTS][3]; // will be changed to list

	float m_destinationX;
	float m_destinationY;
	float m_destinationZ;

	uint8 m_aggressive;

	bool m_Pet;

};
#endif
