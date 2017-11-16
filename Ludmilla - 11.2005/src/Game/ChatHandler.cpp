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
void WorldSession::HandleMessagechatOpcode( WorldPacket & recv_data )
{
    WorldPacket data;

    Log::getSingleton().outDebug("CHAT: packet received");

    uint32 type;
    uint32 lang;

    recv_data >> type;
    recv_data >> lang;

    switch(type)
    {
        case CHAT_MSG_SAY:
		{
			std::string msg, t;
            recv_data >> msg;

			t = msg;
            if (sChatHandler.ParseCommands (t.c_str(), this) > 0)
				break;

            //sChatHandler.FillMessageData( &data, this, type, LANG_UNIVERSAL, NULL, msg.c_str() );
			sChatHandler.FillMessageData( &data, this, CHAT_MSG_SAY, lang, NULL, msg.c_str() );
            GetPlayer()->SendMessageToSet( &data, true );
        } break;
        
		case CHAT_MSG_CHANNEL:
		{
            std::string channel, msg, t;

			t = msg;
			if (sChatHandler.ParseCommands (t.c_str(), this) > 0)
				break;

            recv_data >> channel;
            recv_data >> msg;
			Channel *chn = channelmgr.GetChannel(channel.c_str(),GetPlayer());
			if(chn) chn->Say (GetPlayer(), msg.c_str());
        } break;

		case CHAT_MSG_WHISPER: 
        {
            std::string to, msg, t;
            recv_data >> to >> msg;

			t = msg;
			if (sChatHandler.ParseCommands (t.c_str(), this) > 0)
				break;

            Player *player = objmgr.GetPlayer(to.c_str());            
			if (!player)
			{
                data.clear();
                //sChatHandler.FillSystemMessageData( &data, this, msg.c_str() );
                //SendPacket(&data);
				this->SystemMessage ("Player '%s' isn't online", to.c_str());
				Log::getSingleton().outDebug ("ChatHandler.Whisper: Player '%s' isn't online", to.c_str());
                break;
            }

			// Send whisper MSG to receiver
			sChatHandler.FillMessageData(&data, this, type, lang, NULL, msg.c_str());
			player->GetSession()->SendPacket(&data);

			// Echo whisper back to sender
			sChatHandler.FillMessageData(&data, this, CHAT_MSG_WHISPER_INFORM, lang, NULL,
				msg.c_str(), player->GetGUID());
			SendPacket(&data);
        } break;

		case CHAT_MSG_YELL:
        {
            std::string msg;
            recv_data >> msg;
            sChatHandler.FillMessageData(&data, this, type, lang, NULL, msg.c_str() );
            SendPacket(&data);
            //sWorld.SendGlobalMessage(&data, this);
			GetPlayer()->SendMessageToSet( &data, false );
        } break;

		case CHAT_MSG_EMOTE:
		{
			std::string msg;
			recv_data >> msg;
			sChatHandler.FillMessageData(&data, this, type, lang, NULL, msg.c_str() );
			SendPacket(&data);
			GetPlayer()->SendMessageToSet( &data, false );
		} break;

		case CHAT_MSG_PARTY:
        {
            std::string msg;
            recv_data >> msg;
            if (sChatHandler.ParseCommands(msg.c_str(), this) > 0)
                break;
            if (GetPlayer()->IsInGroup())
            {
                Group *group = objmgr.GetGroupByLeader(GetPlayer()->GetGroupLeader());
                if (group)
                    group->BroadcastToGroup(this, msg);
            }
        }

		default:
            Log::getSingleton().outError("CHAT: unknown msg type %u, lang: %u", type, lang);
    }
}

//-----------------------------------------------------------------------------
void WorldSession::HandleTextEmoteOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint32 text_emote;
    uint64 guid;

    recv_data >> text_emote;
    recv_data >> guid;

    const char *nam = 0;
    uint32 namlen = 1;

	Creature *pCreature = objmgr.GetObject<Creature> (guid);
    if(pCreature)
    {
        nam = pCreature->GetName();
        namlen = strlen( nam ) + 1;
    } else {
		Player *pChar = guid == 1 ? GetPlayer(): objmgr.GetObject<Player> (guid);
        if(pChar)
        {
            nam = pChar->GetName();
            namlen = strlen(nam) + 1;
		} else {
			Log::getSingleton().outError ("CMSG_TEXT_EMOTE: Unknown GUID=%X for emote %d",
				GUID_LOPART (guid), text_emote);
			return;
		}
    }

	EmoteEntry *em = sEmoteStore.LookupEntry(text_emote);
    uint32 emote_anim = em->fmtYou;

    data.Initialize(SMSG_EMOTE);
    data << (uint32)emote_anim;
    data << GetPlayer()->GetGUID();
    WPAssert(data.size() == 12);
    sWorld.SendGlobalMessage(&data);

    data.Initialize(SMSG_TEXT_EMOTE);
    data << GetPlayer()->GetGUID();
    data << (uint32)text_emote;
    data << (uint32)namlen;
    if( namlen > 1 )
    {
        data.append(nam, namlen);
    }
    else
    {
        data << (uint8)0x00;
    }

    WPAssert(data.size() == 16 + namlen);
    SendPacket( &data );
    sWorld.SendGlobalMessage(&data, this);
}

