// SendMail.cpp : implementation file
//
#ifdef WIN32

#include "stdafx.h"
#include "TownHall.h"
#include "SendMail.h"
#include "Mail.h"
#include "DataManager.h"
#include "Player.h"

// CSendMail dialog

IMPLEMENT_DYNAMIC(CSendMail, CDialog)
CSendMail::CSendMail(CWnd* pParent /*=NULL*/)
: CDialog(CSendMail::IDD, pParent)
{
}

CSendMail::~CSendMail()
{
}

void CSendMail::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_MAIL_TEXT_TO, Txt_SendTo);
	DDX_Control(pDX, IDC_MAIL_TEXT_FROM, Txt_From);
	DDX_Control(pDX, IDC_MAIL_TEXT_SUBJECT, Txt_Subject);
	DDX_Control(pDX, IDC_MAIL_TEXT_BODY, Txt_Body);
	DDX_Control(pDX, IDC_MAIL_TEXT_MONEY, Txt_Money);
}


BEGIN_MESSAGE_MAP(CSendMail, CDialog)
	ON_BN_CLICKED(IDOK, OnBnClickedOk)
	ON_BN_CLICKED(IDCANCEL, OnBnClickedCancel)
END_MESSAGE_MAP()


// CSendMail message handlers

void CSendMail::OnBnClickedOk()
{
	// TODO: Add your control notification handler code here

#define MAXMAILSIZE 512
#define MAXNAMESIZE 64

	char sendername[MAXNAMESIZE];
	char receivername[MAXNAMESIZE];

	Txt_SendTo.GetWindowText(receivername,MAXNAMESIZE-1);
	Txt_From.GetWindowText(sendername,MAXNAMESIZE-1);

	unsigned long sender;
	sender = DataManager.PlayerNames[sendername];

	unsigned long receiver;
	receiver = DataManager.PlayerNames[receivername];

	if (!sender)
	{
		MessageBox("Sender could not be found.","Error",MB_OK);
		return;
	}
	if (!receiver)
	{
		MessageBox("Receiver could not be found.","Error",MB_OK);
		return;
	}

	CMail *pMail=new CMail;

	pMail->New();

	pMail->Data.Sender = sender;
	pMail->Data.Recipient = receiver;
	pMail->Data.TimeSent=time(NULL);

	char moneysize[8];

	Txt_Money.GetWindowText(moneysize,7);
	pMail->Data.Money = atoi(moneysize);

	Txt_Subject.GetWindowText(pMail->Data.Subject,MAXNAMESIZE-1);
	Txt_Body.GetWindowText(pMail->Data.Text,MAXMAILSIZE-1);

	pMail->Data.Flags = 0x00;
	pMail->Data.AttachmentGuid = 0;

	// Find target player
	CPlayer *pPlayer;
	if (!DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,receiver))
	{
		MessageBox("Couldn't find target player.","Error",MB_OK);
		return;
	}

	DataManager.NewObject(*pMail);
	pPlayer->Mails.push_back(pMail);

	MessageBox("Mail sent successfully.","Sent",MB_OK);
	OnOK();
}

void CSendMail::OnBnClickedCancel()
{
	// TODO: Add your control notification handler code here
	MessageBox("Process aborted. Message not sent.","Message",MB_OK);
	OnCancel();
}

#endif // WIN32
