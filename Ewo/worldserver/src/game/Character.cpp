// Copyright (C) 2006 Team Evolution
#include "Character.h"
#include "GameClient.h"

inline float distance(float x1,float y1,float x2, float y2)
{
	float dist_x=x1-x2;
	float dist_y=y1-y2;
	return sqrt(dist_x*dist_x+dist_y*dist_y);
}

inline float distance_sq(float x1,float y1,float x2, float y2)
{
	float dist_x=x1-x2;
	float dist_y=y1-y2;
	return dist_x*dist_x+dist_y*dist_y;
}

inline float distance(float x1,float y1,float z1,float x2, float y2,float z2)
{
	float dist_x=x1-x2;
	float dist_y=y1-y2;
	float dist_z=z1-z2;
	return sqrt(dist_x*dist_x+dist_y*dist_y+dist_z*dist_z);
}

Character::Character ()
{
    data32 = (uint32 *)malloc(PLAYER_END*4);
    ASSERT(data32);
    update_mask.SetCount(PLAYER_END+4);
    packet_mask.SetCount(PLAYER_END+4);	//used for create packet
	skill_list=(skill_entry *)&data32[PLAYER_SKILL_INFO_1_1];
	obj_type = HIGHGUID_PLAYER;
	Refurbish();
}

//can be called by object pool to bring item object into a state where it can be reused
void Character::Refurbish()
{
    memset(data32,0,PLAYER_END*4);
    data32[OBJECT_FIELD_TYPE] = OBJECT_TYPE_PLAYER;
	set_guid();//new object so we regenerate guid
    strcpy(name,"");
//    data32[PLAYER_FIELD_WATCHED_FACTION_INDEX] = 0xEEEEEEEE;
    update_mask.Clear();
    m_petInfoId = 0;
    m_petLevel = 0;
    m_petFamilyId = 0;
	speed_land_modifyer = 1;
	speed_water_modifyer = 1;
	state1 = 0;
	prev_x = prev_y = prev_z = prev_orientation = 0;
//	cache_id_create = 0;
//	cache_create_length_total = 0;
	health = 1;	//to prevent bug that on first update player dies
	power = 1; //just so it's not 0 (no meaning of it)
	afk = 0;
    player_powertype = 0;
	last_used_gameobject_guid = 0;
	selected_object_guid = 0;
	last_target_GUID = 0;
	water_submerge = 0;
	water_dmg = 0;
	group = NULL;
	group_invitated_by = NULL;
	target=NULL;
	//empty bags
	pcorpse = NULL;
	for(int i=0;i<PLAYER_USED_DMG_TYPES;i++)
	{
		item_min_dmg[i]=0;
		item_max_dmg[i]=0;
		dmg_min[i]=0;
		dmg_diff[i]=1;
		spell_min_dmg[i]=0;
		spell_max_dmg[i]=0;
		spell_res_pct[i]=0;
		spell_res_pct_values[i]=0;
	}
	quests_started.owner = this;
	spell_queue_len = 0;
	last_atacker_guid = 0;
	looted_object_guid = 0;
	last_vendor_used = NULL;
	memset(quest_loot_item_ids,0,20*4*sizeof(uint32));
	areatrigger_lastcheck_x = pos_x;
	areatrigger_lastcheck_y = pos_y;
	areatrigger_lastcheck_z = pos_z;
	speed_attack_modifyer = 1;
	flags1 = 0;
	pClient = NULL;
	spell_extra_healing = 0;
	spell_extra_healing_pct = 1;
	spell_animation=0;
	memset(folower_matrix,NULL,25*sizeof(creature*));
	mechanic_rezistance = 0;
	offhand_dmg_mod = 0;//dmg multiplyer
	offhand_dmg_mod_pct = 1;
	state2 = 0;
	memset(totems,NULL, sizeof(creature*)*CHARACTER_MAX_TOTEMS);
	rage_conversion=1;
	cache_id_update = 0;
	cache_update_length_total = 0;
	agro_x = agro_y = 0;
	rooted_count = 0;
	silenced_count = 0;
	pacified_count = 0;
	target = NULL;
	threat_generated = UNITS_BASE_THREAT_GENERATE;
//	threat_generate_mod = 1;
	health_regen_spell = 0;
	power_regen_spell = 0;
	shapeshift_stats_backup = NULL; //this is released by affect if it is null on refurbish
	agro_sent_time = 0;
    zone_id = 0;
	//on char enum list these are not cleared by logout 
    spellbook.clear(); 
    affect_list->clear();
    spell_cooldowns.clear();
	quests_finished.clear();
	quests_started.clear();
	on_attack_spell_dmg.clear();
	on_struck_spell_dmg.clear();
	memset(&duel_info,0,sizeof(Duel_Info));
/*
	//these will be set due to initialization
	memset(reputation,0,NUMBER_OF_FACTIONS);
	memset(reputation_val,0,NUMBER_OF_FACTIONS*4);
	bind_x = bind_y = bind_z = bind_orientation = 0;
	bind_map_id = bind_area_id = bind_zone_id;
	account_id = zone_id = 0;
	memset(actionbuttons,0,NUMBER_OF_ACTION_BUTTONS*4);
	cache_data_update = NULL;
	corpse_x = corpse_y = corpse_z = corpse_o = 0;
    map_id = 0;
	bind_map_id = 0;
	bind_area_id = 0;
    pos_x = pos_y = pos_z = orientation = 0;
	memset(spell_queue,0,CHAR_SPELL_QUEUE_MAXLEN*4);
*/
#ifndef DISABLE_CUSTOM_TRIGGER_CHECKS
	areatrigger_lastcheck_x=areatrigger_lastcheck_y=areatrigger_lastcheck_z=0;
#endif
}

Character::~Character ()
{
	uint32 i;
   //destroy items for char
	for ( i = PLAYER_FIELD_INV_SLOT_HEAD+0; i < PLAYER_FIELD_INV_SLOT_HEAD + BANK_SLOT_BAG_END*2; i +=2)
	{
		if(data32[i]!=0) 
		{
			//delete bag content
			if((INVENTORY_SLOT_BAG_START*2+PLAYER_FIELD_INV_SLOT_HEAD)<=i && i<(INVENTORY_SLOT_BAG_END*2+PLAYER_FIELD_INV_SLOT_HEAD))
			{
				Item *cur_bag=((Item*)data32[i]);
				uint32 bag_slot_iter;
				for (bag_slot_iter=CONTAINER_FIELD_SLOT_1;bag_slot_iter<CONTAINER_END;bag_slot_iter+=2)
					if(cur_bag->data32[bag_slot_iter]!=0)
						G_Object_Pool.Release_item(((Item*)cur_bag->data32[bag_slot_iter]));
			}
			G_Object_Pool.Release_item((Item*)data32[i]); //delete whatever item it is
		}
	}
   spellbook.clear();
   affect_list->clear();
   spell_cooldowns.clear();
}

void  Character::load_from_db()
{
    //loads bytes as they were saved, items, spellbook
	G_dbi_r->load_character(this);
   //set the guid 
   state1 &= ~(PLAYER_STATE_IN_COMBAT | PLAYER_STATE_INVITED_TO_GROUP | PLAYER_STATE_MOVED_SINCE_LAST_UPDATE | PLAYER_STATE_PREPARE_SPELL | PLAYER_STATE_STUNNED | PLAYER_STATE_DROWNING);
   if(!((state1 & PLAYER_STATE_DEAD) || (state1 & PLAYER_STATE_CORPSE)))
   {
		//give him some health to not die on create.This must be replaced with apropriate char init
		data32[UNIT_FIELD_HEALTH] = data32[UNIT_FIELD_MAXHEALTH];
		health = (float)(data32[UNIT_FIELD_HEALTH]);
		if(player_powertype==Unit_Power_Type_Rage)
		{
			data32[UNIT_FIELD_POWER1+player_powertype] = 0;
			power = 0;
		}
		else power = (float)data32[UNIT_FIELD_POWER1+player_powertype];
   }
	flag_clr(PLAYER_FLAGS,PLAYER_FLAG_GROUP_LEADER);
	data32[PLAYER_FIELD_BYTES]= 0xEEEE0000; //this stores combo points
//   _LoadMail();
//   _LoadBids();
//   _LoadTutorials();
//   _LoadHonorStatus();
}

//simply save char to db
void Character::save_to_db()
{
	G_dbi_r->save_character(this);
}

void Character::build_enum_block (uint8 * data, uint8 * length)
{
   ASSERT(data);
   uint32 data_index,i;
   uint16 name_size = 0;
   uint32 temp;
   //add guid and type
   *(uint32*)&data[0] = getGUIDL();
   *(uint32*)&data[4] = getGUIDH();
   strcpy((char*)&data[8],name);
   name_size = strlen(name);
   data_index = name_size+1+8;
   temp = data32[UNIT_FIELD_BYTES_0];
   data[data_index++] = uint8(temp & 0xff);         // race
   data[data_index++] = uint8((temp >> 8) & 0xff);   // class
   data[data_index++] = uint8((temp >> 16) & 0xff);   // gender
   temp = data32[PLAYER_BYTES];
   data[data_index++] = uint8(temp & 0xff);         //skin
   data[data_index++] = uint8((temp >> 8) & 0xff);   //face
   data[data_index++] = uint8((temp >> 16) & 0xff);   //hairstyle
   data[data_index++] = uint8((temp >> 24) & 0xff);   //haircolor
   temp = data32[PLAYER_BYTES_2];
   data[data_index++] = uint8(temp & 0xff);   //facialhair
   data[data_index++] = uint8(data32[UNIT_FIELD_LEVEL]); //level
   *(uint32*)&data[data_index] = zone_id; data_index+=4;
   *(uint32*)&data[data_index] = map_id; data_index+=4;
   *(float*)&data[data_index] = pos_x; data_index+=4;
   *(float*)&data[data_index] = pos_y; data_index+=4;
   *(float*)&data[data_index] = pos_z; data_index+=4;
   *(uint32*)&data[data_index] = data32[PLAYER_GUILDID]; data_index+=4;
   *(uint32*)&data[data_index] = data32[PLAYER_GUILDRANK]; data_index+=4;
   data[data_index++] = m_isRested;
   *(uint32*)&data[data_index] = m_petInfoId; data_index+=4;
   *(uint32*)&data[data_index] = m_petLevel; data_index+=4;
   *(uint32*)&data[data_index] = m_petFamilyId; data_index+=4;
   //items
   for ( i = PLAYER_FIELD_INV_SLOT_HEAD+0; i < PLAYER_FIELD_INV_SLOT_HEAD + 20*2; i +=2)
	   if(data32[i]!=0)
	   {
		   *(uint32*)&data[data_index] = ((Item*)data32[i])->item_data32[ITEM_DISPLAY_INFO_ID];
		   data_index+=4;
		   data[data_index++] = ((Item*)data32[i])->item_data32[ITEM_INVENTORY_TYPE];
	   }
	   else
	   {
		   *(uint32*)&data[data_index] = 0;
		   data_index+=4;
		   data[data_index++] = 0;
	   }/**/
   *length = data_index;
}

//this a create object packet builder-> we send all not 0 values to client to build right this type of object
//!!!! important 2do is to fix this, this is not functioning correctly and could not find the bug
// 1) if you send the updatemask beeing FF, he will ecxept X blocks in the packet. 
// 1.1) if you send all values, object will not spawn
//If you do it the "right" way by sending only non 0 values ,he will crash
// Notice : values are not initilized. The problem is in the last 70*4 bytes
//If we use this methode(not able to fix it) then we should have a static mask and make a memcpy for all values
void Character::build_create_block(Compressed_Update_Block *packet,uint32 target_self)
{
   if((state1 & PLAYER_STATE_DEAD) && (target_self==0))
	   return;//no need to create us while we are dead
   uint8 *data;
   float *packetf;
   uint32 *packet32;
   uint32 i;
   for ( i = PLAYER_FIELD_INV_SLOT_HEAD+0; i < PLAYER_FIELD_INV_SLOT_HEAD + EQUIPMENT_SLOT_END*2; i +=2)
	   if(data32[i]!=0) 
		   ((Item*)data32[i])->build_create_block(packet,0);
   if (target_self)
	   for (; i < PLAYER_FIELD_INV_SLOT_HEAD + BANK_SLOT_BAG_END*2; i +=2)
	   {
		   if(data32[i]!=0) 
		   {
			   ((Item*)data32[i])->build_create_block(packet,0);
			   //create bag content for self
			   if((INVENTORY_SLOT_BAG_START*2+PLAYER_FIELD_INV_SLOT_HEAD)<=i && i<(INVENTORY_SLOT_BAG_END*2+PLAYER_FIELD_INV_SLOT_HEAD))
			   {
				   Item *cur_bag=((Item*)data32[i]);
				   uint32 bag_slot_iter;
				   for (bag_slot_iter=CONTAINER_FIELD_SLOT_1;bag_slot_iter<CONTAINER_END;bag_slot_iter+=2)
					   if(cur_bag->data32[bag_slot_iter]!=0)
						   ((Item*)cur_bag->data32[bag_slot_iter])->build_create_block(packet,0);
			   }
		   }
	   }
   data = packet->get_next_pointer();
   if(target_self)   data[0] = UPDATETYPE_CREATE_YOURSELF; //type of the block
   else data[0] = UPDATETYPE_CREATE_OBJECT; //type of the block
   data[1] = 0xFF; //guid mask
   *(uint64*)(&data[2])	= *(uint64*)data32; //the guid
   data[10] = TYPEID_PLAYER; //TYPEID_PLAYER = 4
   if(target_self)  data[11] = 0x71; //flags1 sandbox=71
   else data[11] = 0x70;
   packetf = (float*)&data[12];
   packet32=(uint32*)&data[12];
   packet32[0]=0; //flags2 sandbox uses 0x2000
   packet32[1]=G_cur_time_ms;
   packetf[2]=pos_x; 
   packetf[3]=pos_y; 
   packetf[4]=pos_z; 
   packetf[5]=orientation; 
   packetf[6]=0; 
   // build and add the movement update portion of the packet
   packetf[7]=speed_land_modifyer*UNIT_NORMAL_WALK_SPEED;
   packetf[8]=speed_land_modifyer*UNIT_NORMAL_RUN_SPEED;
   packetf[9]=speed_land_modifyer*UNIT_NORMAL_WALK_BACK_SPEED;
   packetf[10]=speed_water_modifyer*UNIT_NORMAL_SWIM_SPEED;
   packetf[11]=speed_water_modifyer*UNIT_NORMAL_SWIM_BACK_SPEED;
   packetf[12]=speed_land_modifyer*UNIT_NORMAL_FLY_SPEED;
   packetf[13]=speed_land_modifyer*UNIT_NORMAL_FLY_BACK_SPEED;
   packetf[14]=speed_land_modifyer*UNIT_NORMAL_TURN_SPEED;
   packet32[15]=target_self; //1 = active player, 0 else , this can be removed from packet if using flag 1 0x60 !
   packet_mask.Clear();

   //set bits and add values to packet
   data[76]=(uint8)packet_mask.GetBlockCount();//16*4+12
   uint32 len,pos;
   len = 77 + packet_mask.GetBlockCount()*4;
   packet32 = (uint32*)&data[len];
   pos = 0;
   for( i=0; i<PLAYER_END; i++)
   if(data32[i]!=0)
   {
      packet_mask.SetBit(i);
      packet32[pos++] = data32[i];
   }
   //add bitmask to packet
   memcpy(&data[77],packet_mask.GetMask(),packet_mask.GetBlockCount()*4);
   packet->add_virtual_packet(len+pos*4);
}

//updatemask does not care if it is for self or not
//more updatepacks can be grouped into 1 A9
void Character::build_update_block(Compressed_Update_Block *packet,uint32 target_self,uint8 clear_mask)
{
	uint8 *data=packet->get_next_pointer();
	//if we updated ourself this turn then we have to send it to others 2
	//we simply copy updata to other packets from our packet. We do not wish to copy it to us again
	if(cache_id_update==G_turn_id && &pClient->compressed_update!=packet)
	{
		memcpy(data,cache_data_update,cache_update_length_total);
		*(uint32*)&data[62]=target_self; //1 = active player, 0 else
		packet->add_virtual_packet(cache_update_length_total);
		return;
	}
	//check if we have anithing to update at all. We also check if stupid coder forgot that he already created packet :P
	if(cache_id_update==G_turn_id || update_mask.IsEmpty())
		return;
	uint32 *packet32;
	uint32 i;
	data[0]=UPDATETYPE_VALUES; //type of the block
	data[1]=0xFF; //type of the block
	*(uint32*)(data+2)=data32[OBJECT_FIELD_GUID]; //the guid
	*(uint32*)(data+6)=data32[OBJECT_FIELD_GUID+1]; //the guid
	//set bits and add values to packet
	data[10]=(uint8)update_mask.GetBlockCount();
	uint32 len,pos;
	len = 11 + update_mask.GetBlockCount()*4;
	packet32 = (uint32*)&data[len];
	pos = 0;
	for( i=0; i<PLAYER_END; i++)
	if(update_mask.GetBit(i))
		packet32[pos++] = data32[i];
	//add bitmask to packet
	memcpy(&data[11],update_mask.GetMask(),update_mask.GetBlockCount()*4);
	packet->add_virtual_packet(len+pos*4);
	if(clear_mask)	update_mask.Clear();
	if(&pClient->compressed_update==packet)
	{
		cache_id_update = G_turn_id;
		cache_update_length_total = len+pos*4;
		cache_data_update = data;
	}
}
/**/
void Character::Create (NetworkPacket &data )
{
	//interupt wich can oweride this function
#ifdef USE_OBJECT_INTERRUPTS
	if(On_Player_Create(this)==1)
		return;
#endif
    uint8 skin,face,hairStyle,hairColor,facialHair,outfitId;
	uint8 player_race,player_class,player_gender;
	uint32 pos;
    //prepare name 
	strcpy(name,(char*)&data.data[0]);
	pos =strlen(name)+1;
	player_race = data.data[pos++];
	player_class = data.data[pos++];
//printf("trying to create new player with race %u and class %u\n",player_race,player_class);
	player_gender = data.data[pos++];
	skin = data.data[pos++];
	face = data.data[pos++];
	hairStyle = data.data[pos++];
	hairColor = data.data[pos++];
	facialHair = data.data[pos++];
	outfitId = data.data[pos++];
    //we load the template for this player : stats,reputation,actionbuttons
	G_dbi_r->load_character_template(this,player_race,player_class);
	set_guid();//until not saved the guid is not correct here
	//clear all explored zones
	for (int i = 0; i < 64; i++)
      SetUInt32Value (PLAYER_EXPLORED_ZONES_1 + i, 0);
    data32[OBJECT_FIELD_TYPE]=OBJECT_TYPE_PLAYER;
	state1 = PLAYER_STATE_JUST_CREATED;
	//customize it with data that we recevied
    //name like in the original (bullshit comunist idea :D )
    strlwr (name);
    name[0] = toupper (name[0]);
    //GUID is already set in constructor
    SetUInt32Value (OBJECT_FIELD_TYPE, OBJECT_TYPE_PLAYER);
    //define power type
    SetUInt32Value(UNIT_FIELD_BYTES_1, 0x0000EE00 );//do not move this line !
	switch(player_class)
    {
      case PLAYER_CLASS_WARRIOR :
		  {
			  player_powertype = Unit_Power_Type_Rage;
			  SetUInt32Value(UNIT_FIELD_MAXPOWER1 + Unit_Power_Type_Rage,1000);
			  SetUInt32Value(UNIT_FIELD_BYTES_1, 0x1100EE00 );
		  }break; 
      case PLAYER_CLASS_PALADIN : {         player_powertype = Unit_Power_Type_Mana;      }break; 
      case PLAYER_CLASS_HUNTER  : {         player_powertype = Unit_Power_Type_Mana;      }break;
      case PLAYER_CLASS_ROGUE   : 
		  {
			  player_powertype = Unit_Power_Type_Energy;    
			  SetUInt32Value(UNIT_FIELD_MAXPOWER1 + Unit_Power_Type_Energy,100);
		      SetUInt32Value(UNIT_FIELD_BYTES_1, 0x00000000 );
		  }break;
      case PLAYER_CLASS_PRIEST  : {         player_powertype = Unit_Power_Type_Mana;      }break;
      case PLAYER_CLASS_SHAMAN  : {         player_powertype = Unit_Power_Type_Mana;      }break;
      case PLAYER_CLASS_MAGE    : {         player_powertype = Unit_Power_Type_Mana;      }break;
      case PLAYER_CLASS_WARLOCK : {         player_powertype = Unit_Power_Type_Mana;      }break;
      case PLAYER_CLASS_DRUID   : {         player_powertype = Unit_Power_Type_Mana;      }break;
     }
    //all values have been set to 0 by constructor
    if(player_race < 7) SetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE, player_race );
	else if(player_race==PLAYER_RACE_TYPE_DRAENEI)SetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE, 1629);
	else if(player_race==PLAYER_RACE_TYPE_BLOODELF)SetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE, 1610);
    else SetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE, player_race+108 );
	SetFloatValue(OBJECT_FIELD_SCALE_X, 1.0f);
	SetUInt32Value(UNIT_FIELD_BYTES_0, ( ( player_race ) | ( player_class << 8 ) | ( player_gender << 16 ) | ( player_powertype << 24 ) ) );
    SetUInt32Value(UNIT_FIELD_BYTES_2, 0xEEEEEE00 );
	if(player_race==PLAYER_RACE_TYPE_BLOODELF && player_gender==1)
        SetUInt32Value(UNIT_FIELD_DISPLAYID, data32[UNIT_FIELD_DISPLAYID]-1); //this just has to be special
    else SetUInt32Value(UNIT_FIELD_DISPLAYID, data32[UNIT_FIELD_DISPLAYID]+player_gender); //info->displayId + gender );
    SetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID, data32[UNIT_FIELD_DISPLAYID]);		   //info->displayId + gender );
	SetUInt32Value(PLAYER_BYTES, ((skin) | (face << 8) | (hairStyle << 16) | (hairColor << 24)));
    SetUInt32Value(PLAYER_BYTES_2, (facialHair | (0xEE << 8) | (0x00 << 16) | (0x02 << 24)));
    SetUInt32Value(PLAYER_BYTES_3, player_gender);
    SetUInt32Value(PLAYER_FIELD_BYTES, 0xEEE00000 );
	SetUInt32Value(UNIT_FIELD_LEVEL, 1);
	SetUInt32Value(UNIT_DYNAMIC_FLAGS, 0x10);
    SetUInt32Value(PLAYER_NEXT_LEVEL_XP, 400);
	SetUInt32Value(UNIT_FIELD_FLAGS,U_FIELD_FLAG_PLAYER_CONTROLLED);
	SetUInt32Value(UNIT_FIELD_BASEATTACKTIME,2000);
	SetUInt32Value(UNIT_FIELD_BASEATTACKTIME+1,2000);
	SetUInt32Value(UNIT_FIELD_RANGEDATTACKTIME,2000);
	SetFloatValue(UNIT_FIELD_BOUNDINGRADIUS,0.39f);
	SetFloatValue(UNIT_FIELD_COMBATREACH,1.5f);
	SetUInt32Value(PLAYER_FIELD_WATCHED_FACTION_INDEX,0xEEEEEEEE);
	recalc_base_stats();
	recalc_dinamic_stats();
}

