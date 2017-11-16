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

#include "zthread/PriorityInheritanceMutex.h"
#include "MutexImpl.h"
#include "ThreadOps.h"


namespace ZThread {

  class InheritPriorityBehavior : public NullBehavior {
  
    ThreadImpl* owner;
    Priority p;

  protected:

    // Temporarily raise the effective priority of the owner 
    inline void waiterArrived(ThreadImpl* impl) {  
    
      Priority q = impl->getPriority();
      if((int)q > (int)p) {

        ThreadOps::setPriority(impl, p);
        p = q;
      
      }

    }


    // Note the owners priority
    inline void ownerAcquired(ThreadImpl* impl) {  

      p = impl->getPriority();
      owner = impl;

    }

    // Restore its original priority
    inline void ownerReleased(ThreadImpl* impl) {  

      if(p > owner->getPriority())
        ThreadOps::setPriority(impl, impl->getPriority());

    }

  };

  class PriorityInheritanceMutexImpl : 
    public MutexImpl<priority_list, InheritPriorityBehavior> { };

  PriorityInheritanceMutex::PriorityInheritanceMutex() {
  
    _impl = new PriorityInheritanceMutexImpl();
  
  }

  PriorityInheritanceMutex::~PriorityInheritanceMutex() {

    if(_impl != 0) 
      delete _impl;

  }

  // P
  void PriorityInheritanceMutex::acquire() {

    _impl->acquire(); 

  }


  // P
  bool PriorityInheritanceMutex::tryAcquire(unsigned long ms) {

    return _impl->tryAcquire(ms); 

  }

  // V
  void PriorityInheritanceMutex::release() {

    _impl->release(); 

  }


} // namespace ZThread

