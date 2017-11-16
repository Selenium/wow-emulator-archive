// Copyright (C) 2006 Team Evolution
#include "WorldServer.h"

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////
createFileSingleton (WorldServer);

WorldServer::WorldServer()
{
	G_max_creature_mods = 0;
	mClientsConnected = 0;
	mClientLimit = CLIENTLIMIT;
	motd = "Default MOTD";
	dbstate = 0;
	server_start_time = (uint32)time(NULL);
	G_turn_id = server_start_time;
	G_packet_serializer = 0;
}

WorldServer::~WorldServer()
{
	//destroy global lists
	uint32 i;
	free(G_creature_mods);
	for(i=0;i<G_max_item_id;i++)
		if(G_item_prototypes[i]!=NULL)
			delete G_item_prototypes[i];
	free(G_item_prototypes);
	for(i=0;i<G_max_spell_id;i++)
		if(G_spell_info[i]!=NULL)
			delete G_spell_info[i];
	free(G_spell_info);
	for(i=0;i<G_max_gameobjects;i++)
		if(G_gameobject_prototypes[i]!=NULL)
			delete G_gameobject_prototypes[i];
	free(G_gameobject_prototypes);
	for(i=0;i<G_max_creature_prototypes;i++)
		if(G_creature_prototypes[i]!=NULL)
			delete G_creature_prototypes[i];
	free(G_creature_prototypes);
	for(i=0;i<G_max_loot_template_id;i++)
		if(G_static_loot_templates[i])
			delete G_static_loot_templates[i];
	free(G_static_loot_templates);
	free(G_item_mods);
	for(i=0;i<G_max_map_id;i++)
		if(G_maps[i]!=NULL)
			delete G_maps[i];
	delete [] G_maps;
}


