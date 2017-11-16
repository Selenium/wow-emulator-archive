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



//-----------------------------------------------------------------------------
void WorldSession::HandleSetActionButton( WorldPacket & recv_data )
{
    Log::getSingleton( ).outDebug( "WORLD: CMSG_SET_ACTION_BUTTON" );

	uint8 slot;
	uint32 what;

	recv_data >> slot >> what;

	ASSERT( ((slot >= 0) && (slot < 120)) );

	GetPlayer()->m_actionsButtons[slot] = what;
}


//-----------------------------------------------------------------------------
void WorldSession::HandleRepopRequestOpcode( WorldPacket & recv_data )
{
    Log::getSingleton( ).outDebug( "WORLD: CMSG_REPOP_REQUEST" );

    GetPlayer()->BuildPlayerRepop();
    GetPlayer()->RepopAtGraveyard();
	
	GetPlayer()->RemoveFromMap();
	GetPlayer()->PlaceOnMap();
}

//-----------------------------------------------------------------------------
void WorldSession::HandleAutostoreLootItemOpcode( WorldPacket & recv_data )
{
    uint8 slot = 0;
    uint32 itemid;
    uint8 lootSlot;
    WorldPacket data;

	Log::getSingleton( ).outDebug( "WORLD: CMSG_AUTOSTORE_LOOT_ITEM" );

    Creature* pCreature = objmgr.GetObject<Creature>(GetPlayer()->GetLootGUID());
    if (!pCreature)
        return;

    recv_data >> lootSlot;

    /*
	uint8 i;
	for(i = INVENTORY_SLOT_ITEM_START; i < INVENTORY_SLOT_ITEM_END; i++)
    {
        if (GetPlayer()->GetItemBySlot(i) == NULL)
        {
            slot = i;
            break;
        }
    }

    if (slot == 0)
        return; //maybe whine a bit too?
	*/

    if (pCreature->getItemAmount(lootSlot) == 0)
        return; //maybe whine a bit too?

    itemid = pCreature->getItemId(lootSlot);
    
	if (GetPlayer()->AddItemToBackpack (itemid, pCreature->getItemAmount (lootSlot))) {
		pCreature->setItemAmount(lootSlot, 0);
	}
	else return;

    /*Item *item = new Item();
    ASSERT(item);

    item->Create(objmgr.GenerateLowGuid(HIGHGUID_ITEM), itemid, GetPlayer());
    GetPlayer()->AddItemToSlot(slot, item);
	*/
	Log::getSingleton( ).outDebug( "WORLD: SMSG_LOOT_REMOVED" );
    data.Initialize( SMSG_LOOT_REMOVED );
    data << uint8(lootSlot);
    SendPacket( &data );


    data.Initialize( SMSG_ITEM_PUSH_RESULT );
	/*
	0:02:59 - SERVER >>> OpCode=0x166 SMSG_ITEM_PUSH_RESULT, size=37

		0- 1- 2- 3- 4- 5- 6- 7- | 8- 9- A- B- C- D- E- F- | 01234567 89ABCDEF
	0000: 00#23#66#01 6F FF 0C 01 | 00 00 00 00 00 00 00 00 | .#f.o... ........
	0010: 00 00 00 00 01 00 00 00 | FF A1 1B 00 00 00 00 00 | ........ ........
	0020: 00 00 00 00 00          |                         | .....    
	*/
	// 6F FF 0C 01 = GUID of Player
	// A1 1B 00 00 = Item ID

	// Data filling
	data << GetPlayer()->GetGUID();
	data << uint64(0x00000000);
	data << uint8(0x01);			// Goes constant to all
	data << uint8(0x00);
	data << uint8(0x00);
	data << uint8(0x00);
	data << uint8(0xFF);			// Goes constant to all
    data << uint32(itemid);
	data << uint8(0x00);
	data << uint8(0x00);
	data << uint8(0x00);
	data << uint32(0x00000000);
	data << uint8(0x00);

    SendPacket( &data );
}

//-----------------------------------------------------------------------------
void WorldSession::HandleLootMoneyOpcode( WorldPacket & recv_data )
{
    WorldPacket data;

    uint32 newcoinage = 0;

    Creature* pCreature = objmgr.GetObject<Creature>(GetPlayer()->GetLootGUID());
    if (!pCreature)
        return;

    newcoinage = GetPlayer()->GetUInt32Value(PLAYER_FIELD_COINAGE) + pCreature->getLootMoney();
    pCreature->setLootMoney(0);
    GetPlayer()->SetUInt32Value( PLAYER_FIELD_COINAGE , newcoinage);
}

//-----------------------------------------------------------------------------
void WorldSession::HandleLootOpcode( WorldPacket & recv_data )
{

	Log::getSingleton( ).outDebug( "WORLD: CMSG_LOOT" );
    uint64 guid;
    //uint16 tmpItemsCount = 0;
    uint8 i;
    ItemPrototype *tmpLootItem;
    WorldPacket data;

    recv_data >> guid;

    Creature* pCreature = objmgr.GetObject<Creature>(guid);
    if (!pCreature)
        return;

    GetPlayer()->SetLootGUID(guid);

    /*for(i = 0; i < pCreature->getItemCount() ; i++)
    {
        if (pCreature->getItemAmount((int)i) > 0)
            tmpItemsCount++;
    }*/

    data.Initialize( SMSG_LOOT_RESPONSE );

    data << guid;
    data << uint8(0x01);
    data << uint32(pCreature->getLootMoney());
    data << uint8(pCreature->getItemCount());

    for(i = 0; i<pCreature->getItemCount() ; i++)
    {
        if (pCreature->getItemAmount((int)i) > 0)
        {
            data << uint8(i);
            tmpLootItem = objmgr.GetItemPrototype(pCreature->getItemId((int)i));
            data << uint32(pCreature->getItemId((int)i));
            data << uint32(pCreature->getItemAmount((int)i));
            data << uint32(tmpLootItem->DisplayInfoID);
            data << uint8(0) << uint32(0) << uint32(0);
        }
    }
    SendPacket( &data );
}

