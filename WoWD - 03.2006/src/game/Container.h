// Copyright (C) 2004 WoW Daemon
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.

#ifndef _CONTAINER_H
#define _CONTAINER_H


#include "Object.h"
#include "ItemPrototype.h"


#define CONTAINER_NO_SLOT_AVAILABLE 255

class Item;
class WorldSession;
class Container : public Object
{
public:
	   friend class WorldSession;
    Container( );
	~Container();

    void Create( uint32 guidlow, uint32 itemid, Player* owner );

    ItemPrototype* GetProto() const { return m_itemProto; }
    void AddItem(uint8 slot, Item *item);
    Item *GetItem(uint8 slot) { return m_Slot[slot]; }
    uint8 FindFreeSlot();
    void SwapItems(uint8 SrcSlot, uint8 DstSlot);
	Item* RemoveItemFromSlot(uint8 slot) { return RemoveItemFromSlot(slot, true); }
	Item* RemoveItemFromSlot(uint8 slot, bool DestroyForPlayer);
	void SaveBagToDB(uint8 DestinationBagSlot);
	bool HasItems();



    Player* GetOwner() const { return m_owner; }
    void SetOwner(Player *owner) { m_owner = owner; }

protected:
    ItemPrototype *m_itemProto;
    Player *m_owner;
    Item **m_Slot;
};

#endif
