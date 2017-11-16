struct CreatureItemInfo
{
	unsigned char m_classID;
	unsigned char m_subclassID;
	unsigned char m_material;
	unsigned char m_inventoryType;
	unsigned char m_sheatheType;
	unsigned char m_padding0;
	unsigned char m_padding1;
	unsigned char m_padding2;
};
struct CreatureTemplateData
{
	char Name[64];
	char Guild[64];
	CreatureStats NormalStats;
	unsigned long Armor;
	unsigned short DamageMin;
	unsigned short DamageMax;
	float Size;
	float Speed;

	unsigned long Model;
	unsigned long Level;
	guid_t LootTable;
	unsigned long TextID;
	unsigned long Elite;
	unsigned long Flags;
	unsigned long Type;
	unsigned long Faction;
	unsigned long Family;
	unsigned long NPCFlags;
	char QuestGiverText[128];
	unsigned long TemplateID;
	unsigned long virtualItemDisplay[3];
	CreatureItemInfo virtualItemInfo[3];
	unsigned long Mount;
	float BoundingRadius;
	float CombatReach;

	// -- Stuff not to copy to creatures

	// used for preventing certain creatures from spawning too often. for example,
	// dragons that spawn every 100 hours would have a MinRespawnTime of 60*60*100
	// (seconds per minute)*(minutes per hour)*(number of hours)
	unsigned long MinRespawnTime; // number of seconds between allowed spawns of this creature
	unsigned long MaxLifetime;	  // number of seconds creature is allowed to live for (0=infinite)
	unsigned long LastSpawn; // when our emu stops working in 30 years, call me.
};