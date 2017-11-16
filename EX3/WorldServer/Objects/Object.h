// (c) AbyssX Group
#if !defined(OBJECT_H)
#define OBJECT_H

//! Basic class that all other objects in the game will derive from.
class Object
{
	public:
		// Constructor: Object.
		/*! Creates a new object with the sent 64-bit GUID. */
		Object(QuadWord objectGuid, const char *name);

		// Destructor: ~Object.
		/*! Destroys an object and releases all its used resources. */
		virtual ~Object();

		//! Retrieves the 64-bit GUID of the object.
		/*! @return The 64-bit GUID of the object. */
		QuadWord GetObjectGuid(void) { return mObjectGuid; };

		//! Retrieves the x coordinate of the object.
		/*! @return X coodinate of the object. */
		Float GetXCoordinate(void) { return mX; };
		
		//! Retrieves the y coordinate of the object.
		/*! @return Y coodinate of the object. */
		Float GetYCoordinate(void) { return mY; };

		//! Retrieves the z coordinate of the object.
		/*! @return Z coodinate of the object. */
		Float GetZCoordinate(void) { return mZ; };

		//! Retrieves the facing angle of the object.
		/*! @return The facing angle of the object. */
		Float GetFacing(void) { return mFacing; };

		//! Retrieves the pitc angle of the object.
		/*! @return The pitch angle of the object. */
		Float GetPitch(void) { return mPitch; };

		//! Retrieves the scale of the object.
		/*! @return The scale of the object. */
		Float GetScale(void) { return mScale; };

		//! Gets the name of the object.
		/*! @return The name of the object as a string. */
		string GetName(void) { return mName; };

		//! Gets the name of the object.
		/*! @return The name of the object as a string. */
		string GetGuildName(void) { return mGuildName; };

		//! Gets the type of the object.
		/*! @return The type of the object. */
		DoubleWord GetType(void) { return mType; };

		//! Sets a new x coordinate for the object.
		/*! @param x New x coordinate. */
		void SetXCoordinate(Float x) { mX = x; };

		//! Sets a new y coordinate for the object.
		/*! @param y New y coordinate. */
		void SetYCoordinate(Float y) { mY = y; };

		//! Sets a new z coordinate for the object.
		/*! @param z New z coordinate. */
		void SetZCoordinate(Float z) { mZ = z; };

		//! Sets a new facing angle for the object.
		/*! @param angle Facing angle between blaha and blaha. */
		void SetFacing(Float angle) { mFacing = angle; };

		//! Sets a new pitch angle for the object.
		/*! @param angle pitch angle between blaha and blaha. */
		void SetPitch(Float angle) { mPitch = angle; };

		//! Sets a new scale for the object.
		/*! @param scale New scale between blaha and blaha for object. */
		void SetScale(Float scale) { mScale = scale; };

		//! Sets the name of the object.
		/*! @param name The name of the object. */
		void SetName(string name) { mName = name; };

		//! Sets the name of the object.
		/*! @param name The name of the object. */
		void SetGuildName(string name) { mGuildName = name; };

		//! Sets the type of the object.
		/*! @param type The type of the object. */
		void SetType(DoubleWord type) { mType = type; };

		
		// Following not using, or not part of the object type, left over from
		// converting to Object from GameObject?

		//! Gets the object's entry.
		/*! @return The object's entry. */
		DoubleWord GetEntry(void) { return mEntry; };

		//! Gets the object's padding.
		/*! @return The object's padding. */
		//DoubleWord GetPadding(void) { return mPadding; };

		//! Gets the model that this object uses for display.
		/*! Can be used for shape-shifting/morphing.
			@return The id of the model to display for this object. */
		virtual Word GetObjectModel() { return mObjectModel; };

		//! Gets the state of this object.
		/*! @return The state of this object. */
		//DoubleWord GetState() { return mState; };

		//! Gets the extra flags of this object.
		/*! @return The flags of this object. */
		//DoubleWord GetFlags() { return mFlags; };

		//! Gets the timestamp of this object.
		/*! @return The timestamp of this object. */
		//DoubleWord GetTimestamp() { return mTimestamp; };

		//! Retrieves the current region that the object is within.
		/*! @return The region this object is within. */
		Region *GetCurrentRegion(void) { return mCurrentRegion; };

		//! Retreives the current region list that is associated with the object.
		/*! @return The current region list. */
		RegionList &GetCurrentRegionList(void) { return *mCurrentRegionList; };

		//! Sets the object's entry.
		/*! @param entry The object's entry. */
		void SetEntry(DoubleWord entry) { mEntry = entry; };

		//! Sets the object's padding.
		/*! @param padding The object's padding. */
		//void SetPadding(DoubleWord padding) { mPadding = padding; };

		//! Sets the model that this object uses for display.
		/*! @param modelId Id of model that this object should use for display. */
		void SetObjectModel(Word modelId) { mObjectModel = modelId; };

		//! Sets the state for this object.
		/*! @param state State of this object. */
		//void SetState(DoubleWord state) { mState = state; };

		//! Sets the extra flags for this object.
		/*! @param flags Flags of this object. */
		//void SetFlags(DoubleWord flags) { mFlags = flags; };

		//! Sets the timestamp for this object.
		/*! @param timestamp Timestamp of this object. */
		//void SetTimestamp(DoubleWord timestamp) { mTimestamp = timestamp; };

		//! Sets the current region that the object is within.
		/*! @param currentRegion The region that this object is within. */
		void SetCurrentRegion(Region *currentRegion) { mCurrentRegion = currentRegion; };

		//! Sets the current region list associated with the object.
		/*! @param currentRegionList The region list associated with this object. */
		void SetCurrentRegionList(const RegionList &currentRegionList);

	protected:
		//! 64-bit object GUID.
		QuadWord mObjectGuid;

		//! The object's x coordinate.
		Float mX;

		//! The object's y coordinate.
		Float mY;

		//! The object's z coordinate.
		Float mZ;

		//! The direction the object is facing.
		Float mFacing;

		//! The direction the object is pitched.
		Float mPitch;

		//! The scale of the object.
		Float mScale;

		//! Name of the game object.
		string mName;

		//! GuildName of game Object.
		string mGuildName;

		//! The type of object this is.
		/*! @todo Need enumeration of available types? */
		DoubleWord mType;

		// Following not using, or not part of the object type, left over from
		// converting to Object from GameObject?

		//! Object entry. Dunno what this is?
		DoubleWord mEntry;

		//! Object padding.
		//DoubleWord mPadding;

		//! Model to display this object as, used for shape-shifting/mophing.
		Word mObjectModel;

		//! The state of the object.
		//DoubleWord mState;

		//! Extra flags for this object.
		/*! @todo What does these flags contain? */
		//DoubleWord mFlags;

		//! Timestamp of the object.
		/*! @todo Dunno what this does? Add some comments about it when we do. */
		//DoubleWord mTimestamp;

		//! The region this object is currently within.
		Region *mCurrentRegion;

		//! The current region list associated with this object.
		RegionList *mCurrentRegionList;
};

#endif
