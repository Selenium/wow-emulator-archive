// (c) Abyss Group
// (c) NAWE Group
#if !defined(DATABASE_H)
#define DATABASE_H

class Database : public Singleton<Database>
{
    protected:
        Database() {}

    public:
        //! Frees resources used by Database.
        virtual ~Database() {}

        //! Initialize db, infoString is very implementation-dependant.
        virtual bool Initialize(const char *infoString) = 0;

        //! Query the database with a SQL command.
        /*
        This is where all the transaction with the database takes place.
        Any result data is held in memory and can be iterated through with NextRow().
        @param sql SQL command to query the database with. Should be supported by all database modules being used.
        @return Returns QueryResult if the query succeded and there are results and NULL otherwise */
        virtual QueryResult* Query(const char *sql) = 0;

        //! Execute SQL command.
        /*
        @param sql SQL command to query the database with. Should be supported by all database modules being used.
        @return Returns true if query succeded */
        virtual bool Execute(const char *sql) = 0;

        //! Returns the status of the database, and should be used to ensure the database was opened successfully.
        virtual operator bool () const = 0;
};

#define sDatabase Database::getSingleton()

#endif
