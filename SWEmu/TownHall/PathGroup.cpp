#include "stdafx.h"
#include "PathGroup.h"

CPathGroup::CPathGroup(void):CWoWObject(OBJ_PATHGROUP)
{
	AdjacentGroups=0;
}

CPathGroup::~CPathGroup(void)
{
	Delete();
	while(AdjacentGroups)
	{
		GroupConnector *pNext = AdjacentGroups->pNext;
		delete AdjacentGroups;
		AdjacentGroups=pNext;
	}
	AdjacentGroups=0;
}

void CPathGroup::Clear()
{
	while(AdjacentGroups)
	{
		GroupConnector *pNext = AdjacentGroups->pNext;
		delete AdjacentGroups;
		AdjacentGroups=pNext;
	}
	AdjacentGroups=0;
	CWoWObject::Clear();
}


bool CPathGroup::StoringData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	Storage.Allocate(sizeof(PathGroupData));
	memcpy(Storage.Data,&Data,sizeof(PathGroupData));
	return true;
}

bool CPathGroup::LoadingData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	memcpy(&Data,Storage.Data,sizeof(PathGroupData));
	return true;
}
