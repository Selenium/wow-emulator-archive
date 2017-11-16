#include "DBCStores.h"
#include "DataStore.h"

// You need a line like this for every DBC store. If you use createDBCStore (no Indexed), the lines will be ordered the way they are in the file
// SpellEntry is the file struct entry (for Spell.dbc here).
implementIndexedDBCStore(SpellStore,SpellEntry)
implementIndexedDBCStore(DurationStore,SpellDuration)
implementIndexedDBCStore(RangeStore,SpellRange)
implementIndexedDBCStore(EmoteStore,emoteentry)
implementIndexedDBCStore(RadiusStore,SpellRadius)
implementIndexedDBCStore(CastTimeStore,SpellCastTime)
implementIndexedDBCStore(TalentStore,TalentEntry)
implementIndexedDBCStore(AreaStore,AreaTable);
implementIndexedDBCStore(FactionTmpStore,FactionTemplateDBC);
implementIndexedDBCStore(RandomPropStore,RandomProps);
implementIndexedDBCStore(FactionStore,FactionDBC);
implementIndexedDBCStore(EnchantStore,EnchantEntry);
implementIndexedDBCStore(WorldMapAreaStore,WorldMapArea);
implementDBCStore(WorldMapOverlayStore,WorldMapOverlay);
implementDBCStore(SkillStore,skilllinespell)
implementIndexedDBCStore(SkillLineStore,skilllineentry);
// When loading this DBC, just write new SpellStore("spell.dbc");

float GetRadius(SpellRadius *radius)
{
	return radius->Radius;
}
uint32 GetCastTime(SpellCastTime *time)
{
	return time->CastTime;
}
float GetMaxRange(SpellRange *range)
{
	return range->maxRange;
}
float GetMinRange(SpellRange *range)
{
	return range->minRange;
}
uint32 GetDuration(SpellDuration *dur)
{
	return dur->Duration1;
}

