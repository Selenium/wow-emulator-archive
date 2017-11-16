// Realm List Server.cpp : Defines the class behaviors for the application.
//

#include "stdafx.h"
#include "RealmListServer.h"

#ifdef WIN32
#include "Realm List Server.h"
#include "Realm List ServerDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CRealmListServerApp

BEGIN_MESSAGE_MAP(CRealmListServerApp, CWinApp)
	ON_COMMAND(ID_HELP, CWinApp::OnHelp)
END_MESSAGE_MAP()


// CRealmListServerApp construction

CRealmListServerApp::CRealmListServerApp()
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}


// The one and only CRealmListServerApp object

CRealmListServerApp theApp;


// CRealmListServerApp initialization

BOOL CRealmListServerApp::InitInstance()
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
	{
		CRealmListServer Server;
		CRealmListServerDlg dlg;
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
	}
	WSACleanup();

	// Since the dialog has been closed, return FALSE so that we exit the
	//  application, rather than start the application's message pump.
	return FALSE;
}
#else
// unix daemon
#include <signal.h>
#include "RealmListServer.h"
bool bshutdown=false;

void shutdownsignal(int param)
{
	bshutdown=true;
}

void hiccupsignal(int param)
{
	// this would be used to re-load config files
}

void ServerLog(char *format,...)
{
        // do nothing under linux at this time
}

int main(int argc, char *argv[])
{
	char Command[1024];
	Command[0]=0;
	Command[1023]=0;

	CRealmListServer RealmListServer;
	
	signal(SIGHUP,hiccupsignal);
	signal(SIGTERM,shutdownsignal);
	signal(SIGINT,shutdownsignal);
	while(!bshutdown)
	{
		Sleep(10);
	}
	return 0;
}
#endif
