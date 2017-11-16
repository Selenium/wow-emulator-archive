#pragma once
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

//////////////////////////////////////////////////////////////////////
//  Chat
//
//  Receives all messages with a chat-related opcode.
//////////////////////////////////////////////////////////////////////
#ifndef WOWSERVER_CHAT_H
#define WOWSERVER_CHAT_H

#include "Creature.h"

class ChatHandler;
class WorldSession;
class Player;
class Unit;

enum ChatMsg
{
    CHAT_MSG_SAY                                  = 0x00,
    CHAT_MSG_PARTY                                = 0x01,
    // unknown
    CHAT_MSG_GUILD                                = 0x03,
    CHAT_MSG_OFFICER                              = 0x04,
    CHAT_MSG_YELL                                 = 0x05,
    CHAT_MSG_WHISPER                              = 0x06,
    CHAT_MSG_WHISPER_INFORM                       = 0x07,
    CHAT_MSG_EMOTE                                = 0x08,
    CHAT_MSG_TEXT_EMOTE                           = 0x09,
    CHAT_MSG_SYSTEM                               = 0x0A,
    CHAT_MSG_MONSTER_SAY                          = 0x0B,
    CHAT_MSG_MONSTER_YELL                         = 0x0C,
    CHAT_MSG_MONSTER_EMOTE                        = 0x0D,
    CHAT_MSG_CHANNEL                              = 0x0E,
    CHAT_MSG_CHANNEL_JOIN                         = 0x0F,
    CHAT_MSG_CHANNEL_LEAVE                        = 0x10,
    CHAT_MSG_CHANNEL_LIST                         = 0x11,
    CHAT_MSG_CHANNEL_NOTICE                       = 0x12,
    CHAT_MSG_CHANNEL_NOTICE_USER                  = 0x13,
    CHAT_MSG_AFK                                  = 0x14,
    CHAT_MSG_DND                                  = 0x15,
    CHAT_MSG_COMBAT_LOG                           = 0x16,
    CHAT_MSG_IGNORED                              = 0x17,
    CHAT_MSG_SKILL                                = 0x18,
    CHAT_MSG_LOOT                                 = 0x19,
};



class ChatCommand
{
public:
    const char *       Name;
    uint16             SecurityLevel;
    bool (ChatHandler::*Handler)(const char* args) ;
    std::string        Help;
    ChatCommand *      ChildCommands;
};

class ChatHandler : public Singleton<ChatHandler>
{
public:
    ChatHandler();
    ~ChatHandler();

    void FillMessageData( WorldPacket *data, WorldSession* session, uint32 type,
		uint32 language, const char* channelName, const char* message,
		Guid someguid=0) const;

    void FillSystemMessageData( WorldPacket *data, WorldSession* session, const char* message ) const
    {
        FillMessageData( data, session, CHAT_MSG_SYSTEM, LANG_UNIVERSAL, NULL, message );
    }

	void GMMessage( WorldSession* session, const char * str, ... ) 
	{
		if (( !str ) || (!session->GetSecurity())) return;
		{
			char *lstpx = new char[2048];
			WorldPacket data;

			va_list ap;
			va_start(ap, str);
			vsprintf(lstpx, str, ap );

			FillSystemMessageData( &data, session, lstpx );
			session->SendPacket( &data );

			delete lstpx;
			va_end(ap);
		}
}

    int ParseCommands(const char* text, WorldSession *session);

protected:
    Creature *SpawnCreature (WorldSession *session, CreatureTemplate *ct, uint32 mapId,
        float x, float y, float z, float o);
    Creature *SpawnCreature (WorldSession *session, CreatureTemplate *ct);
    /*void SpawnCreature(WorldSession *session, const char* pName, uint32 displayId, uint32 npcFlags, uint32 factionId, uint32 level);
    void SpawnCreature (WorldSession *session, CreatureTemplate *ct);*/
    //void smsg_NewWorld(WorldSession *session, uint32 mapid, float x, float y, float z);
    //void MovePlayer(WorldSession *session, float x, float y, float z);

    bool hasStringAbbr(const char* s1, const char* s2);
    void SendMultilineMessage(const char *str);

    bool ExecuteCommandInTable(ChatCommand *table, const char* text);
    bool ShowHelpForCommand(ChatCommand *table, const char* cmd);

    ChatCommand* getCommandTable();

    // Level 0 commands
    bool HandleHelpCommand(const char* args);
    bool Command_Commands (const char* args);
	bool HandleVersionCommand(const char* args);
    bool HandleNYICommand(const char* args);
    bool HandleAcctCommand(const char* args);
    bool HandleStartCommand(const char* args);
    bool HandleInfoCommand(const char* args);
    bool HandleMountCommand(const char* args);
    bool HandleDismountCommand(const char* args);
    bool HandleSaveCommand(const char* args);
    bool HandleGMListCommand(const char* args);