void WorldServer::SetInitialWorldSettings()
{
	//set character create bits
/*	G_char_create_mask.SeCount(PLAYER_END);
	G_char_create_mask.SetBit(OBJECT_FIELD_GUID);
    G_char_create_mask.SetBit(OBJECT_FIELD_TYPE);
    G_char_create_mask.SetBit(OBJECT_FIELD_SCALE_X);
    G_char_create_mask.SetBit(UNIT_FIELD_SUMMON);
    G_char_create_mask.SetBit(UNIT_FIELD_SUMMON+1);
    G_char_create_mask.SetBit(UNIT_FIELD_TARGET);
    G_char_create_mask.SetBit(UNIT_FIELD_TARGET+1);
    G_char_create_mask.SetBit(UNIT_FIELD_HEALTH);
    G_char_create_mask.SetBit(UNIT_FIELD_POWER1);
    G_char_create_mask.SetBit(UNIT_FIELD_POWER2);
    G_char_create_mask.SetBit(UNIT_FIELD_POWER3);
    G_char_create_mask.SetBit(UNIT_FIELD_POWER4);
    G_char_create_mask.SetBit(UNIT_FIELD_POWER5);
    G_char_create_mask.SetBit(UNIT_FIELD_MAXHEALTH);
    G_char_create_mask.SetBit(UNIT_FIELD_MAXPOWER1);
    G_char_create_mask.SetBit(UNIT_FIELD_MAXPOWER2);
    G_char_create_mask.SetBit(UNIT_FIELD_MAXPOWER3);
    G_char_create_mask.SetBit(UNIT_FIELD_MAXPOWER4);
    G_char_create_mask.SetBit(UNIT_FIELD_MAXPOWER5);
    G_char_create_mask.SetBit(UNIT_FIELD_LEVEL);
    G_char_create_mask.SetBit(UNIT_FIELD_FACTIONTEMPLATE);
    G_char_create_mask.SetBit(UNIT_FIELD_BYTES_0);
    G_char_create_mask.SetBit(UNIT_FIELD_FLAGS);
    for(uint16 i = UNIT_FIELD_AURA; i < UNIT_FIELD_AURASTATE; i ++)
        G_char_create_mask.SetBit(i);
    G_char_create_mask.SetBit(UNIT_FIELD_BASEATTACKTIME);
    G_char_create_mask.SetBit(UNIT_FIELD_OFFHANDATTACKTIME);
    G_char_create_mask.SetBit(UNIT_FIELD_RANGEDATTACKTIME);
    G_char_create_mask.SetBit(UNIT_FIELD_BOUNDINGRADIUS);
    G_char_create_mask.SetBit(UNIT_FIELD_COMBATREACH);
    G_char_create_mask.SetBit(UNIT_FIELD_DISPLAYID);
    G_char_create_mask.SetBit(UNIT_FIELD_NATIVEDISPLAYID);
    G_char_create_mask.SetBit(UNIT_FIELD_MOUNTDISPLAYID);
    G_char_create_mask.SetBit(UNIT_FIELD_BYTES_1);
    G_char_create_mask.SetBit(UNIT_FIELD_MOUNTDISPLAYID);
    G_char_create_mask.SetBit(UNIT_FIELD_PETNUMBER);
    G_char_create_mask.SetBit(UNIT_FIELD_PET_NAME_TIMESTAMP);
    G_char_create_mask.SetBit(UNIT_DYNAMIC_FLAGS);
    G_char_create_mask.SetBit(PLAYER_BYTES);
    G_char_create_mask.SetBit(PLAYER_BYTES_2);
    G_char_create_mask.SetBit(PLAYER_BYTES_3);
    G_char_create_mask.SetBit(PLAYER_GUILDID);
    G_char_create_mask.SetBit(PLAYER_GUILDRANK);
    G_char_create_mask.SetBit(PLAYER_GUILD_TIMESTAMP);
    for(uint16 i = 0; i < INVENTORY_SLOT_BAG_END; i++)
    {
        G_char_create_mask.SetBit((uint16)(PLAYER_FIELD_INV_SLOT_HEAD + i*2));
        G_char_create_mask.SetBit((uint16)(PLAYER_FIELD_INV_SLOT_HEAD + (i*2) + 1));
    }
    for(uint16 i = 0; i < EQUIPMENT_SLOT_END; i++)
        G_char_create_mask.SetBit((uint16)(PLAYER_VISIBLE_ITEM_1_0 + (i*12)));
    G_char_create_mask.SetBit(UNIT_VIRTUAL_ITEM_SLOT_DISPLAY);
    G_char_create_mask.SetBit(UNIT_VIRTUAL_ITEM_SLOT_DISPLAY_01);
    G_char_create_mask.SetBit(UNIT_VIRTUAL_ITEM_SLOT_DISPLAY_02);
    G_char_create_mask.SetBit(UNIT_VIRTUAL_ITEM_INFO);
    G_char_create_mask.SetBit(UNIT_VIRTUAL_ITEM_INFO_01);
    G_char_create_mask.SetBit(UNIT_VIRTUAL_ITEM_INFO_02);
    G_char_create_mask.SetBit(UNIT_VIRTUAL_ITEM_INFO_03);
    G_char_create_mask.SetBit(UNIT_VIRTUAL_ITEM_INFO_04);
    G_char_create_mask.SetBit(UNIT_VIRTUAL_ITEM_INFO_05);*/

    G_item_update_mask.SetCount(ITEM_END); //it would be a waist of space to create this for each item. They don't get updated evry day
	G_container_update_mask.SetCount(CONTAINER_END);
	G_gameobject_create_mask.SetCount(GAMEOBJECT_END);

	//prepare G_questgiver_minimap_show_prepared_packet
	G_questgiver_minimap_show_prepared_packet_len = 10+((UNIT_END+31)/32)*4 + 4;
	G_questgiver_minimap_show_prepared_packet = (uint8*)malloc(G_questgiver_minimap_show_prepared_packet_len);
	memset(G_questgiver_minimap_show_prepared_packet,0,G_questgiver_minimap_show_prepared_packet_len);
	G_questgiver_minimap_show_prepared_packet[0] = UPDATETYPE_VALUES;
	G_questgiver_minimap_show_prepared_packet[9] = (UNIT_END+31)/32;
	G_questgiver_minimap_show_prepared_packet[10 + (UNIT_DYNAMIC_FLAGS / 8)] = 1 << ( UNIT_DYNAMIC_FLAGS % 8 );

	//we do not spend time to test if buffer is enough big. So choose a huge buffersize
	G_send_packet.resize_if_too_small(1024000);
	G_recv_packet.resize_if_too_small(1024000);
	if(LOG.GetScreenLogging())
	{
		// clear logfile
		FILE *pFile = fopen("worldlog.txt", "w+");
		fclose(pFile);
	}
	srand(time(NULL));
	//start advertising our server (we add a new line in the realm table = realistserver)
	realm_id = G_dbi_r->add_realm(realm_name,realm_ip,realm_port,realm_icon,realm_color,realm_timezone,mClientLimit);
	//load G_maps 
    LOG.outString ("WORLD: Started loading maps");
	G_max_map_id = G_dbi_w->load_maps(); //load all G_maps and init them (they will be empty)
	//load static loot templates.!!load before creatures
	LOG.outString ("WORLD: Started loading loot templates");
	G_dbi_w->load_static_loot_templates();
	//load quest templates = before creature prototypes
	LOG.outString ("WORLD: Started loading quest templates");
	G_dbi_w->load_quest_templates();
	//load spell info. before creature templates
    LOG.outString ("WORLD: Started loading spell info");
	G_dbi_w->load_spell_templates();
	//load creature prototypes
    LOG.outString ("WORLD: Started loading creature prototypes");
	G_dbi_w->load_creature_templates();
	//load creature sell stuff after prototypes and before spawns
    LOG.outString ("WORLD: Started loading creature sell items");
	G_dbi_w->load_vendor_items();
	//load creature sell stuff after prototypes and before spawns
	LOG.outString ("WORLD: Started loading creature train spells");
	G_dbi_w->load_vendor_spells();
	//load NPC texts
	LOG.outString ("WORLD: Started loading NPC text");
	G_dbi_w->load_NPC_text();
	//load faction relations (before creatures)
    LOG.outString ("WORLD: Started loading faction relations");
	G_dbi_w->load_faction_relations();
	//spawn creatures
    LOG.outString ("WORLD: Started spawning creatures");
	G_dbi_w->spawn_creatures();
	//load graveyards : players respawn locations, also spawn a spirit healer here
	LOG.outString ("WORLD: Started loading graveyards");
	G_dbi_w->load_graveyards();
	//load go prototypes
    LOG.outString ("WORLD: Started loading game object templates");
	G_dbi_w->load_go_templates();
	//spawn game objects
    LOG.outString ("WORLD: Started spawning game objects");
	G_dbi_w->spawn_gos();
	//load item templates
    LOG.outString ("WORLD: Started loading item templates");
	G_dbi_w->load_item_temlates();
	//load areas
    LOG.outString ("WORLD: Started loading areas for explore system");
	G_dbi_w->load_area_info();
	//load creature mods
    LOG.outString ("WORLD: Started loading creature mods");
	G_dbi_w->load_creature_mods();
	//load emote animations
    LOG.outString ("WORLD: Started loading emote animations");
	G_dbi_w->load_emote_text();
	//load item mods
	LOG.outString ("WORLD: Started loading item mods");
	G_dbi_w->load_item_mods();
	//load custom area triggers (server sided supported)
	LOG.outString ("WORLD: Started loading custom area triggers");
	G_dbi_w->load_custom_areatriggers();
	//load item random propertys
	LOG.outString ("WORLD: Started loading item random properties");
	G_dbi_w->load_item_random_propertys();
	//precreate map spirit healer packets that will be sent to player each time somebody dies
	for(uint32 i=0;i<G_max_map_id;i++)
		if(G_maps[i])
			G_maps[i]->create_spirit_healer_create_packet();
}

