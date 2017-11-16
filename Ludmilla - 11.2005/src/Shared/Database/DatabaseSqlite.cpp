#include "StdAfx.h"
// (c) Abyss Group
// (c) NAWE Group

DatabaseSqlite::DatabaseSqlite() : Database(), mSqlite3(0)
{
}

DatabaseSqlite::~DatabaseSqlite()
{
    if (mSqlite3)
        sqlite3_close(mSqlite3);
}

bool DatabaseSqlite::Initialize(const char *infoString)
{
	int errcode = sqlite3_open(infoString, &mSqlite3);

	if (errcode != SQLITE_OK)
	{
		// use sqlite3_errmsg
		sLog.outError("Sqlite initialization failed: code=%d\n", errcode);
        return false;
    }

    return true;
}

QueryResult* DatabaseSqlite::Query(const char *sql)
{
    char *errmsg = NULL;

    if (!mSqlite3)
        return 0;

    char **tableData;
    int rowCount;
    int fieldCount;

    sqlite3_get_table(mSqlite3, sql, &tableData, &rowCount, &fieldCount, &errmsg);

    if (!rowCount)
        return 0; // no result

    if (!tableData)
    {
        sLog.outError("Query \"%s\" failed: %s\n",
            sql, errmsg ? errmsg : "<no error message>");
        if (errmsg)
            sqlite3_free(errmsg);
        return 0;
    }

    QueryResultSqlite *queryResult = new QueryResultSqlite(tableData, rowCount, fieldCount);
    if(!queryResult)
    {
		sLog.outError("Out of memory on query result allocation in query \"%s\"\n", sql);
        return 0;
    }

    queryResult->NextRow();

    return queryResult;
}


bool DatabaseSqlite::Execute(const char *sql)
{
    char *errmsg = NULL;

    if (!mSqlite3)
        return false;

    if(sqlite3_exec(mSqlite3, sql, NULL, NULL, &errmsg) != SQLITE_OK)
	{
        sLog.outError("Query \"%s\" failed: %s\n",
            sql, errmsg ? errmsg : "<no error message>");
        if (errmsg)
            sqlite3_free(errmsg);
        return false;
	}

    return true;
}
