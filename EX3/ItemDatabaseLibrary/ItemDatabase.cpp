// (c) AbyssX Group

#include "ItemDatabaseEnvironment.h"

ItemDatabase::ItemDatabase()
{
	numItems = 0;
	items = NULL;
}

void ItemDatabase::Initialize(const int size)
{
	if(items != NULL)
		delete [numItems] items;
	numItems = size;
	items = new ItemPrototype[size];
}

ItemPrototype *ItemDatabase::GetItemByID(const int id)
{
	if(id < 0 || id >= numItems) return NULL;
	return &items[id];
}

void ItemDatabase::SetItemByID(const int id, ItemPrototypeData *itemdata)
{
	if(id < 0 || id >= numItems || itemdata == NULL) return;
	items[id].SetPrototypeData(itemdata);
}

const int ItemDatabase::GetNumberOfItems()
{
	return numItems;
}

const int ItemDatabase::AddItem(ItemPrototypeData *itemdata)
{
	for(int i=0; i < numItems; i++)
	{
		if(!items[i].IsInfoSet())
		{
			items[i].SetPrototypeData(itemdata);
			return i;
		}
	}
	return -1;
}


ItemDatabase::~ItemDatabase()
{
	if(items != NULL)
		delete [numItems] items;
	numItems = 0;
}