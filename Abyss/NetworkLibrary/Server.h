// (c) AbyssX Group
#if !defined(SERVER_H)
#define SERVER_H

class Server
{
	public:
		Server();
		virtual ~Server();

		void WriteData(Client *cli, const Byte byte);
		void WriteData(Client *cli, const Byte *bytes, DoubleWord len);
		void WriteData(Client *cli, Packet *pack);
		void WriteData(Client *cli, LPacket *pack);

	protected:
		bool Listen(int port);
		bool Select(void);
		void Disconnect(Client *cli);
		void CloseWhenClear(Client *cli);

		Client *Connect(const char *host, int port);

		virtual void ClientConnected(Client *cli) {};
		virtual void ClientDisconnected(Client *cli) {};
		virtual void ClientDataRecvd(Client *cli) = 0;

	protected:
		list<Client *> mClients;
		int mClientCount;
	
	private:
		bool Accept(void);
		bool Read(Client *cli);
		bool Write(Client *cli);

		SOCKET mListenSock;
};

#endif
