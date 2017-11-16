// Copyright (C) 2006 Team Evolution
#include "globals.h"
#include "quest.h"

void Quest_instance_List::add(Quest_instance_Node *new_node)
{
	new_node->next = first;
	first = new_node;
}

uint32 Quest_instance_List::add(uint32 quest_id)
{
	uint32 i,free_q_slot=0xFF;
	//let's see if we have an open free quest slot
	for (i = PLAYER_QUEST_LOG_1_1; i <= PLAYER_VISIBLE_ITEM_1_CREATOR; i+=3)
		if (owner->data32[i] == 0)
		{
			free_q_slot = (i - PLAYER_QUEST_LOG_1_1)/3;
			break;
		}
	if(free_q_slot==0xFF)
			return 0xFFFFFFFF;
//printf("adding new active quest %u,to slot %u\n",quest_id,free_q_slot);
//	Quest_instance_Node	*new_node= cc_char->quests_started.first;
	owner->SetUInt32Value(PLAYER_QUEST_LOG_1_1 + free_q_slot*3+0,quest_id);
	owner->SetUInt32Value(PLAYER_QUEST_LOG_1_1 + free_q_slot*3+1,0);
	Quest_instance_Node *new_node;
	new_node = new Quest_instance_Node;
	memset(new_node,0,sizeof(Quest_instance_Node));
	new_node->value.id = quest_id;
	new_node->value.slot = free_q_slot;
	if(G_quest_prototypes[quest_id]->obj_time)
	{
		new_node->value.end_timestamp_s = G_cur_time + G_quest_prototypes[quest_id]->obj_time;//given in seconds!
		owner->SetUInt32Value(PLAYER_QUEST_LOG_1_1+new_node->value.slot*3+2,new_node->value.end_timestamp_s);
	}
	else new_node->value.end_timestamp_s = 0xFFFFFFFF;
	new_node->value.state = QMGR_QUEST_NOT_FINISHED;
	memcpy(new_node->value.obj_kill_remaining,G_quest_prototypes[quest_id]->obj_kill_count,4*sizeof(uint32));
    memcpy(new_node->value.obj_items_remaining,G_quest_prototypes[quest_id]->obj_item_count,4*sizeof(uint32));
	for(i=0;i<MAGIC_QUEST_NUMBER;i++)
		if(G_quest_prototypes[quest_id]->obj_trigger_id[i])
			new_node->value.obj_trigger_remaining[i] = 1;
	//check if player already has some quest items that are required
	for(i=0;i<4;i++)
		if(G_quest_prototypes[quest_id]->obj_item_id[i])
		{
			uint32 already_has = owner->get_total_item_count(G_quest_prototypes[quest_id]->obj_item_id[i]);
			if(already_has)
				on_add_item(G_quest_prototypes[quest_id]->obj_item_id[i],already_has);
		}
	new_node->next = first;
	first = new_node;
	return new_node->value.slot;
}

/*
uint32 Quest_instance_List::on_to_talk_to_NPC(uint32 cr_id)
{
	Quest_instance_Node *kur = first;
	while(kur && G_quest_prototypes[kur->value.id]->obj_speakto_id!=cr_id)
		kur = kur->next;
	if(kur)
	{
		kur->value.obj_speakto ++;
		check_finished(kur);
		if(kur->value.state==QMGR_QUEST_FINISHED)
			return kur->value.id;
	}
	return 0;
}*/

uint32	Quest_instance_List::need_to_talk_to_NPC(uint32 cr_id)
{
	Quest_instance_Node *kur = first;
	while(kur && G_quest_prototypes[kur->value.id]->obj_speakto_id!=cr_id)
		kur = kur->next;
	if(kur)
		return 1;
	return 0;
}

