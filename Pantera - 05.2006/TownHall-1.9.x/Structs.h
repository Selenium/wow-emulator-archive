#ifndef STRUCTS_H
#define STRUCTS_H

struct _Location
{
	float X;
	float Y;
	float Z;
};

struct _Graveyard
{
	_Location Loc;
	unsigned long Continent;
};

struct _Origin
{
	unsigned long Continent;
	unsigned long Zone;
	_Location Loc;
	float Facing;
	unsigned long Intro;
};

struct _Name
{
	char Name[64];
};
struct TrainerItem_t
{
	unsigned long SpellID;
	unsigned long MoneyCost;
	unsigned long PointCost0;
	unsigned long PointCost1;
	unsigned long ReqLevel;
	unsigned long ReqSkillLine;
	unsigned long ReqSkillRank;
	unsigned long ReqAbility0;
	unsigned long ReqAbility1;
	unsigned long ReqAbility2;
};

struct _TrainerItem
{
	unsigned long SpellID;
	short SkillLine;
	short SpellCost;
	unsigned long ReqSpell;
};

struct TrainerInfo
{
	long TrainerType;
	long Count;
	TrainerItem_t Item[MAX_TRAINER_ITEMS];
	char *Greeting;
};

struct _GossipItem
{
	unsigned long Icon;
	unsigned long Inputbox;
	char Message[50];
	char Message2[50];
	unsigned long HandlerID;
	unsigned long Data1;
	unsigned long Data2;
};

struct _RestoreAura
{
	/*
	RESTORETYPE_HEALTH = 0;
	RESTORETYPE_MANA = 1;
	RESTORETYPE_ENERGY = 2;
	*/
	unsigned long SpellID;
	unsigned long FrequencyID;
	unsigned long Type;
	unsigned long PerTick;
	unsigned long RemainingTicks;
};


struct _Modifier
{
	unsigned long SpellID;
	unsigned short SlotID;
	unsigned short ModID;
	unsigned long Effect;
	unsigned long time;
	unsigned long power;
	unsigned long type;
	CWoWObject *pTarget;
	CWoWObject *pCaster;
	bool Applied;
};

#endif // STRUCTS_H
