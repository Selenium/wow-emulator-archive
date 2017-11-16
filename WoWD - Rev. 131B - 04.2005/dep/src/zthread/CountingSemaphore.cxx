/*
 *  ZThreads, a platform-independant, multithreading and 
 *  synchroniation library
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

#include "zthread/CountingSemaphore.h"
#include "SemaphoreImpl.h"

using namespace ZThread;

namespace ZThread {


  CountingSemaphore::CountingSemaphore(int initialCount) {
  
    _impl = new FifoSemaphoreImpl(initialCount, 0 , false);
  
  }


  CountingSemaphore::~CountingSemaphore() {

    try {

      if(_impl != 0)
        delete _impl;

    } catch(...) { }

  }


  void CountingSemaphore::wait() {
    _impl->acquire();
  }


  bool CountingSemaphore::tryWait(unsigned long ms) {

    return _impl->tryAcquire(ms);

  }


  void CountingSemaphore::post() {

    _impl->release();

  }

  int CountingSemaphore::count() {

    return _impl->count();

  }

  void CountingSemaphore::acquire() {

    _impl->acquire();

  }

  bool CountingSemaphore::tryAcquire(unsigned long ms) {

    return _impl->tryAcquire(ms);

  }

  void CountingSemaphore::release() {

    _impl->release();

  }

} // namespace ZThread
