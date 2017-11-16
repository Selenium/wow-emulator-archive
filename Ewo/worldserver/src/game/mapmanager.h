// Copyright (C) 2006 Team Evolution
#ifndef mapmanager20060503
#define mapmanager20060503 1

#include "Character.h"
#include "creature.h"
#include "multi_block_packet.h"
#include "Character.h"
#include "constants.h"
#include "Opcodes.h"
#include "game_object.h"
#include "corpse.h"
#include "areatrigger.h"

void teleport(Character *p_char,uint32 map_id,float new_x, float new_y, float new_z,float new_o);

class gameobject_instance;
class creature;
class corpse;

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Character_Node
{
public:
	Character_Node(Character *p_char){value=p_char;}
	~Character_Node(){};
	Character *value;
	Character_Node *next;
};
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Character_List
{
public:
	Character_List(){first=NULL;}
	~Character_List()
	{
		Character_Node *kur = first,*prev;
		while(kur)
		{
			prev = kur;
			kur->value = NULL;
			kur = kur->next;
			delete prev;
		}
		first = NULL;
	}
	void add(Character *p_char);
	void del(Character *p_char);
	Character_Node *first;
};
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Corpse_Node
{
public:
	Corpse_Node(corpse *p_char){value=p_char;}
	~Corpse_Node(){};
	corpse *value;
	Corpse_Node *next;
};
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Corpse_List
{
public:
	Corpse_List(){first=NULL;}
	~Corpse_List()
	{
		Corpse_Node *kur = first,*prev;
		while(kur)
		{
			prev = kur;
			kur->value = NULL;
			kur = kur->next;
			delete prev;
		}
		first = NULL;
	}
	inline void add(corpse *p_char)
	{
		Corpse_Node *new_node;
		new_node = new Corpse_Node(p_char);
		new_node->next = first;
		first = new_node;
	}
	void del(corpse *p_char);
	Corpse_Node *first;
};
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Gameobject_Node
{
public:
	Gameobject_Node(gameobject_instance *p_go){value=p_go;}
	~Gameobject_Node(){};
	gameobject_instance *value;
	Gameobject_Node *next;
};
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Gameobject_List
{
public:
	Gameobject_List(){first=NULL;}
	~Gameobject_List()
	{
		Gameobject_Node *kur = first,*prev;
		while(kur)
		{
			prev = kur;
			kur->value = NULL;
			kur = kur->next;
			delete prev;
		}
		first = NULL;
	}
	inline void add(gameobject_instance *p_go)
	{
		Gameobject_Node *new_node;
		new_node = new Gameobject_Node(p_go);
		new_node->next = first;
		first = new_node;
	}
	void del(gameobject_instance *p_go);
	Gameobject_Node *first;
};
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Creature_Node
{
public:
	Creature_Node(creature *p_cr){value=p_cr;}
	~Creature_Node(){};
	creature *value;
	Creature_Node *next;
};
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Creature_List
{
public:
	Creature_List(){first=NULL;}
	~Creature_List()
	{
		Creature_Node *kur = first,*prev;
		while(kur)
		{
			prev = kur;
			kur->value = NULL;
			kur = kur->next;
			delete prev;
		}
		first = NULL;
	}
	inline void add(creature *p_cr)
	{
		Creature_Node *new_node;
		new_node = new Creature_Node(p_cr);
		new_node->next = first;
		first = new_node;
	}
	void del(creature *p_cr);
	Creature_Node *first;
};

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
struct Area
{
	float min_x,min_y,max_x,max_y;
	uint32	explore_flag;
};
class Area_Node
{
public:
	Area_Node(Area *p_area){value=p_area;next=NULL;}
	~Area_Node(){};
	Area *value;
	Area_Node *next;
};
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Area_List
{
public:
	Area_List(){first=NULL;}
	~Area_List()
	{
		Area_Node *kur = first,*prev;
		while(kur)
		{
			prev = kur;
			delete kur->value;
			kur->value = NULL;
			kur = kur->next;
			delete prev;
		}
		first = NULL;
	}
	inline void add(Area *p_area)
	{
		Area_Node *new_node;
		new_node = new Area_Node(p_area);
		new_node->next = first;
		first = new_node;
	}
	void del(Area *p_area)
	{
		Area_Node *kur = first,*prev = NULL;
		while(kur && kur->value!=p_area)
		{
			prev = kur;
			kur = kur->next;
		}
		if(kur)
		{
			if(prev)prev->next = kur->next;
			else if(kur==first)	first = kur->next;
			kur->value = NULL;
			delete kur;
		}
	}
	Area_Node *first;
};

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Grave_Yard_Node
{
public:
	Grave_Yard_Node(){next=NULL;}
	~Grave_Yard_Node(){};
	float x,y,z,o;
	Grave_Yard_Node *next;
};
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Grave_Yard_List
{
public:
	Grave_Yard_List(){first=NULL;}
	~Grave_Yard_List()
	{
		Grave_Yard_Node *kur = first,*prev;
		while(kur)
		{
			prev = kur;
			kur = kur->next;
			delete prev;
		}
		first = NULL;
	}
	inline void add(float x,float y,float z,float o)
	{
		Grave_Yard_Node *new_node;
		new_node = new Grave_Yard_Node();
		new_node->x = x;
		new_node->y = y;
		new_node->z = z;
		new_node->o = o;
		new_node->next = first;
		first = new_node;
	}
	Grave_Yard_Node *first;
	Creature_List	spirit_healers;
};
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//this will have a list of players and other objects
//the purpuse of grouping them is to speed up processing data
class map_cell
{
public:
    map_cell(void);
    ~map_cell(void);
	uint32				cell_last_updated;	//we do not wish to update this cell more than once
	Character_List		char_lst;			//list of characters of this cell
	Creature_List		cr_lst;				//list of creatures of this cell
	Gameobject_List		go_lst;				//list of gameobjects of this cell
	Corpse_List			corpse_lst;			//list of corpses of this cell
	Area_trigger_List	areatriggers_lst;	//list of riggers that might call an event on stepping into them

