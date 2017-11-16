// Copyright (C) 2006 Team Evolution
#include "mapmanager.h"

//gay way to reduce list size is to make some global variables. These will have values incase the list content has been
//modified while we are using it (causes alot of crashes)
//void	*g_iter_next;
//uint32	prev_iter_del_id;
//uint32	cur_iter_del_id;

void Creature_List::del(creature *p_cr)
{
	Creature_Node *kur = first,*prev = NULL;
	while(kur && kur->value!=p_cr)
	{
		prev = kur;
		kur = kur->next;
	}
	if(kur)
	{
		if(prev)prev->next = kur->next;
		else if(kur==first)first = kur->next;
		delete kur;
	}
//	else printf("!!!!!!!could not delete creature from cell !!!!\n");
}

void Gameobject_List::del(gameobject_instance *p_go)
{
	Gameobject_Node *kur = first,*prev = NULL;
	while(kur && kur->value!=p_go)
	{
		prev = kur;
		kur = kur->next;
	}
	if(kur)
	{
		if(prev)prev->next = kur->next;
		else if(kur==first)	first = kur->next;
		delete kur;
	}
}

void Corpse_List::del(corpse *p_char)
{
	Corpse_Node *kur = first,*prev = NULL;
	while(kur && kur->value!=p_char)
	{
		prev = kur;
		kur = kur->next;
	}
	if(kur)
	{
		if(prev)prev->next = kur->next;
		else if(kur==first)	first = kur->next;
		delete kur;
	}

}

inline void Character_List::add(Character *p_char)
{
	Character_Node *new_node;
	new_node = new Character_Node(p_char);
	new_node->next = first;
	first = new_node;
#ifdef _DEBUG
	printf("added char to map cell %u\n",p_char);
	printf("Mapcell : char_p = %u\n",(uint32)p_char);
	if(p_char)
		printf("Mapcell : char_x = %f char_y = %f \n",p_char->pos_x,p_char->pos_y);
#endif
	}

void Character_List::del(Character *p_char)
{
	Character_Node *kur = first,*prev = NULL;
	while(kur && kur->value!=p_char)
	{
		prev = kur;
		kur = kur->next;
	}
	if(kur)
	{
		if(prev)prev->next = kur->next;
		else if(kur==first)	first = kur->next;
		delete kur;
#ifdef _DEBUG
		printf("deleted char to map cell %u\n",p_char);
		printf("Mapcell : char_p = %u\n",(uint32)p_char);
		printf("Mapcell : char_x = %f char_y = %f \n",p_char->pos_x,p_char->pos_y);
#endif
	}
#ifdef _DEBUG
	else
	{
		printf("!!!!!!!!! could not delete char from cel !!!!!!!!!!!!\n");
		printf("Mapcell : char_p = %u\n",(uint32)p_char);
		if(p_char)
			printf("Mapcell : char_x = %f char_y = %f \n",p_char->pos_x,p_char->pos_y);
		Character_Node *kur = first;
		while(kur && kur->value!=p_char)
		{
			printf("Mapcell : char_list_p = %u\n",(uint32)kur->value);
			kur = kur->next;
		}
	}
#endif
}

map_cell::map_cell(void)
{
   cell_last_updated=0;
}

map_cell::~map_cell(void)
{
	//we should delete all mob+go instances here or let memmanager dump them
}

inline void map_cell::add_char (Character *p_char)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_char);
#endif
   char_lst.add(p_char);
}

inline void map_cell::del_char (Character *p_char)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_char);
#endif
   char_lst.del(p_char);
}

inline void map_cell::add_creature (creature *p_creature)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_creature);
#endif
   cr_lst.add(p_creature);
}

inline void map_cell::del_creature (creature *p_creature)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_creature);
#endif
   cr_lst.del(p_creature);
}

inline void map_cell::add_go (gameobject_instance *p_go)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_go);
#endif
	go_lst.add(p_go);
}

inline void map_cell::del_go (gameobject_instance *p_go)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_go);
#endif
	go_lst.del(p_go);
}

inline void map_cell::add_corpse (corpse *p_corpse)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_corpse);
#endif
	corpse_lst.add(p_corpse);
}

inline void map_cell::del_corpse (corpse *p_corpse)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_corpse);
#endif
	corpse_lst.del(p_corpse);
}

///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////
///						game_map
///////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////

//we have 2 maps
// create cells in the map to group objects for faster processing
game_map::game_map(uint8 pmap_id,int32 pmin_x,int32 pmax_x,int32 pmin_y,int32 pmax_y,uint8 pcell_size,char *pname)
{
	signed int t;
	map_id = pmap_id;
	min_x = pmin_x;
	min_y = pmin_y;
	max_x = pmax_x;
	max_y = pmax_y;
	if(min_x>max_x)
	{
		t=min_x;
		min_x=max_x;
		max_x=t;
	}
	if(min_y>max_y)
	{
		t=min_y;
		min_y=max_y;
		max_y=t;
	}
	strcpy(name,pname);
	if(pcell_size==0)cell_size = MAPMGR_CELL_SIZE;
    else cell_size=pcell_size;
    cells_x = (max_x - min_x) / cell_size + 1; //add an extra 1 at the end
    cells_y = (max_y - min_y) / cell_size + 1;
	cell_count = cells_x*cells_y;
    cells = new map_cell*[(cells_x+2)*(cells_y+2)]; //we make a border around the map so when sending data to neighbour cell it will be valid
    ASSERT(cells);
	//populate map with cells
    for (uint32 i = 0; i < (cells_x+2)*(cells_y+2); i++)
    {
        cells[i] = new map_cell;
        ASSERT(cells[i]);
    }
	cells = cells+(cells_x+2+1); // place map begin pointer to second row and second col in the cell matrix
}

//destructor : delete all cells within the map
game_map::~game_map(void)
{
    if(cells)
    {
		cells = cells-(cells_x+2+1);
        for (uint32 i = 0; i < (cells_x+2)*(cells_y+2); i++)
            delete cells[i];
        delete [] cells;
    }
}

//calculate the object location incells
//cals cell function to add an object
void game_map::add_char (Character *p_char)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_char);
#endif
   int32 cellx,celly;
   if(p_char->pos_x<min_x || p_char->pos_x>max_x || p_char->pos_y<min_y || p_char->pos_y>max_y)return;
   cellx=(int32)fabs((p_char->pos_x - min_x) / cell_size);
   celly=(int32)fabs((p_char->pos_y - min_y) / cell_size);
   cells[celly*cells_x+cellx]->add_char(p_char);
}

//calculate from wich cell to remove the object
//cals cell function to remove object
void game_map::del_char (Character *p_char)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_char);
#endif
   int32 cellx,celly;
   cellx=(int32)fabs((p_char->pos_x - min_x) / cell_size);
   celly=(int32)fabs((p_char->pos_y - min_y) / cell_size);
   cells[celly*cells_x+cellx]->del_char(p_char);
}

//in case we skip updating char position in map always then we try to exit char from neighbour cells just to make sure no more instances exist
void game_map::del_char_block (Character *p_char)
{
   int32 cellx,celly,mx,my;
   cellx=(int32)fabs((p_char->pos_x - min_x) / cell_size) - 1;
   celly=(int32)fabs((p_char->pos_y - min_y) / cell_size) - 1;
   mx=cellx+3;
   my=celly+3;
   for(cellx;cellx<mx;cellx++)
	   for(celly;celly<my;celly++)
			cells[celly*cells_x+cellx]->del_char(p_char);
}

void game_map::add_creature (creature *p_creature)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_creature);
#endif
   int32 cellx,celly;
   if(p_creature->pos_x<min_x || p_creature->pos_x>max_x || p_creature->pos_y<min_y || p_creature->pos_y>max_y)return;
   cellx=(int32)fabs((p_creature->pos_x - min_x) / cell_size);
   celly=(int32)fabs((p_creature->pos_y - min_y) / cell_size);;
   if(cells[celly*cells_x+cellx])
	cells[celly*cells_x+cellx]->add_creature(p_creature);
}

void game_map::del_creature (creature *p_creature)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_creature);
#endif
   int32 cellx,celly;
   cellx=(int32)fabs((p_creature->pos_x - min_x) / cell_size);
   celly=(int32)fabs((p_creature->pos_y - min_y) / cell_size);;
   temp_packet.opcode = SMSG_DESTROY_OBJECT;
   temp_packet.data32[0] = p_creature->getGUIDL();
   temp_packet.data32[1] = p_creature->getGUIDH();
   temp_packet.length = 8;
   send_instant_msg_to_block(cellx,celly,&temp_packet);
   cells[celly*cells_x+cellx]->del_creature(p_creature);
}

void game_map::add_go (gameobject_instance *p_go)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_go);
#endif
   int32 cellx,celly;
   if(p_go->pos_x<min_x || p_go->pos_x>max_x || p_go->pos_y<min_y || p_go->pos_y>max_y)return;
   cellx=(int32)fabs((p_go->pos_x - min_x) / cell_size);
   celly=(int32)fabs((p_go->pos_y - min_y) / cell_size);
   cells[celly*cells_x+cellx]->add_go(p_go);
}

