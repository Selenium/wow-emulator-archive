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

#ifndef WOWPYTHONSERVER_DATABASE_H
#define WOWPYTHONSERVER_DATABASE_H

#include "Common.h"
#include "Singleton.h"
#include "DatabaseInterface.h"

#define DATABASE (Database::getSingleton ())

class Database : public Singleton <Database>
{
public:
	Database( );
	~Database( );
	void Initialize( const char *host, const char *user, const char *password, const char *database, uint32 port = 3306 );
	void removeDatabaseInterface( DatabaseInterface *db );
	DatabaseInterface * createDatabaseInterface( );

	inline bool GetAutoCreateAcct ()
	{ return m_bAutoCreateAcct; }
	inline void SetAutoCreateAcct (bool Enable)
	{ m_bAutoCreateAcct = Enable; }

	inline void SetFirewall (bool Enable)
	{ m_bFirewall = Enable; }
	inline bool GetFirewall ()
	{ return m_bFirewall; }
	inline void SetTestIP (bool Enable)
	{ m_bTestIP = Enable; }
	inline bool GetTestIP ()
	{ return m_bTestIP; }

private:
	std::string mHost,mUser,mPassword,mDatabase;
	uint32 mPort;
	std::set < DatabaseInterface * > mInterfaces;

	bool m_bAutoCreateAcct;
	bool m_bFirewall;
	bool m_bTestIP;
};

#endif