//-----------------------------------------------------------------------------
void WorldSession::HandleAreatriggerOpcode( WorldPacket & recv_data ) {
    Log::getSingleton( ).outDebug( "Areatrigger found! Size: %u", recv_data.size() );
	
	Player *player = this->GetPlayer();
	uint32 triggerID;
	recv_data >> triggerID;

	sChatHandler.GMMessage( this, "GM: Activated AreaTrigger {%d}.", triggerID );

	AreaTriggerQuestPoint *pArea = objmgr.GetAreaTriggerQuestPoint( triggerID );
	Quest *pQuest;

	if (pArea) pQuest = objmgr.GetQuest( pArea->QuestId ); else
		pQuest = NULL;

	QuestScriptBackend::getSingleton().scriptCallAreaTrigger( GetPlayer(), pQuest, triggerID );

    Log::getSingleton( ).outDebug( "Areatrigger with some infos -> %u", triggerID );

	std::stringstream ss;
	ss << "SELECT TargetPosX, TargetPosY, TargetPosZ, TargetOrientation, TargetMapID FROM areatrigger WHERE triggerID=" << triggerID;
	QueryResult *result = sDatabase.Query( ss.str().c_str() );
	if(result)
    {
		//TODO: make this teleport you EVER and not only OFTEN teleport you to the RIGHT Position.
		float TargetPosX, TargetPosY, TargetPosZ, TargetOrientation;
		uint32 TargetMapID;
		Field* fields = result->Fetch();
		TargetPosX = fields[0].GetFloat();
		TargetPosY = fields[1].GetFloat();
		TargetPosZ = fields[2].GetFloat();
		TargetOrientation = fields[3].GetFloat();
		TargetMapID = fields[4].GetUInt32();

		// Check if target != current location
		if (TargetMapID == player->GetMapId() &&
			fabs (TargetPosX - player->GetPositionX()) < 50 &&
			fabs (TargetPosY - player->GetPositionY()) < 50 &&
			fabs (TargetPosZ - player->GetPositionZ()) < 50)
		{
			Log::getSingleton( ).outDebug( "Areatrigger %u will not teleport - too close to trigger location", triggerID );
			return;
		}

		WorldPacket data;
		data.Initialize(SMSG_TRANSFER_PENDING);
		data << uint32(0);
		this->SendPacket(&data);

		this->GetPlayer()->RemoveFromMap();
		
		data.Initialize(SMSG_NEW_WORLD);
		data << (uint32)TargetMapID << (float)TargetPosX << (float)TargetPosY << (float)TargetPosZ << (float)0.0f;	//TargetOrientation;
		this->SendPacket( &data );

		player->SetPosition(TargetPosX, TargetPosY, TargetPosZ, 0); //TargetOrientation);
		player->SetMapId(TargetMapID);

		// TODO: clear attack list
		player->ClearHate();

		delete result;
		return;
	}

	ss.rdbuf()->str("");
	ss << "SELECT triggerID FROM tavern WHERE triggerID=" << triggerID;
	QueryResult *result2 = sDatabase.Query( ss.str().c_str() );
	if(result2)
	{
		if(!GetPlayer()->HasFlag(PLAYER_FLAGS, PLAYER_FLAG_RESTING))
			GetPlayer()->SetFlag(PLAYER_FLAGS, PLAYER_FLAG_RESTING);
	}
	//WorldPacket data;
    /*data.Initialize(SMSG_TRANSFER_PENDING);
    data << uint32(1);
    data << uint32(0x00005148); //48 51 00 00 00 00 00 00
    data << uint32(0);
    SendPacket(&data);

    float x,y,z;
    x = GetPlayer()->GetPositionX();
    y = GetPlayer()->GetPositionY();
    z = GetPlayer()->GetPositionZ();*/

    //smsg_NewWorld(this, 0, float(-8949.95), float(-132.493), float(83.5312));
    //smsg_NewWorld(this, 0, x, y, z);
    //SendPacket(&data);
}

//--- END ---