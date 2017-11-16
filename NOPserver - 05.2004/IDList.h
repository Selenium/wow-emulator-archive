#ifndef _OBJECTIDS_H_
#define _OBJECTIDS_H_

/* ADD MORE */
enum ObjectTypes {
    TYPE_OBJ    = 0,
    TYPE_ITEM   = 1,
    TYPE_CONT   = 2,
    TYPE_UNIT   = 3,
    TYPE_CHAR   = 4,
    TYPE_GOBJ   = 5,
    TYPE_DOBJ   = 6,
    TYPE_CORPSE = 7,
};

enum ObjectBitMask {
    BMASK_OBJ    = 1,
    BMASK_ITEM   = 2,
    BMASK_CONT   = 4,
    BMASK_UNIT   = 8,
    BMASK_CHAR   = 16,
    BMASK_GOBJ   = 32,
    BMASK_DOBJ   = 64,
    BMASK_CORPSE = 128,
};

enum RaceID {
    RACE_HUMAN = 0x01,
    RACE_ORC,
    RACE_DWARF,
    RACE_NIGHTELF,
    RACE_UNDEAD,
    RACE_TAUREN,
    RACE_GNOME,
    RACE_TROLL,
};

enum LangIDs {
    LANG_GLOBAL     = 0x0,
    LANG_ORCISH     = 0x1,
    LANG_DARNASSIAN = 0x2,
    LANG_TAURAHE    = 0x3,
    LANG_DWARVISH   = 0x6,
    LANG_COMMON     = 0x7,
    LANG_DEMONIC    = 0x8,
    LANG_TITAN      = 0x9,
    LANG_THELASSIAN = 0xA,
    LANG_DRACONIC   = 0xB,
    LANG_KALIMAG    = 0xC,
    LANG_GNOME      = 0xD,
    LANG_TROLL      = 0xE,
};

enum ClassID {
    CLASS_WARRIOR = 0x01,
    CLASS_PALADIN,
    CLASS_HUNTER,
    CLASS_ROUGE,
    CLASS_PRIEST,
    CLASS_MISSING1, /* 0x06 - missing in action */
    CLASS_SHAMAN,
    CLASS_MAGE,
    CLASS_WARLOCK,
    CLASS_MISSING2, /* 0x0a - missing in action too! */
    CLASS_DRUID,
};

enum ChatTypes {
    CHAT_MSG_SAY            = 0x00,
    CHAT_MSG_PARTY          = 0x01,	
    CHAT_MSG_GUILD          = 0x02,	
    CHAT_MSG_OFFICER        = 0x03,	
    CHAT_MSG_YELL           = 0x04,	
    CHAT_MSG_WHISPER        = 0x05,	
    CHAT_MSG_WHISPER_INFORM = 0x06,	
    CHAT_MSG_EMOTE          = 0x07,	
    CHAT_MSG_TEXT_EMOTE     = 0x08,	
    CHAT_MSG_SYSTEM         = 0x09,	
    CHAT_MSG_MONSTER_SAY    = 0x0A,	
    CHAT_MSG_MONSTER_YELL   = 0x0B,	
    CHAT_MSG_MONSTER_EMOTE  = 0x0C,	
    CHAT_MSG_CHANNEL        = 0x0D,	
    CHAT_MSG_CHANNEL_JOIN   = 0x0E,	
    CHAT_MSG_CHANNEL_LEAVE  = 0x0F,	
    CHAT_MSG_CHANNEL_LIST   = 0x10,	
    CHAT_MSG_CHANNEL_NOTICE = 0x11,
    CHAT_MSG_CHANNEL_NOTICE_USER  = 0x012,
    CHAT_MSG_AFK            = 0x13,	
    CHAT_MSG_DND            = 0x14,
    CHAT_MSG_COMBAT_LOG     = 0x15,
    CHAT_MSG_IGNORED        = 0x16,
    CHAT_MSG_SKILL          = 0x17,
    CHAT_MSG_LOOT           = 0x18,
};

