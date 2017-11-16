#include "../LoginEnvironment.h"

template <class AccountManager> AccountManager *Singleton<AccountManager>::msSingleton = 0;

AccountManager::AccountManager()
{
}

// Method: VerifyAccount.
DoubleWord AccountManager::VerifyAccount(string accountName, string password)
{
	Database *db;
	int result;
	char *buffer;
	Field *fields;
	
	// Fetch the database connection.
	db = Database::GetSingletonPtr();

	if (!db || !*db)
	{
		printf("Couldnt Connect in the Database!\n");
		return 20;
	}
	
	// Should be large enough for a query.
	if ((buffer = new char[2048]) == 0)
		return 20;

	//! @todo Add password checking to this account query!
	snprintf(buffer, 2048, "SELECT * FROM accounts WHERE username = '%s';", accountName.c_str());

	result = db->Query(buffer);
	delete buffer;
	buffer = 0;

	// Did we find the matching account?
	if (result == 1)
	{
		fields = db->Fetch();
		int state = -1;
		
		state = atoi(fields[3].Value());

		// Then return the current Account State in DB.
		return state;
	}

	// If execution reaches this point, no matching account was found, so return 50.
	return 50;
}

void AccountManager::CreateNewAccount(string username, string password)
{
	Database *db;
	char *buf;
	
	db = Database::GetSingletonPtr();
	if (!db || !*db)
		return;
	
	buf = new char[2048];  // should be large enough
	if (!buf)
		return;

	snprintf(buf, 2048, "INSERT INTO accounts VALUES ('0','%s','%s','0');",
		username.c_str(),password.c_str());

	if (db->Query(buf))
		printf("The Account %s Has Been Added into the DB!\n",username.c_str());
}