    // Level 1 commands
    bool HandleSummonCommand(const char* args);
    bool HandleAppearCommand(const char* args);
    bool HandleRecallCommand(const char* args);
    bool HandleAnnounceCommand(const char* args);
    bool HandleGMOnCommand(const char* args);
    bool HandleGMOffCommand(const char* args);
    bool Command_Where (const char* args);
    bool HandleTaxiCheatCommand(const char* args);

    bool Command_Modify_HP (const char* args);
    bool Command_Modify_Mana (const char* args);
    bool Command_Modify_Rage (const char* args);
    bool Command_Modify_Energy (const char* args);
    bool Command_Modify_Money (const char* args);
    bool Command_Modify_Level (const char* args);
    bool Command_Modify_qItems (const char* args);
    bool Command_Modify_qKill (const char* args);
    bool Command_Modify_Item   (const char* args);
    //bool HandleModifyASpedCommand(const char* args);
    bool Command_Modify_Speed (const char* args);
    //bool HandleModifyBWalkCommand(const char* args);
    bool Command_Modify_Swim (const char* args);
    bool Command_Modify_Size (const char* args);
    bool Command_Modify_Mount (const char* args);
    //bool HandleModifyBitCommand(const char* args);
    
    // Level 2 commands
    bool HandleProgCommand (const char* args);
    bool HandleItemMoveCommand (const char* args);

    // Level 3 commands
    bool HandleSecurityCommand (const char* args);
    bool HandleWorldPortCommand (const char* args);
    bool HandleAddSpiritCommand (const char* args);
    bool HandleMoveCommand (const char* args);
    bool Command_Modify_Spell (const char* args);
    bool Command_Modify_Skill (const char* args);
    bool HandleUnlearnCommand (const char* args);
    bool HandleObjectCommand (const char* args);
    bool HandleAnimCommand (const char* args);
    bool HandleStandStateCommand (const char* args);
    bool HandleDieCommand (const char* args);
    bool HandleReviveCommand (const char* args);
    bool HandleMorphCommand (const char* args);
    bool HandleAuraCommand (const char* args);
    bool HandleAddGraveCommand (const char* args);
    bool HandleAddSHCommand (const char* args);
    bool HandleSpawnTransportCommand (const char* args);
    bool HandleInvisCommand (const char* args);

    //------------------------------------------------------------------
    // Waypoints Control Commands
    //------------------------------------------------------------------
    WaypointIndicatorList   m_wpIndicators;
    
    WaypointIndicator *SpawnWaypointIndicator (float x, float y, float z, uint32 index);
    void _recreateCreatureWaypointIndicators (Creature *cr);
    void _resaveWaypoints (Creature *cr);

    bool Command_WP_Info (const char *args);
    bool Command_WP_Show (const char *args);
    bool Command_WP_Hide (const char *args);
    bool Command_WP_Come (const char *args);
    bool Command_WP_Delete (const char *args);
    bool Command_WP_Clear (const char *args);
    bool Command_WP_Add (const char *args);
    bool Command_WP_Wait (const char *args);

    //------------------------------------------------------------------
    // NPC Control commands
    //------------------------------------------------------------------
    bool Command_NPC_Add (const char* args);
    //bool Command_NPC_Spawn (const char* args);
    bool Command_NPC_Turn (const char *args);
	bool Command_NPC_Come (const char *args);
    bool Command_NPC_MType (const char* args);
    bool Command_NPC_Level (const char* args);
    bool Command_NPC_Sell (const char* args);
    bool Command_NPC_Delete (const char* args);
    bool Command_NPC_Model (const char* args);
    bool Command_NPC_Faction (const char* args);
    bool Command_NPC_Flags (const char* args);
    //bool Command_NPC_Name (const char* args);
    bool Command_NPC_Size (const char* args);
    bool Command_NPC_Info (const char* args);
    bool Command_NPC_Run (const char* args);
    bool Command_NPC_GUID (const char* args);
    bool Command_NPC_SpawnTime (const char* args);
    bool Command_NPC_SpawnDistance (const char* args);
	bool Command_NPC_ListHate (const char* args);
	bool Command_NPC_Kill (const char* args);
	bool Command_NPC_Respawn (const char* args);

    //------------------------------------------------------------------
    // Debug and developers access only
    //------------------------------------------------------------------
    bool Command_ImportWorld (const char* args);
	bool Command_ImportGameobj (const char* args);
	bool Command_GoGUID (const char* args);
#ifdef _DEBUG
    bool Command_Test (const char* args);
#endif
    bool Command_Debug_Flags (const char* args);
    bool Command_Debug_DynamicFlags (const char* args);
    bool Command_Debug_Bytes0 (const char* args);
    bool Command_Debug_Bytes1 (const char* args);
    bool Command_Debug_Bytes2 (const char* args);
	bool Command_Debug_ReloadScripts (const char* args);
	bool Command_Debug_Errors (const char* args);
	bool Command_Debug_QInv (const char* args);
	bool Command_Debug_QFailed (const char* args);

    Player* getSelectedChar(WorldSession *client);

public: //? maybe making this public is wrong?
    WorldSession *m_session;
};


#define sChatHandler ChatHandler::getSingleton()


#endif
