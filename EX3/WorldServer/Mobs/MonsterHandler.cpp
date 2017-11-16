// (c) AbyssX Group
#include "../WorldEnvironment.h"

#ifdef MOBS

template <class MonsterHandler> MonsterHandler *Singleton<MonsterHandler>::msSingleton = 0;

void MoveBack(void *Param)
{
	Mob *mob = (Mob *)Param;
	mob->GetBack();
	EventSystem::GetSingleton().AddTimer(8000,MoveBack,(void *)mob,MONSTERHANDLER,mob->GetObjectGuid());
}

MonsterHandler::MonsterHandler()
{
}

MonsterHandler::~MonsterHandler()
{
}

DoubleWord MonsterHandler::HandlePackets(Client *cli, Packet *pack)
{
	switch (pack->GetOpCode())
	{
		case CMSG_CREATURE_QUERY:
			HandlerMSG_CREATURE_QUERY(cli, pack);
			return 1;
			break;
	}

	return 0;
}

void MonsterHandler::HandlerMSG_CREATURE_QUERY(Client *cli, Packet *pack)
{
	Mob *mob;
	Packet retpack;
	Player *ply;

	ply = PlayersHandler::GetSingleton().FindPlayer(cli);

	mob = FindMob(pack->GetDoubleWord(0x00));
	if (!mob)
		return; // should not happen

	retpack.Build(SMSG_CREATURE_QUERY_RESPONSE);
	
	// Mob Entry ID
	retpack.AddDoubleWord(mob->GetEntry());

	// Name
	retpack.AddBytes((Byte *)mob->GetName().c_str(), (DoubleWord)mob->GetName().length() + 1);
	retpack.AddBytes((Byte *)mob->GetName().c_str(), (DoubleWord)mob->GetName().length() + 1);
	retpack.AddBytes((Byte *)mob->GetName().c_str(), (DoubleWord)mob->GetName().length() + 1);	
	retpack.AddBytes((Byte *)mob->GetName().c_str(), (DoubleWord)mob->GetName().length() + 1);

	// Guild Name
	retpack.AddBytes((Byte *)mob->GetGuildName().c_str(), (DoubleWord)mob->GetGuildName().length() + 1);

	retpack.AddDoubleWord(0);
	//retpack.AddDoubleWord(mob->GetMobType());
	retpack.AddDoubleWord(0);
	retpack.AddDoubleWord(0);
	retpack.AddDoubleWord(0);
	WorldServer::GetSingleton().WriteData(cli, &retpack);
}

