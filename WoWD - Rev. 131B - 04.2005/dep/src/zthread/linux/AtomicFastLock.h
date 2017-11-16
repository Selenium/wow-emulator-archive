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

#ifndef __ZTFASTLOCK_H__
#define __ZTFASTLOCK_H__

#include "zthread/NonCopyable.h"
#include "../ThreadOps.h"
#include <assert.h>
#include <asm/atomic.h>

#if !defined(NDEBUG)
#  include <pthread.h>
#endif

namespace ZThread {

/**
 * @class FastLock
 *
 * @author Eric Crahen <http://www.code-foo.com>
 * @date <2003-07-16T23:27:03-0400>
 * @version 2.2.0
 *
 * This implementation of a FastLock uses the atomic operations that
 * linux provides with its kernel sources. This demonstrates how to implement
 * a spinlock with a decrement and test primative.
 */ 
class FastLock : private NonCopyable {
  
  atomic_t _value;
  
#if !defined(NDEBUG)
  pthread_t _owner;
#endif

public:
  
  inline FastLock() {
  
    atomic_t tmp =  ATOMIC_INIT(1);
    _value = tmp;

  }
  
  inline ~FastLock() {

    assert(atomic_read(&_value) == 1);
    assert(_owner == 0);

  }
  
  inline void acquire() {

    while(!atomic_dec_and_test(&_value)) {

      atomic_inc(&_value);
      ThreadOps::yield();

    }
        
#if !defined(NDEBUG)
    _owner = pthread_self();
#endif
  }

  inline void release() {
    
#if !defined(NDEBUG)
    assert(pthread_equal(_owner, pthread_self()) != 0);
#endif

    atomic_inc(&_value);
    _owner = 0;

  }
  
  inline bool tryAcquire(unsigned long timeout=0) {
    
    bool wasLocked = atomic_dec_and_test(&_value);
    if(!wasLocked)
      atomic_inc(&_value);

#if !defined(NDEBUG)
    if(wasLocked)
      _owner = pthread_self();
#endif

    return wasLocked;
    
  }
  
}; /* FastLock */


} // namespace ZThread

#endif
