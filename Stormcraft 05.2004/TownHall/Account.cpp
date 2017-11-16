#include "Account.h"

CAccount::CAccount(void):CWoWObject(OBJ_ACCOUNT)
{
	pClient=0;
}

CAccount::~CAccount(void)
{
	Delete();
}

void CAccount::Clear()
{
	CWoWObject::Clear();
	pClient=0;
	memset(&Data,0,sizeof(AccountData));
}

void CAccount::New()
{
	Clear();
	CWoWObject::New();
}

bool CAccount::StoringData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	Storage.Allocate(sizeof(AccountData));
	memcpy(Storage.Data,&Data,sizeof(AccountData));
	return true;
}

bool CAccount::LoadingData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	memcpy(&Data,Storage.Data,sizeof(AccountData));
	return true;
}


