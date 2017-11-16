#pragma once
#include "stdafx.h"
#include "WoWObject.h"

struct ItemAttribute
{
	unsigned long ID;
	unsigned long Value;
};

struct DamageStat
{
	int Min;
	int Max;
	int Type;
};

struct SpellStat
{
	int ID;
	int Trigger;
	int Charges;
	int Cooldown;
	int Category;
	int CategoryCoolDown;
};

struct ItemTemplateData
{
	char CodeName[64];// internal use only

	unsigned long Type;
	unsigned long Subtype;
	char Name[64];
	char Name1[64];
	char Name2[64];
	char Name3[64];
	unsigned long DisplayID;
	unsigned long OverallQuality;
	unsigned long Flags;
	unsigned long BuyPrice;// Player buys
	unsigned long SellPrice;// Player sells
	unsigned long InvType;
	unsigned long AllowableClass;
	unsigned long AllowableRace;
	unsigned long Level;
	unsigned long LevelReq;
	unsigned long SkillReq;
	unsigned long MinSkillReq;
	unsigned long ItemUnique;
	unsigned long MaxStack;
	unsigned long ContainerSlots;
	ItemAttribute Attributes[10];
	DamageStat DamageStats[5];
	unsigned long ResistPhysical;
	unsigned long ResistHoly;
	unsigned long ResistFire;
	unsigned long ResistNature;
	unsigned long ResistFrost;
	unsigned long ResistShadow;
	unsigned long WeaponSpeed;
	unsigned long AmmoType;
	unsigned long MaxDurability;
	SpellStat SpellStats[5];
	unsigned long Bonding;
	char Text[128];
	unsigned long PageText;
	unsigned long LanguageID;
	unsigned long PageMaterial;
	unsigned long StartQuest;
	unsigned long Lock;
	unsigned long Material;
	unsigned long SheatheType;
	unsigned long Unknown;
};

class CItemTemplate : public CWoWObject
{
public:
	CItemTemplate(void);
	~CItemTemplate(void);

	ItemTemplateData Data;
	void Clear();
	void New();
	unsigned long GetItemTemplateInfoData(char *buffer);

	void CreateFood(char *Name, unsigned long DisplayID, unsigned long Level, bool Mana);
	void CreateOneHandSword(char *Name, unsigned long DisplayID);
	void CreateShield(char *Name, unsigned long DisplayID);
	void CreateShirt(char *Name, unsigned long DisplayID);
	void CreatePants(char *Name, unsigned long DisplayID);
	void CreateBoots(char *Name, unsigned long DisplayID);
	void CreateTwoHandBlunt(char *Name, unsigned long DisplayID);
	void CreateDagger(char *Name, unsigned long DisplayID);
	void CreateOneHandBlunt(char *Name, unsigned long DisplayID);
	void CreateRobe(char *Name, unsigned long DisplayID);
	void CreateStaff(char *Name, unsigned long DisplayID);
	void CreateOneHandAxe(char *Name, unsigned long DisplayID);
	void CreateBuckler(char *Name, unsigned long DisplayID);
	void CreateAmmoPouch(char *Name, unsigned long DisplayID);
	void CreateArrowQuiver(char *Name, unsigned long DisplayID);
	void CreateBullet(char *Name, unsigned long DisplayID);
	void CreateArrow(char *Name, unsigned long DisplayID);
	void CreateGun(char *Name, unsigned long DisplayID);
	void CreateBow(char *Name, unsigned long DisplayID);
	void CreateTabard(char *Name, unsigned long DisplayID);
	void CreateVest(char *Name, unsigned long DisplayID);
	void CreateInvItem(char *Name, unsigned long DisplayID);
	void CreateCloak(char *Name, unsigned long DisplayID);
};

class STATICITEMS
{
public:
	static unsigned long WARRIOR_SHIRT;
	static unsigned long WARRIOR_PANTS;
	static unsigned long WARRIOR_BOOTS;

	static unsigned long NE_WARRIOR_SHIRT;
	static unsigned long NE_WARRIOR_PANTS;
	static unsigned long NE_WARRIOR_BOOTS;

	static unsigned long EVIL_WARRIOR_SHIRT;
	static unsigned long EVIL_WARRIOR_PANTS;
	static unsigned long EVIL_WARRIOR_BOOTS;

	static unsigned long WARRIOR_SHORTSWORD;
	static unsigned long WARRIOR_SHIELD;
			

