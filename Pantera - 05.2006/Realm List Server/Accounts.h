#ifndef ACCOUNTS_H
#define ACCOUNTS_H

#include "stdafx.h"

struct AccountData
{
	char Name[32];
	char Password[32];
	unsigned char SessionKey[40];
	time_t LastLogin;
};

class CAccount
{
public:
	CAccount(void);
	~CAccount(void);

	void Clear();
	void New();
	bool Save();
	bool Load(FILE *fin,bool createflag = false);
	bool Save(FILE *fout);
	bool Create();
	bool Create(const char *name);
	bool Create(const char *name, const char *password);

	AccountData Data;
};

#endif // ACCOUNTS_H
