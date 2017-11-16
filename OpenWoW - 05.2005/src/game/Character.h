//////////////////////////////////////////////////////////////////////
//  Character
//
//  Provides basic Character functions
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

#ifndef WOWPYTHONSERVER_CHARACTER_H
#define WOWPYTHONSERVER_CHARACTER_H

#include "Unit.h"

//====================================================================
//  Inventory
//  Holds the display id and item type id for objects in
//	a character's inventory
//====================================================================

enum Classes
{
	WARRIOR=1,
	PALADIN=2,
	HUNTER=3,
	ROGUE=4,
	PRIEST=5,
	SHAMAN=7,
	MAGE=8,
	WARLOCK=9,
	DRUID=11
};

struct ItemMember{
	uint32 guid;
	uint32 itemid;
};


struct Inventory{
	uint32 displayId;
	uint8 itemType;
};

struct quest_status{
	quest_status(){
		memset(m_questItemCount, 0, 16);
		memset(m_questMobCount, 0, 16);
	}
	uint32 quest_id;
	uint32 status;
	uint32 m_questItemCount[4]; // number of items collected
	uint32 m_questMobCount[4];  // number of monsters slain
};

struct spells{
	uint16 spellId;
	uint16 slotId;
};

//START OF LINA ACTION BAR
struct actions{
	uint8 button;
	uint8 type;
	uint8 misc;
	uint16 action;
};
//END OF LINA ACTION BAR

class Quest;

//====================================================================
//  Character
//  Class that holds every created character on the server.
//
//	TODO:  Attach characters to user accounts
//====================================================================
class Character : public Unit
{
	friend class WorldServer;
	friend class DatabaseInterface;
	friend class GameClient;
	friend class MiscHandler;
public:
	Character ( );
	~Character ( );

	bool isPlayer() { return true; };

	//void Create ( uint8 * data, uint16 length );
	void Create ( uint32 guidlow, struct NetworkPacket &data );
	void Update( uint32 time );

	void BuildEnumData( uint8 * data, uint8 * length );

	void BuildUpdateBlock(UpdateMask *updateMask, uint8 * data, int* length) ;

	// fill UpdateValues with data from a space seperated string of uint32s
	virtual void LoadUpdateValues(uint8* data);

	uint8 ToggleAFK() { m_afk = !m_afk; return m_afk; };
	char* getName() { return (char*)m_name; };
	char* getGuildName() { return (char*)m_guildname; };

	void Die();
	void KilledMonster(uint32 entry, guid mguid);
	void GiveXP (uint32 xp_to_give, guid vguid = guid ());
	uint32 Regen(uint32 curValue, uint32 maxValue, uint16 regenField, uint32* lastRegen);
	uint32 Regenmp(uint32 curValue2, uint32 maxValue2, uint16 regenField2, uint32* lastRegen2);

	// Quests
	uint32 getQuestStatus(uint32 quest_id);
	uint32 addNewQuest(uint32 quest_id, uint32 status=4);
	void loadExistingQuest(struct quest_status qs);
	void setQuestStatus(uint32 quest_id, uint32 new_status);
	bool checkQuestStatus(uint32 quest_id);
	uint16 getOpenQuestSlot();
	uint16 getQuestSlot(uint32 quest_id);

	// sets the needed bits for any quests in the player's log
	void setQuestLogBits(UpdateMask *updateMask);
	std::map<uint32, struct quest_status> getQuestStatusMap() { return mQuestStatus; };

	inline const guid getSelection () { return m_curSelection; }
	inline const guid getTarget () { return m_curTarget; }

	// Spells
	void smsg_InitialSpells();
	void addSpell(uint16 spell_id, uint16 slot_id=0xffff);
	inline std::list<struct spells> getSpellList() { return m_spells; };

	// groups
	void SetInvited() { isinvited = 1; }
	void SetLeader(char * name) { strcpy(groupleader , name); }
	void SetInGroup() { isingroup = 1; }
	int  IsInGroup() { return isingroup == 1 ? 1 : 0; }
	int  IsInvited() { return isinvited == 1 ? 1 : 0; }
	char * GetGroupLeader() { return groupleader; }
	void UnSetInvited() { isinvited = 0; }
	void UnSetInGroup() { isingroup = 0; }
	void SwapItemInSlot(int srcslot, int destslot);
	uint32 getItemIdBySlot(int slot) { return m_items[slot].itemid; }
	uint32 getGuidBySlot(int slot) { return m_items[slot].guid; }
	void AddItemToSlot(int slot, uint32 tempitemguid, uint32 tempitemid) {
		m_items[slot].itemid = tempitemid;
		m_items[slot].guid = tempitemguid;
	}
	guid getLootGUID () { return m_lootGuid; };
	void setLootGUID (guid lguid)
	{
		m_lootGuid = lguid;
	}
	void updateItemStats();

	inline void setNewPosition(float x, float y, float z)
	{
		m_newPos[0] = x;
		m_newPos[1] = y;
		m_newPos[2] = z;
	}

	inline void SetPosToNewPos()
	{
		setPosition(m_newPos[0], m_newPos[1], m_newPos[2], m_orientation, true);
	}

	GameClient *pClient;    // pointer to this char's game client

	///////////////////////////////Heal lasts some time - changed by nothin //////////////
	uint32 m_healingDuration;
	uint32 m_healingTimer;
	uint32 m_replenish_field;
	uint32 m_replenish_value;
	uint32 m_spell;
	//////////////////////////////////////////////////////////////////////////////////////

	//START OF LINA ACTION BAR
	inline std::list<struct actions> getActionList() { return m_actions; };
	void addAction(uint8 button, uint16 action, uint8 type, uint8 misc);	void removeAction(uint8 button);// added gb
	void smsg_InitialActions();
	//END OF LINA ACTION BAR

	bool isAllreadyLearned(uint16 spell_id); //LINA
	void giveStat(); //update stat each level up

protected:
	int m_accountId;

	float m_newPos[3];  // temp vars to hold a new position (ie, to tell me where to worldport)
	guid m_lootGuid;

	char m_name[22];	// max 21 character name
	uint8 m_outfitId;

	uint16 m_guildId;
	char m_guildname[22];
	uint16 m_petInfoId;	// pet display info id
	uint16 m_petLevel;	// pet experience level
	uint32 m_petFamilyId; // pet creature family id

	uint32 m_regenTimer;

	// Inventory
	// Foole's packet pages say to loop this 20 times, only 20 inv slots maybe?
	Inventory m_inventory[20];

	ItemMember m_items[39];
	// AFK status
	uint8 m_afk;

	// guid of current target
	guid m_curTarget;

	// guid of current selection
	guid m_curSelection;

	// current quest statuses
	typedef std::map<uint32, struct quest_status> StatusMap;
	StatusMap mQuestStatus;

	// some group shit
	// might not be used
	char groupleader[22];
	int isingroup;
	int isinvited;

	// Timers
	uint32 m_lastHpRegen;
	uint32 m_lastManaRegen;

	// Player Spells
	std::list<struct spells> m_spells;

	std::list<struct actions> m_actions; //LINA ACTION BAR

	uint8 m_stat0;
	uint8 m_stat1;
	uint8 m_stat2;
	uint8 m_stat3;
	uint8 m_stat4;

	uint32 m_health;
	uint32 m_mana;

};

#endif

