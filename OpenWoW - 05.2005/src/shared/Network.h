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

#ifndef WOWPYTHONSERVER_NETWORK_H
#define WOWPYTHONSERVER_NETWORK_H

#include "Common.h"
#include "Singleton.h"
#include "Threads.h"
#include <errno.h>

#include "NetworkInterface.h"

#define NETWORK (Network::getSingleton ())

class Network : public Singleton <Network>
{
	friend class Socket;
public:
	/// Constructor
	Network( );
	/// Destructor
	~Network( );
	/// Initialisation
	void Initialize( );

	/// Open a TCP port and listen for connections
	Socket *CreateListener (int port);

	/// Open new socket and try to connect to host:port
	Socket *Connect (int port, char *host);

	/// Close a socket
	void removeSocket (Socket *);

	/// Close all sockets
	void Clear( );

	/// Set mConnected to false in all Sockets
	void disconnectAll( );

	/// Get the name of an errorcode
	char * getErrorName( uint32 code );

	inline bool GetWorldLogging ()
	{ return m_loggingWorld; };
	inline void SetWorldLogging (bool Enable)
	{ m_loggingWorld = Enable; };
	inline bool GetRealmLogging ()
	{ return m_loggingRealm; };
	inline void SetRealmLogging (bool Enable)
	{ m_loggingRealm = Enable; };

	private:

	typedef std::set< Socket * > SocketSet;

	/// Currently active Network Interfaces
	SocketSet mInterfaces;

	bool mConnected;

	bool m_loggingWorld;
	bool m_loggingRealm;
};

#endif

