////////////////////////////////////////////////////////////////////
//  Admin Movement Commands
//
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

#include "ChatHandler.h"
#include "NetworkInterface.h"
#include "GameClient.h"
#include "WorldServer.h"
#include "Character.h"
#include "Opcodes.h"
#include "Database.h"
#include "GameObject.h"

bool ChatHandler::HandleGUIDCommand(uint8* args)
{
	(void)args;
	NetworkPacket data;

	Unit * pUnit = getSelectedNPC();
	if(pUnit)
	{
		char buf[256];
		sprintf (buf,"Guid: %i\nSkin: %i\nFaction: %i\nFlag: %i\nAggressive: %i\n",
			 pUnit->getGUID ().sno, pUnit->getUpdateValue (UNIT_FIELD_DISPLAYID),
			 pUnit->getUpdateValue (UNIT_FIELD_FACTIONTEMPLATE),
			 pUnit->getUpdateValue(UNIT_NPC_FLAGS), pUnit->getAggressive ());
		SendMultilineMessage(buf);
	}

	return true;
}


bool ChatHandler::HandleNameCommand(uint8* args)
{
	NetworkPacket data;

	if(!*args)
		return false;

	if (strlen((char*)args) > 75)
	{
		uint8 buf[256];
		sprintf ((char*)buf, "The name was too long by %i",
			 strlen ((char*)args) - 75);
		FillMessageData (&data, 0x09, m_pClient, buf);
		m_pClient->SendMsg (&data);
		return true;
	}

	Unit * pUnit = getSelectedNPC ();
	if(pUnit)
	{
		pUnit->setCreatureName ((char*)args);
		uint32 idname = WORLDSERVER.addCreatureName ((uint8*)pUnit->getCreatureName ());
		ChangeSelectedNPC(OBJECT_FIELD_ENTRY, idname, 65535, 1);
	}
	return true;
}


bool ChatHandler::HandleProgCommand(uint8* args)
{
	(void)args;
	smsg_NewWorld(m_pClient, 0, 16843.00f, 16308.00f, 94.00f); //LINA

	return true;
}


bool ChatHandler::HandleItemMoveCommand(uint8* args)
{
	uint8 srcslot, destslot;

	char* pParam1 = strtok((char*)args, " ");
	if (!pParam1)
		return false;

	char* pParam2 = strtok(NULL, " ");
	if (!pParam2)
		return false;

	srcslot = (uint8)atoi(pParam1);
	destslot = (uint8)atoi(pParam2);

	m_pClient->getCurrentChar()->SwapItemInSlot((int)srcslot, (int)destslot);
	m_pClient->getCurrentChar ()->setUpdateValue (PLAYER_FIELD_INV_SLOT_HEAD  + (destslot*2), m_pClient->getCurrentChar()->getGuidBySlot(destslot));
	m_pClient->getCurrentChar ()->setUpdateValue (PLAYER_FIELD_INV_SLOT_HEAD  + (destslot*2)+1, m_pClient->getCurrentChar()->getGuidBySlot(destslot) == 0 ? 0 : 0x00000040);

	m_pClient->getCurrentChar ()->setUpdateValue (PLAYER_FIELD_INV_SLOT_HEAD  + (srcslot*2), m_pClient->getCurrentChar()->getGuidBySlot(srcslot));
	m_pClient->getCurrentChar ()->setUpdateValue (PLAYER_FIELD_INV_SLOT_HEAD  + (srcslot*2)+1, m_pClient->getCurrentChar()->getGuidBySlot(srcslot) == 0 ? 0 : 0x00000040);

	return true;
}


bool ChatHandler::HandleSpawnCommand(uint8* args)
{
	NetworkPacket data;

	char* pEntry = strtok((char*)args, " ");
	if (!pEntry)
		return false;

	/* Ignatich: not safe
	 if (pEntry[1]=='x') {
	 FillMessageData(&data, 0x09, m_pClient, (uint8*)"Please use decimal.");
	 m_pClient->SendMsg (&data);
	 return;
	 }
	 */
	char* pFlags = strtok(NULL, " ");
	if (!pFlags)
		return false;

	char* pFaction = strtok(NULL, " ");
	if (!pFaction)
		return false;

	char* pLevel = strtok(NULL, " ");
	if (!pLevel)
		return false;

	char* pName = strtok(NULL, "%");
	if (!pName)
		return false;

	uint32 npcFlags  = atoi(pFlags);
	uint32 faction_id  = atoi(pFaction);
	uint32 level  = atoi(pLevel);
	uint32 display_id = atoi(pEntry);

	SpawnCreature(m_pClient, pName, display_id, npcFlags, faction_id, level);

	return true;
}