void Character::update(uint32 time_diff)
{
#ifdef DEBUG_CHAR_VERSION
	uint32 start_time,end_time;
	start_time = GetMilliseconds();
#endif
#ifdef USE_OBJECT_INTERRUPTS
	On_Player_Update(this);
#endif
	//!! do not clear updatemask, it is posibble that values were changed elsewhere and we wanna keep those changes 2
	//!! use ifs so instant actions can flow in only 1 turn
	//!! action flow should be ordered descending so instant actions can jump from 1 to another
	//printf("\n updating char with %u ms\n",time_diff);
#ifdef VERSION_CHAR_MAKE_CREAUTURE_WPOINTS
	if((state2 & CHAR_STATE_TO_DO_CREATURE_CORDS) == CHAR_STATE_TO_DO_CREATURE_CORDS)
	{
		handle_generate_z_cords_state();
		return;
	}
#endif 
	if(state1 & PLAYER_STATE_DEAD)
	{
		if(!(state1 & PLAYER_STATE_CORPSE) && atimer2 <= G_cur_time_ms)
			on_char_corpse();
		return;
	}
//	timer1 -=time_diff;
	affect_list->update();
	//check for underwater timer and decrease health if so
//printf("is in water = %u, health %f, water_submerge %u\n",(state1 & PLAYER_STATE_IN_WATER),health,water_submerge);
	if((state1 & PLAYER_STATE_IN_WATER) && (health>1) && (water_submerge!=0))
	{
		uint32 total_time=G_cur_time_ms-water_submerge;
		uint32 breath_timer=UNDERWATER_BREATH_TIMER;
		if(Get_race()==PLAYER_RACE_TYPE_UNDEAD)
			breath_timer *=2;
//printf("can decrease health, timer diffrence is %d, limit is : %d ",total_time,UNDERWATER_BREATH_TIMER);
		if(total_time>breath_timer)
		{
			total_time -=breath_timer;
			float dmg=(total_time)*UNDERWATER_DMG - water_dmg;
//printf("decreasing health %d\n",(uint32)dmg);
			take_dmg(dmg,0,0,1,255);
			water_dmg = dmg; //we already made this amount of dmg
	        //send enviromental dmg log to client
		    G_send_packet.opcode = SMSG_ENVIRONMENTALDAMAGELOG;
			G_send_packet.data64[0] = getGUID(); //drowning dmg
			G_send_packet.data[8] = ENVIROMENTAL_DAMAGE_DROWNING;
			*(uint32*)&G_send_packet.data[9] = (uint32)dmg;
			*(uint32*)&G_send_packet.data[13] = 0;
			*(uint32*)&G_send_packet.data[17] = 0;
			G_send_packet.length = 21;
			pClient->SendMsg(&G_send_packet);
			state1 |= PLAYER_STATE_DROWNING;
//printf("underwater timers : %u , dmg = %f\n",time(NULL)-water_submerge,dmg);
		}
	}
//	if((state1 & PLAYER_STATE_MOVED_SINCE_LAST_UPDATE) && (state1 & (PLAYER_STATE_PREPARE_SPELL | PLAYER_STATE_CAST_SPELL)) && cur_spell.prototype->cast_time!=0)
	if((state1 & PLAYER_STATE_MOVED_SINCE_LAST_UPDATE) && (state1 & (PLAYER_STATE_PREPARE_SPELL)) && cur_spell.prototype->cast_time!=0)
	{
		//check if it has already been cast on us and remove it (channeled spells)
		cur_spell.cancel_cast();
		//remove states
		state1 &=~(PLAYER_STATE_PREPARE_SPELL | PLAYER_STATE_CAST_SPELL);
		spell_queue_len = 0;
	}
	else if(state1 & UNIT_STATE_CONFUSED)
	{
		orientation = orientation + CONFUSED_UNIT_SPIN_SPEED;
		if(orientation>6.14f)
			orientation -= 6.14f;
		update_obj_pos(NULL);
	}
	else if(atimer1<=G_cur_time_ms)
	{
//printf("ready to take some action\n");
		if((state1 & PLAYER_STATE_PREPARE_SPELL))
		{
			//remove flag
			state1 &= ~PLAYER_STATE_PREPARE_SPELL;
			state1 |= PLAYER_STATE_CAST_SPELL;
			cur_spell.cast();
			//				cur_spell.msg_spell_cooldown();//cast is almoust instant so we can already send cooldown(this way it will not be broken if moving)
			atimer1 += cur_spell.prototype->cast_time;
//printf("casting spell\n");
		}
		else if((state1 & PLAYER_STATE_CAST_SPELL))
		{
			//fill targets with affect of current spell
			state1 &= ~PLAYER_STATE_CAST_SPELL;
			state1 |= PLAYER_STATE_COOLDOWN_SPELL;
			atimer1 += cur_spell.prototype->recovery_time;
		}
		else if((state1 & PLAYER_STATE_COOLDOWN_SPELL))
		{
			state1 &= ~PLAYER_STATE_COOLDOWN_SPELL;
			//send client that we are finished casting
			if(cur_spell.prototype->channel_interrupt_flags!=0)
				cur_spell.msg_spell_channel_update(0);
			//check if we have some queued spells for items
			if(spell_queue_len>0)
			{
				//printf("casting queueed spell from slot %u id %u\n",spell_queue_len,spell_queue[spell_queue_len]);
				//we should prepare data so in the next char update, the spell will start casting
				cur_spell.init_qued(spell_queue[spell_queue_len]);
				//start casting the spell
				cur_spell.msg_spell_start_cast();
				start_cast();
				spell_queue_len--;
			}
			else cur_spell.item_caster_guid = 0;
			atimer1 = G_cur_time_ms-data32[UNIT_FIELD_BASEATTACKTIME];
		}
		if((state1 & PLAYER_STATE_IN_COMBAT) && G_cur_time_ms >= atimer1)
		{
			//check conditions if we can swing, and do dmg
			//			printf("character is trying to swing\n");
			on_atack_swing();
		}
	}
	if((state1 & (PLAYER_STATE_DUEL_PREPARE | PLAYER_STATE_IN_DUEL | PLAYER_STATE_DUEL_UTOFBOUNDS)))
	{
		if((state1 & PLAYER_STATE_IN_DUEL))
		{
			//make sure we do not exited dual arbiter range.
			float dx=duel_info.dual_arbiter->pos_x-pos_x;
			float dy=duel_info.dual_arbiter->pos_y-pos_y;
			float range_sq=dx*dx+dy*dy;
			if(range_sq>DUEL_AREA_RANGE_SQ)
			{
				//just exited the arbiter range
				if(!(state1 & PLAYER_STATE_DUEL_UTOFBOUNDS))
				{
					//we did
					state1 |=PLAYER_STATE_DUEL_UTOFBOUNDS;
					duel_info.atimer1 = G_cur_time_ms + 10000;
					G_send_packet.opcode = SMSG_DUEL_OUTOFBOUNDS;
					G_send_packet.length = 0;
					SendMsg(&G_send_packet);
				}
				else if(duel_info.atimer1 <= G_cur_time_ms)
				{
					finish_duel(2);//loose=flee, no wining to the enemy though
					duel_info.target->state1 &= ~(PLAYER_STATE_DUEL_UTOFBOUNDS | PLAYER_STATE_IN_DUEL | PLAYER_STATE_DUEL_PREPARE);
					state1 &= ~(PLAYER_STATE_DUEL_UTOFBOUNDS | PLAYER_STATE_IN_DUEL | PLAYER_STATE_DUEL_PREPARE);
				}
			}
			else if((state1 & PLAYER_STATE_DUEL_UTOFBOUNDS))
			{
				state1 &= ~PLAYER_STATE_DUEL_UTOFBOUNDS;
				G_send_packet.opcode = SMSG_DUEL_INBOUNDS;
				G_send_packet.length = 0;
				SendMsg(&G_send_packet);
			}
		}
		else if((state1 & PLAYER_STATE_DUEL_PREPARE) && duel_info.atimer1 <= G_cur_time_ms)
		{
			duel_info.target->SetUInt32Value(PLAYER_DUEL_TEAM,(duel_info.target==duel_info.initiator)+1);
			state1 &= ~PLAYER_STATE_DUEL_PREPARE;
			state1 |= PLAYER_STATE_IN_DUEL;
//			duel_info.atimer1 = 0;
		}
	}
	if(spell_animation && atimer2<G_cur_time_ms)
	{
		cur_spell.play_spell_visual(spell_animation);
		atimer2 = G_cur_time_ms+PLAY_SPELL_VISUAL_DELAY;
//printf("playing visual %u\n",cur_spell.prototype->spell_id);
	}
	if(health<1)
	{
		//set dead state, look for interrupts to resurect, take other actions... 
		die();
#ifdef USE_OBJECT_INTERRUPTS
		used_interrupt=On_Player_Just_Died(pClient->mCurrentChar);
#endif
	}
	else if(!(state1 & PLAYER_STATE_DROWNING))
	{
		if(state1 & PLAYER_STATE_IN_COMBAT)
		{
			health += (health_regen*0.25f+health_regen_spell)*time_diff;
			power += (power_regen*0.25f+power_regen_spell)*time_diff;
		}
		else
		{
			health += (health_regen+health_regen_spell)*time_diff;
			power += (power_regen+power_regen_spell)*time_diff;
		}
		if(health>=data32[UNIT_FIELD_MAXHEALTH])health = (float)data32[UNIT_FIELD_MAXHEALTH];
		else if(health<0)health=0;
		if(power>=data32[UNIT_FIELD_MAXPOWER1+player_powertype])power = (float)data32[UNIT_FIELD_MAXPOWER1+player_powertype];
		else if(power<0)power=0;
	}
	//if we moved enough or creatures might got respawned then we resend agro to creatures
	if(((agro_sent_time < G_cur_time_ms) ||
		abs(agro_x - pos_x)>CHARACTER_MOVE_TO_UPDATE_AGRO ||
		abs(agro_y - pos_y)>CHARACTER_MOVE_TO_UPDATE_AGRO) &&
		threat_generated > 0)
	{
//printf("sending out agro with threat : %u\n",threat_generated);
		agro_x = pos_x;
		agro_y = pos_y;
		agro_sent_time = G_cur_time_ms + WORLD_MIN_UPDATE_INTERVAL*PLAYER_AGRO_SEND_TIME_INTERVAL;
		G_maps[map_id]->agro_block(this);
		if(threat_generated>UNITS_BASE_THREAT_GENERATE)
			threat_generated--;//threat decreases in time
	}
	SetUInt32Value(UNIT_FIELD_HEALTH,(uint32)health);
	SetUInt32Value(UNIT_FIELD_POWER1+player_powertype,(uint32)power);
	state1 &=~PLAYER_STATE_MOVED_SINCE_LAST_UPDATE; //remove "moved" flag
	//return a packet with updated values to be sent to whole block
#ifdef DEBUG_CHAR_VERSION
	end_time = GetMilliseconds();
	if(end_time-start_time>0)
		LOG.outString ("Debugger: requred time = %u ms to update 1 character",end_time-start_time);
#endif
}

void Character::on_atack_swing()
{
	float total_dmg=0,total_blocked=0;
	//reset timer whatever the result is
//printf("next atack should be in %d miliseconds,baseatacktime %d, coef %f \n",(uint32)(data32[UNIT_FIELD_BASEATTACKTIME]*speed_attack_modifyer),data32[UNIT_FIELD_BASEATTACKTIME],speed_attack_modifyer);
//	atimer1 = G_cur_time_ms + (uint32)(data32[UNIT_FIELD_BASEATTACKTIME]*speed_attack_modifyer);
	atimer1 += (uint32)(data32[UNIT_FIELD_BASEATTACKTIME]*speed_attack_modifyer);
	//what are we trying to hit ? If it's a creature then we have to agro him
	if(target)
	{
		if(pacified_count)
		{
			G_send_packet.opcode = SMSG_ATTACKSWING_CANT_ATTACK;
			G_send_packet.length = 0;
			pClient->SendMsg(&G_send_packet);
			rage_modify_on_hit(get_dmg(0));
			return;
		}
		//even if we get swing opcode not always we can hit him
//		if(distance(pos_x,pos_y,target_cr->pos_x,target_cr->pos_y)>data32[UNIT_FIELD_COMBATREACH])
		if(distance_sq(pos_x,pos_y,target->pos_x,target->pos_y)>CREATURE_ATACK_RANGE_SQ)
		{
			//in case server pos is not synced with client pos we force update the damn client
			if((target->state1 & CREATURE_STATE_MOVED_SINCE_SYNC) && !(target->state1 & (CREATURE_STATE_ROAMING|CREATURE_STATE_RETURN_TO_LAST_POS)))
			{
				target->pos_z = pos_z+CREATURE_ROAM_LIFT_FROM_GROUND;
				target->update_obj_pos(this);
				target->state1 &= ~CREATURE_STATE_MOVED_SINCE_SYNC;
			}
			G_send_packet.opcode = SMSG_ATTACKSWING_NOTINRANGE;
			G_send_packet.length = 0;
			pClient->SendMsg(&G_send_packet);
			rage_modify_on_hit(get_dmg(0));
			return;
		}
		//check if we can hit him = facing + range
		if(!is_in_front(pos_x,pos_y,orientation,target->pos_x,target->pos_y))
		{
			//in case server pos is not synced with client pos we force update the damn client
			if((target->state1 & CREATURE_STATE_MOVED_SINCE_SYNC) && !(target->state1 & (CREATURE_STATE_ROAMING|CREATURE_STATE_RETURN_TO_LAST_POS)))
			{
				target->pos_z = pos_z+CREATURE_ROAM_LIFT_FROM_GROUND;
				target->update_obj_pos(this);
				target->state1 &= ~CREATURE_STATE_MOVED_SINCE_SYNC;
			}
			G_send_packet.opcode = SMSG_ATTACKSWING_BADFACING;
			G_send_packet.length = 0;
			pClient->SendMsg(&G_send_packet);
			return;
		}
//		target->pos_z = pos_z+CREATURE_ROAM_LIFT_FROM_GROUND; //if we can reach him then he is close to us and we can set his pos_z aprox to ours (sinking creatures :S)
		uint32	hit_status = 0x00000102; //normal hit
		float	dmg_multiply = 1;
		//check if we could do a critical hit this time
		if((G_random.mt_random() % 10000)/100 <= dataf[PLAYER_CRIT_PERCENTAGE])
		{
	        hit_status = 0xEA;
			dmg_multiply = 2;
			emote(EMOTE_ONESHOT_WOUNDCRITICAL);
		}
		//aply each type of dmg to creature
		uint32 victim_state=1;
		for(int i=0;i<PLAYER_USED_DMG_TYPES;i++)
		{
			float dmg_start = get_dmg(i) * dmg_multiply;
			if(dmg_start)
			{
				float dmg_remain = target->take_dmg(dmg_start,getGUID(),i,0,data32[UNIT_FIELD_LEVEL]);
				total_dmg += dmg_remain;
				total_blocked +=dmg_start - dmg_remain;
			}
		}
		for(int i=0;i<on_attack_spell_dmg.len;i++)
			if(G_random.mt_random() % 100 <= on_attack_spell_dmg.list[i].chance)
			{
				float dmg_start = on_attack_spell_dmg.list[i].amount * dmg_multiply;
				if(dmg_start)
				{
					float dmg_remain = target->take_dmg(dmg_start,getGUID(),i,0,data32[UNIT_FIELD_LEVEL]);
					total_dmg += dmg_remain;
					total_blocked +=dmg_start - dmg_remain;
				}
				on_attack_spell_dmg.list[i].casts_remain--;
				if(on_attack_spell_dmg.list[i].casts_remain==0)
					affect_list->del(on_attack_spell_dmg.list[i].parent_spell_list_node);
			}
		//if we have data to be sent then assamble the packet and send it
//		if(total_dmg)
		{
			G_send_packet.opcode = SMSG_ATTACKERSTATEUPDATE;
			G_send_packet.data32[0] = hit_status;
			G_send_packet.data[4] = 0xFF;
			*(uint32*)(G_send_packet.data+5) = getGUIDL();
			*(uint32*)(G_send_packet.data+9) = getGUIDH();
			G_send_packet.data[13] = 0xFF;
			*(uint32*)(G_send_packet.data+14) = target->getGUIDL();
			*(uint32*)(G_send_packet.data+18) = target->getGUIDH();
			*(int*)(G_send_packet.data+22) = (int)total_dmg;
			G_send_packet.data[26] = 1;// Damage block counter. !client still shows it as only 1 dmg
			//dmg block. Because client show's it as only 1 we group it
			//it does not show any info about absorbed dmg or anything just a number will show the melle dmg abowe the target
			*(uint32*)(G_send_packet.data + 27) = 0; // 0 - white font, 1 - yellow
			*(float* )(G_send_packet.data + 31) = total_dmg; 
			*(uint32*)(G_send_packet.data + 35) = (uint32)total_dmg; // Damage amount
			*(uint32*)(G_send_packet.data + 39) = (uint32)total_blocked; // damage absorbed
			*(uint32*)(G_send_packet.data + 43) = 0; //new victim state ?
			*(uint32*)(G_send_packet.data + 47) = victim_state;   //round duration
			*(uint32*)(G_send_packet.data + 51) = 0;   // additional spell damage amount
			*(uint32*)(G_send_packet.data + 55) = 0;   // additional spell damage id
			*(uint32*)(G_send_packet.data + 59) = 0;   // Damage amount blocked
			G_send_packet.length = 63;
			G_maps[map_id]->send_instant_msg_to_block(pos_x,pos_y,&G_send_packet,NULL);
		}
		rage_modify_on_hit(total_dmg);
	}
	//apply on hit event spells
	on_hit_spells->trigger_event_spells_char(last_target_GUID);
	if(!total_dmg)
		return;
	if(state1 & UNIT_STATE_STEALTHED)
		affect_list->remove_stealth();
	//apply durability loss by picking 1 random item
	if(G_random.mt_random() % 100 < PLAYER_CHANCE_TO_LOOSE_DURABILITY)
	{
		uint32 fromslot;
		switch(G_random.mt_random() % 7)
		{
			case 0:
			case 1:{fromslot=EQUIPMENT_SLOT_OFFHAND*2;break;}
			case 2:
			case 3:{fromslot=EQUIPMENT_SLOT_RANGED*2;break;}
			default:{fromslot=EQUIPMENT_SLOT_MAINHAND*2;break;}//big chance that we try to hit with this
		}
		if(data32[PLAYER_FIELD_INV_SLOT_HEAD + fromslot]!=0 && ((Item*)(data32[PLAYER_FIELD_INV_SLOT_HEAD + fromslot]))->data32[ITEM_FIELD_DURABILITY]!=0)
		{
			((Item*)(data32[PLAYER_FIELD_INV_SLOT_HEAD + fromslot]))->loose_durability(total_dmg);
			if(((Item*)(data32[PLAYER_FIELD_INV_SLOT_HEAD + fromslot]))->data32[ITEM_FIELD_DURABILITY]==0)
				rem_item_stats(((Item*)(data32[PLAYER_FIELD_INV_SLOT_HEAD + fromslot])),1);//we remove stats now and they will not be removed again
			((Item*)(data32[PLAYER_FIELD_INV_SLOT_HEAD + fromslot]))->send_create_item(pClient);
		}
	}
}

