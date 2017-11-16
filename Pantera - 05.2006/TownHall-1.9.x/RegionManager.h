/*
The Region Manager's job is to facilitate the interaction between objects when they are
near each other.
*/

#ifndef REGIONMANAGER_H
#define REGIONMANAGER_H

#include "stdafx.h"
#include "Index.h"
#include "Creature.h" // for wander

#ifdef __CYGWIN__
#include <map>
#define hash_map map // for cygwin compatibility
#else
#include <hash_map>
#endif

using namespace std;

#define REGIONSIZE (100.0f)
#define UNITSIZE (4.166666640625f)
#define HEIGHTMAP_MASK 0xFFFE // this mask determines the accuracy of the map
// Possible values: 0xFFFF (max accuracy, ~400MB RAM), 0xFFFE (~100MB), 0xFFFC (~25MB)

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
		isDisabled = false;
		nPlayers=0;
		lastWander=0;
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
		RegionObjectNode *pNext=0;
		while(pNode)
		{
			pNext=pNode->pNext; //chance that pNode will be obliterated by the end of this :(
			if (pNode->pObject!=&Object)
				pNode->pObject->ObjectUpdates(Object);
			pNode=pNext;
		}
	}

	void ObjectNears(CWoWObject &Object)
	{// O(n)
		RegionObjectNode *pNode=pList;
		RegionObjectNode *pNext=0;
		while(pNode)
		{
			pNext=pNode->pNext; //chance that pNode will be obliterated by the end of this :(
			if (pNode->pObject!=&Object)
				pNode->pObject->ObjectNears(Object);
			pNode=pNext;
		}
	}

	void ObjectFades(CWoWObject &Object)
	{// O(n)
		RegionObjectNode *pNode=pList;
		RegionObjectNode *pNext=0;
		while(pNode)
		{
			pNext=pNode->pNext; //chance that pNode will be obliterated by the end of this :(
			if (pNode->pObject!=&Object)
				pNode->pObject->ObjectFades(Object);
			pNode=pNext;
		}
	}

	void RegionNears(CWoWObject &Object)
	{// O(n)
		RegionObjectNode *pNode=pList;
		RegionObjectNode *pNext=0;
		while(pNode)
		{
			pNext=pNode->pNext; //chance that pNode will be obliterated by the end of this :(
			if (pNode->pObject!=&Object)
				Object.ObjectNears(*pNode->pObject);
			pNode=pNext;
		}
	}

	void RegionFades(CWoWObject &Object)
	{// O(n)
		RegionObjectNode *pNode=pList;
		RegionObjectNode *pNext=0;
		while(pNode)
		{
			pNext=pNode->pNext; //chance that pNode will be obliterated by the end of this :(
			if (pNode->pObject!=&Object)
				Object.ObjectFades(*pNode->pObject);
			pNode=pNext;
		}
	}

	bool RegionWanderCreatures(time_t now, bool force) // return value: false = no more wandering; true = more wandering
		// force makes the function wander even w/o players (ex. as an adjacent)
	{// O(n)
		if(!force && !nPlayers) return false;
		if(difftime(now,lastWander) < 15.0) return true; //min. 15 seconds for wander
		lastWander=now;
		RegionObjectNode *pNode=pList;
		RegionObjectNode *pNext=0;
		CCreature *pCreature=NULL;
		while(pNode)
		{
			pNext=pNode->pNext;
			if (pNode->pObject->type==OBJ_CREATURE)
			{
				pCreature=(CCreature *)pNode->pObject;
				// if(pCreature->Data.NPCType<=1) //gossip ppl are allowed to wander
				if(pCreature->FirstPoint > 0 || pCreature->bIsSummon || pCreature->AI_Actions.size() > 0)
				{
					// get fucked
					pCreature->AI_Update();
				} else {
					pCreature->Wander();
				}
			}
			pNode=pNext;
		}
		return true;
	}

	inline void AddPathNode(CPathGroup *pGroup, _Location *pPoint)
	{
		RegionPathNode *pNode = new RegionPathNode;
		pNode->pGroup=pGroup;
		pNode->pPoint=pPoint;
		pNode->pNext=pPathList;
		pPathList=pNode;
	}

	bool isDisabled;
	unsigned long nPlayers;
	time_t lastWander;
	RegionObjectNode *pList;
	RegionPathNode *pPathList;
	class CContinent* pContinent;
	CRegion* Adjacent[3][3];
	//
	// 0 1 2 y
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
	CContinent(unsigned long ID, float xTop, float xBottom, float xLeft, float xRight);
	~CContinent();
	float Top;
	float Bottom;
	float Left;
	float Right;
	unsigned long ID;

	unsigned long nRegions;
	unsigned long Rows;
	unsigned long Columns;
	CIndex<CRegion*> Regions;
	stdext::hash_map<unsigned long,float> HeightMap;

	inline CRegion *RegionByLoc(float X, float Y) 
	{
		unsigned long R=(int)((X-Bottom)/REGIONSIZE);
		unsigned long C=(int)((Y-Right)/REGIONSIZE);
		if (R>=Rows) R=Rows-1;
		if (C>=Columns) C=Columns-1;
		return Regions[R*Columns+C];
	}
	inline float HeightAt(float X,float Y)
	{
		long closestY = (long)(Y/UNITSIZE) << 1; //needs to be multiplied by 2
		long closestX = (long)(X/UNITSIZE);
		closestX &= HEIGHTMAP_MASK;
		closestX <<=16;
		closestY &= HEIGHTMAP_MASK;
		stdext::hash_map<unsigned long,float>::iterator i;
		i=HeightMap.find(closestX+closestY);
		if(i==HeightMap.end()) return 0;
		return i->second;
	}
};

class CRegionManager
{
public:
	CRegionManager(void);
	~CRegionManager(void);

	stdext::hash_map<unsigned long,CRegion*> ObjectRegions;

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

	//CContinent *Continents[2];

	stdext::hash_map<unsigned long,CContinent *> Continents;

	static inline float Distance(_Location &lA, _Location &lB)
	{
		float A=lA.X-lB.X;
		float B=lA.Y-lB.Y;
		return sqrtf((A*A)+(B*B));
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

#endif // REGIONMANAGER_H
