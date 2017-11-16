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

#include "Server.h"
#include "Network.h"
#include "RealmListSrv.h"
#include "RedirectorSrv.h"
#include "WorldServer.h"
#include "Log.h"
#include "Threads.h"
#include "Database.h"
#include "version.h"

#include <fstream>
using namespace std;

#if PLATFORM == PLATFORM_WIN32
#  define WIN32_LEAN_AND_MEAN
#  include <windows.h>
#endif

#define DEFAULT_LOOP_TIME 0 /* 0 millisecs - instant */

// TODO: so many globals... maybe should have a struct or class?
RedirectorSrv *mainredirector = 0, *lanredirector = 0, *devredirector = 0;
string cHost, lHost, cName;
string DBhost, DBuser, DBpass, DBdb;
// add for the limit users
int playerlimit;
int startzone;
int cinematics;
int dbfixe;

void launchWorld()
{
    string sTemp, xTemp;

    Database::getSingleton( ).Initialise( DBhost.c_str(), DBuser.c_str(), DBpass.c_str(), DBdb.c_str() );

    WorldServer::getSingleton( ).Initialise( 8140, "World Server" );
    sTemp = cHost + ":8140";

	// TODO: it's ugly, new is here and the corresponding delete in main()...
    mainredirector = new RedirectorSrv( );
	// TODO: const_cast is also ugly and can result in undefined behavior...
    mainredirector->Initialise( 9010, "Redirector Server", const_cast<char *>(sTemp.c_str())   );

    cout << "Host: " << sTemp << endl;
    cout << "Database: " << DBdb << " on " << DBuser << ":" << DBpass << "@" <<
		DBhost << endl;
    mainredirector->Start( );

    WorldServer::getSingleton( ).Start();
    Threads::getSingleton( ).setCurrentPriority( Threads::TP_LOWER );

	WorldServer::getSingleton().LoadHelp();

	cout << endl << "World of Warcraft Server v. " << XVERSION << " started..." << endl;

	cout << "Host: " << sTemp << endl;

	cout << "World Logging is "; 
	if (Network::getSingleton().IsLoggingWorld())
		cout << "on." << endl;
	else
		cout << "off." << endl;

	//Start M4rku5 Code
	cout << "Screen Logging is ";
	if (Log::getSingleton().IsLoggingScreen())
		cout << "on." << endl;
	else
		cout << "off." << endl;
	//End M4rku5 Code

	cout << "Auto Account Creation is ";
	if (Database::getSingleton().isAutoCreateAccts())
		cout << "on." << endl;
	else
		cout << "off." << endl;

	cout << "Firewall is ";
    if (Database::getSingleton().isFirewall())
		cout << "on." << endl;
	else
		cout << "off." << endl;

	cout << "Test Login/IP is ";
	if (Database::getSingleton().isTestIP())
		cout << "on." << endl;
	else
		cout << "off." << endl;
}

