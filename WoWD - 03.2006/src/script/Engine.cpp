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

#include "Engine.h"
initialiseSingleton( LuaManager );


#include "luabind/luabind.hpp"

#include "../game/Unit.h"

int AddFileToMapID(lua_State *L)
{
	luaL_checkany(L,2);
	luaL_checktype(L,1,LUA_TSTRING);
	luaL_checktype(L,2,LUA_TNUMBER);

	sLuaManager.addFileToMapID(lua_tostring(L,1),(uint32)lua_tonumber(L,2));
	return 0;
}

int AddFileToEntry(lua_State *L)
{
	luaL_checkany(L,2);
	luaL_checktype(L,1,LUA_TSTRING);
	luaL_checktype(L,2,LUA_TNUMBER);

	sLuaManager.addFileToEntry(lua_tostring(L,1),(uint32)lua_tonumber(L,2));
	return 0;
}

int AddFile(lua_State *L)
{
	luaL_checkany(L,1);
	luaL_checktype(L,1,LUA_TSTRING);

	sLuaManager.addFile(lua_tostring(L,1));
	return 0;
}

void LuaManager::addWowdLibSupport(lua_State *Lua)
{
	luabind::module( Lua )
		[
			luabind::class_<Unit>("Unit")
			.def( "isAlive", &Unit::isAlive) // bind the setMessage method
			.def( "Emote", &Unit::Emote)
			.def( "SetStandState", &Unit::SetStandState)
			.def( "SendChatMessage", &Unit::SendChatMessage)
		];
}
void LuaManager::registerSupportFuncs(lua_State *m_state)
{
	lua_pushstring(m_state,"Support");

	lua_newtable(m_state);
	uint32 table = lua_gettop(m_state);

	lua_pushstring(m_state,"AddFile");
	lua_pushcclosure(m_state,AddFile,0);
	lua_settable(m_state,table);

	lua_pushstring(m_state,"AddFileToMapID");
	lua_pushcclosure(m_state,AddFileToMapID,0);
	lua_settable(m_state,table);

	lua_pushstring(m_state,"AddFileToEntry");
	lua_pushcclosure(m_state,AddFileToEntry,0);
	lua_settable(m_state,table);

	lua_settable(m_state,LUA_GLOBALSINDEX);
}

LuaManager::LuaManager()
{
	eng = new LuaEngine();
	registerSupportFuncs(eng->getState());
}
LuaManager::~LuaManager()
{
	delete eng;
}
LuaEngine *LuaManager::getInnerEngine()
{
	return eng;
}
void LuaManager::addFile(const char *file)
{
	m_files.insert(file);
}
void LuaManager::removeFile(const char *file)
{
	m_files.erase(file);
}

void LuaManager::addFileToMapID(const char *file, uint32 mapid)
{
	m_mapID[mapid].insert(file);
}
void LuaManager::removeFileFromMapID(const char *file, uint32 mapid)
{
	m_mapID[mapid].erase(file);
	if(m_mapID[mapid].size() == 0)
		m_mapID.erase(mapid);
}

void LuaManager::addFileToEntry(const char *file, uint32 entry)
{
	m_entry[entry].insert(file);
}
void LuaManager::removeFileFromEntry(const char *file, uint32 entry)
{
	m_entry[entry].erase(file);
	if(m_entry[entry].size() == 0)
		m_entry.erase(entry);
}

void LuaManager::addSupportForMapID(LuaEngine *L, uint32 mapid)
{
	if(m_mapID.count(mapid) == 0)
		return;
	fileset::iterator i;
	for(i=m_mapID[mapid].begin();i!=m_mapID[mapid].end();i++)
		L->runFile(i->c_str());
}
void LuaManager::addSupportForEntry(LuaEngine *L, uint32 entry)
{
	if(m_entry.count(entry) == 0)
		return;
	fileset::iterator i;
	for(i=m_entry[entry].begin();i!=m_entry[entry].end();i++)
		L->runFile(i->c_str());
}
void LuaManager::addSupport(LuaEngine *L)
{
	addWowdLibSupport(L->getState());
	fileset::iterator i;
	for(i=m_files.begin();i!=m_files.end();i++)
	{
		L->runFile(i->c_str());
	}
}
LuaEngine *LuaManager::getEngine(uint32 instanceID)
{
	LuaEngine *ret;
	if(m_engines.count(instanceID) == 0)
	{
		ret = new LuaEngine();
		m_engines[instanceID] = ret;
		ret->addSupport();
	}
	else
	{
		ret = m_engines[instanceID];
	}
	return ret;
}
void LuaManager::closeEngine(uint32 instanceID)
{
	delete m_engines[instanceID];
	m_engines.erase(instanceID);
}
