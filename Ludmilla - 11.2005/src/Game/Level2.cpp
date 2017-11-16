#include "StdAfx.h"

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

//-----------------------------------------------------------------------------
bool ChatHandler::Command_NPC_GUID (const char* args)
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

//-----------------------------------------------------------------------------
/*bool ChatHandler::Command_NPC_Name (const char* args)
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
}*/

/*
bool ChatHandler::HandleProgCommand(const char* args)
{
    smsg_NewWorld(m_session, 451, 16391.80f, 16341.20f, 69.44f);

    return true;
}
*/

//-----------------------------------------------------------------------------
bool ChatHandler::HandleItemMoveCommand(const char* args)
{
    uint8 srcslot, dstslot;

    char* pParam1 = strtok((char*)args, " ");
    if (!pParam1)
        return false;

    char* pParam2 = strtok(NULL, " ");
    if (!pParam2)
        return false;

    srcslot = (uint8)hex_or_decimal(pParam1);
    dstslot = (uint8)hex_or_decimal(pParam2);

    Item * dstitem = m_session->GetPlayer()->GetItemBySlot(dstslot);
    Item * srcitem = m_session->GetPlayer()->GetItemBySlot(srcslot);

    m_session->GetPlayer()->SwapItemSlots(srcslot, dstslot);

    return true;
}

//-----------------------------------------------------------------------------
/*bool ChatHandler::Command_NPC_Spawn (const char* args)
{
    WorldPacket data;

    char* pEntry = strtok((char*)args, " ");
    if (!pEntry)
        return false;

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

    SpawnCreature (m_session, pName, display_id, npcFlags, faction_id, level);

    return true;
}
*/
//-----------------------------------------------------------------------------
bool ChatHandler::Command_NPC_Add (const char* args)
{
	WorldPacket data;

	uint32 Entry = hex_or_decimal ((char*)args);
	if (!Entry)
		return false;

	//SpawnCreature (m_session, pName, display_id, npcFlags, faction_id, level);
	
	CreatureTemplate *ct = objmgr.GetCreatureTemplate (Entry, false);
	if (ct != NULL) {
		SpawnCreature (m_session, ct);
	} else {
		m_session->SystemMessage ("Can't spawn creature %d, template doesn't exist");
	}

	return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_NPC_Delete (const char* args)
{
	// Just in case, clear waypoint indicators
	Command_WP_Hide (NULL);

    WorldPacket data;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
		m_session->SystemMessage ("No selection.");
        return true;
    }

    Creature *unit = objmgr.GetObject<Creature>(guid);
    if(!unit)
    {
		m_session->SystemMessage ("No selection.");
        return true;
    }

	data.Initialize (SMSG_DESTROY_OBJECT);
	data << unit->GetGUID();
	unit->SendMessageToSet (&data, true);

	//for (ObjectSet::iterator it = unit->GetInRangeSetBegin(); it != unit->GetInRangeSetEnd(); it++)
	//Object *o;
	//for (MapRangeIterator it (unit); o = it.Advance(); )
	//	o->RemoveInRangeObject (unit);
	
	if (unit->GetMapCell()) {
		unit->GetMapCell()->RemoveObject (unit);
//		unit->GetMapCell()->RemoveInactive (unit);
	}
	
	unit->RemoveFromMap();
	unit->RemoveFromWorld();

    unit->DeleteFromDB();

    objmgr.RemoveObject_Free(unit);
    //delete unit;

    return true;
}


/*bool ChatHandler::HandleSpawnTaxiCommand(const char* args)
{
    SpawnCreature(m_session, "Taxi", 20, 8, 1 , 1);

    return true;
}*/

