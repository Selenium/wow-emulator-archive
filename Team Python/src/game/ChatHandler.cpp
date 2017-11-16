
#include "ChatHandler.h"
#include "NetworkInterface.h"
#include "GameClient.h"
#include "Opcodes.h"
#include "Log.h"
#include "WorldServer.h"
#include "Character.h"
#include "UpdateMask.h"
#include "Database.h"

#define world WorldServer::getSingleton()

ChatCommand * ChatHandler::LoadHelp(bool load)
{
	static bool first_call = true;

	// TODO: change to std::vectors?
	static ChatCommand adminCommandTable[8];
	static ChatCommand npcCommandTable[23];
	static ChatCommand moveCommandTable[9];
	static ChatCommand gmCommandTable[7];
	static ChatCommand usrCommandTable[12];
	static ChatCommand commandTable[16];

	if(first_call)
	{
		first_call = false;
		//ADMIN
		adminCommandTable[0].setValues("ban",         3, &ChatHandler::HandleBanCommand,           "",   NULL);//LINA FEATURE
		adminCommandTable[1].setValues("unban",       3, &ChatHandler::HandleUnBanCommand,         "",   NULL);//LINA FEATURE
		adminCommandTable[2].setValues("lvl",         3, &ChatHandler::HandleSecurityCommand,      "",   NULL);//LINA FEATUR
		adminCommandTable[3].setValues("morph",       3, &ChatHandler::HandleMorphCommand,         "",   NULL);
		adminCommandTable[3].setValues("die",         3, &ChatHandler::HandleDieCommand,           "",   NULL);
		adminCommandTable[4].setValues("revive",      3, &ChatHandler::HandleReviveCommand,        "",   NULL);
		adminCommandTable[5].setValues("update",      3, &ChatHandler::HandleUpdateCommand,        "",   NULL);
		adminCommandTable[6].setValues(NULL,          0, NULL,                                     "",   NULL);

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
       npcCommandTable[19].setValues("scale",      2, &ChatHandler::HandleNPCScaleCommand,       "",   NULL);//THE_WIZARD 
       npcCommandTable[20].setValues("hpmin",      2, &ChatHandler::HandleNPChpminCommand,       "",   NULL);//THE_WIZARD 
       npcCommandTable[21].setValues("hpmax",      2, &ChatHandler::HandleNPChpmaxCommand,       "",   NULL);//THE_WIZARD       
       npcCommandTable[22].setValues(NULL,          0, NULL,                                     "",   NULL);


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
		gmCommandTable[3].setValues("kick",        1, &ChatHandler::HandleKickCommand,          "",   NULL);//LINA FEATURE
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
		usrCommandTable[8].setValues("aura",        3, &ChatHandler::HandleAuraCommand,				"",   NULL);
		usrCommandTable[9].setValues("spell",       3, &ChatHandler::HandleLearnCommand,			"",   NULL);
		usrCommandTable[10].setValues("skin",       3, &ChatHandler::HandleMorphCommand,			"",   NULL);
		usrCommandTable[11].setValues(NULL,         0, NULL,										"",   NULL);

		//MAIN
//		commandTable[0].setValues("help",        0, &ChatHandler::HandleHelpCommand,          "",   NULL);
		commandTable[0].setValues("help",        0, &ChatHandler::HandleCommandsCommand,      "",   NULL);
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
		DatabaseInterface *dbi = Database::getSingleton().createDatabaseInterface( );

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

		Database::getSingleton( ).removeDatabaseInterface(dbi);
	}
	return commandTable;
}
/*
bool ChatHandler::HandleDisplayVRItemSlot0Command(uint8* args) //for weapons in the NPC By WIZARD
{
	wowWData data;
	if (!*args) return false;
	uint32 Arg = (uint32) atoi((char*)args);
	ChangeSelectedNPC(UNIT_VIRTUAL_ITEM_SLOT_DISPLAY_0, Arg, 9999999, 0);
	return true; 
} 
*/
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
    wowWData data;

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
                    wowWData data;
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
                wowWData data;
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
    assert(text);
   // assert(*text); fixed by ScreaM

    if(text[0] != '!' && text[0] != '.') // let's not confuse users
        return 0;
    text++;

    if(!ExecuteCommandInTable(LoadHelp(false), text))
    {
        wowWData data;
        FillMessageData(&data, 0x09, m_pClient, (uint8*)"There is no such command.");
        m_pClient->SendMsg(&data);
    }

    return 1;
}

