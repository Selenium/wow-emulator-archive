// (c) AbyssX Group
#include "../WorldEnvironment.h"

// Constructor: Unit.
Unit::Unit(QuadWord objectGuid, const char *name) : Object(objectGuid, name)
{
	mMoveFlags = 0x00000000;
	memset(&mDamages,0x00,sizeof(mDamages));
}

