#include "stdafx.h"
#include "RealmServer.h"
#include "Globals.h"
#include "Creature.h"
#include "CreatureTemplate.h"
#include "ItemTemplate.h"
#include "SpawnPoint.h"
#include "Container.h"
#include "LootTable.h"
#include "Zone.h"
#include "PathGroup.h"
#include "ChatManager.h"
#include "DataBuffer.h"
#include "Debug.h"
#include "Guild.h"
#include "antidebuggers.h"
#include "Corpse.h"
#include "GameObjectTemplate.h"
#include "NPCText.h"
#include "Mail.h"
#include "Quest.h"
#include "TrainerTemplate.h"
#include "ConsoleDlg.h"
#include "dbc_structs.h"

#define NUM_GRAVEYARDS 66
_Graveyard SHLocations[NUM_GRAVEYARDS]=
{
	{ {-637.3295f, -4293.471f, 40.36089f}, 1},      //  Valley of trials
	{ {-8935.325195f, -188.646271f, 80.416466f}, 0},//  human starting zone cemetery
	{ {-9341.788f, 177.7866f, 61.56488f}, 0},       //  Goldshire
	{ {-5681.76f, -520.6374f, 396.2743f}, 0},       //  Kharanos
	{ {10384.810f, 811.531f, 1317.538f}, 1},        //  Aldrassil - elfs starting zone cemetery
	{ {2603.311f, -534.657f, 89.000f}, 0},          //  Faol's Rest
	{ {-6164.226f, 336.321f, 399.793f}, 0},         //  Coldridge valley - gnomes and dwarfs starting zone cemetery
	{ {-3525.706f, -4315.455f, 6.996f}, 1},         //  Dustwallow Marsh
	{ {-3127.690f, -3046.940f, 33.831f}, 1},        //	Dustwallow Marsh
	{ {-1072.589f, -3481.849f, 62.695f}, 1},        //	Ratchet
	{ {-592.601f, -2523.492f, 91.788f}, 1},         //	The Barrens
	{ {-2515.993f, -1966.481f, 91.784f}, 1},        //	Southern Barrens
	{ {-778.000f, -4985.000f, 18.944f}, 1},         //	Sen'jin Village
	{ {238.027f, -4792.516f, 10.213f}, 1},          //	Razor Hill
	{ {-1443.488f, 1973.370f, 85.491f}, 1},         //	Kodo Graveyard
	{ {4291.283f, 96.956f, 43.075f}, 1},            //	Twilight Vale
	{ {6739.190f, 209.993f, 23.285f}, 1},           //	Darkshore
	{ {2681.058f, -4009.754f, 107.849f}, 1},        //	Azshara
	{ {2942.760f, -6037.130f, 4.104f}, 1},          //	Southbridge Beach
	{ {2633.411f, -629.735f, 107.581f}, 1},         //	Astranaar
	{ {2421.724f, -2953.619f, 123.473f}, 1},        //	Nightsong Woods
	{ {-7490.450f, -2132.620f, 142.186f}, 0},       //	Flame Crest
	{ {-5351.229f, -2881.582f, 340.942f}, 0},       //	Loch Modan
	{ {-732.799f, -592.502f, 22.663f}, 0},          //	Southshore
	{ {-2175.190f, -342.027f, -5.512f}, 1},         //	Bloodhoof Village
	{ {908.323f, -1520.286f, 55.037f}, 0},          //	Chillwind Camp
	{ {-10546.900f, 1197.240f, 31.724f}, 0},        //	Sentinel Hill
	{ {-3289.124f, -2435.991f, 18.597f}, 0},        //	Wetlands
	{ {-3349.342f, -856.986f, 1.060f}, 0},          //	Baradin Bay
	{ {1880.739f, 1624.735f, 94.434f}, 0},          //	Deathknell  - undeads starting zone cemetery
	{ {2349.608f, 485.208f, 33.373f}, 0},           //	Brill
	{ {1750.344f, -669.790f, 44.570f}, 0},          //	The Bulwark
	{ {7426.000f, -2809.000f, 463.961f}, 1},        //	Moonglade
	{ {323.513f, -2227.196f, 137.617f}, 0},         //	Aerie Peak
	{ {-10567.813f, -3377.203f, 22.253f}, 0},       //	Stonard
	{ {-11542.560f, -228.637f, 27.843f}, 0},        //	Stranglehorn Vale
	{ {-14284.962f, 288.447f, 32.332f}, 0},         //	The Cape of Stranglehorn
	{ {516.194f, 1589.807f, 127.545f}, 0},          //	The Sepulcher
	{ {-6450.610f, -1113.510f, 308.021f}, 0},       //	Searing Gorge
	{ {-9403.245f, -2037.692f, 58.369f}, 0},        //	Redridge Mountains
	{ {2116.790f, -5287.337f, 81.132f}, 0},         //	Light's Hope Chapel
	{ {1392.000f, -3701.000f, 76.701f}, 0},         //	Darrowshire
	{ {-10774.263f, -1189.672f, 33.149f}, 0},       //	Darkshire
	{ {-11110.377f, -1833.241f, 71.864f}, 0},       //	Morgan's Plot
	{ {-10846.574f, -2949.488f, 13.227f}, 0},       //	Dreadmaul Hold
	{ {-6808.382f, -2286.167f, 280.752f}, 0},       //	Badlands
	{ {-1472.289f, -2617.959f, 49.277f}, 0},        //	Arathi Highlands
	{ {-18.678f, -981.171f, 55.838f}, 0},           //	Tarren Mill
	{ {6858.564f, -4663.245f, 701.363f}, 1},        //	Everlook
	{ {-7205.565f, -2436.674f, -218.161f}, 1},      //	The Marshlands
	{ {-5530.283f, -3459.280f, -45.744f}, 1},       //	Thousand Needles
	{ {9701.255f, 945.620f, 1291.355f}, 1},         //	Dolanaar
	{ {-7190.949f, -3944.652f, 9.227f}, 1},         //	Gadgetzan
	{ {899.100f, 437.556f, 65.742f}, 1},            //	Webwinder Path
	{ {-6432.256f, -278.292f, 3.794f}, 1},          //	Valor's Rest
	{ {-4596.404f, 3229.434f, 8.994f}, 1},          //	Feathermoon Stronghold
	{ {-4439.967f, 370.153f, 51.357f}, 1},          //	Camp Mojache
	{ {-4656.000f, -1765.000f, -41.173f}, 1},       //	Thousand Needles
	{ {3806.540f, -1600.291f, 218.831f}, 1},        //	Morlos'Aran
	{ {5935.470f, -1217.750f, 383.202f}, 1},        //	Irontree Woods
	{ {4788.780f, -6845.000f, 89.790f}, 1},         //	Legash Encampent
	{ {-1078.000f, -305.000f, 58.000f}, 30},        //  Frostwolf, Alterac Valley
	{ {667.186f, -307.983f, 30.291f}, 30},          //  Stormpike, Alterac Valley
	{ {-198.000f, -113.000f, 79.000f}, 30},         //  Snow Cemetery, Alterac Valley
	{ {1415.330f, 1554.790f, 343.156f}, 489},       //  Alliance Cemetery, Warsong Gulch
	{ {1029.140f, 1387.490f, 340.836f}, 489}        //  Horde Cemetery, Warsong Gulch
};

