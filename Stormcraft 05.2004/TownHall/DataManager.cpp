#include "stdafx.h"
#include "DataManager.h"
#include "Account.h"
#include "Creature.h"
#include "CreatureTemplate.h"
#include "Item.h"
#include "ItemTemplate.h"
#include "Player.h"
#include "SpawnPoint.h"
#include "Zone.h"
#include "Container.h"
#include "LootTable.h"
#include "PathGroup.h"
#include "Globals.h"
#include "Guild.h"
#include "Party.h"

CDataManager::CDataManager(void):CachedPlayers(0x100),CachedCreatures(0x100),CachedCreatureTemplates(0x100),CachedGuilds(0x100),CachedPartys(0x100)
{
	NextID=0;
}

CDataManager::~CDataManager(void)
{
	Cleanup();
}

void CDataManager::Cleanup()
{
	// save cached crap
	// TODO.
#define SaveCache(_index_) 	for (i = 0 ; i < _index_.Size ; i++)\
	{		if (_index_[i])			StoreObject(*(CWoWObject*)_index_[i]);	}


	unsigned long i;
	SaveCache(CachedItems);
	SaveCache(CachedItemTemplates);
	SaveCache(CachedCreatures);
	SaveCache(CachedCreatureTemplates);
	SaveCache(CachedPlayers);
	SaveCache(CachedAccounts);
	SaveCache(CachedZones);
	SaveCache(CachedSpawnPoints);
	SaveCache(CachedContainers);
	SaveCache(CachedLootTables);
	SaveCache(CachedPathGroups);
	SaveCache(CachedGuilds);
	SaveCache(CachedPartys);

	// clear cached crap
	CachedItems.Cleanup();
	CachedItemTemplates.Cleanup();
	CachedCreatures.Cleanup();
	CachedCreatureTemplates.Cleanup();
	CachedPlayers.Cleanup();
	CachedAccounts.Cleanup();
	CachedZones.Cleanup();
	CachedSpawnPoints.Cleanup();
	CachedContainers.Cleanup();
	CachedLootTables.Cleanup();
	CachedPathGroups.Cleanup();
	CachedGuilds.Cleanup();
	CachedPartys.Cleanup();
}

void CDataManager::NewObject(CWoWObject &Object)
{
	Storage.StoreObject(Object);
	CacheObject(Object);
}

bool CDataManager::StoreObject(CWoWObject &Object)
{
	// the object in use IS the one in the cache, dont update cache

	// store data into storage system
	return Storage.StoreObject(Object);
}

bool CDataManager::DeleteObject(CWoWObject &Object)
{
	// remove from cache
	UnCacheObject(Object);
	// remove data from storage system
	return Storage.DeleteObject(Object);
}

bool CDataManager::RetrieveObject(CWoWObject **ppObject, unsigned long Type, unsigned long ID)
{
	// check cache before storage
	if (RetrieveCache(ppObject,Type,ID))
		return true;
	// not cached, load data from storage system

	ObjectStorage Data;
#define RetrieveCase(objtype,datatype) \
case objtype: \
	{ \
		datatype *pPtr = new datatype;\
		if (Storage.RetrieveObject(*pPtr,ID)) { CacheObject(*pPtr); *ppObject=pPtr; return true;}\
		delete pPtr;\
		return false;\
	}\
	break;

	switch(Type)
	{
		RetrieveCase(OBJ_PLAYER,CPlayer);
		RetrieveCase(OBJ_CREATURE,CCreature);
		RetrieveCase(OBJ_CREATURETEMPLATE,CCreatureTemplate);
		RetrieveCase(OBJ_ITEM,CItem);
		RetrieveCase(OBJ_ITEMTEMPLATE,CItemTemplate);
		RetrieveCase(OBJ_ACCOUNT,CAccount);
		RetrieveCase(OBJ_SPAWNPOINT,CSpawnPoint);
		RetrieveCase(OBJ_ZONE,CZone);
		RetrieveCase(OBJ_LOOTTABLE,CLootTable);
		RetrieveCase(OBJ_PATHGROUP,CPathGroup);
		RetrieveCase(OBJ_GUILD,CGuild);
		RetrieveCase(OBJ_PARTY,CParty);
	}

	return false;
#undef RetrieveCase
}

