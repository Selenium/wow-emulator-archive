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

#ifndef __ZTEXCEPTIONS_H__
#define __ZTEXCEPTIONS_H__


#include "zthread/Config.h"
#include <string>

namespace ZThread { 
  
/**
 * @class Synchronization_Exception
 *
 * Serves as a general base class for the Exception hierarchy used within
 * this package.
 *
 */
class Synchronization_Exception {

  // Restrict heap allocation
  static void * operator new(size_t size);
  static void * operator new[](size_t size);

  std::string _msg;
  
public:
  
  /**
   * Create a new exception with a default error message 'Synchronization 
   * Exception'
   */
  Synchronization_Exception() : _msg("Synchronization exception") { }

  /**
   * Create a new exception with a given error message
   *
   * @param const char* - error message
   */
  Synchronization_Exception(const char* msg) : _msg(msg) { }

  /**
   * Get additional info about the exception
   *
   * @return const char* for the error message
   */
  const char* what() const {
    return _msg.c_str();
  }
  
};
  

/**
 * @class Interrupted_Exception
 *
 * Used to describe an interrupted operation that would have normally
 * blocked the calling thread
 */
class Interrupted_Exception : public Synchronization_Exception {

  public:

  //! Create a new exception
  Interrupted_Exception() : Synchronization_Exception("Thread interrupted") { }

  //! Create a new exception
  Interrupted_Exception(const char* msg) : Synchronization_Exception(msg) { }

};
  
 
  
/**
 * @class Deadlock_Exception
 *
 * Thrown when deadlock has been detected
 */
class Deadlock_Exception : public Synchronization_Exception {
  public:

  //! Create a new exception
  Deadlock_Exception() : Synchronization_Exception("Deadlock detected") { }

  //! Create a new exception
  Deadlock_Exception(const char* msg) : Synchronization_Exception(msg) { }

};
  
  
/**
 * @class InvalidOp_Exception
 *
 * Thrown when performing an illegal operation this object
 */
class InvalidOp_Exception : public Synchronization_Exception {
  public:

  //! Create a new exception
  InvalidOp_Exception() : Synchronization_Exception("Invalid operation") { }
  //! Create a new exception
  InvalidOp_Exception(const char* msg) : Synchronization_Exception(msg) { }

};

  
  
/**
 * @class Initialization_Exception
 *
 * Thrown when the system has no more resources to create new 
 * synchronization controls
 */
class Initialization_Exception : public Synchronization_Exception {
  
  public:

  //! Create a new exception
  Initialization_Exception() : Synchronization_Exception("Initialization error") { }
  //! Create a new exception
  Initialization_Exception(const char*msg) : Synchronization_Exception(msg) { }

};
  
/**
 * @class Cancellation_Exception
 *
 * Cancellation_Exceptions are thrown by 'Canceled' objects. 
 * @see Cancelable
 */
class Cancellation_Exception : public Synchronization_Exception {

  public:
  
  //! Create a new Cancelltion_Exception
  Cancellation_Exception()  : Synchronization_Exception("Canceled") { }
  //! Create a new Cancelltion_Exception
  Cancellation_Exception(const char*msg) : Synchronization_Exception(msg) { }
  
};
  

/**
 * @class Timeout_Exception
 *
 * There is no need for error messaged simply indicates the last
 * operation timed out
 */
class Timeout_Exception : public Synchronization_Exception {
  public:

  //! Create a new Timeout_Exception
  Timeout_Exception() : Synchronization_Exception("Timeout") { }
  //! Create a new 
  Timeout_Exception(const char*msg) : Synchronization_Exception(msg) { }
  
};

/**
 * @class NoSuchElement_Exception
 * 
 * The last operation that was attempted on a Queue could not find 
 * the item that was indicated (during that last Queue method invocation)
 */
class NoSuchElement_Exception {
 public:
  
  //! Create a new exception
  NoSuchElement_Exception() {}

};

/**
 * @class InvalidTask_Exception
 *
 * Thrown when a task is not valid (e.g. null or start()ing a thread with 
 * no overriden run() method)
 */
class InvalidTask_Exception : public InvalidOp_Exception {
 public:

  //! Create a new exception
  InvalidTask_Exception() : InvalidOp_Exception("Invalid task") {}
  
};

/**
 * @class BrokenBarrier_Exception
 *
 * Thrown when a Barrier is broken because one of the participating threads
 * has been interrupted.
 */
class BrokenBarrier_Exception : public Synchronization_Exception {

  public:

  //! Create a new exception
  BrokenBarrier_Exception() : Synchronization_Exception("Barrier broken") { }

  //! Create a new exception
  BrokenBarrier_Exception(const char* msg) : Synchronization_Exception(msg) { }

};
  
/**
 * @class Future_Exception
 *
 * Thrown when there is an error using a Future.
 */
class Future_Exception : public Synchronization_Exception {

  public:

  //! Create a new exception
  Future_Exception() : Synchronization_Exception() { }

  //! Create a new exception
  Future_Exception(const char* msg) : Synchronization_Exception(msg) { }

};

};

#endif // __ZTEXCEPTIONS_H__
