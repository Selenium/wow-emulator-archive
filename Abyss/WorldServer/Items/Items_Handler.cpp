// (c) AbyssX Group
#include "../WorldEnvironment.h"

#ifdef ITEMS

template <class Items_Handler> Items_Handler *Singleton<Items_Handler>::msSingleton = 0;

Items_Handler::Items_Handler()
{
	mDebug = false;
}

Items_Handler::~Items_Handler()
{
}

DoubleWord Items_Handler::HandlePackets(Client *cli, Packet *pack)
{
	switch (pack->GetOpCode())
	{
		case CMSG_ITEM_QUERY_SINGLE:
			MSG_ITEM_QUERY_SINGLE(cli, pack);
			return 1;
			break;
		
		case CMSG_SWAP_INV_ITEM:
			MSG_SWAP_INV_ITEM(cli, pack);
			return 1;
			break;

		case CMSG_AUTOEQUIP_ITEM:
			MSG_AUTOEQUIP_ITEM(cli, pack);
			return 1;
			break;

		case CMSG_DESTROYITEM:
			MSG_DESTROYITEM(cli, pack);
			return 1;
			break;

		case CMSG_LOOT:
			MSG_LOOT(cli, pack);
			return 1;
			break;

		case CMSG_AUTOSTORE_LOOT_ITEM:
			MSG_AUTOSTORE_LOOT_ITEM(cli, pack);
			return 1;
			break;

		case CMSG_LOOT_RELEASE:
			MSG_LOOT_RELEASE(cli, pack);
			return 1;
			break;

		case CMSG_LOOT_MONEY:
			MSG_LOOT_MONEY(cli, pack);
			return 1;
			break;
	}
	return 0;
}

void Items_Handler::MSG_ITEM_QUERY_SINGLE(Client *cli, Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Packet retpack;
	DoubleWord ENTRY = 0;

	if (!ply)
		return;
	
	ENTRY = pack->GetDoubleWord(0x00);

	if(mDebug)
		printf("[World-Server] - Player %s Is Requesting Data Query of Item %d\n",ply->GetName().c_str(),ENTRY);

	if (QuerySingleItem(ENTRY,&retpack) == true)
	{
		WorldServer::GetSingleton().WriteData(cli,&retpack);
		if(mDebug)
			printf("[World-Server] - Item Data Sent to The Player!\n");
	}
}
void Items_Handler::MSG_SWAP_INV_ITEM(Client *cli, Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Packet retpack;

	if (!ply)
		return;

	DoubleWord SlotA = pack->GetByte(0x00);
	DoubleWord SlotB = pack->GetByte(0x01);

	if(mDebug)
		printf("[World-Server] - Moving Items from [SLOT:%d -> SLOT:%d]\n",SlotA,SlotB);

	MoveToSlot(ply,SlotA,SlotB);
}

void Items_Handler::MSG_AUTOEQUIP_ITEM(Client *cli, Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Packet retpack;

	if (!ply)
		return;

	DoubleWord SLOT = pack->GetByte(0x01);

	if(mDebug)
		printf("[World-Server] - AUTO EQUIPING ITEM FROM [SLOT:%d]\n",SLOT);
	
	MoveToSlot(ply,SLOT,1000);
}

void Items_Handler::MSG_DESTROYITEM(Client *cli, Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Packet retpack;

	if (!ply)
		return;

	DoubleWord SLOT = pack->GetByte(0x01);

	if(mDebug)
		printf("[World-Server] - DESTROYING ITEM FROM [SLOT:%d]\n",SLOT);
	
	DestroyItem(ply,SLOT);
}

void Items_Handler::MSG_LOOT(Client *cli, Packet *pack)
{
	Packet retpack;

	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);

	if (!ply)
		return;

	ply->SetLootTarget(pack->GetQuadWord(0x00));

	Mob *mob = MonsterHandler::GetSingleton().FindMob(pack->GetQuadWord(0x00));

	retpack.Build(SMSG_LOOT_RESPONSE);
	retpack.AddQuadWord(pack->GetQuadWord(0x00));
	retpack.AddByte(0x01);//Fishing Loot ? 0x03
	if(mob)
	{
		retpack.AddDoubleWord(mob->GetMoney());//Money
		retpack.AddDoubleWord(0x00);//Item Count
		/*
			BYTE Slot
			UINT ItemID
			UINT DisplayID
			UINT Quantity
			UINT Unk1
			UINT unk2
		*/
	}
	else
	{
		retpack.AddDoubleWord(0x00);
		retpack.AddDoubleWord(0x00);
	}

	WorldServer::GetSingleton().WriteData(cli,&retpack);
}

