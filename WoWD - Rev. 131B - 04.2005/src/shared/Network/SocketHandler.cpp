/**
 ** File ......... SocketHandler.cpp
 ** Published ....  2004-02-13
 ** Author ....... grymse@alhem.net
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
//#include <stdio.h>
#ifdef _WIN32
#pragma warning(disable:4786)
#include <stdlib.h>
#else
#include <errno.h>
#endif

#include "TcpSocket.h"
#include "StdLog.h"
#include "SocketHandler.h"
#include "UdpSocket.h"

#ifdef _DEBUG
#define DEB(x) x
#else
#define DEB(x)
#endif


SocketHandler::SocketHandler()
:m_stdlog(NULL)
,m_maxsock(0)
,m_host("")
,m_ip(0)
,m_preverror(-1)
,m_slave(false)
,m_local_resolved(false)
{
    FD_ZERO(&m_rfds);
    FD_ZERO(&m_wfds);
    FD_ZERO(&m_efds);
}


SocketHandler::~SocketHandler()
{
    if (!m_slave)
    {
        for (socket_m::iterator it = m_sockets.begin(); it != m_sockets.end(); it++)
        {
            Socket *p = (*it).second;
            p -> Close();
            p -> OnDelete(); // hey, I turn this back on. what's the worst that could happen??!!
            if (p -> DeleteByHandler())
            {
                delete p;
            }
        }
    }
}


void SocketHandler::ResolveLocal()
{
    char h[256];

    // get local hostname and translate into ip-address
    *h = 0;
    gethostname(h,255);
    {
        Socket zl(*this);
        if (zl.u2ip(h, m_ip))
        {
            zl.l2ip(m_ip, m_addr);
        }
    }
#ifdef IPPROTO_IPV6
    memset(&m_local_ip6, 0, sizeof(m_local_ip6));
    {
        Socket zl(*this);
        zl.SetIpv6();
        if (zl.u2ip(h, m_local_ip6))
        {
            zl.l2ip(m_local_ip6, m_local_addr6);
        }
    }
#endif
    m_host = h;
    m_local_resolved = true;
}


void SocketHandler::Add(Socket *p)
{
    if (p -> GetSocket() == INVALID_SOCKET)
    {
        LogError(p, "Add", -1, "Invalid socket", LOG_LEVEL_FATAL);
        return;
    }
DEB(    printf("%s: add socket %d\n",m_slave ? "slave" : "master",p -> GetSocket());)
    m_add[p -> GetSocket()] = p;
    if (p -> Connecting())
        Set(p -> GetSocket(),false,true);
    else
        Set(p -> GetSocket(),true,false);
    m_maxsock = (p -> GetSocket() > (SOCKET)m_maxsock) ? p -> GetSocket() : m_maxsock;
}


void SocketHandler::Set(SOCKET s,bool bRead,bool bWrite,bool bException)
{
    if (s >= 0)
    {
        if (bRead)
        {
            if (!FD_ISSET(s, &m_rfds))
                FD_SET(s, &m_rfds);
        }
        else
            FD_CLR(s, &m_rfds);
        if (bWrite)
        {
            if (!FD_ISSET(s, &m_wfds))
                FD_SET(s, &m_wfds);
        }
        else
            FD_CLR(s, &m_wfds);
        if (bException)
        {
            if (!FD_ISSET(s, &m_efds))
                FD_SET(s, &m_efds);
        }
        else
            FD_CLR(s, &m_efds);
    }
}


int SocketHandler::Select(long sec,long usec)
{
    struct timeval tv;
    fd_set rfds = m_rfds;
    fd_set wfds = m_wfds;
    fd_set efds = m_efds;
    int n;
//DEB(  printf("tick\n");)

    while (!m_add.empty())
    {
        socket_m::iterator it = m_add.begin();
        SOCKET s = (*it).first;
        Socket *p = (*it).second;
        m_sockets[s] = p;
        m_add.erase(it);
    }

    tv.tv_sec = sec;
    tv.tv_usec = usec;
    n = select(m_maxsock + 1,&rfds,&wfds,&efds,&tv);
    if (n == -1)
    {
        LogError(NULL, "select", errno, strerror(errno));
#ifdef _WIN32
DEB(
        int errcode = WSAGetLastError();
        if (errcode != m_preverror)
        {
            printf("  select() errcode = %d\n",errcode);
            m_preverror = errcode;
            for (int i = 0; i <= m_maxsock; i++)
            {
                if (FD_ISSET(i, &m_rfds))
                    printf("%4d: Read\n",i);
                if (FD_ISSET(i, &m_wfds))
                    printf("%4d: Write\n",i);
                if (FD_ISSET(i, &m_efds))
                    printf("%4d: Exception\n",i);
            }
        }
) // DEB
#else
DEB(
        printf("slave: %s\n",m_slave ? "YES" : "NO");
        exit(-1);
)
#endif
    }
    else
//  if (n > 0)
    {
        for (socket_m::iterator it2 = m_sockets.begin(); it2 != m_sockets.end(); it2++)
        {
            SOCKET i = (*it2).first;
            Socket *p = (*it2).second;
            if (p)
            {
                if (p -> SSLConnecting())
                {
                    if (p -> SSLCheckConnect())
                    {
                        p -> OnSSLInitDone();
                    }
                }
                else if (n > 0)
                {
                    if (FD_ISSET(i, &rfds))
                    {
                        p -> OnRead();
                        if (p -> LineProtocol())
                        {
                            p -> ReadLine();
                        }
//                      p -> Touch();
                    }
                    if (FD_ISSET(i, &wfds))
                    {
                        if (p -> Connecting())
                        {
                            if (p -> CheckConnect())
                            {
DEB(                                printf("calling OnConnect\n");)
                                p -> OnConnect();
                            }
//                          p -> Touch();
                        }
                        else
                        {
                            p -> OnWrite();
//                          p -> Touch();
                        }
                    }
                    if (FD_ISSET(i, &efds))
                    {
                        p -> OnException();
                    }
                }
            } // if (p)
        } // for
    }

    for (socket_m::iterator next, it3 = m_sockets.begin(); it3 != m_sockets.end(); it3 = next)
    {
        next = it3;
        next++;

//      SOCKET s = (*it3).first;
        Socket *p = (*it3).second;
        if (p)
        {
            if (!m_slave && p -> IsDetach())
            {
                Set(p -> GetSocket(), false, false, false);
                p -> DetachSocket();
                m_sockets.erase(it3);
                continue;
            }
/*
            if (p && p -> Timeout() && p -> Inactive() > p -> Timeout())
            {
                p -> SetCloseAndDelete();
            }
*/
            if (p && p -> Connecting() && p -> GetConnectTime() > 5)
            {
                LogError(p, "connect", -1, "connect timeout", LOG_LEVEL_FATAL);
                p -> SetCloseAndDelete(true);
            }
            if (p && p -> CloseAndDelete() )
            {
//DEB(printf("%s: calling Close for socket %d\n",m_slave ? "slave" : "master",s);)
                Set(p -> GetSocket(), false, false, false);
                p -> Close();
                p -> OnDelete();
                if (p -> DeleteByHandler())
                {
                    delete p;
                }
                m_sockets.erase(it3);
                continue;
            }
        } // if (p)
    }

    m_maxsock = 0;
    for (socket_m::iterator it3 = m_sockets.begin(); it3 != m_sockets.end(); it3++)
    {
        SOCKET s = (*it3).first;
        m_maxsock = s > (SOCKET)m_maxsock ? s : m_maxsock;
    }
    for (socket_m::iterator it3 = m_add.begin(); it3 != m_add.end(); it3++)
    {
        SOCKET s = (*it3).first;
        m_maxsock = s > m_maxsock ? s : m_maxsock;
    }

    return n;
}


