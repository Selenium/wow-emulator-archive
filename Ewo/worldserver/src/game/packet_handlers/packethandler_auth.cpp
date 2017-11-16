// Copyright (C) 2006 Team Evolution
#include "packethandler_auth.h"
#include "BigNumber.h"
#include "Sha1.h"
#include "Character.h"

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void send_proficiency (GameClient *pClient,uint8 b1, uint8 b2, uint8 b3, uint8 b4, uint8 b5)
{
	G_send_packet.opcode = SMSG_SET_PROFICIENCY;
	G_send_packet.length=5;
	G_send_packet.data[0]=b1;
	G_send_packet.data[1]=b2;
	G_send_packet.data[2]=b3;
	G_send_packet.data[3]=b4;
	G_send_packet.data[4]=b5;
	pClient->SendMsg( &G_send_packet );
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_AUTH_SESSION(GameClient *pClient)
{
#ifdef _DEBUG
	LOG.outString ("WORLD: Recvd Auth Challenge.");
#endif
	if(G_recv_packet.length < 8)
		return;
	strcpy (pClient->user, (char *)G_recv_packet.data+8);
	int account_id=-1;
	Socket *net = pClient->getNetwork();
	account_id = G_dbi_r->Login(pClient->user, net->getIP());
	if (account_id == -2) // account does not exist
	{
		// Send Bad Account
		G_send_packet.opcode = SMSG_AUTH_RESPONSE;
		G_send_packet.data[0] = 21;
		G_send_packet.length = 1;
		pClient->SendMsg(&G_send_packet);
#ifdef _DEBUG
		LOG.outString ("WORLD: Sent Auth Response (unknown account).");
#endif
		WORLDSERVER.disconnect_client(pClient);
		return;
	} 
	if (account_id == -3) // account already online
	{
		G_send_packet.opcode = SMSG_AUTH_RESPONSE;
		G_send_packet.data[0] = 13;
		G_send_packet.length = 1;
		pClient->SendMsg(&G_send_packet);
#ifdef _DEBUG
		LOG.outString ("WORLD: Sent Auth Response (already connected).");
#endif
		WORLDSERVER.disconnect_client(pClient);
		return;
	} 
	//get the sshash from database.
	G_dbi_r->get_account_hash(pClient->user,pClient->SS_Hash);

	BigNumber K;
	K.SetHexStr(pClient->SS_Hash);
    Sha1Hash sha;
    uint32 t = 0;
    uint32 seed = 0x336E6295;
	uint32 pos_after_name=8+strlen(pClient->user)+1;
	uint32 clientSeed=*(uint32*)&G_recv_packet.data[pos_after_name];
	uint8	*digest=&G_recv_packet.data[pos_after_name+4];
//printf("account is %s\n clientseed %d \n,pos after_ame %d\n value before seed %d\n,hash %s",(char *)G_recv_packet.data+8,clientSeed,pos_after_name,G_recv_packet.data[pos_after_name-1],pClient->SS_Hash);
    sha.UpdateData(pClient->user);
    sha.UpdateData((uint8 *)&t, 4);
    sha.UpdateData((uint8 *)&clientSeed, 4);
    sha.UpdateData((uint8 *)&seed, 4);
    sha.UpdateBigNumbers(&K, NULL);
    sha.Finalize();
    if (memcmp(sha.GetDigest(), digest, 20))
    {
        // Sending Authentification Failed
		G_send_packet.opcode = SMSG_AUTH_RESPONSE;
		G_send_packet.data[0] = AUTH_UNKNOWN_ACCOUNT;
		G_send_packet.length = 1;
		pClient->SendMsg(&G_send_packet);
        return;
    }
	memcpy(pClient->SS_Hash,K.AsByteArray(),40);

//#ifdef _DEBUG
//	printBytes(pClient->SS_Hash, 40, "SS_Hash");
//#endif
	// Variables for Main loop that need to be different per client
	pClient->BindAcctID(account_id);
	pClient->start_encode_decode();
	//int account_lvl = dbi->getAccountLvl(account_id);
	int account_lvl = 0;
	pClient->setAccountLvl(account_lvl);
	pClient->setAuth();
	// Send Auth Successful
#ifdef _DEBUG
	Sleep(50);
#endif
	G_send_packet.opcode = SMSG_AUTH_RESPONSE;
	G_send_packet.data[0] = AUTH_OK;
	G_send_packet.data[1] = 0xB4;
	G_send_packet.data[2] = 0xF1;
	G_send_packet.data[3] = 0xB5;
	G_send_packet.data[4] = 0xFE;
	G_send_packet.data[5] = 0x42;
	G_send_packet.data[6] = 0x00;
	G_send_packet.data[7] = 0x00;
	G_send_packet.data[8] = 0x00;
	G_send_packet.data[9] = 0x00;
	if(G_dbi_r->account_client_addons(account_id)==1)	G_send_packet.data[10] = 0x01;//require bc ?
	else G_send_packet.data[10] = 0x00;//normal wow for you sun :P 
	G_send_packet.length = 11;
	pClient->SendMsg(&G_send_packet);
#ifdef _DEBUG
	LOG.outString ("WORLD: Sent Auth Response (ok).");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_UPDATE_ACCOUNT_DATA(GameClient *pClient)
{
#ifdef _DEBUG
	LOG.outString ("WORLD: Dumping CMSG_UPDATE_ACCOUNT_DATA");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_CHAR_ENUM(GameClient *pClient)
{
	//get new chars
	pClient->refresh_char_snapshots();
	G_send_packet.opcode = SMSG_CHAR_ENUM;
	G_send_packet.data[0] = pClient->numCharacters();
	G_send_packet.length = 1;
	// Iterate through once because each individual character packet length varies based on the
	// size of their username.  It's always 159 + a max of 21 characters in the name
	CharacterSnapshotList::iterator itr;
	uint8 length = 0;
	for (itr = pClient->charListBegin(); itr != pClient->charListEnd(); ++itr)
	{
		//if our send buffer is too small we resize it
		G_send_packet.resize_if_too_small(G_send_packet.length+181);
		memcpy(G_send_packet.data+G_send_packet.length,(*itr)->buffer+1,(*itr)->buffer[0]);
		G_send_packet.length += (*itr)->buffer[0];
	}
	pClient->SendMsg( &G_send_packet );
#ifdef _DEBUG
	LOG.outString ("WORLD: Sent SMSG_CHAR_ENUM.");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_CHAR_CREATE(GameClient *pClient)
{
	if (G_dbi_r->IsNameTaken((char*)G_recv_packet.data))
	{
		G_send_packet.length = 1;
		G_send_packet.opcode = SMSG_CHAR_CREATE;
		G_send_packet.data[0] = CHAR_CREATE_NAME_IN_USE;
		pClient->SendMsg( &G_send_packet );
	}
	else if(G_dbi_r->number_of_char_for_account(pClient->m_accountId)>=LIMIT_CHARS_PER_REALM)
	{
		G_send_packet.length = 1;
		G_send_packet.opcode = SMSG_CHAR_CREATE;
		G_send_packet.data[0] = CHAR_CREATE_FAILED;
		pClient->SendMsg( &G_send_packet );
	}
	else 
	{
		Character * pNewChar = G_Object_Pool.Get_New_Character();
		pNewChar->pClient = pClient;
		pNewChar->Create( G_recv_packet );
		pNewChar->state1 = PLAYER_STATE_JUST_CREATED;
		G_dbi_r->add_character( pNewChar );
		//create snapshot for enum
		Char_snapshot *char_snapshot=new Char_snapshot;
		char_snapshot->create_snapshot(pNewChar);
		pClient->m_charsnapshots.push_front(char_snapshot);//save the snapshot because we are going to use it any minute now for enum packet
		G_send_packet.length = 1;
		G_send_packet.opcode = SMSG_CHAR_CREATE;
		G_send_packet.data[0] = CHAR_CREATE_OK; 
		pClient->SendMsg( &G_send_packet );
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: Sent SMSG_CHAR_CREATE.");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_CHAR_DELETE(GameClient *pClient)
{
	uint32 t_db_id=pClient->db_id_from_snapshot_guid(G_recv_packet.data32[0],G_recv_packet.data32[1]);
	uint32 object_type=G_recv_packet.data32[1];
	G_send_packet.length = 1;
	G_send_packet.opcode = SMSG_CHAR_DELETE;
	if(object_type & HIGHGUID_PLAYER)
	{
		G_dbi_r->del_character( t_db_id );
		pClient->erase_character_snapshot( t_db_id );
		G_send_packet.data[0] = CHAR_DELETE_OK;
	}
	else G_send_packet.data[0] = CHAR_DELETE_FAIL;
	pClient->SendMsg( &G_send_packet );
#ifdef _DEBUG
	LOG.outString ("WORLD: Sent SMSG_CHAR_DELETE.");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_PLAYER_LOGIN(GameClient *pClient)
{
//	if(!((G_recv_packet.data32[1] & HIGHGUID_OBJECT_TYPE_MASK)==HIGHGUID_PLAYER))
//		return;
	//the received guid is wrong but we can get the db_id out of it :)
	uint32 t_db_id=pClient->db_id_from_snapshot_guid(G_recv_packet.data32[0],G_recv_packet.data32[1]);
	Character *cur_char=G_Object_Pool.Get_New_Character();
	cur_char->db_id = t_db_id;
	cur_char->pClient = pClient;
    cur_char->load_from_db();
	uint32 number_of_objects_to_update=0;
	uint32 t_length=0;
	uint32 i;
	if(cur_char->map_id>G_max_map_id || !G_maps[cur_char->map_id])
	{
		printf("!!!!OMG player has a map that is not defiend for world server. Cannot let him log in \n");
		return; //can't login a player that has unknown map
	}
	pClient->setCurrentChar(cur_char);
	pClient->setLoggedIn ();

/*	G_send_packet.opcode = 0x0329;
	G_send_packet.data32[0] = 0x00;
	G_send_packet.data32[1] = 0x01;
	G_send_packet.data32[2] = 0x00;
	G_send_packet.length = 12;
	cur_char->SendMsg(&G_send_packet);

	G_send_packet.opcode = 0x0329;
	G_send_packet.data32[0] = 0x00;
	G_send_packet.data32[1] = 0xC60BF22F;
	G_send_packet.data32[2] = 0x429AC28B;
	G_send_packet.data32[2] = 0x432B2057;
	G_send_packet.data32[2] = 0x40974C95;
	G_send_packet.length = 12;
	cur_char->SendMsg(&G_send_packet);*/

	//account md5 - have no idea yet to what to set it
	G_send_packet.opcode = SMSG_ACCOUNT_DATA_MD5;
	G_send_packet.length=128;
	memset(G_send_packet.data,0,128);
	pClient->SendMsg( &G_send_packet );

	G_send_packet.opcode = SMSG_FRIEND_LIST;
	G_send_packet.data[0]=0;
	//foreach(friendguid)
	//{
	//	G_send_packet.data64[G_send_packet.data[0]]=friendguid
	//	G_send_packet.data[0]++;
	//}
	G_send_packet.length=1+G_send_packet.data[0]*4;
	pClient->SendMsg( &G_send_packet );

	//same as friend list
	G_send_packet.opcode = SMSG_IGNORE_LIST;
	G_send_packet.length=1+G_send_packet.data[0]*4;
	G_send_packet.data[0]=0;
	pClient->SendMsg( &G_send_packet );

	//rest state
	G_send_packet.opcode = SMSG_SET_REST_START;
	G_send_packet.data32[0]=time(NULL);
	G_send_packet.length=4;
	pClient->SendMsg( &G_send_packet );

	//bindpoint update
	G_send_packet.opcode = SMSG_BINDPOINTUPDATE;
	G_send_packet.dataf[0]=cur_char->bind_x;
	G_send_packet.dataf[1]=cur_char->bind_y;
	G_send_packet.dataf[2]=cur_char->bind_z;
	G_send_packet.data32[3]=cur_char->bind_map_id;
	G_send_packet.data32[4]=cur_char->bind_area_id;
	G_send_packet.length=20;
	pClient->SendMsg( &G_send_packet );

	//set proficiency's
	uint8 player_class=(uint8)((cur_char->data32[UNIT_FIELD_BYTES_0] >> 8) & 0xFF);
	switch (player_class)
	{
	case PLAYER_CLASS_MAGE:
		send_proficiency (pClient, 0x04, 0x02, 0x00, 0x00);
		send_proficiency (pClient, 0x02, 0x00, 0x04, 0x00);
		send_proficiency (pClient, 0x02, 0x00, 0x44, 0x00);
		send_proficiency (pClient, 0x04, 0x03, 0x00, 0x00);
		send_proficiency (pClient, 0x02, 0x00, 0x44, 0x08);
		break;
	case PLAYER_CLASS_ROGUE:
		send_proficiency (pClient, 0x04, 0x02, 0x00, 0x00);
		send_proficiency (pClient, 0x02, 0x00, 0x00, 0x01);
		send_proficiency (pClient, 0x04, 0x06, 0x00, 0x00);
		send_proficiency (pClient, 0x02, 0x00, 0x80, 0x01);
		send_proficiency (pClient, 0x02, 0x00, 0xC0, 0x01);
		send_proficiency (pClient, 0x04, 0x07, 0x00, 0x00);
		break;
	case PLAYER_CLASS_WARRIOR:
		send_proficiency (pClient, 0x04, 0x02, 0x00, 0x00);
		send_proficiency (pClient, 0x02, 0x01, 0x00, 0x00);
		send_proficiency (pClient, 0x02, 0x11, 0x00, 0x00);
		send_proficiency (pClient, 0x04, 0x42, 0x00, 0x00);
		send_proficiency (pClient, 0x04, 0x4A, 0x00, 0x00);
		send_proficiency (pClient, 0x04, 0x4E, 0x00, 0x00);
		send_proficiency (pClient, 0x02, 0x11, 0x40, 0x00);
		send_proficiency (pClient, 0x04, 0x4F, 0x00, 0x00);
		send_proficiency (pClient, 0x02, 0x91, 0x40, 0x00);
		break;
	case PLAYER_CLASS_PALADIN:
		send_proficiency (pClient, 0x04, 0x02, 0x00, 0x00);
		send_proficiency (pClient, 0x02, 0x10, 0x00, 0x00);
		send_proficiency (pClient, 0x04, 0x42, 0x00, 0x00);
		send_proficiency (pClient, 0x02, 0x30, 0x00, 0x00);
		send_proficiency (pClient, 0x04, 0x4A, 0x00, 0x00);
		send_proficiency (pClient, 0x04, 0x4E, 0x00, 0x00);
		send_proficiency (pClient, 0x02, 0x30, 0x40, 0x00);
		send_proficiency (pClient, 0x04, 0x4F, 0x00, 0x00);
		break;
	case PLAYER_CLASS_WARLOCK:
		send_proficiency (pClient, 0x04, 0x02, 0x00, 0x00);
		send_proficiency (pClient, 0x02, 0x00, 0x80, 0x00);
		send_proficiency (pClient, 0x02, 0x00, 0xC0, 0x00);
		send_proficiency (pClient, 0x04, 0x03, 0x00, 0x00);
		send_proficiency (pClient, 0x02, 0x00, 0xC0, 0x08);
		break;
	case PLAYER_CLASS_PRIEST:
		send_proficiency (pClient, 0x04, 0x02, 0x00, 0x00);
		send_proficiency (pClient, 0x02, 0x10, 0x00, 0x00);
		send_proficiency (pClient, 0x02, 0x10, 0x40, 0x00);
		send_proficiency (pClient, 0x04, 0x03, 0x00, 0x00);
		send_proficiency (pClient, 0x02, 0x10, 0x40, 0x08);
		break;
	case PLAYER_CLASS_DRUID:
		send_proficiency (pClient, 0x04, 0x02, 0x00, 0x00);
		send_proficiency (pClient, 0x02, 0x00, 0x04, 0x00);
		send_proficiency (pClient, 0x04, 0x06, 0x00, 0x00);
		send_proficiency (pClient, 0x02, 0x00, 0x84, 0x00);
		send_proficiency (pClient, 0x02, 0x00, 0xC4, 0x00);
		send_proficiency (pClient, 0x04, 0x07, 0x00, 0x00);
		break;
	case PLAYER_CLASS_HUNTER:
		send_proficiency (pClient, 0x04, 0x02, 0x00, 0x00);
		send_proficiency (pClient, 0x02, 0x01, 0x00, 0x00);
		send_proficiency (pClient, 0x04, 0x06, 0x00, 0x00);
		send_proficiency (pClient, 0x02, 0x05, 0x00, 0x00);
		send_proficiency (pClient, 0x02, 0x05, 0x40, 0x00);
		send_proficiency (pClient, 0x04, 0x07, 0x00, 0x00);
		break;
	case PLAYER_CLASS_SHAMAN:
		send_proficiency (pClient, 0x04, 0x02, 0x00, 0x00);
		send_proficiency (pClient, 0x02, 0x00, 0x04, 0x00);
		send_proficiency (pClient, 0x02, 0x10, 0x04, 0x00);
		send_proficiency (pClient, 0x04, 0x42, 0x00, 0x00);
		send_proficiency (pClient, 0x04, 0x46, 0x00, 0x00);
		send_proficiency (pClient, 0x02, 0x10, 0x44, 0x00);
		send_proficiency (pClient, 0x04, 0x47, 0x00, 0x00);
		break;
	}

	//tutorial flags (o don't even bother, this will not be implemented unless realy requested)
	G_send_packet.opcode = SMSG_TUTORIAL_FLAGS;
	G_send_packet.length=32;
	for(i=0;i<8;i++)
		G_send_packet.data32[i]=0xffffffff;
	pClient->SendMsg( &G_send_packet );

	//send initial spels
	G_send_packet.opcode = SMSG_INITIAL_SPELLS;
	G_send_packet.data[0]=0; // just 1
	spell_book_node *kur=cur_char->spellbook.first;
	i=0;
	while(kur)
	{
		*(uint16*)&G_send_packet.data[3+i*4] = kur->spell_id; 
		*(uint16*)&G_send_packet.data[3+i*4+2] = i; //slot id -> will always be the same becouse of storring in db
		i++;
		kur=kur->next;
	}
	*(uint16*)&G_send_packet.data[1]=i; //spellcount
	*(uint16*)&G_send_packet.data[3+i*4] = 0;//item cooldown count
	G_send_packet.length = 3+i*4+2;
	uint16	*cooldown_list_count=(uint16*)&G_send_packet.data[3+i*4];
	uint8	*cooldown_list_start=(uint8*)&G_send_packet.data[3+i*4+2];
	//check if we have timer on hearthstone
	spell_cooldown_node *c_itr=cur_char->spell_cooldowns.first;
	i=0;
	while(c_itr && c_itr->spell_id!=8690)
	{
		if(c_itr && c_itr->end_time_stamp>G_cur_time)
		{
			*(uint16*)&cooldown_list_start[i*4] = 1; //amount of items/spells to be updated
			*(uint16*)&cooldown_list_start[i*4+2] = 8690;//spell id
			*(uint16*)&cooldown_list_start[i*4+4] = 6948;//item_id
			*(uint16*)&cooldown_list_start[i*4+6] = 89; //category
			*(uint32*)&cooldown_list_start[i*4+8] = 0; //just 0
			*(uint32*)&cooldown_list_start[i*4+12] = (c_itr->end_time_stamp - G_cur_time)*1000; //ms remaining
			i++;
		}
		c_itr = c_itr->next;
	}
	G_send_packet.length += i*16;
	*cooldown_list_count=i;
	pClient->SendMsg( &G_send_packet );
/*	if(cur_char->map_id==0)
	{
		G_send_packet.opcode = SMSG_INIT_WORLD_STATES;
		G_send_packet.data32[0]=0;
		G_send_packet.data32[1]=0x0C;
		G_send_packet.data32[2]=0x08D80006;
		G_send_packet.data32[3]=0x00;
		G_send_packet.data32[4]=0x08D70000;
		G_send_packet.data32[5]=0x00;
		G_send_packet.data32[6]=0x08D60000;
		G_send_packet.data32[7]=0x00;
		G_send_packet.data32[8]=0x08D50000;
		G_send_packet.data32[9]=0x00;
		G_send_packet.data32[10]=0x08D30000;
		G_send_packet.data32[11]=0x00;
		G_send_packet.data32[12]=0x08D40000;
		G_send_packet.data32[13]=0x00;
		G_send_packet.data32[14]=0x00;//!!only 16 bit is used !!
		G_send_packet.length = 58;
		cur_char->SendMsg(&G_send_packet);
	}*/

	/*				//the pet bar
	if(*(uint64*)&cur_char->data32[UNIT_FIELD_SUMMON] != 0)
	{
	G_send_packet.opcode = SMSG_PET_SPELLS;
	G_send_packet.length=110;
	G_send_packet.data32[0]=cur_char->data32[UNIT_FIELD_SUMMON];
	G_send_packet.data32[1]=cur_char->data32[UNIT_FIELD_SUMMON+1];
	G_send_packet.data32[2]=0x0000;
	G_send_packet.data32[3]=0x0101;
	G_send_packet.data32[4]=0x0000;
	G_send_packet.data32[5]=0x0000;
	G_send_packet.data32[6]=0x0700;
	G_send_packet.data32[7]=0x0001;
	G_send_packet.data32[8]=0x0700;
	G_send_packet.data32[9]=0x0002;
	G_send_packet.data32[10]=0x0200;
	G_send_packet.data32[11]=0x0000;
	G_send_packet.data32[12]=0x0700;
	G_send_packet.data32[13]=0x0000;
	G_send_packet.data32[14]=0x0400;
	G_send_packet.data32[15]=0x0000;
	G_send_packet.data32[16]=0x0300;
	G_send_packet.data32[17]=0x0000;
	G_send_packet.data32[18]=0x0600;
	G_send_packet.data32[19]=0x0002;
	G_send_packet.data32[20]=0x0500;
	G_send_packet.data32[21]=0x0000;
	G_send_packet.data32[22]=0x0600;
	G_send_packet.data32[23]=0x0000;
	G_send_packet.data32[24]=0x0600;
	G_send_packet.data32[25]=0x0001;
	G_send_packet.data[101]=0x02;
	*(uint*)(&G_send_packet.data[102])=0x0c26;
	*(uint*)(&G_send_packet.data[106])=0x18a3;
	pClient->SendMsg( &G_send_packet );
	}*/

	//action buttons
	G_send_packet.opcode = SMSG_ACTION_BUTTONS;
	for (uint32 i = 0; i < 120; i++)
		G_send_packet.data32[i]=cur_char->actionbuttons[i];
	G_send_packet.length=120*4;
	pClient->SendMsg( &G_send_packet );/**/

	//send reputaion = faction relationship for this player
	G_send_packet.opcode = SMSG_INITIALIZE_FACTIONS;
	G_send_packet.length = NUMBER_OF_FACTIONS*5+4;
	G_send_packet.data32[0] = NUMBER_OF_FACTIONS;
	for (uint32 i = 0; i < NUMBER_OF_FACTIONS; i++)
	{
		G_send_packet.data[i*5+4]=cur_char->reputation[i];
		*(uint32*)(&G_send_packet.data[i*5+5])=cur_char->reputation_val[i];
	}
	pClient->SendMsg( &G_send_packet );

	//login time speed
	time_t minutes = time(NULL) / 60;
	time_t hours = minutes / 60;
	minutes %= 60;
	time_t gameTime = minutes + ( hours << 6 );
	G_send_packet.opcode = SMSG_LOGIN_SETTIMESPEED;
	G_send_packet.length=8;
	G_send_packet.data32[0]=gameTime;
	G_send_packet.dataf[1]=(float)0.017f; //normal game speed
	pClient->SendMsg( &G_send_packet );
	pClient->InWorld(1);
	// create us for other players and we create all other players for us
	pClient->compressed_update.clear();
	//on logon we create ourself to us to (sounds funny)
	cur_char->build_create_block( &pClient->compressed_update,1);
	//we send it now to ourself (don't wait next turn end)
	pClient->SendMsg( pClient->compressed_update.build_packet() );
	//at the end of turn packet should be cleared
	pClient->compressed_update.clear();

	//in case we are dead. This is not beautifull but will do the trick
	//replace char position until we enter the game
	if(cur_char->state1 & (PLAYER_STATE_DEAD | PLAYER_STATE_DEAD & PLAYER_STATE_CORPSE))
	{
		float x,y,z,o;
		x=cur_char->pos_x;
		y=cur_char->pos_y;
		z=cur_char->pos_z;
		o=cur_char->orientation;
		cur_char->pos_x = cur_char->corpse_x;
		cur_char->pos_y = cur_char->corpse_y;
		cur_char->pos_z = cur_char->corpse_z;
		cur_char->orientation = cur_char->corpse_o;
		//add character to mapmanager
		G_maps[cur_char->map_id]->add_char(cur_char);
		//show mobs around corpse
		G_maps[cur_char->map_id]->on_player_entered_block(cur_char);
		//spawn a corpse to corpse to our location. It's createpacket is sent to us 
		cur_char->pcorpse = new corpse(cur_char);
		//enable water walk
		cur_char->Send_SMSG_MOVE_WATER_WALK();
		//restore position where we are
		cur_char->pos_x = x;
		cur_char->pos_y = y;
		cur_char->pos_z = z;
		cur_char->orientation = o;
		//spawn spirit healers only once (will destroy them when player get resurrected)
		pClient->SendMsg(G_maps[cur_char->map_id]->Spirit_healer_prepared_packet.build_packet());
	}
	else
	{
		//add character to mapmanager
		G_maps[cur_char->map_id]->add_char(cur_char);
		//we also gather data from others and send our data to them
		G_maps[cur_char->map_id]->on_player_entered_block(cur_char);
	}

	cur_char->update_mask.Clear();
	//affects must be loaded after placing char on map. Be carefull not to clear changemask after !
	G_dbi_r->load_character_affects(cur_char);
	if(cur_char->state1 & (PLAYER_STATE_DEAD | PLAYER_STATE_CORPSE))
	{
		G_temp_compressed_packet.clear();
		cur_char->build_update_block(&G_temp_compressed_packet,1,0);
		cur_char->pClient->SendMsg(G_temp_compressed_packet.build_packet());
	}
	else
	{
		cur_char->health = (float)cur_char->data32[UNIT_FIELD_MAXHEALTH];
		cur_char->power = (float)cur_char->data32[UNIT_FIELD_MAXPOWER1+cur_char->player_powertype];
	}
//NO_NEED_TO_LOAD_AFEFCTS_ON_CHAR_CORPSE:
	//destroy only newly logged in char and leave the rest unchanged. In case we logout we can find them already laoded. On exit list is cleared
	pClient->erase_character_snapshot(cur_char);
		//trigger cinematics if required
		if((cur_char->state1 & PLAYER_STATE_JUST_CREATED))
		{
#ifndef SERVER_DOTA_COMPILATION
			G_send_packet.opcode = SMSG_TRIGGER_CINEMATIC;
			G_send_packet.length=4;
			uint8 player_race=(uint8)((cur_char->data32[UNIT_FIELD_BYTES_0]));
			switch (player_race)
			{
			case PLAYER_RACE_TYPE_HUMAN:		G_send_packet.data32[0]=81; break;
			case PLAYER_RACE_TYPE_ORC:			G_send_packet.data32[0]=21; break;
			case PLAYER_RACE_TYPE_DWARF:		G_send_packet.data32[0]=41; break;
			case PLAYER_RACE_TYPE_NIGHT_ELF:	G_send_packet.data32[0]=61; break;
			case PLAYER_RACE_TYPE_UNDEAD:		G_send_packet.data32[0]=2; break;
			case PLAYER_RACE_TYPE_TAUREN:		G_send_packet.data32[0]=141; break;
			case PLAYER_RACE_TYPE_GNOME:		G_send_packet.data32[0]=101; break;
			case PLAYER_RACE_TYPE_TROLL:		G_send_packet.data32[0]=121; break;           
			case PLAYER_RACE_TYPE_BLOODELF:		G_send_packet.data32[0]=162; break;           
			case PLAYER_RACE_TYPE_DRAENEI:		G_send_packet.data32[0]=163; break;//has no sound ?
			default:							G_send_packet.data32[0]=81;
			}
			pClient->SendMsg( &G_send_packet );
#endif
			cur_char->state1 = cur_char->state1 &(~PLAYER_STATE_JUST_CREATED);
		}

//	cur_char->cur_spell.char_instant_nomana_cast(0x0344,-1);//spawn self after login :S

		//cast the spawning spell
		G_send_packet.opcode = SMSG_MOVE_UNLOCK_MOVEMENT;
		G_send_packet.data32[0] = 0x00;
		G_send_packet.length = 4;
		cur_char->SendMsg(&G_send_packet);

/*		G_send_packet.opcode = SMSG_CAST_RESULT;
		G_send_packet.data32[0] = 0x344;
		G_send_packet.length = 4;
		cur_char->SendMsg(&G_send_packet);

		G_send_packet.opcode = SMSG_SPELL_START;
		G_send_packet.data[0] = 0xFF;
		*(uint64*)(G_send_packet.data+1) = cur_char->getGUID();
		G_send_packet.data[9] = 0xFF;
		*(uint64*)(G_send_packet.data+10) = cur_char->getGUID();
		*(uint32*)(G_send_packet.data+18) = 0x344;//spell id
		*(uint16*)(G_send_packet.data+22) = 2; //cast flags
		*(uint32*)(G_send_packet.data+24) = 0;
		*(uint16*)(G_send_packet.data+28) = 0; //target mask
		G_send_packet.length = 30;
		cur_char->SendMsg(&G_send_packet);

		G_send_packet.opcode = SMSG_SPELL_GO;
		G_send_packet.data[0] = 0xFF;
		*(uint64*)(G_send_packet.data+1) = cur_char->getGUID();
		G_send_packet.data[9] = 0xFF;
		*(uint64*)(G_send_packet.data+10) = cur_char->getGUID();
		*(uint32*)(G_send_packet.data+18) = 0x344;//spell id
		*(uint16*)(G_send_packet.data+22) = 0x0100; //cast flags
		G_send_packet.data[24] = 1;
		*(uint64*)(G_send_packet.data+25) = cur_char->getGUID();
		G_send_packet.data[33] = 0;
		*(uint16*)(G_send_packet.data+34) = 2; //target mask
		G_send_packet.data[36] = 0;
		G_send_packet.length = 37;
		cur_char->SendMsg(&G_send_packet);*/

		//add time stamp as login time to character acount
		G_dbi_r->set_player_online(cur_char->db_id);

		//				GetPlayer()->m_PVP_timer = 300000;
//		cur_char->Send_SMSG_FORCE_MOVE_UNROOT();
		//load gm level 
		G_dbi_r->get_gm_ticket(cur_char);
		//about the server
		char message_to_world[300];
		// Green letters: player has entered the world.
		WORLDSERVER.send_message(SERVER_ADVERTISE_VERSION,SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,cur_char,NULL);
		WORLDSERVER.send_message((char*)WORLDSERVER.motd.c_str(),SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,cur_char,NULL);
		sprintf(message_to_world,"|cdf20af20 %s |c1f40af20 has enterred the world",cur_char->name);
		WORLDSERVER.send_message(message_to_world,SEND_MESSAGE_TO_EVRYBODY,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,cur_char,NULL);
		//show log to server that somebody entered the game
		printf("%s has entered the game\n",cur_char->name);
#ifdef USE_OBJECT_INTERRUPTS
		On_Player_Login(this);
#endif
#ifdef _DEBUG
		LOG.outString ("WORLD: Sent CMSG_PLAYER_LOGIN.");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

