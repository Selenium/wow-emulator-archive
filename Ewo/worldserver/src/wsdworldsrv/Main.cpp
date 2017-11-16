//////////////////////////////////////////////////////////////////////
//  Main
//
//  Main server
//////////////////////////////////////////////////////////////////////

// Copyright (C) 2004 Team Python
// Copyright (C) 2004, 2005 Team WSD
// Copyright (C) 2006 Team Evolution

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

#include "Server.h"
#include "Network.h"
#include "WorldServer.h"
#include "Log.h"
#include "Threads.h"
#include "Database.h"
#include "Console.h"
#include "CommandInterpreter.h"
#include "StringFun.h"
#include "SystemFun.h"
#include "version.h"
#include "Opcodes.h"

#include <getopt.h>

using namespace std;

struct ServerOptions
{
	bool Running;
	char *realm_name,*realm_ip;
	uint32 realm_port,realm_player_limit;
	uint8 realm_icon,realm_color,realm_timezone;
	char *DBhost_r, *DBuser_r, *DBpass_r, *DBdb_r;
	char *DBhost_w, *DBuser_w, *DBpass_w, *DBdb_w;
    char *ConfigFile;

	ServerOptions ()
	{
		Running = false;

		realm_name = strnew (REALMNAME);
		realm_ip = strnew (SERVERIP);
		realm_port = REALMPORT;
		realm_icon = 0;
		realm_color = 0;
		realm_timezone = 1;
		realm_player_limit = PLAYERLIMIT;
		DBhost_r = strnew (DBHOST);
		DBuser_r = strnew (DBUSER);
		DBpass_r = strnew (DBPASS);
		DBdb_r = strnew (DBDB);
		DBhost_w = strnew (DBHOST);
		DBuser_w = strnew (DBUSER);
		DBpass_w = strnew (DBPASS);
		DBdb_w = strnew (DBDB);
		ConfigFile = strnew (WS_CONFIG_FILE);
	}

	~ServerOptions ()
	{
		delete [] realm_name;
		delete [] realm_ip;
		delete [] DBhost_r;
		delete [] DBuser_r;
		delete [] DBpass_r;
		delete [] DBdb_r;
		delete [] DBhost_w;
		delete [] DBuser_w;
		delete [] DBpass_w;
		delete [] DBdb_w;
		delete [] ConfigFile;
	}
};

static void display_version ()
{
	CONSOLE.TextOutput (
		"\ax9World Server\ax2, version \axf%s\ax2\n"
		"Copyright \axf(C) \ax2%s\ax2\n",
		VERSION, COPYRIGHT);
}

static void display_usage (const char *argv0, ServerOptions &srvopt)
{
	display_version ();

	CONSOLE.TextOutput (
		"\n\ax2Usage: \axb%s [options]\ax2\n"
		"  \axa-c#\t--config=#\t\ax2Load an alternative config file (default: %s)\n"
		"  \axa-h\t--help\t\ax2Display program usage information\n"
		"  \axa-V\t--version\t\ax2Display program version information\n"
		, argv0, srvopt.ConfigFile);
}

static int cmdVersion (ServerOptions *srvopt)
{
	(void)srvopt;
	CONSOLE.TextOutput (
		"\ax2** Team Evolution WoW Server **    \axa%s\ax2    for build \axa%d\ax2 **\n",
		FULLVERSION, CLIENT_BUILD_MIN);
	return 0;
}

static int cmdQuit (ServerOptions *srvopt)
{
	(void)srvopt;
	return 1;
}

