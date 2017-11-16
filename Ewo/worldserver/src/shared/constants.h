// Copyright (C) 2006 Team Evolution
#pragma once
#include "common.h"
/////////////////////////////// worldserverr constants /////////////////////////////////
#define WORLD_MIN_UPDATE_INTERVAL 500 //1 second
#define WORLD_EVENT_UPDATE_NUMBER 1
#define WORLD_EVENT_UPDATE_CHAR 0
#define WORLD_EVENT_UPDATE_CHAR_INTERVAL 500
#define CLIENT_PACKET_PROCESS_TIME_MIN 500 //client needs time to process packets, if we send them too fast they owerwrite each other :(

//#define SERVER_DOTA_COMPILATION 1 //will disable some functionalitys that are not required for dota

#define SERVER_ADVERTISE_VERSION "|cdf0000AA Welcome to |cdfAA0000 EWO server |cdfFFFFFFv. Demo20070221"

//comment this to not use some debug code in source
//#define DEBUG_MAPMANAGER_VERSION 1
//#define DEBUG_CREATURE_VERSION 1
//#define DEBUG_CHAR_VERSION 1
//#define SAVE_CHARACTERS_ON_SERVER_CRASH //use this compile option in case you wish to save characters that are in game when server crashes

#ifdef _DEBUG
//	#define VERSION_CHAR_MAKE_CREAUTURE_WPOINTS 1 //!!this is a special version when char will teleport to creature locations and get them a valid Z cord
	#define CHAR_MAKE_CREATURE_WAYPOINT_LIFT_Z 1 // add this value to creature spawn z and see if we can fall safely to ground
	#define CHAR_STATE_TO_DO_CREATURE_CORDS 0x01000000
	#define CHAR_STATE_TO_DO_CREATURE_CORDS_BEFORE_FALL 0x10000000
	#define CHAR_STATE_TO_DO_CREATURE_CORDS_AFTER_FALL 0x00100000
	#define CHAR_STATE_TO_DO_CREATURE_CORDS_FALL_TIMEOUT 3000 //given in MS
	#define CHAR_STATE_TO_DO_CREATURE_CORDS_RETRY_UNTIL_DELETE 3 //-> 20==10*(CHAR_MAKE_CREATURE_WAYPOINT_LIFT_Z+1) z lift and still no ground 
	#define CHAR_STATE_TO_DO_CREATURE_CORDS_LIFT_CREATURES 0.1f //client might send us a smaller z cord then actually would be good for us so we lift them a littlebit
	#define CHAR_STATE_TO_DO_CREATURE_CORDS_ACCEEPTED_ELEVATION_DIFFRENCE 3.0f //if creature waypoint is way different then the spawning z then it is probably wrong and we remove it
#endif
//#define AURA_CAN_EXPIRE_DIFFRENTLY_FOR_SPELLS 1

#define DUEL_AREA_RANGE_SQ		2500

//#define DISABLE_CUSTOM_TRIGGER_CHECKS 1 //this can greatly boost server speed 
#define DISABLE_CUSTOM_TRIGGER_CHECKS_FOR_CREATURES 1

#define LIMIT_CHARS_PER_REALM 3

#define AREATRIGGER_CHECK_RESOLUTION 4.0f //you must move atleast this amout so areatriggers will be checked again
#define MIN_MAX_DMG_RELATION 1.25f //sometimes max dmg is not defined :S

#define MAX_GROUP_SIZE 5

#define UNDERWATER_DISTANCE 0.2
#define UNDERWATER_BREATH_TIMER 25000 //we can breath for 6 seconds underwater
#define UNDERWATER_DMG 0.0002f	//heath taken each ms!. (10 heath per second)

#define MAX_AURAS 64 //this was 56 but there are 64 values in updatefields
#define MAX_POSITIVE_AURAS 32 

#define CHARACTER_MOVE_TO_UPDATE_AGRO	5
#define CHAR_SPELL_QUEUE_MAXLEN 7
#define CHAR_FORCE_RESURECT_TIME 360000 //6*60*1000 = 6 minutes

#define CHARACTER_HEALTH_REGEN_COMBAT_PER_MS 0.001f
#define CHARACTER_MANA_REGEN_COMBAT_PER_MS 0.002f
#define CHARACTER_HEALTH_REGEN_REST_PER_MS 0.005f
#define CHARACTER_MANA_REGEN_REST_PER_MS 0.005f

#define AGRO_PROPAGATION_MAX_RANGE_SQUARE	400 //20 smaller then the avarege spell cast range. It is good to 
#define AGRO_PROPAGATION_MAX_RANGE	10 //10 smaller then the avarege spell cast range. It is good to 
#define AGRO_LVL_DIFRENCE	10	//creatures with lvl smaller then X will not get agroed
#define SPELL_AGRO_VALUE_TO_DRAW_ATTENTION 1000

#define CREATURE_EXTRA_XP_COEF		1
#define CREATURE_EXTRA_GOLD_COEF	1

#define CHAR_MAX_LEVEL 70

#define PLAYER_MAX_STAT_TYPES 5
#define PLAYER_MAX_DMG_TYPES 7 //equal to the 7 tipes of dmg types (magic types too)
#define PLAYER_USED_DMG_TYPES 7
#define CERATURE_MAX_DMG_TYPES 7 
#define CREATURE_USED_DMG_TYPES 7

#define MINIMAL_DAMAGE_APPLYABLE 0

#define MAX_RANDOM_LOOTS_FOR_OBJECT 3
#define MAX_STATIC_LOOTS_FOR_OBJECT 5
#define MAX_LOOTS_FOR_OBJECT (MAX_RANDOM_LOOTS_FOR_OBJECT+MAX_STATIC_LOOTS_FOR_OBJECT)

#define PLAYER_CHANCE_TO_LOOSE_DURABILITY 5

#define PI 3.1415926538f

#define MAX_TIME_FOR_AURAS 604800 //amount of time in MS until aura will trigger again

#define PLAY_SPELL_VISUAL_DELAY	2000

#define UNITS_BASE_THREAT_GENERATE 10 //make sure this value is greater then basic dmg so threat modify spells can have effect
//on each block change the agro is sent out again
#define PLAYER_AGRO_SEND_TIME_INTERVAL	2 //meaured in server cycles
#define CREATURE_AGRO_SEND_TIME_INTERVAL	20 //meaured in server cycles. aprox 10 seconds if server cycles is 500 ms

#define CHARACTER_MAX_TOTEMS	5
//get info
/*
struct movement_info{
	//do not change the order of the data
	uint32 flags, time;
	float x, y, z, orientation;
	uint64 unk1;
	float unk2, unk3, unk4, unk5;
	float unk6;
	uint32 FallTime;
	float unk8, unk9, unk10, unk11, unk12;
};*/

class Character;
class gameobject_instance;

enum Duel_State_Flags
{
	DUEL_STATE_NOT_STARTED		= 0,
	DUEL_STATE_STARTED			= 1,
	DUEL_STATE_FINISHED			= 2,
};

struct Duel_Info
{
	uint32					atimer1;//when will this object change it's state
	uint32					spell_id;
	Character				*initiator;
	Character				*target;
	gameobject_instance		*dual_arbiter;//could be anything. Right now a gameobject is used
};

struct item_enchantment_def
{
	uint32	id;
	uint32	dispel_type;
	uint32	spell_value;//force spell to cast with this value (probably not used anymore)
	uint32	spell_id[3];
	uint32	aura_name[2];
};

struct item_random_property_def
{
	//contains 3 enchantments
	item_enchantment_def *ench[3];
};

#define PLAYER_SKILL_ENTRY_NUMBER 32 //(PLAYER_CHARACTER_POINTS1-PLAYER_SKILL_INFO_1_1)/sizeof(skill_entry)=>32

enum Group_command_result_codes
{
	GROUP_COMMAND_OK					= 0,
	GROUP_COMMAND_PLAYER_NOT_FOUND		= 1,
	GROUP_COMMAND_GROUP_IS_FULL			= 3,
	GROUP_COMMAND_ALREADY_IN_GROUP		= 4,
	GROUP_COMMAND_YOU_MUST_BE_LEADER	= 6,
	GROUP_COMMAND_NO_TEAM_INTERRACTION	= 7,
};

enum Spell_Atribute_Ext_Flags
{
	SPELL_ATRIBUTE_REQUIRE_TARGET_BEHIND		= 0x050010,
	SPELL_ATRIBUTE_REQUIRE_TARGET_STEALTH		= 0x220000,
};

enum Spell_animation_types
{
	SPELL_ANIMATION_EAT			= 406,
	SPELL_ANIMATION_DRINK		= 438,
	SPELL_ANIMATION_UNK1		= 701, //found at some creature
};

enum FriendsResult {
    FRIEND_DB_ERROR                               = 0x00,
    FRIEND_LIST_FULL                              = 0x01,
    FRIEND_ONLINE                                 = 0x02,
    FRIEND_OFFLINE                                = 0x03,
    FRIEND_NOT_FOUND                              = 0x04,
    FRIEND_REMOVED                                = 0x05,
    FRIEND_ADDED_ONLINE                           = 0x06,
    FRIEND_ADDED_OFFLINE                          = 0x07,
    FRIEND_ALREADY                                = 0x08,
    FRIEND_SELF                                   = 0x09,
    FRIEND_ENEMY                                  = 0x0A,
    FRIEND_IGNORE_FULL                            = 0x0B,
    FRIEND_IGNORE_SELF                            = 0x0C,
    FRIEND_IGNORE_NOT_FOUND                       = 0x0D,
    FRIEND_IGNORE_ALREADY                         = 0x0E,
    FRIEND_IGNORE_ADDED                           = 0x0F,
    FRIEND_IGNORE_REMOVED                         = 0x10
};

enum ChatMsgNew
{
    CHAT_MSG_SAY								=0,
    CHAT_MSG_PARTY								=1,
    CHAT_MSG_RAID								=2,
    CHAT_MSG_GUILD								=3,
    CHAT_MSG_OFFICER							=4,
    CHAT_MSG_YELL								=5,
    CHAT_MSG_WHISPER							=6,
    CHAT_MSG_WHISPER_INFORM						=7,
    CHAT_MSG_EMOTE								=8,
    CHAT_MSG_TEXT_EMOTE							=9,
    CHAT_MSG_SYSTEM								=10,
    CHAT_MSG_MONSTER_SAY						=11,
    CHAT_MSG_MONSTER_YELL						=12,
    CHAT_MSG_MONSTER_EMOTE						=13,//maybe this is not emote at all
    CHAT_MSG_CHANNEL							=14,
    CHAT_MSG_CHANNEL_JOIN						=15,
    CHAT_MSG_CHANNEL_LEAVE						=16,
    CHAT_MSG_CHANNEL_LIST						=17,
    CHAT_MSG_CHANNEL_NOTICE						=18,
    CHAT_MSG_CHANNEL_NOTICE_USER				=19,
    CHAT_MSG_AFK								=20,
    CHAT_MSG_DND								=21,
    CHAT_MSG_IGNORED							=22,
    CHAT_MSG_SKILL								=23,
    CHAT_MSG_LOOT								=24,
    CHAT_COMBAT_MISC_INFO						=25,
    CHAT_MONSTER_WHISPER						=26,
    CHAT_COMBAT_SELF_HITS						=27,
    CHAT_COMBAT_SELF_MISSES						=28,
    CHAT_COMBAT_PET_HITS						=29,
    CHAT_COMBAT_PET_MISSES						=30,
    CHAT_COMBAT_PARTY_HITS						=31,
    CHAT_COMBAT_PARTY_MISSES					=32,
    CHAT_COMBAT_FRIENDLYPLAYER_HITS				=33,
    CHAT_COMBAT_FRIENDLYPLAYER_MISSES			=34,
    CHAT_COMBAT_HOSTILEPLAYER_HITS				=35,
    CHAT_COMBAT_HOSTILEPLAYER_MISSES			=36,
    CHAT_COMBAT_CREATURE_VS_SELF_HITS			=37,
    CHAT_COMBAT_CREATURE_VS_SELF_MISSES			=38,
    CHAT_COMBAT_CREATURE_VS_PARTY_HITS			=39,
    CHAT_COMBAT_CREATURE_VS_PARTY_MISSES		=40,
    CHAT_COMBAT_CREATURE_VS_CREATURE_HITS		=41,
    CHAT_COMBAT_CREATURE_VS_CREATURE_MISSES		=42,
    CHAT_COMBAT_FRIENDLY_DEATH					=43,
    CHAT_COMBAT_HOSTILE_DEATH					=44,
    CHAT_COMBAT_XP_GAIN							=45,
    CHAT_SPELL_SELF_DAMAGE						=46,
    CHAT_SPELL_SELF_BUFF						=47,
    CHAT_SPELL_PET_DAMAGE						=48,
    CHAT_SPELL_PET_BUFF							=49,
    CHAT_SPELL_PARTY_DAMAGE						=50,
    CHAT_SPELL_PARTY_BUFF						=51,
    CHAT_SPELL_FRIENDLYPLAYER_DAMAGE			=52,
    CHAT_SPELL_FRIENDLYPLAYER_BUFF				=53,
    CHAT_SPELL_HOSTILEPLAYER_DAMAGE				=54,
    CHAT_SPELL_HOSTILEPLAYER_BUFF				=55,
    CHAT_SPELL_CREATURE_VS_SELF_DAMAGE			=56,
    CHAT_SPELL_CREATURE_VS_SELF_BUFF			=57,
    CHAT_SPELL_CREATURE_VS_PARTY_DAMAGE			=58,
    CHAT_SPELL_CREATURE_VS_PARTY_BUFF			=59,
    CHAT_SPELL_CREATURE_VS_CREATURE_DAMAGE		=60,
    CHAT_SPELL_CREATURE_VS_CREATURE_BUFF		=61,
    CHAT_SPELL_TRADESKILLS						=62,
    CHAT_SPELL_DAMAGESHIELDS_ON_SELF			=63,
    CHAT_SPELL_DAMAGESHIELDS_ON_OTHERS			=64,
    CHAT_SPELL_AURA_GONE_SELF					=65,
    CHAT_SPELL_AURA_GONE_PARTY					=66,
    CHAT_SPELL_AURA_GONE_OTHER					=67,
    CHAT_SPELL_ITEM_ENCHANTMENTS				=68,
    CHAT_SPELL_BREAK_AURA						=69,
    CHAT_SPELL_PERIODIC_SELF_DAMAGE				=70,
    CHAT_SPELL_PERIODIC_SELF_BUFFS				=71,
    CHAT_SPELL_PERIODIC_PARTY_DAMAGE			=72,
    CHAT_SPELL_PERIODIC_PARTY_BUFFS				=73,
    CHAT_SPELL_PERIODIC_FRIENDLYPLAYER_DAMAGE	=74,
    CHAT_SPELL_PERIODIC_FRIENDLYPLAYER_BUFFS	=75,
    CHAT_SPELL_PERIODIC_HOSTILEPLAYER_DAMAGE	=76,
    CHAT_SPELL_PERIODIC_HOSTILEPLAYER_BUFFS		=77,
    CHAT_SPELL_PERIODIC_CREATURE_DAMAGE			=78,
    CHAT_SPELL_PERIODIC_CREATURE_BUFFS			=79,
    CHAT_SPELL_FAILED_LOCALPLAYER				=80,
    CHAT_COMBAT_HONOR_GAIN						=81,
    CHAT_BG_SYSTEM_NEUTRAL						=82,
    CHAT_BG_SYSTEM_ALLIANCE						=83,
    CHAT_BG_SYSTEM_HORDE						=84
};

