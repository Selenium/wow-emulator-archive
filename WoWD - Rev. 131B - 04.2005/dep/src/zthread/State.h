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

#ifndef __ZTSTATE_H__
#define __ZTSTATE_H__

namespace ZThread {

/**
 * @class State 
 * @author Eric Crahen <http://www.code-foo.com>
 * @date <2003-07-16T20:04:01-0400>
 * @version 2.2.1
 *
 * Class to encapsulate the current state of the threads life-cycle.
 */
class State {
 public:

  //! Various states
  typedef enum { REFERENCE, IDLE, RUNNING, JOINED } STATE;

  /**
   * Create State with the given flag set.
   */
  State(STATE initialState) : _state(initialState) {}

  /**
   * Test for the IDLE state. No task has yet run.
   */
  bool isIdle() const {
    return _state == IDLE;
  }

  /**
   * Test for the JOINED state. A task has completed and 
   * the thread is join()ed.
   *
   * @return bool
   */
  bool isJoined() const {
    return _state == JOINED;
  }

  /**
   * Test for the RUNNING state. A task is in progress.
   *
   * @return bool
   */
  bool isRunning() const {
    return _state == RUNNING;
  }

  /**
   * Test for the REFERENCE state. A task is in progress but not
   * under control of this library.
   *
   * @return bool
   */
  bool isReference() const {
    return _state == REFERENCE;
  }

  /**
   * Transition to the IDLE state.
   *
   * @return bool true if successful
   */
  bool setIdle() {

    if(_state != RUNNING)
      return false;

    _state = IDLE;
    return true;

  }

  /**
   * Transition to the RUNNING state.
   *
   * @return bool true if successful
   */
  bool setRunning() {

    if(_state != IDLE)
      return false;

    _state = RUNNING;
    return true;

  }

  /**
   * Transition to the REFERENCE state.
   *
   * @return bool true if successful
   */
  bool setReference() {

    if(_state != IDLE)
      return false;

    _state = REFERENCE;
    return true;

  }


  /**
   * Transition to the JOINED state.
   *
   * @return bool true if successful
   */
  bool setJoined() {

    _state = JOINED;
    return true;

  }

 private:

  //! Current state
  STATE _state;

};


};

#endif
