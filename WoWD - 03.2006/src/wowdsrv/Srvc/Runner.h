//******************************************************************************
class CRunner // Класс, запускающий консольную программу
{
public:						// Внешние методы:

	// Запустить (выполняется до установленного stopevent)
	void Start(HANDLE stopevent);

	// Послать запущеной программе Ctrl-C
	void Stop();

	// Wait until child process ends
	bool WaitForChild(DWORD dwMilliseconds);
	
	// Terminate child process
	void Kill();

	// Конструктор
	CRunner();

	// Просто деструктор
	~CRunner();

protected:					// Защищённые методы:

	// Terminate child process of other instance of service
	void KillStepson();

	// Create service's pipes for communication with client
	void CreatePublicPipes();

	// Create pipes for child process StdIn and StdOut 
	void CreateIntPipes(DWORD nTimeOut = 0);

	// Additionally checks for process of other instance of service
	void CreateIntPipesSafe();

	// Connect to child's StdIn/StdOut pipes
	void ConnectToChild();

	// Changes curdir to dir where program is
	void ChDirToHome();

	// Create child process with redirected input and output
	void CreateChildProcess();

	// Creates events for pipe's async operations
	void CreateEvents();

	// Waits for clients in loop and redirects data from and to child process
	void Transmission(HANDLE stopevent);

							// Защищённые данные:

	// Handles of pipes for communication with child process
	HANDLE hChildStdInR, hChildStdInW, hChildStdOutW, hChildStdOutR;

	// Handles of pipes for communication with service's client
	HANDLE hwowdStdOutW, hwowdStdInR;

	// Handle of child process
	HANDLE hChildProcess;

	// ID of child process
	DWORD ChildProcessID;

	// Events for pipe's async operations
	HANDLE hEventChild, hEventClient;

							// Защищённые константы:

	// Image path of child process
	static CPCTSTR server_program_image;

	// Name of pipe for server program StdOut
	static CPCTSTR server_program_stdout_pipe;

	// Name of pipe for server program StdIn
	static CPCTSTR server_program_stdin_pipe;

	// Name of pipe for server program StdOut for service
	static CPCTSTR server_program_stdout_pipe_internal;

	// Name of pipe for server program StdIn for service
	static CPCTSTR server_program_stdin_pipe_internal;

	// Command to kill child of pervious service
	static PTSTR kill_stepson_cmd;
};
//******************************************************************************
