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

#include <asm/atomic.h>
#include <assert.h>

namespace ZThread {

typedef struct atomic_count_t {

  atomic_t count;

  atomic_count_t() {
    atomic_t init = ATOMIC_INIT(1);
    count = init;
  }

  ~atomic_count_t() {
    assert(atomic_read(&count) == 0);
  }

} ATOMIC_COUNT;


AtomicCount::AtomicCount() {

  _value = reinterpret_cast<void*>(new ATOMIC_COUNT);
  
}

AtomicCount::~AtomicCount() {

  delete reinterpret_cast<ATOMIC_COUNT*>(_value);

}
  
void AtomicCount::increment() {

  atomic_inc(&reinterpret_cast<ATOMIC_COUNT*>(_value)->count);
  
}
  
bool AtomicCount::decrement() {

  return atomic_dec_and_test(&reinterpret_cast<ATOMIC_COUNT*>(_value)->count);
  
}
 
};

#endif // __ZTATOMICCOUNTIMPL_H__
