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

//#define EXPECTED_WOW_CLIENT_BUILD         >>> Moved to AuthSocket.cpp

#ifdef HAVE_CONFIG_H
# include <config.h>
#endif

#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <math.h>
#include <errno.h>
#include <set>
#include <list>
#include <string>
#include <map>
#include <queue>
#include <sstream>
#include <algorithm>
#include <zthread/FastMutex.h>
#include <zthread/LockedQueue.h>
#include <zthread/Runnable.h>
#include <zthread/Thread.h>
#include "MemoryLeaks.h"
#include "Portable.h"

#define GUID_HIPART(x) (*(((uint32*)&(x))+1))
#define GUID_LOPART(x) (*((uint32*)&(x)))

#define atol(a) strtoul( a, NULL, 10)

#define STRINGIZE(a) #a

// fix buggy MSVC's for variable scoping to be reliable =S
#define for if(true) for

#endif

