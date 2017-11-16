#if !defined(OBJECTMANAGER_H)
#define OBJECTMANAGER_H


//! Handles collection of in-game objects.
/*! Use this class to manage object collections, such as players, monsters,
etc. All objects are stored with their GUID's as search key. Searching on GUID
is very fast (Red-black balanced binary tree), index is a bit slower (linear
search). */
template <class ObjectType> class ObjectManager
{
	public:
		//! Used to wrap the object map iterator into our own type.
		typedef typename map<QuadWord, ObjectType>::iterator ObjectManagerIterator;


		// Constructor: ObjectManager.
		/*! Creates an empty object manager. */
		ObjectManager() {};

		// Destructor: ~ObjectManager.
		/*! Destroys the object manager and releases all added objects. */
		~ObjectManager() {};

		//! Adds a new object to the object map, coupled with its GUID.
		/*! @param object The object to add to the object map.
			@param objectGuid Globally unique identifier coupled with the object to add. */
		void AddObject(QuadWord objectGuid, ObjectType object)
		{
			mObjectMap[objectGuid] = (ObjectType)object;
		};

		//! Removes a managed object based on the sent GUID.
		/*! @param objectGuid Globally unique identifier coupled with the object to remove. */
		void RemoveObject(QuadWord objectGuid)
		{
			mObjectMap.erase(objectGuid);
		};

		//! Removes a managed object based on its index.
		/*! @param index Index representing the slot from where to remove the object. */
		void RemoveObject(ObjectManagerIterator i)
		{
			mObjectMap.erase(i);
		};

		//! Gets a managed object based on the sent GUID.
		/*! @param objectGuid Globally unique identifier coupled with the object to get.
			@return A pointer to the object if a match was found, NULL otherwise. */
		ObjectType GetObject(QuadWord objectGuid)
		{
			return mObjectMap[objectGuid];
		};

		//! Gets a managed object based on the sent index.
		/*! @param index Index representing the slot from where to get the object.
			@return A pointer to the object if a match was found, NULL otherwise. */
		/*ObjectType *GetObject(DoubleWord index)
		{
			map<QuadWord, ObjectType>::iterator i;
			DoubleWord counter;

			for (i = mObjectMap.begin(), counter = 0; i != mObjectMap.end(); i++, counter++)
			{
				if (index == counter)
					return *i;
			}

			// No match was found, so return NULL.
			return NULL;
		};
		*/

		//! Returns the number of managed objects.
		/*! @return Number of managed objects. */
		DoubleWord GetObjectCount() { return mObjectMap.size(); };

		//! Returns an iterator pointing to the first element in the object map.
		/*! @return Iterator pointing to the first element in the object map. */
		ObjectManagerIterator Begin(void) { return mObjectMap.begin(); };
	    
		//! Returns an iterator pointing to the last element in the object map.
		/*! @return Iterator pointing to the last element in the object map. */
		ObjectManagerIterator End(void) { return mObjectMap.end();	};

	private:
		//! Used for mapping objects to GUID's to be able to use fast searching.
		map<QuadWord, ObjectType> mObjectMap;
};

#endif
