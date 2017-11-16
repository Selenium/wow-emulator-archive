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

#ifndef __ZTPRIORITYINHERITANCEMUTEX_H__
#define __ZTPRIORITYINHERITANCEMUTEX_H__

#include "zthread/Lockable.h"
#include "zthread/NonCopyable.h"

namespace ZThread { 
  
  class PriorityInheritanceMutexImpl;

  /**
   * @class PriorityInheritanceMutex
   *
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-16T19:37:36-0400>
   * @version 2.2.1
   *
   * A PriorityInheritanceMutex is similar to a PriorityMutex, it is a non-reentrant, 
   * priority sensitive MUTual EXclusion Lockable object. It differs only in its 
   * scheduling policy.
   *
   * @see PriorityMutex
   *
   * <b>Scheduling</b>
   *
   * Threads competing to acquire() a PriorityInheritanceMutex are granted access in 
   * order of priority. Threads with a higher priority will be given access first.
   *
   * When a higher priority thread tries to acquire() a PriorityInheritanceMutex and is 
   * about to be blocked by a lower priority thread that has already acquire()d it, the
   * lower priority thread will temporarily have its effective priority raised to that 
   * of the higher priority thread until it release()s the mutex; at which point its 
   * previous priority will be restored. 
   */
  class ZTHREAD_API PriorityInheritanceMutex : public Lockable, private NonCopyable {
  
    PriorityInheritanceMutexImpl* _impl;
  
  public:

    /**
     * @see Mutex::Mutex()
     */
    PriorityInheritanceMutex();

    /**
     * @see Mutex::~Mutex()
     */
    virtual ~PriorityInheritanceMutex();
  
    /**
     * @see Mutex::acquire()
     */
    virtual void acquire(); 

    /**
     * @see Mutex::tryAcquire(unsigned long timeout)
     */
    virtual bool tryAcquire(unsigned long timeout); 
  
    /**
     * @see Mutex::release()
     */
    virtual void release();
  
  }; 


} // namespace ZThread

#endif // __ZTPRIORITYINHERITANCEMUTEX_H__
