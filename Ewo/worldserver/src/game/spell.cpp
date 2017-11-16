// Copyright (C) 2006 Team Evolution
#include "spell.h"
#include "Character.h"
#include "creature.h"
#include "group.h"

uint8 Spell_Info::Get_Creature_Prefered_Target()
{
	//target importance : Self/Friend, Enemy
	uint32 target_type,i;
	for(i=0;i<6;i++)
	{
		target_type = effect_implicit_target_a[i];
		switch(target_type)
		{
         case EFF_TARGET_SELF:
			 {
				 return CREATURE_CAST_PREFERED_TARGET_TYPE_SELF;
			 }break;
         case EFF_TARGET_SINGLE_ENEMY:
         case EFF_TARGET_ALL_ENEMY_IN_AREA:
         case EFF_TARGET_ALL_ENEMY_IN_AREA_INSTANT:
         case EFF_TARGET_ALL_ENEMY_IN_AREA_CHANNELED:
         case EFF_TARGET_ALL_ENEMIES_AROUND_CASTER:
         case EFF_TARGET_CURRENT_SELECTION:
			 {
				 return CREATURE_CAST_PREFERED_TARGET_TYPE_TARGET;
			 }break;
         case EFF_TARGET_SINGLE_FRIEND:
		 case EFF_TARGET_PARTY_MEMBER:
         case EFF_TARGET_SINGLE_PARTY:
		 case EFF_TARGET_ALL_PARTY:
         case EFF_TARGET_ALL_PARTY_AROUND_CASTER:
			 {
				 return CREATURE_CAST_PREFERED_TARGET_TYPE_FRIEND;
			 }
		}
	}
	return 0;
}

void Spell_Instance::set_caster(uint64 p_caster_guid,uint32 caster_faction)
{
	caster_guid = p_caster_guid;
	if(caster_guid_parts[1] & HIGHGUID_PLAYER)
		caster_char = (Character *)caster_guid;
	else caster_char = NULL;
	cast_faction = caster_faction;
}

void Spell_Instance::init_qued(uint32 spell_id)
{
	prototype = G_spell_info[spell_id];
	spell_duration[0] = prototype->duration[0];
	spell_duration[1] = prototype->duration[1];
	spell_duration[2] = prototype->duration[2];
	cast_duration = prototype->cast_time;
	target_list[0].clear();
	target_list[1].clear();
	target_list[2].clear();
}

void Spell_Instance::init(uint32 spell_id,float caster_x,float caster_y,float caster_o,uint32 caster_map_id)
{
	target_mask = 0; //==traget self
	target_creature = NULL;
	target_object = NULL;
	target_item = NULL;
	target_char = NULL;
//		src_pos_x = src_pos_y = src_pos_z = 0;
//		dst_pos_x = dst_pos_y = dst_pos_z = 0;
	if(target_string)
	{
		free(target_string);
		target_string = NULL;
	}
	prototype = G_spell_info[spell_id];
//	start_time = 0;
	target_list[0].clear();
	target_list[1].clear();
	target_list[2].clear();
	cast_x = caster_x; //required to send spell failed in case it is interrupted
	cast_y = caster_y;
	cast_o = caster_o;
	cast_map_id = caster_map_id;
	spell_duration[0] = prototype->duration[0];
	spell_duration[1] = prototype->duration[1];
	spell_duration[2] = prototype->duration[2];
	cast_duration = prototype->cast_time;
	cast_flags = CAST_ACTION_FLAG_NONE;
}

//!!! input src is where the targets start (incase packet structure changes)
//!!! caster can be char,unit,item,object
void Spell_Instance::read_targets_from_src(uint8 *src)
{
	target_mask = *(uint16*)&src[0];
	//not sure but spell can target multiple targets 
    if(target_mask==SPELL_TARGET_FLAG_SELF)
	{
		if(caster_guid_parts[1] & HIGHGUID_PLAYER)target_char = (Character*)caster_guid_parts[0];
		else if(caster_guid_parts[1] & HIGHGUID_UNIT)target_creature=(creature*)caster_guid_parts[0];
		else if(caster_guid_parts[1] & HIGHGUID_ITEM)target_item=(Item*)caster_guid_parts[0];
		else if(caster_guid_parts[1] & HIGHGUID_GAMEOBJECT)target_object=(gameobject_instance*)caster_guid_parts[0];
	}
	else
	{
		uint32	pos=2;
	    if(target_mask & SPELL_TARGET_FLAG_UNIT)
		{
			uint32 buff[2];
//printf("unpacking guid : mask is %u and pos is %u \n",src[pos],pos);
			UnpackGuid(src,pos,(uint8*)buff);
			//this can be creature or player
			if(buff[1] & HIGHGUID_PLAYER) target_char = (Character *)(buff[0]);
			else if(buff[1] & HIGHGUID_UNIT)	target_creature = (creature *)(buff[0]);
		}
		if(target_mask & SPELL_TARGET_FLAG_OBJECT)
		{
			uint32 buff[2];
			UnpackGuid(src,pos,(uint8*)buff);
			target_object = (gameobject_instance *)(buff[0]);
		}
		if(target_mask & SPELL_TARGET_FLAG_ITEM)
		{
			uint32 buff[2];
			UnpackGuid(src,pos,(uint8*)buff);
			target_item = (Item *)(buff[0]);
		}
		if(target_mask & SPELL_TARGET_FLAG_SOURCE_LOCATION)
		{	
			src_pos_x = *(float*)&src[pos];
			pos+=4;
			src_pos_y = *(float*)&src[pos];
			pos+=4;
			src_pos_z = *(float*)&src[pos];
			pos+=4;
		}
		if(target_mask & SPELL_TARGET_FLAG_DEST_LOCATION)
		{
			dst_pos_x = *(float*)&src[pos];
			pos+=4;
			dst_pos_y = *(float*)&src[pos];
			pos+=4;
			dst_pos_z = *(float*)&src[pos];
			pos+=4;
		}
		if(target_mask & SPELL_TARGET_FLAG_STRING)
		{
			if(target_string)
				free(target_string);
			target_string = (char*)malloc(strlen((char*)src[pos])+1);
			strcpy(target_string,(char*)src[pos]);
		}
	}
}


void Spell_Instance::write_targets_to_packet(NetworkPacket &packet)
{
	*(uint16*)&packet.data[packet.length]=target_mask;
    packet.length+=2;
/*	if(target_mask == SPELL_TARGET_FLAG_SELF)
    {
	    if(target_char)	*(uint64*)&packet.data[packet.length]=target_char->getGUID();
		else if(target_creature) *(uint64*)&packet.data[packet.length]=target_creature->getGUID();
		else if(target_item) *(uint64*)&packet.data[packet.length]=target_item->getGUID();
		packet.length+=8;
	}*/
    if(target_mask & SPELL_TARGET_FLAG_UNIT)
    {
		packet.data[packet.length++]= 0xFF;
	    if(target_char)	*(uint64*)&packet.data[packet.length]=target_char->getGUID();
		else if(target_creature) *(uint64*)&packet.data[packet.length]=target_creature->getGUID();
 	    packet.length+=8;
	}
    if((target_mask & SPELL_TARGET_FLAG_OBJECT) && target_object)
    {
		packet.data[packet.length++]= 0xFF;
	   *(uint64*)&packet.data[packet.length]=target_object->getGUID();
	   packet.length+=8;
    }
    if((target_mask & SPELL_TARGET_FLAG_ITEM) && target_item)
    {
		packet.data[packet.length++]= 0xFF;
	   *(uint64*)&packet.data[packet.length]=target_item->getGUID();
	   packet.length+=8;
    }
    if(target_mask & SPELL_TARGET_FLAG_SOURCE_LOCATION)
    {
	   *(float*)&packet.data[packet.length]=src_pos_x;
	   packet.length+=4;
	   *(float*)&packet.data[packet.length]=src_pos_y;
	   packet.length+=4;
	   *(float*)&packet.data[packet.length]=src_pos_z;
	   packet.length+=4;
    }
    if(target_mask & SPELL_TARGET_FLAG_DEST_LOCATION)
    {
	   *(float*)&packet.data[packet.length]=dst_pos_x;
	   packet.length+=4;
	   *(float*)&packet.data[packet.length]=dst_pos_y;
	   packet.length+=4;
	   *(float*)&packet.data[packet.length]=dst_pos_z;
	   packet.length+=4;
    }
    if((target_mask & SPELL_TARGET_FLAG_STRING) && target_string)
    {
	   strcpy((char*)&packet.data[packet.length],target_string);
	   packet.length+=strlen(target_string);
    }	
}

void Spell_Instance::write_targets_to_packet_go_spell(NetworkPacket &packet)
{
	if(target_mask==0)*(uint16*)&packet.data[packet.length]=0x0002;
	else *(uint16*)&packet.data[packet.length]=target_mask;
    packet.length+=2;
    if(target_mask & (SPELL_TARGET_FLAG_UNIT | SPELL_TARGET_FLAG_OBJECT | SPELL_TARGET_FLAG_ITEM))
		packet.data[packet.length++]=0xFF; //this is guidmask, it is 0 if there is no guid
	else packet.data[packet.length++]=0x00; //this is guidmask, it is 0 if there is no guid
    if(target_mask & SPELL_TARGET_FLAG_UNIT)
    {
	    if(target_char)	*(uint64*)&packet.data[packet.length]=target_char->getGUID();
		else if(target_creature) *(uint64*)&packet.data[packet.length]=target_creature->getGUID();
 	    packet.length+=8;
	}
    if((target_mask & SPELL_TARGET_FLAG_OBJECT) && target_object)
    {
	   *(uint64*)&packet.data[packet.length]=target_object->getGUID();
	   packet.length+=8;
    }
    if((target_mask & SPELL_TARGET_FLAG_ITEM) && target_item)
    {
	   *(uint64*)&packet.data[packet.length]=target_item->getGUID();
	   packet.length+=8;
    }
    if(target_mask & SPELL_TARGET_FLAG_SOURCE_LOCATION)
    {
	   *(float*)&packet.data[packet.length]=src_pos_x;
	   packet.length+=4;
	   *(float*)&packet.data[packet.length]=src_pos_y;
	   packet.length+=4;
	   *(float*)&packet.data[packet.length]=src_pos_z;
	   packet.length+=4;
    }
    if(target_mask & SPELL_TARGET_FLAG_DEST_LOCATION)
    {
	   *(float*)&packet.data[packet.length]=dst_pos_x;
	   packet.length+=4;
	   *(float*)&packet.data[packet.length]=dst_pos_y;
	   packet.length+=4;
	   *(float*)&packet.data[packet.length]=dst_pos_z;
	   packet.length+=4;
    }
    if((target_mask & SPELL_TARGET_FLAG_STRING) && target_string)
    {
	   strcpy((char*)&packet.data[packet.length],target_string);
	   packet.length+=strlen(target_string);
    }	
}


void Spell_Instance::cancel_cast(uint32 spell_id)
{
	//we are not casting a spell so we cannot cancel the cast
	if(spell_id!=0 && (!prototype || prototype->spell_id!=spell_id))
		return;
	msg_spell_failed(0);
	msg_spell_can_cast_result(CAST_FAIL_INTERRUPTED); //intrupted
	//if channeled
	if(prototype->channel_interrupt_flags!=0)
		msg_spell_channel_update(0);
}

void Spell_Instance::msg_spell_failed(uint8 result)
{
	G_send_packet.opcode = SMSG_SPELL_FAILURE;
	G_send_packet.data[0] = 0xFF;
	*(uint64*)(G_send_packet.data+1) = caster_guid;
	*(uint32*)(G_send_packet.data+9) = prototype->spell_id;
	G_send_packet.data[13] = result;
	G_send_packet.length = 14;
//	G_maps[cast_map_id]->send_instant_msg_to_block(cast_x,cast_y,&G_send_packet,NULL);
	if(caster_char)
		caster_char->SendMsg(&G_send_packet);
}
void Spell_Instance::play_spell_visual(uint32 spell_id)
{
	G_send_packet.opcode = SMSG_PLAY_SPELL_VISUAL;
	G_send_packet.data64[0] = caster_guid;
	if(spell_id)G_send_packet.data32[2] = spell_id;
	else G_send_packet.data32[2] = prototype->spell_id;
	G_send_packet.length = 12;
//	G_maps[cast_map_id]->send_instant_msg_to_block(cast_x,cast_y,&G_send_packet,NULL);
	if(caster_char)
		caster_char->SendMsg(&G_send_packet);
}


void Spell_Instance::msg_spell_can_cast_result(uint8 result)
{
	if(!caster_char)
		return;
	G_send_packet.opcode = SMSG_CAST_RESULT;
	G_send_packet.data32[0] = prototype->spell_id;
    if(result != 0)
	{
        G_send_packet.data[4] = 2;
        G_send_packet.data[5] = result;
		G_send_packet.length = 6;
	}
	else
	{
		G_send_packet.data[4] = 0;
		G_send_packet.length = 5;
	}
//	G_maps[cast_map_id]->send_instant_msg_to_block(cast_x,cast_y,&G_send_packet,NULL);
	caster_char->SendMsg(&G_send_packet);
}

void msg_spell_can_cast_result(uint32 spell_id,uint8 result,Character *sendto)
{
	G_send_packet.opcode = SMSG_CAST_RESULT;
	G_send_packet.data32[0] = spell_id;
    if(result != 0)
	{
        G_send_packet.data[4] = 2;
        G_send_packet.data[5] = result;
		G_send_packet.length = 6;
	}
	else
	{
		G_send_packet.data[4] = 0;
		G_send_packet.length = 5;
	}
	sendto->SendMsg(&G_send_packet);
}

void Spell_Instance::msg_spell_start_cast()
{
	G_send_packet.opcode = SMSG_SPELL_START;
	G_send_packet.data[0] = 0xFF;
	*(uint64*)(G_send_packet.data+1) = caster_guid;
	G_send_packet.data[9] = 0xFF;
	if(item_caster_guid) *(uint64*)(G_send_packet.data+10) = item_caster_guid;
	else *(uint64*)(G_send_packet.data+10) = caster_guid;
	*(uint32*)(G_send_packet.data+18) = prototype->spell_id;
	if(target_mask & SPELL_TARGET_FLAG_SOURCE_LOCATION)    *(uint16*)(G_send_packet.data+22) = 0x0B; //cast flags
	else *(uint16*)(G_send_packet.data+22) = 0x02; //cast flags
	*(uint32*)(G_send_packet.data+24) = cast_duration;
	G_send_packet.length = 28;
	write_targets_to_packet(G_send_packet);
	G_maps[cast_map_id]->send_instant_msg_to_block(cast_x,cast_y,&G_send_packet,NULL);
}

void Spell_Instance::msg_spell_channel_start()
{
	//only chars can channel spells
	if(!caster_char)
		return;
	G_send_packet.opcode = MSG_CHANNEL_START;
	G_send_packet.data[0] = 0xFF;
	*(uint64*)(G_send_packet.data+1) = caster_guid;
	*(uint32*)(G_send_packet.data+9) = prototype->spell_id;
	*(uint32*)(G_send_packet.data+13) = prototype->duration[0];
	G_send_packet.length = 17;
	caster_char->pClient->SendMsg(&G_send_packet);
/*	if(target_char) caster_char->SetUInt64Value(UNIT_FIELD_CHANNEL_OBJECT,target_char->getGUID());
	else if(target_creature) caster_char->SetUInt64Value(UNIT_FIELD_CHANNEL_OBJECT,target_creature->getGUID());
	else if(target_object) caster_char->SetUInt64Value(UNIT_FIELD_CHANNEL_OBJECT,target_object->getGUID());
	else if(target_item) caster_char->SetUInt64Value(UNIT_FIELD_CHANNEL_OBJECT,target_item->getGUID());
	caster_char->SetUInt32Value(UNIT_CHANNEL_SPELL,prototype->spell_id);*/
}

void Spell_Instance::msg_spell_channel_update(uint32 time)
{
	//only chars can channel spells
	if(!caster_char)
		return;
    G_send_packet.opcode = MSG_CHANNEL_UPDATE;
	G_send_packet.data[0] = 0xFF;
	*(uint64*)(G_send_packet.data+1) = caster_guid;
	*(uint32*)(G_send_packet.data+9) = time;
	G_send_packet.length = 13;
	caster_char->pClient->SendMsg(&G_send_packet);
    if(time == 0)
    {
       caster_char->SetUInt64Value(UNIT_FIELD_CHANNEL_OBJECT,0);
       caster_char->SetUInt32Value(UNIT_CHANNEL_SPELL,0);
    }
}

void Spell_Instance::msg_spell_cast_go()
{
    G_send_packet.opcode = SMSG_SPELL_GO;
	G_send_packet.data[0]=0xFF;
    *(uint64*)(G_send_packet.data+1) = caster_guid;
	G_send_packet.data[9]=0xFF;
	*(uint64*)(G_send_packet.data+10) = caster_guid; //creatures do not send the second guid. Try it for chars too
	*(uint32*)(G_send_packet.data+18) = prototype->spell_id;
//	if(target_mask==0)*(uint16*)(G_send_packet.data+22)=2;//or 0x500 ?
//	else *(uint16*)(G_send_packet.data+22)=target_mask;
//	if(target_mask==0)target_mask=2;
	G_send_packet.data[22] = 0x00; //this is somekinda mask, just didn't have enough examples to decode it yet, it's 0,5,9
	G_send_packet.data[23] = 0x01; //until now i met 0x01 and 0x11(on target place) values
	G_send_packet.data[24] = (uint8)target_list[3].len;
    memcpy((G_send_packet.data+25),target_list[3].data,target_list[3].len*8);
	G_send_packet.length = 25 + target_list[3].len*8;
	G_send_packet.data[G_send_packet.length++] = 0; //number of misses
	write_targets_to_packet_go_spell(G_send_packet);
	G_maps[cast_map_id]->send_instant_msg_to_block(cast_x,cast_y,&G_send_packet,NULL);
}

void Spell_Instance::msg_heal_unit(uint64 target_guid,uint32 value,uint8 is_crititcal)
{
	if(!((target_guid >> 32) & HIGHGUID_PLAYER))
		return;
	G_send_packet.opcode = SMSG_HEALSPELL_ON_PLAYER_OBSOLETE;
	G_send_packet.data[0]=0xFF;
    *(uint64*)(G_send_packet.data+1) = caster_guid;
	G_send_packet.data[9]=0xFF;
	*(uint64*)(G_send_packet.data+10) = target_guid; //creatures do not send the second guid. Try it for chars too
	*(uint32*)(G_send_packet.data+18) = prototype->spell_id;
	*(uint32*)(G_send_packet.data+22) = value;
	*(uint32*)(G_send_packet.data+26) = is_crititcal;
	G_send_packet.length = 27;
	((Character*)(target_guid))->SendMsg(&G_send_packet);
}

void msg_heal_unit(uint64 target_guid,uint64 caster_guid,uint32 value,uint8 is_crititcal,uint32 spell_id)
{
	if(!((target_guid >> 32) & HIGHGUID_PLAYER))
		return;
	G_send_packet.opcode = SMSG_HEALSPELL_ON_PLAYER_OBSOLETE;
	G_send_packet.data[0]=0xFF;
    *(uint64*)(G_send_packet.data+1) = caster_guid;
	G_send_packet.data[9]=0xFF;
	*(uint64*)(G_send_packet.data+10) = target_guid; //creatures do not send the second guid. Try it for chars too
	*(uint32*)(G_send_packet.data+18) = spell_id;
	*(uint32*)(G_send_packet.data+22) = value;
	*(uint32*)(G_send_packet.data+26) = is_crititcal;
	G_send_packet.length = 27;
	((Character*)(target_guid))->SendMsg(&G_send_packet);
}

//in case we duel we help out the caster to cast good spells on self
void Spell_Instance::make_target_list_if_duel()
{
	uint32 target_type,i,has_target=0,j;
	for(i=0;i<6;i++)
	{
		target_type = prototype->effect_implicit_target_a[i];
		has_target += target_type; //if not 0 means we have a target
		j = i % 3;
		switch(target_type)
		{
         case EFF_TARGET_SELF:
			 {
				 target_list[j].add(caster_guid);
			 }break;
         case EFF_TARGET_MINION:
         case EFF_TARGET_PET:
			 {
				 if((caster_guid_parts[1] & (HIGHGUID_PLAYER | HIGHGUID_UNIT)))
				 {
					 Base_Unit_Object *caster=(Base_Unit_Object *)caster_guid;
					 if(caster->data32[UNIT_FIELD_SUMMON])
						 target_list[j].add(*(uint64*)&caster->data32[UNIT_FIELD_SUMMON]);
				 }
			 }break;
         case EFF_TARGET_SINGLE_ENEMY:
			 {
				 if(target_creature)
						 target_list[j].add(target_creature->getGUID());
				 else if(target_char)
						 target_list[j].add(target_char->getGUID());
				 else target_list[j].add(caster_char->last_atacker_guid);
			 }break;
         case EFF_TARGET_SINGLE_FRIEND:
			 {
					 target_list[j].add(caster_char->last_atacker_guid);
			 }
         case EFF_TARGET_DUEL:
			 {
				if(target_char)	target_list[j].add(target_char->getGUID());
			 }break;
         case EFF_TARGET_GAMEOBJECT:
			 {
				if(target_object)
					target_list[j].add(target_object->getGUID());
			 }break;
         case EFF_TARGET_ALL_ENEMY_IN_AREA:
         case EFF_TARGET_ALL_ENEMY_IN_AREA_INSTANT:
         case EFF_TARGET_ALL_ENEMY_IN_AREA_CHANNELED:
			 {
				 target_list[j].add(caster_char->duel_info.target->getGUID());
				cast_flags |= CAST_ACTION_FLAG_LOCATION_DEPENDENT | CAST_ACTION_FLAG_ALWAYS_ACTIVE; //do not save on exit and if we are too far away from caster then it is removed
			 };
         case EFF_TARGET_ALL_ENEMIES_AROUND_CASTER:
			 {
				 target_list[j].add(caster_char->duel_info.target->getGUID());
			 }break;
         case EFF_TARGET_CURRENT_SELECTION:
			 {
				 target_list[j].add(caster_char->last_target_GUID);
			 }break;
         case EFF_TARGET_GAMEOBJECT_ITEM:
			 {
				if(target_object)target_list[j].add(target_object->getGUID());
				else if(target_item)target_list[j].add(target_item->getGUID());
			 }break;
         case EFF_TARGET_CHAIN:
			 {
				 target_list[j].add(caster_char->duel_info.target->getGUID());
			 }break;
         case EFF_TARGET_IN_FRONT_OF_CASTER:
			 {
				 target_list[j].add(caster_char->duel_info.target->getGUID());
			 }break;
#ifdef _DEBUG
		 case EFF_TARGET_TOTEM_EARTH:
		 case EFF_TARGET_TOTEM_WATER:
		 case EFF_TARGET_TOTEM_AIR:
		 case EFF_TARGET_TOTEM_FIRE:
			 {
				 //these are used when we sumon a new totem
			 }break;
#endif
		}
	}
}

