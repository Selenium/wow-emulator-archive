//******************************************************************************
typedef void (*PNotifyFunc)(); // Просто функция
//==============================================================================
class CSCfgP // Service Configuration Program
{
public:						// Внешние методы:

	// Gets current module name and installs it
	void InstallSelf();

	// Устанавливает сервис в систему
	void Install(CPCSTR FileName, char *host = NULL);

	// Запускает сервис
	void Begin(void(*notify)(void*), void* data, char *host = NULL);

	// Останавливает сервис
	void End(void(*notify)(void*), void* data, char *host = NULL);

	// Удаляет сервис
	void Remove(char *host = NULL);

	// Проверить статус сервиса
	void GetInfo(bool &exists, bool &running, char *host = NULL);

protected:					// Защищённые константы:

	// Внутреннее имя сервиса
	static CPCTSTR service_name;

	// Экранное имя сервиса
	static CPCTSTR service_display_name;
};
//******************************************************************************
