struct AuraStatMinus
{
	long Str;
	long Ag;
	long Sta;
	long Int;
	long Spi;
	long Armor;
	long HolyRes;
	long FireRes;
	long NatureRes;
	long FrostRes;
	long ShadowRes;
	long ArcaneRes;
};
struct AuraStatBonus
{
	long Str;
	long Ag;
	long Sta;
	long Int;
	long Spi;
	long Armor;
	long HolyRes;
	long FireRes;
	long NatureRes;
	long FrostRes;
	long ShadowRes;
	long ArcaneRes;
};
// Exploration System
struct ExplorationArea
{
	unsigned long areaID;
	unsigned long areaFlag;
	float x1;
	float x2;
	float y1;
	float y2;
};

struct _FactionInfo
{
	// unsigned long ID; // Completely made up.
	// unsigned long ReputationListID; // Index determines this already.
	unsigned char Flags; // shorten to char
	unsigned long Standing;
};

struct _TutorialFlags
{
	unsigned char Unknown[0x20];
};

struct _SkillInfo
{
	unsigned long SkillID;
	unsigned short CurrentLevel;
	unsigned short MaxLevel;
	unsigned short posStatCurrentLevel; //????
	unsigned short posStatMaxLevel;
};

struct _QuestInfo
{
	guid_t QuestID;
	char State;
	char Rewarded;
};

struct _QuestLogSlot
{
	guid_t QuestID;
	unsigned long State;
	short QuestMobCount[4];
	short QuestItemCount[4];
	long QuestMobKills;
	char QuestAreasExplored[4];
	unsigned long EndTime;
	long Explored;
};

struct PlayerStats
{
	long HitPoints;
	long Mana;
	long Focus;
	long Energy;
	long Rage;

	long Strength;
	long Agility;
	long Stamina;
	long Intellect;
	long Spirit;

	long Armor;
	long Block;
	long ResistArcane;
	long ResistFire;
	long ResistNature;
	long ResistFrost;
	long ResistShadow;
	long ResistHoly;
};

struct ActionButton
{
	unsigned short action;
	unsigned char type;
	unsigned char misc;
};

struct BuybackItem
{
	guid_t guid;
	unsigned long SellPrice;
};

struct _AuraSlot
{
	unsigned long auraid;
	unsigned long spellid;
	unsigned long appliation;
	unsigned long flags;
	unsigned long state;
};

// contains ONLY what is saved to disk. NO POINTERS. info that is not to be
// saved should be a member of the class itself... (ex: current target)
struct PlayerData
{
	char Name[16];
	_Location Loc;
	unsigned long Zone;
	unsigned long Continent;
	_Location BindLoc;
	unsigned long BindZone;
	unsigned long BindContinent;
	float Facing;
	float walkspeed;
	float runspeed;
	float swimspeed;
	unsigned char Race;
	unsigned char Class;
	unsigned char Female;
	unsigned char Appearance[5];
	unsigned long Level;
	// Items moved to just Items
	guid_t ItemGuids[LAST_SLOT_PLAYER];
	guid_t BagItemGuids[120];
	// Avoid using the above constructs: they will ONLY be used to save and load!
	unsigned long Model;
	unsigned long BaseModel;
	float Size;
	
	unsigned long Talents[20];
	unsigned long TalentResetTimes;
	PlayerStats NormalStats;
	PlayerStats CurrentStats;

	_TutorialFlags TutorialFlags;

	unsigned long Copper;

	float DamageMin;
	float DamageMax;
	unsigned long AttackSpeed;
	unsigned long MeleeWeaponSkillID;

	float RangedDamageMin;
	float RangedDamageMax;
	unsigned long RangedAttackSpeed;
	unsigned long RangedWeaponSkillID;

	float CritPct;

	long Exp;
	long NextLevelExp;
	unsigned char ManaType; // corresponds to the bar type mana,rage,energy,focus
	unsigned char PvP;
	unsigned char RecentPvP;
	unsigned char ResurrectionSickness;// <-- should be a duration or something if its being saved
	unsigned long StatusFlags;
	float RestAmount;
	unsigned char StandState;
	unsigned char MorphState;
	unsigned char WeaponMode;
	unsigned char RestState;
	unsigned char DrunkState;
	unsigned char PvPRank;
	unsigned char bDead;
	unsigned char bSummoned;
	char StatusReason[128];
	unsigned short LFG;
	short UsedTalentPoints;

	unsigned long MountModel;

	_Location CorpseLoc;

	unsigned long SkillPoints;
	guid_t GuildID;
	unsigned long GuildRank;
	unsigned long GuildTimestamp;
	char GuildPublicNote[256];
	char GuildOfficerNote[256];

	guid_t PartyID;
	unsigned long PartyRank;

	_FactionInfo factionlist[FACTION_ARRAY_COUNT];

	// keeping extra for future expansion
	_SkillInfo Skills[140];
	unsigned long QuestCounter;
	_QuestInfo Quests[1000]; // 1000 quests seems about right. If it is insufficient
	// we can use a different loading system.
	_QuestLogSlot QuestLogSlots[20];
	unsigned long KnownTaxiNodes[8];
	unsigned long Spells[200];
	guid_t Friends[50];
	guid_t ExtFriends[200]; //people who have me on their friends
	guid_t Ignore[50];
	guid_t ExtIgnore[200]; //people who have ignored me
	ActionButton ActionButtons[120];
	unsigned char PlayedIntro;
	unsigned long LastLogon;
	unsigned char AccountData0[300];
	unsigned char AccountData1[1200];
	unsigned char AccountData2[1300];
	unsigned char AccountData3[1300];
	unsigned char AccountData4[1350];
	unsigned short AccountDataLen[5];
	unsigned long ExploredZones[64];
};