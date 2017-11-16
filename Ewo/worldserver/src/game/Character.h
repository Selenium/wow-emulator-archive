// Copyright (C) 2006 Team Evolution
#ifndef character20060503
#define character20060503 1

#include "GameClient.h"
#include "UpdateMask.h"
#include "Namespace.h"
#include "constants.h"
#include "multi_block_packet.h"
#include "SystemFun.h"
#include "WorldServer.h"
#include "constants.h"
#include "DatabaseInterface.h"
#include "spell.h"
#include "group.h"
#include "quest.h"
#include "globals.h"
#include "on_event_spells.h"
#include "base_unit_object.h"

class Item;
class Group;
class corpse;
class NetworkPacket;
class Quest_id_List;
class Quest_instance_List;

struct skill_entry
{
	uint32 lineId;
	uint16 currVal;
	uint16 maxVal;
	uint32 unk;
};

class Character:public Base_Unit_Object
{
	friend class UpdateMask;
public:
	//constructor takes param becouse these objects will have dinamic ip
	Character ( );
	void Refurbish();//can be called by object pool to bring item object into a state where it can be reused
	~Character ( );
	inline void	set_guid()//sometimes we require to generate guid again
	{
		data32[OBJECT_FIELD_GUID] = (uint32)this;
		data32[OBJECT_FIELD_GUID+1] = HIGHGUID_PLAYER | (db_id<<16); //use salt for refurbished objects
	}
	//this function initilize the current class from db
	void		load_from_db();//used for charlist (does not load items, stats ...
	//this function saves all necesary data to db so next time it will be loaded
	void		save_to_db();
	//this will build up a pack of data that has to be sent to the client when char_enum packet is received
	void		build_enum_block( uint8 * data, uint8 * length );
	//this will build a create object packet. This is used when we enter the world or other players enter the world
	void		build_create_block(Compressed_Update_Block *packet,uint32 target_self);
	//this should send for A9 only the values that changed since last update
	void		build_update_block(Compressed_Update_Block *packet,uint32 target_self,uint8 clear_mask=1);
	//create a new player
	void		Create (NetworkPacket &data );
	//this will update the player. param is a time_diff = diffrence since the last update
	void		update(uint32 time_diff);
	//incase we take dmg this will calc the amount that is blocked and substract the remaining dmg from health
	float		take_dmg(float pdmg,uint64 atacker_GUID,uint8 ptype=0,uint8 unblockable=0,uint32 atacker_level=0);
	//when char dies we take some actions : corpse, ghost form ..
	void		die();
    inline void set_stand_state (uint8 standstate)
    {
       SetUInt32Value (UNIT_FIELD_BYTES_1, (data32[UNIT_FIELD_BYTES_1] & 0xFFFFFF00) | standstate);
    }
    inline uint8 GetComboPoints() { return uint8((data32[PLAYER_FIELD_BYTES] & 0xFF00) >> 8); }
    void		SetComboPoints (uint8 value) { SetUInt32Value (PLAYER_FIELD_BYTES, ((data32[PLAYER_FIELD_BYTES] & ~(0xFF << 8)) | (value << 8))); }
	uint8		can_cast(uint32 spell_id);	//checks if player can cast this spell
	inline void	start_cast();	//takes actions when a spell is casted
	void		xp_modify(uint64 victim_guid,uint32 amount,uint8 personal);
	Item*		get_item(uint32 slot,uint8 bag_index);
	Item*		rem_item(uint32 slot,uint8 bag_index=0,uint8 is_switch=0);
	uint32		rem_item(Item *src_item);//willreturn slot + bag >> 16;
	uint32		rem_item_id(uint32	item_id,uint32 count);//willreturn count that has been removed
	void		rem_item_stats(Item *p_item,uint8 forced_remove=0);
	void		add_item(Item *p_item,uint32 slot,uint8 bag_index=0,uint8 is_switch=0);
	//used on add item and on item rapair
	void		add_item_stats(Item *p_item);
	void		sheath_set(uint32 sheath_value);
	void		on_atack_swing();
	float		get_dmg(uint8 type);
	uint8		will_dodge_atack();
	uint8		will_block_atack();
	uint8		will_parry_atack();
	void		on_char_corpse(uint8 quiet_transform=0);
	void		on_char_resurect(uint8 at_corpse);
	void		force_durability_change(float coef);
	void		msg_corpse_location();
	void		remove_mods();//should remove secondary efects for spells and items
	void		recalc_dinamic_stats();//dmg,health is dependent on base stats, when they change, we recalc dinamic values
	void		recalc_base_stats();//basee stats do not depend but only of level
	void		on_spell_change_resistance();//recalc rezistances to show corectly
	void		msg_inv_change_result(Item *item1,Item *item2,uint8 result);
	void		Send_SMSG_FORCE_MOVE_UNROOT();
	void		Send_SMSG_FORCE_MOVE_ROOT();
	void		Send_SMSG_MOVE_WATER_WALK();
	void		Send_SMSG_MOVE_LAND_WALK();
#ifdef VERSION_CHAR_MAKE_CREAUTURE_WPOINTS
	void		handle_generate_z_cords_state();
	float		fall_z;
	int			lock_map_id;
	int			cur_map_id;
	int			cur_cell;
#endif 
	//ths function should find best location for an item. Used at looting
	uint8		auto_store_item(Item *pitem);
	//part of the full autostore function, also used for other purpuses
	uint8		auto_store_item_in_bag(Item *pitem,uint8 bag_nr,uint8 just_stack);
	//set some values so player seems to be loged out
	void		on_logout();
	//we presume that setting have been made before
	void		msg_change_speed(uint8 speed_type);
	void		add_skill(uint32 skill_id,uint32 cur_lvl,uint32 max_lvl);
	uint8		has_skill(uint32 skill_id,uint32 skill_lvl);
	//will return one of the client defined quest relation constants : started,finished,.... Aker might just finish the quest if quest type is speak to
	uint8		quest_relation(uint32 quest_id,creature *asker=NULL);
	uint32		get_total_item_count(uint32 item_id);
	void		try_force_enter_combat(uint64 atacker_GUID);//called by creatures when they start rushing at char
	void		try_force_exit_combat();//called by creatures when he exited combat (die or return)
	void		get_folower_next_coords(creature *folower);//used for dota so not all creatures will be at the same place
	inline void SendMsg(NetworkPacket *data){pClient->SendMsg(data);}
	//inline void SendPacket(WowData * data);
	void		AI_flee_from_point(uint32 time); //used to make creature get away from a specific point. He will keep running for x ms
	void		on_change_lvl()	{rage_conversion = ((0.0091107836f * data32[UNIT_FIELD_LEVEL]*data32[UNIT_FIELD_LEVEL])+3.225598133f*data32[UNIT_FIELD_LEVEL])+4.2652911f;}
	inline void		rage_modify_on_hit(float dmg_made){power += dmg_made/rage_conversion*25.0f;}		
	inline void 	rage_modify_on_struck(float dmg_rcv){power += dmg_rcv/rage_conversion*75.0f;}
	void		genrate_quest_loot(uint32 creature_id);//caled on looting a new creature. Can be tricked right now by looting 2 creatures :)
	void		finish_duel(uint8 finish_type);
//	signed int	GetFactionReputation(uint32 faction_id);
#ifdef SERVER_DOTA_COMPILATION
#endif
	//values are stored in 
//	uint8		*cache_data_create;
	uint8		*cache_data_update;
//	uint32		cache_id_create,cache_create_length_total;
	uint32		cache_id_update,cache_update_length_total;
//	signed int	timer1; //state timer, when it reaches 0 or less state can change
	//this value is set in 2 parts : when loading char from database and when creating a new char
	//what properties we have to update. At each update this is cleared 
    UpdateMask	packet_mask;
	uint8		m_isRested;      // rest state
	uint8		afk;			//away from keyboard 
    uint32		m_petInfoId;      // pet info id
    uint32		m_petLevel;      // pet level
    uint32		m_petFamilyId;   // pet family id
	char		name[MAX_CHAR_NAME_LENGTH];
	uint8		reputation[NUMBER_OF_FACTIONS];
	uint32		reputation_val[NUMBER_OF_FACTIONS];
	float		prev_x,prev_y,prev_z,prev_orientation;
	float		bind_x,bind_y,bind_z,bind_orientation;
	uint32		bind_map_id,bind_area_id,bind_zone_id;
//	uint32		account_id;
	uint32		zone_id;
	GameClient	*pClient;
	uint32		actionbuttons[NUMBER_OF_ACTION_BUTTONS];
//	uint64		killer_guid;	//store the id of our killer
//	uint8		player_race,player_class,player_gender;
	uint8		player_powertype; //just store it instead of calc it evry time
	uint64		selected_object_guid;
	uint64		last_target_GUID;
	uint64		last_used_gameobject_guid; //used for gm to be able to delete gameobjects from map
	spell_list	spellbook;	//the list of spells a player knows
	Spell_Instance	cur_spell,instant_spell;	//the list of spell_instances
//	Target_list	spell_target_list[3];	//store guids for spell that is going to be cast
	uint32		water_submerge; //the time when we went underwater
	float		water_dmg;
	float		water_level_z;	//register where the water level was
	Group		*group;
	Character	*group_invitated_by;
	float		corpse_x, corpse_y, corpse_z, corpse_o;
	float		agro_x,agro_y;	//the position where we last sent agro to creatures
	corpse		*pcorpse;
	float		item_min_dmg[PLAYER_USED_DMG_TYPES],item_max_dmg[PLAYER_USED_DMG_TYPES];
	float		spell_min_dmg[PLAYER_USED_DMG_TYPES],spell_max_dmg[PLAYER_USED_DMG_TYPES];
	float		dmg_min[PLAYER_USED_DMG_TYPES];
	signed int	dmg_diff[PLAYER_USED_DMG_TYPES];
	float		spell_res_pct[PLAYER_USED_DMG_TYPES];
	uint32		spell_res_pct_values[PLAYER_USED_DMG_TYPES];//store percent resistance modifyers
	uint32		spell_queue[CHAR_SPELL_QUEUE_MAXLEN],spell_queue_len;//used for items only
	Spell_cooldown_list spell_cooldowns;	
	uint64		last_atacker_guid;
	uint64		looted_object_guid;
	Quest_id_List		quests_finished;
	Quest_instance_List	quests_started;
	uint32		quest_loot_item_ids[20*4];//will store quest items id thet we sent on loot list generation to know what we are looting
	creature	*last_vendor_used;//used to sell to vendor our items after we leave him. Will be null most of the time
	skill_entry *skill_list;
	float		spell_extra_healing,spell_extra_healing_pct;
	uint32		spell_animation;
	uint32		mechanic_rezistance;
	float		offhand_dmg_mod,offhand_dmg_mod_pct;
	uint32		state2;
	creature	*totems[CHARACTER_MAX_TOTEMS];
	float		rage_conversion;
	Duel_Info	duel_info;
	On_Attack_Extra_Dmg_List	on_attack_spell_dmg,on_struck_spell_dmg;
#ifndef DISABLE_CUSTOM_TRIGGER_CHECKS
	float		areatrigger_lastcheck_x,areatrigger_lastcheck_y,areatrigger_lastcheck_z;
#endif
	creature	*folower_matrix[5][5];//contains the creatures that are folowing you and their location around you
#ifdef SERVER_DOTA_COMPILATION
#endif
	// Interupts not implemented but eventualy can be used as external owerrides to functions
	uint8 On_Player_Create(Character *p_char);
	uint8 On_Player_Login(Character *p_char);
	uint8 On_Player_Take_DMG(Character *p_char,uint32 DMG,uint8 internal_type);
	uint8 On_Player_Just_Died(Character *p_char);
	uint8 On_Player_Log_Out(Character *p_char);
	uint8 On_Player_Update(Character *p_char);
};

#endif