void Spell_Instance::make_target_list()
{
	if(caster_char && (caster_char->state1 & (PLAYER_STATE_DUEL_PREPARE | PLAYER_STATE_IN_DUEL | PLAYER_STATE_DUEL_UTOFBOUNDS)))
	{
		make_target_list_if_duel();
		return;
	}
	uint32 target_type,i,has_target=0,j;
	for(i=0;i<6;i++)
	{
		target_type = prototype->effect_implicit_target_a[i];
		has_target += target_type; //if not 0 means we have a target
		j = i % 3;
		switch(target_type)
		{
         case EFF_TARGET_SELF:
			 {
				 target_list[j].add(caster_guid);
			 }break;
         case EFF_TARGET_MINION:
         case EFF_TARGET_PET:
			 {
				 if((caster_guid_parts[1] & (HIGHGUID_PLAYER | HIGHGUID_UNIT)))
				 {
					 Base_Unit_Object *caster=(Base_Unit_Object *)caster_guid;
					 if(caster->data32[UNIT_FIELD_SUMMON])
						 target_list[j].add(*(uint64*)&caster->data32[UNIT_FIELD_SUMMON]);
				 }
			 }break;
         case EFF_TARGET_SINGLE_ENEMY:
			 {
				 if(target_creature)
				 {
					 if(G_faction_is_enemy[cast_faction*G_max_faction_id+target_creature->data32[UNIT_FIELD_FACTIONTEMPLATE]] || 
						 !G_faction_is_friend[cast_faction*G_max_faction_id+target_creature->data32[UNIT_FIELD_FACTIONTEMPLATE]]) 
						 target_list[j].add(target_creature->getGUID());
					 else break;
				 }
				 else if(target_char)
				 {
					 if(G_faction_is_enemy[cast_faction*G_max_faction_id+target_char->data32[UNIT_FIELD_FACTIONTEMPLATE]] ||
						 !G_faction_is_friend[cast_faction*G_max_faction_id+target_char->data32[UNIT_FIELD_FACTIONTEMPLATE]]) 
						 target_list[j].add(target_char->getGUID());
					 else break;
				 }
				 //check last used object guid to be friend
				 else if(caster_char)
				 {
					 uint32 last_target_faction=0;
					 if(((uint32)(caster_char->last_atacker_guid>>32)) & HIGHGUID_PLAYER)
						 last_target_faction = ((Character*)caster_char->last_atacker_guid)->data32[UNIT_FIELD_FACTIONTEMPLATE];
					 else if(((uint32)(caster_char->last_atacker_guid>>32)) & HIGHGUID_UNIT)
						 last_target_faction = ((creature*)caster_char->last_atacker_guid)->data32[UNIT_FIELD_FACTIONTEMPLATE];
					 if(last_target_faction && 
						 !G_faction_is_friend[cast_faction*G_max_faction_id+last_target_faction])
//						 ( G_faction_is_enemy[cast_faction*G_max_faction_id+last_target_faction] ||
//						 !G_faction_is_friend[cast_faction*G_max_faction_id+last_target_faction] ))
					 {
						 target_list[j].add(caster_char->last_atacker_guid);
						 break;
					 }
				 }
			 }break;
         case EFF_TARGET_SINGLE_FRIEND:
			 {
				 //target_char and target_cr is aquired by readtarget or implicit set
				 if(target_char && !G_faction_is_enemy[cast_faction*G_max_faction_id+target_char->data32[UNIT_FIELD_FACTIONTEMPLATE]])
					target_list[j].add(target_char->getGUID());
				 else if(target_creature && !G_faction_is_enemy[cast_faction*G_max_faction_id+target_creature->data32[UNIT_FIELD_FACTIONTEMPLATE]])
						 target_list[j].add(target_creature->getGUID());
				 //check last used object guid to be friend
				 else if(caster_char)
				 {
					 uint32 last_target_faction=0;
					 if(((uint32)(caster_char->last_atacker_guid>>32)) & (HIGHGUID_PLAYER | HIGHGUID_UNIT))
						 last_target_faction = ((Base_Unit_Object*)caster_char->last_atacker_guid)->data32[UNIT_FIELD_FACTIONTEMPLATE];
					 if(last_target_faction && !G_faction_is_enemy[cast_faction*G_max_faction_id+last_target_faction])
					 {
						 target_list[j].add(caster_char->last_atacker_guid);
						 break;
					 }
				 }
				 //if not then cast on self only if above code did not execute
				 else if(caster_guid)
					target_list[j].add(caster_guid);
			 }
         case EFF_TARGET_DUEL:
			 {
				if(target_char)	target_list[j].add(target_char->getGUID());
			 }break;
		 case EFF_TARGET_PARTY_MEMBER:
         case EFF_TARGET_SINGLE_PARTY:
			 {
				if(target_char)	target_list[j].add(target_char->getGUID());
				else if(target_creature) target_list[j].add(target_creature->getGUID());
			 }break;
         case EFF_TARGET_GAMEOBJECT:
			 {
				if(target_object)
					target_list[j].add(target_object->getGUID());
			 }break;
         case EFF_TARGET_ALL_ENEMY_IN_AREA:
         case EFF_TARGET_ALL_ENEMY_IN_AREA_INSTANT:
         case EFF_TARGET_ALL_ENEMY_IN_AREA_CHANNELED:
			 {
				 if(dst_pos_x)
					G_maps[cast_map_id]->get_inrange_enemy_guids(dst_pos_x,dst_pos_y,&target_list[j],0,prototype->radius[i%3],cast_faction);
				 else if(src_pos_x)
					G_maps[cast_map_id]->get_inrange_enemy_guids(src_pos_x,src_pos_y,&target_list[j],0,prototype->radius[i%3],cast_faction);
				cast_flags |= CAST_ACTION_FLAG_LOCATION_DEPENDENT | CAST_ACTION_FLAG_ALWAYS_ACTIVE; //do not save on exit and if we are too far away from caster then it is removed
			 };
         case EFF_TARGET_ALL_ENEMIES_AROUND_CASTER:
			 {
				G_maps[cast_map_id]->get_inrange_enemy_guids(cast_x,cast_y,&target_list[j],0,prototype->radius[i%3],cast_faction);
			 }break;
         case EFF_TARGET_CURRENT_SELECTION:
			 {
				 if(caster_char)
					 target_list[j].add(caster_char->last_target_GUID);
			 }break;
		 case EFF_TARGET_ALL_PARTY:
         case EFF_TARGET_ALL_PARTY_AROUND_CASTER:
			 {
				//iterate through group members and if inrange then add to list
				Character *char_caster=(Character*)caster_guid;
				if(char_caster->group)
				{
					Group_Node *group_iter;
					group_iter = char_caster->group->first;
					while(group_iter)
					{
						target_list[j].add(group_iter->p_char->getGUID());
						group_iter = group_iter->next;
					}
				}
				else target_list[j].add(caster_guid);
				cast_flags |= CAST_ACTION_FLAG_CASTER_DEPENDENT | CAST_ACTION_FLAG_ALWAYS_ACTIVE; //do not save on exit and if we are too far away from caster then it is removed
			 }break;
         case EFF_TARGET_GAMEOBJECT_ITEM:
			 {
				if(target_object)target_list[j].add(target_object->getGUID());
				else if(target_item)target_list[j].add(target_item->getGUID());
			 }break;
         case EFF_TARGET_CHAIN:
			 {
				G_maps[cast_map_id]->get_inrange_enemy_guids(cast_x,cast_y,&target_list[j],0,prototype->radius[i%3],cast_faction);
			 }break;
         case EFF_TARGET_IN_FRONT_OF_CASTER:
			 {
				 G_maps[cast_map_id]->get_inrange_enemy_guids(cast_x,cast_y,&target_list[j],0,prototype->radius[i%3],cast_faction);
			 }break;
#ifdef _DEBUG
		 case EFF_TARGET_TOTEM_EARTH:
		 case EFF_TARGET_TOTEM_WATER:
		 case EFF_TARGET_TOTEM_AIR:
		 case EFF_TARGET_TOTEM_FIRE:
			 {
				 //these are used when we sumon a new totem
			 }break;
#endif
		}
	}
   if (has_target == 0)
      for(i = 0; i < 3; i++)
		  if (prototype->effect[i] == EFFECT_LEARN_SPELL)
		  {
			  //if caster is a creature then he must have targeted us - not realy the case
			  if(caster_char)
			  {
				  //if we are trying to teach our target something
					 uint32 last_target_faction=0;
					 if(((uint32)(caster_char->last_target_GUID>>32)) & (HIGHGUID_PLAYER | HIGHGUID_UNIT))
						 last_target_faction = ((Base_Unit_Object*)caster_char->last_atacker_guid)->data32[UNIT_FIELD_FACTIONTEMPLATE];
					 if(last_target_faction && G_faction_is_friend[cast_faction*G_max_faction_id+last_target_faction])
					 {
						 target_list[i].add(caster_char->last_atacker_guid);
						 break;//break from for
					 }
					 //if we got here it means we can add caster as target
					 target_list[i].add(caster_guid);
					 break;//exit loop
			  }
		  }
	target_list[3].clear();//full list of target
	for(i=0;i<target_list[0].len;i++)
		target_list[3].add(target_list[0].data[i]);
	for(i=0;i<target_list[1].len;i++)
		target_list[3].add(target_list[1].data[i]);
	for(i=0;i<target_list[2].len;i++)
		target_list[3].add(target_list[2].data[i]);
}

void Spell_Instance::msg_spell_log_execute()
{
	Character *char_caster=(Character*)caster_guid;
    G_send_packet.opcode = SMSG_SPELLLOGEXECUTE;
	G_send_packet.data64[0] = caster_guid;
	G_send_packet.data32[2] = prototype->spell_id;
	G_send_packet.data32[3] = 1;
	G_send_packet.data32[4] = 0x00000021;
	G_send_packet.data32[5] = 0x00000001;
	G_send_packet.data64[3] = target_list[3].data[0];
//	if(target_creature)G_send_packet.data64[3] = target_creature->getGUID();
//	else if(target_char)G_send_packet.data64[3] = target_char->getGUID();
//	else if(target_object)G_send_packet.data64[3] = target_object->getGUID();
//	else if(target_item)G_send_packet.data64[3] = target_item->getGUID();
	G_send_packet.length = 32;
	caster_char->pClient->SendMsg(&G_send_packet);
}

void Spell_Instance::msg_non_melee_dmg_log(float damage,uint8 dmg_type)
{
	//only chars can channel spells
	if(!caster_char)
		return;
	G_send_packet.opcode = SMSG_SPELLNONMELEEDAMAGELOG;
	G_send_packet.data[0] = 0xFF;
//	*(uint64*)(G_send_packet.data+1) = target_list[0].data[0];
	G_send_packet.data[9] = 0xFF;
	*(uint64*)(G_send_packet.data+10) = caster_guid;
	*(uint32*)(G_send_packet.data + 18) = prototype->spell_id;
	*(uint32*)(G_send_packet.data + 22) = (uint32)damage;
	*(uint32*)(G_send_packet.data + 26) = dmg_type; 
	*(uint32*)(G_send_packet.data + 30) = 0x00000000;
	*(uint32*)(G_send_packet.data + 34) = 0x00000000; 
	*(uint32*)(G_send_packet.data + 38) = 0x00000000; 
	*(uint32*)(G_send_packet.data + 42) = 0x00000000; 
	if(caster_char)
	{
		G_send_packet.data[36] = 0x01;
		G_send_packet.data[41] = 0x04;
	}
	else G_send_packet.data[41] = 0x05;
	G_send_packet.length = 46;
	for(uint32 target_itr=0;target_itr<target_list[3].len;target_itr++)
	{
		*(uint64*)(G_send_packet.data+1) = target_list[3].data[target_itr];
		caster_char->pClient->SendMsg(&G_send_packet);
	}
}

void msg_non_melee_dmg_log(float damage,uint64 caster_guid,uint64 target,Spell_Info *prototype,Character *sendto)
{
	//only chars can channel spells
	G_send_packet.opcode = SMSG_SPELLNONMELEEDAMAGELOG;
	G_send_packet.data[0] = 0xFF;
	*(uint64*)(G_send_packet.data+1) = target;
	G_send_packet.data[9] = 0xFF;
	*(uint64*)(G_send_packet.data+10) = caster_guid;
	*(uint32*)(G_send_packet.data + 18) = prototype->spell_id;
	*(uint32*)(G_send_packet.data + 22) = (uint32)damage;
	*(uint32*)(G_send_packet.data + 26) = prototype->school; 
	*(uint32*)(G_send_packet.data + 30) = 0x00000000;
	*(uint32*)(G_send_packet.data + 34) = 0x00000000; 
	*(uint32*)(G_send_packet.data + 38) = 0x00000000; 
	*(uint32*)(G_send_packet.data + 42) = 0x00000000; 
	if((uint32)caster_guid & HIGHGUID_PLAYER)
	{
		G_send_packet.data[36] = 0x01;
		G_send_packet.data[41] = 0x04;
	}
	else G_send_packet.data[41] = 0x05;
	G_send_packet.length = 46;
	sendto->pClient->SendMsg(&G_send_packet);
}


uint8 Spell_Instance::require_caster_behind_target()
{
   //--- Rogue Backstab
	if (prototype->spell_id == 53 || prototype->spell_id == 2589 || prototype->spell_id == 2590 || prototype->spell_id == 2591 || prototype->spell_id == 8721 ||
      prototype->spell_id == 11279 || prototype->spell_id == 11280 || prototype->spell_id == 11281) return 1;
   //--- Rogue Garrote
   if (prototype->spell_id == 703 || prototype->spell_id == 8631 || prototype->spell_id == 8632 || prototype->spell_id == 8633 || prototype->spell_id == 11289 ||
      prototype->spell_id == 11290) return 1;
   //--- Rogue - Ambush
   if (prototype->spell_id == 8676 || prototype->spell_id == 8724 || prototype->spell_id == 8725 || prototype->spell_id == 11267 || prototype->spell_id == 11268 ||
      prototype->spell_id == 11269) return 1;
   return 0;
}

uint8 is_in_front(float viewer_x,float viewer_y,float viewer_orintation,float target_x,float target_y)
{
	float angle,min_angle,max_angle;
	float dif_x = (target_x-viewer_x),dif_y=(target_y-viewer_y);
	if(dif_x!=0)
		angle = atan(dif_y/dif_x);
	else angle = PI / 2;
	if(dif_y < 0 && dif_x < 0) 	angle += PI; //3
	else if(dif_y < 0 && dif_x > 0)	angle = 2*PI - (-angle);//4
	else if(dif_y > 0 && dif_x < 0)	angle = PI - (-angle);//2
	min_angle = angle - PI/4; // viewer can see 45 left and right from orientation
	max_angle = angle + PI/4;
	if(viewer_orintation > min_angle && viewer_orintation < max_angle) return 1;
	return 0;
}
/*
void Spell_Instance::msg_spell_cooldown()
{
	if(prototype->recovery_time)
	{
		G_send_packet.opcode = SMSG_SPELL_COOLDOWN;
		G_send_packet.data64[0] = caster_char->getGUID();
		G_send_packet.data32[2] = prototype->spell_id;
		G_send_packet.data32[3] = prototype->recovery_time;
		G_send_packet.length = 16;
		caster_char->pClient->SendMsg(&G_send_packet);
	}
}
*/
void Spell_Instance::msg_spell_cooldown(uint32 spell_id,uint32 cooldown_time)
{
	if(!caster_char)
		return;
	G_send_packet.opcode = SMSG_SPELL_COOLDOWN;
	G_send_packet.data32[0] = caster_char->getGUIDL();
	G_send_packet.data32[0] = caster_char->getGUIDH();
	G_send_packet.data32[2] = spell_id;
	G_send_packet.data32[3] = cooldown_time;
	G_send_packet.length = 16;
	caster_char->pClient->SendMsg(&G_send_packet);
}

//found when initiating a duel
void Spell_Instance::msg_cooldown_event(uint32 spell_id)
{
	if(!caster_char)
		return;
	G_send_packet.opcode = SMSG_COOLDOWN_EVENT;
	G_send_packet.data32[0] = spell_id;
	*(uint64*)&G_send_packet.data32[1] = caster_char->getGUID();
	G_send_packet.length = 12;
	caster_char->pClient->SendMsg(&G_send_packet);
}

void Spell_Instance::WORLD_instant_cast(Base_Unit_Object *t_obj,uint32 spell_id)
{
	flags1 &= ~SPELL_CAST_INTERNAL_FLAG_FORCE_STACKABLE;
	caster_guid = NULL;
	caster_char = NULL;
	cast_faction = 0xFFFFFFFF; //we cast this spell on 1 target only
	target_mask=2;
	target_char = (Character*)t_obj;
	target_creature = NULL;
	target_object = NULL;
	target_item = NULL;
	prototype = G_spell_info[spell_id];
	cast_x = t_obj->pos_x; //required to send spell failed in case it is interrupted
	cast_y = t_obj->pos_y;
	cast_o = t_obj->orientation;
	cast_map_id = t_obj->map_id;
	target_list[0].clear();
	target_list[1].clear();
	target_list[2].clear();
	target_list[0].add(t_obj->getGUID());
	target_list[1].add(t_obj->getGUID());
	target_list[2].add(t_obj->getGUID());
	cast_duration = 0;
	spell_duration[0] = prototype->duration[0];
	spell_duration[1] = prototype->duration[1];
	spell_duration[2] = prototype->duration[2];
//	msg_spell_start_cast();
//	msg_spell_can_cast_result(0);
	msg_spell_cast_go();
//	msg_spell_log_execute();
	add_affects_to_targets();
}

//no initialisation 
void Spell_Instance::cr_instant_cast(creature *owner,uint32 spell_id,uint64 sugested_target)
{
	caster_guid = owner->getGUID();
	caster_char = NULL;
	cast_faction = owner->data32[UNIT_FIELD_FACTIONTEMPLATE];
	target_mask=2;
	if(sugested_target)
	{
		if((sugested_target>>32) & HIGHGUID_PLAYER) target_char = (Character*)sugested_target;
		else if((sugested_target>>32) & HIGHGUID_UNIT) target_creature = (creature*)sugested_target;
	}
	else if(owner->target)
	{
		if(owner->target->obj_type & HIGHGUID_PLAYER) target_char = (Character*)owner->target;
		else if(owner->target->obj_type & HIGHGUID_UNIT)	target_creature = (creature*)owner->target;
	}
	else 
	{
		target_char = NULL;
		target_creature = NULL;
	}
	target_object = NULL;
	target_item = NULL;
	prototype = G_spell_info[spell_id];
	cast_x = owner->pos_x; //required to send spell failed in case it is interrupted
	cast_y = owner->pos_y;
	cast_o = owner->orientation;
	cast_map_id = owner->map_id;
	target_list[0].clear();
	target_list[1].clear();
	target_list[2].clear();
	make_target_list();
	cast_duration = 0;
	spell_duration[0] = prototype->duration[0];
	spell_duration[1] = prototype->duration[1];
	spell_duration[2] = prototype->duration[2];
//	msg_spell_start_cast();
//	msg_spell_can_cast_result(0);
	msg_spell_cast_go();
//	msg_spell_log_execute();
	add_affects_to_targets();
}

