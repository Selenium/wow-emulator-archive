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

#ifndef __ZTFASTRECURSIVELOCKSELECT_H__
#define __ZTFASTRECURSIVELOCKSELECT_H__

#include "zthread/Config.h"

#ifdef HAVE_CONFIG_H
#  include "config.h"
#endif

// Select the correct FastRecusriveLock implementation based on
// what the compilation environment has defined

#if defined(ZTHREAD_DUAL_LOCKS) 
#  include "vanilla/DualMutexRecursiveLock.h"
#else

#  if defined(ZT_POSIX)

// Linux and Solaris have working pthreads recursive locks. These
// are created differently, and there are some system don't seem to
// include recursive locks at all. Several recursive implementations
// are provided

#    if defined(__linux__)
#      include "linux/FastRecursiveLock.h"
#    elif defined(HAVE_MUTEXATTR_SETTYPE)
#      include "solaris/FastRecursiveLock.h"
#    elif defined(ZTHREAD_CONDITION_LOCKS) 
#      include "posix/ConditionRecursiveLock.h"
#    endif

// Use spin locks
#  elif defined(ZT_WIN32) && defined(ZTHREAD_USE_SPIN_LOCKS)
#    include "win32/AtomicFastRecursiveLock.h"

// Use normal Mutex objects
#  elif defined(ZT_WIN32) || defined(ZT_WIN9X)
#    include "win32/FastRecursiveLock.h"
#  endif

#endif

#ifndef __ZTFASTRECURSIVELOCK_H__
#include "vanilla/SimpleRecursiveLock.h"
#endif

#endif // __ZTFASTRECURSIVELOCKSELECT_H__
