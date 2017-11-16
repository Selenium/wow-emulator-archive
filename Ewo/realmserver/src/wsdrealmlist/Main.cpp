#include "Server.h"
#include "Network.h"
#include "RealmListSrv.h"
#include "Log.h"
#include "Threads.h"
#include "Console.h"
#include "SystemFun.h"
//#include "StringFun.h"
#include "CommandInterpreter.h"
#include "getopt.h"
#include "version.h"
#include <time.h>

#include <fstream>
using namespace std;

#if PLATFORM == PLATFORM_WIN32
#  define WIN32_LEAN_AND_MEAN
#  include <windows.h>
#endif

struct ServerOptions
{
   uint8 Running;
   char *serverAddress;
   char *serverName;
   char *configFile;
   char *DBhost, *DBuser, *DBpass, *DBdb;
   uint32 last_realm_refresh;

   ServerOptions ()
   {
      Running = false;
      serverAddress = strnew (SERVERIP);
      serverName = strnew (SERVERNAME);
      configFile = strnew (RL_CONFIG_FILE);
      DBhost = strnew (DBHOST);
      DBuser = strnew (DBUSER);
      DBpass = strnew (DBPASS);
      DBdb = strnew (DBDB);
      last_realm_refresh=0;
   }

   ~ServerOptions ()
   {
      delete [] serverAddress;
      delete [] serverName;
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

static int cmdrefresh_realms_from_db (ServerOptions *srvopt)
{
   //check if it is time to refresh the realmlist
   uint32 cur_time=time(NULL);
   uint32 last_time=srvopt->last_realm_refresh;
   uint32 diff_time=cur_time-last_time;
   if(diff_time<REALM_REFRESH_INTERVAL)   
      return 0;
   srvopt->last_realm_refresh=cur_time;
   CONSOLE.TextOutput ("Refreshing realm list\n");
   //dump the old realmlist if exists and refresh it with a new one
   REALMLISTSRV.refresh_realm_list();
   return 0;
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

   srvopt->Running = 1;

   string temp;
   DATABASE.Initialize_r (srvopt->DBhost,
                     srvopt->DBuser,
                     srvopt->DBpass,
                     srvopt->DBdb);

   REALMLISTSRV.Initialize(REALMLIST_SERVER_CLIENT_PORT, "RealmList Server");
   REALMLISTSRV.Start ();

   //a list will be created for realms
   cmdrefresh_realms_from_db(srvopt);
   THREADS.setCurrentPriority (Threads::TP_LOWER);

   CONSOLE.TextOutput (
      "\ax3World of Warcraft Realmlist Server v. \axf%s\axf started...\n"
      "Realm list:\n\axe", VERSION);

   REALMLISTSRV.printRealms ();

   CONSOLE.TextOutput (
      "\ax3Realm Logging is \axf%s\ax3.\n"
      "Screen Logging is \axf%s\ax3.\n",
      NETWORK.GetRealmLogging () ? "on" : "off",
      LOG.GetScreenLogging () ? "on" : "off");

   return 0;
}

static void cmdout_text (const char *argv0,ServerOptions *srvopt)
{
   CONSOLE.TextOutput ("\ax3 %s \axa%s\ax2\n",argv0);
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

static int cmdRealmList (ServerOptions *srvopt)
{
   (void)srvopt;
   REALMLISTSRV.printRealms();
   return 0;
}

static int cmdRLog (ServerOptions *srvopt, uintptr Enable)
{
   (void)srvopt;
   if (Enable != NO_ARG)
      NETWORK.SetRealmLogging ((uint8)Enable);
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
      LOG.SetScreenLogging ((uint8)Enable);
   else
      CONSOLE.TextOutput (
         "\ax3Screen logging is now: \axa%s\ax2\n",
         LOG.GetScreenLogging () ? "on" : "off");
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
   CONSOLE.TextOutput (
         "\ax3Current database is: \axa%s\ax2 \axa%s\ax2:\axa%s\ax2 \axa%s\ax2\n",
         srvopt->DBhost, srvopt->DBuser,
         srvopt->DBpass, srvopt->DBdb);
   return 0;
}

static int cmdsetoffline(ServerOptions *srvopt)
{
	REALMLISTSRV.force_players_in_offline_state();	
    CONSOLE.TextOutput ("\ax2All players have been set to offline state\n");
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

#ifdef DEBUG_VERSION
	FILE *pFile;
	pFile = fopen("realmlog.txt", "w");
#endif

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
      { "start",     0, {}, CMDFUNC (cmdStart), "Starts the server" },
      { "stop",      0, {}, CMDFUNC (cmdQuit),  "Stop and shutdown server" },
      { "quit",      0, {}, CMDFUNC (cmdQuit),  "Quit and shutdown server" },
      { "exit",      0, {}, CMDFUNC (cmdQuit),  "Exit and shutdown server" },
      { "ver",       0, {}, CMDFUNC (cmdVersion),     "Display server and expected client version" },
      { "host",      1, { ARG_OSTR }, CMDFUNC (cmdHost),  "Sets Realm Server host address" },
      { "name",      1, { ARG_OSTR }, CMDFUNC (cmdName),  "Sets a new Realm Server Name" },
      { "refresh",    0, {}, CMDFUNC (cmdrefresh_realms_from_db),  "Refresh realms from database (flood control)" },
      { "realms",      0, {}, CMDFUNC (cmdRealmList),  "Print the realmlist" },
      { "setoffline",      0, {}, CMDFUNC (cmdsetoffline),  "This will set all players in an offline state(not kick them)" },
      { "rlog",      1, { ARG_OINT }, CMDFUNC (cmdRLog),  "Log packets sent and recv'd by the realm server" },
      { "slog",      1, { ARG_OINT }, CMDFUNC (cmdSLog), "Set/display screen logging (errors will still be displayed)" },
      { "db",        4, { ARG_OSTR, ARG_STR, ARG_STR, ARG_STR }, CMDFUNC (cmdDB),  "Set the database host/user/password/database" },
   };

   display_version ();

   CommandInterpreter (srvopt.configFile, &srvopt,
             Commands, ARRAY_LEN (Commands),
             "\ax1realm\ax9list\axf> \ax7");

   THREADS.setCurrentPriority (Threads::TP_LOWER);

   LOG << "Stopping realm list server..." << endl;
   REALMLISTSRV.Stop ();

//   LOG << "Stopping world communication server..." << endl;
//   WORLDCOMMSRV.Stop ();

   LOG << "Disconnecting clients..." << endl;
   NETWORK.disconnectAll ();

   LOG << "Halting process..." << endl;
   THREADS.closeCurrentThread ();

   return 0;
}
