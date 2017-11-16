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


#ifndef __ZTTIMESELECT_H__
#define __ZTTIMESELECT_H__

#include "zthread/Config.h"

#ifdef HAVE_CONFIG_H
#  include "config.h"
#endif

// Select the correct TimeOps implementation based on
// what the complilation environment has defined

#ifndef HAVE_FTIME

#  if defined(ZT_WIN32) || defined(ZT_WIN9X)

#    if !defined(__MWERKS__)

#      ifndef HAVE_FTIME
#      define HAVE_FTIME
#      endif

#    elif defined(__MWERKS__)

#      ifndef HAVE_PERFORMANCECOUNTER
#      define HAVE_PERFORMANCECOUNTER
#      endif

#    endif

#  endif

#endif

// Some systems require this to complete the definition of timespec
// which is needed by pthreads.
#if defined(HAVE_SYS_TYPES_H)
#  include <sys/types.h>
#endif

#if defined(ZT_MACOS)

#  include "macos/UpTimeStrategy.h"

#elif defined(HAVE_PERFORMANCECOUNTER)
              
#  include "win32/PerformanceCounterStrategy.h"

#elif defined(HAVE_FTIME)

#  include "posix/FtimeStrategy.h"

#else

#  include "posix/GetTimeOfDayStrategy.h"

#endif


#ifndef __ZTTIMESTRATEGY_H__
#error "No TimeStrategy implementation could be selected"
#endif

#endif // __ZTTIMESELECT_H__
