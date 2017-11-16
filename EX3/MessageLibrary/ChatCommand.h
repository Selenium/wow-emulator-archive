#if !defined(CHATCOMMAND_H)
#define CHATCOMMAND_H


//! Parses raw commands and breaks them up into easily managed parts.
class ChatCommand
{
public:
	//! Types of command the class can contain.
	enum CommandType
	{
		COMMANDTYPE_CHAT = 0x01,
		COMMANDTYPE_SERVER = 0x02
	};

	// Constructor: ChatCommand.
	/*! The constructor takes the raw message and parses it, splitting it up into easily managed parts.
		@param rawMessage Raw message sent to the server from the client.
		@param messageCode Code retreived from the message packet, indicating the type of message. */
	ChatCommand(string rawMessage, Byte messageCode);
	
	// Destructor: ~ChatCommand.
	/*! Destroys the chat command and removes all parameters associated with it. */
	~ChatCommand();

	//! Returns the command extracted from the raw message.
	/*! @return The command string, without prefix character (/ or !). */
	string GetCommand() { return mCommand; };

	//! Returns the type of command this is.
	/*! Command types are implemented in the x enumeration. */
	CommandType GetCommandType() { return mCommandType; };

	//! Returns the message code for this message.
	/*! @return Message code to use when sending packets. */
	Byte GetMessageCode() { return mMessageCode; };

	//! Adds a parameter to this message.
	/*! @param parameterString Parameter to add. */
	void AddParameter(string parameterString);

	//! Returns the parameter at the specified index.
	/*! @param index Index into the parameters list. */
	string GetParameter(DoubleWord index);

	//! Returns the number of parameters associated with this command.
	/*! @return Number of parameters. */
	DoubleWord GetParameterCount() { return (DoubleWord)mParameters.size(); };

private:
	//! Command without the prefix character (/ or !).
	string mCommand;

	//! The type of command this is.
	CommandType mCommandType;

	//! The code of the message received/to send, indicating the type of message.
	Byte mMessageCode;

	//! Holds the parameters associated with this command.
	vector<string> mParameters;
};

#endif
