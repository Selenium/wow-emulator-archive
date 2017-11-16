//******************************************************************************
#include "header.h"
#include "../myheader.h"
//==============================================================================
CPCTSTR							CMainWnd::caption = MAINWND_CAPTION;
//==============================================================================
CPCTSTR STR_SRV_NOTREG = "Service is not registered";
CPCTSTR STR_SRV_REG = "Service is registered";
CPCTSTR STR_SRV_NOTRUN = "Service is not running";
CPCTSTR STR_SRV_RUN = "Service is running";
//==============================================================================
							// Внешние методы:
//------------------------------------------------------------------------------
// Создать и отобразить окно
void CMainWnd::Show(HWND hParent)
{
	INT_PTR ret = DialogBoxParam(hInstance, MAKEINTRESOURCE(IDD_MAIN),
		hParent, CMainWnd::DialogProc, (LPARAM)this);
	hWnd = NULL;
	switch (ret)
	{
		case 0:
			throwe("DialogBoxParam fails because hWndParent is invalid");
			break;
		case -1:
			throwe("DialogBoxParam");
			break;
	}
}
//------------------------------------------------------------------------------
// Просто конструктор
CMainWnd::CMainWnd()
{
	hWnd = NULL;
}
//------------------------------------------------------------------------------
// Деструктор класса
CMainWnd::~CMainWnd()
{
	if (hWnd != NULL)
		SendMessage(hWnd, WM_CLOSE, 0, 0);
}
//------------------------------------------------------------------------------
							// Защищённые методы:
