//******************************************************************************
class CSCtrlP // Service Control Program
{
public:						// Внешние методы:

	// Connect to server
	void Connect(char *host = NULL);

	// Disconnect from server
	void Disconnect();

	// Write to server StdIn
	void SendCommand(char* buf, int size);

protected:					// Защищённые методы:

	// Open server's StdIn and StdOut pipes
	void Open(char *host);

	// Close server's StdIn and StdOut pipes
	void Close();

	// Create thread with server's StdOut
	void StartOutThread();

	// Closes thread with server's StdOut
	void StopOutThread();

	// Thread procedure for processing server program output
	void  ThreadProc();

	// Thread for processing server program output
	static uint __stdcall FromChildThread(void* ptr);

							// Защищённые данные:

	// Handles of pipes to server program StdIn and StdOut
	HANDLE LudaStdOut, LudaStdIn;

	// Handle of event for stoping operations with server program
	HANDLE hStopEvent;

	// Handle of thread for processing server program output
	HANDLE thread;

							// Защищённые константы:

	// Name of pipe for server program StdOut
	static CPCTSTR server_program_stdout_pipe;

	// Name of pipe for server program StdIn
	static CPCTSTR server_program_stdin_pipe;

	// Capture of communication window
	static CPCTSTR server_program_name;
};
//******************************************************************************
