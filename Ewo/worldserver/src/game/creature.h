// Copyright (C) 2006 Team Evolution
#ifndef creature20060503
#define creature20060503 1

#include "constants.h"
#include "multi_block_packet.h"
//#include "Character.h"
#include "UpdateMask.h"
#include "WorldServer.h"
#include "math.h"
#include "Opcodes.h"
#include "spell.h"
#include "globals.h"
#include "on_event_spells.h"
#include "base_unit_object.h"
#include "quest.h"

#define CREATURE_ON_POLYMORPH_HEALTH_REGEN_FACTOR 5
#define CREATURE_MINIMAL_SPEED 0.001f //used on rooted. It is not 0 to not have divison by 0 error

#define CREATURE_ROAM_LIFT_FROM_GROUND 0.2f //required because if creature should be on higher ground then player, he will fall through map

#define CREATURE_DIST_UNTIL_TRAVERMERCHANT_WAIT 4
#define CREATURE_DIST_UNTIL_FOLOWER_WAIT 3.0f //if player is further then this distance then creature will start folowing him

#define CREATURE_CHANCE_TO_RANDOMIZE_LOOT		50

#define CREATURE_MOD_TYPE_ADD			1
#define CREATURE_MOD_TYPE_MULTIPLY		3
#define CREATURE_MOD_TYPE_SET			5

#define CREATURE_MIN_WAIT_TIME_AT_PATROL		30000 //atleast 30 seconds
#define CREATURE_DIF_WAIT_TIME_AT_PATROL		120000 //atleast 2 minutes

#define CREATURE_MIN_WAIT_UNTIL_NEXT_CAST		60000 //wait atleast 1 minute between spell casts. No need to flood client with it
//#define CREATURE_MIN_WAIT_UNTIL_NEXT_CAST		10000 //wait atleast 1 minute between spell casts. No need to flood client with it

enum Creature_mod_indexes 
{
	CREATURE_MOD_INDEX_NONE						= 0,
	CREATURE_MOD_INDEX_HEALTH					= 1,
	CREATURE_MOD_INDEX_MANA						= 2,
	CREATURE_MOD_INDEX_DMG						= 3,
	CREATURE_MOD_INDEX_DMG_TYPE					= 4,
	CREATURE_MOD_INDEX_SIZE						= 5,
	CREATURE_MOD_INDEX_ATACK_SPEED				= 6,
	CREATURE_MOD_INDEX_XP						= 7,
	CREATURE_MOD_INDEX_GOLD						= 8,
	CREATURE_MOD_INDEX_LEVEL					= 9,
	CREATURE_MOD_INDEX_DMG_ABSORTION			= 10,
	CREATURE_MOD_INDEX_DMG_ABSORTION_PERCENT	= 11,
	CREATURE_MOD_INDEX_DMG_ABSORTION_TYPE		= 12,
};

#define MAX_RETRY_FIND_CREATURE_MOD 5

#define MAX_CREATURE_NAME_LENGTH 50
#define MAX_CREATURE_GUILD_NAME_LENGTH 50
#define MAX_CREATURE_MOD_NAME_LENGTH 10

#define VENDOR_GENERATE_NEW_RANDOM_ITEMS_INTERVAL	1800000 //every 30 minutes or server restart
#define VENDOR_DUMP_CHARACTER_SOLD_ITEMS			1800000
#define VENDOR_CHANCE_TO_RANDOMIZE_ITEM				25

#define CREATURE_YELL_EVENT_TYPE_RUSH	1

enum Creature_Spell_Cast_Flags
{
	CREATURE_CAST_FLAG_TARGET_SELF			= 1,
	CREATURE_CAST_FLAG_TARGET_MASTER		= 2,
	CREATURE_CAST_FLAG_TARGET_TARGET		= 4,
	CREATURE_CAST_FLAG_CAST_ON_RUSH			= 8,
	CREATURE_CAST_FLAG_CAST_ON_ATTACK		= 16,
	CREATURE_CAST_FLAG_CAST_ON_LOW_HEALTH	= 32,
	CREATURE_CAST_FLAG_CAST_ON_WAIT			= 64,
};

