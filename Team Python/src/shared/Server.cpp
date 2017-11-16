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

#include "Server.h"
#include "RealmListSrv.h"
#include "Network.h"
#include "Log.h"
#include "Threads.h"
#include "Client.h"
#include "Sockets.h"

#include "math.h"
#include <time.h>
#include "Timer.h"

#if PLATFORM == PLATFORM_WIN32
#include <windows.h>
#else
#include <unistd.h>
#include <sys/select.h>
#endif
#include <stdlib.h>
#include <iostream>

void Server::Initialise(unsigned int port, char* type) {
  mNetwork = Network::getSingletonPtr( );
  mPort = port;
  mType = type;
}

void Server::Start( ) {
  if( !mActive ) {
    mActive = true;
    mStop = false;
	eventStart( );
    Threads::getSingleton( ).Fork( MainLoop, this, Threads::TP_HIGHER );
	mLastTicks = clock( );
	mLastTime = (float)mLastTicks / CLOCKS_PER_SEC;
    //_beginthread( threadListen, 0, this );
  }
}

void Server::Stop( ) {
  mStop = true;
  while( mActive );
  eventStop( );
}

THREADCALL Server::MainLoop( void * myServer ) {
  NetworkInterface * listener = Network::getSingleton( ).createWorldListener( ((Server *) myServer)->mPort );
  nlink_server * cptr;
  nlink * tCptr;

  cptr = new nlink_server;
  cptr->hdr.type = RSERVER;
  cptr->hdr.flags = 0;
  cptr->hdr.fd = listener->getSocketID();
  ((Server *)myServer)->nlink_init();
  ((Server *)myServer)->nlink_insert((nlink *)cptr);
  int res;
  struct timeval selectTimeout;
  selectTimeout.tv_sec = 0;
  selectTimeout.tv_usec = 100000;
  int nfds;
  fd_set rfds;
  fd_set wfds;
  fd_set efds;
  unsigned short revents;
  //float timeDif; 
  //uint32 newTicks;
  uint32 realCurrTime, realPrevTime, realTimeDiff;
  realPrevTime = getMSTime();
  realTimeDiff = 0;
  while( ! ( (Server *)myServer )->mStop ) {
	realCurrTime = getMSTime();
	if (realPrevTime > realCurrTime) { //uint32 exceeded
		realPrevTime = 0;
	}
	realTimeDiff = realCurrTime - realPrevTime;

    ((Server *)myServer)->Update( realTimeDiff );
	realPrevTime = realCurrTime;

    nfds = 0;
	FD_ZERO(&rfds);
	FD_ZERO(&wfds);
	FD_ZERO(&efds);
	tCptr = ((Server *)myServer)->getHead();
	while(tCptr)
	{
		if (tCptr->flags & CF_DEAD)
		{
#if PLATFORM == PLATFORM_WIN32
				closesocket(tCptr->fd);
#else
				close(tCptr->fd);
#endif
			tCptr = ((Server *)myServer)->nlink_remove((nlink *)tCptr);
			continue;
		}
		switch(tCptr->type)
		{
		case RSERVER:
			{
				FD_SET(tCptr->fd, &rfds);
				if (tCptr->fd >= nfds)
					nfds = tCptr->fd + 1;
				break;
			}
		case RCLIENT:
			{
				FD_SET(tCptr->fd, &rfds);
				if (tCptr->fd >= nfds)
					nfds = tCptr->fd + 1;
				//printf("Write Buffer: %d\n",(((nlink_client *)tCptr)->pClient)->getNetwork()->getSendqLen());
				if ( (((nlink_client *)tCptr)->pClient)->getNetwork()->getSendqLen()  > 0)
				{
					FD_SET(tCptr->fd, &wfds);
					if (tCptr->fd >= nfds)
						nfds = tCptr->fd + 1;
				}
				break;
			}
		}
		tCptr = tCptr->next;
	}

	selectTimeout.tv_sec = 0;
    selectTimeout.tv_usec = 100000; // 100ms timeout

	res = select(nfds, &rfds, &wfds, &efds, &selectTimeout);

	if (res == 0)
		continue;
	if (res == -1)
		break;
	for(tCptr = ((Server *)myServer)->getHead() ; tCptr; tCptr = tCptr->next)
	{
		if (tCptr->flags & CF_DEAD)
			continue;
		revents = 0;
		if(FD_ISSET(tCptr->fd, &rfds))
			revents |= PF_READ;
		if(FD_ISSET(tCptr->fd, &wfds))
			revents |= PF_WRITE;
		if(FD_ISSET(tCptr->fd, &efds))
			revents |= PF_EXCEPT;
		if (revents) 
		{
			if (tCptr->type == RSERVER)
			{
				((Server *)myServer)->server_sockevent((nlink_server *)tCptr, revents , listener);
			}
			else if (tCptr->type == RCLIENT)
			{
				((Server *)myServer)->client_sockevent((nlink_client *)tCptr, revents);
			}
		}

	}
  }

  ((Server *)myServer)->mActive = false;

  ENDTHREAD
}

void Server::server_sockevent( nlink_server *cptr, uint16 revents, void *myNet ) {
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
		mClients.insert(pClient);
	}
}