enum Speed_Change_Types
{
	SPEED_CHANGE_TYPE_RUN		= 1,
	SPEED_CHANGE_TYPE_RUN_BACK	= 2,
	SPEED_CHANGE_TYPE_WALK		= 3,
	SPEED_CHANGE_TYPE_SWIM		= 4,
	SPEED_CHANGE_TYPE_SWIM_BACK = 5,
};

enum Cast_flags_sersided
{
	CAST_FLAG_SELF			= 1,
	CAST_FLAG_INSTANT		= 2,
	CAST_FLAG_NOMANA		= 4,
	CAST_FLAG_QUEUED		= 8,
	CAST_FLAG_FORCE_TARGET	= 16,
	CAST_FLAG_SURECAST		= 32,
};
enum EnviromentalDamage
{
   ENVIROMENTAL_DAMAGE_EXHAUSTED = 0,
   ENVIROMENTAL_DAMAGE_DROWNING = 1,
   ENVIROMENTAL_DAMAGE_FALL = 2,
   ENVIROMENTAL_DAMAGE_LAVA = 3,
   ENVIROMENTAL_DAMAGE_SLIME = 4,
   ENVIROMENTAL_DAMAGE_FIRE = 5
};

enum Spell_Efect_Flags
{
	SPELL_EFECT_FLAG_PERCENT		= 1,
	SPELL_EFECT_TRGIGGER_SPELL		= 2,
};

enum AURA_SPECIAL_INDEXES
{
	AURA_STAT_INDEX_THREAT		= 10001,
	AURA_STAT_INDEX_SPEED		= 10002,
	AURA_STAT_INDEX_SPELL		= 10003,
	AURA_STAT_INDEX_WATER_WALK	= 10004,
};

enum AURA_FLAGS
{
    AFLAG_EMPTY = 0x0,
    AFLAG_SET = 0x9
};

enum MOD_TYPES
{
    SPELL_AURA_NONE = 0,                                // None
    SPELL_AURA_BIND_SIGHT = 1,                          // Bind Sight
    SPELL_AURA_MOD_THREAT = 10,                         // Mod Threat
    SPELL_AURA_AURAS_VISIBLE = 100,                     // Auras Visible
    SPELL_AURA_MOD_RESISTANCE_PCT = 101,                // Mod Resistance %
    SPELL_AURA_MOD_CREATURE_ATTACK_POWER = 102,         // Mod Creature Attack Power
    SPELL_AURA_MOD_TOTAL_THREAT = 103,                  // Mod Total Threat (Fade)
    SPELL_AURA_WATER_WALK = 104,                        // Water Walk
    SPELL_AURA_FEATHER_FALL = 105,                      // Feather Fall
    SPELL_AURA_HOVER = 106,                             // Hover
    SPELL_AURA_ADD_FLAT_MODIFIER = 107,                 // Add Flat Modifier
    SPELL_AURA_ADD_PCT_MODIFIER = 108,                  // Add % Modifier
    SPELL_AURA_ADD_TARGET_TRIGGER = 109,                // Add Class Target Trigger
    SPELL_AURA_MOD_TAUNT = 11,                          // Taunt
    SPELL_AURA_MOD_POWER_REGEN_PERCENT = 110,           // Mod Power Regen %
    SPELL_AURA_ADD_CASTER_HIT_TRIGGER = 111,            // Add Class Caster Hit Trigger. No spell instances found
    SPELL_AURA_OVERRIDE_CLASS_SCRIPTS = 112,            // Override Class Scripts
    SPELL_AURA_MOD_RANGED_DAMAGE_TAKEN = 113,           // Mod Ranged Dmg Taken
    SPELL_AURA_MOD_RANGED_DAMAGE_TAKEN_PCT = 114,       // Mod Ranged % Dmg Taken. No spell instances found
    SPELL_AURA_MOD_HEALING = 115,                       // Mod Healing
    SPELL_AURA_IGNORE_REGEN_INTERRUPT = 116,            // Regen During Combat
    SPELL_AURA_MOD_MECHANIC_RESISTANCE = 117,           // Mod Mechanic Resistance
    SPELL_AURA_MOD_HEALING_PCT = 118,                   // Mod Healing %
    SPELL_AURA_SHARE_PET_TRACKING = 119,                // Share Pet Tracking
    SPELL_AURA_MOD_STUN = 12,                           // Stun
    SPELL_AURA_UNTRACKABLE = 120,                       // Untrackable
    SPELL_AURA_EMPATHY = 121,                           // Empathy (Lore, whatever)
    SPELL_AURA_MOD_OFFHAND_DAMAGE_PCT = 122,            // Mod Offhand Dmg %
    SPELL_AURA_MOD_POWER_COST_PCT = 123,                // Mod Power Cost %. No spell instances found
    SPELL_AURA_MOD_RANGED_ATTACK_POWER = 124,           // Mod Ranged Attack Power
    SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN = 125,            // Mod Melee Dmg Taken
    SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN_PCT = 126,        // Mod Melee % Dmg Taken
    SPELL_AURA_RANGED_ATTACK_POWER_ATTACKER_BONUS = 127,// Rngd Atk Pwr Attckr Bonus
    SPELL_AURA_MOD_POSSESS_PET = 128,                   // Mod Possess Pet
    SPELL_AURA_MOD_INCREASE_SPEED_ALWAYS = 129,         // Mod Speed Always
    SPELL_AURA_MOD_DAMAGE_DONE = 13,                    // Mod Damage Done
    SPELL_AURA_MOD_MOUNTED_SPEED_ALWAYS = 130,          // Mod Mounted Speed Always
    SPELL_AURA_MOD_CREATURE_RANGED_ATTACK_POWER = 131,  // Mod Creature Ranged Attack Power
    SPELL_AURA_MOD_INCREASE_ENERGY_PERCENT = 132,       // Mod Increase Energy %
    SPELL_AURA_MOD_INCREASE_HEALTH_PERCENT = 133,       // Mod Max Health %
    SPELL_AURA_MOD_MANA_REGEN_INTERRUPT = 134,          // Mod Interrupted Mana Regen
    SPELL_AURA_MOD_HEALING_DONE = 135,                  // Mod Healing Done
    SPELL_AURA_MOD_HEALING_DONE_PERCENT = 136,          // Mod Healing Done %
    SPELL_AURA_MOD_TOTAL_STAT_PERCENTAGE = 137,         // Mod Total Stat %
    SPELL_AURA_MOD_HASTE = 138,                         // Haste - Melee
    SPELL_AURA_FORCE_REACTION = 139,                    // Force Reaction
    SPELL_AURA_MOD_DAMAGE_TAKEN = 14,                   // Mod Damage Taken
    SPELL_AURA_MOD_RANGED_HASTE = 140,                  // Haste - Ranged
    SPELL_AURA_MOD_RANGED_AMMO_HASTE = 141,             // Haste - Ranged (Ammo Only)
    SPELL_AURA_MOD_BASE_RESISTANCE_PCT = 142,           // Mod Base Resistance %
    SPELL_AURA_MOD_RESISTANCE_EXCLUSIVE = 143,          // Mod Resistance Exclusive
    SPELL_AURA_SAFE_FALL = 144,                         // Safe Fall
    SPELL_AURA_CHARISMA = 145,                          // Charisma
    SPELL_AURA_PERSUADED = 146,                         // Persuaded
    SPELL_AURA_ADD_CREATURE_IMMUNITY = 147,             // Add Creature Immunity
    SPELL_AURA_RETAIN_COMBO_POINTS = 148,               // Retain Combo Points
    SPELL_AURA_DAMAGE_SHIELD = 15,                      // Damage Shield
    SPELL_AURA_MOD_STEALTH = 16,                        // Mod Stealth
    SPELL_AURA_MOD_DETECT = 17,                         // Mod Detect
    SPELL_AURA_MOD_INVISIBILITY = 18,                   // Mod Invisibility
    SPELL_AURA_MOD_INVISIBILITY_DETECTION = 19,         // Mod Invisibility Detection
    SPELL_AURA_MOD_POSSESS = 2,                         // Mod Possess
    SPELL_AURA_MOD_RESISTANCE = 22,                     // Mod Resistance
    SPELL_AURA_PERIODIC_TRIGGER_SPELL = 23,             // Periodic Trigger
    SPELL_AURA_PERIODIC_ENERGIZE = 24,                  // Periodic Energize
    SPELL_AURA_MOD_PACIFY = 25,                         // Pacify
    SPELL_AURA_MOD_ROOT = 26,                           // Root
    SPELL_AURA_MOD_SILENCE = 27,                        // Silence
    SPELL_AURA_REFLECT_SPELLS = 28,                     // Reflect Spells %
    SPELL_AURA_MOD_STAT = 29,                           // Mod Stat
    SPELL_AURA_PERIODIC_DAMAGE = 3,                     // Periodic Damage
    SPELL_AURA_MOD_SKILL = 30,                          // Mod Skill
    SPELL_AURA_MOD_INCREASE_SPEED = 31,                 // Mod Speed
    SPELL_AURA_MOD_INCREASE_MOUNTED_SPEED = 32,         // Mod Speed Mounted
    SPELL_AURA_MOD_DECREASE_SPEED = 33,                 // Mod Speed Slow
    SPELL_AURA_MOD_INCREASE_HEALTH = 34,                // Mod Increase Health
    SPELL_AURA_MOD_INCREASE_ENERGY = 35,                // Mod Increase Energy
    SPELL_AURA_MOD_SHAPESHIFT = 36,                     // Shapeshift
    SPELL_AURA_EFFECT_IMMUNITY = 37,                    // Immune Effect
    SPELL_AURA_STATE_IMMUNITY = 38,                     // Immune State
    SPELL_AURA_SCHOOL_IMMUNITY = 39,                    // Immune School
    SPELL_AURA_DAMAGE_IMMUNITY = 40,                    // Immune Damage
    SPELL_AURA_DISPEL_IMMUNITY = 41,                    // Immune Dispel Type
    SPELL_AURA_PROC_TRIGGER_SPELL = 42,                 // Proc Trigger Spell
    SPELL_AURA_PROC_TRIGGER_DAMAGE = 43,                // Proc Trigger Damage
    SPELL_AURA_TRACK_CREATURES = 44,                    // Track Creatures
    SPELL_AURA_TRACK_RESOURCES = 45,                    // Track Resources
    SPELL_AURA_MOD_PARRY_SKILL = 46,                    // Mod Parry Skill
    SPELL_AURA_MOD_PARRY_PERCENT = 47,                  // Mod Parry Percent
    SPELL_AURA_MOD_DODGE_SKILL = 48,                    // Mod Dodge Skill
    SPELL_AURA_MOD_DODGE_PERCENT = 49,                  // Mod Dodge Percent
	SPELL_AURA_UNK1 = 4,								// found at arcane missile, and all kinda vision and mindcontrol spells
														// though it is not implemented on blizz side i think this should refresh spell remaining time on some event
														// also found at spell 21084 that it should call some other spell based on value. But the called spell was not the one as in the description
    SPELL_AURA_MOD_CONFUSE = 5,                         // Mod Confuse
    SPELL_AURA_MOD_BLOCK_SKILL = 50,                    // Mod Block Skill
    SPELL_AURA_MOD_BLOCK_PERCENT = 51,                  // Mod Block Percent
    SPELL_AURA_MOD_CRIT_PERCENT = 52,                   // Mod Crit Percent
    SPELL_AURA_PERIODIC_LEECH = 53,                     // Periodic Leech
    SPELL_AURA_MOD_HIT_CHANCE = 54,                     // Mod Hit Chance
    SPELL_AURA_MOD_SPELL_HIT_CHANCE = 55,               // Mod Spell Hit Chance
    SPELL_AURA_TRANSFORM = 56,                          // Transform
    SPELL_AURA_MOD_SPELL_CRIT_CHANCE = 57,              // Mod Spell Crit Chance
    SPELL_AURA_MOD_INCREASE_SWIM_SPEED = 58,            // Mod Speed Swim
    SPELL_AURA_MOD_DAMAGE_DONE_CREATURE = 59,           // Mod Creature Dmg Done
    SPELL_AURA_MOD_CHARM = 6,                           // Mod Charm
    SPELL_AURA_MOD_PACIFY_SILENCE = 60,                 // Pacify & Silence
    SPELL_AURA_MOD_SCALE = 61,                          // Mod Scale
    SPELL_AURA_PERIODIC_HEALTH_FUNNEL = 62,             // Periodic Health Funnel
    SPELL_AURA_PERIODIC_MANA_FUNNEL = 63,               // Periodic Mana Funnel
    SPELL_AURA_PERIODIC_MANA_LEECH = 64,                // Periodic Mana Leech
    SPELL_AURA_MOD_CASTING_SPEED = 65,                  // Haste - Spells
    SPELL_AURA_FEIGN_DEATH = 66,                        // Feign Death
    SPELL_AURA_MOD_DISARM = 67,                         // Disarm
    SPELL_AURA_MOD_STALKED = 68,                        // Mod Stalked
    SPELL_AURA_SCHOOL_ABSORB = 69,                      // School Absorb
    SPELL_AURA_MOD_FEAR = 7,                            // Mod Fear
    SPELL_AURA_EXTRA_ATTACKS = 70,                      // Extra Attacks
    SPELL_AURA_MOD_SPELL_CRIT_CHANCE_SCHOOL = 71,       // Mod School Spell Crit Chance
    SPELL_AURA_MOD_POWER_COST = 72,                     // Mod Power Cost
    SPELL_AURA_MOD_POWER_COST_SCHOOL = 73,              // Mod School Power Cost
    SPELL_AURA_REFLECT_SPELLS_SCHOOL = 74,              // Reflect School Spells %
    SPELL_AURA_MOD_LANGUAGE = 75,                       // Mod Language
    SPELL_AURA_FAR_SIGHT = 76,                          // Far Sight
    SPELL_AURA_MECHANIC_IMMUNITY = 77,                  // Immune Mechanic
    SPELL_AURA_MOUNTED = 78,                            // Mounted
    SPELL_AURA_MOD_DAMAGE_PERCENT_DONE = 79,            // Mod Dmg %
    SPELL_AURA_PERIODIC_HEAL = 8,                       // Periodic Heal
    SPELL_AURA_MOD_PERCENT_STAT = 80,                   // Mod Stat %
    SPELL_AURA_SPLIT_DAMAGE = 81,                       // Split Damage
    SPELL_AURA_WATER_BREATHING = 82,                    // Water Breathing
    SPELL_AURA_MOD_BASE_RESISTANCE = 83,                // Mod Base Resistance
    SPELL_AURA_MOD_REGEN = 84,                          // Mod Health Regen
    SPELL_AURA_MOD_POWER_REGEN = 85,                    // Mod Power Regen
    SPELL_AURA_CHANNEL_DEATH_ITEM = 86,                 // Create Death Item
    SPELL_AURA_MOD_DAMAGE_PERCENT_TAKEN = 87,           // Mod Dmg % Taken
    SPELL_AURA_MOD_PERCENT_REGEN = 88,                  // Mod Health Regen Percent
    SPELL_AURA_PERIODIC_DAMAGE_PERCENT = 89,            // Periodic Damage Percent
    SPELL_AURA_MOD_ATTACKSPEED = 9,                     // Mod Attack Speed
    SPELL_AURA_MOD_RESIST_CHANCE = 90,                  // Mod Resist Chance
    SPELL_AURA_MOD_DETECT_RANGE = 91,                   // Mod Detect Range
    SPELL_AURA_PREVENTS_FLEEING = 92,                   // Prevent Fleeing
    SPELL_AURA_MOD_UNATTACKABLE = 93,                   // Mod Uninteractible
    SPELL_AURA_INTERRUPT_REGEN = 94,                    // Interrupt Regen
    SPELL_AURA_GHOST = 95,                              // Ghost
    SPELL_AURA_SPELL_MAGNET = 96,                       // Spell Magnet
    SPELL_AURA_MANA_SHIELD = 97,                        // Mana Shield
    SPELL_AURA_MOD_SKILL_TALENT = 98,                   // Mod Skill Talent
    SPELL_AURA_MOD_ATTACK_POWER = 99,                   // Mod Attack Power
    SPELL_AURA_MOD_HEALTH_REGEN = 161,                   // found only at demon skin armor
};

