#pragma once
#include "stdafx.h"
#include "WoWObject.h"

struct CreatureStats
{
	long HitPoints;
	long Energy;
	long Focus;
	long Rage;
};

struct CreatureTemplateData
{
	char CodeName[64];

	char Name[64];
	char Name1[64];
	char Name2[64];
	char Name3[64];
	char Guild[64];
	unsigned long Something1;
	unsigned long Something2;
	unsigned long Something3;

	CreatureStats NormalStats;

	unsigned short DamageMin;
	unsigned short DamageMax;

	unsigned long Size;
	unsigned long Model;
	unsigned long Level;
	unsigned long Exp;

	unsigned long RegenPerTick;
	unsigned long RegenPeriodicity;

	unsigned char Aggressiveness;

// -- calculate at spawn time to allow weapons/armor to be displayed
	unsigned long LootTable;


// -- Stuff not to copy to creatures

	// used for preventing certain creatures from spawning too often. for example,
	// dragons that spawn every 100 hours would have a MinRespawnTime of 60*60*100
	// (seconds per minute)*(minutes per hour)*(number of hours)
	unsigned long MinRespawnTime; // number of seconds between allowed spawns of this creature
	unsigned long MaxLifetime;	  // number of seconds creature is allowed to live for (0=infinite)
	time_t LastSpawn;

};

class CCreatureTemplate : public CWoWObject
{
public:
	CCreatureTemplate(void);
	~CCreatureTemplate(void);

	CreatureTemplateData Data;
	bool StoringData(ObjectStorage &Storage);
	bool LoadingData(ObjectStorage &Storage);
	unsigned long DataStorageSize() {return sizeof(CreatureTemplateData);};

	void Clear();
	void New(const char *Name);

	bool Generated;
};
