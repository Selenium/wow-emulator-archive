#ifndef FLYPATH_H
#define FLYPATH_H

#include "stdafx.h"

using namespace std;
typedef map<unsigned long, _Location>::iterator FLYPATH_ITER;
class CFlyPath
{
	map<unsigned long, _Location> m_map;
	unsigned long currentNodeID;
	float Length;
public:

	CFlyPath(void) {Length = 0.0f; currentNodeID = 0;};

	~CFlyPath(void)
	{
		m_map.clear();
	}

	inline unsigned long Add(_Location &loc)
	{
		m_map[currentNodeID] = loc;
		return currentNodeID++;
	}

	inline void Remove(unsigned long nodeID)
	{
		m_map.erase(nodeID);
	}

	inline void Modify(unsigned long nodeID, _Location &loc)
	{
		m_map[nodeID] = loc;
	}

	inline FLYPATH_ITER First()
	{
		return m_map.begin();
	}

	inline FLYPATH_ITER Last()
	{
		return m_map.end();
	}

	inline map<unsigned long, _Location>::size_type Count()
	{
		return m_map.size();
	}

	void CalcLength()
	{
		Length = 0.0f;
		if(m_map.size() <= 1)
			return;
		FLYPATH_ITER i = First();
		_Location lastLoc = i->second;
		i++;
		for(;i != Last();i++)
		{
			Length += Distance(lastLoc, i->second);
			lastLoc = i->second;
		}
	}

	inline float LengthFrom(_Location &loc)
	{
		if(m_map.size() == 0)
			return 0.0f;
		return Length + Distance(loc, First()->second);
	}

	inline int MoveTime(float speed, _Location &from)
	{
		return (int)((LengthFrom(from)/speed) * 1000);
	}

	void GetPos(float speed, int time, _Location &from)
	{
		if(m_map.size() == 0)
			return;
		if(time >= MoveTime(speed, from))
		{
			from = (--Last())->second;
			return;
		}
		float moved = (((float)time)/1000) * speed;
		float moved_save = moved;
		_Location lastLoc = from;
		FLYPATH_ITER i = First();
		for(;i != Last();i++)
		{
			float dist = Distance(lastLoc, i->second);
			if(dist > moved)
				break;
			moved -= dist;
			lastLoc = i->second;
		}
		int timeSpentOnNode = time-(int)(((moved_save-moved)/speed)*1000);
		int timePossibleToSpend = (int)(Distance(lastLoc, i->second)/speed) * 1000;
		float timeProcent = ((float)timeSpentOnNode)/((float)timePossibleToSpend);
		from.X = lastLoc.X + ((i->second.X - lastLoc.X) * timeProcent);
		from.Y = lastLoc.Y + ((i->second.Y - lastLoc.Y) * timeProcent);
		from.Z = lastLoc.Z + ((i->second.Z - lastLoc.Z) * timeProcent);
	}
private:
	inline float Distance(_Location &Loc1, _Location &Loc2)
	{
		float x=Loc1.X-Loc2.X;
		float y=Loc1.Y-Loc2.Y;
		float z=Loc1.Z-Loc2.Z;
		return sqrtf((x*x)+(y*y)+(z*z));
	}
};

#endif // FLYPATH_H