enum Vendor_buy_errors
{
	VENDOR_BUY_ERR_NOT_ENOUGH_MONEY		= 2,
};

enum INV_ERR
{
   INV_ERR_OK,
   INV_ERR_YOU_MUST_REACH_LEVEL_N,
   INV_ERR_SKILL_ISNT_HIGH_ENOUGH,
   INV_ERR_ITEM_DOESNT_GO_TO_SLOT,
   INV_ERR_BAG_FULL,
   INV_ERR_NONEMPTY_BAG_OVER_OTHER_BAG,
   INV_ERR_CANT_TRADE_EQUIP_BAGS,
   INV_ERR_ONLY_AMMO_CAN_GO_HERE,
   INV_ERR_NO_REQUIRED_PROFICIENCY,
   INV_ERR_NO_EQUIPMENT_SLOT_AVAILABLE,
   INV_ERR_YOU_CAN_NEVER_USE_THAT_ITEM,
   INV_ERR_YOU_CAN_NEVER_USE_THAT_ITEM2,
   INV_ERR_NO_EQUIPMENT_SLOT_AVAILABLE2,
   INV_ERR_CANT_EQUIP_WITH_TWOHANDED,
   INV_ERR_CANT_DUAL_WIELD,
   INV_ERR_ITEM_DOESNT_GO_INTO_BAG,
   INV_ERR_ITEM_DOESNT_GO_INTO_BAG2,
   INV_ERR_CANT_CARRY_MORE_OF_THIS,
   INV_ERR_NO_EQUIPMENT_SLOT_AVAILABLE3,
   INV_ERR_ITEM_CANT_STACK,
   INV_ERR_ITEM_CANT_BE_EQUIPPED,
   INV_ERR_ITEMS_CANT_BE_SWAPPED,
   INV_ERR_SLOT_IS_EMPTY,
   INV_ERR_ITEM_NOT_FOUND,
   INV_ERR_CANT_DROP_SOULBOUND,
   INV_ERR_OUT_OF_RANGE,
   INV_ERR_TRIED_TO_SPLIT_MORE_THAN_COUNT,
   INV_ERR_COULDNT_SPLIT_ITEMS,
   INV_ERR_MISSING_REAGENT,
   INV_ERR_NOT_ENOUGH_MONEY,
   INV_ERR_NOT_A_BAG,
   INV_ERR_CAN_ONLY_DO_WITH_EMPTY_BAGS,
   INV_ERR_DONT_OWN_THAT_ITEM,
   INV_ERR_CAN_EQUIP_ONLY1_QUIVER,
   INV_ERR_MUST_PURCHASE_THAT_BAG_SLOT,
   INV_ERR_TOO_FAR_AWAY_FROM_BANK,
   INV_ERR_ITEM_LOCKED,
   INV_ERR_YOU_ARE_STUNNED,
   INV_ERR_YOU_ARE_DEAD,
   INV_ERR_CANT_DO_RIGHT_NOW,
   INV_ERR_BAG_FULL2,
   INV_ERR_CAN_EQUIP_ONLY1_QUIVER2,
   INV_ERR_CAN_EQUIP_ONLY1_AMMOPOUCH,
   INV_ERR_STACKABLE_CANT_BE_WRAPPED,
   INV_ERR_EQUIPPED_CANT_BE_WRAPPED,
   INV_ERR_WRAPPED_CANT_BE_WRAPPED,
   INV_ERR_BOUND_CANT_BE_WRAPPED,
   INV_ERR_UNIQUE_CANT_BE_WRAPPED,
   INV_ERR_BAGS_CANT_BE_WRAPPED,
   INV_ERR_ALREADY_LOOTED,
   INV_ERR_INVENTORY_FULL,
   INV_ERR_BANK_FULL,
   INV_ERR_ITEM_IS_CURRENTLY_SOLD_OUT,
   INV_ERR_BAG_FULL3,
   INV_ERR_ITEM_NOT_FOUND2,
   INV_ERR_ITEM_CANT_STACK2,
   INV_ERR_BAG_FULL4,
   INV_ERR_ITEM_SOLD_OUT,
   INV_ERR_OBJECT_IS_BUSY,
   INV_ERR_NONE,
   INV_ERR_CANT_DO_IN_COMBAT,
   INV_ERR_CANT_DO_WHILE_DISARMED,
   INV_ERR_BAG_FULL6,
   INV_ERR_ITEM_RANK_NOT_ENOUGH,
   INV_ERR_ITEM_REPUTATION_NOT_ENOUGH,
   INV_ERR_MORE_THAN1_SPECIAL_BAG,
};

enum Item_quality_names
{
	ITEM_QUALITY_POOR_GREY				= 0, 
	ITEM_QUALITY_NORMAL_WHITE			= 1,
	ITEM_QUALITY_UNCOMMON_GREEN			= 2, 
	ITEM_QUALITY_RARE_BLUE				= 3,
	ITEM_QUALITY_EPIC_PURPLE			= 4, 
	ITEM_QUALITY_LEGENDARY_ORANGE		= 5, 
	ITEM_QUALITY_ARTIFACT_LIGHT_YELLOW	= 6,
};