void Spell_Instance::aura_refresh_cast_on_group(uint32 spell_id)
{
	//this can be casted by pet and a group member
	Group_Node *itr;
	if(caster_guid_parts[1] & HIGHGUID_PLAYER && ((Character*)caster_guid)->group)
		itr = ((Character*)caster_guid)->group->first;
	else if((caster_guid_parts[1] & HIGHGUID_UNIT) && ((creature*)caster_guid)->folowed_char && ((creature*)caster_guid)->folowed_char->group)
		itr = ((creature*)caster_guid)->folowed_char->group->first;
	else return;//it is not case to recast this spell
	float px=((Base_Unit_Object*)caster_guid)->pos_x;
	float py=((Base_Unit_Object*)caster_guid)->pos_y;
	target_list[0].clear();
	target_list[1].clear();
	target_list[2].clear();
	Character *just_a_pointer=(Character *)caster_guid;//!!this is not always a char pointer (most of the time yes)
	while(itr)
	{
		if(itr->p_char!=just_a_pointer && abs(px-itr->p_char->pos_x)<CHAR_AURA_REMOVE_RANGE && abs(py-itr->p_char->pos_y)<CHAR_AURA_REMOVE_RANGE)
		{
			target_list[0].add(itr->p_char->getGUID());
			target_list[1].add(itr->p_char->getGUID());
			target_list[2].add(itr->p_char->getGUID());
		}
		itr = itr->next;
	}	
	if(target_list[0].len==0)
		return;//there is no point to cast it again if we have no targets
	cast_flags = CAST_ACTION_FLAG_CASTER_DEPENDENT | CAST_ACTION_FLAG_ALWAYS_ACTIVE; //do not save on exit and if we are too far away from caster then it is removed
	target_char = NULL;
	target_creature = NULL;
	target_object = NULL;
	target_item = NULL;
	prototype = G_spell_info[spell_id];
	cast_duration = 0;
	spell_duration[0] = prototype->duration[0];
	spell_duration[1] = prototype->duration[1];
	spell_duration[2] = prototype->duration[2];
//	msg_spell_start_cast();
//	msg_spell_can_cast_result(0);
	msg_spell_cast_go();
//	msg_spell_log_execute();
	add_affects_to_targets();
}

//no initialisation 
void Spell_Instance::item_instant_cast_quiet(Item *owner,Base_Unit_Object *owner_owner,uint32 spell_id,uint64 sugested_target)
{
	caster_guid = owner_owner->getGUID();//just to fool target list creation function
	cast_faction = owner_owner->data32[UNIT_FIELD_FACTIONTEMPLATE];
	target_mask=2;
	if(sugested_target)
	{
		if((sugested_target>>32) & HIGHGUID_PLAYER)
		{
			target_char = (Character*)sugested_target;
			caster_char = target_char;
		}
		else if((sugested_target>>32) & HIGHGUID_UNIT) target_creature = (creature*)sugested_target;
		else if((sugested_target>>32) & HIGHGUID_ITEM) target_item = (Item*)sugested_target;
		else if((sugested_target>>32) & HIGHGUID_GAMEOBJECT) target_object = (gameobject_instance*)sugested_target;
	}
	if(spell_id>G_max_spell_id || G_spell_info[spell_id]==NULL)
		return;
	prototype = G_spell_info[spell_id];
	cast_x = owner_owner->pos_x; //required to send spell failed in case it is interrupted
	cast_y = owner_owner->pos_y;
	cast_o = owner_owner->orientation;
	cast_map_id = owner_owner->map_id;
	target_list[0].clear();
	target_list[1].clear();
	target_list[2].clear();
	make_target_list();
	cast_duration = 0;
	spell_duration[0] = prototype->duration[0];
	spell_duration[1] = prototype->duration[1];
	spell_duration[2] = prototype->duration[2];
	caster_guid = owner->getGUID();
	caster_char = NULL;
	add_affects_to_targets();
}

//used when interrupt triggers when fighting
void Spell_Instance::char_instant_cast(uint32 spell_id,uint64 sugested_target)
{
	target_mask=2;
	if(sugested_target)
	{
		if((sugested_target>>32) & HIGHGUID_PLAYER)
			target_char = (Character*)sugested_target;
		else if((sugested_target>>32) & HIGHGUID_UNIT)
			target_creature = (creature*)sugested_target;
	}
	else if(caster_char->target)
	{
		if(caster_char->target->obj_type & HIGHGUID_PLAYER)
			target_char = (Character*)(caster_char->target);
		else if(caster_char->target->obj_type & HIGHGUID_UNIT)
			target_creature = (creature*)(caster_char->target);
	}
	else
	{
		target_char = NULL;
		target_creature = NULL;
	}
	target_object = NULL;
	target_item = NULL;
	prototype = G_spell_info[spell_id];
	cast_x = caster_char->pos_x; //required to send spell failed in case it is interrupted
	cast_y = caster_char->pos_y;
	cast_o = caster_char->orientation;
	cast_map_id = caster_char->map_id;
	target_list[0].clear();
	target_list[1].clear();
	target_list[2].clear();
	make_target_list();
	cast_duration = 0;
	spell_duration[0] = prototype->duration[0];
	spell_duration[1] = prototype->duration[1];
	spell_duration[2] = prototype->duration[2];
	msg_spell_start_cast();
	msg_spell_can_cast_result(0);
	msg_spell_cast_go();
//	msg_spell_log_execute();
	add_affects_to_targets();
}

void Spell_Instance::char_instant_nomana_cast(uint32 spell_id,uint32 end_timestamp,uint64 suggested_target)
{
	target_mask=0;
	target_char = caster_char;
	target_creature = NULL;
	target_object = NULL;
	target_item = NULL;
	prototype = G_spell_info[spell_id];
	cast_x = caster_char->pos_x; //required to send spell failed in case it is interrupted
	cast_y = caster_char->pos_y;
	cast_o = caster_char->orientation;
	cast_map_id = caster_char->map_id;
	target_list[0].clear();
	target_list[1].clear();
	target_list[2].clear();
	if(suggested_target)
	{
		target_list[0].add(suggested_target);
		target_list[1].add(suggested_target);
		target_list[2].add(suggested_target);
	}
	else
	{
		target_list[0].add(caster_char->getGUID());
		target_list[1].add(caster_char->getGUID());
		target_list[2].add(caster_char->getGUID());
	}
	cast_duration = 0;
	if(end_timestamp==-1)
	{
		spell_duration[0] = prototype->duration[0];
		spell_duration[1] = prototype->duration[1];
		spell_duration[2] = prototype->duration[2];
	}
	else 
	{
		spell_duration[0] = (end_timestamp - G_cur_time)*1000;
		spell_duration[1] = spell_duration[0];
		spell_duration[2] = spell_duration[0];
	}
	msg_spell_start_cast();
	msg_spell_can_cast_result(0);
	msg_spell_cast_go();
//	msg_spell_log_execute();
	add_affects_to_targets();
}

void Spell_Instance::cast()
{
    uint8		cast_error;
	//check if caster is player then if he can cast the spell. No checks for other casters
	if(caster_char)
	{
		cast_error = caster_char->can_cast(prototype->spell_id);
		msg_spell_can_cast_result(cast_error);
		//if there was an error casting it then we exit now
		if(cast_error)
			return;
		//if this is a channeled spell then we take extra actions
		caster_char->spell_cooldowns.add(prototype->spell_id,prototype->recovery_time);
		//take power
		caster_char->power -= ((float)(prototype->power_cost));
		//remove items consumed by it
		for(int i=0;i<8;i++)
			if(prototype->reagent[i])
				caster_char->rem_item_id(prototype->reagent[i],prototype->reagent_count[i]);
		//triger on cast event spells
		((Base_Unit_Object*)(caster_guid))->on_cast_spells->trigger_event_spells_char_on_cast(target_list[3].data[0],prototype->spell_id);
	}
	else if(caster_guid_parts[1] & HIGHGUID_UNIT)
		((Base_Unit_Object*)(caster_guid))->on_cast_spells->trigger_event_spells_cr_on_cast(target_list[3].data[0],prototype->spell_id);
 	//targets are read from packet that initilizes this spell + the ones described by this spell
	make_target_list();
	msg_spell_cast_go();
//printf("spell costed %d mana\n",prototype->power_cost);
	//agro target if it is enemy. This is mana agro.Each spell should add diffrent amount of agro to creatures
	//atm we only agro our target and our friends target. Maybe we should agro whole block ?
	if(target_creature)
		if(G_faction_is_enemy[G_max_faction_id*target_creature->data32[UNIT_FIELD_FACTIONTEMPLATE]+cast_faction])
			target_creature->agro_list.add(caster_guid,(float)prototype->power_cost);
	else if(target_char && target_char->target)
		if(G_faction_is_enemy[G_max_faction_id*target_char->target->data32[UNIT_FIELD_FACTIONTEMPLATE]+cast_faction])
			target_char->target->add_agro(caster_guid,(float)prototype->power_cost);
	add_affects_to_targets();
}

