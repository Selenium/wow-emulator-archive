// Copyright (C) 2006 Team Evolution
#include "item.h"

Item::Item()
{
	data32 = (uint32 *)malloc(ITEM_END*4);
    ASSERT(data32);
	item_data32 = (uint32 *)malloc(ITEM_FIELDS_END*4);
    ASSERT(item_data32);
	state1 = 0; //item basic states will be kept even if refurbished (template is template and will remain one :) )
	Refurbish();
}

//can be called by object pool to bring item object into a state where it can be reused
void Item::Refurbish()
{
    memset(data32,0,ITEM_END*4);
    memset(item_data32,0,ITEM_FIELDS_END*4);
	data32[OBJECT_FIELD_TYPE] = OBJECT_TYPE_ITEM;
	set_guid();
//	update_mask.SetCount(ITEM_END);
//	update_mask.Clear();
}

Item::~Item()
{
   free(data32);
   free(item_data32);
}
/*
void Item::SetUInt32Value (uint32 index, uint32 value)
{
	if(data32[ index ] != value)
	{
		data32[ index ] = value;
		update_mask.SetBit( index );
	}
}

void Item::SetUInt64Value (uint32 index, uint64 value)
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
*/
//this will create item from a template. Template can be any already existing item 2
// - make sure to set timer when to destroy this item
void Item::create_from_template(Item *p_template)
{
	memcpy(data32,p_template->data32,ITEM_END*4);
	memcpy(item_data32,p_template->item_data32,ITEM_FIELDS_END*4);
//	created_at = time(NULL);
	on_load_from_template();
}

//becouse we use data that are generated dinamicaly, this has to be refreshed each time we load static data
void Item::on_load_from_template()
{
//	if(data32[OBJECT_FIELD_TYPE] == OBJECT_TYPE_CONTAINER) 
	if((item_data32[ITEM_CLASS] == ITEM_CLASS_CONTAINER) ||
		(item_data32[ITEM_CLASS] == ITEM_CLASS_QUIVER) ||
		(item_data32[ITEM_SLOTS] > 0))
		convert_to_conatiner();
	else set_guid();
}

//use this function when the item changes owner, like item trade,or when putting item into bag
//if owner changes then we can resend item create data
void Item::on_change_owner(uint64 owner_guid,Character *char_owner,uint32 pmap_id,float px,float py)
{
	uint8 resend_info=0;
	//data changed for item then we resend it
	if((*(uint64*)&data32[ITEM_FIELD_OWNER]!=owner_guid || *((uint64*)&data32[ITEM_FIELD_CONTAINED]) != (uint64)owner_guid) && char_owner)
		resend_info=1;
	*((uint64*)&data32[ITEM_FIELD_CONTAINED]) = (uint64)owner_guid;
	*((uint64*)(&data32[ITEM_FIELD_OWNER])) = (uint64)owner_guid;
//	SetUInt64Value(ITEM_FIELD_CONTAINED,owner_guid);
//	SetUInt64Value(ITEM_FIELD_OWNER,owner_guid);
	if(resend_info)
	{
		if(px!=0 && py!=0)
		{
			//in this case we equiped the item on us. Let's make sure this is created for others too
			G_temp_compressed_packet.clear();
			build_create_block(&G_temp_compressed_packet,1); //actualy we are not building this packet for self only :(
			G_maps[pmap_id]->send_instant_msg_to_block(px,py,G_temp_compressed_packet.build_packet(),NULL);
		}
		else send_create_item(char_owner->pClient);
	}/**/
}

