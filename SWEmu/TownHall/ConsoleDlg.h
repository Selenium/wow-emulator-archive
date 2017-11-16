#ifndef CONSOLEDLG_H
#define CONSOLEDLG_H
#ifdef WIN32
#include "afxwin.h"

// CConsoleDlg dialog

class CConsoleDlg : public CDialog
{
	DECLARE_DYNAMIC(CConsoleDlg)

public:
	CConsoleDlg(CWnd* pParent = NULL);   // standard constructor
	virtual ~CConsoleDlg();

	// Dialog Data
	enum { IDD = IDD_CONSOLEDIALOG };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	BOOL PreTranslateMessage(MSG* pMsg);
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedButtonAccept();
	CEdit Txt_Command;
	CEdit Txt_Display;
	CFont *pCourier;
	void LogText(char *logtext);
	void LogTextLPC(LPCTSTR logtext);
	afx_msg void OnBnClickedButtonClose();
};

#endif // WIN32
#endif // CONSOLEDLG_H
