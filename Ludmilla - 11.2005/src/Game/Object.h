// Copyright (C) 2004 WoWD Team

#ifndef _OBJECT_H
#define _OBJECT_H

#include "UpdateMask.h"
#include "World.h"

//#include <hash_set>

// TODO: fix that type mess

enum TYPE {
    TYPE_OBJECT         = 1,
    TYPE_ITEM           = 2,
    TYPE_CONTAINER      = 4,
    TYPE_UNIT           = 8,
    TYPE_PLAYER         = 16,
    TYPE_GAMEOBJECT     = 32,
    TYPE_DYNAMICOBJECT  = 64,
    TYPE_CORPSE         = 128,
    TYPE_AIGROUP        = 256,
    TYPE_AREATRIGGER    = 512
};

enum TYPEID {
    TYPEID_OBJECT        = 0,
    TYPEID_ITEM          = 1,
    TYPEID_CONTAINER     = 2,
    TYPEID_UNIT          = 3,
    TYPEID_PLAYER        = 4,
    TYPEID_GAMEOBJECT    = 5,
    TYPEID_DYNAMICOBJECT = 6,
    TYPEID_CORPSE        = 7,
    TYPEID_AIGROUP       = 8,
    TYPEID_AREATRIGGER   = 9
};

class WorldPacket;
class UpdateData;
class ByteBuffer;
class WorldSession;
class Player;
class MapCell;
class Object;

typedef std::set<Object*> ObjectSet;
typedef ObjectSet::iterator ObjectSetIterator;

//--------------------------------------------------------------------
typedef uint64 Guid;

typedef std::set<Guid> GuidSet;
typedef GuidSet::iterator GuidSetIterator;

typedef std::vector<Guid> GuidVector;
typedef GuidVector::iterator GuidVectorIterator;

typedef std::list<Guid> GuidList;
typedef GuidList::iterator GuidListIterator;

//====================================================================
//  Object
//  Base object for every item, unit, player, corpse, container, etc
//====================================================================
class Object
{
public:
    virtual ~Object ( );

    virtual void Update ( float time ) { }

    bool IsInWorld() { return m_inWorld; }
    virtual void AddToWorld() { m_inWorld = true; }
    virtual void RemoveFromWorld() { m_inWorld = false; }

	bool HasReputationForFaction( uint8 FactId );
	bool SetReputationForFaction( uint8 FactId, uint32 RepVal );
	uint32 GetReputationForFaction( uint8 FactId );

    // guid always comes first
    uint64 GetGUID() { return *((uint64*)m_uint32Values); }

	bool FailedToLoad() { return m_uint32Values == NULL; }

    // should be removed later
    uint32 GetGUIDLow() { return m_uint32Values[0]; }
    uint32 GetGUIDHigh() { return m_uint32Values[1]; }

    // type
    uint8 GetTypeId() { return m_objectTypeId; }
	uint8 m_reputation[64];
	uint32 m_reputationValues[64];

//    void BuildUpdateMsgHeader( WorldPacket *data );

    //! This includes any nested objects we have, inventory for example.
    virtual void BuildCreateUpdateBlockForPlayer( UpdateData *data, Player *target );
    void BuildValuesUpdateBlockForPlayer( UpdateData *data, Player *target );
    void BuildOutOfRangeUpdateBlock( UpdateData *data );
    void BuildMovementUpdateBlock( UpdateData * data, uint32 flags = 0 );

    virtual void DestroyForPlayer( Player *target );

    void BuildHeartBeatMsg( WorldPacket *data );
    void BuildTeleportAckMsg( WorldPacket *data, float x, float y, float z, float ang);

    bool SetPosition( float newX, float newY, float newZ, float newOrientation, bool allowPorting = false );

    float GetPositionX() { return m_positionX; }
    float GetPositionY() { return m_positionY; }
    float GetPositionZ() { return m_positionZ; }
    float GetOrientation() { return m_orientation; }

    //! Only for MapMgr use
    MapCell * GetMapCell() { return m_mapCell; }
	MapMgr * GetMapMgr() { return m_mapMgr; }
    //! Only for MapMgr use
    void SetMapCell(MapCell* cell) { m_mapCell = cell; }

    uint32 GetTaximask( uint8 index ) { return m_taximask[index]; }
    void SetTaximask( uint8 index, uint32 value ) { m_taximask[index] = value; }

