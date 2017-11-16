#include "Account.h"
#include "Player.h"
#include "Client.h"
#include "Globals.h"

CAccount::CAccount(void):CWoWObject(OBJ_ACCOUNT)
{
	pClient=NULL;
}

CAccount::~CAccount(void)
{
	Delete();
}

void CAccount::Clear()
{
	CWoWObject::Clear();
	pClient=NULL;
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

bool CAccount::Create() {
	/*
	char filename[256];
	sprintf(filename,"%s/%s",Settings.accounts_path,Data.Name);
	FILE *fout = fopen(filename, STORAGE_CREATE);
	if(!fout) return false;
	fclose(fout);
	*/
	DataManager.NewObject(*this);
	string name=Data.Name;
	DataManager.AccountNames[name]=guid;
	DataManager.NewObject(*this);
	return true;
}

bool CAccount::Save(FILE *fout) {
	return DataManager.StoreObject(*this);
	/*
	long size = sizeof(AccountData);
	fwrite(&Data, size, 1, fout);
	for (int i = 0 ; i < 10 ; i++)
	{
		if (guid_t CharID=Data.Characters[i])
		{
			CPlayer *pPlayer=NULL;
			if (DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,CharID))
			{
				if (!pPlayer->Save(fout))
					return false;
			}
		}
	}
	return true;
	*/
}

bool CAccount::Load(FILE *fin, bool createflag) {
	long size = sizeof(AccountData);
	char *buffer = (char*)malloc(size);
	if(!buffer) return false;
	if (fread(buffer, size, 1, fin) != 1)
	{
		free(buffer);
		return false;
	}
	AccountData *inData = (AccountData *)buffer;

	memcpy(&Data,inData,sizeof(AccountData));
	if(Data.UserLevel == USER_DELETE)
	{
		free(buffer);
		return false; // this account will be hauled away and executed by the public executioner!
	}
	for (int i = 0 ; i < 10 ; i++)
	{
		if (guid_t CharID=inData->Characters[i])
		{
			CPlayer *pPlayer=NULL;
			if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, CharID))
			{
				pClient->Characters[i]=new CPlayer;
				if (!pClient->Characters[i]->Load(fin,CharID,createflag))
				{
					free(buffer);
					return false;
				}
				//DataManager.NewObject(*pClient->Characters[i]);
				pClient->nCharacters++;
#ifndef ACCOUNTLESS
				pClient->pAccount->Data.Characters[i]=pClient->Characters[i]->guid;
				pClient->Characters[i]->AccountID = pClient->pAccount->guid;
#endif
			}
			else //well, most of the time these will be precached objects!
			{
				pClient->Characters[i]=pPlayer;
				pClient->nCharacters++;
#ifndef ACCOUNTLESS
				pClient->pAccount->Data.Characters[i]=pClient->Characters[i]->guid;
				pClient->Characters[i]->AccountID = pClient->pAccount->guid;
#endif
			}
		}
	}
	if (createflag)
	{
		DataManager.AccountNames[inData->Name]=guid;
		DataManager.NewObject(*this);
	}
	if(Data.UserLevel==USER_BANNED) Settings.Banned[Data.ip]=1; //This session only, but next boot, this IP will be banned again!
	free(buffer);
	return true;
}

bool CAccount::Save() {
	return DataManager.StoreObject(*this);
	/*
	char filename[256];
	sprintf(filename,"%s/%s",Settings.accounts_path,Data.Name);
	FILE *fout = fopen(filename, STORAGE_WRITE);
	if(!fout) return false;
	if (!Save(fout))
	{
		fclose(fout);
		return false;
	}
	fclose(fout);
	return true;
	*/
}

bool LoadAccount(char *name, CClient *pClient, bool createflag) {
	CAccount *pNewAccount = NULL;
	string acctname=name;
	if(!DataManager.RetrieveObject((CWoWObject**)&pNewAccount,OBJ_ACCOUNT,DataManager.AccountNames[acctname]))
		return false;
	pClient->pAccount=pNewAccount;
	for (int i = 0 ; i < 10 ; i++)
	{
		if (guid_t CharID=pNewAccount->Data.Characters[i])
		{
			CPlayer *pPlayer=NULL;
			if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, CharID))
			{
				return false;
			}
			else //well, most of the time these will be precached objects!
			{
				pClient->Characters[i]=pPlayer;
				pClient->nCharacters++;
#ifndef ACCOUNTLESS
				pClient->Characters[i]->AccountID = pNewAccount->guid;
#endif
			}
		}
	}
	return true;
	/*
	char filename[256];
	sprintf(filename,"%s/%s",Settings.accounts_path,name);
	FILE *fin = fopen(filename, STORAGE_READ);
	if(!fin) return false;

	// new account
	CAccount *pNewAccount = new CAccount;
	pNewAccount->New();
	pNewAccount->pClient=pClient;
	pClient->pAccount=pNewAccount;
	if (!pNewAccount->Load(fin,createflag))
	{
		delete pNewAccount;
		pClient->pAccount = NULL;
		fclose(fin);
		remove(filename); //who cares if it fails? Toast the file!
		return false;
	}
	fclose(fin);
	return true;
	*/
}
