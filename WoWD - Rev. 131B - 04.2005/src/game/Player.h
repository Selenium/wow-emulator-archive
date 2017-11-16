// Copyright (C) 2004 WoWD Team

#ifndef _PLAYER_H
#define _PLAYER_H

#include "Unit.h"
#include "Database/DatabaseEnv.h"
struct Mail;
class Channel;

//====================================================================
//  Inventory
//  Holds the display id and item type id for objects in
//  a character's inventory
//====================================================================

enum Classes
{
    WARRIOR = 1,
    PALADIN = 2,
    HUNTER = 3,
    ROGUE = 4,
    PRIEST = 5,
    SHAMAN = 7,
    MAGE = 8,
    WARLOCK = 9,
    DRUID = 11,
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

struct PlayerCreateInfo{
    uint8 index;
    uint8 race;
    uint8 class_;
    uint32 mapId;
    uint32 zoneId;
    float positionX;
    float positionY;
    float positionZ;
    uint16 displayId;
    uint8 strength;
    uint8 ability;
    uint8 stamina;
    uint8 intellect;
    uint8 spirit;
    uint32 health;
    uint32 mana;
    uint32 rage;
    uint32 focus;
    uint32 energy;
    uint32 attackpower;
    float mindmg;
    float maxdmg;
    uint32 item[10];
    uint8 item_slot[10];
    uint16 spell[10];
};

enum PlayerMovementType
{
    MOVE_ROOT       = 1,
    MOVE_UNROOT     = 2,
    MOVE_WATER_WALK = 3,
    MOVE_LAND_WALK  = 4,
};

enum PlayerSpeedType
{
    RUN      = 1,
    RUNBACK  = 2,
    SWIM     = 3,
    SWIMBACK = 4,
    WALK     = 5,
};

class Quest;
class Spell;
class Item;
class WorldSession;

#define EQUIPMENT_SLOT_START         0
#define EQUIPMENT_SLOT_HEAD          0
#define EQUIPMENT_SLOT_NECK          1
#define EQUIPMENT_SLOT_SHOULDERS     2
#define EQUIPMENT_SLOT_BODY          3
#define EQUIPMENT_SLOT_CHEST         4
#define EQUIPMENT_SLOT_WAIST         5
#define EQUIPMENT_SLOT_LEGS          6
#define EQUIPMENT_SLOT_FEET          7
#define EQUIPMENT_SLOT_WRISTS        8
#define EQUIPMENT_SLOT_HANDS         9
#define EQUIPMENT_SLOT_FINGER1       10
#define EQUIPMENT_SLOT_FINGER2       11
#define EQUIPMENT_SLOT_TRINKET1      12
#define EQUIPMENT_SLOT_TRINKET2      13
#define EQUIPMENT_SLOT_BACK          14
#define EQUIPMENT_SLOT_MAINHAND      15
#define EQUIPMENT_SLOT_OFFHAND       16
#define EQUIPMENT_SLOT_RANGED        17
#define EQUIPMENT_SLOT_TABARD        18
#define EQUIPMENT_SLOT_END           19

#define INVENTORY_SLOT_BAG_START     19
#define INVENTORY_SLOT_BAG_1         19
#define INVENTORY_SLOT_BAG_2         20
#define INVENTORY_SLOT_BAG_3         21
#define INVENTORY_SLOT_BAG_4         22
#define INVENTORY_SLOT_BAG_END       23

#define INVENTORY_SLOT_ITEM_START    23
#define INVENTORY_SLOT_ITEM_1        23
#define INVENTORY_SLOT_ITEM_2        24
#define INVENTORY_SLOT_ITEM_3        25
#define INVENTORY_SLOT_ITEM_4        26
#define INVENTORY_SLOT_ITEM_5        27
#define INVENTORY_SLOT_ITEM_6        28
#define INVENTORY_SLOT_ITEM_7        29
#define INVENTORY_SLOT_ITEM_8        30
#define INVENTORY_SLOT_ITEM_9        31
#define INVENTORY_SLOT_ITEM_10       32
#define INVENTORY_SLOT_ITEM_11       33
#define INVENTORY_SLOT_ITEM_12       34
#define INVENTORY_SLOT_ITEM_13       35
#define INVENTORY_SLOT_ITEM_14       36
#define INVENTORY_SLOT_ITEM_15       37
#define INVENTORY_SLOT_ITEM_16       38
#define INVENTORY_SLOT_ITEM_END      39


//====================================================================
//  Player
//  Class that holds every created character on the server.
//
//  TODO:  Attach characters to user accounts
//====================================================================
class Player : public Unit
{
    friend class WorldSession;
public:
    Player ( );
    ~Player ( );