void game_map::del_go (gameobject_instance *p_go)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_go);
#endif
   int32 cellx,celly;
   cellx=(int32)fabs((p_go->pos_x - min_x) / cell_size);
   celly=(int32)fabs((p_go->pos_y - min_y) / cell_size);
   temp_packet.opcode = SMSG_DESTROY_OBJECT;
   temp_packet.data32[0] = p_go->getGUIDL();
   temp_packet.data32[1] = p_go->getGUIDH();
   temp_packet.length = 8;
   send_instant_msg_to_block(cellx,celly*cells_x,&temp_packet);
   cells[celly*cells_x+cellx]->del_go(p_go);
}

void game_map::add_corpse (corpse *p_corpse)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_corpse);
#endif
   int32 cellx,celly;
   if(p_corpse->pos_x<min_x || p_corpse->pos_x>max_x || p_corpse->pos_y<min_y || p_corpse->pos_y>max_y)return;
   cellx=(int32)fabs((p_corpse->pos_x - min_x) / cell_size);
   celly=(int32)fabs((p_corpse->pos_y - min_y) / cell_size);
   cells[celly*cells_x+cellx]->add_corpse(p_corpse);
}

void game_map::del_corpse (corpse *p_corpse)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_corpse);
#endif
   int32 cellx,celly;
   cellx=(int32)fabs((p_corpse->pos_x - min_x) / cell_size);
   celly=(int32)fabs((p_corpse->pos_y - min_y) / cell_size);
   cells[celly*cells_x+cellx]->del_corpse(p_corpse);
}

//calculates current and old cell location
//if it changed then remove from old cell and put into new one
//!!! somewhere we should check if player walked out of map
void game_map::change_location (Character *p_char, float old_x, float old_y)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_char);
	uint32 start_time,end_time;
	start_time = GetMilliseconds();
#endif
	int32 cur_cellx,cur_celly;
    int32 old_cellx,old_celly;
	cur_cellx=(int32)fabs((p_char->pos_x - min_x) / cell_size);
    cur_celly=(int32)fabs((p_char->pos_y - min_y) / cell_size);
    old_cellx=(int32)fabs((old_x - min_x) / cell_size);
    old_celly=(int32)fabs((old_y - min_y) / cell_size);
#ifndef DISABLE_CUSTOM_TRIGGER_CHECKS
//printf("checking on map %u cx%u and cy %u triggers\n",p_char->map_id,cur_cellx,cur_celly);
	if(cells[cur_celly*cells_x+cur_cellx]->areatriggers_lst.trigger_areatriggers(p_char->getGUID(),p_char->pos_x,p_char->pos_y,p_char->pos_z,p_char->areatrigger_lastcheck_x,p_char->areatrigger_lastcheck_y,p_char->areatrigger_lastcheck_z))
	{
		p_char->areatrigger_lastcheck_x = p_char->pos_x;
		p_char->areatrigger_lastcheck_y = p_char->pos_y;
		p_char->areatrigger_lastcheck_z = p_char->pos_z;
	}
#endif
	if(cur_cellx!=old_cellx || cur_celly!=old_celly)
	{
		signed int selected_cell;
		//move char to new cell
		selected_cell=old_celly*cells_x+old_cellx;
        if(selected_cell>(int)cell_count || selected_cell<0)return; //if we fell out of map then we exit this function
		cells[selected_cell]->del_char(p_char);
		selected_cell=cur_celly*cells_x+cur_cellx;
        if(selected_cell>(int)cell_count || selected_cell<0)return; //if we fell out of map then we exit this function
		cells[selected_cell]->add_char(p_char);
	}
	else return;
//printf("char changed cell cx=%d cy=%d ox=%d oy=%d x=%f y=%f\n",cur_cellx,cur_celly,old_cellx,old_celly,p_char->pos_x,p_char->pos_y);
	if(cur_cellx==old_cellx-1)
	{
		//exit all the blocks that we were in but left them (can be more than 1)
		send_out_of_range_object_to_col(p_char,old_cellx+1,cur_celly);
		send_create_object_to_col(p_char,cur_cellx-1,cur_celly);
	}
	//if we moved to Eastern cell
	else if(cur_cellx==old_cellx+1)
	{
		send_out_of_range_object_to_col(p_char,old_cellx-1,cur_celly);
		send_create_object_to_col(p_char,cur_cellx+1,cur_celly);
	}
	//if we moved to Northern cell
	else if(cur_celly==old_celly-1)
	{
		send_out_of_range_object_to_row(p_char,cur_cellx,old_celly+1);
		send_create_object_to_row(p_char,cur_cellx,cur_celly-1);
	}
	//if we moved to Southern cell
	else if(cur_celly==old_celly+1)
	{
		send_out_of_range_object_to_row(p_char,cur_cellx,old_celly-1);
		send_create_object_to_row(p_char,cur_cellx,cur_celly+1);
	}
	else
	{
		//in case of a teleport we move more then just 1 cell
		float x,y;
		x = p_char->pos_x;
		y = p_char->pos_y;
		p_char->pos_x = old_x;
		p_char->pos_y = old_y;
		on_player_exited_block(p_char);
		p_char->pos_x = x;
		p_char->pos_y = y;
		on_player_entered_block(p_char);
	}
#ifdef DEBUG_MAPMANAGER_VERSION
	end_time = GetMilliseconds();
	if(end_time-start_time>0)
		printf("MapManager: requred time = %u ms to change location\n",end_time-start_time);
#endif
}

//calculates current and old cell location
//if it changed then remove from old cell and put into new one
//!!! somewhere we should check if player walked out of map
void game_map::change_location (creature *p_cr, float old_x, float old_y)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_cr);
	uint32 start_time,end_time;
	start_time = GetMilliseconds();
#endif
	int32 cur_cellx,cur_celly;
    int32 old_cellx,old_celly;
	cur_cellx=(int32)fabs((p_cr->pos_x - min_x) / cell_size);
    cur_celly=(int32)fabs((p_cr->pos_y - min_y) / cell_size);
    old_cellx=(int32)fabs((old_x - min_x) / cell_size);
    old_celly=(int32)fabs((old_y - min_y) / cell_size);
#ifndef DISABLE_CUSTOM_TRIGGER_CHECKS_FOR_CREATURES
	if(cells[cur_celly*cells_x+cur_cellx]->areatriggers_lst.trigger_areatriggers(p_cr->getGUID(),p_cr->pos_x,p_cr->pos_y,p_cr->pos_z,p_cr->areatrigger_lastcheck_x,p_cr->areatrigger_lastcheck_y,p_cr->areatrigger_lastcheck_z))
	{
		p_cr->areatrigger_lastcheck_x = p_cr->pos_x;
		p_cr->areatrigger_lastcheck_y = p_cr->pos_y;
		p_cr->areatrigger_lastcheck_z = p_cr->pos_z;
	}
#endif
	if(cur_cellx!=old_cellx || cur_celly!=old_celly)
	{
		signed int selected_cell;
		selected_cell=old_celly*cells_x+old_cellx;
        if(selected_cell>(int)cell_count || selected_cell<0)return; //if we fell out of map then we exit this function
		cells[selected_cell]->del_creature(p_cr);
		selected_cell=cur_celly*cells_x+cur_cellx;
        if(selected_cell>(int)cell_count || selected_cell<0)return; //if we fell out of map then we exit this function
		cells[selected_cell]->add_creature(p_cr);
	}
	else return;
//if(WORLDSERVER.debug_guid==p_cr->getGUID())
//printf("creature changed cell cx=%d cy=%d ox=%d oy=%d x=%f y=%f\n",cur_cellx,cur_celly,old_cellx,old_celly,p_cr->pos_x,p_cr->pos_y);
	//if we moved to West cell
	if(cur_cellx==old_cellx-1)
	{
		send_out_of_range_object_to_col(p_cr,old_cellx+(Player_affect_neighbour_cells),cur_celly);
		send_create_object_to_col(p_cr,cur_cellx-(Player_affect_neighbour_cells),cur_celly);
	}
	//if we moved to Eastern cell
	else if(cur_cellx==old_cellx+1)
	{
		send_out_of_range_object_to_col(p_cr,old_cellx-(Player_affect_neighbour_cells),cur_celly);
		send_create_object_to_col(p_cr,cur_cellx+(Player_affect_neighbour_cells),cur_celly);
	}
	//if we moved to Northern cell
	else if(cur_celly==old_celly-1)
	{
		send_out_of_range_object_to_row(p_cr,cur_cellx,old_celly+(Player_affect_neighbour_cells));
		send_create_object_to_row(p_cr,cur_cellx,cur_celly-(Player_affect_neighbour_cells));
	}
	//if we moved to Southern cell
	else if(cur_celly==old_celly+1)
	{
		send_out_of_range_object_to_row(p_cr,cur_cellx,old_celly-(Player_affect_neighbour_cells));
		send_create_object_to_row(p_cr,cur_cellx,cur_celly+(Player_affect_neighbour_cells));
	}
	else
	{
		//in case of a teleport we move more then just 1 cell
#ifdef _DEBUG
		printf("OMG creature moved more then one cell in 1 turn \n");
#endif
		float x,y;
		x = p_cr->pos_x;
		y = p_cr->pos_y;
		p_cr->pos_x = old_x;
		p_cr->pos_y = old_y;
		on_creature_exited_block(p_cr);
		p_cr->pos_x = x;
		p_cr->pos_y = y;
		on_creature_entered_block(p_cr);
	}
	//send out creature agro so they will attack each other
	agro_block(p_cr);
	p_cr->agro_sent_time = G_cur_time_ms + WORLD_MIN_UPDATE_INTERVAL*CREATURE_AGRO_SEND_TIME_INTERVAL;
