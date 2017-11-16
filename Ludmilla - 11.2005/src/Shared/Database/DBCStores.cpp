#include "StdAfx.h"

// You need a line like this for every DBC store. If you use createDBCStore (no Indexed), the lines will be ordered the way they are in the file
// SpellEntry is the file struct entry (for Spell.dbc here).
implementIndexedDBCStore (SpellStore, SpellEntry)
implementDBCStore (DurationStore, SpellDuration)
implementDBCStore (RangeStore, SpellRange)
implementIndexedDBCStore (EmoteStore, EmoteEntry)
implementIndexedDBCStore (RadiusStore, SpellRadius)
implementDBCStore (CastTimeStore, SpellCastTime)
implementIndexedDBCStore (WorldMapAreaStore, WorldMapArea)
implementIndexedDBCStore(AreaTableStore,AreaTableEntry)
implementDBCStore(WorldMapOverlayStore,WorldMapOverlayEntry)
implementIndexedDBCStore (TalentStore, TalentEntry)
implementIndexedDBCStore (ItemRandomPropertiesStore, ItemRandomPropertiesEntry)
implementIndexedDBCStore (SpellItemEnchantmentStore, SpellItemEnchantmentEntry)
implementDBCStore (SkillStore, skilllinespell)
implementIndexedDBCStore (FactionStore, FactionEntry)
//-----------------------------------------------------------------------------
// When loading this DBC, just write new SpellStore("spell.dbc");
float GetRadius(SpellRadius *radius)
{
	return radius->Radius;
}

//-----------------------------------------------------------------------------
uint32 GetCastTime(SpellCastTime *time)
{
	return time->CastTime;
}

//-----------------------------------------------------------------------------
float GetRange(SpellRange *range)
{
	return range->Range;
}

//-----------------------------------------------------------------------------
uint32 GetDuration(SpellDuration *dur)
{
	return dur->Duration1;
}

//--- END ---