void Items_Handler::MSG_AUTOSTORE_LOOT_ITEM(Client *cli, Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Packet retpack;

	if (!ply)
		return;

	retpack.Build(SMSG_LOOT_REMOVED);
	WorldServer::GetSingleton().WriteData(cli,&retpack);
}

void Items_Handler::MSG_LOOT_RELEASE(Client *cli, Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Packet retpack;

	if (!ply)
		return;

	retpack.Build(SMSG_LOOT_RELEASE_RESPONSE);
	retpack.AddQuadWord(pack->GetQuadWord(0x00));
	retpack.AddByte(0x01);

	WorldServer::GetSingleton().WriteData(cli,&retpack);

	retpack.Build(SMSG_LOOT_REMOVED);
	WorldServer::GetSingleton().WriteData(cli,&retpack);
}

void Items_Handler::MSG_LOOT_MONEY(Client *cli, Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Packet retpack;
	ObjectUpdate upd;

	if (!ply)
		return;

	Mob *mob = MonsterHandler::GetSingleton().FindMob(ply->GetLootTarget());

	if (mob)
	{
		if (ply->GetParty())
		{
#ifdef GROUPS
			GroupsHandler::GetSingleton().ShareMONEY(ply,mob->GetMoney());
#endif
			mob->SetMoney(0);
		}
		else
		{
			retpack.Build(SMSG_LOOT_MONEY_NOTIFY);
			retpack.AddDoubleWord(mob->GetMoney());

			WorldServer::GetSingleton().WriteData(cli,&retpack);

			ply->SetMoney(ply->GetMoney() + mob->GetMoney());
			mob->SetMoney(0);

			Packets::UpdateObjectHeader(ply,&retpack);

			upd.Clear();
			upd.Touch(ObjectUpdate::UPDOBJECT);
			upd.Touch(ObjectUpdate::UPDUNIT);
			upd.Touch(ObjectUpdate::UPDPLAYER);

			//Money
			upd.AddField(ObjectUpdate::UPDPLAYER, PLAYER_FIELD_COINAGE, ply->GetMoney());

			retpack.AddObjectUpdate(&upd);

			WorldServer::GetSingleton().WriteData(cli,&retpack);
		}
	}
}

