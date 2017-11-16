// (c) AbyssX Group
#include "NetworkEnvironment.h"

ObjectUpdate::ObjectUpdate()
{
	Clear();
}

ObjectUpdate::~ObjectUpdate()
{
}

void ObjectUpdate::Clear(void)
{
	mTouched[UPDOBJECT] = false;
	mTouched[UPDITEM] = false;
	mTouched[UPDCONTAINER] = false;
	mTouched[UPDUNIT] = false;
	mTouched[UPDPLAYER] = false;
	mTouched[UPDGAMEOBJ] = false;
	mTouched[UPDDYNAMICOBJ] = false;
	mTouched[UPDCORPSE] = false;

	mObjectUpdates.clear();
	mItemUpdates.clear();
	mContainerUpdates.clear();
	mUnitUpdates.clear();
	mPlayerUpdates.clear();
	mGameObjectUpdates.clear();
	mDynamicObjectUpdates.clear();
	mCorpseUpdates.clear();
}

void ObjectUpdate::Touch(enum ObjectUpdate::UpdateType t)
{
	mTouched[t] = true;
}

void ObjectUpdate::AddFieldFloat(enum ObjectUpdate::UpdateType t, unsigned short field,
																 float value)
{
	unsigned int uint;

	uint = 0;
	memcpy(&uint, &value, 4);
	AddField(t, field, uint);
}

void ObjectUpdate::AddField(enum ObjectUpdate::UpdateType t, unsigned short field,
														unsigned int value)
{
	mTouched[t] = true;

	switch (t)
	{
		case UPDCONTAINER:
			mContainerUpdates[field] = value;
			break;
		case UPDCORPSE:
			mCorpseUpdates[field] = value;
			break;
		case UPDDYNAMICOBJ:
			mDynamicObjectUpdates[field] = value;
			break;
		case UPDGAMEOBJ:
			mGameObjectUpdates[field] = value;
			break;
		case UPDITEM:
			mItemUpdates[field] = value;
			break;
		case UPDOBJECT:
			mObjectUpdates[field] = value;
			break;
		case UPDPLAYER:
			mPlayerUpdates[field] = value;
			break;
		case UPDUNIT:
			mUnitUpdates[field] = value;
			break;
	}
}

unsigned short ObjectUpdate::WriteTo(unsigned char *buf)
{
	float f;
	unsigned int bits;
	unsigned int bytes;
	unsigned char dwords;
	unsigned short place = 0;
	unsigned short sbit;
	unsigned char sbyte;

	bits = 0;
	if (mTouched[UPDCONTAINER])
		bits += CONTAINER_END;
	if (mTouched[UPDCORPSE])
		bits += CORPSE_END;
	if (mTouched[UPDDYNAMICOBJ])
		bits += DYNAMICOBJECT_END;
	if (mTouched[UPDGAMEOBJ])
		bits += GAMEOBJECT_END;
	if (mTouched[UPDITEM])
		bits += ITEM_END;
	if (mTouched[UPDOBJECT])
		bits += OBJECT_END;
	if (mTouched[UPDPLAYER])
		bits += PLAYER_END;
	if (mTouched[UPDUNIT])
		bits += UNIT_END;
	f = (float)bits / 8.0f;
	bytes = (unsigned int)f;
	if (f > bytes)
		bytes++;
	f = (float)bytes / 4.0f;
	dwords = (unsigned char)f;
	if (f > dwords)
		dwords++;

	memcpy(buf + place, &dwords, 1);
	place += 1;

	sbit = 0;
	sbyte = 0;
	if (mTouched[UPDOBJECT])
		WriteMask(UPDOBJECT, buf, &place, &sbyte, &sbit);
	if (mTouched[UPDITEM])
		WriteMask(UPDITEM, buf, &place, &sbyte, &sbit);
	if (mTouched[UPDCONTAINER])
		WriteMask(UPDCONTAINER, buf, &place, &sbyte, &sbit);
	if (mTouched[UPDUNIT])
		WriteMask(UPDUNIT, buf, &place, &sbyte, &sbit);
	if (mTouched[UPDPLAYER])
		WriteMask(UPDPLAYER, buf, &place, &sbyte, &sbit);
	if (mTouched[UPDGAMEOBJ])
		WriteMask(UPDGAMEOBJ, buf, &place, &sbyte, &sbit);
	if (mTouched[UPDDYNAMICOBJ])
		WriteMask(UPDDYNAMICOBJ, buf, &place, &sbyte, &sbit);
	if (mTouched[UPDCORPSE])
		WriteMask(UPDCORPSE, buf, &place, &sbyte, &sbit);
	buf[place++] = sbyte;
	while ((place-1) / 4 < dwords)
		buf[place++] = 0x00;

	if (mTouched[UPDOBJECT])
		WriteFields(UPDOBJECT, buf, &place);
	if (mTouched[UPDITEM])
		WriteFields(UPDITEM, buf, &place);
	if (mTouched[UPDCONTAINER])
		WriteFields(UPDCONTAINER, buf, &place);
	if (mTouched[UPDUNIT])
		WriteFields(UPDUNIT, buf, &place);
	if (mTouched[UPDPLAYER])
		WriteFields(UPDPLAYER, buf, &place);
	if (mTouched[UPDGAMEOBJ])
		WriteFields(UPDGAMEOBJ, buf, &place);
	if (mTouched[UPDDYNAMICOBJ])
		WriteFields(UPDDYNAMICOBJ, buf, &place);
	if (mTouched[UPDCORPSE])
		WriteFields(UPDCORPSE, buf, &place);

	return place;
}

