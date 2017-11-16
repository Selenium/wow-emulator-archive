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
#include "WorldPacket.h"
#include "WorldSession.h"
#include "World.h"
#include "Opcodes.h"
#include "Log.h"
#include "ObjectMgr.h"
#include "Player.h"
#include "Chat.h"
#include "Item.h"
#include "UpdateData.h"
void WorldSession::HandleSplitOpcode(WorldPacket& recv_data)
{
	uint8 DstInvSlot, DstSlot, SrcInvSlot, SrcSlot, count;
	recv_data >> SrcInvSlot >> SrcSlot >> DstInvSlot >> DstSlot >> count;
	Player *pl = this->GetPlayer();
	Item *i1 = NULL;
	Item *i2 = NULL;
	if (pl->GetItemBySlot(SrcInvSlot))
	{
		i1 = pl->GetItemBySlot(SrcInvSlot);
		if (i1->pContainer->GetItem(SrcSlot))
		{
			i1 = i1->pContainer->GetItem(SrcSlot);
		} else
		{
			i1 = NULL;
		}
	} else if (pl->GetItemBySlot(SrcSlot))
	{
		i1 = pl->GetItemBySlot(SrcSlot);
	}
	if (pl->GetItemBySlot(DstInvSlot))
	{
		i2 = pl->GetItemBySlot(DstInvSlot);
		if(i2->pContainer->GetItem(DstSlot))
		{
			i2 = i2->pContainer->GetItem(DstSlot);
			if (i2->GetProto()->ItemId == i1->GetProto()->ItemId)
			{
				i1->SetUInt32Value(ITEM_FIELD_STACK_COUNT,i1->GetUInt32Value(ITEM_FIELD_STACK_COUNT) - count);
			}
			else
			{
				//error!
			}
		} else
		{
			Item *nItem = new Item();
			nItem->Create(objmgr.GenerateLowGuid(HIGHGUID_ITEM),i1->GetProto()->ItemId,pl);
			nItem->SetUInt32Value(ITEM_FIELD_STACK_COUNT,count);
			i2->pContainer->AddItem(DstSlot,nItem);
			i1->SetUInt32Value(ITEM_FIELD_STACK_COUNT,i1->GetUInt32Value(ITEM_FIELD_STACK_COUNT) - count);
		}
	}
	else if (pl->GetItemBySlot(DstSlot))
	{
		i2 = pl->GetItemBySlot(DstSlot);
		if (i2->GetProto()->ItemId == i1->GetProto()->ItemId)
		{
			i1->SetUInt32Value(ITEM_FIELD_STACK_COUNT,i1->GetUInt32Value(ITEM_FIELD_STACK_COUNT) - count);
		}
		else
		{
			//error!
		}
	}
	else
	{
		Item *nItem = new Item();
		nItem->Create(objmgr.GenerateLowGuid(HIGHGUID_ITEM),i1->GetProto()->ItemId,pl);
		nItem->SetUInt32Value(ITEM_FIELD_STACK_COUNT,count);
		pl->AddItemToSlot(DstSlot,nItem);
		i1->SetUInt32Value(ITEM_FIELD_STACK_COUNT,i1->GetUInt32Value(ITEM_FIELD_STACK_COUNT) - count);
	}

}
void WorldSession::HandleSwapItemOpcode(WorldPacket& recv_data)
{
	WorldPacket data;
	UpdateData upd;
	WorldPacket packet;
	Item *SrcItem;
	Item *DstItem;
	Item *SrcTemp = NULL;
	Item *DstTemp = NULL;
	uint8 DstInvSlot, DstSlot, SrcInvSlot, SrcSlot, error;
	//     20           5            255      26

	recv_data >> DstInvSlot >> DstSlot >> SrcInvSlot >> SrcSlot;

	Log::getSingleton().outDetail("ITEM: swap, DstInvSlot %u DstSlot %u SrcInvSlot %u SrcSlot %u\n", (uint32)DstInvSlot, (uint32)DstSlot, (uint32)SrcInvSlot, (uint32)SrcSlot);

	//Bag to Bag swaping
	//bag to inventory swaping
	if(SrcInvSlot >= INVENTORY_SLOT_BAG_START && SrcInvSlot < INVENTORY_SLOT_BAG_END)
	{
		SrcItem = GetPlayer()->GetItemBySlot(SrcInvSlot); //should be true always

		if(SrcItem->GetProto()->InventoryType == INVTYPE_BAG)
		{
			SrcTemp = SrcItem->pContainer->GetItem(SrcSlot); //get item from bag
		}

		//dst is a bag
		if(DstInvSlot >= INVENTORY_SLOT_BAG_START && DstInvSlot < INVENTORY_SLOT_BAG_END)
		{
			DstItem = GetPlayer()->GetItemBySlot(DstInvSlot);

			//both are bags, Case: Bag is the same
			if(DstInvSlot == SrcInvSlot)
			{
				SrcItem->pContainer->SwapItems(SrcSlot,DstSlot);
			}
			//Both are bags, Case: bags are diferent
			if(DstInvSlot != SrcInvSlot)
			{
				Item* item1 = SrcItem->pContainer->RemoveItemFromSlot(SrcSlot);
				Item* item2 = DstItem->pContainer->RemoveItemFromSlot(DstSlot);

				if(item2) { SrcItem->pContainer->AddItem(SrcSlot,item2); } //dst item added to the src container
				if(item1) { DstItem->pContainer->AddItem(DstSlot,item1); } //source item added to the dst container
			}
		}
		//dst is inventory, equipable or backpack+, since bags are handled already
		if(DstInvSlot < INVENTORY_SLOT_BAG_START || DstInvSlot >= INVENTORY_SLOT_BAG_END)
		{
			Item *BagItem;
			BagItem = SrcItem->pContainer->GetItem(SrcSlot);
            if(!BagItem)
            {
                GetPlayer()->BuildInventoryChangeError(NULL, NULL, INV_ERR_SLOT_IS_EMPTY);
                return;
            }

			//ERROR HANDLING
			if(error=GetPlayer()->CanEquipItemInSlot(DstSlot, BagItem->GetProto()))
			{
				if(DstSlot <= INVENTORY_SLOT_BAG_END)
				{
					GetPlayer()->BuildInventoryChangeError(BagItem, DstItem, error);
					/*
					data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
					data << error;
					if(error == 1) 
					{
						data << BagItem->GetProto()->RequiredLevel;
					}
					data << (BagItem ? BagItem->GetGUID() : uint64(0));
					data << (DstItem ? DstItem->GetGUID() : uint64(0));
					data << uint8(0);

					SendPacket( &data );
					*/
					return;
				}
			}
			else if(BagItem->GetProto()->InventoryType == INVTYPE_BAG && DstSlot >= INVENTORY_SLOT_BAG_START && DstSlot < INVENTORY_SLOT_BAG_END)
			{
                DstItem = GetPlayer()->GetItemBySlot(DstSlot);
				if(DstItem)
				{
					if(DstItem->pContainer)
					{
						if(DstItem->pContainer->HasItems())
						{
							GetPlayer()->BuildInventoryChangeError(BagItem, DstItem, INV_ERR_NONEMPTY_BAG_OVER_OTHER_BAG);
							/*
							data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
							data << uint8(BAG_IN_BAG);
							data << (BagItem->pContainer ? BagItem->pContainer->GetGUID() : uint64(0));
							data << (DstItem->pContainer ? DstItem->pContainer->GetGUID() : uint64(0));
							data << uint8(0);

							SendPacket( &data );
							*/
							return;
						}
					}
				}		
			}
			//END OF ERROR HANDLING

			//remove existing items.
			Item* item1 = SrcItem->pContainer->RemoveItemFromSlot(SrcSlot);
			Item* item2 = GetPlayer()->RemoveItemFromSlot(DstSlot); 

			if(item1)
			{
				GetPlayer()->AddItemToSlot(DstSlot, item1);
			}

			if(item2)
			{
				SrcItem->pContainer->AddItem(SrcSlot, item2);
			}
		}
	}

	//Inventory to Bag
	if(SrcInvSlot < EQUIPMENT_SLOT_END || SrcInvSlot >= INVENTORY_SLOT_BAG_END)
	{
		SrcItem =  GetPlayer()->GetItemBySlot(SrcSlot);

		//Case: Destiny is a Bag
		if(DstInvSlot >= INVENTORY_SLOT_BAG_START && DstInvSlot < INVENTORY_SLOT_BAG_END)
		{
			DstItem = GetPlayer()->GetItemBySlot(DstInvSlot);

			if(DstItem)
			{
				DstTemp = DstItem->pContainer->GetItem(DstSlot);
			}
			//ERROR HANDLING
			if(SrcItem->GetProto()->InventoryType == INVTYPE_BAG)
			{
				if(SrcItem->pContainer)
				{
					//check if the source have items(its a bag ofc)
					if(SrcItem->pContainer->HasItems())
					{
						data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
						data << uint8(INV_ERR_NONEMPTY_BAG_OVER_OTHER_BAG);
						data << (SrcItem->pContainer ? SrcItem->pContainer->GetGUID() : uint64(0));
						if(DstTemp)
						{
							if(DstTemp->GetProto()->InventoryType == INVTYPE_BAG)
							{
								data << (DstTemp->pContainer ? DstTemp->pContainer->GetGUID() : uint64(0));
							}
							else
							{
								data << (DstTemp ? DstTemp->GetGUID() : uint64(0));
							}
						}
						else
						{
							data << (DstTemp ? DstTemp->GetGUID() : uint64(0));
						}
						data << uint8(0);

						SendPacket( &data );
						return;
					}
				}
				if(DstTemp)
				{
					//Item in the destiny bag is not a bag, swap impossible
					if(DstTemp->GetProto()->InventoryType == INVTYPE_BAG)
					{

					}
					else
					{
						data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
						data << uint8(INV_ERR_NOT_A_BAG);
						data << (SrcItem->pContainer ? SrcItem->pContainer->GetGUID() : uint64(0));
						data << (DstTemp ? DstTemp->GetGUID() : uint64(0));
						data << uint8(0);

						SendPacket( &data );
						return;
					}
				}
			}

			SrcItem = NULL;
			SrcItem = GetPlayer()->RemoveItemFromSlot(SrcSlot); //remove item from inventory

			//swaping items
			if(DstTemp) //dst bag slot contains a item, add it to the inv
			{
				Item* item2 = DstItem->pContainer->RemoveItemFromSlot(DstSlot);
				GetPlayer()->AddItemToSlot(SrcSlot,item2); //add bag item to inventory
			}

			DstItem->pContainer->AddItem(DstSlot,SrcItem); //src to dst
		}
	}
}

