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

///////////////////////////////////////////////
//  Admin Movement Commands
//

#include "Common.h"
#include "Database/DatabaseEnv.h"
#include "WorldPacket.h"
#include "WorldSession.h"
#include "World.h"
#include "ObjectMgr.h"
#include "Player.h"
#include "Item.h"
#include "GameObject.h"
#include "Opcodes.h"
#include "Chat.h"
#include "Log.h"
#include "Unit.h"


bool ChatHandler::HandleGUIDCommand(const char* args)
{
    WorldPacket data;

    uint64 guid;
    guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
        FillSystemMessageData(&data, m_session, "No selection.");
        m_session->SendPacket( &data );
        return true;
    }

    char buf[256];
    sprintf((char*)buf,"Object guid is: lowpart %u highpart %X", GUID_LOPART(guid), GUID_HIPART(guid));
    FillSystemMessageData(&data, m_session, buf);
    m_session->SendPacket( &data );

    return true;
}


bool ChatHandler::HandleNameCommand(const char* args)
{
    WorldPacket data;

    if(!*args)
        return false;

    if(strlen((char*)args)>75)
    {
        // send message to user
        char buf[256];
        sprintf((char*)buf,"The name was too long by %i", strlen((char*)args)-75);
        FillSystemMessageData(&data, m_session, buf);
        m_session->SendPacket( &data );
        return true;
    }

	for (int i = 0; i < strlen(args); i++) {
		if(!isalpha(args[i]) && args[i]!=' ') {
			FillSystemMessageData(&data, m_session, "Error, name can only contain chars A-Z and a-z.");
			m_session->SendPacket( &data );
			return false;
		}
	}

    uint64 guid;
    guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
        FillSystemMessageData(&data, m_session, "No selection.");
        m_session->SendPacket( &data );
        return true;
    }

    Creature * pCreature = objmgr.GetObject<Creature>(guid);
    if(!pCreature)
    {
        FillSystemMessageData(&data, m_session, "You should select a creature.");
        m_session->SendPacket( &data );
        return true;
    }

    pCreature->SetName(args);
    uint32 idname = objmgr.AddCreatureName(pCreature->GetName());
    pCreature->SetUInt32Value(OBJECT_FIELD_ENTRY, idname);

    pCreature->SaveToDB();

    return true;
}

bool ChatHandler::HandleSubNameCommand(const char* args)
{
    WorldPacket data;

	if(!*args)
		args = "";

    if(strlen((char*)args)>75)
    {
        // send message to user
        char buf[256];
        sprintf((char*)buf,"The subname was too long by %i", strlen((char*)args)-75);
        FillSystemMessageData(&data, m_session, buf);
        m_session->SendPacket( &data );
        return true;
    }

	for (int i = 0; i < strlen(args); i++) {
		if(!isalpha(args[i]) && args[i]!=' ') {
			FillSystemMessageData(&data, m_session, "Error, name can only contain chars A-Z and a-z.");
			m_session->SendPacket( &data );
			return false;
		}
	}
    uint64 guid;
    guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
        FillSystemMessageData(&data, m_session, "No selection.");
        m_session->SendPacket( &data );
        return true;
    }

    Creature * pCreature = objmgr.GetObject<Creature>(guid);
    if(!pCreature)
    {
        FillSystemMessageData(&data, m_session, "You should select a creature.");
        m_session->SendPacket( &data );
        return true;
    }

    uint32 idname = objmgr.AddCreatureSubName(pCreature->GetName(),args,pCreature->GetUInt32Value(UNIT_FIELD_DISPLAYID));
    pCreature->SetUInt32Value(OBJECT_FIELD_ENTRY, idname);

    pCreature->SaveToDB();

    return true;
}