//------------------------------------------------------------------------------
// Allocs (with "new") string with remote host name, or NULL
char* CMainWnd::GetRemoteHost()
{
	if (!ChIsCheckedID(IDCB_REMOTE))
		return NULL;

	int hostl = GetWindowTextLength(ChGetDlgItem(IDE_HOST));
	if (hostl == 0)
		return NULL;

	char *host = NULL;
	chf(NULL, host = new char[hostl+2]);
		
	DWORD r = GetDlgItemText(hWnd, IDE_HOST, host, hostl+1);
	if (r == 0)
	{
		delete[] host;
		throwe("GetDlgItemText");
	}

	return host;
}
//------------------------------------------------------------------------------
// Задисаблить окно нормально
bool CMainWnd::ChEnableWindow(HWND hWnd, bool enable)
{
	SetLastError(ERROR_SUCCESS);
	bool ret = (EnableWindow(hWnd, enable ? TRUE : FALSE) == 0); // "==" ! :)
	DWORD e = GetLastError();
	if (e != ERROR_SUCCESS)
		throwe("EnableWindow");
	return ret;
}
//------------------------------------------------------------------------------
// Получить хендл элемента нормально
HWND CMainWnd::ChGetDlgItem(int id)
{
	HWND ret = GetDlgItem(hWnd, id);
	if (ret == NULL)
		throwe("GetDlgItem");
	return ret;
}
//------------------------------------------------------------------------------
// Задисаблить окно нормально по id
bool CMainWnd::ChEnableWindowID(int id, bool enable)
{
	return ChEnableWindow(ChGetDlgItem(id), enable);
}
//------------------------------------------------------------------------------
// Отмечен ли флаг
bool CMainWnd::ChIsCheckedID(int id)
{
	return IsDlgButtonChecked(hWnd, id) == BST_CHECKED;
}
//------------------------------------------------------------------------------
// Вывести, что работа идёт
void CMainWnd::Running(void* data)
{
	uint len = (uint)strlen(caption)+3*2;
	char *str = new char[len];
	__try
	{
		strcpy(str, caption);

		CMainWnd *this_obj = (CMainWnd*)data;
		this_obj->palka.Next();

		char add[3] = {' ', this_obj->palka.Get(), '\0'};
		strcat(str, add);

		chf(FALSE, SetWindowText(this_obj->hWnd, str));
	}
	__finally
	{
		delete[] str;
	}
}
//------------------------------------------------------------------------------
// Заэнаблить группу "управление"
void CMainWnd::EnableControlGroup(bool enable)
{
	ChEnableWindowID(IDB_CONNECT, enable);
	ChEnableWindowID(IDB_DISCONNECT, false);
	ChEnableWindowID(IDB_COMMAND, false);
	ChEnableWindowID(IDE_COMMAND, false);
	ChEnableWindowID(IDG_CONTROL, enable);
}
//------------------------------------------------------------------------------
// Заэнаблить группу "удалённое"
void CMainWnd::EnableRemoteGroup(bool enable, bool labletrue)
{
	bool logined = (IsWindowEnabled(ChGetDlgItem(IDCB_REMOTE)) != TRUE);

	ChEnableWindowID(IDL_HOST, enable|labletrue);
	ChEnableWindowID(IDE_HOST, enable && !logined);
	ChEnableWindowID(IDL_USER, enable|labletrue);
	ChEnableWindowID(IDE_USER, enable && !logined);
	ChEnableWindowID(IDL_PASS, enable|labletrue);
	ChEnableWindowID(IDE_PASS, enable && !logined);
	ChEnableWindowID(IDB_LOGIN, enable && !logined);
	//ChEnableWindowID(IDB_LOGOUT, enable);
}
//------------------------------------------------------------------------------
// Установить начальные настройки интерфейса
void CMainWnd::OnInit()
{
	chf(FALSE, SetWindowText(hWnd, caption));
	bool reg, run;
	SCfgP->GetInfo(reg, run);

	ChEnableWindowID(IDB_START, reg&&(!run));
	ChEnableWindowID(IDB_STOP, reg&&run);
	ChEnableWindowID(IDB_REGISTER, !reg);
	ChEnableWindowID(IDB_UNREGISTER, reg);
	ch(SetWindowText(ChGetDlgItem(IDL_REG), reg?STR_SRV_REG:STR_SRV_NOTREG));
	ch(SetWindowText(ChGetDlgItem(IDL_RUN), run?STR_SRV_RUN:STR_SRV_NOTRUN));

	bool connected = (IsWindowEnabled(ChGetDlgItem(IDB_DISCONNECT)) == TRUE);
	if (!connected)
		EnableControlGroup(run);

	EnableRemoteGroup(ChIsCheckedID(IDCB_REMOTE));
}
//------------------------------------------------------------------------------
// Зарегистрировать сервис
void CMainWnd::OnRegister()
{
	ChEnableWindowID(IDB_REGISTER, false);
	SCfgP->InstallSelf();
	ChEnableWindowID(IDB_START, true);
	ChEnableWindowID(IDB_STOP, false);
	ChEnableWindowID(IDB_UNREGISTER, true);
	ch(SetWindowText(ChGetDlgItem(IDL_REG), STR_SRV_REG));
}
//------------------------------------------------------------------------------
// Удалить сервис
void CMainWnd::OnUnRegister()
{
	ChEnableWindowID(IDB_UNREGISTER, false);
	
	char *host = GetRemoteHost();
	__try
	{
		SCfgP->Remove(host);
	}
	__finally
	{
		if (host != NULL)
			delete[] host;
	}

	ChEnableWindowID(IDB_START, false);
	ChEnableWindowID(IDB_REGISTER, true);
	ch(SetWindowText(ChGetDlgItem(IDL_REG), STR_SRV_NOTREG));
}
//------------------------------------------------------------------------------
// Запустить сервис
void CMainWnd::OnStart()
{
	ChEnableWindowID(IDB_START, false);
	
	char *host = GetRemoteHost();
	__try
	{
		SCfgP->Begin(Running, this, host);
	}
	__finally
	{
		if (host != NULL)
			delete[] host;
	}

	chf(FALSE, SetWindowText(hWnd, caption));
	ChEnableWindowID(IDB_STOP, true);
	EnableControlGroup(true);
	ch(SetWindowText(ChGetDlgItem(IDL_RUN), STR_SRV_RUN));
}
//------------------------------------------------------------------------------
// Остановить сервис
void CMainWnd::OnStop()
{
	if (IsWindowEnabled(ChGetDlgItem(IDB_DISCONNECT)) == TRUE)
		OnDisconnect();

	EnableControlGroup(false);
	ChEnableWindowID(IDB_STOP, false);
	
	char *host = GetRemoteHost();
	__try
	{
		SCfgP->End(Running, this, host);
	}
	__finally
	{
		if (host != NULL)
			delete[] host;
	}

	chf(FALSE, SetWindowText(hWnd, caption));
	ch(SetWindowText(ChGetDlgItem(IDL_RUN), STR_SRV_NOTRUN));

	bool reg, run;
	SCfgP->GetInfo(reg, run);
	if (reg)
		ChEnableWindowID(IDB_START, true);
}
//------------------------------------------------------------------------------
// Connect to server
void CMainWnd::OnConnect()
{
	ChEnableWindowID(IDB_CONNECT, false);
	
	char *host = GetRemoteHost();
	__try
	{
		SCtrlP->Connect(host);
	}
	__finally
	{
		if (host != NULL)
			delete[] host;
	}

	ChEnableWindowID(IDB_DISCONNECT, true);
	ChEnableWindowID(IDB_COMMAND, true);
	ChEnableWindowID(IDE_COMMAND, true);
}
//------------------------------------------------------------------------------
// Disconnect from server
void CMainWnd::OnDisconnect()
{
	ChEnableWindowID(IDB_DISCONNECT, false);
	ChEnableWindowID(IDB_COMMAND, false);
	ChEnableWindowID(IDE_COMMAND, false);
	SCtrlP->Disconnect();
	ChEnableWindowID(IDB_CONNECT, true);
}
//------------------------------------------------------------------------------
// Send command to server
void CMainWnd::OnCommand()
{
	ChEnableWindowID(IDB_COMMAND, false);
	ChEnableWindowID(IDE_COMMAND, false);

	int len;
	len = GetWindowTextLength(GetDlgItem(hWnd, IDE_COMMAND));
	if (len == 0)
	{
		MessageBox(hWnd, "Input command first!", "Error", MB_ICONWARNING);
		ChEnableWindowID(IDE_COMMAND, true);
		ChEnableWindowID(IDB_COMMAND, true);
		return;
	}

	char * cmd = NULL;
	char * buf = NULL;
	chf(NULL, cmd = new char[len+2]);
	chf(NULL, buf = new char[len+2+4]);
	__try
	{
		chf(0, GetDlgItemText(hWnd, IDE_COMMAND, cmd, len+1));
		chf(-1, len = sprintf(buf, "%s\n", cmd));
		SCtrlP->SendCommand(buf, len);
	}
	__finally
	{
		if (buf != NULL)
            delete[] buf;
		if (cmd != NULL)
            delete[] cmd;
	}
	ChEnableWindowID(IDE_COMMAND, true);
	ChEnableWindowID(IDB_COMMAND, true);
}
//------------------------------------------------------------------------------
// Login into remote machine
void CMainWnd::OnLogin()
{
	char *host = NULL;
	char *user = NULL;
	char *pass = NULL;
	char *share = NULL;

	__try
	{
		EnableRemoteGroup(false, true);

		int hostl = GetWindowTextLength(ChGetDlgItem(IDE_HOST));
		int userl = GetWindowTextLength(ChGetDlgItem(IDE_USER));
		int passl = GetWindowTextLength(ChGetDlgItem(IDE_PASS));

		if (hostl == 0)
		{
			MessageBox(hWnd, "Input host name first!", "Warning", MB_ICONWARNING);
			EnableRemoteGroup(true, false);
			return;
		}
		if (userl == 0)
		{
			MessageBox(hWnd, "Input user name first!", "Warning", MB_ICONWARNING);
			EnableRemoteGroup(true, false);
			return;
		}

		// password can be empty...

		chf(NULL, host = new char[hostl+2]);
		chf(NULL, user = new char[userl+2]);
		chf(NULL, pass = new char[passl+2]);
	
		chf(0, GetDlgItemText(hWnd, IDE_HOST, host, hostl+1));
		chf(0, GetDlgItemText(hWnd, IDE_USER, user, userl+1));
		if (passl != 0)
			{chf(0, GetDlgItemText(hWnd, IDE_PASS, pass, passl+1));}
		else
			pass[0] = 0;

		chf(NULL, share = new char[2+hostl+5+1]);
		chf(-1, sprintf(share, "\\\\%s\\IPC$", host));
		AddShare(user, pass, share);
	}
	__finally
	{
		if (host != NULL)
			delete[] host;
		if (user != NULL)
			delete[] user;
		if (pass != NULL)
			delete[] pass;
		if (share != NULL)
			delete[] share;
	}
	ChEnableWindowID(IDCB_REMOTE, false);
	ChEnableWindowID(IDB_LOGOUT, true);
	MessageBox(hWnd, "Connected successfully.", "Information", MB_ICONINFORMATION | MB_OK);
}
//------------------------------------------------------------------------------
// Logout from remote machine
void CMainWnd::OnLogout()
{
	char *host = NULL;
	char *share = NULL;

	__try
	{
		int hostl = GetWindowTextLength(ChGetDlgItem(IDE_HOST));

		chf(NULL, host = new char[hostl+2]);

		chf(0, GetDlgItemText(hWnd, IDE_HOST, host, hostl+1));

		chf(NULL, share = new char[2+hostl+5+1]);

		chf(-1, sprintf(share, "\\\\%s\\IPC$", host));

		DelShare(share);
	}
	__finally
	{
		if (host != NULL)
			delete[] host;
		if (share != NULL)
			delete[] share;
	}
	ChEnableWindowID(IDCB_REMOTE, true);
	EnableRemoteGroup(ChIsCheckedID(IDCB_REMOTE));
	ChEnableWindowID(IDB_LOGOUT, false);
	MessageBox(hWnd, "Disconnected successfully.", "Information", MB_ICONINFORMATION | MB_OK);
}
//------------------------------------------------------------------------------
// Оконная процедура диалогового окна
INT_PTR CALLBACK CMainWnd::DialogProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	// Обрабатываю WM_INITDIALOG:
	if (uMsg == WM_INITDIALOG)
	{
		((CMainWnd*)lParam)->hWnd = hWnd;

		// Устанавливаю указатель на класс в качестве данных окна:
		SetLastError(ERROR_SUCCESS);
		if (0 == SetWindowLongPtr(hWnd, DWLP_USER, (LONG)lParam))
		{
			DWORD e = GetLastError();
			if (e != ERROR_SUCCESS)
				throwe_code("SetWindowLongPtr", e);
		}

		((CMainWnd*)lParam)->OnInit();
		return TRUE;
	}

	// Получаю указатель на класс:
	SetLastError(ERROR_SUCCESS);
	CMainWnd *this_obj = (CMainWnd*)((char*)NULL+GetWindowLongPtr(hWnd, DWLP_USER));
	if (NULL == this_obj)
	{
		DWORD e = GetLastError();
		if (e != ERROR_SUCCESS)
			throwe_code("GetWindowLongPtr", e);
	}

	// Обрабатываю сообщения:
	try
	{
		switch(uMsg)
		{
			case WM_COMMAND:
				if (LOWORD(wParam) == IDB_REGISTER)
				{
					this_obj->OnRegister();
					return FALSE;
				}
				else if (LOWORD(wParam) == IDB_UNREGISTER)
				{
					this_obj->OnUnRegister();
					return FALSE;
				}
				else if (LOWORD(wParam) == IDB_START)
				{
					this_obj->OnStart();
					return FALSE;
				}
				else if (LOWORD(wParam) == IDB_STOP)
				{
					this_obj->OnStop();
					return FALSE;
				}
				else if (LOWORD(wParam) == IDB_CONNECT)
				{
					this_obj->OnConnect();
					return FALSE;
				}
				else if (LOWORD(wParam) == IDB_DISCONNECT)
				{
					this_obj->OnDisconnect();
					return FALSE;
				}
				else if (LOWORD(wParam) == IDB_COMMAND)
				{
					this_obj->OnCommand();
					return FALSE;
				}
				else if (LOWORD(wParam) == IDCB_REMOTE)
				{
					this_obj->EnableRemoteGroup(this_obj->ChIsCheckedID(IDCB_REMOTE));
					return FALSE;
				}
				else if (LOWORD(wParam) == IDB_LOGIN)
				{
					this_obj->OnLogin();
					return FALSE;
				}
				else if (LOWORD(wParam) == IDB_LOGOUT)
				{
					this_obj->OnLogout();
					return FALSE;
				}
				return FALSE;
			case WM_CLOSE:
				chf(0, EndDialog(hWnd, 1));
				return TRUE;
		}
	}
	catch (CError &e)
	{
		e.ToGUI(hWnd);
		this_obj->OnInit();
	}

	return FALSE;
}
//******************************************************************************
