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
// MapCell.cpp
//

#include "MapCell.h"
#include "TemplateCell.h"
#include "Map.h"

MapCell::~MapCell()
{
    sLog.outDebug("Unloading Idle Cell [%d][%d] on map %d...",
        this->GetX(), this->GetY(), this->_mapid);

    this->RemoveObjects();
    this->SetLoadState(false);
}

void MapCell::Init(uint32 x, uint32 y, uint32 mapid, MapMgr *mapmgr)
{
    _mapmgr = mapmgr;
    _active = false;
    _loaded = false;
    _playerCount = 0;
    _x = x;
    _y = y;
    _mapid = mapid;
    _timeWentIdle = time(NULL);
}

void MapCell::AddObject(Object *obj)
{
    if (obj->GetTypeId() == TYPEID_PLAYER)
        _playerCount++;
    
    ObjectSet::iterator itr = _objects.find(obj);

    if (itr == _objects.end())
        _objects.insert(obj);
}

void MapCell::RemoveObject(Object *obj)
{
    if (obj->GetTypeId() == TYPEID_PLAYER)
        _playerCount--;

    ObjectSet::iterator itr = _objects.find(obj);
    
    if (itr != _objects.end())
        _objects.erase(itr);
}
 
void MapCell::SetActivity(bool state)
{
    _active = state; 

    if (!state)
        _timeWentIdle = time(NULL);
}

void MapCell::RemoveObjects()
{
    ObjectSet::iterator itr2;
    std::list<uint32>::iterator itr;
    uint32 count = 0;
    TemplateCell *tcl;
    uint32 ltime = getMSTime();

    tcl = this->GetMapMgr()->GetBaseMap()->GetTemplate()->GetCell(this->GetX(), this->GetY());

    if (tcl)
    { 
        //Unload Creatures
        count = 0;
        for(itr = tcl->GetListBegin<Creature>(); itr != tcl->GetListEnd<Creature>(); itr++)
        {
            Creature *mob = objmgr.GetObject<Creature>((uint32)*itr);
            ASSERT(mob);

            if (mob->IsInWorld())
                mob->RemoveFromWorld();
            else
                sWorld.RemoveGlobalObject(mob);
                
            objmgr.RemoveObject(mob);
            delete mob;
            count++;
        }
        Log::getSingleton( ).outDebug(" %d Creatures Unloaded.", count);

        //Unload GameObjects
        count = 0;
        for(itr = tcl->GetListBegin<GameObject>(); itr != tcl->GetListEnd<GameObject>(); itr++)
        {
            GameObject *go = objmgr.GetObject<GameObject>((uint32)*itr);
            ASSERT(go);

            if (go->IsInWorld())
                go->RemoveFromWorld();
            else
                sWorld.RemoveGlobalObject(go);

            objmgr.RemoveObject(go);
            delete go;
            count++;
        }
        Log::getSingleton( ).outDebug(" %d GameObjects Unloaded.", count);
    }
    else
    {
        Log::getSingleton( ).outDebug(" 0 Creatures Unloaded.");
        Log::getSingleton( ).outDebug(" 0 GameObjects Unloaded.");
    }

    count = 0;
    for(itr2 = _objects.begin(); itr2 != _objects.end(); )
    {
        count++;
        
        Object *obj = (*itr2);
        
        itr2++;

        if (obj->GetTypeId() == TYPEID_UNIT)
        {
            //Todo: the only thing that should worry us here is update
            //      the index list on !spawn and !delete commands
            
            //Gotta get rid of him, since this cell is getting deleted from the memory
            ((Creature*)(obj))->Despawn();
        }
        else if (obj->GetTypeId() == TYPEID_GAMEOBJECT)
        {
            //Todo: the only thing that should worry us here is update
            //      the index list on !spawn and !delete commands

            //we shouldn't really get here since gameobjects aren't moving...
            if (obj->IsInWorld())
                obj->RemoveFromWorld();
            else
                sWorld.RemoveGlobalObject(obj);
            objmgr.RemoveObject((GameObject*)(obj));
            delete (GameObject*)(obj);
        }
        else if (obj->GetTypeId() == TYPEID_CORPSE)
        {
            //the reason for not unloading the index list for corpses is that
            //once a corpse becomes bones it is removed from the index list
            //(since it's no longer stays in the db) but remains an object
            //this means that bones will not be reloaded once a cell is unloaded
            //(we might want to reconsider that...)
            if (obj->IsInWorld())
                obj->RemoveFromWorld();
            else
                sWorld.RemoveGlobalObject(obj);
            objmgr.RemoveObject((Corpse*)(obj));
            delete (Corpse*)(obj);
        }
        else if (obj->GetTypeId() == TYPEID_DYNAMICOBJECT)
        {
            if (obj->IsInWorld())
                obj->RemoveFromWorld();
            else
                sWorld.RemoveGlobalObject(obj);
            objmgr.RemoveObject((DynamicObject*)(obj));
            delete (DynamicObject*)(obj);
        }
    }

    sLog.outDebug(" %d Unbound Objects Unloaded.", count);
    Log::getSingleton( ).outDebug(" Cell Unloaded in %dms.", getMSTime() - ltime);

    _objects.clear();
    _playerCount = 0;
}

void MapCell::LoadObjects()
{
    ASSERT(!this->_loaded);

    uint32 ltime = getMSTime();
    uint32 count;    
    TemplateCell *tcl;
    tcl = this->GetMapMgr()->GetBaseMap()->GetTemplate()->GetCell(this->GetX(), this->GetY());
    if (!tcl) //Cell is empty
    {
        Log::getSingleton( ).outDebug(" 0 Creatures Loaded.");
        Log::getSingleton( ).outDebug(" 0 GameObjects Loaded.");
        Log::getSingleton( ).outDebug(" 0 Corpses Loaded.");
        Log::getSingleton( ).outDebug(" Cell Loaded in %dms.", getMSTime() - ltime);
        return;
    }

    //Load Creatures
    std::list<uint32>::iterator itr;
    count = 0;
    for(itr = tcl->GetListBegin<Creature>(); itr != tcl->GetListEnd<Creature>(); itr++ )
    {
        objmgr.LoadCreature(*itr);
        count++;
    }
    Log::getSingleton( ).outDebug(" %d Creatures Loaded.", count);

    //Load GameObjects
    count = 0;
    for(itr = tcl->GetListBegin<GameObject>(); itr != tcl->GetListEnd<GameObject>(); itr++ )
    {
        objmgr.LoadGameObject(*itr);
        count++;
    }
    Log::getSingleton( ).outDebug(" %d GameObjects Loaded.", count);

    //Load Corpses
    count = 0;
    for(itr = tcl->GetListBegin<Corpse>(); itr != tcl->GetListEnd<Corpse>(); itr++ )
    {
        objmgr.LoadCorpse(*itr);
        count++;
    }
    Log::getSingleton( ).outDebug(" %d Corpses Loaded.", count);
    Log::getSingleton( ).outDebug(" Cell Loaded in %dms.", getMSTime() - ltime);
}

void MapCell::Unload()
{
    //this is considered to be pretty dangerous, so lemme know if we crash around here
    // - Doron
    ASSERT(!this->HasPlayers());

    this->GetMapMgr()->Remove(this->GetX(), this->GetY());
}
