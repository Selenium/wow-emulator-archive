// Copyright (C) 2006 Team Evolution
#ifndef BASE_UNIT_OBJECT_H
#define BASE_UNIT_OBJECT_H

#include "base_game_object.h"
//#include "multi_block_packet.h"
//#include "spell.h"
//#include "on_event_spells.h"

//this should be the base object of all killable and movable objects
//over this we should build up all other game objects like creature, player
class Spell_Info;
class NetworkPacket;
class On_event_spell_list;
class Compressed_Update_Block;
class Spell_Affect_List;
class Health_Shield_List;

class Base_Unit_Object: public Base_Game_Object
{
public:
	Base_Unit_Object();
	~Base_Unit_Object();
	//this will build a create object packet. This is used when we enter the world or other players enter the world
	virtual void		build_create_block(Compressed_Update_Block *packet,uint32 target_self){};
	//this should send for A9 only the values that changed since last update
	virtual void		build_update_block(Compressed_Update_Block *packet,uint32 target_self,uint8 clear_mask=1){};
	virtual float		take_dmg(float pdmg,uint64 atacker_GUID,uint8 ptype=0,uint8 unblockable=0,uint32 atacker_level=0){return pdmg;};
	virtual void		die(){};
	virtual	uint8		can_cast(Spell_Info *spell_info){return 0;};//0 means it's ok
	virtual void		start_cast(){};
	virtual inline void SendMsg(NetworkPacket *data){};
	virtual void		recalc_dinamic_stats(){};
	uint8				get_free_aura_slot(uint8 type,uint32 spell_id);
	uint8				has_active_spell(uint32 spell_id);
	void				add_aura_icon_to_slot(uint32 slot,uint32 spell_id);
	void				emote(uint32 what);
	virtual inline uint8		will_dodge_atack(){return 0;};
	virtual inline uint8		will_block_atack(){return 0;};
	virtual inline uint8		will_parry_atack(){return 0;};
	void				msg_move_creauture(float dest_x, float dest_y, float dest_z, uint32 time, uint8 run);
	virtual void		AI_flee_from_point(uint32 time){}; //used to make creature get away from a specific point. He will keep running for x ms
	virtual void		AI_flee_remove();
	virtual inline void	add_agro(uint64 guid,float amount){};
	virtual void		on_spell_change_resistance(){};//recalc rezistances to show corectly
	inline virtual void	flag_set(uint32 index,uint32 flag)
	{
		if(!(data32[index] & flag))update_mask.SetBit(index);
		data32[index] |= flag;
	}
	inline virtual void	flag_clr(uint32 index,uint32 flag)
	{
	    if((data32[index] & flag))update_mask.SetBit(index);
		data32[index] &= ~flag;
	}
	inline virtual		uint8 flag_is(uint32 index,uint32 flag){return ((data32[index] & flag)!=0);}
	inline		uint8	Get_race(){return ((uint8)(data32[UNIT_FIELD_BYTES_0] & 0xFF));}
	inline		uint8	Get_class(){return ((uint8)((data32[UNIT_FIELD_BYTES_0] >> 8) & 0xFF));}
	inline		uint8	Get_gender(){return ((uint8)((data32[UNIT_FIELD_BYTES_0] >> 16) & 0xFF));}
	inline		uint8	Get_powertype(){return ((uint8)((data32[UNIT_FIELD_BYTES_0] >> 24) & 0xFF));}
	void				Set_powertype(uint8 powertype);
	void				Aplly_Shapeshift_Stats(uint32 new_form,uint8 power_type=0xFF);
	inline		uint8	Get_ShapeShift_form(){return ((uint8)((data32[UNIT_FIELD_BYTES_1] >> 16) & 0xFF));}
	float				health,health_regen,health_regen_spell;
	float				power,power_regen,power_regen_spell;
	float				speed_land_modifyer,speed_water_modifyer,speed_attack_modifyer;
	uint32				state1,flags1;
	On_event_spell_list	*on_hit_spells;
	On_event_spell_list	*on_struck_spells;
	On_event_spell_list	*on_cast_spells;
	Health_Shield_List	*health_shield;
	Spell_Affect_List	*affect_list;
	uint8				rooted_count,silenced_count,pacified_count;
	uint32				agro_sent_time; //sometimes we do not move and creatures reapear, we have to send agro to these
	signed int			threat_generated;//this is used for static presence threat
//	float				threat_generate_mod;//coeficient factor for threat generation
	Base_Unit_Object	*target;//the one that is targeted for attack
	signed int			*faction_reputation;//this is 1 row from the matrix containing all faction reputaion relations. If it is - then it's enemy, if it's below 2000 then it's neutral, else it's friendly
	uint8				*shapeshift_stats_backup;
//	uint8				spell_school_imun[SPELL_MAX_SCOOL_TYPE];
#ifdef AURA_CAN_EXPIRE_DIFFRENTLY_FOR_SPELLS
	uint8				affects_in_aura_slot[MAX_AURAS];//there are spells which have 3 auras and they expire in diffrent times
#endif
};

#endif