#ifdef DEBUG_MAPMANAGER_VERSION
	end_time = GetMilliseconds();
	if(end_time-start_time>0)
		printf("MapManager: requred time = %u ms to change location\n",end_time-start_time);
#endif
}

//update Player. send it's udate data to all players in his block
//also update all cells from block that were not updated by other players
//updated creatures send to their block their updata
//MORE UPDATEBLOCKS CAN BE GROUPED INTO ONE A9
void game_map::update_block (Character *p_char,uint32 time_dif)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_char);
	uint32 start_time,end_time;
	start_time = GetMilliseconds();
	if(time_dif==0)
		return; //this is very improbable, but better make safe than sorry
#endif
   int32 min_cellx,min_celly,max_cellx,max_celly,cur_x;
   map_cell *cur_cell;
   Character_Node *char_itr;
   Creature_Node *cr_itr;
   Gameobject_Node *go_itr;
   void *next,*obj;
   //update cur char
	p_char->update(time_dif);
	//always update ourself first to cache the data
	p_char->build_update_block(&p_char->pClient->compressed_update,1,1);
	//get the cell in wich the object is
		//we shift it's position to get always pos values
   min_cellx=(int32)fabs((p_char->pos_x - min_x) / cell_size);
   min_celly=(int32)fabs((p_char->pos_y - min_y) / cell_size);
   max_celly=min_celly+Player_affect_neighbour_cells;
   max_cellx=min_cellx+Player_affect_neighbour_cells;
   min_celly-=Player_affect_neighbour_cells;
   min_cellx-=Player_affect_neighbour_cells;
   if(max_celly>(int)cells_y) max_celly=cells_y;
   if(max_cellx>(int)cells_x) max_cellx=cells_x;
   if(min_celly<0)min_celly=0;
   if(min_cellx<0)min_cellx=0;
   //we update the whole block = 9 cells. The p_char is standing in the middle
	    //set cells as updated
   for(;min_celly<=max_celly;min_celly++)
       for(cur_x=min_cellx;cur_x<=max_cellx;cur_x++)
       {
			//get one cell from the block
			cur_cell=cells[min_celly*cells_x+cur_x];
			//we add the current char updata to other chars in the block
			char_itr = cur_cell->char_lst.first;
			while(char_itr)
			{
				if(char_itr->value!=p_char)
					p_char->build_update_block(&char_itr->value->pClient->compressed_update,0,0);
				char_itr = char_itr->next;
			}
			//if another player already updated this cell then we can exit now
			if(cur_cell->cell_last_updated==G_turn_id)
					continue;
			temp_compressed_packet.clear();
			//objects can be removed from list while updating
			cr_itr = cur_cell->cr_lst.first;
			while(cr_itr)
			{
				next = cr_itr->next;
				obj = cr_itr->value;
				((creature*)obj)->update(); //it is possible that while updating we remove object from list
				((creature*)obj)->build_update_block(&temp_compressed_packet,0,1); //get their create packet
				cr_itr = (Creature_Node *)next;
			}
			go_itr = cur_cell->go_lst.first;
			while(go_itr)
			{
				next = go_itr->next;
				obj = go_itr->value;
				((gameobject_instance*)obj)->update();
				((gameobject_instance*)obj)->build_update_block(&temp_compressed_packet,0,1); //get their create packet
				go_itr = (Gameobject_Node *)next;
			}
			//mark cell that it has been updated this turn
			cur_cell->cell_last_updated=G_turn_id;
			send_update_packet_to_block(min_cellx,min_celly,&temp_compressed_packet);
	   } //end iterate through block
#ifdef DEBUG_MAPMANAGER_VERSION
	end_time = GetMilliseconds();
	if(end_time-start_time>0)
		printf("MapManager: requred time = %u ms to update bloc for player %s\n",end_time-start_time,p_char->name);
#endif
}

//each creature/go.. ads his update block to each player that he sees it
void game_map::send_update_packet_to_block(uint32 cell_x,uint32 cell_y,Compressed_Update_Block *packet)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	uint32 start_time,end_time;
	start_time = GetMilliseconds();
#endif
   uint32 min_cellx,min_celly,max_cellx,max_celly,cur_x;
   Character_Node *char_itr;
   //get the cell in wich the object is
		//we shift it's position to get always pos values
   min_cellx=cell_x;
   min_celly=cell_y;
   max_celly=min_celly+Player_affect_neighbour_cells;
   max_cellx=min_cellx+Player_affect_neighbour_cells;
   if(min_celly<Player_affect_neighbour_cells)min_celly=0;
   else min_celly-=Player_affect_neighbour_cells;
   if(min_cellx<Player_affect_neighbour_cells)min_cellx=0;
   else min_cellx-=Player_affect_neighbour_cells;
   if(max_celly>cells_y) max_celly=cells_y;
   if(max_cellx>cells_x) max_cellx=cells_x;
   for(;min_celly<=max_celly;min_celly++)
       for(cur_x=min_cellx;cur_x<=max_cellx;cur_x++)
       {
			char_itr = cells[min_celly*cells_x+cur_x]->char_lst.first;
			while(char_itr)
			{
				char_itr->value->pClient->compressed_update.add_blocks_from_other_packet(packet);
				char_itr = char_itr->next;
			}
	   } //end iterate through block
#ifdef DEBUG_MAPMANAGER_VERSION
	end_time = GetMilliseconds();
	if(end_time-start_time>0)
		printf("MapManager: requred time = %u ms to send 1 packet to block(cel)\n",end_time-start_time);
#endif
}

//create blocks cannot be grouped into 1 A9 :(
void game_map::on_player_entered_block (Character *p_char)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_char);
	uint32 start_time,end_time;
	start_time = GetMilliseconds();
#endif
   uint32 min_cellx,min_celly,max_cellx,max_celly,cur_x;
   map_cell *cur_cell;
   Character_Node *char_itr;
   Creature_Node *cr_itr;
   Gameobject_Node *go_itr;
   Corpse_Node	*corps_itr;
   //get the cell in wich the object is
		//we shift it's position to get always pos values
   if(p_char->pos_x<min_x || p_char->pos_x>max_x || p_char->pos_y<min_y || p_char->pos_y>max_y)return;
   min_cellx=(int32)fabs((p_char->pos_x - min_x) / cell_size);
   min_celly=(int32)fabs((p_char->pos_y - min_y) / cell_size);
   max_celly=min_celly+Player_affect_neighbour_cells;
   max_cellx=min_cellx+Player_affect_neighbour_cells;
   min_celly-=Player_affect_neighbour_cells;
   min_cellx-=Player_affect_neighbour_cells;
   if(max_celly>cells_y) max_celly=cells_y;
   if(max_cellx>cells_x) max_cellx=cells_x;
   if(min_celly<0)min_celly=0;
   if(min_cellx<0)min_cellx=0;
   //create 1 create block and send it to all players
   temp_compressed_packet2.clear();
   p_char->build_create_block(&temp_compressed_packet2,0); //get our create packet
   for(;min_celly<=max_celly;min_celly++)
       for(cur_x=min_cellx;cur_x<=max_cellx;cur_x++)
       {
			//get one cell from the block
			cur_cell=cells[min_celly*cells_x+cur_x];
				//add create data to all players in this cell
				//+players will add their create data to this player
			//each player will make it's create block that will be sent to us
			//we send to them our create packet 2
			char_itr = cur_cell->char_lst.first;
			while(char_itr)
			{
				if(p_char!=char_itr->value)
				{
					temp_compressed_packet.clear();
					char_itr->value->build_create_block(&temp_compressed_packet,0); //get their create packet
					p_char->SendMsg(temp_compressed_packet.build_packet());
//					char_itr->value->build_create_block(&p_char->pClient->compressed_update,0,G_turn_id); //get their create packet
					char_itr->value->pClient->SendMsg(temp_compressed_packet2.build_packet());
				}
				char_itr = char_itr->next;
			}
			cr_itr = cur_cell->cr_lst.first;
			while(cr_itr)
			{
				cr_itr->value->build_create_block(&p_char->pClient->compressed_update,0); //get their create packet
				cr_itr = cr_itr->next;
			}
			go_itr = cur_cell->go_lst.first;
			while(go_itr)
			{
				go_itr->value->build_create_block(&p_char->pClient->compressed_update,0); //get their create packet
				go_itr = go_itr->next;
			}
			corps_itr = cur_cell->corpse_lst.first;
			while (corps_itr)
			{
				corps_itr->value->build_create_block(&p_char->pClient->compressed_update,0,G_turn_id); //get their create packet
				corps_itr = corps_itr->next;
			}
	   } //end iterate through block
#ifdef DEBUG_MAPMANAGER_VERSION
	end_time = GetMilliseconds();
	if(end_time-start_time>0)
		printf("MapManager: requred time = %u ms to send create block for player %s\n",end_time-start_time,p_char->name);
#endif
}

//will send an out of range message to all players in the block
//called rarely
void game_map::on_player_exited_block(Character *p_char)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_char);
	uint32 start_time,end_time;
	start_time = GetMilliseconds();
