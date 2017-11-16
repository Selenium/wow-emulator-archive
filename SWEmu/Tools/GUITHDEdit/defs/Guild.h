struct RankData
{
	char Name[64];
	unsigned long Privileges;
};

struct GuildData
{
	// cache query stuff
	char Name[0x60];
	int EmblemStyle;
	int EmblemColor;
	int BorderStyle;
	int BorderColor;
	int BackgroundColor;
	// end cache query stuff

	// ginfo stuff
	int CreatedYear;
	int CreatedMonth;
	int CreatedDay;
	int numCharacters;
	int numAccounts;

	char Motd[0x60];

	guid_t Leader;
	RankData Ranks[10];
	unsigned long nRanks;
	guid_t Members[MAX_GUILDMEMBERS]; // save the guid, the rest can be stored on the character
};