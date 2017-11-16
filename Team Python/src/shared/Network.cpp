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

#include "Network.h"

#include "Sockets.h"
#include "Threads.h"

/// Singleton
createFileSingleton( Network );

Network::~Network( ) {
	clear( );
}

void Network::clear( ) {
	m_loggingWorld = false;
	NetworkInterfaceSet::iterator iterNI;
	/// Network's going down, close all open sockets
	for( iterNI = mInterfaces.begin( ); iterNI != mInterfaces.end( ); ++iterNI )
		delete ( NetworkInterface * ) (*iterNI);
	mInterfaces.clear( );
}

void Network::disconnectAll( ) {
	for( NetworkInterfaceSet::iterator iterNI = mInterfaces.begin( ); iterNI != mInterfaces.end( ); ++iterNI )
		(*iterNI)->mConnected = false;
}

Network::Network( ) {
	Initialise( );
}

void Network::Initialise( ) {
#if PLATFORM == PLATFORM_WIN32
	// Load Winsock 2.0
	WSADATA wsda;
	WSAStartup(MAKEWORD(2,0), &wsda);
#else
	signal(SIGPIPE, SIG_IGN);
#endif
	m_loggingWorld = true;
}




NetworkInterface * Network::createWorldListener( int port, void ( * callback ) ( NetworkInterface * ) ) {
	int opt = 1;

	/// Create the socket
	NetworkInterface * tempNI = new NetworkInterface( );
	tempNI->mSocketID = ( uint32 ) socket( AF_INET, SOCK_STREAM, 0 );
	// TODO: if( tempNI->mSocketID == SOCKET_ERROR ) // catch error with WSAGetLastError()

	/// Make blocking(I think that's how i need to do it :/)
	uint32 nonblockingstate = false;
	IOCTL_SOCKET( tempNI->mSocketID, IOCTL_NOBLOCK, &nonblockingstate );
	// Make socket accept multiple connections
	setsockopt(tempNI->mSocketID, SOL_SOCKET, SO_REUSEADDR,(char *)&opt, sizeof(opt));

	/// Set the address
	SOCKADDR_IN tempAddr;
	tempAddr.sin_family = AF_INET;
	tempAddr.sin_port = htons( port );
	tempAddr.sin_addr.s_addr = htonl( INADDR_ANY ); // Listen on any interface
	tempNI->internalAddress = new SOCKADDR_IN( tempAddr );

	/// TODO: handle error case of bind
	NAssertRP( bind( tempNI->mSocketID, (struct sockaddr *) tempNI->internalAddress, sizeof( SOCKADDR_IN ) ) );

	/// TODO: handle error case of listen
	NAssertRP( listen( tempNI->mSocketID, SOMAXCONN ) );


	/// Add this listening interface to our set
	mInterfaces.insert( tempNI );

	return tempNI;
}

void Network::removeNetworkInterface( NetworkInterface * net ) {
	delete *mInterfaces.find( net );
	mInterfaces.erase( net );
}

char * Network::getErrorName( uint32 code ) {
	//assert( false );
	switch( code ) {
	case SOCKERR(FAULT):
		return "[EFAULT] Bad address";
	case SOCKERR(INTR):
		return "[EINTR] Interrupted function call";
	case SOCKERR(MFILE):
		return "[EMFILE] Too many open files";
	case SOCKERR(CONNRESET):
		return "[ECONNRESET] Connection reset by peer";
	case SOCKERR(ACCES):
		return "[EACCES] Permission denied";
	case SOCKERR(WOULDBLOCK):
		return "[EWOULDBLOCK] Resource temporarily unavailable";
	case SOCKERR(INVAL):
		return "[EINVAL] Invalid argument";
	case SOCKERR(CONNABORTED):
		return "[ECONNABORTED] Software caused connection abort";
	case SOCKERR(SHUTDOWN):
		return "[ESHUTDOWN] Cannot send after socket shutdown.";
	case SOCKERR(ADDRINUSE):
		return "[EADDRINUSE] Address already in use.";
#if PLATFORM != PLATFORM_WIN32
	case SOCKERR(PIPE):
		return "[EPIPE] Broken pipe.";
#endif
	case SOCKERR(TIMEDOUT):
		return "[ETIMEDOUT] Connection timed out.";
	}

	char buf[256];
	sprintf( buf, "unknown: %i", code );
#if PLATFORM != PLATFORM_WIN32
	perror( " unknown ");
#endif
	Log::getSingleton( ).outString( buf );
	assert( false && "UNKNOWN ERROR CODE" );
	return "UNKNOWN ERROR";
}

