// Realm List ServerDlg.h : header file
//

#ifndef REALM_LIST_SERVERDLG_H
#define REALM_LIST_SERVERDLG_H

#ifdef WIN32
#include "SystemTray.h"
#define BALLOONPOPUPTEXT "Pantera Realm List Server"

// CRealmListServerDlg dialog
class CRealmListServerDlg : public CDialog
{
// Construction
public:
	CRealmListServerDlg(CWnd* pParent = NULL);	// standard constructor
	CSystemTray m_TrayIcon;
	BOOL alreadyminimisedonce;

// Dialog Data
	enum { IDD = IDD_REALMLISTSERVER_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedOk();
	afx_msg void OnBnClickedAddAcct();
	afx_msg void OnOK() { CDialog::OnOK(); };
	CEdit m_Connected;
	CEdit m_UserName;
	CEdit m_Password;
	afx_msg void OnPopupShowMainWindow();
	afx_msg void OnPopupStartRealmServer();
	afx_msg void OnPopupShutdownRealmServer();
	afx_msg void OnPopupShutdownRealmListServer();
	afx_msg void OnBnClickedMinimize();
};
extern CRealmListServerDlg *dlg;
#endif // WIN32
#endif // REALM_LIST_SERVERDLG_H
