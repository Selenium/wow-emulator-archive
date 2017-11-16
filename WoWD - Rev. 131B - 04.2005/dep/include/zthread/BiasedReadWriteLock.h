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

#ifndef __ZTBIASEDREADWRITELOCK_H__
#define __ZTBIASEDREADWRITELOCK_H__

#include "zthread/ReadWriteLock.h"
#include "zthread/Condition.h"
#include "zthread/Guard.h"
#include "zthread/FastMutex.h"

namespace ZThread {

  /**
   * @class BiasedReadWriteLock
   *
   * @author Eric Crahen <http://www.code-foo.com>
   * @date <2003-07-16T10:22:34-0400>
   * @version 2.2.7
   *  
   * A BiasedReadWriteLock has a bias toward writers. It will prefer read-write access over 
   * read-only access when many threads are contending for access to either Lockable this
   * ReadWriteLock provides.
   *
   * @see ReadWriteLock 
   */
  class BiasedReadWriteLock : public ReadWriteLock {

    FastMutex _lock;
    Condition _condRead;
    Condition _condWrite;
  
    volatile int _activeWriters;
    volatile int _activeReaders; 

    volatile int _waitingReaders;
    volatile int _waitingWriters;

    //! @class ReadLock
    class ReadLock : public Lockable {

      BiasedReadWriteLock& _rwlock;

    public:

      ReadLock(BiasedReadWriteLock& rwlock) : _rwlock(rwlock) {}

      virtual ~ReadLock() {}

      virtual void acquire() {
        _rwlock.beforeRead();
      }

      virtual bool tryAcquire(unsigned long timeout) {            
        return _rwlock.beforeReadAttempt(timeout);
      }

      virtual void release() {
        _rwlock.afterRead();
      }

    };

    //! @class WriteLock
    class WriteLock : public Lockable {

      BiasedReadWriteLock& _rwlock;

    public:

      WriteLock(BiasedReadWriteLock& rwlock) : _rwlock(rwlock) {}

      virtual ~WriteLock() {}


      virtual void acquire() {
        _rwlock.beforeWrite();
      }

      virtual bool tryAcquire(unsigned long timeout) {            
        return _rwlock.beforeWriteAttempt(timeout);
      }

      virtual void release() {
        _rwlock.afterWrite();
      }

    };

    friend class ReadLock;
    friend class WriteLock;

    ReadLock _rlock;
    WriteLock _wlock;

  public:
  
    /**
     * Create a BiasedReadWriteLock
     *
     * @exception Initialization_Exception thrown if resources could not be 
     *            allocated for this object.
     */
    BiasedReadWriteLock() : _condRead(_lock), _condWrite(_lock), _rlock(*this), _wlock(*this) {

      _activeWriters = 0;
      _activeReaders = 0;
 
      _waitingReaders = 0;
      _waitingWriters = 0;

    }

    //! Destroy this ReadWriteLock
    virtual ~BiasedReadWriteLock() {}

    /**
     * @see ReadWriteLock::getReadLock()
     */
    virtual Lockable& getReadLock() { return _rlock; }

    /**
     * @see ReadWriteLock::getWriteLock()
     */
    virtual Lockable& getWriteLock() { return _wlock; }

  
  protected:

    void beforeRead() {
    
      Guard<FastMutex> guard(_lock); 
    
      ++_waitingReaders;  
    
      while(!allowReader()) {
      
        try {
        
          // wait
          _condRead.wait();
        
        } catch(...) {
        
          --_waitingReaders;        
          throw;

        }
      
      }
    
      --_waitingReaders;
      ++_activeReaders;
    
    }

    bool beforeReadAttempt(unsigned long timeout) {
      
      Guard<FastMutex> guard(_lock); 
      bool result = false;

      ++_waitingReaders;  

      while(!allowReader()) {
        
        try {
          
          result = _condRead.wait(timeout);
          
        } catch(...) {
          
          --_waitingReaders;          
          throw;

        }

      }
      
      --_waitingReaders;
      ++_activeReaders;

      return result;
    }   
  

    void afterRead() {

      bool wakeReader = false;
      bool wakeWriter = false;

      {

        Guard<FastMutex> guard(_lock);
      
        --_activeReaders;

        wakeReader = (_waitingReaders > 0);
        wakeWriter = (_waitingReaders > 0);

      }

      if(wakeWriter)
        _condWrite.signal();
    
      else if(wakeReader)
        _condRead.signal();

    }

    void beforeWrite() {
    
      Guard<FastMutex> guard(_lock);
  
      ++_waitingWriters;

      while(!allowWriter()) {
        
        try {

          _condWrite.wait();
          
        } catch(...) {

          --_waitingWriters;
          throw;

        }
        
      }
      
      --_waitingWriters;
      ++_activeWriters;    

    }

    bool beforeWriteAttempt(unsigned long timeout) {
  
      Guard<FastMutex> guard(_lock);
      bool result = false;

      ++_waitingWriters;

      while(!allowWriter()) {
        
        try {

          result = _condWrite.wait(timeout);
          
        } catch(...) {

          --_waitingWriters;
          throw;
        }
        
      }
      
      --_waitingWriters;
      ++_activeWriters;
      
      return result;

    }

    void afterWrite() {

      bool wakeReader = false;
      bool wakeWriter = false;

      {

        Guard<FastMutex> guard(_lock);
      
        --_activeWriters;
      
        wakeReader = (_waitingReaders > 0);
        wakeWriter = (_waitingReaders > 0);

      }

      if(wakeWriter)
        _condWrite.signal();
    
      else if(wakeReader)
        _condRead.signal();
   
    }

    bool allowReader() {
      return (_activeWriters == 0);   
    }

    bool allowWriter() {
      return (_activeWriters == 0 && _activeReaders == 0);
    }

  };

}; // __ZTBIASEDREADWRITELOCK_H__

#endif
