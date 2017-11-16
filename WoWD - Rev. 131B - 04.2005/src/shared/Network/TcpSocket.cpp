/**
 ** File ......... TcpSocket.cpp
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
#ifdef _WIN32
#pragma warning(disable:4786)
#define strcasecmp stricmp
#include <stdlib.h>
#endif
#include <stdio.h>
#include <fcntl.h>
#include <errno.h>
#include <assert.h>

#include "SocketHandler.h"
#include "TcpSocket.h"


#ifdef _DEBUG
#define DEB(x) x
#else
#define DEB(x)
#endif


TcpSocket::TcpSocket(SocketHandler& h) : Socket(h)
,ibuf(10240)
,obuf(32768)
,m_line("")
{
}


TcpSocket::TcpSocket(SocketHandler& h,size_t isize,size_t osize) : Socket(h)
,ibuf(isize)
,obuf(osize)
,m_line("")
{
}


TcpSocket::~TcpSocket()
{
}


bool TcpSocket::Open4(ipaddr_t ip,port_t port)
{
    SOCKET s = CreateSocket4(SOCK_STREAM, "tcp");
    if (s == INVALID_SOCKET)
    {
        return false;
    }
    ipaddr_t l = ip;
    {
        struct sockaddr_in sa;
        socklen_t sa_len = sizeof(sa);

        memset(&sa,0,sizeof(sa));
        sa.sin_family = AF_INET; // hp -> h_addrtype;
        sa.sin_port = htons( port );
        memcpy(&sa.sin_addr,&l,4);

        if (!SetNonblocking(true, s))
        {
            closesocket(s);
            return false;
        }
        int n = connect(s, (struct sockaddr *)&sa, sa_len);
        if (n == -1)
        {
#ifdef _WIN32
            int errcode;
            errcode = WSAGetLastError();
            if (errcode != WSAEWOULDBLOCK)
#else
            if (errno != EINPROGRESS)
#endif
            {
                Handler().LogError(this, "connect", errno, strerror(errno), LOG_LEVEL_FATAL);
                closesocket(s);
                return false;
            }
            else
            {
                SetConnecting( true ); // this flag will control fd_set's
            }
        }
        SetRemoteAddress( (struct sockaddr *)&sa,sa_len);
        Attach(s);
        return !Connecting();
    }
    return false;
}


bool TcpSocket::Open4(const std::string &host,port_t port)
{
    SOCKET s = CreateSocket4(SOCK_STREAM, "tcp");
    if (s == INVALID_SOCKET)
    {
        return false;
    }
    ipaddr_t l;
    if (u2ip(host,l))
    {
        struct sockaddr_in sa;
        socklen_t sa_len = sizeof(sa);

        memset(&sa,0,sizeof(sa));
        sa.sin_family = AF_INET;
        sa.sin_port = htons( port );
        memcpy(&sa.sin_addr,&l,4);

        if (!SetNonblocking(true, s))
        {
            closesocket(s);
            return false;
        }
        int n = connect(s, (struct sockaddr *)&sa, sa_len);
        if (n == -1)
        {
#ifdef _WIN32
            int errcode;
            errcode = WSAGetLastError();
            if (errcode != WSAEWOULDBLOCK)
#else
            if (errno != EINPROGRESS)
#endif
            {
                Handler().LogError(this, "connect", errno, strerror(errno), LOG_LEVEL_FATAL);
                closesocket(s);
                return false;
            }
            else
            {
                SetConnecting(true);
            }
        }
        SetRemoteAddress((struct sockaddr *)&sa,sa_len);
        Attach(s);
        return !Connecting();
    }
    return false;
}


#ifdef IPPROTO_IPV6
bool TcpSocket::Open6(const std::string &host,port_t port)
{
    SOCKET s = CreateSocket6(SOCK_STREAM, "tcp");
    if (s == INVALID_SOCKET)
    {
        return false;
    }
    struct in6_addr a;
    if (u2ip(host,a))
    {
        struct sockaddr_in6 sa;
        socklen_t sa_len = sizeof(sa);

        memset(&sa,0,sizeof(sa));
        sa.sin6_family = AF_INET6;
        sa.sin6_port = htons( port );
        sa.sin6_flowinfo = 0;
        sa.sin6_scope_id = 0;
        sa.sin6_addr = a;

        if (!SetNonblocking(true, s))
        {
            closesocket(s);
            return false;
        }
        int n = connect(s, (struct sockaddr *)&sa, sa_len);
        if (n == -1)
        {
#ifdef _WIN32
            int errcode;
            errcode = WSAGetLastError();
            if (errcode != WSAEWOULDBLOCK)
#else
            if (errno != EINPROGRESS)
#endif
            {
                Handler().LogError(this, "connect", errno, strerror(errno), LOG_LEVEL_FATAL);
                closesocket(s);
                return false;
            }
            else
            {
                SetConnecting(true);
            }
        }
        SetRemoteAddress((struct sockaddr *)&sa,sa_len);
        Attach(s);
        return !Connecting();
    }
    return false;
}
#endif


#define BUFSIZE_READ 16400
void TcpSocket::OnRead()
{
    int n = ibuf.Space();
    char buf[BUFSIZE_READ];
//  if (!n)
//      return; // bad
    n = BUFSIZE_READ; // %! patch away
    n = readsocket(GetSocket(),buf,(n < BUFSIZE_READ) ? n : BUFSIZE_READ);
    if (n == -1)
    {
        Handler().LogError(this, "read", errno, strerror(errno), LOG_LEVEL_FATAL);
        SetCloseAndDelete(true); // %!
    }
    else
    if (!n)
    {
        Handler().LogError(this, "read", 0, "read returns 0", LOG_LEVEL_FATAL);
        SetCloseAndDelete(true);
    }
    else
    {
        OnRawData(buf,n);
        if (!ibuf.Write(buf,n))
        {
            // overflow
            Handler().LogError(this, "read", 0, "ibuf overflow", LOG_LEVEL_WARNING);
        }
    }
}


void TcpSocket::OnWrite()
{
/*
    assert(GetSocket() != INVALID_SOCKET);
    if (obuf.GetL() <= 0)
    {
printf("OnWrite abort because: nothing to write\n");
        Set(true, false);
        return;
    }
    assert(obuf.GetL() > 0);
    if (!Handler().Valid(this))
    {
printf("OnWrite abort because: not valid\n");
        return;
    }
    if (!Ready())
    {
printf("OnWrite abort because: not ready\n");
        return;
    }
*/
    int n = writesocket(GetSocket(),obuf.GetStart(),obuf.GetL());
