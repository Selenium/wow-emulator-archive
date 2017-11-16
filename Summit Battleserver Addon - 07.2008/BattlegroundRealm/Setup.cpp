#include "StdAfx.h"
#include "Setup.h"
#define SKIP_ALLOCATOR_SHARING 1
#include <ScriptSetup.h>

extern "C" SCRIPT_DECL uint32 _exp_get_script_type()
{
	return SCRIPT_TYPE_MISC;
}

extern "C" SCRIPT_DECL void _exp_script_register(ScriptMgr* mgr)
{
	RegisterMasterHooks(mgr);
	SetupGlobal();
	SetupGenericBGs();
	SetupMounts();
	SetupHealerBadges();
}

void RegisterMasterHooks(ScriptMgr * mgr)
{
	mgr->register_hook(SERVER_HOOK_EVENT_ON_FIRST_ENTER_WORLD, (void*)&HookMgr::HandleFirstEnterWorldHook);
	mgr->register_hook(SERVER_HOOK_EVENT_ON_ENTER_WORLD, (void*)&HookMgr::HandleEnterWorldHook);
	mgr->register_hook(SERVER_HOOK_EVENT_ON_CAST_SPELL, (void*)&HookMgr::HandleCastSpellHook);
	mgr->register_hook(SERVER_HOOK_EVENT_ON_ARENA_FINISH, (void*)&HookMgr::HandleArenaFinishHook);
	mgr->register_hook(SERVER_HOOK_EVENT_ON_QUEST_FINISHED, (void*)&HookMgr::HandleQuestFinishHook);
	mgr->register_hook(SERVER_HOOK_EVENT_ON_HONORABLE_KILL, (void*)&HookMgr::HandleHonorableKillHook);
	mgr->register_hook(SERVER_HOOK_EVENT_ON_DEATH, (void*)&HookMgr::HandleDeathHook);
	mgr->register_hook(SERVER_HOOK_EVENT_ON_REPOP, (void*)&HookMgr::HandleRepopHook);
	mgr->register_hook(SERVER_HOOK_EVENT_ON_KILL_PLAYER, (void*)&HookMgr::HandleKillPlayerHook);
	mgr->register_hook(SERVER_HOOK_EVENT_ON_CONTIENT_CREATE, (void*)&HookMgr::HandleContinentCreateHook);
	mgr->register_hook(SERVER_HOOK_EVENT_ON_POST_SPELL_CAST, (void*)&HookMgr::HandlePostSpellCastHook);
}

#ifdef WIN32

BOOL APIENTRY DllMain( HANDLE hModule, DWORD  ul_reason_for_call, LPVOID lpReserved )
{
    return TRUE;
}

#endif


