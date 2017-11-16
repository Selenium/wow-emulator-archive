#include "ItemTemplate.h"

CItemTemplate::CItemTemplate(void):CWoWObject(OBJ_ITEMTEMPLATE)
{
	Clear();
}

CItemTemplate::~CItemTemplate(void)
{
	Delete();
}

unsigned long CItemTemplate::GetItemTemplateInfoData(char *buffer)
{
#define Add(datatype,data) *(datatype*)&buffer[c]=data;c+=sizeof(datatype);
#define AddString(data) strcpy(&buffer[c],data);c+=strlen(data)+1;
#define Skip(n) c+=n;
#define Fill(size,value) memset(&buffer[c],value,size);c+=size;
	int c=0;
	Add(unsigned long,guid);
	Add(unsigned long,Data.Type);
	Add(unsigned long,Data.Subtype);	
	AddString(Data.Name);
	AddString(Data.Name1);
	AddString(Data.Name2);
	AddString(Data.Name3);

	memcpy(&buffer[c], &Data.DisplayID, 25*4 + sizeof(ItemAttribute)*10 + sizeof(DamageStat)*5 + sizeof(SpellStat)*5);
	c += 25*4 + sizeof(ItemAttribute)*10 + sizeof(DamageStat)*5 + sizeof(SpellStat)*5;
	AddString(Data.Text);
	memcpy(&buffer[c], &Data.PageText, 8*4);
	c += 8*4;
	return c;
#undef Fill
#undef Skip
#undef Add
#undef AddString
}

void CItemTemplate::Clear()
{
	CWoWObject::Clear();
	memset(&Data,0,sizeof(ItemTemplateData));
}

void CItemTemplate::New()
{
	Clear();
	CWoWObject::New();
	Data.BuyPrice = 1;
	Data.SellPrice = 1;
	Data.AllowableClass = 0x7FFF;
	Data.AllowableRace = 0x1FF;
	Data.Level = 1;
	Data.LevelReq = 1;
	Data.MaxStack = 1;
}

// hp
#define ITEMDISPLAYID_TOUGH_JERKY 2473
#define ITEMDISPLAYID_TOUGH_HUNK_OF_BREAD 6399
#define ITEMDISPLAYID_DARNASSIAN_BLEU 6353
#define ITEMDISPLAYID_FOREST_MUSHROOM_CAP 6380
#define ITEMDISPLAYID_SHINY_RED_APPLE 6410
// mana
#define ITEMDISPLAYID_REFRESHING_SPRING_WATER 6366
void CItemTemplate::CreateFood(char *Name, unsigned long DisplayID, unsigned long Level, bool Mana)
{
	strncpy(Data.Name, Name, 63);
	Data.Name[63] = 0;
	Data.Type = ITEMTYPE_CONSUMABLE;
	Data.Subtype = 0;
	Data.InvType = WORN_NONE;
	Data.DisplayID = DisplayID;
	Data.BuyPrice = 25;
	Data.SellPrice = 1;
	Data.Level = Level;
	Data.OverallQuality = 1;
	Data.MaxStack = 20;
	Data.Material = -1;

	if(!Mana)
	{
		if(Level == 5)
		{
			Data.SpellStats[0].ID = 0x1B1;
			Data.SpellStats[0].Trigger = 0;
			Data.SpellStats[0].Charges = -1;
			Data.SpellStats[0].Cooldown = 0;
			Data.SpellStats[0].Category = 0x0B;
			Data.SpellStats[0].CategoryCoolDown = 0x3E8;
		}
	}
	else
	{
		if(Level == 5)
		{
			Data.SpellStats[0].ID = 0x1AE;
			Data.SpellStats[0].Trigger = 0;
			Data.SpellStats[0].Charges = -1;
			Data.SpellStats[0].Cooldown = 0;
			Data.SpellStats[0].Category = 0x0B;
			Data.SpellStats[0].CategoryCoolDown = 0x3E8;
		}
	}
}

