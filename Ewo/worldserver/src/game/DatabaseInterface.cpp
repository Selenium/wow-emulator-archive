// Copyright (C) 2006 Team Evolution
#include "DatabaseInterface.h"
#include "Database.h"
#include <mysql.h>

DatabaseInterface::DatabaseInterface (void * db) : mDatabaseConnection ((MYSQL *)db) { }

DatabaseInterface::~DatabaseInterface () {
   mysql_close ((MYSQL *)mDatabaseConnection);
}

int DatabaseInterface::doQuery (const char * query) {
#ifdef _DEBUG
//   LOG.outString ((std::string("SQL: ") + query).c_str ());
#endif
   mysql_query ((MYSQL *)mDatabaseConnection, query);
   const char *err = mysql_error((MYSQL*)mDatabaseConnection);
   if (err && *err)
      LOG.outString ("SQL ERROR: %s", err);
   return mysql_field_count ((MYSQL *)mDatabaseConnection);
}

uint64 DatabaseInterface::doQueryId (const char * query) 
{
#ifdef _DEBUG
//   LOG.outString ((std::string("SQL: ") + query).c_str ());
#endif
   mysql_query ((MYSQL *)mDatabaseConnection, query);
   const char *err = mysql_error((MYSQL*)mDatabaseConnection);
   if (err && *err)
      LOG.outString ("SQL ERROR: %s", err);
   return mysql_insert_id ((MYSQL *)mDatabaseConnection);
}

//get hash if player is online
void DatabaseInterface::get_account_hash(const char* username,char *hash_store)
{
   char query[300];
   sprintf(query, "SELECT ssh_hash FROM account where online!='0' and username='%s'",username);
   doQuery(query);
   MYSQL_RES *res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
   uint16 numrows = (uint16)mysql_num_rows (res);
   MYSQL_ROW row = mysql_fetch_row(res);
   if(numrows==1 && res!=NULL && row!=NULL) 
	   strcpy(hash_store,row[0]);
   mysql_free_result (res);
}

void DatabaseInterface::set_player_offline(uint32 acc_id,uint32 char_id)
{
	char query[300];
	//set account offline
    sprintf(query, "UPDATE account set online='0' where id='%u'",acc_id);
    doQuery(query);
	//set character offline (also set timestamp when going offline)
    sprintf(query, "UPDATE character_instances set online='0',time_logoff='%u',time_played=(time_played+(%u-time_login)) where id='%u'",(uint32)time(NULL),(uint32)time(NULL),char_id);
    doQuery(query);
}

void DatabaseInterface::set_player_online(uint32 char_id)
{
	char query[300];
	//set character online (also set timestamp when going online)
    sprintf(query, "UPDATE character_instances set online='1',time_login='%u' where id='%u'",(uint32)time(NULL),char_id);
    doQuery(query);
}


uint32 DatabaseInterface::add_realm(const char *realm,const char *ip,uint32 port,uint8 icon,uint8 color,uint8 timezone,uint32 player_limit)
{
   char query[300];
   MYSQL_RES *res;
   uint16 numrows;
   MYSQL_ROW row;
   uint32 ret=0;
//   sprintf(query, "INSERT INTO REALM (name,ip,port,icon,colour,timezone,player_limit) values ('%s','%s','%d','%d','%d','%d','%d')",realm,ip,port,icon,color,timezone,player_limit);
   sprintf(query, "UPDATE realm SET online=1 WHERE name='%s' AND address='%s:%d'", realm, ip, port);
   doQuery(query);   
//   return (uint32)mysql_insert_id ((MYSQL *)mDatabaseConnection);
   sprintf(query, "SELECT address FROM realm WHERE name='%s' AND address='%s:%d'", realm, ip, port);
   doQuery(query);
   res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
   numrows = (uint16)mysql_num_rows (res);
   if(numrows!=0)
   {
		row = mysql_fetch_row(res);
		ret=(int)atoi(row[0]);
		mysql_free_result (res);
   }
   return ret;
}

void DatabaseInterface::del_realm(uint32 id)
{
   char query[300];
   sprintf(query, "Update REALM set online=0 where id='%d'",id);
   doQuery(query);   
}

int DatabaseInterface::IsNameTaken(char * charname) 
{
   int answer;
   char query[300];
   strcpy(query,"");
   sprintf(query, "SELECT count(id) FROM character_instances WHERE name = '%s'", charname);
   doQuery(query);
   MYSQL_RES *res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
   MYSQL_ROW row;
   row = mysql_fetch_row (res);
   answer = (int)atoi(row[0]);
   mysql_free_result (res);
   return answer;
}


// Logs in a client with username and password
int DatabaseInterface::Login(char* username, char* ip)
{
   LOG.outString ("DB: Checking username...");
   char query[300];
   int ret;
   strcpy(query, "");
   sprintf(query, "SELECT id,online FROM account WHERE username='%s'", username);
   doQuery(query);
   MYSQL_RES *res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
   MYSQL_ROW row;
   if (!res)
      return -2;  //account does not exist
   if (res->row_count == 1)
   { // Match!
      row = mysql_fetch_row (res);
	  if(strcmp(row[1],"0"))
	  {
		ret=atoi(row[0]);
		mysql_free_result (res);
		//update last ip
		sprintf(query, "UPDATE account set lastip='%s' WHERE id='%d'", ip,ret);
		doQuery(query);
	  }
	  else ret = -3; //account already online
      return ret;
   }
   return -1; //there are more then 1 account matches
}

int DatabaseInterface::account_client_addons(unsigned int accoint_id)
{
	char query[300];
	int ret;
	sprintf(query, "SELECT TBC_acc FROM account WHERE id='%u'", accoint_id);
	doQuery(query);
	MYSQL_RES *res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
	MYSQL_ROW row;
	if (!res)
		return 0;  //account does not exist
	row = mysql_fetch_row (res);
	ret= atoi(row[0]); 
	mysql_free_result (res);
printf("account id=%u, state %u\n",accoint_id,ret);
	return ret; //there are more then 1 account matches
}

void DatabaseInterface::BanIP(char* ip)
{
   char query[300];
   strcpy(query, "");
   sprintf(query, "INSERT INTO firewall SET ip='%s',allow='0'", ip);
   doQuery(query);
}

void DatabaseInterface::AllowIP(char* ip)
{
   char query[300];
   strcpy(query, "");
   sprintf(query, "DELETE FROM firewall WHERE ip='%s'", ip);
   doQuery(query);
}

//load all chars for an account into gameclients char list
void DatabaseInterface::refresh_char_snapshots(GameClient *client,uint32 account_id)
{
   char query[300];
   sprintf(query,"select id from character_instances where account_id='%d' and realm_id='%u' order by name desc",account_id,WORLDSERVER.realm_id);
   doQuery(query);
   MYSQL_RES *res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
   MYSQL_ROW row;
   uint32 db_id;
   while(row = mysql_fetch_row (res))
   {
      db_id = atoi(row[0]);
	  if(!client->has_character_snapshot(db_id))
	  {
		  Char_snapshot *t_snap=new Char_snapshot;
		  t_snap->load_snapshot(db_id);
		  client->m_charsnapshots.push_front(t_snap);
	  }
   }
   mysql_free_result (res);
}

uint32 DatabaseInterface::number_of_char_for_account(uint32 account_id)
{
   char query[300];
   sprintf(query,"select count(id) from character_instances where account_id='%d' and realm_id='%u'",account_id,WORLDSERVER.realm_id);
   doQuery(query);
   MYSQL_RES *res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
   MYSQL_ROW row;
   uint32 ret;
   row = mysql_fetch_row (res);
   ret = atoi(row[0]);
   mysql_free_result (res);
   return ret;
}

void DatabaseInterface::load_emote_text()
{
   char query[300];
   MYSQL_RES *res ;
   MYSQL_ROW row;
   uint32 row_number=1;
   //get the biggest map_id
   sprintf(query,"SELECT id from emote_text order by id desc limit 0,1");
   doQuery(query);
   res = mysql_store_result ((MYSQL *)mDatabaseConnection);
   row = mysql_fetch_row (res);
   G_max_emote_anim = atoi(row[0])+1;
   G_emote_anim = (uint32*)malloc(sizeof(uint32)*G_max_emote_anim);
   memset(G_emote_anim,0,sizeof(uint32)*G_max_emote_anim);
   mysql_free_result (res);
   sprintf(query,"SELECT id,emote_anim from emote_text");
   doQuery(query);
   res = mysql_store_result ((MYSQL *)mDatabaseConnection);
   while(row = mysql_fetch_row (res))
   {
	   G_emote_anim[atoi(row[0])] = atoi(row[1]);
	   row_number++;
   }
#ifdef _DEBUG
   LOG.outString ("Loaded %u emote animations\n",row_number);
#endif
   mysql_free_result (res);
}

void DatabaseInterface::add_character (Character *newChar) 
{
   std::stringstream ss;
   uint64	db_id;
   ss << "INSERT INTO character_instances "
	   << "(account_id,data,name,position_x,bind_x,position_y,bind_y,position_z,bind_z,orientation,bind_orientation,map_id,bind_map_id,zone_id,bind_area_id,reputation,reputation_val,actionbutton,state,realm_id,enum_snapshot) "
	   << "VALUES ('" 
	   << newChar->pClient->m_accountId << "',"
	   << "'0','"
	   << newChar->name << "',"
	   << "'0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','"
	   << WORLDSERVER.realm_id << "','0')";
   db_id = doQueryId(ss.str ().c_str ());
   newChar->db_id = (uint32)db_id;
   save_character(newChar);

}

void DatabaseInterface::load_character(Character *character)
{
	int i;
   char query[300];
   sprintf(query,"SELECT id,account_id,data,name,position_x,bind_x,position_y,bind_y,position_z,bind_z,orientation,bind_orientation,map_id,bind_map_id,zone_id,bind_area_id,reputation,reputation_val,actionbutton,state,corpse_x,corpse_y,corpse_z,corpse_o FROM character_instances WHERE id='%d'",character->db_id);
   doQuery(query);
   MYSQL_RES *res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
   MYSQL_ROW row;
   Item	*new_item;
   if(res)
   {
      row = mysql_fetch_row (res);
	  if(!row)
	  {
		  printf("Could not load character from db\n");
		  return;
	  }
//	  character->db_id=atoi(row[0]);
//	  character->account_id=atoi(row[1]);
      LoadValues32(character->data32, row[2],PLAYER_END);
	  safe_strcpy(character->name,row[3],MAX_CHAR_NAME_LENGTH);
	  character->areatrigger_lastcheck_x = character->pos_x = (float)atof(row[4]);
      character->bind_x = (float)atof(row[5]);
      character->areatrigger_lastcheck_y = character->pos_y = (float)atof(row[6]);
      character->bind_y = (float)atof(row[7]);
      character->areatrigger_lastcheck_z = character->pos_z = (float)atof(row[8]);
      character->bind_z = (float)atof(row[9]);
      character->orientation = (float)atof(row[10]);
      character->bind_orientation = (float)atof(row[11]);
      character->map_id = atoi(row[12]);
      character->bind_map_id = atoi(row[13]);
      character->zone_id = atoi(row[14]);
      character->bind_area_id = atoi(row[15]);
      LoadValues8(character->reputation, row[16],NUMBER_OF_FACTIONS);
	  LoadValues32(character->reputation_val, row[17],NUMBER_OF_FACTIONS);
	  LoadValues32(character->actionbuttons, row[18],NUMBER_OF_ACTION_BUTTONS);
	  character->state1 = atoi(row[19]);
	  character->corpse_x = (float)atof(row[20]);
	  character->corpse_y = (float)atof(row[21]);
	  character->corpse_z = (float)atof(row[22]);
	  character->corpse_o = (float)atof(row[23]);
      mysql_free_result (res);
   }
   character->set_guid();//while loading values we lost the guid
   character->data32[UNIT_FIELD_SUMMON]=0;
   character->data32[UNIT_FIELD_SUMMON+1]=0;
   //clear all aura slots
   for(i=0;i<MAX_AURAS;i++)
	   character->data32[UNIT_FIELD_AURA+i]=0;
   for(i=0;i<8;i++)
	   character->data32[UNIT_FIELD_AURAFLAGS+i]=0;
   for(i=0;i<12;i++)
   {
	   character->data32[UNIT_FIELD_AURALEVELS+i]=0;
	   character->data32[UNIT_FIELD_AURAAPPLICATIONS+i]=0;
   }
   character->data32[UNIT_FIELD_AURASTATE]=0;
   //used by stat recalc functions so init them before loading rest
   character->player_powertype = (uint8)((character->data32[UNIT_FIELD_BYTES_0] >> 24) & 0xFF);
   //remove mods so further loading will restore them
   character->cur_spell.set_caster(character->getGUID(),character->data32[UNIT_FIELD_FACTIONTEMPLATE]);
   character->instant_spell.set_caster(character->getGUID(),character->data32[UNIT_FIELD_FACTIONTEMPLATE]);
   //in this state we have on ourself item and spell affects affecting basic and dinamic stats
   character->remove_mods();
   //recalc base stats. Just to make sure no error occured
   character->recalc_base_stats();
   //load spellbook
   sprintf(query,"SELECT spell_id from character_spell_instances WHERE char_id='%d'",character->db_id);
   doQuery(query);
   res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
   while(row = mysql_fetch_row (res))
	   character->spellbook.add(atoi(row[0]));   
   mysql_free_result (res);
   //load items
   memset(&character->data32[PLAYER_VISIBLE_ITEM_1_CREATOR],0,(PLAYER_FARSIGHT-PLAYER_VISIBLE_ITEM_1_CREATOR)*4);
   //important to load items in ascending order so bags will be loaded before the items in the bags
   sprintf(query,"SELECT data,item_data,slot_index,bag_index from character_item_instances WHERE char_id='%d' order by bag_index asc",character->db_id);
   doQuery(query);
   res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
   while(row = mysql_fetch_row (res))
   {
	   //create new item
	   new_item = G_Object_Pool.Get_fast_New_item();
	   LoadValues32(new_item->data32, row[0],ITEM_END);
	   LoadValues32(new_item->item_data32, row[1],ITEM_FIELDS_END);
	   new_item->on_load_from_template();
	   new_item->on_change_owner(character->getGUID(),NULL);
//printf("loaded item with name : %s \n",(char*)&new_item->item_data32[ITEM_NAME]);
	   character->add_item(new_item,atoi(row[2]),atoi(row[3]));
//printf("added item_id %u to slot %u slot value is %u\n",new_item->item_data32[ITEM_ID],atoi(row[2]),character->data32[PLAYER_VISIBLE_ITEM_1_0 + (atoi(row[2]) * PLAYER_VISIBLE_ITEM_SIZE)]);
   }
   mysql_free_result (res);
   //load finished quests
   sprintf(query,"SELECT quest_id from character_quest_instances_finished WHERE char_id='%d'",character->db_id);
   doQuery(query);
   res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
   while(row = mysql_fetch_row (res))
	   character->quests_finished.add(atoi(row[0]));
   mysql_free_result (res);
   //load active quests. !!load them after loading items
   sprintf(query,"SELECT data from character_quest_instances WHERE char_id='%d'",character->db_id);
   doQuery(query);
   res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
   while(row = mysql_fetch_row (res))
   {
	   Quest_instance_Node *new_node;
	   new_node = new Quest_instance_Node;
	   LoadValues32((uint32*)&new_node->value, row[0],sizeof(Quest_instance)/4);
	   character->quests_started.add(new_node);
   }
   //check if meantime we were logged out quest state has changed
   character->quests_started.refresh_items_gathered();
   Quest_instance_Node *itr=character->quests_started.first;
   while(itr)
   {
	   character->quests_started.check_finished(itr);
	   itr = itr->next;
   }
   mysql_free_result (res);
   //update rage conversion on lvl change 
   character->on_change_lvl();
}

