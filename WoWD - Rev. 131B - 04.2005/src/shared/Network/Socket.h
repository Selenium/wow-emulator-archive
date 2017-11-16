/**
 ** File ......... Socket.h
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
#ifndef _SOCKETBASE_H
#define _SOCKETBASE_H

#include <string>
#include <time.h>
#include <vector>
#include "socket_include.h"


class SocketHandler;


#include <list>
    typedef std::list<std::string> string_v;

class Socket
{
    friend class SocketHandler;
public:
    Socket(SocketHandler&);
    virtual ~Socket();

    virtual void Init();

    void Attach(SOCKET s);
    SOCKET GetSocket();
    virtual int Close();
    SOCKET CreateSocket4(int type,const std::string& protocol = "");
    SOCKET CreateSocket6(int type,const std::string& protocol = "");
    void Set(bool bRead,bool bWrite,bool bException = true);
    bool Ready();

    virtual void OnRead();
    virtual void OnWrite();
    virtual void OnException();
    virtual void OnDelete();
    virtual void OnConnect();
    virtual void OnAccept();
    virtual void OnLine(const std::string& );
    virtual void OnSSLInitDone();
    virtual void OnConnectFailed();

    virtual bool CheckConnect();
    virtual void ReadLine();
    virtual bool SSLCheckConnect();

    void SetSSLConnecting(bool = true);
    bool SSLConnecting();
    void SetLineProtocol(bool = true);
    bool LineProtocol();
    void SetDeleteByHandler(bool = true);
    bool DeleteByHandler();
    void SetCloseAndDelete(bool = true);
    bool CloseAndDelete();
    void SetConnecting(bool = true);
    bool Connecting();
    time_t GetConnectTime();

    /** ipv4 and ipv6 */
    bool isip(const std::string&);
    /** ipv4 */
    bool u2ip(const std::string&, ipaddr_t&);
    /** ipv6 */
#ifdef IPPROTO_IPV6
    bool u2ip(const std::string&, struct in6_addr&);
#endif
    /** ipv4 */
    void l2ip(const ipaddr_t,std::string& );
    /** ipv6 */
#ifdef IPPROTO_IPV6
    void l2ip(const struct in6_addr&,std::string& ,bool mixed = false);
#endif

    /** ipv4 and ipv6 */
    void SetRemoteAddress(struct sockaddr* sa,socklen_t);
    /** ipv4 */
    ipaddr_t GetRemoteIP4();
    /** ipv6 */
#ifdef IPPROTO_IPV6
    struct in6_addr GetRemoteIP6();
#endif
    /** ipv4 and ipv6 */
    port_t GetRemotePort();
    /** ipv4 and ipv6 */
    std::string GetRemoteAddress();
    /** ipv4 and ipv6(not implemented) */
    std::string GetRemoteHostname();

    SocketHandler& Handler();
    bool SetNonblocking(bool);
    bool SetNonblocking(bool, SOCKET);

    time_t Uptime() { return time(NULL) - m_tCreate; }

/*
    void SetTimeout(time_t x) { m_timeout = x; }
    time_t Timeout() { return m_timeout; }
    void Touch() { m_tActive = time(NULL); }
    time_t Inactive() { return time(NULL) - m_tActive; }
*/
    void SetDetach(bool x = true) { m_detach = x; }
    bool IsDetach() { return m_detach; }
    bool Detach();

    void SetIpv6(bool x = true) { m_ipv6 = x; }
    bool IsIpv6() { return m_ipv6; }

protected:
    void DetachSocket(); // protected, friend class SocketHandler;

private:
    SocketHandler& m_handler;
    SOCKET m_socket;
    bool m_bDel;
    bool m_bClose;
    bool m_bConnecting;
    time_t m_tConnect;
    time_t m_tCreate;
    bool m_line_protocol;
    bool m_ssl_connecting;
    bool m_detach;
    bool m_ipv6;
    struct sockaddr m_sa; // remote, from accept
    socklen_t m_sa_len;
};


#endif // _SOCKETBASE_H