    void SetMapId(uint32 newMap) { m_mapId = newMap; }
    void SetZoneId(uint32 newZone) { m_zoneId = newZone; }

    uint32 GetMapId() { return m_mapId; }
    uint32 GetZoneId() { return m_zoneId; }

    //! Get uint32 property
    uint32 GetUInt32Value (uint32 index)
    {
        ASSERT( index < m_valuesCount );
        return m_uint32Values[ index ];
    }

    //! Get uint64 property
    uint64 GetUInt64Value (uint32 index)
    {
        ASSERT( index + 1 < m_valuesCount );
        return *((uint64*)&(m_uint32Values[ index ]));
    }

    //! Get float property
    float GetFloatValue (uint32 index)
    {
        ASSERT( index < m_valuesCount );
        return m_floatValues[ index ];
    }

    //! Set uint32 property
    void SetUInt32Value (uint32 index, uint32 value );
	void ModifyUInt32Value (uint32 index, int32 change );

    //! Set uint64 property
    void SetUInt64Value (uint32 index, uint64 value );

    //! Set float property
    void SetFloatValue (uint32 index, float value);
	void ModifyUFloatValue (uint32 index, float change );

    void SetFlag (uint32 index, uint32 newFlag);

    void RemoveFlag (uint32 index, uint32 oldFlag);

    bool HasFlag (uint32 index, uint32 flag)
    {
        ASSERT( index < m_valuesCount );
        return (m_uint32Values[ index ] & flag) != 0;
    }

    void ClearUpdateMask( )
    {
        m_updateMask.Clear();
        m_objectUpdated = false;
    }

    float GetDistanceSq(Object* obj)
    {
        //ASSERT(obj->GetMapId() == m_mapId);
		if (obj == NULL || obj->GetMapId() != m_mapId) return 50000.0f;

        float dx  = obj->GetPositionX() - GetPositionX();
        float dy  = obj->GetPositionY() - GetPositionY();
        float dz  = obj->GetPositionZ() - GetPositionZ();

        return ((dx*dx) + (dy*dy) + (dz*dz));
    }

    float GetDistance2dSq(Object* obj)
    {
        ASSERT(obj->GetMapId() == m_mapId);

        float dx  = obj->GetPositionX() - GetPositionX();
        float dy  = obj->GetPositionY() - GetPositionY();

        return (dx*dx) + (dy*dy);
    }

	//------------------------------------------------------
    // In-range object management, not sure if we need it
	//------------------------------------------------------
	/*
    bool IsInRangeSet(Object* pObj) { return !(m_objectsInRange.find(pObj) == m_objectsInRange.end()); }
    virtual void AddInRangeObject(Object* pObj) { ASSERT (pObj != (Object *)this); m_objectsInRange.insert(pObj); }
    virtual void RemoveInRangeObject(Object* pObj) { m_objectsInRange.erase(pObj); }
    void ClearInRangeSet() { m_objectsInRange.clear(); }
	bool HasObjectsInRange() { return ! m_objectsInRange.empty(); }
	bool NoObjectsInRange() { return ! m_objectsInRange.empty(); }

    inline ObjectSet::iterator GetInRangeSetBegin() { return m_objectsInRange.begin(); }
    inline ObjectSet::iterator GetInRangeSetEnd() { return m_objectsInRange.end(); }
	*/

	//-------------------------------------------------------
	// In-range object set replacement functions
	//-------------------------------------------------------
	int MapCellX();
	int MapCellY();

	/*inline bool IsInRangeSet(Object* pObj) {
		return (abs (MapCellX() - pObj->MapCellX()) <= 1 &&
				abs (MapCellY() - pObj->MapCellY()) <= 1);
	}*/
	//virtual void AddInRangeObject (Object* pObj) {}
	//virtual void RemoveInRangeObject (Object* pObj) {}

    void SendMessageToSet(WorldPacket *data, bool self);

    //! Fill values with data from a space seperated string of uint32s.
    void LoadValues (const char* data);
    void LoadTaxiMask (const char* data);
	void LoadReputation (const char* data);

    uint16 GetValuesCount() { return m_valuesCount; }

    //! Add object to map
    void PlaceOnMap();
    //! Remove object from map
    void RemoveFromMap();

	virtual bool IsPathWalker() { return 0; }

	//-----------------------------
	// Some Selected Object fields
	//-----------------------------
	uint32 GetEntry() { return GetUInt32Value (OBJECT_FIELD_ENTRY); }
	
