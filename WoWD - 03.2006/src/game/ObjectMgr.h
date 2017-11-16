// Copyright (C) 2004 WoW Daemon
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.

#ifndef _OBJECTMGR_H
#define _OBJECTMGR_H

#include "Log.h"
#include "Object.h"
#include "Item.h"
#include "Container.h"
#include "Creature.h"
#include "Player.h"
#include "DynamicObject.h"
#include "GameObject.h"
#include "Corpse.h"
#include "Quest.h"
#include "Path.h"
#include "ItemPrototype.h"
#include "QuestMgr.h"
#include "NPCHandler.h"
#include "MiscHandler.h"
#include "Database/DatabaseEnv.h"
#include "Mail.h"
#include "Spell.h"
#include "Guild.h"
#include "Raid.h"

enum HIGHGUID {
    HIGHGUID_ITEM          = 0x40000000,
    HIGHGUID_CONTAINER     = 0x40000000,
    HIGHGUID_UNIT          = 0xF0001000,
    HIGHGUID_PLAYER        = 0x00000000,
    HIGHGUID_WAYPOINT      = 0x0000F000,
    HIGHGUID_GAMEOBJECT    = 0xF0007000,
    HIGHGUID_DYNAMICOBJECT = 0xF000A000,
    HIGHGUID_CORPSE        = 0xF0007000
};

struct GM_Ticket
{
    uint64 guid;
    std::string name;
    uint32 level;
    uint32 type;
    float posX;
    float posY;
    float posZ;
    std::string message;
    uint32 timestamp;
};

class Group;
class Path;

#define MAX_CONTINENTS 500

class ObjectMgr : public Singleton < ObjectMgr >
{
public:
    ObjectMgr();
    ~ObjectMgr();

