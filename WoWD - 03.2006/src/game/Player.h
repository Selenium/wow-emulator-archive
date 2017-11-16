// Copyright (C) 2004 WoWD Team

#ifndef _PLAYER_H
#define _PLAYER_H

#include "ItemPrototype.h"
#include "Unit.h"
#include "Database/DatabaseEnv.h"
#include "Creature.h"
#include "Trade.h"

struct Mail;
class Channel;
class Creature;

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

enum Races
{
    RACE_HUMAN = 1,
    RACE_ORC = 2,
    RACE_DWARF = 3,
    RACE_NIGHTELF = 4,
    RACE_UNDEAD = 5,
    RACE_TAUREN = 6,
    RACE_GNOME = 7,
    RACE_TROLL = 8,
};

enum PlayerStatus
{
	NONE			 = 0,
	TRANSFER_PENDING = 1,
};

struct spells{
    uint16 spellId;
    uint16 slotId;
};
struct affloads{
	uint16 id;
	uint32 dur;
};

struct actions
{
	uint8 button;
	uint8 type;
	uint8 misc;
	uint16 action;
};

struct PvPArea {
	uint32 AreaId;
	std::string AreaName;
	uint16 PvPType;
};

enum PvPAreaStatus
{
	AREA_ALLIANCE = 1,
	AREA_HORDE = 2,
	AREA_CONTESTED = 3,
	AREA_PVPARENA = 4,
};

struct skilllines {
	uint32 lineId;
	uint16 currVal;
	uint16 maxVal;
	uint16 posStatCurrVal;
	uint16 posstatMaxVal;
	uint32 place;
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

enum Standing
{
    STANDING_HATED,
    STANDING_HOSTILE,
    STANDING_UNFRIENDLY,
    STANDING_NEUTRAL,
    STANDING_FRIENDLY,
    STANDING_HONORED,
    STANDING_REVERED,
    STANDING_EXALTED
};

enum PlayerFlags
{
	PLAYER_FLAG_PARTY_LEADER			= 0x01,
	PLAYER_FLAG_AFK						= 0x04,
	PLAYER_FLAG_AFK_2					= 0x08,
	PLAYER_FLAG_DEATH_WORLD_ENABLE		= 0x10,
	PLAYER_FLAG_RESTING					= 0x20,
	PLAYER_FLAG_FREE_FOR_ALL_PVP		= 0x80,
	PLAYER_FLAG_PVP_TOGGLE				= 0x200,
	PLAYER_FLAG_NEED_REST_3_HOURS       = 0x1000,
	PLAYER_FLAG_NEED_REST_5_HOURS       = 0x2000,
};

struct Reputation
{
    uint8 id;
    uint32 factionId;
    int32 standing;
    uint8 flag;
};

struct Faction
{
    uint8 race;
    uint8 id;
    uint8 state;
    uint32 standing;
};

//DK: FriendList
struct FriendStr
{
    uint64 PlayerGUID;
    unsigned char Status;

    uint32 Area;
    uint32 Level;
    uint32 Class;
};

struct Charter
{
    uint32 charterId;
};

struct PlayerInfo
{
    uint64 guid;
    std::string name;
    uint32 race;
    uint32 gender;
    uint32 cl;
};

class Quest;
class Spell;
class Item;
class Container;
class WorldSession;

#define RESTSTATE_RESTED			 1
#define RESTSTATE_NORMAL			 2
#define RESTSTATE_TIRED100			 3
#define RESTSTATE_TIRED50			 4
#define RESTSTATE_EXHAUSTED			 5

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

#define BANK_SLOT_ITEM_START	     39
#define BANK_SLOT_ITEM_1		     39
#define BANK_SLOT_ITEM_2		     40
#define BANK_SLOT_ITEM_3		     41
#define BANK_SLOT_ITEM_4		     42
#define BANK_SLOT_ITEM_5		     43
#define BANK_SLOT_ITEM_6		     44
#define BANK_SLOT_ITEM_7		     45
#define BANK_SLOT_ITEM_8		     46
#define BANK_SLOT_ITEM_9		     47
#define BANK_SLOT_ITEM_10		     48
#define BANK_SLOT_ITEM_11		     49
#define BANK_SLOT_ITEM_12		     50
#define BANK_SLOT_ITEM_13		     51
#define BANK_SLOT_ITEM_14		     52
#define BANK_SLOT_ITEM_15		     53
#define BANK_SLOT_ITEM_16		     54
#define BANK_SLOT_ITEM_17		     55
#define BANK_SLOT_ITEM_18		     56
#define BANK_SLOT_ITEM_19		     57
#define BANK_SLOT_ITEM_20		     58
#define BANK_SLOT_ITEM_21		     59
#define BANK_SLOT_ITEM_22		     60
#define BANK_SLOT_ITEM_23		     61
#define BANK_SLOT_ITEM_24		     62
#define BANK_SLOT_ITEM_END		     63

#define BANK_SLOT_BAG_START		     63
#define BANK_SLOT_BAG_1			     63
#define BANK_SLOT_BAG_2			     64
#define BANK_SLOT_BAG_3			     65
#define BANK_SLOT_BAG_4			     66
#define BANK_SLOT_BAG_5			     67
#define BANK_SLOT_BAG_6			     68
#define BANK_SLOT_BAG_END		     69

#define INVENTORY_NO_SLOT_AVAILABLE  BANK_SLOT_BAG_END
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
    //void KilledMonster(uint32 entry, const uint64 &guid);
    void GiveXP(uint32 xp, const uint64 &guid);