//load 1 char from db and initialize the given char with it
void DatabaseInterface::load_character_affects(Character *character)
{
   char query[300];
   MYSQL_RES *res;
   MYSQL_ROW row;
   //load aura instances if they are still active
   //!!time is saved in seconds and not in ms
   sprintf(query,"SELECT distinct spell_id,end_time,cast_flags from character_affect_instances WHERE char_id='%d'",character->db_id);
   doQuery(query);
   res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
   while(row = mysql_fetch_row (res))
   {
//	   uint32 cur_end_time=(uint32)atoi(row[1]);
//	   printf("trying to load aura, cur time is %u, end time is %u(%d),diffrence is %u\n",G_cur_time,cur_end_time,cur_end_time,G_cur_time-cur_end_time);
	   if(G_cur_time<(uint32)atoi(row[1]))
	   {
//		   printf("aura is supposed to load\n");
		   character->cur_spell.cast_flags = atoi(row[2]);
		   character->cur_spell.char_instant_nomana_cast(atoi(row[0]),atoi(row[1]));
	   }
//	   else printf("aura expired\n");
   }
   character->cur_spell.cast_flags=0;
   mysql_free_result (res);
	//load cooldowns
	sprintf(query,"SELECT spell_id,end_time from character_spell_cooldown_instances WHERE char_id='%d'",character->db_id);
	doQuery(query);
	res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
	while(row = mysql_fetch_row (res))
		if(G_cur_time<(uint32)atoi(row[1]))
		{
			character->cur_spell.msg_spell_cooldown(atoi(row[0]),(atoi(row[1]) - G_cur_time)*1000);
			character->spell_cooldowns.add(atoi(row[0]),(atoi(row[1]) - G_cur_time)*1000);
		}
	mysql_free_result (res);
}

void DatabaseInterface::save_character(Character *character)
{
   std::stringstream ss;
   uint32 index,i;
   char query[300];
   Item *cur_item,*cur_bag;
   uint32 bag_index;

   //!!!this will save char with item/spells having their affect applied
   ss << "UPDATE character_instances set data='";
   for ( index = 0; index < PLAYER_END; index ++)
	   ss << character->data32[index] << " ";
   ss << "', "
	   << "position_x='" << character->pos_x << "',"
	   << "bind_x='" << character->bind_x << "',"
	   << "position_y='" << character->pos_y << "',"
	   << "bind_y='" << character->bind_y << "',"
	   << "position_z='" << character->pos_z << "',"
	   << "bind_z='" << character->bind_z << "',"
	   << "orientation='" << character->orientation << "',"
	   << "bind_orientation='" << character->bind_orientation << "',"
	   << "map_id='" << character->map_id << "',"
	   << "bind_map_id='" << character->bind_map_id << "',"
	   << "zone_id='" << character->zone_id << "',"
	   << "bind_area_id='" << character->bind_area_id << "',"
	   << "reputation='" ;
   for ( index = 0; index < 64 ; index ++)
	   ss << (uint32)character->reputation[index] << " ";
   ss << "',"
	   << "reputation_val='" ;
   for ( index = 0; index < 64 ; index ++)
	   ss << (uint32)character->reputation_val[index] << " ";
   ss << "',"
	   << "actionbutton='" ;
   for ( index = 0; index < 120 ; index ++)
	   ss << (uint32)character->actionbuttons[index] << " ";
   ss << "',state='" << character->state1 << "'";
   ss  << ",corpse_x='" << character->corpse_x << "'"
	   << ",corpse_y='" << character->corpse_y << "'"
	   << ",corpse_z='" << character->corpse_z << "'"
	   << ",corpse_o='" << character->corpse_o << "'";
   ss << " where id='" << character->db_id << "'";
   doQuery (ss.str ().c_str ());
   //save spells
		//first dump old ones
   sprintf(query,"DELETE from character_spell_instances WHERE char_id='%d'",character->db_id);
   doQuery(query);
		//insert new ones
   spell_book_node *kur=character->spellbook.first;
   while(kur)
   {
	   sprintf(query,"INSERT INTO character_spell_instances (char_id, spell_id) VALUES ('%d','%d')",character->db_id,kur->spell_id);
       doQuery(query);
	   kur=kur->next;
   }
    //dump old items
   sprintf(query,"DELETE from character_item_instances WHERE char_id='%d'",character->db_id);
   doQuery(query);
	//save current items
   bag_index=0; //store items that are on char
   for ( index = PLAYER_FIELD_INV_SLOT_HEAD+0; index < PLAYER_FIELD_INV_SLOT_HEAD + BANK_SLOT_BAG_END*2; index +=2)
	   if(character->data32[index]!=0)
	   {
		   cur_item = (Item *)character->data32[index]; //get a lock on the item
		   if(cur_item->data32[ITEM_FIELD_CREATOR]!=0)
			   continue;
		   //save item data
		   ss.rdbuf()->str("");
           ss << "INSERT INTO character_item_instances "
			  << " (char_id, data, item_data,slot_index,bag_index) "
			  << " VALUES " 
			  << "('" << character->db_id << "','";
		   for ( i = 0; i < ITEM_END; i ++)
			   ss << cur_item->data32[i] << " ";
		   ss << "','";
		   //save item personal data
		   for ( i = 0; i < ITEM_FIELDS_END; i ++)
			   ss << cur_item->item_data32[i] << " ";
		   ss << "','" << (uint32)((index - (PLAYER_FIELD_INV_SLOT_HEAD+0))/2);
		   ss << "','" << bag_index;
		   ss << "')";
	       doQuery(ss.str ().c_str ());
	   }
   //store items from the bags
	for ( index = PLAYER_FIELD_INV_SLOT_HEAD+INVENTORY_SLOT_BAG_START*2; index < PLAYER_FIELD_INV_SLOT_HEAD + INVENTORY_SLOT_BAG_END*2; index +=2)
	{
		bag_index++;
	   if(character->data32[index]!=0)
	   {
		   cur_bag = (Item *)character->data32[index];
		   if(!(cur_bag->state1 & ITEM_STATE_CONVERTED_TO_CONTAINER))
			   continue;
		   //parse bag content and save
		   uint32 c_slot;
		   for(c_slot=CONTAINER_FIELD_SLOT_1;c_slot<CONTAINER_END;c_slot+=2)
			   if(cur_bag->data32[c_slot]!=0)
			   {
				   cur_item = (Item *)cur_bag->data32[c_slot]; //get a lock on the item
				   if(cur_item->data32[ITEM_FIELD_CREATOR]!=0)
					   continue;
				   //save item data
				   ss.rdbuf()->str("");
				   ss << "INSERT INTO character_item_instances "
					   << " (char_id, data, item_data,slot_index,bag_index) "
					   << " VALUES " 
					   << "('" << character->db_id << "','";
				   for ( i = 0; i < ITEM_END; i ++)
					   ss << cur_item->data32[i] << " ";
				   ss << "','";
				   //save item personal data
				   for ( i = 0; i < ITEM_FIELDS_END; i ++)
					   ss << cur_item->item_data32[i] << " ";
				   ss << "','" << (uint32)((c_slot-CONTAINER_FIELD_SLOT_1)/2);
				   ss << "','" << (bag_index+18);
				   ss << "')";
				   doQuery(ss.str ().c_str ());
			   }
	   }
	}
    //dump old auras
    sprintf(query,"DELETE from character_affect_instances WHERE char_id='%d'",character->db_id);
    doQuery(query);
    //save auras
	Spell_Affect_node *affect_itr;
	affect_itr = character->affect_list->first;
	while(affect_itr)
	{
		if(!(affect_itr->cast_flags & (CAST_ACTION_FLAG_ITEM_ENCHANTMENT)) || !((affect_itr->cast_flags & CAST_ACTION_FLAG_ALWAYS_ACTIVE) && (affect_itr->caster_guid!=character->getGUID())))
		{
			ss.rdbuf()->str("");
			ss << "INSERT INTO character_affect_instances (char_id, end_time, spell_id,cast_flags"
				<< ") VALUES ("
				<< "'" << character->db_id << "',"
				<< "'" << affect_itr->end_time_sv << "',"
				<< "'" << affect_itr->prototype->spell_id << "',"
				<< "'" << affect_itr->cast_flags << "'"
				<< ")";
	//printf("the query :%s,current time in ms %u\n",ss.str().c_str(),G_cur_time_ms);
			doQuery(ss.str ().c_str ());
		}
		affect_itr = affect_itr->next;
	}
	//dump old cooldown values
	sprintf(query,"DELETE from character_spell_cooldown_instances WHERE char_id='%d'",character->db_id);
	doQuery(query);
	//save spell cooldowns
	spell_cooldown_node *cooldown_itr;
	cooldown_itr = character->spell_cooldowns.first;
	while(cooldown_itr)
	{
		//insert data into db
		ss.rdbuf()->str("");
		ss << "INSERT INTO character_spell_cooldown_instances (char_id, spell_id, end_time"
			<< ") VALUES ("
			<< "'" << character->db_id << "',"
			<< "'" << cooldown_itr->spell_id << "',"
			<< "'" << cooldown_itr->end_time_stamp << "'"
			<< ")";
		doQuery(ss.str ().c_str ());
		cooldown_itr = cooldown_itr->next;
	}
	//save finished quests
	sprintf(query,"delete from character_quest_instances_finished WHERE char_id='%d'",character->db_id);
	doQuery(query);
	Quest_id_Node *q_id_iter=character->quests_finished.first;
	while(q_id_iter)
	{
		sprintf(query,"insert into character_quest_instances_finished (char_id,quest_id) values ('%d','%u')",character->db_id,q_id_iter->value);
		doQuery(query);
		q_id_iter = q_id_iter->next;
	}
	//save active quests
	sprintf(query,"delete from character_quest_instances WHERE char_id='%d'",character->db_id);
	doQuery(query);
	Quest_instance_Node *q_ins_iter=character->quests_started.first;
	while(q_ins_iter)
	{
		ss.rdbuf()->str("");
		uint32	*datap=(uint32*)&q_ins_iter->value;
		ss << "insert into character_quest_instances (data,char_id) values ('";
		for(i=0;i<(sizeof(Quest_instance)/4);i++)
			ss << datap[i] <<" ";
		ss << "','" << character->db_id << "')";
		doQuery(ss.str().c_str());
		q_ins_iter = q_ins_iter->next;
	}
}

void DatabaseInterface::load_character_template(Character *character,uint8 race,uint8 player_class)
{
   char query[300];
//   sprintf(query,"SELECT data,position_x,position_y,position_z,orientation,map_id,zone_id,actionbutton FROM character_template WHERE race='%d' and player_class='%d'",race,player_class);
   sprintf(query,"SELECT display_id,x,y,z,orientation,map_id,zone_id,actionbutton FROM character_template WHERE race='%d' and player_class='%d'",race,player_class);
   doQuery(query);
   MYSQL_RES *res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
   MYSQL_ROW row;
   Item		*new_item;
   uint32	cur_slot_index;
   if(res)
   {
      row = mysql_fetch_row (res);
//      LoadValues32(character->data32, row[0],PLAYER_END);
	  character->data32[UNIT_FIELD_DISPLAYID] = atoi(row[0]);
	  character->pos_x = character->bind_x = (float)atof(row[1]);
	  character->pos_y = character->bind_y = (float)atof(row[2]);
	  character->pos_z = character->bind_z = (float)atof(row[3]);
	  character->orientation = character->bind_orientation = (float)atof(row[4]);
	  character->map_id = character->bind_map_id = atoi(row[5]);
//	  character->zone_id = character->bind_area_id = atoi(row[6]);
	  LoadValues32(character->actionbuttons, row[7],NUMBER_OF_ACTION_BUTTONS);
      mysql_free_result (res);
   }
	if( race==PLAYER_RACE_TYPE_HUMAN || 
		race==PLAYER_RACE_TYPE_DWARF ||
		race==PLAYER_RACE_TYPE_NIGHT_ELF ||
		race==PLAYER_RACE_TYPE_GNOME ||
		race==PLAYER_RACE_TYPE_DRAENEI
		)
	   doQuery("SELECT reputation,reputation_val FROM reputation_template WHERE map_id='0'");
	else   doQuery("SELECT reputation,reputation_val FROM reputation_template WHERE map_id='1'");
   res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
   if(res)
   {
      row = mysql_fetch_row (res);
      LoadValues8(character->reputation, row[0],NUMBER_OF_FACTIONS);
	  LoadValues32(character->reputation_val, row[1],NUMBER_OF_FACTIONS);
      mysql_free_result (res);
   }
   //load spell template
   sprintf(query,"SELECT spell_id from character_spell_template WHERE char_race='%d' and char_class='%d'",race,player_class);
   doQuery(query);
   res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
   while(row = mysql_fetch_row (res))
	   character->spellbook.add(atoi(row[0]));   
   mysql_free_result (res);
   //load item template
	//destroy items if forgot to remove from template
   memset(&character->data32[PLAYER_VISIBLE_ITEM_1_CREATOR],0,(PLAYER_FARSIGHT-PLAYER_VISIBLE_ITEM_1_CREATOR)*4);
   sprintf(query,"SELECT item_template_id,slot_index,stack_count from character_item_template WHERE char_race='%d' and char_class='%d'",race,player_class);
   doQuery(query);
   res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
   while(row = mysql_fetch_row (res))
   if((uint32)atoi(row[0])<G_max_item_id && G_item_prototypes[atoi(row[0])] && atoi(row[1])<BANK_SLOT_BAG_END)
   {
	   //create new item
	   cur_slot_index = atoi(row[1]);
	   new_item = G_Object_Pool.Get_fast_New_item();
	   new_item->create_from_template(G_item_prototypes[atoi(row[0])]);
	   //set stack count for item
	   new_item->data32[ITEM_FIELD_STACK_COUNT] = atoi(row[2]);
	   //add it to player
   	   character->add_item(new_item,cur_slot_index,0);
   }
   mysql_free_result (res);
   sprintf(query,"SELECT skill,cur_val,max_val FROM character_skill_template WHERE race='%d' and player_class='%d'",race,player_class);
   doQuery(query);
	res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
   while(row = mysql_fetch_row (res))
	   character->add_skill(atoi(row[0]),atoi(row[1]),atoi(row[2]));
   mysql_free_result (res);
}

