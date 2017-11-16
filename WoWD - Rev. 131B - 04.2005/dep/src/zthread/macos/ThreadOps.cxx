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

#include "ThreadOps.h"
#include "zthread/Exceptions.h"
#include "zthread/Runnable.h"

namespace ZThread {

const ThreadOps ThreadOps::INVALID(0); 

ThreadOps::ThreadOps()  : _queue(0), _tid(0) { 
  
  if(MPCreateQueue(&_queue) != noErr)
    throw Initialization_Exception();

}

ThreadOps::~ThreadOps() throw() {
  
  if(_queue != 0) {

    OSStatus status = MPDeleteQueue(_queue);
    if(status != noErr) 
      assert(0);

  }
    
}

bool ThreadOps::join(ThreadOps* ops) {

  assert(ops);
  assert(ops->_tid != 0);

  OSStatus status = MPWaitOnQueue(ops->_queue, NULL, NULL, NULL, kDurationForever);

  return status == noErr;
 
}

bool ThreadOps::yield() {

  MPYield();
  return true;

}

bool ThreadOps::setPriority(ThreadOps* impl, Priority p) {
  return true;
}

bool ThreadOps::getPriority(ThreadOps* impl, Priority& p) {
  return true;
}


bool ThreadOps::spawn(Runnable* task) {

  OSStatus status =
    MPCreateTask(&_dispatch, task, 0UL, _queue, NULL, NULL, 0UL, &_tid);

  return status == noErr;

}

OSStatus ThreadOps::_dispatch(void *arg) {

  Runnable* task = reinterpret_cast<Runnable*>(arg);
  assert(task);

  // Run the task from the correct context
  task->run();
  
  // Exit the thread
  MPExit(noErr);
  return noErr;

}
  
} // namespace ZThread


