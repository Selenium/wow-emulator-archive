#if !defined(ITEM_H)
#define ITEM_H

#ifdef ITEMS

struct ItemAttribute
{
	DoubleWord ID;
	DoubleWord Value;
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

struct ItemData
{
	DoubleWord Entry;
	DoubleWord Type;
	DoubleWord Subtype;
	string name;
	DoubleWord DisplayID;
	DoubleWord OverallQuality;
	DoubleWord Flags;
	DoubleWord BuyPrice;// Player buys
	DoubleWord SellPrice;// Player sells
	DoubleWord InvType;
	int AllowableClass;
	int AllowableRace;
	DoubleWord Level;
	DoubleWord LevelReq;
	DoubleWord SkillReq;
	DoubleWord MinSkillReq;
	DoubleWord ItemUnique;
	DoubleWord MaxStack;
	DoubleWord ContainerSlots;
	ItemAttribute Attributes[10];
	DamageStat DamageStats[5];
	int ResistPhysical;
	int ResistHoly;
	int ResistFire;
	int ResistNature;
	int ResistFrost;
	int ResistShadow;
	DoubleWord WeaponSpeed;
	DoubleWord AmmoType;
	DoubleWord MaxDurability;
	SpellStat SpellStats[5];
	DoubleWord Bonding;
	string description;
	DoubleWord PageText;
	DoubleWord LanguageID;
	DoubleWord PageMaterial;
	DoubleWord StartQuest;
	DoubleWord Lock;
	DoubleWord Material;
	DoubleWord SheatheType;
	DoubleWord Unknown;
	DoubleWord UnknownBeta2;
};

class Item
{
	public:
		Item();
		~Item();

	ItemData ItemDATA;
};

#endif

#endif