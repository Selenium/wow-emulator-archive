#pragma once
// Copyright (C) 2004 WoWD Team

#ifndef __UNIT_H
#define __UNIT_H

#include "Object.h"
#include "Opcodes.h"
#include "../Shared/FactionTemplates.h"

#include "../Shared/Namespace.h"

#define UF_TARGET_DIED  1
#define UF_ATTACKING    2 // this unit is attacking it's selection

/*class Affect;
class Modifier;
class Spell;*/

// Count of unit update ticks, till unit hates other unit. Then hate fades
#define UNIT_HATE_DEGRADE_COUNTER	100

// Maximum limit for degrade counter to not make mob endlessly chasing
#define MAX_DEGRADE_COUNTER_VALUE	(UNIT_HATE_DEGRADE_COUNTER * 4)

// Increase step when monster gets more aggroed
#define UPGRADE_HATE_COUNTER_VALUE	(UNIT_HATE_DEGRADE_COUNTER / 2)

#define AURA_CHECK_EVERY_MSEC		2000

enum DamageType
{
	DMG_PHYSICAL = 0,
	DMG_HOLY,
	DMG_FIRE,
	DMG_NATURE,
	DMG_FROST,
	DMG_SHADOW,
	DMG_ARCANE
};

enum CreatureState
{
	AI_STATE_STOPPED,
	AI_STATE_MOVING,
	AI_STATE_ATTACKING
};

enum DeathState
{
    ALIVE = 0,  // Unit is alive and well
    JUST_DIED,  // Unit has JUST died
    CORPSE,     // Unit has died but remains in the world as a corpse
    DEAD        // Unit is dead and his corpse is gone from the world
};

enum InvisibilityLevel
{
	INVISIBILITY_NONE = 0,
	INVISIBILITY_LESSER,
	INVISIBILITY_MEDIUM,
	INVISIBILITY_GREATER,
	INVISIBILITY_GM,
	INVISIBILITY_TRUE
};


enum Classes
{
	CLASS_WARRIOR = 1,
	CLASS_PALADIN = 2,
	CLASS_HUNTER = 3,
	CLASS_ROGUE = 4,
	CLASS_PRIEST = 5,
	CLASS_SHAMAN = 7,
	CLASS_MAGE = 8,
	CLASS_WARLOCK = 9,
	CLASS_DRUID = 11,
};

enum WorldRaces
{
	RACE_HUMAN		= 1,
	RACE_ORC        = 2,
	RACE_DWARF      = 3,
	RACE_NIGHT_ELF  = 4,
	RACE_UNDEAD     = 5,
	RACE_TAUREN     = 6,
	RACE_GNOME      = 7,
	RACE_TROLL      = 8
};


