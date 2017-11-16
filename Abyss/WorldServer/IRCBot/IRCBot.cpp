// (c) AbyssX Group
#include "../WorldEnvironment.h"

#ifdef IRCBOT

IRCBot::IRCBot()
{
	mServer = NULL;
	mClient = NULL;
}

IRCBot::~IRCBot()
{
}

bool IRCBot::LoadConfig(void)
{
	ConfigCursor cfg = Config::GetSingleton().Cursor();

	if (!cfg.Find("WorldServer") || !cfg.FindIn("BotNick"))
	{
		fprintf(stderr, "No configured BotNick for WorldServer\n");
		return false;
	}
	mNick = cfg[0];
	cfg.Reset();
	if (!cfg.Find("WorldServer") || !cfg.FindIn("BotChannel"))
	{
		fprintf(stderr, "No configured BotChannel for WorldServer\n");
		return false;
	}
	mChannel = "#";
	mChannel += cfg[0];
	cfg.Reset();
	if (!cfg.Find("WorldServer") || !cfg.FindIn("BotPassword"))
	{
		fprintf(stderr, "No configured BotPassword for WorldServer\n");
		return false;
	}
	mNickServPass = cfg[0];

	return true;
}

void IRCBot::Connected(Server *server, Client *client)
{
	char buf[32];
	char buffer[255];

	mServer = server;
	mClient = client;

	sprintf(buf, "IDENTIFY %s", mNickServPass.c_str());

	Send("NICK", mNick.c_str(), NULL);
	Send("USER", mNick.c_str(), "|", "|", "[EX3 Server BOT]", NULL);
	Send("PRIVMSG", "NickServ", buf, NULL);
	Send("JOIN", mChannel.c_str(), NULL);

	sprintf(buffer,"[ EX3 ] Online! IP: %s:%d",
		WorldServer::GetSingleton().LIP,WorldServer::GetSingleton().LPort);

	Send("PRIVMSG", mChannel.c_str(), buffer, NULL);
}

void IRCBot::Disconnected(void)
{
	mServer = NULL;
	mClient = NULL;
}

void IRCBot::DataRecvd(void)
{
	string commandline;
	unsigned int i;

	for (i = 0; i < mClient->GetInBuffer().length(); i++)
	{
		// If we hit CRLF
		if (mClient->GetInBuffer().at(i) == 0x0D)
		{
			if (i+1 < mClient->GetInBuffer().length())
			{
				if (mClient->GetInBuffer().at(i+1) == 0x0A)
				{
					// Then break
					break;
				}
			}
		}

		// Else add to our line
		commandline += mClient->GetInBuffer().at(i);
	}

	// Did we end up getting a whole command?
	if (i < mClient->GetInBuffer().length())
	{
		// erase the data we've read from the in buffer
		mClient->GetInBuffer() = mClient->GetInBuffer().substr(i + 2);
		CommandRecvd(commandline);

		// Sine we may have more commands, call ourselves again
		DataRecvd();
	}
}

void IRCBot::CommandRecvd(string command)
{
	string prefix;
	string nick;
	string cmd;
	vector<string> params;

	if (command[0] == ':')
	{
		// This command has a prefix - extract it
		prefix = command.substr(1, command.find_first_of(' ') - 1);
		command = command.substr(command.find_first_of(' ') + 1);
	}

	// Parse the prefix
	if (prefix.find_first_of('!') != string::npos)
	{
		nick = prefix.substr(0, prefix.find_first_of('!'));
	}
	else
		nick = prefix;

	// Parse the command
	if (command.find_first_of(' ') != string::npos)
	{
		// A command with arguments
		// Extract the command
		cmd = command.substr(0, command.find_first_of(' '));
		command = command.substr(command.find_first_of(' ') + 1);

		// extract the params
		while (true)
		{
			if (command[0] == ':')
			{
				// Last param, rest of string is param
				params.push_back(command.substr(1));
				break;
			}
			else
			{
				// If string is empty, we go tno more params
				if (command.empty())
					break;
				// If there are no more spaces, we've got the last param now
				if (command.find_first_of(' ') == string::npos)
				{
					params.push_back(command);
					break;
				}
				// Otherwise, just snatch the next command
				params.push_back(command.substr(0, command.find_first_of(' ')));
				command = command.substr(command.find_first_of(' ') + 1);
			}
		}
	}
	else
	{
		// A command without arguments
		cmd = command;
	}

	HandleCommand(nick, cmd, params);
}

