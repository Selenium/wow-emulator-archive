// (c) Abyss Group
#include "DatabaseEnvironment.h"

DatabaseSqlite::DatabaseSqlite(const char *infoString) :
	Database(infoString), mSqlite(0), mTableData(0), mTableIndex(0)
{
	char *errmsg;

	mSqlite = sqlite_open(mInfoString, 0, &errmsg);

	if (!mSqlite)
	{
		LogManager::GetSingleton().Log("DatabaseSqlite.log", "Sqlite initialization failed: %s\n",
			errmsg ? errmsg : "<no error message>");
		if (errmsg)
			sqlite_freemem(errmsg);
		return;
	}
}

DatabaseSqlite::~DatabaseSqlite()
{
	if (mTableData)
		EndQuery();
	if (mSqlite)
		sqlite_close(mSqlite);
}

int DatabaseSqlite::Query(const char *sql)
{
	int i;
	char *errmsg;

	if (mTableData)
		EndQuery();
	if (!mSqlite)
		return 0;

	mTableIndex = 0;
	sqlite_get_table(mSqlite, sql, &mTableData, (int *)&mRowCount, &mFieldCount, &errmsg);

	if (!mRowCount)
	{
		mTableData = 0;
		return -1;
	}

	if (!mTableData)
	{
		LogManager::GetSingleton().Log("DatabaseSqlite.log", "Query \"%s\" failed: %s\n",
			sql, errmsg ? errmsg : "<no error message>");
		if (errmsg)
			sqlite_freemem(errmsg);
		return 0;
	}

	mCurrentRow = new Field[mFieldCount];
	if (!mCurrentRow)
	{
 		LogManager::GetSingleton().Log("DatabaseSqlite.log",
 										"Out of memory on query result allocation in query \"%s\"\n", sql);
		return 0;
	}
	
	for (i = 0; i < mFieldCount; i++)
	{
		mCurrentRow[i].SetName(mTableData[i]);
		// will change this to support datatypes eventually if needed
		mCurrentRow[i].SetType(Field::DB_TYPE_UNKNOWN);
	}

	NextRow();
	return 1;
}

int DatabaseSqlite::NextRow()
{
	QuadWord startIndex;
	int i;
	if (!mTableData)
		return 0;

	if (!(mTableIndex < mRowCount))
	{
		EndQuery();
		return 0;
	}

	startIndex = (mTableIndex + 1) * mFieldCount;
	for (i = 0; i < mFieldCount; i++)
	{
		mCurrentRow[i].SetValue(mTableData[startIndex + i]);
	}
	++mTableIndex;
	return 1;
}

void DatabaseSqlite::EndQuery()
{
	if (mCurrentRow)
	{
		delete [] mCurrentRow;
		mCurrentRow = 0;
	}
	if (mTableData)
	{
		sqlite_free_table(mTableData);
		mTableData = 0;
	}
}

int DatabaseSqlite::ConvertNativeType(const char *sqliteType)
{
	if (sqliteType)
	{
		switch (*sqliteType)
		{
		case 'S':
			return Field::DB_TYPE_STRING;
		case 'I':
			return Field::DB_TYPE_INTEGER;
		case 'F':
			return Field::DB_TYPE_FLOAT;
		default:
			return Field::DB_TYPE_UNKNOWN;
		};
	}
	return Field::DB_TYPE_UNKNOWN;
}