typedef enum
{
	TEXTEMOTE_AGREE            = 1,
	TEXTEMOTE_AMAZE            = 2,
	TEXTEMOTE_ANGRY            = 3,
	TEXTEMOTE_APOLOGIZE        = 4,
	TEXTEMOTE_APPLAUD          = 5,
	TEXTEMOTE_BASHFUL          = 6,
	TEXTEMOTE_BECKON           = 7,
	TEXTEMOTE_BEG              = 8,
	TEXTEMOTE_BITE             = 9,
	TEXTEMOTE_BLEED            = 10,
	TEXTEMOTE_BLINK            = 11,
	TEXTEMOTE_BLUSH            = 12,
	TEXTEMOTE_BONK             = 13,
	TEXTEMOTE_BORED            = 14,
	TEXTEMOTE_BOUNCE           = 15,
	TEXTEMOTE_BRB              = 16,
	TEXTEMOTE_BOW              = 17,
	TEXTEMOTE_BURP             = 18,
	TEXTEMOTE_BYE              = 19,
	TEXTEMOTE_CACKLE           = 20,
	TEXTEMOTE_CHEER            = 21,
	TEXTEMOTE_CHICKEN          = 22,
	TEXTEMOTE_CHUCKLE          = 23,
	TEXTEMOTE_CLAP             = 24,
	TEXTEMOTE_CONFUSED         = 25,
	TEXTEMOTE_CONGRATULATE     = 26,
	TEXTEMOTE_COUGH            = 27,
	TEXTEMOTE_COWER            = 28,
	TEXTEMOTE_CRACK            = 29,
	TEXTEMOTE_CRINGE           = 30,
	TEXTEMOTE_CRY              = 31,
	TEXTEMOTE_CURIOUS          = 32,
	TEXTEMOTE_CURTSEY          = 33,
	TEXTEMOTE_DANCE            = 34,
	TEXTEMOTE_DRINK            = 35,
	TEXTEMOTE_DROOL            = 36,
	TEXTEMOTE_EAT              = 37,
	TEXTEMOTE_EYE              = 38,
	TEXTEMOTE_FART             = 39,
	TEXTEMOTE_FIDGET           = 40,
	TEXTEMOTE_FLEX             = 41,
	TEXTEMOTE_FROWN            = 42,
	TEXTEMOTE_GASP             = 43,
	TEXTEMOTE_GAZE             = 44,
	TEXTEMOTE_GIGGLE           = 45,
	TEXTEMOTE_GLARE            = 46,
	TEXTEMOTE_GLOAT            = 47,
	TEXTEMOTE_GREET            = 48,
	TEXTEMOTE_GRIN             = 49,
	TEXTEMOTE_GROAN            = 50,
	TEXTEMOTE_GROVEL           = 51,
	TEXTEMOTE_GUFFAW           = 52,
	TEXTEMOTE_HAIL             = 53,
	TEXTEMOTE_HAPPY            = 54,
	TEXTEMOTE_HELLO            = 55,
	TEXTEMOTE_HUG              = 56,
	TEXTEMOTE_HUNGRY           = 57,
	TEXTEMOTE_KISS             = 58,
	TEXTEMOTE_KNEEL            = 59,
	TEXTEMOTE_LAUGH            = 60,
	TEXTEMOTE_LAYDOWN          = 61,
	TEXTEMOTE_MASSAGE          = 62,
	TEXTEMOTE_MOAN             = 63,
	TEXTEMOTE_MOON             = 64,
	TEXTEMOTE_MOURN            = 65,
	TEXTEMOTE_NO               = 66,
	TEXTEMOTE_NOD              = 67,
	TEXTEMOTE_NOSEPICK         = 68,
	TEXTEMOTE_PANIC            = 69,
	TEXTEMOTE_PEER             = 70,
	TEXTEMOTE_PLEAD            = 71,
	TEXTEMOTE_POINT            = 72,
	TEXTEMOTE_POKE             = 73,
	TEXTEMOTE_PRAY             = 74,
	TEXTEMOTE_ROAR             = 75,
	TEXTEMOTE_ROFL             = 76,
	TEXTEMOTE_RUDE             = 77,
	TEXTEMOTE_SALUTE           = 78,
	TEXTEMOTE_SCRATCH          = 79,
	TEXTEMOTE_SEXY             = 80,
	TEXTEMOTE_SHAKE            = 81,
	TEXTEMOTE_SHOUT            = 82,
	TEXTEMOTE_SHRUG            = 83,
	TEXTEMOTE_SHY              = 84,
	TEXTEMOTE_SIGH             = 85,
	TEXTEMOTE_SIT              = 86,
	TEXTEMOTE_SLEEP            = 87,
	TEXTEMOTE_SNARL            = 88,
	TEXTEMOTE_SPIT             = 89,
	TEXTEMOTE_STARE            = 90,
	TEXTEMOTE_SURPRISED        = 91,
	TEXTEMOTE_SURRENDER        = 92,
	TEXTEMOTE_TALK             = 93,
	TEXTEMOTE_TALKEX           = 94,
	TEXTEMOTE_TALKQ            = 95,
	TEXTEMOTE_TAP              = 96,
	TEXTEMOTE_THANK            = 97,
	TEXTEMOTE_THREATEN         = 98,
	TEXTEMOTE_TIRED            = 99,
	TEXTEMOTE_VICTORY          = 100,
	TEXTEMOTE_WAVE             = 101,
	TEXTEMOTE_WELCOME          = 102,
	TEXTEMOTE_WHINE            = 103,
	TEXTEMOTE_WHISTLE          = 104,
	TEXTEMOTE_WORK             = 105,
	TEXTEMOTE_YAWN             = 106,
	TEXTEMOTE_BOGGLE           = 107,
	TEXTEMOTE_CALM             = 108,
	TEXTEMOTE_COLD             = 109,
	TEXTEMOTE_COMFORT          = 110,
	TEXTEMOTE_CUDDLE           = 111,
	TEXTEMOTE_DUCK             = 112,
	TEXTEMOTE_INSULT           = 113,
	TEXTEMOTE_INTRODUCE        = 114,
	TEXTEMOTE_JK               = 115,
	TEXTEMOTE_LICK             = 116,
	TEXTEMOTE_LISTEN           = 117,
	TEXTEMOTE_LOST             = 118,
	TEXTEMOTE_MOCK             = 119,
	TEXTEMOTE_PONDER           = 120,
	TEXTEMOTE_POUNCE           = 121,
	TEXTEMOTE_PRAISE           = 122,
	TEXTEMOTE_PURR             = 123,
	TEXTEMOTE_PUZZLE           = 124,
	TEXTEMOTE_RAISE            = 125,
	TEXTEMOTE_READY            = 126,
	TEXTEMOTE_SHIMMY           = 127,
	TEXTEMOTE_SHIVER           = 128,
	TEXTEMOTE_SHOO             = 129,
	TEXTEMOTE_SLAP             = 130,
	TEXTEMOTE_SMIRK            = 131,
	TEXTEMOTE_SNIFF            = 132,
	TEXTEMOTE_SNUB             = 133,
	TEXTEMOTE_SOOTHE           = 134,
	TEXTEMOTE_STINK            = 135,
	TEXTEMOTE_TAUNT            = 136,
	TEXTEMOTE_TEASE            = 137,
	TEXTEMOTE_THIRSTY          = 138,
	TEXTEMOTE_VETO             = 139,
	TEXTEMOTE_SNICKER          = 140,
	TEXTEMOTE_STAND            = 141,
	TEXTEMOTE_TICKLE           = 142,
	TEXTEMOTE_VIOLIN           = 143,
	TEXTEMOTE_SMILE            = 163,
	TEXTEMOTE_RASP             = 183,
	TEXTEMOTE_PITY             = 203,
	TEXTEMOTE_GROWL            = 204,
	TEXTEMOTE_BARK             = 205,
	TEXTEMOTE_SCARED           = 223,
	TEXTEMOTE_FLOP             = 224,
	TEXTEMOTE_LOVE             = 225,
	TEXTEMOTE_MOO              = 226,
	TEXTEMOTE_COMMEND          = 243,
	TEXTEMOTE_JOKE             = 329
} TextEmoteType;

typedef enum
{
	EMOTE_ONESHOT_NONE             = 0,
	EMOTE_ONESHOT_TALK             = 1,   //DNR
	EMOTE_ONESHOT_BOW              = 2,
	EMOTE_ONESHOT_WAVE             = 3,   //DNR
	EMOTE_ONESHOT_CHEER            = 4,   //DNR
	EMOTE_ONESHOT_EXCLAMATION      = 5,   //DNR
	EMOTE_ONESHOT_QUESTION         = 6,
	EMOTE_ONESHOT_EAT              = 7,
	EMOTE_STATE_DANCE              = 10,
	EMOTE_ONESHOT_LAUGH            = 11,
	EMOTE_STATE_SLEEP              = 12,
	EMOTE_STATE_SIT                = 13,
	EMOTE_ONESHOT_RUDE             = 14,  //DNR
	EMOTE_ONESHOT_ROAR             = 15,  //DNR
	EMOTE_ONESHOT_KNEEL            = 16,
	EMOTE_ONESHOT_KISS             = 17,
	EMOTE_ONESHOT_CRY              = 18,
	EMOTE_ONESHOT_CHICKEN          = 19,
	EMOTE_ONESHOT_BEG              = 20,
	EMOTE_ONESHOT_APPLAUD          = 21,
	EMOTE_ONESHOT_SHOUT            = 22,  //DNR
	EMOTE_ONESHOT_FLEX             = 23,
	EMOTE_ONESHOT_SHY              = 24,  //DNR
	EMOTE_ONESHOT_POINT            = 25,  //DNR
	EMOTE_STATE_STAND              = 26,
	EMOTE_STATE_READYUNARMED       = 27,
	EMOTE_STATE_WORK               = 28,
	EMOTE_STATE_POINT              = 29,  //DNR
	EMOTE_STATE_NONE               = 30,
	EMOTE_ONESHOT_WOUND            = 33,
	EMOTE_ONESHOT_WOUNDCRITICAL    = 34,
	EMOTE_ONESHOT_ATTACKUNARMED    = 35,
	EMOTE_ONESHOT_ATTACK1H         = 36,
	EMOTE_ONESHOT_ATTACK2HTIGHT    = 37,
	EMOTE_ONESHOT_ATTACK2HLOOSE    = 38,
	EMOTE_ONESHOT_PARRYUNARMED     = 39,
	EMOTE_ONESHOT_PARRYSHIELD      = 43,
	EMOTE_ONESHOT_READYUNARMED     = 44,
	EMOTE_ONESHOT_READY1H          = 45,
	EMOTE_ONESHOT_READYBOW         = 48,
	EMOTE_ONESHOT_SPELLPRECAST     = 50,
	EMOTE_ONESHOT_SPELLCAST        = 51,
	EMOTE_ONESHOT_BATTLEROAR       = 53,
	EMOTE_ONESHOT_SPECIALATTACK1H  = 54,
	EMOTE_ONESHOT_KICK             = 60,
	EMOTE_ONESHOT_ATTACKTHROWN     = 61,
	EMOTE_STATE_STUN               = 64,
	EMOTE_STATE_DEAD               = 65,
	EMOTE_ONESHOT_SALUTE           = 66,
	EMOTE_STATE_KNEEL              = 68,
	EMOTE_STATE_USESTANDING        = 69,
	EMOTE_ONESHOT_WAVE_NOSHEATHE   = 70,
	EMOTE_ONESHOT_CHEER_NOSHEATHE  = 71,
	EMOTE_ONESHOT_EAT_NOSHEATHE    = 92,
	EMOTE_STATE_STUN_NOSHEATHE     = 93,
	EMOTE_ONESHOT_DANCE            = 94,
	EMOTE_ONESHOT_SALUTE_NOSHEATH  = 113,
	EMOTE_STATE_USESTANDING_NOSHEATHE  = 133,
	EMOTE_ONESHOT_LAUGH_NOSHEATHE  = 153,
	EMOTE_STATE_WORK_NOSHEATHE     = 173,
	EMOTE_STATE_SPELLPRECAST       = 193,
	EMOTE_ONESHOT_READYRIFLE       = 213,
	EMOTE_STATE_READYRIFLE         = 214,
	EMOTE_STATE_WORK_NOSHEATHE_MINING  = 233,
	EMOTE_STATE_WORK_NOSHEATHE_CHOPWOOD= 234,
	EMOTE_zzOLDONESHOT_LIFTOFF     = 253,
	EMOTE_ONESHOT_LIFTOFF          = 254,
	EMOTE_ONESHOT_YES              = 273, //DNR
	EMOTE_ONESHOT_NO               = 274, //DNR
	EMOTE_ONESHOT_TRAIN            = 275, //DNR
	EMOTE_ONESHOT_LAND             = 293,
	EMOTE_STATE_READY1H            = 333,
	EMOTE_STATE_AT_EASE            = 313,
	EMOTE_STATE_SPELLKNEELSTART    = 353,
	EMOTE_STATE_SUBMERGED          = 373,
	EMOTE_ONESHOT_SUBMERGE         = 374
} EmoteType;

