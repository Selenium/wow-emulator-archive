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

#include "../FastLock.h"
#include "../ThreadOps.h"
#include <assert.h>

namespace ZThread {

/**
 * @class FastRecursiveLock
 *
 * @author Eric Crahen <http://www.code-foo.com>
 * @date <2003-07-16T23:31:09-0400>
 * @version 2.2.8
 *
 * This is a vanilla FastRecursiveLock implementation for a
 * system that doesn't provide recurisve locks. This implementation
 * is based on using a pair of mutexes, because of this, it performs 
 * roughly the same as a spin lock would.
 */ 
class FastRecursiveLock : private NonCopyable {
    
  //! Lock for blocking
  FastLock _blockingLock;

  //! Serialize state
  FastLock _stateLock;

  //! Owner
  ThreadOps _owner;

  //! Count
  volatile unsigned int _count;

 public:

  inline FastRecursiveLock() : _owner(ThreadOps::INVALID), _count(0) { }
  
  inline ~FastRecursiveLock() {

    assert(_owner == ThreadOps::INVALID);
    assert(_count == 0);

  }
  
  void acquire() {

    ThreadOps self(ThreadOps::self());

    // Try to lock the blocking mutex first
    bool wasLocked = _blockingLock.tryAcquire();
    if(!wasLocked) {
    
      // Otherwise, grab the lock for the state
      _stateLock.acquire();

      wasLocked = (_owner == self);
      if(wasLocked)
        _count++;

      _stateLock.release();
      
      if(wasLocked)
        return;

      // Try to be cooperative
      ThreadOps::yield();
      _blockingLock.acquire();
      
    }

    // Serialze access to the state 
    _stateLock.acquire();
    
    // Take ownership    
    assert(_owner == ThreadOps::INVALID || _owner == self);

    _owner = self;
    _count++;
      
    _stateLock.release();

  }
  
  
  bool tryAcquire(unsigned long timeout = 0) {

    ThreadOps self(ThreadOps::self());

    // Try to lock the blocking mutex first
    bool wasLocked = _blockingLock.tryAcquire();
    if(!wasLocked) {
    
      // Otherwise, grab the lock for the state
      _stateLock.acquire();

      wasLocked = (_owner == self);
      if(wasLocked)
        _count++;

      _stateLock.release();
      
      return wasLocked;
      
    }

    // Serialze access to the state 
    _stateLock.acquire();
    
    // Take ownership    
    assert(_owner == ThreadOps::INVALID || _owner == self);

    _owner = self;
    _count++;
      
    _stateLock.release();
    
    return true;

  }

    
  void release() {

    // Assume that release is only used by the owning thread, as it 
    // should be.
    assert(_count != 0);
    assert(_owner == ThreadOps::self());
    
    _stateLock.acquire();
    
    // If the lock was owned and the count has reached 0, give up
    // ownership and release the blocking lock
    if(--_count == 0) {
      
      _owner = ThreadOps::INVALID;
      _blockingLock.release();
      
    }
    
    _stateLock.release();

  }
  

}; /* FastRecursiveLock */

} // namespace ZThread 

#endif
