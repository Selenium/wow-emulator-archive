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
// TemplateCell.h
//

#ifndef __TEMPLATECELL_H
#define __TEMPLATECELL_H

#include "Common.h"
#include "Creature.h"
#include "GameObject.h"
#include "Corpse.h"

class TemplateCell
{
public:
    TemplateCell() { };
    ~TemplateCell() { };

    //Init
    void Init(uint32 x, uint32 y, uint32 mapid)
    {
        _x = x;
        _y = y;
        _mapid = mapid;
    }

    //Position Related
    uint32 GetX() { return _x; }
    uint32 GetY() { return _y; }
    uint32 GetMapId() { return _mapid; }

    //Object Loading Managing
    template <class T> inline void AddIndex(uint32 guid) { _GetList<T>().push_back(guid); }
    template <class T> inline void RemoveIndex(uint32 guid) { _GetList<T>().remove(guid); }
    bool HasIndexes() { return ((_creatures.size()) || (_gameobjects.size()) || (_corpses.size())); }

    //Iterators
    template <class T> inline typename list<uint32>::iterator GetListBegin()
    { 
        return _GetList<T>().begin();
    }
    template <class T> inline typename list<uint32>::iterator GetListEnd()
    {
        return _GetList<T>().end();
    }

private:
    template <class T> std::list<uint32>& _GetList();
    template<> std::list<uint32>& _GetList<Creature>()
    {
        return _creatures;
    }
    template<> std::list<uint32>& _GetList<GameObject>()
    {
        return _gameobjects;
    }
    template<> std::list<uint32>& _GetList<Corpse>()
    {
        return _corpses;
    }

    uint32 _x, _y, _mapid;

    std::list<uint32> _creatures;
    std::list<uint32> _gameobjects;
    std::list<uint32> _corpses;
};

#endif