/*****************************************************************************
EQIMBase, the Base C++ classes for handling EQIM
Copyright (C) 2003-2004 Lax

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License, version 2,
as published by the Free Software Foundation.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

Usage of these EQIM clients and derivatives subject you to the rules of
the EQIM network.  Access to the network is restricted to paying
subscribers of the online game EverQuest.  This software and the EQIM
protocol is provided in good faith to the EverQuest community, and not
intended for malicious purposes.  Usage of this software for malicious
purposes is prohibited and any distribution, usage, or mention of
malicious activity can and will be reported to the administrators of the
EQIM network.
******************************************************************************/
#ifndef INDEX_H
#define INDEX_H

#include <stdlib.h>
//#include <afxmt.h>

template <class Any>
class CIndex
{
public:
	CIndex()
	{
		Size=0;
		List=0;
	}

	CIndex(unsigned long InitialSize)
	{
		Size=0;
		List=0;
		Resize(InitialSize);
	}

	~CIndex()
	{// user is responsible for managing elements
		//		CSingleLock L(&CS,1);
		CLock(&CS,true);
		if (List)
			free(List);
		List=0;
		Size=0;
	}

	void Cleanup()
	{
		for (unsigned long i = 0 ; i < Size ; i++)
		{
			if (List[i])
			{
				delete List[i];
				List[i]=0;
			}
		}
	}

	void Resize(unsigned long NewSize)
	{
		//		CSingleLock L(&CS,1);
		CLock(&CS,true);
		if (List)
		{
			if (NewSize>Size)
			{
				// because we want to zero out the unused portions, we wont use realloc
				Any *NewList=(Any*)malloc(NewSize*sizeof(Any));
				memset(NewList,0,NewSize*sizeof(Any));
				memcpy(NewList,List,Size*sizeof(Any));
				free(List);
				List=NewList;
				Size=NewSize;
			}
		}
		else
		{
			List=(Any*)malloc(NewSize*sizeof(Any));
			memset(List,0,NewSize*sizeof(Any));
			Size=NewSize;
		}
	}

	// gets the next unused index, resizing if necessary
	inline unsigned long GetUnused()
	{
		//		CSingleLock L(&CS,1);
		CLock(&CS,true);
		unsigned long i;
		for ( i = 0 ; i < Size ; i++)
		{
			if (!List[i])
				return i;
		}
		Resize(Size+25);
		return i;
	}

	unsigned long Count()
	{
		//		CSingleLock L(&CS,1);
		CLock(&CS,true);
		unsigned long ret=0;
		for (unsigned long i = 0 ; i < Size ; i++)
		{
			if (List[i])
				ret++;
		}
		return ret;
	}

	unsigned long Size;
	Any *List;

	inline Any& operator+=(Any& Value){return List[GetUnused()]=Value;}
	inline Any& operator[](unsigned long Index){return List[Index];}
	//	CCriticalSection CS;
	CSemaphore CS;
};

#endif // INDEX_H
