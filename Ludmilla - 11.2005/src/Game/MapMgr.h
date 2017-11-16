//
// MapMgr.h
//

#ifndef __MAPMGR_H
#define __MAPMGR_H

class Object;
class MapCell;

// Distance a Player can "see" other objects and receive updates from them
//#define UPDATE_DISTANCE 155.8
//#define UPDATE_DISTANCE 60

#define MAPMGR_CELL_SIZE	50

enum MapMgrTimers
{
    MMUPDATE_OBJECTS = 0,
    MMUPDATE_SESSIONS,
    MMUPDATE_FIELDS,
    MMUPDATE_COUNT
};

//=============================================================================
// Helper Class to easy do iterations over map area around object
//=============================================================================
class MapRangeIterator
{
private:
	Object	*m_center;
	int		m_fromX, m_toX, m_toY;
	int		m_X, m_Y;
	MapMgr  *m_mapMgr;
	MapCell *m_cell;
	ObjectSetIterator m_iter;

	inline Object * GetObject() {
		//if (m_iter == m_cell->End()) return NULL;
		return *m_iter;
	}
public:
	MapRangeIterator (Object *center);

	//bool End() {
	//	return m_X == m_toX && m_Y == m_toY && m_iter == m_cell->End();
	//}

	Object * Advance();
};

class MapMgr
{
	friend class Object;
	friend class MapRangeIterator;

public:
    MapMgr(uint32 mapid);
    ~MapMgr();

    typedef HM_NAMESPACE::hash_map<uint64, Object*> ObjectMap;

	// Called for every object or unit entering map area
    void AddObject (Object *obj);

	// Called for every object or unit leaving map area
	void RemoveObject (Object *obj);

	// Called for moving players and units
	void ChangeObjectLocation (Object *obj, int32 oldX, int32 oldY);

    //ObjectMap::iterator GetObjectsBegin() { return _objects.begin(); }
    //ObjectMap::iterator GetObjectsEnd() { return _objects.end(); }

    //! Mark object as updated
    void ObjectUpdated(Object *obj)
    {
        ASSERT(_updatedObjects.find(obj) == _updatedObjects.end());
        _updatedObjects.insert(obj);
    }

    void Update(time_t diff);
	
	// Scans area around for friendly creatures that may want to share my aggro
	void ScanForFriends (Creature *caller, float scanRadius, ObjectSet &friends);

	inline bool HasActiveObjects() {
		return ! _activeGuids.empty();
	}
	// Calls Update for every active registered object on this map, removing invalid guids
	void UpdateActiveObjects (uint32 diff);

protected:

    //! Collect and send updates to clients
    void _UpdateObjects();
	
	// Helper function called by ChangeObjectLocation when player leaves map cell
	void _PlayerLeftCell (Player *player, MapCell &empty, UpdateData &playerData, WorldPacket &packet);

	// Helper function called by ChangeObjectLocation when player enters map cell
	void _PlayerEnteredCell (Player *player, MapCell &cell, UpdateData &data,
		UpdateData &playerData, WorldPacket &packet);

	void _MobEnteredCell (Object *obj, MapCell &cell, UpdateData &playerData, WorldPacket &packet);
	void _MobLeftCell (Object *obj, MapCell &cell, UpdateData &playerData, WorldPacket &packet);

	// Set of GUID numbers of all mobs in the world surrounded by players, so these
	// mobs have CPU time for thinking. When last player leaves map cell with active
	// mob, GUID of this mob gets removed from this set and it hibernates conserving
	// CPU power and waiting for players.
	//
	GuidSet		_activeGuids;

	inline bool IsGuidActivated (Guid id) {
		return _activeGuids.find (id) != _activeGuids.end();
	}
	inline void ActivateGuid (Guid id) {
		_activeGuids.insert (id);
		//Log::getSingleton().outDebug ("Activated Guid %I64X, now active %d total", id, (int32)_activeGuids.size());
	}
	inline void HibernateGuid (Guid id) {
		//GuidSetIterator iter = _activeGuids.find (id);
		//if (iter != _activeGuids.end())
		_activeGuids.erase (id);
		//Log::getSingleton().outDebug ("Hibernated Guid %I64X, %d left active", id, (int32)_activeGuids.size());
	}

	friend class ChatHandler;
	int32 _minX, _minY, _minZ, _maxX, _maxY, _maxZ;

private:
	// Inactive mobs located here and alive, but ready to join the world
	//ObjectMap _inactive;

    //uint32 _cellSize;
	
	//enum { NUM_CELLS = 400 };

	int32 _sizeX, _sizeY;
	int32 _numCellsX, _numCellsY;

    MapCell **_cells;

    uint32 _mapId;

	IntervalTimer _timers[MMUPDATE_COUNT];

	//! Objects that exist on map
	//ObjectMap _objects;
    ObjectSet _updatedObjects;
};

#endif