void Quest_instance_List::on_kill(uint32 p_object_id,uint64 obj_guid)
{
	Quest_instance_Node *kur = first;
	int i;
	uint32 object_id = p_object_id & 0x0000FFFF;
	while(kur)
	{
//printf("checking onkill event, state is %u for quest %u\n",kur->value.state,kur->value.id);
		if(kur->value.state==QMGR_QUEST_NOT_FINISHED)
			for(i=0;i<4;i++)
			{
//printf("\t %u)should kill %u and have %u,kur %u\n",i, G_quest_prototypes[kur->value.id]->obj_kill_id[i],object_id,kur->value.obj_kill_remaining[i]);
				if( G_quest_prototypes[kur->value.id]->obj_kill_id[i]==object_id && 
					kur->value.obj_kill_remaining[i])
				{
					kur->value.obj_kill_remaining[i]--;
					//alert owner
					uint32 kill_count = G_quest_prototypes[kur->value.id]->obj_kill_count[i] - kur->value.obj_kill_remaining[i];
					G_send_packet.opcode = SMSG_QUESTUPDATE_ADD_KILL;
					G_send_packet.data32[0] = kur->value.id;
					G_send_packet.data32[1] = object_id;
					G_send_packet.data32[2] = kill_count;
					G_send_packet.data32[3] = G_quest_prototypes[kur->value.id]->obj_kill_count[i];
					G_send_packet.data64[2] = obj_guid;
					G_send_packet.length = 24;
					owner->pClient->SendMsg(&G_send_packet);
					owner->SetUInt32Value(PLAYER_QUEST_LOG_1_1+kur->value.slot*3+1,owner->data32[PLAYER_QUEST_LOG_1_1+kur->value.slot*3+1] + (1<<(6*i)));
					//check if we completed quest
					if(kur->value.obj_kill_remaining[i]==0)
					{
						check_finished(kur);
						//if this is a kill quest then we can prodly anounce that it has been finished. Watch about gather item quests as you can dump quest items
						if(kur->value.state==QMGR_QUEST_FINISHED)
							finish_quest(kur);
//						else if(kur->value.state==QMGR_QUEST_FAILED)
//							fail_quest(kur);
					}
				}
			}
		kur = kur->next;
	}
}

void	Quest_instance_List::finish_quest(Quest_instance_Node *node)
{
	msg_quest_complete(owner->pClient,node->value.id);
	uint32 index=PLAYER_QUEST_LOG_1_1+node->value.slot*3+1;
	owner->SetUInt32Value(index,owner->data32[index] | 0x01000000);
	//remove timer for timed quests
	owner->SetUInt32Value(index+1,0x0);
}

void	Quest_instance_List::finish_quest(uint32 quest_id)
{
	Quest_instance_Node *kur = first;
	while(kur)
	{
		if(kur->value.id==quest_id)
		{
			kur->value.state=QMGR_QUEST_FINISHED;
			finish_quest(kur);
			return;
		}
		kur = kur->next;
	}
}

void	Quest_instance_List::fail_quest(uint32 quest_id)
{
	Quest_instance_Node *kur = first;
	while(kur)
	{
		if(kur->value.id==quest_id)
		{
			if(kur->value.state!=QMGR_QUEST_FINISHED)
				kur->value.state=QMGR_QUEST_FAILED;
			return;
		}
		kur = kur->next;
	}
	msg_quest_failed(owner->pClient,quest_id);
}

void	Quest_instance_List::check_finished(Quest_instance_Node *node)
{
	Quest_template *ptemplate;
	if(node->value.state==QMGR_QUEST_FINISHED || node->value.state==QMGR_QUEST_FAILED)
		return;
	if(node->value.end_timestamp_s<G_cur_time)
	{
		node->value.state = QMGR_QUEST_FAILED;
		msg_quest_timer_failed(owner->pClient,node->value.id);
		return;
	}
	node->value.state = QMGR_QUEST_FINISHED;
	ptemplate = G_quest_prototypes[node->value.id];//we should have taken care of wrong quests on load
	//this quest is already on progress for us. Let's see if we finished it
	for(int i=0;i<4;i++)
		if( //we killed all the mobs that we were required to kill ?
			(node->value.obj_kill_remaining[i] > 0) ||
			//check if we gathered all required triggers ?
			(node->value.obj_trigger_remaining[i] > 0 ) ||
			//check if we have all required items ?
			(node->value.obj_items_remaining[i] > 0)
//			(ptemplate->obj_item_id[i] && owner->get_total_item_count(ptemplate->obj_item_id[i])<ptemplate->obj_item_count[i])
			)
			node->value.state = QMGR_QUEST_NOT_FINISHED;
	if((owner->data32[PLAYER_FIELD_COINAGE] < ptemplate->obj_money))
		node->value.state = QMGR_QUEST_NOT_FINISHED;
}

