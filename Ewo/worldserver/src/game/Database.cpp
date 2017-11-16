// Copyright (C) 2004 Team Python
// Copyright (C) 2006 Team Evolution
//  
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software 
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.



#include "Database.h"
#include "Errors.h"
#include "Sockets.h"
#include "Threads.h"
#include "WorldServer.h"
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
	WORLDSERVER.dbstate--;
	mInterfaces.erase (db);
	char logoutput[50];
	sprintf(logoutput, "DBI: Removed interface [%d]", WORLDSERVER.dbstate);
	LOG.outString (logoutput);
}

DatabaseInterface * Database::createDatabaseInterface_r ()
{
	MYSQL * handle = mysql_init (NULL);
	MYSQL * retval = mysql_real_connect (handle, mHost_r.c_str (), mUser_r.c_str (), mPassword_r.c_str (), mDatabase_r.c_str (), mPort_r, NULL, 0);
	fprintf(stderr,"%s", mysql_error(handle));
	WPFatal(retval, "Could not connect to database!");
	DatabaseInterface * db = new DatabaseInterface (handle);
	mInterfaces.insert (db);
	WORLDSERVER.dbstate++;
	char logoutput[50];
	sprintf(logoutput, "DBI: Added interface [%d]",WORLDSERVER.dbstate);
	LOG.outString (logoutput);
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
	WORLDSERVER.dbstate++;
	char logoutput[50];
	sprintf(logoutput, "DBI: Added interface [%d]",WORLDSERVER.dbstate);
	LOG.outString (logoutput);
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
	WORLDSERVER.dbstate++;
	char logoutput[50];
	sprintf(logoutput, "DBI: Added interface [%d]",WORLDSERVER.dbstate);
	LOG.outString (logoutput);
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