void ChatHandler::HandleMsg( wowWData & recv_data, GameClient *pClient )
{
    wowWData data;
    char f[256];
    sprintf(f, "WORLD: Chat Opcode 0x%.4X", recv_data.opcode);
    Log::getSingleton( ).outString( f );
    switch (recv_data.opcode)
    {
	case CHAT_MSG_YELL:
	case CHAT_MSG_PARTY:
	case CHAT_MSG_GUILD:
	case CHAT_MSG_OFFICER:
    case CMSG_MESSAGECHAT:
		{
            uint16 text_length = strlen((char*)recv_data.data+8)+1;

			m_pClient = pClient;
            if (ParseCommands(recv_data.data+8, text_length) > 0)
                return;

			uint8 text_mode = recv_data.data[0];
            FillMessageData( &data, text_mode, pClient, recv_data.data+8 );

			if (text_mode == CHAT_MSG_PARTY) {
				if (((Character*)pClient->getCurrentChar())->IsInGroup()) {
					Group *pGroup = world.GetGroupByLeader(((Character*)pClient->getCurrentChar())->GetGroupLeader());
	                for (uint32 c=0; c < pGroup->count; c++){
						Character *pGroupGuy = world.mCharacters[pGroup->members[c].guid];
						world.SendMessageToPlayer(&data, pGroupGuy->getGUID());
					}
				}
			}
			else if (text_mode == CHAT_MSG_YELL) {
				world.SendZoneMessage(&data, pClient, 1);
			}
			else if (text_mode == CHAT_MSG_GUILD) return;
			else if (text_mode == CHAT_MSG_OFFICER) return;
            else if (text_mode != CHAT_MSG_WHISPER) { // whisper message send in FillMessageData
				world.SendAreaMessage(&data, pClient, 1);
            }
        } break;
    case CMSG_TEXT_EMOTE:
        {
			if (pClient->getCurrentChar()->isDead()) return;
            uint32 text_emote, guid1, guid2;
            recv_data.readData(text_emote);
            recv_data >> guid1 >> guid2;

            char *nam=0; uint16 namlen=0;
            WorldServer::CharacterMap::iterator chariter;
            WorldServer::CreatureMap::iterator npciter;

            if( (( npciter = world.mCreatures.find( guid1 ) ) != world.mCreatures.end( ) ) && (guid2==0xF0001000) ) {
                nam = npciter->second->getCreatureName( );
                namlen = strlen( nam ) + 1;
            } else if( ( chariter = world.mCharacters.find( guid1 ) ) != world.mCharacters.end( ) ) {
                nam = chariter->second->getName( );
                namlen = strlen( nam ) + 1;
            }

            data.clear();
            data.Initialise(12, SMSG_EMOTE);

            uint8 emote_anim = world.mEmotes[uint8(text_emote&0xff)];

            data << (uint8)emote_anim;
            data << (uint8)0x00;
            data << (uint8)0x00;
            data << (uint8)0x00;

            uint32 guid = pClient->getCurrentChar()->getGUID();
            data << (uint32)guid << (uint8)0x00 << (uint8)0x00 << (uint8)0x00 << (uint8)0x00;
//            world.SendGlobalMessage(&data);
			world.SendAreaMessage(&data, pClient, 1);

            data.clear();
            data.setLength(12 + namlen);
            data.opcode = SMSG_TEXT_EMOTE;


            memcpy(data.data, &guid, 4);
            data.data[4] = 0x00;
            data.data[5] = 0x00;
            data.data[6] = 0x00;
            data.data[7] = 0x00;

            memcpy(data.data+8,recv_data.data,4);

            if( namlen > 0 )
                memcpy( data.data + 12, nam, namlen );

//            pClient->SendMsg( &data );
//            world.SendGlobalMessage(&data, pClient);
			world.SendAreaMessage(&data, pClient, 1);
        } break;
    }
}

