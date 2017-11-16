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

#ifndef __ZTPRIORITYMUTEX_H__
#define __ZTPRIORITYMUTEX_H__

#include "zthread/Lockable.h"
#include "zthread/NonCopyable.h"

namespace ZThread { 
  
  class PriorityMutexImpl;

  /**
   * @class PriorityMutex
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-16T17:35:46-0400>
   * @version 2.2.1
   *
   * A PriorityMutex is similar to a Mutex, with exception that a PriorityMutex 
   * has a difference scheduling policy. It is a non-reentrant, priority sensitive 
   * MUTual EXclusion Lockable object. 
   *
   * @see Mutex
   *
   * <b>Scheduling</b>
   *
   * Threads competing to acquire() a Mutex are granted access in order of priority. Threads
   * with a higher priority will be given access first.
   */
  class ZTHREAD_API PriorityMutex : public Lockable, private NonCopyable {
  
    PriorityMutexImpl* _impl;
  
  public:

    /**
     * @see Mutex::Mutex()
     */
    PriorityMutex();

    /**
     * @see Mutex::~Mutex()
     */
    virtual ~PriorityMutex();
  
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

#endif // __ZTPRIORITYMUTEX_H__
