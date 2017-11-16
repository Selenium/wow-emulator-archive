// (c) AbyssX Group
#if !defined(REGION_H)
#define REGION_H

//! Represents a region in the game world.
/*! Regions are rectangular areas that the game world is divided into. Each region contains a list of
players currently within that region. */
class Region
{
public:
	//! Used to wrap the player list iterator into our own type.
	typedef std::list<Player *>::iterator PlayerIterator;

	//! Used to wrap the object list iterator into our own type.
	typedef std::list<Object *>::iterator ObjectIterator;

	// Constructor: Region.
	/*! Default constructor, remember to set all the values by hand! */
	Region();

	// Constructor: Region.
	/*! Creates a new region with the given extent. Player and Object lists will be initialized
	to being empty. */
	Region(float x, float y, float size);

	// Destructor: ~Region.
	/*! Makes sure to remove all players and Objects from their lists. */
	~Region();

	//! Adds an existing player object to this region.
	/*! @param player Existing Player object. */
	void AddPlayer(Player *player);

	//! Removes a player from this region based on the sent [player].
	/*! @param player Existing Player object.
		@return Returns true if successful, false otherwise. */
	bool RemovePlayer(Player *player);

	//! Removes a player from this region based on the sent [index].
	/*! @param index Index of Player object in player list.
		@return Returns true if successful, false otherwise. */
	void RemovePlayer(PlayerIterator &i);

	//! Returns the number of players currently in the region.
	/*! @return Number of players currently in the region. */
	int GetPlayerCount() { return (int)mPlayerList.size(); };

	//! Returns the beginning iterator of players
	/*! @return begin() of mPlayerList. */
	PlayerIterator PlayerBegin(void) { return mPlayerList.begin(); };

	//! Returns the ending iterator of players
	/*! @return end() of mPlayerList. */
	PlayerIterator PlayerEnd(void) { return mPlayerList.end(); };

	//! Adds an existing Object object to this region.
	/*! @param Object Existing Object object. */
	void AddObject(Object *object);

	//! Removes a Object from this region based on the sent [Object].
	/*! @param Object Existing Object object.
		@return Returns true if successful, false otherwise. */
	bool RemoveObject(Object *object);

	//! Removes a Object from this region based on the sent [index].
	/*! @param index Index of Object object in Object list.
		@return Returns true if successful, false otherwise. */
	void RemoveObject(ObjectIterator &i);

	//! Returns the number of Objects currently in the region.
	/*! @return Number of Objects currently in the region. */
	int GetObjectCount() { return (int)mObjectList.size(); };

	//! Returns the beginning iterator of objects.
	/*! @return begin() of mObjectList. */
	ObjectIterator ObjectBegin(void) { return mObjectList.begin(); };

	//! Returns the ending iterator of objects.
	/*! @return end() of mObjectList. */
	ObjectIterator ObjectEnd(void) { return mObjectList.end(); };

	//! Returns the region's x-coordinate.
	/*! @return The region's x-coodinate, in world coordinates. */
	float GetXCoordinate() { return mXCoordinate; };

	//! Returns the region's y-coordinate.
	/*! @return The region's y-coodinate, in world coordinates. */
	float GetYCoordinate() { return mYCoordinate; };

	//! Returns the region's size.
	/*! @return The region's width and height. */
	float GetSize() { return mSize; };

	//! Sets the region's x-coordinate.
	/*! @param newXCoordinate The region's new x-coodinate, in world coordinates. */
	void SetXCoordinate(float newXCoordinate) { mXCoordinate = newXCoordinate; };

	//! Sets the region's y-coordinate.
	/*! @param newYCoordinate The region's new y-coodinate, in world coordinates. */
	void SetYCoordinate(float newYCoordinate) { mYCoordinate = newYCoordinate; };

	//! Sets the region's size.
	/*! @param newSize The region's width and height. */
	void SetSize(float newSize) { mSize = newSize; };
	
private:

	//! List of players currently within this region.
	std::list<Player *> mPlayerList;

	//! List of Objects currently within this region.
	std::list<Object *> mObjectList;

	//! Top-left x-coordinate for region, in world coordinates.
	float mXCoordinate;

	//! Top-left y-coordinate for region, in world coordinates.
	float mYCoordinate;

	//! Width of the region.
	float mSize;
};

#endif
