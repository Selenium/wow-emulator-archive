// Copyright (C) 2006 Team Evolution
#ifndef QUEST_H
#define QUEST_H 1

#define MAGIC_QUEST_NUMBER 4

enum QUEST_STATUS
{
	QMGR_QUEST_NOT_AVAILABLE            = 0x00,    // There aren't quests avaiable.                   | "No Mark"
	QMGR_QUEST_AVAILABLELOW_LEVEL       = 0x01,    // Quest avaiable, and your level isnt enough.     | "Gray Quotation Mark !"
	QMGR_QUEST_CHAT                     = 0x02,    // Quest avaiable it shows a talk baloon.          | "No Mark"
	QMGR_QUEST_NOT_FINISHED             = 0x03,    // Quest isnt finished yet.                        | "Gray Question ? Mark"
	QMGR_QUEST_REPEATABLE               = 0x04,    // Quest repeatable                                | "Blue Question ? Mark" 
	QMGR_QUEST_AVAILABLE                = 0x05,    // Quest avaiable, and your level is enough        | "Yellow Quotation ! Mark" 
	QMGR_QUEST_FINISHED                 = 0x06,    // Quest has been finished.                        | "Yellow Question  ? Mark"

	QMGR_QUEST_FAILED                   = 0xF0,    // internal marker, client should have a value too
};

enum QUESTGIVER_QUEST_TYPE
{
	QUESTGIVER_QUEST_START  = 0x01,
	QUESTGIVER_QUEST_END    = 0x02,
};

enum QUEST_TYPE
{
	QUEST_GATHER    = 0x01,
	QUEST_SLAY      = 0x02,
};

enum QuestSpecialFlags
{
    QUEST_SPECIAL_FLAGS_NONE          = 0,
    QUEST_SPECIAL_FLAGS_DELIVER       = 1,
    QUEST_SPECIAL_FLAGS_EXPLORATION   = 2,
    QUEST_SPECIAL_FLAGS_SPEAKTO       = 4,

    QUEST_SPECIAL_FLAGS_KILL          = 8,
    QUEST_SPECIAL_FLAGS_TIMED         = 16,
    QUEST_SPECIAL_FLAGS_REPEATABLE    = 32,                 //?

    QUEST_SPECIAL_FLAGS_REPUTATION    = 64,
};

struct Quest_template
{
	uint32	id;
	uint32	lvl;
	uint32	q_type;
	uint32	zone_id;
	uint32	quest_sort;
	uint32	req_rep_faction;
	uint32	req_rep_value;
	uint32	req_skill;
	uint32	req_skill_value;
	uint32	req_class_flags;
	uint32	req_race_flags;
	uint32  req_lvl;
	uint32	req_spell;
//	uint32	req_stat_index[MAGIC_QUEST_NUMBER];
//	uint32	req_stat_value[MAGIC_QUEST_NUMBER];
	uint32	req_quest[MAGIC_QUEST_NUMBER];
	uint32	prev_quest_id;
	uint32	next_quest_id;
	uint32	s_flags;
	uint32	src_item_id;
	uint32	src_item_count;
//	uint8	obj_kill_type[4];//the next id's will point to creature or gameobject ?
	uint32	obj_kill_id[4]; //can be gamobject or creature
	uint32	obj_kill_count[4];
	uint32	obj_trigger_id[MAGIC_QUEST_NUMBER];
//	uint32	obj_trigger_count[MAGIC_QUEST_NUMBER];
	uint32	obj_item_id[4];
	uint32	obj_item_count[4];
	uint32	obj_item_from_cr_id[4];//not used by client, only by server, stores creature id's from which we can loot quest items
	uint32	obj_time; //in seconds
	uint32	obj_money;
	uint32	obj_speakto_id;
	char	*title_txt,*details_txt,*done_txt,*objective_txt,*incomplete_txt,*end_txt,*obj_text_1,*obj_text_2,*obj_text_3,*obj_text_4;
	uint32	start_quest;
	uint32	rew_opt_item_id[6];
	uint32	rew_opt_item_count[6];
	uint32	rew_item_id[4];
	uint32	rew_item_count[4];
	uint32	rew_money;
	uint32	rew_teach_spell;
	uint32	cast_spell; //this is introduced in 2.0.6 and by cating this olayer will learn the reward spell
	uint32	rew_cast_spell;
	uint32	rew_xp;
	uint32	rew_xp_or_money;
	uint32	rew_rep_faction[2];
	int		rew_rep_faction_value[2];
	float	point_x,point_y;
	uint32	point_opt;
	uint32	point_map_id;
};
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Quest_id_Node
{
public:
	uint32 value;
	Quest_id_Node *next;
};
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Quest_id_List
{
public:
	Quest_id_List(){first=NULL;}
	~Quest_id_List(){clear();}
	void clear()
	{
		Quest_id_Node *kur = first,*prev;
		while(kur)
		{
			prev = kur;
			kur->value = NULL;
			kur = kur->next;
			delete prev;
		}
		first = NULL;
	}
	inline void add(uint32 quest_id)
	{
		Quest_id_Node *kur = first;
		while(kur && kur->value!=quest_id)
			kur = kur->next;
		if(!kur)
		{	
			Quest_id_Node *new_node;
			new_node = new Quest_id_Node;
			new_node->value = quest_id;
			new_node->next = first;
			first = new_node;
		}
	}
	void del(uint32 quest_id)
	{
		Quest_id_Node *kur = first,*prev;
		while(kur && kur->value!=quest_id)
		{
			prev = kur;
			kur = kur->next;
		}
		if(kur)
		{	
			if(prev) prev->next = kur->next;
			if(kur==first) first = kur->next;
			delete kur;
		}
	}
	uint8 has_quest(uint32 quest_id)
	{
		Quest_id_Node *kur = first;
		while(kur && kur->value!=quest_id)
			kur = kur->next;
		return (uint8)kur;
	}
	Quest_id_Node *first;
};

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//!!must be all 4 bytes long values
struct Quest_instance
{
	uint32		id;
	uint32		slot;//slot in the char data fields
	signed int	obj_kill_remaining[MAGIC_QUEST_NUMBER];
	signed int	obj_trigger_remaining[MAGIC_QUEST_NUMBER];
	signed int	obj_items_remaining[MAGIC_QUEST_NUMBER];
	uint32		obj_speakto;
	uint32		end_timestamp_s;//it is in seconds
	uint32		static_item_rewards_added;
	uint32		state;//is it finished ?
};
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Quest_instance_Node
{
public:
	Quest_instance_Node(){memset(&value,0,sizeof(Quest_instance));}
	Quest_instance value;
	Quest_instance_Node *next;
};

