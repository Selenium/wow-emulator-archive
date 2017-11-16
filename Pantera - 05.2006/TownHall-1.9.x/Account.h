#ifndef ACCOUNT_H
#define ACCOUNT_H

#include "stdafx.h"
#include "WoWObject.h"

struct AccountData
{
	char Name[32];
	char Password[32];
	unsigned char SessionKey[40];
	unsigned long Characters[10];
	int UserLevel;
	long ip;
	char LockedToIP;

	time_t LastLogin;
	time_t SuspendedUntil;
};

class CAccount : public CWoWObject
{
public:
	CAccount(void);
	~CAccount(void);

	void Clear();
	void New();
	bool StoringData(ObjectStorage &Storage);
	bool LoadingData(ObjectStorage &Storage);
	unsigned long DataStorageSize() {return sizeof(AccountData);};
	bool Save();
	bool Load(FILE *fin,bool createflag = true);
	bool Save(FILE *fout);
	bool Create();

	AccountData Data;

	class CClient *pClient;
};

#endif // ACCOUNT_H
