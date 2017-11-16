// Copyright (C) 2006 Team Evolution
#include "base_unit_object.h"
#include "globals.h"
#include "Opcodes.h"

Base_Unit_Object::Base_Unit_Object()
{
	rooted_count = 0;
	silenced_count = 0;
	pacified_count = 0;
	target = NULL;
	threat_generated = UNITS_BASE_THREAT_GENERATE;
//	threat_generate_mod = 1;
	health_regen_spell = 0;
	power_regen_spell = 0;
	on_hit_spells = new On_event_spell_list(this);
	on_struck_spells = new On_event_spell_list(this);
	on_cast_spells = new On_event_spell_list(this);
	affect_list = new Spell_Affect_List;
	affect_list->owner_obj = this;
	health_shield = new Health_Shield_List();
	health_shield->owner = this;
	shapeshift_stats_backup = NULL;
	agro_sent_time = 0;
//	memset(spell_school_imun,0,SPELL_MAX_SCOOL_TYPE);
#ifdef AURA_CAN_EXPIRE_DIFFRENTLY_FOR_SPELLS
	memset(affects_in_aura_slot,0,MAX_AURAS);
#endif
}

Base_Unit_Object::~Base_Unit_Object()
{
   free(data32);
   data32 = NULL;
   delete on_hit_spells;
   delete on_struck_spells;
   delete on_cast_spells;
   delete affect_list;
   delete health_shield;
}

void Base_Unit_Object::AI_flee_remove()
{
	state1 &= ~UNIT_STATE_FLEE;
	if(obj_type & HIGHGUID_UNIT)
	{
		state1 &= ~(CREATURE_STATE_IN_COMBAT | CREATURE_STATE_ATACK);//make him target char again
	}
	else if(obj_type & HIGHGUID_PLAYER)
	{
		Character *c_char=(Character*)this;
		G_maps[map_id]->change_location(c_char,c_char->prev_x,c_char->prev_y);
		c_char->Send_SMSG_FORCE_MOVE_UNROOT();
	}
	atimer1 = G_cur_time_ms;//free to continue what we were doing before flee
}

void Base_Unit_Object::emote(uint32 what)
{
	NetworkPacket *packet=&G_send_packet;
	packet->opcode = SMSG_EMOTE;
	packet->data32[0] = what;
	*(uint64*)&packet->data32[1] = getGUID();
	packet->length = 12;
	G_maps[map_id]->send_instant_msg_to_block(pos_x,pos_y,packet,NULL);
}


//! only negative auras should be visible to attacker(i think)
uint8 Base_Unit_Object::get_free_aura_slot(uint8 type,uint32 spell_id)
{
	uint32 i;
	if(type==1)
	{
		for (i = MAX_POSITIVE_AURAS; i < MAX_AURAS; i++)
			if (data32[UNIT_FIELD_AURA + i] == spell_id)
				return i;
		for (i = MAX_POSITIVE_AURAS; i < MAX_AURAS; i++)
			if (data32[UNIT_FIELD_AURA + i] == 0) 
				return i;
	}
	else if(type==0)
	{
		for (i = 0; i < MAX_POSITIVE_AURAS; i++) 
			if (data32[UNIT_FIELD_AURA + i] == spell_id)
				return i;
		for (i = 0; i < MAX_POSITIVE_AURAS; i++) 
			if (data32[UNIT_FIELD_AURA + i] == 0) 
				return i;
	}
	return 0xFF; //in case we didn't find any free slot
}

//check if we have this kind of active spell on self
uint8 Base_Unit_Object::has_active_spell(uint32 spell_id)
{
	uint32 i;
	for (i = 0; i < MAX_AURAS; i++) 
		if (data32[UNIT_FIELD_AURA + i] == spell_id)
			return 1;
	return 0;
}

void Base_Unit_Object::add_aura_icon_to_slot(uint32 slot,uint32 spell_id)
{
	SetUInt32Value(UNIT_FIELD_AURA + slot,spell_id);
	uint8 flagslot = slot >> 3;
	uint32 value = data32[UNIT_FIELD_AURAFLAGS + flagslot];
	value |= (AFLAG_SET << ((slot & 7) << 2));
	SetUInt32Value( UNIT_FIELD_AURAFLAGS + flagslot, value);
	SetUInt32Value( UNIT_FIELD_AURALEVELS + flagslot, value );
}

