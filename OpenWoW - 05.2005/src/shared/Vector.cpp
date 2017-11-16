/*
    Crystal Space Vector class
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

#include <stdlib.h>
#include <string.h>
#include "sysdefs.h"
#include "cs/csvector.h"

csVector::csVector (int ilimit, int ithreshold)
{
    limit = ilimit;
    if (ilimit)
        root = (Some *)malloc (ilimit * sizeof (Some));
    else
        root = NULL;
    count = 0; threshold = ithreshold;
}

csVector::~csVector ()
{
    //not much sense to call DeleteAll () since even for inherited classes
    //anyway will be called csVector::FreeItem which is empty.
    //DeleteAll ();
    if (root) free (root);
}

void csVector::DeleteAll ()
{
    while (count > 0)
    {
        if (!FreeItem (root [count - 1]))
            break;
        count--;
    }
    SetLength (count);
    while (count > 0)
        Delete (count - 1);
}

void csVector::SetLength (int n)
{
    count = n;
    if ((n > limit) || ((limit > threshold) && (n < limit - threshold)))
    {
        n = ((n + threshold - 1) / threshold) * threshold;
        if (n)
            root = (Some *)realloc (root, n * sizeof (Some));
        else
        {
            free (root);
            root = NULL;
        }
        limit = n;
    }
}

bool csVector::FreeItem (Some Item)
{
    (void)Item;
    return true;
}

bool csVector::Delete (int n)
{
    if (n < count)
    {
        if (!FreeItem (root [n]))
            return false;
        int ncount = count - 1;
        if (ncount != n)
            memmove (&root [n], &root [n + 1], (ncount - n) * sizeof (Some));
        SetLength (count = ncount);
        return true;
    }
    else
        return false;
}

bool csVector::Replace (int n, Some what)
{
    if (n < count)
    {
        if (!FreeItem (root [n]))
            return false;
        root [n] = what;
        return true;
    }
    else
        return false;
}

bool csVector::Insert (int n, Some Item)
{
    if (n <= count)
    {
        SetLength (count + 1); // Increments 'count' as a side-effect.
        uint movebytes = (count - n - 1) * sizeof (Some);
        if (movebytes)
            memmove (&root [n + 1], &root [n], movebytes);
        root [n] = Item;
        return true;
    }
    else
        return false;
}

bool csVector::Shift (int n1, int n2)
{
    if (n1 < 0 || n2 < 0 || n2 >= count || n2 >= count)
        return false;

    Some x = root [n1];
    if (n1 < n2)
        memmove (&root [n1], &root [n1 + 1], (n2 - n1) * sizeof (Some));
    else
        memmove (&root [n2 + 1], &root [n2], (n1 - n2) * sizeof (Some));

    root [n2] = x;

    return true;
}

int csVector::Find (Some which, bool reversedir) const
{
    int i;

    if (reversedir)
    {
        for (i = Length () - 1; i >= 0; i--)
            if (root [i] == which)
                return i;
    }
    else
    {
        for (i = 0; i < Length (); i++)
            if (root [i] == which)
                return i;
    }

    return -1;
}

int csVector::FindKey (ConstSome Key, int Mode) const
{
    for (int i = 0; i < Length (); i++)
        if (CompareKey (root [i], Key, Mode) == 0)
            return i;
    return -1;
}

int csVector::FindSortedKey (ConstSome Key, int Mode) const
{
    int l = 0, r = Length () - 1;
    int CompMode = Mode & ~CSV_FIND_MODE_MASK;
    int m = 0, cmp = 0;

    while (l <= r)
    {
        m = (l + r) / 2;
        cmp = CompareKey (root [m], Key, CompMode);

        if (cmp == 0)
            return m;
        else if (cmp < 0)
            l = m + 1;
        else
            r = m - 1;
    }

    switch (Mode & CSV_FIND_MODE_MASK)
    {
    case CSV_FIND_NEAREST_SMALLER:
        return cmp < 0 ? m : m - 1;
    case CSV_FIND_NEAREST_LARGER:
        return cmp >= 0 ? m : m + 1;
    }

    return -1;
}

int csVector::InsertSorted (Some Item, int *oEqual, int Mode)
{
    int m = 0, l = 0, r = Length () - 1;
    while (l <= r)
    {
        m = (l + r) / 2;
        int cmp = Compare (root [m], Item, Mode);

        if (cmp == 0)
        {
            if (oEqual)
                *oEqual = m;
            Insert (++m, Item);
            return m;
        }
        else if (cmp < 0)
            l = m + 1;
        else
            r = m - 1;
    }
    if (r == m)
        m++;
    Insert (m, Item);
    if (oEqual)
        *oEqual = -1;
    return m;
}

void csVector::QuickSort (int Left, int Right, int Mode)
{
recurse:
    int i = Left, j = Right;
    int x = (Left + Right) / 2;
    do
    {
        while ((i != x) && (Compare (Get (i), Get (x), Mode) < 0))
            i++;
        while ((j != x) && (Compare (Get (j), Get (x), Mode) > 0))
            j--;
        if (i < j)
        {
            Exchange (i, j);
            if (x == i)
                x = j;
            else if (x == j)
                x = i;
        }
        if (i <= j)
        {
            i++;
            if (j > Left)
                j--;
        }
    } while (i <= j);

    if (j - Left < Right - i)
    {
        if (Left < j)
            QuickSort (Left, j, Mode);
        if (i < Right)
        {
            Left = i;
            goto recurse;
        }
    }
    else
    {
        if (i < Right)
            QuickSort (i, Right, Mode);
        if (Left < j)
        {
            Right = j;
            goto recurse;
        }
    }
}

int csVector::Compare (Some Item1, Some Item2, int Mode) const
{
    (void)Mode;
    return ((int)Item1 > (int)Item2) ? +1 : ((int)Item1 == (int)Item2) ? 0 : -1;
}

int csVector::CompareKey (Some Item, ConstSome Key, int Mode) const
{
    (void)Mode;
    return (Item > Key) ? +1 : (Item == Key) ? 0 : -1;
}

bool csVector::Copy (csVector &Other)
{
    DeleteAll ();
    threshold = Other.threshold;
    SetLength (Other.count);
    memcpy (root, Other.root, count * sizeof (Some));
    return true;
}

int csVector::Float (int n, int Mode)
{
    if (n < 0 || n >= count || count == 1)
        return n;

    int n1 = n;

    while ((n > 0) && (Compare (root [n], root [n - 1], Mode) < 0))
    {
        Exchange (n, n - 1);
        n--;
    }

    if (n1 != n)
        return n;

    // Re-use the variable
    n1 = count - 1;
    while ((n < n1) && (Compare (root [n], root [n + 1], Mode) > 0))
    {
        Exchange (n, n + 1);
        n++;
    }

    return n;
}