void WorldSession::HandleSwapInvItemOpcode( WorldPacket & recv_data )
{
	WorldPacket data;
	UpdateData upd;
	uint8 srcslot, dstslot;
	uint8 error;

	recv_data >> srcslot >> dstslot;

	Log::getSingleton().outDetail("ITEM: swap, src slot: %u dst slot: %u", (uint32)srcslot, (uint32)dstslot);

	Item * dstitem = GetPlayer()->GetItemBySlot(dstslot);
	Item * srcitem = GetPlayer()->GetItemBySlot(srcslot);

	if (!srcitem)
	{
		data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
		data << uint8(INV_ERR_YOU_CAN_NEVER_USE_THAT_ITEM);
		data << (srcitem ? srcitem->GetGUID() : uint64(0));
		data << (dstitem ? dstitem->GetGUID() : uint64(0));
		data << uint8(0);

		SendPacket( &data );
		return;
	}
	if(error=GetPlayer()->CanEquipItemInSlot(dstslot, srcitem->GetProto()))
	{
		if(dstslot < INVENTORY_SLOT_BAG_END)
		{
			data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
			data << error;
			if(error == 1) 
			{
				data << srcitem->GetProto()->RequiredLevel;
			}
			data << (srcitem ? srcitem->GetGUID() : uint64(0));
			data << (dstitem ? dstitem->GetGUID() : uint64(0));
			data << uint8(0);

			SendPacket( &data );
			return;
		}
	}
	if(srcitem->GetProto()->InventoryType == INVTYPE_BAG)
	{
		//source has items and dst is a backpack
		if(srcitem->pContainer->HasItems() && dstslot >= INVENTORY_SLOT_BAG_END)
		{
			data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
			data << uint8(INV_ERR_NONEMPTY_BAG_OVER_OTHER_BAG);
			data << (srcitem->pContainer ? srcitem->pContainer->GetGUID() : uint64(0));
			if(dstitem)
			{
				if(dstitem->GetProto()->InventoryType == INVTYPE_BAG)
				{
					data << (dstitem->pContainer ? dstitem->pContainer->GetGUID() : uint64(0));
				}
				else
				{
					data << (dstitem ? dstitem->GetGUID() : uint64(0));
				}
				data << uint8(0);

				SendPacket( &data );
				return;
			}

			if(dstitem)
			{
				//source is a bag and dst slot is a bag inventory and has items
				if(dstitem->GetProto()->InventoryType == INVTYPE_BAG)
				{
					if(dstitem->pContainer->HasItems() && dstslot < INVENTORY_SLOT_BAG_END)
					{
						data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
						data << uint8(INV_ERR_NONEMPTY_BAG_OVER_OTHER_BAG);
						data << (srcitem->pContainer ? srcitem->pContainer->GetGUID() : uint64(0));
						data << (dstitem->pContainer ? dstitem->pContainer->GetGUID() : uint64(0));
						data << uint8(0);

						SendPacket( &data );
						return;
					}
				}
				else
				{
					//dst item is not a bag, swap impossible

					data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
					data << uint8(INV_ERR_NOT_A_BAG);
					data << (srcitem->pContainer ? srcitem->pContainer->GetGUID() : uint64(0));
					data << (dstitem ? dstitem->GetGUID() : uint64(0));
					data << uint8(0);

					SendPacket( &data );
					return;
				}
			}
			else
			{
				//dst item doesnt exist, repport error since source bag has items
				data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
				data << uint8(INV_ERR_NONEMPTY_BAG_OVER_OTHER_BAG);
				data << (srcitem->pContainer ? srcitem->pContainer->GetGUID() : uint64(0));
				data << (dstitem ? dstitem->GetGUID() : uint64(0));
				data << uint8(0);

				SendPacket( &data );
				return;
			}
		}
		//src is from a back and dst is bag inventory
		if(srcitem->pContainer && dstslot < INVENTORY_SLOT_BAG_END)
		{
			if(dstitem)
			{
				//source is a bag and dst slot is a bag inventory and has items
				if(dstitem->GetProto()->InventoryType == INVTYPE_BAG)
				{
					if(dstitem->pContainer->HasItems() && dstslot < INVENTORY_SLOT_BAG_END)
					{
						data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
						data << uint8(INV_ERR_NONEMPTY_BAG_OVER_OTHER_BAG);
						data << (srcitem->pContainer ? srcitem->pContainer->GetGUID() : uint64(0));
						data << (dstitem->pContainer ? dstitem->pContainer->GetGUID() : uint64(0));
						data << uint8(0);

						SendPacket( &data );
						return;
					}
				}
			}
		}
	}

	if (srcslot == dstslot)
	{
		data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
		data << uint8(19) ;
		data << (srcitem ? srcitem->GetGUID() : uint64(0));
		data << (dstitem ? dstitem->GetGUID() : uint64(0));
		data << uint8(0);

		SendPacket( &data );
		return;
	}

	// swap items
	GetPlayer()->SwapItemSlots(srcslot, dstslot);
}


