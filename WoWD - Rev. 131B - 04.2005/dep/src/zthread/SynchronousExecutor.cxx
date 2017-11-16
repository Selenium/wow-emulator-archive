#include "zthread/SynchronousExecutor.h"

namespace ZThread {

  SynchronousExecutor::SynchronousExecutor() 
    : _canceled(false) {}

  SynchronousExecutor::~SynchronousExecutor() {
  }
  
  void SynchronousExecutor::cancel() {

    Guard<Mutex> g(_lock);
    _canceled = true;

  }

  bool SynchronousExecutor::isCanceled() {
    
    Guard<Mutex> g(_lock);
    return _canceled;
    
  }

  void SynchronousExecutor::interrupt() {
  }

  void SynchronousExecutor::execute(const Task& task) {
    
    // Canceled Executors will not accept new tasks, quick 
    // check to avoid excessive locking in the canceled state
    if(_canceled) 
      throw Cancellation_Exception();
    
    Guard<Mutex> g(_lock);
    
    if(_canceled) // Double check
      throw Cancellation_Exception();
    
    // Run the task.
    Task(task)->run();
    
  }  

  void SynchronousExecutor::wait() {
    
    if(Thread::interrupted())
      throw Interrupted_Exception();
    
    Guard<Mutex> g(_lock);
    
  }
  
  /**
   * @see Executor::wait(unsigned long)
   */
  bool SynchronousExecutor::wait(unsigned long) {

    if(Thread::interrupted())
      throw Interrupted_Exception();
    
    Guard<Mutex> g(_lock);
    return true;
    
  }
  
  
}
