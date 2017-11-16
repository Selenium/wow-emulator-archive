// Copyright (C) 2004 WoWD Team

#ifndef _PLAYER_H
#define _PLAYER_H

#include "Unit.h"
#include "Quest.h"
#include "../Shared/Database/DatabaseEnv.h"
#include "../Shared/Util.h"
#include "Skill_Auto.h"
#include "Group.h"

#include "../Shared/Namespace.h"

struct Mail;
struct QEmote;
class Channel;
class Creature;
class ItemPrototype;
class NPCGossipMenu;
class NPCQuestMenu;
class UpdateData;
class UpdateMask;

//====================================================================
//  Inventory
//  Holds the display id and item type id for objects in
//  a character's inventory
//====================================================================

#define PLAYER_VISIBLE_ITEM_SIZE	12

struct quest_status{
    quest_status(){
        memset(m_questItemCount, 0, 16);
        memset(m_questMobCount, 0, 16);
		m_timerrel = 0;
    }
    uint32 quest_id;
    uint32 status;
	bool rewarded;
    uint32 m_questItemCount[4]; // number of items collected. Ignored
    uint32 m_questMobCount[4];  // number of monsters slain

	uint32	m_timer;
	uint32	m_timerrel;
	bool	m_explored;
};

/*
typedef struct {
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
    uint8 agility;
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
} PlayerCreateInfo;
*/
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

enum ErrorCodes
{
    CHAR_CREATE_OK			= 0x2E,
    CHAR_CREATE_FAILED		= 0x30,
	CHAR_CREATE_NAME_IN_USE = 0x31,
	CHAR_DELETE_OK			= 0x35,
	CHAR_DELETE_FAIL		= 0x36,
};

// Exploration System
struct Areas
{
	uint32 areaID;	
	uint32 areaFlag;
	float x1;
	float x2;
	float y1;
	float y2;
};


class Quest;
class Spell;
class Item;
class Container;
class WorldSession;


#define EQUIPMENT_SLOT_START         0
enum EquipmentSlots
{
	EQUIPMENT_SLOT_HEAD = 0,
	EQUIPMENT_SLOT_NECK,
	EQUIPMENT_SLOT_SHOULDERS,
	EQUIPMENT_SLOT_BODY,
	EQUIPMENT_SLOT_CHEST,
	EQUIPMENT_SLOT_WAIST,
	EQUIPMENT_SLOT_LEGS,
	EQUIPMENT_SLOT_FEET,
	EQUIPMENT_SLOT_WRISTS,
	EQUIPMENT_SLOT_HANDS,
	EQUIPMENT_SLOT_FINGER1,	// 10
	EQUIPMENT_SLOT_FINGER2,
	EQUIPMENT_SLOT_TRINKET1,
	EQUIPMENT_SLOT_TRINKET2,
	EQUIPMENT_SLOT_BACK,
	EQUIPMENT_SLOT_MAINHAND,
	EQUIPMENT_SLOT_OFFHAND,
	EQUIPMENT_SLOT_RANGED,
	EQUIPMENT_SLOT_TABARD,
};
#define EQUIPMENT_SLOT_END           19

#define IS_BODY_SLOT(s) ((s) < EQUIPMENT_SLOT_END)
#define NOT_BODY_SLOT(s) ((s) >= EQUIPMENT_SLOT_END)

#define INVENTORY_SLOT_BAG_START     19
#define INVENTORY_SLOT_BAG_1         19
#define INVENTORY_SLOT_BAG_2         20
#define INVENTORY_SLOT_BAG_3         21
#define INVENTORY_SLOT_BAG_4         22
#define INVENTORY_SLOT_BAG_END       23

#define IS_BAG_SLOT(s) ((s) >= INVENTORY_SLOT_BAG_START && (s) < INVENTORY_SLOT_BAG_END)
#define IS_NOT_BAG_SLOT(s) ((s) < INVENTORY_SLOT_BAG_START && (s) >= INVENTORY_SLOT_BAG_END)

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

#define IS_BACKPACK_SLOT(s) ((s) >= INVENTORY_SLOT_ITEM_START && (s) < INVENTORY_SLOT_ITEM_END)

#define IS_BANK_SLOT(s) ((s) >= BANK_SLOT_ITEM_START && (s) < BANK_SLOT_ITEM_END)

