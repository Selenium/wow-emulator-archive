// Copyright (C) 2004 WoWD Team

#ifndef _OBJECTMGR_H
#define _OBJECTMGR_H

#include "../Shared/Log.h"
#include "Object.h"
#include "Item.h"
#include "Creature.h"
#include "Player.h"
#include "DynamicObject.h"
#include "GameObject.h"
#include "Corpse.h"
#include "Quest.h"
#include "Path.h"
#include "ItemPrototype.h"
#include "NPCHandler.h"
#include "MiscHandler.h"
#include "../Shared/Database/DatabaseEnv.h"
#include "Mail.h"
#include "Container.h"

enum HIGHGUID {
    HIGHGUID_ITEM          = 0x40000000,
    HIGHGUID_CONTAINER     = 0x40000000,
    HIGHGUID_UNIT          = 0xF0001000,
    HIGHGUID_PLAYER        = 0x00000000,
    HIGHGUID_GAMEOBJECT    = 0xF0001000,
    HIGHGUID_DYNAMICOBJECT = 0xF000A000,
    HIGHGUID_CORPSE        = 0xF0007000
};

class Group;
class Path;
class Player;
class Creature;
class Item;
class Container;
class DynamicObject;
class Corpse;
class GameObject;

#define MAX_CONTINENTS 500

class ObjectMgr : public Singleton < ObjectMgr >
{
public:
    ObjectMgr();
    ~ObjectMgr();

    // objects
    typedef HM_NAMESPACE::hash_map<uint32, Player*> PlayerMap;
    typedef HM_NAMESPACE::hash_map<uint32, Creature*> CreatureMap;
    typedef HM_NAMESPACE::hash_map<uint32, Item*> ItemMap;
	typedef HM_NAMESPACE::hash_map<uint32, Container*> ContainerMap;
    typedef HM_NAMESPACE::hash_map<uint32, DynamicObject*> DynamicObjectMap;
    typedef HM_NAMESPACE::hash_map<uint32, GameObject*> GameObjectMap;
    typedef HM_NAMESPACE::hash_map<uint32, Corpse*> CorpseMap;
    
	// other objects
    typedef std::set< Group * > GroupSet;
    typedef HM_NAMESPACE::hash_map<uint32, GossipText*> GossipTextMap;
    typedef HM_NAMESPACE::hash_map<uint32, ItemPageText*> ItemPageTextMap;
    typedef HM_NAMESPACE::hash_map<uint32, AreaTriggerQuestPoint*> AreaTriggerMap;
    typedef HM_NAMESPACE::hash_map<uint32, GraveyardTeleport*> GraveyardMap;
    //typedef HM_NAMESPACE::hash_map<uint32, CreatureInfo *> CreatureNameMap;
	typedef HM_NAMESPACE::hash_map<uint32, CreatureTemplate *> CreatureTemplateMap;
	typedef HM_NAMESPACE::hash_map<uint32, GameobjectTemplate *> GameobjectTemplateMap;
    typedef HM_NAMESPACE::hash_map<uint32, ItemPrototype*> ItemPrototypeMap;
	typedef HM_NAMESPACE::hash_map<uint32, AuctionEntry*> AuctionEntryMap;
    typedef HM_NAMESPACE::hash_map<uint32, Trainerspell*> TrainerspellMap;
    //typedef HM_NAMESPACE::hash_map<uint32, PlayerCreateInfo*> PlayerCreateInfoMap;
    typedef HM_NAMESPACE::hash_map<uint32, TaxiNodes*> TaxiNodesMap;
    typedef HM_NAMESPACE::hash_map<uint32, TaxiPath*> TaxiPathMap;
    typedef std::vector<TaxiPathNodes*> TaxiPathNodesVec;

