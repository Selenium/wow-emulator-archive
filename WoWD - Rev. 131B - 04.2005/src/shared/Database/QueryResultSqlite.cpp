// (c) NAWE Group
#include "DatabaseEnv.h"


QueryResultSqlite::QueryResultSqlite(char **tableData, uint32 rowCount, uint32 fieldCount) :
    QueryResult(rowCount, fieldCount), mTableData(tableData), mTableIndex(0)
{
    mCurrentRow = new Field[mFieldCount];
    ASSERT(mCurrentRow);

    for (uint32 i = 0; i < mFieldCount; i++)
    {
        mCurrentRow[i].SetName(mTableData[i]);
        // will change this to support datatypes eventually if needed
        mCurrentRow[i].SetType(Field::DB_TYPE_UNKNOWN);
    }
}

QueryResultSqlite::~QueryResultSqlite()
{
    EndQuery();
}

bool QueryResultSqlite::NextRow()
{
    int startIndex;
    uint32 i;

    if (!mTableData)
        return false;

    if (mTableIndex >= mRowCount)
    {
        EndQuery();
        return false;
    }

    startIndex = (mTableIndex + 1) * mFieldCount;
    for (i = 0; i < mFieldCount; i++)
    {
        mCurrentRow[i].SetValue(mTableData[startIndex + i]);
    }

    ++mTableIndex;
    return true;
}

void QueryResultSqlite::EndQuery()
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

enum Field::DataTypes QueryResultSqlite::ConvertNativeType(const char* sqliteType) const
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
