// TownHallDlg.h : header file
//

#ifndef TOWNHALLDLG_H
#define TOWNHALLDLG_H

#ifdef WIN32
#include "afxwin.h"
#include "afxcmn.h"
#include "SystemTray.h"
// #include "Console.h"
#include "TransparentStatic.h"
#include "afxext.h"
#include "ConsoleDlg.h"
#include "RollBtn.h"
#define BALLOONPOPUPTITLE "SWemu Realm Server"
// CTownHallDlg dialog
class CTownHallDlg : public CDialog
{
	// Construction
public:
	CTownHallDlg(CWnd* pParent = NULL);	// standard constructor
	CSystemTray m_TrayIcon;
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
	void OnLButtonDown(UINT nFlags, CPoint point);
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	BOOL rs_started;
	CTransparentStatic Txt_ServerName;
	CTransparentStatic Txt_RLStatus;
	CTransparentStatic Txt_Status;
	CTransparentStatic Txt_Clients;
	CProgressCtrl Ctl_Progress;

	afx_msg void OnBnClickedSave();
	afx_msg void OnBnClickedRehash();
	afx_msg void OnBnClickedMinimize();
	afx_msg void OnBnClickedMail();
	afx_msg void OnBnClickedStartStop();
	afx_msg void OnBnClickedSendP();
	afx_msg void OnBnClickedConsole();

	afx_msg void OnServerPopupShutDownServer();
	afx_msg void OnServerPopupExitTownHall();
	afx_msg void OnServerPopupShowServerWindow();
	afx_msg void OnServerPopupViewLogFile();
	afx_msg void OnServerPopupViewReportLog();
	afx_msg void OnServerPopupViewChatCommandLog();
	afx_msg void OnServerPopupViewPacketLogs();
	afx_msg void OnServerPopupReloadConfig();
	afx_msg void OnServerPopupSaveAll();
	afx_msg void OnServerPopupDisconnectAll();
	afx_msg void OnServerPopupNumberOfConnectedClients();
	afx_msg void OnServerPopupStartServer();
	afx_msg void OnServerPopupSendPacket();
	afx_msg void OnServerPopupSendMail();
	afx_msg void OnOK();
	CTransparentStatic Static_RLStatus;
	CTransparentStatic Static_Status;
	CTransparentStatic Static_Clients;
	CTransparentStatic Static_ServerName;
	RollBtn Btn_Exit;
	RollBtn Btn_SendPacketDlg;
	RollBtn Btn_SendMail;
	RollBtn Btn_Reload;
	RollBtn Btn_Minimize;
	RollBtn Btn_StartButton;
	RollBtn Btn_Save;
	RollBtn Btn_Console;
	void LogText(char *message);
};

#endif // WIN32
#endif // TOWNHALLDLG_H
