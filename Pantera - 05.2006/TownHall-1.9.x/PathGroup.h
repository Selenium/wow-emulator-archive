#ifndef PATHGROUP_H
#define PATHGROUP_H

#include "WoWObject.h"

#define PATH_OPENAREA 1
#define PATH_LAND     2
#define PATH_WATER    3
#define PATH_AIR      4

struct GroupConnector
{
	unsigned long ConnectedGroup;
	_Location SharedPoint;
	GroupConnector *pNext;
};

struct PathGroupData
{
	unsigned long Continent;
	unsigned long Type;
	unsigned long nPoints;
	unsigned char Adjacency[50];
	_Location Points[20];
};

class CPathGroup:public CWoWObject
{
public:
	CPathGroup(void);
	~CPathGroup(void);

	PathGroupData Data;

	void Clear();

	bool StoringData(ObjectStorage &Storage);
	bool LoadingData(ObjectStorage &Storage);
	unsigned long DataStorageSize() {return sizeof(PathGroupData);};

	GroupConnector *AdjacentGroups;
};

#endif // PATHGROUP_H