    void AddToWorld();
    void RemoveFromWorld();

    void Create ( uint32 guidlow, WorldPacket &data );

    void Update( uint32 time );

    void BuildEnumData( WorldPacket * p_data );

    uint8 ToggleAFK() { m_afk = !m_afk; return m_afk; };
    const char* GetName() { return m_name.c_str(); };

    void Die();
    void KilledMonster(uint32 entry, const uint64 &guid);
    void GiveXP(uint32 xp, const uint64 &guid);
    void Regenerate(uint16 field_cur, uint16 field_max, bool switch_);

    // Taxi
    void setDismountTimer(uint32 time) { m_dismountTimer = time; };
    void setDismountCost(uint32 money) { m_dismountCost = money; };
    void setMountPos(float x, float y, float z) { m_mount_pos_x = x;
                                                  m_mount_pos_y = y;
                                                  m_mount_pos_z = z; }

    // Quests
    uint32 getQuestStatus(uint32 quest_id);
    uint32 addNewQuest(uint32 quest_id, uint32 status=4);
    void loadExistingQuest(struct quest_status qs);
    void setQuestStatus(uint32 quest_id, uint32 new_status);
    bool checkQuestStatus(uint32 quest_id);
    uint16 getOpenQuestSlot();
    uint16 getQuestSlot(uint32 quest_id);

	void AddMail(Mail *m);

    // sets the needed bits for any quests in the player's log
    //void setQuestLogBits(UpdateMask *updateMask);
    std::map<uint32, struct quest_status> getQuestStatusMap() { return mQuestStatus; };

    const uint64& GetSelection( ) const { return m_curSelection; }
    const uint64& GetTarget( ) const { return m_curTarget; }

    void SetSelection(const uint64 &guid) { m_curSelection = guid; }
    void SetTarget(const uint64 &guid) { m_curTarget = guid; }

	uint32 GetMailSize() { return m_mail.size();};
	Mail* GetMail(uint32 id);
	void RemoveMail(uint32 id);
	std::list<Mail*>::iterator GetmailBegin() { return m_mail.begin();};
	std::list<Mail*>::iterator GetmailEnd() { return m_mail.end();};
	void AddBid(bidentry *be);
	bidentry* GetBid(uint32 id);
	std::list<bidentry*>::iterator GetBidBegin() { return m_bids.begin();};
	std::list<bidentry*>::iterator GetBidEnd() { return m_bids.end();};
    // spells
	bool HasSpell(uint32 spell);
    void smsg_InitialSpells();
    void addSpell(uint16 spell_id, uint16 slot_id=0xffff);
    inline std::list<struct spells> getSpellList() { return m_spells; };

    // groups
    void SetInvited() { m_isInvited = true; }
    void SetInGroup() { m_isInGroup = true; }
    void SetLeader(const uint64 &guid) { m_groupLeader = guid; }

    int  IsInGroup() { return m_isInGroup; }
    int  IsInvited() { return m_isInvited; }
    const uint64& GetGroupLeader() const { return m_groupLeader; }

    void UnSetInvited() { m_isInvited = false; }
    void UnSetInGroup() { m_isInGroup = false; }

