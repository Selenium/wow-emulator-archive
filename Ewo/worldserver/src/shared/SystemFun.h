//////////////////////////////////////////////////////////////////////
//  SysFun.h
//
//  System-specific functions
//////////////////////////////////////////////////////////////////////

// Copyright (C) 2005 Team WSD
// Copyright (C) 2006 Team Evolution
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

#ifndef __SYSTEMFUN_H__
#define __SYSTEMFUN_H__

#include "Common.h"

/**
 * Sleep given number of milliseconds (1/1000 seconds, that is).
 */
void SleepMs (int ms);

/**
 * Get number of milliseconds passed since doesn't matter when.
 */
uint32 GetMilliseconds ();

#endif // __SYSTEMFUN_H__