static int cmdStart (ServerOptions *srvopt)
{
	if (srvopt->Running)
	{
		CONSOLE.TextOutput (
			"\axeWARNING: \ax2Server already running\n");
                return 0;
	}
	DATABASE.Initialize_r (srvopt->DBhost_r,
					      srvopt->DBuser_r,
					      srvopt->DBpass_r,
					      srvopt->DBdb_r);
	DATABASE.Initialize_w (srvopt->DBhost_w,
					      srvopt->DBuser_w,
					      srvopt->DBpass_w,
					      srvopt->DBdb_w);
	//set realm settings for worldserver
	//add it to the database for realmserver to see it
	WORLDSERVER.set_realm_settings(srvopt->realm_name,srvopt->realm_ip,srvopt->realm_port,srvopt->realm_icon,
		srvopt->realm_color,srvopt->realm_timezone,srvopt->realm_player_limit);
	WORLDSERVER.Initialize (srvopt->realm_port, "World Server");

	CONSOLE.TextOutput (
		"\ax3Realm Database: \axf%s\ax3 on \axa%s\axf:\axa%s\axf@\axa%s\ax3\n",
		srvopt->DBdb_r, srvopt->DBuser_r,
		srvopt->DBpass_r, srvopt->DBhost_r);
	CONSOLE.TextOutput (
		"\ax3World Database: \axf%s\ax3 on \axa%s\axf:\axa%s\axf@\axa%s\ax3\n",
		srvopt->DBdb_w, srvopt->DBuser_w,
		srvopt->DBpass_w, srvopt->DBhost_w);

	WORLDSERVER.Start ();

	THREADS.setCurrentPriority (Threads::TP_LOWER);

//	WORLDSERVER.LoadHelp ();

	CONSOLE.TextOutput (
		"World of Warcraft Server v. \axf%s\ax3 started...\n"
		"Host(Realm): (%u)%s:%d\n"
		"World Logging is %s.\n"
		"Screen Logging is %s.\n",
		VERSION,
		WORLDSERVER.realm_id,srvopt->realm_ip, srvopt->realm_port,
		NETWORK.GetWorldLogging () ? "on" : "off",
		LOG.GetScreenLogging () ? "on" : "off"
		);
	return 0;
}
/*
static int cmdHost (ServerOptions *srvopt, char *HostName)
{
	if (HostName)
	{
		delete [] srvopt->cHost;
		srvopt->cHost = strnew (HostName);
	}
	else
		CONSOLE.TextOutput (
			"\ax3Host name is now: \axa%s\ax2\n",
			srvopt->cHost);
	return 0;
}

static int cmdName (ServerOptions *srvopt, char *Name)
{
	if (Name)
	{
		delete [] srvopt->cName;
		srvopt->cName = strnew (Name);
	}
	else
		CONSOLE.TextOutput (
			"\ax3Server name is now: \axa%s\ax2\n",
			srvopt->cName);
	return 0;
}
*/
//static int cmdRealmHost (ServerOptions *srvopt, char *HostName)
//static void cmdinitserversettings (uint8 icon,uint8 color,uint8 timezone,uint32 player_limit, ServerOptions *srvopt)
static int cmdInitRealm (ServerOptions *srvopt,uintptr icon,uintptr color,uintptr timezone,uintptr player_limit)
{
	srvopt->realm_icon = (uint8)icon;
	srvopt->realm_color = (uint8)color;
	srvopt->realm_timezone = (uint8)timezone;
	srvopt->realm_player_limit = player_limit;
/*	CONSOLE.TextOutput (
		"\axa%d\axa%d\axa%d\ax2\n",
		srvopt->realm_icon,srvopt->realm_color,
		srvopt->realm_timezone,srvopt->realm_player_limit);*/
	return 0;
}

static int cmdRealmHost (ServerOptions *srvopt, char *RealmName,char *RealmIp,uintptr Realmport)
{
	if (RealmName)
	{
		delete [] srvopt->realm_name;
		srvopt->realm_name = strnew (RealmName);
	}
	if (RealmIp)
	{
		delete [] srvopt->realm_ip;
		srvopt->realm_ip = strnew (RealmIp);
	}
	srvopt->realm_port = Realmport;
	CONSOLE.TextOutput (
		"\ax2realm name : \ax5%s \n\ax2realm_addr : \ax6%s:%d\n",
		srvopt->realm_name, srvopt->realm_ip,srvopt->realm_port);
	return 0;
}

