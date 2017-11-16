/*
 *  ZThreads, a platform-independant, multithreading and 
 *  synchroniation library
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

#ifndef __ZTEXECUTOR_H__
#define __ZTEXECUTOR_H__

#include "zthread/Thread.h"
#include "zthread/Waitable.h"

namespace ZThread {

 
  /**
   * @class Executor
   *
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-16T22:39:39-0400>
   * @version 2.3.0
   *
   * Execeutors are an implementation of the Executor pattern. This is
   * a more versatile construct than a thread pool. A paper describing can
   * be found in the proceedings of the 2002 VikingPLOP conference.
   *
   * <b>Executing</b>
   * 
   * - <em>execute</em>()ing task with an Executor will submit the task, scheduling
   *   it for execution at some future time depending on the Executor being used.
   *
   * <b>Disabling</b>
   *
   * - <em>cancel</em>()ing an Executor will cause it to stop accepting 
   *   new tasks. 
   *
   * <b>Interrupting</b>
   *
   * - <em>interrupt</em>()ing an Executor will cause the any thread running 
   *   a task which was submitted prior to the invocation of this function to 
   *   be interrupted during the execution of that task.
   *
   * <b>Waiting</b>
   *
   * - <em>wait</em>()ing on a PoolExecutor will block the calling thread 
   *   until all tasks that were submitted prior to the invocation of this function
   *   have completed.
   * 
   * @see Cancelable
   * @see Waitable
   */
  class Executor : public Cancelable, public Waitable, private NonCopyable {
  public:

    /**
     * If supported by the Executor, interrupt all tasks submitted prior to 
     * the invocation of this function.
     */    
    virtual void interrupt() = 0;

    /**
     * Submit a task to this Executor. 
     *
     * @param task Task to be run by a thread managed by this executor 
     *
     * @pre  The Executor should have been canceled prior to this invocation.
     * @post The submitted task will be run at some point in the future by this Executor.
     *
     * @exception Cancellation_Exception thrown if the Executor was canceled prior to
     *            the invocation of this function.
     */
    virtual void execute(const Task& task) = 0;
  
  };

} // namespace ZThread

#endif // __ZTEXECUTOR_H__
