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

namespace ZThread {

/**
 * @class FastRecursiveLock
 *
 * @author Eric Crahen <http://www.code-foo.com>
 * @date <2003-07-16T23:31:23-0400>
 * @version 2.2.0
 *
 * This FastRecursiveLock implementation uses pthreads mutex attribute 
 * functions to create a recursive lock. This implementation is not 
 * specific to solaris and will work on any system that supports 
 * pthread_mutexattr_settype().  
 */ 
class FastRecursiveLock : private NonCopyable {
    
  pthread_mutex_t _mtx;

  /**
   * @class Attribute
   *
   * Utility class to maintain the attribute as long as it is needed.
   */
  class Attribute {
    
    pthread_mutexattr_t _attr;

  public:

    Attribute() {

      if(pthread_mutexattr_init(&_attr) != 0) {
        assert(0);
      }
      
      if(pthread_mutexattr_settype(&_attr, PTHREAD_MUTEX_RECURSIVE) != 0) {
        assert(0);
      }

    }
    
    ~Attribute() {

      if(pthread_mutexattr_destroy(&_attr) != 0) {
        assert(0);
      }

    }

    operator pthread_mutexattr_t*() {
      return &_attr;
    }

  };

public:

  inline FastRecursiveLock() {
    
    static Attribute attr;
    pthread_mutex_init(&_mtx, (pthread_mutexattr_t*)attr);

  }
  
  inline ~FastRecursiveLock() {

    pthread_mutex_destroy(&_mtx);

  }
  
  inline void acquire() {
    
    pthread_mutex_lock(&_mtx);

  }

  inline void release() {
    
    pthread_mutex_unlock(&_mtx);
    
  }
  
  inline bool tryAcquire(unsigned long timeout=0) {

    return (pthread_mutex_trylock(&_mtx) == 0);

  }
  
}; /* FastRecursiveLock */


} // namespace ZThread

#endif
