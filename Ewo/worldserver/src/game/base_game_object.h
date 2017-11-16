// Copyright (C) 2006 Team Evolution
#ifndef BASE_GAMOBJECT_H
#define BASE_GAMOBJECT_H

#include "UpdateMask.h"
#include "constants.h"
#include "UpdateFields.h"
#include <time.h>

//this should be the base object of all objects
//over this we should build up all other game objects

class Base_Unit_Object;

class Base_Game_Object
{
public:
	void				SetUInt32Value (uint32 index, uint32 value);
	void				SetUInt64Value (uint32 index, uint64 value);
	void				SetFloatValue (uint32 index, float value);
	virtual inline void				set_guid()//sometimes we require to generate guid again
	{
		data32[OBJECT_FIELD_GUID] = (uint32)this;
		data32[OBJECT_FIELD_GUID+1] = obj_type | (time(NULL)<<16); //use salt for refurbished objects
	}
	inline uint32		getGUIDL(){return data32[OBJECT_FIELD_GUID];}
	inline uint32		getGUIDH(){return data32[OBJECT_FIELD_GUID+1];}
	inline uint64		getGUID(){return *((uint64*)&data32[OBJECT_FIELD_GUID]);}
	uint64				GetUInt64Value (uint32 index);
	inline void			flag_set(uint32 index,uint32 flag)
	{
		if(!(data32[index] & flag))update_mask.SetBit(index);
		data32[index] |= flag;
	}
	inline void			flag_clr(uint32 index,uint32 flag)
	{
		if((data32[index] & flag))update_mask.SetBit(index);
		data32[index] &= ~flag;
	}
	inline uint8		flag_is(uint32 index,uint32 flag){return ((data32[index] & flag)!=0);}
	virtual void		update(){};
	void				update_obj_pos(Base_Unit_Object *self_only);
	void				set_object_facing();
	union {
		uint32				*data32;
		uint8				*data;
		float				*dataf;
	};
	float				pos_x,pos_y,pos_z,orientation;
	uint32				map_id;
	uint32				atimer1,atimer2;
	UpdateMask			update_mask;
	uint32				obj_type;
	uint32				db_id;
};

#endif
