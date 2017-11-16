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
#include "Spell.h"
#include "Corpse.h"
#include "GameObject.h"
#include "GameObjectTemplate.h"
#include "DynamicObject.h"
#include "ChatManager.h"
#include "NPCText.h"
#include "Mail.h"
#include "Quest.h"
#include "TrainerTemplate.h"

CDataManager::CDataManager(void)
{
	for(int i=0;i<OBJ_TYPES;i++) NextID[i]=(i<<24);
}

CDataManager::~CDataManager(void)
{
	Cleanup();
}

void CDataManager::Cleanup()
{
	// save cached crap
	// TODO.
	for(stdext::hash_map<unsigned long,CWoWObject *>::iterator i=CachedObjects.begin();i!=CachedObjects.end();i++)
	{
		if(i->second)
		{
			StoreObject(*(i->second));
			RegionManager.ObjectRemove(*(i->second));
			delete i->second;
		}
	}
	CachedObjects.clear();
	// clean out all the maps!
	AccountNames.clear();
	PlayerNames.clear();
	CreatureTemplateNames.clear();
	ItemTemplates.clear();
	SellTemplates.clear();
	TrainerTemplates.clear();
	CreatureQuestRelation.clear();
	CreatureInvolvedRelation.clear();
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
	{\
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
		RetrieveCase(OBJ_CONTAINER,CContainer);
		RetrieveCase(OBJ_GAMEOBJECT,CGameObject);
		RetrieveCase(OBJ_GAMEOBJECTTEMPLATE,CGameObjectTemplate);
		RetrieveCase(OBJ_CORPSE,CCorpse);
		RetrieveCase(OBJ_DYNAMICOBJECT,CDynamicObject);
		RetrieveCase(OBJ_NPCTEXT,CNPCText);
		RetrieveCase(OBJ_PAGETEXT,CPageText);
		RetrieveCase(OBJ_MAIL,CMail);
		RetrieveCase(OBJ_QUESTINFO,CQuestInfo);
		RetrieveCase(OBJ_TRAINERTEMPLATE,CTrainerTemplate);
		RetrieveCase(OBJ_QUESTRELATION,CQuestRelation);
	}

	return false;
#undef RetrieveCase
}

void CDataManager::CacheObject(CWoWObject &Object)
{
	if (!Object.type || !Object.guid)
		return;
	CachedObjects[Object.guid]=&Object;
}

void CDataManager::UnCacheObjectNoFree(CWoWObject &Object)
{
	if (!Object.guid || !Object.type)
		return;
	if (!CachedObjects[Object.guid])
		return;
	CachedObjects.erase(Object.guid);
}

void CDataManager::UnCacheObject(CWoWObject &Object)
{
	if (!Object.guid || !Object.type)
		return;
	CWoWObject *pObject=CachedObjects[Object.guid];
	if (!pObject)
		return;
	CachedObjects.erase(Object.guid);
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
