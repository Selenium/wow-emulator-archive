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

#include "../Shared/PacketBuilder.h"

//-----------------------------------------------------------------------------
void WorldSession::HandleUseItemOpcode(WorldPacket& recvPacket)
{
    Player* p_User = GetPlayer();
    Log::getSingleton( ).outDetail("WORLD: got use Item packet, data length = %i\n",recvPacket.size());
    uint8 tmp1,slot,tmp3;
    uint32 spellId;

    recvPacket >> tmp1 >> slot >> tmp3;

    Item* tmpItem = new Item;
    tmpItem = p_User->GetItemBySlot(slot);
    ItemPrototype *itemProto = tmpItem->GetProto();
    spellId = itemProto->SpellId[0];

    // Check for Spell ID
    SpellEntry *spellInfo = sSpellStore.LookupEntry( spellId );
    if(!spellInfo)
    {
        Log::getSingleton( ).outError("WORLD: unknown spell id %i\n", spellId);
        return;
    }
	
	// Check for Player's Stand State (activate if seated only)
	switch (p_User->GetStandState())
	{
	case STANDSTATE_STAND:
	case STANDSTATE_SLEEP:
	case STANDSTATE_KNEEL:
		// need to add normal Error Code
		//SystemMessage("You must be seated when using this item !");
		GetPlayer()->SetStandState (STANDSTATE_SIT);
		break;
		//return;
	case STANDSTATE_DEAD:
		WorldPacket data;
		Make_INVENTORY_CHANGE_FAILURE (&data, EQUIP_ERR_YOU_ARE_DEAD, tmpItem, tmpItem);
		SendPacket( &data );
		return;
	}
	//------------------------------

	// Check if Player is skilled enough to use Item
	if (!p_User->CanUseItem(itemProto)) return;
	//------------------------------

	// Check if Player is in Combat
	if (p_User->isInCombat()) {
		// Check if used allowed Item class
		if (itemProto->Class == ITEM_CLASS_CONSUMABLE	|| 
			itemProto->Class == ITEM_CLASS_TRADE_GOODS	||
			itemProto->Class == ITEM_CLASS_RECIPE		||
			itemProto->Class == ITEM_CLASS_KEY			||
			itemProto->Class == ITEM_CLASS_MISC			){

			WorldPacket data;
			Make_INVENTORY_CHANGE_FAILURE (&data, EQUIP_ERR_CANT_DO_IN_COMBAT, tmpItem, tmpItem);
			SendPacket( &data );
			return;
		}
	}
	//------------------------------

	// Activate Spell
    Spell *spell = new Spell(GetPlayer(), spellInfo,false, 0);
    WPAssert(spell);

	SpellCastTargets targets;
    targets.read(&recvPacket,GetPlayer()->GetGUID());
    spell->m_CastItem = tmpItem;
    spell->prepare(&targets);
	//------------------------------

	// Decrease item count in Inventory or destroy item if Item count = 1 before use
	uint32 ItemCount = tmpItem->GetCount();
	uint32 ItemClass = itemProto->Class;
	uint32 ItemId    = itemProto->ItemId;

	if (ItemClass == ITEM_CLASS_CONSUMABLE) {
		if (ItemCount > 1) {
			tmpItem->SetCount(ItemCount-1);
		}
		else {
			p_User->RemoveItemFromSlot(slot);
			// We do not remove Action Button if consumable Item is ended (patch 1.7.1 >> )
			//if (p_User->GetActionButtonID(ItemId) != 0) {
			//	p_User->m_actionsButtons[p_User->GetActionButtonID(ItemId)] = 0;
			//}
		}
	}
	//------------------------------

}

//-----------------------------------------------------------------------------
void WorldSession::HandleCastSpellOpcode(WorldPacket& recvPacket)
{
    uint32 spellId;

    recvPacket >> spellId;

    Log::getSingleton( ).outDetail("WORLD: got cast spell packet, spellId - %i, data length = %i\n",
        spellId, recvPacket.size());

    // check for spell id
    SpellEntry *spellInfo = sSpellStore.LookupEntry(spellId );
	//SpellLookupTable::iterator	&si = spell_defs.find (spellId);

    if(!spellInfo)
	//if (si == spell_defs.end())
    {
        Log::getSingleton( ).outError("WORLD: unknown spell id %i\n", spellId);
        return;
    }

	//SpellEntry *spellInfo = (*si).second;

	Spell *spell = new Spell(GetPlayer(), spellInfo, false, 0);
    WPAssert(spell);

    SpellCastTargets targets;
    targets.read(&recvPacket,GetPlayer()->GetGUID());

    spell->prepare(&targets);
}

//-----------------------------------------------------------------------------
void WorldSession::HandleCancelCastOpcode(WorldPacket& recvPacket){
    uint32 spellId;
    recvPacket >> spellId;

    if(GetPlayer()->m_currentSpell)
        GetPlayer()->m_currentSpell->cancel();
}

//-----------------------------------------------------------------------------
void WorldSession::HandleCancelChannellingOpcode(WorldPacket& recvPacket){
	Log::getSingleton().outDebug("CancelChannelling called!");
	uint32 spellId;
    recvPacket >> spellId;
	Log::getSingleton().outDebug("CancelChannelling recieved! length:%u , info1:%u", recvPacket.size(), spellId);

	SpellEntry *spellInfo = sSpellStore.LookupEntry( spellId );
	if (!spellInfo)
		return;
	for(int i = 0; i < 3; i++)
	{
		if(spellInfo->Effect[i] == EFFECT_PERSISTENT_AREA_AURA)
		{
			if(spellId == GetPlayer()->GetUInt32Value(UNIT_CHANNEL_SPELL))
			{
				DynamicObject* dynObj = objmgr.GetObject<DynamicObject>(GetPlayer()->GetUInt64Value(UNIT_FIELD_CHANNEL_OBJECT));
				if(dynObj)
				{
					dynObj->RemoveFromMap();
					objmgr.RemoveObject_Free(dynObj);
				}
				else
				{
					Log::getSingleton().outError("Dynamic Spellobject could not be found!");
				}
			}
		}
	}
}

//-----------------------------------------------------------------------------
void WorldSession::HandleCancelAuraOpcode( WorldPacket& recvPacket){
    uint32 spellId;
    recvPacket >> spellId;
    GetPlayer()->RemoveAffectById(spellId);
}

//-----------------------------------------------------------------------------
void WorldSession::HandleCancelAutorepeatSpellOpcode(WorldPacket& recvPacket){

	Log::getSingleton().outDebug("WORLD: CMSG_CANCEL_AUTO_REPEAT_SPELL");

    if(GetPlayer()->m_currentSpell)	GetPlayer()->m_currentSpell->cancel();
}
