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

#ifndef WOWPYTHON_TIMER_H
#define WOWPYTHON_TIMER_H

#if PLATFORM == PLATFORM_WIN32
#   include <windows.h>
#   include <mmsystem.h>
#else
#   include <sys/timeb.h>
#endif

inline uint32 getMSTime()
{
    uint32 time_in_ms = 0;
#if PLATFORM == PLATFORM_WIN32
    time_in_ms = timeGetTime();    
#else
    struct timeb tp;
    ftime(&tp);

    time_in_ms = tp.time * 1000 + tp.millitm;
    
#endif

    return time_in_ms;
}

#endif


