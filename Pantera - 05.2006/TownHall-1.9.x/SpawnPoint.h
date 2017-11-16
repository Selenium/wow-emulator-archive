#ifndef SPAWNPOINT_H
#define SPAWNPOINT_H

#include "stdafx.h"
#include "WoWObject.h"

// Zone has a list of these.  a spawn point controls repop at a specific point and
// possibly the patrol movement of the creature at this point.

struct SpawnPointData
{
	// origin data
	_Location Origin;
	float	 OriginFacing;
	unsigned long OriginContinent;

	// note: Creatures uses creature TEMPLATE id
	unsigned long Creatures[10];			// randomly select a creature
	unsigned long CreatureRates[10];		// rate of spawn for each in the list
	unsigned long CreatureLifetimes[10];    // max lifetime of each spawn in the list
	// whichever is shorter between this and the creature template's max lifetime will be used

	unsigned long Periodicity; // rate of spawn (e.g. "5 minute respawn") in milliseconds

	// current data
	unsigned long Creature;
	time_t SpawnTime;
};

class CSpawnPoint : public CWoWObject
{
public:
	CSpawnPoint(void);
	~CSpawnPoint(void);

	SpawnPointData Data;
	bool StoringData(ObjectStorage &Storage);
	bool LoadingData(ObjectStorage &Storage);
	unsigned long DataStorageSize() {return sizeof(SpawnPointData);};

	void Clear();
	void Delete();

	void Spawn();
	void Despawn();

	void ProcessEvent(struct WoWEvent &Event);
};

#endif // SPAWNPOINT_H
