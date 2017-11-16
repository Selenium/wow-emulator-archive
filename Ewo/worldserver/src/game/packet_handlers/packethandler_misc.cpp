// Copyright (C) 2006 Team Evolution
#include "packethandler_misc.h"

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void unhandled_opcode(GameClient *pClient)
{
#ifdef _DEBUG
	LOG.outString ("WORLD: recieved unknown opcode 0x%.4X [%s]", G_recv_packet.opcode,LookupName(G_recv_packet.opcode, g_worldOpcodeNames));
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_PING(GameClient *pClient)
{
#ifdef _DEBUG
	LOG.outString ("WORLD: Recvd CMSG_PING Message");
#endif
	//G_send_packet.opcode = SMSG_PONG;
	//G_send_packet.length = 4; //strange but we did not receive data
	//G_send_packet.data32[0] = G_recv_packet.data32[0]; //sometimes this is wrong (so we send bad ping :P )
	G_recv_packet.opcode = SMSG_PONG; //send back what we received
	pClient->SendMsg(&G_recv_packet);
#ifdef _DEBUG
	LOG.outString ("WORLD: sent SMSG_PONG Message");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_CANCEL_TRADE(GameClient *pClient)
{
#ifdef _DEBUG
	LOG.outString ("WORLD: Dumping CMSG_CANCEL_TRADE");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_MSG_QUERY_NEXT_MAIL_TIME(GameClient *pClient)
{
#ifdef _DEBUG
	LOG.outString ("WORLD: Dumping MSG_QUERY_NEXT_MAIL_TIME");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_NEXT_CINEMATIC_CAMERA(GameClient *pClient)
{
#ifdef _DEBUG
	LOG.outString ("WORLD: Dumping CMSG_NEXT_CINEMATIC_CAMERA");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_COMPLETE_CINEMATIC(GameClient *pClient)
{
#ifdef _DEBUG
	LOG.outString ("WORLD: Dumping CMSG_COMPLETE_CINEMATIC");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_CREATURE_QUERY(GameClient *pClient)
{
	uint32 object_type;
	creature *cur_cr;
	//first int is the entry
	object_type=G_recv_packet.data32[2];
	cur_cr=(creature*)G_recv_packet.data32[1];
	if(object_type & HIGHGUID_UNIT)
	{
		G_send_packet.opcode = SMSG_CREATURE_QUERY_RESPONSE;
		G_send_packet.data32[0]=G_recv_packet.data32[0]; //send back the entry
		memcpy(&G_send_packet.data[4],cur_cr->name,strlen(cur_cr->name)+1);
		G_send_packet.length = 4 + strlen(cur_cr->name) + 1;
		G_send_packet.data[G_send_packet.length++]=0;
		G_send_packet.data[G_send_packet.length++]=0;
		G_send_packet.data[G_send_packet.length++]=0;
		memcpy(&G_send_packet.data[G_send_packet.length],cur_cr->static_data->guild,strlen(cur_cr->static_data->guild)+1);
		G_send_packet.length += strlen(cur_cr->static_data->guild) + 1;
		*(uint32*)&G_send_packet.data[G_send_packet.length]=cur_cr->data32[UNIT_FIELD_FLAGS];
		G_send_packet.length +=4;
		*(uint32*)&G_send_packet.data[G_send_packet.length]=cur_cr->static_data->type;
		G_send_packet.length +=4;
		*(uint32*)&G_send_packet.data[G_send_packet.length]=cur_cr->static_data->family;
		G_send_packet.length +=4;
		*(uint32*)&G_send_packet.data[G_send_packet.length]=cur_cr->static_data->elite; //rank
		G_send_packet.length +=4;
		*(uint32*)&G_send_packet.data[G_send_packet.length]=0; //unk1
		G_send_packet.length +=4;
		*(uint32*)&G_send_packet.data[G_send_packet.length]=0; //unk2
		G_send_packet.length +=4;
		*(uint32*)&G_send_packet.data[G_send_packet.length]=cur_cr->data32[UNIT_FIELD_DISPLAYID];
		G_send_packet.length +=4;
		*(uint16*)&G_send_packet.data[G_send_packet.length]=cur_cr->flags1 & CREATURE_FLAG_CIVILIAN;
		G_send_packet.length +=2;
		*(uint32*)&G_send_packet.data[G_send_packet.length]=0x00003F80;//unk1
		G_send_packet.length +=4;
		*(uint32*)&G_send_packet.data[G_send_packet.length]=0x00013F80;//unk2
		G_send_packet.length +=4;
		pClient->SendMsg(&G_send_packet);
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: Sent SMSG_CREATURE_QUERY_RESPONSE.");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_GAMEOBJECT_QUERY(GameClient *pClient)
{
	uint32 object_entry;
//				gameobject_instance *cur_go;
//				cur_go=(gameobject_instance*)G_recv_packet.data32[2];
	//first int is the entry
	object_entry=G_recv_packet.data32[0];
//printf("received a query search for item entry %u and name %s",object_entry,G_gameobject_prototypes[object_entry]->name);
	if(object_entry < G_max_gameobjects && G_gameobject_prototypes[object_entry]!=NULL)
	{
		G_send_packet.opcode = SMSG_GAMEOBJECT_QUERY_RESPONSE;
		G_send_packet.data32[0]=G_recv_packet.data32[0]; //send back the entry
		G_send_packet.data32[1]=G_gameobject_prototypes[object_entry]->data32[GAMEOBJECT_TYPE_ID];
		G_send_packet.data32[2]=G_gameobject_prototypes[object_entry]->data32[GAMEOBJECT_DISPLAYID];
		memcpy(&G_send_packet.data[12],G_gameobject_prototypes[object_entry]->name,strlen(G_gameobject_prototypes[object_entry]->name)+1);
		G_send_packet.length = 12 + strlen(G_gameobject_prototypes[object_entry]->name);
		*(uint32*)&G_send_packet.data[G_send_packet.length]=0;
		G_send_packet.length += 4;
		*(uint32*)&G_send_packet.data[G_send_packet.length]=G_gameobject_prototypes[object_entry]->sound[0];
		G_send_packet.length +=4;
		*(uint32*)&G_send_packet.data[G_send_packet.length]=G_gameobject_prototypes[object_entry]->sound[1];
		G_send_packet.length +=4;
		*(uint32*)&G_send_packet.data[G_send_packet.length]=G_gameobject_prototypes[object_entry]->sound[2];
		G_send_packet.length +=4;
		*(uint32*)&G_send_packet.data[G_send_packet.length]=G_gameobject_prototypes[object_entry]->sound[3];
		G_send_packet.length +=4;
		*(uint32*)&G_send_packet.data[G_send_packet.length]=G_gameobject_prototypes[object_entry]->sound[4];
		G_send_packet.length +=4;
		*(uint32*)&G_send_packet.data[G_send_packet.length]=G_gameobject_prototypes[object_entry]->sound[5];
		G_send_packet.length +=4;
		*(uint32*)&G_send_packet.data[G_send_packet.length]=G_gameobject_prototypes[object_entry]->sound[6];
		G_send_packet.length +=4;
		*(uint32*)&G_send_packet.data[G_send_packet.length]=G_gameobject_prototypes[object_entry]->sound[7];
		G_send_packet.length +=4;
		*(uint32*)&G_send_packet.data[G_send_packet.length]=G_gameobject_prototypes[object_entry]->sound[8];
		G_send_packet.length +=4;
		*(uint32*)&G_send_packet.data[G_send_packet.length]=G_gameobject_prototypes[object_entry]->sound[9];
		G_send_packet.length +=4;
//		*(uint32*)&G_send_packet.data[G_send_packet.length]=0;//unk1
//		G_send_packet.length +=4;
		memset(&G_send_packet.data[G_send_packet.length],0,sizeof(uint32)*14+2);
		G_send_packet.length +=sizeof(uint32)*14+2;
		pClient->SendMsg(&G_send_packet);
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: Sent SMSG_GAMEOBJECT_QUERY_RESPONSE.");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_QUERY_TIME(GameClient *pClient)
{
	G_send_packet.opcode = SMSG_QUERY_TIME_RESPONSE;
	G_send_packet.data32[0] = (uint32)time(NULL);
	G_send_packet.length = 4;
	pClient->SendMsg(&G_send_packet);
#ifdef _DEBUG
	LOG.outString ("WORLD: Sent CMSG_QUERY_TIME.");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_ZONEUPDATE(GameClient *pClient)
{
	Character	*cc_char=pClient->mCurrentChar;
	uint32 new_zone_id,xp,ind1,ind2;
	Area_Node *area_itr;
	new_zone_id = G_recv_packet.data32[0];
	//save new zone_id
	cc_char->zone_id = new_zone_id;
	//remove resting flag
	cc_char->flag_clr(PLAYER_FLAGS, PLAYER_FLAG_RESTING);
	//get the area id if there is such
	area_itr = G_maps[cc_char->map_id]->area_list.first;
	while(area_itr && !(cc_char->pos_x>=area_itr->value->min_x && cc_char->pos_x<=area_itr->value->max_x && cc_char->pos_y>=area_itr->value->min_y && cc_char->pos_y<=area_itr->value->max_y))
		area_itr = area_itr->next;
	if(area_itr==NULL)return; //sorry didn't find the area
	//check if this is a new area
	//printf("discovered area with id : %u\n",rea_itr->value->id);
	ind1 = area_itr->value->explore_flag/32;
	ind2 = (uint32)(1<<(area_itr->value->explore_flag % 32));
	if(!cc_char->flag_is(PLAYER_EXPLORED_ZONES_1 + ind1,ind2))
	{
		//set flag to not receive any more xp from this zone
		cc_char->flag_set(PLAYER_EXPLORED_ZONES_1 + ind1,ind2);
		//let client know that we discowered this zone
		xp = cc_char->data32[UNIT_FIELD_LEVEL]*10 + 45;
		cc_char->xp_modify(0,xp,1);
		G_send_packet.opcode = SMSG_EXPLORATION_EXPERIENCE;
		P_SMSG_EXPLORATION_EXPERIENCE *packet=(P_SMSG_EXPLORATION_EXPERIENCE *)G_send_packet.data;
		packet->zone_id = new_zone_id;
		packet->xp = xp;
		G_send_packet.length = sizeof(P_SMSG_EXPLORATION_EXPERIENCE);
		pClient->SendMsg(&G_send_packet);
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_ZONEUPDATE");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_ITEM_QUERY_SINGLE(GameClient *pClient)
{
	Item	*cur_item=NULL;
	uint8	delme=0;
	//0 - entry or id. 
	//!!id is not always item id. More like owner id wich is in many cases the item(not always)
	//1 - guid low
	//2 - guid high
	if(G_recv_packet.data32[0]<G_max_item_id && G_item_prototypes[G_recv_packet.data32[0]]!=NULL)
	{
		cur_item = G_item_prototypes[G_recv_packet.data32[0]];
		goto GOT_ITEM_TO_MAKE_QUERY;
	}
	//this part will probably work only in current version
	if((G_recv_packet.data32[2] & HIGHGUID_OBJECT_TYPE_MASK)==HIGHGUID_ITEM)
	{
		cur_item = (Item*)G_recv_packet.data32[1];
		goto GOT_ITEM_TO_MAKE_QUERY;
	}
	if((G_recv_packet.data32[2] & HIGHGUID_OBJECT_TYPE_MASK)==HIGHGUID_UNIT)
	{
		//it is very probably a random item if we got here. Let's check if we have it
		creature *owner=(creature*)G_recv_packet.data32[1];
		uint32	i;
		for(i=0;i<MAX_RANDOM_LOOTS_FOR_OBJECT;i++)
			if(owner->loots[i] && owner->loots[i]->item_data32[ITEM_ID]==G_recv_packet.data32[0])
			{
				cur_item = owner->loots[i];
				goto GOT_ITEM_TO_MAKE_QUERY;
			}
		//maybe it's a vendor selling a random item
		creature_sell_item_node *itr;
		if(owner->sell_item_list)
		{
			itr = owner->sell_item_list->first;
			while(itr)
			{
				if(itr->dinamic_item && itr->dinamic_item->item_data32[ITEM_ID]==G_recv_packet.data32[0])
				{
					cur_item = itr->dinamic_item;
					goto GOT_ITEM_TO_MAKE_QUERY;
				}
				itr = itr->next;
			}
		}
	}
	//it's probably a random item.
	uint32 mod_id = (uint16)(G_recv_packet.data32[0] >> 16);
	uint32 item_id = (uint16)(G_recv_packet.data32[0]);
	if(G_max_item_mods >= mod_id && mod_id!=0 && G_item_mods[item_id] && item_id<G_max_item_id && G_item_prototypes[item_id]!=NULL)
	{
		//mod exists, we can reproduce item
		cur_item = G_Object_Pool.Get_fast_New_item();
		cur_item->create_from_template(G_item_prototypes[item_id]);
		cur_item->apply_item_mod(mod_id);
		delme = 1;
		goto GOT_ITEM_TO_MAKE_QUERY;
	}
	else
	{
		printf("!!!omg item not found with mod %u item id %u, asker object type %u\n",mod_id,item_id,G_recv_packet.data32[2]);
		return;
	}
	return;
GOT_ITEM_TO_MAKE_QUERY:
	cur_item->msg_item_query_single(pClient);
	if(delme)
		G_Object_Pool.Release_item(cur_item);
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_ITEM_QUERY_SINGLE");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_MSG_CORPSE_QUERY(GameClient *pClient)
{
	Character	*cc_char=pClient->mCurrentChar;
	if((cc_char->state1 & PLAYER_STATE_CORPSE) && cc_char->pcorpse)
		cc_char->msg_corpse_location();
	//printf("char health %f, corpse %d,state dead %d , state corpse %d, corpse pos %f\n",cc_char->health,cc_char->pcorpse,(cc_char->state1 & PLAYER_STATE_DEAD),(cc_char->state1 & PLAYER_STATE_CORPSE),cc_char->corpse_x);
#ifdef _DEBUG
	LOG.outString ("WORLD: handle MSG_CORPSE_QUERY");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_SWAP_INV_ITEM(GameClient *pClient)
{
	Character	*cc_char=pClient->mCurrentChar;
	uint8 src_slot = G_recv_packet.data[0];
	uint8 dst_slot = G_recv_packet.data[1];
	Item	*src_item;
	Item	*dst_item;
	src_item = (Item*)cc_char->data32[PLAYER_FIELD_INV_SLOT_HEAD+src_slot*2];
	dst_item = (Item*)cc_char->data32[PLAYER_FIELD_INV_SLOT_HEAD+dst_slot*2];
	//check if we are trying to stack same item
	if(dst_item && src_item->item_data32[ITEM_ID]==dst_item->item_data32[ITEM_ID] && src_item->data32[OBJECT_FIELD_ENTRY]==dst_item->data32[OBJECT_FIELD_ENTRY])
	{
		uint32 can_store_count=dst_item->item_data32[ITEM_STACK_MAX] - dst_item->data32[ITEM_FIELD_STACK_COUNT];
		if(can_store_count >= src_item->data32[ITEM_FIELD_STACK_COUNT])
		{
			dst_item->data32[ITEM_FIELD_STACK_COUNT] += src_item->data32[ITEM_FIELD_STACK_COUNT];
			dst_item->send_create_item(pClient);
			cc_char->rem_item(src_slot);
			G_Object_Pool.Release_item(src_item);//this item has been added to the other one
		}
		else cc_char->msg_inv_change_result(src_item,dst_item,INV_ERR_ITEM_CANT_STACK);
	}
	else
	{
		//printf("receved swap item opcode. src %d,dst %d, next 2 %d, %d\n",src_slot,dst_slot,G_recv_packet.data[2],G_recv_packet.data[3]);
		//printf("swap items. src %d,dst %d, next 2 %d, %d\n",(uint32)src_item,(uint32)dst_item);
		cc_char->rem_item(src_slot,0,1);
		cc_char->rem_item(dst_slot,0,1);
		cc_char->add_item(src_item,dst_slot,0,1); //atleast src item should exist if there is no destination
		cc_char->add_item(dst_item,src_slot,0,1);
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_SWAP_INV_ITEM");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_SWAP_ITEM(GameClient *pClient)
{
	Character	*cc_char=pClient->mCurrentChar;
	//4 byte
	//0 dst_bag_number. Bag 1 has number 19
	//1 dst_slot 
	//2 src bag number 
	//3 src slot
	Item *src_item,*dst_item,*src_bag,*dst_bag;
	uint8 src_bag_nr,dst_bag_nr;
	uint8 src_slot,dst_slot;
	dst_bag_nr = G_recv_packet.data[0];
	dst_slot = G_recv_packet.data[1];
	src_bag_nr = G_recv_packet.data[2];
	src_slot = G_recv_packet.data[3];
	//printf("swap item src slot %d,scr bag slot %d, dst slot %d, dst bag slot %d\n",src_slot,src_bag_nr,dst_slot,dst_bag_nr);
	if(IS_BAG_SLOT(src_bag_nr))
	{
		src_bag = (Item*)cc_char->data32[PLAYER_FIELD_INV_SLOT_HEAD+src_bag_nr*2];
		src_item = (Item*)src_bag->data32[CONTAINER_FIELD_SLOT_1+src_slot*2];
	}
	else src_item = (Item*)cc_char->data32[PLAYER_FIELD_INV_SLOT_HEAD+src_slot*2];
	if(IS_BAG_SLOT(dst_bag_nr))
	{
		dst_bag = (Item*)cc_char->data32[PLAYER_FIELD_INV_SLOT_HEAD+dst_bag_nr*2];
		dst_item = (Item*)dst_bag->data32[CONTAINER_FIELD_SLOT_1+dst_slot*2];
	}
	else dst_item = (Item*)cc_char->data32[PLAYER_FIELD_INV_SLOT_HEAD+dst_slot*2];
	//check if we are trying to stack same item
	if(dst_item && src_item->item_data32[ITEM_ID]==dst_item->item_data32[ITEM_ID] && src_item->data32[OBJECT_FIELD_ENTRY]==dst_item->data32[OBJECT_FIELD_ENTRY])
	{
		//!! client expects to swap items with or without stacking
		uint32 can_store_count=dst_item->item_data32[ITEM_STACK_MAX] - dst_item->data32[ITEM_FIELD_STACK_COUNT];
		if(can_store_count >= src_item->data32[ITEM_FIELD_STACK_COUNT])
		{
			src_item->data32[ITEM_FIELD_STACK_COUNT] += dst_item->data32[ITEM_FIELD_STACK_COUNT];
			src_item->send_create_item(pClient);
			cc_char->rem_item(src_slot,src_bag_nr,1);
			cc_char->rem_item(dst_slot,dst_bag_nr,1);
			cc_char->add_item(src_item,dst_slot,dst_bag_nr,1);
			G_Object_Pool.Release_item(dst_item); //this item has been added to the other one
			dst_item = NULL;
		}
		else cc_char->msg_inv_change_result(src_item,dst_item,INV_ERR_ITEM_CANT_STACK);
	}
	else
	{
		//printf("receved swap item opcode. src %d,dst %d, next 2 %d, %d\n",src_slot,dst_slot,G_recv_packet.data[2],G_recv_packet.data[3]);
		//printf("swap items. src %d,dst %d, next 2 %d, %d\n",(uint32)src_item,(uint32)dst_item);
		src_item = cc_char->rem_item(src_slot,src_bag_nr,1);
		dst_item = cc_char->rem_item(dst_slot,dst_bag_nr,1);
		cc_char->add_item(src_item,dst_slot,dst_bag_nr,1);
		cc_char->add_item(dst_item,src_slot,src_bag_nr,1);
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_SWAP_ITEM");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_SPLIT_ITEM(GameClient *pClient)
{
	Character	*cc_char=pClient->mCurrentChar;
	uint8 src_bag_nr = G_recv_packet.data[0];
	uint8 src_slot = G_recv_packet.data[1];
	uint8 dst_bag_nr = G_recv_packet.data[2];
	uint8 dst_slot = G_recv_packet.data[3];
	uint8 dst_count = G_recv_packet.data[4];//or left count
	Item	*src_item,*src_bag;
	Item	*dst_item,*dst_bag;
	if(IS_BAG_SLOT(src_bag_nr))
	{
		src_bag = (Item*)cc_char->data32[PLAYER_FIELD_INV_SLOT_HEAD+src_bag_nr*2];
		src_item = (Item*)src_bag->data32[CONTAINER_FIELD_SLOT_1+src_slot*2];
	}
	else src_item = (Item*)cc_char->data32[PLAYER_FIELD_INV_SLOT_HEAD+src_slot*2];
	if(IS_BAG_SLOT(dst_bag_nr))
	{
		dst_bag = (Item*)cc_char->data32[PLAYER_FIELD_INV_SLOT_HEAD+dst_bag_nr*2];
		dst_item = (Item*)dst_bag->data32[CONTAINER_FIELD_SLOT_1+dst_slot*2];
	}
	else dst_item = (Item*)cc_char->data32[PLAYER_FIELD_INV_SLOT_HEAD+dst_slot*2];
	//check if we are stacking items
	if(dst_item && src_item->item_data32[ITEM_ID]==dst_item->item_data32[ITEM_ID])
	{
		uint32 can_store_count=dst_item->item_data32[ITEM_STACK_MAX] - dst_item->data32[ITEM_FIELD_STACK_COUNT];
		//we can store the required amount
//!!! i have no idea why but client will gray item if it is in a bag.Maybe he expects a validation packet
		if(can_store_count >= dst_count)
		{
			//note that src item stackcount will not be 0 when we receive split!
			uint32 t;
			t = dst_item->data32[ITEM_FIELD_STACK_COUNT];
			dst_item->data32[ITEM_FIELD_STACK_COUNT] = src_item->data32[ITEM_FIELD_STACK_COUNT] - dst_count;
			dst_item->send_create_item(pClient);
			src_item->data32[ITEM_FIELD_STACK_COUNT] = t + dst_count;
			src_item->send_create_item(pClient);
			cc_char->rem_item(src_slot,src_bag_nr,1);
			cc_char->rem_item(dst_slot,dst_bag_nr,1);
			cc_char->add_item(src_item,dst_slot,dst_bag_nr,1);
			cc_char->add_item(dst_item,src_slot,src_bag_nr,1);
		}
		else 
		{
			//new item should have maxed stack , old item the remaining
			src_item->data32[ITEM_FIELD_STACK_COUNT] = src_item->item_data32[ITEM_STACK_MAX];
			src_item->send_create_item(pClient);
			dst_item->data32[ITEM_FIELD_STACK_COUNT] = dst_count - can_store_count;
			dst_item->send_create_item(pClient);
			cc_char->rem_item(src_slot,src_bag_nr,1);
			cc_char->rem_item(dst_slot,dst_bag_nr,1);
			cc_char->add_item(src_item,dst_slot,dst_bag_nr,1);
			cc_char->add_item(dst_item,src_slot,src_bag_nr,1);
//			cc_char->msg_inv_change_result(src_item,dst_item,INV_ERR_OK);
//			cc_char->msg_inv_change_result(src_item,dst_item,INV_ERR_ITEM_CANT_STACK);
		}
	}
	else
	{
		//if we got here it means we have to create a new item of the same type to have the give stackcount
		dst_item = G_Object_Pool.Get_fast_New_item();
		dst_item->create_from_template(src_item);
		/*						dst_item->data32[ITEM_FIELD_STACK_COUNT] = src_item->data32[ITEM_FIELD_STACK_COUNT] - dst_count;
		dst_item->send_create_item(pClient);
		src_item->data32[ITEM_FIELD_STACK_COUNT] = dst_count;
		src_item->send_create_item(pClient);
		cc_char->rem_item(src_slot,src_bag_nr,1);
		cc_char->add_item(src_item,dst_slot,dst_bag_nr,1);
		cc_char->add_item(dst_item,src_slot,src_bag_nr,1);*/
		dst_item->data32[ITEM_FIELD_STACK_COUNT] = dst_count;
		dst_item->send_create_item(pClient);
		src_item->data32[ITEM_FIELD_STACK_COUNT] -= dst_count;
		src_item->send_create_item(pClient);
		cc_char->add_item(dst_item,dst_slot,dst_bag_nr,1);
		//						cc_char->msg_inv_change_result(src_item,dst_item,INV_ERR_OK);
		//						cc_char->msg_inv_change_result(src_item,src_bag,INV_ERR_OK);
		//						cc_char->add_item(dst_item,src_slot,src_bag_nr,1);
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_SPLIT_ITEM");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_RECLAIM_CORPSE(GameClient *pClient)
{
	//will receive the corpse guid full
	Character	*cc_char=pClient->mCurrentChar;
	if(cc_char->pcorpse)
		cc_char->on_char_resurect(1);
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_RECLAIM_CORPSE");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_USE_ITEM(GameClient *pClient)
{
	Character	*cc_char=pClient->mCurrentChar;
	uint8 bag_index=G_recv_packet.data[0];
	uint8 slot=G_recv_packet.data[1];
	uint8 spells=0,consume_item=1;
	Item *cur_item;
	if(IS_BAG_SLOT(bag_index))
	{
		Item *cur_bag=(Item*)cc_char->data32[PLAYER_FIELD_INV_SLOT_HEAD+bag_index*2];
		cur_item=(Item*)cur_bag->data32[CONTAINER_FIELD_SLOT_1+slot*2];
	}
	else cur_item=(Item*)cc_char->data32[PLAYER_FIELD_INV_SLOT_HEAD+slot*2];
	if((cc_char->state1 & (PLAYER_STATE_PREPARE_SPELL | PLAYER_STATE_CAST_SPELL)) && cc_char->cur_spell.prototype->cast_time!=0)
	{
		cc_char->cur_spell.cancel_cast();
		cc_char->state1 &=~(PLAYER_STATE_PREPARE_SPELL | PLAYER_STATE_CAST_SPELL);
	}
	cc_char->spell_queue_len=0;

	//we cast each spell on the item
	for(int i=0;i<5*6;i+=6)
	{
		uint32 spell_id=cur_item->item_data32[ITEM_SPELL_ID+i];
/*printf("examin spell %u \n",spell_id);
if(spell_id && G_spell_info[spell_id])
printf("spell exists %d\n",spell_id);
if(cur_item->item_data32[ITEM_SPELL_TRIGGER+i]==SPELLTRIGGER_TYPE_ON_USE)
printf("spell is triggered %u\n",cur_item->item_data32[ITEM_SPELL_TRIGGER+i]);
if((cur_item->data32[ITEM_FIELD_SPELL_CHARGES+i]>0 || cur_item->data32[ITEM_FIELD_SPELL_CHARGES+i]==-1))
printf("spell has enough charges\n");/**/
//else printf("spell does NOT have enough charges %u\n",cur_item->data32[ITEM_FIELD_SPELL_CHARGES+i]);
		if(spell_id && G_spell_info[spell_id] && cur_item->item_data32[ITEM_SPELL_TRIGGER+i]==SPELLTRIGGER_TYPE_ON_USE && (cur_item->data32[ITEM_FIELD_SPELL_CHARGES+i]>0 || cur_item->data32[ITEM_FIELD_SPELL_CHARGES+i]==-1))
		{
			//lookup spell prototype and see if we require sit stand
			if(G_spell_info[spell_id]->aura_interrupt_flags & 262144)
			{
				//check if we are in combat we do not sit
				if(cc_char->state1 & PLAYER_STATE_IN_COMBAT)
				{
					G_send_packet.opcode = SMSG_INVENTORY_CHANGE_FAILURE;
					G_send_packet.data[0] = INV_ERR_CANT_DO_IN_COMBAT;
					*(uint64*)&G_send_packet.data[1] = cur_item->getGUID();
					*(uint64*)&G_send_packet.data[9] = 0;
					G_send_packet.data[17] = 0;
					G_send_packet.length = 18;
					pClient->SendMsg(&G_send_packet);
					return;
				}
				else
				{
					//set stand state to sit (don't care if we are already sitting)
					cc_char->set_stand_state(STANDSTATE_SIT);
					//									//remove all before used eating auras. Current spell is set to not stackable
					//									cc_char->affect_list.remove_auras_that_reqire_sit();
				}
			}
			else cc_char->set_stand_state(STANDSTATE_STAND);
			spells++;
			if(spells==1)
			{
				cc_char->cur_spell.item_caster_guid = cur_item->getGUID();
				cc_char->cur_spell.init(spell_id,cc_char->pos_x,cc_char->pos_y,cc_char->orientation,cc_char->map_id);
				//we should prepare data so in the next char update, the spell will start casting
				cc_char->cur_spell.read_targets_from_src(&G_recv_packet.data[3]);
				//start casting the spell
				cc_char->cur_spell.msg_spell_start_cast();
				cc_char->state1 &=~PLAYER_STATE_MOVED_SINCE_LAST_UPDATE; //remove "moved" flag
				cc_char->spell_cooldowns.add(spell_id,cur_item->item_data32[ITEM_SPELL_COOLDOWN+i]);//if it is greater then spell cooldown then will owerwrite it 
				cc_char->start_cast();
//printf("registering spell to cast now %u\n",spell_id);
			}
			//queue spell for casting
			else  if(cc_char->spell_queue_len < CHAR_SPELL_QUEUE_MAXLEN)
			{
				cc_char->spell_queue_len++;
//printf("inserting spell into queue slot %u ,id %u\n",cc_char->spell_queue_len,spell_id);
				cc_char->spell_queue[cc_char->spell_queue_len] = spell_id;
			}
			//printf("t1 = %u, t2 = %u, t3 = %u, t4 = %u \n",cc_char->cur_spell.target_player1,cc_char->cur_spell.target_player2,cc_char->cur_spell.target_creature,cc_char->cur_spell.target_object,cc_char->cur_spell.target_item);
			//if it is consumable then decrease stack count
			if(cur_item->data32[ITEM_FIELD_SPELL_CHARGES+i]==-1)
			{
				if(cur_item->item_data32[ITEM_CLASS] != ITEM_CLASS_CONSUMABLE)
					consume_item=0;
			}
			else if(cur_item->data32[ITEM_FIELD_SPELL_CHARGES+i]>1)
			{
				cur_item->data32[ITEM_FIELD_SPELL_CHARGES+i]-=1;
				consume_item=0;
			}
			//								cur_item->SetUInt32Value(ITEM_SPELL_CHARGES+i,cur_item->item_data32[ITEM_SPELL_CHARGES+i]-1)
		}//end if we cast the spell on use
	}//end for
	//if we managed to cast a spell then we can remove stack
	if(spells!=0)
	{
		//printf("casted item spell\n");
		if(cur_item->item_data32[ITEM_CLASS] == ITEM_CLASS_CONSUMABLE && consume_item)
		{
			if(cur_item->data32[ITEM_FIELD_STACK_COUNT]==1)
			{
				cc_char->rem_item(slot);
				G_Object_Pool.Release_item(cur_item);
				cur_item = NULL;
				return;
			}
			else 
			{
				cur_item->data32[ITEM_FIELD_STACK_COUNT] -= 1;
				//reset spell charges
				for(int i=0;i<5*6;i+=6)
					cur_item->data32[ITEM_FIELD_SPELL_CHARGES+i]=cur_item->item_data32[ITEM_SPELL_CHARGES + i];
			}
		}
		//update item if we casted spell for it
		cur_item->send_create_item(pClient);
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_USE_ITEM");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_DESTROYITEM(GameClient *pClient)
{
	Character	*cc_char=pClient->mCurrentChar;
	uint8 slot=G_recv_packet.data[1];
	Item *cur_item=cc_char->get_item(G_recv_packet.data[1],G_recv_packet.data[0]);
	if(!cur_item)
		return;
	if(cc_char->quests_started.can_destroy_item(cur_item->item_data32[ITEM_ID]))
	{
		cc_char->rem_item(slot);
		//cc_char->quests_started.on_rem_item(cur_item->item_data32[ITEM_ID],cur_item->data32[ITEM_FIELD_STACK_COUNT]);
		G_Object_Pool.Release_item(cur_item);
	}
	else
	{
		WORLDSERVER.send_message("Can't delete item that is required for active quest,abandon quest first",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,cc_char,NULL);
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_DESTROYITEM");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_LOOT(GameClient *pClient)
{
	//				if(G_recv_packet.data32[1] & HIGHGUID_UNIT)
	//					((creature*)(G_recv_packet.data32[0]))->msg_loot_list(pClient);
	//loot items are generated on creature death
	uint32		loop_itr,i;
	uint32		data_shift;
	creature	*target_cr=NULL;
	Item		**cur_loot_list;
	uint8		*cur_loot_item_count;
	Character	*cc_char=pClient->mCurrentChar;
	uint32		creature_id;
	if(G_recv_packet.data32[1] & HIGHGUID_UNIT)
	{
		creature *target_cr=(creature*)(G_recv_packet.data32[0]);
		*(uint32*)&G_send_packet.data[9] = target_cr->loot_money;
		cur_loot_list = target_cr->loots;
		cur_loot_item_count = target_cr->loot_item_count;
		creature_id = target_cr->data32[OBJECT_FIELD_ENTRY];
	}
	else if(G_recv_packet.data32[1] & HIGHGUID_GAMEOBJECT)
	{
		//					*(uint32*)&G_send_packet.data[9] = target_cr->loot_money;
	}
	G_send_packet.opcode = SMSG_LOOT_RESPONSE;
	G_send_packet.data32[0] = G_recv_packet.data32[0];
	G_send_packet.data32[1] = G_recv_packet.data32[1];
	G_send_packet.data[8] = 0x01;
	//				*(uint32*)&G_send_packet.data[9] = target_cr->loot_money;
	G_send_packet.data[13] = 0;
	data_shift = 14;
	for(loop_itr=0;loop_itr<MAX_LOOTS_FOR_OBJECT;loop_itr++)
		if(cur_loot_list[loop_itr]!=NULL)
		{
			//printf("adding new loot item %u\n",cur_item_id);
			G_send_packet.data[13]++;
			//						G_send_packet.data[data_shift] = G_send_packet.data[13]; //index
			G_send_packet.data[data_shift] = loop_itr; //index
			*(uint32*)&G_send_packet.data[data_shift+1] = cur_loot_list[loop_itr]->item_data32[ITEM_ID];
			*(uint32*)&G_send_packet.data[data_shift+5] = cur_loot_item_count[loop_itr]; //ammount
			*(uint32*)&G_send_packet.data[data_shift+9] = cur_loot_list[loop_itr]->item_data32[ITEM_DISPLAY_INFO_ID];
			*(uint32*)&G_send_packet.data[data_shift+13] = 0; //this seems to be sime kind of timestamp that increases with 0x01000000 from 1 loot block to another :)
			*(uint32*)&G_send_packet.data[data_shift+17] = 0;
			G_send_packet.data[data_shift+21] = 0;
			data_shift += 22;
		}
	//if this is not the creature we last looted then we can generate quest items for it
	if((uint32)(cc_char->looted_object_guid) != G_recv_packet.data32[0])
		cc_char->genrate_quest_loot(creature_id);
	//add quest required items if not added 
	Quest_instance_Node *itr=cc_char->quests_started.first;
	for(i=1;i<cc_char->quest_loot_item_ids[0];i++)
		if(cc_char->quest_loot_item_ids[i]!=0)
		{
//printf("found quest %u which requires item id %u, remaining %u\n",itr->value.id,G_quest_prototypes[itr->value.id]->obj_item_id[i],itr->value.obj_items_remaining[i]);
			G_send_packet.data[13]++;
			G_send_packet.data[data_shift] = MAX_LOOTS_FOR_OBJECT+i; //client will send this nuber when we are looting a creature
			*(uint32*)&G_send_packet.data[data_shift+1] = cc_char->quest_loot_item_ids[i];
			*(uint32*)&G_send_packet.data[data_shift+5] = 1; //ammount
			*(uint32*)&G_send_packet.data[data_shift+9] = G_item_prototypes[cc_char->quest_loot_item_ids[i]]->item_data32[ITEM_DISPLAY_INFO_ID];
			G_send_packet.data[data_shift+13] = 0;
			*(uint32*)&G_send_packet.data[data_shift+14] = 0; //random property id / enchantment ?
			*(uint32*)&G_send_packet.data[data_shift+18] = 0; //random property id / enchantment ?
			data_shift += 22;
		}
	G_send_packet.length = data_shift;
	pClient->SendMsg(&G_send_packet);
	cc_char->looted_object_guid = G_recv_packet.data64[0];
#ifdef _DEBUG
		LOG.outString ("WORLD: handle CMSG_LOOT");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_LOOT_MONEY(GameClient *pClient)
{
	Character	*cc_char=pClient->mCurrentChar;
	if(((uint32)(cc_char->looted_object_guid>>32)) & HIGHGUID_UNIT)
	{
		cc_char->SetUInt32Value(PLAYER_FIELD_COINAGE,cc_char->data32[PLAYER_FIELD_COINAGE]+((creature*)cc_char->looted_object_guid)->loot_money);
		((creature*)cc_char->looted_object_guid)->loot_money = 0;
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_LOOT_MONEY");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_AUTOSTORE_LOOT_ITEM(GameClient *pClient)
{
	//first and only byte represents the loot slot
	Character	*cc_char=pClient->mCurrentChar;
	uint8		loot_from_slot=G_recv_packet.data[0];
	uint32		item_id;//because autostore might delete item
	//printf("trying to loot from slot %u\n",loot_from_slot);
	if(((uint32)(cc_char->looted_object_guid>>32)) & HIGHGUID_UNIT)
	{
		Item *new_item=G_Object_Pool.Get_fast_New_item();
		if(loot_from_slot<MAX_LOOTS_FOR_OBJECT)
		{
			new_item->create_from_template(((creature*)cc_char->looted_object_guid)->loots[loot_from_slot]);
			new_item->data32[ITEM_FIELD_STACK_COUNT]=((creature*)cc_char->looted_object_guid)->loot_item_count[loot_from_slot];
		}
		else
		{
			//we got a quest item here
			uint32 quest_slot=loot_from_slot-MAX_LOOTS_FOR_OBJECT;
			uint32	item_id = cc_char->quest_loot_item_ids[quest_slot]; //slot is stored in 8 bits
//printf("trying to loot a quest item with id %u\n",item_id);
			new_item->create_from_template(G_item_prototypes[item_id]);
			new_item->data32[ITEM_FIELD_STACK_COUNT]=1;
		}
		item_id = new_item->item_data32[ITEM_ID];
		//duplicate item and store the copy only.!!this function can destroy the item
		uint8 res=cc_char->auto_store_item(new_item);
		//printf("autostore returned %u\n",res);
		if(res>0)
		{
			G_send_packet.opcode = SMSG_LOOT_REMOVED;
			G_send_packet.data[0] = loot_from_slot; //or lootslot + 1 ?
			G_send_packet.length = 1;
			pClient->SendMsg(&G_send_packet);
			G_send_packet.opcode = SMSG_ITEM_PUSH_RESULT;
			G_send_packet.data32[0] = cc_char->getGUIDL();
			G_send_packet.data32[1] = cc_char->getGUIDH();
			G_send_packet.data32[2] = 0;
			G_send_packet.data32[3] = 0;
			G_send_packet.data32[4] = 1;
			G_send_packet.data[20] = 0xFF;
			*(uint32*)&G_send_packet.data[21] = item_id;
			*(uint64*)&G_send_packet.data[25] = 0; 
			G_send_packet.length = 33;
			pClient->SendMsg(&G_send_packet);
			if(loot_from_slot<MAX_LOOTS_FOR_OBJECT)
			{
				//remove item from creature
				((creature*)cc_char->looted_object_guid)->loots[loot_from_slot]=NULL;
				//check if it is still lottable and set flag if not
				((creature*)cc_char->looted_object_guid)->is_still_lootable();
			}
			else 
			{
				cc_char->quests_started.on_add_item(item_id,1);
				cc_char->quest_loot_item_ids[loot_from_slot-MAX_LOOTS_FOR_OBJECT] = 0;
			}
		}
		else 
		{
			cc_char->msg_inv_change_result(NULL,NULL,INV_ERR_INVENTORY_FULL);
			G_Object_Pool.Release_item(new_item);
		}
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_AUTOSTORE_LOOT_ITEM");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_AUTOSTORE_BAG_ITEM(GameClient *pClient)
{
	Character	*cc_char=pClient->mCurrentChar;
	uint8 src_bag_nr = G_recv_packet.data[0];
	uint8 src_slot = G_recv_packet.data[1];
	uint8 dst_bag_nr = G_recv_packet.data[2];
	Item *src_bag,*src_item;
	if(IS_BAG_SLOT(G_recv_packet.data[0]))
	{
		src_bag = (Item*)cc_char->data32[PLAYER_FIELD_INV_SLOT_HEAD+src_bag_nr*2];
		src_item = (Item*)src_bag->data32[CONTAINER_FIELD_SLOT_1+src_slot*2];
	}
	else src_item = (Item*)cc_char->data32[PLAYER_FIELD_INV_SLOT_HEAD+src_slot*2];
	if(!cc_char->auto_store_item_in_bag(src_item,dst_bag_nr,1))
		if(!cc_char->auto_store_item_in_bag(src_item,dst_bag_nr,0))
		{
			cc_char->msg_inv_change_result(src_item,NULL,INV_ERR_INVENTORY_FULL);
			return;
		}
		//if we got here it means we succesfully added the item
		cc_char->rem_item(src_slot,src_bag_nr);
#ifdef _DEBUG
		LOG.outString ("WORLD: handle CMSG_AUTOSTORE_BAG_ITEM");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_SPIRIT_HEALER_ACTIVATE(GameClient *pClient)
{
	//we received the spirit healer guid
	Character	*cc_char=pClient->mCurrentChar;
	//decrease item durability
	cc_char->force_durability_change(0.75);
	//revive char
	cc_char->on_char_resurect(0);
	//cast spell on self for resurection sickness
	cc_char->cur_spell.char_instant_nomana_cast(2146,-1);
#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_SPIRIT_HEALER_ACTIVATE");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_AUTOEQUIP_ITEM(GameClient *pClient)
{
	Character	*cc_char=pClient->mCurrentChar;
	//first byte is bag nr,second is slot number
	Item *src_item,*dest_item;
	uint32	dst_slot;
	//remove item from the bag
	src_item=cc_char->rem_item(G_recv_packet.data[1],G_recv_packet.data[0],1);
	dst_slot = 0xFF;
	switch(src_item->item_data32[ITEM_INVENTORY_TYPE])
	{
		case INVTYPE_HEAD:
		case INVTYPE_NECK:
		case INVTYPE_SHOULDERS:
		case INVTYPE_BODY:
		case INVTYPE_CHEST:
		case INVTYPE_WAIST:
		case INVTYPE_LEGS:
		case INVTYPE_FEET:
		case INVTYPE_WRISTS:
		case INVTYPE_HANDS:
			{
				dst_slot = src_item->item_data32[ITEM_INVENTORY_TYPE]-1;
			}break;
		case INVTYPE_ROBE:
			{
				dst_slot =  EQUIPMENT_SLOT_CHEST;
			}break;
		case INVTYPE_FINGER:
			{
				if(!cc_char->data32[PLAYER_FIELD_INV_SLOT_HEAD+2*EQUIPMENT_SLOT_FINGER1])
					dst_slot =  EQUIPMENT_SLOT_FINGER1;
				else if (!cc_char->data32[PLAYER_FIELD_INV_SLOT_HEAD+2*EQUIPMENT_SLOT_FINGER2])
					dst_slot =  EQUIPMENT_SLOT_FINGER1;
				else dst_slot =  EQUIPMENT_SLOT_FINGER1;
			}break;
		case INVTYPE_TRINKET:
			{
				if(!cc_char->data32[PLAYER_FIELD_INV_SLOT_HEAD+2*EQUIPMENT_SLOT_TRINKET1])
					dst_slot =  EQUIPMENT_SLOT_TRINKET1;
				else if (!cc_char->data32[PLAYER_FIELD_INV_SLOT_HEAD+2*EQUIPMENT_SLOT_TRINKET2])
					dst_slot =  EQUIPMENT_SLOT_TRINKET2;
				else dst_slot =  EQUIPMENT_SLOT_TRINKET1;
			}break;
		case INVTYPE_CLOAK:
			{
				dst_slot = EQUIPMENT_SLOT_BACK;
			}break;
		case INVTYPE_WEAPON:
			{
				if(!cc_char->data32[PLAYER_FIELD_INV_SLOT_HEAD+2*EQUIPMENT_SLOT_MAINHAND])
					dst_slot =  EQUIPMENT_SLOT_MAINHAND;
				else if (!cc_char->data32[PLAYER_FIELD_INV_SLOT_HEAD+2*EQUIPMENT_SLOT_OFFHAND])
					dst_slot =  EQUIPMENT_SLOT_OFFHAND;
				else dst_slot =  EQUIPMENT_SLOT_MAINHAND;
			}break;
		case INVTYPE_SHIELD:
		case INVTYPE_RANGED:
		case INVTYPE_TABARD:
			{
				dst_slot = src_item->item_data32[ITEM_INVENTORY_TYPE]+2;
			}break;
		case INVTYPE_TWOHAND_WEAPON:
		case INVTYPE_HOLDABLE:
		case INVTYPE_WEAPONMAINHAND:
			{
				dst_slot = EQUIPMENT_SLOT_MAINHAND;
			}break;
		case INVTYPE_WEAPONOFFHAND:
			{
				dst_slot = EQUIPMENT_SLOT_OFFHAND;
			}break;
		case INVTYPE_AMMO:
		case INVTYPE_THROWN:
		case INVTYPE_RANGEDRIGHT:
			{
				dst_slot = EQUIPMENT_SLOT_RANGED;
			}break;
		case INVTYPE_BAG:
			{
				for (uint8 i = INVENTORY_SLOT_BAG_START; i < INVENTORY_SLOT_BAG_END; i++)
				{
					if(!cc_char->data32[PLAYER_FIELD_INV_SLOT_HEAD+2*i])
					{
						dst_slot =  i;
						break;
					}
				}
			}break;
	}
	if(dst_slot!=0xFF)
	{
		dest_item=cc_char->rem_item(dst_slot,0xFF,1);
		cc_char->add_item(src_item,dst_slot,0xFF,1);
		cc_char->add_item(dest_item,G_recv_packet.data[1],G_recv_packet.data[0],1);
	}
	else
	{
		cc_char->add_item(src_item,G_recv_packet.data[1],G_recv_packet.data[0],1);
		G_send_packet.opcode = SMSG_INVENTORY_CHANGE_FAILURE;
		G_send_packet.data[0] = INV_ERR_ITEM_DOESNT_GO_TO_SLOT;
		*(uint64*)&G_send_packet.data[1] = src_item->getGUID();
		*(uint64*)&G_send_packet.data[9] = 0;
		G_send_packet.data[17] = 0;
		G_send_packet.length = 18;
		pClient->SendMsg(&G_send_packet);
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_AUTOEQUIP_ITEM");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_FORCE_WALK_SPEED_CHANGE_ACK(GameClient *pClient)
{
#ifdef _DEBUG
	LOG.outString ("WORLD: Dumping CMSG_FORCE_WALK_SPEED_CHANGE_ACK");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_LIST_INVENTORY(GameClient *pClient)
{
	creature *cur_vendor;
	cur_vendor=(creature *)G_recv_packet.data32[0];
	Character	*cc_char=pClient->mCurrentChar;
	//dump our buyback list to a vendor so later we can buy it back
	if(cc_char->last_vendor_used)
	{
		//clear buyback slot for current char (can't rebuy item that we sold to another merchant)
		uint32		i;
		for(i=0;i<24;i+=2)
			if(cc_char->data32[PLAYER_FIELD_VENDORBUYBACK_SLOT_1+i])
			{
				cc_char->last_vendor_used->sell_item_list->add_item_instance((Item*)(cc_char->data32[PLAYER_FIELD_VENDORBUYBACK_SLOT_1+i]));
				cc_char->SetUInt64Value(PLAYER_FIELD_VENDORBUYBACK_SLOT_1 + i,0);
				cc_char->SetUInt32Value(PLAYER_FIELD_BUYBACK_PRICE_1 + (i/2),0);
				cc_char->SetUInt32Value(PLAYER_FIELD_BUYBACK_TIMESTAMP_1 + (i/2),0);
			}
		cc_char->last_vendor_used = NULL;
	}
	cc_char->last_vendor_used = cur_vendor;
	cur_vendor->msg_vendor_sell_list(pClient);
	//if he is a travel merchant then he should stop 
//	if(cur_vendor->flags1 & CREATURE_FLAG_WAYPOINT_WALKER && cur_vendor->state1 && CREATURE_STATE_PATROL_MOVE)
	if(cur_vendor->flags1 & CREATURE_FLAG_WAYPOINT_WALKER)
	{
		cur_vendor->state1 |= CREATURE_STATE_VENDOR_SELL;
		cur_vendor->atimer1 = G_cur_time_ms + 2000;
		cur_vendor->last_atacker_guid = cc_char->getGUID();
		cur_vendor->orientation = get_orientation(cur_vendor->pos_x,cur_vendor->pos_y,cc_char->pos_x,cc_char->pos_y);
		cur_vendor->pos_z = cc_char->pos_z+CREATURE_ROAM_LIFT_FROM_GROUND; //better chances that player has valid pos_z then creature
		cur_vendor->update_obj_pos(NULL);
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_LIST_INVENTORY");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_BUY_ITEM(GameClient *pClient)
{
	Character	*cc_char=pClient->mCurrentChar;
	creature	*vendor=(creature*)G_recv_packet.data32[0];
	uint32		item_id=G_recv_packet.data32[2];
	uint8		amount=G_recv_packet.data[13];
	uint8		slot=G_recv_packet.data[14];
	Item		*new_item;
	uint32		price;
	new_item=G_Object_Pool.Get_fast_New_item();
	if(item_id<G_max_item_id && G_item_prototypes[item_id])
		new_item->create_from_template(G_item_prototypes[item_id]);
	else
	{
		//this might be an item instance or a randomized item
		//we search for it on the vendor
		creature_sell_item_node *itr=vendor->sell_item_list->first;
		while(itr && itr->item_id!=item_id)
			itr = itr->next;
		if(itr && itr->dinamic_item)
			new_item->create_from_template(itr->dinamic_item);
		else
		{
			//if not found on vendor then we try to recreate it
			uint32 n_mod_id = (uint16)(item_id >> 16);
			uint32 n_item_id = (uint16)(item_id);
			if(G_max_item_mods >= n_mod_id && n_item_id<G_max_item_id && G_item_prototypes[n_item_id]!=NULL)
			{
				//mod exists, we can reproduce item
				new_item->create_from_template(G_item_prototypes[n_item_id]);
				new_item->apply_item_mod(n_mod_id);
			}
		}
	}
	price = new_item->item_data32[ITEM_PRICE_BUY]*amount; //need to store price because autostore might destroy item
	if(cc_char->data32[PLAYER_FIELD_COINAGE] < price)
	{
		G_send_packet.opcode = SMSG_BUY_FAILED;
		G_send_packet.data32[0] = G_recv_packet.data32[0]; //src guid
		G_send_packet.data32[1] = G_recv_packet.data32[1]; //src guid
		G_send_packet.data32[2] = item_id;
		G_send_packet.data[12] = VENDOR_BUY_ERR_NOT_ENOUGH_MONEY;
		G_send_packet.length = 13;
		pClient->SendMsg(&G_send_packet);
		G_Object_Pool.Release_item(new_item);
		return;
	} 
	if(new_item->item_data32[ITEM_STACK_MAX]==5)
		new_item->data32[ITEM_FIELD_STACK_COUNT] = 1;
	else if(new_item->item_data32[ITEM_STACK_MAX]==20)
		new_item->data32[ITEM_FIELD_STACK_COUNT] = 5;
	else new_item->data32[ITEM_FIELD_STACK_COUNT] = new_item->item_data32[ITEM_STACK_MAX];
	//!!auto store item might delete item on store=stack
	if(!cc_char->auto_store_item(new_item))
	{
		cc_char->msg_inv_change_result(new_item,NULL,INV_ERR_INVENTORY_FULL);
		//we were not able to add it to backpack
		G_Object_Pool.Release_item(new_item);
		return;
	}
	vendor->sell_item_list->sell(item_id,amount);//vendor sells item even if can't :)
	cc_char->SetUInt32Value(PLAYER_FIELD_COINAGE,cc_char->data32[PLAYER_FIELD_COINAGE]-price);
	G_send_packet.opcode = SMSG_BUY_ITEM;
	G_send_packet.data32[0] = G_recv_packet.data32[0]; //vendor guid
	G_send_packet.data32[1] = G_recv_packet.data32[1]; //vendor guid
	G_send_packet.data32[2] = item_id;
	G_send_packet.data32[3] = amount;
	G_send_packet.length = 16;
	pClient->SendMsg(&G_send_packet);
	vendor->msg_vendor_sell_list(pClient);
#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_BUY_ITEM");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_BUY_ITEM_IN_SLOT(GameClient *pClient)
{
	Character	*cc_char=pClient->mCurrentChar;
	creature	*vendor=(creature*)G_recv_packet.data32[0];
	uint32		item_id=G_recv_packet.data32[2];
	Item		*dst_bag;
	Character	*dst_char;
	uint8		slot=G_recv_packet.data[20];
	uint8		amount=G_recv_packet.data[21];
	Item		*new_item;
	uint8		container_slot=0xFF;
	uint32		i;

//	if(!vendor->sell_item_list->sell(item_id,amount))
//		goto VENDOR_SELL_ITEM;//in case they tried to cheat making the vendor sell stuff that he does not own (or just run out of them)
	if((G_recv_packet.data32[4] & HIGHGUID_PLAYER) && G_recv_packet.data32[3])
	{
		dst_char = (Character *)G_recv_packet.data32[3];
		if (dst_char->data32[PLAYER_FIELD_INV_SLOT_HEAD+slot*2]!=0)
			return; //slot is not empty...
	}
	else if((G_recv_packet.data32[4] & HIGHGUID_ITEM )&& G_recv_packet.data32[3])
	{
		dst_bag = (Item *)G_recv_packet.data32[3];
		if(dst_bag->data32[CONTAINER_FIELD_SLOT_1+slot*2]!=0)
			return;
		//find our bag on the char :). Incase we bought a charm we have to apply it's stats ...set owner
		for(i=PLAYER_FIELD_INV_SLOT_HEAD+INVENTORY_SLOT_BAG_1*2;i<PLAYER_FIELD_INV_SLOT_HEAD+INVENTORY_SLOT_BAG_END*2;i+=2)
			if(cc_char->data32[i]==G_recv_packet.data32[3])
			{
				container_slot = (i - PLAYER_FIELD_INV_SLOT_HEAD)/2;
				break;
			}
		if(container_slot==0xFF)
			return; //invalid container
	}
	else return; //there is no way to store this item
	new_item=G_Object_Pool.Get_fast_New_item();
	if(item_id<G_max_item_id && G_item_prototypes[item_id])
		new_item->create_from_template(G_item_prototypes[item_id]);
	else
	{
		//this might be an item instance or a randomized item
		//we search for it on the vendor
		creature_sell_item_node *itr=vendor->sell_item_list->first;
		while(itr && itr->item_id!=item_id)
			itr = itr->next;
		if(itr && itr->dinamic_item)
			new_item->create_from_template(itr->dinamic_item);
		else
		{
			//if not found on vendor then we try to recreate it
			uint32 n_mod_id = (uint16)(item_id >> 16);
			uint32 n_item_id = (uint16)(item_id);
			if(G_max_item_mods >= n_mod_id && n_item_id<G_max_item_id && G_item_prototypes[n_item_id]!=NULL)
			{
				//mod exists, we can reproduce item
				new_item->create_from_template(G_item_prototypes[n_item_id]);
				new_item->apply_item_mod(n_mod_id);
			}
		}
	}
	if(cc_char->data32[PLAYER_FIELD_COINAGE]<new_item->item_data32[ITEM_PRICE_BUY]*amount)
	{
		G_Object_Pool.Release_item(new_item);
		goto VENDOR_COULD_NOT_BUY_ITEM;
	}
	cc_char->SetUInt32Value(PLAYER_FIELD_COINAGE,cc_char->data32[PLAYER_FIELD_COINAGE]-new_item->item_data32[ITEM_PRICE_BUY]*amount);
	if(new_item->item_data32[ITEM_STACK_MAX]==5)
		new_item->data32[ITEM_FIELD_STACK_COUNT] = 1;
	else if(new_item->item_data32[ITEM_STACK_MAX]==20)
		new_item->data32[ITEM_FIELD_STACK_COUNT] = 5;
	else new_item->data32[ITEM_FIELD_STACK_COUNT] = new_item->item_data32[ITEM_STACK_MAX];
	cc_char->add_item(new_item,slot,container_slot,0);//set owner and apply stats
//VENDOR_SELL_ITEM:
	G_send_packet.opcode = SMSG_BUY_ITEM;
	G_send_packet.data32[0] = G_recv_packet.data32[0]; //src guid
	G_send_packet.data32[1] = G_recv_packet.data32[1]; //src guid
	G_send_packet.data32[2] = item_id;
	G_send_packet.data32[3] = amount;
	G_send_packet.length = 16;
	pClient->SendMsg(&G_send_packet);
	vendor->msg_vendor_sell_list(pClient);
	return;
VENDOR_COULD_NOT_BUY_ITEM:
	G_send_packet.opcode = SMSG_BUY_FAILED;
	G_send_packet.data32[0] = G_recv_packet.data32[0]; //src guid
	G_send_packet.data32[1] = G_recv_packet.data32[1]; //src guid
	G_send_packet.data32[2] = item_id;
	G_send_packet.data[12] = VENDOR_BUY_ERR_NOT_ENOUGH_MONEY;
	G_send_packet.length = 13;
	pClient->SendMsg(&G_send_packet);
#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_BUY_ITEM_IN_SLOT");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_SELL_ITEM(GameClient *pClient)
{

	Character	*cc_char=pClient->mCurrentChar;
	creature	*vendor=(creature*)G_recv_packet.data32[0];
	Item		*src_item=(Item*)G_recv_packet.data32[2],*buyback_item;
	uint8		amount=G_recv_packet.data[16];
	uint8		sell_err_code;
	uint32		i;

	if(!vendor)
	{
		sell_err_code = 0x03;
		goto PLAYER_COULD_NOT_SELL_ITEM;
	}
	if (!src_item)
	{
		sell_err_code = 0x01;
		goto PLAYER_COULD_NOT_SELL_ITEM;
	}
	if(src_item->item_data32[ITEM_PRICE_SELL]==0)
	{
		sell_err_code = 0x02;
		goto PLAYER_COULD_NOT_SELL_ITEM;
	}
	//check if we are selling all items or just a few
	if(amount==0)
		amount = src_item->data32[ITEM_FIELD_STACK_COUNT];
	cc_char->SetUInt32Value(PLAYER_FIELD_COINAGE,cc_char->data32[PLAYER_FIELD_COINAGE] + src_item->item_data32[ITEM_PRICE_SELL]*amount);
	//original item is kept to be buyback
	//we create a new item that is added to the vendor
	if(amount==src_item->data32[ITEM_FIELD_STACK_COUNT])
	{
		//find item on char and remove it
		cc_char->rem_item(src_item);
//		//add it to vendor. Vendor will copy this item!
//		vendor->sell_item_list->add_item_instance(src_item);
		buyback_item = src_item;
	}
	else
	{
		//change count for item
		src_item->data32[ITEM_FIELD_STACK_COUNT] -= amount;
		src_item->send_create_item(pClient);//update item for client
		//create new for buyback
		Item *new_item;
		new_item = G_Object_Pool.Get_fast_New_item();
		new_item->create_from_template(src_item);
		new_item->data32[ITEM_FIELD_STACK_COUNT] = amount;
		//add to vendor
//		vendor->sell_item_list->add_item_instance(new_item);
		buyback_item = new_item;
	}
	//add item to buyback slot
	for(i=0;i<24;i+=2)
		if(cc_char->data32[PLAYER_FIELD_VENDORBUYBACK_SLOT_1 + i]==0)
		{
			cc_char->SetUInt64Value(PLAYER_FIELD_VENDORBUYBACK_SLOT_1 + i,buyback_item->getGUID());
			cc_char->SetUInt32Value(PLAYER_FIELD_BUYBACK_PRICE_1 + (i/2),buyback_item->item_data32[ITEM_PRICE_SELL]*amount);
			cc_char->SetUInt32Value(PLAYER_FIELD_BUYBACK_TIMESTAMP_1 + (i/2),time(NULL));
			break;
		}
	if(i>=24 && buyback_item)
		G_Object_Pool.Release_item(buyback_item);//in case we could not add item to buyback slot
	sell_err_code = 0x0;
PLAYER_COULD_NOT_SELL_ITEM:
	G_send_packet.opcode = SMSG_SELL_ITEM;
	memcpy(G_send_packet.data,G_recv_packet.data,2*8); //the 2 guids
	G_send_packet.data[16] = sell_err_code;
	G_send_packet.length = 17;
	pClient->SendMsg(&G_send_packet);
	// Error Codes: 0x01 = Item not Found
	//              0x02 = Vendor doesnt want that item
	//              0x03 = Vendor doesnt like you ;P
	//              0x04 = You dont own that item
	//              0x05 = Ok
	//              0x06 = Only with empty Bags !?
#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_SELL_ITEM");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_BUYBACK_ITEM(GameClient *pClient)
{
	creature	*vendor = (creature*)G_recv_packet.data32[0];
	uint32		slot=G_recv_packet.data32[2];
	Character	*cc_char=pClient->mCurrentChar;
	Item		*cur_item=(Item*)(cc_char->data32[PLAYER_FIELD_INV_SLOT_HEAD + slot*2]);
	creature_sell_item_node *itr=vendor->sell_item_list->first;
	uint32 price;
	if(!cur_item)
		return;
	price = cur_item->item_data32[ITEM_PRICE_SELL]*cur_item->data32[ITEM_FIELD_STACK_COUNT];
	//check if we can afford buyback
	if(price>cc_char->data32[PLAYER_FIELD_COINAGE])
	{
		G_send_packet.opcode = SMSG_BUY_FAILED;
		G_send_packet.data32[0] = G_recv_packet.data32[0]; //src guid
		G_send_packet.data32[1] = G_recv_packet.data32[1]; //src guid
		G_send_packet.data32[2] = cur_item->item_data32[ITEM_ID];
		G_send_packet.data[12] = VENDOR_BUY_ERR_NOT_ENOUGH_MONEY;
		G_send_packet.length = 13;
		pClient->SendMsg(&G_send_packet);
	}
	//see if vendor has our item and remove from him. Usually he should has it. We don't care if he has it or not because buyback is stored at char
	vendor->sell_item_list->sell(cur_item->item_data32[ITEM_ID],cur_item->data32[ITEM_FIELD_STACK_COUNT]);
	if(cc_char->auto_store_item(cur_item))
	{
		cc_char->SetUInt32Value(PLAYER_FIELD_COINAGE,cc_char->data32[PLAYER_FIELD_COINAGE] - price);		//give money back
		//clear buybackslot
		uint32 buybackslot=slot - (PLAYER_FIELD_VENDORBUYBACK_SLOT_1 - PLAYER_FIELD_INV_SLOT_HEAD)/2;
//		cc_char->SetUInt64Value(PLAYER_FIELD_INV_SLOT_HEAD + slot*2,0);
		cc_char->SetUInt64Value(PLAYER_FIELD_VENDORBUYBACK_SLOT_1 + buybackslot*2,0);
		cc_char->SetUInt32Value(PLAYER_FIELD_BUYBACK_PRICE_1 + buybackslot,0);
		cc_char->SetUInt32Value(PLAYER_FIELD_BUYBACK_TIMESTAMP_1 + buybackslot,0);

		G_send_packet.opcode = SMSG_BUY_ITEM;
		G_send_packet.data32[0] = G_recv_packet.data32[0]; //src guid
		G_send_packet.data32[1] = G_recv_packet.data32[1]; //src guid
		G_send_packet.data32[2] = cur_item->item_data32[ITEM_ID];
		G_send_packet.data32[3] = cur_item->data32[ITEM_FIELD_STACK_COUNT];
		G_send_packet.length = 16;
		pClient->SendMsg(&G_send_packet);
//		vendor->msg_vendor_sell_list(pClient);
	}
	else cc_char->msg_inv_change_result(NULL,NULL,INV_ERR_INVENTORY_FULL);
#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_BUYBACK_ITEM");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_TRAINER_LIST(GameClient *pClient)
{
	creature *trainer=(creature*)G_recv_packet.data32[0];
	Character	*cc_char=pClient->mCurrentChar;
	if(trainer->static_data->train_class!=cc_char->Get_class())
	{
		G_send_packet.opcode = SMSG_GOSSIP_MESSAGE;
		G_send_packet.data32[0] = G_recv_packet.data32[0];
		G_send_packet.data32[1] = G_recv_packet.data32[1];
		G_send_packet.data32[2] = 3;
		G_send_packet.data32[3] = 0;
		G_send_packet.data32[4] = 0;
		G_send_packet.length = 20;
		pClient->SendMsg(&G_send_packet);
		goto THE_EXIT_OF_THIS_FUNCTION;
	}
	trainer->msg_trainer_sell_list(pClient);
THE_EXIT_OF_THIS_FUNCTION:
	cc_char=NULL; //need 1 more line before end of function :(
#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_TRAINER_LIST");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_NPC_TEXT_QUERY(GameClient *pClient)
{
	uint32		NPC_text_id=G_recv_packet.data32[0];
	Character	*cc_char=pClient->mCurrentChar;

	//we target the one we are talking to ;)
	cc_char->SetUInt64Value(UNIT_FIELD_TARGET,*(uint64*)&G_recv_packet.data32[1]);

	G_send_packet.opcode = SMSG_NPC_TEXT_UPDATE;
	G_send_packet.data32[0] = NPC_text_id;
	if(NPC_text_id < G_max_NPC_text && G_NPC_text[NPC_text_id])
	{
		G_send_packet.data32[1] = 0;
		strcpy((char*)&G_send_packet.data32[2], G_NPC_text[NPC_text_id][0].text_0);
		G_send_packet.length = 8 + strlen(G_NPC_text[NPC_text_id][0].text_0)+1;
/*		uint32 shift=4;
		for (int i=0; i<NPC_TEXT_TO_CHOOSE_FROM; i++)
		{
			*(float*)&G_send_packet.data[shift] = G_NPC_text[NPC_text_id][i].chance;
			shift +=4;
			strcpy((char*)&G_send_packet.data[shift],G_NPC_text[NPC_text_id][i].text_0);
			shift += strlen(G_NPC_text[NPC_text_id][i].text_0)+1;
			if(G_NPC_text[NPC_text_id][i].text_1)
			{
				strcpy((char*)&G_send_packet.data[shift],G_NPC_text[NPC_text_id][i].text_1);
				shift += strlen(G_NPC_text[NPC_text_id][i].text_1)+1;
			}
			else
			{
				strcpy((char*)&G_send_packet.data[shift],G_NPC_text[NPC_text_id][i].text_0);
				shift += strlen(G_NPC_text[NPC_text_id][i].text_0)+1;
			}
			*(uint32*)&G_send_packet.data[shift] = G_NPC_text[NPC_text_id][i].lang;
			shift += 4;
			for(int j=0;i<3;j++)
			{
				*(uint32*)&G_send_packet.data[shift] = G_NPC_text[NPC_text_id][i].emote_anim[j];
				shift += 4;
				*(uint32*)&G_send_packet.data[shift] = G_NPC_text[NPC_text_id][i].emote_delay[j];
				shift += 4;
			}
		}*/
	}
	else
	{
		G_send_packet.data32[1] = 0;
		strcpy((char*)&G_send_packet.data32[2],"Hi there, $N. How may I help you?");
		G_send_packet.length = 8 + strlen("Hi there, $N. How may I help you?")+1;
	}
	pClient->SendMsg(&G_send_packet);
#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_NPC_TEXT_QUERY");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_TRAINER_BUY_SPELL(GameClient *pClient)
{
	creature *trainer=(creature*)G_recv_packet.data32[0];
	if(!trainer)
		return;
	Character	*cc_char=pClient->mCurrentChar;
	uint32	spell_id=G_recv_packet.data32[2];
	uint32	spell_cost=0;
	creature_sell_spell_node *itr=trainer->static_data->sell_spell_list.first;
	//because of lag sometimes client send more then once learn a specific spell. So we need to check if we already know this
	if(cc_char->spellbook.find(spell_id))
		return;
	while(itr)
	{
		if(itr->cast_spell_id==spell_id)
		{
			spell_cost = itr->cost;
			break;
		}
		itr = itr->next;
	}
	//this should not happen because we sent him in red the spell so he could not have cliked on it anyway ;)
/*	if(cc_char->data32[PLAYER_FIELD_COINAGE]<spell_cost || spell_cost==0)
	{
		G_send_packet.opcode = SMSG_TRAINER_BUY_FAILED;
		G_send_packet.data32[0] = G_recv_packet.data32[0]; //src guid
		G_send_packet.data32[1] = G_recv_packet.data32[1]; //src guid
		G_send_packet.data32[2] = spell_id;
		G_send_packet.data[12] = VENDOR_BUY_ERR_NOT_ENOUGH_MONEY;
		G_send_packet.length = 13;
		pClient->SendMsg(&G_send_packet);
	}*/
	cc_char->SetUInt32Value(PLAYER_FIELD_COINAGE,cc_char->data32[PLAYER_FIELD_COINAGE] - spell_cost);		//give money back
	G_send_packet.opcode = SMSG_TRAINER_BUY_SUCCEEDED;
	G_send_packet.data32[0] = G_recv_packet.data32[0]; //src guid
	G_send_packet.data32[1] = G_recv_packet.data32[1]; //src guid
	G_send_packet.data32[2] = spell_id;
	G_send_packet.length = 12;
	pClient->SendMsg(&G_send_packet);
	//cast the bought spell that will treach us the spell we actualy were dreaming of
	cc_char->instant_spell.char_instant_nomana_cast(spell_id,-1);
//	//resend trainer list
//	trainer->msg_trainer_sell_list(pClient);
#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_TRAINER_BUY_SPELL");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_REPAIR_ITEM(GameClient *pClient)
{
	//vendor guid and item guid is received
//	creature *vendor=G_recv_packet.data32[0];
	Item		*target_item=(Item*)G_recv_packet.data32[2];
	Character	*cc_char=pClient->mCurrentChar;
	//i think these are some price factors when quality is the index
	//float		price_per_durability_when_quality[]={0,1,0.6,1,0.8,1,1,1.2,1.25,1.44,2.5,1.728,3,0,0};
	if(G_recv_packet.data32[2]==0 && G_recv_packet.data32[3]==0)
	{
		//this means we have to iterate through all avalable items and repair them all
	   for (uint32 i = PLAYER_FIELD_INV_SLOT_HEAD+0; i < PLAYER_FIELD_INV_SLOT_HEAD + EQUIPMENT_SLOT_END*2; i +=2)
		   if(cc_char->data32[i]!=0) 
		   {
			   target_item = (Item*)cc_char->data32[i];
				float price_per_unit;
				uint32 repair_price;
				uint32 units_have_to_repair = target_item->item_data32[ITEM_DURABILITY_MAX]-target_item->data32[ITEM_FIELD_DURABILITY];
				price_per_unit = (float)target_item->item_data32[ITEM_PRICE_BUY] / target_item->item_data32[ITEM_DURABILITY_MAX];
				repair_price = (uint32)(units_have_to_repair*price_per_unit);
				if(cc_char->data32[PLAYER_FIELD_COINAGE]<repair_price)
				{
					G_send_packet.opcode = SMSG_BUY_FAILED;
					G_send_packet.data32[0] = G_recv_packet.data32[0]; //src guid
					G_send_packet.data32[1] = G_recv_packet.data32[1]; //src guid
					G_send_packet.data32[2] = target_item->item_data32[ITEM_ID];
					G_send_packet.data[12] = VENDOR_BUY_ERR_NOT_ENOUGH_MONEY;
					G_send_packet.length = 13;
					pClient->SendMsg(&G_send_packet);
					break;
				}
				else
				{
					cc_char->SetUInt32Value(PLAYER_FIELD_COINAGE,cc_char->data32[PLAYER_FIELD_COINAGE]-repair_price);
					if(target_item->data32[ITEM_FIELD_DURABILITY]==0)
					{
						target_item->data32[ITEM_FIELD_DURABILITY] = target_item->item_data32[ITEM_DURABILITY_MAX];
						cc_char->add_item_stats(target_item);
					}
					else target_item->data32[ITEM_FIELD_DURABILITY] = target_item->item_data32[ITEM_DURABILITY_MAX];
					target_item->send_create_item(pClient);
				}
		   }
	}
	else
	{
		float price_per_unit;
		uint32 repair_price;
		uint32 units_have_to_repair = target_item->item_data32[ITEM_DURABILITY_MAX]-target_item->data32[ITEM_FIELD_DURABILITY];
		price_per_unit = (float)target_item->item_data32[ITEM_PRICE_BUY] / target_item->item_data32[ITEM_DURABILITY_MAX];
		repair_price = (uint32)(units_have_to_repair*price_per_unit);
		if(cc_char->data32[PLAYER_FIELD_COINAGE]<repair_price)
		{
			G_send_packet.opcode = SMSG_BUY_FAILED;
			G_send_packet.data32[0] = G_recv_packet.data32[0]; //src guid
			G_send_packet.data32[1] = G_recv_packet.data32[1]; //src guid
			G_send_packet.data32[2] = target_item->item_data32[ITEM_ID];
			G_send_packet.data[12] = VENDOR_BUY_ERR_NOT_ENOUGH_MONEY;
			G_send_packet.length = 13;
			pClient->SendMsg(&G_send_packet);
		}
		else
		{
			cc_char->SetUInt32Value(PLAYER_FIELD_COINAGE,cc_char->data32[PLAYER_FIELD_COINAGE]-repair_price);
			if(target_item->data32[ITEM_FIELD_DURABILITY]==0)
			{
				target_item->data32[ITEM_FIELD_DURABILITY] = target_item->item_data32[ITEM_DURABILITY_MAX];
				//check if item is equiped
			    for (uint32 i = PLAYER_FIELD_INV_SLOT_HEAD+0; i < PLAYER_FIELD_INV_SLOT_HEAD + EQUIPMENT_SLOT_END*2; i +=2)
					if(cc_char->data32[i]==(uint32)target_item) 
						cc_char->add_item_stats(target_item);
			}
			else target_item->data32[ITEM_FIELD_DURABILITY] = target_item->item_data32[ITEM_DURABILITY_MAX];
			target_item->send_create_item(pClient);
		}
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_REPAIR_ITEM");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//when a questgiver is created the client will ask the server what mark should he put on the NPC (available/finished ...)
void handle_CMSG_QUESTGIVER_STATUS_QUERY(GameClient *pClient)
{
	creature	*quest_giver=(creature*)G_recv_packet.data32[0];
//printf("\t questgiver name is %s \n",quest_giver->name);
	G_send_packet.opcode = SMSG_QUESTGIVER_STATUS;
	G_send_packet.data32[0] = G_recv_packet.data32[0];
	G_send_packet.data32[1] = G_recv_packet.data32[1];
	//if we need to talk to this person then he is a quest target and mark him
	if(pClient->mCurrentChar->quests_started.need_to_talk_to_NPC(quest_giver->data32[OBJECT_FIELD_ENTRY]))
		G_send_packet.data32[2] = QMGR_QUEST_FINISHED;//so we will be able to talk to the damn npc
	else G_send_packet.data32[2] = quest_giver->quest_giver_status(pClient->mCurrentChar);
	G_send_packet.length = 12;
	pClient->SendMsg(&G_send_packet);

	if(G_send_packet.data32[2] != QMGR_QUEST_FINISHED)
		quest_giver->mark_creature_on_minimap(pClient,0);
	else quest_giver->mark_creature_on_minimap(pClient,1);

#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_QUESTGIVER_STATUS_QUERY");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_QUESTGIVER_HELLO(GameClient *pClient)
{
	creature	*questgiver=(creature*)G_recv_packet.data32[0];
	Character	*cc_char=pClient->mCurrentChar;
	//check if we are supposed to talk to this person. If so then we complete that quest
	Quest_instance_Node *talkitr=cc_char->quests_started.first;
	while(talkitr)
	{
        if(cc_char->quests_started.would_finish(talkitr,questgiver->data32[OBJECT_FIELD_ENTRY])==QMGR_QUEST_FINISHED)
		{
			msg_quest_finished_rewards(pClient,G_recv_packet.data64[0],talkitr->value.id);
#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_QUESTGIVER_HELLO and returned to direct revard list");
#endif		
			return;
		}
		talkitr = talkitr->next;
	}
	if(!questgiver->static_data->quests_list.first)
		return;
	questgiver->emote(EMOTE_ONESHOT_TALK);
	G_send_packet.opcode = SMSG_QUESTGIVER_QUEST_LIST;
	G_send_packet.data32[0] = G_recv_packet.data32[0];
	G_send_packet.data32[1] = G_recv_packet.data32[1];
	G_send_packet.data[8] = 0;//null terminated string containing hello msg
	*(uint32*)&G_send_packet.data[9] = 0;
	*(uint32*)&G_send_packet.data[13] = 0;
	G_send_packet.data[17] = 0; //available quest count
	Quest_id_Node *itr=questgiver->static_data->quests_list.first;
	uint32	shift=18;
	//make a list of available quests
	while(itr)
	{
		uint32 cur_quest_status = cc_char->quest_relation(itr->value);
		if(cur_quest_status==QMGR_QUEST_AVAILABLE || cur_quest_status==QMGR_QUEST_FINISHED)
		{
			G_send_packet.data[17]++;
			*(uint32*)&G_send_packet.data[shift] = itr->value;
			shift += 4;
			//for some starnge reason the codes seems to be reversed
//			if(cur_quest_status==QMGR_QUEST_FINISHED)
//				*(uint32*)&G_send_packet.data[shift] = QMGR_QUEST_NOT_FINISHED;
//			else if (cur_quest_status==QMGR_QUEST_NOT_FINISHED)
//				*(uint32*)&G_send_packet.data[shift] = QMGR_QUEST_FINISHED;
			*(uint32*)&G_send_packet.data[shift] = cur_quest_status;
//printf("sending on hello cur status %u\n",cur_quest_status);
			shift += 4;
			*(uint32*)&G_send_packet.data[shift] = 0;
			shift += 4;
			if(G_quest_prototypes[itr->value]->title_txt)
			{
				strcpy((char*)&G_send_packet.data[shift],G_quest_prototypes[itr->value]->title_txt);
				shift += strlen(G_quest_prototypes[itr->value]->title_txt)+1;
			}
			else
			{
				strcpy((char*)&G_send_packet.data[shift],"no title available");
				shift += strlen("no title available")+1;
			}
		}
		itr = itr->next;
	}
	G_send_packet.length = shift;
	pClient->SendMsg(&G_send_packet);
#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_QUESTGIVER_HELLO");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//this request is received when we create a quest giver object or when we take a quest and client asks us to update the questgivers
void handle_CMSG_QUESTGIVER_QUERY_QUEST(GameClient *pClient)
{
	//we received the questgiver and the quest id
	uint32 quest_id=G_recv_packet.data32[2];
//	if(quest_id>G_max_quest_id || !G_quest_prototypes[quest_id])
//		return;
	Character	*cc_char=pClient->mCurrentChar;
	//we have 3 cases here depending on quest status : start,not completed, completed
	uint32 cur_quest_status = cc_char->quest_relation(quest_id);
	if(cur_quest_status==QMGR_QUEST_AVAILABLE)
	{
		msg_quest_start_details(pClient,G_recv_packet.data64[0],quest_id);
//printf("available %u \n",quest_id);
	}
	//i will try to avoid this situation, because you can view at anytime your log
	else if(cur_quest_status==QMGR_QUEST_NOT_FINISHED)
	{
		msg_quest_not_finished_missing(pClient,G_recv_packet.data64[0],quest_id);
//printf("not finished\n");
	}
	else if(cur_quest_status==QMGR_QUEST_FINISHED)
	{
		msg_quest_finished_rewards(pClient,G_recv_packet.data64[0],quest_id);
//printf("finished\n");
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_QUESTGIVER_QUERY_QUEST");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_QUESTGIVER_ACCEPT_QUEST(GameClient *pClient)
{
	uint32 quest_id=G_recv_packet.data32[2];
	if(quest_id>G_max_quest_id || !G_quest_prototypes[quest_id])
		return;
	Character	*cc_char=pClient->mCurrentChar;
	//we have 3 cases here depending on quest status : start,not completed, completed
//	uint32 cur_quest_status = cc_char->quest_relation(quest_id);
//	if(cur_quest_status==QMGR_QUEST_AVAILABLE)
	if(cc_char->quests_started.add(quest_id)==0xFFFFFFFF)
	{
		G_send_packet.opcode = SMSG_QUESTLOG_FULL;
		G_send_packet.data32[0] = 0x01950200;//have no idea why this number but in all examples it was the same
		G_send_packet.length = 4;
		pClient->SendMsg(&G_send_packet);
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_QUESTGIVER_ACCEPT_QUEST");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_QUEST_QUERY(GameClient *pClient)
{
	uint32 quest_id=G_recv_packet.data32[0];
	if(quest_id>G_max_quest_id || G_quest_prototypes[quest_id]==NULL)
		return;
	Quest_template	*ptemplate = G_quest_prototypes[quest_id];
	uint32 i,len;
	G_send_packet.opcode = SMSG_QUEST_QUERY_RESPONSE;
	G_send_packet.data32[0] = quest_id;
	G_send_packet.data32[1] = ptemplate->req_lvl;
	G_send_packet.data32[2] = ptemplate->lvl;
	G_send_packet.data32[3] = ptemplate->zone_id;
	G_send_packet.data32[4] = ptemplate->q_type;
	G_send_packet.data32[5] = ptemplate->req_rep_faction;
	G_send_packet.data32[6] = ptemplate->req_rep_value;
	G_send_packet.data32[7] = 0;
	G_send_packet.data32[8] = 0;
	G_send_packet.data32[9] = 0;
	G_send_packet.data32[10] = ptemplate->next_quest_id;
	G_send_packet.data32[11] = ptemplate->rew_money;
	G_send_packet.data32[12] = ptemplate->rew_xp;
	G_send_packet.data32[13] = ptemplate->rew_teach_spell;
	G_send_packet.data32[14] = ptemplate->src_item_id;
	G_send_packet.data32[15] = 0;
	G_send_packet.data32[16] = ptemplate->s_flags;
	for(i=0;i<4;i++)
	{
		G_send_packet.data32[17+i*2] = ptemplate->rew_item_id[i];
		G_send_packet.data32[18+i*2] = ptemplate->rew_item_count[i];
	}
	for(i=0;i<6;i++)
	{
		G_send_packet.data32[25+i*2] = ptemplate->rew_opt_item_id[i];
		G_send_packet.data32[26+i*2] = ptemplate->rew_opt_item_count[i];
	}
	G_send_packet.data32[37] = ptemplate->point_map_id;
	G_send_packet.dataf[38] = ptemplate->point_x;
	G_send_packet.dataf[39] = ptemplate->point_y;
	G_send_packet.data32[40] = ptemplate->point_opt;
	//add uint32
	strcpy((char*)&G_send_packet.data[41*4],ptemplate->title_txt);
	len =41*4 + strlen(ptemplate->title_txt) + 1;
	strcpy((char*)&G_send_packet.data[len],ptemplate->objective_txt);
	len += strlen(ptemplate->objective_txt) + 1;
	strcpy((char*)&G_send_packet.data[len],ptemplate->details_txt);
	len += strlen(ptemplate->details_txt) + 1;
	strcpy((char*)&G_send_packet.data[len],ptemplate->end_txt);
	len += strlen(ptemplate->end_txt) + 1;
	for(i=0;i<4;i++)
	{
		*(uint32*)&G_send_packet.data[len] = ptemplate->obj_kill_id[i];
		len += 4;
		*(uint32*)&G_send_packet.data[len] = ptemplate->obj_kill_count[i];
		len += 4;
		*(uint32*)&G_send_packet.data[len] = ptemplate->obj_item_id[i];
		len += 4;
		*(uint32*)&G_send_packet.data[len] = ptemplate->obj_item_count[i];
		len += 4;
	}
	strcpy((char*)&G_send_packet.data[len],ptemplate->obj_text_1);
	len += strlen(ptemplate->obj_text_1) + 1;
	strcpy((char*)&G_send_packet.data[len],ptemplate->obj_text_2);
	len += strlen(ptemplate->obj_text_2) + 1;
	strcpy((char*)&G_send_packet.data[len],ptemplate->obj_text_3);
	len += strlen(ptemplate->obj_text_3) + 1;
	strcpy((char*)&G_send_packet.data[len],ptemplate->obj_text_4);
	len += strlen(ptemplate->obj_text_4) + 1;
	G_send_packet.length = len;
	pClient->SendMsg(&G_send_packet);
#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_QUEST_QUERY");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_QUESTGIVER_COMPLETE_QUEST(GameClient *pClient)
{
	msg_quest_finished_rewards(pClient,G_recv_packet.data64[0],G_recv_packet.data32[2]);
#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_QUESTGIVER_COMPLETE_QUEST");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_QUESTLOG_REMOVE_QUEST(GameClient *pClient)
{
	uint32		quest_slot = G_recv_packet.data[0];
	Character	*cc_char = pClient->mCurrentChar;
	cc_char->quests_started.del_slot(quest_slot);
    cc_char->SetUInt32Value(PLAYER_QUEST_LOG_1_1 + quest_slot*3, 0);
    cc_char->SetUInt32Value(PLAYER_QUEST_LOG_1_1 + quest_slot*3 + 1, 0);
    cc_char->SetUInt32Value(PLAYER_QUEST_LOG_1_1 + quest_slot*3 + 2, 0);
#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_QUESTLOG_REMOVE_QUEST");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_QUESTGIVER_CHOOSE_REWARD(GameClient *pClient)
{
	uint32		quest_id=G_recv_packet.data32[2];
	uint32		rew_slot=G_recv_packet.data32[3];
	Character	*cc_char = pClient->mCurrentChar;
	uint32		quest_slot;
	Quest_instance	*acrive_quest_info;
	uint32		i,len;
	Item		*new_item;
	Quest_template	*ptemplate=G_quest_prototypes[quest_id];
	acrive_quest_info = cc_char->quests_started.get_quest_info(quest_id);
	if(!acrive_quest_info)
		return;
	//first we try to add all reward to player and only after that we finish the quest
	for(i=acrive_quest_info->static_item_rewards_added;i<4;i++)
		if(ptemplate->rew_item_id[i])
		{
			new_item = G_Object_Pool.Get_fast_New_item();
			new_item->create_from_template(G_item_prototypes[ptemplate->rew_item_id[i]]);
			if(!cc_char->auto_store_item(new_item))
			{
				G_Object_Pool.Release_item(new_item);
				cc_char->msg_inv_change_result(NULL,NULL,INV_ERR_INVENTORY_FULL);
				acrive_quest_info->static_item_rewards_added = i;
#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_QUESTGIVER_CHOOSE_REWARD(static items could not be added)");
#endif
				return;//we could not finish the quest
			}
		}
	if(ptemplate->rew_opt_item_id[rew_slot])
	{
		new_item = G_Object_Pool.Get_fast_New_item();
		new_item->create_from_template(G_item_prototypes[ptemplate->rew_opt_item_id[rew_slot]]);
		if(!cc_char->auto_store_item(new_item))
		{
			G_Object_Pool.Release_item(new_item);
			cc_char->msg_inv_change_result(NULL,NULL,INV_ERR_INVENTORY_FULL);
#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_QUESTGIVER_CHOOSE_REWARD(opt item could not be added)");
#endif
			return;//we could not finish the quest
		}
	}
	for(i=0;i<4;i++)
		if(ptemplate->obj_item_id[i])
			cc_char->rem_item_id(ptemplate->obj_item_id[i],ptemplate->obj_item_count[i]);
	//send finish quest packets in case we gave the rewards
	G_send_packet.opcode = SMSG_QUESTUPDATE_COMPLETE;
	G_send_packet.data32[0] = quest_id;
	G_send_packet.length = 4;
	pClient->SendMsg(&G_send_packet);
	G_send_packet.opcode = SMSG_QUESTGIVER_QUEST_COMPLETE;
	G_send_packet.data32[0] = quest_id;
	G_send_packet.data32[1] = 3;
	if ( pClient->mCurrentChar->data32[UNIT_FIELD_LEVEL] < 60 )
    {
		G_send_packet.data32[2] = ptemplate->rew_xp;
		G_send_packet.data32[3] = ptemplate->rew_xp_or_money;
    }
    else
    {
		G_send_packet.data32[2] = 0;
		G_send_packet.data32[3] = ptemplate->rew_xp_or_money + ptemplate->rew_xp;
    }
	//add xp to char too
	G_send_packet.data32[4] = 0; //reward items
	len = 5;
	for(i=0;i<6;i++)
		if(ptemplate->rew_item_id[i]!=0)
		{
			G_send_packet.data32[4] += 1;//item count
			G_send_packet.data32[len] = ptemplate->rew_item_id[i];
			G_send_packet.data32[len+1] = ptemplate->rew_item_count[i];
			len += 2;
		}
	G_send_packet.length = len*4;
	pClient->SendMsg(&G_send_packet);
	//finish the quest (in char lists)
	quest_slot = cc_char->quests_started.del_id(quest_id);
    cc_char->SetUInt32Value(PLAYER_QUEST_LOG_1_1 + quest_slot*3, 0);
    cc_char->SetUInt32Value(PLAYER_QUEST_LOG_1_1 + quest_slot*3 + 1, 0);
    cc_char->SetUInt32Value(PLAYER_QUEST_LOG_1_1 + quest_slot*3 + 2, 0);
	cc_char->quests_finished.add(quest_id);
	//give rewards
	cc_char->SetUInt32Value(PLAYER_FIELD_COINAGE,cc_char->data32[PLAYER_FIELD_COINAGE]+ptemplate->rew_money);
	if ( pClient->mCurrentChar->data32[UNIT_FIELD_LEVEL] == 60 )
		cc_char->SetUInt32Value(PLAYER_FIELD_COINAGE,cc_char->data32[PLAYER_FIELD_COINAGE]+ptemplate->rew_xp);
	else cc_char->xp_modify(0,ptemplate->rew_xp,1);
	((creature*)(G_recv_packet.data32[0]))->emote(EMOTE_ONESHOT_APPLAUD);
	if(ptemplate->next_quest_id)
		msg_quest_start_details(pClient,G_recv_packet.data64[0],ptemplate->next_quest_id);
#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_QUESTGIVER_CHOOSE_REWARD");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_CANCEL_CAST(GameClient *pClient)
{
	//received uint32 is spell id
	Character	*cc_char = pClient->mCurrentChar;
	cc_char->cur_spell.cancel_cast(G_recv_packet.data32[0]);
	//remove states
	cc_char->state1 &=~(PLAYER_STATE_PREPARE_SPELL | PLAYER_STATE_CAST_SPELL);
	cc_char->spell_queue_len = 0;
#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_CANCEL_CAST");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_FORCE_WALK_SPEED_CHANGE_ACK1(GameClient *pClient)
{
#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_TRAINER_LIST");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_MOVE_UNLOCK_MOVEMENT_ACK(GameClient *pClient)
{
#ifdef _DEBUG
	LOG.outString ("WORLD: Dumping CMSG_MOVE_UNLOCK_MOVEMENT_ACK");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_CANCEL_AURA(GameClient *pClient)
{
	//we received the spell id
	Character	*cc_char = pClient->mCurrentChar;
	cc_char->affect_list->cancel_spell(G_recv_packet.data32[0]);
#ifdef _DEBUG
	LOG.outString ("WORLD: Handle CMSG_CANCEL_AURA");
#endif
}