typedef enum
{
	LANG_UNIVERSAL      = 0x00,
	LANG_ORCISH         = 0x01,
	LANG_DARNASSIAN     = 0x02,
	LANG_TAURAHE        = 0x03,
	LANG_DWARVISH       = 0x06,
	LANG_COMMON         = 0x07,
	LANG_DEMONIC        = 0x08,
	LANG_TITAN          = 0x09,
	LANG_THELASSIAN     = 0x0A,
	LANG_DRACONIC       = 0x0B,
	LANG_KALIMAG        = 0x0C,
	LANG_GNOMISH        = 0x0D,
	LANG_TROLL          = 0x0E,
	LANG_GUTTERSPEAK	= 33,
	NUM_LANGUAGES
} Language;


//---------------------------------------------------------
//  Dynamic flags for units
//---------------------------------------------------------
// Unit has blinking stars effect showing lootable
#define UNIT_DYNFLAG_LOOTABLE			0x0001
// Shows marked unit as small red dot on radar
#define UNIT_DYNFLAG_TRACK_UNIT			0x0002
// Gray mob title marks that mob is tagged by another player
#define UNIT_DYNFLAG_OTHER_TAGGER		0x0004
// Blocks player character from moving
#define UNIT_DYNFLAG_ROOTED				0x0008
// Shows infos like Damage and Health of the enemy
#define UNIT_DYNFLAG_SPECIALINFO		0x0010
// Unit falls on the ground and shows like dead
#define UNIT_DYNFLAG_DEAD				0x0020

//---------------------------------------------------------
//  Flags for units
//---------------------------------------------------------
#define UNIT_FLAG_NOT_ATTACKABLE		0x0002
// Unit becomes temporarily hostile, shows in red, allows attack
#define UNIT_FLAG_ATTACKABLE			0x0008
// Unit cannot be attacked by player, shows no attack cursor
#define UNIT_FLAG_NOT_ATTACKABLE_1		0x0080
// Unit cannot be attacked by player, shows in blue
#define UNIT_FLAG_NON_PVP_PLAYER		(UNIT_FLAG_ATTACKABLE + UNIT_FLAG_NOT_ATTACKABLE_1)
// Doesn't play animation
#define UNIT_FLAG_ANIMATION_FROZEN		0x0400
#define UNIT_FLAG_WAR_PLAYER			0x1000//Show for Example "A proud Member of the Horde..." etc. when resurrecting a friend or fighting



#define UNIT_NORMAL_WALK_SPEED		2.5f
#define UNIT_NORMAL_RUN_SPEED		7.0f
#define UNIT_NORMAL_RUN_BACK_SPEED	4.5f
#define UNIT_NORMAL_SWIM_SPEED		4.72f

enum {
	POWER_TYPE_MANA = 0,
	POWER_TYPE_RAGE = 1,
	POWER_TYPE_FOCUS = 2,
	POWER_TYPE_ENERGY = 3
};

class Affect;
class Modifier;
class Spell;
class Unit;

//-----------------------------------------------------------------------------
// Hated By and Target Unit collections
//-----------------------------------------------------------------------------
typedef hash_map<Unit *, float> TargetMap;	// Collection of creature targets
typedef set<Unit *> UnitSet;

//====================================================================
//  Unit
//  Base object for Players and Creatures
//====================================================================
class Unit : public Object
{
public:
    virtual ~Unit ( );

    virtual void Update( int32 time );

	//-------------------------------------------------
	//  AI, Mob Combat, Aggro Calculations
	//-------------------------------------------------
protected:
	TargetMap		m_targets;

	int32			m_nextThink;
	uint32			m_nextThinkParam;

	Unit		  * m_tagger;

public:
	Unit * GetTagger() { return m_tagger; }
	void SetTagger (Unit *t) { m_tagger = t; }

	inline void NextThink (uint32 time, uint32 param) {
		m_nextThink = time;
		m_nextThinkParam = param;
	}
	inline bool isInCombat() { return m_targets.size() != 0; }

	void setAttackTimer();
	bool isAttackReady() const { return m_attackTimer == 0; }
	bool CanReachWithAttack (Unit *pVictim);
	
