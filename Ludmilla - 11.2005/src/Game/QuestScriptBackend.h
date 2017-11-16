/*
 *  **********  (c) 2005 PavkaM. Ludmilla Project *************
 */

#ifndef __QUEST_SCRIPTS_H
#define __QUEST_SCRIPTS_H

#include "StdAfx.h"
#include "QuestPacketHandler.h"

class QuestScriptBackend : public Singleton< QuestScriptBackend >
{
public:

	// Need implementation of Scripting !

	void scriptCallGossipHello      ( Player *pPlayer, Creature *pCreature );
	void scriptCallQuestAccept      ( Player *pPlayer, Creature *pCreature, Quest *pQuest );;
	void scriptCallGossipSelect     ( Player *pPlayer, Creature *pCreature, uint32 opt, GossipData data );
	void scriptCallGossipSelectWithCode     ( Player *pPlayer, Creature *pCreature, uint32 opt, GossipData data, char* sCode );
	void scriptCallQuestSelect      ( Player *pPlayer, Creature *pCreature, Quest *pQuest );
    void scriptCallQuestComplete    ( Player *pPlayer, Creature *pCreature, Quest *pQuest );
  uint32 scriptCallNPCDialogStatus  ( Player *pPlayer, Creature *pCreature );
	void scriptCallChooseReward     ( Player *pPlayer, Creature *pCreature, Quest *pQuest, uint32 opt );
	void scriptCallItemHello        ( Player *pPlayer, Item *pItem, Quest *pQuest );
	void scriptCallGOHello          ( Player *pPlayer, GameObject *pGO );
	void scriptCallAreaTrigger      ( Player *pPlayer, Quest *pQuest, uint32 triggerID );
	void scriptCallItemQuestAccept  ( Player *pPlayer, Item *pItem, Quest *pQuest );
	void scriptCallGOQuestAccept    ( Player *pPlayer, GameObject *pGO, Quest *pQuest );
	void scriptCallGOChooseReward   ( Player *pPlayer, GameObject *pGameObject, Quest *pQuest, uint32 opt );
};

#endif