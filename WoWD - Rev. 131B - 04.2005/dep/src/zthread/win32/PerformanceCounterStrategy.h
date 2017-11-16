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

#include <assert.h>
#include <windows.h>

namespace ZThread {

/**
 * @class PerformanceCounterStrategy
 *
 * Implement a strategy for time operatons based on 
 * Windows QueryPerformanceXXX() functions. 
 * This only (erroneously) considers the lower 32 bits.
 */
class TimeStrategy {

  unsigned long _secs;
  unsigned long _millis;
    
public:

  TimeStrategy() {
    
    // Keep track of the relative time the program started
    static LARGE_INTEGER i;
    static BOOL valid(::QueryPerformanceCounter(&i));

    assert(valid == TRUE);

    LARGE_INTEGER j;
    ::QueryPerformanceCounter(&j);
  
    j.LowPart -= i.LowPart;
    j.LowPart /= frequency();

    // Mask off the high bits        
    _millis = (unsigned long)j.LowPart / 1000;
    _secs   = (unsigned long)j.LowPart - _millis;

  }
  
  unsigned long seconds() const {
    return _secs;
  }

  unsigned long milliseconds() const {  
    return _millis;    
  }

  unsigned long seconds(unsigned long s) {

    unsigned long z = seconds();

    _secs = s;
    return z;

  }

  unsigned long milliseconds(unsigned long ms) {

    unsigned long z = milliseconds();

    _millis = ms;
    return z;

  }

private:

  // Get the frequency
  static DWORD frequency() {

    static LARGE_INTEGER i;
    static BOOL valid(::QueryPerformanceFrequency(&i));

    assert(valid == TRUE);
    return i.LowPart;

  }

};

};

#endif // __ZTTIMESTRATEGY_H__