char *OpcodeNames[]={
	"MSG_NULL_ACTION",
		"CMSG_BOOTME",
		"CMSG_DBLOOKUP",
		"SMSG_DBLOOKUP",
		"CMSG_QUERY_OBJECT_POSITION",
		"SMSG_QUERY_OBJECT_POSITION",
		"CMSG_QUERY_OBJECT_ROTATION",
		"SMSG_QUERY_OBJECT_ROTATION",
		"CMSG_WORLD_TELEPORT",
		"CMSG_TELEPORT_TO_UNIT",
		"CMSG_ZONE_MAP",
		"SMSG_ZONE_MAP",
		"CMSG_DEBUG_CHANGECELLZONE",
		"CMSG_EMBLAZON_TABARD_OBSOLETE",
		"CMSG_UNEMBLAZON_TABARD_OBSOLETE",
		"CMSG_RECHARGE",
		"CMSG_LEARN_SPELL",
		"CMSG_CREATEMONSTER",
		"CMSG_DESTROYMONSTER",
		"CMSG_CREATEITEM",
		"CMSG_CREATEGAMEOBJECT",
		"CMSG_MAKEMONSTERATTACKME_OBSOLETE",
		"CMSG_MAKEMONSTERATTACKGUID",
		"CMSG_ENABLEDEBUGCOMBATLOGGING_OBSOLETE",
		"CMSG_FORCEACTION",
		"CMSG_FORCEACTIONONOTHER",
		"CMSG_FORCEACTIONSHOW",
		"SMSG_FORCEACTIONSHOW",
		"SMSG_ATTACKERSTATEUPDATEDEBUGINFO_OBSOLETE",
		"SMSG_DEBUGINFOSPELL_OBSOLETE",
		"SMSG_DEBUGINFOSPELLMISS_OBSOLETE",
		"SMSG_DEBUG_PLAYER_RANGE_OBSOLETE",
		"CMSG_UNDRESSPLAYER",
		"CMSG_BEASTMASTER",
		"CMSG_GODMODE",
		"SMSG_GODMODE",
		"CMSG_CHEAT_SETMONEY",
		"CMSG_LEVEL_CHEAT",
		"CMSG_PET_LEVEL_CHEAT",
		"CMSG_LEVELUP_CHEAT_OBSOLETE",
		"CMSG_COOLDOWN_CHEAT",
		"CMSG_USE_SKILL_CHEAT",
		"CMSG_FLAG_QUEST",
		"CMSG_FLAG_QUEST_FINISH",
		"CMSG_CLEAR_QUEST",
		"CMSG_SEND_EVENT",
		"CMSG_DEBUG_AISTATE",
		"SMSG_DEBUG_AISTATE",
		"CMSG_DISABLE_PVP_CHEAT",
		"CMSG_ADVANCE_SPAWN_TIME",
		"CMSG_PVP_PORT_OBSOLETE",
		"CMSG_AUTH_SRP6_BEGIN",
		"CMSG_AUTH_SRP6_PROOF",
		"CMSG_AUTH_SRP6_RECODE",
		"CMSG_CHAR_CREATE",
		"CMSG_CHAR_ENUM",
		"CMSG_CHAR_DELETE",
		"SMSG_AUTH_SRP6_RESPONSE",
		"SMSG_CHAR_CREATE",
		"SMSG_CHAR_ENUM",
		"SMSG_CHAR_DELETE",
		"CMSG_PLAYER_LOGIN",
		"SMSG_NEW_WORLD",
		"SMSG_TRANSFER_PENDING",
		"SMSG_TRANSFER_ABORTED",
		"SMSG_CHARACTER_LOGIN_FAILED",
		"SMSG_LOGIN_SETTIMESPEED",
		"SMSG_GAMETIME_UPDATE",
		"CMSG_GAMETIME_SET",
		"SMSG_GAMETIME_SET",
		"CMSG_GAMESPEED_SET",
		"SMSG_GAMESPEED_SET",
		"CMSG_SERVERTIME",
		"SMSG_SERVERTIME",
		"CMSG_PLAYER_LOGOUT",
		"CMSG_LOGOUT_REQUEST",
		"SMSG_LOGOUT_RESPONSE",
		"SMSG_LOGOUT_COMPLETE",
		"CMSG_LOGOUT_CANCEL",
		"SMSG_LOGOUT_CANCEL_ACK",
		"CMSG_NAME_QUERY",
		"SMSG_NAME_QUERY_RESPONSE",
		"CMSG_PET_NAME_QUERY",
		"SMSG_PET_NAME_QUERY_RESPONSE",
		"CMSG_GUILD_QUERY",
		"SMSG_GUILD_QUERY_RESPONSE",
		"CMSG_ITEM_QUERY_SINGLE",
		"CMSG_ITEM_QUERY_MULTIPLE",
		"SMSG_ITEM_QUERY_SINGLE_RESPONSE",
		"SMSG_ITEM_QUERY_MULTIPLE_RESPONSE",
		"CMSG_PAGE_TEXT_QUERY",
		"SMSG_PAGE_TEXT_QUERY_RESPONSE",
		"CMSG_QUEST_QUERY",
		"SMSG_QUEST_QUERY_RESPONSE",
		"CMSG_GAMEOBJECT_QUERY",
		"SMSG_GAMEOBJECT_QUERY_RESPONSE",
		"CMSG_CREATURE_QUERY",
		"SMSG_CREATURE_QUERY_RESPONSE",
		"CMSG_WHO",
		"SMSG_WHO",
		"CMSG_WHOIS",
		"SMSG_WHOIS",
		"CMSG_FRIEND_LIST",
		"SMSG_FRIEND_LIST",
		"SMSG_FRIEND_STATUS",
		"CMSG_ADD_FRIEND",
		"CMSG_DEL_FRIEND",
		"SMSG_IGNORE_LIST",
		"CMSG_ADD_IGNORE",
		"CMSG_DEL_IGNORE",
		"CMSG_GROUP_INVITE",
		"SMSG_GROUP_INVITE",
		"CMSG_GROUP_CANCEL",
		"SMSG_GROUP_CANCEL",
		"CMSG_GROUP_ACCEPT",
		"CMSG_GROUP_DECLINE",
		"SMSG_GROUP_DECLINE",
		"CMSG_GROUP_UNINVITE",
		"CMSG_GROUP_UNINVITE_GUID",
		"SMSG_GROUP_UNINVITE",
		"CMSG_GROUP_SET_LEADER",
		"SMSG_GROUP_SET_LEADER",
		"CMSG_LOOT_METHOD",
		"CMSG_GROUP_DISBAND",
		"SMSG_GROUP_DESTROYED",
		"SMSG_GROUP_LIST",
		"SMSG_PARTY_MEMBER_STATS",
		"SMSG_PARTY_COMMAND_RESULT",
		"UMSG_UPDATE_GROUP_MEMBERS",
		"CMSG_GUILD_CREATE",
		"CMSG_GUILD_INVITE",
		"SMSG_GUILD_INVITE",
		"CMSG_GUILD_ACCEPT",
		"CMSG_GUILD_DECLINE",
		"SMSG_GUILD_DECLINE",
		"CMSG_GUILD_INFO",
		"SMSG_GUILD_INFO",
		"CMSG_GUILD_ROSTER",
		"SMSG_GUILD_ROSTER",
		"CMSG_GUILD_PROMOTE",
		"CMSG_GUILD_DEMOTE",
		"CMSG_GUILD_LEAVE",
		"CMSG_GUILD_REMOVE",
		"CMSG_GUILD_DISBAND",
		"CMSG_GUILD_LEADER",
		"CMSG_GUILD_MOTD",
		"SMSG_GUILD_EVENT",
		"SMSG_GUILD_COMMAND_RESULT",
		"UMSG_UPDATE_GUILD",
		"CMSG_MESSAGECHAT",
		"SMSG_MESSAGECHAT",
		"CMSG_JOIN_CHANNEL",
		"CMSG_LEAVE_CHANNEL",
		"SMSG_CHANNEL_NOTIFY",
		"CMSG_CHANNEL_LIST",
		"SMSG_CHANNEL_LIST",
		"CMSG_CHANNEL_PASSWORD",
		"CMSG_CHANNEL_SET_OWNER",
		"CMSG_CHANNEL_OWNER",
		"CMSG_CHANNEL_MODERATOR",
		"CMSG_CHANNEL_UNMODERATOR",
		"CMSG_CHANNEL_MUTE",
		"CMSG_CHANNEL_UNMUTE",
		"CMSG_CHANNEL_INVITE",
		"CMSG_CHANNEL_KICK",
		"CMSG_CHANNEL_BAN",
		"CMSG_CHANNEL_UNBAN",
		"CMSG_CHANNEL_ANNOUNCEMENTS",
		"CMSG_CHANNEL_MODERATE",
		"SMSG_UPDATE_OBJECT",
		"SMSG_DESTROY_OBJECT",
		"CMSG_USE_ITEM",
		"CMSG_OPEN_ITEM",
		"CMSG_READ_ITEM",
		"SMSG_READ_ITEM_OK",
		"SMSG_READ_ITEM_FAILED",
		"SMSG_ITEM_COOLDOWN",
		"CMSG_GAMEOBJ_USE",
		"CMSG_GAMEOBJ_CHAIR_USE_OBSOLETE",
		"SMSG_GAMEOBJECT_CUSTOM_ANIM",
		"CMSG_AREATRIGGER",
		"MSG_MOVE_START_FORWARD",
		"MSG_MOVE_START_BACKWARD",
		"MSG_MOVE_STOP",
		"MSG_MOVE_START_STRAFE_LEFT",
		"MSG_MOVE_START_STRAFE_RIGHT",
		"MSG_MOVE_STOP_STRAFE",
		"MSG_MOVE_JUMP",
		"MSG_MOVE_START_TURN_LEFT",
		"MSG_MOVE_START_TURN_RIGHT",
		"MSG_MOVE_STOP_TURN",
		"MSG_MOVE_START_PITCH_UP",
		"MSG_MOVE_START_PITCH_DOWN",
		"MSG_MOVE_STOP_PITCH",
		"MSG_MOVE_SET_RUN_MODE",
		"MSG_MOVE_SET_WALK_MODE",
		"MSG_MOVE_TOGGLE_LOGGING",
		"MSG_MOVE_TELEPORT",
		"MSG_MOVE_TELEPORT_CHEAT",
		"MSG_MOVE_TELEPORT_ACK",
		"MSG_MOVE_TOGGLE_FALL_LOGGING",
		"MSG_MOVE_FALL_LAND",
		"MSG_MOVE_START_SWIM",
		"MSG_MOVE_STOP_SWIM",
		"MSG_MOVE_SET_RUN_SPEED_CHEAT",
		"MSG_MOVE_SET_RUN_SPEED",
		"MSG_MOVE_SET_RUN_BACK_SPEED_CHEAT",
		"MSG_MOVE_SET_RUN_BACK_SPEED",
		"MSG_MOVE_SET_WALK_SPEED_CHEAT",
		"MSG_MOVE_SET_WALK_SPEED",
		"MSG_MOVE_SET_SWIM_SPEED_CHEAT",
		"MSG_MOVE_SET_SWIM_SPEED",
		"MSG_MOVE_SET_SWIM_BACK_SPEED_CHEAT",
		"MSG_MOVE_SET_SWIM_BACK_SPEED",
		"MSG_MOVE_SET_ALL_SPEED_CHEAT",
		"MSG_MOVE_SET_TURN_RATE_CHEAT",
		"MSG_MOVE_SET_TURN_RATE",
		"MSG_MOVE_TOGGLE_COLLISION_CHEAT",
		"MSG_MOVE_SET_FACING",
		"MSG_MOVE_SET_PITCH",
		"MSG_MOVE_WORLDPORT_ACK",
		"SMSG_MONSTER_MOVE",
		"SMSG_MOVE_WATER_WALK",
		"SMSG_MOVE_LAND_WALK",
		"MSG_MOVE_SET_RAW_POSITION_ACK",
		"CMSG_MOVE_SET_RAW_POSITION",
		"SMSG_FORCE_RUN_SPEED_CHANGE",
		"CMSG_FORCE_RUN_SPEED_CHANGE_ACK",
		"SMSG_FORCE_RUN_BACK_SPEED_CHANGE",
		"CMSG_FORCE_RUN_BACK_SPEED_CHANGE_ACK",
		"SMSG_FORCE_SWIM_SPEED_CHANGE",
		"CMSG_FORCE_SWIM_SPEED_CHANGE_ACK",
		"SMSG_FORCE_MOVE_ROOT",
		"CMSG_FORCE_MOVE_ROOT_ACK",
		"SMSG_FORCE_MOVE_UNROOT",
		"CMSG_FORCE_MOVE_UNROOT_ACK",
		"MSG_MOVE_ROOT",
		"MSG_MOVE_UNROOT",
		"MSG_MOVE_HEARTBEAT",
		"SMSG_MOVE_KNOCK_BACK",
		"CMSG_MOVE_KNOCK_BACK_ACK",
		"MSG_MOVE_KNOCK_BACK",
		"SMSG_MOVE_FEATHER_FALL",
		"SMSG_MOVE_NORMAL_FALL",
		"SMSG_MOVE_SET_HOVER",
		"SMSG_MOVE_UNSET_HOVER",
		"CMSG_MOVE_HOVER_ACK",
		"MSG_MOVE_HOVER",
		"CMSG_TRIGGER_CINEMATIC_CHEAT",
		"CMSG_OPENING_CINEMATIC",
		"SMSG_TRIGGER_CINEMATIC",
		"CMSG_NEXT_CINEMATIC_CAMERA",
		"CMSG_COMPLETE_CINEMATIC",
		"SMSG_TUTORIAL_FLAGS",
		"CMSG_TUTORIAL_FLAG",
		"CMSG_TUTORIAL_CLEAR",
		"CMSG_TUTORIAL_RESET",
		"CMSG_STANDSTATECHANGE",
		"CMSG_EMOTE",
		"SMSG_EMOTE",
		"CMSG_TEXT_EMOTE",
		"SMSG_TEXT_EMOTE",
		"CMSG_AUTOEQUIP_GROUND_ITEM",
		"CMSG_AUTOSTORE_GROUND_ITEM",
		"CMSG_AUTOSTORE_LOOT_ITEM",
		"CMSG_STORE_LOOT_IN_SLOT",
		"CMSG_AUTOEQUIP_ITEM",
		"CMSG_AUTOSTORE_BAG_ITEM",
		"CMSG_SWAP_ITEM",
		"CMSG_SWAP_INV_ITEM",
		"CMSG_SPLIT_ITEM",
		"CMSG_PICKUP_ITEM",
		"CMSG_DROP_ITEM",
		"CMSG_DESTROYITEM",
		"SMSG_INVENTORY_CHANGE_FAILURE",
		"SMSG_OPEN_CONTAINER",
		"CMSG_INSPECT",
		"SMSG_INSPECT",
		"CMSG_INITIATE_TRADE",
		"CMSG_BEGIN_TRADE",
		"CMSG_BUSY_TRADE",
		"CMSG_IGNORE_TRADE",
		"CMSG_ACCEPT_TRADE",
		"CMSG_UNACCEPT_TRADE",
		"CMSG_CANCEL_TRADE",
		"CMSG_SET_TRADE_ITEM",
		"CMSG_CLEAR_TRADE_ITEM",
		"CMSG_SET_TRADE_GOLD",
		"SMSG_TRADE_STATUS",
		"SMSG_TRADE_STATUS_EXTENDED",
		"SMSG_INITIALIZE_FACTIONS",
		"SMSG_SET_FACTION_VISIBLE",
		"SMSG_SET_FACTION_STANDING",
		"CMSG_SET_FACTION_ATWAR",
		"CMSG_SET_FACTION_CHEAT",
		"SMSG_SET_PROFICIENCY",
		"CMSG_SET_ACTION_BUTTON",
		"SMSG_ACTION_BUTTONS",
		"SMSG_INITIAL_SPELLS",
		"SMSG_LEARNED_SPELL",
		"SMSG_SUPERCEDED_SPELL",
		"CMSG_NEW_SPELL_SLOT",
		"CMSG_CAST_SPELL",
		"CMSG_CANCEL_CAST",
		"SMSG_CAST_RESULT",
		"SMSG_SPELL_START",
		"SMSG_SPELL_GO",
		"SMSG_SPELL_FAILURE",
		"SMSG_SPELL_COOLDOWN",
		"SMSG_COOLDOWN_EVENT",
		"CMSG_CANCEL_AURA",
		"SMSG_UPDATE_AURA_DURATION",
		"SMSG_PET_CAST_FAILED",
		"MSG_CHANNEL_START",
		"MSG_CHANNEL_UPDATE",
		"CMSG_CANCEL_CHANNELLING",
		"SMSG_AI_REACTION",
		"CMSG_SET_SELECTION",
		"CMSG_SET_TARGET_OBSOLETE",
		"CMSG_UNUSED",
		"CMSG_UNUSED2",
		"CMSG_ATTACKSWING",
		"CMSG_ATTACKSTOP",
		"SMSG_ATTACKSTART",
		"SMSG_ATTACKSTOP",
		"SMSG_ATTACKSWING_NOTINRANGE",
		"SMSG_ATTACKSWING_BADFACING",
		"SMSG_ATTACKSWING_NOTSTANDING",
		"SMSG_ATTACKSWING_DEADTARGET",
		"SMSG_ATTACKSWING_CANT_ATTACK",
		"SMSG_ATTACKERSTATEUPDATE",
		"SMSG_VICTIMSTATEUPDATE_OBSOLETE",
		"SMSG_DAMAGE_DONE_OBSOLETE",
		"SMSG_DAMAGE_TAKEN_OBSOLETE",
		"SMSG_CANCEL_COMBAT",
		"SMSG_PLAYER_COMBAT_XP_GAIN_OBSOLETE",
		"SMSG_HEALSPELL_ON_PLAYER_OBSOLETE",
		"SMSG_HEALSPELL_ON_PLAYERS_PET_OBSOLETE",
		"CMSG_SHEATHE_OBSOLETE",
		"CMSG_SAVE_PLAYER",
		"CMSG_SETDEATHBINDPOINT",
		"SMSG_BINDPOINTUPDATE",
		"CMSG_GETDEATHBINDZONE",
		"SMSG_BINDZONEREPLY",
		"SMSG_PLAYERBOUND",
		"SMSG_DEATH_NOTIFY_OBSOLETE",
		"CMSG_REPOP_REQUEST",
		"SMSG_RESURRECT_REQUEST",
		"CMSG_RESURRECT_RESPONSE",
		"CMSG_LOOT",
		"CMSG_LOOT_MONEY",
		"CMSG_LOOT_RELEASE",
		"SMSG_LOOT_RESPONSE",
		"SMSG_LOOT_RELEASE_RESPONSE",
		"SMSG_LOOT_REMOVED",
		"SMSG_LOOT_MONEY_NOTIFY",
		"SMSG_LOOT_ITEM_NOTIFY",
		"SMSG_LOOT_CLEAR_MONEY",
		"SMSG_ITEM_PUSH_RESULT",
		"SMSG_DUEL_REQUESTED",
		"SMSG_DUEL_OUTOFBOUNDS",
		"SMSG_DUEL_INBOUNDS",
		"SMSG_DUEL_COMPLETE",
		"SMSG_DUEL_WINNER",
		"CMSG_DUEL_ACCEPTED",
		"CMSG_DUEL_CANCELLED",
		"SMSG_MOUNTRESULT",
		"SMSG_DISMOUNTRESULT",
		"SMSG_PUREMOUNT_CANCELLED_OBSOLETE",
		"CMSG_MOUNTSPECIAL_ANIM",
		"SMSG_MOUNTSPECIAL_ANIM",
		"SMSG_PET_TAME_FAILURE",
		"CMSG_PET_SET_ACTION",
		"CMSG_PET_ACTION",
		"CMSG_PET_ABANDON",
		"CMSG_PET_RENAME",
		"SMSG_PET_NAME_INVALID",
		"SMSG_PET_SPELLS",
		"SMSG_PET_MODE",
		"CMSG_GOSSIP_HELLO",
		"CMSG_GOSSIP_SELECT_OPTION",
		"SMSG_GOSSIP_MESSAGE",
		"SMSG_GOSSIP_COMPLETE",
		"CMSG_NPC_TEXT_QUERY",
		"SMSG_NPC_TEXT_UPDATE",
		"SMSG_NPC_WONT_TALK",
		"CMSG_QUESTGIVER_STATUS_QUERY",
		"SMSG_QUESTGIVER_STATUS",
		"CMSG_QUESTGIVER_HELLO",
		"SMSG_QUESTGIVER_QUEST_LIST",
		"CMSG_QUESTGIVER_QUERY_QUEST",
		"CMSG_QUESTGIVER_QUEST_AUTOLAUNCH",
		"SMSG_QUESTGIVER_QUEST_DETAILS",
		"CMSG_QUESTGIVER_ACCEPT_QUEST",
		"CMSG_QUESTGIVER_COMPLETE_QUEST",
		"SMSG_QUESTGIVER_REQUEST_ITEMS",
		"CMSG_QUESTGIVER_REQUEST_REWARD",
		"SMSG_QUESTGIVER_OFFER_REWARD",
		"CMSG_QUESTGIVER_CHOOSE_REWARD",
		"SMSG_QUESTGIVER_QUEST_INVALID",
		"CMSG_QUESTGIVER_CANCEL",
		"SMSG_QUESTGIVER_QUEST_COMPLETE",
		"SMSG_QUESTGIVER_QUEST_FAILED",
		"CMSG_QUESTLOG_SWAP_QUEST",
		"CMSG_QUESTLOG_REMOVE_QUEST",
		"SMSG_QUESTLOG_FULL",
		"SMSG_QUESTUPDATE_FAILED",
		"SMSG_QUESTUPDATE_FAILEDTIMER",
		"SMSG_QUESTUPDATE_COMPLETE",
		"SMSG_QUESTUPDATE_ADD_KILL",
		"SMSG_QUESTUPDATE_ADD_ITEM",
		"CMSG_QUEST_CONFIRM_ACCEPT",
		"SMSG_QUEST_CONFIRM_ACCEPT",
		"CMSG_PUSHQUESTTOPARTY",
		"CMSG_LIST_INVENTORY",
		"SMSG_LIST_INVENTORY",
		"CMSG_SELL_ITEM",
		"SMSG_SELL_ITEM",
		"CMSG_BUY_ITEM",
		"CMSG_BUY_ITEM_IN_SLOT",
		"SMSG_BUY_ITEM",
		"SMSG_BUY_FAILED",
		"CMSG_TAXICLEARALLNODES",
		"CMSG_TAXIENABLEALLNODES",
		"CMSG_TAXISHOWNODES",
		"SMSG_SHOWTAXINODES",
		"CMSG_TAXINODE_STATUS_QUERY",
		"SMSG_TAXINODE_STATUS",
		"CMSG_TAXIQUERYAVAILABLENODES",
		"CMSG_ACTIVATETAXI",
		"SMSG_ACTIVATETAXIREPLY",
		"SMSG_NEW_TAXI_PATH",
		"CMSG_TRAINER_LIST",
		"SMSG_TRAINER_LIST",
		"CMSG_TRAINER_BUY_SPELL",
		"SMSG_TRAINER_BUY_SUCCEEDED",
		"SMSG_TRAINER_BUY_FAILED",
		"CMSG_BINDER_ACTIVATE",
		"SMSG_PLAYERBINDERROR",
		"CMSG_BANKER_ACTIVATE",
		"SMSG_SHOW_BANK",
		"CMSG_BUY_BANK_SLOT",
		"SMSG_BUY_BANK_SLOT_RESULT",
		"CMSG_PETITION_SHOWLIST",
		"SMSG_PETITION_SHOWLIST",
		"CMSG_PETITION_BUY",
		"CMSG_PETITION_SHOW_SIGNATURES",
		"SMSG_PETITION_SHOW_SIGNATURES",
		"CMSG_PETITION_SIGN",
		"SMSG_PETITION_SIGN_RESULTS",
		"MSG_PETITION_DECLINE",
		"CMSG_OFFER_PETITION",
		"CMSG_TURN_IN_PETITION",
		"SMSG_TURN_IN_PETITION_RESULTS",
		"CMSG_PETITION_QUERY",
		"SMSG_PETITION_QUERY_RESPONSE",
		"SMSG_FISH_NOT_HOOKED",
		"SMSG_FISH_ESCAPED",
		"CMSG_BUG",
		"SMSG_NOTIFICATION",
		"CMSG_PLAYED_TIME",
		"SMSG_PLAYED_TIME",
		"CMSG_QUERY_TIME",
		"SMSG_QUERY_TIME_RESPONSE",
		"SMSG_LOG_XPGAIN",
		"MSG_SPLIT_MONEY",
		"CMSG_RECLAIM_CORPSE",
		"CMSG_WRAP_ITEM",
		"SMSG_LEVELUP_INFO",
		"MSG_MINIMAP_PING",
		"SMSG_RESISTLOG",
		"SMSG_ENCHANTMENTLOG",
		"CMSG_SET_SKILL_CHEAT",
		"SMSG_START_MIRROR_TIMER",
		"SMSG_PAUSE_MIRROR_TIMER",
		"SMSG_STOP_MIRROR_TIMER",
		"CMSG_PING",
		"SMSG_PONG",
		"SMSG_CLEAR_COOLDOWN",
		"SMSG_GAMEOBJECT_PAGETEXT",
		"CMSG_SETSHEATHED",
		"SMSG_COOLDOWN_CHEAT",
		"SMSG_SPELL_DELAYED",
		"CMSG_PLAYER_MACRO_OBSOLETE",
		"SMSG_PLAYER_MACRO_OBSOLETE",
		"CMSG_GHOST",
		"CMSG_GM_INVIS",
		"SMSG_INVALID_PROMOTION_CODE",
		"MSG_GM_BIND_OTHER",
		"MSG_GM_SUMMON",
		"SMSG_ITEM_TIME_UPDATE",
		"SMSG_ITEM_ENCHANT_TIME_UPDATE",
		"SMSG_AUTH_CHALLENGE",
		"CMSG_AUTH_SESSION",
		"SMSG_AUTH_RESPONSE",
		"MSG_GM_SHOWLABEL",
		"MSG_ADD_DYNAMIC_TARGET_OBSOLETE",
		"MSG_SAVE_GUILD_EMBLEM",
		"MSG_TABARDVENDOR_ACTIVATE",
		"SMSG_PLAY_SPELL_VISUAL",
		"CMSG_ZONEUPDATE",
		"SMSG_PARTYKILLLOG",
		"SMSG_COMPRESSED_UPDATE_OBJECT",
		"SMSG_OBSOLETE",
		"SMSG_EXPLORATION_EXPERIENCE",
		"CMSG_GM_SET_SECURITY_GROUP",
		"CMSG_GM_NUKE",
		"MSG_RANDOM_ROLL",
		"SMSG_ENVIRONMENTALDAMAGELOG",
		"CMSG_RWHOIS",
		"SMSG_RWHOIS",
		"MSG_LOOKING_FOR_GROUP",
		"CMSG_SET_LOOKING_FOR_GROUP",
		"CMSG_UNLEARN_SPELL",
		"CMSG_UNLEARN_SKILL",
		"SMSG_REMOVED_SPELL",
		"CMSG_DECHARGE",
		"CMSG_GMTICKET_CREATE",
		"SMSG_GMTICKET_CREATE",
		"CMSG_GMTICKET_UPDATETEXT",
		"SMSG_GMTICKET_UPDATETEXT",
		"SMSG_ACCOUNT_DATA_MD5",
		"CMSG_REQUEST_ACCOUNT_DATA",
		"CMSG_UPDATE_ACCOUNT_DATA",
		"SMSG_UPDATE_ACCOUNT_DATA",
		"SMSG_CLEAR_FAR_SIGHT_IMMEDIATE",
		"SMSG_POWERGAINLOG_OBSOLETE",
		"CMSG_GM_TEACH",
		"CMSG_GM_CREATE_ITEM_TARGET",
		"CMSG_GMTICKET_GETTICKET",
		"SMSG_GMTICKET_GETTICKET",
		"CMSG_UNLEARN_TALENTS",
		"SMSG_GAMEOBJECT_SPAWN_ANIM",
		"SMSG_GAMEOBJECT_DESPAWN_ANIM",
		"MSG_CORPSE_QUERY",
		"CMSG_GMTICKET_DELETETICKET",
		"SMSG_GMTICKET_DELETETICKET",
		"SMSG_CHAT_WRONG_FACTION",
		"CMSG_GMTICKET_SYSTEMSTATUS",
		"SMSG_GMTICKET_SYSTEMSTATUS",
		"CMSG_SPIRIT_HEALER_ACTIVATE",
		"CMSG_SET_STAT_CHEAT",
		"SMSG_SET_REST_START",
		"CMSG_SKILL_BUY_STEP",
		"CMSG_SKILL_BUY_RANK",
		"CMSG_XP_CHEAT",
		"SMSG_SPIRIT_HEALER_CONFIRM",
		"CMSG_CHARACTER_POINT_CHEAT",
		"SMSG_GOSSIP_POI",
		"CMSG_CHAT_IGNORED",
		"CMSG_GM_VISION",
		"CMSG_SERVER_COMMAND",
		"CMSG_GM_SILENCE",
		"CMSG_GM_REVEALTO",
		"CMSG_GM_RESURRECT",
		"CMSG_GM_SUMMONMOB",
		"CMSG_GM_MOVECORPSE",
		"CMSG_GM_FREEZE",
		"CMSG_GM_UBERINVIS",
		"CMSG_GM_REQUEST_PLAYER_INFO",
		"SMSG_GM_PLAYER_INFO",
		"CMSG_GUILD_RANK",
		"CMSG_GUILD_ADD_RANK",
		"CMSG_GUILD_DEL_RANK",
		"CMSG_GUILD_SET_PUBLIC_NOTE",
		"CMSG_GUILD_SET_OFFICER_NOTE",
		"SMSG_LOGIN_VERIFY_WORLD",
		"CMSG_CLEAR_EXPLORATION",
		"CMSG_SEND_MAIL",
		"SMSG_SEND_MAIL_RESULT",
		"CMSG_GET_MAIL_LIST",
		"SMSG_MAIL_LIST_RESULT",
		"CMSG_BATTLEFIELD_LIST",
		"SMSG_BATTLEFIELD_LIST",
		"CMSG_BATTLEFIELD_JOIN",
		"SMSG_BATTLEFIELD_WIN",
		"SMSG_BATTLEFIELD_LOSE",
		"CMSG_TAXICLEARNODE",
		"CMSG_TAXIENABLENODE",
		"CMSG_ITEM_TEXT_QUERY",
		"SMSG_ITEM_TEXT_QUERY_RESPONSE",
		"CMSG_MAIL_TAKE_MONEY",
		"CMSG_MAIL_TAKE_ITEM",
		"CMSG_MAIL_MARK_AS_READ",
		"CMSG_MAIL_RETURN_TO_SENDER",
		"CMSG_MAIL_DELETE",
		"CMSG_MAIL_CREATE_TEXT_ITEM",
		"SMSG_SPELLLOGMISS",
		"SMSG_SPELLLOGEXECUTE",
		"SMSG_DEBUGAURAPROC",
		"SMSG_PERIODICAURALOG",
		"SMSG_SPELLDAMAGESHIELD",
		"SMSG_SPELLNONMELEEDAMAGELOG",
		"CMSG_LEARN_TALENT",
		"SMSG_RESURRECT_FAILED",
		"CMSG_TOGGLE_PVP",
		"SMSG_ZONE_UNDER_ATTACK",
		"MSG_AUCTION_HELLO",
		"CMSG_AUCTION_SELL_ITEM",
		"CMSG_AUCTION_REMOVE_ITEM",
		"CMSG_AUCTION_LIST_ITEMS",
		"CMSG_AUCTION_LIST_OWNER_ITEMS",
		"CMSG_AUCTION_PLACE_BID",
		"SMSG_AUCTION_COMMAND_RESULT",
		"SMSG_AUCTION_LIST_RESULT",
		"SMSG_AUCTION_OWNER_LIST_RESULT",
		"SMSG_AUCTION_BIDDER_NOTIFICATION",
		"SMSG_AUCTION_OWNER_NOTIFICATION",
		"SMSG_PROCRESIST",
		"SMSG_STANDSTATE_CHANGE_FAILURE",
		"SMSG_DISPEL_FAILED",
		"SMSG_SPELLORDAMAGE_IMMUNE",
		"CMSG_AUCTION_LIST_BIDDER_ITEMS",
		"SMSG_AUCTION_BIDDER_LIST_RESULT",
		"SMSG_SET_FLAT_SPELL_MODIFIER",
		"SMSG_SET_PCT_SPELL_MODIFIER",
		"CMSG_SET_AMMO",
		"SMSG_CORPSE_RECLAIM_DELAY",
		"CMSG_SET_ACTIVE_MOVER",
		"CMSG_PET_CANCEL_AURA",
		"CMSG_PLAYER_AI_CHEAT",
		"CMSG_CANCEL_AUTO_REPEAT_SPELL",
		"MSG_GM_ACCOUNT_ONLINE",
		"MSG_LIST_STABLED_PETS",
		"CMSG_STABLE_PET",
		"CMSG_UNSTABLE_PET",
		"CMSG_BUY_STABLE_SLOT",
		"SMSG_STABLE_RESULT",
		"CMSG_STABLE_REVIVE_PET",
		"CMSG_STABLE_SWAP_PET",
		"MSG_QUEST_PUSH_RESULT",
		"SMSG_PLAY_MUSIC",
		"SMSG_PLAY_OBJECT_SOUND",
		"CMSG_REQUEST_PET_INFO",
		"CMSG_FAR_SIGHT",
		"SMSG_SPELLDISPELLOG",
		"SMSG_DAMAGE_CALC_LOG",
		"CMSG_ENABLE_DAMAGE_LOG",
		"CMSG_GROUP_CHANGE_SUB_GROUP",
		"CMSG_REQUEST_PARTY_MEMBER_STATS",
		"CMSG_GROUP_SWAP_SUB_GROUP",
		"CMSG_RESET_FACTION_CHEAT",
		"CMSG_AUTOSTORE_BANK_ITEM",
		"CMSG_AUTOBANK_ITEM",
		"MSG_QUERY_NEXT_MAIL_TIME",
		"SMSG_RECEIVED_MAIL",
		"SMSG_RAID_GROUP_ONLY",
		"CMSG_SET_DURABILITY_CHEAT",
		"CMSG_SET_PVP_RANK_CHEAT",
		"CMSG_ADD_PVP_MEDAL_CHEAT",
		"CMSG_DEL_PVP_MEDAL_CHEAT",
		"CMSG_SET_PVP_TITLE",
		"SMSG_PVP_CREDIT",
		"SMSG_AUCTION_REMOVED_NOTIFICATION",
		"CMSG_GROUP_RAID_CONVERT",
		"CMSG_GROUP_ASSISTANT_LEADER",
		"CMSG_BUYBACK_ITEM",
		"SMSG_SERVER_MESSAGE",
		"CMSG_MEETINGSTONE_JOIN",
		"CMSG_MEETINGSTONE_LEAVE",
		"CMSG_MEETINGSTONE_CHEAT",
		"SMSG_MEETINGSTONE_SETQUEUE",
		"CMSG_MEETINGSTONE_INFO",
		"SMSG_MEETINGSTONE_COMPLETE",
		"SMSG_MEETINGSTONE_IN_PROGRESS",
		"SMSG_MEETINGSTONE_MEMBER_ADDED",
		"CMSG_GMTICKETSYSTEM_TOGGLE",
		"CMSG_CANCEL_GROWTH_AURA",
		"SMSG_CANCEL_AUTO_REPEAT",
		"SMSG_STANDSTATE_CHANGE_ACK",
		"SMSG_LOOT_ALL_PASSED",
		"SMSG_LOOT_ROLL_WON",
		"CMSG_LOOT_ROLL",
		"SMSG_LOOT_START_ROLL",
		"SMSG_LOOT_ROLL",
		"CMSG_LOOT_MASTER_GIVE",
		"SMSG_LOOT_MASTER_LIST",
		"SMSG_SET_FORCED_REACTIONS",
		"SMSG_SPELL_FAILED_OTHER",
		"SMSG_GAMEOBJECT_RESET_STATE",
		"CMSG_REPAIR_ITEM",
		"SMSG_CHAT_PLAYER_NOT_FOUND",
		"MSG_TALENT_WIPE_CONFIRM",
		"SMSG_SUMMON_REQUEST",
		"CMSG_SUMMON_RESPONSE",
		"MSG_MOVE_TOGGLE_GRAVITY_CHEAT",
		"SMSG_MONSTER_MOVE_TRANSPORT",
		"SMSG_PET_BROKEN",
		"MSG_MOVE_FEATHER_FALL",
		"MSG_MOVE_WATER_WALK",
		"CMSG_SERVER_BROADCAST",
		"CMSG_SELF_RES",
		"SMSG_FEIGN_DEATH_RESISTED",
		"CMSG_RUN_SCRIPT",
		"SMSG_SCRIPT_MESSAGE",
		"SMSG_DUEL_COUNTDOWN",
		"SMSG_AREA_TRIGGER_MESSAGE",
		"CMSG_TOGGLE_HELM",
		"CMSG_TOGGLE_CLOAK",
		"SMSG_MEETINGSTONE_JOINFAILED",
		"SMSG_PLAYER_SKINNED",
		"SMSG_DURABILITY_DAMAGE_DEATH",
		"CMSG_SET_EXPLORATION",
		"CMSG_SET_ACTIONBAR_TOGGLES",
		"UMSG_DELETE_GUILD_CHARTER",
		"MSG_PETITION_RENAME",
		"SMSG_INIT_WORLD_STATES",
		"SMSG_UPDATE_WORLD_STATE",
		"CMSG_ITEM_NAME_QUERY",
		"SMSG_ITEM_NAME_QUERY_RESPONSE",
		"SMSG_PET_ACTION_FEEDBACK",
		"CMSG_CHAR_RENAME",
		"SMSG_CHAR_RENAME",
		"CMSG_MOVE_SPLINE_DONE",
		"CMSG_MOVE_FALL_RESET",
		"SMSG_INSTANCE_SAVE_CREATED",
		"SMSG_RAID_INSTANCE_INFO",
		"CMSG_REQUEST_RAID_INFO",
		"CMSG_MOVE_TIME_SKIPPED",
		"CMSG_MOVE_FEATHER_FALL_ACK",
		"CMSG_MOVE_WATER_WALK_ACK",
		"CMSG_MOVE_NOT_ACTIVE_MOVER",
		"SMSG_PLAY_SOUND",
		"CMSG_BATTLEFIELD_STATUS",
		"SMSG_BATTLEFIELD_STATUS",
		"CMSG_BATTLEFIELD_PORT",
		"MSG_INSPECT_HONOR_STATS",
		"CMSG_BATTLEMASTER_HELLO",
		"CMSG_MOVE_START_SWIM_CHEAT",
		"CMSG_MOVE_STOP_SWIM_CHEAT",
		"SMSG_FORCE_WALK_SPEED_CHANGE",
		"CMSG_FORCE_WALK_SPEED_CHANGE_ACK",
		"SMSG_FORCE_SWIM_BACK_SPEED_CHANGE",
		"CMSG_FORCE_SWIM_BACK_SPEED_CHANGE_ACK",
		"SMSG_FORCE_TURN_RATE_CHANGE",
		"CMSG_FORCE_TURN_RATE_CHANGE_ACK",
		"MSG_PVP_LOG_DATA",
		"CMSG_LEAVE_BATTLEFIELD",
		"CMSG_AREA_SPIRIT_HEALER_QUERY",
		"CMSG_AREA_SPIRIT_HEALER_QUEUE",
		"SMSG_AREA_SPIRIT_HEALER_TIME",
		"CMSG_GM_UNTEACH",
		"SMSG_HARDWARE_SURVEY_REQUEST",
		"CMSG_HARDWARE_SURVEY_RESULTS",
		"SMSG_WARDEN_DATA",
		"CMSG_WARDEN_DATA",
		"SMSG_GROUP_JOINED_BATTLEGROUND",
		"MSG_BINDPOINT_CONFIRM",
		"CMSG_PET_STOP_ATTACK",
		"SMSG_BINDER_CONFIRM",
		"SMSG_BATTLEGROUND_PLAYER_JOINED",
		"SMSG_ADDON_INFO",
		"CMSG_BATTLEMASTER_JOIN",
		"SMSG_ADDON_INFO",
		"CMSG_PET_UNLEARN",
		"SMSG_PET_UNLEARN_CONFIRM",
		"SMSG_PARTY_MEMBER_STATS_FULL",
		"CMSG_PET_SPELL_AUTOCAST",
		"SMSG_WEATHER",
		"SMSG_PLAY_TIME_WARNING",
		"SMSG_MINIGAME_SETUP",
		"SMSG_MINIGAME_STATE",
		"CMSG_MINIGAME_MOVE",
		"SMSG_MINIGAME_MOVE_FAILED",
		"NUM_MSG_TYPES"
};