void launchServer(RealmListSrv *realms)
{
    string sTemp, lTemp, nTemp, oTemp, pTemp, xTemp;

    Database::getSingleton( ).Initialise( DBhost.c_str(), DBuser.c_str(), DBpass.c_str(), DBdb.c_str() );

    WorldServer::getSingleton( ).Initialise( 8129, "World Server" );

    //  RedirectorSrv mainredirector,devredirector;

	// build string
    sTemp = cHost + ":8129";

    lTemp = lHost + ":8129";

    cout << "Host: " << sTemp << endl;
    cout << "LanHost: " << lTemp << endl;
    cout << "Database: " << DBdb << " on " << DBuser << ":" << DBpass << "@" << DBhost <<
		endl;

    mainredirector = new RedirectorSrv( );
    devredirector = new RedirectorSrv( );
    lanredirector = new RedirectorSrv( );

    mainredirector->Initialise( 9003, "Redirector Server", const_cast<char *>(sTemp.c_str())   );
    devredirector->Initialise(  9004, "Redirector Server", "127.0.0.1:8129" );
    lanredirector->Initialise(  9005, "Redirector Server", const_cast<char *>(lTemp.c_str())   );

    mainredirector->Start( );
    devredirector->Start( );
    lanredirector->Start( );

    realms->Initialise(3724, "RealmList Server");
    realms->Start();

    WorldServer::getSingleton( ).Start();


    // build string
    sTemp = cHost + ":8129";

    // Lanhost fix - Torg
    lTemp = lHost + ":8129";

    nTemp = cName;
    oTemp = cName + "(localhost mode)";
    pTemp = cName + "(LAN mode)";

	// Format: Realm_Name, Realm_IP, Icon (0 = Normal, 1 = PvP), Color (0 = Yellow, 1 = Red)
    realms->addRealm( const_cast<char *>(nTemp.c_str()), const_cast<char *>(sTemp.c_str()), FvF, 0 );
    realms->addRealm( const_cast<char *>(oTemp.c_str()), "127.0.0.1:8129", FvF, 0 );
    realms->addRealm( const_cast<char *>(pTemp.c_str()), const_cast<char *>(lTemp.c_str()), FvF, 0 );
	// Change: if your Server is running in FvF Mode, its listed as PvP Server

    Threads::getSingleton( ).setCurrentPriority( Threads::TP_LOWER );

	WorldServer::getSingleton().LoadHelp();

    cout << endl << "World of Warcraft Server v. " << XVERSION << " started..." << endl;

    cout << "Host: " << sTemp;
    cout << "LanHost: " << lTemp;
	
	cout << "World Logging is "; 
	if (Network::getSingleton().IsLoggingWorld())
		cout << "on." << endl;
	else
		cout << "off." << endl;

	//Start M4rku5 Code
	cout << "Screen Logging is ";
	if (Log::getSingleton().IsLoggingScreen())
		cout << "on." << endl;
	else
		cout << "off." << endl;
	//End M4rku5 Code

	cout << "Auto Account Creation is ";
	if (Database::getSingleton().isAutoCreateAccts())
		cout << "on." << endl;
	else
		cout << "off." << endl;

	cout << "Firewall is ";
    if (Database::getSingleton().isFirewall())
		cout << "on." << endl;
	else
		cout << "off." << endl;

	cout << "Test Login/IP is ";
	if (Database::getSingleton().isTestIP())
		cout << "on." << endl;
	else
		cout << "off." << endl;

	cout << "Server Cinematics is ";
	if (!cinematics)
		cout << "on." << endl;
	else
		cout << "off." << endl;

	cout << "Server start zone set to: ";
	if (!startzone)
		cout << "Normal Race Zone" << endl;
	else
		cout << "Human Zone" << endl;
}

inline void setBlackColor()
{
#if PLATFORM == PLATFORM_WIN32
    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE),
        0);
#endif
}
inline void setGrayColor()
{
#if PLATFORM == PLATFORM_WIN32
    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE),
        FOREGROUND_INTENSITY);
#endif
}
inline void setWhiteColor()
{
#if PLATFORM == PLATFORM_WIN32
    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE),
        FOREGROUND_RED | FOREGROUND_BLUE | FOREGROUND_GREEN | FOREGROUND_INTENSITY);
#endif
}
inline void setRedColor()
{
#if PLATFORM == PLATFORM_WIN32
    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE),
        FOREGROUND_RED | FOREGROUND_INTENSITY);
#endif
}

inline void setGreenColor()
{
#if PLATFORM == PLATFORM_WIN32
    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE),
        FOREGROUND_GREEN | FOREGROUND_INTENSITY);
#endif
}