//-----------------------------------------------------------------------------
void WorldSession::HandleLootReleaseOpcode( WorldPacket & recv_data )
{
	Log::getSingleton( ).outDebug( "WORLD: CMSG_LOOT_RELEASE" );

	uint8 lootCount = 0;
    uint64 guid;
    WorldPacket data;

    recv_data >> guid;

    GetPlayer()->SetLootGUID(0);

    Creature* pCreature = objmgr.GetObject<Creature>(guid);

    data.Initialize( SMSG_LOOT_RELEASE_RESPONSE );
    data << guid << uint8( 1 );
    SendPacket( &data );

    if (!pCreature)
        return;

	for(int i = 0; i<pCreature->getItemCount() ; i++)
    {
        if (pCreature->getItemAmount((int)i) > 0)
        {
			lootCount += 1;
        }
    }

	// If loot released and nothing left there - set sparkles off
	if (pCreature->getLootMoney() == 0 && lootCount == 0) {
		pCreature->SetUInt32Value(UNIT_DYNAMIC_FLAGS, 0);

		// Also set skinnable flag for beasts and dragonkin
		// TODO: Add Skinnable also for Yetis and Worgen-like creatures
		int32 ctype = pCreature->GetCreatureTemplate()->Type;
		if (ctype == CREATURE_TYPE_BEAST || ctype == CREATURE_TYPE_DRAGONKIN)
			pCreature->SetUInt32Value (UNIT_FIELD_FLAGS, (0x4004000)); // set skinnable
	} else {
		// Set group/raid-wide loot rights for the corpse - send update to
		// all group or raid members with lootable flag
		// TODO!
	}
}

//-----------------------------------------------------------------------------
void WorldSession::HandleWhoOpcode( WorldPacket & recv_data )
{
    uint64 clientcount = 0;
    int datalen = 8;
    int countcheck = 0;
    WorldPacket data;

    Log::getSingleton( ).outDebug( "WORLD: CMSG_WHO" );

    ObjectMgr::PlayerMap::const_iterator itr;
    for (itr = objmgr.Begin<Player>(); itr != objmgr.End<Player>(); itr++)
    {
        if ( itr->second->GetName() )
        {
            clientcount++;

            datalen = datalen + strlen(itr->second->GetName()) + 1 + 21;
        }
    }

    data.Initialize( SMSG_WHO );
    data << uint64( clientcount );

    for (itr = objmgr.Begin<Player>(); itr != objmgr.End<Player>(); itr++)
    {
        if ( itr->second->GetName() && (countcheck  < clientcount))
        {
            countcheck++;

            data.append(itr->second->GetName() , strlen(itr->second->GetName()) + 1);
            data << uint8( 0x00 );
            data << uint32( itr->second->GetLevel() );
            data << uint32( itr->second->GetClass() );
            data << uint32( itr->second->GetRace() );
            data << uint32( itr->second->GetZoneId() );

            data << uint32( 0x00000000 ); // this is the guild id...once we have guilds working it'll go here.
        }
    }

    WPAssert(data.size() == datalen);
    SendPacket(&data);
}

//-----------------------------------------------------------------------------
void WorldSession::HandleLogoutRequestOpcode( WorldPacket & recv_data )
{
    WorldPacket data;

    Log::getSingleton( ).outDebug( "WORLD: CMSG_LOGOUT_REQUEST" );

	if (GetPlayer()->isInCombat()) {
		SystemMessage ("Can't logout, you're in combat!");
		return;
	}

	GetPlayer()->SetStandState (STANDSTATE_SIT);
	GetPlayer()->LoseStealth();

	// Aighty let player logs out
	//
    data.Initialize( SMSG_LOGOUT_RESPONSE );
    data << uint32(0); // Filler
	
	data << uint8(0);  // Logout accepted
    SendPacket( &data );

	// Can't move
	//
	data.Initialize( SMSG_FORCE_MOVE_ROOT );
	data << GetPlayer()->GetGUID();
	SendPacket( &data );

	// Add here sit down code
	// ....

    LogoutRequest(time(NULL));
}

//-----------------------------------------------------------------------------
void WorldSession::HandlePlayerLogoutOpcode( WorldPacket & recv_data )
{
    WorldPacket data;

    Log::getSingleton( ).outDebug( "WORLD: CMSG_PLAYER_LOGOUT" );

    LogoutRequest(0);
    LogoutPlayer();
}

//-----------------------------------------------------------------------------
void WorldSession::HandleLogoutCancelOpcode( WorldPacket & recv_data )
{
    WorldPacket data;

    Log::getSingleton( ).outDebug( "WORLD: CMSG_LOGOUT_CANCEL" );

    LogoutRequest(0);

    data.Initialize( SMSG_LOGOUT_CANCEL_ACK );
    SendPacket( &data );

	// Can move again
	//
	data.Initialize( SMSG_FORCE_MOVE_UNROOT );
	data << GetPlayer()->GetGUID();
	SendPacket( &data );

	// Stand Up
	GetPlayer()->SetStandState (STANDSTATE_STAND);

    Log::getSingleton( ).outDebug( "WORLD: SMSG_LOGOUT_CANCEL_ACK" );
}

