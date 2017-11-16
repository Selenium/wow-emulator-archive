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

#ifndef __ZTCLASSLOCKABLE_H__
#define __ZTCLASSLOCKABLE_H__

#include "zthread/CountedPtr.h"
#include "zthread/Mutex.h"

namespace ZThread { 

  /**
   * @class ClassLockable
   *
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-16T23:37:38-0400>
   * @version 2.3.0
   *
   *
   */
  template <typename ClassType, class LockType = Mutex>
    class ClassLockable : public Lockable {

    static CountedPtr<LockType> _instance;
    CountedPtr<LockType> _lock;

    public:  
  
    //! Create a ClassLockable
    ClassLockable() 
      : _lock(_instance) {} 
  
    //! acquire() the ClassLockable
    virtual void acquire() { 
      _lock->acquire(); 
    }

    //! tryAcquire() the ClassLockable
    virtual bool tryAcquire(unsigned long timeout) {
      return _lock->tryAcquire(timeout); 
    }

    //! release() the ClassLockable
    virtual void release() {
      _lock->release(); 
    }

  };

  template <typename ClassType, class LockType>
    CountedPtr<LockType> ClassLockable<ClassType, LockType>::_instance(new LockType);

} // namespace ZThread

#endif // __ZTCLASSLOCKABLE_H__
