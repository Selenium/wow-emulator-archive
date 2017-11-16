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

#include "WorldPacket.h"
#include "WorldSession.h"
#include "Opcodes.h"
#include "Log.h"
#include "World.h"
#include "ObjectMgr.h"
#include "Player.h"
#include "UpdateMask.h"
#include "Unit.h"
#include "Item.h"
#include "Trade.h"

createFileSingleton( TradeHandler );

TradeHandler::TradeHandler()
{
}

TradeHandler::~TradeHandler()
{
}

bool TradeHandler::SwapItems(Player *from, Player *to, uint8 tradeslot)
{
	sLog.outDebug("TRADE SWAP ITEMS");
	//get Trade Item
	TradeItem* tradeitem = from->GetTradeItem(tradeslot);
	if(tradeitem != NULL)
	{
		Item *item = from->GetItemByLocation(tradeitem->SourceBag, tradeitem->SourceSlot, true);
		to->AddItemToFreeSlot(item);
		return true;
	}
	return false;
}

void TradeHandler::UpdateTrade(Player *player)
{
	WorldPacket data;
	Player *pTarget = player->TradingWith;

	if (!pTarget)
	{
		data.Initialize(SMSG_TRADE_STATUS);
		data << uint32(TRADE_STATUS_PLAYER_NOT_FOUND);
		player->GetSession()->SendPacket(&data);
		return;
	}

	sLog.outDebug("SMSG_TRADE_STATUS_EXTENDED");

	player->SetTradeSeqNum(player->GetTradeSeqNum()+1);
	uint8 n;

	data.Initialize(SMSG_TRADE_STATUS_EXTENDED);
	data << (uint8)TRADE_RECEIVE;
	data << uint32(player->GetTradeSeqNum());
	data << uint32(pTarget->GetTradeSeqNum());
	data << player->GetTradeGold();
	data << pTarget->GetTradeGold();

	TradeItem* tradeitem;
	Item* item = NULL;
	for(n = 0;n < 7;n++)
	{			
		tradeitem = player->GetTradeItem(n);
		if(tradeitem != NULL)
		{
			Item *item = player->GetItemByLocation(tradeitem->SourceBag, tradeitem->SourceSlot, false);
			if(!item)
				continue;

			data << (uint8)n;
			data << item->GetUInt32Value(OBJECT_FIELD_ENTRY);
			data << item->GetProto()->DisplayInfoID;
			data << item->GetUInt32Value(ITEM_FIELD_STACK_COUNT);

			//NOTES
			//NO SUPPORT FOR DISPLAYING MODIFIED ITEMS	
			//these are for custom made items
			data << uint32(0); 
			data << uint32(0); //Duribility is showen but wrong
			data << uint32(0); //^
			data << uint32(0); // Green text "Rockbiter 3"
			data << uint32(0); // Made by GUID
			data << uint32(0); // Made By GUID 
			data << uint32(0); // unk
			data << uint32(0);
			data << uint32(0);
			data << uint32(0);

			data << uint32(item->GetProto()->InventoryType);
			data << uint32(item->GetProto()->InventoryType);
		}
	}
	pTarget->GetSession()->SendPacket(&data);
	sLog.outDebug("SMSG_TRADE_STATUS_EXTENDED SENT");
}

void WorldSession::HandleInitiateTrade(WorldPacket & recv_data)
{
	WorldPacket data;
	uint64 TargetGUID;
	recv_data >> TargetGUID;
	Player *player = GetPlayer();
	Player *pTarget = objmgr.GetObject<Player>(TargetGUID);

	if (!pTarget)
	{
		data.Initialize(SMSG_TRADE_STATUS);
		data << uint32(TRADE_STATUS_PLAYER_NOT_FOUND);
		SendPacket(&data);
		return;
	}
	if (!player->IsInRangeSet(pTarget))
	{
		data.Initialize(SMSG_TRADE_STATUS);
		data << uint32(TRADE_STATUS_TOO_FAR_AWAY);
		SendPacket(&data);
		return;
	}
	if (pTarget->isDead())
	{
		data.Initialize(SMSG_TRADE_STATUS);
		data << uint32(TRADE_STATUS_DEAD);
		SendPacket(&data);
		return;
	}
	if(pTarget->TradingWith != NULL) //target is Already Trading
	{
		//Busy
		data.Initialize(SMSG_TRADE_STATUS);
		data << uint32(TRADE_STATUS_ALREADY_TRADING);
		SendPacket(&data);
		return;
	}
	player->TradingWith = pTarget; 
	pTarget->TradingWith = player;

	sLog.outDebug("TRADE_STATUS_PROPOSED");

	player->SetTradeSeqNum(1);
	pTarget->SetTradeSeqNum(1);
	player->SetTradeStatus(TRADE_STATUS_PROPOSED);
	data.Initialize(SMSG_TRADE_STATUS);
	data << uint32(TRADE_STATUS_PROPOSED);
	data << player->GetGUID();
	pTarget->GetSession()->SendPacket(&data);

}