	inline bool isAlliance() {
		uint8 r = (uint8)GetRace();
		return r == RACE_HUMAN || r == RACE_DWARF || r == RACE_GNOME || r == RACE_NIGHT_ELF;
	}
	inline bool isHorde() {
		uint8 r = (uint8)GetRace();
		return r == RACE_ORC || r == RACE_UNDEAD || r == RACE_TAUREN || r == RACE_TROLL;
	}
	//---------------------------------------------------
	inline bool isHostileToMe (Unit *unit)
	{
		uint32	f = unit->GetFaction();

		// Hey this thing doesn't love anyone!
		if (FACTION_ALL_HOSTILE(f)) return true;
		
		if (isAlliance()) {  // I am alliance
			if (FACTION_ALLIANCE_HOSTILE(f)) return true;
		} 
		else
		if (isHorde()) { // I am horde
			if (FACTION_HORDE_HOSTILE(f)) return true;
		}
		else // I am environment creature mehehe
			if (FACTION_ENV_HOSTILE(f)) return true;
		
		return false; // not hostile else
	}
	//---------------------------------------------------
	inline bool isFriendlyToMe (Unit *unit)
	{
		uint32	f = unit->GetFaction();

		// Hey this thing loves everyone!
		if (FACTION_ALL_FRIENDLY(f)) return true;

		if (isAlliance()) {  // I am alliance
			if (FACTION_ALLIANCE_FRIENDLY(f)) return true;
		} 
		else
			if (isHorde()) { // I am horde
				if (FACTION_HORDE_FRIENDLY(f)) return true;
			}
			else // I am environment creature mehehe
				if (FACTION_ENV_FRIENDLY(f)) return true;

		return false; // not friendly else
	}
	//---------------------------------------------------
	inline bool CanFightMe (Unit *unit)
	{
		uint32	f = unit->GetFaction();

		// Hey this thing loves everyone!
		if (FACTION_FIGHT_ALL(f)) return true;
		
		if (isAlliance()) {  // I am alliance
			if (FACTION_FIGHT_ALLIANCE(f)) return true;
		} 
		else
		if (isHorde()) { // I am horde
			if (FACTION_FIGHT_HORDE(f)) return true;
		}
		else // I am environment creature mehehe
			if (FACTION_FIGHT_ENV(f)) return true;
		
		return false; // can't fight else
	}

	//--------------------------------------------------------
	inline void RemoveHate (Unit *unit)
	{
		TargetMap::iterator itr = m_targets.find (unit);
		bool wasInCombat = isInCombat();

		if (itr != m_targets.end())
		{
			m_targets.erase (itr);
			unit->RemoveHate (this);
		}

		if (wasInCombat && !isInCombat())
			OnExitCombat();

		Unit *h = GetMostHated();
		SetUInt64Value (UNIT_FIELD_TARGET, h != NULL ? h->GetGUID() : 0);
	}

	//--------------------------------------------------------
	inline void RemoveHate_NR (Unit *unit)
	{
		TargetMap::iterator itr = m_targets.find (unit);
		bool wasInCombat = isInCombat();

		if (itr != m_targets.end())
		{
			m_targets.erase (itr);
		}

		if (wasInCombat && !isInCombat())
			OnExitCombat();

		Unit *h = GetMostHated();
		SetUInt64Value (UNIT_FIELD_TARGET, h != NULL ? h->GetGUID() : 0);
	}
	
	//--------------------------------------------------------
	inline float GetHate (Unit *unit)
	{
		TargetMap::iterator itr = m_targets.find (unit);
		if (itr != m_targets.end()) return itr->second;
		return 0.0f;
	}

	//--------------------------------------------------------
	inline Unit *GetMostHated()
	{
		Unit *Mh = NULL;
		float mostHate = 0.0f;

		for (TargetMap::iterator itr = m_targets.begin(); itr != m_targets.end(); itr++)
		{
			if (itr->second > mostHate) {
				Mh = ((Unit *)itr->first);
				mostHate = itr->second;
			}
		}
		return Mh;
	}

	//--------------------------------------------------------
	// This thing gets reset to 40 (10 seconds / run update interval) every time
	// aggro gets increased, and degrades by 1 every time, mob chases most hated target
	int16	m_hateDegradeCounter;

	// Increases or resets hate degradation counter every time someone
	// adds aggro to this creature. Degradation counter decreases with every
	// AI_Update tick till zero (if not reset by damaging or aggroing monster)
	// When counter reaches -1, all aggro resets, mob heals and returns to spawn
	void ResetHateDegradeCounter()
	{
		// If hate degradation is less than 1/4 of maximum counter value - then
		// we reset counter back. Else add some part of initial value with every hit.
		if (m_hateDegradeCounter < UNIT_HATE_DEGRADE_COUNTER)
			m_hateDegradeCounter = UNIT_HATE_DEGRADE_COUNTER;
		else
			m_hateDegradeCounter += UPGRADE_HATE_COUNTER_VALUE;

		if (m_hateDegradeCounter > MAX_DEGRADE_COUNTER_VALUE)
			m_hateDegradeCounter = MAX_DEGRADE_COUNTER_VALUE;
	}

	//--------------------------------------------------------
	// Adds some hate to given creature, and adds some hate to
	// creature hate table too (just to put into combat mode)
	//
	inline void AddHate (Unit *unit, float hate)
	{
		bool wasInCombat = isInCombat();
		ResetHateDegradeCounter();
		m_targets[unit] = GetHate (unit) + hate;
		unit->AddHate_NR (this, 0.1f);

		if (! wasInCombat && isInCombat())
			OnEnterCombat();

		Unit *h = GetMostHated();
		SetTarget (h != NULL ? h->GetGUID() : 0);
		//SetUInt64Value (UNIT_FIELD_TARGET, h != NULL ? h->GetGUID() : 0);
	}

	// NR - Non recursive - Doesn't notify target creature about added hate
	inline void AddHate_NR (Unit *unit, float hate)
	{
		bool wasInCombat = isInCombat();
		ResetHateDegradeCounter();
		m_targets[unit] = GetHate (unit) + hate;

		if (! wasInCombat && isInCombat())
			OnEnterCombat();

		Unit *h = GetMostHated();
		//SetUInt64Value (UNIT_FIELD_TARGET, h != NULL ? h->GetGUID() : 0);
		SetTarget (h != NULL ? h->GetGUID() : 0);
	}

	//--------------------------------------------------------
	// Mob becomes extremely peaceful and forgets all worries
	//
	inline void ClearHate()
	{
		bool wasInCombat = isInCombat();
		//for (TargetMap::iterator itr = m_targets.begin(); itr != m_targets.end(); itr++)
		while (! m_targets.empty())
		{
            //((Unit *)(itr->first))->RemoveHate (this);
			Unit * u = (Unit *)(m_targets.begin()->first);
			u->RemoveHate_NR (this);
			m_targets.erase (m_targets.begin());
		}
		//m_targets.clear();
		//SetUInt64Value (UNIT_FIELD_TARGET, 0); // stop turning self at attacker :)
		SetTarget (0);

		if (wasInCombat) OnExitCombat();
	}

