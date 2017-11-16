#include "Common.h"
#include "WorldThread.h"
#include "CallbackHandler.h"
extern "C"
{
#include <lauxlib.h>
#include <lualib.h>
}
CallbackHandler::CallbackHandler(WorldThread *p) : ScriptCallbacks(p->GetStopWatch()),Parent(p)
{
	L = p->GetScriptHandler()->GetState();
	using namespace luabind;
	module(L)
	[
		class_<CallbackHandler>("__CallbackHandler")
			.def("RegisterCallback",&CallbackHandler::RegisterScriptCallback)
			.def("StartTest",&CallbackHandler::StartTest)
			.def("StopTest",&CallbackHandler::StopTest)
	];
	
	object wrap(L,this);
	get_globals(L)["CallbackHandler"] = wrap;
	lua_dostring(L,"function Start() CallbackHandler:StartTest() end function Stop() CallbackHandler:StopTest() end");
}

CallbackHandler::~CallbackHandler(void)
{
}




void CallbackHandler::RegisterScriptCallback(luabind::functor<int> function, luabind::object table)
{
	if (table.type() == LUA_TTABLE)
	{
		ScriptCallbacks.Attach(function,table);
	} 
}

void CallbackHandler::StartTest()
{
	bool ret;
	ret = lua_dostring(L,"dofile(\"x.lua\")");
	ret = lua_dostring(L,"test()");
	sw = new wxStopWatch();
	ret = lua_dostring(L,"testrunning = true");
}

void CallbackHandler::StopTest()
{
	sw->Pause();
	lua_dostring(L,"testrunning = false");
	lua_dostring(L,"Write(tostring(callcount))");
	LOG("time: %ldms",sw->Time());
	delete sw;
}
