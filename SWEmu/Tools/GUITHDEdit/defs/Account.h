struct AccountData
{
	char Name[32];
	char Password[32];
	unsigned char SessionKey[40];
	guid_t Characters[10];
	long UserLevel;
	long ip;
	char LockedToIP;
	char AccountTeam; // 0=none 1=alliance 2=horde

	unsigned long LastLogin; // time_t
	unsigned long SuspendedUntil; // time_t
};
