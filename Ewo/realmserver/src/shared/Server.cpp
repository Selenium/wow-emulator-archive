// Copyright (C) 2004 Team Python
// Copyright (C) 2006 Team Evolution
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
#include "Network.h"
#include "Log.h"
#include "Threads.h"
#include "Client.h"
#include "Sockets.h"

#include "math.h"
#include <time.h>
#include "SystemFun.h"

#if PLATFORM == PLATFORM_WIN32
#include <windows.h>
#else
#include <unistd.h>
#include <sys/select.h>
#endif
#include <stdlib.h>
#include <iostream>

#include "constants.h"

void Server::Initialize(unsigned int port, char* type) {
	mNetwork = Network::getSingletonPtr( );
	mPort = port;
	mType = type;
}

void Server::Start ()
{
	if (!mActive)
	{
		mActive = true;
		mStop = false;
		eventStart ();
		THREADS.Fork (MainLoop, this, Threads::TP_HIGHER);
		mLastTicks = clock ();
		mLastTime = (float)mLastTicks / CLOCKS_PER_SEC;
		//_beginthread( threadListen, 0, this );
	}
}

void Server::Stop ()
{
	mStop = true;
	while (mActive)
		eventStop ();
}

//i'm only guessing how this works :) (noob)
//1) create a port listener in blocking state(will wait until something reads/writes to the port)
//2) create a new link to listen to the R server 
//3) while server is not instructed to stop (mStop)
//3.1) test if we have to close one of the sockets
//3.2) wait max 100 Ms or until one of the ports has an event
//3.3) if waikup was made by port event then we
THREADCALL Server::MainLoop (void * myServer)
{
	Socket *listener = NETWORK.CreateListener (((Server *) myServer)->mPort);
	if (!listener)
	{
		((Server *)myServer)->mActive = false;
		ENDTHREAD
	}
	nlink * cptr;
	NlinkList::iterator tCiter;
	nlink *tCptr;
	cptr = new nlink;	// first server element
	cptr->type = RSERVER;
	cptr->flags = 0;
	cptr->fd = listener->GetHandle();
	cptr->pClient = NULL;
	((Server *)myServer)->nlink_insert(cptr);
	int res;
	struct timeval selectTimeout;
	selectTimeout.tv_sec = 0;
	selectTimeout.tv_usec = 100000;
	int nfds;
	fd_set rfds;
	fd_set wfds;
	fd_set efds;
	unsigned short revents;
	uint32 realCurrTime, realPrevTime, realTimeDiff;
//	realPrevTime = GetMilliseconds();
	realPrevTime = timeGetTime ();
	realTimeDiff = 0;
	while (!((Server *)myServer)->mStop)
	{
		realCurrTime = timeGetTime ();
		if (realPrevTime > realCurrTime)
			realPrevTime = 0;
		realTimeDiff = realCurrTime - realPrevTime;
		((Server *)myServer)->Update( realTimeDiff );
		realPrevTime = realCurrTime;
		nfds = 0;
		FD_ZERO(&rfds);
		FD_ZERO(&wfds);
		FD_ZERO(&efds);
		for(tCiter = ((Server *)myServer)->getHead(); tCiter != ((Server *)myServer)->getTail(); tCiter++)
		{
			tCptr = (*tCiter);
			if (tCptr->flags & CF_DEAD)
			{
				so_close (tCptr->fd);
				((Server *)myServer)->nlink_remove(tCiter++);
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
						//printf("Write Buffer: %d\n",(tCptr->pClient)->getNetwork()->getSendqLen());
						if ( (tCptr->pClient)->getNetwork()->getSendqLen()  > 0)
						{
							FD_SET(tCptr->fd, &wfds);
							if (tCptr->fd >= nfds)
								nfds = tCptr->fd + 1;
						}
						break;
					}
			}
		}
		selectTimeout.tv_sec = 0;
		selectTimeout.tv_usec = UPDATE_THREAD_MILISECONDS_SLEEP_MAX;
		res = select(nfds, &rfds, &wfds, &efds, &selectTimeout);
		if (res == 0)
			continue;
		if (res == -1)
			break;
		for(tCiter = ((Server *)myServer)->getHead(); tCiter != ((Server *)myServer)->getTail(); tCiter++)
		{
			tCptr = (*tCiter);
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
					((Server *)myServer)->server_sockevent(tCptr, revents , listener);
				else if (tCptr->type == RCLIENT)
					((Server *)myServer)->client_sockevent(tCptr, revents);
			}
		}
	}
	((Server *)myServer)->mActive = false;
	ENDTHREAD
}

void Server::server_sockevent( nlink *cptr, uint16 revents, void *myNet ) {
	Socket * client;
	struct nlink *ncptr;
	if(revents & PF_READ)
	{
		client = ((Socket *) myNet)->AcceptConnection ();
		if (!client)
			return;
		ulong nonblockingstate = true;
		so_ioctl (client->GetHandle(), FIONBIO, &nonblockingstate);
		ncptr = new nlink;
		if(ncptr == NULL)
			return;
		memset(ncptr, 0, sizeof(*ncptr));
		ncptr->type = RCLIENT;
		ncptr->fd = client->GetHandle();
		nlink_insert(ncptr);
		Client *pClient = new Client();
		pClient->BindNI(client);
		ncptr->pClient = pClient;
		mClients.insert(pClient);
	}
}
