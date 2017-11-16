#include "MessageEnvironment.h"

// Constructor: ChatCommand.
ChatCommand::ChatCommand(string rawMessage, Byte messageCode) : mMessageCode(messageCode)
{
	char *stringPointer = (char *)rawMessage.c_str();
	char parsedString[80];

	// Extract the type of command.
	if (stringPointer[0] == '!')
		mCommandType = COMMANDTYPE_SERVER;
	else
		mCommandType = COMMANDTYPE_CHAT;

	// Extract the command itself.
	if (mCommandType == COMMANDTYPE_SERVER)
	{
		stringPointer++;
		sscanf(stringPointer, "%s", parsedString);
		mCommand = parsedString;
	}
	else
	{
		mCommand = rawMessage;
	}

	// Extract any parameters, if this is a server command.
	// '/'-commands does not take any argument.
	// '!'-commands can take 0 or more arguments.
	if (mCommandType == COMMANDTYPE_SERVER)
	{
		stringPointer += mCommand.length();

		while (stringPointer[0] != '\0')
		{
			stringPointer++;
			sscanf(stringPointer, "%s", parsedString);
			this->AddParameter(parsedString);

			stringPointer += strlen(parsedString);
		}
	}
}

// Destructor: ~ChatCommand.
ChatCommand::~ChatCommand()
{
	// Release used resources.
}

// Method: AddParameter.
void ChatCommand::AddParameter(string parameterString)
{
	mParameters.push_back(parameterString);
}

string ChatCommand::GetParameter(DoubleWord index)
{
	return mParameters[index];
}
