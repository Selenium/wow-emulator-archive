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

#ifndef __ZTPRIORITYSEMAPHORE_H__
#define __ZTPRIORITYSEMAPHORE_H__

#include "zthread/Lockable.h"
#include "zthread/NonCopyable.h"

namespace ZThread {
  
  class PrioritySemaphoreImpl;
 
  /**
   * @class PrioritySemaphore
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-16T15:36:07-0400>
   * @version 2.2.1
   *
   * A PrioritySemaphore operates in the same way as a Semaphore. Its an owner-less 
   * Lockable object that is sensitive to priority.
   *
   * <b>Scheduling</b>
   *
   * Threads blocked on a PrioritySemaphore are resumed in priority order, highest
   * priority first.
   *
   * <b>Error Checking</b>
   *
   * An attempt to increase a PrioritySemaphore beyond its maximum value will result in 
   * an InvalidOp_Exception.
   *
   * @see Semaphore
   */
  class ZTHREAD_API PrioritySemaphore : public Lockable, private NonCopyable {
  
    PrioritySemaphoreImpl* _impl;
  
  public:
  
    /**
     * @see Semaphore::Semaphore(int count, unsigned int maxCount)
     */
    PrioritySemaphore(int count = 1, unsigned int maxCount = 1);

    /**
     * @see Semaphore::~Semaphore()
     */
    virtual ~PrioritySemaphore();

    /**
     * @see Semaphore::wait()
     */ 
    void wait();

    /**
     * @see Semaphore::tryWait(unsigned long)
     */ 
    bool tryWait(unsigned long);

    /**
     * @see Semaphore::post()
     */
    void post();
  
    /**
     * @see Semaphore::count()
     */
    virtual int count();

    /**
     * @see Semaphore::tryAcquire(unsigned long timeout)
     */
    virtual bool tryAcquire(unsigned long timeout);

    /**
     * @see Semaphore::acquire()
     */
    virtual void acquire();

    /**
     * @see Semaphore::release()
     */
    virtual void release();
      
  }; 


} // namespace ZThread

#endif // __ZTPRIORITYSEMAPHORE_H__