//position is in 4bytes
enum Item_Fields_2
{
	ITEM_ID						= 0,
	ITEM_CLASS					= 1,
	ITEM_SUBCLASS				= 2,
	ITEM_UNK4					= 3,
	ITEM_DISPLAY_INFO_ID		= 4,//+1
	ITEM_QUALITY				= 5,
	ITEM_FLAGS					= 6,
	ITEM_PRICE_BUY				= 7, //this is reversed loaded from db because it would be actualy vendor_sell=char_buy
	ITEM_PRICE_SELL				= 8,
	ITEM_INVENTORY_TYPE			= 9,
	ITEM_ALLOW_CLASS			= 10,
	ITEM_ALLOW_RACE				= 11,
	ITEM_LVL					= 12,
	ITEM_REQUIRE_LVL			= 13,
	ITEM_REQUIRE_SKILL			= 14,
	ITEM_REQUIRE_SKILL_LVL		= 15,
	ITEM_REQUIRE_SPELL_ID		= 16,
	ITEM_REQUIRE_HONOR_RANK		= 17,
	ITEM_REQUIRE_CITY_RANK		= 18,
	ITEM_REQUIRE_FACTION		= 19,
	ITEM_REQUIRE_FACTION_lvl	= 20,	
	ITEM_UNK21					= 21,
	ITEM_STACK_MAX				= 22,
	ITEM_SLOTS					= 23,//in case it is a bag
	ITEM_STAT_TYPE_0			= 24, //10 values paires !!!
	ITEM_STAT_VALUE_0			= 25, //10 values
	ITEM_DMG_MIN_0				= 44, //float 5 values. 3 value blocks then again !!!
	ITEM_DMG_MAX_0				= 45, //float 5 values
	ITEM_DMG_TYPE_0				= 46, //5 values
	ITEM_ARMOR					= 59,
	ITEM_RESISTANCE_HOLY		= 60,
	ITEM_RESISTANCE_FIRE		= 61,
	ITEM_RESISTANCE_NATURE		= 62,
	ITEM_RESISTANCE_FROST		= 63,
	ITEM_RESISTANCE_SHADOW		= 64,
	ITEM_RESISTANCE_ARCANE		= 65,
	ITEM_DELAY					= 66,
	ITEM_AMO_TYPE				= 67,//amo type
	ITEM_RANGED_MOD_RANGE		= 68,//float
	ITEM_SPELL_ID				= 69, //5 values . 6 value block !!!
	ITEM_SPELL_TRIGGER			= 70, //5 values
	ITEM_SPELL_CHARGES			= 71, //5 values
	ITEM_SPELL_COOLDOWN			= 72, //5 values
	ITEM_SPELL_CATEGORY			= 73, //5 values
	ITEM_SPELL_CATEGORY_COOLDOWN	= 74, //5 values
	ITEM_BONDING				= 99,
	ITEM_PAGE_TEXT_ID			= 100,
	ITEM_PAGE_LANGUAGE			= 101,
	ITEM_PAGE_MATERIAL			= 102,
	ITEM_START_QUEST			= 103,
	ITEM_LOCK_ID				= 104,
	ITEM_LOCK_MATERIAL			= 105,
	ITEM_SHEATH					= 106,
	ITEM_EXTRA					= 107,
	ITEM_BLOCK					= 108,
	ITEM_ITEMSET				= 109,
	ITEM_DURABILITY_MAX			= 110,
	ITEM_AREA					= 111,
	ITEM_MAP					= 112,
	ITEM_BAG_FAMILY				= 113,
	ITEM_TOTEM_CATEGORY			= 114,
	ITEM_JEWEL_SOCKET_COLOR_0	= 115, //3 * value pair
	ITEM_JEWEL_SOCKET_CONTENT_0	= 116, //3 * value pair
	ITEM_SOCKET_BONUS			= 121,
	ITEM_GEM_PROPERTIES			= 122,
	ITEM_EXTENDED_COST			= 123,
	ITEM_DISENCHANT_SKILL_LVL	= 124,
	ITEM_UNK141					= 125,
	ITEM_FIELDS_END_BEFORE_NAME = 126,//count 0 value too 
	ITEM_NAME					= 126, //52 chars = 13 values. !!!if you change it change in dbinterface 2
	ITEM_DESCRIPTION			= 139, //100 chars = 25 values
	ITEM_FIELDS_END_ORIGINAL	= 155,
	ITEM_EXTRA_FLAGS			= 156, //store is flags
	ITEM_SPELL_CAST_CHANCE_0	= 157, //5 values [0..100]
	ITEM_FIELDS_END				= 163,
};

enum Item_Extra_flags
{
	ITEM_IS_RANDOMISABLE			= 1,
	ITEM_IS_CHARM					= 2,
	ITEM_IS_SPELL_CREATED			= 4,
};

enum ITEM_STAT_TYPE
{
    HEALTH     = 1,
    UNKNOWN    = 2,
    AGILITY    = 3,
    STRENGHT   = 4,
    INTELLECT  = 5,
    SPIRIT     = 6,
    STAMINA    = 7,
};

#define SPELL_MAX_SCOOL_TYPE (6+1)

enum ITEM_DAMAGE_TYPE
{
    NORMAL_DAMAGE  = 0,
    HOLY_DAMAGE    = 1,
    FIRE_DAMAGE    = 2,
    NATURE_DAMAGE  = 3,
    FROST_DAMAGE   = 4,
    SHADOW_DAMAGE  = 5,
    ARCANE_DAMAGE  = 6,
};

enum ITEM_SPELLTRIGGER_TYPE
{
    SPELLTRIGGER_TYPE_ON_USE			= 0,
    SPELLTRIGGER_TYPE_ON_EQUIP			= 1,
    SPELLTRIGGER_TYPE_CHANCE_ON_HIT		= 2,
    SPELLTRIGGER_TYPE_SOULSTONE			= 4,
    SPELLTRIGGER_TYPE_CHANCE_ON_STRUCK   = 256, //this must have a defiend value 256 is jsut picked by me :(
};

enum Spell_Aura_Interrupt_Flag_Types
{
	SPELL_AURA_INTERRUPT_FLAGS_TYPE_STANDSTATE_SIT		= 262144,
	SPELL_AURA_INTERRUPT_FLAGS_TYPE_STRUCK				= 2,
};

enum Spell_cast_internal_flags
{
	SPELL_CAST_INTERNAL_FLAG_FORCE_STACKABLE	= 1,
	SPELL_CAST_INTERNAL_FLAG_ITEM_CAST			= 2,
};

enum ITEM_BONDING_TYPE
{
    NO_BIND             = 0,
    BIND_WHEN_PICKED_UP = 1,
    BIND_WHEN_EQUIPED   = 2,
};

enum INVENTORY_TYPES
{
    INVTYPE_NON_EQUIP      = 0,
    INVTYPE_HEAD           = 1,
    INVTYPE_NECK           = 2,
    INVTYPE_SHOULDERS      = 3,
    INVTYPE_BODY           = 4,   // cloth robes only
    INVTYPE_CHEST          = 5,
    INVTYPE_WAIST          = 6,
    INVTYPE_LEGS           = 7,
    INVTYPE_FEET           = 8,
    INVTYPE_WRISTS         = 9,
    INVTYPE_HANDS          = 10,
    INVTYPE_FINGER         = 11,
    INVTYPE_TRINKET        = 12,
    INVTYPE_WEAPON         = 13,
    INVTYPE_SHIELD         = 14,
    INVTYPE_RANGED         = 15,
    INVTYPE_CLOAK          = 16,
    INVTYPE_TWOHAND_WEAPON = 17,
    INVTYPE_BAG            = 18,
    INVTYPE_TABARD         = 19,
    INVTYPE_ROBE           = 20,
    INVTYPE_WEAPONMAINHAND = 21,
    INVTYPE_WEAPONOFFHAND  = 22,
    INVTYPE_HOLDABLE       = 23,
    INVTYPE_AMMO           = 24,
    INVTYPE_THROWN         = 25,
    INVTYPE_RANGEDRIGHT    = 26,
    NUM_INVENTORY_TYPES    = 27,
};

enum Sheath_Type
{
   SHEATHETYPE_NONE               = 0,
   SHEATHETYPE_MAINHAND            = 1,
   SHEATHETYPE_OFFHAND               = 2,
   SHEATHETYPE_LARGEWEAPONLEFT         = 3,
   SHEATHETYPE_LARGEWEAPONRIGHT      = 4,
   SHEATHETYPE_HIPWEAPONLEFT         = 5,
   SHEATHETYPE_HIPWEAPONRIGHT         = 6,
   SHEATHETYPE_SHIELD               = 7,
};

enum Item_Class
{
   ITEM_CLASS_CONSUMABLE	= 0,
   ITEM_CLASS_CONTAINER		= 1,
   ITEM_CLASS_WEAPON		= 2,
   ITEM_CLASS_ARMOR			= 4,
   ITEM_CLASS_REAGENT		= 5,
   ITEM_CLASS_PROJECTILE	= 6,
   ITEM_CLASS_TRADE_GOODS   = 7,
   ITEM_CLASS_RECIPE		= 9,
   ITEM_CLASS_QUIVER		= 11,
   ITEM_CLASS_QUEST			= 12,
   ITEM_CLASS_KEY			= 13,
   ITEM_CLASS_MISC			= 15,
};
#define MAX_ITEM_CLASS_TYPES 16

enum Item_Subclass
{
   // Weapon
   ITEM_SUBCLASS_WEAPON_AXE			= 0,
   ITEM_SUBCLASS_WEAPON_TWOHAND_AXE	= 1,
   ITEM_SUBCLASS_WEAPON_BOW			= 2,
   ITEM_SUBCLASS_WEAPON_GUN			= 3,
   ITEM_SUBCLASS_WEAPON_MACE			= 4,
   ITEM_SUBCLASS_WEAPON_TWOHAND_MACE   = 5,
   ITEM_SUBCLASS_WEAPON_POLEARM		= 6,
   ITEM_SUBCLASS_WEAPON_SWORD			= 7,
   ITEM_SUBCLASS_WEAPON_TWOHAND_SWORD	= 8,
   ITEM_SUBCLASS_WEAPON_STAFF			= 10,
   ITEM_SUBCLASS_WEAPON_FIST_WEAPON	= 13,
   ITEM_SUBCLASS_WEAPON_MISC_WEAPON	= 14,
   ITEM_SUBCLASS_WEAPON_DAGGER			= 15,
   ITEM_SUBCLASS_WEAPON_THROWN			= 16,
   ITEM_SUBCLASS_WEAPON_CROSSBOW		= 18,
   ITEM_SUBCLASS_WEAPON_WAND			= 19,
   ITEM_SUBCLASS_WEAPON_FISHING_POLE   = 20,
   
   // Armor
   ITEM_SUBCLASS_ARMOR_MISC			= 0,
   ITEM_SUBCLASS_ARMOR_CLOTH			= 1,
   ITEM_SUBCLASS_ARMOR_LEATHER		= 2,
   ITEM_SUBCLASS_ARMOR_MAIL			= 3,
   ITEM_SUBCLASS_ARMOR_PLATE_MAIL		= 4,
   ITEM_SUBCLASS_ARMOR_SHIELD			= 6,

   // Projectile
   ITEM_SUBCLASS_PROJECTILE_ARROW			= 2,
   ITEM_SUBCLASS_PROJECTILE_BULLET			= 3,
   
   // Trade goods
   ITEM_SUBCLASS_PROJECTILE_TRADE_GOODS	= 0,
   ITEM_SUBCLASS_PROJECTILE_PARTS			= 1,
   ITEM_SUBCLASS_PROJECTILE_EXPLOSIVES		= 2,
   ITEM_SUBCLASS_PROJECTILE_DEVICES		= 3,
   
   // Recipe
   ITEM_SUBCLASS_RECIPE_BOOK            = 0,
   ITEM_SUBCLASS_RECIPE_LEATHERWORKING  = 1,
   ITEM_SUBCLASS_RECIPE_TAILORING       = 2,
   ITEM_SUBCLASS_RECIPE_ENGINEERING     = 3,
   ITEM_SUBCLASS_RECIPE_BLACKSMITHING   = 4,
   ITEM_SUBCLASS_RECIPE_COOKING         = 5,
   ITEM_SUBCLASS_RECIPE_ALCHEMY         = 6,
   ITEM_SUBCLASS_RECIPE_FIRST_AID       = 7,
   ITEM_SUBCLASS_RECIPE_ENCHANTING      = 8,
   ITEM_SUBCLASS_RECIPE_FISNING         = 9,

   // Quiver
   ITEM_SUBCLASS_QUIVER_AMMO_POUCH     = 3,
   ITEM_SUBCLASS_QUIVER_QUIVER			= 2,

   // Misc
   ITEM_SUBCLASS_MISC_JUNK            = 0,
};
#define MAX_ITEM_SUBCLASS_TYPES 32

enum Item_Is_Flags
{
	ITEM_IS_CRAFTED		= 1,
	ITEM_IS_QUESTED		= 2,
	ITEM_IS_RAID		= 4,
	ITEM_IS_STATIC		= 8,
	ITEM_IS_VENDOR		= 16,
	ITEM_IS_WORLD		= 32,
};

enum Item_mod_stat_types
{
	ITEM_MOD_STAT_TYPE_MAXHEALTH		= 1,
	ITEM_MOD_STAT_TYPE_STAT1			= 3,
	ITEM_MOD_STAT_TYPE_STAT0			= 4,
	ITEM_MOD_STAT_TYPE_STAT3			= 5,
	ITEM_MOD_STAT_TYPE_STAT4			= 6,
	ITEM_MOD_STAT_TYPE_STAT2			= 7,
	ITEM_MOD_STAT_TYPE_DEFENSE_RATE		= 12,
	ITEM_MOD_STAT_TYPE_UNK				= 15,
	ITEM_MOD_STAT_TYPE_SPELL_HIT_RATE	= 18,
	ITEM_MOD_STAT_TYPE_SPELL_CRIT_RATE	= 21,
	ITEM_MOD_STAT_TYPE_HIT_RATE			= 31,
	ITEM_MOD_STAT_TYPE_CRITICAL_RATE	= 32,
	ITEM_MOD_STAT_TYPE_RESILIANCE_RATE	= 35,
};

