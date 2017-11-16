// WoWLogin.cpp : Defines the class behaviors for the application.
//

#include "stdafx.h"
#include "WoWLogin.h"
#include "WoWLoginDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CWoWLoginApp

BEGIN_MESSAGE_MAP(CWoWLoginApp, CWinApp)
	ON_COMMAND(ID_HELP, CWinApp::OnHelp)
END_MESSAGE_MAP()


// CWoWLoginApp construction

CWoWLoginApp::CWoWLoginApp()
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}


// The one and only CWoWLoginApp object

CWoWLoginApp theApp;


// CWoWLoginApp initialization

BOOL CWoWLoginApp::InitInstance()
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

	CWoWLoginDlg dlg;
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

	WSACleanup();
	// Since the dialog has been closed, return FALSE so that we exit the
	//  application, rather than start the application's message pump.
	return FALSE;
}
