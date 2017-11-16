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

#ifndef __ZTCOUNTINGSEMAPHORE_H__
#define __ZTCOUNTINGSEMAPHORE_H__

#include "zthread/Lockable.h"
#include "zthread/NonCopyable.h"

namespace ZThread {
  
  class FifoSemaphoreImpl;
  
  /**
   * @class CountingSemaphore
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-16T15:26:18-0400>
   * @version 2.2.1
   *
   * A CountingSemaphore is an owner-less Lockable object. 
   * 
   * It differs from a normal Semaphore in that there is no upper bound on the count
   * and it will not throw an exception because a maximum value has been exceeded.
   *
   * @see Semaphore
   *
   * Threads blocked on a CountingSemaphore are resumed in FIFO order.
   */
  class ZTHREAD_API CountingSemaphore : public Lockable, private NonCopyable {
  
    FifoSemaphoreImpl* _impl;  

  public:

    /**
     * Create a new CountingSemaphore. 
     *
     * @param count - initial count
     */
    CountingSemaphore(int initialCount = 0); 

    //! Destroy the CountingSemaphore
    virtual ~CountingSemaphore();

    /**
     * <i>Provided to reflect the traditional Semaphore semantics</i>
     *
     * @see acquire()
     */ 
    void wait(); 


    /**
     * <i>Provided to reflect the traditional Semaphore semantics</i>
     *
     * @see tryAcquire(unsigned long timeout)
     */
    bool tryWait(unsigned long timeout); 

    /**
     * <i>Provided to reflect the traditional Semaphore semantics</i>
     *
     * @see release()
     */
    void post(); 

  
    /**
     * Get the current count of the semaphore. 
     *
     * This value may change immediately after this function returns to the calling thread.
     *
     * @return <em>int</em> count
     */
    virtual int count(); 
  
    /**
     * Decrement the count, blocking that calling thread if the count becomes 0 or 
     * less than 0. The calling thread will remain blocked until the count is 
     * raised above 0, an exception is thrown or the given amount of time expires.
     * 
     * @param timeout maximum amount of time (milliseconds) this method could block
     * 
     * @return 
     *   - <em>true</em> if the Semaphore was acquired before <i>timeout</i> milliseconds elapse.
     *   - <em>false</em> otherwise.
     *
     * @exception Interrupted_Exception thrown when the calling thread is interrupted.
     *            A thread may be interrupted at any time, prematurely ending any wait.
     * 
     * @see Lockable::tryAcquire(unsigned long timeout)
     */
    virtual bool tryAcquire(unsigned long timeout);

    /**
     * Decrement the count, blocking that calling thread if the count becomes 0 or 
     * less than 0. The calling thread will remain blocked until the count is 
     * raised above 0 or if an exception is thrown.
     * 
     * @exception Interrupted_Exception thrown when the calling thread is interrupted.
     *            A thread may be interrupted at any time, prematurely ending any wait.
     * 
     * @see Lockable::acquire()
     */
    virtual void acquire();

    /**
     * Increment the count, unblocking one thread if count is positive.
     *
     * @see Lockable::release()
     */
    virtual void release();
  
  }; 


} // namespace ZThread

#endif // __ZTCOUNTINGSEMAPHORE_H__