#endif
   uint32 min_cellx,min_celly,max_cellx,max_celly,cur_x;
   map_cell *cur_cell;
   Character_Node *char_itr;
   Creature_Node *cr_itr;
   Gameobject_Node *go_itr;
   Corpse_Node	*corps_itr;
   if(p_char->pos_x<min_x || p_char->pos_x>max_x || p_char->pos_y<min_y || p_char->pos_y>max_y)return;
   min_cellx=(int32)fabs((p_char->pos_x - min_x) / cell_size);
   min_celly=(int32)fabs((p_char->pos_y - min_y) / cell_size);
   max_celly=min_celly+Player_affect_neighbour_cells;
   max_cellx=min_cellx+Player_affect_neighbour_cells;
   min_celly-=Player_affect_neighbour_cells;
   min_cellx-=Player_affect_neighbour_cells;
   if(max_celly>cells_y) max_celly=cells_y;
   if(max_cellx>cells_x) max_cellx=cells_x;
   if(min_celly<0)min_celly=0;
   if(min_cellx<0)min_cellx=0;
   //prepare packet to be sent(it is a small packet -> less than 9 if's +..)
   temp_packet.opcode = SMSG_DESTROY_OBJECT;
   temp_packet.length = 8;
   temp_packet1.opcode = SMSG_DESTROY_OBJECT;
   temp_packet1.data32[0] = p_char->getGUIDL();
   temp_packet1.data32[1] = p_char->getGUIDH();
   temp_packet1.length = 8;
//   send_instant_msg_to_block(p_char->pos_x,p_char->pos_y,&temp_packet,p_char);
//   send_instant_msg_to_block(p_char->pos_x,p_char->pos_y,&temp_packet1,NULL);
   //destroy objects from the block for player. if we do not destroy them incase we come back to block,
   //and they are dead, we might see them alive = bad
   for(;min_celly<=max_celly;min_celly++)
       for(cur_x=min_cellx;cur_x<=max_cellx;cur_x++)
       {
		//get one cell from the block
		cur_cell=cells[min_celly*cells_x+cur_x];
			//add create data to all players in this cell
			//+players will add their create data to this player
		char_itr = cur_cell->char_lst.first;
		while(char_itr)
		{
			if(char_itr->value!=p_char) //do not destroy self
			{
				//destroy us for that client
				char_itr->value->pClient->SendMsg(&temp_packet1);
				//destroy this client for us
			    temp_packet.data32[0] = char_itr->value->getGUIDL();
			    temp_packet.data32[1] = char_itr->value->getGUIDH();
				p_char->pClient->SendMsg(&temp_packet);
			}
			char_itr = char_itr->next;
		}
		cr_itr = cur_cell->cr_lst.first;
		while(cr_itr)
		{
		    temp_packet.data32[0] = cr_itr->value->getGUIDL();
		    temp_packet.data32[1] = cr_itr->value->getGUIDH();
			p_char->pClient->SendMsg(&temp_packet);
			//also remove hate for this col
			cr_itr->value->agro_list.del(p_char->getGUID());
			cr_itr = cr_itr->next;
		}
		go_itr = cur_cell->go_lst.first;
		while(go_itr)
		{
		    temp_packet.data32[0] = go_itr->value->getGUIDL();
		    temp_packet.data32[1] = go_itr->value->getGUIDH();
			p_char->pClient->SendMsg(&temp_packet);
			go_itr = go_itr->next;
		}
		corps_itr = cur_cell->corpse_lst.first;
		while (corps_itr)
		{
			temp_packet.data32[0] = corps_itr->value->getGUIDL();
			temp_packet.data32[1] = corps_itr->value->getGUIDH();
			p_char->pClient->SendMsg(&temp_packet);
			corps_itr = corps_itr->next;
		}
	} //end iterate through block
#ifdef DEBUG_MAPMANAGER_VERSION
	end_time = GetMilliseconds();
	if(end_time-start_time>0)
		printf("MapManager: requred time = %u ms to send outofrange to col\n",end_time-start_time);
#endif
}

//used almost in every turn allot of times. Send a prepared packet to block (like movement change)
void game_map::send_instant_msg_to_block(float pos_x,float pos_y,NetworkPacket *packet,Character *p_char)
{
	if(!packet) return;
#ifdef DEBUG_MAPMANAGER_VERSION
	uint32 start_time,end_time;
	start_time = GetMilliseconds();
#endif
   uint32 min_cellx,min_celly,max_cellx,max_celly,cur_x;
   map_cell *cur_cell;
   Character_Node *char_itr;
   //get the cell in wich the object is
		//we shift it's position to get always pos values
   min_cellx=(uint32)fabs((pos_x - min_x) / cell_size);
   min_celly=(uint32)fabs((pos_y - min_y) / cell_size);
   max_celly=min_celly+Player_affect_neighbour_cells;
   max_cellx=min_cellx+Player_affect_neighbour_cells;
   min_celly-=Player_affect_neighbour_cells;
   min_cellx-=Player_affect_neighbour_cells;
   if(max_celly>cells_y) max_celly=cells_y;
   if(max_cellx>cells_x) max_cellx=cells_x;
   if(min_celly<0)min_celly=0;
   if(min_cellx<0)min_cellx=0;
   if(p_char!=NULL)
   {
	   for(;min_celly<=max_celly;min_celly++)
		   for(cur_x=min_cellx;cur_x<=max_cellx;cur_x++)
		   {
			   //get one cell from the block
			   cur_cell=cells[min_celly*cells_x+cur_x];
			   //send to others (not to us)
			   char_itr = cur_cell->char_lst.first;
			   while(char_itr)
			   {
				   if(char_itr->value!=p_char)
					   char_itr->value->pClient->SendMsg(packet);
				   char_itr = char_itr->next;
			   }
		   } //end iterate through block
   }
   else
   {
	   for(;min_celly<=max_celly;min_celly++)
		   for(cur_x=min_cellx;cur_x<=max_cellx;cur_x++)
		   {
			   //get one cell from the block
			   cur_cell=cells[min_celly*cells_x+cur_x];
			   //send to others (not to us)
			   char_itr = cur_cell->char_lst.first;
			   while(char_itr)
			   {
//!!!!!!!!!!sometimes char is not removed from list. WHY ???????
				   char_itr->value->pClient->SendMsg(packet);
				   char_itr = char_itr->next;
			   }
		   } //end iterate through block

   }
#ifdef DEBUG_MAPMANAGER_VERSION
	end_time = GetMilliseconds();
	if(end_time-start_time>0)
		printf("MapManager: requred time = %u ms to send 1 packet to block(pos)\n",end_time-start_time);
#endif
}

//used almoust in evry turn alot of times. Send a prepared packet to block (like movement change)
void game_map::send_instant_msg_to_block(uint32 cell_x,uint32 cell_y,NetworkPacket *packet)
{
   if(!packet) return;
#ifdef DEBUG_MAPMANAGER_VERSION
	uint32 start_time,end_time;
	start_time = GetMilliseconds();
#endif
   uint32 min_cellx,min_celly,max_cellx,max_celly,cur_x;
   map_cell *cur_cell;
   Character_Node *char_itr;
   //get the cell in wich the object is
		//we shift it's position to get always pos values
   min_cellx=cell_x;
   min_celly=cell_y;
   max_celly=min_celly+Player_affect_neighbour_cells;
   max_cellx=min_cellx+Player_affect_neighbour_cells;
   if(min_celly<Player_affect_neighbour_cells)min_celly=0;
   else min_celly-=Player_affect_neighbour_cells;
   if(min_cellx<Player_affect_neighbour_cells)min_cellx=0;
   else min_cellx-=Player_affect_neighbour_cells;
   if(max_celly>cells_y) max_celly=cells_y;
   if(max_cellx>cells_x) max_cellx=cells_x;
   for(;min_celly<=max_celly;min_celly++)
       for(cur_x=min_cellx;cur_x<=max_cellx;cur_x++)
       {
			//get one cell from the block
			cur_cell=cells[min_celly*cells_x+cur_x];
				//send to others (not to us)
			char_itr = cur_cell->char_lst.first;
			while(char_itr)
			{
				char_itr->value->pClient->SendMsg(packet);
				char_itr = char_itr->next;
			}
	   } //end iterate through block
#ifdef DEBUG_MAPMANAGER_VERSION
	end_time = GetMilliseconds();
	if(end_time-start_time>0)
		printf("MapManager: requred time = %u ms to send 1 packet to block(cel)\n",end_time-start_time);
#endif
}

//inform players in this col that we left them = moved into a new cell
void game_map::send_out_of_range_object_to_col(Character *p_char,uint32 col, uint32 row)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_char);
	uint32 start_time,end_time;
	start_time = GetMilliseconds();
