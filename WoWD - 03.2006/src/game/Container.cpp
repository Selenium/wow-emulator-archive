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

#include "Common.h"
#include "ObjectMgr.h"
#include "Database/DatabaseEnv.h"
#include "Container.h"
#include "UpdateData.h"
#include "WorldPacket.h"
#include "WorldSession.h"
#include "World.h"


Container::Container( ) : Object()
{
    m_objectType |= TYPE_CONTAINER;
    m_objectTypeId = TYPEID_CONTAINER;

    m_valuesCount = CONTAINER_END;

	m_Slot = NULL;
}

Container::~Container( )
{
	for(int i = 0; i < m_itemProto->ContainerSlots; i++)
    {
        if(m_Slot[i])
            delete m_Slot[i];
    }
}

void Container::Create( uint32 guidlow, uint32 itemid, Player *owner )
{
    Object::_Create( guidlow, HIGHGUID_CONTAINER );

    m_itemProto = objmgr.GetItemPrototype( itemid );
    ASSERT(m_itemProto);

    SetUInt32Value( OBJECT_FIELD_ENTRY, itemid );
    SetFloatValue( OBJECT_FIELD_SCALE_X, 1.0f );
    SetUInt64Value( ITEM_FIELD_OWNER, owner->GetGUID() );
    SetUInt64Value( ITEM_FIELD_CONTAINED, owner->GetGUID() );
    SetUInt32Value( ITEM_FIELD_STACK_COUNT, 1 );
    SetUInt32Value( CONTAINER_FIELD_NUM_SLOTS, m_itemProto->ContainerSlots);

    m_Slot = new Item*[m_itemProto->ContainerSlots];
    memset(m_Slot, 0, sizeof(Item*)*(m_itemProto->ContainerSlots));

    m_owner = owner;
}


uint8 Container::FindFreeSlot()
{
    uint32 TotalSlots = GetUInt32Value( CONTAINER_FIELD_NUM_SLOTS );
    for (uint8 i=0; i < TotalSlots; i++)
    {
        if(!m_Slot[i]) 
        { 
            return i; 
        }
    }
    return CONTAINER_NO_SLOT_AVAILABLE;
}

bool Container::HasItems()
{
	uint32 TotalSlots = GetUInt32Value( CONTAINER_FIELD_NUM_SLOTS );
    for (uint8 i=0; i < TotalSlots; i++)
    {
        if(m_Slot[i]) 
        { 
            return true; 
        }
    }
	return false;
}

void Container::AddItem(uint8 slot, Item *item)
{
	UpdateData upd;
	WorldPacket packet;
	ASSERT(m_Slot[slot] == NULL);

	//new version to fix bag issues
	if(m_owner->IsInWorld())
	{
		//item is a container
		if(item->GetProto()->InventoryType == INVTYPE_BAG)
		{
			m_Slot[slot] = item;
			m_Slot[slot]->pContainer = new Container();
            m_Slot[slot]->pContainer->Create(objmgr.GenerateLowGuid(HIGHGUID_CONTAINER),item->GetProto()->ItemId,m_owner);
			item->pContainer->SetOwner(m_owner);
			item->pContainer->AddToWorld();
			item->SetOwner(m_owner);
			item->AddToWorld();

			upd.Clear();
			item->pContainer->BuildCreateUpdateBlockForPlayer( &upd, m_owner );
			upd.BuildPacket( &packet );
			m_owner->GetSession()->SendPacket( &packet );

			SetUInt64Value( (uint16)(CONTAINER_FIELD_SLOT_1  + (slot*2)), item->pContainer->GetGUID() );
		}
		else
		{
			m_Slot[slot] = item;
			item->SetOwner(m_owner);
			item->AddToWorld();

			upd.Clear();
			item->BuildCreateUpdateBlockForPlayer( &upd, m_owner );
			upd.BuildPacket( &packet );
			m_owner->GetSession()->SendPacket( &packet );

			SetUInt64Value( (uint16)(CONTAINER_FIELD_SLOT_1  + (slot*2)), item->GetGUID() );
		}
	}
	else
	{
		if(item->GetProto()->InventoryType == INVTYPE_BAG)
		{
			m_Slot[slot] = item;
			m_Slot[slot]->pContainer = new Container();
            m_Slot[slot]->pContainer->Create(objmgr.GenerateLowGuid(HIGHGUID_CONTAINER),item->GetProto()->ItemId,m_owner);
			SetUInt64Value( (uint16)(CONTAINER_FIELD_SLOT_1  + (slot*2)), item->pContainer->GetGUID() );
			item->pContainer->SetOwner(m_owner);
			item->pContainer->AddToWorld();
			item->SetOwner(m_owner);
			item->AddToWorld();
		}
		else
		{
			m_Slot[slot] = item;
			SetUInt64Value( (uint16)(CONTAINER_FIELD_SLOT_1  + (slot*2)), item->GetGUID() );
			item->SetOwner(m_owner);
			item->AddToWorld();
		}
	}
}

