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

#ifndef __ZTLOCKEDQUEUE_H__
#define __ZTLOCKEDQUEUE_H__

#include "zthread/Guard.h"
#include "zthread/Queue.h"

#include <deque>

namespace ZThread {

  /**
   * @class LockedQueue
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-16T11:42:33-0400>
   * @version 2.3.0
   *
   * A LockedQueue is the simple Queue implementation that provides 
   * serialized access to the values added to it.
   */
  template <class T, class LockType, typename StorageType=std::deque<T> >
    class LockedQueue : public Queue<T> {

      //! Serialize access to the Queue
      LockType _lock;

      //! Storage backing the queue
      StorageType _queue;

      //! Cancellation flag
      volatile bool _canceled;

      public:

      //! Create a LockedQueue
      LockedQueue() : _canceled(false) {}

      //! Destroy a LockedQueue
      virtual ~LockedQueue() { }

      /**
       * @see Queue::add(const T& item)
       */
      virtual void add(const T& item) {

        Guard<LockType> g(_lock);
    
        if(_canceled)
          throw Cancellation_Exception();

        _queue.push_back(item);

      }

      /**
       * @see Queue::add(const T& item, unsigned long timeout)
       */
      virtual bool add(const T& item, unsigned long timeout) {
      
        try {

          Guard<LockType> g(_lock, timeout);
      
          if(_canceled)
            throw Cancellation_Exception();
      
          _queue.push_back(item);

        } catch(Timeout_Exception&) { return false; }
 
        return true;

      }

      /**
       * @see Queue::next()
       */
      virtual T next() {
    
        Guard<LockType> g(_lock);

        if(_queue.size() == 0 && _canceled)
          throw Cancellation_Exception();
    
        if(_queue.size() == 0)
          throw NoSuchElement_Exception();

        T item = _queue.front();
        _queue.pop_front();
    
        return item;

      }

      
      /**
       * @see Queue::next(unsigned long timeout)
       */
      virtual T next(unsigned long timeout) {

        Guard<LockType> g(_lock, timeout);

        if(_queue.size() == 0 && _canceled)
          throw Cancellation_Exception();
    
        if(_queue.size() == 0)
          throw NoSuchElement_Exception();

        T item = _queue.front();
        _queue.pop_front();
      
        return item;
      
      }


      /**
       * @see Queue::cancel()
       */
      virtual void cancel() {
 
        Guard<LockType> g(_lock);

        _canceled = true;

      }

      /**
       * @see Queue::isCanceled()
       */
      virtual bool isCanceled() {
    
        // Faster check since the queue will not become un-canceled
        if(_canceled)
          return true;
      
        Guard<LockType> g(_lock);

        return _canceled;

      }

      /**
       * @see Queue::size()
       */
      virtual size_t size() {

        Guard<LockType> g(_lock);
        return _queue.size();

      }

      /**
       * @see Queue::size(unsigned long timeout)
       */
      virtual size_t size(unsigned long timeout) {

        Guard<LockType> g(_lock, timeout);
        return _queue.size();

      }

    }; /* LockedQueue */

} // namespace ZThread

#endif // __ZTLOCKEDQUEUE_H__