void Spell_Instance::add_affects_to_targets()
{
	//add affect to targets
#ifdef _DEBUG
	printf("targets counted for spell %u = %u + %u + %u (unique %u)\n",prototype->spell_id,target_list[0].len,target_list[1].len,target_list[2].len,target_list[3].len);
#endif
	uint32 i,target_itr;
	uint8 is_negative_aura;
	//determine the type of the aura (if there is such)
	if(prototype->effect_base_points[0]<0 || prototype->effect_base_points[1]<0 || prototype->effect_base_points[2]<0)
		is_negative_aura = 1;
	else is_negative_aura=0;
	for(i=0;i<3;i++)
	{
		switch(prototype->effect[i])
		{

//			probably would dodge next attack ?
//			case EFFECT_DODGE:
//			case EFFECT_EVADE:
//			case EFFECT_PARRY:
//			case EFFECT_BLOCK:
//				{
//					float value = prototype->effect_misc_value[i] + ((float)prototype->effect_base_points[i] + G_random.mt_random() % (prototype->effect_die_sides[i]+1) + 1) + prototype->effect_base_dice[i];
//					for(target_itr=0;target_itr<target_list.len*2;target_itr+=2)
//			}break;
//			case EFFECT_OPEN_LOCK:
//				{
//					msg_spell_log_execute();
//					//should list generate a loot list (used at herbs and mining stones)
//				}break;
			case EFFECT_DUEL:
			{
				uint32 gameobject_id=prototype->effect_misc_value[i];
				if(gameobject_id>G_max_gameobjects || !G_gameobject_prototypes[gameobject_id])
				{
#ifdef _DEBUG
					printf("Dual arbiter object template is missing %u\n",gameobject_id);
#endif		
					return;
				}
				if(!target_char)
				{
#ifdef _DEBUG
					printf("Dual target char is not set (sent by client)\n");
#endif
					return;//duel without no target ...
				}
				if(!caster_char)
				{
#ifdef _DEBUG
					printf("Only a character may initiate a duel\n");
#endif
					return;
				}
				//check if target is in our ignore list or not. If yes then we reject it
				//create dual arbiter
				caster_char->duel_info.dual_arbiter = new gameobject_instance;
				caster_char->duel_info.dual_arbiter->init_from_template(G_gameobject_prototypes[gameobject_id]);
				caster_char->duel_info.dual_arbiter->map_id = caster_char->map_id;
				caster_char->duel_info.dual_arbiter->pos_x = (caster_char->pos_x + target_char->pos_x)/2;
				caster_char->duel_info.dual_arbiter->pos_y = (caster_char->pos_y + target_char->pos_y)/2;
				caster_char->duel_info.dual_arbiter->pos_z = (caster_char->pos_z + target_char->pos_z)/2;
				caster_char->duel_info.dual_arbiter->orientation = caster_char->orientation;
				caster_char->duel_info.dual_arbiter->respawn_delay = 0x7FFFFFFF;//no respawn needed
				G_maps[caster_char->map_id]->add_go(caster_char->duel_info.dual_arbiter);
				caster_char->duel_info.dual_arbiter->spawn();
				caster_char->duel_info.initiator = caster_char;
				caster_char->duel_info.target = target_char;
				caster_char->duel_info.spell_id = prototype->spell_id;
				memcpy(&target_char->duel_info,&caster_char->duel_info,sizeof(Duel_Info));
				target_char->duel_info.target = caster_char;
				caster_char->SetUInt64Value(PLAYER_DUEL_ARBITER,caster_char->duel_info.dual_arbiter->getGUID());
				target_char->SetUInt64Value(PLAYER_DUEL_ARBITER,caster_char->duel_info.dual_arbiter->getGUID());

/*	pGameObj->SetFloatValue(OBJECT_FIELD_SCALE_X,1.0f);
    pGameObj->SetUInt32Value(GAMEOBJECT_DISPLAYID, 787 );
    pGameObj->SetUInt32Value(GAMEOBJECT_FACTION, m_caster->getFaction() );
    pGameObj->SetUInt32Value(GAMEOBJECT_TYPE_ID, 16 );
    pGameObj->SetUInt32Value(GAMEOBJECT_LEVEL, m_caster->getLevel()+1 );
    int32 duration = GetDuration(m_spellInfo);
    pGameObj->SetRespawnTime(duration > 0 ? duration/1000 : 0);
    pGameObj->SetSpellId(m_spellInfo->Id);*/

				G_send_packet.opcode = SMSG_DUEL_REQUESTED;
				G_send_packet.data32[0] = caster_char->duel_info.dual_arbiter->getGUIDL();
				G_send_packet.data32[1] = caster_char->duel_info.dual_arbiter->getGUIDH();
				G_send_packet.data32[2] = caster_char->getGUIDL();
				G_send_packet.data32[3] = caster_char->getGUIDH();
				G_send_packet.length = 16;
				target_char->SendMsg(&G_send_packet);
				caster_char->SendMsg(&G_send_packet);
			}
			case EFFECT_ADD_COMBO_POINTS:
			{
				//!it seems 1 combo point is not showned at client side but on second it apears instanteniously each of them
				if(!caster_char)
					return;
				uint8 value ;
				if(prototype->effect_die_sides[i]>1)
					value=(uint8)(prototype->effect_base_points[i] + G_random.mt_random() % prototype->effect_die_sides[i] + prototype->effect_base_dice[i]);
				else value=prototype->effect_base_points[i] + prototype->effect_base_dice[i];
				uint8 cur_points=caster_char->data32[PLAYER_FIELD_BYTES] >> 8;
				cur_points = cur_points + value;
				if(cur_points>5)
					cur_points=5;
				else if(cur_points==0)
					cur_points=1;
				caster_char->SetUInt32Value(PLAYER_FIELD_BYTES,(caster_char->data32[PLAYER_FIELD_BYTES] & 0xFFFF00FF)|(cur_points<<8));
			}break;
			case EFFECT_TRIGGER_SPELL:
			{
				if(caster_char)
					caster_char->instant_spell.char_instant_nomana_cast(prototype->effect_trigger_spell[i],-1,caster_char->selected_object_guid);
				else if(caster_guid_parts[1] & HIGHGUID_UNIT)
					G_instant_spell_instance2.cr_instant_cast((creature*)(caster_guid),prototype->effect_trigger_spell[i],0);
			}break;
			case EFFECT_SUMMON_TOTEM_SLOT1:
			case EFFECT_SUMMON_TOTEM_SLOT2:
			case EFFECT_SUMMON_TOTEM_SLOT3:
			case EFFECT_SUMMON_TOTEM_SLOT4:
				{
					if(!caster_char)
						return;
					uint32 totem_slot=prototype->effect[i]-EFFECT_SUMMON_TOTEM_SLOT1;
					Waypoint_Node *wp_node;
					creature *cr;
					//check if we already have a totem in this slot 
					if(caster_char->totems[totem_slot])
					{
						//we destroy it visualy and refurbish the object later
						G_maps[caster_char->totems[totem_slot]->map_id]->on_creature_exited_block(caster_char->totems[totem_slot]);
						cr=caster_char->totems[totem_slot];
					}
					else 
					{
						cr=new creature;
						caster_char->totems[totem_slot]=cr;
						cr->spawn();
						cr->speed_land_modifyer = 0.00001f;
						cr->speed_water_modifyer = 0.00001f;
						cr->respawn_delay = 0x0FFFFFFF;
						cr->flags1 = CREATURE_FLAG_STAND | CREATURE_FLAG_CASTER;
						//even if it is standing object we still need 1 waypoint for it
						cr->SetUInt64Value(UNIT_FIELD_SUMMONEDBY,caster_char->getGUID());
						cr->SetUInt64Value(UNIT_FIELD_CREATEDBY,caster_char->getGUID());
						//should die off after a while
						cr->db_id = 0;
						cr->suggested_spell_target = caster_guid;
						cr->folowed_char = caster_char;
					}
					wp_node=cr->waypoint_lst.first;
					cr->init_from_template(G_creature_prototypes[prototype->effect_misc_value[i]]);
					cr->data32[UNIT_FIELD_FACTIONTEMPLATE]=caster_char->data32[UNIT_FIELD_FACTIONTEMPLATE];
					cr->pos_x = caster_char->pos_x;
					cr->pos_y = caster_char->pos_y;
					cr->pos_z = caster_char->pos_z;
					cr->orientation = caster_char->orientation;
					cr->map_id = caster_char->map_id;
					cr->data32[UNIT_FIELD_MAXHEALTH]=(uint32)((float)prototype->effect_base_points[i] + G_random.mt_random() % (prototype->effect_die_sides[i]+1) + 1) + prototype->effect_base_dice[i];
				    cr->data32[UNIT_FIELD_BASE_MANA]=0x7FFFFFF;//plenty of mana to be able to cast any spell
					wp_node->dst_x = cr->pos_x;
					wp_node->dst_y = cr->pos_y;
					wp_node->dst_z = cr->pos_z;
					wp_node->dst_o = cr->orientation;
					cr->respawn();
					cr->state1 |= (CREATURE_STATE_PAUSE_MOVEMENT | CREATURE_STATE_DIE_ON_TIMER);//no roaming 
					cr->atimer2 = prototype->duration[i] + G_cur_time_ms;
				}break;/**/
			//when you learn a new skill or advance an already existing one
			case EFFECT_SKILL_STEP:
				{
					uint32 learnskill=prototype->effect_misc_value[i];
					for(target_itr=0;target_itr<target_list[i].len*2;target_itr+=2)
						if(((Base_Unit_Object *)target_list[i].data32[target_itr])->obj_type & HIGHGUID_PLAYER)
						{
							Character *t=(Character *)target_list[i].data32[target_itr];
							uint32 has_pos=666,free_pos=666,it;
							for(it=0;it<PLAYER_SKILL_ENTRY_NUMBER;i++)
								if(t->skill_list[i].lineId==learnskill)
								{
									has_pos=i;
									break;
								}
								else if(free_pos==666 && t->skill_list[i].lineId==0)
									free_pos=i;
							if(has_pos!=666)
							{
								t->skill_list[has_pos].currVal++;
								t->update_mask.SetBit(PLAYER_SKILL_INFO_1_1+i*sizeof(skill_entry)/4+1);
							}
							else if(free_pos!=666)
								t->add_skill(learnskill,1,5);
						}
				}break;
			//can summon X creatures or objects. Target will last x seconds and it is boud to caster
			case EFFECT_SUMMON_PET:
			case EFFECT_SUMMON_GUARDIAN:
			case EFFECT_SUMMON_WILD:
				{
					creature	*tc,*tempc=NULL;
					gameobject	*tempgo=NULL;
					if(!caster_char)
						continue;
//					value = (((float)prototype->effect_base_points[i] + G_random.mt_random() % (prototype->effect_die_sides[i]+1) + 1) + prototype->effect_base_dice[i]);
					//check if we have the template for this creature
					if(!(prototype->effect_misc_value[i]>G_max_creature_prototypes || !G_creature_prototypes[prototype->effect_misc_value[i]]))
						tempc=G_creature_prototypes[prototype->effect_misc_value[i]];
					else if(!(prototype->effect_misc_value[i]>G_max_gameobjects || !G_gameobject_prototypes[prototype->effect_misc_value[i]]))
						tempgo=G_gameobject_prototypes[prototype->effect_misc_value[i]];
					if(!tempc && !tempgo)
						continue;
					if(caster_char->data32[UNIT_FIELD_SUMMON]!=0 && caster_char->data32[UNIT_FIELD_SUMMON+1] & HIGHGUID_UNIT)
					{
						//dismiss old sumoned creature
						tc=(creature *)caster_char->data32[UNIT_FIELD_SUMMON];
						G_maps[tc->map_id]->on_creature_exited_block(tc);
						G_maps[tc->map_id]->del_creature(tc);
						delete tc;
					}
					if(caster_char->data32[UNIT_FIELD_SUMMON]!=0 && caster_char->data32[UNIT_FIELD_SUMMON+1] & HIGHGUID_GAMEOBJECT)
					{
						//dismiss old sumoned totem or whatever gamobject
//						tgo=(gameobject *)caster_char->data32[UNIT_FIELD_SUMMON];
//							G_maps[tgo->map_id]->on_go_exited_block(tgo,G_turn_id);
//						G_maps[tgo->map_id]->del_go(tgo);
//						delete tgo;
					}
					//if we summon a new creature
					if(tempc)
					{
						tc = new creature;
						tc->init_from_template(tempc);
						tc->pos_x = caster_char->pos_x+0.2f;
						tc->pos_y = caster_char->pos_y;
						tc->pos_z = caster_char->pos_z+0.2f;
						tc->orientation = caster_char->orientation;
						tc->map_id = caster_char->map_id;
						tc->atimer1 = G_cur_time_ms;
						tc->folowed_char = caster_char;
						tc->SetUInt64Value(UNIT_FIELD_SUMMONEDBY,caster_char->getGUID());
						tc->SetUInt64Value(UNIT_FIELD_CREATEDBY,caster_char->getGUID());
						tc->SetUInt32Value(UNIT_FIELD_LEVEL,caster_char->data32[UNIT_FIELD_LEVEL]);
						tc->SetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE,caster_char->data32[UNIT_FIELD_FACTIONTEMPLATE]);
			            tc->SetUInt32Value(UNIT_FIELD_BYTES_0,2048);
						tc->SetUInt32Value(UNIT_FIELD_FLAGS, 8);
						tc->SetUInt32Value(UNIT_FIELD_PETNUMBER, 1 );
					    tc->SetUInt32Value(UNIT_FIELD_PET_NAME_TIMESTAMP,0);
						tc->SetUInt32Value(UNIT_FIELD_PETEXPERIENCE, 0);
						tc->SetUInt32Value(UNIT_FIELD_PETNEXTLEVELEXP, -1);
						tc->spawn();
						tc->state1 = CREATURE_STATE_FOLLOW;
//        ((Player*)owner)->PetSpellInitialize();
						caster_char->SetUInt64Value(UNIT_FIELD_SUMMON,tc->getGUID());
					}
					else if (tempgo)
					{
					}
					//update variables
				}break;
			case EFFECT_DISPEL:
				{
					//the number of available dispels
					float value = ((float)prototype->effect_base_points[i] + G_random.mt_random() % (prototype->effect_die_sides[i]+1) + 1) + prototype->effect_base_dice[i];
					//misc_value => 3=disease, 1=magic, 2=curse, 4=poison, 5=invisible, 7=negative spell effect(from user), 8=protection, 9-frenzy
					for(target_itr=0;target_itr<target_list[i].len*2;target_itr+=2)
					{
						//probably we have chosen targets so friend relation is already fullfilled 
//						uint32	caster_faction=(((Base_Unit_Object *)caster_guid)->data32[UNIT_FIELD_FACTIONTEMPLATE];
//						uint32	target_faction=((Base_Unit_Object *)target_list.data32[target_itr])->data32[UNIT_FIELD_FACTIONTEMPLATE];
//						uint8	is_friendly=G_faction_is_friend[caster_faction*G_max_faction_id+target_faction];
						uint32	dispells_remain=(uint32)value;
						//iterate through affect list and remove apropriate effects for x times
						Spell_Affect_node *affect_itr;
						Spell_Affect_List *owner_list=((Base_Unit_Object *)target_list[i].data32[target_itr])->affect_list;
						affect_itr = owner_list->first;
						while(affect_itr)
						{
							if(affect_itr->prototype->dispell_type==prototype->effect_misc_value[i])
//								if((is_friendly && affect_itr->slot < 32) || (is_friendly==0 && affect_itr->slot > 32))
							{
								affect_itr->remove_effect(owner_list->owner_obj);
								dispells_remain--;
								if(dispells_remain==0)
									goto END_THIS_DISPELL_CYLE;
							}
							affect_itr = affect_itr->next;
						}
END_THIS_DISPELL_CYLE:;
					}
				}break;
			case EFFECT_WEAPON_DMG_PERCENT:
				{
					//value is in percent
					float value;
					if(!caster_guid) //can't be casted by items
						break;
					value = (((float)prototype->effect_base_points[i] + G_random.mt_random() % (prototype->effect_die_sides[i]+1) + 1) + prototype->effect_base_dice[i]);
					value *= ((Base_Unit_Object *)caster_guid)->dataf[UNIT_FIELD_MINDAMAGE]/100;//given in percent 
					msg_non_melee_dmg_log((float)value,prototype->school);
					for(target_itr=0;target_itr<target_list[i].len*2;target_itr+=2)
						((Base_Unit_Object *)target_list[i].data32[target_itr])->take_dmg(value,caster_guid,prototype->school);
				}break;
			case EFFECT_CHARGE:
			case EFFECT_LEAP:
				{
					Base_Unit_Object *buc=((Base_Unit_Object *)caster_guid);
					Base_Unit_Object *but=((Base_Unit_Object *)target_list[i].data32[0]);
					buc->orientation = get_orientation(buc->pos_x,buc->pos_y,but->pos_x,but->pos_y);
					if(but->pos_x>buc->pos_x) buc->pos_x = but->pos_x-1;
					else buc->pos_x = but->pos_x+1;
					if(but->pos_y>buc->pos_y) buc->pos_y = but->pos_y-1;
					else buc->pos_y = but->pos_y+1;
					buc->pos_z = but->pos_z + CREATURE_ROAM_LIFT_FROM_GROUND;
					buc->update_obj_pos(NULL);
				}break;
			case EFFECT_EXTRA_ATTACKS:
				{
					float value = ((float)prototype->effect_base_points[i] + G_random.mt_random() % (prototype->effect_die_sides[i]+1) + 1) + prototype->effect_base_dice[i];
					for(target_itr=0;target_itr<target_list[i].len*2;target_itr+=2)
						((Base_Unit_Object *)target_list[i].data32[target_itr])->atimer1 -= (uint32)(value*((Base_Unit_Object *)target_list[i].data32[target_itr])->data32[UNIT_FIELD_BASEATTACKTIME]*((Base_Unit_Object *)target_list[i].data32[target_itr])->speed_attack_modifyer);
				}break;
			case EFFECT_WEAPON_DAMAGE_ADD_NOSCHOOL:
				{
					float value = ((float)prototype->effect_base_points[i] + G_random.mt_random() % (prototype->effect_die_sides[i]+1) + 1) + prototype->effect_base_dice[i];
					msg_non_melee_dmg_log(value,prototype->school);
					for(target_itr=0;target_itr<target_list[i].len*2;target_itr+=2)
						((Base_Unit_Object *)target_list[i].data32[target_itr])->take_dmg(value,caster_guid,prototype->school,0,((Base_Unit_Object *)target_list[i].data32[target_itr])->data32[UNIT_FIELD_LEVEL]);
				}break;
			case EFFECT_QUEST_COMPLETE:
				{
					for(target_itr=0;target_itr<target_list[i].len*2;target_itr+=2)
						if(((Base_Unit_Object *)target_list[i].data32[target_itr])->obj_type & HIGHGUID_PLAYER)
							((Character *)target_list[i].data32[target_itr])->quests_started.finish_quest(prototype->effect_misc_value[i]);
				}break;
			case EFFECT_BIND:
				{
					for(target_itr=0;target_itr<target_list[i].len*2;target_itr+=2)
						if(((Base_Unit_Object *)target_list[i].data32[target_itr])->obj_type & HIGHGUID_PLAYER)
						{
							((Character *)target_list[i].data32[target_itr])->bind_map_id = ((Character *)target_list[i].data32[target_itr])->map_id;
							((Character *)target_list[i].data32[target_itr])->bind_x = ((Character *)target_list[i].data32[target_itr])->pos_x;
							((Character *)target_list[i].data32[target_itr])->bind_y = ((Character *)target_list[i].data32[target_itr])->pos_y;
							((Character *)target_list[i].data32[target_itr])->bind_z = ((Character *)target_list[i].data32[target_itr])->pos_z;
							((Character *)target_list[i].data32[target_itr])->bind_orientation = ((Character *)target_list[i].data32[target_itr])->orientation;
						}
				}break;
			case EFFECT_HEALTH_LEECH:
				{
					float value = ((float)prototype->effect_base_points[i] + G_random.mt_random() % (prototype->effect_die_sides[i]+1) + 1) + prototype->effect_base_dice[i];
					uint8 caster_lvl;
					if(caster_char)
						caster_lvl=caster_char->data32[UNIT_FIELD_LEVEL];
					else if((caster_guid >> 32) & HIGHGUID_UNIT)
						caster_lvl=((creature*)(caster_guid))->data32[UNIT_FIELD_LEVEL];
					else caster_lvl=0;
					//maybe we should check if we are draining mana or not
					float total_heal=0;
					for(target_itr=0;target_itr<target_list[i].len*2;target_itr+=2)
					{
						float ret=((Base_Unit_Object *)target_list[i].data32[target_itr])->take_dmg(value,caster_guid,prototype->school,0,caster_lvl);
						total_heal +=ret;
						if(((Base_Unit_Object *)target_list[i].data32[target_itr])->obj_type & HIGHGUID_PLAYER)
							msg_non_melee_dmg_log((float)ret,prototype->school);
					}
					((Base_Unit_Object *)caster_guid)->health += total_heal;
					msg_heal_unit(caster_guid,(uint32)total_heal,0);
				}break;
			case EFFECT_ENVIRONMENTAL_DAMAGE:
				{
					float value = ((float)prototype->effect_base_points[i] + G_random.mt_random() % (prototype->effect_die_sides[i]+1) + 1) + prototype->effect_base_dice[i];
					for(target_itr=0;target_itr<target_list[i].len*2;target_itr+=2)
					{
						((Base_Unit_Object *)target_list[i].data32[target_itr])->take_dmg(value,caster_guid,prototype->school,1);
						//send packet to owner that we made some dmg
/*						if((uint32)caster_guid_parts[1] & HIGHGUID_PLAYER)
						{
							G_send_packet.opcode = SMSG_SPELLNONMELEEDAMAGELOG;
							G_send_packet.data64[0] = target_list.data[target_itr/2];
							G_send_packet.data64[1] = caster_guid;
							G_send_packet.data32[4] = prototype->spell_id;
							G_send_packet.data32[5] = (uint32)(value);
							G_send_packet.data32[6] = 0;
							G_send_packet.data32[7] = 0;
							G_send_packet.data32[8] = 0;
							G_send_packet.data32[9] = 0;
							G_send_packet.data32[10] = 0;
							G_send_packet.length = 40;
							((Character*)caster_guid)->pClient->SendMsg(&G_send_packet);
						}*/
					}
				}break;
			case EFFECT_POWER_DRAIN:
				{
					float value = ((float)prototype->effect_base_points[i] + G_random.mt_random() % (prototype->effect_die_sides[i]+1) + 1) + prototype->effect_base_dice[i];
					//maybe we should check if we are draining mana or not 
					for(target_itr=0;target_itr<target_list[i].len*2;target_itr+=2)
					{
						if(((Base_Unit_Object *)target_list[i].data32[target_itr])->power>value)
						{
							((Base_Unit_Object *)caster_guid)->power += value;
							((Base_Unit_Object *)target_list[i].data32[target_itr])->power -= value;
						}
						else
						{
							((Base_Unit_Object *)caster_guid)->power += ((Base_Unit_Object *)target_list[i].data32[target_itr])->power;
							((Base_Unit_Object *)target_list[i].data32[target_itr])->power -= 0;
						}
					}
				}break;
			case EFFECT_RESURRECT_FLAT:
				{
				if(	target_char &&	!(target_char->state1 & PLAYER_STATE_CORPSE) &&	(target_char->state1 & PLAYER_STATE_DEAD) )
					{
						target_char->health = (float)prototype->effect_base_points[i]+G_random.mt_random() % prototype->effect_die_sides[i] + prototype->effect_base_dice[i];
						target_char->power = (float)prototype->effect_misc_value[i] + G_random.mt_random() % prototype->effect_die_sides[i] + prototype->effect_base_dice[i];
						target_char->Send_SMSG_FORCE_MOVE_UNROOT();
						target_char->SetUInt32Value(UNIT_FIELD_FLAGS,UNIT_FLAG_NON_PVP_PLAYER);
						target_char->flag_clr(PLAYER_FLAGS, PLAYER_FLAG_DEAD);
						target_char->state1 &=~(PLAYER_STATE_DEAD | PLAYER_STATE_CORPSE | PLAYER_STATE_IN_COMBAT);
						target_char->atimer2 = 0xFFFFFFFF;
					}
				}break;
			case EFFECT_CREATE_ITEM:
				{
					Item *new_item;
					if(prototype->effect_create_item[i]<G_max_item_id && G_item_prototypes[prototype->effect_create_item[i]]!=0)
					{
						new_item = G_Object_Pool.Get_fast_New_item();
						new_item->create_from_template(G_item_prototypes[prototype->effect_create_item[i]]);
						new_item->created_at = G_cur_time; //mark the creation of the item because it is spell created and maybe after a while it should dissapear
						new_item->data32[ITEM_EXTRA_FLAGS] |= ITEM_IS_SPELL_CREATED;
						*(uint64*)&new_item->data32[ITEM_FIELD_CREATOR] = caster_guid;
						 uint32 value= prototype->effect_base_points[i] + G_random.mt_random() % (prototype->effect_die_sides[i]+1) + prototype->effect_base_dice[i];
						if(caster_char)
							value += caster_char->data32[UNIT_FIELD_LEVEL]*prototype->effect_dice_per_lvl[i];
						new_item->data32[ITEM_FIELD_STACK_COUNT] = value;
						//try to add to targets
						for(target_itr=0;target_itr<target_list[i].len*2;target_itr+=2)
							if(target_list[i].data32[target_itr+1] & HIGHGUID_PLAYER)
							{
								Character *p_char=((Character *)target_list[i].data32[target_itr]);
								if(!p_char->auto_store_item(new_item))
								{
									p_char->msg_inv_change_result(NULL,NULL,INV_ERR_INVENTORY_FULL);
									G_Object_Pool.Release_item(new_item);
									return; //there is no point to continue if there is no more room in inventory
								}
							}
					}
				}break;
			case EFFECT_SCHOOL_DAMAGE:
				{
					float dmg=((float)prototype->effect_base_points[i] + G_random.mt_random() % (prototype->effect_die_sides[i]+1) + 1) + prototype->effect_base_dice[i];
					if(prototype->dmg_multiply_for_combo[i]!=0 && caster_char && caster_char->player_powertype == Unit_Power_Type_Energy)
					{
						uint8 combo_points=(uint8)(caster_char->data32[PLAYER_FIELD_BYTES] >> 8);
						if(combo_points>0)
						{
							dmg += (prototype->dmg_multiply_for_combo[i]*combo_points); //multiply dmg by number of combo points
							caster_char->SetUInt32Value(PLAYER_FIELD_BYTES,(caster_char->data32[PLAYER_FIELD_BYTES] & 0xFFFF00FF)); // set combo points 0
						}
					} 
					msg_non_melee_dmg_log(dmg,prototype->school);
					for(target_itr=0;target_itr<target_list[i].len*2;target_itr+=2)
					{
						((Base_Unit_Object *)target_list[i].data32[target_itr])->take_dmg(dmg,caster_guid,prototype->school);
						//send packet to owner that we made some dmg
/*						if((uint32)caster_guid_parts[1] & HIGHGUID_PLAYER)
						{
							G_send_packet.opcode = SMSG_SPELLNONMELEEDAMAGELOG;
							G_send_packet.data64[0] = target_list.data[target_itr/2];
							G_send_packet.data64[1] = caster_guid;
							G_send_packet.data32[4] = prototype->spell_id;
							G_send_packet.data32[5] = (uint32)(damage);
							G_send_packet.data32[6] = 0;
							G_send_packet.data32[7] = 0;
							G_send_packet.data32[8] = 0;
							G_send_packet.data32[9] = 0;
							G_send_packet.data32[10] = 0;
							G_send_packet.length = 40;
							((Character*)caster_guid)->pClient->SendMsg(&G_send_packet);
						}*/
					}
					if(caster_char)
						caster_char->try_force_enter_combat(target_list[i].data[0]);/**/
//printf("starting atack with creature\n");
//#ifdef _DEBUG
//				LOG.outString ("Spell: Casted a damage spell\n");
//#endif
				}break;
		    case EFFECT_DUMMY:
				{
				}break;
			case EFFECT_SCRIPT_EFFECT: //this can be heal and arcane missle too
			case EFFECT_HEAL: 
				{
					float heal=((float)prototype->effect_base_points[i] + G_random.mt_random() % (prototype->effect_die_sides[i]+1) + 1) + prototype->effect_base_dice[i];
					if(caster_char)
						heal = (heal + caster_char->spell_extra_healing)*caster_char->spell_extra_healing_pct;
					if(heal<=0)
						break;
					for(target_itr=0;target_itr<target_list[i].len*2;target_itr+=2)
					{
						((Base_Unit_Object *)target_list[i].data32[target_itr])->health += heal;
						msg_heal_unit(target_list[i].data[i/2],(uint32)heal,0);
/*						Base_Unit_Object *target=((Base_Unit_Object *)target_list.data32[target_itr]);
						target->health += heal;
						if((target_list.data32[target_itr+1] & HIGHGUID_PLAYER) && ((Character*)target)->spell_extra_healing)
						{
							float t_heal=(heal + ((Character*)target)->spell_extra_healing)*((Character*)target)->spell_extra_healing_pct;
							if(t_heal>0)
								target->health += t_heal;
						}
						else target->health += heal;*/
					}
#ifdef _DEBUG
				LOG.outString ("Spell: Casted a healing spell\n");
#endif
				}break;
			case EFFECT_TELEPORT_UNITS:
				{
					if(prototype->spell_id == 8690)
						if(target_char)teleport(target_char,target_char->bind_map_id,target_char->bind_x,target_char->bind_y,target_char->bind_z,target_char->bind_orientation);
				}break;
			case EFFECT_ENERGIZE:
				{
					float energize=((float)prototype->effect_base_points[i] + G_random.mt_random() % (prototype->effect_die_sides[i]+1) + 1) + prototype->effect_base_dice[i];
					if(prototype->effect_misc_value[i]==Unit_Power_Type_Rage)
						energize = energize/10;//the value is in percent -> 1000/100
					for(target_itr=0;target_itr<target_list[i].len*2;target_itr+=2)
						((Base_Unit_Object *)target_list[i].data32[target_itr])->power += energize;
				}break;
			case EFFECT_LEARN_SPELL:
				{
					if(!target_list[i].data32[0])
						break;
					if(target_list[i].data32[1] & HIGHGUID_PLAYER)
					{
						((Character*)target_list[i].data32[0])->spellbook.add(prototype->effect_trigger_spell[i]);
						//cast the learning spell - w
						G_send_packet.opcode = SMSG_LEARNED_SPELL;
						G_send_packet.data32[0] = prototype->effect_trigger_spell[i];
						G_send_packet.length = 4;
						((Character*)target_list[i].data32[0])->pClient->SendMsg(&G_send_packet);
					}
				}break;
			//aply are aon more then a few targets
			case EFFECT_APPLY_AREA_AURA:
			//periodicaly apply efect only if target is in range
			case EFFECT_PERSISTENT_AREA_AURA:
			//aply effect for a period
			case EFFECT_APPLY_AURA: 
				{
//					uint64 t_caster_guid;
//					if(item_caster_guid)
//					{
//                        t_caster_guid=caster_guid;
//						caster_guid = item_caster_guid;
//					}
					//printf("received a SPELL_AURA aura with name, tp1=%u,tp2=%u,tc=%u\n",prototype->effect_apply_aura_name[i],target_player1,target_player2,target_creature);
					//todo: check if efect is stackable
					Spell_Affect_node *new_affect;
					new_affect = new Spell_Affect_node;
					new_affect->cast_flags = cast_flags;
					new_affect->value = ((float)prototype->effect_base_points[i] + G_random.mt_random() % (prototype->effect_die_sides[i]+1) + 1) + prototype->effect_base_dice[i];
					//just show everithyng for creatures :) 
					if(prototype->effect_amplitude[i]==0)
					{
						if(cast_flags & (CAST_ACTION_FLAG_ALWAYS_ACTIVE | CAST_ACTION_FLAG_CASTER_DEPENDENT))
							new_affect->timer_interval = CHAR_AURA_TO_GROUP_RECHECK_INTERVAL;
						else if(cast_flags & (CAST_ACTION_FLAG_ALWAYS_ACTIVE | CAST_ACTION_FLAG_LOCATION_DEPENDENT))
						{
							new_affect->timer_interval = CHAR_AURA_TO_LOCATION_RECHECK_INTERVAL;
							new_affect->values[6] = cast_x;
							new_affect->values[5] = cast_y;
							new_affect->values[4] = cast_z;
							new_affect->values[3] = cast_o;
						}
						else new_affect->timer_interval = MAX_TIME_FOR_AURAS; //watch the division by 0 error and the time loop
					}
					else new_affect->timer_interval = prototype->effect_amplitude[i];
					if(item_caster_guid) new_affect->caster_guid = item_caster_guid; //required for stacking
					else new_affect->caster_guid = caster_guid;//required for dmg spells
					new_affect->time_next_trigger = G_cur_time_ms+new_affect->timer_interval; //this should contain when will trigger again the effect of the affect
					new_affect->start_time = G_cur_time_ms;
					new_affect->start_time_sv = G_cur_time;
					if(spell_duration[i]==-1) 
					{
						new_affect->end_time = spell_duration[i];
						new_affect->end_time_sv = spell_duration[i];
//printf("setting spell duration to infinite %u,cur time is %u\n",spell_duration[i],G_cur_time_ms);
//						new_affect->end_time_sv = G_cur_time + 604800;//add only one week so no owerflow occures !!
					}
					else
					{
						new_affect->end_time = G_cur_time_ms + spell_duration[i];
						new_affect->end_time_sv = G_cur_time + spell_duration[i]/1000;//in s
					}
					new_affect->prototype = prototype;
					new_affect->aura_ind = i;
					new_affect->aura_name = prototype->effect_apply_aura_name[i];
//printf("new aura interval is %u, aura name is %u,spell duration %u\n",new_affect->timer_interval,prototype->effect_apply_aura_name[i],spell_duration[i]);
					if(target_list[i].len==1)
					{
//printf("aura has 1 target\n");
						if(target_list[i].affect_slot[0]==0xFE)
						{
							if(target_list[i].data32[1] & HIGHGUID_UNIT)
							{
								target_list[i].affect_slot[0]=((Base_Unit_Object *)target_list[i].data32[0])->get_free_aura_slot(1,prototype->spell_id);
//printf("slot %d chosen for creature\n",target_list[i].affect_slot[0]);
							}
							else target_list[i].affect_slot[0]=((Base_Unit_Object *)target_list[i].data32[0])->get_free_aura_slot(is_negative_aura,prototype->spell_id);
						}
						if(target_list[i].affect_slot[0]!=0xFF)
						{
//printf("adding aurta to slot %d \n",target_list[i].affect_slot[0]);
							new_affect->slot = target_list[i].affect_slot[0];
							uint8 ret=((Base_Unit_Object *)target_list[i].data32[0])->affect_list->add(new_affect);
							if(ret)	msg_spell_failed(ret);
						}
						else msg_spell_failed(CAST_FAIL_UNKNOWN_REASON);
					}
					else
					{
						Spell_Affect_node *templ_affect;
						templ_affect = new_affect;
						uint32 t=0;
						for(target_itr=0;target_itr<target_list[i].len*2;target_itr+=2)
						{
							new_affect = new Spell_Affect_node;
							memcpy(new_affect,templ_affect,sizeof(Spell_Affect_node));
							if(target_list[i].affect_slot[t]==0xFE)
							{
								if(target_list[i].data32[target_itr+1] & HIGHGUID_UNIT)
									target_list[i].affect_slot[t]=((Base_Unit_Object *)target_list[i].data32[0])->get_free_aura_slot(1,prototype->spell_id);
								else target_list[i].affect_slot[t]=((Base_Unit_Object *)target_list[i].data32[0])->get_free_aura_slot(is_negative_aura,prototype->spell_id);
							}
							if(target_list[i].affect_slot[target_itr]!=0xFF)
							{
								new_affect->slot = target_list[i].affect_slot[t];
								uint8 ret=((Base_Unit_Object *)target_list[i].data32[target_itr])->affect_list->add(new_affect);
								if(ret)	msg_spell_failed(ret);
							}
							else msg_spell_failed(CAST_FAIL_UNKNOWN_REASON);
							t++;
						}//end for
						delete templ_affect;
					}//end else not 1 target
//				if(item_caster_guid)
//					caster_guid = t_caster_guid;
			}break; //end case
		   default:
		   {
#ifdef _DEBUG
			   if(prototype->effect[i]!=0)
				   LOG.outString ("Spell: Unknown spell effect %u for spell id=%u\n",prototype->effect[i],prototype->spell_id);
#endif
		   }break;
		}
	}
}

