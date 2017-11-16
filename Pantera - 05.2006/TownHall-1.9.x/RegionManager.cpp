#include "RegionManager.h"
#include "Globals.h"

CContinent::CContinent(unsigned long id, float xTop, float xBottom, float xLeft, float xRight)
{
	Rows=(unsigned long)((xTop-xBottom)/REGIONSIZE);
	Columns=(unsigned long)((xLeft-xRight)/REGIONSIZE);
	ID = id;
	Top=xTop;
	Left=xLeft;
	Right=xRight;
	Bottom=xBottom;
	nRegions=Rows*Columns;
	Regions.Resize(nRegions);
	unsigned long i;
	// Allocate regions
	for ( i = 0 ; i < nRegions ; i++)
	{
		Regions[i]=new CRegion;
		Regions[i]->pContinent=this;
	}
	// Calculate adjacent regions now

#define CalcRegion(row,col) (((row)*Columns)+(col))
	for (i = 0 ; i < nRegions ; i++)
	{
		CRegion* pRegion=Regions[i];
		unsigned long R=i/Columns;
		unsigned long C=i%Columns;
		if (R>0)
		{
			// top middle
			pRegion->Adjacent[0][1]=Regions[CalcRegion(R-1,C)];
			if (C>0)
			{
				// top left
				pRegion->Adjacent[0][0]=Regions[CalcRegion(R-1,C-1)];
			}
			if (C<Columns-1)
			{
				// top right
				pRegion->Adjacent[0][2]=Regions[CalcRegion(R-1,C+1)];
			}
		}
		pRegion->Adjacent[1][1]=pRegion;// adjacent to itself! ;)
		if (C>0)
		{
			// middle left
			pRegion->Adjacent[1][0]=Regions[CalcRegion(R,C-1)];
		}
		if (C<Columns-1)
		{
			// middle right
			pRegion->Adjacent[1][2]=Regions[CalcRegion(R,C+1)];
		}
		if (R<Rows-1)
		{
			// lower middle
			pRegion->Adjacent[2][1]=Regions[CalcRegion(R+1,C)];
			if (C>0)
			{
				// lower left
				pRegion->Adjacent[2][0]=Regions[CalcRegion(R+1,C-1)];
			}
			if (C<Columns-1)
			{
				// lower right
				pRegion->Adjacent[2][2]=Regions[CalcRegion(R+1,C+1)];
			}
		}
	}
#undef CalcRegion
}

CContinent::~CContinent()
{
	Regions.Cleanup();
	HeightMap.clear();
}


CRegionManager::CRegionManager(void)
{
	/*	// azeroth
	// top 5200
	// bottom -16000
	// left 3725
	// right -6400
	Continents[0]=new CContinent(0, 5200.0f,-16000.0f,3700.f,-6400.0f);

	// kalimdor
	// top 11700
	// bottom -12750
	// left 3725
	// right -8500
	Continents[1]=new CContinent(1, 11700.0f,-12700.0f,3700.f,-8500.0f);
	*/
	Continents[0]=new CContinent(0,6400.00f,-16000.00f,15466.67f,-6400.00f);
	Continents[1]=new CContinent(1,17066.67f,-12800.00f,17066.67f,-8533.33f);
	Continents[30]=new CContinent(30,1600.00f,-2133.33f,1066.67f,-1600.00f);
	Continents[33]=new CContinent(33,1066.67f,-1600.00f,3733.33f,0.00f);
	Continents[36]=new CContinent(36,1066.67f,-2133.33f,1066.67f,-2133.33f);
	Continents[37]=new CContinent(37,1600.00f,-1066.67f,1600.00f,-1300.00f);
	Continents[47]=new CContinent(47,2666.67f,0.00f,2666.67f,0.00f);
	Continents[129]=new CContinent(129,3200.00f,0.00f,2666.67f,-533.33f);
	Continents[169]=new CContinent(169,3733.33f,-3733.33f,0.00f,-4266.67f);
	Continents[189]=new CContinent(189,2666.67f,-533.33f,2133.33f,-1066.67f);
	Continents[209]=new CContinent(209,2133.33f,-1066.67f,1600.00f,0.00f);
	Continents[269]=new CContinent(269,3733.33f,-2666.67f,8000.00f,-533.33f);
	Continents[289]=new CContinent(289,533.33f,-533.33f,533.33f,-1066.67f);
	Continents[309]=new CContinent(309,0.00f,-13333.33f,0.00f,-3200.00f);
	Continents[329]=new CContinent(329,4266.67f,0.00f,0.00f,-4800.00f);
	Continents[451]=new CContinent(451,17066.67f,0.00f,17066.67f,-17066.67f);
	Continents[469]=new CContinent(469,0.00f,-8533.33f,0.00f,-2133.33f);
	Continents[489]=new CContinent(489,2133.33f,0.00f,2133.33f,0.00f);
	Continents[529]=new CContinent(529,2133.33f,0.00f,2133.33f,0.00f);
}

