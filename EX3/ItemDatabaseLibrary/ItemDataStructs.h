// (c) AbyssX Group
#if !defined(ITEMSTRUCTS_H)
#define ITEMSTRUCTS_H


// McKay34, you must hate me so much right now =P
// Please dont hack this to hell. It works well.
// I dont know what you have against structs, but they are a good way to organize stuff.
// -Silent

struct ItemPrototypeStatAndBonus
{
	int stat;
	int statBonus;
};

struct ItemPrototypeDamage
{
	int minDamage;//done
	int maxDamage;//done
	int damageType;//done - Need type list
};

struct ItemPrototypeSpellInfo
{
	int spellID;//done
	int spellTrigger;//done
	int spellCharges;//done
	int spellCooldown;//done
	int spellCategory;//done
	int spellCategoryCooldown;//done
};

struct ItemPrototypeData
{
	int id; //done -
	int iClass; //done -
	int subClass; //done -
	char* name[4]; //done -
	int displayID; //done -
	int qualityID; // WTF? -
	int flags; // working on it -
	int buyPrice; //done -
	int sellPrice; //done -
	int inventoryT; //done -
	int aClass; //done -
	int aRace; //done -
	int level; //done -
	int rLevel; //done -
	int rSkill; //done -
	int rSkillRank; //done -
	int maxInv; //done -
	int stack; //done -
	int container; //done -
	ItemPrototypeStatAndBonus stat[10]; -
	ItemPrototypeDamage dmg[5]; -
	int armour;//done -
	int resist[6]; -
	int delay;//done -
	int ammoType;//done -
	int maxDurability;//done -
	ItemPrototypeSpellInfo spell[5]; -
	int bond; // WTF? -
	char* description;//done
	int pageTXT; // Need Example
	int langID;//done
	int pageMaterial;//done
	int questID; // Need quests first =)
	int lockID; // ?
	int material;// Doesnt help
	int sheathe;//?
};

#endif