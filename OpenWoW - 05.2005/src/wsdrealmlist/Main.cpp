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

#include "Accounts.h"
#include "RealmList.h"
#include "Server.h"
#include "Network.h"
#include "RealmListSrv.h"
#include "WorldCommSrv.h"
#include "Log.h"
#include "Threads.h"
#include "Console.h"
#include "SystemFun.h"
#include "StringFun.h"
#include "CommandInterpreter.h"
#include "getopt.h"
#include "version.h"

#include <fstream>
using namespace std;

#if PLATFORM == PLATFORM_WIN32
#  define WIN32_LEAN_AND_MEAN
#  include <windows.h>
#endif

struct ServerOptions
{
	bool Running;
	char *serverAddress;
	char *serverName;
	char *realmsFile;
	char *accountsFile;
	char *configFile;

	ServerOptions ()
	{
		Running = false;
		serverAddress = strnew (SERVERIP);
		serverName = strnew (SERVERNAME);
		accountsFile = strnew (ACCOUNTS_FILE);
		realmsFile = strnew (REALMS_FILE);
		configFile = strnew (RL_CONFIG_FILE);
	}

	~ServerOptions ()
	{
		delete [] serverAddress;
		delete [] serverName;
		delete [] realmsFile;
		delete [] accountsFile;
		delete [] configFile;
	}
};

static void display_version ()
{
	CONSOLE.TextOutput (
		"\ax9RealmList Server\ax2, version \axf%s\ax2\n"
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
		, argv0, srvopt.configFile);
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

	srvopt->Running = true;

	string temp;

	REALMLISTSRV.Initialize(3724, "RealmList Server");
	REALMLISTSRV.Start ();

	WORLDCOMMSRV.Initialize(3725, "WorldCommunication Server");
	WORLDCOMMSRV.Start ();

	ACCOUNTS.Initialize (srvopt->accountsFile);
	REALMLIST.Initialize (srvopt->realmsFile);

	char name[512], address[512];
	int ret, icon, color;

	// Format: Realm_Name, Realm_IP, Icon (0 = Normal, 1 = PvP), Color (0 = Yellow, 1 = Red)
	REALMLISTSRV.addRealm ("Localhost server", "127.0.0.1:8129", 0, 0 );

	while ((ret = REALMLIST.getRealm (name, address, &icon, &color)))
	{
		if (ret == -1)
			continue;
		REALMLISTSRV.addRealm( name, address, icon, color );
	}

	THREADS.setCurrentPriority (Threads::TP_LOWER);

	CONSOLE.TextOutput (
		"\ax3World of Warcraft Realmlist Server v. \axf%s\axf started...\n"
		"Realm list:\n\axe", XVERSION);

	REALMLISTSRV.printRealms ();

	CONSOLE.TextOutput (
		"\ax3Realm Logging is \axf%s\ax3.\n"
		"Screen Logging is \axf%s\ax3.\n",
		NETWORK.GetRealmLogging () ? "on" : "off",
		LOG.GetScreenLogging () ? "on" : "off");

	return 0;
}

static int cmdHost (ServerOptions *srvopt, char *HostName)
{
	if (HostName)
	{
		delete [] srvopt->serverAddress;
		srvopt->serverAddress = strnew (HostName);
	}
	else
		CONSOLE.TextOutput (
			"\ax3Host name is: \axa%s\ax2\n",
			srvopt->serverAddress);
	return 0;
}

static int cmdName (ServerOptions *srvopt, char *Name)
{
	if (Name)
	{
		delete [] srvopt->serverName;
		srvopt->serverName = strnew (Name);
	}
	else
		CONSOLE.TextOutput (
			"\ax3Current realm name is: \axa%s\ax2\n",
			srvopt->serverName);
	return 0;
}

static int cmdRealms (ServerOptions *srvopt, char *FileName)
{
	if (FileName)
	{
		delete [] srvopt->realmsFile;
		srvopt->realmsFile = strnew (FileName);
	}
	else
		CONSOLE.TextOutput (
			"\ax3Current realm file is: \axa%s\ax2\n",
			srvopt->realmsFile);
	return 0;
}

static int cmdRealmList (ServerOptions *srvopt)
{
	(void)srvopt;
	REALMLISTSRV.printRealms();
	return 0;
}

static int cmdAccounts (ServerOptions *srvopt, char *FileName)
{
	if (FileName)
	{
		delete [] srvopt->accountsFile;
		srvopt->accountsFile = strnew (FileName);
	}
	else
		CONSOLE.TextOutput (
			"\ax3Current accounts file is: \axa%s\ax2\n",
			srvopt->accountsFile);
	return 0;
}

static int cmdRLog (ServerOptions *srvopt, uintptr Enable)
{
	(void)srvopt;
	if (Enable != NO_ARG)
		NETWORK.SetRealmLogging (Enable);
	else
		CONSOLE.TextOutput (
			"\ax3Realm logging is now: \axa%s\ax2\n",
			NETWORK.GetRealmLogging () ? "on" : "off");
	return 0;
}

static int cmdSLog (ServerOptions *srvopt, uintptr Enable)
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

int main (int argc, char **argv)
{
	int c;
	static struct option long_options[] = {
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
			delete [] srvopt.configFile;
			srvopt.configFile = strnew (optarg);
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
		  "Starts the server" },
		{ "stop",      0, {}, CMDFUNC (cmdQuit),
		  "Stop and shutdown server" },
		{ "quit",      0, {}, CMDFUNC (cmdQuit),
		  "Quit and shutdown server" },
		{ "exit",      0, {}, CMDFUNC (cmdQuit),
		  "Exit and shutdown server" },
		{ "ver",       0, {}, CMDFUNC (cmdVersion),
		  "Display server and expected client version" },
		{ "host",      1, { ARG_OSTR }, CMDFUNC (cmdHost),
		  "Sets Realm Server host address" },
		{ "name",      1, { ARG_OSTR }, CMDFUNC (cmdName),
		  "Sets a new Realm Server Name" },
		{ "realms",    1, { ARG_OSTR }, CMDFUNC (cmdRealms),
		  "Print the realmlist" },
		{ "realmlist", 0, {}, CMDFUNC (cmdRealmList),
		  "Set the realmlist file" },
		{ "accounts",  1, { ARG_OSTR }, CMDFUNC (cmdAccounts),
		  "Set the accounts file" },
		{ "rlog",      1, { ARG_OBOOL }, CMDFUNC (cmdRLog),
		  "Log packets sent and recv'd by the realm server" },
		{ "slog",      1, { ARG_OBOOL }, CMDFUNC (cmdSLog),
		  "Set/display screen logging (errors will still be displayed)" },
	};

	display_version ();

	CommandInterpreter (srvopt.configFile, &srvopt,
			    Commands, ARRAY_LEN (Commands),
			    "\ax1realm\ax9list\axf> \ax7");

	THREADS.setCurrentPriority (Threads::TP_LOWER);

	LOG << "Stopping realm list server..." << endl;
	REALMLISTSRV.Stop ();

	LOG << "Stopping world communication server..." << endl;
	WORLDCOMMSRV.Stop ();

	LOG << "Disconnecting clients..." << endl;
	NETWORK.disconnectAll ();

	LOG << "Halting process..." << endl;
	THREADS.closeCurrentThread ();

	return 0;
}