void DatabaseInterface::del_character (uint32 db_id)
{
   char query[300];
   sprintf(query,"DELETE FROM character_instances WHERE id='%d'",db_id);
   doQuery(query);
   //del spells
   sprintf(query,"DELETE from character_spell_instances WHERE char_id='%d'",db_id);
   doQuery(query);
   //delete items
   sprintf(query,"DELETE from character_item_instances WHERE char_id='%d'",db_id);
   doQuery(query);
   //delete auras
   sprintf(query,"DELETE from character_affect_instances WHERE char_id='%d'",db_id);
   doQuery(query);
   //delete cooldowns
   sprintf(query,"DELETE from character_spell_cooldown_instances WHERE char_id='%d'",db_id);
   doQuery(query);
   //delete finsihed quests and active quests
   sprintf(query,"DELETE from character_quest_instances_finished WHERE char_id='%d'",db_id);
   doQuery(query);
   sprintf(query,"DELETE from character_quest_instances WHERE char_id='%d'",db_id);
   doQuery(query);
}

uint32 DatabaseInterface::load_maps()
{
   char query[300];
   MYSQL_RES *res ;
   MYSQL_ROW row;
   uint32 ret=0;
//   uint32 i;
   //get the biggest map_id
   sprintf(query,"SELECT map_id from map order by map_id desc limit 0,1");
   doQuery(query);
   res = mysql_store_result ((MYSQL *)mDatabaseConnection);
   row = mysql_fetch_row (res);
   //alloc memory for our map_holder
   G_max_map_id = atoi(row[0]);
   ret = G_max_map_id+1; //add +1 to it becouse we wanna store the biggest id too
   G_maps = new game_map*[ret]; //make a vector of map pointers to be ablo to store them all
   for(uint32 i=0;i<ret;i++)
	   G_maps[i]=NULL;
   mysql_free_result (res);
   sprintf(query,"SELECT map_id,min_x,max_x,min_y,max_y,cell_size,name from map order by map_id asc");
   doQuery(query);
   res = mysql_store_result ((MYSQL *)mDatabaseConnection);
   //fetch all maps and init them
   while(row = mysql_fetch_row (res))
   {
	   G_maps[atoi(row[0])]=new game_map(atoi(row[0]),atoi(row[1]),atoi(row[2]),atoi(row[3]),atoi(row[4]),atoi(row[5]),row[6]);
	   ASSERT(G_maps[atoi(row[0])]);
#ifdef _DEBUG
       LOG.outString ("added new map to mapmanager with name %u) %s",atoi(row[0]),row[6]);
#endif
   }
   mysql_free_result (res);
   return ret;
}

//check if player is gm. returns gm level for account
uint8 DatabaseInterface::get_gm_ticket(Character *p_char)
{
	uint8 ret=0;
   char query[300];
   MYSQL_RES *res ;
   MYSQL_ROW row;
   sprintf(query,"SELECT gm,gm_text from account where id='%u'",p_char->pClient->m_accountId);
   doQuery(query);
   res = mysql_store_result ((MYSQL *)mDatabaseConnection);
   row = mysql_fetch_row (res);
   ret = atoi(row[0]);
   p_char->pClient->gm_level = ret;
   safe_strcpy(p_char->pClient->gm_text,row[1],MAX_GM_TEXT_LENGTH);
   mysql_free_result (res);
   return ret;
}

void DatabaseInterface::set_char_snapshot(Char_snapshot *from)
{
	std::stringstream ss;
	ss.str( "" );
	ss << "update character_instances set enum_snapshot='";
	for (int i = 0; i < CHARACTER_MAX_ENUM_BLOCK_SIZE; i ++)
		ss << from->buffer[i] << " ";
	ss << "' where id='" << from->db_id << "'";
	doQuery(ss.str().c_str());
}

void DatabaseInterface::get_char_snapshot(Char_snapshot *to)
{
   char query[300];
   MYSQL_RES *res ;
   MYSQL_ROW row;
   sprintf(query,"SELECT enum_snapshot from character_instances where id='%u'",to->db_id);
   doQuery(query);
   res = mysql_store_result ((MYSQL *)mDatabaseConnection);
   row = mysql_fetch_row (res);
   if(row)
	LoadValues32(to->buffer, row[0],CHARACTER_MAX_ENUM_BLOCK_SIZE);
   mysql_free_result (res);
}

////////////////////////////////// BEGIN creature interface /////////////////////////////////////
//load values for 1 creature
void DatabaseInterface::load_creature_templates()
{
//   char query[500];
   MYSQL_RES *res ;
   MYSQL_ROW row;
   creature *new_creature;
   uint32 row_number=0;
	std::stringstream ss;
   //select the max item_id from the table
   doQuery("select id from creature_template order by id desc limit 0,1");
   res = mysql_store_result ((MYSQL *)mDatabaseConnection);
   row = mysql_fetch_row (res);
   G_max_creature_prototypes = atoi(row[0]);
   G_creature_prototypes = (creature**)malloc(sizeof(creature*)*G_max_creature_prototypes);
   memset(G_creature_prototypes,NULL,sizeof(creature*)*G_max_creature_prototypes);
//   sprintf(query,"SELECT id,name,guild,bounding_radius,combat_reach,level_min,level_max,damage_min,damage_max,damage_type,faction,flags1,maxhealth,maxmana,model,npcflags,speed,size,type,family,elite,trainer_type,mount,atack_melee,atack_ranged,loot_template_id,train_class from creature_template order by id asc");
//   doQuery(query);
   ss.str( "" );
   ss << "SELECT id,name,guild,bounding_radius,combat_reach,level_min,level_max,damage_min,damage_max,damage_type,"
	  << "faction,flags1,maxhealth,maxmana,model,npcflags,speed,size,type,family,elite,trainer_type,mount,"
	  << "atack_melee,atack_ranged,loot_template_id,train_class,item_model_1,item_model_2,item_model_3,item_info_1, "
	  << "item_info_2,item_info_3,item_equip_slot_1,item_equip_slot_2,item_equip_slot_3,rezist_0,rezist_1,rezist_2, "
	  << "rezist_3,rezist_4,rezist_5,rezist_6 "
	  << " from creature_template order by id asc";
	doQuery(ss.str().c_str());
   res = mysql_store_result ((MYSQL *)mDatabaseConnection);
   //fetch all templates, alloc space and insert them into a holder list
   while(row = mysql_fetch_row (res))
   {
	   //alloc space for it
	   new_creature = new creature;
	   ASSERT(new_creature);
	   new_creature->static_data = new creature_static_data_holder;
	   ASSERT(new_creature->static_data);
	   //load it's data
	   uint32 template_id=atoi(row[0]);
	   new_creature->data32[OBJECT_FIELD_ENTRY]=template_id;
	   new_creature->db_id = atoi(row[0]);
	   new_creature->name = (char*)malloc(strlen(row[1])+1);
	   new_creature->static_data->guild = (char*)malloc(strlen(row[2])+1);
	   safe_strcpy(new_creature->name, row[1],MAX_CREATURE_NAME_LENGTH);
	   safe_strcpy(new_creature->static_data->guild, row[2],MAX_CREATURE_GUILD_NAME_LENGTH);
	   new_creature->dataf[UNIT_FIELD_BOUNDINGRADIUS]=(float)atof(row[3]);
	   new_creature->dataf[UNIT_FIELD_COMBATREACH]=(float)atof(row[4]);
	   new_creature->data32[UNIT_FIELD_LEVEL]=atoi(row[5]);
	   new_creature->static_data->level_diff = atoi(row[5])-atoi(row[6])+1;
	   new_creature->dataf[UNIT_FIELD_MINDAMAGE]=(float)atof(row[7]);
	   new_creature->dataf[UNIT_FIELD_MAXDAMAGE]=(float)atof(row[8]);
	   new_creature->dmg_type = atoi(row[9]);
	   new_creature->data32[UNIT_FIELD_FACTIONTEMPLATE]=atoi(row[10]);
	   new_creature->data32[UNIT_FIELD_FLAGS]=atoi(row[11]);
	   new_creature->data32[UNIT_FIELD_MAXHEALTH]=atoi(row[12]);
	   new_creature->data32[UNIT_FIELD_HEALTH]=atoi(row[12]);
	   new_creature->data32[UNIT_FIELD_MAXPOWER1]=atoi(row[13]);
	   new_creature->data32[UNIT_FIELD_POWER1]=atoi(row[13]);
	   new_creature->data32[UNIT_FIELD_DISPLAYID]=atoi(row[14]);
	   new_creature->data32[UNIT_FIELD_NATIVEDISPLAYID]=atoi(row[14]);
	   new_creature->data32[UNIT_NPC_FLAGS]=atoi(row[15]);
	   new_creature->speed_land_modifyer = (float)atof(row[16]);
	   new_creature->dataf[OBJECT_FIELD_SCALE_X]=(float)atof(row[17]);
	   new_creature->static_data->type = atoi(row[18]);
	   new_creature->static_data->family = atoi(row[19]);
	   new_creature->static_data->elite = atoi(row[20]);
	   new_creature->static_data->trainer_type = atoi(row[21]);
	   new_creature->data32[UNIT_FIELD_MOUNTDISPLAYID]=atoi(row[22]);
	   new_creature->data32[UNIT_FIELD_BASEATTACKTIME]=atoi(row[23]);
	   new_creature->data32[UNIT_FIELD_BASEATTACKTIME+1]=atoi(row[24]);
	   new_creature->static_data->loot_template_id = atoi(row[25]);
	   if(new_creature->static_data->loot_template_id>=G_max_loot_template_id || G_static_loot_templates[new_creature->static_data->loot_template_id]==NULL)
		   new_creature->static_data->loot_template_id = 0;
	   new_creature->static_data->train_class = atoi(row[26]);
	   new_creature->data32[UNIT_VIRTUAL_ITEM_INFO+0*2] = atoi(row[27]);
	   new_creature->data32[UNIT_VIRTUAL_ITEM_INFO+1*2] = atoi(row[28]);
	   new_creature->data32[UNIT_VIRTUAL_ITEM_INFO+2*2] = atoi(row[29]);
	   new_creature->data32[UNIT_VIRTUAL_ITEM_INFO+0*2+1] = atoi(row[30]);
	   new_creature->data32[UNIT_VIRTUAL_ITEM_INFO+1*2+1] = atoi(row[31]);
	   new_creature->data32[UNIT_VIRTUAL_ITEM_INFO+2*2+1] = atoi(row[32]);
	   new_creature->data32[UNIT_VIRTUAL_ITEM_SLOT_DISPLAY+0] = atoi(row[33]);
	   new_creature->data32[UNIT_VIRTUAL_ITEM_SLOT_DISPLAY+1] = atoi(row[34]);
	   new_creature->data32[UNIT_VIRTUAL_ITEM_SLOT_DISPLAY+2] = atoi(row[35]);
	   new_creature->data32[UNIT_FIELD_RESISTANCES+0] = atoi(row[36]);
	   new_creature->data32[UNIT_FIELD_RESISTANCES+1] = atoi(row[37]);
	   new_creature->data32[UNIT_FIELD_RESISTANCES+2] = atoi(row[38]);
	   new_creature->data32[UNIT_FIELD_RESISTANCES+3] = atoi(row[39]);
	   new_creature->data32[UNIT_FIELD_RESISTANCES+4] = atoi(row[40]);
	   new_creature->data32[UNIT_FIELD_RESISTANCES+5] = atoi(row[41]);
	   new_creature->data32[UNIT_FIELD_RESISTANCES+6] = atoi(row[42]);
	   G_creature_prototypes[new_creature->db_id] = new_creature;
	   //load creature quests 
		char query2[500];
		MYSQL_RES *res2;
		MYSQL_ROW row2;
		sprintf(query2,"select quest_id from creature_quests where creature_id='%u'",template_id);
		doQuery(query2);
		res2 = mysql_store_result ((MYSQL *)mDatabaseConnection);
		while(row2 = mysql_fetch_row (res2))
		{
			uint32 quest_id=atoi(row2[0]);
			if(quest_id < G_max_quest_id && G_quest_prototypes[quest_id])
				new_creature->static_data->quests_list.add(quest_id);
		}
	    mysql_free_result (res2);
		//creature spells if he has any
		sprintf(query2,"select spell_id,cast_chance,flags from creature_spell_templates where template_id='%u'",template_id);
		doQuery(query2);
		res2 = mysql_store_result ((MYSQL *)mDatabaseConnection);
		while(row2 = mysql_fetch_row (res2))
		{
			uint32 spell_id=atoi(row2[0]);
			if(spell_id>G_max_spell_id || !G_spell_info[spell_id])
				continue;
			cr_spell_book_node *node=new cr_spell_book_node;
			node->spell_id = spell_id;
			//make creature have a quick tartget
			node->flags = atoi(row2[2]);
			if(!(node->flags & (CREATURE_CAST_FLAG_TARGET_SELF | CREATURE_CAST_FLAG_TARGET_MASTER | CREATURE_CAST_FLAG_TARGET_TARGET)))
				node->flags = G_spell_info[spell_id]->Get_Creature_Prefered_Target();
			node->chance_to_cast = atoi(row2[1]);
			new_creature->static_data->spell_book.add(node);
		}
		if(new_creature->static_data->spell_book.first)
				new_creature->flags1 |= CREATURE_FLAG_CASTER;
		mysql_free_result (res2);
		//creature yells
		sprintf(query2,"select type,lang,text,chance,yell_on_event_type,emote from creature_yells where template_id='%u'",template_id);
		doQuery(query2);
		res2 = mysql_store_result ((MYSQL *)mDatabaseConnection);
		while(row2 = mysql_fetch_row (res2))
		{
			cr_yell_node *new_yell_node=new cr_yell_node;
			ASSERT(new_yell_node);
			new_yell_node->type = atoi(row2[0]);
			new_yell_node->lang = atoi(row2[1]);
			new_yell_node->text = (char*)malloc(strlen(row2[2])+1);
			strcpy(new_yell_node->text,row2[2]);
			new_yell_node->chance = atoi(row2[3]);
			new_yell_node->trigger_on_event = atoi(row2[4]);
			new_creature->static_data->yell_list.add(new_yell_node);
		}
	    mysql_free_result (res2);
		if(!new_creature->static_data->quests_list.first)
			new_creature->data32[UNIT_NPC_FLAGS] &= ~UNIT_NPC_FLAG_QUESTGIVER; //remove questgiver flag if not a questgiver.
		if(!new_creature->static_data->sell_spell_list.first)
			new_creature->data32[UNIT_NPC_FLAGS] &= ~UNIT_NPC_FLAG_TRAINER; //remove trainer flag if not a trainer.
	   row_number++;
   }
#ifdef _DEBUG
   LOG.outString ("Loaded %u creature templates\n",row_number);
#endif
   mysql_free_result (res);
}

