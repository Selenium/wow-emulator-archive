//////////////////////////////////////////////////////////////////////
//  Chat Handler
//
//  Handles all messages with a chat-related opcode.
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
#include "Opcodes.h"
#include "Log.h"
#include "WorldServer.h"
#include "Character.h"
#include "UpdateMask.h"
#include "Database.h"

ChatCommand * ChatHandler::LoadHelp(bool load)
{
	static bool first_call = true;


	static ChatCommand adminCommandTable[7];
	static ChatCommand npcCommandTable[20];
	static ChatCommand moveCommandTable[9];
	static ChatCommand gmCommandTable[7];
	static ChatCommand usrCommandTable[13];
	static ChatCommand commandTable[16];


	if(first_call)
	{
		first_call = false;
		//ADMIN
		//		adminCommandTable[0].setValues("ban",         3, &ChatHandler::HandleBanCommand,           "",   NULL);//LINA FEATURE
		//		adminCommandTable[1].setValues("unban",       3, &ChatHandler::HandleUnBanCommand,         "",   NULL);//LINA FEATURE
		adminCommandTable[2].setValues("lvl",         3, &ChatHandler::HandleSecurityCommand,      "",   NULL);//LINA FEATUR
		adminCommandTable[3].setValues("addspirit",   3, &ChatHandler::HandleAddSpiritCommand,     "",   NULL);
		adminCommandTable[4].setValues("die",         3, &ChatHandler::HandleDieCommand,           "",   NULL);
		adminCommandTable[5].setValues("update",      3, &ChatHandler::HandleUpdateCommand,        "",   NULL);
		adminCommandTable[6].setValues(NULL,          0, NULL,                                     "",   NULL);

		//CREATOR
		npcCommandTable[0].setValues("info",        2, &ChatHandler::HandleGUIDCommand,          "",   NULL);
		npcCommandTable[1].setValues("mobs",        2, &ChatHandler::HandleSpawnCommand,         "",   NULL);
		npcCommandTable[2].setValues("taxi",        2, &ChatHandler::HandleSpawnTaxiCommand,     "",   NULL);
		npcCommandTable[3].setValues("spell",       2, &ChatHandler::HandleSpellCommand,         "",   NULL);
		npcCommandTable[4].setValues("rmvspell",    2, &ChatHandler::HandleRemoveSpellCommand,   "",   NULL);
		npcCommandTable[5].setValues("item",        2, &ChatHandler::HandleItemCommand,          "",   NULL);
		npcCommandTable[6].setValues("rmvitem",     2, &ChatHandler::HandleRemoveItemCommand,    "",   NULL);
		npcCommandTable[7].setValues("itemmove",    2, &ChatHandler::HandleItemMoveCommand,      "",   NULL);
		npcCommandTable[8].setValues("delete",      2, &ChatHandler::HandleDeleteCommand,        "",   NULL);
		npcCommandTable[9].setValues("level",       2, &ChatHandler::HandleChangeLevelCommand,   "",   NULL);//LINA FEATURE
		npcCommandTable[10].setValues("skin",       2, &ChatHandler::HandleDisplayIdCommand,     "",   NULL);
		npcCommandTable[11].setValues("faction",     2, &ChatHandler::HandleFactionIdCommand,     "",   NULL);
		npcCommandTable[12].setValues("name",        2, &ChatHandler::HandleNameCommand,          "",   NULL);//LINA FEATURE
		npcCommandTable[13].setValues("flag",        2, &ChatHandler::HandleNPCFlagCommand,       "",   NULL);
		npcCommandTable[14].setValues("animfreq",    3, &ChatHandler::HandleAnimFreqCommand,      "",   NULL);
		npcCommandTable[15].setValues("random",      2, &ChatHandler::HandleRandomCommand,        "",   NULL);
		npcCommandTable[16].setValues("addmove",     2, &ChatHandler::HandleAddMoveCommand,       "",   NULL);
		npcCommandTable[17].setValues("run",         2, &ChatHandler::HandleRunCommand,           "",   NULL);
		npcCommandTable[18].setValues("state",       2, &ChatHandler::HandleAggressiveCommand,    "",   NULL);
		npcCommandTable[19].setValues(NULL,          0, NULL,                                     "",   NULL);


		//MOVE
		moveCommandTable[0].setValues("where",       1, &ChatHandler::HandleGPSCommand,           "",   NULL);
		moveCommandTable[1].setValues("there",       1, &ChatHandler::HandleAppearCommand,        "",   NULL);
		moveCommandTable[2].setValues("here",        1, &ChatHandler::HandleSummonCommand,        "",   NULL);
		moveCommandTable[3].setValues("fast",        2, &ChatHandler::HandleMoveCommand,          "",   NULL);
		moveCommandTable[4].setValues("world",       3, &ChatHandler::HandleWorldPortCommand,     "",   NULL);
		moveCommandTable[5].setValues("town",        1, &ChatHandler::HandleRecallCommand,        "",   NULL);
		moveCommandTable[6].setValues("prog",        2, &ChatHandler::HandleProgCommand,          "",   NULL);
		moveCommandTable[7].setValues("isle",        1, &ChatHandler::HandleIsleCommand,          "",   NULL);
		moveCommandTable[8].setValues(NULL,          0, NULL,                                     "",   NULL);

		//GM
		gmCommandTable[0].setValues("pass",        1, &ChatHandler::HandleGMPassCommand,        "",   NULL);//LINA FEATURE
		gmCommandTable[1].setValues("off",         1, &ChatHandler::HandleGMOffCommand,         "",   NULL);
		gmCommandTable[2].setValues("on",          1, &ChatHandler::HandleGMOnCommand,          "",   NULL);
		//		gmCommandTable[3].setValues("kick",        1, &ChatHandler::HandleKickCommand,          "",   NULL);//LINA FEATURE
		gmCommandTable[4].setValues("save",        1, &ChatHandler::HandleSaveAllCommand,       "",   NULL);//LINA FEATURE
		gmCommandTable[5].setValues("announce",    1, &ChatHandler::HandleAnnounceCommand,      "",   NULL);
		gmCommandTable[6].setValues(NULL,          0, NULL,                                     "",   NULL);

		//CHANGE
		usrCommandTable[0].setValues("hp",          1, &ChatHandler::HandleModifyHPCommand,			"",   NULL);
		usrCommandTable[1].setValues("mana",        1, &ChatHandler::HandleModifyManaCommand,		"",   NULL);
		usrCommandTable[2].setValues("gold",        1, &ChatHandler::HandleModifyGoldCommand,		"",   NULL);
		usrCommandTable[3].setValues("lvl",         1, &ChatHandler::HandleModifyLevelCommand,		"",   NULL);
		usrCommandTable[4].setValues("speed",       1, &ChatHandler::HandleModifySpeedCommand,		"",   NULL);
		usrCommandTable[5].setValues("wspeed",      1, &ChatHandler::HandleModifyWaterSpeedCommand,	"",   NULL);//LINA FEATURE
		usrCommandTable[6].setValues("scale",       1, &ChatHandler::HandleModifyScaleCommand,		"",   NULL);//LINA FEATURE
		usrCommandTable[7].setValues("mount",       1, &ChatHandler::HandleModifyMountCommand,		"",   NULL);
		usrCommandTable[8].setValues("exp",         1, &ChatHandler::HandleModifyExpCommand,		"",   NULL);
		usrCommandTable[9].setValues("aura",        3, &ChatHandler::HandleAuraCommand,				"",   NULL);
		usrCommandTable[10].setValues("spell",       3, &ChatHandler::HandleLearnCommand,			"",   NULL);
		usrCommandTable[11].setValues("skin",       3, &ChatHandler::HandleMorphCommand,			"",   NULL);
		usrCommandTable[12].setValues(NULL,         0, NULL,										"",   NULL);

		//MAIN
		commandTable[0].setValues("help",        0, &ChatHandler::HandleHelpCommand,          "",   NULL);
		commandTable[1].setValues("commands",    0, &ChatHandler::HandleCommandsCommand,      "",   NULL);
		commandTable[2].setValues("info",        0, &ChatHandler::HandleInfoCommand,          "",   NULL);
		commandTable[3].setValues("dismount",    0, &ChatHandler::HandleDismountCommand,      "",   NULL);
		commandTable[4].setValues("mount",       0, &ChatHandler::HandleMountCommand,         "",   NULL);
		commandTable[5].setValues("save",        0, &ChatHandler::HandleSaveCommand,          "",   NULL);//LINA FEATURE
		commandTable[6].setValues("start",       0, &ChatHandler::HandleStartCommand,         "",   NULL);
		commandTable[7].setValues("list",        0, &ChatHandler::HandleGMListCommand,        "",   NULL);
		commandTable[8].setValues("acct",        0, &ChatHandler::HandleAcctCommand,          "",   NULL);
		commandTable[9].setValues("login",       0, &ChatHandler::HandleGMLoginCommand,       "",   NULL);
		commandTable[10].setValues("usr",        1, NULL,                                     "",   usrCommandTable);
		commandTable[11].setValues("gm",         1, NULL,                                     "",   gmCommandTable);
		commandTable[12].setValues("move",		 1, NULL,                                     "",   moveCommandTable);
		commandTable[13].setValues("npc",        2, NULL,                                     "",   npcCommandTable);
		commandTable[14].setValues("admin",      3, NULL,                                     "",   adminCommandTable);
		commandTable[15].setValues(NULL,         0, NULL,                                     "",   NULL);
	}

	if(load)
	{
		DatabaseInterface *dbi = DATABASE.createDatabaseInterface( );

		for(uint32 i = 0; commandTable[i].Name != NULL; i++)
		{
			dbi->loadChatCommand(commandTable[i].Name, &commandTable[i]);

			if(commandTable[i].ChildCommands != NULL)
			{
				ChatCommand *ptable = commandTable[i].ChildCommands;
				for(uint32 j = 0; ptable[j].Name != NULL; j++)
				{
					std::string str = commandTable[i].Name;
					str += " ";
					str += ptable[j].Name;
					dbi->loadChatCommand(str.c_str(), &ptable[j]);
				}
			}
		}

		DATABASE.removeDatabaseInterface(dbi);
	}
	return commandTable;
}

