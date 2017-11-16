// (c) NAWE Group

#ifndef _DATABASEMYSQL_H
#define _DATABASEMYSQL_H

#ifdef WIN32
#include <winsock2.h>
#endif
#include <mysql/mysql.h>

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

        operator bool () const { return mMysql != NULL; }

    private:
        MYSQL *mMysql;
};

#endif