CRegionManager::~CRegionManager(void)
{
	/*	delete Continents[0];
	delete Continents[1];*/
	for(stdext::hash_map<unsigned long,CContinent *>::iterator i=Continents.begin();i!=Continents.end();i++) delete i->second;
	Continents.clear();
}

void CRegionManager::ObjectMovement(CWoWObject &Object, float NewX, float NewY)
{// O(1) for this function, O(n) for each fading region
	CRegion *pOldRegion=ObjectRegions[Object.guid];
	if (!pOldRegion)
	{
		// probably new object, we dont handle that here! use ObjectNew
		return;
	}
	CRegion *pNewRegion=pOldRegion->pContinent->RegionByLoc(NewX,NewY);
	// a region will ALWAYS be returned.
	if (pOldRegion==pNewRegion)
		return; // same region

	int adj = pOldRegion->IsAdjacent(*pNewRegion);
	if(adj == ADJ_NONE)
	{
		ObjectRemove(Object);
		ObjectNew(Object, pOldRegion->pContinent->ID, NewX, NewY);
		return;
	}
	// remove from old region, enter new
	pOldRegion->RemoveObject(Object);
	pNewRegion->AddObject(Object);
	ObjectRegions[Object.guid]=pNewRegion;
	if(Object.type==OBJ_PLAYER)
	{
		pOldRegion->nPlayers--;
		if(!pNewRegion->nPlayers) RealmServer.ActiveRegionsCreatureMove.push(pNewRegion);
		pNewRegion->nPlayers++;
	}

	// this returns our direction of regional movement if we're moving to
	// an adjacent region
	switch(adj)
	{
	case ADJ_TOPLEFT:
		{
			// moving away from lower right
			// . . X
			// . . X
			// X X X
			if (CRegion *pRegion=pOldRegion->Adjacent[2][2])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			if (CRegion *pRegion=pOldRegion->Adjacent[0][2])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			if (CRegion *pRegion=pOldRegion->Adjacent[1][2])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			if (CRegion *pRegion=pOldRegion->Adjacent[2][1])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			if (CRegion *pRegion=pOldRegion->Adjacent[2][0])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			// moving toward upper left
			if (CRegion *pRegion=pNewRegion->Adjacent[0][0])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[0][1])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[1][0])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[2][0])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[0][2])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
		}
		break;
	case ADJ_TOP:
		{
			// moving away from lower
			// . . .
			// . . .
			// X X X
			if (CRegion *pRegion=pOldRegion->Adjacent[2][0])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			if (CRegion *pRegion=pOldRegion->Adjacent[2][1])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			if (CRegion *pRegion=pOldRegion->Adjacent[2][2])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			// moving toward top
			if (CRegion *pRegion=pNewRegion->Adjacent[0][0])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[0][1])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[0][2])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
		}
		break;
	case ADJ_TOPRIGHT:
		{
			// moving away from lower left
			// X . .
			// X . .
			// X X X
			if (CRegion *pRegion=pOldRegion->Adjacent[2][0])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			if (CRegion *pRegion=pOldRegion->Adjacent[2][1])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			if (CRegion *pRegion=pOldRegion->Adjacent[1][0])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			if (CRegion *pRegion=pOldRegion->Adjacent[2][2])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			if (CRegion *pRegion=pOldRegion->Adjacent[0][0])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}

			// moving toward top right
			if (CRegion *pRegion=pNewRegion->Adjacent[1][2])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[0][1])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[0][2])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[0][0])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[2][2])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
		}
		break;
	case ADJ_LEFT:
		{
			// moving away from right
			// . . X
			// . . X
			// . . X
			if (CRegion *pRegion=pOldRegion->Adjacent[0][2])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			if (CRegion *pRegion=pOldRegion->Adjacent[1][2])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			if (CRegion *pRegion=pOldRegion->Adjacent[2][2])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			// moving toward left
			if (CRegion *pRegion=pNewRegion->Adjacent[0][0])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[1][0])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[2][0])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
		}
		break;
	case ADJ_RIGHT:
		{
			// moving away from left
			// X . .
			// X . .
			// X . .
			if (CRegion *pRegion=pOldRegion->Adjacent[0][0])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			if (CRegion *pRegion=pOldRegion->Adjacent[1][0])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			if (CRegion *pRegion=pOldRegion->Adjacent[2][0])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			// moving toward right
			if (CRegion *pRegion=pNewRegion->Adjacent[0][2])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[1][2])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[2][2])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
		}
		break;
	case ADJ_LOWERLEFT:
		{
			// moving away from upper right
			// X X X
			// . . X
			// . . X
			if (CRegion *pRegion=pOldRegion->Adjacent[1][2])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			if (CRegion *pRegion=pOldRegion->Adjacent[0][2])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			if (CRegion *pRegion=pOldRegion->Adjacent[0][1])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[2][2])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[0][0])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			// moving toward lower left
			if (CRegion *pRegion=pNewRegion->Adjacent[1][0])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[2][0])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[2][1])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[2][2])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[0][0])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
		}
		break;
	case ADJ_LOWER:
		{
			// moving away from upper
			// X X X
			// . . .
			// . . .
			if (CRegion *pRegion=pOldRegion->Adjacent[0][0])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			if (CRegion *pRegion=pOldRegion->Adjacent[0][1])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			if (CRegion *pRegion=pOldRegion->Adjacent[0][2])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			// moving toward lower
			if (CRegion *pRegion=pNewRegion->Adjacent[2][0])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[2][1])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[2][2])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
		}
		break;
	case ADJ_LOWERRIGHT:
		{
			// moving away from upper left
			// X X X
			// X . .
			// X . .
			if (CRegion *pRegion=pOldRegion->Adjacent[0][2])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			if (CRegion *pRegion=pOldRegion->Adjacent[0][1])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			if (CRegion *pRegion=pOldRegion->Adjacent[0][0])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[1][0])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[2][0])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			// moving toward lower right
			if (CRegion *pRegion=pNewRegion->Adjacent[2][0])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[2][1])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[2][2])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[1][2])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
			if (CRegion *pRegion=pNewRegion->Adjacent[0][2])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
		}
		break;
	}
}

