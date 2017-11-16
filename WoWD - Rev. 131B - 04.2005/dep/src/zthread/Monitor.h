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


#ifndef __ZTMONITORSELECT_H__
#define __ZTMONITORSELECT_H__

#include "zthread/Config.h"

#if defined(ZT_MONITOR_IMPLEMENTATION)
#  error "Reserved symbol defined"
#endif

// Include the dependencies for a Montior 
#ifdef HAVE_CONFIG_H
#  include "config.h"
#endif

// Select the correct Monitor implementation based on
// what the compilation environment has defined
#if defined(ZT_POSIX)

#  include "posix/Monitor.h"
#  define ZT_MONITOR_IMPLEMENTATION "posix/Monitor.cxx"

#elif defined(ZT_WIN32) || defined(ZT_WIN9X)

#  include "win32/Monitor.h"
#  define ZT_MONITOR_IMPLEMENTATION "win32/Monitor.cxx"

#elif defined(ZT_MACOS)

#  include "macos/Monitor.h"
#  define ZT_MONITOR_IMPLEMENTATION "macos/Monitor.cxx"

#endif

#ifndef __ZTMONITOR_H__
#error "No Monitor implementation could be selected"
#endif

#endif // __ZTMONITORSELECT_H__