#ifndef WIN32
void pipesignal(int param)
{
	RealmServer.pTempClient->socket.Close();
	signal(SIGPIPE,pipesignal);
}
#endif
const unsigned long seed = server_seed;
extern bool LoadAccount(char *name, CClient *pClient, bool createflag = true);

void touppercase(char *data) {
	int len = strlen(data);
	for (int i=0; i<len; i++) {
		data[i] = toupper(data[i]);
	}
}

fMessageHandler LoginMessageHandlers[MSG_HANDLERS] = {0};
fMessageHandler GameMessageHandlers[MSG_HANDLERS] = {0};
THREAD WINAPI RealmServerThreadFunction( LPVOID pParam )
{
	InstallMessageHandlers(LoginMessageHandlers);
	InstallGameMessageHandlers(GameMessageHandlers);

	CThread *pThread=(CThread*)pParam;
	CLock L(&pThread->Threading,true);
	pThread->bThreading=true;
	pThread->ThreadReady=true;
	CRealmServer *pServer=(CRealmServer*)pThread->Info;
#ifndef WIN32
	signal(SIGPIPE,pipesignal);
#endif
	pServer->ThreadState=0;
	//char Buffer[20480];
	CClient *nextclient=new CClient;
	time_t LastMasterHeartbeat=0;
	TCPSocket Redirect;
	TCPSocket LoginSocket;
	Addr From;
	time_t now=time(0);
	//int updatecounter=0;
	int updatequeuecounter=0;
	int ServerState=0;
	// seed random number generator for this thread
	srand(time(0));
	CDataBuffer *pRecvBuffer = new CDataBuffer(20480);
	char *Buffer = pRecvBuffer->Buffer();
	//unsigned int msgID = 0;
	CDebug logfile;
	logfile.Initialize("PktLog.txt");

	while(!pThread->CloseThread)
	{
		DETECT_DEBUG
			int LastState=ServerState;

		now=time(0);
		// handle each client individually
		if(!RealmServer.ActiveRegionsCreatureMove.empty())
		{
			CRegion *pNextRegion=RealmServer.ActiveRegionsCreatureMove.front();
			RealmServer.ActiveRegionsCreatureMove.pop();
			if(pNextRegion)
			{
				//alright, center one we keep checking for, outside ones we force move to keep movement realb
				for (int i = 0 ; i < 3 ; i++)
					for (int j = 0 ; j < 3 ; j++)
					{
						if (CRegion *pRegion=pNextRegion->Adjacent[i][j])
						{
							if(i==1 && j==1)
							{
								if(pRegion->RegionWanderCreatures(now,false))
									RealmServer.ActiveRegionsCreatureMove.push(pNextRegion);
							}
							else
								pRegion->RegionWanderCreatures(now,true);
						}
					}
			}
		}

#ifdef WIN32

/*		updatecounter++;
		if(updatecounter>100)
		{
			updatecounter=0;
			char temp[80];
			if(pServer->ServerQueue.size()) sprintf(temp,"%i playing, %i queued",pServer->nClients,pServer->ServerQueue.size());
			else sprintf(temp,"%i playing",pServer->nClients);
			if(dlg) dlg->Txt_Clients.SetWindowText(temp);
		}*/
#endif
		for (unsigned long i = 0 ; i < pServer->Clients.Size ; i++)
		{
			if (CClient *client=pServer->Clients[i])
			{
				// disconnected?
				if (!client->socket.isConnected() || client->DestroyMe)
				{
					for(unsigned long k = 0;k<pServer->ServerQueue.size();k++)
					{
						if(pServer->ServerQueue[k]==client)
						{
							pServer->ServerQueue.erase(pServer->ServerQueue.begin()+k);
							pServer->nClients++; //err...yeah, we need to increment then decrement
						}
					}
					// delete and whatnot
					pServer->Clients[i]=0;
					client->CompleteLogout();
					//don't worry, this client is being deleted in a sec anyway
					//therefore OutPacket won't do anything :D
					//doing this to ensure that cleanup is properly done, otherwise we could have problems!
					delete client;
					pServer->nClients--;
					continue;
				}
				// outgoing data new
				while (!client->Outgoing.Empty() && client->DataPending.Size<1024)
				{
					_OutData data=client->Outgoing.Peek();
					int AddSize=data.Size;
					if (AddSize+client->DataPending.Size>=0x3F00)
					{
						break;
					}
#ifdef _DEBUG
					char tempop[128];
					if(data.Size)
					{
						unsigned short op=*((unsigned short*)&data.buffer[2]);
						if(op<=NUM_MSG_TYPES)
						{
							sprintf(tempop,"Data to Send: Opcode %04X (%s)",op,OpcodeNames[op]);
							logfile.LogBuffer(&data.buffer[4],data.Size-4,tempop);
						}
					}
#endif
					client->Crypter.EncryptSend((unsigned char*)data.buffer,4);
					memcpy(&client->DataPending.buffer[client->DataPending.Size],data.buffer,AddSize);
					client->DataPending.Size+=AddSize;
					free(data.buffer);
					client->Outgoing.Pop();
				}
				if (client->DataPending.Size)
				{
					pServer->pTempClient=client;
					//					if (SendSize>1024)
					//						SendSize=1024;
					pServer->ThreadState=1;
					int sent=client->socket.Send(client->DataPending.buffer,client->DataPending.Size);
					pServer->ThreadState=2;
					if (sent>0)
					{
						pServer->ThreadState=3;
						if (sent>(int)pServer->MaxSent)
							pServer->MaxSent=(unsigned long)sent;

						client->DataPending.Size-=sent;
						memmove(client->DataPending.buffer,&client->DataPending.buffer[sent],client->DataPending.Size);
						pServer->ThreadState=4;
					}
				}
				/*
				if (client->DestroyMe)
				{
				pServer->Clients[i]=0;
				delete client;
				pServer->nClients--;
				continue;
				}
				*/
				// incoming data?
				pServer->ThreadState=5;
				for (int n = 0 ; n < 6 ; n++)
				{
					int isize=client->socket.isData();
					if (isize>0 || (client->NextLength==0 && client->NextOpCode))
					{
						if (!client->NextLength && !client->NextOpCode)
						{
							if (isize>=6) //get the header now
							{
								char inhdr[6];
								client->LastIncoming=now;
								client->socket.Receive(inhdr,6);
								client->Crypter.DecryptRecv((unsigned char *)inhdr,6);
								memcpy(&client->NextLength,&inhdr[0],2);
								memcpy(&client->NextOpCode,&inhdr[2],4);
								client->NextLength=htons(client->NextLength)-4;
								//logfile.LogBuffer((char*)&client->NextOpCode,4,"NextOpCode");
							}
						}
						else
							if (isize>=client->NextLength)
							{
								client->LastIncoming=now;
								isize = client->socket.Receive(Buffer,client->NextLength);
#ifdef _DEBUG
								if(client->NextOpCode<=NUM_MSG_TYPES)
								{
									char tempop[128];
									sprintf(tempop,"Incoming: Opcode %04X (%s)",client->NextOpCode,OpcodeNames[client->NextOpCode]);
									logfile.LogBuffer(Buffer,isize,tempop);
								}
#endif
								pServer->ThreadState=6;
								pRecvBuffer->Position(0);

								if (client->NextOpCode<MSG_HANDLERS && client->MessageHandlers[client->NextOpCode])
									client->MessageHandlers[client->NextOpCode](client, client->NextOpCode, *pRecvBuffer);
#ifdef _DEBUG
								else if(client->NextOpCode<=NUM_MSG_TYPES)
								{
									char temptoprint[128];
									sprintf(temptoprint,"Unhandled opcode %04X: %s",client->NextOpCode,OpcodeNames[client->NextOpCode]);
									Debug.LogBuffer(Buffer,isize,temptoprint);
								}
#endif
								pServer->ThreadState=7;
								//client->ProcessIncomingData(Data);
								client->NextLength=0;
								client->NextOpCode=0;
							}
					}
					else
						break;
				}
				if (difftime(now,client->LastIncoming)>180.0f)
				{
					client->DestroyMe=true;
				}
			}
		}
		if(pServer->ServerQueue.size()>0 && pServer->nClients<Settings.max_connections) //we can let someone in!
		{
			CClient *queuedguy=pServer->ServerQueue[0];
			pServer->ServerQueue.erase(pServer->ServerQueue.begin());
			if(queuedguy && !queuedguy->DestroyMe)
			{
				queuedguy->OutPacket(SMSG_AUTH_RESPONSE,"\x0c\xcf\xd2\x07\x00\x00",6); //you're in!
				pServer->nClients++; //we now have one more, sir.
			}
		}
		updatequeuecounter++;
		if(updatequeuecounter>100)
		{
			int counter=0;
			updatequeuecounter=0;
			for(unsigned long i = 0;i<pServer->ServerQueue.size();i++) //update the poor other queued peons
			{
				if(!pServer->ServerQueue[i]) continue;
				counter++;
				CPacket pkg;
				pkg.Reset(SMSG_AUTH_RESPONSE);
				pkg << (char)0x1B; //You Are (still) Queued!
				//1B 73 2C 00 00 00 00 00 00 00 61 00 00 00
				pkg << (long)0x00002C73; //what is this? miscellaneous garbage
				pkg << (char)0x00;
				pkg << (long)0;
				pkg << (long)counter;
				pServer->ServerQueue[i]->Send(&pkg);
			}
		}
		/*if (pServer->RedirectListener.Accept(Redirect))
		{
		char Out[256];
		long clientip=Redirect.GetClientIP();
		sprintf(Out,"%s:%i",pServer->IPAddr,Settings.Port_Realm);
		Redirect.Send(Out,strlen(Out)+1);
		Redirect.Close();
		}*/
		/*
		if (pServer->LoginListener.Accept(LoginSocket))
		{
		char user[256];
		char pass[256];
		Sleep(500);
		LoginSocket.Receive(Buffer,1);
		unsigned int userlen = Buffer[0];
		LoginSocket.Receive(user,userlen);
		user[userlen] =0;
		LoginSocket.Receive(Buffer,1);
		unsigned int passlen = Buffer[0];
		LoginSocket.Receive(pass,passlen);
		pass[passlen] = 0;
		char Out[1];
		if (ValidateUser(&LoginSocket,user,pass))
		Out[0] = 1;
		else
		Out[0] = 0;
		LoginSocket.Send(Out,1);
		LoginSocket.Close();
		}
		*/
		if (pServer->MasterList.isData())
		{
			int len=pServer->MasterList.RecvFrom(Buffer,2048,From);
			pServer->MasterList.SendTo(Buffer,len,From);
		}

		pServer->ThreadState=8;
		pServer->ThreadState=9;
		ServerState=0;
		if (pServer->Listener.Accept(nextclient->socket))
		{
			pServer->ThreadState=10;
			nextclient->SendAuthChallenge(seed); //transmit the seed data
			nextclient->LastIncoming=now;
			pServer->Clients+=nextclient;
			nextclient = new CClient;
			pServer->nClients++;
			if (pServer->nClients>pServer->nMaxClients)
			{
				pServer->nMaxClients=pServer->nClients;
			}
		}

		pServer->ThreadState=11;
		if (difftime(now,LastMasterHeartbeat)>60.0f || ServerState!=LastState)
		{
			LastMasterHeartbeat=now;
			pServer->UpdateMasterLists(ServerState);
		}

		pServer->ThreadState=12;
		EventManager.ProcessReadyEvents();
		pServer->ThreadState=13;

		Sleep(5); // 200 per second
	}
	// OK, cleanup time. Make sure everyone logs out safely to retain anything important, then quit.
	for (unsigned long i = 0 ; i < pServer->Clients.Size ; i++)
	{
		if (CClient *client=pServer->Clients[i])
		{
			// delete and whatnot
			pServer->Clients[i]=0;
			client->CompleteLogout();
			//don't worry, this client is being deleted in a sec anyway
			//therefore OutPacket won't do anything :D
			//doing this to ensure that cleanup is properly done, otherwise we could have problems!
			delete client;
		}
	}
	if (difftime(now,LastMasterHeartbeat)<140.0f)
	{
		pServer->UpdateMasterLists(-1);
	}

	if (nextclient)
		delete nextclient;
	while(!RealmServer.ActiveRegionsCreatureMove.empty()) RealmServer.ActiveRegionsCreatureMove.pop();
	pServer->Clients.Cleanup();
	pServer->nClients=0;
	pThread->bThreading=false;
	delete pRecvBuffer;
	return 0;
}


