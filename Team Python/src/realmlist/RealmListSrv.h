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

// RealmListSrv.h: interface for the RealmListSrv class.
//
//////////////////////////////////////////////////////////////////////

#ifndef WOWPYTHONSERVER_REALMLISTSRV_H
#define WOWPYTHONSERVER_REALMLISTSRV_H

#include "RealmClient.h"
#include "Server.h"


class RealmListSrv : public Server, public Singleton < RealmListSrv >
{
public:
	RealmListSrv();
	~RealmListSrv();

  void addRealm( char * name, char * address, uint8 icon, uint8 color, uint32 players = 0 );
  void setRealm( char * name, uint8 icon, uint8 color, uint32 players = 0 );
  void printRealms();
  void removeRealm( char * name );

protected:

  virtual void client_sockevent(struct nlink_client *cptr, unsigned short revents);
  virtual void server_sockevent( nlink_server *cptr, uint16 revents, void *myNet );
  virtual void disconnect_client(	struct nlink_client *cptr );
  
  struct Realm {
    std::string address;
    uint32 players;
	uint8 icon;
	uint8 color;
  };

  typedef std::map < std::string, Realm * > RealmMap;
  RealmMap mRealms;

  struct Patch {
      uint8 Hash[16];
      char Platform[4];
  };
  
  typedef std::map < uint32, Patch * > PatchMap;
  PatchMap mPatches;
};

#endif // ndef WOWPYTHONSERVER_REALMLISTSRV_H

