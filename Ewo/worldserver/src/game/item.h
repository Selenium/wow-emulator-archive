// Copyright (C) 2006 Team Evolution
#ifndef item20060503
#define item20060503 1

#include "constants.h"
#include "SystemFun.h"
#include "UpdateFields.h"
#include "WorldServer.h"
#include "UpdateMask.h"
//#include "spell.h"
#include "globals.h"

class creature;
class Character;

#define ITEM_STATE_CONVERTED_TO_CONTAINER 1
//template items can be used but not destroyed. Used = stack can modify
#define ITEM_STATE_IS_TEMPLATE 2
//static items do not get consumed and their values do not modify
#define ITEM_STATE_IS_STATIC 4

#define ITEM_MOD_AFFECT_TYPE_SET	1
#define ITEM_MOD_AFFECT_TYPE_ADD	2
#define ITEM_MOD_AFFECT_TYPE_MUL	3

#define MAX_ITEM_MOD_NAME 20
#define MAX_ITEM_MOD_AFFECTS_PER_MOD 10

#define MAX_MODS_PER_ITEM 1
#define MAX_RETRY_FIND_ITEM_MOD 5
#define MAX_RETRY_FIND_BETTER_ITEM_MOD 3

#define LOOT_LIST_REALLOC_COUNT 10
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Loot_template_list
{
	struct loot_template_node
	{
		uint32	item_id;
		uint8	chance;
	};
public:
	Loot_template_list(uint32 plen)
	{
		maxlen=plen;
		node_list=(loot_template_node*)malloc(maxlen*sizeof(loot_template_node));
		ASSERT(node_list);
		len=0;
	}
	Loot_template_list()
	{
		maxlen=LOOT_LIST_REALLOC_COUNT;
		node_list=(loot_template_node*)malloc(maxlen*sizeof(loot_template_node));
		ASSERT(node_list);
		len=0;
	}
	~Loot_template_list()
	{
		free(node_list);
	}
	inline void add(uint32 pitem_id,uint8 pchance)
	{
		if(len==maxlen)
		{
			maxlen += LOOT_LIST_REALLOC_COUNT;
			node_list=(loot_template_node*)realloc(node_list,maxlen*sizeof(loot_template_node));
			ASSERT(node_list);
		}
		node_list[len].item_id=pitem_id;
		node_list[len++].chance=pchance;
	}
	loot_template_node	*node_list;
	uint32				len,maxlen;
};


//this is a modifier for creature prototype to generate more dinamic creatures
class Item_mod
{
public:
	Item_mod(){};
	~Item_mod(){};
	char	preffix[MAX_ITEM_MOD_NAME];
	char	suffix[MAX_ITEM_MOD_NAME];
	uint32	affect_what[MAX_ITEM_MOD_AFFECTS_PER_MOD];	//describes what stats will affect on creature instance
	uint8	affect_type[MAX_ITEM_MOD_AFFECTS_PER_MOD];	//add, multiply
	float	affect_value[MAX_ITEM_MOD_AFFECTS_PER_MOD];
//	uint8	chance_to_appear;	//currently it's not based on anything just a random number
	uint32	use_cost;//a value that will be taken account when creating random items
	uint16	mod_id;
	uint32	require_item_class_flags; //don't apply stupid randomizations on items that are not randomizable
	uint32	require_item_subclass_flags;
};

//item template. Instances will be a simple copy of this object becouse of complex structure that can be modified
class Item
{
public:
	Item();
	void Refurbish();//can be called by object pool to bring item object into a state where it can be reused
	~Item();
	virtual inline void				set_guid()//sometimes we require to generate guid again
	{
		data32[OBJECT_FIELD_GUID] = (uint32)this;
		data32[OBJECT_FIELD_GUID+1] = HIGHGUID_ITEM | (time(NULL)<<16); //use salt for refurbished objects
	}
	inline uint32 getGUIDL(){return data32[OBJECT_FIELD_GUID];}
	inline uint32 getGUIDH(){return data32[OBJECT_FIELD_GUID+1];}
	inline uint64 getGUID(){return *((uint64*)&data32[OBJECT_FIELD_GUID]);}
//	inline void SetUInt32Value (uint32 index, uint32 value);
//	inline void SetUInt64Value (uint32 index, uint64 value);
	//this will build a create object packet. This is used when we enter the world or other players enter the world
	void	build_create_block(Compressed_Update_Block *packet,uint32 target_self);
	//contaners are items too. They only differ by adding a couple of values to them
	void	build_create_block_container(Compressed_Update_Block *packet,uint32 target_self);
	//this should send for A9 only the values that changed since last update
//	void build_update_block(Compressed_Update_Block *packet,uint32 target_self,uint32 turn_id,uint8 clear_mask=1);
	//called when creating an instance from a template (it's just a duplication process
	void	create_from_template(Item *p_template);
	//on loading from database we have to remake guid
	void	on_load_from_template();
	//when owner changes we have to change owner data and send createblock
	void	on_change_owner(uint64 owner_guid,Character *char_owner,uint32 pmap_id=0,float px=0,float py=0);
	//it's used instead of update function
	void	send_create_item(GameClient	*pClient);
	//turn item into a container
	void	convert_to_conatiner(uint8 is_template=0);
	void	add_to_container(Item *p_item,uint8 slot);
	Item	*rem_from_container(uint8 slot);
	void	apply_item_mod(Item_mod *p_mod);
	void	apply_item_mod(uint32 mod_id);
	//item can randomise itself.!!call this function before you create it for client.
	//generaly this will occure when generating loot for mobs
	void	randomise_me(uint32 avail_points);
	//static item means that has nodinamic variables like stacking, spells ...
	uint8	is_static_item();
	void	msg_item_query_single(GameClient *pClient);
	//decrease durability. will return the new durability wich if it is 0 then remove efects
	void	loose_durability(float dmg);
	void	add_enchantment(uint32 ench_id,uint32 time_remain,uint32 count,uint8 update_client=0);
	void	del_enchantment(uint32 ench_id,uint8 update_client=0);
	uint32		*data32;
	union {
        uint32		*item_data32;
		float		*item_dataf;
		char		*item_data;
		signed int	*item_datai;
	};
	uint32		created_at;	//store time when it was created to know when we have to destroy it. Magicaly created items
	uint8		state1;
//	UpdateMask	update_mask; 
	//	Spell_Instance	affect_list;	//the list of spell_instances
};
#endif