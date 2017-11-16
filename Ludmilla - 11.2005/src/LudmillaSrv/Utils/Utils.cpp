//******************************************************************************
#include "header.h"
#include "../myheader.h"
//==============================================================================
// This function forces the debugger to be invoked
void ForceDebugBreak()
{
#ifdef _DEBUG
	__try {DebugBreak();}
	__except(UnhandledExceptionFilter(GetExceptionInformation())) {}
#endif
}
//------------------------------------------------------------------------------
// Asynchronous connects to pipe and process common errors
void AConnect(HANDLE hPipe, LPOVERLAPPED lpOverlapped)
{
	BOOL bRet = ConnectNamedPipe(hPipe, lpOverlapped);
	if (!bRet) // not connected now ...
	{
		DWORD e = GetLastError();
		if (e != ERROR_PIPE_CONNECTED) // ... not already connected ...
			if (e != ERROR_IO_PENDING) // ... and will not be connected
				throwe("ConnectNamedPipe");
	}
}
//------------------------------------------------------------------------------
// Asynchronous read from pipe and process common errors
bool ARead(HANDLE hFile, LPVOID lpBuffer, DWORD nNumberOfBytesToRead, LPDWORD lpNumberOfBytesRead, LPOVERLAPPED lpOverlapped, bool fatal)
{
	// Reading:
	BOOL bRet = ReadFile(hFile, lpBuffer, nNumberOfBytesToRead, lpNumberOfBytesRead, lpOverlapped);
	if (!bRet) // not read now ...
	{
		DWORD e = GetLastError();
		if (e == ERROR_IO_PENDING) // ... will be read
			return false;
		if (e == ERROR_NO_DATA || e == ERROR_BROKEN_PIPE) // The pipe has been ended, closed.
		{
			if (fatal)
				throwe_code("luda have died", e);
			throw PipeIsClosed;
		}
		throwe_code("ReadFile", e);
	}
	else
		return true;
}
//------------------------------------------------------------------------------
// Synchronous write to pipe and process common errors, then flush if specified
void SWrite(HANDLE hFile, LPCVOID lpBuffer, DWORD nNumberOfBytesToWrite, bool fatal, bool flush)
{
	DWORD NumberOfBytesWritten;
	BOOL bRet = WriteFile(hFile, lpBuffer, nNumberOfBytesToWrite, &NumberOfBytesWritten, NULL);
	if (!bRet)
	{
		DWORD e = GetLastError();
		if (e == ERROR_NO_DATA || e == ERROR_BROKEN_PIPE) // The pipe has been ended, closed.
		{
			if (fatal)
				throwe_code("luda have died", e);
			throw PipeIsClosed;
		}
		throwe_code("WriteFile", e);
	}

	if (!flush) return;

	bRet = FlushFileBuffers(hFile);
	if (!bRet)
	{
		DWORD e = GetLastError();
		if (e == ERROR_NO_DATA || e == ERROR_BROKEN_PIPE) // The pipe has been ended, closed.
		{
			if (fatal)
				throwe_code("luda have died", e);
			throw PipeIsClosed;
		}
		throwe_code("FlushFileBuffers", e);
	}
}
//------------------------------------------------------------------------------
// Get Asynchronous result on pipe and process common errors
void SResult(HANDLE hFile, LPOVERLAPPED lpOverlapped, LPDWORD lpNumberOfBytesTransferred, bool child)
{
	BOOL bRet = GetOverlappedResult(hFile, lpOverlapped, lpNumberOfBytesTransferred, FALSE);
	if (!bRet)
	{
		DWORD e = GetLastError();
		if (e == ERROR_NO_DATA || e == ERROR_BROKEN_PIPE) // The pipe is being closed, ended.
		{
			if (child)
				throwe_code("luda have died", e);
			throw PipeIsClosed;
		}
		throwe_code("GetOverlappedResult", e);
	}
}
//------------------------------------------------------------------------------
// Closes HANDLE if it is correct, then set variable to INVALID_HANDLE_VALUE
void TryClose(HANDLE &h)
{
	if (h != INVALID_HANDLE_VALUE)
		ch(CloseHandle(h));
	h = INVALID_HANDLE_VALUE;
}
//------------------------------------------------------------------------------
// Allocates \\host\pipe\pipename with "new"
char* MakePipeName(CPCTSTR name, CPCTSTR host)
{
	uint namelen = (uint)strlen(name);
	uint hostlen = host==NULL ? 1 : (uint)strlen(host);
	char *ret = NULL;
	chf(NULL, ret = new char[2+hostlen+6+namelen+1]);
	chf(-1, sprintf(ret, "\\\\%s\\pipe\\%s", host==NULL?".":host, name));
	return ret;
}
//------------------------------------------------------------------------------
// Присоеденить указаный ресурс
void AddShare(char *user, char *password, char *share, char *local)
{
	NETRESOURCE nr;
	nr.dwType = local==NULL ? RESOURCETYPE_ANY : RESOURCETYPE_DISK;
	nr.lpLocalName = local;
	nr.lpRemoteName = share;
	nr.lpProvider = NULL;

	DWORD err = WNetAddConnection2(&nr, password, user, 0);
	if (err != NO_ERROR)
	{
		SetLastError(err);
		throwe("WNetAddConnection2");
	}
}
//------------------------------------------------------------------------------
// Отсоединить указаный ресурс
void DelShare(char *share)
{
	DWORD err = WNetCancelConnection2(share, 0, false);
	if (err != NO_ERROR)
	{
		SetLastError(err);
		throwe("WNetCancelConnection2");
	}
}
//******************************************************************************