bool Items_Handler::QuerySingleItem(DoubleWord ENTRY, Packet *retpack)
{
	Item *item = FindItem(ENTRY);

	if (!item)
	{
		if(mDebug)
			printf("[World-Server] - Item Not Found!\n");
		return false;
	}
	
	if(mDebug)
		printf("[World-Server] - Item Found!\n");

	retpack->Build(SMSG_ITEM_QUERY_SINGLE_RESPONSE);

	retpack->AddDoubleWord(item->ItemDATA.Entry);							// Item Database Entry
	retpack->AddDoubleWord(item->ItemDATA.Type);							// Item Class
	retpack->AddDoubleWord(item->ItemDATA.Subtype);							// Item SubClass

	retpack->AddBytes((Byte *)item->ItemDATA.name.c_str(),
		(Word)item->ItemDATA.name.size());									// Item Name
	retpack->AddByte(0x00);													// Null Byte

	retpack->AddBytes((Byte *)item->ItemDATA.name.c_str(),
		(Word)item->ItemDATA.name.size());									// Item Name
	retpack->AddByte(0x00);													// Null Byte

	retpack->AddBytes((Byte *)item->ItemDATA.name.c_str(),
		(Word)item->ItemDATA.name.size());									// Item Name
	retpack->AddByte(0x00);													// Null Byte

	retpack->AddBytes((Byte *)item->ItemDATA.name.c_str(),
		(Word)item->ItemDATA.name.size());									// Item Name
	retpack->AddByte(0x00);													// Null Byte

	retpack->AddDoubleWord(item->ItemDATA.DisplayID);						// Model ID

	retpack->AddDoubleWord(item->ItemDATA.OverallQuality);					// Quality ID

	retpack->AddDoubleWord(item->ItemDATA.Flags);							// Flags
	retpack->AddDoubleWord(item->ItemDATA.BuyPrice);						// Buy Price
	retpack->AddDoubleWord(item->ItemDATA.SellPrice);						// Sell Price
 
	retpack->AddDoubleWord(item->ItemDATA.InvType);							// Inventory Type

	retpack->AddDoubleWord(item->ItemDATA.AllowableClass);					// Req Character Class
	retpack->AddDoubleWord(item->ItemDATA.AllowableRace);					// Req Character Race

	retpack->AddDoubleWord(item->ItemDATA.Level);							// Level
	retpack->AddDoubleWord(item->ItemDATA.LevelReq);						// Level REQ

	retpack->AddDoubleWord(item->ItemDATA.SkillReq);						// Skill REQ
	retpack->AddDoubleWord(item->ItemDATA.MinSkillReq);						// Skill Level REQ
	retpack->AddDoubleWord(item->ItemDATA.ItemUnique);						// Item Unique
	retpack->AddDoubleWord(item->ItemDATA.MaxStack);						// Max Stack
	retpack->AddDoubleWord(item->ItemDATA.ContainerSlots);					// Container Slots


	for (int a = 0; a < 10;a++)
	{
		retpack->AddDoubleWord(item->ItemDATA.Attributes[a].ID);			// Item Attributes
		retpack->AddDoubleWord(item->ItemDATA.Attributes[a].Value);			// Item Attributes
	}

	for (int b = 0; b < 5;b++)
	{
		retpack->AddDoubleWord(item->ItemDATA.DamageStats[b].Min);			// Minimum Damage
		retpack->AddDoubleWord(item->ItemDATA.DamageStats[b].Max);			// Maximum Damage
		retpack->AddDoubleWord(item->ItemDATA.DamageStats[b].Type);			// Damage Type
	}

	retpack->AddDoubleWord(item->ItemDATA.ResistPhysical);					// Physical (Bonus) "Armor"
	retpack->AddDoubleWord(item->ItemDATA.ResistHoly);						// Holy (BONUS)
	retpack->AddDoubleWord(item->ItemDATA.ResistFire);						// Fire (BONUS)
	retpack->AddDoubleWord(item->ItemDATA.ResistNature);					// Nature (BONUS)
	retpack->AddDoubleWord(item->ItemDATA.ResistFrost);						// Frost (BONUS)
	retpack->AddDoubleWord(item->ItemDATA.ResistShadow);					// Shadow (BONUS)
	retpack->AddDoubleWord(item->ItemDATA.WeaponSpeed);						// Item Attack Speed.
	retpack->AddDoubleWord(item->ItemDATA.AmmoType);						// Ammo Type
	retpack->AddDoubleWord(item->ItemDATA.MaxDurability);					// Max Durability

	for (int c = 0; c < 5;c++)												// Spell Info
	{
		retpack->AddDoubleWord(item->ItemDATA.SpellStats[c].Category);
		retpack->AddDoubleWord(item->ItemDATA.SpellStats[c].CategoryCoolDown);
		retpack->AddDoubleWord(item->ItemDATA.SpellStats[c].Charges);
		retpack->AddDoubleWord(item->ItemDATA.SpellStats[c].Cooldown);
		retpack->AddDoubleWord(item->ItemDATA.SpellStats[c].ID);
		retpack->AddDoubleWord(item->ItemDATA.SpellStats[c].Trigger);
	}

	retpack->AddDoubleWord(item->ItemDATA.Bonding);						    // Bonding

	retpack->AddBytes((Byte *)item->ItemDATA.description.c_str(),
		(Word)item->ItemDATA.description.size());							// Item Description
	retpack->AddByte(0x00);													// Null Byte

	retpack->AddDoubleWord(item->ItemDATA.PageText);						// PageText
	retpack->AddDoubleWord(item->ItemDATA.LanguageID);						// Language ID
	retpack->AddDoubleWord(item->ItemDATA.PageMaterial);					// Page Material;
	retpack->AddDoubleWord(item->ItemDATA.StartQuest);						// Start Quest
	retpack->AddDoubleWord(item->ItemDATA.Lock);							// Lock
	retpack->AddDoubleWord(item->ItemDATA.Material);						// Material
	retpack->AddDoubleWord(item->ItemDATA.SheatheType);						// SheAtTheType;
	retpack->AddDoubleWord(item->ItemDATA.Unknown);							// Unknown
	retpack->AddDoubleWord(item->ItemDATA.UnknownBeta2);					// Unknown 

	return true;
}

