#include "StdAfx.h"

#include "openssl/md5.h"
#include "../Shared/PacketBuilder.h"

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

// Flag Just Created: TRUE for newly created player, resets to FALSE when Logins further.
bool JUST_CREATED;

//-----------------------------------------------------------------------------
void WorldSession::HandleCharEnumOpcode( WorldPacket & recv_data )
{
    WorldPacket data;

	// i've found this packet in 1.8.0
	WorldPacket packet;
	packet.Initialize(SMSG_AUTH_RESPONSE2_UNKNOWN180);
	packet << uint8(0x00);
	for (int i=0; i<10; i++)
		packet << uint8(0x02) << uint8(0x01) << uint16(0) << uint32(0);
	SendPacket(&packet);

    // parse m_characters and build a mighty packet of
    // characters to send to the client.
    data.Initialize(SMSG_CHAR_ENUM);

    // loading characters
    std::stringstream ss;
    ss << "SELECT guid FROM characters WHERE acct=" << GetAccountId() << " ORDER BY guid";

    QueryResult* result = sDatabase.Query( ss.str().c_str() );
    uint8 num = 0;

    data << num;

    if( result )
    {
        Player *plr;
        do
        {
            plr = new Player;
            ASSERT(plr);

            plr->LoadFromDB( (*result)[0].GetUInt32() );
            plr->BuildEnumData( &data );

            delete plr;

            num++;
        }
        while( result->NextRow() );

        delete result;
    }

    data.put<uint8>(0, num);

    SendPacket( &data );
}

//-----------------------------------------------------------------------------
void WorldSession::HandleCharCreateOpcode( WorldPacket & recv_data )
{
    std::string name;
    WorldPacket data;

	// checking name:
	if (!CheckNameInPacket(&recv_data))
	{
		sLog.outError("Security check of name fails.");
		Make_CHAR_CREATION_ERROR_CODE(&data, CHAR_CREATE_FAILED);
        SendPacket( &data );
        return;
	}
    recv_data >> name;
    recv_data.rpos(0);

    std::stringstream ss;
    ss << "SELECT guid FROM characters WHERE name = '" << name << "'";
	
    QueryResult *result = sDatabase.Query( ss.str( ).c_str( ) );
    if (result)
    {
        delete result;
		Make_CHAR_CREATION_ERROR_CODE(&data, CHAR_CREATE_NAME_IN_USE);
        SendPacket( &data );
        return;
    }

    // loading characters
    ss.rdbuf()->str("");
    ss << "SELECT guid FROM characters WHERE acct=" << GetAccountId();
    result = sDatabase.Query( ss.str( ).c_str( ) );
    if (result)
    {
        if (result->GetRowCount() >= 10)
        {
			Make_CHAR_CREATION_ERROR_CODE(&data, CHAR_CREATE_FAILED);
            SendPacket( &data );
            delete result;
            return;
        }
        delete result;
    }

    Player * pNewChar = new Player;
    pNewChar->Create( objmgr.GenerateLowGuid(HIGHGUID_PLAYER), recv_data );
    pNewChar->SetSession(this); // we need account id
    pNewChar->SaveToDB();

	// Set JUST CREATED Flag
	JUST_CREATED = true;
	// Just in case to avoid Movie bug
	ss.rdbuf()->str("");
	ss << "UPDATE characters SET timestamp = " << (uint32)1 << ", online = 0 WHERE guid = " << pNewChar->GetGUID();
	sDatabase.Execute (ss.str().c_str());
	
	delete pNewChar;

	// Confirm OK
	Make_CHAR_CREATION_ERROR_CODE(&data, CHAR_CREATE_OK);
    SendPacket( &data );
}


// !!! WE MUST REVIEW ERROR CODES, THEY SHIFTED +1 ON 1.8.1 CLIENT !!!