CRealmServer::CRealmServer(void):Clients(10),MasterLists(10)
{
	MaxSent=0;
	nMaxClients=0;
	nClients=0;
	strcpy(Name,"Localhost Server");
	strcpy(IPAddr,"127.0.0.1");
}

CRealmServer::~CRealmServer(void)
{
	RealmThread.EndThread();
	// Clients are cleaned up by thread
	MasterLists.Cleanup();
}

bool DoAccountNames(ObjectStorage &Storage, unsigned long ID)
{
	string name=((AccountData*)Storage.Data)->Name;
	MakeLower(name);
	DataManager.AccountNames[name]=ID;
	return true;
}

bool DoPlayerNames(ObjectStorage &Storage, unsigned long ID)
{
	string name=((PlayerData*)Storage.Data)->Name;
	MakeLower(name);
	DataManager.PlayerNames[name]=ID;
	return true;
}

bool DoCreatureTemplateNames(ObjectStorage &Storage, unsigned long ID)
{
	string name=((CreatureTemplateData*)Storage.Data)->Name;
	MakeLower(name);
	DataManager.CreatureTemplateNames[name]=ID;
	CCreatureTemplate *pTemplate;
	DataManager.RetrieveObject((CWoWObject **)&pTemplate,OBJ_CREATURETEMPLATE,ID); //force cache
	return true;
}

