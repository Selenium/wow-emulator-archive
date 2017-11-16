// (c) AbyssX Group
#if !defined(IRCBOT_H)
#define IRCBOT_H

#ifdef IRCBOT

class IRCBot
{
	public:
		IRCBot();
		~IRCBot();

		bool LoadConfig(void);

		void Connected(Server *server, Client *client);
		void Disconnected(void);
		void DataRecvd(void);

		void CommandRecvd(string command);
		void HandleCommand(string nick, string command, vector<string> params);

		void Send(const char *cmd, ...);

		void Announce(const char *announcement);
		void Yell(const char *who, const char *txt);

	private:
		Server *mServer;
		Client *mClient;
		string mNick, mChannel, mNickServPass;
		map<string, Byte> mUserModes;

		enum UserModes {
			MODE_ADMIN = 0x01
		};
};

#endif

#endif
