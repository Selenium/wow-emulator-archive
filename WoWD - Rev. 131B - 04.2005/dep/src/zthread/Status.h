/*
 *  ZThreads, a platform-independent, multi threading and 
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

#ifndef __ZTBLOCKINGSTATE_H__
#define __ZTBLOCKINGSTATE_H__

#include <assert.h>

namespace ZThread {

  /**
   * @class Status
   * @version 2.3.0
   *
   * A Status is associated with each Thread's Monitor. Monitors rely on a
   * Status object for providing information that will affect a blocking operations.
   */
  class Status {
  public:
    //! Aggregate of pending status changes
    volatile unsigned short _pending; 
 
    //! Interest mask  
    volatile unsigned short _mask;

  public:
 
    //! State for the monitor
    typedef enum {
    
      // Default
      INVALID      = 0x00,

      // Valid states
      SIGNALED     = 0x01,
      INTERRUPTED  = 0x02, 
      TIMEDOUT     = 0x04,
      CANCELED     = 0x08,

      // Mask
      ANYTHING     = (~INVALID & ~CANCELED)

    } STATE;

    Status() : _pending(INVALID), _mask(ANYTHING) { }
  
    /**
     * Set the mask for the STATE's that next() will report.
     * STATE's not covered by the interest mask can still be 
     * set, they just aren't reported until the mask is changed
     * to cover that STATE.
     *
     * @param STATE
     * @pre accessed ONLY by the owning thread.
     */
    void interest(STATE mask) {
      _mask = static_cast<unsigned short>(mask);
    }

    bool masked(STATE mask) {
      return (_mask & static_cast<unsigned short>(mask)) == 0;
    }

    /**
     * Return true if next() will return a STATE covered
     * by the current interest mask and by the mask given
     * to this function.
     *
     * @param unsigned short
     * @pre accessed ONLY by the owning thread.
     */      
    bool pending(unsigned short mask) {
 
      assert(mask != INVALID);
      return ((_pending & _mask) & mask) != INVALID;

    }

    /**
     * Check the state without the interest mask. 
     *
     * @param state 
     * @return true if the flag is set 
     * @pre access must be serial
     */
    bool examine(STATE state) {
      return (_pending & static_cast<unsigned short>(state)) != INVALID;
    }

    /**
     * Add the flags to the current state.
     *
     * @param interest - the flags to add to the current state.
     * @pre access must be serial
     */
    void push(STATE interest) {
      _pending |= interest;  
    }

    /**
     * Clear the flags from the current state
     * 
     * @param interest - the flags to clear from the current state.
     * @pre access must be serial
     */
    void clear(STATE interest) {

      assert(interest != INVALID);
      assert(interest != ANYTHING);
      assert(interest != CANCELED);

      _pending &= ~interest;
    
    }

    /**
     * Get the next state from set that has accumulated. The order STATES are
     * reported in is SIGNALED, TIMEOUT, or INTERRUPTED. Setting the 
     * intrest mask allows certain state to be selectively ignored for 
     * a time - but not lost. The states will become visible again as soon
     * as the interest mask is changed appropriately. The interest mask is 
     * generally used to create uninterruptable waits (waiting for threads 
     * to start, reacquiring a conditions predicate lock, etc)
     *
     * @return STATE
     * @pre access must be serial
     */
    STATE next() {

      STATE state = INVALID;
    
      if(((_pending & _mask) & SIGNALED) != 0) {
      
        // Absorb the timeout if it happens when a signal
        // is available at the same time
        _pending &= ~(SIGNALED|TIMEDOUT);
        state = SIGNALED;
      
      } else if(((_pending & _mask) & TIMEDOUT) != 0) {

        _pending &= ~TIMEDOUT;
        state = TIMEDOUT;

      } else if(((_pending & _mask) & INTERRUPTED) != 0) {
      
        _pending &= ~INTERRUPTED;
        state = INTERRUPTED;
      
      } 
      
      assert(state != INVALID);
      return state;
    
    }

  };

}; // namespace ZThread

#endif