bool ChatHandler::HandleItemMoveCommand(const char* args)
{
    uint8 srcslot, dstslot;

    char* pParam1 = strtok((char*)args, " ");
    if (!pParam1)
        return false;

    char* pParam2 = strtok(NULL, " ");
    if (!pParam2)
        return false;

    srcslot = (uint8)atoi(pParam1);
    dstslot = (uint8)atoi(pParam2);

    Item * dstitem = m_session->GetPlayer()->GetItemBySlot(dstslot);
    Item * srcitem = m_session->GetPlayer()->GetItemBySlot(srcslot);

    m_session->GetPlayer()->SwapItemSlots(srcslot, dstslot);

    return true;
}
/*
#define isalpha(c)  {isupper(c) || islower(c))
#define isupper(c)  (c >=  'A' && c <= 'Z')
#define islower(c)  (c >=  'a' && c <= 'z')
*/

bool ChatHandler::HandleSpawnEntryCommand(const char* args)
{

    WorldPacket data;
	std::stringstream sstext;

    char* pEntryID = strtok((char*)args, " ");
    if (!pEntryID)
        return false;

	uint32 EntryID  = atoi(pEntryID);
	CreatureSpawnTemplate *ct = objmgr.GetCreatureSpawnTemplate(EntryID);
	if(!ct)
	{
		sstext << "Creature Spawn Template '" << EntryID << "' Not Found" << '\0';
		FillSystemMessageData(&data, m_session, sstext.str().c_str());
		m_session->SendPacket( &data );
        return true;
	}

	sLog.outDebug("Spawning Creature Template '%u'", EntryID);
	sstext << "Spawning Creature using Template '" << EntryID << "'" << '\0';
	FillSystemMessageData(&data, m_session, sstext.str().c_str());
	m_session->SendPacket( &data );

	CreatureInfo *ci = objmgr.GetCreatureName(EntryID);

	// Create the requested monster
    Player *chr = m_session->GetPlayer();
    float x = chr->GetPositionX();
    float y = chr->GetPositionY();
    float z = chr->GetPositionZ();
    float o = chr->GetOrientation();

    Creature* pCreature = new Creature();

	pCreature->Create(objmgr.GenerateLowGuid(HIGHGUID_UNIT), ci->Name.c_str(), chr->GetMapId(), x, y, z, o);
	pCreature->SetZoneId(chr->GetZoneId());

	pCreature->SetUInt32Value(OBJECT_FIELD_ENTRY, ct->EntryID);
    pCreature->SetFloatValue(OBJECT_FIELD_SCALE_X, ct->Scale);
    pCreature->SetUInt32Value(UNIT_FIELD_DISPLAYID, ci->DisplayID);
	pCreature->SetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID, ci->DisplayID);
	pCreature->SetUInt32Value(UNIT_FIELD_MOUNTDISPLAYID, ct->MountModelID);
    pCreature->SetUInt32Value(UNIT_NPC_FLAGS, ct->Flag);
    pCreature->SetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE , ct->Faction);
    pCreature->SetUInt32Value(UNIT_FIELD_HEALTH, ct->MaxHealth);
    pCreature->SetUInt32Value(UNIT_FIELD_MAXHEALTH, ct->MaxHealth);
	pCreature->SetUInt32Value(UNIT_FIELD_RESISTANCES, ct->Armor);
	uint8 Race = 0;
	uint8 Class = 0;
	uint8 Gender = 0;
	uint8 PowerType = 0;
	if(ct->MaxMana == 0)
	{
		pCreature->SetUInt32Value(UNIT_FIELD_MAXPOWER4, 100);
		pCreature->SetUInt32Value(UNIT_FIELD_POWER4, 100);
		PowerType = 3;
	}
	else
	{
		pCreature->SetUInt32Value(UNIT_FIELD_MAXPOWER1, ct->MaxMana );
		pCreature->SetUInt32Value(UNIT_FIELD_POWER1, ct->MaxMana );
	}
	pCreature->SetUInt32Value(UNIT_FIELD_BYTES_0, ( ( Race ) | ( Class << 8 ) | ( Gender << 16 ) | ( PowerType << 24 ) ) );
    pCreature->SetUInt32Value(UNIT_FIELD_LEVEL, ct->Level );
    pCreature->SetFloatValue(UNIT_FIELD_COMBATREACH , ct->CombatReach);
	pCreature->SetFloatValue(UNIT_FIELD_BOUNDINGRADIUS , ct->BoundingRadius);
	pCreature->SetFloatValue(UNIT_FIELD_MINDAMAGE , ct->MinDamage);
	pCreature->SetFloatValue(UNIT_FIELD_MAXDAMAGE ,  ct->MaxDamage);
    pCreature->SetFloatValue(UNIT_FIELD_MINRANGEDDAMAGE , ct->MinRangedDamage);
	pCreature->SetFloatValue(UNIT_FIELD_MAXRANGEDDAMAGE , ct->MaxRangedDamage);

    pCreature->SetUInt32Value(UNIT_FIELD_BASEATTACKTIME, ct->BaseAttackTime);
    pCreature->SetUInt32Value(UNIT_FIELD_RANGEDATTACKTIME, ct->RangedAttackTime);

	if(ct->Slot1Model != 0)
	{
		pCreature->SetUInt32Value(UNIT_VIRTUAL_ITEM_SLOT_DISPLAY, ct->Slot1Model);
		pCreature->SetUInt32Value(UNIT_VIRTUAL_ITEM_INFO, ( ( uint8(ct->Slot1Info1) ) | ( uint8(ct->Slot1Info2) << 8 ) | ( uint8(ct->Slot1Info3) << 16 ) | ( uint8(ct->Slot1Info4) << 24 ) ) );
		pCreature->SetUInt32Value(UNIT_VIRTUAL_ITEM_INFO+1, ( ( uint8(ct->Slot1Info5) ) | ( uint8(0) << 8 ) | ( uint8(0) << 16 ) | ( uint8(0) << 24 ) ) );
	}
	if(ct->Slot2Model != 0)
	{
		pCreature->SetUInt32Value(UNIT_VIRTUAL_ITEM_SLOT_DISPLAY+1, ct->Slot2Model);
		pCreature->SetUInt32Value(UNIT_VIRTUAL_ITEM_INFO+2, ( ( uint8(ct->Slot2Info1) ) | ( uint8(ct->Slot2Info2) << 8 ) | ( uint8(ct->Slot2Info3) << 16 ) | ( uint8(ct->Slot2Info4) << 24 ) ) );
		pCreature->SetUInt32Value(UNIT_VIRTUAL_ITEM_INFO+3, ( ( uint8(ct->Slot2Info5) ) | ( uint8(0) << 8 ) | ( uint8(0) << 16 ) | ( uint8(0) << 24 ) ) );
	}
	if(ct->Slot3Model != 0)
	{
		pCreature->SetUInt32Value(UNIT_VIRTUAL_ITEM_SLOT_DISPLAY+2, ct->Slot3Model);
		pCreature->SetUInt32Value(UNIT_VIRTUAL_ITEM_INFO+4, ( ( uint8(ct->Slot3Info1) ) | ( uint8(ct->Slot3Info2) << 8 ) | ( uint8(ct->Slot3Info3) << 16 ) | ( uint8(ct->Slot3Info4) << 24 ) ) );
		pCreature->SetUInt32Value(UNIT_VIRTUAL_ITEM_INFO+5, ( ( uint8(ct->Slot3Info5) ) | ( uint8(0) << 8 ) | ( uint8(0) << 16 ) | ( uint8(0) << 24 ) ) );
	}

	//Trainer Templates
	Trainerspell *TrainSpell;
	std::stringstream sssql;
	sssql << "SELECT * FROM trainertemplate WHERE subname='" << ci->SubName << "'\0";
    QueryResult *result = sDatabase.Query(sssql.str().c_str());
	if(result)
    {
		sLog.outDebug("Trainer Template Exists");
		Field *fields = result->Fetch();
		
		TrainSpell = new Trainerspell;
		TrainSpell->Id = pCreature->GetGUIDLow();
		TrainSpell->skilline1 = fields[1].GetUInt32();
		TrainSpell->skilline2 = fields[2].GetUInt32();
		TrainSpell->skilline3 = fields[3].GetUInt32();
		//TrainSpell->maxlvl = fields[5].GetUInt32();
		TrainSpell->maxlvl = ct->Level;
		TrainSpell->charclass = fields[4].GetUInt32();
		objmgr.AddTrainerspell(TrainSpell);

		std::stringstream sssqlins;
		sssqlins << "INSERT INTO trainer (GUID, skillline1, skillline2,  skillline3, maxlvl, class) VALUES ("
				<< TrainSpell->Id << ", "
				<< TrainSpell->skilline1 << ", "
				<< TrainSpell->skilline2 << ", "
				<< TrainSpell->skilline3 << ", "
				<< TrainSpell->maxlvl << ", "
				<< TrainSpell->charclass << ")\0";
		sDatabase.Execute(sssqlins.str().c_str());
	}
	delete result;
	

	objmgr.AddObject(pCreature);
	pCreature->AddToWorld();
    pCreature->SaveToDB();
    return true;
}