void ChatHandler::FillMessageData( wowWData *data, uint8 type, GameClient* pClient, uint8 *text )
{

    // !!!! Be careful using strlen to determine the size of the chat message.
    // A CHAT_MSG_WHISPER sends TWO null terminated  strings(first the name of
    // the whisper target, then the message) and doing strlen only finds the
    // length of the first string.  -- DeathCheese

    const uint8 msgchat_header_size=13;
    uint8 msgchat_header[msgchat_header_size] = {type,
        0x00, 0x00, 0x00, 0x00}; //no idea what are those bytes for

    // add guid to message header
    uint32 guid=0;
    if(pClient)
        guid = pClient->getCurrentChar()->getGUID();
    memcpy(msgchat_header+5, &guid, 4);
    msgchat_header[9] = 0x00;
    msgchat_header[10] = 0x00;
    msgchat_header[11] = 0x00;
    msgchat_header[12] = 0x00;

    data->clear();

    std::string logoutput = "CHAT: ";
    if( pClient ) {
        logoutput += pClient->getCurrentChar( )->getName( );
        logoutput += ": ";
    }

    uint16 length = strlen((char*)text) + 1;
    if (type == CHAT_MSG_WHISPER){
        // Whisper Chat:  Server receives two strings.  First is the target of whisper, second is the message.
        uint16 msg_length = strlen((char*)text+length) + 1;

        data->setLength(msgchat_header_size + msg_length + 1);
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
        data->setLength(msgchat_header_size + length + 1);
        data->opcode = SMSG_MESSAGECHAT;

        memcpy(data->data,msgchat_header,msgchat_header_size);
        memcpy(data->data+msgchat_header_size, text, length);
        data->data[msgchat_header_size+length] = 0; //NULL terminated string
        logoutput += (char *)text;
    }

    //Log::getSingleton( ).outChat( logoutput.c_str( ) );

    // The last byte is most likely a flag, 0 or 1, denoting on or off
    uint8 byte = 0x00;
    if(type == CHAT_MSG_AFK && pClient!=0) { // toggle AFK
        byte = pClient->getCurrentChar()->ToggleAFK();
    }

    data->data[data->length-1] = byte;

    if (type == CHAT_MSG_WHISPER){
        char name[22];
        memcpy(name, text, length);
		if (world.GetClientByName((char*)name))
		{
			world.SendMessageToPlayer(data, (char*)name);
			data->clear();
			uint8 buf[256];
			sprintf((char*)buf,"To %s: %s", (char*)name, (char *)(text + length));
			FillMessageData(data, 0x09, pClient, buf);
			pClient->SendMsg( data );
		}
		else
		{
			data->clear();
			uint8 buf[256];
			sprintf((char*)buf,"No player named '%s' is currently playing", (char*)name);
			FillMessageData(data, 0x09, pClient, buf);
			pClient->SendMsg( data );
		}						
    }
}

void ChatHandler::SpawnCreature(GameClient *pClient, char* pName, uint32 display_id, uint32 npcFlags, uint32 faction_id, uint32 level)
{
    wowWData data;

    // Create the requested monster
    Character *chr = pClient->getCurrentChar();
    float x = chr->getPositionX();
    float y = chr->getPositionY();
    float z = chr->getPositionZ();
    float o = chr->getOrientation();

    Unit* pUnit = new Unit();
    UpdateMask unitMask;
    WorldServer::getSingletonPtr()->mObjectMgr.SetCreateUnitBits(unitMask);

    pUnit->Create(world.m_hiCreatureGuid++, (uint8*)pName, x, y, z, o);
    pUnit->setMapId(chr->getMapId());
    pUnit->setZone(chr->getZone());
    data.clear();
    pUnit->setUpdateValue(OBJECT_FIELD_ENTRY, world.addCreatureName((uint8*)pUnit->getCreatureName()));
    //pUnit->setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 1.0f);
    pUnit->setUpdateValue(UNIT_FIELD_DISPLAYID, display_id);
    pUnit->setUpdateValue(UNIT_NPC_FLAGS , npcFlags);
    pUnit->setUpdateValue(UNIT_FIELD_FACTIONTEMPLATE , faction_id);
    pUnit->setUpdateValue(UNIT_FIELD_HEALTH, 30 + 20*level);
    pUnit->setUpdateValue(UNIT_FIELD_MAXHEALTH, 30 + 20*level);
    pUnit->setUpdateValue(UNIT_FIELD_LEVEL , level);
	// Mobs size fixe by RaSCaO
	if (level <= 4)
	{
		pUnit->setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 0.75f);
	}
	else if (level > 4 && level <= 10)
	{
		pUnit->setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 0.85f);
	}
	else if (level > 10 && level <= 30)
	{
		pUnit->setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 0.95f);
	}
	else if (level > 30 && level <= 60)
	{
		pUnit->setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 1.1f);
	}
	else
	{
		pUnit->setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 1.25f);
	}


    pUnit->setUpdateFloatValue(UNIT_FIELD_COMBATREACH , 1.5f);
    pUnit->setUpdateFloatValue(UNIT_FIELD_MAXDAMAGE ,  5.0f);
    pUnit->setUpdateFloatValue(UNIT_FIELD_MINDAMAGE , 8.0f);
    pUnit->setUpdateValue(UNIT_FIELD_BASEATTACKTIME, 1900);
    pUnit->setUpdateValue(UNIT_FIELD_BASEATTACKTIME+1, 2000);
    pUnit->setUpdateFloatValue(UNIT_FIELD_BOUNDINGRADIUS, 2.0f);

    pUnit->CreateObject(&unitMask, &data, 0);

    // add to the world list of creatures
    WPAssert( pUnit->getGUID() != 0 );
    world.mCreatures[pUnit->getGUID()] = pUnit;

    // send create message to everyone
