//////////////////////////////////////////////////////////////////////
// WorldCommSrv.cpp: implementation of the WorldCommSrv class.
//
//////////////////////////////////////////////////////////////////////

// Copyright (C) 2005 Team WSD
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

#include "WorldCommSrv.h"
#include "Log.h"
#include "Singleton.h"
#include "Sockets.h"
#include "UserHashes.h"
#include "SrpRealm.h"
#include <string>
#include <math.h>

using namespace std;

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

createFileSingleton( WorldCommSrv );


WorldCommSrv::WorldCommSrv( )
{
}

WorldCommSrv::~WorldCommSrv( )
{
}

enum opcode {
	UPDATESRV = 0x01,
	SSHASH = 0x02
};

void WorldCommSrv::client_sockevent( nlink *cptr, unsigned short revents)
{
	if(revents & PF_READ)
	{
		Client *pClient = static_cast < Client * > ( cptr->pClient );
		Socket *net = pClient->getNetwork();
		uint8 opcode;

		if (!net->isConnected()) {
			disconnect_client(cptr);
			return;
		}

		net->getData( 1, &opcode );

		if (!net->isConnected()) {
			disconnect_client(cptr);
			return;
		}

		switch( opcode ) {
			/*
			   case UPDATESRV:
			   {
			   char buf[256];
			   char *realm;
			   char *count;
			   string rTemp = "";
			   LOG.outString( "WORLDCOMMSRV: Recieved UPDATESRV request" );
			   net->getData( 256, buf );
			   realm = strtok(buf,";");
			   count = strtok(NULL,";");
			   rTemp="";
			   rTemp.append(realm);
			// 2, 2 stands for unchanged icon and color
			this->setRealm( const_cast<char *>(rTemp.c_str()), 2, 2, atoi(count) );

			}break;
			*/
			case SSHASH:
				{
					uint8 length;
					char buf[256];
					char *tmp;
					net->getData(1, &length);
					net->getData(length, buf);
					buf[length]='\0';
					LOG.outString( "WORLDCOMMSRV: Received SSHASH request for user: %s", buf );
					ClientSet::iterator itr;
					if ((tmp = USERHASHES.getHash (buf)))
					{
						//send hash
						char data[1024];
						int doo = 0;
						data[ doo++ ]=0x00;
						data[ doo++ ]=4+40+strlen(buf);
						data[ doo++ ]=0x01;
						data[ doo++ ]=0xFF;
						data[ doo++ ]=0x00;
						data[ doo++ ]=0x00;
						memcpy(data+doo, tmp, 40);
						doo+=40;
						memcpy(data+doo, buf, strlen(buf));
						doo+=strlen(buf);
						net->sendData(doo, data);
						LOG.outString( "WORLDCOMMSRV: Sent SSHASH for user: %s", buf );
						//disconnect_client(cptr);
						return;
					}

					LOG.outString( "WORLDCOMMSRV: No SSHASH for user: %s anymore", buf );
				}

			default:
				{
					LOG.outString( "WORLDCOMMSRV: Recieved unknown opcode %i", opcode );
				}break;
		} //switch opcode

	} // if pfread

}

void WorldCommSrv::disconnect_client( struct nlink *cptr )
{
	Client * pClient = static_cast < Client * > ( cptr->pClient );
	printf("Erasing mClients pClient\n");
	mClients.erase( pClient );
	delete pClient;
	LOG.outString( "REALM: Socket Closed!" );
	Server::disconnect_client( cptr );
}

