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

#ifndef __ZTFASTRECURSIVELOCK_H__
#define __ZTFASTRECURSIVELOCK_H__

#include "zthread/NonCopyable.h"
#include <pthread.h>
#include <errno.h>
#include <assert.h>

namespace ZThread {

/**
 * @class FastRecursiveLock
 *
 * @author Eric Crahen <http://www.code-foo.com>
 * @date <2003-07-16T23:28:37-0400>
 * @version 2.2.0
 *
 * This is an implementation of a FastRecursiveLock for any vannila
 * POSIX system. It is based on a condition variable and a mutex; 
 * because of this it is important to not that its waiting properties
 * are not the same as other mutex implementations that generally
 * based on spin locks. Under high contention, this implementation may
 * be preferable to a spin lock, although refactoring the design of
 * code that puts a mutex under alot of preasure may be worth investigating.
 */ 
class FastRecursiveLock : private NonCopyable {

  //! Serialize state
  pthread_mutex_t _mtx;

  //! Wait for lock
  pthread_cond_t _cond;

  //! Owner
  pthread_t _owner;

  //! Count
  volatile unsigned int _count;

public:

  inline FastRecursiveLock() : _owner(0), _count(0) {
    
    pthread_mutex_init(&_mtx, 0);
    if(pthread_cond_init(&_cond, 0) != 0) {
      assert(0);
    }

  }
  
  inline ~FastRecursiveLock() {

    pthread_mutex_destroy(&_mtx);
    if(pthread_cond_destroy(&_cond) != 0) {
      assert(0); 
    }
    
  }
  
  inline void acquire() {
    
    pthread_t self = pthread_self();
    pthread_mutex_lock(&_mtx);

    // If the caller does not own the lock, wait until there is no owner
    if(_owner != 0 && !pthread_equal(_owner, self)) {

      int status = 0;
      do { // ignore signals
        status = pthread_cond_wait(&_cond, &_mtx);
      } while(status == EINTR && _owner == 0);
      
    }
    
    _owner = self;
    _count++;

    pthread_mutex_unlock(&_mtx);
 
  }

  inline bool tryAcquire(unsigned long timeout=0) {

    pthread_t self = pthread_self();
    pthread_mutex_lock(&_mtx);

    // If the caller owns the lock, or there is no owner update the count
    bool success = (_owner == 0 || pthread_equal(_owner, self));
    if(success) {
      
      _owner = self;
      _count++;
      
    }

    pthread_mutex_unlock(&_mtx);

    return success;

  }

  inline void release() {
    
    assert(pthread_equal(_owner, pthread_self()));

    pthread_mutex_lock(&_mtx);
    if(--_count == 0) {

      _owner = 0;
      pthread_cond_signal(&_cond);

    }

    pthread_mutex_unlock(&_mtx);
    
  }
  
  
}; /* FastRecursiveLock */


} // namespace ZThread 

#endif
