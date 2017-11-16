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

#ifndef __GUARDEDCLASS_H__
#define __GUARDEDCLASS_H__

#include "zthread/Guard.h"
#include "zthread/Mutex.h"

namespace ZThread {

  /**
   * @class GuardedClass
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-20T20:17:34-0400>
   * @version 2.3.0
   *
   * A simple wrapper template that uses Guard's to provide 
   * serialized access to an objects member functions.
   */
  template <class T, class LockType = Mutex>
    class GuardedClass {
      
      LockType _lock;
      T* _ptr;
      
      class TransferedScope {
      public:
        
        template <class LockType1, class LockType2>
          static void shareScope(LockHolder<LockType1>& l1,
                                 LockHolder<LockType2>& l2) {
          l1.disable();
          l2.getLock().acquire();
        }
        
        template <class LockType1>
          static void createScope(LockHolder<LockType1>& l) {
          // Don't acquire the lock when scope the Guard is created
        }

        template <class LockType1>
          static void destroyScope(LockHolder<LockType1>& l) {
          l.getLock().release();
        }

      };

      class Proxy : Guard<LockType, TransferedScope> {

        T* _object;

      public:

        Proxy(LockType& lock, T* object) :
          Guard<LockType, TransferedScope>(lock), _object(object) { }

        T* operator->() {
          return _object;
        }

      };

      GuardedClass();
      GuardedClass& operator=(const GuardedClass&);
      
      public:
      
      GuardedClass(T* ptr) : _ptr(ptr) {}
      ~GuardedClass() {
        if(_ptr)
          delete _ptr;
      }

      Proxy operator->() {
        Proxy p(_lock, _ptr);
        return p;
      }
      
    };
  
} // namespace ZThread

#endif // __ZTGUARDEDCLASS_H__
