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
// Map.h
//

#ifndef __MAP_H
#define __MAP_H

#include "Common.h"
#include "MapMgr.h"
#include "TemplateMgr.h"
#include "Log.h"

class Map
{
public:
    Map(uint32 mapid)
    {
        //Todo: Get map positions
        //      Create terrain manager
        sLog.outDetail("Creating Map %d", mapid);
        _template = new TemplateMgr(this, mapid);
        _instance = new MapMgr(this, mapid);
    }
    
    ~Map()
    {
        delete _template;
        delete _instance;
        //delete _terrain;
    }

    inline MapMgr* GetInstance() { return _instance; }
    inline TemplateMgr* GetTemplate() { return _template; }
    //inline TerrainMgr* GetTerrain() { return _terrain; }
private:
    TemplateMgr*    _template;
    MapMgr*         _instance; //TODO: support instances
    //TerrainMgr*   _terrain;

};

#endif