bool PreCacheNPCTexts(unsigned long ID)
{
	CNPCText *pText;
	DataManager.RetrieveObject((CWoWObject **)&pText,OBJ_NPCTEXT,ID);
	return true;
}

bool PreCachePageTexts(unsigned long ID)
{
	CPageText *pText;
	DataManager.RetrieveObject((CWoWObject **)&pText,OBJ_PAGETEXT,ID);
	return true;
}

bool LoadMails(unsigned long ID)
{
	CMail *pMail;
	if(!DataManager.RetrieveObject((CWoWObject **)&pMail,OBJ_MAIL,ID)) return true;
	CPlayer *pPlayer;
	if(!DataManager.RetrieveObject((CWoWObject **)&pPlayer,OBJ_PLAYER,pMail->Data.Recipient)) return true;
	pPlayer->Mails.push_back(pMail);
	pMail->EventsEligible=true; // all mails should be eligible anyway...
	EventManager.AddEvent(*pMail,3600000,EVENT_MAIL_EXPIRE_CHECK,0,0);
	return true;
}

bool InitSpawnPoints(unsigned long ID)
{
	CSpawnPoint *pPoint;
	if (DataManager.RetrieveObject((CWoWObject**)&pPoint,OBJ_SPAWNPOINT,ID))
	{
		// does it have a creature spawned?
		if (pPoint->Data.Creature)
		{
			CCreature *pCreature;
			if (DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE,ID))
			{
				// reset it to normal state
				pCreature->Data.CurrentStats=pCreature->pTemplate->Data.NormalStats;
				// and let it appear
				RegionManager.ObjectNew(*pCreature,pCreature->Data.Continent,pCreature->Data.Loc.X,pCreature->Data.Loc.Y);
				return true;
			}
		}
		pPoint->Data.Creature=0;
		pPoint->Spawn();
	}
	return true;
}

bool InitPathGroups(unsigned long ID)
{
	CPathGroup *pGroup;
	if (DataManager.RetrieveObject((CWoWObject**)&pGroup,OBJ_PATHGROUP,ID))
	{
		// TODO: populate some temporary map of every point. the data stored by the map
		// will be a linked list for every point x y and z on a particular continent.
		// once the linked list is complete, iterate through the entire map. for each list
		// that has more nodes than just the head, generate pairs of connected groups.
		// once this is complete, free the map.
	}
	return true;
}

bool InitQuestInfos(unsigned long ID)
{
	CQuestInfo *pQuest;
	if (!DataManager.RetrieveObject((CWoWObject**)&pQuest,OBJ_QUESTINFO,ID))
		return true; // it's a lie, but otherwise Enum stops processing
	// 	Debug.Logf("Failed to load quest %d", ID);
	// DataManager.QuestIDs[pQuest->Data.questid] = ID;

	return true;
}

bool InitGuilds(unsigned long ID)
{
	CGuild *pGuild=new CGuild;
	if (Storage.RetrieveObject(*pGuild,ID))
	{
		DataManager.NewObject(*pGuild);
	}
	return true;
}

void CRealmServer::InitSkillLines()
{
	int skillinecount;
	int i = 0;
	unsigned long skillline;
	unsigned long spell;

	skillinecount = DBCManager.SkillLineAbility.rowcount();	// row count

	while (i < skillinecount)
	{
		skillline = DBCManager.SkillLineAbility.getIntValueNoKey(i, 1);
		spell = DBCManager.SkillLineAbility.getIntValueNoKey(i, 2);

		RealmServer.SkillLines[spell] = skillline;
		i++;
		SetProgressBar(i,skillinecount,"Initializing Skill Lines...");
	}
}

void CRealmServer::LoadTaxiData()
{
	unsigned long count = 0;

	for ( int a = 1; a < DBCManager.TaxiNodes.rowcount() ; a++ )
	{
		TaxiNodesRec TX;
		_Location Loc;

		if(!DBCManager.TaxiNodes.fetchRow( a, &TX )) continue;

		CTaxiMob::Mask[(a-1) >> 5] |= 1<<((a-1)&31); // precompute the unchanging mask

		Loc.X = TX.X;
		Loc.Y = TX.Y;
		Loc.Z = TX.Z;

		CTaxiMob *pCreature = RealmServer.GenerateTaxiMob(20, "The Traveler", TX.ContinentID, Loc, 0);

		if ( pCreature )
		{
			//			pCreature->Data.FactionTemplate = 3;
			//			pCreature->Data.NPCType = 8;
			//			pCreature->Data.DamageMin = 1;
			//			pCreature->Data.DamageMax = 2;
			//			pCreature->Data.Size = 1;
			//			pCreature->Data.Level = 100;
			//			pCreature->Data.NormalStats.HitPoints = 10;
			pCreature->Data.CurrentStats.HitPoints = 10;
			//			pCreature->Data.CurrentStats.Mana = 10;
			//			pCreature->Data.NormalStats.Mana = 10;
			//			pCreature->Data.Exp = 10;
			pCreature->nodeid = TX.ID;

			RegionManager.ObjectNew(*pCreature, pCreature->Data.Continent, pCreature->Data.Loc.X, pCreature->Data.Loc.Y);

			count++;
		}
	}

	if ( count > 0 )
		Debug.Logf("%d of %d Taxi Nodes Loaded.", count, DBCManager.TaxiNodes.rowcount()-1);
	else
		Debug.Log("Error Loading Taxi Nodes.");
}

bool DoGOTemplateInit(unsigned long ID)
{
	CGameObjectTemplate *pTemplate;
	if (!DataManager.RetrieveObject((CWoWObject**)&pTemplate, OBJ_GAMEOBJECTTEMPLATE, ID))
		return false;
	DataManager.GameObjectEntries[pTemplate->Data.ObjectID] = ID;
	return true;
}