class Character;
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Quest_instance_List
{
public:
	Quest_instance_List(){first=NULL;}
	~Quest_instance_List(){clear();}
	void clear()
	{
		Quest_instance_Node *kur = first,*prev;
		while(kur)
		{
			prev = kur;
			kur = kur->next;
			delete prev;
		}
		first = NULL;
	}
	void add(Quest_instance_Node *new_node);
	uint32 add(uint32 quest_id);//will return the slot into what it was inserted
	void del_slot(uint32 slot)
	{
		Quest_instance_Node *kur = first,*prev=NULL;
		while(kur && kur->value.slot!=slot)
		{
			prev = kur;
			kur = kur->next;
		}
		if(kur)
		{	
			if(prev) prev->next = kur->next;
			if(kur==first) first = kur->next;
			delete kur;
		}
	}
	uint8 del_id(uint32 quest_id)
	{
		Quest_instance_Node *kur = first,*prev=NULL;
		uint8 ret=0;
		while(kur && kur->value.id!=quest_id)
		{
			prev = kur;
			kur = kur->next;
		}
		if(kur)
		{	
			ret=kur->value.slot;
			if(prev) prev->next = kur->next;
			if(kur==first) first = kur->next;
			delete kur;
		}
		return ret;
	}
	uint8 has_active_quest(uint32 quest_id)
	{
		Quest_instance_Node *kur = first;
		while(kur && kur->value.id!=quest_id)
			kur = kur->next;
		return (uint8)kur;
	}
	Quest_instance*	get_quest_info(uint32 quest_id)
	{
		Quest_instance_Node *kur = first;
		while(kur && kur->value.id!=quest_id)
			kur = kur->next;
		return &kur->value;
	}
//	uint32	on_to_talk_to_NPC(uint32 cr_id);
	uint32	need_to_talk_to_NPC(uint32 cr_id);
	void	on_kill(uint32 object_id,uint64 obj_guid);
	//!!warning this does not take into count speakto quests. That is checked by char when he observes the questgiver
	void	check_finished(Quest_instance_Node *node);
	//character cals this function to test if the only thing this quest misses is to talk to the NPC
	uint32	would_finish(Quest_instance_Node *node,uint32 talkingto_id);
	uint32	get_quest_status(uint32 quest_id);
	void	on_add_item(uint32 item_id,uint32 count);
//	void	on_rem_item(uint32 item_id,uint32 count);
	void	msg_add_item(uint32 item_id,uint32 count);
	void	on_enter_custom_trigger(uint32 trigger_id);
	uint32	can_destroy_item(uint32 item_id);//we can only destroy an item if we abandoned the quest
	void	refresh_items_gathered();//used on load char and on finish quest. To recaunt and resend number of available items for quests
	void	finish_quest(Quest_instance_Node *node);
	void	finish_quest(uint32 quest_id);
	void	fail_quest(uint32 quest_id);
	Quest_instance_Node *first;
	Character	*owner;
};

void msg_quest_start_details(GameClient *pClient,uint64 quest_giver_guid,uint32 quest_id);
void msg_quest_not_finished_missing(GameClient *pClient,uint64 quest_giver_guid,uint32 quest_id);
void msg_quest_finished_rewards(GameClient *pClient,uint64 quest_giver_guid,uint32 quest_id);
//void msg_quest_update_on_mob_kill(GameClient *pClient,uint32 quest_id,uint32 obj_id,uint32 kill_count,uint32 max_kill_count,uint64 obj_GUID);
void msg_quest_failed(GameClient *pClient,uint32 quest_id);
void msg_quest_timer_failed(GameClient *pClient,uint32 quest_id);
void msg_quest_complete(GameClient *pClient,uint32 quest_id);
#endif