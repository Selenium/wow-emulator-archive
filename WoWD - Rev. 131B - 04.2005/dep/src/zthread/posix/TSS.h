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

#include "zthread/NonCopyable.h"
#include <pthread.h>
#include <assert.h>

namespace ZThread {

  /**
   * @class TSS
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-27T14:18:37-0400>
   * @version 2.3.0
   *
   * An abstraction for dealing with POSIX thread specific storage (tss). 
   * Provides get/set and creation/destruction.
   */
  template <typename T>
    class TSS : private NonCopyable {
  
    pthread_key_t _key;

    public:

    /**
     * Create a new object for accessing tss. 
     */
    TSS() {

      if(pthread_key_create(&_key, 0) != 0) {
        assert(0); // Key creation failed
      }

    }

    /**
     * Destroy the underlying supoprt for accessing tss with this 
     * object.
     */
    ~TSS() {
  
      pthread_key_delete(_key);
    
    }
 
    /**
     * Get the value stored in tss.
     *
     * @return T
     *
     * @exception InvalidOp_exception thrown when the tss is not properly initialized
     */
    T get() const {
      return reinterpret_cast<T>(pthread_getspecific(_key));
    }
  
 
    /**
     * Store a value in tss.
     *
     * @param value T
     * @return T old value
     *
     * @exception InvalidOp_exception thrown when the tss is not properly initialized
     */
    T set(T value) const {

      T oldValue = get();
      pthread_setspecific(_key, value);
    
      return oldValue;
    
    }
   
  };

}

#endif


