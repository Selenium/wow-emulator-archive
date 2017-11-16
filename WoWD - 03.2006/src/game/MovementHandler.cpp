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
	uint32 time;
	uint64 unk1;
	float unk2, unk3, unk4, unk5;
	float unk6;
	uint32 FallTime;
	float unk8, unk9, unk10, unk11, unk12;
	public:
	float x, y, z, orientation;
	uint32 flags;
	
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
    //uint32 flags, time;
    //float x, y, z, orientation;
	MovementInfo mi(recv_data);

	if(GetPlayer()->GetPlayerStatus() == TRANSFER_PENDING) //dont update coords
		return;


   // recv_data >> flags >> time;
   // recv_data >> x >> y >> z >> orientation;

    if( GetPlayer() && !GetPlayer( )->SetPosition(mi.x, mi.y, mi.z, mi.orientation) )
    {
        WorldPacket movedata;

        GetPlayer( )->BuildTeleportAckMsg(&movedata, GetPlayer()->GetPositionX(),
            GetPlayer()->GetPositionY(), GetPlayer()->GetPositionZ(), GetPlayer()->GetOrientation() );

        SendPacket(&movedata);
    }

    WorldPacket data;
    data.Initialize( MSG_MOVE_HEARTBEAT );

    data << GetPlayer()->GetNewGUID();
    //data << flags << time;
    //data << x << y << z << orientation;
	mi >> data;
    GetPlayer( )->SendMessageToSet(&data, false);
}


void WorldSession::HandleMoveWorldportAckOpcode( WorldPacket & recv_data )
{
    Log::getSingleton( ).outDebug( "WORLD: got MSG_MOVE_WORLDPORT_ACK." );
    GetPlayer()->AddToWorld();
	GetPlayer()->SetPlayerStatus(NONE);
}

void WorldSession::HandleFallOpcode( WorldPacket & recv_data )
{

	uint32 flags, time;
    float x, y, z, orientation;
    //float unk1, unk2, unk3, unk4;
	uint32 FallTime;

//	uint64 guid;
	uint8 type;
	uint32 damage;

	if(GetPlayer()->GetPlayerStatus() == TRANSFER_PENDING) //dont update coords
		return;

	recv_data >> flags >> time;
    recv_data >> x >> y >> z >> orientation;
	recv_data >> FallTime;
	if ( FallTime > 1100 && !GetPlayer()->isDead() ) {
        uint32 maxhealth = GetPlayer()->GetUInt32Value(UNIT_FIELD_MAXHEALTH);		
//		guid = GetPlayer()->GetNewGUID();
		type = DAMAGE_FALL;
        //2.2 sec of fall kill player
        damage = (maxhealth/2200)*FallTime;
//		damage = (uint32)((FallTime - 1100)/100)+1;
//		Log::getSingleton().outError("Falling for %d time and %d damage taken.",FallTime,damage);
		WorldPacket data;
		data.Initialize(SMSG_ENVIRONMENTALDAMAGELOG);
		data << GetPlayer()->GetGUID();
		data << type;
		data << damage;
		SendPacket(&data);
		GetPlayer()->DealDamage(GetPlayer(), damage, 0, 0, 0);
	}
}
void WorldSession::HandleMovementOpcodes( WorldPacket & recv_data )
{
    //uint32 flags, time;
    //float x, y, z, orientation;
    //float unk1, unk2, unk3, unk4, unk5;
	MovementInfo mi(recv_data);

	if(GetPlayer()->GetPlayerStatus() == TRANSFER_PENDING) //dont update coords
		return;

   // recv_data >> flags >> time;
   // recv_data >> x >> y >> z >> orientation;

    if( GetPlayer() && !GetPlayer( )->SetPosition(mi.x, mi.y, mi.z, mi.orientation) )
    {
        WorldPacket movedata;
        GetPlayer( )->BuildTeleportAckMsg(&movedata, GetPlayer()->GetPositionX(),
            GetPlayer()->GetPositionY(), GetPlayer()->GetPositionZ(), GetPlayer()->GetOrientation() );

        SendPacket(&movedata);
    }

    WorldPacket data;
    data.Initialize( recv_data.GetOpcode() );

    data << GetPlayer()->GetNewGUID();
    //data << flags << time;
    //data << x << y << z << orientation;
	mi >> data;
    GetPlayer()->SendMessageToSet(&data, false);
	
	WorldPacket ptmp;
	
#define WMSG(message) ptmp.clear(); \
	sChatHandler.FillSystemMessageData(&ptmp,this, message); \
	SendPacket(&ptmp);

#define CLEARBREATH if(GetPlayer()->m_BreathingAir != 1) { \
	sEventMgr.RemoveEvents(GetPlayer(),EVENT_PLAYER_UNDERWATER); \
	swimpkt.Initialize(SMSG_START_MIRROR_TIMER); \
	swimpkt << (uint32)1; \
	swimpkt << (uint32)GetPlayer()->m_Breath; \
	swimpkt << (uint32)30000; \
	swimpkt << (uint32)10; \
	swimpkt << (uint32)0; \
	SendPacket(&swimpkt); \
	GetPlayer()->m_BreathingAir = 1; \
	GetPlayer()->EventBreathRegen(); \
	}
    
	WorldPacket swimpkt;

	if(GetPlayer()->m_StartSwimHeight != 0)
	{
		if(GetPlayer()->m_StartSwimHeight < mi.z)
		{
			if(mi.flags & 0x00200000)
			{
				// we're not underwater but still swimming
				// WMSG("we're not underwater but still swimming");
				CLEARBREATH;
				/*if(GetPlayer()->m_BreathingAir != 1)
				{
					swimpkt.Initialize(SMSG_START_MIRROR_TIMER);
					swimpkt << (uint32)1;	// breath
					swimpkt << (uint32)10000;
					swimpkt << (uint32)30000;
					swimpkt << (uint32)10;
					swimpkt << (uint32)0;
					SendPacket(&swimpkt);
					GetPlayer()->m_BreathingAir = 1;
				}
				GetPlayer()->m_Breath = 30000;*/
			} else {
				// we're not swimming
				// WMSG("we're not swimming");
				GetPlayer()->m_StartSwimHeight = 0;
				CLEARBREATH;
				/*if(GetPlayer()->m_BreathingAir != 1)
				{
					swimpkt.Initialize(SMSG_START_MIRROR_TIMER);
					swimpkt << (uint32)1;	// breath
					swimpkt << (uint32)10000;
					swimpkt << (uint32)30000;
					swimpkt << (uint32)10;
					swimpkt << (uint32)0;
					GetPlayer()->m_BreathingAir = 1;
				}*/
			}
		} else {
			// we're swimming
			//WMSG("we're swimming");
			if(GetPlayer()->m_BreathingAir == 1)
			{
				GetPlayer()->m_BreathingAir = 0;
				//sEventMgr.AddEvent(GetPlayer(),&Player::EventBreathReduce(),EVENT_PLAYER_UNDERWATER,500,0);
				//Class *obj, void (Class::*method)(), uint32 flags, uint32 time, uint32 repeats
				GetPlayer()->EventBreathReduce();
				sEventMgr.RemoveEvents(GetPlayer(),EVENT_PLAYER_REGENBREATH);
				swimpkt.Initialize(SMSG_START_MIRROR_TIMER);
				swimpkt << (uint32)1;	// breath
				swimpkt << (uint32)30000;	// breath
				swimpkt << (uint32)30000;	// remaining
				swimpkt << (uint32)-1;	// regen
				swimpkt << (uint32)0;
				SendPacket(&swimpkt);
			}
		}
	}

	if(recv_data.GetOpcode() == MSG_MOVE_START_SWIM)
	{
		GetPlayer()->m_StartSwimHeight = (mi.z - 0.15f);
		GetPlayer()->m_Breath = 30000;		// 30 secs
	}

}

