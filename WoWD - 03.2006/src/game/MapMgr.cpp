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
// MapMgr.cpp
//

#include "Common.h"
#include "Log.h"
#include "Object.h"
#include "Player.h"
#include "Item.h"
#include "WorldPacket.h"
#include "WorldSession.h"
#include "UpdateData.h"
#include "MapCell.h"
#include "CellHandler.h"
#include "MapMgr.h"
#include "GameObject.h"
#include "DynamicObject.h"
#include "EventMgr.h"

MapMgr::MapMgr(Map *map, uint32 mapId) : _mapId(mapId), CellHandler<MapCell>(map)
{
	sLog.outDetail(" Creating new instance for Map %d", this->_mapId);

	sEventMgr.AddEvent(this, &MapMgr::_UpdateObjects, EVENT_MAPMGR_UPDATEOBJECTS, 100, 0);
}


MapMgr::~MapMgr()
{

}


void MapMgr::AddObject(Object *obj)
{
	/////////////
	// Assertions
	/////////////

	ASSERT(obj);
	ASSERT(obj->GetInRangeSetBegin() == obj->GetInRangeSetEnd()); // make sure object is a virgin
	ASSERT(obj->GetMapId() == _mapId);
	ASSERT(obj->GetPositionX() < _maxX && obj->GetPositionX() > _minX);
	ASSERT(obj->GetPositionY() < _maxY && obj->GetPositionY() > _minY);
	ASSERT(_cells);

	// That object types are not map objects. TODO: add AI groups here?
	if(obj->GetTypeId() == TYPEID_ITEM || obj->GetTypeId() == TYPEID_CONTAINER)
	{
		// mark object as updatable and exit
		return;
	}

	ASSERT(!obj->GetMapCell());

	///////////////////////
	// Get cell coordinates
	///////////////////////

	uint32 x = GetPosX(obj->GetPositionX());
	uint32 y = GetPosY(obj->GetPositionY());

	MapCell *objCell = GetCell(x,y);
    if (!objCell)
    {
        objCell = Create(x,y);
        objCell->Init(x, y, _mapId, this);
    }

    uint32 endX = x < _sizeX ? x + 1 : _sizeX;
	uint32 endY = y < _sizeY ? y + 1 : _sizeY;
	uint32 startX = x > 0 ? x - 1 : 0;
	uint32 startY = y > 0 ? y - 1 : 0;
	uint32 posX, posY;
	MapCell *cell;
	MapCell::ObjectSet::iterator iter;

	WorldPacket packet;
	UpdateData data;
	UpdateData playerData;

	//////////////////////
	// Build in-range data
	//////////////////////

	for (posX = startX; posX <= endX; posX++ )
	{
		for (posY = startY; posY <= endY; posY++ )
		{
			cell = GetCell(posX, posY);

            if (cell)
            {
			    for (iter = cell->Begin(); iter != cell->End(); iter++)
			    {
				    if ((*iter)->GetDistance2dSq(obj) <= UPDATE_DISTANCE*UPDATE_DISTANCE)
				    {
					    // Object in range, add to set
					    if((*iter)->GetTypeId() == TYPEID_PLAYER)
					    {
						    data.Clear();
						    obj->BuildCreateUpdateBlockForPlayer( &data, (Player*)*iter );
						    data.BuildPacket(&packet);

						    ((Player*)*iter)->GetSession()->SendPacket( &packet );
					    }

					    (*iter)->AddInRangeObject(obj);

					    if(obj->GetTypeId() == TYPEID_PLAYER)
					    {
					        (*iter)->BuildCreateUpdateBlockForPlayer( &playerData, (Player*)obj );
					    }
      
					    obj->AddInRangeObject(*iter);
				    }
                }
			}
		}
	}

	if(obj->GetTypeId() == TYPEID_PLAYER)
	{
		//sLog.outDetail("Creating player "I64FMT" for himself.", obj->GetGUID());
		obj->BuildCreateUpdateBlockForPlayer( &playerData, (Player*)obj );
		packet.clear();
		playerData.BuildPacket( &packet );
		((Player*)obj)->GetSession()->SendPacket( &packet );
	}

	//Add to the cell's object list
	objCell->AddObject(obj);
	//Add to the mapmanager's object list
	_objects[obj->GetGUID()] = obj;

	//If it's a player - update his nearby cells
	if(obj->GetTypeId() == TYPEID_PLAYER)
	{
		UpdateCellActivity(x, y, 1);
	}

	obj->SetMapCell(objCell);
}


