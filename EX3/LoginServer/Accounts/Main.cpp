#include "../LoginEnvironment.h"
#include <conio.h>


// Function: Main.
int main(int argc, char **argv)
{
	char errorBuffer[255];
	new Config();
	if (Config::GetSingleton().SetSource("AbyssX.conf") == false)
	{
		printf("Failed to initialize logging\n");
		getch();
		return 1;
	}

	Config::GetSingleton().Parse(errorBuffer, 255);

	new LogManager("AccountTesting");
	new DatabaseMysql("200.171.6.148;root;fred300;abyssx");
	AccountManager am(0);
	Account account;

//	account.SetName("sprattel");
//	account.SetPassword("hej");

	if (am.VerifyAccount("sprattelina", "") == false)
	{
		printf("Account was invalid\n");
		getch();
		return 1;
	}

	printf("Account verified ok!\n");

	am.RemoveExpiredAccounts();


/*	if (am.LoadAccount("sprattelina", account) == false)
	{
		printf("Failed to load account\n");
		getch();
		return 1;
	}

	printf("Account loaded successfully!\n");

	printf("Account id: %d\nAccount name: %s\nAccount password: %s\nTimestamp: %d\n", account.GetAccountId(), 
		account.GetName().c_str(), account.GetPassword().c_str(), (int)account.GetCreationTime());

*/
/*	account.SetAccountId(8);
	account.SetName("sprattelina");
	account.SetPassword("lalala");

	if (am.SaveAccount(account) == false)
	{
		printf("Failed to save account\n");
		getch();
		return 1;
	}

	printf("Saved account successfully\n");
*/
	getch();

	// Release used resources.
	delete Config::GetSingletonPtr();
	delete LogManager::GetSingletonPtr();

	return 0;
}