//    world.SendGlobalMessage(&data);
	world.SendUnitAreaMessage(&data, pUnit);

    DatabaseInterface *dbi = Database::getSingleton( ).createDatabaseInterface( );
    dbi->saveCreature(pUnit);
    Database::getSingleton( ).removeDatabaseInterface(dbi);
}

void ChatHandler::smsg_NewWorld(GameClient *pClient, uint16 c, float x, float y, float z)
{
	pClient->getCurrentChar()->setWorldPort(true);
	
    wowWData data;
    WorldServer::CreatureMap creatures = world.getCreatureMap();
    WorldServer::CharacterMap characters = world.getCharacterMap();

    data.Initialise(4, SMSG_TRANSFER_PENDING);
    data << uint32(0);

    pClient->SendMsg(&data);

    // Build a NEW WORLD packet
    data.Initialise(20, SMSG_NEW_WORLD);
    data << (uint32)c << (float)x << (float)y << (float)z << (float)0.0f;
    pClient->SendMsg( &data );

    /*
    // Destroy this client's player from all clients (including self)
    uint32 guid = pClient->getCurrentChar()->getGUID();
    data.Initialise(SMSG_DESTROY_OBJECT);
    data << (uint32)guid << (uint8)0x00 << (uint8)0x00 << (uint8)0x00 << (uint8)0x00;
    WPAssert(data.getLength() == 8);
    pClient->SendMsg(&data);

    for( WorldServer::CreatureMap::iterator i = creatures.begin( ); i != creatures.end( ); ++ i )
    {
        uint32 guid = i->second->getGUID();
        data.Initialise(SMSG_DESTROY_OBJECT);
        data << (uint32)guid << i->second->getGUIDHigh();
        WPAssert(data.getLength() == 8);
        pClient->SendMsg(&data);
    }
    */

    // Destroy ourselves from other clients
    uint32 guid = pClient->getCurrentChar()->getGUID();
    data.Initialise(8, SMSG_DESTROY_OBJECT );
    data << (uint32)guid << (uint8)0x00 << (uint8)0x00 << (uint8)0x00 << (uint8)0x00;
//    pClient->getCurrentChar()->SendMessageToSet(&data, true);
	world.SendAreaMessage(&data, pClient, 1);

    // Remove ourselves from inrange lists
    for( WorldServer::CharacterMap::iterator iter = characters.begin( ); iter != characters.end( ); ++ iter )
        iter->second->RemoveInRangeObject( pClient->getCurrentChar() );

    for( WorldServer::CreatureMap::iterator iter = creatures.begin( ); iter != creatures.end( ); ++ iter )
        iter->second->RemoveInRangeObject( pClient->getCurrentChar() );

    pClient->getCurrentChar()->ClearInRangeSet();

    pClient->getCurrentChar()->setMapId(c);

    pClient->getCurrentChar()->setNewPosition(x,y,z);
//    pClient->getCurrentChar()->setPosition(8000,8000,0,0,true);
    pClient->getCurrentChar()->setPosition(x,y,z,0,true);
    //wowWData movedata;
//	pClient->getCurrentChar( )->TeleportAck(&data, x, y, z);
//	world.SendAreaMessage(&data, pClient, 1);
}

