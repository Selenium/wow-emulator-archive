//////////////////////////////////////////////////////////////////////
//  Quest Handler
//
//  Handles quest related opcodes
//////////////////////////////////////////////////////////////////////

// Copyright (C) 2004 Team Python
// Copyright (C) 2004, 2005 Team WSD
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

#include "QuestHandler.h"
#include "GameClient.h"
#include "Opcodes.h"
#include "Log.h"
#include "WorldServer.h"
#include "Character.h"
#include "Quest.h"
#include "UpdateMask.h"


QuestHandler::QuestHandler()
{

}

QuestHandler::~QuestHandler()
{
	for( QuestMap::iterator i = mQuests.begin( ); i != mQuests.end( ); ++ i ) {
		delete i->second;
	}
	mQuests.clear( );

}


void QuestHandler::HandleMsg( NetworkPacket & recv_data, GameClient *pClient )
{
	NetworkPacket data;
	char f[256];
	sprintf(f, "WORLD: Quest Opcode 0x%.4X", recv_data.opcode);
	LOG.outString( f );
	switch (recv_data.opcode)
	{
	case CMSG_QUESTGIVER_STATUS_QUERY:
		{
			LOG.outString( "WORLD: Recieved CMSG_QUESTGIVER_STATUS_QUERY" );
			uint32 guid1, guid2;
			recv_data >> guid1 >> guid2;

			WPAssert( guid1 != 0 );
			//uint32 quest_status = WORLDSERVER.mCreatures[guid1]->getQuestStatus(pClient->getCurrentChar());
			uint32 quest_status;
			Unit *tmpUnit;
			tmpUnit = WORLDSERVER.GetValidCreature(guid1);
			if (!tmpUnit)
				return;
			quest_status = tmpUnit->getQuestStatus(pClient->getCurrentChar());
			data.Initialize( 12, SMSG_QUESTGIVER_STATUS );
			data << guid1 << guid2 << quest_status;
			pClient->SendMsg( &data );
			LOG.outString( "WORLD: Sent SMSG_QUESTGIVER_STATUS" );
		}break;
	case CMSG_QUESTGIVER_HELLO:
		{
			LOG.outString( "WORLD: Recieved CMSG_QUESTGIVER_HELLO" );
			uint32 guid1, guid2;
			recv_data >> guid1 >> guid2;

			WPAssert( guid1 != 0 );
			uint32 qg_status = WORLDSERVER.mCreatures[guid1]->getQuestStatus(pClient->getCurrentChar());
			uint32 quest_id = WORLDSERVER.mCreatures[guid1]->getCurrentQuest(pClient->getCurrentChar());

			if (qg_status == 0) break;
			Quest *pQuest = WORLDSERVER.getQuest(quest_id);

			if(qg_status == QUEST_STATUS_INCOMPLETE)
			{
				if (pClient->getCurrentChar()->checkQuestStatus(quest_id) || pQuest->m_targetGuid == guid1)
				{
					char *title = WORLDSERVER.mCreatures[guid1]->getQuestTitle(quest_id);
					char *details = WORLDSERVER.mCreatures[guid1]->getQuestCompleteText(quest_id);

					uint16 length = 8+4+strlen(title)+1 + strlen(details)+1 + 32;
					length += pQuest->m_choiceRewards*12;
					length += pQuest->m_itemRewards*12;
					data.Initialize( length, SMSG_QUESTGIVER_OFFER_REWARD );
					data << guid1 << guid2 << quest_id;
					data.WriteData( title, strlen(title)+1 );
					data.WriteData( details, strlen(details)+1 );

					data << uint8(0x01) << uint8(0x00) << uint8(0x00) << uint8(0x00);
					data << uint8(0x01) << uint8(0x00) << uint8(0x00) << uint8(0x00);
					data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
					data << uint8(0x01) << uint8(0x00) << uint8(0x00) << uint8(0x00);

					data << uint32(pQuest->m_choiceRewards);
					for (uint16 i=0; i < pQuest->m_choiceRewards; i++){
						data << uint32(pQuest->m_choiceItemId[i]) << uint32(pQuest->m_choiceItemCount[i]);
						data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
					}

					data << uint32(pQuest->m_itemRewards);
					for (uint16 i=0; i < pQuest->m_itemRewards; i++){
						data << uint32(pQuest->m_rewardItemId[i]) << uint32(pQuest->m_rewardItemCount[i]);
						data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
					}

					data << uint32(pQuest->m_rewardGold);
					data << uint8(0x01) << uint8(0x00) << uint8(0x00) << uint8(0x00);

					pClient->SendMsg( &data );
					LOG.outString( "WORLD: Sent SMSG_QUESTGIVER_OFFER_REWARD" );
				} else {
					// Incomplete Quest
					char *title = WORLDSERVER.mCreatures[guid1]->getQuestTitle(quest_id);
					char *incompleteText = WORLDSERVER.mCreatures[guid1]->getQuestIncompleteText(quest_id);

					uint16 length = 8 + 4 + strlen(title)+1 + strlen(incompleteText)+1 + 28;

					data.Initialize( length, SMSG_QUESTGIVER_REQUEST_ITEMS);
					data << guid1 << guid2 << quest_id;
					data.WriteData( title, strlen(title)+1 );
					data.WriteData( incompleteText, strlen(incompleteText)+1 );

					data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
					data << uint8(0x06) << uint8(0x00) << uint8(0x00) << uint8(0x00);
					data << uint8(0x01) << uint8(0x00) << uint8(0x00) << uint8(0x00);
					data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
					data << uint8(0x01) << uint8(0x00) << uint8(0x00) << uint8(0x00); // setting this to anything...
					data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00); // with this set to anything, enables "continue" to comlete quest
					data << uint8(0x01) << uint8(0x00) << uint8(0x00) << uint8(0x00);

					pClient->SendMsg( &data );
					//                       pClient->getCurrentChar()->setQuestStatus(quest_id, QUEST_STATUS_CHOOSE_REWARD);
					LOG.outString( "WORLD: Sent SMSG_QUESTGIVER_REQUEST_ITEMS" );
				}
			}
			else if(qg_status == QUEST_STATUS_AVAILABLE)
			{
				// Send quest details
				char *title = WORLDSERVER.mCreatures[guid1]->getQuestTitle(quest_id);
				char *details = WORLDSERVER.mCreatures[guid1]->getQuestDetails(quest_id);
				char *objectives = WORLDSERVER.mCreatures[guid1]->getQuestObjectives(quest_id);
				Quest *pQuest = WORLDSERVER.getQuest(quest_id);


				uint16 rewardSize = 52;
				rewardSize += pQuest->m_choiceRewards*12;
				rewardSize += pQuest->m_itemRewards*12;

				data.Initialize( 8 + 4 + strlen(title)+1 + strlen(details)+1 + strlen(objectives)+1 + rewardSize, SMSG_QUESTGIVER_QUEST_DETAILS );
				data << guid1 << guid2 << quest_id;
				data.WriteData( title, strlen(title)+1 );
				data.WriteData( details, strlen(details)+1 );
				data.WriteData( objectives, strlen(objectives)+1 );

				data << uint32(1);
				data << uint32(pQuest->m_choiceRewards);

				for (int i=0; i < pQuest->m_choiceRewards; i++){
					data << pQuest->m_choiceItemId[i] << pQuest->m_choiceItemCount[i];
					data << uint32(0);
				}

				data << uint32(pQuest->m_itemRewards);
				for (int i=0; i < pQuest->m_itemRewards; i++){
					data << uint32(pQuest->m_rewardItemId[i]) << uint32(pQuest->m_rewardItemCount[i]);
					data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
				}

				data << uint32(pQuest->m_rewardGold);
				data << uint32(0) << uint32(0);
				data << uint32(0) << uint32(0);
				data << uint32(0) << uint32(0);
				data << uint32(0) << uint32(0) << uint32(0);

				pClient->SendMsg( &data );
				LOG.outString( "WORLD: Sent SMSG_QUESTGIVER_QUEST_DETAILS" );
			}

		}break;
	case CMSG_QUESTGIVER_ACCEPT_QUEST:
		{
			LOG.outString( "WORLD: Recieved CMSG_QUESTGIVER_ACCEPT_QUEST" );
			uint32 guid1, guid2, quest_id;
			recv_data >> guid1 >> guid2 >> quest_id;
			WPAssert( guid1 != 0 );
			Quest *pQuest = WORLDSERVER.getQuest(quest_id);

			uint16 log_slot = pClient->getCurrentChar()->getOpenQuestSlot();
			if (log_slot == 0)
			{
				// TODO:  Send log full message
				break;
			}

			pClient->getCurrentChar()->setUpdateValue(log_slot, quest_id);
			pClient->getCurrentChar()->setUpdateValue(log_slot+1, uint32(0x337));

			//                pClient->SendMsg( &data );
			LOG.outString( "WORLD: Sent Quest Acceptance 0xA9" );

			if (pQuest->m_targetGuid != 0)
			{
				SetNpcFlagsForTalkToQuest(pClient, guid1, pQuest->m_targetGuid);
			}

			pClient->getCurrentChar()->setQuestStatus(quest_id, QUEST_STATUS_INCOMPLETE);
		}break;
	case CMSG_QUEST_QUERY:
		{
			LOG.outString( "WORLD: Recieved CMSG_QUEST_QUERY" );
			uint32 quest_id=0, guid1=0;
			recv_data >> quest_id;

			for( std::map<uint32, Unit*>::iterator i = WORLDSERVER.mCreatures.begin( ); i != WORLDSERVER.mCreatures.end( ); ++ i ) {
				if(i->second != NULL) {
					if(i->second->hasQuest(quest_id))
						guid1 = i->second->getGUID().sno;
				}
			}

			char *title = WORLDSERVER.mCreatures[guid1]->getQuestTitle(quest_id);
			char *details = WORLDSERVER.mCreatures[guid1]->getQuestDetails(quest_id);
			char *objectives = WORLDSERVER.mCreatures[guid1]->getQuestObjectives(quest_id);
			Quest *pQuest = getQuest(quest_id);


			// Begin MarkusWin32 fix [source: http://www.blizzhackers.com/viewtopic.php?t=235576]
			uint16 length = 148 + strlen(title)+1 + strlen(details)+1 + strlen(objectives)+1 + 69;
			// End MarkusWin32 fix

			data.Initialize( 4 + length, SMSG_QUEST_QUERY_RESPONSE );
			data << quest_id;

			// tdata
			data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
			data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
			data << uint32(pQuest->m_zone);

			data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
			data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00); // reputation faction?
			data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);

			data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
			data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
			data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
			data << uint32(pQuest->m_rewardGold);
			data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
			data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);

			data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
			data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);

			data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
			data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
			data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
			data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);

			data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);

			for (int i=0; i < 5; i++){
				data << uint32(pQuest->m_choiceItemId[i]) << uint32(pQuest->m_choiceItemCount[i]);
			}

			data << uint32(0);
			data << uint32(0x01);
			data << uint32(0xFF);
			data << uint32(0);
			data << uint32(0);

			data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);

			data.WriteData( title, strlen(title)+1 );
			data.WriteData( objectives, strlen(objectives)+1 );
			data.WriteData( details, strlen(details)+1 );

			// quest requirements
			data << uint8(0);
			data << uint32(pQuest->m_questMobId[0])  << uint32(pQuest->m_questMobCount[0]);
			data << uint32(pQuest->m_questItemId[0]) << uint32(pQuest->m_questItemCount[0]);
			data << uint32(pQuest->m_questMobId[1])  << uint32(pQuest->m_questMobCount[1]);
			data << uint32(pQuest->m_questItemId[1]) << uint32(pQuest->m_questItemCount[1]);
			data << uint32(pQuest->m_questMobId[2])  << uint32(pQuest->m_questMobCount[2]);
			data << uint32(pQuest->m_questItemId[2]) << uint32(pQuest->m_questItemCount[2]);
			data << uint32(pQuest->m_questMobId[3])  << uint32(pQuest->m_questMobCount[3]);
			data << uint32(pQuest->m_questItemId[3]) << uint32(pQuest->m_questItemCount[3]);
			data << uint32(0);

			pClient->SendMsg( &data );
			LOG.outString( "WORLD: Sent SMSG_QUEST_QUERY_RESPONSE" );

		}break;
	case CMSG_QUESTGIVER_CHOOSE_REWARD:
		{
			LOG.outString( "WORLD: Recieved CMSG_QUESTGIVER_CHOOSE_REWARD" );
			uint32 guid1,guid2,quest_id,rewardid;
			recv_data >> guid1 >> guid2 >> quest_id >> rewardid;

			Quest *pQuest = WORLDSERVER.getQuest(quest_id);

			data.Initialize( 16 + 4, SMSG_QUESTGIVER_QUEST_COMPLETE );
			data << quest_id;
			data.WriteData(uint32(0x03));  // unsure
			data.WriteData(uint32(pQuest->m_questXp));
			data.WriteData(uint32(pQuest->m_rewardGold));
			data << uint32(0x00);
			pClient->SendMsg( &data );

			pClient->getCurrentChar()->setQuestStatus(quest_id, QUEST_STATUS_COMPLETE);

			if (pQuest->m_targetGuid != 0 && pQuest->m_originalGuid != 0){
				// Do some special actions for "Talk to..." quests
				UpdateMask npcMask;
				npcMask.SetLength (UNIT_FIELDS);
				npcMask.SetBit (OBJECT_FIELD_GUID );
				npcMask.SetBit (OBJECT_FIELD_GUID+1 );
				npcMask.SetBit (UNIT_NPC_FLAGS );
				// added code to buffer flags and set back so other players don't see the change -RG
				// note that this buffering is *not* thread safe and should be only temporary

				uint32 orig = pQuest->m_originalGuid;
				WPAssert( orig != 0 );
				uint32 valuebuffer = WORLDSERVER.mCreatures[ orig ]->getUpdateValue( UNIT_NPC_FLAGS  );
				WORLDSERVER.mCreatures[orig]->setUpdateValue(UNIT_NPC_FLAGS , uint32(2));
				WORLDSERVER.mCreatures[orig]->UpdateObject(&npcMask, &data);
				pClient->SendMsg(&data);
				WORLDSERVER.mCreatures[orig]->setUpdateValue(UNIT_NPC_FLAGS , valuebuffer);

				uint32 targGuid = pQuest->m_targetGuid;
				WPAssert( targGuid != 0 );
				valuebuffer = WORLDSERVER.mCreatures[targGuid]->getUpdateValue(UNIT_NPC_FLAGS );
				WORLDSERVER.mCreatures[targGuid]->setUpdateValue(UNIT_NPC_FLAGS , uint32(2));
				WORLDSERVER.mCreatures[targGuid]->UpdateObject(&npcMask, &data);
				pClient->SendMsg(&data);
				WORLDSERVER.mCreatures[targGuid]->setUpdateValue(UNIT_NPC_FLAGS , valuebuffer);
			}

			LOG.outString( "WORLD: Sent SMSG_QUESTGIVER_QUEST_COMPLETE" );

			uint16 log_slot = pClient->getCurrentChar()->getQuestSlot(quest_id);

			// Set player object with rewards!
			Character *chr = pClient->getCurrentChar();

			chr->GiveXP (pQuest->m_questXp);
			if (pQuest->m_rewardGold > 0)
			{
				uint32 newCoinage = chr->getUpdateValue (PLAYER_FIELD_COINAGE) + pQuest->m_rewardGold;
				chr->setUpdateValue (PLAYER_FIELD_COINAGE, newCoinage);
			}

			// Give item rewards, if any
			uint8 slot, i, j, actualGiven = 0;
			uint16 numRewards = pQuest->m_itemRewards;
			uint32 rewards[6];

			// first we need to copy the rewards array
			// in case there's a choice reward
			for(i = 0; i < numRewards; i++) {
				rewards[i] = pQuest->m_rewardItemId[i];
			}
			if(pQuest->m_choiceItemId[rewardid]) {
				// add choice reward
				rewards[numRewards] = pQuest->m_choiceItemId[rewardid];
				numRewards++;
			}

			for(i = 0; i < numRewards; i++) {
				slot = 0;
				// look for a backpack slot to store the item
				for(j = 23; j <= 38; j++) {
					if (!chr->getGuidBySlot(j)) {
						slot = j;
						break;
					}
				}
				if (!slot) {
					WORLDSERVER.mChatHandler.FillMessageData(&data, 0x09, pClient,
									   (uint8 *)"Backpack full, cannot add reward\n");
					pClient->SendMsg(&data);
					break;
				}

				actualGiven++;
				WORLDSERVER.m_hiItemGuid++;
				LOG.outString("Created Item. Guid: %i",
							       WORLDSERVER.m_hiItemGuid);

				// actually create the item
				chr->AddItemToSlot(slot, WORLDSERVER.m_hiItemGuid, rewards[i]);

				// send a client update
				UpdateMask invUpdateMask;
				invUpdateMask.SetLength (64);

				WORLDSERVER.mItemHandler.createItemUpdate(&data, pClient, slot);
				pClient->SendMsg(&data);

				UpdateMask updateMask;
				updateMask.SetLength (PLAYER_FIELDS);
				chr->setUpdateValue (PLAYER_FIELD_INV_SLOT_HEAD + (slot*2),
						     chr->getGuidBySlot(slot), updateMask.data);
				chr->setUpdateValue (PLAYER_FIELD_INV_SLOT_HEAD + (slot*2)+1,
						     chr->getGuidBySlot(slot) ? 0x00000040 : 0,
						     updateMask.data);
				chr->UpdateObject (&updateMask, &data);
				pClient->SendMsg (&data);
			}

			if(actualGiven) {
				// since it's C++, I use stringstream instead of ugly sprintf
				std::stringstream ss;
				ss << "You have received " << actualGiven << " items as a reward.\n";
				WORLDSERVER.mChatHandler.FillMessageData(&data, 0x09, pClient,
								   (uint8 *)ss.str().c_str());
				pClient->SendMsg(&data);
			}
			// End MarkusWin32 fix

			chr->setUpdateValue(log_slot, 0);
			chr->setUpdateValue(log_slot+1, 0);
			// Begin MarkusWin32 fix [source: http://www.blizzhackers.com/viewtopic.php?t=235576]
			//chr->setUpdateValue(log_slot+2, 0);
			//chr->setUpdateValue(log_slot+3, 0);
			// End MarkusWin32 fix
		}break;

	case CMSG_QUESTGIVER_REQUEST_REWARD :
		{
			/*  Not really sure what this is all about.  SEnt from a SMSG_QUESTGIVER_REQUEST_ITEMS

			uint32 guid1, guid2, quest_id;
			recv_data >> guid1 >> guid2 >> quest_id;

			char *title = WORLDSERVER.mCreatures[guid1]->getQuestTitle(quest_id);
			char *details = WORLDSERVER.mCreatures[guid1]->getQuestCompleteText(quest_id);


			unsigned char tdata[] =
			{
			0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00
			};

			data.Initialize( 8+4+strlen(title)+1 + strlen(details)+1 +sizeof(tdata), SMSG_QUESTGIVER_OFFER_REWARD );
			data << guid1 << guid2 << uint32( 0x1 );
			data.WriteData( title, strlen(title)+1 );
			data.WriteData( details, strlen(details)+1 );
			data.WriteData( tdata, sizeof(tdata) );
			pClient->SendMsg( &data );
			LOG.outString( "WORLD: Sent SMSG_QUESTGIVER_OFFER_REWARD" );
			pClient->getCurrentChar()->setQuestStatus(quest_id, QUEST_STATUS_CHOOSE_REWARD);
			*/
		}break;
	}
}