/*
SMSG_CHAR_CREATE Error Codes:
0x01 Failure
0x02 Canceled
0x03 Disconnect from server
0x04 Failed to connect
0x05 Connected
0x06 Wrong client version
0x07 Connecting to server
0x08 Negotiating security
0x09 Negotiating security complete
0x0A Negotiating security complete
0x0B Authenticating
0x0C Authentication successful
0x0D Authentication failed
0x0E Login unavailable - Please contact Tech Support
0x0F Server is not valid
0x10 System unavailable
0x11 System error
0x12 Billing system error
0x13 Account billing has expired
0x14 Wrong client version
0x15 Unknown account
0x16 Incorrect password
0x17 Session expired
0x18 Server Shutting Down
0x19 Already logged in
0x1A Invalid login server
0x1B Position in Queue: 0
0x1C This account has been banned
0x1D This character is still logged on
0x1E Your WoW subscription has expired
0x1F This session has timed out
0x20 This account has been temporarily suspended
0x21 Retrieving realmlist
0x22 Realmlist retrieved
0x23 Unable to connect to realmlist server
0x24 Invalid realmlist
0x25 The game server is currently down
0x26 Creating account
0x27 Account created
0x28 Account creation failed
0x29 Retrieving character list
0x2A Character list retrieved
0x2B Error retrieving character list
0x2C Creating character
0x2D Character created
0x2E Error creating character
0x2F Character creation failed
0x30 Name already in use
0x31 Creation of that race/class is disabled
0x32 All characters on a PVP realm must be on the same team
0x33 Deleting character
0x34 Character deleted
0x35 Character deletion failed
0x36 Entering the WoW
0x37 Login successful
0x38 World server down
0x39 A character with that name already exists
0x3A No instance server available
0x3B Login failed
0x3C Login for that race/class is disabled
0x3D Enter a name for your character
0x3E Names must be atleast 2 characters long
0x3F Names must be no more then 12 characters
0x40 Names can only contain letters
0x41 Names must contain only one language
0x42 That name contains profanity
0x43 That name is reserved
0x44 You cannot use an apostrophe
0x45 You can only have one apostrophe
0x46 You cannot use the same letter three times consecutively
0x47 Invalid character name
0x48 <Blank>
All further codes give the number in dec.
*/

//-----------------------------------------------------------------------------
void WorldSession::HandleCharDeleteOpcode( WorldPacket & recv_data )
{
    WorldPacket data;

    uint64 guid;
    recv_data >> guid;

    Player* plr = new Player;
    ASSERT(plr);

    plr->LoadFromDB( GUID_LOPART(guid) );
    plr->DeleteFromDB();

    delete plr;

    Make_CHAR_CREATION_ERROR_CODE(&data, CHAR_DELETE_OK);
    SendPacket( &data );
}

