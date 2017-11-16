#pragma once
// Copyright (C) 2004 WoWD Team

#ifndef __SPELL_H
#define __SPELL_H


class WorldSession;
class Unit;
class DynamicObj;
class Player;
class Item;
class Group;
class Affect;

enum SpellCastTargetFlags
{
    TARGET_FLAG_SELF             = 0x0, // they are checked in following order
    TARGET_FLAG_UNIT             = 0x0002,
    TARGET_FLAG_OBJECT           = 0x0800,
    TARGET_FLAG_ITEM             = 0x1010,
    TARGET_FLAG_SOURCE_LOCATION  = 0x20,
    TARGET_FLAG_DEST_LOCATION    = 0x40,
    TARGET_FLAG_STRING           = 0x2000
};

enum SpellCastFlags
{
    CAST_FLAG_UNKNOWN1           = 0x2,
    CAST_FLAG_UNKNOWN2           = 0x10, // no idea yet, i saw it in blizzard spell
    CAST_FLAG_AMMO               = 0x20 // load ammo display id (uint32) and ammo inventory type (uint32)
};

class SpellCastTargets
{
public:
    void read ( WorldPacket * data,uint64 caster );
    void write ( WorldPacket * data);

    SpellCastTargets& operator=(const SpellCastTargets &target)
    {
        m_unitTarget = target.m_unitTarget;
        m_itemTarget = target.m_itemTarget;

        m_srcX = target.m_srcX;
        m_srcY = target.m_srcY;
        m_srcZ = target.m_srcZ;

        m_destX = target.m_destX;
        m_destY = target.m_destY;
        m_destZ = target.m_destZ;

        m_strTarget = target.m_strTarget;

        m_targetMask = target.m_targetMask;


        return *this;
    }

    uint64 m_unitTarget;
    uint64 m_itemTarget;
    float m_srcX, m_srcY, m_srcZ;
    float m_destX, m_destY, m_destZ;
    std::string m_strTarget;

    uint16 m_targetMask;
};

enum SpellState
{
    SPELL_STATE_NULL      = 0,
    SPELL_STATE_PREPARING = 1,
    SPELL_STATE_CASTING   = 2,
    SPELL_STATE_FINISHED  = 3,
    SPELL_STATE_IDLE      = 4
};

enum ShapeshiftForm
{
    FORM_CAT              = 1,
    FORM_TREE             = 2,
    FORM_TRAVEL           = 3,
    FORM_AQUA             = 4,
    FORM_BEAR             = 5,
    FORM_AMBIENT          = 6,
    FORM_GHOUL            = 7,
    FORM_DIREBEAR         = 8,
    FORM_CREATUREBEAR     = 14,
    FORM_GHOSTWOLF        = 16,
    FORM_BATTLESTANCE     = 17,
    FORM_DEFENSIVESTANCE  = 18,
    FORM_BERSERKERSTANCE  = 19,
    FORM_SHADOW           = 28,
    FORM_STEALTH          = 30
};

