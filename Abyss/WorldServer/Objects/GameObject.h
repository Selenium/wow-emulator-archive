// (c) AbyssX Group
#if !defined(GAMEOBJECT_H)
#define GAMEOBJECT_H

//! Represents game entities such as chairs, signposts, etc.
class GameObject : Object
{
	public:
		// Constructor: GameObject.
		/*! Creates a new game object with the sent GUID. */
		GameObject(QuadWord objectGuid, const char *name);

		// Destructor: ~GameObject.
		/*! Destroys a game object and releases all its used resources. */
		~GameObject();

		//! Gets the game object's rotation #0.
		/*! @return Rotation #0 of the game object. */
		Float GetRotation0() { return mRotation0; };

		//! Sets the rotation #0 of this game object.
		/*! @param rotation The new rotation #0 of this game object. */
		void SetRotation0(Float rotation) { mRotation0 = rotation; };

		//! Gets the game object's rotation #1.
		/*! @return Rotation #1 of the game object. */
		Float GetRotation1() { return mRotation1; };

		//! Sets the rotation #1 of this game object.
		/*! @param rotation The new rotation #1 of this game object. */
		void SetRotation1(Float rotation) { mRotation1 = rotation; };

		//! Gets the game object's rotation #2.
		/*! @return Rotation #2 of the game object. */
		Float GetRotation2() { return mRotation2; };

		//! Sets the rotation #2 of this game object.
		/*! @param rotation The new rotation #2 of this game object. */
		void SetRotation2(Float rotation) { mRotation2 = rotation; };

		//! Gets the game object's rotation #3.
		/*! @return Rotation #3 of the game object. */
		Float GetRotation3() { return mRotation3; };

		//! Sets the rotation #3 of this game object.
		/*! @param rotation The new rotation #3 of this game object. */
		void SetRotation3(Float rotation) { mRotation3 = rotation; };

		//! Gets the game object's dynamic flags.
		/*! @return Dynamic flags. */
		DoubleWord GetDynamicFlags() { return mDynamicFlags; };

		//! Sets the dynamic flags of this game object.
		/*! @param flags The new dynamic flags of this game object. */
		void SetDynamicFlags(DoubleWord flags) { mDynamicFlags = flags; };

		//! Gets the faction of this game object.
		/*! @return The faction of this game object. */
		DoubleWord GetFaction(void) { return mFaction; };

		//! Sets the faction of this game object.
		/*! @param faction The new faction of this game object. */
		void SetFaction(DoubleWord faction) { mFaction = faction; };

	protected:
		//! Quaternion rotation coefficients.
		Float mRotation0, mRotation1, mRotation2, mRotation3;

		//! Dynamic flags, for collision.
		DoubleWord mDynamicFlags;

		//! The game object's faction.
		/*! @todo How are factions represented? */
		DoubleWord mFaction;
};

#endif
