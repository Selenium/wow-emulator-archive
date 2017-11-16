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

#ifndef __TEMPLATEMGR_H
#define __TEMPLATEMGR_H

#include "TemplateCell.h"
#include "CellHandler.h"
#include "Object.h"

class TemplateMgr : public CellHandler <TemplateCell>
{
public:
    TemplateMgr(Map *map, uint32 mapid);
    ~TemplateMgr() { };

    template <class T> void AddIndex(float x, float y, uint32 guid);
    template <class T> void RemoveIndex(float x, float y, uint32 guid);
    template <class T> void AddIndex(uint32 posx, uint32 posy, uint32 guid);
    template <class T> void RemoveIndex(uint32 posx, uint32 posy, uint32 guid);
    template <class T> void AddIndex(Object *obj);
    template <class T> void RemoveIndex(Object *obj);

private:
    uint32 _mapId;
    
    void _IndexObjects();
};

template <class T>
void TemplateMgr::AddIndex(uint32 posx, uint32 posy, uint32 guid)
{
    TemplateCell *tcl = GetCell(posx, posy);

    if (!tcl)
    {
        tcl = Create(posx, posy);
        tcl->Init(posx, posy, _mapId);
    }

    tcl->AddIndex<T>(guid);
}

template <class T>
void TemplateMgr::RemoveIndex(uint32 posx, uint32 posy, uint32 guid)
{
    ASSERT(GetCell(posx, posy));

    TemplateCell *tcl = GetCell(posx, posy);
    tcl->RemoveIndex<T>(guid);

    if (!tcl->HasIndexes())
        Remove(posx, posy);
}

template <class T>
void TemplateMgr::AddIndex(float x, float y, uint32 guid)
{
    uint32 posx = GetPosX(x);
    uint32 posy = GetPosY(y);

    AddIndex<T>(posx, posy, guid);
}

template <class T>
void TemplateMgr::RemoveIndex(float x, float y, uint32 guid)
{
    uint32 posx = GetPosX(x);
    uint32 posy = GetPosY(y);

    RemoveIndex<T>(posx, posy, guid);
}

template <class T>
void TemplateMgr::AddIndex(Object *obj)
{
    //might change that to spawn coordinates
    AddIndex<T>(obj->GetPositionX(), obj->GetPositionY(), obj->GetGUIDLow());
}

template <class T>
void TemplateMgr::RemoveIndex(Object *obj)
{
    //might change that to spawn coordinates
    RemoveIndex<T>(obj->GetPositionX(), obj->GetPositionY(), obj->GetGUIDLow());
}

#endif
