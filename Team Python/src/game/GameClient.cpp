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

#include "GameClient.h"
#include "NetworkInterface.h"
#include "Database.h"
#include "Character.h"
#include "Log.h"

GameClient::GameClient( )
{ 
    m_net = NULL;
    mCurrentChar = NULL;
    pleaseKillMe = false;
    numThreadsUsing = 0;
    m_isInWorld = false;
    rcvAuth = 0;
	rcvLogged = 0;
    m_accountLvl = 0;
    logoutTime = 0;
	
}

GameClient::~GameClient( ) {
    ClearCharacterList( );
    pleaseKillMe = true;
    while( numThreadsUsing != 0 );
    Database::getSingleton( ).removeDatabaseInterface( m_db );
}

void GameClient::Create(int account_id, NetworkInterface *net)
{
    m_accountId = account_id;
    m_net = net;
    m_db = Database::getSingleton( ).createDatabaseInterface( );
}
void GameClient::BindAcctID( int account_id )
{
    m_accountId = account_id;
}
void GameClient::CreateDB() 
{
    m_db = Database::getSingleton( ).createDatabaseInterface( );	
}
void GameClient::SendMsg(wowWData *data)
{
    if( (uint32)m_net > 0xfff ) {
        numThreadsUsing ++;
        if( pleaseKillMe ) { numThreadsUsing --; return; }
        m_net->sendWData(data);
        numThreadsUsing --;
    } else {
        Log::getSingleton( ).outError( "%s:%i WARNING:\n  %s\n", __FILE__, __LINE__, "Invalid m_net!  Perhaps pleaseKillMe was not set, or a memory conflict!" );
    }
}

char* GameClient::getCharacterName(uint32 guid)
{
    CharacterList::iterator itr;
    for (itr = m_characters.begin(); itr != m_characters.end(); itr++){
        if ((*itr)->getGUID() == (uint32)guid){
            return (char *)((*itr)->m_name);
        }
    }

    assert(!"Invalid Player_GUID in getCharacterName!");
    return NULL;
}

char* GameClient::getCharacterGuildName(uint32 guid) 
{ 
	CharacterList::iterator itr; 
	for (itr = m_characters.begin(); itr != m_characters.end(); itr++) 
	{ 
		if ((*itr)->getGUID() == (uint32)guid) 
			return (char *)((*itr)->m_guildname); 
	} 
	assert(!"Invalid Player_GUID in getCharacterGuildName!"); 
	return NULL; 
} 


char* GameClient::getCharacterName()
{
    if (!mCurrentChar){
        return NULL;
    }

    return (char *)mCurrentChar->m_name;
}


void GameClient::ClearCharacterList( )
{
    CharacterList::iterator itr;
    for (itr = m_characters.begin(); itr != m_characters.end(); itr++){
        delete *itr;
        *itr = NULL;
    }

    m_characters.clear();
}


Character* GameClient::getCurrentChar(uint32 player_guid)
{
    for (CharacterList::iterator itr = m_characters.begin(); itr != m_characters.end(); itr++){
        if( (*itr)->getGUID() == player_guid )
        {
            return((Character*)*itr);
        }
    }

    assert(!"Invalid Player_GUID in getCurrentChar!");
    return NULL;
}


void GameClient::addCharacter(Character* pChar)
{ 
    pChar->m_accountId = m_accountId;
    m_characters.push_back(pChar); 
}


void GameClient::setCurrentChar(Character* pChar)
{
    mCurrentChar = pChar;

    if (mCurrentChar)
        mCurrentChar->pClient = this;
}