    // objects
    template <class T>
    typename HM_NAMESPACE::hash_map<uint32, T*>::iterator
        Begin() { return _GetContainer<T>().begin(); }
    template <class T>
    typename HM_NAMESPACE::hash_map<uint32, T*>::iterator
        End() { return _GetContainer<T>().end(); }
    template <class T>
    T* GetObject(const uint64 &guid)
    {
        const HM_NAMESPACE::hash_map<uint32, T*> &container = _GetContainer<T>();
        typename HM_NAMESPACE::hash_map<uint32, T*>::const_iterator itr =
            container.find(GUID_LOPART(guid));
        if(itr == container.end() || itr->second->GetGUID() != guid)
            return NULL;
        else
            return itr->second;
    }
    template <class T>
    void AddObject(T *obj)
    {
        ASSERT(obj && obj->GetTypeId() == _GetTypeId<T>());
        ASSERT(_GetContainer<T>().find(obj->GetGUIDLow()) == _GetContainer<T>().end());
        _GetContainer<T>()[obj->GetGUIDLow()] = obj;
    }
    
	template <class T> bool RemoveObject(T *obj)
    {
        HM_NAMESPACE::hash_map<uint32, T*> &container = _GetContainer<T>();

        typename HM_NAMESPACE::hash_map<uint32, T*>::iterator i = container.find(obj->GetGUIDLow());
        if(i == container.end()) return false;

		container.erase(i);
        return true;
    }

	// Does the same as remove object, but additionally places object into
	// helper recycle map and deletes it automatically a bit later after all
	// updates finished
	template <class T> bool RemoveObject_Free(T *obj)
	{
		HM_NAMESPACE::hash_map<uint32, T*> &container = _GetContainer<T>();
		HM_NAMESPACE::hash_map<uint32, T*> &recycle = _GetRecycle<T>();

		typename HM_NAMESPACE::hash_map<uint32, T*>::iterator i = container.find(obj->GetGUIDLow());
		if(i == container.end()) return false;

		recycle[i->first] = i->second;
		container.erase(i);
		return true;
	}

	// Should be called between world updates and whatever important
	void WipeRecycles();

    Player* GetPlayer(const char* name)
    {
		// Lowercase player name and uppercase first letter
		char name1[128];
		strncpy (name1, name, sizeof (name1)-1);
		name1[sizeof (name1)-1] = '\x00';
		
		strlwr (name1);
		name1[0] = toupper(name1[0]);

        PlayerMap::const_iterator itr;
        for (itr = mPlayers.begin(); itr != mPlayers.end(); itr++)
        {
            if(strcmp(itr->second->GetName(), name1) == 0)
                return itr->second;
        }

        return NULL;
    }

    // Groups
    Group * GetGroupByLeader(const uint64 &guid) const;
    void AddGroup(Group* group) { mGroupSet.insert( group ); }
    void RemoveGroup(Group* group) { mGroupSet.erase( group ); }

    // quests
    void AddQuest(Quest* quest)
    {
        ASSERT( quest );
        ASSERT( mQuests.find(quest->m_questId) == mQuests.end() );
        mQuests[quest->m_questId] = quest;
    }
    Quest* GetQuest(uint32 id) const
    {
        QuestMap::const_iterator itr = mQuests.find( id );
        if( itr != mQuests.end( ) )
            return itr->second;
        return NULL;
    }
	void AddAuction(AuctionEntry *ah)
	{
        ASSERT( ah );
        ASSERT( mAuctions.find(ah->Id) == mAuctions.end() );
        mAuctions[ah->Id] = ah;
		Log::getSingleton().outString("adding auction entry with id %u",ah->Id);
	}
    AuctionEntry* GetAuction(uint32 id) const
    {
        AuctionEntryMap::const_iterator itr = mAuctions.find( id );
        if( itr != mAuctions.end( ) )
            return itr->second;
        return NULL;
    }
	bool RemoveAuction(uint32 id)
	{
		AuctionEntryMap::iterator i = mAuctions.find(id);
		if (i == mAuctions.end())
		{
			return false;
		}
		mAuctions.erase(i);
		return true;
	}
    // creature names
    //uint32 AddCreatureName(const char* name);
    //uint32 AddCreatureName(const char* name, uint32 displayid);
    //void AddCreatureName(uint32 id, const char* name);
    //void AddCreatureName(uint32 id, const char* name, uint32 displayid);
    //void AddCreatureName(CreatureInfo *cinfo);
	void AddCreatureTemplate (CreatureTemplate *cinfo);
	void AddGameobjectTemplate (GameobjectTemplate *goinfo);
    CreatureTemplate *GetCreatureTemplate (uint32 id, bool can_create = true);
	GameobjectTemplate *GetGameobjectTemplate (uint32 id);