void DatabaseInterface::load_creature_mods()
{
   char query[300];
   MYSQL_RES *res ;
   MYSQL_ROW row;
   uint32 row_number=1;
   sprintf(query,"SELECT count(id) from creature_mods");
   doQuery(query);
   res = mysql_store_result ((MYSQL *)mDatabaseConnection);
   row = mysql_fetch_row (res);
   G_max_creature_mods = atoi(row[0])+1;
   G_creature_mods = (creature_mod*)malloc(sizeof(creature_mod)*G_max_creature_mods);
   mysql_free_result (res);
   sprintf(query,"SELECT name,is_suffix,aff_what_1,aff_type_1,aff_val_1,aff_what_2,aff_type_2,aff_val_2,aff_what_3,aff_type_3,aff_val_3,chance from creature_mods");
   doQuery(query);
   res = mysql_store_result ((MYSQL *)mDatabaseConnection);
   while(row = mysql_fetch_row (res))
   {
	   safe_strcpy(G_creature_mods[row_number].name,row[0],MAX_CREATURE_MOD_NAME_LENGTH);
	   G_creature_mods[row_number].flags = atoi(row[1]);
	   G_creature_mods[row_number].affect_what[0] = atoi(row[2]);
	   G_creature_mods[row_number].affect_type[0] = atoi(row[3]);
	   G_creature_mods[row_number].affect_value[0] = (float)atof(row[4]);
	   G_creature_mods[row_number].affect_what[1] = atoi(row[5]);
	   G_creature_mods[row_number].affect_type[1] = atoi(row[6]);
	   G_creature_mods[row_number].affect_value[1] = (float)atof(row[7]);
	   G_creature_mods[row_number].affect_what[2] = atoi(row[8]);
	   G_creature_mods[row_number].affect_type[2] = atoi(row[9]);
	   G_creature_mods[row_number].affect_value[2] = (float)atof(row[10]);
	   G_creature_mods[row_number].chance_to_appear = atoi(row[11]);
	   row_number++;
   }
#ifdef _DEBUG
   LOG.outString ("Loaded %u creature mods\n",row_number-1);
#endif
   mysql_free_result (res);
}

void DatabaseInterface::load_vendor_items()
{
   char query[300];
   MYSQL_RES *res ;
   MYSQL_ROW row;
   uint32 row_number=0;
   creature_sell_item_node *new_node;
   sprintf(query,"SELECT creature_template_id,item_id,maxcount,incrtime from npc_vendor_items");
   doQuery(query);
   res = mysql_store_result ((MYSQL *)mDatabaseConnection);
   while(row = mysql_fetch_row (res))
   {
	   uint32 cur_creature_id=atoi(row[0]);
	   if(G_creature_prototypes[cur_creature_id])
	   {
		   if(!(G_creature_prototypes[cur_creature_id]->sell_item_list))
			   G_creature_prototypes[cur_creature_id]->sell_item_list = new creature_sell_item_list;
		   new_node = new creature_sell_item_node;
		   new_node->item_id = atoi(row[1]);
		   new_node->item_count_max = atoi(row[2]);
		   new_node->item_count = new_node->item_count_max;
		   new_node->increase_stack_interval = min(atoi(row[3])*1000,1000);
		   G_creature_prototypes[cur_creature_id]->sell_item_list->add(new_node);
	   }
	   row_number++;
   }
   mysql_free_result (res);
#ifdef _DEBUG
   LOG.outString ("Loaded %u vendor items\n",row_number);
#endif
}

void DatabaseInterface::load_vendor_spells()
{
	char query[300];
	MYSQL_RES *res ;
	MYSQL_ROW row;
	uint32 row_number=0;
	creature_sell_spell_node *new_node;
	sprintf(query,"SELECT creature_template_id,cast_spell_id,teach_spell_id,spell_cost,reqspell,reqskill,reqskilllvl,reqlvl from npc_trainer_spells");
	doQuery(query);
	res = mysql_store_result ((MYSQL *)mDatabaseConnection);
	while(row = mysql_fetch_row (res))
	{
		uint32 cur_creature_id=atoi(row[0]);
		if(G_creature_prototypes[cur_creature_id])
		{
			new_node = new creature_sell_spell_node;
			new_node->cast_spell_id = atoi(row[1]);
			new_node->teach_spell_id = atoi(row[2]);
			new_node->cost = atoi(row[3]);
			new_node->req_spell = atoi(row[4]);
			new_node->req_skill = atoi(row[5]);
			new_node->req_skill_lvl = atoi(row[6]);
			new_node->req_lvl = atoi(row[7]);
			G_creature_prototypes[cur_creature_id]->static_data->sell_spell_list.add(new_node);
		}
		row_number++;
	}
	mysql_free_result (res);
#ifdef _DEBUG
	LOG.outString ("Loaded %u traner spells\n",row_number);
#endif
}

void DatabaseInterface::load_NPC_text()
{
	MYSQL_RES *res;
	MYSQL_ROW row;
	uint32 row_number=0;
	std::stringstream ss;
	ss.str( "" );
	ss << "select id from npc_text order by id desc limit 0,1";
	doQuery(ss.str().c_str());
	res = mysql_store_result ((MYSQL *)mDatabaseConnection);
	row = mysql_fetch_row(res);
	G_max_NPC_text = atoi(row[0])+1;
	G_NPC_text = (NPC_text**)malloc(G_max_NPC_text*sizeof(NPC_text*));
	memset(G_NPC_text,NULL,G_max_NPC_text*sizeof(NPC_text*));
	mysql_free_result (res);
	ss.str( "" );
	ss << "select id,text0_0 from npc_text order by id";
	doQuery(ss.str().c_str());
	res = mysql_store_result ((MYSQL *)mDatabaseConnection);
	while(row = mysql_fetch_row (res))
	{
		uint32 cur_txt_id=atoi(row[0]);
		if(!G_NPC_text[cur_txt_id])
		{
			G_NPC_text[cur_txt_id] = (NPC_text*)malloc(sizeof(NPC_text)*NPC_TEXT_TO_CHOOSE_FROM);
			memset(G_NPC_text[cur_txt_id],0,sizeof(NPC_text)*NPC_TEXT_TO_CHOOSE_FROM);
		}
		G_NPC_text[cur_txt_id][0].text_0 = (char*)malloc(strlen(row[1])+1);
		strcpy(G_NPC_text[cur_txt_id][0].text_0,row[1]);
		row_number++;
	}
	mysql_free_result (res);
#ifdef _DEBUG
	LOG.outString ("Loaded %u NPC texts\n",row_number);
#endif
/*
	MYSQL_RES *res ;
	MYSQL_ROW row;
	uint32 row_number=0;
	uint32 i;
	std::stringstream ss;
	ss.str( "" );
	ss << "select id from NPC_text order by id desc limit 0,1";
	doQuery(ss.str().c_str());
	res = mysql_store_result ((MYSQL *)mDatabaseConnection);
	row = mysql_fetch_row(res);
	G_max_NPC_text = atoi(row[0])+1;
	G_NPC_text = (NPC_text**)malloc(G_max_NPC_text*sizeof(NPC_text*));
	memset(G_NPC_text,NULL,G_max_NPC_text*sizeof(NPC_text*));
	mysql_free_result (res);
	ss.str( "" );
	ss << "select id";
	for(i=1;i<=NPC_TEXT_TO_CHOOSE_FROM;i++)
		ss << ",chance_" << i << ",emote_anim_" << i << "_0,emote_anim_" << i << "_1,emote_anim_" << i << "_2,text_" << i << "_0,text_" << i <<"_1,lang,emote_delay_" << i << "_0,emote_delay_" << i << "_1,emote_delay_" << i << "_2 ";
	ss << " from NPC_text order by id";
	doQuery(ss.str().c_str());
	res = mysql_store_result ((MYSQL *)mDatabaseConnection);
	while(row = mysql_fetch_row (res))
	{
		uint32 cur_txt_id=atoi(row[0]);
		if(!G_NPC_text[cur_txt_id])
		{
			G_NPC_text[cur_txt_id] = (NPC_text*)malloc(sizeof(NPC_text)*NPC_TEXT_TO_CHOOSE_FROM);
			memset(G_NPC_text[cur_txt_id],0,sizeof(NPC_text)*NPC_TEXT_TO_CHOOSE_FROM);
		}
		for(i=0;i<NPC_TEXT_TO_CHOOSE_FROM;i++)
		{
			G_NPC_text[cur_txt_id][i].chance = (float)atof(row[1+i*10+0]);
			G_NPC_text[cur_txt_id][i].emote_anim[0] = atoi(row[1+i*10+1]);
			G_NPC_text[cur_txt_id][i].emote_anim[1] = atoi(row[1+i*10+2]);
			G_NPC_text[cur_txt_id][i].emote_anim[2] = atoi(row[1+i*10+3]);
			if(row[1+i*10+4])
			{
				G_NPC_text[cur_txt_id][i].text_0 = (char*)malloc(strlen(row[1+i*10+4])+1);
				strcpy(G_NPC_text[cur_txt_id][i].text_0,row[1+i*10+4]);
			}
			if(row[1+i*10+5])
			{
				G_NPC_text[cur_txt_id][i].text_1 = (char*)malloc(strlen(row[1+i*10+5])+1);
				strcpy(G_NPC_text[cur_txt_id][i].text_1,row[1+i*10+5]);
			}
			G_NPC_text[cur_txt_id][i].lang = atoi(row[1+i*10+6]);
			G_NPC_text[cur_txt_id][i].emote_delay[0] = atoi(row[1+i*10+1]);
			G_NPC_text[cur_txt_id][i].emote_delay[1] = atoi(row[1+i*10+2]);
			G_NPC_text[cur_txt_id][i].emote_delay[2] = atoi(row[1+i*10+3]);
		}
		row_number++;
	}
	mysql_free_result (res);
#ifdef _DEBUG
	LOG.outString ("Loaded %u NPC texts\n",row_number);
#endif
*/
}

