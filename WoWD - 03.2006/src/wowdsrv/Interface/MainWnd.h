//******************************************************************************
enum EPalcaPosition // Rotating line position
{
	epp_h = 1,	// -
	epp_hv = 2,	// '\'
	epp_v = 3,  // |
	epp_vh = 4	// /
};
//------------------------------------------------------------------------------
class CPalka // Rotating prograss line
{
public:
	char Get() const
		{
			switch (state)
			{
				case epp_h:  return '-';
				case epp_hv: return '\\';
				case epp_v:  return '|';
				case epp_vh: return '/';
				default: throwe("invalid state");
			}
		};
	void Next()
		{
			switch (state)
			{
				case epp_h:  state = epp_hv;
					break;
				case epp_hv:  state = epp_v;
					break;
				case epp_v:  state = epp_vh;
					break;
				case epp_vh:  state = epp_h;
					break;
			}
		};
	CPalka() { state = epp_h; };
protected:
	EPalcaPosition state;
};
//==============================================================================
class CMainWnd // Главное окно
{
public:						// Внешние методы:

	// Создать и отобразить окно
	void Show(HWND hParent);

	// Просто конструктор
	CMainWnd();

	// Деструктор класса
	~CMainWnd();

protected:					// Защищённые данные:

	// Дескриптор окна
	HWND hWnd;

	// Индикатор работы
	CPalka palka;

							// Защищённые методы:

	// Allocs (with "new") string with remote host name, or NULL
	char* GetRemoteHost();

	// Задисаблить окно нормально
	bool ChEnableWindow(HWND hWnd, bool enable);

	// Получить хендл элемента нормально
	HWND ChGetDlgItem(int id);

	// Задисаблить окно нормально по id
	bool ChEnableWindowID(int id, bool enable);

	// Отмечен ли флаг
	bool ChIsCheckedID(int id);

	// Вывести, что работа идёт
	static void Running(void* data);

	// Заэнаблить группу "управление"
	void EnableControlGroup(bool enable);

	// Заэнаблить группу "удалённое"
	void EnableRemoteGroup(bool enable, bool labletrue = false);

	// Установить начальные настройки интерфейса
	void OnInit();

	// Зарегистрировать сервис
	void OnRegister();

	// Удалить сервис
	void OnUnRegister();

	// Запустить сервис
	void OnStart();

	// Остановить сервис
	void OnStop();

	// Connect to server
	void OnConnect();

	// Disconnect from server
	void OnDisconnect();

	// Send command to server
	void OnCommand();

	// Login into remote machine
	void OnLogin();

	// Logout from remote machine
	void OnLogout();

	// Оконная процедура диалогового окна
	static INT_PTR CALLBACK DialogProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam);

							// Защищённые константы

	// Заголовок окна
	static CPCTSTR caption;
};
//******************************************************************************