uint32	Quest_instance_List::would_finish(Quest_instance_Node *node,uint32 talkingto_id)
{
	if(node->value.state==QMGR_QUEST_FINISHED)
		return 1;
	if(node->value.state==QMGR_QUEST_FAILED)
		return 0;
	if(node->value.end_timestamp_s<G_cur_time)
	{
		node->value.state = QMGR_QUEST_FAILED;
		msg_quest_timer_failed(owner->pClient,node->value.id);
		return 0;
	}
	Quest_template *ptemplate;
	ptemplate = G_quest_prototypes[node->value.id];//we should have taken care of wrong quests on load
	//this quest is already on progress for us. Let's see if we finished it
	for(int i=0;i<4;i++)
		if( //we killed all the mobs that we were required to kill ?
			(node->value.obj_kill_remaining[i] > 0 ) ||
			//check if we gathered all required triggers ?
			(node->value.obj_trigger_remaining[i] > 0) ||
			//check if we have all required items ?
			(node->value.obj_items_remaining[i] > 0)
//			(ptemplate->obj_item_id[i] && owner->get_total_item_count(ptemplate->obj_item_id[i])<ptemplate->obj_item_count[i])
			)
			return QMGR_QUEST_NOT_FINISHED;
	if(owner->data32[PLAYER_FIELD_COINAGE] < ptemplate->obj_money)
			return QMGR_QUEST_NOT_FINISHED;
//printf("player met all the rest requirments on  atalkto quest\n");
//	if(ptemplate->obj_speakto_id && talkingto_id!=ptemplate->obj_speakto_id)
	if(talkingto_id!=ptemplate->obj_speakto_id)//finish only talkto quests
		return QMGR_QUEST_NOT_FINISHED;
//printf("player is able to finish the talkto quest with the current NPC\n");
	return QMGR_QUEST_FINISHED;
}

uint32	Quest_instance_List::get_quest_status(uint32 quest_id)
{
	Quest_instance_Node *itr=first;
	while(itr && itr->value.id!=quest_id)
		itr = itr->next;
	if(itr)
		return itr->value.state;
	return 0xFFFFFFFF;
}

void	Quest_instance_List::on_add_item(uint32 item_id,uint32 count)
{
	Quest_instance_Node *itr=first;
	uint32	i;
	while(itr)
	{
		for(i=0;i<4;i++)
			if(itr->value.obj_items_remaining[i]>0 && G_quest_prototypes[itr->value.id]->obj_item_id[i]==item_id)
			{
				itr->value.obj_items_remaining[i]=itr->value.obj_items_remaining[i] - count;
				msg_add_item(item_id,count);
				if(itr->value.obj_items_remaining[i]<=0)
				{
					check_finished(itr);
					if(itr->value.state==QMGR_QUEST_FINISHED)
						finish_quest(itr);
//					else if(kur->value.state==QMGR_QUEST_FAILED)
//						fail_quest(kur);
				}
				return;
			}
		itr = itr->next;
	}
}

void	Quest_instance_List::msg_add_item(uint32 item_id,uint32 count)
{
	G_send_packet.opcode = SMSG_QUESTUPDATE_ADD_ITEM;
	G_send_packet.data32[0] = item_id;
	G_send_packet.data32[1] = count;
	G_send_packet.length = 8;
	owner->pClient->SendMsg(&G_send_packet);
}
//we can only destroy an item if we abandoned the quest
uint32	Quest_instance_List::can_destroy_item(uint32 item_id)
{
	Quest_instance_Node *itr=first;
	uint32	i;
	while(itr)
	{
		for(i=0;i<4;i++)
			if(G_quest_prototypes[itr->value.id]->obj_item_id[i]==item_id)
				return 0;
		itr = itr->next;
	}
	return 1;
}

//used on load char and on finish quest. To recaunt and resend number of available items for quests
void	Quest_instance_List::refresh_items_gathered()
{
	Quest_instance_Node *itr=first;
	uint32	i;
	while(itr)
	{
		for(i=0;i<4;i++)
			if(G_quest_prototypes[itr->value.id]->obj_item_id[i])
			{
				itr->value.obj_items_remaining[i] = G_quest_prototypes[itr->value.id]->obj_item_count[i];
				uint32 already_has = owner->get_total_item_count(G_quest_prototypes[itr->value.id]->obj_item_id[i]);
//printf("found %u items fro quest on char\n",already_has);
				if(already_has)
				{
					itr->value.obj_items_remaining[i] -= already_has;
//					msg_add_item(G_quest_prototypes[itr->value.id]->obj_item_id[i],already_has);
					msg_add_item(G_quest_prototypes[itr->value.id]->obj_item_id[i],0);//for some wierd reson client shows diffrent value
				}
			}
		itr = itr->next;
	}
	//teoreticaly we won't get more then required quest item in inventory. Change here incase we send more then required count
}

