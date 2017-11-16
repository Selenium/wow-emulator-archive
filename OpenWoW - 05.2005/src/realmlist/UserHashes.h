#ifndef WSD_USERHASHES_H
#define WSD_USERHASHES_H

#include <map>
#include <string>
#include "Singleton.h"

#define USERHASHES (UserHashes::getSingleton ())

class UserHashes : public Singleton <UserHashes>
{
public:
	UserHashes();
	~UserHashes();
	void addHash(char *name, char *hash);
	char* getHash(char *name);
	void removeHash(char *name);
	void clearHashes();	// TODO

protected:
	struct UserHash
	{
		char SS_Hash[40];
		// some time sign, probably platform dependant
		// DWORD / GetTickCount() <-> WINDOWS
		// struct timeval / gettimeofday() <-> LINUX
	};

	typedef std::map <std::string, UserHash *> HashMap;
	HashMap mHashes;
};

#endif