//will be added to creature spell book flags so be carefull about other flags to be greater then these 
enum Creature_Cast_Prefered_Target_Types
{
	CREATURE_CAST_PREFERED_TARGET_TYPE_SELF		= 1,
	CREATURE_CAST_PREFERED_TARGET_TYPE_TARGET	= 2,
	CREATURE_CAST_PREFERED_TARGET_TYPE_FRIEND	= 4,
};

class UpdateMask;
class Compressed_Update_Block;
class Character;
class WorldServer;
class Quest_id_List;

#define WAYPOINT_SPEED_LIMIT_TO_TELEPORT 20
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
enum Waypoint_Flags
{
	WAYPOINT_FLAG_CIRCULAR_WALK		= 1,//creature walks to last waypoint then to first
	WAYPOINT_FLAG_WALKBACK_WALK		= 2,//creature walks to last waypoint then walks path backwards
	WAYPOINT_FLAG_FORWARD_WALK		= 4,//creature walks to last waypoint
};
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class cr_yell_node
{
public:
	~cr_yell_node(){delete text;}
	uint8	type;
	uint8	lang;
	uint8	chance;
	uint8	trigger_on_event;//like on rush
	char*	text;
	uint32	emote;
	cr_yell_node *next;
};
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class cr_yell_list
{
public:
	cr_yell_list(){first=NULL;}
	~cr_yell_list(){clear();}
	inline void add(cr_yell_node *new_node)
	{
		new_node->next = first;
		first = new_node;
	}
	inline void clear()
	{
		cr_yell_node *kur=first,*prev=NULL;
		while(kur)
		{
			prev = kur;
			kur = kur->next;
			delete prev;
		}
		first = NULL;
	}
	//this funtion will return a yell if possible for this target
	void yell_to_target(creature *owner,Character *target,uint8 event_type);
	cr_yell_node	*first;
};
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class cr_spell_book_node
{
public:
	cr_spell_book_node()
	{
//		next_cast_after_stamp=0;
	}
	~cr_spell_book_node(){};
	uint32	spell_id;
	uint8	chance_to_cast;
	uint32	flags;
//	uint32	next_cast_after_stamp;//
	cr_spell_book_node *next;
};
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class cr_spell_list
{
public:
	cr_spell_list(){first=NULL;}
	~cr_spell_list(){clear();}
	inline void add(cr_spell_book_node *new_node)
	{
		new_node->next = first;
		first = new_node;
	}
	inline void clear()
	{
		cr_spell_book_node *kur=first,*prev=NULL;
		while(kur)
		{
			prev = kur;
			kur = kur->next;
			delete prev;
		}
		first = NULL;
	}
	cr_spell_book_node *first;
};
//sell lists are private for each vendor
class Waypoint_Node
{
public:
	float	speed_coef; //maybe we should hurry get there. If this is a very big value, creature is teleported
	float	dst_x,dst_y,dst_z,dst_o;
	uint32	dst_time_wait;
	Waypoint_Node	*next,*prev;
};
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Waypoint_List
{
public:
	Waypoint_List(){first=NULL;cur_dst=NULL;flags=WAYPOINT_FLAG_CIRCULAR_WALK;}
	~Waypoint_List(){clear();}
	inline void clear()
	{
		Waypoint_Node *kur = first,*prev;
		while(kur)
		{
			prev = kur;
			kur = kur->next;
			delete prev;
		}
		first = NULL;
		cur_dst = NULL;
	}
	//deletes the way point at which the current creature is heading to or waiting at
	void del(Waypoint_Node *delthis=NULL)
	{
		Waypoint_Node *kur = first,*prev=NULL,*delme;
		if(delthis==NULL)delme=cur_dst;
		else delme=delthis;
		get_next_waypoint();
		while(kur && kur!=delme)
		{
			prev = kur;
			kur = kur->next;
		}
		if(kur)
		{
			if(prev) prev->next = kur->next;
			if(kur->next)(kur->next)->prev=prev;
			if(first==kur) first=kur->next;
			delete delme;
		}
	}
	void add(Waypoint_Node *new_node)
	{
		if (new_node) {
			new_node->next = first;
			if (first)
				first->prev = new_node;
			first = new_node;
		}
	}

	void add_to_end(Waypoint_Node *new_node)
	{
		//we add them at the end
		Waypoint_Node *kur;
		kur = first;
		while(kur && kur->next) kur = kur->next;
		if(kur)
		{
			kur->next = new_node;
			new_node->prev = kur;
		}
		else
		{
			first = new_node;
			new_node->prev = NULL;
		}
		new_node->next = NULL;
	}

	Waypoint_Node*	get_next_waypoint()
	{
		if(flags & WAYPOINT_FLAG_CIRCULAR_WALK) 
		{
			if(cur_dst==NULL || cur_dst->next == NULL)
			{
				if(first==NULL)
					return NULL; //will crash the server :)
				cur_dst = first;
				return cur_dst;
			}
			cur_dst = cur_dst->next;
		}
		else if(flags & WAYPOINT_FLAG_WALKBACK_WALK)
		{
			if(cur_dst==NULL)
				cur_dst=first;
			if(flags & WAYPOINT_FLAG_FORWARD_WALK)
			{
				if(cur_dst->next)
					cur_dst=cur_dst->next;
				else
				{
					flags &= ~WAYPOINT_FLAG_FORWARD_WALK;
					if(cur_dst->prev)
						cur_dst=cur_dst->prev;
				}
			}
			else
			{
				if(cur_dst->prev)
					cur_dst=cur_dst->prev;
				else
				{
					flags |= WAYPOINT_FLAG_FORWARD_WALK;
					if(cur_dst->next)
						cur_dst=cur_dst->next;
				}
			}
		}
		return cur_dst;
	}
	void restart_path()
	{	cur_dst = first;	}
	int count_wp()
	{
		Waypoint_Node *kur = first;
		int count=0;
		while(kur)
		{
			kur = kur->next;
			count++;
		}
		return count;
	}
	Waypoint_Node	*first,*cur_dst;
	uint8		flags;
};