void WorldSession::HandleDestroyItemOpcode( WorldPacket & recv_data )
{
	WorldPacket data;
	Item *InvItem;
	Item *BagItem;

	uint8 SrcInvSlot, SrcSlot;

	recv_data >> SrcInvSlot >> SrcSlot;

	Log::getSingleton().outDetail("ITEM: destroy, SrcInv Slot: %u Src slot: %u", (uint32)SrcInvSlot, (uint32)SrcSlot);

	if(SrcInvSlot >= INVENTORY_SLOT_BAG_START  && SrcInvSlot <  INVENTORY_SLOT_BAG_END) // the item is from a bag
	{
		InvItem = GetPlayer()->GetItemBySlot(SrcInvSlot);
		if(InvItem)
		{
			BagItem = InvItem->pContainer->GetItem(SrcSlot);
			if(BagItem)
			{
				Item *item = InvItem->pContainer->RemoveItemFromSlot(SrcSlot);
				
				std::stringstream delinvq;
				delinvq << "DELETE FROM bag_inventory WHERE player_guid = " << GetPlayer()->GetGUIDLow() << " AND bagslot=" << SrcSlot << " AND item_guid=" << item->GetGUIDLow();
				sDatabase.Execute( delinvq.str().c_str( ) );

			    item->DeleteFromDB(); //delete instanced item from db
				delete item;
			}
		}
	}
	//source if from a backpack or equipped items
	if(SrcInvSlot >= INVENTORY_SLOT_BAG_END)
	{
		InvItem = GetPlayer()->GetItemBySlot(SrcSlot);
		if(InvItem)
		{
			if((InvItem->GetProto()->InventoryType == INVTYPE_BAG))
			{
				GetPlayer()->RemoveItemFromSlot(SrcSlot);
				delete InvItem->pContainer;
			}
			else
			{
				GetPlayer()->RemoveItemFromSlot(SrcSlot);
			}

			std::stringstream delinvq;
			delinvq << "DELETE FROM inventory WHERE player_guid = " << GetPlayer()->GetGUIDLow() << " AND slot=" << uint32(SrcSlot) << " AND item_guid=" << InvItem->GetGUIDLow();
			sDatabase.Execute( delinvq.str().c_str( ) );

            // Delete charter
            if(InvItem->GetProto()->ItemId == 5863)
            {
                guildCharter *gc = objmgr.GetGuildCharter( GetPlayer()->GetGUID() );
                if(gc)
                {
                    Player *plyr;
                    std::list<charterName>::iterator nameItr;
                    for(nameItr = gc->signList.begin(); nameItr != gc->signList.end(); nameItr++)
                    {
                        plyr = objmgr.GetPlayer(nameItr->signer);
                        if(plyr)
                        {
                            plyr->DeleteSignedCharter( gc->itemGuid );
                        }                        
                    }
                    std::stringstream query;
                    query << "DELETE FROM charters WHERE leaderGuid = ";
                    query << GetPlayer()->GetGUID();
                    sDatabase.Execute( query.str().c_str() );

                    query.rdbuf()->str("");
                    query << "DELETE FROM playercharters WHERE charterId = ";
                    query << gc->itemGuid;
                    sDatabase.Execute( query.str().c_str() );
                    delete gc;
                }
            }

			InvItem->DeleteFromDB();
			delete InvItem;
		}
	}
}


