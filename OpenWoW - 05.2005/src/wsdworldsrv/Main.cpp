//////////////////////////////////////////////////////////////////////
//  Main
//
//  Main server
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

#include <getopt.h>

using namespace std;

struct ServerOptions
{
	bool Running;
	char *rHost, *cHost, *cName;
	char *DBhost, *DBuser, *DBpass, *DBdb;
        char *ConfigFile;
	int dbfixe;

	ServerOptions ()
	{
		Running = false;
		cHost = strnew (LANIP);
		rHost = strnew (REALMIP);
		cName = strnew (SERVERNAME);
		DBhost = strnew (DBHOST);
		DBuser = strnew (DBUSER);
		DBpass = strnew (DBPASS);
		DBdb = strnew (DBDB);
		ConfigFile = strnew (WS_CONFIG_FILE);
		dbfixe = FIXE;
	}

	~ServerOptions ()
	{
		delete [] cHost;
		delete [] rHost;
		delete [] cName;
		delete [] DBhost;
		delete [] DBuser;
		delete [] DBpass;
		delete [] DBdb;
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
		"\ax2** Team WSD WoW Server **    \axa%s\ax2    for build \axa%d\ax2 **\n",
		FULLVERSION, EXPECTED_WOW_CLIENT_BUILD);
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

	DATABASE.Initialize (srvopt->DBhost,
					      srvopt->DBuser,
					      srvopt->DBpass,
					      srvopt->DBdb);

	WORLDSERVER.Initialize (8129, "World Server");
	WORLDSERVER.SetRLHost (srvopt->rHost);

	CONSOLE.TextOutput (
		"\ax3Database: \axf%s\ax3 on \axa%s\axf:\axa%s\axf@\axa%s\ax3\n",
		srvopt->DBdb, srvopt->DBuser,
		srvopt->DBpass, srvopt->DBhost);

	WORLDSERVER.Start ();

	THREADS.setCurrentPriority (Threads::TP_LOWER);

	WORLDSERVER.LoadHelp ();

	CONSOLE.TextOutput (
		"World of Warcraft Server v. \axf%s\ax3 started...\n"
		"Host: %s:%d\n"
		"World Logging is %s.\n"
		"Screen Logging is %s.\n"
		"Firewall is %s.\n"
		"Test Login/IP is %s\n"
		"Server Cinematics is %s\n"
		"Server start zone set to: %s\n",
		XVERSION,
		srvopt->cHost, 8129,
		NETWORK.GetWorldLogging () ? "on" : "off",
		LOG.GetScreenLogging () ? "on" : "off",
		DATABASE.GetFirewall () ? "on" : "off",
		DATABASE.GetTestIP () ? "on" : "off",
		(WORLDSERVER.GetCinematics ()) ? "on" : "off",
		(WORLDSERVER.GetStartZone ()) ? "Human Zone" : "Normal Race Zone");
	return 0;
}

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

static int cmdRealmHost (ServerOptions *srvopt, char *HostName)
{
	if (HostName)
	{
		delete [] srvopt->rHost;
		srvopt->rHost = strnew (HostName);
	}
	else
		CONSOLE.TextOutput (
			"\ax3Realm host name is now: \axa%s\ax2\n",
			srvopt->rHost);
	return 0;
}

static int cmdDB (ServerOptions *srvopt, const char *HostName,
		  const char *UserName, const char *Password, const char *DataBase)
{
	if (HostName)
	{
		delete [] srvopt->DBhost;
		delete [] srvopt->DBuser;
		delete [] srvopt->DBpass;
		delete [] srvopt->DBdb;
		srvopt->DBhost = strnew (HostName);
		srvopt->DBuser = strnew (UserName);
		srvopt->DBpass = strnew (Password);
		srvopt->DBdb = strnew (DataBase);
	}
	else
		CONSOLE.TextOutput (
			"\ax3Current database is: \axa%s\ax2 \axa%s\ax2:\axa%s\ax2 \axa%s\ax2\n",
			srvopt->DBhost, srvopt->DBuser,
			srvopt->DBpass, srvopt->DBdb);
	return 0;
}

