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

//////////////////////////////////////////////////////////////
/// This function handles CMSG_NAME_QUERY:
//////////////////////////////////////////////////////////////
void WorldSession::HandleNameQueryOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint64 guid;

    recv_data >> guid;

    uint32 race = 0, gender = 0, cl = 0;
    std::string name = "ERROR_NO_NAME_FOR_GUID";

    Player *pChar = objmgr.GetObject<Player>(guid);
    if (pChar == NULL)
    {
        if (!objmgr.GetPlayerNameByGUID(guid, name))
            Log::getSingleton( ).outError( "No player name found for this guid" );

        // TODO: load race, class, sex, etc from db
    }
    else
    {
        race = pChar->GetRace();
        gender = pChar->GetGender();
        cl = pChar->GetClass();
        name = pChar->GetName();
    }

    Log::getSingleton( ).outDebug( "Received CMSG_NAME_QUERY for: %s", name.c_str() );

    data.Initialize( SMSG_NAME_QUERY_RESPONSE );

    data << guid;
    data << name;
    data << race << gender << cl;

    SendPacket( &data );
}

//////////////////////////////////////////////////////////////
/// This function handles CMSG_QUERY_TIME:
//////////////////////////////////////////////////////////////
void WorldSession::HandleQueryTimeOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    data.Initialize( SMSG_QUERY_TIME_RESPONSE );

    data << (uint32)time(NULL);
    SendPacket( &data );
}

//////////////////////////////////////////////////////////////
/// This function handles CMSG_CREATURE_QUERY:
//////////////////////////////////////////////////////////////
void WorldSession::HandleCreatureQueryOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint32 entry;
    uint64 guid;
    CreatureTemplate *ct;

    recv_data >> entry;
    recv_data >> guid;

    ct = objmgr.GetCreatureTemplate (entry);
    Log::getSingleton( ).outDetail("WORLD: CMSG_CREATURE_QUERY '%s'", ct->Name.c_str());

    data.Initialize( SMSG_CREATURE_QUERY_RESPONSE );
    data << (uint32)entry;
    data << ct->Name.c_str();
    data << uint8(0) << uint8(0) << uint8(0);
    data << ct->Guild.c_str();	// Subname
    data << (uint32)0;			// unknown 1
    data << ct->Type;			// Creature Type
    data << (uint32)ct->Family; // unknown 3
    data << (uint32)ct->Elite;  // unknown 4
	data << (uint32)0;			// unknown (move before or after unknowns 3 and 4) don't know where exactly
    data << ct->Model;			// DisplayID

    SendPacket( &data );
}

//////////////////////////////////////////////////////////////
/// This function handles CMSG_GAMEOBJECT_QUERY:
//////////////////////////////////////////////////////////////
void WorldSession::HandleGameObjectQueryOpcode( WorldPacket & recv_data )
{

	Log::getSingleton().outDebug("WORLD: CMSG_GAMEOBJECT_QUERY ");

    WorldPacket data;
    data.Initialize( SMSG_GAMEOBJECT_QUERY_RESPONSE );
    uint32 entryID;
    uint64 guid;

    recv_data >> entryID;
    recv_data >> guid;

    GameObject* gameObj = objmgr.GetObject<GameObject>(guid);
	GameobjectTemplate *goT = objmgr.GetGameobjectTemplate (gameObj->GetEntry());

    if(!gameObj) return;

    std::string name = gameObj->GetName();

	Log::getSingleton( ).outDetail("WORLD: CMSG_GAMEOBJECT_QUERY '%u' ", guid);
   
    data << uint32(goT->Entry);
    data << uint32(goT->GType);
    data << uint32(goT->Model);
    data << name.c_str(); 
	data << uint8 (0); // closing 00 after Text
	data << uint8 (0); // unk
	data << uint8 (0); // unk
	data << uint8 (0); // unk
    data << uint32(goT->Sound[0]); // sound0
    data << uint32(goT->Sound[1]); // sound1
    data << uint32(goT->Sound[2]); // sound2
    data << uint32(goT->Sound[3]);
    data << uint32(goT->Sound[4]);
    data << uint32(goT->Sound[5]);
    data << uint32(goT->Sound[6]);
    data << uint32(goT->Sound[7]);
    data << uint32(goT->Sound[8]);
    data << uint32(goT->Sound[9]);
	data << uint32(goT->Sound[10]);// sound10
	data << uint32(0); // unk
	data << uint32(0); // unk
	data << uint32(0); // unk
	data << uint32(0); // unk
	data << uint32(0); // unk

    /*
    00 00 07 87 00 00 00 08 00 00 00 C0 54 F9 EC 01
    04 00 00 00 0A 00 00 00 12 00 00 00 00 00 00 08
    00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
    00 00 00 00 00 00 00 00 00 00 00 4F 52 44 45 52
    */

    /* Mailbox
    22 33 02 00 // ENTRY
    13 00 00 00 // Unknown
    8e 08 00 00 // Display_id
    4d 61 69 6c | 62 6f 78 00 // Mailbox (Null terminated)
    00 00 00 00 // 1
    00 00 00 00 // 2
    00 00 00 00 // 3
    00 00 00 00 // 4
    00 00 00 00 // 5
    00 00 00 00 // 6
    00 00 00 00 // 7
    00 00 00 00 // 8
    00 00 00 00 // 9
    00 00 00 00 // 10
    00 00 00    // 11
    */

    //WPAssert( data.size() == 64 );
    SendPacket( &data );
}

