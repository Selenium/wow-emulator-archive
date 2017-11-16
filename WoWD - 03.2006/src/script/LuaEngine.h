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

#ifndef WOWD_LUAENGINE
#define WOWD_LUAENGINE

#include "Common.h"
#include "ScriptCommon.h"

class Unit;

struct lua_State;
extern "C" {
#include "lua.h"
#include "lualib.h"
#include "lauxlib.h"
};


int HandleLuaCrash(lua_State *L);
int BounceLuaCall(lua_State *L);
int RegisterEvent(lua_State *L);
int UnregisterEvent(lua_State *L);
int RegisterMapEvent(lua_State *L);
int UnregisterMapEvent(lua_State *L);
int RunFileFromScript(lua_State *L);

class LuaEngine
{
private:
	lua_State* m_state;
	int m_crashTop;
	typedef std::list<lua_Debug> debuglist;
	debuglist m_dbL;
	std::string m_lastError;
	typedef std::map<uint32,std::map<WOWD_SCRIPTEVENT,std::set<std::string> > > eventmap;
	std::set<uint32> supportedentries;
	std::set<uint32> supportedmaps;
	bool support;

	eventmap m_eventMap;

	friend int HandleLuaCrash(lua_State *L);
	friend int BounceLuaCall(lua_State *L);
	friend int RunFileFromScript(lua_State *L);

	void runFileFromScript(const char *Path);
	void updateLastError();
	int handleCrash();
	void stackTrace();
	bool callFunctionAtTop(int args = 0);
	void registerTrampoline();
	void registerEventFuncs();
	void registerFuncs();
public:
	LuaEngine();
	~LuaEngine();
	std::string getLastError();
	bool runFile(const char *Path);
	bool runString(const char *String,const char *name = "Loaded Chunk");
	lua_State *getState();
	void registerEvent(uint32 entry, WOWD_SCRIPTEVENT event, const char *function);
	void unregisterEvent(uint32 entry, WOWD_SCRIPTEVENT event, const char *function);
	void handleEvent(Unit *pUnit, uint32 entry, WOWD_SCRIPTEVENT event);
	void handleMapEvent(WOWD_SCRIPTEVENT event);
	void registerMapEvent(WOWD_SCRIPTEVENT event, const char *function);
	void unregisterMapEvent(WOWD_SCRIPTEVENT event, const char *function);

	void addSupport();
	void addSupportForMapID(uint32 mapid);
	void addSupportForEntry(uint32 entry);
};

#endif
