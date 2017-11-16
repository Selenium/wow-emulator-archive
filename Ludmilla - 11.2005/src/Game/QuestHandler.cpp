/*
 *  **********  (c) 2005 PavkaM. Ludmilla Project *************
 */

#include "StdAfx.h"
#include "../Shared/PacketBuilder.h"


/*
   World Definitions
   -----------------
*/

void WorldSession::HandleQuestgiverStatusQueryOpcode( WorldPacket & recv_data )
{
    Log::getSingleton( ).outDebug( "WORLD: Received CMSG_QUESTGIVER_STATUS_QUERY" );
    uint64 guid;
    recv_data >> guid;

    Creature *pCreature = objmgr.GetObject<Creature>(guid);

    if (!pCreature)
    {
        Log::getSingleton( ).outError( "WORLD: received incorrect guid in CMSG_QUESTGIVER_STATUS_QUERY" );
        return;
    }

	uint32 questStatus = QuestScriptBackend::getSingleton().scriptCallNPCDialogStatus(GetPlayer(), pCreature );

	if ( ( questStatus == DIALOG_STATUS_REWARD ) ||
		 ( questStatus == DIALOG_STATUS_REWARD_REP ) )
		pCreature->MinimapTrackingStatus( true ); else
		pCreature->MinimapTrackingStatus( false );

	QuestPacketHandler::getSingleton().SendNPCQuestStatus(this, questStatus, guid );
}


void WorldSession::HandleQuestgiverHelloOpcode( WorldPacket & recv_data )
{
    Log::getSingleton( ).outDebug( "WORLD: Received CMSG_QUESTGIVER_HELLO" );

    uint64 guid;

	NPCGossipMenu *pMenu;
	pMenu = GetPlayer()->GetPreviousGossipMenu();
	GetPlayer()->SetPreviousGossipMenu( NULL, 0 );

	if ( (pMenu) && (GetPlayer()->_GossipMenu != pMenu)) delete pMenu;

    recv_data >> guid;
    Creature *pCreature = objmgr.GetObject<Creature>(guid);

    if(!pCreature)
    {
        Log::getSingleton( ).outError( "WORLD: Received incorrect guid in CMSG_QUESTGIVER_HELLO" );
        return;
    }

	QuestScriptBackend::getSingleton().scriptCallGossipHello( GetPlayer(), pCreature );
}


void WorldSession::HandleQuestgiverAcceptQuestOpcode( WorldPacket & recv_data )
{
    Log::getSingleton( ).outDebug( "WORLD: Received CMSG_QUESTGIVER_ACCEPT_QUEST" );

    uint64 guid;
    uint32 quest_id;

    recv_data >> guid >> quest_id;

    Quest *pQuest = objmgr.GetQuest(quest_id);
	if (!pQuest)
	{
		QuestPacketHandler::getSingleton().SendQuestInvalid( this, quest_id );
		return;
	}

	if ( GetPlayer()->m_timedQuest != 0)
	{
		QuestPacketHandler::getSingleton().SendQuestInvalid( this, INVALIDREASON_HAVE_TIMED_QUEST );
		return;
	}

	if ( pQuest->m_srcItem > 0 )
	 if ( !GetPlayer()->AddItemToBackpack( pQuest->m_srcItem, 1) )
	 {
		 QuestPacketHandler::getSingleton().SendQuestFailedToPlayer( this, FAILEDREASON_INV_FULL );
		 return; // No free slot to add an item to backpack !
	 }

    uint16 log_slot = GetPlayer()->getOpenQuestSlot();
    if (log_slot == 0)
    {
        QuestPacketHandler::getSingleton().SendQuestLogFullMessage( this );
        return;
    }

    GetPlayer()->SetUInt32Value(log_slot + 0, quest_id);
    GetPlayer()->SetUInt32Value(log_slot + 1, 0);
    GetPlayer()->SetUInt32Value(log_slot + 2, 0);

    Log::getSingleton( ).outDebug( "WORLD: Sent Quest Acceptance" );

    GetPlayer()->setQuestStatus(quest_id, QUEST_STATUS_INCOMPLETE, false);

	if ( GetPlayer()->checkQuestStatus(quest_id) )
	{
		QuestPacketHandler::getSingleton().SendQuestUpdateComplete( this, pQuest );
		GetPlayer()->setQuestStatus(quest_id, QUEST_STATUS_COMPLETE, false);
	}


	Creature *pCreature = objmgr.GetObject<Creature>(guid);

	if (!pCreature)
	{
		uint32 islot = GetPlayer()->GetSlotByItemGUID( guid );
		Item *pItem;

		if (islot)
			pItem = GetPlayer()->GetItemBySlot( (uint8)islot );

		if (!islot || !pItem)
		{
			GameObject *pGO = objmgr.GetObject<GameObject>(guid);
			ASSERT(pGO);

	        QuestScriptBackend::getSingleton().scriptCallGOQuestAccept( GetPlayer(), pGO, pQuest );

			return;
		}

		QuestScriptBackend::getSingleton().scriptCallItemQuestAccept( GetPlayer(), pItem, pQuest );

		return;
	}

	QuestScriptBackend::getSingleton().scriptCallQuestAccept( GetPlayer(), pCreature, pQuest );

	sChatHandler.GMMessage( this, "GM: Accepted Quest {%d}.", quest_id );
	GetPlayer()->SaveToDB();
}