void Item::build_create_block(Compressed_Update_Block *packet,uint32 target_self)
{
	if(data32[OBJECT_FIELD_TYPE] == OBJECT_TYPE_CONTAINER)
	{
		build_create_block_container(packet,target_self);
		return;
	}
	#define ALWAYS_SET_TO_ZERO_FIELDS_COUNT 18*4
//	#define ITEM_UPDATEMASK_BLOCKCOUNT (ITEM_END+31)/32
	#define ITEM_UPDATEMASK_BLOCKCOUNT 2
	#define ITEM_CREATEBLOCK_START_UPDATEMASK 17 
//	#define ITEM_CREATEBLOCK_START_DINAMIC_DATA (17 + ITEM_UPDATEMASK_BLOCKCOUNT*4)
	#define ITEM_CREATEBLOCK_START_DINAMIC_DATA 25
	uint8 *data=packet->get_next_pointer();
	uint32 *packet32;
	uint32 pos;
	uint32 i;
    data[0]=UPDATETYPE_CREATE_OBJECT; //type of the block
    data[1]=0xFF; //type of the block
	*(uint32*)(data+2)=getGUIDL(); //guid
	*(uint32*)(data+6)=getGUIDH(); //guid
	data[10]=TYPEID_ITEM; 
	data[11]=16;//flags1
	*(uint32*)(&data[12])=1;//flags2
	data[16]=ITEM_UPDATEMASK_BLOCKCOUNT;//masc values count
	G_item_update_mask.Clear();
	//set bits and add values to packet
	packet32 = (uint32*)&data[ITEM_CREATEBLOCK_START_DINAMIC_DATA];
	pos = 0;
	for( i=0; i<ITEM_END; i++)
		if(data32[i]!=0)
		{
			G_item_update_mask.SetBit(i);
			packet32[pos++] = data32[i];
		}
	//add bitmask to packet
	memcpy(&data[ITEM_CREATEBLOCK_START_UPDATEMASK],G_item_update_mask.GetMask(),ITEM_UPDATEMASK_BLOCKCOUNT*4);
	packet->add_virtual_packet(ITEM_CREATEBLOCK_START_DINAMIC_DATA+pos*4);
	#undef ITEM_CREATEBLOCK_START_UPDATEMASK
	#undef ALWAYS_SET_TO_ZERO_FIELDS_COUNT
	#undef ITEM_UPDATEMASK_BLOCKCOUNT
	#undef ITEM_CREATEBLOCK_START_DINAMIC_DATA
}

void Item::build_create_block_container(Compressed_Update_Block *packet,uint32 target_self)
{
	#define CONTAINER_UPDATEMASK_BLOCKCOUNT 5
	#define CONTAINER_CREATEBLOCK_START_UPDATEMASK 17
	#define CONTAINER_CREATEBLOCK_START_DINAMIC_DATA 37
	uint8 *data=packet->get_next_pointer();
	uint32 *packet32;
	uint32 pos;
	uint32 i;
    data[0]=UPDATETYPE_CREATE_OBJECT; //type of the block
    data[1]=0xFF; //type of the block
	*(uint32*)(data+2)=getGUIDL(); //guid
	*(uint32*)(data+6)=getGUIDH(); //guid
	data[10]=TYPEID_CONTAINER; 
	data[11]=16;//flags1
	*(uint32*)(&data[12])=1;//flags2
	data[16]=CONTAINER_UPDATEMASK_BLOCKCOUNT;//masc values count
	G_container_update_mask.Clear();
	//set bits and add values to packet
	data[82]=CONTAINER_UPDATEMASK_BLOCKCOUNT; //updatemask blockcount
	packet32 = (uint32*)&data[CONTAINER_CREATEBLOCK_START_DINAMIC_DATA];
	pos = 0;
	for( i=0; i<CONTAINER_END; i++)
		if(data32[i]!=0)
		{
			G_container_update_mask.SetBit(i);
			packet32[pos++] = data32[i];
		}
	//add bitmask to packet
	memcpy(&data[CONTAINER_CREATEBLOCK_START_UPDATEMASK],G_container_update_mask.GetMask(),CONTAINER_UPDATEMASK_BLOCKCOUNT*4);
	packet->add_virtual_packet(CONTAINER_CREATEBLOCK_START_DINAMIC_DATA+pos*4);
	#undef CONTAINER_CREATEBLOCK_START_UPDATEMASK
	#undef CONTAINER_UPDATEMASK_BLOCKCOUNT
	#undef CONTAINER_CREATEBLOCK_START_DINAMIC_DATA
}