#define BANK_SLOT_ITEM_START         39
#define BANK_SLOT_ITEM_1             39
#define BANK_SLOT_ITEM_2             40
#define BANK_SLOT_ITEM_3             41
#define BANK_SLOT_ITEM_4             42
#define BANK_SLOT_ITEM_5             43
#define BANK_SLOT_ITEM_6             44
#define BANK_SLOT_ITEM_7             45
#define BANK_SLOT_ITEM_8             46
#define BANK_SLOT_ITEM_9             47
#define BANK_SLOT_ITEM_10            48
#define BANK_SLOT_ITEM_11            49
#define BANK_SLOT_ITEM_12            50
#define BANK_SLOT_ITEM_13            51
#define BANK_SLOT_ITEM_14            52
#define BANK_SLOT_ITEM_15            53
#define BANK_SLOT_ITEM_16            54
#define BANK_SLOT_ITEM_17            55
#define BANK_SLOT_ITEM_18            56
#define BANK_SLOT_ITEM_19            57
#define BANK_SLOT_ITEM_20            58
#define BANK_SLOT_ITEM_21            59
#define BANK_SLOT_ITEM_22            60
#define BANK_SLOT_ITEM_23            61
#define BANK_SLOT_ITEM_24            62
#define BANK_SLOT_ITEM_END           63

#define IS_BANK_BAG_SLOT(s) ((s) >= BANK_SLOT_BAG_START && (s) < BANK_SLOT_BAG_END)

#define BANK_SLOT_BAG_START          63
#define BANK_SLOT_BAG_1              63
#define BANK_SLOT_BAG_2              64
#define BANK_SLOT_BAG_3              65
#define BANK_SLOT_BAG_4              66
#define BANK_SLOT_BAG_5              67
#define BANK_SLOT_BAG_6              68
#define BANK_SLOT_BAG_END            69

typedef hash_map<uint32, uint16> SpellMap;
typedef hash_map<uint32, uint32> SkillMap;

#define GOLD(c) ((c)*10000)
#define SILVER(c) ((c)*100)

enum PlayerFlags
{
	PLAYER_FLAG_GROUP_LEADER	= 0x01,
	PLAYER_FLAG_DEAD			= 0x10,
	PLAYER_FLAG_RESTING			= 0x20,
	PLAYER_FLAG_DUEL			= 0x80,
};

