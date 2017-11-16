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

#include "NetworkInterface.h"
#include "Sockets.h"
#include "Network.h"
#include "SystemFun.h"
#include "Debug.h"
#include <errno.h>
#include <stdio.h>
#include "constants.h"

#define char2short(ch) (*(ch)<<8)+*(ch+1)
#define RECVQEXCEED 131070//131070
#define SENDQEXCEED 131070//131070

Socket::Socket (socket_t sh, sockaddr_in *sa)
{
	handle = sh;
    memcpy (&inaddr, sa, sizeof (inaddr));
	amountUsed = 0;
	pleasekillme = false;
	mCallback = 0;
	mConnected = true;
	mRecvWaiting = 0;
	mSendWaiting = 0;
	mRecieving = 0;
	mSending = 0;
	sendqlen = 0;
	recvqlen = 0;
	sendqmax = 2048;
	recvqmax = 2048;
	sendq = (unsigned char *)malloc (sendqmax * sizeof (char));
	recvq = (unsigned char *)malloc (recvqmax * sizeof (char));
}

bool Socket::isConnected () const
{
	return mConnected;
}

Socket::~Socket ()
{
	/// Inform all users that suicide is our goal
	pleasekillme = true;
	mConnected = false;

	/// Wait until everybody's done with this socket
	while (amountUsed)
		SleepMs (100);

	so_close (handle);
}

Socket *Socket::AcceptConnection ()
{
	sockaddr_in inaddr;
	socklen_t inaddr_len = sizeof (sockaddr_in);
	socket_t sh = accept (handle, (struct sockaddr *) &inaddr, &inaddr_len);
	if (sh == SOCKET_ERROR)
                return NULL;
	if (inaddr_len != sizeof (sockaddr_in))
	{
		// Hmm.... what was that?! IPX?
		so_close (sh);
		return NULL;
	}
#ifdef DEBUG_VERSION
	LOG.outString ("Accepted incoming connection");
#endif
	Socket *sock = new Socket (sh, &inaddr);
	NETWORK.mInterfaces.insert (sock);
	return sock;
}

const uint8 *Socket::fillRecvQ ()
{
	// I need more tests on huge servers with many players. r-o-n-n-y
	signed int templen;
	if (!isConnected())
		return NULL;

	int repeatit = 1;
	while (repeatit == 1)
	{
		repeatit = 0;

		NAssertRP (templen = recv (handle, (char *)(recvq + recvqlen), recvqmax - recvqlen, 0));
		if (templen == -1)
		{
			WPAssert(so_errno != SOCKERR (WOULDBLOCK));
		}
		else
		{
			if (!templen)
			{
				mConnected = false;
				return NULL;
			}
			if (templen == recvqmax)
			{
				repeatit = 1;
				recvq = (unsigned char *)realloc(recvq, 2 * recvqmax);
				recvqmax = 2 * recvqmax;
				recvqlen += templen;
				if (recvqmax >= RECVQEXCEED)
				{
					// a nasty way to handle this :(
					printf ("NETWORK: Overflow RECVQEXCEED\n");
					mConnected = false;
					return NULL;
				}
			}
			else recvqlen += templen;
		}
	}
	return recvq;
}

uint32 Socket::sendPendingSendq()
{
	int status;
	uint32 written = 0;
	while( (written < uint32(getSendqLen())) && mConnected) {
		status = send(handle,(char *)sendq + written, getSendqLen() - written, 0);
		if (!status) {
			mConnected = false;
			break;
		}
		if (status == SOCKET_ERROR) {
			if (so_errno == SOCKERR (WOULDBLOCK)) {
				return written;
			}
			else {
				mConnected = false;
				break;
			}
		}
		else {
			written += status;
		}
	}
	return written;
}

void Socket::updateSendq(uint32 written)
{
	uint32 j;
	for(j = 0; j < sendqlen - written; j++)
	{
		*(sendq + j) = *(sendq + j + written);
	}
	sendqlen -= written;
}

void Socket::sendData (int length, const void *data)
{
#ifdef DEBUG_VERSION
	if (NETWORK.GetRealmLogging ())
	{
		char* d=(char*)data;
		FILE *pFile;
		pFile = fopen("realmlog.txt", "a");
		fprintf(pFile, "SERVER:\nSOCKET: %d\nLENGTH: %d\nOPCODE: %.2X\nDATA:\n", handle, length, d[0]);
		DebugDump (pFile, d+1, length-1);
		fprintf(pFile, "\n\n");
		fclose(pFile);
	}
#endif
	if(!_NIsend (data, length)) LOG.outDebug("Could not send packet");
}

void Socket::getData (int length, void *data)
{
	_NIrecv (data, length);
}


int Socket::_NIsend (const void * data, int length)
{
	WPAssert (data != 0);
	int status, clength = 0;
	while ((clength < length) & mConnected)
	{
		NAssertSpecial (status = send (handle, (char *)data + clength, length - clength, 0));
		if (status && status != SOCKET_ERROR)
			clength += status;
		else
			mConnected = false;
	}
	if(mConnected)
        return 1;
	else return 0;
}


void Socket::_NIWsend (unsigned char * data, int length)
{
	//WPAssert (data != 0);
//	int i;
	if (length == 0)
		return;

	while(length + sendqlen >= sendqmax)
	{
		sendqmax = sendqmax * 2;
		if (sendqmax > SENDQEXCEED)
		{
			sendqmax = SENDQEXCEED;
			while(length + sendqlen >= SENDQEXCEED)
			{
				uint32 status;
				status = sendPendingSendq();
				if (!mConnected)
				{
					return;
				}
				updateSendq(status);
			}
		}
		sendq = (unsigned char *)realloc(sendq, sendqmax);
	}

	memcpy((sendq+sendqlen),data,length);
/*	for(i = 0; i < length; i++)
	{
		*(sendq + sendqlen + i) = (char)data[i];
	}*/
	sendqlen += length;
}

void Socket::_NIrecv (void * data, int length)
{
	WPAssert (data != 0);
	int status, clength = 0;
	while ( (clength < length) && mConnected)
	{
		NAssert (status = recv (handle, (char *)data + clength, length - clength, 0));
		if (!status)
		{
			mConnected = false;
//			printf("connection error while reading\n");
		}
		if (status != SOCKET_ERROR)
			clength += status;
	}

}
