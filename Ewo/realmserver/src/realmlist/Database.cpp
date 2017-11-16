#include "Database.h"
#include "Errors.h"
#include "Sockets.h"
#include "Threads.h"
#include <mysql.h>

createFileSingleton (Database);

Database::Database ()
{
}

Database::~Database ()
{
	for (std::set< DatabaseInterface * >::iterator i = mInterfaces.begin (); i != mInterfaces.end (); ++ i)
		delete *i;
	mInterfaces.clear ();
}

void Database::removeDatabaseInterface (DatabaseInterface *db)
{
	delete db;
	REALMLISTSRV.dbstate--;
	mInterfaces.erase (db);
#ifdef DEBUG_VERSION
	LOG.outString("DBI: Removed interface [%d]", REALMLISTSRV.dbstate);
#endif
}

DatabaseInterface * Database::createDatabaseInterface_r ()
{
	MYSQL * handle = mysql_init (NULL);
	MYSQL * retval = mysql_real_connect (handle, mHost_r.c_str (), mUser_r.c_str (), mPassword_r.c_str (), mDatabase_r.c_str (), mPort_r, NULL, 0);
	fprintf(stderr,"%s", mysql_error(handle));
	WPFatal(retval, "Could not connect to database!");
	DatabaseInterface * db = new DatabaseInterface (handle);
	mInterfaces.insert (db);
	REALMLISTSRV.dbstate++;
#ifdef DEBUG_VERSION
	LOG.outString("DBI: Added interface [%d]",REALMLISTSRV.dbstate);
#endif
	return db;
}

DatabaseInterface * Database::createDatabaseInterface_w ()
{
	MYSQL * handle = mysql_init (NULL);
	MYSQL * retval = mysql_real_connect (handle, mHost_w.c_str (), mUser_w.c_str (), mPassword_w.c_str (), mDatabase_w.c_str (), mPort_w, NULL, 0);
	fprintf(stderr,"%s", mysql_error(handle));
	WPFatal(retval, "Could not connect to database!");
	DatabaseInterface * db = new DatabaseInterface (handle);
	mInterfaces.insert (db);
	REALMLISTSRV.dbstate++;
#ifdef DEBUG_VERSION
	LOG.outString("DBI: Added interface [%d]",REALMLISTSRV.dbstate);
#endif
	return db;
}

DatabaseInterface * Database::create_new_DatabaseInterface( const char *host, const char *user, const char *password, const char *database, uint32 port)
{
	MYSQL * handle = mysql_init (NULL);
	MYSQL * retval = mysql_real_connect (handle, host, user, password, database, port, NULL, 0);
	fprintf(stderr,"%s", mysql_error(handle));
	WPFatal(retval, "Could not connect to database!");
	DatabaseInterface *db = new DatabaseInterface (handle);
	mInterfaces.insert (db);
	REALMLISTSRV.dbstate++;
#ifdef DEBUG_VERSION
	LOG.outString("DBI: Added interface [%d]",REALMLISTSRV.dbstate);
#endif
	return db;
}

void Database::Initialize_r (const char *host, const char *user, const char *password, const char *database, uint32 port)
{
	mHost_r = host;
	mUser_r = user;
	mPassword_r = password;
	mDatabase_r = database;
	mPort_r = port;
}

void Database::Initialize_w (const char *host, const char *user, const char *password, const char *database, uint32 port)
{
	mHost_w = host;
	mUser_w = user;
	mPassword_w = password;
	mDatabase_w = database;
	mPort_w = port;
}