//it's used instead of update function
//void Item::send_create_item(GameClient *pClient)
void Item::send_create_item(GameClient *pClient)
{
/*	G_temp_compressed_packet.clear();
	build_create_block(&G_temp_compressed_packet,1,0);
	//send updated item
	pClient->SendMsg(G_temp_compressed_packet.build_packet());*/
	build_create_block(&pClient->compressed_update,1); //add our update/create to our owner updateblock
}

void Item::convert_to_conatiner(uint8 is_template)
{
	if(is_template==0)
	{
		if(state1 & ITEM_STATE_CONVERTED_TO_CONTAINER)
			return;
		state1 |= ITEM_STATE_CONVERTED_TO_CONTAINER;
		data32 = (uint32*)realloc(data32,CONTAINER_END*4);
		ASSERT(data32);
		for(int i=CONTAINER_ALIGN_PAD;i<CONTAINER_END;i++)
			data32[i]=0;
//		update_mask.SetCount(CONTAINER_END);
//		update_mask.Clear();
	}
	data32[CONTAINER_FIELD_NUM_SLOTS]=item_data32[ITEM_SLOTS];
	data32[OBJECT_FIELD_TYPE] = OBJECT_TYPE_CONTAINER;
	set_guid();
//	on_load_from_template();
}

void Item::add_to_container(Item *p_item,uint8 slot)
{
	*(uint64*)&data32[CONTAINER_FIELD_SLOT_1+slot*2]=p_item->getGUID();
//	p_item->on_change_owner(getGUID(),(Character*)data32[ITEM_FIELD_OWNER]);
	p_item->on_change_owner(*(uint64*)&data32[ITEM_FIELD_OWNER],(Character*)data32[ITEM_FIELD_OWNER]);
//	p_item->data32[ITEM_FIELD_CONTAINED] = getGUIDL();//if we place item in bag then contained is bag
//	p_item->data32[ITEM_FIELD_CONTAINED+1] = getGUIDH();//if we place item in bag then contained is bag
	//update bag
	send_create_item(((Character*)data32[ITEM_FIELD_OWNER])->pClient);
}

Item *Item::rem_from_container(uint8 slot)
{
#ifdef _DEBUG
	if(slot*2>CONTAINER_END)
		return NULL;
#endif
	Item *ret=(Item*)data32[CONTAINER_FIELD_SLOT_1+slot*2];
	if(data32[CONTAINER_FIELD_SLOT_1+slot*2] != 0)
	{
		data32[CONTAINER_FIELD_SLOT_1+slot*2] = 0;
		send_create_item(((Character*)data32[ITEM_FIELD_OWNER])->pClient);
	}
	return ret;
}

void Item::add_enchantment(uint32 ench_id,uint32 time_remain,uint32 count,uint8 update_client)
{
	for(int i=9;i<30;i+=3)
		if(data32[ITEM_FIELD_ENCHANTMENT+i]==0)
		{
			data32[ITEM_FIELD_ENCHANTMENT+i]=ench_id;
			data32[ITEM_FIELD_ENCHANTMENT+i+1]=time_remain;
			data32[ITEM_FIELD_ENCHANTMENT+i+2]=count;
			break;
		}
	if(update_client)
		send_create_item(((Character*)data32[ITEM_FIELD_OWNER])->pClient);
}

void Item::del_enchantment(uint32 ench_id,uint8 update_client)
{
	for(int i=0;i<21;i++)
		if(data32[ITEM_FIELD_ENCHANTMENT+i]==ench_id)
		{
			data32[ITEM_FIELD_ENCHANTMENT+i]=0;
			break;
		}
	if(update_client)
		send_create_item(((Character*)data32[ITEM_FIELD_OWNER])->pClient);
}