float Character::get_dmg(uint8 type)
{
	return (dmg_min[type] + G_random.mt_random() % dmg_diff[type]);
}

//incase we take dmg this will calc the amount that is blocked and substract the remaining dmg from health
float Character::take_dmg(float pdmg,uint64 atacker_GUID,uint8 ptype,uint8 unblockable,uint32 atacker_level)
{
	//remamber the bastard tham made dmg to us
	if(atacker_GUID)
	{
//		if(atacker_GUID!=last_atacker_guid)
//			try_force_enter_combat(atacker_GUID);//maybe we do not wan't to enter combat with him after all
		last_atacker_guid = atacker_GUID;
		//apply on struck event spells
		if(!unblockable)
		{
			on_struck_spells->trigger_event_spells_char(atacker_GUID);
			rage_modify_on_struck(pdmg);
		}
	}
//	if(spell_school_imun[ptype])
//		return 0;//we are imune to this type of dmg
	if(affect_list->first)
		affect_list->on_game_interrupt(SPELL_AURA_INTERRUPT_FLAGS_TYPE_STRUCK);
	//apply durability loss by picking 1 random item
	if(G_random.mt_random() % 100 < PLAYER_CHANCE_TO_LOOSE_DURABILITY)
	{
		uint32 fromslot;
		switch(G_random.mt_random() % 16)
		{
			case 0:
			case 1:{fromslot=EQUIPMENT_SLOT_HEAD*2;break;}
			case 2:{fromslot=EQUIPMENT_SLOT_SHOULDERS*2;break;}
			case 3:
			case 4:
			case 5:{fromslot=EQUIPMENT_SLOT_BODY*2;break;}
			case 6:{fromslot=EQUIPMENT_SLOT_CHEST*2;break;}
			case 7:{fromslot=EQUIPMENT_SLOT_WAIST*2;break;}
			case 8:{fromslot=EQUIPMENT_SLOT_LEGS*2;break;}
			case 9:{fromslot=EQUIPMENT_SLOT_FEET*2;break;}
			case 10:{fromslot=EQUIPMENT_SLOT_WRISTS*2;break;}
			case 11:{fromslot=EQUIPMENT_SLOT_HANDS*2;break;}
			case 12:{fromslot=EQUIPMENT_SLOT_BACK*2;break;}
			case 13:
			case 14:
			case 15:
			default:{fromslot=EQUIPMENT_SLOT_MAINHAND*2;break;}//big chance that we try to block it
		}
		if(data32[PLAYER_FIELD_INV_SLOT_HEAD + fromslot]!=0 && ((Item*)(data32[PLAYER_FIELD_INV_SLOT_HEAD + fromslot]))->data32[ITEM_FIELD_DURABILITY]!=0)
		{
			((Item*)(data32[PLAYER_FIELD_INV_SLOT_HEAD + fromslot]))->loose_durability(pdmg);
			if(((Item*)(data32[PLAYER_FIELD_INV_SLOT_HEAD + fromslot]))->data32[ITEM_FIELD_DURABILITY]==0)
				rem_item_stats(((Item*)(data32[PLAYER_FIELD_INV_SLOT_HEAD + fromslot])),1);//we remove stats now and they will not be removed again
			((Item*)(data32[PLAYER_FIELD_INV_SLOT_HEAD + fromslot]))->send_create_item(pClient);
		}
	}
	if(unblockable)
	{
		health -=pdmg;
		return pdmg;
	}
	float dmg_remain=pdmg;
	//health shield do not take into count resistance
	if(health_shield->first)
		dmg_remain=health_shield->absorb_dmg(dmg_remain,ptype);
	if(data32[UNIT_FIELD_RESISTANCES+ptype])
	{
		float damage_reduction = 0;
		if(atacker_level)
		{
			signed int level_diff = 10 + data32[UNIT_FIELD_LEVEL] - atacker_level;
			if(level_diff <= 0) level_diff = 1;
			if(level_diff >= 20) level_diff = 19;
			//damage_reduction = data32[UNIT_FIELD_RESISTANCES+ptype] / ((85.0 * atacker_level) + data32[UNIT_FIELD_RESISTANCES+ptype] + 400.0)
			damage_reduction = (20/level_diff) * (data32[UNIT_FIELD_RESISTANCES+ptype]* 0.0002f) * dmg_remain;
//printf("dmg_remain reduction %f, level diff %d, resistence %d, dmg_remain %f \n",damage_reduction,level_diff,data32[UNIT_FIELD_RESISTANCES+ptype],dmg_remain);
		}
		else damage_reduction = (data32[UNIT_FIELD_RESISTANCES+ptype] * 0.0002f)*dmg_remain; //presume we are at equal level
		dmg_remain = dmg_remain - damage_reduction;
		if(dmg_remain<0 || dmg_remain>dmg_remain)dmg_remain = MINIMAL_DAMAGE_APPLYABLE;
	}
	if(dmg_remain)
	{
		if(state1 & (PLAYER_STATE_PREPARE_SPELL))
		{
			uint32 delaytime=(uint32)(dmg_remain/pdmg*0.25*cur_spell.prototype->cast_time);
			G_send_packet.opcode = SMSG_SPELL_DELAYED;
			G_send_packet.data64[0]=getGUID();
			G_send_packet.data32[2]=delaytime;
			G_send_packet.length = 12;
			SendMsg(&G_send_packet);
			atimer1 += delaytime;
		}
		health -= dmg_remain;
	}
	return dmg_remain; //all dmg remains becouse we do not block it at all
}

//uint8 Character::will_dodge_atack(){return ((G_random.mt_random() % 10000)/100 <= dataf[PLAYER_DODGE_PERCENTAGE]);}
//uint8 Character::will_block_atack(){return ((G_random.mt_random() % 10000)/100 <= dataf[PLAYER_BLOCK_PERCENTAGE]);}
//uint8 Character::will_parry_atack(){return ((G_random.mt_random() % 10000)/100 <= dataf[PLAYER_PARRY_PERCENTAGE]);}
uint8 Character::will_dodge_atack(){return ((G_random.mt_random() % 100) <= dataf[PLAYER_DODGE_PERCENTAGE]);}
uint8 Character::will_block_atack(){return ((G_random.mt_random() % 100) <= dataf[PLAYER_BLOCK_PERCENTAGE]);}
uint8 Character::will_parry_atack(){return ((G_random.mt_random() % 100) <= dataf[PLAYER_PARRY_PERCENTAGE]);}

//when char dies we take some actions : lie him down 
void Character::die()
{
	if(state1 & (PLAYER_STATE_DUEL_PREPARE | PLAYER_STATE_IN_DUEL | PLAYER_STATE_DUEL_UTOFBOUNDS))
	{
		health = 1;
		try_force_exit_combat();
		duel_info.target->try_force_exit_combat();
		emote(20);//beg
		duel_info.target->emote(23);//flex
		duel_info.target->finish_duel(1);
		finish_duel(3);
		return;
	}
	G_maps[map_id]->rem_agro_block(this);
#ifdef SERVER_DOTA_COMPILATION
	health = (float)data32[UNIT_FIELD_MAXHEALTH];
	if(player_powertype==Unit_Power_Type_Rage)
		power=0;
	else power = (float)data32[UNIT_FIELD_MAXPOWER1+player_powertype];
	pos_x = bind_x;
	pos_y = bind_y;
	pos_z = bind_z;
	orientation = bind_orientation;
	teleport(this,map_id,bind_x,bind_y,bind_z,bind_orientation);
	return;
#endif
	//stop casting or any other activities
	if((state1 & (PLAYER_STATE_PREPARE_SPELL | PLAYER_STATE_CAST_SPELL | PLAYER_STATE_COOLDOWN_SPELL)))
	cur_spell.cancel_cast();
	//remove all other auras
	affect_list->clear();
	//if we do not set player flag dead. Player is able to talk to NPCs
	Send_SMSG_FORCE_MOVE_ROOT();
	SetUInt32Value(UNIT_FIELD_FLAGS,U_FIELD_FLAG_PLAYER_CONTROLLED | U_FIELD_FLAG_DEAD);
    SetUInt32Value( UNIT_DYNAMIC_FLAGS, 0x00 );

	state1 |=PLAYER_STATE_DEAD;
	health = 0;
	power = 0;
	atimer2 = G_cur_time_ms + CHAR_FORCE_RESURECT_TIME;
}

//checks if player can cast this spell
//!!! 0 means no error
uint8 Character::can_cast(uint32 spell_id)
{
	Spell_Info *spell_info=G_spell_info[spell_id];
	uint8 ret=0;
	//if spell uses combo points
//	if(spell_info->power_type == Unit_Power_Type_Energy)
//	{
//	}
	if(data32[UNIT_FIELD_POWER1+spell_info->power_type] < spell_info->power_cost) return CAST_FAIL_NOT_ENOUGH_MANA;
	//check if spell requeres in back. Only Rogue spells require this so no need to check it for all the spells
	if(spell_info->power_type==Unit_Power_Type_Energy && cur_spell.require_caster_behind_target())
	{
		if(cur_spell.target_creature && !is_in_front(pos_x,pos_y,orientation,cur_spell.target_creature->pos_x,cur_spell.target_creature->pos_y))return CAST_FAIL_NOT_BEHIND_TARGET;
		else if(cur_spell.target_char && !is_in_front(pos_x,pos_y,orientation,cur_spell.target_char->pos_x,cur_spell.target_char->pos_y))return CAST_FAIL_NOT_BEHIND_TARGET;
		else if(cur_spell.target_object && !is_in_front(pos_x,pos_y,orientation,cur_spell.target_object->pos_x,cur_spell.target_object->pos_y))return CAST_FAIL_NOT_BEHIND_TARGET;
	}
//	if(health==0) return CAST_FAIL_YOU_ARE_DEAD;
	//check if it is in water
	if(state1 & UNIT_STATE_FLEE)
		return CAST_FAIL_YOU_ARE_FLEEING;
	if(silenced_count)
		return    CAST_FAIL_SILENCED;
	//check if stealthed and if there are enemys too close
//	for(int i=0;i<8;i++)
//		if(spell_info->reagent[i] && spell_info->reagent_count[i]>get_total_item_count(spell_info->reagent[i]))
//			return CAST_FAIL_REQUIRES_SOMETHING;
//	if((state1 & PLAYER_STATE_IN_WATER))
//	{
//	}
/*
CAST_FAIL_CANT_USE_WHILE_PACIFIED
   CAST_FAIL_ALREADY_FULL_HEALTH = 1,
   CAST_FAIL_ALREADY_FULL_MANA = 2,
   CAST_FAIL_CREATURE_ALREADY_TAMING = 3,
   CAST_FAIL_ALREADY_HAVE_CHARMED = 4,
   CAST_FAIL_ALREADY_HAVE_SUMMON = 5, 
   CAST_FAIL_ALREADY_OPEN = 6,
   CAST_FAIL_MORE_POWERFUL_SPELL_ACTIVE = 7,
   CAST_FAIL_NO_TARGET = 9,
   CAST_FAIL_INVALID_TARGET = 10,
   CAST_FAIL_CANT_BE_CHARMED = 11,
   CAST_FAIL_CANT_BE_DISENCHANTED = 12,
   CAST_FAIL_TARGET_IS_TAPPED = 13,
   CAST_FAIL_CANT_START_DUEL_INVISIBLE = 14,
   CAST_FAIL_CANT_START_DUEL_STEALTHED = 15,
   CAST_FAIL_TOO_CLOSE_TO_ENEMY = 16,
   CAST_FAIL_CANT_DO_THAT_YET = 17,
   CAST_FAIL_OBJECT_ALREADY_BEING_USED = 19,
   CAST_FAIL_CANT_DO_WHILE_CONFUSED = 20,
   CAST_FAIL_MUST_HAVE_ITEM_EQUIPPED = 22,
   CAST_FAIL_MUST_HAVE_XXXX_EQUIPPED = 23,
   CAST_FAIL_MUST_HAVE_XXXX_IN_MAINHAND = 24,
   CAST_FAIL_INTERNAL_ERROR = 25,
   CAST_FAIL_FIZZLED = 26,
   CAST_FAIL_YOU_ARE_FLEEING = 27,
   CAST_FAIL_FOOD_TOO_LOWLEVEL_FOR_PET = 28,
   CAST_FAIL_TARGET_IS_TOO_HIGH = 29,
   CAST_FAIL_IMMUNE = 32,         // was 31 in pre 1.7
   //CAST_FAIL_INTERRUPTED_COMBAT = 31,
   CAST_FAIL_ITEM_ALREADY_ENCHANTED = 34,
   CAST_FAIL_ITEM_IS_GONE = 35,
   CAST_FAIL_ENCHANT_NOT_EXISTING_ITEM = 36,
   CAST_FAIL_ITEM_NOT_READY = 37,
   CAST_FAIL_YOU_ARE_NOT_HIGH_ENOUGH = 38,
   CAST_FAIL_NOT_IN_LINE_OF_SIGHT = 39,
   CAST_FAIL_TARGET_TOO_LOW = 40,
   CAST_FAIL_SKILL_NOT_HIGH_ENOUGH = 41,
   CAST_FAIL_WEAPON_HAND_IS_EMPTY = 42,
   CAST_FAIL_CANT_DO_WHILE_MOVING = 43,
   CAST_FAIL_NEED_AMMO_IN_PAPERDOLL_SLOT = 44,
   CAST_FAIL_REQUIRES_SOMETHING = 45,
   CAST_FAIL_NEED_EXOTIC_AMMO = 46,
   CAST_FAIL_NO_PATH_AVAILABLE = 47,
   CAST_FAIL_NOT_BEHIND_TARGET = 48,
   CAST_FAIL_DIDNT_LAND_IN_FISHABLE_WATER = 49,
   CAST_FAIL_CANT_BE_CAST_HERE = 50,
   CAST_FAIL_NOT_IN_FRONT_OF_TARGET = 51,
   CAST_FAIL_NOT_IN_CONTROL_OF_ACTIONS = 52,
   CAST_FAIL_SPELL_NOT_LEARNED = 53,
   CAST_FAIL_CANT_USE_WHEN_MOUNTED = 54,
   CAST_FAIL_YOU_ARE_IN_FLIGHT = 55,
   CAST_FAIL_YOU_ARE_ON_TRANSPORT = 56,
   CAST_FAIL_SPELL_NOT_READY_YET = 57,
   CAST_FAIL_CANT_DO_IN_SHAPESHIFT = 58,
   CAST_FAIL_HAVE_TO_BE_STANDING = 59,
   CAST_FAIL_CAN_USE_ONLY_ON_OWN_OBJECT = 60,
   CAST_FAIL_CANT_ENCHANT_TRADE_ITEM = 61,
   CAST_FAIL_HAVE_TO_BE_UNSHEATHED = 62,
   CAST_FAIL_CANT_CAST_AS_GHOST = 63,
   CAST_FAIL_NO_AMMO = 64,
   CAST_FAIL_NO_CHARGES_REMAIN = 65,
   CAST_FAIL_COMBO_POINTS_REQUIRED = 66,
   CAST_FAIL_NO_DUELING_HERE = 67,
   CAST_FAIL_NOT_ENOUGH_ENDURANCE = 68,
   CAST_FAIL_THERE_ARENT_ANY_FISH_HERE = 69,
   CAST_FAIL_CANT_USE_WHILE_SHAPESHIFTED = 70,
   CAST_FAIL_CANT_MOUNT_HERE = 71,
   CAST_FAIL_YOU_DO_NOT_HAVE_PET = 72,
   CAST_FAIL_CANT_USE_WHILE_SWIMMING = 74,
   CAST_FAIL_CAN_ONLY_USE_AT_DAY = 75,
   CAST_FAIL_CAN_ONLY_USE_INDOORS = 76,
   CAST_FAIL_CAN_ONLY_USE_MOUNTED = 77,
   CAST_FAIL_CAN_ONLY_USE_AT_NIGHT = 78,
   CAST_FAIL_CAN_ONLY_USE_OUTDOORS = 79,
   CAST_FAIL_CAN_ONLY_USE_STEALTHED  = 81,
   CAST_FAIL_CAN_ONLY_USE_WHILE_SWIMMING = 82,
   CAST_FAIL_OUT_OF_RANGE = 83,
   CAST_FAIL_YOU_ARE_POSSESSED = 85,
   CAST_FAIL_YOU_NEED_TO_BE_IN_XXX = 87,
   CAST_FAIL_REQUIRES_XXX = 88,
   CAST_FAIL_UNABLE_TO_MOVE = 89,
   CAST_FAIL_ANOTHER_ACTION_IS_IN_PROGRESS = 91,
   CAST_FAIL_ALREADY_LEARNED_THAT_SPELL = 92,
   CAST_FAIL_SPELL_NOT_AVAILABLE_TO_YOU = 93,
   CAST_FAIL_CANT_DO_WHILE_STUNNED = 94,
   CAST_FAIL_YOUR_TARGET_IS_DEAD = 95,
   CAST_FAIL_TARGET_IS_IN_COMBAT = 96,
   CAST_FAIL_CANT_DO_THAT_YET_2 = 97,
   CAST_FAIL_TARGET_IS_DUELING = 98,
   CAST_FAIL_TARGET_IS_HOSTILE = 99,
   CAST_FAIL_TARGET_IS_TOO_ENRAGED_TO_CHARM = 100,
   CAST_FAIL_TARGET_IS_FRIENDLY = 101,
   CAST_FAIL_TARGET_CANT_BE_IN_COMBAT = 102,
   CAST_FAIL_CANT_TARGET_PLAYERS = 103,
   CAST_FAIL_TARGET_IS_ALIVE = 104,
   CAST_FAIL_TARGET_NOT_IN_YOUR_PARTY = 104,
   CAST_FAIL_CREATURE_MUST_BE_LOOTED_FIRST = 106,
   CAST_FAIL_TARGET_IS_NOT_A_PLAYER = 107,
   CAST_FAIL_NO_POCKETS_TO_PICK = 108,
   CAST_FAIL_TARGET_HAS_NO_WEAPONS_EQUIPPED = 109,
   CAST_FAIL_NOT_SKINNABLE = 110,
   CAST_FAIL_TOO_CLOSE = 112,
   CAST_FAIL_TOO_MANY_OF_THAT_ITEM_ALREADY = 113,
   CAST_FAIL_NOT_ENOUGH_TRAINING_POINTS = 115,   
   CAST_FAIL_FAILED_ATTEMPT = 116,
   CAST_FAIL_TARGET_NEED_TO_BE_BEHIND = 117,
   CAST_FAIL_TARGET_NEED_TO_BE_INFRONT = 118,
   CAST_FAIL_PET_DOESNT_LIKE_THAT_FOOD = 119,
   CAST_FAIL_CANT_CAST_WHILE_FATIGUED = 120,
   CAST_FAIL_TARGET_MUST_BE_IN_THIS_INSTANCE = 121,
   CAST_FAIL_CANT_CAST_WHILE_TRADING = 122,
   CAST_FAIL_TARGET_IS_NOT_PARTY_OR_RAID = 123,
   CAST_FAIL_CANT_DISENCHANT_WHILE_LOOTING = 124,
   CAST_FAIL_TARGET_IS_IN_FFA_PVP_COMBAT = 125,
   CAST_FAIL_NO_NEARBY_CORPSES_TO_EAT = 126,
   CAST_FAIL_CAN_ONLY_USE_IN_BATTLEGROUNDS = 127,
   CAST_FAIL_TARGET_IS_NOT_A_GHOST = 128,
   CAST_FAIL_YOUR_PET_CANT_LEARN_MORE_SKILLS = 129,
   CAST_FAIL_UNKNOWN_REASON = 130,
   CAST_FAIL_NUMREASONS*/
    //check spell conditions
    //if (m_spellInfo->CheckFlags & FLAG_CHECK_HIGH_LEVEL) 
    //   if (m_caster->GetUInt32Value (UNIT_FIELD_LEVEL) + 4 < target->GetUInt32Value (UNIT_FIELD_LEVEL))
    //      castResult = CAST_FAIL_TARGET_IS_TOO_HIGH;
    //if (m_spellInfo->CheckFlags & FLAG_CHECK_TARGET_TYPE) 
    //	if (1 << target->GetUInt32Value (UNIT_FIELD_))
	//check player state if he can cast
	//check target to be in front if not selfcast
//         castResult = CAST_FAIL_TARGET_NEED_TO_BE_INFRONT;
	//check target to be in range
//         castResult = CAST_FAIL_OUT_OF_RANGE;
//   if (m_caster->m_silenced) castResult = CAST_FAIL_SILENCED;
//   if (m_caster->isStunned()) castResult = CAST_FAIL_CANT_DO_WHILE_STUNNED;
	//check if the teacher is valid
//      m_spellInfo->Effect[0] == EFFECT_LEARN_SPELL && (m_spellInfo->EffectImplicitTargetA[0] == 0 && m_spellInfo->EffectImplicitTargetA[1] == 0 && m_spellInfo->EffectImplicitTargetA[2] == 0 && m_spellInfo->EffectImplicitTargetB[0] == 0 && m_spellInfo->EffectImplicitTargetB[1] == 0 && m_spellInfo->EffectImplicitTargetB[2] == 0 )
	return ret;
}

