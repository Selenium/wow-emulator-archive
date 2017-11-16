#ifndef DATAMANAGER_H
#define DATAMANAGER_H

#include "stdafx.h"
#include "WoWObject.h"
#include <map>

#include <map>
/* // no more hash_maps
#ifdef __CYGWIN__
#define hash_map map // for cygwin compatibility
#else
#include <hash_map>
#endif
*/

#include <string>
#include <algorithm>
#include <vector>
#include <list>

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
class CPathGroup;
class CGuild;
class CParty;
class CSpell;
class CCorpse;
class CGameObject;
class CGameObjectTemplate;
class CDynamicObject;
class CNPCText;
class CAuction;
class CPageText;
class CMail;
class CQuestInfo;
class CTrainerTemplate;
class CQuestRelation;

#define MakeLower(yourstring) transform (yourstring.begin(),yourstring.end(), yourstring.begin(), tolower);
#define MakeUpper(yourstring) transform (yourstring.begin(),yourstring.end(), yourstring.begin(), toupper);

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
	bool RetrieveObject(CWoWObject **ppObject, unsigned long Type, guid_t ID);
	// no type checking (WILL ONLY FIND CACHED OBJECTS!)
	inline bool RetrieveObject(CWoWObject **ppObject, guid_t ID) {return RetrieveCache(ppObject,ID);}
	bool DeleteObject(CWoWObject &Object);
	// ----------------------------------

	map<string,guid_t> AccountNames;

	map<string,guid_t> PlayerNames;

	map<string,guid_t> CreatureTemplateNames;

	// NPC related stuff

	map<guid_t, std::list<guid_t> > CreatureQuestRelation;
	map<guid_t, std::list<guid_t> > CreatureInvolvedRelation;
	map<string, guid_t> GameObjectEntries;

	map<guid_t, std::list<guid_t> > SellTemplates;

	map<guid_t, std::list<_TrainerItem> > TrainerTemplates;

	// until storage is implemented we need a way to re-use item templates
	// stuff using this will need to be rewritten to use whatever system we implement, if
	// it is different.
	inline guid_t CreatureTemplates(unsigned long ID)
	{
		if(!ID) return 0;
		return (ID | (OBJ_CREATURETEMPLATE << 24));
	}
	inline guid_t ItemTemplates(unsigned long ID)
	{
		if(!ID) return 0;
		return (ID | (OBJ_ITEMTEMPLATE << 24));
	}
	inline guid_t QuestIDs(unsigned long ID)
	{
		if(!ID) return 0;
		return (ID | (OBJ_QUESTINFO << 24));
	}
	inline guid_t GetFreeID(unsigned long Type)
	{
		CLock L(&SID,1);
		// todo: by type (unnecessary until we have a few billion objects, put this off
		// indefinitely)
		// for now:
		return ++NextID[Type];
	}

	// dont call this or i'll kick your ass. k.
	inline void SetNextID(guid_t NewNextID, unsigned long type)
	{
		CLock L(&SID,1);
		NextID[type]=NewNextID;
	}

	inline void SetNextIDIfGreater(guid_t NewNextID, unsigned long type)
	{
		CLock L(&SID,1);
		if(NewNextID>NextID[type]) NextID[type]=NewNextID;
	}

	void UnCacheObjectNoFree(CWoWObject &Object);

private:
	CSemaphore SID;
	guid_t NextID[OBJ_TYPES];

	// type checking
	bool RetrieveCache(CWoWObject **ppObject, unsigned long Type, guid_t ID);
	// no type checking
	bool RetrieveCache(CWoWObject **ppObject, guid_t ID);

	// cache
	// a universal map (all our ids are currently *unique* across all types)
	map<guid_t,CWoWObject *> CachedObjects;

	void CacheObject(CWoWObject &Object);
	void UnCacheObject(CWoWObject &Object);
};

#endif // DATAMANAGER_H