void WorldSession::HandleQuestgiverQuestQueryOpcode( WorldPacket & recv_data )
{
    Log::getSingleton( ).outDebug( "WORLD: Received CMSG_QUESTGIVER_QUERY_QUEST" );

	uint64 guid;
    uint32 quest_id = 0;
    recv_data >> guid >> quest_id;

    Quest *pQuest = objmgr.GetQuest(quest_id);

	if (!pQuest)
	{
		Log::getSingleton( ).outError("Invalid Quest ID (or not in the ObjMgr) '%d' received from player.", quest_id);
		return;
	}

    Creature *pCreature     = objmgr.GetObject<Creature>(guid);
	if (!pCreature)
	{
		uint32 islot = GetPlayer()->GetSlotByItemGUID( guid );
		Item *pItem;

		if (islot)
			pItem = GetPlayer()->GetItemBySlot( (uint8)islot );

		if (!islot || !pItem)
		{
			GameObject *pGO = objmgr.GetObject<GameObject>(guid);
			ASSERT(pGO);

	        QuestScriptBackend::getSingleton().scriptCallGOHello( GetPlayer(), pGO );
			return;
		}

		QuestScriptBackend::getSingleton().scriptCallItemHello( GetPlayer(), pItem, pQuest );
		return;
	}

	QuestScriptBackend::getSingleton().scriptCallQuestSelect( GetPlayer(), pCreature, pQuest );
}

void WorldSession::HandleQuestQueryOpcode( WorldPacket & recv_data )
{
    Log::getSingleton( ).outDebug( "WORLD: Received CMSG_QUEST_QUERY" );

    uint32 quest_id = 0;
    recv_data >> quest_id;

    Quest *pQuest = objmgr.GetQuest(quest_id);

	if (!pQuest)
	{
		QuestPacketHandler::getSingleton().SendQuestInvalid( this, quest_id );
		return;
	}

	QuestPacketHandler::getSingleton().SendFullQuestDetailsToPlayer( this, pQuest );
}