//-----------------------------------------------------------------------------
bool ChatHandler::Command_NPC_Sell (const char* args)
{
    WorldPacket data;

    char* pitem = strtok((char*)args, " ");
    if (!pitem)
        return false;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0)
    {
        m_session->SystemMessage ("No selection.");
        return true;
    }

    Creature * pCreature = objmgr.GetObject<Creature>(guid);
	if(!pCreature)
	{
		m_session->SystemMessage ("You should select a creature.");
		return true;
	}

	if ((uint32)0 == (pCreature->GetUInt32Value (UNIT_NPC_FLAGS) & (uint32)UNIT_NPC_FLAG_VENDOR))
    {
        m_session->SystemMessage ("Selected creature must have VENDOR NPC flag.");
        return true;
    }

    uint32 item = hex_or_decimal (pitem);;
    int amount = -1;

    char* pamount = strtok(NULL, " ");
    if (pamount)
        amount = atoi(pamount);

    char sql[512];
    sprintf(sql, "INSERT INTO vendors VALUES ('%u', '%i', '%i')", GUID_LOPART(guid), item, amount);
    sDatabase.Execute( sql );

    CreatureItem citem;
	citem.itemid = (int)item;
    citem.amount = amount;
    pCreature->item_list.push_back (citem);

    FillSystemMessageData(&data, m_session, "Item added.");
    m_session->SendPacket( &data );

    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_NPC_MType (const char* args)
{
    WorldPacket data;

    if(!*args)
        return false;

    int option = atoi((char*)args);

    if (option < 0 && option > 4) {
        m_session->SystemMessage ("Incorrect value, use 0 - random roam, 1 - walk forth, 2 - walk back, 3 - loop forth, 4 - loop back");
        return true;
    }

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0) {
        m_session->SystemMessage ("No selection.");
        return true;
    }

    Creature * pCreature = objmgr.GetObject<Creature>(guid);
    if (!pCreature) {
        m_session->SystemMessage ("You should select a creature.");
        return true;
    }

    char sql[512];
    sprintf(sql, "UPDATE creatures SET moveType = '%i' WHERE id = '%u'", option, GUID_LOPART(guid));
    sDatabase.Execute( sql );

    //pCreature->setMoveRandomFlag (option == 0);
	pCreature->m_movementType = (Creature::MovementType)option;
    
	m_session->SystemMessage ( "New movement type %d saved.", option);

    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_NPC_Run (const char* args)
{
    if(!*args) return false;
    int option = atoi((char*)args);

    if(option != 0 && option != 1) {
        m_session->SystemMessage ("Incorrect value, use 0 or 1");
        return true;
    }

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid == 0) {
        m_session->SystemMessage ("No selection.");
        return true;
    }

    Creature * pCreature = objmgr.GetObject<Creature>(guid);
    if(!pCreature) {
        m_session->SystemMessage ("Select an NPC first.");
        return true;
    }

	std::stringstream	ss;
    ss << "UPDATE creatures SET running=" << option << " WHERE id=" << GUID_LOPART(guid);
    sDatabase.Execute (ss.str().c_str());

    pCreature->setMoveRunFlag (option > 0);

    m_session->SystemMessage ("Creature run state changed to %d.", option);

    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_NPC_SpawnTime (const char* args)
{
	int time1 = 0,
		time2 = 0;

	if (*args) {
		char args1[512];
		strncpy (args1, args, sizeof (args1)-1); args1[sizeof (args1)-1] = '\x00';

		// read argument 1
		char *p = strtok (args1, " ");
		time1 = *p? atoi(p): time1;

		// read if exists - argument2, or else arg2 = arg1
		p = strtok (NULL, " ");
		time2 = p && *p? atoi(p): time1;

		// Make arg1 always <= arg2
		if (time1 > time2) {
			int t = time1; time1 = time2; time2 = t;
		}
	} else {
		m_session->SystemMessage ("Erm... spawn time or two spawn times expected as parameters.");
		return true;
	}

	uint64 guid = m_session->GetPlayer()->GetSelection();
	if (guid == 0) {
		m_session->SystemMessage ("No selection.");
		return true;
	}

	Creature * pCreature = objmgr.GetObject<Creature>(guid);
	if(!pCreature) {
		m_session->SystemMessage ("Select an NPC first.");
		return true;
	}

	if (time1 < 1 || time1 > 1000000) {
		m_session->SystemMessage ("Incorrect value for 1st parameter, use anything "
			"from 1 second to 1 million seconds");
		return true;
	}

	if (time2 < 1 || time2 > 1000000) {
		m_session->SystemMessage ("Incorrect value for 2nd parameter, use anything "
			"from 1 second to 1 million seconds, or just skip this parameter");
		return true;
	}

	std::stringstream	ss;
	ss << "UPDATE creatures SET spawnTime1=" << time1 << ", spawnTime2=" << time2
		<< " WHERE id=" << GUID_LOPART(guid);
	sDatabase.Execute (ss.str().c_str());

	if (pCreature->m_respawnTimer > 0) {
		pCreature->ResetRespawnTimer (time1, time2);
		m_session->SystemMessage ("Spawn time changed to %d..%d, spawn timer reset.", time1, time2);
	} else {
		pCreature->m_spawnTime[0] = time1;
		pCreature->m_spawnTime[1] = time2;
		m_session->SystemMessage ("Spawn time changed to %d..%d.", time1, time2);
	}

	return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_NPC_SpawnDistance (const char* args)
{
	if(!*args) return false;
	float dist = (float)atof((char*)args);

	if (dist < 0 || dist > 100) {
		m_session->SystemMessage ("Bad value for distance, use values from 0 to 100 or change NPC roam type.");
		return true;
	}

	uint64 guid = m_session->GetPlayer()->GetSelection();
	if (guid == 0) {
		m_session->SystemMessage ("No selection.");
		return true;
	}

	Creature * pCreature = objmgr.GetObject<Creature>(guid);
	if(!pCreature) {
		m_session->SystemMessage ("Select an NPC first.");
		return true;
	}

	std::stringstream	ss;
	ss << "UPDATE creatures SET spawnDist=" << dist << " WHERE id=" << GUID_LOPART(guid);
	sDatabase.Execute (ss.str().c_str());

	pCreature->m_spawnDist = dist;

	m_session->SystemMessage ("Creature roaming (spawning) distance changed to %.1f m", dist);

	return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_NPC_Level (const char* args)
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
    pCreature->SetLevel (lvl);

    pCreature->SaveToDB();

    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_NPC_Flags (const char* args)
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

    FillSystemMessageData(&data, m_session, "Value saved.");
    m_session->SendPacket( &data );

    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_NPC_Model (const char* args)
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
	pCreature->SetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID, displayId);

    pCreature->SaveToDB();

    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_NPC_Faction (const char* args)
{
	WorldPacket data;

	if (!*args)
		return false;

	uint32 factionId = (uint32) atoi((char*)args);

	uint64 guid = m_session->GetPlayer()->GetSelection();
	if (guid == 0) {
		m_session->SystemMessage ("No selection.");
		return true;
	}

	Creature * pCreature = objmgr.GetObject<Creature>(guid);
	if(!pCreature) {
		m_session->SystemMessage ("You should select a creature.");
		return true;
	}

	pCreature->SetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE , factionId);
	pCreature->SaveToDB();
	return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_NPC_ListHate (const char* args)
{
	WorldPacket data;

	if (!*args)
		return false;

	///uint32 factionId = (uint32) atoi((char*)args);

	uint64 guid = m_session->GetPlayer()->GetSelection();
	if (guid == 0) {
		m_session->SystemMessage ("No selection.");
		return true;
	}

	Creature * pCreature = objmgr.GetObject<Creature>(guid);
	if(!pCreature) {
		m_session->SystemMessage ("You should select a creature.");
		return true;
	}

	for (TargetMap::iterator iter = pCreature->m_targets.begin();
		iter != pCreature->m_targets.end(); iter++)
	{
		Unit * u = iter->first;
		m_session->SystemMessage ("GUID %X, hate: %.1f", 
			u->GetGUIDLow(), iter->second);
	}

	return true;
}

//--- END ---