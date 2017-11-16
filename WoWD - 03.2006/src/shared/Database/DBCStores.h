#ifndef __SPELLSTORE_H
#define __SPELLSTORE_H

#include "Common.h"
#include "DataStore.h"
#include "Timer.h"


// Struct for the entry in Spell.dbc
struct bidentry
{
	uint32 AuctionID;
	uint32 amt;
};
struct AuctionEntry
{
	uint32 auctioneer;
	uint32 item;
	uint32 owner;
	uint32 bid;
	uint32 buyout;
	time_t time;
	uint32 bidder;
	uint32 Id;
};
struct TalentEntry
{
	uint32 TalentID;
	uint32 TalentTree;
	uint32 unk1;
	uint32 unk2;
	uint32 RankID[4];
	uint32 unk[11];
};
struct emoteentry
{
	uint32 Id;
	uint32 name;
	uint32 textid;
	uint32 textid2;
	uint32 textid3;
	uint32 textid4;
	uint32 unk1;
	uint32 textid5;
	uint32 unk2;
	uint32 textid6;
	uint32 unk3;
	uint32 unk4;
	uint32 unk5;
	uint32 unk6;
	uint32 unk7;
	uint32 unk8;
	uint32 unk9;
	uint32 unk10;
	uint32 unk11;
};

struct skilllinespell
{
	uint32 Id;
	uint32 skilline;
	uint32 spell;
	uint32 unk1;
	uint32 unk2;
	uint32 unk3;
	uint32 unk4;
	uint32 unk5;
	uint32 minrank;
	uint32 next;
	uint32 grey;
	uint32 green;
	uint32 unk10;
	uint32 unk11;
	uint32 unk12;
};
struct EnchantEntry
{
	uint32 Id;
	uint32 type;
	uint32 unk1;
	uint32 unk2;
	uint32 min;
	uint32 unk3;
	uint32 unk4;
	uint32 max;
	uint32 unk5;
	uint32 unk6;
	uint32 spell1;
	uint32 spell2;
	uint32 spell3;
    uint32 Name;
    uint32 NameAlt1;
    uint32 NameAlt2;
    uint32 NameAlt3;
    uint32 NameAlt4;
    uint32 NameAlt5;
    uint32 NameAlt6;
    uint32 NameAlt7;
    uint32 NameFlags;
	uint32 visual;
	uint32 unk8;

};
struct skilllineentry
{
	uint32 id;
	uint32 type;
	uint32 unk1;
    uint32 Name;
    uint32 NameAlt1;
    uint32 NameAlt2;
    uint32 NameAlt3;
    uint32 NameAlt4;
    uint32 NameAlt5;
    uint32 NameAlt6;
    uint32 NameAlt7;
    uint32 NameFlags;
    uint32 Description;
    uint32 DescriptionAlt1;
    uint32 DescriptionAlt2;
    uint32 DescriptionAlt3;
    uint32 DescriptionAlt4;
    uint32 DescriptionAlt5;
    uint32 DescriptionAlt6;
    uint32 DescriptionAlt7;
    uint32 DescriptionFlags;
	uint32 unk2;

};
struct SpellEntry
{
   uint32 Id;
    uint32 School;
    uint32 Category;
    uint32 field4;
    uint32 field5;
    uint32 field5_1;
    uint32 Attributes;
    uint32 AttributesEx;
    uint32 new_field1;
    uint32 field8;
    uint32 field9;
    uint32 Targets;
    uint32 TargetCreatureType;
    uint32 RequiresSpellFocus;
    uint32 CasterAuraState;
    uint32 TargetAuraState;
        uint32 CastingTimeIndex;
    uint32 RecoveryTime;
    uint32 CategoryRecoveryTime;
    uint32 InterruptFlags;
    uint32 AuraInterruptFlags;
    uint32 ChannelInterruptFlags;
    uint32 procFlags;
    uint32 procChance;
    uint32 procCharges;
    uint32 maxLevel;
    uint32 baseLevel;
    uint32 spellLevel;
    uint32 DurationIndex;
    uint32 powerType;
    uint32 manaCost;
    uint32 manaCostPerlevel;
    uint32 manaPerSecond;
    uint32 manaPerSecondPerLevel;
    uint32 rangeIndex;
    float speed;
    uint32 modalNextSpell;
    uint32 field36;
    uint32 Totem[2];
    uint32 Reagent[8];
    uint32 ReagentCount[8];
    uint32 EquippedItemClass;
    uint32 EquippedItemSubClass;
    uint32 Effect[3];
    uint32 EffectDieSides[3];
    uint32 EffectBaseDice[3];
    float EffectDicePerLevel[3];
    float EffectRealPointsPerLevel[3];
    int32 EffectBasePoints[3];
	int32  Effectunk190[3];
    uint32 EffectImplicitTargetA[3];
    uint32 EffectImplicitTargetB[3];
    uint32 EffectRadiusIndex[3];
    uint32 EffectApplyAuraName[3];
    uint32 EffectAmplitude[3];
    float Effectunknown[3];
    uint32 EffectChainTarget[3];
    uint32 EffectSpellGroupRelation[3]; // not sure maybe we should rename it. its the relation to field: SpellGroupType
    uint32 EffectMiscValue[3];
    uint32 EffectTriggerSpell[3];
    float EffectPointsPerComboPoint[3];
    uint32 SpellVisual;
    uint32 field110;
    uint32 SpellIconID;
    uint32 activeIconID;
    uint32 spellPriority;
    uint32 Name;
    uint32 NameAlt1;
    uint32 NameAlt2;
    uint32 NameAlt3;
    uint32 NameAlt4;
    uint32 NameAlt5;
    uint32 NameAlt6;
    uint32 NameAlt7;
    uint32 NameFlags;
    uint32 Rank;
    uint32 RankAlt1;
    uint32 RankAlt2;
    uint32 RankAlt3;
    uint32 RankAlt4;
    uint32 RankAlt5;
    uint32 RankAlt6;
    uint32 RankAlt7;
    uint32 RankFlags;
    uint32 Description;
    uint32 DescriptionAlt1;
    uint32 DescriptionAlt2;
    uint32 DescriptionAlt3;
    uint32 DescriptionAlt4;
    uint32 DescriptionAlt5;
    uint32 DescriptionAlt6;
    uint32 DescriptionAlt7;
    uint32 DescriptionFlags;
    uint32 BuffDescription;
    uint32 BuffDescriptionAlt1;
    uint32 BuffDescriptionAlt2;
    uint32 BuffDescriptionAlt3;
    uint32 BuffDescriptionAlt4;
    uint32 BuffDescriptionAlt5;
    uint32 BuffDescriptionAlt6;
    uint32 BuffDescriptionAlt7;
	uint32 buffdescflags;
    uint32 ManaCostPercentage;
	uint32 unkflags;
    uint32 StartRecoveryTime;
    uint32 StartRecoveryCategory;
    uint32 SpellFamilyName;
    uint32 SpellGroupType; // flags
	uint32 FD;
	uint32 FE;
	uint32 FF;
	uint32 FG;
	uint32 FH;
	uint32 FI;
	uint32 FJ;
	uint32 FK;
	uint32 FL;
	uint32 FM;
};
struct Trainerspell
{
	uint32 Id;
	uint32 skilline1;
	uint32 skilline2;
	uint32 skilline3;
	uint32 maxlvl;
	uint32 charclass;
};
struct SpellCastTime
{
    uint32 ID;
    uint32 CastTime;
	uint32 unk1;
	uint32 unk2;
};