bool ChatHandler::hasStringAbbr(const char* s1, const char* s2)
{
	for(;;)
	{
		if( !*s2 )
			return true;
		else if( !*s1 )
			return false;
		else if( tolower( *s1 ) != tolower( *s2 ) )
			return false;
		s1++; s2++;
	}
}


void ChatHandler::SendMultilineMessage(const char *str)
{
	char buf[256];
	NetworkPacket data;

	const char* line = str;
	const char* pos = line;
	while((pos = strchr(line, '\n')) != NULL)
	{
		strncpy(buf, line, pos-line);
		buf[pos-line]=0;

		FillMessageData(&data, 0x09, m_pClient, (uint8*)buf);
		m_pClient->SendMsg(&data);

		line = pos+1;
	}

	FillMessageData(&data, 0x09, m_pClient, (uint8*)line);
	m_pClient->SendMsg(&data);
}

bool ChatHandler::ExecuteCommandInTable(ChatCommand *table, uint8* text)
{
	char *cmd = (char*)text;
	uint32 AcctLvl = m_pClient->getAccountLvl();

	while (*text != ' ' && *text != '\0') text++; // skip command
	if(*text != '\0')
	{
		*text = '\0';
		text++;
	}

	while (*text == ' ') text++; // skip whitespace

	if(*cmd == '\0')
		return false;

	for(uint32 i = 0; table[i].Name != NULL; i++)
	{
		if(!hasStringAbbr(table[i].Name, cmd))
			continue;

		if(AcctLvl < table[i].SecurityLevel)
			continue;

		if(table[i].ChildCommands != NULL)
		{
			if(!ExecuteCommandInTable(table[i].ChildCommands, text))
			{
				if(table[i].Help != "")
					SendMultilineMessage(table[i].Help.c_str());
				else
				{
					NetworkPacket data;
					FillMessageData(&data, 0x09, m_pClient, (uint8*)"There is no such subcommand.");
					m_pClient->SendMsg(&data);
				}
			}
			return true;
		}

		if(!(this->*(table[i].Handler))(text))
		{
			if(table[i].Help != "")
				SendMultilineMessage(table[i].Help.c_str());
			else
			{
				NetworkPacket data;
				FillMessageData(&data, 0x09, m_pClient, (uint8*)"Incorrect syntax.");
				m_pClient->SendMsg(&data);
			}
		}
		return true;
	}
	return false;
}

