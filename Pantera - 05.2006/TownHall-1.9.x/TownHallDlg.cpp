// TownHallDlg.cpp : implementation file
//
#ifdef WIN32
#include "stdafx.h"
#include "TownHall.h"
#include "TownHallDlg.h"
#include "TCPSocket.h"
#include "Globals.h"
#include "SendPDlg.h"
#include "SendMail.h"
#include "ConsoleDlg.h"
#include "Player.h"
#ifdef _DEBUG
#define new DEBUG_NEW
#endif
HBITMAP m_hBitmap;
BITMAP m_Bitmap;
// CAboutDlg dialog used for App About
CConsoleDlg *Btn_ConsoleDlg;

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

	// Dialog Data
	enum { IDD = IDD_ABOUTBOX };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	// Implementation
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
}
void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}
BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
END_MESSAGE_MAP()

CTownHallDlg::CTownHallDlg(CWnd* pParent /*=NULL*/)
: CDialog(CTownHallDlg::IDD, pParent)
, Txt_ServerName()
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CTownHallDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_TEXT_SERVER_NAME, Txt_ServerName);
	DDX_Control(pDX, IDC_TEXT_RL_STATUS, Txt_RLStatus);
	DDX_Control(pDX, IDC_TEXT_STATUS, Txt_Status);
	DDX_Control(pDX, IDC_TEXT_CLIENT_NUM, Txt_Clients);
	DDX_Control(pDX, IDC_LOADPROGRESS, Ctl_Progress);
	DDX_Control(pDX, IDC_BUTTON_SENDMAIL, Btn_SendMail);
	DDX_Control(pDX, IDC_STATIC_RL_STATUS, Static_RLStatus);
	DDX_Control(pDX, IDC_STATIC_STATUS, Static_Status);
	DDX_Control(pDX, IDC_STATIC_CLIENT_NUM, Static_Clients);
	DDX_Control(pDX, IDC_STATIC_SERVER_NAME, Static_ServerName);
	DDX_Control(pDX, IDC_BUTTON_EXIT, Btn_Exit);
	DDX_Control(pDX, IDC_BUTTON_SENDPACKET, Btn_SendPacketDlg);
	DDX_Control(pDX, IDC_BUTTON_REHASH, Btn_Reload);
	DDX_Control(pDX, IDC_BUTTON_MINIMIZE, Btn_Minimize);
	DDX_Control(pDX, IDC_BUTTON_STARTSTOP, Btn_StartButton);
	DDX_Control(pDX, IDC_BUTTON_SAVE, Btn_Save);
	DDX_Control(pDX, IDC_BUTTON_CONSOLE, Btn_Console);
}

