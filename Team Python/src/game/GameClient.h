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

#ifndef WOWPYTHONSERVER_GAMECLIENT_H
#define WOWPYTHONSERVER_GAMECLIENT_H

#include "Common.h"

#include "Client.h"

class DatabaseInterface;

class Object;
class Character;
struct wowWData;
typedef std::list<Character*> CharacterList;

class GameClient : public Client {
public:

//LINA ADD FOR KICK COMMAND
//i know it's very bad

    struct nlink
    {
        struct nlink *next;
        struct nlink *prev;
        int fd;
        int flags;
        int type;
    };

    struct nlink_client
    {
        struct nlink hdr;
        Client *pClient;
    };


    GameClient();
    ~GameClient();

    void Create( int account_id, NetworkInterface * net );
    void SendMsg( wowWData * data );
    void CreateDB();
    void BindAcctID( int account_id );
    DatabaseInterface * getDB( ) const { return m_db; }

    inline bool IsInWorld() { return m_isInWorld; };
    inline void InWorld(bool bNew) { m_isInWorld = bNew; };

    inline Character * getCurrentChar() const { return mCurrentChar; }
    void addCharacter(Character* pChar);
    void setCurrentChar(Character* pChar);
    inline int numCharacters() { return m_characters.size( ); };
    char* getCharacterName();
    char* getCharacterName(uint32 guid);
	char* getCharacterGuildName(uint32 guid);
    void ClearCharacterList();
    Character* getCurrentChar(uint32 player_guid);

    inline void eraseCharacter( CharacterList::iterator iter ) { m_characters.erase(iter); };
    inline CharacterList::iterator charListBegin() { return m_characters.begin(); };
    inline CharacterList::iterator charListEnd() { return m_characters.end(); };
    int isAuth() { return rcvAuth; }
    void setAuth() { rcvAuth = 1; }
    int isLogged() { return rcvLogged; }
    void setLogged() { rcvLogged = 1; }
    void unSetLogged() { rcvLogged = 0; }
    void SetLastTarget(uint32 ttarget) { lasttarget = ttarget; }
    uint32 getLastTarget() { return lasttarget; }

    inline void setAccountLvl(int lvl) { m_accountLvl = lvl; };
    inline int getAccountLvl() { return m_accountLvl; };
    int getAccountID() { return m_accountId; }

    inline void LogoutRequest(uint32 requestTime) { logoutTime = requestTime; };
    inline bool ShouldLogOut(uint32 currTime) { return (logoutTime > 0 && currTime >= logoutTime + 20); };

    inline void SetNLink( struct nlink_client* ncptr) { Nlink = ncptr;}; //LINA ADD FOR KICK COMMAND
    inline struct nlink_client * GetNLink() {return Nlink;};             //LINA ADD FOR KICK COMMAND

protected:
    struct nlink_client * Nlink; //LINA ADD FOR KICK COMMAND

    DatabaseInterface * m_db;
    Character * mCurrentChar;

    CharacterList m_characters; // list of characters this client has

    int m_accountLvl;   // 0 - normal, 1 - GM
    int m_accountId;
    int numThreadsUsing;
    bool pleaseKillMe;
    bool m_isInWorld;   // true when the client's character has been created and is int he world

    uint32 logoutTime;  // time we received a logout request -- wait 20 seconds, and quit
    uint32 lasttarget;

    int rcvAuth;
    int rcvLogged;
};

#endif