bool ChatHandler::HandleSpawnCommand(const char* args)
{
    WorldPacket data;

    char* pEntry = strtok((char*)args, " ");
    if (!pEntry)
        return false;

/* Ignatich: not safe
    if (pEntry[1]=='x') {
        FillSystemMessageData(&data, m_session, "Please use decimal.");
        m_session->SendPacket( &data );
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

    if (display_id==0)
        return false;

	for (int i = 0; i < strlen(pName); i++) {
		if(!isalpha(pName[i]) && pName[i]!=' ') {
			FillSystemMessageData(&data, m_session, "Error, name can only contain chars A-Z and a-z.");
			m_session->SendPacket( &data );
			return false;
		}
	}
    SpawnCreature(m_session, pName, display_id, npcFlags, faction_id, level);

    return true;
}


bool ChatHandler::HandleDeleteCommand(const char* args)
{
    WorldPacket data;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
        FillSystemMessageData(&data, m_session, "No selection.");
        m_session->SendPacket( &data );
        return true;
    }

    Creature *unit = objmgr.GetObject<Creature>(guid);
    if(!unit)
    {
        FillSystemMessageData(&data, m_session, "You should select a creature.");
        m_session->SendPacket( &data );
        return true;
    }

    unit->RemoveFromWorld();

    unit->DeleteFromDB();

    objmgr.RemoveObject(unit);
    delete unit;

    return true;
}

bool ChatHandler::HandleDeMorphCommand(const char* args)
{
	Log::getSingleton().outError("Demorphed %s",m_session->GetPlayer()->GetName());
	m_session->GetPlayer()->DeMorph();
	return true;
}
/*bool ChatHandler::HandleSpawnTaxiCommand(const char* args)
{
    SpawnCreature(m_session, "Taxi", 20, 8, 1 , 1);

    return true;
}*/


bool ChatHandler::HandleItemCommand(const char* args)
{
    WorldPacket data;

    char* pitem = strtok((char*)args, " ");
    if (!pitem)
        return false;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
        FillSystemMessageData(&data, m_session, "No selection.");
        m_session->SendPacket( &data );
        return true;
    }

	Creature * pCreature = objmgr.GetCreature(guid);
    if(!pCreature)
    {
        FillSystemMessageData(&data, m_session, "You should select a creature.");
        m_session->SendPacket( &data );
        return true;
    }

    uint32 item = atoi(pitem);
    int amount = -1;

    char* pamount = strtok(NULL, " ");
    if (pamount)
        amount = atoi(pamount);

	ItemPrototype* tmpItem = objmgr.GetItemPrototype(item);

	std::stringstream sstext;
	if(tmpItem)
	{
		std::stringstream ss;
		ss << "INSERT INTO vendors VALUES ('" << pCreature->GetUInt32Value(OBJECT_FIELD_ENTRY) << "', '" << item << "', '" << amount << "')" << '\0';
		QueryResult *result = sDatabase.Query( ss.str().c_str() );

		uint8 itemscount = (uint8)pCreature->getItemCount();
	    pCreature->setItemId(itemscount , item);
	    pCreature->setItemAmount(itemscount , amount);
		pCreature->increaseItemCount();

		sstext << "Item '" << item << "' '" << tmpItem->Name1 << "' Added to list" << '\0';
	}
	else
	{
		sstext << "Item '" << item << "' Not Found in Database." << '\0';
	}

	FillSystemMessageData(&data, m_session, sstext.str().c_str());
	m_session->SendPacket( &data );

    return true;
}

