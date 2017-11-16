// (c) NAWE Group

#ifndef _DATABASEMYSQL_H
#define _DATABASEMYSQL_H

#ifdef WIN32
#include <winsock2.h>
#include <mysql/mysql.h>
#else
#include <mysql.h>
#endif

#define SQL_CONNECTIONS 2

typedef struct
{
    MYSQL *sqlDescriptor;
    bool busy;
} MysqlConnection;

class DatabaseMysql : public Database
{
    public:
        DatabaseMysql();
        ~DatabaseMysql();

        //! Initializes Mysql and connects to a server.
        /*! infoString should be formated like hostname;username;password;database. */
        bool Initialize(const char *infoString);

        QueryResult* Query(const char *sql);
        bool Execute(const char *sql);

        MysqlConnection *GetFreeConnection() const;

        operator bool () const { return GetFreeConnection() != NULL; }

    private:
        MysqlConnection m_sqlConnections[SQL_CONNECTIONS];
};

#endif
