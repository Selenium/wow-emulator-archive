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

#ifndef WOWPYTHONSERVER_COMMON_H
#define WOWPYTHONSERVER_COMMON_H

// Only clients with this version will be allowed to view the realmlist.
// Higher versions will be rejected, lower versions will be patched if possible.

#define EXPECTED_WOW_CLIENT_BUILD         3925 //3892 //3810//3807//3734//3712//3702//3694
// 3925 for 0.11.0

#ifdef HAVE_CONFIG_H
# include <config.h>
#endif

#include <stdio.h>
#include <stdlib.h>


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
#  error "FATAL ERROR: Unknown compiler."
#endif

#if COMPILER == COMPILER_MICROSOFT
#  pragma warning( disable : 4267 ) // conversion from 'size_t' to 'int', possible loss of data
#  pragma warning( disable : 4786 ) // identifier was truncated to '255' characters in the debug information
#  pragma warning( disable : 4244 ) // conversion from 'uint32','double', to 'float',''uint8', possible loss of data
#endif

// MinGW is C99-compliant and has strcasecmp
#if PLATFORM == PLATFORM_WIN32 && COMPILER != COMPILER_GNU
#define STRCASECMP stricmp
#else
#define STRCASECMP strcasecmp
#endif

#include <set>
#include <list>
#include <string>
#include <map>
#include <sstream>
#include <algorithm>

#include "MemoryLeaks.h"

// VS.NET 2003 has long long, but eralier versions don't
#if COMPILER == COMPILER_MICROSOFT && _MSC_VER < 1300
  typedef __int64   int64;
#else
  typedef long long int64;
#endif
typedef long        int32;
typedef short       int16;
typedef char        int8;

#if COMPILER == COMPILER_MICROSOFT && _MSC_VER < 1300
  typedef unsigned __int64   uint64;
#else
  typedef unsigned long long uint64;
  typedef unsigned long      DWORD;
#endif
typedef unsigned long        uint32;
typedef unsigned short       uint16;
typedef unsigned char        uint8;

//#define atol(a) strtoul( a, NULL, 10)

#define STRINGIZE(a) #a

// fix buggy MSVC's for variable scoping to be reliable =S
#define for if(true) for

#endif

