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
#include "Log.h"
#include "WorldPacket.h"
#include "WorldSession.h"
#include "World.h"
#include "ObjectMgr.h"

void WorldSession::HandleAttackSwingOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint64 guid;
    recv_data >> guid;

    // AttackSwing
    Log::getSingleton( ).outDebug( "WORLD: Recvd CMSG_ATTACKSWING Message" );

	Unit *pEnemy;
    pEnemy = objmgr.GetObject<Creature>(guid);
    if(!pEnemy)
	{
		pEnemy = objmgr.GetObject<Player>(guid);
	}

    if(!pEnemy)
    {
        Log::getSingleton( ).outError( "WORLD: %u %.8X is not a creature",
            GUID_LOPART(guid), GUID_HIPART(guid));
        return; // we do not attack PCs for now
    }

    if(GetPlayer()->IsPacified() || GetPlayer()->IsStunned())
        return;

    GetPlayer()->addStateFlag(UF_ATTACKING);
    GetPlayer()->smsg_AttackStart(pEnemy);
    GetPlayer()->EventAttackStart();
}


void WorldSession::HandleAttackStopOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint64 guid = GetPlayer()->GetSelection();

    GetPlayer()->EventAttackStop();

    GetPlayer()->smsg_AttackStop(guid);

    GetPlayer()->clearStateFlag(UF_ATTACKING);
    // GetPlayer()->removeCreatureFlag(0x00080000);
}
