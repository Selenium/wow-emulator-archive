// (c) AbyssX Group
#include "../WorldEnvironment.h"


// Constructor: RegionList.
RegionList::RegionList()
{
}

// Destructor: ~RegionList.
RegionList::~RegionList()
{
}

// Copy-constructor: RegionList.
RegionList::RegionList(RegionList &rhs)
{
	this->mRegionList = rhs.mRegionList;
}

// Assignment operator.
RegionList &RegionList::operator=(const RegionList &rhs)
{
	this->mRegionList = rhs.mRegionList;
	return *this;
}

// Method: AddRegion.
void RegionList::AddRegion(Region *region)
{
	mRegionList.push_back(region);
}

// Method: RemoveRegion.
bool RegionList::RemoveRegion(Region *region)
{
	list<Region *>::iterator i;

	for (i=mRegionList.begin(); i!=mRegionList.end(); i++)
	{
		if (region == (*i))
		{
			mRegionList.erase(i);
			return true;
		}
	}

	// No match was found, so return false.
	return false;
}

// Operator: -
RegionList RegionList::operator- (RegionList &rightSideList)
{
	RegionList resultList;
	RegionList::RegionListIterator i, j;
	bool match;

	// Loop through the left-side list, for each of its elements, loop through right-side list.
	for (i=this->Begin(); i!=this->End(); i++)
	{
		match = false;

		for (j=rightSideList.Begin(); j!=rightSideList.End(); j++)
		{
			// If we found two matching regions, flag it by setting match to true. One hit is enough to break the loop.
			if (*i == *j)
			{
				match = true;
				break;
			}
		}

		// If this region passed the test above, it should be added to the list.
		if (match == false)
			resultList.AddRegion(*i);
	}

	return resultList;
}

// Operator: +
RegionList RegionList::operator+ (RegionList &rightSideList)
{
	RegionList resultList;
	RegionList::RegionListIterator i, j;

	// Add all the left side regions
	for (i = Begin(); i != End(); i++)
		resultList.AddRegion(*i);

	for (i = rightSideList.Begin(); i != rightSideList.End(); i++)
	{
		for (j = resultList.Begin(); j != resultList.End(); j++)
		{
			if (*j == *i)
				break;
		}
		if (j == resultList.End())
			resultList.AddRegion(*i);
	}

	return resultList;
}