void CDataManager::CacheObject(CWoWObject &Object)
{
	if (!Object.type || !Object.guid)
		return; // nothing to cache
	unsigned long N=0;
	switch(Object.type)
	{
		case OBJ_PLAYER://1
			N=CachedPlayers.GetUnused();
			CachedPlayers[N]=(CPlayer*)&Object;
			CachedObjects[Object.guid]=(CWoWObject*)CachedPlayers[N];
			CachedObjectIndexes[Object.guid]=N+1;
			break;
		case OBJ_CREATURE://2 
			N=CachedCreatures.GetUnused();
			CachedCreatures[N]=(CCreature*)&Object;
			CachedObjects[Object.guid]=(CWoWObject*)CachedCreatures[N];
			CachedObjectIndexes[Object.guid]=N+1;
			break;
		case OBJ_SPAWNPOINT://3
			N=CachedSpawnPoints.GetUnused();
			CachedSpawnPoints[N]=(CSpawnPoint*)&Object;
			CachedObjects[Object.guid]=(CWoWObject*)CachedSpawnPoints[N];
			CachedObjectIndexes[Object.guid]=N+1;
			break;
		case OBJ_ZONE://4
			N=CachedZones.GetUnused();
			CachedZones[N]=(CZone*)&Object;
			CachedObjects[Object.guid]=(CWoWObject*)CachedZones[N];
			CachedObjectIndexes[Object.guid]=N+1;
			break;
		case OBJ_ACCOUNT://5
			N=CachedAccounts.GetUnused();
			CachedAccounts[N]=(CAccount*)&Object;
			CachedObjects[Object.guid]=(CWoWObject*)CachedAccounts[N];
			CachedObjectIndexes[Object.guid]=N+1;
			break;
		case OBJ_ITEM://6
			N=CachedItems.GetUnused();
			CachedItems[N]=(CItem*)&Object;
			CachedObjects[Object.guid]=(CWoWObject*)CachedItems[N];
			CachedObjectIndexes[Object.guid]=N+1;
			break;
		case OBJ_ITEMTEMPLATE://7
			N=CachedItemTemplates.GetUnused();
			CachedItemTemplates[N]=(CItemTemplate*)&Object;
			CachedObjects[Object.guid]=(CWoWObject*)CachedItemTemplates[N];
			CachedObjectIndexes[Object.guid]=N+1;
			break;
		case OBJ_CREATURETEMPLATE://8
			N=CachedCreatureTemplates.GetUnused();
			CachedCreatureTemplates[N]=(CCreatureTemplate*)&Object;
			CachedObjects[Object.guid]=(CWoWObject*)CachedCreatureTemplates[N];
			CachedObjectIndexes[Object.guid]=N+1;
			break;
		case OBJ_CONTAINER://9
			N=CachedContainers.GetUnused();
			CachedContainers[N]=(CContainer*)&Object;
			CachedObjects[Object.guid]=(CWoWObject*)CachedContainers[N];
			CachedObjectIndexes[Object.guid]=N+1;
			break;
		case OBJ_LOOTTABLE://10
			N=CachedLootTables.GetUnused();
			CachedLootTables[N]=(CLootTable*)&Object;
			CachedObjects[Object.guid]=(CWoWObject*)CachedLootTables[N];
			CachedObjectIndexes[Object.guid]=N+1;
			break;
		case OBJ_PATHGROUP://11
			N=CachedPathGroups.GetUnused();
			CachedPathGroups[N]=(CPathGroup*)&Object;
			CachedObjects[Object.guid]=(CWoWObject*)CachedPathGroups[N];
			CachedObjectIndexes[Object.guid]=N+1;
			break;
		case OBJ_GUILD://12
			N=CachedGuilds.GetUnused();
			CachedGuilds[N]=(CGuild*)&Object;
			CachedObjects[Object.guid]=(CWoWObject*)CachedGuilds[N];
			CachedObjectIndexes[Object.guid]=N+1;
		case OBJ_PARTY://15
			N=CachedPartys.GetUnused();
			CachedPartys[N]=(CParty*)&Object;
			CachedObjects[Object.guid]=(CWoWObject*)CachedPartys[N];
			CachedObjectIndexes[Object.guid]=N+1;
			break;
	}
}

