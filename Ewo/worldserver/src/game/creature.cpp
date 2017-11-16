// Copyright (C) 2006 Team Evolution
#include "creature.h"

creature::creature()
{
	data32 = (uint32 *)malloc(UNIT_END*4);
    ASSERT(data32);
    memset(data32,0,UNIT_END*4);
	data32[OBJECT_FIELD_TYPE] = OBJECT_TYPE_CREATURE;
    update_mask.SetCount(UNIT_END);
    update_mask.Clear();
	data32[0]=(uint32)this;
	data32[1]=HIGHGUID_UNIT;
	obj_type = HIGHGUID_UNIT;
	loot_money = 1;
//	trainer_type = 0;
//	elite = 0;
	db_id = 0;
	health = 1;
	dmg_taken = 0;
	dmg_done = 0;
	state1 = CREATURE_STATE_PATROLLING;
	pos_x = (float)-8931.65; //dump uninitilised cretures in a place where we can see them
	pos_y = (float)-114.644;
	pos_z = (float)82.4876;
	orientation = 1;
	atimer1 = G_cur_time_ms;
	map_id = 0;
	agro_list.owner = this;
	adv_x = 0;
	adv_y = 0;
	adv_z = 0;
	prototype = NULL;
	mod_id = 0;
	dmg_type = 0;
//	loot_template_id=0;
	memset(loots,NULL,sizeof(Item*)*(MAX_LOOTS_FOR_OBJECT));
	figh_points=0;
	folowed_char = NULL;
	speed_land_modifyer = 1;
	speed_water_modifyer = 1;
	speed_attack_modifyer = 1;
	spell_cooldown_atimer = 0;
	sell_item_list = NULL;
	name = NULL;
	respawn_delay=CREATURE_RESPAWN_DELAY;
	last_atacker_guid = 0;
	flags1 = 0;
}

creature::~creature()
{
	//sell_item_list->clear();
	//sell_spell_list->clear();
}

void creature::init_from_template(creature *cr_template)
{
	//init the instance
	prototype = cr_template;
	static_data = cr_template->static_data;
	name = cr_template->name;
//	guild = cr_template->guild;
	memcpy(data32,cr_template->data32,UNIT_END*4);
	speed_land_modifyer=cr_template->speed_land_modifyer;
//	type=cr_template->type;
//	family=cr_template->family;
//	trainer_type=cr_template->trainer_type;
//	elite=cr_template->elite;
//	loot_template_id = prototype->loot_template_id;
//	level_diff = cr_template->level_diff;
	dmg_type = cr_template->dmg_type;
	if(cr_template->sell_item_list)
	{
		//we have to create a sell item list for this creature
		creature_sell_item_node *itr,*new_node;
		sell_item_list = new creature_sell_item_list;
		itr = cr_template->sell_item_list->first;
		while(itr)
		{
			new_node = new creature_sell_item_node;
			memcpy(new_node,itr,sizeof(creature_sell_item_node));
			sell_item_list->add(new_node);
			itr = itr->next;
		}
	}
	//these are static lists and can be used globaly from the templates
//	train_class = cr_template->train_class;
//	quests_list = cr_template->quests_list;
//	spell_book = cr_template->spell_book;
//	sell_spell_list = cr_template->sell_spell_list;
//	yell_list = cr_template->yell_list;
	set_guid();
}

void creature::spawn()
{
	uint32 i;
	if(flags1 & CREATURE_FLAG_RANDOM_MOVE)
	{
		float		patrol[NUMBER_OF_RANDOM_WAYPOINTS_FOR_CREATURE][4]; //store path point to know where to move next and the time we wait for moving and after it
		uint32		patrol_wait[NUMBER_OF_RANDOM_WAYPOINTS_FOR_CREATURE][2];	//at each patrol point he is going to wait x seconds
		//generate patrol points. These points will be limited to the cell the creture is spawned. so when patrolling he will not generate change_cell event
		float cell_bounds[2][3]; //min x,y,z ; max x,y,z
		G_maps[map_id]->get_cell_boundary(this,(float*)&cell_bounds[0][0]);
//printf("cell bounds are [%f,%f] [%f,%f]\n",cell_bounds[0][0],cell_bounds[0][1],cell_bounds[1][0],cell_bounds[1][1]);
		int min_walk_distance=(uint32)(cell_bounds[0][1]-cell_bounds[1][1])/4; //size of cell/4
		float cur_distance,owerall_distance;
		float dx,dy;
		uint32 ox,oy,star_step;
		patrol[0][0]=pos_x;
		patrol[0][1]=pos_y;
		patrol[0][2]=pos_z;
		ox=G_random.mt_random() % 2;
		oy=G_random.mt_random() % 2;
		star_step = G_random.mt_random() % 4;
		//!!! we will try to generate random points so creature will walk like on a star
		if(min_walk_distance>CREATURE_MAX_PATROL_DISTANCE)min_walk_distance=CREATURE_MAX_PATROL_DISTANCE;
		for(i=1;i<NUMBER_OF_RANDOM_WAYPOINTS_FOR_CREATURE;i++)
		{
			//generate next waypoint so it is far enough to not flood the server with useless mesages
				//the max distance we will walk is a whole cell
			cur_distance=(float)(min_walk_distance*1000 + (G_random.mt_random() % (min_walk_distance*1000)))/1000;
			if(star_step==0 || star_step==1)
				cur_distance = cur_distance * 0.5f;	//we force this walue to be very small
			if(star_step==2 || star_step==3)
				cur_distance = cur_distance * 1.5f;	//we force this walue to be very big
			if(cur_distance<CREATURE_MIN_PATROL_DISTANCE)cur_distance=CREATURE_MIN_PATROL_DISTANCE;
			if(cur_distance>CREATURE_MAX_PATROL_DISTANCE*2)cur_distance=CREATURE_MAX_PATROL_DISTANCE;
			ox=1 - ox; // walk in another direction then last time
			patrol[i][0]=pos_x+2*ox*cur_distance-cur_distance; //we walk around the spawn point
			cur_distance=(float)(min_walk_distance*1000 + (G_random.mt_random() % (min_walk_distance*1000)))/1000;
			if(star_step==0 || star_step==1)
				cur_distance = cur_distance * 1.5f;	//we force this walue to be very big
			if(star_step==2 || star_step==3)
				cur_distance = cur_distance * 0.5f;	//we force this walue to be very small
			star_step = (star_step + 1) % 4;
			if(cur_distance<CREATURE_MIN_PATROL_DISTANCE)cur_distance=CREATURE_MIN_PATROL_DISTANCE;
			if(cur_distance>CREATURE_MAX_PATROL_DISTANCE*2)cur_distance=CREATURE_MAX_PATROL_DISTANCE;
			oy=1 - oy;
			patrol[i][1]=pos_y+2*oy*cur_distance-cur_distance;
				//do not walk out of cell => just to avoid extra chekings
			if(patrol[i][0]<=cell_bounds[0][0])	patrol[i][0]=cell_bounds[0][0];
			if(patrol[i][0]>=cell_bounds[1][0])	patrol[i][0]=cell_bounds[1][0];
			if(patrol[i][1]<=cell_bounds[0][1])	patrol[i][1]=cell_bounds[0][1];
			if(patrol[i][1]>=cell_bounds[1][1])	patrol[i][1]=cell_bounds[1][1];
	//printf("patrol point [%f,%f] added \n",patrol[i][0],patrol[i][1]);
			patrol[i][2]=pos_z;//we should use a z-map here
			dx=(patrol[i][0]-patrol[i-1][0]);
			dy=(patrol[i][1]-patrol[i-1][1]);
			owerall_distance=(sqrt((dx)*(dx)+(dy)*(dy)));//z is always the same so no need to add it here
//			patrol_wait[i][0]=(uint32)((owerall_distance*1000)/(UNIT_NORMAL_WALK_SPEED*speed+speed_modifyer));
			patrol_wait[i][1]=(6000 + G_random.mt_random() % 8000); //creature will wait aprox 6-14 seconds at waypoint end
		}
		dx=(patrol[0][0]-patrol[i-1][0]);
		dy=(patrol[0][1]-patrol[i-1][1]);
		owerall_distance=sqrt((dx)*(dx)+(dy)*(dy));//z is always the same so no need to add it here
		patrol_wait[0][0]=(uint32)((owerall_distance*1000)/(UNIT_NORMAL_WALK_SPEED*speed_land_modifyer));
		patrol_wait[0][1]=(CREATURE_MIN_WAIT_TIME_AT_PATROL + G_random.mt_random() % CREATURE_DIF_WAIT_TIME_AT_PATROL); //time to wait after we arive to the end of the waypoint
//		next_patrol_point = (uint8) (G_random.mt_random() % NUMBER_OF_RANDOM_WAYPOINTS_FOR_CREATURE);
		for(i=0;i<NUMBER_OF_RANDOM_WAYPOINTS_FOR_CREATURE;i++)
		{
			Waypoint_Node *new_node;
			new_node = new Waypoint_Node;
			new_node->dst_x = patrol[i][0];
			new_node->dst_y = patrol[i][1];
			new_node->dst_z = patrol[i][2];
			new_node->dst_o = 1;
			new_node->dst_time_wait = patrol_wait[i][1];
			new_node->speed_coef = 1;
			waypoint_lst.add(new_node);
		}
	}
	else if(waypoint_lst.first==NULL)//just make sure if we used coords somewhere else, no error occures
	{
		Waypoint_Node *new_node;
		new_node = new Waypoint_Node;
		new_node->dst_x = pos_x;
		new_node->dst_y = pos_y;
		new_node->dst_z = pos_z;
		new_node->dst_o = orientation;
		new_node->dst_time_wait = 1;
		new_node->speed_coef = 1;
		waypoint_lst.add(new_node);
	}
//	dmg_abs_min = 0;
//	dmg_abs_dif = (float)data32[UNIT_FIELD_LEVEL];
//	dmg_abs_percent = 0.05f;
//	dmg_abs_type = 0;
	xp_coef = 1;
	money_coef = 1;
	dst_x = pos_x;
	dst_y = pos_y;
	dst_z = pos_z;
	waypoint_lst.restart_path();
//	name = prototype->name;
//	guild = prototype->guild;
	if(!static_data->spell_book.first)
		spell_cooldown_atimer = 0x7FFFFFFF;//no spell casting will occure
	respawn();
#ifdef USE_OBJECT_INTERRUPTS
	//add actions here when spawning, like waypoints and items
	On_Creature_spawn(this);
#endif
}