void ChatHandler::MovePlayer(GameClient *pClient, float x, float y, float z)
{
    wowWData data;

    //Output new position to the console
    uint8 txtBuffer[512];
    sprintf((char*)txtBuffer,"WORLD: Moved player to (%f, %f, %f)",x,y,z );
    Log::getSingleton( ).outString( (char*)txtBuffer );

    sprintf((char*)txtBuffer,"You have been moved to (%f, %f, %f)",x,y,z );
    FillMessageData(&data, 0x09, pClient, txtBuffer);
    pClient->SendMsg( &data );

    ////////////////////////////////////////
    //Set the new position of the character
    Character *chr = pClient->getCurrentChar();

    //Send new position to client via MSG_MOVE_TELEPORT_ACK
    chr->TeleportAck(&data, x,y,z);
    //pClient->SendMsg(&data);

    //////////////////////////////////
    //Now send new position of this player to all clients using MSG_MOVE_HEARTBEAT
    chr->BuildHeartBeat(&data);
//    world.SendGlobalMessage(&data, pClient);
	world.SendAreaMessage(&data, pClient, 1);
}

//START OF LINA COMMAND BY NAME FONCTION PATCH
Character * ChatHandler::getCurrentCharByName(uint8 * pName)
{
	WorldServer::ClientSet::iterator itr;
	for (itr = world.mClients.begin(); itr != world.mClients.end(); itr++)
	{
		if( strcmp(((GameClient*)(*itr))->getCharacterName(), (char*)pName) == 0 )
		{
			return ((GameClient*)(*itr))->getCurrentChar();
		}
	}
	wowWData data;
	uint8 buf[256];
	sprintf((char*)buf,"Character (%s) does not exist or is not logged in.", (char*)pName);
	FillMessageData(&data, 0x09, m_pClient, buf);
	m_pClient->SendMsg( &data );
	return NULL;
}
//END OF LINA COMMAND BY NAME FONCTION PATCH

//START OF LINA COMMAND BY PTR FONCTION PATCH 1.3
Character * ChatHandler::getSelectedChar()
{
	const uint32 *guid;
	wowWData data;
	Character *chr=NULL;
				
	guid = m_pClient->getCurrentChar()->getSelectionPtr();
	if (guid[0] != 0)
	{
		if(guid[1]==0) chr= WorldServer::getSingleton().GetCharacter(guid[0]);
		else
		{			
			FillMessageData(&data, 0x09, m_pClient,(uint8*) "Please select a User.");
			m_pClient->SendMsg( &data );
		}
	}
	else
	{
		chr=m_pClient->getCurrentChar();
//		FillMessageData(&data, 0x09, m_pClient,(uint8*) "AutoSelection.");
//		m_pClient->SendMsg( &data );
	}
	return chr;
}

