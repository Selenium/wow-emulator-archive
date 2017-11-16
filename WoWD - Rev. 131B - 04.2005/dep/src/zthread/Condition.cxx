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

#include "zthread/Condition.h"
#include "ConditionImpl.h"

namespace ZThread {

  class FifoConditionImpl : public ConditionImpl<fifo_list> {
  public:
    FifoConditionImpl(Lockable& l) : ConditionImpl<fifo_list>(l) {}

  };

  Condition::Condition(Lockable& lock) {
  
    _impl = new FifoConditionImpl(lock);

  }


  Condition::~Condition() {
  
    if(_impl != 0)
      delete _impl;

  }



  void Condition::wait() {

    _impl->wait();

  }



  bool Condition::wait(unsigned long ms) {

    return _impl->wait(ms);

  }



  void Condition::signal() {
  
    _impl->signal();

  }


  void Condition::broadcast() {

    _impl->broadcast();

  }

} // namespace ZThread

