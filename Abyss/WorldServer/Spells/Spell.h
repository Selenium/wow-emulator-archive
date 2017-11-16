// (c) AbyssX Group
#if !defined(SPELL_H)
#define SPELL_H

#ifdef SPELLS

class Spell
{
	public:

		// Constructor: Spell.
		/*! Creates a new spell. */
		Spell();

		// Destructor: ~Spell.
		/*! Destroys a spell and releases all its used resources. */
		~Spell();

		void SetSpellSchool(DoubleWord L) { School = L; };

		DoubleWord GetSpellSchool(void) { return School; };

		void SetSpellSchool2(DoubleWord L) { School2 = L; };

		DoubleWord GetSpellSchool2(void) { return School2; };

		void SetSpellSchool3(DoubleWord L) { School3 = L; };

		DoubleWord GetSpellSchool3(void) { return School3; };

		void SetSpellCastTime(DoubleWord L) { CastTime = L; };

		DoubleWord GetSpellCastTime(void) { return CastTime; };

		void SetSpellCooldownTime(DoubleWord L) { CooldownTime = L; };

		DoubleWord GetSpellCooldownTime(void) { return CooldownTime; };

		void SetSpellPlylvl(DoubleWord L) { Plylvl = L; };

		DoubleWord GetSpellPlylvl(void) { return Plylvl; };

		void SetSpellMaxlvl(DoubleWord L) { Maxlvl = L; };

		DoubleWord GetSpellMaxlvl(void) { return Maxlvl; };

		void SetSpellDuration(DoubleWord L) { Duration = L; };

		DoubleWord GetSpellDuration(void) { return Duration; };

		void SetSpellPowerType(DoubleWord L) { PowerType = L; };

		DoubleWord GetSpellPowerType(void) { return PowerType; };

		void SetSpellManaCost(DoubleWord L) { ManaCost = L; };

		DoubleWord GetSpellManaCost(void) { return ManaCost; };

		void SetSpellManaCostperlvl(DoubleWord L) { ManaCostperlvl = L; };

		DoubleWord GetSpellManaCostperlvl(void) { return ManaCostperlvl; };

		void SetSpellRange(DoubleWord L) { Range = L; };

		DoubleWord GetSpellRange(void) { return Range; };

		void SetSpellRandomDam(DoubleWord L) { RandomDam = L; };

		DoubleWord GetSpellRandomDam(void) { return RandomDam; };

		void SetSpellSpeed(DoubleWord L) { Speed = L; };

		DoubleWord GetSpellSpeed(void) { return Speed; };

		void SetSpellDamage(DoubleWord L) { Damage = L; };

		DoubleWord GetSpellDamage(void) { return Damage; };

		void SetSpellRadius(DoubleWord L) { Radius = L; };

		DoubleWord GetSpellRadius(void) { return Radius; };

		void SetSpellRank(DoubleWord L) { Rank = L; };

		DoubleWord GetSpellRank(void) { return Rank; };

		void SetSpellId(DoubleWord L) { Id = L; };

		DoubleWord GetSpellId(void) { return Id; };

	protected:

		DoubleWord School;

		DoubleWord School2;

		DoubleWord School3;

		DoubleWord CastTime;

		DoubleWord CooldownTime;

		DoubleWord Plylvl;

		DoubleWord Maxlvl;

		DoubleWord Duration;

		DoubleWord PowerType;

		DoubleWord ManaCost;

		DoubleWord ManaCostperlvl;

		DoubleWord Range;

		DoubleWord RandomDam;

		DoubleWord Speed;

		DoubleWord Damage;

		DoubleWord Radius;

		DoubleWord Rank;

		DoubleWord Id;
};

#endif

#endif