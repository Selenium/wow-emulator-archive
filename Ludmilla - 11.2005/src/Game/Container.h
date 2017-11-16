#ifndef WOWSERVER_CONTAINER_H
#define WOWSERVER_CONTAINER_H

#include "Object.h"
#include "ItemPrototype.h"
#include "Unit.h"
#include "Creature.h"


// ---------------------------------------------------------
class Container : public Item
{
public:
    Container ( );
	~Container ( );

	void Create( uint32 guidlow, uint32 itemid, Player *owner );

	void AddItemToContainer (uint8 slot, Item *item);

    Item* GetItemFromBag (uint8 slot) { return m_bagslot[slot]; }

    uint8 FindFreeBagSlot();

	// DB operations
	void SaveToDB();
	void LoadFromDB(uint32 guid, uint32 auctioncheck);
	void DeleteFromDB();

protected:
	
	// Bag Storage space
	Item* m_bagslot[20];

};

#endif