// (c) AbyssX Group
#include "../WorldEnvironment.h"

template <class WorldPort_DB> WorldPort_DB *Singleton<WorldPort_DB>::msSingleton = 0;

WorldPort_DB::WorldPort_DB()
{
}

WorldPort_DB::~WorldPort_DB()
{
}

void WorldPort_DB::ParseChat(Player *ply, Client *cli, char *txt)
{
	char *line;

	if (strnicmp(txt, "add ", 4) == 0 && ply->IsGM())
	{
		char newplace[64];
		Float x = 50.0f;
		Float y = 50.0f;
		Float z = 150.0f;
		int m = 0;
		
		line = txt + 4;
		sscanf(line, "%s %d %f %f %f", newplace, &m, &x, &y, &z);

		if(Add(newplace,m,x,y,z) == true)
		{
			WorldPort *wp = new WorldPort();
			wp->mMap = m;	wp->mName = newplace;	
			wp->mX = x;	wp->mY = y;	wp->mZ = z;

			mWorldPorts.push_back(wp);

			WorldServer::GetSingleton().AnnounceToAll("%s has added a new worldport for your worldporting pleasure...",ply->GetName().c_str());

			LogManager::GetSingleton().Log("GMActions.log",
				"%s added worldport %s (%d, %f, %f, %f)\n",
				ply->GetName().c_str(), newplace, m, x, y, z);
		}
	}

	if (strnicmp(txt, "go ", 3) == 0 && ply->IsGM())
	{
		Float x = 50.0f;
		Float y = 50.0f;
		Float z = 150.0f;
		int m = 0;
		
		line = txt + 3;
		sscanf(line, "%d %f %f %f", &m, &x, &y, &z);

		WorldPort *go = new WorldPort();
		go->mMap = m;
		go->mX = x;
		go->mY = y;
		go->mZ = z;
		if(m == 0 || m == 1 || m == 44)
		{
			if ( PlayersHandler::GetSingleton().TeleportPlayer(ply, (go)->mMap, (go)->mX, (go)->mY, (go)->mZ) )
				WorldServer::GetSingleton().AnnounceTo(cli, "[World-Server] - You have been WorldPorted to (%d, %f, %f, %f).",(go)->mMap, (go)->mX, (go)->mY, (go)->mZ);
		}
		else
			WorldServer::GetSingleton().AnnounceTo(cli, "[World-Server] -> You almost crashed the server your dumb!");
		
		LogManager::GetSingleton().Log("GMActions.log", "%s WorldPorted to %d, %f, %f, %f\n", ply->GetName().c_str(), m, x, y, z);
	}
	
	else if (strnicmp(txt, "del ", 4) == 0 && ply->IsGM())
	{
		line = txt + 4;

		list<WorldPort *>::iterator it;

		if (Del(line))
		{
			for (it = mWorldPorts.begin(); it != mWorldPorts.end(); it++)
			{
				if (stricmp((*it)->mName.c_str(), line) == 0)
					break;
			}

			if (it != mWorldPorts.end())
			{
				WorldPort *wp;
				LogManager::GetSingleton().Log("GMActions.log",
					"%s deleted worldport %s\n",
					ply->GetName().c_str(), (*it)->mName.c_str());
				wp = *it;
				mWorldPorts.remove(*it);
				delete wp;

				WorldServer::GetSingleton().AnnounceTo(cli, "[World-Server] -> Worldport removed.");
			}
		}
	}

	else if (stricmp(txt, "list") == 0)
	{
		WorldServer::GetSingleton().AnnounceTo(cli, "Avaiable WorldPorts:");

		list<WorldPort *>::iterator it;

		for (it = mWorldPorts.begin(); it != mWorldPorts.end(); it++)
		{
			WorldServer::GetSingleton().AnnounceTo(cli, "  %s  (%d, %f, %f, %f)", (*it)->mName.c_str(),
				(*it)->mMap, (*it)->mX, (*it)->mY, (*it)->mZ);
		}

	}

	else if (stricmp(txt, "home") == 0)
	{
		if(ply->HasMoved())
			ply->SetStartCoordinates();
		if ( PlayersHandler::GetSingleton().TeleportPlayer(ply, ply->GetStartMap(),ply->GetXCoordinate(), ply->GetYCoordinate(), ply->GetZCoordinate()) )
			WorldServer::GetSingleton().AnnounceTo(cli,"[World-Server] -> You have been worldported into the start position!");
	}

	else

	{

		list<WorldPort *>::iterator it;

		for (it = mWorldPorts.begin(); it != mWorldPorts.end(); it++)
		{
			if (stricmp((*it)->mName.c_str(), txt) == 0)
				break;
		}
	
		if (it == mWorldPorts.end())
		{
			WorldServer::GetSingleton().AnnounceTo(cli, "No such world port defined.");
		}
		
		else

		{
			if ( PlayersHandler::GetSingleton().TeleportPlayer(ply, (*it)->mMap, (*it)->mX, (*it)->mY, (*it)->mZ) )
			WorldServer::GetSingleton().AnnounceTo(cli, "You have been WorldPorted to [ %s ].",(*it)->mName.c_str());
		}

	}
}