BEGIN_MESSAGE_MAP(CTownHallDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_WM_LBUTTONDOWN()
	//}}AFX_MSG_MAP
	ON_COMMAND(IDC_BUTTON_SENDPACKET, OnBnClickedSendP)
	ON_COMMAND(IDC_BUTTON_SENDMAIL, OnBnClickedMail)
	ON_COMMAND(IDC_BUTTON_REHASH, OnBnClickedRehash)
	ON_COMMAND(IDC_BUTTON_MINIMIZE, OnBnClickedMinimize)
	ON_COMMAND(IDC_BUTTON_STARTSTOP, OnBnClickedStartStop)
	ON_COMMAND(IDC_BUTTON_SAVE, OnBnClickedSave)
	ON_COMMAND(IDC_BUTTON_CONSOLE, OnBnClickedConsole)
	ON_COMMAND(IDC_BUTTON_EXIT, OnOK)
	ON_COMMAND(ID_SERVERPOPUP_SHOWSERVERWINDOW, OnServerPopupShowServerWindow)
	ON_COMMAND(ID_SERVERPOPUP_VIEWLOGFILE, OnServerPopupViewLogFile)
	ON_COMMAND(ID_SERVERPOPUP_VIEWPACKETLOGS, OnServerPopupViewPacketLogs)
	ON_COMMAND(ID_SERVERPOPUP_VIEWREPORTLOG, OnServerPopupViewReportLog)
	ON_COMMAND(ID_SERVERPOPUP_VIEWCHATCOMMANDLOG, OnServerPopupViewChatCommandLog)
	ON_COMMAND(ID_SERVERPOPUP_RELOADCONFIG, OnServerPopupReloadConfig)
	ON_COMMAND(ID_SERVERPOPUP_SAVEALLCLIENTS, OnServerPopupSaveAll)
	ON_COMMAND(ID_SERVERPOPUP_DISCONNECTALLPLAYERS, OnServerPopupDisconnectAll)
	ON_COMMAND(ID_SERVERPOPUP_STARTSERVER, OnServerPopupStartServer)
	ON_COMMAND(ID_SERVERPOPUP_SHUTDOWNSERVER, OnServerPopupShutDownServer)
	ON_COMMAND(ID_SERVERPOPUP_EXITTOWNHALL, OnServerPopupExitTownHall)
	ON_COMMAND(ID_SERVERPOPUP_NUMBEROFCONNECTEDCLIENTS, OnServerPopupNumberOfConnectedClients)
	ON_COMMAND(ID_SERVERPOPUP_SENDPACKET, OnServerPopupSendPacket)
	ON_COMMAND(ID_SERVERPOPUP_SENDMAILMESSAGE, OnServerPopupSendMail)
END_MESSAGE_MAP()


// CTownHallDlg message handlers

BOOL CTownHallDlg::OnInitDialog()
{
	CDialog::OnInitDialog();
	//Btn_Exit.LoadBitmaps(IDB_BITMAP_EXIT_NORMAL,IDB_BITMAP_EXIT_PRESSED,0,IDB_BITMAP_EXIT_DISABLED);
	Btn_Exit.SetBitmaps(IDB_BITMAP_EXIT_NORMAL,IDB_BITMAP_EXIT_OVER,IDB_BITMAP_EXIT_PRESSED,IDB_BITMAP_EXIT_DISABLED);
	Btn_StartButton.SetBitmaps(IDB_BITMAP_START_NORMAL,IDB_BITMAP_START_OVER,IDB_BITMAP_START_PRESSED,IDB_BITMAP_START_DISABLED);
	Btn_Save.SetBitmaps(IDB_BITMAP_SAVE_NORMAL,IDB_BITMAP_SAVE_OVER,IDB_BITMAP_SAVE_PRESSED,IDB_BITMAP_SAVE_DISABLED);
	Btn_SendPacketDlg.SetBitmaps(IDB_BITMAP_SENDPKT_NORMAL,IDB_BITMAP_SENDPKT_OVER,IDB_BITMAP_SENDPKT_PRESSED,IDB_BITMAP_SENDPKT_DISABLED);
	Btn_SendMail.SetBitmaps(IDB_BITMAP_SENDMAIL_NORMAL,IDB_BITMAP_SENDMAIL_OVER,IDB_BITMAP_SENDMAIL_PRESSED,IDB_BITMAP_SENDMAIL_DISABLED);
	Btn_Minimize.SetBitmaps(IDB_BITMAP_MINIMIZE_NORMAL,IDB_BITMAP_MINIMIZE_OVER,IDB_BITMAP_MINIMIZE_PRESSED,IDB_BITMAP_MINIMIZE_DISABLED);
	Btn_Reload.SetBitmaps(IDB_BITMAP_RELOAD_NORMAL,IDB_BITMAP_RELOAD_OVER,IDB_BITMAP_RELOAD_PRESSED,IDB_BITMAP_RELOAD_DISABLED);
	Btn_Console.SetBitmaps(IDB_BITMAP_CONSOLE_NORMAL,IDB_BITMAP_CONSOLE_OVER,IDB_BITMAP_CONSOLE_PRESSED,IDB_BITMAP_CONSOLE_DISABLED);
	Btn_ConsoleDlg = new CConsoleDlg;
	Btn_ConsoleDlg->Create(IDD_CONSOLEDIALOG);
	// Btn_Console.EnableWindow(false);
	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}
	SetWindowText("Pantera Emulator");
	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
	m_TrayIcon.Create(NULL,WM_APP+10,_T("Pantera Realm Server"),m_hIcon,IDR_MENU,FALSE,0,0,0,10);
	Txt_ServerName.SetWindowText("Pantera Server");
	rs_started=FALSE;
	m_hBitmap = (HBITMAP)LoadImage(GetModuleHandle(NULL), "Data\\Design.bin", IMAGE_BITMAP, 0, 0, LR_LOADFROMFILE);
	if (m_hBitmap == NULL)
	{
		MessageBox("Error loading Design.bin");
	}
	GetObject(m_hBitmap, sizeof(m_Bitmap), &m_Bitmap);	// Get info about the bitmap
	return TRUE;  // return TRUE  unless you set the focus to a control
}
void CTownHallDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CTownHallDlg::OnPaint()
{
	CPaintDC dc(this);
	CBitmap *bmp=CBitmap::FromHandle(m_hBitmap);
	CDC bmDC;
	bmDC.CreateCompatibleDC(&dc);
	CBitmap *pOldbmp = bmDC.SelectObject(bmp);
	dc.BitBlt(0, 0, m_Bitmap.bmWidth, m_Bitmap.bmHeight, &bmDC, 0, 0, SRCCOPY);
	bmDC.SelectObject(pOldbmp);
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CTownHallDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

void CTownHallDlg::OnBnClickedStartStop()
{
	Ctl_Progress.SetRange(1,100);
	Ctl_Progress.SetStep(1);
	if(!rs_started)
	{
		time_t starttime;
		time(&starttime);
		if (!IsWindowVisible())
			m_TrayIcon.MaximiseFromTray(this);
		CWaitCursor wait;
		m_TrayIcon.ShowBalloon(_T("Realm server is loading..."),_T(BALLOONPOPUPTITLE),NIIF_INFO,10);
		Btn_StartButton.EnableWindow(false);
		Txt_Status.SetWindowText("Loading...");
		RealmServer.Go();
		time_t endtime;
		time(&endtime);
		wait.Restore();
		char balloontext[200];
		m_TrayIcon.MinimiseToTray(this, TRUE);
		sprintf(balloontext,"%s started in %.0f seconds on %s. Server window has been minimised, double click this icon to show it again.",RealmServer.Name,difftime(endtime,starttime),RealmServer.IPAddr);
		m_TrayIcon.ShowBalloon(_T(balloontext),_T(BALLOONPOPUPTITLE), NIIF_INFO,10);
	}
	else
	{
		m_TrayIcon.ShowBalloon(_T("Server stopping..."),_T(BALLOONPOPUPTITLE),NIIF_INFO,10);
		Btn_SendMail.EnableWindow(false);
		Btn_Save.EnableWindow(false);
		Btn_SendPacketDlg.EnableWindow(false);

		RealmServer.Listener.Close();
		//RealmServer.RedirectListener.Close();
		//RealmServer.LoginListener.Close();
		RealmServer.MasterLists.Cleanup();
		RealmServer.MasterList.ShutDown();
		RealmServer.RealmThread.EndThread();
		DataManager.Cleanup();
		//WSACleanup();
		Btn_StartButton.SetBitmaps(IDB_BITMAP_START_NORMAL,IDB_BITMAP_START_OVER,IDB_BITMAP_START_PRESSED,IDB_BITMAP_START_DISABLED);
		Btn_StartButton.SetWindowText("&Start");
		Txt_Status.SetWindowText("Not Running");
		Txt_RLStatus.SetWindowText("Not Connected");
		Txt_Clients.SetWindowText("Not Running");
		rs_started=FALSE;
		m_TrayIcon.ShowBalloon(_T("Server shut down."),_T(BALLOONPOPUPTITLE),NIIF_INFO,10);
	}
}

void CTownHallDlg::OnBnClickedSendP()
{
	CSendPDlg dlgSendP;
	dlgSendP.DoModal();
}

void CTownHallDlg::OnBnClickedSave()
{
	CLock L(&RealmServer.Clients.CS);// exclusive lock on clients for this, not guaranteed to be in the realm server thread
	for (unsigned long i = 0 ; i < RealmServer.Clients.Size ; i++)
	{
		if (CClient *pClient=RealmServer.Clients[i]) pClient->pAccount->Save();
	}
}

void CTownHallDlg::OnBnClickedRehash()
{
	RealmServer.MasterLists.Cleanup();
	RealmServer.MasterLists.Resize(0);
	Settings.LoadSettings();
	RealmServer.UpdateMasterLists(0);
	if(dlg) dlg->Txt_ServerName.SetWindowText(RealmServer.Name);
	m_TrayIcon.ShowBalloon(_T("Config file reloaded."),_T(BALLOONPOPUPTITLE),NIIF_INFO,10);
}


void CTownHallDlg::OnServerPopupShutDownServer()
{
	if(rs_started) OnBnClickedStartStop();
}

void CTownHallDlg::OnServerPopupExitTownHall()
{
	m_TrayIcon.RemoveIcon();
	if(rs_started) OnBnClickedStartStop();
	OnOK();
}

void CTownHallDlg::OnBnClickedMinimize()
{
	m_TrayIcon.MinimiseToTray(this,TRUE);
	m_TrayIcon.ShowBalloon(_T("Server has been minimised to the tray. Double-click this icon to show the main window again."),_T(BALLOONPOPUPTITLE),NIIF_INFO,10);
}

void CTownHallDlg::OnServerPopupShowServerWindow()
{
	if (!IsWindowVisible())
		m_TrayIcon.MaximiseFromTray(this,TRUE);
	else
	{
		m_TrayIcon.MinimiseToTray(this,TRUE);
		m_TrayIcon.ShowBalloon(_T("Dialog window has been minimised, double click on this icon to return it to it's previous state."),_T(BALLOONPOPUPTITLE),NIIF_INFO,10);
	}
}

void CTownHallDlg::OnServerPopupViewLogFile()
{

	if(!_FileExists("CDebug.txt"))
		m_TrayIcon.ShowBalloon(_T("Log file not found!"),_T(BALLOONPOPUPTITLE),NIIF_ERROR,10);
	else
		system("start CDebug.txt");
}

void CTownHallDlg::OnServerPopupViewPacketLogs()
{

	if(!_FileExists("pktlog.txt"))
		m_TrayIcon.ShowBalloon(_T("Packetlog file not found!"),_T(BALLOONPOPUPTITLE),NIIF_ERROR,10);
	else
		system("start pktlog.txt");
}

void CTownHallDlg::OnServerPopupViewReportLog()
{
	if(!_FileExists("data/report.log"))
		m_TrayIcon.ShowBalloon(_T("No reports yet."),_T(BALLOONPOPUPTITLE),NIIF_INFO,10);
	else
		system("start write data/report.log");
}

void CTownHallDlg::OnServerPopupViewChatCommandLog()
{
	if(!_FileExists("data/chatcmd.log"))
		m_TrayIcon.ShowBalloon(_T("Chat command log not found."),_T(BALLOONPOPUPTITLE),NIIF_ERROR,10);
	else
		system("start write data/chatcmd.log");
}


void CTownHallDlg::OnServerPopupReloadConfig()
{
	OnBnClickedRehash();
}

void CTownHallDlg::OnServerPopupSaveAll()
{
	if(!rs_started)
		m_TrayIcon.ShowBalloon(_T("ERROR: Server is not running!"),_T(BALLOONPOPUPTITLE),NIIF_ERROR,10);
	else
	{
		CLock L(&RealmServer.Clients.CS);// exclusive lock on clients for this, not guaranteed to be in the realm server thread
		for (unsigned long i = 0 ; i < RealmServer.Clients.Size ; i++)
		{
			if (CClient *pClient=RealmServer.Clients[i]) pClient->pAccount->Save();
		}
		m_TrayIcon.ShowBalloon(_T("All players saved."),_T(BALLOONPOPUPTITLE),NIIF_INFO,10);
	}
}

void CTownHallDlg::OnServerPopupDisconnectAll()
{
	if(!rs_started)
		m_TrayIcon.ShowBalloon(_T("ERROR: Server is not running!"),_T(BALLOONPOPUPTITLE),NIIF_ERROR,10);
	else
	{
		m_TrayIcon.ShowBalloon(_T("Players are being disconnected..."),_T(BALLOONPOPUPTITLE),NIIF_WARNING,10);
		for (unsigned long i = 0 ; i < RealmServer.Clients.Size ; i++)
		{
			if (CClient *pClient=RealmServer.Clients[i])
			{
				pClient->DestroyMe=true; //pop goes the weasel.
			}
		}
	}
}

void CTownHallDlg::OnServerPopupNumberOfConnectedClients()
{
	if(!rs_started)
		m_TrayIcon.ShowBalloon(_T("ERROR: Server is not running!"),_T(BALLOONPOPUPTITLE),NIIF_ERROR,10);
	else
	{
		char playerstext[100];
		sprintf(playerstext,"There are currently %d player%s on this realm server.",RealmServer.nClients,(RealmServer.nClients==1)?"":"s");
		m_TrayIcon.ShowBalloon(_T(playerstext),_T(BALLOONPOPUPTITLE),NIIF_INFO,10);
	}
}

void CTownHallDlg::OnServerPopupStartServer()
{
	OnBnClickedStartStop();
}

void CTownHallDlg::OnServerPopupSendPacket()
{
	CSendPDlg dlgSendP;
	dlgSendP.DoModal();
}

void CTownHallDlg::OnBnClickedMail()
{
	CSendMail dlgSendMail;
	dlgSendMail.DoModal();
}

void CTownHallDlg::OnServerPopupSendMail()
{
	OnBnClickedMail();
}

void CTownHallDlg::OnLButtonDown(UINT nFlags, CPoint point)
{
	CDialog::OnLButtonDown(nFlags, point);
	PostMessage(
		WM_NCLBUTTONDOWN,
		HTCAPTION,
		MAKELPARAM( point.x, point.y ) );
}

void CTownHallDlg::OnBnClickedConsole()
{
	// CConsoleDlg dlgConsole;
	// dlgConsole.DoModal();

	Btn_ConsoleDlg->ShowWindow(1);
	Btn_ConsoleDlg->Txt_Command.SetFocus();
}

void CTownHallDlg::LogText(char *message)
{
	// if (Btn_ConsoleDlg)
	Btn_ConsoleDlg->LogText(message);
	Btn_ConsoleDlg->LogText("\r\n");
	/*
	if (Txt_Display)
	{
	int nSize = Txt_Display.GetWindowTextLength();
	Txt_Display.SetSel(nSize, nSize);
	Txt_Display.ReplaceSel(_T(message));
	}*/
	return;
}
// NO CODE BEYOND THIS POINT EXCEPT #endif FOR LINUX COMPATIBILITY
#endif // WIN32
