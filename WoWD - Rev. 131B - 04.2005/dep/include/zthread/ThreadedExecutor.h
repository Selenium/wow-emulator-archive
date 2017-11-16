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

#ifndef __ZTTHREADEDEXECUTOR_H__
#define __ZTTHREADEDEXECUTOR_H__

#include "zthread/Executor.h"
#include "zthread/CountedPtr.h"

namespace ZThread {

  namespace { class ExecutorImpl; }

  /**
   * @class ThreadedExecutor
   *
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-16T22:39:13-0400>
   * @version 2.3.0
   *
   * A ThreadedExecutor spawns a new thread to execute each task submitted.
   * A ThreadedExecutor supports the following optional operations,
   *
   * - <em>cancel</em>()ing a ThreadedExecutor will cause it to stop accepting 
   *   new tasks. 
   *
   * - <em>interrupt</em>()ing a ThreadedExecutor will cause the any thread running 
   *   a task which was submitted prior to the invocation of this function to 
   *   be interrupted during the execution of that task.
   *
   * - <em>wait</em>()ing on a ThreadedExecutor will block the calling thread 
   *   until all tasks that were submitted prior to the invocation of this function
   *   have completed.
   * 
   * @see Executor.
   */
  class ThreadedExecutor : public Executor {
  
    CountedPtr< ExecutorImpl > _impl;

  public:

    //! Create a new ThreadedExecutor
    ThreadedExecutor();

    //! Destroy a ThreadedExecutor
    virtual ~ThreadedExecutor();

    /**
     * Interrupting a ThreadedExecutor will cause an interrupt() to be sent
     * to every Task that has been submitted at the time this function is
     * called. Tasks that are submitted after this function is called will 
     * not be interrupt()ed; unless this function is invoked again().
     */
    virtual void interrupt();
    
    /**
     * Submit a task to this Executor. This will not block the current thread 
     * for very long. A new thread will be created and the task will be run()
     * within the context of that new thread.
     * 
     * @exception Cancellation_Exception thrown if this Executor has been canceled.
     * The Task being submitted will not be executed by this Executor.
     *
     * @see Executor::execute(const Task&)
     */
    virtual void execute(const Task&);

    /**
     * @see Cancelable::cancel()
     */
    virtual void cancel();
  
    /**
     * @see Cancelable::isCanceled()
     */
    virtual bool isCanceled();
 
    /**
     * Waiting on a ThreadedExecutor will block the current thread until all
     * tasks submitted to the Executor up until the time this function was called
     * have completed.
     *
     * Tasks submitted after this function is called will not delay a thread that
     * was already waiting on the Executor any longer. In order to wait for
     * those tasks to complete as well, another wait() would be needed.
     *
     * @exception Interrupted_Exception thrown if the calling thread is interrupted
     *            before the set of tasks for which it was waiting complete.
     *
     * @see Waitable::wait()
     */
    virtual void wait();

    /**
     * Operates the same as ThreadedExecutor::wait() but with a timeout. 
     *
     * @param timeout maximum amount of time, in milliseconds, to wait for the 
     *                currently submitted set of Tasks to complete.
     *
     * @exception Interrupted_Exception thrown if the calling thread is interrupt()ed
     *            while waiting for the current set of Tasks to complete.
     *
     * @return 
     *   - <em>true</em> if the set of tasks running at the time this function is invoked complete
     *     before <i>timeout</i> milliseconds elapse.
     *   - <em>false</em> othewise.
     *
     * @see Waitable::wait(unsigned long timeout)
     */
    virtual bool wait(unsigned long timeout);

  }; /* ThreadedExecutor */

} // namespace ZThread

#endif // __ZTTHREADEDEXECUTOR_H__
