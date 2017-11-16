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

#ifndef __ZTREADWRITELOCK_H__
#define __ZTREADWRITELOCK_H__

#include "zthread/Lockable.h"
#include "zthread/NonCopyable.h"

namespace ZThread {
  
  /**
   * @class ReadWriteLock
   * 
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-16T10:17:31-0400>
   * @version 2.2.7
   *
   * A ReadWriteLock provides a set of coordinated Lockable objects that can be used to
   * guard an object; One for read-only access, and another for read-write access.
   *
   * @see BiasedReadWriteLock
   * @see FairReadWriteLock
   */  
  class ReadWriteLock : public NonCopyable {
  public:

    /**
     * Create a ReadWriteLock
     *
     * @exception Initialization_Exception thrown if resources could not be 
     *            allocated for this object.
     */
    ReadWriteLock() {}
  
    //! Destroy this ReadWriteLock
    virtual ~ReadWriteLock() {} 
  
    /**
     * Get a reference to the read-only Lockable.
     *
     * @return <em>Lockable&</em> reference to a Lockable that provides read-only
     *         access.
     */
    virtual Lockable& getReadLock() = 0;

    /**
     * Get a reference to the read-write Lockable.
     *
     * @return <em>Lockable&</em> reference to a Lockable that provides read-write
     *         access.
     */
    virtual Lockable& getWriteLock() = 0;

      
  }; /* ReadWriteLock */


}; // __ZTREADWRITELOCK_H__

#endif
