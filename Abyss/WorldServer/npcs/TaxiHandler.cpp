// (c) AbyssX Group
#include "../WorldEnvironment.h"

#ifdef NPCS

template <class TaxiHandler> TaxiHandler *Singleton<TaxiHandler>::msSingleton = 0;

TaxiHandler::TaxiHandler()
{
}

TaxiHandler::~TaxiHandler()
{
}

void StopFlying(void *Param)
{
	Player *ply = (Player *)Param;
	ply->SetFlying(false);
	ply->Mount();
	ply->UnROOT();
	PlayersHandler::GetSingleton().MoveTroughRegion(ply);
	WorldServer::GetSingleton().AnnounceTo(ply->GetClient(),"[World-Server] - Travel Finished!");
}

DoubleWord TaxiHandler::HandlePackets(Client *cli, Packet *pack)
{
	switch (pack->GetOpCode())
	{
		case CMSG_TAXINODE_STATUS_QUERY:
			HandlerMSG_TAXINODE_STATUS_QUERY(cli, pack);
			return 1;
			break;

		case CMSG_TAXIQUERYAVAILABLENODES:
			HandlerMSG_TAXIQUERYAVAILABLENODES(cli, pack);
			return 1;
			break;

		case CMSG_ACTIVATETAXI:
			HandlerMSG_ACTIVATETAXI(cli, pack);
			return 1;
			break;
	}

	return 0;
}

void TaxiHandler::HandlerMSG_TAXINODE_STATUS_QUERY(Client *cli, Packet *pack)
{
	Packet retpack;
	Mob *mob = MonsterHandler::GetSingleton().FindMob(pack->GetQuadWord(0x00));
	
	if (mob)
	{
		//Initializing Taxi Vendor...
		retpack.Build(SMSG_TAXINODE_STATUS);
		retpack.AddQuadWord(mob->GetObjectGuid());
		retpack.AddByte(0);
		WorldServer::GetSingleton().WriteData(cli,&retpack);
	}
}

void TaxiHandler::HandlerMSG_TAXIQUERYAVAILABLENODES(Client *cli, Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);

	if (!ply)
		return;

	Packet retpack;
	Mob *mob = MonsterHandler::GetSingleton().FindMob(pack->GetQuadWord(0x00));
	
	DoubleWord NODE = GetNearNode(ply);
	DoubleWord MASK = GetTaxiMask(NODE);
	
	if (mob)
	{
		retpack.Build(SMSG_SHOWTAXINODES);

		retpack.AddDoubleWord(1);

		retpack.AddQuadWord(mob->GetObjectGuid());

		retpack.AddDoubleWord(NODE);

		retpack.AddDoubleWord(( MASK | (1<<(NODE-1)) ) << 0);
		retpack.AddDoubleWord(( MASK | (1<<(NODE-1)) ) << 0);

		retpack.AddDoubleWord(( MASK | (1<<(NODE-1)) ) << 0);
		retpack.AddDoubleWord(( MASK | (1<<(NODE-1)) ) << 0);

		WorldServer::GetSingleton().WriteData(cli,&retpack);
	}
}

