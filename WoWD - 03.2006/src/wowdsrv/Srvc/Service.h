//******************************************************************************
class CService // Собственно сервис
{
public:						// Внешние методы:

	// Главная функция сервиса
	static void main();

	// Точка входа сервиса
	static VOID WINAPI ServiceMain(DWORD dwArgc, LPTSTR *lpszArgv);

							// Внешние константы:

	// Внутреннее имя сервиса
	static CPCTSTR service_name;

	// Экранное имя сервиса
	static CPCTSTR service_display_name;

protected:					// Защищённые методы:

	// Обработчик команд
	static VOID WINAPI Handler(DWORD fdwControl);

	// Сообщить статус SCM'ру
	static void ReportStatusToSCMgr(DWORD dwCurrentState, DWORD dwWaitHint);

	// Инициализирует сервис
	static void ServiceInitialization();

	// Рабочая процедура сервиса
	static void ServiceRun(DWORD dwArgc, LPTSTR *lpszArgv);

	// Останавливает сервис
	static void ServiceStop();

	// Если _DEBUG - вывести MessageBox с текстом об ошибке, записать в журнал
	inline static void MessageError(CError &e);

							// Защищённые данные:

	// Состояние службы
	volatile static DWORD					CurrentState;
	volatile static SERVICE_STATUS_HANDLE	ServiceStatusHandle;
	volatile static HANDLE					hStopEvent;
	volatile static DWORD					Win32ExitCode;
	static SERVICE_STATUS					ServiceStatus;

	// Получена команда "остановиться"
	volatile static bool stop_command;

	// Класс, запускающий задачу
	static CRunner *runner;
};
//******************************************************************************
