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

#ifndef __ZTSCHEDULING_H__
#define __ZTSCHEDULING_H__

#include "ThreadImpl.h"

#include <algorithm>
#include <functional>
#include <deque>
#include <utility>

namespace ZThread {

  /**
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-16T20:01:18-0400>
   * @version 2.2.0
   * @class fifo_list
   */
  class fifo_list : public std::deque<ThreadImpl*> {
  public:

    void insert(const value_type& val) { push_back(val); }

  };

  /**
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-16T20:01:18-0400>
   * @version 2.2.0
   * @struct priority_order
   */
  struct priority_order : public std::binary_function<ThreadImpl*, ThreadImpl*, bool> {
   
    std::less<const ThreadImpl*> id;

    bool operator()(const ThreadImpl* t0, const ThreadImpl* t1) const {

      if(t0->getPriority() > t1->getPriority())
        return true;

      else if (t0->getPriority() < t1->getPriority())
        return false;

      return id(t0, t1);

    }
  
  };


  /**
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-16T20:01:18-0400>
   * @version 2.2.0
   * @class priority_list
   */
  class priority_list : public std::deque<ThreadImpl*> { 

    priority_order comp;

  public:

    void insert(const value_type& val) { 

      push_back(val); 
      std::sort(begin(), end(), comp);

    }

  };

} // namespace ZThread

#endif // __ZTSCHEDULING_H__
