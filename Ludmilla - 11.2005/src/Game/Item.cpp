#include "StdAfx.h"

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

#include "../Shared/Common.h"
#include "Item.h"
#include "ObjectMgr.h"
#include "../Shared/Database/DatabaseEnv.h"

//-----------------------------------------------------------------------------
Item::Item()
{
    m_objectType |= TYPE_ITEM;
    m_objectTypeId = TYPEID_ITEM;

    m_valuesCount = ITEM_END;
}
//-----------------------------------------------------------------------------
void Item::Create( uint32 guidlow, uint32 itemid, Unit *owner )
{
	m_itemProto = objmgr.GetItemPrototype( itemid );
    ASSERT(m_itemProto);

	Object::_Create( guidlow, HIGHGUID_ITEM );

    SetUInt32Value( OBJECT_FIELD_ENTRY, itemid );
    SetFloatValue( OBJECT_FIELD_SCALE_X, 1.0f );

    SetUInt64Value( ITEM_FIELD_OWNER, owner->GetGUID() );
    SetUInt64Value( ITEM_FIELD_CONTAINED, owner->GetGUID() );

	SetUInt32Value( ITEM_FIELD_MAXDURABILITY, m_itemProto->MaxDurability);
    SetUInt32Value( ITEM_FIELD_DURABILITY, m_itemProto->MaxDurability);
	SetUInt32Value( ITEM_FIELD_FLAGS, m_itemProto->Flags);

	SetUInt32Value( ITEM_FIELD_RANDOM_PROPERTIES_ID, m_itemProto->RandPropID);

    if (owner->isPlayer()) m_owner = (Player*)owner;
	if (owner->isUnit()) c_owner = (Creature*)owner;
}

//-----------------------------------------------------------------------------
void Item::SaveToDB()
{
    std::stringstream ss;
    ss << "DELETE FROM item_instances WHERE guid = " << GetGUIDLow();
    sDatabase.Execute( ss.str( ).c_str( ) );

	//Log::getSingleton( ).outDebug ("ITEM: SAVE DB: [%d] FIELDS SAVED", m_valuesCount);

    ss.rdbuf()->str("");
    
	ss << "INSERT INTO item_instances (guid, data) VALUES ("
        << GetGUIDLow() << ", '"; // TODO: use full guids
    for(uint16 i = 0; i < m_valuesCount; i++ )
        ss << GetUInt32Value(i) << " ";

	ss << "')";

/*
	ss << "INSERT INTO item_instances (guid, owner, contained, creator, giftcreator, "
		<< "stackcount, duration, charges1, charges2, charges3, charges4, charges5, "
		<< "flags, enchant1, enchant2, enchant3, enchant4, enchant5, enchant6, enchant7, "
		<< "enchant8, enchant9, enchant10, enchant11, enchant12, enchant13, enchant14, "
		<< "enchant15, enchant16, enchant17, enchant18, enchant19, enchant20, enchant21, "
		<< "randpropid, itemtextid, durability, maxdurability) VALUES ("
		<< GetGUIDLow() << ", "
		<< GetUInt64Value (ITEM_FIELD_OWNER) << ", "
		<< GetUInt64Value (ITEM_FIELD_CONTAINED) << ", "
		<< GetUInt64Value (ITEM_FIELD_CREATOR) << ", "
		<< GetUInt64Value (ITEM_FIELD_GIFTCREATOR) << ", "
		<< GetUInt32Value (ITEM_FIELD_STACK_COUNT) << ", "
		<< GetUInt32Value (ITEM_FIELD_DURATION) << ", ";
	
	for (int i = 0; i < 5; i++) ss << GetUInt32Value (ITEM_FIELD_SPELL_CHARGES + i) << ", ";
	ss << GetUInt32Value (ITEM_FIELD_FLAGS) << ", ";
	for (int i = 0; i < 21; i++) ss << GetUInt32Value (ITEM_FIELD_ENCHANTMENT + i) << ", ";

	ss << GetUInt32Value (ITEM_FIELD_RANDOM_PROPERTIES_ID) << ", "
		<< GetUInt32Value (ITEM_FIELD_ITEM_TEXT_ID) << ", "
		<< GetUInt32Value (ITEM_FIELD_DURABILITY) << ", "
		<< GetUInt32Value (ITEM_FIELD_MAXDURABILITY) << ")";
*/
    sDatabase.Execute( ss.str().c_str() );
}

//-----------------------------------------------------------------------------
void Item::LoadFromDB(uint32 guid, uint32 auctioncheck)
{
	std::stringstream ss;

	//Log::getSingleton( ).outDebug ("ITEM: LOAD FROM DB: [%d] FIELDS LOADED", m_valuesCount);

	if (auctioncheck == 1)
	{
		ss << "SELECT data FROM item_instances WHERE guid = " << guid;
	}
	else if (auctioncheck == 2)
	{
		ss << "SELECT data FROM auctioned_items WHERE guid = " << guid;
	}
	else
	{
		ss << "SELECT data FROM mailed_items WHERE guid = " << guid;
	}

	QueryResult *result = sDatabase.Query( ss.str().c_str() );
	if (result == NULL) {
		m_itemProto = NULL; // Sign of unsuccessful loading
		return;
	}

	Field *fields = result->Fetch();

	LoadValues( fields[0].GetString() );

	delete result;

	m_itemProto = objmgr.GetItemPrototype( GetUInt32Value(OBJECT_FIELD_ENTRY) );
	ASSERT(m_itemProto);

}

//-----------------------------------------------------------------------------
void Item::DeleteFromDB()
{
    std::stringstream ss;
    ss << "DELETE FROM item_instances WHERE guid = " << GetGUIDLow();
    sDatabase.Execute( ss.str( ).c_str( ) );
}
