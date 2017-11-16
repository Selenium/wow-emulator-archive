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

#include "Monitor.h"

#ifdef HAVE_CONFIG_H
#include "config.h"
#endif

using namespace ZThread;

Monitor::Monitor() : _owner(0), _waiting(false) {
  
  _handle = ::CreateEvent(0, TRUE, FALSE, 0);  
  if(_handle == NULL) {
    assert(0);
  }

}
 
Monitor::~Monitor() {
  
  assert(!_waiting);

  ::CloseHandle(_handle);  

}

Monitor::STATE Monitor::wait(unsigned long ms) {
  
  // Update the owner on first use. The owner will not change, each
  // thread waits only on a single Monitor and a Monitor is never
  // shared
  if(_owner == 0)
    _owner = ::GetCurrentThreadId();

  STATE state; //(INVALID);
  
  // Serialize access to the state of the Monitor
  // and test the state to determine if a wait is needed.
  _waitLock.acquire();

  if(pending(ANYTHING)) {
    
    // Return without waiting when possible
    state = next();

    _waitLock.release();
    return state;

  }
  // Unlock the external lock if a wait() is probably needed. 
  // Access to the state is still serial.
  _lock.release();

  // Wait for a transition in the state that is of interest, this
  // allows waits to exclude certain flags (e.g. INTERRUPTED) 
  // for a single wait() w/o actually discarding those flags -
  // they will remain set until a wait interested in those flags
  // occurs.
  //  if(!currentState(interest)) {

  // Wait, ignoring signals
  _waiting = true;

  // Block until the event is set.  
  _waitLock.release();

  // The event is manual reset so this lack of atmoicity will not
  // be an issue

  DWORD dwResult = 
    ::WaitForSingleObject(_handle, ((ms == 0) ? INFINITE : (DWORD)ms));

  // Reacquire serialized access to the state
  _waitLock.acquire();

  // Awaken only when the event is set or the timeout expired
  assert(dwResult == WAIT_OBJECT_0 || dwResult == WAIT_TIMEOUT);

  if(dwResult == WAIT_TIMEOUT)
    push(TIMEDOUT);
  
  // Get the next available STATE
  state = next();  
  _waiting = false;  

  ::ResetEvent(_handle);

  // Acquire the internal lock & release the external lock
  _waitLock.release();
    
  // Reaquire the external lock, keep from deadlocking threads calling 
  // notify(), interrupt(), etc.
  _lock.acquire();
  
  return state;

}


bool Monitor::interrupt() {

  // Serialize access to the state
  _waitLock.acquire();
  
  bool wasInterruptable = !pending(INTERRUPTED);
  bool hadWaiter = _waiting;
 
  if(wasInterruptable) {
 
    // Update the state & wake the waiter if there is one
    push(INTERRUPTED);

    wasInterruptable = false;

    if(hadWaiter && !masked(Monitor::INTERRUPTED)) {

      // Blocked on a synchronization object
      if(::SetEvent(_handle) == FALSE) {
        assert(0);
      }

    } else 
      wasInterruptable = !(_owner == ::GetCurrentThreadId());
            
  }

  _waitLock.release();

  // Only returns true when an interrupted thread is not currently blocked
  return wasInterruptable;

}

bool Monitor::isInterrupted() {

  // Serialize access to the state
  _waitLock.acquire();

  bool wasInterrupted = pending(INTERRUPTED);
  clear(INTERRUPTED);
    
  _waitLock.release();

  return wasInterrupted;

}


bool Monitor::notify() {

  // Serialize access to the state
  _waitLock.acquire();

  bool wasNotifyable = !pending(INTERRUPTED);
 
  if(wasNotifyable) {
  
    // Set the flag and wake the waiter if there
    // is one
    push(SIGNALED);
    
    // If there is a waiter then send the signal.
    if(_waiting) 
      if(::SetEvent(_handle) == FALSE) {
        assert(0);
      }

  }

  _waitLock.release();

  return wasNotifyable;

}


bool Monitor::cancel() {

  // Serialize access to the state
  _waitLock.acquire();

  bool wasInterrupted = !pending(INTERRUPTED);
  bool hadWaiter = _waiting;
 
  push(CANCELED);

  if(wasInterrupted) {
 
    // Update the state & wake the waiter if there is one
    push(INTERRUPTED);
    
    // If there is a waiter then send the signal.
    if(hadWaiter && !masked(Monitor::INTERRUPTED)) 
      if(::SetEvent(_handle) == FALSE) {
        assert(0);
      }
    
  }

  _waitLock.release();

  return wasInterrupted;

}

bool Monitor::isCanceled() {

  // Serialize access to the state
  _waitLock.acquire();

  bool wasCanceled = examine(CANCELED);
    
  if(_owner == ::GetCurrentThreadId())
    clear(INTERRUPTED);

  _waitLock.release();

  return wasCanceled;

}