//takes actions when a spell is casted
void Character::start_cast()
{
	state1 |= PLAYER_STATE_PREPARE_SPELL;
	atimer1 = G_cur_time_ms + cur_spell.cast_duration;
//printf("starting cast, duration until cast %d\n",cur_spell.cast_duration);
}

void Character::xp_modify(uint64 victim_guid,uint32 amount,uint8 personal)
{
	//if personal then we do not have it with group(group will callback thisfunction). 
	if((personal || group==NULL) && data[4*UNIT_FIELD_LEVEL]<CHAR_MAX_LEVEL)
	{
		uint32 my_amount=amount;
		//this is not shown to client, could be becouse it is combat xp ?
		G_send_packet.opcode = SMSG_LOG_XPGAIN;
		G_send_packet.data64[0] = victim_guid;
		G_send_packet.data32[2] = my_amount; //normal xp
		G_send_packet.data[12] = 0;
		*(uint32*)&G_send_packet.data[13] = my_amount; //"Rest XP", is equal to XP for no rest xp message
		*(uint32*)&G_send_packet.data[17] = 0x3f80000;
		G_send_packet.length = 21;
		pClient->SendMsg(&G_send_packet);
		SetUInt32Value(PLAYER_XP,data32[PLAYER_XP]+my_amount);
		//if we advanced a level
		while(data32[PLAYER_XP] >= data32[PLAYER_NEXT_LEVEL_XP])
		{
			if(data[UNIT_FIELD_LEVEL*4]==CHAR_MAX_LEVEL)
			{
				SetUInt32Value(PLAYER_XP,data32[PLAYER_NEXT_LEVEL_XP]);
				SetUInt32Value(PLAYER_NEXT_LEVEL_XP,data32[PLAYER_XP]);
			    on_change_lvl();
				return;
			}
			SetUInt32Value(PLAYER_XP,data32[PLAYER_XP] - data32[PLAYER_NEXT_LEVEL_XP]);
			SetUInt32Value(PLAYER_NEXT_LEVEL_XP,data32[PLAYER_NEXT_LEVEL_XP] + data32[PLAYER_NEXT_LEVEL_XP]/4);
			SetUInt32Value(UNIT_FIELD_LEVEL,data32[UNIT_FIELD_LEVEL]+1);
			uint32  prev_health=data32[UNIT_FIELD_MAXHEALTH];
			uint32  prev_power=data32[UNIT_FIELD_POWER1+player_powertype];
			uint32	prev_stat[5];
			prev_stat[0] = data32[UNIT_FIELD_STAT0];
			prev_stat[1] = data32[UNIT_FIELD_STAT1];
			prev_stat[2] = data32[UNIT_FIELD_STAT2];
			prev_stat[3] = data32[UNIT_FIELD_STAT3];
			prev_stat[4] = data32[UNIT_FIELD_STAT4];
			//little hack to recalc dmg bonus 2
			recalc_base_stats();
			recalc_dinamic_stats();
			//inform client that we advanced a level
			G_send_packet.opcode = SMSG_LEVELUP_INFO;
			G_send_packet.data32[0] = data32[UNIT_FIELD_LEVEL];
			G_send_packet.data32[1] = data32[UNIT_FIELD_MAXHEALTH] - prev_health; 
			G_send_packet.data32[2] = data32[UNIT_FIELD_POWER1+player_powertype] - prev_power;
			G_send_packet.data32[3] = 0;
			G_send_packet.data32[4] = 0;
			G_send_packet.data32[5] = 0;
			G_send_packet.data32[6] = 0;
			G_send_packet.data32[7] = data32[UNIT_FIELD_STAT0] - prev_stat[0];
			G_send_packet.data32[8] = data32[UNIT_FIELD_STAT1] - prev_stat[1];
			G_send_packet.data32[9] = data32[UNIT_FIELD_STAT2] - prev_stat[2];
			G_send_packet.data32[10] = data32[UNIT_FIELD_STAT3] - prev_stat[3];
			G_send_packet.data32[11] = data32[UNIT_FIELD_STAT4] - prev_stat[4];
			G_send_packet.length = 48;
			pClient->SendMsg(&G_send_packet);
			//if it's time we give him some talent points
			if(data32[UNIT_FIELD_LEVEL]>=9)
				SetUInt32Value(PLAYER_CHARACTER_POINTS1, data32[PLAYER_CHARACTER_POINTS1]+1);
			health = (float)data32[UNIT_FIELD_MAXHEALTH]; //set to max health
			if(player_powertype!=Unit_Power_Type_Rage)
				power = (float)data32[UNIT_FIELD_MAXPOWER1+player_powertype]; //set max mana
	 	    on_change_lvl();
		}
	}
	else if(group)
	{
		uint32 my_amount=0;
		//calc a fair share of xp based on the number of chars in our group
		my_amount = (uint32)(amount*1.5 /group->member_count);
		Group_Node *kur=group->first;
		while(kur)
		{
			kur->p_char->xp_modify(victim_guid,my_amount,1);
			kur = kur->next;
		}
	}
}
//willreturn count that has been removed
uint32 Character::rem_item_id(uint32	item_id,uint32 count)
{
	uint32 ret=0;
	uint32 i;
	for ( i = PLAYER_FIELD_INV_SLOT_HEAD+INVENTORY_SLOT_ITEM_START*2; i < PLAYER_FIELD_INV_SLOT_HEAD + BANK_SLOT_BAG_END*2; i +=2)
	{
		Item *cur_item=(Item*)data32[i];
		//is this the item we are searching for ?
		if(cur_item && cur_item->data32[OBJECT_FIELD_ENTRY]==item_id)
		{
			uint32 stack=cur_item->data32[ITEM_FIELD_STACK_COUNT];
			if(stack<=count)
			{
				ret += stack;
				rem_item((i - PLAYER_FIELD_INV_SLOT_HEAD)/2,0xFF,0);
			}
			else
			{
				ret = count;
				cur_item->data32[ITEM_FIELD_STACK_COUNT] = cur_item->data32[ITEM_FIELD_STACK_COUNT] - count;
				cur_item->send_create_item(pClient);
			}
			if(count==ret)
				return ret;
		}
	}
	for ( i = PLAYER_FIELD_INV_SLOT_HEAD+INVENTORY_SLOT_BAG_START*2; i < PLAYER_FIELD_INV_SLOT_HEAD + INVENTORY_SLOT_BAG_END*2; i +=2)
	{
		Item *cur_bag=((Item*)data32[i]);
		uint32 bag_slot_iter;
		for (bag_slot_iter=CONTAINER_FIELD_SLOT_1;bag_slot_iter<CONTAINER_END;bag_slot_iter+=2)
		{
			Item *cur_item=(Item*)cur_bag->data32[bag_slot_iter];
			//is this the item we are searching for ?
			if(cur_item && cur_item->data32[OBJECT_FIELD_ENTRY]==item_id)
			{
				uint32 stack=cur_item->data32[ITEM_FIELD_STACK_COUNT];
				if(stack<=count)
				{
					ret += stack;
					rem_item((bag_slot_iter-CONTAINER_FIELD_SLOT_1)/2,(i - PLAYER_FIELD_INV_SLOT_HEAD)/2,0);
				}
				else
				{
					ret = count;
					cur_item->data32[ITEM_FIELD_STACK_COUNT] = cur_item->data32[ITEM_FIELD_STACK_COUNT] - count;
					cur_item->send_create_item(pClient);
				}
				if(count==ret)
					return ret;
			}
		}
	}
	return ret;
}

//will return slot + bag >> 16;
uint32 Character::rem_item(Item *src_item)
{
	uint32 ret;
	uint32 i;
	for ( i = PLAYER_FIELD_INV_SLOT_HEAD+0; i < PLAYER_FIELD_INV_SLOT_HEAD + BANK_SLOT_BAG_END*2; i +=2)
	{
		if(data32[i]!=0) 
		{
			//is this the item we are searching for ?
			if(data32[i]==(uint32)src_item)
			{
				uint32	 bag_id = 0xFF;
				uint32	 slot = (i - PLAYER_FIELD_INV_SLOT_HEAD)/2;
				ret = (bag_id >> 16) + slot;
//printf("removing item from slot %u\n",slot);
				rem_item(slot,0xFF,0);
				return ret;
			}
			//search in bags
			if((INVENTORY_SLOT_BAG_START*2+PLAYER_FIELD_INV_SLOT_HEAD)<=i && i<(INVENTORY_SLOT_BAG_END*2+PLAYER_FIELD_INV_SLOT_HEAD))
			{
				Item *cur_bag=((Item*)data32[i]);
				uint32 bag_slot_iter;
				for (bag_slot_iter=CONTAINER_FIELD_SLOT_1;bag_slot_iter<CONTAINER_END;bag_slot_iter+=2)
					if(cur_bag->data32[bag_slot_iter]==(uint32)src_item)
					{
						uint32	 bag_slot = (i - PLAYER_FIELD_INV_SLOT_HEAD)/2;
						uint32	 slot = (bag_slot_iter-CONTAINER_FIELD_SLOT_1)/2;
						ret = (bag_slot >> 16) + slot;
//printf("removing item from bag %u and slot %u\n",bag_slot,slot);
						rem_item(slot,bag_slot,0);
						return ret;
					}
			}
		}
	}
	return 0;
}

Item* Character::get_item(uint32 slot,uint8 bag_index)
{
	Item *p_item;
	if(IS_BAG_SLOT(bag_index))
	{
		Item *cur_bag=(Item*)data32[PLAYER_FIELD_INV_SLOT_HEAD+bag_index*2];
		if(!cur_bag) return NULL;
		p_item = (Item*)cur_bag->data32[CONTAINER_FIELD_SLOT_1+slot*2];
		return p_item; //it was not a charm and we removed it 
	}
	p_item = (Item*)data32[PLAYER_FIELD_INV_SLOT_HEAD+slot*2];
	return p_item;
}

Item* Character::rem_item(uint32 slot,uint8 bag_index,uint8 is_switch)
{
	Item *p_item;
//printf("removing item from char , slot %d, agslot %d \n",slot,bag_index);
	if(IS_BAG_SLOT(bag_index))
	{
		Item *cur_bag=(Item*)data32[PLAYER_FIELD_INV_SLOT_HEAD+bag_index*2];
		if(!cur_bag) return NULL;
		p_item = cur_bag->rem_from_container(slot);
		if(p_item && (p_item->item_data32[ITEM_EXTRA_FLAGS] & ITEM_IS_CHARM) && !is_switch)
			rem_item_stats(p_item);
		return p_item; //it was not a charm and we removed it 
	}
	p_item = (Item*)data32[PLAYER_FIELD_INV_SLOT_HEAD+slot*2];
	SetUInt64Value(PLAYER_FIELD_INV_SLOT_HEAD+slot*2,NULL);
    if(p_item==NULL)
	   return NULL; //seems like a careless call of the function
	//it is an item from char (not bag)
   if(IS_BODY_SLOT(slot))
   {
     int pos = PLAYER_VISIBLE_ITEM_1_0 + (slot * PLAYER_VISIBLE_ITEM_SIZE + slot * 4);
	 SetUInt32Value (pos + 0, 0);
     SetUInt32Value (pos + 1, 0);
     SetUInt32Value (pos + 2, 0);
     SetUInt32Value (pos + 3, 0);
     SetUInt32Value (pos + 4, 0);
     SetUInt32Value (pos + 5, 0);
     SetUInt32Value (pos + 6, 0);
     SetUInt32Value (pos + 7, 0);
     SetUInt32Value (pos + 8, 0);
	 rem_item_stats(p_item);
   }
   else if((p_item->item_data32[ITEM_EXTRA_FLAGS] & ITEM_IS_CHARM) && !is_switch)
	   rem_item_stats(p_item);
   return p_item;
}

void Character::rem_item_stats(Item *p_item,uint8 forced_remove)
{
	if(p_item->data32[ITEM_FIELD_DURABILITY]==0 && forced_remove==0)
		return;
	int i;
	//base stat modifyers
	for(i=0;i<10*2;i+=2)
	{
		signed int mod_stat_value = p_item->item_datai[ITEM_STAT_VALUE_0+i];
		switch(p_item->item_data32[ITEM_STAT_TYPE_0+i])
		{
			case ITEM_MOD_STAT_TYPE_MAXHEALTH:
			{
				SetUInt32Value (UNIT_FIELD_MAXHEALTH, data32[UNIT_FIELD_MAXHEALTH] - mod_stat_value);
			}break;
			case ITEM_MOD_STAT_TYPE_STAT1:
			{
				SetUInt32Value (UNIT_FIELD_STAT1, data32[UNIT_FIELD_STAT1] - mod_stat_value);
				if(mod_stat_value>0)
					SetUInt32Value (UNIT_FIELD_POSSTAT1, data32[UNIT_FIELD_POSSTAT1] - mod_stat_value);
				else SetUInt32Value (UNIT_FIELD_NEGSTAT1, data32[UNIT_FIELD_NEGSTAT1] + mod_stat_value);
			}break;
			case ITEM_MOD_STAT_TYPE_STAT0:
			{
				SetUInt32Value (UNIT_FIELD_STAT0, data32[UNIT_FIELD_STAT0] - mod_stat_value);
				if(mod_stat_value>0)
					SetUInt32Value (UNIT_FIELD_POSSTAT0, data32[UNIT_FIELD_POSSTAT0] - mod_stat_value);
				else SetUInt32Value (UNIT_FIELD_NEGSTAT0, data32[UNIT_FIELD_NEGSTAT0] + mod_stat_value);
			}break;
			case ITEM_MOD_STAT_TYPE_STAT3:
			{
				SetUInt32Value (UNIT_FIELD_STAT3, data32[UNIT_FIELD_STAT3] - mod_stat_value);
				if(mod_stat_value>0)
					SetUInt32Value (UNIT_FIELD_POSSTAT3, data32[UNIT_FIELD_POSSTAT3] - mod_stat_value);
				else SetUInt32Value (UNIT_FIELD_NEGSTAT3, data32[UNIT_FIELD_NEGSTAT3] + mod_stat_value);
			}break;
			case ITEM_MOD_STAT_TYPE_STAT4:
			{
				SetUInt32Value (UNIT_FIELD_STAT4, data32[UNIT_FIELD_STAT4] - mod_stat_value);
				if(mod_stat_value>0)
					SetUInt32Value (UNIT_FIELD_POSSTAT4, data32[UNIT_FIELD_POSSTAT4] - mod_stat_value);
				else SetUInt32Value (UNIT_FIELD_NEGSTAT4, data32[UNIT_FIELD_NEGSTAT4] + mod_stat_value);
			}break;
			case ITEM_MOD_STAT_TYPE_STAT2:
			{
				SetUInt32Value (UNIT_FIELD_STAT2, data32[UNIT_FIELD_STAT2] - mod_stat_value);
				if(mod_stat_value>0)
					SetUInt32Value (UNIT_FIELD_POSSTAT2, data32[UNIT_FIELD_POSSTAT2] - mod_stat_value);
				else SetUInt32Value (UNIT_FIELD_NEGSTAT2, data32[UNIT_FIELD_NEGSTAT2] + mod_stat_value);
			}break;
			case ITEM_MOD_STAT_TYPE_DEFENSE_RATE:
			case ITEM_MOD_STAT_TYPE_UNK:
			case ITEM_MOD_STAT_TYPE_SPELL_HIT_RATE:
			case ITEM_MOD_STAT_TYPE_SPELL_CRIT_RATE:
			case ITEM_MOD_STAT_TYPE_HIT_RATE:
			case ITEM_MOD_STAT_TYPE_CRITICAL_RATE:
			case ITEM_MOD_STAT_TYPE_RESILIANCE_RATE:
				{
					//yet to be done
				}break;
		}
	}
	for(i=0;i<5*3;i+=3)
	{
		uint32 mod_dmg_index = p_item->item_data32[ITEM_DMG_TYPE_0+i];
		if(mod_dmg_index > PLAYER_MAX_DMG_TYPES || p_item->item_dataf[ITEM_DMG_MAX_0+i]==0)
			continue;
		item_min_dmg[mod_dmg_index] -= p_item->item_dataf[ITEM_DMG_MIN_0+i];
		item_max_dmg[mod_dmg_index] -= p_item->item_dataf[ITEM_DMG_MAX_0+i];
	}
	for(i=0;i<PLAYER_MAX_DMG_TYPES;i++)
	{
		SetUInt32Value(UNIT_FIELD_RESISTANCES+i,data32[UNIT_FIELD_RESISTANCES+i] - p_item->item_data32[ITEM_ARMOR+i]);
//		if(p_item->item_datai[ITEM_ARMOR+i]<0)
//			SetUInt32Value(UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+i,data32[UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+i] + p_item->item_datai[ITEM_ARMOR+i]);
//		else SetUInt32Value(UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+i,data32[UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+i] - p_item->item_datai[ITEM_ARMOR+i]);
	}
	//register spells to events
	for(i=0;i<5*6;i+=6)
	{
		if(p_item->item_data32[ITEM_SPELL_TRIGGER+i]==SPELLTRIGGER_TYPE_CHANCE_ON_HIT)
			on_hit_spells->del(p_item->item_data32[ITEM_SPELL_ID+i]);
		else if(p_item->item_data32[ITEM_SPELL_TRIGGER+i]==SPELLTRIGGER_TYPE_CHANCE_ON_STRUCK)
			on_struck_spells->del(p_item->item_data32[ITEM_SPELL_ID+i]);
	}
	//remove enchantments
	for(i=0;i<30;i+=3)
		if(p_item->data32[ITEM_FIELD_ENCHANTMENT+i]!=0 && p_item->data32[ITEM_FIELD_ENCHANTMENT+i]<G_max_enchant_id && G_item_enchantments[p_item->data32[ITEM_FIELD_ENCHANTMENT+i]]!=0)
		{
			item_enchantment_def *edef=G_item_enchantments[p_item->data32[ITEM_FIELD_ENCHANTMENT+i]];
			for(int j=0;j<3;j++)
				if(edef->spell_id[j]!=0)
					affect_list->remove_enchantment(p_item->getGUID(),edef->spell_id[j]);
		}
	SetFloatValue(PLAYER_BLOCK_PERCENTAGE,dataf[PLAYER_BLOCK_PERCENTAGE] - p_item->item_data32[ITEM_BLOCK]);
	if(p_item->item_data32[ITEM_DELAY]!=0)
	  	SetUInt32Value(UNIT_FIELD_BASEATTACKTIME,2000);
	recalc_dinamic_stats();
}