void TaxiHandler::HandlerMSG_ACTIVATETAXI(Client *cli, Packet *pack)
{	
	Packet retpack;
	Mob *mob = MonsterHandler::GetSingleton().FindMob(pack->GetQuadWord(0x00));	
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);

	list<TaxiPathNodes *>::iterator it;
	list<TaxiPaths *>::iterator its;
	Player::PlayersCreatedIterator i;

	DoubleWord Count = 0;
	DoubleWord SpeedFactor = 32;

	DoubleWord Path = GetPath(pack->GetDoubleWord(0x08), pack->GetDoubleWord(0x0C));

	if (!ply)
		return;

	for(its = mTaxiPaths.begin(); its != mTaxiPaths.end(); its++)
	{
		if ((*its)->ID == Path)
		{
			if(ply->GetMoney() >= (*its)->Price)
			{
				ply->SetMoney(ply->GetMoney() - (*its)->Price);

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

				WorldServer::GetSingleton().AnnounceTo(cli,"[World-Server] - You have paid %d Copper for the Travel!",(*its)->Price);
			}
			else
			{
				WorldServer::GetSingleton().AnnounceTo(cli,"[World-Server] - You dont have enough money to Travel!");
				return;
			}
		}
	}
	
	ply->SetFlying(true);
	ply->Mount();
	ply->ROOT();

	retpack.Build(SMSG_ACTIVATETAXIREPLY);
	retpack.AddDoubleWord(0x00);
	WorldServer::GetSingleton().WriteData(cli, &retpack);

	for(it = mTaxiPathNodes.begin(); it != mTaxiPathNodes.end(); it++)
	{
		if ((*it)->PathID == Path)
			Count++;
	}

	if (Count > 0)
	{

		PathNode *p = new PathNode[Count];

		DoubleWord loop = 0;

		float len = 0, xd, yd, zd;

		//printf("[World-Server] - Current PathID Selected: %d",Path);
		
		//printf("[World-Server] - Loading Path Nodes:");
		for(it = mTaxiPathNodes.begin(); it != mTaxiPathNodes.end(); it++)
		{
			if ((*it)->PathID == Path)
			{
				p[loop].x = (*it)->X;
				p[loop].y = (*it)->Y;
				p[loop].z = (*it)->Z;

				//printf("[World-Server] - INDEX: %d X: %f Y: %f Z: %f\n",(*it)->Index,(*it)->X,(*it)->Y,(*it)->Z);
	
				loop++;
			}
		}

		for( DoubleWord a = 1; a < loop; a ++ ) 
		{
			xd = p[ a ].x - p[ a-1 ].x;
			yd = p[ a ].y - p[ a-1 ].y;
			zd = p[ a ].z - p[ a-1 ].z;
			len += (float)sqrt( xd * xd + yd*yd + zd*zd );
		}

		DoubleWord Lenght = (DoubleWord)len;

		DoubleWord TravelTime = Lenght * SpeedFactor;
	
		retpack.Build(SMSG_MONSTER_MOVE);
		retpack.AddQuadWord(ply->GetObjectGuid());
		retpack.AddFloat(ply->GetXCoordinate());
		retpack.AddFloat(ply->GetYCoordinate());
		retpack.AddFloat(ply->GetZCoordinate());
		retpack.AddFloat(ply->GetFacing());

		retpack.AddByte(0x00);

		retpack.AddDoubleWord(0x00000300);
		retpack.AddDoubleWord(TravelTime);
		retpack.AddDoubleWord(Count);
	
		for (it = mTaxiPathNodes.begin(); it != mTaxiPathNodes.end(); it++)
		{
			if ((*it)->PathID == Path)
			{
				retpack.AddFloat((*it)->X);
				retpack.AddFloat((*it)->Y);
				retpack.AddFloat((*it)->Z);
			}
		}
		
		//Hiding Player While Travelling...
		ply->SetXCoordinate(0);
		ply->SetYCoordinate(0);
		ply->SetZCoordinate(2500);
		
		PlayersHandler::GetSingleton().MoveTroughRegion(ply);

		ply->SetXCoordinate(p[loop-1].x);
		ply->SetYCoordinate(p[loop-1].y);
		ply->SetZCoordinate(p[loop-1].z);

		ply->SetMoved(false);

		WorldServer::GetSingleton().WriteData(cli, &retpack);

		WorldServer::GetSingleton().AnnounceTo(ply->GetClient(),"[World-Server] - Travel Started!");
		WorldServer::GetSingleton().AnnounceTo(ply->GetClient(),"[World-Server] - Duration: (%d)-> Seconds!",TravelTime/1000);

		EventSystem::GetSingleton().AddTimer(TravelTime,StopFlying,(void *)ply,TAXIHANDLER,ply->GetObjectGuid());

		delete p;
	}
}
	
DoubleWord TaxiHandler::GetNearNode(Player *ply)
{
	list<TaxiNodes *>::iterator it;

	DoubleWord NODE = 0;
    float distance = -1;
    float nx, ny, nz, nd;
    
	for(it = mTaxiNodes.begin(); it != mTaxiNodes.end();it++)
	{
		if ((*it)->Map == ply->GetCurrentMap())
		{
			nx = (*it)->X - ply->GetXCoordinate();
			ny = (*it)->Y - ply->GetYCoordinate();
			nz = (*it)->Z - ply->GetZCoordinate();
			nd = nx * nx + ny * ny + nz * nz;
			if( nd < distance || distance < 0 ) 
			{
			    distance = nd;
				NODE = (*it)->ID;
			}
		}
	}
    
    return NODE;
}

DoubleWord TaxiHandler::GetTaxiMask(DoubleWord SOURCE)
{
	list<TaxiPaths *>::iterator it;

	DoubleWord mask = 0;
	DoubleWord count = 0;
    
    for (it = mTaxiPaths.begin(); it != mTaxiPaths.end(); it++)
	{
		if((*it)->Source == SOURCE)
		{
			mask |= 1 << ((*it)->Destination - 1);
		}
	}
     
    return mask;
}

DoubleWord TaxiHandler::GetPath(DoubleWord Source, DoubleWord Destination)
{
	list<TaxiPaths *>::iterator it;

	DoubleWord path = 0;

	for(it = mTaxiPaths.begin(); it != mTaxiPaths.end(); it++)
	{
		if ((*it)->Source == Source && (*it)->Destination == Destination)
			path = (*it)->ID;
	}

    return path;
}

void TaxiHandler::LoadTaxiDB()
{
	LoadTaxiNodes();
	LoadTaxiPathNodes();
	LoadTaxiPaths();
}

