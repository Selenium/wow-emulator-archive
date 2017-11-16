//******************************************************************************
#include "header.h"
#include "../myheader.h"
//==============================================================================
CPCTSTR				CSCfgP::service_name = SERVICE_NAME;
CPCTSTR				CSCfgP::service_display_name = SERVICE_DISPLAY_NAME;
//==============================================================================
							// Внешние методы:
//------------------------------------------------------------------------------
// Gets current module name and installs it
void CSCfgP::InstallSelf()
{
	uint len = MAX_PATH;
	char * filename = NULL;
	char * buf = NULL;
	chf(NULL, filename = new char[len]);
	__try
	{
retry:
		DWORD ret = GetModuleFileName(NULL, filename, len);
		if (ret == 0) // error
			throwe("GetModuleFileName");
		else if (ret == len)
		{
			delete[] filename;
			len *= 2;
			chf(NULL, filename = new char[len]);
			goto retry;
		}
		// ok, now len = length of string, filename = filename :)
		
		CError::AddEventSource("Application", "\"WDDG Ludmilla\" service", filename, 0);

		chf(NULL, buf = new char[len+9]);
		sprintf(buf, "%s -service", filename);
		Install(buf);
	}
	__finally
	{
		if (buf != NULL)
			delete[] buf;
		if (filename != NULL)
			delete[] filename;
	}
}
//------------------------------------------------------------------------------
// Устанавливает сервис в систему
void CSCfgP::Install(CPCSTR FileName, char *host)
{
	char *Machine = NULL;
	SC_HANDLE schService = NULL;
	SC_HANDLE schSCManager = NULL;

	__try
	{
		if (host != NULL)
		{
			chf(NULL, Machine = new char[strlen(host)+3]);
			chf(-1, sprintf(Machine, "\\\\%s", host));
		}

		schSCManager = OpenSCManager(Machine, NULL, SC_MANAGER_CREATE_SERVICE);
		if (schSCManager == NULL)
			throwe("OpenSCManager");
		schService = CreateService(schSCManager, service_name,
						service_display_name, 0,
						SERVICE_WIN32_OWN_PROCESS,// | SERVICE_INTERACTIVE_PROCESS,
						SERVICE_AUTO_START, SERVICE_ERROR_IGNORE, FileName,
						NULL, NULL, NULL, NULL, NULL);
		if (schService == NULL)
			throwe("CreateService");
	}
	__finally
	{
		if (schService != NULL)
			CloseServiceHandle(schService);
		if (schSCManager != NULL)
			CloseServiceHandle(schSCManager);
		if (Machine != NULL)
			delete[] Machine;
	}
}
//------------------------------------------------------------------------------
// Запускает сервис
void CSCfgP::Begin(void(*notify)(void*), void* data, char *host)
{
	char *Machine = NULL;
	SC_HANDLE schService = NULL;
	SC_HANDLE schSCManager = NULL;

	__try
	{
		if (host != NULL)
		{
			chf(NULL, Machine = new char[strlen(host)+3]);
			chf(-1, sprintf(Machine, "\\\\%s", host));
		}

		schSCManager = OpenSCManager(Machine, NULL, SC_MANAGER_CONNECT);
		if (schSCManager == NULL)
			throwe("OpenSCManager");
		schService = OpenService(schSCManager, service_name,
									SERVICE_START | SERVICE_QUERY_STATUS);
		if (schService == NULL)
			throwe("OpenService");

		SERVICE_STATUS ssStatus;
		chf(FALSE, StartService(schService, 0, NULL));
		chf(FALSE, QueryServiceStatus(schService, &ssStatus));

		DWORD dwStartTickCount = GetTickCount();
		DWORD dwOldCheckPoint = ssStatus.dwCheckPoint;
		while (ssStatus.dwCurrentState == SERVICE_START_PENDING)
		{
			// Жду установски новой контрольной точки сервисом одну
			// десятую dwWaitHint, но не меньше, чем секунду и не
			// больше чем 10 секунд:
			DWORD dwWaitTime = min(max(ssStatus.dwWaitHint/10, 100), 1000);
			Sleep(dwWaitTime);
			if (notify != NULL)
				notify(data);

			// Проверяю статус снова:
			chf(FALSE, QueryServiceStatus(schService, &ssStatus));
			if (ssStatus.dwCurrentState != SERVICE_START_PENDING)
				break;

			if (ssStatus.dwCheckPoint > dwOldCheckPoint)
			{ // Сервис обновил своё состояние
				dwStartTickCount = GetTickCount();
				dwOldCheckPoint = ssStatus.dwCheckPoint;
			}
			else
				if(GetTickCount()-dwStartTickCount > ssStatus.dwWaitHint)
					throwe("Не удалось запустить сервис. Сервис не отвечает.");
		}
		if (ssStatus.dwCurrentState != SERVICE_RUNNING)
			throwe("Не удалось запустить сервис. Сервис прервал запуск.");
	}
	__finally
	{
		if (schService != NULL)
			CloseServiceHandle(schService);
		if (schSCManager != NULL)
			CloseServiceHandle(schSCManager);
		if (Machine != NULL)
			delete[] Machine;
	}
}
//------------------------------------------------------------------------------
// Останавливает сервис
void CSCfgP::End(void(*notify)(void*), void* data, char *host)
{
	char *Machine = NULL;
	SC_HANDLE schService = NULL;
	SC_HANDLE schSCManager = NULL;

	__try
	{
		if (host != NULL)
		{
			chf(NULL, Machine = new char[strlen(host)+3]);
			chf(-1, sprintf(Machine, "\\\\%s", host));
		}

		schSCManager = OpenSCManager(Machine, NULL, SC_MANAGER_CONNECT);
		if (schSCManager == NULL)
			throwe("OpenSCManager");
		schService = OpenService(schSCManager, TEXT(service_name), SERVICE_STOP | SERVICE_QUERY_STATUS);
		if (schService == NULL)
			throwe("OpenService");

		SERVICE_STATUS ssStatus;
		// Пытаюсь остановить сервис:
		chf(FALSE, ControlService(schService, SERVICE_CONTROL_STOP, &ssStatus));

		DWORD dwStartTickCount = GetTickCount();
		DWORD dwOldCheckPoint = ssStatus.dwCheckPoint;
		while (ssStatus.dwCurrentState == SERVICE_STOP_PENDING)
		{
			// Жду установски новой контрольной точки сервисом одну
			// десятую dwWaitHint, но не меньше, чем секунду и не
			// больше чем 10 секунд:
			DWORD dwWaitTime = min(max(ssStatus.dwWaitHint/10, 100), 1000);
			Sleep(dwWaitTime);
			if (notify != NULL)
				notify(data);

			// Проверяю статус снова:
			chf(FALSE, QueryServiceStatus(schService, &ssStatus));
			if (ssStatus.dwCurrentState != SERVICE_STOP_PENDING)
				break;

			if (ssStatus.dwCheckPoint > dwOldCheckPoint)
			{ // Сервис обновил своё состояние
				dwStartTickCount = GetTickCount();
				dwOldCheckPoint = ssStatus.dwCheckPoint;
			}
			else
				if(GetTickCount()-dwStartTickCount > ssStatus.dwWaitHint)
					throwe("Не удалось остановить сервис. Сервис не отвечает.");
		}
		if (ssStatus.dwCurrentState != SERVICE_STOPPED)
			throwe("Не удалось остановить сервис. Сервис прервал останов.");
	}
	__finally
	{
		if (schService != NULL)
			CloseServiceHandle(schService);
		if (schSCManager != NULL)
			CloseServiceHandle(schSCManager);
		if (Machine != NULL)
			delete[] Machine;
	}
}
//------------------------------------------------------------------------------
// Удаляет сервис
void CSCfgP::Remove(char *host)
{
	char *Machine = NULL;
	SC_HANDLE schService = NULL;
	SC_HANDLE schSCManager = NULL;

	__try
	{
		if (host != NULL)
		{
			chf(NULL, Machine = new char[strlen(host)+3]);
			chf(-1, sprintf(Machine, "\\\\%s", host));
		}

		schSCManager = OpenSCManager(Machine, NULL, SC_MANAGER_ALL_ACCESS);
		if (schSCManager == NULL)
			throwe("OpenSCManager");
		schService = OpenService(schSCManager, service_name, DELETE);
		if (schService == NULL)
			throwe("OpenService");
		chf(FALSE, DeleteService(schService));
	}
	__finally
	{
		if (schService != NULL)
			CloseServiceHandle(schService);
		if (schSCManager != NULL)
			CloseServiceHandle(schSCManager);
		if (Machine != NULL)
			delete[] Machine;
	}
}
//------------------------------------------------------------------------------
// Проверить статус сервиса
void CSCfgP::GetInfo(bool &exists, bool &running, char *host)
{
	char *Machine = NULL;
	SC_HANDLE schService = NULL;
	SC_HANDLE schSCManager = NULL;
	DWORD e;
	SERVICE_STATUS ssStatus;

	__try
	{
		if (host != NULL)
		{
			chf(NULL, Machine = new char[strlen(host)+3]);
			chf(-1, sprintf(Machine, "\\\\%s", host));
		}

		schSCManager = OpenSCManager(Machine, NULL, SC_MANAGER_CONNECT);
		if (schSCManager == NULL)
			throwe("OpenSCManager");
		schService = OpenService(schSCManager, service_name, SERVICE_QUERY_STATUS);
		if (schService == NULL)
		{
			e = GetLastError();
			if (e == ERROR_SERVICE_DOES_NOT_EXIST)
			{
				exists = running = false;
				return;
			}
			else
				throwe_code("OpenService", e);
		}
		
		chf(FALSE, QueryServiceStatus(schService, &ssStatus));
		running = (ssStatus.dwCurrentState!=SERVICE_STOPPED);
		exists = true;
	}
	__finally
	{
		if (schService != NULL)
			CloseServiceHandle(schService);
		if (schSCManager != NULL)
			CloseServiceHandle(schSCManager);
		if (Machine != NULL)
			delete[] Machine;
	}
}
//******************************************************************************