struct SpellRadius
{
    uint32 ID;
    float Radius;
	float unk1;
	float Radius2;
};

struct SpellRange
{
    uint32 ID;
    float minRange;
	float maxRange;
	uint32 unks[18];
};

struct SpellDuration
{
    uint32 ID;
    uint32 Duration1;
    uint32 Duration2;
    uint32 Duration3;
};

struct RandomProps
{
	uint32 ID;
	uint32 name1;
	uint32 spells[3];
	uint32 unk1;
	uint32 unk2;
	uint32 name2;
    uint32 RankAlt1;
    uint32 RankAlt2;
    uint32 RankAlt3;
    uint32 RankAlt4;
    uint32 RankAlt5;
    uint32 RankAlt6;
    uint32 RankAlt7;
    uint32 RankFlags;

};

struct AreaTable
{
    uint32 zoneId;
    uint32 mapId;
    uint32 parentZoneId;
    uint32 explorationFlag;
    uint32 boolEnabled;
    uint32 unk2;
    uint32 unk3;
    uint32 unk4;
    uint32 EXP;
    uint32 unk5;
    uint32 unk6;
    char* name;
    char* nameAlt1;
    char* nameAlt2;
    char* nameAlt3;
    char* nameAlt4;
    char* nameAlt5;
    char* nameAlt6;
    char* nameAlt7;
    char* nameFlags;
};

