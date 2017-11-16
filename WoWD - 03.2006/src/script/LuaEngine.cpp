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

#include "LuaEngine.h"
#include "Engine.h"

#include "luabind/luabind.hpp"


using namespace luabind;

int HandleLuaCrash(lua_State *L)
{
	void *x = lua_touserdata(L,lua_upvalueindex(1));
	return ((LuaEngine *)x)->handleCrash();
}


int BounceLuaCall(lua_State *L)
{
	LuaEngine *x = (LuaEngine *)lua_touserdata(L,lua_upvalueindex(1));

	int n = lua_gettop(L);
	luaL_checktype(L,1,LUA_TSTRING);

	const char *fname = lua_tostring(L,1);
	lua_pushstring(L,fname);
	lua_gettable(L, LUA_GLOBALSINDEX);
	for(int i=2;i<=n;i++)
		lua_pushvalue(L,i);
	x->callFunctionAtTop(n-1);
	return 0;
}

int RegisterEvent(lua_State *L)
{
	luaL_checkany(L,3);
	luaL_checktype(L,1,LUA_TNUMBER);
	luaL_checktype(L,2,LUA_TNUMBER);
	luaL_checktype(L,3,LUA_TSTRING);

	LuaEngine *x = (LuaEngine *)lua_touserdata(L,lua_upvalueindex(1));
	x->registerEvent((uint32)lua_tonumber(L,1),(WOWD_SCRIPTEVENT)(uint32)lua_tonumber(L,2),lua_tostring(L,3));
	return 0;
}

int UnregisterEvent(lua_State *L)
{
	luaL_checkany(L,3);
	luaL_checktype(L,1,LUA_TNUMBER);
	luaL_checktype(L,2,LUA_TNUMBER);
	luaL_checktype(L,3,LUA_TSTRING);

	LuaEngine *x = (LuaEngine *)lua_touserdata(L,lua_upvalueindex(1));
	x->unregisterEvent((uint32)lua_tonumber(L,1),(WOWD_SCRIPTEVENT)(uint32)lua_tonumber(L,2),lua_tostring(L,3));
	return 0;
}

int RegisterMapEvent(lua_State *L)
{
	luaL_checkany(L,2);
	luaL_checktype(L,1,LUA_TNUMBER);
	luaL_checktype(L,2,LUA_TSTRING);

	LuaEngine *x = (LuaEngine *)lua_touserdata(L,lua_upvalueindex(1));
	x->registerMapEvent((WOWD_SCRIPTEVENT)(uint32)lua_tonumber(L,1),lua_tostring(L,2));
	return 0;
}

int UnregisterMapEvent(lua_State *L)
{
	luaL_checkany(L,2);
	luaL_checktype(L,1,LUA_TNUMBER);
	luaL_checktype(L,2,LUA_TSTRING);

	LuaEngine *x = (LuaEngine *)lua_touserdata(L,lua_upvalueindex(1));
	x->unregisterMapEvent((WOWD_SCRIPTEVENT)(uint32)lua_tonumber(L,1),lua_tostring(L,2));
	return 0;
}

int RunFileFromScript(lua_State *L)
{
	luaL_checkany(L,1);
	luaL_checktype(L,1,LUA_TSTRING);

	LuaEngine *x = (LuaEngine *)lua_touserdata(L,lua_upvalueindex(1));
	x->runFileFromScript(lua_tostring(L,1));
	return 0;
}

#include "LuaEngine.h"


void LuaEngine::runFileFromScript(const char *Path)
{
	if (luaL_loadfile(m_state, Path))
	{
		lua_remove(m_state,-1);
	}
	lua_call(m_state, 0, 0);
}
void LuaEngine::updateLastError()
{
	m_lastError = lua_tostring(m_state,-1);
}
int LuaEngine::handleCrash()
{
	updateLastError();
	printf("Lua script crash! Error: %s. Stack dump:\n",m_lastError.c_str());
	stackTrace();
	printf("End of stack dump.\n");
	return 1;
}
void LuaEngine::stackTrace()
{
	m_dbL.clear();
	lua_Debug curr;
	uint32 i = 0;
	while(lua_getstack(m_state,i++,&curr))
	{
		lua_getinfo(m_state,"nSlu",&curr);
		m_dbL.push_back(curr);
		printf("%u: %s (%s - %s:%u)\n",i,curr.name,curr.namewhat,curr.short_src,curr.currentline);
	}
}
bool LuaEngine::callFunctionAtTop(int args)
{
	if(!lua_pcall(m_state, args, 0, m_crashTop))
		return true;
	else
	{
		lua_remove(m_state,-1);
		return false;
	}
}
void LuaEngine::registerTrampoline()
{
	lua_pushstring(m_state,"_CTRAMPOLINE");
	lua_pushlightuserdata(m_state,this);
	lua_pushcclosure(m_state,BounceLuaCall,1);
	lua_settable(m_state,LUA_GLOBALSINDEX);
}
void LuaEngine::registerEventFuncs()
{
	lua_pushstring(m_state,"Events");

	lua_newtable(m_state);
	uint32 table = lua_gettop(m_state);

	lua_pushstring(m_state,"RegisterEvent");
	lua_pushlightuserdata(m_state,this);
	lua_pushcclosure(m_state,RegisterEvent,1);
	lua_settable(m_state,table);

	lua_pushstring(m_state,"UnregisterEvent");
	lua_pushlightuserdata(m_state,this);
	lua_pushcclosure(m_state,UnregisterEvent,1);
	lua_settable(m_state,table);

	lua_pushstring(m_state,"RegisterMapEvent");
	lua_pushlightuserdata(m_state,this);
	lua_pushcclosure(m_state,RegisterEvent,1);
	lua_settable(m_state,table);

	lua_pushstring(m_state,"UnregisterMapEvent");
	lua_pushlightuserdata(m_state,this);
	lua_pushcclosure(m_state,UnregisterEvent,1);
	lua_settable(m_state,table);

	lua_settable(m_state,LUA_GLOBALSINDEX);
}
void LuaEngine::registerFuncs()
{
	lua_pushstring(m_state,"RunFile");
	lua_pushlightuserdata(m_state,this);
	lua_pushcclosure(m_state,RunFileFromScript,1);
	lua_settable(m_state,LUA_GLOBALSINDEX);
}

