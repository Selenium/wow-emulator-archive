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

#include "Debug.h"

#include "RecursiveMutexImpl.h"
#include "ThreadImpl.h"

#include "zthread/Guard.h"

#include <assert.h>
#include <errno.h>
#include <algorithm>

namespace ZThread {

  /**
   * Create a new RecursiveMutexImpl
   *
   * @exception Initialization_Exception thrown if resources could not be
   * properly allocated
   */
  RecursiveMutexImpl::RecursiveMutexImpl() 
    : _owner(0), _count(0) {
 
  }

  /**
   * Destroy this RecursiveMutexImpl and release its resources
   */
  RecursiveMutexImpl::~RecursiveMutexImpl() {

#ifndef NDEBUG

    // It is an error to destroy a mutex that has not been released
    if(_owner != 0) { 

      ZTDEBUG("** You are destroying a mutex which was never released. **\n");
      assert(0); // Destroyed mutex while in use

    }

    if(_waiters.size() > 0) { 

      ZTDEBUG("** You are destroying a mutex which is blocking %d threads. **\n", _waiters.size());
      assert(0); // Destroyed mutex while in use

    }

#endif

  }


  void RecursiveMutexImpl::acquire() {

    // Get the monitor for the current thread
    Monitor& m = ThreadImpl::current()->getMonitor();
    Monitor::STATE state;

    Guard<FastLock> g1(_lock);
      
    // If there is an entry count and the current thread is 
    // the owner, increment the count and continue.
    if(_owner == &m) 
      _count++;

    else {

      // Acquire the lock if it is free and there are no waiting threads
      if(_owner == 0 && _waiters.empty()) {

        assert(_count == 0);

        _owner = &m;    
        _count++;

      } else { // Otherwise, wait()
        
        _waiters.push_back(&m);

        m.acquire();

        {

          Guard<FastLock, UnlockedScope> g2(g1);
          state = m.wait();

        }

        m.release();
        
        // Remove from waiter list, regarless of weather release() is called or
        // not. The monitor is sticky, so its possible a state 'stuck' from a
        // previous operation and will leave the wait() w/o release() having
        // been called.
        List::iterator i = std::find(_waiters.begin(), _waiters.end(), &m);
        if(i != _waiters.end())
          _waiters.erase(i);

        // If awoke due to a notify(), take ownership. 
        switch(state) {
          case Monitor::SIGNALED:
          
            assert(_owner == 0);
            assert(_count == 0);

            _owner = &m;
            _count++;
            
            break;

          case Monitor::INTERRUPTED:
            throw Interrupted_Exception();
            
          default:
            throw Synchronization_Exception();
        } 
            
      }
      
    }

  }

  bool RecursiveMutexImpl::tryAcquire(unsigned long timeout) {
  
    // Get the monitor for the current thread
    Monitor& m = ThreadImpl::current()->getMonitor();

    Guard<FastLock> g1(_lock);
  
    // If there is an entry count and the current thread is 
    // the owner, increment the count and continue.
    if(_owner == &m)
      _count++;

    else {

      // Acquire the lock if it is free and there are no waiting threads
      if(_owner == 0 && _waiters.empty()) {

        assert(_count == 0);

        _owner = &m;
        _count++;

      } else { // Otherwise, wait()

        _waiters.push_back(&m);

        Monitor::STATE state = Monitor::TIMEDOUT;

        // Don't bother waiting if the timeout is 0
        if(timeout) {

          m.acquire();

          {
          
            Guard<FastLock, UnlockedScope> g2(g1);
            state = m.wait(timeout);
          
          }

          m.release();
        
        }

        // Remove from waiter list, regarless of weather release() is called or
        // not. The monitor is sticky, so its possible a state 'stuck' from a
        // previous operation and will leave the wait() w/o release() having
        // been called.
        List::iterator i = std::find(_waiters.begin(), _waiters.end(), &m);
        if(i != _waiters.end())
          _waiters.erase(i);

        // If awoke due to a notify(), take ownership. 
        switch(state) {
          case Monitor::SIGNALED:

            assert(_count == 0);
            assert(_owner == 0);

            _owner = &m;
            _count++;
            
            break;

          case Monitor::INTERRUPTED:
            throw Interrupted_Exception();
          
          case Monitor::TIMEDOUT:
            return false;

          default:
            throw Synchronization_Exception();
        } 
            
      }
      
    }

    return true;

  }

  void RecursiveMutexImpl::release() {

    // Get the monitor for the current thread
    Monitor& m = ThreadImpl::current()->getMonitor();

    Guard<FastLock> g1(_lock);

    // Make sure the operation is valid
    if(!(_owner == &m))
      throw InvalidOp_Exception();

    // Update the count, if it has reached 0, wake another waiter.
    if(--_count == 0) {
    
      _owner = 0;

      // Try to find a waiter with a backoff & retry scheme
      for(;;) {

        // Go through the list, attempt to notify() a waiter.
        for(List::iterator i = _waiters.begin(); i != _waiters.end();) {
        
          // Try the monitor lock, if it cant be locked skip to the next waiter
          Monitor* n = *i;
          if(n->tryAcquire()) {
           
            // If notify() is not sucessful, it is because the wait() has already 
            // been ended (killed/interrupted/notify'd)
            bool woke = n->notify();
            n->release();
          
            // Once notify() succeeds, return
            if(woke)
              return;
          
          } else ++i;
        
        }
      
        if(_waiters.empty())
          return;

        { // Backoff and try again

          Guard<FastLock, UnlockedScope> g2(g1);
          ThreadImpl::yield();

        }

      }

    }
  
  }

} // namespace ZThread