void WorldSession::HandleMoveTimeSkippedOpcode( WorldPacket & recv_data )
{
    //flood fix
}
/*{CLIENT} Packet: (0x02D1) CMSG_MOVE_NOT_ACTIVE_MOVER PacketSize = 28
|------------------------------------------------|----------------|
|00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F |0123456789ABCDEF|
|------------------------------------------------|----------------|
|00 00 00 00 |3B D0 7D 0B |5F 5E 61 45 |0F 43 89 C5 |....;.}._^aE.C..|
||70 BA E7 42 |8B 6D 00 40 00 00 00 00             |p..B.m.@....    |
-------------------------------------------------------------------
uint32 unk
flags
uint64 plyrguid
*/
void WorldSession::HandleMoveNotActiveMoverOpcode( WorldPacket & recv_data )
{
    //uint32 flags, time;
    //float x, y, z, orientation;
    //float unk1, unk2, unk3, unk4, unk5;
	MovementInfo mi(recv_data);

	if(GetPlayer()->GetPlayerStatus() == TRANSFER_PENDING) //dont update coords
		return;

   // recv_data >> flags >> time;
   // recv_data >> x >> y >> z >> orientation;

    if( GetPlayer() && !GetPlayer( )->SetPosition(mi.x, mi.y, mi.z, mi.orientation) )
    {
        WorldPacket movedata;
        GetPlayer( )->BuildTeleportAckMsg(&movedata, GetPlayer()->GetPositionX(),
            GetPlayer()->GetPositionY(), GetPlayer()->GetPositionZ(), GetPlayer()->GetOrientation() );

        SendPacket(&movedata);
    }

    WorldPacket data;
    data.Initialize( recv_data.GetOpcode() );

    data << GetPlayer()->GetNewGUID();
    //data << flags << time;
    //data << x << y << z << orientation;
	mi >> data;
    GetPlayer()->SendMessageToSet(&data, false);
}

/*{CLIENT} Packet: (0x026A) CMSG_SET_ACTIVE_MOVER PacketSize = 8
|------------------------------------------------|----------------|
|00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F |0123456789ABCDEF|
|------------------------------------------------|----------------|
|29 1F 1E 00 00 70 00 F0                         |)....p..        |
-------------------------------------------------------------------
uint64 creatureGuid
*/

void WorldSession::HandleSetActiveMoverOpcode( WorldPacket & recv_data )
{
}