Spell_Affect_List::Spell_Affect_List()
{
	first = NULL;
	owner_obj = NULL;
//	last_update = G_cur_time_ms;
}

uint8 Spell_Affect_List::add(Spell_Affect_node *new_node)
{
	//check if it is already in list. we remove the one which has a weaker effect
//printf("adding aura\n");
	if(!(new_node->cast_flags & CAST_ACTION_FLAG_STACK_WITH_ANY_OTHER))
	{
		Spell_Affect_node *another_instance;
		//if this is a paladin seal then we can have only 1 seal active at a time
		if(new_node->prototype->custom_flags & SPELL_GROUP_PALADIN_SEAL)
		{
			remove_seals_from_caster(new_node->caster_guid);
			another_instance = NULL;
		}
		else another_instance = find(new_node->caster_guid,new_node->prototype->spell_id,new_node->aura_name);
//printf("aura is not stackable,spell %u name %u\n",new_node->prototype->spell_id,new_node->prototype->effect_apply_aura_name[new_node->aura_ind]);
		if(another_instance)
		{
//printf("aura has another instance\n");
			if((another_instance->value > new_node->value))
			{
//printf("found same instance of the affect %u\n",new_node->prototype->effect_apply_aura_name[new_node->aura_ind]);
				//destroy new one because we keep the old one
				delete new_node;
				return CAST_FAIL_MORE_POWERFUL_SPELL_ACTIVE;
			}
			else
			{
				if( another_instance->end_time < new_node->end_time &&
					another_instance->end_time_sv < new_node->end_time_sv)
				{
					another_instance->end_time = new_node->end_time;
					another_instance->end_time_sv = new_node->end_time_sv;
					if(owner_obj->obj_type & HIGHGUID_PLAYER)
					{
						G_send_packet.opcode = SMSG_UPDATE_AURA_DURATION;
						G_send_packet.data[0] = another_instance->slot;
						*(uint32*)&G_send_packet.data[1] = new_node->end_time - G_cur_time_ms;
						G_send_packet.length = 5;
						owner_obj->SendMsg(&G_send_packet);
					}
					delete new_node;
					return 0;
				}
				else del(another_instance); //dump old one
//printf("found older instance of the affect %u\n",new_node->prototype->effect_apply_aura_name[new_node->aura_ind]);
			}
		}
	}
#ifdef AURA_CAN_EXPIRE_DIFFRENTLY_FOR_SPELLS
	owner_obj->affects_in_aura_slot[new_node->slot]++;
#endif
	//we arrived here means we can insert it
	new_node->next = first;
	if(first)first->prev = new_node;
	first = new_node;
	new_node->apply_effect(owner_obj);
	//update owner so client will show this aura
	owner_obj->add_aura_icon_to_slot(new_node->slot,new_node->prototype->spell_id);
	if((owner_obj->obj_type & HIGHGUID_PLAYER) && !(new_node->cast_flags & CAST_ACTION_FLAG_ITEM_ENCHANTMENT))
	{
//printf("adding aura %u to slot : %u\n",new_node->prototype->spell_id,slot);
		G_send_packet.opcode = SMSG_UPDATE_AURA_DURATION;
		G_send_packet.data[0] = new_node->slot;
		*(uint32*)&G_send_packet.data[1] = new_node->end_time - G_cur_time_ms;
		G_send_packet.length = 5;
		owner_obj->SendMsg(&G_send_packet);
//printf("added new aura to char, start=%u,end=%u,server=%u\n",new_node->start_time,new_node->end_time,G_cur_time_ms);
//printf("new aura duration=%d\n",new_node->end_time - G_cur_time_ms);
	}
	return 0;
}

void Spell_Affect_List::del(Spell_Affect_node *p_node)
{
#ifdef AURA_CAN_EXPIRE_DIFFRENTLY_FOR_SPELLS
	if(owner_obj->affects_in_aura_slot[p_node->slot]==1)
	{
		owner_obj->affects_in_aura_slot[p_node->slot]=0;
#endif
		owner_obj->SetUInt32Value(UNIT_FIELD_AURA + p_node->slot, 0);
		uint8 flagslot = p_node->slot >> 3;
		uint32 value = owner_obj->data32[UNIT_FIELD_AURAFLAGS + flagslot];
		value &= 0xFFFFFFFF ^ (0xF << ((p_node->slot & 7) << 2));
		owner_obj->SetUInt32Value(UNIT_FIELD_AURAFLAGS + flagslot, value);
		p_node->remove_effect(owner_obj); //remove effects of this affect (only those who require)
//printf("deleting an aura from player endtime=%u,cur_time=%u\n",p_node->end_time,G_cur_time_ms);
		if(p_node->prev)p_node->prev->next = p_node->next;
		if(p_node->next)p_node->next->prev = p_node->prev;
		if(p_node == first && first)
		first = first->next;
		delete p_node;
#ifdef AURA_CAN_EXPIRE_DIFFRENTLY_FOR_SPELLS
	}
#endif
}

void Spell_Affect_List::cancel_spell(uint32 spell_id)
{
	Spell_Affect_node *affect_itr,*next;
	affect_itr = first;
	while(affect_itr)
	{
		next=affect_itr->next;
		if(affect_itr->prototype->spell_id==spell_id)
			del(affect_itr);
		affect_itr = next;
	}
}

void Spell_Affect_List::update()
{
	Spell_Affect_node *affect_itr,*next;
	affect_itr = first;
//	uint32 time_diff;
	//!!sometimes time_diff is very large
//	time_diff = G_cur_time_ms - last_update;
	while(affect_itr)
	{
		next=affect_itr->next;
		//update affect. Check if we have to delete it
		//!!! we might refresh the world so rarely that affect should have done it's effect more then once
		//!!! be carefull about creatures that have efects on them but do not get updated = > next time pool will be huge
		if((affect_itr->cast_flags & CAST_ACTION_FLAG_ALWAYS_ACTIVE) && (affect_itr->time_next_trigger <= G_cur_time_ms))
		{
			//these auras require special scripting and it is enough to call them once only
			affect_itr->update(owner_obj);
			affect_itr->time_next_trigger = G_cur_time_ms + affect_itr->timer_interval;
		}
		else
		{
			while(affect_itr->time_next_trigger <= G_cur_time_ms && affect_itr->time_next_trigger<affect_itr->end_time)
			{
				affect_itr->apply_effect(owner_obj);
				affect_itr->time_next_trigger += affect_itr->timer_interval;
			}
		}
		if(affect_itr->end_time <= G_cur_time_ms)
		{
//printf("spell aura efect has expired, end time %u cur time %u\n",affect_itr->end_time,G_cur_time_ms);
			del(affect_itr);
		}
		//next affect if we didn't delete it 
		affect_itr = next;
	}
//	last_update = G_cur_time_ms;
}

void Spell_Affect_List::apply_effects()
{
	Spell_Affect_node *affect_itr;
	affect_itr = first;
	while(affect_itr)
	{
		affect_itr->apply_effect(owner_obj);
		affect_itr = affect_itr->next;
	}
}

void Spell_Affect_List::remove_effects()
{
	Spell_Affect_node *affect_itr;
	affect_itr = first;
	while(affect_itr)
	{
		affect_itr->remove_effect(owner_obj);
		affect_itr = affect_itr->next;
	}
}

void Spell_Affect_List::on_game_interrupt(uint32 int_flags)
{
	Spell_Affect_node *affect_itr;
	affect_itr = first;
	while(affect_itr)
	{
		if(affect_itr->prototype->aura_interrupt_flags & int_flags)
		{
			Spell_Affect_node *t_cur;
			t_cur=affect_itr;
			affect_itr = affect_itr->next;
			del(t_cur);
		}
		else affect_itr = affect_itr->next;
	}
}

void Spell_Affect_List::remove_seals_from_caster(uint64	caster_guid)
{
	Spell_Affect_node *affect_itr;
	affect_itr = first;
	while(affect_itr)
	{
		if((affect_itr->prototype->custom_flags & SPELL_GROUP_PALADIN_SEAL) && caster_guid==affect_itr->caster_guid)
		{
			Spell_Affect_node *t_cur;
			t_cur=affect_itr;
			affect_itr = affect_itr->next;
			del(t_cur);
		}
		else affect_itr = affect_itr->next;
	}
}

void Spell_Affect_List::remove_stealth()
{
	Spell_Affect_node *affect_itr;
	affect_itr = first;
	while(affect_itr)
	{
		if(affect_itr->aura_name==SPELL_AURA_MOD_STEALTH)
		{
			Spell_Affect_node *t_cur;
			t_cur=affect_itr;
			affect_itr = affect_itr->next;
			del(t_cur);
		}
		else affect_itr = affect_itr->next;
	}
}

void Spell_Affect_node::msg_aura_periodic_log(uint64 target_guid)
{
	G_send_packet.opcode = SMSG_PERIODICAURALOG;
	G_send_packet.data[0] = 0xFF;
	*(uint64*)(G_send_packet.data+1) = target_guid;
	G_send_packet.data[9] = 0xFF;
	*(uint64*)(G_send_packet.data+10) = caster_guid;
	*(uint32*)(G_send_packet.data+18) = prototype->spell_id;
	*(uint32*)(G_send_packet.data+22) = 0x01;//block count ?
	*(uint32*)(G_send_packet.data+26) = aura_name;
	*(uint32*)(G_send_packet.data+30) = (uint32)value;
	*(uint32*)(G_send_packet.data+34) = prototype->school;
	*(uint32*)(G_send_packet.data+38) = 0;
	*(uint32*)(G_send_packet.data+42) = 0;
	G_send_packet.length = 46;
	if(caster_guid_parts[1] & HIGHGUID_PLAYER)
		((Character*)caster_guid_parts[0])->SendMsg(&G_send_packet);
	else if(target_guid>>32 & HIGHGUID_PLAYER)
		((Character*)target_guid)->SendMsg(&G_send_packet);
}

