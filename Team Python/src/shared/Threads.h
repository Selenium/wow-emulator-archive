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

#ifndef WOWPYTHONSERVER_THREADS_H
#define WOWPYTHONSERVER_THREADS_H

#include "Common.h"

#include "Singleton.h"

#if PLATFORM == PLATFORM_WIN32
#  define THREADCONVENTION __cdecl
#  define THREADRETURN void

#  define ENDTHREAD Threads::getSingleton( ).closeCurrentThread( ); return;

#  define THREADTYPE uint32
#else
#  include <pthread.h>
#  define THREADCONVENTION
#  define THREADRETURN void *

#  define ENDTHREAD Threads::getSingleton( ).closeCurrentThread( ); return NULL;

#  define THREADTYPE pthread_t
#endif

#define THREADCALL THREADRETURN THREADCONVENTION

class Threads : public Singleton < Threads > {
public:
  enum ThreadPriority {
    TP_IDLE,
    TP_LOWER,
    TP_LOW,
    TP_NORMAL,
    TP_HIGH,
    TP_HIGHER,
    TP_REALTIME
  };

  void Fork( THREADRETURN ( THREADCONVENTION * child )( void * ), void * param, ThreadPriority priority );

  void setCurrentPriority( ThreadPriority priority );
  void closeCurrentThread( );
  void closeAllThreads( );
private:
  int32 getPlatformPriority( ThreadPriority & priority );
  typedef std::set < THREADTYPE > threadSet;
  threadSet mThreads;
};

#endif

