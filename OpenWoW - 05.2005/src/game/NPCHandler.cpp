//////////////////////////////////////////////////////////////////////
//  NPC Handler
//
//  Receives all messages with NPC management opcodes
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

#include "SpellHandler.h"
#include "NetworkInterface.h"
#include "Opcodes.h"
#include "Log.h"
#include "Character.h"
#include "WorldServer.h"
#include "Database.h"
#include "UpdateMask.h"
#include "Character.h"

#include "DatabaseInterface.h"
#include "Sockets.h"

NPCHandler::NPCHandler()
{

}

NPCHandler::~NPCHandler()
{

}

void NPCHandler::HandleMsg( NetworkPacket & recv_data, GameClient *pClient )
{
	NetworkPacket data;
	char f[256];
	sprintf(f, "WORLD: NPC Opcode: 0x%.4X", recv_data.opcode);
	LOG.outString( f );
	switch (recv_data.opcode)
	{
	case MSG_TABARDVENDOR_ACTIVATE:
		{
			uint32 guid, guid2;
			recv_data >> guid >> guid2;
			data.Initialize( 8, MSG_TABARDVENDOR_ACTIVATE );
			data << guid << guid2;
			pClient->SendMsg( &data );
			break;
		}

	case CMSG_BANKER_ACTIVATE:
		{
			uint32 bguid, bguid2;
			recv_data >> bguid >> bguid2;

			data.Initialize( 8, SMSG_SHOW_BANK );
			data << bguid << bguid2;
			pClient->SendMsg( &data );
			break;
		}

	case CMSG_TRAINER_LIST:
		{
			//Every things now done in getTrainerSpells() saves calling slow mysql all the time
			DatabaseInterface *dbi = Database::getSingleton().createDatabaseInterface();
			dbi->getTrainerSpells( pClient->getCurrentChar(), pClient->getCurrentChar()->getSelection(), data);
			Database::getSingleton().removeDatabaseInterface( dbi );
			
			//Send the data Packet generated in getTrainerSpells()
			pClient->SendMsg( &data );
			break;
		}

	case CMSG_TRAINER_BUY_SPELL:
		{
			uint32 guid1, guid2, spell_id, player_gold;
			int price;
			guid tguid = pClient->getCurrentChar()->getSelection(); //guid for trainer
			recv_data >> guid1 >> guid2 >> spell_id;
			player_gold = pClient->getCurrentChar ()->getUpdateValue (PLAYER_FIELD_COINAGE);

			if (pClient->getCurrentChar ()->isAllreadyLearned (spell_id)) //shouldn't get here handled client side
				break;

			/*
			DatabaseInterface *dbi = DATABASE.createDatabaseInterface ();
			price = dbi->getTrainerSpellsPrice (spell_id, tguid);
			DATABASE.removeDatabaseInterface (dbi);
			*/
			price = 0;

			if (player_gold >= (uint32)price)
			{
				pClient->getCurrentChar ()->setUpdateValue (PLAYER_FIELD_COINAGE, player_gold - price);

/*
S/O: 36/SMSG_SPELL_START
AB 25 00 00 00 10 00 F0 AB 25 00 00 00 10 00 F0  .%.......%......
C0 05 00 00 00 00 00 00 00 00 02 00 39 2E 8C 00  ............9...
00 00 00 00                                      ....

S/O: 4/SMSG_LEARNED_SPELL
B3 05 00 00                                      ....

S/O: 42/SMSG_SPELL_GO
AB 25 00 00 00 10 00 F0 AB 25 00 00 00 10 00 F0  .%.......%......
C0 05 00 00 00 01 01 39 2E 8C 00 00 00 00 00 00  .......9........
02 00 39 2E 8C 00 00 00 00 00                    ..9.......

S/O: 12/SMSG_TRAINER_BUY_SUCCEEDED
AB 25 00 00 00 10 00 F0 C0 05 00 00              .%..........
*/
				// Spell Effects are a bit buggy some one need to take a look at the db as packet structure is fine
				/* from 1.2.4 US Blizzard Server
				S/O: 36/SMSG_SPELL_START
				AB 25 00 00 00 10 00 F0 AB 25 00 00 00 10 00 F0  .%.......%......
				C0 05 00 00 00 00 00 00 00 00 02 00 D3 08 8B 00  ................
				00 00 00 00                                      ....
				*/
				/*
				//Start Spell Effect
				data.Clear ();
				data.Initialize( 36, SMSG_SPELL_START );
				data << tguid.sno << tguid.type;
				data << tguid.sno << tguid.type;
				data << spell_id;
				data << uint16(0) << uint32(0);
				data << uint8(2);
				data << uint8(0);
				data << pClient->getCurrentChar()->getGUID().sno << pClient->getCurrentChar()->getGUID().type;
				pClient->SendMsg( &data );
				*/
				/*
				S/O: 42/SMSG_SPELL_GO
				AB 25 00 00 00 10 00 F0 AB 25 00 00 00 10 00 F0  .%.......%......
				C0 05 00 00 00 01 01 D3 08 8B 00 00 00 00 00 00  ................
				02 00 D3 08 8B 00 00 00 00 00                    ..........
				*/
				/*
				//Do Spell affect
				data.Clear();
				data.Initialize( 42, SMSG_SPELL_GO );
				data << tguid.sno << tguid.type;
				data << tguid.sno << tguid.type;
				data << spell_id;
				data << uint8(0) << uint8(1) << uint8(1);
				data << pClient->getCurrentChar()->getGUID().sno << pClient->getCurrentChar()->getGUID().type;
				data << uint8(0) << uint8(2) << uint8(0);
				data << pClient->getCurrentChar()->getGUID().sno << pClient->getCurrentChar()->getGUID().type;
				pClient->SendMsg( &data );
				*/

				/*
				data.Clear();
				data.Initialize( 36, SMSG_SPELLLOGEXECUTE );
				data << tguid.sno << tguid.type;
				data << spell_id;
				data << uint32(1);
				data << uint32(0x24);
				data << uint32(1);
				data << pClient->getCurrentChar()->getGUID().sno << pClient->getCurrentChar()->getGUID().type;
				pClient->SendMsg( &data );
				*/

				//send Client the Spell Learned MSG
				data.Clear();
				data.Initialize( 4, SMSG_LEARNED_SPELL );
				data << spell_id;
				pClient->SendMsg( &data );
				pClient->getCurrentChar()->addSpell(spell_id);
				
				
				//Spell Buy Succeeded
				data.Clear();
				data.Initialize (12, SMSG_TRAINER_BUY_SUCCEEDED);
				data << tguid.sno << tguid.type << spell_id;
				pClient->SendMsg (&data);
				
				/*
				//Not sure if it's done this way oh well
				data.Clear();
				//Get Trainers List again and send it to the client
				DatabaseInterface *dbi = Database::getSingleton().createDatabaseInterface();
				dbi->getTrainerSpells( pClient->getCurrentChar(), pClient->getCurrentChar()->getSelection(), data);
				Database::getSingleton().removeDatabaseInterface( dbi );
			
				//Send the data Packet generated in getTrainerSpells()
				pClient->SendMsg( &data );
				*/
			}
			else
			{
				
				//Failed to Buy Spell - doesn't do much maybe wrong structure ?
				data.Clear();
				data.Initialize (12, SMSG_TRAINER_BUY_FAILED);
				data << tguid.sno << tguid.type << spell_id;
				pClient->SendMsg (&data);
				
			}

			break;
		}

	case CMSG_PETITION_SHOWLIST:
		{
			uint32 guid1, guid2;
			unsigned char tdata[21] =
			{
				0x01, 0x01, 0x00, 0x00, 0x00, 0xe7, 0x16, 0x00, 0x00, 0xef, 0x23, 0x00, 0x00, 0xe8, 0x03, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00
			};
			recv_data >> guid1 >> guid2;
			data.Clear();
			data.Initialize( 12, SMSG_PETITION_SHOWLIST );
			data << guid1 << guid2;
			data.WriteData( &tdata );
			pClient->SendMsg( &data );
			break;
		}

	case MSG_AUCTION_HELLO:
		{
			uint32 guid1, guid2;
			recv_data >> guid1 >> guid2;
			data.Initialize( 12, MSG_AUCTION_HELLO );
			data << guid1 << guid2;
			data << uint32(0);
			pClient->SendMsg( &data );
			break;
		}

	case CMSG_SPIRIT_HEALER_ACTIVATE:
		{
			//maybe tale some xp away?
			//pClient->getCurrentChar( )->setUpdateValue( UNIT_FIELD_FLAGS, 8 );
			pClient->getCurrentChar( )->setUpdateValue( UNIT_FIELD_FLAGS, (0xffffffff - 65536) & pClient->getCurrentChar( )->getUpdateValue( UNIT_FIELD_FLAGS ) );
			pClient->getCurrentChar( )->setUpdateValue( UNIT_FIELD_AURA +32, 0 );
			pClient->getCurrentChar( )->setUpdateValue( UNIT_FIELD_AURAFLAGS +4, 0 );
			pClient->getCurrentChar( )->setUpdateValue( UNIT_FIELD_AURASTATE, 0 );
			//pClient->getCurrentChar( )->setUpdateValue( PLAYER_BYTES_2, 16777984 );
			pClient->getCurrentChar( )->setUpdateValue( PLAYER_BYTES_2, (0xffffffff - 0x10) & pClient->getCurrentChar( )->getUpdateValue( PLAYER_BYTES_2 ) );
			pClient->getCurrentChar( )->UpdateObject( );
			pClient->getCurrentChar()->setDeathState(ALIVE);
		}break;

	default:
		break;
	}
}
