/*
    Vector class interface
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

#ifndef __VECTOR_H__
#define __VECTOR_H__

#include "Base.h"
#include "Debug.h"

typedef void *Some;
typedef const void *ConstSome;

/**
 * The following flags, if ORed with the 'Mode' parameter of FindSortedKey
 * allow some additional control over the search process.
 */
/// Find the nearest element that is smaller
#define CSV_FIND_NEAREST_SMALLER	0x40000000
/// Find the nearest element that is larger
#define CSV_FIND_NEAREST_LARGER		0x80000000
/// Search mode mask
#define CSV_FIND_MODE_MASK		0xc0000000

/**
 * Vector is an abstract class which can hold an unlimited array
 * of unspecified (void *) data. Since this is a basic object, it does
 * not presume anything about its elements, so FreeItem () is
 * effectively a NOP. If you want vector elements to free automatically
 * occupied memory upon vector destruction you should create a derived
 * class which should provide its own FreeItem () method (see csStrVector
 * for a example).
 */
class Vector : public Base
{
protected:
    int count, limit, threshold;
    Some *root;

public:
    /**
     * Initialize object to hold initially 'ilimit' elements, and increase
     * storage by 'ithreshold' each time the upper bound is exceeded.
     */
    Vector (int ilimit = 8, int ithreshold = 16);
    /// Destroy the vector object
    virtual ~Vector ();

    /// Get a reference to n-th element (n must be < Length())
    inline Some& operator [] (int n) const
    {
	DEBUG_BREAK_IF (n >= count)
        return (root [n]);
    }

    /// Same but in function form
    inline Some& Get (int n) const
    {
	DEBUG_BREAK_IF (n >= count)
        return (root [n]);
    }

    /// Set vector length to n
    virtual void SetLength (int n);
    /// Query vector length
    inline int Length () const
    { return count; }
    /// Query vector limit
    inline int Limit () const
    { return limit; }

    /// Exchange two elements in array
    inline void Exchange (int n1, int n2)
    {
	Some tmp = root [n1];
	root [n1] = root [n2];
	root [n2] = tmp;
    }
    /// Shift one element to a different place (ROL and ROR)
    bool Shift (int n1, int n2);

    /// Find a element in array and return its index (or -1 if not found)
    int Find (Some which, bool reversedir = false) const;
    /// Find a element by key (using CompareKey method)
    int FindKey (ConstSome Key, int Mode = 0) const;
    /**
     * Find a element in a SORTED array by key (using CompareKey method).
     * @arg Key
     *   The search key. The key can be anything, its interpretation depends
     *   on the implementation of the possibly overrided CompareKey() method.
     * @arg Mode
     *   Comparison mode. This argument is passed almost as-is (after dropping
     *   the CSV_FIND_MODE_MASK bits) to the CompareKey method so that you
     *   can have several different comparison criteria in one class.
     *   If you set the CSV_FIND_NEAREST_LARGER bit in Mode (using | operator),
     *   the function will return the nearest element that is larger than
     *   specified key (note it can return -1 if all elements are smaller).
     *   If you set the CSV_FIND_NEAREST_SMALLER bit in Mode, the function
     *   will return the nearest element that is smaller than the specified key
     *   (note that it can return -1 if all elements are greater than the key).
     *   In any case, you'll most probably have to call CompareKey yourself after
     *   FindSortedKey since you can't make find out whether the found element
     *   is smaller, equal or greater than the specified key.
     * @return
     *   The index of the found element or -1 if there's no element matching
     *   the criteria you specified.
     */
    int FindSortedKey (ConstSome Key, int Mode = 0) const;

    /// Partially sort the array
    void QuickSort (int Left, int Right, int Mode = 0);
    /// Same but for all elements
    void QuickSort (int Mode = 0)
    { if (count > 0) QuickSort (0, count - 1, Mode); }

    /// Push a element on 'top' of vector
    inline int Push (Some what)
    {
	SetLength (count + 1);
	root [count - 1] = what;
	return count - 1;
    }
    /// Pop a element from vector 'top'
    inline Some Pop ()
    {
	Some ret = root [count - 1];
	SetLength (count - 1);
	return ret;
    }

    /// Delete element number 'n' from vector
    bool Delete (int n);
    /// Replace n-th item with another (free previous value)
    bool Replace (int n, Some what);
    /// Delete all elements
    void DeleteAll ();
    /// Insert element 'Item' before element 'n'
    bool Insert (int n, Some Item);
    /// Insert element 'Item' so that array remains sorted (assumes its already)
    int InsertSorted (Some Item, int *oEqual = 0, int Mode = 0);
    /// Virtual function which frees a vector element; returns success status
    virtual bool FreeItem (Some Item);
    /// Compare two array elements in given Mode
    virtual int Compare (Some Item1, Some Item2, int Mode) const;
    /// Compare entry with a key; for Vector just compare (int)Key vs (int)Item
    virtual int CompareKey (Some Item, ConstSome Key, int Mode) const;
    /// Float a element up or down until it becomes > previous and < next element
    int Float (int n, int Mode = 0);
    /// Сделать вектор точной копией другого
    bool Copy (Vector &Other);
};

#endif // __VECTOR_H__
