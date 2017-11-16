// (c) Abyss Group
#include "RedirectEnvironment.h"

int main(int argc, char **argv)
{
#ifdef WIN32
	WSADATA wsdata;

	if (WSAStartup(MAKEWORD(2, 0), &wsdata) != 0)
	{
		fprintf(stderr, "Could not initialize WinSock\n");
		return 0;
	}
#endif

	new Config();
	if (!Config::GetSingleton().SetSource("AbyssX.conf"))
	{
		fprintf(stderr, "Could not find AbyssX.conf configuration\n");
		delete Config::GetSingletonPtr();
		return 0;
	}
	new LogManager("RedirectServer");
	new RedirectServer;

	RedirectServer::GetSingleton().Run();

	delete RedirectServer::GetSingletonPtr();
	delete LogManager::GetSingletonPtr();
	delete Config::GetSingletonPtr();

#ifdef WIN32
	WSACleanup();
#endif

	return 0;
}