int ChatHandler::ParseCommands(uint8* text, uint16 text_length)
{
	(void)text_length;
	assert(text);
	//    assert(*text);

	if(text[0] != '!' && text[0] != '.') // let's not confuse users
		return 0;
	text++;

	if(!ExecuteCommandInTable(LoadHelp(false), text))
	{
		NetworkPacket data;
		FillMessageData(&data, 0x09, m_pClient, (uint8*)"There is no such command.");
		m_pClient->SendMsg(&data);
	}

	return 1;
}

void ChatHandler::HandleMsg( NetworkPacket & recv_data, GameClient *pClient )
{
	NetworkPacket data;
	char f[256];
	sprintf(f, "WORLD: Chat Opcode 0x%.4X", recv_data.opcode);
	LOG.outString( f );
	switch (recv_data.opcode)
	{
		case CMSG_MESSAGECHAT:
			{
				uint16 text_length = strlen((char*)recv_data.data+8)+1;

				m_pClient = pClient;
				if (ParseCommands(recv_data.data+8, text_length) > 0)
					return;

				uint8 text_mode = recv_data.data[0];
				FillMessageData( &data, text_mode, pClient, recv_data.data+8 );

				if (text_mode != CHAT_MSG_WHISPER) { // whisper message send in FillMessageData
					pClient->SendMsg( &data );
					WORLDSERVER.SendGlobalMessage(&data, pClient);
				}
			}break;
		case CMSG_TEXT_EMOTE:
			{
				uint32 text_emote, guid1, guid2;
				recv_data.ReadData(text_emote);
				recv_data >> guid1 >> guid2;

				char *nam=0; uint16 namlen=0;
				WorldServer::CharacterMap::iterator chariter;
				WorldServer::CreatureMap::iterator npciter;
				if( ( npciter = WORLDSERVER.mCreatures.find( guid1 ) ) != WORLDSERVER.mCreatures.end( ) ) {
					nam = npciter->second->getCreatureName( );
					namlen = strlen( nam ) + 1;
				} else if( ( chariter = WORLDSERVER.mCharacters.find( guid1 ) ) != WORLDSERVER.mCharacters.end( ) ) {
					nam = chariter->second->getName( );
					namlen = strlen( nam ) + 1;
				}

				data.Clear();
				data.Initialize(12, SMSG_EMOTE);

				uint8 emote_anim = WORLDSERVER.mEmotes[uint8(text_emote&0xff)];

				data << (uint8)emote_anim;
				data << (uint8)0x00;
				data << (uint8)0x00;
				data << (uint8)0x00;

				guid mguid = pClient->getCurrentChar()->getGUID();
				data << mguid.sno << (uint8)0x00 << (uint8)0x00 << (uint8)0x00 << (uint8)0x00;
				WORLDSERVER.SendGlobalMessage (&data);

				data.Clear ();
				data.SetLength (12 + namlen);
				data.opcode = SMSG_TEXT_EMOTE;

				memcpy (data.data, &mguid.sno, 4);
				data.data [4] = 0x00;
				data.data [5] = 0x00;
				data.data [6] = 0x00;
				data.data [7] = 0x00;

				memcpy (data.data + 8,recv_data.data,4);

				if( namlen > 0 )
					memcpy( data.data + 12, nam, namlen );

				pClient->SendMsg( &data );
				WORLDSERVER.SendGlobalMessage(&data, pClient);
			} break;
	}
}