bool ChatHandler::HandleDeleteCommand (uint8* args)
{
	(void)args;
	NetworkPacket data;

	Unit *pUnit = getSelectedNPC ();
	if(pUnit)
	{
		guid uguid = pUnit->getGUID();

		data.Clear();
		data.Initialize(8, SMSG_DESTROY_OBJECT);
		data << uguid.sno << uguid.type;
		m_pClient->getCurrentChar()->SendMessageToSet (&data, true);

		std::map<uint32, Unit*>::iterator itr = WORLDSERVER.mCreatures.find (uguid.sno);

		for (WorldServer::CharacterMap::iterator iter = WORLDSERVER.mCharacters.begin (); iter != WORLDSERVER.mCharacters.end (); ++ iter)
			iter->second->RemoveInRangeObject (itr->second);

		delete itr->second;
		WORLDSERVER.mCreatures.erase(itr);

		DatabaseInterface *dbi = DATABASE.createDatabaseInterface ();
		char sql [512];
		sprintf(sql, "DELETE FROM creatures WHERE id=%u", uguid.sno);
		dbi->doQuery (sql);
		sprintf(sql, "DELETE FROM creatures_mov WHERE creatureId=%u", uguid.sno);
		dbi->doQuery (sql);
		sprintf(sql, "DELETE FROM vendors WHERE vendorGuid=%u", uguid.sno);
		dbi->doQuery (sql);
		sprintf(sql, "DELETE FROM trainers WHERE trainerGuid=%u", uguid.sno);
		dbi->doQuery (sql);
		sprintf(sql, "DELETE FROM creaturequestrelation WHERE creatureId=%u", uguid.sno);
		dbi->doQuery (sql);
		DATABASE.removeDatabaseInterface(dbi);
	}
	return true;
}


bool ChatHandler::HandleSpellCommand(uint8* args)
{
	NetworkPacket data;

	char* pspell = strtok((char*)args, " ");
	if (!pspell)
		return false;

	char* pprice = strtok(NULL, " ");
	if (!pprice)
		return false;

	uint32 spell = atoi(pspell);
	uint32 price = atoi(pprice);

	if(price <= 0)
	{
		FillMessageData(&data, 0x09, m_pClient, (uint8*)"Incorrect price.");
		m_pClient->SendMsg (&data);
		return true;
	}

	Unit * pUnit = getSelectedNPC();
	if(pUnit)
	{
		guid uguid = pUnit->getGUID ();

		DatabaseInterface *dbi = DATABASE.createDatabaseInterface();
		guid gspell (spell);
		dbi->addTrainerSpell (uguid, gspell, price); //add spell to trainer
		DATABASE.removeDatabaseInterface (dbi); //clean up

		uint8 buf[256];
		sprintf ((char*)buf,"Spell %u added into trainers %u", spell, pUnit->getGUID().sno);
		FillMessageData(&data, 0x09, m_pClient, buf);
		m_pClient->SendMsg (&data);
	}

	return true;
}


bool ChatHandler::HandleSpawnTaxiCommand(uint8* args)
{
	(void)args;
	SpawnCreature(m_pClient, "Taxi", 20, 8, 1 , 1);

	return true;
}


bool ChatHandler::HandleItemCommand (uint8 *args)
{
	NetworkPacket data;

	char* pitem = strtok((char*)args, " ");
	if (!pitem)
		return false;

	Unit * pUnit = getSelectedNPC();
	if(pUnit)
	{
		guid uguid = pUnit->getGUID();

		uint32 item = atoi (pitem);;
		uint32 amount = 1;

		char* pamount = strtok(NULL, " ");
		if (pamount) amount = atoi(pamount);

		DatabaseInterface *dbi = DATABASE.createDatabaseInterface ();

		char sql[512];
		sprintf (sql, "insert into vendors values ('%u', '%u', '%u')",
			 uguid.sno, item, amount);
		dbi->doQuery(sql);

		std::map<uint32, Unit*>::iterator itr = WORLDSERVER.mCreatures.find (uguid.sno);
		itr->second->setItemId(itr->second->getItemCount() , (int)item);
		itr->second->setItemAmount(itr->second->getItemCount() , (int)amount);
		itr->second->increaseItemCount();

		sprintf(sql,"Item %u added into vendors %u",
			item, pUnit->getGUID().sno);
		FillMessageData(&data, 0x09, m_pClient, (uint8*)sql);
		m_pClient->SendMsg (&data);
	}
	return true;
}