//#define NPC_TEXT_TO_CHOOSE_FROM 8
#define NPC_TEXT_TO_CHOOSE_FROM 1
struct NPC_text
{
	char*	text_0;
//	char*	text_1;
//	uint32	lang;
//	float	chance;
//	uint32	emote_anim[3];
//	uint32	emote_delay[3];
};
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//sell lists are private for each vendor
class creature_sell_item_node
{
public:
	creature_sell_item_node(){next_increase_stack=1;dinamic_item=NULL;}
	~creature_sell_item_node(){};
	uint32					item_id;
	uint32					item_count;
	uint32					item_count_max;
	uint32					next_increase_stack;
	uint32					increase_stack_interval;
	Item					*dinamic_item;
	creature_sell_item_node	*next;
};
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class creature_sell_item_list
{
public:
	creature_sell_item_list(){first=NULL;next_refresh=1;random_item_next_generate=1;}
	~creature_sell_item_list(){clear();}
	void clear();
	void update();
	void add(creature_sell_item_node *new_node)
	{
		new_node->next = first;
		first = new_node;
		if(refresh_interval>new_node->increase_stack_interval)
			refresh_interval = new_node->increase_stack_interval;
	}
	void add_item_instance(Item *item_instance);
	//make sure we are able to sell the item(in case more people are buying the same stuff from the vendor)
	uint8 sell(uint32 item_id,uint32 count)
	{
		creature_sell_item_node *cur_node = first;
		while(cur_node)
		{
			if(cur_node->item_id==item_id)
			{
				//dinamic items will be removed on next refresh. ! do not delete them here
				if(cur_node->item_count >= count)
				{
					cur_node->item_count -= count;
					return 1;//yes,  we can buy the item
				}
				else
				{
					cur_node->item_count = 0;//jsut in case we set it to 0
					return 0; //somebody else bought the item before us
				}
			}
			cur_node = cur_node->next;
		}
		return 0;//sorry, you cheated, the item is not available
	}
	uint32	refresh_interval; //will be set by the min refresh value of list
	uint32	next_refresh;
	uint32	random_item_next_generate;
	creature_sell_item_node	*first;
};
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//spell lists are the same for everybody
class creature_sell_spell_node
{
public:
	creature_sell_spell_node(){};
	~creature_sell_spell_node(){};
	uint32						cast_spell_id;
	uint32						teach_spell_id;//might not be only one but it is only to check if we know it or not
	uint32						cost;
	uint32						req_spell;
	uint32						req_skill;
	uint32						req_skill_lvl;
	uint32						req_lvl;
	creature_sell_spell_node	*next;
};
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class creature_sell_spell_list
{
public:
	creature_sell_spell_list(){first=NULL;}
	~creature_sell_spell_list(){clear();}
	inline void clear()
	{
		creature_sell_spell_node *kur = first,*prev;
		while(kur)
		{
			prev = kur;
			kur = kur->next;
			delete prev;
		}
		first = NULL;
	}
	void add(creature_sell_spell_node *new_node)
	{
		new_node->next = first;
		first = new_node;
	}
	creature_sell_spell_node	*first;
};
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Agro_Node
{
public:
	Agro_Node(){};
	~Agro_Node(){};
	Base_Unit_Object *owner;
//	uint64		owner_GUID;
	float		value;
	Agro_Node	*next;
	uint32		received_stamp;
};
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Agro_List
{
public:
	Agro_List(){first=NULL;max_value=NULL;owner=NULL;}
	~Agro_List(){clear();}
	inline void clear()
	{
		Agro_Node *kur = first,*prev;
		while(kur)
		{
			prev = kur;
			kur = kur->next;
			delete prev;
		}
		max_value = NULL;
		first = NULL;
	}
	//after a while agro should disapear
	void update();
	void add(uint64 owner_GUID,float value);
	void del(uint64 owner_GUID);
	Agro_Node	*first;
	Agro_Node	*max_value;
	creature	*owner;
};
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//this is a modifier for creature prototype to generate more dinamic creatures
class creature_mod
{
public:
	creature_mod();
	~creature_mod();
	char	name[MAX_CREATURE_MOD_NAME_LENGTH];
	uint8	flags; //actualy store if it is a suffix or prefix
	uint32	affect_what[3];	//describes what stats will affect on creature instance
	uint8	affect_type[3];	//add, multiply
	float	affect_value[3];
	uint8	chance_to_appear;	//currently it's not based on anithing just a random number
};

