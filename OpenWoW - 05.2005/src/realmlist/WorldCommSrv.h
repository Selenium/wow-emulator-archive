//////////////////////////////////////////////////////////////////////
// WorldCommSrv.h: interface for the WorldCommSrv class.
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

#ifndef WSDWORLDSERVERCOMM_H
#define WSDWORLDSERVERCOMM_H

#include "Client.h"
#include "Server.h"
#include "Singleton.h"

#define WORLDCOMMSRV (WorldCommSrv::getSingleton ())

class WorldCommSrv : public Server, public Singleton <WorldCommSrv>
{
	public:
		WorldCommSrv();
		~WorldCommSrv();

	protected:

		virtual void client_sockevent(nlink *cptr, unsigned short revents);
//		virtual void server_sockevent(nlink *cptr, uint16 revents, void *myNet );
		virtual void disconnect_client(nlink *cptr );

};

#endif
