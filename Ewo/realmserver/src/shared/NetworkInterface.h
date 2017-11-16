/*
   Copyright (C) 2004 Team Python
   Copyright (C) 2005 Team OpenWoW
   Copyright (C) 2006 Team Evolution

   This program is free software; you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation; either version 2 of the License, or
   (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program; if not, write to the Free Software
   Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.
*/

#ifndef __NETWORKINTERFACE_H__
#define __NETWORKINTERFACE_H__

#include "Sockets.h"

/**
 * This class is used to encapsulate socket objects
 */
class Socket
{
public:
   /// Handle of the socket encapsulated in this object
   socket_t handle;

   /// Receiver queue
   uint8 *recvq;
        /// Sender queue
   uint8 *sendq;

   /// RecvQ and SendQ sizes
   int recvqlen;
   int sendqlen;

   /// RecvQ and SendQ max size
   int recvqmax;
   int sendqmax;

   /// Network address of the socket
   sockaddr_in inaddr;

   /// Internal function to send raw data
   int _NIsend (const void *data, int length);
   void _NIWsend (unsigned char * data, int length);
   /// Internal function to recieve raw data
   void _NIrecv (void *data, int length);

   /// Number of extra threads using this socket
   int amountUsed;

   /// Is this socket still connected?
   bool mConnected;

   /// Is this socket about to removed?
   bool pleasekillme;

   /// Callback function on connect
   void (* mCallback) (Socket *);

   /// Current error code
   uint32 Ncerr;

   /// How many threads are waiting to recieve or send a packet?
   uint32 mRecvWaiting, mSendWaiting;

   /// How many threads are currently sending or recieving a packet? (should never be over 1!)
   uint32 mRecieving, mSending;

   /// Private constructor & destructor, only createable via Network
   Socket (socket_t sh, sockaddr_in *sa);
   ~Socket ();

   friend class Network;

public:
   const uint8 * fillRecvQ ();
   void sendData (int length, const void * data);
   void getData (int length, void *data);
   inline int getSendqLen() { return sendqlen; }
   inline int getRecvqLen() { return recvqlen; }
   void * customData;
   /// Accept an incoming connection request if one exists
   Socket *AcceptConnection ();
   /// Is this socket still connected?
   bool isConnected () const;
   socket_t GetHandle () { return handle; }
//   inline uint8 * getSendq () { return sendq; }
//   inline uint8 * getRecvq () { return recvq; }
   inline void ClearSendq (){sendqlen = 0;}
   inline void ClearRecvq (){recvqlen = 0;}
   void updateSendq (uint32 written);
   uint32 sendPendingSendq ();
   inline char * getIP ()
   { return inet_ntoa (inaddr.sin_addr); }

   uint32 parse_next_pos;
   inline void reset_read(){parse_next_pos=0;}
   inline uint8 get_next_8b(){ return recvq[parse_next_pos++];}
   inline uint32 get_next_16b()
   { 
	   uint32 ret=recvq[parse_next_pos]+ (recvq[parse_next_pos+1]<<8);
	   parse_next_pos += 2;
	   return ret;
   }
   inline uint32 get_next_24b()
   { 
	   uint32 ret=recvq[parse_next_pos] + (recvq[parse_next_pos+1]<<8) + (recvq[parse_next_pos+2]<<16);
	   parse_next_pos += 3;
	   return ret;
   }
   inline uint32 get_next_32b()
   { 
	   uint32 ret=*((uint32*)(&recvq[parse_next_pos]));
	   parse_next_pos += 4;
	   return ret;
   }
   inline void get_next_str(char *buffer)
   {
	   recvq[recvqlen]=0;//just to make sure no error ocures
	   strcpy(buffer,(char*)&recvq[parse_next_pos]);
	   parse_next_pos += strlen((char*)&recvq[parse_next_pos])+1;
   }
   inline uint8* get_next_struct_addr(){return &recvq[recvqlen];}
   inline void request_disconnect() {mConnected = false;}
};

#endif // __NETWORKINTERFACE_H__
