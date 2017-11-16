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

#include "Network.h"

#include "Sockets.h"
#include "Threads.h"

/// Singleton
createFileSingleton (Network);

Network::~Network ()
{
	Clear ();
}

void Network::Clear ()
{
	m_loggingWorld = false;
	m_loggingRealm = false;
	SocketSet::iterator iterNI;
	/// Network's going down, close all open sockets
	for (iterNI = mInterfaces.begin (); iterNI != mInterfaces.end (); ++iterNI)
		delete (Socket *) (*iterNI);
	mInterfaces.clear ();
}

void Network::disconnectAll ()
{
	for (SocketSet::iterator iterNI = mInterfaces.begin ();
	     iterNI != mInterfaces.end (); ++iterNI)
		(*iterNI)->mConnected = false;
}

Network::Network ()
{
	Initialize ();
}

void Network::Initialize ()
{
#if PLATFORM == PLATFORM_WIN32
	// Load Winsock 2.0
	WSADATA wsda;
	WSAStartup(MAKEWORD(2,0), &wsda);
#else
	signal(SIGPIPE, SIG_IGN);
#endif
	m_loggingWorld = false;
	m_loggingRealm = false;
}


Socket *Network::CreateListener (int port)
{
//	printf("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!Creating a new listener\n");
	/// Create the socket
	socket_t sh = (uint32) socket (AF_INET, SOCK_STREAM, 0);
	if (sh == SOCKET_ERROR)
		return NULL;

	// Switch to blocking state (socket is created in blocking state, no need -- zap)
	//u_long flag = 0;
	//so_ioctl (sh, FIONBIO, &flag);

	// Make socket accept multiple connections
	int opt = 1;
	setsockopt (sh, SOL_SOCKET, SO_REUSEADDR, (char *)&opt, sizeof (opt));

	// Bind socket to address
	sockaddr_in inaddr;
	inaddr.sin_family = AF_INET;
	inaddr.sin_port = htons (port);
	inaddr.sin_addr.s_addr = htonl (INADDR_ANY); // Listen on any interface
	if (bind (sh, (struct sockaddr *)&inaddr, sizeof (inaddr)) == SOCKET_ERROR)
	{
error:		so_close (sh);
		return NULL;
	}

	if (listen (sh, SOMAXCONN) == SOCKET_ERROR)
		goto error;

	Socket *sock = new Socket (sh, &inaddr);

	// Add this listening interface to our set
	mInterfaces.insert (sock);

	return sock;
}

Socket *Network::Connect (int port, char *host)
{
	struct hostent *he;
	if ((he = gethostbyname (host)) == NULL)
		return NULL;

	socket_t sh = socket (AF_INET, SOCK_STREAM, 0);
	if (sh == SOCKET_ERROR)
		return NULL;

	sockaddr_in inaddr;
	inaddr.sin_family = AF_INET;
	inaddr.sin_port = htons (port);
	inaddr.sin_addr = *((struct in_addr *)he->h_addr);

	if (connect (sh, (struct sockaddr *)&inaddr, sizeof(inaddr)) == SOCKET_ERROR)
	{
		LOG.outError("Couldn't connect to: %s:%d.", host, port);
		so_close (sh);
		return NULL;
	}

	// Create the socket
	Socket *sock = new Socket (sh, &inaddr);

#ifdef DEBUG_VERSION
	LOG.outString ("Connected to: %s:%d", host, port);
#endif
	// Add this listening interface to our set
	mInterfaces.insert (sock);

	return sock;
}

void Network::removeSocket (Socket * net)
{
	delete *mInterfaces.find (net);
	mInterfaces.erase (net);
}

char * Network::getErrorName (uint32 code)
{
	switch (code)
	{
	case SOCKERR (FAULT):
		return "[EFAULT] Bad address";
	case SOCKERR (INTR):
		return "[EINTR] Interrupted function call";
	case SOCKERR (MFILE):
		return "[EMFILE] Too many open files";
	case SOCKERR (CONNRESET):
		return "[ECONNRESET] Connection reset by peer";
	case SOCKERR (ACCES):
		return "[EACCES] Permission denied";
	case SOCKERR (WOULDBLOCK):
		return "[EWOULDBLOCK] Resource temporarily unavailable";
	case SOCKERR (INVAL):
		return "[EINVAL] Invalid argument";
	case SOCKERR (CONNABORTED):
		return "[ECONNABORTED] Software caused connection abort";
	case SOCKERR (SHUTDOWN):
		return "[ESHUTDOWN] Cannot send after socket shutdown.";
	case SOCKERR (ADDRINUSE):
		return "[EADDRINUSE] Address already in use.";
#if PLATFORM != PLATFORM_WIN32
	case SOCKERR (PIPE):
		return "[EPIPE] Broken pipe.";
#endif
	case SOCKERR (TIMEDOUT):
		return "[ETIMEDOUT] Connection timed out.";
	}

	char buf[256];
	sprintf (buf, "unknown: %u", code);
#if PLATFORM != PLATFORM_WIN32
	perror (" unknown ");
#endif
	LOG.outString (buf);
	//assert (false && "UNKNOWN ERROR CODE");
	return "UNKNOWN ERROR";
}