void creature::respawn()
{
	data32[OBJECT_FIELD_ENTRY]=prototype->data32[OBJECT_FIELD_ENTRY]; //change this for dinamic creature spawning
	health_regen = CREATURE_HEALTH_REGEN_PER_MS;
	//remove him from map 
	G_maps[map_id]->del_creature(this);
	uint32 i;
	//if creature is not a civilian(he's a mob) then we can randomize it
		//if he is already randomized then we de randomize it
	if(mod_id!=0)
	{
		//restore name
		if(name && name!=prototype->name)
		{
			free(name);
			name = prototype->name;
		}
		//restore for each affected type
		for(i=0;i<3;i++)
		{
			switch(G_creature_mods[mod_id].affect_what[i])
			{
				case CREATURE_MOD_INDEX_HEALTH:		{data32[UNIT_FIELD_MAXHEALTH] = prototype->data32[UNIT_FIELD_HEALTH];}break;
				case CREATURE_MOD_INDEX_MANA:		{data32[UNIT_FIELD_BASE_MANA] = prototype->data32[UNIT_FIELD_HEALTH];}break;
				case CREATURE_MOD_INDEX_DMG:		
				{
					dataf[UNIT_FIELD_MINDAMAGE] = prototype->dataf[UNIT_FIELD_MINDAMAGE];
					dataf[UNIT_FIELD_MAXDAMAGE] = prototype->dataf[UNIT_FIELD_MAXDAMAGE];
				}break;
				case CREATURE_MOD_INDEX_DMG_TYPE:	{dmg_type = prototype->dmg_type;}break;
				case CREATURE_MOD_INDEX_SIZE:		{dataf[OBJECT_FIELD_SCALE_X] = 1;}break;
				case CREATURE_MOD_INDEX_ATACK_SPEED:{data32[UNIT_FIELD_BASEATTACKTIME] = prototype->data32[UNIT_FIELD_BASEATTACKTIME];}break;
				case CREATURE_MOD_INDEX_XP:			{xp_coef = 1;}break;
				case CREATURE_MOD_INDEX_GOLD:		{money_coef = 1;}break;
				case CREATURE_MOD_INDEX_LEVEL:		{data32[UNIT_FIELD_LEVEL] = prototype->data32[UNIT_FIELD_LEVEL];}break;
				case CREATURE_MOD_INDEX_DMG_ABSORTION:		
					{
//						dmg_abs_min = 0;
//						dmg_abs_dif = (float)data32[UNIT_FIELD_LEVEL];
					}break;
//				case CREATURE_MOD_INDEX_DMG_ABSORTION_PERCENT:{dmg_abs_percent = 0.05f;}break;
//				case CREATURE_MOD_INDEX_DMG_ABSORTION_TYPE:{dmg_abs_type = 0;}break;		
			}
		}
	}
		//select a modification
	if(G_max_creature_mods)
	{
		uint32 retrys_left=MAX_RETRY_FIND_CREATURE_MOD;
		while(retrys_left)
		{
			uint32 t_mod_id = G_random.mt_random() % G_max_creature_mods;
			if(G_random.mt_random() % 100 < G_creature_mods[t_mod_id].chance_to_appear)
			{
				mod_id = t_mod_id;
				break;
			}
			retrys_left--;
		}
	}
//	for(i=1;i<G_max_creature_mods;i++)
//		//apply modification
	if(mod_id!=0)
	{
		name=(char*)malloc(MAX_CREATURE_NAME_LENGTH);
		data32[OBJECT_FIELD_ENTRY]=(mod_id << 16) + prototype->data32[OBJECT_FIELD_ENTRY];
		char tname[300];
		if(G_creature_mods[mod_id].flags & 1)
		{
			//if it is a suffix
			sprintf(tname,"%s %s",prototype->name,G_creature_mods[mod_id].name);
			tname[50]=0; //make sure it's shorter then max limit
			strcpy(name,tname);
		}
		else
		{
			//it is a prefix
			sprintf(tname,"%s %s",G_creature_mods[mod_id].name,prototype->name);
			tname[50]=0; //make sure it's shorter then max limit
			strcpy(name,tname);
		}
//printf("Made a modification to creature %d. New name %s, mod name %s\n",(uint32)this,name,G_creature_mods[mod_id].name);
		for(i=0;i<3;i++)
		{
			switch(G_creature_mods[mod_id].affect_what[i])
			{
				case CREATURE_MOD_INDEX_HEALTH:
				{
					switch(G_creature_mods[mod_id].affect_type[i])
					{
						case CREATURE_MOD_TYPE_ADD:{data32[UNIT_FIELD_HEALTH] += (uint32)G_creature_mods[mod_id].affect_value[i];}break;
						case CREATURE_MOD_TYPE_MULTIPLY:{data32[UNIT_FIELD_HEALTH] = (uint32)(data32[UNIT_FIELD_HEALTH]*G_creature_mods[mod_id].affect_value[i]);}break;
						case CREATURE_MOD_TYPE_SET:{data32[UNIT_FIELD_HEALTH] = (uint32)G_creature_mods[mod_id].affect_value[i];}break;
					}
				}break;
				case CREATURE_MOD_INDEX_MANA:
				{
					switch(G_creature_mods[mod_id].affect_type[i])
					{
						case CREATURE_MOD_TYPE_ADD:{data32[UNIT_FIELD_BASE_MANA] += (uint32)G_creature_mods[mod_id].affect_value[i];}break;
						case CREATURE_MOD_TYPE_MULTIPLY:{data32[UNIT_FIELD_BASE_MANA] = (uint32)(data32[UNIT_FIELD_BASE_MANA]*G_creature_mods[mod_id].affect_value[i]);}break;
						case CREATURE_MOD_TYPE_SET:{data32[UNIT_FIELD_BASE_MANA] = (uint32)G_creature_mods[mod_id].affect_value[i];}break;
					}
				}break;
				case CREATURE_MOD_INDEX_DMG_TYPE:
				{
					if(G_creature_mods[mod_id].affect_type[i]==CREATURE_MOD_TYPE_SET)
						dmg_type = (uint8)G_creature_mods[mod_id].affect_value[i];
				}break;
				case CREATURE_MOD_INDEX_SIZE:
				{
					switch(G_creature_mods[mod_id].affect_type[i])
					{
						case CREATURE_MOD_TYPE_ADD:{dataf[OBJECT_FIELD_SCALE_X] += G_creature_mods[mod_id].affect_value[i];}break;
						case CREATURE_MOD_TYPE_MULTIPLY:{dataf[OBJECT_FIELD_SCALE_X] *= G_creature_mods[mod_id].affect_value[i];}break;
						case CREATURE_MOD_TYPE_SET:{dataf[OBJECT_FIELD_SCALE_X] = G_creature_mods[mod_id].affect_value[i];}break;
					}
				}break;
				case CREATURE_MOD_INDEX_ATACK_SPEED:
				{
					switch(G_creature_mods[mod_id].affect_type[i])
					{
						case CREATURE_MOD_TYPE_ADD:{data32[UNIT_FIELD_BASEATTACKTIME] += (uint32)G_creature_mods[mod_id].affect_value[i];}break;
						case CREATURE_MOD_TYPE_MULTIPLY:{data32[UNIT_FIELD_BASEATTACKTIME] = (uint32)(data32[UNIT_FIELD_BASEATTACKTIME]*G_creature_mods[mod_id].affect_value[i]);}break;
						case CREATURE_MOD_TYPE_SET:{data32[UNIT_FIELD_BASEATTACKTIME] = (uint32)G_creature_mods[mod_id].affect_value[i];}break;
					}
				}break;
				case CREATURE_MOD_INDEX_LEVEL:
				{
					switch(G_creature_mods[mod_id].affect_type[i])
					{
						case CREATURE_MOD_TYPE_ADD:{data32[UNIT_FIELD_LEVEL] += (uint32)G_creature_mods[mod_id].affect_value[i];}break;
						case CREATURE_MOD_TYPE_MULTIPLY:{data32[UNIT_FIELD_LEVEL] = (uint32)(data32[UNIT_FIELD_LEVEL]*G_creature_mods[mod_id].affect_value[i]);}break;
						case CREATURE_MOD_TYPE_SET:{data32[UNIT_FIELD_LEVEL] = (uint32)G_creature_mods[mod_id].affect_value[i];}break;
					}
				}break;
				case CREATURE_MOD_INDEX_XP:
				{
					switch(G_creature_mods[mod_id].affect_type[i])
					{
						case CREATURE_MOD_TYPE_ADD:{xp_coef += G_creature_mods[mod_id].affect_value[i];}break;
						case CREATURE_MOD_TYPE_MULTIPLY:{xp_coef *= G_creature_mods[mod_id].affect_value[i];}break;
						case CREATURE_MOD_TYPE_SET:{xp_coef = G_creature_mods[mod_id].affect_value[i];}break;
					}
				}break;
				case CREATURE_MOD_INDEX_GOLD:
				{
					switch(G_creature_mods[mod_id].affect_type[i])
					{
						case CREATURE_MOD_TYPE_ADD:{money_coef += G_creature_mods[mod_id].affect_value[i];}break;
						case CREATURE_MOD_TYPE_MULTIPLY:{money_coef *= G_creature_mods[mod_id].affect_value[i];}break;
						case CREATURE_MOD_TYPE_SET:{money_coef = G_creature_mods[mod_id].affect_value[i];}break;
					}
				}break;
				case CREATURE_MOD_INDEX_DMG:
				{
					switch(G_creature_mods[mod_id].affect_type[i])
					{
						case CREATURE_MOD_TYPE_ADD:
							{
								dataf[UNIT_FIELD_MINDAMAGE] += G_creature_mods[mod_id].affect_value[i];
								dataf[UNIT_FIELD_MAXDAMAGE] += G_creature_mods[mod_id].affect_value[i];
							}break;
						case CREATURE_MOD_TYPE_MULTIPLY:
							{
								dataf[UNIT_FIELD_MINDAMAGE] = (dataf[UNIT_FIELD_MINDAMAGE]*G_creature_mods[mod_id].affect_value[i]);
								dataf[UNIT_FIELD_MAXDAMAGE] = (dataf[UNIT_FIELD_MAXDAMAGE]*G_creature_mods[mod_id].affect_value[i]);
							}break;
						case CREATURE_MOD_TYPE_SET:
							{
								dataf[UNIT_FIELD_MINDAMAGE] = G_creature_mods[mod_id].affect_value[i];
								dataf[UNIT_FIELD_MAXDAMAGE] = G_creature_mods[mod_id].affect_value[i];
							}break;
					}
				}break;
/*				case CREATURE_MOD_INDEX_DMG_ABSORTION:		
				{
					switch(G_creature_mods[mod_id].affect_type[i])
					{
						case CREATURE_MOD_TYPE_ADD:
							{
								dmg_abs_min += G_creature_mods[mod_id].affect_value[i];
								dmg_abs_dif += G_creature_mods[mod_id].affect_value[i];
							}break;
						case CREATURE_MOD_TYPE_MULTIPLY:
							{
								dmg_abs_min *= G_creature_mods[mod_id].affect_value[i];
								dmg_abs_dif *= G_creature_mods[mod_id].affect_value[i];
							}break;
						case CREATURE_MOD_TYPE_SET:
							{
								dmg_abs_min = G_creature_mods[mod_id].affect_value[i];
								dmg_abs_dif = G_creature_mods[mod_id].affect_value[i];
							}break;
					}
				}break;
				case CREATURE_MOD_INDEX_DMG_ABSORTION_PERCENT:
				{
					switch(G_creature_mods[mod_id].affect_type[i])
					{
						case CREATURE_MOD_TYPE_ADD:{dmg_abs_percent += G_creature_mods[mod_id].affect_value[i];}break;
						case CREATURE_MOD_TYPE_MULTIPLY:{dmg_abs_percent *= G_creature_mods[mod_id].affect_value[i];}break;
						case CREATURE_MOD_TYPE_SET:{dmg_abs_percent = G_creature_mods[mod_id].affect_value[i];}break;
					}
				}break;
				case CREATURE_MOD_INDEX_DMG_ABSORTION_TYPE:
				{
					if(G_creature_mods[mod_id].affect_type[i]==CREATURE_MOD_TYPE_SET)
						dmg_abs_type = (uint8)G_creature_mods[mod_id].affect_value[i];
				}break;		*/
			}
		}
	}/**/
	//state change comes first or else creature will not generate an create/update packet
	state1 &= ~(CREATURE_STATE_IN_COMBAT | CREATURE_STATE_ROAMING | CREATURE_STATE_RETURN_TO_LAST_POS | CREATURE_STATE_ATACK | CREATURE_STATE_DEAD | CREATURE_STATE_RESPAWN | CREATURE_STATE_SKELETON | CREATURE_STATE_LOOTABLE | CREATURE_STATE_HAS_LOOT_GENERATED | CREATURE_STATE_FOLLOW);//set flag
	state1 |= CREATURE_STATE_PATROLLING | CREATURE_STATE_PATROL_WAIT;//set flag
	dmg_done = 0;
	dmg_taken = 0;
	health = (float)data32[UNIT_FIELD_MAXHEALTH];
    power = (float)data32[UNIT_FIELD_BASE_MANA];
	dst_x = pos_x = waypoint_lst.cur_dst->dst_x;
	dst_y = pos_y = waypoint_lst.cur_dst->dst_y;
	dst_z = pos_z = waypoint_lst.cur_dst->dst_z;
	waypoint_lst.get_next_waypoint();
	atimer1 = G_cur_time_ms; //start walking as soon as possible
	agro_list.clear();
	affect_list->clear();
	adv_x = 0;
	adv_y = 0;
	adv_z = 0;
	if(dataf[UNIT_FIELD_MINDAMAGE]==0)
		dataf[UNIT_FIELD_MINDAMAGE]=1;//the laugh of the world :(
	dmg_diff = (uint32)(dataf[UNIT_FIELD_MAXDAMAGE]-dataf[UNIT_FIELD_MINDAMAGE])+2;
	SetUInt32Value(UNIT_DYNAMIC_FLAGS, data32[UNIT_DYNAMIC_FLAGS] & ~(UNIT_DYNFLAG_LOOTABLE | UNIT_DYNFLAG_DEAD));
	SetUInt32Value(UNIT_FIELD_FLAGS,data32[UNIT_FIELD_FLAGS] & ~U_FIELD_FLAG_DEAD);
	SetUInt64Value(UNIT_FIELD_TARGET,0);
	//spirithealers are spawned manualy
	if((data32[UNIT_FIELD_FLAGS] & UNIT_FLAG_SPIRITHEALER)!=UNIT_FLAG_SPIRITHEALER)
	{
		//change it's location in mapmanager
//		G_maps[map_id]->change_location(this,dst_x,dst_x,0);
	    //add to mapmanager
		G_maps[map_id]->add_creature(this);
		//show creature to others
		G_maps[map_id]->on_creature_entered_block(this);
	}
#ifdef USE_OBJECT_INTERRUPTS
	On_Creature_respawn(this);
#endif
}