void ChatHandler::FillMessageData( NetworkPacket *data, uint8 type, GameClient* pClient, uint8 *text )
{

	// !!!! Be careful using strlen to determine the size of the chat message.
	// A CHAT_MSG_WHISPER sends TWO null terminated  strings(first the name of
	// the whisper target, then the message) and doing strlen only finds the
	// length of the first string.  -- DeathCheese

	const uint8 msgchat_header_size=13;
	uint8 msgchat_header[msgchat_header_size] = {type,
		0x00, 0x00, 0x00, 0x00}; //no idea what are those bytes for

	// add guid to message header
	guid mguid;
	if (pClient)
                mguid = pClient->getCurrentChar()->getGUID();
        else
                mguid.Set (0, 0);
	memcpy (msgchat_header + 5, &mguid.sno, 4);
	msgchat_header[9] = 0x00;
	msgchat_header[10] = 0x00;
	msgchat_header[11] = 0x00;
	msgchat_header[12] = 0x00;

	data->Clear();

	std::string logoutput = "CHAT: ";
	if( pClient ) {
		logoutput += pClient->getCurrentChar( )->getName( );
		logoutput += ": ";
	}

	uint32 length = strlen((char*)text) + 1;
	//	data.Initialize(length+msgchat_header_size+5 , SMSG_MESSAGECHAT);
	if (type == CHAT_MSG_WHISPER){
		// Whisper Chat:  Server receives two strings.  First is the target of whisper, second is the message.
		uint16 msg_length = strlen((char*)text+length) + 1;

		data->SetLength(msgchat_header_size + msg_length + 1);
		data->opcode = SMSG_MESSAGECHAT;
		memcpy(data->data, msgchat_header, msgchat_header_size);
		memcpy(data->data+msgchat_header_size, text+length, msg_length);
		data->data[msgchat_header_size+msg_length] = 0; //NULL terminated string
		logoutput += "->";
		logoutput += (char *)text;
		logoutput += "<- ";
		logoutput += (char *)(text + length);
	}
	else{

		data->SetLength(msgchat_header_size + length + 5);
		data->opcode = SMSG_MESSAGECHAT;

		memcpy(data->data,msgchat_header,msgchat_header_size);
		memcpy(data->data+13, &length, 4);
		memcpy(data->data+17, text, length);
		data->data[msgchat_header_size+length+4] = 0; //NULL terminated string
		logoutput += (char *)text;
	}

	LOG.outString( logoutput.c_str( ) );

	// The last byte is most likely a flag, 0 or 1, denoting on or off
	uint8 byte = 0x00;
	if(type == CHAT_MSG_AFK && pClient!=0) { // toggle AFK
		byte = pClient->getCurrentChar()->ToggleAFK();
	}

	data->data[data->length-1] = byte;

	if (type == CHAT_MSG_WHISPER){
		// save the whisper TO name
		char name[22];
		memcpy(name, text, length);
		WORLDSERVER.SendMessageToPlayer(data, (char*)name); // slightly hackish I guess
	}
}

