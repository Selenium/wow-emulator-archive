// (c) NAWE Group

#ifndef _DATABASESQLITE_H
#define _DATABASESQLITE_H

// Required for SQLite DBM
#include <sqlite/sqlite.h>

class DatabaseSqlite : public Database
{
    public:
        DatabaseSqlite();
        ~DatabaseSqlite();

        //! Initializes Sqlite and opens a database file.
        /*! infoString should be formated like database.db. */
        bool Initialize(const char *infoString);

        QueryResult* Query(const char *sql);
        bool Execute(const char *sql);

        operator bool () const { return mSqlite != NULL; }

    private:
        sqlite *mSqlite;
};

#endif
