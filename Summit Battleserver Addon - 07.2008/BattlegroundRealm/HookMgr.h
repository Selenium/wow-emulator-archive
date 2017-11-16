#ifndef _HOOK_MGR_H
#define _HOOK_MGR_H

#include "Setup.h"

#define CREATE_HOOK(Name,Type,Map,Function) \
Type* Name = new Type; \
Name->mapId = Map; \
Name->function = Function; \
HookMgr::RegisterHook(Name);


typedef std::list<void*> HookList;

/* HookLists for each event and their structures */
struct EnterWorldHook
{
	uint32 mapId;
	void (*function)(Player * pPlayer);
};

struct CastSpellHook
{
	uint32 mapId;
	bool (*function)(Player * pPlayer, SpellEntry * pSpell);
};

struct FirstEnterWorldHook
{
	uint32 mapId;
	void (*function)(Player * pPlayer);
};

struct ArenaFinishHook
{
	uint32 mapId;
	void (*function)(Player * pPlayer, uint32 type, ArenaTeam * pTeam, bool rated, bool victory);
};

struct QuestFinishHook
{
	uint32 mapId;
	void (*function)(Player * pPlayer, Quest * pQuest);
};

struct HonorableKillHook
{
	uint32 mapId;
	void (*function)(Player * pPlayer, Player * pKilled);
};

struct DeathHook
{
	uint32 mapId;
	void (*function)(Player * pPlayer);
};

struct RepopHook
{
	uint32 mapId;
	bool (*function)(Player * pPlayer);
};

struct KillPlayerHook
{
	uint32 mapId;
	void (*function)(Player * pPlayer, Player * pVictim);
};

struct ContinentCreateHook
{
	uint32 mapId;
	void (*function)(MapMgr * pMapMgr);
};

struct PostSpellCastHook
{
	uint32 mapId;
	void (*function)(Player * pPlayer, SpellEntry * pSpell, Unit * pTarget);
};

class SCRIPT_DECL HookMgr
{
public:
	static void RegisterHook(EnterWorldHook * pHook);
	static void RegisterHook(CastSpellHook * pHook);
	static void RegisterHook(FirstEnterWorldHook * pHook);
	static void RegisterHook(ArenaFinishHook * pHook);
	static void RegisterHook(QuestFinishHook * pHook);
	static void RegisterHook(HonorableKillHook * pHook);
	static void RegisterHook(DeathHook * pHook);
	static void RegisterHook(RepopHook * pHook);
	static void RegisterHook(KillPlayerHook * pHook);
	static void RegisterHook(ContinentCreateHook * pHook);
	static void RegisterHook(PostSpellCastHook * pHook);
	static void HandleEnterWorldHook(Player * pPlayer);
	static bool HandleCastSpellHook(Player * pPlayer, SpellEntry * pSpell);
	static void HandleFirstEnterWorldHook(Player * pPlayer);
	static void HandleArenaFinishHook(Player * pPlayer, uint32 type, ArenaTeam * pTeam, bool rated, bool victory);
	static void HandleQuestFinishHook(Player * pPlayer, Quest * pQuest);
	static void HandleHonorableKillHook(Player * pPlayer, Player * pKilled);
	static void HandleDeathHook(Player * pPlayer);
	static bool HandleRepopHook(Player * pPlayer);
	static void HandleKillPlayerHook(Player * pPlayer, Player * pVictim);
	static void HandleContinentCreateHook(MapMgr * pMapMgr);
	static void HandlePostSpellCastHook(Player * pPlayer, SpellEntry * pSpell, Unit * pTarget);
};

#endif
