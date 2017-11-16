//******************************************************************************
#include "header.h"
#include "../myheader.h"
//==============================================================================
CPCTSTR				CRunner::server_program_image = SERVER_PROGRAM_IMAGE;
CPCTSTR				CRunner::server_program_stdout_pipe = SERVER_PROGRAM_STDOUT_PIPE;
CPCTSTR				CRunner::server_program_stdin_pipe = SERVER_PROGRAM_STDIN_PIPE;
CPCTSTR				CRunner::server_program_stdout_pipe_internal = SERVER_PROGRAM_STDOUT_PIPE_INTERNAL;
CPCTSTR				CRunner::server_program_stdin_pipe_internal = SERVER_PROGRAM_STDIN_PIPE_INTERNAL;
PTSTR				CRunner::kill_stepson_cmd = KILL_STEPSON_CMD;
//==============================================================================
#define BUF_SIZE 80
//==============================================================================
							// Внешние методы:
//------------------------------------------------------------------------------
// Запустить (выполняется до установленного stopevent)
void CRunner::Start(HANDLE stopevent)
{
	__try
	{
		CreateEvents();

		CreateIntPipesSafe();
		ConnectToChild();

		CreatePublicPipes();

		ChDirToHome();
		CreateChildProcess();

		Transmission(stopevent);

		Stop();
	}
	__finally
	{
		TryClose(hChildStdInR);
		TryClose(hChildStdInW);
		TryClose(hChildStdOutW);
		TryClose(hChildStdOutR);

		TryClose(hwowdStdOutW);
		TryClose(hwowdStdInR);

		TryClose(hEventChild);
		TryClose(hEventClient);

		if (hChildProcess != INVALID_HANDLE_VALUE)
		{
			if (!WaitForChild(1000))
				Kill();
			TryClose(hChildProcess);
		}
	}
}
//------------------------------------------------------------------------------
// Послать запущеной программе Ctrl-C
void CRunner::Stop()
{
	if (hChildProcess != INVALID_HANDLE_VALUE)
		switch(WaitForSingleObject(hChildProcess, 0))
		{
			case WAIT_TIMEOUT:
				// win bug: WaitForInputIdle ignors consoles, but it was only way to wait...
				// in result we need to wait
				for (int i=0; i<10; i++)
					if (AttachConsole(ChildProcessID) == 0)
					{
						if (GetLastError() != ERROR_INVALID_HANDLE && GetLastError() != ERROR_ACCESS_DENIED) // errors i've gotten
							throwe("AttachConsole");
						else
							Sleep(100);
					}
					else
						break;
				ch(GenerateConsoleCtrlEvent(CTRL_C_EVENT, ChildProcessID));
				break;
			default:
				throwe("WaitForSingleObject");
		}
}
//------------------------------------------------------------------------------
// Wait until child process ends
bool CRunner::WaitForChild(DWORD dwMilliseconds)
{
	if (hChildProcess == INVALID_HANDLE_VALUE)
		return true;
	switch(WaitForSingleObject(hChildProcess, dwMilliseconds))
	{
		case WAIT_OBJECT_0:
			return true;
		case WAIT_TIMEOUT:
			return false;
		default:
			throwe("WaitForSingleObject");
	}
}
//------------------------------------------------------------------------------
// Terminate child process
void CRunner::Kill()
{
	if (hChildProcess == INVALID_HANDLE_VALUE)
		return;
	switch(WaitForSingleObject(hChildProcess, 0))
	{
		case WAIT_OBJECT_0:
			TryClose(hChildProcess);
			return;
		case WAIT_TIMEOUT:
			ch(TerminateProcess(hChildProcess, (uint)-1));
			return;
		default:
			throwe("WaitForSingleObject");
	}
}
//------------------------------------------------------------------------------
// Конструктор
CRunner::CRunner()
{
	hChildStdInR = hChildStdInW = hChildStdOutW = hChildStdOutR = INVALID_HANDLE_VALUE;
	hwowdStdOutW = hwowdStdInR = INVALID_HANDLE_VALUE;
	hChildProcess = INVALID_HANDLE_VALUE;
	hEventChild = hEventClient = INVALID_HANDLE_VALUE;
	ChildProcessID = 0;
}
//------------------------------------------------------------------------------
// Просто деструктор
CRunner::~CRunner()
{
	TryClose(hChildStdInR);
	TryClose(hChildStdInW);
	TryClose(hChildStdOutW);
	TryClose(hChildStdOutR);

	TryClose(hwowdStdOutW);
	TryClose(hwowdStdInR);

	TryClose(hEventChild);
	TryClose(hEventClient);

	if (hChildProcess != INVALID_HANDLE_VALUE)
	{
		if (!WaitForChild(1000))
            Kill();
		TryClose(hChildProcess);
	}
}

