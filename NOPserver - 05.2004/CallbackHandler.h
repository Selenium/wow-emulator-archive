#ifndef _CALLBACKHANDLER_H
#define _CALLBACKHANDLER_H
#include "ScriptHandler.h"
#include "ScriptEvent.h"
#include "HandlerTemplates.h"
#include "WorldThread.h"

class CallbackHandler
{
	ScriptCallbackList ScriptCallbacks;
	CallbackList Callbacks;
	WorldThread *Parent;
	lua_State *L;
	wxStopWatch *sw;
public:
	CallbackHandler(WorldThread*);
	~CallbackHandler(void);
	void StartTest();
	void StopTest();

	void RegisterScriptCallback(luabind::functor<int> function,luabind::object table);
	void DoCallbackLoop()
	{
		Callbacks.Call();
		ScriptCallbacks.Call();
	}
	template<class T>
	CallbackFunctor * RegisterCallback(T* obj,long (T::*m)())
	{
		CallbackFunctor *F = new MemberCallbackFunctor<T>(Parent->GetStopWatch(),obj,m);
		Callbacks.Attach(F);
		return F;
	}
	CallbackFunctor * RegisterCallback(long (*f)())
	{
		CallbackFunctor *F = new FunctionCallbackFunctor(Parent->GetStopWatch(),f);
		Callbacks.Attach(F);
		return F;
	}
};

#endif
