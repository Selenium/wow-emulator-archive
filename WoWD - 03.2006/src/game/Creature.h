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
#include "Quest.h"
#include "Opcodes.h"
#include "EventMgr.h"

class Quest;
class Player;
class WorldSession;

using namespace std;

#define MAX_CREATURE_ITEMS 128
#define MAX_CREATURE_LOOT 8
#define MAX_CREATURE_SPELL 32

struct CreatureItem
{
	uint32 itemid;
	int amount;
};

struct CreatureInfo
{
	uint32 Id;
	std::string Name;
	std::string SubName;
	uint32 Flags1;
	uint32 Type;
	uint32 Family;
	uint32 Rank;
	uint32 Unknown1;
	uint32 Unknown2;
	uint32 DisplayID;
	uint8  Civilian;
	uint8  Unknown3;
};

struct CreatureSpawnTemplate
{
	uint32 EntryID;
	uint32 MaxHealth;
	uint32 MaxMana;
	uint32 Armor;
	uint32 Level;
	uint32 Faction;
	uint32 Flag;
	float Scale;
	float Speed;
	float MinDamage;
	float MaxDamage;
	float MinRangedDamage;
	float MaxRangedDamage;
	uint32 BaseAttackTime;
	uint32 RangedAttackTime;
	float BoundingRadius;
	float CombatReach;
	uint32 MountModelID;
	uint32 Slot1Model;
	uint8 Slot1Info1;
	uint8 Slot1Info2;
	uint8 Slot1Info3;
	uint8 Slot1Info4;
	uint8 Slot1Info5;
	uint32 Slot2Model;
	uint8 Slot2Info1;
	uint8 Slot2Info2;
	uint8 Slot2Info3;
	uint8 Slot2Info4;
	uint8 Slot2Info5;
	uint32 Slot3Model;
	uint8 Slot3Info1;
	uint8 Slot3Info2;
	uint8 Slot3Info3;
	uint8 Slot3Info4;
	uint8 Slot3Info5;
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

typedef struct
{
	Quest *qst;
	uint8 type;
} QuestRelation;

///////////////////
/// Creature object

class Creature : public Unit
{
public:

	Creature();
	virtual ~Creature();

	/// Creation
	void Create (uint32 guidlow, const char* creature_name, uint32 mapid, float x, float y, float z, float ang);
    void CreateWayPoint (uint32 WayPointID, uint32 mapid, float x, float y, float z, float ang);

	/// Updates
	virtual void Update( uint32 time );

	/// Creature inventory
	void setItemId(int slot, uint32 tempitemid) { item_list[slot].itemid = tempitemid; }
	void setItemAmount(int slot, int tempamount) { item_list[slot].amount = tempamount; }
	void setItemAmountById(uint32 tempitemid, int tempamount);
	void increaseItemCount() { itemcount++; }
	void addItem(uint32 itemid, uint32 amount);
	int getItemCount() { return itemcount; }
	int getItemSlotById(uint32 itemid);
	int getItemAmount(int slot) { return item_list[slot].amount; }
	uint32 getItemId(int slot) { return item_list[slot].itemid; }

	/// Quests
	void _LoadQuests();
	bool HasQuests() { return m_quests != NULL; };
	void AddQuest(QuestRelation *Q);
	void DeleteQuest(QuestRelation *Q);
	Quest *FindQuest(uint32 quest_id, uint8 quest_relation);
	uint16 GetQuestRelation(uint32 quest_id);
	uint32 NumOfQuests();
	list<QuestRelation *>::iterator QuestsBegin() { return m_quests->begin(); };
	list<QuestRelation *>::iterator QuestsEnd() { return m_quests->end(); };
	void SetQuestList(std::list<QuestRelation *>* qst_lst) { m_quests = qst_lst; };

	inline bool isQuestGiver() { return HasFlag( UNIT_NPC_FLAGS, UNIT_NPC_FLAG_QUESTGIVER ); };

	//Make this unit face another unit
	bool setInFront(Unit* target);

	/// Looting
	void generateLoot();
	uint32 getLootMoney() { return m_lootMoney; }
	void setLootMoney(uint32 amount) { m_lootMoney = amount; }
	void setLootid(uint32 cnt, uint32 id) {lootSlots[cnt] = id;}
	uint32 getLootid(uint32 id) {return lootSlots[id];}
	std::map<uint32, uint32>::const_iterator getLootBegin() { return mItems.begin();}
	std::map<uint32, uint32>::const_iterator getLootEnd() { return mItems.end();}
	uint32 getLootAmt(uint32 id);
	uint32 getLootProp(uint32 id);
	void setLootAmt(uint32 id, uint32 amt);

	/// Spells
	void setSpellId(int count, uint32 spellid) { spell_data[count] = spellid; }
	void increaseSpellCount() { spellcount++; }
	int getSpellCount() { return spellcount; }    

	/// Name
	const char* GetName() const { return m_name.c_str(); };
	void SetName(const char* name) { m_name = name; }

	/// Misc
	inline void setEmoteState(uint8 emote) { m_emoteState = emote; };

	inline uint32 getNameEntry() { return m_nameEntry; };
	inline uint32 GetSQL_id() { return m_sqlid; };

	virtual void setDeathState(DeathState s);

	// Serialization
	void SaveToDB();
	void LoadFromDB(uint32 guid);
	void DeleteFromDB();

	/// Respawn Coordinates
	float respawn_cord[3];

	void OnJustDied();
	void OnRemoveCorpse();
	void OnRespawn();

    void Despawn();

	// Temp
	void _LoadHealth();

protected:
	void _LoadGoods();
	void _LoadMovement();

	/// Looting
	uint32 m_lootMoney;
	std::map<uint32,uint32>mItems;
	std::map<uint32,uint32>mProps;
	uint32 lootSlots[12];
	void _LoadLoot();
	int lootcount;


	/// Spells/Skills
	//uint8 m_movementState;
	//DK:ai SpellData
	uint32 spell_data[MAX_CREATURE_SPELL];
	void _LoadSpells();
	int spellcount;

	/// Timers
	uint32 m_deathTimer;    // timer for death or corpse disappearance
	uint32 m_respawnTimer;  // timer for respawn to happen
	uint32 m_moveTimer;     // timer creature moves
	uint32 m_respawnDelay;  // delay between corpse disappearance and respawning
	uint32 m_corpseDelay;   // delay between death and corpse disappearance

	/// Vendor data
	CreatureItem item_list[MAX_CREATURE_ITEMS];
	int itemcount;

	/// Taxi data
	uint32 mTaxiNode;

	/// Quest data
	std::list<QuestRelation *>* m_quests;

	/// Misc
	uint8 m_emoteState;
	std::string m_name;
	uint32 m_nameEntry;
	uint32 m_sqlid;

};

#endif
