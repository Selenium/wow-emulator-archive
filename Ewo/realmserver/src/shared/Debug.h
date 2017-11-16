// Copyright (C) 2005 WSD Python
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

#pragma once
#ifndef __DEBUG_H
#define __DEBUG_H
#include <stdio.h>
/**
 * All kind of asserts, as well as debug outputs must be activated ONLY IN DEBUG BUILDS.
 * The reason for having the following macros is to disable all kinds of debugging
 * for release builds.
 */

// This must be defined elsewhere, perhaps in config.h

#define DEBUG 1

#ifdef DEBUG
#  include <assert.h>
#  define DEBUG_DUMP (f,d,s,r) DebugDump (f, d, s, r)
#  if COMPILER == COMPILER_GNU
#    define DEBUG_BREAK asm ("int $3")
#  elif (COMPILER == COMPILER_MICROSOFT) || (COMPILER == COMPILER_BORLAND)
#    define DEBUG_BREAK _asm { int 3 }
#  else
#    define DEBUG_BREAK
#  endif
#  define DEBUG_BREAK_IF(cond) { if (cond) DEBUG_BREAK; }
#  define ASSERT(cond) assert(cond)
#else
#  define DEBUG_DUMP (f,d,s,r)
#  define DEBUG_BREAK
#  define DEBUG_BREAK_IF(cond)
#  define ASSERT(cond)
#endif

// Neat for debugging
void DebugDump(FILE *Out, const void *Data, unsigned Size, bool RelOfs = true);

void printBytes(char* bytes, int l, char *name);

#endif

