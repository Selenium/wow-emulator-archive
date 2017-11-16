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

#ifndef __ZTPOOLEXECUTOR_H__
#define __ZTPOOLEXECUTOR_H__

#include "zthread/Executor.h"
#include "zthread/CountedPtr.h"
#include "zthread/Thread.h"

namespace ZThread {
  
  namespace { class ExecutorImpl; }

  /**
   * @class PoolExecutor
   *
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-16T22:41:07-0400>
   * @version 2.3.0
   *
   * A PoolExecutor spawns a set of threads that are used to run tasks 
   * that are submitted in parallel. A PoolExecutor supports the following
   * optional operations,
   *
   * - <em>cancel</em>()ing a PoolExecutor will cause it to stop accepting 
   *   new tasks. 
   *
   * - <em>interrupt</em>()ing a PoolExecutor will cause the any thread running 
   *   a task which was submitted prior to the invocation of this function to 
   *   be interrupted during the execution of that task.
   *
   * - <em>wait</em>()ing on a PoolExecutor will block the calling thread 
   *   until all tasks that were submitted prior to the invocation of this function
   *   have completed.
   * 
   * @see Executor.
   */
  class PoolExecutor : public Executor {

    //! Reference to the internal implementation 
    CountedPtr< ExecutorImpl > _impl;
    
    //! Cancellation task
    Task _shutdown;

  public:
    
    /**
     * Create a PoolExecutor
     *
     * @param n number of threads to service tasks with
     */
    PoolExecutor(size_t n);

    //! Destroy a PoolExecutor
    virtual ~PoolExecutor();

    /**
     * Invoking this function causes each task that had been submitted prior to
     * this function to be interrupted. Tasks submitted after the invocation of 
     * this function are unaffected.
     *
     * @post Any task submitted prior to the invocation of this function will be
     *       run in the context of an interrupted thread. 
     * @post Any thread already executing a task which was submitted prior to the 
     *       invocation of this function will be interrupted.        
     */
    virtual void interrupt();

    /**
     * Alter the number of threads being used to execute submitted tasks.
     * 
     * @param n number of worker threads.
     *
     * @pre  <i>n</i> must be greater than 0.
     * @post <i>n</i> threads will be executing tasks submitted to this executor.
     *
     * @exception InvalidOp_Exception thrown if the new number of threads
     *            <i>n</i> is less than 1.
     */
    void size(size_t n);
        
    /**
     * Get the current number of threads being used to execute submitted tasks.
     *
     * @return n number of worker threads.
     */
    size_t size();
    
    /**
     * Submit a task to this Executor. 
     *
     * This will not block the calling thread very long. The submitted task will
     * be executed at some later point by another thread.
     * 
     * @param task Task to be run by a thread managed by this executor 
     *
     * @pre  The Executor should have been canceled prior to this invocation.
     * @post The submitted task will be run at some point in the future by this Executor.
     *
     * @exception Cancellation_Exception thrown if the Executor was canceled prior to
     *            the invocation of this function.
     *
     * @see PoolExecutor::cancel()
     * @see Executor::execute(const Task& task)
     */
    virtual void execute(const Task& task);

    /**
     * @see Cancelable::cancel()
     */
    virtual void cancel();

    /**
     * @see Cancelable::isCanceled()
     */
    virtual bool isCanceled();
 
    /**
     * Block the calling thread until all tasks submitted prior to this invocation
     * complete.
     *
     * @exception Interrupted_Exception thrown if the calling thread is interrupted
     *            before the set of tasks being wait for can complete.
     *
     * @see Waitable::wait()
     */
    virtual void wait();

    /**
     * Block the calling thread until all tasks submitted prior to this invocation
     * complete or until the calling thread is interrupted.
     *
     * @param timeout maximum amount of time, in milliseconds, to wait for the 
     *                currently submitted set of Tasks to complete.
     *
     * @exception Interrupted_Exception thrown if the calling thread is interrupted
     *            before the set of tasks being wait for can complete.
     *
     * @return 
     *   - <em>true</em> if the set of tasks being wait for complete before 
     *                   <i>timeout</i> milliseconds elapse.
     *   - <em>false</em> otherwise.
     *
     * @see Waitable::wait(unsigned long timeout)
     */
    virtual bool wait(unsigned long timeout);
      
  }; /* PoolExecutor */


} // namespace ZThread

#endif // __ZTPOOLEXECUTOR_H__




