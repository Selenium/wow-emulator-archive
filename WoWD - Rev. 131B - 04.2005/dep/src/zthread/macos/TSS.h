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
#include "zthread/Exceptions.h"

#include <assert.h>
#include <CoreServices/CoreServices.h>
//#include <Multiprocessing.h>

namespace ZThread {

  /**
   * @class TSS
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-27T14:19:10-0400>
   * @version 2.1.6
   *
   * An abstraction for dealing with POSIX thread specific storage (tss). 
   * Provides get/set and creation/destruction.
   */
  template <typename T>
    class TSS : private NonCopyable {

    TaskStorageIndex _key;

    public:

    /**
     * Create a new object for accessing tss. 
     */
    TSS() {

      // Apple TN1071
      static bool init = MPLibraryIsLoaded();
    
      if(!init || MPAllocateTaskStorageIndex(&_key) != noErr) {
        assert(0);
        throw Initialization_Exception();
      }

    }

    /**
     * Destroy the underlying supoprt for accessing tss with this 
     * object.
     */
    ~TSS() {
  
      OSStatus status = MPDeallocateTaskStorageIndex(_key);
      if(status != noErr) 
        assert(0);

    }
 
    /**
     * Get the value stored in tss.
     *
     * @return T
     *
     * @exception InvalidOp_exception thrown when the tss is not properly initialized
     */
    T get() const {
      return reinterpret_cast<T>(MPGetTaskStorageValue(_key));
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

      OSStatus status = 
        MPSetTaskStorageValue(_key, reinterpret_cast<TaskStorageValue>(value));
    
      if(status != noErr) {
        assert(0);
        throw Synchronization_Exception();
      }

      return oldValue;
    
    }
   
  };

}

#endif