enum TradeStatus {
    TRADE_STATUS_PLAYER_BUSY = 0x00,
    TRADE_STATUS_PROPOSED,
    TRADE_STATUS_INITIATED,
    TRADE_STATUS_CANCELLED,
    TRADE_STATUS_ACCEPTED,
    TRADE_STATUS_ALREADY_TRADING,
    TRADE_STATUS_PLAYER_NOT_FOUND,
    TRADE_STATUS_STATE_CHANGED,
    TRADE_STATUS_COMPLETE,
    TRADE_STATUS_UNACCEPTED,
    TRADE_STATUS_TOO_FAR_AWAY,
    TRADE_STATUS_WRONG_FACTION,
    TRADE_STATUS_FAILED,
    TRADE_STATUS_DEAD,
    TRADE_STATUS_PETITION,
    TRADE_STATUS_PLAYER_IGNORED,
};

enum StandStates {
    UNIT_STANDING           = 0,
    UNIT_SITTING            = 1,
    UNIT_SITTINGCHAIR       = 2,
    UNIT_SLEEPING           = 3,
    UNIT_SITTINGCHAIRLOW    = 4,
    UNIT_FIRSTCHAIRSIT      = 4,
    UNIT_SITTINGCHAIRMEDIUM = 5,
    UNIT_SITTINGCHAIRHIGH   = 6,
    UNIT_LASTCHAIRSIT       = 6,
    UNIT_DEAD               = 7,
    UNIT_KNEEL              = 8,
    UNIT_NUMSTANDSTATES     = 9,
    UNIT_NUMCHAIRSTATES     = 3,
};

enum DamageTypes {
    DMG_PHYSICAL    = 0,
    DMG_HOLY        = 1,
    DMG_FIRE        = 2,
    DMG_NATURE      = 3,
    DMG_FROST       = 4,
    DMG_SHADOW      = 5,
};

enum ObjectUpdates {
    OBJUPD_UPDATE           = 0,
    OBJUPD_UPDATE_MOV       = 1,
    OBJUPD_CREATE           = 2,
    OBJUPD_OUTOFRANGE       = 3,
    OBJUPD_INRANGE          = 4,
};

enum PropertyBounds {
    OBJECT_START            = 0,
    OBJECT_SIZE             = 6,
    OBJECT_END              = 5,
    
    ITEM_START              = 6,
    ITEM_SIZE               = 38,
    ITEM_END                = 43,
    CONTAINER_START         = 36,
    CONTAINER_SIZE          = 42,
    CONTAINER_END           = 77,

    UNIT_START              = 6,
    UNIT_SIZE               = 186,
    UNIT_END                = 191,
    CHAR_START              = 192,
    CHAR_SIZE               = 467,
    CHAR_END                = 658,

    GAMEOBJECT_START        = 6,
    GAMEOBJECT_SIZE         = 14,
    GAMEOBJECT_END          = 19,

    DYNAMICOBJECT_START     = 6,
    DYNAMICOBJECT_SIZE      = 10,
    DYNAMICOBJECT_END       = 15,

    CORPSE_START            = 6,
    CORPSE_SIZE             = 30,
    CORPSE_END              = 35,
};

enum ObjectPropertyIndices {
    OBJECT_OBJECTID         = 0, /* uint64 */
    OBJECT_TYPE             = 2,
    OBJECT_ENTRYNUM         = 3,
    OBJECT_SCALE            = 4,
    OBJECT_PADDING          = 5,
};

enum ItemPropertyIndices {
    ITEM_OWNER              = 6, /* uint64 */
    ITEM_CONTAINED          = 8, /* uint64 */
    ITEM_CREATOR            = 10, /* uint64 */
    ITEM_STACK_COUNT        = 12,
    ITEM_DURATION           = 13,
    ITEM_SPELL_CHARGES      = 14, /* 5 uint32 */
    ITEM_FLAGS              = 19,
    ITEM_ENCHANTMENT        = 20, /* 21 uint32 */
    ITEM_PROPERTY_SEED      = 41,
    ITEM_RANDOM_PROPERTIES  = 42,
    ITEM_PAD                = 43,
};

enum ContainerPropertyIndices {
    CONTAINER_NUM_SLOTS     = 36,
    CONTAINER_ALIGN_PAD     = 37,
    CONTAINER_SLOTS         = 38, /* 40 uint32, slot 0 - 39 */
};

