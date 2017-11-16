// Copyright (C) 2004 Team Python
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
	m_bAutoCreateAcct = false;
	m_bFirewall = false; //LINA ADD FIREWALL
	m_bTestIP = false; //LINA ADD FIREWALL
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

DatabaseInterface * Database::createDatabaseInterface ()
{
	MYSQL * handle = mysql_init (NULL);
	MYSQL * retval = mysql_real_connect (handle, mHost.c_str (), mUser.c_str (), mPassword.c_str (), mDatabase.c_str (), mPort, NULL, 0);

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

void Database::Initialize (const char *host, const char *user, const char *password, const char *database, uint32 port)
{
	mHost = host;
	mUser = user;
	mPassword = password;
	mDatabase = database;
	mPort = port;
	/*
	DatabaseInterface * db = createDatabaseInterface ();
	*/

	/*I made these one line because its easies for me to type SQL querys like this
	Also as a note, switched engine type to InnoDB for linking purposes, added acct field
	added 2nd database.  --battyone 
	//The line below makes the characters table
	db->doQuery (" CREATE TABLE characters (ID BIGINT NOT NULL AUTO_INCREMENT UNIQUE PRIMARY KEY, name char(21) not null, race tinyint, class tinyint, gender tinyint, skin tinyint, face tinyint, hairStyle tinyint,hairColor tinyint, facialHair tinyint, level tinyint, outfitId tinyint, zoneId smallint,  mapId smallint, positionX float, positionY float, positionZ float, guildId smallint, petInfoId smallint, petLevel smallint, petFamilyId smallint, acct BIGINT not null, orientation float) ENGINE=InnoDB");
	//The line below makes the accounts table 
	db->doQuery (" CREATE TABLE accounts (acct BIGINT NOT NULL AUTO_INCREMENT UNIQUE PRIMARY KEY, login char(20), password char(20)) ENGINE=InnoDB"); 
	//The line below makes the creatures table
	db->doQuery (" CREATE TABLE creatures (ID BIGINT(20) NOT NULL AUTO_INCREMENT UNIQUE PRIMARY KEY, name varchar(100), positionX float, positionY float, positionZ float, displayid int(11), npcflags int(11), level int(11), health int(11), mana int(11), mapId int(11))) ENGINE=InnoDB");
	//Switched the engine to InnoDB, having 2 different engines running causes some ram issues, and the mysam engine is not as efficent.

	removeDatabaseInterface (db);
	*/
}
