/*
 *  ZThreads, a platform-independent, multi-threading and
 *  synchronization library
 *
 *  Copyright (C) 2000-2003, Eric Crahen, See LGPL.TXT for details
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

#ifndef __ZTBARRIER_H__
#define __ZTBARRIER_H__

#include "zthread/Condition.h"
#include "zthread/Guard.h"
#include "zthread/Waitable.h"
#include "zthread/Runnable.h"

namespace ZThread {

  /**
   * @class Barrier
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-16T09:54:01-0400>
   * @version 2.2.1
   *
   * A Barrier is a Waitable object that serves as synchronization points for
   * a set of threads. A Barrier is constructed for a fixed number (<i>N</i>) of threads.
   * Threads attempting to wait() on a Barrier (<i> 1 - N</i>) will block until the <i>N</i>th
   * thread arrives. The <i>N</i>th thread will awaken all the the others.
   *
   * An optional Runnable command may be associated with the Barrier. This will be run()
   * when the <i>N</i>th thread arrives and Barrier is not broken.
   *
   * <b>Error Checking</b>
   *
   * A Barrier uses an all-or-nothing. All threads involved must successfully
   * meet at Barrier. If any one of those threads leaves before all the threads
   * have (as the result of an error or exception) then all threads present at
   * the Barrier will throw BrokenBarrier_Exception.
   *
   * A broken Barrier will cause all threads attempting to wait() on it to
   * throw a BrokenBarrier_Exception.
   *
   * A Barrier will remain 'broken', until it is manually reset().
   */
  template <unsigned int Count, class LockType>
    class Barrier : public Waitable, private NonCopyable {

    //! Broken flag
    bool _broken;
    //! Task flag
    bool _haveTask;
    //! Thread count
    unsigned int _count;
    //! Wait generation
    unsigned int _generation;
    //! Serialize access
    LockType _lock;
    //! Signaled when all thread arrive
    Condition _arrived;
    //! Command to run when all the thread arrive
    Task _task;

    public:

    //! Create a Barrier
    Barrier()
      : _broken(false), _haveTask(false), _count(Count), _generation(0), _arrived(_lock),
      _task(NULL) { }

    /**
     * Create a Barrier that executes the given task when all threads arrive
     * without error
     *
     * @param task Task to associate with this Barrier
     */
    Barrier (const Task& task)
      : _broken(false), _haveTask(true), _count(Count), _generation(0), _arrived(_lock),
      _task(task) { }

    //! Destroy this Barrier
    virtual ~Barrier() {}

    /**
     * Enter barrier and wait for the other threads to arrive. This can block for an indefinite
     * amount of time.
     *
     * @exception BrokenBarrier_Exception thrown when any thread has left a wait on this
     *            Barrier as a result of an error.
     * @exception Interrupted_Exception thrown when the calling thread is interrupted.
     *            A thread may be interrupted at any time, prematurely ending a wait
     *            for one thread and breaking the barrier for all threads
     *
     * @see Waitable::wait()
     *
     * @post If no exception was thrown, all threads have successfully arrived
     * @post If an exception was thrown, the barrier is broken
     */
    virtual void wait() {

      Guard<LockType> g(_lock);

      if(_broken)
        throw BrokenBarrier_Exception();

      // Break the barrier if an arriving thread is interrupted
      if(Thread::interrupted()) {

        // Release the other waiter, propagate the exception
        _arrived.broadcast();
        _broken = true;

        throw Interrupted_Exception();

      }

      if(--_count == 0) {

        // Wake the other threads if this was the last
        // arriving thread
        _arrived.broadcast();

        // Try to run the associated task, if it throws then
        // break the barrier and propagate the exception
        try {

          if(_task)
            _task->run();

          _generation++;

        } catch(Synchronization_Exception&) {

          _broken = true;
          throw;

        } catch(...) { assert(0); }

      } else {

        int myGeneration = _generation;

        try {

          // Wait for the other threads to arrive
          _arrived.wait();

        } catch(Interrupted_Exception&) {

          // Its possible for a thread to be interrupted before the
          // last thread arrives. If the interrupted thread hasn't
          // resumed, then just propagate the interruption

          if(myGeneration != _generation)
          //  Thread::current().interrupt();
            throw Interrupted_Exception ();

          else _broken = true;

        } catch(Synchronization_Exception&) {

          // Break the barrier and propagate the exception
          _broken = true;
          throw;

        }

        // If the thread woke because it was notified by the thread
        // that broke the barrier, throw.
        if(_broken)
          throw BrokenBarrier_Exception();

      }

    }

    /**
     * Enter barrier and wait for the other threads to arrive. This can block up to the
     * amount of time specified with the timeout parameter. The barrier will not break
     * if a thread leaves this function due to a timeout.
     *
     * @param timeout maximum amount of time, in milliseconds, to wait before
     *
     * @return
     *   - <em>true</em> if the set of tasks being wait for complete before
     *                   <i>timeout</i> milliseconds elapse.
     *   - <em>false</em> otherwise.
     *
     * @exception BrokenBarrier_Exception thrown when any thread has left a wait on this
     *            Barrier as a result of an error.
     * @exception Interrupted_Exception thrown when the calling thread is interrupted.
     *            A thread may be interrupted at any time, prematurely ending a wait
     *            for one thread and breaking the barrier for all threads
     *
     * @see Waitable::wait(unsigned long timeout)
     *
     * @post If no exception was thrown, all threads have successfully arrived
     * @post If an exception was thrown, the barrier is broken
     */
    virtual bool wait(unsigned long timeout) {

      Guard<LockType> g(_lock);

      if(_broken)
        throw BrokenBarrier_Exception();

      // Break the barrier if an arriving thread is interrupted
      if(Thread::interrupted()) {

        // Release the other waiter, propagate the exception
        _arrived.broadcast();
        _broken = true;

        throw Interrupted_Exception();

      }


      if(--_count == 0) {

        // Wake the other threads if this was the last
        // arriving thread
        _arrived.broadcast();

        // Try to run the associated task, if it throws then
        // break the barrier and propagate the exception
        try {

          if(_task)
            _task->run();

          _generation++;

        } catch(Synchronization_Exception&) {

          _broken = true;
          throw;

        } catch(...) { assert(0); }

      } else {

        int myGeneration = _generation;

        try {

          // Wait for the other threads to arrive
          if(!_arrived.wait(timeout))
            // If this happens then we have our timeout, we are cleanly out
            // <CHANGE>
            return false;
//          Old code that generated the BrokenBarrier Exception when the timeout
//          {
//          _broken = true;
//          }

        } catch(Interrupted_Exception&) {

          // Its possible for a thread to be interrupted before the
          // last thread arrives. If the interrupted thread hasn't
          // resumed, then just propagate the interruption

          if(myGeneration != _generation)
//            Thread::current().interrupt();
             throw Interrupted_Exception ();

          else _broken = true;

        } catch(Synchronization_Exception&) {

          // Break the barrier and propagate the exception
          _broken = true;
          throw;

        }

        // If the thread woke because it was notified by the thread
        // that broke the barrier, throw.
        if(_broken)
          throw BrokenBarrier_Exception();

      }

      return true;

    }

    /**
     * Break the Barrier ending the wait for any threads that were waiting on
     * the barrier.
     *
     * @post the Barrier is broken, all waiting threads will throw the
     *       BrokenBarrier_Exception
     */
    void shatter() {

      Guard<LockType> g(_lock);

      _broken = true;
      _arrived.broadcast();

    }

    /**
     * Reset the Barrier.
     *
     * @post the Barrier is no longer Broken and can be used again.
     */
    void reset() {

      Guard<LockType> g(_lock);

      _broken = false;
      _generation++;
      _count = Count;

    }

  };


} // namespace ZThread

#endif // __ZTBARRIER_H__