void Container::SwapItems(uint8 SrcSlot, uint8 DstSlot)
{
	Item *temp;
    temp = m_Slot[SrcSlot];
    m_Slot[SrcSlot] = m_Slot[DstSlot];
    m_Slot[DstSlot] = temp;


	if( m_Slot[DstSlot])
	{
		if((m_Slot[DstSlot]->GetProto()->InventoryType == INVTYPE_BAG))
		{
			SetUInt64Value( (uint16)(CONTAINER_FIELD_SLOT_1  + (DstSlot*2)), m_Slot[DstSlot]->pContainer->GetGUID());
		}
		else
		{
			SetUInt64Value( (uint16)(CONTAINER_FIELD_SLOT_1  + (DstSlot*2)),  m_Slot[DstSlot]->GetGUID()  );
		}
	}
	else
	{
		SetUInt64Value( (uint16)(CONTAINER_FIELD_SLOT_1  + (DstSlot*2)), 0 );
	}

	if( m_Slot[SrcSlot])
	{
		if((m_Slot[SrcSlot]->GetProto()->InventoryType == INVTYPE_BAG))
		{
			SetUInt64Value( (uint16)(CONTAINER_FIELD_SLOT_1  + (SrcSlot*2)),  m_Slot[SrcSlot]->pContainer->GetGUID()  );
		}
		else
		{
			SetUInt64Value( (uint16)(CONTAINER_FIELD_SLOT_1  + (SrcSlot*2)), m_Slot[SrcSlot]->GetGUID() );
		}
	}
	else
	{
		SetUInt64Value( (uint16)(CONTAINER_FIELD_SLOT_1  + (SrcSlot*2)), 0 );

	}
}

Item* Container::RemoveItemFromSlot(uint8 slot, bool DestroyForPlayer)
{
	Item *item = m_Slot[slot];
	
    if (item == NULL) return NULL;
    m_Slot[slot] = NULL;
	SetUInt64Value( (uint16)(CONTAINER_FIELD_SLOT_1  + (slot*2)), 0 );

	if(item->GetProto()->InventoryType == INVTYPE_BAG)
	{
		item->pContainer->SetOwner(NULL);
		item->pContainer->RemoveFromWorld();
		if(DestroyForPlayer)
			item->pContainer->DestroyForPlayer(m_owner);
		item->RemoveFromWorld();
	}
	else
	{
		item->SetOwner(NULL);
		item->RemoveFromWorld();
		if(DestroyForPlayer)
			item->DestroyForPlayer( m_owner );
	}
	return item;
}

void Container::SaveBagToDB(uint8 DestinationBagSlot)
{
	std::stringstream delinvq;
    delinvq << "DELETE FROM bag_inventory WHERE player_guid = " << m_owner->GetGUIDLow() << " AND bagslot=" << (uint32)DestinationBagSlot;
    sDatabase.Execute( delinvq.str().c_str( ) );

    for(unsigned int i = 0; i < m_itemProto->ContainerSlots; i++)
    {
        if (m_Slot[i])
        {
            m_Slot[i]->SaveToDB();

            std::stringstream invq;
            invq <<  "INSERT INTO bag_inventory (player_guid, bagslot, slot, item_guid) VALUES (" << m_owner->GetGUIDLow() << ", " << (uint32)DestinationBagSlot << ", " << i << ", " << m_Slot[i]->GetGUIDLow() << " )";

            sDatabase.Execute( invq.str().c_str( ) );
        }
    }
}

