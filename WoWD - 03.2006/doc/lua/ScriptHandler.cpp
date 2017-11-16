#include "Common.h"
#include "Core.h"
#include "ScriptHandler.h"
#include "WorldThread.h"
extern "C"
{
#include <lauxlib.h>
#include <lualib.h>
}

void Print(const char *text)
{
	LOG(text);
}
void ClassTestBind(lua_State *L);
LuaScriptHandler::LuaScriptHandler(WorldThread *thread): StopWatch(thread->GetStopWatch())
{
	State = lua_open();
	lua_baselibopen(State);
	luabind::open(State);
	using namespace luabind;
	module(State)
	[
		def("Write",&Print),
		class_<WorldThread>("__Thread")
				.def("PCC",&WorldThread::PCC)
	];
	lua_dostring(State,"function print(a) Write(tostring(a)) end _ALERT = print");
	
	object thrwrap(State,thread);
	get_globals(State)["Thread"] = thrwrap;
	wowPacket::LuaBind(State);
	ClassTestBind(State);
	/*State = LuaState::Create();
	LuaObject globals = State->GetGlobals();
	globals.Register("print",NOP_print);
	globals.RegisterEx("Quit",*this,LuaScriptHandler::QuitWorld);
	globals.RegisterEx("_ALERT",*this,LuaScriptHandler::Alert);
	//globals.RegisterEx("cls",wxGetApp(),NOPServer::ClearConsole);
	globals.RegisterEx("PCC",*thread,WorldThread::PCC);*/
	
	parent = thread;
}

LuaScriptHandler::~LuaScriptHandler(void)
{
	lua_close(State);
}

void LuaScriptHandler::ParseCommand(wxString *command)
{
	lua_dostring(State,command->c_str());
}

void LuaScriptHandler::QuitWorld()
{
	//hack hack hack
	wxGetApp().GetTopWindow()->Close();
}

void LuaScriptHandler::Alert(const char *text)
{
	LOG(text);

}

//test Only!
using namespace luabind;
class base
{
	int member;
public:
	base(int i)
	{
		LOG("base(%i)",i);	
		member = i;
	}
	virtual ~base()
	{
		LOG("~base()");
	}
	virtual void f()
	{
		LOG("called from base");
	}
};

class derived :public base
{
public:
	derived(int i) :base(i)
	{
		LOG("derived(%i)",i);
	}
	~derived()
	{
		LOG("~derived()");
	}
	virtual void f()
	{
		LOG("called from derived");
	}
};

class derived_wrapper : public derived
{
private:
	luabind::object m_l;
public:
	derived_wrapper(luabind::object l,int i): derived(i), m_l(l) {}

	virtual void f() { call_member<void>(m_l, "f"); }
	static void f_static(derived* ptr)
	{
	return ptr->derived::f();
	}
};

void ClassTestBind(lua_State *L)
{
	
	module(L)
	[
		class_<derived, derived_wrapper>("derived")
			.def(constructor<int>())
			.def("f", &derived_wrapper::f_static)
	];

	lua_dostring(L, "class 'script_derived' (derived)\n"
					"function script_derived:__init(a) super(a) end\n"
					"function script_derived:f() print(\"calling from script derived and sending down\") derived.f(self)  end\n");
	lua_dostring(L, "function create_derived(x) return script_derived(x) end");
	derived * b = call_function<derived*>(L,"script_derived",2);
	b->f();
}
