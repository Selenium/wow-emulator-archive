// (c) AbyssX Group
#include "../WorldEnvironment.h"

#ifdef MOBS

Population::Population()
{
}

Population::~Population()
{
}

bool Population::AddStaticDB(string text, QuadWord GUID, Player *ply)
{
	char *buf;

	DoubleWord map = ply->GetCurrentMap();
	DoubleWord entry = 0;
	Float x = ply->GetXCoordinate();
	Float y = ply->GetYCoordinate();
	Float z = ply->GetZCoordinate();
	Float facing = ply->GetFacing();
	
	// Fetch the database connection.
	pdb = Database::GetSingletonPtr();

	if (!pdb || !*pdb)
	{
		printf("Couldnt Connect in the Database!\n");
		return false;
	}
	
	// Should be large enough for a query.
	buf = new char[2048];  // should be large enough
	if (!buf)
		return false;

	sscanf(text.c_str(),"%d",&entry);

	snprintf(buf, 2048, "INSERT INTO population VALUES ('0','%d','%f','%f','%f','%f','"I64FMTD"','%d');",map, x, y, z, facing, GUID, entry);

	if (pdb->Query(buf))
	{
		delete [] buf;
		return true;
	}

	delete [] buf;

	return false;
}

bool Population::UpdateStaticDB(QuadWord GUID, Mob *mob)
{
	char *buf;

	DoubleWord entry = mob->GetEntry();
	DoubleWord map = mob->GetCurrentMap();
	Float x = mob->GetXCoordinate();
	Float y = mob->GetYCoordinate();
	Float z = mob->GetZCoordinate();
	Float facing = mob->GetFacing();
	
	// Fetch the database connection.
	pdb = Database::GetSingletonPtr();

	if (!pdb || !*pdb)
	{
		printf("Couldnt Connect in the Database!\n");
		return false;
	}
	
	// Should be large enough for a query.
	buf = new char[2048];  // should be large enough
	if (!buf)
		return false;

	snprintf(buf, 2048, "UPDATE population SET map='%d', x='%f', y='%f', z='%f', facing='%f', entry='%d' WHERE GUID='"I64FMTD"';",map, x, y, z, facing, entry, GUID);

	if (pdb->Query(buf))
	{
		delete [] buf;
		return true;
	}

	delete [] buf;

	return false;
}

bool Population::DelStaticDB(QuadWord GUID)
{
	char *buf;
	
	// Fetch the database connection.
	pdb = Database::GetSingletonPtr();

	if (!pdb || !*pdb)
	{
		printf("Couldnt Connect in the Database!\n");
		return false;
	}
	
	// Should be large enough for a query.
	buf = new char[2048];  // should be large enough
	if (!buf)
		return false;

	snprintf(buf, 2048, "DELETE FROM population WHERE GUID = '"I64FMTD"';", GUID);

	//printf(""I64FMTD"\n",GUID);

	if(pdb->Query(buf))
	{
		delete [] buf;
		return true;
	}

	delete [] buf;

	return false;
}

bool Population::ListStaticDB()
{
	int result;
	char *buffer;
	
	// Fetch the database connection.
	pdb = Database::GetSingletonPtr();

	if (!pdb || !*pdb)
	{
		printf("Couldnt Connect in the Database!\n");
		return false;
	}
	
	// Should be large enough for a query.
	if ((buffer = new char[2048]) == 0)
		return false;

	snprintf(buffer, 2048, "SELECT * FROM population;");

	result = pdb->Query(buffer);

	if (result == 1)
	{
		delete [] buffer;
		return true;
	}

	delete [] buffer;

	return false;
}

#endif