uint8 Character::auto_store_item_in_bag(Item *pitem,uint8 bag_nr,uint8 just_stack)
{
	if(just_stack)
	{
		//we store item only if we can stack it in a bag
		if(IS_BAG_SLOT(bag_nr) && data32[PLAYER_FIELD_INV_SLOT_HEAD+bag_nr*2]!=NULL)
		{
			//store item in an empty slot
			Item *cur_bag = (Item*)data32[PLAYER_FIELD_INV_SLOT_HEAD+bag_nr*2];
			uint32 j;
			for(j=0;j<cur_bag->item_data32[ITEM_SLOTS];j++)
			{
				Item *cur_item=(Item*)cur_bag->data32[CONTAINER_FIELD_SLOT_1+j*2];
				if(cur_item && 
					cur_item->item_data32[ITEM_ID]==pitem->item_data32[ITEM_ID] &&
					cur_item->item_data32[ITEM_STACK_MAX] - cur_item->data32[ITEM_FIELD_STACK_COUNT]>=pitem->data32[ITEM_FIELD_STACK_COUNT]
					)
				{
					cur_item->data32[ITEM_FIELD_STACK_COUNT] += pitem->data32[ITEM_FIELD_STACK_COUNT];
					cur_item->send_create_item(pClient);
					G_Object_Pool.Release_item(pitem);
					return 2;
				}
			}
		}
		else //try to stack item in backpack
		{
			uint32 i;
			for(i=PLAYER_FIELD_INV_SLOT_HEAD + INVENTORY_SLOT_ITEM_1*2;i<PLAYER_FIELD_INV_SLOT_HEAD + INVENTORY_SLOT_ITEM_END*2;i+=2)
				if(data32[i]!=0 &&
					((Item*)data32[i])->item_data32[ITEM_ID]==pitem->item_data32[ITEM_ID] &&
					((Item*)data32[i])->item_data32[ITEM_STACK_MAX] - ((Item*)data32[i])->data32[ITEM_FIELD_STACK_COUNT]>=pitem->data32[ITEM_FIELD_STACK_COUNT]
					)
				{
					((Item*)data32[i])->data32[ITEM_FIELD_STACK_COUNT] += pitem->data32[ITEM_FIELD_STACK_COUNT];
					((Item*)data32[i])->send_create_item(pClient);
					G_Object_Pool.Release_item(pitem);
					return 2;
				}
		}
		return 0;
	}
	else
	{
		//store item in an empty slot in bag
		if(IS_BAG_SLOT(bag_nr) && data32[PLAYER_FIELD_INV_SLOT_HEAD+bag_nr*2]!=NULL)
		{
			Item *cur_bag = (Item*)data32[PLAYER_FIELD_INV_SLOT_HEAD+bag_nr*2];
			uint32 j;
			for(j=0;j<cur_bag->item_data32[ITEM_SLOTS];j++)
				if(cur_bag->data32[CONTAINER_FIELD_SLOT_1+j*2]==0)
				{
					//if item is template then we duplicate it
					if(pitem->state1 & ITEM_STATE_IS_TEMPLATE)
					{
						Item *theitem;
						theitem = G_Object_Pool.Get_fast_New_item();
						theitem->create_from_template(pitem);
						add_item(theitem,j,bag_nr,0);
					}
					else add_item(pitem,j,bag_nr,0);
					return 1;
				}
		}
		else //store item in inventory in an empty slot in backpack
		{
			uint32 i;
			for(i=PLAYER_FIELD_INV_SLOT_HEAD + INVENTORY_SLOT_ITEM_1*2;i<PLAYER_FIELD_INV_SLOT_HEAD + INVENTORY_SLOT_ITEM_END*2;i+=2)
				if(data32[i]==0)
				{
					//if item is template then we duplicate it
					if(pitem->state1 & ITEM_STATE_IS_TEMPLATE)
					{
						Item *theitem;
						theitem = G_Object_Pool.Get_fast_New_item();
						theitem->create_from_template(pitem);
						add_item(theitem,(i - (PLAYER_FIELD_INV_SLOT_HEAD + INVENTORY_SLOT_ITEM_1*2))/2 + INVENTORY_SLOT_ITEM_1,bag_nr,0);
					}
					else add_item(pitem,(i - (PLAYER_FIELD_INV_SLOT_HEAD + INVENTORY_SLOT_ITEM_1*2))/2 + INVENTORY_SLOT_ITEM_1,bag_nr,0);
					return 1;
				}
		}
		return 0;
	}
	return 0; //just so compiler won't give a warning
}

//!note that in case we will stack the item, this function will delete the new instance of the object 
uint8 Character::auto_store_item(Item *pitem)
{
	uint32	i,res;
	//try to store item as stackable
	if(pitem->item_data32[ITEM_STACK_MAX]>1)
	{
		for(i=INVENTORY_SLOT_BAG_1-1;i<INVENTORY_SLOT_BAG_END;i++)
			if(res=auto_store_item_in_bag(pitem,i,1))
				return res;
	}
	//search for first empty slot in all bags
	for(i=INVENTORY_SLOT_BAG_1-1;i<INVENTORY_SLOT_BAG_END;i++)
		if(res=auto_store_item_in_bag(pitem,i,0))
			return res;
	return 0;
}

void Character::add_item(Item *p_item,uint32 slot,uint8 bag_index,uint8 is_switch)
{
	//printf("added item %u to slot %u display_id = %u, guid = %u\n",(uint32)p_item,slot,p_item->item_data32[ITEM_DISPLAY_INFO_ID]);
	if(!p_item)
		return;
//printf("adding item to char slot %d bagslot %d\n",slot,bag_index);
	//add it to player
	if(IS_BAG_SLOT(bag_index))
	{
		Item *cur_bag=(Item*)data32[PLAYER_FIELD_INV_SLOT_HEAD+bag_index*2];
		if(!cur_bag)
			return;
		cur_bag->add_to_container(p_item,slot);
		if((p_item->item_data32[ITEM_EXTRA_FLAGS] & ITEM_IS_CHARM) && !is_switch)
			add_item_stats(p_item);
		return;//no more actions required
	}
	p_item->on_change_owner(getGUID(),this);
	SetUInt64Value(PLAYER_FIELD_INV_SLOT_HEAD+slot*2,p_item->getGUID());
	//equipable items cannot be charms
	if(IS_BODY_SLOT (slot))
	{
//printf("added item to visible part with id %u \n",p_item->item_data32[ITEM_ID]);
		int pos = PLAYER_VISIBLE_ITEM_1_0 + (slot * PLAYER_VISIBLE_ITEM_SIZE + slot * 4);
		SetUInt32Value (pos + 0, p_item->item_data32[ITEM_ID]);
		SetUInt32Value (pos + 1, p_item->data32[ITEM_FIELD_ENCHANTMENT]);
		SetUInt32Value (pos + 2, p_item->data32[ITEM_FIELD_ENCHANTMENT + 3]);
		SetUInt32Value (pos + 3, p_item->data32[ITEM_FIELD_ENCHANTMENT + 6]);
		SetUInt32Value (pos + 4, p_item->data32[ITEM_FIELD_ENCHANTMENT + 9]);
		SetUInt32Value (pos + 5, p_item->data32[ITEM_FIELD_ENCHANTMENT + 12]);
		SetUInt32Value (pos + 6, p_item->data32[ITEM_FIELD_ENCHANTMENT + 15]);
		SetUInt32Value (pos + 7, p_item->data32[ITEM_FIELD_ENCHANTMENT + 18]);
		SetUInt32Value (pos + 8, p_item->data32[ITEM_FIELD_RANDOM_PROPERTIES_ID]);
		add_item_stats(p_item);
	}//end if body slot
	else if((p_item->item_data32[ITEM_EXTRA_FLAGS] & ITEM_IS_CHARM) && !is_switch)
		add_item_stats(p_item);
}

void Character::add_item_stats(Item *p_item)
{
	if(p_item->data32[ITEM_FIELD_DURABILITY]==0 && p_item->data32[ITEM_FIELD_MAXDURABILITY]!=0)
		return;
	int i;
	//base stat modifyers
	for(i=0;i<10*2;i+=2)
	{
		signed int mod_stat_value = p_item->item_datai[ITEM_STAT_VALUE_0+i];
		switch(p_item->item_data32[ITEM_STAT_TYPE_0+i])
		{
			case ITEM_MOD_STAT_TYPE_MAXHEALTH:
			{
				SetUInt32Value (UNIT_FIELD_MAXHEALTH, data32[UNIT_FIELD_MAXHEALTH] + mod_stat_value);
			}break;
			case ITEM_MOD_STAT_TYPE_STAT1:
			{
				SetUInt32Value (UNIT_FIELD_STAT1, data32[UNIT_FIELD_STAT1] + mod_stat_value);
				if(mod_stat_value>0)
					SetUInt32Value (UNIT_FIELD_POSSTAT1, data32[UNIT_FIELD_POSSTAT1] + mod_stat_value);
				else SetUInt32Value (UNIT_FIELD_NEGSTAT1, data32[UNIT_FIELD_NEGSTAT1] - mod_stat_value);
			}break;
			case ITEM_MOD_STAT_TYPE_STAT0:
			{
				SetUInt32Value (UNIT_FIELD_STAT0, data32[UNIT_FIELD_STAT0] + mod_stat_value);
				if(mod_stat_value>0)
					SetUInt32Value (UNIT_FIELD_POSSTAT0, data32[UNIT_FIELD_POSSTAT0] + mod_stat_value);
				else SetUInt32Value (UNIT_FIELD_NEGSTAT0, data32[UNIT_FIELD_NEGSTAT0] - mod_stat_value);
			}break;
			case ITEM_MOD_STAT_TYPE_STAT3:
			{
				SetUInt32Value (UNIT_FIELD_STAT3, data32[UNIT_FIELD_STAT3] + mod_stat_value);
				if(mod_stat_value>0)
					SetUInt32Value (UNIT_FIELD_POSSTAT3, data32[UNIT_FIELD_POSSTAT3] + mod_stat_value);
				else SetUInt32Value (UNIT_FIELD_NEGSTAT3, data32[UNIT_FIELD_NEGSTAT3] - mod_stat_value);
			}break;
			case ITEM_MOD_STAT_TYPE_STAT4:
			{
				SetUInt32Value (UNIT_FIELD_STAT4, data32[UNIT_FIELD_STAT4] + mod_stat_value);
				if(mod_stat_value>0)
					SetUInt32Value (UNIT_FIELD_POSSTAT4, data32[UNIT_FIELD_POSSTAT4] + mod_stat_value);
				else SetUInt32Value (UNIT_FIELD_NEGSTAT4, data32[UNIT_FIELD_NEGSTAT4] - mod_stat_value);
			}break;
			case ITEM_MOD_STAT_TYPE_STAT2:
			{
				SetUInt32Value (UNIT_FIELD_STAT2, data32[UNIT_FIELD_STAT2] + mod_stat_value);
				if(mod_stat_value>0)
					SetUInt32Value (UNIT_FIELD_POSSTAT2, data32[UNIT_FIELD_POSSTAT2] + mod_stat_value);
				else SetUInt32Value (UNIT_FIELD_NEGSTAT2, data32[UNIT_FIELD_NEGSTAT2] - mod_stat_value);
			}break;
			case ITEM_MOD_STAT_TYPE_DEFENSE_RATE:
			case ITEM_MOD_STAT_TYPE_UNK:
			case ITEM_MOD_STAT_TYPE_SPELL_HIT_RATE:
			case ITEM_MOD_STAT_TYPE_SPELL_CRIT_RATE:
			case ITEM_MOD_STAT_TYPE_HIT_RATE:
			case ITEM_MOD_STAT_TYPE_CRITICAL_RATE:
			case ITEM_MOD_STAT_TYPE_RESILIANCE_RATE:
				{
					//yet to be done
				}break;

		}
	}
	for(i=0;i<5*3;i+=3)
	{
		uint32 mod_dmg_index = p_item->item_data32[ITEM_DMG_TYPE_0+i];
		if(mod_dmg_index > PLAYER_MAX_DMG_TYPES || p_item->item_dataf[ITEM_DMG_MAX_0+i]==0)
			continue;
//printf("item has dmg\n");
		item_min_dmg[mod_dmg_index] += p_item->item_dataf[ITEM_DMG_MIN_0+i];
		item_max_dmg[mod_dmg_index] += p_item->item_dataf[ITEM_DMG_MAX_0+i];
	}
	for(i=0;i<PLAYER_MAX_DMG_TYPES;i++)
	{
		SetUInt32Value(UNIT_FIELD_RESISTANCES+i,data32[UNIT_FIELD_RESISTANCES+i] + p_item->item_data32[ITEM_ARMOR+i]);
//		if(p_item->item_datai[ITEM_ARMOR+i]<0)
//			SetUInt32Value(UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+i,data32[UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+i] - p_item->item_datai[ITEM_ARMOR+i]);
//		else SetUInt32Value(UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+i,data32[UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+i] + p_item->item_datai[ITEM_ARMOR+i]);
	}
	//register spells to events
	for(i=0;i<5*6;i+=6)
	{
		if(p_item->item_data32[ITEM_SPELL_TRIGGER+i]==SPELLTRIGGER_TYPE_CHANCE_ON_HIT)
			on_hit_spells->add(p_item->item_data32[ITEM_SPELL_ID+i],p_item->item_data32[ITEM_SPELL_CAST_CHANCE_0+i/6]);
		else if(p_item->item_data32[ITEM_SPELL_TRIGGER+i]==SPELLTRIGGER_TYPE_CHANCE_ON_STRUCK)
			on_struck_spells->add(p_item->item_data32[ITEM_SPELL_ID+i],p_item->item_data32[ITEM_SPELL_CAST_CHANCE_0+i/6]);
	}
	SetFloatValue(PLAYER_BLOCK_PERCENTAGE,dataf[PLAYER_BLOCK_PERCENTAGE] + p_item->item_data32[ITEM_BLOCK]);
	if(p_item->item_data32[ITEM_DELAY]!=0)
		SetUInt32Value(UNIT_FIELD_BASEATTACKTIME,p_item->item_data32[ITEM_DELAY]);
	//cast enchantments
//remove me
//if(p_item->data32[ITEM_FIELD_RANDOM_PROPERTIES_ID]!=0)
//printf("item name %s, random property id %d, enchants:",(char*)&p_item->item_data32[ITEM_NAME],p_item->data32[ITEM_FIELD_RANDOM_PROPERTIES_ID]);
	for(i=0;i<30;i+=3)
		if(p_item->data32[ITEM_FIELD_ENCHANTMENT+i]!=0 && p_item->data32[ITEM_FIELD_ENCHANTMENT+i]<G_max_enchant_id && G_item_enchantments[p_item->data32[ITEM_FIELD_ENCHANTMENT+i]]!=0)
		{
			item_enchantment_def *edef=G_item_enchantments[p_item->data32[ITEM_FIELD_ENCHANTMENT+i]];
			G_instant_spell_instance.item_caster_guid=p_item->getGUID();
			G_instant_spell_instance.cast_flags = CAST_ACTION_FLAG_ITEM_ENCHANTMENT | CAST_ACTION_FLAG_STACK_WITH_ANY_OTHER;
			for(int j=0;j<3;j++)
				if(edef->spell_id[j]!=0)
				{
					G_instant_spell_instance.item_instant_cast_quiet(p_item,this,edef->spell_id[j],getGUID());
//remove me
//printf(" %d->%d ",edef->id,edef->spell_id[j]);
				}
			G_instant_spell_instance.item_caster_guid=0;
			G_instant_spell_instance.cast_flags = 0;
		}
//remove me
//if(p_item->data32[ITEM_FIELD_RANDOM_PROPERTIES_ID]!=0)
//printf("\n");
	recalc_dinamic_stats();
}

void Character::sheath_set(uint32 sheath_value)
{
	Item *p_item;
    if (sheath_value==1)
    {
      if (data32[PLAYER_FIELD_INV_SLOT_HEAD+EQUIPMENT_SLOT_MAINHAND*2])
	  {
          p_item = (Item*)data32[PLAYER_FIELD_INV_SLOT_HEAD+EQUIPMENT_SLOT_MAINHAND*2];
		  SetUInt32Value (UNIT_VIRTUAL_ITEM_SLOT_DISPLAY + 0, p_item->item_data32[ITEM_DISPLAY_INFO_ID]);
		  SetUInt64Value (UNIT_VIRTUAL_ITEM_INFO + 0, p_item->getGUID());
      }
      if (data32[PLAYER_FIELD_INV_SLOT_HEAD+EQUIPMENT_SLOT_OFFHAND*2])
	  {
          p_item = (Item*)data32[PLAYER_FIELD_INV_SLOT_HEAD+EQUIPMENT_SLOT_OFFHAND*2];
		  SetUInt32Value (UNIT_VIRTUAL_ITEM_SLOT_DISPLAY + 1, p_item->item_data32[ITEM_DISPLAY_INFO_ID]);
		  SetUInt64Value (UNIT_VIRTUAL_ITEM_INFO + 2, p_item->getGUID());
      }
	  SetUInt32Value (UNIT_VIRTUAL_ITEM_SLOT_DISPLAY + 2,0);
	  SetUInt64Value (UNIT_VIRTUAL_ITEM_INFO + 4,0);
	}
	else if(sheath_value==2)
	{
	  SetUInt32Value (UNIT_VIRTUAL_ITEM_SLOT_DISPLAY + 0, 0);
	  SetUInt64Value (UNIT_VIRTUAL_ITEM_INFO + 0, 0);
	  SetUInt32Value (UNIT_VIRTUAL_ITEM_SLOT_DISPLAY + 1, 0);
	  SetUInt64Value (UNIT_VIRTUAL_ITEM_INFO + 2, 0);
      if (data32[PLAYER_FIELD_INV_SLOT_HEAD+EQUIPMENT_SLOT_RANGED*2])
	  {
          p_item = (Item*)data32[PLAYER_FIELD_INV_SLOT_HEAD+EQUIPMENT_SLOT_RANGED*2];
		  SetUInt32Value (UNIT_VIRTUAL_ITEM_SLOT_DISPLAY + 2, p_item->item_data32[ITEM_DISPLAY_INFO_ID]);
		  SetUInt64Value (UNIT_VIRTUAL_ITEM_INFO + 4, p_item->getGUID());
      }
    }
    else 
    {
		  SetUInt32Value (UNIT_VIRTUAL_ITEM_SLOT_DISPLAY + 0,0);
		  SetUInt64Value (UNIT_VIRTUAL_ITEM_INFO + 0,0);
		  SetUInt32Value (UNIT_VIRTUAL_ITEM_SLOT_DISPLAY + 1,0);
		  SetUInt64Value (UNIT_VIRTUAL_ITEM_INFO + 2,0);
		  SetUInt32Value (UNIT_VIRTUAL_ITEM_SLOT_DISPLAY + 2,0);
		  SetUInt64Value (UNIT_VIRTUAL_ITEM_INFO + 4,0);
	}
}

/*
uint8 Character::is_empty_bag(uint8 bag_nr)
{
	for(int i=0;i<MAX_BAG_SLOTS;i++)
		if(bags[bag_nr][i]!=0)
			return 0;
	return 1;
}*/

//corpse state comes after player dies and cannot ressurect anymore = release spirit
void Character::on_char_corpse(uint8 quiet_transform)
{
	//save position
	corpse_x = pos_x;
	corpse_y = pos_y;
	corpse_z = pos_z;
	corpse_o = orientation;
	//transform ourself into a ghost
	cur_spell.char_instant_nomana_cast(8326,-1);

/*	SetUInt32Value(CONTAINER_FIELD_SLOT_1+29, 8326);
    SetUInt32Value(UNIT_FIELD_AURA+32, 8326);
    SetUInt32Value(UNIT_FIELD_AURALEVELS+8, 0xeeeeee00);
    SetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS+8, 0xeeeeee00);
    SetUInt32Value(UNIT_FIELD_AURAFLAGS+4, 12);
    SetUInt32Value(UNIT_FIELD_AURASTATE, 2);*/

	if(Get_race() == PLAYER_RACE_TYPE_NIGHT_ELF)
		SetUInt32Value(UNIT_FIELD_DISPLAYID, 10045);
	//set flag as dead will disable alot of things. Mostly NPC talking too 
	health = 1;
	power = 1;
	SetUInt32Value(UNIT_FIELD_HEALTH,1);
	SetUInt32Value(PLAYER_FLAGS, PLAYER_FLAG_DEAD); 
	state1 |= PLAYER_STATE_CORPSE | PLAYER_STATE_DEAD;

	//set our position to the nearest graveyard position
	float newx,newy,newz=pos_z,newo=orientation,cur_dist_sq;
	Grave_Yard_Node *gr_iter=G_maps[map_id]->graveyard_list.first;
	cur_dist_sq = 0;
	if(!gr_iter)
	{
		newx = pos_x;
		newy = pos_y;
		newz = pos_z;
		newo = orientation;
	}
	else while (gr_iter)
	{
		float dist_sq = (corpse_x-gr_iter->x)*(corpse_x-gr_iter->x)+(corpse_y-gr_iter->y)*(corpse_y-gr_iter->y);
		if(dist_sq<cur_dist_sq || cur_dist_sq == 0)
		{
			cur_dist_sq = dist_sq;
			newx = gr_iter->x;
			newy = gr_iter->y;
			newz = gr_iter->z;
			newo = gr_iter->o;
		}
		gr_iter = gr_iter->next;
	}
	if(quiet_transform)
	{
		pos_x = newx;
		pos_y = newy;
		pos_z = newz;
		orientation = newo;
		return;
	}
	Send_SMSG_FORCE_MOVE_UNROOT();
	Send_SMSG_MOVE_WATER_WALK();
	//init timers
	G_send_packet.opcode = SMSG_CORPSE_RECLAIM_DELAY;
	G_send_packet.data32[0] = 0x8CA0;
	G_send_packet.length = 4;
	pClient->SendMsg(&G_send_packet);
	G_send_packet.opcode = SMSG_STOP_MIRROR_TIMER;
	G_send_packet.data32[0] = 0;
	pClient->SendMsg(&G_send_packet);
	G_send_packet.data32[0] = 1;
	pClient->SendMsg(&G_send_packet);
	G_send_packet.data32[0] = 2;
	pClient->SendMsg(&G_send_packet);

	//destroy us so others won't see us anymore
	G_send_packet.opcode = SMSG_DESTROY_OBJECT;
	G_send_packet.data64[0] = getGUID();
	G_send_packet.length = 8;
	G_maps[map_id]->send_instant_msg_to_block(pos_x,pos_y,&G_send_packet,this); //do not destroy self

	//spawn a corpse. Corpse does all inits and deinits for the char to see his corpse
	pcorpse = new corpse(this);

	//spawn spirit healers only once (will destroy them when player get resurrected)
	pClient->SendMsg(G_maps[map_id]->Spirit_healer_prepared_packet.build_packet());
	//teleport player to new location
	pos_x = newx;
	pos_y = newy;
	pos_z = newz;
	orientation = newo;
	//update client so we will be placed at nearest spirit healer.
	//Note that this is made only for our client. Others will not see us
	update_obj_pos(this);
}

