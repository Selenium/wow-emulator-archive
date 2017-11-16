//******************************************************************************
enum ErrEvents
{
	NoError,
	PipeIsClosed
};
//==============================================================================
// This function forces the debugger to be invoked
void ForceDebugBreak();

// Asynchronous connects to pipe and process common errors
void AConnect(HANDLE hPipe, LPOVERLAPPED lpOverlapped);

// Asynchronous read from pipe and process common errors
bool ARead(HANDLE hFile, LPVOID lpBuffer, DWORD nNumberOfBytesToRead, LPDWORD lpNumberOfBytesRead, LPOVERLAPPED lpOverlapped, bool fatal = false);

// Synchronous write to pipe and process common errors, then flush if specified
void SWrite(HANDLE hFile, LPCVOID lpBuffer, DWORD nNumberOfBytesToWrite, bool fatal = false, bool flush = true);

// Get Asynchronous result on pipe and process common errors
void SResult(HANDLE hFile, LPOVERLAPPED lpOverlapped, LPDWORD lpNumberOfBytesTransferred, bool child = false);

// Closes HANDLE if it is correct, then set variable to INVALID_HANDLE_VALUE
void TryClose(HANDLE &h);

// Allocates \\host\pipename with "new"
char* MakePipeName(CPCTSTR name, CPCTSTR host = NULL);

// Присоеденить указаный ресурс
void AddShare(char *user, char *password, char *share, char *local = NULL);

// Отсоединить указаный ресурс
void DelShare(char *share);
//******************************************************************************
