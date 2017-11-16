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

//
// MapMgr.h
//

#ifndef __MAPMGR_H
#define __MAPMGR_H

#include "MapCell.h"
#include "CellHandler.h"

class Object;
class MapCell;
//class CellHandler;

// Distance a Player can "see" other objects and receive updates from them
#define UPDATE_DISTANCE 79.1

enum MapMgrTimers
{
    MMUPDATE_OBJECTS = 0,
    MMUPDATE_SESSIONS = 1,
    MMUPDATE_FIELDS = 2,
    MMUPDATE_IDLE_OBJECTS = 3,
    MMUPDATE_ACTIVE_OBJECTS = 4,
    MMUPDATE_COUNT = 5
};

class MapMgr : public CellHandler <MapCell>
{
public:
    MapMgr(Map *map, uint32 mapid);
    ~MapMgr();

    typedef HM_NAMESPACE::hash_map<uint64, Object*> ObjectMap;

    void AddObject(Object *obj);
    void RemoveObject(Object *obj);
    void ChangeObjectLocation(Object *obj); // update inrange lists

    ObjectMap::iterator GetObjectsBegin() { return _objects.begin(); }
    ObjectMap::iterator GetObjectsEnd() { return _objects.end(); }

    //! Mark object as updated
    void ObjectUpdated(Object *obj)
    {
        ASSERT(_updatedObjects.find(obj) == _updatedObjects.end());
        _updatedObjects.insert(obj);
    }

    void Update(time_t diff);
    void UpdateCellActivity(uint32 x, uint32 y, int radius);
protected:

    //! Collect and send updates to clients
    void _UpdateObjects();

private:
    //! Objects that exist on map
    ObjectMap _objects;

    uint32 _mapId;

    std::set<MapCell*> _idleCells, _activeCells;

    typedef std::set<Object*> ObjectSet;
    ObjectSet _updatedObjects;
    IntervalTimer _timers[MMUPDATE_COUNT];

    bool _CellActive(uint32 x, uint32 y);
};

#endif