void Character::msg_corpse_location()
{
	//update char corpse position. Sometimes client asks to early corpse position and we answer none
	G_send_packet.opcode = MSG_CORPSE_QUERY;
	G_send_packet.data[0] = 0x01;
	*(uint32*)&G_send_packet.data[1] = map_id;
	*(float*)&G_send_packet.data[5] = corpse_x;
	*(float*)&G_send_packet.data[9] = corpse_y;
	*(float*)&G_send_packet.data[13] = corpse_z;
	*(float*)&G_send_packet.data[17] = 0; 
	G_send_packet.length = 21;
	pClient->SendMsg(&G_send_packet);
}

//when resurecting the char we have to remove corpse, set states ....
void Character::on_char_resurect(uint8 at_corpse)
{
	//move on land only again
	Send_SMSG_MOVE_LAND_WALK();
	Send_SMSG_FORCE_MOVE_UNROOT();
	//remove ghost aura
	affect_list->clear();
	//be sure to not have ghost aura on us
	//set state to alive
	SetUInt32Value(UNIT_FIELD_FLAGS,UNIT_FLAG_NON_PVP_PLAYER);
	flag_clr(PLAYER_FLAGS, PLAYER_FLAG_DEAD);
	state1 &=~(PLAYER_STATE_DEAD | PLAYER_STATE_CORPSE | PLAYER_STATE_IN_COMBAT);
	//if we were morphed then morph back
	if(Get_race() == PLAYER_RACE_TYPE_NIGHT_ELF)
		SetUInt32Value(UNIT_FIELD_DISPLAYID, data32[UNIT_FIELD_NATIVEDISPLAYID]);
	//set health
	health = (float)data32[UNIT_FIELD_MAXHEALTH] / 2;
	if(player_powertype==Unit_Power_Type_Rage)
		power = 0;
	else power = (float)data32[UNIT_FIELD_MAXPOWER1+player_powertype] / 2;
	//hide all spirit healers
	G_send_packet.opcode = SMSG_DESTROY_OBJECT;
	G_send_packet.length = 8;
	Creature_Node *spr_itr;
	spr_itr = G_maps[map_id]->graveyard_list.spirit_healers.first;
	while(spr_itr)
	{
		G_send_packet.data64[0] = spr_itr->value->getGUID();
		pClient->SendMsg(&G_send_packet);
		spr_itr = spr_itr->next;
	}
	//hide corpse by destroying it
	if(pcorpse)
	{
		delete pcorpse;
		pcorpse = NULL;
	}
	//make sure in mapmanager we are at the right place
	float x=pos_x,y=pos_y;
	pos_x=corpse_x;pos_y=corpse_y;
	G_maps[map_id]->del_char(this);
	pos_x=x,pos_y=y;
	G_maps[map_id]->del_char(this);
	G_maps[map_id]->add_char(this);
/*	if(at_corpse)
	{
		//in this case we can see others but they can't see us. We create us for others
		G_temp_compressed_packet.clear();
		build_create_block(&G_temp_compressed_packet,0,G_turn_id);
		G_maps[map_id]->send_instant_msg_to_block(pos_x,pos_y,G_temp_compressed_packet.build_packet(),this);
	}
	else
	{*/
		//in this case we resurected in a place where we cannot see anybody and other do not see us eighter
		//delete ourself from mapmanager (corpse location).
//		float x=pos_x,y=pos_y;
		pos_x=corpse_x;pos_y=corpse_y;
		//destroy other creatures for us
		G_maps[map_id]->on_player_exited_block(this);
//		G_maps[map_id]->del_char(this);
		//update our position for mapmanager
		pos_x=x,pos_y=y;
//		G_maps[map_id]->add_char(this);
		//show other creatures for us and show us for others
		G_maps[map_id]->on_player_entered_block(this);
//	}
	corpse_x = 0;
	corpse_y = 0;
	corpse_z = 0;
	corpse_o = 0;
}

void Character::force_durability_change(float coef)
{
	uint32 i;
	//destroy items for char
/*	for ( i = PLAYER_FIELD_INV_SLOT_HEAD+0; i < PLAYER_FIELD_INV_SLOT_HEAD + BANK_SLOT_BAG_END*2; i +=2)
	{
		if(data32[i]!=0) 
		{
			if((INVENTORY_SLOT_BAG_START*2+PLAYER_FIELD_INV_SLOT_HEAD)<=i && i<(INVENTORY_SLOT_BAG_END*2+PLAYER_FIELD_INV_SLOT_HEAD))
			{
				Item *cur_bag=((Item*)data32[i]);
				uint32 bag_slot_iter;
				for (bag_slot_iter=CONTAINER_FIELD_SLOT_1;bag_slot_iter<CONTAINER_END;bag_slot_iter+=2)
					if(cur_bag->data32[bag_slot_iter]!=0)
					{
						((Item*)cur_bag->data32[bag_slot_iter])->data32[ITEM_FIELD_DURABILITY] = (uint32)(((Item*)cur_bag->data32[bag_slot_iter])->data32[ITEM_FIELD_DURABILITY]*coef);
					}
			}
			((Item*)data32[i])->data32[ITEM_FIELD_DURABILITY] = (uint32)(((Item*)data32[i])->data32[ITEM_FIELD_DURABILITY]*coef);
		}
	}/**/
	for ( i = PLAYER_FIELD_INV_SLOT_HEAD+0; i < PLAYER_FIELD_INV_SLOT_HEAD + EQUIPMENT_SLOT_END*2; i +=2)
	{
		if(data32[i]!=0) 
		{
			((Item*)data32[i])->data32[ITEM_FIELD_DURABILITY] = (uint32)(((Item*)data32[i])->data32[ITEM_FIELD_DURABILITY]*coef);
			((Item*)data32[i])->send_create_item(pClient);
		}
	}
}


//should remove secondary efects for spells and items
void Character::remove_mods()
{
	int i;
	// Reset aura icons and flags
	if(Get_class() == PLAYER_CLASS_WARRIOR) data32[UNIT_FIELD_BYTES_1, 0x0011EE00 ];
    else  data32[UNIT_FIELD_BYTES_1, 0x0000EE00];
	for(i = 0; i < 8; i++) 
		data32[UNIT_FIELD_AURAFLAGS + i] = 0;
	for(i = 0; i < MAX_AURAS; i++) 
		data32[UNIT_FIELD_AURA + i] = 0;
	//first remove negative mods so no owerflow should occure
	for(i=0;i<PLAYER_MAX_STAT_TYPES;i++)
	{
		data32[UNIT_FIELD_STAT0+i] += data32[UNIT_FIELD_NEGSTAT0+i];
		data32[UNIT_FIELD_NEGSTAT0+i]=0;
		data32[UNIT_FIELD_STAT0+i] -= data32[UNIT_FIELD_POSSTAT0+i];
		data32[UNIT_FIELD_POSSTAT0+i]=0;
	}
	for(i=0;i<PLAYER_MAX_DMG_TYPES;i++)
	{
//printf("before removing resistance %u, value was %u for pos %u and neg %u\n",i,data32[UNIT_FIELD_RESISTANCES+i],data32[UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+i],data32[UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+i]);
		data32[UNIT_FIELD_RESISTANCES+i] += data32[UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+i];
		data32[UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+i]=0;
		data32[UNIT_FIELD_RESISTANCES+i] -= data32[UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+i];
		data32[UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+i]=0;
	}
	//min/max dmg will be recalculated
	for(i=0;i<PLAYER_MAX_DMG_TYPES;i++)
	{
		data32[PLAYER_FIELD_MOD_DAMAGE_DONE_NEG+i]=0;
		data32[PLAYER_FIELD_MOD_DAMAGE_DONE_POS+i]=0;
		dataf[PLAYER_FIELD_MOD_DAMAGE_DONE_PCT+i]=1.0f;
	}
	data32[UNIT_FIELD_ATTACK_POWER_MODS] = 0;
	data32[UNIT_FIELD_RANGED_ATTACK_POWER_MODS] = 0;
	data32[UNIT_FIELD_POWER_COST_MODIFIER] = 0;
	data32[UNIT_FIELD_POWER_COST_MULTIPLIER] = 0;
	data32[UNIT_FIELD_BASEATTACKTIME]=2000;
	data32[UNIT_FIELD_RESISTANCES]=0;
	dataf[UNIT_FIELD_MINDAMAGE]=0;
	dataf[UNIT_FIELD_MAXDAMAGE]=0;
	for(int i=0;i<PLAYER_USED_DMG_TYPES;i++)
	{
		item_min_dmg[i]=0;
		item_max_dmg[i]=0;
		dmg_min[i]=0;
		dmg_diff[i]=1;
	}
	speed_land_modifyer = 1;
	speed_water_modifyer = 1;
	speed_attack_modifyer = 1;
	recalc_dinamic_stats(); //necesary to reset min/max dmg
}

void Character::recalc_base_stats()
{
	//set base stats
	switch (Get_class())
	{
		case PLAYER_RACE_TYPE_HUMAN:
			{
				data32[UNIT_FIELD_STAT0] = 23;
				data32[UNIT_FIELD_STAT1] = 20;
				data32[UNIT_FIELD_STAT2] = 22;
				data32[UNIT_FIELD_STAT3] = 20;
				data32[UNIT_FIELD_STAT4] = 21;
			}break;
		case PLAYER_RACE_TYPE_ORC:
			{
				data32[UNIT_FIELD_STAT0] = 26;
				data32[UNIT_FIELD_STAT1] = 17;
				data32[UNIT_FIELD_STAT2] = 24;
				data32[UNIT_FIELD_STAT3] = 17;
				data32[UNIT_FIELD_STAT4] = 23;
			}break;
		case PLAYER_RACE_TYPE_DWARF:
			{
				data32[UNIT_FIELD_STAT0] = 25;
				data32[UNIT_FIELD_STAT1] = 16;
				data32[UNIT_FIELD_STAT2] = 25;
				data32[UNIT_FIELD_STAT3] = 19;
				data32[UNIT_FIELD_STAT4] = 29;
			}break;
		case PLAYER_RACE_TYPE_NIGHT_ELF:
			{
				data32[UNIT_FIELD_STAT0] = 17;
				data32[UNIT_FIELD_STAT1] = 25;
				data32[UNIT_FIELD_STAT2] = 19;
				data32[UNIT_FIELD_STAT3] = 20;
				data32[UNIT_FIELD_STAT4] = 20;
			}break;
		case PLAYER_RACE_TYPE_UNDEAD:
			{
				data32[UNIT_FIELD_STAT0] = 22;
				data32[UNIT_FIELD_STAT1] = 18;
				data32[UNIT_FIELD_STAT2] = 23;
				data32[UNIT_FIELD_STAT3] = 18;
				data32[UNIT_FIELD_STAT4] = 25;
			}break;
		case PLAYER_RACE_TYPE_TAUREN:
			{
				data32[UNIT_FIELD_STAT0] = 28;
				data32[UNIT_FIELD_STAT1] = 15;
				data32[UNIT_FIELD_STAT2] = 24;
				data32[UNIT_FIELD_STAT3] = 15;
				data32[UNIT_FIELD_STAT4] = 22;
			}break;
		case PLAYER_RACE_TYPE_GNOME:
			{
				data32[UNIT_FIELD_STAT0] = 18;
				data32[UNIT_FIELD_STAT1] = 23;
				data32[UNIT_FIELD_STAT2] = 21;
				data32[UNIT_FIELD_STAT3] = 24;
				data32[UNIT_FIELD_STAT4] = 20;
			}break;
		case PLAYER_RACE_TYPE_TROLL:
			{
				data32[UNIT_FIELD_STAT0] = 24;
				data32[UNIT_FIELD_STAT1] = 22;
				data32[UNIT_FIELD_STAT2] = 23;
				data32[UNIT_FIELD_STAT3] = 16;
				data32[UNIT_FIELD_STAT4] = 21;
			}break;
	}
	signed int lvl=data32[UNIT_FIELD_LEVEL];
	if(lvl>1)
	switch(Get_class())
    {
      case PLAYER_CLASS_WARRIOR : 
		  {	
			 data32[UNIT_FIELD_STAT0] += 3 + min(lvl,23) + max((lvl-23),0)*2;
			 data32[UNIT_FIELD_STAT2] += 2 + min(lvl,23) + max((lvl-23),0)*2;
			 data32[UNIT_FIELD_STAT1] += min(max(lvl-6,0),36)/2 + max((lvl-36),0);
			 data32[UNIT_FIELD_STAT3] +=  max((lvl-9),0)/2;
			 data32[UNIT_FIELD_STAT4] += max((lvl-9),0)/2;
  			 data32[UNIT_FIELD_MAXPOWER1 + Unit_Power_Type_Rage] = 1000;
		  }break; 
      case PLAYER_CLASS_PALADIN :
		  {        
			 data32[UNIT_FIELD_STAT0] += 2 + max(lvl-3,0);
			 data32[UNIT_FIELD_STAT2] += min(lvl,33) + max(lvl-33,0)*2;
			 data32[UNIT_FIELD_STAT1] += min(max((lvl-7),0),38)/2 + max(lvl-38,0);
			 data32[UNIT_FIELD_STAT3] += max((lvl-6),0)/2;
			 data32[UNIT_FIELD_STAT4] += 1 + max((lvl-7),0);
		  }break; 
      case PLAYER_CLASS_HUNTER  : 
		  {      
			 data32[UNIT_FIELD_STAT0] += max(lvl-4,0);
			 data32[UNIT_FIELD_STAT2] += 1 + max(lvl-4,0);
			 data32[UNIT_FIELD_STAT1] += 3 + min(lvl,33) + max(lvl-33,0)*2;
			 data32[UNIT_FIELD_STAT3] += max((lvl-8),0)/2;
			 data32[UNIT_FIELD_STAT4] += min(max((lvl-9),0),38)/2 + max(lvl-38,0);
		  }break;
      case PLAYER_CLASS_ROGUE   :
		  {     
			 data32[UNIT_FIELD_STAT0] += 1 + max(lvl-5,0);
			 data32[UNIT_FIELD_STAT2] += 1 + max(lvl-4,0);
			 data32[UNIT_FIELD_STAT1] += 3 + min(lvl,16) + max(lvl-16,0)*2;
			 data32[UNIT_FIELD_STAT3] += max((lvl-8),0)/2;
			 data32[UNIT_FIELD_STAT4] += min(max((lvl-9),0),38)/2 + max(lvl-38,0);
			 data32[UNIT_FIELD_MAXPOWER1 + Unit_Power_Type_Energy] = 100;
		  }break;
      case PLAYER_CLASS_PRIEST  : 
		  {        
			 data32[UNIT_FIELD_STAT0] += max(lvl-9,0)/2;
			 data32[UNIT_FIELD_STAT2] += max(lvl-5,0);
			 data32[UNIT_FIELD_STAT1] += min(max(lvl-8,0),38)/2 + max(lvl-38,0);
			 data32[UNIT_FIELD_STAT3] += 2 + min(lvl,22) + max((lvl-22),0)*2;
			 data32[UNIT_FIELD_STAT4] += 3 + max(lvl-3,0);
		  }break;
      case PLAYER_CLASS_SHAMAN  :
		  {      
			 data32[UNIT_FIELD_STAT0] += 1 + min(max(lvl-6,0),34)/2 + max(lvl-34,0);
			 data32[UNIT_FIELD_STAT2] += 1 + max(lvl-4,0);
			 data32[UNIT_FIELD_STAT1] += max(lvl-7,0)/2;
			 data32[UNIT_FIELD_STAT3] += 1 + max((lvl-5),0);
			 data32[UNIT_FIELD_STAT4] += 2 + max(lvl-4,0);
		  }break;
      case PLAYER_CLASS_MAGE    :
		  {     
			 data32[UNIT_FIELD_STAT0] += max(lvl-9,0)/2;
			 data32[UNIT_FIELD_STAT2] += max(lvl-5,0);
			 data32[UNIT_FIELD_STAT1] += max(lvl-9,0)/2;
			 data32[UNIT_FIELD_STAT3] += 3 + min(lvl,24) + max((lvl-24),0)*2;
			 data32[UNIT_FIELD_STAT4] += 2 + min(max(lvl-2,0),33) + max(lvl-33,0)*2;
		  }break;
      case PLAYER_CLASS_WARLOCK :
		  {      
			 data32[UNIT_FIELD_STAT0] += max(lvl-9,0)/2;
			 data32[UNIT_FIELD_STAT2] += min(38,max(lvl-3,0)) + max(lvl-38,0)*2;
			 data32[UNIT_FIELD_STAT1] += max(lvl-9,0)/2;
			 data32[UNIT_FIELD_STAT3] += 2 + min(33,max(lvl-2,0)) + max((lvl-33),0)*2;
			 data32[UNIT_FIELD_STAT4] += 2 + min(max(lvl-3,0),38) + max(lvl-38,0)*2;
		  }break;
      case PLAYER_CLASS_DRUID   :
		  {     
			 data32[UNIT_FIELD_STAT0] += 1 + min(38,max(lvl-6,0))/2 + max(lvl-38,0)*2;
			 data32[UNIT_FIELD_STAT2] += min(32,max(lvl-4,0)) + max(lvl-32,0)*2;
			 data32[UNIT_FIELD_STAT1] += min(38,max(lvl-8,0))/2 + max(lvl-38,0)*2;
			 data32[UNIT_FIELD_STAT3] += 2 + min(38,max(lvl-4,0)) + max((lvl-38),0)*3;
			 data32[UNIT_FIELD_STAT4] += 2 + min(max(lvl-4,0),38) + max(lvl-38,0)*3;
		  }break;
    }
	dataf[OBJECT_FIELD_SCALE_X] = 1.0f + data32[UNIT_FIELD_LEVEL]*0.008f;
}