void Spell_Affect_node::apply_effect(Base_Unit_Object	*owner_obj)
{
#ifdef _DEBUG
printf("applying new aura effect %u\n",aura_name);
#endif
	switch (aura_name)
	{	
/*	not tested yet,will uncomment them when i find the spell that requires them to be able to debug them
	case SPELL_AURA_TRACK_CREATURES:
		{
			if(owner_char)
				owner_char->SetUInt32Value(PLAYER_TRACK_CREATURES,prototype->effect_misc_value[aura_ind]);
		}break;
	case SPELL_AURA_TRACK_RESOURCES:
		{
			if(owner_char)
				owner_char->SetUInt32Value(PLAYER_TRACK_RESOURCES,prototype->effect_misc_value[aura_ind]);
		}break;
	case SPELL_AURA_ADD_FLAT_MODIFIER:
	case SPELL_AURA_ADD_PCT_MODIFIER:
		{
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
			{
				uint8 op = prototype->effect_misc_value[aura_ind];
				int32 value = prototype->effect_base_points[aura_ind]+1;
				uint8 type = prototype->effect_apply_aura_name[aura_ind];
//				uint32 mask = prototype->EffectItemType[m_effIndex];
				if (!op) return;
				uint16 send_val=0, send_mark=0;
				int16 tmpval=value;
				uint32 shiftdata=0x01, Opcode=SMSG_SET_FLAT_SPELL_MODIFIER;
				if(tmpval > 0)
				{
					send_val =  tmpval+1;
					send_mark = 0x0;
				}
				else if(tmpval < 0)
				{
					send_val  = 0xFFFF + (tmpval+2);
					send_mark = 0xFFFF;
				}
				if (type == SPELL_AURA_ADD_FLAT_MODIFIER) G_send_packet.opcode = SMSG_SET_FLAT_SPELL_MODIFIER;
				else if (type == SPELL_AURA_ADD_PCT_MODIFIER) G_send_packet.opcode = SMSG_SET_PCT_SPELL_MODIFIER;
				G_send_packet.length = 6;
				for(int eff=0;eff<32;eff++)
				{
//					if ( mask & shiftdata )
					{
						G_send_packet.data[0] = eff;
						G_send_packet.data[1] = op;
						*(uint16*)&G_send_packet.data[2] = send_val;
						*(uint16*)&G_send_packet.data[4] = send_mark;
						owner_obj->SendMsg(&G_send_packet);
					}
					shiftdata=shiftdata<<1;
				}
			}
		}break;
	case SPELL_AURA_MOD_BASE_RESISTANCE_PCT:
	case SPELL_AURA_MOD_RESISTANCE_PCT:
		{
			value = value/100;
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
			{
				if(prototype->effect_misc_value[aura_ind]>=PLAYER_USED_DMG_TYPES)
				{
					for(int i=0;i<PLAYER_USED_DMG_TYPES;i++)
						((Character*)owner_obj)->spell_res_pct[i] += value;
				}
				else ((Character*)owner_obj)->spell_res_pct[prototype->effect_misc_value[aura_ind]] += value; //saw examples only for armor 
			}
			else if(owner_obj->obj_type & HIGHGUID_UNIT)
			{
				values[0]=owner_obj->data32[UNIT_FIELD_RESISTANCES]*value;
				owner_obj->data32[UNIT_FIELD_RESISTANCES] += values[0];
			}
			owner_obj->on_spell_change_resistance();
		}break;
	case SPELL_AURA_MOD_DAMAGE_TAKEN:
	case SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN:
		{
			Health_Shield_Node *new_node=new Health_Shield_Node;
			new_node->dmg_type_flags = prototype->effect_misc_value[aura_ind] + 1;//only fizical dmg was in spell list
			new_node->mana_conversion = 0;
			new_node->shield_remain = -value;
			new_node->flags1 = HEALTH_SHIELD_FLAG_PERSISTENT_INSTANT;
			new_node->parent_spell_list_node = this;
			*(Health_Shield_Node**)&values[0] = new_node;
			owner_obj->health_shield->add(new_node);
		}break;
	case SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN_PCT:
		{
			Health_Shield_Node *new_node=new Health_Shield_Node;
			new_node->dmg_type_flags = prototype->effect_misc_value[aura_ind] + 1;//only fizical dmg was in spell list
			new_node->mana_conversion = 0;
			new_node->dmg_pct = -value/100;
			new_node->flags1 = HEALTH_SHIELD_FLAG_PERSISTENT_INSTANT | ;
			new_node->parent_spell_list_node = this;
			*(Health_Shield_Node**)&values[0] = new_node;
			owner_obj->health_shield->add(new_node);
		}break;
	case SPELL_AURA_FORCE_REACTION:
		{
			if(owner_obj->obj_type & HIGHGUID_PLAYER)			//save old standing
			{
				//lookup the position in our reputation list
				int vect_index=NUMBER_OF_FACTIONS;
				for(int i=0;i<NUMBER_OF_FACTIONS;i++)
					if((Character*)owner_obj)->reputation[i]==prototype->effect_misc_value[aura_ind])
					{
						vect_index=i;
						break;
					}
				if(vect_index==NUMBER_OF_FACTIONS)
				{
					values[1]=NUMBER_OF_FACTIONS;
					break;
				}
				//save standing
				values[0] = ((Character*)owner_obj)->reputation_val[vect_index];
				values[1] = vect_index;
				//set new standing
				//set your reputation with a specific faction 
				G_send_packet.opcode = SMSG_SET_FACTION_STANDING;
				G_send_packet.data32[0] = 1; //visible faction
				G_send_packet.data32[1] = vect_index; //reputaion_list_id
				G_send_packet.data32[2] = value; //standing
				G_send_packet.length = 12;
			}
		}break;
	case SPELL_AURA_RETAIN_COMBO_POINTS:
		{
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
			{
				uint8 comboPoints = (owner_obj->data32[PLAYER_FIELD_BYTES] >> 8) + value;
				owner_obj->SetUInt32Value(PLAYER_FIELD_BYTES,(owner_obj->data32[PLAYER_FIELD_BYTES] && 0x00FF) | (comboPoints << 8));
			}
		}break;
	case SPELL_AURA_ADD_TARGET_TRIGGER:
		{
			//i think these are actually talents. It will add one on event spell to target, this spell should trigger only for specific spels. Don't know how to get the list for that
			owner_obj->on_cast_spells->add(prototype->effect_trigger_spell[aura_ind],(uint8)value,-1);
		}break;
	case SPELL_AURA_OVERRIDE_CLASS_SCRIPTS:
		{
			//this will customize som espells. Have to work more on this
		}break;
	case SPELL_AURA_ADD_CASTER_HIT_TRIGGER:
		{
			//no examples found 
		}break;
	case SPELL_AURA_MOD_MECHANIC_RESISTANCE:
		{
			if(owner_obj->obj_type & HIGHGUID_UNIT)
				((Character*)(owner_obj))->mechanic_rezistance += value;
		}break;
	case SPELL_AURA_DAMAGE_SHIELD:*/
	case SPELL_AURA_MOD_STEALTH:
		{
			//while stealthed we generate no threath
			owner_obj->state1 |= UNIT_STATE_STEALTHED;
			values[0] = (float)owner_obj->threat_generated;
			owner_obj->threat_generated = 0;
		}break;
	case SPELL_AURA_MANA_SHIELD:
		{
			Health_Shield_Node *new_node=new Health_Shield_Node;
			new_node->dmg_type_flags = HEALTH_SHIELD_DMG_TYPE_FLAG_ALL;
			new_node->mana_conversion = 2; //2 mana for each dmg
			new_node->shield_remain = value;
			new_node->parent_spell_list_node = this;
			*(Health_Shield_Node**)&values[0] = new_node;
			owner_obj->health_shield->add(new_node);
		}break;
	case SPELL_AURA_PERIODIC_HEAL:
		{
			if(values[0]!=(float)end_time)//just a value to make sure we don;t initialize it twice
			{
				if(owner_obj->obj_type & HIGHGUID_PLAYER)
				{
					Character *p_char=(Character *)owner_obj;
					value = (value + p_char->spell_extra_healing)*p_char->spell_extra_healing_pct;
				}
				values[0]=(float)end_time;
			}
			owner_obj->health += value;
			msg_heal_unit(owner_obj->getGUID(),caster_guid,(uint32)value,0,prototype->spell_id);
		}break;
	case SPELL_AURA_PROC_TRIGGER_DAMAGE:
		{
			//must be made to use chance and charges
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
			{
				//try to add them to be fast
				if(prototype->proc_charges==0 && prototype->proc_chance>=90)
				{
					((Character*)owner_obj)->spell_min_dmg[prototype->school] += value;
					((Character*)owner_obj)->spell_max_dmg[prototype->school] += (uint32)value;
				}
				//this is alot slower solution
				else values[0] =	((Character*)owner_obj)->on_attack_spell_dmg.add(prototype->proc_chance,prototype->school,value,prototype->proc_charges,this);
			}
			else if(owner_obj->obj_type & HIGHGUID_UNIT)
			{
				((creature*)owner_obj)->dataf[UNIT_FIELD_MINDAMAGE] += value;
				((creature*)owner_obj)->dmg_diff += (uint32)value;
			}
		}break;
	case SPELL_AURA_SCHOOL_IMMUNITY:
		{
			//check if imunity is for all types
			if(prototype->effect_misc_value[aura_ind]>SPELL_MAX_SCOOL_TYPE)
			{
				for(int i=0;i<SPELL_MAX_SCOOL_TYPE;i++)
				{
					owner_obj->SetUInt32Value(UNIT_FIELD_RESISTANCES+i,owner_obj->data32[UNIT_FIELD_RESISTANCES+i] + 0x00FFFFFF);
					owner_obj->SetUInt32Value(UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+i,owner_obj->data32[UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+i] + 0x00FFFFFF);
//					owner_obj->spell_school_imun[i]++;
				}
			}
			else 
			{
//				owner_obj->spell_school_imun[prototype->effect_misc_value[aura_ind]]++;
				owner_obj->SetUInt32Value(UNIT_FIELD_RESISTANCES+prototype->effect_misc_value[aura_ind],owner_obj->data32[UNIT_FIELD_RESISTANCES+prototype->effect_misc_value[aura_ind]] + 0x00FFFFFF);
				owner_obj->SetUInt32Value(UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+prototype->effect_misc_value[aura_ind],owner_obj->data32[UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+prototype->effect_misc_value[aura_ind]] + 0x00FFFFFF);
			}
		}break;
	case SPELL_AURA_MOD_ATTACKSPEED:
		{
			values[0] = owner_obj->data32[UNIT_FIELD_BASEATTACKTIME]*value/100;
			owner_obj->speed_attack_modifyer += values[0];
		}break;
	case SPELL_AURA_INTERRUPT_REGEN:
		{
			values[0] = owner_obj->power_regen*0.75f;
			values[1] = owner_obj->health_regen*0.75f;
			owner_obj->power_regen -= values[0];
			owner_obj->health_regen -= values[1];
		}
	case SPELL_AURA_PERIODIC_ENERGIZE:
		{
			owner_obj->power += value;
		}break;
	case SPELL_AURA_MOD_SHAPESHIFT:
		{
			values[0] = owner_obj->Get_powertype(); //store old power type
			owner_obj->Aplly_Shapeshift_Stats(prototype->effect_misc_value[aura_ind]);
		}break;
	case SPELL_AURA_MOD_RANGED_ATTACK_POWER:
		{
			owner_obj->SetUInt32Value(UNIT_FIELD_RANGED_ATTACK_POWER_MODS,owner_obj->data32[UNIT_FIELD_RANGED_ATTACK_POWER_MODS]+(uint32)value);
		}break;
	case SPELL_AURA_MOD_OFFHAND_DAMAGE_PCT:
		{
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
			{
				value = value/100;
				((Character*)(owner_obj))->offhand_dmg_mod_pct += value;
			}
		}break;
	case SPELL_AURA_IGNORE_REGEN_INTERRUPT:
		{
			values[0] = owner_obj->health_regen*value/100;//this should be active when in combat but what the hell we activate it all the time :)
			owner_obj->health_regen_spell += values[0];
		}break;
	case SPELL_AURA_MOD_TAUNT:
		{
			if(owner_obj->obj_type & HIGHGUID_UNIT)
				((creature*)(owner_obj))->agro_list.add(caster_guid,SPELL_AGRO_VALUE_TO_DRAW_ATTENTION);
		}break;
	case SPELL_AURA_HOVER:
		{
			owner_obj->state1 |=PLAYER_STATE_SOFT_FALL;
			G_send_packet.opcode = SMSG_MOVE_SET_HOVER;
			G_send_packet.data[0] = 0xFF;
			*(uint32*)(G_send_packet.data+1) = owner_obj->getGUIDL();
			*(uint32*)(G_send_packet.data+5) = owner_obj->getGUIDL();
			G_send_packet.length = 9;
			owner_obj->SendMsg(&G_send_packet);
		}break;
	case SPELL_AURA_FEATHER_FALL:
		{
			//client will handle this effect (i hope)
			owner_obj->state1 |=PLAYER_STATE_SOFT_FALL;
			G_send_packet.opcode = SMSG_MOVE_FEATHER_FALL;
			G_send_packet.data[0] = 0xFF;
			*(uint32*)(G_send_packet.data+1) = owner_obj->getGUIDL();
			*(uint32*)(G_send_packet.data+5) = owner_obj->getGUIDL();
			G_send_packet.length = 9;
			owner_obj->SendMsg(&G_send_packet);
		}break;
	case SPELL_AURA_MOD_CREATURE_ATTACK_POWER:
		{
			//this should work agains specific monster types. We make it work for all
			owner_obj->SetUInt32Value(UNIT_FIELD_ATTACK_POWER,owner_obj->data32[UNIT_FIELD_ATTACK_POWER]+(uint32)value);
			if(owner_obj->obj_type & HIGHGUID_UNIT)
			{
				//since creatures do not have dinamic stat recalculations we make it directly for them
				float dmg = ((owner_obj->data32[UNIT_FIELD_ATTACK_POWER ]) * owner_obj->data32[UNIT_FIELD_BASEATTACKTIME]) / (14*1000.0f);
				values[0] = dmg;
				((creature*)(owner_obj))->dmg_diff += (uint32)dmg;
				((creature*)(owner_obj))->dataf[UNIT_FIELD_MINDAMAGE] += dmg;
			}
		}break;
	case SPELL_AURA_AURAS_VISIBLE:
		{
			//has only visible effects. Mark a player
		}break;
	case SPELL_AURA_MOD_THREAT:
		{
			//value is given in percent
			if(!(owner_obj->obj_type & HIGHGUID_PLAYER))
				break;
			value = value/100;
			owner_obj->threat_generated += (uint32)value;
		}break;
	case SPELL_AURA_MOD_PACIFY:
		{
			owner_obj->pacified_count++;
		}break;
	case SPELL_AURA_MOD_PACIFY_SILENCE:
		{
			//can't cast spell or attack
			owner_obj->pacified_count++;
			owner_obj->silenced_count++;
		}break;
	case SPELL_AURA_MOD_HEALING_DONE_PERCENT:
	case SPELL_AURA_MOD_HEALING_PCT:
		{
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
			{
				value = 1 + value/100;
				((Character*)owner_obj)->spell_extra_healing_pct += value;
			}
		}break;
	case SPELL_AURA_MOD_HEALING_DONE:
	case SPELL_AURA_MOD_HEALING:
		{
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
				((Character*)owner_obj)->spell_extra_healing += value;
		}break;
	case SPELL_AURA_MOD_POWER_REGEN_PERCENT:
		{
			value = (owner_obj->power_regen+owner_obj->power_regen_spell) * value/100;
			owner_obj->power_regen_spell += value;
		}break;
	//used only by demon aura to resotre health
	case SPELL_AURA_MOD_DAMAGE_DONE:
		{
			owner_obj->SetFloatValue(UNIT_FIELD_MINRANGEDDAMAGE, owner_obj->dataf[UNIT_FIELD_MINRANGEDDAMAGE] + value );
            owner_obj->SetFloatValue(UNIT_FIELD_MAXRANGEDDAMAGE, owner_obj->dataf[UNIT_FIELD_MAXRANGEDDAMAGE] + value );
            owner_obj->SetFloatValue(UNIT_FIELD_MINOFFHANDDAMAGE, owner_obj->dataf[UNIT_FIELD_MINOFFHANDDAMAGE] + value );
            owner_obj->SetFloatValue(UNIT_FIELD_MAXOFFHANDDAMAGE, owner_obj->dataf[UNIT_FIELD_MAXOFFHANDDAMAGE] + value );
            owner_obj->SetFloatValue(UNIT_FIELD_MINDAMAGE, owner_obj->dataf[UNIT_FIELD_MINDAMAGE] + value );
            owner_obj->SetFloatValue(UNIT_FIELD_MAXDAMAGE, owner_obj->dataf[UNIT_FIELD_MAXDAMAGE] + value );
			//recalc_dinamic_stats stat will update values for char
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
			{
				((Character*)owner_obj)->spell_min_dmg[prototype->effect_misc_value[aura_ind]] += value;
				((Character*)owner_obj)->spell_max_dmg[prototype->effect_misc_value[aura_ind]] += (uint32)value;
			}
			else if(owner_obj->obj_type & HIGHGUID_UNIT)
				((creature*)owner_obj)->dmg_diff += (uint32)value;
		}break;
	case SPELL_AURA_MOD_HEALTH_REGEN:
		{
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
				value = (value+((Character*)owner_obj)->spell_extra_healing)*((Character*)owner_obj)->spell_extra_healing_pct / 5000;
			else value = value / 5000;
			owner_obj->health_regen_spell += value;
		}break;
	case SPELL_AURA_MOD_FEAR:
		{
//			owner_obj->flag_set(UNIT_FIELD_FLAGS,UNIT_STAT_FLEEING<<16);
			G_send_packet.opcode = SMSG_DEATH_NOTIFY_OBSOLETE;
			G_send_packet.data32[0] = owner_obj->getGUIDL();
			G_send_packet.data32[0] = owner_obj->getGUIDH();
			G_send_packet.data[8] = 0;
			G_send_packet.length = 9;
			owner_obj->SendMsg(&G_send_packet);
			if(owner_obj->health>1)
				owner_obj->AI_flee_from_point(prototype->duration[0]);
		}break;
	case SPELL_AURA_MOD_TOTAL_THREAT:
		{
			owner_obj->threat_generated += (signed int)value; //value is negative
		}break;
	case SPELL_AURA_GHOST:
		{
		}break;
	case SPELL_AURA_MOD_ATTACK_POWER:
		{
			owner_obj->SetUInt32Value(UNIT_FIELD_ATTACK_POWER_MODS,owner_obj->data32[UNIT_FIELD_ATTACK_POWER_MODS]+(uint32)value);
		}break;
	case SPELL_AURA_MOD_RANGED_DAMAGE_TAKEN:
		{
			value = - value; //we use health shield to do our job for this. Do not add break here !
			goto LABEL_SPELL_AURA_SCHOOL_ABSORB;
		}
	case SPELL_AURA_SCHOOL_ABSORB:
		{
LABEL_SPELL_AURA_SCHOOL_ABSORB:
			Health_Shield_Node *new_node=new Health_Shield_Node;
			new_node->dmg_type_flags = HEALTH_SHIELD_DMG_TYPE_FLAG_ALL;
			new_node->mana_conversion = 0;
			new_node->shield_remain = value;
			new_node->parent_spell_list_node = this;
			*(Health_Shield_Node**)&values[0] = new_node;
			owner_obj->health_shield->add(new_node);
		}break;
	case SPELL_AURA_PERIODIC_TRIGGER_SPELL:
		{
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
				((Character*)(owner_obj))->instant_spell.char_instant_cast(prototype->effect_trigger_spell[aura_ind]);
			else if(owner_obj->obj_type & HIGHGUID_UNIT)G_instant_spell_instance.cr_instant_cast((creature*)owner_obj,prototype->effect_trigger_spell[aura_ind]);
		}break;
	case SPELL_AURA_MOD_STUN:
		{
			owner_obj->flag_set(UNIT_FIELD_FLAGS, 0x40000);
			owner_obj->state1 |= UNIT_STATE_STUN;
			goto BLOCK_CREATURE_MOVEMENT;
		}break;
	case SPELL_AURA_MOD_ROOT:
		{
			owner_obj->state1 |= UNIT_STATE_ROOTED;
			goto BLOCK_CREATURE_MOVEMENT;
		}break;
	case SPELL_AURA_MOD_CONFUSE:
		{
			//first spell that i found is (polymorph)will make creature to move around randomly 
			owner_obj->state1 |= UNIT_STATE_CONFUSED;
BLOCK_CREATURE_MOVEMENT:
			owner_obj->rooted_count++;
			if(owner_obj->rooted_count==1)
			{
				owner_obj->state1 |= UNIT_STATE_ROOTED;
				if(owner_obj->obj_type & HIGHGUID_PLAYER)
					((Character*)owner_obj)->Send_SMSG_FORCE_MOVE_ROOT();
				else if(owner_obj->obj_type & HIGHGUID_UNIT)
				{
					values[0] = owner_obj->speed_land_modifyer;
					owner_obj->speed_land_modifyer = CREATURE_MINIMAL_SPEED;
					((creature*)(owner_obj))->on_change_speed();
				}
			}
		}break;
	case SPELL_AURA_TRANSFORM:
		{
			creature *transform_to=G_creature_prototypes[prototype->effect_misc_value[aura_ind]];
			if(G_max_creature_prototypes>prototype->effect_misc_value[aura_ind] && transform_to==NULL)
				return;
			//!! effect misc value is creature id to inherit properties
			if(owner_obj && !(owner_obj->flags1 & CREATURE_FLAG_IMUNE_TO_MORPH))
			{
					owner_obj->SetUInt32Value(UNIT_FIELD_DISPLAYID,transform_to->data32[UNIT_FIELD_DISPLAYID]);
					owner_obj->health_regen_spell += CREATURE_ON_POLYMORPH_HEALTH_REGEN_FACTOR;
			}
			else if((uint32)caster_guid_parts[1] & HIGHGUID_PLAYER)
				msg_spell_can_cast_result(prototype->spell_id,SPELL_FAILED_IMMUNE,(Character*)caster_guid);
		}break;
	case SPELL_AURA_MOD_HASTE:
		{
			value /=100;
			owner_obj->speed_attack_modifyer +=value/100;
		}break;
	case SPELL_AURA_PROC_TRIGGER_SPELL:
		{
			if(prototype->proc_flags & ON_EVENT_SPELL_TYPE_STRUCK_ANY )
				values[0]=owner_obj->on_struck_spells->add(prototype->effect_trigger_spell[aura_ind],prototype->proc_chance,prototype->proc_charges);
			if(prototype->proc_flags & ON_EVENT_SPELL_TYPE_HIT_ANY)
				values[0]=owner_obj->on_hit_spells->add(prototype->effect_trigger_spell[aura_ind],prototype->proc_chance,prototype->proc_charges);
		}break;
	case SPELL_AURA_MOD_DECREASE_SPEED:
		{
			values[0] = owner_obj->speed_land_modifyer - owner_obj->speed_land_modifyer * (value/100);
			owner_obj->speed_land_modifyer -= values[0];
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
			{
				((Character*)(owner_obj))->msg_change_speed(SPEED_CHANGE_TYPE_RUN);
				((Character*)(owner_obj))->msg_change_speed(SPEED_CHANGE_TYPE_RUN_BACK);
				((Character*)(owner_obj))->msg_change_speed(SPEED_CHANGE_TYPE_WALK);
			}
			else if(owner_obj->obj_type & HIGHGUID_UNIT)
				((creature*)(owner_obj))->on_change_speed();
		}break;
	case SPELL_AURA_PERIODIC_DAMAGE:
		{
			owner_obj->take_dmg(value,caster_guid,prototype->school);
			//send packet to owner that we made some dmg
			if((uint32)caster_guid_parts[1] & HIGHGUID_PLAYER)
//				msg_non_melee_dmg_log(value,caster_guid,owner_obj->getGUID(),prototype,(Character*)caster_guid);
				msg_aura_periodic_log(owner_obj->getGUID());
		}break;
	case SPELL_AURA_MOD_RESISTANCE_EXCLUSIVE:
	case SPELL_AURA_MOD_RESISTANCE: 
		{
			owner_obj->SetUInt32Value(UNIT_FIELD_RESISTANCES + prototype->effect_misc_value[aura_ind],owner_obj->data32[UNIT_FIELD_RESISTANCES + prototype->effect_misc_value[aura_ind]] + (uint32)value);
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
			{
				if(prototype->effect_base_points[aura_ind]<0)
                    owner_obj->SetUInt32Value(UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE + prototype->effect_misc_value[aura_ind],owner_obj->data32[UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE + prototype->effect_misc_value[aura_ind]] + (uint32)value);
				else owner_obj->SetUInt32Value(UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE + prototype->effect_misc_value[aura_ind],owner_obj->data32[UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE + prototype->effect_misc_value[aura_ind]] + (uint32)value);
			}
		}break;
	case SPELL_AURA_MOD_REGEN:
		{
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
			{
				((Character*)(owner_obj))->spell_animation = SPELL_ANIMATION_EAT;
				value = (value+((Character*)owner_obj)->spell_extra_healing)*((Character*)owner_obj)->spell_extra_healing_pct / 2000;
				owner_obj->state1 |= PLAYER_STATE_EATING;
				((Character*)owner_obj)->atimer2 = G_cur_time_ms + PLAY_SPELL_VISUAL_DELAY; //show eat animation in each second
			}
			else value = value / 2000;//spell values are fixed for a period
			owner_obj->health_regen_spell += value; 
		}break;
	case SPELL_AURA_MOD_POWER_REGEN:
		{
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
			{
				((Character*)(owner_obj))->spell_animation = SPELL_ANIMATION_DRINK;
				owner_obj->state1 |= PLAYER_STATE_EATING;
				((Character*)owner_obj)->atimer2 = G_cur_time_ms + PLAY_SPELL_VISUAL_DELAY; //show eat animation in each second
			}
			value /= 2000;//spell values are fixed for a period
			owner_obj->power_regen_spell += value;
		}break;
	case SPELL_AURA_MOD_PERCENT_STAT:
		{
			if(prototype->effect_misc_value[aura_ind]==-1)
			{
				uint32 i;
				for(i=0;i<5;i++)
				{
					//use base stat so when removing items. everything should 
					values[i] = (owner_obj->data32[UNIT_FIELD_STAT0+i]+owner_obj->data32[UNIT_FIELD_POSSTAT0+i]-owner_obj->data32[UNIT_FIELD_NEGSTAT0+i]) * ((100 + value)/100);
					owner_obj->SetUInt32Value(UNIT_FIELD_STAT0 + i, (uint32)(owner_obj->data32[UNIT_FIELD_STAT0 + i] - values[i]));
				}
				//affect all stats
				if(owner_obj->obj_type & HIGHGUID_PLAYER)
				{
					uint32 i;
					if(value<0)	for(i=0;i<5;i++)
							owner_obj->SetUInt32Value(UNIT_FIELD_NEGSTAT0+i, (uint32)(owner_obj->data32[UNIT_FIELD_NEGSTAT0+i] + values[i]));
					else for(i=0;i<5;i++)
							owner_obj->SetUInt32Value(UNIT_FIELD_POSSTAT0+i, (uint32)(owner_obj->data32[UNIT_FIELD_POSSTAT0+i] + values[i]));
				}
			}
			else
			{
				values [prototype->effect_misc_value[aura_ind]] = (owner_obj->data32[UNIT_FIELD_STAT0+prototype->effect_misc_value[aura_ind]] * ((100 + value)/100));
				owner_obj->SetUInt32Value(UNIT_FIELD_STAT0 + prototype->effect_misc_value[aura_ind], (uint32)(owner_obj->data32[UNIT_FIELD_STAT0 + prototype->effect_misc_value[aura_ind]] - values [prototype->effect_misc_value[aura_ind]]));
				if(owner_obj)
				{
					if(value<0)	owner_obj->SetUInt32Value(UNIT_FIELD_NEGSTAT0+prototype->effect_misc_value[aura_ind], (uint32)(owner_obj->data32[UNIT_FIELD_NEGSTAT0+prototype->effect_misc_value[aura_ind]] + values [prototype->effect_misc_value[aura_ind]]));
					else owner_obj->SetUInt32Value(UNIT_FIELD_POSSTAT0+prototype->effect_misc_value[aura_ind], (uint32)(owner_obj->data32[UNIT_FIELD_POSSTAT0+prototype->effect_misc_value[aura_ind]] + values [prototype->effect_misc_value[aura_ind]]));
				}
			}
		}break;
	case SPELL_AURA_MOD_INCREASE_SPEED:
		{
			values[0] = value/100;
			owner_obj->speed_land_modifyer += values[0];
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
			{
				((Character*)(owner_obj))->msg_change_speed(SPEED_CHANGE_TYPE_RUN);
				((Character*)(owner_obj))->msg_change_speed(SPEED_CHANGE_TYPE_RUN_BACK);
				((Character*)(owner_obj))->msg_change_speed(SPEED_CHANGE_TYPE_WALK);
//printf("speed should increase with %f \n",values[0]);
			}
			else if(owner_obj->obj_type & HIGHGUID_UNIT)
				((creature*)(owner_obj))->on_change_speed();
		}break;
	case SPELL_AURA_MOD_INCREASE_SWIM_SPEED:
		{
			values[0] = value/100;
			owner_obj->speed_water_modifyer += values[0];
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
			{
				((Character*)(owner_obj))->msg_change_speed(SPEED_CHANGE_TYPE_SWIM);
				((Character*)(owner_obj))->msg_change_speed(SPEED_CHANGE_TYPE_SWIM_BACK);
			}
			else if(owner_obj->obj_type & HIGHGUID_UNIT)
			{
				((creature*)(owner_obj))->on_change_speed();
			}
		}break;
	case SPELL_AURA_WATER_WALK:
		{
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
			{
				G_send_packet.opcode = SMSG_MOVE_WATER_WALK;
				G_send_packet.data[0] = 0xFF;
				*(uint32*)(G_send_packet.data+1) = owner_obj->getGUIDL();
				*(uint32*)(G_send_packet.data+5) = owner_obj->getGUIDH();
				G_send_packet.length = 9;
				owner_obj->SendMsg(&G_send_packet);
			}
		}
	case SPELL_AURA_MOD_TOTAL_STAT_PERCENTAGE:
		{
			if(prototype->effect_misc_value[aura_ind]>1000)
			{
				uint32 i;
				for(i=0;i<5;i++)
				{
					values[i]= owner_obj->data32[UNIT_FIELD_STAT0 + i] * value/100;
					owner_obj->SetUInt32Value(UNIT_FIELD_STAT0 + i, (uint32)(owner_obj->data32[UNIT_FIELD_STAT0 + i] + values[i]));
				}
				//affect all stats
				if(owner_obj->obj_type & HIGHGUID_PLAYER)
				{
					if(value<0)	for(i=0;i<5;i++)
						owner_obj->SetUInt32Value(UNIT_FIELD_NEGSTAT0+i, (uint32)(owner_obj->data32[UNIT_FIELD_NEGSTAT0+i] - values[i]));
					else for(i=0;i<5;i++)
						owner_obj->SetUInt32Value(UNIT_FIELD_POSSTAT0+i, (uint32)(owner_obj->data32[UNIT_FIELD_POSSTAT0+i] + values[i]));
				}
			}
			else
			{
				values[0]=owner_obj->data32[UNIT_FIELD_STAT0 + prototype->effect_misc_value[aura_ind]] * value/100;
				owner_obj->SetUInt32Value(UNIT_FIELD_STAT0 + prototype->effect_misc_value[aura_ind], (uint32)(owner_obj->data32[UNIT_FIELD_STAT0 + prototype->effect_misc_value[aura_ind]] + values[0]));
				if(owner_obj->obj_type & HIGHGUID_PLAYER)
				{
					if(value<0)	owner_obj->SetUInt32Value(UNIT_FIELD_NEGSTAT0+prototype->effect_misc_value[aura_ind], (uint32)(owner_obj->data32[UNIT_FIELD_NEGSTAT0+prototype->effect_misc_value[aura_ind]] - values[0]));
					else owner_obj->SetUInt32Value(UNIT_FIELD_POSSTAT0+prototype->effect_misc_value[aura_ind], (uint32)(owner_obj->data32[UNIT_FIELD_POSSTAT0+prototype->effect_misc_value[aura_ind]] + values[0]));
				}
			}
		}break;
	case SPELL_AURA_MOD_STAT:
		{
			if(prototype->effect_misc_value[aura_ind]>1000)
			{
				uint32 i;
				for(i=0;i<5;i++)
					owner_obj->SetUInt32Value(UNIT_FIELD_STAT0 + i, (uint32)(owner_obj->data32[UNIT_FIELD_STAT0 + i] + value));
				//affect all stats
				if(owner_obj->obj_type & HIGHGUID_PLAYER)
				{
					if(value<0)	for(i=0;i<5;i++)
						owner_obj->SetUInt32Value(UNIT_FIELD_NEGSTAT0+i, (uint32)(owner_obj->data32[UNIT_FIELD_NEGSTAT0+i] - value));
					else for(i=0;i<5;i++)
						owner_obj->SetUInt32Value(UNIT_FIELD_POSSTAT0+i, (uint32)(owner_obj->data32[UNIT_FIELD_POSSTAT0+i] + value));
				}
			}
			else
			{
				owner_obj->SetUInt32Value(UNIT_FIELD_STAT0 + prototype->effect_misc_value[aura_ind], (uint32)(owner_obj->data32[UNIT_FIELD_STAT0 + prototype->effect_misc_value[aura_ind]] + value));
				if(owner_obj->obj_type & HIGHGUID_PLAYER)
				{
					if(value<0)	owner_obj->SetUInt32Value(UNIT_FIELD_NEGSTAT0+prototype->effect_misc_value[aura_ind], (uint32)(owner_obj->data32[UNIT_FIELD_NEGSTAT0+prototype->effect_misc_value[aura_ind]] - value));
					else owner_obj->SetUInt32Value(UNIT_FIELD_POSSTAT0+prototype->effect_misc_value[aura_ind], (uint32)(owner_obj->data32[UNIT_FIELD_POSSTAT0+prototype->effect_misc_value[aura_ind]] + value));
				}
			}
		}break;
	case SPELL_AURA_NONE:
	case SPELL_AURA_BIND_SIGHT:
	case SPELL_AURA_ADD_CASTER_HIT_TRIGGER:
	case SPELL_AURA_OVERRIDE_CLASS_SCRIPTS:
	case SPELL_AURA_MOD_RANGED_DAMAGE_TAKEN_PCT:
	case SPELL_AURA_MOD_MECHANIC_RESISTANCE:
	case SPELL_AURA_SHARE_PET_TRACKING:
	case SPELL_AURA_UNTRACKABLE:
	case SPELL_AURA_EMPATHY:
	case SPELL_AURA_MOD_POWER_COST_PCT:	//couldn't find any examples :S
	case SPELL_AURA_RANGED_ATTACK_POWER_ATTACKER_BONUS:
	case SPELL_AURA_MOD_POSSESS_PET:
	case SPELL_AURA_MOD_CREATURE_RANGED_ATTACK_POWER:
	case SPELL_AURA_MOD_MANA_REGEN_INTERRUPT:
	case SPELL_AURA_MOD_RANGED_HASTE:
	case SPELL_AURA_MOD_RANGED_AMMO_HASTE:
	case SPELL_AURA_CHARISMA: //1 example
	case SPELL_AURA_PERSUADED: // 1 example
	case SPELL_AURA_ADD_CREATURE_IMMUNITY://1 example
	case SPELL_AURA_MOD_DETECT:
	case SPELL_AURA_MOD_INVISIBILITY:
	case SPELL_AURA_MOD_INVISIBILITY_DETECTION:
	case SPELL_AURA_MOD_POSSESS:
	case SPELL_AURA_EFFECT_IMMUNITY:
	case SPELL_AURA_STATE_IMMUNITY:
	case SPELL_AURA_DAMAGE_IMMUNITY:
	case SPELL_AURA_DISPEL_IMMUNITY:
	case SPELL_AURA_MOD_PARRY_SKILL:
	case SPELL_AURA_MOD_DODGE_SKILL:
	case SPELL_AURA_MOD_BLOCK_SKILL:
	case SPELL_AURA_PERIODIC_LEECH:
	case SPELL_AURA_MOD_HIT_CHANCE:
	case SPELL_AURA_MOD_SPELL_HIT_CHANCE:
	case SPELL_AURA_MOD_SPELL_CRIT_CHANCE:
	case SPELL_AURA_MOD_DAMAGE_DONE_CREATURE:
	case SPELL_AURA_MOD_CHARM:
	case SPELL_AURA_REFLECT_SPELLS:
	case SPELL_AURA_MOD_SKILL:
	case SPELL_AURA_PERIODIC_HEALTH_FUNNEL:
	case SPELL_AURA_PERIODIC_MANA_FUNNEL:
	case SPELL_AURA_PERIODIC_MANA_LEECH:
	case SPELL_AURA_MOD_CASTING_SPEED:
	case SPELL_AURA_FEIGN_DEATH:
	case SPELL_AURA_MOD_DISARM:
	case SPELL_AURA_MOD_STALKED:
	case SPELL_AURA_EXTRA_ATTACKS:
	case SPELL_AURA_MOD_SPELL_CRIT_CHANCE_SCHOOL:
	case SPELL_AURA_MOD_POWER_COST:
	case SPELL_AURA_MOD_POWER_COST_SCHOOL:
	case SPELL_AURA_REFLECT_SPELLS_SCHOOL:
	case SPELL_AURA_MOD_LANGUAGE:
	case SPELL_AURA_FAR_SIGHT:
	case SPELL_AURA_MECHANIC_IMMUNITY:
	case SPELL_AURA_MOD_DAMAGE_PERCENT_DONE:
	case SPELL_AURA_SPLIT_DAMAGE:
	case SPELL_AURA_WATER_BREATHING:
	case SPELL_AURA_MOD_BASE_RESISTANCE:
	case SPELL_AURA_CHANNEL_DEATH_ITEM:
	case SPELL_AURA_MOD_DAMAGE_PERCENT_TAKEN:
	case SPELL_AURA_MOD_PERCENT_REGEN:
	case SPELL_AURA_MOD_RESIST_CHANCE:
	case SPELL_AURA_MOD_DETECT_RANGE:
	case SPELL_AURA_PREVENTS_FLEEING:
	case SPELL_AURA_MOD_UNATTACKABLE:
	case SPELL_AURA_SPELL_MAGNET:
	case SPELL_AURA_MOD_SKILL_TALENT:
	default:
		{
			printf("unhandled aura type(name) %u for spell %u\n",aura_name,prototype->spell_id);
		}break;
	}//end switch 1
	owner_obj->recalc_dinamic_stats();
}

