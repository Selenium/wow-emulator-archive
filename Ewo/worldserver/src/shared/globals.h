// Copyright (C) 2006 Team Evolution
#pragma once
#ifndef _GLOBALS_H
#define _GLOBALS_H 1

#include "packet_structures.h"
#include "NetworkInterface.h"
#include "mersenet.cpp"
//#include "mapmanager.h"
//#include "Character.h"
//#include "corpse.h"
//#include "creature.h"
//#include "game_object.h"
//#include "group.h"
//#include "item.h"
//#include "spell.h"
//#include "constants.h"
//#include "GameClient.h"
//#include "multi_block_packet.h"
//#include "WorldServer.h"
#include "Database.h"
#include "creature.h"
#include "./packet_handlers/packethandler_misc.h"
#include "./packet_handlers/packethandler_auth.h"
#include "./packet_handlers/packethandler_char.h"
#include "quest.h"
#include "Packet.h"
#include "object_pool.h"

class DatabaseInterface;
class creature_mod;
class gameobject;
class game_map;
class Item_mod;
class Loot_template_list;
struct NPC_text;
class Creature_List;

extern NetworkPacket		G_send_packet;
extern NetworkPacket		G_recv_packet;

extern MersenneTwister		G_random;
extern uint32				G_cur_time_ms;
extern uint32				G_cur_time;
extern uint32				*G_emote_anim,G_max_emote_anim;
//this is actualy only a flag but maybe later will represent amount to agro
extern uint8				*G_faction_is_enemy,*G_faction_is_friend;
extern uint32				G_max_faction_id;
extern DatabaseInterface	*G_dbi_r,*G_dbi_w;

extern creature_mod			*G_creature_mods; //will store a list of creature mods (like extra health, more block...)
extern uint32				G_max_creature_mods;
extern NPC_text				**G_NPC_text;//store all texts
extern uint32				G_max_NPC_text;

extern Item					**G_item_prototypes; //1 step lookup vector
extern uint32				G_max_item_id;
extern Item_mod				**G_item_mods;
extern uint32				G_max_item_mods;
extern Item_mod				**G_item_mods_sorted[MAX_ITEM_CLASS_TYPES][MAX_ITEM_SUBCLASS_TYPES]; //each item type should pick a 
extern uint32				G_max_item_mods_sorted[MAX_ITEM_CLASS_TYPES][MAX_ITEM_SUBCLASS_TYPES];
extern Loot_template_list	**G_static_loot_templates;
extern uint32				G_max_loot_template_id;

extern Spell_Info			**G_spell_info; //this a 1 step lookup vector
extern uint32				G_max_spell_id;
extern gameobject			**G_gameobject_prototypes;
extern uint32				G_max_gameobjects;
extern creature				**G_creature_prototypes;
extern uint32				G_max_creature_prototypes;
extern game_map				**G_maps;	//vector of maps
extern uint32				G_max_map_id;
extern UpdateMask			G_item_update_mask;
extern UpdateMask			G_container_update_mask;
//extern UpdateMask			G_char_create_mask;
//extern UpdateMask			G_creature_create_mask;
extern UpdateMask			G_gameobject_create_mask;
extern Compressed_Update_Block		G_temp_compressed_packet;
extern uint32				G_turn_id;	//used localy by update function to mark an update unique
extern void (*G_packet_handlers[])(GameClient *pClient);
extern uint32				G_max_handled_opcode;
extern uint8				*G_questgiver_minimap_show_prepared_packet;
extern uint32				G_questgiver_minimap_show_prepared_packet_len;

extern Quest_template		**G_quest_prototypes;
extern uint32				G_max_quest_id;

extern Creature_List		G_creature_always_active;//contains a list of creatures that should be updated at each server turn

extern Spell_Instance		G_instant_spell_instance,G_instant_spell_instance2;

extern item_random_property_def **G_item_random_property;
extern uint32				G_max_random_property_id;
extern item_enchantment_def		**G_item_enchantments;
extern uint32				G_max_enchant_id;
extern uint32				G_packet_serializer;//this should be created separatly for each client
extern Object_Pool			G_Object_Pool; //create a unique global object (=singleton)
#endif