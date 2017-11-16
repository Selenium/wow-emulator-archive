#include "HookMgr.h"

HookList mEnterWorldHooks;
HookList mCastSpellHooks;
HookList mFirstEnterWorldHooks;
HookList mArenaFinishHooks;
HookList mQuestFinishHooks;
HookList mHonorableKillHooks;
HookList mDeathHooks;
HookList mRepopHooks;
HookList mKillPlayerHooks;
HookList mContinentCreateHooks;
HookList mPostSpellCastHooks;

void HookMgr::RegisterHook(PostSpellCastHook * pHook)
{
	mPostSpellCastHooks.push_back((void*)pHook);
}

void HookMgr::RegisterHook(ContinentCreateHook * pHook)
{
	mContinentCreateHooks.push_back((void*)pHook);
}

void HookMgr::RegisterHook(EnterWorldHook * pHook)
{
	mEnterWorldHooks.push_back((void*)pHook);
}

void HookMgr::RegisterHook(CastSpellHook * pHook)
{
	mCastSpellHooks.push_back((void*)pHook);
}

void HookMgr::RegisterHook(FirstEnterWorldHook * pHook)
{
	mFirstEnterWorldHooks.push_back((void*)pHook);
}

void HookMgr::RegisterHook(ArenaFinishHook * pHook)
{
	mArenaFinishHooks.push_back((void*)pHook);
}

void HookMgr::RegisterHook(QuestFinishHook * pHook)
{
	mQuestFinishHooks.push_back((void*)pHook);
}

void HookMgr::RegisterHook(HonorableKillHook * pHook)
{
	mHonorableKillHooks.push_back((void*)pHook);
}

void HookMgr::RegisterHook(DeathHook * pHook)
{
	mDeathHooks.push_back((void*)pHook);
}

void HookMgr::RegisterHook(RepopHook * pHook)
{
	mRepopHooks.push_back((void*)pHook);
}

void HookMgr::RegisterHook(KillPlayerHook * pHook)
{
	mKillPlayerHooks.push_back((void*)pHook);
}

void HookMgr::HandlePostSpellCastHook(Player * pPlayer, SpellEntry * pSpell, Unit * pTarget)
{
	HookList::iterator itr = mPostSpellCastHooks.begin();
	for(; itr != mPostSpellCastHooks.end(); itr++)
	{
		PostSpellCastHook * pHook = (PostSpellCastHook*)(*itr);
		if(pPlayer->GetMapId() == pHook->mapId || pHook->mapId == ALL_MAPS)
			pHook->function(pPlayer, pSpell, pTarget);
	}
}

void HookMgr::HandleContinentCreateHook(MapMgr * pMapMgr)
{
	HookList::iterator itr = mContinentCreateHooks.begin();
	for(; itr != mContinentCreateHooks.end(); itr++)
	{
		ContinentCreateHook * pHook = (ContinentCreateHook*)(*itr);
		if(pMapMgr->GetMapId() == pHook->mapId || pHook->mapId == ALL_MAPS)
			pHook->function(pMapMgr);
	}
}

void HookMgr::HandleEnterWorldHook(Player * pPlayer)
{
	HookList::iterator itr = mEnterWorldHooks.begin();
	for(; itr != mEnterWorldHooks.end(); itr++)
	{
		EnterWorldHook * pHook = (EnterWorldHook*)(*itr);
		if(pPlayer->GetMapId() == pHook->mapId || pHook->mapId == ALL_MAPS)
			pHook->function(pPlayer);
	}
}

bool HookMgr::HandleCastSpellHook(Player * pPlayer, SpellEntry * pSpell)
{
	bool pResult = true;
	HookList::iterator itr = mCastSpellHooks.begin();
	for(; itr != mCastSpellHooks.end(); itr++)
	{
		CastSpellHook * pHook = (CastSpellHook*)(*itr);
		if(pPlayer->GetMapId() == pHook->mapId || pHook->mapId == ALL_MAPS)
			pResult = pHook->function(pPlayer, pSpell);
	}

	return pResult;
}

void HookMgr::HandleFirstEnterWorldHook(Player * pPlayer)
{
	HookList::iterator itr = mFirstEnterWorldHooks.begin();
	for(; itr != mFirstEnterWorldHooks.end(); itr++)
	{
		FirstEnterWorldHook * pHook = (FirstEnterWorldHook*)(*itr);
		if(pPlayer->GetMapId() == pHook->mapId || pHook->mapId == ALL_MAPS)
			pHook->function(pPlayer);
	}
}

void HookMgr::HandleArenaFinishHook(Player * pPlayer, uint32 type, ArenaTeam * pTeam, bool rated, bool victory)
{
	HookList::iterator itr = mArenaFinishHooks.begin();
	for(; itr != mArenaFinishHooks.end(); itr++)
	{
		ArenaFinishHook * pHook = (ArenaFinishHook*)(*itr);
		if(pPlayer->GetMapId() == pHook->mapId || pHook->mapId == ALL_MAPS)
			pHook->function(pPlayer, type, pTeam, rated, victory);
	}
}

void HookMgr::HandleQuestFinishHook(Player * pPlayer, Quest * pQuest)
{
	HookList::iterator itr = mQuestFinishHooks.begin();
	for(; itr != mQuestFinishHooks.end(); itr++)
	{
		QuestFinishHook * pHook = (QuestFinishHook*)(*itr);
		if(pPlayer->GetMapId() == pHook->mapId || pHook->mapId == ALL_MAPS)
			pHook->function(pPlayer, pQuest);
	}
}

void HookMgr::HandleHonorableKillHook(Player * pPlayer, Player * pKilled)
{
	HookList::iterator itr = mHonorableKillHooks.begin();
	for(; itr != mHonorableKillHooks.end(); itr++)
	{
		HonorableKillHook * pHook = (HonorableKillHook*)(*itr);
		if(pPlayer->GetMapId() == pHook->mapId || pHook->mapId == ALL_MAPS)
			pHook->function(pPlayer, pKilled);
	}
}

void HookMgr::HandleDeathHook(Player * pPlayer)
{
	HookList::iterator itr = mDeathHooks.begin();
	for(; itr != mDeathHooks.end(); itr++)
	{
		DeathHook * pHook = (DeathHook*)(*itr);
		if(pPlayer->GetMapId() == pHook->mapId || pHook->mapId == ALL_MAPS)
			pHook->function(pPlayer);
	}
}

bool HookMgr::HandleRepopHook(Player * pPlayer)
{
	bool pResult = true;
	HookList::iterator itr = mRepopHooks.begin();
	for(; itr != mRepopHooks.end(); itr++)
	{
		RepopHook * pHook = (RepopHook*)(*itr);
		if(pPlayer->GetMapId() == pHook->mapId || pHook->mapId == ALL_MAPS)
			pResult = pHook->function(pPlayer);
	}
	return pResult;
}

void HookMgr::HandleKillPlayerHook(Player * pPlayer, Player * pVictim)
{
	HookList::iterator itr = mKillPlayerHooks.begin();
	for(; itr != mKillPlayerHooks.end(); itr++)
	{
		KillPlayerHook * pHook = (KillPlayerHook*)(*itr);
		if(pPlayer->GetMapId() == pHook->mapId || pHook->mapId == ALL_MAPS)
			pHook->function(pPlayer, pVictim);
	}
}