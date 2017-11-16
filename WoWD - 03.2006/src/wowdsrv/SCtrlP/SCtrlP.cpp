//******************************************************************************
#include "header.h"
#include "../myheader.h"
//==============================================================================
CPCTSTR				CSCtrlP::server_program_stdout_pipe = SERVER_PROGRAM_STDOUT_PIPE;
CPCTSTR				CSCtrlP::server_program_stdin_pipe = SERVER_PROGRAM_STDIN_PIPE;
CPCTSTR				CSCtrlP::server_program_name = SERVER_PROGRAM_NAME;
//==============================================================================
							// Внешние методы:
//------------------------------------------------------------------------------
// Connect to server
void CSCtrlP::Connect(char *host)
{
	Open(host);
	StartOutThread();
}
//------------------------------------------------------------------------------
// Disconnect from server
void CSCtrlP::Disconnect()
{
	StopOutThread();
	Close();
}
//------------------------------------------------------------------------------
// Write to server StdIn
void CSCtrlP::SendCommand(char* buf, int size)
{
	DWORD dwWritten;
	ch(WriteFile(wowdStdIn, buf, size, &dwWritten, NULL));
}
//------------------------------------------------------------------------------
							// Защищённые методы:
//------------------------------------------------------------------------------
// Open server's StdIn and StdOut pipes
void CSCtrlP::Open(char *host)
{
	char *stdinname = NULL;
	char *stdoutname = NULL;
	__try
	{
		stdinname = MakePipeName(server_program_stdin_pipe, host);
		stdoutname = MakePipeName(server_program_stdout_pipe, host);

		wowdStdOut = INVALID_HANDLE_VALUE;
		wowdStdIn = INVALID_HANDLE_VALUE;
		ch(WaitNamedPipe(stdinname, NMPWAIT_USE_DEFAULT_WAIT));
		chf(INVALID_HANDLE_VALUE, wowdStdIn = CreateFile(stdinname,
			GENERIC_WRITE, 
			0,              // no sharing
			NULL,           // default security attributes
			OPEN_EXISTING,  // opens existing pipe
			FILE_FLAG_OVERLAPPED
			|FILE_FLAG_NO_BUFFERING
			|FILE_FLAG_WRITE_THROUGH,	// attributes
			NULL));          // no template file
		ch(WaitNamedPipe(stdoutname, NMPWAIT_USE_DEFAULT_WAIT));
		chf(INVALID_HANDLE_VALUE, wowdStdOut = CreateFile(stdoutname,
			GENERIC_READ, 
			0,              // no sharing
			NULL,           // default security attributes
			OPEN_EXISTING,  // opens existing pipe
			FILE_FLAG_OVERLAPPED
			|FILE_FLAG_NO_BUFFERING
			|FILE_FLAG_WRITE_THROUGH,	// attributes
			NULL));          // no template file
	}
	__finally
	{
		if (stdinname != NULL)
			delete[] stdinname;
		if (stdoutname != NULL)
			delete[] stdoutname;
	}
}
//------------------------------------------------------------------------------
// Close server's StdIn and StdOut pipes
void CSCtrlP::Close()
{
	TryClose(wowdStdOut);
	TryClose(wowdStdIn);
}
//------------------------------------------------------------------------------
// Create thread with server's StdOut
void CSCtrlP::StartOutThread()
{
	chf(NULL, hStopEvent = CreateEvent(NULL, TRUE, FALSE, NULL));
	thread = (HANDLE)_beginthreadex(NULL, 0, FromChildThread, this, 0, NULL);
	if (thread == 0)
		throwe("_beginthreadex");
}
//------------------------------------------------------------------------------
// Closes thread with server's StdOut
void CSCtrlP::StopOutThread()
{
	ch(SetEvent(hStopEvent));
	chf(WAIT_FAILED, WaitForSingleObject(thread, INFINITE));
	TryClose(thread);
}
//------------------------------------------------------------------------------
// Thread procedure for processing server program output
void  CSCtrlP::ThreadProc()
{
	HANDLE hEvent = INVALID_HANDLE_VALUE;
	__try
	{
		chf(NULL, hEvent = CreateEvent(NULL, TRUE, FALSE, NULL));
		OVERLAPPED ol;
		HANDLE wait[] = {hStopEvent, hEvent};
		
		// Allocating console:
		ch(AllocConsole());
		ch(SetConsoleTitle(server_program_name));
		HANDLE StdOut = GetStdHandle(STD_OUTPUT_HANDLE);

		// Buffer for data:
		char bufChild[80];
		DWORD cbReadChild;

		for(;;)
		{
			// Init overlapped structure for reading:
			ZeroMemory(&ol, sizeof(OVERLAPPED));
			ol.hEvent = hEvent; // ReadFile will reset

			// Reading from child:
			while (ARead(wowdStdOut, bufChild, sizeof(bufChild), &cbReadChild, &ol, true))
				if (WaitForSingleObject(hStopEvent, 0) == WAIT_TIMEOUT)
					SWrite(StdOut, bufChild, cbReadChild, false, false);
				else
					return;

			switch(WaitForMultipleObjects(2, wait, FALSE, INFINITE))
			{
				case WAIT_OBJECT_0:
					return;
				case WAIT_OBJECT_0+1:
					SResult(wowdStdOut, &ol, &cbReadChild, true);
					SWrite(StdOut, bufChild, cbReadChild, false, false);
					break;
				default:
					throwe("WaitForMultipleObjects");
			}
		}
	}
	__finally
	{
		TryClose(hEvent);
		ch(FreeConsole());
		Close();
	}
}
//------------------------------------------------------------------------------
// Thread for processing server program output
uint CSCtrlP::FromChildThread(void* ptr)
{
	try
	{
		CSCtrlP* this_obj = (CSCtrlP*)ptr;
		this_obj->ThreadProc();
	}
	catch(CError &e)
	{
		e.ToGUI();
		_endthreadex((uint)-1);
	}
	_endthreadex(0);
	return 0;
}
//******************************************************************************
