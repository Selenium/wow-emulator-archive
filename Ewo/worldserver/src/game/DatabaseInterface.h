// Copyright (C) 2006 Team Evolution
#ifndef WOWPYTHONSERVER_DATABASEINTERFACE_H
#define WOWPYTHONSERVER_DATABASEINTERFACE_H 1

#include "Common.h"
#include "Sockets.h"
//#include <mysql.h>
#include "mapmanager.h"
#include "Character.h"
#include "creature.h"
#include "spell.h"
#include "item.h"
#include "Log.h"
#include "WorldServer.h"
#include "StringFun.h"
#include "constants.h"
#include "functions.h"
#include "Opcodes.h" //added for new trainer code

class Character;
class NetworkPacket;
class Item;
class Char_snapshot;

class DatabaseInterface
{
	friend class Database;
public:
	int doQuery (const char * query);
	uint64 doQueryId (const char * query);

////////////////////////////////// BEGIN World Server interface ///////////////////////////////////
	//get hash if player is online
	void get_account_hash(const char* username,char *hash_store);
	//we set player + account offline
	void set_player_offline(uint32 acc_id,uint32 char_id);
	//account is already online when we loged in, we only set player online now
	void set_player_online(uint32 char_id);
	//this will make the realm to be online only if given params are right
	uint32 add_realm(const char *realm,const char *ip,uint32 port,uint8 icon,uint8 color,uint8 timezone,uint32 player_limit);
	//when a server is shut down we remove it from realmlist by setting it to oflline
	void del_realm(uint32 id);
	int Login(char* username, char* ip);
	int account_client_addons(unsigned int accoint_id);
	void AllowIP(char* ip);
	void BanIP(char* ip);
	uint32 load_maps();
	void load_emote_text();
////////////////////////////////// END World Server interface //////////////////////////////////////
////////////////////////////////// BEGIN creature interface /////////////////////////////////////
	void load_creature_templates(); //loads all creature templates into a list
	void spawn_creatures(); //loads+init all creature instances and ads them to mapmanager
	void add_spawn_creature(Character *p_char,uint32 template_id,uint32 respawn_delay,uint32 flags); //add a new spawnpoint to db
	void del_spawn_creature(uint32 db_id);
	void load_faction_relations();//fills table with data who is friend or foe
	void load_creature_mods();
	void load_vendor_items();
	void load_vendor_spells();
	void load_NPC_text();
	void load_quest_templates();
////////////////////////////////// END creature interface //////////////////////////////////////
////////////////////////////////// BEGIN gameobject interface /////////////////////////////////////
	void load_go_templates(); //loads all creature templates into a list
	void spawn_gos(); //loads+init all creature instances and ads them to mapmanager
	void add_spawn_go(Character *p_char,uint32 template_id,uint32 respawn_delay); //add a new spawnpoint to db
	void del_spawn_go(uint32 db_id);
////////////////////////////////// END gameobject interface //////////////////////////////////////
////////////////////////////////// BEGIN Charhandler interface /////////////////////////////////////
	void add_character (Character * newChar);
	void load_character(Character *character);
	void load_character_affects(Character *character);
	void save_character(Character *character);
	void load_character_template(Character *character,uint8 race,uint8 player_class);
	void del_character (uint32 db_id);
	uint32 number_of_char_for_account(uint32 account_id);
	int IsNameTaken(char * charname);
	uint8 get_gm_ticket(Character *p_char);
	void	set_char_snapshot(Char_snapshot *from);
	void	get_char_snapshot(Char_snapshot *to);
////////////////////////////////// END Charhandler interface ///////////////////////////////////////
////////////////////////////////// BEGIN Gameclient interface //////////////////////////////////////
	void refresh_char_snapshots(GameClient *client,uint32 account_id);
////////////////////////////////// END Gameclient interface ///////////////////////////////////////
////////////////////////////////// BEGIN spell interface //////////////////////////////////////
	void load_spell_templates();
////////////////////////////////// END spell interface ///////////////////////////////////////
////////////////////////////////// BEGIN item interface //////////////////////////////////////
	void load_item_temlates();
	void load_item_mods();
	void load_static_loot_templates();
	void load_item_random_propertys();
////////////////////////////////// END item interface ///////////////////////////////////////
////////////////////////////////// BEGIN explorations interface //////////////////////////////////////
	void load_area_info();
	void load_graveyards();
	void load_custom_areatriggers(); //this are server sided suported only
////////////////////////////////// END explorations interface ///////////////////////////////////////
////////////////////////////////// BEGIN explorations interface //////////////////////////////////////
	void save_creature_waypoints(creature *cr);
////////////////////////////////// END explorations interface ///////////////////////////////////////
protected:
	DatabaseInterface (void * handle);
	~DatabaseInterface ();
	/// Handle to the database connection represented by this object
	void * mDatabaseConnection;
};

#endif
