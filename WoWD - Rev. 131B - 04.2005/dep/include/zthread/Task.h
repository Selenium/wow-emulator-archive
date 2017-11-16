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

#ifndef __ZTTASK_H__
#define __ZTTASK_H__

#include "zthread/CountedPtr.h"
#include "zthread/Runnable.h"

namespace ZThread {
  
  class ThreadImpl;
  
  /**
   * @class Task
   *
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-20T05:22:38-0400>
   * @version 2.3.0
   *
   * A Task provides a CountedPtr wrapper for Runnable objects. 
   * This wrapper enables an implicit conversion from a 
   * <i>Runnable*</i> to a <i>Task</i> adding some syntactic sugar 
   * to the interface.
   */
  class ZTHREAD_API Task : public CountedPtr<Runnable, AtomicCount> {
  public:


#if !defined(_MSC_VER) || (_MSC_VER > 1200)
      
    Task(Runnable* raw)
      : CountedPtr<Runnable, AtomicCount>(raw) { } 

#endif
    
    template <typename U>
      Task(U* raw)
      : CountedPtr<Runnable, AtomicCount>(raw) { } 
    
    Task(const CountedPtr<Runnable, AtomicCount>& ptr) 
      : CountedPtr<Runnable, AtomicCount>(ptr) { } 
    
    template <typename U, typename V>
      Task(const CountedPtr<U, V>& ptr) 
      : CountedPtr<Runnable, AtomicCount>(ptr) { } 
    
    void operator()() {
      (*this)->run();
    }
    
  }; /* Task */
  
} // namespace ZThread

#endif // __ZTTASK_H__