bool InitAreaTriggerTable()
{
	unsigned long ID;
	AreaTrigger at;

	FILE *f = fopen("data/AreaTriggers.dat", STORAGE_READ);
	if(f == NULL)
		return false;
	fseek(f, 0, SEEK_END);
	long size = ftell(f);
	fseek(f,0,SEEK_SET);
	char *buffer = (char*)malloc(size);
	if(buffer == NULL || fread(buffer, size, 1, f) != 1)
	{
		fclose(f);
		return false;
	}
	fclose(f);
	long c = 0;
	while(c < size)
	{
		if(c+4 >= size)
			break;
		memcpy(&ID, &buffer[c], 4);
		c += 4;
		memcpy(&at, &buffer[c], sizeof(AreaTrigger));
		c+=sizeof(AreaTrigger);
		if(ID) RealmServer.AreaTriggers[ID]=at;
	}
	free(buffer);
	return true;
}

void InitGOLoots()
{
	unsigned long guid;
	unsigned long count;
	LootItem li;
	CGameObjectTemplate *pTemplate;
	FILE *f=fopen("data/gameobjloot.dat", STORAGE_READ);
	if(f==NULL) return;
	fseek(f, 0, SEEK_END);
	long size = ftell(f);
	fseek(f,0,SEEK_SET);
	while(1)
	{
		if(fread(&guid,sizeof(unsigned long),1,f)!=1)
		{
			fclose(f);
			return;
		}
		if(fread(&count,sizeof(unsigned long),1,f)!=1)
		{
			fclose(f);
			return;
		}
		if(!DataManager.RetrieveObject((CWoWObject**)&pTemplate,OBJ_GAMEOBJECTTEMPLATE,guid)) pTemplate=NULL;
		else pTemplate->LootTable.clear();
		for(unsigned long i=0;i<count;i++)
		{
			if(fread(&li,sizeof(LootItem),1,f)!=1)
			{
				fclose(f);
				return;
			}
			if(pTemplate) pTemplate->LootTable.push_back(li);
		}
		if(ftell(f) >= size)
		{
			fclose(f);
			return;
		}
	}
}

bool LoadMapFile(FILE *f)
{
	unsigned long Header[3]; // Continent, AreaID, Count
	if(fread(Header,4,3,f)!=3)// || Header[0] > 1)
	{
		fclose(f);
		return false;
	}

	struct Point
	{
		unsigned long X;
		unsigned long Y;
		float Z;
	};
	Point Pt;
	CContinent *pContinent=RegionManager.Continents[Header[0]];
	if(!pContinent) return false;
	for(unsigned long i=0;i<Header[2];i++)
	{
		if(!fread(&Pt,sizeof(Point),1,f))
		{
			fclose(f);
			return false;
		}
		pContinent->HeightMap[((Pt.X & HEIGHTMAP_MASK) << 16) + (Pt.Y & HEIGHTMAP_MASK)]=Pt.Z;
	}
	fclose(f);
	return true;
}

bool DoItemTemplates(unsigned long ID)
{
	CItemTemplate *pTemplate;
	if (!DataManager.RetrieveObject((CWoWObject**)&pTemplate, OBJ_ITEMTEMPLATE, ID))
		return true;

	DataManager.ItemTemplates[pTemplate->Data.ItemID] = ID;
	return true;
}

void LoadTrainTemplates(void)
{
	/*	if(!FileExists("data/selltemplates.bin"))
	{
	Debug.Log("Sell Template data file not found!!!!!");
	return;
	}*/
	FILE *f = fopen("data/trainertemplates.bin","rb");
	if (!f)
	{
		Debug.Log("Can't open trainertemplates.bin");
		return;
	}

	fseek(f, 0, SEEK_END);
	long size = ftell(f);
	//long approxcount = size/sizeof(_TrainerTempBinItem);
	fseek(f,0,SEEK_SET);
	char *buffer = (char*)malloc(size);
	if(buffer == NULL || fread(buffer, size, 1, f) != 1)
	{
		fclose(f);
		return;
	}
	fclose(f);
	long c = 0;
	unsigned long creatureid;
	unsigned long creatureid2;
	unsigned long oldvendorid = 0;
	int vendorcount = 0;
	int itemcount = 0;

	_TrainerTempBinItem si;
	_TrainerItem trainitem;
	while(c < size)
	{
		if(c+4 >= size)
			break;
		memcpy(&creatureid, &buffer[c], 4);
		memcpy(&si, &buffer[c], sizeof(_TrainerTempBinItem));
		c+=sizeof(_TrainerTempBinItem);
		creatureid2 = creatureid | 0x08000000;
		if (oldvendorid != creatureid2)
		{
			oldvendorid = creatureid2;
			vendorcount++;
		}

		// itemid = DataManager.ItemTemplates[si.SellID];
		trainitem.SkillLine = (short)RealmServer.SkillLines[si.SpellID];
		trainitem.SpellID = si.SpellID;
		trainitem.ReqSpell = si.ReqSpell;
		trainitem.SpellCost = (short)si.SpellCost;

		itemcount++;
		DataManager.TrainerTemplates[creatureid2].push_back(trainitem);
		///if (!(count % 689)) RealmServer.SetProgressBar(ftell(f)/size, approxcount, "Loading Trainers...");
		//if(ID) RealmServer.AreaTriggers[ID]=at;
	}
	free(buffer);
	char printtext[60];
	sprintf(printtext,"%d spells at %d trainers loaded!", itemcount,vendorcount);
	Debug.Log(printtext);
}

void LoadSellTemplates(void)
{
	/*	if(!FileExists("data/selltemplates.bin"))
	{
	Debug.Log("Sell Template data file not found!!!!!");
	return;
	}*/
	FILE *f = fopen("data/selltemplates.bin","rb");
	if (!f)
	{
		Debug.Log("Can't open selltemplate");
		return;
	}

	fseek(f, 0, SEEK_END);
	long size = ftell(f);
	fseek(f,0,SEEK_SET);
	char *buffer = (char*)malloc(size);
	if(buffer == NULL || fread(buffer, size, 1, f) != 1)
	{
		fclose(f);
		return;
	}
	fclose(f);
	long c = 0;
	unsigned long creatureid;
	unsigned long creatureid2;
	unsigned long itemid;
	unsigned long oldvendorid = 0;
	int vendorcount = 0;
	int itemcount = 0;

	_SellTempBinItem si;
	while(c < size)
	{
		if(c+4 >= size)
			break;
		memcpy(&creatureid, &buffer[c], 4);
		memcpy(&si, &buffer[c], sizeof(_SellTempBinItem));
		c+=sizeof(_SellTempBinItem);
		creatureid2 = creatureid | 0x08000000;
		if (oldvendorid != creatureid2)
		{
			oldvendorid = creatureid2;
			vendorcount++;
		}

		itemid = DataManager.ItemTemplates[si.SellID];
		itemcount++;
		DataManager.SellTemplates[creatureid2].push_back(itemid);


		//if(ID) RealmServer.AreaTriggers[ID]=at;
	}
	free(buffer);
	char printtext[60];
	sprintf(printtext,"%d items at %d vendors loaded!", itemcount,vendorcount);
	Debug.Log(printtext);

}

bool InitQuestRelation(unsigned long ID)
{
	CQuestRelation *pqr;
	if (!DataManager.RetrieveObject((CWoWObject**)&pqr, OBJ_QUESTRELATION, ID))
		return true;

	if (pqr->Data.involver)
		DataManager.CreatureInvolvedRelation[pqr->Data.templateguid].push_back(pqr->Data.questguid);
	else
		DataManager.CreatureQuestRelation[pqr->Data.templateguid].push_back(pqr->Data.questguid);

	return true;
}

bool InitWaypoints()
{
	FILE *f = fopen("data/waypoints.bin","rb");
	if (!f)
	{
		Debug.Log("Can't open waypoints.bin");
		return false;
	}

	fseek(f, 0, SEEK_END);
	long size = ftell(f);
	//long approxcount = size/sizeof(Waypoint);
	fseek(f,0,SEEK_SET);
	char *buffer = (char*)malloc(size);
	if(buffer == NULL || fread(buffer, size, 1, f) != 1)
	{
		fclose(f);
		return false;
	}
	fclose(f);
	long c = 0;
	int itemcount = 0;

	Waypoint point;

	while(c < size)
	{
		if(c+4 >= size)
			break;
		memcpy(&point, &buffer[c], sizeof(Waypoint));
		c+=sizeof(Waypoint);
		itemcount++;
		RealmServer.Waypoints[point.PointID] = point;
	}
	free(buffer);
	char printtext[60];
	sprintf(printtext,"%d waypoints loaded!", itemcount);
	Debug.Log(printtext);

	return true;
}

void CRealmServer::Go()
{
	SetStatusText("Loading Settings...");
	Settings.LoadSettings();

	if (CRealmServer::Initialize())
	{
		SetStatusText("Loading DBC files...");
		DBCManager.Initialize();

		SetStatusText("Loading Stored Data...");
		if (Storage.Initialize())
		{
			SetStatusText("Initializing Storage Manager...");
			// convert if necessary
			Storage.SetObjectSize(OBJ_ACCOUNT,sizeof(AccountData));
			Storage.SetObjectSize(OBJ_PLAYER,sizeof(PlayerData));
			Storage.SetObjectSize(OBJ_ITEM,sizeof(ItemData));
			Storage.SetObjectSize(OBJ_ITEMTEMPLATE,sizeof(ItemTemplateData));
			Storage.SetObjectSize(OBJ_CREATURE,sizeof(CreatureData));
			Storage.SetObjectSize(OBJ_CREATURETEMPLATE,sizeof(CreatureTemplateData));
			Storage.SetObjectSize(OBJ_SPAWNPOINT,sizeof(SpawnPointData));
			Storage.SetObjectSize(OBJ_LOOTTABLE,sizeof(LootTableData));
			Storage.SetObjectSize(OBJ_ZONE,sizeof(ZoneData));
			//			Storage.SetObjectSize(OBJ_CONTAINER,sizeof(ContainerData));
			Storage.SetObjectSize(OBJ_PATHGROUP,sizeof(PathGroupData));
			Storage.SetObjectSize(OBJ_GUILD,sizeof(GuildData));
			Storage.SetObjectSize(OBJ_CORPSE,sizeof(CorpseData));
			Storage.SetObjectSize(OBJ_QUESTINFO,sizeof(QuestData));
			Storage.SetObjectSize(OBJ_TRAINERTEMPLATE,sizeof(TrainerTemplateData));
			Storage.SetObjectSize(OBJ_QUESTRELATION,sizeof(QuestRelationData));

			// ok, set up the name caches
			SetStatusText("Finding Item Template IDs...");
			Storage.EnumObjectIDs(OBJ_ITEMTEMPLATE, DoItemTemplates);

			SetStatusText("Setting up default player info...");
			InitPlayerStartItems();

			SetStatusText("Initializing Creature Templates...");
			Storage.EnumObjects(OBJ_CREATURETEMPLATE,DoCreatureTemplateNames);

			SetStatusText("Initializing Quest Relations...");
			Storage.EnumObjectIDs(OBJ_QUESTRELATION, InitQuestRelation);

			SetStatusText("Initializing Sell Templates...");
			// Storage.EnumObjectIDs(OBJ_SELLTEMPLATE, InitSellTemplates);
			LoadSellTemplates();

			SetStatusText("Loading Waypoints...");
			InitWaypoints();

			SetStatusText("Loading Accounts...");

			Storage.EnumObjects(OBJ_ACCOUNT,DoAccountNames);
			Storage.EnumObjects(OBJ_ACCOUNT,DoPlayerNames);

			SetStatusText("Finding Quests...");
			Storage.EnumObjectIDs(OBJ_QUESTINFO,InitQuestInfos);

#ifdef WIN32
			SetStatusText("Initializing Skill Lines...");
#endif
			InitSkillLines();
#ifndef WIN32
			printf("\r%-79s\n","Initializing Skill Lines: Done");
#endif

			SetStatusText("Initializing Trainer Templates...");
			//Storage.EnumObjectIDs(OBJ_TRAINERTEMPLATE, DoTrainerTemplateInit);
			LoadTrainTemplates();

			SetStatusText("Freeing temp memory...");
			SkillLines.clear();

#ifdef WIN32
			CFileFind fileFinder;
			char acctdir[1024];
			strcpy(acctdir,Settings.accounts_path);
			for(unsigned long i=0;i<strlen(Settings.accounts_path);i++) //windows sux0rs with backslashes!
			{
				if(acctdir[i]=='/') acctdir[i]='\\';
			}
			strcat(acctdir,"\\*.*");
			BOOL working = fileFinder.FindFile(acctdir);
			CClient *tempClient=new CClient;
			while(working)
			{
				working = fileFinder.FindNextFile();
				if(fileFinder.GetFileName()[0] != '.')
				{
					LoadAccount(fileFinder.GetFileName().GetBuffer(),tempClient, true);
				}
			}
			delete tempClient;

			SetStatusText("Loading Maps...");
			int ct=0;
			working = fileFinder.FindFile("data\\maps\\map????????.bin");
			while(working)
			{
				working = fileFinder.FindNextFile();
				ct++;
				if(!(ct%8)) dlg->Ctl_Progress.SetPos(ct >> 3);
				char fn[1024]="data/maps/";
				strcat(fn,fileFinder.GetFileName().GetBuffer());
				FILE *f=fopen(fn,"rb");
				if(!f) continue;
				LoadMapFile(f); //will automatically close file
				// true = success, false = failure
			}
			dlg->Ctl_Progress.SetPos(0);
#else
			DIR *pdir;
			struct dirent *pent;
			char acctdir[1024];
			strcpy(acctdir,"./");
			strcat(acctdir,Settings.accounts_path);
			strcat(acctdir,"/");
			pdir=opendir(acctdir);
			CClient *tempClient=new CClient;
			if(pdir)
			{
				errno=0;
				while ((pent=readdir(pdir)))
				{
					LoadAccount(pent->d_name,tempClient, true);
				}
				closedir(pdir);
			}
			delete tempClient;

#define NUMMAPS 861
			setbuf(stdout,NULL);
			pdir=opendir("./data/maps/");
			if(pdir)
			{
				printf("Progress: %3i/%3i",0,NUMMAPS);
				errno=0;
				int count=0;
				while ((pent=readdir(pdir)))
				{
					count++;
					SetProgressBar(count,NUMMAPS,"Loading Maps");
					char fn[1024]="data/maps/";
					char *mapfilename=pent->d_name;
					if(strlen(mapfilename)!=15) continue;
					if(strncmp(mapfilename,"map",3)) continue;
					if(strncmp(mapfilename+11,".bin",4)) continue;
					strcat(fn,pent->d_name);
					FILE *f=fopen(fn,"rb");
					if(!f) continue;
					LoadMapFile(f); //will automatically close file
					// true = success, false = failure
				}
				closedir(pdir);
				printf("\r%-79s\n","Loading Maps: Done");
			}
			else printf("Error: maps not found.\n");
#undef NUMMAPS
#endif // WIN32
			SetStatusText("Precaching objects...");
			Storage.EnumObjectIDs(OBJ_PATHGROUP,InitPathGroups); // set up pathing point groups
			Storage.EnumObjectIDs(OBJ_SPAWNPOINT,InitSpawnPoints); // cache spawn points
			Storage.EnumObjectIDs(OBJ_GUILD,InitGuilds); // cache guilds

			// cache Texts and load Mail
			SetStatusText("Loading Texts and Mails...");
			Storage.EnumObjectIDs(OBJ_NPCTEXT,PreCacheNPCTexts);
			Storage.EnumObjectIDs(OBJ_PAGETEXT,PreCachePageTexts);
			Storage.EnumObjectIDs(OBJ_MAIL,LoadMails);

			SetStatusText("Loading Areatriggers...");
			InitAreaTriggerTable();
			SetStatusText("Mapping GameObject Templates...");
			Storage.EnumObjectIDs(OBJ_GAMEOBJECTTEMPLATE,DoGOTemplateInit);
			SetStatusText("Loading GameObject loot...");
			InitGOLoots();
		}
#ifdef WIN32 // On *nix, progress bar will automatically update the progress
		SetStatusText("Spawning Creatures...");
#endif
		SpawnSavedCreatures();
#ifdef WIN32
		SetStatusText("Spawning GameObjects...");
#endif
		SpawnSavedGameObjects();

		SetStatusText("Loading TaxiHandler Data...");
		LoadTaxiData();

		SetStatusText("Spawning Spirithealers");
		SpawnSpiritHealers();

		RealmThread.BeginThread(RealmServerThreadFunction,this);
		SetStatusText("Running");
#ifdef WIN32
		if(dlg)
		{
			dlg->Ctl_Progress.SetPos(0);
			dlg->Txt_ServerName.SetWindowText(Name);
			dlg->Btn_SendPacketDlg.EnableWindow();
			dlg->Btn_Save.EnableWindow();
			dlg->Btn_SendMail.EnableWindow();
			dlg->rs_started=TRUE;
			dlg->Btn_StartButton.SetBitmaps(IDB_BITMAP_STOP_NORMAL,IDB_BITMAP_STOP_OVER,IDB_BITMAP_STOP_PRESSED,IDB_BITMAP_STOP_DISABLED);
			dlg->Btn_StartButton.SetWindowText("&Stop");
			dlg->Btn_StartButton.EnableWindow(true);
		}
#endif
	}
#ifdef WIN32
	else if(dlg)
	{
		dlg->Txt_Status.SetWindowText("Failed to start! Ports not available.");
		RealmServer.Listener.Close();
		//RealmServer.RedirectListener.Close();
		//RealmServer.LoginListener.Close();
		RealmServer.MasterLists.Cleanup();
		RealmServer.MasterList.ShutDown();
		dlg->Btn_StartButton.EnableWindow(true);
	}
#else
	else
	{
		printf("Failed to start! Ports not available.");
		exit(1); //error code!
	}
#endif
}

