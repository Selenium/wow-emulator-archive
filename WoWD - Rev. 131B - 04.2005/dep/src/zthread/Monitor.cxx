/*
 *  ZThreads, a platform-independent, multi-threading and 
 *  synchronization library
 *
 *  Copyright (C) 2000-2003 Eric Crahen, See LGPL.TXT for details
 *
 *  This library is free software; you can redistribute it and/or
 *  modify it under the terms of the GNU Lesser General Public
 *  License as published by the Free Software Foundation; either
 *  version 2.1 of the License, or (at your option) any later version.
 *
 *  This library is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 *  Lesser General Public License for more details.
 *
 *  You should have received a copy of the GNU Lesser General Public
 *  License along with this library; if not, write to the Free Software
 *  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307 USA
 */

#ifndef __ZTMONITORIMPLSELECT_CXX__
#define __ZTMONITORIMPLSELECT_CXX__

#include "Monitor.h"

// This file will select an implementation for a Monitor based on
// what Monitor.h selects. This method is for selecting the 
// source files, to improve portability. Currently, the project is
// based on the autoconf tool-set, which doesn't support conditional
// compilation well. Additionally, this should make the library 
// easier to port since its working around conditional compilation
// by using C++ features and people won't have to fiddle around with
// their make tool as much to compile the source

#include ZT_MONITOR_IMPLEMENTATION

#endif
