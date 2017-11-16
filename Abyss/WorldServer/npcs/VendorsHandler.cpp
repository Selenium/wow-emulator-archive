// (c) AbyssX Group
#include "../WorldEnvironment.h"

#ifdef NPCS

template <class VendorsHandler> VendorsHandler *Singleton<VendorsHandler>::msSingleton = 0;

VendorsHandler::VendorsHandler()
{
}

VendorsHandler::~VendorsHandler()
{
}

void VendorsHandler::ParseChat(Player *ply, char *txt, Client *cli)
{
	char *line;

	if (strnicmp(txt, "add ", 4) == 0 && ply->IsGM())
	{
		line = txt + 4;

		Mob *mob = MonsterHandler::GetSingleton().FindMob(ply->GetTarget());

		if (mob)
		{
			if (AddVendorItems(line,mob->GetEntry()) == true)
			{
				VENDOR_DB *vitem = new VENDOR_DB();
	
				DoubleWord I_ENTRY = 0;
	
				sscanf(line, "%d %d", &I_ENTRY);
	
				vitem->IEntry = I_ENTRY;
				vitem->VEntry = mob->GetEntry();
	
				mVendorItems.push_back(vitem);
	
				WorldServer::GetSingleton().AnnounceTo(cli,"[World-Server] -> New Item Added to Vendor %s.",mob->	GetName().c_str());
			}
		}
	}
			
	else if (strnicmp(txt, "del ", 4) == 0 && ply->IsGM())
	{
		line = txt + 4;

		Mob *mob = MonsterHandler::GetSingleton().FindMob(ply->GetTarget());

		DoubleWord I_ENTRY = 0;

		sscanf(line,"%d",&I_ENTRY);

		if (mob)
		{
			if (DelVendorItems(mob->GetEntry(),I_ENTRY) == true)
			{
				DoubleWord found = 0;

				list<VENDOR_DB *>::iterator it;

				//EXCLUDING FROM THE LIST PROPERLY
				for (it = mVendorItems.begin();it != mVendorItems.end();it)
				{
					if ((*it)->IEntry == I_ENTRY)
					{
						delete *it;
						mVendorItems.erase(it++);
						found++;
					}
					else 
						it++;
				}
				//EXCLUDING FROM THE LIST PROPERLY

				if (found > 0)
				{
					WorldServer::GetSingleton().AnnounceTo(cli,"[World-Server] -> The Item Has Been Removed from the Vendor %s.",mob->GetName().c_str());
				}
				else
				{
					WorldServer::GetSingleton().AnnounceTo(cli,"[World-Server] -> Vendor Item Not Found!");
				}
			}
		}
	}
}

void VendorsHandler::LoadVendorItems()
{
	DoubleWord result;
	char *buffer;
	
	// Fetch the database connection.
	Database *ndb = Database::GetSingletonPtr();

	if (!ndb || !*ndb)
	{
		printf("Couldnt Connect in the Database!\n");
		return;
	}
	
	// Should be large enough for a query.
	if ((buffer = new char[2048]) == 0)
		return;

	snprintf(buffer, 2048, "SELECT * FROM vendor_items;");

	result = ndb->Query(buffer);

	DoubleWord count = 0;

	if (result == 1)
	{
		do
		{
			Field *Item = ndb->Fetch();

			VENDOR_DB *vitems = new VENDOR_DB();

			vitems->VEntry = atoi(Item[1].Value());		// ENTRY ID
			vitems->IEntry = atoi(Item[2].Value());		// DISPLAY ID

			mVendorItems.push_back(vitems);

			count++;

		} while (ndb->NextRow());
	}
	
	printf("[World-Server] - (%d)-> Vendor Items Loaded...\n",count);
	delete [] buffer;
}

bool VendorsHandler::DelVendorItems(DoubleWord ENTRY, DoubleWord I_ENTRY)
{
	char *buf;
	
	// Fetch the database connection.
	Database *ndb = Database::GetSingletonPtr();

	if (!ndb || !*ndb)
	{
		printf("Couldnt Connect in the Database!\n");
		return false;
	}
	
	// Should be large enough for a query.
	buf = new char[2048];  // should be large enough
	if (!buf)
		return false;

	snprintf(buf, 2048, "DELETE FROM vendor_items WHERE entry='%d' and item_entry='%d';", ENTRY, I_ENTRY);

	if(ndb->Query(buf))
	{
		delete [] buf;
		return true;
	}

	delete [] buf;

	return false;
}

bool VendorsHandler::AddVendorItems(string line, DoubleWord V_ENTRY)
{
	char *buf;

	DoubleWord I_ENTRY = 0;

	sscanf(line.c_str(), "%d", &I_ENTRY);
	
	// Fetch the database connection.
	Database *ndb = Database::GetSingletonPtr();

	if (!ndb || !*ndb)
	{
		printf("Couldnt Connect in the Database!\n");
		return false;
	}
	
	// Should be large enough for a query.
	buf = new char[2048];  // should be large enough
	if (!buf)
		return false;

	snprintf(buf, 2048, "INSERT INTO vendor_items VALUES ('0','%d','%d');", V_ENTRY, I_ENTRY);

	if(ndb->Query(buf))
	{
		delete [] buf;
		return true;
	}

	delete [] buf;

	return false;
}

DoubleWord VendorsHandler::CountItems(Mob *mob)
{
	list<VENDOR_DB *>::iterator it;

	DoubleWord count = 0;

	for (it = mVendorItems.begin();it != mVendorItems.end();it++)
	{
		if (mob->GetEntry() == (*it)->VEntry)
			count++;
	}

	return count;
}

void VendorsHandler::BuildData(Packet *retpack, Mob *mob)
{
	list<VENDOR_DB *>::iterator it;

	DoubleWord count = 1;

#ifdef ITEMS
	for (it = mVendorItems.begin();it != mVendorItems.end();it++)
	{
		if (mob->GetEntry() == (*it)->VEntry)
		{
			Item *item = Items_Handler::GetSingleton().FindItem((*it)->IEntry);

			if (!item)
				continue;

			//DATA LOOP
			retpack->AddDoubleWord(1);							// MUID
			retpack->AddDoubleWord((*it)->IEntry);				// ENTRY ID
			retpack->AddDoubleWord(item->ItemDATA.DisplayID);	// DISPLAY ID
			retpack->AddDoubleWord(1);							// QUANTITY
			retpack->AddDoubleWord(item->ItemDATA.BuyPrice);	// PRICE
			retpack->AddDoubleWord(0);							// NOT USED
			retpack->AddDoubleWord(0);							// STACK COUNT
			//DATA LOOP
		}
	}
#endif
}
#endif