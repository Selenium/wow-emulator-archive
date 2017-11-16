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

#include "Common.h"

#include "Database/DatabaseEnv.h"
#include "LootMgr.h"

initialiseSingleton(LootMgr);

LootMgr::LootMgr()
{

}
LootTable* LootMgr::getLoot(uint32 id) { 
	LootMap::const_iterator itr = mLoots.find(id);
	if (itr != mLoots.end())
		return itr->second;
	return NULL;
}

LootPropTable* LootMgr::getLootProp(uint32 id) { 
	LootPropMap::const_iterator itr = mLootProps.find(id);
	if (itr != mLootProps.end())
		return itr->second;
	return NULL;
}

LootTable* LootMgr::getObjectLoot(uint32 id) { 
	LootMap::const_iterator itr = mObjectLoots.find(id);
	if (itr != mObjectLoots.end())
		return itr->second;
	return NULL;
}

void LootMgr::loadLoot(uint32 id)
{
	uint32 itemid = 0;
	if (!getLoot(id))
	{
		std::stringstream ss;
		ss << "SELECT * FROM creatureloot WHERE entryid=" << id << " ORDER BY `percentchance` DESC";
		QueryResult *result = sDatabase.Query( ss.str().c_str() );

		LootTable *tb;
		if(result)
		{
			tb = new LootTable();
			do
			{
				Field *fields = result->Fetch();
				std::stringstream s2;
				s2 << "SELECT * FROM items WHERE entry=" << fields[1].GetUInt32();
				QueryResult *result2 = sDatabase.Query( s2.str().c_str() );	
				if (result2)
				{
					delete result2;
					tb->mItems.push_back(fields[1].GetUInt32());
					itemid = fields[1].GetUInt32();
					tb->mChance.push_back((fields[2].GetFloat()));
				}
			}
			while( result->NextRow() );
			mLoots[id] = tb;
			loadLootProp(itemid);

			delete result;

		}
	}
}
void LootMgr::loadObjectLoot(uint32 id)
{
	uint32 itemid = 0;
	if (!getObjectLoot(id))
	{
		std::stringstream ss;
		std::stringstream s2;
		ss << "SELECT * FROM objectloot WHERE entryid=" << id << " ORDER BY `percentchance` DESC";
		QueryResult *result = sDatabase.Query( ss.str().c_str() );

		Field *fields;
		LootTable *tb;
		if(result)
		{
			tb = new LootTable();
			do
			{
				fields = result->Fetch();
				s2 << "SELECT * FROM items WHERE entry=" << fields[1].GetUInt32();
				QueryResult *result2 = sDatabase.Query( s2.str().c_str() );	
				if (result2)
				{
					delete result2;
					tb->mItems.push_back(fields[1].GetUInt32());
					itemid = fields[1].GetUInt32();
					tb->mChance.push_back((fields[2].GetFloat()));
				}
			}
			while( result->NextRow() );
			mObjectLoots[id] = tb;
			loadLootProp(itemid);

			delete result;
		}
	}
}
void LootMgr::loadLootProp(uint32 id)
{
	if (!getLootProp(id))
	{
		std::stringstream ss;
		ss << "SELECT * FROM lootrandomprop WHERE entryid=" << id << " ORDER BY `percentchance` DESC";

		QueryResult *result = sDatabase.Query( ss.str().c_str() );

		Field *fields;
		LootPropTable *tb;
		if(result)
		{
			tb = new LootPropTable();
			do
			{
				fields = result->Fetch();
				tb->mProps.push_back(fields[1].GetUInt32());
				tb->mChance.push_back(fields[2].GetFloat());
			}
			while( result->NextRow() );
			delete result;
			mLootProps[id] = tb;
		}
	}
}
