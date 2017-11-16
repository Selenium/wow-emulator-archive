// Copyright (C) 2006 Team Evolution
#ifndef corpse20060623
#define corpse20060623 1

#include "constants.h"
#include "multi_block_packet.h"
#include "WorldServer.h"
#include "UpdateMask.h"
#include "Character.h"

class Compressed_Update_Block;
class UpdateMask;
class Character;
class WorldServer;

//corpse init does all the work, you just have to create one
//corpse is spawned when player dies, or enters game and it is still dead
//corpse is spawned on player enter game based on player flag
//corpse exists only if player is in game
//only corpse pos is stored in db, rest is initialized when player enters game
//ver1
//corpse is added to mapmanager as gameobject to reduce cell size. !!!be carefull to check interaction with corpse
//corpse does not get updated only created or removed on player enter/exit cell
//ver2
//corpse is created to all players ingame
//corpse is destroyed only when player is resurected
//ver 3 -  we use this
//corpse is added to mapmanager as corpse
//corpse is created/destroyed on player enter/exit cell
class corpse
{
public:
	corpse(Character *owner);
	~corpse();
	inline uint32		getGUIDL(){return data32[OBJECT_FIELD_GUID];}
	inline uint32		getGUIDH(){return data32[OBJECT_FIELD_GUID+1];}
	inline uint64		getGUID(){return (*(uint64*)&data32[OBJECT_FIELD_GUID]);}
	void		build_create_block(Compressed_Update_Block *packet,uint32 target_self,uint32 turn_id);
	float		pos_x,pos_y,pos_z,orientation;
	uint32		map_id;
	uint32		*packet_cache;
	uint32		packet_cache_len;
	Character	*owner;

	uint32		*data32;
	float		*dataf;
};

#endif 