#endif
   uint32 cur_cellx,min_celly,max_celly;
   map_cell *cur_cell;
   Character_Node *char_itr;
   Creature_Node *cr_itr;
   Gameobject_Node *go_itr;
   Corpse_Node *corps_itr;
   //get the cell in wich the object is
		//we shift it's position to get always pos values
   cur_cellx=col;
   max_celly=row+Player_affect_neighbour_cells;
   min_celly=row-Player_affect_neighbour_cells;
   if(max_celly>cells_y) max_celly=cells_y;
   if(cur_cellx>(int)cells_x)return; //if we fell out of map then we exit this function
   if(min_celly<0)min_celly=0;
   if(cur_cellx<0)return; //if we fell out of map then we exit this function
   //prepare packet to be sent(it is a small packet -> less than 9 if's +..)
   temp_packet.opcode = SMSG_DESTROY_OBJECT;
   temp_packet.length = 8;
   temp_packet1.opcode = SMSG_DESTROY_OBJECT;
   temp_packet1.data32[0] = p_char->getGUIDL();
   temp_packet1.data32[1] = p_char->getGUIDH();
   temp_packet1.length = 8;
   for(;min_celly<=max_celly;min_celly++)
   {
		//get one cell from the block
		cur_cell=cells[min_celly*cells_x+cur_cellx];
			//add create data to all players in this cell
			//+players will add their create data to this player
		char_itr = cur_cell->char_lst.first;
		while(char_itr)
		{
			//destroy us for that client
			char_itr->value->pClient->SendMsg(&temp_packet1);
		    temp_packet.data32[0] = char_itr->value->getGUIDL();
		    temp_packet.data32[1] = char_itr->value->getGUIDH();
			//destroy for us that client
			p_char->pClient->SendMsg(&temp_packet);
			char_itr = char_itr->next;
		}
		cr_itr = cur_cell->cr_lst.first;
		while(cr_itr)
		{
		    temp_packet.data32[0] = cr_itr->value->getGUIDL();
		    temp_packet.data32[1] = cr_itr->value->getGUIDH();
			p_char->pClient->SendMsg(&temp_packet);
			//also remove hate for this col
			cr_itr = cr_itr->next;
		}
		go_itr = cur_cell->go_lst.first;
		while(go_itr)
		{
		    temp_packet.data32[0] = go_itr->value->getGUIDL();
		    temp_packet.data32[1] = go_itr->value->getGUIDH();
			p_char->pClient->SendMsg(&temp_packet);
			go_itr = go_itr->next;
		}
		corps_itr = cur_cell->corpse_lst.first;
		while (corps_itr)
		{
			temp_packet.data32[0] = corps_itr->value->getGUIDL();
			temp_packet.data32[1] = corps_itr->value->getGUIDH();
			p_char->pClient->SendMsg(&temp_packet);
			corps_itr = corps_itr->next;
		}
	} //end iterate through block
#ifdef DEBUG_MAPMANAGER_VERSION
	end_time = GetMilliseconds();
	if(end_time-start_time>0)
		printf("MapManager: requred time = %u ms to send outofrange to col\n",end_time-start_time);
#endif
}

//inform players in this col that we arrived here,also get their create object packet
void game_map::send_create_object_to_col(Character *p_char,uint32 col, uint32 row)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_char);
	uint32 start_time,end_time;
	start_time = GetMilliseconds();
#endif
   uint32 cur_cellx,min_celly,max_celly;
   map_cell *cur_cell;
   Character_Node *char_itr;
   Creature_Node *cr_itr;
   Gameobject_Node *go_itr;
   Corpse_Node *corps_itr;
   //get the cell in wich the object is
		//we shift it's position to get always pos values
   cur_cellx=col;
   max_celly=row+Player_affect_neighbour_cells;
   min_celly=row-Player_affect_neighbour_cells;
   if(max_celly>cells_y) max_celly=cells_y;
   if(cur_cellx>(int)cells_x)return; //if we fell out of map then we exit this function
   if(min_celly<0)min_celly=0;
   if(cur_cellx<0)return; //if we fell out of map then we exit this function
   //create 1 create block and send it to all players
   temp_compressed_packet.clear();
   p_char->build_create_block(&temp_compressed_packet,0); //get their create packet
   for(;min_celly<=max_celly;min_celly++)
   {
		//get one cell from the block
		cur_cell=cells[min_celly*cells_x+cur_cellx];
			//add create data to all players in this cell
			//+players will add their create data to this player
		char_itr = cur_cell->char_lst.first;
		while(char_itr)
		{
			if(char_itr->value!=p_char)
			{
				temp_compressed_packet2.clear();
				char_itr->value->build_create_block(&temp_compressed_packet2,0); //get their create packet
				p_char->SendMsg(temp_compressed_packet2.build_packet());
				char_itr->value->pClient->SendMsg(temp_compressed_packet.build_packet());

//				char_itr->value->build_create_block(&p_char->pClient->compressed_update,0); //get their create packet
				//create us for that client
//				char_itr->value->pClient->SendMsg(temp_compressed_packet.build_packet());
			}
			char_itr = char_itr->next;
		}
		cr_itr = cur_cell->cr_lst.first;
		while(cr_itr)
		{
			cr_itr->value->build_create_block(&p_char->pClient->compressed_update,0); //get their create packet
			//also remove hate for this col
			cr_itr = cr_itr->next;
		}
		go_itr = cur_cell->go_lst.first;
		while(go_itr)
		{
			go_itr->value->build_create_block(&p_char->pClient->compressed_update,0); //get their create packet
			go_itr = go_itr->next;
		}
		corps_itr = cur_cell->corpse_lst.first;
		while (corps_itr)
		{
			corps_itr->value->build_create_block(&p_char->pClient->compressed_update,0,G_turn_id); //get their create packet
			corps_itr = corps_itr->next;
		}
	} //end iterate through block
#ifdef DEBUG_MAPMANAGER_VERSION
	end_time = GetMilliseconds();
	if(end_time-start_time>0)
		printf("MapManager: requred total = %u ms to send createobject to col\n",end_time-start_time);
#endif
}

//inform players in this row that we left them = moved into a new cell
void game_map::send_out_of_range_object_to_row(Character *p_char,uint32 col, uint32 row)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_char);
	uint32 start_time,end_time;
	start_time = GetMilliseconds();
#endif
   uint32 min_cellx,cur_celly,max_cellx;
   map_cell *cur_cell;
   Character_Node *char_itr;
   Creature_Node *cr_itr;
   Gameobject_Node *go_itr;
   Corpse_Node *corps_itr;
   //get the cell in wich the object is
		//we shift it's position to get always pos values
   cur_celly=row;
   max_cellx=col+Player_affect_neighbour_cells;
   min_cellx=col-Player_affect_neighbour_cells;
   if(max_cellx>cells_x) max_cellx=cells_x;
   if(min_cellx<0)min_cellx=0;
   //prepare the data holder
   temp_packet.opcode = SMSG_DESTROY_OBJECT;
   temp_packet.length = 8;
   temp_packet1.opcode = SMSG_DESTROY_OBJECT;
   temp_packet1.data32[0] = p_char->getGUIDL();
   temp_packet1.data32[1] = p_char->getGUIDH();
   temp_packet1.length = 8;
   for(;min_cellx<=max_cellx;min_cellx++)
   {
		//get one cell from the block
		cur_cell=cells[cur_celly*cells_x+min_cellx];
			//add create data to all players in this cell
			//+players will add their create data to this player
		char_itr = cur_cell->char_lst.first;
		while(char_itr)
		{
			//destroy us for that client
			char_itr->value->pClient->SendMsg(&temp_packet1);
		    temp_packet.data32[0] = char_itr->value->getGUIDL();
		    temp_packet.data32[0] = char_itr->value->getGUIDH();
			//destroy that client for us
			p_char->pClient->SendMsg(&temp_packet);
			char_itr = char_itr->next;
		}
		cr_itr = cur_cell->cr_lst.first;
		while(cr_itr)
		{
		    temp_packet.data32[0] = cr_itr->value->getGUIDL();
		    temp_packet.data32[1] = cr_itr->value->getGUIDH();
			p_char->pClient->SendMsg(&temp_packet);
			//also remove hate for this col
			cr_itr = cr_itr->next;
		}
		go_itr = cur_cell->go_lst.first;
		while(go_itr)
		{
		    temp_packet.data32[0] = go_itr->value->getGUIDL();
		    temp_packet.data32[1] = go_itr->value->getGUIDH();
			p_char->pClient->SendMsg(&temp_packet);
			go_itr = go_itr->next;
		}
		corps_itr = cur_cell->corpse_lst.first;
		while (corps_itr)
		{
			temp_packet.data32[0] = corps_itr->value->getGUIDL();
			temp_packet.data32[1] = corps_itr->value->getGUIDH();
			p_char->pClient->SendMsg(&temp_packet);
			corps_itr = corps_itr->next;
		}
   } //end iterate through block
#ifdef DEBUG_MAPMANAGER_VERSION
	end_time = GetMilliseconds();
	if(end_time-start_time>0)
		printf("MapManager: requred = %u ms to send outofrange to row\n",end_time-start_time);
#endif
}

//inform players in this col that we arrived here,also get their create object packet
void game_map::send_create_object_to_row(Character *p_char,uint32 col, uint32 row)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_char);
	uint32 start_time,end_time;
	start_time = GetMilliseconds();