bool Items_Handler::LoadDB_Items()
{
	int result;
	char *buffer;
	DoubleWord count = 0;
	
	// Fetch the database connection.
	Database *idb = Database::GetSingletonPtr();

	if (!idb || !*idb)
	{
		printf("Couldnt Connect in the Database!\n");
		return false;
	}
	
	// Should be large enough for a query.
	if ((buffer = new char[2048]) == 0)
		return false;

	snprintf(buffer, 2048, "SELECT * FROM items;");

	result = idb->Query(buffer);

	if (result == 1)
	{
		do
		{
		
		Item *item = new Item();

		Field *fields = idb->Fetch();

		item->ItemDATA.Entry = atoi(fields[1].Value());
		item->ItemDATA.Type =  atoi(fields[2].Value());
		item->ItemDATA.Subtype = atoi(fields[3].Value());
		item->ItemDATA.name = fields[4].Value();
		item->ItemDATA.description = fields[5].Value();
		item->ItemDATA.DisplayID = atoi(fields[6].Value());
		item->ItemDATA.InvType = atoi(fields[7].Value());
		//item->ItemDATA.AllowableClass = atoi(fields[8].Value());
		//item->ItemDATA.AllowableRace = atoi(fields[9].Value());
		item->ItemDATA.AllowableClass = -1;
		item->ItemDATA.AllowableRace = -1;
		item->ItemDATA.Level = atoi(fields[10].Value());
		item->ItemDATA.LevelReq = atoi(fields[11].Value());
		item->ItemDATA.SkillReq = atoi(fields[12].Value());
		item->ItemDATA.MinSkillReq = atoi(fields[13].Value());
		item->ItemDATA.OverallQuality = atoi(fields[14].Value());
		item->ItemDATA.DamageStats[0].Min = atoi(fields[15].Value());
		item->ItemDATA.DamageStats[0].Max = atoi(fields[16].Value());
		item->ItemDATA.DamageStats[0].Type = 0;
		item->ItemDATA.ResistPhysical = atoi(fields[17].Value());
		item->ItemDATA.ResistHoly = atoi(fields[18].Value());
		item->ItemDATA.ResistFire = atoi(fields[19].Value());
		item->ItemDATA.ResistNature = atoi(fields[20].Value());
		item->ItemDATA.ResistFrost = atoi(fields[21].Value());
		item->ItemDATA.ResistShadow = atoi(fields[22].Value());
		item->ItemDATA.WeaponSpeed = atoi(fields[23].Value());
		item->ItemDATA.BuyPrice = atoi(fields[24].Value());
		item->ItemDATA.StartQuest = 0;

		if(item->ItemDATA.InvType == 14)
			item->ItemDATA.SheatheType = SHEATHETYPE_SHIELD;

		if(item->ItemDATA.InvType == 21)
			item->ItemDATA.SheatheType = SHEATHETYPE_LARGEWEAPONLEFT;
		
		int sp = item->ItemDATA.BuyPrice/2;
		if (sp > 0)
			item->ItemDATA.SellPrice = sp;
		else
			item->ItemDATA.SellPrice = 1;

		mItem.push_back(item);

		count++;

		} while (idb->NextRow());

		printf("[World-Server] - (%d)-> Custom Items Loaded...\n",count);

		delete [] buffer;
		return true;
	}
	
	printf("[World-Server] - (%d)-> Custom Items Loaded...\n",count);
	delete [] buffer;
	return false;
}

bool Items_Handler::LoadStarting_Items()
{
	int result;
	char *buffer;
	DoubleWord count = 0;
	
	// Fetch the database connection.
	Database *idb = Database::GetSingletonPtr();

	if (!idb || !*idb)
	{
		printf("Couldnt Connect in the Database!\n");
		return false;
	}
	
	// Should be large enough for a query.
	if ((buffer = new char[2048]) == 0)
		return false;

	snprintf(buffer, 2048, "SELECT * FROM startingitems;");

	result = idb->Query(buffer);

	if (result == 1)
	{
		do
		{
		
		Item *item = new Item();

		Field *fields = idb->Fetch();

		item->ItemDATA.Entry = atoi(fields[1].Value());
		item->ItemDATA.Type =  atoi(fields[2].Value());
		item->ItemDATA.Subtype = atoi(fields[3].Value());
		item->ItemDATA.name = fields[4].Value();
		item->ItemDATA.description = fields[5].Value();
		item->ItemDATA.DisplayID = atoi(fields[6].Value());
		item->ItemDATA.InvType = atoi(fields[7].Value());
		//item->ItemDATA.AllowableClass = atoi(fields[8].Value());
		//item->ItemDATA.AllowableRace = atoi(fields[9].Value());
		item->ItemDATA.AllowableClass = -1;
		item->ItemDATA.AllowableRace = -1;
		item->ItemDATA.Level = atoi(fields[10].Value());
		item->ItemDATA.LevelReq = atoi(fields[11].Value());
		item->ItemDATA.SkillReq = atoi(fields[12].Value());
		item->ItemDATA.MinSkillReq = atoi(fields[13].Value());
		item->ItemDATA.OverallQuality = atoi(fields[14].Value());
		item->ItemDATA.DamageStats[0].Min = atoi(fields[15].Value());
		item->ItemDATA.DamageStats[0].Max = atoi(fields[16].Value());
		item->ItemDATA.DamageStats[0].Type = 0;
		item->ItemDATA.ResistPhysical = atoi(fields[17].Value());
		item->ItemDATA.ResistHoly = atoi(fields[18].Value());
		item->ItemDATA.ResistFire = atoi(fields[19].Value());
		item->ItemDATA.ResistNature = atoi(fields[20].Value());
		item->ItemDATA.ResistFrost = atoi(fields[21].Value());
		item->ItemDATA.ResistShadow = atoi(fields[22].Value());
		item->ItemDATA.WeaponSpeed = atoi(fields[23].Value());
		item->ItemDATA.BuyPrice = atoi(fields[24].Value());
		item->ItemDATA.StartQuest = 0;

		if(item->ItemDATA.InvType == 14)
			item->ItemDATA.SheatheType = SHEATHETYPE_SHIELD;

		if(item->ItemDATA.InvType == 21)
			item->ItemDATA.SheatheType = SHEATHETYPE_LARGEWEAPONLEFT;
		
		int sp = item->ItemDATA.BuyPrice/2;
		if (sp > 0)
			item->ItemDATA.SellPrice = sp;
		else
			item->ItemDATA.SellPrice = 1;

		mItem.push_back(item);

		count++;

		} while (idb->NextRow());

		printf("[World-Server] - (%d)-> Starting Items Loaded...\n",count);

		delete [] buffer;
		return true;
	}
	
	printf("[World-Server] - (%d)-> Starting Items Loaded...\n",count);
	delete [] buffer;
	return false;
}

