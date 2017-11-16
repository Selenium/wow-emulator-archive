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
// WorldCreator.cpp
//

#include "WorldCreator.h"

initialiseSingleton( WorldCreator );

WorldCreator::WorldCreator()
{
    //Create the two main maps
    _CreateMap(0);
    _CreateMap(1);
}

WorldCreator::~WorldCreator()
{
    std::map<uint32, Map*>::iterator it;

    for(it = _maps.begin(); it != _maps.end(); it++)
    {
        delete it->second;
    }
}

Map* WorldCreator::_CreateMap(uint32 mapid)
{
    std::map<uint32, Map*>::iterator it;
    it = _maps.find(mapid);
    ASSERT(it == _maps.end());

    Map *newmap = new Map(mapid);
    ASSERT(newmap);

    _maps.insert(std::pair<uint32, Map*>(mapid, newmap));

    return newmap;
}

Map* WorldCreator::GetMap(uint32 mapid)
{
    std::map<uint32, Map*>::iterator it;
    it = _maps.find(mapid);
    
    if (it != _maps.end())
        return it->second;
    else
        return _CreateMap(mapid);
}

MapMgr* WorldCreator::GetInstance(uint32 mapid, Object *obj)
{
    Map* mp = GetMap(mapid);
    //atm ignore the object part.
    //will add that when i'll add instances

    return mp->GetInstance();
}