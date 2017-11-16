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

#ifndef __ZTATOMICCOUNT_H__
#define __ZTATOMICCOUNT_H__

#include <cstdlib>

#include "zthread/Config.h"
#include "zthread/NonCopyable.h"

namespace ZThread {

  /**
   * @class AtomicCount
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-16T09:41:55-0400> 
   * @version 2.3.0
   *
   * This class provides an interface to a small integer whose value can be
   * incremented or decremented atomically. It's designed to be as simple and
   * lightweight as possible so that it can be used cheaply to create reference
   * counts.
   */
  class ZTHREAD_API AtomicCount : public NonCopyable {
  
    void* _value;
  
  public:
  
    //! Create a new AtomicCount, initialized to a value of 1
    AtomicCount();

    //! Destroy a new AtomicCount
    ~AtomicCount();
  
    //! Postfix decrement and return the current value
    size_t operator--(int);
  
    //! Postfix increment and return the current value
    size_t operator++(int);  

    //! Prefix decrement and return the current value
    size_t operator--();
  
    //! Prefix increment and return the current value
    size_t operator++();  


  }; /* AtomicCount */

  
} // namespace ZThread

#endif // __ZTATOMICCOUNT_H__