//creature createblock may be ucreated more then once per turn. Maybe we should cahce it
void creature::build_create_block(Compressed_Update_Block *packet,uint32 target_self)
{
	if((state1 & CREATURE_STATE_DEAD) && (state1 & CREATURE_STATE_RESPAWN))
		return;
	uint8 *data=packet->get_next_pointer();
	float *packetf;
	uint32 *packet32;
	uint32 i;
    data[0]=UPDATETYPE_CREATE_OBJECT; //type of the block
    data[1]=0xFF; //guid mask
	*(uint32*)(data+2)=getGUIDL();
	*(uint32*)(data+6)=getGUIDH();
	data[10]=TYPEID_UNIT; 
	data[11]=0x70; //flags1
	packetf=(float*)&data[12];
	packet32=(uint32*)&data[12];
	packet32[0]=0x0000; //flags2
	packet32[1]=G_cur_time_ms; //time
	packetf[2]=pos_x; 
	packetf[3]=pos_y; 
	packetf[4]=pos_z; 
	packetf[5]=orientation; 
	packetf[6]=0; 
	packetf[7]=UNIT_NORMAL_WALK_SPEED*speed_land_modifyer;
	packetf[8]=UNIT_NORMAL_RUN_SPEED*speed_land_modifyer;
	packetf[9]=UNIT_NORMAL_WALK_BACK_SPEED*speed_land_modifyer;
	packetf[10]=UNIT_NORMAL_SWIM_SPEED*speed_land_modifyer;
	packetf[11]=UNIT_NORMAL_SWIM_BACK_SPEED*speed_land_modifyer;
    packetf[12]=speed_land_modifyer*UNIT_NORMAL_FLY_SPEED;
    packetf[13]=speed_land_modifyer*UNIT_NORMAL_FLY_BACK_SPEED;
	packetf[14]=UNIT_NORMAL_TURN_SPEED*speed_land_modifyer;
	packet32[15]=0; //1 = active player, 0 else
	update_mask.Clear();
	//set bits and add values to packet
	data[76]=(uint8)update_mask.GetBlockCount();
	uint32 len,pos;
	len = 77 + update_mask.GetBlockCount()*4;
	packet32 = (uint32*)&data[len];
	pos = 0;
	for( i=0; i<UNIT_END; i++)
		if(data32[i]!=0)
		{
			update_mask.SetBit(i);
			packet32[pos++] = data32[i];
		}
	//add bitmask to packet
	memcpy(&data[77],update_mask.GetMask(),update_mask.GetBlockCount()*4);
	packet->add_virtual_packet(len+pos*4);
	update_mask.Clear();
}

//creatures create on;y once per turn their updatepacket and send it to whole block. No need to cache it
void creature::build_update_block(Compressed_Update_Block *packet,uint32 target_self,uint8 clear_mask)
{
	if((state1 & CREATURE_STATE_DEAD) && (state1 & CREATURE_STATE_RESPAWN)) // do not send update block times  per turn = crash client 
		return;
	uint8 *data=packet->get_next_pointer();
	if(update_mask.IsEmpty())return;
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
	for( i=0; i<UNIT_END; i++)
		if(update_mask.GetBit(i))
			packet32[pos++] = data32[i];
	//add bitmask to packet
	memcpy(&data[11],update_mask.GetMask(),update_mask.GetBlockCount()*4);
	packet->add_virtual_packet(len+pos*4);
	if(clear_mask) update_mask.Clear();
}

void creature::mark_creature_on_minimap(GameClient *pClient,uint8 is_visible)
{
	G_temp_compressed_packet.clear();
	//set guid
	*(uint64*)(&G_questgiver_minimap_show_prepared_packet[1])=*(uint64*)data32;
	//set visibility
	if(is_visible)	*(uint32*)&G_questgiver_minimap_show_prepared_packet[G_questgiver_minimap_show_prepared_packet_len-4] = data32[UNIT_DYNAMIC_FLAGS] | UNIT_DYNFLAG_TRACK_UNIT ;
	else *(uint32*)&G_questgiver_minimap_show_prepared_packet[G_questgiver_minimap_show_prepared_packet_len-4] = data32[UNIT_DYNAMIC_FLAGS] & ~UNIT_DYNFLAG_TRACK_UNIT ;
	//add it to char compresed update block
	G_temp_compressed_packet.add_raw_info_as_block(G_questgiver_minimap_show_prepared_packet,G_questgiver_minimap_show_prepared_packet_len);
	pClient->SendMsg(G_temp_compressed_packet.build_packet());
}

