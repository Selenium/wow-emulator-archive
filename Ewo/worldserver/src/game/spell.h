// Copyright (C) 2006 Team Evolution
#ifndef spell20060503
#define spell20060503 1

#include "constants.h"
#include "SystemFun.h"
#include "time.h"
#include "math.h"
#include "base_unit_object.h"
//#include "creature.h"

class Character;
class creature;
class gameobject_instance;
class Item;
class NetworkPacket;

uint8 is_in_front(float viewer_x,float viewer_y,float viewer_orintation,float target_x,float target_y);
uint8 is_in_back(float viewer_x,float viewer_y,float viewer_orintation,float target_x,float target_y);

#define CHAR_AURA_TO_GROUP_RECHECK_INTERVAL			10000 //given in ms. Excesive checking might lead to lag 
#define CHAR_AURA_TO_LOCATION_RECHECK_INTERVAL		2000 //given in ms. Excesive checking might lead to lag 
#define CHAR_AURA_REMOVE_RANGE_SQ					2500 //wow units
#define CHAR_AURA_REMOVE_RANGE						50 //wow units

enum Action_Cast_Flags
{
	CAST_ACTION_FLAG_NONE						= 0, //this will not be saved to db, and stacks with any other spell
	CAST_ACTION_FLAG_ITEM_ENCHANTMENT			= 1, //this will not be saved to db, and stacks with any other spell
	CAST_ACTION_FLAG_STACK_WITH_ANY_OTHER		= 2, 
	CAST_ACTION_FLAG_CASTER_DEPENDENT			= 4, //auras that are received from other members have to be removed on certain situation
	CAST_ACTION_FLAG_LOCATION_DEPENDENT			= 8, //blizzard is bound to a location, if we leave it then it should be removed
	CAST_ACTION_FLAG_ALWAYS_ACTIVE				= 16,
};

