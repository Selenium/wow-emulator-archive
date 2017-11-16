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

#ifndef __ZTTIMESTRATEGY_H__
#define __ZTTIMESTRATEGY_H__

#include <sys/timeb.h>

#if defined(_MSC_VER)

#  include <time.h>

#  define timeb _timeb
#  define ftime _ftime

#endif

namespace ZThread {

/**
 * @class TimeStrategy
 *
 * Implement a strategy for time operatons based on ftime
 */
class TimeStrategy {

  struct timeb _value;

public:

  TimeStrategy() {
    ftime(&_value);
  }

  inline unsigned long seconds() const {
    return (unsigned long)_value.time;
  }

  inline unsigned long milliseconds() const {  
    return _value.millitm;    
  }

  unsigned long seconds(unsigned long s) {

    unsigned long z = seconds();
    _value.time = s;

    return z;

  }

  unsigned long milliseconds(unsigned long ms) {

    unsigned long z = milliseconds();
    _value.millitm = (unsigned short)ms;

    return z;

  }

};

};

#endif // __ZTTIMESTRATEGY_H__
