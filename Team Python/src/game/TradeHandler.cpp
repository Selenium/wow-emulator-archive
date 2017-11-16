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

#include "NetworkInterface.h"
#include "Opcodes.h"
#include "Log.h"
#include "Character.h"
#include "WorldServer.h"
#include "Database.h"
#include "UpdateMask.h"
#include "DatabaseInterface.h"
#include "Sockets.h"

#define world WorldServer::getSingleton()

TradeHandler::TradeHandler()
{
}
TradeHandler::~TradeHandler()
{
}
void TradeHandler::HandleMsg( wowWData & recv_data, GameClient *pClient )
{
	wowWData data;
    char f[256];
    sprintf(f, "WORLD: Trade Opcode: 0x%.4X", recv_data.opcode);
    Log::getSingleton( ).outString( f );
	switch (recv_data.opcode)
	{
		case CMSG_INITIATE_TRADE: // Initiate trade
		{
			unsigned long targetguid;
			unsigned long templong;

			recv_data >> targetguid;
			recv_data >> templong;
				
			WorldServer::ClientSet::iterator itr;
				for (itr = world.mClients.begin(); itr != world.mClients.end(); itr++)
				{
					if ((((GameClient*)(*itr))->getCurrentChar()->getGUID() == targetguid) && (((GameClient*)(*itr))->IsInWorld()))
					{
						data.Initialise( 8, SMSG_TRADE_STATUS );
						data << (long) 0x02;
						
						((GameClient*)(*itr))->SendMsg(&data); // sends selection
						pClient->SendMsg(&data); // sends to the player
					
						Log::getSingleton( ).outString( "WORLD: Player %s is trading", pClient->getCurrentChar()->getName());
						data.clear();
					}
					else
					{		
						data.Initialise( 12, SMSG_TRADE_STATUS );
						data << (long) 0x01;
						data << (long) pClient->getCurrentChar()->getGUIDHigh();
						
						((GameClient*)(*itr))->SendMsg(&data);
						pClient->SendMsg(&data);

						Log::getSingleton( ).outString( "WORLD: Player %s is requesting to trade", pClient->getCurrentChar()->getName());
						data.clear();
					}
				}
			}break;

	case CMSG_ACCEPT_TRADE: // Accept trade
			{
				/*
				CMSG_ACCEPT_TRADE 
			    dword // unknown (0x01) 
				*/

				data.Initialise( 8, SMSG_TRADE_STATUS );
 		   		//data << uint8( 0x01 );	
				pClient->SendMsg( &data );
				data.clear();
				
				Log::getSingleton( ).outString( "WORLD: Accepting Trade Request ...\n" );
			}break;

		case CMSG_SET_TRADE_GOLD: // Set Cost of Trade
			{
				/*
				CMSG_SET_TRADE_GOLD 
			    dword     // coinage 
				*/

				uint32 player_gold;
				player_gold = pClient->getCurrentChar( )->getUpdateValue( PLAYER_FIELD_COINAGE );

				data.Initialise( 8, SMSG_TRADE_STATUS );
 		   	   
				data << uint32 ( player_gold );
 		   	
				pClient->SendMsg( &data );
				data.clear();
				Log::getSingleton( ).outString( "WORLD: Setting Cost of Trade ...\n" );
			}break;

		case CMSG_CANCEL_TRADE: // Cancle trade
			{
				/*
				CMSG_CANCEL_TRADE 
				*/
				data.Initialise( 8, SMSG_TRADE_STATUS );
 		   		pClient->SendMsg( &data );
				data.clear();
				
				Log::getSingleton( ).outString( "WORLD: Canceling Trade ...\n" );
			}break;

		case CMSG_SET_TRADE_ITEM: // Set Trade Item
			{
				/*
				CMSG_SET_TRADE_ITEM 
				byte // trade window slot (0x00 - 0x05) 
				byte // source bag or 0xFF for backpack 
				byte // source slot (inventory slot, backpack, worn, etc...) 
				
				Something down the lines of this shit! i would imagine ...

				unsigned char tradeslot;
				unsigned char sourcebag;
				unsigned char invslot;
				
				data >> tradeslot;
				data >> sourcebag;
				data >> invslot;

				data.Initialise( 32, SMSG_TRADE_STATUS_EXTENDED );
				
				data << (char) 0x00;
				data << (long) 0x02;
				data << (long) 0x00;
				data << (long) 0x00;
				data << (long) 0x00;
				data << (char) 0x03;
				data << (long) 0x1131;  // might be id of item
				data << (long) 0x4098;  // might be id of item
				data << (long) 0x01;
				data << (long) 0x00;
				data << (long) 0x00;
				data << (long) 0x00;
				data << (long) 0x00;
				data << (long) pClient->getCurrentChar()->getGUID();  // guid of player (me)?
				data << (long) 0x00;
				data << (long) 0x00;
				data << (char) 0x60;
				data << (char) 0x74;
				data << (char) 0x35;
				data << (char) 0x1B;
				data << (long) 0x00;
				
				pClient->SendMsg( &data );
				*/
				Log::getSingleton( ).outString( "WORLD: Set Trade Item ...\n" );
			}break;
		
		case CMSG_CLEAR_TRADE_ITEM: // Clear Trade Item
			{	
				/*
				CMSG_CLEAR_TRADE_ITEM 
			    byte // trade window slot (0x00 - 0x05) 
				*/
				data.Initialise( 12, SMSG_TRADE_STATUS );

				data << uint32( 0x00 );

				pClient->SendMsg( &data );
				data.clear();
				
				Log::getSingleton( ).outString( "WORLD: Clearing Trade Item ...\n" );
			}break;

		case CMSG_UNACCEPT_TRADE: // unaccept trade
			{
				/*
				no notes on this case .. 
				*/
				data.Initialise( 8, SMSG_TRADE_STATUS );
				// unknown data strings!

				pClient->SendMsg( &data );
				data.clear();

				Log::getSingleton( ).outString( "WORLD: Stopping Trade ...\n" );
			}break;
		case CMSG_BEGIN_TRADE: // begin the trade
			{
				/*
				no notes on this case .. 
				*/
				uint32 guid;
   		   		recv_data >> guid;
  		   		
				WorldServer::ClientSet::iterator itr;
				for (itr = world.mClients.begin(); itr != world.mClients.end(); itr++)
				{
					if ((((GameClient*)(*itr))->getCurrentChar()->getGUID() == guid) && (((GameClient*)(*itr))->IsInWorld()))
					{
						//GAME SERVER:                                          @ 14.7328851222992 s
						//Length = 12
						//Opcode = SMSG_TRADE_STATUS[011e]
						//Data = 
						//01 00 00 00 07 0b 08 00 00 00 00 00                 ............

						data.Initialise( 8, SMSG_TRADE_STATUS );
						data << uint8(0x01);
						data << uint8(0x00);
						data << uint8(0x00);
						data << uint8(0x00);
						data << uint32(guid);
 		   		
						((GameClient*)(*itr))->SendMsg(&data); //send initiate to the other play
						//then its suposed to send to both player status 2
						data.clear();
						Log::getSingleton( ).outString( "WORLD: Begin Trade ...\n" );
					}
				}
			}break;
	}
}