enum Custom_Spell_Groups
{
	SPELL_GROUP_PALADIN_SEAL	= 1,
};

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#define MIN_COOLDOWN_LIMIT_TO_REMAMBER 60000 //ex : given in ms would mean aprox 1 minute
class spell_cooldown_node
{
public:
	spell_cooldown_node(uint32 p_spell_id,uint32 cooldown);
	~spell_cooldown_node(){};
	uint32 spell_id;
	uint32 end_time_stamp;
	spell_cooldown_node *next;
};
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Spell_cooldown_list
{
public:
	Spell_cooldown_list(){first=NULL;}
	~Spell_cooldown_list(){clear();}
	void add(uint32 spell_id,uint32 cooldown);
	void update();
	inline void clear()
	{
		spell_cooldown_node *kur=first,*prev=NULL;
		while(kur)
		{
			prev = kur;
			kur = kur->next;
			delete prev;
		}
		first = NULL;
	}
	spell_cooldown_node *first;
};
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Target_list
{
public:
	Target_list()
	{
		maxlen=40;
		data=(uint64*)malloc(maxlen*sizeof(uint64));
		affect_slot=(uint8*)malloc(maxlen);
		len=0;
	}
	~Target_list(){delete data;delete affect_slot;}
	inline void add(uint64 value)
	{
		if(len==maxlen)
		{
			maxlen *=2;
			data = (uint64*)realloc(data,maxlen*sizeof(uint64));
			affect_slot=(uint8*)malloc(maxlen);
		}
		//check if it is already inserted
		for(uint32 i=0;i<len;i++)
			if(data[i]==value)
				return;
		affect_slot[len]=0xFE;//just an impossible value
		data[len++]=value;
	}
	inline void  clear()
	{
		len=0;
	}
	union
	{
		uint64	*data;
		uint32	*data32;
	};
	uint32	len,maxlen;//point to the next free loc
	uint8	*affect_slot;
};
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class spell_book_node
{
public:
	spell_book_node(uint32 id){spell_id=id;next=NULL;}
	~spell_book_node(){};
	uint32 spell_id;
	spell_book_node *next;
};
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class spell_list
{
public:
	spell_list(){first=NULL;}
	~spell_list(){clear();}
	inline void add(uint32 id)
	{
		spell_book_node *new_node;
		new_node = new spell_book_node(id);
		new_node->next = first;
		first = new_node;
	}
	void del(uint32 id)
	{
		spell_book_node *kur=first,*prev=NULL;
		while(kur && kur->spell_id!=id)
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
	inline spell_book_node *find(uint32 spell_id)
	{
		spell_book_node *kur=first;
		while(kur && kur->spell_id!=spell_id)
			kur = kur->next;
		return kur;
	}
	inline void clear()
	{
		spell_book_node *kur=first,*prev=NULL;
		while(kur)
		{
			prev = kur;
			kur = kur->next;
			delete prev;
		}
		first = NULL;
	}
	spell_book_node *first;
};
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//spell prototype holder. It is stored by 
class Spell_Info
{
public:
	Spell_Info()
	{
		effect_implicit_target_b = &effect_implicit_target_a[3];
		custom_flags = 0;
	}
	uint8	Get_Creature_Prefered_Target();//creautures should have a prefered target that they cast the spell on
	uint32	spell_id;
	uint32	cast_time;
	uint32	power_type;
	uint32	power_cost;
	uint32	power_cost_per_lvl;
	uint32	power_cost_per_second;
//	uint32	power_cost_per_second_per_level;
	uint32	effect[3];
	uint32	effect_implicit_target_a[6];
	uint32	*effect_implicit_target_b;//see constructor for value trick
	uint32	channel_interrupt_flags;
	uint32	duration[3];
	float	range_min,range_max;
	float	radius[3];
	int		effect_base_points[3];
	float	dmg_multiply_for_combo[3];
	uint32	effect_die_sides[3];
	uint32	effect_misc_value[3];
//	int		effect_real_points_per_lvl[3];
	uint32	effect_apply_aura_name[3];
	uint32	effect_amplitude[3];
	uint32	effect_trigger_spell[3];
	uint32	school;
	uint32	aura_interrupt_flags;
//	uint32	category;
//	uint32	is_dispelable;
	uint32	recovery_time;
//	uint32	category_recovery_time;
//	uint32	duration_index;
	uint8	spell_lvl;//useless but required for trainers :(
	uint32	effect_create_item[3];
	uint32	effect_base_dice[3];
	uint32	effect_dice_per_lvl[3];
	uint8	proc_chance;
	uint32	proc_charges;
	uint32	proc_flags;
	uint8	dispell_type;//0 means not dispellable. dispell spell will have to match this value
//	uint32	spell_visual;
	uint32	reagent[7];
	uint32	reagent_count[7];
	uint32	stack_count;
	uint32	custom_flags;
//	uint32	totem_template_id[2];
};
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//spell instance
class Spell_Instance
{
public:
	Spell_Instance()
	{
		caster_char = NULL;
		target_mask = 0;
		target_creature = NULL;
		target_object = NULL;
		target_item = NULL;
		target_char = NULL;
		target_string = NULL;
		item_caster_guid = 0;
//		stack_id = 0; //mark casters with an id to know which one can stack and whick ones not
//		stack_id_old = 0; //just for backup to know the owner of the spell
		src_pos_x=src_pos_y=src_pos_z=dst_pos_x=dst_pos_y=dst_pos_z=0; //not necesary to init it ?
		flags1 = 0;
		cast_flags = 0;
		prototype = NULL;
	}
	~Spell_Instance()
	{
		if(target_string)
			free(target_string);
	};
	void	msg_spell_failed(uint8 result);
	void	msg_spell_can_cast_result(uint8 result);
	void	msg_spell_can_cast_result(uint32 spell_id,uint8 result,Character *sendto);
	void	msg_spell_start_cast();
	void	msg_spell_channel_start();
	void	msg_spell_channel_update(uint32 time);
	void	make_target_list();
	void	make_target_list_if_duel();
	void	msg_spell_cast_go();
	void	msg_spell_log_execute();
	void	msg_heal_unit(uint64 target_guid,uint32 value,uint8 is_crititcal);
	void	cast();	//this will take all necesary actions when actualy casting. like add affects .. 
	uint8	require_caster_behind_target();
	void	msg_non_melee_dmg_log(float damage,uint8 dmg_type);
	void	msg_non_melee_dmg_log(float damage,uint64 caster_guid,uint64 target,Spell_Info *prototype,Character *sendto);
	void	init(uint32 spell_id,float caster_x,float caster_y,float caster_o,uint32 caster_map_id);
	void	init_qued(uint32 spell_id);
	void	cancel_cast(uint32 spell_id=0);
	void	apply_effect();
	void	read_targets_from_src(uint8 *src);
	void	write_targets_to_packet(NetworkPacket &packet);
	void	write_targets_to_packet_go_spell(NetworkPacket &packet);
	void	set_caster(uint64 p_caster_guid,uint32 caster_faction);//if caster is char then we do some extra calculations like combo points
	void	msg_spell_cooldown(uint32 spell_id,uint32 cooldown_time);
	void	msg_cooldown_event(uint32 spell_id);//have no idea where to use this and what effect it has
	void	add_affects_to_targets();
	void	char_instant_nomana_cast(uint32 spell_id,uint32 end_timestamp,uint64 suggested_target=0);
	void	char_instant_cast(uint32 spell_id,uint64 sugested_target=0);
	void	cr_instant_cast(creature *owner,uint32 spell_id,uint64 sugested_target=0);
	void	aura_refresh_cast_on_group(uint32 spell_id);
	void	item_instant_cast_quiet(Item *owner,Base_Unit_Object *owner_owner,uint32 spell_id,uint64 sugested_target=0);
	void	WORLD_instant_cast(Base_Unit_Object *t_obj,uint32 spell_id);//there is no caster but effect should occure
	void	play_spell_visual(uint32 spell_id=0);
	Character			*caster_char;
	union {
		uint64				caster_guid; //usualy the char(owner but can be attacker too)
		uint32				caster_guid_parts[2]; //same as caster_guid
	};
//	uint32				stack_id,stack_id_old;//store item_id or char_id to know if we can stack or not
	uint64				item_caster_guid;
	uint32				cast_flags;
//	uint32				cast_session; //should mark a single cast. The purpuse is to be able to differentiate stackable spels and not stackable ones
	float				cast_x,cast_y,cast_z,cast_o;
	uint32				cast_map_id;
	uint32				cast_faction;
	uint32				cast_duration,spell_duration[3];
	Spell_Info			*prototype;
	uint16				target_mask;
	creature			*target_creature;
	gameobject_instance	*target_object;
	Item				*target_item;
	Character			*target_char;
	float				src_pos_x,src_pos_y,src_pos_z,dst_pos_x,dst_pos_y,dst_pos_z;
	char				*target_string;
	Target_list			target_list[4];//each effect has it's own list. Some spells effect target both enemy and friend but with diffrent effect
	uint32				flags1;
};

class Spell_Affect_List;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//this a double chained list to be able to fastly remove and add elements every where
//at given intervals some stat value will be modified by a given value. When end time is reached affect is removed
//to be able to count ms and not uint values, timer and dmg
class Spell_Affect_node
{
public:
	Spell_Affect_node()
	{
		prev=NULL;
	}
	~Spell_Affect_node(){};
	void	apply_effect(Base_Unit_Object	*owner_obj);//function that knows how and wich stats he has to modify
	void	remove_effect(Base_Unit_Object	*owner_obj);//if there is an inverse function for apply_effect then this is it
	void	msg_aura_periodic_log(uint64 target_guid);
	void	update(Base_Unit_Object	*owner_obj);//used by only some auras that need to do some specific action at some specific intervals. Like paladin aura should fade if too far from caster
	Spell_Affect_node *next,*prev;
	uint32	start_time; // store time when it was cast to know after loading when it expired
	uint32	start_time_sv; //store time but not in ms for saving and loading
	uint32	end_time;
	uint32	end_time_sv;
	float	value;
	uint32	timer_interval;
	uint32	time_next_trigger;
	uint8	slot;
	uint8	aura_ind;//there are 3 effects in a spell usualy, so we need to store the index
	uint32	aura_name;//since it is used a lot we will make a shortcut to it :)
	Spell_Info *prototype;
	union {
		uint64				caster_guid; //usualy a char
		uint32				caster_guid_parts[2]; //same as caster_guid
	};
	uint32	cast_flags;//internal flags
//	uint32	stack_id;//can't stack spells with same stack_id unless cast_flag says so
	float	values[7];//in case of pct values we memorize the amount we afflicted so we can remove it later
};
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Spell_Affect_List
{
public:
	Spell_Affect_List();
	~Spell_Affect_List()
	{
		Spell_Affect_node *kur=first,*prev;
		while(kur)
		{
			prev=kur;
			kur=kur->next;
			delete prev;
		}
		first = NULL;
	}
	inline void clear()
	{
		while(first)
			del(first);
	}
	uint8 add(Spell_Affect_node *new_node);
	void del(Spell_Affect_node *p_node);
	void update();
	inline Spell_Affect_node *find(uint64 caster_guid,uint32 spell_id,uint32 aura_name)
	{
		Spell_Affect_node *kur=first;
		while(kur && (kur->prototype->spell_id!=spell_id || kur->aura_name!=aura_name || kur->caster_guid!=caster_guid))
			kur = kur->next;
		return kur;
	}
	inline void remove_enchantment(uint64 caster_guid,uint32 spell_id)
	{
		Spell_Affect_node *kur=first;
		while(kur)
		{
			if(kur->caster_guid==caster_guid && kur->prototype->spell_id==spell_id)
			{
				Spell_Affect_node *next=kur->next;
				del(kur);
				kur=next;
			}
			else kur = kur->next;
		}
	}
	void		apply_effects();//called when a spell is making it's efect
	void		remove_effects();//called when a spell effect duration is off. It's the inverse function of apply_effects
	void		on_game_interrupt(uint32 int_flags);//like when eating and we stand up we will receive 
	void		remove_seals_from_caster(uint64	caster_guid);
	void		remove_stealth();
	void		cancel_spell(uint32 spell_id);
	Spell_Affect_node	*first;
	Base_Unit_Object	*owner_obj;
};
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#endif