void MonsterHandler::LoadMobs()
{
	Mob *mob;
	DoubleWord i = 0;
	DoubleWord j = 0;
	Field *population;
	DoubleWord rows = 0;
	DoubleWord fields = 0;
	
	if (POP.ListStaticDB() == true)
	{
			rows = DoubleWord(POP.pdb->RowCount());
			fields = DoubleWord(POP.pdb->FieldCount());

			population = new Field[(rows * fields)];

			//printf("[World-Server] - Allocating Space: [%d] fields... \n",(rows * fields));

			do {
			
				Field *data = POP.pdb->Fetch();

				for (unsigned int kk = 0; kk < fields; kk++)
				{
					population[kk + i * fields].SetName(data[kk].Name());
					population[kk + i * fields].SetValue(data[kk].Value());
					population[kk + i * fields].SetType(data[kk].Type());
				}
				
				i++;

			} while (POP.pdb->NextRow());

			do {
				
			if (Mob_DB.FindMDB(atoi(population[7+(j * fields)].Value())) == true)
			{
				Field *monster;

				monster = Mob_DB.mdb->Fetch();

				mob = new Mob(atoi(population[6+(j * fields)].Value()),monster[1].Value());

				mob->SetStandState(0x00);
				mob->SetCurrentMap(atoi(population[1+(j * fields)].Value()));
				mob->SetXCoordinate((Float)atof(population[2+(j * fields)].Value()));
				mob->SetYCoordinate((Float)atof(population[3+(j * fields)].Value()));
				mob->SetZCoordinate((Float)atof(population[4+(j * fields)].Value()));
				mob->mCoordz.X = (Float)atof(population[2+(j * fields)].Value());
				mob->mCoordz.Y = (Float)atof(population[3+(j * fields)].Value());
				mob->mCoordz.Z = (Float)atof(population[4+(j * fields)].Value());
				mob->SetFacing((Float)atof(population[5+(j * fields)].Value()));
				
				mob->SetGuildName(monster[2].Value());
				mob->SetEntry(atoi(monster[3].Value()));
				mob->SetHealth(atoi(monster[4].Value()));
				mob->SetMaximumHealth(atoi(monster[4].Value()));
				mob->SetLevel(atoi(monster[5].Value()));
				mob->mDamages.BPhysicalMAX = (atoi(monster[6].Value()));
				mob->mDamages.BPhysicalMIN = (atoi(monster[6].Value()) / 3);
				mob->SetScale((Float)atof(monster[9].Value()));
				mob->SetObjectModel(atoi(monster[10].Value()));
				mob->SetMobType(atoi(monster[11].Value()));
				mob->SetMobExperience(atoi(monster[12].Value()));
				mob->SetNPCFlags(atoi(monster[13].Value()));
				mob->SetFaction(0x13);
				mob->SetUnitFlags(UNIT_FLAG_SHEATHE);
				mob->SetDynamicFlags(0x00);
				mob->SetDeadState(false);
				mob->SetAttackState(false);
				mMobs.AddObject(mob->GetObjectGuid(), mob);
				MonsterSpawned(mob, NULL, false);
				
				UpdateRegion(mob);
				EventSystem::GetSingleton().AddTimer(5000,MoveBack,(void *)mob,MONSTERHANDLER,mob->GetObjectGuid());
			} 

				j++;
			} while (j < rows);

			if (population)
			{
				printf("[World-Server] - (%d)-> Mobs Loaded !\n",rows);
				//printf("[World-Server] - Cleaning Allocated Space: [%d] fields... \n",(rows * fields));
				delete [] population;
			}
	}
}

void MonsterHandler::UpdateRegion(Mob *mob)
{
	// We moved, but did not change maps
	Region *returnRegion;
	RegionList newRegions, oldRegions;
	RegionList disappearingRegions, appearingRegions;
	RegionList::RegionListIterator ri;
	Region::PlayerIterator pi;
	Region::ObjectIterator oi;
	Player *p;

	returnRegion = WorldServer::GetSingleton().mRegionManagers[mob->GetCurrentMap()]->UpdateObject(mob,false);
		
	// We did not change regions, do nothing
	if (!returnRegion)
		return;

	// We now know we moved from a region to a new good region, in the same map
	// Fetch the 'new' regions
	newRegions = WorldServer::GetSingleton().mRegionManagers[mob->GetCurrentMap()]->GetRegionsWithinRange(mob,RegionManager::RANGETYPE_3X3);
	// Fetch the 'old' regions
	oldRegions = mob->GetCurrentRegionList();
	// Figure out which regions are disappearing
	disappearingRegions = oldRegions - newRegions;
	// Figure out which regions are appearing
	appearingRegions = newRegions - oldRegions;

	// Send out-of-range stuff
	for (ri = disappearingRegions.Begin(); ri != disappearingRegions.End(); ri++)
	{
		for (pi = (*ri)->PlayerBegin(); pi != (*ri)->PlayerEnd(); pi++)
		{
			p = (Player *) *pi;
			if (p->GetClient())
			{
				// Send out of Range to the players that we left behind...
				p->RemoveCreatedMob(mob);
				MobOutOfRange(p->GetClient(), mob);
			}
		}
	}

	// Send in-range stuff
	for (ri = appearingRegions.Begin(); ri != appearingRegions.End(); ri++)
	{
		for (pi = (*ri)->PlayerBegin(); pi != (*ri)->PlayerEnd(); pi++)
		{
			p = (Player *) *pi;
			
			if (p->GetClient())
			{
				if (mob->GetNPCFlags() != 0)
					mob->SetFaction(p->GetFaction());
					
				// Send the in range packet to the players that didnt knew about us before...
				p->AddCreatedMob(mob);
				MobInRange(p->GetClient(), mob);
			}

		}
	}

	// Finally, we update our current region list.
	mob->SetCurrentRegionList(newRegions);
}

