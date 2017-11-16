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

#include "Common.h"
#include "Database/DatabaseEnv.h"
#include "WorldPacket.h"
#include "WorldSession.h"
#include "Opcodes.h"
#include "Log.h"
#include "World.h"
#include "ObjectMgr.h"
#include "Player.h"
#include "UpdateMask.h"
#include "Chat.h"
#include "Auth/md5.h"
#include "Affect.h"


void WorldSession::HandleCharEnumOpcode( WorldPacket & recv_data )
{    
	WorldPacket data;

	// parse m_characters and build a mighty packet of
	// characters to send to the client.
	data.Initialize(SMSG_CHAR_ENUM);

	// loading characters
	std::stringstream ss;
	ss << "SELECT guid FROM characters WHERE acct=" << GetAccountId();

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
			// added to catch an assertion failure at Player::LoadFromDB function.
			Log::getSingleton().outError("Loading char guid %d from account %d.",(*result)[0].GetUInt32(),GetAccountId());

			plr->LoadFromDB( (*result)[0].GetUInt32() );
            plr->LoadEnumFromDB();
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


void WorldSession::HandleCharCreateOpcode( WorldPacket & recv_data )
{
	std::string name;
	WorldPacket data;

	recv_data >> name;
	recv_data.rpos(0);

	std::stringstream ss;
	ss << "SELECT guid FROM characters WHERE name = '" << name << "'";

	QueryResult *result = sDatabase.Query( ss.str( ).c_str( ) );
	if (result)
	{
		delete result;
		data.Initialize(SMSG_CHAR_CREATE);
		data << (uint8)0x3B; // Error codes below
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
			data.Initialize(SMSG_CHAR_CREATE);
			data << (uint8)0x30; // Should be a better error code i think
			SendPacket( &data );
			delete result;
			return;
		}
		delete result;
	}

	Player * pNewChar = new Player;
	pNewChar->Create( objmgr.GenerateLowGuid(HIGHGUID_PLAYER), recv_data );
	pNewChar->SetSession(this); // we need account id
	pNewChar->UnSetBanned();
	pNewChar->addSpell(7266); // duel spell
	pNewChar->SaveToDB();

	PlayerInfo *pn = new PlayerInfo;
	pn->guid = pNewChar->GetGUID();
	pn->name = pNewChar->GetName();
	pn->cl = pNewChar->getClass();
	pn->race = pNewChar->getRace();
	pn->gender = pNewChar->getGender();

	objmgr.AddPlayerName(pn);

	delete pNewChar;

	data.Initialize( SMSG_CHAR_CREATE );
	data << (uint8)0x2E; // Error codes below
	SendPacket( &data );
}

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
0x21 Access to this account blocked by parental controls 
0x22 Retrieving realmlist
0x23 Realmlist retrieved
0x24 Unable to connect to realmlist server
0x25 Invalid realmlist
0x26 The game server is currently down
0x27 Creating account
0x28 Account created
0x29 Account creation failed
0x2A Retrieving character list
0x2B Character list retrieved
0x2C Error retrieving character list
0x2D Creating character
0x2E Character created
0x2F Error creating character
0x30 Character creation failed
0x31 Name already in use
0x32 Creation of that race/class is disabled
0x34 All characters on a PVP realm must be on the same team
0x35 Deleting character
0x36 Character deleted
0x37 Character deletion failed
0x38 Entering the WoW
0x39 Login successful
0x3A World server down
0x3B A character with that name already exists
0x3C No instance server available
0x3D Login failed
0x3E Login for that race/class is disabled
0x3F Enter a name for your character
0x40 Names must be atleast 2 characters long
0x41 Names must be no more then 12 characters
0x42 Names can only contain letters
0x43 Names must contain only one language
0x44 That name contains profanity
0x45 That name is reserved
0x46 You cannot use an apostrophe
0x47 You can only have one apostrophe
0x48 You cannot use the same letter three times consecutively
0x49 Invalid character name
0x4A <Blank>
All further codes give the number in dec.
*/

