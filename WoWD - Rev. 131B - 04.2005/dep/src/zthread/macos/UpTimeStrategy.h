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

#include <CoreServices/CoreServices.h>
//#include <DriverServices.h>

namespace ZThread {


/**
 * @class TimeStrategy
 *
 * Implement a strategy for time operatons based on UpTime
 */
class TimeStrategy {

  unsigned long _ms;
  unsigned long _s;

 public:
  
  TimeStrategy() {

    // Get the absolute time in milliseconds relative to the program startup
    static AbsoluteTime sysUpTime(UpTime());
    AbsoluteTime delta = AbsoluteDeltaToNanoseconds(UpTime(), sysUpTime);

    uint64_t now = *reinterpret_cast<uint64_t*>(&delta) / 1000000;

    _s = now / 1000;
    _ms = now % 1000;

  }
  
  inline unsigned long seconds() const {
    return _s;
  }

  inline unsigned long milliseconds() const {  
    return _ms;
  }

  unsigned long seconds(unsigned long s) {

    unsigned long z = seconds();
    _s = s;
    return z;

  }

  unsigned long milliseconds(unsigned long ms) {

    unsigned long z = milliseconds();
    _ms = ms;

    return z;

  }

};

};

#endif // __ZTTIMESTRATEGY_H__
