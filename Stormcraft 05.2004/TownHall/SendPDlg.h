#pragma once
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

	CEdit m_Opcode;
	CEdit m_Edit;
	CComboBox m_ComboList;
	CButton m_CheckCompress;

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
#endif