const std::string& SocketHandler::GetLocalHostname()
{
    if (!m_local_resolved)
        LogError(NULL, "GetLocalHostname", 0, "local address not resolved");
    return m_host;
}


ipaddr_t SocketHandler::GetLocalIP()
{
    if (!m_local_resolved)
        LogError(NULL, "GetLocalHostname", 0, "local address not resolved");
    return m_ip;
}


const std::string& SocketHandler::GetLocalAddress()
{
    if (!m_local_resolved)
        LogError(NULL, "GetLocalHostname", 0, "local address not resolved");
    return m_addr;
}


void SocketHandler::StatLoop(long sec,long usec)
{
    time_t t = time(NULL);
    int count = 0;
    for (;;)
    {
        if (Select(sec, usec) > 0)
            count++;
        time_t x = time(NULL);
        if (t != x)
        {
            if (count)
                printf("ticks: %d\n", count);
            t = x;
            count = 0;
        }
    }
}


bool SocketHandler::Valid(Socket *p0)
{
    for (socket_m::iterator it3 = m_sockets.begin(); it3 != m_sockets.end(); it3++)
    {
        Socket *p = (*it3).second;
        if (p0 == p)
            return true;
    }
    return false;
}


void SocketHandler::RegStdLog(StdLog *x)
{
    m_stdlog = x;
}


bool SocketHandler::OkToAccept()
{
    return true;
}


size_t SocketHandler::GetCount()
{
    return m_sockets.size();
}


void SocketHandler::SetSlave(bool x)
{
    m_slave = x;
}


void SocketHandler::LogError(Socket *p,const std::string& user_text,int err,const std::string& sys_err,loglevel_t t)
{
    if (m_stdlog)
    {
        m_stdlog -> error(this, p, user_text, err, sys_err, t);
    }
}


#ifdef IPPROTO_IPV6
const struct in6_addr& SocketHandler::GetLocalIP6()
{
    if (!m_local_resolved)
        LogError(NULL, "GetLocalHostname", 0, "local address not resolved");
    return m_local_ip6;
}
#endif


const std::string& SocketHandler::GetLocalAddress6()
{
    if (!m_local_resolved)
        LogError(NULL, "GetLocalHostname", 0, "local address not resolved");
    return m_local_addr6;
}


