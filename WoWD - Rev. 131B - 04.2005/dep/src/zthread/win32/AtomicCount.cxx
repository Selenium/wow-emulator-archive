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

#ifndef __ZTATOMICCOUNTIMPL_H__
#define __ZTATOMICCOUNTIMPL_H__

#include <windows.h>
#include <assert.h>

namespace ZThread {


AtomicCount::AtomicCount() {

  _value = reinterpret_cast<void*>(new LONG(1));
  
}

AtomicCount::~AtomicCount() {

  assert(*reinterpret_cast<LPLONG>(_value) == 0);
  delete reinterpret_cast<LPLONG>(_value);

}
  
void AtomicCount::increment() {

  ::InterlockedIncrement(reinterpret_cast<LPLONG>(_value));
  
}
  
bool AtomicCount::decrement() {

  LONG v = ::InterlockedDecrement(reinterpret_cast<LPLONG>(_value));
  return static_cast<unsigned long>(v) == 0;
  
}
 
};

#endif // __ZTATOMICCOUNTIMPL_H__
