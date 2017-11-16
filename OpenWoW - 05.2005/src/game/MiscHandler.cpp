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
#include "version.h"

MiscHandler::MiscHandler (){}
MiscHandler::~MiscHandler (){}

void MiscHandler::HandleMsg (NetworkPacket & recv_data, GameClient *pClient)
{
	NetworkPacket data;
	char f[256];
	typedef std::map< uint32, Unit*> CreatureMap;
	CreatureMap mCreatures;
	sprintf(f, "WORLD: Misc Opcode 0x%.4X", recv_data.opcode);
	LOG.outString (f);
	Socket *net = pClient->getNetwork();
	switch (recv_data.opcode)
	{
	case CMSG_REPOP_REQUEST:
		{
			LOG.outString ("WORLD: Recvd CMSG_REPOP_REQUEST Message");

			//						printf("updates\n");
			pClient->getCurrentChar ()->setUpdateValue (UNIT_FIELD_HEALTH, 1);
			//						printf("updated\n");

			//pClient->getCurrentChar ()->UpdateObject();

			float x,y,z;
			uint16 mapID;
			x = pClient->getCurrentChar()->getPositionX();
			y = pClient->getCurrentChar()->getPositionY();
			z = pClient->getCurrentChar()->getPositionZ();
			mapID = pClient->getCurrentChar()->getMapId();
			WorldServer::getSingletonPtr ()->dbi->getClosestSpiritHealer(x,y,z,mapID);
			NetworkPacket data;

			pClient->getCurrentChar()->TeleportAck(&data, x,y,z);
			pClient->SendMsg(&data);
			//						pClient->getCurrentChar()->BuildHeartBeat(&data);
			//						WORLDSERVER.SendGlobalMessage(&data, pClient);

			/*/START OF LINA TEMP DEATH FIX
			Character * pChar = pClient->getCurrentChar();
			pChar->m_deathTimer = 0;
			pChar->setDeathState(ALIVE);
			pChar->m_respawnTimer = 0;

			UpdateMask mask;
			NetworkPacket data;
			WorldServer::getSingletonPtr()->mObjectMgr.SetCreateUnitBits(mask);
			uint32 max_health = pChar->getUpdateValue(UNIT_FIELD_MAXHEALTH);
			pChar->setUpdateValue(UNIT_FIELD_HEALTH, max_health);

			//maybe tale some xp away?
			//pClient->getCurrentChar ()->setUpdateValue (UNIT_FIELD_FLAGS, 8);
			pChar->setUpdateValue (UNIT_FIELD_FLAGS, (0xffffffff - 65536) & pChar->getUpdateValue (UNIT_FIELD_FLAGS));
			pChar->setUpdateValue (UNIT_FIELD_AURA +32, 0);
			pChar->setUpdateValue (UNIT_FIELD_AURAFLAGS +4, 0);
			pChar->setUpdateValue (UNIT_FIELD_AURASTATE, 0);
			//pClient->getCurrentChar ()->setUpdateValue (PLAYER_BYTES_2, 16777984);
			pChar->setUpdateValue (PLAYER_BYTES_2, (0xffffffff - 0x10) & pClient->getCurrentChar ()->getUpdateValue (PLAYER_BYTES_2));
			//setDeathState(ALIVE);

			uint8 buf[256];

			uint32 xp = pChar->getUpdateValue(PLAYER_XP);
			uint32 xpt = (uint32) (200 * pChar->getLevel() * pow(pChar->getLevel(),1.2));
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
			WORLDSERVER.mChatHandler.FillMessageData(&data, 0x09, pClient, buf);
			pClient->SendMsg (&data);
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
			WORLDSERVER.mChatHandler.FillMessageData(&data, 0x09, pClient, buf);
			pClient->SendMsg (&data);
			printf("Take Gold %i, so %i\n", moneyt, newmoney);
			//END OF LINA TEMP DEATH FIX */
			break;
		}

	case CMSG_AUTOSTORE_LOOT_ITEM:
		{
			int i,slot = 0;
			uint32 itemid;
			uint8 lootSlot;
			//std::map<uint32, Unit*>::iterator itr = WORLDSERVER.mCreatures.find(pClient->getCurrentChar()->getLootGUID());
			//mCreatures.find
			Unit* pVictim = WORLDSERVER.GetCreature (pClient->getCurrentChar ()->getLootGUID ().sno);

			if (pVictim == NULL)
				return;

			recv_data >> lootSlot;
			//printf("lootslot = %u",lootSlot);
			lootSlot -=1; //to prevent Slot 0 from been use "Still Rolling for item fix"
			for(i = 23; i <= 38; i++)
			{
				if (pClient->getCurrentChar()->getGuidBySlot(i) == 0) {
					slot = i;
					break;
				}
			}

			if (slot == 0)
			{//Our User doesn't have a free Slot in there bag
				ChatHandler pChat;
				pChat.FillMessageData(&data, 0x09, pClient, (uint8*)"You have no free space in your Backpack !!!");
				pClient->SendMsg(&data);
				data.Clear();
				return;
			}

			//if (pVictim->getItemAmount(lootSlot) == 0) //Can't sell the item for cash
			//	return; //maybe whine a bit too?

			WORLDSERVER.m_hiItemGuid++;
			itemid = pVictim->getItemId(lootSlot);
			pVictim->setItemAmount(lootSlot, 0);

			pClient->getCurrentChar()->AddItemToSlot(slot,WORLDSERVER.m_hiItemGuid,itemid);

			WORLDSERVER.mItemHandler.createItemUpdate(&data, pClient, slot);
			pClient->SendMsg (&data);

			UpdateMask updateMask;
			updateMask.SetLength (PLAYER_FIELDS);
			pClient->getCurrentChar ()->setUpdateValue (
				PLAYER_FIELD_INV_SLOT_HEAD  + (slot*2),
				pClient->getCurrentChar()->getGuidBySlot(slot),
				updateMask.data);
			pClient->getCurrentChar ()->setUpdateValue (
				PLAYER_FIELD_INV_SLOT_HEAD  + (slot*2)+1,
				pClient->getCurrentChar()->getGuidBySlot(slot) == 0 ? 0 : 0x00000040,
				updateMask.data);
			pClient->getCurrentChar ()->UpdateObject (&updateMask, &data);
			pClient->SendMsg (&data);

			data.Initialize(1 , SMSG_LOOT_REMOVED);
			data << uint8(lootSlot+1);
			pClient->SendMsg (&data);
			break;
		}
	case CMSG_LOOT_MONEY:
		{
			UpdateMask updateMask;
			updateMask.SetLength (PLAYER_FIELDS);
			uint32 newcoinage = 0;
			Unit* pVictim = WORLDSERVER.GetCreature (pClient->getCurrentChar ()->getLootGUID ().sno);
			//std::map<uint32, Unit*>::iterator itr = WORLDSERVER.mCreatures.find(pClient->getCurrentChar()->getLootGUID());
			if (pVictim == NULL)
				return;

			newcoinage = pClient->getCurrentChar()->getUpdateValue(PLAYER_FIELD_COINAGE) + pVictim->getLootMoney();
			pVictim->setLootMoney(0);
			pClient->getCurrentChar()->setUpdateValue (PLAYER_FIELD_COINAGE , newcoinage);
			break;
		}
	case CMSG_LOOT:
		{
			guid lguid;
			//uint16 tmpDataLen;
			uint16 ItemsCount = 0;
			uint8 i;
			uint8 tmpItemsCount = 0;
			//Item *tmpLootItem;
			recv_data >> lguid.sno >> lguid.type;

			//std::map<uint32, Unit*>::iterator itr =
			Unit* pVictim = WORLDSERVER.GetCreature (lguid.sno); //.mCreatures.find(guid1);
			if (pVictim == NULL)
			{
				ChatHandler pChat;
				pChat.FillMessageData (&data, 0x09, pClient, (uint8*)"You can't Loot thin air !!!");
				pClient->SendMsg (&data);
				data.Clear ();
				return;
			}

			pClient->getCurrentChar ()->setLootGUID (lguid);

			for (i = 0; i <= pVictim->getItemCount () ; i++)
				if (pVictim->getItemAmount (i) > 0)
					tmpItemsCount++;

			//printf("Unit Item Count %i\n",itr->second->getItemCount());
			//printf("Unit Item Count %i\n",tmpItemsCount);
			//set items got to 1 untill we find out how to make the packet properly


			/*
			 tmpDataLen = 14 + tmpItemsCount*21;
			 data.Initialize(tmpDataLen, SMSG_LOOT_RESPONSE);
			 data << guid1;
			 data << guid2;
			 data << uint8(0x02);
			 data << uint32(itr->second->getLootMoney());
			 data << uint8(tmpItemsCount);//itr->second->getItemCount()
			 for(i = 0 ; i<tmpItemsCount; i++) { //itr->second->getItemCount()
			 //tmpLootItem = WORLDSERVER.GetItem(itr->second->getItemId((int)i));
			 if (itr->second->getItemAmount((int)i) > 0) {
			 data << uint8(i); //Item Slot
			 printf("Item Slot = %i\n",i);
			 printf("Item Slot = 0x%.4X\n",i);
			 data << uint32(itr->second->getItemId((int)i));
			 printf("Unit Item GUID %i\n",itr->second->getItemId((int)i));
			 printf("Unit Item GUID 0x%.4X\n",itr->second->getItemId((int)i));
			 data << uint32(1); //itr->second->getItemAmount((int)i) //no of items maybe??
			 data << uint32(WORLDSERVER.GetItem(itr->second->getItemId((int)i))->DisplayInfoID);
			 printf("Unit Item Display ID %i\n",WORLDSERVER.GetItem(itr->second->getItemId((int)i))->DisplayInfoID);
			 printf("Unit Item Display ID 0x%.4X\n",WORLDSERVER.GetItem(itr->second->getItemId((int)i))->DisplayInfoID);
			 //printf("Unit Item Display ID %i\n",uint32(itr->second->getItemId((int)i))->DisplayInfoID));
			 //data << uint8(0);
			 data << uint32(0) << uint32(0);
			 }
			 }
			 */
			/*
			 if (tmpItemsCount > 1) tmpItemsCount = 1;

			 //tmpDataLen = 14 + tmpItemsCount*21;
			 tmpDataLen = 1000;
			 data.Initialize(tmpDataLen, SMSG_LOOT_RESPONSE);
			 data << guid1;
			 data << guid2;
			 // 0 =  Premission Deined | 1 = 4 = 5 = 2 = Death | 3 = Fishing
			 data << uint8(0x05); //Loot Type Flag
			 data << uint32(itr->second->getLootMoney());
			 data << uint8(1); //items Total Count
			 data << uint8(1); //Item Slot
			 data << guid(2072); //Item Guid
			 data << uint32(1);
			 data << uint32(878); //Displayid
			 data << uint8(2); //Item Slot
			 data << uint32(3013); //Item Guid
			 data << uint32(1);
			 data << uint32(6409); //Displayid
			 */

			ItemsCount = pVictim->getItemCount();
			//printf(" %i Items Total but Found %i Items",ItemsCount,tmpItemsCount);

			data.Initialize(14 + (22 * tmpItemsCount), SMSG_LOOT_RESPONSE);
			data << lguid.sno;
			data << lguid.type;
			data << uint8 (1); //loot Type
			data << uint32 (pVictim->getLootMoney()); //Loot gold
			data << uint8 (tmpItemsCount); //Item Count
			for(i = 0 ; i < tmpItemsCount; i++)
			{
				if (pVictim->getItemAmount((int)i) > 0)
				{
					data << uint8(i+1); //Item Slot
					data << uint32(pVictim->getItemId((int)i)); //Item Guid
					//data << uint16(2072); //Item Guid
					//data << uint16(0); //spacer
					data << uint32(pVictim->getItemAmount((int)i)); //quantity
					data << uint32(WORLDSERVER.GetItem(pVictim->getItemId((int)i))->DisplayInfoID); //Display IconID
					//data << uint16(878); //Display IconID
					//data << uint16(0); //spacer
					data << uint8(0); //spacer
					data << uint32(0); //spacer
					data << uint32(0); //spacer
				}
			}

			/*
			 data << uint8(2); //Item Slot
			 data << uint32(5572); //Item Guid
			 //data << uint16(5572); //Item Guid
			 //data << uint16(0); //spacer
			 data << uint32(1); //quantity
			 data << uint32(1277); //Display IconID
			 //data << uint16(1277); //Display IconID
			 //data << uint16(0); //spacer
			 data << uint32(0); //spacer
			 data << uint32(0); //spacer
			 */
			/*
			 data << uint8(2); //Item Slot
			 data << uint16(5572); //Item Guid
			 data << uint16(0); //spacer
			 data << uint32(1); //quantity
			 data << uint16(1277); //Display IconID
			 data << uint16(0); //spacer
			 data << uint32(0); //spacer
			 data << uint32(0); //spacer
			 */

			/*
			 for(i = 0 ; i<tmpItemsCount; i++) { //itr->second->getItemCount()
			 //tmpLootItem = WORLDSERVER.GetItem(itr->second->getItemId((int)i));
			 if (itr->second->getItemAmount((int)i) > 0) {
			 data << uint8(i); //Item Slot
			 printf("Item Slot = %i\n",i);
			 printf("Item Slot = 0x%.4X\n",i);
			 data << uint32(itr->second->getItemId((int)i));
			 printf("Unit Item GUID %i\n",itr->second->getItemId((int)i));
			 printf("Unit Item GUID 0x%.4X\n",itr->second->getItemId((int)i));
			 data << uint32(1); //itr->second->getItemAmount((int)i) //no of items maybe??
			 data << uint32(WORLDSERVER.GetItem(itr->second->getItemId((int)i))->DisplayInfoID);
			 printf("Unit Item Display ID %i\n",WORLDSERVER.GetItem(itr->second->getItemId((int)i))->DisplayInfoID);
			 printf("Unit Item Display ID 0x%.4X\n",WORLDSERVER.GetItem(itr->second->getItemId((int)i))->DisplayInfoID);
			 //printf("Unit Item Display ID %i\n",uint32(itr->second->getItemId((int)i))->DisplayInfoID));
			 //data << uint8(0);
			 data << uint32(0) << uint32(0);
			 }
			 }
			 */

			pClient->SendMsg(&data);
			//net->sendWData (&data);
			//printf("Loot Sent...\n");
			break;
		}
	case CMSG_LOOT_RELEASE:
		{
			guid lguid;
			pClient->getCurrentChar()->setLootGUID (guid ());
			recv_data >> lguid.sno >> lguid.type;
			data.Initialize (9, SMSG_LOOT_RELEASE_RESPONSE);
			data << lguid.sno << lguid.type << uint8 (1);
			net->sendWData (&data, (SrpWorld*)(pClient));
			break;
		}
	case CMSG_WHO:
		{
			uint64 clientcount = 0;
			int datalen = 8;
			uint countcheck = 0;
			LOG.outString ("WORLD: Recvd CMSG_WHO Message");


			WorldServer::ClientSet::iterator itr;
			for (itr = WORLDSERVER.mClients.begin(); itr != WORLDSERVER.mClients.end(); itr++)

			{
				if (((GameClient*)(*itr))->getCharacterName()) {
					clientcount++;
					datalen = datalen + strlen(((GameClient*)(*itr))->getCharacterName()) + 1 + strlen(((GameClient*)(*itr))->getCurrentChar()->getGuildName()) + 1 + 21;
				}
			}

			data.Clear();
			data.Initialize(datalen, SMSG_WHO);
			data << uint64 (clientcount);
			for (itr = WORLDSERVER.mClients.begin(); itr != WORLDSERVER.mClients.end(); itr++)

			{
				if (((((GameClient *)(*itr))->getCharacterName ()) &&
				     (((GameClient *)(*itr))->IsInWorld ())) &&
				    (countcheck < clientcount))
				{
					countcheck++;
					data.WriteData (((GameClient *)(*itr))->getCurrentChar()->getName(),
							strlen(((GameClient*)(*itr))->getCurrentChar()->getName()));
					data << uint8 (0x00);

					if(!strcmp(((GameClient*)(*itr))->getCurrentChar()->getGuildName(), ""))

						data.WriteData("",0);

					else

						data.WriteData(((GameClient*)(*itr))->getCurrentChar()->getGuildName()) , strlen(((GameClient*)(*itr))->getCurrentChar()->getGuildName());

					data << uint8 (0x00);
					data << uint32 (((GameClient*)(*itr))->getCurrentChar()->getLevel());
					data << uint32 (((GameClient*)(*itr))->getCurrentChar()->getClass());
					data << uint32 (((GameClient*)(*itr))->getCurrentChar()->getRace());
					data << uint32 (((GameClient*)(*itr))->getCurrentChar()->getZone());

					if(((GameClient*)(*itr))->getCurrentChar()->IsInGroup())
					{
						data << uint32 (0x00000001); //group
					}
					else
					{
						data << uint32 (0x00000000);
					}
				}
			}
			pClient->SendMsg(&data);
			break;
		}

	case CMSG_LOGOUT_REQUEST:
		{

			LOG.outString ("WORLD: Recvd CMSG_LOGOUT_REQUEST Message");
			if(pClient->getCurrentChar()->m_state && UF_ATTACKING)

			{

				ChatHandler pChat;

				pChat.FillMessageData(&data, 0x09, pClient, (uint8*)"You can't logout in fight !!!");

				pClient->SendMsg(&data);

				data.Clear();

				data.Initialize (5, SMSG_LOGOUT_RESPONSE);

				data << uint32(0); //Filler

				data << uint8(1); //Logout rejected

			}

			else

			{

				data.Clear();

				data.Initialize (5, SMSG_LOGOUT_RESPONSE);

				data << uint32(0); //Filler

				data << uint8(0); //Logout accepted

				pClient->LogoutRequest(time(NULL));

			}



			net->sendWData (&data, (SrpWorld*)(pClient));

			break;
		}

	case CMSG_PLAYER_LOGOUT:
		{
			LOG.outString ("WORLD: Recvd CMSG_PLAYER_LOGOUT Message");

			data.Clear();
			data.length = 0;
			data.data = new uint8 [data.length];
			data.opcode = SMSG_LOGOUT_COMPLETE;
			net->sendWData (&data, (SrpWorld*)(pClient));

			WORLDSERVER.LogoutPlayer(pClient);

			LOG.outString ("WORLD: sent SMSG_LOGOUT_COMPLETE Message");
			break;
		}

	case CMSG_LOGOUT_CANCEL:
		{
			LOG.outString ("WORLD: Recvd CMSG_LOGOUT_CANCEL Message");

			pClient->LogoutRequest(0);

			data.Clear();
			data.length = 0;
			data.data = new uint8 [data.length];
			data.opcode = SMSG_LOGOUT_CANCEL_ACK;
			net->sendWData (&data, (SrpWorld*)(pClient));

			LOG.outString ("WORLD: sent SMSG_LOGOUT_CANCEL_ACK Message");
			break;
		}

	case CMSG_PING:
		{
			LOG.outString ("WORLD: Recvd CMSG_PING Message");
			uint32 ping;
			memcpy(&ping, recv_data.data, 4);
			data.Clear();
			data.Initialize (4, SMSG_PONG);
			data << ping;
			net->sendWData (&data, (SrpWorld*)(pClient));
			LOG.outString ("WORLD: sent SMSG_PONG Message");
			break;
		}

	case CMSG_GMTICKET_GETTICKET:
		{
			data.Initialize (10, SMSG_GMTICKET_GETTICKET);
			data << uint32(6);
			data << uint32(0xffbfbfbf);
			data << uint8(0);
			data << uint8(3);
			net->sendWData (&data, (SrpWorld*)(pClient));
			break;
		}

	case CMSG_GMTICKET_CREATE:
		{
			//TODO: Receive message sent and relay it to an online GM
			data.Initialize (4, SMSG_GMTICKET_CREATE);
			data << uint32(2);
			net->sendWData (&data, (SrpWorld*)(pClient));
			break;
		}

	case CMSG_GMTICKET_SYSTEMSTATUS:
		{
			//TODO: Receive message sent and relay it to an online GM
			data.Initialize (4, SMSG_GMTICKET_SYSTEMSTATUS);
			data << uint32(1);
			net->sendWData (&data, (SrpWorld*)(pClient));
			break;
		}

	case CMSG_ZONEUPDATE:
		{
			uint32 newZone,oldZone;
			char output[50];
			recv_data.ReadData(newZone);
			oldZone = pClient->getCurrentChar ()->getZone();
			if (oldZone == newZone)
				return;

			sprintf(output, "WORLD: Recvd ZONE_UPDATE: %u\n", newZone);
			LOG.outString (output);

			//Setting new zone
			if (pClient->getCurrentChar ())
			{
				pClient->getCurrentChar()->setZone((uint16)newZone);
				//printf("Zone Update from %u to %u", oldZone, newZone);
			}
			break;
		}

	case CMSG_SET_ACTION_BUTTON:
		{
		LOG.outString( "WORLD: Recieved CMSG_SET_ACTION_BUTTON" ); 
		uint8 button, misc, type; 
        uint16 action; 
        recv_data >> button >> action >> misc >> type; 
        printf("BUTTON: %x ACTION: %x TYPE: %x MISC: %x \n", button, action, type, misc); 
        if(action==0)
			{
			printf("MISC: Remove action from button %i\n", button); 
			//remove the action button from the db
			pClient->getCurrentChar()->removeAction(button);
			}
		else 
			{ 
			if(type==0x40) 
				{ 
				printf("MISC: Macro %i into button %i\n", action, button); 
				pClient->getCurrentChar()->addAction(button,action,misc,type); 
				} 
			else if(type==0x0) 
				{ 
				printf("MISC: Add Action %i into button %i\n", action, button); 
				pClient->getCurrentChar()->addAction(button,action,type,misc); 
				} 
			} 
	}break;
/*

	case CMSG_PET_SET_ACTION:
		{
			LOG.outString ("WORLD: Recieved CMSG_PET_SET_ACTION");
			uint8 val;
			int i=0;
			for (int size = recv_data.length ; i < size ; i++)
			{
				recv_data >> val;
				printf("%i|%x\n",val);
			}
			//pClient->getCurrentChar()->addAction(button,action,type,misc);
			break;
		}break;
		*/
//#endif

	case CMSG_AREATRIGGER:
		{
			uint32 AreaTriggerID;
			recv_data >> AreaTriggerID;
			
			printf("AreaTrigger %u ",AreaTriggerID);
			AreaTrigger *Trigger;
			DatabaseInterface *dbi = DATABASE.createDatabaseInterface();
			Trigger = dbi->getAreaTriggerInformation(AreaTriggerID);
			if(Trigger->m_TargetTriggerID == 0)
				{
					DATABASE.removeDatabaseInterface (dbi); //clean up used resources
					break;
				}
			AreaTrigger *TargetTrigger;
			TargetTrigger = dbi->getAreaTriggerInformation(Trigger->m_TargetTriggerID);

			printf("From MapID: %i X: %f Y: %f Z: %f O: %f\n",Trigger->m_MapID, Trigger->m_X, Trigger->m_Y, Trigger->m_Z, Trigger->m_O);
			printf("AreaTrigger %u ",TargetTrigger->m_AreaTriggerID);
			printf("To MapID: %i X: %f Y: %f Z: %f O: %f\n",TargetTrigger->m_MapID, TargetTrigger->m_X, TargetTrigger->m_Y, TargetTrigger->m_Z, TargetTrigger->m_O);
			//pClient->getCurrentChar()->setWorldPort(true);

			NetworkPacket data;
			WorldServer::CreatureMap creatures = WORLDSERVER.getCreatureMap();
			WorldServer::CharacterMap characters = WORLDSERVER.getCharacterMap();
			data.Initialize(4, SMSG_TRANSFER_PENDING);
			data << uint32(8);
			pClient->SendMsg(&data);

			// Build a NEW WORLD packet
			data.Initialize(20, SMSG_NEW_WORLD);
			data << (uint32)TargetTrigger->m_MapID << (float)TargetTrigger->m_X << (float)TargetTrigger->m_Y << (float)TargetTrigger->m_Z << (float)TargetTrigger->m_O;
			pClient->SendMsg (&data);

			// Destroy ourselves from other clients
			guid pguid = pClient->getCurrentChar()->getGUID ();
			data.Initialize(8, SMSG_DESTROY_OBJECT);
			data << pguid.sno << pguid.type;
			pClient->getCurrentChar()->SendMessageToSet(&data, true);

			// Remove ourselves from inrange lists
			for (WorldServer::CharacterMap::iterator iter = characters.begin (); iter != characters.end (); ++ iter)
				iter->second->RemoveInRangeObject (pClient->getCurrentChar());
			for (WorldServer::CreatureMap::iterator iter = creatures.begin (); iter != creatures.end (); ++ iter)
				iter->second->RemoveInRangeObject (pClient->getCurrentChar());
			
			pClient->getCurrentChar()->ClearInRangeSet();
			pClient->getCurrentChar()->setMapId(TargetTrigger->m_MapID);
			pClient->getCurrentChar()->setNewPosition(TargetTrigger->m_X,TargetTrigger->m_Y,TargetTrigger->m_Z);
			pClient->getCurrentChar()->setPosition(TargetTrigger->m_X,TargetTrigger->m_Y,TargetTrigger->m_Z,TargetTrigger->m_O,true);
			DATABASE.removeDatabaseInterface (dbi); //clean up used resources
		}break;

	case CMSG_PLAYER_LOGIN:
		{
			LOG.outString ("WORLD: Recvd Player Logon Message");
			uint32 player_guid=0;

			memcpy(&player_guid, recv_data.data, 4); //This is the GUID selected by the player
			pClient->setCurrentChar(pClient->getCurrentChar (player_guid));

			Character *pCurrChar = pClient->getCurrentChar ();
			pClient->setLogged ();
			WORLDSERVER.dbi->loadQuestStatus (pCurrChar);

			data.Initialize (80, SMSG_ACCOUNT_DATA_MD5);
			memset(data.data, 0, 80);
			pClient->SendMsg(&data);

			// MOTD
			//const uint8 msgchat_header_size=13;
			//uint8 msgchat_header[msgchat_header_size] =
			//{ 0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

			uint8 msgchat_info[256];
			uint8 msgchat_info_size=0;
			sprintf((char*)msgchat_info, SITW "\nServer Engine: %s\nNumber of users connected: %i/%i\n",
				XVERSION, (int)WORLDSERVER.GetClientsConnected (), WORLDSERVER.GetClientLimit ());
			for(; msgchat_info [msgchat_info_size] != 0; msgchat_info_size++)
				;

			// FIXME
			/*data.Initialize(WORLDSERVER.motd_size + msgchat_header_size + msgchat_info_size + 1, SMSG_MESSAGECHAT);
			 memcpy(data.data, msgchat_header, msgchat_header_size);
			 memcpy(data.data+msgchat_header_size, msgchat_info, msgchat_info_size);
			 memcpy(data.data+msgchat_header_size+msgchat_info_size, WORLDSERVER.motd, WORLDSERVER.motd_size);
			 data.data[WORLDSERVER.motd_size + msgchat_header_size + msgchat_info_size]=0; //Yeah, it looks like there must be two 0 at the end of the string
			 pClient->SendMsg (&data);
			 LOG.outString ("WORLD: Sent motd (SMSG_MESSAGECHAT)"); */


			//data.Initialize(4, SMSG_SET_REST_START);
			//data << unsure;
			//pClient->SendMsg(&data);

			//Tutorial Flags
			data.Initialize(32, SMSG_TUTORIAL_FLAGS);
			memset(data.data, 0xff, 32);
			pClient->SendMsg(&data);
			LOG.outString ("WORLD: Sent tutorial flags.");

			//Initial Spells
			pCurrChar->smsg_InitialSpells();

			//START OF LINA ACTION BAR

			//Initial Action Buttons

			pCurrChar->smsg_InitialActions();

			//END OF LINA ACTION BAR

			// SMSG_INITIALIZE_FACTIONS

			// SMSG_EXPLORATION_EXPERIENCE

			// SMSG_CAST_RESULT -- Spell_id = 836 (LOGINEFFECT (24347)) From spells.dbc.csv

			data.Initialize(8, SMSG_LOGIN_SETTIMESPEED);
			uint32 minutes = WORLDSERVER.updateGameTime () / 60;
			uint32 hours = minutes / 60; minutes %= 60;
			uint32 gameTime = minutes + (hours << 6);
			data << (uint32)gameTime;
			data << (float)0.017f;	// Normal Game Speed
			pClient->SendMsg (&data);

			// SMSG_UPDATE_AURA_DURATION -- if the player had an aura on when he logged out

			// Bojangles has Been up in here :0 Cinematics working Just need
			// the sound flags to kick off sound.
			// doesnt check yet if its the first login to run. *YET*
			// WantedMan fixed so it will only start if you are at starting loc

			// temp disabling this - joker
			/*
			 if (WORLDSERVER.GetCinematics ())
			 {
			 data.Initialize (4, SMSG_TRIGGER_CINEMATIC);
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
			 pClient->SendMsg (&data);
			 }
			 }
			 if (theRace == 2) // Orc
			 {
			 if (xLoc == -618.518f)
			 if (yLoc == -4251.67f)
			 if (zLoc == 38.718f)

			 {
			 data << uint32(21);
			 pClient->SendMsg (&data);
			 }
			 }
			 if (theRace == 3) // Dwarf
			 {
			 if (xLoc == -6240.32f)
			 if (yLoc == 331.033f)
			 if (zLoc == 382.758f)

			 {
			 data << uint32(41);
			 pClient->SendMsg (&data);
			 }
			 }
			 if (theRace == 4) // Night Elves
			 {
			 if (xLoc == 10311.3f)
			 if (yLoc == 832.463f)
			 if (zLoc == 1326.41f)

			 {
			 data << uint32(61);
			 pClient->SendMsg (&data);
			 }
			 }
			 if (theRace == 5) // undead <-- WORKING thats Correct
			 {
			 if (xLoc == 1676.35f)
			 if (yLoc == 1677.45f)
			 if (zLoc == 121.67f)

			 {
			 data << uint32(2);
			 pClient->SendMsg (&data);
			 }
			 }
			 if (theRace == 6) // Tauren
			 {
			 if (xLoc == -2917.58f)
			 if (yLoc == -257.98f)
			 if (zLoc == 52.9968f)

			 {
			 data << uint32(141);
			 pClient->SendMsg (&data);
			 }
			 }
			 if (theRace == 7) // Gnome
			 {
			 if (xLoc == -6240.32f)
			 if (yLoc == 331.033f)
			 if (zLoc == 382.758f)

			 {
			 data << uint32(101);
			 pClient->SendMsg (&data);
			 }
			 }
			 if (theRace == 8) // Troll
			 {
			 if (xLoc == -618.518f)
			 if (yLoc == -4251.67f)
			 if (zLoc == 38.718f)

			 {
			 data << uint32(121);
			 pClient->SendMsg (&data);
			 }
			 }
			 if (WORLDSERVER.GetStartZone == 1)
			 {
			 if (xLoc == -8897.50f)
			 if (yLoc == -173.480f)
			 if (zLoc == 81.5775f)

			 {
			 if (theRace == 2) // Orc
			 {
			 data << uint32(81);
			 pClient->SendMsg (&data);
			 }
			 if (theRace == 3) // Dwarf
			 {
			 data << uint32(81);
			 pClient->SendMsg (&data);
			 }
			 if (theRace == 4) // Night Elves
			 {
			 data << uint32(81);
			 pClient->SendMsg (&data);
			 }
			 if (theRace == 5) // undead
			 {
			 data << uint32(81);
			 pClient->SendMsg (&data);
			 }
			 if (theRace == 6) // Tauren
			 {
			 data << uint32(81);
			 pClient->SendMsg (&data);
			 }
			 if (theRace == 7) // Gnome
			 {
			 data << uint32(81);
			 pClient->SendMsg (&data);
			 }
			 if (theRace == 8) // Troll
			 {
			 data << uint32(81);
			 pClient->SendMsg (&data);
			 }
			 }
			 }
			 }*/



			//SEND EXTRA STAT/VALUES

			//Talent points

			pCurrChar->setUpdateValue (PLAYER_CHARACTER_POINTS1,
						   pCurrChar->getUpdateValue (PLAYER_CHARACTER_POINTS1));


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
				pCurrChar->setUpdateValue (PLAYER_BYTES_2, newbytes);
			} else {
				uint32 newbytes = pCurrChar->getUpdateValue(PLAYER_BYTES_2) & ~(0x8);
				pCurrChar->setUpdateValue (PLAYER_BYTES_2, newbytes);
			}

			//======================================================================================
			//  Create Player Character

			WORLDSERVER.mObjectMgr.BuildAndSendCreatePlayer(pCurrChar, 1, NULL);
			LOG.outString ("WORLD: Created Player Character");

			// Add character to the ingame list
			// And let this client know we're in game
			pClient->InWorld(true);
			WORLDSERVER.mCharacters [pCurrChar->getGUID().sno] = pCurrChar;

			// Build the in-range set
			WORLDSERVER.CheckForInRangeObjects(pCurrChar);

			//=======================================================================================
			// Send a message to other Clients that a new player has entered the world

			// FIXME: I R BROKEN! - Joker
			/*std::list<NetworkPacket*> msglist;
			WORLDSERVER.mObjectMgr.BuildCreatePlayerMsg(pCurrChar, &msglist, 0);

			std::list<NetworkPacket*>::iterator msgitr;
			for (msgitr = msglist.begin(); msgitr != msglist.end();)
			{
				NetworkPacket *msg = (*msgitr);
				pClient->getCurrentChar()->SendMessageToSet(msg, false);
				delete msg;
				msgitr = msglist.erase(msgitr);
			}*/

			LOG.outString ("WORLD: Created new player for existing players");

			// Creation of existing creatures and players moved to UpdateInRangeSet(), where only objects close enough
			// are created
			/*
			 LOG.outString ("WORLD: Creating creatures...");
			 for (WorldServer::CreatureMap::iterator i = WORLDSERVER.mCreatures.begin (); i != WORLDSERVER.mCreatures.end (); ++ i) {
			 if (pClient->getCurrentChar()->getZone() != i->second->getZone())
			 continue;
			 data.Clear();
			 UpdateMask unitMask;
			 WorldServer::getSingletonPtr()->mObjectMgr.SetCreateUnitBits(unitMask);

			 i->second->SendCreateWithTempNpcFlags(&unitMask, pClient);
			 i->second->clearUpdateMask();
			 }
			 */

			printf("%s\n",pClient->getCharacterName ());
			std::string outstring = pClient->getCharacterName ();
			outstring.append (" has entered the world.");
			WORLDSERVER.SendWorldText ((uint8*)outstring.c_str ());

			break;
		}

	case CMSG_SET_TARGET:
		{

			LOG.outString ("WORLD: Recieved CMSG_SET_TARGET");
			guid tguid;
			recv_data >> tguid.sno >> tguid.type;
			if (pClient->getCurrentChar () != 0)
				pClient->getCurrentChar ()->m_curTarget = tguid;
			break;
		}

	case CMSG_SET_SELECTION:
		{
			LOG.outString ("WORLD: Recieved CMSG_SET_SELECTION");

			/*if the current character is not invalid get the creature or NPC they have selected*/
			if (pClient->getCurrentChar () != 0)
			{
				guid sguid;
				recv_data >> sguid.sno >> sguid.type;
				pClient->getCurrentChar ()->m_curSelection = sguid;
			}

			Unit *pUnit = WORLDSERVER.GetCreature(pClient->getCurrentChar ()->m_curSelection.sno);

			/*if the object is a Creature*/
			if (pClient->getCurrentChar ()->m_curSelection.type == 0xF0001000)
			{
				/*if they Dead and still in the world*/
				if(pClient->getCurrentChar()->getDeathState() == ALIVE || pClient->getCurrentChar()->getDeathState() == CORPSE || pClient->getCurrentChar()->getDeathState() == JUST_DIED || pClient->getCurrentChar()->getDeathState() == DEAD)
				{
					/*if the creature they selected is a spirit healer*/
					if(pUnit->getUpdateValue(UNIT_NPC_FLAGS) == 32)
					{
						/*Spirit Healer only work here how dumb lol*/
						LOG.outString ("Spirit Healer! ");
						uint16 tSize;
						tSize = 47;
						data.Initialize (tSize, SMSG_GOSSIP_MESSAGE);
						tSize = 0;
						data << pClient->getCurrentChar ()->m_curSelection.sno << pClient->getCurrentChar ()->m_curSelection.type;
						data << (uint32)1; //text ID //Spirit Healers text
						data << (uint32)0x00000001; //BulletPoint Count
						data <<	(uint32)0x00000000; //Option Number
						data << (uint32)0x00000004; //Option Icon
						//Option Text
						data << (uint8)0x52;
						data << (uint32)0x72757465;
						data << (uint32)0x656D206e;
						data << (uint32)0x206F7420;
						data << (uint32)0x6566696c;
						data << (uint8)0x2e;
						data << (uint8)0x00;
						data << (uint32)0;
						pClient->SendMsg (&data);
					}
				}
				// Island Teleporters
				if (pUnit->getUpdateValue(UNIT_NPC_FLAGS) == 25 ||
				    pUnit->getUpdateValue(UNIT_NPC_FLAGS) == 21)
				{
					uint16 c;
					float x;
					float y;
					float z;

					switch (pUnit->getUpdateValue(UNIT_NPC_FLAGS))
					{
					case 21:
						//To Eastern Kingdoms
						c = 0;
						x = -3767.00f;
						y = -654.00f;
						z = 8.4f;
						break;
					case 25:
						//To Kalimdor
						c = 1;
						x = -997.00f;
						y = -3822.00f;
						z = 5.5f;
						break;
					default:
						return;
					}
					//pClient->getCurrentChar()->setWorldPort(true);

					NetworkPacket data;
					WorldServer::CreatureMap creatures = WORLDSERVER.getCreatureMap();
					WorldServer::CharacterMap characters = WORLDSERVER.getCharacterMap();
					data.Initialize(4, SMSG_TRANSFER_PENDING);
					data << uint32(0);
					pClient->SendMsg(&data);
					// Build a NEW WORLD packet
					data.Initialize(20, SMSG_NEW_WORLD);
					data << (uint32)c << (float)x << (float)y << (float)z << (float)0.0f;
					pClient->SendMsg (&data);
					// Destroy ourselves from other clients
					guid pguid = pClient->getCurrentChar()->getGUID ();
					data.Initialize(8, SMSG_DESTROY_OBJECT);
					data << pguid.sno << pguid.type;
					pClient->getCurrentChar()->SendMessageToSet(&data, true);
					// Remove ourselves from inrange lists
					for (WorldServer::CharacterMap::iterator iter = characters.begin (); iter != characters.end (); ++ iter)
						iter->second->RemoveInRangeObject (pClient->getCurrentChar());
					for (WorldServer::CreatureMap::iterator iter = creatures.begin (); iter != creatures.end (); ++ iter)
						iter->second->RemoveInRangeObject (pClient->getCurrentChar());
					pClient->getCurrentChar()->ClearInRangeSet();
					pClient->getCurrentChar()->setMapId(c);
					pClient->getCurrentChar()->setNewPosition(x,y,z);
					pClient->getCurrentChar()->setPosition(x,y,z,0,true);
				}
			}
			/*printf("TARGET NPC FLAGS = %u\n", pUnit->getUpdateValue(UNIT_NPC_FLAGS));*/
			break;
		}

#if 0
		// Joker- Needs updating to 1.2.1, crashes server
	case CMSG_STANDSTATECHANGE:
		{
			if (pClient->getCurrentChar () != 0) {
				// retrieve current BYTES
				uint32 bytes1 = pClient->getCurrentChar ()->getUpdateValue (UNIT_FIELD_BYTES_1);
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

				//data.Initialize (0, SMSG_STANDSTATE_CHANGE_FAILURE);
				//net->sendWData (&data);
				//SMSG_STANDSTATE_CHANGE_FAILURE
				//SMSG_STANDSTATE_CHANGE_ACK
				uint32 newbytes = (bytes[0]) + (bytes[1]<<8) + (bytes[2]<<16) + (bytes[3]<<24);
				pClient->getCurrentChar ()->setUpdateValue(UNIT_FIELD_BYTES_1 , newbytes);
			}
			break;
		}
#endif

		// Friends related
#if 0
	case CMSG_NAME_QUERY:
		 {
			 LOG.outString ("WORLD: Recieved CMSG_NAME_QUERY" );



			 uint64 GUID=0;
			 recv_data >> GUID;
			 char tmpBuf[2156];
			 sprintf (tmpBuf, "WORLD: %s name querried : '%d'", pClient->getCharacterName (), GUID);
			 LOG.outString (tmpBuf);


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
			 data.Clear();
			 data.opcode =SMSG_FRIEND_STATUS;
			 data.length=sizeof(FriendResult) + sizeof(FriendGUID);
			 data.data= new uint8 [data.length];
			 data <<  FriendResult << FriendGUID;
			 net->sendWData (&data);

			 LOG.outString ("WORLD: Sent motd (SMSG_FRIEND_STATUS)");

                         break;
		 }
#endif
	case CMSG_FRIEND_LIST:
		{
			char tmpBuf[2156];

			LOG.outString ("WORLD: Recieved CMSG_FRIEND_LIST" );

			unsigned char Counter=0;
			//int datalen = 8;
			//int countcheck = 0;
			//int CharCheck = 0;
			uint charguid;
			int i;
			SocialData *pSdata;
			FriendData *pFriend;

			DatabaseInterface *dbi = DATABASE.createDatabaseInterface();
			pSdata = dbi->getFriendList(pClient->getCurrentChar()->getGUID().sno);

			pFriend = new FriendData[pSdata->pArraySize];

			WorldServer::ClientSet::iterator itr;
			for(i=0; i < pSdata->pArraySize; i++)
			{
				for (itr = WORLDSERVER.mClients.begin(); itr != WORLDSERVER.mClients.end(); itr++) {
					if (((GameClient*)(*itr))->IsInWorld())
						charguid = ((GameClient*)(*itr))->getCurrentChar()->getGUID().sno;
					else
						charguid = 0;
					if (((((GameClient *)(*itr))->getCharacterName()) &&
					     (pSdata->pSudata[i].guid == charguid) &&
					     (((GameClient*)(*itr))->IsInWorld())))
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

			data.Clear();
			data.opcode = SMSG_FRIEND_LIST;
			data.length=sizeof(Counter) + (Counter * sizeof(FriendData));
			data.data= new uint8[data.length];

			data << Counter;

			for (int j=0; j<Counter; j++) {
				sprintf(tmpBuf, "Adding Friend - Guid:%d, Status:%d, Area:%d, Level:%d Class:%d",
					(int)pFriend[j].pGuid, (int)pFriend[j].Status,
					(int)pFriend[j].Area, pFriend[j].Level,pFriend[j].Class);
				LOG.outString (tmpBuf );
				pFriend[j].Status = char(pFriend[j].tmpStatus);

				data << pFriend[j].pGuid << pFriend[j].Status ;
				if (pFriend[j].Status != 0)
					data << pFriend[j].Area << pFriend[j].Level << pFriend[j].Class;
			}

			net->sendWData (&data, (SrpWorld*)(pClient));

			LOG.outString ("WORLD: Sent (SMSG_FRIEND_LIST)");
			DATABASE.removeDatabaseInterface (dbi); //clean up used resources
			break;
		}

	case CMSG_ADD_FRIEND:
		{
			LOG.outString ("WORLD: Recieved CMSG_ADD_FRIEND" );

			char FriendName[2048]="UNKNOWN";
			recv_data >> FriendName;

			char tmpBuf[2156];
			sprintf (tmpBuf, "WORLD: %s asked to add friend : '%s'", pClient->getCharacterName (), FriendName);
			LOG.outString (tmpBuf);

			unsigned char FriendResult = FRIEND_NOT_FOUND;
			unsigned char FriendStatus;
			uint friendGuid = 0;
			uint32 FriendArea=0;
			uint32 FriendLevel=0;
			uint32 FriendClass=0;
			int i;
			SocialData *pSdata;
			ChatHandler pChat;

			DatabaseInterface *dbi = DATABASE.createDatabaseInterface();

			pSdata = dbi->getFriendList (pClient->getCurrentChar()->getGUID().sno);

			uint tmpguid = pClient->getDB()->GetNameGUID (FriendName);

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
						pClient->SendMsg (&data);

					}
				}
				if (FriendResult != FRIEND_ALREADY)
				{
					friendGuid = tmpguid;
					if (WORLDSERVER.mCharacters.find ((uint32)friendGuid) != WORLDSERVER.mCharacters.end ())
					{
						FriendResult = FRIEND_ADDED_ONLINE;
						Character *pChar = WORLDSERVER.mCharacters[tmpguid];
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
					sprintf (tmpBuf, "WORLD: %s Guid found '%u' area:%d Level:%d Class:%d. ",
						 FriendName, friendGuid, FriendArea,FriendLevel,FriendClass);
					LOG.outString (tmpBuf);
					if (!strcmp(pClient->getCharacterName(),FriendName))
						FriendResult = FRIEND_SELF;
					else
						dbi->AddFriend (pClient->getCurrentChar()->getGUID ().sno ,friendGuid ,FriendName);
				}
			}
			else
			{
				sprintf (tmpBuf, "WORLD: %s Guid not found ", FriendName);
				LOG.outString (tmpBuf);
			}

			// Send reposnse.
			data.Clear();
			data.opcode =SMSG_FRIEND_STATUS;
			if (FriendResult ==  FRIEND_ADDED_ONLINE || FriendResult == FRIEND_ONLINE ||
			    FriendResult ==  FRIEND_OFFLINE
			    //|| FriendResult ==  FRIEND_ADDED_OFFLINE
			   )
			{
				data.length=sizeof(FriendResult) + sizeof(friendGuid) + sizeof(FriendStatus) + sizeof(FriendArea)
					+ sizeof(FriendLevel) +  sizeof(FriendClass);
				data.data= new uint8 [data.length];
				data <<  FriendResult << friendGuid;
				data <<  FriendArea << FriendLevel << FriendClass;
			}
			else
			{
				data.length=sizeof(FriendResult) + sizeof(friendGuid);
				data.data= new uint8 [data.length];
				data <<  FriendResult << friendGuid;
			}

			net->sendWData (&data, (SrpWorld*)(pClient));

			LOG.outString ("WORLD: Sent (SMSG_FRIEND_STATUS)");
			DATABASE.removeDatabaseInterface (dbi); //clean up used resources
			break;
		}
	case CMSG_DEL_FRIEND:
		{
			LOG.outString ("WORLD: Recieved CMSG_DEL_FRIEND" );

			uint32 FriendGUID;
			recv_data >> FriendGUID;
			char tmpBuf[2156];
			sprintf (tmpBuf, "WORLD: %s asked to Remove friend : %u",
				 pClient->getCharacterName (), FriendGUID);
			LOG.outString (tmpBuf);

			DatabaseInterface *dbi = DATABASE.createDatabaseInterface();

			unsigned char FriendResult = FRIEND_REMOVED;

			dbi->RemoveFriend (pClient->getCurrentChar ()->getGUID ().sno, FriendGUID);

			// Send reposnse.
			data.Clear();
			data.opcode =SMSG_FRIEND_STATUS;
			data.length=sizeof(FriendResult) + sizeof(FriendGUID);
			data.data= new uint8 [data.length];
			data <<  FriendResult << FriendGUID;
			net->sendWData (&data, (SrpWorld*)(pClient));

			LOG.outString ("WORLD: Sent motd (SMSG_FRIEND_STATUS)");
			DATABASE.removeDatabaseInterface (dbi); //clean up used resources
			break;
		}
	case CMSG_BUG:
		{
			uint32 suggestion, contentlen;
			std::string content;
			uint32 typelen;
			std::string type;
			recv_data >> suggestion >> contentlen >> content >> typelen >> type;
			if (suggestion == 0)
				LOG.outString ("WORLD: Recieved CMSG_BUG [Bug Report]");
			else
				LOG.outString ("WORLD: Recieved CMSG_BUG [Suggestion]");
			LOG.outString (type.c_str ());
			LOG.outString (content.c_str ());
			break;
		}
	case CMSG_JOIN_CHANNEL:
		{
			char channelname[256];
			recv_data >> channelname;
			data.Initialize((strlen(channelname)+7), SMSG_CHANNEL_NOTIFY);
			data << uint8(2);
			data << channelname;
			data << uint8(0);
			data << uint32(1);
			pClient->SendMsg (&data);
			break;
		}

	default:
		break;
	}
}
