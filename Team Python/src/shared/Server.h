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
class Server  {
public:
    /// Constructor
    Server( ) : mActive( false ) { }
    /// Destructor
    ~Server( ) { }
    /// Initialisation
    void Initialise(unsigned int port, char* type );

    /// Begin listening for client connections
    void StartThreaded( );

    /// Stop accepting connections and disconnect all clients
    void Stop( );

    void Start( );
    //void StopWorld( );

	virtual void eventStart( ) { }
	virtual void eventStop( ) { }

    struct nlink
    {
        struct nlink *next;
        struct nlink *prev;
        int fd;
        int flags;
        int type;
    };

    struct nlink_server
    {
        struct nlink hdr;
    };

    struct nlink_client
    {
        struct nlink hdr;
        Client *pClient;
    };


    struct nlinklist
    {
        struct nlink *head;
        struct nlink *tail;
    };

    void nlink_insert(struct nlink *nptr)
    {
        nptr->prev = g_netlink->tail;
        nptr->next = NULL;
        if(g_netlink->tail)
            g_netlink->tail->next = nptr;
        else
            g_netlink->head = nptr;	
        g_netlink->tail = nptr;
    }
    struct nlink * nlink_remove(struct nlink *nptr)
    {
        struct nlink *fptr;
        fptr = nptr;
        nptr = nptr->next;
        if(fptr->next)
            fptr->next->prev = fptr->prev;
        else
            g_netlink->tail = fptr->prev;

        if(fptr->prev)
            fptr->prev->next = fptr->next;
        else
            g_netlink->head = fptr->next;
        free(fptr);
        return nptr;
    }
    void nlink_init()
    {
        g_netlink->tail = NULL;
        g_netlink->head = NULL;
    }
    struct nlink * getHead() { return g_netlink->head; }

    virtual void server_sockevent(struct nlink_server *cptr, unsigned short revents, void * myNet);
    virtual void client_sockevent(struct nlink_client *cptr, unsigned short revents) {}
    virtual void disconnect_client(	struct nlink_client *cptr ) {
    //	nlink_remove((nlink *)cptr);
	    cptr->hdr.flags |= CF_DEAD;
    }

protected:
	struct nlinklist g_netlink[1];

    virtual void Update( uint32 time ) { }

    /// Convenience pointer to the network singleton
    Network * mNetwork;

    /// Port this server is listening on
    int mPort;

    /// Is this server accepting connections?
    bool mActive;

    /// Has this server been instructed to stop?
    bool mStop;

    char * mType;

    static THREADCALL MainLoop( void * myServer );

	typedef std::set< Client * > ClientSet;
	ClientSet mClients;

private:
    float mLastTime;
	uint32 mLastTicks;
};



#endif

