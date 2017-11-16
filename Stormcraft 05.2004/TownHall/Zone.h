#pragma once
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