#endif
   uint32 min_cellx,cur_celly,max_cellx;
   map_cell *cur_cell;
   Character_Node *char_itr;
   Creature_Node *cr_itr;
   Gameobject_Node *go_itr;
   Corpse_Node	*corps_itr;
   //get the cell in wich the object is
		//we shift it's position to get always pos values
   cur_celly=row;
   max_cellx=col+Player_affect_neighbour_cells;
   min_cellx=col-Player_affect_neighbour_cells;
   if(cur_celly>(int)cells_y) return;
   if(max_cellx>cells_x) max_cellx=cells_x;
   if(cur_celly<0) return;
   if(min_cellx<0)min_cellx=0;
   //create 1 create block and send it to all players
   temp_compressed_packet.clear();
   p_char->build_create_block(&temp_compressed_packet,0); //get their create packet
   for(;min_cellx<=max_cellx;min_cellx++)
   {
		//get one cell from the block
		cur_cell=cells[cur_celly*cells_x+min_cellx];
			//add create data to all players in this cell
			//+players will add their create data to this player
//printf("trying to send a createobj for cell [%u,%u]\n",cur_celly,min_cellx);
		char_itr = cur_cell->char_lst.first;
		while(char_itr)
		{
			if(char_itr->value!=p_char)
			{
				temp_compressed_packet2.clear();
				char_itr->value->build_create_block(&temp_compressed_packet2,0); //get their create packet
				p_char->SendMsg(temp_compressed_packet2.build_packet());
				char_itr->value->pClient->SendMsg(temp_compressed_packet.build_packet());

//				char_itr->value->build_create_block(&p_char->pClient->compressed_update,0); //get their create packet
				//create us for that client
//				char_itr->value->pClient->SendMsg(temp_compressed_packet.build_packet());
			}
			char_itr = char_itr->next;
		}
		cr_itr = cur_cell->cr_lst.first;
		while(cr_itr)
		{
			cr_itr->value->build_create_block(&p_char->pClient->compressed_update,0); //get their create packet
			//also remove hate for this col
			cr_itr = cr_itr->next;
		}
		go_itr = cur_cell->go_lst.first;
		while(go_itr)
		{
			temp_compressed_packet2.clear();
			go_itr->value->build_create_block(&p_char->pClient->compressed_update,0); //get their create packet
			go_itr = go_itr->next;
		}
		corps_itr = cur_cell->corpse_lst.first;
		while (corps_itr)
		{
			corps_itr->value->build_create_block(&p_char->pClient->compressed_update,0,G_turn_id); //get their create packet
			corps_itr = corps_itr->next;
		}
   } //end iterate through block
#ifdef DEBUG_MAPMANAGER_VERSION
	end_time = GetMilliseconds();
	if(end_time-start_time>0)
		printf("MapManager: requred time = %u ms to send createobject to row\n",end_time-start_time);
#endif
}

//same for creature
//inform players in this col that we left them = moved into a new cell
void game_map::send_out_of_range_object_to_col(creature *p_cr,uint32 col, uint32 row)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_cr);
	uint32 start_time,end_time;
	start_time = GetMilliseconds();
#endif
   uint32 cur_cellx,min_celly,max_celly;
   map_cell *cur_cell;
   Character_Node *char_itr;
   //get the cell in wich the object is
		//we shift it's position to get always pos values
   cur_cellx=col;
   max_celly=row+Player_affect_neighbour_cells;
   min_celly=row-Player_affect_neighbour_cells;
   if(max_celly>cells_y) max_celly=cells_y;
   if(cur_cellx>(int)cells_x)return; //if we fell out of map then we exit this function
   if(min_celly<0)min_celly=0;
   if(cur_cellx<0)return; //if we fell out of map then we exit this function
   //prepare packet to be sent(it is a small packet -> less than 9 if's +..)
   temp_packet.opcode = SMSG_DESTROY_OBJECT;
   temp_packet.data32[0] = p_cr->getGUIDL();
   temp_packet.data32[1] = p_cr->getGUIDH();
   temp_packet.length = 8;
   for(;min_celly<=max_celly;min_celly++)
   {
		//get one cell from the block
		cur_cell=cells[min_celly*cells_x+cur_cellx];
			//add create data to all players in this cell
			//+players will add their create data to this player
		char_itr = cur_cell->char_lst.first;
		while(char_itr)
		{
//printf("sending out off range guid (%s) for col, in cell [%u,%u]\n",char_itr->value->name,min_celly,cur_cellx);
			char_itr->value->pClient->SendMsg(&temp_packet);
			char_itr = char_itr->next;
		}
	} //end iterate through block
#ifdef DEBUG_MAPMANAGER_VERSION
	end_time = GetMilliseconds();
	if(end_time-start_time>0)
		printf("MapManager: requred time = %u ms to send outofrange to col\n",end_time-start_time);
#endif
}

//inform players in this col that we arrived here,also get their create object packet
void game_map::send_create_object_to_col(creature *p_cr,uint32 col, uint32 row)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_cr);
	uint32 start_time,end_time;
	start_time = GetMilliseconds();
#endif
   uint32 cur_cellx,min_celly,max_celly;
   map_cell *cur_cell;
   Character_Node *char_itr;
   //get the cell in wich the object is
		//we shift it's position to get always pos values
   cur_cellx=col;
   max_celly=row+Player_affect_neighbour_cells;
   min_celly=row-Player_affect_neighbour_cells;
   if(max_celly>cells_y) max_celly=cells_y;
   if(cur_cellx>(int)cells_x)return; //if we fell out of map then we exit this function
   if(min_celly<0)min_celly=0;
   if(cur_cellx<0)return; //if we fell out of map then we exit this function
   //create 1 create block and send it to all players
   temp_compressed_packet.clear();
   p_cr->build_create_block(&temp_compressed_packet,0); //get their create packet
   for(;min_celly<=max_celly;min_celly++)
   {
		//get one cell from the block
		cur_cell=cells[min_celly*cells_x+cur_cellx];
			//add create data to all players in this cell
			//+players will add their create data to this player
		char_itr = cur_cell->char_lst.first;
		while(char_itr)
		{
//printf("sending create guid (%s) for col, in cell [%u,%u]\n",char_itr->value->name,min_celly,cur_cellx);
			char_itr->value->pClient->compressed_update.add_blocks_from_other_packet(&temp_compressed_packet);
			char_itr = char_itr->next;
		}
	} //end iterate through block
#ifdef DEBUG_MAPMANAGER_VERSION
	end_time = GetMilliseconds();
	if(end_time-start_time>0)
		printf("MapManager: requred time = %u ms to send createobject to col\n",end_time-start_time);
#endif
}

//inform players in this row that we left them = moved into a new cell
void game_map::send_out_of_range_object_to_row(creature *p_cr,uint32 col, uint32 row)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_cr);
	uint32 start_time,end_time;
	start_time = GetMilliseconds();
#endif
   uint32 min_cellx,cur_celly,max_cellx;
   map_cell *cur_cell;
   Character_Node *char_itr;
   //get the cell in wich the object is
		//we shift it's position to get always pos values
   cur_celly=row;
   max_cellx=col+Player_affect_neighbour_cells;
   min_cellx=col-Player_affect_neighbour_cells;
   if(cur_celly>(int)cells_y) return;
   if(max_cellx>cells_x) max_cellx=cells_x;
   if(cur_celly<0) return;
   if(min_cellx<0)min_cellx=0;
   //prepare the data holder
   temp_packet.opcode = SMSG_DESTROY_OBJECT;
   temp_packet.data32[0] = p_cr->getGUIDL();
   temp_packet.data32[1] = p_cr->getGUIDH();
   temp_packet.length = 8;
   for(;min_cellx<=max_cellx;min_cellx++)
   {
		//get one cell from the block
		cur_cell=cells[cur_celly*cells_x+min_cellx];
			//add create data to all players in this cell
			//+players will add their create data to this player
//printf("trying to send a outofrange for cell [%u,%u]\n",cur_celly,min_cellx);
		char_itr = cur_cell->char_lst.first;
		while(char_itr)
		{
//printf("sending out off range guid (%s) for row in cell [%u,%u]\n",char_itr->value->name,cur_celly,min_cellx);
			char_itr->value->pClient->SendMsg(&temp_packet);
			char_itr = char_itr->next;
		}
   } //end iterate through block
#ifdef DEBUG_MAPMANAGER_VERSION
	end_time = GetMilliseconds();
	if(end_time-start_time>0)
		printf("MapManager: requred time = %u ms to send outofrange to row\n",end_time-start_time);
#endif
}

//inform players in this col that we arrived here,also get their create object packet
void game_map::send_create_object_to_row(creature *p_cr,uint32 col, uint32 row)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_cr);
	uint32 start_time,end_time;
	start_time = GetMilliseconds();
#endif
   uint32 min_cellx,cur_celly,max_cellx;
   map_cell *cur_cell;
   Character_Node *char_itr;
   //get the cell in wich the object is
		//we shift it's position to get always pos values
   cur_celly=row;
   max_cellx=col+Player_affect_neighbour_cells;
   min_cellx=col-Player_affect_neighbour_cells;
   if(cur_celly>(int)cells_y) return;
   if(max_cellx>cells_x) max_cellx=cells_x;
   if(cur_celly<0) return;
   if(min_cellx<0)min_cellx=0;
   //create 1 create block and send it to all players
   temp_compressed_packet.clear();
   p_cr->build_create_block(&temp_compressed_packet,0); //get their create packet
   for(;min_cellx<=max_cellx;min_cellx++)
   {
		//get one cell from the block
		cur_cell=cells[cur_celly*cells_x+min_cellx];
			//add create data to all players in this cell
			//+players will add their create data to this player
//printf("trying to send a createobj for cell [%u,%u]\n",cur_celly,min_cellx);
		char_itr = cur_cell->char_lst.first;
		while(char_itr)
		{
			char_itr->value->pClient->compressed_update.add_blocks_from_other_packet(&temp_compressed_packet);
			char_itr = char_itr->next;
		}
   } //end iterate through block
