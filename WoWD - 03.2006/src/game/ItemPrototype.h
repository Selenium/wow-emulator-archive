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

#ifndef _ITEMPROTOTYPE_H
#define _ITEMPROTOTYPE_H


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
/*
	ITEM_NO_ERROR = 0,
	CANT_EQUIP_LEVEL_I         = 0x1,  // need more level
	CANT_EQUIP_SKILL           = 0x2,
	WRONG_SLOT                 = 0x3,  // that item do not go that slot
	BAG_FULL                   = 0x4,  
	BAG_IN_BAG                 = 0x5,  // bag not empty
	AMMO_ONLY                  = 0x6,  
	PROFICIENCY_NEEDED         = 0x7,
	NOT_EQUIPPABLE             = 0x8,
	NEVER                      = 0x9,
	NEVER2                     = 0xA,
	WRONG_EQ_SLOT              = 0xb,
	TWOHAND                    = 0xc,
	DULEWIELD                  = 0xd,
	WRONG_SLOT2                = 0xe,
	WRONG_SLOT3                = 0xf,
	ITEM_TOO_MANY              = 0x10,
	NOT_A_BAG                  = 0x1d,
};*/


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
    INVTYPE_BODY           = 0x4,
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
    INVTYPE_2HWEAPON       = 0x11,
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
    uint32 RequiredSkillSubRank;
    uint32 RequiredPlayerRank1;
    uint32 RequiredPlayerRank2;
    uint32 RequiredFaction;
	uint32 RequiredFactionStanding;
	uint32 Unique;
    uint32 MaxCount;
    uint32 ContainerSlots;
    uint32 ItemStatType[10];
    uint32 ItemStatValue[10];
    float DamageMin[5];
    float DamageMax[5];
    uint32 DamageType[5];
    uint32 Armor;
    uint32 Field62;
    uint32 FireRes;
    uint32 NatureRes;
    uint32 FrostRes;
    uint32 ShadowRes;
    uint32 ArcaneRes;
    uint32 Delay;
    uint32 Field69;
    uint32 SpellId[5];
    uint32 SpellTrigger[5];
    uint32 SpellCharges[5];
    uint32 SpellCooldown[5];
    uint32 SpellCategory[5];
    uint32 SpellCategoryCooldown[5];
    uint32 Bonding;
    std::string Description;
    uint32 Field102;
    uint32 Field103;
    uint32 Field104;
    uint32 Field105;
    uint32 Field106;
    uint32 Field107;
    uint32 Field108;
    uint32 Field109;
    uint32 Block;
    uint32 Field111;
    uint32 MaxDurability;
	uint32 ZoneNameID;
	uint32 Field114;
};

#endif