Mob *MonsterHandler::FindMob(QuadWord guid)
{
	ObjectManager<Mob *>::ObjectManagerIterator it;

	for (it = mMobs.Begin(); it != mMobs.End(); it++)
	{
		if ((*it).second->GetObjectGuid() == guid)
		{
			return (*it).second;
		}
	}

	return NULL;
}

Mob *MonsterHandler::FindMob(DoubleWord entry)
{
	ObjectManager<Mob *>::ObjectManagerIterator it;

	for (it = mMobs.Begin(); it != mMobs.End(); it++)
	{
		if ((*it).second->GetEntry() == entry)
			return (*it).second;
	}

	return NULL;
}

Mob *MonsterHandler::FindMob(const char *name)
{
	ObjectManager<Mob *>::ObjectManagerIterator it;

	for (it = mMobs.Begin(); it != mMobs.End(); it++)
	{
		if (stricmp((*it).second->GetName().c_str(), name) == 0)
			return (*it).second;
	}

	return NULL;
}

void MonsterHandler::MobInRange(Client *cli, Mob *mob)
{
	Packet pack;

	Packets::NewObjectHeader(mob,&pack);
	Packets::NewObjectData(mob,&pack);
	WorldServer::GetSingleton().WriteData(cli, &pack);
	LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_UPDATE_OBJECT\n");
}

void MonsterHandler::MobOutOfRange(Client *cli, Mob *mob)
{
	Packet pack;

	pack.Build(SMSG_DESTROY_OBJECT);
	pack.AddQuadWord(mob->GetObjectGuid());
	WorldServer::GetSingleton().WriteData(cli, &pack);
	LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_DESTROY_OBJECT\n");
}

void MonsterHandler::SpawnMob(char *info, Player *ply)
{
	char name[64];
	char facing[64];
	DoubleWord mod;
	Mob *mob;

	sscanf(info, "%s %d %s", name, &mod, facing);
	mob = new Mob(WorldServer::GetSingleton().mNextMOBGUID++, name);
	mob->SetStandState(0x00);
	mob->SetXCoordinate(ply->GetXCoordinate());
	mob->SetYCoordinate(ply->GetYCoordinate());
	mob->SetZCoordinate(ply->GetZCoordinate());
	mob->mCoordz.X = ply->GetXCoordinate();
	mob->mCoordz.Y = ply->GetYCoordinate();
	mob->mCoordz.Z = ply->GetZCoordinate();
	
	if (!facing)
		mob->SetFacing(ply->GetFacing());
	else
	{
		if (stricmp(facing, "N") == 0)
			mob->SetFacing(FACING_NORTH);
		else if (stricmp(facing, "NE") == 0)
			mob->SetFacing(FACING_NORTHEAST);
		else if (stricmp(facing, "E") == 0)
			mob->SetFacing(FACING_EAST);
		else if (stricmp(facing, "SE") == 0)
			mob->SetFacing(FACING_SOUTHEAST);
		else if (stricmp(facing, "S") == 0)
			mob->SetFacing(FACING_SOUTH);
		else if (stricmp(facing, "SW") == 0)
			mob->SetFacing(FACING_SOUTHWEST);
		else if (stricmp(facing, "W") == 0)
			mob->SetFacing(FACING_WEST);
		else if (stricmp(facing, "NW") == 0)
			mob->SetFacing(FACING_NORTHWEST);
		else
			mob->SetFacing(ply->GetFacing());
	}
	
	mob->SetGuildName("*Spawned Mob");
	mob->SetHealth(500);
	mob->SetMana(1000);
	mob->SetLevel(12);
	mob->mDamages.BPhysicalMAX = (50);
	mob->mDamages.BPhysicalMIN = (50/3);
	mob->SetMobExperience(2000);
	mob->SetMaximumHealth(500);
	mob->SetMaximumMana(100);
	mob->SetScale(1);
	mob->SetEntry(WorldServer::GetSingleton().mNextMOBEntry++);
	mob->SetObjectModel(mod);
	mob->SetDeadState(false);
	mob->SetCurrentMap(ply->GetCurrentMap());
	mob->SetFaction(0x13);
	mob->SetAttackState(false);
	mob->SetUnitFlags(UNIT_FLAG_SHEATHE);
	mob->SetDynamicFlags(0x00);
	mob->SetMobType(0x01);
	mob->SetNPCFlags(0x00);

	mMobs.AddObject(mob->GetObjectGuid(), mob);
	MonsterSpawned(mob, ply, true);

	UpdateRegion(mob);
	EventSystem::GetSingleton().AddTimer(5000,MoveBack,(void *)mob,MONSTERHANDLER,mob->GetObjectGuid());
}