#define ITEMDISPLAYID_WORN_SHORTSWORD 1542
void CItemTemplate::CreateOneHandSword(char *Name, unsigned long DisplayID)
{
	strncpy(Data.Name, Name, 63);
	Data.Name[63] = 0;
	Data.Type = ITEMTYPE_WEAPON;
	Data.Subtype = WEAPONSUBTYPE_ONEHANDSWORD;
	Data.DisplayID = DisplayID;
	Data.OverallQuality = 1;
	Data.BuyPrice = 0x23;
	Data.SellPrice = 7;
	Data.InvType = WORN_MAINHAND;
	Data.Level = 2;
	Data.LevelReq = 1;
	Data.DamageStats[0].Min = 6;
	Data.DamageStats[0].Max = 10;
	Data.WeaponSpeed = 1900;
	Data.LanguageID = 1;
	Data.Material = 1;
	Data.SheatheType = SHEATHETYPE_LARGEWEAPONLEFT;
}

#define ITEMDISPLAYID_WORN_WOODEN_SHIELD 2158
void CItemTemplate::CreateShield(char *Name, unsigned long DisplayID)
{
	strncpy(Data.Name, Name, 63);
	Data.Name[63] = 0;
	Data.Type = ITEMTYPE_ARMOUR;
	Data.Subtype = ARMOURSUBTYPE_SHIELD;
	Data.DisplayID = DisplayID;
	Data.OverallQuality = 1;
	Data.InvType = WORN_SHIELD;
	Data.Level = 1;
	Data.LevelReq = 1;
	Data.ResistPhysical = 1;
	Data.Material = 1;
	Data.SheatheType = SHEATHETYPE_LARGEWEAPONRIGHT;
}

void CItemTemplate::CreateShirt(char *Name, unsigned long DisplayID)
{
	strncpy(Data.Name, Name, 63);
	Data.Name[63] = 0;
	Data.Type = ITEMTYPE_ARMOUR;
	Data.Subtype = ARMOURSUBTYPE_CLOTH;
	Data.DisplayID = DisplayID;
	Data.OverallQuality = 1;
	Data.InvType = WORN_SHIRT;
	Data.Level = 1;
	Data.LevelReq = 1;
	Data.ResistPhysical = 1;
	Data.Material = 7;
}

void CItemTemplate::CreateVest(char *Name, unsigned long DisplayID)
{
	strncpy(Data.Name, Name, 63);
	Data.Name[63] = 0;
	Data.Type = ITEMTYPE_ARMOUR;
	Data.Subtype = ARMOURSUBTYPE_CLOTH;
	Data.DisplayID = DisplayID;
	Data.OverallQuality = 1;
	Data.InvType = WORN_CHEST;
	Data.Level = 1;
	Data.LevelReq = 1;
	Data.ResistPhysical = 1;
	Data.Material = 7;
}

void CItemTemplate::CreatePants(char *Name, unsigned long DisplayID)
{
	strncpy(Data.Name, Name, 63);
	Data.Name[63] = 0;
	Data.Type = ITEMTYPE_ARMOUR;
	Data.Subtype = ARMOURSUBTYPE_CLOTH;
	Data.DisplayID = DisplayID;
	Data.OverallQuality = 1;
	Data.InvType = WORN_PANTS;
	Data.Level = 1;
	Data.LevelReq = 1;
	Data.ResistPhysical = 1;
	Data.Material = 7;
}

void CItemTemplate::CreateBoots(char *Name, unsigned long DisplayID)
{
	strncpy(Data.Name, Name, 63);
	Data.Name[63] = 0;
	Data.Type = ITEMTYPE_ARMOUR;
	Data.Subtype = ARMOURSUBTYPE_CLOTH;
	Data.DisplayID = DisplayID;
	Data.OverallQuality = 1;
	Data.InvType = WORN_BOOTS;
	Data.Level = 1;
	Data.LevelReq = 1;
	Data.ResistPhysical = 1;
	Data.Material = 7;
}

