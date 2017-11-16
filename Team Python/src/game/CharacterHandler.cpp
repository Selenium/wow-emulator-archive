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

#include "CharacterHandler.h"
#include "NetworkInterface.h"
#include "Opcodes.h"
#include "Log.h"
#include "Character.h"
#include "WorldServer.h"
#include "Database.h"
#include "UpdateMask.h"

typedef std::list<Character*> CharacterList;
#define world WorldServer::getSingleton()

CharacterHandler::CharacterHandler()
{

}

CharacterHandler::~CharacterHandler()
{

}

void CharacterHandler::HandleMsg( wowWData & recv_data, GameClient *pClient )
{
	wowWData data;
    char f[256];
    sprintf(f, "WORLD: Character Opcode 0x%.4X", recv_data.opcode);
    Log::getSingleton( ).outString( f );
	switch (recv_data.opcode)
	{
		case CMSG_CHAR_ENUM:
		{
			// parse m_characters and build a mighty packet of
			// characters to send to the client.
			int doo=1;
			int charsize = 181;  // assuming 20 character name

			data.clear();
			data.length = 1;
			data.opcode = SMSG_CHAR_ENUM;

			// Iterate through once because each individual character packet length varies based on the
			// size of their username.  It's always 159 + a max of 21 characters in the name
			CharacterList::iterator itr;
			for (itr = pClient->charListBegin(); itr != pClient->charListEnd(); ++itr){
				uint8 * pData = 0;
				uint8 length = 0;
				pData = new uint8[charsize];
                (*itr)->pClient = pClient;
				(*itr)->BuildEnumData( pData, &length );
				data.length += length;  // figure out the length of the whole data
				delete [] pData;
			}

			data.data = new uint8[ data.length ];
			data.data[0] = pClient->numCharacters();
			for (itr = pClient->charListBegin(); itr != pClient->charListEnd(); ++itr){
				uint8 * pData = 0;
				uint8 length = 0;
				pData = new uint8[charsize];
				(*itr)->BuildEnumData( pData, &length );
				memcpy( data.data+doo, pData, length );
				doo += length;
				delete [] pData;
			}

			pClient->SendMsg( &data );
			data.clear();
		}break;
		
		
		case CMSG_CHAR_CREATE:
		{		
			std::string name;
			
			recv_data >> name;
			recv_data.pointer = 0;
			if (pClient->getDB()->IsNameTaken((char *)name.c_str())) 
			{
				data.clear();
				data.length = 1;
				data.data = new uint8[ data.length ];
				data.opcode = SMSG_CHAR_CREATE;
				data.data[0] = 0x33;
				pClient->SendMsg( &data );
			}
			else 
			{
				Character * pNewChar = new Character;
				pNewChar->Create( world.m_hiCharGuid++, recv_data );

                wowWData save_data;
                pClient->addCharacter(pNewChar);

				pClient->getDB( )->addCharacter( pNewChar );
                pClient->getDB( )->setCharacter( pNewChar );
  				
				data.clear();
				data.length = 1;
				data.data = new uint8[ data.length ];
				data.opcode = SMSG_CHAR_CREATE;
				data.data[0] = 0x28;
				pClient->SendMsg( &data );

			}
		}break;

		case CMSG_CHAR_DELETE:
		{
			uint64 player_guid;
			memcpy(&player_guid,recv_data.data,8);

			CharacterList::iterator itr;
			for (itr = pClient->charListBegin(); itr != pClient->charListEnd(); itr++)
			{
				if ((*itr)->getGUID() == (uint32)player_guid)
				{
					pClient->getDB( )->removeCharacter( *itr );
					delete *itr;
					pClient->eraseCharacter( itr );
					itr = pClient->charListEnd();
				}
			}

			data.clear();
			data.length = 1;
			data.data = new uint8[ data.length ];
			data.opcode = SMSG_CHAR_DELETE;
			data.data[0] = 0x2E;
			pClient->SendMsg( &data );
		}break;
		default: {}break;
	}
}

