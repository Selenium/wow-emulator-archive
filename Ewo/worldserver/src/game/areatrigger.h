// Copyright (C) 2006 Team Evolution
#ifndef character20061020
#define character20061020 1

//!!! client supports area trigger object. We only implement it server side 
//areatrigger should have on enter and on exit type
enum Area_trigger_types
{
	AREATRIGGER_TYPE_ENTER_START_REST		= 1,
	AREATRIGGER_TYPE_EXIT_STOP_REST			= 2,
	AREATRIGGER_TYPE_ENTER_QUEST			= 3,
	AREATRIGGER_TYPE_ENTER_QUEST_AND_MSG	= 4,
	AREATRIGGER_TYPE_ENTER_MSG				= 5,
	AREATRIGGER_TYPE_ENTER_CAST_SPELL		= 6,
	AREATRIGGER_TYPE_EXIT_CAST_SPELL		= 7,
	AREATRIGGER_TYPE_ENTER_RUN_SCRIPT		= 8,
	AREATRIGGER_TYPE_EXIT_RUN_SCRIPT		= 9,
	AREATRIGGER_TYPE_ENTER_START_QUEST		= 10,
	AREATRIGGER_TYPE_EXIT_FAIL_QUEST		= 11,
};

//area trigger is just a space in the map when a player enters it. It will trigger
class Area_trigger
{
public:
	void	on_enter_trigger(uint64	trigger);
	void	on_left_trigger(uint64	trigger);
	uint32	id;
	uint32	map_id;
	float	x1,y1,z1,x2,y2,z2; //the space delimiting box
	uint8	on_enter_type,on_exit_type; //this will produce dome event
	float	param[4]; //teleport action would require 4 params
	char*	msg_param1;
};

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Area_trigger_Node
{
public:
	Area_trigger		value;
	Area_trigger_Node	*next;
};
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Area_trigger_List
{
public:
	Area_trigger_List(){first=NULL;}
	~Area_trigger_List(){clear();}
	inline void clear()
	{
		Area_trigger_Node *kur = first,*prev;
		while(kur)
		{
			prev = kur;
			kur = kur->next;
			delete prev;
		}
		first = NULL;
	}
	//!!! this node might be used in more then one map cell
	void add(Area_trigger_Node *new_node)
	{
//printf("adding areatrigger to a list\n");
		new_node->next = first;
		first = new_node;
		if(new_node->value.x1 > new_node->value.x2)
		{
			float t;
			t = new_node->value.x1;
			new_node->value.x1 = new_node->value.x2;
			new_node->value.x2 = t;
		}
		if(new_node->value.y1 > new_node->value.y2)
		{
			float t;
			t = new_node->value.y1;
			new_node->value.y1 = new_node->value.y2;
			new_node->value.y2 = t;
		}
		if(new_node->value.z1 > new_node->value.z2)
		{
			float t;
			t = new_node->value.z1;
			new_node->value.z1 = new_node->value.z2;
			new_node->value.z2 = t;
		}
	}
	inline uint8 trigger_areatriggers(uint64 guid,float cur_x,float cur_y, float cur_z, float old_x, float old_y, float old_z)
	{
		if(!first)
			return 0;
		if(	abs(cur_x - old_x)<AREATRIGGER_CHECK_RESOLUTION &&
			abs(cur_y - old_y)<AREATRIGGER_CHECK_RESOLUTION &&
			abs(cur_z - old_z)<AREATRIGGER_CHECK_RESOLUTION
			)
			return 0;
//printf("checking if we are triggering any areatrigger\n");
		Area_trigger_Node *itr=first;
		while(itr)
		{
//printf("kx=%f,ox=%f,minx=%f,maxx=%f\n",cur_x,old_x,itr->value.x1,itr->value.x2);
//printf("ky=%f,oy=%f,miny=%f,maxy=%f\n",cur_y,old_y,itr->value.y1,itr->value.y2);
//printf("kz=%f,oz=%f,minz=%f,maxz=%f\n",cur_z,old_z,itr->value.z1,itr->value.z2);
			uint8 is_in_box=0;
			uint8 was_in_box=0;
			if(	itr->value.x1 < cur_x && itr->value.x2 > cur_x &&
				itr->value.y1 < cur_y && itr->value.y2 > cur_y &&
				itr->value.z1 < cur_z && itr->value.z2 > cur_z )
				is_in_box = 1;
			if(	itr->value.x1 < old_x && itr->value.x2 > old_x &&
				itr->value.y1 < old_y && itr->value.y2 > old_y &&
				itr->value.z1 < old_z && itr->value.z2 > old_z )
				was_in_box = 1;
			if(is_in_box && !was_in_box)
				itr->value.on_enter_trigger(guid);
			else if(!is_in_box && was_in_box)
				itr->value.on_left_trigger(guid);
			itr = itr->next;
		}
		return 1;
	}
	Area_trigger_Node	*first;
};

void msg_custom_areatrigger_msg(GameClient *pClient,char *msg);
void msg_areatrigger_msg(GameClient *pClient,char *msg);

#endif