bool ChatHandler::HandleItemRemoveCommand(const char* args)
{
    WorldPacket data;

    char* iguid = strtok((char*)args, " ");
    if (!iguid)
        return false;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
        FillSystemMessageData(&data, m_session, "No selection.");
        m_session->SendPacket( &data );
        return true;
    }

    Creature * pCreature = objmgr.GetCreature(guid);
    if(!pCreature)
    {
        FillSystemMessageData(&data, m_session, "You should select a creature.");
        m_session->SendPacket( &data );
        return true;
    }

    uint32 itemguid = atoi(iguid);
	int slot = pCreature->getItemSlotById(itemguid);

	std::stringstream sstext;
	if(slot != -1)
	{
		uint32 guidlow = GUID_LOPART(guid);

		std::stringstream ss;
	    ss << "DELETE FROM vendors WHERE vendorGuid = " << guidlow << " AND itemGuid = " << itemguid << '\0';
		QueryResult *delresult = sDatabase.Query( ss.str().c_str() );

		pCreature->setItemId(slot , 0);
		pCreature->setItemAmount(slot , 0);
		ItemPrototype* tmpItem = objmgr.GetItemPrototype(itemguid);
		if(tmpItem)
		{
			sstext << "Item '" << itemguid << "' '" << tmpItem->Name1 << "' Deleted from list" << '\0';
		}
		else
		{
			sstext << "Item '" << itemguid << "' Deleted from list" << '\0';
		}

	}
	else
	{
		sstext << "Item '" << itemguid << "' Not Found in List." << '\0';
	}

	FillSystemMessageData(&data, m_session, sstext.str().c_str());
	m_session->SendPacket( &data );

    return true;
}

