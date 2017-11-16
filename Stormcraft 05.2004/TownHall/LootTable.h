#pragma once
#include "stdafx.h"
#include "WoWObject.h"

struct LootItem
{
	unsigned long ItemTemplate;
	unsigned long Rate;
};

struct LootTableData
{
	unsigned long MaxItems; // 10 or this number, whichever is lower!
	LootItem Items[20];
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
};
