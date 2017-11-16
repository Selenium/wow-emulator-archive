#pragma once
#include "stdafx.h"
#include "WoWObject.h"
#include "Index.h"
#include <map>
#include <string>
#include <algorithm>
using namespace std;
class CClient;
class CAccount;
class CZone;
class CPlayer;
class CCreature;
class CItem;
class CSpawnPoint;
class CCreatureTemplate;
class CItemTemplate;
class CLootTable;
class CContainer;
class CPathGroup;
class CGuild;
class CParty;

#define MakeLower(yourstring) transform (yourstring.begin(),yourstring.end(), yourstring.begin(), tolower);

// data manager will use any given storage mechanism and style, through use
// of a storage class.  this data manager layer will provide cache capabilities
// based on usage of each object.  objects used more often will be cached in memory
// rather than on disk.  the data manager may also be responsible for routine backups,
// or this may be in another thread.
class CDataManager
{
public:
	CDataManager(void);
	~CDataManager(void);

	void Cleanup();

	// -- common storage and retrieval --
	void NewObject(CWoWObject &Object);
	bool StoreObject(CWoWObject &Object);
	// type checking
	bool RetrieveObject(CWoWObject **ppObject, unsigned long Type, unsigned long ID);
	// no type checking (WILL ONLY FIND CACHED OBJECTS!)
	inline bool RetrieveObject(CWoWObject **ppObject, unsigned long ID) {return RetrieveCache(ppObject,ID);}
	bool DeleteObject(CWoWObject &Object);
	// ----------------------------------

	map<string,unsigned long> AccountNames;

	map<string,unsigned long> PlayerNames;

	// until storage is implemented we need a way to re-use item templates
	// stuff using this will need to be rewritten to use whatever system we implement, if
	// it is different.
	map<string,unsigned long> ItemTemplates;

	inline unsigned long GetFreeID(unsigned long Type)
	{
		CLock L(&SID,1);
		// todo: by type (unnecessary until we have a few billion objects, put this off
		// indefinitely)
		// for now:
		return ++NextID;
	}

	// dont call this or i'll kick your ass. k.
	inline void SetNextID(unsigned long NewNextID)
	{
		CLock L(&SID,1);
		NextID=NewNextID;
	}

	void UnCacheObjectNoFree(CWoWObject &Object);

	inline void EnumItems(fObjectEnum EnumFunction)
	{
		for (unsigned long i = 0 ; i < CachedItems.Size ; i++)
		{
			if (CachedItems[i])
			{
				if (!EnumFunction(*(CWoWObject*)CachedItems[i]))
					return;
			}
		}
	}

	inline void EnumItemTemplates(fObjectEnum EnumFunction)
	{
		for (unsigned long i = 0 ; i < CachedItemTemplates.Size ; i++)
		{
			if (CachedItemTemplates[i])
			{
				if (!EnumFunction(*(CWoWObject*)CachedItemTemplates[i]))
					return;
			}
		}
	}

	inline void EnumCreatures(fObjectEnum EnumFunction)
	{
		for (unsigned long i = 0 ; i < CachedCreatures.Size ; i++)
		{
			if (CachedCreatures[i])
			{
				if (!EnumFunction(*(CWoWObject*)CachedCreatures[i]))
					return;
			}
		}
	}

	inline void EnumCreatureTemplates(fObjectEnum EnumFunction)
	{
		for (unsigned long i = 0 ; i < CachedCreatureTemplates.Size ; i++)
		{
			if (CachedCreatureTemplates[i])
			{
				if (!EnumFunction(*(CWoWObject*)CachedCreatureTemplates[i]))
					return;
			}
		}
	}

	inline void EnumPlayers(fObjectEnum EnumFunction)
	{
		for (unsigned long i = 0 ; i < CachedPlayers.Size ; i++)
		{
			if (CachedPlayers[i])
			{
				if (!EnumFunction(*(CWoWObject*)CachedPlayers[i]))
					return;
			}
		}
	}