void CRealmServer::SetProgressBar (long progressPos, long progressTotal, char *label)
{
#ifndef WIN32
	printf ("\r%s: [",label);

	long barPos = progressPos * 30 / progressTotal + 1;
	long p;
	for (p = 0; p < barPos; p++) putchar ('#');
	for (; p < 30; p++) putchar (' ');

	printf ("] %d%%, %d/%d \r", progressPos * 100 / progressTotal, progressPos, progressTotal);
	fflush(stdout);
#else
	if (dlg) dlg->Ctl_Progress.SetPos(progressPos * 100 / progressTotal);
#endif
}

bool CRealmServer::Initialize()
{
	if (!Listener.Create(Settings.Port_Realm))
		return false;
	if (!Listener.Listen())
		return false;
	/*if (!RedirectListener.Create(Settings.Port_Redirect))
	return false;
	if (!RedirectListener.Listen())
	return false;*/
	/*if (!LoginListener.Create(8087))
	return false;
	if (!LoginListener.Listen())
	return false;*/
	if (!MasterList.Create(Settings.Port_Masterlist))
		return false;
	return true;
}

void CRealmServer::UpdateMasterLists(int State)
{
	// construct packet
	RealmPacket Packet;
	memset(&Packet,0,sizeof(RealmPacket));
	Packet.Port=(unsigned short)Settings.Port_Realm; //Port_Redirect;
	strcpy(Packet.IPAddr,RealmServer.IPAddr);
	switch(State)
	{
	case -1:
		Packet.Name[0]='*';
		Packet.Icon=(Settings.PvPServer?REALMICON_PVP:REALMICON_NORMAL);
		Packet.Language=REALMLANGUAGE_ENGLISH;
		strncpy(&Packet.Name[1],Name,62);
		Packet.Name[63]=0;
		break;
	case 1:
		Packet.nPlayers=nClients;
		Packet.Name[0]='*';
		Packet.Icon=(Settings.PvPServer?REALMICON_PVP:REALMICON_NORMAL);
		Packet.Language=REALMLANGUAGE_ENGLISH;
		strncpy(&Packet.Name[1],Name,62);
		Packet.Name[63]=0;
		break;
	case 0:
	default:
		Packet.nPlayers=nClients;
		Packet.Icon=(Settings.PvPServer?REALMICON_PVP:REALMICON_NORMAL);
		Packet.Language=REALMLANGUAGE_ENGLISH;
		strcpy(Packet.Name,Name);
		break;
	}
	int nRL=0;
	for (unsigned long i = 0 ; i < MasterLists.Size ; i++)
	{
		if (Addr* pAddr=MasterLists[i])
		{
			MasterList.SendTo(&Packet,sizeof(RealmPacket),*pAddr);
			nRL++;
		}
	}
#ifdef WIN32
	if(dlg && State!=-1)
	{
		char temp[80];
		sprintf(temp,"Connected to %i Realm List Server%c",nRL,(nRL==1)?'\x00':'s');
		dlg->Txt_RLStatus.SetWindowText(temp);
	}
#endif
}

void CRealmServer::InitPlayerStartItems()
{
	STATICITEMS::HEARTHSTONE = DataManager.ItemTemplates[0x1b24];
	STATICITEMS::TOUGH_JERKY = DataManager.ItemTemplates[117];
	STATICITEMS::TOUGH_HUNK_OF_BREAD = DataManager.ItemTemplates[4540];
	STATICITEMS::DARNASSIAN_BLEU = DataManager.ItemTemplates[2070];
	STATICITEMS::FOREST_MUSHROOM_CAP = DataManager.ItemTemplates[4604];
	STATICITEMS::SHINY_RED_APPLE = DataManager.ItemTemplates[4536];
	STATICITEMS::REFRESHING_SPRING_WATER = DataManager.ItemTemplates[159];

	STATICITEMS::WARRIOR_SHORTSWORD = DataManager.ItemTemplates[25];
	STATICITEMS::WARRIOR_SHIELD = DataManager.ItemTemplates[2362];

	STATICITEMS::WARRIOR_SHIRT = DataManager.ItemTemplates[38];
	STATICITEMS::WARRIOR_PANTS = DataManager.ItemTemplates[39];
	STATICITEMS::WARRIOR_BOOTS = DataManager.ItemTemplates[40];
	STATICITEMS::NE_WARRIOR_SHIRT = DataManager.ItemTemplates[38];
	STATICITEMS::NE_WARRIOR_PANTS = DataManager.ItemTemplates[39];
	STATICITEMS::NE_WARRIOR_BOOTS = DataManager.ItemTemplates[40];
	STATICITEMS::EVIL_WARRIOR_SHIRT = DataManager.ItemTemplates[6125];
	STATICITEMS::EVIL_WARRIOR_PANTS = DataManager.ItemTemplates[139];
	STATICITEMS::EVIL_WARRIOR_BOOTS = DataManager.ItemTemplates[140];

	STATICITEMS::PALADIN_BOOTS = DataManager.ItemTemplates[43];
	STATICITEMS::PALADIN_HAMMER = DataManager.ItemTemplates[2361];

	STATICITEMS::HUMAN_PALADIN_SHIRT = DataManager.ItemTemplates[45];
	STATICITEMS::HUMAN_PALADIN_PANTS = DataManager.ItemTemplates[44];

	STATICITEMS::ROGUE_DAGGER = DataManager.ItemTemplates[2092];

	STATICITEMS::GOOD_ROGUE_SHIRT = DataManager.ItemTemplates[49];
	STATICITEMS::GOOD_ROGUE_PANTS = DataManager.ItemTemplates[48];
	STATICITEMS::GOOD_ROGUE_BOOTS = DataManager.ItemTemplates[47];

	STATICITEMS::EVIL_ROGUE_CHEST = DataManager.ItemTemplates[49];

	STATICITEMS::EVIL_ROGUE_PANTS = DataManager.ItemTemplates[48];
	STATICITEMS::EVIL_ROGUE_BOOTS = DataManager.ItemTemplates[47];

	STATICITEMS::TROLL_ROGUE_CHEST = DataManager.ItemTemplates[49];

	STATICITEMS::TROLL_ROGUE_PANTS = DataManager.ItemTemplates[48];
	STATICITEMS::TROLL_ROGUE_BOOTS = DataManager.ItemTemplates[47];

	STATICITEMS::PRIEST_SHIRT = DataManager.ItemTemplates[53];
	STATICITEMS::PRIEST_PANTS = DataManager.ItemTemplates[52];
	STATICITEMS::PRIEST_BOOTS = DataManager.ItemTemplates[51];
	STATICITEMS::PRIEST_MACE = DataManager.ItemTemplates[36];

	STATICITEMS::HUMAN_DWARF_PRIEST_ROBE = DataManager.ItemTemplates[6098];
	STATICITEMS::NIGHTELF_PRIEST_ROBE = DataManager.ItemTemplates[6119];
	STATICITEMS::UNDEAD_TROLL_PRIEST_ROBE = DataManager.ItemTemplates[144];

	STATICITEMS::MAGE_SHIRT = DataManager.ItemTemplates[6096];
	STATICITEMS::MAGE_PANTS = DataManager.ItemTemplates[1395];
	STATICITEMS::MAGE_BOOTS = DataManager.ItemTemplates[55];

	STATICITEMS::MAGE_STAFF = DataManager.ItemTemplates[35];

	STATICITEMS::HUMAN_GNOME_MAGE_ROBE = DataManager.ItemTemplates[56];
	STATICITEMS::DWARF_MAGE_ROBE = DataManager.ItemTemplates[6116];
	STATICITEMS::UNDEAD_TROLL_MAGE_ROBE = DataManager.ItemTemplates[6140];

	STATICITEMS::HUMAN_GNOME_WARLOCK_SHIRT = DataManager.ItemTemplates[6097];
	STATICITEMS::WARLOCK_PANTS = DataManager.ItemTemplates[1396];
	STATICITEMS::WARLOCK_BOOTS = DataManager.ItemTemplates[59];
	STATICITEMS::WARLOCK_DAGGER = STATICITEMS::ROGUE_DAGGER;

	STATICITEMS::HUMAN_GNOME_WARLOCK_ROBE = DataManager.ItemTemplates[57];
	STATICITEMS::ORC_UNDEAD_WARLOCK_ROBE = DataManager.ItemTemplates[6129];

	STATICITEMS::SHAMAN_MACE = STATICITEMS::PRIEST_MACE;
	STATICITEMS::ORC_TAUREN_SHAMAN_SHIRT = DataManager.ItemTemplates[154];
	STATICITEMS::ORC_TAUREN_SHAMAN_PANTS = DataManager.ItemTemplates[153];
	STATICITEMS::TROLL_SHAMAN_SHIRT = DataManager.ItemTemplates[6134];
	STATICITEMS::TROLL_HUNTER_PANTS = DataManager.ItemTemplates[6135];

	STATICITEMS::DRUID_PANTS = DataManager.ItemTemplates[6124];
	STATICITEMS::NIGHTELF_DRUID_ROBE = DataManager.ItemTemplates[6123];
	STATICITEMS::TAUREN_DRUID_ROBE = DataManager.ItemTemplates[6139];

	STATICITEMS::NIGHTELF_DRUID_STAFF = DataManager.ItemTemplates[35];
	STATICITEMS::TAUREN_DRUID_STAFF = STATICITEMS::MAGE_STAFF;

	STATICITEMS::HUNTER_AXE = DataManager.ItemTemplates[37];
	STATICITEMS::HUNTER_SHIELD = DataManager.ItemTemplates[2362];

	STATICITEMS::DWARF_NIGHTELF_HUNTER_SHIRT = DataManager.ItemTemplates[148];
	STATICITEMS::DWARF_NIGHTELF_HUNTER_PANTS = DataManager.ItemTemplates[147];
	STATICITEMS::DWARF_NIGHTELF_HUNTER_BOOTS = DataManager.ItemTemplates[129];
	STATICITEMS::ORC_TAUREN_HUNTER_SHIRT = DataManager.ItemTemplates[148];
	STATICITEMS::ORC_TAUREN_HUNTER_PANTS = DataManager.ItemTemplates[6126];
	STATICITEMS::ORC_HUNTER_BOOTS = DataManager.ItemTemplates[6127];
	STATICITEMS::TROLL_HUNTER_SHIRT = DataManager.ItemTemplates[148];
	STATICITEMS::TROLL_HUNTER_PANTS = DataManager.ItemTemplates[147];

	STATICITEMS::HUNTER_AMMO_POUCH = DataManager.ItemTemplates[5441];
	STATICITEMS::HUNTER_QUIVER = DataManager.ItemTemplates[5439];
	STATICITEMS::HUNTER_BULLET = DataManager.ItemTemplates[2516];
	STATICITEMS::HUNTER_ARROW = DataManager.ItemTemplates[2512];
	STATICITEMS::HUNTER_RIFLE = DataManager.ItemTemplates[2509];
	STATICITEMS::HUNTER_BOW = DataManager.ItemTemplates[2504];

	STATICITEMS::GUILD_TABARD = DataManager.ItemTemplates[5976];

	STATICITEMS::FLYPATH_ITEM1 = 0;
	STATICITEMS::FLYPATH_ITEM2 = 0;
	STATICITEMS::FLYPATH_ITEM3 = 0;

	CChatManager::InitCloaks();

	STATICITEMS::ITEMWDB_COUNT = 0;
	STATICITEMS::ITEMWDB_FIRST = 0;
}