LuaEngine::LuaEngine()
{
	support = false;
	m_state = lua_open();
	luabind::open(m_state); 
	lua_baselibopen(m_state);
	lua_iolibopen(m_state);
	lua_strlibopen(m_state);
	lua_mathlibopen(m_state);

	lua_pushlightuserdata(m_state,this);
	lua_pushcclosure(m_state,HandleLuaCrash,1);
	m_crashTop = lua_gettop(m_state);
	registerTrampoline();
	registerFuncs();
	registerEventFuncs();
}
LuaEngine::~LuaEngine()
{
	lua_close(m_state);
	m_state = 0;
}
std::string LuaEngine::getLastError()
{
	return m_lastError;
}
bool LuaEngine::runFile(const char *Path)
{
	if (luaL_loadfile(m_state, Path))
	{
		updateLastError();
		printf("Error running file %s: %s\n",Path,m_lastError.c_str());
		lua_remove(m_state,-1);
		return false;
	}
	return callFunctionAtTop();
}
bool LuaEngine::runString(const char *String,const char *name)
{
	if(luaL_loadbuffer(m_state,String,strlen(String),name))
	{
		updateLastError();
		printf("Error on running lua string: %s.\n",m_lastError.c_str());
		lua_remove(m_state,-1);
		return false;
	}
	return callFunctionAtTop();
}
lua_State *LuaEngine::getState()
{
	return m_state;
}
void LuaEngine::registerEvent(uint32 entry, WOWD_SCRIPTEVENT event, const char *function)
{
	m_eventMap[entry][event].insert(function);
}
void LuaEngine::unregisterEvent(uint32 entry, WOWD_SCRIPTEVENT event, const char *function)
{
	m_eventMap[entry][event].erase(function);
	if(m_eventMap[entry][event].size() == 0)
		m_eventMap[entry].erase(event);
	if(m_eventMap[entry].size() == 0)
		m_eventMap.erase(entry);
}
void LuaEngine::handleEvent(Unit *pUnit, uint32 entry, WOWD_SCRIPTEVENT event)
{
	if(m_eventMap.count(entry) == 0)
		return;
	if(m_eventMap[entry].count(event) == 0)
		return;
	std::set<std::string>::iterator i;
	for(i=m_eventMap[entry][event].begin();i!=m_eventMap[entry][event].end();i++)
	{
		call_function<void>( m_state, "_CTRAMPOLINE", i->c_str(), pUnit, (uint32)event);
	}
}
void LuaEngine::handleMapEvent(WOWD_SCRIPTEVENT event)
{
	handleEvent(NULL,0,event);
}
void LuaEngine::registerMapEvent(WOWD_SCRIPTEVENT event, const char *function)
{
	registerEvent(0,event,function);
}
void LuaEngine::unregisterMapEvent(WOWD_SCRIPTEVENT event, const char *function)
{
	unregisterEvent(0,event,function);
}

void LuaEngine::addSupport()
{
	if(support)
		return;
	sLuaManager.addSupport(this);
	support = true;
}

void LuaEngine::addSupportForMapID(uint32 mapid)
{
	if(supportedmaps.count(mapid) > 0)
		return;
	sLuaManager.addSupportForMapID(this,mapid);
	supportedmaps.insert(mapid);
}

void LuaEngine::addSupportForEntry(uint32 entry)
{
	if(supportedentries.count(entry) > 0)
		return;
	sLuaManager.addSupportForEntry(this,entry);
	supportedentries.insert(entry);
}
