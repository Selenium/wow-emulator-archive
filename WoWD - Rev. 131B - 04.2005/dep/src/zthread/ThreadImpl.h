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


#ifndef __ZTTHREADIMPL_H__
#define __ZTTHREADIMPL_H__

#include "zthread/ThreadLocalImpl.h"
#include "zthread/Thread.h"
#include "zthread/Exceptions.h"
#include "IntrusivePtr.h"

#include "Monitor.h"
#include "TSS.h"
#include "ThreadOps.h"
#include "State.h"

#include <map>
#include <deque>

namespace ZThread {

/**
 * @class ThreadImpl
 * @author Eric Crahen <http://www.code-foo.com>
 * @date <2003-07-27T13:39:03-0400>
 * @version 2.3.0
 */
class ThreadImpl : public IntrusivePtr<ThreadImpl, FastLock>, public ThreadOps {

  typedef std::deque<ThreadImpl*> List;

  //! TSS to store implementation to current thread mapping.
  static TSS<ThreadImpl*> _threadMap;

  //! The Monitor for controlling this thread
  Monitor _monitor;
  
  //! Current state for the thread
  State _state;

  //! Joining threads
  List _joiners;

 public:
  
  typedef std::map<const ThreadLocalImpl*, ThreadLocalImpl::ValuePtr > ThreadLocalMap;

 private:
  
  ThreadLocalMap _tls;

  //! Cached thread priority
  Priority _priority;

  //! Request cancel() when main() goes out of scope
  bool _autoCancel;
  
  void start(const Task& task);

 public:

  ThreadImpl();

  ThreadImpl(const Task&, bool);

  ~ThreadImpl();  

  Monitor& getMonitor();

  void cancel(bool autoCancel = false);

  bool interrupt();

  bool isInterrupted();

  bool isCanceled();

  Priority getPriority() const;

  //  ThreadLocalMap& getThreadLocalMap();
  ThreadLocalMap& getThreadLocalMap() { return _tls; }

  bool join(unsigned long); 
  
  void setPriority(Priority);

  bool isActive();

  bool isReference();

  static void sleep(unsigned long); 

  static void yield();
  
  static ThreadImpl* current();

  static void dispatch(ThreadImpl*, ThreadImpl*, Task);

};

} // namespace ZThread 

#endif // __ZTTHREADIMPL_H__