    // Taxi
    void setDismountTimer(uint32 time) { m_dismountTimer = time; };
    void setDismountCost(uint32 money) { m_dismountCost = money; };
    void setMountPos(float x, float y, float z) { m_mount_pos_x = x;
                                                  m_mount_pos_y = y;
                                                  m_mount_pos_z = z; }

    //QuestLog stuff
    void Add_QLE(QuestLogEntry* quest_entry);
	void Del_QLE(uint32 quest_entry);
	QuestLogEntry* Find_QLE(uint32 quest_entry);
    
    //Quest stuff
    map<uint32, QuestLogEntry *>::iterator QuestsBegin() { return m_questentry.begin(); };
    map<uint32, QuestLogEntry *>::iterator QuestsEnd() { return m_questentry.end(); };
	bool HasQuests() 
	{
		if(m_questentry.size() > 0)
			return true;
		return false;
	}
	uint16 GetOpenQuestSlot();
    uint16 GetQuestSlotForEntry(uint32 quest_entry);
    uint32 GetQuestEntryInSlot(uint8 slot);
	void ResetQuestSlots();
    void AddToFinishedQuests(uint32 quest_id);
    bool HasFinishedQuest(uint32 quest_id);

	void AddMail(Mail *m);

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
    void setResurrect(uint64 guid,float X, float Y, float Z, uint32 health, uint32 mana) { 
        m_resurrectGUID = guid;
        m_resurrectX = X;
        m_resurrectY = Y;
        m_resurrectZ = Z;
        m_resurrectHealth = health;
        m_resurrectMana = mana;
    };

	//action bar
	inline std::list<struct actions> getActionList() { return m_actions; };
	void addAction(uint8 button, uint16 action, uint8 type, uint8 misc);
	void addLoadAff(uint16 id, uint32 dur);
	std::list<struct affloads>::iterator GetaffBegin() { return m_affloads.begin();};
	std::list<struct affloads>::iterator GetaffEnd() { return m_affloads.end();};

	void removeAction(uint8 button);
	void smsg_InitialActions();

    // factions
    void smsg_InitialFactions();
    void modReputation(uint8 id, int32 mod);
    uint8 GetStandingById(uint8 id);
    uint8 GetStandingByFactionTemplate(uint32 fctTmp);
    void SetFactionState(uint8 id, uint8 state);

    // groups
    void SetInvited() { m_isInvited = true; }
    void SetInGroup() { m_isInGroup = true; }
    void SetLeader(const uint64 &guid) { m_groupLeader = guid; }

    int  IsInGroup() { return m_isInGroup; }
    int  IsInvited() { return m_isInvited; }
    
    const uint64& GetGroupLeader() const { return m_groupLeader; }

    void UnSetInvited() { m_isInvited = false; }
    void UnSetInGroup() { m_isInGroup = false; }

    // DK isGroupMember(plyr)
    bool IsGroupMember(Player *plyr);

    // Raid
    uint8 GetRaidSubGroup() { return m_raidSubGroup; }
    void SetRaidSubGroup(uint8 subGroup) { m_raidSubGroup = subGroup; }

    //DK ban
    void SetBanned() { m_banned = 4; }
    void UnSetBanned() { m_banned = 0; }
    bool IsBanned()
    {
        if(m_banned > 0)
            return true;
        return false;
    }