void CItemTemplate::CreateTwoHandBlunt(char *Name, unsigned long DisplayID)
{
	strncpy(Data.Name, Name, 63);
	Data.Name[63] = 0;
	Data.Type = ITEMTYPE_WEAPON;
	Data.Subtype = WEAPONSUBTYPE_TWOHANDBLUNT;
	Data.DisplayID = DisplayID;
	Data.OverallQuality = 1;
	Data.BuyPrice = 0x2D;
	Data.SellPrice = 9;
	Data.InvType = WORN_2H;
	Data.Level = 2;
	Data.LevelReq = 1;
	Data.DamageStats[0].Min = 11;
	Data.DamageStats[0].Max = 16;
	Data.WeaponSpeed = 2900;
	Data.LanguageID = 1;
	Data.Material = 2;
	Data.SheatheType = SHEATHETYPE_MAINHAND;
}

void CItemTemplate::CreateDagger(char *Name, unsigned long DisplayID)
{
	strncpy(Data.Name, Name, 63);
	Data.Name[63] = 0;
	Data.Type = ITEMTYPE_WEAPON;
	Data.Subtype = WEAPONSUBTYPE_DAGGER;
	Data.DisplayID = DisplayID;
	Data.OverallQuality = 1;
	Data.BuyPrice = 35;
	Data.SellPrice = 7;
	Data.InvType = WORN_1H;
	Data.Level = 2;
	Data.LevelReq = 1;
	Data.DamageStats[0].Min = 5;
	Data.DamageStats[0].Max = 8;
	Data.WeaponSpeed = 1600;
	Data.LanguageID = 1;
	Data.Material = 1;
	Data.SheatheType = SHEATHETYPE_LARGEWEAPONLEFT;
}

void CItemTemplate::CreateOneHandBlunt(char *Name, unsigned long DisplayID)
{
	strncpy(Data.Name, Name, 63);
	Data.Name[63] = 0;
	Data.Type = ITEMTYPE_WEAPON;
	Data.Subtype = WEAPONSUBTYPE_ONEHANDBLUNT;
	Data.DisplayID = DisplayID;
	Data.OverallQuality = 1;
	Data.BuyPrice = 38;
	Data.SellPrice = 7;
	Data.InvType = WORN_MAINHAND;
	Data.Level = 2;
	Data.LevelReq = 1;
	Data.DamageStats[0].Min = 6;
	Data.DamageStats[0].Max = 10;
	Data.WeaponSpeed = 1900;
	Data.LanguageID = 1;
	Data.Material = 1;
	Data.SheatheType = SHEATHETYPE_LARGEWEAPONLEFT;
}

void CItemTemplate::CreateRobe(char *Name, unsigned long DisplayID)
{
	strncpy(Data.Name, Name, 63);
	Data.Name[63] = 0;
	Data.Type = ITEMTYPE_ARMOUR;
	Data.Subtype = ARMOURSUBTYPE_CLOTH;
	Data.DisplayID = DisplayID;
	Data.OverallQuality = 1;
	Data.InvType = WORN_ROBE;
	Data.Level = 1;
	Data.LevelReq = 1;
	Data.ResistPhysical = 1;
	Data.Material = 7;
}

void CItemTemplate::CreateStaff(char *Name, unsigned long DisplayID)
{
	strncpy(Data.Name, Name, 63);
	Data.Name[63] = 0;
	Data.Type = ITEMTYPE_WEAPON;
	Data.Subtype = WEAPONSUBTYPE_STAFF;
	Data.DisplayID = DisplayID;
	Data.OverallQuality = 1;
	Data.BuyPrice = 47;
	Data.SellPrice = 9;
	Data.InvType = WORN_2H;
	Data.Level = 2;
	Data.LevelReq = 1;
	Data.DamageStats[0].Min = 11;
	Data.DamageStats[0].Max = 16;
	Data.WeaponSpeed = 1900;
	Data.Material = 2;
	Data.SheatheType = SHEATHETYPE_OFFHAND;
}

