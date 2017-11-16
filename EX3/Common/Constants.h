// (c) AbyssX Group
#if !defined(CONSTANTS_H)
#define CONSTANTS_H

//! \todo Pretty much eliminate this file altogether, none of this stuff
//! is truly global.

//! Server Name
#define SERVER_NAME "(CVS) - EX3 PRO V3.0"
#define IRC_INFO "|cAA33AA33IRC -> /server irc.gotwow.net -j #EX3"

//! Various default unit speeds.
#define WALK_SPEED		(2.5f)
#define RUN_SPEED			(7.0f)
#define SWIM_SPEED		(4.7222f)
#define TURN_SPEED		(3.14f)

//! Various Ranges Stuff
#define MAX_ATTACK_RANGE	(1.2f)
#define MAX_FOLLOW_RANGE	(8.0f)
#define MAX_GROUP_RANGE		(100.0f)

//! Basic facing directions.
#define DEGREEMULTIPLIER	((2.0f * 3.14f) / 360.0f)
#define FACING_EAST				(0.0f)
#define FACING_NORTHEAST	(45.0f * DEGREEMULTIPLIER)
#define FACING_NORTH			(90.0f * DEGREEMULTIPLIER)
#define FACING_NORTHWEST	(135.0f * DEGREEMULTIPLIER)
#define FACING_WEST				(180.0f * DEGREEMULTIPLIER)
#define FACING_SOUTHWEST	(225.0f * DEGREEMULTIPLIER)
#define FACING_SOUTH			(270.0f * DEGREEMULTIPLIER)
#define FACING_SOUTHEAST	(315.0f * DEGREEMULTIPLIER)

//! Authorization packets.
#define AUTH_CHALLENGE1_LEN 118 // (8 * 14) + 6
#define AUTH_CHALLENGE1 { \
	0x00, 0x00, 0x00, 0x77, 0x16, 0x35, 0xB8, 0x98, \
	0x4F, 0xEF, 0x3D, 0x95, 0xEA, 0x16, 0x7E, 0x75, \
	0x2D, 0x76, 0x8F, 0xF8, 0x3B, 0x2B, 0x57, 0x75, \
	0xBD, 0x4E, 0xF3, 0x4B, 0x9A, 0xA6, 0xB3, 0xDE, \
	0x07, 0xAA, 0x6B, 0x01, 0x07, 0x20, 0x89, 0x4B, \
	0x64, 0x5E, 0x89, 0xE1, 0x53, 0x5B, 0xBD, 0xAD, \
	0x5B, 0x8B, 0x29, 0x06, 0x50, 0x53, 0x08, 0x01, \
	0xB1, 0x8E, 0xBF, 0xBF, 0x5E, 0x8F, 0xAB, 0x3C, \
	0x82, 0x87, 0x2A, 0x3E, 0x9B, 0xB7, 0xB8, 0xC6, \
	0x2A, 0xCD, 0x5D, 0x7C, 0x24, 0xF4, 0x9F, 0x0F, \
	0x60, 0xD7, 0xF5, 0x4A, 0x07, 0xD3, 0x92, 0x84, \
	0x77, 0x08, 0xAB, 0xA8, 0x16, 0x87, 0x0C, 0x6C, \
	0xF5, 0x46, 0x65, 0xF6, 0xA5, 0x37, 0xD0, 0x90, \
	0xB8, 0x76, 0x65, 0xD7, 0xA3, 0xD0, 0xCA, 0x54, \
	0x62, 0x6E, 0x63, 0xB3, 0x08, 0x8B \
}
#define AUTH_CHALLENGE2_LEN 34 // (8 * 4) + 2
#define AUTH_CHALLENGE2 { \
	0x02, 0x00, 0x01, 0xA2, 0x9E, 0x0F, 0x94, 0x03, \
	0x50, 0x3F, 0xF3, 0x8D, 0x22, 0x0B, 0x1C, 0xB7, \
	0xC4, 0x2E, 0xAF, 0x1F, 0xE9, 0xE2, 0x06, 0x81, \
	0x3D, 0xD3, 0x66, 0x0E, 0x3A, 0xD0, 0x23, 0xC2, \
	0x99, 0x47 \
}
#define WORLD_CHALLENGE_LEN 6 // 6
#define WORLD_CHALLENGE { \
	0x00, 0x00, 0xCB, 0xB4, 0xEB, 0x34, \
}

//! Enumerations
#define	STATUS_NORMAL 0x00
#define	STATUS_AFK 0x02
#define	STATUS_DND 0x04
#define	STATUS_GM 0x08
#define	STATUS_DEAD 0x10

//!Item Slots
#define SLOT_HEAD			0
#define SLOT_NECK			1
#define SLOT_SHOULDERS		2
#define SLOT_SHIRT			3
#define SLOT_CHEST			4
#define SLOT_WAIST			5
#define SLOT_LEGS			6
#define SLOT_FEET			7
#define SLOT_WRISTS			8
#define SLOT_HANDS			9
#define SLOT_FINGERL		10
#define SLOT_FINGERR		11
#define SLOT_TRINKETL		12
#define SLOT_TRINKETR		13
#define SLOT_BACK			14
#define SLOT_MAINHAND		15
#define SLOT_OFFHAND		16
#define SLOT_RANGED			17
#define SLOT_TABARD			18

