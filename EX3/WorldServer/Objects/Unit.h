// (c) AbyssX Group
#if !defined(UNIT_H)
#define UNIT_H

//! Represents a game unit.
/*! A unit is the next step in the chain up from GameObject. Units represent monster and NPC's. Players are
refined units. */

struct Damages
{
	DoubleWord BPhysicalMAX;
	DoubleWord BPhysicalMIN;
	DoubleWord PPhysicalMIN;
	DoubleWord PPhysicalMAX;
	DoubleWord NPhysicalMIN;
	DoubleWord NPhysicalMAX;
};

class Unit : public Object
{
	public:
		// Constructor: Unit.
		/*! Creates a new unit with the sent parameters. */
		Unit(QuadWord objectGuid, const char *name);

		// Destructor: ~Unit.
		/*! Destroys a unit and releases all allocated resources. */
		~Unit() {};

		//! Gets the unit's current health.
		/*! @return Unit's current health. */
		DoubleWord GetHealth(void) { return mHealth; };

		//! Sets the unit's current health.
		/*! @param health The unit's new health. */
		void SetHealth(DoubleWord health) { mHealth = health; };

		//! Gets the unit's maximum health.
		/*! @return Unit's maximum health. */
		DoubleWord GetMaximumHealth(void) { return mMaximumHealth; };

		//! Sets the unit's maximum health.
		/*! @param maximumHealth The unit's new maximum health. */
		void SetMaximumHealth(DoubleWord maximumHealth) { mMaximumHealth = maximumHealth; };

		//! Gets the unit's current mana.
		/*! @return Unit's current mana. */
		DoubleWord GetMana(void) { return mMana; };

		//! Sets the unit's mana.
		/*! @param mana The unit's new mana. */
		void SetMana(DoubleWord mana) { mMana = mana; };

		//! Gets the unit's maximum mana.
		/*! @return Unit's maximum mana. */
		DoubleWord GetMaximumMana(void) { return mMaximumMana; };

		//! Sets the unit's maximum mana.
		/*! @param maximumMana The unit's new maximum mana. */
		void SetMaximumMana(DoubleWord maximumMana) { mMaximumMana = maximumMana; };

		//! Gets the unit's current level of experience.
		/*! @return Unit's current level. */
		Byte GetLevel(void) { return mLevel; };

		//! Sets the unit's level of experience.
		/*! @param level The unit's new level. */
		void SetLevel(Byte level) { mLevel = level; };

		DoubleWord GetMoney(void) { return mMoney; };
		void SetMoney(DoubleWord m) { mMoney = m; };

		//! Gets the unit's race.
		/*! @return Unit's race. */
		Byte GetRace(void) { return mRace; };

		//! Sets the unit's race.
		/*! @param Race ID */
		void SetRace(Byte race) { mRace = race; };

		//! Gets the unit's character class.
		/*! @return Unit's characted class. */
		Byte GetClass(void) { return mClass; };

		//! Sets the unit's class.
		/*! @param Class ID */
		void SetClass(Byte clss) { mClass = clss; };

		//! Gets the unit's character class.
		/*! @return Unit's characted class. */
		bool GetDeadState(void) { return mDeadState; };

		//! Sets the unit's class.
		/*! @param Class ID */
		void SetDeadState(bool state) { mDeadState = state; };

		//! Gets the unit's character class.
		/*! @return Unit's characted class. */
		Byte GetStandState(void) { return mStandState; };

		//! Sets the unit's class.
		/*! @param Class ID */
		void SetStandState(Byte state) { mStandState = state; };

		//! Gets the unit's gender.
		/*! @return Unit's gender, 0x00 for female, 0x01 for male (?). */
		Byte GetGender(void) { return mGender; };

		//! Sets the unit's gender.
		/*! @param Gender Id. */
		void SetGender(Byte genderId) { mGender = genderId; };

		//! Get Unit Flags.
		/*! @return Currently Unit Flags. */
		DoubleWord GetUnitFlags(void) { return mUnitFlags; };

		//! Sets the Current Unit Flags.
		/*! @param Flags the new Unit Flags. */
		void SetUnitFlags(DoubleWord Flags) { mUnitFlags = Flags; };

