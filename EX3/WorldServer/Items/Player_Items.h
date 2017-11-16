#if !defined(PLAYER_ITEMS_H)
#define PLAYER_ITEMS_H

#ifdef ITEMS

class Player_Item
{
	public:
		Player_Item();
		~Player_Item();

	QuadWord GUID;
	DoubleWord Entry;
	QuadWord OwnerGuid;
	DoubleWord SlotNumber;
	DoubleWord Where;
	DoubleWord CurrentSlot;
};

#endif

#endif