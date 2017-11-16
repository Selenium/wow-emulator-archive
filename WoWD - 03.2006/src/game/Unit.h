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

#ifndef __UNIT_H
#define __UNIT_H

class AIInterface;
#include "Object.h"
#include "AIInterface.h"



#define UF_TARGET_DIED  1
#define UF_ATTACKING    2 // this unit is attacking it's selection

class Affect;
class Modifier;
class Spell;
class AIInterface;

struct CreatureInfo;

enum DeathState
{
	ALIVE = 0,  // Unit is alive and well
	JUST_DIED,  // Unit has JUST died
	CORPSE,     // Unit has died but remains in the world as a corpse
	DEAD        // Unit is dead and his corpse is gone from the world
};

#define HIGHEST_FACTION = 46
enum Factions {
	FACTION_BLOODSAIL_BUCCANEERS,
	FACTION_BOOTY_BAY,
	FACTION_GELKIS_CLAN_CENTAUR,
	FACTION_MAGRAM_CLAN_CENTAUR,
	FACTION_THORIUM_BROTHERHOOD,
	FACTION_RAVENHOLDT,
	FACTION_SYNDICATE,
	FACTION_GADGETZAN,
	FACTION_WILDHAMMER_CLAN,
	FACTION_RATCHET,
	FACTION_UNK1,
	FACTION_UNK2,
	FACTION_UNK3,
	FACTION_ARGENT_DAWN,
	FACTION_ORGRIMMAR,
	FACTION_DARKSPEAR_TROLLS,
	FACTION_THUNDER_BLUFF,
	FACTION_UNDERCITY,
	FACTION_GNOMEREGAN_EXILES,
	FACTION_STORMWIND,
	FACTION_IRONFORGE,
	FACTION_DARNASSUS,
	FACTION_LEATHERWORKING_DRAGON,
	FACTION_LEATHERWORKING_ELEMENTAL,
	FACTION_LEATHERWORKING_TRIBAL,
	FACTION_ENGINEERING_GNOME,
	FACTION_ENGINEERING_GOBLIN,
	FACTION_WINTERSABER_TRAINERS,
	FACTION_EVERLOOK,
	FACTION_BLACKSMITHING_ARMOR,
	FACTION_BLACKSMITHING_WEAPON,
	FACTION_BLACKSMITHING_AXE,
	FACTION_BLACKSMITHING_SWORD,
	FACTION_BLACKSMITHING_HAMMER,
	FACTION_CAER_DARROW,
	FACTION_TIMBERMAW_FURBOLGS,
	FACTION_CENARION_CIRCLE,
	FACTION_SHATTERSPEAR_TROLLS,
	FACTION_RAVASAUR_TRAINERS,
	FACTION_BATTLEGROUND_NEUTRAL,
	FACTION_STORMPIKE_GUARDS,
	FACTION_FROSTWOLF_CLAN,
	FACTION_HYDRAXIAN_WATERLORDS,
	FACTION_MORO_GAI,
	FACTION_SHEN_DRALAR,
	FACTION_SILVERWING_SENTINELS,
	FACTION_WARSONG_OUTRIDERS
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

enum UnitFieldFlags
{
	U_FIELD_FLAG_LOCK_PLAYER				= 0x04,
	U_FIELD_FLAG_PLAYER_CONTROLLED			= 0x08,
	U_FIELD_FLAG_PLUS_MOB					= 0x40,
	U_FIELD_FLAG_PVP						= 0x1000,
	//U_FIELD_FLAG_MOUNT_VISIBLE				= 0x1000,?
	U_FIELD_FLAG_MOUNT_SIT					= 0x2000,
	U_FIELD_FLAG_DEAD						= 0x4000,
	U_FIELD_FLAG_DUEL_WINNER				= 0x40000,
	U_FIELD_FLAG_ATTACK_ANIMATION			= 0x80000,
	U_FIELD_FLAG_STAR_AFTER_NAME			= 0x100000,
	U_FIELD_FLAG_SKINNABLE					= 0x4000000,
	U_FIELD_FLAG_ALIVE						= 0x10000, 
	U_FIELD_FLAG_WEAPON_OFF					= 0x40000000,
	//U_FIELD_FLAG_MAKE_CHAR_UNTOUCHABLE		= 0x8000000,
};

enum UnitDynamicFlags
{
	U_DYN_FLAG_LOOTABLE						= 0x01,
	U_DYN_FLAG_UNIT_TRACKABLE				= 0x02,
	U_DYN_FLAG_TAGGED_BY_OTHER				= 0x04,
	U_DYN_FLAG_TAPPED_BY_PLAYER				= 0x08,
	U_DYN_FLAG_PLAYER_INFO					= 0x10,
	U_DYN_FLAG_DEAD							= 0x20,
};

enum AffectTickFlags
{
    FLAG_PERIODIC_DAMAGE                    = 2,
    FLAG_PERIODIC_TRIGGER_SPELL             = 4,
    FLAG_PERIODIC_HEAL                      = 8,
    FLAG_PERIODIC_LEECH                     = 16,
    FLAG_PERIODIC_ENERGIZE                  = 32
};

enum DamageFlags
{
    DAMAGE_FLAG_MELEE = 1,
    DAMAGE_FLAG_HOLY = 2,
    DAMAGE_FLAG_FIRE = 4,
    DAMAGE_FLAG_NATURE = 8,
    DAMAGE_FLAG_FROST = 16,
    DAMAGE_FLAG_SHADOW = 32,
    DAMAGE_FLAG_ARCANE = 64
};
//====================================================================
//  Unit
//  Base object for Players and Creatures
//====================================================================
class Unit : public Object
{
public:
	typedef std::set<Unit*> AttackerSet;
	virtual ~Unit ( );

