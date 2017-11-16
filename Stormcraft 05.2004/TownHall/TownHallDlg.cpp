// TownHallDlg.cpp : implementation file
//
#ifdef WIN32
#include "stdafx.h"
#include "TownHall.h"
#include "TownHallDlg.h"
#include "TCPSocket.h"
#include "Globals.h"
#include "SendPDlg.h"
#ifdef _DEBUG
#define new DEBUG_NEW
#endif


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
/*
class CSendPDlg : public CDialog
{
public:
	CSendPDlg();

// Dialog Data
	enum { IDD = IDD_SENDPACKET };

	CButton c_CheckCompress;
	CListBox c_ComboList;
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	virtual BOOL OnInitDialog();
	void ReadScript();

// Implementation
	DECLARE_MESSAGE_MAP()
};
CSendPDlg::CSendPDlg() : CDialog(CSendPDlg::IDD)
{
}
void CSendPDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_CHECK1, c_CheckCompress);
	DDX_Control(pDX, IDC_COMBO1, c_ComboList);
}
BEGIN_MESSAGE_MAP(CSendPDlg, CDialog)
END_MESSAGE_MAP()

*/


// CTownHallDlg dialog



CTownHallDlg::CTownHallDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CTownHallDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CTownHallDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_BUTTON1, m_StartButton);
	DDX_Control(pDX, IDC_IPADDRESS1, m_IPAddress);
	DDX_Control(pDX, IDC_REALMLIST, m_RealmList);
	DDX_Control(pDX, IDC_PUBLIC, m_Public);
	DDX_Control(pDX, IDC_NAME, m_Name);
	DDX_Control(pDX, IDC_EXTERNALREALMLIST, m_ExternalList);
//	DDX_Control(pDX, IDC_SENDP, m_SendPacketDlg);
}

BEGIN_MESSAGE_MAP(CTownHallDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_BN_CLICKED(IDC_BUTTON1, OnBnClickedButton1)
	ON_BN_CLICKED(IDC_SENDP, OnBnClickedSendP)
END_MESSAGE_MAP()


// CTownHallDlg message handlers

BOOL CTownHallDlg::OnInitDialog()
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

	// TODO: Add extra initialization here
	m_Name.SetWindowText("StormCraft Town Hall");
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

void CTownHallDlg::OnBnClickedButton1()
{
	m_StartButton.ShowWindow(SW_HIDE);
	// TODO: Add your control notification handler code here
	// start button
	/*
	unsigned long nAddr;
	if (m_ExternalList.GetCheck()==BST_CHECKED)
	{
		RealmServer.IPAddr[0]=0;
	}
	else
	{
		if (m_IPAddress.GetAddress(nAddr)<4)
		{
			MessageBox("IP Address Required");
			return;
		}

		nAddr=ntohl(nAddr);
		strcpy(RealmServer.IPAddr,inet_ntoa(*(in_addr*)&nAddr));
	}

	if (m_Public.GetCheck()==BST_CHECKED)
	{
		Addr *MainList=new Addr;
		memset(MainList,0,sizeof(Addr));
		MainList->sa_family=2;
	//    MainList->IP=inet_addr("192.168.1.69");// private internal lan
	//	MainList->IP=inet_addr("62.65.143.232"); // private stormcraft (TODO: gethostbyname realmlist.alita.cc)
	//	MainList->IP=inet_addr("213.114.164.23");//private stormcraft
		MainList->IP=inet_addr("66.208.106.16");//public
		MainList->Port=htons(9111);
		RealmServer.MasterLists+=MainList;
	}

	if (m_Name.GetWindowText(&RealmServer.Name[0],63)>3)
	{
		RealmServer.Name[63]=0;
	}
	else
	{
		strcpy(RealmServer.Name,"StormCraft Town Hall");
	}

	if (m_RealmList.GetAddress(nAddr)==4)
	{
		Addr *MainList=new Addr;
		memset(MainList,0,sizeof(Addr));
		MainList->sa_family=2;
		MainList->IP=ntohl(nAddr);
		MainList->Port=htons(9111);
		RealmServer.MasterLists+=MainList;
	}
	/**/

	RealmServer.Go();
}
void CTownHallDlg::OnBnClickedSendP()
{
	CSendPDlg dlgSendP;
	dlgSendP.DoModal();	
}
/*
BOOL CSendPDlg::OnInitDialog()
{

	CheckDlgButton(IDC_CHECK1, BST_CHECKED);
	ReadScript();
	return TRUE;
}

void CSendPDlg::ReadScript()
{
	SetDlgItemText(IDC_EDIT1, "test");
//	c_ComboList.SendMessage(CB_ADDSTRING,0,(LPARAM)(LPCSTR)"test");
}
*/

#endif
