// Realm List ServerDlg.cpp : implementation file
//

#ifdef WIN32
#include "stdafx.h"
#include "Realm List Server.h"
#include "Realm List ServerDlg.h"
#include "Accounts.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

CRealmListServerDlg *dlg;

// CAboutDlg dialog used for App About

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


// CRealmListServerDlg dialog



CRealmListServerDlg::CRealmListServerDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CRealmListServerDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CRealmListServerDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_CONNECTED, m_Connected);
	DDX_Control(pDX, IDC_USERNAME, m_UserName);
	DDX_Control(pDX, IDC_PASSWORD, m_Password);
}

BEGIN_MESSAGE_MAP(CRealmListServerDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_BN_CLICKED(IDOK, OnBnClickedOk)
	ON_BN_CLICKED(IDC_ADDACCT, OnBnClickedAddAcct)
	ON_COMMAND(ID_POPUP_SHOWMAINWINDOW, OnPopupShowMainWindow)
	ON_COMMAND(ID_POPUP_STARTREALMSERVER, OnPopupStartRealmServer)
	ON_COMMAND(ID_POPUP_SHUTDOWNREALMSERVER, OnPopupShutdownRealmServer)
	ON_COMMAND(ID_POPUP_SHUTDOWNREALMLISTSERVER, OnPopupShutdownRealmListServer)
	ON_BN_CLICKED(IDC_MINIMIZE, OnBnClickedMinimize)
END_MESSAGE_MAP()


// CRealmListServerDlg message handlers

BOOL CRealmListServerDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

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

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	m_TrayIcon.Create(NULL,WM_APP+10,_T(BALLOONPOPUPTEXT),m_hIcon,IDR_MENU1,FALSE,0,0,0,10);
	// TODO: Add extra initialization here
	alreadyminimisedonce = FALSE;
	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CRealmListServerDlg::OnSysCommand(UINT nID, LPARAM lParam)
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

void CRealmListServerDlg::OnPaint() 
{
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
	if (alreadyminimisedonce == FALSE)
	{
	//	m_TrayIcon.MinimiseToTray(this,FALSE);
		alreadyminimisedonce = TRUE;
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CRealmListServerDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

void CRealmListServerDlg::OnBnClickedOk()
{
	// TODO: Add your control notification handler code here
	m_TrayIcon.RemoveIcon();
	OnOK();
}

void CRealmListServerDlg::OnBnClickedAddAcct()
{
	char UserName[64];
	char Password[64];
	m_UserName.GetWindowText(UserName,64);
	m_Password.GetWindowText(Password,64);
	CAccount Account;
	Account.Clear();
	if(Account.Create(UserName,Password))
	{
		MessageBox("Account Created","Success",MB_OK);
		m_UserName.SetWindowText("");
		m_Password.SetWindowText("");
	}
	else MessageBox("Account Not Created","Failure",MB_OK);
}


void CRealmListServerDlg::OnPopupShowMainWindow()
{
	if (!IsWindowVisible())
		m_TrayIcon.MaximiseFromTray(this,TRUE);
	else
	{
	m_TrayIcon.MinimiseToTray(this,TRUE);
	m_TrayIcon.ShowBalloon(_T("Dialog window has been minimised, double click on this icon to return it to it's previous state."),_T(BALLOONPOPUPTEXT),NIIF_INFO,10);
	}
}

void CRealmListServerDlg::OnPopupStartRealmServer()
{
	// TODO: Add your command handler code here
	MessageBox("TODO: Add shellexecute code to start realm server","Oops...",MB_OK);
}

void CRealmListServerDlg::OnPopupShutdownRealmServer()
{
	// TODO: Add your command handler code here
	MessageBox("TODO: Add killprocess code to stop realm server","Oops...",MB_OK);
}

void CRealmListServerDlg::OnPopupShutdownRealmListServer()
{
	// TODO: Add your command handler code here
	m_TrayIcon.RemoveIcon();
	OnOK();
}

void CRealmListServerDlg::OnBnClickedMinimize()
{
	// TODO: Add your control notification handler code here
	if (!IsWindowVisible())
		m_TrayIcon.MaximiseFromTray(this,TRUE);
	else
	{
	m_TrayIcon.MinimiseToTray(this,TRUE);
	m_TrayIcon.ShowBalloon(_T("Dialog window has been minimized, double click here to return it to it's previous state"),_T(BALLOONPOPUPTEXT),NIIF_INFO,10);
	}
}

#endif