bool ChatHandler::HandleAddMoveCommand(uint8* args)
{
	(void)args;
	NetworkPacket data;

	Unit * pUnit = getSelectedNPC();
	if(pUnit)
	{
		guid uguid = pUnit->getGUID();

		DatabaseInterface *dbi = DATABASE.createDatabaseInterface ();
		char sql[512];

		if(!pUnit->hasWaypoints())
		{
			sprintf(sql, "insert into creatures_mov (creatureId,X,Y,Z) values ('%u', '%g', '%g', '%g')",
				uguid.sno,
				pUnit->getPositionX (),
				pUnit->getPositionY (),
				pUnit->getPositionZ ());
			dbi->doQuery (sql);

			pUnit->addWaypoint(pUnit->getPositionX(), pUnit->getPositionY(), pUnit->getPositionZ());
		}

		if (!pUnit->addWaypoint(m_pClient->getCurrentChar()->getPositionX(),
					m_pClient->getCurrentChar()->getPositionY(),
					m_pClient->getCurrentChar()->getPositionZ()))
		{
			FillMessageData(&data, 0x09, m_pClient, (uint8*)"You have allready set all points.");
			m_pClient->SendMsg (&data);

			DATABASE.removeDatabaseInterface(dbi);
			return true;
		}

		sprintf(sql, "insert into creatures_mov (creatureId,X,Y,Z) values ('%u', '%f', '%f', '%f')",
			uguid.sno,
			m_pClient->getCurrentChar()->getPositionX(),
			m_pClient->getCurrentChar()->getPositionY(),
			m_pClient->getCurrentChar()->getPositionZ());

		dbi->doQuery(sql);

		DATABASE.removeDatabaseInterface(dbi);

		uint8 syntaxError[] = "Waypoint added.";
		FillMessageData(&data, 0x09, m_pClient, syntaxError);
		m_pClient->SendMsg (&data);
	}

	return true;
}


bool ChatHandler::HandleRandomCommand(uint8* args)
{
	NetworkPacket data;

	if(!*args)
		return false;

	int option = atoi((char*)args);

	if (option != 0 && option != 1)
	{
		m_pClient->getCurrentChar ()->SendMessageToSet (&data, true);
		FillMessageData(&data, 0x09, m_pClient, (uint8*)"Incorrect value, use 0 or 1");
		m_pClient->SendMsg (&data);
		return true;
	}

	Unit * pUnit = getSelectedNPC();
	if(pUnit)
	{
		DatabaseInterface *dbi = DATABASE.createDatabaseInterface ();
		char sql[512];
		sprintf(sql, "update creatures set moverandom = '%i' where id = '%u'",
			option, pUnit->getGUID().sno);
		dbi->doQuery(sql);
		DATABASE.removeDatabaseInterface(dbi);

		pUnit->setMoveRandomFlag(option > 0);

		FillMessageData(&data, 0x09, m_pClient, (uint8*)"NPC Updated.");
		m_pClient->SendMsg (&data);
	}

	return true;
}


bool ChatHandler::HandleRunCommand(uint8* args)
{
	NetworkPacket data;

	if(!*args)
		return false;

	int option = atoi((char*)args);

	if(option != 0 && option != 1)
	{
		m_pClient->getCurrentChar ()->SendMessageToSet (&data, true);
		FillMessageData(&data, 0x09, m_pClient, (uint8*)"Incorrect value, use 0 or 1");
		m_pClient->SendMsg (&data);
		return true;
	}

	Unit * pUnit = getSelectedNPC();
	if(pUnit)
	{
		DatabaseInterface *dbi = DATABASE.createDatabaseInterface ();
		char sql[512];
		sprintf(sql, "update creatures set running = '%i' where id = '%u'",
			option, pUnit->getGUID().sno);
		dbi->doQuery(sql);
		DATABASE.removeDatabaseInterface(dbi);

		pUnit->setMoveRunFlag(option > 0);

		FillMessageData(&data, 0x09, m_pClient, (uint8*)"NPC Updated.");
		m_pClient->SendMsg (&data);
	}
	return true;
}