static int cmdDB_r (ServerOptions *srvopt, const char *HostName,
		  const char *UserName, const char *Password, const char *DataBase)
{
	if (HostName)
	{
		delete [] srvopt->DBhost_r;
		delete [] srvopt->DBuser_r;
		delete [] srvopt->DBpass_r;
		delete [] srvopt->DBdb_r;
		srvopt->DBhost_r = strnew (HostName);
		srvopt->DBuser_r = strnew (UserName);
		srvopt->DBpass_r = strnew (Password);
		srvopt->DBdb_r = strnew (DataBase);
	}
	else
		CONSOLE.TextOutput (
			"\ax3Current database is: \axa%s\ax2 \axa%s\ax2:\axa%s\ax2 \axa%s\ax2\n",
			srvopt->DBhost_r, srvopt->DBuser_r,
			srvopt->DBpass_r, srvopt->DBdb_r);
	return 0;
}
static int cmdDB_w (ServerOptions *srvopt, const char *HostName,
		  const char *UserName, const char *Password, const char *DataBase)
{
	if (HostName)
	{
		delete [] srvopt->DBhost_w;
		delete [] srvopt->DBuser_w;
		delete [] srvopt->DBpass_w;
		delete [] srvopt->DBdb_w;
		srvopt->DBhost_w = strnew (HostName);
		srvopt->DBuser_w = strnew (UserName);
		srvopt->DBpass_w = strnew (Password);
		srvopt->DBdb_w = strnew (DataBase);
	}
	else
		CONSOLE.TextOutput (
			"\ax3Current database is: \axa%s\ax2 \axa%s\ax2:\axa%s\ax2 \axa%s\ax2\n",
			srvopt->DBhost_w, srvopt->DBuser_w,
			srvopt->DBpass_w, srvopt->DBdb_w);
	return 0;
}

static int cmdBroadcast (ServerOptions *srvopt, char *Text)
{
	(void)srvopt;
	WORLDSERVER.send_message(Text,SEND_MESSAGE_TO_EVRYBODY,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,(Character*)NULL,(Character*)NULL);
	CONSOLE.TextOutput (
		"\ax3Message sent to all players: \axa%s\ax2\n", Text);
	return 0;
}

static int cmdInfo (ServerOptions *srvopt)
{
	(void)srvopt;
	CONSOLE.TextOutput (
		"\ax3Users connected: \axa%d\ax2\n",
		WORLDSERVER.GetClientsConnected ());
	return 0;
}

static int cmdMotd (ServerOptions *srvopt, char *Motd)
{
	(void)srvopt;
	if (Motd)
		WORLDSERVER.SetMotd (Motd);
	else
		CONSOLE.TextOutput (
			"\ax3Current MOTD is: \axa%s\ax2\n",
			WORLDSERVER.GetMotd ());
	return 0;
}

static int cmdTime (ServerOptions *srvopt)
{
	(void)srvopt;
	uint32 time_s = WORLDSERVER.server_start_time;
	CONSOLE.TextOutput (
		"\ax3Server is running for : \axa%d:%d\ax2\n",
		time_s / 3600,time_s / 60, time_s % 60);
	return 0;
}

static int cmdWlog (ServerOptions *srvopt, uintptr Enable)
{
	(void)srvopt;
	if (Enable != NO_ARG)
		NETWORK.SetWorldLogging ((uint8)Enable);
	else
		CONSOLE.TextOutput (
			"\ax3World logging is now: \axa%s\ax2\n",
			NETWORK.GetWorldLogging () ? "on" : "off");
	return 0;
}

static int cmdSlog (ServerOptions *srvopt, uintptr Enable)
{
	(void)srvopt;
	if (Enable != NO_ARG)
		LOG.SetScreenLogging ((uint8)Enable);
	else
		CONSOLE.TextOutput (
			"\ax3Screen logging is now: \axa%s\ax2\n",
			LOG.GetScreenLogging () ? "on" : "off");
	return 0;
}

static int cmdBan (ServerOptions *srvopt, char *AddrList)
{
	(void)srvopt;
	DatabaseInterface *dbi = DATABASE.createDatabaseInterface_r ();
	dbi->BanIP (AddrList);
	DATABASE.removeDatabaseInterface (dbi);
	CONSOLE.TextOutput (
		"\ax3Adding to ban list: \axa%s\ax2\n", AddrList);
	return 0;
}

