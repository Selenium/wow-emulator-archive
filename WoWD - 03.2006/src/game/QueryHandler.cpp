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
#include "WorldPacket.h"
#include "WorldSession.h"
#include "Opcodes.h"
#include "Log.h"
#include "World.h"
#include "ObjectMgr.h"
#include "Player.h"
#include "UpdateMask.h"

//////////////////////////////////////////////////////////////
/// This function handles CMSG_NAME_QUERY:
//////////////////////////////////////////////////////////////
void WorldSession::HandleNameQueryOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint64 guid;

    recv_data >> guid;

    PlayerInfo *pn = objmgr.GetPlayerName( guid );

    if(!pn)
        return;

    Log::getSingleton( ).outDebug( "Recieved CMSG_NAME_QUERY for: %s", pn->name.c_str() );

    data.Initialize( SMSG_NAME_QUERY_RESPONSE );

    data << pn->guid;
    data << pn->name;
    data << pn->race << pn->gender << pn->cl;

    SendPacket( &data );
}

//////////////////////////////////////////////////////////////
/// This function handles CMSG_QUERY_TIME:
//////////////////////////////////////////////////////////////
void WorldSession::HandleQueryTimeOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    data.Initialize( SMSG_QUERY_TIME_RESPONSE );

    data << (uint32)time(NULL);
    SendPacket( &data );
}

//////////////////////////////////////////////////////////////
/// This function handles CMSG_CREATURE_QUERY:
//////////////////////////////////////////////////////////////
void WorldSession::HandleCreatureQueryOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint32 entry;
    uint64 guid;
    CreatureInfo *ci;

    recv_data >> entry;
    recv_data >> guid;

    if(entry == 300000)
    {
          data.Initialize( SMSG_CREATURE_QUERY_RESPONSE );
          data << (uint32)entry;
          data << "WayPoint";
          data << uint8(0) << uint8(0) << uint8(0);
          data << "Level is WayPoint ID";
          for(uint32 i = 0; i < 8;i++)
          {
            data << uint32(0);
          }
          data << uint8(0);  
    }
    else
    {
      ci = objmgr.GetCreatureName(entry);
      Log::getSingleton( ).outDetail("WORLD: CMSG_CREATURE_QUERY '%s'", ci->Name.c_str());

      data.Initialize( SMSG_CREATURE_QUERY_RESPONSE );
      data << (uint32)entry;
      data << ci->Name.c_str();
      data << uint8(0) << uint8(0) << uint8(0);
      data << ci->SubName.c_str();
      data << ci->Flags1;  
 	  data << ci->Type;
      data << ci->Family;
      data << ci->Rank;
      data << ci->Unknown1;
	  data << ci->Unknown2;
      data << ci->DisplayID;
	  data << ci->Civilian;
	  data << ci->Unknown2;
    }

    SendPacket( &data );
}

//////////////////////////////////////////////////////////////
/// This function handles CMSG_GAMEOBJECT_QUERY:
//////////////////////////////////////////////////////////////
void WorldSession::HandleGameObjectQueryOpcode( WorldPacket & recv_data )
{

    WorldPacket data;
   
    uint32 entryID;
    uint64 guid;
	GameObjectInfo *goinfo;

    recv_data >> entryID;
    recv_data >> guid;

    Log::getSingleton( ).outDetail("WORLD: CMSG_GAMEOBJECT_QUERY '%u'", entryID);

    goinfo = objmgr.GetGameObjectName(entryID);
    
    data.Initialize( SMSG_GAMEOBJECT_QUERY_RESPONSE );
    data << entryID;
	data << goinfo->Type;
	data << goinfo->DisplayID;
	data << goinfo->Name.c_str();
	data << uint8(0) << uint8(0) << uint8(0);
	data << goinfo->sound0;
	data << goinfo->sound1;
	data << goinfo->sound2;
	data << goinfo->sound3;
	data << goinfo->sound4;
	data << goinfo->sound5;
	data << goinfo->sound6;
	data << goinfo->sound7;
	data << goinfo->sound8;
	data << goinfo->sound9;
	data << goinfo->Unknown1;
	data << goinfo->Unknown2;
	data << goinfo->Unknown3;
	data << goinfo->Unknown4;
	data << goinfo->Unknown5;
	data << goinfo->Unknown6;

    SendPacket( &data );
}

//////////////////////////////////////////////////////////////
/// This function handles MSG_CORPSE_QUERY:
//////////////////////////////////////////////////////////////
void WorldSession::HandleCorpseQueryOpcode(WorldPacket &recv_data)
{
    Log::getSingleton().outDetail("WORLD: Received MSG_CORPSE_QUERY");

    Corpse *pCorpse;
    WorldPacket data;

    pCorpse = objmgr.GetCorpseByOwner(GetPlayer());

    if(pCorpse)
    {
        data.Initialize(MSG_CORPSE_QUERY);
        data << uint8(0x01);
        data << uint32(0x00000001);
        data << pCorpse->GetPositionX();
        data << pCorpse->GetPositionY();
        data << pCorpse->GetPositionZ();
        data << uint32(0x00000001);
        SendPacket(&data);
    }
}

void WorldSession::HandlePageTextQueryOpcode( WorldPacket & recv_data )
{
	uint32 pageid;
	recv_data >> pageid;
	WorldPacket data;
	
	char query[200];
	while(pageid)
	{
		sprintf(query,"SELECT * FROM itempages WHERE ID=%d",pageid);
		QueryResult *result = sDatabase.Query(query);
        data.Initialize(SMSG_PAGE_TEXT_QUERY_RESPONSE);
		data << (uint32)pageid;
		if(!result)
		{
			data << "Text for this page is missing.";
			data << (uint32)0;
			pageid = 0;
		} else {

			data << result->Fetch()[1].GetString();
			data << result->Fetch()[2].GetUInt32();
			pageid =  result->Fetch()[2].GetUInt32();
		}
		SendPacket(&data);
	}

}