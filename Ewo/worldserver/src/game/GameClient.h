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

#ifndef WOWPYTHONSERVER_GAMECLIENT_H
#define WOWPYTHONSERVER_GAMECLIENT_H

#include "Common.h"
#include "Client.h"
#include "SrpWorld.h"
#include "Network.h"
#include "multi_block_packet.h"

#define MAX_GM_TEXT_LENGTH 250

//class DatabaseInterface;
class Object;
class Character;
class NetworkPacket;

//used for a blink of a second on char logout so next time on char enum it can be used
//totaly automated will create the snapshot and store it in db for next time
#define CHARACTER_MAX_ENUM_BLOCK_SIZE 80
class Char_snapshot
{
public:
	void create_snapshot(Character*owner);
	void load_snapshot(uint32 pdb_id);
	uint32		db_id;
	uint32		buffer[CHARACTER_MAX_ENUM_BLOCK_SIZE];//aproximated only. First uint32 means size
};
//typedef std::list<Character*> CharacterList;
typedef std::list<Char_snapshot*> CharacterSnapshotList;

class GameClient : public Client, public SrpWorld
{
	public:
		GameClient();
		~GameClient();
		void Create( int account_id, Socket * net );
		void SendMsg( NetworkPacket * data );
		void SendPacket(WowData * data );
		void BindAcctID( int account_id );
		inline uint8 IsInWorld() { return m_isInWorld; };
		inline void InWorld(uint8 bNew) { m_isInWorld = bNew; };
		inline Character * getCurrentChar() const { return mCurrentChar; }
//		void addCharacter(Character* pChar);
		void setCurrentChar(Character* pChar);
		inline int numCharacters() { return static_cast<int>(m_charsnapshots.size()); };
		void ClearCharacterSnapshotList();
		inline CharacterSnapshotList::iterator charListBegin() { return m_charsnapshots.begin(); };
		inline CharacterSnapshotList::iterator charListEnd() { return m_charsnapshots.end(); };
		void	erase_character_snapshot(Character *p_char);
		void	erase_character_snapshot(uint32	db_id);
		int8	has_character_snapshot(uint32 db_id);
		uint32	db_id_from_snapshot_guid(uint32 guid_low,uint32 guid_high);
		inline int isAuth() { return rcvAuth; }
		inline void setAuth() { rcvAuth = 1; }
		inline int isLoggedIn() { return rcvLogged; }
		inline void setLoggedIn() { rcvLogged = 1; }
		inline void unSetLoggedIn() { rcvLogged = 0; }
		inline void setAccountLvl(int lvl) { gm_level = lvl; };
		inline int getAccountLvl() { return gm_level; };
		int getAccountID() { return m_accountId; }
		inline void LogoutRequest(uint32 requestTime) { logoutTime = requestTime; };
		inline bool ShouldLogOut(uint32 currTime) { return (logoutTime > 0 && currTime >= logoutTime + 20 && rcvLogged); };
		//for the current account id, it will load only character snapshots
		void refresh_char_snapshots();

//		DatabaseInterface * dbi_r,*dbi_w;
		Character				*mCurrentChar;
		CharacterSnapshotList	m_charsnapshots; // list of characters this client has
		uint32					m_accountId;
		uint32					numThreadsUsing;
		bool					pleaseKillMe;
		uint8					m_isInWorld;   // true when the client's character has been created and is int he world
		uint8					gm_level;		//this is acces level for gm. Based on this he may execute higher level commands
		char					gm_text[MAX_GM_TEXT_LENGTH];	//this is the gm_ticket text
		uint32					logoutTime;   // time we received a logout request -- wait 20 seconds, and quit
		int						rcvAuth;
		int						rcvLogged;
		Compressed_Update_Block compressed_update;	//stores multi A9 packets to be sent compressed
};

#endif