	//--------------------------------------------------------
	// Merges own hate table into unit's hate
	//
	inline void ShareHateWith (Unit *unit, float scale=1.0f)
	{
		for (TargetMap::iterator itr = m_targets.begin(); itr != m_targets.end(); itr++)
		{
			float hateToShare = itr->second * scale;

			if (unit->GetHate ((Unit *)itr->first) < hateToShare)
				unit->AddHate_NR ((Unit *)itr->first, hateToShare);
		}
	}

    /// State flags are server-only flags to help me know when to do stuff, like die, or attack
    inline void addStateFlag(uint32 f) { m_state |= f; };
    inline void clearStateFlag(uint32 f) { m_state &= ~f; };

	virtual void OnEnterCombat() {
	}
	virtual void OnExitCombat();

	//--------------------------------------------------------
    //  Simple Class/Race Stats
	//--------------------------------------------------------
    inline uint8 GetLevel() { return (uint8)GetUInt32Value (UNIT_FIELD_LEVEL); };
	virtual void SetLevel (uint32 value);
    void _ApplyLevelUpAttributes (int32 level, bool apply);
	
	// Pass HasSkill/GetSkill from Player to Unit
	//bool HasSkill (uint32 skill_id)
	//{
	//	Player::HasSkill(skill_id);
	//}
	//uint16 GetSkill (uint32 skill_id)
	//{
	//	Player::GetSkill (skill_id);
	//}

	inline void _SetRace (uint8 race) {
		SetUInt32Value(UNIT_FIELD_BYTES_0, (GetUInt32Value (UNIT_FIELD_BYTES_0) & 0xFFFFFF00) | race);
	}

	inline uint8 GetRace() { return (uint8)(GetUInt32Value (UNIT_FIELD_BYTES_0) & 0xFF); }
    inline uint8 GetClass() { return (uint8)((GetUInt32Value (UNIT_FIELD_BYTES_0) >> 8) & 0xFF); }
    inline uint8 GetGender() { return (uint8)((GetUInt32Value (UNIT_FIELD_BYTES_0) >> 16) & 0xFF); }

	inline uint8 GetPowerIndex() { return (uint8)(GetUInt32Value(UNIT_FIELD_BYTES_0) >> 24); }
	
	virtual uint8 GetComboPoints() { return 0; }
	virtual void SetComboPoints (uint8 value) {}
	
	//--------------------------------------------------------
	//  Plain stats value reading code
	//--------------------------------------------------------
	inline int32 GetStrength() { return (int32)GetUInt32Value (UNIT_FIELD_STAT0); }
	inline int32 GetAgility() { return (int32)GetUInt32Value (UNIT_FIELD_STAT1); }
	inline int32 GetStamina() { return (int32)GetUInt32Value (UNIT_FIELD_STAT2); }
	inline int32 GetIntellect() { return (int32)GetUInt32Value (UNIT_FIELD_STAT3); }
	inline int32 GetSpirit() { return (int32)GetUInt32Value (UNIT_FIELD_STAT4); }

	inline int32 GetHealth() { return (int32)GetUInt32Value (UNIT_FIELD_HEALTH); }
	inline int32 GetMana() { return (int32)GetUInt32Value (UNIT_FIELD_POWER1); }
	inline int32 GetRage() { return (int32)GetUInt32Value (UNIT_FIELD_POWER2); }
	inline int32 GetFocus() { return (int32)GetUInt32Value (UNIT_FIELD_POWER3); }
	inline int32 GetEnergy() { return (int32)GetUInt32Value (UNIT_FIELD_POWER4); }

	inline int32 GetMaxHealth() { return (int32)GetUInt32Value (UNIT_FIELD_MAXHEALTH); }
	inline int32 GetMaxMana() { return (int32)GetUInt32Value (UNIT_FIELD_MAXPOWER1); }
	inline int32 GetMaxRage() { return (int32)GetUInt32Value (UNIT_FIELD_MAXPOWER2); }
	inline int32 GetMaxFocus() { return (int32)GetUInt32Value (UNIT_FIELD_MAXPOWER3); }
	inline int32 GetMaxEnergy() { return (int32)GetUInt32Value (UNIT_FIELD_MAXPOWER4); }

	inline int32 GetArmor() { return (int32)GetUInt32Value (UNIT_FIELD_RESISTANCES + DMG_PHYSICAL); }
	inline int32 GetHolyResist() { return (int32)GetUInt32Value (UNIT_FIELD_RESISTANCES + DMG_HOLY); }
	inline int32 GetFireResist() { return (int32)GetUInt32Value (UNIT_FIELD_RESISTANCES + DMG_FIRE); }
	inline int32 GetNatureResist() { return (int32)GetUInt32Value (UNIT_FIELD_RESISTANCES + DMG_NATURE); }
	inline int32 GetFrostResist() { return (int32)GetUInt32Value (UNIT_FIELD_RESISTANCES + DMG_FROST); }
	inline int32 GetShadowResist() { return (int32)GetUInt32Value (UNIT_FIELD_RESISTANCES + DMG_SHADOW); }
	inline int32 GetArcaneResist() { return (int32)GetUInt32Value (UNIT_FIELD_RESISTANCES + DMG_ARCANE); }

	virtual int32 GetPosStrength() { return 0; }
	virtual int32 GetPosAgility() { return 0; }
	virtual int32 GetPosStamina() { return 0; }
	virtual int32 GetPosIntellect() { return 0; }
	virtual int32 GetPosSpirit() { return 0; }

	virtual int32 GetNegStrength() { return 0; }
	virtual int32 GetNegAgility() { return 0; }
	virtual int32 GetNegStamina() { return 0; }
	virtual int32 GetNegIntellect() { return 0; }
	virtual int32 GetNegSpirit() { return 0; }

	//--------------------------------------------------------
	// Applies difference to stats, also changes all related stats
	//--------------------------------------------------------
	inline void ModifyStrength (int32 d) { SetStrength (GetStrength() + d); }
	inline void ModifyAgility (int32 d) { SetAgility (GetAgility() + d); }
	inline void ModifyStamina (int32 d) { SetStamina (GetStamina() + d); }
	inline void ModifyIntellect (int32 d) { SetIntellect (GetIntellect() + d); }
	inline void ModifySpirit (int32 d) { SetSpirit (GetSpirit() + d); }

