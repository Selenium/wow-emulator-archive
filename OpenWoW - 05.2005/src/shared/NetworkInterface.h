/*
   Copyright (C) 2004 Team Python
   Copyright (C) 2005 Team OpenWoW

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

#include "Base.h"
#include "Sockets.h"
#include "SrpWorld.h"

//class
struct NetworkPacket
{
public:
	uint opcode;
	uint8 *data;
	uint length, top;

	/// Constructor
	NetworkPacket () : opcode (0), data (0), length (0), top (0)
	{ }

	/// Destructor
	~NetworkPacket ()
	{ Clear (); }

	/// Clear packet and set length and opcode all in one mighty blow
	void Initialize (uint newLength, uint newOpcode)
	{
		SetLength (newLength);
		opcode = newOpcode;
	}

	void SetLength (uint newlength)
	{
		if ((newlength > length) | (data==0))
		{
			Clear ();
			data = new uint8 [newlength];
		}
		else
		{
			top = 0; opcode = 0;
		}
		length = newlength;
	}

	void Clear ()
	{
		if (data)
			delete [] data;
		data = 0;
		length = top = 0;
		opcode = 0;
	}

	inline uint8 * GetTop () const
	{ return data + top; }

	template < class type > inline NetworkPacket & operator<< (const type &newData)
	{
		WriteData (newData);
		return *this;
	}
	template < class type > inline NetworkPacket & operator>> (type &newData)
	{
		ReadData (newData);
		return *this;
	}

	inline NetworkPacket & operator<< (const char * newData)
	{
		WriteData (newData);
		return *this;
	}
	inline NetworkPacket & operator>> (char * newData)
	{
		ReadData (newData);
		return *this;
	}

	inline uint & WriteData (const void * newData, const uint datalength)
	{
		return top = WriteDataAt (top, newData, datalength);
	}
	inline uint & ReadData (void * newData, const uint datalength)
	{
		return top = ReadDataAt (top, newData, datalength);
	}

	template < class type > inline uint & WriteData (const type &newData)
	{
		return top = WriteDataAt (top, newData);
	}
	template < class type > inline uint & ReadData (type &newData)
	{
		return top = ReadDataAt (top, newData);
	}

	inline uint & WriteData (const char * newData)
	{
		return top = WriteDataAt (top, newData);
	}
	inline uint & ReadData (char * newData)
	{
		return top = ReadDataAt (top, newData);
	}

	inline uint WriteDataAt (const uint offset, const char * newData)
	{
		uint dlen = static_cast<uint>(strlen (newData) + 1); // + 1 i.e. also write the trailing 0x00
		WPAssert (offset + dlen <= length);
		memcpy (data + offset, newData, dlen);
		return offset + dlen;
	}
	inline uint ReadDataAt (const uint offset, char * newData)
	{
		// this method shouldn't really be used, too much danger of buffer overflow
		uint dlen = static_cast<uint>(strlen ((char *)data + offset) + 1);
		WPAssert (offset + dlen <= length);
		memcpy (newData, data + offset, dlen);
		return offset + dlen;
	}

	template < class type > inline uint WriteDataAt (const uint offset, const type &newData)
	{
		WPAssert (offset + sizeof (type) <= length);
		memcpy (data + offset, &newData, sizeof (type));
		return offset + sizeof (type);
	}
	template < class type > inline uint ReadDataAt (const uint offset, type &newData) const
	{
		// if you die at this assert whilst reading a char array you may have forgotten to typecast it to a (char *); however, note that std::string's are much safer than char arrays.
		WPAssert (offset + sizeof (type) <= length);
		memcpy (&newData, data + offset, sizeof (type));
		return offset + sizeof (type);
	}

	inline uint WriteDataAt (const uint offset, const std::string &newData)
	{
		uint dlen = static_cast<uint>(newData.length () + 1); // trailing zero is included
		WPAssert (offset + dlen <= length);
		memcpy (data + offset, newData.c_str (), dlen);
		return offset + dlen;
	}
	inline uint ReadDataAt (const uint offset, std::string &newData)
	{
		newData = (char *) data + offset;
		uint dlen = static_cast<uint>(newData.length () + 1);
		WPAssert (offset + dlen <= length);
		return offset + dlen;
	}

	inline uint WriteDataAt (const uint offset, const void * newData, const uint datalength)
	{
		WPAssert (offset + datalength <= length);
		memcpy (data + offset, newData, datalength);
		return offset + datalength;
	}
	inline uint ReadDataAt (const uint offset, void * newData, const uint datalength) const
	{
		WPAssert (offset + datalength <= length);
		memcpy (newData, data + offset, datalength);
		return offset + datalength;
	}
};

/**
 * This class is used to encapsulate socket objects
 */
class Socket
{
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
	void _NIsend (const void *data, int length);
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
	void sendWData (NetworkPacket *data, SrpWorld* srp);
	void sendData (int length, const void * data);
	void getData (int length, void *data);

	int getSendqLen() { return sendqlen; }
	int getRecvqLen() { return recvqlen; }
	void * customData;

	/// Accept an incoming connection request if one exists
	Socket *AcceptConnection ();

	/// Is this socket still connected?
	bool isConnected () const;
	socket_t GetHandle () { return handle; }

	uint8 * getSendq () { return sendq; }
	uint8 * getRecvq () { return recvq; }

	void ClearSendq ()
	{
		sendqlen = 0;
		sendq[0] = 0;
	}
	void ClearRecvq ()
	{
		recvqlen = 0;
		recvq[0] = 0;
	}

	void updateSendq (uint32 written);
	uint32 sendPendingSendq ();
	inline char * getIP ()
	{ return inet_ntoa (inaddr.sin_addr); }
};

#endif // __NETWORKINTERFACE_H__
