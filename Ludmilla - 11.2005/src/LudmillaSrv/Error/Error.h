//******************************************************************************
#ifdef _DEBUG
	#define throwe_code(text, code) throw CError(__FILE__, __LINE__, (text), (code))
#else
	#define throwe_code(text, code) throw CError((text), (code))
#endif

#define throwe(text) throwe_code((text), GetLastError())
#define chf(fail, func) ((func)==(fail)?0,throwe(#func):0);
#define ch(func) chf(0, func)

#define throwe_net(text) throwe_code((text), WSAGetLastError())
#define chf_net(fail, func) ((func)==(fail)?0,throwe_net(#func):0);
//==============================================================================
class CError
{
public:
	static void AddEventSource(
		LPTSTR pszLogName,	// Application log or a custom log
		LPTSTR pszSrcName,	// event source name
		LPTSTR pszMsgDLL,	// path for message DLL
		DWORD  dwNum);		// number of categories
	static void MyReportEvent(
		LPTSTR pszSrcName,	// event source name
		DWORD dwEventID,	// event identifier
		WORD wCategory,		// event category
		WORD cInserts,		// count of insert strings
		LPCTSTR *szMsg);	// insert strings

	// Вывести сообщение
	void Info();

	// Вывести сообщение в консоль (в cerr)
	void ToCON();

	// Вывести сообщение MessageBox'ом
	void ToGUI(HWND Parent = NULL, CPCTSTR lpCaption = "Error Information", UINT uType = MB_OK|MB_ICONERROR);

	// Вывести сообщение в журнал событий
	void ToEventLog();

	// Конструктор копирования
	CError(const CError &e);

	// Конструктор для полной информации об ошибке
	CError(char *srcfn, int srcln, char *text, DWORD code);

	// Конструктор для сжатой информации об ошибке
	CError(char *text = NULL, DWORD code = 0);

	// Деструктор класса
	~CError();

	// Получить код ошибки
	DWORD GetCode() const;

private:
	// Добавить строку в журнал событий
	void AddToMessageLog(LPTSTR lpszMsg);

	// Текст, поясняющий ошибку
	char *str;

	// Код ошибки
	DWORD code;
};
//******************************************************************************