//-----------------------------------------------------------------------------
void WorldSession::HandlePlayerLoginOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint64 playerGuid = 0;

    Log::getSingleton( ).outDebug( "WORLD: Recvd Player Logon Message" );

    recv_data >> playerGuid; // this is the GUID selected by the player

    Player* plr = new Player;
    ASSERT(plr);

    plr->LoadFromDB (GUID_LOPART(playerGuid));
    plr->SetSession (this);
    SetPlayer (plr);

	//------------------------------------------
	// SERVER --> SMSG_ACCOUNT_DATA_MD5
	//------------------------------------------
    data.Initialize( SMSG_ACCOUNT_DATA_MD5 );
    
	for(int i = 0; i < 80; i++)
        data << uint8(0);

	/*
	MD5_CTX md5context;
	for (int i = 0; i < 5; i++) 
	{
		std::stringstream query;

		query << "SELECT data FROM chars_data WHERE ownerChar=" << plr->GetGUID()
			<< " AND dataId=" << i;
		
		QueryResult *result = sDatabase.Query (query.str().c_str());

		if (result != NULL)
		{
			Field *fields = result->Fetch();
			int size = 0;
			char *buff = DecodeBinaryStr (fields[0].GetString(), size);

			MD5_Init (&md5context);
			MD5_Update (&md5context, (unsigned char *)buff, size);
			free (buff);

			unsigned char digest[16];
			MD5_Final (digest, &md5context);

			for (int j = 0; j < 16; j++)
				data << digest[j];
		} else 
		{
			data << uint64(0) << uint64(0);
		}
	}
	*/

    SendPacket(&data);

	//-------------------------------------------------
	// SERVER --> SMSG_FRIEND_LIST, SMSG_IGNORE_LIST
	//-------------------------------------------------
	//SendFriendList();

	//data.Initialize (SMSG_IGNORE_LIST);
	//data << uint8(0);
	//SendPacket (&data);

	//------------------------------------------
	// SERVER --> MESSAGE OF THE DAY
	//------------------------------------------
	SystemMessage (FULLSERVERNAME);

    std::string motd = "|c8f20af20";
	motd.append ((char *)sWorld.GetMotd());

	SystemMessage ("%s", motd.c_str());

	//------------------------------------------
	// SERVER --> SMSG_SET_REST_START
	//------------------------------------------

	///////////////////////////////////////////////////////
	// Update Time for CHARACTERS table
	// On Log off is used for RESTED state calculation, here for external PHP engines
	// to track player if it is On/Off Line >currenttime = ONLINE, <currenttime = OFFLINE
	
	// Read LOGOFF TIME
	std::stringstream ss;
    ss << "SELECT timestamp FROM characters WHERE guid = " << GetPlayer()->GetGUID();
    QueryResult* result = sDatabase.Query( ss.str().c_str() );
	Field *fields = result->Fetch();
	GetPlayer()->m_timeLogoff = fields[0].GetUInt32();
	delete result;

	// Set TIME OF LOGIN
	ss.rdbuf()->str("");
	ss << "UPDATE characters SET timestamp = " << (uint32)time(NULL) << ", online = 1 WHERE guid = " << GetPlayer()->GetGUID();
	sDatabase.Execute (ss.str().c_str());
	///////////////////////////////////////////////////////

    data.Initialize (SMSG_SET_REST_START);
    data << uint32(GetPlayer()->m_timeLogoff);
    SendPacket(&data);


	//------------------------------------------
	// SERVER --> SMSG_BINDPOINTUPDATE
	//------------------------------------------
	data.Initialize (SMSG_BINDPOINTUPDATE);
	data << plr->m_bindPointX << plr->m_bindPointY << plr->m_bindPointZ << plr->m_bindPointMap;
	data << plr->m_bindPointArea;
	SendPacket (&data);


	//------------------------------------------
	// SERVER --> SMSG_SET_PROFICIENCY
	//------------------------------------------
	switch (plr->GetClass())
	{
	case CLASS_MAGE:
		SendProficiency (0x04, 0x02);
		SendProficiency (0x02, 0x00, 0x04);
		SendProficiency (0x02, 0x00, 0x44);
		SendProficiency (0x04, 0x03);
		SendProficiency (0x02, 0x00, 0x44, 0x08);
		break;
	case CLASS_ROGUE:
		SendProficiency (0x04, 0x02);
		SendProficiency (0x02, 0x00, 0x00, 0x01);
		SendProficiency (0x04, 0x06);
		SendProficiency (0x02, 0x00, 0x80, 0x01);
		SendProficiency (0x02, 0x00, 0xC0, 0x01);
		SendProficiency (0x04, 0x07);
		break;
	case CLASS_WARRIOR:
		SendProficiency (0x04, 0x02);
		SendProficiency (0x02, 0x01);
		SendProficiency (0x02, 0x11);
		SendProficiency (0x04, 0x42);
		SendProficiency (0x04, 0x4A);
		SendProficiency (0x04, 0x4E);
		SendProficiency (0x02, 0x11, 0x40);
		SendProficiency (0x04, 0x4F);
		SendProficiency (0x02, 0x91, 0x40);
		break;
	case CLASS_PALADIN:
		SendProficiency (0x04, 0x02);
		SendProficiency (0x02, 0x10);
		SendProficiency (0x04, 0x42);
		SendProficiency (0x02, 0x30);
		SendProficiency (0x04, 0x4A);
		SendProficiency (0x04, 0x4E);
		SendProficiency (0x02, 0x30, 0x40);
		SendProficiency (0x04, 0x4F);
		break;
	case CLASS_WARLOCK:
		SendProficiency (0x04, 0x02);
		SendProficiency (0x02, 0x00, 0x80);
		SendProficiency (0x02, 0x00, 0xC0);
		SendProficiency (0x04, 0x03);
		SendProficiency (0x02, 0x00, 0xC0, 0x08);
		break;
	case CLASS_PRIEST:
		SendProficiency (0x04, 0x02);
		SendProficiency (0x02, 0x10);
		SendProficiency (0x02, 0x10, 0x40);
		SendProficiency (0x04, 0x03);
		SendProficiency (0x02, 0x10, 0x40, 0x08);
		break;
	case CLASS_DRUID:
		SendProficiency (0x04, 0x02);
		SendProficiency (0x02, 0x00, 0x04);
		SendProficiency (0x04, 0x06);
		SendProficiency (0x02, 0x00, 0x84);
		SendProficiency (0x02, 0x00, 0xC4);
		SendProficiency (0x04, 0x07);
		break;
	case CLASS_HUNTER:
		SendProficiency (0x04, 0x02);
		SendProficiency (0x02, 0x01);
		SendProficiency (0x04, 0x06);
		SendProficiency (0x02, 0x05);
		SendProficiency (0x02, 0x05, 0x40);
		SendProficiency (0x04, 0x07);
		break;
	case CLASS_SHAMAN:
		SendProficiency (0x04, 0x02);
		SendProficiency (0x02, 0x00, 0x04);
		SendProficiency (0x02, 0x10, 0x04);
		SendProficiency (0x04, 0x42);
		SendProficiency (0x04, 0x46);
		SendProficiency (0x02, 0x10, 0x44);
		SendProficiency (0x04, 0x47);
		break;
	}


	//---------------------------------------------
	// SERVER --> SAVED AURA DURATIONS, MODIFIERS
	//---------------------------------------------

	// SMSG_SET_PCT_SPELL_MODIFIER
	// SMSG_UPDATE_AURA_DURATION

	
	//------------------------------------------
	// SERVER --> SMSG_TUTORIAL_FLAGS
	//------------------------------------------
    data.Initialize( SMSG_TUTORIAL_FLAGS );
    
	for (int i = 0; i < 8; i++)
		data << uint32( GetPlayer()->GetTutorialInt(i) );
    
	SendPacket(&data);
    Log::getSingleton( ).outDebug( "WORLD: Sent tutorial flags." );

	//------------------------------------------
	// Proficiency table (continued)
	//------------------------------------------
	switch (plr->GetClass())
	{
	case CLASS_MAGE:
		SendProficiency (0x02, 0x00, 0x44, 0x08);
		SendProficiency (0x04, 0x03);
		break;
	case CLASS_ROGUE:
		SendProficiency (0x02, 0x00, 0xC0, 0x01);
		SendProficiency (0x04, 0x07);
		break;
	case CLASS_WARRIOR:
		SendProficiency (0x02, 0x91, 0x40);
		SendProficiency (0x04, 0x4F);
		break;
	case CLASS_PALADIN:
		SendProficiency (0x02, 0x30, 0x40);
		SendProficiency (0x04, 0x4F);
		break;
	case CLASS_WARLOCK:
		SendProficiency (0x02, 0x00, 0xC0, 0x08);
		SendProficiency (0x04, 0x03);
		break;
	case CLASS_PRIEST:
		SendProficiency (0x02, 0x10, 0x40, 0x08);
		SendProficiency (0x04, 0x03);
		break;
	case CLASS_DRUID:
		SendProficiency (0x02, 0x00, 0xC4);
		SendProficiency (0x04, 0x07);
		break;
	case CLASS_HUNTER:
		SendProficiency (0x02, 0x05, 0x40);
		SendProficiency (0x04, 0x07);
		break;
	case CLASS_SHAMAN:
		SendProficiency (0x02, 0x10, 0x44);
		SendProficiency (0x04, 0x47);
		break;
	}

	//------------------------------------------
    // SERVER --> Initial Spells
	//------------------------------------------
    GetPlayer()->SendInitialSpells();

	//------------------------------------------
    // SERVER --> Pet bar
	//------------------------------------------
	
	if(GetPlayer()->GetUInt64Value(UNIT_FIELD_SUMMON) != 0)
	{
		data.Initialize(SMSG_PET_SPELLS);
		data << (uint64)GetPlayer()->GetUInt64Value(UNIT_FIELD_SUMMON) << uint32(0x00000101) << uint32(0x00000000) << uint32(0x07000001) << uint32(0x07000002);
		data << uint32(0x02000000) << uint32(0x07000000) << uint32(0x04000000) << uint32(0x03000000) << uint32(0x06000002) << uint32(0x05000000);
		data << uint32(0x06000000) << uint32(0x06000001) << uint8(0x02)/*Number of spells*/ << uint32(0x0c26)/*SpellID1*/ << uint32(0x18a3)/*SpellID2*/;
		GetPlayer()->GetSession()->SendPacket(&data);
	}

	//------------------------------------------
    // SERVER --> SMSG_ACTION_BUTTONS
	//------------------------------------------
    data.Initialize (SMSG_ACTION_BUTTONS);

	for (int i = 0; i < 120; i++)
		data << GetPlayer()->m_actionsButtons[i];

    SendPacket( &data );

    // SMSG_INITIALIZE_FACTIONS

	uint32 repSize = 64;
	/*when byte=
		1:"AtWar" clickable but not checked
		3:"AtWar" clickable and checked
	*/
	data.Initialize (SMSG_INITIALIZE_FACTIONS);
	data << repSize;

	for (int i = 0; i < 64; i++)
	{
		data << GetPlayer()->m_reputation[i] << GetPlayer()->m_reputationValues[i];
	}

	SendPacket( &data );

	GetPlayer()->m_PVP_timer = 300000;

    // SMSG_EXPLORATION_EXPERIENCE

	data.Initialize(SMSG_CAST_RESULT);
	data << uint32(0x0999) << uint8(0x00);
	SendPacket( &data );

    data.Initialize(SMSG_LOGIN_SETTIMESPEED);
    time_t minutes = sWorld.GetGameTime( ) / 60;
    time_t hours = minutes / 60;
	minutes %= 60;
    time_t gameTime = minutes + ( hours << 6 );
    data << (uint32)gameTime;
    data << (float)0.017f;  // Normal Game Speed
    SendPacket( &data );

    // SMSG_UPDATE_AURA_DURATION -- if the player had an aura on when he logged out

    // Bojangles has Been up in here :0 Cinematics working Just need
    // the sound flags to kick off sound.
    // doesnt check yet if its the first login to run. *YET*
    // WantedMan fixed so it will only start if you are at starting loc

    data.Initialize( SMSG_TRIGGER_CINEMATIC );
    uint8 theRace = GetPlayer()->GetRace(); // get race

    //PlayerCreateInfo *info = objmgr.GetPlayerCreateInfo(theRace, 1);
    //ASSERT(info);

	Player *pCurrChar = GetPlayer();

	if (JUST_CREATED || pCurrChar->m_timeLogoff == 1) {

			switch (pCurrChar->GetRace())
			{
				case RACE_HUMAN:		data << uint32(81); break;
				case RACE_ORC:			data << uint32(21); break;
				case RACE_DWARF:		data << uint32(41); break;
				case RACE_NIGHT_ELF:	data << uint32(61); break;
				case RACE_UNDEAD:		data << uint32(2); break;
				case RACE_TAUREN:		data << uint32(141); break;
				case RACE_GNOME:		data << uint32(101); break;
				case RACE_TROLL:		data << uint32(121); break;
				
				default:				data << uint32(81);  // default to human movie
			}

		SendPacket( &data );
		JUST_CREATED = false; // Reset flag to avoid Movie after relogin in same sesion
	}
	
	// Exploration System
	pCurrChar->InitExploreSystem();

	// Now send all A9's
    // Add character to the ingame list
    // Build the in-range set
    // Send a message to other clients that a new player has entered the world
    // And let this client know we're in game
    objmgr.AddObject( pCurrChar );
    pCurrChar->PlaceOnMap();

	Log::getSingleton( ).outDetail( "WORLD: Created new player for existing players (%s)", pCurrChar->GetName() );

	// Green letters: NNN has entered the world.
	//
	std::string outstring = "|cdf20af20";
	outstring.append( pCurrChar->GetName() );
    outstring.append( "|c1f40af20 has entered the world." );
    sWorld.SendWorldText( outstring.c_str( ) );

	pCurrChar->SetSpeedMod (1.0f);
}

