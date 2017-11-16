#pragma once
#include "stdafx.h"
#include "WinSocket.h"
#include "UDPSocket.h"
#include "Index.h"
#include <map>
#include <string>
#include "RealmVerifier.h"

using namespace std;

#define VERIFY_THREADS 3

struct RealmPacket
{
	unsigned short Port;
//	unsigned short AlignmentPadding;
	char Name[64];
	char IPAddr[16];
	unsigned long nPlayers;
};

struct RealmInfo
{
	unsigned long nPlayers;
	char Name[64];
	char IPAddr[16];
	unsigned long nIP;
	unsigned short Port;
	time_t LastUpdate;
	bool Active;
	time_t LastVerified;
};

class CRealmListServer
{
public:
	CRealmListServer(void);
	~CRealmListServer(void);

	CThread RealmThread;
	TCPSocket ListListener;
	UDPSocket MasterListener;

	CRealmVerifier *pRealmVerifiers[VERIFY_THREADS];

	CIndex<RealmInfo *> Realms;
	void CleanupExpired();
	unsigned long ShowRealm(TCPSocket *socket, RealmInfo &Info, char Total, char *buffer);
	void AddRealm(RealmPacket *realm, Addr &From);

	RealmInfo *GetNextVerify();

	inline void MapInsert(const char *IPAddr, unsigned short Port, unsigned long nRealm);
	inline int FindRealm(const char *IPAddr, unsigned short Port);
	//int FindRealm(unsigned long IP, unsigned long Port);
	bool Initialize();

	map<string,unsigned long> RealmMap;

	CSemaphore Verifying;
};