void DatabaseInterface::load_quest_templates()
{
	MYSQL_RES *res;
	MYSQL_ROW row;
	uint32 row_number=0;
	std::stringstream ss;
	ss.str( "" );
	ss << "select id from quest_template order by id desc limit 0,1";
	doQuery(ss.str().c_str());
	res = mysql_store_result ((MYSQL *)mDatabaseConnection);
	row = mysql_fetch_row(res);
	if(row==NULL)
	{
		G_max_quest_id = 0;
		G_quest_prototypes = NULL;
		return;
	}
	G_max_quest_id = atoi(row[0])+1;
	G_quest_prototypes = (Quest_template**)malloc(G_max_quest_id*sizeof(Quest_template*));
	memset(G_quest_prototypes,NULL,G_max_quest_id*sizeof(Quest_template*));
	mysql_free_result (res);
	ss.str( "" );
	ss  << "select "
		<< "id,zone_id,quest_sort,lvl_min,lvl,type,"
		<< "req_race_flags,req_class_flags,req_skill,req_skill_value,req_rep_faction,req_rep_value,obj_time,s_flags,prev_quest_id,"
		<< "next_quest_id,src_item_id,src_item_count,title,details,objectives,done_text,incomplete_text,end_text,obj_text_1,"
		<< "obj_text_2,obj_text_3,obj_text_4,obj_item_id_1,obj_item_id_2,obj_item_id_3,obj_item_id_4,obj_item_count_1,obj_item_count_2,"
		<< "obj_item_count_3,obj_item_count_4,obj_kill_id_1,obj_kill_id_2,obj_kill_id_3,obj_kill_id_4,obj_kill_count_1,"
		<< "obj_kill_count_2,obj_kill_count_3,obj_kill_count_4,rew_choice_item_id_1,rew_choice_item_id_2,rew_choice_item_id_3,"
		<< "rew_choice_item_id_4,rew_choice_item_id_5,rew_choice_item_id_6,rew_choice_item_count_1,rew_choice_item_count_2,"
		<< "rew_choice_item_count_3,rew_choice_item_count_4,rew_choice_item_count_5,rew_choice_item_count_6,rew_item_id_1,"
		<< "rew_item_id_2,rew_item_id_3,rew_item_id_4,rew_item_count_1,rew_item_count_2,rew_item_count_3,rew_item_count_4,"
		<< "rew_rep_faction_1,rew_rep_faction_2,rew_rep_val_1,rew_rep_val_2,rew_or_req_money,rew_xp,rew_teach_spell,"
		<< "rew_cast_spell,point_map_id,point_x,point_y,point_opt,obj_speak_to_id,obj_item_from_creature_1,obj_item_from_creature_2, "
		<< "obj_item_from_creature_3,obj_item_from_creature_4,obj_trigger_id_1,obj_trigger_id_2,obj_trigger_id_3,obj_trigger_id_4 "
		<< " from quest_template order by id,quest_sort";
//	req_index_1,req_value_1,req_index_2,req_value_2,req_index_3,req_value_3,kill_target_type,
	doQuery(ss.str().c_str());
	res = mysql_store_result ((MYSQL *)mDatabaseConnection);
	while(row = mysql_fetch_row (res))
	{
		uint32 cur_template_id=atoi(row[0]);
		if(!G_quest_prototypes[cur_template_id])
		{
			G_quest_prototypes[cur_template_id] = (Quest_template*)malloc(sizeof(Quest_template));
			memset(G_quest_prototypes[cur_template_id],0,sizeof(Quest_template));
		}
		G_quest_prototypes[cur_template_id]->id = atoi(row[0]);
		G_quest_prototypes[cur_template_id]->zone_id = atoi(row[1]);
		G_quest_prototypes[cur_template_id]->quest_sort = atoi(row[2]);
		G_quest_prototypes[cur_template_id]->req_lvl = atoi(row[3]);
		G_quest_prototypes[cur_template_id]->lvl = atoi(row[4]);
		G_quest_prototypes[cur_template_id]->q_type = atoi(row[5]);
		G_quest_prototypes[cur_template_id]->req_race_flags = atoi(row[6]);
		G_quest_prototypes[cur_template_id]->req_class_flags = atoi(row[7]);
		G_quest_prototypes[cur_template_id]->req_skill = atoi(row[8]);
		G_quest_prototypes[cur_template_id]->req_skill_value = atoi(row[9]);
		G_quest_prototypes[cur_template_id]->req_rep_faction = atoi(row[10]);
		G_quest_prototypes[cur_template_id]->req_rep_value = atoi(row[11]);
		G_quest_prototypes[cur_template_id]->obj_time = atoi(row[12]);
		G_quest_prototypes[cur_template_id]->s_flags = atoi(row[13]);
		G_quest_prototypes[cur_template_id]->prev_quest_id = atoi(row[14]);
		G_quest_prototypes[cur_template_id]->next_quest_id = atoi(row[15]);
		G_quest_prototypes[cur_template_id]->src_item_id = atoi(row[16]);
		G_quest_prototypes[cur_template_id]->src_item_count = atoi(row[17]);
		G_quest_prototypes[cur_template_id]->title_txt = (char*)malloc(strlen(row[18])+1);
		strcpy(G_quest_prototypes[cur_template_id]->title_txt,row[18]);
		G_quest_prototypes[cur_template_id]->details_txt = (char*)malloc(strlen(row[19])+1);
		strcpy(G_quest_prototypes[cur_template_id]->details_txt,row[19]);
		G_quest_prototypes[cur_template_id]->objective_txt = (char*)malloc(strlen(row[20])+1);
		strcpy(G_quest_prototypes[cur_template_id]->objective_txt,row[20]);
		G_quest_prototypes[cur_template_id]->done_txt = (char*)malloc(strlen(row[21])+1);
		strcpy(G_quest_prototypes[cur_template_id]->done_txt,row[21]);
		G_quest_prototypes[cur_template_id]->incomplete_txt = (char*)malloc(strlen(row[22])+1);
		strcpy(G_quest_prototypes[cur_template_id]->incomplete_txt,row[22]);
		G_quest_prototypes[cur_template_id]->end_txt = (char*)malloc(strlen(row[23])+1);
		strcpy(G_quest_prototypes[cur_template_id]->end_txt,row[23]);
		G_quest_prototypes[cur_template_id]->obj_text_1 = (char*)malloc(strlen(row[24])+1);
		strcpy(G_quest_prototypes[cur_template_id]->obj_text_1,row[24]);
		G_quest_prototypes[cur_template_id]->obj_text_2 = (char*)malloc(strlen(row[25])+1);
		strcpy(G_quest_prototypes[cur_template_id]->obj_text_2,row[25]);
		G_quest_prototypes[cur_template_id]->obj_text_3 = (char*)malloc(strlen(row[26])+1);
		strcpy(G_quest_prototypes[cur_template_id]->obj_text_3,row[26]);
		G_quest_prototypes[cur_template_id]->obj_text_4 = (char*)malloc(strlen(row[27])+1);
		strcpy(G_quest_prototypes[cur_template_id]->obj_text_4,row[27]);
		G_quest_prototypes[cur_template_id]->obj_item_id[0] = atoi(row[28]);
		G_quest_prototypes[cur_template_id]->obj_item_id[1] = atoi(row[29]);
		G_quest_prototypes[cur_template_id]->obj_item_id[2] = atoi(row[30]);
		G_quest_prototypes[cur_template_id]->obj_item_id[3] = atoi(row[31]);
		G_quest_prototypes[cur_template_id]->obj_item_count[0] = atoi(row[32]);
		G_quest_prototypes[cur_template_id]->obj_item_count[1] = atoi(row[33]);
		G_quest_prototypes[cur_template_id]->obj_item_count[2] = atoi(row[34]);
		G_quest_prototypes[cur_template_id]->obj_item_count[3] = atoi(row[35]);
		G_quest_prototypes[cur_template_id]->obj_kill_id[0] = atoi(row[36]);
		G_quest_prototypes[cur_template_id]->obj_kill_id[1] = atoi(row[37]);
		G_quest_prototypes[cur_template_id]->obj_kill_id[2] = atoi(row[38]);
		G_quest_prototypes[cur_template_id]->obj_kill_id[3] = atoi(row[39]);
		G_quest_prototypes[cur_template_id]->obj_kill_count[0] = atoi(row[40]);
		G_quest_prototypes[cur_template_id]->obj_kill_count[1] = atoi(row[41]);
		G_quest_prototypes[cur_template_id]->obj_kill_count[2] = atoi(row[42]);
		G_quest_prototypes[cur_template_id]->obj_kill_count[3] = atoi(row[43]);
		G_quest_prototypes[cur_template_id]->rew_opt_item_id[0] = atoi(row[44]);
		G_quest_prototypes[cur_template_id]->rew_opt_item_id[1] = atoi(row[45]);
		G_quest_prototypes[cur_template_id]->rew_opt_item_id[2] = atoi(row[46]);
		G_quest_prototypes[cur_template_id]->rew_opt_item_id[3] = atoi(row[47]);
		G_quest_prototypes[cur_template_id]->rew_opt_item_id[4] = atoi(row[48]);
		G_quest_prototypes[cur_template_id]->rew_opt_item_id[5] = atoi(row[49]);
		G_quest_prototypes[cur_template_id]->rew_opt_item_count[0] = atoi(row[50]);
		G_quest_prototypes[cur_template_id]->rew_opt_item_count[1] = atoi(row[51]);
		G_quest_prototypes[cur_template_id]->rew_opt_item_count[2] = atoi(row[52]);
		G_quest_prototypes[cur_template_id]->rew_opt_item_count[3] = atoi(row[53]);
		G_quest_prototypes[cur_template_id]->rew_opt_item_count[4] = atoi(row[54]);
		G_quest_prototypes[cur_template_id]->rew_opt_item_count[5] = atoi(row[55]);
		G_quest_prototypes[cur_template_id]->rew_item_id[0] = atoi(row[56]);
		G_quest_prototypes[cur_template_id]->rew_item_id[1] = atoi(row[57]);
		G_quest_prototypes[cur_template_id]->rew_item_id[2] = atoi(row[58]);
		G_quest_prototypes[cur_template_id]->rew_item_id[3] = atoi(row[59]);
		G_quest_prototypes[cur_template_id]->rew_item_count[0] = atoi(row[60]);
		G_quest_prototypes[cur_template_id]->rew_item_count[1] = atoi(row[61]);
		G_quest_prototypes[cur_template_id]->rew_item_count[2] = atoi(row[62]);
		G_quest_prototypes[cur_template_id]->rew_item_count[3] = atoi(row[63]);
		G_quest_prototypes[cur_template_id]->rew_rep_faction[0] = atoi(row[64]);
		G_quest_prototypes[cur_template_id]->rew_rep_faction[1] = atoi(row[65]);
		G_quest_prototypes[cur_template_id]->rew_rep_faction_value[0] = atoi(row[66]);
		G_quest_prototypes[cur_template_id]->rew_rep_faction_value[1] = atoi(row[67]);
		G_quest_prototypes[cur_template_id]->rew_xp_or_money = atoi(row[68]);
		G_quest_prototypes[cur_template_id]->rew_xp = atoi(row[69]);
		G_quest_prototypes[cur_template_id]->rew_teach_spell = atoi(row[70]);
		G_quest_prototypes[cur_template_id]->rew_cast_spell = atoi(row[71]);
		G_quest_prototypes[cur_template_id]->point_map_id = atoi(row[72]);
		G_quest_prototypes[cur_template_id]->point_x = (float)atof(row[73]);
		G_quest_prototypes[cur_template_id]->point_y = (float)atof(row[74]);
		G_quest_prototypes[cur_template_id]->point_opt = atoi(row[75]);
		G_quest_prototypes[cur_template_id]->obj_speakto_id = atoi(row[76]);
		G_quest_prototypes[cur_template_id]->obj_item_from_cr_id[0] = atoi(row[77]);
		G_quest_prototypes[cur_template_id]->obj_item_from_cr_id[1] = atoi(row[78]);
		G_quest_prototypes[cur_template_id]->obj_item_from_cr_id[2] = atoi(row[79]);
		G_quest_prototypes[cur_template_id]->obj_item_from_cr_id[3] = atoi(row[80]);
		G_quest_prototypes[cur_template_id]->obj_trigger_id[0] = atoi(row[81]);
		G_quest_prototypes[cur_template_id]->obj_trigger_id[1] = atoi(row[82]);
		G_quest_prototypes[cur_template_id]->obj_trigger_id[2] = atoi(row[83]);
		G_quest_prototypes[cur_template_id]->obj_trigger_id[3] = atoi(row[84]);
/*
		G_quest_prototypes[cur_template_id]->req_stat_index[0] = atoi(row[6]);
		G_quest_prototypes[cur_template_id]->req_stat_value[0] = atoi(row[7]);
		G_quest_prototypes[cur_template_id]->req_stat_index[1] = atoi(row[8]);
		G_quest_prototypes[cur_template_id]->req_stat_value[1] = atoi(row[9]);
		G_quest_prototypes[cur_template_id]->req_stat_index[2] = atoi(row[10]);
		G_quest_prototypes[cur_template_id]->req_stat_value[2] = atoi(row[11]);
		G_quest_prototypes[cur_template_id]->obj_kill_type[0] = atoi(row[42]);*/
		row_number++;
	}
	mysql_free_result (res);
#ifdef _DEBUG
	LOG.outString ("Loaded %u quest templates\n",row_number);
#endif
}

//loads+init all creature instances and ads them to mapmanager
void DatabaseInterface::spawn_creatures()
{
   char query[300];
   MYSQL_RES *res ;
   MYSQL_ROW row;
   creature *new_creature;
   uint32 row_number=0;
   //get the biggest map_id
   sprintf(query,"SELECT id,template_id,pos_x,pos_y,pos_z,orientation,map_id,respawn_delay,flags from creature_instances order by id asc");
   doQuery(query);
   res = mysql_store_result ((MYSQL *)mDatabaseConnection);
   //fetch all templates, alloc space and insert them into a holder list
   while(row = mysql_fetch_row (res))
   {
	  uint32 template_id=atoi(row[1]);
	  if(G_creature_prototypes[template_id]!=NULL && template_id<G_max_creature_prototypes)
	   {
		   //create a new instance
		   new_creature = new creature();
		   //init the instance
		   new_creature->db_id = atoi(row[0]);//before init from template so new guid can be generated from it
		   new_creature->init_from_template(G_creature_prototypes[template_id]);
           new_creature->pos_x = (float)atof(row[2]);
		   new_creature->pos_y = (float)atof(row[3]);
           new_creature->pos_z = (float)atof(row[4]);
		   new_creature->orientation = (float)(atof(row[5]));
		   new_creature->map_id = atoi(row[6]);
		   new_creature->respawn_delay = atoi(row[7])*1000;
		   new_creature->flags1 = atoi(row[8]);
			new_creature->flags1 |= G_creature_prototypes[template_id]->flags1; //inherit caster and other static flags
		   if(new_creature->flags1 & CREATURE_FLAG_ALWAYS_ACTIVE)
			   G_creature_always_active.add(new_creature);
		   //check if it is a path walker and load path points = way points
			char query2[500];
			MYSQL_RES *res2;
			MYSQL_ROW row2;
			sprintf(query2,"select dst_x,dst_y,dst_z,dst_o,wait_at_dst,speed_coef from creature_instance_waypoints where creature_instance_id='%u' order by waypoint_order desc",new_creature->db_id);
			doQuery(query2);
			res2 = mysql_store_result ((MYSQL *)mDatabaseConnection);
			uint32 wpcount=0;
			while(row2 = mysql_fetch_row (res2))
			{
				wpcount++;
				Waypoint_Node *new_node;
				new_node = new Waypoint_Node;
				new_node->dst_x = (float)atof(row2[0]);
				new_node->dst_y = (float)atof(row2[1]);
				new_node->dst_z = (float)atof(row2[2]);
				new_node->dst_o = (float)atof(row2[3]);
				new_node->dst_time_wait = atoi(row2[4]);
				new_node->speed_coef = (float)atof(row2[5]);
				new_creature->waypoint_lst.add(new_node);
//printf("adding new waypoint to creature %f, %f\n",new_node->dst_x,new_node->dst_y);
			}
			mysql_free_result (res2);
			if(wpcount>1)
			{
				new_creature->flags1 |= CREATURE_FLAG_WAYPOINT_WALKER;
				new_creature->flags1 &= ~(CREATURE_FLAG_RANDOM_MOVE | CREATURE_FLAG_STAND);
			}
			else if(wpcount==1)
			{
				new_creature->flags1 |= CREATURE_FLAG_STAND;
				new_creature->flags1 &= ~(CREATURE_FLAG_RANDOM_MOVE | CREATURE_FLAG_WAYPOINT_WALKER );
			}
//			else if(wpcount==0) //this case we should check if it is a civilian and if not then make him a random mover
#ifdef VERSION_CHAR_MAKE_CREAUTURE_WPOINTS
			if(wpcount)
			{
				new_creature->z_cords_already_checked = 1;
//				printf("another creature that has waypoints\n");
			}
			else new_creature->z_cords_already_checked = 0;
#endif
		    new_creature->spawn();
            row_number++;
	   }
   }
#ifdef _DEBUG
	LOG.outString ("Loaded %u creature instances\n",row_number);
#endif
   mysql_free_result (res);
}

//add a new spawnpoint to db
void DatabaseInterface::add_spawn_creature(Character *p_char,uint32 template_id,uint32 respawn_delay,uint32 flags)
{
   char query[300];
   creature *new_creature;
   uint64	db_id;
   if(G_creature_prototypes[template_id]!=NULL)
   {
	   new_creature = new creature;
	   //init the instance
	   memcpy(new_creature->data32,G_creature_prototypes[template_id]->data32,UNIT_END*4);
	   memcpy(new_creature,G_creature_prototypes[template_id],sizeof(creature));
	   new_creature->prototype = G_creature_prototypes[template_id];
       new_creature->pos_x = p_char->pos_x;
	   new_creature->pos_y = p_char->pos_y;
       new_creature->pos_z = p_char->pos_z;
	   new_creature->orientation = p_char->orientation;
	   new_creature->map_id = p_char->map_id;
	   new_creature->respawn_delay = respawn_delay;
	   new_creature->flags1 = flags;
	   new_creature->respawn_delay = respawn_delay;
	   if(flags & CREATURE_FLAG_WAYPOINT_WALKER)
	   {
			Waypoint_Node *new_node=new Waypoint_Node;
			new_node->dst_x = p_char->pos_x;
			new_node->dst_y = p_char->pos_y;
			new_node->dst_z = p_char->pos_z;
			new_node->dst_o = p_char->orientation;
			new_node->speed_coef = 1;
			new_node->dst_time_wait = 0;
			new_creature->waypoint_lst.add(new_node);
	   }
//	   //add to mapmanager
//	   G_maps[new_creature->map_id]->add_creature(new_creature);
	   //insert into db
	   sprintf(query,"INSERT INTO creature_instances (template_id, pos_x, pos_y, pos_z, orientation, map_id, respawn_delay,flags) VALUES ('%u','%f','%f','%f','%f','%u','%u','%u')",
		   template_id,p_char->pos_x,p_char->pos_y,p_char->pos_z,p_char->orientation,p_char->map_id,respawn_delay,flags);
	   db_id = doQueryId(query);
	   new_creature->db_id = (uint32)db_id;
//	   Compressed_Update_Block temp_compressed_packet;
//	   temp_compressed_packet.clear();
//	   new_creature->build_create_block(&temp_compressed_packet,0,0);
//	   G_maps[new_creature->map_id]->send_instant_msg_to_block(new_creature->pos_x,new_creature->pos_y,temp_compressed_packet.build_packet(),NULL);
	   new_creature->spawn();
   }
}

void DatabaseInterface::del_spawn_creature(uint32 db_id)
{
	char query[300];
	if(db_id==0)//dinamicaly spawned creatures are not saved in db
		return;
	sprintf(query,"DELETE FROM creature_instances where id ='%u'",db_id);
	doQuery(query);
	sprintf(query,"DELETE FROM creature_instance_waypoints where creature_instance_id='%u'",db_id);
	doQuery(query);
}