#ifdef DEBUG_MAPMANAGER_VERSION
	end_time = GetMilliseconds();
	if(end_time-start_time>0)
		printf("MapManager: requred time = %u ms to send createobject to row\n",end_time-start_time);
#endif
}

void game_map::on_creature_entered_block(creature *p_cr)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_char);
	uint32 start_time,end_time;
	start_time = GetMilliseconds();
#endif
	uint32 min_cellx,min_celly,max_cellx,max_celly,cur_x;
	map_cell *cur_cell;
	Character_Node *char_itr;
	//get the cell in wich the object is
	//we shift it's position to get always pos values
	if(p_cr->pos_x<min_x || p_cr->pos_x>max_x || p_cr->pos_y<min_y || p_cr->pos_y>max_y)return;
	min_cellx=(int32)fabs((p_cr->pos_x - min_x) / cell_size);
	min_celly=(int32)fabs((p_cr->pos_y - min_y) / cell_size);
	max_celly=min_celly+Player_affect_neighbour_cells;
	max_cellx=min_cellx+Player_affect_neighbour_cells;
	min_celly-=Player_affect_neighbour_cells;
	min_cellx-=Player_affect_neighbour_cells;
	if(max_celly>cells_y) max_celly=cells_y;
	if(max_cellx>cells_x) max_cellx=cells_x;
	if(min_celly<0)min_celly=0;
	if(min_cellx<0)min_cellx=0;
	//create 1 create block and send it to all players
	temp_compressed_packet2.clear();
	p_cr->build_create_block(&temp_compressed_packet2,0); //get our create packet
	for(;min_celly<=max_celly;min_celly++)
		for(cur_x=min_cellx;cur_x<=max_cellx;cur_x++)
		{
			//get one cell from the block
			cur_cell=cells[min_celly*cells_x+cur_x];
			//add create data to all players in this cell
			//+players will add their create data to this player
			//each player will make it's create block that will be sent to us
			//we send to them our create packet 2
			char_itr = cur_cell->char_lst.first;
			while(char_itr)
			{
				char_itr->value->pClient->compressed_update.add_blocks_from_other_packet(&temp_compressed_packet2);
				char_itr = char_itr->next;
			}
		} //end iterate through block
	//send out creature agro so they will attack each other
	agro_block(p_cr);
	p_cr->agro_sent_time = G_cur_time_ms + WORLD_MIN_UPDATE_INTERVAL*CREATURE_AGRO_SEND_TIME_INTERVAL;
#ifdef DEBUG_MAPMANAGER_VERSION
		end_time = GetMilliseconds();
		if(end_time-start_time>0)
			printf("MapManager: requred time = %u ms to send create block for player %s\n",end_time-start_time,p_char->name);
#endif
}


//will send an out of range message to all players in the block
//called rarely
void game_map::on_creature_exited_block(creature *p_cr)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_cr);
	uint32 start_time,end_time;
	start_time = GetMilliseconds();
#endif
	uint32 min_cellx,min_celly,max_cellx,max_celly,cur_x;
	map_cell *cur_cell;
	Character_Node *char_itr;
	if(p_cr->pos_x<min_x || p_cr->pos_x>max_x || p_cr->pos_y<min_y || p_cr->pos_y>max_y)return;
	min_cellx=(int32)fabs((p_cr->pos_x - min_x) / cell_size);
	min_celly=(int32)fabs((p_cr->pos_y - min_y) / cell_size);
	max_celly=min_celly+Player_affect_neighbour_cells;
	max_cellx=min_cellx+Player_affect_neighbour_cells;
	min_celly-=Player_affect_neighbour_cells;
	min_cellx-=Player_affect_neighbour_cells;
	if(max_celly>cells_y) max_celly=cells_y;
	if(max_cellx>cells_x) max_cellx=cells_x;
	if(min_celly<0)min_celly=0;
	if(min_cellx<0)min_cellx=0;
	//prepare packet to be sent(it is a small packet -> less than 9 if's +..)
	temp_packet1.opcode = SMSG_DESTROY_OBJECT;
	temp_packet1.data32[0] = p_cr->getGUIDL();
	temp_packet1.data32[1] = p_cr->getGUIDH();
	temp_packet1.length = 8;
	//   send_instant_msg_to_block(p_cr->pos_x,p_cr->pos_y,&temp_packet,p_cr);
	//   send_instant_msg_to_block(p_cr->pos_x,p_cr->pos_y,&temp_packet1,NULL);
	//destroy objects from the block for player. if we do not destroy them incase we come back to block,
	//and they are dead, we might see them alive = bad
	for(;min_celly<=max_celly;min_celly++)
		for(cur_x=min_cellx;cur_x<=max_cellx;cur_x++)
		{
			//get one cell from the block
			cur_cell=cells[min_celly*cells_x+cur_x];
			//add create data to all players in this cell
			//+players will add their create data to this player
			char_itr = cur_cell->char_lst.first;
			while(char_itr)
			{
				char_itr->value->pClient->SendMsg(&temp_packet1);
				char_itr = char_itr->next;
			}
		} //end iterate through block
#ifdef DEBUG_MAPMANAGER_VERSION
		end_time = GetMilliseconds();
		if(end_time-start_time>0)
			printf("MapManager: requred time = %u ms to send outofrange to col\n",end_time-start_time);
#endif
}



//will return a set of cordinates from wich the creature should not walk out
void game_map::get_cell_boundary(creature *p_cr,float *buffer)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_cr);
#endif
   int cellx,celly,x,y;
   x=(int)p_cr->pos_x;
   y=(int)p_cr->pos_y;
   cellx=(x / (int)cell_size);
   celly=(y / (int)cell_size);
   buffer[0]=(float)(cellx*(int)cell_size-(int)cell_size);
   buffer[1]=(float)(celly*(int)cell_size-(int)cell_size);
   buffer[2]=(float)0;
   buffer[3]=(float)(cellx*(int)cell_size);
   buffer[4]=(float)(celly*(int)cell_size);
   buffer[5]=(float)0;
}

void game_map::get_inrange_enemy_guids(float x,float y,Target_list *list,float range_min,float range_max,uint32 faction)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	uint32 start_time,end_time;
	start_time = GetMilliseconds();
#endif
   uint32 min_cellx,min_celly,max_cellx,max_celly,cur_x;
   map_cell *cur_cell;
   Character_Node *char_itr;
   Creature_Node *cr_itr;
   float r_min,r_max;
   r_min = range_min*range_min;
   r_max = range_max*range_max;
   min_cellx=(int32)fabs((x - min_x) / cell_size);
   min_celly=(int32)fabs((y - min_y) / cell_size);
   max_celly=min_celly+Player_affect_neighbour_cells;
   max_cellx=min_cellx+Player_affect_neighbour_cells;
   if(max_celly>cells_y) max_celly=cells_y;
   if(max_cellx>cells_x) max_cellx=cells_x;
   if(min_celly<Player_affect_neighbour_cells)min_celly=0;
   else min_celly-=Player_affect_neighbour_cells;
   if(min_cellx<Player_affect_neighbour_cells)min_cellx=0;
   else min_cellx-=Player_affect_neighbour_cells;
   for(;min_celly<=max_celly;min_celly++)
       for(cur_x=min_cellx;cur_x<=max_cellx;cur_x++)
       {
			//get one cell from the block
			cur_cell=cells[min_celly*cells_x+cur_x];
			//we add the current char updata to other chars in the block
			char_itr = cur_cell->char_lst.first;
			while(char_itr)
			{
				if(G_faction_is_enemy[char_itr->value->data32[UNIT_FIELD_FACTIONTEMPLATE]*G_max_faction_id+faction])
				{
					float range;
					float dx,dy;
					dx = char_itr->value->pos_x - x;
					dy = char_itr->value->pos_y - y;
					range = dx*dx + dy*dy;
					if(r_min<=range && r_max>=range)
						list->add(char_itr->value->getGUID());
				}
				char_itr = char_itr->next;
			}
			cr_itr = cur_cell->cr_lst.first;
			while(cr_itr)
			{
//				if(G_faction_is_enemy[cr_itr->value->data32[UNIT_FIELD_FACTIONTEMPLATE]*G_max_faction_id+faction])
				if(G_faction_is_enemy[cr_itr->value->data32[UNIT_FIELD_FACTIONTEMPLATE]*G_max_faction_id+faction]
					||
					!G_faction_is_friend[cr_itr->value->data32[UNIT_FIELD_FACTIONTEMPLATE]*G_max_faction_id+faction])
				{
					float range;
					float dx,dy;
					dx = cr_itr->value->pos_x - x;
					dy = cr_itr->value->pos_y - y;
					range = dx*dx + dy*dy;
					if(r_min<=range && r_max>=range)
						list->add(cr_itr->value->getGUID());
				}
				cr_itr = cr_itr->next;
			}
	   } //end iterate through block
#ifdef DEBUG_MAPMANAGER_VERSION
	end_time = GetMilliseconds();
	if(end_time-start_time>0)
		printf("MapManager: requred time = %u ms to get inrange enemys\n",end_time-start_time);
#endif
}

void game_map::get_inrange_friend_guids(float x,float y,Target_list *list,float range_min,float range_max,uint32 faction)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	uint32 start_time,end_time;
	start_time = GetMilliseconds();