void ChatHandler::SpawnCreature(GameClient *pClient, char* pName, uint32 display_id, uint32 npcFlags, uint32 faction_id, uint32 level)
{
	NetworkPacket data;

	// Create the requested monster
	Character *chr = pClient->getCurrentChar();
	float x = chr->getPositionX();
	float y = chr->getPositionY();
	float z = chr->getPositionZ();
	float o = chr->getOrientation();

	Unit* pUnit = new Unit();
	UpdateMask unitMask;
	WorldServer::getSingletonPtr()->mObjectMgr.SetCreateUnitBits(unitMask);

	pUnit->Create(WORLDSERVER.m_hiCreatureGuid++, (uint8*)pName, x, y, z, o);
	pUnit->setMapId(chr->getMapId());
	pUnit->setZone(chr->getZone());
	data.Clear();
	pUnit->setUpdateValue(OBJECT_FIELD_ENTRY, WORLDSERVER.addCreatureName((uint8*)pUnit->getCreatureName()));
	pUnit->setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 1.0f);
	pUnit->setUpdateValue(UNIT_FIELD_DISPLAYID, display_id);
	pUnit->setUpdateValue(UNIT_NPC_FLAGS , npcFlags);
	pUnit->setUpdateValue(UNIT_FIELD_FACTIONTEMPLATE , faction_id);
	float fLevel = (float) level;	// avoid casting all over the place
	pUnit->setUpdateValue(UNIT_FIELD_HEALTH, (uint32)((1.24*fLevel*fLevel)+(1.79*fLevel)+40.64) );
	pUnit->setUpdateValue(UNIT_FIELD_MAXHEALTH, (uint32)((1.24*fLevel*fLevel)+(1.79*fLevel)+40.64) );
	pUnit->setUpdateValue(UNIT_FIELD_LEVEL , level);

	pUnit->setUpdateFloatValue(UNIT_FIELD_COMBATREACH , 1.5f);
	pUnit->setUpdateFloatValue(UNIT_FIELD_MINDAMAGE ,  4.0f+fLevel);			// 5,6, 7, 8, 9,10
	pUnit->setUpdateFloatValue(UNIT_FIELD_MAXDAMAGE , 4.0f+fLevel+fLevel);		// 6,8,10,12,14,16
	pUnit->setUpdateValue(UNIT_FIELD_BASEATTACKTIME, 1900);
	pUnit->setUpdateValue(UNIT_FIELD_BASEATTACKTIME+1, 2000);
	pUnit->setUpdateFloatValue(UNIT_FIELD_BOUNDINGRADIUS, 2.0f);

	pUnit->CreateObject(&unitMask, &data, 0);

	// add to the world list of creatures
	WPAssert (pUnit->getGUID().Assigned ());
	WORLDSERVER.mCreatures [pUnit->getGUID().sno] = pUnit;

	// send create message to everyone
	WORLDSERVER.SendGlobalMessage(&data);

	DatabaseInterface *dbi = DATABASE.createDatabaseInterface( );
	dbi->saveCreature(pUnit);
	DATABASE.removeDatabaseInterface(dbi);
}

void ChatHandler::smsg_NewWorld(GameClient *pClient, uint16 c, float x, float y, float z)
{
	NetworkPacket data;
	WorldServer::CreatureMap creatures = WORLDSERVER.getCreatureMap();
	WorldServer::CharacterMap characters = WORLDSERVER.getCharacterMap();

	data.Initialize(4, SMSG_TRANSFER_PENDING);
	data << uint32(0);

	pClient->SendMsg(&data);

	// Build a NEW WORLD packet
	data.Initialize(20, SMSG_NEW_WORLD);
	data << (uint32)c << (float)x << (float)y << (float)z << (float)0.0f;
	pClient->SendMsg( &data );

	/*
	// Destroy this client's player from all clients (including self)
	uint32 guid = pClient->getCurrentChar()->getGUID();
	data.Initialize(SMSG_DESTROY_OBJECT);
	data << (uint32)guid << (uint8)0x00 << (uint8)0x00 << (uint8)0x00 << (uint8)0x00;
	WPAssert(data.getLength() == 8);
	pClient->SendMsg(&data);

	for( WorldServer::CreatureMap::iterator i = creatures.begin( ); i != creatures.end( ); ++ i )
	{
	uint32 guid = i->second->getGUID();
	data.Initialize(SMSG_DESTROY_OBJECT);
	data << (uint32)guid << i->second->getGUIDHigh();
	WPAssert(data.getLength() == 8);
	pClient->SendMsg(&data);
	}
	*/

	// Destroy ourselves from other clients
	guid mguid = pClient->getCurrentChar()->getGUID();
	data.Initialize(8, SMSG_DESTROY_OBJECT );
	data << mguid.sno << (uint8)0x00 << (uint8)0x00 << (uint8)0x00 << (uint8)0x00;
	pClient->getCurrentChar()->SendMessageToSet(&data, true);

	// Remove ourselves from inrange lists
	for( WorldServer::CharacterMap::iterator iter = characters.begin( ); iter != characters.end( ); ++ iter )
		iter->second->RemoveInRangeObject( pClient->getCurrentChar() );

	for( WorldServer::CreatureMap::iterator iter = creatures.begin( ); iter != creatures.end( ); ++ iter )
		iter->second->RemoveInRangeObject( pClient->getCurrentChar() );

	pClient->getCurrentChar()->ClearInRangeSet();

	pClient->getCurrentChar()->setMapId(c);

	pClient->getCurrentChar()->setNewPosition(x,y,z);
	pClient->getCurrentChar()->setPosition(8000,8000,0,0,true);
}

