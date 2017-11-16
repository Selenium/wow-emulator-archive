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

#ifndef WOWPYTHONSERVER_SERVER_H
#define WOWPYTHONSERVER_SERVER_H

#include<list>

#include "Common.h"
#include "Singleton.h"
#include "Network.h"

#define CF_DEAD 1

#define RSERVER 0
#define RCLIENT   1

#define PF_READ   1
#define PF_WRITE  2
#define PF_EXCEPT 4

class Client;

struct nlink
{
	struct nlink *next;
	struct nlink *prev;
	int fd;
	int flags;
	int type;
	Client *pClient;
};

class Server  {
	private:
		float mLastTime;
		uint32 mLastTicks;

	protected:
		typedef std::list< nlink *> NlinkList;
		NlinkList mLinks;

		typedef std::set< Client * > ClientSet;
		ClientSet mClients;

		virtual void Update (uint32 time) { (void)time; }

		/// Convenience pointer to the network singleton
		Network * mNetwork;

		/// Port this server is listening on
		int mPort;

		/// Is this server accepting connections?
		bool mActive;

		/// Has this server been instructed to stop?
		bool mStop;

		char * mType;

		static THREADCALL MainLoop (void * myServer);

	public:
		/// Constructor
		Server () : mActive (false) { }
		/// Destructor
		virtual ~Server () { }
		/// Initialisation
		void Initialize(unsigned int port, char* type);

		/// Begin listening for client connections
		void StartThreaded ();

		/// Stop accepting connections and disconnect all clients
		void Stop ();

		void Start ();
		//void StopWorld ();

		virtual void eventStart () { }
		virtual void eventStop () { }

		void nlink_insert(struct nlink *nptr)
		{
			mLinks.push_back(nptr);
		}
		void nlink_remove(NlinkList::iterator nptr)
		{
			nlink* tmp=(*nptr);
//			std::cout << "	SIZE_BEF: " << mLinks.size() << std::endl;
			mLinks.erase(nptr);
			delete tmp;
//			std::cout << "	SIZE_AFTER: " << mLinks.size() << std::endl;
		}
		
		NlinkList::iterator getHead () { return mLinks.begin (); }
		NlinkList::iterator getTail () { return mLinks.end (); }

		virtual void server_sockevent(struct nlink *cptr, unsigned short revents, void * myNet);
		virtual void client_sockevent(struct nlink *cptr, unsigned short revents)
		{ (void)cptr; (void)revents; }
		virtual void disconnect_client(struct nlink *cptr)
		{
			//	nlink_remove((nlink *)cptr);
			cptr->flags |= CF_DEAD;
		}
};

#endif
