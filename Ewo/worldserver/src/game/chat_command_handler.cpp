// Copyright (C) 2006 Team Evolution
#include "WorldServer.h"

uint32 get_param_uint32(uint8* data,uint32& pos,uint32 maxlen)
{
	char param[20],start=pos; //we receive this case only 1 param=template_id
	for(;data[pos]!=' ' && pos<maxlen;pos++)
		param[pos-start]=data[pos];
	param[pos-start]=0;
	pos++;
	return atoi(param);
}

float get_param_float(uint8* data,uint32& pos,uint32 maxlen)
{
	char param[20],start=pos; //we receive this case only 1 param=template_id
	for(;data[pos]!=' ' && pos<maxlen;pos++)
		param[pos-start]=data[pos];
	param[pos-start]=0;
	pos++;
	return (float)atof(param);
}

//this is just a cut+paste from worlsrv_packet_handler. Should make it more flexible
void WorldServer::handle_chat_command(GameClient *pClient, Character *p_char)
{
	//let's copy the first word wat can be the command
	char cmd[40];
	uint32	param1,param2,param3,pos; //we receive this case only 1 param=template_id
	float	paramf1,paramf2,paramf3;
	G_recv_packet.data[G_recv_packet.length+1]=' '; //make sure we reach an end when searching for values
	for(pos=9;G_recv_packet.data[pos]!=' ';pos++)
		cmd[pos-9]=G_recv_packet.data[pos];
	cmd[pos-9]=0;//the terminator
	pos++;
	//let's see if it matches any command we know
	creature *p_cr=(creature*)(p_char->last_target_GUID);
	if(pClient->gm_level>2)
	{
	}
	if(pClient->gm_level>1)
	{
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		if(strcmp(cmd,"mypos")==0)
		{
			char msg[100];
			sprintf(msg,"x=%f, y=%f, z=%f, o=%f",p_char->pos_x,p_char->pos_y,p_char->pos_z,p_char->orientation);
			send_message(msg,SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		if(strcmp(cmd,"cr_getuint32")==0)
		{
			param1=get_param_uint32(G_recv_packet.data,pos,G_recv_packet.length); //item_id
			if(p_char->selected_object_guid)
			{
				char msg[50];
				sprintf(msg,"var %u value =%d",param1,((creature *)p_char->selected_object_guid)->data32[param1]);
				send_message(msg,SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			}
			return;
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		if(strcmp(cmd,"cr_setuint32")==0)
		{
			param1=get_param_uint32(G_recv_packet.data,pos,G_recv_packet.length); //item_id
			param2=get_param_uint32(G_recv_packet.data,pos,G_recv_packet.length); //item_id
			if(p_char->selected_object_guid)
			{
				((creature *)p_char->selected_object_guid)->SetUInt32Value(param1,param2);
				send_message("Modified creature stat",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			}
			return;
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*		if(strcmp(cmd,"showstats")==0)
		{
			printf("min/max dmg is %f / %f\n",p_char->dataf[UNIT_FIELD_MINDAMAGE],p_char->dataf[UNIT_FIELD_MAXDAMAGE]);
			for(int i=0;i<7;i++)
				printf("%d) item_dmg_min / max => %f / %f, mod pos %d mod neg %d mod pct %f, dmg_min %f , dmg_diff %d\n",
				i, p_char->item_min_dmg[i],p_char->item_max_dmg[i],
				p_char->data32[PLAYER_FIELD_MOD_DAMAGE_DONE_POS+i],p_char->data32[PLAYER_FIELD_MOD_DAMAGE_DONE_NEG+i],p_char->dataf[PLAYER_FIELD_MOD_DAMAGE_DONE_PCT+i],
				p_char->dmg_min[i],p_char->dmg_diff[i]);
			return;
		}*/
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		if(strcmp(cmd,"castspell")==0)
		{
			param1=get_param_uint32(G_recv_packet.data,pos,G_recv_packet.length); //item_id
			if(param1>G_max_spell_id || G_spell_info[param1]==NULL)
			{
				send_message("Spell template does not exist",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
				return;
			}
			send_message("Casting an instant no mana spell",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			p_char->instant_spell.char_instant_nomana_cast(param1,-1);
			return;
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		if(strcmp(cmd,"additem")==0)
		{
			param1=get_param_uint32(G_recv_packet.data,pos,G_recv_packet.length); //item_id
//printf("received additem to slot %u item id %u\n",param2,param1);
			if(param1 >= G_max_item_id || G_item_prototypes[param1]==NULL)
			{
				send_message("Item id is wrong",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
				return;
			}
//printf("new item name %s\n",(char*)G_item_prototypes[param1]->item_data32[ITEM_NAME]);
			Item *new_item;
			new_item = G_Object_Pool.Get_fast_New_item();
			new_item->create_from_template(G_item_prototypes[param1]);
			//add it to player
			if(!p_char->auto_store_item(new_item))
			{
				G_Object_Pool.Release_item(new_item);
				p_char->msg_inv_change_result(NULL,NULL,INV_ERR_INVENTORY_FULL);
			}
//printf("added item to char \n");
			return;
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		if(strcmp(cmd,"setfloat")==0)
		{
			param1=get_param_uint32(G_recv_packet.data,pos,G_recv_packet.length);
			paramf1=get_param_float(G_recv_packet.data,pos,G_recv_packet.length);
			if(param1>PLAYER_END)
			{
				send_message("Var index missing",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);			
				return;
			}
			p_char->SetFloatValue(param1,paramf1);
			return;
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		if(strcmp(cmd,"getuint32")==0)
		{
			param1=get_param_uint32(G_recv_packet.data,pos,G_recv_packet.length);
			if(param1>PLAYER_END)
			{
				send_message("Var index missing",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);			
				return;
			}
			char msg[50];
			sprintf(msg,"var %u value =%d",param1,p_char->data32[param1]);
			send_message(msg,SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		if(strcmp(cmd,"setuint32")==0)
		{
			param1=get_param_uint32(G_recv_packet.data,pos,G_recv_packet.length);
			param2=get_param_uint32(G_recv_packet.data,pos,G_recv_packet.length);
			if(G_gameobject_prototypes[param1]==NULL)
			{
				send_message("Var index missing",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
				return;
			}
			p_char->SetUInt32Value(param1,param2);
			return;
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		//we received faction cmd
		if(strcmp(cmd,"cr_faction")==0)
		{
			if(!((uint32)(p_char->selected_object_guid>>32) & HIGHGUID_UNIT))
			{
				send_message("Can tell unit faction only",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
				return;
			}
			char msg[100];
			creature *sel_cr;
			sel_cr = (creature *)(p_char->selected_object_guid);
			sprintf(msg,"Creature faction is %d",sel_cr->data32[UNIT_FIELD_FACTIONTEMPLATE]);
			send_message(msg,SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		//we received an delgo cmd so let's take actions for it
		///////////////////////////////////////////////////////////////
		if(strcmp(cmd,"delspawn_go")==0 && p_char->last_used_gameobject_guid!=NULL)
		{
			gameobject_instance *p_go=(gameobject_instance *)(p_char->last_used_gameobject_guid);
			uint32 object_type=(uint32)(p_char->last_used_gameobject_guid >> 32);
			//check if creature realy exists
			if(!(object_type & HIGHGUID_GAMEOBJECT))  return;
			//delete it from world by sending a destroy object to block
			G_maps[p_go->map_id]->del_go(p_go);
			//delete it from db
			G_dbi_w->del_spawn_go(p_go->db_id);
			send_message("Gameobject deleted from world and DB",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		//we received teleport cmd so let's take actions for it
		///////////////////////////////////////////////////////////////
		if(strcmp(cmd,"teleport")==0)
		{
			param1=get_param_uint32(G_recv_packet.data,pos,G_recv_packet.length);
			paramf1=get_param_float(G_recv_packet.data,pos,G_recv_packet.length);
			paramf2=get_param_float(G_recv_packet.data,pos,G_recv_packet.length);
			paramf3=get_param_float(G_recv_packet.data,pos,G_recv_packet.length);
//printf("we received a gm command named %s param 1 %u, param2 %f, param3 %f,param4 %f\n",cmd,atoi(param1),atof(param2),atof(param3),atof(param4));
			if(G_maps[param1]==NULL)
			{
				send_message("Map is not defined",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
				return;
			}
			if(G_maps[param1]->min_x>paramf1 || G_maps[param1]->max_x<paramf1 || G_maps[param1]->min_y>paramf2 || G_maps[param1]->max_y<paramf2)
			{
				send_message("Cannot teleport out of defined map",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
				return;
			}
			teleport(p_char,param1,paramf1,paramf2,paramf3,p_char->orientation);
			return;
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		//we received an addgo cmd so let's take actions for it
		///////////////////////////////////////////////////////////////
		if(strcmp(cmd,"addspawn_go")==0)
		{
			param1=get_param_uint32(G_recv_packet.data,pos,G_recv_packet.length);
			param2=get_param_uint32(G_recv_packet.data,pos,G_recv_packet.length);
			if(param1>G_max_gameobjects || G_gameobject_prototypes[param1]==NULL)
			{
				send_message("Template ID does not exist",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
				return;
			}
			if(param2==0)
			{
				send_message("Respawn delay must be greater than 0",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
				return;
			}
			G_dbi_w->add_spawn_go(p_char,param1,param2);
			send_message("Gameobject added to world and DB",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		//we received an delspawnpoint cmd so let's take actions for it
		///////////////////////////////////////////////////////////////
		if(strcmp(cmd,"delspawn_cr")==0 && p_char->selected_object_guid!=NULL)
		{
			creature *p_cr=(creature *)(p_char->selected_object_guid);
			uint32 object_type=(uint32)(p_char->selected_object_guid >> 32);
			//check if creature realy exists
			if(!(object_type & HIGHGUID_UNIT))return;
			//delete it from world by sending a destroy object to block
			G_maps[p_cr->map_id]->on_creature_exited_block(p_cr);
			G_maps[p_cr->map_id]->del_creature(p_cr);
			//delete it from db
			G_dbi_w->del_spawn_creature(p_cr->db_id);
			send_message("Creature deleted from world and DB",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		//we received an addspawnpoint cmd so let's take actions for it
		///////////////////////////////////////////////////////////////
		if(strcmp(cmd,"addspawn_cr")==0)
		{
			param1=get_param_uint32(G_recv_packet.data,pos,G_recv_packet.length);
			param2=get_param_uint32(G_recv_packet.data,pos,G_recv_packet.length);
			param3=get_param_uint32(G_recv_packet.data,pos,G_recv_packet.length);
//printf("we received a gm command named %s param 1 %u, param2 %u\n",cmd,atoi(param1),atoi(param2));
			if(G_creature_prototypes[param1]==NULL)
			{
				send_message("Template ID does not exist",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
				return;
			}
			if(param2==0)
			{
				send_message("Respawn delay must be greater than 0",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
				return;
			}
			G_dbi_w->add_spawn_creature(p_char,param1,param2,param3);
			send_message("Creature added to world and DB",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		if(strcmp(cmd,"cr_cast")==0)
		{
			creature *p_cr=(creature*)(p_char->last_target_GUID);
			param1=get_param_uint32(G_recv_packet.data,pos,G_recv_packet.length);
			if(p_cr==NULL)
			{
				send_message("Must target creaure",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
				return;
			}
			if(param1>G_max_spell_id || G_spell_info[param1]==0)
			{
				send_message("Spell does not exist",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
				return;
			}
			p_cr->start_cast(param1,0,p_char->getGUID());
//			G_instant_spell_instance.cr_instant_cast(p_cr,param1,p_char->getGUID());
			send_message("Creature casted spell",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		if(strcmp(cmd,"add_xp")==0)
		{
			param1=get_param_uint32(G_recv_packet.data,pos,G_recv_packet.length);
			if(param1==0)
			{
				send_message("There is no point to add no xp",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
				return;
			}
			p_char->xp_modify(0,param1,1);
			send_message("Added XP",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		if(strcmp(cmd,"add_money")==0)
		{
			param1=get_param_uint32(G_recv_packet.data,pos,G_recv_packet.length);
			if(param1==0)
			{
				send_message("There is no point to add no money",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
				return;
			}
			p_char->SetUInt32Value(PLAYER_FIELD_COINAGE,p_char->data32[PLAYER_FIELD_COINAGE]+param1);
			send_message("Added money",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		if(strcmp(cmd,"learnspell")==0)
		{
			param1=get_param_uint32(G_recv_packet.data,pos,G_recv_packet.length);
			if(param1>G_max_spell_id || G_spell_info[param1]==NULL)
			{
				send_message("Spell template does not exist",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
				return;
			}
			p_char->spellbook.add(param1);
			//cast the learning spell - w
			G_send_packet.opcode = SMSG_LEARNED_SPELL;
			G_send_packet.data32[0] = param1;
			G_send_packet.length = 4;
			p_char->pClient->SendMsg(&G_send_packet);
			send_message("Added money",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
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
			if(p_cr->db_id==0)
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
			p_cr->waypoint_lst.del();
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
			p_cr->update_obj_pos(NULL);
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
			p_cr->update_obj_pos(NULL);
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
			p_cr->update_obj_pos(NULL);
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
			p_cr->update_obj_pos(NULL);
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
			p_cr->update_obj_pos(NULL);
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
		}
#ifdef VERSION_CHAR_MAKE_CREAUTURE_WPOINTS
		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		//this is a special function to teleport to each creature waypoint and get them a valid Z
		if(strcmp(cmd,"stop_making_waypoints")==0)
		{
			p_char->state2 &= ~CHAR_STATE_TO_DO_CREATURE_CORDS;
			send_message("Character will stop generating creature z cords",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
		if(strcmp(cmd,"start_making_waypoints_all")==0)
		{
			p_char->cur_map_id=-1;
			p_char->lock_map_id=-1;
			p_char->state2 |= CHAR_STATE_TO_DO_CREATURE_CORDS;
			p_char->state2 &= ~(CHAR_STATE_TO_DO_CREATURE_CORDS_BEFORE_FALL|CHAR_STATE_TO_DO_CREATURE_CORDS_AFTER_FALL);
			send_message("Character will start to teleport like a maniac to generate creature z cords",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
		//this is a special function to teleport to each creature waypoint and get them a valid Z
		if(strcmp(cmd,"start_making_waypoints")==0)
		{
			p_char->cur_map_id=-1;
			p_char->lock_map_id=get_param_uint32(G_recv_packet.data,pos,G_recv_packet.length);
			p_char->state2 |= CHAR_STATE_TO_DO_CREATURE_CORDS;
			p_char->state2 &= ~(CHAR_STATE_TO_DO_CREATURE_CORDS_BEFORE_FALL|CHAR_STATE_TO_DO_CREATURE_CORDS_AFTER_FALL);
			send_message("Character will start to teleport like a maniac to generate creature z cords",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,p_char,NULL);
			return;
		}
#endif
	}
	//if we arrived here it means it's not a command so we realy say it :)
	send_message((char*)&G_recv_packet.data[8],SEND_MESSAGE_TO_BLOCK | SEND_MESSAGE_TO_ME,CHAT_MSG_SAY,G_recv_packet.data32[1],NULL,p_char,NULL);
}