	friend class AIInterface;

	virtual void Update( uint32 time );

	void setAttackTimer(uint32 time);
	bool isAttackReady() const { return m_attackTimer == 0; }
	bool canReachWithAttack(Unit *pVictim);
	CreatureInfo *GetCreatureName();
	void SetCreatureName(CreatureInfo *ci) { creature_info = ci; }

	/// State flags are server-only flags to help me know when to do stuff, like die, or attack
	inline void addStateFlag(uint32 f) { m_state |= f; };
	inline void clearStateFlag(uint32 f) { m_state &= ~f; };

	/// Stats
	inline uint8 getLevel() { return (uint8)m_uint32Values[ UNIT_FIELD_LEVEL ]; };
	inline uint8 getRace() { return (uint8)m_uint32Values[ UNIT_FIELD_BYTES_0 ] & 0xFF; };
	inline uint8 getClass() { return (uint8)(m_uint32Values[ UNIT_FIELD_BYTES_0 ] >> 8) & 0xFF; };
	inline uint8 getGender() { return (uint8)(m_uint32Values[ UNIT_FIELD_BYTES_0 ] >> 16) & 0xFF; };
	inline uint8 getStandState() { return (uint8)m_uint32Values[ UNIT_FIELD_BYTES_1 ] & 0xFF; };
	void StatListener();
	void CalculateStat(uint16 field, int16 mod);
	void CalculateActualArmor();

	//// Combat
	void DealDamage(Unit *pVictim, uint32 damage, uint32 procFlag, uint32 targetEvent, uint32 unitEvent);
	void AttackerStateUpdate(Unit *pVictim, uint32 damage);
	void PeriodicAuraLog(Unit *pVictim, uint32 spellID, uint32 damage, uint32 damageType);
	void SpellNonMeleeDamageLog(Unit *pVictim, uint32 spellID, uint32 damage);
	//void HandleProc(ProcTriggerSpell *pts, uint32 flag) {};
	void CastSpell(Unit* caster,Unit* Victim, uint32 spellId, bool triggered);
	bool isCasting();
	void CalcRage( uint32 damage, bool isVictim );
	void RegenerateAll();
	void Regenerate(uint16 field_cur, uint16 field_max, bool switch_);
	void setRegenTimer(uint32 time) {m_regenTimer = time;};
	uint32 m_lastDamage; 	//Morph stuff  - morph into something, and out of something
	void DeMorph();

