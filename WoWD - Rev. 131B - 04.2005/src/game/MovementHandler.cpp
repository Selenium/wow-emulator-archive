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
#include "WorldPacket.h"
#include "WorldSession.h"
#include "Opcodes.h"
#include "Log.h"
#include "World.h"
#include "ObjectMgr.h"
#include "Player.h"
#include "UpdateMask.h"

class MovementInfo
{
	uint32 flags, time;
	uint64 unk1;
	float unk2, unk3, unk4, unk5;
	float unk6;
	uint32 FallTime;
	float unk8, unk9, unk10, unk11, unk12;
	public:
	float x, y, z, orientation;
	
	MovementInfo(WorldPacket &data)
	{
		data >> flags >> time;
		data >> x >> y >> z >> orientation;
		
		if (flags & 0x2000000) // Transport
		{
			data >> unk1 >> unk2 >> unk3 >> unk4 >> unk5;
		}
		if (flags & 0x200000) // Swimming
		{
			data >> unk6;
		}
		if (flags & 0x2000) // Falling
		{
			data >> FallTime >> unk8 >> unk9 >> unk10 >> unk11;
		}
		if (flags & 0x4000000)
		{
			data >> unk12;
		}
	}
	
	MovementInfo &operator >>(WorldPacket &data)
	{
		data << flags << time;
		data << x << y << z << orientation;
		
		if (flags & 0x2000000) // Transport
		{
			data << unk1 << unk2 << unk3 << unk4 << unk5;
		}
		if (flags & 0x200000) // Swimming
		{
			data << unk6;
		}
		if (flags & 0x2000) // Falling
		{
			data << FallTime << unk8 << unk9 << unk10 << unk11;
		}
		if (flags & 0x4000000)
		{
			data << unk12;
		}
		return *this;
	}
};


void WorldSession::HandleMoveHeartbeatOpcode( WorldPacket & recv_data )
{
	MovementInfo mi(recv_data);

    if( GetPlayer() && !GetPlayer( )->SetPosition(mi.x, mi.y, mi.z, mi.orientation) )
    {
        WorldPacket movedata;

        GetPlayer( )->BuildTeleportAckMsg(&movedata, GetPlayer()->GetPositionX(),
            GetPlayer()->GetPositionY(), GetPlayer()->GetPositionZ(), GetPlayer()->GetOrientation() );

        SendPacket(&movedata);
    }

    WorldPacket data;
    data.Initialize( MSG_MOVE_HEARTBEAT );

    data << GetPlayer()->GetGUID();
	mi >> data;

    GetPlayer( )->SendMessageToSet(&data, false);
}


void WorldSession::HandleMoveWorldportAckOpcode( WorldPacket & recv_data )
{
    Log::getSingleton( ).outDebug( "WORLD: got MSG_MOVE_WORLDPORT_ACK." );
    GetPlayer()->PlaceOnMap();
}

void WorldSession::HandleMovementOpcodes( WorldPacket & recv_data )
{
	MovementInfo mi(recv_data);

    if( GetPlayer() && !GetPlayer( )->SetPosition(mi.x, mi.y, mi.z, mi.orientation) )
    {
        WorldPacket movedata;
        GetPlayer( )->BuildTeleportAckMsg(&movedata, GetPlayer()->GetPositionX(),
            GetPlayer()->GetPositionY(), GetPlayer()->GetPositionZ(), GetPlayer()->GetOrientation() );

        SendPacket(&movedata);
    }

    WorldPacket data;
    data.Initialize( recv_data.GetOpcode() );

    data << GetPlayer()->GetGUID();
	mi >> data;

    GetPlayer()->SendMessageToSet(&data, false);
}