enum StandState
{
	STANDSTATE_STAND = 0,
	STANDSTATE_SIT = 1,
	STANDSTATE_SIT_CHAIR = 2,
	STANDSTATE_SLEEP = 3,
	STANDSTATE_SIT_LOW_CHAIR = 4,
	STANDSTATE_SIT_MEDIUM_CHAIR = 5,
	STANDSTATE_SIT_HIGH_CHAIR = 6,
	STANDSTATE_DEAD = 7,
	STANDSTATE_KNEEL = 8
};

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

    virtual void Update( int32 time );

    void BuildEnumData (WorldPacket * p_data);
	void HideFromPlayers();

    uint8 ToggleAFK() { m_afk = !m_afk; return m_afk; };
    const char* GetName() { return m_name.c_str(); };

    void KilledMonster(uint32 entry, uint64 guid);
	void AddedItemToBackpack(uint32 entry, uint32 count = 1);
	void RemovedItemToBackpack(uint32 entry);

    void GiveXP(uint32 xp, uint64 guid);
    //void Regenerate(uint16 field_cur, uint16 field_max, bool switch_);
	void Regenerate();

    // Taxi
    void setDismountTimer(uint32 time) { m_dismountTimer = time; };
    void setDismountCost(uint32 money) { m_dismountCost = money; };
    void setMountPos(float x, float y, float z) { m_mount_pos_x = x;
                                                  m_mount_pos_y = y;
                                                  m_mount_pos_z = z; }

	//-------------------------
	// Rogue Combo Points
	//-------------------------
	virtual uint8 GetComboPoints() {
		return uint8((GetUInt32Value(PLAYER_FIELD_BYTES) & 0xFF00) >> 8);
	}
	virtual void SetComboPoints (uint8 value) {
		SetUInt32Value (PLAYER_FIELD_BYTES, ((GetUInt32Value(PLAYER_FIELD_BYTES) & ~(0xFF << 8)) | (value << 8)));
	}

	//-------------------------
	// Positive and negative visible stats
	//-------------------------
	virtual int32 GetPosStrength() { return (int32)GetUInt32Value (PLAYER_FIELD_POSSTAT0); }
	virtual int32 GetPosAgility() { return (int32)GetUInt32Value (PLAYER_FIELD_POSSTAT1); }
	virtual int32 GetPosStamina() { return (int32)GetUInt32Value (PLAYER_FIELD_POSSTAT2); }
	virtual int32 GetPosIntellect() { return (int32)GetUInt32Value (PLAYER_FIELD_POSSTAT3); }
	virtual int32 GetPosSpirit() { return (int32)GetUInt32Value (PLAYER_FIELD_POSSTAT4); }

	virtual int32 GetNegStrength() { return (int32)GetUInt32Value (PLAYER_FIELD_NEGSTAT0); }
	virtual int32 GetNegAgility() { return (int32)GetUInt32Value (PLAYER_FIELD_NEGSTAT1); }
	virtual int32 GetNegStamina() { return (int32)GetUInt32Value (PLAYER_FIELD_NEGSTAT2); }
	virtual int32 GetNegIntellect() { return (int32)GetUInt32Value (PLAYER_FIELD_NEGSTAT3); }
	virtual int32 GetNegSpirit() { return (int32)GetUInt32Value (PLAYER_FIELD_NEGSTAT4); }

	virtual void SetPosStrength (int32 value) { 
		int32 d = value - GetPosStrength();
		SetUInt32Value (PLAYER_FIELD_POSSTAT0, value);
		OnModifyStrength (d); }
	virtual void SetPosAgility (int32 value) {
		int32 d = value - GetPosAgility();
		SetUInt32Value (PLAYER_FIELD_POSSTAT1, value);
		OnModifyAgility (d); }
	virtual void SetPosStamina (int32 value) {
		int32 d = value - GetPosStamina();
		SetUInt32Value (PLAYER_FIELD_POSSTAT2, value);
		OnModifyStamina (d); }
	virtual void SetPosIntellect (int32 value) {
		int32 d = value - GetPosIntellect();
		SetUInt32Value (PLAYER_FIELD_POSSTAT3, value); 
		OnModifyIntellect (d); }
	virtual void SetPosSpirit (int32 value) { SetUInt32Value (PLAYER_FIELD_POSSTAT4, value); }

	virtual void SetNegStrength (int32 value) {
		int32 d = value - GetNegStrength();
		SetUInt32Value (PLAYER_FIELD_NEGSTAT0, value);
		OnModifyStrength (d); }
	virtual void SetNegAgility (int32 value) {
		int32 d = value - GetNegAgility();
		SetUInt32Value (PLAYER_FIELD_NEGSTAT1, value);
		OnModifyAgility (d); }
	virtual void SetNegStamina (int32 value) {
		int32 d = value - GetNegStamina();
		SetUInt32Value (PLAYER_FIELD_NEGSTAT2, value);
		OnModifyStamina (d); }
	virtual void SetNegIntellect (int32 value) {
		int32 d = value - GetNegIntellect();
		SetUInt32Value (PLAYER_FIELD_NEGSTAT3, value);
		OnModifyIntellect (d); }
	virtual void SetNegSpirit (int32 value) { SetUInt32Value (PLAYER_FIELD_NEGSTAT4, value); }

	virtual void ModifyPosStrength (int32 d) { SetPosStrength (GetPosStrength() + d); }
	virtual void ModifyPosAgility (int32 d) { SetPosAgility (GetPosAgility() + d); }
	virtual void ModifyPosStamina (int32 d) { SetPosStamina (GetPosStamina() + d); }
	virtual void ModifyPosIntellect (int32 d) { SetPosIntellect (GetPosIntellect() + d); }
	virtual void ModifyPosSpirit (int32 d) { SetPosSpirit (GetPosSpirit() + d); }

	virtual void ModifyNegStrength (int32 d) { SetNegStrength (GetNegStrength() + d); }
	virtual void ModifyNegAgility (int32 d) { SetNegAgility (GetNegAgility() + d); }
	virtual void ModifyNegStamina (int32 d) { SetNegStamina (GetNegStamina() + d); }
	virtual void ModifyNegIntellect (int32 d) { SetNegIntellect (GetNegIntellect() + d); }
	virtual void ModifyNegSpirit (int32 d) { SetNegSpirit (GetNegSpirit() + d); }

	// Total calculating functions
	//
	/*virtual int32 GetStrength() { return GetBaseStrength() + GetPosStrength() - GetNegStrength(); }
	virtual int32 GetAgility() { return GetBaseAgility() + GetPosAgility() - GetNegAgility(); }
	virtual int32 GetStamina() { return GetBaseStamina() + GetPosStamina() - GetNegStamina(); }
	virtual int32 GetIntellect() { return GetBaseIntellect() + GetBaseIntellect() - GetNegIntellect(); }
	virtual int32 GetSpirit() { return GetBaseSpirit() + GetBaseSpirit() - GetNegSpirit(); }
	*/

	//-------------------------
    // Quests
	//-------------------------
    uint32 getQuestStatus(uint32 quest_id);
      bool getQuestRewardStatus(uint32 quest_id);
    uint32 addNewQuest(uint32 quest_id, uint32 status = QUEST_STATUS_AVAILABLE);
      void loadExistingQuest(struct quest_status qs);
      void setQuestStatus(uint32 quest_id, uint32 new_status, bool new_rewarded);
      bool checkQuestStatus(uint32 quest_id);
	  bool isQuestComplete(uint32 quest_id, Creature *pCreature);
	  bool isQuestTakable(uint32 quest_id);
	  quest_status getQuestStatusStruct(uint32 quest_id);

	  void finishExplorationQuest( Quest *pQuest );
	  void sendPreparedGossip( uint32 textid, QEmote em, uint64 guid);

    uint16 getOpenQuestSlot();
    uint16 getQuestSlot(uint32 quest_id);
    uint16 getQuestSlotById(uint32 slot_id);

	void SetPreviousGossipMenu( NPCGossipMenu *pMenu, int mMove );
	NPCGossipMenu *GetPreviousGossipMenu();
	int GetPreviousGossipMenuMove();


	uint32 GetTutorialInt(uint32 intId )
	{
		ASSERT( (intId < 8) );
		return m_Tutorials[intId];
	}

	void SetTutorialInt(uint32 intId, uint32 value)
	{
		ASSERT( (intId < 8) );
		m_Tutorials[intId] = value;
	}

	void AddMail(Mail *m);

    // sets the needed bits for any quests in the player's log
    //void setQuestLogBits(UpdateMask *updateMask);
    map<uint32, struct quest_status> getQuestStatusMap() { return mQuestStatus; };

	//-------------------------
	//  Selection 
	//-------------------------
    uint64 GetSelection() { return m_curSelection; }
	void SetSelection (uint64 guid) { m_curSelection = guid; }

	//-------------------------
	//  Mail and Auction Bids
	//-------------------------
	uint32 GetMailSize() { return m_mail.size();};
	Mail * GetMail (uint32 id);
	void RemoveMail (uint32 id);
	
	list<Mail*>::iterator GetmailBegin() { return m_mail.begin();};
	list<Mail*>::iterator GetmailEnd() { return m_mail.end();};
	
	void AddBid(bidentry *be);
	bidentry* GetBid(uint32 id);
	
	list<bidentry*>::iterator GetBidBegin() { return m_bids.begin();};
	list<bidentry*>::iterator GetBidEnd() { return m_bids.end();};

	//-------------------------------------------
	//  Combat Related (Overridden from Unit.h)
	//-------------------------------------------
	virtual void SetCritChance (float value) { SetFloatValue (PLAYER_CRIT_PERCENTAGE, m_critChance = value); }
	virtual void SetDodgeChance (float value) { SetFloatValue (PLAYER_DODGE_PERCENTAGE, m_dodgeChance = value); }
	virtual void SetParryChance (float value) { SetFloatValue (PLAYER_PARRY_PERCENTAGE, m_parryChance = value); }
	virtual void SetBlockChance (float value) { SetFloatValue (PLAYER_BLOCK_PERCENTAGE, m_blockChance = value); }
	virtual void SetRangedCritChance (float value) { SetFloatValue (PLAYER_RANGED_CRIT_PERCENTAGE, m_critRangedChance = value); }

	//virtual int32 GetCurrentMeleeSkill() { return GetLevel() * 5; }

	virtual void OnEnterCombat();
	virtual void OnExitCombat();

	virtual float CalculateDamageMods (float dmg)
	{
		return dmg * GetFloatValue (PLAYER_FIELD_MOD_DAMAGE_DONE_PCT) +
			GetUInt32Value (PLAYER_FIELD_MOD_DAMAGE_DONE_POS) -
			GetUInt32Value (PLAYER_FIELD_MOD_DAMAGE_DONE_NEG);
	}

	//---------------------
	// XP and Next Level XP
	//---------------------
	inline uint32 GetPlayerXP() { return GetUInt32Value (PLAYER_XP); }
	inline void ModifyPlayerXP (int32 d) { SetPlayerXP (GetPlayerXP() + d); }
	void SetPlayerXP (uint32 value) { SetUInt32Value (PLAYER_XP, value); }

	inline uint32 GetNextLevelXP() { return GetUInt32Value (PLAYER_NEXT_LEVEL_XP); }
	inline void ModifyNextLevelXP (int32 d) { SetNextLevelXP (GetNextLevelXP() + d); }
	void SetNextLevelXP (uint32 value) { SetUInt32Value (PLAYER_NEXT_LEVEL_XP, value); }

	inline uint32 GetRestStateXP() { return GetUInt32Value (PLAYER_REST_STATE_EXPERIENCE); }
	inline void ModifyRestStateXP (int32 d) { SetRestStateXP (GetRestStateXP() + d); }
	void SetRestStateXP (uint32 value) { SetUInt32Value (PLAYER_REST_STATE_EXPERIENCE, value); }

	//---------------
	//  Player Money
	//---------------
	inline uint32 GetMoney() { return GetUInt32Value (PLAYER_FIELD_COINAGE); }
	inline void ModifyMoney (int32 d) { SetMoney (GetMoney() + d); }
	void SetMoney (uint32 value) { SetUInt32Value (PLAYER_FIELD_COINAGE, value); }

	//---------------
	// Spells Stuff
	//---------------
	PreciseTime m_lastCastTime;

	bool HasSpell(uint32 spell)
	{
		return m_spells.find (spell) != m_spells.end();
	}
    void SendInitialSpells();
    bool AddSpell (uint32 spell_id, uint16 slot_id=0xffff);
	bool RemoveSpell (uint32 spell_id);
    //inline list<struct spells> getSpellList() { return m_spells; };
	SpellMap::iterator spellBegin() { return m_spells.begin(); }
	SpellMap::iterator spellEnd() { return m_spells.end(); }
	void setResurrect(uint64 guid,float X, float Y, float Z, uint32 health, uint32 mana) { 
        	m_resurrectGUID = guid;
	        m_resurrectX = X;
	        m_resurrectY = Y;
	        m_resurrectZ = Z;
	        m_resurrectHealth = health;
	        m_resurrectMana = mana;
	};

	//---------------
	// Skills Stuff
	//---------------
	bool HasSkill (uint32 skill_id)
	{
		return m_skills.find (skill_id) != m_skills.end();
	}
	uint16 GetSkill (uint32 skill_id)
	{
		SkillMap::iterator ii = m_skills.find (skill_id);
		if (ii != m_skills.end()) return uint16(ii->second);
		return 0;
	}
	uint16 GetMaxSkill (uint32 skill_id)
	{
		SkillMap::iterator ii = m_skills.find (skill_id);
		if (ii != m_skills.end()) return uint16(ii->second >> 16);
		return 0;
	}

	//---------------
	// To remove skill - set its value to 0
	virtual bool AddSkill (uint32 skill_id, uint16 skillLevel = 1, uint16 maxSkill = 0xFFFF);
	virtual bool RemoveSkill (uint32 skill_id);

	//---------------
    // Groups
	//---------------
    void SetInvited() { m_isInvited = true; }
    void SetInGroup() { m_isInGroup = true; }
    void SetLeader(uint64 guid) { m_groupLeader = guid; }

    int  IsInGroup() { return m_isInGroup; }
    int  IsInvited() { return m_isInvited; }
    uint64 GetGroupLeader() { return m_groupLeader; }

    void UnSetInvited() { m_isInvited = false; }
    void UnSetInGroup() { m_isInGroup = false; }

	//---------------------------
    //  Inventory operations
	//---------------------------
    bool SwapItemSlots(uint8 srcslot, uint8 dstslot);
    Item* GetItemBySlot(uint8 slot)
    {
    //    ASSERT(slot < BANK_SLOT_BAG_END);
        return m_items[slot];
    }

    Container* GetContainerBySlot(uint8 slot)
    {
        return (Container *)m_items[slot];
    }

    uint32 GetSlotByItemID (uint32 ID);
	uint32 GetSlotByItemGUID (uint64 guid);
    void AddItemToSlot (uint8 slot, Item *item);
	bool AddItemToSlot (uint8 slot, uint32 itemId, uint32 count = 1);
	void CreateObjectItem(uint32 itemId, uint8 playerslot, uint8 count);
    Item* RemoveItemFromSlot (uint8 slot);
    uint8 FindFreeItemSlot (uint32 type);

	bool AddItemToBackpack (uint32 itemId, uint32 count = 1);
	bool RemoveItemFromBackpack (uint32 itemId, uint32 count = 1);
	bool HasItemInBackpack (uint32 itemId, uint32 count = 1);
	bool HasSpaceForItemInBackpack (uint32 itemId, uint32 count = 1);

	//----------------------------
	// Items - Equipment control
	//----------------------------
	bool CheckSlotSuitable (uint8 slot, uint32 type);
	bool CanEquipItem (ItemPrototype * proto);
	bool CanUseItem (ItemPrototype * proto);

	//----------------------
    //  Looting Support
	//----------------------
    uint64 GetLootGUID() { return m_lootGuid; }
    void SetLootGUID(uint64 guid) { m_lootGuid = guid; }

	//----------------
    WorldSession* GetSession() { return m_session; }
    void SetSession(WorldSession *s) { m_session = s; }

    void CreateYourself( );
    void DestroyYourself( );

    // These functions build a specific type of A9 packet
    void BuildCreateUpdateBlockForPlayer( UpdateData *data, Player *target );
    void DestroyForPlayer( Player *target );

    // Serialize character to db
    void SaveToDB();
    void LoadFromDB(uint32 guid);
    void DeleteFromDB();

	//-----------------------------------
    // Death Stuff
	//-----------------------------------
	void SpawnCorpseBody();
    void SpawnCorpseBones();
    void CreateCorpse();
    void KillPlayer();
    void ResurrectPlayer();
    void BuildPlayerRepop();
    void DeathDurabilityLoss(double percent);
    void RepopAtGraveyard();
	
	// Timer used to avoid too often autoclicking gossip when dead player
	// walking around Spirit Healer
	uint32 m_autoGossipTimer;

	//-----------------------------------
    // Movement stuff
	//-----------------------------------
    void SetMovement(uint8 pType);
    void SetPlayerSpeed(uint8 SpeedType, float value, bool forced=false);

	virtual void ModifySpeedMod (float scale) { SetSpeedMod (GetSpeedMod() * scale); }
	virtual void SetSpeedMod (float value);

	void TeleportNear (float x, float y, float z);
	void TeleportFar (uint32 mapId, float x, float y, float z);

	//Channel stuff
	void JoinedChannel(Channel *c);
	void LeftChannel(Channel *c);
	void CleanupChannels();

	inline void SetStandState (StandState standstate) {
		uint32 bytes1 = GetUInt32Value (UNIT_FIELD_BYTES_1);
		SetUInt32Value (UNIT_FIELD_BYTES_1, (bytes1 & ~0xFF) | uint8(standstate));
	}
	inline void SetStandState (uint8 standstate) { SetStandState (StandState (standstate)); }

	inline StandState GetStandState() {
		uint32 bytes1 = GetUInt32Value (UNIT_FIELD_BYTES_1);
		return StandState (uint8 (bytes1));
	}

	bool	m_gmInvisible;

	// Fall damage detection
	uint32	m_falldetect_time;
	float	m_falldetect_z;
	float	m_falldetect_speed;

	// Some movement and speed tracking data
	//
	float	m_motionTrackX;
	float	m_motionTrackY;
	float	m_motionTrackZ;

	void motiontrack_ReadPosition() {
		m_motionTrackX = GetPositionX();
		m_motionTrackY = GetPositionY();
		m_motionTrackZ = GetPositionZ();
	}

	// Bind point
	//
	float	m_bindPointX;
	float	m_bindPointY;
	float	m_bindPointZ;
	uint32	m_bindPointMap;
	uint32	m_bindPointArea;

	int32 m_PVP_timer;			//Player PVP timer

	friend class WorldSession;

	void SetLevel (uint32 value); // Player dedicated SetLevel (belongs to Unit)

	// Actions buttons
	uint32 m_actionsButtons[120];
	// Rest time (time when Char called Logoff)
	uint32 m_timeLogoff;
	uint8 m_isRested;
	NPCGossipMenu *_GossipMenu;
	NPCQuestMenu  *_QuestMenu;
	
	// Returns ActionButtonID for given Item ID
	uint32 GetActionButtonID (uint32 itemid) {
		for (int i = 0; i < 120; i++)
			if (m_actionsButtons[i] == (itemid + 0x80000000)) {return i;}
		return 0;
	}

	//Explore Area System
	void CheckExploreSystem(void);
	// Initialize the possible areas that player will discover.
    void InitExploreSystem(void);

	// Group
	bool IsGroupMember(Player *plyr);
	// Sheath
	void ModifySheath (uint32 sheath_type);
	// PVP Status
	bool pvp_status;