void creature::update()
{
#ifdef DEBUG_CREATURE_VERSION
	uint32 start_time,end_time;
	start_time = GetMilliseconds();
#endif
#ifdef VERSION_CHAR_MAKE_CREAUTURE_WPOINTS
	return; //no creature actions while we are trying to make waypoints
#endif
	uint32	time_diff;
	uint64	prev_state;
	if(last_update==G_cur_time_ms)
		return; //there is a slight chance that creatures will get updated twice a turn :(
	time_diff = G_cur_time_ms - last_update;
	prev_state = state1;
	//this loop will try to recover lost time while creature was in sleep mode(like respawn)
	//be carefull not to make infinit loops here
	while(G_cur_time_ms>atimer1 && (state1 & CREATURE_STATE_DEAD))
	{
		if((state1 & CREATURE_STATE_LOOTABLE))
		{
			atimer1+=CREATURE_SKELET_DELAY;
			SetUInt32Value(UNIT_DYNAMIC_FLAGS, 0); //sparkle tootable creature
			state1 &=~CREATURE_STATE_LOOTABLE; //remove flag
			state1 |=CREATURE_STATE_SKELETON;//set flag
			//!!!should set some flag to show only skeleton for the creature
		}
		else if((state1 & CREATURE_STATE_SKELETON))
		{
			atimer1 += respawn_delay + G_random.mt_random()%respawn_delay;
			state1 &=~CREATURE_STATE_SKELETON; //remove flag
			state1 |=CREATURE_STATE_RESPAWN;//set flag
			//remove creature from world
		    G_send_packet.opcode = SMSG_DESTROY_OBJECT;
			G_send_packet.data32[0] = getGUIDL();
			G_send_packet.data32[1] = getGUIDH();
			G_send_packet.length = 8;
			G_maps[map_id]->send_instant_msg_to_block(pos_x,pos_y,&G_send_packet,NULL);
		}
		else if((state1 & CREATURE_STATE_RESPAWN))
		{
			atimer1 = G_cur_time_ms; //exit asinc timer loop
			respawn();
		}
	}
	//no need to continue if we are dead
	if((state1 & CREATURE_STATE_DEAD))
		return;
	else if(state1 & UNIT_STATE_CONFUSED)
	{
		orientation = orientation + CONFUSED_UNIT_SPIN_SPEED;
		if(orientation>6.14f)
			orientation -= 6.14f;
		update_obj_pos(NULL);
		atimer1 = G_cur_time_ms;
	}
	//next part is not important so we do not require to recover lost time (asinc timeline)
	else if(G_cur_time_ms>atimer1 && !(state1 & UNIT_STATE_STUN))
	{
//		if((state1 & (CREATURE_STATE_ROAMING | CREATURE_STATE_IN_COMBAT)))
//		if(state1 & UNIT_STATE_FLEE) //!!!before updating affect!
//			state1 &= ~(CREATURE_STATE_IN_COMBAT | CREATURE_STATE_ATACK);//make him target char again
		//spell casting is prior to moving
		if((state1 & (CREATURE_STATE_PREPARE_CAST)))
		{
			state1 &= ~CREATURE_STATE_PREPARE_CAST;
			state1 |= CREATURE_STATE_CAST;
			atimer1 = G_cur_time_ms + G_spell_info[casting_spell_id]->cast_time;
			G_instant_spell_instance.cr_instant_cast(this,casting_spell_id,suggested_spell_target);
		}
		else if((state1 & (CREATURE_STATE_CAST)))
		{
			state1 &= ~CREATURE_STATE_CAST;
			//if we were moving then we should continue our path
			if(((state1 & (CREATURE_STATE_ROAMING | CREATURE_STATE_PATROL_MOVE | CREATURE_STATE_RETURN_TO_LAST_POS | CREATURE_STATE_FOLLOW))) && time_diff <= time_remain && prev_state==state1 && !(state1 & (CREATURE_STATE_VENDOR_SELL | CREATURE_STATE_PAUSE_MOVEMENT | UNIT_STATE_CONFUSED | CREATURE_STATE_CAST | CREATURE_STATE_PREPARE_CAST)))
				move_creature(waypoint_lst.cur_dst->dst_x,waypoint_lst.cur_dst->dst_y,waypoint_lst.cur_dst->dst_z,0,0);
			else atimer1 = G_cur_time_ms;
		}
		else if((state1 & (CREATURE_STATE_ROAMING)))
		{
//printf("arrived at roaming destination, should start atacking\n");
			//we arived to roaming location
			float old_x,old_y;
			old_x = pos_x;
			old_y = pos_y;
			pos_x = dst_x;
			pos_y = dst_y;
			pos_z = dst_z;
			state1 &=~CREATURE_STATE_ROAMING; //remove flag
			state1 |=CREATURE_STATE_ATACK;//set flag
			//set atack timer
//			atimer1= G_cur_time_ms + (uint32)(data32[UNIT_FIELD_BASEATTACKTIME]*speed_attack_modifyer);
			atimer1= G_cur_time_ms;
			orientation = get_orientation(pos_x,pos_y,agro_list.max_value->owner->pos_x,agro_list.max_value->owner->pos_y);
//			update_obj_pos(NULL);
			//also on map we should correct his position
			G_maps[map_id]->change_location(this,old_x,old_y);
		}
//		else if((state1 & (CREATURE_STATE_ATACK | CREATURE_STATE_IN_COMBAT)))
		if((state1 & (CREATURE_STATE_ATACK )))
		{
//printf("swinging atack\n");
			if(!target)
			{
				state1 &= ~(CREATURE_STATE_ROAMING | CREATURE_STATE_ATACK | CREATURE_STATE_IN_COMBAT);//set flag
				state1 |= CREATURE_STATE_RETURN_TO_LAST_POS;//set flag
				SetUInt32Value(UNIT_FIELD_FLAGS,data32[UNIT_FIELD_FLAGS] & ~(U_FIELD_FLAG_ATTACK_ANIMATION | UNIT_FLAG_IN_COMBAT));
				move_creature(waypoint_lst.cur_dst->dst_x,waypoint_lst.cur_dst->dst_y,waypoint_lst.cur_dst->dst_z,1,0);
				return;
			}
			else on_atack_swing();
		}
		else if((state1 & CREATURE_STATE_RETURN_TO_LAST_POS))
		{
			state1 &=~(CREATURE_STATE_RETURN_TO_LAST_POS | CREATURE_STATE_IN_COMBAT); //remove flag
			state1 |= (CREATURE_STATE_PATROLLING | CREATURE_STATE_PATROL_WAIT);	//set flag
			atimer1 = G_cur_time_ms + 1000;
			//update it's position for mapmanager
			float old_x,old_y;
			old_x = pos_x;
			old_y = pos_y;
			pos_x = dst_x;
			pos_y = dst_y;
			pos_z = dst_z;
			G_maps[map_id]->change_location(this,old_x,old_y);
			SetUInt32Value(UNIT_FIELD_FLAGS,data32[UNIT_FIELD_FLAGS] & ~UNIT_FLAGS_RETURN_HOME);
		}
		else if((flags1 & CREATURE_FLAG_STAND) || (state1 & CREATURE_STATE_PAUSE_MOVEMENT))
		{} //no action required = just stand there
		else if(state1 & CREATURE_STATE_VENDOR_SELL)
		{
//printf("checking if vendor is still near char\n");
			//check if player is at a specific distance
			if(last_atacker_guid)
			{
				float dist_x = abs(((Character*)last_atacker_guid)->pos_x - pos_x);
				float dist_y = abs(((Character*)last_atacker_guid)->pos_y - pos_y);
				if(dist_x>CREATURE_DIST_UNTIL_TRAVERMERCHANT_WAIT || dist_y>CREATURE_DIST_UNTIL_TRAVERMERCHANT_WAIT)
				{
//printf("distance is larger then talking distance %f\n",dist);
					state1 &= ~CREATURE_STATE_VENDOR_SELL;
					if(state1 && CREATURE_STATE_PATROL_MOVE)
						goto CREATURE_CONTINUE_MOVING_TO_NEXT_PATROL_POINT;
				}
			}
			//this shouldn't occure at all
			else 
			{
				state1 &= ~CREATURE_STATE_VENDOR_SELL;
				goto CREATURE_CONTINUE_MOVING_TO_NEXT_PATROL_POINT;
			}
			//we still wait for char to make up his mind
			atimer1 = G_cur_time_ms + WORLD_MIN_UPDATE_INTERVAL*2;
		}
		else if((state1 & (CREATURE_STATE_FOLLOW)) && folowed_char!=NULL)
		{
			float dist_x = abs(folowed_char->pos_x - pos_x);
			float dist_y = abs(folowed_char->pos_y - pos_y);
			if(dist_x>CREATURE_DIST_UNTIL_FOLOWER_WAIT || dist_y>CREATURE_DIST_UNTIL_FOLOWER_WAIT)
			{
//printf("refreshing folowers, dstx=%f /y=%f\n",dist_x,dist_y);
				folowed_char->get_folower_next_coords(this);
				move_creature(dst_x,dst_y,dst_z,0,0,1);
			}
			else atimer1 = G_cur_time_ms + WORLD_MIN_UPDATE_INTERVAL*2;			
		}
		else if(state1 & (CREATURE_STATE_PATROL_MOVE))
		{
			//adjust timer to count ms for waiting at this waypoint
			pos_x = dst_x;
			pos_y = dst_y;
			pos_z = dst_z;
			if(flags1 & CREATURE_FLAG_WAYPOINT_WALKER)
			{
				orientation = waypoint_lst.cur_dst->dst_o;
//				update_obj_pos(NULL);
				if(waypoint_lst.cur_dst->dst_time_wait==0)
					goto CREATURE_MOVE_TO_NEXT_PATROL_POINT;
			}
			atimer1=G_cur_time_ms + waypoint_lst.cur_dst->dst_time_wait; 
			state1 &=~CREATURE_STATE_PATROL_MOVE; //remove flag
			state1 |=CREATURE_STATE_PATROL_WAIT;//set flag
		}
		else if(state1 & (CREATURE_STATE_PATROL_WAIT))
		{
CREATURE_MOVE_TO_NEXT_PATROL_POINT:
			waypoint_lst.get_next_waypoint();
CREATURE_CONTINUE_MOVING_TO_NEXT_PATROL_POINT:
			if(waypoint_lst.cur_dst->speed_coef<=1)
				move_creature(waypoint_lst.cur_dst->dst_x,waypoint_lst.cur_dst->dst_y,waypoint_lst.cur_dst->dst_z,0,0);
			else if(waypoint_lst.cur_dst->speed_coef<3)
				move_creature(waypoint_lst.cur_dst->dst_x,waypoint_lst.cur_dst->dst_y,waypoint_lst.cur_dst->dst_z,1,0,waypoint_lst.cur_dst->speed_coef);
			else move_creature(waypoint_lst.cur_dst->dst_x,waypoint_lst.cur_dst->dst_y,waypoint_lst.cur_dst->dst_z,1,1);
			state1 &=~CREATURE_STATE_PATROL_WAIT; //remove flag
			state1 |=CREATURE_STATE_PATROL_MOVE;//set flag
		}
	}
	//dinamicaly spawned creatures (like totems) dissapear after a while
	if((state1 & CREATURE_STATE_DIE_ON_TIMER) && atimer2<=G_cur_time_ms)
	{	
		G_maps[map_id]->on_creature_exited_block(this);
		G_maps[map_id]->del_creature(this);
		affect_list->clear();
		agro_list.clear();
		atimer1 = G_cur_time_ms + respawn_delay; //probably will never occur
		state1 |= CREATURE_STATE_DEAD;
		return;
	}
	//update position
	//!!!sometimes creatures may be put on pause while moving and resumed later. In this case time_diff is very large!!
	//!!! position tracking is not acurate
	if(((state1 & (CREATURE_STATE_ROAMING | CREATURE_STATE_PATROL_MOVE | CREATURE_STATE_RETURN_TO_LAST_POS | CREATURE_STATE_FOLLOW))) && time_diff <= time_remain && prev_state==state1 && !(state1 & (CREATURE_STATE_VENDOR_SELL | CREATURE_STATE_PAUSE_MOVEMENT | UNIT_STATE_CONFUSED | CREATURE_STATE_CAST | CREATURE_STATE_PREPARE_CAST | UNIT_STATE_STUN)))
	{
		float old_x,old_y;
		old_x=pos_x;
		old_y=pos_y;
		pos_x += time_diff*adv_x;
		pos_y += time_diff*adv_y;
		pos_z += time_diff*adv_z;
		time_remain -= time_diff;
		//also on map we should correct his position
		G_maps[map_id]->change_location(this,old_x,old_y);
	}
	else 
	{
		if(spell_cooldown_atimer<G_cur_time_ms)
		{
			if(WORLDSERVER.debug_guid==getGUID())
				printf("creature will try to cast a spell when waiting\n");
			AI_general_caster(CREATURE_CAST_FLAG_CAST_ON_WAIT); //probably will be used only by support creatures
		}
	}
//if(WORLDSERVER.debug_guid==getGUID())
//	printf("creature is a caster %u and creature has some basic spells %u\n",(flags1 & CREATURE_FLAG_CASTER),static_data->spell_book.first);
	//send out our agro to enemys
	if(agro_sent_time < G_cur_time_ms)
	{
//printf("sending out agro with threat : %u\n",threat_generated);
		agro_sent_time = G_cur_time_ms + WORLD_MIN_UPDATE_INTERVAL*CREATURE_AGRO_SEND_TIME_INTERVAL;
		G_maps[map_id]->agro_block(this);
		if(threat_generated>UNITS_BASE_THREAT_GENERATE)
			threat_generated--;//threat decreases in time
	}
	affect_list->update();
	agro_list.update(); //will do all initis and deinits for creature to start atacking or return home
#ifdef SERVER_DOTA_COMPILATION
	G_maps[map_id]->creature_send_out_agro(this);//agro enemy creatures in neighbourhood
#endif
	if(!(state1 & CREATURE_STATE_IN_COMBAT))
	{
		health += (health_regen+health_regen_spell)*time_diff;
		power += (power_regen+power_regen_spell)*time_diff;
	}
	else
	{
		health += (health_regen*0.25f+health_regen_spell)*time_diff;
		power += (power_regen*0.25f+power_regen_spell)*time_diff;
	}
	if(health>(float)data32[UNIT_FIELD_MAXHEALTH])health=(float)data32[UNIT_FIELD_MAXHEALTH];
	else if(health<1) die();
	if(power>(float)data32[UNIT_FIELD_BASE_MANA])power=(float)data32[UNIT_FIELD_BASE_MANA];
	if(sell_item_list)
		sell_item_list->update();
	SetUInt32Value(UNIT_FIELD_HEALTH,(uint32)health);
	SetUInt32Value(UNIT_FIELD_POWER1,(uint32)power);
	last_update = G_cur_time_ms;
#ifdef DEBUG_CREATURE_VERSION
	end_time = GetMilliseconds();
	if(end_time-start_time>0)
		LOG.outString ("Debugger: requred time = %u ms to update 1 creature",end_time-start_time);
#endif
}

inline float creature::get_dmg(uint8 type)
{
	if(type==dmg_type)
		return (float)(dataf[UNIT_FIELD_MINDAMAGE] + G_random.mt_random() % dmg_diff);
	return 0;
}

