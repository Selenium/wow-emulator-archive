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

#include "zthread/Exceptions.h"
#include "zthread/NonCopyable.h"
#include <pthread.h>
#include <assert.h>

namespace ZThread {

/**
 * @class FastLock
 *
 * @author Eric Crahen <http://www.code-foo.com>
 * @date <2003-07-16T23:28:07-0400>
 * @version 2.2.8
 *
 * This is the smallest and fastest synchronization object in the library.
 * It is an implementation of fast mutex, an all or nothing exclusive
 * lock. It should be used only where you need speed and are willing 
 * to sacrifice all the state & safety checking provided by the framework
 * for speed.
 */ 
class FastLock : private NonCopyable {
    
  pthread_mutex_t _mtx;

 public:
  
  /**
   * Create a new FastLock. No safety or state checks are performed.
   *
   * @exception Initialization_Exception - not thrown
   */
  inline FastLock() {

    if(pthread_mutex_init(&_mtx, 0) != 0)
      throw Initialization_Exception();

  }
  
  /**
   * Destroy a FastLock. No safety or state checks are performed.
   */
  inline ~FastLock() {

    if(pthread_mutex_destroy(&_mtx) != 0) {
      assert(0);
    }

  }
  
  /**
   * Acquire an exclusive lock. No safety or state checks are performed.
   *
   * @exception Synchronization_Exception - not thrown
   */
  inline void acquire() {
    
    if(pthread_mutex_lock(&_mtx) != 0)
      throw Synchronization_Exception();

  }

  /**
   * Try to acquire an exclusive lock. No safety or state checks are performed.
   * This function returns immediately regardless of the value of the timeout
   *
   * @param timeout Unused
   * @return bool
   * @exception Synchronization_Exception - not thrown
   */
  inline bool tryAcquire(unsigned long timeout=0) {

    return (pthread_mutex_trylock(&_mtx) == 0);

  }
  
  /**
   * Release an exclusive lock. No safety or state checks are performed.
   * The caller should have already acquired the lock, and release it 
   * only once.
   * 
   * @exception Synchronization_Exception - not thrown
   */
  inline void release() {
    
    if(pthread_mutex_unlock(&_mtx) != 0)
      throw Synchronization_Exception();

  }
  
  
}; /* FastLock */


};

#endif
