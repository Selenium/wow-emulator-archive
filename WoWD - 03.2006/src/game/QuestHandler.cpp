// Copyright (C) 2004 WoW Daemon
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.

#include "Common.h"
#include "Log.h"
#include "QuestMgr.h"
#include "ObjectMgr.h"
initialiseSingleton( QuestMgr );

void WorldSession::HandleQuestgiverStatusQueryOpcode( WorldPacket & recv_data )
{

    Log::getSingleton( ).outDebug( "WORLD: Recieved CMSG_QUESTGIVER_STATUS_QUERY." );

    uint64 guid;
    WorldPacket data;

    recv_data >> guid;

	Creature *qst_giver = objmgr.GetObject<Creature>(guid);

	if (!qst_giver)
	{
		Log::getSingleton( ).outDebug("WORLD: Invalid questgiver GUID "I64FMT".", guid);
		return;
	}

    if (!qst_giver->isQuestGiver())
    {
		Log::getSingleton( ).outDebug("WORLD: Creature is not a questgiver.");
		return;
    }

	data.Initialize( SMSG_QUESTGIVER_STATUS );
	

    data << guid << sQuestMgr.CalcStatus(qst_giver, GetPlayer());
    SendPacket( &data );
}


void WorldSession::HandleQuestgiverHelloOpcode( WorldPacket & recv_data )
{
    Log::getSingleton( ).outDebug( "WORLD: Recieved CMSG_QUESTGIVER_HELLO." );
	
	uint64 guid;
    uint32 questCount;
    uint32 status;

    recv_data >> guid;

	Creature *qst_giver = objmgr.GetObject<Creature>(guid);

	if (!qst_giver)
	{
		Log::getSingleton( ).outDebug("WORLD: Invalid questgiver GUID.");
		return;
	}

    if (!qst_giver->isQuestGiver())
    {
		Log::getSingleton( ).outDebug("WORLD: Creature is not a questgiver.");
		return;
    }

    questCount = sQuestMgr.ActiveQuestsCount(qst_giver, GetPlayer());

    if (questCount == 0) 
    {
        Log::getSingleton( ).outDebug("WORLD: Invalid NPC for CMSG_QUESTGIVER_HELLO.");
        return;
    }
    else if (questCount == 1)
    {
        std::list<QuestRelation *>::const_iterator itr;

        for(itr = qst_giver->QuestsBegin(); itr != qst_giver->QuestsEnd(); itr++) 
            if (sQuestMgr.CalcQuestStatus(qst_giver, GetPlayer(), *itr) >= QMGR_QUEST_NOT_FINISHED)
                break;

        
        if (sQuestMgr.CalcStatus(qst_giver, GetPlayer()) < QMGR_QUEST_NOT_FINISHED)
            return; 

        ASSERT(itr != qst_giver->QuestsEnd());
	    
        status = sQuestMgr.CalcStatus(qst_giver, GetPlayer());

        if ((status == QMGR_QUEST_AVAILABLE) || (status == QMGR_QUEST_REPEATABLE))
        {
	        SendPacket(&sQuestMgr.BuildQuestDetails((*itr)->qst,qst_giver));
            Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_QUESTGIVER_QUEST_DETAILS." );
        }
        else if (status == QMGR_QUEST_FINISHED)
        {
            SendPacket(&sQuestMgr.BuildOfferReward((*itr)->qst, qst_giver));
            Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_QUESTGIVER_OFFER_REWARD." );
        }
        else if (status == QMGR_QUEST_NOT_FINISHED)
        {
            SendPacket(&sQuestMgr.BuildRequestItems((*itr)->qst, qst_giver));
            Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_QUESTGIVER_REQUEST_ITEMS." );
        }
    }
    else 
    {
	    SendPacket(&sQuestMgr.BuildQuestList(qst_giver ,GetPlayer()));
	    Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_QUESTGIVER_QUEST_LIST." );
    }
}

