
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
    DRUID=11,
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
	void Create ( uint32 guidlow, struct wowWData &data );
    void Update( float time );

	void BuildEnumData( uint8 * data, uint8 * length );

	void BuildUpdateBlock(UpdateMask *updateMask, uint8 * data, int* length) ;

    // fill UpdateValues with data from a space seperated string of uint32s
    virtual void LoadUpdateValues(uint8* data);

	uint8 ToggleAFK() { m_afk = !m_afk; return m_afk; };
	char* getName() { return (char*)m_name; };
	char* getGuildName() { return (char*)m_guildname; };

    void Die();
    void KilledMonster(uint32 entry, uint32 guid);
    void giveXP(uint32 xp_to_give, uint32 guidlow=0, uint32 guidhi=0);
    uint32 Regen(uint32 curValue, uint32 maxValue, uint16 regenField, uint32* lastRegen);

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

    inline const uint32* getSelectionPtr( ) { return m_curSelection; }
    inline const uint32 & getSelection( ) { return m_curSelection[0]; }
    inline const uint32 & getTarget( ) { return m_curTarget[0]; }

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
	uint32 getLootGUID() { return m_lootGuid[0]; };
	uint32 getLootGUIDHigh() { return m_lootGuid[1]; };
	void setLootGUID(uint32 guid1, uint32 guid2) 
	{ 
		m_lootGuid[0] = guid1;
		m_lootGuid[1] = guid2;
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
	void addAction(uint8 button, uint16 action, uint8 type, uint8 misc);
	void smsg_InitialActions();
	//END OF LINA ACTION BAR

	bool isAllreadyLearned(uint16 spell_id); //LINA
	void giveStat(); //update stat each level up
	uint32 lastSavedTime() { return m_lastSavedTime; };
	void setLastSavedTime(uint32 s_time) { m_lastSavedTime = s_time; };

protected:
	int m_accountId;

    float m_newPos[3];  // temp vars to hold a new position (ie, to tell me where to worldport)
	uint32 m_lootGuid[2];

	char m_name[22];	// max 21 character name
	uint8 m_outfitId;

	uint16 m_guildId;
	char m_guildname[22];
	uint16 m_petInfoId;	// pet display info id
	uint16 m_petLevel;	// pet experience level
	uint16 m_petFamilyId; // pet creature family id

    uint32 m_regenTimer;

	// Inventory
	// Foole's packet pages say to loop this 20 times, only 20 inv slots maybe?
	Inventory m_inventory[20];

	ItemMember m_items[39];
	// AFK status
	uint8 m_afk;

    // guid of current target
    uint32 m_curTarget[2]; 

    // guid of current selection
    uint32 m_curSelection[2];

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
	uint32 m_timeToSave;
	uint32 m_lastSavedTime;


    // Player Spells
    std::list<struct spells> m_spells;

	std::list<struct actions> m_actions; //LINA ACTION BAR

	uint8 m_stat0, m_stat1, m_stat2, m_stat3, m_stat4;
	uint8 stat0, stat1, stat2, stat3, stat4;
	uint32 m_health;
	uint32 m_mana;

};

#endif

