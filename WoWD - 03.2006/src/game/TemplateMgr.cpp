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

#include "TemplateMgr.h"
#include "Log.h"
#include "GameObject.h"
#include "Creature.h"
#include "Corpse.h"

TemplateMgr::TemplateMgr(Map *map, uint32 mapId) : _mapId(mapId), CellHandler<TemplateCell>(map)
{
	sLog.outDetail(" Creating new template for Map %d", this->_mapId);
    
    _IndexObjects();
}

void TemplateMgr::_IndexObjects()
{
	std::stringstream query;

	//Load Creature GUIDs
	query << "SELECT id, positionX, positionY FROM creatures WHERE mapId = " <<
		this->_mapId;

	QueryResult *result = sDatabase.Query( query.str().c_str() );

	if( result )
	{
		do
		{
			Field *fields = result->Fetch();

			this->AddIndex<Creature>(fields[1].GetFloat(),
                    fields[2].GetFloat(), fields[0].GetUInt32());
		} while( result->NextRow() );

		sLog.outDetail("  Indexed %d Creatures for Map %d", (uint32)result->GetRowCount(), this->_mapId);

		delete result;
	}
	else
	{
		sLog.outDetail("  Indexed 0 Creatures for Map %d", this->_mapId);
	}

	//Load GameObject GUIDs
	query.rdbuf()->str("");

	query << "SELECT id, positionX, positionY FROM gameobjects WHERE mapId = " <<
		this->_mapId;

	result = sDatabase.Query( query.str().c_str() );

	if( result )
	{
		do
		{
			Field *fields = result->Fetch();

			this->AddIndex<GameObject>(fields[1].GetFloat(),
                    fields[2].GetFloat(), fields[0].GetUInt32());
		} while( result->NextRow() );

		sLog.outDetail("  Indexed %d GameObjects for Map %d", (uint32)result->GetRowCount(), this->_mapId);
		delete result;
	}
	else
	{
		sLog.outDetail("  Indexed 0 GameObjects for Map %d", this->_mapId);
	}

	//Load Corpse GUIDs
	query.rdbuf()->str("");

	query << "SELECT guid, positionX, positionY FROM corpses WHERE mapId = " <<
		this->_mapId;

	result = sDatabase.Query( query.str().c_str() );

	if( result )
	{
		do
		{
			Field *fields = result->Fetch();

			this->AddIndex<Corpse>(fields[1].GetFloat(),
                    fields[2].GetFloat(), fields[0].GetUInt32());
		} while( result->NextRow() );

		sLog.outDetail("  Indexed %d Corpses for Map %d", (uint32)result->GetRowCount(), this->_mapId);

		delete result;
	}
	else
	{
		sLog.outDetail("  Indexed 0 Corpses for Map %d", this->_mapId);
	}

	query.rdbuf()->str("");
}
