/*
 *  ZThreads, a platform-independent, multi-threading and 
 *  synchronization library
 *
 *  Copyright (C) 2000-2003, Eric Crahen, See LGPL.TXT for details
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

#ifndef __ZTFASTMUTEX_H__
#define __ZTFASTMUTEX_H__

#include "zthread/Lockable.h"
#include "zthread/NonCopyable.h"

namespace ZThread {

  class FastLock;

  /**
   * @class FastMutex
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-19T18:45:39-0400>
   * @version 2.2.0
   *
   * A FastMutex is a small fast implementation of a non-recursive, mutually exclusive
   * Lockable object. This implementation is a bit faster than the other Mutex classes
   * as it involved the least overhead. However, this slight increase in speed is 
   * gained by sacrificing the robustness provided by the other classes. 
   *
   * A FastMutex has the useful property of not being interruptable; that is to say  
   * that acquire() and tryAcquire() will not throw Interrupted_Exceptions.
   *
   * @see Mutex
   *
   * <b>Scheduling</b>
   *
   * Scheduling is left to the operating systems and may vary.
   *
   * <b>Error Checking</b>
   *
   * No error checking is performed, this means there is the potential for deadlock.
   */ 
  class ZTHREAD_API FastMutex : public Lockable, private NonCopyable {
    
    FastLock* _lock;

  public:
  
    //! Create a FastMutex
    FastMutex();
  
    //! Destroy a FastMutex
    virtual ~FastMutex();
  
    /**
     * Acquire exclusive access to the mutex. The calling thread will block until the 
     * lock can be acquired. No safety or state checks are performed.
     * 
     * @pre The calling thread should <i>not</i> have previously acquired this lock.
     *      Deadlock will result if the same thread attempts to acquire the mutex more 
     *      than once. 
     *
     * @post The calling thread obtains the lock successfully if no exception is thrown.
     * @exception Interrupted_Exception never thrown
     */
    virtual void acquire();
  
    /**
     * Release exclusive access. No safety or state checks are performed.
     * 
     * @pre the caller should have previously acquired this lock
     */
    virtual void release();
  
    /**
     * Try to acquire exclusive access to the mutex. The calling thread will block until the 
     * lock can be acquired. No safety or state checks are performed.
     * 
     * @pre The calling thread should <i>not</i> have previously acquired this lock.
     *      Deadlock will result if the same thread attempts to acquire the mutex more 
     *      than once. 
     *
     * @param timeout unused
     * @return 
     * - <em>true</em> if the lock was acquired
     * - <em>false</em> if the lock was acquired
     *
     * @post The calling thread obtains the lock successfully if no exception is thrown.
     * @exception Interrupted_Exception never thrown
     */
    virtual bool tryAcquire(unsigned long timeout);
  
  }; /* FastMutex */

};

#endif // __ZTFASTMUTEX_H__
