#pragma once
#include "stdafx.h"
#include "WoWObject.h"

struct AccountData
{
	char Name[32];
	char Password[32];
	unsigned long Characters[10];
	int UserLevel;

	time_t LastLogin;
	unsigned long LastIP;
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


	AccountData Data;

	class CClient *pClient;
};
