// (c) Abyss Group
#if !defined(LOGINSERVER_H)
#define LOGINSERVER_H

class LoginServer : public Server, public Singleton<LoginServer>
{
	public:
		LoginServer();
		~LoginServer();

		void Run(void);

		void StateHandler(DoubleWord, Client *cli);
		void ListRealms(Client *cli);
		void CheckDATA(LPacket pack, Client *cli);
		void UpdatePlayers(LPacket *pack);

	protected:
		virtual void ClientConnected(Client *);
		virtual void ClientDisconnected(Client *);
		virtual void ClientDataRecvd(Client *);

	private:
		
		enum REALMLISTOPCODE
 		{
 			CHALLENGE = 0,
 			PROOF = 1,
 			RECODE_CHALLENGE = 2,
 			RECODE_PROOF = 3,
 			REALMLIST_REQUEST = 16,
		};

		map<Client *, string> mUserID;
		int mLPort, mRPort;
		string mRHost;
		DoubleWord mPlayers;
};

#endif
