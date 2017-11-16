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

#ifndef __ZTTSS_H__
#define __ZTTSS_H__

#include <windows.h>

namespace ZThread {

  /**
   * @class TSS
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-27T14:18:43-0400>
   * @version 2.3.0
   *
   * An abstraction for dealing with WIN32 thread specific storage (tss). 
   * Provides get/set and creation/destruction.
   */
  template <typename T>
    class TSS {
  
    DWORD _key;
    bool _valid;

    public:

    /**
     * Create a new object for accessing tss. The def
     */
    TSS() {

      _key = ::TlsAlloc();
      _valid = (_key != 0xFFFFFFFF);

    }

    /**
     * Destroy the underlying supoprt for accessing tss with this 
     * object.
     */
    virtual ~TSS() {
  
      if(_valid) 
        ::TlsFree(_key);
   
    }
 
    /**
     * Get the value stored in tss.
     *
     * @return T
     *
     * @exception InvalidOp_exception thrown when the tss is not properly initialized
     */
    inline T get() const {

      if(!_valid)
        throw InvalidOp_Exception();

      return static_cast<T>(::TlsGetValue(_key));

    }

    /**
     * Store a value in tss.
     *
     * @param value T
     * @return T old value
     *
     * @exception InvalidOp_exception thrown when the tss is not properly initialized
     */
    inline T set(T value) const {

      T oldValue = get();
      ::TlsSetValue(_key, value);

      return oldValue;

    }
 
 
  };

}

#endif


