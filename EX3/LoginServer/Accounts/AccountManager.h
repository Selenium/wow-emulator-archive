#if !defined(ACCOUNTMANAGER_H)
#define ACCOUNTMANAGER_H

//! Manages the accounts within the game.
/*!  */
class AccountManager : public Singleton<AccountManager>
{
public:
	// Constructor: AccountManager.
	/*! */
	AccountManager();

	// Destructor: ~AccountManager.
	/*! */
	~AccountManager() {};
    
	//! Verifies that the account exists and that login information is correct.
	/*! @param accountName Name of the account to verify.
		@param password Password of the account to verify.
		@return True if the account exists and is ok, false otherwise. */
	DoubleWord VerifyAccount(string accountName, string password);

	void CreateNewAccount(string, string);

private:
	//! Number of days that accounts will be valid before removed.
	DoubleWord mDaysValid;
};


#endif