void MapMgr::RemoveObject(Object *obj)
{
	/////////////
	// Assertions
	/////////////

	ASSERT(obj);
	ASSERT(obj->GetMapId() == _mapId);
	ASSERT(obj->GetPositionX() > _minX && obj->GetPositionX() < _maxX);
	ASSERT(obj->GetPositionY() > _minY && obj->GetPositionY() < _maxY);
	ASSERT(_cells);

#ifndef DYNAMIC_LOADING
	sLog.outDetail("Removing object "I64FMT" with type %i from the world.",
		obj->GetGUID(), obj->GetTypeId());
#endif

	// That object types are not map objects. TODO: add AI groups here?
	if(obj->GetTypeId() == TYPEID_ITEM || obj->GetTypeId() == TYPEID_CONTAINER)
	{
		return;
	}

	ASSERT(obj->GetMapCell());

	///////////////////////
	// Get cell coordinates
	///////////////////////

	uint32 x = obj->GetMapCell()->GetX();
	uint32 y = obj->GetMapCell()->GetY();

	///////////////////////////////////////
	// Remove object from all needed places
	///////////////////////////////////////

	// Remove object from map
	ObjectMap::iterator itr = _objects.find(obj->GetGUID());
	_objects.erase(itr);
	// Remove object from updated objects list
	ObjectSet::iterator updi = _updatedObjects.find(obj);
	if(updi != _updatedObjects.end())
    {
		_updatedObjects.erase(updi);
        //object is going to be recreated, so no need for his update mask
        obj->ClearUpdateMask();
    }
    // Remove object from cell
	obj->GetMapCell()->RemoveObject(obj);
	// Unset object's cell
	obj->SetMapCell(0);

#ifndef DYNAMIC_LOADING
	sLog.outDebug("Removed Object "I64FMT" from Cell", obj->GetGUID());
#endif

	// If it's a player - update his nearby cells
	if(obj->GetTypeId() == TYPEID_PLAYER)
		UpdateCellActivity(x, y, 1);

	// Remove object from all objects 'seeing' him
	for (Object::InRangeSet::iterator iter = obj->GetInRangeSetBegin();
		iter != obj->GetInRangeSetEnd(); iter++)
	{
		(*iter)->RemoveInRangeObject(obj);

		if((*iter)->GetTypeId() == TYPEID_PLAYER)
			obj->DestroyForPlayer( (Player*)*iter );
	}

	// Clear object's in-range set
	obj->ClearInRangeSet();

#ifndef DYNAMIC_LOADING
	sLog.outDebug("Cleared InRangeSet for object "I64FMT, obj->GetGUID());
#endif
}


