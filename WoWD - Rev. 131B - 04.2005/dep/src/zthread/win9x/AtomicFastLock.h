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

#ifndef __ZTFASTLOCK_H__
#define __ZTFASTLOCK_H__

#include "zthread/NonCopyable.h"
#include <windows.h>
#include <assert.h>

namespace ZThread {


/**
 * @class FastLock
 *
 * @author Eric Crahen <http://www.code-foo.com>
 * @date <2003-07-16T23:31:51-0400>
 * @version 2.2.0
 *
 * This uses a custom spin lock based on the older swap & compare approach
 * using the XCHG instruction. You should only use this is you *absolutely* need
 * to use an older system, like Windows 95. If you can, use the Win32 version.
 *
 * Because Windows 95 and earlier can run on processors prior to the 486, they
 * don't all support the CMPXCHG function, and so Windows 95 an earlier dont support
 * InterlockedCompareExchange.
 *
 * This is asm inlined for microsoft visual c, it needs to be changed in order to
 * compile with gcc, or another win32 compiler - but more likely than not you'll
 * be using the Win32 version on those compilers and this won't be a problem.
 */ 
class FastLock : private NonCopyable {

// Add def for mingw32 or other non-ms compiler to align on 32-bit boundary
#pragma pack(push, 4)
  unsigned char volatile _lock;
#pragma pack(pop)
  
  public:
  
  /**
   * Create a new FastLock
   */
  inline FastLock() : _lock(0) { }

  
  inline ~FastLock() {
    assert(_lock == 0);
  }

  inline void acquire() {

    DWORD dw = (DWORD)&_lock;

    _asm { // swap & compare
    spin_lock:

      mov  al, 1
      mov  esi, dw
      xchg [esi], al       
      and  al,al
      jz   spin_locked
    }

    ::Sleep(0);

    _asm {
      jmp spin_lock
    spin_locked:
    }

  }

  inline void release() {

    DWORD dw = (DWORD)&_lock;

    _asm { 
      mov  al, 0
      mov  esi, dw
      xchg [esi], al       
    }


  }
    
 inline bool tryAcquire(unsigned long timeout=0) {

    volatile DWORD dw = (DWORD)&_lock;
    volatile DWORD result;

    _asm {

      mov  al, 1
      mov  esi, dw
      xchg [esi], al       
      and  al,al
      mov  esi, result
      xchg [esi], al       
    }

    return result == 0;

 }
  
}; /* Fast Lock */

} // namespace ZThread

#endif