protected:
    void _SetCreateBits(UpdateMask *updateMask, Player *target);
    void _SetUpdateBits(UpdateMask *updateMask, Player *target);
    void _SetVisibleBits(UpdateMask *updateMask, Player *target);

	void _SaveMail();
	void _LoadMail();
    void _SaveInventory();
    void _SaveSpells();
    void _SaveQuestStatus();
	void _SaveBindpoint();
    void _SaveTutorials();
    void _SaveAffects();
    void _SaveActionButtons();
	void _SaveBids();
    void _SaveHonorStatus();

	void _LoadBids();
	void _SaveAuctions();
    void _LoadInventory();
    void _LoadSpells();
    void _LoadQuestStatus();
    void _LoadHonorStatus();
	void _LoadTutorials();
	void _LoadBindpoint();
    void _LoadAffects();
    void _LoadActionButtons();

	void _RecalculatePlayerStats();
	void _ApplyItemMods(Item *item, bool apply);
    void _RemoveAllItemMods();
    void _ApplyAllItemMods();

	NPCGossipMenu *m_Menu;
	int m_Menu_Move;

    uint64 m_lootGuid;

    string m_name;    // max 21 character name
    uint8 m_outfitId;

    uint16 m_guildId;
    uint16 m_petInfoId; // pet display info id
    uint16 m_petLevel;  // pet experience level
    uint16 m_petFamilyId; // pet creature family id

    int32 m_regenTimer;			// How often we regen player powers
	int32 m_checkAggroTimer;	// How often we check mobs around to aggro
    uint32 m_dismountTimer;
    uint32 m_dismountCost;

	uint32 m_timedQuest;

    float m_mount_pos_x;
    float m_mount_pos_y;
    float m_mount_pos_z;

	uint32 m_Tutorials[8];
    // Inventory and equipment
    Item* m_items[BANK_SLOT_BAG_END];

    // AFK status
    uint8 m_afk;

    // guid of current target
    //uint64 m_curTarget;

    // guid of current selection
    uint64 m_curSelection;

    // current quest statuses
    typedef map<uint32, struct quest_status> StatusMap;
    StatusMap mQuestStatus;

    // Group
    uint64 m_groupLeader;
    bool m_isInGroup;
    bool m_isInvited;

	// items the player has bid on
	list<bidentry*> m_bids;

	// pieces of mail the player has
	list<Mail*> m_mail;

    // Player Spells - dictionary key SpellID, value SlotId
    SpellMap m_spells;

	// Player Skills - dictionary key SkillID, value SkillLevel
	SkillMap m_skills;

	// vars for ressurection
    uint64 m_resurrectGUID;
    float m_resurrectX, m_resurrectY, m_resurrectZ;
    uint32 m_resurrectHealth, m_resurrectMana;

    // Pointer to this char's game client
    WorldSession *m_session;

	// Channels
	list<Channel*> m_channels;

	Item *m_vendorBuybackSlot;
	Item *GetVendorBuybackSlot() { return m_vendorBuybackSlot; }
	void SetVendorBuybackSlot (Item *i, uint64 npcGuid);

	// Scan player's current cell for nearby aggressive mobs that
	// may wish to hate player
	void CheckAggressiveMobsAround ();

	// Exploration System
	list<struct Areas> areas;

	PreciseTime	m_lastCombatError;
};

#endif