    //DK:Guild
    bool IsInGuild()
    {
        if(m_guildId > 0)
            return true;
        return false;
    }
    uint32 GetGuildId() { return m_guildId; }
    void SetGuildId(uint32 guildId) { m_guildId = guildId; }
    uint32 GetGuildRank() { return m_guildRank; }
    void SetGuildRank(uint32 guildRank) { m_guildRank = guildRank; }
    uint64 GetGuildInvitersGuid() { return m_invitersGuid; }
    void SetGuildInvitersGuid( uint64 guid ) { m_invitersGuid = guid; }
    void UnSetGuildInvitersGuid() { m_invitersGuid = 0; }
    bool GetCharterSignStatus() { return m_signedCharter; }
    void SetCharterSigned() { m_signedCharter = true; };
    void UnSetCharterSigned() { m_signedCharter =  false; };
    void AddSignedCharter(uint32 charterId);
    void DeleteSignedCharter(uint32 charterId);    
    void DeleteFromSignedCharters(uint32 charterId);
    void DeleteAllCharterData();

	//Duel
	Player* DuelingWith;
	void StartDuelTimer(uint32 newTime) { m_duelTimer = newTime; }
	void SetDuelStatus(uint8 status) { m_duelStatus = status; }
	uint8 GetDuelStatus() { return m_duelStatus; }
	void SetDuelState(uint8 state) { m_duelState = state; }
	uint8 GetDuelState() { return m_duelState; }

	//PVP
	void UpdatePVPStatus(uint32 AreaID);
	void EventStopPvP();
	void PvPTimeoutUpdate(bool Remove);
	bool PvPTimeoutEnabled;

	//DK:Trade
	void AddTradeItem(TradeItem *ti);
	void DelTradeItem(uint8 slot);
	void DelAllTradeItems()	{ m_tradeitems.clear(); }
	TradeItem* GetTradeItem(uint8 slot);
	uint8 GetTradeItemsCount() { return m_tradeitems.size();};
	void SetTradeStatus(uint16 status) { m_tradeStatus = status; }
	uint16 GetTradeStatus() { return m_tradeStatus; }
	void SetTradeGold(uint32 gold) { m_tradeGold = gold; }
    uint32 GetTradeGold() { return m_tradeGold; }
    void SetTradeSeqNum(uint16 num) { m_tradeSeqNum = num; }
    uint16 GetTradeSeqNum() { return m_tradeSeqNum; }
	Player* TradingWith;

    //DK FriendList
    void SendFriendListData();
    void AddFriend(struct FriendStr fList) { m_friendList.push_back(fList); }
    void DeleteFriend(uint64 FriendGuid);

    //Pet
    void SetPet(Creature *pet) { m_pet = pet; }
    Creature* GetPet() { return m_pet; }
    void SetPetXp(uint32 xp) { m_petXp = xp; }
    uint32 GetPetXp() { return m_petXp; }
    void SetPetLevel(uint16 level) { m_petLevel = level; }
    uint16 GetPetLevel() { return m_petLevel; }
    void SetPetDisplayId(uint16 dispId) { m_petDisplayId = dispId; }
    uint16 GetPetDisplayId() { return m_petDisplayId; }
    void SetPetFamily(uint16 family) { m_petFamilyId = family; }
    uint16 GetPetFamily() { return m_petFamilyId; }
	void SetPetName(std::string name) { m_petName = name; }
	std::string GetPetName() { return m_petName; }

    // Items
	void EmptyBuyBack();
    void SwapItemSlots(uint8 srcslot, uint8 dstslot);
    Item* GetItemBySlot(uint8 slot) const
    {
		if (slot == 255)
			return NULL;
		/* ASSERT(slot < INVENTORY_SLOT_ITEM_END); */
        ASSERT(slot < BANK_SLOT_BAG_END); /* Bank Support */
        return m_items[slot];
    }
	Item* GetBuyBack(uint32 id) { return buyback[id];}
	Item* FindItemLessMax(uint32 id, uint32 cnt);
	void AddBuyBackItem(Item* it, uint32 price);
	void RemoveBuyBackItem(uint32 index);
	uint32 GetItemCount(uint32 id);
	bool RemoveItemAmt(uint32 id, uint32 amt);
    uint32 GetSlotByItemID(uint32 ID);
	uint32 GetSlotByItemGUID(uint64 guid);
    void AddItemToSlot(uint8 slot, Item *item);
	void AddItemToFreeSlot(Item *item);
	Item* RemoveItemFromSlot(uint8 slot) { return RemoveItemFromSlot(slot, true); }
    Item* RemoveItemFromSlot(uint8 slot, bool DestroyForPlayer);
	uint32 NumFreeSlots(){ return GetItemCount(0); };
    uint8 FindFreeInvSlot();
	uint8 FindFreeBagSlot(uint8 BagSlot);
	Item* GetItemByGUID(uint64 itemGuid, bool Remove) { return GetItemByGUID(itemGuid,Remove,true); }
	Item* GetItemByGUID(uint64 itemGuid, bool Remove, bool DestoryForPlayer);
	Item* GetItemByLocation(uint8 bag, uint8 slot, bool Remove);
	uint8 FindBagWithFreeSlots();
    uint8 CanEquipItemInSlot(uint8 slot, ItemPrototype* item);
	uint8 GetItemSlotByType(uint32 type);
	void BuildInventoryChangeError(Item *SrcItem, Item *DstItem, uint8 Error);

