// (c) NAWE Group

#ifndef _DATABASESQLITE_H
#define _DATABASESQLITE_H

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

        operator bool () const { return mSqlite3 != NULL; }

    private:
        sqlite3 *mSqlite3;
};

#endif