CCreature *CRealmServer::GenerateCreatureNew(CCreatureTemplate *pTemplate, unsigned long Continent,
											 _Location Loc, float Facing)
{
	CCreature *pCreature = new CCreature;

	pCreature->New(*pTemplate);
	pCreature->Data.Continent=Continent;
	pCreature->Data.SpawnLoc=Loc;
	pCreature->Data.Loc=Loc;
	pCreature->Data.SpawnFacing=Facing;
	pCreature->Data.Facing=Facing;
	pCreature->pTemplate=pTemplate;
	pCreature->FirstPoint=0;
	DataManager.NewObject(*pCreature);

	return pCreature;
}

CCreature *CRealmServer::GenerateCreature(unsigned long Model, const char *Name, unsigned long Continent,
										  _Location Loc, float Facing)
{
	return NULL;	// THIS FUNCTION SHOULD NOT BE CALLED ANYMORE!
	/*
	CCreatureTemplate *pCreatureTemplate = NULL;
	CCreature *pCreature = new CCreature;
	string TemplateName=Name;
	MakeLower(TemplateName);
	int TemplateID=DataManager.CreatureTemplateNames[TemplateName];
	if(!TemplateID || !DataManager.RetrieveObject((CWoWObject**)&pCreatureTemplate, OBJ_CREATURETEMPLATE, TemplateID))
	{
	pCreatureTemplate=new CCreatureTemplate;
	pCreatureTemplate->New(Name);
	pCreatureTemplate->Generated=true;
	pCreature->New(pCreatureTemplate->guid);
	//		strcpy(pCreature->Data.Name,Name);
	pCreature->Data.CurrentStats.HitPoints=65;
	pCreature->Data.Level=1;
	pCreature->Data.Model=Model;
	pCreature->Data.NormalStats.HitPoints=65;
	pCreature->Data.DamageMax=6;
	pCreature->Data.DamageMin=4;
	pCreature->Data.Exp = 200;
	pCreature->Data.Continent=Continent;
	pCreature->Data.SpawnLoc=Loc;
	pCreature->Data.Loc=Loc;
	pCreature->Data.SpawnFacing=Facing;
	pCreature->Data.Facing=Facing;
	DataManager.NewObject(*pCreatureTemplate);
	}
	else
	{
	pCreature->New(*pCreatureTemplate);
	pCreature->Data.Continent=Continent;
	pCreature->Data.SpawnLoc=Loc;
	pCreature->Data.Loc=Loc;
	pCreature->Data.SpawnFacing=Facing;
	pCreature->Data.Facing=Facing;
	}
	pCreature->pTemplate=pCreatureTemplate;
	DataManager.NewObject(*pCreature);

	// lets make him despawn.
	// creatures will live for 300 seconds  (5 minutes)
	//EventManager.AddEvent(*Creature,300000,EVENT_CREATURE_DESPAWN,0,0);
	//EventManager.AddEvent(*Creature,10000,EVENT_CREATURE_REGENERATE,0,0);
	//if(!pCreature->Data.NPCType) EventManager.AddEvent(*pCreature,30000,EVENT_CREATURE_WANDER,0,0);

	return pCreature;*/
}

CTaxiMob *CRealmServer::GenerateTaxiMob(unsigned long Model, const char *Name, unsigned long Continent,
										_Location Loc, float Facing)
{	
	CTaxiMob *pCreature = new CTaxiMob;
	CCreatureTemplate *pCreatureTemplate=new CCreatureTemplate;
	pCreatureTemplate->New(Name);
	pCreatureTemplate->Data.Level = 1;
	pCreatureTemplate->Data.Model = Model;
	pCreatureTemplate->Data.NormalStats.HitPoints = 65;
	pCreatureTemplate->Data.DamageMax = 6;
	pCreatureTemplate->Data.DamageMin = 4;
	pCreatureTemplate->Generated=true;
	pCreature->New(pCreatureTemplate->guid);
	pCreature->Data.CurrentStats.HitPoints=65;
	pCreature->Data.Continent=Continent;
	pCreature->Data.SpawnLoc=Loc;
	pCreature->Data.Loc=Loc;
	pCreature->Data.SpawnFacing=Facing;
	pCreature->Data.Facing=Facing;
	pCreature->FirstPoint=0;
	DataManager.NewObject(*pCreatureTemplate);
	pCreature->pTemplate=pCreatureTemplate;
	DataManager.NewObject(*pCreature);
	return pCreature;
}

void CRealmServer::BroadcastOutPacket(unsigned short OpCode, void *buffer, unsigned short Length)
{
	CLock L(&Clients.CS);// exclusive lock on clients for this, not guaranteed to be in the realm server thread
	for (unsigned long i = 0 ; i < Clients.Size ; i++)
	{
		if (CClient *pClient=Clients[i])
		{
			pClient->OutPacket(OpCode,buffer,Length);
		}
	}
}

void CRealmServer::SetStatusText(char newtext[])
{
#ifdef WIN32
	if(dlg)
	{
		dlg->Txt_Status.SetWindowTextA(newtext);
		dlg->LogText(newtext);
	}
#else
	puts(newtext);
#endif
}

void CRealmServer::SpawnSpiritHealers(void)
{
	CCreature *pCreature = NULL;
	char *shname = "spirit healer"; // lowercase because we're looking up the name
	// Find CT
	CCreatureTemplate *pTemplate = NULL;
	unsigned long shguid = DataManager.CreatureTemplateNames[shname];
	int count = 0;

	if(DataManager.RetrieveObject((CWoWObject**)&pTemplate,OBJ_CREATURETEMPLATE,shguid))
	{
		for (int i=0; i<NUM_GRAVEYARDS; i++)
		{
			_Location loc;
			unsigned long continent = SHLocations[i].Continent;
			loc.X = SHLocations[i].Loc.X;
			loc.Y = SHLocations[i].Loc.Y;
			loc.Z = SHLocations[i].Loc.Z;
			pCreature = GenerateCreatureNew(pTemplate,continent,loc,0);
			RegionManager.ObjectNew(*pCreature,0,loc.X,loc.Y);
			SetProgressBar(i+1,NUM_GRAVEYARDS, "Spawning Spirithealers");
			count++;
		}
	}
	Debug.Logf("%d spirit healers spawned.",count);

	return;
}

int CRealmServer::SpawnSavedCreatures(void)
{
	CCreature *pCreature = NULL;
	int count = 0;
	long filesize;
	string creaturename;

	FILE *f = fopen("data/spawns.sav", STORAGE_READ);
	if(f == NULL)
		return -1;
	fseek(f,0,SEEK_END);
	filesize=ftell(f);
	fseek(f,0,SEEK_SET);
	long size = sizeof(CreatureSaveData);
	long approxcreatures=filesize/size;
	long spawnedcreatures = 0;
	char *buffer = (char*)malloc(size);
	unsigned long templatenumber;
	unsigned short spawnid = 0;
	CCreatureTemplate *pTemplate = NULL;
	if(buffer == NULL)
	{
		fclose(f);
		return -1;
	}
	while (fread(buffer, size, 1, f) == 1)
	{
		count++;
		if (!(count % 689)) SetProgressBar(ftell(f)/size, approxcreatures, "Spawning Creatures");
		CreatureSaveData *Data = (CreatureSaveData *)buffer;
		templatenumber=Data->TemplateID | 0x08000000;
		if(DataManager.RetrieveObject((CWoWObject**)&pTemplate, OBJ_CREATURETEMPLATE, templatenumber))
		{
			pCreature = RealmServer.GenerateCreatureNew(pTemplate,Data->Continent, Data->Loc, Data->Facing);
			spawnedcreatures++;
			spawnid++;
			pCreature->Data.Template = templatenumber;
			pCreature->Data.SpawnID = spawnid;
			pCreature->Data.CurrentStats = pTemplate->Data.NormalStats;
			pCreature->FirstPoint = Data->FirstPoint;
			RegionManager.ObjectNew(*pCreature, pCreature->Data.Continent, pCreature->Data.Loc.X, pCreature->Data.Loc.Y);
			pCreature->AI_Initialize();
			pCreature->ResetAllAuras();
			pCreature->InitAEvents();
			pCreature->AI_SetFaction();
			Spawns[spawnid] = *Data;
			
		} else {
			//Debug.Logf("Can't spawn %d",Data->TemplateID);
		}
	}

#ifndef WIN32
	printf("%d of %d creatures spawned                                          \r\n", spawnedcreatures, approxcreatures);
#else
	Debug.Logf("%d of %d creatures spawned.", spawnedcreatures, approxcreatures);
#endif
	HighestSpawnID = spawnid;
	free(buffer);
	fclose(f);
	return 0;
}

int CRealmServer::SpawnSavedGameObjects(void)
{
	int count = 0;
	long filesize;

	FILE *f = fopen("data/gospawns.sav", STORAGE_READ);
	if(f == NULL)
		return -1;
	fseek(f,0,SEEK_END);
	filesize=ftell(f);
	fseek(f,0,SEEK_SET);
	long size = sizeof(GameObjectSaveData);
	long approxcreatures=filesize/size;
	long spawnedcreatures = 0;
	char *buffer = (char*)malloc(size);
	unsigned long templatenumber;
	CGameObjectTemplate *pTemplate = NULL;
	CGameObject *pObject;
	if(buffer == NULL)
	{
		fclose(f);
		return -1;
	}
	while (fread(buffer, size, 1, f) == 1)
	{
		count++;
		if (!(count % 289)) SetProgressBar(ftell(f)/size, approxcreatures, "Spawning GameObjects");
		GameObjectSaveData *Data = (GameObjectSaveData *)buffer;
		templatenumber=Data->TemplateID;
		if(DataManager.RetrieveObject((CWoWObject**)&pTemplate, OBJ_GAMEOBJECTTEMPLATE, templatenumber))
		{
			spawnedcreatures++;
			pObject = new CGameObject;
			pObject->New(templatenumber);
			pObject->Data.Continent = Data->Continent;
			pObject->Data.Loc.X = Data->Loc.X;
			pObject->Data.Loc.Y = Data->Loc.Y;
			pObject->Data.Loc.Z = Data->Loc.Z;
			pObject->Data.Facing = Data->Facing;
			pObject->Data.Rotation[0] = Data->Rotation[0];
			pObject->Data.Rotation[1] = Data->Rotation[1];
			pObject->Data.Rotation[2] = Data->Rotation[2];
			pObject->Data.Rotation[3] = Data->Rotation[3];
			// pObject->Data.Model = pTemplate->Data.Model;
			// pObject->Data.Type = pTemplate->Data.Type;
			// pObject->Data.Flags = pTemplate->Data.Flags;
			pObject->Data.Faction = pTemplate->Data.Faction;
			/*if (Data->GType)
			{
			pObject->pTemplate->Data.GType = Data->GType;
			}
			if (Data->Type)
			{
			pObject->pTemplate->Data.Type = Data->Type;
			}*/
			RegionManager.ObjectNew(*pObject, pObject->Data.Continent, pObject->Data.Loc.X, pObject->Data.Loc.Y);
		}
	}

#ifndef WIN32
	printf("%d of %d gameobjects spawned                                          \r\n", spawnedcreatures, approxcreatures);
#else
	Debug.Logf("%d of %d gameobjects spawned.", spawnedcreatures, approxcreatures);
#endif
	free(buffer);
	fclose(f);
	return 0;
}
