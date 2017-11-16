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
#include <windows.h>
#include <assert.h>

namespace ZThread {


/**
 * @class FastRecursiveLock
 *
 * @author Eric Crahen <http://www.code-foo.com>
 * @date <2003-07-16T23:32:34-0400>
 * @version 2.1.6
 *
 * This is the smaller and faster implementation of a RecursiveLock. 
 * A single thread can acquire the mutex any number of times, but it
 * must perform a release for each acquire(). Other threads are blocked
 * until a thread has released all of its locks on the mutex.
 * 
 * This particular implementation performs fewer safety checks. Like 
 * the FastLock implementation, any waiting caused by an acquire() request 
 * is not interruptable. This is so that the mutex can have the fastest
 * response time for a time critical application while still having a good
 * degree of reliability.
 *
 * TryEnterCriticalSection() does not work at all on some systems, so its 
 * not used.
 *
 *
 * The current Platform SDK defines:
 *
 *   LONG InterlockedExchange(LPLONG, LONG)
 *   LONG InterlockedCompareExchange(LPLONG, LONG, LONG, LONG) 
 *
 * If your compiler complains about LPLONG not being implicitly casted to
 * a PVOID, then you should get the SDK update from microsoft or use the 
 * WIN9X implementation of this class.
 *
 * ----
 * Because Windows 95 and earlier can run on processors prior to the 486, they
 * don't all support the CMPXCHG function, and so Windows 95 an earlier dont support
 * InterlockedCompareExchange. If you define ZT_WIN9X, you'll get a version of the 
 * FastLock that uses the XCHG instruction
 */ 
class FastRecursiveLock : private NonCopyable {

// Add def for mingw32 or other non-ms compiler to align on 64-bit
// boundary
#pragma pack(push, 8)
  LONG volatile _lock;
#pragma pack(pop)
  LONG _count;
  
  public:
  
  /**
   * Create a new FastRecursiveLock
   */
  inline FastRecursiveLock() : _lock(0), _count(0) { }

  
  /**
   * Destroy FastLock
   */
  inline ~FastRecursiveLock() {
    assert(_lock == 0);
  }

  /**
   * Lock the fast Lock, no error check.
   * 
   * @exception None
   */ 
  inline void acquire() {

    DWORD id = ::GetCurrentThreadId();

    // Take ownership if the lock is free or owned by the calling thread
    do {

      DWORD owner = (DWORD)::InterlockedCompareExchange(const_cast<LPLONG>(&_lock), id, 0);
      if(owner == 0 || owner == id)
        break;

      ::Sleep(0);

    } while(1);
        
    _count++;

  }

  
  /**
   * Release the fast Lock, no error check.
   * 
   * @exception None
   */ 
  inline void release() {

    if(--_count == 0)
      ::InterlockedExchange(const_cast<LPLONG>(&_lock), 0);

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
    
    DWORD id = ::GetCurrentThreadId();
    DWORD owner = (DWORD)::InterlockedCompareExchange(const_cast<LPLONG>(&_lock), id, 0);
    
    if(owner == 0 || owner == id) {
      _count++;
      return true;
    }
    
    return false;
    
  }
  
  
}; /* FastRecursiveLock */


};
#endif
