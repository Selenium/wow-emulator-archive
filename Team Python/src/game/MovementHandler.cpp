// Copyright (C) 2004 Team Python
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

#include "MovementHandler.h"
#include "NetworkInterface.h"
#include "Opcodes.h"
#include "Log.h"
#include "Character.h"
#include "WorldServer.h"
#include "UpdateMask.h"
#include <time.h>
#include "math.h"

#define world WorldServer::getSingleton()

MovementHandler::MovementHandler()
{

}

MovementHandler::~MovementHandler()
{

}

void MovementHandler::HandleMsg( wowWData & recv_data, GameClient *pClient )
{
    wowWData data;
    bool updateself = false;

    // Was getting crashes receiving heartbeats from players that had logged out
    // So dont go any further if they have no current character
    if (!pClient->IsInWorld())  return;

    //printf("WORLD: Movement Opcode 0x%.4X\n", recv_data.opcode );
    switch (recv_data.opcode)
    {
    case MSG_MOVE_HEARTBEAT:
        {
            data.clear();
            data.Initialise( recv_data.length+8, MSG_MOVE_HEARTBEAT);

            if( pClient->getCurrentChar() && !pClient->getCurrentChar( )->setPosition( recv_data.data+8 ) ) {
                wowWData movedata;
                pClient->getCurrentChar( )->TeleportAck( &movedata, pClient->getCurrentChar( )->getPositionX( ), pClient->getCurrentChar( )->getPositionY( ), pClient->getCurrentChar( )->getPositionZ( ) );
                pClient->getNetwork( )->sendWData(&movedata);
            }

            // GUID of player who sent heartbeat
            uint32 guid = pClient->getCurrentChar()->getGUID();
            memcpy(data.data, &guid, 4);
            data.data[4] = 0x00;
            data.data[5] = 0x00;
            data.data[6] = 0x00;
            data.data[7] = 0x00;

            memcpy(data.data+8, recv_data.data, recv_data.length);
            //memcpy(data.data+8, recv_data.data+8, recv_data.length-8);
//            world.SendAreaMessage(&data, pClient, 0);
            pClient->getCurrentChar()->SendMessageToSet(&data, false);
        }break;

    case MSG_MOVE_JUMP: case MSG_MOVE_START_FORWARD : case MSG_MOVE_START_BACKWARD: case MSG_MOVE_SET_FACING:
    case MSG_MOVE_STOP: case MSG_MOVE_START_STRAFE_LEFT: case MSG_MOVE_START_STRAFE_RIGHT: case MSG_MOVE_STOP_STRAFE:
    case MSG_MOVE_START_TURN_LEFT: case MSG_MOVE_START_TURN_RIGHT:  case MSG_MOVE_STOP_TURN: case MSG_MOVE_START_PITCH_UP :
    case MSG_MOVE_START_PITCH_DOWN: case MSG_MOVE_STOP_PITCH : case MSG_MOVE_SET_RUN_MODE: case MSG_MOVE_SET_WALK_MODE:
    case MSG_MOVE_SET_PITCH: case MSG_MOVE_START_SWIM:
    case MSG_MOVE_STOP_SWIM:
        {
            if( !pClient->getCurrentChar( )->setPosition( recv_data.data+8 ) ) {
                wowWData movedata;
                pClient->getCurrentChar( )->TeleportAck( &movedata, pClient->getCurrentChar( )->getPositionX( ), pClient->getCurrentChar( )->getPositionY( ), pClient->getCurrentChar( )->getPositionZ( ) );
                pClient->getNetwork( )->sendWData(&movedata);
                pClient->getCurrentChar( )->getPosition( recv_data.data+8 );
            }

            // GUID of player who sent the message
            uint32 guid = pClient->getCurrentChar()->getGUID();

            data.clear();
            data.Initialise( 8+recv_data.length, recv_data.opcode);
            //data.Initialise( recv_data.length, recv_data.opcode);

            memcpy(data.data, &guid, 4);
            data.data[4] = 0x00;
            data.data[5] = 0x00;
            data.data[6] = 0x00;
            data.data[7] = 0x00;

            memcpy(data.data+8, recv_data.data, recv_data.length);
            //memcpy(data.data+8, recv_data.data+8, recv_data.length-8);
//            world.SendAreaMessage(&data, pClient, 0);
            pClient->getCurrentChar()->SendMessageToSet(&data, false);

        }break;
    case MSG_MOVE_WORLDPORT_ACK:
        {
            Log::getSingleton( ).outString( "WORLD: got MSG_MOVE_WORLDPORT_ACK." );

            // Create myself for other clients
            pClient->getCurrentChar()->SetPosToNewPos();

            // Create Player Character
            WorldServer::getSingleton().mObjectMgr.BuildAndSendCreatePlayer( pClient->getCurrentChar(), 1, NULL );

            // Build the in-range set
            WorldServer::getSingleton().CheckForInRangeObjects( pClient->getCurrentChar() );

            // Send a message to other Clients that a new player has entered the world
            std::list<wowWData*> msglist;
            WorldServer::getSingleton().mObjectMgr.BuildCreatePlayerMsg( pClient->getCurrentChar(), &msglist, 0 );

            std::list<wowWData*>::iterator msgitr;
            for (msgitr = msglist.begin(); msgitr != msglist.end(); )
            {
                wowWData *msg = (*msgitr);
                pClient->getCurrentChar()->SendMessageToSet(msg, false);
                delete msg;
                msgitr = msglist.erase(msgitr);
            }
        };

    default: {}break;
    }

}
