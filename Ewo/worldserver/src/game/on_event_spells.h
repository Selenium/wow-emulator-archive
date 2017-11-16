// Copyright (C) 2006 Team Evolution
#ifndef ON_EVENT_SPELLS_H
#define ON_EVENT_SPELLS_H

#include "Common.h"
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//store a list of spells which will be called upon an event
//should be very fast on parsing it

enum On_spell_event_types
{
	ON_EVENT_SPELL_TYPE_MELEE_HIT				= 1,
	ON_EVENT_SPELL_TYPE_MELEE_STRUCK			= 2,
	ON_EVENT_SPELL_TYPE_KILL_XP_GIVER			= 4,
	ON_EVENT_SPELL_TYPE_KILL_XP_UNK				= 8,
	ON_EVENT_SPELL_TYPE_DODGE					= 16,
	ON_EVENT_SPELL_TYPE_UNK1					= 32,
	ON_EVENT_SPELL_TYPE_BLOCK					= 64,
	ON_EVENT_SPELL_TYPE_BLOCK1					= 66,
	ON_EVENT_SPELL_TYPE_UNK2					= 112,
	ON_EVENT_SPELL_TYPE_NEXT_MELEE				= 128,
	ON_EVENT_SPELL_TYPE_NEXT_MELEE1				= 129,
	ON_EVENT_SPELL_TYPE_CAST_SPELL				= 256,
	ON_EVENT_SPELL_TYPE_MELEE_STRUCK1			= 1026,
	ON_EVENT_SPELL_TYPE_UNK3					= 1138,
	ON_EVENT_SPELL_TYPE_UNK4					= 1139,
	ON_EVENT_SPELL_TYPE_HIT_RANGED				= 2048,
	ON_EVENT_SPELL_TYPE_HIT_CRITICAL			= 4096,
	ON_EVENT_SPELL_TYPE_STRUCK_CRITICAL_MELLE	= 8192,
	ON_EVENT_SPELL_TYPE_CAST_SPELL1				= 16384,
	ON_EVENT_SPELL_TYPE_TAKE_DMG				= 32768,
	ON_EVENT_SPELL_TYPE_HIT_CRITICAL_SPELL		= 65536,
	ON_EVENT_SPELL_TYPE_HIT_CRITICAL_MELLE		= 69632,
	ON_EVENT_SPELL_TYPE_HIT_SPELL				= 131072,
	ON_EVENT_SPELL_TYPE_STRUCK_CRITICAL			= 270336,
	ON_EVENT_SPELL_TYPE_STRUCK_IN_COMBAT		= 1048578,
	ON_EVENT_SPELL_TYPE_STRUCK_MELEE_OR_RANGED	= 1049602,
	//used types for emu
	ON_EVENT_SPELL_TYPE_STRUCK_ANY	= (ON_EVENT_SPELL_TYPE_MELEE_STRUCK | ON_EVENT_SPELL_TYPE_DODGE | ON_EVENT_SPELL_TYPE_BLOCK | ON_EVENT_SPELL_TYPE_MELEE_STRUCK1 | ON_EVENT_SPELL_TYPE_STRUCK_CRITICAL_MELLE | ON_EVENT_SPELL_TYPE_TAKE_DMG | ON_EVENT_SPELL_TYPE_STRUCK_CRITICAL | ON_EVENT_SPELL_TYPE_STRUCK_IN_COMBAT | ON_EVENT_SPELL_TYPE_STRUCK_MELEE_OR_RANGED),
	ON_EVENT_SPELL_TYPE_HIT_ANY		= (ON_EVENT_SPELL_TYPE_MELEE_HIT | ON_EVENT_SPELL_TYPE_NEXT_MELEE | ON_EVENT_SPELL_TYPE_HIT_RANGED | ON_EVENT_SPELL_TYPE_HIT_CRITICAL | ON_EVENT_SPELL_TYPE_HIT_CRITICAL_SPELL | ON_EVENT_SPELL_TYPE_HIT_CRITICAL_MELLE | ON_EVENT_SPELL_TYPE_HIT_SPELL),

};

class Character;
class creature;
class Base_Unit_Object;
class Spell_Affect_node;

enum Health_Shield_Flags
{
	HEALTH_SHIELD_FLAG_ON_HIT					= 1,
	HEALTH_SHIELD_FLAG_PERSISTENT_INSTANT		= 2, //will restore in time
	HEALTH_SHIELD_FLAG_PERSISTENT_REGEN			= 4, //will recover in time
	HEALTH_SHIELD_FLAG_CAST_SPELL_AT_EXPIRE		= 8, 
	HEALTH_SHIELD_FLAG_DMG_PRC_RECALC			= 16, //will recalc shield value based on dmg 
};

enum Health_Shield_DMG_Type_Flags
{
	HEALTH_SHIELD_DMG_TYPE_FLAG_NORMAL					= 1,
	HEALTH_SHIELD_DMG_TYPE_FLAG_HOLY					= 2,
	HEALTH_SHIELD_DMG_TYPE_FLAG_FIRE					= 4,
	HEALTH_SHIELD_DMG_TYPE_FLAG_NATURE					= 8,
	HEALTH_SHIELD_DMG_TYPE_FLAG_FROST					= 16,
	HEALTH_SHIELD_DMG_TYPE_FLAG_SHADOW					= 32,
	HEALTH_SHIELD_DMG_TYPE_FLAG_ARCANE					= 64,
	HEALTH_SHIELD_DMG_TYPE_FLAG_ALL						= 127,
};

