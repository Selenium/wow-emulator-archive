// Copyright (C) 2004 WoWD Team

#ifndef _ITEMPROTOTYPE_H
#define _ITEMPROTOTYPE_H

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
    USE           = 0,
    ON_EQUIP      = 1,
    CHANCE_ON_HIT = 2,
    SOULSTONE     = 4,
};

enum ITEM_BONDING_TYPE
{
    NO_BIND             = 0,
    BIND_WHEN_PICKED_UP = 1,
    BIND_WHEN_EQUIPED   = 2,
};

enum INVENTORY_TYPES
{
    INVTYPE_NON_EQUIP      = 0x0,
    INVTYPE_HEAD           = 0x1,
    INVTYPE_NECK           = 0x2,
    INVTYPE_SHOULDERS      = 0x3,
    INVTYPE_BODY           = 0x4,	// cloth robes only
    INVTYPE_CHEST          = 0x5,
    INVTYPE_WAIST          = 0x6,
    INVTYPE_LEGS           = 0x7,
    INVTYPE_FEET           = 0x8,
    INVTYPE_WRISTS         = 0x9,
    INVTYPE_HANDS          = 0xa,
    INVTYPE_FINGER         = 0xb,
    INVTYPE_TRINKET        = 0xc,
    INVTYPE_WEAPON         = 0xd,
    INVTYPE_SHIELD         = 0xe,
    INVTYPE_RANGED         = 0xf,
    INVTYPE_CLOAK          = 0x10,
    INVTYPE_TWOHAND_WEAPON = 0x11,
    INVTYPE_BAG            = 0x12,
    INVTYPE_TABARD         = 0x13,
    INVTYPE_ROBE           = 0x14,
    INVTYPE_WEAPONMAINHAND = 0x15,
    INVTYPE_WEAPONOFFHAND  = 0x16,
    INVTYPE_HOLDABLE       = 0x17,
    INVTYPE_AMMO           = 0x18,
    INVTYPE_THROWN         = 0x19,
    INVTYPE_RANGEDRIGHT    = 0x1a,
    NUM_INVENTORY_TYPES    = 0x1b,
};

enum SHEATHE_TYPE
{
	SHEATHETYPE_NONE					= 0,
	SHEATHETYPE_MAINHAND				= 1,
	SHEATHETYPE_OFFHAND					= 2,
	SHEATHETYPE_LARGEWEAPONLEFT			= 3,
	SHEATHETYPE_LARGEWEAPONRIGHT		= 4,
	SHEATHETYPE_HIPWEAPONLEFT			= 5,
	SHEATHETYPE_HIPWEAPONRIGHT			= 6,
	SHEATHETYPE_SHIELD					= 7,
};

enum ITEM_CLASS
{
	ITEM_CLASS_CONSUMABLE	= 0,
    ITEM_CLASS_CONTAINER	= 1,
	ITEM_CLASS_WEAPON		= 2,
	ITEM_CLASS_ARMOR		= 4,
	ITEM_CLASS_REAGENT		= 5,
	ITEM_CLASS_PROJECTILE	= 6,
	ITEM_CLASS_TRADE_GOODS	= 7,
	ITEM_CLASS_RECIPE		= 9,
	ITEM_CLASS_QUIVER		= 11,
	ITEM_CLASS_QUEST		= 12,
	ITEM_CLASS_KEY			= 13,
	ITEM_CLASS_MISC			= 15,
};

enum ITEM_SUBCLASS
{
	// Weapon
	ITEM_SUBCLASS_AXE			= 0,
	ITEM_SUBCLASS_TWOHAND_AXE	= 1,
	ITEM_SUBCLASS_BOW			= 2,
	ITEM_SUBCLASS_GUN			= 3,
	ITEM_SUBCLASS_MACE			= 4,
	ITEM_SUBCLASS_TWOHAND_MACE	= 5,
	ITEM_SUBCLASS_POLEARM		= 6,
	ITEM_SUBCLASS_SWORD			= 7,
	ITEM_SUBCLASS_TWOHAND_SWORD = 8,
	ITEM_SUBCLASS_STAFF			= 10,
	ITEM_SUBCLASS_FIST_WEAPON	= 13,
	ITEM_SUBCLASS_MISC_WEAPON	= 14,
	ITEM_SUBCLASS_DAGGER		= 15,
	ITEM_SUBCLASS_THROWN		= 16,
	ITEM_SUBCLASS_CROSSBOW		= 18,
	ITEM_SUBCLASS_WAND			= 19,
	ITEM_SUBCLASS_FISHING_POLE	= 20,
	