    // Items
    void SwapItemSlots(uint8 srcslot, uint8 dstslot);
    Item* GetItemBySlot(uint8 slot) const
    {
        ASSERT(slot < INVENTORY_SLOT_ITEM_END);
        return m_items[slot];
    }
    uint32 GetSlotByItemID(uint32 ID);
	uint32 GetSlotByItemGUID(uint64 guid);
    void AddItemToSlot(uint8 slot, Item *item);
    Item* RemoveItemFromSlot(uint8 slot);
    uint8 FindFreeItemSlot(uint32 type);
    bool CanEquipItemInSlot(uint8 slot, uint32 type);

    // looting
    const uint64& GetLootGUID() const { return m_lootGuid; }
    void SetLootGUID(const uint64 &guid) { m_lootGuid = guid; }

    WorldSession* GetSession() const { return m_session; }
    void SetSession(WorldSession *s) { m_session = s; }

    void CreateYourself( );
    void DestroyYourself( );

    // These functions build a specific type of A9 packet
    void BuildCreateUpdateBlockForPlayer( UpdateData *data, Player *target ) const;
    void DestroyForPlayer( Player *target ) const;

    // Serialize character to db
    void SaveToDB();
    void LoadFromDB(uint32 guid);
    void DeleteFromDB();

    //Death Stuff
    void SpawnCorpseBody();
    void SpawnCorpseBones();
    void CreateCorpse();
    void KillPlayer();
    void ResurrectPlayer();
    void BuildPlayerRepop();
    void DeathDurabilityLoss(double percent);
    void RepopAtGraveyard();

    //Movement stuff
    void SetMovement(uint8 pType);
    void SetPlayerSpeed(uint8 SpeedType, float value, bool forced=false);

	//Channel stuff
	void JoinedChannel(Channel *c);
	void LeftChannel(Channel *c);
	void CleanupChannels();

protected:
    void _SetCreateBits(UpdateMask *updateMask, Player *target) const;
    void _SetUpdateBits(UpdateMask *updateMask, Player *target) const;
    void _SetVisibleBits(UpdateMask *updateMask, Player *target) const;

	void _SaveMail();
	void _LoadMail();
    void _SaveInventory();
    void _SaveSpells();
    void _SaveQuestStatus();
    void _SaveAffects();
	void _SaveBids();
	void _LoadBids();
	void _SaveAuctions();
    void _LoadInventory();
    void _LoadSpells();
    void _LoadQuestStatus();
    void _LoadAffects();

    void _ApplyItemMods(Item *item, bool apply);
    void _RemoveAllItemMods();
    void _ApplyAllItemMods();

    uint64 m_lootGuid;

    std::string m_name;    // max 21 character name
    uint8 m_outfitId;

    uint16 m_guildId;
    uint16 m_petInfoId; // pet display info id
    uint16 m_petLevel;  // pet experience level
    uint16 m_petFamilyId; // pet creature family id

    uint32 m_regenTimer;
    uint32 m_dismountTimer;
    uint32 m_dismountCost;
    float m_mount_pos_x;
    float m_mount_pos_y;
    float m_mount_pos_z;

    // Inventory and equipment
    Item* m_items[INVENTORY_SLOT_ITEM_END];

    // AFK status
    uint8 m_afk;

    // guid of current target
    uint64 m_curTarget;

    // guid of current selection
    uint64 m_curSelection;

    // current quest statuses
    typedef std::map<uint32, struct quest_status> StatusMap;
    StatusMap mQuestStatus;

    // Group
    uint64 m_groupLeader;
    bool m_isInGroup;
    bool m_isInvited;

	// items the player has bid on
	std::list<bidentry*> m_bids;

	// pieces of mail the player has
	std::list<Mail*> m_mail;

    // Player Spells
    std::list<struct spells> m_spells;

    // Pointer to this char's game client
    WorldSession *m_session;

	// Channels
	std::list<Channel*> m_channels;

};

#endif

