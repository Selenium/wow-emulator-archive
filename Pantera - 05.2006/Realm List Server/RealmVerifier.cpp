#include "RealmVerifier.h"
#include "RealmListServer.h"

THREAD WINAPI RealmVerifierThreadFunction( LPVOID pParam )
{
	CThread *pThread=(CThread*)pParam;
	CLock L(&pThread->Threading,true);
	pThread->bThreading=true;
	pThread->ThreadReady=true;
	CRealmVerifier *pVerifier=(CRealmVerifier*)pThread->Info;
	CRealmListServer *pServer=pVerifier->pRealmList;
	TCPSocket VerifySocket;
	VerifySocket.Create(0);
	while(!pThread->CloseThread)
	{
		if (RealmInfo *pRealm=pServer->GetNextVerify())
		{
			// determine if this should be marked active or not, and mark it.
			// for now.. assume if we can connect to port 9090 its ok :)
			pRealm->Active=VerifySocket.Connect(pRealm->IPAddr,pRealm->Port);
			VerifySocket.Disconnect();
		}
		Sleep(15);
	}

	return (THREAD)0;
}

CRealmVerifier::CRealmVerifier(CRealmListServer *pList)
{
	pRealmList=pList;
}

CRealmVerifier::~CRealmVerifier(void)
{
	VerifierThread.EndThread();
}

void CRealmVerifier::Go()
{
	VerifierThread.BeginThread(RealmVerifierThreadFunction,this);
}