/* method to print the options menu */
void printMenu()
{

    setGrayColor();
    cout << endl << "/------------------------------------------------------------------------\\" << endl;
    cout << "|    ** Team WsD Server**     ";

	setGreenColor();
	cout << FULLVERSION;

	setGrayColor();
    cout << "    for build ";
	cout <<  EXPECTED_WOW_CLIENT_BUILD ;
	cout << " **       |" << endl;

	cout << "|";
	setWhiteColor();
    cout << "                                Commands                                ";
    setGrayColor();
	cout << "|" << endl << "|";
    setGreenColor();
    cout << " start            ";
    setGrayColor();
    cout << "starts the server                                     |" << endl;

	cout << "|";
    setGreenColor();
    cout << " host [host]      ";
    setGrayColor();
    cout << "Sets a new WAN Host                                   |" << endl;

	cout << "|";
    setGreenColor();
    cout << " lanhost [host]   ";
    setGrayColor();
    cout << "Sets a new LAN Host                                   |" << endl;

	cout << "|";
    setGreenColor();
    cout << " name [name]      ";
    setGrayColor();
    cout << "Sets a new Realm Server Name                          |" << endl;

	cout << "|";
    setGreenColor();
    cout << " db [host] [user] [pass] [database]";
    setGrayColor();
    cout << "                                     |" << endl;
	cout << "|                  ";
    cout << "Sets a new database server                            |" << endl;

	cout << "|";
    setGreenColor();
    cout << " info             ";
    setGrayColor();
    cout << "Show general server informations                      |" << endl;

	cout << "|";
    setGreenColor();
    cout << " motd             ";
    setGrayColor();
    cout << "Display the current motd                              |" << endl;

	cout << "|";
    setGreenColor();
    cout << " motd [text]      ";
    setGrayColor();
    cout << "Set the new motd (Write & for new lines)              |" << endl;

	cout << "|";
    setGreenColor();
    printf(" worldtext [text] ");
    setGrayColor();
    cout << "Send a system message to all the players in the world |" << endl;

	cout << "|";
    setGreenColor();
    cout << " help             ";
    setGrayColor();
    cout << "Show this help message                                |" << endl;

	cout << "|";
    setGreenColor();
    cout << " delay            ";
    setGrayColor();
    cout << "show and/or change console delay                      |" << endl;

	cout << "|";
    setGreenColor();
    cout << " worldstart       ";
    setGrayColor();
    cout << "start only the world server                           |" << endl;

	cout << "|";
    setGreenColor();
    cout << " wlog             ";
    setGrayColor();
    cout << "log packets sent and recv'd by the world server       |" << endl;

	cout << "|";
	//Start M4rku5 Code
    setGreenColor();
    cout << " slog             ";
    setGrayColor();
    cout << "log msgs to screen (errors will still be displayed)   |" << endl;
	//End M4rku5 Code

	cout << "|";
    setGreenColor();
    cout << " autocreate       ";
    setGrayColor();
    cout << "auto create new accounts                              |" << endl;

	//START OF LINA FIREWALL V4.1
	cout << "|";
	setGreenColor();
    cout << " fw/ban/allow/rmv ";
    setGrayColor();
    cout << "toggle on/off (def off) - ban - allow - remove - IP   |" << endl;

	cout << "|";
    setGreenColor();
    cout << " testip           ";
    setGrayColor();
    cout << "active the test login/ip for GM                       |" << endl;
	//END OF LINA FIREWALL V4.1

	cout << "|";
	setGreenColor();
	cout << " realmlist        ";
	setGrayColor();
	cout << "prints the realmlist                                  |" << endl;

	cout << "|";
	setGreenColor();
	cout << " limit [players]  ";
	setGrayColor();
	cout << "sets the player limit (default " << PLAYER_LIMIT << ")                    |"
		<< endl;

	cout << "|";
	setGreenColor();
	cout << " stzone [zoneid]  ";
	setGrayColor();
	cout << "Set the default start zone:  0-Normal (default " << SHZ << ")     |" << endl;
	cout << "|                                               1-Human                  |"
		<< endl;

	cout << "|";
	setGreenColor();
	cout << " cinematics       ";
	setGrayColor();
	cout << "Set the cinematics:          0-Off (default " << INTRO << ")        |" <<
		endl;
	cout << "|                                               1-On                     |"
		<< endl;

	cout << "|";
	setGreenColor();
	cout << " fixe             ";
	setGrayColor();
	cout << "set the server for fixe the db: 1-on  (default " << FIXE << ")     |" << endl;
	cout << "|                                                  0-off                 |"
		<< endl;


	//START OF LINA SAVE SERVER COMMAND
	cout << "|";
    setGreenColor();
    cout << " saveall          ";
    setGrayColor();
    cout << "force to save all characters                          |" << endl;
	//END OF LINA SAVE SERVER COMMAND

	//START OF LINA HELP SERVER COMMAND
	cout << "|";
    setGreenColor();
    cout << " reloadhelp       ";
    setGrayColor();
    cout << "reload help from db to server                         |" << endl;
	//END OF LINA HELP SERVER COMMAND

	cout << "|";
	setRedColor();
	cout << " exit";
	setGrayColor();
	cout << "/";
    setRedColor();
	cout << "quit";
	setGrayColor();
	cout << "/";
    setRedColor();
	cout << "stop";
    setGrayColor();
    cout << "   Quit and shutdown server                              |" << endl;
    cout << "\\------------------------------------------------------------------------/";
	cout << endl << endl;
}

