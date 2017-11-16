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

#include "MiscHandler.h"
#include "NetworkInterface.h"
#include "Opcodes.h"
#include "Log.h"
#include "Character.h"
#include "WorldServer.h"
#include "Database.h"
#include "math.h"
#include <string.h>
#include "../wowpython/version.h"
extern int startzone;
extern int cinematics;
extern int playerlimit;

#define world WorldServer::getSingleton()

MiscHandler::MiscHandler( ) 
{

}

MiscHandler::~MiscHandler( ) 
{

}


void MiscHandler::HandleMsg( wowWData & recv_data, GameClient *pClient )
{
    wowWData data;
	char f[256];
    sprintf(f, "WORLD: Misc Opcode 0x%.4X", recv_data.opcode);
	typedef std::map< uint32, Unit*> CreatureMap;		
	CreatureMap mCreatures;
    Log::getSingleton( ).outString( f );
	NetworkInterface *net = pClient->getNetwork();
    switch (recv_data.opcode)
    {
				case CMSG_REPOP_REQUEST:
					{
						Log::getSingleton( ).outString( "WORLD: Recvd CMSG_REPOP_REQUEST Message" );

//						printf("updates\n");
						pClient->getCurrentChar( )->setUpdateValue( UNIT_FIELD_HEALTH, 1 );	
//						printf("updated\n");

						//pClient->getCurrentChar( )->UpdateObject();

						float x,y,z;
						uint16 mapID;
						x = pClient->getCurrentChar()->getPositionX();
						y = pClient->getCurrentChar()->getPositionY();
						z = pClient->getCurrentChar()->getPositionZ();					
						mapID = pClient->getCurrentChar()->getMapId();
						WorldServer::getSingletonPtr( )->dbi->getClosestSpiritHealer(x,y,z,mapID);
						wowWData data;
						pClient->getCurrentChar()->TeleportAck(&data, x,y,z);
						pClient->SendMsg(&data);
//						pClient->getCurrentChar()->BuildHeartBeat(&data);
//						world.SendGlobalMessage(&data, pClient);			

						/*/START OF LINA TEMP DEATH FIX
						Character * pChar = pClient->getCurrentChar();
						pChar->m_deathTimer = 0;
        				pChar->setDeathState(ALIVE);
						pChar->m_respawnTimer = 0;
      
						UpdateMask mask;
						wowWData data;
						WorldServer::getSingletonPtr()->mObjectMgr.SetCreateUnitBits(mask);
						uint32 max_health = pChar->getUpdateValue(UNIT_FIELD_MAXHEALTH);
						pChar->setUpdateValue(UNIT_FIELD_HEALTH, max_health);

						//maybe tale some xp away?
						//pClient->getCurrentChar( )->setUpdateValue( UNIT_FIELD_FLAGS, 8 );
						pChar->setUpdateValue( UNIT_FIELD_FLAGS, (0xffffffff - 65536) & pChar->getUpdateValue( UNIT_FIELD_FLAGS ) );
						pChar->setUpdateValue( UNIT_FIELD_AURA +32, 0 );
						pChar->setUpdateValue( UNIT_FIELD_AURAFLAGS +4, 0 );
						pChar->setUpdateValue( UNIT_FIELD_AURASTATE, 0 );
						//pClient->getCurrentChar( )->setUpdateValue( PLAYER_BYTES_2, 16777984 );
						pChar->setUpdateValue( PLAYER_BYTES_2, (0xffffffff - 0x10) & pClient->getCurrentChar( )->getUpdateValue( PLAYER_BYTES_2 ) );
						//setDeathState(ALIVE);

						uint8 buf[256];

						uint32 xp = pChar->getUpdateValue(PLAYER_XP);
						uint32 xpt = (uint32)( 200 * pChar->getLevel() * pow(pChar->getLevel(),1.2));
						int32 newxp = xp - xpt;
						if(newxp < 0) 
						{
							sprintf((char*)buf,"You lose all of youre XP, be carefull.");
							pChar->setUpdateValue(PLAYER_XP, 0);
						}
						else 
						{
							sprintf((char*)buf,"You lose %u XP.", xpt);
							pChar->setUpdateValue(PLAYER_XP, newxp);
						}
						WorldServer::getSingleton().mChatHandler.FillMessageData(&data, 0x09, pClient, buf);
						pClient->SendMsg( &data );
						printf("Take XP %i, so %i\n", xpt, newxp);

						uint32 money = pChar->getUpdateValue(PLAYER_FIELD_COINAGE);
						uint32 moneyt = (uint32)(200 * pow(pChar->getLevel(),1.2));
						int32 newmoney = money - moneyt;
						if(newmoney < 0) 
						{
							sprintf((char*)buf,"You lose all of youre coppers, be carefull.");
							pChar->setUpdateValue(PLAYER_FIELD_COINAGE, 0);
						}
						else 
						{
							sprintf((char*)buf,"You lose %u coppers.", moneyt);
							pChar->setUpdateValue(PLAYER_FIELD_COINAGE, newmoney);
						}
						WorldServer::getSingleton().mChatHandler.FillMessageData(&data, 0x09, pClient, buf);
						pClient->SendMsg( &data );
						printf("Take Gold %i, so %i\n", moneyt, newmoney);
						//END OF LINA TEMP DEATH FIX */
	
					}break;  

					case CMSG_AUTOSTORE_LOOT_ITEM:
					{
						int i,slot = 0;
						uint32 itemid;
						uint8 lootSlot;
						std::map<uint32, Unit*>::iterator itr = world.mCreatures.find(pClient->getCurrentChar()->getLootGUID());
						if (itr->second == NULL)
							return;
						recv_data >> lootSlot;
						for(i = 23; i <= 38; i++) 
						{
							if (pClient->getCurrentChar()->getGuidBySlot(i) == 0) {
								slot = i;
								break;
							}
						}
						if (slot == 0)
							return; //maybe whine a bit too?
   						if (itr->second->getItemAmount(lootSlot) == 0)
							return; //maybe whine a bit too?
						world.m_hiItemGuid++;
						itemid = itr->second->getItemId(lootSlot);
						itr->second->setItemAmount(lootSlot, 0);
						pClient->getCurrentChar()->AddItemToSlot(slot,world.m_hiItemGuid,itemid);
						
						world.mItemHandler.createItemUpdate(&data, pClient, slot);
						pClient->SendMsg( &data );

						UpdateMask updateMask;
						updateMask.setCount( 0x1b );
						pClient->getCurrentChar( )->setUpdateValue( PLAYER_FIELD_INV_SLOT_HEAD  + (slot*2), pClient->getCurrentChar()->getGuidBySlot(slot), updateMask.updateMask );
						pClient->getCurrentChar( )->setUpdateValue( PLAYER_FIELD_INV_SLOT_HEAD  + (slot*2)+1, pClient->getCurrentChar()->getGuidBySlot(slot) == 0 ? 0 : 0x00000040, updateMask.updateMask );
						pClient->getCurrentChar( )->UpdateObject( &updateMask, &data );
						pClient->SendMsg( &data );

						data.Initialise(1 , SMSG_LOOT_REMOVED);
						data << uint8(lootSlot);
						pClient->SendMsg( &data );

					}break;
				case CMSG_LOOT_MONEY:
					{
						UpdateMask updateMask;
						updateMask.setCount( 0x1b );
						uint32 newcoinage = 0;
						std::map<uint32, Unit*>::iterator itr = world.mCreatures.find(pClient->getCurrentChar()->getLootGUID());
						if (itr->second == NULL)
							return;

						newcoinage = pClient->getCurrentChar()->getUpdateValue(PLAYER_FIELD_COINAGE) + itr->second->getLootMoney();
						itr->second->setLootMoney(0);
						pClient->getCurrentChar()->setUpdateValue( PLAYER_FIELD_COINAGE , newcoinage);				
					}break;
				case CMSG_LOOT:
					{  
						uint32 guid1, guid2;
						uint16 tmpDataLen,tmpItemsCount = 0;
						uint8 i;
						Item *tmpLootItem;
						recv_data >> guid1 >> guid2;

						std::map<uint32, Unit*>::iterator itr = world.mCreatures.find(guid1);
						if (itr->second == NULL)
							return;

						pClient->getCurrentChar()->setLootGUID(guid1,guid2);
						for(i = 0; i<itr->second->getItemCount() ; i++) {
							if (itr->second->getItemAmount((int)i) > 0)
								tmpItemsCount++;
						}
						tmpDataLen = 14 + tmpItemsCount*21;
						data.Initialise(tmpDataLen, SMSG_LOOT_RESPONSE);
						data << uint32(guid1);
						data << uint32(guid2);
						data << uint8(0x01);
						data << uint32(itr->second->getLootMoney());
						data << uint8(itr->second->getItemCount());
						for(i = 0; i<itr->second->getItemCount() ; i++) {
							if (itr->second->getItemAmount((int)i) > 0) {
								data << uint8(i);
								tmpLootItem = world.GetItem(itr->second->getItemId((int)i));
								data << uint32(itr->second->getItemId((int)i));
								data << uint32(itr->second->getItemAmount((int)i));
								data << uint32(tmpLootItem->DisplayInfoID);
								data << uint32(0) << uint32(0);
							}
						}
						net->sendWData( &data ); 
					}break;   
				case CMSG_LOOT_RELEASE:
					{  
						uint32 guid1, guid2;    
						pClient->getCurrentChar()->setLootGUID(0,0);
						recv_data >> guid1 >> guid2;
						data.Initialise( 9, SMSG_LOOT_RELEASE_RESPONSE );
						data << guid1 << guid2 << uint8( 1 );            
						net->sendWData( &data );
					}break;
				case CMSG_WHO:
					{	
						uint64 clientcount = 0;
						int datalen = 8;
						int countcheck = 0;
						Log::getSingleton( ).outString( "WORLD: Recvd CMSG_WHO Message" );
						

						WorldServer::ClientSet::iterator itr;
						for (itr = world.mClients.begin(); itr != world.mClients.end(); itr++)
						{
							if ( ((GameClient*)(*itr))->getCharacterName() ) {
								clientcount++;
								datalen = datalen + strlen(((GameClient*)(*itr))->getCharacterName()) + 1 + strlen(((GameClient*)(*itr))->getCurrentChar()->getGuildName()) + 1 + 21;
							}
						}

						data.clear();
						data.Initialise(datalen, SMSG_WHO);
						data << uint64( clientcount );
						for (itr = world.mClients.begin(); itr != world.mClients.end(); itr++) 
						{
							if ((( ((GameClient*)(*itr))->getCharacterName() ) && (((GameClient*)(*itr))->IsInWorld()) ) && (countcheck  < clientcount)) 
							{
								countcheck++;
								data.writeData(((GameClient*)(*itr))->getCurrentChar()->getName() , strlen(((GameClient*)(*itr))->getCurrentChar()->getName())); 
                                data << uint8( 0x00 ); 
                                if(!strcmp(((GameClient*)(*itr))->getCurrentChar()->getGuildName(), "")) 
									data.writeData("",0); 
                                else 
                                    data.writeData(((GameClient*)(*itr))->getCurrentChar()->getGuildName()) , strlen(((GameClient*)(*itr))->getCurrentChar()->getGuildName()); 
								data << uint8( 0x00 );
                                data << uint32( ((GameClient*)(*itr))->getCurrentChar()->getLevel() );
                                data << uint32( ((GameClient*)(*itr))->getCurrentChar()->getClass() );
                                data << uint32( ((GameClient*)(*itr))->getCurrentChar()->getRace() );
								data << uint32( ((GameClient*)(*itr))->getCurrentChar()->getZone() );
								
								if(((GameClient*)(*itr))->getCurrentChar()->IsInGroup())
								{
									data << uint32( 0x00000001 ); //group
								}
								else
								{
									data << uint32( 0x00000000 );
								}
							}
						}
						pClient->SendMsg(&data);
					}break;

				case CMSG_LOGOUT_REQUEST:
					{
						Log::getSingleton( ).outString( "WORLD: Recvd CMSG_LOGOUT_REQUEST Message" );
						if(pClient->getCurrentChar()->m_state && UF_ATTACKING) 
						{ 
						   ChatHandler pChat; 
							pChat.FillMessageData(&data, 0x09, pClient, (uint8*)"You can't logout in fight !!!"); 
							pClient->SendMsg(&data); 
							data.clear(); 
							data.Initialise( 5, SMSG_LOGOUT_RESPONSE ); 
							data << uint32(0); //Filler 
							data << uint8(1); //Logout rejected 
						} 
						else 
						{ 
							data.clear(); 
							data.Initialise( 5, SMSG_LOGOUT_RESPONSE ); 
							data << uint32(0); //Filler 
							data << uint8(0); //Logout accepted 
							pClient->LogoutRequest(time(NULL)); 
						} 

						net->sendWData( &data );

					}break;

				case CMSG_PLAYER_LOGOUT:
					{
						Log::getSingleton( ).outString( "WORLD: Recvd CMSG_PLAYER_LOGOUT Message" );

						data.clear();
						data.length = 0;
						data.data = new uint8[ data.length ];
						data.opcode = SMSG_LOGOUT_COMPLETE;
						net->sendWData( &data );

						world.LogoutPlayer(pClient);

						Log::getSingleton( ).outString( "WORLD: sent SMSG_LOGOUT_COMPLETE Message" );
					}break;

				case CMSG_LOGOUT_CANCEL:
					{
						Log::getSingleton( ).outString( "WORLD: Recvd CMSG_LOGOUT_CANCEL Message" );

                        pClient->LogoutRequest(0);

						data.clear();
						data.length = 0;
						data.data = new uint8[ data.length ];
						data.opcode = SMSG_LOGOUT_CANCEL_ACK;
						net->sendWData( &data );

						Log::getSingleton( ).outString( "WORLD: sent SMSG_LOGOUT_CANCEL_ACK Message" );
					}break;

				case CMSG_PING:
					{
						//Log::getSingleton( ).outString( "WORLD: Recvd CMSG_PING Message" );
						uint32 ping;
						memcpy(&ping, recv_data.data, 4);
						data.clear();						
						data.Initialise( 4, SMSG_PONG );						
						data << ping;
						net->sendWData( &data );
						//Log::getSingleton( ).outString( "WORLD: sent SMSG_PONG Message" );
					}break;

                case CMSG_GMTICKET_GETTICKET:
					{
						data.Initialise( 10, SMSG_GMTICKET_GETTICKET );	
						data << uint32(6);
                        data << uint32(0xffbfbfbf);
                        data << uint8(0);
                        data << uint8(3);
						net->sendWData( &data );
					}break;

                case CMSG_GMTICKET_CREATE:
					{
                        //TODO: Receive message sent and relay it to an online GM
						data.Initialise( 4, SMSG_GMTICKET_CREATE );	
						data << uint32(2);
						net->sendWData( &data );
					}break;

                case CMSG_GMTICKET_SYSTEMSTATUS:
					{
                        //TODO: Receive message sent and relay it to an online GM
						data.Initialise( 4, SMSG_GMTICKET_SYSTEMSTATUS );	
						data << uint32(1);
						net->sendWData( &data );
					}break;

				case CMSG_ZONEUPDATE:
					{
						uint32 newZone,oldZone;
						recv_data.readData(newZone);
						printf("WORLD: Recvd ZONE_UPDATE: %u\n", newZone);
						if (pClient->getCurrentChar()->getZone() == newZone)
							return;

						oldZone = pClient->getCurrentChar( )->getZone();
						//Setting new zone
						if( pClient->getCurrentChar( ) )
							pClient->getCurrentChar()->setZone((uint16)newZone);

					}break;
/*
				//START OF LINA ACTION BAR
				case CMSG_SET_ACTION_BUTTON:
					{
						Log::getSingleton( ).outString( "WORLD: Recieved CMSG_SET_ACTION_BUTTON" );
						uint8 button, misc, type;
						uint16 action;
						recv_data >> button >> action >> misc >> type;
						printf("BUTTON: %x ACTION: %x TYPE: %x MISC: %x \n", button, action, type, misc);
						if(action==0) printf("MISC: Remove action from button %i\n", button);
						else
						{
							if(type==0x40)
							{
								printf("MISC: Macro %i into button %i\n", action, button);
								break; //don't save action button for macro, because macro are client dependent
							}
							else if(type==0x0) 
							{
								printf("MISC: Add Action %i into button %i\n", action, button);
							}
						}
						pClient->getCurrentChar()->addAction(button,action,type,misc);
					}break;

				case CMSG_PET_SET_ACTION:
					{
						Log::getSingleton( ).outString( "WORLD: Recieved CMSG_PET_SET_ACTION" );
						uint8 val;
						int i=0;
						for( int size = recv_data.length ; i < size ; i++)
						{
							recv_data >> val;
							printf("%i|%x\n",val);
						}
						//pClient->getCurrentChar()->addAction(button,action,type,misc);
					}break;
				//END OF LINA ACTION BAR
*/
				case CMSG_PLAYER_LOGIN:
					{
						Log::getSingleton( ).outString( "WORLD: Recvd Player Logon Message" );
						uint32 player_guid=0;

						memcpy(&player_guid,recv_data.data,4); //This is the GUID selected by the player
						pClient->setCurrentChar(pClient->getCurrentChar(player_guid));
						Character *pCurrChar = pClient->getCurrentChar();
						pClient->setLogged();
						world.dbi->loadQuestStatus(pCurrChar);

                        data.Initialise(80, SMSG_ACCOUNT_DATA_MD5);
                        memset(data.data, 0, 80);
                        pClient->SendMsg(&data);

						// MOTD
						const uint8 msgchat_header_size=13;
						uint8 msgchat_header[msgchat_header_size] = { 0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

						uint8 msgchat_info[256];
						uint8 msgchat_info_size=0;
						sprintf((char*)msgchat_info,SITW"\nServer Engine: %s\nNumber of users connected: %i/%i\n",XVERSION, (int)world.GetClientsConnected(),playerlimit);
						for(;msgchat_info[msgchat_info_size]!=0;msgchat_info_size++){}

                        data.Initialise(world.motd_size + msgchat_header_size + msgchat_info_size + 1, SMSG_MESSAGECHAT);
						memcpy(data.data, msgchat_header, msgchat_header_size);
						memcpy(data.data+msgchat_header_size, msgchat_info, msgchat_info_size);
						memcpy(data.data+msgchat_header_size+msgchat_info_size, world.motd, world.motd_size);
						data.data[world.motd_size + msgchat_header_size + msgchat_info_size]=0; //Yeah, it looks like there must be two 0 at the end of the string
						pClient->SendMsg( &data );
						Log::getSingleton( ).outString( "WORLD: Sent motd (SMSG_MESSAGECHAT)" );


                        //data.Initialise(4, SMSG_SET_REST_START);
                        //data << unsure;
                        //pClient->SendMsg(&data);

                        //Tutorial Flags
						data.Initialise(32,SMSG_TUTORIAL_FLAGS);
                        memset(data.data, 0xff, 32);
                        pClient->SendMsg(&data);
						Log::getSingleton( ).outString( "WORLD: Sent tutorial flags." ); 

                        //Initial Spells
                        pCurrChar->smsg_InitialSpells();

						//START OF LINA ACTION BAR
						//Initial Action Buttons
						pCurrChar->smsg_InitialActions();
						//END OF LINA ACTION BAR

                        // SMSG_INITIALIZE_FACTIONS

                        // SMSG_EXPLORATION_EXPERIENCE

                        // SMSG_CAST_RESULT -- Spell_id = 836 (LOGINEFFECT (24347)) From spells.dbc.csv

    					data.Initialise(8, SMSG_LOGIN_SETTIMESPEED);
						uint32 minutes = world.updateGameTime( ) / 60;
						uint32 hours = minutes / 60; minutes %= 60;
						uint32 gameTime = minutes + ( hours << 6 );
						data << (uint32)gameTime;
						data << (float)0.017f;	// Normal Game Speed
						pClient->SendMsg( &data ); 

                        // SMSG_UPDATE_AURA_DURATION -- if the player had an aura on when he logged out

                        // Bojangles has Been up in here :0 Cinematics working Just need
						// the sound flags to kick off sound.
						// doesnt check yet if its the first login to run. *YET*
						// WantedMan fixed so it will only start if you are at starting loc
						if (cinematics == 1)
						{
						data.Initialise( 4, SMSG_TRIGGER_CINEMATIC );
                        uint8 theRace = pCurrChar->getRace(); // get race
						// Get Player Position
							float xLoc = pCurrChar->m_positionX;
							float yLoc = pCurrChar->m_positionY;
							float zLoc = pCurrChar->m_positionZ;

                        if (theRace == 1) // Human
						{
							if (xLoc == -8897.50f)
							if (yLoc == -173.480f)
							if (zLoc == 81.5775f)

							{
							data << uint32(81);
							pClient->SendMsg( &data );
							}
						}
						if (theRace == 2) // Orc
						{
							if (xLoc == -618.518f)
							if (yLoc == -4251.67f)
							if (zLoc == 38.718f)

							{
							data << uint32(21);
							pClient->SendMsg( &data );
							}
						}
						if (theRace == 3) // Dwarf
						{
							if (xLoc == -6240.32f)
							if (yLoc == 331.033f)
							if (zLoc == 382.758f)

							{
							data << uint32(41);
							pClient->SendMsg( &data );
							}
						}
						if (theRace == 4) // Night Elves
						{
							if (xLoc == 10311.3f)
							if (yLoc == 832.463f)
							if (zLoc == 1326.41f)

							{
							data << uint32(61);
							pClient->SendMsg( &data );
							}
						}
						if (theRace == 5) // undead <-- WORKING thats Correct
						{
							if (xLoc == 1676.35f)
							if (yLoc == 1677.45f)
							if (zLoc == 121.67f)

							{
							data << uint32(2);
							pClient->SendMsg( &data );
							}
						}
						if (theRace == 6) // Tauren
						{
							if (xLoc == -2917.58f)
							if (yLoc == -257.98f)
							if (zLoc == 52.9968f)

							{
							data << uint32(141);
							pClient->SendMsg( &data );
							}
						}
						if (theRace == 7) // Gnome
						{
							if (xLoc == -6240.32f)
							if (yLoc == 331.033f)
							if (zLoc == 382.758f)

							{
							data << uint32(101);
							pClient->SendMsg( &data );
							}
						}
						if (theRace == 8) // Troll
						{
							if (xLoc == -618.518f)
							if (yLoc == -4251.67f)
							if (zLoc == 38.718f)

							{
							data << uint32(121);
							pClient->SendMsg( &data );
							}
						}
                        if (startzone == 1) // Cinematics
						{
							if (xLoc == -8897.50f)
							if (yLoc == -173.480f)
							if (zLoc == 81.5775f)

							{
							if (theRace == 2) // Orc
							{
							data << uint32(81);
							pClient->SendMsg( &data );
							}
							if (theRace == 3) // Dwarf
							{
							data << uint32(81);
							pClient->SendMsg( &data );
							}
							if (theRace == 4) // Night Elves
							{
							data << uint32(81);
							pClient->SendMsg( &data );
							}
							if (theRace == 5) // undead
							{
							data << uint32(81);
							pClient->SendMsg( &data );
							}
							if (theRace == 6) // Tauren
							{
							data << uint32(81);
							pClient->SendMsg( &data );
							}
							if (theRace == 7) // Gnome
							{
							data << uint32(81);
							pClient->SendMsg( &data );
							}
							if (theRace == 8) // Troll
							{
							data << uint32(81);
							pClient->SendMsg( &data );
							}
							}
						}
					}

						//SEND EXTRA STAT/VALUES 
						//Talent points 
						pCurrChar->setUpdateValue(PLAYER_CHARACTER_POINTS1,pCurrChar->getUpdateValue(PLAYER_CHARACTER_POINTS1)); 

						// Now send all A9's

						pCurrChar->m_stat0 = pCurrChar->getUpdateValue(UNIT_FIELD_STAT0);
						pCurrChar->m_stat1 = pCurrChar->getUpdateValue(UNIT_FIELD_STAT1);
						pCurrChar->m_stat2 = pCurrChar->getUpdateValue(UNIT_FIELD_STAT2);
						pCurrChar->m_stat3 = pCurrChar->getUpdateValue(UNIT_FIELD_STAT3);
						pCurrChar->m_stat4 = pCurrChar->getUpdateValue(UNIT_FIELD_STAT4);
						//pCurrChar->m_health = pCurrChar->getUpdateValue(UNIT_FIELD_HEALTH);
						pCurrChar->m_health = pCurrChar->getUpdateValue(UNIT_FIELD_MAXHEALTH);
						//pCurrChar->m_mana = pCurrChar->getUpdateValue(UNIT_FIELD_POWER1);
						pCurrChar->m_mana = pCurrChar->getUpdateValue(UNIT_FIELD_MAXPOWER1);
						pCurrChar->updateItemStats();

						//update GM flag
						if (pClient->getAccountLvl()) {
						    uint32 newbytes = pCurrChar->getUpdateValue(PLAYER_BYTES_2) | 0x8;
							pCurrChar->setUpdateValue( PLAYER_BYTES_2, newbytes);
						} else {
							uint32 newbytes = pCurrChar->getUpdateValue(PLAYER_BYTES_2) & ~(0x8);
							pCurrChar->setUpdateValue( PLAYER_BYTES_2, newbytes);
						}

                        //======================================================================================
                        //  Create Player Character

                        world.mObjectMgr.BuildAndSendCreatePlayer(pCurrChar, 1, NULL);
						Log::getSingleton( ).outString( "WORLD: Created Player Character" );

						// Add character to the ingame list
						// And let this client know we're in game
						pClient->InWorld(true);
						world.mCharacters[ pCurrChar->getGUID() ] = pCurrChar;

                        // Build the in-range set
                        WorldServer::getSingleton().CheckForInRangeObjects(pCurrChar);

                        //=======================================================================================
						// Send a message to other Clients that a new player has entered the world

                        std::list<wowWData*> msglist;
                        world.mObjectMgr.BuildCreatePlayerMsg(pCurrChar, &msglist, 0);

                        std::list<wowWData*>::iterator msgitr;
                        for (msgitr = msglist.begin(); msgitr != msglist.end(); )
                        {
                            wowWData *msg = (*msgitr);
                            pClient->getCurrentChar()->SendMessageToSet(msg, false);
                            delete msg;
                            msgitr = msglist.erase(msgitr);
                        }

						Log::getSingleton( ).outString( "WORLD: Created new player for existing players" );

                        // Creation of existing creatures and players moved to UpdateInRangeSet(), where only objects close enough
                        // are created
/*
						Log::getSingleton( ).outString( "WORLD: Creating creatures..." );
						for( WorldServer::CreatureMap::iterator i = world.mCreatures.begin( ); i != world.mCreatures.end( ); ++ i ) {
							if (pClient->getCurrentChar()->getZone() != i->second->getZone())
									continue;
							data.clear();
                            UpdateMask unitMask;
                            WorldServer::getSingletonPtr()->mObjectMgr.SetCreateUnitBits(unitMask);

							i->second->SendCreateWithTempNpcFlags(&unitMask, pClient);
							i->second->clearUpdateMask();
						}
*/
/*
						printf("%s\n",pClient->getCharacterName( ));
						std::string outstring = pClient->getCharacterName( );
						outstring.append( " has entered the world." );
						world.SendWorldText( (uint8*)outstring.c_str( ) );	
						*/
						ChatHandler pChat;
						wowWData data;
						uint8 buf[256];
						sprintf((char*)buf,"%s joined the world.", pClient->getCharacterName( ));
						pChat.FillMessageData(&data, 0x09, pClient, buf);
						world.SendZoneMessage(&data, pClient, 0);

					}break;

				case CMSG_SET_TARGET:
					{
						Log::getSingleton( ).outString( "WORLD: Recieved CMSG_SET_TARGET" );
						uint32 guid1, guid2;
						recv_data >> guid1 >> guid2;
						if( pClient->getCurrentChar( ) != 0 ) {
							pClient->getCurrentChar( )->m_curTarget[ 0 ] = guid1;
							pClient->getCurrentChar( )->m_curTarget[ 1 ] = guid2;
						}
					}break;

				case CMSG_SET_SELECTION: 
               { 
                  Log::getSingleton( ).outString( "WORLD: Recieved CMSG_SET_SELECTION" ); 
                  if( pClient->getCurrentChar( ) != 0 ) 
                     recv_data >> pClient->getCurrentChar( )->m_curSelection[ 0 ] >> pClient->getCurrentChar( )->m_curSelection[ 1 ]; 
                   
//                  if(pClient->getCurrentChar()->getDeathState() == CORPSE && pClient->getCurrentChar( )->m_curSelection[ 1 ]==0xF0001000) 
                  if(pClient->getCurrentChar( )->m_curSelection[ 1 ]==0xF0001000) 
                  { 
                     Unit * pUnit = WorldServer::getSingleton().GetCreature(pClient->getCurrentChar( )->m_curSelection[ 0 ]); 

                     if( pUnit->getUpdateValue(UNIT_NPC_FLAGS) == 1 ) 
                     { 
                        printf("Spirit Healer!\n"); 
                        DatabaseInterface *dbi = WorldServer::getSingleton( ).dbi; 
                        uint16 tSize; 
                        tSize = 47; 
                        data.Initialise( tSize, SMSG_GOSSIP_MESSAGE ); 
                        tSize = 0; 

                        data << pClient->getCurrentChar( )->m_curSelection[ 0 ] << pClient->getCurrentChar( )->m_curSelection[ 1 ]; 
                        data << dbi->getNextTextID( 1 , pClient->getCurrentChar()->getGUID() ); 
                        data << (uint32)0x00000001; //count 
                        data << (uint32)0x00000000; //uk2 
                        data << (uint32)0x00000004; //uk3 
                        data << (uint8)0x52; 
                        data << (uint32)0x72757465; 
                        data << (uint32)0x656D206e; 
                        data << (uint32)0x206F7420; 
                        data << (uint32)0x6566696c; 
                        data << (uint8)0x2e; 
                        data << (uint8)0x00; 
                        data << (uint32)0; 
                        pClient->SendMsg( &data ); 
                     } 
//                     else 
//                        printf("TARGET NPC FLAGS = %u\n", pUnit->getUpdateValue(UNIT_NPC_FLAGS)); 
                  } 
               }break;

				case CMSG_STANDSTATECHANGE:
					{
						if( pClient->getCurrentChar( ) != 0 ) {
                            // retrieve current BYTES
                            uint32 bytes1 = pClient->getCurrentChar( )->getUpdateValue( UNIT_FIELD_BYTES_1 );
                            uint8 bytes[4];
							uint64 guid;
							recv_data >> guid;
                            bytes[0] = uint8(bytes1 & 0xff);
                            bytes[1] = uint8((bytes1>>8) & 0xff);
                            bytes[2] = uint8((bytes1>>16) & 0xff);
                            bytes[3] = uint8((bytes1>>24) & 0xff);

                            // retrieve new stand state
                            uint8 animstate;
							recv_data >> animstate;

//                            if (bytes[0] == animstate) break;
                            bytes[0] = animstate;

                            uint32 newbytes = (bytes[0]) + (bytes[1]<<8) + (bytes[2]<<16) + (bytes[3]<<24);
							pClient->getCurrentChar( )->setUpdateValue(UNIT_FIELD_BYTES_1 , newbytes);
						}
					}break;


					// Friends related

					/*
					case  	CMSG_NAME_QUERY:
					{
					Log::getSingleton( ).outString( "WORLD: Recieved CMSG_NAME_QUERY"  );



					uint64 GUID=0;
					recv_data >> GUID;
					char tmpBuf[2156];
					sprintf( tmpBuf, "WORLD: %s name querried : '%d'", pClient->getCharacterName( ), GUID );
					Log::getSingleton( ).outString( tmpBuf );


					uint64  	GUID
					string 	Name
					uint 	Race
					uint 	Sex
					uint 	Class

					int FriendArea=0;
					int FriendLevel=0;
					int FriendClass=0;



					// TODO: Delete Friend from list, and fill in FriendResult.



					// Send reposnse.
					data.clear();
					data.opcode =SMSG_FRIEND_STATUS;
					data.length=sizeof(FriendResult) + sizeof(FriendGUID);
					data.data= new uint8[ data.length ];
					data <<  FriendResult << FriendGUID;		
					net->sendWData( &data );

					Log::getSingleton( ).outString( "WORLD: Sent motd (SMSG_FRIEND_STATUS)" );




					}break;*/
				case CMSG_FRIEND_LIST:
					{
						char tmpBuf[2156];

						Log::getSingleton( ).outString( "WORLD: Recieved CMSG_FRIEND_LIST"  );

						unsigned char Counter=0;
						int datalen = 8;
						int countcheck = 0;
						int CharCheck = 0;
						int charguid;
						int i;
						SocialData *pSdata;
						FriendData *pFriend;

						DatabaseInterface *dbi = Database::getSingleton().createDatabaseInterface();
						pSdata = dbi->getFriendList(pClient->getCurrentChar()->getGUID());

						pFriend = new FriendData[pSdata->pArraySize];
						
						WorldServer::ClientSet::iterator itr;
						for(i=0; i < pSdata->pArraySize; i++)
						{
							for (itr = world.mClients.begin(); itr != world.mClients.end(); itr++) {
								if (((GameClient*)(*itr))->IsInWorld())
									charguid = ((GameClient*)(*itr))->getCurrentChar()->getGUID();
								else charguid = 0;
								if (((((GameClient*)(*itr))->getCharacterName() ) && (pSdata->pSudata[i].guid == charguid) && (((GameClient*)(*itr))->IsInWorld()))) 
								{
									pFriend[i].pGuid = pSdata->pSudata[i].guid;
									pFriend[i].Status = 1;
									pFriend[i].tmpStatus = 1;
									pFriend[i].Area = ((GameClient*)(*itr))->getCurrentChar()->getZone();
									pFriend[i].Level = ((GameClient*)(*itr))->getCurrentChar()->getLevel();
									pFriend[i].Class = ((GameClient*)(*itr))->getCurrentChar()->getClass();
								}
								else
								{
									if((pFriend[i].Status != 0) && (pFriend[i].Status != 1))
									{
										pFriend[i].pGuid = pSdata->pSudata[i].guid;
										pFriend[i].Status = 0;
										pFriend[i].tmpStatus = 0;
									}
								}
							}
						}

						Counter = pSdata->pArraySize;
						
						data.clear();
						data.opcode = SMSG_FRIEND_LIST;
						data.length=sizeof(Counter) + (Counter * sizeof(FriendData));
						data.data= new uint8[data.length];

						data << Counter;

						for (int j=0; j<Counter; j++) {
							sprintf(tmpBuf,"Adding Friend - Guid:%i, Status:%i, Area:%i, Level:%i Class:%i",
								pFriend[j].pGuid, pFriend[j].Status, pFriend[j].Area,pFriend[j].Level,pFriend[j].Class);
							Log::getSingleton( ).outString( tmpBuf  );
							pFriend[j].Status = char(pFriend[j].tmpStatus);

							data << pFriend[j].pGuid << pFriend[j].Status ;
							if (pFriend[j].Status != 0)
							data << pFriend[j].Area << pFriend[j].Level << pFriend[j].Class;
						}

						net->sendWData( &data );

						Log::getSingleton( ).outString( "WORLD: Sent (SMSG_FRIEND_LIST)" );

					}break;
				case CMSG_ADD_FRIEND:
					{
						Log::getSingleton( ).outString( "WORLD: Recieved CMSG_ADD_FRIEND"  );

						char FriendName[2048]="UNKNOWN";
						recv_data >> FriendName;

						char tmpBuf[2156];
						sprintf( tmpBuf, "WORLD: %s asked to add friend : '%s'", pClient->getCharacterName( ), FriendName );
						Log::getSingleton( ).outString( tmpBuf );
						
						unsigned char FriendResult = FRIEND_NOT_FOUND;
						unsigned char FriendStatus;
						uint64 friendGuid = 0;
						uint32 FriendArea=0;
						uint32 FriendLevel=0;
						uint32 FriendClass=0;
						int i;
						SocialData *pSdata;
						ChatHandler pChat;
						
						DatabaseInterface *dbi = Database::getSingleton().createDatabaseInterface();

						pSdata = dbi->getFriendList(pClient->getCurrentChar()->getGUID());
						
						int tmpguid = pClient->getDB()->GetNameGUID(FriendName);
						
							if (tmpguid > 0) 
							{
								for(i=0; i < pSdata->pArraySize; i++)
								{
									if (pSdata->pSudata[i].guid == tmpguid)
									{
										FriendResult = FRIEND_ALREADY;
										uint8 buf[256];
										uint8 helpMessage[255] = "Friend already added";
										sprintf((char*)buf,"%s	",  helpMessage);
										pChat.FillMessageData(&data, 0x09, pClient, buf);
										pClient->SendMsg( &data );
											
									}
								}
								if (FriendResult != FRIEND_ALREADY)
								{
									friendGuid = tmpguid;
									if( world.mCharacters.find( (uint32)friendGuid ) != world.mCharacters.end( ) )
									{
										FriendResult = FRIEND_ADDED_ONLINE;	
										Character *pChar = world.mCharacters[tmpguid]; 
										FriendArea = pChar->getZone();
										FriendClass = pChar->getClass();
										FriendLevel = pChar->getLevel();
										FriendStatus = 1;
									}
									else
									{
										FriendResult = FRIEND_ADDED_OFFLINE;
										FriendStatus = 0;
									}
									sprintf( tmpBuf, "WORLD: %s Guid found '%ld' area:%d Level:%d Class:%d. ", FriendName , friendGuid, FriendArea,FriendLevel,FriendClass);
									Log::getSingleton( ).outString( tmpBuf );
									if (!strcmp(pClient->getCharacterName(),FriendName))
									{
										FriendResult = FRIEND_SELF;
									}
									else
									{
										dbi->AddFriend(pClient->getCurrentChar()->getGUID() ,friendGuid ,FriendName);
									}	
								}
							}
							else 
							{
								sprintf( tmpBuf, "WORLD: %s Guid not found ", FriendName );
								Log::getSingleton( ).outString( tmpBuf );
							}

						// Send reposnse.
						data.clear();
						data.opcode =SMSG_FRIEND_STATUS;
						if (FriendResult ==  FRIEND_ADDED_ONLINE || FriendResult == FRIEND_ONLINE || 
							FriendResult ==  FRIEND_OFFLINE  
							//|| FriendResult ==  FRIEND_ADDED_OFFLINE 
							)
						{
							data.length=sizeof(FriendResult) + sizeof(friendGuid) + sizeof(FriendStatus) + sizeof(FriendArea) 
								+ sizeof(FriendLevel) +  sizeof(FriendClass);
							data.data= new uint8[ data.length ];
							data <<  FriendResult << friendGuid;
							data <<  FriendArea << FriendLevel << FriendClass;
						}
						else 
						{
							data.length=sizeof(FriendResult) + sizeof(friendGuid);
							data.data= new uint8[ data.length ];
							data <<  FriendResult << friendGuid;					
						}

						net->sendWData( &data );

						Log::getSingleton( ).outString( "WORLD: Sent (SMSG_FRIEND_STATUS)" );

					}break;
				case CMSG_DEL_FRIEND:
					{
						Log::getSingleton( ).outString( "WORLD: Recieved CMSG_DEL_FRIEND"  );

						uint64 FriendGUID;
						recv_data >> FriendGUID;
						char tmpBuf[2156];
						sprintf( tmpBuf, "WORLD: %s asked to Remove friend : '%ld'", pClient->getCharacterName( ), FriendGUID );
						Log::getSingleton( ).outString( tmpBuf );

						DatabaseInterface *dbi = Database::getSingleton().createDatabaseInterface();

						unsigned char FriendResult = FRIEND_REMOVED;
						int FriendArea=0;
						int FriendLevel=0;
						int FriendClass=0;

						dbi->RemoveFriend(pClient->getCurrentChar()->getGUID() ,FriendGUID);

						// Send reposnse.
						data.clear();
						data.opcode =SMSG_FRIEND_STATUS;
						data.length=sizeof(FriendResult) + sizeof(FriendGUID);
						data.data= new uint8[ data.length ];
						data <<  FriendResult << FriendGUID;		
						net->sendWData( &data );

						Log::getSingleton( ).outString( "WORLD: Sent motd (SMSG_FRIEND_STATUS)" );
						
					}break;
				case CMSG_BUG:
					{
						uint32 suggestion, contentlen;
						std::string content;
						uint32 typelen;
						std::string type;
						recv_data >> suggestion >> contentlen >> content >> typelen >> type;
						if( suggestion == 0 )
							Log::getSingleton( ).outString( "WORLD: Recieved CMSG_BUG [Bug Report]" );
						else
							Log::getSingleton( ).outString( "WORLD: Recieved CMSG_BUG [Suggestion]" );
						Log::getSingleton( ).outString( type.c_str( ) );
						Log::getSingleton( ).outString( content.c_str( ) );
					}break;
                case CMSG_JOIN_CHANNEL:
					{
                        char channelname[256];
                        recv_data >> channelname;
					    data.Initialise((strlen(channelname)+7), SMSG_CHANNEL_NOTIFY);
                        data << uint8(2);
                        data << channelname;
                        data << uint8(0);
                        data << uint32(1);
                        pClient->SendMsg( &data );
					}break;
    }
}