    // item prototypes
    ItemPrototype* GetItemPrototype(uint32 id) const
    {
        ItemPrototypeMap::const_iterator itr = mItemPrototypes.find( id );
        if( itr != mItemPrototypes.end( ) )
            return itr->second;
        return NULL;
    }
    void AddItemPrototype(ItemPrototype *itemProto)
    {
        ASSERT( itemProto );
        ASSERT( mItemPrototypes.find(itemProto->ItemId) == mItemPrototypes.end() );
        mItemPrototypes[itemProto->ItemId] = itemProto;
    }
	Item* GetMItem(uint32 id)
	{
		ItemMap::const_iterator itr = mMitems.find(id);
		if (itr != mMitems.end())
		{
			return itr->second;
		}
		return NULL;
	}
	void AddMItem(Item* it)
	{
		ASSERT( it );
		ASSERT( mMitems.find(it->GetGUIDLow()) == mMitems.end());
		mMitems[it->GetGUIDLow()] = it;
	}
	bool RemoveMItem(uint32 id)
	{
		ItemMap::iterator i = mMitems.find(id);
		if (i == mMitems.end())
		{
			return false;
		}
		mMitems.erase(i);
		return true;
	}
	Item* GetAItem(uint32 id)
	{
		ItemMap::const_iterator itr = mAitems.find(id);
		if (itr != mAitems.end())
		{
			return itr->second;
		}
		return NULL;
	}
	void AddAItem(Item* it)
	{
		ASSERT( it );
		ASSERT( mAitems.find(it->GetGUIDLow()) == mAitems.end());
		mAitems[it->GetGUIDLow()] = it;
	}
	bool RemoveAItem(uint32 id)
	{
		ItemMap::iterator i = mAitems.find(id);
		if (i == mAitems.end())
		{
			return false;
		}
		mAitems.erase(i);
		return true;
	}
	AuctionEntryMap::iterator GetAuctionsBegin() {return mAuctions.begin();}
	AuctionEntryMap::iterator GetAuctionsEnd() {return mAuctions.end();}
    // trainer spells
    Trainerspell* GetTrainerspell(uint32 id) const
    {
        TrainerspellMap::const_iterator itr = mTrainerspells.find( id );
        if( itr != mTrainerspells.end( ) )
            return itr->second;
        return NULL;
    }
    void AddTrainerspell(Trainerspell *trainspell)
    {
        ASSERT( trainspell );
        ASSERT( mTrainerspells.find(trainspell->Id) == mTrainerspells.end() );
        mTrainerspells[trainspell->Id] = trainspell;
    }
    /*
	// Create Player Info
    void AddPlayerCreateInfo(PlayerCreateInfo *playerCreate)
    {
        ASSERT( playerCreate );
        mPlayerCreateInfo[playerCreate->index] = playerCreate;
    }
    PlayerCreateInfo* GetPlayerCreateInfo(uint8 race, uint8 class_) const
    {
        PlayerCreateInfoMap::const_iterator itr;
        for (itr = mPlayerCreateInfo.begin(); itr != mPlayerCreateInfo.end(); itr++)
        {
            if( (itr->second->race == race) && (itr->second->class_ == class_) )
                return itr->second;
        }
        return NULL;
    }
	*/

    // it's kind of db related, not sure where to put it
    uint64 GetPlayerGUIDByName(const char *name) const;
    bool GetPlayerNameByGUID(const uint64 &guid, std::string &name) const;

    // taxi code
    void AddTaxiNodes(TaxiNodes *taxiNodes)
    {
        ASSERT( taxiNodes );
        mTaxiNodes[taxiNodes->id] = taxiNodes;
    }
    void AddTaxiPath(TaxiPath *taxiPath)
    {
        ASSERT( taxiPath );
        mTaxiPath[taxiPath->id] = taxiPath;
    }
    void AddTaxiPathNodes(TaxiPathNodes *taxiPathNodes)
    {
        ASSERT( taxiPathNodes );
        vTaxiPathNodes.push_back(taxiPathNodes);
    }
    bool GetGlobalTaxiNodeMask( uint32 curloc, uint32 *Mask );
    uint32 GetNearestTaxiNode( float x, float y, float z, uint32 mapid );
    void GetTaxiPath( uint32 source, uint32 destination, uint32 &path, uint32 &cost);
    uint16 GetTaxiMount( uint32 id );
    void GetTaxiPathNodes( uint32 path, Path *pathnodes );

