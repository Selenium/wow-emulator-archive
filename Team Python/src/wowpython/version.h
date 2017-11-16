// Copyright (C) 2004 Team Python
// Copyright (C) 2004 Team WoWSrvDev
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


// Server Settings [ Connection ]
#define SERVERIP "localhost"
#define LANIP "localhost"
#define SERVERNAME "Server"

#define DBHOST "localhost"
#define DBUSER "wow"
#define DBPASS "wow"
#define DBDB "wow"
#define TEAM "WSD"
#define SITW "Write !help for a complete list of Commands."
#define THANKS "..."
#define PLAYER_LIMIT 30

// Server Settings [ Gameplay ]
#define FvF 0		// Faction Vs Faction (0 = off / 1 = on)
#define SHZ 1		// Start human zone (0 = off / 1 = on)
#define INTRO 1		// Play Cinematics  (0 = off / 1 = on)
#define FIXE 0		// For Fix the mobs stats and size (1 = server will fixe the db / 0 = server doing nothing :P)

// Version Settings
#define VERSION "0.11.0.5"
#define GVERSION "0.11.0.5"
#define XVERSION "0.11.0.5.19"

#if PLATFORM == PLATFORM_WIN32
# define FULLVERSION XVERSION "-win"
#else
# define FULLVERSION XVERSION "-unix"
#endif