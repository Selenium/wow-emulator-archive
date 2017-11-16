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

#ifndef WOWPYTHONSERVER_REDIRECTORSRV_H
#define WOWPYTHONSERVER_REDIRECTORSRV_H

#include "Common.h"
#include "Client.h"

#include "Server.h"
#include "Network.h"

class RedirectorSrv : public Server {
public:
    RedirectorSrv( ) { }
    ~RedirectorSrv( ) { }
    void Initialise( int port, char * type, char * destination );
protected:

	virtual void client_sockevent(struct nlink_client *cptr, unsigned short revents);
	virtual void server_sockevent( nlink_server *cptr, uint16 revents, void *myNet );
	virtual void disconnect_client(	struct nlink_client *cptr );
	
	std::string mDestination;
private:
    void Initialise( int port, char * type );
};

#endif