    //Corpse Stuff
    Corpse *GetCorpseByOwner(Player *pOwner);
    void SaveCorpses();

    //Gossip Stuff
    void AddGossipText(GossipText *pGText);
    GossipText *GetGossipText(uint32 ID);

    //Item Pages Stuff
    void AddItemPageText(ItemPageText *pIText);
    ItemPageText *GetItemPageText(uint32 ID);

    //Area Quests Stuff
	void AddAreaTriggerQuestPoint(AreaTriggerQuestPoint *pArea);
    AreaTriggerQuestPoint *GetAreaTriggerQuestPoint(uint32 ID);


    //Death stuff
    void AddGraveyard(GraveyardTeleport *pgrave);
    GraveyardMap::iterator GetGraveyardListBegin() { return mGraveyards.begin(); }
    GraveyardMap::iterator GetGraveyardListEnd() { return mGraveyards.end(); }

    // Serialization
    void LoadWorldSpawns();
	void LoadGameobjects();
    void LoadQuests();
    void LoadCreatureTemplates();
    void LoadGameobjectTemplates();
    void SaveCreatureNames();
    void LoadItemPrototypes();
	void LoadTrainerSpells();
    //void LoadPlayerCreateInfo();
    void LoadTaxiNodes();
    void LoadTaxiPath();
    void LoadTaxiPathNodes();
    void LoadCorpses();

    void LoadGossipText();
	void LoadItemPageText();

    void LoadAreaTriggerPoints();
    void LoadGraveyards();
	void LoadAuctions();
	void LoadAuctionItems();
	void LoadMailedItems();
	void LoadTrainerTeachSpells();

	// Work with World Map Areas and ZoneId (for spawning and for graveyards)
	//
	typedef vector<WorldMapArea> WorldMapAreaVector;
	WorldMapAreaVector	m_worldMapAreas[2];
	void LoadWorldMapArea();
	uint32 LookupZoneId (uint32 mapId, float x, float y);

	void SetHighestGuids();
    uint32 GenerateLowGuid(uint32 guidhigh);
	uint32 GenerateAuctionID();
	uint32 GenerateMailID();

	// Loot templates
	LootTemplateVectorMap	m_lootTemplates;
	void LoadLootTemplates();
	void LoadStaticLootTemplates();

	LootGOTemplateVectorMap	m_lootGOTemplates;
	void LoadGOLootTemplates();

	WorldLootTemplateVectorMap	m_WorldLootTemplates;
	void LoadWorldLoots();

	// Sell templates
	SellTemplateMap		m_sellTemplates;
	void LoadSellTemplates();

	friend class MapMgr;

protected:
	uint32 m_auctionid;
	uint32 m_mailid;
    // highest GUIDs, used for creating new objects
    uint32 m_hiCharGuid;
    uint32 m_hiCreatureGuid;
    uint32 m_hiItemGuid;
    uint32 m_hiGoGuid;
    uint32 m_hiDoGuid;
    //uint32 m_hiNameGuid;

    template<class T> HM_NAMESPACE::hash_map<uint32,T*>& _GetContainer();
	template<class T> HM_NAMESPACE::hash_map<uint32,T*>& _GetRecycle();
    template<class T> TYPEID _GetTypeId() const;

    ///// Object Tables ////
    // These tables are modified as creatures are created and destroyed in the world

    typedef HM_NAMESPACE::hash_map<uint32, Quest*> QuestMap;

    // Map of active characters in the game
    PlayerMap           mPlayers, mPlayersDeleted;

    // Map of active creatures in the game (and those deleted from the world)
    CreatureMap         mCreatures, mCreaturesDeleted;
public:
	uint32 GetCreaturesCount() { return mCreatures.size(); }
	uint16 TeachSpellID[65535];

protected:
    // Map of dynamic objects (and those deleted from the world)
    GameObjectMap       mGameObjects, mGameObjectsDeleted;