void ChatHandler::MovePlayer(GameClient *pClient, float x, float y, float z)
{
	NetworkPacket data;

	//Output new position to the console
	uint8 txtBuffer[512];
	sprintf((char*)txtBuffer,"WORLD: Moved player to (%f, %f, %f)",x,y,z );
	LOG.outString( (char*)txtBuffer );

	sprintf((char*)txtBuffer,"You have been moved to (%f, %f, %f)",x,y,z );
	FillMessageData(&data, 0x09, pClient, txtBuffer);
	pClient->SendMsg( &data );

	////////////////////////////////////////
	//Set the new position of the character
	Character *chr = pClient->getCurrentChar();

	//Send new position to client via MSG_MOVE_TELEPORT_ACK
	chr->TeleportAck(&data, x,y,z);
	pClient->SendMsg(&data);

	//////////////////////////////////
	//Now send new position of this player to all clients using MSG_MOVE_HEARTBEAT
	chr->BuildHeartBeat(&data);
	WORLDSERVER.SendGlobalMessage(&data, pClient);
}

Character * ChatHandler::getCurrentCharByName(uint8 * pName)
{
	WorldServer::ClientSet::iterator itr;
	for (itr = WORLDSERVER.mClients.begin(); itr != WORLDSERVER.mClients.end(); itr++)
	{
		if( strcmp(((GameClient*)(*itr))->getCharacterName(), (char*)pName) == 0 )
		{
			return ((GameClient*)(*itr))->getCurrentChar();
		}
	}
	NetworkPacket data;
	uint8 buf[256];
	sprintf((char*)buf,"Character (%s) does not exist or is not logged in.", (char*)pName);
	FillMessageData(&data, 0x09, m_pClient, buf);
	m_pClient->SendMsg( &data );
	return NULL;
}

Character *ChatHandler::getSelectedChar()
{
	guid mguid;
	NetworkPacket data;

	Character *chr = m_pClient->getCurrentChar();
	mguid = chr->getSelection ();
	if (mguid.Assigned ())
	{
		if (mguid.type == 0)
			chr = WORLDSERVER.GetCharacter (mguid.sno);
		else
		{
			FillMessageData(&data, 0x09, m_pClient,(uint8*) "Please select a User.");
			m_pClient->SendMsg( &data );
		}
	}
	else
	{
		FillMessageData (&data, 0x09, m_pClient,(uint8*) "AutoSelection.");
		m_pClient->SendMsg (&data);
	}
	return chr;
}

//UINT32
int32 ChatHandler::TestValue(const float Value, const float max, const float min)
{
	if(Value<min || Value>max)
	{
		NetworkPacket data;
		FillMessageData(&data, 0x09, m_pClient,(uint8*)"Invalid Value.");
		m_pClient->SendMsg( &data );
		return 0;
	}
	return 1;
}