	static unsigned long PALADIN_BOOTS;
	static unsigned long PALADIN_HAMMER;
	static unsigned long HUMAN_PALADIN_SHIRT;
	static unsigned long HUMAN_PALADIN_PANTS;
	static unsigned long DWARF_PALADIN_SHIRT;
	static unsigned long DWARF_PALADIN_PANTS;

	static unsigned long ROGUE_DAGGER;
	static unsigned long GOOD_ROGUE_BOOTS;
	static unsigned long GOOD_ROGUE_SHIRT;
	static unsigned long GOOD_ROGUE_PANTS;
	static unsigned long EVIL_ROGUE_BOOTS;
	static unsigned long EVIL_ROGUE_CHEST;
	static unsigned long EVIL_ROGUE_PANTS;
	static unsigned long TROLL_ROGUE_BOOTS;
	static unsigned long TROLL_ROGUE_CHEST;
	static unsigned long TROLL_ROGUE_PANTS;


	static unsigned long PRIEST_SHIRT;
	static unsigned long PRIEST_PANTS;
	static unsigned long PRIEST_BOOTS;
	static unsigned long PRIEST_MACE;
	static unsigned long HUMAN_DWARF_PRIEST_ROBE;
	static unsigned long NIGHTELF_PRIEST_ROBE;
	static unsigned long UNDEAD_TROLL_PRIEST_ROBE;

	static unsigned long MAGE_SHIRT;
	static unsigned long MAGE_PANTS;
	static unsigned long MAGE_BOOTS;
	static unsigned long MAGE_STAFF;
	static unsigned long HUMAN_GNOME_MAGE_ROBE;
	static unsigned long DWARF_MAGE_ROBE;
	static unsigned long UNDEAD_TROLL_MAGE_ROBE;

	static unsigned long WARLOCK_PANTS;
	static unsigned long WARLOCK_BOOTS;
	static unsigned long WARLOCK_DAGGER;
	static unsigned long HUMAN_GNOME_WARLOCK_SHIRT;
	static unsigned long HUMAN_GNOME_WARLOCK_ROBE;
	static unsigned long ORC_UNDEAD_WARLOCK_ROBE;

	static unsigned long SHAMAN_MACE;
	static unsigned long ORC_TAUREN_SHAMAN_SHIRT;
	static unsigned long ORC_TAUREN_SHAMAN_PANTS;
	static unsigned long TROLL_SHAMAN_SHIRT;
	static unsigned long TROLL_SHAMAN_PANTS;

	static unsigned long DRUID_PANTS;
	static unsigned long NIGHTELF_DRUID_ROBE;
	static unsigned long NIGHTELF_DRUID_STAFF;
	static unsigned long TAUREN_DRUID_ROBE;
	static unsigned long TAUREN_DRUID_STAFF;

	static unsigned long HUNTER_AXE;
	static unsigned long HUNTER_SHIELD;
	static unsigned long DWARF_NIGHTELF_HUNTER_SHIRT;
	static unsigned long DWARF_NIGHTELF_HUNTER_PANTS;
	static unsigned long DWARF_NIGHTELF_HUNTER_BOOTS;
	static unsigned long ORC_TAUREN_HUNTER_SHIRT;
	static unsigned long ORC_TAUREN_HUNTER_PANTS;
	static unsigned long ORC_HUNTER_BOOTS;
	static unsigned long TROLL_HUNTER_SHIRT;
	static unsigned long TROLL_HUNTER_PANTS;
			
	static unsigned long HUNTER_AMMO_POUCH;
	static unsigned long HUNTER_RIFLE;
	static unsigned long HUNTER_BULLET;

	static unsigned long HUNTER_QUIVER;
	static unsigned long HUNTER_BOW;
	static unsigned long HUNTER_ARROW;

	static unsigned long GUILD_TABARD;
	static unsigned long FLYPATH_ITEM1;
	static unsigned long FLYPATH_ITEM2;
	static unsigned long FLYPATH_ITEM3;
	// FOOD
	// MANA
	static unsigned long REFRESHING_SPRING_WATER;
	// HEALTH
	static unsigned long TOUGH_JERKY;
	static unsigned long TOUGH_HUNK_OF_BREAD;
	static unsigned long DARNASSIAN_BLEU;
	static unsigned long FOREST_MUSHROOM_CAP;
	static unsigned long SHINY_RED_APPLE;

	static unsigned long ITEMWDB_FIRST;
	static unsigned long ITEMWDB_COUNT;
};
