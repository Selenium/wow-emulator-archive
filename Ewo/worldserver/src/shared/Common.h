// Copyright (C) 2004 Team Python
// Copyright (C) 2006 Team Evolution
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

#ifndef __COMMON_H__
#define __COMMON_H__

// Only clients with this version will be allowed to view the realmlist.
// Higher versions will be rejected, lower versions will be patched if possible.

#ifdef HAVE_CONFIG_H
# include <config.h>
#endif

#include <stdio.h>
#include <stdlib.h>

#include <set>
#include <list>
#include <string>
#include <map>
#include <sstream>
#include <algorithm>

// current platform and compiler
#define PLATFORM_WIN32 0
#define PLATFORM_UNIX  1
#define PLATFORM_APPLE 2

#if defined( __WIN32__ ) || defined( WIN32 ) || defined( _WIN32 )
#  define PLATFORM		PLATFORM_WIN32
#  define __i386__
#  pragma warning(disable : 4996) // added to stop warnings
#elif defined( __APPLE_CC__ )
#  define PLATFORM		PLATFORM_APPLE
#else
#  define PLATFORM		PLATFORM_UNIX
#endif

#define COMPILER_MICROSOFT	0
#define COMPILER_GNU		1
#define COMPILER_BORLAND	2

#if defined (_MSC_VER)
#  define COMPILER		COMPILER_MICROSOFT
#elif defined (__BORLANDC__)
#  define COMPILER		COMPILER_BORLAND
#elif defined (__GNUC__)
#  define COMPILER		COMPILER_GNU
#else
#  error "FATAL ERROR: Unknown compiler."
#endif

#ifndef LITTLE_ENDIAN
#  define LITTLE_ENDIAN	1234
#endif
#ifndef BIG_ENDIAN
#  define BIG_ENDIAN	3412
#endif

#if defined (__i386__)
#  define CPU_x86
#  ifndef BYTE_ORDER
#    define BYTE_ORDER	LITTLE_ENDIAN
#  endif
#else
#  error "Unknown CPU type"
#endif

#include "MemoryLeaks.h"

/*
+-------------------------------------+
|             Base type sizes         |
+--------------------+-------+--------+
|        Arch        |  x86  | x86_64 |
+--------------------+-------+--------+
| sizeof (char)      |   1   |    1   |
| sizeof (short)     |   2   |    2   |
| sizeof (int)       |   4   |    4   |
| sizeof (long)      |   4   |    8   |
| sizeof (long long) |   8   |    8   |
| sizeof (float)     |   4   |    4   |
| sizeof (double)    |   8   |    8   |
+--------------------+-------+--------+
*/

// VS.NET 2003 has long long, but eralier versions don't
#if COMPILER == COMPILER_MICROSOFT && _MSC_VER < 1300
  typedef __int64 int64;
  typedef unsigned __int64 uint64;
#else
  typedef long long int64;
  typedef unsigned long long uint64;
#endif
typedef int int32;
typedef unsigned int uint32;
typedef short int16;
typedef unsigned short uint16;
typedef char int8;
typedef unsigned char uint8;

// This is an integer type that has the same size as pointers
typedef unsigned long uintptr;

// Short for unsigned long
typedef unsigned long ulong;
// Short for 'unsigned int'
typedef unsigned int uint;
// Short for 'unsigned short'
typedef unsigned short ushort;
// Short for 'unsigned char'
typedef unsigned char uchar;

#if defined (__GNUC__) && defined (CPU_x86)
// Optimized routines for x86
static inline const uint16 swap16 (const uint16 x)
{
  uint16 ret;
  __asm ("xchgb %%al,%%ah" : "=a" (ret) : "a" (x));
  return ret;
}
static inline const uint32 swap32 (const uint32 x)
{
  uint32 ret;
  __asm ("bswapl %%eax" : "=a" (ret) : "a" (x));
  return ret;
}
static inline const uint64 swap64 (const uint64 x)
{
  uint64 ret;
  __asm ("bswapl %%eax\nbswapl %%edx\nxchgl %%eax,%%edx" : "=A" (ret) : "A" (x));
  return ret;
}
#else
static inline const uint16 swap16 (const uint16 x)
{ return (x >> 8) | (x << 8); }
static inline const uint32 swap32 (const uint32 x)
{ return (x >> 24) | ((x >> 8) & 0xff00) | ((x << 8) & 0xff0000) | (x << 24); }
static inline const uint64 swap64 (const uint64 x)
{ return ((x >> 56) /*& 0x00000000000000ffULL*/) | ((x >> 40) & 0x000000000000ff00ULL) |
         ((x >> 24) & 0x0000000000ff0000ULL) | ((x >> 8 ) & 0x00000000ff000000ULL) |
         ((x << 8 ) & 0x000000ff00000000ULL) | ((x << 24) & 0x0000ff0000000000ULL) |
	 ((x << 40) & 0x00ff000000000000ULL) | ((x << 56) /*& 0xff00000000000000ULL*/); }