//FLOAT
int32 ChatHandler::TestValue(const uint32 Value, const uint32 max, const uint32 min)
{
	if(Value<min || Value>max)
	{
		NetworkPacket data;
		FillMessageData(&data, 0x09, m_pClient,(uint8*)"Invalid Value.");
		m_pClient->SendMsg( &data );
		return 0;
	}
	return 1;
}
//FLOAT
void ChatHandler::ChangeSelectedCharMsg(const uint16 &index, const float Value, const float max, const float min, char * nom)
{
	NetworkPacket data;

	if(!TestValue(Value, max, min)) return;

	Character * pChar = getSelectedChar();
	if(pChar!=NULL)
	{
		data.Initialize( 12, index );
		data << pChar->getUpdateValue( OBJECT_FIELD_GUID );
		data << pChar->getUpdateValue( OBJECT_FIELD_GUID + 1 );
		data << Value;
		pChar->SendMessageToSet( &data, true );
		Message(pChar, nom, Value);
	}
	return;
}
//UINT32
void ChatHandler::ChangeSelectedCharMsg(const uint16 &index, const uint32 Value, const uint32 max, const uint32 min, char * nom)
{
	NetworkPacket data;

	if(!TestValue(Value, max, min)) return;

	Character * pChar = getSelectedChar();
	if(pChar!=NULL)
	{
		data.Initialize( 12, index );
		data << pChar->getUpdateValue( OBJECT_FIELD_GUID );
		data << pChar->getUpdateValue( OBJECT_FIELD_GUID + 1 );
		data << Value;
		pChar->SendMessageToSet( &data, true );
		Message(pChar, nom, Value);
	}
	return;
}
//FLOAT
void ChatHandler::ChangeSelectedChar(const uint16 &index, const float Value, const float max, const float min, char * nom)
{
	if(!TestValue(Value, max, min)) return;

	Character * pChar = getSelectedChar();
	if(pChar!=NULL)
	{
		pChar->setUpdateFloatValue(index , Value);
		Message(pChar, nom, Value);
	}
	return;
}
//UINT32
void ChatHandler::ChangeSelectedChar(const uint16 &index, const uint32 Value, const uint32 max, const uint32 min, char * nom)
{
	if(!TestValue(Value, max, min)) return;

	Character * pChar = getSelectedChar();
	if(pChar!=NULL)
	{
		pChar->setUpdateValue(index , Value);
		Message(pChar, nom, Value);
	}
	return;
}

//FLOAT
void ChatHandler::Message(Character * pChar, char * nom, const float Value)
{
	NetworkPacket data;
	uint8 buf[256];

	if(strcmp(pChar->getName(),m_pClient->getCurrentChar()->getName())!=0)
	{
		// send message to user
		sprintf((char*)buf,"You change the %s to %2.2f of %s.", nom, Value, pChar->getName());
		FillMessageData(&data, 0x09, m_pClient, buf);
		m_pClient->SendMsg( &data );

		// send message to player
		sprintf((char*)buf,"%s changed your %s to %2.2f.", m_pClient->getCurrentChar()->getName(), nom, Value);
		FillMessageData(&data, 0x09, pChar->pClient, buf);
		pChar->pClient->SendMsg( &data );
	}
	else
	{
		// send message to user
		sprintf((char*)buf,"You change your %s to %2.2f.", nom, Value);
		FillMessageData(&data, 0x09, m_pClient, buf);
		m_pClient->SendMsg( &data );
	}
}

//UINT32
void ChatHandler::Message(Character * pChar, char * nom, const uint32 Value)
{
	NetworkPacket data;
	uint8 buf[256];

	if(strcmp(pChar->getName(),m_pClient->getCurrentChar()->getName())!=0)
	{
		// send message to user
		sprintf((char*)buf,"You change the %s to %i of %s.", nom, Value, pChar->getName());
		FillMessageData(&data, 0x09, m_pClient, buf);
		m_pClient->SendMsg( &data );

		// send message to player
		sprintf((char*)buf,"%s changed your %s to %i.", m_pClient->getCurrentChar()->getName(), nom, Value);
		FillMessageData(&data, 0x09, pChar->pClient, buf);
		pChar->pClient->SendMsg( &data );
	}
	else
	{
		// send message to user
		sprintf((char*)buf,"You change your %s to %i.", nom, Value);
		FillMessageData(&data, 0x09, m_pClient, buf);
		m_pClient->SendMsg( &data );
	}
}
void ChatHandler::Message(Character * pChar, char * nom)
{
	NetworkPacket data;
	uint8 buf[256];

	if(strcmp(pChar->getName(),m_pClient->getCurrentChar()->getName())!=0)
	{
		// send message to user
		sprintf((char*)buf,"You %s %s.", nom, pChar->getName());
		FillMessageData(&data, 0x09, m_pClient, buf);
		m_pClient->SendMsg( &data );

		// send message to player
		sprintf((char*)buf,"%s %s you.", m_pClient->getCurrentChar()->getName(), nom);
		FillMessageData(&data, 0x09, pChar->pClient, buf);
		pChar->pClient->SendMsg( &data );
	}
	else
	{
		// send message to user
		sprintf((char*)buf,"You %s to you.", nom);
		FillMessageData(&data, 0x09, m_pClient, buf);
		m_pClient->SendMsg( &data );
	}
}

