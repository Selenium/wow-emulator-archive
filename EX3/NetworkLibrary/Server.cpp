// (c) AbyssX Group
#include "NetworkEnvironment.h"

Server::Server()
{
	mListenSock = INVALID_SOCKET;
	mClientCount = 0;
}

Server::~Server()
{
}

bool Server::Listen(int port)
{
	struct sockaddr_in sa;

	mListenSock = socket(AF_INET, SOCK_STREAM, 0);
	if (mListenSock == INVALID_SOCKET)
		return false;

	sa.sin_family = AF_INET;
	sa.sin_addr.s_addr = htonl(INADDR_ANY);
	sa.sin_port = htons(port);

	if (bind(mListenSock, (struct sockaddr *)&sa, sizeof(struct sockaddr_in)) != 0)
		return false;

#ifdef WIN32
	if (listen(mListenSock, 512) != 0)//SOMAXCONN
		return false;
#else
	if (listen(mListenSock, 512) != 0)
		return false;
#endif

	return true;
}

bool Server::Select(void)
{
	fd_set rfds, wfds;
	struct timeval tv;
	int cnt;
	list<Client *>::iterator it;
	Client *cli;
	list<Client *> RemoveList;

	tv.tv_sec = 0;//Seconds
	tv.tv_usec = 100;//Milliseconds

	FD_ZERO(&rfds);
	FD_ZERO(&wfds);
	if (mListenSock != INVALID_SOCKET)
	{
		FD_SET(mListenSock, &rfds);
		FD_SET(mListenSock, &wfds);
	}

	for (it = mClients.begin(); it != mClients.end(); it++)
	{
		FD_SET((*it)->GetSock(), &rfds);
		if (!(*it)->GetOutBuffer().empty())
			FD_SET((*it)->GetSock(), &wfds);
	}

	cnt = select(FD_SETSIZE, &rfds, &wfds, NULL, &tv);
	if (cnt < 0)
		return false;

	if (FD_ISSET(mListenSock, &rfds))
		if (!Accept())
			return false;

	for (it = mClients.begin(); it != mClients.end(); it++)
	{
		cli = *it;
		if (FD_ISSET(cli->GetSock(), &rfds))
		{
			cli->Touch();
			if (!Read(cli))
			{
				Disconnect(cli);
				RemoveList.push_back(cli);
			}
		}
	}
	for (it = RemoveList.begin(); it != RemoveList.end(); it++)
		mClients.remove(*it);
	RemoveList.clear();

	for (it = mClients.begin(); it != mClients.end(); it++)
	{
		cli = *it;
		if (FD_ISSET(cli->GetSock(), &wfds))
		{
			cli->Touch();
			if (!Write(cli))
			{
				Disconnect(cli);
				RemoveList.push_back(cli);
			}
		}
	}
	for (it = RemoveList.begin(); it != RemoveList.end(); it++)
		mClients.remove(*it);
	RemoveList.clear();

	for (it = mClients.begin(); it != mClients.end(); it++)
	{
		cli = *it;
		if (cli->IsTimedOut())
		{
			LogManager::GetSingleton().Log("Network.log", "** Client %s timeout\n", cli->GetHost().c_str());
			Disconnect(cli);
			RemoveList.push_back(cli);
		}
	}
	for (it = RemoveList.begin(); it != RemoveList.end(); it++)
		mClients.remove(*it);

	return true;
}

bool Server::Accept(void)
{
	struct sockaddr_in addr;
#ifdef WIN32
	int len;
#else
	socklen_t len;
#endif
	SOCKET newsock;
	Client *cli;
	int host;
	char hostname[16];
	unsigned long lo;
	fd_set rfds;
	struct timeval tv;

	do
	{
		len = sizeof(struct sockaddr_in);
		newsock = accept(mListenSock, (struct sockaddr *)&addr, &len);
		if (newsock == INVALID_SOCKET)
			return false;
		lo = 1;
#ifdef WIN32
		ioctlsocket(newsock, FIONBIO, &lo);
#else
		ioctl(newsock, FIONBIO, &lo);
#endif
		host = ntohl(addr.sin_addr.s_addr);
		sprintf(hostname, "%d.%d.%d.%d", (host >> 24) & 0xFF, (host >> 16) & 0xFF,
				(host >>  8) & 0xFF, (host      ) & 0xFF);

		cli = new Client(newsock);
		cli->GetHost() = hostname;
		cli->Touch();
		mClients.push_back(cli);

		LogManager::GetSingleton().Log("Network.log", "** Client %s connected\n", cli->GetHost().c_str());

		mClientCount++;
		ClientConnected(cli);

		// There has got to be a better way to find out how many
		// connections are pending :(
		FD_ZERO(&rfds);
		FD_SET(mListenSock, &rfds);
		tv.tv_sec = 0;
		tv.tv_usec = 0;
		if (select(FD_SETSIZE, &rfds, NULL, NULL, &tv) <= 0)
			break;

	} while (FD_ISSET(mListenSock, &rfds));

	return true;
}

void Server::CloseWhenClear(Client *cli)
{
	cli->mQueueClose = true;
}

