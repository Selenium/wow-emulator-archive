// Copyright (C) 2005 WoW Daemon
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
#include "Opcodes.h"
#include "Log.h"
#include "WorldPacket.h"
#include "WorldSession.h"
#include "World.h"
#include "ObjectMgr.h"
#include "Player.h"
#include "Group.h"
#include "Raid.h"

void WorldSession::HandleConvertGroupToRaidOpcode(WorldPacket & recv_data)
{
    WorldPacket data;

    Player *plyr = GetPlayer();

    if(!plyr)
        return;

    if( !plyr->IsInGroup() )
        return;

    Group *group = objmgr.GetGroupByLeader( plyr->GetGroupLeader() );

    if(!group)
        return;

    if ( plyr->GetGroupLeader() != plyr->GetGUID() )
    {
        data.Initialize( SMSG_PARTY_COMMAND_RESULT );
        data << uint32( 0x0 );
        data << uint8( 0 );
        data << uint32( 0x00000006 );

        SendPacket( &data );
        return;
    }

    group->ConvertToRaid();
    data.Initialize( SMSG_PARTY_COMMAND_RESULT );
    data << uint32( 0x0 );
    data << uint8( 0 );
    data << uint32( 0x00000000 );

    SendPacket( &data );

    Raid *raid = objmgr.GetRaidByLeader( plyr->GetGroupLeader() );

    if(!raid)
        return;

    raid->SendUpdate();
}

void WorldSession::HandleGroupChangeSubGroup(WorldPacket & recv_data)
{
    WorldPacket data;

    std::string name;
    uint8 subGroup;

    recv_data >> name;
    recv_data >> subGroup;

    Player *plyr = objmgr.GetPlayer(name.c_str());
    if(!plyr)
        return;

    Raid *pRaid = objmgr.GetRaidByLeader(plyr->GetGroupLeader());
    if(!pRaid)
        return;

    pRaid->ChangeMemberSubGroup(plyr->GetGUID(),subGroup);    
}

void WorldSession::HandleGroupAssistantLeader(WorldPacket & recv_data)
{
    WorldPacket data;
    //80

    std::string name;
    uint8 subGroup;

    recv_data >> name;
    recv_data >> subGroup;

    Player *plyr = objmgr.GetPlayer(name.c_str());
    if(!plyr)
        return;

    Raid *pRaid = objmgr.GetRaidByLeader(plyr->GetGroupLeader());
    if(!pRaid)
        return;

    pRaid->ChangeSubGroupLeader(plyr->GetGUID(),subGroup);
}

void WorldSession::HandleRequestRaidInfoOpcode(WorldPacket & recv_data)
{  
 //      	SMSG_RAID_INSTANCE_INFO             = 716,  //(0x2CC)    
}