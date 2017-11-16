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

#ifndef __ZTINTRUSIVEPTR_H__
#define __ZTINTRUSIVEPTR_H__

#include "zthread/Guard.h"
#include <cstdlib>

namespace ZThread {

/**
 * @class IntrusivePtr
 * @author Eric Crahen <http://www.code-foo.com>
 * @date <2003-07-16T17:54:23-0400>
 * @version 2.2.0
 *
 * This template creates an intrusively reference counted object
 * an IntrusivePtr starts out with a 1 count, which is updated as references are 
 * added and removed. When the reference count drops to 0, the 
 * IntrusivePtr will delete itself. 
 */
template <typename T, class LockType>
class IntrusivePtr : NonCopyable {
  
  //! Intrusive reference count
  size_t _count;
  
  //! Synchornization object
  LockType _lock;

public:

  /**
   * Create an IntrusivePtr with a count.
   */
  IntrusivePtr(size_t InitialCount=1) : _count(InitialCount) { }
  
  /**
   * Destroy an IntrusivePtr
   */
  virtual ~IntrusivePtr() {}

  /**
   * Add a reference to this object, it will take one more
   * call to delReference() for it to be deleted.
   */
  void addReference() {

    Guard<LockType, LockedScope> g(_lock);
    _count++;  

  }

  /**
   * Remove a reference from this object, if the reference count
   * drops to 0 as a result, the object deletes itself.
   */
  void delReference() {

    bool result = false;

    {

      Guard<LockType, LockedScope> g(_lock);
      result = (--_count == 0);

    }

    if(result)
      delete this;

  }

};


};

#endif
