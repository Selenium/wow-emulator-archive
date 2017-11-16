#include "DatabaseEnv.h"
#include "Util.h"

using namespace std;

DatabaseMysql::DatabaseMysql() : Database()
{
}

DatabaseMysql::~DatabaseMysql()
{
    int i;

    for(i = 0; i < SQL_CONNECTIONS; i++)
    {
        if (m_sqlConnections[i].sqlDescriptor)
            mysql_close(m_sqlConnections[i].sqlDescriptor);
    }
}

bool DatabaseMysql::Initialize(const char *infoString)
{
    int i;
	vector<string> tokens = StrSplit(infoString, ";");
    std::string params[4] = { "", "", "", "" };

	vector<string>::iterator iter;

    std::string host, user, password, database;
    iter = tokens.begin();

    if(iter != tokens.end())
        host = *iter++;
    if(iter != tokens.end())
        user = *iter++;
    if(iter != tokens.end())
        password = *iter++;
    if(iter != tokens.end())
        database = *iter++;

    for(i = 0; i < SQL_CONNECTIONS; i++)
    {
        MYSQL * handle = mysql_init( NULL );

        m_sqlConnections[i].busy = false;

        if (!handle)
        {
            Log::getSingleton().outError( "Could not initialize Mysql" );
            return false;
        }

        m_sqlConnections[i].sqlDescriptor = mysql_real_connect(handle, host.c_str(), user.c_str(),
                                        password.c_str(), database.c_str(), 0, 0, 0);

        if (m_sqlConnections[i].sqlDescriptor)
            Log::getSingleton().outDetail( "Connected to MySQL database at %s [%d]\n",
                host.c_str(), i);
        else
            Log::getSingleton().outError( "Could not connect to MySQL database at %s [%d]: %s\n",
                host.c_str(),i, mysql_error(handle));


        if(!m_sqlConnections[i].sqlDescriptor)
            return false;
    }

    return true;
}

QueryResult* DatabaseMysql::Query(const char *sql)
{
    MysqlConnection *sqlConn = GetFreeConnection();

    if (!sqlConn)
        return 0;

    sqlConn->busy = true;

    //Log::getSingleton().outDetail( (std::string("SQL: ") + sql).c_str() );

    if (mysql_query(sqlConn->sqlDescriptor, sql))
    {
        sqlConn->busy = false;
        return 0;
    }

    MYSQL_RES *result = mysql_store_result(sqlConn->sqlDescriptor);

    uint64 rowCount = mysql_affected_rows(sqlConn->sqlDescriptor);
    uint32 fieldCount = mysql_field_count(sqlConn->sqlDescriptor);


    // Did the query succeed? And did it return any result set?
	if (!result)
	{
        mysql_free_result(result);

        sqlConn->busy = false;
		return 0;
	}
	else
	{
		if (rowCount == 0)
		{
			mysql_free_result(result);

            sqlConn->busy = false;
			return 0;
		}
	}


    QueryResultMysql *queryResult = new QueryResultMysql(result, rowCount, fieldCount);
    if(!queryResult)
    {
		mysql_free_result(result);

        sqlConn->busy = false;
        return 0;
    }

    queryResult->NextRow();
    sqlConn->busy = false;
    return queryResult;
}


bool DatabaseMysql::Execute(const char *sql)
{
    MysqlConnection* sqlConn = GetFreeConnection();

    if (!sqlConn)
        return false;

    Log::getSingleton().outDetail( (std::string("SQL: ") + sql).c_str() );

    if (mysql_query(sqlConn->sqlDescriptor, sql))
        return false;

    return true;
}

MysqlConnection *DatabaseMysql::GetFreeConnection() const
{
    int i;

    for(i = 0; i < SQL_CONNECTIONS; i++)
    {
        if (!m_sqlConnections[i].busy && m_sqlConnections[i].sqlDescriptor)
            return (MysqlConnection *)&m_sqlConnections[i];
    }

    return NULL;
}