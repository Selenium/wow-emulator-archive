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

#ifndef __ZTSYNCHRONOUSEXECUTOR_H__
#define __ZTSYNCHRONOUSEXECUTOR_H__

#include "zthread/Executor.h"
#include "zthread/Guard.h"
#include "zthread/Mutex.h"
#include "zthread/Thread.h"

namespace ZThread {

  /**
   * @class SynchronousExecutor
   *
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-16T22:33:51-0400>
   * @version 2.3.0
   *
   * A SynchronousExecutor is an Executor which runs tasks using the thread that 
   * submits the task. It runs tasks serially, one at a time, in the order they
   * were submitted to the executor.
   *
   * @see Executor.
   */
  class SynchronousExecutor : public Executor {
    
    //! Serialize access
    Mutex _lock;

    //! Cancellation flag
    bool _canceled;

    public:

    //! Create a new SynchronousExecutor
    SynchronousExecutor();

    //! Destroy a SynchronousExecutor
    virtual ~SynchronousExecutor();

    /**
     * This operation is not supported by this executor.
     */
    virtual void interrupt();

    /**
     * Submit a task to this Executor, blocking the calling thread until the 
     * task is executed. 
     *
     * @param task Task to be run by a thread managed by this executor 
     *
     * @pre  The Executor should have been canceled prior to this invocation.
     * @post The submitted task will be run at some point in the future by this Executor.
     *
     * @exception Cancellation_Exception thrown if the Executor was canceled prior to
     *            the invocation of this function.
     *
     * @see Executor::execute(const Task& task)
     */
    virtual void execute(const Task& task);

    /**
     * @see Cancelable::cancel()
     */
    virtual void cancel();
  
    /**
     * @see Cancelable::cancel()
     */
    virtual bool isCanceled();
 
    /**
     * Block the calling thread until all tasks submitted prior to this invocation
     * complete.
     *
     * @exception Interrupted_Exception thrown if the calling thread is interrupted
     *            before the set of tasks being wait for can complete.
     *
     * @see Executor::wait()
     */
    virtual void wait();

    /**
     * Block the calling thread until all tasks submitted prior to this invocation
     * complete or until the calling thread is interrupted.
     *
     * @param timeout - maximum amount of time, in milliseconds, to wait for the 
     * currently submitted set of Tasks to complete.
     *
     * @exception Interrupted_Exception thrown if the calling thread is interrupted
     *            before the set of tasks being wait for can complete.
     *
     * @return 
     *   - <em>true</em> if the set of tasks being wait for complete before 
     *                   <i>timeout</i> milliseconds elapse.
     *   - <em>false</em> othewise.
     */
    virtual bool wait(unsigned long timeout);


  }; /* SynchronousExecutor */

} // namespace ZThread

#endif // __ZTSYNCHRONOUSEXECUTOR_H__
