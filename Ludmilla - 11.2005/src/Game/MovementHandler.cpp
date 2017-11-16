#include "StdAfx.h"

//-----------------------------------------------------------------------------
class MovementInfo
{
protected:
	friend class WorldSession;

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

//-----------------------------------------------------------------------------
void WorldSession::HandleMoveHeartbeatOpcode( WorldPacket & recv_data )
{
	MovementInfo mi(recv_data);

	Player *player = GetPlayer();

	if( player ) {
		if( player->m_falldetect_time != 0 ) {
			uint32	dt = mi.time - player->m_falldetect_time;
			float	dz = player->m_falldetect_z - mi.z;
			float	speed = dt? dz * 1000.0f / dt: 0;

			player->m_falldetect_speed = speed;
			//Log::getSingleton( ).outDebug( "Fall Damage Detect: dt=%d, dz=%.1f speed=%.1f", dt, dz, speed );
		}
		player->m_falldetect_z = mi.z;
		player->m_falldetect_time = mi.time;
	}

	player->RemoveFromWorld();
	bool setpos = player->SetPosition(mi.x, mi.y, mi.z, mi.orientation);
	player->AddToWorld();
    if( player && ! setpos )
    {
        WorldPacket movedata;

        player->BuildTeleportAckMsg(&movedata, player->GetPositionX(),
            player->GetPositionY(), player->GetPositionZ(), player->GetOrientation() );

        SendPacket(&movedata);
    }

	float dx = player->GetPositionX() - player->m_motionTrackX;
	float dy = player->GetPositionY() - player->m_motionTrackY;
	float dz = player->GetPositionZ() - player->m_motionTrackZ;
	float sqDist = (dx*dx)+(dy*dy)+(dz*dz);

	if (sqDist < 40.0f * 40.0f)
		player->m_mapMgr->ChangeObjectLocation (player, player->m_motionTrackX, player->m_motionTrackY);

	player->motiontrack_ReadPosition();

	WorldPacket data;
    data.Initialize( MSG_MOVE_HEARTBEAT );

    data << GetPlayer()->GetGUID();
	mi >> data;

    GetPlayer( )->SendMessageToSet(&data, false);
}


//-----------------------------------------------------------------------------
void WorldSession::HandleMoveWorldportAckOpcode( WorldPacket & recv_data )
{
    Log::getSingleton( ).outDebug( "WORLD: got MSG_MOVE_WORLDPORT_ACK." );
    GetPlayer()->PlaceOnMap();
}

//-----------------------------------------------------------------------------
void WorldSession::HandleMovementFall( WorldPacket & recv_data )
{
	Player *player = GetPlayer();
	
	if (player && player->isAlive() && player->m_falldetect_speed > 15.0f)
	{
		float fallpower = player->m_falldetect_speed - 15.0f;
		//uint32 dmg = (uint32)(10.0f * fallpower + 0.2f * fallpower * fallpower);
		
		// Divider 45 takes <50% of life when fall from 50m, and 75% from 100m
		uint32 dmg = uint32 (fallpower * player->GetMaxHealth() / 35.0f);

		Log::getSingleton( ).outDebug( "Long fall detected, damage=%d", dmg );
		player->GetSession()->SystemMessage ("You suffered %d points of falling damage", dmg);
		player->TakeDamage (dmg);
		
		player->m_falldetect_speed = 0;
	}
}

//-----------------------------------------------------------------------------
void WorldSession::HandleMovementOpcodes( WorldPacket & recv_data )
{
	MovementInfo mi(recv_data);
	Player *player = GetPlayer();

    if (player)
	{
		player->RemoveFromWorld();
		bool setpos = player->SetPosition(mi.x, mi.y, mi.z, mi.orientation);
		player->AddToWorld();
		if (! setpos)
		{
	        WorldPacket movedata;
		    player->BuildTeleportAckMsg (&movedata, player->GetPositionX(),
			    player->GetPositionY(), player->GetPositionZ(), player->GetOrientation() );

			SendPacket(&movedata);
		}

		float dx = player->GetPositionX() - player->m_motionTrackX;
		float dy = player->GetPositionY() - player->m_motionTrackY;
		float dz = player->GetPositionZ() - player->m_motionTrackZ;
		float sqDist = (dx*dx)+(dy*dy)+(dz*dz);

		if (sqDist < 40.0f * 40.0f)
			player->m_mapMgr->ChangeObjectLocation (player, player->m_motionTrackX, player->m_motionTrackY);

		player->motiontrack_ReadPosition();
    }

    WorldPacket data;
    data.Initialize( recv_data.GetOpcode() );

    data << GetPlayer()->GetGUID();
	mi >> data;

    GetPlayer()->SendMessageToSet(&data, false);
}

void WorldSession::HandleSetActiveMoverOpcode(WorldPacket &recv_data)
{
    uint32 guild, time;
    recv_data >> guild >> time;
}

//--- END ---