void ObjectUpdate::WriteMask(enum ObjectUpdate::UpdateType t, unsigned char *buf,
														 unsigned short *place, unsigned char *startbyte,
														 unsigned short *startbit)
{
	unsigned short endbit;
	unsigned short bit;
	unsigned char byte;
	std::map<unsigned short, unsigned int> *map;
	std::map<unsigned short, unsigned int>::iterator it;

	endbit = 0;
	map = NULL;
	switch (t)
	{
		case UPDOBJECT:
			endbit = OBJECT_END;
			map = &mObjectUpdates;
			break;
		case UPDITEM:
			endbit = ITEM_END;
			map = &mItemUpdates;
			break;
		case UPDCONTAINER:
			endbit = CONTAINER_END;
			map = &mContainerUpdates;
			break;
		case UPDUNIT:
			endbit = UNIT_END;
			map = &mUnitUpdates;
			break;
		case UPDPLAYER:
			endbit = PLAYER_END;
			map = &mPlayerUpdates;
			break;
		case UPDGAMEOBJ:
			endbit = GAMEOBJECT_END;
			map = &mGameObjectUpdates;
			break;
		case UPDDYNAMICOBJ:
			endbit = DYNAMICOBJECT_END;
			map = &mDynamicObjectUpdates;
			break;
		case UPDCORPSE:
			endbit = CORPSE_END;
			map = &mCorpseUpdates;
			break;
	}

	byte = *startbyte;
	for (bit = 0; bit < endbit; bit++)
	{
		it = map->find(bit);
		if (it != map->end())
			byte = byte | (0x01 << ((bit + *startbit) % 8));

		if (((bit + *startbit) % 8) == 7) // just set our last bit
		{
			buf[*place] = byte;
			(*place)++;
			byte = 0x00;
		}
	}
	*startbyte = byte;
	*startbit = (bit + *startbit);
}

void ObjectUpdate::WriteFields(enum ObjectUpdate::UpdateType t, unsigned char *buf,
															 unsigned short *place)
{
	unsigned short endbit, bit;
	std::map<unsigned short, unsigned int> *map;
	std::map<unsigned short, unsigned int>::iterator it;

	endbit = 0;
	map = NULL;
	switch (t)
	{
		case UPDOBJECT:
			endbit = OBJECT_END;
			map = &mObjectUpdates;
			break;
		case UPDITEM:
			endbit = ITEM_END;
			map = &mItemUpdates;
			break;
		case UPDCONTAINER:
			endbit = CONTAINER_END;
			map = &mContainerUpdates;
			break;
		case UPDUNIT:
			endbit = UNIT_END;
			map = &mUnitUpdates;
			break;
		case UPDPLAYER:
			endbit = PLAYER_END;
			map = &mPlayerUpdates;
			break;
		case UPDGAMEOBJ:
			endbit = GAMEOBJECT_END;
			map = &mGameObjectUpdates;
			break;
		case UPDDYNAMICOBJ:
			endbit = DYNAMICOBJECT_END;
			map = &mDynamicObjectUpdates;
			break;
		case UPDCORPSE:
			endbit = CORPSE_END;
			map = &mCorpseUpdates;
			break;
	}

	// can do this better, I'm sure, this is quick n dirty for now
	// should sort and iterate instead of all these .find() calls
	for (bit = 0; bit < endbit; bit++)
	{
		it = map->find(bit);
		if (it == map->end())
			continue;
		buf[*place    ] = ((*it).second & 0x000000FF);
		buf[*place + 1] = ((*it).second & 0x0000FF00) >> 8;
		buf[*place + 2] = ((*it).second & 0x00FF0000) >> 16;
		buf[*place + 3] = ((*it).second & 0xFF000000) >> 24;
		*place += 4;
	}
}