void WorldServer::eventStart () 
{
	if (!G_dbi_r)
		G_dbi_r = DATABASE.createDatabaseInterface_r ();
	if (!G_dbi_w)
		G_dbi_w = DATABASE.createDatabaseInterface_w ();
	SetInitialWorldSettings();
}

void WorldServer::eventStop () 
{
	if(realm_id!=0)
	{
		DatabaseInterface *t_dbi = DATABASE.createDatabaseInterface_r (); 
		t_dbi->del_realm(realm_id);
		DATABASE.removeDatabaseInterface(t_dbi); 
		realm_id=0;
	}
	if (G_dbi_r)
	{
		DATABASE.removeDatabaseInterface (G_dbi_r);
		G_dbi_r = NULL;
	}
	if (G_dbi_w)
	{
		DATABASE.removeDatabaseInterface (G_dbi_w);
		G_dbi_w = NULL;
	}
}

//update fTime is equal or greater then WORLD_MIN_UPDATE_INTERVAL
void WorldServer::Update (uint32 fTime)
{
	ClientSet::iterator t_c_itr; //temp client iterator. Declared here only to not declare it at each update 
	GameClient *pClient;
#ifdef _DEBUG
	uint32 start_turn,end_turn,update_time;
	start_turn=GetMilliseconds();
#endif
//	updateGameTime();
//	update_Timers(fTime);
	G_turn_id+=fTime;
	G_cur_time_ms = GetMilliseconds();
	G_cur_time = time(NULL);
	//first update restless creatures so they may add their changes to the clients
	Creature_Node *restless_itr=G_creature_always_active.first;
	while(restless_itr)
	{
		restless_itr->value->update();
		restless_itr = restless_itr->next;
	}
	//update each player and their block
	//players will call update for that block
	//when updating block we update creatures and objects within it
	//players will add their update data to other players
	for (t_c_itr = mClients.begin(); t_c_itr != mClients.end(); t_c_itr++)
		if(((GameClient*)(*t_c_itr))->IsInWorld())
		{
			pClient=((GameClient*)(*t_c_itr));
			//logout chars that requested it
			if (((GameClient*)(*t_c_itr))->ShouldLogOut(G_cur_time))
			{
				G_send_packet.opcode = SMSG_LOGOUT_COMPLETE;
				G_send_packet.length = 0;
				((GameClient*)(*t_c_itr))->SendMsg(&G_send_packet);
				LogoutPlayer(((GameClient*)(*t_c_itr)));
				((GameClient*)(*t_c_itr))->logoutTime = 0;
#ifdef _DEBUG
				LOG.outString ("WORLD: sent SMSG_LOGOUT_COMPLETE Message");
#endif
			}
			else if (pClient->IsInWorld())
				G_maps[pClient->mCurrentChar->map_id]->update_block(pClient->mCurrentChar,fTime);
		}
#ifdef _DEBUG
		update_time = GetMilliseconds();
#endif
		//send all non empty update blocks to the clients
		for (t_c_itr = mClients.begin(); t_c_itr != mClients.end(); t_c_itr++)
		{
			pClient=((GameClient*)(*t_c_itr));
			if (pClient->IsInWorld() && pClient->compressed_update.get_length()!=0)
			{
				pClient->compressed_update.build_packet();
				pClient->SendMsg( pClient->compressed_update.build_packet() );
				//we clear the buffer at the end of turn so events may add data anytime until next turn end
				pClient->compressed_update.clear();
			}
		}		
#ifdef _DEBUG
	end_turn=GetMilliseconds();
//	if(end_turn-start_turn>0)
//		LOG.outString ("WORLD: requred update time for \n \t 1)total = %u ms \n \t 2)update world = %u \n \t 3)send updates = %u",end_turn-start_turn,update_time-start_turn,end_turn-update_time);
#endif
}


