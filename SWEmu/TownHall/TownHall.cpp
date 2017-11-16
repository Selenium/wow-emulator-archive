// TownHall.cpp : Defines the class behaviors for the application.
//

#include "stdafx.h"
#include "RealmServer.h"
#include "DataManager.h"
#include "Compress.h"
#include "RegionManager.h"
#include "Settings.h"
#include "EventManager.h"
#include "DBCHandler.h"
#include "antidebuggers.h"
#include "ConsoleInterface.h"
//#include "PPoint.h"

CDBCManager DBCManager;
CEventManager EventManager;
CRealmServer RealmServer;
CDataManager DataManager;
CCompress Compressor;
CRegionManager RegionManager;
CSettings Settings;
CStorage Storage;

//CPPoint PPoints;

#ifdef WIN32
CTownHallDlg *dlg;
#include "TownHall.h"
#include "TownHallDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CTownHallApp

BEGIN_MESSAGE_MAP(CTownHallApp, CWinApp)
	ON_COMMAND(ID_HELP, CWinApp::OnHelp)
END_MESSAGE_MAP()


// CTownHallApp construction

CTownHallApp::CTownHallApp()
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}


// The one and only CTownHallApp object

CTownHallApp theApp;


// CTownHallApp initialization

BOOL CTownHallApp::InitInstance()
{
	// InitCommonControls() is required on Windows XP if an application
	// manifest specifies use of ComCtl32.dll version 6 or later to enable
	// visual styles.  Otherwise, any window creation will fail.
	InitCommonControls();

	CWinApp::InitInstance();

	AfxEnableControlContainer();

	WSADATA wsa;
	if (WSAStartup(MAKEWORD(2,0),&wsa) || (HIBYTE(wsa.wVersion) != 0) || (LOBYTE(wsa.wVersion) != 2))
	{
		MessageBox(NULL,"Could not initialize Winsock, you lose!","CRITICAL ERROR - REFORMATTING C:",MB_OK);
		//return;
	}
	DETECT_DEBUG
		//CTownHallDlg dlg;
		dlg=new CTownHallDlg();
	m_pMainWnd = dlg;
	INT_PTR nResponse = dlg->DoModal();
	if (nResponse == IDOK)
	{
		// TODO: Place code here to handle when the dialog is
		//  dismissed with OK
	}
	else if (nResponse == IDCANCEL)
	{
		// TODO: Place code here to handle when the dialog is
		//  dismissed with Cancel
	}
	/* Done by CTownHallDlg::OnOK()
	RealmServer.Listener.Close();
	//RealmServer.RedirectListener.Close();
	RealmServer.RealmThread.EndThread();
	DataManager.Cleanup();
	*/
	delete dlg;
	dlg=0;
	WSACleanup();

	// Since the dialog has been closed, return FALSE so that we exit the
	//  application, rather than start the application's message pump.
	return FALSE;
}
#else
// unix
bool bshutdown=false;

void shutdownsignal(int param)
{
	bshutdown=true;
}

void hiccupsignal(int param)
{
	// this would be used to re-load config files

	signal(SIGHUP,hiccupsignal);
}

int main(int argc, char *argv[])
{
	char Command[1024];
	Command[0]=0;
	Command[1023]=0;

	RealmServer.IPAddr[0]=0;
	signal(SIGHUP,hiccupsignal);
	signal(SIGTERM,shutdownsignal);
	signal(SIGINT,shutdownsignal);
	//signal(SIGPIPE,pipesignal);
#ifndef WIN32
	time_t starttime;
	time(&starttime);
#endif
	RealmServer.Go();
#ifndef WIN32
	time_t endtime;
	time(&endtime);
	// puts("Loaded successfully");
	printf("SWemu server successfully loaded in %.2f seconds!\r\n\r\n", difftime(endtime, starttime));
	/*	printf("==========================\r\n");
	printf("SERVER INFO:\r\n");
	printf("------------\r\n");
	printf("Name: %s\r\nIP Address: %s\r\n", RealmServer.Name, RealmServer.IPAddr);
	printf("==========================\r\n");*/
#endif
	char commandbuf[256];
	putchar(7);
	CConsoleInterface cConsole;
#ifdef WIN32
	cConsole = new CConsoleInterface;
#endif
	string stufftoprint;
	while(!bshutdown)
	{
		Sleep(10);
		// command line interface
		printf("SWemu: ");
		char *command = fgets(commandbuf,sizeof(commandbuf),stdin);
		for(int x=0;true;x++)
			if(command[x]==0xd||command[x]==0xa)
			{command[x]=0;break;}

			if (strlen(command) > 2)
			{
				stufftoprint = cConsole.ParseCommand(command);
				printf(stufftoprint.c_str());
				printf("\n\n");
			}
			// ParseCommand(&printf,command);
	}
	RealmServer.Listener.Close();
	//RealmServer.RedirectListener.Close();
	RealmServer.RealmThread.EndThread();
	DataManager.Cleanup();

	return 0;
}

#endif // WIN32