	void smsg_AttackStart(Unit* pVictim);
	void smsg_AttackStop(uint64 victimGuid);

	virtual void RemoveInRangeObject(Object* pObj);

	/// Combat / Death Status
	bool isAlive() { return m_deathState == ALIVE; };
	bool isDead() { return ( m_deathState == DEAD || m_deathState == CORPSE ); };
	virtual void setDeathState(DeathState s) {
		m_deathState = s;
	};
	DeathState getDeathState() { return m_deathState; }

	//! Add affect to unit
	bool AddAffect(Affect *aff, bool uniq = false);
	//! Remove affect from unit
	void RemoveAffect(Affect *aff);
	//! Remove all affects with specified type
	bool RemoveAffect(uint32 spellId);
	void RemoveAffectById(uint32 spellId);
	void RemoveAffectByIdAndGuid(uint32 spellId,uint64 guid);
	//! Remove all affects
	void RemoveAllAffects();
	void SetAura(Affect* aff){ m_aura = aff; }
	bool SetAffDuration(uint32 spellId,Unit* caster,uint32 duration);
	uint32 GetAffDuration(uint32 spellId,Unit* caster);
	Affect* tmpAffect;
	std::list<Affect*>::iterator GetAffectBegin() { return m_affects.begin();};
	std::list<Affect*>::iterator GetAffectEnd() { return m_affects.end();};

	uint32 GetDamageModTaken(uint32 damage, bool PCT, uint32 school);
    uint32 GetDamageModTakenMelee(uint32 damage, bool PCT);
	uint32 GetDamageModTakenSpells(uint32 damage, bool PCT);

	uint32 GetDamageModGiven(uint32 type);
	uint32 GetDamageModGivenPercent(uint32 type);
	uint32 GetDamageModGivenSpells();
	uint32 GetDamageModGivenSpellsPercent();

    //TODO:Some of the functions can be reduced to one function
    uint32 SplitDamagePCT(uint32 damage, uint32 type);
    void GetPowerRegenPCT(float *hr, float *mr, float *rr, float *er);
    uint32 GetSchoolAbsorb(uint32 damage, uint32 school);
    bool GetManaShieldAbsorb(uint32 damage,Unit *pVictim);
    void DamageHeal(uint32 damage);

	//! Player should override it to use POS/NEG fields
	virtual void ApplyModifier(const Modifier *mod, bool apply, Affect* parent);

	void castSpell(Spell * pSpell);
	void InterruptSpell();
	bool m_meleeSpell;
	uint32 m_addDmgOnce;
	uint64 m_TotemSlot1;
	uint64 m_TotemSlot2;
	uint64 m_TotemSlot3;
	uint64 m_TotemSlot4;
	uint32 m_triggerSpell;
	uint32 m_triggerDamage;
	uint32 m_canMove;

	uint32 s_stats[5];

	// Spell Effect Variables
	uint16 m_silenced;
	bool HasAffects();
	std::list<struct DamageShield> m_damageShields;
	std::list<struct ProcTriggerSpell> m_procSpells;
	void SetOnMeleeSpell(uint32 spell ) { m_meleespell = spell; }
	uint32 GetOnMeleeSpell() { return m_meleespell; }

	// AIInterface
	AIInterface *GetAIInterface() { return m_aiInterface; };
	void WipeHateList();
	void WipeTargetList();
	void _setFaction();
	uint32 myFaction;
	uint32 hostile;
	uint32 combatSupport;

