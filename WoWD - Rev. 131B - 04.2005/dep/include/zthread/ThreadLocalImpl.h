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

#ifndef __ZTTHREADLOCALIMPL_H__
#define __ZTTHREADLOCALIMPL_H__

#include "zthread/CountedPtr.h"

namespace ZThread {

  /**
   * @class ThreadLocalImpl
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-27T10:23:19-0400>
   * @version 2.3.0
   *
   * @see ThreadLocal
   */
  class ZTHREAD_API ThreadLocalImpl : private NonCopyable {   
  public:

    class Value;
    typedef CountedPtr<Value, size_t> ValuePtr;

    //!
    class Value {
      Value& operator=(const Value&);
    public:
      virtual ~Value() {}
      virtual bool isInheritable() const = 0;
      virtual ValuePtr clone() const = 0;
    };

    //! Create a ThreadLocalImpl
    ThreadLocalImpl();
  
    //! Destroy a ThreadLocalImpl
    ~ThreadLocalImpl();
  
    /**
     * @class InitialValueFn
     */
    template <typename T>
    struct InitialValueFn {      
      T operator()() { return T(); }
    }; 

    /**
     * @class ChildValueFn
     */
    struct ChildValueFn {
      template <typename T>
      T operator()(const T& value) { return T(value); }
    };
 
    /**
     * @class UniqueChildValueFn
     */
    struct UniqueChildValueFn : public ChildValueFn { };
    
    /**
     * @class InheritableValueFn
     */
    struct InheritableValueFn {

      template <typename T>    
      bool operator()(const T&) { return true; }

      bool operator()(const UniqueChildValueFn&) { return false; }

    };

  protected:

    //! Get the Value for the current thread
    ValuePtr value( ValuePtr (*pfn)() ) const;

    //! Clear any value set for this thread
    void clear() const;

    //! Clear any value set with any ThreadLocal for this thread
    static void clearAll();

  };

} // __ZTTHREADLOCALIMPL_H__

#endif

