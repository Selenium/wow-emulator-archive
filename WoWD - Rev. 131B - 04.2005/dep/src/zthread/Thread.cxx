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

#include "zthread/Runnable.h"
#include "zthread/Thread.h"
#include "ThreadImpl.h"

namespace ZThread {


  Thread::Thread() 
    : _impl( ThreadImpl::current() ) { 

    // ThreadImpl's start out life with a reference count 
    // of one, and the they are added to the ThreadQueue.
    _impl->addReference();
    
  }

  Thread::Thread(const Task& task, bool autoCancel)
    : _impl( new ThreadImpl(task, autoCancel) ) { 
    
    _impl->addReference();
    
  }

  bool Thread::operator==(const Thread& t) const {
    return (t._impl == _impl);
  }

  Thread::~Thread() {

    _impl->delReference();

  }

  void Thread::wait() {
    _impl->join(0);
  }

  bool Thread::wait(unsigned long timeout) {

    return _impl->join(timeout == 0 ? 1 : timeout);

  }

  bool Thread::interrupted() {

    return ThreadImpl::current()->isInterrupted();

  }


  bool Thread::canceled() {

    return ThreadImpl::current()->isCanceled();

  }

  void Thread::setPriority(Priority n) {

    _impl->setPriority(n);

  }


  Priority Thread::getPriority() {

    return _impl->getPriority();

  }

  bool Thread::interrupt() {

    return _impl->interrupt();

  }
  
  void Thread::cancel() {

    if(ThreadImpl::current() == _impl)
      throw InvalidOp_Exception();

    _impl->cancel();

  } 

  bool Thread::isCanceled() {

    return _impl->isCanceled();

  }


  void Thread::sleep(unsigned long ms) {

    ThreadImpl::sleep(ms);

  }


  void Thread::yield() {

    ThreadImpl::yield();

  }

} // namespace ZThread 
