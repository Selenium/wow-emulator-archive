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
 * @date <2003-07-16T23:30:59-0400>
 * @version 2.2.8
 *
 * This implementation of a FastRecursiveLock uses the which ever FastLock
 * that is selected to create a recursive spin lock. 
 */ 
class FastRecursiveLock : private NonCopyable {
  
  FastLock _lock;

  ThreadOps _owner;

  volatile unsigned int _count;
  
public:
  
  inline FastRecursiveLock() : _owner(ThreadOps::INVALID), _count(0) {}
  
  inline ~FastRecursiveLock() {

    assert(_owner == ThreadOps::INVALID);
    assert(_count == 0);

  }
  
  inline void acquire() {

    ThreadOps self(ThreadOps::self());
    bool wasLocked = false;

    do {
      
      _lock.acquire();
      
      // If there is no owner, or the owner is the caller
      // update the count
      if(_owner == ThreadOps::INVALID || _owner == self) {

        _owner = self;
        _count++;
        
        wasLocked = true;
  
      }

      _lock.release();
      
    } while(!wasLocked);

    assert(_owner == ThreadOps::self());

  }

  inline void release() {

    assert(_owner == ThreadOps::self());

    _lock.acquire();

    if(--_count == 0)
      _owner = ThreadOps::INVALID;

    _lock.release();
    
  }
  
  inline bool tryAcquire(unsigned long timeout=0) {

    ThreadOps self(ThreadOps::self());
    bool wasLocked = false;

    _lock.acquire();
    
    if(_owner == ThreadOps::INVALID || _owner == self) {
    
      _owner = self;
      _count++;
      
      wasLocked = true;

    }
    
    _lock.release();

    assert(!wasLocked || _owner == ThreadOps::self());
    return wasLocked;    
    
  }
  
}; /* FastRecursiveLock */


} // namespace ZThread

#endif
