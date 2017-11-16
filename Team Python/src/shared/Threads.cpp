// Copyright (C) 2004 Team Python
//  
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software 
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.

#include "Threads.h"

#if PLATFORM == PLATFORM_WIN32

/// for _beginthread
#  include <process.h>
/// for SetThreadPriority
#  define WIN32_LEAN_AND_MEAN
#  include <windows.h>

#else

#  include <pthread.h>

#endif

/// Singleton
createFileSingleton( Threads );

void Threads::Fork( THREADRETURN (THREADCONVENTION *child)( void * ), void * param, ThreadPriority priority ) {
  //THREADTYPE thread;
#if PLATFORM == PLATFORM_WIN32
  HANDLE threadhandle = (HANDLE)_beginthread( child, 0, param );
  SetThreadPriority( threadhandle, getPlatformPriority( priority ) );
  // TODO: for some reason getthreadid gives me a runtime error
  //thread = GetThreadId( threadhandle );
#else
  pthread_t thread;
  pthread_attr_t threadattributes;
  pthread_attr_init( &threadattributes );
  sched_param schedparams;
  schedparams.sched_priority = getPlatformPriority( priority );
  pthread_attr_setschedparam( &threadattributes, &schedparams );
  pthread_create( &thread, &threadattributes, child, param );
  //not needed
  //pthread_attr_destroy( &threadattributes );
#endif
  // thread isn't set on windows =S
  //mThreads.insert( thread );
}

void Threads::setCurrentPriority( ThreadPriority priority ) {
#if PLATFORM == PLATFORM_WIN32
  SetThreadPriority( GetCurrentThread( ), getPlatformPriority( priority ) );
#else
  sched_param schedparams;
  schedparams.sched_priority = getPlatformPriority( priority );
  pthread_setschedparam( pthread_self( ), SCHED_OTHER, &schedparams );
#endif
}

void Threads::closeCurrentThread( ) {
  THREADTYPE thread;
#if PLATFORM != PLATFORM_WIN32
  thread = pthread_self( );
  mThreads.erase( thread );
  int ret = 0;
  pthread_exit( &ret );
#else
  thread = GetCurrentThreadId( );
  //mThreads.erase( thread );
  _endthread( );
#endif
}

//void Threads::closeAllThreads( ) {
//  while( mThreads.size( ) );
//}

int32 Threads::getPlatformPriority( ThreadPriority &priority ) {
  switch( priority ) {
#if PLATFORM == PLATFORM_WIN32
    case TP_IDLE:
      return THREAD_PRIORITY_IDLE;
    case TP_LOWER:
      return THREAD_PRIORITY_LOWEST;
    case TP_LOW:
      return THREAD_PRIORITY_BELOW_NORMAL;
    case TP_NORMAL:
      return THREAD_PRIORITY_NORMAL;
    case TP_HIGH:
      return THREAD_PRIORITY_ABOVE_NORMAL;
    case TP_HIGHER:
      return THREAD_PRIORITY_HIGHEST;
    case TP_REALTIME:
      return THREAD_PRIORITY_TIME_CRITICAL;
    default:
      return THREAD_PRIORITY_NORMAL;
#else
    case TP_IDLE:
      return 45;
    case TP_LOWER:
      return 51;
    case TP_LOW:
      return 57;
    case TP_NORMAL:
      return 63;
    case TP_HIGH:
      return 69;
    case TP_HIGHER:
      return 75;
    case TP_REALTIME:
      return 81;
    default:
      return 63; 
#endif
  }
}