/* method to clear screen */
void clearScreen()
{
#if PLATFORM == PLATFORM_WIN32
/*    COORD coordScreen = { 0, 0 };
    DWORD cCharsWritten;
    CONSOLE_SCREEN_BUFFER_INFO csbi;
    DWORD dwConSize;
    HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);

    GetConsoleScreenBufferInfo(hConsole, &csbi);
    dwConSize = csbi.dwSize.X * csbi.dwSize.Y;
    FillConsoleOutputCharacter(hConsole, TEXT(' '), dwConSize,
        coordScreen, &cCharsWritten);
    GetConsoleScreenBufferInfo(hConsole, &csbi);
    FillConsoleOutputAttribute(hConsole, csbi.wAttributes, dwConSize,
        coordScreen, &cCharsWritten);
    SetConsoleCursorPosition(hConsole, coordScreen); */

	// it isn't necessary to invoke the Windows API for such a simple thing...
	system("cls");
#endif
	// TODO: implement clearScreen for Unix
}
int main( void ) {

    uint32 dwTime; // System-clock time
    uint32 dwLoopTime; // override default loop time
    bool bRunning;	// server running?

	// TODO: remove that Hungarian notation
    dwLoopTime	=	DEFAULT_LOOP_TIME; // set real loop time to default one
    cHost		=	SERVERIP; // set the host to default host
    lHost		=	LANIP;
    cName		=	SERVERNAME;
	playerlimit =	PLAYER_LIMIT;
	startzone	=	SHZ;
	cinematics	=	INTRO;
    DBhost		=	DBHOST;
    DBuser		=	DBUSER;
    DBpass		=	DBPASS;
    DBdb		=	DBDB;
	dbfixe		=	FIXE;
    bRunning	=	false; // server is not running initially

	RealmListSrv * realms = RealmListSrv::getSingletonPtr( );

    printMenu();
	//Start M4rku5 Code
	Log::getSingleton().toggleScreenLogging();
	//End M4rku5 Code

    char data[512];

	ifstream conf("WSDServer.conf");
//	conf = fopen(,"r");
	if(!conf.is_open())
	{
        cout << "WARNING: WSDServer.conf not found - no Server config will be performed!";
		cout << endl;
	}

	// TODO: really ugly, needs to be restructured
    while(strncmp(data, "exit", 4) && strncmp(data, "quit", 4) && strncmp(data, "stop", 4))
    {

		if(conf.is_open())
		{
			if(conf.peek() != char_traits<char>::eof())
				conf.getline(data, sizeof(data));
			else
				conf.close();
		}
		else
		{
			cin.getline(data, sizeof(data));
		}

        if(!strncmp(data,"help",4))
        {
            clearScreen();
            printMenu();
        }

        else if(!(strncmp(data,"start",5)))
        {
            if(!bRunning)
            {
                launchServer(realms);
                bRunning=true;
            }
            else
            {
				cout << "Server already running." << endl;
            }
        }

        else if(!(strncmp(data,"worldstart",10)))
        {
            if(!bRunning)
            {
                launchWorld();
                bRunning=true;
            }
            else
            {
                cout << "Server already running." << endl;
            }
        }
        else if(!(strncmp(data,"host ",5)))
        {
            if( data[5] )
            {
                cHost = data+5;
                cout << "Successfully set new host to: " << cHost << endl;
            }
            else
            {
                cout << "Please supply a valid host address." << endl;
            }
		}
		else if(!(strncmp(data,"realmlist",9)))
		{
			realms->printRealms();
        }

        else if(!(strncmp(data,"name ",5)))
        {
            if( data[5] )
            {
                cName = data+5;
                cout << "Successfully set new realm server name to: " << cName << endl;
            }
            else
            {
                cout << "Please supply a valid realm server name." << endl;
            }
		}
		else if(!(strncmp(data,"realmlist",9)))
		{
			realms->printRealms();
        }

        else if(!(strncmp(data,"lanhost ",8)))
        {
            if( data[8] )
            {
                lHost = data+8;
                cout << "Successfully set new lan host to: " << lHost << endl;
            }
            else
            {
                cout << "Please supply a valid host address." << endl;
            }

        }

        else if(!(strncmp(data,"db ",3))) {
            strtok((char*)data, " ");
            char* host = strtok(NULL, " ");
            char* user = strtok(NULL, " ");
            char* pass = strtok(NULL, " ");
            char* db = strtok(NULL, " ");
            if( host ) DBhost = host;
            if( user ) DBuser = user;
            if( pass ) DBpass = pass;
            if( db )  DBdb = db;
        }


        else if(!(strncmp(data,"host",4)))
        {
            cout << "Current host set to: " << cHost << endl;
        }

        else if(!(strncmp(data,"lanhost",7)))
        {
            cout << "Current lanhost set to: " << lHost << endl;
        }

        else if(!(strncmp(data,"name",4)))
        {
            cout << "Current realm name set to: " << cName << endl;
        }

		// TODO: something ugly
        else if(!(strncmp(data, "delay ", 6)))
        {
			if(dwLoopTime = atoi(data + 6))
			{
                cout << "Console delay successfully set to: " << dwLoopTime << endl;
			}
            else
            {
                /* else, if argument for delay is not a valid number,
                give a simple error message. */
                cout << "Error setting new Console delay value." << endl;
            }

        }

        else if(!(strncmp(data,"delay",5)))
        {
            cout << "Console delay currently set to: " << dwLoopTime << endl;
        }
        else if(!strncmp(data,"worldtext ",10))
        {
            for(size_t textsize = 10; data[textsize]; textsize++)
            {
                if(data[textsize] == '&')
                    data[textsize] = '\n';
            }

			// TODO: why do we always convert char* to uint8*?
			WorldServer::getSingleton().SendWorldText(reinterpret_cast<uint8*>(data + 10));
            cout << "Message sent to all players:" << endl << "(" << data << ")" << endl;
        }
        else if(strncmp(data,"info",4)==0)
        {
            cout << "Users connected: " << 
				WorldServer::getSingleton().GetClientsConnected() << endl;
        }
        else if(strncmp(data,"motd ",5)==0)
        {
            int textsize;
            for( textsize=0; data[textsize+5]!=0; textsize++ )
            {
                if(data[textsize+5]=='&')
                    data[textsize+5]='\n';
            }
            memcpy(data,data+5,textsize);
            data[textsize]=0;
            WorldServer::getSingleton().SetMotd(data);
            cout << "New motd has been set." << endl;
        }
        else if(!strncmp(data,"motd",4))
        {
            cout << "Current message of the day is:" << endl;
			cout << WorldServer::getSingleton().GetMotd() << endl;
        }
        else if(!strncmp(data,"exit",4) || !strncmp(data,"quit",4) || !strncmp(data,"stop",4))
        {
            bRunning = false;
        }
        else if(!strncmp(data,"time",4))
        {
            cout << "Game Time is: " << WorldServer::getSingleton().updateGameTime() << endl;
        }
        else if(!strncmp(data,"wlog",4))
        {
            Network::getSingleton().toggleWorldLogging();
            cout << "World Logging is now ";
            if (Network::getSingleton().IsLoggingWorld())
                cout << "on." << endl;
            else
                cout << "off." << endl;
        }
		//Start M4rku5 Code
        else if(!strncmp(data,"slog",4))
        {
            Log::getSingleton().toggleScreenLogging();
            cout << "Screen Logging is now ";
            if (Log::getSingleton().IsLoggingScreen())
                cout << "on.";
            else
                cout << "off.";
        }
		//End M4rku5 Code
        else if(!strncmp(data,"autocreate",10))
        {
            // Toggle Auto Create Accounts
            Database::getSingleton().toggleAutoCreateAcct();
            cout << "Auto Account Creation is now ";
            if (Database::getSingleton().isAutoCreateAccts())
                cout << "on." << endl;
            else
                cout << "off." << endl;
        }
		//START OF LINA FIREWALL SERVER COMMAND
		else if(!strncmp(data,"fw",2))
        {
            Database::getSingleton().toggleFirewall();
            cout << "Firewall is now ";
            if (Database::getSingleton().isFirewall())
                cout << "on.";
            else
                cout << "off.";
        }
		else if(!strncmp(data,"ban ",4))
        {
            for(size_t textsize = 0; data[textsize]; textsize++)
            {
                if(data[textsize] == '&')
                    data[textsize] = '\n';
            }

			DatabaseInterface *dbi = Database::getSingleton().createDatabaseInterface( );
			dbi->BanIP(data + 4);
			Database::getSingleton( ).removeDatabaseInterface(dbi);
        }
		else if(!strncmp(data,"allow ",6))
        {
            for(size_t textsize = 0; data[textsize]; textsize++)
            {
                if(data[textsize] == '&')
                    data[textsize] = '\n';
            }

			DatabaseInterface *dbi = Database::getSingleton().createDatabaseInterface( );
			dbi->AllowIP(data + 6);
			Database::getSingleton( ).removeDatabaseInterface(dbi);
        }
		else if(!strncmp(data,"rmv ",4))
        {
            for(size_t textsize = 0; data[textsize]; textsize++)
            {
                if(data[textsize] == '&')
                    data[textsize] = '\n';
            }

			DatabaseInterface *dbi = Database::getSingleton().createDatabaseInterface( );
			dbi->RemoveIP(data + 4);
			Database::getSingleton( ).removeDatabaseInterface(dbi);
        }
		else if(!strncmp(data,"testip",7))
        {
            Database::getSingleton().toggleTestIP();
            cout << "Test Login/IP is now ";
            if (Database::getSingleton().isTestIP())
                cout << "on." << endl;
            else
                cout << "off." << endl;
        }

		//END OF LINA FIREWALL SERVER COMMAND

		//START OF LINA SAVE SERVER COMMAND
		else if(!strncmp(data,"saveall",7))
        {
			if(!WorldServer::getSingleton().GetClientsConnected())
				cout << "No Characters to save." << endl;
			else
				cout << "Characters saved: " << WorldServer::getSingleton().Save("Server")
					<< "/" <<WorldServer::getSingleton().GetClientsConnected() << endl;
        }
		//END OF LINA SAVE SERVER COMMAND
		//START OF LINA RELOAD HELP SERVER COMMAND
		else if(!strncmp(data,"reloadhelp",10))
        {
			WorldServer::getSingleton().LoadHelp();
			cout << "Help reloaded" << endl;
		}
		//END OF LINA RELOAD HELP SERVER COMMAND

		else if(!strncmp(data,"sm ",3))
        {
			char* pGuid = strtok((char*)data, " ");
			uint32 Guid=(uint32)atoi(pGuid);

			Character * pChar = WorldServer::getSingleton().GetCharacter(Guid);
			if(pChar)
			{
				char* pOpcode = strtok(NULL, " ");
				uint32 Opcode=(uint32)atoi(pOpcode);

				char* pLength = strtok(NULL, " ");
				uint32 Length=(uint32)atoi(pLength);

				char* pData = strtok(NULL, " ");

				wowWData packets;
				packets.Initialise(Length, Opcode);
				packets << pData;
				pChar->pClient->SendMsg( &packets );
			}
			else
				cout << "Unable to find Client with CharGuid: " << Guid << endl;
		}
		
		else if(!(strncmp(data, "fixe ", 5)))
		{
			if(data[5])
			{
				if(dbfixe = atoi(data + 5))
				{
					cout << "the server will do the db fixe" << endl;
				}
				else
				{
					cout << "no db fixe this time";
				}
			}
		}

		else if(!(strncmp(data,"fixe",4)))
		{
			if(dbfixe)
			{
				cout << "the server is set up for the db Fixe" << endl;
			}
			else
			{
				cout << "no db fixe this time" << endl;
			}
		}

		else if(!(strncmp(data, "cinematics ", 11)))
		{
			if(data[11])
			{
				cinematics = atoi(data + 11);
				cout << "Succesfully set the Cinematics ";
				if (!cinematics)
				{
					cout << "off." << endl;
				}
				else
				{
					cout << "on." << endl;
				}
			}
		}
		else if(!(strncmp(data, "cinematics", 10)))
		{
			cout << "Server Cinematics are ";
			if(!cinematics)
			{
				cout << "off." << endl;
			}
			else
			{
				cout << "on." << endl;
			}
		}
		else if(!(strncmp(data, "stzone ", 7)))
		{
			if(data[6])
			{
				startzone = atoi(data + 6);
				cout << "Succesfully set the Start zone to: " << startzone << "endl";
			}
		}
		else if(!(strncmp(data, "stzone", 6)))
		{
			cout << "Server start zone Set to: ";
			if (startzone == 0)
			{
				cout << "Normal Race Zone" << endl;
			}
			if (startzone == 1)
			{
				cout << "Human Zone" << endl;
			}	
		}
		else if(!(strncmp(data,"limit ",6)))
        {
            if(data[6])
            {
                playerlimit = atoi(data + 6);
                cout << "Successfully set new player limit to: " << playerlimit << endl;
            }
        }

        else if(!(strncmp(data,"limit",5)))
        {
            cout << "Server limit currently set to: " << playerlimit << endl;
        }
        else
            cout << "Unknown command (Type 'help' for a list of commands)" << endl;


        if(dwLoopTime)
        {
            dwTime = clock() * 1000 / CLOCKS_PER_SEC; // get current time
            while((clock() * 1000 / CLOCKS_PER_SEC - dwTime) < dwLoopTime); // 'idle' for dwLoopTime ms
        }
    }

    Threads::getSingleton( ).setCurrentPriority( Threads::TP_LOWER );

    Log::getSingleton( ) << "Stopping realm list server..." << endl;
    RealmListSrv::getSingleton( ).Stop( );

    if( mainredirector ) {
        Log::getSingleton( ) << "Stopping public redirector server..." << endl;
        mainredirector->Stop( );
        delete mainredirector; mainredirector = 0;
    }

    if( devredirector ) {
        Log::getSingleton( ) << "Stopping developer redirector server..." << endl;
        devredirector->Stop( );
        delete devredirector; devredirector = 0;
    }

    if( lanredirector ) {
        Log::getSingleton( ) << "Stopping LAN redirector server..." << endl;
        lanredirector->Stop( );
        delete lanredirector; lanredirector = 0;
    }

    Log::getSingleton( ) << "Stopping world server..." << endl;
    WorldServer::getSingleton( ).Stop( );

    Log::getSingleton( ) << "Disconnecting clients..." << endl;
    Network::getSingleton( ).disconnectAll( );

    Log::getSingleton( ) << "Halting process..." << endl;
    Threads::getSingleton( ).closeCurrentThread( );
    return 0;
}

