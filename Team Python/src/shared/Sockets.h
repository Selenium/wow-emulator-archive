// Copyright (C) 2004 Team Python
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

#ifndef WOWPYTHONSERVER_SOCKETS_H
#define WOWPYTHONSERVER_SOCKETS_H

#include "Common.h"

#if PLATFORM == PLATFORM_WIN32
#  include <Winsock2.h>
#else
#  include <sys/types.h>
#  include <sys/ioctl.h>
#  include <sys/socket.h>
#  include <netinet/in.h>
#  include <arpa/inet.h>
#  include <unistd.h>
#  include <signal.h>
#  include <netdb.h>
#endif

#if PLATFORM == PLATFORM_WIN32
#  define SOCKLEN_T int
#  define SOCK_LASTERR WSAGetLastError( )
#  define SOCKERR( a ) WSAE##a
#  define IOCTL_SOCKET ioctlsocket
#  define IOCTL_NOBLOCK FIONBIO
#else
#  define SOCKLEN_T socklen_t
#  define SOCK_LASTERR errno
#  define SOCKERR( a) E##a
#  define IOCTL_SOCKET ioctl
#  define IOCTL_NOBLOCK FIONBIO

#  define closesocket( a ) close( a )
#  define SOCKET_ERROR -1
#  define SOCKADDR_IN sockaddr_in
#endif

#if !defined( SOMAXCONN ) || SOMAXCONN < 10
#  define SOMAXCONN 10
#endif

#include "Log.h"

#define NAssert( assertion ) \
  if( (assertion) == SOCKET_ERROR ) \
    if( SOCK_LASTERR != SOCKERR(WOULDBLOCK) ) { \
      mConnected = false; \
      Log::getSingleton( ).outString( "Socket error!" ); \
      Log::getSingleton( ).outString( Network::getSingleton( ).getErrorName( SOCK_LASTERR ) ); \
      return; \
    } \

#define NAssertRP( assertion ) \
  if( (assertion) == SOCKET_ERROR ) \
    if( SOCK_LASTERR != SOCKERR(WOULDBLOCK) ) { \
      mConnected = false; \
      Log::getSingleton( ).outString( "Socket error!" ); \
      Log::getSingleton( ).outString( Network::getSingleton( ).getErrorName( SOCK_LASTERR ) ); \
      return NULL; \
    } \

#endif

