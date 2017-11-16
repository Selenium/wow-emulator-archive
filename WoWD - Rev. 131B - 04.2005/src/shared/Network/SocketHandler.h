/**
 **	File ......... SocketHandler.h
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
#ifndef _SOCKETHANDLER_H
#define _SOCKETHANDLER_H

//#include <vector>
#include <map>
#include <string>

#include "socket_include.h"
#include "StdLog.h"

class Socket;

class SocketHandler
{
	typedef std::map<int,Socket *> socket_m;

public:
	SocketHandler();
	virtual ~SocketHandler();

	/** Register StdLog object for error callback */
	void RegStdLog(StdLog *);
	void LogError(Socket *,const std::string&,int,const std::string&,loglevel_t = LOG_LEVEL_WARNING);

	void Add(Socket *);
	void Set(SOCKET s,bool bRead,bool bWrite,bool bException = true);
	int Select(long sec,long usec);
	void StatLoop(long s,long us);
	bool Valid(Socket *);
	virtual bool OkToAccept();

	/** ResolveLocal before calling any GetLocal method */
	void ResolveLocal();

	const std::string& GetLocalHostname();
	ipaddr_t GetLocalIP();
	const std::string& GetLocalAddress();
	const struct in6_addr& GetLocalIP6();
	const std::string& GetLocalAddress6();

	size_t GetCount();
	void SetSlave(bool x = true);

protected:
	socket_m m_sockets;
	socket_m m_add;

private:
	StdLog *m_stdlog;
	int m_maxsock;
	std::string m_host; // local
	ipaddr_t m_ip; // local
	std::string m_addr; // local
	fd_set m_rfds;
	fd_set m_wfds;
	fd_set m_efds;
	int m_preverror;
	bool m_slave;
#ifdef IPPROTO_IPV6
	struct in6_addr m_local_ip6;
#endif
	std::string m_local_addr6;
	bool m_local_resolved;
};




#endif // _SOCKETHANDLER_H
