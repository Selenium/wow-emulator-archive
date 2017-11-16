#include "StdAfx.h"

#include "Item.h"
#include "../Shared/PacketBuilder.h"

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

//-----------------------------------------------------------------------------
void WorldSession::HandleSwapInvItemOpcode( WorldPacket & recv_data )
{
    WorldPacket data;

    uint8 srcslot, dstslot;

    recv_data >> srcslot >> dstslot;

    //Log::getSingleton().outDetail("ITEM: swap, src slot: %u dst slot: %u", (uint32)srcslot, (uint32)dstslot);
	Log::getSingleton().outDetail("WORLD: CMSG_SWAP_INV_ITEM");

    Item * dstitem = GetPlayer()->GetItemBySlot (dstslot);
    Item * srcitem = GetPlayer()->GetItemBySlot (srcslot);
	Player * player = GetPlayer();

	if (player->isDead()) {
		Make_INVENTORY_CHANGE_FAILURE (&data, EQUIP_ERR_YOU_ARE_DEAD, srcitem, dstitem);
		//GetPlayer()->GetSession()->SystemMessage ("Inventory: (Swap.Op) EQUIP_ERR_YOU_ARE_DEAD");
		SendPacket( &data );
		return;
	}

    // error
    if (srcslot == dstslot)
    {
		Make_INVENTORY_CHANGE_FAILURE (&data, EQUIP_ERR_ITEMS_CANT_BE_SWAPPED, srcitem, dstitem);
     	//GetPlayer()->GetSession()->SystemMessage ("Inventory: (Swap.Op) EQUIP_ERR_ITEMS_CANT_BE_SWAPPED");
		SendPacket( &data );
        return;
    }

    // swap items
    GetPlayer()->SwapItemSlots(srcslot, dstslot);

//    GetPlayer( )->BuildUpdateObjectMsg( &data, &updateMask );
//    GetPlayer( )->SendMessageToSet( &data, false );
}

//-----------------------------------------------------------------------------
void WorldSession::HandleDestroyItemOpcode( WorldPacket & recv_data )
{
    WorldPacket data;

    uint8 srcslot, dstslot;

    recv_data >> srcslot >> dstslot;

	Log::getSingleton().outDetail("ack > INVENTORY: ITEM: DESTROY >> SLOTS SRC[%u] DST[%u]", (uint32)srcslot, (uint32)dstslot);

    Item *item = GetPlayer()->GetItemBySlot(dstslot);

    if(!item)
    {
        Log::getSingleton().outDetail("err > INVENTORY: ITEM: CAN'T DESTROY! ITEM DOES NOT EXIST!");
        return;
    }

    GetPlayer()->RemoveItemFromSlot(dstslot);

    item->DeleteFromDB();

    delete item;
}

//-----------------------------------------------------------------------------
void WorldSession::HandleAutoEquipItemOpcode( WorldPacket & recv_data )
{
    WorldPacket data;

    uint8 srcslot, dstslot;

    recv_data >> srcslot >> dstslot;

    Log::getSingleton().outDetail("ITEM: autoequip, src slot: %u dst slot: %u", (uint32)srcslot, (uint32)dstslot);

    Item *item = GetPlayer()->GetItemBySlot(dstslot);
    if(!item)
    {
        Log::getSingleton().outDetail("ITEM: tried to equip non-existant item");
		//GetPlayer()->GetSession()->SystemMessage ("Inventory: (AutoEquip.Op) EQUIP_ERR_ITEM_NOT_FOUND");
		Make_INVENTORY_CHANGE_FAILURE (&data, EQUIP_ERR_ITEM_NOT_FOUND);
		SendPacket( &data );

        return;
    }

    uint8 slot = GetPlayer()->FindFreeItemSlot(item->GetProto()->InventoryType);

    if (slot == INVENTORY_SLOT_ITEM_END)
    {
        data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
        data << uint8(EQUIP_ERR_ITEM_DOESNT_GO_TO_SLOT);
        data << item->GetGUID();
        data << uint64(0);
        data << uint8(0);
        WPAssert(data.size() == 18);
        SendPacket( &data );
        return;
    }

    GetPlayer()->SwapItemSlots(dstslot, slot);
}

