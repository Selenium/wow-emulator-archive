/*
The Region Manager's job is to facilitate the interaction between objects when they are
near each other.


/**/


#pragma once
#include "stdafx.h"
#include "Index.h"
#include <map>
using namespace std;

#define REGIONSIZE (50.0f)

struct RegionObjectNode
{
	CWoWObject *pObject;
	RegionObjectNode *pNext;
};

struct RegionPathNode
{
	_Location *pPoint;
	CPathGroup *pGroup;
	RegionPathNode *pNext;
};

enum Adjacency
{
	ADJ_NONE = 0,
	ADJ_TOPLEFT,
	ADJ_TOP,
	ADJ_TOPRIGHT,
	ADJ_LEFT,
	ADJ_SAME,
	ADJ_RIGHT,
	ADJ_LOWERLEFT,
	ADJ_LOWER,
	ADJ_LOWERRIGHT
};

class CRegion
{
public:
	CRegion()
	{// O(1)
		pList=0;
		for (int i = 0 ; i < 3 ; i++)
			for (int j = 0 ; j < 3 ; j++)
				Adjacent[i][j]=0;
		pPathList=0;
	}
	~CRegion()
	{// O(n)
		while(pList)
		{
			RegionObjectNode *pNext=pList->pNext;
			delete pList;
			pList=pNext;
		}
		while(pPathList)
		{
			RegionPathNode *pNext=pPathList->pNext;
			delete pPathList;
			pPathList=pNext;
		}
	}
	inline void AddObject(CWoWObject &Object)
	{// O(1)
		RegionObjectNode *pNew=new RegionObjectNode;
		pNew->pNext=pList;
		pNew->pObject=&Object;
		pList=pNew;
	}

	inline void RemoveObject(CWoWObject &Object)
	{// O(n)
		RegionObjectNode *pNode=pList;
		RegionObjectNode *pLast=0;
		while(pNode)
		{
			if (pNode->pObject==&Object)
			{
				if (pLast)
					pLast->pNext=pNode->pNext;
				else
					pList=pNode->pNext;
				delete pNode;
				return;
			}
			pLast=pNode;
			pNode=pNode->pNext;
		}
	}

	void ObjectUpdates(CWoWObject &Object)
	{// O(n)
		RegionObjectNode *pNode=pList;
		while(pNode)
		{
			if (pNode->pObject!=&Object)
				pNode->pObject->ObjectUpdates(Object);
			pNode=pNode->pNext;
		}
	}

	void ObjectNears(CWoWObject &Object)
	{// O(n)
		RegionObjectNode *pNode=pList;
		while(pNode)
		{
			if (pNode->pObject!=&Object)
				pNode->pObject->ObjectNears(Object);
			pNode=pNode->pNext;
		}
	}

	void ObjectFades(CWoWObject &Object)
	{// O(n)
		RegionObjectNode *pNode=pList;
		while(pNode)
		{
			if (pNode->pObject!=&Object)
				pNode->pObject->ObjectFades(Object);
			pNode=pNode->pNext;
		}
	}

	void RegionNears(CWoWObject &Object)
	{// O(n)
		RegionObjectNode *pNode=pList;
		while(pNode)
		{
			if (pNode->pObject!=&Object)
				Object.ObjectNears(*pNode->pObject);
			pNode=pNode->pNext;
		}
	}

	void RegionFades(CWoWObject &Object)
	{// O(n)
		RegionObjectNode *pNode=pList;
		while(pNode)
		{
			if (pNode->pObject!=&Object)
				Object.ObjectFades(*pNode->pObject);
			pNode=pNode->pNext;
		}
	}

	inline void AddPathNode(CPathGroup *pGroup, _Location *pPoint)
	{
		RegionPathNode *pNode = new RegionPathNode;
		pNode->pGroup=pGroup;
		pNode->pPoint=pPoint;
		pNode->pNext=pPathList;
		pPathList=pNode;
	}


	RegionObjectNode *pList;
	RegionPathNode *pPathList;
	class CContinent* pContinent;
	CRegion* Adjacent[3][3];
	//
    //   0 1 2 y
	// 0 X X X 
	// 1 X - X
	// 2 X X X
    // x
	Adjacency IsAdjacent(CRegion &pRegion)
	{// O(1)
		if (Adjacent[0][0]==&pRegion) return ADJ_TOPLEFT;
		if (Adjacent[0][1]==&pRegion) return ADJ_TOP;
		if (Adjacent[0][2]==&pRegion) return ADJ_TOPRIGHT;
		if (Adjacent[1][0]==&pRegion) return ADJ_LEFT;
		if (Adjacent[1][1]==&pRegion) return ADJ_SAME;
		if (Adjacent[1][2]==&pRegion) return ADJ_RIGHT;
		if (Adjacent[2][0]==&pRegion) return ADJ_LOWERLEFT;
		if (Adjacent[2][1]==&pRegion) return ADJ_LOWER;
		if (Adjacent[2][2]==&pRegion) return ADJ_LOWERRIGHT;
		return ADJ_NONE;
	}
};

class CContinent
{
public:
	CContinent(float xTop, float xBottom, float xLeft, float xRight);
	~CContinent();
	float Top;
	float Bottom;
	float Left;
	float Right;

	unsigned long nRegions;
	unsigned long Rows;
	unsigned long Columns;
	CIndex<CRegion*> Regions;

	inline CRegion *RegionByLoc(float X, float Y)
	{
		unsigned long R=(int)((X-Bottom)/REGIONSIZE);
		unsigned long C=(int)((Y-Right)/REGIONSIZE);
		if (R>=Rows) R=Rows-1;
		if (C>=Columns) C=Columns-1;
		return Regions[R*Columns+C];
	}
};

class CRegionManager
{
public:
	CRegionManager(void);
	~CRegionManager(void);

	map<unsigned long,CRegion*> ObjectRegions;

	// region updating use only:
	// switching same-continent regions
	void ObjectMovement(CWoWObject &Object, float NewX, float NewY);
	// leaves its region...
	void ObjectRemove(CWoWObject &Object);
	// new object on this continent
	void ObjectNew(CWoWObject &Object, unsigned long Continent, float NewX, float NewY);

	void ObjectResend(CWoWObject &Object);

	bool GetNearestPathGroup(CPathGroup **ppGroup, unsigned long Continent, _Location &Loc);
	bool GetNearestPathGroup(CPathGroup **ppGroup, unsigned long Continent, _Location &Origin, _Location &Destination);

	CContinent *Continents[2];

	static inline float Distance(_Location &lA, _Location &lB)
	{
		float A=lA.X-lB.X;
		float B=lA.Y-lB.Y;
		return sqrt((A*A)+(B*B));
	}

	// todo: 3 dimensional distance
//	static inline float DistanceXYZ(_Location &lA, _Location &lB)
//	{
//		float A=lA.X-lB.X;
//		float B=lA.Y-lB.Y;
//		return sqrt((A*A)+(B*B));
//	}
};

// kalimdor:
// top 11700
// bottom -12750
// left 3725
// right -8500
// (width) 12225
// (height) 24450

// azeroth:
// top 5200
// bottom -16000
// left 3725
// right -6400