//from the given points we generate a new item
//currently only one randomization is available per item
//for more complex randomizations add more options for a single randomizations instead of applying more than 1
void Item::randomise_me(uint32 avail_points)
{
	//see chance if we are going to apply random property_id
//	if((100 - 100/item_data32[ITEM_LVL]) > G_random.mt_random() % 100)
	{
		//pick 1 random property
		int random_property_index = G_random.mt_random() % G_max_random_property_id;
		if(G_item_random_property[random_property_index])
		{
			data32[ITEM_FIELD_RANDOM_PROPERTIES_ID]=random_property_index;
			uint32 ench_count=0;
			for(int i=0;i<3;i++)
				if(G_item_random_property[random_property_index]->ench[i])
				{
					add_enchantment(G_item_random_property[random_property_index]->ench[i]->id,-1,-1);
					ench_count++;
				}
			if(item_data32[ITEM_QUALITY]<ITEM_QUALITY_UNCOMMON_GREEN)
				item_data32[ITEM_QUALITY]=ITEM_QUALITY_UNCOMMON_GREEN;
			item_data32[ITEM_PRICE_SELL] += ench_count*avail_points;
			item_data32[ITEM_PRICE_BUY] += ench_count*avail_points;
		}
	}
	if(!G_max_item_mods)
		return;
	uint32 remianing_points=avail_points;
	uint32 applied_mods=0;
	uint32 cur_mod_id;
	uint32 cur_class,cur_subclass;
	cur_class = item_data32[ITEM_CLASS];
	cur_subclass = item_data32[ITEM_SUBCLASS];
	//usualy we only call this function if there is a mod to apply on the item
	while(applied_mods<MAX_MODS_PER_ITEM)
	{
		uint8 can_get_better=1,step;
		cur_mod_id = (G_max_item_mods_sorted[cur_class][cur_subclass])/2;
		step = cur_mod_id/2;
		//this will use divide et impera to get the best available mod for cur points
		while(can_get_better && step)
		{
			//this will get a better mod then we have right now
			uint32 hind;
			hind = cur_mod_id+step;
			//end search when we can't have a better mod
			if(G_item_mods_sorted[cur_class][cur_subclass][hind]->use_cost<=remianing_points)
			{
				cur_mod_id = hind;
				step /= 2;
				continue;
			}
			else if(G_item_mods_sorted[cur_class][cur_subclass][cur_mod_id]->use_cost>remianing_points)
			{
				cur_mod_id = cur_mod_id-step;
				step /= 2;
				continue;
			}
			//in case we got here it means there is no way we can get a mod for this item
			can_get_better=0;
		}
		//if we got here then we can apply the mod to the item
		applied_mods++;
//		remianing_points -= G_item_mods_sorted[cur_class][cur_subclass][cur_mod_id]->use_cost;
		apply_item_mod(G_item_mods_sorted[cur_class][cur_subclass][cur_mod_id]);
	}
}


void Item::apply_item_mod(Item_mod *p_mod)
{
	apply_item_mod(p_mod->mod_id);
}

