// TownHallDlg.h : header file

//



#pragma once

#ifdef WIN32

#include "afxwin.h"

#include "afxcmn.h"





// CTownHallDlg dialog

class CTownHallDlg : public CDialog

{

// Construction

public:

	CTownHallDlg(CWnd* pParent = NULL);	// standard constructor



// Dialog Data

	enum { IDD = IDD_TOWNHALL_DIALOG };



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

	afx_msg void OnBnClickedButton1();

	afx_msg void OnBnClickedSendP();

	CButton m_StartButton;

//	CButton m_SendPacketDlg;

	CIPAddressCtrl m_IPAddress;

	CIPAddressCtrl m_RealmList;

	CButton m_Public;

	CEdit m_Name;

	CButton m_ExternalList;

};



#endif