//-----------------------------------------------------------------------------
void WorldSession::HandleItemQuerySingleOpcode( WorldPacket & recv_data )
{
    WorldPacket data;

    int i;
    uint32 itemid, guidlow, guidhigh;
    recv_data >> itemid >> guidlow >> guidhigh; // guid is the guid of the ITEM OWNER - NO ITS NOT

    Log::getSingleton( ).outDetail( "WORLD: CMSG_ITEM_QUERY_SINGLE for item id 0x%.8X, guid 0x%.8X 0x%.8X",
        itemid, guidlow, guidhigh );

    ItemPrototype *itemProto = objmgr.GetItemPrototype(itemid);
    if(!itemProto)
    {
        Log::getSingleton( ).outError( "WORLD: Unknown item id 0x%.8X", itemid );
        return;
    }

    data.Initialize( SMSG_ITEM_QUERY_SINGLE_RESPONSE );

    data << itemProto->ItemId;
    data << itemProto->Class;
    data << itemProto->SubClass;
    data << itemProto->Name1;
	data << itemProto->Name2;
	data << itemProto->Name3;
	data << itemProto->Name4;
    data << itemProto->DisplayInfoID;
    data << itemProto->Quality;
    data << itemProto->Flags;
    data << itemProto->BuyPrice;
    data << itemProto->SellPrice;
    data << itemProto->InventoryType;
    data << itemProto->AllowableClass;
    data << itemProto->AllowableRace;
    data << itemProto->ItemLevel;
    data << itemProto->RequiredLevel;
    data << itemProto->RequiredSkill;
    data << itemProto->RequiredSkillRank;
    data << itemProto->RequiredSpell;
    data << itemProto->RequiredFaction;
    data << itemProto->RequiredFactionLvL;
    data << itemProto->RequiredPVPRank;

	data << itemProto->FieldNew_17_1;
	data << itemProto->FieldNew_17_2;

    data << itemProto->MaxCount;
    data << itemProto->ContainerSlots;

    for(i = 0; i < 10; i++) {
        data << itemProto->ItemStatType[i];
        data << uint32(itemProto->ItemStatValue[i]);
    }

    for(i = 0; i < 5; i++) {
        data << itemProto->DamageMin[i];
        data << itemProto->DamageMax[i];
        data << itemProto->DamageType[i];
    }

    data << itemProto->Armor;
    data << itemProto->HolyRes;
    data << itemProto->FireRes;
    data << itemProto->NatureRes;
    data << itemProto->FrostRes;
    data << itemProto->ShadowRes;
    data << itemProto->ArcaneRes;
    data << itemProto->Delay;
    data << itemProto->Block;
    for(i = 0; i < 5; i++) {
        data << itemProto->SpellId[i];
        data << itemProto->SpellTrigger[i];
        data << itemProto->SpellCharges[i];
        data << itemProto->SpellCooldown[i];
        data << itemProto->SpellCategory[i];
        data << itemProto->SpellCategoryCooldown[i];
    }
    data << itemProto->Bonding;
    data << itemProto->Description;

  //data << itemProto->RandPropID;   // <PavkaM>
    data << itemProto->PageTextID;	 
    data << itemProto->PageLanguage; 
    data << itemProto->PageMaterial; 
	data << itemProto->StartQuest;   // <PavkaM>
    data << itemProto->LockId;		 
    data << itemProto->LockMaterial; 
	data << itemProto->Sheath;       // <PavkaM>
    data << itemProto->Field108;
    data << itemProto->Field109;
    data << itemProto->Field110;
    data << itemProto->MaxDurability;
    data << itemProto->Field111;


   // WPAssert(data.size() == 433+8 + itemProto->Name1.length() + itemProto->Description.length());
    SendPacket( &data );
}

