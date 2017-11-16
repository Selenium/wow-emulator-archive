// Copyright (C) 2006 Team Evolution
#ifndef worldserver20060503
#define worldserver20060503 1

#include <string>
#include "Server.h"
#include "Common.h"
#include "GameClient.h"
#include "time.h"
#include "constants.h"
#include "Network.h"
#include "Log.h"
#include "Opcodes.h"
#include "Character.h"
#include "UpdateMask.h"
#include "Debug.h"
#include "math.h"
#include "version.h"
#include "spell.h"
#include "item.h"
#include "mapmanager.h"
#include "Character.h"
#include "creature.h"
#include "game_object.h"
#include <stdexcept>
#include <exception>
#include "globals.h"
#include "Database.h"

class game_map;
class creature;
class gameobject;
class Item;
class creature_mod;
class cr_yell_node;

/////////////////////////
#define WORLDSERVER (WorldServer::getSingleton ())

class WorldServer : public Server, public Singleton <WorldServer>
{
public:
	WorldServer();
	~WorldServer();
	void			Update( uint32 time );  // update the world server every frame
    uint32			GetClientsConnected () { return static_cast<uint32>(mClients.size()); }
	void			SetMotd(char *newMotd) { motd = newMotd; }
	uint8			*GetMotd(){ return (uint8*)motd.c_str(); }
	//send a message
	void			send_message(char *message,uint8 send_type,uint8 msg_type,uint32 lang,uint32 channel_id,Character *sender,Character *target);
	void			send_message(uint8 send_type,cr_yell_node *yell_node,creature *sender,Character *target);
	void			SetInitialWorldSettings();
	GameClient		*GetClientByName(char* name);
	void			server_sockevent(nlink *cptr, unsigned short revents, void * myNet);
	void			client_sockevent(nlink *cptr, unsigned short revents);
	void			disconnect_client(nlink *cptr );
	void			disconnect_client(GameClient *pClient);
	void			eventStart( );
	void			eventStop( );
	inline	uint	GetClientLimit () { return mClientLimit; }
	inline void		SetClientLimit (int Limit) { mClientLimit = Limit; }
	void			set_realm_settings(const char *realm,const char *ip,uint32 port,uint8 icon,uint8 color,uint8 timezone,uint32 player_limit);
	Character		*get_character_by_name(const char* char_name);
	void			handle_chat_command(GameClient *pClient, Character *p_char);
	void			save_loged_in_chars();//used in crash situation
#ifdef SERVER_DOTA_COMPILATION
	void			handle_chat_command_dota(GameClient *pClient,Character *cc_char);
#endif
	void			LogoutPlayer(GameClient *pClient);
	uint8			Check_Player_exist(Character *p_char);//make sure this is a valid pointer
	char			realm_name[50];
	char			realm_ip[15];
	uint32			realm_port,realm_id;
	uint8			realm_icon,realm_color,realm_timezone;
	uint32			dbstate;
	uint32			server_start_time; //this is required for dinamic ip generation (make sure we receive id's only from this session)
	// sets the timeout limit for timers
	uint			mClientsConnected;
	uint			mClientLimit;
	//stores the number of active connections to the database
	std::string		motd;
	uint64			debug_guid;
};

uint32 get_param_uint32(uint8* data,uint32& pos,uint32 maxlen);
float get_param_float(uint8* data,uint32& pos,uint32 maxlen);

#endif
