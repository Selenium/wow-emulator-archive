#include <string.h>
#include "UserHashes.h"

createFileSingleton( UserHashes );

UserHashes::UserHashes()
{
}

UserHashes::~UserHashes()
{
	for( HashMap::iterator i = mHashes.begin( ); i != mHashes.end( ); ++ i )
		delete i->second;
}

void UserHashes::addHash(char *name, char *hash)
{
	removeHash(name);
	mHashes[name]=new UserHash();
	memcpy(mHashes[name]->SS_Hash, hash, 40);
}

char* UserHashes::getHash(char *name)
{
	if( mHashes.find( name ) != mHashes.end( ) )
		return mHashes[name] -> SS_Hash;
	else
		return NULL;
}

void UserHashes::removeHash(char *name)
{
	if( mHashes.find( name ) != mHashes.end( ) )
	{
		delete mHashes[ name ];
		mHashes.erase( name );
	}
}

void UserHashes::clearHashes()	// TODO
{
}