void WorldSession::HandleQuestGiverQueryQuestOpcode( WorldPacket & recv_data )
{
	Log::getSingleton( ).outDebug( "WORLD: Recieved CMSG_QUESTGIVER_QUERY_QUEST." );

	WorldPacket data;
	uint64 guid;
	uint32 quest_id;
    uint32 status;

	recv_data >> guid;
	recv_data >> quest_id;

	Creature *qst_giver = objmgr.GetObject<Creature>(guid);
    Quest* qst = sQuestMgr.FindQuest(quest_id);

    if (!qst)
	{
		Log::getSingleton( ).outDebug("WORLD: Invalid quest ID.");
		return;
	}

	if (!qst_giver)
	{
		Log::getSingleton( ).outDebug("WORLD: Invalid questgiver GUID.");
		return;
	}

    if (!qst_giver->isQuestGiver())
    {
		Log::getSingleton( ).outDebug("WORLD: Creature is not a questgiver.");
		return;
    }

    if (!qst_giver->FindQuest(quest_id, QUESTGIVER_QUEST_START | QUESTGIVER_QUEST_END))
    {
		Log::getSingleton( ).outDebug("WORLD: QuestGiver doesn't have that quest.");
		return;
    }

    status = sQuestMgr.CalcQuestStatus(qst_giver, GetPlayer(), qst,
                qst_giver->GetQuestRelation(qst->GetID()));
                
    if ((status == QMGR_QUEST_AVAILABLE) || (status == QMGR_QUEST_REPEATABLE))
    {
	    SendPacket(&sQuestMgr.BuildQuestDetails(qst,qst_giver));
        Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_QUESTGIVER_QUEST_DETAILS." );
    }
    else if (status == QMGR_QUEST_FINISHED)
    {
        SendPacket(&sQuestMgr.BuildOfferReward(qst, qst_giver));
        Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_QUESTGIVER_OFFER_REWARD." );
    }
    else if (status == QMGR_QUEST_NOT_FINISHED)
    {
        SendPacket(&sQuestMgr.BuildRequestItems(qst, qst_giver));
        Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_QUESTGIVER_REQUEST_ITEMS." );
    }
}

void WorldSession::HandleQuestgiverAcceptQuestOpcode( WorldPacket & recv_data )
{
	Log::getSingleton( ).outDebug( "WORLD: Recieved CMSG_QUESTGIVER_ACCEPT_QUEST" );

	WorldPacket data;

	uint64 guid;
	uint32 quest_id;

	recv_data >> guid;
	recv_data >> quest_id;

	Creature *qst_giver = objmgr.GetObject<Creature>(guid);

	if (!qst_giver)
	{
		Log::getSingleton( ).outDebug("WORLD: Invalid questgiver GUID.");
		return;
	}

    if (!qst_giver->isQuestGiver())
    {
		Log::getSingleton( ).outDebug("WORLD: Creature is not a questgiver.");
		return;
    }
    
    Quest *qst = qst_giver->FindQuest(quest_id, QUESTGIVER_QUEST_START);

	if (!qst)
	{
		Log::getSingleton( ).outDebug("WORLD: Invalid Quest.");
		return;
	}

	if(GetPlayer()->Find_QLE(quest_id))
		return;
    
	uint16 log_slot = GetPlayer()->GetOpenQuestSlot();
    
	if (log_slot == 0)
        return;

    GetPlayer()->SetUInt32Value(log_slot, qst->GetID());

	QuestLogEntry *qle = new QuestLogEntry();
    qle->Init(qst, qst_giver->GetGUID());

	GetPlayer()->Add_QLE(qle);

	Log::getSingleton( ).outDebug("WORLD: Added new QLE.");
}

void WorldSession::HandleQuestgiverCancelOpcode(WorldPacket& recvPacket)
{
}

void WorldSession::HandleQuestlogRemoveQuestOpcode(WorldPacket& recvPacket)
{
    Log::getSingleton( ).outDebug( "WORLD: Recieved CMSG_QUESTLOG_REMOVE_QUEST" );

    uint8 quest_slot;
    recvPacket >> quest_slot;
    
    if (!GetPlayer()->GetQuestEntryInSlot(quest_slot))
    {
		Log::getSingleton( ).outDebug("WORLD: No quest in slot %d.", quest_slot);
		return;        
    }

    GetPlayer()->Del_QLE(GetPlayer()->GetQuestEntryInSlot(quest_slot));

    GetPlayer()->SetUInt32Value(PLAYER_QUEST_LOG_1_1 + quest_slot*3, 0);
    GetPlayer()->SetUInt32Value(PLAYER_QUEST_LOG_1_1 + quest_slot*3 + 1, 0);
    GetPlayer()->SetUInt32Value(PLAYER_QUEST_LOG_1_1 + quest_slot*3 + 2, 0);
}

