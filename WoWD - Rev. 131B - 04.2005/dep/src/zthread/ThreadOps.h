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


#ifndef __ZTTHREADOPSSELECT_H__
#define __ZTTHREADOPSSELECT_H__

#include "zthread/Config.h"

#if defined(ZT_THREADOPS_IMPLEMENTATION)
#  error "Reserved symbol defined"
#endif


// Select the correct implementation
#if defined(ZT_POSIX)

#  include "posix/ThreadOps.h"
#  define ZT_THREADOPS_IMPLEMENTATION "posix/ThreadOps.cxx"

#elif defined(ZT_WIN32) || defined(ZT_WIN9X)

// Visual C provides the _beginthreadex function, other compilers
// might not have this if they don't use Microsoft's C runtime. 
// _beginthreadex is similar to in effect defining REENTRANT on a 
// POSIX system. CreateThreadEx doesn't use reentrant parts of the  
// Microsfot C runtime, but if your not using that runtime, no problem.

#  if !defined(HAVE_BEGINTHREADEX)
#    if defined(_MSC_VER)
#      define HAVE_BEGINTHREADEX
#    endif
#  endif

#  include "win32/ThreadOps.h"
#  define ZT_THREADOPS_IMPLEMENTATION "win32/ThreadOps.cxx"

#elif defined(ZT_MACOS)

#  include "macos/ThreadOps.h"
#  define ZT_THREADOPS_IMPLEMENTATION "macos/ThreadOps.cxx"

#endif

#ifndef __ZTTHREADOPS_H__
#error "No ThreadOps implementation could be selected"
#endif

#endif // __ZTTHREADOPSSELECT_H__
