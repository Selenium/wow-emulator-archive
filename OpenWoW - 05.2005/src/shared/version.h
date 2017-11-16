//////////////////////////////////////////////////////////////////////
//  version
//  
//  versioninfo and basic configuration
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

#ifndef __VERSION_H__
#define __VERSION_H__

// Server Settings [ Connection ]
#define SERVERIP	"localhost"
#define LANIP		"localhost"
#define REALMIP		"localhost"
#define SERVERNAME	"Server"
#define COPYRIGHT	"2004 Team Python; 2004, 2005 Team OpenWoW"
#define SITW		"Write !help for a complete list of Commands."

#define DBHOST		"localhost"
#define DBUSER		"wow"
#define DBPASS		"wow"
#define DBDB		"wow"

// Server Settings [ Gameplay ]

// Faction Vs Faction (0 = off / 1 = on)
#define FvF		0
// Start human zone (0 = off / 1 = on)
#define SHZ		1
// Play Cinematics  (0 = off / 1 = on)
#define INTRO		1
// For Fix the mobs stats and size (1 = server will fixe the db / 0 = server doing nothing :P)
#define FIXE		0
// Max number of clients
#define CLIENTLIMIT	50

// Version Settings
#define VERSION "1.2.1"
#define GVERSION "1.2.1"
#define XVERSION "1.2.1.01"

#define EXPECTED_WOW_CLIENT_BUILD        4150 //3925 //3892 //3810//3807//3734//3712//3702//3694
// 3925 for 0.11.0

#if PLATFORM == PLATFORM_WIN32
# define FULLVERSION XVERSION "-win"
#else
# define FULLVERSION XVERSION "-nix"
#endif

#define RL_CONFIG_FILE	"realmlist.conf"
#define WS_CONFIG_FILE	"worldserv.conf"
#define ACCOUNTS_FILE	"passwd"
#define REALMS_FILE	"realms"

#endif // __VERSION_H__