//-----------------------------------------------------------------------------
// Handles the Get Ticket Opcode.
//
void WorldSession::HandleGMTicketGetTicketOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint64 guid;
    std::stringstream query,query1;
    Field *fields;
    guid = GetPlayer()->GetGUID();
	
	Log::getSingleton( ).outDebug( "WORLD: Received CMSG_GMTICKET_GETTICKET");

    query << "SELECT COUNT(*) FROM `gmsystem` where guid='" << guid << "'";
    QueryResult *result = sDatabase.Query( query.str().c_str() );

    if (result)
    {
        int cnt;
        fields = result->Fetch();
        cnt = fields[0].GetUInt32();

		if ( cnt > 0)
		{
			data.Initialize( SMSG_GMTICKET_GETTICKET );
			query1 << "SELECT * FROM `gmsystem` where guid='" << guid << "'";
			QueryResult *result = sDatabase.Query( query1.str().c_str() );
			fields = result->Fetch();

			std::string tText = fields[2].GetString();

			data << uint32(6); // means we have open tickets
			data << tText;
			data << uint8(0) << uint8(3); // Unknown fields
			SendPacket( &data );
			Log::getSingleton( ).outDebug( "WORLD: Send SMSG_GMTICKET_GETTICKET");
        } else 
		{
			data << uint32(1); // No Open Tickets;
			data << uint32(0); // NULL String
			data << uint8(0) << uint8(0); // Unknown
			SendPacket( &data );
			Log::getSingleton( ).outDebug( "WORLD: Send SMSG_GMTICKET_GETTICKET");
        }

        delete result;
	}
}

// -------------------------------------------------------------------------
// Text update
void WorldSession::HandleGMTicketTextUpdateOpcode( WorldPacket & recv_data )
{
    Log::getSingleton( ).outDebug( "WORLD: Received CMSG_GMTICKET_UPDATETEXT");
    WorldPacket data;
    uint64 guid = GetPlayer()->GetGUID();
    std::string ticketText;
	std::stringstream ss;
	uint8 unk1;
	char *newText;

	recv_data >> unk1;
	recv_data >> ticketText;
	newText = new char[ (ticketText.length() * 2) + 1 ];

    replaceESCChars( (char*)ticketText.c_str(), newText );

    ss << "UPDATE `gmsystem` set text = '" << newText << "' WHERE guid = '" << guid << "'";
    sDatabase.Execute( ss.str( ).c_str( ) );

	delete newText;
}

void WorldSession::HandleGMTicketDeleteOpcode( WorldPacket & recv_data )  
{
	WorldPacket data;  
	uint64 guid = GetPlayer()->GetGUID();  
	std::stringstream ss;
	
	Log::getSingleton( ).outDebug( "WORLD: Received CMSG_GMTICKET_DELETETICKET");

	ss << "DELETE FROM `gmsystem` where guid='" << guid << "' LIMIT 1";  
	sDatabase.Execute( ss.str( ).c_str( ) );  

	data.Initialize( SMSG_GMTICKET_GETTICKET );  
	data << uint32(1); // No Tickets we have :)
	data << uint32(0);  
	data << uint8(0);  
	data << uint8(0);

	SendPacket( &data );  
} 


//-----------------------------------------------------------------------------
void WorldSession::HandleGMTicketCreateOpcode( WorldPacket & recv_data )
{
    Log::getSingleton( ).outDebug( "WORLD: Received CMSG_GMTICKET_CREATE");
    WorldPacket data;
    uint64 guid = GetPlayer()->GetGUID();
    std::string ticketText;
	std::stringstream ss;

	uint8 category;
	uint64 unk1, unk2;
	int   cat[] = { 0,5,1,2,0,6,4,7,0,8,3 };
	char *newText;

	recv_data >> category;
	recv_data >> unk1 >> unk2;
	recv_data >> ticketText;
	newText = new char[ (ticketText.length() * 2) + 1 ];

	replaceESCChars( (char*)ticketText.c_str(), newText );

    ss << "INSERT INTO `gmsystem` VALUES ('','" << guid << "', '" << newText << "', '" << cat[category] << "')";
    sDatabase.Execute( ss.str( ).c_str( ) );
    data.Initialize( SMSG_GMTICKET_CREATE );
    data << uint32(2); // unknown
    SendPacket( &data );

    Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_GMTICKET_CREATE");
    delete newText;
}

//-----------------------------------------------------------------------------
void WorldSession::HandleGMTicketSystemStatusOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    Log::getSingleton( ).outDebug( "WORLD: Received CMSG_GMTICKET_SYSTEMSTATUS");
	
    //TODO: Receive message sent and relay it to an online GM
    data.Initialize( SMSG_GMTICKET_SYSTEMSTATUS );
    data << uint32(1);

    Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_GMTICKET_SYSTEMSTATUS");
    SendPacket( &data );
}

//-----------------------------------------------------------------------------
void WorldSession::HandleZoneUpdateOpcode( WorldPacket & recv_data )
{
    uint32 newZone,oldZone;
    WPAssert(GetPlayer());
	if(GetPlayer()->HasFlag(PLAYER_FLAGS, PLAYER_FLAG_RESTING))
		GetPlayer()->RemoveFlag(PLAYER_FLAGS, PLAYER_FLAG_RESTING);

    recv_data >> newZone;
    Log::getSingleton( ).outDetail("WORLD: Recvd ZONE_UPDATE: %u", newZone);

    if (GetPlayer()->GetZoneId() == newZone)
        return;

    oldZone = GetPlayer( )->GetZoneId();

    //Setting new zone
    GetPlayer()->SetZoneId((uint16)newZone);
	
	// Exploration System
	GetPlayer()->InitExploreSystem();
}

//-----------------------------------------------------------------------------
void WorldSession::HandleSetTargetOpcode( WorldPacket & recv_data )
{
    uint64 guid ;
    recv_data >> guid;

    if( GetPlayer( ) != 0 )
        GetPlayer( )->SetTarget(guid);
}

//-----------------------------------------------------------------------------
void WorldSession::HandleSetSelectionOpcode( WorldPacket & recv_data )
{
    uint64 guid;
    recv_data >> guid;

	Player *p = GetPlayer();
	if (p != NULL)
	{
		// If changed selection to another mob - reset combo points
		if (p->GetSelection() != p->GetUInt64Value (PLAYER__FIELD_COMBO_TARGET) &&
			p->GetComboPoints() != 0) 
		{
			p->SetComboPoints (0);
		}

        GetPlayer()->SetSelection(guid);
	}
}