void creature::on_atack_swing()
{
	//reset timer whatever the result is
//	atimer1 = G_cur_time_ms + (uint32)(data32[UNIT_FIELD_BASEATTACKTIME]*speed_attack_modifyer);
	if(spell_cooldown_atimer<G_cur_time_ms)
		AI_general_caster(CREATURE_CAST_FLAG_CAST_ON_ATTACK);
	atimer1 += (uint32)(data32[UNIT_FIELD_BASEATTACKTIME]*speed_attack_modifyer);
	//what are we trying to hit ? If it's a creature then we have to agro him
	float total_dmg=0,total_blocked=0;
	//check if victim dodged or blocked attack
	uint32	round_duration=1;
	if(pacified_count)
		return;
	if(target->will_dodge_atack())
	{
		total_dmg = 1;
		total_blocked = 1;
		round_duration = 2;
		target->emote(EMOTE_ONESHOT_PARRYUNARMED);
	}
	else if(target->will_block_atack())
	{
		total_dmg = 1;
		total_blocked = 1;
		round_duration = 5;
		target->emote(EMOTE_ONESHOT_PARRYUNARMED);
	}
	else if(target->will_parry_atack())
	{
		total_dmg = 1;
		total_blocked = 1;
		round_duration = 3;
		target->emote(EMOTE_ONESHOT_PARRYUNARMED);
	}
	else
	{
		//aply each type of dmg to creature
//		for(int i=0;i<CREATURE_USED_DMG_TYPES;i++)
		{
//			float dmg_start = get_dmg(i);
			float dmg_start = dataf[UNIT_FIELD_MINDAMAGE] + G_random.mt_random() % dmg_diff;
//printf("creature is trying to make some dmg %f min dmg %f, dmg diff %d, type %d\n",dmg_start,dataf[UNIT_FIELD_MINDAMAGE],dmg_diff,dmg_type);
//			if(dmg_start)
			{
//				float dmg_remain = agro_list.max_value->owner->take_dmg(dmg_start,getGUID(),i,0,data32[UNIT_FIELD_LEVEL]);
				float dmg_remain = target->take_dmg(dmg_start,getGUID(),dmg_type,0,data32[UNIT_FIELD_LEVEL]);
				total_dmg += dmg_remain;
				total_blocked +=dmg_start - dmg_remain;
			}
		}
	}
	//if we have data to be sent then assamble the packet and send it
//	if(total_dmg)
	{
		G_send_packet.opcode = SMSG_ATTACKERSTATEUPDATE;
		G_send_packet.data32[0] = 0x000002;
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
		*(uint32*)(G_send_packet.data + 47) = round_duration;   //round duration
		*(uint32*)(G_send_packet.data + 51) = 0;   // additional spell damage amount
		*(uint32*)(G_send_packet.data + 55) = 0;   // additional spell damage id
		*(uint32*)(G_send_packet.data + 59) = 0;   // Damage amount blocked
		G_send_packet.length = 63;
		G_maps[map_id]->send_instant_msg_to_block(pos_x,pos_y,&G_send_packet,NULL);
//		pClient->SendMsg(&G_send_packet);
	}
	//there is a veeery small chance that creature has such a thing
	on_hit_spells->trigger_event_spells_cr(target->getGUID());
	if(state1 & UNIT_STATE_STEALTHED)
		affect_list->remove_stealth();
}

void creature::die()
{
	//stop him moving while dead
	update_obj_pos(NULL);
//	SetUInt32Value(UNIT_FIELD_FLAGS,data32[UNIT_FIELD_FLAGS] | U_FIELD_FLAG_DEAD);
	SetUInt32Value(UNIT_FIELD_FLAGS,data32[UNIT_FIELD_FLAGS]);
	SetUInt64Value(UNIT_FIELD_TARGET,0);
//	SetUInt32Value(UNIT_DYNAMIC_FLAGS, data32[UNIT_DYNAMIC_FLAGS] | UNIT_DYNFLAG_LOOTABLE | UNIT_DYNFLAG_DEAD); //sparkle tootable creature
	SetUInt32Value(UNIT_DYNAMIC_FLAGS, data32[UNIT_DYNAMIC_FLAGS] | UNIT_DYNFLAG_LOOTABLE); //sparkle tootable creature
   //remove flags and add new 
//   state1 &= ~(CREATURE_STATE_IN_COMBAT | CREATURE_STATE_ROAMING | CREATURE_STATE_PATROL_MOVE | CREATURE_STATE_RETURN_TO_LAST_POS | CREATURE_STATE_PATROL_WAIT | CREATURE_STATE_PATROLLING | CREATURE_STATE_ATACK);//set flag
//   state1 |= CREATURE_STATE_DEAD | CREATURE_STATE_LOOTABLE;//set flag
   state1 = CREATURE_STATE_DEAD | CREATURE_STATE_LOOTABLE;//set flag
   atimer1 = G_cur_time_ms + CREATURE_CORPSE_DELAY;
   //give xp to killer group
   //if it was a pet then give xp to his master
   if((uint32)(last_atacker_guid >> 32) & HIGHGUID_PLAYER)
   {
	   Character *atacker_char = (Character *)last_atacker_guid;
	   if(atacker_char)
	   {
		   figh_points = (uint32)(((float)data32[UNIT_FIELD_LEVEL] / atacker_char->data32[UNIT_FIELD_LEVEL])*(dmg_taken+dmg_done));
		   if(figh_points > atacker_char->data32[PLAYER_XP])
			   figh_points = atacker_char->data32[PLAYER_XP];//just in case some bug occures
		   atacker_char->xp_modify(getGUID(),figh_points,0);
		   atacker_char->quests_started.on_kill(data32[OBJECT_FIELD_ENTRY],getGUID());
		   atacker_char->try_force_exit_combat();
	   }
   }
   affect_list->clear();
   agro_list.clear();
   generate_loot();
}

void creature::move_creature(float pdst_x,float pdst_y,float pdst_z,int run,int instant_move,float speed_coef)
{
	state1 |= CREATURE_STATE_MOVED_SINCE_SYNC;
	//set our destination so we can set our pos when we arived
	dst_x = pdst_x;
	dst_y = pdst_y;
	dst_z = pdst_z;
	float dist_x,dist_y,dist_z,dist;
	dist_x = pdst_x - pos_x;
	dist_y = pdst_y - pos_y;
	dist_z = pdst_z - pos_z;
	dist = sqrt(dist_x*dist_x + dist_y*dist_y + dist_z*dist_z);
	float t_time_remain;
//if(WORLDSERVER.debug_guid==getGUID())
//printf("dist %f,speed_land_modifyer %f,UNIT_NORMAL_RUN_SPEED %f,speed_coef %f \n",dist,speed_land_modifyer,UNIT_NORMAL_RUN_SPEED,speed_coef);
	if(run)	t_time_remain = ((dist*1000)/((speed_land_modifyer*UNIT_NORMAL_RUN_SPEED)*speed_coef));
	else t_time_remain = ((dist*1000)/((speed_land_modifyer*UNIT_NORMAL_WALK_SPEED)*speed_coef));
	t_time_remain += 0.001f;//speed corection or jus tmake sure no division by 0 occures :)
//	if(t_time_remain==0) t_time_remain = 1;
	time_remain = (uint32)t_time_remain;
	adv_x = dist_x / t_time_remain; //each ms we have to advance amount on this 
	adv_y = dist_y / t_time_remain; 
	adv_z = dist_z / t_time_remain; 
	atimer1 = G_cur_time_ms + time_remain;
	if(instant_move)msg_move_creauture(pdst_x,pdst_y,pdst_z,0,run);
	else msg_move_creauture(pdst_x,pdst_y,pdst_z,time_remain,run);
//if(WORLDSERVER.debug_guid==getGUID())
//printf("pos_x %f, pos_y %f, dest_x %f, dest_y %f dist %f, time_remain %d\n",pos_x, pos_y,pdst_x,pdst_y,dist,time_remain);
//if(abs(adv_x)>speed*UNIT_NORMAL_RUN_SPEED || abs(adv_y)>speed*UNIT_NORMAL_RUN_SPEED)
//printf("some fuckedup values again : %f,%f\n",adv_x,adv_y);
//if(WORLDSERVER.debug_guid==getGUID())
//printf("adv_x %f , adv_y %f, dist_x %f, dist_y %f, time_remain %d\n",adv_x,adv_y,dist_x,dist_y,time_remain);
//if(pos_x<-10000 || pos_x>-8000 || pos_y<-300 || pos_y>200)
//printf("move creature position is fucked up ? [%f,%f] %d\n",pos_x,pos_y,(uint32)this);
//if(pdst_x<-10000 || pdst_x>-8000 || pdst_y<-300 || pdst_y>200)
//printf("move creature destination position is fucked up ? [%f,%f] %d\n",pdst_x,pdst_y,(uint32)this);
}

float creature::take_dmg(float pdmg,uint64 atacker_GUID,uint8 ptype,uint8 unblockable,uint32 atacker_level)
{
//	after_atack_state = 1; //used for combat log i guess
	//add atacker to agro list
	if(atacker_GUID)
	{
//		agro_list.add(atacker_GUID,pdmg*((Base_Unit_Object*)atacker_GUID)->threat_generate_mod);
		agro_list.add(atacker_GUID,pdmg);
		//there is a veeery small chance that creature has such a thing
		on_hit_spells->trigger_event_spells_cr(atacker_GUID);
	}
	if(affect_list->first)
		affect_list->on_game_interrupt(SPELL_AURA_INTERRUPT_FLAGS_TYPE_STRUCK);
	//remamber who killed us to give him xp
	last_atacker_guid = atacker_GUID;
	//info to be able to calc how much xp we are going to give to atacker
	dmg_taken += pdmg;
	//calc dmg reduction. 
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
			//damage_reduction = data32[UNIT_FIELD_RESISTANCES+type] / ((85.0 * atacker_level) + data32[UNIT_FIELD_RESISTANCES+type] + 400.0)
			damage_reduction = (20/level_diff) * (data32[UNIT_FIELD_RESISTANCES+ptype] * 0.0002f) * dmg_remain;
		}
		else damage_reduction = (data32[UNIT_FIELD_RESISTANCES+ptype] * 0.0002f)*dmg_remain; //presume we are at equal level
//		if(type==dmg_abs_type) damage_reduction += dmg_abs_min + (G_random.mt_random() % (uint32)dmg_abs_dif);
		dmg_remain = dmg_remain - damage_reduction;
		if(dmg_remain<0 || dmg_remain>dmg_remain)
			dmg_remain = MINIMAL_DAMAGE_APPLYABLE;
	}
	//see chances to dodge parry or miss
	//aply remaining dmg
	health -= dmg_remain;
	//if we are casting then delay casting
	return dmg_remain;
}