typedef enum {
   EFFECT_NONE = 0,
   EFFECT_INSTAKILL = 1,
   EFFECT_SCHOOL_DAMAGE = 2,
   EFFECT_DUMMY = 3,
   EFFECT_PORTAL_TELEPORT = 4,
   EFFECT_TELEPORT_UNITS = 5,
   EFFECT_APPLY_AURA = 6,
   EFFECT_ENVIRONMENTAL_DAMAGE = 7,
   EFFECT_POWER_DRAIN = 8,
   EFFECT_HEALTH_LEECH = 9,
   EFFECT_HEAL = 10,
   EFFECT_BIND = 11,
   EFFECT_PORTAL = 12,
   EFFECT_RITUAL_BASE = 13, //no examples :(
   EFFECT_RITUAL_SPECIALIZE = 14,//no examples :(
   EFFECT_RITUAL_ACTIVATE_PORTAL = 15,//no examples :(
   EFFECT_QUEST_COMPLETE = 16,
   EFFECT_WEAPON_DAMAGE_ADD_NOSCHOOL = 17,
   EFFECT_RESURRECT = 18,
   EFFECT_EXTRA_ATTACKS = 19,
   EFFECT_DODGE = 20,
   EFFECT_EVADE = 21,
   EFFECT_PARRY = 22,
   EFFECT_BLOCK = 23,
   EFFECT_CREATE_ITEM = 24,
   EFFECT_WEAPON = 25, //think it's for the ability to wield weapons
   EFFECT_DEFENSE = 26, //all values are 0 :(. Think it's ability
   EFFECT_PERSISTENT_AREA_AURA = 27,
   EFFECT_SUMMON = 28,
   EFFECT_LEAP = 29,
   EFFECT_ENERGIZE = 30,
   EFFECT_WEAPON_DMG_PERCENT = 31,
   EFFECT_TRIGGER_MISSILE = 32, //couldn't find any examples
   EFFECT_OPEN_LOCK = 33,
   EFFECT_APPLY_AREA_AURA = 35,
   EFFECT_LEARN_SPELL = 36,
   EFFECT_SPELL_DEFENSE = 37,//seems like an ability
   EFFECT_DISPEL = 38,
   EFFECT_LANGUAGE = 39, //ability to speak a language
   EFFECT_DUAL_WIELD = 40, //ability to dual wield weapons
   EFFECT_SUMMON_WILD = 41, 
   EFFECT_SUMMON_GUARDIAN = 42,
   EFFECT_SKILL_STEP = 44,
   EFFECT_SPAWN = 46,
   EFFECT_SPELL_CAST_UI = 47,
   EFFECT_STEALTH = 48,
   EFFECT_DETECT = 49,
   EFFECT_SUMMON_OBJECT = 50,
   EFFECT_FORCE_CRITICAL_HIT = 51,
   EFFECT_GUARANTEE_HIT = 52,
   EFFECT_ENCHANT_ITEM_PERMANENT = 53,
   EFFECT_ENCHANT_ITEM_TEMPORARY = 54,
   EFFECT_TAME_CREATURE = 55,
   EFFECT_SUMMON_PET = 56,
   EFFECT_LEARN_PET_SPELL = 57,
   EFFECT_WEAPON_DAMAGE_ADD = 58,
   EFFECT_OPEN_LOCK_ITEM = 59,
   EFFECT_PROFICIENCY = 60,
   EFFECT_SEND_EVENT = 61,
   EFFECT_POWER_BURN = 62,
   EFFECT_THREAT = 63,
   EFFECT_TRIGGER_SPELL = 64,
   EFFECT_HEALTH_FUNNEL = 65,
   EFFECT_POWER_FUNNEL = 66,
   EFFECT_HEAL_MAX_HEALTH = 67,
   EFFECT_INTERRUPT_CAST = 68,
   EFFECT_DISTRACT = 69,
   EFFECT_PULL = 70,
   EFFECT_PICKPOCKET = 71,
   EFFECT_ADD_FARSIGHT = 72,
   EFFECT_SUMMON_POSSESSED = 73,
   EFFECT_SUMMON_TOTEM = 74,
   EFFECT_HEAL_MECHANICAL = 75,
   EFFECT_SUMMON_OBJECT_WILD = 76,
   EFFECT_SCRIPT_EFFECT = 77,
   EFFECT_ATTACK = 78,
   EFFECT_SANCTUARY = 79,
   EFFECT_ADD_COMBO_POINTS = 80,
   EFFECT_CREATE_HOUSE = 81,
   EFFECT_BIND_SIGHT = 82,
   EFFECT_DUEL = 83,
   EFFECT_STUCK = 84,
   EFFECT_SUMMON_PLAYER = 85,
   EFFECT_ACTIVATE_OBJECT = 86,
   EFFECT_SUMMON_TOTEM_SLOT1 = 87,
   EFFECT_SUMMON_TOTEM_SLOT2 = 88,
   EFFECT_SUMMON_TOTEM_SLOT3 = 89,
   EFFECT_SUMMON_TOTEM_SLOT4 = 90,
   EFFECT_THREAT_ALL = 91,
   EFFECT_ENCHANT_HELD_ITEM = 92,
   EFFECT_SUMMON_PHANTASM = 93,
   EFFECT_SELF_RESURRECT = 94,
   EFFECT_SKINNING = 95,
   EFFECT_CHARGE = 96,
   EFFECT_SUMMON_CRITTER = 97,
   EFFECT_KNOCK_BACK = 98,
   EFFECT_DISENCHANT = 99,
   EFFECT_INEBRIATE = 100,
   EFFECT_FEED_PET = 101,
   EFFECT_DISMISS_PET = 102,
   EFFECT_REPUTATION = 103,
   EFFECT_SUMMON_OBJECT_SLOT1 = 104,
   EFFECT_SUMMON_OBJECT_SLOT2 = 105,
   EFFECT_SUMMON_OBJECT_SLOT3 = 106,
   EFFECT_SUMMON_OBJECT_SLOT4 = 107,
   EFFECT_DISPEL_MECHANIC = 108,
   EFFECT_SUMMON_DEAD_PET = 109,
   EFFECT_DESTROY_ALL_TOTEMS = 110,
   EFFECT_DURABILITY_DAMAGE = 111,
   EFFECT_SUMMON_DEMON = 112,
   EFFECT_RESURRECT_FLAT = 113,
   EFFECT_ATTACK_ME = 114,
   EFFECT_DURABILITY_DMG_PERCENT = 115,
   EFFECT_SKIN_PLAYER_CORPSE = 116,
   EFFECT_SPIRIT_HEAL = 117,
   EFFECT_LEARN_INCREASE_SKILL = 118, //!not sure about name! found at skills
} SpellEffect;

//enum Spell_atribute_flags
//{
//	SPELL_ATTRIBUTE_FLAG_SUMMON			= 0b10000000000000000010000000,
//	SPELL_ATTRIBUTE_FLAG_MECANICAL		= 0b00000000000000000010000000,
//	SPELL_ATTRIBUTE_FLAG_SUICIDE		= 0b00000001000000000000010000,
//	SPELL_ATTRIBUTE_FLAG_ELEMENTAL		= 0b00000000010000000000000000,
//};

enum EFFECT_DISPEL_MECHANIC_TYPES
{
	EFFECT_DISPEL_MECHANIC_CHARM			= 1,
	EFFECT_DISPEL_MECHANIC_CONFUSE			= 2,
	EFFECT_DISPEL_MECHANIC_DISARM			= 3,
	EFFECT_DISPEL_MECHANIC_DISTRACT			= 4,
	EFFECT_DISPEL_MECHANIC_FLEE				= 5,
	EFFECT_DISPEL_MECHANIC_CLUMSY			= 6,
	EFFECT_DISPEL_MECHANIC_ROOT				= 7,
	EFFECT_DISPEL_MECHANIC_PACIFIED			= 8,
	EFFECT_DISPEL_MECHANIC_SILENCED			= 9,
	EFFECT_DISPEL_MECHANIC_SLEEP			= 10,
	EFFECT_DISPEL_MECHANIC_ENSHNARE			= 11,
	EFFECT_DISPEL_MECHANIC_STUN				= 12,
	EFFECT_DISPEL_MECHANIC_FREEZ			= 13,
	EFFECT_DISPEL_MECHANIC_DISORIENT		= 14,
	EFFECT_DISPEL_MECHANIC_BLEED			= 15,
	EFFECT_DISPEL_MECHANIC_HEAL				= 16,
	EFFECT_DISPEL_MECHANIC_POLYMORPH		= 17,
	EFFECT_DISPEL_MECHANIC_BANISH			= 18,
	EFFECT_DISPEL_MECHANIC_SHIELD			= 19,
	EFFECT_DISPEL_MECHANIC_SHACKLE			= 20,
	EFFECT_DISPEL_MECHANIC_MOUNT			= 21,
	EFFECT_DISPEL_MECHANIC_SEDUCE			= 22,
	EFFECT_DISPEL_MECHANIC_TURNED			= 23,
	EFFECT_DISPEL_MECHANIC_HORRIFY			= 24,
};

typedef enum {
   EFF_TARGET_NONE						= 0,
   EFF_TARGET_SELF						= 1,
   EFF_TARGET_PET						= 5,
   EFF_TARGET_SINGLE_ENEMY				= 6,
   EFF_TARGET_ALL_ENEMY_IN_AREA         = 15,
   EFF_TARGET_ALL_ENEMY_IN_AREA_INSTANT	= 16,
   EFF_TARGET_ALL_PARTY_AROUND_CASTER   = 20,
   EFF_TARGET_SINGLE_FRIEND				= 21,
   EFF_TARGET_ALL_ENEMIES_AROUND_CASTER = 22,
   EFF_TARGET_GAMEOBJECT				= 23,
   EFF_TARGET_IN_FRONT_OF_CASTER        = 24,
   EFF_TARGET_DUEL						= 25,//Dont know the real name!!!
   EFF_TARGET_GAMEOBJECT_ITEM           = 26,
   EFF_TARGET_ALL_ENEMY_IN_AREA_CHANNELED = 28,
   EFF_TARGET_MINION					= 32,
   EFF_TARGET_SINGLE_PARTY              = 35,
   EFF_TARGET_ALL_PARTY					= 37,
   EFF_TARGET_SELF_FISHING              = 39,
   EFF_TARGET_TOTEM_EARTH               = 41,
   EFF_TARGET_TOTEM_WATER               = 42,
   EFF_TARGET_TOTEM_AIR					= 43,
   EFF_TARGET_TOTEM_FIRE				= 44,
   EFF_TARGET_CHAIN						= 45,
   EFF_TARGET_DYNAMIC_OBJECT            = 47,//not sure exactly where is used
   EFF_TARGET_CURRENT_SELECTION         = 53,
   EFF_TARGET_PARTY_MEMBER		        = 57,
   EFF_TARGET_AREAEFFECT_PARTY_AND_CLASS  = 61,
} SpellEffectTarget;

enum Spell_Cast_State
{
	SPELL_CAST_STATE_PREPARING		= 1,
	SPELL_CAST_STATE_CASTING		= 2,
	SPELL_CAST_STATE_COOLDOWN		= 4,
	SPELL_CAST_STATE_INTERUPTED		= 8,
};

enum Unit_Power_Type
{
	Unit_Power_Type_Mana		= 0,
	Unit_Power_Type_Rage		= 1,
	Unit_Power_Type_Focus		= 2,
	Unit_Power_Type_Energy		= 3,
	Unit_Power_Type_Happiness	= 4,
};

enum Spell_Cast_Target_Flags
{
    SPELL_TARGET_FLAG_SELF             = 0x0, // they are checked in following order
    SPELL_TARGET_FLAG_UNIT             = 0x0002,
    SPELL_TARGET_FLAG_OBJECT           = 0x0800,
    SPELL_TARGET_FLAG_ITEM             = 0x1010,
    SPELL_TARGET_FLAG_SOURCE_LOCATION  = 0x20,
    SPELL_TARGET_FLAG_DEST_LOCATION    = 0x40,
    SPELL_TARGET_FLAG_STRING           = 0x2000
};