//-----------------------------------------------------------------------------
void WorldSession::HandleStandStateChangeOpcode( WorldPacket & recv_data )
{
    if( GetPlayer( ) != 0 )
    {
		uint8 animstate;
		recv_data >> animstate;

		GetPlayer()->SetStandState (animstate);

		/*
        // retrieve current BYTES
        uint32 bytes1 = GetPlayer( )->GetUInt32Value( UNIT_FIELD_BYTES_1 );
        uint8 bytes[4];

//        uint64 guid; no need for it in 0.12
//        recv_data >> guid;

        bytes[0] = uint8(bytes1 & 0xff);
        bytes[1] = uint8((bytes1>>8) & 0xff);
        bytes[2] = uint8((bytes1>>16) & 0xff);
        bytes[3] = uint8((bytes1>>24) & 0xff);

        // retrieve new stand state
        uint8 animstate;
        recv_data >> animstate;

        // if (bytes[0] == animstate) break;
        bytes[0] = animstate;

        uint32 newbytes = (bytes[0]) + (bytes[1]<<8) + (bytes[2]<<16) + (bytes[3]<<24);
        GetPlayer( )->SetUInt32Value(UNIT_FIELD_BYTES_1 , newbytes);
		*/
    }
}

//-----------------------------------------------------------------------------
void WorldSession::HandleFriendListOpcode( WorldPacket & recv_data )
{
    WorldPacket data, dataI;

    Log::getSingleton( ).outDebug( "WORLD: CMSG_FRIEND_LIST"  );

    unsigned char Counter=0, nrignore=0;
	int i=0;
    uint64 guid;
    std::stringstream query,query2,query3,query4;
	Field *fields;
    Player* pObj;
    FriendStr friendstr[255];

    guid=GetPlayer()->GetGUID();

    query << "SELECT COUNT(*) FROM `friendlist` where flags = 'FRIEND' AND guid='" << guid << "'";
    QueryResult *result = sDatabase.Query( query.str().c_str() );

    if(result)
    {
        fields = result->Fetch();
        Counter=fields[0].GetUInt32();

        query2 << "SELECT * FROM `friendlist` where flags = 'FRIEND' AND guid='" << guid << "'";
        result = sDatabase.Query( query2.str().c_str() );
        
        if(result)
        {
            fields = result->Fetch();
            friendstr[i].PlayerGUID = fields[2].GetUInt64();
            pObj=objmgr.GetObject<Player>(friendstr[i].PlayerGUID);

            if(pObj && pObj->IsInWorld())
            {
                friendstr[i].Status = 1;
                friendstr[i].Area = pObj->GetZoneId();
                friendstr[i].Level = pObj->GetLevel();
                friendstr[i].Class = pObj->GetClass();
                i++;
            }
            else
            {
                friendstr[i].Status = 0;
                friendstr[i].Area = 0;
                friendstr[i].Level = 0;
                friendstr[i].Class = 0;
                i++;
            }

            while( result->NextRow() )
            {
                friendstr[i].PlayerGUID = fields[2].GetUInt64();

				pObj = objmgr.GetObject<Player>(friendstr[i].PlayerGUID);

                if(pObj)
                {
                    friendstr[i].Status = 1;
                    friendstr[i].Area = pObj->GetZoneId();
                    friendstr[Counter].Level = pObj->GetLevel();
                    friendstr[Counter].Class = pObj->GetClass();
                    i++;
                }
                else
                {
                    friendstr[i].Status = 0;
                    friendstr[i].Area = 0;
                    friendstr[Counter].Level = 0;
                    friendstr[Counter].Class = 0;
                    i++;
                }
            }
        }
    }

    // Sending Friend List

    data.Initialize( SMSG_FRIEND_LIST );
    data << Counter;

    for (int j=0; j<Counter; j++)
    {

        //Log::getSingleton( ).outDetail( "WORLD: Adding Friend - Guid:%ld, Status:%d, Area:%d, Level:%d Class:%d",friendstr[j].PlayerGUID, friendstr[j].Status, friendstr[j].Area,friendstr[j].Level,friendstr[j].Class  );

        data << friendstr[j].PlayerGUID << friendstr[j].Status ;
        if (friendstr[j].Status != 0)
            data << friendstr[j].Area << friendstr[j].Level << friendstr[j].Class;
    }

    SendPacket( &data );
    Log::getSingleton( ).outDebug( "WORLD: SMSG_FRIEND_LIST" );

	// Sending Ignore List

	query3 << "SELECT COUNT(*) FROM `friendlist` where flags = 'IGNORE' AND guid='" << guid << "'";
	result = sDatabase.Query( query3.str().c_str() );
	
	if(!result) return;
	
	fields = result->Fetch();
	nrignore=fields[0].GetUInt32();


	dataI.Initialize( SMSG_IGNORE_LIST );
	dataI << nrignore;

	query4 << "SELECT * FROM `friendlist` where flags = 'IGNORE' AND guid='" << guid << "'";
	result = sDatabase.Query( query4.str().c_str() );
  
	if(!result) return;
	
	do {
		fields = result->Fetch();
        dataI << fields[2].GetUInt64();

   	}while( result->NextRow() );


	SendPacket( &dataI );
	Log::getSingleton( ).outDebug( "WORLD: SMSG_IGNORE_LIST" );
}