void Item::apply_item_mod(uint32 mod_id)
{
	uint32 i;
	char tname[300];
	char *name;
	Item_mod *p_mod = G_item_mods[mod_id];
	//set item new id
//printf("randomizing item with mod id %u and item id %u\n",p_mod->mod_id,data32[OBJECT_FIELD_ENTRY]);
//printf("current item class is %u subclass is %u\n",item_data32[ITEM_CLASS],item_data32[ITEM_SUBCLASS]);
	data32[OBJECT_FIELD_ENTRY] = (uint32)(mod_id << 16) | data32[OBJECT_FIELD_ENTRY];
	item_data32[ITEM_ID] = data32[OBJECT_FIELD_ENTRY];
	name = (char*)&item_data32[ITEM_NAME];
	sprintf(tname,"%s %s",name,p_mod->suffix);
	tname[100]=0; //make sure it's shorter then max limit
	strcpy(name,tname);
	//it is a prefix
	sprintf(tname,"%s %s",p_mod->preffix,name);
	tname[100]=0; //make sure it's shorter then max limit
	strcpy(name,tname);
	for(i=0;i<MAX_ITEM_MOD_AFFECTS_PER_MOD;i++)
	{
		float new_value;
		switch(p_mod->affect_type[i])
		{
			case ITEM_MOD_AFFECT_TYPE_SET: new_value = p_mod->affect_value[i];break;
			case ITEM_MOD_AFFECT_TYPE_ADD: new_value = (item_data32[p_mod->affect_what[i]] + p_mod->affect_value[i]);break;
			case ITEM_MOD_AFFECT_TYPE_MUL: new_value = (item_data32[p_mod->affect_what[i]] * p_mod->affect_value[i]);break;
			default:new_value=(float)item_data32[p_mod->affect_what[i]];break;//incase we did not set any operation type, we should not modify the value
		}
		if(new_value!=item_data32[p_mod->affect_what[i]])
		{
			switch(p_mod->affect_what[i])
			{
				case ITEM_DMG_MIN_0:
				case ITEM_DMG_MAX_0:
				case ITEM_DMG_MIN_0+3:
				case ITEM_DMG_MAX_0+3:
				case ITEM_DMG_MIN_0+6:
				case ITEM_DMG_MAX_0+6:
				case ITEM_DMG_MIN_0+9:
				case ITEM_DMG_MAX_0+9:
				case ITEM_DMG_MIN_0+12:
				case ITEM_DMG_MAX_0+12:
					{item_dataf[p_mod->affect_what[i]] = new_value;}break;
				default:
					item_data32[p_mod->affect_what[i]] = (uint32)new_value;break;
			}
		}
	}
	item_data32[ITEM_PRICE_SELL] += p_mod->use_cost;
	item_data32[ITEM_PRICE_BUY] += p_mod->use_cost;
}

uint8 Item::is_static_item()
{
	uint32 i;
	for(i=0;i<5;i++)
		if(data32[ITEM_FIELD_SPELL_CHARGES+i]!=0 || data32[ITEM_FIELD_SPELL_CHARGES+i]!=-1)
			return 0;
	if(item_data32[ITEM_CLASS]==ITEM_CLASS_CONSUMABLE)
			return 0;
	return 1;
}

void Item::msg_item_query_single(GameClient *pClient)
{
	G_send_packet.opcode = SMSG_ITEM_QUERY_SINGLE_RESPONSE;
	G_send_packet.data32[0]=item_data32[ITEM_ID];
	G_send_packet.data32[1]=item_data32[ITEM_CLASS];
	G_send_packet.data32[2]=item_data32[ITEM_SUBCLASS];
	G_send_packet.data32[3]=item_data32[ITEM_UNK4];//unk
//printf("%u)Got a query, item name is %s and desc %s \n",item_data32[ITEM_ID],(char*)&item_data32[ITEM_NAME],(char*)&item_data32[ITEM_DESCRIPTION]);
	strcpy((char*)&G_send_packet.data32[4],(char*)&item_data32[ITEM_NAME]);
	G_send_packet.length = 4*4 + strlen((char*)&item_data32[ITEM_NAME])+1;
	G_send_packet.data[G_send_packet.length++] = 0;
	G_send_packet.data[G_send_packet.length++] = 0;
	G_send_packet.data[G_send_packet.length++] = 0;
	memcpy(&G_send_packet.data[G_send_packet.length],&item_data32[ITEM_DISPLAY_INFO_ID],96*4);
	G_send_packet.length+=96*4;
	strcpy((char*)&G_send_packet.data[G_send_packet.length],(char*)&item_data32[ITEM_DESCRIPTION]);
	G_send_packet.length += strlen((char*)&item_data32[ITEM_DESCRIPTION])+1;
	memcpy(&G_send_packet.data[G_send_packet.length],&item_data32[ITEM_PAGE_TEXT_ID],26*4);
	G_send_packet.length+=26*4;
	pClient->SendMsg(&G_send_packet);
}

void Item::loose_durability(float dmg)
{
	uint32 dur_loss = (uint32)(dmg/item_data32[ITEM_DURABILITY_MAX])+1;
	if(dur_loss >= data32[ITEM_FIELD_DURABILITY]) data32[ITEM_FIELD_DURABILITY] = 0;
	else data32[ITEM_FIELD_DURABILITY] -= dur_loss;
}