void creature::generate_loot()
{
	uint32	templ_itr;
	uint32	used_random_items;
	uint32	loot_count=0;
	uint32	i;
	uint32	loot_template_id=static_data->loot_template_id;
	loot_money = (uint32)(figh_points*money_coef);
//printf("started generating loot fopr creature %u with template %u\n",data32[OBJECT_FIELD_ENTRY],loot_template_id);
	if(state1 & CREATURE_STATE_HAS_LOOT_GENERATED)
		return;
	state1 |= CREATURE_STATE_HAS_LOOT_GENERATED;
//printf("creature has no loot generated yet\n");
	if(loot_template_id==0)//on laod this is set to 0 in case no loot is available
		goto NO_CREATURE_STATIC_LOOT_AVAILABLE;
//printf("selecting loot from %u items\n",data32[OBJECT_FIELD_ENTRY],G_static_loot_templates[loot_template_id]->len);
	templ_itr = G_static_loot_templates[loot_template_id]->len-1;
	used_random_items =0 ;
	//delete previusly not looted random loots
	for(i=0;i<MAX_RANDOM_LOOTS_FOR_OBJECT;i++)
		if(loots[i]!=NULL)
			G_Object_Pool.Release_item(loots[i]);
	while(templ_itr)
	{
		uint32 cur_item_id=G_static_loot_templates[loot_template_id]->node_list[templ_itr].item_id;
		if(G_random.mt_random() % 100 < G_static_loot_templates[loot_template_id]->node_list[templ_itr].chance)
		{
			if(((G_random.mt_random() % 100)< CREATURE_CHANCE_TO_RANDOMIZE_LOOT) && used_random_items<MAX_RANDOM_LOOTS_FOR_OBJECT && figh_points>data32[UNIT_FIELD_MAXHEALTH]*used_random_items)
			{
	//printf("selected item %u with id %u to be randomized\n",templ_itr,G_static_loot_templates[loot_template_id]->node_list[templ_itr].item_id);
				//check if we could randomize this item (there are some mods available for it)
				uint32 cur_class = G_item_prototypes[cur_item_id]->item_data32[ITEM_CLASS];
				uint32 cur_subclass = G_item_prototypes[cur_item_id]->item_data32[ITEM_SUBCLASS];
				if(G_max_item_mods_sorted[cur_class][cur_subclass] && G_item_mods_sorted[cur_class][cur_subclass][0]->use_cost<=figh_points)
				{
	//printf("selected item %u with id %u to be randomized\n",templ_itr,G_static_loot_templates[loot_template_id]->node_list[templ_itr].item_id);
					//we can create a new random item 
					//			random_loots[i] = new Item;
					loots[used_random_items] = G_Object_Pool.Get_fast_New_item();
					loots[used_random_items]->create_from_template(G_item_prototypes[cur_item_id]);
					loots[used_random_items]->randomise_me(figh_points);
					loot_item_count[used_random_items] = (uint8)(G_random.mt_random() % loots[used_random_items]->item_data32[ITEM_STACK_MAX])+1;
					used_random_items++;
					if((used_random_items+loot_count)==MAX_LOOTS_FOR_OBJECT)
						break;
				}
			}
			else
			{
//printf("selected item %u with id %u to be looted\n",templ_itr,G_static_loot_templates[loot_template_id]->node_list[templ_itr].item_id);
				//on looting the items will be duplicated
				loots[MAX_RANDOM_LOOTS_FOR_OBJECT+loot_count] = G_item_prototypes[cur_item_id];
				loot_item_count[MAX_RANDOM_LOOTS_FOR_OBJECT+loot_count] = (uint8)(G_random.mt_random() % loots[MAX_RANDOM_LOOTS_FOR_OBJECT+loot_count]->item_data32[ITEM_STACK_MAX])+1;
				loot_count++;
				if((used_random_items+loot_count)==MAX_LOOTS_FOR_OBJECT)
					break;
			}
		}
		templ_itr--;
	}
NO_CREATURE_STATIC_LOOT_AVAILABLE:
//printf("generated %u items to be looted for creature,%u random \n",loot_count,used_random_items);
	//if no static loot is available then we probably will just show some money to the client ;)
	return;
}

uint8 creature::is_still_lootable()
{
	uint8 ret=0;
	uint32 i;
	if(loot_money!=0)
	{
		ret = 1;
		goto IS_LOOTABLE_WE_KNOW_THE_RESULT;
	}
	for(i=0;i<MAX_RANDOM_LOOTS_FOR_OBJECT+MAX_STATIC_LOOTS_FOR_OBJECT;i++)
		if(loots[i]!=NULL)
		{
			ret = 1;
			goto IS_LOOTABLE_WE_KNOW_THE_RESULT;
		}

IS_LOOTABLE_WE_KNOW_THE_RESULT:
	//if it is not lootble anymore then we can clear lootable flag
	if(!ret)
		SetUInt32Value(UNIT_DYNAMIC_FLAGS, data32[UNIT_DYNAMIC_FLAGS] & ~UNIT_DYNFLAG_LOOTABLE); //sparkle tootable creature
	return ret;
}

void creature::msg_vendor_sell_list(GameClient *pClient)
{
	if(!sell_item_list)
		return;
	creature_sell_item_node *list_iter;
	uint32	data_shift;
	G_send_packet.opcode = SMSG_LIST_INVENTORY;
	G_send_packet.data32[0] = G_recv_packet.data32[0];
	G_send_packet.data32[1] = G_recv_packet.data32[1];
	G_send_packet.data[8] = 0; //itemcount
	data_shift = 9;
	list_iter = sell_item_list->first;
	while(list_iter)
	{
		if(list_iter->item_count>0)
		{
			Item *cur_item;
			if(list_iter->dinamic_item)
				cur_item = list_iter->dinamic_item;
			else cur_item = G_item_prototypes[list_iter->item_id];
			G_send_packet.data[8]++;
			*(uint32*)&G_send_packet.data[data_shift] = G_send_packet.data[8]; //index
			*(uint32*)&G_send_packet.data[data_shift+4] = cur_item->item_data32[ITEM_ID];
			*(uint32*)&G_send_packet.data[data_shift+8] = cur_item->item_data32[ITEM_DISPLAY_INFO_ID];
			*(uint32*)&G_send_packet.data[data_shift+12] = list_iter->item_count;
			*(uint32*)&G_send_packet.data[data_shift+16] = cur_item->item_data32[ITEM_PRICE_BUY];
			*(uint32*)&G_send_packet.data[data_shift+20] = 0xFFFFFFFF; //seems like item count too
			if(cur_item->item_data32[ITEM_STACK_MAX]==5)
				*(uint32*)&G_send_packet.data[data_shift+24] = 1;
			else if(cur_item->item_data32[ITEM_STACK_MAX]==20)
				*(uint32*)&G_send_packet.data[data_shift+24] = 5;
			else *(uint32*)&G_send_packet.data[data_shift+24] = cur_item->item_data32[ITEM_STACK_MAX];
			data_shift += 28;
		}
		list_iter = list_iter->next;
	}
	G_send_packet.length = data_shift;
	pClient->SendMsg(&G_send_packet);
}

void creature::msg_trainer_sell_list(GameClient *pClient)
{
	uint32 data_shift;
	if(!static_data->sell_spell_list.first)
		return;
	creature_sell_spell_node *itr=prototype->static_data->sell_spell_list.first;
	Character	*cc_char=pClient->mCurrentChar;
	G_send_packet.opcode = SMSG_TRAINER_LIST;
	G_send_packet.data32[0] = G_recv_packet.data32[0];
	G_send_packet.data32[1] = G_recv_packet.data32[1];
	G_send_packet.data32[2] = 0;
	G_send_packet.data32[3] = 0; //number of entrys in packet
	data_shift=16;
	while(itr)
	{
		uint32 has_req_spell,has_skill;
		if(itr->req_spell && !cc_char->spellbook.find(itr->req_spell)) has_req_spell = 0;
		else has_req_spell = 1;
		if(itr->req_skill && !cc_char->has_skill(itr->req_skill,itr->req_skill_lvl))has_skill = 0;
		else has_skill = 1;
		G_send_packet.data32[3]++;//count the number of inserted blocks
		*(uint32*)&G_send_packet.data[data_shift]=itr->cast_spell_id;
		//this is already bought by us
		if(cc_char->spellbook.find(itr->teach_spell_id))	*(uint8*)&G_send_packet.data[data_shift+4]=2;
		//show it in red
		else if(cc_char->data32[UNIT_FIELD_LEVEL] < itr->req_lvl || 
				cc_char->data32[PLAYER_FIELD_COINAGE] < itr->cost ||
				!has_req_spell || !has_skill)
			*(uint8*)&G_send_packet.data[data_shift+4]=1;
		else *(uint8*)&G_send_packet.data[data_shift+4]=0; //it's available
		*(uint32*)&G_send_packet.data[data_shift+5]=itr->cost;
		*(uint32*)&G_send_packet.data[data_shift+9]=0;//0
		*(uint32*)&G_send_packet.data[data_shift+13]=0;//0
		if(cc_char->data32[UNIT_FIELD_LEVEL] < itr->req_lvl) G_send_packet.data[data_shift+17]=itr->req_lvl;
		else G_send_packet.data[data_shift+17]=0;
		*(uint32*)&G_send_packet.data[data_shift+18]=0;
		*(uint32*)&G_send_packet.data[data_shift+22]=0;
		if(!has_req_spell)	*(uint32*)&G_send_packet.data[data_shift+26]=itr->req_spell; //req spell_id 1
		else *(uint32*)&G_send_packet.data[data_shift+26]=0; //req spell_id 1
		if(!has_skill)	*(uint32*)&G_send_packet.data[data_shift+30]=itr->req_skill; //req spell_id 2
		else *(uint32*)&G_send_packet.data[data_shift+30]=0; //req spell_id 2
		*(uint32*)&G_send_packet.data[data_shift+34]=0; //req spell_id 3
		data_shift +=38;
		itr = itr->next;
	}
	char *temp="Greetings $N, ready for some training ?";
	strcpy((char*)&G_send_packet.data[data_shift],temp);
	data_shift += strlen(temp)+1;
	G_send_packet.length = data_shift;
	pClient->SendMsg(&G_send_packet);
}

uint32 creature::quest_giver_status(Character *asker)
{
	//we test all sold spells to see if we have some that are not finished or started and available
	//we only search until we find a finished quest QMGR_QUEST_FINISHED
	if(!static_data->quests_list.first)
	{
#ifdef _DEBUG
		printf("reporting bad questgiver with id %u\n",data32[OBJECT_FIELD_ENTRY]);
#endif
		return QMGR_QUEST_NOT_AVAILABLE;
	}
	Quest_id_Node *itr=static_data->quests_list.first;
	uint32	best_state=0;
	while(itr)
	{
		//check if current quest state at char
		uint32 cur_state = asker->quest_relation(itr->value,this) & 0xF;//we might store internal states too in this 
//printf("checking quest id %u,state is %u\n",itr->value,cur_state);
		if(cur_state > best_state)
		{
			best_state = cur_state;
			if(best_state >= QMGR_QUEST_FINISHED)
				return best_state;
		}
		itr = itr->next;
	}
	//we return the best(biggest) result that we found
	return best_state;
}

//called by spell after setting the new speed for creature
void creature::on_change_speed()
{
	//if we were moving then we recalc the speed
	if(((state1 & (CREATURE_STATE_ROAMING | CREATURE_STATE_PATROL_MOVE | CREATURE_STATE_RETURN_TO_LAST_POS | CREATURE_STATE_FOLLOW))) && !(state1 & (CREATURE_STATE_VENDOR_SELL | CREATURE_STATE_PAUSE_MOVEMENT | UNIT_STATE_CONFUSED | UNIT_STATE_ROOTED)))
		move_creature(dst_x,dst_y,dst_z,0,0);
}