//calc this before loading items
void Character::recalc_dinamic_stats()
{
	//calc base armor
	uint8 player_class=Get_class();
	SetUInt32Value(UNIT_FIELD_RESISTANCES , 2*(data32[UNIT_FIELD_STAT1])+data32[UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE]-data32[UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE]);
	SetUInt32Value(UNIT_FIELD_MAXHEALTH , (data32[UNIT_FIELD_STAT2])*10);
	SetFloatValue(PLAYER_CRIT_PERCENTAGE , 5 + (data32[UNIT_FIELD_STAT1])/20.0f);
	SetFloatValue(PLAYER_PARRY_PERCENTAGE , 5.0f);
	SetFloatValue(PLAYER_DODGE_PERCENTAGE, (data32[UNIT_FIELD_STAT1])/20.0f);
	if(player_class != PLAYER_CLASS_WARRIOR && player_class != PLAYER_CLASS_ROGUE)
		SetUInt32Value(UNIT_FIELD_MAXPOWER1+player_powertype , (data32[UNIT_FIELD_STAT3])*15);
	if(player_class == PLAYER_CLASS_HUNTER)   
		SetUInt32Value(UNIT_FIELD_RANGED_ATTACK_POWER , data32[UNIT_FIELD_LEVEL] * 2 + (data32[UNIT_FIELD_STAT1]) * 2 - 20);
	else   SetUInt32Value(UNIT_FIELD_RANGED_ATTACK_POWER , data32[UNIT_FIELD_LEVEL] + (data32[UNIT_FIELD_STAT1]) * 2 - 20);
	switch(player_class)
	{
	case PLAYER_CLASS_WARRIOR:
		{
			power_regen = -20.0f;
			health_regen = (data32[UNIT_FIELD_STAT4])*0.8f;
			SetUInt32Value(UNIT_FIELD_ATTACK_POWER , data32[UNIT_FIELD_LEVEL]*3 + (data32[UNIT_FIELD_STAT0])*2 - 20 + data32[UNIT_FIELD_ATTACK_POWER_MODS]); 
		}break;
	case PLAYER_CLASS_PALADIN:
		{
			power_regen = (data32[UNIT_FIELD_STAT4])/5.0f + 15.0f;
			health_regen = (data32[UNIT_FIELD_STAT4])*0.25f;
			SetUInt32Value(UNIT_FIELD_ATTACK_POWER , data32[UNIT_FIELD_LEVEL]*3 + (data32[UNIT_FIELD_STAT0])*2 - 20 + data32[UNIT_FIELD_ATTACK_POWER_MODS]);
		}break;
	case PLAYER_CLASS_ROGUE:
		{
			power_regen = 20.0f;
			health_regen = (data32[UNIT_FIELD_STAT4])*0.5f + 2.0f;
			SetUInt32Value(UNIT_FIELD_ATTACK_POWER , data32[UNIT_FIELD_LEVEL]*2 + (data32[UNIT_FIELD_STAT0]) + (data32[UNIT_FIELD_STAT1]) - 20 + data32[UNIT_FIELD_ATTACK_POWER_MODS]);
			SetFloatValue(PLAYER_CRIT_PERCENTAGE , 5 + (data32[UNIT_FIELD_STAT1])/29.0f);
			SetFloatValue(PLAYER_DODGE_PERCENTAGE, (data32[UNIT_FIELD_STAT1])/26.5f);
		}break;
	case PLAYER_CLASS_HUNTER:
		{
			power_regen = (data32[UNIT_FIELD_STAT4])/5.0f + 15.0f;
			health_regen = (data32[UNIT_FIELD_STAT4])*0.25f;
			SetUInt32Value(UNIT_FIELD_ATTACK_POWER , data32[UNIT_FIELD_LEVEL]*2 + (data32[UNIT_FIELD_STAT0]) + (data32[UNIT_FIELD_STAT1]) - 20 + data32[UNIT_FIELD_ATTACK_POWER_MODS]);
			SetFloatValue(PLAYER_CRIT_PERCENTAGE , 5 + (data32[UNIT_FIELD_STAT1])/53.0f);
			SetFloatValue(PLAYER_DODGE_PERCENTAGE , (data32[UNIT_FIELD_STAT1])/26.5f);
		}break;
	case PLAYER_CLASS_SHAMAN:
		{
			power_regen = (data32[UNIT_FIELD_STAT4])/5.0f + 17.0f;
			health_regen = (data32[UNIT_FIELD_STAT4])*0.11f;
			SetUInt32Value(UNIT_FIELD_ATTACK_POWER , data32[UNIT_FIELD_LEVEL]*2 + (data32[UNIT_FIELD_STAT0])*2 - 20 + data32[UNIT_FIELD_ATTACK_POWER_MODS]);
		}break;
	case PLAYER_CLASS_DRUID:
		{
			power_regen = (data32[UNIT_FIELD_STAT4])/5.0f + 15.0f;
			health_regen = (data32[UNIT_FIELD_STAT4])*0.9f + 6.5f;
			SetUInt32Value(UNIT_FIELD_ATTACK_POWER , (data32[UNIT_FIELD_STAT0])*2 - 20 + data32[UNIT_FIELD_ATTACK_POWER_MODS]);
		}break;
	case PLAYER_CLASS_MAGE:	
		{
			power_regen = (data32[UNIT_FIELD_STAT4])/4.0f + 12.5f;
			health_regen = (data32[UNIT_FIELD_STAT4])*0.1f;
			SetUInt32Value(UNIT_FIELD_ATTACK_POWER , (data32[UNIT_FIELD_STAT0]) - 10 + data32[UNIT_FIELD_ATTACK_POWER_MODS]);
		}break;
	case PLAYER_CLASS_PRIEST:
		{
			power_regen = (data32[UNIT_FIELD_STAT4])/4.0f + 12.5f;
			health_regen = (data32[UNIT_FIELD_STAT4])*0.1f;
			SetUInt32Value(UNIT_FIELD_ATTACK_POWER , (data32[UNIT_FIELD_STAT0]) - 10 + data32[UNIT_FIELD_ATTACK_POWER_MODS]);
		}break;
	case PLAYER_CLASS_WARLOCK:
		{
			power_regen = (data32[UNIT_FIELD_STAT4])/5.0f + 15.0f;
			health_regen = (data32[UNIT_FIELD_STAT4])*0.07f + 6.0f;
			SetUInt32Value(UNIT_FIELD_ATTACK_POWER , (data32[UNIT_FIELD_STAT0]) - 10 + data32[UNIT_FIELD_ATTACK_POWER_MODS]); 
		}break;
	}
	power_regen = power_regen / 2000.0f; //the value for each ms
	health_regen = health_regen / 2000.0f;
	// multiply attack power change by attack delay, then divide by 14 AP points per 1 damage point/second
	SetUInt32Value(UNIT_FIELD_ATTACK_POWER ,data32[UNIT_FIELD_ATTACK_POWER ]+data32[UNIT_FIELD_ATTACK_POWER_MODS]);
	float dmg = ((data32[UNIT_FIELD_ATTACK_POWER ]) * data32[UNIT_FIELD_BASEATTACKTIME]) / (14*1000.0f);
	if(dmg + spell_min_dmg[0]>0)
		SetUInt32Value(PLAYER_FIELD_MOD_DAMAGE_DONE_POS,(uint32)(dmg + spell_min_dmg[0]));
	else if(dmg + spell_min_dmg[0]<0)
		SetUInt32Value(PLAYER_FIELD_MOD_DAMAGE_DONE_NEG,(uint32)(dmg + spell_min_dmg[0]));
	//dmg is used alot so we precalc as much as we can
	dmg_min[0]=(item_min_dmg[0]+spell_min_dmg[0]+dmg)*dataf[PLAYER_FIELD_MOD_DAMAGE_DONE_PCT];
	dmg_diff[0]=(uint32)((item_max_dmg[0]+spell_min_dmg[0]+dmg)*dataf[PLAYER_FIELD_MOD_DAMAGE_DONE_PCT] - dmg_min[0] + 1);
	if(dmg_diff[0]<1)dmg_diff[0]=1;
	dataf[UNIT_FIELD_MINDAMAGE] = dmg_min[0];
	dataf[UNIT_FIELD_MAXDAMAGE] = dmg_min[0] + dmg_diff[0] - 1;

	data32[UNIT_FIELD_RESISTANCES] -= spell_res_pct_values[0];
	spell_res_pct_values[0] = (uint32)(data32[UNIT_FIELD_RESISTANCES]*spell_res_pct[0]);
	data32[UNIT_FIELD_RESISTANCES] += spell_res_pct_values[0];
   	for(int i=1;i<PLAYER_USED_DMG_TYPES;i++)
	{
		//correct would be this but for some reason client shows only fizical dmg mods
//		if(spell_min_dmg[i]>0) SetUInt32Value(PLAYER_FIELD_MOD_DAMAGE_DONE_POS+i,(uint32)(spell_min_dmg[i]));
//		else if(spell_min_dmg[i]<0) SetUInt32Value(PLAYER_FIELD_MOD_DAMAGE_DONE_NEG+i,(uint32)(spell_min_dmg[i]));
		if(spell_min_dmg[i]>0) data32[PLAYER_FIELD_MOD_DAMAGE_DONE_POS] +=(uint32)(spell_min_dmg[i]);
		else if(spell_min_dmg[i]<0) data32[PLAYER_FIELD_MOD_DAMAGE_DONE_NEG] +=(uint32)(spell_min_dmg[i]);
		dmg_min[i]=(item_min_dmg[i]+spell_min_dmg[i])*dataf[PLAYER_FIELD_MOD_DAMAGE_DONE_PCT+i];
		dmg_diff[i]=(uint32)((item_max_dmg[i]+spell_max_dmg[i])*dataf[PLAYER_FIELD_MOD_DAMAGE_DONE_PCT+i] - dmg_min[i] + 1);
		if(dmg_diff[i]<1)dmg_diff[i]=1;
		dataf[UNIT_FIELD_MINDAMAGE] += dmg_min[i];
		dataf[UNIT_FIELD_MAXDAMAGE] += dmg_min[i] + dmg_diff[i] - 1;
	}
	update_mask.SetBit(UNIT_FIELD_MINDAMAGE);
	update_mask.SetBit(UNIT_FIELD_MAXDAMAGE);
//	SetFloatValue(UNIT_FIELD_MINOFFHANDDAMAGE , dataf[UNIT_FIELD_MINDAMAGE]/2);
//	SetFloatValue(UNIT_FIELD_MAXOFFHANDDAMAGE , dataf[UNIT_FIELD_MAXDAMAGE]/2);
	//if player has dual vield then don't forget about that neighter(later)
	if(Get_race()==PLAYER_RACE_TYPE_NIGHT_ELF)
		SetFloatValue(PLAYER_DODGE_PERCENTAGE, dataf[PLAYER_DODGE_PERCENTAGE] + 1);
//	SetFloatValue(PLAYER_BLOCK_PERCENTAGE,0); //this is item dependent
	//apply some skills here they should apply to base stats but let's make things more intresting :)
}

void Character::on_spell_change_resistance()
{
	//calc base armor
	SetUInt32Value(UNIT_FIELD_RESISTANCES , 2*(data32[UNIT_FIELD_STAT1])+data32[UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE]-data32[UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE]);
   	for(int i=0;i<PLAYER_USED_DMG_TYPES;i++)
	{
		//remove old value
		SetUInt32Value(UNIT_FIELD_RESISTANCES+i,data32[UNIT_FIELD_RESISTANCES+i] - spell_res_pct_values[i]);
		if(spell_res_pct_values[i]<0) SetUInt32Value(UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+i,data32[UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+i] + spell_res_pct_values[i]);
		else SetUInt32Value(UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+i,data32[UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+i] - spell_res_pct_values[i]);

		//recalc
		spell_res_pct_values[i] = (uint32)(data32[UNIT_FIELD_RESISTANCES+i]*spell_res_pct[i]);

		//set
		if(spell_res_pct_values[i]<0) SetUInt32Value(UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+i,data32[UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+i] - spell_res_pct_values[i]);
		else SetUInt32Value(UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+i,data32[UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+i] + spell_res_pct_values[i]);
		SetUInt32Value(UNIT_FIELD_RESISTANCES+i,data32[UNIT_FIELD_RESISTANCES+i] + spell_res_pct_values[i]);

		if(*(signed int*)&data32[UNIT_FIELD_RESISTANCES+i]<-1)
			SetUInt32Value(UNIT_FIELD_RESISTANCES+i,0);
	}
}

void Character::msg_inv_change_result(Item *item1,Item *item2,uint8 result)
{
	uint8 shift=0;
	G_send_packet.opcode = SMSG_INVENTORY_CHANGE_FAILURE;
	G_send_packet.data[0] = result;
    if( result == INV_ERR_YOU_MUST_REACH_LEVEL_N )
	{
		*(uint32*)&G_send_packet.data[1] = item1->item_data32[ITEM_REQUIRE_LVL];
		shift=4;
	}
	if(item1) *(uint64*)&G_send_packet.data[1+shift] = item1->getGUID();
	else *(uint64*)&G_send_packet.data[1+shift] = NULL;
	if(item2) *(uint64*)&G_send_packet.data[9+shift] = item2->getGUID();
	else *(uint64*)&G_send_packet.data[9+shift] = NULL;
	G_send_packet.data[17+shift] = result;
	G_send_packet.length = 18 + shift;
	pClient->SendMsg(&G_send_packet);
}

void Character::on_logout()
{
	//create snapshot used on next logon
	Char_snapshot char_snapshot;
	char_snapshot.create_snapshot(this); //this will create snapshot
	//call custom event
	On_Player_Log_Out(this);
	//if we are duelling then we should abort it
	if(duel_info.dual_arbiter)
	{
		finish_duel(0);
		duel_info.target->finish_duel(0);
	}
	if(state1 & PLAYER_STATE_DEAD && !(state1 & PLAYER_STATE_CORPSE))
		on_char_corpse(1);	//brute force exit, we create corpse and cast spells
	//inform players who can see this player that he left the world
	//inform world with message that we left the world
	char message_to_world[300];
	sprintf(message_to_world,"|cdf20af20 %s |c1f40af20 has left the world",name);
	WORLDSERVER.send_message(message_to_world,SEND_MESSAGE_TO_EVRYBODY,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,this,NULL);
	//remove ourself from the group
	if(group)
		group->del(this);
//	G_maps[map_id]->del_char_block(this);
	G_maps[map_id]->del_char(this);
	//save char to db
	save_to_db();
	if(!(state1 & PLAYER_STATE_CORPSE))
	{
		G_maps[map_id]->on_player_exited_block(this);
	}
	else
	{
		//if we are dead then we are destroyed for others but we remove ourself from the mapmanager from corpse location
		//make sure we didn't forgot the rules. Better to remove 2 times then crash the server ;)
		pos_x = corpse_x;
		pos_y = corpse_y;
		G_maps[map_id]->del_char(this);
	}
	//set player offline in db so it can log in next time
	G_dbi_r->set_player_offline(pClient->m_accountId,(uint32)db_id);
	//remove corpse if we are dead
	if(pcorpse)
	{
		delete pcorpse;
		pcorpse=NULL;
	}
	//inform server output that somebody loged out
	printf("%s has left the game\n",name);
	//clear ourselfs from folowers
	uint32 i,j;
	for(i=0;i<5;i++)
		for(j=0;j<5;j++)
			if(folower_matrix[i][j])
			{
				folower_matrix[i][j]->folowed_char = NULL;
				folower_matrix[i][j] = 0;
			}
	//clear items
    //destroy items for char
	for ( i = PLAYER_FIELD_INV_SLOT_HEAD+0; i < PLAYER_FIELD_INV_SLOT_HEAD + BANK_SLOT_BAG_END*2; i +=2)
	{
		if(data32[i]!=0) 
		{
			//delete bag content
			if((INVENTORY_SLOT_BAG_START*2+PLAYER_FIELD_INV_SLOT_HEAD)<=i && i<(INVENTORY_SLOT_BAG_END*2+PLAYER_FIELD_INV_SLOT_HEAD))
			{
				Item *cur_bag=((Item*)data32[i]);
				uint32 bag_slot_iter;
				for (bag_slot_iter=CONTAINER_FIELD_SLOT_1;bag_slot_iter<CONTAINER_END;bag_slot_iter+=2)
					if(cur_bag->data32[bag_slot_iter]!=0)
					{
						G_Object_Pool.Release_item(((Item*)cur_bag->data32[bag_slot_iter]));
						cur_bag->data32[bag_slot_iter] = 0;
					}
			}
			G_Object_Pool.Release_item((Item*)data32[i]); //delete whatever item it is
			data32[i] = 0;
		}
	}
    spellbook.clear();
    affect_list->clear();
    spell_cooldowns.clear();
	quests_finished.clear();
	quests_started.clear();
	on_attack_spell_dmg.clear();
	on_struck_spell_dmg.clear();
	//destroy pet
}

void Character::msg_change_speed(uint8 speed_type)
{
	G_send_packet.data[0] = 0xFF;
	*(uint32*)(G_send_packet.data+1)=getGUIDL();
	*(uint32*)(G_send_packet.data+5)=getGUIDH();
	*(uint32*)(G_send_packet.data+9)=G_packet_serializer++;
	G_send_packet.length = 17;
	switch(speed_type)
	{
		case SPEED_CHANGE_TYPE_RUN:
		{
			G_send_packet.opcode = SMSG_FORCE_RUN_SPEED_CHANGE;
			*(float*)(G_send_packet.data+13) = speed_land_modifyer*UNIT_NORMAL_RUN_SPEED;
		}break;
		case SPEED_CHANGE_TYPE_RUN_BACK:
		{
			G_send_packet.opcode = SMSG_FORCE_RUN_BACK_SPEED_CHANGE;
			*(float*)(G_send_packet.data+13) = speed_land_modifyer*UNIT_NORMAL_RUN_BACK_SPEED;
		}break;
		case SPEED_CHANGE_TYPE_WALK:
		{
			G_send_packet.opcode = SMSG_FORCE_WALK_SPEED_CHANGE;
			*(float*)(G_send_packet.data+13) = speed_land_modifyer*UNIT_NORMAL_WALK_SPEED;
		}break;
		case SPEED_CHANGE_TYPE_SWIM:
		{
			G_send_packet.opcode = SMSG_FORCE_SWIM_SPEED_CHANGE;
			*(float*)(G_send_packet.data+13) = speed_water_modifyer*UNIT_NORMAL_SWIM_SPEED;
		}break;
		case SPEED_CHANGE_TYPE_SWIM_BACK:
		{
			G_send_packet.opcode = MSG_MOVE_SET_SWIM_BACK_SPEED;
			*(float*)(G_send_packet.data+13) = speed_water_modifyer*UNIT_NORMAL_SWIM_BACK_SPEED;
		}break;
	}
	pClient->SendMsg(&G_send_packet);
}

void Character::add_skill(uint32 skill_id,uint32 cur_lvl,uint32 max_lvl)
{
	uint32 i,has_pos=666;
	//check if we already have it
	for(i=0;i<PLAYER_SKILL_ENTRY_NUMBER;i++)
		if(skill_list[i].lineId==skill_id)
		{
			has_pos=i;
			break;
		}
	if(has_pos==666)
		for(i=0;i<PLAYER_SKILL_ENTRY_NUMBER;i++)
			if(skill_list[i].lineId==0)
			{
				has_pos=i;
				break;
			}
	skill_list[has_pos].lineId=skill_id;
	skill_list[has_pos].currVal=cur_lvl;
	skill_list[has_pos].maxVal=max_lvl;
	update_mask.SetBit(PLAYER_SKILL_INFO_1_1+i*sizeof(skill_entry)/4);
	update_mask.SetBit(PLAYER_SKILL_INFO_1_1+i*sizeof(skill_entry)/4+1);
}

uint8 Character::has_skill(uint32 skill_id,uint32 skill_lvl)
{

	uint32 i;
	for(i=0;i<PLAYER_SKILL_ENTRY_NUMBER;i++)
		if(skill_list[i].lineId==skill_id && skill_list[i].currVal>=skill_lvl)
			return 1;
	return 0;
}

//each creature should have it own reputation table to know who to attack/friendly
/*signed int Character::GetFactionReputation(uint32 faction_id)
{
	return 0;
}*/

//this function will be called alot of times(each time something cahnges on char). Better make it fast as possible
uint8 Character::quest_relation(uint32 quest_id,creature *asker)
{
	Quest_template *ptemplate;
//	if(!(quest_id < G_max_quest_id && G_quest_prototypes[quest_id]))
//		return;
	ptemplate = G_quest_prototypes[quest_id];//we should have taken care of wrong quests on load
	//check if it is a finished quest. The fastest way to give a result
	if(!(ptemplate->s_flags & QUEST_SPECIAL_FLAGS_REPEATABLE) && quests_finished.has_quest(quest_id))
		return QMGR_QUEST_NOT_AVAILABLE;
	//check if we could have this quest(we did not finish it and we did not start it yet)
	if(	ptemplate->req_lvl > data32[UNIT_FIELD_LEVEL])
		return QMGR_QUEST_AVAILABLELOW_LEVEL;
	if(
		ptemplate->obj_money > data32[PLAYER_FIELD_COINAGE] ||
		!(ptemplate->req_class_flags & (1 << (Get_class()+1))) ||
		!(ptemplate->req_race_flags & (1 << (Get_race()+1))) ||
//		(ptemplate->req_rep_faction && !(reputation[ptemplate->req_rep_faction] || reputation_val[ptemplate->req_rep_value])) ||
		(ptemplate->req_quest[0] && !quests_finished.has_quest(ptemplate->req_quest[0])) ||
		(ptemplate->req_quest[1] && !quests_finished.has_quest(ptemplate->req_quest[1])) ||
		(ptemplate->req_quest[2] && !quests_finished.has_quest(ptemplate->req_quest[2])) ||
		(ptemplate->req_quest[3] && !quests_finished.has_quest(ptemplate->req_quest[3])) ||
		(ptemplate->prev_quest_id && !quests_finished.has_quest(ptemplate->prev_quest_id)) ||
		(ptemplate->req_skill && !has_skill(ptemplate->req_skill,ptemplate->req_skill_value)) ||
		(ptemplate->req_spell && !spellbook.find(ptemplate->req_spell)) ||
		(ptemplate->src_item_id && get_total_item_count(ptemplate->src_item_id)<ptemplate->src_item_count)
		)
		return QMGR_QUEST_NOT_AVAILABLE;
//printf("quest %u met requirements and it's not taken\n",quest_id);
	//check currently rolling quests
	Quest_instance_Node *itr=quests_started.first;
	while(itr && itr->value.id!=quest_id)
		itr = itr->next;
	if(itr)
	{
		if(itr->value.state != QMGR_QUEST_FINISHED && G_cur_time>itr->value.end_timestamp_s)
		{
			itr->value.state = QMGR_QUEST_FAILED;
			msg_quest_timer_failed(pClient,itr->value.id);
		}
		return itr->value.state;
	}
//	{
//printf("found quest as an active quest %u, asker %u, speaktoid %u,askerid %u\n",itr->value.id,asker,ptemplate->obj_speakto_id,asker->data32[OBJECT_FIELD_ENTRY]);
//		if(asker && ptemplate->obj_speakto_id==asker->data32[OBJECT_FIELD_ENTRY]) return quests_started.would_finish(itr,asker->data32[OBJECT_FIELD_ENTRY]);
//		else return itr->value.state;
//	}
	//if we met all requirements and we did not finish it already and we do not already have it, then we can start it 
	return QMGR_QUEST_AVAILABLE;
}

