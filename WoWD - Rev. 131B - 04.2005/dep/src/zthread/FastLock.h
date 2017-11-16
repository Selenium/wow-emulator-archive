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


#ifndef __ZTFASTLOCKSELECT_H__
#define __ZTFASTLOCKSELECT_H__

#include "zthread/Config.h"

#ifdef HAVE_CONFIG_H
#include "config.h"
#endif

// Select the correct FastLock implementation based on
// what the compilation environment has defined

#if defined(ZT_POSIX)

#  if defined(HAVE_ATOMIC_LINUX)

#    if defined(ZTHREAD_USE_SPIN_LOCKS)
#      include "linux/AtomicFastLock.h"
#    endif

#  endif

#  include "posix/FastLock.h"

// Use spin locks
#elif defined(ZTHREAD_USE_SPIN_LOCKS)

#  if defined(ZT_WIN9X)
#    include "win9x/AtomicFastLock.h"
#  elif defined(ZT_WIN32)
#    include "win32/AtomicFastLock.h"
#  endif

// Use normal Mutex objects
#elif defined(ZT_WIN9X) || defined(ZT_WIN32)

#  include "win32/FastLock.h"

#elif defined(ZT_MACOS)

#  include "macos/FastLock.h"

#endif

#ifndef __ZTFASTLOCK_H__
#error "No FastLock implementation could be selected"
#endif

#endif // __ZTFASTLOCKSELECT_H__
