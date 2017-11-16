// Copyright (C) 2006 Team Evolution
#include "base_game_object.h"
#include "globals.h"

void Base_Game_Object::SetUInt32Value (uint32 index, uint32 value)
{
	if(data32[ index ] != value)
	{
		data32[ index ] = value;
		update_mask.SetBit( index );
	}
}

void Base_Game_Object::SetUInt64Value (uint32 index, uint64 value)
{
	if(data32[ index ] != (uint32)(value))
	{
		data32[ index ] = (uint32)(value);
		update_mask.SetBit( index );
	}
	if(data32[ index + 1 ] != (uint32)(value >> 32))
	{
		data32[ index + 1 ] = (uint32)(value >> 32);
		update_mask.SetBit( index + 1 );
	}
}

void Base_Game_Object::SetFloatValue (uint32 index, float value)
{
	if(dataf[ index ] != value)
	{
		dataf[ index ] = value;
		update_mask.SetBit( index );
	}
}

uint64 Base_Game_Object::GetUInt64Value (uint32 index)
{
	return *((uint64*)&(data32[ index ]));
}

//update position when we actualy wanna make sure it is correctly shown to client (like a sincronisation)
//do not use this funtion to create(show) new objects in game (like in case of teleport)
//does not modify any object data!!!
void Base_Game_Object::update_obj_pos(Base_Unit_Object *self_only)
{
	G_send_packet.opcode=MSG_MOVE_TELEPORT_ACK;
	G_send_packet.data[0] = 0xFF;
	*(uint64*)(G_send_packet.data+1) = getGUIDL();
	*(uint64*)(G_send_packet.data+5) = getGUIDH();
	*(uint32*)(G_send_packet.data+9) = G_packet_serializer++;//This is packet serializer
	*(uint32*)(G_send_packet.data+13) = 0x00100000;//unk and has multiple values
	*(uint32*)(G_send_packet.data+17) = G_cur_time_ms; //unk huge changing number. It's not float as i see it. It's very rapidly increasing. Like a global serializer
	*(float*)(G_send_packet.data+21) = pos_x;
	*(float*)(G_send_packet.data+25) = pos_y;
	*(float*)(G_send_packet.data+29) = pos_z;
//	*(float*)(G_send_packet.data+33) = 0;//viewer angle ? (not orientation just angle)
	*(uint32*)(G_send_packet.data+37) = 0x00000000;//unk and has multiple values
	G_send_packet.length=41;
	//send update object location to new block
	if(self_only)
	{
		*(float*)(G_send_packet.data+33) = self_only->orientation;//viewer angle ? (not orientation just angle)
		self_only->SendMsg(&G_send_packet);
	}
	else
	{
		game_map *map=G_maps[map_id];
		uint32 min_cellx,min_celly,max_cellx,max_celly,cur_x;
		Character_Node *char_itr;
		min_cellx=(int32)abs((pos_x - map->min_x) / map->cell_size);
		min_celly=(int32)abs((pos_y - map->min_y) / map->cell_size);
		max_celly=min_celly+Player_affect_neighbour_cells;
		max_cellx=min_cellx+Player_affect_neighbour_cells;
		min_celly-=Player_affect_neighbour_cells;
		min_cellx-=Player_affect_neighbour_cells;
		if(max_celly>map->cells_y) max_celly=map->cells_y;
		if(max_cellx>map->cells_x) max_cellx=map->cells_x;
		if(min_celly<0)min_celly=0;
		if(min_cellx<0)min_cellx=0;
		for(;min_celly<=max_celly;min_celly++)
			for(cur_x=min_cellx;cur_x<=max_cellx;cur_x++)
			{
				char_itr = map->cells[min_celly*map->cells_x+cur_x]->char_lst.first;
				while(char_itr)
				{
					*(float*)(G_send_packet.data+33) = char_itr->value->orientation;//viewer angle ? (not orientation just angle)
					char_itr->value->pClient->SendMsg(&G_send_packet);
					char_itr = char_itr->next;
				}
			} //end iterate through block
	}
}

void Base_Game_Object::set_object_facing()
{
	G_send_packet.opcode = MSG_MOVE_SET_FACING;
	G_send_packet.data[0] = 0xFF;
	*(uint32*)(G_send_packet.data+1) = getGUIDL();
	*(uint32*)(G_send_packet.data+5) = getGUIDH();
	*(uint32*)(G_send_packet.data+9) = 1; //move flags
	*(uint32*)(G_send_packet.data+13) = G_packet_serializer++;
	*(float*)(G_send_packet.data+17) = pos_x;
	*(float*)(G_send_packet.data+21) = pos_y;
	*(float*)(G_send_packet.data+25) = pos_z;
	*(float*)(G_send_packet.data+29) = orientation;
	*(float*)(G_send_packet.data+33) = 0;
	G_send_packet.length = 37;
	G_maps[map_id]->send_instant_msg_to_block(pos_x,pos_y,&G_send_packet,NULL);
}
