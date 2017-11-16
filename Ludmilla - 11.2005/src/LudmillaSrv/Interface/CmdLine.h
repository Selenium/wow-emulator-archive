//******************************************************************************
class CCmdLine // Разбор коммандной строки
{
public:						// Внешние методы:

	// Обработать параметры командной строки
	void ProcessCmdLine(int argc, char* argv[]);
	void ProcessCmdLine(LPSTR lpCmdLine);

	// Показать отчёт о работе
	void ShowReport();

	// Конструктор
	CCmdLine();

	// Просто деструктор
	~CCmdLine();

protected:					// Защищённые методы:

	// Добавить строку к отчёту
	void AddToReport(char *str);

	// Не начинается ли str на cmd?
	bool CmpCmd(char *str, char *cmd);

	// Скопировать из str до lasts в buf
	void GetFirstStr(char *&str, char first, char *lasts, char *buf);

	// Обработать один параметр командной строки
	void ProcessCmd(char *cmd);

// Управление менеджером сервисов:

	// -i[nstall][:file[@host]]
	void TranslateInstall(char *str);
	void ProcessInstall(char *file, char *host);

	// -b[egin][@host]
	void TranslateBegin(char *str);
	void ProcessBegin(char *host);

	// -e[nd][@host]
	void TranslateEnd(char *str);
	void ProcessEnd(char *host);

	// -r[emove][@host]
	void TranslateRemove(char *str);
	void ProcessRemove(char *host);

// Управление сервисом:

	// -c[ommand]:cmd[@host]
	void TranslateCommand(char *str);
	void ProcessCommand(char *cmd, char *host);

// Работа с сетью:

	// -login:[user[:pass]]@host или -li
	void TranslateLogin(char *str);
	void ProcessLogin(char *user, char *pass, char *host);

	// -lo[gout]@host
	void TranslateLogout(char *str);
	void ProcessLogout(char *host);

// Всмомогательные функции:

	// -keys или -k
	void TranslateKeys(char *str);

	// -help или -h или -?
	void TranslateHelp(char *str);

	void TranslateQuiet(char *str);

							// Защищённые данные:

	// Отчёт о работе
	char * report;

};
//==============================================================================
extern CCmdLine CmdLine;
//******************************************************************************
