// Copyright (C) 2004 WoW Daemon
// Copyright (C) 2005 Oxide
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

enum School
{
    SCHOOL_HOLY = 1,
    SCHOOL_FIRE = 2,
    SCHOOL_NATURE = 3,
    SCHOOL_FROST = 4,
    SCHOOL_SHADOW = 5,
    SCHOOL_ARCANE = 6
};

struct TeleportCoords
{
	uint32 id;
	uint32 mapId;
	float x;
	float y;
	float z;
};

enum SpellEffects
{
    SPELL_EFFECT_INSTANT_KILL = 1,	
    SPELL_EFFECT_SCHOOL_DAMAGE,		//		2	
    SPELL_EFFECT_DUMMY,				//		3	
    SPELL_EFFECT_PORTAL_TELEPORT,	//		4	
    SPELL_EFFECT_TELEPORT_UNITS,		//		5	
    SPELL_EFFECT_APPLY_AURA,			//		6	
    SPELL_EFFECT_ENVIRONMENTAL_DAMAGE,	//	7	
    SPELL_EFFECT_POWER_DRAIN,				//	8	
    SPELL_EFFECT_HEALTH_LEECH,			//	9	
    SPELL_EFFECT_HEAL,					//	10	
    SPELL_EFFECT_BIND,					//	11	
    SPELL_EFFECT_PORTAL,					//	12
    SPELL_EFFECT_RITUAL_BASE,			//	13
    SPELL_EFFECT_RITUAL_SPECIALIZE,		//	14
    SPELL_EFFECT_RITUAL_ACTIVATE_PORTAL,	//	15
    SPELL_EFFECT_QUEST_COMPLETE,			//	16	
    SPELL_EFFECT_WEAPON_DAMAGE_NOSCHOOL,	//	17	
    SPELL_EFFECT_RESURRECT,				//	18	
    SPELL_EFFECT_ADD_EXTRA_ATTACKS,		//	19	
    SPELL_EFFECT_DODGE,					//	20	
    SPELL_EFFECT_EVADE,					//	21	
    SPELL_EFFECT_PARRY,					//	22	
    SPELL_EFFECT_BLOCK,					//	23	
    SPELL_EFFECT_CREATE_ITEM,			//	24	
    SPELL_EFFECT_WEAPON,					//	25
    SPELL_EFFECT_DEFENSE,				//	26
    SPELL_EFFECT_PERSISTENT_AREA_AURA,	//	27	
    SPELL_EFFECT_SUMMON,					//	28	
    SPELL_EFFECT_LEAP,					//	29	
    SPELL_EFFECT_ENERGIZE,				//	30	
    SPELL_EFFECT_WEAPON_PERCENT_DAMAGE,	//	31	
    SPELL_EFFECT_TRIGGER_MISSILE,		//	32	
    SPELL_EFFECT_OPEN_LOCK,				//	33	
    SPELL_EFFECT_SUMMON_MOUNT_OBSOLETE,	//	34	
    SPELL_EFFECT_APPLY_AREA_AURA,		//	35	
    SPELL_EFFECT_LEARN_SPELL,			//	36	
    SPELL_EFFECT_SPELL_DEFENSE,			//	37	
    SPELL_EFFECT_DISPEL,					//	38	
    SPELL_EFFECT_LANGUAGE,				//	39
    SPELL_EFFECT_DUAL_WIELD,				//	40	
    SPELL_EFFECT_SUMMON_WILD,			//	41	
    SPELL_EFFECT_SUMMON_GUARDIAN,		//	42	
    SPELL_EFFECT_TELEPORT_UNITS_FACE_CASTER,	//43
    SPELL_EFFECT_SKILL_STEP,					//44	
    SPELL_EFFECT_UNDEFINED_45,			//	45	
    SPELL_EFFECT_SPAWN,					//	46
    SPELL_EFFECT_TRADE_SKILL,			//	47
    SPELL_EFFECT_STEALTH,				//	48
    SPELL_EFFECT_DETECT,					//	49
    //SPELL_EFFECT_SUMMON_OBJECT		//		50	
    SPELL_EFFECT_TRANS_DOOR,				//	50	
    SPELL_EFFECT_FORCE_CRITICAL_HIT,		//	51
    SPELL_EFFECT_GUARANTEE_HIT,			//	52
    SPELL_EFFECT_ENCHANT_ITEM,			//	53	
    SPELL_EFFECT_ENCHANT_ITEM_TEMPORARY,	//	54	
    SPELL_EFFECT_TAMECREATURE,			//	55	
    SPELL_EFFECT_SUMMON_PET,				//	56	
    SPELL_EFFECT_LEARN_PET_SPELL,		//	57	
    SPELL_EFFECT_WEAPON_DAMAGE,			//	58	
    SPELL_EFFECT_OPEN_LOCK_ITEM,			//	59	
    SPELL_EFFECT_PROFICIENCY,			//	60
    SPELL_EFFECT_SEND_EVENT,				//	61	
    SPELL_EFFECT_POWER_BURN,				//	62
    SPELL_EFFECT_THREAT,					//	63
    SPELL_EFFECT_TRIGGER_SPELL,			//	64	
    SPELL_EFFECT_HEALTH_FUNNEL,			//	65
    SPELL_EFFECT_POWER_FUNNEL,			//	66
    SPELL_EFFECT_HEAL_MAX_HEALTH,		//	67	
    SPELL_EFFECT_INTERRUPT_CAST,			//	68
    SPELL_EFFECT_DISTRACT,				//	69
    SPELL_EFFECT_PULL,					//	70
    SPELL_EFFECT_PICKPOCKET,				//	71
    SPELL_EFFECT_ADD_FARSIGHT,			//	72
    SPELL_EFFECT_SUMMON_POSSESSED,		//	73	
    SPELL_EFFECT_SUMMON_TOTEM,			//	74	
    SPELL_EFFECT_HEAL_MECHANICAL,		//	75
    SPELL_EFFECT_SUMMON_OBJECT_WILD,		//	76
    SPELL_EFFECT_SCRIPT_EFFECT,			//	77	
    SPELL_EFFECT_ATTACK,					//	78
    SPELL_EFFECT_SANCTUARY,				//	79
    SPELL_EFFECT_ADD_COMBO_POINTS,		//	80	
    SPELL_EFFECT_CREATE_HOUSE,			//	81
    SPELL_EFFECT_BIND_SIGHT,				//	82
    SPELL_EFFECT_DUEL,					//	83
    SPELL_EFFECT_STUCK,					//	84
    SPELL_EFFECT_SUMMON_PLAYER,			//	85
    SPELL_EFFECT_ACTIVATE_OBJECT,		//	86
    SPELL_EFFECT_SUMMON_TOTEM_SLOT1,		//	87	
    SPELL_EFFECT_SUMMON_TOTEM_SLOT2,		//	88	
    SPELL_EFFECT_SUMMON_TOTEM_SLOT3,		//	89	
    SPELL_EFFECT_SUMMON_TOTEM_SLOT4,		//	90	
    SPELL_EFFECT_THREAT_ALL,				//	91
    SPELL_EFFECT_ENCHANT_HELD_ITEM,		//	92
    SPELL_EFFECT_SUMMON_PHANTASM,		//	93
    SPELL_EFFECT_SELF_RESURRECT,			//	94	
    SPELL_EFFECT_SKINNING,				//	95	
    SPELL_EFFECT_CHARGE,					//	96	
    SPELL_EFFECT_SUMMON_CRITTER,			//	97	
    SPELL_EFFECT_KNOCK_BACK,				//	98	
    SPELL_EFFECT_DISENCHANT,				//	99	
    SPELL_EFFECT_INEBRIATE,				//	100	
    SPELL_EFFECT_FEED_PET,				//	101
    SPELL_EFFECT_DISMISS_PET,			//	102
    SPELL_EFFECT_REPUTATION,				//	103
    SPELL_EFFECT_SUMMON_OBJECT_SLOT1,	//	104
    SPELL_EFFECT_SUMMON_OBJECT_SLOT2,	//	105
    SPELL_EFFECT_SUMMON_OBJECT_SLOT3,	//	106
    SPELL_EFFECT_SUMMON_OBJECT_SLOT4,	//	107
    SPELL_EFFECT_DISPEL_MECHANIC,		//	108	
    SPELL_EFFECT_SUMMON_DEAD_PET,		//	109
    SPELL_EFFECT_DESTROY_ALL_TOTEMS,		//	110
    SPELL_EFFECT_DURABILITY_DAMAGE,		//	111
    SPELL_EFFECT_SUMMON_DEMON,			//	112	
    SPELL_EFFECT_RESURRECT_FLAT,			//	113	
    SPELL_EFFECT_ATTACK_ME,				//	114
    SPELL_EFFECT_DURABILITY_DAMAGE_PCT,	//	115
    SPELL_EFFECT_SKIN_PLAYER_CORPSE,		//	116
    SPELL_EFFECT_SPIRIT_HEAL,			//	117
    SPELL_EFFECT_SKILL,					//	118
    SPELL_EFFECT_APPLY_AURA_NEW,			//	119	
    SPELL_EFFECT_TELEPORT_GRAVEYARD,		//	120
	SPELL_EFFECT_DUMMYMELEE,				//  121
    TOTAL_SPELL_EFFECTS,					//	122
};

