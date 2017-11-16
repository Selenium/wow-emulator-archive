#include "ItemTemplate.h"
#include "Client.h"

CItemTemplate::CItemTemplate(void):CWoWObject(OBJ_ITEMTEMPLATE)
{
	Clear();
}

CItemTemplate::~CItemTemplate(void)
{
	Delete();
}

void CItemTemplate::SendTemplate(CClient *pClient)
{
	int i;

	CPacket pkg(SMSG_ITEM_QUERY_SINGLE_RESPONSE, sizeof(ItemTemplateData) + 12);

	pkg << guid;

	pkg << Data.Class;
	pkg << Data.SubClass;

	pkg << Data.Name;
	pkg << Data.Name1;
	pkg << Data.Name2;
	pkg << Data.Name3;

	pkg << Data.DisplayID;
	pkg << Data.OverallQualityID;

	pkg << Data.Flags;
	pkg << Data.BuyPrice;
	pkg << Data.SellPrice;
	pkg << Data.InventoryType;

	pkg << Data.AllowableClass;
	pkg << Data.AllowableRace;

	pkg << Data.ItemLevel;
	pkg << Data.RequiredLevel;
	pkg << Data.RequiredSkill;
	pkg << Data.RequiredSkillRank;

	pkg << Data.RequiredSpell; //required spell
	pkg << Data.RequiredPVPRank; //required faction
	pkg << Data.unk1; //unknown 1
	pkg << Data.RequiredFaction; //required PvP rank
	pkg << Data.RequiredFactionLvL; //required faction level

	pkg << Data.Stackable;
	pkg << Data.MaxStack;
	pkg << Data.ContainerSlots;

	pkg.Write(Data.Attributes, sizeof(Data.Attributes));

	for (i = 0; i < 5; i++)
	{
		pkg << Data.DamageStats[i].Min;
		pkg << Data.DamageStats[i].Max;
		pkg << Data.DamageStats[i].Type;
	}
	pkg << Data.Resistances.Physical;
	pkg << Data.Resistances.Holy; // So called holy resist... I don't know what it is :(
	pkg << Data.Resistances.Fire;
	pkg << Data.Resistances.Nature;
	pkg << Data.Resistances.Frost;
	pkg << Data.Resistances.Shadow;
	pkg << Data.Resistances.Arcane;

	pkg << Data.WeaponSpeed;
	pkg << Data.AmmoType;

	pkg.Write(Data.SpellStats, sizeof(Data.SpellStats));

	pkg << Data.Bonding;
	pkg << Data.Description;
	pkg << Data.PageText;
	pkg << Data.LanguageID;
	pkg << Data.PageMaterial;
	pkg << Data.StartQuest;
	pkg << Data.LockID;
	pkg << Data.Material;
	pkg << Data.SheatheType;
	pkg << Data.Unknown1;
	pkg << Data.Block;
	//three new fields
	pkg << Data.SetID; //(unsigned long)(0); //Unknown3 added two more fields!
	pkg << Data.MaxDurability; //(unsigned long)(0); //MaxDurability
	pkg << Data.Unknown2; //(unsigned long)(0); //unknown

	pClient->Send(&pkg);
}

//please don't use this function!
unsigned long CItemTemplate::GetItemTemplateInfoData(char *buffer)
{
#define Add(datatype,data) *(datatype*)&buffer[c]=data;c+=sizeof(datatype);
#define AddString(data) strcpy(&buffer[c],data);c+=strlen(data)+1;
#define Skip(n) c+=n;
#define Fill(size,value) memset(&buffer[c],value,size);c+=size;
	int c=0;

	Add(unsigned long,guid);
	Add(unsigned long,Data.Class);
	Add(unsigned long,Data.SubClass);
	AddString(Data.Name);
	AddString(Data.Name1);
	AddString(Data.Name2);
	AddString(Data.Name3);

	memcpy(&buffer[c], &Data.DisplayID, 30*4 + sizeof(ItemAttribute)*10 + sizeof(DamageStat)*5 + sizeof(SpellStat)*5);
	c += 30*4 + sizeof(ItemAttribute)*10 + sizeof(DamageStat)*5 + sizeof(SpellStat)*5;
	AddString(Data.Description);
	memcpy(&buffer[c], &Data.PageText, 11*4);
	c += 11*4;

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
	Data.ItemLevel = 1;
	Data.RequiredLevel = 1;
	Data.MaxStack = 1;

	memset(&Data, 0, sizeof(Data));
}

bool CItemTemplate::StoringData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	Storage.Allocate(sizeof(ItemTemplateData));
	memcpy(Storage.Data,&Data,sizeof(ItemTemplateData));
	return true;
}

bool CItemTemplate::LoadingData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	memcpy(&Data,Storage.Data,sizeof(ItemTemplateData));
	return true;
}
unsigned long STATICITEMS::HEARTHSTONE;
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
