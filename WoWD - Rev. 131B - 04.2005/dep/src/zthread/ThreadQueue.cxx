/*
 *  ZThreads, a platform-independent, multi threading and 
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

#include "DeferredInterruptionScope.h"
#include "Debug.h"
#include "ThreadImpl.h"
#include "ThreadQueue.h"

#include <algorithm>
#include <deque>

namespace ZThread {
  
  ThreadQueue::ThreadQueue() 
    : _waiter(0) { 

    ZTDEBUG("ThreadQueue created\n");

  }

  ThreadQueue::~ThreadQueue() {

    ZTDEBUG("ThreadQueue waiting on remaining threads...\n");

    // Ensure the current thread is mapped.
    ThreadImpl* impl = ThreadImpl::current();

    bool threadsWaiting = false;
    bool waitRequired = false;

    {

      TaskList shutdownTasks;

      { // Check the queue to for pending user threads
        
        Guard<FastLock> g(_lock);
        
        waitRequired = (_waiter != (ThreadImpl*)1);
        _waiter = impl;
        
        threadsWaiting = !_userThreads.empty() || !_pendingThreads.empty();
        
        //ZTDEBUG("Wait required:   %d\n", waitRequired);
        //ZTDEBUG("Threads waiting: %d\n", threadsWaiting);
        
        // Auto-cancel any active threads at the time main() goes out of scope
        // "force" a gentle exit from the executing tasks; eventually the user- 
        // threads will transition into pending-threads
        pollUserThreads();
        
        // Remove all the tasks about to be run from the task list so an indication
        // can be given to threads calling removeShutdownTask() too late.
        std::remove_copy(_shutdownTasks.begin(), 
                         _shutdownTasks.end(), 
                         std::back_inserter(shutdownTasks), 
                         Task((Runnable*)0)); 
        
        //ZTDEBUG("Threads waiting: %d\n", threadsWaiting);
        
      }

      // Execute the shutdown tasks
      for(TaskList::iterator i = shutdownTasks.begin(); i != shutdownTasks.end(); ++i) {
        try { 
          (*i)->run();
        } catch(...) { }
      }

    }

    // Wait for all the users threads to get into the appropriate state
    if(threadsWaiting) {


      Monitor& m = _waiter->getMonitor();
      
      // Defer interruption while this thread waits for a signal from
      // the last pending user thread
      Guard<Monitor, CompoundScope<DeferredInterruptionScope, LockedScope> > g(m);
      //ZTDEBUG("Threads waiting: %d %d\n", _userThreads.size(), _pendingThreads.size());

      // Avoid race-condition where the last threads are done with thier tasks, but
      // only begin the final part of the clean up phase after this destructor begins 
      // to run. Takes advantage of the fact that if all remaining threads have transitioned
      // into a pending state by the time execution reaches this point, then there is no
      // need to wait.
      waitRequired = waitRequired && !(_userThreads.empty() && !_pendingThreads.empty());

      // Reference threads can't be interrupted or otherwise 
      // manipulated. The only signal this monitor will recieve
      // at this point will be from the last pending thread.
      if(waitRequired && m.wait() != Monitor::SIGNALED) {
        assert(0);
      }

      // Join those pending threads
      pollPendingThreads();
      
    }
      
    // Clean up the reference threads
    pollReferenceThreads(); 
    
    ZTDEBUG("ThreadQueue destroyed\n");

  }
  

  void ThreadQueue::insertPendingThread(ThreadImpl* impl) {
    ZTDEBUG("insertPendingThread()\n");
    Guard<FastLock> g(_lock);

    // Move from the user-thread list to the pending-thread list
    ThreadList::iterator i = std::find(_userThreads.begin(), _userThreads.end(), impl);
    if(i != _userThreads.end())
      _userThreads.erase(i);

    _pendingThreads.push_back(impl);
    
    // Wake the main thread,if its waiting, when the last pending-thread becomes available;
    // Otherwise, take note that no wait for pending threads to finish is needed
    if(_userThreads.empty())
      if(_waiter && _waiter != (ThreadImpl*)1)
        _waiter->getMonitor().notify();
      else
        _waiter = (ThreadImpl*)!_waiter;

    ZTDEBUG("1 pending-thread added.\n");

  }

  void ThreadQueue::insertReferenceThread(ThreadImpl* impl) {

    Guard<FastLock> g(_lock);
    _referenceThreads.push_back(impl);

    ZTDEBUG("1 reference-thread added.\n");

  }

  void ThreadQueue::insertUserThread(ThreadImpl* impl) {

    Guard<FastLock> g(_lock);
    _userThreads.push_back(impl);

    // Reclaim pending-threads
    pollPendingThreads();

    // Auto-cancel threads that are started when main() is out of scope
    if(_waiter)
      impl->cancel(true);

    ZTDEBUG("1 user-thread added.\n");
    
  }


  void ThreadQueue::pollPendingThreads() {

    ZTDEBUG("pollPendingThreads()\n");

    for(ThreadList::iterator i = _pendingThreads.begin(); i != _pendingThreads.end();) {

      ThreadImpl* impl = (ThreadImpl*)*i;
      ThreadOps::join(impl);
      
      impl->delReference();
           
      i = _pendingThreads.erase(i);

      ZTDEBUG("1 pending-thread reclaimed.\n");

    }

  }

  void ThreadQueue::pollReferenceThreads() {

    ZTDEBUG("pollReferenceThreads()\n");

    for(ThreadList::iterator i = _referenceThreads.begin(); i != _referenceThreads.end(); ++i) {
      
      ThreadImpl* impl = (ThreadImpl*)*i;
      impl->delReference();
      
      ZTDEBUG("1 reference-thread reclaimed.\n");

    }
    
  }

  void ThreadQueue::pollUserThreads() {

    ZTDEBUG("pollUserThreads()\n");

    for(ThreadList::iterator i = _userThreads.begin(); i != _userThreads.end(); ++i) {

      ThreadImpl* impl = *i;
      impl->cancel(true);

      ZTDEBUG("1 user-thread reclaimed.\n");
      
    }

  }
  
  void ThreadQueue::insertShutdownTask(Task& task) {

    bool hasWaiter = false;

    {

      Guard<FastLock> g(_lock);
    
      // Execute later when the ThreadQueue is destroyed  
      if( !(hasWaiter = (_waiter != 0)) ) {

        _shutdownTasks.push_back(task);
        //ZTDEBUG("1 shutdown task added. %d\n", _shutdownTasks.size());
        
      }

    }
    
    // Execute immediately if things are shutting down
    if(hasWaiter)
      task->run();
    
  }
  
  bool ThreadQueue::removeShutdownTask(const Task& task) {
    
    Guard<FastLock> g(_lock);
    
    TaskList::iterator i = std::find(_shutdownTasks.begin(), _shutdownTasks.end(), task);
    bool removed = (i != _shutdownTasks.end());
    if(removed)
      _shutdownTasks.erase(i);

    //ZTDEBUG("1 shutdown task removed (%d)-%d\n", removed, _shutdownTasks.size());
    
    return removed;

  }

};