//used to make creature get away from a specific point. He will keep running for x ms
void creature::AI_flee_from_point(uint32 time)
{
	if(state1 & (UNIT_STATE_CONFUSED | UNIT_STATE_ROOTED | CREATURE_STATE_DEAD))
		return;
	//choose a target point to head to. and start moving unit to that point
	float dist=UNIT_NORMAL_RUN_SPEED*time/1000;
//	float direction = get_orientation(pos_x,pos_y,((creature*)this)->agro_list.max_value->owner->pos_x,((creature*)this)->agro_list.max_value->owner->pos_y);
	float direction = 6.14f - orientation;
	float dst_x = pos_x + sin(direction)*dist;
	float dst_y = pos_y + cos(direction)*dist;
	move_creature(dst_x,dst_y,pos_z,1,0);
	//set state so he won't be able to cast spells and stuff
	state1 |= UNIT_STATE_FLEE;
	atimer1 = G_cur_time_ms + time;
}

inline uint8 creature::close_enough_to_cast_spell(Base_Unit_Object *target,Spell_Info *sp)
{
	float dx=pos_x-target->pos_x;
	float dy=pos_y-target->pos_y;
	if(dx*dx+dy*dy<sp->range_max*sp->range_max)
		return 1;
	return 0;
}

void creature::AI_general_caster(uint32 event_type)
{
//	return;
	cr_spell_book_node *itr=static_data->spell_book.first;
	//pick a spell from spellbook.
PICK_ANOTHER_SPELL_FROM_SPELLBOOK:
#ifdef _DEBUG
//	if(itr!=static_data->spell_book.first)
//		printf("could not cast previous spell, trying another one\n");
//	if(WORLDSERVER.debug_guid==getGUID())
//		printf("debug creature will try to cast a spell\n");
#endif
	while(	itr && 
#ifdef _DEBUG
			G_spell_info[itr->spell_id]->power_cost>power && //no cost spells still can be casted
#endif
			(G_random.mt_random() % 100 > itr->chance_to_cast)//chance to cast this spell
		)
		itr = itr->next;
	if(!itr)
	{
		//let us not flood server trying to cast a spell
		spell_cooldown_atimer=G_cur_time_ms + CREATURE_MIN_WAIT_UNTIL_NEXT_CAST;
		return;
	}
//printf("%u)creature is trying to cast a spell, target flags are %u, spell id is %u\n",this,itr->flags,itr->spell_id);
	//we selected a spell that will be cast. Check if we have the target for it
	uint32	duration=G_spell_info[itr->spell_id]->duration[0];
	if(( itr->flags & CREATURE_CAST_PREFERED_TARGET_TYPE_TARGET) && agro_list.max_value)
	{
		if(!close_enough_to_cast_spell(agro_list.max_value->owner,G_spell_info[itr->spell_id]) ||
			agro_list.max_value->owner->has_active_spell(itr->spell_id)
			)
		{
			itr=itr->next;
			goto PICK_ANOTHER_SPELL_FROM_SPELLBOOK;
		}
		start_cast(itr->spell_id,duration==0,agro_list.max_value->owner->getGUID());
	}
	else if(( itr->flags & CREATURE_CAST_PREFERED_TARGET_TYPE_FRIEND) && folowed_char)
	{
		if(!close_enough_to_cast_spell(folowed_char,G_spell_info[itr->spell_id]) ||
			folowed_char->has_active_spell(itr->spell_id)
			)
		{
			itr=itr->next;
			goto PICK_ANOTHER_SPELL_FROM_SPELLBOOK;
		}
		start_cast(itr->spell_id,duration==0,folowed_char->getGUID());
	}
	else if( (itr->flags & CREATURE_CAST_PREFERED_TARGET_TYPE_SELF) &&
				!has_active_spell(itr->spell_id))
		start_cast(itr->spell_id,duration==0,getGUID());
	else if((itr->flags & (CREATURE_CAST_PREFERED_TARGET_TYPE_SELF | CREATURE_CAST_PREFERED_TARGET_TYPE_FRIEND | CREATURE_CAST_PREFERED_TARGET_TYPE_TARGET))==0)
		start_cast(itr->spell_id,duration==0,0);
	//we cannot cast this spell
	else
	{
		itr=itr->next;
		goto PICK_ANOTHER_SPELL_FROM_SPELLBOOK;
	}
//	uint32 wait_until_next_cast=duration + G_spell_info[itr->spell_id]->recovery_time;
//	if(wait_until_next_cast<CREATURE_MIN_WAIT_UNTIL_NEXT_CAST)
//		spell_cooldown_atimer=G_cur_time_ms + CREATURE_MIN_WAIT_UNTIL_NEXT_CAST;
//	else spell_cooldown_atimer = wait_until_next_cast + G_cur_time_ms;
	spell_cooldown_atimer=G_cur_time_ms + CREATURE_MIN_WAIT_UNTIL_NEXT_CAST; //wait fixed amount of time cause some auras have infinite duration 
}

//should take care of all preparetions in order so creture casts a spell
void creature::start_cast(uint32 spell_id,uint32 is_instant,uint64 suggest_target_guid)
{
//printf("!!!!!!!!!!!!!!!creature is casting a spell %u,is instant %u\n",spell_id,is_instant);
	//no action should be taken while we are returning home
//	if(state1 & CREATURE_STATE_RETURN_TO_LAST_POS)
//		return;
	//this might happen a lot like stun and other small spells
	if(is_instant)
	{
		G_instant_spell_instance.cr_instant_cast(this,spell_id,suggest_target_guid);
		return;
	}
	//in case we are moving, we stop, and set facign to target
//	face_target();
//	update_obj_pos(NULL);
	casting_spell_id = spell_id;
	state1 |= CREATURE_STATE_PREPARE_CAST;
	atimer1 = G_cur_time_ms + G_spell_info[spell_id]->cast_time;
	//start casting the spell
	suggested_spell_target = suggest_target_guid;
	G_instant_spell_instance.set_caster(getGUID(),data32[UNIT_FIELD_FACTIONTEMPLATE]);
	G_instant_spell_instance.init(spell_id,pos_x,pos_y,orientation,map_id);
	G_instant_spell_instance.msg_spell_start_cast();
}

inline void creature::face_target()
{
	if(agro_list.max_value)
		orientation = get_orientation(pos_x,pos_y,agro_list.max_value->owner->pos_x,agro_list.max_value->owner->pos_y);
}

//remove old unused agros
//find the most hated creature/char
//calc distance to see if we have to rush him
inline void Agro_List::update()
{
//	if((owner->state1 & (CREATURE_STATE_RETURN_TO_LAST_POS | CREATURE_STATE_ROAMING)))return; //this is a non breakable state. I know it's lame but creature was going forward and backward all the time
//	if((owner->state1 & (CREATURE_STATE_RETURN_TO_LAST_POS)) || first==NULL)return; //this is a non breakable state. I know it's lame but creature was going forward and backward all the time
//	if((owner->state1 & (CREATURE_STATE_RETURN_TO_LAST_POS)) || (first==NULL && max_value==NULL))return; //this is a non breakable state. I know it's lame but creature was going forward and backward all the time
	if((first==NULL && max_value==NULL) || (owner->state1 & (UNIT_STATE_CONFUSED | UNIT_STATE_FLEE)))return;
//if(WORLDSERVER.debug_guid==owner->getGUID())
//printf("debug creature has some agro to char\n");
	Agro_Node *kur = first, *prev_max_value;
	//don't fade agro while atacking
	if(!(owner->state1 & CREATURE_STATE_ATACK))
	{
		while(kur)
		{
			if(G_cur_time_ms - kur->received_stamp > CREATURE_AGRO_FADE_AWAY_TIME)
			{
				Agro_Node	*delme;
				delme = kur;
				if(delme==first)first=NULL;
				kur = kur->next;
				delete delme;
			}
			else kur = kur->next;
		}
	}
	//get the most hated target
	prev_max_value = max_value;
	float kur_max_value;
	if(max_value) kur_max_value = max_value->value;
	else kur_max_value = 0;
	max_value = NULL;
	kur=first;
	while(kur)
	{
		//choose this value only if we can rush him
		if(kur->value >= kur_max_value)
		{
			float dx1=abs(kur->owner->pos_x - owner->waypoint_lst.cur_dst->dst_x);
			float dy1=abs(kur->owner->pos_y - owner->waypoint_lst.cur_dst->dst_y);
			if(dx1 <= CREATURE_BOUND_RADIOUS && dy1 <= CREATURE_BOUND_RADIOUS)
			{
				if(kur->value == kur_max_value && max_value) //very rare case. Mostly when creatures are making the agro
				{
					float dx2=abs(max_value->owner->pos_x - owner->waypoint_lst.cur_dst->dst_x);
					float dy2=abs(max_value->owner->pos_y - owner->waypoint_lst.cur_dst->dst_y);
					if(dx1*dx1+dy1*dy1<dx2*dx2+dy2*dy2)
					{
						max_value = kur;
						kur_max_value = kur->value;
					}
				}
				else
				{
					max_value = kur;
					kur_max_value = kur->value;
				}
			}
		}
		kur = kur->next;
	}
	if(max_value)	owner->target = max_value->owner;
	else 
	{
		//we can clear the agro list because we are heading back home
		kur = first;
		while(kur)
		{
			Agro_Node	*delme;
			delme = kur;
			if(delme==first)first=NULL;
			kur = kur->next;
			delete delme;
		}
		owner->target = NULL;
	}
//if(WORLDSERVER.debug_guid==owner->getGUID() && max_value)
//printf("debug creature has targeted char\n");
	//if we have no more targets, but we had, then we can go home
	if(max_value==NULL && prev_max_value!=NULL)
	{
//if(WORLDSERVER.debug_guid==owner->getGUID())
//printf("going home\n");
		owner->state1 &= ~(CREATURE_STATE_ROAMING | CREATURE_STATE_ATACK | CREATURE_STATE_IN_COMBAT);//set flag
		owner->state1 |= CREATURE_STATE_RETURN_TO_LAST_POS;//set flag
		owner->SetUInt32Value(UNIT_FIELD_FLAGS,owner->data32[UNIT_FIELD_FLAGS] & ~U_FIELD_FLAG_ATTACK_ANIMATION);
		owner->SetUInt32Value(UNIT_FIELD_FLAGS,owner->data32[UNIT_FIELD_FLAGS] | UNIT_FLAGS_RETURN_HOME);
		owner->SetUInt64Value(UNIT_FIELD_TARGET,0);
		//walk back from where we started attacking
		owner->move_creature(owner->waypoint_lst.cur_dst->dst_x,owner->waypoint_lst.cur_dst->dst_y,owner->waypoint_lst.cur_dst->dst_z,1,0);
		return;
	}
	//if we can't reach any of our atackers then we exit function
	if(max_value==NULL && prev_max_value==NULL)
		return;
	//check distances
	float dist,dst_x,dst_y;
	dst_x = max_value->owner->pos_x - owner->pos_x;
	dst_y = max_value->owner->pos_y - owner->pos_y;
	dist = dst_x*dst_x + dst_y*dst_y;
	//if new target is further then we could reach then we have to move closer
	if(dist>CREATURE_ATACK_RANGE_SQ)
		if(!(owner->state1 & CREATURE_STATE_ROAMING) || abs(dst_x)>CREATURE_RECALIBRATE_RUSH_WHEN_TARGET_MOVES || abs(dst_y)>CREATURE_RECALIBRATE_RUSH_WHEN_TARGET_MOVES)
	{
		if(owner->spell_cooldown_atimer<G_cur_time_ms)
			owner->AI_general_caster(CREATURE_CAST_FLAG_CAST_ON_WAIT);
		owner->state1 &= ~(CREATURE_CAST_FLAG_CAST_ON_RUSH);//set flag
		owner->state1 |= CREATURE_STATE_ROAMING | CREATURE_STATE_IN_COMBAT;//set flag
		//calc rush positions. Do not complicate things => 4 cases
		float roam_x,roam_y,roam_z;
		if(max_value->owner->pos_x >= owner->pos_x)roam_x = max_value->owner->pos_x - 1;
		else if(max_value->owner->pos_x < owner->pos_x) roam_x = max_value->owner->pos_x + 1;
		if(max_value->owner->pos_y >= owner->pos_y)roam_y = max_value->owner->pos_y - 1;
		else if(max_value->owner->pos_y < owner->pos_y) roam_y = max_value->owner->pos_y + 1;
		roam_z = max_value->owner->pos_z+CREATURE_ROAM_LIFT_FROM_GROUND;
		owner->move_creature(roam_x,roam_y,roam_z,1,0);
		//yell a text
		if(max_value!=prev_max_value && owner->static_data->yell_list.first && (max_value->owner->obj_type & HIGHGUID_PLAYER))
			owner->static_data->yell_list.yell_to_target(owner,(Character*)max_value->owner,CREATURE_YELL_EVENT_TYPE_RUSH);
//if(WORLDSERVER.debug_guid==owner->getGUID())
//printf("going after target, distance %f, dx %f dy%f\n",dist,roam_x,roam_y);
	//			max_p_char->try_force_enter_combat(owner->getGUID());
		return;
	}
//else printf(" i have an agro target but already going forward him so i can't attack\n");
	//if we are atacking then there is nothing left to do for agro update
	if((owner->state1 & (CREATURE_STATE_ATACK | CREATURE_STATE_IN_COMBAT)))
		return;
	//if we are close enough but creture is patrolling then we should stop him
	if(owner->state1 & CREATURE_STATE_PATROL_MOVE)
	{
		owner->state1 &= ~CREATURE_STATE_PATROL_MOVE;
		owner->update_obj_pos(0);
	}
	//if we do not need to go home and we do not need to move closer then we can start atacking
//if(WORLDSERVER.debug_guid==owner->getGUID())
//printf("starting to attack\n");
	P_SMSG_AI_REACTION *TP=(P_SMSG_AI_REACTION *)G_send_packet.data;
	G_send_packet.opcode = SMSG_AI_REACTION;
	TP->guidl = owner->getGUIDL();
	TP->guidh = owner->getGUIDH();
	TP->reaction = 2;
	G_send_packet.length = sizeof(P_SMSG_AI_REACTION);
	G_maps[owner->map_id]->send_instant_msg_to_block(owner->pos_x,owner->pos_y,&G_send_packet,NULL);
	owner->state1 &= ~(CREATURE_STATE_ROAMING);//clr flag
	owner->state1 |= CREATURE_STATE_ATACK | CREATURE_STATE_IN_COMBAT;//set flag
	owner->SetUInt32Value(UNIT_FIELD_FLAGS,owner->data32[UNIT_FIELD_FLAGS] | U_FIELD_FLAG_ATTACK_ANIMATION | UNIT_FLAG_IN_COMBAT & ~UNIT_FLAGS_RETURN_HOME);//set combat flag for creature. I hope this will remove emotes while in combat
	max_value->owner->SetUInt64Value(UNIT_FIELD_TARGET,max_value->owner->getGUID());
	//set attack timer
//	owner->atimer1= G_cur_time_ms + (uint32)(owner->data32[UNIT_FIELD_BASEATTACKTIME]*owner->speed_attack_modifyer);
	owner->atimer1= G_cur_time_ms; //just trying to make him swing at first contact
	return;
}