#endif
   uint32 min_cellx,min_celly,max_cellx,max_celly,cur_x;
   map_cell *cur_cell;
   Character_Node *char_itr;
   Creature_Node *cr_itr;
   float r_min,r_max;
   r_min = range_min*range_min;
   r_max = range_max*range_max;
   min_cellx=(int32)fabs((x - min_x) / cell_size);
   min_celly=(int32)fabs((y - min_y) / cell_size);
   max_celly=min_celly+Player_affect_neighbour_cells;
   max_cellx=min_cellx+Player_affect_neighbour_cells;
   if(max_celly>cells_y) max_celly=cells_y;
   if(max_cellx>cells_x) max_cellx=cells_x;
   if(min_celly<Player_affect_neighbour_cells)min_celly=0;
   else min_celly-=Player_affect_neighbour_cells;
   if(min_cellx<Player_affect_neighbour_cells)min_cellx=0;
   else min_cellx-=Player_affect_neighbour_cells;
   for(;min_celly<=max_celly;min_celly++)
       for(cur_x=min_cellx;cur_x<=max_cellx;cur_x++)
       {
			//get one cell from the block
			cur_cell=cells[min_celly*cells_x+cur_x];
			//we add the current char updata to other chars in the block
			char_itr = cur_cell->char_lst.first;
			while(char_itr)
			{
				if(G_faction_is_enemy[char_itr->value->data32[UNIT_FIELD_FACTIONTEMPLATE]*G_max_faction_id+faction])
				{
					float range;
					float dx,dy;
					dx = char_itr->value->pos_x - x;
					dy = char_itr->value->pos_y - y;
					range = dx*dx + dy*dy;
					if(r_min<=range && r_max>=range)
						list->add(char_itr->value->getGUID());
				}
				char_itr = char_itr->next;
			}
			cr_itr = cur_cell->cr_lst.first;
			while(cr_itr)
			{
				if(G_faction_is_friend[cr_itr->value->data32[UNIT_FIELD_FACTIONTEMPLATE]*G_max_faction_id+faction])
				{
					float range;
					float dx,dy;
					dx = cr_itr->value->pos_x - x;
					dy = cr_itr->value->pos_y - y;
					range = dx*dx + dy*dy;
					if(r_min<=range && r_max>=range)
						list->add(cr_itr->value->getGUID());
				}
				cr_itr = cr_itr->next;
			}
	   } //end iterate through block
#ifdef DEBUG_MAPMANAGER_VERSION
	end_time = GetMilliseconds();
	if(end_time-start_time>0)
		printf("MapManager: requred time = %u ms to get inrange friends\n",end_time-start_time);
#endif
}

//periodicaly called by players, should be fast but it can't so instead try calling it more rarely
void game_map::agro_block(Base_Unit_Object *p_unit)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_unit);
	uint32 start_time,end_time;
	start_time = GetMilliseconds();
#endif
   uint32 min_cellx,min_celly,max_cellx,max_celly,cur_x;
   Creature_Node *cr_itr;
   min_cellx=(int32)fabs((p_unit->pos_x - min_x) / cell_size);
   min_celly=(int32)fabs((p_unit->pos_y - min_y) / cell_size);
   max_celly=min_celly+Player_affect_neighbour_cells;
   max_cellx=min_cellx+Player_affect_neighbour_cells;
   if(max_celly>cells_y) max_celly=cells_y;
   if(max_cellx>cells_x) max_cellx=cells_x;
   if(min_celly<Player_affect_neighbour_cells)min_celly=0;
   else min_celly-=Player_affect_neighbour_cells;
   if(min_cellx<Player_affect_neighbour_cells)min_cellx=0;
   else min_cellx-=Player_affect_neighbour_cells;
   for(;min_celly<=max_celly;min_celly++)
       for(cur_x=min_cellx;cur_x<=max_cellx;cur_x++)
       {
			//get one cell from the block
			cr_itr = cells[min_celly*cells_x+cur_x]->cr_lst.first;
			while(cr_itr)
			{
				//if creature is enemy then calc range
//				float range,dz;
				float dx,dy;
				dx = cr_itr->value->pos_x - p_unit->pos_x;
				dy = cr_itr->value->pos_y - p_unit->pos_y;
//				dz = cr_itr->value->pos_z - p_unit->pos_z;
//				range = dx*dx + dy*dy + dz*dz;
 				//if it is in range then we add it to the list
//				if(range<AGRO_PROPAGATION_MAX_RANGE_SQUARE && cr_itr->value->data32[UNIT_FIELD_LEVEL]+AGRO_LVL_DIFRENCE>p_unit->data32[UNIT_FIELD_LEVEL] &&
				if(fabs(dx)<AGRO_PROPAGATION_MAX_RANGE && fabs(dy)<AGRO_PROPAGATION_MAX_RANGE && cr_itr->value->data32[UNIT_FIELD_LEVEL]+AGRO_LVL_DIFRENCE>p_unit->data32[UNIT_FIELD_LEVEL] &&
					G_faction_is_enemy[cr_itr->value->data32[UNIT_FIELD_FACTIONTEMPLATE]*G_max_faction_id+p_unit->data32[UNIT_FIELD_FACTIONTEMPLATE]])
//					cr_itr->value->agro_list.add(p_unit->getGUID(),p_unit->threat_generated*p_unit->threat_generate_mod);
					cr_itr->value->agro_list.add(p_unit->getGUID(),(float)p_unit->threat_generated);
				cr_itr = cr_itr->next;
			}
	   } //end iterate through block
#ifdef DEBUG_MAPMANAGER_VERSION
	end_time = GetMilliseconds();
	if(end_time-start_time>0)
		printf("MapManager: requred time = %u ms to send agro to inrange enemys\n",end_time-start_time);
#endif
}

//called by players (usualy when died, should be fast but it can't so instead try calling it more rarely)
void game_map::rem_agro_block(Base_Unit_Object *p_unit)
{
#ifdef DEBUG_MAPMANAGER_VERSION
	ASSERT(p_unit);
	uint32 start_time,end_time;
	start_time = GetMilliseconds();
#endif
   uint32 min_cellx,min_celly,max_cellx,max_celly,cur_x;
   Creature_Node *cr_itr;
   min_cellx=(int32)fabs((p_unit->pos_x - min_x) / cell_size);
   min_celly=(int32)fabs((p_unit->pos_y - min_y) / cell_size);
   max_celly=min_celly+Player_affect_neighbour_cells;
   max_cellx=min_cellx+Player_affect_neighbour_cells;
   if(max_celly>cells_y) max_celly=cells_y;
   if(max_cellx>cells_x) max_cellx=cells_x;
   if(min_celly<Player_affect_neighbour_cells)min_celly=0;
   else min_celly-=Player_affect_neighbour_cells;
   if(min_cellx<Player_affect_neighbour_cells)min_cellx=0;
   else min_cellx-=Player_affect_neighbour_cells;
   for(;min_celly<=max_celly;min_celly++)
       for(cur_x=min_cellx;cur_x<=max_cellx;cur_x++)
       {
			//get one cell from the block
			cr_itr = cells[min_celly*cells_x+cur_x]->cr_lst.first;
			while(cr_itr)
			{
				cr_itr->value->agro_list.del(p_unit->getGUID());
				cr_itr = cr_itr->next;
			}
	   } //end iterate through block
#ifdef DEBUG_MAPMANAGER_VERSION
	end_time = GetMilliseconds();
	if(end_time-start_time>0)
		printf("MapManager: requred time = %u ms to remove agro from mobs\n",end_time-start_time);
#endif
}

void game_map::create_spirit_healer_create_packet()
{
	Creature_Node *spr_itr;
	spr_itr = graveyard_list.spirit_healers.first;
	Spirit_healer_prepared_packet.clear();
	while(spr_itr)
	{
		spr_itr->value->build_create_block(&Spirit_healer_prepared_packet,0);
		spr_itr = spr_itr->next;
	}
	Spirit_healer_prepared_packet.build_packet();
}

//use when changing location further than a few cells
//do not use this when dead
void teleport(Character *p_char,uint32 map_id,float new_x, float new_y, float new_z,float new_o)
{
	//check if map_id differs then it's a far teleport
	if(G_maps[map_id]!=NULL)
	{
		G_maps[p_char->map_id]->del_char(p_char); //will destroy us for others
		G_maps[p_char->map_id]->on_player_exited_block(p_char);
		p_char->pos_x=new_x;
		p_char->pos_y=new_y;
		p_char->pos_z=new_z;
		p_char->orientation=new_o;
		G_maps[map_id]->add_char(p_char);
		G_maps[map_id]->on_player_entered_block(p_char);
		//this is update for self only
		if(p_char->map_id==map_id)
			p_char->update_obj_pos(p_char);
		else
		{
			G_send_packet.opcode = SMSG_TRANSFER_PENDING;
			G_send_packet.data32[0] = 0;//pendingscreen
			G_send_packet.length = 4;
			p_char->SendMsg(&G_send_packet);
			G_send_packet.opcode = SMSG_NEW_WORLD;
			G_send_packet.data32[0] = map_id;
			G_send_packet.dataf[1] = new_x;
			G_send_packet.dataf[2] = new_y;
			G_send_packet.dataf[3] = new_z;
			G_send_packet.dataf[4] = new_o;
			G_send_packet.length = 20;
			p_char->SendMsg(&G_send_packet);
			p_char->map_id = map_id;
		}
	}
}
