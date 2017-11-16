// (c) AbyssX Group
#include "../WorldEnvironment.h"


// Constructor: Region.
Region::Region() : mXCoordinate(0), mYCoordinate(0), mSize(0)
{
}

// Constructor: Region.
Region::Region(float x, float y, float size) : mXCoordinate(x), mYCoordinate(y), mSize(size)
{
}

// Destructor: ~Region.
Region::~Region()
{
	// Players and objects are removed from lists when they go out of scope. No deallocation needed.
}

// Method: AddPlayer.
void Region::AddPlayer(Player *player)
{
	mPlayerList.push_back(player);
}

// Method: RemovePlayer [Player *].
bool Region::RemovePlayer(Player *player)
{
	Region::PlayerIterator i;

	for (i=mPlayerList.begin(); i!=mPlayerList.end(); i++)
	{
		if (player == (*i))
		{
			mPlayerList.erase(i);
			return true;
		}
	}
	
	// No matching player was found, so return false.
	return false;
}

// Method: RemovePlayer [index].
void Region::RemovePlayer(PlayerIterator &i)
{
	mPlayerList.erase(i);
}

// Method: AddObject.
void Region::AddObject(Object *object)
{
	mObjectList.push_back(object);
}

// Method: RemoveObject [Object *].
bool Region::RemoveObject(Object *object)
{
	Region::ObjectIterator i;

	for (i=mObjectList.begin(); i!=mObjectList.end(); i++)
	{
		if (object == (*i))
		{
			mObjectList.erase(i);
			return true;
		}
	}
	
	// No matching Object was found, so return false.
	return false;
}

// Method: RemoveObject [index].
void Region::RemoveObject(ObjectIterator &i)
{
	mObjectList.erase(i);
}
