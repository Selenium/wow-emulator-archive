// (c) Abyss Group
#if !defined(DATABASESQLLITE_H)
#define DATABASESQLITE_H

// Required for SQLite DBM
#include "sqlite/include/sqlite.h"

class DatabaseSqlite : public Database
{
	public:
		//! Initializes Sqlite and opens a database file.
		/*! infoString should be formated like database.db. */
		DatabaseSqlite(const char *infoString);

		~DatabaseSqlite();

		int Query(const char *sql);

		int NextRow();

		operator bool () { return mSqlite != NULL; }

	private:
		static int ConvertNativeType(const char *sqliteType);

		void EndQuery();

		sqlite *mSqlite;

		char **mTableData;

		QuadWord mTableIndex;
};

#endif
