struct SpawnPointData
{
	// origin data
	_Location Origin;
	float	 OriginFacing;
	unsigned long OriginContinent;

	// note: Creatures uses creature TEMPLATE id
	unsigned long Creatures[10];			// randomly select a creature
	unsigned long CreatureRates[10];		// rate of spawn for each in the list
	unsigned long CreatureLifetimes[10];    // max lifetime of each spawn in the list
	// whichever is shorter between this and the creature template's max lifetime will be used

	unsigned long Periodicity; // rate of spawn (e.g. "5 minute respawn") in milliseconds

	// current data
	guid_t Creature;
	unsigned long SpawnTime; // time_t
};