#if !defined(ACCOUNT_H)
#define ACCOUNT_H


//! Represents a player account.
/*! Communicates account settings with the database. */
class Account
{
public:
	//! Returns the account's id.
	/*! @return The id for this account. */
	DoubleWord GetAccountId(void) { return mAccountId; };

	//! Sets the account's id.
	/*! @param accountId Id to set for this account. Changes won't be updated when saving accounts though. */
	void SetAccountId(DoubleWord accountId) { mAccountId = accountId; };

	//! Returns the account's name.
	/*! @return The name for this account. */
	string GetName(void) { return mAccountName; };

	//! Sets a new name for this account.
	/*! @param name The new name for this account. */
	void SetName(string name) { mAccountName = name; };

	//! Returns the account's password.
	/*! @return The password in plain text for this account. */
	string GetPassword(void) { return mPassword; };

	//! Sets a new password for this account.
	/*! @param password The new plain text password for this account. */
	void SetPassword(string password) { mPassword = password; };

	//! Returns the account's creation timestamp.
	/*! @return Time when the account was created, in minutes since 1900 (system time). */
	DoubleWord GetCreationTime() { return mCreationTime; };

	//! Sets the creation timestamp for this account.
	/*! @param newTime New time in minutes since 1900 (system time). */
	void SetCreationTime(DoubleWord newTime) { mCreationTime = newTime; };

private:
	//! Holds the accountId.
	DoubleWord mAccountId;

	//! Holds the account name.
	string mAccountName;

	//! Holds the password.
	string mPassword;

	//! Holds the account creation date.
	DoubleWord mCreationTime;
};

#endif
