//////////////////////////////////////////////////////////////////////
//  Taxi Handler
//
//  Receives all messages with Taxi opcodes
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

#include "TaxiHandler.h"
#include "NetworkInterface.h"
#include "Log.h"
#include "Opcodes.h"
#include "GameClient.h"
#include "Character.h"
#include "UpdateMask.h"
#include "WorldServer.h"
#include "Path.h"
#include "DatabaseInterface.h"
#include "Database.h"
#include "math.h"

// npcs have a taxi element
// how about when the npc is created it uses the database to find the nearest taxi and set it
// when the npc is clicked for now we use the database to display available waypoints
// when the taxi is started, we know the starting node and the ending node.
//   we use the database or a cache to find the path, utilizing two tables.

TaxiHandler::TaxiHandler( ) {

}

TaxiHandler::~TaxiHandler( ) {

}


void TaxiHandler::HandleMsg( NetworkPacket & recv_data, GameClient *pClient ) {
    NetworkPacket data;
    char f[ 256 ];
    sprintf( f, "WORLD: Taxi Opcode 0x%.4X", recv_data.opcode );
	int CharZone;
	CharZone=pClient->getCurrentChar( )->getZone();
	printf("Zona: %i\n",CharZone);
    LOG.outString( f );
    switch( recv_data.opcode ) {
        case CMSG_TAXINODE_STATUS_QUERY:
            {
                LOG.outString( "WORLD: Recieved CMSG_TAXINODE_STATUS_QUERY" );
                uint32 guid1, guid2;
                recv_data >> guid1 >> guid2;

                data.Initialize( 9, SMSG_TAXINODE_STATUS );
                data << guid1 << guid2 << uint8( 0 );
                pClient->SendMsg( &data );
                LOG.outString( "WORLD: Sent SMSG_TAXINODE_STATUS" );
            }break;
        case CMSG_TAXIQUERYAVAILABLENODES:
            {
                LOG.outString( "WORLD: Recieved CMSG_TAXIQUERYAVAILABLENODES" );
                uint32 guid1, guid2;
                recv_data >> guid1 >> guid2;

                data.Initialize( 32, SMSG_SHOWTAXINODES );
                
                DatabaseInterface *dbi = DATABASE.createDatabaseInterface( );

                uint32 curloc = dbi->getNearestTaxiNode( 
                    pClient->getCurrentChar( )->getPositionX( ),
                    pClient->getCurrentChar( )->getPositionY( ),
                    pClient->getCurrentChar( )->getPositionZ( ), pClient->getCurrentChar( )->getMapId( ) );

                data << uint32( 1 ) << guid1 << guid2;

                // current location: 0x0c is darkshire... 0x02 is stormwind
                data << uint32( curloc );
			  
				uint32 TaxiMask = dbi->getGlobalTaxiNodeMask( curloc );                
				//uint32 TaxiMask = dbi->getGlobalTaxiNodeMask(  );
				// a uint64 representing places on the map that have prices, same format as next uint64
         		    data << ( TaxiMask | (1<<(curloc-1)) ) << uint32(0);
                // a uint64 representing the map.  Each bit is a visible location -- smallest bit is location #1, etc.
					data << ( TaxiMask | (1<<(curloc-1)) ) << uint32(0);
                DATABASE.removeDatabaseInterface( dbi );
				//data << uint32( 0 );
                pClient->SendMsg( &data );
                LOG.outString( "WORLD: Sent SMSG_SHOWTAXINODES" );
            }break;
        case CMSG_ACTIVATETAXI:
            {
				/*uint16 MountId;
				switch (CharZone) //zone 45 dont know
				{
					case 10,40,33,44,51,38,45,267: //gryphon
					{
						MountId=0;
					}break;
					case 85,130,36: //bat
					{
					}break;
					case 3: //lionfly and 33
					else
					{
						MountId=0;
					}
				}*/
                LOG.outString( "WORLD: Recieved CMSG_ACTIVATETAXI" );
                uint32 guid1, guid2, sourcenode, destinationnode;
                recv_data >> guid1 >> guid2 >> sourcenode >> destinationnode;

                // can't taxi if frozen for now, fixes bug when you double-click a node
                if( pClient->getCurrentChar( )->getUpdateValue( UNIT_FIELD_FLAGS ) & 0x4 )
                    break;

                DatabaseInterface *dbi = DATABASE.createDatabaseInterface( );
                uint32 path = dbi->getPath( sourcenode, destinationnode );
				
                Path pathnodes;
                dbi->getPathNodes( path, &pathnodes );

                DATABASE.removeDatabaseInterface( dbi );

                data.Initialize( 4, SMSG_ACTIVATETAXIREPLY );
                data << uint32( 0 );
                pClient->SendMsg( &data );
                LOG.outString( "WORLD: Sent SMSG_ACTIVATETAXIREPLY" );

                // first create the mount
                pClient->getCurrentChar( )->addUnitFlag( 0x001000 );
                pClient->getCurrentChar( )->addUnitFlag( 0x000004 );
                pClient->getCurrentChar( )->setUpdateValue( UNIT_FIELD_MOUNTDISPLAYID, 0x3a7 );
                pClient->getCurrentChar( )->UpdateObject( );

                // now mount it.  this must be done separately for it to animate while moving for some reason.
                pClient->getCurrentChar( )->addUnitFlag( 0x002000 );
//                pClient->getCurrentChar( )->UpdateObject( );

                // 0x001000 seems to make a mount visible
                // 0x002000 seems to make you sit on the mount, and the mount move with you
                // 0x100000 ?? 
                // 0x000004 locks you so you can't move, no msg_move updates are sent to the server
                // 0x000008 seems to enable detailed collision checking

                data.Initialize( /*229*/37 + pathnodes.getLength( ) * 4 * 3, SMSG_MONSTER_MOVE );
                data << pClient->getCurrentChar( )->getGUID( ) << uint32( 0 );
                //data << (float)-10514.92 << (float)-1260.089 << (float)41.38442; // starting location;
                data << pClient->getCurrentChar( )->getPositionX( )
                    << pClient->getCurrentChar( )->getPositionY( )
                    << pClient->getCurrentChar( )->getPositionZ( );
                data << pClient->getCurrentChar( )->getOrientation( );

                data << uint8( 0 ); // dunno
                data << uint32( 0x00000300 ); // flags?

                uint32 traveltime = uint32(pathnodes.getTotalLength( ) * 32); // 36.7407
                data << uint32( traveltime ); // total travel time

                data << uint32( pathnodes.getLength( ) ); // number of spline points

                pClient->getCurrentChar( )->setPosition( pathnodes.getNodes( )[ pathnodes.getLength( ) - 1 ].x, pathnodes.getNodes( )[ pathnodes.getLength( ) - 1 ].y, pathnodes.getNodes( )[ pathnodes.getLength( ) - 1 ].z, true );
                data.WriteData( pathnodes.getNodes( ), pathnodes.getLength( ) * 4 * 3 );

                pClient->getCurrentChar()->SendMessageToSet(&data, true);
//                WORLDSERVER.SendZoneMessage(&data, pClient, 1);				
				}break;
    }
}
