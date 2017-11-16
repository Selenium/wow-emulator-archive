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

#include "RedirectorSrv.h"

#include "Network.h"
#include "Log.h"
#include "Sockets.h"

void RedirectorSrv::client_sockevent(struct nlink_client *cptr, unsigned short revents){
}

void RedirectorSrv::Initialise( int port, char *type, char * destination ) {
    assert( this != 0 );
    mDestination = destination;
    Server::Initialise( port, type );
}


void RedirectorSrv::server_sockevent( nlink_server *cptr, uint16 revents, void *myNet ) {
	NetworkInterface * client;
	struct nlink_client *ncptr;
	if(revents & PF_READ)
	{
		client = ( ( NetworkInterface * ) myNet )->getConnection( );
		if (!client) 
			return;
		uint32 nonblockingstate = true;
		IOCTL_SOCKET( client->getSocketID(), IOCTL_NOBLOCK, &nonblockingstate );

		ncptr = new nlink_client;
		if(ncptr == NULL)
			return;
		memset(ncptr, 0, sizeof(*ncptr));
		ncptr->hdr.type = RCLIENT;
		ncptr->hdr.fd = client->getSocketID();
		
		nlink_insert((struct nlink *)ncptr);

		Client *pClient = new Client();
		pClient->BindNI(client);
		ncptr->pClient = pClient;
		pClient->getNetwork()->sendData( mDestination.length( ), mDestination.c_str( ) );
		Log::getSingleton( ).outString( "REDIRECTOR: Sent world server" );
		disconnect_client( ncptr );
	}
}

void RedirectorSrv::disconnect_client(	struct nlink_client *cptr )
{
	Client * pClient = static_cast < Client * > ( cptr->pClient );
	mClients.erase( pClient );
	delete pClient;
	Log::getSingleton( ).outString( "REDIRECTOR: Socket Closed!" );
	Server::disconnect_client( cptr );
}


