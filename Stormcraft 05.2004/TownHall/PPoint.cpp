#include "PPoint.h"

CPPoint::CPPoint()
{
	head = NULL;
	tail = NULL;

	editGroup = 0;
	editType = 0;
	editMode = false;

	CreateTestData();
}

CPPoint::~CPPoint()
{
	Cleanup();
}

bool CPPoint::IsInside(const Point &testPoint, const Rect &rect)
{
	Line line1, line2;
	int intersectCount = 0;

	line1.a.x = testPoint.x;
	line1.a.y = testPoint.y;

	line1.b.x = testPoint.x + GetDistanceToRectCenter(testPoint, rect)*2.0f;
	line1.b.y = testPoint.y;

	for (int i = 0; i < 4; ++i)
	{
		line2.a.x = rect.points[i].x;
		line2.a.y = rect.points[i].y;

		line2.b.x = rect.points[i+1].x;
		line2.b.y = rect.points[i+1].y;

		if (LinesIntersect(line1, line2))
			++intersectCount;

		if (intersectCount > 1)
			return false;
	}

	if (intersectCount)
		return true;
	else
		return false;
}

bool CPPoint::LinesIntersect(const Line &line1, const Line &line2)
{	
	Point a,b,c,d;
	a=line1.a;	
	b=line1.b;	
	c=line2.a;	
	d=line2.b;	
	float d1 = DIR(c, d, a);	
	float d2 = DIR(c, d, b);
	float d3 = DIR(a, b, c);
	float d4 = DIR(a, b, d);
	
	if (((d1 > 0 && d2 < 0) || (d1 < 0 && d2 > 0)) && 
	   (((d3 > 0 && d4 < 0) || (d3 < 0 && d4 > 0))))		
		return true;		
	else if((d1 == 0) && ONSEG(c, d, a))			
		return true;		
	else if((d2 == 0) && ONSEG(c, d, b))			
		return true;		
	else if((d3 == 0) && ONSEG(a, b, c))			
		return true;		
	else if((d4 == 0) && ONSEG(a, b, d))			
		return true;		
	else 			
		return false;
}

float CPPoint::GetDistanceToRectCenter(const Point &point, const Rect &rect)
{
	float minX, maxX, minY, maxY, distance;

	minX = MIN4(rect.points[0].x, rect.points[1].x, rect.points[2].x, rect.points[3].x);
	maxX = MAX4(rect.points[0].x, rect.points[1].x, rect.points[2].x, rect.points[3].x);

	minY = MIN4(rect.points[0].y, rect.points[1].y, rect.points[2].y, rect.points[3].y);
	maxY = MAX4(rect.points[0].y, rect.points[1].y, rect.points[2].y, rect.points[3].y);

	distance = sqrt((point.x - ((maxX - minX)/2)) + (point.y - ((maxY - minY)/2)));

	return distance;
}

void CPPoint::AddPathingPoint(const PPoint &point)
{
	PPointNode *temp = new PPointNode;

	temp->nextNode = NULL;

	temp->pPoint.recordID = point.recordID;
	temp->pPoint.group = point.group;
	temp->pPoint.nodeNumber = point.nodeNumber;
	temp->pPoint.continent = point.continent;
	temp->pPoint.x = point.x;
	temp->pPoint.y = point.y;
	temp->pPoint.z = point.z;
	temp->pPoint.reserved = point.reserved;
	temp->pPoint.type = point.type;

	if (head)
		tail->nextNode=temp;
	else
		head=temp;

	tail=temp;
}

void CPPoint::Cleanup()
{
	PPointNode *current = head;
	PPointNode *temp;

	while (current)
	{
		temp = current;
		current = current->nextNode;
		delete temp;
	}

	head = NULL;
}

void CPPoint::SpawnPathPoints()
{
	PPointNode *current = head;
	_Location loc;
	CCreature *pCreature;
	char name[64] = {""};
	unsigned long model;

	int i = 0;
	while (current)
	{
		loc.X = current->pPoint.x;
		loc.Y = current->pPoint.y;
		loc.Z = current->pPoint.z;

		sprintf(name, "ID=%d group=%d node=%d", current->pPoint.recordID, current->pPoint.group, current->pPoint.nodeNumber);

		switch (current->pPoint.type)
		{
		case TYPE_OPENAREA:
			model = WARLOCK_WARD;
			break;
		case TYPE_LAND:
			model = EYE_WARD;
			break;
		case TYPE_WATER:
			model = ICE_WARD;
			break;
		case TYPE_AIR:
			model = LIGHTNING_WARD;
			break;
		}

		pCreature = RealmServer.GenerateCreature(model, name, current->pPoint.continent, loc, 0.0f);
		RegionManager.ObjectNew(*pCreature, current->pPoint.continent, loc.X, loc.Y);

		current = current->nextNode;
	}

}

void CPPoint::AddPoint(CClient *pClient)
{
	_Location loc;
	char name[64];
	PPoint point;
	unsigned long model;

	point.recordID = 0; // not used yet
	point.type = editType;
	point.continent = pClient->pPlayer->Data.Continent;
	point.group = editGroup;
	point.nodeNumber = 0; // not used yet
	point.x = pClient->pPlayer->Data.Loc.X;
	point.y = pClient->pPlayer->Data.Loc.Y;
	point.z = pClient->pPlayer->Data.Loc.Z;

	loc.X = point.x;
	loc.Y = point.y;
	loc.Z = point.z;

	switch (point.type)
	{
	case TYPE_OPENAREA:
		model = WARLOCK_WARD;
		break;
	case TYPE_LAND:
		model = EYE_WARD;
		break;
	case TYPE_WATER:
		model = ICE_WARD;
		break;
	case TYPE_AIR:
		model = LIGHTNING_WARD;
		break;
	}

//	AddPathingPoint(point);

	sprintf(name, "ID=%d group=%d node=%d", point.recordID, point.group, point.nodeNumber);

	CCreature *pCreature = RealmServer.GenerateCreature(model, name, point.continent, loc, 0.0f);
	RegionManager.ObjectNew(*pCreature, point.continent, loc.X, loc.Y);
}

void CPPoint::CreateTestData()
{
	PPoint pPoint;

	pPoint.recordID = 0;
	pPoint.group = 1;
	pPoint.nodeNumber = 1;
	pPoint.continent = 1;
	pPoint.x = 307.0f;
	pPoint.y = -4724.0f;
	pPoint.z = 10.0f;
	pPoint.reserved = 0;
	pPoint.type = TYPE_LAND;

	for (int i = 0; i < 10; ++i)
	{
		AddPathingPoint(pPoint);
		++pPoint.recordID;
		++pPoint.nodeNumber;
		pPoint.x += 1.0f;
	}
}

bool CPPoint::GetPPoint(const int pPointID, PPoint &point)
{
	PPointNode *current = head;

	while (current)
	{
		if (current->pPoint.recordID == pPointID)
		{
			point = current->pPoint;
			return true;
		}
		current = current->nextNode;
	}

	return false;
}