void WorldServer::server_sockevent(nlink *cptr, unsigned short revents, void * myNet)
{
	(void)cptr;
	Socket * client;
	nlink *ncptr;
	if(revents & PF_READ)
	{
		client = ( (Socket *) myNet)->AcceptConnection ();
		if (!client) 
		{
            LOG.outString ("SERVER: Client not created");
			return;
		}
		ulong nonblockingstate = true;
		so_ioctl (client->GetHandle(), FIONBIO, &nonblockingstate);
		ncptr = new nlink;	// client one
		if(ncptr == NULL)
			return;
		memset(ncptr, 0, sizeof(*ncptr));
		ncptr->type = RCLIENT;
		ncptr->fd = client->GetHandle();
		nlink_insert(ncptr);
		GameClient *pClient = new GameClient();
		pClient->BindNI(client);
		mClients.insert(pClient);
		LOG.outString ("SERVER: Client added ");
		//updateRealm ("WoW Realm");
		ncptr->pClient = pClient;
		G_send_packet.opcode = SMSG_AUTH_CHALLENGE;
		G_send_packet.data32[0] = 0x336E6295;
		G_send_packet.length = 4;
		pClient->SendMsg (&G_send_packet);
		LOG.outString ("WORLD: connection! Sent Auth Challenge.");
	}
}

