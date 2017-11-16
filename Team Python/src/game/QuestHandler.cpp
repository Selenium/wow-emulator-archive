// Copyright (C) 2004 Team Python
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


#define world WorldServer::getSingleton()

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


void QuestHandler::HandleMsg( wowWData & recv_data, GameClient *pClient )
{
    wowWData data;
    Log::getSingleton( ).outString("WORLD: Quest Opcode 0x%.4X", recv_data.opcode);
    switch (recv_data.opcode)
    {
        case CMSG_QUESTGIVER_STATUS_QUERY:
            {
                Log::getSingleton( ).outString( "WORLD: Recieved CMSG_QUESTGIVER_STATUS_QUERY" );
                uint32 guid1, guid2;
                recv_data >> guid1 >> guid2;
                
                WPAssert( guid1 != 0 );
                //uint32 quest_status = world.mCreatures[guid1]->getQuestStatus(pClient->getCurrentChar());
				uint32 quest_status;
				Unit *tmpUnit;
				tmpUnit = world.GetValidCreature(guid1);
				if (!tmpUnit)
					return;
				quest_status = tmpUnit->getQuestStatus(pClient->getCurrentChar());
                data.Initialise( 12, SMSG_QUESTGIVER_STATUS );
                data << guid1 << guid2 << quest_status;
                pClient->SendMsg( &data );
                Log::getSingleton( ).outString( "WORLD: Sent SMSG_QUESTGIVER_STATUS" );
            }break;
        case CMSG_QUESTGIVER_HELLO:
            {
                Log::getSingleton( ).outString( "WORLD: Recieved CMSG_QUESTGIVER_HELLO" );
                uint32 guid1, guid2;
                recv_data >> guid1 >> guid2;

                WPAssert( guid1 != 0 );
                uint32 qg_status = world.mCreatures[guid1]->getQuestStatus(pClient->getCurrentChar());
                uint32 quest_id = world.mCreatures[guid1]->getCurrentQuest(pClient->getCurrentChar());
                
                if (qg_status == 0) break;
                Quest *pQuest = world.getQuest(quest_id);

                if(qg_status == QUEST_STATUS_INCOMPLETE)
                {
                    if (pClient->getCurrentChar()->checkQuestStatus(quest_id) || pQuest->m_targetGuid == guid1)
                    {
                        char *title = world.mCreatures[guid1]->getQuestTitle(quest_id);
                        char *details = world.mCreatures[guid1]->getQuestCompleteText(quest_id);
                        
                        uint16 length = 8+4+strlen(title)+1 + strlen(details)+1 + 32;
                        length += pQuest->m_choiceRewards*12;
                        length += pQuest->m_itemRewards*12;
                        data.Initialise( length, SMSG_QUESTGIVER_OFFER_REWARD );
                        data << guid1 << guid2 << quest_id;
                        data.writeData( title, strlen(title)+1 );
                        data.writeData( details, strlen(details)+1 );
                    
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
                        Log::getSingleton( ).outString( "WORLD: Sent SMSG_QUESTGIVER_OFFER_REWARD" );
                    } else {
                        // Incomplete Quest
                        char *title = world.mCreatures[guid1]->getQuestTitle(quest_id);
                        char *incompleteText = world.mCreatures[guid1]->getQuestIncompleteText(quest_id);

                        uint16 length = 8 + 4 + strlen(title)+1 + strlen(incompleteText)+1 + 28;

                        data.Initialise( length, SMSG_QUESTGIVER_REQUEST_ITEMS);
                        data << guid1 << guid2 << quest_id;
                        data.writeData( title, strlen(title)+1 );
                        data.writeData( incompleteText, strlen(incompleteText)+1 );

                        data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
                        data << uint8(0x06) << uint8(0x00) << uint8(0x00) << uint8(0x00);
                        data << uint8(0x01) << uint8(0x00) << uint8(0x00) << uint8(0x00);
                        data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
                        data << uint8(0x01) << uint8(0x00) << uint8(0x00) << uint8(0x00); // setting this to anything...
                        data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00); // with this set to anything, enables "continue" to comlete quest
                        data << uint8(0x01) << uint8(0x00) << uint8(0x00) << uint8(0x00);

                        pClient->SendMsg( &data );
 //                       pClient->getCurrentChar()->setQuestStatus(quest_id, QUEST_STATUS_CHOOSE_REWARD);
                        Log::getSingleton( ).outString( "WORLD: Sent SMSG_QUESTGIVER_REQUEST_ITEMS" );
                    }               
                }
                else if(qg_status == QUEST_STATUS_AVAILABLE)
                {
                    // Send quest details
                    char *title = world.mCreatures[guid1]->getQuestTitle(quest_id);
                    char *details = world.mCreatures[guid1]->getQuestDetails(quest_id);
                    char *objectives = world.mCreatures[guid1]->getQuestObjectives(quest_id);
                    Quest *pQuest = world.getQuest(quest_id);


                    uint16 rewardSize = 52;
                    rewardSize += pQuest->m_choiceRewards*12;
                    rewardSize += pQuest->m_itemRewards*12;

                    data.Initialise( 8 + 4 + strlen(title)+1 + strlen(details)+1 + strlen(objectives)+1 + rewardSize, SMSG_QUESTGIVER_QUEST_DETAILS );
                    data << guid1 << guid2 << quest_id;
                    data.writeData( title, strlen(title)+1 );
                    data.writeData( details, strlen(details)+1 );
                    data.writeData( objectives, strlen(objectives)+1 );

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
                    Log::getSingleton( ).outString( "WORLD: Sent SMSG_QUESTGIVER_QUEST_DETAILS" );
                }

            }break;
        case CMSG_QUESTGIVER_ACCEPT_QUEST:
            {
                Log::getSingleton( ).outString( "WORLD: Recieved CMSG_QUESTGIVER_ACCEPT_QUEST" );
                uint32 guid1, guid2, quest_id;
                recv_data >> guid1 >> guid2 >> quest_id;
                WPAssert( guid1 != 0 );
                Quest *pQuest = world.getQuest(quest_id);
				ChatHandler pChat;

				if (quest_id == 199) //taxi to undercity
					pChat.smsg_NewWorld(pClient, 0, 2062.8f, 282.867f, 98.4408f);
				else if (quest_id == 200) //taxi to orgrimmar
					pChat.smsg_NewWorld(pClient, 1, 1323.53f, -4647.89f, 54.1709f);
//balko start --New Ports (as Ship and Lift replacement)
				else if (quest_id == 205)					// to Rut'theran from Auberdeen
					pChat.smsg_NewWorld(pClient, 1, 8553.71f, 1021.20f, 5.52f);
				else if (quest_id == 206)					//to Auberdeen from Menethil 
					pChat.smsg_NewWorld(pClient, 1, 6425.37f, 817.10f, 5.47f);
				else if (quest_id == 207)					//to Ratchet (from Booty  Bay
					pChat.smsg_NewWorld(pClient, 1, -997.00f, -3821.11f, 5.34f);
				else if (quest_id == 208)					//to Ratchet (from Menethil)
					pChat.smsg_NewWorld(pClient, 1, -997.00f, -3821.11f, 5.34f);
				else if (quest_id == 209)					//to Menethil (from Theramore)
					pChat.smsg_NewWorld(pClient, 0, -3892.08f, -601.45f, 5.47f);
				else if (quest_id == 210)					//to Menethil (from Ratchet)
					pChat.smsg_NewWorld(pClient, 0, -3892.08f, -601.45f, 5.47f);
				else if (quest_id == 211)					//to Menethil (from Auberdeen)
					pChat.smsg_NewWorld(pClient, 0, -3727.27f, -584.09f, 6.25f);
				else if (quest_id == 212)					//to Booty Bay (from Ratchet)
					pChat.smsg_NewWorld(pClient, 0, -14288.00f, 551.74f, 8.90f);
				else if (quest_id == 213)					//to Theramore (from Menethil)
					pChat.smsg_NewWorld(pClient, 1, -4001.16f, -4727.15f, 4.97f);
				else if (quest_id == 214)					//to Darnassus (from Rut'theran)
					pChat.smsg_NewWorld(pClient, 1, 9942.95f, 2606.23f, 1316.32f);
				else if (quest_id == 215)					//to Rut'theran (from Darnassus)
					pChat.smsg_NewWorld(pClient, 1, 8784.80f, 966.17f, 30.20f);
				else if (quest_id == 216)					//to Thunderbluff (from Plains)
					pChat.smsg_NewWorld(pClient, 1, -1288.03f, 141.82f, 130.05f);
				else if (quest_id == 217)					//to Plains (from Thunderbluff)
					pChat.smsg_NewWorld(pClient, 1, -1317.59f, 181.33f, 68.55f);
				else if (quest_id == 218)					//down the Great Lift (from up)
					pChat.smsg_NewWorld(pClient, 1, -4618.09f, -1852.60f, 86.06f);
				else if (quest_id == 219)					//up the Great Lift (from up)
					pChat.smsg_NewWorld(pClient, 1, -4678.36f, -1854.63f, -44.17f);
				else if (quest_id == 220)					//to Auberdeen (from Rut'theran)
					pChat.smsg_NewWorld(pClient, 1, 6578.02f, 768.93f, 5.67f);
				else if (quest_id == 221)					//up the Freewind Lift (from down)
					pChat.smsg_NewWorld(pClient, 1, -5406.10f, -2421.63f, 89.34f);
				else if (quest_id == 222)					//down the Freewind Lift (from up)
					pChat.smsg_NewWorld(pClient, 1, -5372.00f, -2490.18f, -40.56f);
				else if (quest_id == 223)					//to Silithus (from Un´Goro)
					pChat.smsg_NewWorld(pClient, 1, -6231.59f, -459.36f, -55.88f);
				else if (quest_id == 224)					//to Un´Goro (from Silithus)
					pChat.smsg_NewWorld(pClient, 1, -6219.93f, -528.73f, -97.78f);
				else if (quest_id == 225)					//to Feralas (from Sardor Island)
					pChat.smsg_NewWorld(pClient, 1, -4388.11f, 2427.13f, 8.15f);
				else if (quest_id == 226)					//to Sardor Island (from Feralas)
					pChat.smsg_NewWorld(pClient, 1, -4214.71f, 3243.85f, 11.54f);			
				else if (quest_id == 227)					//to Ironforge Deeprun (from Stormwind)
					pChat.smsg_NewWorld(pClient, 0, -4839.45f, -1319.05f, 501.86f);			
				else if (quest_id == 228)					//to Stormwind Deeprun (from Ironforge)
					pChat.smsg_NewWorld(pClient, 0, -8353.66f, 522.21f, 91.79f);			
				
//balko end
								
				else {
					uint16 log_slot = pClient->getCurrentChar()->getOpenQuestSlot();
					if (log_slot == 0)
					{
						// TODO:  Send log full message
		                break;
	                }
                
					pClient->getCurrentChar()->setUpdateValue(log_slot, quest_id); 
					pClient->getCurrentChar()->setUpdateValue(log_slot+1, uint32(0));   // 4 bytes for mobs 

//                pClient->SendMsg( &data );
					Log::getSingleton( ).outString( "WORLD: Sent Quest Acceptance 0xA9" );

					if (pQuest->m_targetGuid != 0)
					{
						SetNpcFlagsForTalkToQuest(pClient, guid1, pQuest->m_targetGuid);
		            }

	                pClient->getCurrentChar()->setQuestStatus(quest_id, QUEST_STATUS_INCOMPLETE);
				}
            }break;
        case CMSG_QUEST_QUERY:
            {
                Log::getSingleton( ).outString( "WORLD: Recieved CMSG_QUEST_QUERY" );
                uint32 quest_id=0, guid1=0;
                recv_data >> quest_id;

                for( std::map<uint32, Unit*>::iterator i = world.mCreatures.begin( ); i != world.mCreatures.end( ); ++ i ) {
                    if(i->second != NULL) {
						if(i->second->hasQuest(quest_id))
						    guid1 = i->second->getGUID();
					}
                }
                WPAssert( guid1 != 0 );

                char *title = world.mCreatures[guid1]->getQuestTitle(quest_id);
                char *details = world.mCreatures[guid1]->getQuestDetails(quest_id);
                char *objectives = world.mCreatures[guid1]->getQuestObjectives(quest_id);
                Quest *pQuest = world.getQuest(quest_id);

// Questfixes from blizzhackers.com - balko
//				uint16 length = 140 + strlen(title)+1 + strlen(details)+1 + strlen(objectives)+1 + 69;
                uint16 length = 148 + strlen(title)+1 + strlen(details)+1 + strlen(objectives)+1 + 69;
				data.Initialise( 4 + length, SMSG_QUEST_QUERY_RESPONSE );
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
				data << uint32(0); //quest name bugfix 
				data << uint32(0); //quest name bugfix
                data.writeData( title, strlen(title)+1 );
                data.writeData( objectives, strlen(objectives)+1 );
                data.writeData( details, strlen(details)+1 );
                
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
                Log::getSingleton( ).outString( "WORLD: Sent SMSG_QUEST_QUERY_RESPONSE" );

            }break;
        case CMSG_QUESTGIVER_CHOOSE_REWARD:
            {
                Log::getSingleton( ) << "WORLD: Recieved CMSG_QUESTGIVER_CHOOSE_REWARD" <<
					std::endl;
                uint32 guid1,guid2,quest_id,rewardid;
                recv_data >> guid1 >> guid2 >> quest_id >> rewardid;

                Quest *pQuest = world.getQuest(quest_id);

                data.Initialise( 16 + 4, SMSG_QUESTGIVER_QUEST_COMPLETE );
                data << quest_id;
                data.writeData(uint32(0x03));  // unsure
                data.writeData(uint32(pQuest->m_questXp));
                data.writeData(uint32(pQuest->m_rewardGold));
                data << uint32(0x00);
                pClient->SendMsg( &data );

                pClient->getCurrentChar()->setQuestStatus(quest_id, QUEST_STATUS_COMPLETE);

                if (pQuest->m_targetGuid != 0 && pQuest->m_originalGuid != 0){
                    // Do some special actions for "Talk to..." quests
                    UpdateMask npcMask;
                    npcMask.setCount(UNIT_BLOCKS);
                    npcMask.setBit(OBJECT_FIELD_GUID );
                    npcMask.setBit(OBJECT_FIELD_GUID+1 );
                    npcMask.setBit(UNIT_NPC_FLAGS );
                    // added code to buffer flags and set back so other players don't see the change -RG
                    // note that this buffering is *not* thread safe and should be only temporary

                    uint32 orig = pQuest->m_originalGuid;
                    WPAssert( orig != 0 );
                    uint32 valuebuffer = world.mCreatures[ orig ]->getUpdateValue( UNIT_NPC_FLAGS  );
                    world.mCreatures[orig]->setUpdateValue(UNIT_NPC_FLAGS , uint32(2));
                    world.mCreatures[orig]->UpdateObject(&npcMask, &data);
                    pClient->SendMsg(&data);
                    world.mCreatures[orig]->setUpdateValue(UNIT_NPC_FLAGS , valuebuffer);

                    uint32 targGuid = pQuest->m_targetGuid;
                    WPAssert( targGuid != 0 );
                    valuebuffer = world.mCreatures[targGuid]->getUpdateValue(UNIT_NPC_FLAGS );
                    world.mCreatures[targGuid]->setUpdateValue(UNIT_NPC_FLAGS , uint32(2));
                    world.mCreatures[targGuid]->UpdateObject(&npcMask, &data);
                    pClient->SendMsg(&data);
                    world.mCreatures[targGuid]->setUpdateValue(UNIT_NPC_FLAGS , valuebuffer);
                }
              
                Log::getSingleton( ) << "WORLD: Sent SMSG_QUESTGIVER_QUEST_COMPLETE" <<
					std::endl;

                uint16 log_slot = pClient->getCurrentChar()->getQuestSlot(quest_id);

                // Set player object with rewards!
                Character *chr = pClient->getCurrentChar();
                
                uint32 guid = chr->getGUID();

                chr->giveXP(pQuest->m_questXp);
                if (pQuest->m_rewardGold > 0){
                    uint32 newCoinage = chr->getUpdateValue(PLAYER_FIELD_COINAGE ) + pQuest->m_rewardGold;
                    chr->setUpdateValue(PLAYER_FIELD_COINAGE , newCoinage);
                }

				// Sikon Questfixes
				// Give item rewards, if any 
				uint8 slot, i, j, actualGiven = 0; 
				uint16 numRewards = pQuest->m_itemRewards; 
				uint32 rewards[6]; 

				// first we need to copy the rewards array 
				// in case there's a choice reward 
				for(i = 0; i < numRewards; i++) 
				{ 
					rewards[i] = pQuest->m_rewardItemId[i]; 
				} 
				if(pQuest->m_choiceItemId[rewardid]) 
				{ 
					// add choice reward 
					rewards[numRewards] = pQuest->m_choiceItemId[rewardid]; 
					numRewards++; 
				} 

				for(i = 0; i < numRewards; i++) 
				{ 
					slot = 0; 
					// look for a backpack slot to store the item 
					for(j = 23; j <= 38; j++) 
					{ 
						if(!chr->getGuidBySlot(j)) { 
							slot = j; 
							break; 
						} 
					} 
					if(!slot) 
					{ 
						world.mChatHandler.FillMessageData(&data, 0x09, pClient, 
							reinterpret_cast<uint8 *>("Backpack full, cannot add reward\n")); 
						pClient->SendMsg(&data); 
						break; 
					} 
		                
					actualGiven++; 
					world.m_hiItemGuid++; 
					Log::getSingleton( ) << "Created Item. Guid: " << world.m_hiItemGuid <<
						std::endl;

					// actually create the item 
					chr->AddItemToSlot(slot, world.m_hiItemGuid, rewards[i]); 
		                
					// send a client update 
					UpdateMask invUpdateMask; 
					invUpdateMask.clear(); 
					invUpdateMask.setCount(0x02); 
		       
					world.mItemHandler.createItemUpdate(&data, pClient, slot); 
					pClient->SendMsg(&data); 

					UpdateMask updateMask; 
					updateMask.setCount(0x1b); 
					chr->setUpdateValue(PLAYER_FIELD_INV_SLOT_HEAD + (slot*2), chr->getGuidBySlot(slot), updateMask.updateMask); 
					chr->setUpdateValue(PLAYER_FIELD_INV_SLOT_HEAD + (slot*2)+1, chr->getGuidBySlot(slot) ? 0x00000040 : 0, updateMask.updateMask); 
					chr->UpdateObject(&updateMask, &data); 
					pClient->SendMsg(&data); 
				} 

				if(actualGiven) 
				{ 
					std::stringstream ss; 
					ss << "You have received " << actualGiven << " items as a reward.\n"; 
					// unfortunately... either C-style cast or reinterpret_cast + const_cast
					world.mChatHandler.FillMessageData(&data, 0x09, pClient, 
						(uint8 *)ss.str().c_str());
					pClient->SendMsg(&data); 
				} 

				chr->setUpdateValue(log_slot, 0);
                chr->setUpdateValue(log_slot + 1, 0);
		  }break;

        case CMSG_QUESTGIVER_REQUEST_REWARD :
            {
                /*  Not really sure what this is all about.  SEnt from a SMSG_QUESTGIVER_REQUEST_ITEMS

                uint32 guid1, guid2, quest_id;
                recv_data >> guid1 >> guid2 >> quest_id;

                char *title = world.mCreatures[guid1]->getQuestTitle(quest_id);
                char *details = world.mCreatures[guid1]->getQuestCompleteText(quest_id);

                
                unsigned char tdata[] = 
                { 
                    0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 
                    0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                    0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00 
                };

                data.Initialise( 8+4+strlen(title)+1 + strlen(details)+1 +sizeof(tdata), SMSG_QUESTGIVER_OFFER_REWARD );
                data << guid1 << guid2 << uint32( 0x1 );
                data.writeData( title, strlen(title)+1 );
                data.writeData( details, strlen(details)+1 );
                data.writeData( tdata, sizeof(tdata) );
                pClient->SendMsg( &data );
                Log::getSingleton( ).outString( "WORLD: Sent SMSG_QUESTGIVER_OFFER_REWARD" );
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
    assert( mQuests.find( quest_id ) != mQuests.end( ) );
    return mQuests[quest_id];
}


void QuestHandler::SetNpcFlagsForTalkToQuest(GameClient* pClient, uint32 guid1, uint32 targetGuid)
{
    // Do some special actions for "Talk to..." quests
    wowWData data;
    UpdateMask npcMask;

    npcMask.setCount(UNIT_BLOCKS);
    npcMask.setBit(UNIT_NPC_FLAGS );

    Unit* pGiver = world.GetValidCreature(guid1);
    uint32 valuebuffer = pGiver->getUpdateValue( UNIT_NPC_FLAGS  );
    pGiver->setUpdateValue(UNIT_NPC_FLAGS , uint32(0));
    pGiver->UpdateObject(&npcMask, &data);
    pClient->SendMsg(&data);
    pGiver->setUpdateValue(UNIT_NPC_FLAGS , valuebuffer);

    Unit* pTarget = world.GetValidCreature(targetGuid);

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