void IRCBot::HandleCommand(string nick, string command, vector<string> params)
{
	vector<string>::iterator it;

	LogManager::GetSingleton().Log("Bot.log", "Nick: '%s'\n", nick.c_str());
	LogManager::GetSingleton().Log("Bot.log", "Command: '%s'\n", command.c_str());
	for (it = params.begin(); it != params.end(); it++)
		LogManager::GetSingleton().Log("Bot.log", "Param: '%s'\n", (*it).c_str());

	if (command == "PING")
		Send("PONG", params[0].c_str(), NULL);
	if (command == "PRIVMSG")
	{
		vector<string> cmdparts;

		while (true)
		{
			if (params[1].find_first_of(' ') == string::npos)
			{
				cmdparts.push_back(params[1]);
				break;
			}
			cmdparts.push_back(params[1].substr(0, params[1].find_first_of(' ')));
			params[1] = params[1].substr(params[1].find_first_of(' ') + 1);
		}

		if (stricmp(cmdparts[0].c_str(), "!help") == 0)
		{
			Send("PRIVMSG", nick.c_str(), "IRC Help:", NULL);
			Send("PRIVMSG", nick.c_str(), "-------------------------------------------", NULL);
			Send("PRIVMSG", nick.c_str(), "!stats -> Server info", NULL);
			Send("PRIVMSG", nick.c_str(), "!talk  -> to talk to people in the Server", NULL);
			Send("PRIVMSG", nick.c_str(), "!auth <pass> -> gives you IRC Admin.", NULL);
			if(mUserModes[nick] == 0x01) {
				Send("PRIVMSG", nick.c_str(), "Admin Commands: ", NULL);
				Send("PRIVMSG", nick.c_str(), "!quit -> Makes the bot Quit irc.", NULL);
			}
			Send("PRIVMSG", nick.c_str(), "-------------------------------------------", NULL);
		}
		if (stricmp(cmdparts[0].c_str(), "!quit") == 0 && mUserModes[nick] == 0x01)
		{
			Send("QUIT", " ", NULL);
		}
		if (stricmp(cmdparts[0].c_str(), "!stats") == 0)
		{
			char buf[128];

			sprintf(buf, "[ EX3 ] Online!:  %d player(s) is/are playing ",
				PlayersHandler::GetSingleton().NumberPlayers());

			Send("PRIVMSG", nick.c_str(), buf, NULL);

			sprintf(buf, "[ EX3 ] Online!:  %d of then %s ",
				PlayersHandler::GetSingleton().NumberGMs(),
				PlayersHandler::GetSingleton().NumberGMs() == 1 ? "is a GM." : "are GMs");

			Send("PRIVMSG", nick.c_str(), buf, NULL);

			sprintf(buf, "[ EX3 ] Online!:  realmlist %s:%d ",
				WorldServer::GetSingleton().LIP,
				WorldServer::GetSingleton().LPort);

			Send("PRIVMSG", nick.c_str(), buf, NULL);

			//Send("PRIVMSG", stricmp(params[0].c_str(), mChannel.c_str()) == 0 ?
			//	mChannel.c_str() : nick.c_str(), buf, NULL);

		}

		if (stricmp(cmdparts[0].c_str(), "!talk") == 0)
		{
			char buf[512];
			memset(buf,0x00,512);
			char* bufptr = buf;

			bufptr += sprintf(bufptr,"[%s] <%s>",mChannel.c_str(),nick.c_str());

			for (DoubleWord i = 1; i < cmdparts.size(); i++)
			{
				bufptr += sprintf(bufptr," %s", cmdparts[i].c_str());
			}

			WorldServer::GetSingleton().IRCTOWOW(buf);

		}

		if (stricmp(cmdparts[0].c_str(), "!auth") == 0)
		{
			if (cmdparts.size() > 1 && cmdparts[1] == "ircadmin")
			{
				char buf[1024];

				sprintf(buf, "You are now authorized, %s", nick.c_str());
				Send("PRIVMSG", stricmp(params[0].c_str(), mChannel.c_str()) == 0 ?
					mChannel.c_str() : nick.c_str(), buf, NULL);
				mUserModes[nick] |= MODE_ADMIN;
			}
		}
	}
}

void IRCBot::Send(const char *cmd, ...)
{
	va_list args;
	char *arg;
	char *nextarg;

	va_start(args, cmd);

	mServer->WriteData(mClient, (Byte *)cmd, (DoubleWord)strlen(cmd));
	nextarg = va_arg(args, char *);
	while (nextarg)
	{
		arg = nextarg;
		nextarg = va_arg(args, char *);
		if (!nextarg)
		{
			mServer->WriteData(mClient, (Byte)' ');
			mServer->WriteData(mClient, (Byte)':');
			mServer->WriteData(mClient, (Byte *)arg, (DoubleWord)strlen(arg));
		}
		else
		{
			mServer->WriteData(mClient, (Byte)' ');
			mServer->WriteData(mClient, (Byte *)arg, (DoubleWord)strlen(arg));
		}
	}

	mServer->WriteData(mClient, 0x0D);
	mServer->WriteData(mClient, 0x0A);
	va_end(args);
}

void IRCBot::Announce(const char *txt)
{
	char buf[1024*6];

	sprintf(buf, "Server Announcement: %s", txt);

	if(mServer)
		if(mClient)
			Send("PRIVMSG", mChannel.c_str(), buf, NULL);
}

void IRCBot::Yell(const char *who, const char *txt)
{
	char buf[1024*6];

	sprintf(buf, "%s yells: %s", who, txt);

	if(mServer)
		if(mClient)
	Send("PRIVMSG", mChannel.c_str(), buf, NULL);
}

#endif