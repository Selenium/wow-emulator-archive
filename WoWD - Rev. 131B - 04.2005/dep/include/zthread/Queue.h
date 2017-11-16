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

#ifndef __ZTQUEUE_H__
#define __ZTQUEUE_H__

#include "zthread/Cancelable.h"
#include "zthread/NonCopyable.h"

namespace ZThread {

  /**
   * @class Queue
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-16T11:32:42-0400>
   * @version 2.3.0
   *
   * A Queue defines an interface for a value-oriented collection objects (similar to
   * STL collections). 
   */
  template <typename T>
    class Queue : public Cancelable, private NonCopyable {
    public:

    //! Destroy a Queue
    virtual ~Queue() { }

    /**
     * Add an object to this Queue.
     *
     * @param item value to be added to the Queue
     * 
     * @exception Cancellation_Exception thrown if this Queue has been canceled.
     *
     * @pre  The Queue should not have been canceled prior to the invocation of this function.
     * @post If no exception is thrown, a copy of <i>item</i> will have been added to the Queue.
     */
    virtual void add(const T& item) = 0;

    /**
     * Add an object to this Queue.
     *
     * @param item value to be added to the Queue
     * @param timeout maximum amount of time (milliseconds) this method may block
     *        the calling thread.
     *
     * @return 
     *   - <em>true</em> if a copy of <i>item</i> can be added before <i>timeout</i> 
     *     milliseconds elapse.
     *   - <em>false</em> otherwise.
     *
     * @exception Cancellation_Exception thrown if this Queue has been canceled.
     *
     * @pre  The Queue should not have been canceled prior to the invocation of this function.
     * @post If this function returns true a copy of <i>item</i> will have been added to the Queue.
     */
    virtual bool add(const T& item, unsigned long timeout) = 0;

    /**
     * Retrieve and remove a value from this Queue.
     *
     * @return <em>T</em> next available value
     * 
     * @exception Cancellation_Exception thrown if this Queue has been canceled.
     *
     * @pre  The Queue should not have been canceled prior to the invocation of this function.
     * @post The value returned will have been removed from the Queue.
     */
    virtual T next() = 0;

    /**
     * Retrieve and remove a value from this Queue.
     *
     * @param timeout maximum amount of time (milliseconds) this method may block
     *        the calling thread.
     *
     * @return <em>T</em> next available value
     * 
     * @exception Cancellation_Exception thrown if this Queue has been canceled.
     * @exception Timeout_Exception thrown if the timeout expires before a value
     *            can be retrieved.
     *
     * @pre  The Queue should not have been canceled prior to the invocation of this function.
     * @post The value returned will have been removed from the Queue.
     */
    virtual T next(unsigned long timeout) = 0;

    /**
     * Canceling a Queue disables it, disallowing further additions. Values already
     * present in the Queue can still be retrieved and are still available through
     * the next() methods.
     *
     * Canceling a Queue more than once has no effect.
     * 
     * @post The next() methods will continue to return objects until 
     *       the Queue has been emptied. 
     * @post Once emptied, the next() methods will throw a Cancellation_Exception.
     * @post The add() methods will throw a Cancellation_Exceptions from this point on.
     */
    virtual void cancel() = 0;

    /**
     * Count the values present in this Queue. 
     *
     * @return <em>size_t</em> number of elements available in the Queue. 
     */
    virtual size_t size() = 0;

    /**
     * Count the values present in this Queue. 
     *
     * @param timeout maximum amount of time (milliseconds) this method may block
     *        the calling thread.
     *
     * @return <em>size_t</em> number of elements available in the Queue. 
     *
     * @exception Timeout_Exception thrown if <i>timeout</i> milliseconds
     *            expire before a value becomes available
     */
    virtual size_t size(unsigned long timeout) = 0;

    /**
     * Test whether any values are available in this Queue.
     *
     * @return 
     *  - <em>true</em> if there are no values available.
     *  - <em>false</em> if there <i>are</i> values available.
     */
    virtual bool empty() {

      try {

        return size() == 0;

      } catch(Cancellation_Exception&) { }

      return true;

    }

    /**
     * Test whether any values are available in this Queue.
     *
     * @param timeout maximum amount of time (milliseconds) this method may block
     *        the calling thread.
     *
     * @return 
     *  - <em>true</em> if there are no values available.
     *  - <em>false</em> if there <i>are</i> values available.
     *
     * @exception Timeout_Exception thrown if <i>timeout</i> milliseconds
     *            expire before a value becomes available
     */
    virtual bool empty(unsigned long timeout) {

      try {

        return size(timeout) == 0;

      } catch(Cancellation_Exception&) { }

      return true;

    }

  }; /* Queue */

} // namespace ZThread

#endif // __ZTQUEUE_H__