void MapMgr::ChangeObjectLocation(Object *obj)
{
	ASSERT(obj);
	ASSERT(obj->GetMapId() == _mapId);
	ASSERT(_cells);

	// Items and containers are of no interest for us
	if(obj->GetTypeId() == TYPEID_ITEM || obj->GetTypeId() == TYPEID_CONTAINER)
		return;

	ASSERT(obj->GetMapCell());

	WorldPacket packet;
	UpdateData data;
	UpdateData playerData;
	Object* curObj;

	///////////////////////////////////////
	// Update in-range data for old objects
	///////////////////////////////////////

	for (Object::InRangeSet::iterator iter = obj->GetInRangeSetBegin();
		iter != obj->GetInRangeSetEnd();)
	{
		curObj = *iter;
		iter++;

		if (curObj->GetDistance2dSq(obj) > UPDATE_DISTANCE*UPDATE_DISTANCE)
		{
#ifndef DYNAMIC_LOADING
			sLog.outDetail("Object "I64FMT" no longer in field of view of object "I64FMT".",
				obj->GetGUID(), (curObj)->GetGUID());
#endif

			if( obj->GetTypeId() == TYPEID_PLAYER )
				curObj->BuildOutOfRangeUpdateBlock( &playerData );

			obj->RemoveInRangeObject(curObj);

			if( curObj->GetTypeId() == TYPEID_PLAYER )
			{
				data.Clear();
				obj->BuildOutOfRangeUpdateBlock( &data );
				packet.clear();
				data.BuildPacket(&packet);
				((Player*)curObj)->GetSession()->SendPacket( &packet );
			}

			curObj->RemoveInRangeObject(obj);
		}
	}

	///////////////////////////
	// Get new cell coordinates
	///////////////////////////

	uint32 cellX = GetPosX(obj->GetPositionX());
	uint32 cellY = GetPosY(obj->GetPositionY());

	MapCell *objCell = GetCell(cellX, cellY);
    if (!objCell)
    {
        objCell = Create(cellX,cellY);
        objCell->Init(cellX, cellY, _mapId, this);
    }

	// If object moved cell
	if (objCell != obj->GetMapCell())
	{
		// remove from current cell
		obj->GetMapCell()->RemoveObject(obj);
		// add to new cell
		objCell->AddObject(obj);
		// update object's cell indicator
		obj->SetMapCell(objCell);

		// if player we need to update cell activity
		// radius = 2 is used in order to update both
		// old and new cells
		if(obj->GetTypeId() == TYPEID_PLAYER)
			UpdateCellActivity(cellX, cellY, 2);
	}


	//////////////////////////////////////
	// Update in-range set for new objects
	//////////////////////////////////////

	uint32 endX = cellX < _sizeX ? cellX + 1 : _sizeX;
	uint32 endY = cellY < _sizeY ? cellY + 1 : _sizeY;
	uint32 startX = cellX > 0 ? cellX - 1 : 0;
	uint32 startY = cellY > 0 ? cellY - 1 : 0;
	uint32 posX, posY;
	MapCell *cell;
	MapCell::ObjectSet::iterator iter;

	for (posX = startX; posX <= endX; posX++ )
	{
		for (posY = startY; posY <= endY; posY++ )
		{
			cell = GetCell(posX, posY);
			if (cell)
            {
			    for (iter = cell->Begin(); iter != cell->End(); iter++)
			    {
				    curObj = *iter;
				    if (curObj != obj &&
					    (curObj)->GetDistance2dSq(obj) <= UPDATE_DISTANCE*UPDATE_DISTANCE &&
					    !obj->IsInRangeSet(curObj))
				    {
					    // Object in range, add to set
					    if((curObj)->GetTypeId() == TYPEID_PLAYER)
					    {
						    data.Clear();
						    obj->BuildCreateUpdateBlockForPlayer( &data, (Player*)curObj );
						    packet.clear();
						    data.BuildPacket(&packet);
						    ((Player*)curObj)->GetSession()->SendPacket( &packet );
					    }

					    (curObj)->AddInRangeObject(obj);			

					    if(obj->GetTypeId() == TYPEID_PLAYER)
					    {
#ifndef DYNAMIC_LOADING
						    sLog.outDetail("Creating object "I64FMT" for player "I64FMT".",
							    (curObj)->GetGUID(), obj->GetGUID());
#endif
						    (curObj)->BuildCreateUpdateBlockForPlayer( &playerData, (Player*)obj );

					    }

					    obj->AddInRangeObject(curObj);
				    }
			    }
            }
		}
	}

	if (obj->GetTypeId() == TYPEID_PLAYER && playerData.HasData())
	{
		packet.clear();
		playerData.BuildPacket(&packet);
		((Player*)obj)->GetSession()->SendPacket( &packet );
	}
}


void MapMgr::_UpdateObjects()
{
	UpdateData *data;
	WorldPacket packet;
	HM_NAMESPACE::hash_map<Player*, UpdateData*> updates;
	HM_NAMESPACE::hash_map<Player*, UpdateData*>::iterator i;

	ObjectSet::iterator iobj, iobjend;

	for ( iobj = _updatedObjects.begin(), iobjend = _updatedObjects.end();
		iobj != iobjend; iobj++ )
	{
		if( (*iobj)->GetTypeId() == TYPEID_PLAYER )
		{
			i = updates.find( (Player*)*iobj );
			if(i == updates.end())
			{
				data = new UpdateData;
				ASSERT(data);

				updates[(Player*)*iobj] = data;
			}
			else
				data = i->second;

			(*iobj)->BuildValuesUpdateBlockForPlayer( data, (Player*)*iobj );
		}

		if( (*iobj)->GetTypeId() == TYPEID_ITEM)
		{
			i = updates.find( ((Item*)*iobj)->GetOwner() );
			if(i == updates.end())
			{
				data = new UpdateData;
				ASSERT(data);

				updates[((Item*)*iobj)->GetOwner()] = data;
			}
			else
				data = i->second;

			(*iobj)->BuildValuesUpdateBlockForPlayer( data, ((Item*)*iobj)->GetOwner());
		}
		if((*iobj)->GetTypeId() == TYPEID_CONTAINER)
		{
			i = updates.find( ((Container*)*iobj)->GetOwner() );
			if(i == updates.end())
			{
				data = new UpdateData;
				ASSERT(data);

				updates[((Container*)*iobj)->GetOwner()] = data;
			}
			else
				data = i->second;

			(*iobj)->BuildValuesUpdateBlockForPlayer( data, ((Container*)*iobj)->GetOwner());
		}

		for( Object::InRangeSet::iterator iplr = (*iobj)->GetInRangeSetBegin();
			iplr != (*iobj)->GetInRangeSetEnd(); iplr++)
		{
			if( (*iplr)->GetTypeId() == TYPEID_PLAYER )
			{
				//Log::getSingleton( ).outDetail("Sending updater to player %u",
				//    (*iplr)->GetGUIDLow());

				// TODO: take ranges into accounts as suggested by quetzal

				i = updates.find( (Player*)*iplr );
				if(i == updates.end())
				{
					data = new UpdateData;
					ASSERT(data);

					updates[(Player*)*iplr] = data;
				}
				else
					data = i->second;

				(*iobj)->BuildValuesUpdateBlockForPlayer( data, (Player*)*iplr );
			}
		}

		(*iobj)->ClearUpdateMask();
	}

	for ( i = updates.begin(); i != updates.end(); i++ )
	{
		i->second->BuildPacket( &packet );
		((Player*)(i->first))->GetSession()->SendPacket( &packet );

		delete i->second;
	}

	updates.clear();
	_updatedObjects.clear();
}