void Spell_Affect_node::remove_effect(Base_Unit_Object	*owner_obj)
{
//printf("removing aura effect %u\n",prototype->effect_apply_aura_name[aura_ind]);
	switch (aura_name)
	{
/*	
	case SPELL_AURA_TRACK_CREATURES:
		{
			if(owner_char)
				owner_char->SetUInt32Value(PLAYER_TRACK_CREATURES,0);
		}break;
	case SPELL_AURA_TRACK_RESOURCES:
		{
			if(owner_char)
				owner_char->SetUInt32Value(PLAYER_TRACK_RESOURCES,0);
		}break;
	case SPELL_AURA_MOD_BASE_RESISTANCE_PCT:
	case SPELL_AURA_MOD_RESISTANCE_PCT:
		{
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
			{
				if(prototype->effect_misc_value[aura_ind]>=PLAYER_USED_DMG_TYPES)
				{
					for(int i=0;i<PLAYER_USED_DMG_TYPES;i++)
						((Character*)owner_obj)->spell_res_pct[i] -= value;
				}
				else ((Character*)owner_obj)->spell_res_pct[prototype->effect_misc_value[aura_ind]] -= value; //saw examples only for armor 
			}
			else if(owner_obj->obj_type & HIGHGUID_UNIT)
				owner_obj->data32[UNIT_FIELD_RESISTANCES] = (uint32)(owner_obj->data32[UNIT_FIELD_RESISTANCES] - values[0]);
			owner_obj->on_spell_change_resistance();
		}break;
	case SPELL_AURA_MOD_DAMAGE_TAKEN:
	case SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN:
	case SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN_PCT:
		{
			owner_obj->health_shield->del(*(Health_Shield_Node**)&values[0]);
		}break;
	case SPELL_AURA_FORCE_REACTION:
		{
			if(values[1]==NUMBER_OF_FACTIONS)
				break;
			//save standing
			 ((Character*)owner_obj)->reputation_val[values[1]] = values[0];
			//set new standing
			//set your reputation with a specific faction 
			G_send_packet.opcode = SMSG_SET_FACTION_STANDING;
			G_send_packet.data32[0] = 1; //visible faction
			G_send_packet.data32[1] = values[1]; //reputaion_list_id
			G_send_packet.data32[2] = values[0]; //standing
			G_send_packet.length = 12;
		}break;
	case SPELL_AURA_ADD_TARGET_TRIGGER:
		{
			//i think these are actually talents. It will add one on event spell to target. trigger is conditioned by spell_id or effect_type
			owner_obj->on_cast_spells->del(prototype->effect_trigger_spell[aura_ind],value,-1);
		}break;
	case SPELL_AURA_MOD_MECHANIC_RESISTANCE:
		{
			if(owner_obj->obj_type & HIGHGUID_UNIT)
				((Character*)(owner_obj))->mechanic_rezistance -= value;
		}break;
	case SPELL_AURA_DAMAGE_SHIELD:
`		*/
	case SPELL_AURA_MOD_STEALTH:
		{
			owner_obj->state1 &= ~UNIT_STATE_STEALTHED;
			owner_obj->threat_generated += (signed int)values[0];
		}break;
	case SPELL_AURA_PROC_TRIGGER_DAMAGE:
		{
			//must be made to use chance and charges
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
			{
				//try to add them to be fast
				if(prototype->proc_charges==0 && prototype->proc_chance>=90)
				{
					((Character*)owner_obj)->spell_min_dmg[prototype->school] -= value;
					((Character*)owner_obj)->spell_max_dmg[prototype->school] -= (uint32)value;
				}
				//this is alot slower solution :(
				else ((Character*)owner_obj)->on_attack_spell_dmg.del((uint8)values[0]);
			}
			else if(owner_obj->obj_type & HIGHGUID_UNIT)
			{
				((creature*)owner_obj)->dataf[UNIT_FIELD_MINDAMAGE] -= value;
				((creature*)owner_obj)->dmg_diff -= (uint32)value;
			}
		}break;
	case SPELL_AURA_SCHOOL_IMMUNITY:
		{
			//check if imunity is for all types
			if(prototype->effect_misc_value[aura_ind]>SPELL_MAX_SCOOL_TYPE)
			{
				for(int i=0;i<SPELL_MAX_SCOOL_TYPE;i++)
				{
					owner_obj->SetUInt32Value(UNIT_FIELD_RESISTANCES+i,owner_obj->data32[UNIT_FIELD_RESISTANCES+i] - 0x00FFFFFF);
					owner_obj->SetUInt32Value(UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+i,owner_obj->data32[UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+i] - 0x00FFFFFF);
//					owner_obj->spell_school_imun[i]++;
				}
			}
			else 
			{
//				owner_obj->spell_school_imun[prototype->effect_misc_value[aura_ind]]++;
				owner_obj->SetUInt32Value(UNIT_FIELD_RESISTANCES+prototype->effect_misc_value[aura_ind],owner_obj->data32[UNIT_FIELD_RESISTANCES+prototype->effect_misc_value[aura_ind]] - 0x00FFFFFF);
				owner_obj->SetUInt32Value(UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+prototype->effect_misc_value[aura_ind],owner_obj->data32[UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+prototype->effect_misc_value[aura_ind]] - 0x00FFFFFF);
			}
		}break;
	case SPELL_AURA_MOD_ATTACKSPEED:
		{
			owner_obj->speed_attack_modifyer -= values[0];
		}break;
	case SPELL_AURA_INTERRUPT_REGEN:
		{
			owner_obj->power_regen += values[0];
			owner_obj->health_regen += values[1];
		}
	case SPELL_AURA_MOD_SHAPESHIFT:
		{
			owner_obj->Aplly_Shapeshift_Stats(0,(uint8)values[0]);//restore previous form == 0
		}break;
	case SPELL_AURA_MOD_RANGED_ATTACK_POWER:
		{
			owner_obj->SetUInt32Value(UNIT_FIELD_RANGED_ATTACK_POWER_MODS,owner_obj->data32[UNIT_FIELD_RANGED_ATTACK_POWER_MODS]-(uint32)value);
		}break;
	case SPELL_AURA_MOD_OFFHAND_DAMAGE_PCT:
		{
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
				((Character*)(owner_obj))->offhand_dmg_mod_pct -= value;
		}break;
	case SPELL_AURA_IGNORE_REGEN_INTERRUPT:
		{
			owner_obj->health_regen_spell -= values[0];
		}break;
	case SPELL_AURA_HOVER:
		{
			owner_obj->state1 &=~PLAYER_STATE_SOFT_FALL;
			G_send_packet.opcode = SMSG_MOVE_UNSET_HOVER;
			G_send_packet.data[0] = 0xFF;
			*(uint32*)(G_send_packet.data+1) = owner_obj->getGUIDL();
			*(uint32*)(G_send_packet.data+5) = owner_obj->getGUIDL();
			G_send_packet.length = 9;
			owner_obj->SendMsg(&G_send_packet);
		}break;
	case SPELL_AURA_FEATHER_FALL:
		{
			//client will handle this effect (i hope)
			owner_obj->state1 &=~PLAYER_STATE_SOFT_FALL;
			G_send_packet.opcode = SMSG_MOVE_NORMAL_FALL;
			G_send_packet.data[0] = 0xFF;
			*(uint32*)(G_send_packet.data+1) = owner_obj->getGUIDL();
			*(uint32*)(G_send_packet.data+5) = owner_obj->getGUIDL();
			G_send_packet.length = 9;
		}break;
	case SPELL_AURA_MOD_CREATURE_ATTACK_POWER:
		{
			//this should work agains specific monster types. We make it work for all
			owner_obj->SetUInt32Value(UNIT_FIELD_ATTACK_POWER,owner_obj->data32[UNIT_FIELD_ATTACK_POWER]-(uint32)value);
			if(owner_obj->obj_type & HIGHGUID_UNIT)
			{
				//since creatures do not have dinamic stat recalculations we make it directly for them
				((creature*)(owner_obj))->dmg_diff -= (uint32)values[0];
				((creature*)(owner_obj))->dataf[UNIT_FIELD_MINDAMAGE] -= values[0];
			}
		}break;
	case SPELL_AURA_MOD_THREAT:
		{
			//value is given in percent
			if(!(owner_obj->obj_type & HIGHGUID_PLAYER))
				break;
			owner_obj->threat_generated -= (uint32)value;
		}break;
	case SPELL_AURA_MOD_PACIFY:
		{
			owner_obj->pacified_count--;
		}break;
	case SPELL_AURA_MOD_PACIFY_SILENCE:
		{
			//can't cast spell or attack
			owner_obj->pacified_count--;
			owner_obj->silenced_count--;
		}break;
	case SPELL_AURA_MOD_HEALING_DONE_PERCENT:
	case SPELL_AURA_MOD_HEALING_PCT:
	{
		if(owner_obj->obj_type & HIGHGUID_PLAYER)
			((Character*)owner_obj)->spell_extra_healing_pct -= value;
	}break;
	case SPELL_AURA_MOD_HEALING_DONE:
	case SPELL_AURA_MOD_HEALING:
		{
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
				((Character*)owner_obj)->spell_extra_healing -= value;
		}break;
	case SPELL_AURA_MOD_POWER_REGEN_PERCENT:
		{
			owner_obj->power_regen_spell -= value;
		}break;
	case SPELL_AURA_MOD_DAMAGE_DONE:
		{
			owner_obj->SetFloatValue(UNIT_FIELD_MINRANGEDDAMAGE, owner_obj->dataf[UNIT_FIELD_MINRANGEDDAMAGE] - value );
            owner_obj->SetFloatValue(UNIT_FIELD_MAXRANGEDDAMAGE, owner_obj->dataf[UNIT_FIELD_MAXRANGEDDAMAGE] - value );
            owner_obj->SetFloatValue(UNIT_FIELD_MINOFFHANDDAMAGE, owner_obj->dataf[UNIT_FIELD_MINOFFHANDDAMAGE] - value );
            owner_obj->SetFloatValue(UNIT_FIELD_MAXOFFHANDDAMAGE, owner_obj->dataf[UNIT_FIELD_MAXOFFHANDDAMAGE] - value );
            owner_obj->SetFloatValue(UNIT_FIELD_MINDAMAGE, owner_obj->dataf[UNIT_FIELD_MINDAMAGE] - value );
            owner_obj->SetFloatValue(UNIT_FIELD_MAXDAMAGE, owner_obj->dataf[UNIT_FIELD_MAXDAMAGE] - value );
			//recalc_dinamic_stats stat will update values for char
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
			{
				((Character*)owner_obj)->spell_min_dmg[prototype->effect_misc_value[aura_ind]] -= value;
				((Character*)owner_obj)->spell_max_dmg[prototype->effect_misc_value[aura_ind]] -= (uint32)value;
			}
			else if(owner_obj->obj_type & HIGHGUID_UNIT)
				((creature*)owner_obj)->dmg_diff -= (uint32)value;
		}break;
	case SPELL_AURA_MOD_HEALTH_REGEN:
		{
			owner_obj->health_regen_spell -= value;
		}break;
	case SPELL_AURA_MOD_FEAR:
		{
			G_send_packet.opcode = SMSG_DEATH_NOTIFY_OBSOLETE;
			G_send_packet.data32[0] = owner_obj->getGUIDL();
			G_send_packet.data32[0] = owner_obj->getGUIDH();
			G_send_packet.data[8] = 1;
			G_send_packet.length = 9;
//			owner_obj->flag_clr(UNIT_FIELD_FLAGS,UNIT_STAT_FLEEING<<16);
			owner_obj->AI_flee_remove();
		}break;
	case SPELL_AURA_MOD_TOTAL_THREAT:
		{
			owner_obj->threat_generated -= (signed int)value; //value is negative
		}break;
	case SPELL_AURA_GHOST:
		{
		}break;
	case SPELL_AURA_MOD_ATTACK_POWER:
		{
			owner_obj->SetUInt32Value(UNIT_FIELD_ATTACK_POWER_MODS,owner_obj->data32[UNIT_FIELD_ATTACK_POWER_MODS]-(uint32)value);
		}break;
	case SPELL_AURA_MANA_SHIELD:
	case SPELL_AURA_MOD_RANGED_DAMAGE_TAKEN:
	case SPELL_AURA_SCHOOL_ABSORB:
		{
			owner_obj->health_shield->del(*(Health_Shield_Node**)&values[0]);
		}break;
	case SPELL_AURA_MOD_STUN:
		{
			owner_obj->flag_clr(UNIT_FIELD_FLAGS, 0x40000);
			owner_obj->state1 &= ~UNIT_STATE_STUN;
			goto CREATURE_STATE_BLOCKED_MOVEMENT;
		}break;
	case SPELL_AURA_MOD_ROOT:
		{
			owner_obj->state1 &= ~UNIT_STATE_ROOTED;
			goto CREATURE_STATE_BLOCKED_MOVEMENT;
		}break;
	case SPELL_AURA_MOD_CONFUSE:
		{
			owner_obj->state1 &= ~UNIT_STATE_CONFUSED;
CREATURE_STATE_BLOCKED_MOVEMENT:
			//first spell that i found is (polymorph)will make creature not able to move
			if(owner_obj->rooted_count==1)
			{
				owner_obj->rooted_count = 0;
				owner_obj->state1 &= ~UNIT_STATE_ROOTED;
				if(owner_obj->obj_type & HIGHGUID_PLAYER)
					((Character*)(owner_obj))->Send_SMSG_FORCE_MOVE_UNROOT();
				else if(owner_obj->obj_type & HIGHGUID_UNIT)
				{
					owner_obj->speed_land_modifyer = owner_obj->speed_land_modifyer + values[0] - CREATURE_MINIMAL_SPEED;
					((creature*)(owner_obj))->on_change_speed();
				}
			}
			else owner_obj->rooted_count--;
		}break;
	case SPELL_AURA_TRANSFORM:
		{
			owner_obj->SetUInt32Value(UNIT_FIELD_DISPLAYID,owner_obj->data32[UNIT_FIELD_NATIVEDISPLAYID]);
			owner_obj->health_regen_spell -= CREATURE_ON_POLYMORPH_HEALTH_REGEN_FACTOR;
		}break;
	case SPELL_AURA_MOD_HASTE:
		{
			owner_obj->speed_attack_modifyer -=value;
		}break;
	case SPELL_AURA_PROC_TRIGGER_SPELL:
		{
			if(prototype->proc_flags & ON_EVENT_SPELL_TYPE_STRUCK_ANY )
				owner_obj->on_struck_spells->del((uint32)values[0]);
			if(prototype->proc_flags & ON_EVENT_SPELL_TYPE_HIT_ANY)
				owner_obj->on_hit_spells->del((uint32)values[0]);
		}break;
	case SPELL_AURA_MOD_DECREASE_SPEED:
		{
			owner_obj->speed_land_modifyer += values[0];
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
			{
				((Character*)(owner_obj))->msg_change_speed(SPEED_CHANGE_TYPE_RUN);
				((Character*)(owner_obj))->msg_change_speed(SPEED_CHANGE_TYPE_RUN_BACK);
				((Character*)(owner_obj))->msg_change_speed(SPEED_CHANGE_TYPE_WALK);
			}
			else if(owner_obj->obj_type & HIGHGUID_UNIT)
				((creature*)(owner_obj))->on_change_speed();
		}break;
	case SPELL_AURA_MOD_RESISTANCE_EXCLUSIVE:
	case SPELL_AURA_MOD_RESISTANCE: 
		{
			owner_obj->SetUInt32Value(UNIT_FIELD_RESISTANCES + prototype->effect_misc_value[aura_ind],owner_obj->data32[UNIT_FIELD_RESISTANCES + prototype->effect_misc_value[aura_ind]] - (uint32)value);
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
			{
				if(prototype->effect_base_points[aura_ind]<0)
					owner_obj->SetUInt32Value(UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE + prototype->effect_misc_value[aura_ind],owner_obj->data32[UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE + prototype->effect_misc_value[aura_ind]] - (uint32)value);
				else owner_obj->SetUInt32Value(UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE + prototype->effect_misc_value[aura_ind],owner_obj->data32[UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE + prototype->effect_misc_value[aura_ind]] - (uint32)value);
			}
		}break;
	case SPELL_AURA_MOD_REGEN:
		{
			owner_obj->state1 &= ~(PLAYER_STATE_EATING);
			owner_obj->health_regen_spell -= value;
			((Character*)(owner_obj))->spell_animation = 0;
		}break;
	case SPELL_AURA_MOD_POWER_REGEN:
		{
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
				((Character*)(owner_obj))->spell_animation = 0;
			owner_obj->state1 &= ~(PLAYER_STATE_EATING);
			owner_obj->power_regen_spell -= value;
		}break;
	case SPELL_AURA_MOD_PERCENT_STAT:
		{
			if(prototype->effect_misc_value[aura_ind]==-1)
			{
				uint32 i;
				for(i=0;i<5;i++)
					owner_obj->SetUInt32Value(UNIT_FIELD_STAT0 + i, (uint32)(owner_obj->data32[UNIT_FIELD_STAT0 + i] + values[i]));
				//affect all stats
				if(owner_obj->obj_type & HIGHGUID_PLAYER)
				{
					uint32 i;
					if(value<0)	for(i=0;i<5;i++)
							owner_obj->SetUInt32Value(UNIT_FIELD_NEGSTAT0+i, (uint32)(owner_obj->data32[UNIT_FIELD_NEGSTAT0+i] - values[i]));
					else for(i=0;i<5;i++)
							owner_obj->SetUInt32Value(UNIT_FIELD_POSSTAT0+i, (uint32)(owner_obj->data32[UNIT_FIELD_POSSTAT0+i] - values[i]));
				}
			}
			else
			{
				owner_obj->SetUInt32Value(UNIT_FIELD_STAT0 + prototype->effect_misc_value[aura_ind], (uint32)(owner_obj->data32[UNIT_FIELD_STAT0 + prototype->effect_misc_value[aura_ind]] + values[prototype->effect_misc_value[aura_ind]]));
				if(owner_obj)
				{
					if(value<0)	owner_obj->SetUInt32Value(UNIT_FIELD_NEGSTAT0+prototype->effect_misc_value[aura_ind], (uint32)(owner_obj->data32[UNIT_FIELD_NEGSTAT0+prototype->effect_misc_value[aura_ind]] - values [prototype->effect_misc_value[aura_ind]]));
					else owner_obj->SetUInt32Value(UNIT_FIELD_POSSTAT0+prototype->effect_misc_value[aura_ind], (uint32)(owner_obj->data32[UNIT_FIELD_POSSTAT0+prototype->effect_misc_value[aura_ind]] - values [prototype->effect_misc_value[aura_ind]]));
				}
			}
		}break;
	case SPELL_AURA_MOD_INCREASE_SPEED:
		{
			owner_obj->speed_land_modifyer -= values[0];
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
			{
//printf("speed should decrease with %f \n",values[0]);
				((Character*)(owner_obj))->msg_change_speed(SPEED_CHANGE_TYPE_RUN);
				((Character*)(owner_obj))->msg_change_speed(SPEED_CHANGE_TYPE_RUN_BACK);
				((Character*)(owner_obj))->msg_change_speed(SPEED_CHANGE_TYPE_WALK);
			}
			else if(owner_obj->obj_type & HIGHGUID_UNIT)
				((creature*)(owner_obj))->on_change_speed();
		}break;
	case SPELL_AURA_MOD_INCREASE_SWIM_SPEED:
		{
			owner_obj->speed_water_modifyer -= values[0];
			if(owner_obj->obj_type & HIGHGUID_PLAYER)
			{
				((Character*)(owner_obj))->msg_change_speed(SPEED_CHANGE_TYPE_SWIM);
				((Character*)(owner_obj))->msg_change_speed(SPEED_CHANGE_TYPE_SWIM_BACK);
			}
			else if(owner_obj->obj_type & HIGHGUID_UNIT)
			{
				((creature*)(owner_obj))->on_change_speed();
			}
		}break;
	case SPELL_AURA_WATER_WALK:
		{
			G_send_packet.opcode = SMSG_MOVE_LAND_WALK;
			G_send_packet.data[0] = 0xFF;
			*(uint32*)(G_send_packet.data+1) = owner_obj->getGUIDL();
			*(uint32*)(G_send_packet.data+5) = owner_obj->getGUIDL();
			G_send_packet.length = 9;
			owner_obj->SendMsg(&G_send_packet);
		}break;
	case SPELL_AURA_MOD_TOTAL_STAT_PERCENTAGE:
		{
			if(prototype->effect_misc_value[aura_ind]>1000)
			{
				uint32 i;
				for(i=0;i<5;i++)
					owner_obj->SetUInt32Value(UNIT_FIELD_STAT0 + i, (uint32)(owner_obj->data32[UNIT_FIELD_STAT0 + i] - values[i]));
				//affect all stats
				if(owner_obj->obj_type & HIGHGUID_PLAYER)
				{
					if(value<0)	for(i=0;i<5;i++)
						owner_obj->SetUInt32Value(UNIT_FIELD_NEGSTAT0+i, (uint32)(owner_obj->data32[UNIT_FIELD_NEGSTAT0+i] + values[i]));
					else for(i=0;i<5;i++)
						owner_obj->SetUInt32Value(UNIT_FIELD_POSSTAT0+i, (uint32)(owner_obj->data32[UNIT_FIELD_POSSTAT0+i] - values[i]));
				}
			}
			else
			{
				owner_obj->SetUInt32Value(UNIT_FIELD_STAT0 + prototype->effect_misc_value[aura_ind], (uint32)(owner_obj->data32[UNIT_FIELD_STAT0 + prototype->effect_misc_value[aura_ind]] - values[0]));
				if(owner_obj->obj_type & HIGHGUID_PLAYER)
				{
					if(value<0)	owner_obj->SetUInt32Value(UNIT_FIELD_NEGSTAT0+prototype->effect_misc_value[aura_ind], (uint32)(owner_obj->data32[UNIT_FIELD_NEGSTAT0+prototype->effect_misc_value[aura_ind]] + values[0]));
					else owner_obj->SetUInt32Value(UNIT_FIELD_POSSTAT0+prototype->effect_misc_value[aura_ind], (uint32)(owner_obj->data32[UNIT_FIELD_POSSTAT0+prototype->effect_misc_value[aura_ind]] - values[0]));
				}
			}
		}break;	case SPELL_AURA_MOD_STAT:
		{
			if(prototype->effect_misc_value[aura_ind]==-1)
			{
				uint32 i;
				for(i=0;i<5;i++)
					owner_obj->SetUInt32Value(UNIT_FIELD_STAT0 + i, (uint32)(owner_obj->data32[UNIT_FIELD_STAT0 + i] - value));
				//affect all stats
				if(owner_obj->obj_type & HIGHGUID_PLAYER)
				{
					if(value<0)	for(i=0;i<5;i++)
							owner_obj->SetUInt32Value(UNIT_FIELD_NEGSTAT0+i, (uint32)(owner_obj->data32[UNIT_FIELD_NEGSTAT0+i] - value));
					else for(i=0;i<5;i++)
							owner_obj->SetUInt32Value(UNIT_FIELD_POSSTAT0+i, (uint32)(owner_obj->data32[UNIT_FIELD_POSSTAT0+i] - value));
				}
			}
			else
			{
				owner_obj->SetUInt32Value(UNIT_FIELD_STAT0 + prototype->effect_misc_value[aura_ind], (uint32)(owner_obj->data32[UNIT_FIELD_STAT0 + prototype->effect_misc_value[aura_ind]] - value));
				if(owner_obj)
				{
					if(value<0)owner_obj->SetUInt32Value(UNIT_FIELD_NEGSTAT0+prototype->effect_misc_value[aura_ind], (uint32)(owner_obj->data32[UNIT_FIELD_NEGSTAT0+prototype->effect_misc_value[aura_ind]] - value));
					else owner_obj->SetUInt32Value(UNIT_FIELD_POSSTAT0+prototype->effect_misc_value[aura_ind], (uint32)(owner_obj->data32[UNIT_FIELD_POSSTAT0+prototype->effect_misc_value[aura_ind]] - value));
				}
			}
		}break;
/*	
	case SPELL_AURA_MOD_TAUNT:
		{
		}break;
	case SPELL_AURA_AURAS_VISIBLE:
		{
			//has only visible effects. Mark a player
		}break;
	case SPELL_AURA_PERIODIC_DAMAGE:
		{}break;*/
	case SPELL_AURA_NONE:
	case SPELL_AURA_BIND_SIGHT:
	case SPELL_AURA_ADD_FLAT_MODIFIER:
	case SPELL_AURA_ADD_CASTER_HIT_TRIGGER:
	case SPELL_AURA_OVERRIDE_CLASS_SCRIPTS:
	case SPELL_AURA_MOD_RANGED_DAMAGE_TAKEN_PCT:
	case SPELL_AURA_MOD_MECHANIC_RESISTANCE:
	case SPELL_AURA_SHARE_PET_TRACKING:
	case SPELL_AURA_UNTRACKABLE:
	case SPELL_AURA_EMPATHY:
	case SPELL_AURA_MOD_POWER_COST_PCT:
	case SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN:
	case SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN_PCT:
	case SPELL_AURA_RANGED_ATTACK_POWER_ATTACKER_BONUS:
	case SPELL_AURA_MOD_POSSESS_PET:
	case SPELL_AURA_MOD_CREATURE_RANGED_ATTACK_POWER:
	case SPELL_AURA_MOD_MANA_REGEN_INTERRUPT:
	case SPELL_AURA_FORCE_REACTION:
	case SPELL_AURA_MOD_DAMAGE_TAKEN:
	case SPELL_AURA_MOD_RANGED_HASTE:
	case SPELL_AURA_MOD_RANGED_AMMO_HASTE:
	case SPELL_AURA_CHARISMA:
	case SPELL_AURA_PERSUADED:
	case SPELL_AURA_ADD_CREATURE_IMMUNITY:
	case SPELL_AURA_RETAIN_COMBO_POINTS:
	case SPELL_AURA_MOD_DETECT:
	case SPELL_AURA_MOD_INVISIBILITY:
	case SPELL_AURA_MOD_INVISIBILITY_DETECTION:
	case SPELL_AURA_MOD_POSSESS:
	case SPELL_AURA_EFFECT_IMMUNITY:
	case SPELL_AURA_STATE_IMMUNITY:
	case SPELL_AURA_DAMAGE_IMMUNITY:
	case SPELL_AURA_DISPEL_IMMUNITY:
	case SPELL_AURA_MOD_PARRY_SKILL:
	case SPELL_AURA_MOD_DODGE_SKILL:
	case SPELL_AURA_MOD_BLOCK_SKILL:
	case SPELL_AURA_PERIODIC_LEECH:
	case SPELL_AURA_MOD_HIT_CHANCE:
	case SPELL_AURA_MOD_SPELL_HIT_CHANCE:
	case SPELL_AURA_MOD_SPELL_CRIT_CHANCE:
	case SPELL_AURA_MOD_DAMAGE_DONE_CREATURE:
	case SPELL_AURA_MOD_CHARM:
	case SPELL_AURA_REFLECT_SPELLS:
	case SPELL_AURA_MOD_SKILL:
	case SPELL_AURA_PERIODIC_HEALTH_FUNNEL:
	case SPELL_AURA_PERIODIC_MANA_FUNNEL:
	case SPELL_AURA_PERIODIC_MANA_LEECH:
	case SPELL_AURA_MOD_CASTING_SPEED:
	case SPELL_AURA_FEIGN_DEATH:
	case SPELL_AURA_MOD_DISARM:
	case SPELL_AURA_MOD_STALKED:
	case SPELL_AURA_EXTRA_ATTACKS:
	case SPELL_AURA_MOD_SPELL_CRIT_CHANCE_SCHOOL:
	case SPELL_AURA_MOD_POWER_COST:
	case SPELL_AURA_MOD_POWER_COST_SCHOOL:
	case SPELL_AURA_REFLECT_SPELLS_SCHOOL:
	case SPELL_AURA_MOD_LANGUAGE:
	case SPELL_AURA_FAR_SIGHT:
	case SPELL_AURA_MECHANIC_IMMUNITY:
	case SPELL_AURA_MOD_DAMAGE_PERCENT_DONE:
	case SPELL_AURA_SPLIT_DAMAGE:
	case SPELL_AURA_WATER_BREATHING:
	case SPELL_AURA_MOD_BASE_RESISTANCE:
	case SPELL_AURA_CHANNEL_DEATH_ITEM:
	case SPELL_AURA_MOD_DAMAGE_PERCENT_TAKEN:
	case SPELL_AURA_MOD_PERCENT_REGEN:
	case SPELL_AURA_MOD_RESIST_CHANCE:
	case SPELL_AURA_MOD_DETECT_RANGE:
	case SPELL_AURA_PREVENTS_FLEEING:
	case SPELL_AURA_MOD_UNATTACKABLE:
	case SPELL_AURA_SPELL_MAGNET:
	case SPELL_AURA_MOD_SKILL_TALENT:
	default:
		{
#ifdef _DEBUG
//			LOG.outString ("AFFECT: Spell is trying to modify unhandled stat value.");
//			printf("unhandled aura type(name) %u\n",prototype->effect_apply_aura_name[aura_ind]);
#endif
		}break;
	}//end switch 1
	owner_obj->recalc_dinamic_stats();
}

