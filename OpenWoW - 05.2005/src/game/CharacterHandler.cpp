//////////////////////////////////////////////////////////////////////
//  Character Handler
//
//  Receives all messages with character management opcodes
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

#include "CharacterHandler.h"
#include "NetworkInterface.h"
#include "Opcodes.h"
#include "Log.h"
#include "Character.h"
#include "WorldServer.h"
#include "Database.h"
#include "UpdateMask.h"

typedef std::list<Character*> CharacterList;

CharacterHandler::CharacterHandler()
{

}

CharacterHandler::~CharacterHandler()
{

}

void CharacterHandler::HandleMsg( NetworkPacket & recv_data, GameClient *pClient )
{
	NetworkPacket data;
	char f[256];
	sprintf(f, "WORLD: Character Opcode 0x%.4X", recv_data.opcode);
	LOG.outString( f );
	switch (recv_data.opcode)
	{
		case CMSG_CHAR_ENUM:
		{
			// parse m_characters and build a mighty packet of
			// characters to send to the client.
			int charsize = 181;  // assuming 21 character name

			data.Clear();
			data.length = 1;
			data.opcode = SMSG_CHAR_ENUM;

			// Iterate through once because each individual character packet length varies based on the
			// size of their username.  It's always 159 + a max of 21 characters in the name
			CharacterList::iterator itr;
			uint8 * pData = new uint8[charsize];
			for (itr = pClient->charListBegin(); itr != pClient->charListEnd(); ++itr){
				uint8 length = 0;
				(*itr)->pClient = pClient;
				(*itr)->BuildEnumData( pData, &length );
				data.length += length;  // figure out the length of the whole data
			}

			data.data = new uint8[ data.length ];
			data.data[0] = pClient->numCharacters();
			int doo=1;
			for (itr = pClient->charListBegin(); itr != pClient->charListEnd(); ++itr){
				uint8 length = 0;
				(*itr)->BuildEnumData( pData, &length );
				memcpy( data.data+doo, pData, length );
				doo += length;
			}
			delete [] pData;

			pClient->SendMsg( &data );
			data.Clear();
			break;
		}

		case CMSG_CHAR_CREATE:
		{		
			std::string name;
			
			recv_data >> name;
			recv_data.top = 0;
			if (pClient->getDB()->IsNameTaken((char *)name.c_str())) 
			{
				data.Clear();
				data.length = 1;
				data.data = new uint8[ data.length ];
				data.opcode = SMSG_CHAR_CREATE;
				// MarkusWin32 :: fix wrong code sent back
				data.data[0] = 0x30;
				// End of MarkusWin32 fix
				pClient->SendMsg( &data );
			}
			else 
			{
				Character * pNewChar = new Character;
				pNewChar->Create( WORLDSERVER.m_hiCharGuid++, recv_data );

                NetworkPacket save_data;
                pClient->addCharacter(pNewChar);

				pClient->getDB( )->addCharacter( pNewChar );
                pClient->getDB( )->setCharacter( pNewChar );
  				
				data.Clear();
				data.length = 1;
				data.data = new uint8[ data.length ];
				data.opcode = SMSG_CHAR_CREATE;
				// MarkusWin32 :: fix acc creation bug
				data.data[0] = 0x2D;
				// End of MarkusWin32 fix
				pClient->SendMsg( &data );

			}
		}break;

		case CMSG_CHAR_DELETE:
		{
			guid player_guid;
			memcpy (&player_guid, recv_data.data, sizeof (guid));

			CharacterList::iterator itr;
			for (itr = pClient->charListBegin (); itr != pClient->charListEnd (); itr++)
			{
				if ((*itr)->getGUID () == player_guid)
				{
					pClient->getDB( )->removeCharacter( *itr );
					delete *itr;
					pClient->eraseCharacter( itr );
					itr = pClient->charListEnd();
				}
			}

			data.Clear();
			data.length = 1;
			data.data = new uint8[ data.length ];
			data.opcode = SMSG_CHAR_DELETE;
			// MarkusWin32 :: fix wrong code sent back
			data.data[0] = 0x36;
			// End of MarkusWin32 fix
			pClient->SendMsg( &data );
		}break;
		default: {}break;
	}
}

