//******************************************************************************
#include "header.h"
#include "../myheader.h"
//==============================================================================
							// Внешние методы:
//------------------------------------------------------------------------------
// Обработать параметры командной строки
void CCmdLine::ProcessCmdLine(int argc, char* argv[])
{
	for (int i=1; i<argc; i++)
		if (argv[i][0] == '/' || argv[i][0] == '-')
			ProcessCmd(argv[i]+1);
		else
			throwe("incorrect command");
}
void CCmdLine::ProcessCmdLine(LPSTR lpCmdLine)
{ 
	int			argc = 0;
	char**		argv = NULL;
	unsigned int	i;
	int				j;

	// parse a few of the command line arguments 
	// a space delimites an argument except when it is inside a quote 

	__try
	{
		argc = 1;
		int pos = 0;
		for (i = 0; i < strlen(lpCmdLine); i++)
		{
			while (lpCmdLine[i] == ' ' && i < strlen(lpCmdLine))
				i++;
			if (lpCmdLine[i] == '\"')
			{
				i++;
				while (lpCmdLine[i] != '\"' && i < strlen(lpCmdLine))
				{
					i++;
					pos++;
				}
				argc++;
				pos = 0;
			}
			else
			{
				while (lpCmdLine[i] != ' ' && i < strlen(lpCmdLine))
				{
					i++;
					pos++;
				}
				argc++;
				pos = 0;
			}
		}

		chf(NULL, argv = (char**)malloc(sizeof(char*)* (argc+1)) );

		chf(NULL, argv[0] = (char*)malloc(1024) );
		ch(GetModuleFileName(0, argv[0], 1024));

		for(j=1; j<argc; j++)
		{
			chf(NULL, argv[j] = (char*)malloc(strlen(lpCmdLine)+10) );
		}
		argv[argc] = 0;

		argc = 1;
		pos = 0;
		for (i = 0; i < strlen(lpCmdLine); i++)
		{
			while (lpCmdLine[i] == ' ' && i < strlen(lpCmdLine))
			{
				i++;
			}
			if (lpCmdLine[i] == '\"')
			{
				i++;
				while (lpCmdLine[i] != '\"' && i < strlen(lpCmdLine))
				{
					argv[argc][pos] = lpCmdLine[i];
					i++;
					pos++;
				}
				argv[argc][pos] = '\0';
				argc++;
				pos = 0;
			}
			else
			{
				while (lpCmdLine[i] != ' ' && i < strlen(lpCmdLine))
				{
					argv[argc][pos] = lpCmdLine[i];
					i++;
					pos++;
				}
				argv[argc][pos] = '\0';
				argc++;
				pos = 0;
			}
		}
		argv[argc] = 0;

		ProcessCmdLine(argc, argv);
	}
	__finally
	{
		// Delete arguments
		for(j=0; j<argc; j++)
		{
			free(argv[j]);
		}
		free(argv);
	}
} 
//------------------------------------------------------------------------------
// Показать отчёт о работе
void CCmdLine::ShowReport()
{
	if (report != NULL)
		if (report[0] != 0)
			MessageBox(NULL, report, "Result of command line processing:", MB_ICONINFORMATION | MB_OK);
}
//------------------------------------------------------------------------------
// Конструктор
CCmdLine::CCmdLine()
{
	chf(NULL, report = new char[2]);
	report[0] = 0;
}
//------------------------------------------------------------------------------
// Просто деструктор
CCmdLine::~CCmdLine()
{
	if (report != NULL)
		delete[] report;
}
//------------------------------------------------------------------------------
							// Защищённые методы:
//------------------------------------------------------------------------------
// Добавить строку к отчёту
void CCmdLine::AddToReport(char *str)
{
	char * buf = NULL;
	size_t oldlen = strlen(report);
	size_t addlen = strlen(str);
	size_t len = oldlen + addlen + 1;
	chf(NULL, buf = new char[len]);
	if (-1 == sprintf(buf, "%s%s", report, str))
	{
		delete[] buf;
		throwe("sprintf");
	}
	char *del = report;
	report = buf;
	delete[] del;
}
//------------------------------------------------------------------------------
// Скопировать из str до lasts в buf
void CCmdLine::GetFirstStr(char *&str, char first, char *lasts, char *buf)
{
	if (*str == 0 || *str != first)
	{
		buf[0] = 0; // throwe("incorrect command format");
		return;
	}
	++str;
	size_t pos = strcspn(str, lasts);
	memcpy(buf, str, pos);
	buf[pos] = 0;
	str += pos;
}
//------------------------------------------------------------------------------
// Не начинается ли str на cmd?
bool CCmdLine::CmpCmd(char *str, char *cmd)
{
	size_t cmd_len = strlen(cmd);
	char *cstr = new char[cmd_len+1];
	strncpy(cstr, str, cmd_len);
	cstr[cmd_len] = 0;
	bool ret = stricmp(cstr, cmd) == 0;
	delete[] cstr;
	return ret;
}
//------------------------------------------------------------------------------
// Обработать один параметр командной строки
void CCmdLine::ProcessCmd(char *cmd)
{
	typedef void (CCmdLine::*PTranslater)(char *str);
	struct SCmd
	{
		char *name;
		PTranslater tr;
	};
	
	SCmd cmds[] =
	{
		{"install", &CCmdLine::TranslateInstall}, {"i", &CCmdLine::TranslateInstall},
		{"begin", &CCmdLine::TranslateBegin}, {"b", &CCmdLine::TranslateBegin},
		{"end", &CCmdLine::TranslateEnd}, {"e", &CCmdLine::TranslateEnd},
		{"remove", &CCmdLine::TranslateRemove}, {"r", &CCmdLine::TranslateRemove},

		{"command", &CCmdLine::TranslateCommand}, {"c", &CCmdLine::TranslateCommand},

		{"login", &CCmdLine::TranslateLogin}, {"li", &CCmdLine::TranslateLogin},
		{"logout", &CCmdLine::TranslateLogout}, {"lo", &CCmdLine::TranslateLogout},

		{"keys", &CCmdLine::TranslateKeys}, {"k", &CCmdLine::TranslateKeys},
		{"help", &CCmdLine::TranslateHelp}, {"h", &CCmdLine::TranslateHelp}, {"?", &CCmdLine::TranslateHelp},
		{"quiet", &CCmdLine::TranslateQuiet}, {"q", &CCmdLine::TranslateQuiet}
	};

	for (int i = 0; i < sizeof(cmds)/sizeof(SCmd); i++)
		if (CmpCmd(cmd, cmds[i].name))
		{
			(this->*(cmds[i].tr)) (cmd + strlen(cmds[i].name));
			return;
		}
	throwe("unknown key, use \"/?\" for help");
}
//------------------------------------------------------------------------------
// Управление менеджером сервисов:
//------------------------------------------------------------------------------
// -i[nstall][:file[@host]]
void CCmdLine::TranslateInstall(char *str)
{
	AddToReport("'-install' starting ...");
	char file[MAX_PATH], host[MAX_PATH];
	GetFirstStr(str, ':', "@", file);
	GetFirstStr(str, '@', "", host);
	ProcessInstall(file, host);
	AddToReport("\t\tdone.\n");
}
void CCmdLine::ProcessInstall(char *file, char *host)
{
	if (*host == 0) host = NULL;
	if (*file == 0) file = NULL;
	if (file==NULL && host!=NULL) throwe("file name absent");
	if (file!=NULL)
		SCfgP->Install(file, host);
	else
		SCfgP->InstallSelf();
}
//------------------------------------------------------------------------------
// -b[egin][@host]
void CCmdLine::TranslateBegin(char *str)
{
	AddToReport("'-begin' starting ...");
	char host[MAX_PATH];
	GetFirstStr(str, '@', "", host);
	ProcessBegin(host);
	AddToReport("\t\tdone.\n");
}
void CCmdLine::ProcessBegin(char *host)
{
	if (*host == 0) host = NULL;
	SCfgP->Begin(NULL, NULL, host);
}
//------------------------------------------------------------------------------
// -e[nd][@host]
void CCmdLine::TranslateEnd(char *str)
{
	AddToReport("'-end' starting ...");
	char host[MAX_PATH];
	GetFirstStr(str, '@', "", host);
	ProcessEnd(host);
	AddToReport("\t\tdone.\n");
}
void CCmdLine::ProcessEnd(char *host)
{
	if (*host == 0) host = NULL;
	SCfgP->End(NULL, NULL, host);
}
//------------------------------------------------------------------------------
// -r[emove][@host]
void CCmdLine::TranslateRemove(char *str)
{
	AddToReport("'-remove' starting ...");
	char host[MAX_PATH];
	GetFirstStr(str, '@', "", host);
	ProcessRemove(host);
	AddToReport("\tdone.\n");
}
void CCmdLine::ProcessRemove(char *host)
{
	if (*host == 0) host = NULL;
	SCfgP->Remove(host);
}
//------------------------------------------------------------------------------
// Управление сервисом:
//------------------------------------------------------------------------------
// -c[ommand]:cmd[@host]
void CCmdLine::TranslateCommand(char *str)
{
	AddToReport("'-command' starting ...");
	char cmd[MAX_PATH];
	char host[MAX_PATH];

	GetFirstStr(str, ':', "", cmd);
	GetFirstStr(str, '@', "", host);

	ProcessCommand(cmd, host);
	AddToReport("\tdone.\n");
}
void CCmdLine::ProcessCommand(char *cmd, char *host)
{
	if (*cmd == 0) cmd = NULL;
	if (*host == 0) host = NULL;
	if (cmd == NULL) throwe("command text absent");

	char * buf = NULL;
	size_t len = strlen(cmd);
	chf(NULL, buf = new char[len+2+4]);
	__try
	{
		chf(-1, len = sprintf(buf, "%s\n", cmd));
		SCtrlP->Connect(host);
		SCtrlP->SendCommand(buf, (int)len);
		SCtrlP->Disconnect();
	}
	__finally
	{
		if (buf != NULL)
            delete[] buf;
	}
}
//------------------------------------------------------------------------------
// Работа с сетью:
//------------------------------------------------------------------------------
// -login:[user[:pass]]@host или -li
void CCmdLine::TranslateLogin(char *str)
{
	AddToReport("'-login' starting ...");
	char user[MAX_PATH], pass[MAX_PATH], host[MAX_PATH];
	GetFirstStr(str, ':', ":@", user);
	GetFirstStr(str, ':', "@", pass);
	GetFirstStr(str, '@', "", host);
	ProcessLogin(user, pass, host);
	AddToReport("\t\tdone.\n");
}
void CCmdLine::ProcessLogin(char *user, char *pass, char *host)
{
	if (*user == 0) user = NULL;
	if (*pass == 0) pass = NULL;
	if (*host == 0) host = NULL;
	if (pass!=NULL && user==NULL) throwe("user name absent");
	if (host == NULL) throwe("host name absent");

	char buf[MAX_PATH];
	chf(-1, sprintf(buf, "\\\\%s\\IPC$", host));
	AddShare(user, pass, buf);
}
//------------------------------------------------------------------------------
// -lo[gout]@host
void CCmdLine::TranslateLogout(char *str)
{
	AddToReport("'-logout' starting ...");
	char host[MAX_PATH];
	GetFirstStr(str, '@', "", host);
	ProcessLogout(host);
	AddToReport("\t\tdone.\n");
}
void CCmdLine::ProcessLogout(char *host)
{
	if (*host == 0) host = NULL;
	if (host == NULL) throwe("host name absent");

	char buf[MAX_PATH];
	chf(-1, sprintf(buf, "\\\\%s\\IPC$", host));
	DelShare(buf);
}
//------------------------------------------------------------------------------
// Всмомогательные функции:
//------------------------------------------------------------------------------
// -keys или -k
void CCmdLine::TranslateKeys(char *str)
{
	if (*str != 0) throwe("params in -key command");
	AddToReport("wowdsrv.exe -i[:file[@host]]\n");
	AddToReport("wowdsrv.exe -b[@host]\n");
	AddToReport("wowdsrv.exe -e[@host]\n");
	AddToReport("wowdsrv.exe -r[@host]\n");
	AddToReport("\n");
	AddToReport("wowdsrv.exe -c:cmd[@host]\n");
	AddToReport("\n");
	AddToReport("wowdsrv.exe -li:[user[:pass]]@host\n");
	AddToReport("wowdsrv.exe -lo@host\n");
	AddToReport("\n");
	AddToReport("wowdsrv.exe -k\n");
	AddToReport("wowdsrv.exe -h\n");
	AddToReport("wowdsrv.exe -q\n");
}
//------------------------------------------------------------------------------
// -help или -h или -?
void CCmdLine::TranslateHelp(char *str)
{
	if (*str != 0) throwe("params in -help command");
	AddToReport("Control Service Manager:\n");
	AddToReport("	wowdsrv.exe -i[nstall][:file[@host]]\n");
	AddToReport("	wowdsrv.exe -b[egin][@host]\n");
	AddToReport("	wowdsrv.exe -e[nd][@host]\n");
	AddToReport("	wowdsrv.exe -r[emove][@host]\n");
	AddToReport("		Install/Run/Stop/Remove service\n");
	AddToReport("\n");
	AddToReport("Control of the service:\n");
	AddToReport("	wowdsrv.exe -c[ommand]:cmd[@host]\n");
	AddToReport("		Send cmd to WoWD's console on host\n");
	AddToReport("\n");
	AddToReport("Working with a network:\n");
	AddToReport("	wowdsrv.exe -login:[user[:pass]]@host or -li\n");
	AddToReport("		Add all needed resources (IPC$) for communication\n");
	AddToReport("	wowdsrv.exe -lo[gout]@host\n");
	AddToReport("		Remove connection to needed resources (IPC$)\n");
	AddToReport("\n");
	AddToReport("Additional functions:\n");
	AddToReport("	wowdsrv.exe -keys or -k\n");
	AddToReport("		Short keys list\n");
	AddToReport("	wowdsrv.exe -help or -h or -?\n");
	AddToReport("		This text\n");
	AddToReport("	wowdsrv.exe -q[uiet]\n");
	AddToReport("		Do not show message box with report for previous commands\n");
}
//------------------------------------------------------------------------------
// -quiet или -q
void CCmdLine::TranslateQuiet(char *str)
{
	if (*str != 0) throwe("params in -quiet command");
	report[0] = 0;
}
//******************************************************************************