	// Armor
	ITEM_SUBCLASS_MISC			= 0,
	ITEM_SUBCLASS_CLOTH			= 1,
	ITEM_SUBCLASS_LEATHER		= 2,
	ITEM_SUBCLASS_MAIL			= 3,
	ITEM_SUBCLASS_PLATE_MAIL	= 4,
	ITEM_SUBCLASS_SHIELD		= 6,

	// Projectile
	ITEM_SUBCLASS_ARROW			= 2,
	ITEM_SUBCLASS_BULLET		= 3,
	
	// Trade goods
	ITEM_SUBCLASS_TRADE_GOODS	= 0,
	ITEM_SUBCLASS_PARTS			= 1,
	ITEM_SUBCLASS_EXPLOSIVES	= 2,
	ITEM_SUBCLASS_DEVICES		= 3,
	
	// Recipe
	ITEM_SUBCLASS_BOOK				= 0,
	ITEM_SUBCLASS_LEATHERWORKING	= 1,
	ITEM_SUBCLASS_TAILORING			= 2,
	ITEM_SUBCLASS_ENGINEERING		= 3,
	ITEM_SUBCLASS_BLACKSMITHING		= 4,
	ITEM_SUBCLASS_COOKING			= 5,
	ITEM_SUBCLASS_ALCHEMY			= 6,
	ITEM_SUBCLASS_FIRST_AID			= 7,
	ITEM_SUBCLASS_ENCHANTING		= 8,
	ITEM_SUBCLASS_FISNING			= 9,

	// Quiver
	ITEM_SUBCLASS_AMMO_POUCH		= 3,
	ITEM_SUBCLASS_QUIVER			= 2,

	// Misc
	ITEM_SUBCLASS_JUNK				= 0,
};

struct ItemPrototype
{
    uint32 ItemId;
    uint32 Class;
    uint32 SubClass;
    std::string Name1;
    std::string Name2;
    std::string Name3;
    std::string Name4;
    uint32 DisplayInfoID;
    uint32 Quality;
    uint32 Flags;
    uint32 BuyPrice;
    uint32 SellPrice;
    uint32 InventoryType;
    uint32 AllowableClass;
    uint32 AllowableRace;
    uint32 ItemLevel;
    uint32 RequiredLevel;
    uint32 RequiredSkill;
    uint32 RequiredSkillRank;
    uint32 RequiredSpell;
    uint32 RequiredFaction;
    uint32 RequiredFactionLvL;
    uint32 RequiredPVPRank;
	uint32 FieldNew_17_1;
	uint32 FieldNew_17_2;
    uint32 MaxCount;
    uint32 ContainerSlots;
    uint32 ItemStatType[10];
    int32 ItemStatValue[10];
    float  DamageMin[5];
    float  DamageMax[5];
    uint32 DamageType[5];
    uint32 Armor;
    uint32 HolyRes;
    uint32 FireRes;
    uint32 NatureRes;
    uint32 FrostRes;
    uint32 ShadowRes;
    uint32 ArcaneRes;
    uint32 Delay;
    uint32 Block;
    uint32 SpellId[5];
    uint32 SpellTrigger[5];
    uint32 SpellCharges[5];
    uint32 SpellCooldown[5];
    uint32 SpellCategory[5];
    uint32 SpellCategoryCooldown[5];
    uint32 Bonding;
    std::string Description;
    uint32 RandPropID;
    uint32 PageTextID;
    uint32 PageLanguage;
    uint32 PageMaterial;
    uint32 LockId;
    uint32 LockMaterial;
    uint32 Field108;
    uint32 Field109;
    uint32 Field110;
    uint32 Field111;
    uint32 MaxDurability;
    uint32 StartQuest;
    uint32 isCrafted;
    uint32 isQuested; 
    uint32 isRaid;
    uint32 isStatic; 
    uint32 isVendor;
    uint32 isWorld;
    uint32 common_Mob;
    uint32 common_Percent;
    uint32 Total_Percent;
	uint32 Sheath;


	void Describe (char *buff) {
		sprintf (buff, "<ItemTemplate Id=%d \"%s\">", ItemId, Name1.c_str());
	}

	uint32 GetSellStackSize() {
		uint32 sellStackSize = MaxCount;

		if (sellStackSize == 5) sellStackSize = 1;
		else if (sellStackSize == 20) sellStackSize = 5;

		return sellStackSize;
	}
};

#endif
