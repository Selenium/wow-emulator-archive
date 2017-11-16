/**
 **	File ......... TcpSocket.h
 **	Published ....  2004-02-13
 **	Author ....... grymse@alhem.net
**/
/*
Copyright (C) 2004  Anders Hedstrom

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
*/
#ifndef _TCPSOCKET_H
#define _TCPSOCKET_H

#include "Socket.h"
#include "CircularBuffer.h"


class TcpSocket : public Socket
{
	struct MES {
		MES( const char *buf_in,size_t len_in)
		:buf(new  char[len_in])
		,len(len_in)
		,ptr(0)
		{
			memcpy(buf,buf_in,len);
		}
		~MES() { delete[] buf; }
		size_t left() { return len - ptr; }
		 char *curbuf() { return buf + ptr; }
		 char *buf;
		size_t len;
		size_t ptr;
	};
	typedef std::list<MES *> ucharp_v;

public:
	TcpSocket(SocketHandler& );
	TcpSocket(SocketHandler& ,size_t isize,size_t osize);
	~TcpSocket();

	bool Open4(ipaddr_t,port_t);
	bool Open4(const std::string &host,port_t port);
	bool Open6(const std::string& host,port_t port);

	void Send(const std::string &);

	virtual void SendBuf(const char *,size_t);
	virtual void OnRawData(const char *,size_t) {}

	int GetInputLength() { return ibuf.GetLength(); }
	int GetOutputLength() { return obuf.GetLength(); }

	void ReadLine();
	virtual void OnLine(const std::string& );

	unsigned long GetBytesReceived() { return ibuf.ByteCounter(); }
	unsigned long GetBytesSent() { return obuf.ByteCounter(); }

protected:
	void OnRead();
	void OnWrite();
	//
	CircularBuffer ibuf;
	CircularBuffer obuf;
	std::string m_line;
	ucharp_v m_mes; // overflow protection
};


#endif // _TCPSOCKET_H
