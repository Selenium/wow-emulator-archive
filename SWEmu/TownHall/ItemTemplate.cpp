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

	pkg << Data.Range; // Range

	pkg.Write(Data.SpellStats, sizeof(Data.SpellStats));

	pkg << Data.Bonding;
	pkg << Data.Description;
	pkg << Data.PageText;
	pkg << Data.LanguageID;
	pkg << Data.PageMaterial;
	pkg << (unsigned long)0; // Data.StartQuest; // ridiculous thing, doesn't even work that well.
	pkg << Data.LockID;
	pkg << Data.Material;
	pkg << Data.SheatheType;
	pkg << Data.Unknown1;
	pkg << Data.Block;
	//three new fields
	pkg << Data.SetID; //(unsigned long)(0); //Unknown3 added two more fields!
	pkg << Data.MaxDurability; //(unsigned long)(0); //MaxDurability
	pkg << Data.Unknown2; //(unsigned long)(0); //unknown
	pkg << (unsigned long)0 << (unsigned long)0;

	pClient->Send(&pkg);
}

//please don't use this function!
/*
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
}
*/
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
