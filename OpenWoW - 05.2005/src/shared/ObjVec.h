/*
    This file defines a vector of objects.
    Copyright (C) 1998,1999 by Andrew Zabolotny

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

#ifndef __OBJVEC_H__
#define __OBJVEC_H__

#include "Vector.h"

/**
 * ObjVector is a subclass of Vector that holds any number of pointers
 * to Base objects. Every inserted object gets its reference counter
 * incremented, and after removing a object from the vector it is
 * the caller's responsability to decrement the reference counter
 * after the object is no longer used.
 */
class ObjVector : public Vector
{
public:
    /// Create the object
    ObjVector (int ilimit = 8, int ithreshold = 16) :
        Vector (ilimit, ithreshold) {}
    /// Decrement reference count for all objects
    virtual ~ObjVector ();

    /// Decrement object's reference count
    virtual bool FreeItem (Some Item);

    /// Append the object to the array and increment object's reference counter
    inline int Push (Base *what)
    { what->IncRef (); return Vector::Push (what); }
    /// Pick the top object from the array (DOES NOT decrement object's reference counter)
    inline Base *Pop ()
    { return (Base *)Vector::Pop (); }
    /// Get a pointer to object by index
    inline Base *Get (int iIndex) const
    { return (Base *)Vector::Get (iIndex); }
    /// Insert element 'Item' before element 'n'
    inline bool Insert (int n, Base *Item)
    { Item->IncRef (); return Vector::Insert (n, Item); }
    /// Insert element 'Item' so that array remains sorted (assumes its already sorted)
    inline int InsertSorted (Base *Item, int *oEqual = 0, int Mode = 0)
    { Item->IncRef (); return Vector::InsertSorted (Item, oEqual, Mode); }
};

#endif // __OBJVEC_H__