void WorldSession::HandleAutoEquipItemOpcode( WorldPacket & recv_data )
{
	WorldPacket data;

	uint8 SrcInvSlot, SrcSlot, error;

	recv_data >> SrcInvSlot >> SrcSlot;

	Log::getSingleton().outDetail("ITEM: autoequip, Inventory slot: %u Source Slot: %u", (uint32)SrcInvSlot, (uint32)SrcSlot);


	//detect wish type of slots are we handling
	if(SrcInvSlot >= INVENTORY_SLOT_BAG_START  && SrcInvSlot <  INVENTORY_SLOT_BAG_END) // the item is from a bag
	{
		Item *item = GetPlayer()->GetItemBySlot(SrcInvSlot);
		Item *BagItem = item->pContainer->GetItem(SrcSlot);
        if(!BagItem)
        {
            GetPlayer()->BuildInventoryChangeError(NULL, NULL, INV_ERR_SLOT_IS_EMPTY);
            return;
        }
		//get the proper slot based on the inventory type
		uint8 Slot = GetPlayer()->GetItemSlotByType(BagItem->GetProto()->InventoryType);
		
		if(Slot == INVENTORY_NO_SLOT_AVAILABLE)
		{
			data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
			data << uint8(INV_ERR_ITEM_CANT_BE_EQUIPPED);

			if((item->GetProto()->InventoryType == INVTYPE_BAG))
			{
				data << (BagItem ? BagItem->pContainer->GetGUID() : uint64(0));
			}
			else
			{
				data << (BagItem ? BagItem->GetGUID() : uint64(0));
			}

			data << uint64(0);
			data << uint8(0);
			SendPacket( &data );
			return;
		}
		
		Item *InventoryItem = GetPlayer()->GetItemBySlot(Slot);


		if(error=GetPlayer()->CanEquipItemInSlot(Slot, BagItem->GetProto()))
		{
			if(Slot <= INVENTORY_SLOT_BAG_END)
			{
				data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
				data << error;
				if(error == 1) 
				{
					data << BagItem->GetProto()->RequiredLevel;
				}
				data << (BagItem ? BagItem->GetGUID() : uint64(0));
				data << (InventoryItem ? InventoryItem->GetGUID() : uint64(0));
				data << uint8(0);

				SendPacket( &data );
				return;
			}
		}

		Item *bagitem = item->pContainer->RemoveItemFromSlot(SrcSlot);
		Item *InvItem = GetPlayer()->RemoveItemFromSlot(Slot);

		if(InvItem)
		{
			item->pContainer->AddItem(SrcSlot, InvItem);
		}
		if(bagitem)
		{

			GetPlayer()->AddItemToSlot(Slot,bagitem);
		}
	}
	//item is from backpack
	if(SrcInvSlot >= INVENTORY_SLOT_BAG_END)
	{
        uint8 Slot = 0;
		Item *item = GetPlayer()->GetItemBySlot(SrcSlot);
        if(item)
        {
            Slot = GetPlayer()->GetItemSlotByType(item->GetProto()->InventoryType);
        }
        else
        {
            GetPlayer()->BuildInventoryChangeError(NULL, NULL, INV_ERR_SLOT_IS_EMPTY);
            return;
        }

        if(Slot == INVENTORY_NO_SLOT_AVAILABLE || Slot == INVENTORY_SLOT_ITEM_END)
		{
			data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
			data << uint8(INV_ERR_ITEM_CANT_BE_EQUIPPED);

			if((item->GetProto()->InventoryType == INVTYPE_BAG))
			{
				data << (item ? item->pContainer->GetGUID() : uint64(0));
			}
			else
			{
				data << (item ? item->GetGUID() : uint64(0));
			}

			data << uint64(0);
			data << uint8(0);
			SendPacket( &data );
			return;
		}


		Item *InventoryItem = GetPlayer()->GetItemBySlot(Slot);


		if(error=GetPlayer()->CanEquipItemInSlot(Slot, item->GetProto()))
		{
			if(Slot <= INVENTORY_SLOT_BAG_END)
			{
				data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
				data << error;
				if(error == 1) 
				{
					data << item->GetProto()->RequiredLevel;
				}
				data << (item ? item->GetGUID() : uint64(0));
				data << (InventoryItem ? InventoryItem->GetGUID() : uint64(0));
				data << uint8(0);

				SendPacket( &data );
				return;
			}
		}

		GetPlayer()->SwapItemSlots(SrcSlot, Slot);
	}
}