    // looting
    const uint64& GetLootGUID() const { return m_lootGuid; }
    void SetLootGUID(const uint64 &guid) { m_lootGuid = guid; }

    WorldSession* GetSession() const { return m_session; }
    void SetSession(WorldSession *s) { m_session = s; }
	void SetBindPoint(float x, float y, float z, uint32 m, uint32 v) { m_bind_pos_x = x; m_bind_pos_y = y; m_bind_pos_z = z; m_bind_mapid = m; m_bind_zoneid = v;}

    void CreateYourself( );
    void DestroyYourself( );

	// talents
	float GetSpellTimeMod(uint32 id);
	int GetSpellDamageMod(uint32 id);
	int GetSpellManaMod(uint32 id);
	void AddTalent(uint32 id) { m_talents.push_back(id);}
	bool isTalent(uint32 id);

    // These functions build a specific type of A9 packet
    void BuildCreateUpdateBlockForPlayer( UpdateData *data, Player *target ) const;
    void DestroyForPlayer( Player *target ) const;

    // Serialize character to db
    void SaveToDB();
    void LoadFromDB(uint32 guid);
    void LoadPropertiesFromDB();
    void LoadEnumFromDB();
    void LoadNamesFromDB(uint32 guid);
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
    uint8 m_currentMovement;

	//Channel stuff
	void JoinedChannel(Channel *c);
	void LeftChannel(Channel *c);
	void CleanupChannels();

    //Attack stuff
    void EventAttackStart();
    void EventAttackStop();
    void EventAttackUpdateSpeed() { }
    
    void EventDeath();

	// skilllines
	bool HasSkillLine(uint32 id);
	void AddSkillLine(uint32 id, uint16 currVal, uint16 maxVal);
	void AddSkillLine(uint32 id, uint16 currVal, uint16 maxVal, bool sendUpdate);
	void ModSkillLine(uint32 id, uint32 amt);
	void ModSkillMax(uint32 id, uint32 amt);
	float GetSkillUpChance(uint32 id);
	uint32 GetSkillAmt(uint32 id);
	uint32 GetSkillPlace(uint32 id);
	uint32 GetSkillMax(uint32 id);
	void RemoveSkillLine(uint32 id);
	inline std::list<struct skilllines>getSkillLines() { return m_skilllines; }

	void SetPlayerStatus(uint8 pStatus) { m_status = pStatus; }
	uint8 GetPlayerStatus() { return m_status; }

    const float& GetBindPositionX( ) const { return m_bind_pos_x; }
    const float& GetBindPositionY( ) const { return m_bind_pos_y; }
    const float& GetBindPositionZ( ) const { return m_bind_pos_z; }
	const uint32& GetBindMapId( ) const { return m_bind_mapid; }
	const uint32& GetBindZoneId( ) const { return m_bind_zoneid; }

	uint32 GetEating() { return eating;}
	void SetEating(uint32 spell) { eating = spell;}
    //Showing Units WayPoints
    AIInterface* waypointunit;

	// Object Map place
	void PlaceItemsOnMap();

    void SaveGuild();
    void SaveCharters();

	//Tutorials
	uint32 GetTutorialInt(uint32 intId );
	void SetTutorialInt(uint32 intId, uint32 value);

	//Base stats calculations
	void CalcBaseStats();

	// Rest
	void EnterInn();
	void AddRestXP(uint32 amount);
	void SubtractRestXP(uint32 amount);
	uint32 CalculateRestXP(uint32 seconds);
	void ExitInn();
	uint32 m_lastRestUpdate;
	void EventPlayerRest();
	void EventPlayerRestStart();
	void UpdateRestState();

