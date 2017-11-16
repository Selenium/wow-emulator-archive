// (c) AbyssX Group
#if !defined(ITEMDATABASE_H)
#define ITEMDATABASE_H

class ItemPrototype;

class ItemDatabase
{
private:
	int numItems;
	ItemPrototype *items;
public:
	ItemDatabase();
	void Initialize(const int size);
	ItemPrototype *GetItemByID(const int id);
	void SetItemByID(const int id, ItemPrototypeData *itemdata);
	const int GetNumberOfItems();
	const int AddItem(ItemPrototypeData *itemdata);
	~ItemDatabase();
};

#endif