#ifdef WIN32
// ConsoleDlg.cpp : implementation file
//

#include "stdafx.h"
#include "TownHall.h"
#include "ConsoleDlg.h"
#include "ConsoleInterface.h"

// CConsoleDlg dialog
CConsoleInterface cConsoleParser;

IMPLEMENT_DYNAMIC(CConsoleDlg, CDialog)
CConsoleDlg::CConsoleDlg(CWnd* pParent /*=NULL*/)
: CDialog(CConsoleDlg::IDD, pParent)
{
	pCourier=new CFont;
	pCourier->CreatePointFont(110,"Courier");
}

CConsoleDlg::~CConsoleDlg()
{
	delete pCourier;
}

void CConsoleDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_CONSOLE_TEXT_ENTRY, Txt_Command);
	DDX_Control(pDX, IDC_CONSOLE_TEXT_DISPLAY, Txt_Display);
}


BEGIN_MESSAGE_MAP(CConsoleDlg, CDialog)
	ON_BN_CLICKED(IDC_CONSOLE_BUTTON_ACCEPT, OnBnClickedButtonAccept)
	ON_BN_CLICKED(IDC_CONSOLE_BUTTON_CLOSE, OnBnClickedButtonClose)
END_MESSAGE_MAP()


// CConsoleDlg message handlers

void CConsoleDlg::OnBnClickedButtonAccept()
{
	// TODO: Add your control notification handler code here
	// Parse Command

	char commandtext[256];
	Txt_Command.GetWindowText(commandtext, 255);

	Txt_Command.SetWindowText(0);
	LogText("Console: ");
	LogText(commandtext);
	LogText("\r\n");
	string returnedtext;
	returnedtext = cConsoleParser.ParseCommand(commandtext);
	LogTextLPC(_T(returnedtext.c_str()));
	LogText("\r\n");
	return;
}

void CConsoleDlg::LogText(char *logtext)
{
	Txt_Display.SetFont(pCourier);
	int nSize = Txt_Display.GetWindowTextLength();
	Txt_Display.SetSel(nSize, nSize);
	Txt_Display.ReplaceSel(_T(logtext));
}

void CConsoleDlg::LogTextLPC(LPCTSTR logtext)
{
	Txt_Display.SetFont(pCourier);
	int nSize = Txt_Display.GetWindowTextLength();
	Txt_Display.SetSel(nSize, nSize);
	Txt_Display.ReplaceSel(logtext);
}

BOOL CConsoleDlg::PreTranslateMessage(MSG* pMsg)
{
	if(pMsg->message==WM_KEYDOWN)
	{
		if(pMsg->wParam==VK_ESCAPE)
			pMsg->wParam=NULL ;
		if(pMsg->wParam==VK_RETURN)
		{
			pMsg->wParam=NULL ;
			OnBnClickedButtonAccept();
		}
	}
	return CDialog::PreTranslateMessage(pMsg);
}

void CConsoleDlg::OnBnClickedButtonClose()
{
	OnOK();
}

#endif // WIN32
