// (c) AbyssX Group
#if !defined(REGIONLIST_H)
#define REGIONLIST_H

//! Represents one or more regions in the world.
/*! This class can be used to process many regions in one operation by lumping them together in a list. */
class RegionList
{
public:

	//! Used to wrap the region list iterator into our own type.
	typedef std::list<Region *>::iterator RegionListIterator;

	// Constructor: RegionList.
	/*! Creates a new, empty region list. */
	RegionList();

	// Destructor: ~RegionList.
	/*! Removes all regions from the region list and deallocates used resources. */
	~RegionList();

	// Copy-constructor: RegionList.
	RegionList(RegionList &rhs);

	// Assignment operator.
	RegionList &operator=(const RegionList &rhs);

	//! Adds an existing region to the region list.
	/*! @param region The region to add to the region list. */
	void AddRegion(Region *region);

	//! Removes a region from the region list.
	/*! @param region The region to remove from the list.
		@return True if successful, false otherwise. */
	bool RemoveRegion(Region *region);

	//! Returns an iterator pointing to the first element in the region list.
	/*! @return Iterator pointing to the first element in the region list. */
	RegionListIterator Begin(void)	{ return mRegionList.begin(); };

	//! Returns an iterator pointing to the last element in the region list.
	/*! @return Iterator pointing to the last element in the region list. */
	RegionListIterator End(void) { return mRegionList.end(); };

	//! Returns the number of regions in the list.
	/*! @return The number of regions in the list. */
	int GetRegionCount() { return (int)mRegionList.size(); };

	//! Returns the resulting regions as a new RegionList.
	/*! @param rightSideList Right side operand of the subtract operation. */
	RegionList operator- (RegionList &rightSideList);

	//! Returns the resulting regions as a new RegionList.
	/*! @param rightSideList Right side operand of the addition operation. */
	RegionList operator+ (RegionList &rightSideList);

private:
	//! List of regions.
	std::list<Region *> mRegionList;
};

#endif
