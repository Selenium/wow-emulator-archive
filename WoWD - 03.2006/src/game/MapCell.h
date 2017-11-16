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
// MapCell.h
//

#ifndef __MAP_CELL_H
#define __MAP_CELL_H

#include "Common.h"
#include "Object.h"
#include "Log.h"
#include "Objectmgr.h"
#include "MapMgr.h"

class MapCell
{
public:
    MapCell() { };
    ~MapCell();

    typedef std::set<Object*> ObjectSet;

    //Init
    void Init(uint32 x, uint32 y, uint32 mapid, MapMgr *mapmgr);

    //Object Managing
    void AddObject(Object *obj); 
    void RemoveObject(Object *obj);
    bool HasObject(Object *obj) { return !(_objects.find(obj) == _objects.end()); }
    bool HasPlayers() { return ((_playerCount > 0) ? true : false); }
    uint32 GetObjectCount() { return _objects.size(); }
    void RemoveObjects();
    ObjectSet::iterator Begin() { return _objects.begin(); }
    ObjectSet::iterator End() { return _objects.end(); }

    //State Related
    void SetActivity(bool state);
    void SetLoadState(bool state) { _loaded = state; }
    bool IsActive() { return _active; }
    bool IsLoaded() { return _loaded; }
    time_t GetWentIdleTime() { return _timeWentIdle; }

    //Position Related
    uint32 GetX() { return _x; }
    uint32 GetY() { return _y; }
    MapMgr* GetMapMgr() { return _mapmgr; }

    //Object Loading Managing
    void LoadObjects();
    void Unload();

private:
    ObjectSet _objects;
    bool _active, _loaded;
    uint32 _playerCount;
    uint32 _x, _y, _mapid;
    time_t _timeWentIdle;
    MapMgr* _mapmgr;
};

#endif
