// (c) Abyss Group
#include "RedirectEnvironment.h"

template <class RedirectServer> RedirectServer *Singleton<RedirectServer>::msSingleton = 0;

RedirectServer::RedirectServer()
{
	LogManager::GetSingleton().SetLive("Debug.log", true);
}

RedirectServer::~RedirectServer()
{
}

void RedirectServer::Run(void)
{
	ConfigCursor cfg = Config::GetSingleton().Cursor();

	if (!cfg.Find("RedirectServer") || !cfg.FindIn("ListenPort"))
	{
		fprintf(stderr, "No configured ListenPort for RedirectServer\n");
		return;
	}
	mLPort = atoi(cfg[0]);
	if (mLPort < 1024 || mLPort > 9999)
	{
		fprintf(stderr, "ListenPort must be between 1024 and 9999, not %d\n", mLPort);
		return;
	}
	cfg.Reset();
	if (!cfg.Find("RedirectServer") || !cfg.FindIn("RedirectHost"))
	{
		fprintf(stderr, "No configured RedirectHost for RedirectServer\n");
		return;
	}
	mRHost = cfg[0];
	cfg.Reset();
	if (!cfg.Find("RedirectServer") || !cfg.FindIn("RedirectPort"))
	{
		fprintf(stderr, "No configured RedirectPort for RedirectServer\n");
		return;
	}
	mRPort = atoi(cfg[0]);
	if (mRPort < 1024 || mRPort > 9999)
	{
		fprintf(stderr, "RedirectPort must be between 1024 and 9999, not %d\n", mRPort);
		return;
	}

	if (!Listen(mLPort))
		return;

	while (true)
	{
		if (!Select())
			return;
	}
}

void RedirectServer::ClientConnected(Client *cli)
{
	char buf[64];

	LogManager::GetSingleton().Log("Debug.log", "Redirected %s to %s:%d\n",
		cli->GetHost().c_str(), mRHost.c_str(), mRPort);

	sprintf(buf, "%s:%d", mRHost.c_str(), mRPort);
	WriteData(cli, (unsigned char *)buf, (unsigned int)strlen(buf)+1);
	cli->SetTimeout(2);
}

void RedirectServer::ClientDataRecvd(Client *cli)
{
	LogManager::GetSingleton().Log("Debug.log", "%s disconnected\n",
		cli->GetHost().c_str());
}