//-----------------------------------------------------------------------------
void WorldSession::SendFriendList()
{
    unsigned char Counter=0;

    while (0) {
        // get friend list add them to buffer
    }

    FriendStr friendstr[255];

    /// add RandomGuy to the friend's list
    /*friendstr[Counter].PlayerGUID = 48;
    friendstr[Counter].Status = 0;
    friendstr[Counter].Area = 0;
    friendstr[Counter].Level = 1;
    friendstr[Counter].Class = 1;
    Counter++;*/

	WorldPacket	data;

    data.Initialize( SMSG_FRIEND_LIST );
    data << Counter;

    for (int j=0; j<Counter; j++) {
        // adding friend
        Log::getSingleton( ).outDetail( "WORLD: Adding Friend - Guid:%ld, Status:%d, Area:%d, Level:%d Class:%d",
            friendstr[j].PlayerGUID, friendstr[j].Status, friendstr[j].Area,friendstr[j].Level,friendstr[j].Class  );

        data << friendstr[j].PlayerGUID << friendstr[j].Status ;
        if (friendstr[j].Status != 0)
            data << friendstr[j].Area << friendstr[j].Level << friendstr[j].Class;
    }

    SendPacket( &data );

    Log::getSingleton( ).outDebug( "WORLD: Sent (SMSG_FRIEND_LIST)" );
}

//-----------------------------------------------------------------------------
void WorldSession::HandleAddFriendOpcode( WorldPacket & recv_data )
{
    Log::getSingleton( ).outDebug( "WORLD: CMSG_ADD_FRIEND" );

    std::string friendName = "UNKNOWN";
	std::stringstream fquery;
	unsigned char friendResult = FRIEND_NOT_FOUND;
	Player *pfriend=NULL;
	uint64 friendGuid = 0;
    uint32 friendArea = 0, friendLevel = 0, friendClass = 0;
	WorldPacket data;

    recv_data >> friendName;

    //Log::getSingleton( ).outDetail( "WORLD: %s asked to add friend : '%s'",
	//   GetPlayer()->GetName(), friendName.c_str() );
	
   
    friendGuid = objmgr.GetPlayerGUIDByName(friendName.c_str());

	pfriend = objmgr.GetObject<Player>(friendGuid);

	fquery << "SELECT * FROM friendlist WHERE flags = 'FRIEND' AND friend_guid = " << friendGuid;

	if(sDatabase.Query( fquery.str().c_str() )) friendResult = FRIEND_ALREADY;
	if (!strcmp(GetPlayer()->GetName(),friendName.c_str())) friendResult = FRIEND_SELF;
	
	// Send response.
    data.Initialize( SMSG_FRIEND_STATUS );

    if (friendGuid > 0 && friendResult!=FRIEND_ALREADY && friendResult!=FRIEND_SELF)
    {
        if( pfriend != NULL && pfriend->IsInWorld())
		{
            friendResult = FRIEND_ADDED_ONLINE;
			friendArea = pfriend->GetZoneId();
			friendLevel = pfriend->GetLevel();
			friendClass = pfriend->GetClass();
			
			data << (uint8)friendResult << (uint64)friendGuid;
            data << (uint32)friendArea << (uint32)friendLevel << (uint32)friendClass;
			
			std::stringstream query;
			uint64 guid;
			guid=GetPlayer()->GetGUID();

			query << "INSERT INTO `friendlist` VALUES ('" << guid << "', " << friendName << ", " << friendGuid << ", 'FRIEND')" ;
			sDatabase.Query( query.str().c_str() );	

		}
        else
            friendResult = FRIEND_ADDED_OFFLINE;

       // Log::getSingleton( ).outDetail( "WORLD: %s Guid found '%ld' area:%d Level:%d Class:%d. ",
       //     friendName.c_str(), friendGuid, friendArea, friendLevel, friendClass);

    }
	else if(friendResult==FRIEND_ALREADY)
	{
		data << (uint8)friendResult << (uint64)friendGuid;
		//Log::getSingleton( ).outDetail( "WORLD: %s Guid Already a Friend. ", friendName.c_str() );
	}
	else if(friendResult==FRIEND_SELF)
	{
		data << (uint8)friendResult << (uint64)friendGuid;
		//Log::getSingleton( ).outDetail( "WORLD: %s Guid can't add himself. ", friendName.c_str() );
	}
	else
	{
		data << (uint8)friendResult << (uint64)friendGuid;
        //Log::getSingleton( ).outDetail( "WORLD: %s Guid not found. ", friendName.c_str() );
	}

    // Finish
    SendPacket( &data );

    Log::getSingleton( ).outDebug( "WORLD: SMSG_FRIEND_STATUS" );
}


//-----------------------------------------------------------------------------
void WorldSession::HandleDelFriendOpcode( WorldPacket & recv_data )
{
    uint64 FriendGUID;
    WorldPacket data;

    Log::getSingleton( ).outDebug( "WORLD: CMSG_DEL_FRIEND"  );
    recv_data >> FriendGUID;

    unsigned char FriendResult = FRIEND_REMOVED;

    int FriendArea = 0;
    int FriendLevel = 0;
    int FriendClass = 0;

    // Send response.
    data.Initialize( SMSG_FRIEND_STATUS );

    data << (uint8)FriendResult << (uint64)FriendGUID;

    std::stringstream query;
    uint64 guid;
    guid=GetPlayer()->GetGUID();

    query << "DELETE FROM `friendlist` WHERE flags = 'FRIEND' AND `guid`=" << guid << " AND `friend_guid`=" << FriendGUID;
    sDatabase.Query( query.str().c_str() );
    
	// Finish
    SendPacket( &data );

    Log::getSingleton( ).outDebug( "WORLD: SMSG_FRIEND_STATUS" );
}

