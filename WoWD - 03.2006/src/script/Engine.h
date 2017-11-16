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

#ifndef WOWD_SCRIPTENGINE
#define WOWD_SCRIPTENGINE

#include "ScriptCommon.h"
#include "Common.h"
#include "Singleton.h"
#include "LuaEngine.h"


extern "C" {
#include "lua.h"
#include "lualib.h"
#include "lauxlib.h"
};

int AddFile(lua_State *L);
int AddFileToEntry(lua_State *L);
int AddFileToMapID(lua_State *L);
class LuaManager : public Singleton<LuaManager>
{
private:
	typedef std::set<std::string> fileset;
	typedef std::map<uint32,fileset> filemap;
	fileset m_files;
	filemap m_mapID;
	filemap m_entry;
	std::map<uint32,LuaEngine *> m_engines;
	LuaEngine *eng;
	void addWowdLibSupport(lua_State *Lua);
	void registerSupportFuncs(lua_State *m_state);
public:
	LuaManager();
	~LuaManager();
	LuaEngine *getInnerEngine();
	void addFile(const char *file);
	void removeFile(const char *file);
	void addFileToMapID(const char *file, uint32 mapid);
	void removeFileFromMapID(const char *file, uint32 mapid);
	void addFileToEntry(const char *file, uint32 entry);
	void removeFileFromEntry(const char *file, uint32 entry);
	void addSupportForMapID(LuaEngine *L, uint32 mapid);
	void addSupportForEntry(LuaEngine *L, uint32 entry);
	void addSupport(LuaEngine *L);
	LuaEngine *getEngine(uint32 instanceID);
	void closeEngine(uint32 instanceID);
};

#define sLuaManager LuaManager::getSingleton()
#endif
