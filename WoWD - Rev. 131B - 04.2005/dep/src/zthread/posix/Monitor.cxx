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
#include "../Debug.h"
#include "../TimeStrategy.h"

#include <errno.h>
#include <assert.h>
#include <signal.h>

namespace ZThread {

Monitor::Monitor() : _owner(0), _waiting(false) {
  
  pthread_cond_init(&_waitCond, 0);
  pthread_mutex_init(&_waitLock, 0);

}
 
Monitor::~Monitor() {
  
  assert(!_waiting);

  pthread_cond_destroy(&_waitCond);
  pthread_mutex_destroy(&_waitLock);
  
}

Monitor::STATE Monitor::wait(unsigned long ms) {

  // Update the owner on first use. The owner will not change, each
  // thread waits only on a single Monitor and a Monitor is never
  // shared
  if(_owner == 0)
    _owner = pthread_self();

  STATE state(INVALID);
  
  // Serialize access to the state of the Monitor
  // and test the state to determine if a wait is needed.
  
  pthread_mutex_lock(&_waitLock);
  
  if(pending(ANYTHING)) {
    
    // Return without waiting when possible
    state = next();

    pthread_mutex_unlock(&_waitLock);
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
  int status = 0;
  
  if(ms == 0) { // Wait forever 
    
    do { // ignore signals unless the state is interesting  
      status = pthread_cond_wait(&_waitCond, &_waitLock);
    } while(status == EINTR && !pending(ANYTHING));
    
    // Akwaken only when a state is pending
    assert(status == 0);
    
  } else {
    
    // Find the target time
    TimeStrategy t; 

    ms += t.milliseconds();

    unsigned long s = t.seconds() + (ms / 1000);
    ms %= 1000;

    // Convert to a timespec
    struct ::timespec timeout;   
    
    timeout.tv_sec = s; 
    timeout.tv_nsec = ms*1000000;
    
    // Wait ignoring signals until the state is interesting    
    do { 
      
      // When a timeout occurs, update the state to reflect that.
      status = pthread_cond_timedwait(&_waitCond, &_waitLock, &timeout);
      
    } while(status == EINTR && !pending(ANYTHING));
 
    // Akwaken only when a state is pending or when the timeout expired
    assert(status == 0 || status == ETIMEDOUT);
   
    if(status == ETIMEDOUT)
      push(TIMEDOUT);

  }
  
  // Get the next available STATE
  state = next();  
  _waiting = false;  
    
  pthread_mutex_unlock(&_waitLock);
    
  // Reaquire the external lock, keep from deadlocking threads calling 
  // notify(), interrupt(), etc.

  _lock.acquire();

  return state;

}


bool Monitor::interrupt() {

  // Serialize access to the state
  pthread_mutex_lock(&_waitLock);
  
  bool wasInterruptable = !pending(INTERRUPTED);
  bool hadWaiter = _waiting;
 
  if(wasInterruptable) {
 
    // Update the state & wake the waiter if there is one
    push(INTERRUPTED);

    wasInterruptable = false;
    
    if(hadWaiter && !masked(Monitor::INTERRUPTED))
      pthread_cond_signal(&_waitCond);
    else
      wasInterruptable = !pthread_equal(_owner, pthread_self());

  }

  pthread_mutex_unlock(&_waitLock);

  // Only returns true when an interrupted thread is not currently blocked
  return wasInterruptable;

}

bool Monitor::isInterrupted() {

  // Serialize access to the state
  pthread_mutex_lock(&_waitLock);

  bool wasInterrupted = pending(INTERRUPTED);

  clear(INTERRUPTED);
    
  pthread_mutex_unlock(&_waitLock);

  return wasInterrupted;

}

bool Monitor::isCanceled() {

  // Serialize access to the state
  pthread_mutex_lock(&_waitLock);

  bool wasCanceled = examine(CANCELED);
    
  if(pthread_equal(_owner, pthread_self()))
    clear(INTERRUPTED);

  pthread_mutex_unlock(&_waitLock);

  return wasCanceled;

}

bool Monitor::cancel() {

  // Serialize access to the state
  pthread_mutex_lock(&_waitLock);

  bool wasInterrupted = !pending(INTERRUPTED);
  bool hadWaiter = _waiting;
 
  push(CANCELED);

  if(wasInterrupted) {
 
    // Update the state & wake the waiter if there is one
    push(INTERRUPTED);
    
    if(hadWaiter && !masked(Monitor::INTERRUPTED))
      pthread_cond_signal(&_waitCond);
    
  }

  pthread_mutex_unlock(&_waitLock);

  return wasInterrupted;

}

bool Monitor::notify() {

  // Serialize access to the state
  pthread_mutex_lock(&_waitLock);

  bool wasNotifyable = !pending(INTERRUPTED);
 
  if(wasNotifyable) {
  
    // Set the flag and wake the waiter if there
    // is one
    push(SIGNALED);
    
    if(_waiting) 
      pthread_cond_signal(&_waitCond);
    
  }

  pthread_mutex_unlock(&_waitLock);

  return wasNotifyable;

}

} // namespace ZThread

