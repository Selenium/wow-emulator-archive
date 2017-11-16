//******************************************************************************
class CAConsole // Implementation of platform independent asynchronous console functions
{
public:						// Public methods:

	// Get char from console or EOF
	int GetChar();

	// Constructor
	CAConsole();

	// Simple destructor
	~CAConsole();

protected:					// Protected methods:

#ifdef _WIN32
#else

	// see http://sxs.thexdershome.com/programming/kbhit.html
	int kbhit();
	int getch();

#endif

							// Protected data:

#ifdef _WIN32
	
	// Handle to StdIn
	HANDLE hStdIn;

	// Is hStdIn console handle or something else (pipe)
	bool RealConsole;

	// Structure contains information used in asynchronous operations
	OVERLAPPED ol;

	// Next char in input buffer
	char key;

	// Number of bytes read by ReadFile()
	DWORD keyread;

#else

	// see http://sxs.thexdershome.com/programming/kbhit.html
	struct termios initial_settings, new_settings;
	int peek_character;

#endif
};
//******************************************************************************