enum UnitPropertyIndicies {
    UNIT_CHARMID            = 6, /* uint64 */
    UNIT_SUMMONID           = 8, /* uint64 */

    UNIT_CHARMEDBY          = 10, /* uint64 */
    UNIT_SUMMONEDBY         = 12, /* uint64 */
    UNIT_CREATEDBY          = 14, /* uint64 */

    UNIT_TARGET             = 16, /* uint64 */
    UNIT_COMBOTARGET        = 18, /* uint64 */

    UNIT_CHANNELOBJECT      = 20, /* uint64 */

    UNIT_HEALTH             = 22,
    UNIT_MANA               = 23,
    UNIT_RAGE               = 24,
    UNIT_FOCUS              = 25,
    UNIT_POWERUNK           = 26,

    UNIT_MAX_HEALTH         = 27,
    UNIT_MAX_MANA           = 28,
    UNIT_MAX_RAGE           = 29,
    UNIT_MAX_FOCUS          = 30,
    UNIT_MAX_POWERUNK       = 31,

    UNIT_LEVEL              = 32,

    UNIT_FACTION_TEMPLATE   = 33,

    UNIT_CLASSINFO          = 34, /* Race, class, gender, unk */

    UNIT_STRENGTH           = 35,
    UNIT_AGILITY            = 36,
    UNIT_STAMINA            = 37,
    UNIT_INTELLECT          = 38,
    UNIT_SPIRIT             = 39,

    UNIT_BASE_STRENGTH      = 40,
    UNIT_BASE_AGILITY       = 41,
    UNIT_BASE_STAMINA       = 42,
    UNIT_BASE_INTELLECT     = 43,
    UNIT_BASE_SPIRIT        = 44,

    UNIT_VIRTUAL_ITEMSLOTDISPLAY = 45, /* 3 uint32 */
    UNIT_VIRTUAL_ITEMINFO   = 48, /* 6 uint32 */

    UNIT_FLAGS              = 54, /* unk */
    UNIT_COINAGE            = 55,
    
    UNIT_AURA               = 56, /* 56 uint32 */
    UNIT_AURALEVELS         = 112, /* 10 uint32 */
    UNIT_AURAAPPLICATIONS   = 122, /* 10 uint32 */
    UNIT_AURA_FLAGS         = 132, /* 7 uint32 */
    UNIT_AURA_STATE         = 139,
    
    UNIT_BASE_ATTACKTIME    = 140, /* 2 uint32, left / right? */
    UNIT_RESISTANCES        = 142, /* 6 uint32, see enum DamageTypes for offsets  */
    
    UNIT_BOUNDING_RADIUS    = 148, /* float32 */
    UNIT_COMBAT_REACH       = 149, /* float32 */
    UNIT_WEAPON_REACH       = 150, /* float32 */

    UNIT_DISPLAYID          = 151,
    UNIT_MOUNTDISPLAYID     = 152,

    UNIT_DAMAGE             = 153, /* low 16 bits = min dmg, hi 16 bits = max dmg */
    UNIT_MOD_DAMAGE_DONE    = 154, /* 6 uint32, see enum DamageTypes for offsets */

    UNIT_RESISTANCEBUFF_POS = 160, /* 6 uint32, see enum DamageTypes for offsets */
    UNIT_RESISTANCEBUFF_NEG = 166, /* 6 uint32, see enum DamageTypes for offsets */
    UNIT_RESISTANCEMOD_ITEM = 172, /* 6 uint32, see enum DamageTypes for offsets */

    UNIT_ANIMSTATE          = 178, /* 1 byte = animstate */

    UNIT_PETNUMBER          = 179,
    UNIT_PETNAMETIMESTAMP   = 180,
    UNIT_PETXP              = 181,
    UNIT_PETNEXTLEVELXP     = 182,

    UNIT_DYNAMICFLAGS       = 183, /* unk, 1 = glitter */
    
    UNIT_EMOTESTATE         = 184,
    
    UNIT_CHANNELSPELL       = 185, /* unk */
    UNIT_MODCASTSPELL       = 186, /* unk */
    UNIT_CREATEDBYSPELL     = 187,

    UNIT_NPC_FLAGS          = 188, /* unk */