void CRegionManager::ObjectRemove(CWoWObject &Object)
{
	CRegion *pOldRegion=ObjectRegions[Object.guid];
	if (!pOldRegion)
	{
		// probably new object, wtf
		return;
	}
	pOldRegion->RemoveObject(Object);
	if(Object.type==OBJ_PLAYER) pOldRegion->nPlayers--;
	for (int i = 0 ; i < 3 ; i++)
		for (int j = 0 ; j < 3 ; j++)
			if (CRegion *pRegion=pOldRegion->Adjacent[i][j])
			{
				pRegion->ObjectFades(Object);
				pRegion->RegionFades(Object);
			}
			ObjectRegions[Object.guid]=0;
}

void CRegionManager::ObjectNew(CWoWObject &Object, unsigned long Continent, float NewX, float NewY)
{
	CRegion *pOldRegion=ObjectRegions[Object.guid];
	if (pOldRegion)
	{
		//  not a new object.
		ObjectRemove(Object);
	}
	/*if (Continent>=2)
	return;//... fuck you.*/
	CContinent *pContinent=Continents[Continent];
	if(!pContinent)
	{
		// Debug.Logf("Bad continent ID: %i.",Continent);
		return;
	}
	CRegion *pNewRegion=pContinent->RegionByLoc(NewX,NewY);
	pNewRegion->AddObject(Object);
	if(Object.type==OBJ_PLAYER)
	{
		if(!pNewRegion->nPlayers) RealmServer.ActiveRegionsCreatureMove.push(pNewRegion);
		pNewRegion->nPlayers++;
	}
	ObjectRegions[Object.guid]=pNewRegion;
	for (int i = 0 ; i < 3 ; i++)
		for (int j = 0 ; j < 3 ; j++)
			if (CRegion *pRegion=pNewRegion->Adjacent[i][j])
			{
				pRegion->ObjectNears(Object);
				pRegion->RegionNears(Object);
			}
}