//-----------------------------------------------------------------------------
void WorldSession::HandleTutorialFlag( WorldPacket & recv_data )
{
	uint32 iFlag;
	recv_data >> iFlag;

	uint32 wInt = (iFlag / 32);
	uint32 rInt = (iFlag % 32);

	uint32 tutflag = GetPlayer()->GetTutorialInt( wInt );
	tutflag |= (1 << rInt);
	GetPlayer()->SetTutorialInt( wInt, tutflag );

	Log::getSingleton().outDebug("Received Tutorial Flag Set {%u}.", iFlag);
}

//-----------------------------------------------------------------------------
void WorldSession::HandleTutorialClear( WorldPacket & recv_data )
{
	for ( uint32 iI = 0; iI < 8; iI++)
		GetPlayer()->SetTutorialInt( iI, 0xFFFFFFFF );
}

//-----------------------------------------------------------------------------
void WorldSession::HandleTutorialReset( WorldPacket & recv_data )
{
	for ( uint32 iI = 0; iI < 8; iI++)
		GetPlayer()->SetTutorialInt( iI, 0x00000000 );
}

//-----------------------------------------------------------------------------
void WorldSession::HandleEnablePVPOpcode( WorldPacket & recv_data )
{
	//FLAGS probably: 1000 0 14 //?19
	if (!GetPlayer()->HasFlag(UNIT_FIELD_FLAGS, UNIT_FLAG_WAR_PLAYER))
	{
		GetPlayer()->SetFlag(UNIT_FIELD_FLAGS, UNIT_FLAG_WAR_PLAYER);
		GetPlayer()->m_PVP_timer = 300000;//5 minutes
		SystemMessage("PVP is now ON");
	}
	Log::getSingleton().outDebug("EnablePVP called");
}

//-----------------------------------------------------------------------------
void WorldSession::HandleMeetingStoneInfo( WorldPacket & recv_data)
{
	Log::getSingleton( ).outString( "WORLD:: CMSG_MEETING_STONE_INFO" );
    WorldPacket data;
	data.Initialize( SMSG_MEETING_STONE_INFO );
	data << uint32(0);
	data << uint32(0);
	data << uint32(0);
	SendPacket(&data);
}

//--- END ---