//LINA
bool ChatHandler::HandleAggressiveCommand(uint8* args)
{
	NetworkPacket data;

	if(!*args)
		return false;

	int option = atoi((char*)args);

	if(option < 0 || option > 3)
	{
		m_pClient->getCurrentChar ()->SendMessageToSet (&data, true);
		FillMessageData(&data, 0x09, m_pClient, (uint8*)"Incorrect value, use 0, 1, 2, 3");
		m_pClient->SendMsg (&data);
		return true;
	}

	Unit * pUnit = getSelectedNPC();
	if(pUnit)
	{
		DatabaseInterface *dbi = DATABASE.createDatabaseInterface ();
		char sql[512];
		sprintf(sql, "update creatures set aggressive = '%i' where id = '%u'",
			option, pUnit->getGUID().sno);
		dbi->doQuery(sql);
		DATABASE.removeDatabaseInterface(dbi);

		pUnit->setAggressive(option);

		FillMessageData(&data, 0x09, m_pClient, (uint8*)"NPC Updated.");
		m_pClient->SendMsg (&data);
	}
	return true;
}

bool ChatHandler::HandleChangeLevelCommand(uint8* args)
{
	NetworkPacket data;

	if (!*args)
		return false;

	uint8 Arg = (uint8) atoi((char*)args);

	Unit * pUnit = getSelectedNPC();
	if(pUnit!=NULL)
	{
		float fLevel = (float)Arg;
		pUnit->setUpdateValue(UNIT_FIELD_MAXHEALTH, (uint32)((1.24*fLevel*fLevel)+(1.79*fLevel)+40.64));
		pUnit->setUpdateValue(UNIT_FIELD_HEALTH, (uint32)((1.24*fLevel*fLevel)+(1.79*fLevel)+40.64));
		pUnit->setUpdateFloatValue(UNIT_FIELD_MINDAMAGE ,  4.0f+fLevel);
		pUnit->setUpdateFloatValue(UNIT_FIELD_MAXDAMAGE , 4.0f+fLevel+fLevel);
	}
	ChangeSelectedNPC(UNIT_FIELD_LEVEL, Arg, 255, 1);

	return true;
}


bool ChatHandler::HandleNPCFlagCommand(uint8* args)
{
	NetworkPacket data;

	if (!*args)
		return false;

	uint32 Arg = (uint32) atoi((char*)args);

	ChangeSelectedNPC(UNIT_NPC_FLAGS, Arg, 2048, 0);
	return true;
}


bool ChatHandler::HandleDisplayIdCommand(uint8* args)
{
	NetworkPacket data;

	if (!*args)
		return false;

	uint32 Arg = (uint32) atoi((char*)args);
	ChangeSelectedNPC(UNIT_FIELD_DISPLAYID, Arg, 8192, 1);
	return true;
}


bool ChatHandler::HandleFactionIdCommand(uint8* args)
{
	NetworkPacket data;

	if (!*args)
		return false;

	uint32 Arg = (uint32) atoi((char*)args);
	ChangeSelectedNPC(UNIT_FIELD_FACTIONTEMPLATE, Arg, 32, 0);
	return true;
}


bool ChatHandler::HandleRemoveSpellCommand(uint8* args)
{
	NetworkPacket data;

	char* pspell = strtok((char*)args, " ");
	if (!pspell)
		return false;

	uint32 spell = atoi(pspell);

	Unit * pUnit = getSelectedNPC();
	if(pUnit)
	{
		uint8 buf[256];
		sprintf((char*)buf,"delete from trainers where (trainerGuid='%i') AND (spellGuid='%i')",
			pUnit->getGUID().sno, spell);
		FillMessageData(&data, 0x09, m_pClient, buf);
		m_pClient->SendMsg (&data);

		sprintf((char*)buf,"Spell %u removed from vendors %u",
			spell, pUnit->getGUID().sno);
		FillMessageData(&data, 0x09, m_pClient, buf);
		m_pClient->SendMsg (&data);
	}
	return true;
}

bool ChatHandler::HandleRemoveItemCommand(uint8* args)
{
	NetworkPacket data;

	char* pitem = strtok((char*)args, " ");
	if (!pitem)
		return false;

	uint32 item = atoi(pitem);

	Unit * pUnit = getSelectedNPC();
	if(pUnit)
	{
		uint8 buf[256];
		sprintf((char*)buf,"delete from vendord where (vendorGuid='%u') AND (itemGuid='%u')",
			pUnit->getGUID().sno, item);
		FillMessageData(&data, 0x09, m_pClient, buf);
		m_pClient->SendMsg (&data);

		sprintf((char*)buf,"Item %u removed from vendors %u",
			item, pUnit->getGUID().sno);
		FillMessageData(&data, 0x09, m_pClient, buf);
		m_pClient->SendMsg (&data);
	}
	return true;
}