enum CAST_FAILED
{
   CAST_FAIL_IN_COMBAT = 0,
    CAST_FAIL_ALREADY_FULL_HEALTH = 1,
    CAST_FAIL_ALREADY_FULL_MANA = 2,
    //CAST_FAIL_ALREADY_FULL_RAGE = 2,
    CAST_FAIL_CREATURE_ALREADY_TAMING = 3,
    CAST_FAIL_ALREADY_HAVE_CHARMED = 4,
    CAST_FAIL_ALREADY_HAVE_SUMMON = 5,
    CAST_FAIL_ALREADY_OPEN = 6,
    CAST_FAIL_MORE_POWERFUL_SPELL_ACTIVE = 7,
    //CAST_FAIL_FAILED = 8,-> 29
    CAST_FAIL_NO_TARGET = 9,
    CAST_FAIL_INVALID_TARGET = 10,
    CAST_FAIL_CANT_BE_CHARMED = 11,
    CAST_FAIL_CANT_BE_DISENCHANTED = 12,                    //decompose
    // 13 SPELL_FAILED_CANT_BE_PROSPECTED
    CAST_FAIL_TARGET_IS_TAPPED = 13+1,
    CAST_FAIL_CANT_START_DUEL_INVISIBLE = 14+1,
    CAST_FAIL_CANT_START_DUEL_STEALTHED = 15+1,
    CAST_FAIL_TOO_CLOSE_TO_ENEMY = 16+1,
    CAST_FAIL_CANT_DO_THAT_YET = 17+1,
    CAST_FAIL_YOU_ARE_DEAD = 18+1,
    CAST_FAIL_CANT_DO_WHILE_XXXX =19,                       //NONE
    CAST_FAIL_CANT_DO_WHILE_CHARMED =19+1,                  //SPELL_FAILED_CHARMED
    CAST_FAIL_OBJECT_ALREADY_BEING_USED = 20+1,             //SPELL_FAILED_CHEST_IN_USE
    CAST_FAIL_CANT_DO_WHILE_CONFUSED = 21+1,                //SPELL_FAILED_CONFUSED
    //23 is gone.
    CAST_FAIL_MUST_HAVE_ITEM_EQUIPPED = 22 + 1 + 1,
    CAST_FAIL_MUST_HAVE_XXXX_EQUIPPED = 23 + 1 + 1,         //SPELL_FAILED_EQUIPPED_ITEM_CLASS
    CAST_FAIL_MUST_HAVE_XXXX_IN_MAINHAND = 24 + 1 + 1,      //SPELL_FAILED_EQUIPPED_ITEM_CLASS_MAINHAND
    CAST_FAIL_MUST_HAVE_XXXX_IN_OFFHAND = 25 + 1 + 1,       //SPELL_FAILED_EQUIPPED_ITEM_CLASS_OFFHAND
    CAST_FAIL_INTERNAL_ERROR = 26 + 1 + 1,
    CAST_FAIL_FAILED = 29,                                  // Doesn't exist anymore? Used Fizzle value atm.
    CAST_FAIL_FIZZLED = 27 + 1 + 1,                         // changed (+2) 12.1.1
    CAST_FAIL_YOU_ARE_FLEEING = 28 + 1 + 1,
    CAST_FAIL_FOOD_TOO_LOWLEVEL_FOR_PET = 29 + 1 + 1,
    CAST_FAIL_TARGET_IS_TOO_HIGH = 30 + 1 + 1,
    //32 + 1 is gone.
    CAST_FAIL_IMMUNE = 32 + 1 + 1,                          //SPELL_FAILED_IMMUNE
    CAST_FAIL_INTERRUPTED = 33 + 1 + 1,                     //SPELL_FAILED_INTERRUPTED
    CAST_FAIL_INTERRUPTED1 = 34 + 1 + 1,                    //SPELL_FAILED_INTERRUPTED_COMBAT
    CAST_FAIL_INTERRUPTED_COMBAT = 36,                      //just 36 SPELL_FAILED_INTERRUPTED_COMBAT
    CAST_FAIL_ITEM_ALREADY_ENCHANTED = 35 + 1 + 1,
    CAST_FAIL_ITEM_NOT_EXIST = 36 + 1 + 1,
    CAST_FAIL_ENCHANT_NOT_EXISTING_ITEM = 37 + 1 + 1,
    CAST_FAIL_ITEM_NOT_READY = 38 + 1 + 1,
    CAST_FAIL_YOU_ARE_NOT_HIGH_ENOUGH = 39 + 1 + 1,
    CAST_FAIL_NOT_IN_LINE_OF_SIGHT = 40 + 1 + 1,
    CAST_FAIL_TARGET_TOO_LOW = 41 + 1 + 1,
    CAST_FAIL_SKILL_NOT_HIGH_ENOUGH = 42 + 1 + 1,
    CAST_FAIL_WEAPON_HAND_IS_EMPTY = 43 + 1 + 1,
    CAST_FAIL_CANT_DO_WHILE_MOVING = 44 + 1 + 1,
    CAST_FAIL_NEED_AMMO_IN_PAPERDOLL_SLOT = 45 + 1 + 1,
    CAST_FAIL_REQUIRES_SOMETHING = 46 + 1 + 1,
    CAST_FAIL_NEED_EXOTIC_AMMO = 47 + 1 + 1,
    CAST_FAIL_NO_PATH_AVAILABLE = 48 + 1 + 1,
    CAST_FAIL_NOT_BEHIND_TARGET = 49 + 1 + 1,
    CAST_FAIL_DIDNT_LAND_IN_FISHABLE_WATER = 50 + 1 + 1,
    CAST_FAIL_CANT_BE_CAST_HERE = 51 + 1 + 1,
    CAST_FAIL_NOT_IN_FRONT_OF_TARGET = 52 + 1 + 1,
    CAST_FAIL_NOT_IN_CONTROL_OF_ACTIONS = 53 + 1 + 1,
    CAST_FAIL_SPELL_NOT_LEARNED = 54 + 1 + 1,
    CAST_FAIL_CANT_USE_WHEN_MOUNTED = 55 + 1 + 1,
    CAST_FAIL_YOU_ARE_IN_FLIGHT = 56 + 1 + 1,
    CAST_FAIL_YOU_ARE_ON_TRANSPORT = 57 + 1 + 1,
    CAST_FAIL_SPELL_NOT_READY_YET = 58 + 1 + 1,
    CAST_FAIL_CANT_DO_IN_SHAPESHIFT = 59 + 1 + 1,
    CAST_FAIL_HAVE_TO_BE_STANDING = 60 + 1 + 1,
    CAST_FAIL_CAN_USE_ONLY_ON_OWN_OBJECT = 61 + 1 + 1,      // rogues trying "enchant" other's weapon with poison
    //CAST_FAIL_ALREADY_OPEN1 = 62,

    CAST_FAIL_CANT_ENCHANT_TRADE_ITEM = 63 + 1,
    CAST_FAIL_HAVE_TO_BE_UNSHEATHED = 63 + 1 + 1,           // yellow text SPELL_FAILED_NOT_UNSHEATHED
    CAST_FAIL_CANT_CAST_AS_GHOST = 64 + 1 + 1,
    CAST_FAIL_NO_AMMO = 65 + 1 + 1,
    CAST_FAIL_NO_CHARGES_REMAIN = 66 + 1 + 1,
    CAST_FAIL_NOT_SELECT = 67 + 1 + 1,
    CAST_FAIL_COMBO_POINTS_REQUIRED = 68 + 1 + 1,
    CAST_FAIL_NO_DUELING_HERE = 69 + 1 + 1,
    CAST_FAIL_NOT_ENOUGH_ENDURANCE = 70 + 1 + 1,
    CAST_FAIL_THERE_ARENT_ANY_FISH_HERE = 71 + 1 + 1,
    CAST_FAIL_CANT_USE_WHILE_SHAPESHIFTED = 72 + 1 + 1,
    CAST_FAIL_CANT_MOUNT_HERE = 73 + 1 + 1,
    CAST_FAIL_YOU_DO_NOT_HAVE_PET = 74 + 1 + 1,
    CAST_FAIL_NOT_ENOUGH_MANA = 75 + 1 + 1,
    CAST_FAIL_NOT_AURA_TO_QUSHAN = 76 + 1 + 1,
    //= 79, CAST_FAIL_NOT_ITEM_TO_STEAL = 111 + 1 + 2   //(SPELL_FAILED_NOTHING_TO_STEAL)
    CAST_FAIL_CANT_USE_WHILE_SWIMMING = 77 + 1 + 2,
    CAST_FAIL_CAN_ONLY_USE_AT_DAY = 78 + 1 + 2,
    CAST_FAIL_CAN_ONLY_USE_INDOORS = 79 + 1 + 2,
    CAST_FAIL_CAN_ONLY_USE_MOUNTED = 80 + 1 + 2,
    CAST_FAIL_CAN_ONLY_USE_AT_NIGHT = 81 + 1 + 2,
    CAST_FAIL_CAN_ONLY_USE_OUTDOORS = 82 + 1 + 2,
    //CAST_FAIL_ONLY_SHAPESHIFTED = 83                  // didn't display
    // 86 none
    CAST_FAIL_CAN_ONLY_USE_STEALTHED  = 85 + 2,
    CAST_FAIL_CAN_ONLY_USE_WHILE_SWIMMING = 86 + 2,
    CAST_FAIL_OUT_OF_RANGE = 87 + 2,
    CAST_FAIL_CANT_USE_WHILE_PACIFIED = 87 + 1 + 2,
    CAST_FAIL_YOU_ARE_POSSESSED = 88 + 1 + 2,
    CAST_FAIL_YOU_NEED_TO_BE_IN_XXX = 90 + 1 + 2,
    CAST_FAIL_REQUIRES_XXX = 91 + 1 + 2,
    CAST_FAIL_UNABLE_TO_MOVE = 92 + 1 + 2,
    CAST_FAIL_SILENCED = 93 + 1 + 2,
    CAST_FAIL_ANOTHER_ACTION_IS_IN_PROGRESS = 94 + 1 + 2,
    CAST_FAIL_ALREADY_LEARNED_THAT_SPELL = 95 + 1 + 2,
    CAST_FAIL_SPELL_NOT_AVAILABLE_TO_YOU = 96 + 1 + 2,
    CAST_FAIL_CANT_DO_WHILE_STUNNED = 97 + 1 + 2,
    CAST_FAIL_YOUR_TARGET_IS_DEAD = 98 + 1 + 2,
    CAST_FAIL_TARGET_IS_IN_COMBAT = 99 + 1 + 2,
    CAST_FAIL_CANT_DO_THAT_YET_2 = 100 + 1 + 2,
    CAST_FAIL_TARGET_IS_DUELING = 101 + 1 + 2,
    CAST_FAIL_TARGET_IS_HOSTILE = 102 + 1 + 2,
    CAST_FAIL_TARGET_IS_TOO_ENRAGED_TO_CHARM = 103 + 1 + 2,
    CAST_FAIL_TARGET_IS_FRIENDLY = 104 + 1 + 2,
    CAST_FAIL_TARGET_CANT_BE_IN_COMBAT = 105 + 1 + 2,
    CAST_FAIL_CANT_TARGET_PLAYERS = 106 + 1 + 2,
    CAST_FAIL_TARGET_IS_ALIVE = 107 + 1 + 2,
    CAST_FAIL_TARGET_NOT_IN_YOUR_PARTY = 108 + 1 + 2,
    CAST_FAIL_CREATURE_MUST_BE_LOOTED_FIRST = 109 + 1 + 2,
    CAST_FAIL_AUCTION_HAVE_CANCEL = 110 + 1 + 2,
    CAST_FAIL_NOT_ITEM_TO_STEAL = 111 + 1 + 2,
    //CAST_FAIL_TARGET_IS_NOT_A_PLAYER = 107,
    //CAST_FAIL_NO_POCKETS_TO_PICK = 108,
    CAST_FAIL_TARGET_HAS_NO_WEAPONS_EQUIPPED = 112 + 1 + 2,
    CAST_FAIL_NOT_SKINNABLE = 113 + 1 + 2,
    CAST_FAIL_TOO_CLOSE = 115 + 1 + 2,
    CAST_FAIL_TOO_MANY_OF_THAT_ITEM_ALREADY = 116 + 1 + 2,
    CAST_FAIL_NOT_ENOUGH_TRAINING_POINTS = 118 + 1 + 2,
    CAST_FAIL_FAILED_ATTEMPT = 119 + 1 + 2,
    CAST_FAIL_TARGET_NEED_TO_BE_BEHIND = 120 + 1 + 2,
    CAST_FAIL_TARGET_NEED_TO_BE_INFRONT = 121 + 1 + 2,
    CAST_FAIL_PET_DOESNT_LIKE_THAT_FOOD = 122 + 1 + 2,
    CAST_FAIL_CANT_CAST_WHILE_FATIGUED = 123 + 1 + 2,
    CAST_FAIL_TARGET_MUST_BE_IN_THIS_INSTANCE = 124 + 1 + 2,
    CAST_FAIL_CANT_CAST_WHILE_TRADING = 125 + 1 + 2,
    CAST_FAIL_TARGET_IS_NOT_PARTY_OR_RAID = 126 + 1 + 2,
    CAST_FAIL_CANT_DISENCHANT_WHILE_LOOTING = 127 + 1 + 2,
    CAST_FAIL_TARGET_IS_IN_FFA_PVP_COMBAT = 133,
    //CAST_FAIL_TARGET_IS_NOT_A_GHOST = 128,    //SPELL_FAILED_TARGET_NOT_GHOST
    CAST_FAIL_NO_NEARBY_CORPSES_TO_EAT = 129 + 1 + 4,
    CAST_FAIL_CAN_ONLY_USE_IN_BATTLEGROUNDS = 130 + 1 + 4,
    CAST_FAIL_CANT_EQUIP_ON_LOW_RANK = 131 + 1 + 4,
    CAST_FAIL_YOUR_PET_CANT_LEARN_MORE_SKILLS = 132 + 1 + 4,
    CAST_FAIL_CANT_USE_NEW_ITEM = 133 + 1 + 4,
    CAST_FAIL_CANT_DO_IN_THIS_WEATHER = 134 + 1 + 4,
    CAST_FAIL_CANT_DO_IN_IMMUNE = 135 + 1 + 4,
    CAST_FAIL_CANT_DO_IN_XXX = 136 + 1 + 4,
    CAST_FAIL_GAME_TIME_OVER = 137 + 1 + 4,
    CAST_FAIL_NOT_ENOUGH_RANK = 138 + 1 + 4,
    CAST_FAIL_UNKNOWN_REASON = 139 + 1 + 4,
    CAST_FAIL_NUMREASONS
};

