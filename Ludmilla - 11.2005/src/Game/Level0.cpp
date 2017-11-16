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

/////////////////////////////////////////////////
//  Normal User Chat Commands
//
//-----------------------------------------------------------------------------
bool ChatHandler::ShowHelpForCommand(ChatCommand *table, const char* cmd)
{
    for(uint32 i = 0; table[i].Name != NULL; i++)
    {
        if(!hasStringAbbr(table[i].Name, cmd))
            continue;

        if(m_session->GetSecurity() < table[i].SecurityLevel)
            continue;

        if(table[i].ChildCommands != NULL)
        {
            cmd = strtok(NULL, " ");
            if(cmd && ShowHelpForCommand(table[i].ChildCommands, cmd))
                return true;
        }

        if(table[i].Help == "")
        {
            WorldPacket data;
            FillSystemMessageData(&data, m_session, "There is no help for that command");
            m_session->SendPacket(&data);
            return true;
        }

        SendMultilineMessage(table[i].Help.c_str());

        return true;
    }

    return false;
}

//-----------------------------------------------------------------------------
bool ChatHandler::HandleHelpCommand(const char* args)
{
    ChatCommand *table = getCommandTable();
    WorldPacket data;

    if(!*args)
        return false;

    char* cmd = strtok((char*)args, " ");
    if(!cmd)
        return false;

    if(!ShowHelpForCommand(getCommandTable(), cmd))
    {
		char msg[256];
		sprintf (msg, "Unknown command: %s", cmd);
		FillSystemMessageData(&data, m_session, msg);
        m_session->SendPacket( &data );
    }

    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::Command_Commands (const char* args)
{
    ChatCommand *table = getCommandTable();
    WorldPacket data;

	m_session->SystemMessage ("Available commands:");
    m_session->SendPacket(&data);

	std::string	msg;

    for(uint32 i = 0; table[i].Name != NULL; i++)
    {
        if(*args && !hasStringAbbr(table[i].Name, (char*)args))
            continue;

        if(m_session->GetSecurity() < table[i].SecurityLevel)
            continue;

		// Format command help
		ChatCommand * child = table[i].ChildCommands;
		msg += "|cffcccccc";
		msg += table[i].Name;

		if (child != NULL) {
			msg += " (|cffccccff";

			for (uint32 q = 0; child[q].Name != NULL; q++)
			{
				msg += child[q].Name;
				if (child[q+1].Name != NULL)
					msg += ", ";

				// Flush too long lines
				if (msg.size() > 200) {
					m_session->SystemMessage ((char *)msg.c_str());
					msg = "|cffccccff";
				}
			}
			msg += "|cffcccccc)";
		}

		if (table[i+1].Name != NULL)
			msg += ", ";

		// Flush too long lines
		if (msg.size() > 200) {
			m_session->SystemMessage ((char *)msg.c_str());
			msg = "|cffcccccc";
		}
    }

	// Flush the rest
	if (msg.size()) {
		msg += ".";
		m_session->SystemMessage ((char *)msg.c_str());
	}
	m_session->SystemMessage ("Subcommands grouped by color and brackets. "\
		"Use |cffccccff.help cmd|r, or |cffccccff.help cmd subcmd|r to read short "\
		"command descriptions.");

    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::HandleVersionCommand(const char* args)
{
	m_session->SystemMessage(FULLSERVERNAME);
	return true;
}
//-----------------------------------------------------------------------------
bool ChatHandler::HandleAcctCommand(const char* args)
{
    WorldPacket data;

    uint32 gmlevel = m_session->GetSecurity(); // get account level
    char buf[256];
    sprintf(buf, "Your access level is: %i", gmlevel);
    FillSystemMessageData(&data, m_session, buf);
    m_session->SendPacket( &data ); // send message

    return true;
}

//-----------------------------------------------------------------------------

bool ChatHandler::HandleStartCommand(const char* args)
{
    Player *chr = m_session->GetPlayer();
    chr->SetUInt32Value(PLAYER_FARSIGHT, 0x01); // what does that do?

    //PlayerCreateInfo *info = objmgr.GetPlayerCreateInfo(
    //    m_session->GetPlayer()->GetRace(), m_session->GetPlayer()->GetClass());
    //ASSERT(info);

	switch (chr->GetRace())
	{
		case RACE_HUMAN:		m_session->GetPlayer()->TeleportFar (0, -8949.95, -132.493, 83.5312); break;
		case RACE_ORC:			m_session->GetPlayer()->TeleportFar (1, -618.518, -4251.67, 38.718); break;
		case RACE_DWARF:		m_session->GetPlayer()->TeleportFar (0, -6240.32, 331.033, 382.758); break;
		case RACE_NIGHT_ELF:	m_session->GetPlayer()->TeleportFar (1, 10311.3, 832.463, 1326.41); break;
		case RACE_UNDEAD:		m_session->GetPlayer()->TeleportFar (0, 1676.35, 1677.45, 121.67); break;
		case RACE_TAUREN:		m_session->GetPlayer()->TeleportFar (1, -2917.58, -257.98, 52.9968); break;
		case RACE_GNOME:		m_session->GetPlayer()->TeleportFar (0, -6240.32, 331.033, 382.758); break;
		case RACE_TROLL:		m_session->GetPlayer()->TeleportFar (1, -618.518, -4251.67, 38.718); break;
	}


    //m_session->GetPlayer()->TeleportFar (info->mapId, info->positionX,
	//	info->positionY, info->positionZ);

	return true;
}


//-----------------------------------------------------------------------------
bool ChatHandler::HandleInfoCommand(const char* args)
{
    WorldPacket data;

    uint32 clientsNum = sWorld.GetSessionCount();
    char buf[256];

    //more info come.. right now only display users connected
    sprintf((char*)buf,"Number of users connected: %i", (int) clientsNum);
    FillSystemMessageData(&data, m_session, buf);
    m_session->SendPacket( &data );

    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::HandleNYICommand(const char* args)
{
    WorldPacket data;
    char buf[256];

    sprintf((char*)buf,"Not implemented");
    FillSystemMessageData(&data, m_session, buf);
    m_session->SendPacket( &data );

    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::HandleMountCommand(const char* args)
{
    WorldPacket data;

    uint8 theLevel = m_session->GetPlayer()->GetLevel(); // get level
    uint16 mId=1147;
    float speed = (float)8;
    uint8 theRace = m_session->GetPlayer()->GetRace();
    uint32 num=0;

    if (theLevel < 10 )
    {
        // If not level 10, then this text will be displayed
        FillSystemMessageData(&data, m_session, "You must be at least level 10 to mount.");
        m_session->SendPacket( &data );
        return true;
    }
    else
    {
        char* pMount = strtok((char*)args, " ");
        if( pMount )
        {
            num = atoi(pMount);
            switch(num)
            {
            case 1: //nothing to do, min lvl mount lvl 10, lol
                break;
            case 2:
                if(theLevel<15) num=1;
                break;
            case 3:
                if(theLevel<20)
                    if(theLevel<15) num=1;
                        else
                    num=2;
                break;
            default:
                return true;
            }
        }
        else
        {
            if(theLevel>19)
                num=3;
            else
                if(theLevel>14)
                    num=2;
                else
                    num=1;
        }
        if (num > 2 )
        {
            switch(theRace)
            {
            case 1: //HUMAN
                mId=1147;
                break;
            case 2: //ORC
                mId=295;
                break;
            case 3: //DWARF
                mId=1147;
                break;
            case 4: //NIGHT ELF
                mId=479;
                break;
            case 5: //UNDEAD
                mId=1147; //need to change
                break;
            case 6: //TAUREN
                mId=295;
                break;
            case 7: //GNOME
                mId=1147;
                break;
            case 8: //TROLL
                mId=479;
                break;
            }
        }
        else if (num > 1 )
        {
            switch(theRace)
            {
            case 1: //HUMAN
                mId=1531;
                break;
            case 2: //ORC
                mId=207; //need to change
                break;
            case 3: //DWARF
                mId=2786;
                break;
            case 4: //NIGHT ELF
                mId=720;
                break;
            case 5: //UNDEAD
                mId=2346;
                break;
            case 6: //TAUREN
                mId=180;
                break;
            case 7: //GNOME
                mId=1147; //need to change
                break;
            case 8: //TROLL
                mId=1340;
                break;
            }
        }
        else
        {
            switch(theRace)
            {
            case 1: //HUMAN
                mId=236;
                break;
            case 2: //ORC
                mId=207;
                break;
            case 3: //DWARF
                mId=2186;
                break;
            case 4: //NIGHT ELF
                mId=632;
                break;
            case 5: //UNDEAD
                mId=5050;
                break;
            case 6: //TAUREN
                mId=1220;
                break;
            case 7: //GNOME
                mId=748; //need to change
                break;
            case 8: //TROLL
                mId=2320;
                break;
            }
        }
    }

    m_session->GetPlayer( )->SetUInt32Value( UNIT_FIELD_MOUNTDISPLAYID , mId);
    m_session->GetPlayer( )->SetUInt32Value( UNIT_FIELD_FLAGS , 0x002000 );

    if (theLevel < 60)	speed = 1.60f;
    else				speed = 2.00f;

	m_session->GetPlayer( )->SetSpeedMod (speed);

    /*
	data.Initialize( SMSG_FORCE_RUN_SPEED_CHANGE );
    data << m_session->GetPlayer( )->GetUInt32Value( OBJECT_FIELD_GUID );
    data << m_session->GetPlayer( )->GetUInt32Value( OBJECT_FIELD_GUID + 1 );
    data << speed;
    WPAssert(data.size() == 12);
    m_session->GetPlayer( )->SendMessageToSet( &data, true );
	*/


    char cmount[256];
    sprintf(cmount, "You got a level %i mount at %i speed.", num, (int)speed);
    FillSystemMessageData(&data, m_session, cmount);
    m_session->SendPacket( &data ); // send message

    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::HandleDismountCommand(const char* args)
{
    WorldPacket data;

    m_session->GetPlayer( )->SetUInt32Value(UNIT_FIELD_MOUNTDISPLAYID , 0);
    m_session->GetPlayer( )->RemoveFlag( UNIT_FIELD_FLAGS, 0x002000 );

    // Remove the "player locked" flag, to allow movement
    if (m_session->GetPlayer( )->GetUInt32Value(UNIT_FIELD_FLAGS) & 0x000004 )
        m_session->GetPlayer( )->RemoveFlag( UNIT_FIELD_FLAGS, 0x000004 );

    float dmspeed = 7.5f; // Exact value of normal player speed

    data.Initialize( SMSG_FORCE_RUN_SPEED_CHANGE );
    data << m_session->GetPlayer( )->GetUInt32Value( OBJECT_FIELD_GUID );
    data << m_session->GetPlayer( )->GetUInt32Value( OBJECT_FIELD_GUID + 1 );
    data << dmspeed;
    WPAssert(data.size() == 12);

    m_session->GetPlayer( )->SendMessageToSet( &data, true );

    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::HandleSaveCommand(const char* args)
{
    WorldPacket data;

    m_session->GetPlayer()->SaveToDB();
    FillSystemMessageData(&data, m_session, "Player saved.");
    m_session->SendPacket( &data );
    return true;
}

//-----------------------------------------------------------------------------
bool ChatHandler::HandleGMListCommand(const char* args)
{
    WorldPacket data;
    bool first = true;

    ObjectMgr::PlayerMap::const_iterator itr;
    for (itr = objmgr.Begin<Player>(); itr != objmgr.End<Player>(); itr++)
    {
        if(itr->second->GetSession()->GetSecurity())
        {
            if(first)
            {
                FillSystemMessageData(&data, m_session, "Following GMs now online:");
                m_session->SendPacket( &data );
            }

            FillSystemMessageData(&data, m_session, itr->second->GetName());
            m_session->SendPacket( &data );

            first = false;
        }
    }

    if(first)
    {
        FillSystemMessageData(&data, m_session, "There are no GMs currently online.");
        m_session->SendPacket( &data );
    }

    return true;
}

//--- END ---