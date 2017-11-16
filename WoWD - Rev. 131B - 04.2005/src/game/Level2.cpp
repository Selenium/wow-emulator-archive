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


bool ChatHandler::HandleProgCommand(const char* args)
{
    smsg_NewWorld(m_session, 451, 16391.80f, 16341.20f, 69.44f);

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

    unit->RemoveFromMap();

    unit->DeleteFromDB();

    objmgr.RemoveObject(unit);
    delete unit;

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

    Creature * pCreature = objmgr.GetObject<Creature>(guid);
    if(!pCreature)
    {
        FillSystemMessageData(&data, m_session, "You should select a creature.");
        m_session->SendPacket( &data );
        return true;
    }

    uint32 item = atoi(pitem);;
    int amount = -1;

    char* pamount = strtok(NULL, " ");
    if (pamount)
        amount = atoi(pamount);

    char sql[512];
    sprintf(sql, "INSERT INTO vendors VALUES ('%u', '%i', '%i')", GUID_LOPART(guid), item, amount);
    sDatabase.Execute( sql );

    pCreature->setItemId(pCreature->getItemCount() , (int)item);
    pCreature->setItemAmount(pCreature->getItemCount() , amount);
    pCreature->increaseItemCount();

    FillSystemMessageData(&data, m_session, "Item added.");
    m_session->SendPacket( &data );

    return true;
}


bool ChatHandler::HandleAddMoveCommand(const char* args)
{
    WorldPacket data;

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

    if(!pCreature->hasWaypoints())
    {
        sprintf(sql, "INSERT INTO creatures_mov (creatureId,X,Y,Z) VALUES ('%u', '%f', '%f', '%f')",
            GUID_LOPART(guid),
            pCreature->GetPositionX(),
            pCreature->GetPositionY(),
            pCreature->GetPositionZ());

        sDatabase.Execute(sql);

        pCreature->addWaypoint(pCreature->GetPositionX(), pCreature->GetPositionY(), pCreature->GetPositionZ());
    }

    if (!pCreature->addWaypoint(m_session->GetPlayer()->GetPositionX(),
        m_session->GetPlayer()->GetPositionY(),
        m_session->GetPlayer()->GetPositionZ()))
    {
        FillSystemMessageData(&data, m_session, "You have allready set all points.");
        m_session->SendPacket( &data );

        return true;
    }

    sprintf(sql, "INSERT INTO creatures_mov (creatureId,X,Y,Z) VALUES ('%u', '%f', '%f', '%f')",
        GUID_LOPART(guid),
        m_session->GetPlayer()->GetPositionX(),
        m_session->GetPlayer()->GetPositionY(),
        m_session->GetPlayer()->GetPositionZ());

    sDatabase.Execute( sql );

    FillSystemMessageData(&data, m_session, "Waypoint added.");
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

    pCreature->setMoveRandomFlag(option > 0);

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

    pCreature->setMoveRunFlag(option > 0);

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