/*
When writing onto a connection-oriented socket that has been shut down (by the  local
or the remote end) SIGPIPE is sent to the writing process and EPIPE is returned.  The
signal is not sent when the write call specified the MSG_NOSIGNAL flag.
*/
    if (n == -1)
    {
#ifdef _WIN32
        int x = WSAGetLastError();
#endif
        Handler().LogError(this, "write", errno, strerror(errno), LOG_LEVEL_FATAL);
        SetCloseAndDelete(true); // %!
    }
    else
    if (!n)
    {
//      SetCloseAndDelete(true);
    }
    else
    {
        obuf.Remove(n);
    }
    // check m_mes
    while (obuf.Space() && m_mes.size())
    {
        ucharp_v::iterator it = m_mes.begin();
        MES *p = *it; //m_mes[0];
        if (obuf.Space() > p -> left())
        {
            obuf.Write(p -> curbuf(),p -> left());
            delete p;
//printf("\n m_mes erase()\n");
            m_mes.erase(m_mes.begin());
        }
        else
        {
            size_t sz = obuf.Space();
            obuf.Write(p -> curbuf(),sz);
            p -> ptr += sz;
        }
    }
    if (obuf.GetLength())
        Set(true, true);
    else
        Set(true, false);
}


void TcpSocket::Send(const std::string &str)
{
    SendBuf(str.c_str(),str.size());
}


void TcpSocket::SendBuf(const char *buf,size_t len)
{
    int n = obuf.GetLength();
    if (!Ready())
    {
        Handler().LogError(this, "SendBuf", -1, "Attempt to write to a non-ready socket" );
        return;
    }
//DEB(  printf("trying to send %d bytes;  buf before = %d bytes\n",len,n);)
    if (m_mes.size() || len > obuf.Space())
    {
        MES *p = new MES(buf,len);
        m_mes.push_back(p);
    }
    if (m_mes.size())
    {
        while (obuf.Space() && m_mes.size())
        {
            ucharp_v::iterator it = m_mes.begin();
            MES *p = *it; //m_mes[0];
            if (obuf.Space() > p -> left())
            {
                obuf.Write(p -> curbuf(),p -> left());
                delete p;
                m_mes.erase(m_mes.begin());
            }
            else
            {
                size_t sz = obuf.Space();
                obuf.Write(p -> curbuf(),sz);
                p -> ptr += sz;
            }
        }
    }
    else
    {
        if (!obuf.Write(buf,len))
        {
            Handler().LogError(this, "SendBuf", -1, "Send overflow" );
            // overflow
        }
    }
    if (!n)
    {
        OnWrite();
    }
}


void TcpSocket::OnLine(const std::string& )
{
}


#define BUFSIZE 16384

void TcpSocket::ReadLine()
{
    if (ibuf.GetLength())
    {
        size_t x = 0;
        size_t n = ibuf.GetLength();
        char tmp[BUFSIZE];

        n = (n >= BUFSIZE) ? BUFSIZE - 1 : n;
        ibuf.Read(tmp,n);
        tmp[n] = 0;

        for (size_t i = 0; i < n; i++)
        {
            while (tmp[i] == 13 || tmp[i] == 10)
            {
                char c = tmp[i];
                tmp[i] = 0;
                if (tmp[x])
                {
                    m_line += (tmp + x);
                }
                OnLine( m_line );
                i++;
                if (i < n && (tmp[i] == 13 || tmp[i] == 10) && tmp[i] != c)
                {
                    i++;
                }
                x = i;
                m_line = "";
            }
        }
        if (tmp[x])
        {
            m_line += (tmp + x);
        }
    }
}