#endif

/**
 * The following macros MUST be used anywhere where byte ordering is important
 */

#if BYTE_ORDER == LITTLE_ENDIAN
#  define GET_LE16(x)		(*(uint16 *)(x))
#  define PUT_LE16(x, y)	(*(uint16 *)(x) = y)
#  define GET_BE16(x)		swap16 (GET_LE16 (x))
#  define PUT_BE16(x, y)	PUT_LE16 (x, swap16 (y))
#  define HOST_TO_LE16(x)	(x)
#  define HOST_TO_BE16(x)	swap16(x)
#  define GET_LE32(x)		(*(uint32 *)(x))
#  define PUT_LE32(x, y)	(*(uint32 *)(x) = y)
#  define GET_BE32(x)		swap32 (GET_LE32 (x))
#  define PUT_BE32(x, y)	PUT_LE32 (x, swap32 (y))
#  define HOST_TO_LE32(x)	(x)
#  define HOST_TO_BE32(x)	swap32(x)
#  define GET_LE64(x)		(*(uint64 *)(x))
#  define PUT_LE64(x, y)	(*(uint64 *)(x) = y)
#  define GET_BE64(x)		swap64 (GET_LE64 (x))
#  define PUT_BE64(x, y)	PUT_LE64 (x, swap64 (y))
#  define HOST_TO_LE64(x)	(x)
#  define HOST_TO_BE64(x)	swap64(x)
#elif BYTE_ORDER == BIG_ENDIAN
#  define GET_BE16(x)		(*(uint16 *)(x))
#  define PUT_BE16(x, y)	(*(uint16 *)(x) = y)
#  define GET_LE16(x)		swap16 (GET_BE16 (x))
#  define PUT_LE16(x, y)	PUT_BE16 (x, swap16 (y))
#  define HOST_TO_BE16(x)	(x)
#  define HOST_TO_LE16(x)	swap16(x)
#  define GET_BE32(x)		(*(uint32 *)(x))
#  define PUT_BE32(x, y)	(*(uint32 *)(x) = y)
#  define GET_LE32(x)		swap32 (GET_BE32 (x))
#  define PUT_LE32(x, y)	PUT_BE32 (x, swap32 (y))
#  define HOST_TO_BE32(x)	(x)
#  define HOST_TO_LE32(x)	swap32(x)
#  define GET_BE64(x)		(*(uint64 *)(x))
#  define PUT_BE64(x, y)	(*(uint64 *)(x) = y)
#  define GET_LE64(x)		swap64 (GET_BE64 (x))
#  define PUT_LE64(x, y)	PUT_BE64 (x, swap64 (y))
#  define HOST_TO_BE64(x)	(x)
#  define HOST_TO_LE64(x)	swap64(x)
#endif

#define LE16_TO_HOST(x)		HOST_TO_LE16(x)
#define BE16_TO_HOST(x)		HOST_TO_BE16(x)
#define LE32_TO_HOST(x)		HOST_TO_LE32(x)
#define BE32_TO_HOST(x)		HOST_TO_BE32(x)
#define LE64_TO_HOST(x)		HOST_TO_LE64(x)
#define BE64_TO_HOST(x)		HOST_TO_BE64(x)

// Number of bits in the 'int' type
#define BITS_PER_INT		(sizeof (int) * 8)
// Number of bits in the 'long' type
#define BITS_PER_LONG		(sizeof (long) * 8)

#define STRINGIZE(a)		#a
#define ARRAY_LEN(a)		(sizeof (a) / sizeof (a [0]))

// fix buggy MSVC's for variable scoping to be reliable =S
#if COMPILER == COMPILER_MICROSOFT && _MSC_VER < 1300
#  define for if(0);else for
#endif

#if PLATFORM == PLATFORM_WIN32
#  define vsnprintf _vsnprintf
#endif

// MinGW is C99-compliant and has strcasecmp
#if PLATFORM == PLATFORM_WIN32 && COMPILER != COMPILER_GNU
#  define strcasecmp stricmp
#endif

#endif