void WorldSession::HandleBeginTrade(WorldPacket & recv_data)
{
	WorldPacket data;
	Player *player = GetPlayer();
	Player *pTarget = player->TradingWith;

	if (!pTarget)
	{
		data.Initialize(SMSG_TRADE_STATUS);
		data << uint32(TRADE_STATUS_PLAYER_NOT_FOUND);
		player->GetSession()->SendPacket(&data);
		return;
	}

	sLog.outDebug("TRADE_STATUS_INITIATED");

	data.Initialize(SMSG_TRADE_STATUS);
	data << uint32(TRADE_STATUS_INITIATED);

	player->GetSession()->SendPacket(&data);
	pTarget->GetSession()->SendPacket(&data);
	pTarget->SetTradeStatus(TRADE_STATUS_INITIATED);
	player->SetTradeStatus(TRADE_STATUS_INITIATED);
	
	//Zero Gold
	pTarget->SetTradeGold(0);
	player->SetTradeGold(0);

	//make sure Item Lists Clear
	player->DelAllTradeItems();
	pTarget->DelAllTradeItems();
}

void WorldSession::HandleBusyTrade(WorldPacket & recv_data)
{
	WorldPacket data;
	Player *pTarget = GetPlayer()->TradingWith;

	if (!pTarget)
	{
		data.Initialize(SMSG_TRADE_STATUS);
		data << uint32(TRADE_STATUS_PLAYER_NOT_FOUND);
		GetPlayer()->GetSession()->SendPacket(&data);
		return;
	}

	data.Initialize(SMSG_TRADE_STATUS);
	data << uint32(TRADE_STATUS_PLAYER_BUSY);
	GetPlayer()->GetSession()->SendPacket(&data);
}

void WorldSession::HandleIgnoreTrade(WorldPacket & recv_data)
{
	WorldPacket data;
	Player *pTarget = GetPlayer()->TradingWith;

	if (!pTarget)
	{
		data.Initialize(SMSG_TRADE_STATUS);
		data << uint32(TRADE_STATUS_PLAYER_NOT_FOUND);
		GetPlayer()->GetSession()->SendPacket(&data);
		return;
	}

	data.Initialize(SMSG_TRADE_STATUS);
	data << uint32(TRADE_STATUS_PLAYER_IGNORED);
	pTarget->GetSession()->SendPacket(&data);

	GetPlayer()->GetSession()->SendPacket(&data);
}

void WorldSession::HandleAcceptTrade(WorldPacket & recv_data)
{
	WorldPacket data;

	Player *player = GetPlayer();
	sLog.outDebug("TRADE_STATUS_ACCEPTED BY %s (%u)",player->GetName(), player->GetGUIDLow());

	if((player->GetTradeStatus() == TRADE_STATUS_COMPLETE) || (player->GetTradeStatus() == TRADE_STATUS_CANCELLED)) return;

	Player *pTarget = player->TradingWith;

	player->SetTradeStatus(TRADE_STATUS_ACCEPTED);

	if (!pTarget)
	{
		data.Initialize(SMSG_TRADE_STATUS);
		data << uint32(TRADE_STATUS_PLAYER_NOT_FOUND);
		player->GetSession()->SendPacket(&data);
		return;
	}

	uint32 playerTGold = player->GetTradeGold();
	uint32 pTargetTGold = pTarget->GetTradeGold();

	data.Initialize(SMSG_TRADE_STATUS);
	data << uint32(TRADE_STATUS_ACCEPTED);
	pTarget->GetSession()->SendPacket(&data);

	if (pTarget->GetTradeStatus() == TRADE_STATUS_ACCEPTED)
	{
		//Test for Enough Slots
		bool Cancel = false;
		uint32 freeslots = 0;
		uint8 playerslotsneeded = pTarget->GetTradeItemsCount();
		uint8 targetslotsneeded = player->GetTradeItemsCount();
		uint32 playerfreeslots = player->NumFreeSlots()+targetslotsneeded;
		uint32 targetfreeslots = pTarget->NumFreeSlots()+playerslotsneeded;
		
		if(targetfreeslots < targetslotsneeded)
			Cancel = true;

		if(playerfreeslots < playerslotsneeded)
			Cancel = true;

		if(!Cancel)
		{
			TradeItem* tradeitem;
			for(int j=0;j < 6;j++) //so they only get slots 0 to 5
			{
				//get Trade Item
				tradeitem = player->GetTradeItem(j);
				if(tradeitem != NULL)
				{
					//exchange item
					sTradeHandler.SwapItems(player,pTarget,j);
				}
				//Repeat for other Player
				//get Trade Item
				tradeitem = pTarget->GetTradeItem(j);
				if(tradeitem != NULL)
				{
					//exchange item
					sTradeHandler.SwapItems(pTarget,player,j);
				}
			}

			player->SetUInt32Value(PLAYER_FIELD_COINAGE,(player->GetUInt32Value(PLAYER_FIELD_COINAGE) - playerTGold) + pTargetTGold);
			pTarget->SetUInt32Value(PLAYER_FIELD_COINAGE,(pTarget->GetUInt32Value(PLAYER_FIELD_COINAGE) - pTargetTGold) + playerTGold);

			data.Initialize(SMSG_TRADE_STATUS);
			data << uint32(TRADE_STATUS_COMPLETE);
			SendPacket(&data);
			pTarget->GetSession()->SendPacket(&data);
			
			player->SetTradeStatus(TRADE_STATUS_COMPLETE);
			pTarget->SetTradeStatus(TRADE_STATUS_COMPLETE);
		}
		else
		{
			data.Initialize(SMSG_TRADE_STATUS);
			data << uint32(TRADE_STATUS_CANCELLED);
			SendPacket(&data);
			pTarget->GetSession()->SendPacket(&data);

			player->SetTradeStatus(TRADE_STATUS_CANCELLED);
			pTarget->SetTradeStatus(TRADE_STATUS_CANCELLED);
		}

		//Empty Trading Items
		player->DelAllTradeItems();
		pTarget->DelAllTradeItems();

		//Set Trading will to no one
		player->TradingWith = NULL;
		pTarget->TradingWith = NULL;
	}
}

