#ifndef ITEMTEMPLATE_H
#define ITEMTEMPLATE_H

#include "stdafx.h"
#include "WoWObject.h"

struct ItemAttribute
{
	unsigned long ID;
	unsigned long Value;
};

struct DamageStat
{
	float Min;
	float Max;
	unsigned long Type;
};

struct ResistStat
{
	unsigned long Physical;
	unsigned long Holy; //inserted 0x0
	unsigned long Fire;
	unsigned long Nature;
	unsigned long Frost;
	unsigned long Shadow;
	unsigned long Arcane;
};


struct SpellStat
{
	unsigned long ID;
	unsigned long Trigger;
	unsigned long Charges;
	unsigned long Cooldown;
	unsigned long Category;
	unsigned long CategoryCoolDown;
};

struct ItemTemplateData
{
	//char CodeName[64];// internal use only
	unsigned long ItemID;
	unsigned long Class;
	unsigned long SubClass;

	char Name[64];
	char Name1[64];
	char Name2[64];
	char Name3[64];

	unsigned long DisplayID;
	unsigned long OverallQualityID;
	unsigned long Flags;
	unsigned long BuyPrice;// Player buys
	unsigned long SellPrice;// Player sells
	unsigned long InventoryType;
	unsigned long AllowableClass;
	unsigned long AllowableRace;
	unsigned long ItemLevel;

	unsigned long RequiredLevel;
	unsigned long RequiredSkill;
	unsigned long RequiredSkillRank;

	unsigned long RequiredSpell;
	unsigned long RequiredPVPRank;
	unsigned long unk1; //always 0?
	unsigned long RequiredFaction;
	unsigned long RequiredFactionLvL;

	unsigned long Stackable;
	unsigned long MaxStack;
	//unsigned long dummy; //Stackable
	unsigned long ContainerSlots;

	ItemAttribute Attributes[10];
	DamageStat DamageStats[5];

	ResistStat Resistances;

	unsigned long WeaponSpeed;
	unsigned long AmmoType;

	unsigned long Range;

	SpellStat SpellStats[5];

	unsigned long Bonding;
	char Description[160];
	unsigned long PageText;
	unsigned long LanguageID;
	unsigned long PageMaterial;
	unsigned long StartQuest;
	unsigned long LockID;
	unsigned long Material;
	unsigned long SheatheType;
	unsigned long Unknown1;
	unsigned long Block;
	//three new fields
	unsigned long SetID;
	unsigned long MaxDurability;
	unsigned long Unknown2;
};

class CItemTemplate : public CWoWObject
{
public:
	CItemTemplate(void);
	~CItemTemplate(void);

	ItemTemplateData Data;
	void Clear();
	void New();
	unsigned long GetItemTemplateInfoData(char *buffer) {return 0;};
	void SendTemplate(CClient *pClient);

	void CreateCloak(char *Name, unsigned long DisplayID);
	bool StoringData(ObjectStorage &Storage);
	bool LoadingData(ObjectStorage &Storage);
};

#endif // ITEMTEMPLATE_H