void QuestHandler::addQuest(Quest *pQuest)
{
	mQuests[pQuest->m_questId] = pQuest;
}

Quest* QuestHandler::getQuest(uint32 quest_id)
{
	//assert( mQuests.find( quest_id ) != mQuests.end( ) );
	if( mQuests.find( quest_id ) != mQuests.end( ) )
		return mQuests[quest_id];
	else
		return mQuests[1];
}

void QuestHandler::SetNpcFlagsForTalkToQuest(GameClient* pClient, uint32 guid1, uint32 targetGuid)
{
	// Do some special actions for "Talk to..." quests
	NetworkPacket data;
	UpdateMask npcMask;

	npcMask.SetLength (UNIT_FIELDS);
	npcMask.SetBit (UNIT_NPC_FLAGS);

	Unit* pGiver = WORLDSERVER.GetValidCreature(guid1);
	uint32 valuebuffer = pGiver->getUpdateValue( UNIT_NPC_FLAGS  );
	pGiver->setUpdateValue(UNIT_NPC_FLAGS , uint32(0));
	pGiver->UpdateObject(&npcMask, &data);
	pClient->SendMsg(&data);
	pGiver->setUpdateValue(UNIT_NPC_FLAGS , valuebuffer);

	Unit* pTarget = WORLDSERVER.GetValidCreature(targetGuid);

	valuebuffer = pTarget->getUpdateValue(UNIT_NPC_FLAGS );
	pTarget->setUpdateValue(UNIT_NPC_FLAGS , uint32(2));
	pTarget->UpdateObject(&npcMask, &data);
	pClient->SendMsg(&data);
	pTarget->setUpdateValue(UNIT_NPC_FLAGS , valuebuffer);
}

