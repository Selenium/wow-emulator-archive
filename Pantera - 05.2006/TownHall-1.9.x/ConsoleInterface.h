#ifndef CONSOLEINTERFACE_H
#define CONSOLEINTERFACE_H
#include <string>

#define CMDFUNCTYPE_NONE 0 // () no arguments; void
#define CMDFUNCTYPE_ARGS 1 // (argv,argc) like main
#define CMDFUNCTYPE_STRING 2 // (input) remainder of line minus command
struct ConsoleCmdHandler
{
	char *cmd;
	void *func;
	unsigned long funcType;
	char *description;
};

#define COMMANDLENGTH_HELP 4
#define COMMANDLENGTH_QUIT 4
#include "stdafx.h"

void BroadcastMessage(char *input);
void WorldSave();

class CConsoleInterface
{
public:
	string ParseCommand(char *command);
};
#endif // CONSOLEINTERFACE_H