void CItemTemplate::CreateOneHandAxe(char *Name, unsigned long DisplayID)
{
	strncpy(Data.Name, Name, 63);
	Data.Name[63] = 0;
	Data.Type = ITEMTYPE_WEAPON;
	Data.Subtype = WEAPONSUBTYPE_ONEHANDAXE;
	Data.DisplayID = DisplayID;
	Data.OverallQuality = 1;
	Data.BuyPrice = 35;
	Data.SellPrice = 7;
	Data.InvType = WORN_MAINHAND;
	Data.Level = 2;
	Data.LevelReq = 1;
	Data.DamageStats[0].Min = 6;
	Data.DamageStats[0].Max = 10;
	Data.WeaponSpeed = 1900;
	Data.Material = 1;
	Data.SheatheType = SHEATHETYPE_LARGEWEAPONLEFT;
}

void CItemTemplate::CreateBuckler(char *Name, unsigned long DisplayID)
{
	CreateShield(Name, DisplayID);
	Data.Subtype = ARMOURSUBTYPE_BUCKLER;
}

void CItemTemplate::CreateAmmoPouch(char *Name, unsigned long DisplayID)
{
	strncpy(Data.Name, Name, 63);
	Data.Name[63] = 0;
	Data.Type = ITEMTYPE_QUIVER;
	Data.Subtype = QUIVERSUBTYPE_AMMO;
	Data.DisplayID = DisplayID;
	Data.OverallQuality = 1;
	Data.InvType = WORN_BAG;
	Data.Level = 1;
	Data.LevelReq = 1;
	Data.ContainerSlots = 4;
	Data.Material = -1;
}

void CItemTemplate::CreateArrowQuiver(char *Name, unsigned long DisplayID)
{
	strncpy(Data.Name, Name, 63);
	Data.Name[63] = 0;
	Data.Type = ITEMTYPE_QUIVER;
	Data.Subtype = QUIVERSUBTYPE_ARROW;
	Data.DisplayID = DisplayID;
	Data.OverallQuality = 1;
	Data.InvType = WORN_BAG;
	Data.Level = 1;
	Data.LevelReq = 1;
	Data.ContainerSlots = 4;
	Data.Material = -1;
}

void CItemTemplate::CreateBullet(char *Name, unsigned long DisplayID)
{
	strncpy(Data.Name, Name, 63);
	Data.Name[63] = 0;
	Data.Type = ITEMTYPE_PROJECTILE;
	Data.Subtype = PROJECTILESUBTYPE_BULLET;
	Data.DisplayID = DisplayID;
	Data.OverallQuality = 1;
	Data.InvType = WORN_AMMO;
	Data.Level = 1;
	Data.LevelReq = 1;
	Data.MaxStack = 100;
	Data.Material = -1;
}

void CItemTemplate::CreateArrow(char *Name, unsigned long DisplayID)
{
	strncpy(Data.Name, Name, 63);
	Data.Name[63] = 0;
	Data.Type = ITEMTYPE_PROJECTILE;
	Data.Subtype = PROJECTILESUBTYPE_ARROW;
	Data.DisplayID = DisplayID;
	Data.OverallQuality = 1;
	Data.InvType = WORN_AMMO;
	Data.Level = 1;
	Data.LevelReq = 1;
	Data.MaxStack = 100;
	Data.Material = -1;
}

void CItemTemplate::CreateGun(char *Name, unsigned long DisplayID)
{
	strncpy(Data.Name, Name, 63);
	Data.Name[63] = 0;
	Data.Type = ITEMTYPE_WEAPON;
	Data.Subtype = WEAPONSUBTYPE_GUN;
	Data.DisplayID = DisplayID;
	Data.OverallQuality = 1;
	Data.BuyPrice = 35;
	Data.SellPrice = 7;
	Data.InvType = WORN_RANGEDRIGHT;
	Data.Level = 2;
	Data.LevelReq = 1;
	Data.DamageStats[0].Min = 4;
	Data.DamageStats[0].Max = 7;
	Data.WeaponSpeed = 2300;
	Data.AmmoType = PROJECTILESUBTYPE_BULLET;
	Data.Material = 2;
}