void Items_Handler::ParseChat(QuadWord GUID, Client *Cli, Player *Ply, char *line)
{
	char *txt;

	if (strnicmp(line, "get ", 4) == 0)
	{
		txt = line + 4;
		DoubleWord ENTRY = 0;

		sscanf(txt,"%d",&ENTRY);

		if (FindItem(ENTRY) != NULL)
			ItemUpdate(ENTRY,GUID,Ply,Cli);
	}
}

int GetSlotByType[WORN_NUM_TYPES] = {
	SLOT_INBACKPACK, // NONE EQUIP
		SLOT_HEAD,
		SLOT_NECK,
		SLOT_SHOULDERS,
		SLOT_SHIRT,
		SLOT_CHEST,
		SLOT_WAIST,
		SLOT_LEGS,
		SLOT_FEET,
		SLOT_WRISTS,
		SLOT_HANDS,
		SLOT_FINGERL,
		SLOT_TRINKETL,
		SLOT_MAINHAND, // 1h
		SLOT_OFFHAND, // shield
		SLOT_RANGED,
		SLOT_BACK,
		SLOT_MAINHAND, // 2h
		SLOT_BAG1,
		SLOT_TABARD,
		SLOT_CHEST, // ROBE
		SLOT_MAINHAND, // mainhand
		SLOT_OFFHAND, // offhand
		SLOT_MAINHAND, // held
		SLOT_INBACKPACK, // ammo
		SLOT_RANGED, // thrown
		SLOT_RANGED // rangedright
};

