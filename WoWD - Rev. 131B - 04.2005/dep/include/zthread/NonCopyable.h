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

#ifndef __ZTNONCOPYABLE_H__
#define __ZTNONCOPYABLE_H__

namespace ZThread {

  /**
   * @class NonCopyable
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-16T19:36:00-0400>
   * @version 2.2.11
   *
   * Some objects kind of objects should not be copied. This is particularly true
   * of objects involved in providing mutually exclusive access to something
   * (e.g. Mutexes, Queues, Semaphores, etc.)
   *
   * Based on Dave Abrahams contribution to the Boost library.
   */
  class NonCopyable {

    //! Restrict the copy constructor
    NonCopyable(const NonCopyable&);

    //! Restrict the assignment operator
    const NonCopyable& operator=(const NonCopyable&);

  protected:

    //! Create a NonCopyable object
    NonCopyable() { }

    //! Destroy a NonCopyable object
    ~NonCopyable() { }

  }; /* NonCopyable */

} // namespace ZThread

#endif // __ZTNONCOPYABLE_H__
