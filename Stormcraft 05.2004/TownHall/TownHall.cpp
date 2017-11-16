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
//		return;
	}
	CTownHallDlg dlg;
	m_pMainWnd = &dlg;
	INT_PTR nResponse = dlg.DoModal();
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

	RealmServer.Listener.Close();
	RealmServer.RedirectListener.Close();
	RealmServer.RealmThread.EndThread();
	DataManager.Cleanup();
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

//		Addr *MainList=new Addr;
//		memset(MainList,0,sizeof(Addr));
//		MainList->sa_family=2;
//	    MainList->IP=inet_addr("192.168.1.69");// private internal lan
	//	MainList->IP=inet_addr("62.65.143.232"); // private stormcraft (TODO: gethostbyname realmlist.alita.cc)
	//	MainList->IP=inet_addr("213.114.164.23");//private stormcraft
//		MainList->IP=inet_addr("66.208.106.16");//public
//		MainList->Port=htons(9111);
//		RealmServer.MasterLists+=MainList;
//	strcpy(RealmServer.IPAddr,"0");
	RealmServer.IPAddr[0]=0;
	strcpy(RealmServer.Name,"StormCraft Town Hall *nix");
        signal(SIGHUP,hiccupsignal);
        signal(SIGTERM,shutdownsignal);
        signal(SIGINT,shutdownsignal);
//		signal(SIGPIPE,pipesignal);
	RealmServer.Go();
        while(!bshutdown)
        {
                Sleep(10);
        }
        RealmServer.Listener.Close();
        RealmServer.RedirectListener.Close();
        RealmServer.RealmThread.EndThread();
		DataManager.Cleanup();

        return 0;
}


#endif
