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

#include "StringFun.h"
#include "debug.h"
#include <string.h>
#include "Namespace.h"
#include <vector>

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

vector<string> StrSplit(const string &src, const string &sep)
{
   vector<string> r;
   string s;
   for (string::const_iterator i = src.begin(); i != src.end(); i++) {
      if (sep.find(*i) != string::npos) {
         if (s.length()) r.push_back(s);
         s = "";
      } else {
         s += *i;
      }
   }
   if (s.length()) r.push_back(s);
   return r;
}

//-----------------------------------------------------------------------------
/// Fill the object's Update Values from a space delimited list of values.
//-----------------------------------------------------------------------------
void LoadValues32(uint32* target_data,const char* src_data,uint32 valuesCount)
{
	ASSERT(src_data);
	ASSERT(target_data);
    vector<string> tokens = StrSplit(src_data, " ");
    vector<string>::iterator iter;
    uint32 index;
    for (iter = tokens.begin(), index = 0;index < valuesCount && iter != tokens.end(); ++iter, ++index)
		target_data[index] = atol((*iter).c_str());
}

void LoadValues8(uint8* target_data,const char* src_data,uint32 valuesCount)
{
	ASSERT(src_data);
	ASSERT(target_data);
    vector<string> tokens = StrSplit(src_data, " ");
    vector<string>::iterator iter;
    uint32 index;
    for (iter = tokens.begin(), index = 0;index < valuesCount && iter != tokens.end(); ++iter, ++index)
		target_data[index] = (uint8)atol((*iter).c_str());
}
