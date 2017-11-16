// WoWLoginDlg.cpp : implementation file
//

#include "stdafx.h"
#include "WoWLogin.h"
#include "WoWLoginDlg.h"
#include ".\wowlogindlg.h"
#include "WinSocket.h"

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


// CWoWLoginDlg dialog



CWoWLoginDlg::CWoWLoginDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CWoWLoginDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CWoWLoginDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_EDITUSERNAME, m_Username);
	DDX_Control(pDX, IDC_EDITPASSWORD, m_Password);
	DDX_Control(pDX, IDC_EDITREALMLIST, m_RealmList);
	DDX_Control(pDX, IDC_CHECK1, m_CheckWindowed);
	DDX_Control(pDX, IDC_REALMLIST, m_listbox);
}

BEGIN_MESSAGE_MAP(CWoWLoginDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_BN_CLICKED(IDOK, OnBnClickedOk)
	ON_LBN_SELCHANGE(IDC_REALMLIST, OnLbnSelchangeRealmlist)
	ON_BN_CLICKED(IDC_REFRESH, OnBnClickedRefresh)
END_MESSAGE_MAP()


// CWoWLoginDlg message handlers

BOOL CWoWLoginDlg::OnInitDialog()
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

	FILE *file=fopen("WTF/RealmList.WTF","rt");
	char temp[256];
	if (file)
	{
		temp[0]=0;
		fgets(temp,255,file);
		temp[255]=0;
		strtok(temp,"\r\n");
		// 1234567890
		// realmlist xxxxxxxx
		if (strlen(temp)>10)
		{
			m_RealmList.SetWindowText(&temp[10]);
		}
		else
			m_RealmList.SetWindowText("localhost");
		fclose(file);
	}
	else
	{
		m_RealmList.SetWindowText("localhost");
	}
	
	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CWoWLoginDlg::OnSysCommand(UINT nID, LPARAM lParam)
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

void CWoWLoginDlg::OnPaint() 
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
HCURSOR CWoWLoginDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

void CWoWLoginDlg::OnBnClickedOk()
{
	// TODO: Add your control notification handler code here
	char RealmList[256]={0};
	char AccountName[256]={0};
	char Password[256]={0};
	int selected = m_listbox.GetCurSel();
	if (selected == LB_ERR) {
		MessageBox("You must select a server from the realm list");
		return;
	}
	if (!m_Username.GetWindowText(AccountName,255))
	{
		MessageBox("Account Name Required");
		return;
	}
	if (!m_Password.GetWindowText(Password,255))
	{
		MessageBox("Password Required");
		return;
	}
	if (!m_RealmList.GetWindowText(RealmList,255)) {
		MessageBox("RealmList Required");
		return;
	}
	else
	{
		FILE *file=fopen("WTF\\RealmList.WTF","wt+");
		if (!file)
		{
			MessageBox("Could not open WTF\\RealmList.WTF for writing");
			return;
		}
		fprintf(file,"realmList %s\n",RealmList);
		fprintf(file,"realmName \"\"\n");
		fprintf(file,"realmAddress \"\"\n");
		fclose(file);
	}
	char *selip = ip[selected];
	char *selserver = strtok(selip,":");

	if (selserver == NULL) {
		MessageBox("Server is not defined in realmlist");
		return;
	}

	if (!strcmp(selserver,"0")) {
		MessageBox("Server is not defined in realmlist");
		return;
	}

	int val = Validate(selserver,AccountName,Password);
	if (val != 0) {
		if (val == -1)
			MessageBox("User/pass incorrect");
		return;
	}

	remove("WDB\\itemcache.wdb");
	remove("WDB\\creaturecache.wdb");
	remove("WDB\\gameobjectcache.wdb");
	remove("WDB\\npccache.wdb");
	remove("WDB\\questcache.wdb");
	remove("WDB\\pagetextcache.wdb");

	STARTUPINFO si;
	PROCESS_INFORMATION pi;

	ZeroMemory( &si, sizeof(si) );
	si.cb = sizeof(si);
	ZeroMemory( &pi, sizeof(pi) );


	char arg1[32] = {""};

	if (m_CheckWindowed.GetCheck())
	{
		strcpy(arg1, "WoW.exe -console -windowed");
	}



	// Start the child process. 
	if( !CreateProcess( "WoW.exe", //  
		//NULL, // Command line. 
		arg1,
		NULL,             // Process handle not inheritable. 
		NULL,             // Thread handle not inheritable. 
		FALSE,            // Set handle inheritance to FALSE. 
		CREATE_SUSPENDED,                // No creation flags. 
		NULL,             // Use parent's environment block. 
		NULL,             // Use parent's starting directory. 
		&si,              // Pointer to STARTUPINFO structure.
		&pi )             // Pointer to PROCESS_INFORMATION structure.
	) 
	{
		MessageBox("Could not start WoW.exe, run WoWLogin from the WoW directory");
		return;
	}

	/*
	unsigned char PassJump[]=
	{
		0xEB, 0x04,0x90,0x90,0x90,0x90
	};
	// 402278
	// 40228a
	unsigned long i;
	WriteProcessMemory(pi.hProcess,(LPVOID)0x4023A8,&PassJump[0],6,&i);
	WriteProcessMemory(pi.hProcess,(LPVOID)0x4023BA,&PassJump[0],6,&i);

	*/
	ResumeThread(pi.hThread);

	OnOK();
}




int CWoWLoginDlg::Validate(char *server, char * user, char * pass)
{
	TCPSocket sock;
	unsigned char buffer[256];
	int buflen=0;

	if (!sock.Connect(server,8087)) {
		MessageBox("Connect to server failed");
		return -2;
	}
	int userlen = (int)strlen(user);
	buffer[buflen]=(char)userlen;
	buflen++;
	memcpy(&buffer[buflen],user,userlen);
	buflen+=userlen;

	int passlen = (int)strlen(pass);
	buffer[buflen]=(char)passlen;
	buflen++;
	memcpy(&buffer[buflen],pass,passlen);
	buflen+=passlen;

	if (!sock.Send((char *)buffer,(int)buflen)) {
		MessageBox("Send failed");
		return -2;
	}
	if (!sock.Receive((char *)buffer,1)) {
		MessageBox("Recv failed");
		return -2;
	}
	sock.Close();
	if (buffer[0] == 1)
		return 0;
	else
		return -1;
}


void CWoWLoginDlg::OnLbnSelchangeRealmlist()
{
	// TODO: Add your control notification handler code here
}

void CWoWLoginDlg::OnBnClickedRefresh()
{
	m_listbox.ResetContent();
	char RealmList[256]={0};
	if (!m_RealmList.GetWindowText(RealmList,255)) {
		MessageBox("RealmList Required");
		return;
	}
	TCPSocket sock;
	unsigned char buffer[4096];
	int buflen=0;
	unsigned char req[0x05] = {0x10,0x00,0x00,0x00,0x00};

	if (!sock.Connect(RealmList,3724)) {
		MessageBox("Connect failed");
		return;
	}
	memcpy(buffer,req,5);
	if (!sock.Send((char *)buffer,(int)5)) {
		MessageBox("Send failed");
		return;
	}
	if (!sock.Receive((char *)buffer,1)) {
		MessageBox("Recv failed");
		return;
	}
	short len;
	if (!sock.Receive((char *)&len,2)) {
		MessageBox("Recv failed");
		return;
	}
	if (!sock.Receive((char *)buffer,len)) {
		MessageBox("Recv failed");
		return;
	}
	sock.Close();
	int realmcount = buffer[4];

	char *ptr = (char *)&buffer[5];
	for (int i=0;i<realmcount;i++) {
		pvp[i] = *(unsigned long*)ptr;
		ptr+=4;
		invalidrealm[i] = *ptr;
		ptr++;
		strcpy(realmname[i],ptr);
		ptr+=strlen(realmname[i])+1;
		strcpy(ip[i],ptr);
		ptr+=strlen(ip[i])+1;
		players[i] = *(unsigned long*)ptr;
		ptr+=4;
		char listboxstr[256];
		sprintf(listboxstr,"%4d %s %s",players[i],realmname[i],ip[i]);
		m_listbox.AddString(listboxstr);
	}
}