/*  Query Response Header
 uint8 tdata[] =
 {
 // Flags of some sort?
 0x02, 0x00, 0x00, 0x00,
 0x04, 0x00, 0x00, 0x00,
 0x09, 0x00, 0x00, 0x00,

 0x00, 0x00, 0x00, 0x00,
 0x00, 0x00, 0x00, 0x00, //<-- Reputation Faction!?  If I set above 0, CRASH!  Probably have to set factions first
 0x00, 0x00, 0x00, 0x00,
 0x00, 0x00, 0x00, 0x00,
 0x00, 0x00, 0x00, 0x00,
 0x00, 0x00, 0x00, 0x00,
 0x05, 0x00, 0x00, 0x00, // Oooh, gold reward?

 0x00, 0x00, 0x00, 0x00,
 0x00, 0x00, 0x00, 0x00,
 0x00, 0x00, 0x00, 0x00,

 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,

 // Item Reward list
 0xb0, 0x08, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, // Item Entry ID and reward count
 0xcc, 0x15, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00,
 0x89, 0x04, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00,
 0xcb, 0x15, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00,
 0x87, 0x04, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00,

 0x00, 0x00, 0x00, 0x00, // setting any of these bytes to 1 makes it ignore the Item rewards Above. Ooook then.

 0x00, 0x00, 0x00, 0x00,
 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
 };
 */