void Items_Handler::MoveToSlot(Player *ply, Word SlotA, Word SlotB)
{
	Word A = SlotA; //SOURCE
	Word B = SlotB; //DESTINY

	if (B != 1000)
	{
		if (A <= 19)
		{
			if (B <= 19)
			{
				Player_Item *pitem = ply->FindPlayerItem(ply->GetInventory(A));
	
				if (pitem)
				{
					Item *item = FindItem(pitem->Entry);

					//Checks if there is a Item in The Wanted Slot...
					if (ply->GetInventory(B) != 0x00)
					{
						SendInventory(ply->GetClient(), B, A, 3, false, true, 0, 1, NULL);
						SendInventory(ply->GetClient(), B, A, 1, false, true, 0, 1, NULL);
						return;
					}

					ply->SetInventory( A, 0x00);
					ply->SetInventory( B, pitem->GUID);

					pitem->CurrentSlot = B;
					pitem->Where = 1;

					ply->Equip(item);
	
					SendInventory(ply->GetClient(), B, A, 1, false, true, 0, 1, NULL);
				}
			}
	
			if (B >= 23 && B <= 39)
			{
				B = (B-23);
				
				Player_Item *pitem = ply->FindPlayerItem(ply->GetInventory(A));
	
				if (pitem)
				{
					Item *item = FindItem(pitem->Entry);

					//Checks if there is a Item in The Wanted Slot...
					if (ply->GetBackPack(B) != 0x00)
					{
						SendInventory(ply->GetClient(), B, A, 4, false, true, 0, 1, NULL);
						SendInventory(ply->GetClient(), B, A, 2, false, true, 0, 1, NULL);
						return;
					}

					ply->SetInventory( A, 0x00);				
					ply->SetBackPack( B, pitem->GUID);

					pitem->CurrentSlot = B;
					pitem->Where = 2;

					ply->UnEquip(item);
	
					SendInventory(ply->GetClient(), B, A, 2, false, true, 0, 1, NULL);
				}
			}
		}
	
		else if (A >= 23 && A <= 39)
		{
			if (B <= 19)
			{
				A = (A-23);
					
				Player_Item *pitem = ply->FindPlayerItem(ply->GetBackPack(A));
	
				if (pitem)
				{
					Item *item = FindItem(pitem->Entry);

					//Checks if there is a Item in The Wanted Slot...
					if (ply->GetInventory(B) != 0x00)
					{
						SendInventory(ply->GetClient(), B, A, 3, false, true, 1, 1, NULL);
						SendInventory(ply->GetClient(), B, A, 1, false, true, 1, 1, NULL);
						return;
					}

					ply->SetBackPack( A, 0x00);
					ply->SetInventory( B, pitem->GUID);

					pitem->CurrentSlot = B;
					pitem->Where = 1;

					SendInventory(ply->GetClient(), B, A, 1, false, true, 1, 1, NULL);

					ply->Equip(item);
				}
			}
	
			if (B >= 23 && B <= 39)
			{
				A = (A-23);
				B = (B-23);
				
				Player_Item *pitem = ply->FindPlayerItem(ply->GetBackPack(A));
	
				if (pitem)
				{
					Item *item = FindItem(pitem->Entry);

					//Checks if there is a Item in The Wanted Slot...
					if (ply->GetBackPack(B) != 0x00)
					{
						SendInventory(ply->GetClient(), B, A, 4, false, true, 1, 1, NULL);
						SendInventory(ply->GetClient(), B, A, 2, false, true, 1, 1, NULL);
						return;
					}

					ply->SetBackPack( A, 0x00);				
					ply->SetBackPack( B, pitem->GUID);

					pitem->CurrentSlot = B;
					pitem->Where = 2;
	
					SendInventory(ply->GetClient(), B, A, 2, false, true, 1, 1, NULL);
				}
			}
		}
	}

	if (B == 1000)
	{
		if (A >= 23 && A <= 39)
		{
			A = (A-23);

			Player_Item *pitem = ply->FindPlayerItem(ply->GetBackPack(A));

			if (pitem)
			{
				Item *item = FindItem(pitem->Entry);
					
				if (item)
				{
					B = GetSlotByType[item->ItemDATA.InvType];

					if (B <= 19)
					{

						Player_Item *pitem = ply->FindPlayerItem(ply->GetBackPack(A));
				
						if (pitem)
						{
							Item *item = FindItem(pitem->Entry);

							//Checks if there is a Item in The Wanted Slot...
							if (ply->GetInventory(B) != 0x00)
							{
								SendInventory(ply->GetClient(), B, A, 3, false, true, 1, 1, NULL);
								SendInventory(ply->GetClient(), B, A, 1, false, true, 1, 1, NULL);
								return;
							}
				
							ply->SetBackPack( A, 0x00);
							ply->SetInventory( B, pitem->GUID);

							pitem->CurrentSlot = B;
							pitem->Where = 1;
					
							SendInventory(ply->GetClient(), B, A, 1, false, true, 1, 1, NULL);

							ply->Equip(item);
						}
					}
				}
			}
		}
	}

}

void Items_Handler::DestroyItem(Player *ply, Word SLOT)
{
	Packet retpack;

	Word A = SLOT; //SOURCE

	if (A <= 19)
	{
		Player_Item *pitem = ply->FindPlayerItem(ply->GetInventory(A));

		if (pitem)
		{
			Item *item = FindItem(pitem->Entry);

			if (item)
			{
				ply->UnEquip(item);

				ply->SetInventory(A, 0x00);

				SendInventory(ply->GetClient(), 0, A, 1, false, true, 0, 1, NULL);

				retpack.Build(SMSG_DESTROY_OBJECT);
				retpack.AddQuadWord(pitem->GUID);
				WorldServer::GetSingleton().SendToPlayersInRange(&retpack,ply);

				DestroyItemByGUID(ply,pitem->GUID);
			}
		}
	}

	if (A >= 23 && A <= 39)
	{
		A = (A-23);

		Player_Item *pitem = ply->FindPlayerItem(ply->GetBackPack(A));

		if (pitem)
		{
			Item *item = FindItem(pitem->Entry);

			ply->SetBackPack(A, 0x00);

			SendInventory(ply->GetClient(), 0, A, 1, false, true, 1, 1, NULL);

			retpack.Build(SMSG_DESTROY_OBJECT);
			retpack.AddQuadWord(pitem->GUID);
			WorldServer::GetSingleton().SendToPlayersInRange(&retpack,ply);

			DestroyItemByGUID(ply,pitem->GUID);
		}
	}
}

