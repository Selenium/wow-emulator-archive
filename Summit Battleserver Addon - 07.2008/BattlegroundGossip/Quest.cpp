#include "StdAfx.h"
#include "Setup.h"

void OnQuestFinished(Player * pPlayer, Quest * pQuest)
{
	if(pQuest->id == 3)
	{
		pPlayer->Reset_Talents();
		pPlayer->BroadcastMessage("Your talents have been reset.");
		return;
	}
}

void SetupQuests(ScriptMgr * mgr)
{
	mgr->register_hook(SERVER_HOOK_EVENT_ON_QUEST_FINISHED, (void*)&OnQuestFinished);
}