void DatabaseInterface::load_faction_relations()
{
   char query[300];
   MYSQL_RES *res ;
   MYSQL_ROW row;
   uint32 row_number=0;
   sprintf(query,"SELECT faction_id from faction_names order by faction_id desc limit 0,1");
   doQuery(query);
   res = mysql_store_result ((MYSQL *)mDatabaseConnection);
   row = mysql_fetch_row (res);
   G_max_faction_id = atoi(row[0]);
   mysql_free_result (res);
   G_faction_is_enemy = (uint8*)malloc((G_max_faction_id+1)*(G_max_faction_id+1));
   memset(G_faction_is_enemy,0,(G_max_faction_id+1)*(G_max_faction_id+1));
   //fetch all enemy relations
   sprintf(query,"SELECT faction_id1,faction_id2 from faction_relation where is_enemy='1'");
   doQuery(query);
   res = mysql_store_result ((MYSQL *)mDatabaseConnection);
   while(row = mysql_fetch_row (res))
   {
	   uint32 f1,f2;
	   f1 = atoi(row[0]);
	   f2 = atoi(row[1]);
	   G_faction_is_enemy[f1*G_max_faction_id + f2] = 1;
	   G_faction_is_enemy[f2*G_max_faction_id + f1] = 1;
	   row_number ++;
   }
   mysql_free_result (res);
   //make sure nobody is enemy with himself
   for(uint32 i=0;i<G_max_faction_id;i++)
	   G_faction_is_enemy[i*G_max_faction_id + i] = 0;
   row_number=0;
   //fetch all friend relations
   G_faction_is_friend = (uint8*)malloc((G_max_faction_id+1)*(G_max_faction_id+1));
   memset(G_faction_is_friend,0,(G_max_faction_id+1)*(G_max_faction_id+1));
   sprintf(query,"SELECT faction_id1,faction_id2 from faction_relation where is_friend='1'");
   doQuery(query);
   res = mysql_store_result ((MYSQL *)mDatabaseConnection);
   while(row = mysql_fetch_row (res))
   {
	   uint32 f1,f2;
	   f1 = atoi(row[0]);
	   f2 = atoi(row[1]);
	   G_faction_is_friend[f1*G_max_faction_id + f2] = 1;
	   G_faction_is_friend[f2*G_max_faction_id + f1] = 1;
	   row_number ++;
   }
   mysql_free_result (res);
   //make sure everybody is friend with himself
   for(uint32 i=0;i<G_max_faction_id;i++)
   {
	   G_faction_is_friend[i*G_max_faction_id + i] = 1;
//	   G_faction_is_enemy[i*G_max_faction_id + i] = 0;
   }
#ifdef _DEBUG
	LOG.outString ("Loaded %u faction relations\n",row_number);
#endif
}

void DatabaseInterface::load_go_templates()
{
   char query[300];
   MYSQL_RES *res ;
   MYSQL_ROW row;
   gameobject *new_go;
   uint32 row_number=0;
   sprintf(query,"SELECT id from go_template order by id desc limit 0,1");
   doQuery(query);
   res = mysql_store_result ((MYSQL *)mDatabaseConnection);
   row = mysql_fetch_row (res);
   if(!row)
   {
	   G_max_gameobjects = 0;
	   G_gameobject_prototypes = NULL;
	   return;
   }
   G_max_gameobjects = atoi(row[0]);
   mysql_free_result (res);
   G_gameobject_prototypes = (gameobject**)malloc(sizeof(gameobject*)*G_max_gameobjects);
   memset(G_gameobject_prototypes,NULL,sizeof(gameobject*)*G_max_gameobjects);
   sprintf(query,"SELECT id,name,model,faction,flags,go_type,size,level,sound0,sound1,sound2,sound3,sound4,sound5,sound6,sound7,sound8,sound9 from go_template order by id asc");
   doQuery(query);
   res = mysql_store_result ((MYSQL *)mDatabaseConnection);
   //fetch all templates, alloc space and insert them into a holder list
   while(row = mysql_fetch_row (res))
   {
	   //alloc space for it
	   new_go = new gameobject;
	   //load it's data
	   new_go->db_id = atoi(row[0]);
       new_go->data32[OBJECT_FIELD_ENTRY]=new_go->db_id;
	   safe_strcpy(new_go->name, row[1],MAX_GO_NAME_LENGTH);
       new_go->data32[GAMEOBJECT_DISPLAYID]=atoi(row[2]);
	   new_go->data32[GAMEOBJECT_FACTION]= atoi(row[3]);
	   new_go->data32[GAMEOBJECT_FLAGS]= atoi(row[4]);
	   new_go->data32[GAMEOBJECT_TYPE_ID]= atoi(row[5]);
	   new_go->dataf[OBJECT_FIELD_SCALE_X]=(float)atoi(row[6]);
	   new_go->data32[GAMEOBJECT_LEVEL] = atoi(row[7]);
	   new_go->sound[0] = atoi(row[8]);
	   new_go->sound[1] = atoi(row[9]);
	   new_go->sound[2] = atoi(row[10]);
	   new_go->sound[3] = atoi(row[11]);
	   new_go->sound[4] = atoi(row[12]);
	   new_go->sound[5] = atoi(row[13]);
	   new_go->sound[6] = atoi(row[14]);
	   new_go->sound[7] = atoi(row[15]);
	   new_go->sound[8] = atoi(row[16]);
	   new_go->sound[9] = atoi(row[17]);
	   new_go->data32[GAMEOBJECT_STATE]=1; //create
	   //new_go->data32[GAMEOBJECT_TIMESTAMP]=0;
	   G_gameobject_prototypes[new_go->db_id] = new_go;
	   row_number++;
   }
#ifdef _DEBUG
       LOG.outString ("Loaded %u game object templates\n",row_number);
#endif
   mysql_free_result (res);
}

void DatabaseInterface::spawn_gos()
{
   char query[300];
   MYSQL_RES *res ;
   MYSQL_ROW row;
   gameobject_instance *new_go;
   uint32 row_number=0;
   sprintf(query,"SELECT id,template_id,pos_x,pos_y,pos_z,orientation,map_id,respawn_delay from go_instances order by id asc");
   doQuery(query);
   res = mysql_store_result ((MYSQL *)mDatabaseConnection);
   //fetch all templates, alloc space and insert them into a holder list
   while(row = mysql_fetch_row (res))
   {
	   if(G_gameobject_prototypes[atoi(row[1])]!=NULL)
	   {
		   //create a new instance
		   new_go = new gameobject_instance;
		   //init the instance
		   new_go->init_from_template(G_gameobject_prototypes[atoi(row[1])]);
		   new_go->db_id = atoi(row[0]);
           new_go->pos_x = (float)atof(row[2]);
		   new_go->pos_y = (float)atof(row[3]);
           new_go->pos_z = (float)atof(row[4]);
		   new_go->orientation = (float)(atof(row[5]));
		   new_go->map_id = atoi(row[6]);
		   new_go->respawn_delay = atoi(row[7]);
		   new_go->spawn();
		   //add to mapmanager
		   G_maps[new_go->map_id]->add_go(new_go);
           row_number++;
	   }
   }
#ifdef _DEBUG
       LOG.outString ("Loaded %u gameobject instances\n",row_number);
#endif
   mysql_free_result (res);
}

void DatabaseInterface::add_spawn_go(Character *p_char,uint32 template_id,uint32 respawn_delay)
{
   char query[300];
   gameobject_instance *new_go;
   uint64	db_id;
   if(template_id<G_max_gameobjects && G_gameobject_prototypes[template_id]!=NULL)
   {
	   new_go = new gameobject_instance;
	   //init the instance
	   new_go->prototype = G_gameobject_prototypes[template_id];
       new_go->pos_x = p_char->pos_x;
	   new_go->pos_y = p_char->pos_y;
       new_go->pos_z = p_char->pos_z;
	   new_go->orientation = p_char->orientation;
	   new_go->map_id = p_char->map_id;
	   new_go->respawn_delay = respawn_delay;
	   //add to mapmanager
	   G_maps[new_go->map_id]->add_go(new_go);
	   new_go->spawn();//spawn
	   //insert into db
	   sprintf(query,"INSERT INTO go_instances (template_id, pos_x, pos_y, pos_z, orientation, map_id, respawn_delay) VALUES ('%u','%f','%f','%f','%f','%u','%u')",
		   template_id,p_char->pos_x,p_char->pos_y,p_char->pos_z,p_char->orientation,p_char->map_id,respawn_delay);
//	   doQuery(query);
//	   sprintf(query,"SELECT id FROM go_instances order by id desc limit 0,1");
	   db_id = doQueryId(query);
	   new_go->db_id = (uint32)db_id;
   }
//   printf("inserting gameobject into db : templid (%d), query %s \n",template_id,query);
}

void DatabaseInterface::del_spawn_go(uint32 db_id)
{
	  char query[300];
	  sprintf(query,"DELETE FROM go_instances where id ='%u'",db_id);
	  doQuery(query);
}

void DatabaseInterface::load_spell_templates()
{
//	  char query[300];
	  MYSQL_RES *res;
      MYSQL_ROW row;
	  uint32 spell_id,row_number=0;
  	  std::stringstream ss;
   	  //select the max spell_id from the table
	  doQuery("select id from spell_template order by id desc limit 0,1");
	  res = mysql_store_result ((MYSQL *)mDatabaseConnection);
	  row = mysql_fetch_row (res);
	  G_max_spell_id = atoi(row[0]);
	  G_spell_info = (Spell_Info**)malloc(sizeof(Spell_Info*)*G_max_spell_id+4);
	  memset(G_spell_info,NULL,sizeof(Spell_Info*)*G_max_spell_id+4);
	  mysql_free_result (res);
	  //set all pointers to be null so we can test for sure if we have info about the spell or not
//	  memset(G_spell_info,NULL,sizeof(Spell_Info*)*G_max_spell_id+4);
	  ss << "select id,cast_time,power_type,power_cost,power_cost_per_lvl,power_cost_per_second,power_cost_per_second_per_level," 
		 << "effect_0,effect_1,effect_2,effect_implicit_target_a_0,effect_implicit_target_a_1,effect_implicit_target_a_2,effect_implicit_target_b_0,"
		 << "effect_implicit_target_b_1,effect_implicit_target_b_2,channel_interrupt_flags,duration_0,duration_1,duration_2,range_min,range_max,"
		 << "effect_base_points_0,effect_base_points_1,effect_base_points_2,dmg_multiply_for_combo_0,dmg_multiply_for_combo_1,dmg_multiply_for_combo_2,"
		 << "effect_die_sides_0,effect_die_sides_1,effect_die_sides_2,effect_misc_value_0,effect_misc_value_1,effect_misc_value_2,"
		 << "effect_real_points_per_lvl_0,effect_real_points_per_lvl_1,effect_real_points_per_lvl_2,effect_apply_aura_name_0,effect_apply_aura_name_1,"
		 << "effect_apply_aura_name_2,effect_amplitude_0,effect_amplitude_1,effect_amplitude_2,effect_trigger_spell_0,effect_trigger_spell_1,effect_trigger_spell_2,"
		 << "school,aura_interrupt_flags,recovery_time,radius_1,radius_2,radius_3,spell_lvl,effect_item_type_0,effect_item_type_1,effect_item_type_2, "
		 << "proc_chance,proc_charges,proc_flags,effect_base_dice_0,effect_base_dice_1,effect_base_dice_2,effect_dice_per_lvl_0,effect_dice_per_lvl_1,effect_dice_per_lvl_2, "
		 << "is_dispelable,spell_visual,reagent_0,reagent_1,reagent_2,reagent_3,reagent_4,reagent_5,reagent_6,reagent_7,reagent_count_0,reagent_count_1,reagent_count_2, "
		 << "reagent_count_3,reagent_count_4,reagent_count_5,reagent_count_6,reagent_count_7,maxstack,c_is_paladin_seal "
		 << "from spell_template order by id asc ";
	  doQuery(ss.str().c_str());
	  res =  mysql_store_result ((MYSQL *)mDatabaseConnection);
	  while(row = mysql_fetch_row (res))
	  {
		  spell_id = atoi(row[0]);
		  if(G_spell_info[spell_id] == NULL)
		  {
			  //create a new entry for this
			  G_spell_info[spell_id] = new Spell_Info;
			  //load data into it
			  G_spell_info[spell_id]->spell_id = spell_id;
			  G_spell_info[spell_id]->cast_time = atoi(row[1]);
			  G_spell_info[spell_id]->power_type = atoi(row[2]);
			  G_spell_info[spell_id]->power_cost = atoi(row[3]);
			  G_spell_info[spell_id]->power_cost_per_lvl = atoi(row[4]);
			  G_spell_info[spell_id]->power_cost_per_second = atoi(row[5]);
//			  G_spell_info[spell_id]->power_cost_per_second_per_level = atoi(row[6]);
			  G_spell_info[spell_id]->effect[0] = atoi(row[7]);
			  G_spell_info[spell_id]->effect[1] = atoi(row[8]);
			  G_spell_info[spell_id]->effect[2] = atoi(row[9]);
			  G_spell_info[spell_id]->effect_implicit_target_a[0] = atoi(row[10]);
			  G_spell_info[spell_id]->effect_implicit_target_a[1] = atoi(row[11]);
			  G_spell_info[spell_id]->effect_implicit_target_a[2] = atoi(row[12]);
			  G_spell_info[spell_id]->effect_implicit_target_b[0] = atoi(row[13]);
			  G_spell_info[spell_id]->effect_implicit_target_b[1] = atoi(row[14]);
			  G_spell_info[spell_id]->effect_implicit_target_b[2] = atoi(row[15]);
			  G_spell_info[spell_id]->channel_interrupt_flags = atoi(row[16]);
			  G_spell_info[spell_id]->duration[0] = atoi(row[17]);
			  G_spell_info[spell_id]->duration[1] = atoi(row[18]);
			  G_spell_info[spell_id]->duration[2] = atoi(row[19]);
			  G_spell_info[spell_id]->range_min = (float)atof(row[20]);
			  G_spell_info[spell_id]->range_max = (float)atof(row[21]);
			  G_spell_info[spell_id]->effect_base_points[0] = atoi(row[22]);
			  G_spell_info[spell_id]->effect_base_points[1] = atoi(row[23]);
			  G_spell_info[spell_id]->effect_base_points[2] = atoi(row[24]);
			  G_spell_info[spell_id]->dmg_multiply_for_combo[0] = (float)atof(row[25]);
			  G_spell_info[spell_id]->dmg_multiply_for_combo[1] = (float)atof(row[26]);
			  G_spell_info[spell_id]->dmg_multiply_for_combo[3] = (float)atof(row[27]);
			  G_spell_info[spell_id]->effect_die_sides[0] = atoi(row[28]);
			  G_spell_info[spell_id]->effect_die_sides[1] = atoi(row[29]);
			  G_spell_info[spell_id]->effect_die_sides[2] = atoi(row[30]);
			  G_spell_info[spell_id]->effect_misc_value[0] = atoi(row[31]);
			  G_spell_info[spell_id]->effect_misc_value[1] = atoi(row[32]);
			  G_spell_info[spell_id]->effect_misc_value[2] = atoi(row[33]);
//			  G_spell_info[spell_id]->effect_real_points_per_lvl[0] = atoi(row[34]);
//			  G_spell_info[spell_id]->effect_real_points_per_lvl[1] = atoi(row[35]);
//			  G_spell_info[spell_id]->effect_real_points_per_lvl[2] = atoi(row[36]);
			  G_spell_info[spell_id]->effect_apply_aura_name[0] = atoi(row[37]);
			  G_spell_info[spell_id]->effect_apply_aura_name[1] = atoi(row[38]);
			  G_spell_info[spell_id]->effect_apply_aura_name[2] = atoi(row[39]);
			  G_spell_info[spell_id]->effect_amplitude[0] = atoi(row[40]);
			  G_spell_info[spell_id]->effect_amplitude[1] = atoi(row[41]);
			  G_spell_info[spell_id]->effect_amplitude[2] = atoi(row[42]);
			  G_spell_info[spell_id]->effect_trigger_spell[0] = atoi(row[43]);
			  G_spell_info[spell_id]->effect_trigger_spell[1] = atoi(row[44]);
			  G_spell_info[spell_id]->effect_trigger_spell[2] = atoi(row[45]);
			  G_spell_info[spell_id]->school = atoi(row[46]);
			  G_spell_info[spell_id]->aura_interrupt_flags = atoi(row[47]);
			  G_spell_info[spell_id]->recovery_time = atoi(row[48]);
			  G_spell_info[spell_id]->radius[0] = (float)atof(row[49]);
			  G_spell_info[spell_id]->radius[1] = (float)atof(row[50]);
			  G_spell_info[spell_id]->radius[2] = (float)atof(row[51]);
			  G_spell_info[spell_id]->spell_lvl = atoi(row[52]);
			  G_spell_info[spell_id]->effect_create_item[0] = atoi(row[53]);
			  G_spell_info[spell_id]->effect_create_item[1] = atoi(row[54]);
			  G_spell_info[spell_id]->effect_create_item[2] = atoi(row[55]);
			  G_spell_info[spell_id]->proc_chance = atoi(row[56]);
			  G_spell_info[spell_id]->proc_charges = atoi(row[57]);
			  G_spell_info[spell_id]->proc_flags = atoi(row[58]);
			  G_spell_info[spell_id]->effect_base_dice[0] = atoi(row[59]);
			  G_spell_info[spell_id]->effect_base_dice[1] = atoi(row[60]);
			  G_spell_info[spell_id]->effect_base_dice[2] = atoi(row[61]);
			  G_spell_info[spell_id]->effect_dice_per_lvl[0] = atoi(row[62]);
			  G_spell_info[spell_id]->effect_dice_per_lvl[1] = atoi(row[63]);
			  G_spell_info[spell_id]->effect_dice_per_lvl[2] = atoi(row[64]);
			  G_spell_info[spell_id]->dispell_type = atoi(row[65]);
//			  G_spell_info[spell_id]->spell_visual = atoi(row[66]);
			  G_spell_info[spell_id]->reagent[0] = atoi(row[67]);
			  G_spell_info[spell_id]->reagent[1] = atoi(row[68]);
			  G_spell_info[spell_id]->reagent[2] = atoi(row[69]);
			  G_spell_info[spell_id]->reagent[3] = atoi(row[70]);
			  G_spell_info[spell_id]->reagent[4] = atoi(row[71]);
			  G_spell_info[spell_id]->reagent[5] = atoi(row[72]);
			  G_spell_info[spell_id]->reagent[6] = atoi(row[73]);
			  G_spell_info[spell_id]->reagent[7] = atoi(row[74]);
			  G_spell_info[spell_id]->reagent_count[0] = atoi(row[75]);
			  G_spell_info[spell_id]->reagent_count[1] = atoi(row[76]);
			  G_spell_info[spell_id]->reagent_count[2] = atoi(row[77]);
			  G_spell_info[spell_id]->reagent_count[3] = atoi(row[78]);
			  G_spell_info[spell_id]->reagent_count[4] = atoi(row[79]);
			  G_spell_info[spell_id]->reagent_count[5] = atoi(row[80]);
			  G_spell_info[spell_id]->reagent_count[6] = atoi(row[81]);
			  G_spell_info[spell_id]->reagent_count[7] = atoi(row[82]);
			  G_spell_info[spell_id]->stack_count = atoi(row[83]);
			  if(atoi(row[84]))
				  G_spell_info[spell_id]->custom_flags |= SPELL_GROUP_PALADIN_SEAL;
//			  G_spell_info[spell_id]- = atoi(row[4]);
//			  G_spell_info[spell_id]->category = atoi(row[2]);
//			  G_spell_info[spell_id]->is_dispelable = atoi(row[3]);
//			  G_spell_info[spell_id]->recovery_time = atoi(row[4]);
//			  G_spell_info[spell_id]->category_recovery_time = atoi(row[5]);
		  }
		  row_number++;
	  }
   mysql_free_result (res);
#ifdef _DEBUG
       LOG.outString ("Loaded %u spell_infos\n",row_number);
#endif
}

