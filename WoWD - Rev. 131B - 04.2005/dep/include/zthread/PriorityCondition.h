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

#ifndef __ZTPRIORITYCONDITION_H__
#define __ZTPRIORITYCONDITION_H__

#include "zthread/Lockable.h"
#include "zthread/NonCopyable.h"
#include "zthread/Waitable.h"

namespace ZThread {
  
  class PriorityConditionImpl;

  /**
   * @class PriorityCondition
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-16T17:35:28-0400>
   * @version 2.2.1
   *
   * A PriorityCondition is a Condition that is sensitive to thread priority.
   *
   * @see Condition
   *
   * <b>Scheduling</b>
   *
   * Threads blocked on a PriorityCondition are resumed in priority order, highest priority
   * first
   */
  class ZTHREAD_API PriorityCondition : public Waitable, private NonCopyable {

    PriorityConditionImpl* _impl;
  
  public:
  
    /**
     * @see Condition::Condition(Lockable& l)
     */
    PriorityCondition(Lockable& l);

    /**
     * @see Condition::~Condition()
     */
    ~PriorityCondition();
  
    /**
     * @see Condition::signal()
     */
    void signal();

    /**
     * @see Condition::broadcast()
     */
    void broadcast();

    /**
     * @see Condition::wait()
     */
    virtual void wait();

    /**
     * @see Condition::wait(unsigned long timeout)
     */
    virtual bool wait(unsigned long timeout);
  
  };
  
} // namespace ZThread

#endif // __ZTPRIORITYCONDITION_H__