void WorldServer::LogoutPlayer(GameClient *pClient)
{
	//of we logout from char enum screen, we do not have a selected char yet
	if(pClient->mCurrentChar!=NULL)
		pClient->mCurrentChar->on_logout();
	//set client object to not use any chars
	//we have to save,destroy the character and his pet too
		//empty char list for this client(should already be empty)
	pClient->ClearCharacterSnapshotList();
	G_Object_Pool.Release_Character(pClient->mCurrentChar);
	pClient->mCurrentChar = NULL;
	pClient->m_isInWorld = 0;
	pClient->rcvLogged = 0;
	//delete all item instances of this char
}

void WorldServer::disconnect_client (struct nlink *cptr)
{
	GameClient * pClient = static_cast < GameClient * > (cptr->pClient);
	if (pClient->isAuth() && pClient->isLoggedIn())
		LogoutPlayer(pClient);
	pClient->BindAcctID(-1);
	mClients.erase (pClient);
	delete pClient;
	LOG.outString ("WORLD: Client Quit!");
	Server::disconnect_client (cptr);
}

void WorldServer::disconnect_client(GameClient *pClient)
{
	NlinkList::iterator itr;
	nlink *cptr;
	if (pClient->isAuth() && pClient->isLoggedIn())
		LogoutPlayer(pClient);
	pClient->BindAcctID(-1);
	mClients.erase (pClient);
	//iterate through the links and find the nlink
	for (itr = mLinks.begin(); itr != mLinks.end(); itr++)
		if(((nlink*)(*itr))->pClient == pClient)
		{
			cptr = ((nlink*)(*itr));
			break;
		}
	delete pClient;
	LOG.outString ("WORLD: Client Quit!");
	Server::disconnect_client (cptr);
}

void WorldServer::set_realm_settings(const char *realm,const char *ip,uint32 port,uint8 icon,uint8 color,uint8 timezone,uint32 player_limit)
{
	strcpy(realm_name,realm);
	strcpy(realm_ip,ip);
	realm_port = port;
	realm_icon = icon;
	realm_color = color;
	realm_timezone = timezone;
	mClientLimit = player_limit;
}

Character* WorldServer::get_character_by_name(const char* char_name)
{
	ClientSet::iterator itr;
	for (itr = mClients.begin(); itr != mClients.end(); itr++)
		if(((GameClient*)(*itr))->IsInWorld() && strcmpi((((GameClient*)(*itr))->mCurrentChar->name),char_name)==0)
			return (((GameClient*)(*itr))->mCurrentChar);
	return NULL;
}

//used in crash situation
void WorldServer::save_loged_in_chars()
{
	ClientSet::iterator itr;
	for (itr = mClients.begin(); itr != mClients.end(); itr++)
		if(((GameClient*)(*itr))->IsInWorld())
			((GameClient*)(*itr))->mCurrentChar->save_to_db();
}

//make sure this is a valid pointer
uint8 WorldServer::Check_Player_exist(Character *p_char)
{
	ClientSet::iterator itr;
	for (itr = mClients.begin(); itr != mClients.end(); itr++)
		if(((GameClient*)(*itr))->mCurrentChar==p_char)
			return 1;
	return 0;
}