		//! Get Dynamic Flags.
		/*! @return Currently Dynamic Flags. */
		DoubleWord GetDynamicFlags(void) { return mDynamicFlags; };

		//! Sets the Current Dynamic Flags.
		/*! @param Flags the new Dynamic Flags. */
		void SetDynamicFlags(DoubleWord Flags) { mDynamicFlags = Flags; };

		//! Get The Current Mount Model.
		/*! @return The Mount-specific Model. */
		DoubleWord GetMountModel(void) { return mMountModel; };

		//! Sets the Current Mount Model.
		/*! @param newModel The new Mount Model. */
		void SetMountModel(DoubleWord newModel) { mMountModel = newModel; };

		//! Set a move flags
		void SetMoveFlag(DoubleWord flag) { mMoveFlags |= flag; };

		//! Unset a move flag
		void ClearMoveFlag(DoubleWord flag) { mMoveFlags &= ~flag; };

		//! Get the move flags
		DoubleWord GetMoveFlags(void) { return mMoveFlags; };

		// Following not using

		//! Gets the unit's current rage level.
		/*! @return Unit's current rage level. */
		//DoubleWord GetRageLevel(void) { return mRage; };

		//! Sets the unit's rage level.
		/*! @param rageLevel The unit's new rage level. */
		//void SetRageLevel(DoubleWord rageLevel) { mRage = rageLevel; };

		//! Gets the unit's maximum rage.
		/*! @return Unit's maximum rage. */
		//DoubleWord GetMaximumRage(void) { return mMaximumRage; };

		//! Sets the unit's maximum rage.
		/*! @param maximumRage The unit's new maximum rage. */
		//void SetMaximumRage(DoubleWord maximumRage) { mMaximumRage = maximumRage; };

		//! Gets the flags for this unit.
		/*! @return Unit flags. */
		//DoubleWord GetFlags(void) { return mFlags; };

		//! Sets the flags of this unit.
		/*! @param flags The unit's new flags. */
		//void SetFlags(DoubleWord flags) { mFlags = flags; };

		//! Gets the model that this unit's mounted creature uses for display.
		/*!	@return The id of the model to display for this unit's mounted creature. */
		//DoubleWord GetMountModel() { return mMountModel; };

		//! Sets the model that this unit's mounted creature uses for display.
		/*! @param modelId Id of model that this unit's mounted creature should use for display. */
		//void SetMountModel(DoubleWord modelId) { mMountModel = modelId; };

		//! Gets the emote state of this unit.
		/*!	@return The emote state of this unit. */
		//DoubleWord GetEmoteState() { return mEmoteState; };

		//! Sets the emote state of this unit.
		/*! @param emoteState New emote state to set for this unit. */
		//void SetEmoteState(DoubleWord emoteState) { mEmoteState = emoteState; };

		//! Shows wether the unit uses mana or rage.
		/*! @return 0x00 if the unit uses mana, 0x01 if the unit uses rage. */
		//Byte GetManaRage(void) { return mManaRageSwitch; };

		//! Gets the faction that the unit belongs to.
		DoubleWord GetFaction(void) { return mFaction; };

		//! Sets the faction that the unit belongs to.
		void SetFaction(DoubleWord fact) { mFaction = fact; };

		//! Player Damages
		Damages mDamages;

		//! UNIT Attack States
		void SetAttackState(bool s) { mAttacking = s; };
		bool GetAttackState(void) { return mAttacking; };

	protected:
		//! The unit's current health.
		DoubleWord mHealth;

		//! The unit's maximum health.
		DoubleWord mMaximumHealth;

		//! Current mana level.
		DoubleWord mMana;

		//! The unit's maximum mana level.
		DoubleWord mMaximumMana;

		//! The unit's current level of experience.
		Byte mLevel;

		//! The unit's race.
		/*! @todo Get defines for races and make this an enumeration instead. */
		Byte mRace;

		//! The unit's character class.
		/*! @todo Get defines for character classes and make this an enumeration instead. */
		Byte mClass;

		//! The unit's gender.
		/*! 0x00 (female) or 0x01 (male). */
		Byte mGender;