//this part of the cretures can be common and only templates should create it and the rest use it
class creature_static_data_holder
{
public:
	creature_static_data_holder()
	{
		level_min=1;
		level_diff=1;
		base_land_speed = UNIT_NORMAL_WALK_SPEED;
		trainer_type = train_class = type = family = 0;
		guild = NULL;
		elite = 0;
		loot_template_id = 0;
	}
	uint32						level_min,level_diff;
	uint32						trainer_type,train_class,type,family;
	uint32						loot_template_id;
	float						base_land_speed;
	char						*guild;
	uint8						elite;
	creature_sell_spell_list	sell_spell_list;
	Quest_id_List				quests_list;//player can choose from these
	cr_spell_list				spell_book;
	cr_yell_list				yell_list;//on rush we pick a line that is shouted to target
};

//this class stores a creature as a template/prototype. Instances should be alot smaller
//have static id's got from db
class creature:public Base_Unit_Object
{
public:
	creature();
	~creature();
	void		update();	//give time for creature to update self
	void		spawn();	//the first time we initialise the creature = create pathpoints...
	void		respawn();
	//this will build a create object packet. This is used when we enter the world or other players enter the world
	void		build_create_block(Compressed_Update_Block *packet,uint32 target_self);
	//this should send for A9 only the values that changed since last update
	void		build_update_block(Compressed_Update_Block *packet,uint32 target_self,uint8 clear_mask=1);
	void		mark_creature_on_minimap(GameClient *pClient,uint8 is_visible);//used for questgivers to mark them as visible on minimap
	void		move_creature(float pdst_x,float pdst_y,float pdst_z,int run,int instant_move=0,float speed_coef=1);
	//incase we take dmg this will calc the amount that is blocked and substract the remaining dmg from health
	float		take_dmg(float pdmg,uint64 atacker_GUID,uint8 ptype=0,uint8 unblockable=0,uint32 atacker_level=0);
	void		die();
	void		on_atack_swing();
	float		get_dmg(uint8 type);
	//parse loot template and marc items based on chance wich to show. Also generate random items
	void		generate_loot();
	//see if we still have something lootable. If not then clear lootable flag
	uint8		is_still_lootable();
	void		msg_vendor_sell_list(GameClient *pClient);
	void		msg_trainer_sell_list(GameClient *pClient);
	uint32		quest_giver_status(Character *asker);//client will ask us if we have some available or finished quests for the char
	void		on_change_speed();//called by spell after setting the new speed for creature
	void		AI_flee_from_point(uint32 time); //used to make creature get away from a specific point. He will keep running for x ms
	void		AI_general_caster(uint32 event_type);//will try to cast a spell from spellbook. Called only when cooldown has finished
	inline void	add_agro(uint64 guid,float amount){agro_list.add(guid,amount);}
	void		init_from_template(creature *cr_template);
	void		start_cast(uint32 spell_id,uint32 is_instant=0,uint64 suggest_target_guid=0);//should take care of all preparetions in order so creture casts a spell
	void		face_target();
	uint8		close_enough_to_cast_spell(Base_Unit_Object *target,Spell_Info *sp);
	uint32		respawn_delay;
	uint32		dmg_diff;
	uint32		dmg_res[7];
//	float		dmg_abs_min,dmg_abs_dif,dmg_abs_percent;
//	uint8		dmg_abs_type;
	uint32		loot_money;
	char		*name;		//can be randomized
	uint8		dmg_type;
	float		dmg_taken;	//dificulty is calculated from dmg_taken and dmg_done*2
	float		dmg_done;
	uint32		last_update;	//timestamp when creature was last updated
	Agro_List	agro_list;	//hold a list of guids and value of agro for them
	float		dst_x,dst_y,dst_z,adv_x,adv_y,adv_z; //for position tracking the deswtination and the advancment of each vector
	uint32		time_remain;
	uint64		last_atacker_guid;
	creature	*prototype;//when randomizing creature we have to be able to restore him
	uint32		mod_id;
	float		xp_coef;
	float		money_coef;
	Item		*loots[MAX_LOOTS_FOR_OBJECT];
	uint8		loot_item_count[MAX_LOOTS_FOR_OBJECT];
	uint32		figh_points;
	float		target_last_x,target_last_y;//in case atacker moves we want to face him always again
	uint32		casting_spell_id;
	uint64		suggested_spell_target;
	uint32		spell_cooldown_atimer;
	creature_static_data_holder		*static_data;//store data that can be same for all creatures. Only created for templates and used by all
	creature_sell_item_list			*sell_item_list;
#ifdef VERSION_CHAR_MAKE_CREAUTURE_WPOINTS
	uint8		z_cords_already_checked;
#endif
#ifndef	DISABLE_CUSTOM_TRIGGER_CHECKS_FOR_CREATURES
	float		areatrigger_lastcheck_x,areatrigger_lastcheck_y,areatrigger_lastcheck_z;
#endif
	Waypoint_List	waypoint_lst;
	Character		*folowed_char;

	uint8 On_Creature_spawn(creature *p_cr);
	uint8 On_Creature_respawn(creature *p_cr);
};

#endif 