    // Map of dynamic objects (and those deleted from the world)
    DynamicObjectMap    mDynamicObjects, mDynamicObjectsDeleted;

    // Map of corpse objects
    CorpseMap           mCorpses, mCorpsesDeleted;

	//---------------------------------------------------
    // Group List
    GroupSet            mGroupSet;

    // Map of all item types in the game
    //ItemMap             mItems;

	// Map of auction item intances
	ItemMap				mAitems;

	// Map of mailed itesm
	ItemMap				mMitems;

    // Map of all item types in the game
    ItemPrototypeMap    mItemPrototypes;

	// Map of the trainer spells
	TrainerspellMap		mTrainerspells;

	// Map of auctioned items
	AuctionEntryMap		mAuctions;

    // map entry to a creature name
    //CreatureNameMap     mCreatureNames;
	CreatureTemplateMap	mCreatureTemplates;

	GameobjectTemplateMap mGameobjectTemplates;

    // Quest data
    QuestMap            mQuests;
	AreaTriggerMap	    mAreaTriggerMap;

    // Map of all starting infos needed for player creation
    //PlayerCreateInfoMap mPlayerCreateInfo;

    // Maps containing the infos for taxi paths
    TaxiNodesMap        mTaxiNodes;
    TaxiPathMap         mTaxiPath;
    TaxiPathNodesVec    vTaxiPathNodes;

    // Maps for Gossip and Pages stuff
    GossipTextMap       mGossipText;
	ItemPageTextMap     mItemPageText;

    // Death Stuff
    GraveyardMap        mGraveyards;
};

// According to C++ standard explicit template declarations should be in scope where ObjectMgr is.

template<> inline HM_NAMESPACE::hash_map<uint32,DynamicObject*>& ObjectMgr::_GetContainer<DynamicObject>()
    { return mDynamicObjects; }
template<> inline HM_NAMESPACE::hash_map<uint32,Creature*>& ObjectMgr::_GetContainer<Creature>()
    { return mCreatures; }
template<> inline HM_NAMESPACE::hash_map<uint32,Player*>& ObjectMgr::_GetContainer<Player>()
    { return mPlayers; }
template<> inline HM_NAMESPACE::hash_map<uint32,GameObject*>& ObjectMgr::_GetContainer<GameObject>()
    { return mGameObjects; }
template<> inline HM_NAMESPACE::hash_map<uint32,Corpse*>& ObjectMgr::_GetContainer<Corpse>()
    { return mCorpses; }

template<> inline HM_NAMESPACE::hash_map<uint32,DynamicObject*>& ObjectMgr::_GetRecycle<DynamicObject>()
	{ return mDynamicObjectsDeleted; }
template<> inline HM_NAMESPACE::hash_map<uint32,Creature*>& ObjectMgr::_GetRecycle<Creature>()
	{ return mCreaturesDeleted; }
template<> inline HM_NAMESPACE::hash_map<uint32,Player*>& ObjectMgr::_GetRecycle<Player>()
	{ return mPlayersDeleted; }
template<> inline HM_NAMESPACE::hash_map<uint32,GameObject*>& ObjectMgr::_GetRecycle<GameObject>()
	{ return mGameObjectsDeleted; }
template<> inline HM_NAMESPACE::hash_map<uint32,Corpse*>& ObjectMgr::_GetRecycle<Corpse>()
	{ return mCorpsesDeleted; }

template<> inline TYPEID ObjectMgr::_GetTypeId<DynamicObject>() const
    { return TYPEID_DYNAMICOBJECT; }
template<> inline TYPEID ObjectMgr::_GetTypeId<GameObject>() const
    { return TYPEID_GAMEOBJECT; }
template<> inline TYPEID ObjectMgr::_GetTypeId<Creature>() const
    { return TYPEID_UNIT; }
template<> inline TYPEID ObjectMgr::_GetTypeId<Player>() const
    { return TYPEID_PLAYER; }
template<> inline TYPEID ObjectMgr::_GetTypeId<Corpse>() const
    { return TYPEID_CORPSE; }

#define objmgr ObjectMgr::getSingleton()

#endif
