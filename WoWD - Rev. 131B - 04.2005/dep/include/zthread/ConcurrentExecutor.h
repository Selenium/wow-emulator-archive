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

#ifndef __ZTCONCURRENTEXECUTOR_H__
#define __ZTCONCURRENTEXECUTOR_H__

#include "zthread/PoolExecutor.h"

namespace ZThread {

  /**
   * @class ConcurrentExecutor
   *
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-16T22:36:11-0400>
   * @version 2.3.0
   *
   * A ConcurrentExecutor spawns a single thread to service a series of Tasks.
   * 
   * @see PoolExecutor.
   */
  class ConcurrentExecutor : public Executor {

    PoolExecutor _executor;

  public:
    
    //! Create a ConcurrentExecutor
    ConcurrentExecutor(); 

    /**
     * Interrupting a ConcurrentExecutor will cause the thread running the tasks to be
     * be interrupted once during the execution of each task that has been submitted 
     * at the time this function is called.
     *  
     * Tasks that are submitted after this function is called will 
     * not be interrupt()ed; unless this function is invoked again().
     *
     * @code
     * 
     * void aFunction() {
     *
     *   ConcurrentExecutor executor;
     *
     *   // Submit p Tasks
     *   for(size_t n = 0; n < p; n++)
     *     executor.execute(new aRunnable);
     *
     *   // Tasks [m, p) may be interrupted, where m is the first task that has 
     *   // not completed at the time the interrupt() is invoked. 
     *   executor.interrupt();
     *
     *   // Submit (q - p) Tasks
     *   for(size_t n = p; n < q; n++)
     *     executor.execute(new Chore);
     * 
     *   // Tasks [p, q) are not interrupted 
     *
     * }
     *
     * @endcode
     */
    virtual void interrupt();
    
    /**
     * Submit a Task to this Executor. This will not block the current thread 
     * for very long. The task will be enqueued internally and eventually run 
     * in the context of the single thread driving all the Tasks submitted to this 
     * Executor.
     * 
     * @exception Cancellation_Exception thrown if this Executor has been canceled.
     * The Task being submitted will not be executed by this Executor.
     *
     * @exception Synchronization_Exception thrown only in the event of an error 
     * in the implementation of the library.
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
     * @see PoolExecutor::wait()
     */
    virtual void wait();
    
    /**
     * @see PoolExecutor::wait(unsigned long timeout)
     */
    virtual bool wait(unsigned long timeout);
    
  }; /* ConcurrentExecutor */
  
} // namespace ZThread

#endif // __ZTCONCURRENTEXECUTOR_H__