// Strongly uncertain about these constants and their value, but a few
// marked values are testet and should work
enum CAST_FAILED
{
	CAST_FAIL_ALREADY_FULL_HEALTH = 1,
	CAST_FAIL_ALREADY_FULL_MANA = 2,
	//CAST_FAIL_ALREADY_FULL_RAGE = 2,
	CAST_FAIL_CREATURE_ALREADY_TAMING = 3,
	CAST_FAIL_ALREADY_HAVE_CHARMED = 4,
	CAST_FAIL_ALREADY_HAVE_SUMMON = 5, 
	CAST_FAIL_ALREADY_OPEN = 6,
	CAST_FAIL_MORE_POWERFUL_SPELL_ACTIVE = 7,
	CAST_FAIL_NO_TARGET = 9,
	CAST_FAIL_INVALID_TARGET = 10,
	CAST_FAIL_CANT_BE_CHARMED = 11,
	CAST_FAIL_CANT_BE_DISENCHANTED = 12,
	CAST_FAIL_TARGET_IS_TAPPED = 13,
	CAST_FAIL_CANT_START_DUEL_INVISIBLE = 14,
	CAST_FAIL_CANT_START_DUEL_STEALTHED = 15,
	CAST_FAIL_TOO_CLOSE_TO_ENEMY = 16,
	CAST_FAIL_CANT_DO_THAT_YET = 17,
	CAST_FAIL_YOU_ARE_DEAD = 18,
	CAST_FAIL_OBJECT_ALREADY_BEING_USED = 19,
	CAST_FAIL_CANT_DO_WHILE_CONFUSED = 20,
	CAST_FAIL_MUST_HAVE_ITEM_EQUIPPED = 22,
	CAST_FAIL_MUST_HAVE_XXXX_EQUIPPED = 23,
	CAST_FAIL_MUST_HAVE_XXXX_IN_MAINHAND = 24,
	CAST_FAIL_INTERNAL_ERROR = 25,
	CAST_FAIL_FIZZLED = 26,
	CAST_FAIL_YOU_ARE_FLEEING = 27,
	CAST_FAIL_FOOD_TOO_LOWLEVEL_FOR_PET = 28,
	CAST_FAIL_TARGET_IS_TOO_HIGH = 29,
	CAST_FAIL_IMMUNE = 32,			// was 31 in pre 1.7
	CAST_FAIL_INTERRUPTED = 33,		// was 32 in pre 1.7
	//CAST_FAIL_INTERRUPTED_COMBAT = 31,
	CAST_FAIL_ITEM_ALREADY_ENCHANTED = 34,
	CAST_FAIL_ITEM_IS_GONE = 35,
	CAST_FAIL_ENCHANT_NOT_EXISTING_ITEM = 36,
	CAST_FAIL_ITEM_NOT_READY = 37,
	CAST_FAIL_YOU_ARE_NOT_HIGH_ENOUGH = 38,
	CAST_FAIL_NOT_IN_LINE_OF_SIGHT = 39,
	CAST_FAIL_TARGET_TOO_LOW = 40,
	CAST_FAIL_SKILL_NOT_HIGH_ENOUGH = 41,
	CAST_FAIL_WEAPON_HAND_IS_EMPTY = 42,
	CAST_FAIL_CANT_DO_WHILE_MOVING = 43,
	CAST_FAIL_NEED_AMMO_IN_PAPERDOLL_SLOT = 44,
	CAST_FAIL_REQUIRES_SOMETHING = 45,
	CAST_FAIL_NEED_EXOTIC_AMMO = 46,
	CAST_FAIL_NO_PATH_AVAILABLE = 47,
	CAST_FAIL_NOT_BEHIND_TARGET = 48,
	CAST_FAIL_DIDNT_LAND_IN_FISHABLE_WATER = 49,
	CAST_FAIL_CANT_BE_CAST_HERE = 50,
	CAST_FAIL_NOT_IN_FRONT_OF_TARGET = 51,
	CAST_FAIL_NOT_IN_CONTROL_OF_ACTIONS = 52,
	CAST_FAIL_SPELL_NOT_LEARNED = 53,
	CAST_FAIL_CANT_USE_WHEN_MOUNTED = 54,
	CAST_FAIL_YOU_ARE_IN_FLIGHT = 55,
	CAST_FAIL_YOU_ARE_ON_TRANSPORT = 56,
	CAST_FAIL_SPELL_NOT_READY_YET = 57,
	CAST_FAIL_CANT_DO_IN_SHAPESHIFT = 58,
	CAST_FAIL_HAVE_TO_BE_STANDING = 59,
	CAST_FAIL_CAN_USE_ONLY_ON_OWN_OBJECT = 60,	// rogues trying "enchant" other's weapon with poison
	CAST_FAIL_CANT_ENCHANT_TRADE_ITEM = 61,
	CAST_FAIL_HAVE_TO_BE_UNSHEATHED = 62,		// yellow text
	CAST_FAIL_CANT_CAST_AS_GHOST = 63,
	CAST_FAIL_NO_AMMO = 64,
	CAST_FAIL_NO_CHARGES_REMAIN = 65,
	CAST_FAIL_COMBO_POINTS_REQUIRED = 66,
	CAST_FAIL_NO_DUELING_HERE = 67,
	CAST_FAIL_NOT_ENOUGH_ENDURANCE = 68,
	CAST_FAIL_THERE_ARENT_ANY_FISH_HERE = 69,
	CAST_FAIL_CANT_USE_WHILE_SHAPESHIFTED = 70,
	CAST_FAIL_CANT_MOUNT_HERE = 71,
	CAST_FAIL_YOU_DO_NOT_HAVE_PET = 72,
	CAST_FAIL_NOT_ENOUGH_MANA = 73,
	CAST_FAIL_CANT_USE_WHILE_SWIMMING = 74,
	CAST_FAIL_CAN_ONLY_USE_AT_DAY = 75,
	CAST_FAIL_CAN_ONLY_USE_INDOORS = 76,
	CAST_FAIL_CAN_ONLY_USE_MOUNTED = 77,
	CAST_FAIL_CAN_ONLY_USE_AT_NIGHT = 78,
	CAST_FAIL_CAN_ONLY_USE_OUTDOORS = 79,
	//CAST_FAIL_ONLY_SHAPESHIFTED = 80,			// didn't display
	CAST_FAIL_CAN_ONLY_USE_STEALTHED  = 81,
	CAST_FAIL_CAN_ONLY_USE_WHILE_SWIMMING = 82,
	CAST_FAIL_OUT_OF_RANGE = 83,
	CAST_FAIL_CANT_USE_WHILE_PACIFIED = 84,
	CAST_FAIL_YOU_ARE_POSSESSED = 85,
	CAST_FAIL_YOU_NEED_TO_BE_IN_XXX = 87,
	CAST_FAIL_REQUIRES_XXX = 88,
	CAST_FAIL_UNABLE_TO_MOVE = 89,
	CAST_FAIL_SILENCED = 90,
	CAST_FAIL_ANOTHER_ACTION_IS_IN_PROGRESS = 91,
	CAST_FAIL_ALREADY_LEARNED_THAT_SPELL = 92,
	CAST_FAIL_SPELL_NOT_AVAILABLE_TO_YOU = 93,
	CAST_FAIL_CANT_DO_WHILE_STUNNED = 94,
	CAST_FAIL_YOUR_TARGET_IS_DEAD = 95,
	CAST_FAIL_TARGET_IS_IN_COMBAT = 96,
	CAST_FAIL_CANT_DO_THAT_YET_2 = 97,
	CAST_FAIL_TARGET_IS_DUELING = 98,
	CAST_FAIL_TARGET_IS_HOSTILE = 99,
	CAST_FAIL_TARGET_IS_TOO_ENRAGED_TO_CHARM = 100,
	CAST_FAIL_TARGET_IS_FRIENDLY = 101,
	CAST_FAIL_TARGET_CANT_BE_IN_COMBAT = 102,
	CAST_FAIL_CANT_TARGET_PLAYERS = 103,
	CAST_FAIL_TARGET_IS_ALIVE = 104,
	CAST_FAIL_TARGET_NOT_IN_YOUR_PARTY = 104,
	CAST_FAIL_CREATURE_MUST_BE_LOOTED_FIRST = 106,
	CAST_FAIL_TARGET_IS_NOT_A_PLAYER = 107,
	CAST_FAIL_NO_POCKETS_TO_PICK = 108,
	CAST_FAIL_TARGET_HAS_NO_WEAPONS_EQUIPPED = 109,
	CAST_FAIL_NOT_SKINNABLE = 110,
	CAST_FAIL_TOO_CLOSE = 112,
	CAST_FAIL_TOO_MANY_OF_THAT_ITEM_ALREADY = 113,
	CAST_FAIL_NOT_ENOUGH_TRAINING_POINTS = 115,	
	CAST_FAIL_FAILED_ATTEMPT = 116,
	CAST_FAIL_TARGET_NEED_TO_BE_BEHIND = 117,
	CAST_FAIL_TARGET_NEED_TO_BE_INFRONT = 118,
	CAST_FAIL_PET_DOESNT_LIKE_THAT_FOOD = 119,
	CAST_FAIL_CANT_CAST_WHILE_FATIGUED = 120,
	CAST_FAIL_TARGET_MUST_BE_IN_THIS_INSTANCE = 121,
	CAST_FAIL_CANT_CAST_WHILE_TRADING = 122,
	CAST_FAIL_TARGET_IS_NOT_PARTY_OR_RAID = 123,
	CAST_FAIL_CANT_DISENCHANT_WHILE_LOOTING = 124,
	CAST_FAIL_TARGET_IS_IN_FFA_PVP_COMBAT = 125,
	CAST_FAIL_NO_NEARBY_CORPSES_TO_EAT = 126,
	CAST_FAIL_CAN_ONLY_USE_IN_BATTLEGROUNDS = 127,
	CAST_FAIL_TARGET_IS_NOT_A_GHOST = 128,
	CAST_FAIL_YOUR_PET_CANT_LEARN_MORE_SKILLS = 129,
	CAST_FAIL_UNKNOWN_REASON = 130,
	CAST_FAIL_NUMREASONS
};

