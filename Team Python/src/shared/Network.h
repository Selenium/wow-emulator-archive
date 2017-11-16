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

class Network : public Singleton < Network > {
  friend class NetworkInterface;
public:
  /// Constructor
  Network( );
  /// Destructor
  ~Network( );
  /// Initialisation
  void Initialise( );

  /// Open a TCP port and listen for connections
  NetworkInterface * createWorldListener( int port, void ( * callback ) ( NetworkInterface * ) = NULL );  

  /// Close a socket
  void removeNetworkInterface( NetworkInterface * );


  /// Close all sockets
  void clear( );

  /// Set mConnected to false in all NetworkInterfaces
  void disconnectAll( );

  /// Get the name of an errorcode
  char * getErrorName( uint32 code );

  inline bool IsLoggingWorld() { return m_loggingWorld; };
  inline void toggleWorldLogging() { m_loggingWorld = !m_loggingWorld; };

private:

  typedef std::set< NetworkInterface * > NetworkInterfaceSet;

  /// Currently active Network Interfaces
  NetworkInterfaceSet mInterfaces;

  bool mConnected;

  bool m_loggingWorld;
};

#endif