static int cmdBroadcast (ServerOptions *srvopt, char *Text)
{
	(void)srvopt;
	WORLDSERVER.SendWorldText ((uint8 *)Text);
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
	time_t time = WORLDSERVER.updateGameTime ();
	CONSOLE.TextOutput (
		"\ax3Game time is now: \axa%d:%d\ax2\n",
		time / 60, time % 60);
	return 0;
}

static int cmdWlog (ServerOptions *srvopt, uintptr Enable)
{
	(void)srvopt;
	if (Enable != NO_ARG)
		NETWORK.SetWorldLogging (Enable);
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
		LOG.SetScreenLogging (Enable);
	else
		CONSOLE.TextOutput (
			"\ax3Screen logging is now: \axa%s\ax2\n",
			LOG.GetScreenLogging () ? "on" : "off");
	return 0;
}

static int cmdAutoCreate (ServerOptions *srvopt, uintptr Enable)
{
	(void)srvopt;
	if (Enable != NO_ARG)
		DATABASE.SetAutoCreateAcct (Enable);
	else
		CONSOLE.TextOutput (
			"\ax3Auto Account Creation is now: \axa%s\ax2\n",
			DATABASE.GetAutoCreateAcct () ? "on" : "off");
	return 0;
}

static int cmdFirewall (ServerOptions *srvopt, uintptr Enable)
{
	(void)srvopt;
	if (Enable != NO_ARG)
		DATABASE.SetFirewall (Enable);
	else
		CONSOLE.TextOutput (
			"\ax3Firewall is now: \axa%s\ax2\n",
			DATABASE.GetFirewall () ? "on" : "off");
	return 0;
}

static int cmdBan (ServerOptions *srvopt, char *AddrList)
{
	(void)srvopt;
	DatabaseInterface *dbi = DATABASE.createDatabaseInterface ();
	dbi->BanIP (AddrList);
	DATABASE.removeDatabaseInterface (dbi);
	CONSOLE.TextOutput (
		"\ax3Adding to ban list: \axa%s\ax2\n", AddrList);
	return 0;
}

static int cmdAllow (ServerOptions *srvopt, char *AddrList)
{
	(void)srvopt;
	DatabaseInterface *dbi = DATABASE.createDatabaseInterface();
	dbi->AllowIP (AddrList);
	DATABASE.removeDatabaseInterface (dbi);
	CONSOLE.TextOutput (
		"\ax3Adding to allowed IP range: \axa%s\ax2\n", AddrList);
	return 0;
}

static int cmdRmIP (ServerOptions *srvopt, char *AddrList)
{
	(void)srvopt;
	DatabaseInterface *dbi = DATABASE.createDatabaseInterface();
	dbi->RemoveIP (AddrList);
	DATABASE.removeDatabaseInterface (dbi);
	CONSOLE.TextOutput (
		"\ax3Removing from allowed IP range: \axa%s\ax2\n", AddrList);
	return 0;
}

static int cmdTestIP (ServerOptions *srvopt, uintptr Enable)
{
	(void)srvopt;
	if (Enable != NO_ARG)
		DATABASE.SetTestIP (Enable);
	else
		CONSOLE.TextOutput (
			"\ax3Test Login/IP is now: \axa%s\ax2\n",
			DATABASE.GetTestIP () ? "on" : "off");
	return 0;
}

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

static int cmdReloadHelp (ServerOptions *srvopt)
{
	(void)srvopt;
	WORLDSERVER.LoadHelp ();
	CONSOLE.TextOutput (
		"\ax3Help reloaded\ax2\n");
	return 0;
}

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

static int cmdFixe (ServerOptions *srvopt, uintptr Enable)
{
	if (Enable != NO_ARG)
		srvopt->dbfixe = (Enable != 0);
	CONSOLE.TextOutput (
		"\ax3Database fixes are currently: \axa%s\ax2\n",
		srvopt->dbfixe ? "on" : "off");
	return 0;
}

static int cmdCinematics (ServerOptions *srvopt, uintptr Enable)
{
	(void)srvopt;
	if (Enable != NO_ARG)
                WORLDSERVER.SetCinematics (Enable);
	CONSOLE.TextOutput (
		"\ax3Server Cinematics are currently: \axa%s\ax2\n",
		WORLDSERVER.GetCinematics () ? "on" : "off");
	return 0;
}

