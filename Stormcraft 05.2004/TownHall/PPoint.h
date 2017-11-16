#pragma once
#include "stdafx.h"
#include "Globals.h"
#include "Creature.h"

#define MIN(a,b) ((a)<(b)?(a):(b))
#define MAX(a,b) ((a)<(b)?(a):(b))
#define MIN4(a, b, c, d) MIN(MAX(a, b), MIN(c, d))
#define MAX4(a, b, c, d) MAX(MAX(a, b), MAX(c, d))
#define DIR(i, j, k) (((k.x - i.x) * (j.y - i.y)) - ((j.x - i.x) * (k.y - i.y)))
#define ONSEG(i, j, k) (MIN(i.x, j.x) <= k.x && k.x <= MAX(i.x, j.x) && \
	                   MIN(i.y, j.y) <= k.y && k.y <= MAX(i.y, j.y) ? true : false)
#define MAKERECT(points, rect) {rect.points[0] = points[0] \
	                           rect.points[1] = points[1] \
							   rect.points[2] = points[2] \
							   rect.points[3] = points[3] \
							   rect.points[4] = points[0]}

#define TYPE_OPENAREA 1
#define TYPE_LAND     2
#define TYPE_WATER    3
#define TYPE_AIR      4

#define ICE_WARD 0x0972       // water
#define WARLOCK_WARD 0x0973   // open area
#define LIGHTNING_WARD 0x0974 // air
#define EYE_WARD 0x0975       // land

struct PPoint
{
	int recordID;
	int group;
	int nodeNumber;
	int continent;
	float x;
	float y;
	float z;
	int reserved;
	int type;
};

struct PPointNode
{
	PPoint pPoint;
	PPointNode *nextNode;
};

struct Point
{
	float x;
	float y;
	float z;
};

struct Line
{
	Point a;
	Point b;
};

struct Rect
{
	Point points[5]; // 4 + 1 points, where points[n] = points[0]
};

class CPPoint
{
public:
	CPPoint();
	~CPPoint();
	void AddPoint(CClient *pClient);
	void SpawnPathPoints();
	bool GetPPoint(const int pPointID, PPoint &point);
	int editGroup;
	int editType;
	bool editMode;
	map<int,PPointNode *> groups;
private:
	PPointNode *head;
	PPointNode *tail;
	bool IsInside(const Point &testPoint, const Rect &rect);
	bool LinesIntersect(const Line &line1, const Line &line2);
	float GetDistanceToRectCenter(const Point &point, const Rect &rect);
	void AddPathingPoint(const PPoint &point);
	void Cleanup();
	void CreateTestData();
};