enum SpellCastError
{
    SPELL_FAILED_AFFECTING_COMBAT = 0,
    SPELL_FAILED_ALREADY_AT_FULL_HEALTH = 1,
    SPELL_FAILED_ALREADY_AT_FULL_POWER = 2,
    SPELL_FAILED_ALREADY_BEING_TAMED = 3,
    SPELL_FAILED_ALREADY_HAVE_CHARM = 4,
    SPELL_FAILED_ALREADY_HAVE_SUMMON = 5,
    SPELL_FAILED_ALREADY_OPEN = 6,
    SPELL_FAILED_AURA_BOUNCED = 7,
    SPELL_FAILED_AUTOTRACK_INTERRUPTED = 8,
    SPELL_FAILED_BAD_IMPLICIT_TARGETS = 9,
    SPELL_FAILED_BAD_TARGETS = 10,
    SPELL_FAILED_CANT_BE_CHARMED = 11,
    SPELL_FAILED_CANT_BE_DISENCHANTED = 12,
    SPELL_FAILED_CANT_CAST_ON_TAPPED = 13,
    SPELL_FAILED_CANT_DUEL_WHILE_INVISIBLE = 14,
    SPELL_FAILED_CANT_DUEL_WHILE_STEALTHED = 15,
    SPELL_FAILED_CANT_STEALTH = 16,
    SPELL_FAILED_CASTER_AURASTATE = 17,
    SPELL_FAILED_CASTER_DEAD = 18,
    SPELL_FAILED_CHEST_IN_USE = 19,
    SPELL_FAILED_CONFUSED = 20,
    SPELL_FAILED_DONT_REPORT = 21,
    SPELL_FAILED_EQUIPPED_ITEM = 22,
    SPELL_FAILED_EQUIPPED_ITEM_CLASS = 23,
    SPELL_FAILED_EQUIPPED_ITEM_CLASS_MAINHAND = 24,
    SPELL_FAILED_ERROR = 25,
    SPELL_FAILED_FIZZLE = 26,
    SPELL_FAILED_FLEEING = 27,
    SPELL_FAILED_FOOD_LOWLEVEL = 28,
    SPELL_FAILED_HIGHLEVEL = 29,
    SPELL_FAILED_HUNGER_SATIATED = 30,
    SPELL_FAILED_IMMUNE = 31,
    SPELL_FAILED_INTERRUPTED = 32,
    SPELL_FAILED_INTERRUPTED_COMBAT = 33,
    SPELL_FAILED_ITEM_ALREADY_ENCHANTED = 34,
    SPELL_FAILED_ITEM_GONE = 35,
    SPELL_FAILED_ITEM_NOT_FOUND = 36,
    SPELL_FAILED_ITEM_NOT_READY = 37,
    SPELL_FAILED_LEVEL_REQUIREMENT = 38,
    SPELL_FAILED_LINE_OF_SIGHT = 39,
    SPELL_FAILED_LOWLEVEL = 40,
    SPELL_FAILED_LOW_CASTLEVEL = 41,
    SPELL_FAILED_MAINHAND_EMPTY = 42,
    SPELL_FAILED_MOVING = 43,
    SPELL_FAILED_NEED_AMMO = 44,
    SPELL_FAILED_NEED_AMMO_POUCH = 45,
    SPELL_FAILED_NEED_EXOTIC_AMMO = 46,
    SPELL_FAILED_NOPATH = 47,
    SPELL_FAILED_NOT_BEHIND = 48,
    SPELL_FAILED_NOT_FISHABLE = 49,
    SPELL_FAILED_NOT_HERE = 50,
    SPELL_FAILED_NOT_INFRONT = 51,
    SPELL_FAILED_NOT_IN_CONTROL = 52,
    SPELL_FAILED_NOT_KNOWN = 53,
    SPELL_FAILED_NOT_MOUNTED = 54,
    SPELL_FAILED_NOT_ON_TAXI = 55,
    SPELL_FAILED_NOT_ON_TRANSPORT = 56,
    SPELL_FAILED_NOT_READY = 57,
    SPELL_FAILED_NOT_SHAPESHIFT = 58,
    SPELL_FAILED_NOT_STANDING = 59,
    SPELL_FAILED_NOT_TRADEABLE = 60,
    SPELL_FAILED_NOT_TRADING = 61,
    SPELL_FAILED_NOT_UNSHEATHED = 62,
    SPELL_FAILED_NOT_WHILE_GHOST = 63,
    SPELL_FAILED_NO_AMMO = 64,
    SPELL_FAILED_NO_CHARGES_REMAIN = 65,
    SPELL_FAILED_NO_COMBO_POINTS = 66,
    SPELL_FAILED_NO_DUELING = 67,
    SPELL_FAILED_NO_ENDURANCE = 68,
    SPELL_FAILED_NO_FISH = 69,
    SPELL_FAILED_NO_ITEMS_WHILE_SHAPESHIFTED = 70,
    SPELL_FAILED_NO_MOUNTS_ALLOWED = 71,
    SPELL_FAILED_NO_PET = 72,
    SPELL_FAILED_NO_POWER = 73,
    SPELL_FAILED_ONLY_ABOVEWATER = 74,
    SPELL_FAILED_ONLY_DAYTIME = 75,
    SPELL_FAILED_ONLY_INDOORS = 76,
    SPELL_FAILED_ONLY_MOUNTED = 77,
    SPELL_FAILED_ONLY_NIGHTTIME = 78,
    SPELL_FAILED_ONLY_OUTDOORS = 79,
    SPELL_FAILED_ONLY_SHAPESHIFT = 80,
    SPELL_FAILED_ONLY_STEALTHED = 81,
    SPELL_FAILED_ONLY_UNDERWATER = 82,
    SPELL_FAILED_OUT_OF_RANGE = 83,
    SPELL_FAILED_PACIFIED = 84,
    SPELL_FAILED_POSSESSED = 85,
    SPELL_FAILED_REAGENTS = 86,
    SPELL_FAILED_REQUIRES_AREA = 87,
    SPELL_FAILED_REQUIRES_SPELL_FOCUS = 88,
    SPELL_FAILED_ROOTED = 89,
    SPELL_FAILED_SILENCED = 90,
    SPELL_FAILED_SPELL_IN_PROGRESS = 91,
    SPELL_FAILED_SPELL_LEARNED = 92,
    SPELL_FAILED_SPELL_UNAVAILABLE = 93,
    SPELL_FAILED_STUNNED = 94,
    SPELL_FAILED_TARGETS_DEAD = 95,
    SPELL_FAILED_TARGET_AFFECTING_COMBAT = 96,
    SPELL_FAILED_TARGET_AURASTATE = 97,
    SPELL_FAILED_TARGET_DUELING = 98,
    SPELL_FAILED_TARGET_ENEMY = 99,
    SPELL_FAILED_TARGET_ENRAGED = 100,
    SPELL_FAILED_TARGET_FRIENDLY = 101,
    SPELL_FAILED_TARGET_IN_COMBAT = 102,
    SPELL_FAILED_TARGET_IS_PLAYER = 103,
    SPELL_FAILED_TARGET_NOT_DEAD = 104,
    SPELL_FAILED_TARGET_NOT_IN_PARTY = 105,
    SPELL_FAILED_TARGET_NOT_LOOTED = 106,
    SPELL_FAILED_TARGET_NOT_PLAYER = 107,
    SPELL_FAILED_TARGET_NO_POCKETS = 108,
    SPELL_FAILED_TARGET_NO_WEAPONS = 109,
    SPELL_FAILED_TARGET_UNSKINNABLE = 110,
    SPELL_FAILED_THIRST_SATIATED = 111,
    SPELL_FAILED_TOO_CLOSE = 112,
    SPELL_FAILED_TOO_MANY_OF_ITEM = 113,
    SPELL_FAILED_TOTEMS = 114,
    SPELL_FAILED_TRAINING_POINTS = 115,
    SPELL_FAILED_TRY_AGAIN = 116,
    SPELL_FAILED_UNIT_NOT_BEHIND = 117,
    SPELL_FAILED_UNIT_NOT_INFRONT = 118,
    SPELL_FAILED_WRONG_PET_FOOD = 119,
    SPELL_FAILED_NOT_WHILE_FATIGUED = 120,
    SPELL_FAILED_TARGET_NOT_IN_INSTANCE = 121,
    SPELL_FAILED_NOT_WHILE_TRADING = 122,
    SPELL_FAILED_TARGET_NOT_IN_RAID = 123,
    SPELL_FAILED_DISENCHANT_WHILE_LOOTING = 124,
    SPELL_FAILED_TARGET_FREEFORALL = 125,
    SPELL_FAILED_NO_EDIBLE_CORPSES = 126,
    SPELL_FAILED_ONLY_BATTLEGROUNDS = 127
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
    FORM_STEALTH          = 30,
    FORM_MOONKIN          = 31,
};