void Items_Handler::DestroyItemByGUID(Player *ply, QuadWord GUID)
{
	Packet retpack;

	Player_Item *pitem = ply->FindPlayerItem(GUID);

	if (pitem)
	{
		Word B = pitem->CurrentSlot;

		B = (B);

		if (pitem)
		{
			Item *item = FindItem(pitem->Entry);
			
			if (pitem->Where == 2)
				ply->SetBackPack( B, 0x00);
			if (pitem->Where == 1)
				ply->SetInventory( B, 0x00);

			if (pitem->Where == 2)
				SendInventory(ply->GetClient(), 0, B, 2, false, true, 1, 1, NULL);
			if (pitem->Where == 1)
				SendInventory(ply->GetClient(), 0, B, 2, false, true, 0, 1, NULL);

			retpack.Build(SMSG_DESTROY_OBJECT);
			retpack.AddQuadWord(pitem->GUID);
			WorldServer::GetSingleton().SendToPlayersInRange(&retpack,ply);

			ply->DeletePlayerItem(pitem->GUID);

		}
	}
}

Word Items_Handler::ItemUpdate(DoubleWord ENTRY, QuadWord GUID, Player *ply, Client *cli)
{
	Packet retpack;

	Player_Item *pitem = new Player_Item();

	Item *item = FindItem(ENTRY);

	pitem->Entry = ENTRY;
	pitem->GUID = GUID;
	pitem->OwnerGuid = ply->GetObjectGuid();
	pitem->Where = 2;

	Word SLOT = ply->GetSlot();

	if(SLOT == 100)
	{
		WorldServer::GetSingleton().AnnounceTo(cli,"[World-Server] - Your BackPack is FULL...");
		return 10;
	}

	pitem->SlotNumber = SLOT;
	pitem->CurrentSlot = SLOT;

	ply->SetBackPack(pitem->SlotNumber, pitem->GUID);

	ply->NewPlayerItem(pitem);

	Packets::NewItemHeader(pitem,&retpack);
	Packets::NewItemData(pitem,&retpack);

	WorldServer::GetSingleton().SendToPlayersInRange(&retpack,ply);

	SendInventory(cli,pitem->SlotNumber,0,2,false,false,0,0, NULL);

	return 0;
}

