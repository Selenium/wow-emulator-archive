// (c) Abyss Group
// (c) NAWE Group
#include "DatabaseEnv.h"

DatabaseSqlite::DatabaseSqlite() : Database(), mSqlite(0)
{
}

DatabaseSqlite::~DatabaseSqlite()
{
    if (mSqlite)
        sqlite_close(mSqlite);
}

bool DatabaseSqlite::Initialize(const char *infoString)
{
    char *errmsg;

    mSqlite = sqlite_open(infoString, 0, &errmsg);

    if (!mSqlite)
    {
//        sLog.Log(L_CRITICAL, "Sqlite initialization failed: %s\n",
//            errmsg ? errmsg : "<no error message>");
        if (errmsg)
            sqlite_freemem(errmsg);
        return false;
    }

    return true;
}

QueryResult* DatabaseSqlite::Query(const char *sql)
{
    char *errmsg;

    if (!mSqlite)
        return 0;

    char **tableData;
    int rowCount;
    int fieldCount;

    sqlite_get_table(mSqlite, sql, &tableData, &rowCount, &fieldCount, &errmsg);

    if (!rowCount)
        return 0; // no result

    if (!tableData)
    {
//        sLog.Log(L_ERROR, "Query \"%s\" failed: %s\n",
//            sql, errmsg ? errmsg : "<no error message>");
        if (errmsg)
            sqlite_freemem(errmsg);
        return 0;
    }

    QueryResultSqlite *queryResult = new QueryResultSqlite(tableData, rowCount, fieldCount);
    if(!queryResult)
    {
//        sLog.Log(L_ERROR, "Out of memory on query result allocation in query \"%s\"\n", sql);
        return 0;
    }

    queryResult->NextRow();

    return queryResult;
}


bool DatabaseSqlite::Execute(const char *sql)
{
    char *errmsg;

    if (!mSqlite)
        return false;

    if(sqlite_exec(mSqlite, sql, NULL, NULL, &errmsg) != SQLITE_OK)
        return false;

    return true;
}