void WorldSession::HandleCharDeleteOpcode( WorldPacket & recv_data )
{
	WorldPacket data;

	uint64 guid;
	recv_data >> guid;

	Player* plr = new Player;
	ASSERT(plr);

	plr->LoadFromDB( GUID_LOPART(guid) );
	plr->DeleteFromDB();
	objmgr.RemovePlayerName(guid);
	//if charter leader
	guildCharter *gc = objmgr.GetGuildCharter(plr->GetGUID());
	if(gc)
	{
		Player *pMember;
		std::list<charterName>::iterator i;
		for(i = gc->signList.begin(); i != gc->signList.end(); i++)
		{
			pMember = objmgr.GetPlayer(i->signer);
			if(pMember)
			{
				//Charters
				pMember->DeleteFromSignedCharters( gc->itemGuid );
				pMember->DeleteAllCharterData();

				pMember->SaveToDB();
			}
			else
			{
				pMember = new Player();
				pMember->LoadFromDB(i->signer);

				//Charters
				pMember->DeleteFromSignedCharters( gc->itemGuid );
				pMember->DeleteAllCharterData();            

				pMember->SaveGuild();
				pMember->SaveCharters();

				delete pMember;
			}
		}
	}
	plr->DeleteFromSignedCharters(0);
	Guild *pGuild = objmgr.GetGuild(plr->GetGuildId());
	if(pGuild)
	{
		pGuild->DeleteGuildMember(plr->GetGUID());
	}

	delete plr;

	data.Initialize(SMSG_CHAR_CREATE);
	data << (uint8)0x34;
	SendPacket( &data );
}


