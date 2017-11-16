//******************************************************************************
#include "header.h"
#include "../myheader.h"
//#define HARD_DEBUG
//==============================================================================
void CError::AddEventSource(
   LPTSTR pszLogName,	// Application log or a custom log
   LPTSTR pszSrcName,	// event source name
   LPTSTR pszMsgDLL,	// path for message DLL
   DWORD  dwNum)		// number of categories
{
	HKEY hk;
	DWORD dwData, dwDisp;
	TCHAR szBuf[3*MAX_PATH*2];
	DWORD err;

	// Create the event source as a subkey of the log:

	wsprintf(szBuf, "SYSTEM\\CurrentControlSet\\Services\\EventLog\\%s\\%s", pszLogName, pszSrcName);


	err = RegCreateKeyEx(HKEY_LOCAL_MACHINE, szBuf, 0, NULL, REG_OPTION_NON_VOLATILE, KEY_WRITE, NULL, &hk, &dwDisp);
	if (err != ERROR_SUCCESS)
		throwe_code("RegCreateKeyEx: Could not create the registry key.", err);

	// Set the name of the message file:

	err = RegSetValueEx(hk,					// subkey handle
						"EventMessageFile",	// value name
						0,					// must be zero
						REG_EXPAND_SZ,		// value type
						(LPBYTE) pszMsgDLL,	// pointer to value data
						(DWORD) lstrlen(pszMsgDLL)+1); // length of value data
	if (err != ERROR_SUCCESS)
		throwe_code("RegSetValueEx: Could not set the event message file.", err);

	// Set the supported event types:

	dwData = EVENTLOG_ERROR_TYPE | EVENTLOG_WARNING_TYPE |
		EVENTLOG_INFORMATION_TYPE;
	err = RegSetValueEx(hk,					// subkey handle
						"TypesSupported",	// value name
						0,					// must be zero
						REG_DWORD,			// value type
						(LPBYTE) &dwData,	// pointer to value data
						sizeof(DWORD));		// length of value data
	if (err != ERROR_SUCCESS)
		throwe_code("RegSetValueEx: Could not set the supported types.", err);

	// Set the category message file and number of categories:
	if (dwNum > 0)
	{
		err = RegSetValueEx(hk,					// subkey handle
							"CategoryMessageFile",// value name
							0,					// must be zero
							REG_EXPAND_SZ,		// value type
							(LPBYTE) pszMsgDLL,	// pointer to value data
							(DWORD) lstrlen(pszMsgDLL)+1);// length of value data
		if (err != ERROR_SUCCESS)
			throwe_code("RegSetValueEx: Could not set the category message file.", err);

		err = RegSetValueEx(hk,					// subkey handle
							"CategoryCount",	// value name
							0,					// must be zero
							REG_DWORD,			// value type
							(LPBYTE) &dwNum,	// pointer to value data
							sizeof(DWORD));		// length of value data
		if (err != ERROR_SUCCESS)
			throwe_code("RegSetValueEx: Could not set the category count.", err);
	}

	err = RegCloseKey(hk);
	if (err != ERROR_SUCCESS)
		throwe_code("RegCloseKey", err);
}
//------------------------------------------------------------------------------
void CError::MyReportEvent(
	LPTSTR pszSrcName,	// event source name
	DWORD dwEventID,	// event identifier
	WORD wCategory,		// event category
	WORD cInserts,		// count of insert strings
	LPCTSTR *szMsg)		// insert strings
{
	HANDLE h = NULL;

	// Get a handle to the event log:
	chf(NULL, h = RegisterEventSource(NULL,		// use local computer
							pszSrcName));// event source name
	// Report the event:
	ch(ReportEvent(h,			// event log handle
		EVENTLOG_ERROR_TYPE,	// event type
		wCategory,				// event category
		dwEventID,				// event identifier
		NULL,					// no user security identifier
		cInserts,				// number of substitution strings
		0,						// no data
		szMsg,					// pointer to strings
		NULL));					// no data

	ch(DeregisterEventSource(h));
}
//------------------------------------------------------------------------------
// Вывести сообщение
void CError::Info()
{
	#ifdef _CONSOLE
		ToCON();
	#else
		ToGUI();
	#endif
}
//------------------------------------------------------------------------------
// Вывести сообщение в консоль (в cerr)
void CError::ToCON()
{
	#ifdef UNICODE
		char *oem = new char[2*strlen(str)+2];
	#else
		char *oem = new char[strlen(str)+1];
	#endif
	CharToOem(str, oem);
	cout << endl << oem << flush;
	delete[] oem;
}
//------------------------------------------------------------------------------
// Вывести сообщение MessageBox'ом
void CError::ToGUI(HWND Parent, CPCTSTR lpCaption, UINT uType)
{
	MessageBox(Parent, str, lpCaption, uType);
}
//------------------------------------------------------------------------------
// Вывести сообщение в журнал событий
void CError::ToEventLog()
{
	AddToMessageLog(str);
}
//------------------------------------------------------------------------------
// Конструктор копирования
CError::CError(const CError &e)
{
	str = new char[strlen(e.str)+1];
	strcpy(str, e.str);
	code = e.code;
}
//------------------------------------------------------------------------------
// Конструктор для полной информации об ошибке
CError::CError(char *srcfn, int srcln, char *text, DWORD code)
{
	CError::code = code;
	LPSTR lpErrText = NULL;
	DWORD dwRet = FormatMessage(FORMAT_MESSAGE_ALLOCATE_BUFFER |
					FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_ARGUMENT_ARRAY,
					NULL, code, LANG_NEUTRAL, (LPSTR)&lpErrText, 0, NULL);
	str = new char[dwRet + strlen(srcfn) + strlen(text) + 256];
	if (dwRet == 0)
		sprintf(str, "SRC:\t%s:%d\nCMD:\t%s\nWERR:\t%d (0x%x)\n", srcfn, srcln, text, code, code);
	else
		sprintf(str, "SRC:\t%s:%d\nCMD:\t%s\nWERR:\t%d (0x%x): %s", srcfn, srcln, text, code, code, lpErrText);
	if (lpErrText != NULL)
		LocalFree(lpErrText);
#ifdef HARD_DEBUG
	DebugBreak();
#endif
}
//------------------------------------------------------------------------------
// Конструктор для сжатой информации об ошибке
CError::CError(char *text, DWORD code)
{
	CError::code = code;
	LPSTR lpErrText = NULL;
	DWORD dwRet = FormatMessage(FORMAT_MESSAGE_ALLOCATE_BUFFER |
					FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_ARGUMENT_ARRAY,
					NULL, code, LANG_NEUTRAL, (LPSTR)&lpErrText, 0, NULL);
	str = new char[dwRet + 256];
	if (dwRet == 0)
		//sprintf(str, "CMD:\t%s\nWERR:\t%d (0x%x)\n", text, code, code);
		sprintf(str, "Command:\t%sError Code:\t%d (0x%x)\n", text, code, code);
	else
		//sprintf(str, "CMD:\t%s\nWERR:\t%d (0x%x): %s", text, code, code, lpErrText);
		sprintf(str, "%s", lpErrText);
	if (lpErrText != NULL)
		LocalFree(lpErrText);
#ifdef HARD_DEBUG
	DebugBreak();
#endif
}
//------------------------------------------------------------------------------
// Деструктор класса
CError::~CError()
{
	delete[] str;
}
//------------------------------------------------------------------------------
// Получить код ошибки
DWORD CError::GetCode() const
{
	return code;
}
//==============================================================================
// Добавить строку в журнал событий
void CError::AddToMessageLog(LPTSTR lpszMsg)
{
	TCHAR szMsg[1024];
	HANDLE hEventSource;
	LPCTSTR lpszStrings[2];
	DWORD dwErr = code;

	// Use event logging to log the error:
	hEventSource = RegisterEventSource(NULL, TEXT("\"WoWD\" service"));

	sprintf(szMsg, "%s error: %d", "\"WoWD\" service", dwErr);
	lpszStrings[0] = szMsg;
	lpszStrings[1] = lpszMsg;

	if (hEventSource != NULL)
	{
		ReportEvent(hEventSource, EVENTLOG_ERROR_TYPE, 0, MSG_COMMON_ERROR, NULL, 2, 0, lpszStrings, NULL);
		DeregisterEventSource(hEventSource);
	}
}
//******************************************************************************