void WorldSession::HandleQuestQueryOpcode( WorldPacket & recv_data )
{
	Log::getSingleton( ).outDebug( "WORLD: Recieved CMSG_QUEST_QUERY" );

	uint32 quest_id;

	recv_data >> quest_id;

    Quest *qst = sQuestMgr.FindQuest(quest_id);

	if (!qst)
	{
		Log::getSingleton( ).outDebug("WORLD: Invalid quest ID.");
		return;
	}

	SendPacket(&qst->BuildQueryResponse());

	Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_QUEST_QUERY_RESPONSE." );
}

void WorldSession::HandleQuestgiverRequestRewardOpcode( WorldPacket & recv_data )
{
}

void WorldSession::HandleQuestgiverCompleteQuestOpcode( WorldPacket & recvPacket )
{
	Log::getSingleton( ).outDebug( "WORLD: Recieved CMSG_QUESTGIVER_COMPLETE_QUEST." );

	WorldPacket data;
	uint64 guid;
	uint32 quest_id;

	recvPacket >> guid;
	recvPacket >> quest_id;

	Creature *qst_giver = objmgr.GetObject<Creature>(guid);
    Quest* qst = sQuestMgr.FindQuest(quest_id);

    if (!qst)
	{
		Log::getSingleton( ).outDebug("WORLD: Invalid quest ID.");
		return;
	}

	if (!qst_giver)
	{
		Log::getSingleton( ).outDebug("WORLD: Invalid questgivr GUID.");
		return;
	}

    if (!qst_giver->isQuestGiver())
    {
		Log::getSingleton( ).outDebug("WORLD: Creature is not a questgiver.");
		return;
    }

    if (!qst_giver->FindQuest(quest_id, QUESTGIVER_QUEST_END))
    {
		Log::getSingleton( ).outDebug("WORLD: QuestGiver doesn't have that quest.");
		return;
    }
}

void WorldSession::HandleQuestgiverChooseRewardOpcode(WorldPacket& recvPacket)
{
	Log::getSingleton( ).outDebug( "WORLD: Recieved CMSG_QUESTGIVER_CHOOSE_REWARD." );

	WorldPacket data;
	uint64 guid;
	uint32 quest_id;
    uint32 reward_slot;

	recvPacket >> guid;
	recvPacket >> quest_id;
    recvPacket >> reward_slot;

    Creature *qst_giver = objmgr.GetObject<Creature>(guid);
    Quest* qst = sQuestMgr.FindQuest(quest_id);

    if (!qst)
	{
		Log::getSingleton( ).outDebug("WORLD: Invalid quest ID.");
		return;
	}

	if (!qst_giver)
	{
		Log::getSingleton( ).outDebug("WORLD: Invalid questgiver ID.");
		return;
	}

    if (!qst_giver->isQuestGiver())
    {
		Log::getSingleton( ).outDebug("WORLD: Creature is not a questgiver.");
		return;
    }

    if (!qst_giver->FindQuest(quest_id, QUESTGIVER_QUEST_END))
    {
		Log::getSingleton( ).outDebug("WORLD: QuestGiver doesn't have that quest.");
		return;
    }

    QuestLogEntry *qle = GetPlayer()->Find_QLE(quest_id);

    if (!qle)
    {
		Log::getSingleton( ).outDebug("WORLD: QuestLogEntry not found.");
		return;
    }

    if (!qle->CanBeFinished())
    {
		Log::getSingleton( ).outDebug("WORLD: Quest not finished.");
		return;
    }

    //check for room in inventory for all items
    sQuestMgr.OnQuestFinished(GetPlayer(), qst);
}
