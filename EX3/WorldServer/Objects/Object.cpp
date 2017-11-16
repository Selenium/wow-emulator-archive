// (c) AbyssX Group
#include "../WorldEnvironment.h"

// Constructor: Object.
Object::Object(QuadWord objectGuid, const char *name) :
	mObjectGuid(objectGuid), mName(name)
{
	mCurrentRegion = 0;
	mCurrentRegionList = new RegionList();
}

// Destructor: ~Object.
Object::~Object()
{
	delete mCurrentRegionList;
}

// Sets the current region list associated with the object.
void Object::SetCurrentRegionList(const RegionList &currentRegionList)
{
	*mCurrentRegionList = currentRegionList;
}
