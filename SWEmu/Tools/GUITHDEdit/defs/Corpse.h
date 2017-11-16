struct CorpseData
{
	char Name[15];
	guid_t Owner;
	unsigned long Model;
	unsigned char Appearance[5];
	unsigned char Race;
	unsigned char Gender;
//	unsigned long Items[120];
	guid_t ItemGuids[120];
	_Location Loc;
	unsigned long Continent;
	float Facing;
};