void WorldSession::HandleQuestgiverChooseRewardOpcode( WorldPacket & recv_data )
{
    
    Log::getSingleton( ).outString( "WORLD: Received CMSG_QUESTGIVER_CHOOSE_REWARD" );

    uint32 quest_id, rewardid;
	uint64 guid1;
    recv_data >> guid1 >> quest_id >> rewardid;

    Quest *pQuest = objmgr.GetQuest(quest_id);

    // Set player object with rewards!
    Player *chr = GetPlayer();

	if (!pQuest)
	{
		QuestPacketHandler::getSingleton().SendQuestInvalid( this, quest_id );
		return;
	}

	// Requirements

	if (pQuest->m_rewardGold < 0) 
		if ( !( (chr->GetMoney() - pQuest->m_rewardGold) >= 0) )
		{
			QuestPacketHandler::getSingleton().SendQuestInvalid( this, INVALIDREASON_DONT_HAVE_REQ_MONEY );
			return;
		}

	// removing items ...
	if ( pQuest->m_questItemId[0] > 0 ) 
		if (!chr->HasItemInBackpack( pQuest->m_questItemId[0], pQuest->m_questItemCount[0])) 
		{
			QuestPacketHandler::getSingleton().SendQuestInvalid( this, INVALIDREASON_DONT_HAVE_REQ_ITEMS );
			return;
		}

	if ( pQuest->m_questItemId[1] > 0 ) 
		if (!chr->HasItemInBackpack( pQuest->m_questItemId[1], pQuest->m_questItemCount[1]))
		{
			QuestPacketHandler::getSingleton().SendQuestInvalid( this, INVALIDREASON_DONT_HAVE_REQ_ITEMS );
			return;
		}

	if ( pQuest->m_questItemId[2] > 0 ) 
		if (!chr->HasItemInBackpack( pQuest->m_questItemId[2], pQuest->m_questItemCount[2]))
		{
			QuestPacketHandler::getSingleton().SendQuestInvalid( this, INVALIDREASON_DONT_HAVE_REQ_ITEMS );
			return;
		}

	if ( pQuest->m_questItemId[3] > 0 ) 
		if (!chr->HasItemInBackpack( pQuest->m_questItemId[3], pQuest->m_questItemCount[3]))
		{
			QuestPacketHandler::getSingleton().SendQuestInvalid( this, INVALIDREASON_DONT_HAVE_REQ_ITEMS );
			return;
		}

	if ( pQuest->m_questItemId[0] > 0 ) chr->RemoveItemFromBackpack( pQuest->m_questItemId[0], pQuest->m_questItemCount[0]);
	if ( pQuest->m_questItemId[1] > 0 ) chr->RemoveItemFromBackpack( pQuest->m_questItemId[1], pQuest->m_questItemCount[1]);
	if ( pQuest->m_questItemId[2] > 0 ) chr->RemoveItemFromBackpack( pQuest->m_questItemId[2], pQuest->m_questItemCount[2]);
	if ( pQuest->m_questItemId[3] > 0 ) chr->RemoveItemFromBackpack( pQuest->m_questItemId[3], pQuest->m_questItemCount[3]);

	if (pQuest->m_rewardGold < 0) 
		chr->ModifyMoney(pQuest->m_rewardGold);

	// Rewards ...

	if ( ( rewardid >= pQuest->m_choiceRewards ) && ( pQuest->m_choiceRewards > 0 ) )
	{
		Log::getSingleton().outString("WORLD: Attempt to select an unexisting rewardid !");
		return;
	}

	QuestPacketHandler::getSingleton().SendQuestUpdateComplete( this, pQuest );
	QuestPacketHandler::getSingleton().SendQuestCompleteToPlayer( this, pQuest );

    GetPlayer()->setQuestStatus(quest_id, QUEST_STATUS_COMPLETE, true);

    uint16 log_slot = GetPlayer()->getQuestSlot(quest_id);

	if (pQuest->m_rewardGold > 0) chr->ModifyMoney( pQuest->m_rewardGold );

	// Add items to backpack

	bool bkFull = false;
	for ( int iI = 0; iI < pQuest->m_itemRewards; iI++ )
		if (!GetPlayer()->AddItemToBackpack( pQuest->m_rewardItemId[iI], pQuest->m_rewardItemCount[iI] )) 
		{ 
			bkFull = true; 
			break; 
		}

	if ( pQuest->m_choiceRewards > 0 )
	{
		if  (!bkFull) 
			GetPlayer()->AddItemToBackpack( pQuest->m_choiceItemId[rewardid], pQuest->m_choiceItemCount[rewardid] ); else
			QuestPacketHandler::getSingleton().SendQuestFailedToPlayer ( this, FAILEDREASON_INV_FULL );
	}

	// -- Teach the spell to the player

	if ( pQuest->m_learnSpell > 0 ) 
	{
		WorldPacket sdata;

		if ( GetPlayer()->AddSpell( pQuest->m_learnSpell ) ) 
		{
			sdata.Initialize (SMSG_LEARNED_SPELL);
			sdata << pQuest->m_learnSpell;
			SendPacket( &sdata );

			Make_SMSG_SPELL_GO (&sdata, 476, GetPlayer(), GetPlayer());
			GetPlayer()->SendMessageToSet (&sdata, true);
		}
	}

	// -- Free the quest occupied slot --
    chr->SetUInt32Value(log_slot+0, 0);
    chr->SetUInt32Value(log_slot+1, 0);
    chr->SetUInt32Value(log_slot+2, 0);

	chr->GiveXP( pQuest->GenerateQuestXP( chr ), guid1 );

	chr->setQuestStatus( quest_id, QUEST_STATUS_AVAILABLE, true); // reset the qs.

    Creature *pCreature     = objmgr.GetObject<Creature>(guid1);
	GameObject *pGameObject = objmgr.GetObject<GameObject>(guid1);

	if (pCreature)
		QuestScriptBackend::getSingleton().scriptCallChooseReward(  GetPlayer(), pCreature, pQuest, rewardid ); else
		if (pGameObject)
			QuestScriptBackend::getSingleton().scriptCallGOChooseReward(  GetPlayer(), pGameObject, pQuest, rewardid );

	GetPlayer()->SaveToDB();
}


void WorldSession::HandleQuestgiverRequestRewardOpcode( WorldPacket & recv_data )
{
    Log::getSingleton( ).outString( "WORLD: Received CMSG_QUESTGIVER_REQUEST_REWARD" );

    uint32 quest_id;
	uint64 guid;
	recv_data >> guid >> quest_id;

	Quest *pQuest		= objmgr.GetQuest( quest_id );
	Creature *pCreature = objmgr.GetObject<Creature>(guid);

	if (!pQuest)
	{
		Log::getSingleton( ).outError("Invalid Quest ID (or not in the ObjMgr) '%d' received from player.", quest_id);
		return;
	}

	if (!pCreature)
	{
		Log::getSingleton( ).outError("Invalid NPC GUID (or not in the ObjMgr) '%d' received from player.", guid);
		return;
	}

	if ( GetPlayer()->isQuestComplete( quest_id, pCreature ) )
		QuestPacketHandler::getSingleton().SendRewardToPlayer( this, pQuest, guid); else
		this->SystemMessage( "You haven't yet finished the quest to request a reward." );
}


