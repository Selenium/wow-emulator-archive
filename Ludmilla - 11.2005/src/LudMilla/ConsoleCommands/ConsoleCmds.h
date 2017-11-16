//******************************************************************************
class CConsoleCmds // direct console commands processor
{
public:						// Public methods:

	// Get pending input and process it
	void Do();

	// Constructor
	CConsoleCmds();

	// Simple destructor
	~CConsoleCmds();

protected:					// Protected methods:

	// Process one command
	void ProcessCmd(char *cmd);

	// ver[sion]
	static void TranslateVersion(char *str);
	static void ProcessVersion();

	// quit | exit
	static void TranslateQuit(char *str);
	static void ProcessQuit();

	// help | ?
	static void TranslateHelp(char *str);
	static void ProcessHelp(char *command);

							// Protected data:

	// Pending input
	char * cmd;

	// Current position in cmd buffer
	int pos;

	// Platform independent asynchronous console functions
	CAConsole AConsole;
};
//******************************************************************************