void WorldSession::HandleAddIgnoreOpcode( WorldPacket & recv_data )
{
    Log::getSingleton( ).outDebug( "WORLD: CMSG_ADD_IGNORE"  );

    std::string IgnoreName = "UNKNOWN";
	std::stringstream iquery;
	unsigned char ignoreResult = FRIEND_IGNORE_NOT_FOUND;
	Player *pIgnore=NULL;
	uint64 IgnoreGuid = 0;

	WorldPacket data;

    recv_data >> IgnoreName;

    //Log::getSingleton( ).outDetail( "WORLD: %s asked to Ignore: '%s'",
	//    GetPlayer()->GetName(), IgnoreName.c_str() );
   
    IgnoreGuid = objmgr.GetPlayerGUIDByName(IgnoreName.c_str());

	pIgnore = objmgr.GetObject<Player>(IgnoreGuid);

	iquery << "SELECT * FROM friendlist WHERE flags = 'IGNORE' AND friend_guid = " << IgnoreGuid;

	if(sDatabase.Query( iquery.str().c_str() )) ignoreResult = FRIEND_IGNORE_ALREADY;
	if (!strcmp(GetPlayer()->GetName(),IgnoreName.c_str())) ignoreResult = FRIEND_IGNORE_SELF;
	
	// Send response.
    data.Initialize( SMSG_FRIEND_STATUS );

    if (pIgnore && ignoreResult!=FRIEND_IGNORE_ALREADY && ignoreResult!=FRIEND_IGNORE_SELF)
    {
        ignoreResult = FRIEND_IGNORE_ADDED;
				
		std::stringstream query;
		uint64 guid;
		guid=GetPlayer()->GetGUID();

		data << (uint8)ignoreResult << (uint64)IgnoreGuid;

		query << "INSERT INTO `friendlist` VALUES ('" << guid << "', " << IgnoreName << ", " << IgnoreGuid << ", 'IGNORE')" ;
		sDatabase.Query( query.str().c_str() );	
    }
	else if(ignoreResult==FRIEND_IGNORE_ALREADY)
	{
		data << (uint8)ignoreResult << (uint64)IgnoreGuid;
		//Log::getSingleton( ).outDetail( "WORLD: %s Guid Already Ignored. ", IgnoreName.c_str() );
	}
	else if(ignoreResult==FRIEND_IGNORE_SELF)
	{
		data << (uint8)ignoreResult << (uint64)IgnoreGuid;
		//Log::getSingleton( ).outDetail( "WORLD: %s Guid can't add himself. ", IgnoreName.c_str() );
	}
	else
	{
		data << (uint8)ignoreResult << (uint64)IgnoreGuid;
        //Log::getSingleton( ).outDetail( "WORLD: %s Guid not found. ", IgnoreName.c_str() );
	}

    // Finish
    SendPacket( &data );

    Log::getSingleton( ).outDebug( "WORLD: SMSG_FRIEND_STATUS" );
}

void WorldSession::HandleDelIgnoreOpcode( WorldPacket & recv_data )
{
    uint64 IgnoreGUID;
    WorldPacket data;

    Log::getSingleton( ).outDebug( "WORLD: CMSG_DEL_IGNORE"  );
    recv_data >> IgnoreGUID;

    unsigned char IgnoreResult = FRIEND_IGNORE_REMOVED;

    // Send response.
    data.Initialize( SMSG_FRIEND_STATUS );

    data << (uint8)IgnoreResult << (uint64)IgnoreGUID;


    std::stringstream query;
    uint64 guid;
    guid=GetPlayer()->GetGUID();

    query << "DELETE FROM `friendlist` WHERE flags = 'IGNORE' AND `guid`=" << guid << " AND `friend_guid`=" << IgnoreGUID;
    sDatabase.Query( query.str().c_str() );

    SendPacket( &data );

    Log::getSingleton( ).outDebug( "WORLD: SMSG_FRIEND_STATUS" );

}

//-----------------------------------------------------------------------------
void WorldSession::HandleBugOpcode( WorldPacket & recv_data )
{
    uint32 suggestion, contentlen;
    std::string content;
    uint32 typelen;
    std::string type;

    recv_data >> suggestion >> contentlen >> content >> typelen >> type;

    if( suggestion == 0 )
        Log::getSingleton( ).outDebug( "WORLD: CMSG_BUG [Bug Report]" );
    else
        Log::getSingleton( ).outDebug( "WORLD: CMSG_BUG [Suggestion]" );

    Log::getSingleton( ).outDebug( type.c_str( ) );
    Log::getSingleton( ).outDebug( content.c_str( ) );

	std::stringstream ss;
	ss << "INSERT INTO bugreport (rep_type, rep_content) VALUES (" << type.c_str( ) << ", " << content.c_str( ) << " )";
	sDatabase.Execute (ss.str().c_str());

}


/*void WorldSession::HandleJoinChannelOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    std::string channelName;
    recv_data >> channelName;
    data.Initialize(SMSG_CHANNEL_NOTIFY);
    data << uint8(2);
    data << channelName;
    data << uint32(1);
    SendPacket( &data );
}


void WorldSession::HandleLeaveChannelOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    std::string channelName;
    recv_data >> channelName;
    data.Initialize(SMSG_CHANNEL_NOTIFY);
    data << uint8(3);
    data << channelName;
    SendPacket( &data );
}*/

