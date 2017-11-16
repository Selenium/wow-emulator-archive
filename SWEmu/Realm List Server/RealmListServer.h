#ifndef REALMLISTSERVER_H
#define REALMLISTSERVER_H

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
	unsigned short Icon;/// 0 - Normal, 1 - PvP, 2 - Offline
	unsigned short Language;/// 0,1 - English, 2 - German, 3 - French, 4 - Other
};

struct RealmInfo
{
	unsigned long nPlayers;
	char Name[64];
	char IPAddr[16];
	unsigned long nIP;
	unsigned char RealmType;
	unsigned char Icon;/// 0 - Normal, 1 - PvP, 2 - Offline
	unsigned char Color;/// 0 - Normal, 1 - Red, 2 - Disabled
	unsigned char Language;/// 0,1 - English, 2 - German, 3 - French, 4 - Other
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
	unsigned long ShowRealm(RealmInfo &Info, char Total, char *buffer);
	void AddRealm(RealmPacket *realm, Addr &From);

	RealmInfo *GetNextVerify();

	inline void MapInsert(const char *IPAddr, unsigned short Port, unsigned long nRealm);
	inline int FindRealm(const char *IPAddr, unsigned short Port);
	//int FindRealm(unsigned long IP, unsigned long Port);
	bool Initialize();

	map<string,unsigned long> RealmMap;

	CSemaphore Verifying;
};

#endif // REALMLISTSERVER_H