    UNIT_BYTES2             = 189, /* unk */

    UNIT_ATTACKPOWER        = 190, /* unk */
    
    UNIT_PADDING            = 191,
};

enum CharacterPropertyIndicies {
    CHAR_INV_SLOTS          = 192, /* 46 uint32 */
    CHAR_PACK_SLOTS         = 238, /* 32 uint32 */
    CHAR_BANK_SLOTS         = 270, /* 48 uint32 */
    CHAR_BANKBAG_SLOTS      = 318, /* 12 uint32 */

    CHAR_SELECTION          = 330, /* uint64 */
    
    CHAR_FARSIGHT           = 332, /* uint64 */ /* unk */

    CHAR_DUEL_ARBITER       = 334, /* uint64 */ /* unk */

    CHAR_NUM_INV_SLOTS      = 336, 
    
    CHAR_GUILD_ID           = 337,
    CHAR_GUILD_RANK         = 338,

    CHAR_FACE               = 339, /* skin, face, hairstyle, haircolor */
    
    CHAR_CURRENT_XP         = 340,
    CHAR_NEXTLEVEL_XP       = 341,

    CHAR_SKILLINFO          = 342, /* 192 uint32 */
    
    CHAR_FACIALHAIR         = 534,

    CHAR_QUESTLOG           = 535, /* 80 uint32 */
    
    CHAR_SKILLPOINTS        = 615,
    CHAR_TALENTPOINTS       = 616,

    CHAR_TRACK_CREATURES    = 617, /* unk */
    CHAR_TRACK_RESOURCES    = 618, /* unk */

    CHAR_CHAT_FILTERS       = 619, /* unk */

    CHAR_DUEL_TEAM          = 620,

    CHAR_BLOCK_PERCENTAGE   = 621, /* float32 */
    CHAR_DODGE_PERCENTAGE   = 622, /* float32 */
    CHAR_PARRY_PERCENTAGE   = 623, /* float32 */

    CHAR_BASE_MANA          = 624, /* ? */

    CHAR_GUILD_TIMESTAMP    = 625, /* unk */

    CHAR_EXPLORED_ZONES     = 626, /* 32 uint32 */
};

enum WeaponIDs {
    WEAPON_LEETSTAFF    = 0x0787,
    WEAPON_TRISTAFF     = 0x0B19,
    WEAPON_ALITA        = 0x1931,
};

/* ALL WRONG! */
enum LogoutStatus {
    LOGOUT_OK           = 0x01,
    LOGOUT_FAILURE      = 0x00,
    LOGOUT_CANCELLED    = 0x02,
};

enum CharCreationStatus {
    CREATE_OK           = 0x28,
    CREATE_NAMETAKEN    = 0x2B,
};

enum FriendStatus {
    FRIEND_LIST_FULL        = 0x01,
    FRIEND_ONLINE           = 0x02,
    FRIEND_OFFLINE          = 0x03,
    FRIEND_NOT_FOUND        = 0x04,
    FRIEND_REMOVED          = 0x05,
    FRIEND_ADDED_ONLINE     = 0x06,
    FRIEND_ADDED_OFFLINE    = 0x07,
    FRIEND_ALREADY          = 0x08,
    FRIEND_SELF             = 0x09,
    FRIEND_ENEMY            = 0x0A,
    FRIEND_IGNORE_FULL      = 0x0B,
    FRIEND_IGNORE_SELF      = 0x0C,
    FRIEND_IGNORE_NOT_FOUND = 0x0D,
    FRIEND_IGNORE_ALREADY   = 0x0E,
    FRIEND_IGNORE_ADDED     = 0x0F,
    FRIEND_IGNORE_REMOVED   = 0x10,
};

// It is boolean, tbh ;-) --daxxar
enum FriendListStatus {
    FRIENDLIST_OFFLINE      = 0x00,
    FRIENDLIST_ONLINE       = 0x01,
};

enum AuthenticationResponse {
    AUTH_SUCCESSFUL         = 0x0C,
    AUTH_FAILED             = 0x0D,
    AUTH_WRONGVERSION       = 0x14,
    AUTH_UNKNOWNUSER        = 0x15,
};

#endif