void CRegionManager::ObjectResend(CWoWObject &Object)
{
	CRegion *pOldRegion=ObjectRegions[Object.guid];
	if (!pOldRegion)
		return;
	for (int i = 0 ; i < 3 ; i++)
		for (int j = 0 ; j < 3 ; j++)
			if (CRegion *pRegion=pOldRegion->Adjacent[i][j])
			{
				pRegion->ObjectUpdates(Object);
			}
}

bool CRegionManager::GetNearestPathGroup(CPathGroup **ppGroup, unsigned long Continent, _Location &Loc)
{
	// retrieve nearest path group, set the dereference of pointer passed to the pointer to the group ;)
	// ex: *ppGroup=pNearestPathGroup;
	/*if (Continent>=2)
	return false;*/
	CContinent *pContinent=Continents[Continent];
	if(!pContinent)
	{
		Debug.Logf("Bad continent ID: %i.",Continent);
		return false;
	}
	CRegion *pRegion=pContinent->RegionByLoc(Loc.X,Loc.Y);
	// do we have a list?
	RegionPathNode *pNearest=0;
	float Nearest=0.0f;
	RegionPathNode *pNode = pRegion->pPathList;
	while(pNode)
	{
		if (!pNearest)
		{
			pNearest=pNode;
			Nearest=Distance(*pNode->pPoint,Loc);
		}
		else
		{
			// compare the distance between this node and pNearest
			float Dist=Distance(*pNode->pPoint,Loc);
			if (Dist<Nearest)
			{
				Nearest=Dist;
				pNearest=pNode;
			}
		}

		pNode=pNode->pNext;
	}
	if (pNearest)
	{
		*ppGroup=pNearest->pGroup;
		return true;
	}

	// origin region checked, now lets check other regions :(
	for (int x = 0 ; x < 3 ; x++)
		for (int y = 0 ; y < 3 ; y++)
		{
			CRegion *pNewRegion=pRegion->Adjacent[x][y];
			if (pNewRegion && pNewRegion!=pRegion)
			{
				RegionPathNode *pNode = pRegion->pPathList;
				while(pNode)
				{
					if (!pNearest)
					{
						pNearest=pNode;
						Nearest=Distance(*pNode->pPoint,Loc);
					}
					else
					{
						// compare the distance between this node and pNearest
						float Dist=Distance(*pNode->pPoint,Loc);
						if (Dist<Nearest)
						{
							Nearest=Dist;
							pNearest=pNode;
						}
					}

					pNode=pNode->pNext;
				}
			}
		}

		if (pNearest)
		{
			*ppGroup=pNearest->pGroup;
			return true;
		}

		return false;
}

bool CRegionManager::GetNearestPathGroup(CPathGroup **ppGroup, unsigned long Continent, _Location &Origin, _Location &Destination)
{
	// TODO
	return false;
}
