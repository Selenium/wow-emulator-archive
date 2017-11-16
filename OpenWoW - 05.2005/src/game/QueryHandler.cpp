//////////////////////////////////////////////////////////////////////
//  Query Handler
//
//  Handles Object querys
//////////////////////////////////////////////////////////////////////

// Copyright (C) 2004 Team Python
// Copyright (C) 2004, 2005 Team WSD
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

#include "QueryHandler.h"
#include "NetworkInterface.h"
#include "GameClient.h"
#include "Opcodes.h"
#include "Log.h"
#include "WorldServer.h"
#include "Character.h"
#include "UpdateMask.h"
#include "Database.h"

#include <time.h>

QueryHandler::QueryHandler()
{

}

QueryHandler::~QueryHandler()
{

}


void QueryHandler::HandleMsg( NetworkPacket & recv_data, GameClient *pClient )
{
    NetworkPacket data;
    char f[256];
    sprintf(f, "WORLD: Query Opcode 0x%.4X", recv_data.opcode);
    LOG.outString( f );
    switch (recv_data.opcode)
    {
        case CMSG_NAME_QUERY:
        {
            uint32 guid;
            memcpy(&guid, recv_data.data, 4);

            uint32 race = 0, gender = 0, cl = 0;
            char name[32];

            std::map<uint32, Character*>::iterator itr = WORLDSERVER.mCharacters.find(guid);
            if (itr == WORLDSERVER.mCharacters.end()) {

                DatabaseInterface *dbi = DATABASE.createDatabaseInterface( );

                if (!dbi->GetPlayerNameFromGUID(1, (uint8*)name))
                    LOG.outString( "No player name found for this guid" );

                DATABASE.removeDatabaseInterface( dbi );
            } else {
                Character *pChar = WORLDSERVER.mCharacters[guid];         
                race = pChar->getRace();
                gender = pChar->getGender();
                cl = pChar->getClass();
                strcpy(name, pChar->getName());
            }

            data.Clear();
            data.length = 8 + strlen(name)+ 1 + 4*sizeof(uint32);
            data.data = new uint8[ data.length ];
            data.opcode = SMSG_NAME_QUERY_RESPONSE;

            LOG.outString( name );

            data << guid << uint32(0);
            data << (std::string)name << uint32(0);
            data << race << gender << cl;
			// FIXME, something wrong here, crashes client.
            pClient->SendMsg( &data );
        } break;

        case CMSG_QUERY_TIME:
        {
            data.Clear();
            data.Initialize(4, SMSG_QUERY_TIME_RESPONSE);

            data << (int32)time(NULL);
            pClient->SendMsg(&data);
        }break;	

        case CMSG_CREATURE_QUERY:
        {
            uint32 entry=0;
            uint32 guid=0;

            recv_data.ReadData(entry);
            recv_data.ReadData(guid);

            uint8 *name = 0;

            /*std::map<uint32, uint8*>::iterator itr = WORLDSERVER.mCreatureNames.find(entry);
            if (itr == WORLDSERVER.mCreatureNames.end()){
                WPAssert(!"invalid creature entry");
            }*/

            name = WORLDSERVER.mCreatureNames[entry];
            if (!name)
				name = (uint8 *)"ERROR_NO_CREATURENAME_FOR_ENTRY";
            //    return;
            printf(" WORLD: CMSG_CREATURE_QUERY '%s'\n", name );
            
            uint16 namesize = strlen((char*)name)+1;

            data.Clear();
            data.Initialize(4+namesize+16, SMSG_CREATURE_QUERY_RESPONSE);
            data << (uint32)entry;
            strcpy((char*)data.data+4, (char*)name);

            uint8 somedata[] = 
            { 
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00
            };

            memcpy(data.data+namesize+4, somedata, 16);
            pClient->SendMsg(&data);
        }break;
        
        case CMSG_GAMEOBJECT_QUERY:
		{
			data.Initialize( 64, SMSG_GAMEOBJECT_QUERY_RESPONSE );
            //TODO: Check the database for the ENTRY (First long) and obtain all the details from there...
            data << uint32( 0x00000787 ) << uint32( 0x00000013 ) << uint32( 0x0000088e );                    
            data << uint32( 0x6c69614d ) << uint32( 0x00786f62 );
            data << uint32( 0x00000000 ) << uint32( 0x00000000 ) << uint32( 0x00000000 );
            data << uint32( 0x00000000 );
            data << uint32( 0 ) << uint32( 0 ) << uint32( 0 ) << uint32( 0 ) << uint32( 0 ) << uint32( 0 );
            data << uint16( 0 ) << uint8( 0 );

            /*
            00 00 07 87 00 00 00 08 00 00 00 C0 54 F9 EC 01 
            04 00 00 00 0A 00 00 00 12 00 00 00 00 00 00 08 
            00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
            00 00 00 00 00 00 00 00 00 00 00 4F 52 44 45 52 
            */

            /* Mailbox
            22 33 02 00 // ENTRY
            13 00 00 00 // Unknown
            8e 08 00 00 // Display_id
            4d 61 69 6c | 62 6f 78 00 // Mailbox (Null terminated)
            00 00 00 00 // 1
            00 00 00 00 // 2
            00 00 00 00 // 3
            00 00 00 00 // 4
            00 00 00 00 // 5
            00 00 00 00 // 6
            00 00 00 00 // 7
            00 00 00 00 // 8
            00 00 00 00 // 9
            00 00 00 00 // 10
            00 00 00    // 11
            */

            pClient->SendMsg( &data );  
            LOG.outString( "WORLD: Sent Object Query Response." );
		}break;
    }
}
