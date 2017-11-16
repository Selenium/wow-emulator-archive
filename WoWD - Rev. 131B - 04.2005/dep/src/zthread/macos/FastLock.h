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
#include "zthread/Exceptions.h"

#include <assert.h>
#include <CoreServices/CoreServices.h>
//#include <Multiprocessing.h>

namespace ZThread {

/**
 * @class FastLock
 *
 * @author Eric Crahen <http://www.code-foo.com>
 * @date <2003-07-16T23:25:31-0400>
 * @version 2.1.6
 *
 */ 
class FastLock : private NonCopyable {
    
  MPCriticalRegionID _mtx;

 public:
  
  /**
   * Create a new FastLock. No safety or state checks are performed.
   *
   * @exception Initialization_Exception - not thrown
   */
  inline FastLock() {
    
    // Apple TN1071
    static bool init = MPLibraryIsLoaded();
    
    if(!init || MPCreateCriticalRegion(&_mtx) != noErr) {
      assert(0);
      throw Initialization_Exception();
    }

  }
  
  /**
   * Destroy a FastLock. No safety or state checks are performed.
   */
  inline ~FastLock() throw () {

    OSStatus status = MPDeleteCriticalRegion(_mtx);
    if(status != noErr) 
      assert(false);

  }
  
  /**
   * Acquire an exclusive lock. No safety or state checks are performed.
   *
   * @exception Synchronization_Exception - not thrown
   */
  inline void acquire() {
    
    if(MPEnterCriticalRegion(_mtx, kDurationForever) != noErr)
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

    OSStatus status = 
      MPEnterCriticalRegion(_mtx, kDurationMillisecond * timeout);

    switch(status) {
      case kMPTimeoutErr:
        return false;
        
      case noErr:
        return true;
        
    } 
    
    assert(0);
    throw Synchronization_Exception();

  }
  
  /**
   * Release an exclusive lock. No safety or state checks are performed.
   * The caller should have already acquired the lock, and release it 
   * only once.
   * 
   * @exception Synchronization_Exception - not thrown
   */
  inline void release() {
    
    if(MPExitCriticalRegion(_mtx) != noErr)
      throw Synchronization_Exception();

  }
  
  
}; /* FastLock */


};

#endif



