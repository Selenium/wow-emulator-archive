// (c) AbyssX Group
#include "../WorldEnvironment.h"

#ifdef NPCS

NPC::NPC()
{
}

NPC::~NPC()
{
}

DoubleWord NPC::HandlePackets(Client *cli, Packet *pack)
{
	switch (pack->GetOpCode())
	{
		case CMSG_LIST_INVENTORY:
			HandleMSG_LIST_INVENTORY(cli, pack);
			return 1;
			break;
#ifdef ITEMS
		case CMSG_BUY_ITEM:
			HandleMSG_BUY_ITEM(cli, pack);
			return 1;
			break;

		case CMSG_BUY_ITEM_IN_SLOT:
			HandleMSG_BUY_ITEM_IN_SLOT(cli, pack);
			return 1;
			break;

		case CMSG_SELL_ITEM:
			HandleMSG_SELL_ITEM(cli, pack);
			return 1;
			break;
#endif
	}

	return 0;
}

void NPC::HandleMSG_LIST_INVENTORY(Client *cli, Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Mob *mob = MonsterHandler::GetSingleton().FindMob(pack->GetQuadWord(0x00));

	if (!ply)
		return;

	if (mob)
	{
#ifdef NPCDEBUG
		printf("[World-Server] - Player %s, is Asked for %s's Items List.\n",
			ply->GetName().c_str(),mob->GetName().c_str());
#endif
		QueryVendorItems(mob, cli);
#ifdef NPCDEBUG
		printf("[World-Server] - The Items List Has Been Sent!\n");
#endif
	}
}

#ifdef ITEMS
void NPC::HandleMSG_BUY_ITEM(Client *cli, Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Item *item = Items_Handler::GetSingleton().FindItem(pack->GetDoubleWord(0x08));

	Packet retpack;
	
	if (!ply)
		return;

	if (item)
	{
		if (ply->GetMoney() >= item->ItemDATA.BuyPrice)
		{
			ply->SetMoney(ply->GetMoney() - item->ItemDATA.BuyPrice);

			//printf("[World-Server] - The Player %s Is Buying Item %s\n",ply->GetName().c_str(),item->name.c_str());
			if(Items_Handler::GetSingleton().ItemUpdate(item->ItemDATA.Entry, WorldServer::GetSingleton().GetNewItemGUID(), ply, ply->GetClient()) == 0)
			{
				Packets::UpdateObjectHeader(ply,&retpack);

				ObjectUpdate upd;

				upd.Clear();
				upd.Touch(ObjectUpdate::UPDOBJECT);
				upd.Touch(ObjectUpdate::UPDUNIT);
				upd.Touch(ObjectUpdate::UPDPLAYER);

				//Money
				upd.AddField(ObjectUpdate::UPDPLAYER, PLAYER_FIELD_COINAGE, ply->GetMoney());

				retpack.AddObjectUpdate(&upd);
	
				WorldServer::GetSingleton().WriteData(cli,&retpack);

				WorldServer::GetSingleton().AnnounceTo(cli,"[World-Server] - You Bought [ %s ] for %d of Copper",item->ItemDATA.name.c_str(),item->ItemDATA.BuyPrice);
			}
			else
				WorldServer::GetSingleton().AnnounceTo(cli,"[World-Server] - Buy Canceled...",item->ItemDATA.name.c_str(),item->ItemDATA.BuyPrice);

		}

		else
			WorldServer::GetSingleton().AnnounceTo(cli,"[World-Server] - You don't have enough money to Buy this item...");
	}
}

