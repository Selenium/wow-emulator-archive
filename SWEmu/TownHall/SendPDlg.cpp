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
	DDX_Control(pDX, IDC_SENDP_EDIT_PACKET, Txt_Edit);
	DDX_Control(pDX, IDC_SENDP_COMBO_PACKET_LIST, List_ComboList);
	DDX_Control(pDX, IDC_SENDP_OPCODE, Txt_Opcode);
}


BEGIN_MESSAGE_MAP(CSendPDlg, CDialog)
	ON_CBN_SELCHANGE(IDC_SENDP_COMBO_PACKET_LIST, OnSelect)
	ON_BN_CLICKED(IDC_SENDP_BUTTON_SEND, OnClickOk)
	ON_BN_CLICKED(IDC_SENDP_BUTTON_CLOSE, OnClickCancel)
END_MESSAGE_MAP()


BOOL CSendPDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	ReadScript();

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

			List_ComboList.AddString(packetName);
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

		Txt_Edit.SetWindowText(current->string);

		sprintf(temp,"%X",current->opCode);
		Txt_Opcode.SetWindowText(temp);
	}
}

int CSendPDlg::ConvertToBinary()
{
	int i = 0;
	int j = 0;
	size_t sLen = strlen(packet);

	// Remove anything foreign ;)
	while(packet[i] != 0)
	{
		if(!isalnum(packet[i])) memcpy(&packet[i],&packet[i+1],sLen-i);
		else i++;
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

	Txt_Edit.GetWindowText(packet, sizeof(packet));
	char temp[10];
	Txt_Opcode.GetWindowText(temp,9);
	temp[9]=0;
	sscanf(temp,"%X",&opCode);

	length = ConvertToBinary();
	//	opCode = *(unsigned short*)&packet[2];

	RealmServer.BroadcastOutPacket((unsigned short)opCode, packet, length);
}

void CSendPDlg::OnSelect()
{
	DisplayPacket(List_ComboList.GetCurSel());
}

void CSendPDlg::OnClickOk()
{
	SendPacket();
}

void CSendPDlg::OnClickCancel()
{
	EndDialog(IDC_SENDP_BUTTON_CLOSE);
}

#endif // WIN32
