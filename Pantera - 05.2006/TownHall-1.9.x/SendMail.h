#ifndef SENDMAILDLG_H
#define SENDMAILDLG_H
#ifdef WIN32

#include "afxwin.h"


// CSendMail dialog

class CSendMail : public CDialog
{
	DECLARE_DYNAMIC(CSendMail)

public:
	CSendMail(CWnd* pParent = NULL);   // standard constructor
	virtual ~CSendMail();

	// Dialog Data
	enum { IDD = IDD_SENDMAIL };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedOk();
	afx_msg void OnBnClickedCancel();
	CEdit Txt_SendTo;
	CEdit Txt_From;
	CEdit Txt_Subject;
	CEdit Txt_Body;
	CEdit Txt_Money;
};


#endif // WIN32
#endif // SENDMAILDLG_H