	// Underwater Breathing
	uint8 m_BreathingAir;
	uint16 m_Breath;
	float m_StartSwimHeight;
	void EventBreathReduce();
	uint32 m_LastHeartbeat;
	void EventBreathRegen();

protected:
    void _SetCreateBits(UpdateMask *updateMask, Player *target) const;
    void _SetUpdateBits(UpdateMask *updateMask, Player *target) const;
    void _SetVisibleBits(UpdateMask *updateMask, Player *target) const;

	void  _LoadTutorials();
	void  _SaveTutorials();
	void _SaveMail();
	void _LoadMail();
    void _SaveInventory();
	void _LoadBagInventory(uint32 playerguid, uint8 bagslot);
    void _SaveSpells();
	void _SaveActions();
    void _SaveQuestLogEntry();
    void _LoadQuestLogEntry();
    void _SaveAffects();
	void _SaveBids();
	void _LoadBids();
	void _SaveAuctions();
    void _LoadInventory();
    void _LoadSpells();
	void _LoadActions();
    void _LoadAffects();
    void _SaveFinishedQuests();
    void _LoadFinishedQuests();
    void _SaveReputation();
    void _LoadReputation();
    // DK
    void _LoadGuild();
    void _LoadCharters();
    void _LoadFriendList();
    void _SaveFriendList();
    void _LoadPet();
    void _SavePet();

    void _ApplyItemMods(Item *item,uint8 slot,bool apply);
    void _RemoveAllItemMods();
    void _ApplyAllItemMods();

    void _EventAttack();
    void _EventExploration();

    uint32 m_lastAttackTime;

    uint64 m_lootGuid;

	uint32 eating;

    std::string m_name;    // max 21 character name
    uint8 m_outfitId;

	uint32 m_Tutorials[8];

    // Guild
    uint32 m_guildId;
    uint32 m_guildRank;
	uint32 m_guildLastOnline;
    uint64 m_invitersGuid; // It is guild inviters guid ,0 when its not used
    bool m_signedCharter;
	std::list<Charter*> m_charterList;
 
    // Character Ban
    uint32 m_banned;

    // Pet
    uint16 m_petDisplayId; // pet display info id
    uint16 m_petLevel;  // pet experience level
    uint16 m_petFamilyId; // pet creature family id
    uint32 m_petXp; // pet experience
	std::string m_petName;
    Creature *m_pet;

    uint32 m_dismountTimer;
    uint32 m_dismountCost;
	float m_mount_pos_x;
    float m_mount_pos_y;
    float m_mount_pos_z;

	float m_bind_pos_x;
    float m_bind_pos_y;
    float m_bind_pos_z;
	uint32 m_bind_mapid;
	uint32 m_bind_zoneid;

	uint32 m_nextSave;

    // Inventory and equipment
    Item* m_items[BANK_SLOT_BAG_END];
	Item* buyback[12];

	// DK:Trade
	uint16 m_tradeStatus;
	uint32 m_tradeGold;
    uint16 m_tradeSeqNum;

	//Duel
	uint32 m_duelTimer;
	uint8 m_duelStatus;
	uint8 m_duelState;

    // AFK status
    uint8 m_afk;
    // Rested State Stuff
    uint32 m_timeLogoff;
	//uint32 m_timeLogin;
	uint8 m_isResting;
	uint8 m_restState;
	uint32 m_restAmount;
	
    // STATUS
	uint8 m_status;

    // guid of current target
    uint64 m_curTarget;

    // guid of current selection
    uint64 m_curSelection;

	//Quests
	std::map<uint32, QuestLogEntry *> m_questentry;
    std::set<uint32> m_finishedQuests;

    // Group
    uint64 m_groupLeader;
    bool m_isInGroup;
    bool m_isInvited;

    // Raid
    uint8 m_raidSubGroup;
	
	std::list<struct affloads> m_affloads;
	std::list<uint32> m_talents;
	// items the player has bid on
	std::list<bidentry*> m_bids;

	// pieces of mail the player has
	std::list<Mail*> m_mail;

    // Player Spells
    std::list<struct spells> m_spells;

	//Player Action Bar
	std::list<struct actions> m_actions;

	//Player Trading Items
	std::list<TradeItem*> m_tradeitems;

	// Player Skilllines
	std::list<struct skilllines> m_skilllines;

    // Player Reputation
    std::list<struct Reputation> m_reputation;

    // Player FriendList
    std::list<struct FriendStr> m_friendList;

    // vars for ressurection
    uint64 m_resurrectGUID;
    float m_resurrectX, m_resurrectY, m_resurrectZ;
    uint32 m_resurrectHealth, m_resurrectMana;

    // Pointer to this char's game client
    WorldSession *m_session;

	// Channels
	std::list<Channel*> m_channels;
};

#endif

