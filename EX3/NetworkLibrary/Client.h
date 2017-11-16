// (c) AbyssX Group
#if !defined(CLIENT_H)
#define CLIENT_H

class Client
{
	public:
		Client(SOCKET s) : mQueueClose(false), mSock(s), mTimeout(0) {};
		~Client();

		SOCKET GetSock(void);

		void SetTimeout(unsigned int secs);
		bool IsTimedOut(void);
		void Touch(void);

		void RecvData(const Byte *data, int len);
		void SendData(const Byte *data, int len);

		string &GetInBuffer(void);
		string &GetOutBuffer(void);
		string &GetHost(void);

		bool mQueueClose;

	private:
		SOCKET mSock;
		time_t mTimeout;
		time_t mIdleStart;
		string mInBuffer, mOutBuffer;
		string mHost;
};

#endif