    // objects
    typedef HM_NAMESPACE::hash_map<uint32, Player*> PlayerMap;
    typedef HM_NAMESPACE::hash_map<uint32, Creature*> CreatureMap;
    typedef HM_NAMESPACE::hash_map<uint32, DynamicObject*> DynamicObjectMap;
    typedef HM_NAMESPACE::hash_map<uint32, GameObject*> GameObjectMap;
    typedef HM_NAMESPACE::hash_map<uint32, Corpse*> CorpseMap;
    // other objects
    typedef std::set< Group * > GroupSet;
    typedef std::set< Raid * > RaidSet;
    typedef HM_NAMESPACE::hash_map<uint32, Item*> ItemMap;
    typedef HM_NAMESPACE::hash_map<uint32, GossipText*> GossipTextMap;
    typedef HM_NAMESPACE::hash_map<uint32, GossipNpc*> GossipNpcMap;
    typedef HM_NAMESPACE::hash_map<uint32, GraveyardTeleport*> GraveyardMap;
    typedef HM_NAMESPACE::hash_map<uint32, PlayerInfo*> PlayerNameMap;
    typedef HM_NAMESPACE::hash_map<uint32, CreatureInfo*> CreatureNameMap;
	typedef HM_NAMESPACE::hash_map<uint32, GameObjectInfo*> GameObjectNameMap;
	typedef HM_NAMESPACE::hash_map<uint32, CreatureSpawnTemplate*> CreatureSpawnTemplateMap;
    typedef HM_NAMESPACE::hash_map<uint32, ItemPrototype*> ItemPrototypeMap;
	typedef HM_NAMESPACE::hash_map<uint32, AuctionEntry*> AuctionEntryMap;
    typedef HM_NAMESPACE::hash_map<uint32, Trainerspell*> TrainerspellMap;
    typedef HM_NAMESPACE::hash_map<uint32, PlayerCreateInfo*> PlayerCreateInfoMap;
    typedef HM_NAMESPACE::hash_map<uint32, Faction*> FactionMap;
    typedef HM_NAMESPACE::hash_map<uint32, Guild*> GuildMap;
    typedef HM_NAMESPACE::hash_map<uint32, TaxiNodes*> TaxiNodesMap;
    typedef HM_NAMESPACE::hash_map<uint32, TaxiPath*> TaxiPathMap;
	typedef std::vector<TaxiPathNodes*> TaxiPathNodesVec;
	typedef HM_NAMESPACE::hash_map<uint32, TeleportCoords*> TeleportMap;
	typedef HM_NAMESPACE::hash_map<uint32, skilllinespell*> SLMap;
    std::list<GM_Ticket*> GM_TicketList;
    std::list<guildCharter*> Guild_CharterList;
	typedef HM_NAMESPACE::hash_map<uint32, PvPArea*> PvPAreaMap;

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
    T* GetObject(const uint32 &guid)
    {
        const HM_NAMESPACE::hash_map<uint32, T*> &container = _GetContainer<T>();
        typename HM_NAMESPACE::hash_map<uint32, T*>::const_iterator itr =
            container.find(guid);
        if(itr == container.end() || itr->second->GetGUIDLow() != guid)
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
    template <class T>
    bool RemoveObject(T *obj)
    {
        HM_NAMESPACE::hash_map<uint32, T*> &container = _GetContainer<T>();
        typename HM_NAMESPACE::hash_map<uint32, T*>::iterator i = container.find(obj->GetGUIDLow());
        if(i == container.end())
            return false;
        container.erase(i);
        return true;
    }

    Player* GetPlayer(const char* name);
	Player* GetPlayer(uint64 guid);

	Creature* GetCreature(uint64 guid);

	//Creature Templates
	void AddCreatureSpawnTemplate(CreatureSpawnTemplate *ct);
    CreatureSpawnTemplate* GetCreatureSpawnTemplate(uint32 entryid) const;
	bool RemoveCreatureSpawnTemplate(uint32 entryid);

    // Groups
    Group * GetGroupByLeader(const uint64 &guid) const;
    void AddGroup(Group* group) { mGroupSet.insert( group ); }
    void RemoveGroup(Group* group) { mGroupSet.erase( group ); }

    // Raid
    Raid * GetRaidByLeader(const uint64 &guid) const;
    void AddRaid(Raid* raid) { mRaidSet.insert( raid ); }
    void RemoveRaid(Raid* raid) { mRaidSet.erase( raid ); }

	void AddAuction(AuctionEntry *ah);
    AuctionEntry* GetAuction(uint32 id) const;
	bool RemoveAuction(uint32 id);

    // player names
    void AddPlayerName(PlayerInfo *pn);
    PlayerInfo *GetPlayerName( uint64 guid );
    void RemovePlayerName( uint64 guid );

    // creature names
    uint32 AddCreatureName(const char* name);
    uint32 AddCreatureName(const char* name, uint32 displayid);
    void AddCreatureName(uint32 id, const char* name);
    void AddCreatureName(uint32 id, const char* name, uint32 displayid);
    void AddCreatureName(CreatureInfo *cinfo);
    CreatureInfo *GetCreatureName( uint32 id );
	
	//Sub names
	uint32 AddCreatureSubName(const char* name, const char* subname, uint32 displayid);

    // item prototypes
    ItemPrototype* GetItemPrototype(uint32 id) const;
    void AddItemPrototype(ItemPrototype *itemProto);
	Item* GetMItem(uint32 id);
	void AddMItem(Item* it);
	bool RemoveMItem(uint32 id);
	Item* GetAItem(uint32 id);
	void AddAItem(Item* it);
	bool RemoveAItem(uint32 id);
	AuctionEntryMap::iterator GetAuctionsBegin() {return mAuctions.begin();}
	AuctionEntryMap::iterator GetAuctionsEnd() {return mAuctions.end();}

    // trainer spells
    Trainerspell* GetTrainerspell(uint32 id) const;
    void AddTrainerspell(Trainerspell *trainspell);

    // Create Player Info
    void AddPlayerCreateInfo(PlayerCreateInfo *playerCreate);
    PlayerCreateInfo* GetPlayerCreateInfo(uint8 race, uint8 class_) const;

    // it's kind of db related, not sure where to put it
    uint64 GetPlayerGUIDByName(const char *name) const;
    bool GetPlayerNameByGUID(const uint64 &guid, std::string &name) const;

    // DK:Guild
    void AddGuild(Guild *pGuild);
    uint32 GetTotalGuildCount();
    bool RemoveGuild(uint32 guildId);
    Guild* GetGuild(uint32 guildId);
    Guild* GetGuildByLeaderGuid(uint64 leaderGuid);
    Guild* GetGuildByGuildName(std::string guildName);
    
    // DK:Charter
    void AddCharter(guildCharter* gc);
    void DeleteCharter(uint64 leaderGuid);
    guildCharter *GetGuildCharter(uint64 leaderGuid);
    guildCharter *GetGuildCharterByCharterGuid(uint32 itemGuid);

    // Faction
    uint32 m_highest_fact;
    void AddFaction(Faction* fact);
    Faction* GetFaction(uint8 race, uint8 id);

    // taxi code
    void AddTaxiNodes(TaxiNodes *taxiNodes);
    void AddTaxiPath(TaxiPath *taxiPath);
    void AddTaxiPathNodes(TaxiPathNodes *taxiPathNodes);
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
    void AddGossip(GossipNpc *pGossip);
    GossipText *GetGossipText(uint32 ID);
    GossipNpc *GetGossipByGuid(uint32 guid);

    //Death stuff
    void AddGraveyard(GraveyardTeleport *pgrave);
    GraveyardMap::iterator GetGraveyardListBegin() { return mGraveyards.begin(); }
    GraveyardMap::iterator GetGraveyardListEnd() { return mGraveyards.end(); }

	//Teleport Stuff
	void AddTeleportCoords(TeleportCoords* TC);
    TeleportCoords* GetTeleportCoords(uint32 id) const;

    // Gm Tickets
    void AddGMTicket(GM_Ticket *ticket);
    void remGMTicket(uint64 guid);
    GM_Ticket* GetGMTicket(uint64 guid);

	//GameObject names
	GameObjectInfo *GetGameObjectName(uint32 ID);
	void AddGameObjectName( GameObjectInfo *goinfo);

	skilllinespell* GetSpellSkill(uint32 id);

	//PVP
	void AddPvPArea(PvPArea* pvparea);
	PvPArea* GetPvPArea(uint32 AreaId);

    // Serialization
    void LoadCreatures();
    Creature* LoadCreature(uint32 guid);
	void LoadGameObjects();
    GameObject* LoadGameObject(uint32 guid);
    void LoadQuests();
    void LoadPlayerNames();
    void LoadCreatureNames();
	void LoadGameObjectNames();
    void SaveCreatureNames();
    void LoadItemPrototypes();
	void LoadTrainerSpells();
    void LoadPlayerCreateInfo();
    void LoadFaction();
    void LoadGuilds();
    void LoadCharters();
    void SaveCharters(uint64 leaderGuid);
    void LoadTaxiNodes();
    void LoadTaxiPath();
    void LoadTaxiPathNodes();
    void LoadCorpses();
    Corpse* LoadCorpse(uint32 guid);
    void LoadGossipText();
    void LoadGossips();
    void LoadGraveyards();
    void LoadGMTickets();
    void SaveGMTicket(uint64 guid);
	void LoadAuctions();
	void LoadAuctionItems();
	void LoadMailedItems();
	void LoadCreatureSpawnTemplates();
	void LoadSpellSkills();
	void LoadPvPAreas();

    void LoadCellObjects(uint32 x, uint32 y, uint32 sizeX, uint32 sizeY, int32 minX, int32 minY, uint32 map);
    void LoadCorpses(int32 startX, int32 endX, int32 startY, int32 endY, int32 map);
    void LoadCreatures(int32 startX, int32 endX, int32 startY, int32 endY, int32 map);
	void LoadGameObjects(int32 startX, int32 endX, int32 startY, int32 endY, int32 map);

    void SetHighestGuids();
    uint32 GenerateLowGuid(uint32 guidhigh);
	uint32 GenerateAuctionID();
	uint32 GenerateMailID();

protected:
	uint32 m_auctionid;
	uint32 m_mailid;
    // highest GUIDs, used for creating new objects
    uint32 m_hiCharGuid;
    uint32 m_hiCreatureGuid;
    uint32 m_hiItemGuid;
    uint32 m_hiGoGuid;
    uint32 m_hiDoGuid;
    uint32 m_hiNameGuid;
	uint32 m_hiGoNameGuid;

    template<class T> HM_NAMESPACE::hash_map<uint32,T*>& _GetContainer();
    template<class T> TYPEID _GetTypeId() const;

    ///// Object Tables ////
    // These tables are modified as creatures are created and destroyed in the world

    // Map of active characters in the game
    PlayerMap           mPlayers;

    // Map of active creatures in the game
    CreatureMap         mCreatures;

    // Map of dynamic objects
    GameObjectMap       mGameObjects;

    // Map of dynamic objects
    DynamicObjectMap    mDynamicObjects;

    // Map of corpse objects
    CorpseMap           mCorpses;

    // Group List
    GroupSet            mGroupSet;

    // Raid List
    RaidSet             mRaidSet;

    // Map of all item types in the game
    ItemMap             mItems;

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

    // map entry of player names
    PlayerNameMap       mPlayerNames;

    // map entry to a creature name
    CreatureNameMap     mCreatureNames;

	//Map entry to a gameobject query name
	GameObjectNameMap   mGameObjectNames;

    // map entry to a creature template
    CreatureSpawnTemplateMap mCreatureSpawnTemplates;

    // Map of all starting infos needed for player creation
    PlayerCreateInfoMap mPlayerCreateInfo;

    // Map of Factions
    FactionMap mFactions;

    // DK: Map of all Guild's
    GuildMap mGuild;

    // Maps containing the infos for taxi paths
    TaxiNodesMap        mTaxiNodes;
    TaxiPathMap         mTaxiPath;
	TaxiPathNodesVec    vTaxiPathNodes;

    // Maps for Gossip stuff
    GossipTextMap       mGossipText;
    GossipNpcMap        mGossipNpc;

    // Death Stuff
    GraveyardMap        mGraveyards;

	// Teleport Stuff
	TeleportMap			mTeleports;

	SLMap				mSpellSkills;

	//PVP Stuff
	PvPAreaMap			mPvPAreas;
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