//used by only some auras that need to do some specific action at some specific intervals. Like paladin aura should fade if too far from caster
void Spell_Affect_node::update(Base_Unit_Object	*owner_obj)
{
	if(cast_flags & CAST_ACTION_FLAG_LOCATION_DEPENDENT)
	{
		if((uint32)caster_guid==(uint32)owner_obj)
		{
			//check if spell needs to resend some visual effect
			//gather new target list 
			//apply effect on them
		}
		else
		{
			//if we are target then check if we exited the location of the cast. If so then no need to bare the effect anymore
			float dx=values[6]-owner_obj->pos_x;
			float dy=values[5]-owner_obj->pos_y;
			float loc_range_sq=dx*dx+dy*dy;
			if(loc_range_sq>prototype->radius[0]*prototype->radius[0])
			{
				owner_obj->affect_list->del(this);
				return;
			}
		}
	}
	else if(cast_flags & CAST_ACTION_FLAG_CASTER_DEPENDENT)
	{
		//this is mostly for paladin auras
		if((uint32)caster_guid==(uint32)owner_obj)
		{
			//check if spell needs to resend some visual effect
			//we simply recast the spell and hope for the best
			G_instant_spell_instance.set_caster(caster_guid,((Base_Unit_Object*)(caster_guid))->data32[UNIT_FIELD_FACTIONTEMPLATE]);
			G_instant_spell_instance.aura_refresh_cast_on_group(prototype->spell_id);
		}
		else
		{
			//if caster quited game or died then we should remove these dependent auras
			if(caster_guid_parts[1] & HIGHGUID_PLAYER)
			{
				//if player is not in our group then we can remove it
				Character	*c_char=(Character*)(caster_guid);
				Character	*o_char=(Character*)(owner_obj);
				if(o_char->group==NULL || !o_char->group->find(c_char))
				{
					owner_obj->affect_list->del(this);
					return;
				}
				//check if caster is still in range
				float dx=c_char->pos_x-owner_obj->pos_x;
				float dy=c_char->pos_y-owner_obj->pos_y;
				if(abs(dx)>CHAR_AURA_REMOVE_RANGE || abs(dy)>CHAR_AURA_REMOVE_RANGE)
				{
					owner_obj->affect_list->del(this);
					return;
				}
			}
			else
			{
				//in this case caster was a unit
				creature	*c_cr=(creature*)(caster_guid);
				if(c_cr->folowed_char && c_cr->folowed_char->group->find((Character*)(owner_obj)))
				{
					owner_obj->affect_list->del(this);
					return;
				}
				//check if caster is still in range
				float dx=c_cr->pos_x-owner_obj->pos_x;
				float dy=c_cr->pos_y-owner_obj->pos_y;
//				float caster_range_sq=dx*dx+dy*dy;
//				if(CHAR_AURA_REMOVE_RANGE_SQ<caster_range_sq)
				if(abs(dx)>CHAR_AURA_REMOVE_RANGE_SQ || abs(dy)>CHAR_AURA_REMOVE_RANGE_SQ)
				{
					owner_obj->affect_list->del(this);
					return;
				}
			}
		}
	}
}

spell_cooldown_node::spell_cooldown_node(uint32 p_spell_id,uint32 cooldown)
{
	spell_id=p_spell_id;
	end_time_stamp = G_cur_time + cooldown / 1000;
	next=NULL;
}

void Spell_cooldown_list::add(uint32 spell_id,uint32 cooldown)
{
	//remove unused values
	update();
	//insert this value to first position
//printf("trying to add a new cooldown value %u for spell %u\n",cooldown,spell_id);
	if(cooldown>MIN_COOLDOWN_LIMIT_TO_REMAMBER)
	{
		//check if this spell_id is already used
		spell_cooldown_node *itr=first;
		while(itr && itr->spell_id!=spell_id)
			itr = itr->next;
		uint32 new_timestamp =G_cur_time + cooldown / 1000;
		if(itr && itr->end_time_stamp<new_timestamp)
			itr->end_time_stamp = new_timestamp;
		else
		{
			spell_cooldown_node *newnode;
			newnode = new spell_cooldown_node(spell_id,cooldown);
			newnode->next = first;
			first = newnode;
		}
	}
}
void Spell_cooldown_list::update()
{
	//search through the list and dump values that we do not save anymore
	spell_cooldown_node *itr=first,*prev=NULL;
	while (itr)
	{
		if(itr->end_time_stamp<=G_cur_time)
		{
			spell_cooldown_node *delme;
			delme = itr;
			if(prev) prev->next = itr->next;
			if(itr==first) first = first->next;
			prev = itr;
			itr = itr->next;
			delete delme;
		}
		else
		{
			prev = itr;
			itr = itr->next;
		}
	}
}