		//! Unit's move flags
		/*! see #defines below */
		DoubleWord mMoveFlags;

		//! Unit's dead state
		/*! thats for make sure the Unit's like mob's are dead. */
		bool mDeadState;
		
		//! Attacking Someone OR not...
		bool mAttacking;

		//! Unit's Stand State
		Byte mStandState;

		//! Unit Damage;
		DoubleWord mMinDamage;
		DoubleWord mMaxDamage;

		//! Player Money
		DoubleWord mMoney;

		// Following not using

		//! Current rage level.
		//DoubleWord mRage;

		//! The unit's maximum rage level.
		//DoubleWord mMaximumRage;

		//! Model to display for mounted creatures.
		DoubleWord mMountModel;
		DoubleWord mUnitFlags;
		DoubleWord mDynamicFlags;

		//! Mana/rage switch.
		/*! Decides wether the unit uses mana or rage. 0x00 for mana, 0x01 for rage. */
		//Byte mManaRageSwitch;

		//! The faction that the unit belongs to. Alliance or horde.
		DoubleWord mFaction;

		enum Races
		{
			RACE_HUMAN = 0x01, RACE_ORC = 0x02, RACE_DWARF = 0x03,
			RACE_NIGHT_ELF = 0x04, RACE_UNDEAD = 0x05, RACE_TAUREN = 0x06,
			RACE_GNOME = 0x07, RACE_TROLL = 0x08
		};
};

// Verified
#define MOVEFLAG_FORWARD							0x00000001
#define MOVEFLAG_BACKWARD							0x00000002
#define MOVEFLAG_STRAFE_LEFT					0x00000004
#define MOVEFLAG_STRAFE_RIGHT					0x00000008
#define MOVEFLAG_LEFT									0x00000010
#define MOVEFLAG_RIGHT								0x00000020
#define MOVEFLAG_WALK									0x00000100
#define MOVEFLAG_SWIMMING							0x00200000

// Unverified/unknown
#define MOVEFLAG_PITCH_UP							0x00000040
#define MOVEFLAG_PITCH_DOWN						0x00000080
#define MOVEFLAG_TIME_VALID						0x00000200
#define MOVEFLAG_IMMOBILIZED					0x00000400
#define MOVEFLAG_DONTCOLLIDE					0x00000800
#define MOVEFLAG_REDIRECTED						0x00001000
#define MOVEFLAG_ROOTED								0x00002000
#define MOVEFLAG_FALLING							0x00004000
#define MOVEFLAG_FALLEN_FAR						0x00008000
#define MOVEFLAG_PENDING_STOP					0x00010000
#define MOVEFLAG_PENDING_UNSTRAFE			0x00020000
#define MOVEFLAG_PENDING_FALL					0x00040000
#define MOVEFLAG_PENDING_FORWARD			0x00080000
#define MOVEFLAG_PENDING_BACKWARD			0x00100000
#define MOVEFLAG_PENDING_STR_LEFT			0x00200000
#define MOVEFLAG_PENDING_STR_RGHT			0x00400000
#define MOVEFLAG_PEND_MOVE_MASK				0x00180000
#define MOVEFLAG_PEND_STRAFE_MASK			0x00600000
#define MOVEFLAG_PENDING_MASK					0x007F0000
#define MOVEFLAG_MOVED								0x00800000
#define MOVEFLAG_SLIDING							0x01000000
#define MOVEFLAG_SPLINE_MOVER					0x04000000
#define MOVEFLAG_SPEED_DIRTY					0x08000000
#define MOVEFLAG_HALTED								0x10000000
#define MOVEFLAG_NUDGE								0x20000000
#define MOVEFLAG_FALL_MASK						0x0100C000
#define MOVEFLAG_LOCAL								0x80400000
#define MOVEFLAG_MOVE_MASK						0x00030000
#define MOVEFLAG_TURN_MASK						0x00300000
#define MOVEFLAG_PITCH_MASK						0x00C00000
#define MOVEFLAG_STRAFE_MASK					0x000C0000
#define MOVEFLAG_MOTION_MASK					0x00FF0000
#define MOVEFLAG_STOPPED_MASK					0x0003100F

#endif