uint32 Character::get_total_item_count(uint32 item_id)
{
	uint32 total_count=0;
	uint32 index;
	for ( index = PLAYER_FIELD_INV_SLOT_HEAD; index < PLAYER_FIELD_BANK_SLOT_1; index +=2)
		if(data32[index]!=0 && ((Item*)(data32[index]))->item_data32[ITEM_ID]==item_id)
			total_count += ((Item*)(data32[index]))->data32[ITEM_FIELD_STACK_COUNT];
	for ( index = INVENTORY_SLOT_BAG_START*2+PLAYER_FIELD_INV_SLOT_HEAD; index < INVENTORY_SLOT_BAG_END*2+PLAYER_FIELD_INV_SLOT_HEAD; index +=2)
		if(data32[index]!=0)
		{
			//parse bag content
			Item *cur_bag = (Item *)data32[index];
			uint32 c_slot;
			for(c_slot=CONTAINER_FIELD_SLOT_1;c_slot<CONTAINER_END;c_slot+=2)
				if(cur_bag->data32[c_slot]!=0 && ((Item*)(cur_bag->data32[c_slot]))->item_data32[ITEM_ID]==item_id)
					total_count += ((Item*)(cur_bag->data32[c_slot]))->data32[ITEM_FIELD_STACK_COUNT];
		}
	return total_count;
}

void Character::try_force_enter_combat(uint64 atacker_GUID)
{
	if(state1 & PLAYER_STATE_IN_COMBAT)
		return;
	SetUInt64Value(UNIT_FIELD_TARGET,atacker_GUID);
	//loose action points if we change target
	SetUInt64Value(PLAYER__FIELD_COMBO_TARGET,atacker_GUID);
	SetComboPoints(0);
	flag_set(UNIT_FIELD_FLAGS, U_FIELD_FLAG_ATTACK_ANIMATION);
	state1 |=PLAYER_STATE_IN_COMBAT;
	last_target_GUID = atacker_GUID;
	atimer1 = G_cur_time_ms + (uint32)(data32[UNIT_FIELD_BASEATTACKTIME]*speed_attack_modifyer);
	if(((uint32)(atacker_GUID>>32)) & (HIGHGUID_UNIT | HIGHGUID_PLAYER))
		target = ((Base_Unit_Object*)atacker_GUID);
	// Send out ATTACKSTART
	P_SMSG_ATTACKSTART *packet=(P_SMSG_ATTACKSTART *)G_send_packet.data;
	G_send_packet.opcode = SMSG_ATTACKSTART;
	packet->self_guid_mask = 0xFF;
	packet->self_guid[0] = getGUIDL();
	packet->self_guid[1] = getGUIDH();
	packet->target_guid_mask = 0xFF;
	*(uint64*)packet->self_guid = atacker_GUID;
	G_send_packet.length = sizeof(P_SMSG_ATTACKSTART);
	pClient->SendMsg(&G_send_packet);
}
//called by creatures when he exited combat (die or return)
void Character::try_force_exit_combat()
{
	if(!(state1 & PLAYER_STATE_IN_COMBAT))
		return;
	SetUInt64Value(UNIT_FIELD_TARGET,0);
	G_send_packet.opcode = SMSG_ATTACKSTOP;
	P_SMSG_ATTACKSTOP *packet=(P_SMSG_ATTACKSTOP *)G_send_packet.data;
	packet->self_guid_mask=0xFF;
	packet->self_guid[0] = getGUIDL();
	packet->self_guid[1] = getGUIDH();
	packet->target_guid_mask=0xFF;
	*(uint64*)packet->target_guid = selected_object_guid;
	packet->flags = 0; //can be 0,1 from samples
	G_send_packet.length = sizeof(P_SMSG_ATTACKSTOP);
	pClient->SendMsg(&G_send_packet);
	//remove crossed swords
	flag_clr(UNIT_FIELD_FLAGS, U_FIELD_FLAG_ATTACK_ANIMATION);
	//get player out of combat
	state1 &=~PLAYER_STATE_IN_COMBAT;
	atimer1 = 0;
	target = NULL;
	//loose action points if we change target
	SetUInt64Value(PLAYER__FIELD_COMBO_TARGET,0);
	SetComboPoints(0);
	flag_clr(UNIT_FIELD_FLAGS, U_FIELD_FLAG_ATTACK_ANIMATION);
	state1 &=~PLAYER_STATE_IN_COMBAT;
}

//used for dota so not all creatures will be at the same place
void Character::get_folower_next_coords(creature *folower)
{
	uint32 i,j;
	float x,y,nx,ny;
	//find creature in our matrix
	for(i=0;i<5;i++)
		for(j=0;j<5;j++)
			if(folower_matrix[i][j]==folower)
			{
				x=(float)j-2;
				y=(float)i-2;
				goto GOT_CREATURE_POS_IN_MATRIX;
			}
	//find an empty spot in matrix (first clean out the trash
	for(i=0;i<5;i++)
		for(j=0;j<5;j++)
			if(folower_matrix[i][j] && !(folower_matrix[i][j]->state1 & (CREATURE_STATE_FOLLOW | CREATURE_STATE_DEAD)))
				folower_matrix[i][j]=0;
	struct point2d { float x,y;};
	static point2d search_pattern[] = {{2,1},{2,3},{1,3},{1,1},{1,2},{2,0},{2,4},{1,0},{1,4},{0,1},{0,3},{0,2},{0,0},{0,4},{3,1},{3,3},{3,0},{3,4},{4,1},{4,3},{3,2},{4,0},{4,4},{4,2}};
	for(i=0;i<25;i++)
		if(folower_matrix[(int)(search_pattern[i].y)][(int)(search_pattern[i].x)]==0)
		{
			x=search_pattern[i].x-2;
			y=search_pattern[i].y-2;
			folower_matrix[(int)(search_pattern[i].y)][(int)(search_pattern[i].x)] = folower;
			goto GOT_CREATURE_POS_IN_MATRIX;
		}
	return;//in this case we can't give back coords
GOT_CREATURE_POS_IN_MATRIX:
	//i and j means the position in matrix. We rotate those points in 2d space to get the displacement relative to char
	float sv = sin(orientation);
	float cv = cos(orientation);
	nx = x * cv - y * sv;
	ny = y * cv + x * sv;
	folower->dst_x = pos_x + nx;
	folower->dst_y = pos_y + ny;
	folower->orientation = orientation;
}

//used to make creature get away from a specific point. He will keep running for x ms
void Character::AI_flee_from_point(uint32 time)
{
	//choose a target point to head to. and start moving unit to that point
	float dist=UNIT_NORMAL_RUN_SPEED*time/1000;
	float direction = 6.14f - orientation;
	prev_x = pos_x;
	prev_y = pos_y;
	pos_x = pos_x + sin(direction)*dist;
	pos_y = pos_y + cos(direction)*dist;
	msg_move_creauture(pos_x,pos_y,pos_z+1,time,1);
	//set state so he won't be able to cast spells and stuff
	state1 |= UNIT_STATE_FLEE;
	atimer1 = G_cur_time_ms + time;
	//make unit not controllable
	Send_SMSG_FORCE_MOVE_ROOT();
}

void Character::genrate_quest_loot(uint32 creature_id)
{
	//add quest required items if not added 
	Quest_instance_Node *itr=quests_started.first;
	int loop_itr = 1,i;
	while(itr)
	{
		//for current quest check if it requires items
		for(i=0;i<4;i++)
			if(itr->value.obj_items_remaining[i] && (G_quest_prototypes[itr->value.id]->obj_item_from_cr_id[i]==0 || G_quest_prototypes[itr->value.id]->obj_item_from_cr_id[i]==creature_id))
			{
				//because quest items are not randomized we can do this jerkish solition
				quest_loot_item_ids[loop_itr] = G_quest_prototypes[itr->value.id]->obj_item_id[i];
				loop_itr++;
			}
		itr = itr->next;
	}
	//warning, first element contains length
	quest_loot_item_ids[0]=loop_itr;
}

// 0-cancel duel, 1 won , 2 flee, 3 - lost
void Character::finish_duel(uint8 finish_type)
{
    // duel not requested
	if(!(state1 & (PLAYER_STATE_DUEL_PREPARE | PLAYER_STATE_IN_DUEL | PLAYER_STATE_DUEL_UTOFBOUNDS)))
		return;

	state1 &= ~(PLAYER_STATE_DUEL_PREPARE | PLAYER_STATE_IN_DUEL | PLAYER_STATE_DUEL_UTOFBOUNDS);

	if(duel_info.initiator==duel_info.target)
	{
		duel_info.dual_arbiter->despawn();
		G_maps[duel_info.dual_arbiter->map_id]->del_go(duel_info.dual_arbiter);
		delete duel_info.dual_arbiter;
	}

	duel_info.dual_arbiter = NULL;

	if((finish_type==0 && duel_info.initiator==duel_info.target)
		|| finish_type!=0)
	{
		G_send_packet.opcode = SMSG_DUEL_COMPLETE;
		G_send_packet.data[0] = (finish_type!=0);
		G_send_packet.length = 1;
		SendMsg(&G_send_packet);
	}

    if(finish_type != 0)
    {
		G_send_packet.opcode = SMSG_DUEL_WINNER;
		G_send_packet.data[0] = !(finish_type==1);
		G_send_packet.length = 1;
		uint32 namelen=strlen(name)+1;
		memcpy(G_send_packet.data + G_send_packet.length,name,namelen);
		G_send_packet.length += namelen;
		namelen=strlen(duel_info.target->name)+1;
		memcpy(G_send_packet.data + G_send_packet.length,duel_info.target->name,namelen);
		G_send_packet.length += namelen;
		SendMsg(&G_send_packet);
		//remove auras
		//set spell cooldown for both sides
		G_send_packet.opcode = SMSG_COOLDOWN_EVENT;
		G_send_packet.data32[0] = duel_info.spell_id;
		G_send_packet.data32[1] = getGUIDL();
		G_send_packet.data32[2] = getGUIDH();
		G_send_packet.length = 12;
		SendMsg(&G_send_packet);
    }
    SetUInt64Value(PLAYER_DUEL_ARBITER, 0);
    SetUInt32Value(PLAYER_DUEL_TEAM, 0);
}

inline void Character::Send_SMSG_FORCE_MOVE_UNROOT()
{
	G_send_packet.opcode = SMSG_FORCE_MOVE_UNROOT;
	G_send_packet.data[0] = 0xFF;
	*(uint32*)(G_send_packet.data+1) = getGUIDL();
	*(uint32*)(G_send_packet.data+5) = getGUIDH();
	*(uint32*)(G_send_packet.data+9) = G_packet_serializer++;
	G_send_packet.length = 13;
	SendMsg(&G_send_packet);
}

inline void Character::Send_SMSG_MOVE_WATER_WALK()
{
	G_send_packet.opcode = SMSG_MOVE_WATER_WALK;
	G_send_packet.data[0] = 0xFF;
	*(uint32*)(G_send_packet.data+1) = getGUIDL();
	*(uint32*)(G_send_packet.data+5) = getGUIDH();
	*(uint32*)(G_send_packet.data+9) = G_packet_serializer++;
	G_send_packet.length = 13;
	SendMsg(&G_send_packet);
}

inline void Character::Send_SMSG_MOVE_LAND_WALK()
{
	G_send_packet.opcode = SMSG_MOVE_LAND_WALK;
	G_send_packet.data[0] = 0xFF;
	*(uint32*)(G_send_packet.data+1) = getGUIDL();
	*(uint32*)(G_send_packet.data+5) = getGUIDH();
	*(uint32*)(G_send_packet.data+9) = G_packet_serializer++;
	G_send_packet.length = 13;
	SendMsg(&G_send_packet);
}

void Character::Send_SMSG_FORCE_MOVE_ROOT()
{
	G_send_packet.opcode = SMSG_FORCE_MOVE_ROOT;
	G_send_packet.data[0] = 0xFF;
	*(uint32*)(G_send_packet.data+1) = getGUIDL();
	*(uint32*)(G_send_packet.data+5) = getGUIDH();
	*(uint32*)(G_send_packet.data+9) = G_packet_serializer++;
	G_send_packet.length = 13;
	SendMsg(&G_send_packet);
}

#ifdef VERSION_CHAR_MAKE_CREAUTURE_WPOINTS
void Character::handle_generate_z_cords_state()
{
	static Creature_Node *gen_cr_node;
	static creature* gen_sel_cr;
	static Waypoint_Node *gen_wp_itr;
	static uint32 timeout_for_fall=0;
	static uint32 rase_retrys=1;
//printf("%u,%u,%u,%u,%u\n",cur_map_id,cur_cell,timeout_for_fall,rase_retrys,lock_map_id);
	if(cur_map_id==-1)
		goto START_INIT_HERE;
	if((state2 & CHAR_STATE_TO_DO_CREATURE_CORDS_BEFORE_FALL))
	{
		if(timeout_for_fall<G_cur_time_ms)
		{
			if(rase_retrys==CHAR_STATE_TO_DO_CREATURE_CORDS_RETRY_UNTIL_DELETE)
			{
				WORLDSERVER.send_message("deleted not valid waypoint",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,this,NULL);
				//delete only this waypoint
				Waypoint_Node *next_node=gen_wp_itr->next;
				gen_cr_node->value->waypoint_lst.del(gen_wp_itr);
				gen_wp_itr = next_node;
				goto DO_NEXT_WP;
			}
			//in this case char did not hit the ground so we have to raise him higher
			WORLDSERVER.send_message("timeout before fall raising z then making him fall again",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,this,NULL);
			rase_retrys++;
			teleport(this,cur_map_id,gen_wp_itr->dst_x,gen_wp_itr->dst_y,gen_wp_itr->dst_z+rase_retrys*(CHAR_MAKE_CREATURE_WAYPOINT_LIFT_Z+1),0);
			state2 |= CHAR_STATE_TO_DO_CREATURE_CORDS_BEFORE_FALL;
			timeout_for_fall = G_cur_time_ms + CHAR_STATE_TO_DO_CREATURE_CORDS_FALL_TIMEOUT;
			return;
		}
		//if there is no timeout but no fall event eighter then we exit function
		return;
	}
	if(state2 & CHAR_STATE_TO_DO_CREATURE_CORDS_AFTER_FALL)
	{
		//check if this wp is too far from spawn point z, if so then we can remove this wp
		float dif_z=fall_z-gen_cr_node->value->pos_z;//creature pos_z is actually spawn z since we do not move them while doing wps
		if(fabs(dif_z)>CHAR_STATE_TO_DO_CREATURE_CORDS_ACCEEPTED_ELEVATION_DIFFRENCE)
		{
			WORLDSERVER.send_message("this wp is too far from spawn z, delteing it",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,this,NULL);
			Waypoint_Node *next_node=gen_wp_itr->next;
			gen_cr_node->value->waypoint_lst.del(gen_wp_itr);
			gen_wp_itr = next_node;
		}
		else
		{
			//we got a z for this waypoint so we can go to the next one
			WORLDSERVER.send_message("got this wp z cord",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,this,NULL);
			gen_wp_itr->dst_z = fall_z+CHAR_STATE_TO_DO_CREATURE_CORDS_LIFT_CREATURES;
	//		state2 &= ~CHAR_STATE_TO_DO_CREATURE_CORDS_AFTER_FALL;
			gen_wp_itr=gen_wp_itr->next;
		}
		goto DO_NEXT_WP;		
	}
START_INIT_HERE:
	//check if we finished with this map
	if(lock_map_id!=-1)
	{
		cur_map_id=lock_map_id;
		cur_cell = 0;//reset cell iterator in case it is a valid map id
		goto GET_NEXT_GOOD_CELL;
	}
	else if(cur_map_id==-1 || cur_cell>(int)G_maps[cur_map_id]->cell_count)
	{
GET_NEXT_MAP:
		if(cur_map_id<0)
			cur_map_id=0;
		WORLDSERVER.send_message("selecting next available map",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,this,NULL);
		//get next valid map_id
		while(cur_map_id<(int)G_max_map_id && G_maps[cur_map_id]==NULL)
			cur_map_id++;
		//check if we finished making Z cords for all creatures
		if(cur_map_id==G_max_map_id)
		{
FINISHED_PARSING_MAPS:
			WORLDSERVER.send_message("Finished to generate creature z cords",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,this,NULL);
			state2 &= ~CHAR_STATE_TO_DO_CREATURE_CORDS;
			return;
		}
		cur_cell = 0;//reset cell iterator in case it is a valid map id
GET_NEXT_GOOD_CELL:
		WORLDSERVER.send_message("searching for next cell that has creatures",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,this,NULL);
		//get a lock on a good cell
		while(cur_cell<(int)G_maps[cur_map_id]->cell_count && (G_maps[cur_map_id]->cells[cur_cell]==NULL || (G_maps[cur_map_id]->cells[cur_cell]!=NULL && G_maps[cur_map_id]->cells[cur_cell]->cr_lst.first==NULL)))
			cur_cell++;
		//this map seems to not have any cells or creatures so we select another one
		if(cur_cell==G_maps[cur_map_id]->cell_count)
		{
			if(lock_map_id==-1)
				goto FINISHED_PARSING_MAPS;
			cur_map_id++;
			goto GET_NEXT_MAP;
		}
		//start iterating on the list of creatures
		gen_cr_node = G_maps[cur_map_id]->cells[cur_cell]->cr_lst.first;
		while(gen_cr_node && gen_cr_node->value->z_cords_already_checked)
			gen_cr_node = gen_cr_node->next;
		if(!gen_cr_node)
		{
			cur_cell++;
			goto GET_NEXT_GOOD_CELL;
		}
		//start iterating on waypoints of the creature
		gen_wp_itr=gen_cr_node->value->waypoint_lst.first;
	}
	//teleport to creature next waypoint if awailable
DO_NEXT_WP:
	WORLDSERVER.send_message("get next wp to process",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,this,NULL);
	if(gen_wp_itr)
	{
		//we raise player and wait him to fall on the ground
		teleport(this,cur_map_id,gen_wp_itr->dst_x,gen_wp_itr->dst_y,gen_wp_itr->dst_z+CHAR_MAKE_CREATURE_WAYPOINT_LIFT_Z,0);
		state2 |= CHAR_STATE_TO_DO_CREATURE_CORDS_BEFORE_FALL;
		timeout_for_fall = G_cur_time_ms + CHAR_STATE_TO_DO_CREATURE_CORDS_FALL_TIMEOUT;
		rase_retrys = 0;
		fall_z = 0;
	}
	else 
	{
		WORLDSERVER.send_message("finished with this creature, going to next",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,this,NULL);
		//count number of waypoints for this creature. If he has none then we can delete it
		if(gen_cr_node->value->waypoint_lst.count_wp()==0)
		{
			//delete it from world by sending a destroy object to block
//			G_maps[cur_map_id]->del_creature(gen_cr_node->value);
//			G_maps[cur_map_id]->on_creature_exited_block(gen_cr_node->value);
			//delete it from db
			G_dbi_w->del_spawn_creature(gen_cr_node->value->db_id);
			WORLDSERVER.send_message("Creature deleted from world and DB because it had no walid spawn points",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,this,NULL);
			goto GET_NEXT_CREATURE;
		}
		//save this creature waypoints
		else G_dbi_w->save_creature_waypoints(gen_cr_node->value);
GET_NEXT_CREATURE:
		//get next creature
		gen_cr_node = gen_cr_node->next;
		while(gen_cr_node && gen_cr_node->value->z_cords_already_checked)
			gen_cr_node = gen_cr_node->next;
		if(gen_cr_node==NULL)
		{
			cur_cell++;
			goto GET_NEXT_GOOD_CELL;
		}
		else 
		{
			gen_wp_itr=gen_cr_node->value->waypoint_lst.first;
			goto DO_NEXT_WP;
		}
	}
}
#endif

