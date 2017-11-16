// Copyright (C) 2004 WoW Daemon
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

#ifndef WOWSERVER_COMMON_H
#define WOWSERVER_COMMON_H

#pragma warning(disable:4996)

// Only clients with this version will be allowed to view the realmlist.
// Higher versions will be rejected, lower versions will be patched if possible.

#define EXPECTED_WOW_CLIENT_BUILD {4937,4983,4996,5059,5086}
#define DYNAMIC_LOADING
#define DYNAMIC_UNLOAD_TIME 60
#ifdef HAVE_CONFIG_H
# include <config.h>
#endif

#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <math.h>
#include <errno.h>

// current platform and compiler
#define PLATFORM_WIN32 0
#define PLATFORM_UNIX  1
#define PLATFORM_APPLE 2

#if defined( __WIN32__ ) || defined( WIN32 ) || defined( _WIN32 )
#  define PLATFORM PLATFORM_WIN32
#elif defined( __APPLE_CC__ )
#  define PLATFORM PLATFORM_APPLE
#else
#  define PLATFORM PLATFORM_UNIX
#endif

#define COMPILER_MICROSOFT 0
#define COMPILER_GNU       1
#define COMPILER_BORLAND   2

#ifdef _MSC_VER
#  define COMPILER COMPILER_MICROSOFT
#elif defined( __BORLANDC__ )
#  define COMPILER COMPILER_BORLAND
#elif defined( __GNUC__ )
#  define COMPILER COMPILER_GNU
#else
#  pragma error "FATAL ERROR: Unknown compiler."
#endif

#if COMPILER == COMPILER_MICROSOFT
#  pragma warning( disable : 4267 ) // conversion from 'size_t' to 'int', possible loss of data
#  pragma warning( disable : 4786 ) // identifier was truncated to '255' characters in the debug information
#endif

#if PLATFORM == PLATFORM_WIN32
#define STRCASECMP stricmp
#else
#define STRCASECMP strcasecmp
#endif

#include <set>
#include <list>
#include <string>
#include <map>
#include <queue>
#include <sstream>
#include <algorithm>
//#include <iostream>
#if COMPILER == COMPILER_GNU && __GNUC__ >= 3
#include <ext/hash_map>
#define __fastcall __attribute__((__fastcall__))
#else
#include <hash_map>
#endif

#include <zthread/FastMutex.h>
#include <zthread/LockedQueue.h>
#include <zthread/Runnable.h>
#include <zthread/Thread.h>

#if PLATFORM == PLATFORM_WIN32
#  include <winsock2.h>
#  include <ws2tcpip.h>
#else
#  include <sys/types.h>
#  include <sys/ioctl.h>
#  include <sys/socket.h>
#  include <netinet/in.h>
#  include <unistd.h>
#  include <signal.h>
#  include <netdb.h>
#endif

#ifdef _STLPORT_VERSION
#define HM_NAMESPACE std
#elif COMPILER == COMPILER_MICROSOFT && _MSC_VER >= 1300 // msvc71
#define HM_NAMESPACE stdext
#elif COMPILER == COMPILER_GNU && __GNUC__ >= 3
#define HM_NAMESPACE __gnu_cxx

namespace __gnu_cxx {
    template<> struct hash<unsigned long long> {
        size_t operator()(const unsigned long long &__x) const { return (size_t)__x; }
    };
    template<typename T> struct hash<T *> {
        size_t operator()(T * const &__x) const { return (size_t)__x; }
    };

};

#else
#define HM_NAMESPACE std
#endif

#include "MemoryLeaks.h"

#if COMPILER == COMPILER_MICROSOFT
  typedef __int64   int64;
#else
  typedef long long int64;
#endif
typedef long        int32;
typedef short       int16;
typedef char        int8;

#if COMPILER == COMPILER_MICROSOFT
  typedef unsigned __int64   uint64;
#else
  typedef unsigned long long  uint64;
  typedef unsigned long      DWORD;
#endif
typedef unsigned long        uint32;
typedef unsigned short       uint16;
typedef unsigned char        uint8;

#if COMPILER == COMPILER_MICROSOFT

#define I64FMT "%016I64X"
#define I64FMTD "%I64u"
#define SI64FMTD "%I64d"
#define snprintf _snprintf
#define atoll __atoi64

#else

#define stricmp strcasecmp
#define strnicmp strncasecmp
#define I64FMT "%016llX"
#define I64FMTD "%llu"
#define SI64FMTD "%lld"

#endif

#define GUID_HIPART(x) (*(((uint32*)&(x))+1))
#define GUID_LOPART(x) (*((uint32*)&(x)))

#define atol(a) strtoul( a, NULL, 10)

#define STRINGIZE(a) #a

// fix buggy MSVC's for variable scoping to be reliable =S
#define for if(true) for

#ifdef GNL_BIG_ENDIAN
#  define GNL_LOWER_WORD_BYTE    4
#else
#  define GNL_LOWER_WORD_BYTE    0
#endif

#define GNL_LONG_AT_BYTE(x,b)    *(long *)(((char *)&x) + b)
#define FIST_MAGIC_QROUND (((65536.0 * 65536.0 * 16.0) + (65536.0 * 0.5)) * 65536.0)


/// Round a floating-point value and convert to integer
static inline long QRound (double inval)
{
    double dtemp = FIST_MAGIC_QROUND + inval;
    return GNL_LONG_AT_BYTE (dtemp, GNL_LOWER_WORD_BYTE) - 0x80000000;
}

/// Convert a float to a cross-platform 32-bit format (no endianess adjustments!)
static inline long float2long (float f)
{
  int exp;
  long mant = QRound (frexp (f, &exp) * 0x1000000);
  long sign = mant & 0x80000000;
  if (mant < 0) mant = -mant;
  if (exp > 63) exp = 63; else if (exp < -64) exp = -64;
  return sign | ((exp & 0x7f) << 24) | (mant & 0xffffff);
}

/// Convert a 32-bit cross-platform float to native format (no endianess adjustments!)
static inline float long2float (long l)
{
  int exp = (l >> 24) & 0x7f;
  if (exp & 0x40) exp = exp | ~0x7f;
  float mant = float (l & 0x00ffffff) / 0x1000000;
  if (l & 0x80000000) mant = -mant;
  return (float) ldexp (mant, exp);
}

#endif