void WorldPort_DB::LoadWP()
{
	DoubleWord count = 0;

	if(List() == true)
	{
		do
		{
		Field *fields;

		fields = db->Fetch();
	
		WorldPort *wp = new WorldPort();
		wp->mMap = atoi(fields[1].Value());	
		wp->mName = fields[2].Value();	
		wp->mX = (Float)atof(fields[3].Value());	
		wp->mY = (Float)atof(fields[4].Value());	
		wp->mZ = (Float)atof(fields[5].Value());

		mWorldPorts.push_back(wp);

		count++;

		} while (db->NextRow());
	}
	printf("[World-Server] - (%d)-> WorldPort's Loaded\n",count);
}

bool WorldPort_DB::List()
{
	int result;
	char *buffer;
	
	// Fetch the database connection.
	db = Database::GetSingletonPtr();

	if (!db || !*db)
	{
		printf("Couldnt Connect in the Database!\n");
		return false;
	}
	
	// Should be large enough for a query.
	if ((buffer = new char[2048]) == 0)
		return false;

	snprintf(buffer, 2048, "SELECT * FROM worldports;");

	result = db->Query(buffer);

	if (result == 1)
	{
		delete [] buffer;
		return true;
	}

	delete [] buffer;

	return false;
}

bool WorldPort_DB::Add(string Place, DoubleWord map_id, float x, float y, float z)
{
	char *buf;
	
	// Fetch the database connection.
	db = Database::GetSingletonPtr();

	if (!db || !*db)
	{
		printf("Couldnt Connect in the Database!\n");
		return false;
	}
	
	// Should be large enough for a query.
	buf = new char[2048];  // should be large enough
	if (!buf)
		return false;

	snprintf(buf, 2048, "INSERT INTO worldports VALUES ('0','%d','%s','%f','%f','%f');",
	map_id,Place.c_str(),x,y,z);

	if (db->Query(buf))
	{
		delete [] buf;
		return true;
	}

	delete [] buf;

	return false;
}

bool WorldPort_DB::Del(string Place)
{
	char *buf;
	
	// Fetch the database connection.
	db = Database::GetSingletonPtr();

	if (!db || !*db)
	{
		printf("Couldnt Connect in the Database!\n");
		return false;
	}
	
	// Should be large enough for a query.
	buf = new char[2048];  // should be large enough
	if (!buf)
		return false;

	snprintf(buf, 2048, "DELETE FROM worldports WHERE destiny = '%s';", Place.c_str());

	if (db->Query(buf))
	{
		delete [] buf;
		return true;
	}

	delete [] buf;

	return false;
}