void WorldSession::HandlePlayerLoginOpcode( WorldPacket & recv_data )
{
	WorldPacket data;
	uint64 playerGuid = 0;

	Log::getSingleton( ).outDebug( "WORLD: Recvd Player Logon Message" );

	recv_data >> playerGuid; // this is the GUID selected by the player

	Player* plr = new Player;
	ASSERT(plr);

	plr->LoadFromDB(GUID_LOPART(playerGuid));
	//plr->_RemoveAllItemMods(); 'dont think we need this since they are loaded from db anyway
	plr->SetSession(this);
	SetPlayer(plr); 

    plr->LoadPropertiesFromDB();

	//DK TradeStatus
	plr->SetTradeStatus(1);

	// account data == UI config
	data.Initialize( SMSG_ACCOUNT_DATA_MD5 );
	/*for (int i = 0; i < 5; i++)
	{
	std::stringstream ss;
	ss << "SELECT uiconfig" << i << " FROM accounts WHERE acct=" << GetAccountId();
	QueryResult* result = sDatabase.Query(ss.str().c_str());
	int j;
	if (!result)
	{
	for (int j = 0; j < 16; j++)
	data << uint8(0);
	}
	else
	{
	std::string dat;
	dat = result->Fetch()->GetString();
	if (strcmp(dat.c_str(), "") == 0)
	{
	for (int j = 0; j < 16; j++)
	data << uint8(0);
	continue;
	}
	md5_byte_t md5hash[16];
	md5_state_t state;
	md5_init(&state);
	md5_append(&state, (const md5_byte_t *)dat.c_str(), dat.length());
	md5_finish(&state, md5hash);
	data << md5hash;
	}
	}*/
	for(int i = 0; i < 80; i++)
		data << uint8(0);

	SendPacket(&data);

	// MOTD
	sChatHandler.FillSystemMessageData(&data, this, sWorld.GetMotd());
	SendPacket( &data );

	Log::getSingleton( ).outDebug( "WORLD: Sent motd (SMSG_MESSAGECHAT)" );

	// Read LOGOFF TIME
	std::stringstream ss;
	ss << "SELECT characters.timestamp FROM characters WHERE guid = " << GetPlayer()->GetGUID();
	QueryResult* result = sDatabase.Query( ss.str().c_str() );
	Field *fields = result->Fetch();
	GetPlayer()->m_timeLogoff = fields[0].GetUInt32();
	delete result;

	// Set TIME OF LOGIN
	ss.rdbuf()->str("");
	ss << "UPDATE characters SET online = 1 WHERE guid = " << GetPlayer()->GetGUID();
	sDatabase.Execute (ss.str().c_str());

	//Rest State
	data.Initialize (SMSG_SET_REST_START);
	data << uint32(GetPlayer()->m_timeLogoff);
	SendPacket(&data);

	//Tutorial Flags
	data.Initialize( SMSG_TUTORIAL_FLAGS );
	for (int i = 0; i < 8; i++)
		data << uint32( GetPlayer()->GetTutorialInt(i) );
	SendPacket(&data);

	Log::getSingleton( ).outDebug( "WORLD: Sent tutorial flags." );

	//Initial Spells
	GetPlayer()->smsg_InitialSpells();

	//Initial Actions
	GetPlayer()->smsg_InitialActions();

	//Factions
	GetPlayer()->smsg_InitialFactions();

	// SMSG_INITIALIZE_FACTIONS

	// SMSG_EXPLORATION_EXPERIENCE

	data.Initialize(SMSG_LOGIN_SETTIMESPEED);
	time_t minutes = sWorld.GetGameTime( ) / 60;
	time_t hours = minutes / 60; minutes %= 60;
	time_t gameTime = minutes + ( hours << 6 );
	data << (uint32)gameTime;
	data << (float)0.017f;  // Normal Game Speed
	SendPacket( &data );

	// Bojangles has Been up in here :0 Cinematics working Just need
	// the sound flags to kick off sound.
	// doesnt check yet if its the first login to run. *YET*
	// WantedMan fixed so it will only start if you are at starting loc

	data.Initialize( SMSG_TRIGGER_CINEMATIC );
	uint8 theRace = GetPlayer()->getRace(); // get race

	PlayerCreateInfo *info = objmgr.GetPlayerCreateInfo(theRace, 1);
	ASSERT(info);

	if (theRace == 1) // Human
	{
		if (GetPlayer()->m_positionX == info->positionX)
			if (GetPlayer()->m_positionY == info->positionY)
				if (GetPlayer()->m_positionZ == info->positionZ)
				{
					data << uint32(81);
					SendPacket( &data );
				}
	}

	if (theRace == 2) // Orc
	{
		if (GetPlayer()->m_positionX == info->positionX)
			if (GetPlayer()->m_positionY == info->positionY)
				if (GetPlayer()->m_positionZ == info->positionZ)
				{
					data << uint32(21);
					SendPacket( &data );
				}
	}

	if (theRace == 3) // Dwarf
	{
		if (GetPlayer()->m_positionX == info->positionX)
			if (GetPlayer()->m_positionY == info->positionY)
				if (GetPlayer()->m_positionZ == info->positionZ)
				{
					data << uint32(41);
					SendPacket( &data );
				}
	}
	if (theRace == 4) // Night Elves
	{
		if (GetPlayer()->m_positionX == info->positionX)
			if (GetPlayer()->m_positionY == info->positionY)
				if (GetPlayer()->m_positionZ == info->positionZ)
				{
					data << uint32(61);
					SendPacket( &data );
				}
	}
	if (theRace == 5) // undead <-- WORKING thats Correct
	{
		if (GetPlayer()->m_positionX == info->positionX)
			if (GetPlayer()->m_positionY == info->positionY)
				if (GetPlayer()->m_positionZ == info->positionZ)
				{
					data << uint32(2);
					SendPacket( &data );
				}
	}
	if (theRace == 6) // Tauren
	{
		if (GetPlayer()->m_positionX == info->positionX)
			if (GetPlayer()->m_positionY == info->positionY)
				if (GetPlayer()->m_positionZ == info->positionZ)
				{
					data << uint32(141);
					SendPacket( &data );
				}
	}
	if (theRace == 7) // Gnome
	{
		if (GetPlayer()->m_positionX == info->positionX)
			if (GetPlayer()->m_positionY == info->positionY)
				if (GetPlayer()->m_positionZ == info->positionZ)
				{
					data << uint32(101);
					SendPacket( &data );
				}
	}
	if (theRace == 8) // Troll
	{
		if (GetPlayer()->m_positionX == info->positionX)
			if (GetPlayer()->m_positionY == info->positionY)
				if (GetPlayer()->m_positionZ == info->positionZ)
				{
					data << uint32(121);
					SendPacket( &data );
				}
	}

	Player *pCurrChar = GetPlayer();

	objmgr.AddObject( pCurrChar );
	pCurrChar->AddToWorld();
	pCurrChar->PlaceItemsOnMap();

	// add skilllines from db
	for (uint16 sl = PLAYER_SKILL_INFO_1_1; sl < PLAYER_SKILL_INFO_1_1_381; sl += 3)
	{
		uint16 curr = 0, max = 0;
		uint32 id = pCurrChar->GetUInt32Value(sl);
		if (id == 0) continue;
		curr = (uint16)pCurrChar->GetUInt32Value(sl + 1);
		max = (uint16)(pCurrChar->GetUInt32Value(sl + 1) >> 16);
		pCurrChar->AddSkillLine(id, curr, max, false);
	}
	// end
	std::list<struct affloads>::iterator itr1;
	for (itr1 = pCurrChar->GetaffBegin(); itr1 != pCurrChar->GetaffEnd(); itr1++)
	{
		printf("setting dur to %u\n",itr1->dur);
		SpellEntry *spellInfo = sSpellStore.LookupEntry( itr1->id );
		Spell *spell = new Spell(pCurrChar, spellInfo,false, 0,true,true);
		WPAssert(spell);

		SpellCastTargets targets;
		targets.m_unitTarget = pCurrChar->GetGUID();
		spell->prepare(&targets);
		if (itr1->dur != 0)
		{
			pCurrChar->SetAffDuration(itr1->id,pCurrChar,itr1->dur);
			Affect* aff = pCurrChar->FindAff(itr1->id);
			WorldPacket data1;
			data1.Initialize(SMSG_UPDATE_AURA_DURATION);
			data1 << (uint8)aff->GetAuraSlot() << itr1->dur;
			pCurrChar->GetSession()->SendPacket(&data1);
		}

	}
	data.clear();
	data.Initialize(SMSG_BINDPOINTUPDATE);
	data << pCurrChar->GetBindPositionX();
	data << pCurrChar->GetBindPositionY();
	data << pCurrChar->GetBindPositionZ();
	data << pCurrChar->GetBindMapId();
	data << pCurrChar->GetZoneId();
	SendPacket( &data );
	Log::getSingleton( ).outDetail( "WORLD: Created new player for existing players (%s)", pCurrChar->GetName() );

	std::string outstring = pCurrChar->GetName();
	outstring.append( " has entered the world." );
	sWorld.SendWorldText( outstring.c_str( ) );

	//Calc Begining Armor
	pCurrChar->CalculateActualArmor();

	//Proficiences
	WorldPacket ppkt;
		
#define SendProficiency(b1,b2,b3,b4,b5) ppkt.clear(); \
	ppkt.Initialize(SMSG_SET_PROFICIENCY); \
	ppkt << (uint8)b1 << (uint8)b2 << (uint8)b3 << (uint8)b4 << (uint8)b5; \
	SendPacket(&ppkt);

	switch (pCurrChar->getClass())
	{
	case MAGE:
		SendProficiency (0x04, 0x02, 0x00, 0x00, 0x00);
		SendProficiency (0x02, 0x00, 0x04, 0x00, 0x00);
		SendProficiency (0x02, 0x00, 0x44, 0x00, 0x00);
		SendProficiency (0x04, 0x03, 0x00, 0x00, 0x00);
		SendProficiency (0x02, 0x00, 0x44, 0x08, 0x00);
		break;
	case ROGUE:
		SendProficiency (0x04, 0x02, 0x00, 0x00, 0x00);
		SendProficiency (0x02, 0x00, 0x00, 0x01, 0x00);
		SendProficiency (0x04, 0x06, 0x00, 0x00, 0x00);
		SendProficiency (0x02, 0x00, 0x80, 0x01, 0x00);
		SendProficiency (0x02, 0x00, 0xC0, 0x01, 0x00);
		SendProficiency (0x04, 0x07, 0x00, 0x00, 0x00);
		break;
	case WARRIOR:
		SendProficiency (0x04, 0x02, 0x00, 0x00, 0x00);
		SendProficiency (0x02, 0x01, 0x00, 0x00, 0x00);
		SendProficiency (0x02, 0x11, 0x00, 0x00, 0x00);
		SendProficiency (0x04, 0x42, 0x00, 0x00, 0x00);
		SendProficiency (0x04, 0x4A, 0x00, 0x00, 0x00);
		SendProficiency (0x04, 0x4E, 0x00, 0x00, 0x00);
		SendProficiency (0x02, 0x11, 0x40, 0x00, 0x00);
		SendProficiency (0x04, 0x4F, 0x00, 0x00, 0x00);
		SendProficiency (0x02, 0x91, 0x40, 0x00, 0x00);
		break;
	case PALADIN:
		SendProficiency (0x04, 0x02, 0x00, 0x00, 0x00);
		SendProficiency (0x02, 0x10, 0x00, 0x00, 0x00);
		SendProficiency (0x04, 0x42, 0x00, 0x00, 0x00);
		SendProficiency (0x02, 0x30, 0x00, 0x00, 0x00);
		SendProficiency (0x04, 0x4A, 0x00, 0x00, 0x00);
		SendProficiency (0x04, 0x4E, 0x00, 0x00, 0x00);
		SendProficiency (0x02, 0x30, 0x40, 0x00, 0x00);
		SendProficiency (0x04, 0x4F, 0x00, 0x00, 0x00);
		break;
	case WARLOCK:
		SendProficiency (0x04, 0x02, 0x00, 0x00, 0x00);
		SendProficiency (0x02, 0x00, 0x80, 0x00, 0x00);
		SendProficiency (0x02, 0x00, 0xC0, 0x00, 0x00);
		SendProficiency (0x04, 0x03, 0x00, 0x00, 0x00);
		SendProficiency (0x02, 0x00, 0xC0, 0x08, 0x00);
		break;
	case PRIEST:
		SendProficiency (0x04, 0x02, 0x00, 0x00, 0x00);
		SendProficiency (0x02, 0x10, 0x00, 0x00, 0x00);
		SendProficiency (0x02, 0x10, 0x40, 0x00, 0x00);
		SendProficiency (0x04, 0x03, 0x00, 0x00, 0x00);
		SendProficiency (0x02, 0x10, 0x40, 0x08, 0x00);
		break;
	case DRUID:
		SendProficiency (0x04, 0x02, 0x00, 0x00, 0x00);
		SendProficiency (0x02, 0x00, 0x04, 0x00, 0x00);
		SendProficiency (0x04, 0x06, 0x00, 0x00, 0x00);
		SendProficiency (0x02, 0x00, 0x84, 0x00, 0x00);
		SendProficiency (0x02, 0x00, 0xC4, 0x00, 0x00);
		SendProficiency (0x04, 0x07, 0x00, 0x00, 0x00);
		break;
	case HUNTER:
		SendProficiency (0x04, 0x02, 0x00, 0x00, 0x00);
		SendProficiency (0x02, 0x01, 0x00, 0x00, 0x00);
		SendProficiency (0x04, 0x06, 0x00, 0x00, 0x00);
		SendProficiency (0x02, 0x05, 0x00, 0x00, 0x00);
		SendProficiency (0x02, 0x05, 0x40, 0x00, 0x00);
		SendProficiency (0x04, 0x07, 0x00, 0x00, 0x00);
		break;
	case SHAMAN:
		SendProficiency (0x04, 0x02, 0x00, 0x00, 0x00);
		SendProficiency (0x02, 0x00, 0x04, 0x00, 0x00);
		SendProficiency (0x02, 0x10, 0x04, 0x00, 0x00);
		SendProficiency (0x04, 0x42, 0x00, 0x00, 0x00);
		SendProficiency (0x04, 0x46, 0x00, 0x00, 0x00);
		SendProficiency (0x02, 0x10, 0x44, 0x00, 0x00);
		SendProficiency (0x04, 0x47, 0x00, 0x00, 0x00);
		break;
	}

#undef SendProficiency

	// Calculate rested experience if there is time between lastlogoff and now
	uint32 currenttime = (uint32)time(NULL);
	float timediff = difftime(currenttime,GetPlayer()->m_timeLogoff);

	if(GetPlayer()->m_timeLogoff > 0)	// if timelogoff = 0 then it's the first login
	{
		if(GetPlayer()->m_isResting) {
			// We are resting at an inn, calculate XP and add it.
			uint32 RestXP = GetPlayer()->CalculateRestXP(timediff);
			GetPlayer()->AddRestXP(RestXP);
			Log::getSingleton( ).outDebug("REST: Added %d of rest XP.", RestXP);
			GetPlayer()->EnterInn();
		} else if(timediff > 0) {
			// We are resting in the wilderness at a slower rate.
			uint32 RestXP = GetPlayer()->CalculateRestXP(timediff);
			RestXP >>= 2;		// divide by 4 because its at 1/4 of the rate
			GetPlayer()->AddRestXP(RestXP);
		}
	}

	//Issue a message telling all guild members that this player has signed on
	if(pCurrChar->IsInGuild())
	{
		Guild *pGuild = objmgr.GetGuild( pCurrChar->GetGuildId() );
		if(pGuild)
		{
			WorldPacket data;
			data.Initialize(SMSG_GUILD_EVENT);
			data << uint8(GUILD_EVENT_MOTD);
			data << uint8(0x01);
			data << pGuild->GetGuildMotd();
			SendPacket(&data);

			data.clear();
			data.Initialize(SMSG_GUILD_EVENT);
			data << uint8(GUILD_EVENT_HASCOMEONLINE);
			data << uint8(0x01);
			data << pCurrChar->GetName();
			data << pCurrChar->GetGUID();
			pGuild->SendMessageToGuild(NULL,&data,G_MSGTYPE_ALL);
		}
	}

	// burlex: breathing
	GetPlayer()->m_Breath = 0;
	GetPlayer()->m_StartSwimHeight = 0;
	GetPlayer()->m_BreathingAir = 1;

}