//-----------------------------------------------------------------------------
void WorldSession::HandleSellItemOpcode( WorldPacket & recv_data )
{
    Log::getSingleton( ).outDetail( "WORLD: CMSG_SELL_ITEM" );

    WorldPacket data;
    uint64 vendorguid, itemguid;
    uint8 amount;
    uint32 newmoney;
    int check = 0;

    recv_data >> vendorguid;
    recv_data >> itemguid;
    recv_data >> amount;

	Player * player = GetPlayer();

    // Check if item exists
    if (itemguid == 0)
    {
        data.Initialize( SMSG_SELL_ITEM );
        data << vendorguid << itemguid << uint8(0x01);
        WPAssert(data.size() == 17);
        SendPacket( &data );
        return;
    }


    Creature *unit = objmgr.GetObject<Creature>(vendorguid);
    // Check if Vendor exists
    if (unit == NULL)
    {
        data.Initialize( SMSG_SELL_ITEM );
        data << vendorguid << itemguid << uint8(0x03);
        WPAssert(data.size() == 17);
        SendPacket( &data );
        return;
    }

    
	uint8 slot = 0xFF; 
	Item *item;
	// Search the slot...
    for(uint8 i=0; i<39; i++)
    {
        item = player->GetItemBySlot(i);
        if (item != NULL) {
            if (item->GetGUID() == itemguid)
            {
                slot = i;
                break;
            }
        }
    }

    if (slot == 0xFF)
    {
        data.Initialize( SMSG_SELL_ITEM );
        data << vendorguid << itemguid << uint8(0x01);
        WPAssert(data.size() == 17);
        SendPacket( &data );
        return; //our player doesn't have this item
    }

	// Error Codes: 0x01 = Item not Found
	//              0x02 = Vendor doesnt want that item
	//              0x03 = Vendor doesnt like you ;P
	//              0x04 = You dont own that item
	//              0x05 = Ok
	//              0x06 = Only with empty Bags !? -- can sell only empty bag
	uint8 sell_result = 0x05;
	ItemPrototype * iProto = item->GetProto();

	if (iProto == NULL) {
		sell_result = 0x01;
	}
	else
	if (iProto->SellPrice == 0 || iProto->Class == 12) {
		// 0x02 = Vendor doesnt want that item
		sell_result = 0x02;
	}
	else
	{
		if (amount == 0) amount = 1; // ?!?
		newmoney = ((player->GetUInt32Value(PLAYER_FIELD_COINAGE)) + iProto->SellPrice * item->GetCount());//amount);
		player->SetUInt32Value( PLAYER_FIELD_COINAGE , newmoney);

		//removing the item from the char's inventory
		player->RemoveItemFromSlot(slot);

		uint64 bbSlotGuid = player->GetUInt64Value (PLAYER_FIELD_VENDORBUYBACK_SLOT_1);
		if (bbSlotGuid != 0) {
			Item *bbSlotItem = player->GetVendorBuybackSlot();
			if (bbSlotItem != NULL) {
				bbSlotItem->DeleteFromDB();
				delete bbSlotItem;
			}
		}
		player->SetVendorBuybackSlot (item, vendorguid);
	}

    data.Initialize( SMSG_SELL_ITEM );
    data << vendorguid << itemguid << sell_result;

    WPAssert(data.size() == 17);
    SendPacket( &data );

    Log::getSingleton( ).outDetail( "WORLD: Sent SMSG_SELL_ITEM" );
}

