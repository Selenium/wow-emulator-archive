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

#ifndef __STRFUN_H__
#define __STRFUN_H__

#include "Common.h"

/**
 * Allocate a new copy of the string. The allocated storage must be freed
 * when it's no longer needed with delete [].
 * @arg s
 *   Source string to make a copy of
 * @return
 *   A new allocated copy of the string.
 */
extern char *strnew (const char *s);

/**
 * Trim starting and ending whitespaces in a string.
 * Changes the string in-place.
 * @arg str
 *   The source (and also the destination) string.
 */
extern void trim (char *str);

void LoadValues32(uint32* target_data,const char* src_data,uint32 valuesCount);
void LoadValues8(uint8* target_data,const char* src_data,uint32 valuesCount);
#endif // __STRFUN_H__
