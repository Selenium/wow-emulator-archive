struct CreatureData
{
	// char Name[64];
	unsigned long SpawnPoint;
	guid_t Template;
	unsigned long Continent;
	_Location Loc;
	_Location SpawnLoc;
	float Facing;
	float SpawnFacing;

	CreatureStats CurrentStats;

	// unsigned long ItemTemplates[10];

	// unsigned int virtualItemDisplay[3];
	// struct CreatureItemInfo virtualItemInfo[3];		// This shit will be moved into templates ;)
	// bool isSaved; everything is saved!
	long LootMoney;
	unsigned long isRegenning; // bool, but it'll take the whole 4 bytes anyway
	guid_t Summoner;
	unsigned long SourceSpell;
	unsigned long SpawnID;
};