	// DK:Affect
	uint16 IsDamageImmune() { return m_damageImmune; }
    uint16 IsPacified() { return m_pacified; }
    uint16 IsStunned() { return m_stunned; }
    uint16 HasMeleeDamageSplit() { return m_meleeDamageSplitPCT; }
    uint16 HasSpellDamageSplit() { return m_spellDamageSplitPCT; }
	uint32 GetResistChanceMod() { return m_resistChance; }
	void SetResistChanceMod(uint32 amount) { m_resistChance=amount; }
	bool IsCastedCurse() { return m_castedCurse; }
	void SetCastedCurse(bool check) { m_castedCurse = check; }
    uint16 HasDamageTakenSpell() { return m_damageTakenSpell; }
    uint16 HasDamageTakenMelee() { return m_meleeDamageTaken; }
    uint16 HasDamageTakenMeleePCT() { return m_meleeDamageTakenPCT; }
    uint16 HasDamageTakenPCT() { return m_damageTakenPCT; }
    uint16 HasSchoolAbsorb() { return m_schoolAbsorb; }
    bool HasManaShield() { return m_manaShield; }
    uint16 HasDamageHeal() { return m_damageHeal; }

	void Emote (EmoteType emote);

	inline void SetStandState (uint8 standstate) {
		uint32 bytes1 = GetUInt32Value (UNIT_FIELD_BYTES_1);
		SetUInt32Value (UNIT_FIELD_BYTES_1, (bytes1 & ~0xFF) | uint8(standstate));
	}

	inline StandState GetStandState() {
		uint32 bytes1 = GetUInt32Value (UNIT_FIELD_BYTES_1);
		return StandState (uint8 (bytes1));
	}

	void SendChatMessage(uint8 type, uint32 lang, const char *msg);

	void LoadAIAgents();

	uint32 PhysicalArmor;
	uint32 MagicalArmor;
	uint32 ActualArmor;

	//Pet
	bool IsPet()
	{
		if(GetUInt64Value(UNIT_FIELD_SUMMONEDBY) > 0)
			return true;
		return false;
	}
	bool isInCombat() { return m_state & UF_ATTACKING;}

    uint32 CalculateDamageExt();
	
protected:
	Unit ( );

	uint32 m_meleespell;
	float m_speed;
	bool hasAffects;
	//! Temporary remove all affects
	void _RemoveAllAffectMods();
	//! Place all mods back
	void _ApplyAllAffectMods();

	void _AddAura(Affect *aff);
	void _RemoveAura(Affect *aff);
	Affect* FindAff(uint32 spellId);
	Affect* FindAff(uint32 spellId, uint64 guid);

	void _UpdateSpells(uint32 time);
	void _UpdateAura();

	Affect* m_aura;
	uint32 m_auraCheck, m_removeAuraTimer;

	// FIXME: implement it
	bool _IsAffectPositive(Affect *aff) { return true; }

	uint32 m_regenTimer;
	uint32 m_state;         // flags for keeping track of some states
	uint32 m_attackTimer;   // timer for attack

	/// Combat
	DeathState m_deathState;

	typedef std::list<Affect*> AffectList;
	AffectList m_affects;

	// DK:pet
	uint32 m_pet_state;
	bool m_Pet;

	// Spell currently casting
	Spell * m_currentSpell;

	// AI
	AIInterface *m_aiInterface;
	bool m_useAI;
	CreatureInfo *creature_info;

	//	float getDistance( float Position1X, float Position1Y, float Position2X, float Position2Y );

	// Affect checks
	uint16 m_damageImmune;
    uint16 m_pacified;
	bool m_manaShield;
	uint16 m_interruptRegen;
	uint32 m_resistChance;
    uint16 m_meleeDamageSplitPCT;
    uint16 m_spellDamageSplitPCT;
    uint16 m_powerRegenPCT;
    uint16 m_damageTakenSpell;
    uint16 m_meleeDamageTaken;
    uint16 m_meleeDamageTakenPCT;
    uint16 m_damageTakenPCT;
    uint16 m_schoolAbsorb;
    uint16 m_damageHeal;
    uint16 m_stunned;
    uint16 m_polymorphImmunity;

	//Spell related
	bool m_castedCurse;
};

#endif
