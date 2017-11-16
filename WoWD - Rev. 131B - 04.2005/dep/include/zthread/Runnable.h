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

#ifndef __ZTRUNNABLE_H__
#define __ZTRUNNABLE_H__

#include "zthread/Config.h"

namespace ZThread {

  /**
   * @class Runnable
   * 
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-16T17:45:35-0400>
   * @version 2.2.11
   *
   * Encapsulates a Runnable task.
   */
  class Runnable {
  public:

    /**
     * Runnables should never throw in their destructors
     */
    virtual ~Runnable() {}

    /**
     * Task to be performed in another thread of execution
     */
    virtual void run() = 0;

  };
 

}

#endif // __ZTRUNNABLE_H__