//-----------------------------------------------------------------------------
void WorldSession::HandleCorpseReclaimOpcode(WorldPacket &recv_data)
{
    Log::getSingleton().outDetail("WORLD: CMSG_RECLAIM_CORPSE");

    uint64 guid;
    recv_data >> guid;

    /*
	GetPlayer()->SetMovement(MOVE_LAND_WALK);
    GetPlayer( )->SetPlayerSpeed(RUN, (float)7.5, true);
    GetPlayer( )->SetPlayerSpeed(SWIM, (float)4.9, true);

    GetPlayer( )->SetUInt32Value(CONTAINER_FIELD_SLOT_1+29, 0);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURA+32, 0);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURALEVELS+8, 0xeeeeeeee);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS+8, 0xeeeeeeee);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURAFLAGS+4, 0);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURASTATE, 0);
	*/

    GetPlayer()->ResurrectPlayer();
    //GetPlayer()->SetUInt32Value(UNIT_FIELD_HEALTH, (uint32)(GetPlayer()->GetUInt32Value(UNIT_FIELD_MAXHEALTH)*0.50) );
    //GetPlayer()->SpawnCorpseBones();
}
//-----------------------------------------------------------------------------------------
void WorldSession::HandleResurrectResponseOpcode(WorldPacket & recv_data)
{
    Log::getSingleton().outDetail("WORLD: CMSG_RESURRECT_RESPONSE");

	Player *plr = GetPlayer();
    if (plr->isAlive()) return;

    WorldPacket data;
    uint64 guid;
    uint8 status;
    recv_data >> guid;
    recv_data >> status;

    if(status != 0)
        return;

    if (plr->m_resurrectGUID == 0) return;

    //GetPlayer( )->SetMovement(MOVE_LAND_WALK);
    plr->SetMovement(MOVE_UNROOT);
    //GetPlayer( )->SetPlayerSpeed(RUN, (float)7.5, true);
    //GetPlayer( )->SetPlayerSpeed(SWIM, (float)4.9, true);

    /*
	GetPlayer( )->SetUInt32Value(CONTAINER_FIELD_SLOT_1+29, 0);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURA+32, 0);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURALEVELS+8, 0xeeeeeeee);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS+8, 0xeeeeeeee);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURAFLAGS+4, 0);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURASTATE, 0);
	*/

    plr->ResurrectPlayer();
    
	if (plr->GetHealth() > (int)plr->m_resurrectHealth)
			plr->SetHealth ((int)plr->m_resurrectHealth);
	else	plr->SetHealth (plr->GetHealth() / 2);

	if (plr->GetMana() > (int)plr->m_resurrectMana)
			plr->SetMana ((int)plr->m_resurrectMana);
	else	plr->SetMana (plr->GetMana());
    
	plr->SpawnCorpseBones();

    plr->BuildTeleportAckMsg (&data, plr->m_resurrectX, plr->m_resurrectY, plr->m_resurrectZ, plr->GetOrientation());
    plr->GetSession()->SendPacket(&data);
    plr->SetPosition (plr->m_resurrectX, plr->m_resurrectY, plr->m_resurrectZ, plr->GetOrientation());

    plr->m_resurrectGUID = 0;
    plr->m_resurrectHealth = plr->m_resurrectHealth = 0;
    plr->m_resurrectX = plr->m_resurrectY = plr->m_resurrectZ = 0;
}

//-----------------------------------------------------------------------------------------
void WorldSession::HandleUpdateAccountDataOpcode (WorldPacket & recvPacket)
{
	uint32	dataId,
			dataLen = recvPacket.size() - 4;
	
	recvPacket >> dataId;

	Log::getSingleton().outDetail("WORLD: CMSG_UPDATE_ACCOUNT_DATA (%d)", dataId, dataLen);

	uint8 *dataPtr = new uint8[dataLen];
	recvPacket.read (dataPtr, dataLen);

	// Store client settings: Delete old from database
	//
	std::stringstream query;

	query << "DELETE FROM chars_data WHERE ownerChar=" << GetPlayer()->GetGUID()
		<< " AND dataId=" << dataId;
	sDatabase.Execute (query.str().c_str());

	// Store client settings: Insert into database
	//
	query.rdbuf()->str("");
	query << "INSERT INTO chars_data (uniqId, ownerChar, dataId, dataType, data) "\
		" VALUES (NULL, " << GetPlayer()->GetGUID() << ", " << dataId << ", 0, \"";

	char tmp[16];
	for (uint32 i = 0; i < dataLen; i++) {
		sprintf (tmp, "%02X", (int)dataPtr[i]);
		query << tmp;
	}

	query << "\");\n";
	sDatabase.Execute (query.str().c_str());

	delete dataPtr;
}
//-----------------------------------------------------------------------------------------
void WorldSession::HandlePetActionOpcode (WorldPacket & recvPacket)
{
	WorldPacket data;
	uint64 petGUID, TargetGUID;
	uint16 flags, flags2;
	recvPacket >> petGUID >> flags >> flags2;
	
	Creature *Pet = objmgr.GetObject<Creature>(petGUID);
	if(Pet == NULL)
	{
		Log::getSingleton().outError("Pet action not possible: Pet not found! guid %u", petGUID);
		return;
	}

	Log::getSingleton().outDebug("Pet action called! flags=%u flags2=%u for guid=%u", flags, flags2, petGUID);
	if(flags == 0x0002 && flags2 == 1792)
	{ // ATTACK
		recvPacket >> TargetGUID;
		Unit *TargetUnit = objmgr.GetObject<Creature>(TargetGUID);
		if(TargetUnit == NULL) TargetUnit = objmgr.GetObject<Player>(TargetGUID);
		if(TargetUnit == NULL) return;

		data.Initialize(SMSG_AI_REACTION);
		data << petGUID << uint32(00000002);
		SendPacket(&data);
		
		Pet->AddHate(TargetUnit, 1.0f);
		//Pet->AI_AttackReaction(world.GetCreature(unitTarget), 0); //TODO: find out if this is needed
	}
	else if(flags == 0x0001 && flags2 == 1792)
	{ // FOLLOW	
		Unit *Owner = objmgr.GetObject<Creature>(Pet->GetUInt64Value(UNIT_FIELD_SUMMONEDBY));
		if (Owner == NULL) Owner = objmgr.GetObject<Player>(Pet->GetUInt64Value(UNIT_FIELD_SUMMONEDBY));
		if (Owner == NULL) return;

		Pet->AI_Follow(Owner);

	}
	else if(flags == 0x0000 && flags2 == 1792)
	{ // STAY
		Pet->AI_StopFollow();
	}
	else if(flags2 == 256 || flags2 == 16640)
	{
		SpellEntry *proto = sSpellStore.LookupEntry( flags );
		if (proto == NULL) return;

		recvPacket >> TargetGUID;
		
		Unit* unit_target = objmgr.GetObject<Creature>(TargetGUID);
		if(unit_target == NULL) unit_target = objmgr.GetObject<Player>(TargetGUID);
		if(unit_target)
		{
			//TODO:check if the minion is allowed and able to cast

				Spell *spell = new Spell(Pet, proto, false, 0);
				SpellCastTargets targets;
				targets.m_unitTarget = TargetGUID;
				spell->prepare(&targets);
		}
	}/*
	else if(flags == 0 && flags2 == 1536)
	{//passive
		pet_caster->m_pet_state = 0;
	}
	else if(flags == 1 && flags2 == 1536)
	{//defensive
		pet_caster->m_pet_state = 1;
		//pet_caster->m_creatureState = MOVING;
		//pet_caster->setUpdateValue(UNIT_FIELD_TARGET,205);
	}
	else if(flags == 2 && flags2 == 1536)
	{//aggressive
		pet_caster->m_pet_state = 2;
	
	}*/
	else if(flags == 0x0003 && flags2 == 1792)
	{
		if(GetPlayer()->GetUInt64Value(UNIT_FIELD_SUMMON) != 0)//If there is already a summon
		{
			Creature *OldSummon = objmgr.GetObject<Creature>(petGUID);
			if(!OldSummon)
			{
				GetPlayer()->SetUInt64Value(UNIT_FIELD_SUMMON, 0);
				Log::getSingleton().outError("Warning!Summon could not be found!");
			}
			else
			{
				data.clear();
				data.Initialize(SMSG_DESTROY_OBJECT);
				data << OldSummon->GetGUID();
				OldSummon->SendMessageToSet (&data, true);

				//for (ObjectSet::iterator it = OldSummon->GetInRangeSetBegin(); it != OldSummon->GetInRangeSetEnd(); it++)
				//Object *o;
				//for (MapRangeIterator itr (OldSummon); o = itr.Advance(); )
				//	o->RemoveInRangeObject (OldSummon);

				if (OldSummon->GetMapCell()) 
				{
					OldSummon->GetMapCell()->RemoveObject (OldSummon);
//					OldSummon->GetMapCell()->RemoveInactive (OldSummon);
				}

				OldSummon->RemoveFromMap();
				OldSummon->RemoveFromWorld();
				OldSummon->DeleteFromDB();

				objmgr.RemoveObject_Free(OldSummon);
				GetPlayer()->SetUInt64Value(UNIT_FIELD_SUMMON, 0);
			}
		}

		data.clear();
		data.Initialize(SMSG_PET_SPELLS);
		data << (uint64)0;
		SendPacket(&data);
	}/*
	else
	{
		printf("WRONG FLAGS\n");
	}*/
}
//-----------------------------------------------------------------------------------------
void WorldSession::HandleSetAmmoOpcode(WorldPacket & recv_data)
{
	uint32 ammoId;
    recv_data >> ammoId;
    GetPlayer()->SetUInt32Value(PLAYER_AMMO_ID, ammoId);

    return;
}
//-----------------------------------------------------------------------------------------
void WorldSession::HandleGameObjectUseOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint64 guid;
    recv_data >> guid;

	Log::getSingleton( ).outDebug("WORLD: CMSG_GAMEOBJ_USE: [GUID %d]", guid);   

    GameObject *obj = objmgr.GetObject<GameObject>(guid);
	if (!obj) return;

	GetPlayer()->SetLootGUID(guid);
    
	data.Initialize(SMSG_LOOT_RESPONSE);

	if( obj->FillLoot(&data) ) {

		SendPacket(&data);
		Log::getSingleton( ).outDebug("WORLD: CMSG_GAMEOBJ_USE: [GUID %d] : LOOT COMPLETED.", guid);  
	
	}

}
//- Cinematic Handlers -------------------------------------------------------------------
void WorldSession::HandleCompleteCinema( WorldPacket & recv_data )
{
    Log::getSingleton( ).outDebug( "WORLD: CMSG_COMPLETE_CINEMATIC" );
}
void WorldSession::HandleNextCinematicCamera( WorldPacket & recv_data )
{
    Log::getSingleton( ).outDebug( "WORLD: CMSG_NEXT_CINEMATIC_CAMERA" );
}

