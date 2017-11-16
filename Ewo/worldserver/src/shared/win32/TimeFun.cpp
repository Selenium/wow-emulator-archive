//////////////////////////////////////////////////////////////////////
//  SysFun.h
//
//  POSIX-specific implementation of some functions
//////////////////////////////////////////////////////////////////////

// Copyright (C) 2005 Team WSD
// Copyright (C) 2006 Team Evolution
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

#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#include <mmsystem.h>

uint32 GetMilliseconds ()
{
//    uint32 time_in_ms = 0;
//    time_in_ms = timeGetTime();    
//    return time_in_ms;
    return timeGetTime();
}

void SleepMs (int ms)
{
	Sleep (ms);
}