# define POWER_TYPE_HEALTH 4294967294
# define POWER_TYPE_MANA 0
# define POWER_TYPE_RAGE 1
# define POWER_TYPE_FOCUS 2
# define POWER_TYPE_ENERGY 3


#define SPELL_SPELL_CHANNEL_UPDATE_INTERVAL 1000
// Spell instance
class Spell
{
public:
    Spell( Unit* Caster, SpellEntry *info, bool triggered, Affect* aff, bool melee);
	Spell( Unit* Caster, SpellEntry *info, bool triggered, Affect* aff, bool melee, bool load);
    void FillTargetMap();
    void prepare(SpellCastTargets * targets);
    void cancel();
    void update(uint32 difftime);
    void cast();
    void finish();
    void HandleEffects(uint64 guid,uint32 i);
    void TakePower();
    void TriggerSpell();
    int8 CanCast();
    int8 CheckItems();
    void RemoveItems();
    uint32 CalculateDamage(uint8 i, Unit* unitTarget);
	void HandleTeleport(uint32 id, Unit* Target);
	void melee();
	void DetermineSkillUp();
	void AddTime();

    inline uint32 getState() { return m_spellState; }

    // Send Packet functions
    void SendCastResult(int8 result);
    void SendSpellStart();
    void SendSpellGo();
    void SendLogExecute(uint32 damage);
    void SendInterrupted(uint8 result);
    void SendChannelUpdate(uint32 time);
    void SendChannelStart(uint32 duration);
    void SendResurrectRequest(Player* target);


    void HandleAddAffect(uint64 guid);
    void writeSpellGoTargets( WorldPacket * data );

    SpellEntry * m_spellInfo;
    Item* m_CastItem;
    SpellCastTargets m_targets;

	void CreateItem(uint32 itemId);



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

	bool load;

    uint32 m_spellState;
    uint32 m_timer;
    uint32 m_intervalTimer; // used to update channel bar
    uint32 TriggerSpellId;  // used to set next spell to use

    float m_castPositionX;
    float m_castPositionY;
    float m_castPositionZ;
    bool m_triggeredSpell;
	bool m_melee;
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