//-----------------------------------------------------------------------------
void WorldSession::HandleBuyItemInSlotOpcode( WorldPacket & recv_data ) // drag & drop
{
    Log::getSingleton( ).outDetail( "WORLD: Received CMSG_BUY_ITEM_IN_SLOT" );

    WorldPacket data;
    uint64 srcguid, dstguid;
    uint32 itemid;
    uint8 slot;
	uint32 amount = 1;
    int vendorslot = -1;
    int32 newmoney;

    recv_data >> srcguid >> itemid;
    recv_data >> dstguid; // ??
    recv_data >> slot;
	
	if (recv_data.rpos() + 4 < recv_data.size())
		recv_data >> amount;

    Creature *unit = objmgr.GetObject<Creature>(srcguid);
    if (unit == NULL) return;

    Player * player = GetPlayer();

    if (slot > 38) return;
	//if (slot < 19) return;

	//these are the bags slots...i'm not sure exactly how to use them
    if ((slot <= 22) && (slot >=19)) return;

	ItemPrototype * itemProto = objmgr.GetItemPrototype (itemid);

	// Check slot type
	if (!player->CheckSlotSuitable (slot, itemProto->InventoryType))
	{
		Make_INVENTORY_CHANGE_FAILURE (&data, EQUIP_ERR_ITEM_DOESNT_GO_TO_SLOT, 0, 0);
		SendPacket( &data );
		return;
	}

	// Check if item is usable
	if (IS_BODY_SLOT(slot) && !player->CanEquipItem(itemProto))
	{
		Make_INVENTORY_CHANGE_FAILURE (&data, EQUIP_ERR_ITEM_CANT_BE_EQUIPPED, 0, 0);
		SendPacket( &data );
		return;
	}

    // Check for gold
    newmoney = ((GetPlayer()->GetUInt32Value(PLAYER_FIELD_COINAGE)) - (objmgr.GetItemPrototype(itemid)->BuyPrice));
    if(newmoney < 0 )
    {
		Make_INVENTORY_CHANGE_FAILURE (&data, EQUIP_ERR_NOT_ENOUGH_MONEY, 0, 0);
		SendPacket( &data );
        return;
    }

	//if (itemProto->MaxCount > 0)
	amount *= itemProto->GetSellStackSize();

	/*Item *item = new Item();
    item->Create(objmgr.GenerateLowGuid(HIGHGUID_ITEM), itemid, GetPlayer());

    unit->setItemAmount( vendorslot, unit->getItemAmount(vendorslot)-amount );*/
	if (GetPlayer()->AddItemToSlot( slot, itemid, amount )) {
		GetPlayer()->SetUInt32Value (PLAYER_FIELD_COINAGE, newmoney);
		data.Initialize (SMSG_BUY_ITEM);
		data << uint64(srcguid);
		data << uint32(itemid) << uint32(amount);
		WPAssert(data.size() == 16);
		SendPacket( &data );
		Log::getSingleton( ).outDetail( "WORLD: Sent SMSG_BUY_ITEM" );
	}
	else
	{
		data.Initialize (SMSG_BUY_FAILED);
		data << uint64(srcguid);
		//WPAssert(data.size() == 16);
		SendPacket( &data );
		Log::getSingleton( ).outDetail( "WORLD: Sent SMSG_BUY_FAILED" );

		Make_INVENTORY_CHANGE_FAILURE (&data, EQUIP_ERR_ITEM_DOESNT_GO_TO_SLOT, 0, 0);
		SendPacket( &data );
		return;
	}
}


