// WoWLoginDlg.h : header file
//

#pragma once
#include "afxwin.h"
#include "afxcmn.h"


// CWoWLoginDlg dialog
class CWoWLoginDlg : public CDialog
{
// Construction
public:
	CWoWLoginDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_WOWLOGIN_DIALOG };

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
	CEdit m_Username;
	CEdit m_Password;
	CEdit m_RealmList;
	CButton m_CheckWindowed;
	int Validate(char *server, char * user, char * pass);
	afx_msg void OnLbnSelchangeRealmlist();
	CListBox m_listbox;
	afx_msg void OnBnClickedRefresh();

	long pvp[256];
	char invalidrealm[256];
	char realmname[256][256];
	char ip[256][256];
	long players[256];

};
