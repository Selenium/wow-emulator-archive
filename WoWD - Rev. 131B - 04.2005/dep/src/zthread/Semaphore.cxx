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

#include "zthread/Semaphore.h"
#include "SemaphoreImpl.h"

namespace ZThread {

  /**
   * Create a new semaphore of a given size with a given count
   *
   * @param initialCount initial count to assign this semaphore
   * @param maxCount maximum size of the semaphore count
   */
  Semaphore::Semaphore(int count, unsigned int maxCount) {
  
    _impl = new FifoSemaphoreImpl(count, maxCount, true);
  
  }

  Semaphore::~Semaphore() {

    if(_impl != 0)
      delete _impl;

  }

  void Semaphore::wait() {

    _impl->acquire();

  }


  bool Semaphore::tryWait(unsigned long ms) {

    return _impl->tryAcquire(ms);

  }

  void Semaphore::post() {

    _impl->release();

  }

  int Semaphore::count() {

    return _impl->count();

  }

  ///////////////////////////////////////////////////////////////////////////////
  // Locakable compatibility
  //

  void Semaphore::acquire() {

    _impl->acquire();

  }

  bool Semaphore::tryAcquire(unsigned long ms) {

    return _impl->tryAcquire(ms);


  }

  void Semaphore::release() {

    _impl->release();

  }

} // namespace ZThread