typedef enum {
	FLAG_CHECK_TARGET_TYPE = 1,
	FLAG_CHECK_HIGH_LEVEL = 2,
	FLAG_FREE_WHEN_DAMAGED = 4
} CheckFlagsType;

#define SPELL_SPELL_CHANNEL_UPDATE_INTERVAL 1000
class Unit;
class Affect;

// Spell object
//
class Spell
{
public:
    Spell( Unit* Caster, SpellEntry *info, bool triggered, Affect* aff );

    void FillTargetMap();
    void prepare(SpellCastTargets * targets);
    void cancel();
    void update(uint32 difftime);
    virtual void cast();
    virtual void finish();
    virtual void HandleEffects(uint64 guid,uint32 i);
    void TakePower();
    void TriggerSpell();
	void DelaySpell(uint32 delay);
    uint8 CanCast();

    inline uint32 getState() { return m_spellState; }

    void SendCastResult(uint8 result);
    void SendSpellStart();
    void SendSpellGo();
    void SendLogExecute();
    void SendInterrupted(uint8 result);
    void SendChannelUpdate(uint32 time);
    void SendChannelStart(uint32 duration);
    void SendResurrectRequest(Player* target);
    void HandleAddAffect(uint64 guid);
    void writeSpellGoTargets( WorldPacket * data );

    SpellEntry * m_spellInfo;
    Item* m_CastItem;
    SpellCastTargets m_targets;


protected:

    float _CalcDistance(float sX, float sY, float sZ, float dX, float dY, float dZ)
    {
        return sqrt((dX-sX)*(dX-sX)+(dY-sY)*(dY-sY)+(dZ-sZ)*(dZ-sZ));
    }

    Unit* m_caster;

    std::list<uint64> m_targetUnits1;
    std::list<uint64> m_targetUnits2;
    std::list<uint64> m_targetUnits3;
    std::list<uint64> UniqueTargets;
    uint8 m_targetCount;

    uint32	m_spellState;
    int32	m_timer;
    int32	m_intervalTimer; // used to update channel bar
    uint32	TriggerSpellId;  // used to set next spell to use

    float m_castPositionX;
    float m_castPositionY;
    float m_castPositionZ;
    bool m_triggeredSpell;
    Affect* m_triggeredByAffect;
    bool m_AreaAura;


};

enum ReplenishType
{
    REPLENISH_UNDEFINED = 0,
    REPLENISH_HEALTH = 20,
    REPLENISH_MANA = 21,
    REPLENISH_RAGE = 22 //don't know if rage is 22 or what, but will do for now
};


#endif

