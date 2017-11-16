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

#ifndef __ZTLOCKABLE_H__
#define __ZTLOCKABLE_H__

#include "zthread/Exceptions.h"

namespace ZThread { 

  /**
   * @class Lockable
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-16T10:33:32-0400>
   * @version 2.3.0
   *
   * The Lockable interface defines a common method of adding general <i>acquire-release</i> 
   * semantics to an object. An <i>acquire-release</i> protocol does not necessarily imply 
   * exclusive access. 
   */
  class Lockable {
  public:  
  
    //! Destroy a Lockable object.
    virtual ~Lockable() {}

    /** 
     * Acquire the Lockable object. 
     *
     * This method may or may not block the caller for an indefinite amount
     * of time. Those details are defined by specializations of this class.
     *
     * @exception Interrupted_Exception thrown if the calling thread is interrupted before
     *            the operation completes.
     *
     * @post The Lockable is acquired only if no exception was thrown. 
     */
    virtual void acquire() = 0;

    /** 
     * Attempt to acquire the Lockable object. 
     *
     * This method may or may not block the caller for a definite amount
     * of time. Those details are defined by specializations of this class;
     * however, this method includes a timeout value that can be used to 
     * limit the maximum amount of time that a specialization <i>could</i> block. 
     *
     * @param timeout - maximum amount of time (milliseconds) this method could block
     *
     * @return 
     *   - <em>true</em>  if the operation completes and the Lockable is acquired before 
     *     the timeout expires. 
     *   - <em>false</em> if the operation times out before the Lockable can be acquired.
     * 
     * @exception Interrupted_Exception thrown if the calling thread is interrupted before
     *            the operation completes.
     *
     * @post The Lockable is acquired only if no exception was thrown. 
     */
    virtual bool tryAcquire(unsigned long timeout) = 0;
  
    /** 
     * Release the Lockable object.
     *
     * This method may or may not block the caller for an indefinite amount
     * of time. Those details are defined by specializations of this class.
     *
     * @post The Lockable is released only if no exception was thrown. 
     */    
    virtual void release() = 0;

  };


} // namespace ZThread

#endif // __ZTLOCKABLE_H__
