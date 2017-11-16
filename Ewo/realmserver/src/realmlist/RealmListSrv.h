//////////////////////////////////////////////////////////////////////
// RealmListSrv.h: interface for the RealmListSrv class.
//
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

#ifndef WOWPYTHONSERVER_REALMLISTSRV_H
#define WOWPYTHONSERVER_REALMLISTSRV_H

#include "Server.h"

#include "RealmClient.h"
#include "DatabaseInterface.h"
#include "Database.h"

class DatabaseInterface;

#define REALMLISTSRV (RealmListSrv::getSingleton ())

class RealmListSrv : public Server, public Singleton < RealmListSrv >
{
   public:
      RealmListSrv();
      ~RealmListSrv();
      void addRealm( uint8 realmtype, uint8 flags, uint8 colour, char *name, char *adress, uint32 population, uint8 country, uint8 unk, uint8 online);
      void setRealm ( char * name, uint8 flags, uint8 colour, uint32 population );
      void printRealms();
      void removeRealm( char * name );
      void clear_realm_list();
      void refresh_realm_list();
	  void force_players_in_offline_state();
	  void HandleLogonChallenge(nlink *cptr);
	  void HandleLogonProof(nlink *cptr);
	  void HandleRealmList(nlink *cptr);
	  uint32 dbstate;

   protected:

      virtual void client_sockevent(nlink *cptr, unsigned short revents);
      virtual void server_sockevent(nlink *cptr, uint16 revents, void *myNet );
      virtual void disconnect_client(nlink *cptr );

#if __GNUC__ && (GCC_MAJOR < 4 || GCC_MAJOR == 4 && GCC_MINOR < 1)
#pragma pack(1)
#else
#pragma pack(push,1)
#endif 
      struct Realm {
		 uint8 RealmType; // RealmType Normal = 0, PvP = 1, RP = 6, RPPVP = 8
		 uint8 Flags; // Flags 0 - none; 1 - locked
		 uint8 Colour; // Colour: YellowGreen = 0, Red = 1, GrayOffline = 2
		 std::string Name;
         std::string Adress;
         uint32 Population; // players playing on the realm.
		 uint8 Chars; // Number of character at this realm for this account
		 uint8 Country; // Country UnitedKingdom = 0x0, USA = 0x1, Germany = 0x2, France = 0x3, Other = 0x4, Oceania = 0x5, Spain = 0x5,
         uint8 unk; // 0 unk, 2 - test realm?
      };

	  typedef std::map < std::string, Realm * > RealmMap;

#if __GNUC__ && (GCC_MAJOR < 4 || GCC_MAJOR == 4 && GCC_MINOR < 1)
#pragma pack()
#else
#pragma pack(pop)
#endif

      RealmMap::iterator i;
      Realm realm;
      uint8 TotalRealms;

      RealmMap mRealms;

      DatabaseInterface *dbi_r;
};

#endif // ndef WOWPYTHONSERVER_REALMLISTSRV_H

