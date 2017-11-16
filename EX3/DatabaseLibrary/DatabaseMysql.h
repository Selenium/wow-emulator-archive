// (c) Abyss Group
#if !defined(DATABASEMYSQL_H)
#define DATABASEMYSQL_H

#ifdef WIN32
#include <winsock2.h>
#endif
#include "mysql/include/mysql.h"

class DatabaseMysql : public Database
{
	public:
		//! Initializes Mysql and connects to a server.
		/*! infoString should be formated like hostname;username;password;database. */
		DatabaseMysql(const char *infoString);
		
		~DatabaseMysql();
		
		int Query(const char *sql);
		
		int NextRow();

		operator bool () { return mMysql != NULL; }
		
	private:
		static enum Field::DataTypes ConvertNativeType(enum_field_types mysqlType);

		void EndQuery();

		MYSQL *mMysql;

		MYSQL_RES *mResult;
};

#endif
