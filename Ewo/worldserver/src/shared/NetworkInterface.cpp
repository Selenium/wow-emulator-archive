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
#include "opcodes.h"

#define char2short(ch) (*(ch)<<8)+*(ch+1)

Socket::Socket (socket_t sh, sockaddr_in *sa)
{
	handle = sh;
    memcpy (&inaddr, sa, sizeof (inaddr));
//	pleasekillme = false;
	mCallback = 0;
	mConnected = true;
}

inline bool Socket::isConnected () const
{
	return mConnected;
}

Socket::~Socket ()
{
	/// Inform all users that suicide is our goal
//	pleasekillme = true;
	mConnected = false;

	so_close (handle);
}

Socket *Socket::AcceptConnection ()
{
	sockaddr_in inaddr;
	socklen_t inaddr_len = sizeof (sockaddr_in);
	socket_t sh = accept (handle, (struct sockaddr *) &inaddr, &inaddr_len);
	if (sh == SOCKET_ERROR) return NULL;
	if (inaddr_len != sizeof (sockaddr_in))
	{
		so_close (sh);
		return NULL;
	}
#ifdef _DEBUG
	LOG.outString ("Accepted incoming connection");
#endif
	Socket *sock = new Socket (sh, &inaddr);
	NETWORK.mInterfaces.insert (sock);
	return sock;
}

uint32 Socket::fillRecvQ (uint8 *buffer,uint32 max_buffer_len)
{
	int templen;
	templen = recv (handle, (char *)(buffer), max_buffer_len, 0);
	if ((templen == 0) || (templen == -1 && so_errno != SOCKERR (WOULDBLOCK)))
	{
		//this means that some error happened. Kick the client. He is not that important :P
#ifdef _DEBUG
	LOG.outString ("ReadSocket error. Kicking client!");
#endif
		mConnected = false;
		return NULL;
	}
	return templen;
}

void Socket::sendWData (NetworkPacket * data, SrpWorld* srp)
{
	//	printf("	USERNAME:%s\n", (srp->user));
	//	printBytes(srp->SS_Hash, 40, "SS-HASH");
	if (!isConnected()) return;
	uint8 b[4];
	int packet_length = data->length + 2;
#ifdef _DEBUG
	if (NETWORK.GetWorldLogging ())
	{
		FILE *pFile;
		pFile = fopen("worldlog.txt", "a");
		fprintf(pFile, "SERVER:\nSOCKET: %d\nLENGTH: %d\nOPCODE: %.4X = %s\nDATA:\n", handle, packet_length, data->opcode,LookupName(data->opcode, g_worldOpcodeNames));
		DebugDump (pFile, data->data, data->length);
		fprintf(pFile, "\n\n");
		fclose(pFile);
	}
	//force some time to be inserted between packets
//	if(GetTickCount()<can_send_after_stamp)
//		Sleep(CLIENT_PACKET_PROCESS_TIME_MIN);
//	can_send_after_stamp = GetTickCount() + CLIENT_PACKET_PROCESS_TIME_MIN;
#endif
	b[0] = packet_length >> 8;
	b[1] = (uint8)(packet_length);
	*(uint16*)&b[2] = data->opcode;
	//printBytes((char*)b, 4, "ENCODE before");
	srp->encode((unsigned char*)b);
	_NIsend (b, 4);
	//printBytes((char*)b, 4, "ENCODE after");
	_NIsend (data->data, data->length);
}

void Socket::sendData (WowData * data, SrpWorld* srp)
{
	//	printf("	USERNAME:%s\n", (srp->user));
	//	printBytes(srp->SS_Hash, 40, "SS-HASH");
	if (!isConnected()) return;
	uint8 b[4];
	int packet_length = data->length + 2;
#ifdef _DEBUG
	if (NETWORK.GetWorldLogging ())
	{
		FILE *pFile;
		pFile = fopen("worldlog.txt", "a");
		fprintf(pFile, "SERVER:\nSOCKET: %d\nLENGTH: %d\nOPCODE: %.4X = %s\nDATA:\n", handle, packet_length, data->opcode,LookupName(data->opcode, g_worldOpcodeNames));
		DebugDump (pFile, data->data, data->length);
		fprintf(pFile, "\n\n");
		fclose(pFile);
	}
	//force some time to be inserted between packets
//	if(GetTickCount()<can_send_after_stamp)
//		Sleep(CLIENT_PACKET_PROCESS_TIME_MIN);
//	can_send_after_stamp = GetTickCount() + CLIENT_PACKET_PROCESS_TIME_MIN;
#endif
	b[0] = packet_length >> 8;
	b[1] = (uint8)(packet_length);
	*(uint16*)&b[2] = data->opcode;
	//printBytes((char*)b, 4, "ENCODE before");
	srp->encode((unsigned char*)b);
	_NIsend (b, 4);
	//printBytes((char*)b, 4, "ENCODE after");
	_NIsend (data->data, data->length);
}


void Socket::_NIsend (const void * data, int length)
{
	WPAssert (data != 0);
	int status, clength = 0,errorcount=0;
	while ((clength < length) && mConnected && errorcount<20)
	{
//		NAssert (status = send (handle, (char *)data + clength, length - clength, 0));
		status = send (handle, (char *)data + clength, length - clength, 0);
		if (!status) mConnected = false;
		else if (status != SOCKET_ERROR) clength += status;
		else errorcount++;
	}
	if(errorcount==20) mConnected = false;
}
