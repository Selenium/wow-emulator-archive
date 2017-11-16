// (c) AbyssX Group
#include "../WorldEnvironment.h"

#ifdef MOBS

MobDB::MobDB()
{
}

MobDB::~MobDB()
{
}

bool MobDB::AddMDB(string text, DoubleWord ENTRY)
{
	char *buf;

	char name[128];
	char guildname[128];
	DoubleWord hp = 0;
	DoubleWord level = 0;
	DoubleWord damage = 0;
	DoubleWord defense = 0;
	DoubleWord speed = 0;
	DoubleWord model = 0;
	DoubleWord type = 0;
	DoubleWord exp = 0;
	DoubleWord flags = 0;
	Float scale = 1.0f;
	
	// Fetch the database connection.
	mdb = Database::GetSingletonPtr();

	if (!mdb || !*mdb)
	{
		printf("Couldnt Connect in the Database!\n");
		return false;
	}
	
	// Should be large enough for a query.
	buf = new char[2048];  // should be large enough
	if (!buf)
		return false;

	sscanf(text.c_str(), "%s %s %d %d %d %d %d %d %d %d %d %d %d", name, guildname, &hp, &level,
		&damage, &defense, &speed, &model, &type, &exp, &flags);

	snprintf(buf, 2048,
		"INSERT INTO monsters VALUES ('0','%s','%s','%d','%d','%d','%d','%d','%d','%f','%d','%d','%d','%d');", name, guildname, ENTRY, hp, level, damage, defense, speed, scale, model, type, exp, flags);

	if (mdb->Query(buf))
	{
		delete [] buf;
		return true;
	}

	delete [] buf;

	return false;
}

bool MobDB::DelMDB(DoubleWord ENTRY)
{
	char *buf;
	
	// Fetch the database connection.
	mdb = Database::GetSingletonPtr();

	if (!mdb || !*mdb)
	{
		printf("Couldnt Connect in the Database!\n");
		return false;
	}
	
	// Should be large enough for a query.
	buf = new char[2048];  // should be large enough
	if (!buf)
		return false;

	snprintf(buf, 2048, "DELETE FROM monsters WHERE entry = '%d';", ENTRY);

	if (mdb->Query(buf))
	{
		delete [] buf;
		return true;
	}

	delete [] buf;

	return false;
}

bool MobDB::ListMDB()
{
	int result;
	char *buffer;
	
	// Fetch the database connection.
	mdb = Database::GetSingletonPtr();

	if (!mdb || !*mdb)
	{
		printf("Couldnt Connect in the Database!\n");
		return false;
	}
	
	// Should be large enough for a query.
	if ((buffer = new char[2048]) == 0)
		return false;

	snprintf(buffer, 2048, "SELECT * FROM monsters;");

	result = mdb->Query(buffer);

	if (result == 1)
	{
		delete [] buffer;
		return true;
	}

	delete [] buffer;

	return false;
}

bool MobDB::FindMDB(DoubleWord ENTRY)
{
	int result;
	char *buffer;
	
	// Fetch the database connection.
	mdb = Database::GetSingletonPtr();

	if (!mdb || !*mdb)
	{
		printf("Couldnt Connect in the Database!\n");
		return false;
	}
	
	// Should be large enough for a query.
	if ((buffer = new char[2048]) == 0)
		return false;

	snprintf(buffer, 2048, "SELECT * FROM monsters WHERE entry='%d';",ENTRY);

	result = mdb->Query(buffer);

	if (result == 1)
	{
		delete [] buffer;
		return true;
	}

	delete [] buffer;

	return false;
}

#endif