//////////////////////////////////////////////////////////////
/// This function handles MSG_CORPSE_QUERY:
//////////////////////////////////////////////////////////////
void WorldSession::HandleCorpseQueryOpcode(WorldPacket &recv_data)
{
    Log::getSingleton().outDetail("WORLD: Received MSG_CORPSE_QUERY");

    Corpse *pCorpse;
    WorldPacket data;

    pCorpse = objmgr.GetCorpseByOwner(GetPlayer());

    if(pCorpse)
    {
        data.Initialize(MSG_CORPSE_QUERY);
        data << uint8(0x01);
        data << pCorpse->GetMapId();
        data << pCorpse->GetPositionX();
        data << pCorpse->GetPositionY();
        data << pCorpse->GetPositionZ();
        data << uint32(0);
        SendPacket(&data);
    }
}

//////////////////////////////////////////////////////////////
/// This function handles CMSG_NPC_TEXT_QUERY:
//////////////////////////////////////////////////////////////
void WorldSession::HandleNpcTextQueryOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint32 textID;
    uint32 uField0, uField1;
    GossipText *pGossip;
	std::string GossipStr;

    recv_data >> textID;
    Log::getSingleton( ).outDetail("WORLD: CMSG_NPC_TEXT_QUERY ID '%u'", textID );

    recv_data >> uField0 >> uField1;
    GetPlayer()->SetUInt32Value(UNIT_FIELD_TARGET, uField0);
    GetPlayer()->SetUInt32Value(UNIT_FIELD_TARGET + 1, uField1);

	pGossip = objmgr.GetGossipText(textID);
	
    data.Initialize( SMSG_NPC_TEXT_UPDATE );
    data << textID;

	if (!pGossip)
	{
		data << uint32( 0 );
		data << "Greetings $N";
		data << "Greetings $N";
	} else

	for (int i=0; i<8; i++)
	{
		data << pGossip->parts[i].prob;
		data << pGossip->parts[i].Text0;

		if ( pGossip->parts[i].Text1 == "" )
			data << pGossip->parts[i].Text0; else
			data << pGossip->parts[i].Text1;

		data << pGossip->parts[i].lang;

		data << pGossip->parts[i].em[0].iDelay;
		data << pGossip->parts[i].em[0].iEmote;

		data << pGossip->parts[i].em[1].iDelay;
		data << pGossip->parts[i].em[1].iEmote;

		data << pGossip->parts[i].em[2].iDelay;
		data << pGossip->parts[i].em[2].iEmote;
	}

    SendPacket( &data );

    Log::getSingleton( ).outString( "WORLD: Sent SMSG_NPC_TEXT_UPDATE " );
}

//////////////////////////////////////////////////////////////
/// This function handles CMSG_PAGE_TEXT_QUERY:
//////////////////////////////////////////////////////////////
void WorldSession::HandlePageQueryOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint32 pageID;

    recv_data >> pageID;
    Log::getSingleton( ).outDetail("WORLD: Received CMSG_PAGE_TEXT_QUERY for pageID '%u'", pageID);
	
	while (pageID)
	{
		ItemPageText *pPage = objmgr.GetItemPageText( pageID );
		data.Initialize( SMSG_PAGE_TEXT_QUERY_RESPONSE );
		data << pageID;

		if (!pPage)
		{
			data << "The selected item page is missing!$b$bPlease report to Ludmilla Server Developers.";
			data << uint32(0);

			pageID = 0;
		} else
		{
			data << pPage->Text;
			data << uint32(pPage->NextPage);

			pageID = pPage->NextPage;
		}

		SendPacket( &data );

		Log::getSingleton( ).outString( "WORLD: Sent SMSG_PAGE_TEXT_QUERY_RESPONSE " );
	}
}