void Agro_List::add(uint64 owner_GUID,float value)
{
#ifndef VERSION_CHAR_MAKE_CREAUTURE_WPOINTS //do not agro player while we generate z cords
//printf("adding new agro \n");
	if(owner_GUID==NULL || owner->state1 & CREATURE_STATE_RETURN_TO_LAST_POS || owner->health<1)
		return;
	//search if owner is already inserted
	Agro_Node *kur = first;
	Base_Unit_Object *the_owner=(Base_Unit_Object*)(owner_GUID);
	while(kur && kur->owner!=the_owner)
		kur = kur->next;
	//if we alredy have this player as agroed then we add value
	if(kur)
	{
		kur->value += value;
		kur->received_stamp = G_cur_time_ms;
	}
	else
	{
		Agro_Node *new_node;
		new_node = new Agro_Node();
#ifdef DEBUG_CREATURE_VERSION
		ASSERT(new_node);
#endif
		new_node->owner = the_owner;
		new_node->value = value;
		new_node->next = first;
		new_node->received_stamp = G_cur_time_ms;
		first = new_node;
	}
	//maybe we should change our target
	update();
#endif
}

void Agro_List::del(uint64 owner_GUID)
{
//printf("deleting agro\n");
	Agro_Node *kur = first,*prev = NULL;
	Base_Unit_Object *the_owner=(Base_Unit_Object*)(owner_GUID);
	while(kur && kur->owner!=the_owner)
	{
		prev = kur;
		kur = kur->next;
	}
	if(kur)
	{
		if(prev)prev->next = kur->next;
		else if(kur==first)	first = kur->next;
		if(kur==max_value) 
			update(); //maybe it is time to walk home
		delete kur;
	}
}

void creature_sell_item_list::update()
{
	if(next_refresh>G_cur_time_ms)
		return;
	next_refresh = G_cur_time_ms + refresh_interval;
	//iterate through the list and increase
	creature_sell_item_node *cur_node = first,*prev=NULL;
	while(cur_node)
	{
BEGIN_WHILE_CYCLE:
		if(cur_node->next_increase_stack < G_cur_time_ms)
		{
			if(cur_node->dinamic_item)
			{
				//it is time to dump this item
				G_Object_Pool.Release_item(cur_node->dinamic_item);
				creature_sell_item_node	*next=cur_node->next;
				if(cur_node==first)first=cur_node->next;
				if(prev)prev->next = cur_node->next;
				delete cur_node;
				cur_node = next;
				if(cur_node) goto BEGIN_WHILE_CYCLE;//no need to increase cur node now
				else break; //end of list
			}
			else if(cur_node->item_count < cur_node->item_count_max)
			{
				uint32 timediff = G_cur_time_ms - cur_node->next_increase_stack;
				if(timediff / cur_node->increase_stack_interval > cur_node->item_count_max)
					cur_node->item_count = cur_node->item_count_max;
				else cur_node->item_count = timediff / cur_node->increase_stack_interval;
				cur_node->next_increase_stack = G_cur_time_ms + cur_node->increase_stack_interval;
			}
			else	cur_node->next_increase_stack = G_cur_time_ms + cur_node->increase_stack_interval;
		}
		prev = cur_node;
		cur_node = cur_node->next;
	}
	//create some random items
	if(G_cur_time_ms>random_item_next_generate)
	{
		random_item_next_generate = G_cur_time_ms + VENDOR_GENERATE_NEW_RANDOM_ITEMS_INTERVAL;
		cur_node = first;
		while(cur_node)
		{
			//only randomize items once
			if(!cur_node->dinamic_item && cur_node->item_id<G_max_item_id && G_item_prototypes[cur_node->item_id])
			{
				uint32 item_class,item_subclass;
				item_class = G_item_prototypes[cur_node->item_id]->item_data32[ITEM_CLASS];
				item_subclass = G_item_prototypes[cur_node->item_id]->item_data32[ITEM_SUBCLASS];
				if(G_max_item_mods_sorted[item_class][item_subclass] && G_random.mt_random() % 100 < VENDOR_CHANCE_TO_RANDOMIZE_ITEM)
				{
					Item *new_item;
					new_item = G_Object_Pool.Get_fast_New_item();
					new_item->create_from_template(G_item_prototypes[cur_node->item_id]);
					new_item->apply_item_mod(G_item_mods_sorted[item_class][item_subclass][G_random.mt_random() % G_max_item_mods_sorted[item_class][item_subclass]]);
					creature_sell_item_node *new_node;
					new_node = new creature_sell_item_node;
					new_node->increase_stack_interval = 0xFFFFFF; //pretty sure this will not happen :)
					new_node->item_count = 1;
					new_node->item_count_max = 0xFFFFFF; //stack will not be increased automatically only by adding new instance of the same item
					new_node->item_id = new_item->data32[ITEM_ID];
					new_node->next_increase_stack = G_cur_time_ms + VENDOR_DUMP_CHARACTER_SOLD_ITEMS; //this is actually expiration time for item
					new_node->dinamic_item = new_item;
					add(new_node);
				}
			}
			cur_node = cur_node->next;
		}
	}
}

//ads a sold item to the vendor. This should be deleted right now or at the next refresh
//!!will create it's own item. If original is not used anymore then ust be deleted
void creature_sell_item_list::add_item_instance(Item *item_instance)
{
	//check if we already have this item in the list
	creature_sell_item_node *iter=first;
	while(iter && iter->item_id!=item_instance->item_data32[ITEM_ID])
		iter = iter->next;
	if(iter)
	{
		iter->item_count += item_instance->data32[ITEM_FIELD_STACK_COUNT];
		iter->next_increase_stack = G_cur_time_ms + VENDOR_DUMP_CHARACTER_SOLD_ITEMS; //this is actualy expiration time for item
//printf("adding item instance to vendor to a pack of already existing items\n");
	}
	else
	{
		//create item,we do not interfere with the other item
		Item	*new_item;
//		new_item = new Item;
		new_item = item_instance;
		new_item->create_from_template(item_instance);
		//create a new node and add this item with a timer after what he will be deleted
		creature_sell_item_node *new_node;
		new_node = new creature_sell_item_node;
		new_node->increase_stack_interval = 0xFFFFFF; //pretty sure this will not happen :)
		new_node->item_count = new_item->data32[ITEM_FIELD_STACK_COUNT];
		new_node->item_count_max = 0xFFFFFF; //stack will not be increased automatically only by adding new instance of the same item
		new_node->item_id = new_item->item_data32[ITEM_ID];
		new_node->next_increase_stack = G_cur_time_ms + VENDOR_DUMP_CHARACTER_SOLD_ITEMS; //this is actually expiration time for item
		new_node->dinamic_item = new_item;
		add(new_node);
	}
}

void creature_sell_item_list::clear()
{
	creature_sell_item_node *kur = first,*prev;
	while(kur)
	{
		prev = kur;
		kur = kur->next;
		if(prev->dinamic_item)
			G_Object_Pool.Release_item(prev->dinamic_item);
		delete prev;
	}
	first = NULL;
}

void cr_yell_list::yell_to_target(creature *owner,Character *target,uint8 event_type)
{
	//iterate through list and pick one
	cr_yell_node *itr=first;
	while(itr)
	{
		if((G_random.mt_random() % 100 < itr->chance) && itr->trigger_on_event==event_type)
		{
			WORLDSERVER.send_message(SEND_MESSAGE_TO_TARGET,itr,owner,target);
			if(itr->emote)
				owner->emote(itr->emote);
			break;
		}
		itr=itr->next;
	}
}

uint8 creature::On_Creature_spawn(creature *p_cr)
{return 0;}

uint8 creature::On_Creature_respawn(creature *p_cr)
{return 0;}
