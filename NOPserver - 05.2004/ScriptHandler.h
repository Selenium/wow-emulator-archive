#ifndef _SCRIPTHANDLER_H
#define _SCRIPTHANDLER_H

extern "C" {
#include <lua.h>
}
#define oldnew new
#undef new
#include <luabind/luabind.hpp>
#define new oldnew



class WorldThread;
class LuaScriptHandler 
	
{
	lua_State *State;
	WorldThread *parent;
	
	wxStopWatch &StopWatch;
public:
	void Alert(const char *);
	LuaScriptHandler(WorldThread *thread);
	~LuaScriptHandler(void);
	void InitScript();
	lua_State *GetState() const
	{
		return State;
	}
	void QuitWorld();
	
	void ParseCommand(wxString *command);
private:
};

#endif