void Quest_instance_List::on_enter_custom_trigger(uint32 trigger_id)
{
//printf("adding trigger %u to quest\n",trigger_id);
	Quest_instance_Node *itr=first;
	while(itr)
	{
		uint32	i;
		for(i=0;i<4;i++)
			if(itr->value.obj_trigger_remaining[i]>0 && G_quest_prototypes[itr->value.id]->obj_trigger_id[i]==trigger_id)
			{
				itr->value.obj_trigger_remaining[i] --;
				if(itr->value.obj_trigger_remaining[i]==0)
				{
//printf("1 found quest %u so this trigger will complete it, state %u time %u should end %u\n",itr->value.id,itr->value.state,G_cur_time,itr->value.end_timestamp_s);
					check_finished(itr);
//printf("2 found quest %u so this trigger will complete it, state %u\n",itr->value.id,itr->value.state);
					if(itr->value.state==QMGR_QUEST_FINISHED)
					{
//printf("realy finished quest\n");
						finish_quest(itr);
					}
//					else if(kur->value.state==QMGR_QUEST_FAILED)
//						fail_quest(kur);
				}
			}
		itr = itr->next;
	}
}

/*
void	Quest_instance_List::on_rem_item(uint32 item_id,uint32 count)
{
	Quest_instance_Node *itr=first;
	uint32 t_count=count;
	uint32	i;
	while(itr)
	{
		for(i=0;i<4;i++)
			if(G_quest_prototypes[itr->value.id]->obj_item_id[i]==item_id)
			{
				//if there is a possibility quests will change it's status
				if(itr->value.obj_items_remaining[i]<=0 && -itr->value.obj_items_remaining[i] < (signed int)count)
					itr->value.state = QMGR_QUEST_NOT_FINISHED;
				itr->value.obj_items_remaining[i] += count;
				if(itr->value.obj_items_remaining[i]>(signed int)G_quest_prototypes[itr->value.id]->obj_item_count[i])
					itr->value.obj_items_remaining[i] = G_quest_prototypes[itr->value.id]->obj_item_count[i];
				G_send_packet.opcode = SMSG_QUESTUPDATE_ADD_ITEM;
				G_send_packet.data32[0] = item_id;
				G_send_packet.data32[1] = -count;
				G_send_packet.length = 8;
				owner->pClient->SendMsg(&G_send_packet);
			}
		itr = itr->next;
	}
}
*/
void msg_quest_start_details(GameClient *pClient,uint64 quest_giver_guid,uint32 quest_id)
{
	Quest_template *ptemplate=G_quest_prototypes[quest_id];
	uint32 i;
	uint32 len,mark1;
	G_send_packet.opcode = SMSG_QUESTGIVER_QUEST_DETAILS;
	G_send_packet.data64[0] = quest_giver_guid;
	G_send_packet.data32[2] = quest_id;
	strcpy((char*)&G_send_packet.data[12],ptemplate->title_txt);
	len = 12 + strlen(ptemplate->title_txt)+1;
	strcpy((char*)&G_send_packet.data[len],ptemplate->details_txt);
	len += strlen(ptemplate->details_txt)+1;
	strcpy((char*)&G_send_packet.data[len],ptemplate->objective_txt);
	len += strlen(ptemplate->objective_txt)+1;
	*(uint32*)&G_send_packet.data[len] = 1;//type ? 0/1 = inactive/active. In all examples it was 1
	len +=4;
	*(uint32*)&G_send_packet.data[len] = 0;//unk
	len +=4;
	*(uint32*)&G_send_packet.data[len] = 0;//number of optional reward items.then a list of item data
	mark1 = len;
	len +=4;
	for(i=0;i<4;i++)
		if(ptemplate->rew_opt_item_id[i]!=0)
		{
			*(uint32*)&G_send_packet.data[mark1] += 1;//item count
			*(uint32*)&G_send_packet.data[len] = ptemplate->rew_opt_item_id[i];
			*(uint32*)&G_send_packet.data[len+4] = ptemplate->rew_opt_item_count[i];
			*(uint32*)&G_send_packet.data[len+8] = G_item_prototypes[ptemplate->rew_opt_item_id[i]]->item_data32[ITEM_DISPLAY_INFO_ID];
			len += 12;
		}
	*(uint32*)&G_send_packet.data[len] = 0;//number of static reward items
	mark1 = len;
	len += 4;
	for(i=0;i<4;i++)
		if(ptemplate->rew_item_id[i]!=0)
		{
			*(uint32*)&G_send_packet.data[mark1] += 1;//item count
			*(uint32*)&G_send_packet.data[len] = ptemplate->rew_item_id[i];
			*(uint32*)&G_send_packet.data[len+4] = ptemplate->rew_item_count[i];
			*(uint32*)&G_send_packet.data[len+8] = G_item_prototypes[ptemplate->rew_item_id[i]]->item_data32[ITEM_DISPLAY_INFO_ID];
			len += 12;
		}
	*(uint32*)&G_send_packet.data[len] = ptemplate->rew_money;
	len += 4;
	*(uint32*)&G_send_packet.data[len] = ptemplate->rew_teach_spell;
	len += 4;
	*(uint32*)&G_send_packet.data[len] = ptemplate->cast_spell;
	len += 4;
	*(uint32*)&G_send_packet.data[len] = 0;//count of blocks that will follow for obj gather. No tsure about list though
	mark1 = len;
	len += 4;
	for(i=0;i<4;i++)
		if(ptemplate->obj_item_id[i]!=0)
//			&& ptemplate->obj_kill_type[i]==0)
		{
			*(uint32*)&G_send_packet.data[mark1] += 1;//item count
			*(uint32*)&G_send_packet.data[len] = ptemplate->obj_kill_id[i]; //it is strange because in logs server sends some small number here and next values are 0 most of the time
			*(uint32*)&G_send_packet.data[len+4] = ptemplate->obj_kill_count[i];
			len += 8;
		}/**/
	G_send_packet.length = len;
	pClient->SendMsg(&G_send_packet);
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void msg_quest_not_finished_missing(GameClient *pClient,uint64 quest_giver_guid,uint32 quest_id)
{
	uint32 i;
	uint32 len,mark1;
	Quest_template *ptemplate=G_quest_prototypes[quest_id];
	G_send_packet.opcode = SMSG_QUESTGIVER_REQUEST_ITEMS;
	G_send_packet.data64[0] = quest_giver_guid;
	G_send_packet.data32[2] = quest_id;
	strcpy((char*)&G_send_packet.data[12],ptemplate->title_txt);
	len = 12 + strlen(ptemplate->title_txt)+1;
	strcpy((char*)&G_send_packet.data[len],ptemplate->incomplete_txt);
	len += strlen(ptemplate->incomplete_txt)+1;
	*(uint32*)&G_send_packet.data[len] = 0;
	len += 4;
	*(uint32*)&G_send_packet.data[len] = 1;
	len += 4;
	*(uint32*)&G_send_packet.data[len] = 1;
	len += 4;
	*(uint32*)&G_send_packet.data[len] = G_quest_prototypes[quest_id]->obj_money;
	len += 4;
	*(uint32*)&G_send_packet.data[len] = 0; //req item count
	mark1 = len;
	len += 4;
	for(i=0;i<4;i++)
		if(ptemplate->obj_item_id[i]!=0)
		{
			*(uint32*)&G_send_packet.data[mark1] += 1;//item count
			*(uint32*)&G_send_packet.data[len] = ptemplate->obj_item_id[i];
			*(uint32*)&G_send_packet.data[len+4] = ptemplate->obj_item_count[i];
			*(uint32*)&G_send_packet.data[len+8] = G_item_prototypes[ptemplate->obj_item_id[i]]->item_data32[ITEM_DISPLAY_INFO_ID];
			len += 12;
		}
	*(uint32*)&G_send_packet.data[len] = 2;
	len += 4;
	*(uint32*)&G_send_packet.data[len] = 0;
	len += 4;
	*(uint32*)&G_send_packet.data[len] = 4;
	len += 4;
	*(uint32*)&G_send_packet.data[len] = 8;
	len += 4;
	*(uint32*)&G_send_packet.data[len] = 0x10;
	len += 4;
	G_send_packet.length = len;
	pClient->SendMsg(&G_send_packet);
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void msg_quest_finished_rewards(GameClient *pClient,uint64 quest_giver_guid,uint32 quest_id)
{
	uint32 i;
	uint32 len,mark1;
	Quest_template *ptemplate=G_quest_prototypes[quest_id];
	G_send_packet.opcode = SMSG_QUESTGIVER_OFFER_REWARD;
	G_send_packet.data64[0] = quest_giver_guid;
	G_send_packet.data32[2] = quest_id;
	strcpy((char*)&G_send_packet.data32[3],ptemplate->title_txt);
	len = 12 + strlen(ptemplate->title_txt)+1;
	strcpy((char*)&G_send_packet.data[len],ptemplate->done_txt);
	len += strlen(ptemplate->done_txt)+1;
	*(uint32*)&G_send_packet.data[len] = 1; //enable next / 1 emote
	len += 4;
	*(uint32*)&G_send_packet.data[len] = 0; //unk ?
	len += 4;
	*(uint32*)&G_send_packet.data[len] = 1; //emote count
	len += 4;
	*(uint32*)&G_send_packet.data[len] = EMOTE_ONESHOT_CHEER; //emote 0
	len += 4;
	*(uint32*)&G_send_packet.data[len] = 0; //delay
	len += 4;
	*(uint32*)&G_send_packet.data[len] = 0; //choice reward items
	mark1 = len;
	len += 4;
	for(i=0;i<6;i++)
		if(ptemplate->rew_opt_item_id[i]!=0)
		{
			*(uint32*)&G_send_packet.data[mark1] += 1;//item count
			*(uint32*)&G_send_packet.data[len] = ptemplate->rew_opt_item_id[i];
			*(uint32*)&G_send_packet.data[len+4] = ptemplate->rew_opt_item_count[i];
			*(uint32*)&G_send_packet.data[len+8] = G_item_prototypes[ptemplate->rew_opt_item_id[i]]->item_data32[ITEM_DISPLAY_INFO_ID];
			len += 12;
		}
	*(uint32*)&G_send_packet.data[len] = 0; //reward items
	mark1 = len;
	len += 4;
	for(i=0;i<6;i++)
		if(ptemplate->rew_item_id[i]!=0)
		{
			*(uint32*)&G_send_packet.data[mark1] += 1;//item count
			*(uint32*)&G_send_packet.data[len] = ptemplate->rew_item_id[i];
			*(uint32*)&G_send_packet.data[len+4] = ptemplate->rew_item_count[i];
			*(uint32*)&G_send_packet.data[len+8] = G_item_prototypes[ptemplate->rew_item_id[i]]->item_data32[ITEM_DISPLAY_INFO_ID];
			len += 12;
		}
	*(uint32*)&G_send_packet.data[len] = ptemplate->rew_money; 
	len += 4;
	*(uint32*)&G_send_packet.data[len] = ptemplate->s_flags; 
	len += 4;
	*(uint32*)&G_send_packet.data[len] = ptemplate->rew_teach_spell; 
	len += 4;
	*(uint32*)&G_send_packet.data[len] = 0; 
	len += 4;
	G_send_packet.length = len;
	pClient->SendMsg(&G_send_packet);
 }

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void msg_quest_failed(GameClient *pClient,uint32 quest_id)
{
	G_send_packet.opcode = SMSG_QUESTUPDATE_FAILED;
	G_send_packet.data32[0] = quest_id;
	G_send_packet.length = 4;
	pClient->SendMsg(&G_send_packet);
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void msg_quest_timer_failed(GameClient *pClient,uint32 quest_id)
{
	G_send_packet.opcode = SMSG_QUESTUPDATE_FAILEDTIMER;
	G_send_packet.data32[0] = quest_id;
	G_send_packet.length = 4;
	pClient->SendMsg(&G_send_packet);
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void msg_quest_complete(GameClient *pClient,uint32 quest_id)
{
	G_send_packet.opcode = SMSG_QUESTUPDATE_COMPLETE;
	G_send_packet.data32[0] = quest_id;
	G_send_packet.length = 4;
	pClient->SendMsg(&G_send_packet);
}