class On_Attack_Extra_Dmg_Node
{
public:
	uint8	chance;
	uint8	dmg_type;
	float	amount;
	uint32	casts_remain;
	Spell_Affect_node	*parent_spell_list_node;
};

class On_Attack_Extra_Dmg_List
{
public:
	On_Attack_Extra_Dmg_List()
	{
		maxlen = 5;
		len=0;
		list = (On_Attack_Extra_Dmg_Node *)malloc(sizeof(On_Attack_Extra_Dmg_Node)*maxlen);
	}
	~On_Attack_Extra_Dmg_List()
	{
		free(list);
	}
	void clear(){};
	inline uint8 add(uint8	chance,uint8	dmg_type,float	amount,uint32	casts_remain,Spell_Affect_node	*parent_spell_list_node)
	{
		if(len==maxlen)
		{
			maxlen +=2;
			list = (On_Attack_Extra_Dmg_Node *)realloc(list,sizeof(On_Attack_Extra_Dmg_Node)*maxlen);
		}
		list[len].chance = chance;
		list[len].dmg_type = dmg_type;
		list[len].amount = amount;
		list[len].casts_remain = casts_remain;
		list[len].parent_spell_list_node = parent_spell_list_node;
		len++;
		return len-1;
	}
	inline void del(uint8 index)
	{
		len--;
		if(index!=len)
			memcpy(&list[index],&list[len],sizeof(On_Attack_Extra_Dmg_Node));
	}
	uint8 maxlen;//we can have 32*3 max extra dmg-es from spells
	uint8 len;
	On_Attack_Extra_Dmg_Node *list;
};

class Health_Shield_Node
{
public:
	Health_Shield_Node(){next=NULL;}
//	uint32	expires_at;
//	uint32	shield_max;
//	uint32	regen_in_time;
//	uint32	restore_interval;
//	uint32	restore_at;
	float	dmg_pct;
	float	shield_remain; //store the amount of shield remained until it will be removed
	float	mana_conversion; //the amount of mana will be used instead of health
	uint32	flags1,dmg_type_flags; //maybe health shield is apply able only in a few cases
	Spell_Affect_node	*parent_spell_list_node;
	Health_Shield_Node	*next;
};

class Health_Shield_List
{
public:
	Health_Shield_List(){first=NULL;}
	void	add(Health_Shield_Node *new_node)
	{
		new_node->next = first;
		first = new_node;
	}
	void	del(Health_Shield_Node *node)
	{
		Health_Shield_Node *kur=first,*prev=NULL;
		while(kur && kur!=node)
		{
			prev=kur;
			kur=kur->next;
		}
		if(kur)
		{
			if(prev)prev->next = kur->next;
			if(kur==first)	first = kur->next;
			delete kur;
		}
	}
	float	absorb_dmg(float dmg,uint8 dmg_type);
	Health_Shield_Node *first;
	Base_Unit_Object *owner;
};

class On_Event_Spell_node
{
public:
	uint8	spell_cast_chance;
	uint32	spell_casts_remaining;
	uint32	spell_id;
	uint32	trigger_on_event_param_only;
};

class On_event_spell_list
{
public:
	On_event_spell_list(Base_Unit_Object *powner)
	{
		owner = powner;
		len=0;
		maxlen=1;
		slots = (On_Event_Spell_node*)malloc(maxlen*sizeof(On_Event_Spell_node));
	}
	~On_event_spell_list()
	{
		free(slots);
	}
	void	resize_if_too_small()
	{
		if(len<maxlen)
			return;
		maxlen*=2;
		slots = (On_Event_Spell_node*)realloc(slots,maxlen*sizeof(On_Event_Spell_node));
	}
	uint8	add(uint32 new_spell_id,uint8 chance,uint32 max_cast_count=0xFFFFFFFF, uint32 condition=0xFFFFFFFF)
	{
		//if not then we insert a new value
		resize_if_too_small();
		slots[len].spell_id = new_spell_id;
		slots[len].spell_cast_chance = chance;
		slots[len].spell_casts_remaining = max_cast_count;
		slots[len].trigger_on_event_param_only = condition;
		return len++;
	}
	inline void	del(uint32 slot)
	{
		memcpy(&slots[slot],&slots[len-1],sizeof(On_Event_Spell_node));
		len--;
	}
	//made different functions for char and creature to boost up speed
	void		trigger_event_spells_char(uint64 suggested_target);
	void		trigger_event_spells_char_on_cast(uint64 suggested_target,uint32 spell_id);
	void		trigger_event_spells_cr(uint64 suggested_target);
	void		trigger_event_spells_cr_on_cast(uint64 suggested_target,uint32 spell_id);
	uint32		len,maxlen;//the number of stored spells
	On_Event_Spell_node *slots;
	Base_Unit_Object	*owner;
	Character	*owner_char;
	creature	*owner_cr;
};

#endif