	inline void ModifyHealth (int32 d) { SetHealth (GetHealth() + d); }
	inline void ModifyMana (int32 d) { SetMana (GetMana() + d); }
	inline void ModifyRage (int32 d) { SetRage (GetRage() + d); }
	inline void ModifyFocus (int32 d) { SetFocus (GetFocus() + d); }
	inline void ModifyEnergy (int32 d) { SetEnergy (GetEnergy() + d); }

	inline void ModifyMaxHealth (int32 d) { SetMaxHealth (GetMaxHealth() + d); }
	inline void ModifyMaxMana (int32 d) { SetMaxMana (GetMaxMana() + d); }
	inline void ModifyMaxRage (int32 d) { SetMaxRage (GetMaxRage() + d); }
	inline void ModifyMaxFocus (int32 d) { SetMaxFocus (GetMaxFocus() + d); }
	inline void ModifyMaxEnergy (int32 d) { SetMaxEnergy (GetMaxEnergy() + d); }

	inline void ModifyArmor (int32 d) { SetArmor (GetArmor() + d); }
	inline void ModifyHolyResist (int32 d) { SetHolyResist (GetHolyResist() + d); }
	inline void ModifyFireResist (int32 d) { SetFireResist (GetFireResist() + d); }
	inline void ModifyNatureResist (int32 d) { SetNatureResist (GetNatureResist() + d); }
	inline void ModifyFrostResist (int32 d) { SetFrostResist (GetFrostResist() + d); }
	inline void ModifyShadowResist (int32 d) { SetShadowResist (GetShadowResist() + d); }
	inline void ModifyArcaneResist (int32 d) { SetArcaneResist (GetArcaneResist() + d); }

	virtual void ModifyPosStrength (int32 d) {}
	virtual void ModifyPosAgility (int32 d) {}
	virtual void ModifyPosStamina (int32 d) {}
	virtual void ModifyPosIntellect (int32 d) {}
	virtual void ModifyPosSpirit (int32 d) {}

	virtual void ModifyNegStrength (int32 d) {}
	virtual void ModifyNegAgility (int32 d) {}
	virtual void ModifyNegStamina (int32 d) {}
	virtual void ModifyNegIntellect (int32 d) {}
	virtual void ModifyNegSpirit (int32 d) {}

	//--------------------------------------------------------
	// Stats modify code calculates difference and applies it
	//--------------------------------------------------------
	void SetStrength (int32 value);
	void SetAgility (int32 value);
	void SetStamina (int32 value);
	void SetIntellect (int32 value);
	inline void SetSpirit (int32 value) { SetUInt32Value (UNIT_FIELD_STAT4, value); }

	inline void SetHealth (int32 value) { SetUInt32Value (UNIT_FIELD_HEALTH, value); }
	inline void SetMana (int32 value) { SetUInt32Value (UNIT_FIELD_POWER1, value); }
	inline void SetRage (int32 value) { SetUInt32Value (UNIT_FIELD_POWER2, value); }
	inline void SetFocus (int32 value) { SetUInt32Value (UNIT_FIELD_POWER3, value); }
	inline void SetEnergy (int32 value) { SetUInt32Value (UNIT_FIELD_POWER4, value); }

	inline void SetMaxHealth (int32 value) { SetUInt32Value (UNIT_FIELD_MAXHEALTH, value); }
	inline void SetMaxMana (int32 value) { SetUInt32Value (UNIT_FIELD_MAXPOWER1, value); }
	inline void SetMaxRage (int32 value) { SetUInt32Value (UNIT_FIELD_MAXPOWER2, value); }
	inline void SetMaxFocus (int32 value) { SetUInt32Value (UNIT_FIELD_MAXPOWER3, value); }
	inline void SetMaxEnergy (int32 value) { SetUInt32Value (UNIT_FIELD_MAXPOWER4, value); }

	inline void SetArmor (int32 value) { SetUInt32Value (UNIT_FIELD_RESISTANCES + DMG_PHYSICAL, value); }
	inline void SetHolyResist (int32 value) { SetUInt32Value (UNIT_FIELD_RESISTANCES + DMG_HOLY, value); }
	inline void SetFireResist (int32 value) { SetUInt32Value (UNIT_FIELD_RESISTANCES + DMG_FIRE, value); }
	inline void SetNatureResist (int32 value) { SetUInt32Value (UNIT_FIELD_RESISTANCES + DMG_NATURE, value); }
	inline void SetFrostResist (int32 value) { SetUInt32Value (UNIT_FIELD_RESISTANCES + DMG_FROST, value); }
	inline void SetShadowResist (int32 value) { SetUInt32Value (UNIT_FIELD_RESISTANCES + DMG_SHADOW, value); }
	inline void SetArcaneResist (int32 value) { SetUInt32Value (UNIT_FIELD_RESISTANCES + DMG_ARCANE, value); }

	virtual void SetPosStrength (int32 value) {}
	virtual void SetPosAgility (int32 value) {}
	virtual void SetPosStamina (int32 value) {}
	virtual void SetPosIntellect (int32 value) {}
	virtual void SetPosSpirit (int32 value) {}

	virtual void SetNegStrength (int32 value) {}
	virtual void SetNegAgility (int32 value) {}
	virtual void SetNegStamina (int32 value) {}
	virtual void SetNegIntellect (int32 value) {}
	virtual void SetNegSpirit (int32 value) {}

	// Change respectable stats when some major stat changes
	//
	void OnModifyStrength (int32 d);
	void OnModifyAgility (int32 d);
	void OnModifyStamina (int32 d);
	void OnModifyIntellect (int32 d);

	//------------------------------
	//  Combat related UpdateFields
	//------------------------------
	inline float  GetCritChance() { return m_critChance; }
	inline void ModifyCritChance (float d) { SetCritChance (GetCritChance() + d); }
	virtual void SetCritChance (float value) { m_critChance = value; }

	inline float  GetRangedCritChance() { return m_critRangedChance; }
	inline void ModifyRangedCritChance (float d) { SetRangedCritChance (GetRangedCritChance() + d); }
	virtual void SetRangedCritChance (float value) { m_critRangedChance = value; }

	inline float  GetDodgeChance() { return m_dodgeChance; }
	inline void ModifyDodgeChance (float d) { SetDodgeChance (GetDodgeChance() + d); }
	virtual void SetDodgeChance (float value) { m_dodgeChance = value; }

	inline float  GetParryChance() { return m_parryChance; }
	inline void ModifyParryChance (float d) { SetParryChance (GetParryChance() + d); }
	virtual void SetParryChance (float value) { m_parryChance = value; }

	inline float  GetBlockChance() { return m_blockChance; }
	inline void ModifyBlockChance (float d) { SetBlockChance (GetBlockChance() + d); }
	virtual void SetBlockChance (float value) { m_blockChance = value; }

	//inline uint64 GetPersuaded() { return GetUInt64Value (UNIT_FIELD_PERSUADED); }
	//void SetPersuaded (uint64 value) { SetUInt64Value (UNIT_FIELD_PERSUADED, value); }