	inline void EnumAccounts(fObjectEnum EnumFunction)
	{
		for (unsigned long i = 0 ; i < CachedAccounts.Size ; i++)
		{
			if (CachedAccounts[i])
			{
				if (!EnumFunction(*(CWoWObject*)CachedAccounts[i]))
					return;
			}
		}
	}

	inline void EnumZones(fObjectEnum EnumFunction)
	{
		for (unsigned long i = 0 ; i < CachedZones.Size ; i++)
		{
			if (CachedZones[i])
			{
				if (!EnumFunction(*(CWoWObject*)CachedZones[i]))
					return;
			}
		}
	}

	inline void EnumSpawnPoints(fObjectEnum EnumFunction)
	{
		for (unsigned long i = 0 ; i < CachedSpawnPoints.Size ; i++)
		{
			if (CachedSpawnPoints[i])
			{
				if (!EnumFunction(*(CWoWObject*)CachedSpawnPoints[i]))
					return;
			}
		}
	}

	inline void EnumContainers(fObjectEnum EnumFunction)
	{
		for (unsigned long i = 0 ; i < CachedContainers.Size ; i++)
		{
			if (CachedContainers[i])
			{
				if (!EnumFunction(*(CWoWObject*)CachedContainers[i]))
					return;
			}
		}
	}

	inline void EnumLootTables(fObjectEnum EnumFunction)
	{
		for (unsigned long i = 0 ; i < CachedLootTables.Size ; i++)
		{
			if (CachedLootTables[i])
			{
				if (!EnumFunction(*(CWoWObject*)CachedLootTables[i]))
					return;
			}
		}
	}

	inline void EnumPathGroups(fObjectEnum EnumFunction)
	{
		for (unsigned long i = 0 ; i < CachedPathGroups.Size ; i++)
		{
			if (CachedPathGroups[i])
			{
				if (!EnumFunction(*(CWoWObject*)CachedPathGroups[i]))
					return;
			}
		}
	}

	inline void EnumGuilds(fObjectEnum EnumFunction)
	{
		for (unsigned long i = 0 ; i < CachedGuilds.Size ; i++)
		{
			if (CachedGuilds[i])
			{
				if (!EnumFunction(*(CWoWObject*)CachedGuilds[i]))
					return;
			}
		}		
	}

	inline void EnumPartys(fObjectEnum EnumFunction)
	{
		for (unsigned long i = 0 ; i < CachedPartys.Size ; i++)
		{
			if (CachedPartys[i])
			{
				if (!EnumFunction(*(CWoWObject*)CachedPartys[i]))
					return;
			}
		}
	}

private:
	CSemaphore SID;
	unsigned long NextID;

	// type checking
	bool RetrieveCache(CWoWObject **ppObject, unsigned long Type, unsigned long ID);
	// no type checking
	bool RetrieveCache(CWoWObject **ppObject, unsigned long ID);

	// cache
	// a) a list per type
	CIndex<CItem*> CachedItems;
	CIndex<CItemTemplate*> CachedItemTemplates;
	CIndex<CCreature*> CachedCreatures;
	CIndex<CCreatureTemplate*> CachedCreatureTemplates;
	CIndex<CPlayer*> CachedPlayers;
	CIndex<CAccount*> CachedAccounts;
	CIndex<CZone*> CachedZones;
	CIndex<CSpawnPoint*> CachedSpawnPoints;
	CIndex<CContainer*> CachedContainers;
	CIndex<CLootTable*> CachedLootTables;
	CIndex<CPathGroup*> CachedPathGroups;
	CIndex<CGuild*> CachedGuilds;
	CIndex<CParty*> CachedPartys;

	// b) a universal map (all our ids are currently *unique* across all types)
	map<unsigned long,CWoWObject *> CachedObjects;
	// c) a map of indexes, so we know what the object's index is in the list for removal
	map<unsigned long,unsigned long> CachedObjectIndexes;

	void CacheObject(CWoWObject &Object);
	void UnCacheObject(CWoWObject &Object);

};
