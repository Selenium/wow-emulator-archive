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
