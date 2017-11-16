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

#include "SpellHandler.h"
#include "NetworkInterface.h"
#include "Opcodes.h"
#include "Log.h"
#include "Character.h"
#include "WorldServer.h"
#include "Database.h"
#include "UpdateMask.h"
#include "Character.h"
//#include "math.h"
#include "DatabaseInterface.h"
#include "Sockets.h"

#define world WorldServer::getSingleton()

NPCHandler::NPCHandler()
{

}

NPCHandler::~NPCHandler()
{

}

void NPCHandler::HandleMsg( wowWData & recv_data, GameClient *pClient )
{
	wowWData data;
    char f[256];
    sprintf(f, "WORLD: NPC Opcode: 0x%.4X", recv_data.opcode);
    Log::getSingleton( ).outString( f );
	switch (recv_data.opcode)
	{   
        case MSG_TABARDVENDOR_ACTIVATE:
            {
                uint32 guid, guid2;
				recv_data >> guid >> guid2;                
                data.Initialise( 8, MSG_TABARDVENDOR_ACTIVATE );
				data << guid << guid2;
				pClient->SendMsg( &data );             
            }break;

        case CMSG_BANKER_ACTIVATE:
            {  
				uint32 bguid, bguid2;
				recv_data >> bguid >> bguid2;

				data.Initialise( 8, SMSG_SHOW_BANK );
				data << bguid << bguid2;
				pClient->SendMsg( &data );
            }break;

			/*case CMSG_TRAINER_LIST: //needs to be changed to the vendor-list
			{ 
                uint32 player_level, player_gold;
                player_level = pClient->getCurrentChar( )->getUpdateValue( UNIT_FIELD_LEVEL );
                player_gold = pClient->getCurrentChar( )->getUpdateValue( PLAYER_FIELD_COINAGE );
                uint32 guid1, guid2;
                uint32 count;
                //count = 2; //we can have more then 2 spells now ;)
				recv_data >> guid1 >> guid2;

				DatabaseInterface *dbi = Database::getSingleton().createDatabaseInterface(); //
				count = (uint32)dbi->getTrainerSpellsCount ( pClient );
                data.Initialise( (38*count)+48, SMSG_TRAINER_LIST ); //set packet size - count = number of spells
				data << guid1 << guid2;
                data << uint32(0) << count;

				dbi->getTrainerSpells( pClient, data);
				Database::getSingleton().removeDatabaseInterface( dbi );

				pClient->SendMsg( &data );
			}break;*/

        case CMSG_TRAINER_LIST:
			{ 
                uint32 player_level, player_gold;
                player_level = pClient->getCurrentChar( )->getUpdateValue( UNIT_FIELD_LEVEL );
                player_gold = pClient->getCurrentChar( )->getUpdateValue( PLAYER_FIELD_COINAGE );
                uint32 guid1, guid2;
                uint32 count;
                //count = 2; //we can have more then 2 spells now ;)
				recv_data >> guid1 >> guid2;

				DatabaseInterface *dbi = Database::getSingleton().createDatabaseInterface(); //
				const uint32 *trainer = pClient->getCurrentChar()->getSelectionPtr();
				count = dbi->getTrainerSpellsCount ( trainer );
                data.Initialise( (38*count)+48, SMSG_TRAINER_LIST ); //set packet size - count = number of spells
				data << guid1 << guid2;
                data << uint32(0) << count;

				dbi->getTrainerSpells( pClient->getCurrentChar(), pClient->getCurrentChar()->getSelectionPtr(), data);
				Database::getSingleton().removeDatabaseInterface( dbi );

				/*
					sql: select * from trainers t INNER JOIN spells s ON t.spellGuid = s.ID where t.trainerGuid = <trainerGuid>;
					^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
					spell id:		2 (base-1 array) / 1 (base-0 array)
					level req.:		28 (base-1 array) / 27 (base-0 array)
					price:			3 (base-1 array) / 2 (base-0 array)
				*/

                /*data << uint32(2120); //Spell_id
                //Check for stuff here....
                if(player_level>=3 ) {
                    if(player_gold>=200) {
                        data << uint8(0); //available (non zero = no)
                    }
                    else {
                        data << uint8(1);
                    }
                }
                else {
                    data << uint8(1);
                }
                data << uint32(200); // Cost (2 silver)
                data << uint32(0) << uint32(0); // ?, ?
                data << uint32(3); //Required level
                data << uint32(0) << uint32(0) << uint32(0) << uint32(0) << uint8(0); //?????

                data << uint32(0x6c6c6548) << uint32(0x5220216f) << uint32(0x79646165);
                data << uint32(0x726f6620) << uint32(0x6d6f7320) << uint32(0x72742065);
                data << uint32(0x696e6961) << uint32(0x003f676e);*/
				pClient->SendMsg( &data );
//H  e  l  l  o  !     R  e  a  d  y     f  o  r     s  o  m  e     t  r  a  i  n  i  n  g  ?  
//48 65 6c 6c 6f 21 20 52 65 61 64 79 20 66 6f 72 20 73 6f 6d 65 20 74 72 61 69 6e 69 6e 67 3f 00
			}break;

        case CMSG_TRAINER_BUY_SPELL:
			{				
                uint32 guid1, guid2, spell_id, player_gold;
				int price;
				const uint32 * guid = pClient->getCurrentChar()->getSelectionPtr(); //guid for trainer
                recv_data >> guid1 >> guid2 >> spell_id;  
                player_gold = pClient->getCurrentChar( )->getUpdateValue( PLAYER_FIELD_COINAGE );

                data.clear();
                data.Initialise( 12, SMSG_TRAINER_BUY_SUCCEEDED );
				data << guid1 << guid2 << spell_id;
				pClient->SendMsg( &data );

				if( pClient->getCurrentChar( )->isAllreadyLearned(spell_id) ) break;

				DatabaseInterface *dbi = Database::getSingleton().createDatabaseInterface();
				price = dbi->getTrainerSpellsPrice ( spell_id, guid[0] );
				Database::getSingleton().removeDatabaseInterface( dbi );

				if(player_gold >= (uint32)price) 
				{

					pClient->getCurrentChar( )->setUpdateValue( PLAYER_FIELD_COINAGE, player_gold-price );

					data.clear();
					data.Initialise( 36, SMSG_SPELL_START );
					data << guid1 << guid2;
					data << guid1 << guid2;
					data << spell_id;
					data << uint16(0) << uint32(0);
					data << uint16(2);
					data << pClient->getCurrentChar()->getGUID() << uint32(0);
					pClient->SendMsg( &data );

					data.clear();
					data.Initialise( 4, SMSG_LEARNED_SPELL );
					data << spell_id;
					pClient->SendMsg( &data );
					pClient->getCurrentChar()->addSpell(spell_id);

					data.clear();
					data.Initialise( 42, SMSG_SPELL_GO );
					data << guid1 << guid2;
					data << guid1 << guid2;
					data << spell_id;
					data << uint8(0) << uint8(1) << uint8(1);
					data << pClient->getCurrentChar()->getGUID() << uint32(0);
					data << uint8(0) << uint16(2);
					data << pClient->getCurrentChar()->getGUID() << uint32(0);
					pClient->SendMsg( &data );

					data.clear();
					data.Initialise( 32, SMSG_SPELLLOGEXECUTE );
					data << guid1 << guid2;
					data << spell_id;
					data << uint32(1);
					data << uint32(0x24);
					data << uint32(1);
					data << pClient->getCurrentChar()->getGUID() << uint32(0);
					pClient->SendMsg( &data );
				}
			}break;

            case CMSG_PETITION_SHOWLIST:
			{				
                uint32 guid1, guid2;
                unsigned char tdata[21] =
                {
                   0x01, 0x01, 0x00, 0x00, 0x00, 0xe7, 0x16, 0x00, 0x00, 0xef, 0x23, 0x00, 0x00, 0xe8, 0x03, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00
                };
                recv_data >> guid1 >> guid2;
                data.clear();
				data.Initialise( 12, SMSG_PETITION_SHOWLIST );
				data << guid1 << guid2;
                data.writeData( &tdata );
				pClient->SendMsg( &data );				
			}break;

            case MSG_AUCTION_HELLO:
			{
                uint32 guid1, guid2;
                recv_data >> guid1 >> guid2;
                data.Initialise( 12, MSG_AUCTION_HELLO );
				data << guid1 << guid2;
                data << uint32(0);
				pClient->SendMsg( &data );
			}break;
			
			case CMSG_GOSSIP_HELLO:
			{
				DatabaseInterface *dbi = WorldServer::getSingleton( ).dbi;
				uint16 tSize;
				uint32 guid[2];
				tSize = 47;
				data.Initialise( tSize, SMSG_GOSSIP_MESSAGE );
				recv_data >> guid[0] >> guid[1];
				tSize = 0;

				if( pClient->getCurrentChar()->getDeathState() == CORPSE && dbi->isSpiritHealer(guid[0]) )
				{
					data << guid[0] << guid[1];
					//data << (uint32)0x01000244; //uk1 possibly deathID
					data << dbi->getNextTextID( 1 , pClient->getCurrentChar()->getGUID() );
					data << (uint32)0x00000001; //count
					data << (uint32)0x00000000; //uk2
					data << (uint32)0x00000004; //uk3
					//NULL terminated message
					// << Bojangles | start >>
					data << (uint8)0x52; 
					data << (uint32)0x72757465; 
					data << (uint32)0x656D206e; 
					data << (uint32)0x206F7420; 
					data << (uint32)0x6566696c; 
					data << (uint8)0x2e; 
					data << (uint8)0x00; 
	            	// << Bojangles | stop >>				
					//end of message
					data << (uint32)0;
					pClient->SendMsg( &data );
				}

				//pClient->getCurrentChar()->setUpdateValue(CORPSE_FIELD_ITEM3, 6947);
				//pClient->getCurrentChar()->setUpdateValue(CORPSE_FIELD_ITEM4, (uint32)0xf0001000 );
				//pClient->getCurrentChar()->UpdateObject();
				}break;

			case CMSG_GOSSIP_SELECT_OPTION:
			{
				uint32 guid1,guid2,option;
				recv_data >> guid1 >> guid2 >> option;
				switch (option)
				{
					case 0:
					{
						data.Initialise(8,SMSG_SPIRIT_HEALER_CONFIRM);
						data << guid1 << guid2;
						pClient->SendMsg( &data );
						data.Initialise(0,SMSG_GOSSIP_COMPLETE);
						pClient->SendMsg( &data );
					}break;

					default: {}break;
				}
			}break;

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
// balko start
				pClient->getCurrentChar()->setDeathState(ALIVE);
				pClient->getCurrentChar()->setUpdateValue(UNIT_FIELD_HEALTH, (uint32)pClient->getCurrentChar()->getUpdateValue(UNIT_FIELD_MAXHEALTH)/2 );
				if (pClient->getCurrentChar()->getUpdateValue(UNIT_FIELD_MAXPOWER1) >0)
				{
					pClient->getCurrentChar()->setUpdateValue(UNIT_FIELD_POWER1, (uint32)pClient->getCurrentChar()->getUpdateValue(UNIT_FIELD_MAXPOWER1)/2 );
				}
// insert XP-loss from Lina Death-fix - balko

				uint8 buf[256];

				uint32 xp = pClient->getCurrentChar( )->getUpdateValue(PLAYER_XP);
				uint32 xpt = (uint32)( 20 * (pClient->getCurrentChar( )->getLevel()/1.2));
			
				int32 newxp = xp - xpt;
				if(newxp < 0) 
				{
					newxp = 0;
					sprintf((char*)buf,"You lost %u XP, be more carefull nexttime.", xpt);
					pClient->getCurrentChar( )->setUpdateValue(PLAYER_XP, newxp);
				}
				else 
				{
					sprintf((char*)buf,"You lost %u XP.", xpt);
					pClient->getCurrentChar( )->setUpdateValue(PLAYER_XP, newxp);
				}
				WorldServer::getSingleton().mChatHandler.FillMessageData(&data, 0x09, pClient, buf);
				pClient->SendMsg( &data );
				printf("Take XP %i, so %i\n", xpt, newxp);				
			
			}break;
// balko end					
			case CMSG_NPC_TEXT_QUERY:
			{
				uint32 textID; 
				uint32 NPC_TEXT_TYPE;
									
				DatabaseInterface *dbi = Database::getSingleton( ).createDatabaseInterface( );
				recv_data >> textID;
				NPC_TEXT_TYPE = dbi->getNPC_TEXT_TYPE( textID );
				Database::getSingleton( ).removeDatabaseInterface( dbi );
				
				switch (NPC_TEXT_TYPE)
				{
					case 1: //DEATH
					{
						//this is having to do with spirit healers
						uint32 uField0, uField1;
						recv_data >> uField0 >> uField1;
						pClient->getCurrentChar()->setUpdateValue(UNIT_FIELD_TARGET, uField0);
						pClient->getCurrentChar()->setUpdateValue(UNIT_FIELD_TARGET + 1, uField1);

						data.Initialise(373, SMSG_NPC_TEXT_UPDATE);
						data << textID << (uint32)0x42c80000 << (uint32)0x69207449 << (uint32)0x6f6e2073;
						data << (uint32)0x65792074 << (uint32)0x6f792074 << (uint32)0x74207275 << (uint32)0x2e656d69;
						data << (uint32)0x73204920 << (uint32)0x6c6c6168 << (uint32)0x64696120 << (uint32)0x756f7920;
						data << (uint32)0x6f6a2072 << (uint32)0x656e7275 << (uint32)0x61622079 << (uint32)0x74206b63;
						data << (uint32)0x6874206f << (uint32)0x65722065 << (uint32)0x206d6c61 << (uint32)0x7420666f;
						data << (uint32)0x6c206568 << (uint32)0x6e697669 << (uint32)0x2e2e2e67 << (uint32)0x726f6620;
						data << (uint32)0x70206120 << (uint32)0x65636972 << (uint32)0x0000002e << (uint32)0x00000000;
						data << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000;
						data << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000;
						data << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000;
						data << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000;
						data << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000;
						data << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000;
						data << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000;
						data << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000;
						data << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000;
						data << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000;
						data << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000;
						data << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000;
						data << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000;
						data << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000;
						data << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000;
						data << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000 << (uint32)0x00000000;
						data << (uint32)0x00000000 << (uint8)0x00;
						pClient->SendMsg( &data );
					}break;
										
					default: {}break;
				}
			}
    default: {}break;
    }
}
