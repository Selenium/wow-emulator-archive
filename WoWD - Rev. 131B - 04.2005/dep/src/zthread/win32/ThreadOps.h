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


#ifndef __ZTTHREADOPS_H__
#define __ZTTHREADOPS_H__

#include "zthread/Priority.h"
#include <windows.h>
#include <assert.h>

namespace ZThread {

class Runnable;

/**
 * @class ThreadOps
 * @author Eric Crahen <http://www.code-foo.com>
 * @date <2003-07-16T23:33:59-0400>
 * @version 2.2.8
 *
 * This class is an abstraction used to perform various operations on a 
 * native WIN32 thread.
 */
class ThreadOps {

  //! Dispatch function for native thread
  static unsigned int __stdcall _dispatch(void*);

  //! TID while the thread is executing.
  HANDLE _hThread;
  DWORD _tid;

  ThreadOps(DWORD tid) : _tid(tid) { }

 public:

  const static ThreadOps INVALID; 

  /**
   * Create a new ThreadOps to represent a native thread. 
   */  
  ThreadOps() : _tid(0), _hThread(NULL) {}


  inline bool operator==(const ThreadOps& ops) const {
    return _tid == ops._tid;
  }

  
  static ThreadOps self() {
    return ThreadOps(::GetCurrentThreadId());
  }

  /**
   * Update the native tid for this thread so it matches the current
   * thread.
   */ 
  static void activate(ThreadOps* ops) {

    assert(ops);
    assert(ops->_tid == 0);

    ops->_tid = ::GetCurrentThreadId();

  }

  /**
   * Test if this object representative of the currently executing 
   * native thread.
   *
   * @return bool true if successful
   */
  static bool isCurrent(ThreadOps* ops) {

    assert(ops);

    return ops->_tid == ::GetCurrentThreadId();

  }

  /**
   * Join a native thread.
   *
   * @return bool true if successful
   */
  static bool join(ThreadOps*);

  /**
   * Force the current native thread to yield, letting the scheduler 
   * give the CPU time to another thread.
   *
   * @return bool true if successful
   */
  static bool yield();

  /**
   * Set the priority for the native thread if supported by the 
   * system.
   *
   * @param PRIORITY requested priority
   * @return bool false if unsuccessful
   */
  static bool setPriority(ThreadOps*, Priority);

  /**
   * Set the priority for the native thread if supported by the 
   * system.
   *
   * @param Thread::PRIORITY& current priority
   * @return bool false if unsuccessful
   */
  static bool getPriority(ThreadOps*, Priority&);

protected:

  /**
   * Spawn a native thread.
   *
   * @param ThreadImpl* parent thread
   * @param ThreadImpl* child thread being started.
   * @param Runnable* task being executed.
   *
   * @return bool true if successful
   */
  bool spawn(Runnable*);


};


}

#endif
