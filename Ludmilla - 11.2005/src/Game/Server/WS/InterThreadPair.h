//******************************************************************************
#ifndef __INTERTHREADPAIR_H
#define __INTERTHREADPAIR_H
//==============================================================================
template <class COwner, class CPair>
class CInterThreadPair
{
public:

	CInterThreadPair():OwnerCanDie(false),WantToDie(false) {}

	// Link to pair, NULL if pair is deleted
	CPair* pair;

	// Owner says that he want to delete himself
	void LetMeDie() { WantToDie = true; }

	// Owner says true, if he want to delete himself
	bool WantYouDie() { return WantToDie; }

	// Pair says that owner now can delete himself
	void YouCanDie() { OwnerCanDie = true; }

	// Pair says true, if it let owner to delete himself
	bool CanDie() { return OwnerCanDie; }

	// Hold owner, don't let him die
	//void PleaseDontDieNow() {lock.lock()}

	// Release owner, now he can ask for death
	//void DieIfYouWant() {lock.release()}

protected:

	// Owner can't ask for death
	//ZThread::Mutex lock;

	// Owner want to delete himself
	bool WantToDie; // read for pair, write for owner

	// Owner now can safely delete himself
	bool OwnerCanDie; // read for owner, write for pair
};
//==============================================================================
#endif // __INTERTHREADPAIR_H
//******************************************************************************