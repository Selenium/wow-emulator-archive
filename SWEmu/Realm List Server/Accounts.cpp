#include "Accounts.h"

CAccount::CAccount(void){}

CAccount::~CAccount(void)
{
	Clear();
}

void CAccount::Clear()
{
	memset(&Data,0,sizeof(AccountData));
}

void CAccount::New()
{
	Clear();
}

bool CAccount::Create()
{
	char filename[256];
	sprintf(filename,"Accounts/%s",Data.Name);
	//uncomment next line to enable already-created checking
	//if(_FileExists(filename)) return false;
	FILE *fout = fopen(filename, "w+b");
	if(fout == NULL) {
		return false;
	} 
	fclose(fout);
	return Save();
}

bool CAccount::Create(const char *name)
{
	strcpy(Data.Name,name);
	return Create();
}

bool CAccount::Create(const char *name, const char *password)
{
	strcpy(Data.Name,name);
	strcpy(Data.Password,password);
	return Create();
}

bool CAccount::Save(FILE *fout) {
	long size = sizeof(AccountData);
	fwrite(&Data, size, 1, fout);
	return true;
}

bool CAccount::Load(FILE *fin, bool createflag) {
	long size = sizeof(AccountData);
	char *buffer = (char*)malloc(size);
	if(buffer == NULL)
	{
		return false;
	}
	if (fread(buffer, size, 1, fin) != 1) {
		free(buffer);
		return false;
	}
	memcpy(&Data,buffer,sizeof(AccountData));
	free(buffer);
	return true;
}

bool CAccount::Save() {
	char filename[256];
	sprintf(filename,"Accounts/%s",Data.Name);
	FILE *fout = fopen(filename, "r+b");
	if(fout == NULL) {
		return false;
	} 
	if (!Save(fout)) {
		fclose(fout);
		return false;
	}
	fclose(fout);
	return true;
}

CAccount *LoadAccount(const char *name,bool createflag) {
	char filename[256];
	sprintf(filename,"Accounts/%s",name);
	FILE *fin = fopen(filename, "rb");
	if(fin == NULL) {
		CAccount *pAccount = new CAccount;
		pAccount->Clear();
		strcpy(pAccount->Data.Password,"nopass");
		if(createflag)
		{
			if(pAccount->Create(name))
			{
				return pAccount;
			}
		}
		delete pAccount;
		return NULL;
	}

	// new account
	CAccount *pNewAccount = new CAccount;
	pNewAccount->New();
	if (!pNewAccount->Load(fin,false)) {
		delete pNewAccount;
		fclose(fin);
		return NULL;
	}
	fclose(fin);
	return pNewAccount;
}