void CDataManager::UnCacheObjectNoFree(CWoWObject &Object)
{
	if (!Object.guid || !Object.type)
		return;
	CWoWObject *pObject=CachedObjects[Object.guid];
	if (!pObject)
		return;
	unsigned long N=CachedObjectIndexes[Object.guid];
	if (N==0)
		return;
	N--;
	CachedObjectIndexes[Object.guid]=0;
}

void CDataManager::UnCacheObject(CWoWObject &Object)
{
	if (!Object.guid || !Object.type)
		return;
	CWoWObject *pObject=CachedObjects[Object.guid];
	if (!pObject)
		return;
	unsigned long N=CachedObjectIndexes[Object.guid];
	if (N==0)
		return;
	N--;
	CachedObjectIndexes[Object.guid]=0;

	switch(Object.type)
	{
		case OBJ_PLAYER://1
			{
				CPlayer *pPlayer=(CPlayer*)pObject;
				delete pPlayer;
			}
			break;
		case OBJ_CREATURE://2 
			{
				CCreature *pCreature=(CCreature*)pObject;
				delete pCreature;
			}
			break;
		case OBJ_SPAWNPOINT://3
			{
				CSpawnPoint *pSpawnPoint=(CSpawnPoint*)pObject;
				delete pSpawnPoint;
			}
			break;
		case OBJ_ZONE://4
			{
				CZone *pZone=(CZone*)pObject;
				delete pZone;
			}
			break;
		case OBJ_ACCOUNT://5
			{
				CAccount *pAccount=(CAccount*)pObject;
				delete pAccount;
			}
			break;
		case OBJ_ITEM://6
			{
				CItem *pItem=(CItem*)pObject;
				delete pItem;
			}
			break;
		case OBJ_ITEMTEMPLATE://7
			{
				CItemTemplate *pItemTemplate=(CItemTemplate*)pObject;
				delete pItemTemplate;
			}
			break;
		case OBJ_CREATURETEMPLATE://8
			{
				CCreatureTemplate *pCreatureTemplate=(CCreatureTemplate*)pObject;
				delete pCreatureTemplate;
			}
			break;
		case OBJ_CONTAINER://9
			{
				CContainer *pContainer=(CContainer*)pObject;
				delete pContainer;
			}
			break;
		case OBJ_LOOTTABLE://10
			{
				CLootTable *pLootTable=(CLootTable*)pObject;
				delete pLootTable;
			}
			break;
		case OBJ_PATHGROUP:
			{
				CPathGroup *pPathGroup=(CPathGroup*)pObject;
				delete pPathGroup;
			}
			break;
		case OBJ_GUILD:
			{
				CGuild *pGuild=(CGuild*)pObject;
				delete pGuild;
			}
			break;
		case OBJ_PARTY:
			{
				CParty *pParty=(CParty*)pObject;
				delete pParty;
			}
	}
}

bool CDataManager::RetrieveCache(CWoWObject **ppObject, unsigned long Type, unsigned long ID)
{
	CWoWObject *pObject=CachedObjects[ID];
	if (!pObject)
		return false;
	if (pObject->type!=Type)
		return false;
	*ppObject=pObject;
	return true;
}

bool CDataManager::RetrieveCache(CWoWObject **ppObject, unsigned long ID)
{
	CWoWObject *pObject=CachedObjects[ID];
	if (!pObject)
		return false;
	*ppObject=pObject;
	return true;
}

