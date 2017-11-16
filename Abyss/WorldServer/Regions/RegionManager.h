// (c) AbyssX Group
#if !defined(REGIONMANAGER_H)
#define REGIONMANAGER_H


//! Manages world regions.
/*! Used to sort game objects, like players and Objects, into a world grid of rectangles. The purpose is
to reduce search time during object- and area specific operations, as well as to reduce network traffic.
Updates about game objects are only sent to the ones in the nearby, instead of everyone. The region
system takes for granted that all sent coordinates are valid world coordinates. */
class RegionManager
{
public:
	//! Types of range to scan for regions in.
	/*! Use 1X1 to only get the current region, 3X3 to get the current region plus the eight	surrounding
	regions. */
	enum RangeType
	{
		RANGETYPE_1X1 = 1,
		RANGETYPE_3X3 = 2
	};

	// Constructor: RegionManager.
	/*! Creates a new region manager with world extent setup, as well as the desired size of created regions.
	@param worldMinX Minimum x-coordinate of the entire map coordinate system.
	@param worldMinY Minimum y-coordinate of the entire map coordinate system.
	@param worldMaxX Maximum x-coordinate of the entire map coordinate system.
	@param worldMaxY Maximum y-coordinate of the entire map coordinate system.
	@param regionSize Width and height of created regions. */
	RegionManager(float worldMinX, float worldMinY, float worldMaxX, float worldMaxY, float regionSize);

	// Destructor: ~RegionManager.
	/*! Destroys all regions associated with the manager object. */
	~RegionManager();

	//! Fetches the region that matches the sent region map [offset].
	/*! @param offset Offset of region to get.
		@return A pointer to the region that the sent object is within. */
	Region *GetRegion(int offset);

	//! Updates or sets a new region for this player based on its coordinates.
	/*! @param player Existing Player to update region information about.
		@return If the region changed, the return value is a pointer to the region the player is within.
		If the player stayed in the same region since the last update, 0 is returned. */
	Region *UpdatePlayer(Player *player);

	//! Removes a Player from this region based on its coordinates.
	/*! @param player Existing Player object.
		@return Returns true if successful, false otherwise. */
	bool RemovePlayer(Player *player);

	//! Updates or sets a new region for this Object based on its coordinates.
	/*! @param object Existing Object to update region information about.
		@return If the region changed, the return value is a pointer to the region the object is within.
		If the object stayed in the same region since the last update, 0 is returned. */
	Region *UpdateObject(Object *object, bool);

	//! Removes a Object from this region based on its coordinates.
	/*! @param object Existing Object object.
		@return Returns true if successful, false otherwise. */
	bool RemoveObject(Object *object);

	//! Fetches a list of regions within range of an object.
	/*! @param object Existing world object that is the center of the region search.
		@param type Type of search to perform. Valid types are listed in the RangeType
		enumeration
		@return A RegionList object containing all selected regions. Returns NULL if something went wrong. */
	RegionList GetRegionsWithinRange(Object *object, RangeType type);

	//! Returns the set minimum x-coordinate of the game world.
	/*! @return The set minimum x-coordinate of the game world. */
	float GetWorldMinX() { return mWorldMinX; };

	//! Returns the set minimum y-coordinate of the game world.
	/*! @return The set minimum y-coordinate of the game world. */
	float GetWorldMinY() { return mWorldMinY; };

	//! Returns the set maximum x-coordinate of the game world.
	/*! @return The set maximum x-coordinate of the game world. */
	float GetWorldMaxX() { return mWorldMaxX; };

	//! Returns the set maximum y-coordinate of the game world.
	/*! @return The set maximum y-coordinate of the game world. */
	float GetWorldMaxY() { return mWorldMaxY; };

	//! Returns the width and height of all created regions.
	/*! @return The width and height of all created regions. */
	float GetRegionSize() { return mRegionSize; };

	//! Returns the number of regions in the x-axis.
	/*! @return The number of regions in the x-axis. */
	int GetRegionXCount() { return mRegionXCount; };

	//! Returns the number of regions in the y-axis.
	/*! @return The number of regions in the y-axis. */
	int GetRegionYCount() { return mRegionYCount; };

	//! Bad Region Return Value
	static Region *BadRegion;

private:
	//! Calculates the offset in the x/y region axes for the specified coordinates.
	/*! @param object Any existing game Object of which to calculate region offset for.
		@return Returns the offset into the regions array based on the object's world position. If the
		object is out of bounds, the invalid offset -1 is returned. */
	int CalculateRegionOffset(Object *object);

	//! Array holding allocated regions.
	Region *mRegions;

	//! Minimum x-coordinate for the game world.
	float mWorldMinX;

	//! Minimum y-coordinate for the game world.
	float mWorldMinY;

	//! Maximum x-coordinate for the game world.
	float mWorldMaxX;

	//! Maximum y-coordinate for the game world.
	float mWorldMaxY;

	//! Width and height of regions within the game world.
	float mRegionSize;

	//! Number of regions created in the x-axis.
	int mRegionXCount;

	//! Number of regions created in the y-axis.
	int mRegionYCount;
};

#endif