#define CREATURE_HEALTH_REGEN_PER_MS 0.001f
#define CREATURE_MANA_REGEN_PER_MS 0.005f

#define GO_RESPAWN_DELAY 15000

#define NUMBER_OF_RANDOM_WAYPOINTS_FOR_CREATURE 5
#define	NUMBER_OF_TARGETS_TO_AGRO	16
#define AMOUNT_OF_TIME_TO_CREATURE_WAIT_AT_WAYPOINT_MIN 1000 //it's given in ms
#define AMOUNT_OF_TIME_TO_CREATURE_WAIT_AT_WAYPOINT_DIF 10000 
#define CREATURE_CORPSE_DELAY	60000 //time until corpse is lootable
#define CREATURE_SKELET_DELAY	0 //time until the skelet is shown
#define CREATURE_RESPAWN_DELAY	15000 //aprox time until creature will be respawned. !each creature has it's own respawn time
//#define CREATURE_BOUND_RADIOUS 50 //minimum is 30 = genral spell range
//#define	CREATURE_ATACK_RANGE 5 //if distance is smaller then this value then we do not need to get closer
#define CREATURE_BOUND_RADIOUS 75 //minimum is 30 = genral spell range
//#define CREATURE_BOUND_RADIOUS_SQ 10000 //minimum is 30 = genral spell range
#define	CREATURE_ATACK_RANGE_SQ 25 //if distance is smaller then this value then we do not need to get closer
#define CREATURE_AGRO_FADE_AWAY_TIME 20000 //10 s. Should be bigger then interval when player sends agro again = respawn usulay
#define CREATURE_SPEED_MODIFYER	1
#define CREATURE_MAX_PATROL_DISTANCE 8 
#define CREATURE_MIN_PATROL_DISTANCE 4 
#define CREATURE_RECALIBRATE_RUSH_WHEN_TARGET_MOVES 2 //if target tryes to evade us then we change our corse

enum GameObject_State {
	GAMEOBJECT_WAITING					=0,
	GAMEOBJECT_RESPAWNING				=1,
};

#define CONFUSED_UNIT_SPIN_SPEED 0.2f

enum Player_State_general {
	PLAYER_STATE_JUST_CREATED		= 1,
	PLAYER_STATE_DEAD				= 2,
	PLAYER_STATE_IN_COMBAT			= 4,
	PLAYER_STATE_PREPARE_SPELL		= 8,
	PLAYER_STATE_CAST_SPELL			= 16,
	PLAYER_STATE_COOLDOWN_SPELL		= 32,
//	PLAYER_STATE_SILENCED			= 64,
	PLAYER_STATE_STUNNED			= 128,
	PLAYER_STATE_MOVED_SINCE_LAST_UPDATE	= 256,
	PLAYER_STATE_IN_WATER			= 512,
	PLAYER_STATE_INVITED_TO_GROUP	= 1024,
	PLAYER_STATE_CORPSE				= 2048,
	PLAYER_STATE_DROWNING			= 4096,
	PLAYER_STATE_EATING				= 8192,
	PLAYER_STATE_SOFT_FALL			= 16384,
	PLAYER_STATE_DUEL_PREPARE		= 32768,
	PLAYER_STATE_IN_DUEL			= 65536,
	PLAYER_STATE_DUEL_UTOFBOUNDS	= 131072,
};

enum UNIT_STATE_TYPES
{
	UNIT_STATE_CONFUSED				= 2147483648, //should wander around randomly, We just make him spin :)
	UNIT_STATE_ROOTED				= 1073741824, 
	UNIT_STATE_FLEE					= 536870912, 
	UNIT_STATE_STUN					= 268435456, 
	UNIT_STATE_STEALTHED			= 134217728, 
};

enum Creature_Instance_Flags
{
	CREATURE_FLAG_RANDOM_MOVE		= 1,
	CREATURE_FLAG_STAND				= 2,
	CREATURE_FLAG_WAYPOINT_WALKER	= 8,
	CREATURE_FLAG_ALWAYS_ACTIVE		= 16,
	CREATURE_FLAG_IMUNE_TO_MORPH	= 32,
	CREATURE_FLAG_CIVILIAN			= 64,
	CREATURE_FLAG_CASTER			= 128,//if possible (not moving and mana) then cast a spell
};

enum Creature_State {
	CREATURE_STATE_PATROLLING			= 1,
	CREATURE_STATE_ROAMING				= 2,
	CREATURE_STATE_EMOTE				= 4,
	CREATURE_STATE_CAST					= 8,
	CREATURE_STATE_RETURN_TO_LAST_POS	= 16,
	CREATURE_STATE_GUARD				= 32,
	CREATURE_STATE_FOLLOW				= 64,
	CREATURE_STATE_IN_COMBAT			= 128,
	CREATURE_STATE_PATROL_MOVE			= 256,
	CREATURE_STATE_PATROL_WAIT			= 512,
	CREATURE_STATE_LOOTABLE				= 1024,
	CREATURE_STATE_SKELETON				= 2048,
	CREATURE_STATE_RESPAWN				= 4096,
	CREATURE_STATE_DEAD					= 8192,
	CREATURE_STATE_ATACK				= 16384,
	CREATURE_STATE_HAS_LOOT_GENERATED	= 32768,
	CREATURE_STATE_VENDOR_SELL			= 65536,
	CREATURE_STATE_PAUSE_MOVEMENT		= 131072,
	CREATURE_STATE_PREPARE_CAST			= 262144,
	CREATURE_STATE_MOVED_SINCE_SYNC		= 524288,
	CREATURE_STATE_DIE_ON_TIMER			= 1048576,
};

/*
#define WORLD_EVENT_UPDATE_SET 1
#define WORLD_EVENT_UPDATE_SET_INTERVAL 1000
#define WORLD_EVENT_UPDATE_OBJECT 2
#define WORLD_EVENT_UPDATE_OBJECT_INTERVAL 1000
#define WORLD_EVENT_UPDATE_LOGOUT 3
#define WORLD_EVENT_UPDATE_LOGOUT_INTERVAL 1000
*/

#define	MAP_GOOD 0
#define MAP_BAD 1
#define MAP_ZONE_HUMAN	12
#define MAP_ZONE_ORC	14
#define MAP_ZONE_DWARF	1
#define MAP_ZONE_NIGHT_ELF	141
#define MAP_ZONE_UNDEAD	85
#define MAP_ZONE_TAUREN	215
#define MAP_ZONE_GNOME	1
#define MAP_ZONE_TROLL	14

#define NUMBER_OF_FACTIONS 64
#define NUMBER_OF_ACTION_BUTTONS 120
#define MAX_CHAR_NAME_LENGTH 30

enum System_message_send_type {
	SEND_MESSAGE_TO_EVRYBODY			= 1,
	SEND_MESSAGE_TO_ME					= 2,
	SEND_MESSAGE_TO_BLOCK				= 4,
	SEND_MESSAGE_TO_DEAD				= 8,
	SEND_MESSAGE_TO_ALLIVE				= 16,
	SEND_MESSAGE_TO_OTHERS				= 32,
	SEND_MESSAGE_TO_GROUP				= 64,
	SEND_MESSAGE_TO_TARGET				= 128,
};

//#define OBJECT_TYPE_PLAYER  (TYPE_PLAYER | TYPE_UNIT | TYPE_OBJECT)
#define OBJECT_TYPE_PLAYER  25
//#define OBJECT_TYPE_CREATURE  (TYPE_UNIT | TYPE_OBJECT)
#define OBJECT_TYPE_CREATURE 9
//#define OBJECT_TYPE_GO  (TYPE_GAMEOBJECT | TYPE_OBJECT)
#define OBJECT_TYPE_GO 33
//#define OBJECT_TYPE_ITEM  (TYPE_ITEM | TYPE_OBJECT)
#define OBJECT_TYPE_ITEM 3
//#define OBJECT_TYPE_CONTAINER  (TYPE_CONTAINER | TYPE_ITEM | TYPE_OBJECT)
#define OBJECT_TYPE_CONTAINER 7
//#define OBJECT_TYPE_CORPSE  (TYPE_CORPSE | TYPE_OBJECT)
#define OBJECT_TYPE_CORPSE 129
//uncomment this to use function owerride interupts
//#define USE_OBJECT_INTERRUPTS 1

//the size of a cell. each player will see 9 cells = block (player is in the midle)
#define MAPMGR_CELL_SIZE 50
#define Player_affect_neighbour_cells 1

//number of miliseconds the refresh thread will sleep if not awaiken by port event
//!!! not always we refresh the world when tread takes a new cycle
#define UPDATE_THREAD_MILISECONDS_SLEEP_MAX 300000	//300 ms

#define PLAYER_VISIBLE_ITEM_SIZE   12

//use only lowest byte to make difference between objects. Differece should be flag like and logical AND between them must be 0
enum HIGHGUID {
    HIGHGUID_ITEM          = 0x00000001,
    HIGHGUID_CONTAINER     = 0x00000002,
    HIGHGUID_UNIT          = 0x00000004,
    HIGHGUID_PLAYER        = 0x00000008,
    HIGHGUID_GAMEOBJECT    = 0x00000010,
    HIGHGUID_DYNAMICOBJECT = 0x00000011,
    HIGHGUID_CORPSE        = 0x00000012,
	HIGHGUID_OBJECT_TYPE_MASK = 0x000000FF,
};

//damage types for internal use. it stats from 127 to let space for game damage types 
enum DAMGE_TYPES_FOR_INTERNAL_USE
{
	DAMAGE_NON_BLOCKABLE	= 127,
};

enum Char_Create_Error_Codes
{
    CHAR_CREATE_OK				= 0x2E,
    CHAR_CREATE_FAILED			= 0x35,//max char create reached
    CHAR_CREATE_NAME_IN_USE		= 0x31,
    CHAR_DELETE_OK				= 0x3A,//old one was 0x35
    CHAR_DELETE_FAIL			= 0x36,
};

enum OBJECT_UPDATE_TYPE {
    UPDATETYPE_VALUES = 0,
//  8 bytes - GUID
//  Goto Update Block
    UPDATETYPE_MOVEMENT = 1,
//  8 bytes - GUID
//  Goto Position Update
    UPDATETYPE_CREATE_OBJECT = 2,
//  8 bytes - GUID
//  1 byte - Object Type (*)
//  Goto Position Update
//  Goto Update Block
    UPDATETYPE_CREATE_YOURSELF = 3,
    UPDATETYPE_OUT_OF_RANGE_OBJECTS = 4,
//  4 bytes - Count
//  Loop Count Times:
//  8 bytes - GUID
    UPDATETYPE_NEAR_OBJECTS = 5 // looks like 3 & 4 do the same thing
//  4 bytes - Count
//  Loop Count Times:
//  8 bytes - GUID
};

//////////////////////////////// player and unit constants //////////////////////////////
enum TYPE {
    TYPE_OBJECT         = 1,
    TYPE_ITEM           = 2,
    TYPE_CONTAINER      = 4,
    TYPE_UNIT           = 8,
    TYPE_PLAYER         = 16,
    TYPE_GAMEOBJECT     = 32,
    TYPE_DYNAMICOBJECT  = 64,
    TYPE_CORPSE         = 128,
    TYPE_AIGROUP        = 256,
    TYPE_AREATRIGGER    = 512
};

enum TYPEID {
    TYPEID_OBJECT        = 0,
    TYPEID_ITEM          = 1,
    TYPEID_CONTAINER     = 2,
    TYPEID_UNIT          = 3,
    TYPEID_PLAYER        = 4,
    TYPEID_GAMEOBJECT    = 5,
    TYPEID_DYNAMICOBJECT = 6,
    TYPEID_CORPSE        = 7,
    TYPEID_AIGROUP       = 8,
    TYPEID_AREATRIGGER   = 9
};

enum Player_Race_Type
{
	PLAYER_RACE_TYPE_HUMAN		= 1,
	PLAYER_RACE_TYPE_ORC		= 2,
	PLAYER_RACE_TYPE_DWARF		= 3,
	PLAYER_RACE_TYPE_NIGHT_ELF	= 4,
	PLAYER_RACE_TYPE_UNDEAD		= 5,
	PLAYER_RACE_TYPE_TAUREN		= 6,
	PLAYER_RACE_TYPE_GNOME		= 7,
	PLAYER_RACE_TYPE_TROLL		= 8,
	PLAYER_RACE_TYPE_GOBLIN     = 9,
	PLAYER_RACE_TYPE_BLOODELF   = 10,
	PLAYER_RACE_TYPE_DRAENEI    = 11,
};

enum Player_Class
{
	PLAYER_CLASS_WARRIOR	= 1,
	PLAYER_CLASS_PALADIN	= 2,
	PLAYER_CLASS_HUNTER		= 3,
	PLAYER_CLASS_ROGUE		= 4,
	PLAYER_CLASS_PRIEST		= 5,
	PLAYER_CLASS_SHAMAN		= 7,
	PLAYER_CLASS_MAGE		= 8,
	PLAYER_CLASS_WARLOCK	= 9,
	PLAYER_CLASS_DRUID		= 11,
};

