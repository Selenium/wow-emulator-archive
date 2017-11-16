/*
 *  **********  (c) 2005 PavkaM. Ludmilla Project *************
 */

#include "StdAfx.h"

createFileSingleton( QuestScriptBackend );

void QuestScriptBackend::scriptCallGossipHello      ( Player *pPlayer, Creature *pCreature ) 
{
	pPlayer->_GossipMenu->Clear();
	pPlayer->_QuestMenu->Clear();

	Call_Unit_OnGossipHello( pCreature, pPlayer );
}

void QuestScriptBackend::scriptCallQuestAccept      ( Player *pPlayer, Creature *pCreature, Quest *pQuest ) 
{
	pPlayer->_GossipMenu->Clear();
	pPlayer->_QuestMenu->Clear();

	Call_Unit_OnQuestAccept( pCreature, pPlayer, pQuest->m_questId );
}

void QuestScriptBackend::scriptCallGossipSelect     ( Player *pPlayer, Creature *pCreature, uint32 opt, GossipData data )
{
	pPlayer->_GossipMenu->Clear();
	pPlayer->_QuestMenu->Clear();

	Call_Unit_OnGossipSelect( pCreature, pPlayer, data.iDataSender, data.iDataSub );
}

void QuestScriptBackend::scriptCallGossipSelectWithCode     ( Player *pPlayer, Creature *pCreature, uint32 opt, GossipData data, char* sCode)
{
	pPlayer->_GossipMenu->Clear();
	pPlayer->_QuestMenu->Clear();

	Call_Unit_OnGossipSelectCode( pCreature, pPlayer, data.iDataSender, data.iDataSub, sCode);
}

void QuestScriptBackend::scriptCallQuestSelect      ( Player *pPlayer, Creature *pCreature, Quest *pQuest )
{
	pPlayer->_GossipMenu->Clear();
	pPlayer->_QuestMenu->Clear();

	Call_Unit_OnQuestSelect( pCreature, pPlayer, pQuest->m_questId );
}

void QuestScriptBackend::scriptCallQuestComplete    ( Player *pPlayer, Creature *pCreature, Quest *pQuest )
{
	pPlayer->_GossipMenu->Clear();
	pPlayer->_QuestMenu->Clear();

	Call_Unit_OnQuestComplete( pCreature, pPlayer, pQuest->m_questId );
}

uint32 QuestScriptBackend::scriptCallNPCDialogStatus  ( Player *pPlayer, Creature *pCreature )
{
	return Call_Unit_OnDialogStatus( pCreature, pPlayer );
}

void QuestScriptBackend::scriptCallChooseReward     ( Player *pPlayer, Creature *pCreature, Quest *pQuest, uint32 opt )
{
	pPlayer->_GossipMenu->Clear();
	pPlayer->_QuestMenu->Clear();

	Call_Unit_OnChooseReward( pCreature, pPlayer, pQuest->m_questId, opt );
}

void QuestScriptBackend::scriptCallItemHello        ( Player *pPlayer, Item *pItem, Quest *pQuest )
{
	Call_Item_OnSelect( pItem, pPlayer, pQuest->m_questId );
}

void QuestScriptBackend::scriptCallGOHello          ( Player *pPlayer, GameObject *pGO )
{
	Call_Obj_OnSelect( pGO, pPlayer );
}

void QuestScriptBackend::scriptCallAreaTrigger      ( Player *pPlayer, Quest *pQuest, uint32 triggerID )
{
	if (pQuest)
		Call_Trigger_OnSelect( pPlayer, triggerID, pQuest->m_questId ); else
		Call_Trigger_OnSelect( pPlayer, triggerID, 0 );
}

void QuestScriptBackend::scriptCallItemQuestAccept  ( Player *pPlayer, Item *pItem, Quest *pQuest )
{
	Call_Item_OnQuestAccept( pItem, pPlayer, pQuest->m_questId );
}

void QuestScriptBackend::scriptCallGOQuestAccept    ( Player *pPlayer, GameObject *pGO, Quest *pQuest )
{
	Call_Obj_OnQuestAccept( pGO, pPlayer, pQuest->m_questId );
}

void QuestScriptBackend::scriptCallGOChooseReward   ( Player *pPlayer, GameObject *pGameObject, Quest *pQuest, uint32 opt )
{
	Call_Obj_OnChooseReward( pGameObject, pPlayer, pQuest->m_questId, opt );
}
