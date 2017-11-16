struct _Location
{
	float X;
	float Y;
	float Z;
};

struct _Origin
{
	unsigned long Continent;
	unsigned long Zone;
	_Location Loc;
	float Facing;
};

struct _Name
{
	char Name[64];
};