	// For mobs melee skill is always maximum available for level
	virtual int32 GetCurrentMeleeSkill() { return GetLevel() * 5; }

	// Block Value
	inline float	GetBlockValue()				{ return m_blockValue; }
	inline void		ModifyBlockValue (float d)	{ SetBlockValue (GetBlockValue() + d); }
	virtual void	SetBlockValue (float value) { m_blockValue = value; }

	//--------------------------------
	// Melee and Ranged Attack Power
	//--------------------------------
	inline int32 GetAttackPower() { return (int32)GetUInt32Value (UNIT_FIELD_ATTACKPOWER); }
	inline void ModifyAttackPower (int32 d) { SetAttackPower (GetAttackPower() + d); }
	void SetAttackPower (int32 value);

	inline int32 GetRangedAttackPower() { return (int32)GetUInt32Value (UNIT_FIELD_RANGEDATTACKPOWER); }
	inline void ModifyRangedAttackPower (int32 d) { SetRangedAttackPower (GetRangedAttackPower() + d); }
	//void SetRangedAttackPower (int32 value) { SetUInt32Value (UNIT_FIELD_RANGEDATTACKPOWER, value); }
	void SetRangedAttackPower (int32 value);

	//--------------------
	// Min and Max Damage (calculated from Unit stats and equips if Player)
	//--------------------
protected:
	float	m_minDamage, m_maxDamage;
	float   r_minDamage, r_maxDamage;

public:
	// Melee Min/Max Damage
	inline float GetMinDamage() { return m_minDamage; /* GetFloatValue (UNIT_FIELD_MINDAMAGE); */ }
	inline void ModifyMinDamage (float d) { m_minDamage += d; SetFloatValue (UNIT_FIELD_MINDAMAGE, m_minDamage); }
	void SetMinDamage (float value) { m_minDamage = value; SetFloatValue (UNIT_FIELD_MINDAMAGE, value); }

	inline float GetMaxDamage() { return m_maxDamage; /* GetFloatValue (UNIT_FIELD_MAXDAMAGE); */ }
	inline void ModifyMaxDamage (float d) { m_maxDamage += d; SetFloatValue (UNIT_FIELD_MAXDAMAGE, m_maxDamage); }
	void SetMaxDamage (float value) { m_maxDamage = value; SetFloatValue (UNIT_FIELD_MAXDAMAGE, value); }

	// Ranged Min/Max Damage
	inline float GetRangedMinDamage() { return r_minDamage; /* GetFloatValue (UNIT_FIELD_MINRANGEDDAMAGE); */ }
	inline void	ModifyRangedMinDamage (float d) { r_minDamage += d; SetFloatValue (UNIT_FIELD_MINRANGEDDAMAGE, r_minDamage); }
	void SetRangedMinDamage (float value) { r_minDamage = value; SetFloatValue (UNIT_FIELD_MINRANGEDDAMAGE, value); }

	inline float GetRangedMaxDamage() { return r_maxDamage; /* GetFloatValue (UNIT_FIELD_MAXRANGEDDAMAGE); */ }
	inline void	ModifyRangedMaxDamage (float d) { r_maxDamage += d; SetFloatValue (UNIT_FIELD_MAXRANGEDDAMAGE, r_maxDamage); }
	void SetRangedMaxDamage (float value) { r_maxDamage = value; SetFloatValue (UNIT_FIELD_MAXRANGEDDAMAGE, value); }

	//------------------------------
	// Base and Ranged Attack times
	//------------------------------
	// GET
	inline int32 GetBaseAttackTime1() { return (int32)GetUInt32Value (UNIT_FIELD_BASEATTACKTIME + 0); }
	inline int32 GetBaseAttackTime2() { return (int32)GetUInt32Value (UNIT_FIELD_BASEATTACKTIME + 1); }
	inline int32 GetRangedAttackTime() { return (int32)GetUInt32Value (UNIT_FIELD_RANGEDATTACKTIME); }

	// SET
	inline void SetBaseAttackTime1(int32 value)	{SetUInt32Value (UNIT_FIELD_BASEATTACKTIME + 0, value); }
	inline void SetBaseAttackTime2(int32 value)	{SetUInt32Value (UNIT_FIELD_BASEATTACKTIME + 1, value); }
	inline void SetRangedAttackTime(int32 value)	{SetUInt32Value (UNIT_FIELD_RANGEDATTACKTIME, value); }

	//--------------------------------------------------------
	inline uint32 GetNpcFlags() { return GetUInt32Value (UNIT_NPC_FLAGS); }
	inline void SetNpcFlags (uint32 flags) { SetUInt32Value (UNIT_NPC_FLAGS, flags); }

	inline uint32 GetFaction() { return GetUInt32Value (UNIT_FIELD_FACTIONTEMPLATE); }
	inline void SetFaction (uint32 fact) { SetUInt32Value (UNIT_FIELD_FACTIONTEMPLATE, fact); }

	inline uint64 GetTarget() { return GetUInt64Value (UNIT_FIELD_TARGET); }
	inline void SetTarget (uint64 guid)
	{
		if (GetTarget() != guid)
			SetUInt64Value (UNIT_FIELD_TARGET, guid);
	}

	// NPC Equiping function
	void VirtualEquip (uint8 count, uint32 slot, uint32 model, uint32 data);


	//-------------------------------------
	// Emotions (NPC) and Messages
	//-------------------------------------
	void Say (Unit *receiver, const char *text, Language language=LANG_UNIVERSAL);
	void Emote (EmoteType emote);


	//--------------------------------------------------------
	//  Movement Speeds
	//--------------------------------------------------------
protected:
	float	m_speedMod;
public:
	float GetSpeedMod() { return m_speedMod; }
	virtual void ModifySpeedMod (float scale) { m_speedMod *= scale; }
	virtual void SetSpeedMod (float value) { m_speedMod = value; }

	//--------------------------------------------------------
	// Stealth and detection
	//--------------------------------------------------------
protected:
	int32	m_stealthLevel;
	int32	m_stealthDetectBonus;
public:
	bool isStealth() { return m_stealthLevel > 0; }
	int32 GetStealthLevel() { return m_stealthLevel; }
	int32 GetStealthDetect() { return 5 * (int32)GetLevel() + m_stealthDetectBonus; }
	void LoseStealth();	// lose all known stealth abilities

	//--------------------------------------------------------
    //  Combat
	//--------------------------------------------------------

	// TODO: Some awesome formula to determine how much damage to deal
	// additionalSpellId - reference to uint32, set to spell id for additional damages
	uint32 CalculateDamage (uint32 &additionalSpellId, uint32 &additionalSpellDmg);

