#include "stdafx.h"
#include "RealmListServer.h"
#include <vector>
using namespace std;
// listen on port 9000
// on connect, send data
// then disconnect

/*
 00000000:  01 46 72 69-65 6E 64 73-20 61 6E 64-20 46 61 6D  .Friends and Fam
 00000010:  69 6C 79 00-31 32 2E 31-32 39 2E 32-33 33 2E 33  ily 12.129.233.3
 00000020:  30 3A 39 30-39 30 00 33-01 00 00   -             0:9090 3.
/**/

/*
class CRealmListClient
{
public:
	TCPSocket sock;
	CRealmListClient *pNext;
	CRealmListClient *pPrev;
	time_t lastActive;
	CRealmListClient() {pNext = NULL; pPrev = NULL;lastActive = time(0);};
	~CRealmListClient() 
	{
		if(pPrev != NULL)
			pPrev->pNext = pNext;
		if(pNext != NULL)
			pNext->pPrev = pPrev;

	}
};*/
struct RealmListClient
{
	SOCKET sock;
	time_t lastActive;
};

THREAD WINAPI RealmListServerThreadFunction( LPVOID pParam )
{
	CThread *pThread=(CThread*)pParam;
	CLock L(&pThread->Threading,true);
	pThread->bThreading=true;
	pThread->ThreadReady=true;
	CRealmListServer *pServer=(CRealmListServer*)pThread->Info;

	//TCPSocket nextclient;
	char pkg0[5] = {0x03, 0x00, 0x00, 0x00, 0x00};
	char pkg2[34] = {0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
		0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
		0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
	char pkg3[2] = {0x03, 0x00};

	char buffer[2048];
	char FullList[20480];
	Addr From;
	time_t LastCleanup=time(0);
	vector<RealmListClient> clients;
	TCPSocket aSock;
	RealmListClient aClient;
	while(!pThread->CloseThread)
	{
		
		if(clients.size() < 100)
		{
			int N=0;
			// try to get a few new clients
			aSock.m_hSocket = INVALID_SOCKET;
			if (pServer->ListListener.Accept(aSock))
			{
				do
				{
					aClient.lastActive = time(0);
					aClient.sock = aSock.m_hSocket;
					clients.push_back(aClient);
					aSock.m_hSocket = INVALID_SOCKET;
					N++;
				}
				while(N<5 && pServer->ListListener.Accept(aSock));
			}
		}


		unsigned char TotalSent;
		unsigned long Pos;
		unsigned short alen;
		TotalSent=0;
		Pos=7;
		FullList[7]=0x00;
		for (unsigned long i=0 ; i < pServer->Realms.Size ; i++)
		{
			if (RealmInfo *pRealm=pServer->Realms[i])
			{
				if (pRealm->Active)
				{
					unsigned long Temp=pServer->ShowRealm(NULL,*pRealm,TotalSent+1,&FullList[Pos]);
					Pos+=Temp;
					TotalSent++;
					if (TotalSent>=250)
						break;
				}
			}
		}
		FullList[0] = 0x10;
		alen = (unsigned short)(Pos-3);
		*(unsigned short*)&FullList[1] = alen;
		*(unsigned char*)&FullList[3]=TotalSent;
		FullList[4]=0x00;
		FullList[5]=0x00;
		FullList[6]=0x00;

		vector<RealmListClient> tmplist = clients;
		clients.clear();
		// process current clients
		for(vector<RealmListClient>::iterator iter = tmplist.begin();iter != tmplist.end();iter++)
		{
			aSock.m_hSocket = iter->sock;
			long dataLen;
			if((dataLen = aSock.isData()) != 0)
			{
				if(dataLen < 3)
					continue;
				/*
				if(aSock.Receive((char*)&alen, 2, MSG_PEEK) != 2)
					continue;
				alen = (alen >> 8) | ((alen & 0xFF) << 8);
				alen += 2;
				// check that all data has been received
				if(dataLen < alen)
					continue;
				if(alen > 2048 || aSock.Receive(&buffer[0], alen) != alen)
				{
				*/
				if(dataLen > 2048 || aSock.Receive(&buffer[0], dataLen) != dataLen) {
					// something is wrong... remove client
					aSock.Close();
					iter->sock = INVALID_SOCKET;
				//	clients.erase(iter);
					continue;
				}
				// handle packets
				switch(buffer[0]) // pkgID
				{
				case 0: // crypt key request for patch server
					iter->lastActive = time(0);
					aSock.Send(pkg0, 5);
					break;
				case 2: // crypt key request for realm list server
					iter->lastActive = time(0);
					aSock.Send(pkg2, 34);
					break;
				case 3: // password auth request
					iter->lastActive = time(0);
					aSock.Send(pkg3, 2);
					break;
				case 16: // realm list request
					if(TotalSent==0) // && Pos>1)
						aSock.Send(&FullList[0],8);
					else
						aSock.Send(&FullList[0],Pos);
					aSock.Close();
					iter->sock = INVALID_SOCKET;
					//clients.erase(iter);
					break;
				}
			}
			else if(difftime(time(0), iter->lastActive) > 30.0f) 
			{
				// client timed out
				aSock.Close();
				iter->sock = INVALID_SOCKET;
				//clients.erase(iter);
			}

		}
		for(iter = tmplist.begin();iter != tmplist.end();iter++)
		{
			if(iter->sock != INVALID_SOCKET)
				clients.push_back(*iter);
		}

		if (pServer->MasterListener.isData())
		{
			int len=pServer->MasterListener.RecvFrom(buffer,2048,From);
			if (len==sizeof(RealmPacket))
			{
				pServer->AddRealm((RealmPacket*)&buffer[0],From);
			}
			else
			{
//				printf("Packet size received %d vs %d\n",len,sizeof(RealmPacket));
			}
		}
		if (difftime(time(0),LastCleanup)>30.0f)
		{
			pServer->CleanupExpired();
			LastCleanup = time(0);
		}
		Sleep(10); // 50 per second
	}
	pThread->bThreading=false;
	return 0;
}

CRealmListServer::CRealmListServer(void)
{
	unsigned long i;
	for ( i = 0 ; i < VERIFY_THREADS ; i++)
		pRealmVerifiers[i]=0;
/*
// testing purposes
	Addr From;
	RealmPacket Packet;
	Packet.Port=1111;
	Packet.nPlayers=0;
	Packet.IPAddr[0]=0;
	strcpy(Packet.Name,"Test 1");
	From.IP=inet_addr("192.168.1.100");
	AddRealm(&Packet,From);
	Packet.Port=1112;
	strcpy(Packet.Name,"Test 2");
	AddRealm(&Packet,From);
/**/
	if (Initialize())
	{
		RealmThread.BeginThread(RealmListServerThreadFunction,this);
		for ( i = 0 ; i < VERIFY_THREADS ; i++)
		{
			pRealmVerifiers[i]=new CRealmVerifier(this);
			pRealmVerifiers[i]->Go();
		}
	}
}

CRealmListServer::~CRealmListServer(void)
{
	for (unsigned long i = 0 ; i < VERIFY_THREADS ; i++)
	{
		if (pRealmVerifiers[i])
			delete pRealmVerifiers[i];
	}
	RealmThread.EndThread();
	Realms.Cleanup();
}

bool CRealmListServer::Initialize()
{
	if (!ListListener.Create(3724))
		return false;
	if (!ListListener.Listen())
		return false;
	if (!MasterListener.Create(9111))
		return false;
	return true;
}


unsigned long CRealmListServer::ShowRealm(TCPSocket *socket, RealmInfo &Info, char Total,char *buffer)
{
/*
 00000000:  01 46 72 69-65 6E 64 73-20 61 6E 64-20 46 61 6D  .Friends and Fam
 00000010:  69 6C 79 00-31 32 2E 31-32 39 2E 32-33 33 2E 33  ily 12.129.233.3
 00000020:  30 3A 39 30-39 30 00 33-01 00 00   -             0:9090 3.
/**/
//	char Out[256]={0};
	char sPort[12]={0};
	char c=0;
	buffer[c++]=Total;
	strcpy(&buffer[c], Info.Name);
	c+=strlen(Info.Name)+1;

	strcpy(&buffer[c],Info.IPAddr);
	c+=strlen(Info.IPAddr);

	buffer[c++]=':';
	sprintf(sPort,"%u",Info.Port);
	strcpy(&buffer[c],sPort);
	c+=strlen(sPort)+1;
	*(unsigned long*)&buffer[c]=Info.nPlayers;
	c+=4;
	//socket->Send(Out,c);
	return c;
}

void CRealmListServer::AddRealm(RealmPacket *realm, Addr &From)
{
	realm->Name[63]=0;
	// lets block all ports other than 9090.
	if (realm->Port!=9090)
		return;

	char IPAddr[16];
	if (realm->IPAddr[0])
		strcpy(IPAddr,realm->IPAddr);
	else
		strcpy(IPAddr,inet_ntoa(*(in_addr*)&From.IP));

	int N=FindRealm(IPAddr,realm->Port);
	if (N>=0)
	{
		RealmInfo *pInfo=Realms[N];
		// update existing
		if (!pInfo->Active)
		{
			if (difftime(time(0),pInfo->LastVerified)>60.0f)
				pInfo->LastVerified=0;// accelerate check
		}

		strcpy(pInfo->Name,realm->Name);
		pInfo->nPlayers=realm->nPlayers;
		pInfo->LastUpdate=time(0);
	}
	else// if (nRealms<250)
	{
		// add new
		RealmInfo *pRealm = new RealmInfo;
		pRealm->nIP=From.IP;
		pRealm->Port=realm->Port;
		strcpy(pRealm->Name,realm->Name);
		pRealm->LastUpdate=time(0);
		pRealm->LastVerified=0;
		pRealm->Active=false;
		strcpy(pRealm->IPAddr,IPAddr);
		pRealm->nPlayers=realm->nPlayers;
		unsigned long N=Realms.GetUnused();
		Realms[N]=pRealm;
		MapInsert(IPAddr,realm->Port,N);
//		printf("New Realm: %s %s:%d\n",pRealm->Name,pRealm->IPAddr,pRealm->Port);
		
	}
}

/*
int CRealmListServer::FindRealm(unsigned long IP, unsigned long Port)
{
	for (unsigned long i = 0 ; i < Realms.Size ; i++)
	{
		if (RealmInfo *pRealm=Realms[i])
		{
			if (pRealm->nIP==IP && pRealm->Port==Port)
				return i;
		}
	}
	return -1;
}
/**/
int CRealmListServer::FindRealm(const char *IPAddr, unsigned short Port)
{
	char TestBuffer[25];
	sprintf(TestBuffer,"%s:%u",IPAddr,Port);
	return RealmMap[TestBuffer]-1;
}

void CRealmListServer::MapInsert(const char *IPAddr, unsigned short Port, unsigned long nRealm)
{
	char TestBuffer[25];
	sprintf(TestBuffer,"%s:%u",IPAddr,Port);
	RealmMap[TestBuffer]=nRealm+1;
}

void CRealmListServer::CleanupExpired()
{
	time_t now=time(0);
	for (unsigned long i = 0 ; i < Realms.Size ; i++)
	{
		if (RealmInfo *pRealm=Realms[i])
		{
			// 2.5 mins recycle time
			if (difftime(now,pRealm->LastUpdate)>150.0f)
			{
				// you are the weakest link, goodbye
//				printf("Expired realm %s %s:%d\n",pRealm->Name,pRealm->IPAddr,pRealm->Port);
//				delete pRealm;
//				Realms[i]=0;
				pRealm->Active=false;
			}
		}
	}
}

RealmInfo *CRealmListServer::GetNextVerify()
{
	CLock L(&Verifying,1);
	time_t now=time(0);
	for (unsigned long i = 0 ; i < Realms.Size ; i++)
	{
		if (RealmInfo *pRealm=Realms[i])
		{
			if (difftime(now,pRealm->LastUpdate)<150.0f && difftime(now,pRealm->LastVerified)>600.0f)
			{
				pRealm->LastVerified=now;
				return pRealm;
			}
		}
	}
	return 0;
}
