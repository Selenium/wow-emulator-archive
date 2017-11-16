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
#include "Opcodes.h"
#include "Log.h"
#include "Player.h"
#include "World.h"
#include "ObjectMgr.h"
#include "UpdateMask.h"


//////////////////////////////////////////////////////////////
/// This function handles CMSG_SKILL_LEVELUP
//////////////////////////////////////////////////////////////

/*void WorldSession::HandleSkillLevelUpOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint32 slot, skill_id, amount, current_points, current_skill, points;
    recv_data >> slot >> skill_id >> amount;
    current_points = GetPlayer( )->GetUInt32Value( PLAYER_SKILL_INFO_1_1+slot+1 );
    current_skill = GetPlayer( )->GetUInt32Value( PLAYER_SKILL_INFO_1_1+slot );
    points = GetPlayer( )->GetUInt32Value( PLAYER_CHARACTER_POINTS2 );
    GetPlayer( )->SetUInt32Value( PLAYER_SKILL_INFO_1_1+slot , ( 0x000001a1 ));
    GetPlayer( )->SetUInt32Value( PLAYER_SKILL_INFO_1_1+slot+1 , ( (current_points & 0xffff) + (amount << 16) ) );
    GetPlayer( )->SetUInt32Value( PLAYER_CHARACTER_POINTS2, points-amount );
    GetPlayer( )->UpdateObject( );
}*/
