#include "AConsole.h"
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
	void TranslateVersion(char *str);
	void ProcessVersion();

	// quit | exit
	void TranslateQuit(char *str);
	void ProcessQuit();

	// help | ?
	void TranslateHelp(char *str);
	void ProcessHelp(char *command);

	//updaterealms
	void TranslateUpdateRealms(char *str);
	void UpdateRealms();

							// Protected data:

	// Pending input
	char * cmd;

	// Current position in cmd buffer
	int pos;

	// Platform independent asynchronous console functions
	CAConsole AConsole;
};
//******************************************************************************
