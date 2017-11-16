// (c) AbyssX Group
#include "../WorldEnvironment.h"

#ifdef ITEMS

Player_Item::Player_Item()
{
	GUID = 0;
	OwnerGuid = 0;
	Entry = 0;
	SlotNumber = 0;
	Where = 0;
	CurrentSlot = 0;
}

Player_Item::~Player_Item()
{
}

#endif