	void add_char (Character *p_char);
    void del_char (Character *p_char);
	void add_creature (creature *p_creature);
    void del_creature (creature *p_creature);
	void add_go (gameobject_instance *p_go);
    void del_go (gameobject_instance *p_go);
	void add_corpse (corpse *p_corpse);
    void del_corpse (corpse *p_corpse);
};

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//this will hold cells wich will hold gameobjects
class game_map
{
public:
    game_map(uint8 pmap_id,int32 pmin_x,int32 pmax_x,int32 pmin_y,int32 pmax_y,uint8 pcell_size,char *pname);
    ~game_map(void);
	int		min_x,min_y,max_x,max_y;  //delimiters of the map
	uint32	cells_x,cells_y;
	uint32	cell_size;	//cells are squares
	uint32	cell_count; //total numer of cells used for this map
	char	name[50];	//possibly not used
	uint32	map_id;		//id of the map
    map_cell **cells;	//will hold cells for current map
	Compressed_Update_Block temp_compressed_packet,temp_compressed_packet2;	//this will hold data for create object,destroy player.. to be sent to other clients
	NetworkPacket temp_packet,temp_packet1;	//this will hold data for create object,destroy player.. to be sent to other clients
	Area_List area_list; //holds a list of areas for this map. Used for exploration system
	Grave_Yard_List graveyard_list;
	Compressed_Update_Block	Spirit_healer_prepared_packet;

	void add_char (Character *p_char);
    void del_char (Character *p_char);
    void del_char_block (Character *p_char);
	void add_creature (creature *p_creature);
    void del_creature (creature *p_creature);
	void add_go (gameobject_instance *p_go);
    void del_go (gameobject_instance *p_go);
	void add_corpse (corpse *p_corpse);
    void del_corpse (corpse *p_corpse);
    void change_location (Character *p_char, float old_x, float old_y);
	void change_location (creature *p_cr, float old_x, float old_y);
	void update_block (Character *p_char,uint32 time_dif);	//a char will trigger a block as updatable. Gameobjects are updated only once per turn
	void send_update_packet_to_block(uint32 cell_x,uint32 cell_y,Compressed_Update_Block *packet);//each creature ads his update to players that they see it
	void on_player_entered_block(Character *p_char); //will generate and add create object info for other clients and invers
	void on_player_exited_block(Character *p_char); //will send an out of range message to all players in the block
	void send_instant_msg_to_block(float pos_x,float pos_y,NetworkPacket *packet,Character *p_char); //this will send an already prepared network packet for all players in block(should be very fast)
	void send_instant_msg_to_block(uint32 cell_x,uint32 cell_y,NetworkPacket *packet); //this will send an already prepared network packet for all players in block(should be very fast)
	void send_out_of_range_object_to_col(Character *p_char,uint32 col, uint32 row); //this will add to players the out of range block
	void send_create_object_to_col(Character *p_char,uint32 col, uint32 row); //this will add to players the ceate object block
	void send_out_of_range_object_to_row(Character *p_char,uint32 col, uint32 row); //this will add to players the out of range block
	void send_create_object_to_row(Character *p_char,uint32 col, uint32 row); //this will add to players the ceate object block

	void send_out_of_range_object_to_col(creature *p_cr,uint32 col, uint32 row); //this will add to players the out of range block
	void send_create_object_to_col(creature *p_cr,uint32 col, uint32 row); //this will add to players the ceate object block
	void send_out_of_range_object_to_row(creature *p_cr,uint32 col, uint32 row); //this will add to players the out of range block
	void send_create_object_to_row(creature *p_cr,uint32 col, uint32 row); //this will add to players the ceate object block
	void on_creature_entered_block(creature *p_cr); //will generate and add create object info for other clients and invers
	void on_creature_exited_block(creature *p_cr); //will send an out of range message to all players in the block

	void get_cell_boundary(creature *p_cr,float *buffer); //will return a set of cordinates from wich the creature should not walk out
	void get_inrange_enemy_guids(float x,float y,Target_list *list,float range_min,float range_max,uint32 faction);
	void get_inrange_friend_guids(float x,float y,Target_list *list,float range_min,float range_max,uint32 faction);
	void get_infront_enemy_guids(float x,float y,float o,Target_list *list,float range_min,float range_max,uint32 faction);
	//a character can agro creatures by it's presense. Only inrange enemy should be agroed
//	void agro_block(Character *p_char);
	void agro_block(Base_Unit_Object *p_unit);
	void rem_agro_block(Base_Unit_Object *p_unit);
	//creature on each update will send presence agro to his neighbours
	void create_spirit_healer_create_packet();
};
#endif