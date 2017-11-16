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


#ifndef __ZTTHREADOPSIMPLSELECT_CXX__
#define __ZTTHREADOPSIMPLSELECT_CXX__

#include "ThreadOps.h"

// This file will select an implementation for a ThreadOps based on
// what ThreadOps.h selects. This method is for selecting the 
// source files, to improve portability. Currently, the project is
// based on the autoconf tool-set, which doesn't support conditional
// compilation well. Additionally, this should make the library 
// easier to port since its working around conditional compilation
// by using C++ features and people won't have to fiddle around with
// their make tool as much to compile the source

#ifdef HAVE_CONFIG_H
#  include "config.h"
#endif

// Check for sched_yield()

#if !defined(HAVE_SCHED_YIELD)
#  if defined(HAVE_UNISTD_H)
#    include <unistd.h>
#    if defined(_POSIX_PRIORITY_SCHEDULING)
#      define HAVE_SCHED_YIELD 1
#    endif
#  endif
#endif

#include ZT_THREADOPS_IMPLEMENTATION

#endif
