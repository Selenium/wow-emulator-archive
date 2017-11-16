
#ifdef WIN32
#include "stdafx.h"
#include "TownHall.h"
#include "SendPDlg.h"
#include "Globals.h"



IMPLEMENT_DYNAMIC(CSendPDlg, CDialog)
CSendPDlg::CSendPDlg(CWnd* pParent)
	: CDialog(CSendPDlg::IDD, pParent)
{
	stringList = NULL;
	stringTail = NULL;
}

CSendPDlg::~CSendPDlg()
{
	DestroyList();
}

void CSendPDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_EDIT1, m_Edit);
	DDX_Control(pDX, IDC_COMBO1, m_ComboList);
	DDX_Control(pDX, IDC_CHECK1, m_CheckCompress);
	DDX_Control(pDX, IDC_OPCODE, m_Opcode);
}


BEGIN_MESSAGE_MAP(CSendPDlg, CDialog)
ON_CBN_SELCHANGE(IDC_COMBO1, OnSelect)
ON_BN_CLICKED(IDOK2, OnClickOk)
ON_BN_CLICKED(IDCANCEL2, OnClickCancel)
END_MESSAGE_MAP()


BOOL CSendPDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	ReadScript();

	m_CheckCompress.SetCheck(BST_CHECKED);
//	m_ComboList.AddString("test");
//	m_Edit.SetWindowText("test");
	
	return TRUE;
}

void CSendPDlg::ReadScript()
{
	fin.open("packets.txt");
	int len;

	char temp[10];
	unsigned long opcode;

	if (fin)
	{
		do 
		{
			fin.get(packetName, sizeof(packetName), ' ');
			fin.get();

			fin.get(temp, 10, ' ');
			fin.get();

			fin.ignore(5,'"');

			fin.get(packet, sizeof(packet), '"');

			len = fin.gcount();

			fin.ignore(5,'\n');

			sscanf(temp,"%X",&opcode);
			AddPacket((unsigned short)opcode,len);

			m_ComboList.AddString(packetName);

		} while(!fin.eof());
	}

	fin.close();
}

void CSendPDlg::AddPacket(unsigned short opcode, int len)
{
	stringNode *pNode = new stringNode;
	pNode->opCode=opcode;
	pNode->string = new char [len + 1];
	strcpy(pNode->string, packet);
	pNode->nextNode = 0;
	if (stringList)
		stringTail->nextNode=pNode;
	else
		stringList=pNode;
	stringTail=pNode;
/*
	stringNode *current = stringList;

	if (current)
	{
		while (current->nextNode)
			current = current->nextNode;

			current->nextNode = new stringNode;
			current = current->nextNode;
			current->string = new char [len + 1];
			strcpy(current->string, packet);
			current->nextNode = NULL;
	}
	else
	{
		stringList = new stringNode;
		stringList->string = new char [len + 1];
		strcpy(stringList->string, packet);
		stringList->nextNode = NULL;
		current = stringList;
	}
/**/
}

void CSendPDlg::DestroyList()
{
	stringNode *current = stringList;
	stringNode *temp;

	while (current)
	{
		temp = current;
		current = current->nextNode;
		if (temp->string)
			delete [] temp->string;
		delete temp;
	}

	stringList = NULL;
}

void CSendPDlg::DisplayPacket(int packetNum)
{
	stringNode *current = stringList;
	char temp[10];
	int i;

	for (i = 0; i < packetNum; ++i)
	{
		if (current)
			current = current->nextNode;
	}

	if (current)
	{
		// Replace newlines with spaces
		i = 0;
		while(current->string[i] != 0) 
		{
			if(current->string[i] == '\n')
				current->string[i] = ' ';
			++i;
		}

		m_Edit.SetWindowText(current->string);

		sprintf(temp,"%X",current->opCode);
		m_Opcode.SetWindowText(temp);
	}
}

int CSendPDlg::ConvertToBinary()
{
	int i = 0;
	int j = 0;
	int sLen = strlen(packet);

	// Remove spaces and any cr
	while(packet[i] != 0) 
	{
		if(packet[i] == ' ' || packet[i] == '\r' || packet[i] == '\n')
			memcpy(&packet[i],&packet[i+1],sLen-i);

		if (packet[i] != ' ' && packet[i] != '\r' && packet[i] != '\n')
			++i;
	}

	i = 0;
	// Convert to binary
	while(packet[i] != 0) 
	{
		packet[j] = (unsigned char)(getDecimal(packet[i]) << 4) + (unsigned char)getDecimal(packet[i+1]);
		i += 2;
		++j;
	}

	return j;
}

void CSendPDlg::SendPacket()
{
	unsigned long opCode;
	unsigned short length;

	m_Edit.GetWindowText(packet, sizeof(packet));
	char temp[10];
	m_Opcode.GetWindowText(temp,9);
	temp[9]=0;
	sscanf(temp,"%X",&opCode);

	length = ConvertToBinary();
//	opCode = *(unsigned short*)&packet[2];

	RealmServer.BroadcastOutPacket((unsigned short)opCode, packet, length);

// check this for compression, and make sure it's an A9 packet before compressing
//	m_CheckCompress.GetCheck();
}

void CSendPDlg::OnSelect()
{
	DisplayPacket(m_ComboList.GetCurSel());
}

void CSendPDlg::OnClickOk()
{
	SendPacket();
	EndDialog(IDOK2);
}

void CSendPDlg::OnClickCancel()
{
	EndDialog(IDCANCEL2);
}

#endif

