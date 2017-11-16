// (c) Abyss Group
#if !defined(REDIRECTSERVER_H)
#define REDIRECTSERVER_H

class RedirectServer : public Server, public Singleton<RedirectServer>
{
	public:
		RedirectServer();
		~RedirectServer();

		void Run(void);

	protected:
		virtual void ClientConnected(Client *);
		virtual void ClientDataRecvd(Client *);

	private:
		string mRHost;
		int mLPort, mRPort;

};

#endif