//UINT32
int32 ChatHandler::TestValue(const float Value, const float max, const float min)
{
	if(Value<min || Value>max)
	{
		wowWData data;
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
		wowWData data;
		FillMessageData(&data, 0x09, m_pClient,(uint8*)"Invalid Value.");
		m_pClient->SendMsg( &data );
		return 0;
	}
	return 1;
}
//FLOAT
void ChatHandler::ChangeSelectedCharMsg(const uint16 &index, const float Value, const float max, const float min, char * nom)
{
	wowWData data;

	if(!TestValue(Value, max, min)) return;

	Character * pChar = getSelectedChar();
	if(pChar!=NULL)
	{
		data.Initialise( 12, index );
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
	wowWData data;

	if(!TestValue(Value, max, min)) return;

	Character * pChar = getSelectedChar();
	if(pChar!=NULL)
	{
		data.Initialise( 12, index );
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
	wowWData data;
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

		// log gm command
		FILE *pFile;
		pFile = fopen("gmcommands.log", "a");
		fprintf(pFile, "%s change %s %s to %2.2f.\n", m_pClient->getCurrentChar()->getName(), pChar->getName(), nom, Value);
		fclose(pFile);
	}
	else
	{
		// send message to user
		sprintf((char*)buf,"You change your %s to %2.2f.", nom, Value, pChar->getName());
		FillMessageData(&data, 0x09, m_pClient, buf);
		m_pClient->SendMsg( &data );
	}
}

//UINT32
void ChatHandler::Message(Character * pChar, char * nom, const uint32 Value)
{
	wowWData data;
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

		// log gm command
		FILE *pFile;
		pFile = fopen("gmcommands.log", "a");
		fprintf(pFile, "%s change %s %s to %i.\n", m_pClient->getCurrentChar()->getName(), pChar->getName(), nom, Value);
		fclose(pFile);
	}
	else
	{
		// send message to user
		sprintf((char*)buf,"You change your %s to %i.", nom, Value, pChar->getName());
		FillMessageData(&data, 0x09, m_pClient, buf);
		m_pClient->SendMsg( &data );
	}
}
void ChatHandler::Message(Character * pChar, char * nom)
{
	wowWData data;
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
	const uint32 *guid;
				
	guid = m_pClient->getCurrentChar()->getSelectionPtr();
	if (guid[0] != 0)
	{
		if(guid[1]==0xF0001000) return WorldServer::getSingleton().GetCreature(guid[0]);
	}

	wowWData data;
	FillMessageData(&data, 0x09, m_pClient,(uint8*) "Please select a NPC");
	m_pClient->SendMsg( &data );

	return NULL;
}
void ChatHandler::ChangeSelectedNPC(const uint16 &index, const uint32 Value, const uint32 max, const uint32 min)
{
	wowWData data;

	if(!TestValue(Value, max, min)) return;

	Unit * pUnit = getSelectedNPC();
	if(pUnit!=NULL)
	{
		pUnit->setUpdateValue(index , Value);
				
		DatabaseInterface *dbi = Database::getSingleton().createDatabaseInterface( );
		/*
		sprintf((char*)buf, "DELETE FROM creatures WHERE id=%u", pUnit->getGUID());
		dbi->doQuery((char*)buf);
		dbi->saveCreature(pUnit);
		*/
		dbi->updateCreature(pUnit);
		Database::getSingleton( ).removeDatabaseInterface(dbi);
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
    wowWData data;

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

        pUnit->Create(world.m_hiCreatureGuid++, (uint8*)pName, x, y, z, o);
        pUnit->setMapId(chr->getMapId());
        pUnit->setZone(chr->getZone());
        data.clear();
        pUnit->setUpdateValue(OBJECT_FIELD_ENTRY, world.addCreatureName((uint8*)pUnit->getCreatureName()));
        //pUnit->setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 1.0f);
        pUnit->setUpdateValue(UNIT_FIELD_DISPLAYID, CurrentId);
        pUnit->setUpdateValue(UNIT_NPC_FLAGS , npcFlags);
        pUnit->setUpdateValue(UNIT_FIELD_FACTIONTEMPLATE , faction_id);
        pUnit->setUpdateValue(UNIT_FIELD_HEALTH, 30 + 20*level);
        pUnit->setUpdateValue(UNIT_FIELD_MAXHEALTH, 30 + 20*level);
        pUnit->setUpdateValue(UNIT_FIELD_LEVEL , level);

		if (level <= 4)
		{
			pUnit->setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 0.75f);
		}
		else if (level > 4 && level <= 10)
		{
			pUnit->setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 0.85f);
		}
		else if (level > 10 && level <= 30)
		{
			pUnit->setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 0.95f);
		}
		else if (level > 30 && level <= 60)
		{
			pUnit->setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 1.1f);
		}
		else
		{
			pUnit->setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 1.25f);
		}

        pUnit->setUpdateFloatValue(UNIT_FIELD_COMBATREACH , 1.5f);
        pUnit->setUpdateFloatValue(UNIT_FIELD_MAXDAMAGE ,  5.0f);
        pUnit->setUpdateFloatValue(UNIT_FIELD_MINDAMAGE , 8.0f);
        pUnit->setUpdateValue(UNIT_FIELD_BASEATTACKTIME, 1900);
        pUnit->setUpdateValue(UNIT_FIELD_BASEATTACKTIME+1, 2000);
        pUnit->setUpdateFloatValue(UNIT_FIELD_BOUNDINGRADIUS, 2.0f);

        pUnit->CreateObject(&unitMask, &data, 0);

        //  add to the world list of creatures
        WPAssert( pUnit->getGUID() != 0 );
        world.mCreatures[pUnit->getGUID()] = pUnit;

        // send create message to everyone
//        world.SendGlobalMessage(&data);
		world.SendUnitAreaMessage(&data, pUnit);

        DatabaseInterface *dbi = Database::getSingleton( ).createDatabaseInterface( );
        char sql[512];
        sprintf(sql, "insert into skin set id_skin='%i',name='%s',type='0',race='0', gender='0'", CurrentId,pName);
        dbi->doQuery(sql);
        //dbi->saveCreature(pUnit);
        Database::getSingleton( ).removeDatabaseInterface(dbi);
    }
}

// }ELECTRIX ADD END