//-----------------------------------------------------------------------------
void WorldSession::HandleBuyItemOpcode( WorldPacket & recv_data ) // right-click on item
{
    Log::getSingleton( ).outDetail( "WORLD: Received CMSG_BUY_ITEM" );

    WorldPacket data;
    uint64 srcguid;
    uint32 itemid;
    uint8 amount;
	uint8 slot;
    uint8 playerslot = 0;
    int vendorslot = -1;

    recv_data >> srcguid >> itemid;
    recv_data >> amount >> slot;

    Creature *unit = objmgr.GetObject<Creature>(srcguid);
    if (unit == NULL)
        return;

    // Check for gold
	int32 price = objmgr.GetItemPrototype(itemid)->BuyPrice * amount;
	int32 newmoney = GetPlayer()->GetMoney() - price;

    if(newmoney < 0 )
    {
		Make_INVENTORY_CHANGE_FAILURE (&data, EQUIP_ERR_NOT_ENOUGH_MONEY, 0, 0);
        SendPacket( &data );
        return;
    }

    // unit->setItemAmount( vendorslot, unit->getItemAmount(vendorslot)-amount ); // Unlimited Items
	ItemPrototype * iproto = objmgr.GetItemPrototype (itemid);
	//if (iproto->MaxCount > 0)
	amount *= iproto->GetSellStackSize();

	if (GetPlayer()->AddItemToBackpack (itemid, amount)) {
		GetPlayer()->SetMoney (newmoney);
		data.Initialize( SMSG_BUY_ITEM );
		data << uint64(srcguid);
		data << uint32(itemid) << uint32(amount);
		WPAssert(data.size() == 16);
		SendPacket( &data );
		Log::getSingleton( ).outDetail( "WORLD: Sent SMSG_BUY_ITEM" );
	}
	else
	{
		/*data.Initialize (SMSG_BUY_FAILED);
		data << uint64(srcguid);
		//WPAssert(data.size() == 16);
		SendPacket( &data );*/
		Log::getSingleton( ).outDetail( "WORLD: Sent SMSG_BUY_FAILED - Inventory full" );

		Make_INVENTORY_CHANGE_FAILURE (&data, EQUIP_ERR_INVENTORY_FULL, 0, 0);
		SendPacket( &data );
	}
}
//-----------------------------------------------------------------------------
void WorldSession::HandleBuybackItemOpcode( WorldPacket & recv_data ) // click vendor buyback target
{
/* Something is changed in 1.8.0

	Log::getSingleton( ).outDetail( "WORLD: Received CMSG_BUYBACK_ITEM" );

	WorldPacket data;
	uint64 vendorguid;

	recv_data >> vendorguid;

	// Scan for empty slot
	uint8 playerslot = 0;
	Item * pItem;
	Player * player = GetPlayer();

	// First search through backpack, then through bags
	for (uint8 i = INVENTORY_SLOT_ITEM_START; i < INVENTORY_SLOT_ITEM_END; i++) 
	{
		pItem = player->GetItemBySlot(i);
		if (pItem == NULL)
		{
			playerslot = i;
			break;
		}
	}

	if (playerslot == 0) {
		Make_INVENTORY_CHANGE_FAILURE (&data, EQUIP_ERR_INVENTORY_FULL, 0, 0);
		SendPacket( &data );
		Log::getSingleton( ).outDetail( "WORLD: Sent SMSG_BUY_FAILED - Inventory full" );
	}

	// Check for gold
	pItem = player->m_vendorBuybackSlot;
	
	uint32 price = player->GetUInt32Value (PLAYER_FIELD_BUYBACK_PRICE);
	uint32 amount = player->GetUInt32Value (PLAYER_FIELD_BUYBACK_COUNT);
	int32 newmoney = player->GetUInt32Value (PLAYER_FIELD_COINAGE) - price;

	if(newmoney < 0 )
	{
		Make_INVENTORY_CHANGE_FAILURE (&data, EQUIP_ERR_NOT_ENOUGH_MONEY, 0, 0);
		SendPacket( &data );
		return;
	}
	player->SetUInt32Value (PLAYER_FIELD_COINAGE, newmoney);

	player->m_items[playerslot] = NULL;
	player->AddItemToSlot (playerslot, pItem);
	//player->SetUInt64Value ((uint16)(PLAYER_FIELD_INV_SLOT_HEAD  + (playerslot*2)), pItem->GetGUID());
	player->SetVendorBuybackSlot (NULL, 0);

	data.Initialize( SMSG_BUY_ITEM );
	data << uint64(vendorguid);
	data << uint32(pItem->GetEntry()) << uint32(pItem->GetCount());
	WPAssert(data.size() == 16);
	SendPacket( &data );
	Log::getSingleton( ).outDetail( "WORLD: Sent SMSG_BUY_ITEM - buyback successful" );
	*/
}

//-----------------------------------------------------------------------------
void WorldSession::HandleListInventoryOpcode( WorldPacket & recv_data )
{
    Log::getSingleton( ).outDetail( "WORLD: Recvd CMSG_LIST_INVENTORY" );

    uint64 guid;
    recv_data >> guid;

	QuestPacketHandler::getSingleton().SendVendorList( this, guid );
}

//-----------------------------------------------------------------------------------------
void WorldSession::HandleSetSheathed( WorldPacket & recv_data )
{
	Log::getSingleton( ).outDebug( "WORLD: CMSG_SETSHEATHED" );
 
	uint32 sheath_type;

	WorldPacket data;
    recv_data >> sheath_type;

	GetPlayer()->ModifySheath (sheath_type);
}