//! Misc Types
#define SLOT_BAG1			19
#define SLOT_BAG2			20
#define SLOT_BAG3			21
#define SLOT_BAG4			22
#define SLOT_INBACKPACK		23

//! Item Worn Types
#define WORN_NONE		0
#define WORN_HEAD		1
#define WORN_NECK		2
#define WORN_SHOULDER	3
#define WORN_SHIRT		4
#define WORN_CHEST		5
#define WORN_WAIST		6
#define WORN_PANTS		7
#define WORN_BOOTS		8
#define WORN_BRACERS	9
#define WORN_HAND		10
#define WORN_FINGER		11
#define WORN_TRINKET	12
#define WORN_1H			13
#define WORN_SHIELD		14
#define WORN_RANGED		15
#define WORN_BACK		16
#define WORN_2H			17
#define WORN_JUNK		18
#define WORN_BAG		18
#define WORN_TABARD		19
#define WORN_ROBE		20
#define WORN_MAINHAND	21
#define WORN_OFFHAND	22
#define WORN_HELD		23
#define WORN_AMMO		24
#define WORN_THROWN		25
#define WORN_RANGEDRIGHT 26
#define WORN_NUM_TYPES  27

//Unit Flags
#define UNIT_FLAG_SHEATHE		0x40000000
#define UNIT_FLAG_GHOST			0x10000
#define UNIT_FLAG_SNEAK			0x8000
#define UNIT_FLAG_HEALTHBAR		0x4000
#define UNIT_FLAG_MOUNT			0x2000
#define UNIT_FLAG_MOUNT_ICON	0x1000
#define UNIT_FLAG_FLYING		0x8
#define UNIT_FLAG_FROZEN		0x4
#define UNIT_FLAG_FROZEN2		0x800000
#define UNIT_FLAG_FROZEN3		0x400000
#define UNIT_FLAG_FROZEN4		0x1
#define UNIT_FLAG_STANDART		0x0

enum StartingZones
{
	Z_HUMAN = 12, 
	Z_ORC = 14, 
	Z_DWARF = 1,
	Z_NIGHT_ELF = 141,
	Z_UNDEAD = 85,
	Z_TAUREN = 215,
	Z_GNOME = 1,
	Z_TROLL = 14
};
		
enum Maps
{
	MAP_AZEROTH = 0,
	MAP_KALIMDOR = 1,
	MAP_MONASTRY = 44
};

enum Factions
{
	HORDE = 6,
	ALLIANCE = 4,
};

enum Races
{
	RACE_HUMAN = 0x01,
	RACE_ORC = 0x02,
	RACE_DWARF = 0x03,
	RACE_NIGHT_ELF = 0x04,
	RACE_UNDEAD = 0x05,
	RACE_TAUREN = 0x06,
	RACE_GNOME = 0x07,
	RACE_TROLL = 0x08
};

enum Classes
{
	CLASS_WARRIOR = 0x01,
	CLASS_PALADIN = 0x02,
	CLASS_HUNTER = 0x03,
	CLASS_ROGUE	= 0x04,
	CLASS_PRIEST = 0x05,
	CLASS_SHAMAN = 0x07,
	CLASS_MAGE = 0x08,
	CLASS_WARLOCK = 0x09,
	CLASS_DRUID = 0x0B
};

enum ChatTypes {
	CHAT_SAY = 0x00,
	CHAT_WHISPERS = 0x05,
	CHAT_WHISPERS_TO = 0x06, 
	CHAT_YELL = 0x04,
	CHAT_EMOTE = 0x07,
	CHAT_PARTY = 0x01,
};

enum Emotes {
	EMOTE_APPLAUD = 0x05,
	EMOTE_BEG = 0x08,
	EMOTE_BOW = 0x11,
	EMOTE_CHEER = 0x15,
	EMOTE_CRY = 0x22,
	EMOTE_DANCE = 0x1F,
    EMOTE_EAT = 0x25,
	EMOTE_FLEX = 0x29,
	EMOTE_POINT = 0x48,
	EMOTE_ROAR = 0x4B,
	EMOTE_RUDE = 0x4D,
	EMOTE_SALUTE = 0x4E,
	EMOTE_SHY = 0x54,
	EMOTE_TALK = 0x5D,
	EMOTE_WAVE = 0x65,
	EMOTE_CHICKEN = 0x16,
	EMOTE_KISS = 0x3A,
	EMOTE_KNEEL = 0x3B,
	EMOTE_LAUGH = 0x3C,
	EMOTE_SIT = 0x56,
	EMOTE_SLEEP = 0x57,
	EMOTE_STAND = 0x8D
};

enum SHEATHETYPE
{
	SHEATHETYPE_NONE,
	SHEATHETYPE_MAINHAND,
	SHEATHETYPE_OFFHAND,
	SHEATHETYPE_LARGEWEAPONLEFT,
	SHEATHETYPE_LARGEWEAPONRIGHT,
	SHEATHETYPE_HIPWEAPONLEFT,
	SHEATHETYPE_HIPWEAPONRIGHT,
	SHEATHETYPE_SHIELD,
	SHEATHETYPE_NUM_TYPES
};

enum EVENT_TYPES
{
	WORLDSERVER,
	TAXIHANDLER,
	MONSTERHANDLER,
	MELEEHANDLER,
	CHAMPIOSHIPHANDLER,
	OBJ_PLAYER,
	OBJ_MONSTER
};

#endif