void NPC::HandleMSG_BUY_ITEM_IN_SLOT(Client *cli, Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Item *item = Items_Handler::GetSingleton().FindItem(pack->GetDoubleWord(0x08));

	Word SLOT = pack->GetByte(0x14);

	Packet retpack;
	
	if (!ply)
		return;

	if (item)
	{
		if (ply->GetMoney() >= item->ItemDATA.BuyPrice)
		{
			ply->SetMoney(ply->GetMoney() - item->ItemDATA.BuyPrice);

			//printf("[World-Server] - The Player %s Is Buying Item %s\n",ply->GetName().c_str(),item->name.c_str());
			if(Items_Handler::GetSingleton().ItemUpdate(item->ItemDATA.Entry, WorldServer::GetSingleton().GetNewItemGUID(), ply, ply->GetClient()) == 0)
			{
				Packets::UpdateObjectHeader(ply,&retpack);

				ObjectUpdate upd;

				upd.Clear();
				upd.Touch(ObjectUpdate::UPDOBJECT);
				upd.Touch(ObjectUpdate::UPDUNIT);
				upd.Touch(ObjectUpdate::UPDPLAYER);

				//Money
				upd.AddField(ObjectUpdate::UPDPLAYER, PLAYER_FIELD_COINAGE, ply->GetMoney());

				retpack.AddObjectUpdate(&upd);

				WorldServer::GetSingleton().WriteData(cli,&retpack);

				WorldServer::GetSingleton().AnnounceTo(cli,"[World-Server] - You Bought [ %s ] for %d of Copper",item->ItemDATA.name.c_str(),item->ItemDATA.BuyPrice);
			}
			else
				WorldServer::GetSingleton().AnnounceTo(cli,"[World-Server] - Buy Canceled...",item->ItemDATA.name.c_str(),item->ItemDATA.BuyPrice);
		}

		else
			WorldServer::GetSingleton().AnnounceTo(cli,"[World-Server] - You don't have enough money to Buy this item...");
	}

}

void NPC::HandleMSG_SELL_ITEM(Client *cli, Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Player_Item *pitem = ply->FindPlayerItem(pack->GetQuadWord(0x08));

	Packet retpack;
	
	if (!ply)
		return;

	if (pitem)
	{
		Item *item = Items_Handler::GetSingleton().FindItem(pitem->Entry);
		if (item)
		{
			ply->SetMoney(ply->GetMoney() + item->ItemDATA.SellPrice);

			//printf("[World-Server] - The Player %s Is Selling Item %s\n",ply->GetName().c_str(),item->name.c_str());
			
			Packets::UpdateObjectHeader(ply,&retpack);

			ObjectUpdate upd;

			upd.Clear();
			upd.Touch(ObjectUpdate::UPDOBJECT);
			upd.Touch(ObjectUpdate::UPDUNIT);
			upd.Touch(ObjectUpdate::UPDPLAYER);

			//Money
			upd.AddField(ObjectUpdate::UPDPLAYER, PLAYER_FIELD_COINAGE, ply->GetMoney());

			retpack.AddObjectUpdate(&upd);

			WorldServer::GetSingleton().WriteData(cli,&retpack);

			WorldServer::GetSingleton().AnnounceTo(cli,"[World-Server] - You Sold [ %s ] for %d of Copper",item->ItemDATA.name.c_str(),item->ItemDATA.SellPrice);

			retpack.Build(SMSG_DESTROY_OBJECT);
			retpack.AddQuadWord(pitem->GUID);

			WorldServer::GetSingleton().SendToPlayersInRange(&retpack,ply);

			if (pitem->Where == 1)
			{
				ply->UnEquip(Items_Handler::GetSingleton().FindItem(pitem->Entry));
			}
			
			Items_Handler::GetSingleton().DestroyItemByGUID(ply,pitem->GUID);
		}
	}
}
#endif

void NPC::QueryVendorItems(Mob *mob, Client *cli)
{
	Packet retpack;

	if (!mob)
		return;

	retpack.Build(SMSG_LIST_INVENTORY);
	retpack.AddQuadWord(mob->GetObjectGuid());
	retpack.AddByte((Byte)VendorsHandler::GetSingleton().CountItems(mob)); //ITEMS COUNT
		
	VendorsHandler::GetSingleton().BuildData(&retpack,mob);

	WorldServer::GetSingleton().WriteData(cli, &retpack);
}
#endif