static int cmdAllow (ServerOptions *srvopt, char *AddrList)
{
	(void)srvopt;
	DatabaseInterface *dbi = DATABASE.createDatabaseInterface_r();
	dbi->AllowIP (AddrList);
	DATABASE.removeDatabaseInterface (dbi);
	CONSOLE.TextOutput (
		"\ax3Adding to allowed IP range: \axa%s\ax2\n", AddrList);
	return 0;
}
/*
static int cmdSaveAll (ServerOptions *srvopt)
{
	(void)srvopt;
	if (!WORLDSERVER.GetClientsConnected ())
		CONSOLE.TextOutput (
			"\ax3No Characters to save\ax2\n");
        else
		CONSOLE.TextOutput (
			"\ax3Characters saved:\axa%d\ax2 of \axa%d\ax2\n",
			WORLDSERVER.Save ("Server"),
			WORLDSERVER.GetClientsConnected ());
	return 0;
}
*/
/*
static int cmdReloadHelp (ServerOptions *srvopt)
{
	(void)srvopt;
	WORLDSERVER.LoadHelp ();
	CONSOLE.TextOutput (
		"\ax3Help reloaded\ax2\n");
	return 0;
}
*/
/*
static int cmdSM (ServerOptions *srvopt, uintptr Guid,
		  uintptr Opcode, uintptr Length, const char *Data)
{
	(void)srvopt;
	Character *pChar = WORLDSERVER.GetCharacter (Guid);
	if (!pChar)
	{
		CONSOLE.TextOutput (
			"\ax3Unable to find Client with CharGuid: \axa%u\ax2\n", Guid);
		return 0;
	}

	NetworkPacket packet;
	packet.Initialize (Length, Opcode);
	packet << Data;
	pChar->pClient->SendMsg (&packet);
	return 0;
}
*/
static int cmdLimit (ServerOptions *srvopt, uintptr Limit)
{
	(void)srvopt;
	if (Limit != NO_ARG)
		WORLDSERVER.SetClientLimit (Limit);
	else
		CONSOLE.TextOutput (
			"\ax3Current player limit set to: \axa%u\ax2\n",
	                WORLDSERVER.GetClientLimit ());
	return 0;
}
/*
typedef enum 
{ 
BLACK	= 0, 
BLUE	= 1, 
GREEN	= 2, 
CYAN	= 3, 
RED		= 4, 
MAGENTA	= 5, 
BROWN	= 6, 
LIGHTGRAY	= 7, 
DARKGRAY	= 8, 
LIGHTBLUE	= 9, 
LIGHTGREEN	= 10, 
LIGHTCYAN	= 11, 
LIGHTRED	= 12, 
LIGHTMAGENTA	= 13, 
YELLOW		= 14, 
WHITE		= 15
} COLORS; 
*/
int main (int argc, char **argv)
{
	int c;
	static struct option long_options[] =
	{
		{"config", required_argument, NULL, 'c'},
		{"help", no_argument, NULL, 'h'},
		{"version", no_argument, NULL, 'V'},
		{0, 0, 0, 0}
	};

CONSOLE.TextOutput("\apu");
CONSOLE.TextOutput("\a4a                         UUU  ‹  ‹    ﬂﬂﬂﬂﬂﬂ    ‹ﬂﬂﬂﬂ                           \r");
CONSOLE.TextOutput("\a4a                     ‹‹UUUUU‹‹ ‹‹ ﬂﬂﬂ‹      ‹ﬂﬂﬂ    ﬂﬂ‹ﬂﬂﬂ‹‹                    \r");
CONSOLE.TextOutput("\a4a                    U ‹UUUUUﬂ ﬂUUﬂ    ‹U  U‹    UUUﬂ  ‹‹UUﬂ ﬂﬂ                  \r");
CONSOLE.TextOutput("\a4a                   U UUUUUUﬂ   UUUU    ‹UU‹    UUUU  Uﬂ    UU ﬂ                 \r");
CONSOLE.TextOutput("\a4a                  U ‹UUﬂ     U  UUUU    UU    UUUU  UU  U   UU U                \r");
CONSOLE.TextOutput("\a4a                 U ‹UUU       U  UUUﬂ  ‹UUﬂ  UUUU  UU  UUﬂ   UU ﬂ               \r");
CONSOLE.TextOutput("\a4a                 U UUUUUUUUUﬂ UU  UUUU‹UUUU‹UUUU  UU  ‹UUﬂﬂ  UU ﬂ               \r");
CONSOLE.TextOutput("\a4a                 U UUUUUUUUUﬂ U    UUUUUUUUUUUU  ‹U  ‹UUU ﬂ   Uﬂ ﬂ              \r");
CONSOLE.TextOutput("\a4a                 U ‹UUU       ‹‹    UUUU  UUUU    UU   ‹U‹   UU ‹               \r");
CONSOLE.TextOutput("\a4a                  U ‹UU‹      ‹‹‹ ﬂﬂ           ﬂ   UU  ‹   UUU ‹                \r");
CONSOLE.TextOutput("\a4a                   U UUUUUUﬂ   ‹ﬂﬂﬂ ﬂ ﬂﬂﬂﬂﬂﬂ  ﬂ ﬂﬂ  Uﬂ   UUU ﬂ‹                 \r");
CONSOLE.TextOutput("\a4a                    U ‹UUUUUﬂ ﬂﬂ     ﬂ      ﬂﬂ    ﬂ  ‹UUUﬂ ﬂ‹                   \r");
CONSOLE.TextOutput("\a4a                    Uﬂﬂﬂﬂﬂ‹‹‹ﬂ                     ﬂﬂﬂﬂﬂﬂﬂﬂ                     \r");
CONSOLE.TextOutput("\a4a                                                         <SOLFERN>              \r");
CONSOLE.TextOutput("\apo");

	// Initialize default server parameters
	ServerOptions srvopt;

	while ((c = getopt_long(argc, argv, "c:hv", long_options, NULL)) != EOF) {
		switch (c) {
		case 'c':
			delete [] srvopt.ConfigFile;
			srvopt.ConfigFile = strnew (optarg);
			break;
		case 'h':
			display_usage (argv[0], srvopt);
			return 0;
		case 'v':
			display_version ();
			return 0;
		default:
			abort ();
		}
	}

	static CommandDesc Commands [] =
	{
		{ "start",     0, {}, CMDFUNC (cmdStart),  "Start the server" },
		{ "stop",      0, {}, CMDFUNC (cmdQuit),  "Stop and shutdown server" },
		{ "exit",      0, {}, CMDFUNC (cmdQuit),  "Exit and shutdown server" },
		{ "quit",      0, {}, CMDFUNC (cmdQuit),  "Quit and shutdown server" },
		{ "ver",       0, {}, CMDFUNC (cmdVersion),	  "Display server and expected client version" },
		{ "inithost",  3, { ARG_STR,ARG_STR,ARG_INT }, CMDFUNC (cmdRealmHost),  "Set the World Server realm host" },
		{ "initrealm", 4, { ARG_INT,ARG_INT,ARG_INT,ARG_INT }, CMDFUNC (cmdInitRealm),  "Set the World Server realm settings" },
		{ "db_r",      4, { ARG_OSTR, ARG_STR, ARG_STR, ARG_STR }, CMDFUNC (cmdDB_r),  "Set the database host/user/password/database for realm server" },
		{ "db_w",      4, { ARG_OSTR, ARG_STR, ARG_STR, ARG_STR }, CMDFUNC (cmdDB_w),  "Set the database host/user/password/database for world server" },
		{ "bcast",     1, { ARG_OSTR }, CMDFUNC (cmdBroadcast),  "Send a system message to all the players in the world" },
		{ "info",      0, {}, CMDFUNC (cmdInfo),  "Show general server information" },
		{ "motd",      1, { ARG_OSTR }, CMDFUNC (cmdMotd),  "Set/display the current MOTD" },
		{ "time",      0, {}, CMDFUNC (cmdTime),  "Display current game time" },
		{ "wlog",      1, { ARG_OBOOL }, CMDFUNC (cmdWlog),  "Log packets sent and recv'd by the world server" },
		{ "slog",      1, { ARG_OBOOL }, CMDFUNC (cmdSlog),  "Log msgs to screen (errors will still be displayed)" },
		{ "ban",       1, { ARG_STR }, CMDFUNC (cmdBan),  "Ban an IP address/list from the server" },
		{ "allow",     1, { ARG_STR }, CMDFUNC (cmdAllow),  "Allow an IP address/list to connect" },
//		{ "saveall",   0, {}, CMDFUNC (cmdSaveAll),  "Force saving the world and characters" },
//		{ "reloadhelp",0, {}, CMDFUNC (cmdReloadHelp),  "Reload help from database" },
//		{ "sm",        4, { ARG_INT, ARG_INT, ARG_INT, ARG_STR }, CMDFUNC (cmdSM),  "Build and send a synthetic packet to a client" },
		{ "limit",     1, { ARG_OINT }, CMDFUNC (cmdLimit),  "Set/display the player limit" },
	};

	display_version ();

	CommandInterpreter (srvopt.ConfigFile, &srvopt,
			    Commands, ARRAY_LEN (Commands),
			    "\ax1world\ax9srv\axf> \ax7");

	THREADS.setCurrentPriority( Threads::TP_LOWER );

	LOG << "Stopping world server..." << endl;
	WORLDSERVER.Stop ();

	LOG << "Disconnecting clients..." << endl;
	NETWORK.disconnectAll ();

	LOG << "Halting process..." << endl;
	THREADS.closeCurrentThread ();
	
	LOG << "Removing realm from realm list " << endl;
	return 0;
}
