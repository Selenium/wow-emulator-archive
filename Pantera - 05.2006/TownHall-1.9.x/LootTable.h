#ifndef LOOTTABLE_H
#define LOOTTABLE_H

#include "stdafx.h"
#include "WoWObject.h"
#include <vector>

#define MAXLOOTITEMS 432

struct LootItem
{
	unsigned long ItemTemplate;
	float Rate;
};

struct LootTableData
{
	unsigned long MaxItems; // 10 or this number, whichever is lower!
	LootItem Items[MAXLOOTITEMS];
};

class CLootTable :
	public CWoWObject
{
public:
	CLootTable(void);
	~CLootTable(void);

	LootTableData Data;

	void Clear();
	void New();
	bool StoringData(ObjectStorage &Storage);
	bool LoadingData(ObjectStorage &Storage);
	unsigned long DataStorageSize() {return sizeof(LootTableData);};

	static void GenerateLoot(CCreature *pCreature);
};

#endif // LOOTTABLE_H