void CItemTemplate::CreateBow(char *Name, unsigned long DisplayID)
{
	strncpy(Data.Name, Name, 63);
	Data.Name[63] = 0;
	Data.Type = ITEMTYPE_WEAPON;
	Data.Subtype = WEAPONSUBTYPE_BOW;
	Data.DisplayID = DisplayID;
	Data.OverallQuality = 1;
	Data.BuyPrice = 35;
	Data.SellPrice = 7;
	Data.InvType = WORN_RANGED;
	Data.Level = 2;
	Data.LevelReq = 1;
	Data.DamageStats[0].Min = 4;
	Data.DamageStats[0].Max = 7;
	Data.WeaponSpeed = 2300;
	Data.AmmoType = PROJECTILESUBTYPE_ARROW;
	Data.Material = 2;
}

void CItemTemplate::CreateTabard(char *Name, unsigned long DisplayID)
{
	strncpy(Data.Name, Name, 63);
	Data.Name[63] = 0;
	Data.Type = ITEMTYPE_ARMOUR;
	Data.Subtype = ARMOURSUBTYPE_GENERIC;
	Data.DisplayID = DisplayID;
	Data.OverallQuality = 1;
	Data.InvType = WORN_TABARD;
	Data.Material = -1;
}

void CItemTemplate::CreateInvItem(char *Name, unsigned long DisplayID)
{
	strncpy(Data.Name, Name, 63);
	Data.Name[63] = 0;
	Data.Type = ITEMTYPE_CONSUMABLE;
	Data.Subtype = 0;
	Data.InvType = WORN_NONE;
	Data.DisplayID = DisplayID;
	Data.BuyPrice = 1;
	Data.SellPrice = 1;
	Data.OverallQuality = 1;
	Data.Material = -1;
}

void CItemTemplate::CreateCloak(char *Name, unsigned long DisplayID)
{
	strncpy(Data.Name, Name, 63);
	Data.Name[63] = 0;
	Data.Type = ITEMTYPE_ARMOUR;
	Data.Subtype = ARMOURSUBTYPE_CLOTH;
	Data.DisplayID = DisplayID;
	Data.OverallQuality = 1;
	Data.InvType = WORN_BACK;
	Data.Material = -1;
}