void Server::Disconnect(Client *cli)
{
	mClientCount--;
	shutdown(cli->GetSock(), 2);
	ClientDisconnected(cli);
#ifdef WIN32
	closesocket(cli->GetSock());
#else
	close(cli->GetSock());
#endif
	LogManager::GetSingleton().Log("Network.log", "** Client %s DISconnected\n", cli->GetHost().c_str());
}

bool Server::Read(Client *cli)
{
	int read;
	Byte buf[1024];
	Word rword;

	while (true)
	{
		read = recv(cli->GetSock(), (char *)buf, sizeof(buf), 0);
		if (read < 0)
		{
			// For some fucked up reason, select() is saying there is data
			// to read when there isn't. I foudn this problem trying to get
			// our IRC bot to work. Perhaps outgoing connections readfds behaves
			// slightly differently, either way, the following will fix it.
#ifdef WIN32
			if (WSAGetLastError() != WSAEWOULDBLOCK)
				return false;
#else
			if (errno != EAGAIN)
				return false;
#endif
		}
		else if (read == 0)
			return false;

		rword = (Word)read;
		LogManager::GetSingleton().LogBinary("Network.bin", 0);
		LogManager::GetSingleton().LogBinary("Network.bin",
			(Byte)cli->GetHost().length());
		LogManager::GetSingleton().LogBinary("Network.bin",
			(Byte *)cli->GetHost().c_str(), (Word)cli->GetHost().length());
		LogManager::GetSingleton().LogBinary("Network.bin",
			(Byte *)&rword, 2);
		LogManager::GetSingleton().LogBinary("Network.bin", buf, rword);

		cli->RecvData(buf, read);

		if (read < (int)sizeof(buf))
			break;
	}

	ClientDataRecvd(cli);

	return true;
}

bool Server::Write(Client *cli)
{
	int len;

	len = send(cli->GetSock(), cli->GetOutBuffer().c_str(),
		(int) cli->GetOutBuffer().length(), 0);
	if (len == SOCKET_ERROR)
		return false;

	LogManager::GetSingleton().LogBinary("Network.bin", 1);
	LogManager::GetSingleton().LogBinary("Network.bin",
		(Byte)cli->GetHost().length());
	LogManager::GetSingleton().LogBinary("Network.bin",
		(Byte *)cli->GetHost().c_str(), (Word)cli->GetHost().length());
	LogManager::GetSingleton().LogBinary("Network.bin",
		(Byte *)&len, 2);
	LogManager::GetSingleton().LogBinary("Network.bin",
		(Byte *) cli->GetOutBuffer().c_str(), (Word)len);

	cli->GetOutBuffer() = cli->GetOutBuffer().substr(len);

	if (cli->GetOutBuffer().empty() && cli->mQueueClose)
		return false;

	return true;
}

void Server::WriteData(Client *cli, const unsigned char byte)
{
	if (!cli)
		return;

	cli->SendData(&byte, 1);
}

void Server::WriteData(Client *cli, const unsigned char *bytes, unsigned int len)
{
	if (!cli)
		return;

	cli->SendData(bytes, len);
}

void Server::WriteData(Client *cli, Packet *pack)
{
	if (!cli)
		return;

	unsigned short len;
	unsigned int op;

	pack->Compress();

	len = htons(4 + pack->GetDataLength());
	op = pack->GetOpCode();
	cli->SendData((unsigned char *)&len, 2);
	cli->SendData((unsigned char *)&op, 4);
	cli->SendData(pack->GetBytes(), pack->GetDataLength());

}

void Server::WriteData(Client *cli, LPacket *pack)
{
	if (!cli)
		return;

	Word len;
	Word op;

	len = pack->GetDataLength();
	op = pack->GetOpCode();
	cli->SendData((unsigned char *)&op, 2);
	cli->SendData((unsigned char *)&len, 2);
	cli->SendData(pack->GetBytes(), pack->GetDataLength());
}

Client *Server::Connect(const char *hostname, int port)
{
	struct sockaddr_in addr;
	SOCKET sock;
	struct hostent *host;
	Client *cli;
	unsigned long lo;

	host = gethostbyname(hostname);
	if (!host)
	{
		LogManager::GetSingleton().Log("Network.log",
			"** Hostname lookup for '%s' failed\n", hostname);
		return NULL;
	}

	addr.sin_addr.s_addr = inet_addr(inet_ntoa(*(struct in_addr *) host->h_addr_list[0]));
	addr.sin_family = AF_INET;
	addr.sin_port = htons(port);

	sock = socket(AF_INET, SOCK_STREAM, 0);
	if (sock == INVALID_SOCKET)
	{
		LogManager::GetSingleton().Log("Network.log",
			"** socket() call failed for connection to '%s'\n", hostname);
		return NULL;
	}

	if (connect(sock, (struct sockaddr *)&addr, sizeof(addr)) != 0)
	{
		LogManager::GetSingleton().Log("Network.log",
			"** Connect failed to '%s'\n", hostname);
		return NULL;
	}

	lo = 1;
#ifdef WIN32
	ioctlsocket(sock, FIONBIO, &lo);
#else
	ioctl(sock, FIONBIO, &lo);
#endif

	cli = new Client(sock);
	cli->GetHost() = hostname;
	cli->Touch();
	mClients.push_back(cli);
	mClientCount++;

	return cli;
}
