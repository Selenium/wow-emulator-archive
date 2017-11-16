#include "StdAfx.h"

#include "../Shared/Common.h"
#include "ObjectMgr.h"
#include "Container.h"
#include "../Shared/Database/DatabaseEnv.h"

//-----------------------------------------------------------------------------
Container::Container( ): Item()
{
    m_objectType |= TYPE_CONTAINER;
    m_objectTypeId = TYPEID_CONTAINER;

    m_valuesCount = CONTAINER_END;

	memset(m_bagslot, 0, sizeof(Item *) * (20)); // Maximum 20 Slots
}

//-----------------------------------------------------------------------------
Container::~Container()
{
	for(int i = 0; i<20; i++)
    {
        if(m_bagslot[i])	delete m_bagslot[i];
    }
}

//-----------------------------------------------------------------------------
void Container::Create( uint32 guidlow, uint32 itemid, Player *owner )
{
	m_itemProto = objmgr.GetItemPrototype(itemid);
    
	ASSERT(m_itemProto);
	ASSERT(m_itemProto->ContainerSlots < 20); // Max 20 Slots possible (1.8.x)
	
	Object::_Create( guidlow, HIGHGUID_CONTAINER );

    SetUInt32Value( OBJECT_FIELD_ENTRY, itemid );
    SetFloatValue( OBJECT_FIELD_SCALE_X, 1.0f );

    SetUInt64Value( ITEM_FIELD_OWNER, owner->GetGUID() );
    SetUInt64Value( ITEM_FIELD_CONTAINED, owner->GetGUID() );

	SetUInt32Value( ITEM_FIELD_MAXDURABILITY, m_itemProto->MaxDurability);
    SetUInt32Value( ITEM_FIELD_DURABILITY, m_itemProto->MaxDurability);
	SetUInt32Value( ITEM_FIELD_FLAGS, m_itemProto->Flags);

	// Let's set Default count to 1
	SetUInt32Value (ITEM_FIELD_STACK_COUNT, 1);

	// Setting the number of Slots the Container has
	SetUInt32Value(CONTAINER_FIELD_NUM_SLOTS, m_itemProto->ContainerSlots);

	// Creating Empty Slots inside Container
	for (uint8 i = 0; i < m_itemProto->ContainerSlots; i++) {
		SetUInt64Value(CONTAINER_FIELD_SLOT_1 + i, 0);
	}
	for(int i = 0; i < 20; i++) // Cleanning 20 slots
    {
        m_bagslot[i] = NULL;
    }
	////////////////////////////////////////

	if (owner->isPlayer()) m_owner = (Player*)owner;
	if (owner->isUnit()) c_owner = (Creature*)owner;

	Log::getSingleton( ).outDebug ("ack > CONTAINER: CREATED ID[%d] SLOTS[%d]", itemid, m_itemProto->ContainerSlots);

}
//-----------------------------------------------------------------------------
void Container::SaveToDB()
{
	//Log::getSingleton( ).outDebug ("ack > CONTAINER: [%d] SAVE TO DB: [%d] FIELDS SAVED", GetEntry(), m_valuesCount);

	Item::SaveToDB();
}
//-----------------------------------------------------------------------------
void Container::LoadFromDB(uint32 guid, uint32 auctioncheck)
{
	Item::LoadFromDB(guid, auctioncheck);

	//Log::getSingleton( ).outDebug ("ack > CONTAINER: [%d] LOAD FROM DB: [%d] FIELDS LOADED", GetEntry(), m_valuesCount);

}
//-----------------------------------------------------------------------------
void Container::DeleteFromDB()
{
	//Log::getSingleton( ).outDebug ("ack > CONTAINER: [%d] DELETE FROM DB: [%d] FIELDS LOADED", GetEntry(), m_valuesCount);
	
	Item::DeleteFromDB();
}

// ------------------------------------------------------------------------------------
uint8 Container::FindFreeBagSlot()
{
    for (uint8 i=0; i < m_itemProto->ContainerSlots; i++)
    {
        if(!m_bagslot[i])
        {
            return i;
        }
     }
    return -1;
}

// ------------------------------------------------------------------------------------
void Container::AddItemToContainer(uint8 slot, Item *item)
{
    ASSERT(m_bagslot[slot] == NULL);
	
	Log::getSingleton( ).outDebug ("ack > CONTAINER: [%d] GETTING ITEM [%d] ", GetEntry(), item->GetEntry());

    m_bagslot[slot] = item;
	
	// Adding into Container Slot
    SetUInt64Value( CONTAINER_FIELD_SLOT_1 + (slot * 2), item->GetGUID() );
	
	// Setting contained to Container
	item->SetUInt64Value( ITEM_FIELD_CONTAINED, GetGUID() );

}

//--- END ---