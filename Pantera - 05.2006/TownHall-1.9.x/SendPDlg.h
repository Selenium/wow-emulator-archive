#ifndef SENDPDLG_H
#define SENDPDLG_H

#ifdef WIN32
#include "afxwin.h"
#include	<fstream>

struct stringNode {
	char *string;
	unsigned short opCode;
	stringNode *nextNode;
};

class CSendPDlg : public CDialog
{
	DECLARE_DYNAMIC(CSendPDlg)

public:
	CSendPDlg(CWnd* pParent = NULL);
	virtual ~CSendPDlg();

	enum { IDD = IDD_SENDPACKET };

	CEdit Txt_Opcode;
	CEdit Txt_Edit;
	CComboBox List_ComboList;

	virtual BOOL OnInitDialog();

protected:
	virtual void DoDataExchange(CDataExchange* pDX);

	DECLARE_MESSAGE_MAP()

private:
	char packetName[64];
	char packet[8192];
	ifstream fin;
	stringNode *stringList;
	stringNode *stringTail;
	void ReadScript();
	void AddPacket(unsigned short opcode, int len);
	void DestroyList();
	void DisplayPacket(int packetNum);
	void OnSelect();
	void OnClickOk();
	void OnClickCancel();
	int ConvertToBinary();
	void SendPacket();
	inline int getDecimal(char hex)
	{
		switch(hex)
		{
		case 'F' : return 15;
		case 'E' : return 14;
		case 'D' : return 13;
		case 'C' : return 12;
		case 'B' : return 11;
		case 'A' : return 10;
		default  : return (hex - '0');
		}
	}
};
#endif // WIN32

#endif // SENDPDLG_H
