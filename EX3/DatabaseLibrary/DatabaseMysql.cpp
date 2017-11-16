// (c) Abyss Group
#include "DatabaseEnvironment.h"

DatabaseMysql::DatabaseMysql(const char *infoString) : Database(infoString), mResult(0)
{
	int i;
	char *parsedInfoString[4];
	MYSQL *mysqlInit;
	mysqlInit = mysql_init(NULL);
	if (!mMysql)
	{
 		LogManager::GetSingleton().Log("DatabaseMysql.log", "Could not initialize Mysql\n");
		return;
	}

	parsedInfoString[0] = new char[strlen(mInfoString) + 1];
	if (!parsedInfoString[0])
	{
 		LogManager::GetSingleton().Log("DatabaseMysql.log", "Out of memory on initialization\n");
		return;
	}
	strcpy(parsedInfoString[0], mInfoString);
	for (i = 1; i < 4; i++)
	{
		parsedInfoString[i] = strchr(parsedInfoString[i - 1], ';');
		*parsedInfoString[i] = '\0';
		++parsedInfoString[i];
	}
	
	mMysql = mysql_real_connect(mysqlInit, parsedInfoString[0], parsedInfoString[1],
 									parsedInfoString[2], parsedInfoString[3], 0, 0, 0);
	
	if (mMysql)
 		LogManager::GetSingleton().Log("DatabaseMysql.log", "Connected to MySQL database at %s\n",
										parsedInfoString[0]);
	else
		LogManager::GetSingleton().Log("DatabaseMysql.log", "Could not connect to MySQL database at %s\n",
										parsedInfoString[0]);
	
	delete parsedInfoString[0];
}

DatabaseMysql::~DatabaseMysql()
{
	if (mResult)
		EndQuery();
	if (mMysql)
		mysql_close(mMysql);
}

int DatabaseMysql::Query(const char *sql)
{
	int i;
	MYSQL_FIELD *fields;
	
	if (mResult)
		EndQuery();
	if (!mMysql)
		return 0;
	
	if (mysql_query(mMysql, sql))
		return 0;
	
	mResult = mysql_store_result(mMysql);

	mRowCount = mysql_affected_rows(mMysql);
	mFieldCount = mysql_field_count(mMysql);

	// Did the query succeed? And did it return any result set?
	if (mResult == 0)
	{
		if (mysql_field_count(mMysql) == 0)
			return -1;
		else
		{
			LogManager::GetSingleton().Log("DatabaseMysql.log", "Query result storage failed in query \"%s\"\n", sql);
			return 0;
		}
	}
	else
	if (mysql_affected_rows(mMysql) == 0)
		return 0;

	// There were rows returned from the query, so fetch them.
	mCurrentRow = new Field[mFieldCount];
	if (!mCurrentRow)
	{
 		LogManager::GetSingleton().Log("DatabaseMysql.log", "Out of memory on query result allocation in query \"%s\"\n", sql);
		return 0;
	}
	
	fields = mysql_fetch_fields(mResult);
	
	for (i = 0; i < mFieldCount; i++)
	{
		mCurrentRow[i].SetName(fields[i].name);
		mCurrentRow[i].SetType(ConvertNativeType(fields[i].type));
	}
	
	NextRow();
	return 1;
}

int DatabaseMysql::NextRow()
{
	MYSQL_ROW row;
//	unsigned long *lengths;
	int i;
	
	if (!mResult)
		return 0;
	
	row = mysql_fetch_row(mResult);
	if (!row)
	{
		EndQuery();
		return 0;
	}
//	lengths = mysql_fetch_lengths(mResult);
	
	for (i = 0; i < mFieldCount; i++)
		mCurrentRow[i].SetValue(row[i]);
	
	return 1;
}

void DatabaseMysql::EndQuery()
{
	if (mCurrentRow)
	{
		delete [] mCurrentRow;
		mCurrentRow = 0;
	}
	if (mResult)
	{
		mysql_free_result(mResult);
		mResult = 0;
	}
}

enum Field::DataTypes DatabaseMysql::ConvertNativeType(enum_field_types mysqlType)
{
	switch (mysqlType)
	{
	case FIELD_TYPE_TIMESTAMP:
	case FIELD_TYPE_DATE:
	case FIELD_TYPE_TIME:
	case FIELD_TYPE_DATETIME:
	case FIELD_TYPE_YEAR:
	case FIELD_TYPE_STRING:
	case FIELD_TYPE_VAR_STRING:
	case FIELD_TYPE_BLOB:
	case FIELD_TYPE_SET:
	case FIELD_TYPE_NULL:
		return Field::DB_TYPE_STRING;
	case FIELD_TYPE_TINY:
//	case FIELD_TYPE_CHAR:			// replaced by FIELD_TYPE_TINY
	case FIELD_TYPE_SHORT:
	case FIELD_TYPE_LONG:
	case FIELD_TYPE_INT24:
	case FIELD_TYPE_LONGLONG:		// this might need to be a text type instead
	case FIELD_TYPE_ENUM:
		return Field::DB_TYPE_INTEGER;
	case FIELD_TYPE_DECIMAL:
	case FIELD_TYPE_FLOAT:
	case FIELD_TYPE_DOUBLE:
		return Field::DB_TYPE_FLOAT;
	default:
		return Field::DB_TYPE_UNKNOWN;
	}
}
