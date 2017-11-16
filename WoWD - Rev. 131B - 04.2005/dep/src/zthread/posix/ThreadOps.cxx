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
#include "zthread/Guard.h"
#include "zthread/Runnable.h"
#include <errno.h>

#if defined(HAVE_SCHED_YIELD)
#  include <sched.h>
#endif

namespace ZThread {

const ThreadOps ThreadOps::INVALID(0); 

bool ThreadOps::join(ThreadOps* ops) {

  assert(ops);
  assert(ops->_tid != 0);

  int err = 0;

  do {

    err = pthread_join(ops->_tid, NULL);

  } while(err == EINTR);

  return err == 0;

}

bool ThreadOps::yield() {

  bool result = false;

#if defined(HAVE_SCHED_YIELD)
  result = sched_yield() == 0;
#endif
  
  return result;

}

bool ThreadOps::setPriority(ThreadOps* impl, Priority p) {

  assert(impl);

  bool result = true;
  
#if !defined(ZTHREAD_DISABLE_PRIORITY)
  
  struct sched_param param;
  
  switch(p) {
    case Low:
      param.sched_priority = 0;
      break;
    case High:
      param.sched_priority = 10;
      break;
    case Medium:
    default:
      param.sched_priority = 5;
  }
  
  result = pthread_setschedparam(impl->_tid, SCHED_OTHER, &param) == 0;

#endif

  return result;

}

bool ThreadOps::getPriority(ThreadOps* impl, Priority& p) {

  assert(impl);

  bool result = true;
  
#if !defined(ZTHREAD_DISABLE_PRIORITY)

  struct sched_param param;
  int policy = SCHED_OTHER;
  
  if(result = (pthread_getschedparam(impl->_tid, &policy, &param) == 0)) {
    
    // Convert to one of the PRIORITY values
    if(param.sched_priority < 10)
      p = Low;
    else if(param.sched_priority == 10)
      p = Medium;
    else
      p = High;
    
  }
  
#endif

  return result;

}


bool ThreadOps::spawn(Runnable* task) {
  return pthread_create(&_tid, 0, _dispatch, task) == 0;
}



extern "C" void *_dispatch(void *arg) {

  Runnable* task = reinterpret_cast<Runnable*>(arg);
  assert(task);
  
  // Run the task from the correct context
  task->run();
  
  // Exit the thread
  pthread_exit((void**)0);
  return (void*)0;
  
}
  
} // namespace ZThread


