// Copyright (C) 2006 Team Evolution
#ifndef gameobject20060503
#define gameobject20060503 1

#include "constants.h"
#include "multi_block_packet.h"
#include "Character.h"
#include "UpdateMask.h"
#include "WorldServer.h"
#include "math.h"
#include "Opcodes.h"
#include "spell.h"

class UpdateMask;
class Compressed_Update_Block;
class Character;
class WorldServer;

#define MAX_GO_NAME_LENGTH 50

//store go prototype
class gameobject
{
public:
	gameobject();
	~gameobject();
	union
	{
		uint32		*data32;
		float		*dataf;
	};
	uint32		db_id;
	uint32		respawn_delay;
	char		name[MAX_GO_NAME_LENGTH];
	uint32		sound[10];
	UpdateMask	update_mask;
//	item		*loot[16];
//	float		*loot_chance[16];
//  item		*loot_rand[4];
};

//creature instances have dinamic id's
class gameobject_instance
{
public:
	gameobject_instance();
	~gameobject_instance();
	void	update();
	void		spawn();	//the first time we initialise the creature = create pathpoints...
	void		respawn();
	void		despawn(); //play despawn animation by desgtroying object
	void	build_create_block(Compressed_Update_Block *packet,uint32 target_self);
	void	build_update_block(Compressed_Update_Block *packet,uint32 target_self,uint8 clear_mask=1);
	inline uint32		getGUIDL(){return (uint32)this;}
	inline uint32		getGUIDH(){return HIGHGUID_GAMEOBJECT;}
	inline uint64 getGUID(){return (((uint64)(HIGHGUID_GAMEOBJECT)<<32) | (uint64)this);}
	void		init_from_template(gameobject *gotemplate);
	void		init_from_template(gameobject_instance *gotemplate);
	gameobject	*prototype;
	float		pos_x,pos_y,pos_z,orientation;
	uint32		map_id;
	uint32		state1;		
	uint32		atimter1_ms_limit;
//	uint32		update_mask; //no sure if we need this at all
	uint32		db_id;
	uint32		respawn_delay;
//	Spell_Instance_list	affect_list;	//the list of spell_instances

	uint8 On_GO_spawn(gameobject_instance *p_go);
	uint8 On_GO_respawn(gameobject_instance *p_go);
};
#endif