bool ChatHandler::HandleRandomCommand(const char* args)
{
    WorldPacket data;

    if(!*args)
        return false;

    int option = atoi((char*)args);

    if (option != 0 && option != 1)
    {
        m_session->GetPlayer( )->SendMessageToSet( &data, true );
        FillSystemMessageData(&data, m_session, "Incorrect value, use 0 or 1");
        m_session->SendPacket( &data );
        return true;
    }

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
        FillSystemMessageData(&data, m_session, "No selection.");
        m_session->SendPacket( &data );
        return true;
    }

    Creature * pCreature = objmgr.GetObject<Creature>(guid);
    if(!pCreature)
    {
        FillSystemMessageData(&data, m_session, "You should select a creature.");
        m_session->SendPacket( &data );
        return true;
    }

    char sql[512];
    sprintf(sql, "UPDATE creatures SET moverandom = '%i' WHERE id = '%u'", option, GUID_LOPART(guid));
    sDatabase.Execute( sql );

    pCreature->GetAIInterface()->setMoveRandomFlag(option > 0);

    FillSystemMessageData(&data, m_session, "Value saved.");
    m_session->SendPacket( &data );

    return true;
}


bool ChatHandler::HandleRunCommand(const char* args)
{
    WorldPacket data;

    if(!*args)
        return false;

    int option = atoi((char*)args);

    if(option != 0 && option != 1)
    {
        m_session->GetPlayer( )->SendMessageToSet( &data, true );
        FillSystemMessageData(&data, m_session, "Incorrect value, use 0 or 1");
        m_session->SendPacket( &data );
        return true;
    }

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
        FillSystemMessageData(&data, m_session, "No selection.");
        m_session->SendPacket( &data );
        return true;
    }

    Creature * pCreature = objmgr.GetObject<Creature>(guid);
    if(!pCreature)
    {
        FillSystemMessageData(&data, m_session, "You should select a creature.");
        m_session->SendPacket( &data );
        return true;
    }

    char sql[512];

    sprintf(sql, "UPDATE creatures SET running = '%i' WHERE id = '%u'", option, GUID_LOPART(guid));
    sDatabase.Execute( sql );

    pCreature->GetAIInterface()->setMoveRunFlag(option > 0);

    FillSystemMessageData(&data, m_session, "Value saved.");
    m_session->SendPacket( &data );

    return true;
}


