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

#ifndef __SOCKETS_H__
#define __SOCKETS_H__

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
#  define socket_t SOCKET
#  define socklen_t int
#  define SOCKERR(a) WSAE##a
#  define so_errno WSAGetLastError()
#  define so_ioctl ioctlsocket
#  define so_close closesocket
#else
#  define socket_t int
#  define so_errno errno
#  define SOCKERR(a) E##a
#  define SOCKET_ERROR -1
#  define INVALID_SOCKET (socket_t (-1)) 
#  define so_ioctl ioctl
#  define so_close close
#endif

#if !defined (SOMAXCONN) || (SOMAXCONN < 10)
#  undef SOMAXCONN
#  define SOMAXCONN 10
#endif

#include "Log.h"

#define NAssert(assertion) \
  if ((assertion) == SOCKET_ERROR) \
    if (so_errno != SOCKERR(WOULDBLOCK)) { \
      mConnected = false; \
      LOG.outString ("Socket error!"); \
      LOG.outString (NETWORK.getErrorName (so_errno)); \
      return; \
    } \

#define NAssertRP( assertion ) \
  if ((assertion) == SOCKET_ERROR) \
    if (so_errno != SOCKERR (WOULDBLOCK)) { \
      mConnected = false; \
      LOG.outString ("Socket error!"); \
      LOG.outString (NETWORK.getErrorName (so_errno)); \
      return NULL; \
    } \

#endif // __SOCKETS_H__