void DatabaseInterface::load_item_temlates()
{
	  MYSQL_RES *res;
      MYSQL_ROW row;
	  uint32 row_number=0,i;
	  Item	*new_item;
	  std::stringstream	ss;
	  uint32 item_id;
	  //!!! I realy tryed to use a map here but the damn shitty new operator could not alocate heap. So i got tired of it
   	  //select the max item_id from the table
	  doQuery("select id from item_template order by id desc limit 0,1");
	  res = mysql_store_result ((MYSQL *)mDatabaseConnection);
	  row = mysql_fetch_row (res);
	  G_max_item_id = atoi(row[0]);
	  G_item_prototypes = (Item**)malloc(sizeof(Item*)*G_max_item_id+4);
	  memset(G_item_prototypes,NULL,sizeof(Item*)*G_max_item_id+4);
	  mysql_free_result (res);
		ss.str( "" );
		ss << "select ";
		ss << " id, class, subclass, unk1_on_pos_4, display_id, quality, flags, price_sell, price_buy, inventory_type, allow_class, allow_race, item_lvl, requir_lvl, require_skill,";//15
		ss << " require_skill_lvl, require_spell_id, require_honor_lvl, require_city_lvl, requie_faction, require_faction_lvl, unk_21, stack_max, slots, stat_type1, stat_value1,";//11
		ss << " stat_type2, stat_value2, stat_type3, stat_value3, stat_type4, stat_value4, stat_type5, stat_value5, stat_type6, stat_value6, stat_type7, stat_value7,";//12
		ss << " stat_type8, stat_value8, stat_type9, stat_value9, stat_type10, stat_value10, dmg_min1, dmg_max1, dmg_type1, dmg_min2, dmg_max2, dmg_type2, dmg_min3,";//13
		ss << " dmg_max3, dmg_type3, dmg_min4, dmg_max4, dmg_type4, dmg_min5, dmg_max5, dmg_type5, armor, holy_res, fire_res, nature_res, frost_res, shadow_res,";//14
		ss << " arcane_res, delay, amo_type, ranged_mod_range, spellid_1, spelltrigger_1, spellcharges_1, spellcooldown_1, spellcategory_1, spellcategorycooldown_1, spellid_2,";//11
		ss << " spelltrigger_2, spellcharges_2, spellcooldown_2, spellcategory_2, spellcategorycooldown_2, spellid_3, spelltrigger_3, spellcharges_3, spellcooldown_3,";//9
		ss << " spellcategory_3, spellcategorycooldown_3, spellid_4, spelltrigger_4, spellcharges_4, spellcooldown_4, spellcategory_4, spellcategorycooldown_4, spellid_5,";//9
		ss << " spelltrigger_5, spellcharges_5, spellcooldown_5, spellcategory_5, spellcategorycooldown_5, bonding, page_text_id, page_language, page_material, start_quest_id,";//10
		ss << " lock_id, lock_material, sheath, extra, block, set_id, max_durability, area, map, bag_family, totem_category, socket_color_0, socket_content_0, ";//13
		ss << " socket_color_1, socket_content_1, socket_color_2, socket_content_2, socket_bonus, gem_properties, extended_cost, disanchant_require_lvl, unk_141, ";//9 , 126
		ss << " name, description,";
		ss << " is_randomizable,is_charm,spell_cast_chance_1,spell_cast_chance_2,spell_cast_chance_3,spell_cast_chance_4,spell_cast_chance_5";
		ss << " from item_template ";
		ss << " order by id asc ";
		doQuery(ss.str().c_str());
		res = mysql_store_result ((MYSQL *)mDatabaseConnection);
		while(row = mysql_fetch_row (res))
		{
			item_id = atoi(row[0]);
			new_item = new Item; //do not add templates to dinamic item list. No need to cycle these
			for(i=0;i<ITEM_FIELDS_END_BEFORE_NAME;i++)
				new_item->item_data32[i] = atoi(row[i]);
			//add float values again : they cycle in 3 values = min/max/type
			for(i=0;i<15;i+=3)
			{
				new_item->item_dataf[ITEM_DMG_MIN_0+i] = (float)(atof(row[ITEM_DMG_MIN_0+i]));
				new_item->item_dataf[ITEM_DMG_MAX_0+i] = (float)(atof(row[ITEM_DMG_MAX_0+i]));
			}
			new_item->item_dataf[ITEM_RANGED_MOD_RANGE] = (float)(atof(row[ITEM_RANGED_MOD_RANGE]));
			//make a safe string copy
			safe_strcpy((char*)&new_item->item_data32[ITEM_NAME],row[ITEM_NAME],50);
			safe_strcpy((char*)&new_item->item_data32[ITEM_DESCRIPTION],row[ITEM_NAME+1],100);
//printf("%u)item name %s and desc %s\n",item_id,(char*)&new_item->item_data32[ITEM_NAME],(char*)&new_item->item_data32[ITEM_DESCRIPTION]);
			G_item_prototypes[item_id] = new_item;
			new_item->data32[OBJECT_FIELD_ENTRY]=item_id;
			new_item->item_data32[ITEM_ID] = item_id;
			*(float*)&new_item->data32[OBJECT_FIELD_SCALE_X]=1.0f;
			new_item->data32[ITEM_FIELD_MAXDURABILITY]=new_item->item_data32[ITEM_DURABILITY_MAX];
			new_item->data32[ITEM_FIELD_DURABILITY]=new_item->item_data32[ITEM_DURABILITY_MAX];
			new_item->data32[ITEM_FIELD_FLAGS]=new_item->item_data32[ITEM_FLAGS];
			new_item->data32[ITEM_FIELD_STACK_COUNT]=new_item->item_data32[ITEM_STACK_MAX];
			//set spell charges
			for(i=0;i<5*6;i+=6)
				new_item->data32[ITEM_FIELD_SPELL_CHARGES+i]=new_item->item_data32[ITEM_SPELL_CHARGES + i];
			new_item->item_data32[ITEM_EXTRA_FLAGS]=0;
			if(atoi(row[ITEM_NAME+2]))
			{
//printf("found a randomizable item\n");
				new_item->item_data32[ITEM_EXTRA_FLAGS] |= ITEM_IS_RANDOMISABLE;
			}
			if(atoi(row[ITEM_NAME+3]))
			{
//printf("found a charm item %u\n",item_id);
				new_item->item_data32[ITEM_EXTRA_FLAGS] |= ITEM_IS_CHARM;
			}
			new_item->item_data32[ITEM_SPELL_CAST_CHANCE_0+0]=atoi(row[ITEM_NAME+4]);
			new_item->item_data32[ITEM_SPELL_CAST_CHANCE_0+1]=atoi(row[ITEM_NAME+5]);
			new_item->item_data32[ITEM_SPELL_CAST_CHANCE_0+2]=atoi(row[ITEM_NAME+6]);
			new_item->item_data32[ITEM_SPELL_CAST_CHANCE_0+3]=atoi(row[ITEM_NAME+7]);
			new_item->item_data32[ITEM_SPELL_CAST_CHANCE_0+4]=atoi(row[ITEM_NAME+8]);
			if(atoi(row[1])==ITEM_CLASS_CONTAINER)
				new_item->convert_to_conatiner(1);
			new_item->state1 |= ITEM_STATE_IS_TEMPLATE;
			if(new_item->is_static_item())
				new_item->state1 |= ITEM_STATE_IS_STATIC;
			row_number++;
		}
		mysql_free_result (res);
#ifdef _DEBUG
       LOG.outString ("Loaded %u item templates\n",row_number);
#endif
}

//use the stupid/lamest bubblesort to sort a vector
void sort_item_mods_vect(Item_mod **vect,uint32 elements)
{
	uint32 i,j;
	Item_mod *temp;
	for(i=0;i<elements-1;i++)
		for(j=i+1;j<elements;j++)
			if(vect[i]->use_cost>vect[j]->use_cost)
			{
				//swap the 2 elements
				temp = vect[i];
				vect[i] = vect[j];
				vect[j] = temp;
			}
}

void DatabaseInterface::load_item_mods()
{
	char query[300];
	MYSQL_RES *res ;
	MYSQL_ROW row;
	uint32 row_number=0,i,j;
	std::stringstream	ss;
	//get the biggest map_id
	sprintf(query,"SELECT id from item_mods order by id desc limit 0,1");
	doQuery(query);
	res = mysql_store_result ((MYSQL *)mDatabaseConnection);
	row = mysql_fetch_row (res);
	G_max_item_mods = atoi(row[0])+1;
	G_item_mods = (Item_mod**)malloc(sizeof(Item_mod*)*G_max_item_mods);
	memset(G_item_mods,NULL,sizeof(Item_mod*)*G_max_item_mods);
	mysql_free_result (res);
	ss.str( "" );
	ss << "select id,suffix,prefix,req_class,req_subclass";
	for(i=1;i<=MAX_ITEM_MOD_AFFECTS_PER_MOD;i++)
		ss << ",aff_what_" << i << ",aff_type_" << i << ",aff_val_" << i;
	ss << " from item_mods order by id";
	doQuery(ss.str().c_str());
	res = mysql_store_result ((MYSQL *)mDatabaseConnection);
	while(row = mysql_fetch_row (res))
	{
		uint32 mod_id = atoi(row[0]);
		G_item_mods[mod_id] = new Item_mod;
		G_item_mods[mod_id]->mod_id = mod_id;
		safe_strcpy(G_item_mods[mod_id]->suffix,row[1],MAX_ITEM_MOD_NAME);
		safe_strcpy(G_item_mods[mod_id]->preffix,row[2],MAX_ITEM_MOD_NAME);
		G_item_mods[mod_id]->require_item_class_flags = atoi(row[3]);
		G_item_mods[mod_id]->require_item_subclass_flags = atoi(row[4]);
		for(i=0;i<MAX_ITEM_MOD_AFFECTS_PER_MOD;i++)
		{
            G_item_mods[mod_id]->affect_what[i] = atoi(row[5+i*3]);
			G_item_mods[mod_id]->affect_type[i] = atoi(row[6+i*3]);
			G_item_mods[mod_id]->affect_value[i] = (float)atof(row[7+i*3]);
		}
		//calc an aproximate value fro this randomization
		G_item_mods[mod_id]->use_cost=0;
		for(i=0;i<MAX_ITEM_MOD_AFFECTS_PER_MOD;i++)
		{
			uint8 mul=0;
			if(G_item_mods[mod_id]->affect_type[i]==ITEM_MOD_AFFECT_TYPE_SET)mul=1;
			else if(G_item_mods[mod_id]->affect_type[i]==ITEM_MOD_AFFECT_TYPE_ADD)mul=2;
			else if(G_item_mods[mod_id]->affect_type[i]==ITEM_MOD_AFFECT_TYPE_MUL)mul=4;
			if(G_item_mods[mod_id]->affect_what[i]!=ITEM_SPELL_ID)
				G_item_mods[mod_id]->use_cost += (uint32)(mul * G_item_mods[mod_id]->affect_value[i]);
		}
		row_number++;
	}
	memset(G_max_item_mods_sorted,0,MAX_ITEM_CLASS_TYPES*MAX_ITEM_SUBCLASS_TYPES*sizeof(uint32));
	//fill "sorted" lists
	for(i=0;i<row_number;i++)
	if(G_item_mods[i])
	{
		uint32 cur_class_mask=G_item_mods[i]->require_item_class_flags;
		uint32 cur_subclass_mask;
		uint32 cur_class=0,cur_subclass;
		while(cur_class_mask && cur_class<MAX_ITEM_CLASS_TYPES)
		{
			if(cur_class_mask % 2)
			{
				cur_subclass_mask=G_item_mods[i]->require_item_subclass_flags;
				cur_subclass = 0;
				while(cur_subclass_mask)
				{
					if((cur_subclass_mask % 2) && cur_subclass < MAX_ITEM_SUBCLASS_TYPES)
					{
						//add this mod to current class+subclass
						G_item_mods_sorted[cur_class][cur_subclass]=(Item_mod**)realloc(G_item_mods_sorted[cur_class][cur_subclass],(G_max_item_mods_sorted[cur_class][cur_subclass]+1)*sizeof(Item_mod**));
						G_item_mods_sorted[cur_class][cur_subclass][G_max_item_mods_sorted[cur_class][cur_subclass]]=G_item_mods[i];
						G_max_item_mods_sorted[cur_class][cur_subclass] ++;
					}
					cur_subclass +=1;
					cur_subclass_mask /=2;
				}
			}
			cur_class +=1;
			cur_class_mask /=2;
		}
	}
	//sort the "sorted" lists
	for(i=0;i<MAX_ITEM_CLASS_TYPES;i++)
		for(j=0;j<MAX_ITEM_SUBCLASS_TYPES;j++)
			if(G_max_item_mods_sorted[i][j])
			{
//printf("have mods for class %u subclass %u\n",i,j);
				sort_item_mods_vect(G_item_mods_sorted[i][j],G_max_item_mods_sorted[i][j]);
			}
#ifdef _DEBUG
	LOG.outString ("Loaded %u item mods\n",row_number);
#endif
	mysql_free_result (res);
}