bool ChatHandler::HandleChangeLevelCommand(const char* args)
{
    WorldPacket data;

    if (!*args)
        return false;

    uint8 lvl = (uint8) atoi((char*)args);
    if ( lvl < 1 || lvl > 99)
    {
        FillSystemMessageData(&data, m_session, "Incorrect value.");
        m_session->SendPacket( &data );
        return true;
    }

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
        FillSystemMessageData(&data, m_session, "No selection.");
        m_session->SendPacket( &data );
        return true;
    }

    Creature * pCreature = objmgr.GetObject<Creature>(guid);
    if(!pCreature)
    {
        FillSystemMessageData(&data, m_session, "You should select a creature.");
        m_session->SendPacket( &data );
        return true;
    }

    pCreature->SetUInt32Value(UNIT_FIELD_HEALTH, 100 + 30*lvl);
    pCreature->SetUInt32Value(UNIT_FIELD_MAXHEALTH, 100 + 30*lvl);
    pCreature->SetUInt32Value(UNIT_FIELD_LEVEL , lvl);

    pCreature->SaveToDB();

    return true;
}


bool ChatHandler::HandleNPCFlagCommand(const char* args)
{
    WorldPacket data;

    if (!*args)
        return false;

    uint32 npcFlags = (uint32) atoi((char*)args);

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
        FillSystemMessageData(&data, m_session, "No selection.");
        m_session->SendPacket( &data );
        return true;
    }

    Creature * pCreature = objmgr.GetObject<Creature>(guid);
    if(!pCreature)
    {
        FillSystemMessageData(&data, m_session, "You should select a creature.");
        m_session->SendPacket( &data );
        return true;
    }

    pCreature->SetUInt32Value(UNIT_NPC_FLAGS , npcFlags);

    pCreature->SaveToDB();

    FillSystemMessageData(&data, m_session, "Value saved, you may need to rejoin or clean your client cache.");
    m_session->SendPacket( &data );

    return true;
}


bool ChatHandler::HandleDisplayIdCommand(const char* args)
{
    WorldPacket data;

    if (!*args)
        return false;

    uint32 displayId = (uint32) atoi((char*)args);

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
        FillSystemMessageData(&data, m_session, "No selection.");
        m_session->SendPacket( &data );
        return true;
    }

    Creature * pCreature = objmgr.GetObject<Creature>(guid);
    if(!pCreature)
    {
        FillSystemMessageData(&data, m_session, "You should select a creature.");
        m_session->SendPacket( &data );
        return true;
    }

    pCreature->SetUInt32Value(UNIT_FIELD_DISPLAYID, displayId);

    pCreature->SaveToDB();

    return true;
}


bool ChatHandler::HandleFactionIdCommand(const char* args)
{
    WorldPacket data;

    if (!*args)
        return false;

    uint32 factionId = (uint32) atoi((char*)args);

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
        FillSystemMessageData(&data, m_session, "No selection.");
        m_session->SendPacket( &data );
        return true;
    }

    Creature * pCreature = objmgr.GetObject<Creature>(guid);
    if(!pCreature)
    {
        FillSystemMessageData(&data, m_session, "You should select a creature.");
        m_session->SendPacket( &data );
        return true;
    }

    pCreature->SetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE , factionId);

    pCreature->SaveToDB();

    return true;
}

bool ChatHandler::HandleSaveAllCommand(const char *args)
{
    WorldPacket data;
    ObjectMgr::PlayerMap::const_iterator itr;
    for (itr = objmgr.Begin<Player>(); itr != objmgr.End<Player>(); itr++)
    {
        if(itr->second->GetSession())
        {
            itr->second->SaveToDB();
        }
    }

    FillSystemMessageData(&data, m_session, "All online players saved!");
    m_session->SendPacket( &data );
    return true;
}