	// Adds and subtracts damages according to buffs and debuffs
	virtual float CalculateDamageMods (float dmg) { return dmg; }

	void DealDamage(Unit *pVictim, uint32 damage);
	void TakeDamage (uint32 damage);
    void AttackerStateUpdate(Unit *pVictim, uint32 damage,bool DoT);
    void PeriodicAuraLog(Unit *pVictim, uint32 spellID, uint32 damage, uint32 damageType);
    void SpellNonMeleeDamageLog(Unit *pVictim, uint32 spellID, uint32 damage);

	// called when victim died
	void UnitDeath (Unit *pKiller, bool isCritterVictim);

    void smsg_AttackStart(Unit* pVictim);
    void smsg_AttackStop(uint64 victimGuid);

    /*virtual void RemoveInRangeObject(Object* pObj)
    {
        if (pObj->isPlayer() || pObj->isUnit())
			RemoveHate ((Unit *)pObj);

		Object::RemoveInRangeObject(pObj);
    }*/

	virtual bool CanSee (Object *npc);

	virtual bool isVendor()       { return HasFlag( UNIT_NPC_FLAGS, UNIT_NPC_FLAG_VENDOR ); };
	virtual bool isTrainer()      { return HasFlag( UNIT_NPC_FLAGS, UNIT_NPC_FLAG_TRAINER ); };
	virtual bool isQuestGiver()   { return HasFlag( UNIT_NPC_FLAGS, UNIT_NPC_FLAG_QUESTGIVER ); };
	virtual bool isGossip()       { return HasFlag( UNIT_NPC_FLAGS, UNIT_NPC_FLAG_GOSSIP ); };
	virtual bool isTaxi()         { return HasFlag( UNIT_NPC_FLAGS, UNIT_NPC_FLAG_TAXIVENDOR ); };
	virtual bool isGuildMaster()  { return HasFlag( UNIT_NPC_FLAGS, UNIT_NPC_FLAG_PETITIONER ); };
	virtual bool isBattleMaster() { return HasFlag( UNIT_NPC_FLAGS, UNIT_NPC_FLAG_BATTLEFIELDPERSON ); };
	virtual bool isBanker()       { return HasFlag( UNIT_NPC_FLAGS, UNIT_NPC_FLAG_BANKER ); };
	virtual bool isInnkeeper()    { return HasFlag( UNIT_NPC_FLAGS, UNIT_NPC_FLAG_INNKEEPER ); };
	virtual bool isSpiritHealer() { return HasFlag( UNIT_NPC_FLAGS, UNIT_NPC_FLAG_SPIRITHEALER ); };
	virtual bool isTabardVendor() { return HasFlag( UNIT_NPC_FLAGS, UNIT_NPC_FLAG_TABARDVENDOR ); };
	virtual bool isAuctioner()    { return HasFlag( UNIT_NPC_FLAGS, UNIT_NPC_FLAG_AUCTIONEER ); };
	virtual bool isArmorer()      { return HasFlag( UNIT_NPC_FLAGS, UNIT_NPC_FLAG_ARMORER ); };

	//--------------------------------------------------------
    //  Personal Status (alive, dead, stunned, frozen, etc)
	//--------------------------------------------------------
    virtual bool isAlive() { return m_deathState == ALIVE; };
    virtual bool isDead() {
		return ( m_deathState == DEAD ||
			m_deathState == CORPSE ||
			m_deathState == JUST_DIED); 
	};

    virtual void setDeathState(DeathState s) {
        m_deathState = s;
    };
    DeathState getDeathState() { return m_deathState; }

	bool isStunned();

    //! Add affect to unit
    bool AddAffect(Affect *aff, bool uniq = false);
    //! Remove affect from unit
    void RemoveAffect(Affect *aff);
    //! Remove all affects with specified type
    bool RemoveAffect(uint32 type);
    void RemoveAffectById(uint32 spellId);
    //! Remove all affects
    void RemoveAllAffects();
    void SetAura(Affect* aff){ m_aura = aff; }
    bool SetAffDuration(uint32 spellId,Unit* caster,uint32 duration);
    Affect* tmpAffect;

    //! Player should override it to use POS/NEG fields
    virtual void ApplyModifier(const Modifier *mod, bool apply, Affect* parent);

    void castSpell(Spell * pSpell);
    void InterruptSpell();

    bool m_meleeSpell;
    
	uint32 m_addDmgOnce;			// damage increase for one next hit and spell for it
	uint32 m_addDmgOnceSpell;
	float  m_amplifyDmgOnce;		// damage amplify for one next hit and spell for it
	uint32 m_amplifyDmgOnceSpell;

    uint64 m_TotemSlot1;
    uint64 m_TotemSlot2;
    uint64 m_TotemSlot3;
    uint64 m_TotemSlot4;
    uint32 m_triggerSpell;
    uint32 m_triggerDamage;

    // Use it to Check if a Unit is in front of another one
    bool isInFront (Unit* target,float distance);

    // Spell Effect Variables
    bool m_silenced;

	// Event method called when Unit takes any damage from other Unit
	void OnTakeDamage (Unit *attacker);


	// Set the Minimap Tracking On or Off
	// 
	void MinimapTrackingStatus( bool bEnabled );

protected:
    Unit ( );

	float	m_critChance;
	float	m_critRangedChance;
	float	m_dodgeChance;
	float	m_parryChance;
	float	m_blockChance;
	uint32	m_blockValue;

	void _ResetBaseStats();
    //! Temporary remove all affects
    void _RemoveAllAffectMods();
    //! Place all mods back
    void _ApplyAllAffectMods();

    void _AddAura(Affect *aff);
    void _RemoveAura(Affect *aff);
    Affect* FindAff(uint32 spellId);

    void _UpdateSpells (int32 time);
    void _UpdateAura();

    Affect* m_aura;
    int32 m_auraCheck;

    // FIXME: implement it
    bool _IsAffectPositive(Affect *aff) { return true; }

    uint32 m_state;         // flags for keeping track of some states
    int32 m_attackTimer;	// timer for attack

    /// Combat
    DeathState m_deathState;

    typedef list<Affect*> AffectList;
    AffectList m_affects;

    // Spell currently casting
    Spell * m_currentSpell;

public:
	static Unit *WorldGetUnit (uint64 guid);
};

// Some Functions for isInFront Calculation ( thanks to emperor and undefined for the formula )
bool InArc (float radius,  float xM, float yM, float offnung, float orientation, float xP, float yP); // Main Function called by isInFront();
float GetEasyAngle (float angle);// converts to 360 > x > 0
float GetAngle (float xe, float ye, float xz, float yz);
float GetDistance (float xe, float ye, float xz, float yz);
float GetDistanceSq (float xe, float ye, float xz, float yz);

#endif