void DatabaseInterface::load_static_loot_templates()
{
	char query[300];
	MYSQL_RES *res;
	MYSQL_ROW row;
	uint32 row_number=0,tempate_nr=0;
	sprintf(query,"SELECT template_id from loot_templates order by template_id desc limit 0,1");
	doQuery(query);
	res = mysql_store_result ((MYSQL *)mDatabaseConnection);
	row = mysql_fetch_row (res);
	if(!row)
	{
		G_max_loot_template_id = 0;
		G_static_loot_templates = NULL;
		return;
	}
	G_max_loot_template_id = atoi(row[0])+1;
	G_static_loot_templates = (Loot_template_list**)malloc(sizeof(Loot_template_list*)*G_max_loot_template_id);
	memset(G_static_loot_templates,NULL,sizeof(Loot_template_list*)*G_max_loot_template_id);
	mysql_free_result (res);
	sprintf(query,"select template_id,item_id,chance from loot_templates order by template_id");
	doQuery(query);
	res = mysql_store_result ((MYSQL *)mDatabaseConnection);
	while(row = mysql_fetch_row (res))
	{
		uint32 cur_template_id=atoi(row[0]);
		if(G_static_loot_templates[cur_template_id]==NULL)
		{
			G_static_loot_templates[cur_template_id] = new Loot_template_list();
			tempate_nr++;
		}
		G_static_loot_templates[cur_template_id]->add(atoi(row[1]),atoi(row[2]));
		row_number++;
	}
#ifdef _DEBUG
	LOG.outString ("Loaded %u static loot templates, with %u loots\n",tempate_nr,row_number);
#endif
}

void DatabaseInterface::load_area_info()
{
	  MYSQL_RES *res;
      MYSQL_ROW row;
	  uint32 row_number=0;
	  Area *cur_area;
	  doQuery("select map_id,explore_flag,min_x,min_y,max_x,max_y from map_area order by map_id");
	  res = mysql_store_result ((MYSQL *)mDatabaseConnection);
	  while(row = mysql_fetch_row (res))
		  if(G_maps[atoi(row[0])]!=NULL)
          {
			  cur_area = new Area;
			  cur_area->explore_flag = atoi(row[1]);
			  cur_area->min_x = (float)atof(row[2]);
			  cur_area->min_y = (float)atof(row[3]);
			  cur_area->max_x = (float)atof(row[4]);
			  cur_area->max_y = (float)atof(row[5]);
			  G_maps[atoi(row[0])]->area_list.add(cur_area);
			  row_number++;
		  }
   mysql_free_result (res);
#ifdef _DEBUG
       LOG.outString ("Loaded %u areas\n",row_number);
#endif
}

void DatabaseInterface::load_graveyards()
{
	MYSQL_RES *res;
	MYSQL_ROW row;
	creature *new_creature;
	uint32 row_number=0;
	doQuery("select map_id,respawn_x,respawn_y,respawn_z,respawn_o,spirit_x,spirit_y,spirit_z,spirit_o,template_id from graveyards order by map_id");
	res = mysql_store_result ((MYSQL *)mDatabaseConnection);
	while(row = mysql_fetch_row (res))
		if(G_maps[atoi(row[0])]!=NULL)
		{
			//add the respawn location
			G_maps[atoi(row[0])]->graveyard_list.add((float)atof(row[1]),(float)atof(row[2]),(float)atof(row[3]),(float)atof(row[4]));
			//add spawn point for the spirit healer
			uint32 template_id=atoi(row[9]);
			if(G_creature_prototypes[template_id]!=NULL && template_id<G_max_creature_prototypes)
			{
				//create a new instance
				new_creature = new creature;
				new_creature->init_from_template(G_creature_prototypes[template_id]);
				new_creature->data32[UNIT_FIELD_FLAGS] = UNIT_FLAG_SPIRITHEALER;
				new_creature->data32[UNIT_NPC_FLAGS] = 33;
				new_creature->pos_x = (float)atof(row[5]);
				new_creature->pos_y = (float)atof(row[6]);
				new_creature->pos_z = (float)atof(row[7]);
				new_creature->orientation = (float)(atof(row[8]));
				new_creature->map_id = atoi(row[0]);
				new_creature->flags1 = CREATURE_FLAG_STAND;

				new_creature->data32[UNIT_FIELD_AURA] = 10848;
				new_creature->data32[UNIT_FIELD_AURA+48] = 9;
				new_creature->data32[UNIT_FIELD_AURA+54] = 60;
				new_creature->data32[UNIT_FIELD_AURALEVELS+7] = 2000;
				new_creature->data32[UNIT_FIELD_AURAAPPLICATIONS+2] = 1056964608;
				new_creature->data32[UNIT_FIELD_AURAAPPLICATIONS+3] = 1069547520;
				new_creature->data32[UNIT_FIELD_AURAAPPLICATIONS+4] = 5233;
				new_creature->data32[UNIT_FIELD_AURAAPPLICATIONS+5] = 5233;
				new_creature->data32[UNIT_FIELD_AURAAPPLICATIONS+11] = 16777216;
				new_creature->data32[UNIT_FIELD_BYTES_0] = 16843008;
				new_creature->data32[UNIT_FIELD_BYTES_1] = 16777216;
				new_creature->data32[UNIT_FIELD_BYTES_2] = 1;
//				new_creature->data32[UNIT_FIELD_FLAGS] = 768;
//				new_creature->data32[UNIT_NPC_FLAGS] = 65;

				new_creature->spawn(); //this will add it to mapmanager
				G_maps[atoi(row[0])]->del_creature(new_creature); //we only show it if we are dead
				G_maps[atoi(row[0])]->graveyard_list.spirit_healers.add(new_creature);
			}
			row_number++;
		}
		mysql_free_result (res);
#ifdef _DEBUG
		LOG.outString ("Loaded %u graveyards\n",row_number);
#endif
}

void DatabaseInterface::load_custom_areatriggers()
{
	MYSQL_RES *res;
	MYSQL_ROW row;
	uint32 row_number=0;
	doQuery("select id,on_enter_type,map_id,x1,y1,z1,x2,y2,z2,param1,param2,param3,param4,param_txt,on_exit_type from custom_areatriggers order by id");
	res = mysql_store_result ((MYSQL *)mDatabaseConnection);
	while(row = mysql_fetch_row (res))
	{
		uint32 map_id=atoi(row[2]);
		if(map_id>G_max_map_id || G_maps[map_id]==NULL)
			continue;
		//create a new trigger and add to each cell that the location covers
		Area_trigger_Node *new_node;
		new_node = new Area_trigger_Node;
		new_node->value.id = atoi(row[0]);
		new_node->value.on_enter_type = atoi(row[1]);
		new_node->value.map_id = atoi(row[2]);
		new_node->value.x1 = (float)(atof(row[3]));
		new_node->value.y1 = (float)(atof(row[4]));
		new_node->value.z1 = (float)(atof(row[5]));
		new_node->value.x2 = (float)(atof(row[6]));
		new_node->value.y2 = (float)(atof(row[7]));
		new_node->value.z2 = (float)(atof(row[8]));
		new_node->value.param[0] = (float)(atof(row[9]));
		new_node->value.param[1] = (float)(atof(row[10]));
		new_node->value.param[2] = (float)(atof(row[11]));
		new_node->value.param[3] = (float)(atof(row[12]));
		new_node->value.on_exit_type = atoi(row[13]);
		uint32 ptxtlen = strlen(row[13]);
		if(ptxtlen)
		{
			new_node->value.msg_param1 = (char*)malloc(ptxtlen+1);
			strcpy(new_node->value.msg_param1,row[13]);
		}
		//for each map cell that is covered by this area trigger we add it to them
		int cell_size = G_maps[new_node->value.map_id]->cell_size;
		int min_x = G_maps[new_node->value.map_id]->min_x;
		int min_y = G_maps[new_node->value.map_id]->min_y;
		uint32 t;
		uint32 cells_x = G_maps[new_node->value.map_id]->cells_x;
		uint32 first_cell_x = (int32)abs((new_node->value.x1 - min_x) / cell_size);
		uint32 last_cell_x = (int32)abs((new_node->value.x2 - min_x) / cell_size);
		uint32 first_cell_y = (int32)abs((new_node->value.y1 - min_y) / cell_size);
		uint32 last_cell_y = (int32)abs((new_node->value.y2 - min_y) / cell_size);
		if(first_cell_x>last_cell_x)
		{
			t = first_cell_x;
			first_cell_x = last_cell_x;
			last_cell_x = t;
		}
		if(first_cell_y>last_cell_y)
		{
			t = first_cell_y;
			first_cell_y = last_cell_y;
			last_cell_y = t;
		}
//printf("fx=%u,lx=%u,fy=%u,ly=%u\n",first_cell_x,last_cell_x,first_cell_y,last_cell_y);
		uint32 i,j;
		for(i=first_cell_y;i<=last_cell_y;i++)
			for(j=first_cell_x;j<=last_cell_x;j++)
			{
				//create a new node and add it to current list
				Area_trigger_Node *tnew_node;
				tnew_node = new Area_trigger_Node;
				memcpy(tnew_node,new_node,sizeof(Area_trigger_Node));
//printf("adding areatrigger to cell %u %u \n",i,j);
				G_maps[new_node->value.map_id]->cells[i*cells_x+j]->areatriggers_lst.add(tnew_node);
			}
		delete new_node;
		row_number++;
	}
	mysql_free_result (res);
#ifdef _DEBUG
		LOG.outString ("Loaded %u custom area triggers\n",row_number);
#endif
}

void DatabaseInterface::save_creature_waypoints(creature *cr)
{
	if(cr->db_id==0)
		return;//for some reason this creauture was spawned in world and not added to db
	char query[300];
	Waypoint_Node *wp_itr=cr->waypoint_lst.first;
	uint32 order=0;
	//dump old waypoints for creature
	sprintf(query,"delete from creature_instance_waypoints where creature_instance_id='%d'",cr->db_id);
	doQuery(query);
	while(wp_itr)
	{
		sprintf(query,"insert into creature_instance_waypoints (creature_instance_id,dst_x,dst_y,dst_z,dst_o,wait_at_dst,speed_coef,waypoint_order) values ('%d','%f','%f','%f','%f','%d','%f','%d')",
			cr->db_id,wp_itr->dst_x,wp_itr->dst_y,wp_itr->dst_z,wp_itr->dst_o,wp_itr->dst_time_wait,wp_itr->speed_coef,order);
		order++;
		doQuery(query);
		wp_itr = wp_itr->next;
	}
}

void DatabaseInterface::load_item_random_propertys()
{
	char query[300];
	MYSQL_RES *res;
	MYSQL_ROW row;
	uint32 row_number=0;

	sprintf(query,"SELECT id from item_enchant_template order by id desc limit 0,1");
	doQuery(query);
	res = mysql_store_result ((MYSQL *)mDatabaseConnection);
	row = mysql_fetch_row (res);
	G_max_enchant_id = atoi(row[0])+1;
	G_item_enchantments = (item_enchantment_def**)malloc(sizeof(item_enchantment_def*)*G_max_enchant_id);
	memset(G_item_enchantments,NULL,sizeof(item_enchantment_def*)*G_max_enchant_id);
	mysql_free_result (res);
	doQuery("select id,dispel_type,spell_param,spell_id1,spell_id2,spell_id3,aura_name1,aura_name2 from item_enchant_template");
	res = mysql_store_result ((MYSQL *)mDatabaseConnection);
	while(row = mysql_fetch_row (res))
	{
		uint32 cur_id=atoi(row[0]);
		G_item_enchantments[cur_id]=new item_enchantment_def;
		G_item_enchantments[cur_id]->id = cur_id;
		G_item_enchantments[cur_id]->dispel_type = atoi(row[1]);
		G_item_enchantments[cur_id]->spell_value = atoi(row[2]);
		G_item_enchantments[cur_id]->spell_id[0] = atoi(row[3]);
		G_item_enchantments[cur_id]->spell_id[1] = atoi(row[4]);
		G_item_enchantments[cur_id]->spell_id[2] = atoi(row[5]);
		G_item_enchantments[cur_id]->aura_name[0] = atoi(row[6]);
		G_item_enchantments[cur_id]->aura_name[1] = atoi(row[7]);
		row_number++;
	}
	mysql_free_result (res);
#ifdef _DEBUG
		LOG.outString ("Loaded %u item enchant definitions",row_number);
#endif

	row_number=0;
	sprintf(query,"SELECT id from item_random_properties order by id desc limit 0,1");
	doQuery(query);
	res = mysql_store_result ((MYSQL *)mDatabaseConnection);
	row = mysql_fetch_row (res);
	G_max_random_property_id = atoi(row[0])+1;
	G_item_random_property = (item_random_property_def**)malloc(sizeof(item_random_property_def*)*G_max_random_property_id);
	memset(G_item_random_property,NULL,sizeof(item_random_property_def*)*G_max_random_property_id);
	mysql_free_result (res);
	doQuery("select id,enchant_1,enchant_2,enchant_3 from item_random_properties");
	res = mysql_store_result ((MYSQL *)mDatabaseConnection);
	while(row = mysql_fetch_row (res))
	{
		uint32 cur_id=atoi(row[0]);
		G_item_random_property[cur_id]=new item_random_property_def;
		G_item_random_property[cur_id]->ench[0] = G_item_enchantments[atoi(row[1])];
		G_item_random_property[cur_id]->ench[1] = G_item_enchantments[atoi(row[2])];
		G_item_random_property[cur_id]->ench[2] = G_item_enchantments[atoi(row[3])];
		row_number++;
	}
	mysql_free_result (res);
#ifdef _DEBUG
		LOG.outString ("Loaded %u item random property definitions\n",row_number);
#endif
}

