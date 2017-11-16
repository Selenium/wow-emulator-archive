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

#include "StringFun.h"
#include <string.h>

char *strnew (const char *s)
{
	if (!s)
		return NULL;

	size_t sl = strlen (s) + 1;
	char *ret = new char [sl];
	memcpy (ret, s, sl);
	return ret;
}

void trim (char *str)
{
	char *first = str;
	while (*first && isspace (*first))
		first++;
	char *last = strchr (str, 0);
	while ((last > first) && isspace (first [-1]))
		last--;
	memmove (str, first, last - first);
	str [last - first] = 0;
}