static int cmdStZone (ServerOptions *srvopt, uintptr Zone)
{
	(void)srvopt;
	if (Zone != NO_ARG)
		WORLDSERVER.SetStartZone (Zone);
	else
		CONSOLE.TextOutput (
			"\ax3Server start zone set to: \axa%s\ax2\n",
			WORLDSERVER.GetStartZone () ?
			"Human Zone" : "Normal Race Zone");
	return 0;
}

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
		{ "start",     0, {}, CMDFUNC (cmdStart),
		  "Start the server" },
		{ "stop",      0, {}, CMDFUNC (cmdQuit),
		  "Stop and shutdown server" },
		{ "exit",      0, {}, CMDFUNC (cmdQuit),
		  "Exit and shutdown server" },
		{ "quit",      0, {}, CMDFUNC (cmdQuit),
		  "Quit and shutdown server" },
		{ "ver",       0, {}, CMDFUNC (cmdVersion),
		  "Display server and expected client version" },
		{ "host",      1, { ARG_OSTR }, CMDFUNC (cmdHost),
		  "Set the World Server address" },
		{ "name",      1, { ARG_OSTR }, CMDFUNC (cmdName),
		  "Sets the World Server Name" },
		{ "realmhost", 1, { ARG_OSTR }, CMDFUNC (cmdRealmHost),
		  "Set the Realm Server address" },
		{ "db",        4, { ARG_OSTR, ARG_STR, ARG_STR, ARG_STR }, CMDFUNC (cmdDB),
		  "Set the database host/user/password/database" },
		{ "bcast",     1, { ARG_OSTR }, CMDFUNC (cmdBroadcast),
		  "Send a system message to all the players in the world" },
		{ "info",      0, {}, CMDFUNC (cmdInfo),
		  "Show general server information" },
		{ "motd",      1, { ARG_OSTR }, CMDFUNC (cmdMotd),
		  "Set/display the current MOTD" },
		{ "time",      0, {}, CMDFUNC (cmdTime),
		  "Display current game time" },
		{ "wlog",      1, { ARG_OBOOL }, CMDFUNC (cmdWlog),
		  "Log packets sent and recv'd by the world server" },
		{ "slog",      1, { ARG_OBOOL }, CMDFUNC (cmdSlog),
		  "Log msgs to screen (errors will still be displayed)" },
		{ "autocreate",0, {}, CMDFUNC (cmdAutoCreate),
		  "Auto create new accounts" },
		{ "firewall",  1, { ARG_OBOOL }, CMDFUNC (cmdFirewall),
		  "Set/display firewall status" },
		{ "ban",       1, { ARG_STR }, CMDFUNC (cmdBan),
		  "Ban an IP address/list from the server" },
		{ "allow",     1, { ARG_STR }, CMDFUNC (cmdAllow),
		  "Allow an IP address/list to connect" },
		{ "rmip",      1, { ARG_STR }, CMDFUNC (cmdRmIP),
		  "Remove an IP address/list from the ban/allow list" },
		{ "testip",    1, { ARG_OBOOL }, CMDFUNC (cmdTestIP),
		  "Set/display status of the login/ip test for GM" },
		{ "saveall",   0, {}, CMDFUNC (cmdSaveAll),
		  "Force saving the world and characters" },
		{ "reloadhelp",0, {}, CMDFUNC (cmdReloadHelp),
		  "Reload help from database" },
		{ "sm",        4, { ARG_INT, ARG_INT, ARG_INT, ARG_STR }, CMDFUNC (cmdSM),
		  "Build and send a synthetic packet to a client" },
		{ "fixe",      1, { ARG_OBOOL }, CMDFUNC (cmdFixe),
		  "Set/display the db autofix flag" },
		{ "cinematics",1, { ARG_OBOOL }, CMDFUNC (cmdCinematics),
		  "Set/display server cinematics" },
		{ "stzone",    1, { ARG_OINT }, CMDFUNC (cmdStZone),
		  "Set/display the default start zone (0-Normal, 1-Human)" },
		{ "limit",     1, { ARG_OINT }, CMDFUNC (cmdLimit),
		  "Set/display the player limit" },
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

	return 0;
}