//-----------------------------------------------------------------------------------------
void WorldSession::HandleReadItem( WorldPacket & recv_data )
{
	uint8 slot, uslot;

	WorldPacket data;

    recv_data >> uslot >> slot;

	Log::getSingleton( ).outDebug( "WORLD: CMSG_READ_ITEM");
	Item *pItem = GetPlayer()->GetItemBySlot( slot );
	
	if (pItem)
		if (pItem->GetProto()->PageTextID)
		{
			if ( GetPlayer()->isInCombat() ||
				 GetPlayer()->isDead() )
			{
				data.Initialize( SMSG_READ_ITEM_FAILED );
				data << pItem->GetGUID();

				SendPacket( &data );
				Log::getSingleton( ).outDetail( "WORLD: Sent SMSG_READ_ITEM_FAILED" );
			} else
			{
				data.Initialize( SMSG_READ_ITEM_OK );
				data << pItem->GetGUID();

				SendPacket( &data );
				Log::getSingleton( ).outDetail( "WORLD: Sent SMSG_READ_ITEM_OK" );
			}
		}
}
//-----------------------------------------------------------------------------------------
void WorldSession::HandleSwapItem( WorldPacket & recv_data )
{
	Log::getSingleton( ).outDebug( "WORLD: CMSG_SWAP_ITEM");
	/*
		0:01:54 - CLIENT >>> OpCode=0x10C CMSG_SWAP_ITEM, size=10

		0- 1- 2- 3- 4- 5- 6- 7- | 8- 9- A- B- C- D- E- F- | 01234567 89ABCDEF
	0000: 00#08#0C#01#00#00 FF 1A | 13 00                   | ........ ..  
	*/

	WorldPacket data;

	uint8 dstslot, srcslot, dstflag, srcflag;

    recv_data >> dstslot >> dstflag >> srcflag >> srcslot ;

	Log::getSingleton().outDebug("ack > INVENTORY: SWAP: SLOTS -> SRC: %d Flag-%d DST: %d Flag-%d", srcslot, srcflag, dstslot, dstflag);

	//Item * dstitem = GetPlayer()->GetItemBySlot (dstslot);
    //Item * srcitem = GetPlayer()->GetItemBySlot (srcslot);
	Player * player = GetPlayer();

	// Adding Item from Bag to BagPack
	if (!IS_BAG_SLOT(dstslot) && IS_BAG_SLOT(srcslot)) {
        
		Log::getSingleton().outDebug("ack > INVENTORY: BAG >> ITEM >> BAGPACK");

		//dstitem->SetUInt64Value( ITEM_FIELD_CONTAINED, player->GetGUID() );

		//dstitem->SetUInt64Value( CONTAINER_FIELD_SLOT_1 + srcsflag, 0 );
		
		//GetPlayer()->AddItemToSlot(dstslot, dstitem);
	}
	
	// Adding Item from BagPack to Bag
	if (IS_BAG_SLOT(dstslot) && !IS_BAG_SLOT(srcslot)) {

		//Container * dstitem = (Container *)GetPlayer()->GetItemBySlot (dstslot);

		Container * dstitem = GetPlayer()->GetContainerBySlot (dstslot);
		Item * srcitem = GetPlayer()->GetItemBySlot (srcslot);

		Log::getSingleton().outDebug("ack > INVENTORY: BAGPACK >> ITEM [%d] >> BAG [%d] SLOT[%d] ", srcitem->GetEntry(), dstitem->GetEntry(), dstflag );

		//srcitem->SetUInt64Value( ITEM_FIELD_CONTAINED, dstitem->GetGUID() );
		
		GetPlayer()->RemoveItemFromSlot(srcslot);
		
		dstitem->AddItemToContainer(dstflag, srcitem);

	}

}

//-----------------------------------------------------------------------------------------
void WorldSession::HandleAutostoreBagItem( WorldPacket & recv_data )
{
	Log::getSingleton( ).outDebug( "WORLD: CMSG_AUTOSTORE_BAG_ITEM");
	/*
		0:02:03 - CLIENT >>> OpCode=0x10B CMSG_AUTOSTORE_BAG_ITEM, size=9

		0- 1- 2- 3- 4- 5- 6- 7- | 8- 9- A- B- C- D- E- F- | 01234567 89ABCDEF
	0000: 00#07#0B#01#00#00 FF 1A | 13                      | ........ . 
	*/
	
	WorldPacket data;

    uint8 unk1, srcslot, dstslot;

    recv_data >> unk1 >> srcslot >> dstslot;

	Log::getSingleton().outDetail("ack > INVENTORY: AUTOSTORE ITEM: SLOTS -> SRC: %d DST: %d UNK: %d", srcslot, dstslot, unk1 );

}

//--- END ---