void Base_Unit_Object::msg_move_creauture(float dest_x, float dest_y, float dest_z, uint32 time, uint8 run)
{
	/*
F7 40 F5 1F D1 02 01 F0 
94 B0 0C C6 = -9004.14
60 38 8B C0 = -4.35063
B3 AE B3 42 = 89.841
44 AB 21 09 = 153201476 
00 
00 00 00 00
85 17 00 00 
02 00 00 00
B1 EB 0C C6 = -9018.922
88 C2 F7 BF = -1.935
B3 6E B1 42 = 88.7162
D0 3F 00 FF = 4278206416 - not time, not acket serializer, not float

F7 5B 3F 22 2B 01 01 F0 
8F 83 0C C6 -x -8992.88
5A 4F 70 C2 -y -60.077
9B 23 B2 42 -z  89.069
30 A5 21 09 -serial
00 -walkback
00 00 00 00 -flags
12 19 00 00 -time = 
04 00 00 00 -wpcount ?
7A 45 0C C6 -x -8977.369
82 1A 65 C2 -y -57.275
9B 23 B7 42 -z  91.569
31 40 40 01 -? = 20987953
29 38 C0 00 -? = 12597289
1E 28 00 00 -? = 10270

F3 66 46 55 03 01 F0 
54 E0 C2 C5 
F0 14 A8 43 
6B A0 BF 43
BA A9 63 26 -serial
00
00 00 00 00
D7 04 00 00 
01 00 00 00 
64 F7 C2 C5 
C6 A1 A8 43 
6B 80 BF 43 

F3 D2 82 55 03 01 F0 
69 75 C3 C5 
9F AB 92 43
E3 D7 BF 43
BB A9 63 26 - serial
00 
00 00 00 00 
35 28 00 00 
05 00 00 00 
8C 6D C3 C5 
B0 DC 85 43 
46 E2 C0 43 
02 28 BD 01 
01 08 3E 01 
00 E8 7E 00
FF AF FF FF 

strange packet
F7 C7 49 7A C1 02 01 F0
BE 58 C0 C5 
F7 03 8E 43 
BA D0 C4 43 
66 5C 64 26 -serial
03 B3 B1 7C 
00 00 00 00
00 -walk back ?
00 01 00 00 - flags
EE 15 00 00 - time 
08 00 00 00 - wpcount
26 29 C1 C5 
83 26 84 43 
0D DC C1 43
9D AF BD FA
A0 BF 7D FB
A7 E7 3D FC 
AD 0F 3E FD 
B7 47 FE FD 
C7 A7 BE FE 
F3 B7 3F FF 
*/
	P_SMSG_MONSTER_MOVE *packet=(P_SMSG_MONSTER_MOVE *)G_send_packet.data;
//	static uint32 move_serial = 0x08000001;
	G_send_packet.opcode = SMSG_MONSTER_MOVE;
	//packet->guid_mask = 0xFF;
	packet->guid[0] = getGUIDL();
	packet->guid[1] = getGUIDH();
	packet->src_x = pos_x;
	packet->src_y = pos_y;
	packet->src_z = pos_z;
	//this values seems to be object dependent. It's an increasing value and min increase found is 1
//	packet->move_serial = G_packet_serializer++;
	packet->move_serial = G_cur_time_ms;
	packet->walk_back = 0; //walk back
	packet->walk_flags = (run ? 0x00000100 : 0x00000000);
	packet->walk_time = time;
	packet->path_waypoint_count = 1;
	packet->dst_x = dest_x;
	packet->dst_y = dest_y;
	packet->dst_z = dest_z;
	G_send_packet.length = sizeof(P_SMSG_MONSTER_MOVE);
	G_maps[map_id]->send_instant_msg_to_block(pos_x,pos_y,&G_send_packet,NULL);
}

void Base_Unit_Object::Set_powertype(uint8 powertype)
{
	if(Get_powertype()==powertype)
		return;
    uint32 new_bytes = (data32[UNIT_FIELD_BYTES_0] | 0x00FF0000) & (powertype<<24);
    SetUInt32Value(UNIT_FIELD_BYTES_0,new_bytes);
    switch(powertype)
    {
        default:
        case Unit_Power_Type_Mana:
            break;
        case Unit_Power_Type_Rage:
			SetUInt32Value(UNIT_FIELD_MAXPOWER1+powertype,1000);
			SetUInt32Value(UNIT_FIELD_POWER1+powertype,0);
			power = 0;
            break;
        case Unit_Power_Type_Focus:
        case Unit_Power_Type_Energy:
			SetUInt32Value(UNIT_FIELD_MAXPOWER1+powertype,100);
			SetUInt32Value(UNIT_FIELD_POWER1+powertype,100);
			power = 100;
            break;
		case Unit_Power_Type_Happiness:
			SetUInt32Value(UNIT_FIELD_MAXPOWER1+powertype,1000000);
			SetUInt32Value(UNIT_FIELD_POWER1+powertype,1000000);
			power = 1000000;
            break;
    }
	if(obj_type & HIGHGUID_PLAYER)
		((Character*)(this))->player_powertype=powertype;//this value is used alot
}