Unit * ChatHandler::getSelectedNPC()
{
	guid mguid;

	mguid = m_pClient->getCurrentChar()->getSelection ();
	if (mguid.Assigned ())
	{
		if (mguid.type == 0xF0001000)
			return WORLDSERVER.GetCreature (mguid.sno);
	}

	NetworkPacket data;
	FillMessageData(&data, 0x09, m_pClient,(uint8*) "Please select a NPC");
	m_pClient->SendMsg( &data );

	return NULL;
}
void ChatHandler::ChangeSelectedNPC(const uint16 &index, const uint32 Value, const uint32 max, const uint32 min)
{
	NetworkPacket data;

	if(!TestValue(Value, max, min)) return;

	Unit * pUnit = getSelectedNPC();
	if(pUnit!=NULL)
	{
		pUnit->setUpdateValue(index , Value);

		DatabaseInterface *dbi = DATABASE.createDatabaseInterface( );
		/*
		   sprintf((char*)buf, "DELETE FROM creatures WHERE id=%u", pUnit->getGUID());
		   dbi->doQuery((char*)buf);
		   dbi->saveCreature(pUnit);
		   */
		dbi->updateCreature(pUnit);
		DATABASE.removeDatabaseInterface(dbi);
		pUnit->UpdateObject();

		FillMessageData(&data, 0x09, m_pClient,(uint8*)"NPC updated.");
		m_pClient->SendMsg( &data );
	}
	return;
}
//END OF LINA COMMAND BY PTR FONCTION PATCH 1.3

// ELECTRIX ADD START {

void ChatHandler::GenCreature(GameClient *pClient, uint32 StartId, uint32 EndId ,uint32 StepId )
{
	char* pName= "Def Name ";
	uint32 CurrentId=1;
	uint16 ModuloId=0;
	uint32 npcFlags=0;
	uint32 faction_id=0;
	uint32 level=10;
	NetworkPacket data;

	// Create the requested monster

	Character *chr = pClient->getCurrentChar();
	float x = chr->getPositionX();
	float y = chr->getPositionY();
	float z = chr->getPositionZ();
	float o = chr->getOrientation();

	for (CurrentId=StartId;CurrentId<=EndId;CurrentId++)
	{
		x+= (float) 5.0f;
		ModuloId++;
		if ( ModuloId>=StepId)
		{
			x-= (float) 5.0f *(float) ModuloId;
			ModuloId=0;
			y+= (float) 10.0f;
		}

		sprintf(pName,"Id:%i",CurrentId);

		Unit* pUnit = new Unit();
		UpdateMask unitMask;
		WorldServer::getSingletonPtr()->mObjectMgr.SetCreateUnitBits(unitMask);

		pUnit->Create(WORLDSERVER.m_hiCreatureGuid++, (uint8*)pName, x, y, z, o);
		pUnit->setMapId(chr->getMapId());
		pUnit->setZone(chr->getZone());
		data.Clear();
		pUnit->setUpdateValue(OBJECT_FIELD_ENTRY, WORLDSERVER.addCreatureName((uint8*)pUnit->getCreatureName()));
		pUnit->setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 1.0f);
		pUnit->setUpdateValue(UNIT_FIELD_DISPLAYID, CurrentId);
		pUnit->setUpdateValue(UNIT_NPC_FLAGS , npcFlags);
		pUnit->setUpdateValue(UNIT_FIELD_FACTIONTEMPLATE , faction_id);
		//pUnit->setUpdateValue(UNIT_FIELD_HEALTH, 100 + 30*level);
		//pUnit->setUpdateValue(UNIT_FIELD_MAXHEALTH, 100 + 30*level);
		pUnit->setUpdateValue(UNIT_FIELD_HEALTH, (uint32)((1.24*(float)level*(float)level)+(1.79*(float)level)+40.64) );
		pUnit->setUpdateValue(UNIT_FIELD_MAXHEALTH, (uint32)((1.24*(float)level*(float)level)+(1.79*(float)level)+40.64) );

		pUnit->setUpdateValue(UNIT_FIELD_LEVEL , level);

		pUnit->setUpdateFloatValue(UNIT_FIELD_COMBATREACH , 1.5f);
		pUnit->setUpdateFloatValue(UNIT_FIELD_MAXDAMAGE ,  5.0f);
		pUnit->setUpdateFloatValue(UNIT_FIELD_MINDAMAGE , 8.0f);
		pUnit->setUpdateValue(UNIT_FIELD_BASEATTACKTIME, 1900);
		pUnit->setUpdateValue(UNIT_FIELD_BASEATTACKTIME+1, 2000);
		pUnit->setUpdateFloatValue(UNIT_FIELD_BOUNDINGRADIUS, 2.0f);

		pUnit->CreateObject(&unitMask, &data, 0);

		//  add to the world list of creatures
		WPAssert (pUnit->getGUID ().Assigned ());
		WORLDSERVER.mCreatures[pUnit->getGUID().sno] = pUnit;

		// send create message to everyone
		WORLDSERVER.SendGlobalMessage(&data);

		DatabaseInterface *dbi = DATABASE.createDatabaseInterface( );
		char sql[512];
		sprintf(sql, "insert into skin set id_skin='%i',name='%s',type='0',race='0', gender='0'", CurrentId,pName);
		dbi->doQuery(sql);
		//dbi->saveCreature(pUnit);
		DATABASE.removeDatabaseInterface(dbi);
	}
}

// }ELECTRIX ADD END