enum Player_Movement_Type
{
    PLAYER_MOVE_ROOT       = 1,
    PLAYER_MOVE_UNROOT     = 2,
    PLAYER_MOVE_WATER_WALK = 3,
    PLAYER_MOVE_LAND_WALK  = 4,
};

enum Player_Speed_Type
{
    PLAYER_SPEED_TYPE_RUN      = 1,
    PLAYER_SPEED_TYPE_RUNBACK  = 2,
    PLAYER_SPEED_TYPE_SWIM     = 3,
    PLAYER_SPEED_TYPE_SWIMBACK = 4,
    PLAYER_SPEED_TYPE_WALK     = 5,
};

#define EQUIPMENT_SLOT_START         0
enum Equipment_Slot
{
   EQUIPMENT_SLOT_HEAD			= 0,
   EQUIPMENT_SLOT_NECK			= 1,
   EQUIPMENT_SLOT_SHOULDERS		= 2,
   EQUIPMENT_SLOT_BODY			= 3,
   EQUIPMENT_SLOT_CHEST			= 4,
   EQUIPMENT_SLOT_WAIST			= 5,
   EQUIPMENT_SLOT_LEGS			= 6,
   EQUIPMENT_SLOT_FEET			= 7,
   EQUIPMENT_SLOT_WRISTS		= 8,
   EQUIPMENT_SLOT_HANDS			= 9,
   EQUIPMENT_SLOT_FINGER1		= 10,
   EQUIPMENT_SLOT_FINGER2		= 11,
   EQUIPMENT_SLOT_TRINKET1		= 12,
   EQUIPMENT_SLOT_TRINKET2		= 13,
   EQUIPMENT_SLOT_BACK			= 14,
   EQUIPMENT_SLOT_MAINHAND		= 15,
   EQUIPMENT_SLOT_OFFHAND		= 16,
   EQUIPMENT_SLOT_RANGED		= 17,
   EQUIPMENT_SLOT_TABARD		= 18,
};

#define EQUIPMENT_SLOT_END           19
#define IS_BODY_SLOT(s) ((s) < EQUIPMENT_SLOT_END)

#define INVENTORY_SLOT_BAG_START     19
#define INVENTORY_SLOT_BAG_1         19
#define INVENTORY_SLOT_BAG_2         20
#define INVENTORY_SLOT_BAG_3         21
#define INVENTORY_SLOT_BAG_4         22
#define INVENTORY_SLOT_BAG_END       23

#define IS_BAG_SLOT(s) ((s) >= INVENTORY_SLOT_BAG_START && (s) < INVENTORY_SLOT_BAG_END)

#define INVENTORY_SLOT_ITEM_START    23 //(PLAYER_FIELD_INV_SLOT_HEAD-PLAYER_FIELD_PACK_SLOT_1)/2
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
#define INVENTORY_SLOT_ITEM_END      39//INVENTORY_SLOT_ITEM_START + (PLAYER_FIELD_BANK_SLOT_1-PLAYER_FIELD_PACK_SLOT_1)/2
/*
#define IS_BACKPACK_SLOT(s) ((s) > INVENTORY_SLOT_ITEM_START && (s) < INVENTORY_SLOT_ITEM_END)

#define IS_BANK_SLOT(s) ((s) > BANK_SLOT_ITEM_START && (s) < BANK_SLOT_ITEM_END)

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
#define BANK_SLOT_ITEM_END           63*/

#define IS_BANK_BAG_SLOT(s) ((s) > BANK_SLOT_BAG_START && (s) < BANK_SLOT_BAG_END)

#define BANK_SLOT_BAG_START          63
#define BANK_SLOT_BAG_1              63
#define BANK_SLOT_BAG_2              64
#define BANK_SLOT_BAG_3              65
#define BANK_SLOT_BAG_4              66
#define BANK_SLOT_BAG_5              67
#define BANK_SLOT_BAG_6              68
#define BANK_SLOT_BAG_END            69

#define GOLD(c) ((c)*10000)
#define SILVER(c) ((c)*100)

//found in a packet log player flags : 3104 = 2048 + 1024 + 32 = 800 + 400 + 20
//			3106
//			32
//			33 = 32 + 1 = 20 + 1
//			34
//			2058
//			2080
//			1056
//			1057
//			3105
//4096-> “jellow Smily right of the avitar telling you that you have more than 3 hours of online playing time and that you need to rest. 5 hours bla bla”
//8192-> “RED Smily right of the avitar telling you that you have more than 5 hours of online playing time and that you need to rest. 5 hours bla
//Player Stance: Death //AFK  
//PLAYER_FLAGS				0b00000000000000000000000000000010
//Player Stance: Resurrected (PLEASE CHECK)  DEATH LOOK // Ghost world
//PLAYER_FLAGS				0b00000000000000000000000000010000
//Player Onlogin: Name is in violance with the naming rules: 
//PLAYER_FLAGS				0b00000000000000000000000000100000
//Player Stance: Resting
//PLAYER_FLAGS				0b00000000000000000000000000100000
//Player PVP: Free For All PVP
//PLAYER_FLAGS				0b00000000000000000000000001000000
//Player PVP: Troggle PVP on/off Shows “You are now Flagged for PvP combat and will remain so until troggled off”
//PLAYER_FLAGS				0b00000000000000000000000010000000
//PLAYER_FLAGS				0b00000000000000000000000100000000
//PLAYER_FLAGS				0b00000000000000000000001000000000

enum PlayerFlags
{
   PLAYER_FLAG_GROUP_LEADER			= 0x01,
   PLAYER_FLAG_AFK					= 0x04,
   PLAYER_FLAG_AFK_					= 0x08,
   PLAYER_FLAG_DEAD					= 0x10,
   PLAYER_FLAG_RESTING				= 0x20,
   PLAYER_FLAG_DUEL					= 0x80,
   PLAYER_FLAG_FREE_FOR_ALL_PVP     = 0x80,
   PLAYER_FLAG_PVP_TOGGLE           = 0x200,
   PLAYER_FLAG_NEED_REST_3_HOURS    = 0x1000,
   PLAYER_FLAG_NEED_REST_5_HOURS    = 0x2000,
};

enum UnitFieldFlags
{
   U_FIELD_FLAG_LOCK_PLAYER            = 0x04,
   U_FIELD_FLAG_PLAYER_CONTROLLED         = 0x08,
   U_FIELD_FLAG_PLUS_MOB               = 0x40,
   U_FIELD_FLAG_PVP                  = 0x1000,
   //U_FIELD_FLAG_MOUNT_VISIBLE            = 0x1000,?
   U_FIELD_FLAG_MOUNT_SIT               = 0x2000,
   U_FIELD_FLAG_DEAD                  = 0x4000,
   U_FIELD_FLAG_DUEL_WINNER            = 0x40000,
   U_FIELD_FLAG_ATTACK_ANIMATION         = 0x80000,
   U_FIELD_FLAG_STAR_AFTER_NAME         = 0x100000,
   U_FIELD_FLAG_SKINNABLE               = 0x4000000,
   U_FIELD_FLAG_ALIVE                  = 0x10000, 
   U_FIELD_FLAG_WEAPON_OFF               = 0x40000000,
   //U_FIELD_FLAG_MAKE_CHAR_UNTOUCHABLE      = 0x8000000,
};

enum StandState
{
   STANDSTATE_STAND				= 0,
   STANDSTATE_SIT				= 1,
   STANDSTATE_SIT_CHAIR			= 2,
   STANDSTATE_SLEEP				= 3,
   STANDSTATE_SIT_LOW_CHAIR		= 4,
   STANDSTATE_SIT_MEDIUM_CHAIR	= 5,
   STANDSTATE_SIT_HIGH_CHAIR	= 6,
   STANDSTATE_DEAD				= 7,
   STANDSTATE_KNEEL				= 8
};

//---------------------------------------------------------
//  Dynamic flags for units
//---------------------------------------------------------
// Unit has blinking stars effect showing lootable
#define UNIT_DYNFLAG_LOOTABLE			0x0001
// Shows marked unit as small red dot on radar
#define UNIT_DYNFLAG_TRACK_UNIT         0x0002
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
// No flags defined
#define UNIT_FLAG_NONE					0x0000
#define UNIT_FLAG_UNK1					0x0001
// Unit is not attackable
#define UNIT_FLAG_NOT_ATTACKABLE		0x0002
#define UNIT_FLAG_LOCKED				0x0004
#define UNIT_FLAGS_RETURN_HOME			0x0006
// Unit becomes temporarily hostile, shows in red, allows attack
#define UNIT_FLAG_ATTACKABLE			0x0008
#define UNIT_FLAG_UNK3					0x0010
#define UNIT_FLAG_UNK4					0x0020
#define UNIT_FLAG_UNK5					0x0040
// Unit cannot be attacked by player, shows no attack cursor
#define UNIT_FLAG_NOT_ATTACKABLE_1      0x0080
#define UNIT_FLAG_UNK6					0x0100
#define UNIT_FLAG_UNK7					0x0200
// Unit cannot be attacked by player, shows in blue
#define UNIT_FLAG_NON_PVP_PLAYER		(UNIT_FLAG_ATTACKABLE | UNIT_FLAG_NOT_ATTACKABLE_1)
// Doesn't play animation
#define UNIT_FLAG_ANIMATION_FROZEN      0x0400
#define UNIT_FLAG_UNK8					0x0800
#define UNIT_FLAG_WAR_PLAYER			0x1000//Show for Example "A proud Member of the Horde..." etc. when resurrecting a friend or fighting
#define UNIT_FLAG_MOUNTED				0x2000
#define UNIT_FLAG_UNK10					0x4000
#define UNIT_FLAG_UNK11					0x8000
#define UNIT_FLAG_UNK13					0x10000
#define UNIT_FLAG_UNK14					0x20000
#define UNIT_FLAG_UNK15					0x40000
#define UNIT_FLAG_IN_COMBAT				0x80000 //some trainers if have this they will not show the book mouse cursor
#define UNIT_FLAG_UNK17					0x100000
#define UNIT_FLAG_UNK18					0x200000
#define UNIT_FLAG_UNK19					0x400000
#define UNIT_FLAG_UNK20					0x800000
#define UNIT_FLAG_UNK21					0x1000000
#define UNIT_FLAG_UNK22					0x2000000
#define UNIT_FLAG_UNK23					0x4000000
#define UNIT_FLAG_UNK24					0x8000000
#define UNIT_FLAG_UNK25					0x10000000
#define UNIT_FLAG_UNK26					0x20000000
#define UNIT_FLAG_SKINNABLE				(UNIT_FLAG_UNK23 | UNIT_FLAG_UNK10)
#define UNIT_FLAG_SPIRITHEALER			(UNIT_FLAG_UNK19 | UNIT_FLAG_UNK21 | UNIT_FLAG_NOT_ATTACKABLE | UNIT_FLAG_LOCKED | UNIT_FLAG_UNK4 | UNIT_FLAG_UNK5)

#define UNIT_NORMAL_WALK_SPEED			3.5f
#define UNIT_NORMAL_RUN_SPEED			8.5f
#define UNIT_NORMAL_RUN_BACK_SPEED		4.5f
#define UNIT_NORMAL_WALK_BACK_SPEED		4.5f
#define UNIT_NORMAL_SWIM_SPEED			4.72f
#define UNIT_NORMAL_SWIM_BACK_SPEED		3.5f
#define UNIT_NORMAL_FLY_SPEED			8.5f
#define UNIT_NORMAL_FLY_BACK_SPEED		4.5f
#define UNIT_NORMAL_TURN_SPEED			3.14f

enum NPCFlags {
   	UNIT_NPC_FLAG_NONE              = 0,
    UNIT_NPC_FLAG_GOSSIP            = 1,
    UNIT_NPC_FLAG_QUESTGIVER        = 2,
    UNIT_NPC_FLAG_VENDOR            = 4,
    UNIT_NPC_FLAG_TAXIVENDOR        = 8,
    UNIT_NPC_FLAG_TRAINER           = 16,
    UNIT_NPC_FLAG_SPIRITHEALER      = 32,
    UNIT_NPC_FLAG_GUARD             = 64,                   //UQ1: ???  We can use as guard flag?
    UNIT_NPC_FLAG_INNKEEPER         = 128,
    UNIT_NPC_FLAG_BANKER            = 256,
    UNIT_NPC_FLAG_PETITIONER        = 512,
    UNIT_NPC_FLAG_TABARDVENDOR      = 1024,
    UNIT_NPC_FLAG_BATTLEFIELDPERSON = 2048,
    UNIT_NPC_FLAG_AUCTIONEER        = 4096,
    UNIT_NPC_FLAG_STABLE            = 8192,
    UNIT_NPC_FLAG_ARMORER           = 16384,

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
   LANG_GUTTERSPEAK   = 33,
   NUM_LANGUAGES
} Language;

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
    FORM_MOONKIN          = 31
};