//------------------------------------------------------------------------------
							// Защищённые методы:
//------------------------------------------------------------------------------
// Terminate child process of other instance of service
void CRunner::KillStepson()
{
	PROCESS_INFORMATION pi;
	STARTUPINFO si;
	ZeroMemory(&pi, sizeof(PROCESS_INFORMATION));
	ZeroMemory(&si, sizeof(STARTUPINFO));

	ch(CreateProcess(
		NULL,						// ApplicationName
		kill_stepson_cmd,			// CommandLine
		NULL,						// returned process handle cannot be inherited
		NULL,						// returned thread handle cannot be inherited
		FALSE,						// handles are not inherited
		0,							// creation flags
		NULL,						// use parent's environment
		NULL,						// use parent's current directory
		&si,						// STARTUPINFO pointer
		&pi							// receives PROCESS_INFORMATION
		));

	chf(WAIT_FAILED, WaitForSingleObject(pi.hProcess, 10000));
	ch(CloseHandle(pi.hThread));
	ch(CloseHandle(pi.hProcess));
}
//------------------------------------------------------------------------------
// Create service's pipes for communication with client
void CRunner::CreatePublicPipes()
{
	char * outname = NULL;
	char * inname = NULL;
	__try
	{
		outname = MakePipeName(server_program_stdout_pipe, NULL);
		inname = MakePipeName(server_program_stdin_pipe, NULL);

		// Create named pipes:
		chf(INVALID_HANDLE_VALUE, hwowdStdOutW = CreateNamedPipe(outname,
			PIPE_ACCESS_OUTBOUND		// from server to client only
			|FILE_FLAG_WRITE_THROUGH	// Write-through mode is enabled
			|FILE_FLAG_OVERLAPPED,
			PIPE_TYPE_BYTE				// written as a stream of bytes
			|PIPE_READMODE_BYTE			// read from as a stream of bytes
			|PIPE_WAIT,					// operations are not completed until there is data
			1,							// max number of instances
			BUF_SIZE,					// for the output buffer
			BUF_SIZE,					// for the input buffer
			NMPWAIT_WAIT_FOREVER,		// Default time-out value for WaitNamedPipe
			NULL						// security attribute
			));

		chf(INVALID_HANDLE_VALUE, hwowdStdInR = CreateNamedPipe(inname,
			PIPE_ACCESS_INBOUND			// from client to server only
			|FILE_FLAG_WRITE_THROUGH	// Write-through mode is enabled
			|FILE_FLAG_OVERLAPPED,
			PIPE_TYPE_BYTE				// written as a stream of bytes
			|PIPE_READMODE_BYTE			// read from as a stream of bytes
			|PIPE_WAIT,					// operations are not completed until there is data
			1,							// max number of instances
			BUF_SIZE,					// for the output buffer
			BUF_SIZE,					// for the input buffer
			NMPWAIT_WAIT_FOREVER,		// Default time-out value for WaitNamedPipe
			NULL						// security attribute
			));
	}
	__finally
	{
		if (outname != NULL)
			delete[] outname;
		if (inname != NULL)
			delete[] inname;
	}
}
//------------------------------------------------------------------------------
void WaitForFreeIntPipe(char * name, DWORD nTimeOut)
{
	if (WaitNamedPipe(name, nTimeOut) == 0)
	{
		DWORD e = GetLastError();
		if (e != ERROR_FILE_NOT_FOUND)
			throwe_code("WaitNamedPipe", e);
	}
}
//------------------------------------------------------------------------------
// Create pipes for child process StdIn and StdOut
void CRunner::CreateIntPipes(DWORD nTimeOut)
{
	char * outname = NULL;
	char * inname = NULL;
	__try
	{
		outname = MakePipeName(server_program_stdout_pipe_internal, NULL);
		inname = MakePipeName(server_program_stdin_pipe_internal, NULL);

		// Set the bInheritHandle flag so pipe handles are inherited:
		SECURITY_ATTRIBUTES saAttr;
		saAttr.nLength = sizeof(SECURITY_ATTRIBUTES);
		saAttr.bInheritHandle = TRUE;
		saAttr.lpSecurityDescriptor = NULL;

		if (nTimeOut > 0)
			WaitForFreeIntPipe(outname, nTimeOut);
		chf(INVALID_HANDLE_VALUE, hChildStdOutW = CreateNamedPipe(outname,
			PIPE_ACCESS_OUTBOUND		// from server to client only
			|FILE_FLAG_WRITE_THROUGH	// Write-through mode is enabled
			|FILE_FLAG_OVERLAPPED,
			PIPE_TYPE_BYTE				// written as a stream of bytes
			|PIPE_READMODE_BYTE			// read from as a stream of bytes
			|PIPE_WAIT,					// operations are not completed until there is data
			1,							// max number of instances
			BUF_SIZE,					// for the output buffer
			BUF_SIZE,					// for the input buffer
			NMPWAIT_WAIT_FOREVER,		// Default time-out value for WaitNamedPipe
			&saAttr						// security attribute
			));
		if (nTimeOut > 0)
			WaitForFreeIntPipe(inname, nTimeOut);
		chf(INVALID_HANDLE_VALUE, hChildStdInR = CreateNamedPipe(inname,
			PIPE_ACCESS_INBOUND			// from client to server only
			|FILE_FLAG_WRITE_THROUGH	// Write-through mode is enabled
			|FILE_FLAG_OVERLAPPED,
			PIPE_TYPE_BYTE				// written as a stream of bytes
			|PIPE_READMODE_BYTE			// read from as a stream of bytes
			|PIPE_WAIT,					// operations are not completed until there is data
			1,							// max number of instances
			BUF_SIZE,					// for the output buffer
			BUF_SIZE,					// for the input buffer
			NMPWAIT_WAIT_FOREVER,		// Default time-out value for WaitNamedPipe
			&saAttr						// security attribute
			));
	}
	__finally
	{
		if (outname != NULL)
			delete[] outname;
		if (inname != NULL)
			delete[] inname;
	}
}
//------------------------------------------------------------------------------
// Additionally checks for process of other instance of service
void CRunner::CreateIntPipesSafe()
{
	try
	{
		CreateIntPipes();
		return;
	}
	catch (CError &e)
	{
		if (e.GetCode() == ERROR_PIPE_BUSY)
			KillStepson();
	}

	// win bug: taskkill had ended, but resources of app have not deleted...
	CreateIntPipes(10000); // so we wait 10 secs...
}
//------------------------------------------------------------------------------
// Connect to child's StdIn/StdOut pipes
void CRunner::ConnectToChild()
{
	char * outname = NULL;
	char * inname = NULL;
	__try
	{
		outname = MakePipeName(server_program_stdout_pipe_internal, NULL);
		inname = MakePipeName(server_program_stdin_pipe_internal, NULL);

		OVERLAPPED ol_Child;

		ZeroMemory(&ol_Child, sizeof(OVERLAPPED));
		ch(ResetEvent(ol_Child.hEvent = hEventChild));
		AConnect(hChildStdInR, &ol_Child);
		chf(INVALID_HANDLE_VALUE, hChildStdInW = CreateFile(inname,
			GENERIC_WRITE,
			0,							// no sharing
			NULL,						// default security attributes
			OPEN_EXISTING,				// opens existing pipe
			FILE_FLAG_OVERLAPPED
			|FILE_FLAG_NO_BUFFERING
			|FILE_FLAG_WRITE_THROUGH,	// attributes
			NULL						// no template file
			));
		chf(WAIT_FAILED, WaitForSingleObject(hEventChild, INFINITE));

		ZeroMemory(&ol_Child, sizeof(OVERLAPPED));
		ch(ResetEvent(ol_Child.hEvent = hEventChild));
		AConnect(hChildStdOutW, &ol_Child);
		chf(INVALID_HANDLE_VALUE, hChildStdOutR = CreateFile(outname,
			GENERIC_READ,
			0,							// no sharing
			NULL,						// default security attributes
			OPEN_EXISTING,				// opens existing pipe
			FILE_FLAG_OVERLAPPED
			|FILE_FLAG_NO_BUFFERING
			|FILE_FLAG_WRITE_THROUGH,	// attributes
			NULL						// no template file
			));
		chf(WAIT_FAILED, WaitForSingleObject(hEventChild, INFINITE));
	}
	__finally
	{
		if (outname != NULL)
			delete[] outname;
		if (inname != NULL)
			delete[] inname;
	}
}
//------------------------------------------------------------------------------
// Changes curdir to dir where program is
void CRunner::ChDirToHome()
{
	uint len = MAX_PATH;
	char * filename = NULL;
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
		// ok, now len = length of string

		char *last_slash = NULL;
		chf(NULL, last_slash = strrchr(filename, '\\'));
		*last_slash = 0;
		ch(SetCurrentDirectory(filename));
	}
	__finally
	{
		if (filename != NULL)
			delete[] filename;
	}
}
//------------------------------------------------------------------------------
// Create child process with redirected input and output
void CRunner::CreateChildProcess()
{
	PROCESS_INFORMATION pi;
	STARTUPINFO si;

	ZeroMemory(&pi, sizeof(PROCESS_INFORMATION));
	ZeroMemory(&si, sizeof(STARTUPINFO));
	si.cb = sizeof(STARTUPINFO);
	si.hStdError = hChildStdOutW;
	si.hStdOutput = hChildStdOutW;
	si.hStdInput = hChildStdInR;
	si.dwFlags |= STARTF_USESTDHANDLES;

	ch(CreateProcess(
		server_program_image,		// ApplicationName
		NULL,						// CommandLine
		NULL,						// returned process handle cannot be inherited
		NULL,						// returned thread handle cannot be inherited
		TRUE,						// handles are inherited
		CREATE_NEW_PROCESS_GROUP,	// creation flags
		NULL,						// use parent's environment
		NULL,						// use parent's current directory
		&si,						// STARTUPINFO pointer
		&pi							// receives PROCESS_INFORMATION
		));
	ch(CloseHandle(pi.hThread));
	hChildProcess = pi.hProcess;
	ChildProcessID = pi.dwProcessId;
}
//------------------------------------------------------------------------------
// Creates events for pipe's async operations
void CRunner::CreateEvents()
{
	chf(NULL, hEventChild = CreateEvent(NULL, TRUE, FALSE, NULL));
	chf(NULL, hEventClient = CreateEvent(NULL, TRUE, FALSE, NULL));
}
//------------------------------------------------------------------------------
// Waits for clients in loop and redirects data from and to child process
void CRunner::Transmission(HANDLE stopevent)
{
	// For synchronization:
	OVERLAPPED ol_Client;
	OVERLAPPED ol_Child;
	HANDLE wait[] = {hChildProcess, stopevent, hEventClient, hEventChild};

	// Buffers for data:
	char bufClient[BUF_SIZE], bufChild[BUF_SIZE];
	DWORD cbReadClient, cbReadChild;

newclient:
	// Waiting for, then connect client (Asyn StdIn, then Syn StdOut):
	// StdIn Pipe (Asyn):
	ZeroMemory(&ol_Client, sizeof(OVERLAPPED));
	ch(ResetEvent(ol_Client.hEvent = hEventClient));
	AConnect(hwowdStdInR, &ol_Client);
clearechild: // without clint we need not data from child
		// Reading from child:
		ZeroMemory(&ol_Child, sizeof(OVERLAPPED));
		ol_Child.hEvent = hEventChild; // ReadFile will reset
		while(ARead(hChildStdOutR, bufChild, sizeof(bufChild), &cbReadChild, &ol_Child, true))
			if (WaitForSingleObject(stopevent, 0) != WAIT_TIMEOUT)
				return;
	switch (WaitForMultipleObjects(4, wait, FALSE, INFINITE))
	{
		case WAIT_OBJECT_0: // process stops
			throwe("wowd have died");
		case WAIT_OBJECT_0+1: // stop command
			return;
		case WAIT_OBJECT_0+2: // client connected
			break;
		case WAIT_OBJECT_0+3: // child writes
			goto clearechild;
		case WAIT_FAILED: // error
			throwe("WaitForMultipleObjects");
	}
	// StdOut Pipe (Syn) (need not asy, because it must be done in moment):
	if (!ConnectNamedPipe(hwowdStdOutW, NULL))
	{
		DWORD e = GetLastError();
		if (e != ERROR_PIPE_CONNECTED)
			throwe_code("ConnectNamedPipe", e);
	}
	// Client connected. Starting transmission of data.

	//ForceDebugBreak();
	// But first, need to cancel pending "clear" operation we've made before:
	ch(CancelIo(hChildStdOutR));

	// Init overlapped structure for reading:
	ZeroMemory(&ol_Client, sizeof(OVERLAPPED));
	ol_Client.hEvent = hEventClient; // ReadFile will reset
	ZeroMemory(&ol_Child, sizeof(OVERLAPPED));
	ol_Child.hEvent = hEventChild; // ReadFile will reset

	try
	{
		// Reading from client:
		while (ARead(hwowdStdInR, bufClient, sizeof(bufClient), &cbReadClient, &ol_Client))
			if (WaitForSingleObject(stopevent, 0) == WAIT_TIMEOUT)
				SWrite(hChildStdInW, bufClient, cbReadClient, true, false);
			else
				return;
	
		// Reading from child:
		while (ARead(hChildStdOutR, bufChild, sizeof(bufChild), &cbReadChild, &ol_Child, true))
			if (WaitForSingleObject(stopevent, 0) == WAIT_TIMEOUT)
				SWrite(hwowdStdOutW, bufChild, cbReadChild);
			else
				return;

		for(;;)
		switch (WaitForMultipleObjects(4, wait, FALSE, INFINITE))
		{
			case WAIT_OBJECT_0: // process stops
				throwe("wowd have died");
				break;
			case WAIT_OBJECT_0+1: // stop command
				return;
			case WAIT_OBJECT_0+2: // client have written data
				// Sending data to child:
				SResult(hwowdStdInR, &ol_Client, &cbReadClient);
				SWrite(hChildStdInW, bufClient, cbReadClient, true, false);
				// Reading from client again:
				while (ARead(hwowdStdInR, bufClient, sizeof(bufClient), &cbReadClient, &ol_Client))
					if (WaitForSingleObject(stopevent, 0) == WAIT_TIMEOUT)
						SWrite(hChildStdInW, bufClient, cbReadClient, true, false);
					else
						return;
				break;
			case WAIT_OBJECT_0+3: // child have written data
				// Sending data to child:
				SResult(hChildStdOutR, &ol_Child, &cbReadChild, true);
				SWrite(hwowdStdOutW, bufChild, cbReadChild);
				// Reading from child again:
				while (ARead(hChildStdOutR, bufChild, sizeof(bufChild), &cbReadChild, &ol_Child, true))
					if (WaitForSingleObject(stopevent, 0) == WAIT_TIMEOUT)
						SWrite(hwowdStdOutW, bufChild, cbReadChild);
					else
						return;
				break;
			case WAIT_FAILED: // error
				throwe("WaitForMultipleObjects");
				break;
		}
	}
	catch(ErrEvents err)
	{
		if (err == PipeIsClosed)
		{
			ch(DisconnectNamedPipe(hwowdStdInR));
			ch(DisconnectNamedPipe(hwowdStdOutW));
			goto newclient;
		}
	}
	throwe("never here");
}
//******************************************************************************