	uint32 GetObjectType() { return GetUInt32Value (OBJECT_FIELD_TYPE); }
	
	float GetScale() { return GetFloatValue (OBJECT_FIELD_SCALE_X); }
	void SetScale (float value) { SetFloatValue (OBJECT_FIELD_SCALE_X, value); }

	//-----------------------------
	// Some type detection facilities
	//-----------------------------
	virtual bool CanSee (Object *npc) { return true; }

	inline bool isUnit() { return GetTypeId() == TYPEID_UNIT; }
	inline bool isNotUnit() { return GetTypeId() != TYPEID_UNIT; }
	inline bool isPlayer() { return GetTypeId() == TYPEID_PLAYER; }
	inline bool isNotPlayer() { return GetTypeId() != TYPEID_PLAYER; }

	inline bool isContainer() { return GetTypeId() == TYPEID_CONTAINER; }

	virtual bool isVendor()       { return false; };
	virtual bool isTrainer()      { return false; };
	virtual bool isQuestGiver()   { return false; };
	virtual bool isGossip()       { return false; };
	virtual bool isTaxi()         { return false; };
	virtual bool isGuildMaster()  { return false; };
	virtual bool isBattleMaster() { return false; };
	virtual bool isBanker()       { return false; };
	virtual bool isInnkeeper()    { return false; };
	virtual bool isSpiritHealer() { return false; };
	virtual bool isTabardVendor() { return false; };
	virtual bool isAuctioner()    { return false; };
	virtual bool isArmorer()      { return false; };

	virtual bool isAlive() { return true; };
	virtual bool isDead() { return false; };

protected:
    Object ( );

    void _InitValues()
    {
        m_uint32Values = new uint32[ m_valuesCount ];

        WPAssert(m_uint32Values);
        memset(m_uint32Values, 0, m_valuesCount*sizeof(uint32));

        m_updateMask.SetCount(m_valuesCount);
        ClearUpdateMask();
    }

    void _Create (uint32 guidlow, uint32 guidhigh);
    void _Create (uint32 guidlow, uint32 guidhigh, uint32 mapid, float x, float y, float z, float ang);

    //! Mark values that need updating for specified player.
    virtual void _SetUpdateBits(UpdateMask *updateMask, Player *target);
    //! Mark values that player should get when he/she/it sees object for first time.
    virtual void _SetCreateBits(UpdateMask *updateMask, Player *target);

    void _BuildMovementUpdate( ByteBuffer *data, uint32 flags, uint32 flags2 );
    void _BuildValuesUpdate( ByteBuffer *data, UpdateMask *updateMask  );

    //! Types. Bitmasked together by subclasses.
    uint16 m_objectType;
    //! Type id.
    uint8 m_objectTypeId;

    //! Zone id.
    uint32 m_zoneId;
    //! Continent/map id.
    uint32 m_mapId;
    //! Map manager
    MapMgr *m_mapMgr;
    //! Current map cell
    MapCell *m_mapCell;

    // TODO: use vectors here
    float m_positionX;
    float m_positionY;
    float m_positionZ;
    float m_orientation;
    uint32 m_taximask[8];

    //! Blizzard seem to send those for all object types. weird.
    float m_walkSpeed;
    float m_runSpeed;
    float m_backWalkSpeed;
    float m_swimSpeed;
    float m_backSwimSpeed;
    float m_turnRate;

    //! TODO: Should be removed later.
    float m_minZ;

    //! Object properties.
    union {
        uint32 *m_uint32Values;
        float *m_floatValues;
    };

    //! Number of properties
    uint16 m_valuesCount;

    //! List of object properties that need updating.
    UpdateMask m_updateMask;

    //! True if object exists in world
    bool m_inWorld;

    //! True if object was updated
    bool m_objectUpdated;

    //! Set of Objects in range.
    //! TODO: that functionality should be moved into WorldServer.
    //ObjectSet m_objectsInRange;
};

inline float _CalcDistance (float sX, float sY, float sZ, float dX, float dY, float dZ)
{
	return sqrt((dX-sX)*(dX-sX)+(dY-sY)*(dY-sY)+(dZ-sZ)*(dZ-sZ));
}
inline float _SquareDistance (float sX, float sY, float sZ, float dX, float dY, float dZ)
{
	return (dX-sX)*(dX-sX)+(dY-sY)*(dY-sY)+(dZ-sZ)*(dZ-sZ);
}


#endif

