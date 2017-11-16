// (c) AbyssX Group
#if !defined(MOB_H)
#define MOB_H

struct Coordinates
{
	Float X;
	Float Y;
	Float Z;
};

class Mob : public Unit
{
	public:
		// Constructor: Mob.
		/*! Creates a new Monster with the sent parameters. */
		Mob(QuadWord objectGuid, const char *name);

		// Destructor: ~Mob.
		~Mob() {};

		//! Gets the map that the mob is currently in.
		/*! @return An id number representing the map that the mob is in. */
		DoubleWord GetCurrentMap(void) { return mMapId; };

		//! Sets the map that the mob is currently in.
		/*! @param mapId An id number representing the map that the mob is in. */
		void SetCurrentMap(DoubleWord mapId) { mMapId = mapId; };

		void SetMobType(DoubleWord L) { mMobType = L; };

		DoubleWord GetMobType(void) { return mMobType; };

		void SetMobExperience(DoubleWord L) { mExperience = L; };

		DoubleWord GetMobExperience(void) { return mExperience; };

		void SetNPCFlags(DoubleWord L) { mNPCFLAGS = L; };

		DoubleWord GetNPCFlags(void) { return mNPCFLAGS; };

		DoubleWord FollowPlayer(Player *ply);

		void Death(Player *ply);

		void RespawnMOB();

		Coordinates mCoordz;
		
		void GetBack();

	protected:

		//! The map that this player is in.
		/*! @todo Which field in the A9 takes care of current player map? */
		DoubleWord mMapId;

		DoubleWord mMobType;

		DoubleWord mExperience;

		DoubleWord mNPCFLAGS;	
};

#endif
