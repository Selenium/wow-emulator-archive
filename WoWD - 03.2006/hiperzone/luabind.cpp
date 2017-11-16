// luabind.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "luabind.h"


void testclass::add()
{

	printf(".add called\r");
}

void testclass::remove()
{
	printf(".remove called\r");
}



void register_class(lua_State *Lua)
{
	luabind::module(Lua)
[
	class_<testclass>("testclass")
	.def("add", &testclass::add)
	.def("remove", &testclass::remove)
];


}

int _tmain(int argc, _TCHAR* argv[])
{

	//lua_pop(), deletes the value from the stack
	lua_State* Lua;

	Lua = lua_open();
	luabind::open(Lua); 
	lua_baselibopen(Lua);
	lua_iolibopen(Lua);
	lua_strlibopen(Lua);
	lua_mathlibopen(Lua);
	register_class(Lua);


	//Create a table to store the scripts

	lua_newtable( Lua );
	
	lua_pushstring( Lua, "test.lua" );
	luaL_loadfile(Lua, "test.lua");
	lua_setglobal( Lua, "scripts" );
	lua_settable(Lua, -3 );

	lua_pushstring( Lua, "test1.lua" );
	luaL_loadfile(Lua, "test1.lua");
	lua_setglobal( Lua, "scripts1" );
	lua_settable(Lua, -3 );
	//call script*/

	testclass *pPointer;
	pPointer = new testclass;

	lua_gettable( Lua, -2 );
	lua_pushstring( Lua, "test.lua" );
	lua_getglobal( Lua, "scripts" );
	
	lua_pcall( Lua, 0, LUA_MULTRET, 0 );
	call_function<void>(Lua, "ON_EVENT", *pPointer);

	lua_pushstring( Lua, "test1.lua" );
	lua_getglobal( Lua, "scripts1" );

	
	lua_pcall( Lua, 0, LUA_MULTRET, 0 );
	call_function<void>(Lua, "ON_EVENT", *pPointer);
///end of code*/
	//luaL_loadfile(Lua, "test.lua");
	//luaL_loadfile(Lua, "test1.lua");
	//lua_dofile(Lua, "test.lua");

	
/*
	lua_pushvalue( Lua, -1 );
	lua_pcall( Lua, 0, 0, 0 );
	call_function<void>(Lua, "ON_EVENT", *pPointer);

	lua_pushvalue( Lua, -2 );
	lua_pcall( Lua, 0, 0, 0 );
	call_function<void>(Lua, "ON_EVENT", *pPointer);

*/

	lua_close(Lua);


	return 0;
}