// ---------------------------------------------------------------------------------------
void WorldSession::HandleBattlefieldStatusOpcode( WorldPacket & recv_data )
{
    Log::getSingleton( ).outDebug( "WORLD: CMSG_BATTLEFIELD_STATUS" );
}

// ---------------------------------------------------------------------------------------
void WorldSession::HandleMoveTimeSkippedOpcode( WorldPacket & recv_data )
{
    //Log::getSingleton( ).outDebug( "WORLD: CMSG_MOVE_TIME_SKIPPED" );
}

// ---------------------------------------------------------------------------------------
void WorldSession::HandleEnablePvP(WorldPacket& recvPacket)
{
    WorldPacket data;

    if ( (!GetPlayer()->isAlive()) || GetPlayer()->isInCombat()) 
    {
        data.Initialize(SMSG_CAST_RESULT);
        data << uint32(0);
        data << uint8(2);
        data << uint8(97);  
        SendPacket(&data);
        return;
    }

    if( GetPlayer()->HasFlag(UNIT_FIELD_FLAGS , 0x08) )
    {
        GetPlayer()->RemoveFlag(UNIT_FIELD_FLAGS , 0x08);
        GetPlayer()->pvp_status = false;
    }
    else
    {
        GetPlayer()->SetFlag(UNIT_FIELD_FLAGS , 0x08);
        GetPlayer()->pvp_status = true;
    }
}

// ---------------------------------------------------------------------------------------
// ! MUST BE REVISED
void WorldSession::HandleMooveRootAck(WorldPacket& recv_data) {

	Log::getSingleton( ).outDebug( "WORLD: CMSG_FORCE_MOVE_ROOT_ACK" );

	WorldPacket data;
    uint64 guid;
    recv_data >> guid;
}

// ---------------------------------------------------------------------------------------
// ! MUST BE REVISED
void WorldSession::HandleMooveUnRootAck(WorldPacket& recv_data) {

	Log::getSingleton( ).outDebug( "WORLD: CMSG_FORCE_MOVE_UNROOT_ACK" );

	WorldPacket data;
    uint64 guid;
    recv_data >> guid;
}

//--- END ---