void WorldSession::HandleItemQuerySingleOpcode( WorldPacket & recv_data )
{
	WorldPacket data;

	int i;
	uint32 itemid, guidlow, guidhigh;
	recv_data >> itemid >> guidlow >> guidhigh; // guid is the guid of the ITEM OWNER - NO ITS NOT

	Log::getSingleton( ).outDetail( "WORLD: Recvd CMSG_ITEM_QUERY_SINGLE for item id 0x%.8X, guid 0x%.8X 0x%.8X",
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
	data << itemProto->Name1.c_str();
	data << uint8(0) << uint8(0) << uint8(0); // name 2,3,4
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
	data << itemProto->RequiredSkillSubRank;
	data << itemProto->RequiredPlayerRank1;
	data << itemProto->RequiredPlayerRank2;
	data << itemProto->RequiredFaction;
	data << itemProto->RequiredFactionStanding;
	data << itemProto->Unique;
	data << itemProto->MaxCount;
	data << itemProto->ContainerSlots;;
	for(i = 0; i < 10; i++) {
		data << itemProto->ItemStatType[i];
		data << itemProto->ItemStatValue[i];
	}
	for(i = 0; i < 5; i++) {
		data << itemProto->DamageMin[i];
		data << itemProto->DamageMax[i];
		data << itemProto->DamageType[i];
	}
	data << itemProto->Armor;
	data << itemProto->Field62;
	data << itemProto->FireRes;
	data << itemProto->NatureRes;
	data << itemProto->FrostRes;
	data << itemProto->ShadowRes;
	data << itemProto->ArcaneRes;
	data << itemProto->Delay;
	data << itemProto->Field69;
	for(i = 0; i < 5; i++) {
		data << itemProto->SpellId[i];
		data << itemProto->SpellTrigger[i];
		data << itemProto->SpellCharges[i];
		data << itemProto->SpellCooldown[i];
		data << itemProto->SpellCategory[i];
		data << itemProto->SpellCategoryCooldown[i];
	}
	data << itemProto->Bonding;
	data << itemProto->Description.c_str();
	data << itemProto->Field102;
	data << itemProto->Field103;
	data << itemProto->Field104;
	data << itemProto->Field105;
	data << itemProto->Field106;
	data << itemProto->Field107;
	data << itemProto->Field108;
	data << itemProto->Field109;
	data << itemProto->Block;
	data << itemProto->Field111;
	data << itemProto->MaxDurability;
	data << itemProto->ZoneNameID;
	data << itemProto->Field114;

	WPAssert(data.size() == 449 + itemProto->Name1.length() + itemProto->Description.length());
	SendPacket( &data );
}

void WorldSession::HandleBuyBackOpcode( WorldPacket & recv_data )
{
	WorldPacket data;
	uint64 guid;
	uint32 stuff;
	uint8 playerslot = 0;
	uint8 vendorslot = 0;
	Item* add = NULL;
	recv_data >> guid >> stuff;
	Item *it = GetPlayer()->GetBuyBack(stuff-69);
	if (it)
	{
		// Find free slot and break if inv full
		uint32 amount = it->GetUInt32Value(ITEM_FIELD_STACK_COUNT);
		uint32 itemid = it->GetUInt32Value(OBJECT_FIELD_ENTRY);
		//uint32 itemid = it->GetProto()->ItemId;
		//add = GetPlayer()->FindItemLessMax(it->GetProto()->ItemId,amount);
		add = GetPlayer()->FindItemLessMax(itemid,amount);
		/*if (!add)
		{
			playerslot = GetPlayer()->FindFreeInvSlot();
		}
		if ((playerslot == INVENTORY_NO_SLOT_AVAILABLE) && (!add))
		{
			playerslot = CONTAINER_NO_SLOT_AVAILABLE;
			if (GetPlayer()->FindBagWithFreeSlots())
				playerslot = GetPlayer()->FindFreeBagSlot(GetPlayer()->FindBagWithFreeSlots());
		}*/
		uint32 FreeSlots = GetPlayer()->NumFreeSlots();
		if ((FreeSlots == 0) && (!add))
		{
			//Our User doesn't have a free Slot in there bag
			data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
			data << uint8(INV_ERR_INVENTORY_FULL); // Inventory Full 48//Already looted
			data << uint64(0);
			data << uint64(0);
			data << uint8(0);
			SendPacket( &data );
			return;
		}
		/*
		if ((playerslot == CONTAINER_NO_SLOT_AVAILABLE) && (!add))
		{
			//Our User doesn't have a free Slot in there bag
			data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
			data << uint8(INV_ERR_INVENTORY_FULL); // Inventory Full 48//Already looted
			data << uint64(0);
			data << uint64(0);
			data << uint8(0);
			SendPacket( &data );
			return;
		}*/
		// Check for gold
		uint32 newmoney = ((GetPlayer()->GetUInt32Value(PLAYER_FIELD_COINAGE)) - GetPlayer()->GetUInt32Value(PLAYER_FIELD_BUYBACK_PRICE_1 + stuff-69));
		if(newmoney < 0 )
		{
			data.Initialize( SMSG_BUY_FAILED );
			data << uint64(guid);
			data << uint32(itemid);
			data << uint8(2); //not enough money
			SendPacket( &data );
			return;
		}
		GetPlayer()->SetUInt32Value( PLAYER_FIELD_COINAGE , newmoney);
		if (!add)
		{
			//GetPlayer()->AddItemToSlot( playerslot, it);
			GetPlayer()->AddItemToFreeSlot(it);
		} else
		{
			add->SetUInt32Value(ITEM_FIELD_STACK_COUNT,add->GetUInt32Value(ITEM_FIELD_STACK_COUNT) + amount);
		}

		data.Initialize( SMSG_BUY_ITEM );
		data << uint64(guid);
		data << uint32(itemid) << uint32(amount);
		WPAssert(data.size() == 16);
		SendPacket( &data );
	}
	GetPlayer()->RemoveBuyBackItem(stuff-69);
}
void WorldSession::HandleSellItemOpcode( WorldPacket & recv_data )
{
	Log::getSingleton( ).outDetail( "WORLD: Recieved CMSG_SELL_ITEM" );

	WorldPacket data;
	uint64 vendorguid, itemguid;
	uint8 amount;
	uint32 newmoney;
	//uint8 slot = INVENTORY_NO_SLOT_AVAILABLE;
	//uint8 bagslot = INVENTORY_NO_SLOT_AVAILABLE;
	//int check = 0;

	recv_data >> vendorguid;
	recv_data >> itemguid;
	recv_data >> amount;

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

	Item* item = GetPlayer()->GetItemByGUID(itemguid, false);
	if(!item)
	{
		data.Initialize( SMSG_SELL_ITEM );
		data << vendorguid << itemguid << uint8(0x01);
		WPAssert(data.size() == 17);
		SendPacket( &data );
		return; //our player doesn't have this item
	}

    ItemPrototype *it = item->GetProto();
    if(!it)
	{
		data.Initialize( SMSG_SELL_ITEM );
		data << vendorguid << itemguid << uint8(0x02);
		WPAssert(data.size() == 17);
		SendPacket( &data );
		return; //our player doesn't have this item
	}

	// Check if item can be sold
	if (it->SellPrice == 0)
	{
		data.Initialize( SMSG_SELL_ITEM );
		data << vendorguid << itemguid << uint8(0x02);
		WPAssert(data.size() == 17);
		SendPacket( &data );
		return;
	}
	/*//adding this item to the vendor's item list... not nessesary for unlimited items
	for(i=0; i<tempunit->getItemCount();i++)
	{
	if (tempunit->getItemId(i) == GetPlayer()->getItemIdBySlot(itemindex))
	{
	tempunit->setItemAmount(i, tempunit->getItemAmount(i) + amount);
	check = 1;
	}
	}

	if (check == 0)
	{
	if (tempunit->getItemCount() > 100)
	{
	data.Initialize( SMSG_SELL_ITEM );
	data << srcguid1 << srcguid2 << itemguid1 << itemguid2 << uint8(0x02);
	WPAssert(data.size() == 17);
	SendPacket( &data );
	return;
	}
	else
	tempunit->addItem(GetPlayer()->getItemIdBySlot(itemindex), amount);
	}*/

	uint32 stackcount = item->GetUInt32Value(ITEM_FIELD_STACK_COUNT);
	uint32 quantity = 0;
	if (amount != 0)
	{
		quantity = amount;
	}
	else
	{
		quantity = stackcount; //allitems
	}

	if(quantity > stackcount) quantity = stackcount; //make sure we don't over do it
	
	newmoney = ((GetPlayer()->GetUInt32Value(PLAYER_FIELD_COINAGE)) + ((it->SellPrice) * quantity));
	GetPlayer()->SetUInt32Value( PLAYER_FIELD_COINAGE , newmoney);

	if(quantity < stackcount)
	{
		item->SetUInt32Value(ITEM_FIELD_STACK_COUNT, (stackcount - quantity));
	}
	else
	{
		//removing the item from the char's inventory
		item = GetPlayer()->GetItemByGUID(itemguid, true, false); //again to remove item from slot
		GetPlayer()->AddBuyBackItem(item,(it->SellPrice) * quantity);
	}

	data.Initialize( SMSG_SELL_ITEM );
	data << vendorguid << itemguid
		<< uint8(0); // Error Codes: 0x01 = Item not Found
	//              0x02 = Vendor doesnt want that item
	//              0x03 = Vendor doesnt like you ;P
	//              0x04 = You dont own that item
	//              0x05 = Ok
	//              0x06 = Only with empty Bags !?
	SendPacket( &data );

	Log::getSingleton( ).outDetail( "WORLD: Sent SMSG_SELL_ITEM" );
}


void WorldSession::HandleBuyItemInSlotOpcode( WorldPacket & recv_data ) // drag & drop
{
	Log::getSingleton( ).outDetail( "WORLD: Recieved CMSG_BUY_ITEM_IN_SLOT" );

	WorldPacket data;
	uint64 srcguid, dstguid;
	uint32 itemid;
	uint8 slot, amount;
	int vendorslot = -1;
	int32 newmoney;

	recv_data >> srcguid >> itemid;
	recv_data >> dstguid; // ??
	recv_data >> slot;
	recv_data >> amount;

	Creature *unit = objmgr.GetObject<Creature>(srcguid);
	if (unit == NULL)
		return;

	if (slot > 38)
		return;
	if (slot < 19)
		return;
	if ((slot <= 22) && (slot >=19))
		return; //these are the bags slots...i'm not sure exactly how to use them
	if (GetPlayer()->GetItemBySlot(slot) != 0)
		return; //slot is not empty...

	//GetPlayer()->GetItemBySlot(slot)
	// Find item slot
	for(uint8 i = 0; i < unit->getItemCount(); i++)
	{
		if (unit->getItemId(i) == itemid)
		{
			vendorslot = i;
			break;
		}
	}

	if( vendorslot == -1 )
		return;

	// Check for vendor have the required amount of that item ....
	if (amount > unit->getItemAmount(vendorslot) && unit->getItemAmount(vendorslot)>=0)
		return;

    ItemPrototype *it = objmgr.GetItemPrototype(itemid);
    if(!it) return;

	// Check for gold
	newmoney = ((GetPlayer()->GetUInt32Value(PLAYER_FIELD_COINAGE)) - (it->BuyPrice));
	if(newmoney < 0 )
	{
		data.Initialize( SMSG_BUY_FAILED );
		data << uint64(srcguid);
		data << uint32(itemid);
		data << uint8(2); //not enough money
		SendPacket( &data );
		return;
	}
	GetPlayer()->SetUInt32Value( PLAYER_FIELD_COINAGE , newmoney);

    sLog.outDebug("BuyItemSlot itemHandler");
	Item *item = new Item();
	item->Create(objmgr.GenerateLowGuid(HIGHGUID_ITEM), itemid, GetPlayer());

	unit->setItemAmount( vendorslot, unit->getItemAmount(vendorslot)-amount );
	GetPlayer()->AddItemToSlot( slot, item );

	data.Initialize( SMSG_BUY_ITEM );
	data << uint64(srcguid);
	data << uint32(itemid) << uint32(amount);
	WPAssert(data.size() == 16);
	SendPacket( &data );
	Log::getSingleton( ).outDetail( "WORLD: Sent SMSG_BUY_ITEM" );
}


void WorldSession::HandleBuyItemOpcode( WorldPacket & recv_data ) // right-click on item
{
	Log::getSingleton( ).outDetail( "WORLD: Recieved CMSG_BUY_ITEM" );

	WorldPacket data;
	uint64 srcguid;
	uint32 itemid;
	uint8 amount, slot;
	uint8 playerslot = 0;
	uint8 bagslot = 0;
	int vendorslot = -1;
	int32 newmoney;
	Item *add;

	recv_data >> srcguid >> itemid;
	recv_data >> amount >> slot;

	Creature *unit = objmgr.GetObject<Creature>(srcguid);
	if (unit == NULL)
		return;

	// Find free slot and break if inv full
	add = GetPlayer()->FindItemLessMax(itemid,amount);
	if (!add)
	{
		playerslot = GetPlayer()->FindFreeInvSlot();
	}
	if ((playerslot == INVENTORY_NO_SLOT_AVAILABLE) && (!add))
	{
        playerslot = CONTAINER_NO_SLOT_AVAILABLE;
		bagslot = GetPlayer()->FindBagWithFreeSlots();
		if (bagslot != 0 )
		{
			playerslot = GetPlayer()->FindFreeBagSlot(bagslot);
		}
	}
	if ((playerslot == CONTAINER_NO_SLOT_AVAILABLE) && (!add))
	{
		//Our User doesn't have a free Slot in there bag
		data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
        data << uint8(INV_ERR_INVENTORY_FULL); // Inventory Full 48//Already looted
        data << uint64(0);
        data << uint64(0);
        data << uint8(0);
		SendPacket( &data );
		return;
	}
	vendorslot = slot;

	// Check for vendor have the required amount of that item ....
	/*if (amount > unit->getItemAmount(vendorslot) && unit->getItemAmount(vendorslot)>=0)
		return;*/

    ItemPrototype *it = objmgr.GetItemPrototype(itemid);
    if(!it) return;

	// Check for gold
	newmoney = ((GetPlayer()->GetUInt32Value(PLAYER_FIELD_COINAGE)) - (it->BuyPrice * amount));
	if(newmoney < 0 )
	{
		data.Initialize( SMSG_BUY_FAILED );
		data << uint64(srcguid);
		data << uint32(itemid);
		data << uint8(2); //not enough money
		SendPacket( &data );
		return;
	}
	GetPlayer()->SetUInt32Value( PLAYER_FIELD_COINAGE , newmoney);

	// unit->setItemAmount( vendorslot, unit->getItemAmount(vendorslot)-amount ); // Unlimited Items
	if (!add)
	{
		sLog.outDebug("BuyItem Itemhandler");
        Item *item = new Item();
		item->Create(objmgr.GenerateLowGuid(HIGHGUID_ITEM), itemid, GetPlayer());
		item->SetUInt32Value(ITEM_FIELD_STACK_COUNT,amount);

		if(bagslot > 0)
		{
			Item *bag = GetPlayer()->GetItemBySlot(bagslot);
			if(bag)
			{
				bag->pContainer->AddItem(playerslot,item);
				//GetPlayer()->AddItemToSlot( playerslot, item );
			}
		}
		else
		{
			GetPlayer()->AddItemToSlot( playerslot, item );
		}
	} else
	{
		add->SetUInt32Value(ITEM_FIELD_STACK_COUNT,add->GetUInt32Value(ITEM_FIELD_STACK_COUNT) + amount);
	}

	data.Initialize( SMSG_BUY_ITEM );
	data << uint64(srcguid);
	data << uint32(itemid) << uint32(amount);
	WPAssert(data.size() == 16);
	SendPacket( &data );
	Log::getSingleton( ).outDetail( "WORLD: Sent SMSG_BUY_ITEM" );
}

void WorldSession::HandleListInventoryOpcode( WorldPacket & recv_data )
{
	Log::getSingleton( ).outDetail( "WORLD: Recvd CMSG_LIST_INVENTORY" );

	WorldPacket data;
	uint64 guid;

	recv_data >> guid;

	Creature *unit = objmgr.GetObject<Creature>(guid);
	if (unit == NULL)
		return;

	uint8 numitems = (uint8)unit->getItemCount();
	uint8 actualnumitems = 0;
	uint8 i = 0;

	//get actual Item Count better then alot of spaces :D
	for(i = 0; i < numitems; i ++ )
	{
		if(unit->getItemId(i) != 0) actualnumitems += 1;
	}
	uint32 guidlow = GUID_LOPART(guid);

	data.Initialize( SMSG_LIST_INVENTORY );
	data << guid;
	data << uint8( actualnumitems ); // num items

	// each item has seven uint32's

	ItemPrototype * curItem;
	for(i = 0; i < numitems; i ++ )
	{
		if(unit->getItemId(i) != 0)
		{
			curItem = objmgr.GetItemPrototype(unit->getItemId(i));
			if( !curItem )
			{
				Log::getSingleton( ).outError( "Unit %i has nonexistant item %i! the item will be removed next time", guid, unit->getItemId(i) );
				for( int a = 0; a < 7; a ++ )
					data << uint32( 0 );

				std::stringstream ss;
				ss << "DELETE * FROM vendors WHERE vendorGuid=" << guidlow << " itemGuid=" << unit->getItemId(i) << '\0';
				QueryResult *result = sDatabase.Query( ss.str().c_str() );

				unit->setItemAmount(i,0);
				unit->setItemId(i,0);
			}
			else
			{
				data << uint32( i + 1 ); // index ? doesn't seem to affect anything
				data << uint32( unit->getItemId(i) ); // item id
				data << uint32( curItem->DisplayInfoID ); // item icon
				data << uint32( unit->getItemAmount(i) ); // number of items available, -1 works for infinity, although maybe just 'cause it's really big
				data << uint32( curItem->BuyPrice ); // price
				data << uint32( 0 ); // ?
				data << uint32( 0 ); // ?
			}
		}
	}

	WPAssert(data.size() == 8 + 1 + ((actualnumitems * 7) * 4));
	SendPacket( &data );
	Log::getSingleton( ).outDetail( "WORLD: Sent SMSG_LIST_INVENTORY" );
}


void WorldSession::HandleAutoStoreBagItemOpcode( WorldPacket & recv_data )
{
	Log::getSingleton( ).outDetail( "WORLD: Recvd CMSG_AUTO_STORE_BAG_ITEM" );

	WorldPacket data;
	WorldPacket packet;
	UpdateData upd;
	uint8 SrcInv, Slot, DstInv;
	Item *item;
	Item *BagItem;
	Item *DstBag;
	uint8 NewSlot;

	recv_data >> SrcInv >> Slot >> DstInv;

	if(SrcInv >= INVENTORY_SLOT_BAG_START  && SrcInv <  INVENTORY_SLOT_BAG_END) // the item is from a bag
	{
		item = GetPlayer()->GetItemBySlot(SrcInv);
		if(item)
		{
			BagItem = item->pContainer->GetItem(Slot);
			//detect Corrent Dst, bag or backpack
			if(DstInv >= INVENTORY_SLOT_BAG_END)
			{
				if(BagItem)
				{
					NewSlot = GetPlayer()->FindFreeInvSlot();
					if(NewSlot == INVENTORY_NO_SLOT_AVAILABLE)
					{
						//backpack is full
						data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
						data << uint8(INV_ERR_BAG_FULL);
						data << (BagItem ? BagItem->GetGUID() : uint64(0));
						data << uint64(0);
						data << uint8(0);
						SendPacket( &data );
					}
					else
					{
						BagItem = NULL; //resets pointer
						BagItem = item->pContainer->RemoveItemFromSlot(Slot);
						if(BagItem)
						{
							GetPlayer()->AddItemToSlot(NewSlot,BagItem);
						}
					}
				}
			}
			else
			{
				DstBag = GetPlayer()->GetItemBySlot(DstInv);

				if(DstBag && BagItem)
				{
					NewSlot = DstBag->pContainer->FindFreeSlot();
					if(NewSlot == CONTAINER_NO_SLOT_AVAILABLE)
					{
					//Dst Bag is full
						data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
						data << uint8(INV_ERR_BAG_FULL);
						data << (BagItem ? BagItem->GetGUID() : uint64(0));
						data << uint64(0);
						data << uint8(0);
						SendPacket( &data );
					}
					else
					{
						BagItem = NULL; //resets pointer
						BagItem = item->pContainer->RemoveItemFromSlot(Slot);
						if(BagItem)
						{
							DstBag->pContainer->AddItem(NewSlot,BagItem);
						}
					}
				}
				//error, Bagitem and DstBag not found
			}
			//error Source bag not found
		}
	}

	if(SrcInv >= INVENTORY_SLOT_BAG_END)
	{
		item = GetPlayer()->GetItemBySlot(Slot);

		if(item)
		{
			if(DstInv >= INVENTORY_SLOT_BAG_END)
			{
				NewSlot = GetPlayer()->FindFreeInvSlot();
				if(NewSlot == INVENTORY_NO_SLOT_AVAILABLE)
				{
						//backpack is full
					data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
					data << uint8(INV_ERR_BAG_FULL);
					data << (item ? item->GetGUID() : uint64(0));
					data << uint64(0);
					data << uint8(0);
					SendPacket( &data );
				}
				else
				{
					item = NULL; //resets pointer
					item = GetPlayer()->RemoveItemFromSlot(Slot);
					if(item)
					{
						GetPlayer()->AddItemToSlot(NewSlot,item);
					}
				}

			}
			else
			{
				DstBag = GetPlayer()->GetItemBySlot(DstInv);
				if(DstBag)
				{
					NewSlot = DstBag->pContainer->FindFreeSlot();
					if(NewSlot == CONTAINER_NO_SLOT_AVAILABLE)
					{
						data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
						data << uint8(INV_ERR_BAG_FULL);
						data << (item ? item->GetGUID() : uint64(0));
						data << uint64(0);
						data << uint8(0);

						SendPacket( &data );
					}
					else
					{
						item = NULL;
						item = GetPlayer()->RemoveItemFromSlot(Slot);
						DstBag->pContainer->AddItem(NewSlot, item);
					}
				}
				//error DstBag not found
			}
			//source item not found
		}
	}
}
