struct ItemData
{
	guid_t nItemTemplate;
	_Location Loc;

	unsigned long Count; // stack
	float Size;
	guid_t Owner;
	guid_t Container;
	unsigned long Durability;
	unsigned long MaxDurability;

	guid_t Creator;

//	unsigned long BagGuid;

};