/* another Query Response Header
 // rewards?
 uint8 tdata[] =
 {
 // Flags of some sort?
 0x2B, 0x02, 0x00, 0x00,
 0x3E, 0x03, 0x00, 0x00,
 0x90, 0x00, 0x00, 0x00, // zone id to store quest in log

 0x02, 0x00, 0x00, 0x00,

 0x00, 0x00, 0x00, 0x00, //<-- Reputation Faction!?  If I set above 0, CRASH!  Probably have to set factions first

 0x0B, 0x01, 0x00, 0x00,

 0x00, 0x00, 0x00, 0x00,
 0x00, 0x00, 0x00, 0x00,
 0x00, 0x00, 0x00, 0x00,
 0x00, 0x00, 0x00, 0x00, // Oooh, gold reward
 0x00, 0x00, 0x00, 0x00,
 0x00, 0x00, 0x00, 0x00,

 0xF4, 0x01, 0x00, 0x00,
 0x00, 0x00, 0x00, 0x00,

 0x99, 0x0E, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, // Item rewards you always get, no choosing
 0x91, 0x0E, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00,

 0x00, 0x00, 0x00, 0x00,

 // Item Reward Choice list
 0x82, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, // Item Entry ID and reward count
 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,

 0x00, 0x00, 0x00, 0x00, // setting any of these bytes to 1 makes it ignore the Item rewards Above. Ooook then.

 0x00, 0x00, 0x00, 0x00,
 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
 };
 */



