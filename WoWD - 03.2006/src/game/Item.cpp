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
#include "Item.h"
#include "ObjectMgr.h"
#include "Database/DatabaseEnv.h"
#include "Spell.h"

Item::Item( )
{
    m_objectType |= TYPE_ITEM;
    m_objectTypeId = TYPEID_ITEM;

    m_valuesCount = ITEM_END;
	enchanted = false;
	pContainer = NULL;
	enchantslot = 0;
}


void Item::Create( uint32 guidlow, uint32 itemid, Player *owner )
{
    Object::_Create( guidlow, HIGHGUID_ITEM );

    SetUInt32Value( OBJECT_FIELD_ENTRY, itemid );
    SetFloatValue( OBJECT_FIELD_SCALE_X, 1.0f );

    SetUInt64Value( ITEM_FIELD_OWNER, owner->GetGUID() );
    SetUInt64Value( ITEM_FIELD_CONTAINED, owner->GetGUID() );
    SetUInt32Value( ITEM_FIELD_STACK_COUNT, 1 );
	SetUInt32Value( ITEM_FIELD_SPELL_CHARGES , 1);

    m_itemProto = objmgr.GetItemPrototype( itemid );
    ASSERT(m_itemProto);

    SetUInt32Value( ITEM_FIELD_MAXDURABILITY, m_itemProto->MaxDurability);
    SetUInt32Value( ITEM_FIELD_DURABILITY, m_itemProto->MaxDurability);

    m_owner = owner;
}
bool Item::IsEnchanted()
{
	if (GetEnchant())
	{
		return true;
	}
	else 
	{
		return false;
	}
}
bool Item::IsTempEnchanted()
{
	if (GetTempEnchant())
	{
		return true;
	}
	else 
	{
		return false;
	}
}
void Item::RemoveEnchant(uint32 eid)
{
	int VisibleBase = PLAYER_VISIBLE_ITEM_1_0 + m_owner->GetSlotByItemGUID(this->GetGUID() * 12);
	this->SetUInt32Value(GetEnchantSlot(),0);
	m_owner->SetUInt32Value(VisibleBase + 1,0);		
	RemoveEnchantBonus(eid);
}
void Item::RemoveEnchantBonus(uint32 eid)
{
	EnchantEntry * ee = sEnchantStore.LookupEntry(eid);
	switch (ee->type) {
		case 2:{
			uint32 res = m_owner->GetUInt32Value(PLAYER_FIELD_MOD_DAMAGE_DONE_POS);
			uint32 res2 = m_owner->GetUInt32Value(UNIT_FIELD_MINDAMAGE);
			uint32 res2m = m_owner->GetUInt32Value(UNIT_FIELD_MAXDAMAGE);
			m_owner->SetUInt32Value(UNIT_FIELD_MINDAMAGE,res2 - ee->min);
			m_owner->SetUInt32Value(UNIT_FIELD_MAXDAMAGE,res2m - ee->min);
			m_owner->SetUInt32Value(PLAYER_FIELD_MOD_DAMAGE_DONE_POS,res - ee->min);

		}break;
		case 3:{
			bool test = m_owner->RemoveAffect(ee->spell1);
		}break;
		case 4:{
			uint32 res = m_owner->GetUInt32Value(PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE);
			uint32 res2 = m_owner->GetUInt32Value(UNIT_FIELD_RESISTANCES);
			m_owner->SetUInt32Value(UNIT_FIELD_RESISTANCES,res2 - ee->min);
			m_owner->SetUInt32Value(PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE,res - ee->min);
		}break;
	}

}
void Item::Enchant(bool apply, SpellEntry *m_spellInfo)
{
	int VisibleBase = PLAYER_VISIBLE_ITEM_1_0 + m_owner->GetSlotByItemGUID(this->GetGUID() * 12);
	int slot = 0;
	for (int i = 0; i < 21;i++)
	{
		if (GetUInt32Value(ITEM_FIELD_ENCHANTMENT + i) == 0)
		{
			slot = ITEM_FIELD_ENCHANTMENT + i;
			break;
		}
	}
	SetUInt32Value(slot,m_spellInfo->EffectMiscValue[0]);
	SetEnchantSlot(slot);
	EnchantEntry * ee = sEnchantStore.LookupEntry(m_spellInfo->EffectMiscValue[0]);
	if (apply)
	{
		m_owner->SetUInt32Value(VisibleBase + 1,m_spellInfo->EffectMiscValue[0]);
		addEnchantBonus(ee);
	}
	SetEnchanted(ee->Id);
}
void Item::addEnchantBonus(EnchantEntry *ee)
{
	switch (ee->type) {
		case 2:{
			uint32 res = m_owner->GetUInt32Value(PLAYER_FIELD_MOD_DAMAGE_DONE_POS);
			uint32 res2 = m_owner->GetUInt32Value(UNIT_FIELD_MINDAMAGE);
			uint32 res2m = m_owner->GetUInt32Value(UNIT_FIELD_MAXDAMAGE);
			m_owner->SetUInt32Value(UNIT_FIELD_MINDAMAGE,res2 + ee->min);
			m_owner->SetUInt32Value(UNIT_FIELD_MAXDAMAGE,res2m +ee->min);
			m_owner->SetUInt32Value(PLAYER_FIELD_MOD_DAMAGE_DONE_POS,res + ee->min);
		}break;
		case 3:{
			SpellEntry* spells = sSpellStore.LookupEntry(ee->spell1);
			Spell *spell = new Spell(m_owner, spells ,false, 0, true);
			WPAssert(spell);
			SpellCastTargets targets;
			targets.m_unitTarget = m_owner->GetGUID();
			spell->prepare(&targets);
		}break;
		case 4:{
			uint32 res = m_owner->GetUInt32Value(PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE);
			uint32 res2 = m_owner->GetUInt32Value(UNIT_FIELD_RESISTANCES);
			m_owner->SetUInt32Value(UNIT_FIELD_RESISTANCES,res2 + ee->min);
			m_owner->SetUInt32Value(PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE,res + ee->min);
		}break;
	}

}
void Item::SaveToDB()
{
    std::stringstream ss;
    ss << "DELETE FROM item_instances WHERE guid = " << GetGUIDLow();
    sDatabase.Execute( ss.str( ).c_str( ) );

    ss.rdbuf()->str("");
    ss << "INSERT INTO item_instances (guid, data) VALUES ("
        << GetGUIDLow() << ", '"; // TODO: use full guids

    for(uint16 i = 0; i < m_valuesCount; i++ )
        ss << GetUInt32Value(i) << " ";

    ss << "' )";

    sDatabase.Execute( ss.str().c_str() );
}


bool Item::LoadFromDB(uint32 guid, uint32 auctioncheck)
{
	std::stringstream ss;
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
	if(result==NULL)
	return FALSE;
//	ASSERT(result);

	Field *fields = result->Fetch();

	LoadValues( fields[0].GetString() );

	delete result;

	m_itemProto = objmgr.GetItemPrototype( GetUInt32Value(OBJECT_FIELD_ENTRY) );
    if(m_itemProto)
    {
	    if (GetUInt32Value(ITEM_FIELD_ENCHANTMENT) != 0)
	    {
		    SetEnchanted(GetUInt32Value(ITEM_FIELD_ENCHANTMENT));
	    }
    }
    else return false;

	//ASSERT(m_itemProto);

	return TRUE;
}

void Item::DeleteFromDB()
{
    std::stringstream ss;
    ss << "DELETE FROM item_instances WHERE guid = " << GetGUIDLow();
    sDatabase.Execute( ss.str( ).c_str( ) );
}
