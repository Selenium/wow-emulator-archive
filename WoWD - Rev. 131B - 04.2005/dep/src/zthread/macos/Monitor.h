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

#ifndef __ZTMONITOR_H__
#define __ZTMONITOR_H__

#include "../Status.h"
#include "../FastLock.h"

namespace ZThread {

/**
 * @class Monitor
 * @author Eric Crahen <http://www.code-foo.com/>
 * @date <2003-07-29T11:24:58-0400>
 * @version 2.2.1
 */
class Monitor : public Status, private NonCopyable {

  //! Serialize access to external objects
  FastLock _lock;

  //! Serialize access to internal state
  FastLock _waitLock;

  //! Semaphore to control the owning thread
  MPSemaphoreID _sema;

  //! Owning thread
  MPTaskID _owner;

  //! Waiting flag, to avoid uneccessary signals
  volatile bool _waiting; 

  //! Waiting flag, to avoid too many signals
  volatile bool _pending; 

  //! State of the monitor
  volatile int _state;
  
 public:
  
  //! Create a new monitor.
  Monitor();

  //! Destroy the monitor.
  ~Monitor() throw();

  //! Acquire the external lock for this monitor. 
  inline void acquire() {
    _lock.acquire();
  }

  //! Try to acquire the external lock for this monitor. 
  inline bool tryAcquire() {
    return _lock.tryAcquire();
  }

  //! Release the external lock for this monitor. 
  inline void release() {
    _lock.release();
  }
  
  /**
   * Wait for a state change and atomically unlock the external lock.
   * Blocks for an indefinent amount of time. 
   *
   * @return INTERRUPTED if the wait was ended by a interrupt()
   *         or SIGNALED if the wait was ended by a notify()
   *
   * @post the external lock is always acquired before this function returns
   */
  inline STATE wait() {
    return wait(0);
  }

  /**
   * Wait for a state change and atomically unlock the external lock.
   * May blocks for an indefinent amount of time. 
   *
   * @param timeout - maximum time to block (milliseconds) or 0 to
   * block indefinently
   * 
   * @return INTERRUPTED if the wait was ended by a interrupt()
   *         or TIMEDOUT if the maximum wait time expired.
   *         or SIGNALED if the wait was ended by a notify()
   *
   * @post the external lock is always acquired before this function returns
   */
  STATE wait(unsigned long timeout);

  /**
   * Interrupt this monitor. If there is a thread blocked on this monitor object
   * it will be signaled and released. If there is no waiter, a flag is set and
   * the next attempt to wait() will return INTERRUPTED w/o blocking.
   *
   * @return false if the thread was previously INTERRUPTED.
   */
  bool interrupt();

  /**
   * Notify this monitor. If there is a thread blocked on this monitor object
   * it will be signaled and released. If there is no waiter, a flag is set and 
   * the next attempt to wait() will return SIGNALED w/o blocking, if no other 
   * flag is set. 
   *
   * @return false if the thread was previously INTERRUPTED.
   */
  bool notify();

  /**
   * Check the state of this monitor, clearing the INTERRUPTED status if set.
   *
   * @return bool true if the monitor was INTERRUPTED.
   * @post INTERRUPTED flag cleared if the calling thread owns the monitor.
   */
  bool isInterrupted();

  /**
   * Mark the Status CANCELED, and INTERRUPT the montor.
   *
   * @see interrupt()
   */
  bool cancel();

  /**
   * Test the CANCELED Status, clearing the INTERRUPTED status if set.
   *
   * @return bool
   */
  bool isCanceled();

};

};

#endif