//this will apply stat changes on shapeshift,uponchange back we need to be able to change stats back !
void Base_Unit_Object::Aplly_Shapeshift_Stats(uint32 new_form,uint8 power_type)
{
#define SHAPESHIFT_VARIABLE_COUNT 1 //right now we only have to backup dmg
#define SHAPESHIFT_DMG_MOD_POS	0 //on pos 0 we have dmg mod value
	uint32 target_race=Get_race();
	if(shapeshift_stats_backup==NULL)
		shapeshift_stats_backup = (uint8*)malloc(sizeof(float)*SHAPESHIFT_VARIABLE_COUNT);
	switch(new_form)
	{
		case FORM_CAT:
			{
				if(target_race == PLAYER_RACE_TYPE_NIGHT_ELF)
					SetUInt32Value(UNIT_FIELD_DISPLAYID,892);
				else if(target_race == PLAYER_RACE_TYPE_TAUREN)
					SetUInt32Value(UNIT_FIELD_DISPLAYID,8571);
				Set_powertype(Unit_Power_Type_Energy);
				power = 0;
				SetUInt32Value(UNIT_FIELD_BASEATTACKTIME,1000);
				SetUInt32Value(UNIT_FIELD_BASEATTACKTIME+1,1000);
				float val = data32[UNIT_FIELD_ATTACK_POWER]/14.0f + data32[UNIT_FIELD_LEVEL];
				dataf[UNIT_FIELD_MINDAMAGE]+=val;
				*(float*)(shapeshift_stats_backup+SHAPESHIFT_DMG_MOD_POS)=val;
				SetFloatValue(UNIT_FIELD_MINOFFHANDDAMAGE, dataf[UNIT_FIELD_MINOFFHANDDAMAGE] + val );
				SetFloatValue(UNIT_FIELD_MAXOFFHANDDAMAGE, dataf[UNIT_FIELD_MAXOFFHANDDAMAGE] + val );
				SetFloatValue(UNIT_FIELD_MINDAMAGE, dataf[UNIT_FIELD_MINDAMAGE] + val );
				SetFloatValue(UNIT_FIELD_MAXDAMAGE, dataf[UNIT_FIELD_MAXDAMAGE] + val );
				//recalc_dinamic_stats stat will update values for char
				if(obj_type & HIGHGUID_PLAYER)
				{
					((Character*)this)->dmg_min[0] += val;
					((Character*)this)->dmg_diff[0] += (uint32)val;
				}
				else if(obj_type & HIGHGUID_UNIT)
					((creature*)this)->dmg_diff += (uint32)val;
			}break;
		case FORM_TRAVEL:
			{
				SetUInt32Value(UNIT_FIELD_DISPLAYID,632);
				Set_powertype(Unit_Power_Type_Mana);
			}break;
		case FORM_AQUA:
			{
				if(target_race == PLAYER_RACE_TYPE_NIGHT_ELF)
					SetUInt32Value(UNIT_FIELD_DISPLAYID,2428);
				else if(target_race == PLAYER_RACE_TYPE_TAUREN)
					SetUInt32Value(UNIT_FIELD_DISPLAYID,2428);
				Set_powertype(Unit_Power_Type_Mana);
			}break;
		case FORM_GHOUL:
			{
				if(target_race == PLAYER_RACE_TYPE_NIGHT_ELF)
					SetUInt32Value(UNIT_FIELD_DISPLAYID,10045);
				Set_powertype(Unit_Power_Type_Mana);
			}break;
		case FORM_BEAR:
			{
				if(target_race == PLAYER_RACE_TYPE_NIGHT_ELF)
					SetUInt32Value(UNIT_FIELD_DISPLAYID,2281);
				else if(target_race == PLAYER_RACE_TYPE_TAUREN)
					SetUInt32Value(UNIT_FIELD_DISPLAYID,2289);
				Set_powertype(Unit_Power_Type_Rage);
				goto APPLY_BEAR_STATS;
			}break;
		case FORM_DIREBEAR:
			{
				if(target_race == PLAYER_RACE_TYPE_NIGHT_ELF)
					SetUInt32Value(UNIT_FIELD_DISPLAYID,2281);
				else if(target_race == PLAYER_RACE_TYPE_TAUREN)
					SetUInt32Value(UNIT_FIELD_DISPLAYID,2289);
				Set_powertype(Unit_Power_Type_Rage);
APPLY_BEAR_STATS:
				SetUInt32Value(UNIT_FIELD_BASEATTACKTIME,2500);
				SetUInt32Value(UNIT_FIELD_BASEATTACKTIME+1,2500);
				float val = data32[UNIT_FIELD_ATTACK_POWER]/14.0f + data32[UNIT_FIELD_LEVEL];
				*(float*)(shapeshift_stats_backup+SHAPESHIFT_DMG_MOD_POS)=val;
				SetFloatValue(UNIT_FIELD_MINOFFHANDDAMAGE, dataf[UNIT_FIELD_MINOFFHANDDAMAGE] + val );
				SetFloatValue(UNIT_FIELD_MAXOFFHANDDAMAGE, dataf[UNIT_FIELD_MAXOFFHANDDAMAGE] + val );
				SetFloatValue(UNIT_FIELD_MINDAMAGE, dataf[UNIT_FIELD_MINDAMAGE] + val );
				SetFloatValue(UNIT_FIELD_MAXDAMAGE, dataf[UNIT_FIELD_MAXDAMAGE] + val );
				//recalc_dinamic_stats stat will update values for char
				if(obj_type & HIGHGUID_PLAYER)
				{
					((Character*)this)->dmg_min[0] += val;
					((Character*)this)->dmg_diff[0] += (uint32)val;
				}
				else if(obj_type & HIGHGUID_UNIT)
					((creature*)this)->dmg_diff += (uint32)val;
			}break;
		case FORM_CREATUREBEAR:
			{
				SetUInt32Value(UNIT_FIELD_DISPLAYID,902);
				Set_powertype(Unit_Power_Type_Mana);
			}break;
		case FORM_GHOSTWOLF:
			{
				SetUInt32Value(UNIT_FIELD_DISPLAYID,4613);
				Set_powertype(Unit_Power_Type_Mana);
			}break;
		case FORM_MOONKIN:
			{
				if(target_race == PLAYER_RACE_TYPE_NIGHT_ELF)
					SetUInt32Value(UNIT_FIELD_DISPLAYID,15374);
				else if(target_race == PLAYER_RACE_TYPE_TAUREN)
					SetUInt32Value(UNIT_FIELD_DISPLAYID,15375);
				Set_powertype(Unit_Power_Type_Mana);
			}break;
		case 0: //this is default of objects and means no form
			{
				SetUInt32Value(UNIT_FIELD_DISPLAYID,data32[UNIT_FIELD_NATIVEDISPLAYID]);
				Set_powertype(power_type);
				SetUInt32Value(UNIT_FIELD_BASEATTACKTIME,2000);
				SetUInt32Value(UNIT_FIELD_BASEATTACKTIME+1,2000);
				SetFloatValue(UNIT_FIELD_MINOFFHANDDAMAGE, dataf[UNIT_FIELD_MINOFFHANDDAMAGE] - *(float*)(shapeshift_stats_backup+SHAPESHIFT_DMG_MOD_POS) );
				SetFloatValue(UNIT_FIELD_MAXOFFHANDDAMAGE, dataf[UNIT_FIELD_MAXOFFHANDDAMAGE] - *(float*)(shapeshift_stats_backup+SHAPESHIFT_DMG_MOD_POS) );
				SetFloatValue(UNIT_FIELD_MINDAMAGE, dataf[UNIT_FIELD_MINDAMAGE] - *(float*)(shapeshift_stats_backup+SHAPESHIFT_DMG_MOD_POS) );
				SetFloatValue(UNIT_FIELD_MAXDAMAGE, dataf[UNIT_FIELD_MAXDAMAGE] - *(float*)(shapeshift_stats_backup+SHAPESHIFT_DMG_MOD_POS) );
				//recalc_dinamic_stats stat will update values for char
				if(obj_type & HIGHGUID_PLAYER)
				{
					((Character*)this)->dmg_min[0] -= *(float*)(shapeshift_stats_backup+SHAPESHIFT_DMG_MOD_POS);
					((Character*)this)->dmg_diff[0] -= (uint32)(*(float*)(shapeshift_stats_backup+SHAPESHIFT_DMG_MOD_POS));
				}
				else if(obj_type & HIGHGUID_UNIT)
					((creature*)this)->dmg_diff -= (uint32)(*(float*)(shapeshift_stats_backup+SHAPESHIFT_DMG_MOD_POS));
				if(shapeshift_stats_backup)//when we get here this should always be not null since we are shifting back
				{
					free(shapeshift_stats_backup);
					shapeshift_stats_backup=NULL;
				}
			}break;
		case FORM_BATTLESTANCE:
			{
			}break;
		case FORM_AMBIENT:
		case FORM_BERSERKERSTANCE:
		case FORM_DEFENSIVESTANCE:
		case FORM_SHADOW:
		case FORM_STEALTH:
		case FORM_TREE:
		default:
#ifdef _DEBUG
				printf("unknown SPELL_AURA_MOD_SHAPESHIFT form %u\n",new_form);
#endif
			break;
	}
	SetUInt32Value(UNIT_FIELD_BYTES_1,(data32[UNIT_FIELD_BYTES_1] & 0xFF00FFFF) | (new_form << 16));
#undef SHAPESHIFT_VARIABLE_COUNT
#undef SHAPESHIFT_DMG_MOD_POS
}