void MonsterHandler::MonsterSpawned(Mob *mob, Player *ply, bool spawned)
{
	Packet pack;
	if (spawned)
	{
		Packets::NewObjectHeader(mob,&pack);
		Packets::NewObjectData(mob,&pack);
	}
	RegionList regionList;
	RegionList::RegionListIterator i;
	Region::PlayerIterator j;
	Player *p;

	// send it to the player who spawned the mob first
	if (spawned)
		WorldServer::GetSingleton().WriteData(ply->GetClient(), &pack);
	
	// set up the mob's regionlist 
	//printf("Objects in current player region: %d\n", ply->GetCurrentRegion()->GetObjectCount());
	// Region *checking =
	WorldServer::GetSingleton().mRegionManagers[mob->GetCurrentMap()]->UpdateObject(mob, true);
	//printf("Currently Result of the Added Mob %p.\n",Checking);
	//printf("Objects in current player region: %d\n", ply->GetCurrentRegion()->GetObjectCount());

	mob->SetCurrentRegionList(
		WorldServer::GetSingleton().mRegionManagers[mob->GetCurrentMap()]->GetRegionsWithinRange(mob,RegionManager::RANGETYPE_3X3));

	regionList = mob->GetCurrentRegionList();

	// Then, tell all the other players within range about us, and add them to the new player's
	// created-for list.

	if (spawned)
	{
		for (i = regionList.Begin(); i != regionList.End(); i++)
		{
			for (j = (*i)->PlayerBegin(); j != (*i)->PlayerEnd(); j++)
			{
				p = (Player *) *j;
				if (!p->GetClient())
					continue; // don't bother if not logged in
				// Add the mob to the surrounding player's created for list
				p->AddCreatedMob(mob);
				if (p->GetClient())
					WorldServer::GetSingleton().WriteData(p->GetClient(), &pack);
				LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_UPDATE_OBJECT\n");
			}
		}
	}

	if (spawned)
		WorldServer::GetSingleton().AnnounceToAll("[World-Server] -> %s spawned with GUID: " I64FMTD, mob->GetName().c_str(),	mob->GetObjectGuid());
}

void MonsterHandler::RemoveMonster(QuadWord MOBGUID, Player *ply)
{
	Packet pack;
	RegionList regionList;
	RegionList::RegionListIterator i;
	Region::PlayerIterator j;
	Region::ObjectIterator k;
	Player *p;

	Mob *mob = FindMob(MOBGUID);

	if (mob)
	{
		EventSystem::GetSingleton().DeleteTimer(10001,mob->GetObjectGuid());

		pack.Build(SMSG_DESTROY_OBJECT);
		pack.AddQuadWord(MOBGUID);

		WorldServer::GetSingleton().WriteData(ply->GetClient(), &pack);
		
		regionList = mob->GetCurrentRegionList();

		for (i = regionList.Begin(); i != regionList.End(); i++)
		{
			for (j = (*i)->PlayerBegin(); j != (*i)->PlayerEnd(); j++)
			{
				p = (Player *) *j;
	
				if (p->GetClient())
				{
					p->RemoveCreatedMob(mob);
					WorldServer::GetSingleton().WriteData(p->GetClient(), &pack);
				}
			}
		}

		if (mob->GetCurrentRegion())
			WorldServer::GetSingleton().mRegionManagers[mob->GetCurrentMap()]->RemoveObject(mob);

		delete mob;
	}
}

Float MonsterHandler::DistBetween(Player *p1, Mob *p2)
{  
	Float x = fabs(p1->GetXCoordinate() - p2->GetXCoordinate());
	Float y = fabs(p1->GetYCoordinate() - p2->GetYCoordinate());
	Float z = fabs(p1->GetZCoordinate() - p2->GetZCoordinate());
	
	return sqrt(x*x + y*y + z*z);
}

#endif
