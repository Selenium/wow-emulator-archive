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

#ifndef WOWSERVER_ITEM_H
#define WOWSERVER_ITEM_H

#include "Object.h"
#include "ItemPrototype.h"
#include "Database/DatabaseEnv.h"

class Container;
class Item : public Object
{
public:
    Item ( );

    void Create( uint32 guidlow, uint32 itemid, Player* owner );

    ItemPrototype* GetProto() const { return m_itemProto; }
    Container* pContainer; //holds the bag items

    Player* GetOwner() const { return m_owner; }
    void SetOwner(Player *owner) { m_owner = owner; }

    //! DB Serialization
    void SaveToDB();
    bool LoadFromDB(uint32 guid, uint32 auctioncheck);
    void DeleteFromDB();

    //! Item Properties
    void SetDurability(uint32 Value);
    void SetDurabilityToMax();

	bool IsEnchanted();
	bool IsTempEnchanted();
	uint32 GetEnchant() { return enchanted;}
	uint32 GetEnchantSlot() { return enchantslot;}
	void SetEnchantSlot(uint32 id) { enchantslot = id;}
	uint32 GetTempEnchant() { return tempenchanted;}
	void SetEnchanted(uint32 id) {enchanted = id;}
	void Enchant(bool apply, SpellEntry *m_spellInfo);
	void addEnchantBonus(EnchantEntry *ee);
	void RemoveEnchantBonus(uint32 eid);
	void RemoveEnchant(uint32 eid);

protected:
	uint32 enchanted;
	uint32 enchantslot;
	uint32 tempenchantslot;
	uint32 tempenchanted;
    ItemPrototype *m_itemProto;
    Player *m_owner; // let's not bother the manager with unneeded requests
};

#endif