void WorldSession::HandleUnacceptTrade(WorldPacket & recv_data)
{
	WorldPacket data;
	Player *player = GetPlayer();
	Player *pTarget = player->TradingWith;

	if (!pTarget)
	{
		data.Initialize(SMSG_TRADE_STATUS);
		data << uint32(TRADE_STATUS_PLAYER_NOT_FOUND);
		player->GetSession()->SendPacket(&data);
		return;
	}

	player->SetTradeStatus(TRADE_STATUS_UNACCEPTED);
	data.Initialize(SMSG_TRADE_STATUS);
	data << uint32(TRADE_STATUS_UNACCEPTED);
	pTarget->GetSession()->SendPacket(&data);
}

void WorldSession::HandleCancelTrade(WorldPacket & recv_data)
{
	WorldPacket data;
	Player *player = GetPlayer();

	if(!player)
		return;
	
	sLog.outDebug("TRADE_STATUS_CANCELLED");

	if((player->GetTradeStatus() == TRADE_STATUS_CANCELLED) || (player->GetTradeStatus() == TRADE_STATUS_COMPLETE)) return;

	Player *pTarget = player->TradingWith;
	
	if (!pTarget)
	{
		data.Initialize(SMSG_TRADE_STATUS);
		data << uint32(TRADE_STATUS_PLAYER_NOT_FOUND);
		player->GetSession()->SendPacket(&data);
		return;
	}

	player->SetTradeStatus(TRADE_STATUS_CANCELLED);
	pTarget->SetTradeStatus(TRADE_STATUS_CANCELLED);

	//Clear Item Lists
	player->DelAllTradeItems();
	pTarget->DelAllTradeItems();

	data.Initialize(SMSG_TRADE_STATUS);
	data << uint32(TRADE_STATUS_CANCELLED); // cancel - close window
	pTarget->GetSession()->SendPacket(&data);
	player->GetSession()->SendPacket(&data);

	//Set Trading will to no one
	player->TradingWith = NULL;
	pTarget->TradingWith = NULL;
}

void WorldSession::HandleSetTradeItem(WorldPacket & recv_data)
{	
	uint8 tradeWindowSlot;
	uint8 sourceBag;
	uint8 sourceSlot;

	Player *player = GetPlayer();

	recv_data >> tradeWindowSlot; // trade window slot (0x00 - 0x06)
	recv_data >> sourceBag; // source bag or 0xFF for backpack
	recv_data >> sourceSlot; // source slot (inventory slot, backpack, worn, etc...)

	Item * theItem = player->GetItemByLocation(sourceBag,sourceSlot,false); //player->GetItemBySlot(sourceSlot);

	if(theItem != NULL) //Items Exists
	{
		sLog.outDebug("SMSG_TRADE_STATUS_EXTENDED SET ITEM");

		//remove the item from the destination slot if it already has one
		player->DelTradeItem(tradeWindowSlot);

		//create new trading item
		TradeItem* newtradeitem;
		newtradeitem = new TradeItem;
		newtradeitem->TradeSlot = tradeWindowSlot;
		newtradeitem->SourceSlot = sourceSlot;
		newtradeitem->SourceBag = sourceBag;

		//add new item
		player->AddTradeItem(newtradeitem);

		//send Update
		sTradeHandler.UpdateTrade(player);
	}
}

void WorldSession::HandleClearTradeItem(WorldPacket & recv_data)
{
	uint8 tradeWindowSlot;
	recv_data >> tradeWindowSlot;
	GetPlayer()->DelTradeItem(tradeWindowSlot);
	sTradeHandler.UpdateTrade(GetPlayer());
}

void WorldSession::HandleSetTradeGold(WorldPacket & recv_data)
{
	uint32 newTradeGold;
	uint32 oldTradeGold;
	recv_data >> newTradeGold;

	oldTradeGold = GetPlayer()->GetTradeGold();
	if(newTradeGold != oldTradeGold)
	{
		GetPlayer()->SetTradeGold(newTradeGold);
		sTradeHandler.UpdateTrade(GetPlayer());
	}
}
