#pragma once
#include "stdafx.h"
#include "WoWObject.h"

struct ContainerData
{
	unsigned long Owner;
	unsigned long Contained;
	unsigned long Flags;
	unsigned long Enchantment[15];
	unsigned long Slots;
	unsigned long Items[20];
};

class CContainer :
	public CWoWObject
{
public:
	CContainer(void);
	~CContainer(void);
};
