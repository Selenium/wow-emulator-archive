// (c) Abyss Group
#include "DatabaseEnvironment.h"

template <class Database> Database *Singleton<Database>::msSingleton = 0;

// Function: InitDatabase.
/*bool InitDatabase()
{
	if (CONFIG(Database).DatabaseModule == Config::DbMysql)
		new DatabaseMysql(CONFIG(Database).InfoString.c_str());
	else
	if (CONFIG(Database).DatabaseModule == Config::DbSqlite)
		new DatabaseSqlite(CONFIG(Database).InfoString.c_str());
	else
		return false;

	return true;
}
*/

Database::Database(const char *infoString) :
	mCurrentRow(0), mFieldCount(0), mRowCount(0)
{
	if (infoString && (mInfoString = new char[strlen(infoString) + 1]))
		strcpy(mInfoString, infoString);
	else
		mInfoString = NULL;
}

Database::~Database()
{
	if (mInfoString)
		delete mInfoString;
	
	if (mCurrentRow)
		delete mCurrentRow;
}
