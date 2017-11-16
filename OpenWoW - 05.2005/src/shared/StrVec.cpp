/*
    String vector class
    Copyright (C) 1998,1999 by Andrew Zabolotny <bit@eltech.ru>

    This library is free software; you can redistribute it and/or
    modify it under the terms of the GNU Library General Public
    License as published by the Free Software Foundation; either
    version 2 of the License, or (at your option) any later version.

    This library is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    Library General Public License for more details.

    You should have received a copy of the GNU Library General Public
    License along with this library; if not, write to the Free
    Software Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.
*/

#include "StrVec.h"
#include <string.h>

StrVector::~StrVector ()
{
    DeleteAll ();
}

bool StrVector::FreeItem (Some Item)
{
    delete [] (char *) Item;
    return true;
}

int StrVector::Compare (Some Item1, Some Item2, int Mode) const
{
    (void)Mode;
    return strcmp ((char *)Item1, (char *)Item2);
}

int StrVector::CompareKey (Some Item, ConstSome Key, int Mode) const
{
    (void)Mode;
    return strcmp ((char *)Item, (char *)Key);
}