void TaxiHandler::LoadTaxiNodes()
{
	int result;
	char *buffer;
	DoubleWord count = 0;
	QuadWord TAXIGUID = 2000000000;

	// Fetch the database connection.
	Database *mdb = Database::GetSingletonPtr();

	if (!mdb || !*mdb)
	{
		printf("Couldnt Connect in the Database!\n");
		return;
	}
	
	// Should be large enough for a query.
	if ((buffer = new char[2048]) == 0)
		return;

	snprintf(buffer, 2048, "SELECT * FROM taxinodes;");

	result = mdb->Query(buffer);

	if (result == 1)
	{
		delete [] buffer;

		do 
		{
			Field *data = mdb->Fetch();
							
			TaxiNodes *txdata = new TaxiNodes();
			txdata->ID = atoi(data[0].Value());
			txdata->Name = data[1].Value();
			txdata->X = (float)atof(data[2].Value());
			txdata->Y = (float)atof(data[3].Value());
			txdata->Z = (float)atof(data[4].Value());
			txdata->Map = atoi(data[5].Value());
			txdata->Flags = atoi(data[6].Value());
			mTaxiNodes.push_back(txdata);				

			Mob *mob = new Mob(TAXIGUID++, "The Traveler");
			
			mob->SetXCoordinate(txdata->X+1.5f);
			mob->SetYCoordinate(txdata->Y+1.5f);
			mob->SetZCoordinate(txdata->Z);
			mob->SetFacing(0);
			mob->SetGuildName("Taxi Node");
			mob->SetHealth(1);
			mob->SetMana(1);
			mob->SetMobExperience(0);
			mob->SetMaximumHealth(1);
			mob->SetMaximumMana(1);
			mob->SetLevel(100);
			mob->mDamages.BPhysicalMAX = (0);
			mob->mDamages.BPhysicalMIN = (0);
			mob->SetScale(1);
			mob->SetEntry(1);
			mob->SetObjectModel(20);
			mob->SetDeadState(false);
			mob->SetCurrentMap(txdata->Map);
			mob->SetFaction(0x13);
			mob->SetAttackState(false);
			mob->SetUnitFlags(UNIT_FLAG_SHEATHE);
			mob->SetDynamicFlags(0x00);
			mob->SetMobType(0x00);
			mob->SetNPCFlags(8);

			MonsterHandler::GetSingleton().mMobs.AddObject(mob->GetObjectGuid(), mob);
			MonsterHandler::GetSingleton().MonsterSpawned(mob, NULL, false);

			count++;

		} while (mdb->NextRow());

		printf("[World-Server] - (%d)-> Taxi Nodes loaded...\n",count);
		return;
	}
	else
	{
		delete [] buffer;
		printf("[World-Server] - (%d)-> Taxi Nodes loaded...\n",count);
		return;
	}
}

void TaxiHandler::LoadTaxiPathNodes()
{
	int result;
	char *buffer;
	DoubleWord count = 0;

	// Fetch the database connection.
	Database *mdb = Database::GetSingletonPtr();

	if (!mdb || !*mdb)
	{
		printf("Couldnt Connect in the Database!\n");
		return;
	}
	
	// Should be large enough for a query.
	if ((buffer = new char[2048]) == 0)
		return;

	snprintf(buffer, 2048, "SELECT * FROM taxipathnodes;");

	result = mdb->Query(buffer);

	if (result == 1)
	{
		delete [] buffer;

		do 
		{
			Field *data = mdb->Fetch();
							
			TaxiPathNodes *txdata = new TaxiPathNodes();
			txdata->PathID = atoi(data[1].Value());
			txdata->Index = atoi(data[2].Value());
			txdata->X = (float)atof(data[4].Value());
			txdata->Y = (float)atof(data[5].Value());
			txdata->Z = (float)atof(data[6].Value());
			txdata->Map = atoi(data[3].Value());
				
			mTaxiPathNodes.push_back(txdata);				
			count++;

		} while (mdb->NextRow());

		printf("[World-Server] - (%d)-> Taxi Path Nodes loaded...\n",count);
		return;
	}
	else
	{
		delete [] buffer;
		printf("[World-Server] - (%d)-> Taxi Path Nodes loaded...\n",count);
		return;
	}
}

void TaxiHandler::LoadTaxiPaths()
{
	int result;
	char *buffer;
	DoubleWord count = 0;

	// Fetch the database connection.
	Database *mdb = Database::GetSingletonPtr();

	if (!mdb || !*mdb)
	{
		printf("Couldnt Connect in the Database!\n");
		return;
	}
	
	// Should be large enough for a query.
	if ((buffer = new char[2048]) == 0)
		return;

	snprintf(buffer, 2048, "SELECT * FROM taxipath;");

	result = mdb->Query(buffer);

	if (result == 1)
	{
		delete [] buffer;

		do 
		{
			Field *data = mdb->Fetch();
							
			TaxiPaths *txdata = new TaxiPaths();
			txdata->ID = atoi(data[0].Value());
			txdata->Source = atoi(data[1].Value());
			txdata->Destination = atoi(data[2].Value());
			txdata->Price = atoi(data[3].Value());
				
			mTaxiPaths.push_back(txdata);				
			count++;

		} while (mdb->NextRow());

		printf("[World-Server] - (%d)-> Taxi Paths loaded...\n",count);
		return;
	}
	else
	{
		delete [] buffer;
		printf("[World-Server] - (%d)-> Taxi Paths loaded...\n",count);
		return;
	}
}

#endif
