struct PartyData
{
	char Name[0x60]; // for AllPartys
	// cache query stuff
	guid_t Members[MAX_PARTYMEMBERS]; // save the guid, the rest can be stored on the character
	guid_t Invites[MAX_PARTYMEMBERS-1]; // save the guid, the rest can be stored on the character
	unsigned long LootMethod;
};