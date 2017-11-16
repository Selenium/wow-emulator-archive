//////////////////////////////////////////////////////////////////////
//  version
//  
//  versioninfo and basic configuration
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

#ifndef __VERSION_H__
#define __VERSION_H__

// Server Settings [ Connection ]
#define SERVERIP   "localhost"
#define LANIP      "localhost"
#define REALMIP      "localhost"
#define SERVERNAME   "Server"
#define REALMNAME   "Evolution"
#define REALMPORT   3726
#define PLAYERLIMIT   50
#define COPYRIGHT   "2004 Team Python; 2004, 2005 Team OpenWoW; 2006 Team Evolution"
#define SITW      "Write !help for a complete list of Commands."

#define DBHOST      "localhost"
#define DBUSER      "wow_user"
#define DBPASS      "wow_passw"
#define DBDB		"wow_db"

// Server Settings [ Gameplay ]

// Faction Vs Faction (0 = off / 1 = on)
#define FvF      0
// Start human zone (0 = off / 1 = on)
#define SHZ      1
// Play Cinematics  (0 = off / 1 = on)
#define INTRO      1
// For Fix the mobs stats and size (1 = server will fixe the db / 0 = server doing nothing :P)
#define FIXE      0
// Max number of clients
#define CLIENTLIMIT   50

// Version Settings
#define VERSION "1"

#if PLATFORM == PLATFORM_WIN32
# define FULLVERSION VERSION "-win"
#else
# define FULLVERSION VERSION "-nix"
#endif

#define RL_CONFIG_FILE   "realmlist.conf"
#define WS_CONFIG_FILE   "worldserv.conf"

#define REALM_REFRESH_INTERVAL 30 //time must pass until we will refresh realmlist=0.5 min (flood control)
#define CLIENT_BUILD_MIN 4700
#define CLIENT_BUILD_MAX 4937

#define REALMLIST_SERVER_CLIENT_PORT 3724
#define WORLDSERVER_CLIENT_PORT 3725

#endif // __VERSION_H__
