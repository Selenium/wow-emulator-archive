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
#include "Affect.h"
#include "UpdateMask.h"
#include "AreaTrigger.h"

void WorldSession::HandleAreaTriggerOpcode(WorldPacket & recv_data)
{
	uint32 id;
	WorldPacket data;
	AreaTrigger *pAreaTrigger;
	recv_data >> id;
	printf("AreaTrigger: %u\n", id);

	pAreaTrigger = sWorld.GetAreaTrigger(id);

	if(pAreaTrigger)
	{
		switch(pAreaTrigger->Type)
		{
		case ATTYPE_INSTANCE:
			{
				data.Initialize(SMSG_TRANSFER_PENDING);
				data << pAreaTrigger->PendingScreen;
				SendPacket(&data);

				GetPlayer()->SetPlayerStatus(TRANSFER_PENDING);

				GetPlayer()->RemoveFromWorld();

				data.Initialize(SMSG_NEW_WORLD);
				data << pAreaTrigger->Mapid << pAreaTrigger->x << pAreaTrigger->y << pAreaTrigger->z << float(0);
				SendPacket(&data);


				GetPlayer()->SetMapId(pAreaTrigger->Mapid);
				GetPlayer()->SetPosition(pAreaTrigger->x,pAreaTrigger->y,pAreaTrigger->z,0);
			}break;
		case ATTYPE_QUESTTRIGGER:
			{

			}break;
		case 3:
			{
				// Inn
				if (!GetPlayer()->m_isResting) GetPlayer()->EnterInn();
			}break;
		default:break;
		}
	}
}

void World::LoadAreaTriggerInformation()
{
	QueryResult *result;
	uint32 MaxID=0;
	uint32 currid;
	AreaTrigger *pAT;

	 result = sDatabase.Query("SELECT * FROM areatriggers");
    
    if(result==NULL)
        return;

    do
    {
        Field *fields = result->Fetch();
		pAT = new AreaTrigger;

		pAT->AreaTriggerID = fields[0].GetUInt32();
		pAT->Type = (uint8)fields[1].GetUInt32();
		pAT->Mapid = fields[2].GetUInt32();
		pAT->PendingScreen = fields[3].GetUInt32();
		pAT->Name= fields[4].GetString();
		pAT->x = fields[5].GetFloat();
		pAT->y = fields[6].GetFloat();
		pAT->z = fields[7].GetFloat();
        
		AddAreaTrigger(pAT);
    } while( result->NextRow() );
}

AreaTrigger *World::GetAreaTrigger(uint32 id)
{
	AreaTriggerMap::iterator iter, end;
    for( iter = m_AreaTrigger.begin(), end = m_AreaTrigger.end(); iter != end; iter++ )
    {
        AreaTrigger *pAT = iter->second;
        if(pAT->AreaTriggerID == id)
            return pAT;
    }
    return NULL;
}

void World::AddAreaTrigger(AreaTrigger *pArea)
{
	ASSERT( pArea->AreaTriggerID );
	ASSERT( m_AreaTrigger.find(pArea->AreaTriggerID) == m_AreaTrigger.end() );

    m_AreaTrigger[pArea->AreaTriggerID] = pArea;
}