struct FactionTemplateDBC
{
    uint32 Id;
    uint32 FactionId;
    uint32 unk1;
    uint32 fightSupport;
    uint32 myFaction;
    uint32 hostile;
    uint32 unk5;
    uint32 unk6;
    uint32 unk7;
    uint32 unk8;
    uint32 unk9;
    uint32 unk10;
    uint32 unk11;
    uint32 unk12;
};

struct FactionDBC
{
    uint32 Id;
    uint32 unk1;
    uint32 FactionGroup;
    uint32 unk2;
    uint32 unk3;
    uint32 unk4;
    uint32 unk5;
    uint32 unk6;
    uint32 unk7;
    uint32 unk8;
    uint32 unk9;
    uint32 unk10;
    uint32 unk11;
    uint32 unk12;
    uint32 unk13;
    uint32 unk14;
    uint32 CapitalCity;
    uint32 unk15;
    uint32 factionGroupReputationFrame;
    char* name;
    char* nameAlt1;
    char* nameAlt2;
    char* nameAlt3;
    char* nameAlt4;
    char* nameAlt5;
    char* nameAlt6;
    char* nameAlt7;
    uint32 nameFlags;
    char* description;
    char* descriptionAlt1;
    char* descriptionAlt2;
    char* descriptionAlt3;
    char* descriptionAlt4;
    char* descriptionAlt5;
    char* descriptionAlt6;
    char* descriptionAlt7;
    uint32 descriptionFlags;
    uint32 unk16;
};

struct WorldMapArea
{
	uint32	ID;
	uint32	mapId;
	uint32	zoneId;
	uint32	zoneName;
	float	y1, y2;
	float	x1, x2;
};

struct WorldMapOverlay
{
    uint32 ID;
	uint32 worldMapAreaID;
	uint32 areaTableID;
	uint32 unk1;
	uint32 unk2;
	uint32 unk3;
	uint32 unk4;
	uint32 unk5;
	uint32 name;
	uint32 areaW; 
	uint32 areaH; 
	uint32 areaX;  
	uint32 areaY;  
	uint32 y1;  
	uint32 x1;
	uint32 y2; 
	uint32 x2; 
};
float GetRadius(SpellRadius *radius);
uint32 GetCastTime(SpellCastTime *time);
float GetMinRange(SpellRange *range);
float GetMaxRange(SpellRange *range);
uint32 GetDuration(SpellDuration *dur);
// You need two lines like this for every new DBC store
defineIndexedDBCStore(SpellStore,SpellEntry);
defineIndexedDBCStore(DurationStore,SpellDuration);
defineIndexedDBCStore(RangeStore,SpellRange);
defineIndexedDBCStore(EmoteStore,emoteentry);
defineIndexedDBCStore(RadiusStore,SpellRadius);
defineIndexedDBCStore(CastTimeStore,SpellCastTime);
defineIndexedDBCStore(TalentStore,TalentEntry);
defineIndexedDBCStore(AreaStore,AreaTable);
defineIndexedDBCStore(WorldMapAreaStore,WorldMapArea);
defineDBCStore(WorldMapOverlayStore,WorldMapOverlay);
defineIndexedDBCStore(FactionTmpStore,FactionTemplateDBC);
defineIndexedDBCStore(FactionStore,FactionDBC);
defineIndexedDBCStore(EnchantStore,EnchantEntry);
defineIndexedDBCStore(RandomPropStore,RandomProps);
defineDBCStore(SkillStore,skilllinespell);
defineIndexedDBCStore(SkillLineStore,skilllineentry);
#define sRandomPropStore RandomPropStore::getSingleton()
#define sEnchantStore EnchantStore::getSingleton()
#define sSpellStore SpellStore::getSingleton()
#define sSkillLineStore SkillLineStore::getSingleton()
#define sSkillStore SkillStore::getSingleton()
#define sEmoteStore EmoteStore::getSingleton()
#define sSpellDuration DurationStore::getSingleton()
#define sSpellRange RangeStore::getSingleton()
#define sSpellRadius RadiusStore::getSingleton()
#define sCastTime CastTimeStore::getSingleton()
#define sTalentStore TalentStore::getSingleton()
#define sAreaStore AreaStore::getSingleton()
#define sWorldMapAreaStore WorldMapAreaStore::getSingleton()
#define sWorldMapOverlayStore WorldMapOverlayStore::getSingleton()
#define sFactionTmpStore FactionTmpStore::getSingleton()
#define sFactionStore FactionStore::getSingleton()

#endif