void WorldSession::HandleQuestgiverCancel(WorldPacket& recv_data )
{
    Log::getSingleton( ).outString( "WORLD: Received CMSG_QUESTGIVER_CANCEL" );

	// ---> Closes the current gossip window.
	QuestPacketHandler::getSingleton().SendCloseGossipToPlayer( this );
}

void WorldSession::HandleQuestLogSwapQuest(WorldPacket& recv_data )
{
    Log::getSingleton( ).outString( "WORLD: Received CMSG_QUESTLOG_SWAP_QUEST" );

	uint8 slot_id1, slot_id2;

	recv_data >> slot_id1 >> slot_id2;

	uint16 log_slot1 = GetPlayer()->getQuestSlotById( slot_id1 );
	uint16 log_slot2 = GetPlayer()->getQuestSlotById( slot_id2 );

	uint32 temp1, temp2;

	for (int iCx = 0; iCx < 3; iCx++ )
	{
		temp1 = GetPlayer()->GetUInt32Value(log_slot1 + iCx);
		temp2 = GetPlayer()->GetUInt32Value(log_slot2 + iCx);

		GetPlayer()->SetUInt32Value(log_slot1 + iCx, temp2);
		GetPlayer()->SetUInt32Value(log_slot2 + iCx, temp1);
	}

	GetPlayer()->SaveToDB();
}

void WorldSession::HandleQuestLogRemoveQuest(WorldPacket& recv_data)
{
    Log::getSingleton( ).outString( "WORLD: Received CMSG_QUESTLOG_REMOVE_QUEST" );

	uint8 slot_id;
	uint32 quest_id;

	recv_data >> slot_id;
	slot_id++;

	uint16 log_slot = GetPlayer()->getQuestSlotById( slot_id );
	quest_id = GetPlayer()->GetUInt32Value(log_slot + 0);

	if ( ( GetPlayer()->getQuestStatus(quest_id) != QUEST_STATUS_COMPLETE ) &&
		 ( GetPlayer()->getQuestStatus(quest_id) != QUEST_STATUS_INCOMPLETE ) )
		{
			Log::getSingleton( ).outError("Trying to remove an invalid quest '%d' from log.", quest_id);
			return;
		}
	GetPlayer()->SetUInt32Value(log_slot + 0, 0);
	GetPlayer()->SetUInt32Value(log_slot + 1, 0);
	GetPlayer()->SetUInt32Value(log_slot + 2, 0);
	GetPlayer()->setQuestStatus( quest_id, QUEST_STATUS_AVAILABLE, false); // reset the qs.

	GetPlayer()->SaveToDB();
}

void WorldSession::HandleQuestConfirmAccept(WorldPacket& recv_data)
{
    Log::getSingleton( ).outString( "WORLD: Received CMSG_QUEST_CONFIRM_ACCEPT" );

    uint32 quest_id;
	recv_data >> quest_id;

	Quest *pQuest = objmgr.GetQuest( quest_id );

	if (!pQuest)
	{
		Log::getSingleton( ).outError("Invalid Quest ID (or not in the ObjMgr) '%d' received from player.", quest_id);
		return;
	}

	QuestPacketHandler::getSingleton().SendQuestConfirmAccept( this, pQuest );
}

void WorldSession::HandleQuestComplete(WorldPacket& recv_data)
{
    Log::getSingleton( ).outString( "WORLD: Received CMSG_QUESTGIVER_COMPLETE_QUEST" );

    uint32 quest_id;
	uint64 guid;

	recv_data >> guid >> quest_id;

	Quest *pQuest = objmgr.GetQuest( quest_id );
	Creature *pCreature = objmgr.GetObject<Creature>( guid );

	if (!pQuest)
	{
		Log::getSingleton( ).outError("Invalid Quest ID (or not in the ObjMgr) '%d' received from player.", quest_id);
		return;
	}

	QuestScriptBackend::getSingleton().scriptCallQuestComplete(  GetPlayer(), pCreature, pQuest );
}

void WorldSession::HandleQuestAutoLaunch(WorldPacket& recvPacket)
{
	Log::getSingleton( ).outString( "WORLD: Received CMSG_QUESTGIVER_QUEST_AUTOLAUNCH (Unhandled!)" );
}