unsigned long STATICITEMS::WARRIOR_SHIRT;
unsigned long STATICITEMS::WARRIOR_PANTS;
unsigned long STATICITEMS::WARRIOR_BOOTS;
unsigned long STATICITEMS::NE_WARRIOR_SHIRT;
unsigned long STATICITEMS::NE_WARRIOR_PANTS;
unsigned long STATICITEMS::NE_WARRIOR_BOOTS;
unsigned long STATICITEMS::EVIL_WARRIOR_SHIRT;
unsigned long STATICITEMS::EVIL_WARRIOR_PANTS;
unsigned long STATICITEMS::EVIL_WARRIOR_BOOTS;
unsigned long STATICITEMS::WARRIOR_SHORTSWORD;
unsigned long STATICITEMS::WARRIOR_SHIELD;
unsigned long STATICITEMS::PALADIN_BOOTS;
unsigned long STATICITEMS::PALADIN_HAMMER;
unsigned long STATICITEMS::HUMAN_PALADIN_SHIRT;
unsigned long STATICITEMS::HUMAN_PALADIN_PANTS;
unsigned long STATICITEMS::DWARF_PALADIN_SHIRT;
unsigned long STATICITEMS::DWARF_PALADIN_PANTS;
unsigned long STATICITEMS::ROGUE_DAGGER;
unsigned long STATICITEMS::GOOD_ROGUE_BOOTS;
unsigned long STATICITEMS::GOOD_ROGUE_SHIRT;
unsigned long STATICITEMS::GOOD_ROGUE_PANTS;
unsigned long STATICITEMS::EVIL_ROGUE_BOOTS;
unsigned long STATICITEMS::EVIL_ROGUE_CHEST;
unsigned long STATICITEMS::EVIL_ROGUE_PANTS;
unsigned long STATICITEMS::TROLL_ROGUE_BOOTS;
unsigned long STATICITEMS::TROLL_ROGUE_CHEST;
unsigned long STATICITEMS::TROLL_ROGUE_PANTS;
unsigned long STATICITEMS::PRIEST_SHIRT;
unsigned long STATICITEMS::PRIEST_PANTS;
unsigned long STATICITEMS::PRIEST_BOOTS;
unsigned long STATICITEMS::PRIEST_MACE;
unsigned long STATICITEMS::HUMAN_DWARF_PRIEST_ROBE;
unsigned long STATICITEMS::NIGHTELF_PRIEST_ROBE;
unsigned long STATICITEMS::UNDEAD_TROLL_PRIEST_ROBE;
unsigned long STATICITEMS::MAGE_SHIRT;
unsigned long STATICITEMS::MAGE_PANTS;
unsigned long STATICITEMS::MAGE_BOOTS;
unsigned long STATICITEMS::MAGE_STAFF;
unsigned long STATICITEMS::HUMAN_GNOME_MAGE_ROBE;
unsigned long STATICITEMS::DWARF_MAGE_ROBE;
unsigned long STATICITEMS::UNDEAD_TROLL_MAGE_ROBE;
unsigned long STATICITEMS::WARLOCK_PANTS;
unsigned long STATICITEMS::WARLOCK_BOOTS;
unsigned long STATICITEMS::WARLOCK_DAGGER;
unsigned long STATICITEMS::HUMAN_GNOME_WARLOCK_SHIRT;
unsigned long STATICITEMS::HUMAN_GNOME_WARLOCK_ROBE;
unsigned long STATICITEMS::ORC_UNDEAD_WARLOCK_ROBE;
unsigned long STATICITEMS::SHAMAN_MACE;
unsigned long STATICITEMS::ORC_TAUREN_SHAMAN_SHIRT;
unsigned long STATICITEMS::ORC_TAUREN_SHAMAN_PANTS;
unsigned long STATICITEMS::TROLL_SHAMAN_SHIRT;
unsigned long STATICITEMS::TROLL_SHAMAN_PANTS;
unsigned long STATICITEMS::DRUID_PANTS;
unsigned long STATICITEMS::NIGHTELF_DRUID_ROBE;
unsigned long STATICITEMS::NIGHTELF_DRUID_STAFF;
unsigned long STATICITEMS::TAUREN_DRUID_ROBE;
unsigned long STATICITEMS::TAUREN_DRUID_STAFF;
unsigned long STATICITEMS::HUNTER_AXE;
unsigned long STATICITEMS::HUNTER_SHIELD;
unsigned long STATICITEMS::DWARF_NIGHTELF_HUNTER_SHIRT;
unsigned long STATICITEMS::DWARF_NIGHTELF_HUNTER_PANTS;
unsigned long STATICITEMS::DWARF_NIGHTELF_HUNTER_BOOTS;
unsigned long STATICITEMS::ORC_TAUREN_HUNTER_SHIRT;
unsigned long STATICITEMS::ORC_TAUREN_HUNTER_PANTS;
unsigned long STATICITEMS::ORC_HUNTER_BOOTS;
unsigned long STATICITEMS::TROLL_HUNTER_SHIRT;
unsigned long STATICITEMS::TROLL_HUNTER_PANTS;
unsigned long STATICITEMS::HUNTER_AMMO_POUCH;
unsigned long STATICITEMS::HUNTER_RIFLE;
unsigned long STATICITEMS::HUNTER_BULLET;
unsigned long STATICITEMS::HUNTER_QUIVER;
unsigned long STATICITEMS::HUNTER_BOW;
unsigned long STATICITEMS::HUNTER_ARROW;
unsigned long STATICITEMS::GUILD_TABARD;
unsigned long STATICITEMS::REFRESHING_SPRING_WATER;
unsigned long STATICITEMS::TOUGH_JERKY;
unsigned long STATICITEMS::TOUGH_HUNK_OF_BREAD;
unsigned long STATICITEMS::DARNASSIAN_BLEU;
unsigned long STATICITEMS::FOREST_MUSHROOM_CAP;
unsigned long STATICITEMS::SHINY_RED_APPLE;
unsigned long STATICITEMS::FLYPATH_ITEM1;
unsigned long STATICITEMS::FLYPATH_ITEM2;
unsigned long STATICITEMS::FLYPATH_ITEM3;
unsigned long STATICITEMS::ITEMWDB_FIRST;
unsigned long STATICITEMS::ITEMWDB_COUNT;