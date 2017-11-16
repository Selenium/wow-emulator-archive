//////////////////////////////////////////////////////////////////////
//  GameClient
//  
//  Provides basic GameClient functions
//////////////////////////////////////////////////////////////////////

// Copyright (C) 2004 Team Python
// Copyright (C) 2004, 2005 Team WSD
// Copyright (C) 2006 Team Evolution
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
#include "Character.h"
#include "Log.h"

GameClient::GameClient()
{ 
	m_net = NULL;
	mCurrentChar = NULL;
	pleaseKillMe = false;
	numThreadsUsing = 0;
	m_isInWorld = false;
	rcvAuth = 0;
	rcvLogged = 0;
	gm_level = 0;
	m_accountId = -1;
	logoutTime = 0;
	m_charsnapshots.clear();
}

GameClient::~GameClient( )
{
	ClearCharacterSnapshotList();
	if(mCurrentChar)
		delete mCurrentChar;
	pleaseKillMe = true;
	while( numThreadsUsing != 0 );
	//remove it from
}

void GameClient::Create(int account_id, Socket *net)
{
	m_accountId = account_id;
	m_net = net;
}

void GameClient::BindAcctID( int account_id )
{
	m_accountId = account_id;
}

void GameClient::SendMsg(NetworkPacket *data)
{
#ifdef _DEBUG
	if(data==NULL)return;
#endif
	if( (uint32)m_net > 0xfff ) 
	{
		if( pleaseKillMe ) 
			return; 
		m_net->sendWData(data, (SrpWorld*)this );
	} 
	else 
		LOG.outError( "%s:%i WARNING:\n  %s\n", __FILE__, __LINE__, "Invalid m_net!  Perhaps pleaseKillMe was not set, or a memory conflict!" );
}

void GameClient::SendPacket(WowData *data)
{
    if( (uint32)m_net > 0xfff ) {
        numThreadsUsing ++;
        if( pleaseKillMe ) { numThreadsUsing --; return; }
        m_net->sendData(data, (SrpWorld*)this );
        numThreadsUsing --;
    } else {
        Log::getSingleton( ).outError( "%s:%i WARNING:\n  %s\n", __FILE__, __LINE__, "Invalid m_net!  Perhaps pleaseKillMe was not set, or a memory conflict!" );
    }
}

void GameClient::ClearCharacterSnapshotList( )
{
	CharacterSnapshotList::iterator itr;
	for (itr = m_charsnapshots.begin(); itr != m_charsnapshots.end(); itr++)
	if(*itr != NULL)
	{
		delete (*itr);
		*itr = NULL;
	}
	m_charsnapshots.clear();
}

void GameClient::setCurrentChar (Character* pChar)
{
	mCurrentChar = pChar;
	if (mCurrentChar)
		mCurrentChar->pClient = this;
}

void GameClient::refresh_char_snapshots()
{
	G_dbi_r->refresh_char_snapshots(this,m_accountId);
}

void GameClient::erase_character_snapshot( Character *p_char )
{
	CharacterSnapshotList::iterator itr;
	for (itr = charListBegin(); itr != charListEnd(); ++itr)
		if((*itr)->db_id==p_char->db_id)
		{
			delete *itr;
			m_charsnapshots.remove(*itr);
			return;
		}
}

void GameClient::erase_character_snapshot( uint32 db_id )
{
	CharacterSnapshotList::iterator itr;
	for (itr = charListBegin(); itr != charListEnd(); ++itr)
		if((*itr)->db_id==db_id)
		{
			delete *itr;
			m_charsnapshots.remove(*itr);
			return;
		}
}

int8 GameClient::has_character_snapshot(uint32 db_id)
{
	CharacterSnapshotList::iterator itr;
	for (itr = charListBegin(); itr != charListEnd(); ++itr)
		if((*itr)->db_id==db_id)
			return 1;
	return 0;
}

uint32 GameClient::db_id_from_snapshot_guid(uint32 guid_low,uint32 guid_high)
{
	CharacterSnapshotList::iterator itr;
	for (itr = charListBegin(); itr != charListEnd(); ++itr)
		if((*itr)->buffer[1]==guid_low && (*itr)->buffer[2]==guid_high)
			return (*itr)->db_id;
	return 0;
}

void Char_snapshot::create_snapshot(Character*owner)
{
	memset(buffer,0,CHARACTER_MAX_ENUM_BLOCK_SIZE*4);
	owner->build_enum_block((uint8*)&buffer[1],(uint8*)&buffer[0]);
	db_id = owner->db_id;
	G_dbi_r->set_char_snapshot(this);
}

void Char_snapshot::load_snapshot(uint32 pdb_id)
{
	db_id = pdb_id;
	G_dbi_r->get_char_snapshot(this);
	if(buffer[0]>CHARACTER_MAX_ENUM_BLOCK_SIZE*4)
		printf("Character snapshot has incorect size !!!!!\n");
}