/*
 SMSG_QUESTGIVER_OFFER_REWARD
 4 bytes
 4 bytes
 4 bytes
 4 bytes
 4 bytes - # of items to choose from
 for itemCount
 4 bytes - item entry id
 4 bytes - # in stack
 4 bytes - Item icon (?)

 4 bytes - # of items being rewarded
 for itemCount
 4 bytes - item entry id
 4 bytes - # in stack
 4 bytes - Item icon (?)
 4 bytes - Gold rewarded
 4 bytes
 */

/*
 SMSG_QUESTGIVER_QUEST_DETAILS

 8 bytes - questgiver guid
 4 bytes - quest id
 string - quest title
 string - quest description
 string - quest objectives
 4 bytes - ?
 4 bytes - number of rewards to choose from
 for each item
 4 bytes - item name entry id
 4 bytes - # in stack
 4 bytes - picture id
 4 bytes - number of item rewards always awarded
 for each item
 4 bytes - item name entry id
 4 bytes - # in stack
 4 bytes - picture id
 4 bytes - reward gold
 4 bytes ?
 4 bytes ?
 4 bytes ?
 4 bytes ?
 4 bytes ?
 4 bytes ?
 4 bytes ?
 4 bytes ?

 */

/*
 SMSG_QUEST_QUERY_RESPONSE

 4 bytes - quest id
 4 bytes - ?
 4 bytes - ?
 4 bytes - Quest Zone
 4 bytes - ?
 4 bytes - Faction (?)
 4 bytes - ?
 4 bytes - ?
 4 bytes - ?
 4 bytes - ?
 4 bytes - Gold rewarded
 4 bytes - ?
 4 bytes - ?

 4 bytes - ?
 4 bytes - ?

 4 bytes - ?
 4 bytes - ?
 4 bytes - ?
 4 bytes - ?

 4 bytes - ?

 loop 5 times
 4 bytes - Item name entry id
 4 bytes - items tack count

 4 bytes - ?
 4 bytes - ?
 4 bytes - ?
 4 bytes - ?
 4 bytes - ?
 4 bytes - ?
 string - quest title
 string - objectives
 string - decription
 1 byte - ? some kind of flag ?
 4 bytes - Creature to slay entry ID
 4 bytes - # of those creature to slay
 4 bytes - Item ID to collect
 4 bytes - # of those items to collect
 4 bytes - Creature to slay entry ID
 4 bytes - # of those creature to slay
 4 bytes - Item ID to collect
 4 bytes - # of those items to collect
 4 bytes - Creature to slay entry ID
 4 bytes - # of those creature to slay
 4 bytes - Item ID to collect
 4 bytes - # of those items to collect
 4 bytes - Creature to slay entry ID
 4 bytes - # of those creature to slay
 4 bytes - Item ID to collect
 4 bytes - # of those items to collect
 4 bytes - ?

 */

/*
 SMSG_QUESTUPDATE_ADD_KILL[00000194]

 4 bytes - Quest ID
 4 bytes - Entry ID of Monster Killed
 4 bytes - Number of kills to add?
 4 bytes - Total kills required for quest?
 8 bytes - Killed Monster GUID
 */
