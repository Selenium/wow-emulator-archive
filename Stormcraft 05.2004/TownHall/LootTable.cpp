#include "LootTable.h"

CLootTable::CLootTable(void):CWoWObject(OBJ_LOOTTABLE)
{
}

CLootTable::~CLootTable(void)
{
}

void CLootTable::Clear()
{
	CWoWObject::Clear();
	memset(&Data,0,sizeof(LootTableData));
}

void CLootTable::New()
{
	Clear();
	CWoWObject::New();
}

bool CLootTable::StoringData(ObjectStorage &Storage)
{
	// dont store until we're actually ready.
	return false;
	if (!guid)
		return false;
	Storage.Allocate(sizeof(LootTableData));
	memcpy(Storage.Data,&Data,sizeof(LootTableData));
	return true;
}

bool CLootTable::LoadingData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	memcpy(&Data,Storage.Data,sizeof(LootTableData));
	return true;
}

