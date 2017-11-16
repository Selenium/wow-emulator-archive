// Copyright (C) 2006 Team Evolution
#include "WorldServer.h"

#ifdef SERVER_DOTA_COMPILATION
//this is just a cut+paste from worlsrv_packet_handler. Should make it more flexible
void WorldServer::handle_chat_command_dota(GameClient *pClient, Character *p_char)
{
	//let's copy the first word wat can be the command
/*	char cmd[40];
	uint32	param1,pos; //we receive this case only 1 param=template_id
	float	paramf1;
	G_recv_packet.data[G_recv_packet.length+1]=' '; //make sure we reach an end when searching for values
	for(pos=9;G_recv_packet.data[pos]!=' ' && pos<G_recv_packet.length;pos++)
		cmd[pos-9]=G_recv_packet.data[pos];
	cmd[pos-9]=0;//the terminator
	pos++;
	creature *p_cr=(creature*)(p_char->last_target_GUID);
	//let's see if it matches any command we know
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	if(strcmp(cmd,"cr_add_wp")==0)
	{
		if(pos+3 >= G_recv_packet.length)
		{
			send_message("usage : .cr_add_wp <speed_coef> <sec_wait_at_dst>",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
		if(p_cr==NULL)
		{
			send_message("must target creature to add waypoint",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
		paramf1=get_param_float(G_recv_packet.data,pos,G_recv_packet.length);
		param1=get_param_uint32(G_recv_packet.data,pos,G_recv_packet.length);
		Waypoint_Node *new_node=new Waypoint_Node;
		new_node->dst_x = p_char->pos_x;
		new_node->dst_y = p_char->pos_y;
		new_node->dst_z = p_char->pos_z;
		new_node->dst_o = p_char->orientation;
		new_node->speed_coef = paramf1;
		new_node->dst_time_wait = param1;
		p_cr->waypoint_lst.add_to_end(new_node);
		send_message("Creature wp added",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
		return;
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	if(strcmp(cmd,"awp")==0)
	{
		if(p_cr==NULL)
		{
			send_message("must target creature to add waypoint",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
		Waypoint_Node *new_node=new Waypoint_Node;
		new_node->dst_x = p_char->pos_x;
		new_node->dst_y = p_char->pos_y;
		new_node->dst_z = p_char->pos_z;
		new_node->dst_o = p_char->orientation;
		new_node->speed_coef = 1;
		new_node->dst_time_wait = 0;
		p_cr->waypoint_lst.add_to_end(new_node);
		send_message("Creature wp added",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
		return;
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	if(strcmp(cmd,"cr_save_wp")==0)
	{
		if(p_cr==NULL)
		{
			send_message("must target creature to save waypoints",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
		if(p_cr->m_db_id==0)
			send_message("Creature is not saved to db yet",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
		else
		{
			G_dbi_w->save_creature_waypoints(p_cr);
			send_message("Creature waypointlist saved",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
		}
		return;
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	if(strcmp(cmd,"cr_del_wp")==0)
	{
		if(p_cr==NULL)
		{
			send_message("must target creature to delete cur waypoint",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
		p_cr->waypoint_lst.delete_cur();
		send_message("Creature current waypoint deleted",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
		return;
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	if(strcmp(cmd,"cr_clear_wp_list")==0)
	{
		if(p_cr==NULL)
		{
			send_message("must target creature to clear waypoint list",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
		p_cr->waypoint_lst.clear();
		Waypoint_Node *new_node=new Waypoint_Node;
		new_node->dst_x = p_char->pos_x;
		new_node->dst_y = p_char->pos_y;
		new_node->dst_z = p_char->pos_z;
		new_node->dst_o = p_char->orientation;
		new_node->speed_coef = 1;
		new_node->dst_time_wait = 0;
		p_cr->waypoint_lst.add(new_node);
		p_cr->waypoint_lst.get_next_waypoint();
		update_obj_pos(p_cr->getGUID(),p_char->pos_x,p_char->pos_y,p_char->pos_z,p_char->orientation,p_char->map_id,NULL);
		send_message("Creature current waypoint list cleared",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
		return;
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	if(strcmp(cmd,"cr_teleport_to_me")==0)
	{
		if(p_cr==NULL)
		{
			send_message("must target creature to clear teleport",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
		creature *cr=p_cr;
		cr->pos_x = p_char->pos_x;
		cr->pos_y = p_char->pos_y;
		cr->pos_z = p_char->pos_z;
		cr->orientation = p_char->orientation;
		update_obj_pos(p_cr->getGUID(),p_char->pos_x,p_char->pos_y,p_char->pos_z,p_char->orientation,p_char->map_id,NULL);
		p_cr->waypoint_lst.clear();
		send_message("Creature teleported",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
		return;
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	if(strcmp(cmd,"cr_pause_move")==0)
	{
		if(p_cr==NULL)
		{
			send_message("must target creature to pause",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
		creature *cr=p_cr;
		cr->state1 |= CREATURE_STATE_PAUSE_MOVEMENT;
		update_obj_pos(cr->getGUID(),cr->pos_x,cr->pos_y,cr->pos_z,cr->orientation,cr->map_id,NULL);
		send_message("Creature position updated and paused",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
		return;
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	if(strcmp(cmd,"cr_resume_move")==0)
	{
		if(p_cr==NULL)
		{
			send_message("must target creature to pause",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
		creature *cr=p_cr;
		cr->state1 &= ~CREATURE_STATE_PAUSE_MOVEMENT;
		Waypoint_Node *cur_dst= cr->waypoint_lst.cur_dst;
		if(cr->waypoint_lst.cur_dst->speed_coef<=1)
			cr->move_creature(cur_dst->dst_x,cur_dst->dst_y,cur_dst->dst_z,0,0);
		else if(cur_dst->speed_coef<3)
			cr->move_creature(cur_dst->dst_x,cur_dst->dst_y,cur_dst->dst_z,1,0,cur_dst->speed_coef);
		else cr->move_creature(cur_dst->dst_x,cur_dst->dst_y,cur_dst->dst_z,1,1);
		send_message("Paused creature resumed",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
		return;
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	if(strcmp(cmd,"cr_prev_wp")==0)
	{
		if(p_cr==NULL)
		{
			send_message("must target creature to pause",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
		creature *cr=p_cr;
		Waypoint_Node *wp_itr;
		wp_itr = cr->waypoint_lst.first;
		if(!wp_itr)
			return;
		while(wp_itr && wp_itr->next!=cr->waypoint_lst.cur_dst && wp_itr->next!=NULL)
			wp_itr = wp_itr->next;
		cr->waypoint_lst.cur_dst = wp_itr;//will be the last node
		cr->pos_x = wp_itr->dst_x;
		cr->pos_y = wp_itr->dst_y;
		cr->pos_z = wp_itr->dst_z;
		cr->orientation = wp_itr->dst_o;
		cr->atimer1 = G_cur_time_ms + 5000; //wait 5 seconds then we start moving if not on pause
		cr->state1 &= CREATURE_STATE_PATROL_MOVE;
		cr->state1 |= CREATURE_STATE_PATROL_WAIT;
		update_obj_pos(cr->getGUID(),cr->pos_x,cr->pos_y,cr->pos_z,cr->orientation,cr->map_id,NULL);
		send_message("Creature moved to previous waypoint",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
		return;
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	if(strcmp(cmd,"cr_next_wp")==0)
	{
		if(p_cr==NULL)
		{
			send_message("must target creature to pause",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
		creature *cr=p_cr;
		cr->waypoint_lst.get_next_waypoint();
		cr->pos_x = cr->waypoint_lst.cur_dst->dst_x;
		cr->pos_y = cr->waypoint_lst.cur_dst->dst_y;
		cr->pos_z = cr->waypoint_lst.cur_dst->dst_z;
		cr->orientation = cr->waypoint_lst.cur_dst->dst_o;
		cr->atimer1 = G_cur_time_ms + 5000; //wait 5 seconds then we start moving if not on pause
		cr->state1 &= CREATURE_STATE_PATROL_MOVE;
		cr->state1 |= CREATURE_STATE_PATROL_WAIT;
		update_obj_pos(cr->getGUID(),cr->pos_x,cr->pos_y,cr->pos_z,cr->orientation,cr->map_id,NULL);
		send_message("Creature moved to previous waypoint",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
		return;
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	if(strcmp(cmd,"cr_follow")==0)
	{
		if(p_cr==NULL)
		{
			send_message("must target creature to pause",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
		p_cr->atimer1 = G_cur_time_ms;
		p_cr->state1 |= CREATURE_STATE_FOLLOW;
		p_cr->folowed_char = p_char;
		send_message("Creature will start folowing",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
		return;
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	if(strcmp(cmd,"cr_stop_follow")==0)
	{
		if(p_cr==NULL)
		{
			send_message("must target creature to pause",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
		p_cr->atimer1 = G_cur_time_ms; //wait 5 seconds then we start moving if not on pause
		p_cr->state1 &= ~CREATURE_STATE_FOLLOW;
		p_cr->folowed_char = NULL;
		send_message("Creature will stop following",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
		return;
	}*/
}
#endif