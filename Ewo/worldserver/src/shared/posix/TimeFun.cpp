//////////////////////////////////////////////////////////////////////
//  SysFun.h
//
//  POSIX-specific implementation of some functions
//////////////////////////////////////////////////////////////////////

// Copyright (C) 2005 Team WSD
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

#include "SystemFun.h"
#include "Common.h"

#include <unistd.h>
#include <sys/timeb.h>

uint32 GetMilliseconds ()
{
    uint32 time_in_ms = 0;
    struct timeb tp;
    ftime(&tp);		// must be switched to gettimeofday()

    time_in_ms = tp.time * 1000 + tp.millitm;
    
    return time_in_ms;
}

void SleepMs (int ms)
{
	usleep (ms * 1000);
}