void MapMgr::UpdateCellActivity(uint32 x, uint32 y, int radius)
{
	uint32 endX = x + radius < _sizeX ? x + radius : _sizeX;
	uint32 endY = y + radius < _sizeY ? y + radius : _sizeY;
	uint32 startX = x - radius > 0 ? x - radius : 0;
	uint32 startY = y - radius > 0 ? y - radius : 0;
	uint32 posX, posY;

	MapCell *objCell;

	for (posX = startX; posX <= endX; posX++ )
	{
		for (posY = startY; posY <= endY; posY++ )
		{
			objCell = GetCell(posX, posY);

            if (!objCell)
            {
                if (_CellActive(posX, posY))
                {
                    objCell = Create(posX, posY);
                    objCell->Init(posX, posY, _mapId, this);

				    sLog.outDetail("Cell [%d,%d] on map %d is now active.", 
					    posX, posY, this->_mapId);
				    objCell->SetActivity(true);

				    if (!objCell->IsLoaded())
				    {
					    sLog.outDetail("Loading objects for Cell [%d][%d] on map %d...", 
						    posX, posY, this->_mapId);
					    //objmgr.LoadCellObjects(posX, posY, _sizeX, _sizeY, _minX, _minY, _mapId); 
					    objCell->LoadObjects();
					    objCell->SetLoadState(true);
				    }
                }
            }
            else
            {
			    //Cell is now active
			    if (_CellActive(posX, posY) && !objCell->IsActive())
			    {
				    sLog.outDetail("Cell [%d,%d] on map %d is now active.", 
					    posX, posY, this->_mapId);
				    objCell->SetActivity(true);

				    if (!objCell->IsLoaded())
				    {
					    sLog.outDetail("Loading objects for Cell [%d][%d] on map %d...", 
						    posX, posY, this->_mapId);
					    //objmgr.LoadCellObjects(posX, posY, _sizeX, _sizeY, _minX, _minY, _mapId); 
					    objCell->LoadObjects();
					    objCell->SetLoadState(true);
				    }
				    else
				    {
					    sEventMgr.RemoveEvents(objCell, EVENT_MAPCELL_UNLOAD);
				    }
			    }
			    //Cell is no longer active
			    else if (!_CellActive(posX, posY) && objCell->IsActive())
			    {
				    sLog.outDetail("Cell [%d,%d] on map %d is now idle.", 
					    posX, posY, this->_mapId);
				    objCell->SetActivity(false);

				    sEventMgr.AddEvent(objCell, &MapCell::Unload, EVENT_MAPCELL_UNLOAD, DYNAMIC_UNLOAD_TIME*1000, 1);
			    }
            }
		}
	}
}

bool MapMgr::_CellActive(uint32 x, uint32 y)
{
	uint32 endX = x < _sizeX ? x + 1 : _sizeX;
	uint32 endY = y < _sizeY ? y + 1 : _sizeY;
	uint32 startX = x > 0 ? x - 1 : 0;
	uint32 startY = y > 0 ? y - 1 : 0;
	uint32 posX, posY;

	MapCell *objCell;

	for (posX = startX; posX <= endX; posX++ )
	{
		for (posY = startY; posY <= endY; posY++ )
		{
			objCell = GetCell(posX, posY);

            if (objCell)
            {
			    if (objCell->HasPlayers())
                {
				    return true;
                }
            }
		}
	}

	return false;
}