void Items_Handler::SendInventory(Client *cli, Word SA, Word SB, Word mode,
								  bool stats, bool del, Word X, Word PMode, Player *ply2)
{
	Packet retpack;
	ObjectUpdate objupd;

	Player *ply;

	if (ply2)
		ply = ply2;
	else
		ply = PlayersHandler::GetSingleton().FindPlayer(cli);

	Packets::UpdateObjectHeader(ply,&retpack);
			
	objupd.Clear();
	objupd.Touch(ObjectUpdate::UPDOBJECT);
	objupd.Touch(ObjectUpdate::UPDUNIT);
	objupd.Touch(ObjectUpdate::UPDPLAYER);

	if (stats == true)
	{
		for (Word Inventory = 0; Inventory < 19; Inventory++)
		{
			QuadWord INV = ply->GetInventory(Inventory);
	
			if (INV != 0x00)
			{
				objupd.AddField(ObjectUpdate::UPDPLAYER, (Inventory*2 + 12), (DoubleWord)(INV >> 0));
				objupd.AddField(ObjectUpdate::UPDPLAYER, (Inventory*2 + 13), (DoubleWord)(INV >> 32));
			}
		}

		for (Word BackPack = 0; BackPack < 16; BackPack++)
		{
			QuadWord BKP = ply->GetBackPack(BackPack);
	
			if (BKP != 0x00)
			{
				objupd.AddField(ObjectUpdate::UPDPLAYER, (BackPack*2 + 58), (DoubleWord)(BKP >> 0));
				objupd.AddField(ObjectUpdate::UPDPLAYER, (BackPack*2 + 59), (DoubleWord)(BKP >> 32));
			}
		}
	}

	else

	{

		if (mode == 1)
		{
			QuadWord INV = ply->GetInventory(SA);

			if (INV != 0x00)
			{
				objupd.AddField(ObjectUpdate::UPDPLAYER, (SA*2 + 12), (DoubleWord)(INV >> 0));
				objupd.AddField(ObjectUpdate::UPDPLAYER, (SA*2 + 13), (DoubleWord)(INV >> 32));
			}
			
			if (del == true)
			{
				if (X == 0)
				{
					QuadWord DEL = ply->GetInventory(SB);

					objupd.AddField(ObjectUpdate::UPDPLAYER, (SB*2 + 12), (DoubleWord)(DEL >> 0));
					objupd.AddField(ObjectUpdate::UPDPLAYER, (SB*2 + 13), (DoubleWord)(DEL >> 32));
				}

				else if (X == 1)
				{
					QuadWord DEL = ply->GetBackPack(SB);

					objupd.AddField(ObjectUpdate::UPDPLAYER, (SB*2 + 58), (DoubleWord)(DEL >> 0));
					objupd.AddField(ObjectUpdate::UPDPLAYER, (SB*2 + 59), (DoubleWord)(DEL >> 32));
				}
			}
		}

		else if (mode == 2)
		{
			QuadWord BKP = ply->GetBackPack(SA);

			if (BKP != 0x00)
			{
				objupd.AddField(ObjectUpdate::UPDPLAYER, (SA*2 + 58), (DoubleWord)(BKP >> 0));
				objupd.AddField(ObjectUpdate::UPDPLAYER, (SA*2 + 59), (DoubleWord)(BKP >> 32));
			}

			if (del == true)
			{
				if (X == 0)
				{
					QuadWord DEL = ply->GetInventory(SB);

					objupd.AddField(ObjectUpdate::UPDPLAYER, (SB*2 + 12), (DoubleWord)(DEL >> 0));
					objupd.AddField(ObjectUpdate::UPDPLAYER, (SB*2 + 13), (DoubleWord)(DEL >> 32));
				}

				else if (X == 1)
				{
					QuadWord DEL = ply->GetBackPack(SB);

					objupd.AddField(ObjectUpdate::UPDPLAYER, (SB*2 + 58), (DoubleWord)(DEL >> 0));
					objupd.AddField(ObjectUpdate::UPDPLAYER, (SB*2 + 59), (DoubleWord)(DEL >> 32));
				}
			}
		}
	
		else if (mode == 3)
		{

			objupd.AddField(ObjectUpdate::UPDPLAYER, (SA*2 + 12), 0);
			objupd.AddField(ObjectUpdate::UPDPLAYER, (SA*2 + 13), 0);
			
			if (del == true)
			{
				if (X == 0)
				{

					objupd.AddField(ObjectUpdate::UPDPLAYER, (SB*2 + 12), 0);
					objupd.AddField(ObjectUpdate::UPDPLAYER, (SB*2 + 13), 0);
				}

				else if (X == 1)
				{
					objupd.AddField(ObjectUpdate::UPDPLAYER, (SB*2 + 58), 0);
					objupd.AddField(ObjectUpdate::UPDPLAYER, (SB*2 + 59), 0);
				}
			}
		}

		else if (mode == 4)
		{
			objupd.AddField(ObjectUpdate::UPDPLAYER, (SA*2 + 58), 0);
			objupd.AddField(ObjectUpdate::UPDPLAYER, (SA*2 + 59), 0);

			if (del == true)
			{
				if (X == 0)
				{
					objupd.AddField(ObjectUpdate::UPDPLAYER, (SB*2 + 12), 0);
					objupd.AddField(ObjectUpdate::UPDPLAYER, (SB*2 + 13), 0);
				}

				else if (X == 1)
				{
					objupd.AddField(ObjectUpdate::UPDPLAYER, (SB*2 + 58), 0);
					objupd.AddField(ObjectUpdate::UPDPLAYER, (SB*2 + 59), 0);
				}
			}
		}
	
	}


	retpack.AddObjectUpdate(&objupd);
	
	if (PMode == 0)
		WorldServer::GetSingleton().WriteData(cli,&retpack);
	else if (PMode == 1)
		WorldServer::GetSingleton().SendToPlayersInRange(&retpack,ply);
}

Item* Items_Handler::FindItem(DoubleWord ENTRY)
{
	list<Item *>::iterator it;

	for (it = mItem.begin(); it != mItem.end(); it++)
	{
		if ((*it)->ItemDATA.Entry == ENTRY)
		{
			return (*it);
			break;
		}
	}

	return NULL;
}

DoubleWord Items_Handler::GetStartingSlotByType(DoubleWord TYPE)
{
	return GetSlotByType[TYPE];
}

#endif