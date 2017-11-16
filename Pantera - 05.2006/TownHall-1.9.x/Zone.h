#ifndef ZONE_H
#define ZONE_H

#include "stdafx.h"
#include "WoWObject.h"

struct ZoneData
{

};

class CZone : public CWoWObject
{
public:
	CZone(void);
	~CZone(void);

	ZoneData Data;
};

#endif // ZONE_H
