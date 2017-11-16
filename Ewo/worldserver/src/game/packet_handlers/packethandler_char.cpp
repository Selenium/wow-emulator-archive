// Copyright (C) 2006 Team Evolution
#include "packethandler_char.h"
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_SET_ACTIVE_MOVER(GameClient *pClient)
{
#ifdef _DEBUG
	LOG.outString ("WORLD: Dumping CMSG_SET_ACTIVE_MOVER");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_MSG_LOOKING_FOR_GROUP(GameClient *pClient)
{
#ifdef _DEBUG
	LOG.outString ("WORLD: Dumping MSG_LOOKING_FOR_GROUP");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_SMSG_LOOT_ALL_PASSED(GameClient *pClient)
{
#ifdef _DEBUG
	LOG.outString ("WORLD: Dumping SMSG_LOOT_ALL_PASSED");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_MSG_MOVE_WORLDPORT_ACK(GameClient *pClient)
{
#ifdef _DEBUG
	LOG.outString ("WORLD: Dumping MSG_MOVE_WORLDPORT_ACK");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_FORCE_RUN_SPEED_CHANGE_ACK(GameClient *pClient)
{
#ifdef _DEBUG
	LOG.outString ("WORLD: Dumping CMSG_FORCE_RUN_SPEED_CHANGE_ACK");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_FORCE_RUN_BACK_SPEED_CHANGE_ACK(GameClient *pClient)
{
#ifdef _DEBUG
	LOG.outString ("WORLD: Dumping CMSG_FORCE_RUN_BACK_SPEED_CHANGE_ACK");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_FORCE_SWIM_SPEED_CHANGE_ACK(GameClient *pClient)
{
#ifdef _DEBUG
	LOG.outString ("WORLD: Dumping CMSG_FORCE_SWIM_SPEED_CHANGE_ACK");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_FORCE_MOVE_ROOT_ACK(GameClient *pClient)
{
#ifdef _DEBUG
	LOG.outString ("WORLD: Dumping CMSG_FORCE_MOVE_ROOT_ACK");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_FORCE_MOVE_UNROOT_ACK(GameClient *pClient)
{
#ifdef _DEBUG
	LOG.outString ("WORLD: Dumping CMSG_FORCE_MOVE_UNROOT_ACK");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_MSG_MOVE_TELEPORT_ACK(GameClient *pClient)
{
#ifdef _DEBUG
	LOG.outString ("WORLD: Dumping MSG_MOVE_TELEPORT_ACK");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_MOVE_TIME_SKIPPED(GameClient *pClient)
{
#ifdef _DEBUG
	LOG.outString ("WORLD: Dumping CMSG_MOVE_TIME_SKIPPED");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_MOVE_FALL_RESET(GameClient *pClient)
{
#ifdef _DEBUG
	LOG.outString ("WORLD: Dumping CMSG_MOVE_FALL_RESET");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_MOVE_WATER_WALK_ACK(GameClient *pClient)
{
#ifdef _DEBUG
	LOG.outString ("WORLD: Dumping CMSG_MOVE_WATER_WALK_ACK");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_LOOT_RELEASE(GameClient *pClient)
{
	Character	*cc_char=pClient->mCurrentChar;
	G_send_packet.opcode = SMSG_LOOT_RELEASE_RESPONSE;
	G_send_packet.data64[0]=cc_char->looted_object_guid;
	G_send_packet.data[9]=0x01;
	G_send_packet.length =9;
	pClient->SendMsg(&G_send_packet);
#ifdef _DEBUG
	LOG.outString ("WORLD: Dumping CMSG_LOOT_RELEASE");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_NAME_QUERY(GameClient *pClient)
{
	uint32 object_type;
	Character *cur_char;
	object_type=G_recv_packet.data32[1];
	cur_char=(Character*)G_recv_packet.data32[0];
	if(object_type & HIGHGUID_PLAYER)
	{
		G_send_packet.opcode = SMSG_NAME_QUERY_RESPONSE;
		G_send_packet.data32[0]=G_recv_packet.data32[0];
		G_send_packet.data32[1]=G_recv_packet.data32[1];
		memcpy(&G_send_packet.data[8],cur_char->name,strlen(cur_char->name)+1);
		G_send_packet.length = 8 + strlen(cur_char->name) + 1;
		*(uint32*)&G_send_packet.data[G_send_packet.length]=cur_char->Get_race();
		G_send_packet.length +=4;
		*(uint32*)&G_send_packet.data[G_send_packet.length]=cur_char->Get_gender();
		G_send_packet.length +=4;
		*(uint32*)&G_send_packet.data[G_send_packet.length]=cur_char->Get_class();
		G_send_packet.length +=4;
		pClient->SendMsg(&G_send_packet);
#ifdef _DEBUG
		LOG.outString ("WORLD: Sent SMSG_NAME_QUERY_RESPONSE.");
#endif
	}
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_move(GameClient *pClient)
{
	float new_z=G_recv_packet.dataf[4];
	uint32 move_flags=G_recv_packet.data32[0];
	Character	*cc_char=pClient->mCurrentChar;
	//compressed guid
//	uint8 start = count_bits_in_byte(G_recv_packet.data[0]); //packet masc
//	float new_x = *(float*)&G_recv_packet.data[start];
	//get data from packet
	/*				movement_info minf;				
	uint32 index8=0;
	minf.flags = G_recv_packet.data32[0];
	minf.time = G_recv_packet.data32[1];
	minf.x = G_recv_packet.dataf[2];
	minf.y = G_recv_packet.dataf[3];
	minf.z = G_recv_packet.dataf[4];
	minf.orientation = G_recv_packet.dataf[5];
	index8=6*4;
	if (minf.flags & 0x2000000) // Transport
	{
	minf.unk1 = G_recv_packet.data64[index8/8];
	index8+=8;
	minf.unk2 = G_recv_packet.dataf[index8/4];
	index8+=4;
	minf.unk3 = G_recv_packet.dataf[index8/4];
	index8+=4;
	minf.unk4 = G_recv_packet.dataf[index8/4];
	index8+=4;
	minf.unk5 = G_recv_packet.dataf[index8/4];
	index8+=4;
	index8+=24;
	}*/
	if (move_flags & 0x200000) // Swimming
	{
		//						minf.unk6 = G_recv_packet.dataf[index8/4];
		//					index8+=4;
		if(!(cc_char->state1 & PLAYER_STATE_IN_WATER))
		{
			//register time when we submerged and z value where we started submerging
			cc_char->state1 |= PLAYER_STATE_IN_WATER;
			cc_char->water_level_z=new_z;
		}
		//if we go under water level for x distance then we start counting breath time
		if(cc_char->water_level_z-new_z>UNDERWATER_DISTANCE && cc_char->water_submerge==0)
		{
			cc_char->water_submerge=G_cur_time_ms;
			//start the counter for the client
			G_send_packet.opcode = SMSG_START_MIRROR_TIMER;
			G_send_packet.data32[0] = 1; //type = breath
			uint32 breath_timer = UNDERWATER_BREATH_TIMER;
			if(cc_char->Get_race() == PLAYER_RACE_TYPE_UNDEAD)
				breath_timer *= 2;
			G_send_packet.data32[1] = breath_timer; // value
			G_send_packet.data32[2] = breath_timer; //maxvalue
			G_send_packet.data32[3] = -1; //tspeed = decrease timer
			G_send_packet.data32[4] = 0;
			G_send_packet.data[20] = 0;
			G_send_packet.length = 21;
			pClient->SendMsg(&G_send_packet);
		}
		else if(cc_char->water_level_z-new_z<=UNDERWATER_DISTANCE)
		{
			cc_char->water_submerge=0;
			cc_char->water_dmg=0;
			G_send_packet.opcode = SMSG_STOP_MIRROR_TIMER;
			G_send_packet.data32[0] = 1; //type
			G_send_packet.length = 4;
			pClient->SendMsg(&G_send_packet);
			cc_char->state1 &= ~PLAYER_STATE_DROWNING;
		}
	}
	else cc_char->state1 &= ~PLAYER_STATE_IN_WATER;
	/*				if (move_flags & 0x2000) // Falling
	{
	minf.FallTime = G_recv_packet.data32[index8/4];
	index8+=4;
	minf.unk8 = G_recv_packet.dataf[index8/4];
	index8+=4;
	minf.unk9 = G_recv_packet.dataf[index8/4];
	index8+=4;
	minf.unk10 = G_recv_packet.dataf[index8/4];
	index8+=4;
	minf.unk11 = G_recv_packet.dataf[index8/4];
	index8+=4;
	index8+=20;
	}
	if (minf.flags & 0x4000000)
	{
	minf.unk11 = G_recv_packet.dataf[index8/4];
	index8+=4;
	}*/
	//if yes then we add info to others packet for old and current block (create object/out of range)
	cc_char->prev_x = cc_char->pos_x;
	cc_char->prev_y = cc_char->pos_y;
	cc_char->prev_z = cc_char->pos_z;
	cc_char->prev_orientation = cc_char->orientation;
	cc_char->pos_x = G_recv_packet.dataf[2];
	cc_char->pos_y = G_recv_packet.dataf[3];
	cc_char->pos_z = new_z;
	cc_char->orientation = G_recv_packet.dataf[5];
	cc_char->state1 |= PLAYER_STATE_MOVED_SINCE_LAST_UPDATE;
	//send the packet to others in block
	if(!(cc_char->state1 & (PLAYER_STATE_DEAD | PLAYER_STATE_CORPSE)))
	{
		//prepare the packet to be sent to others
		G_send_packet.opcode = G_recv_packet.opcode;
		G_send_packet.data[0] = 0xFF;
		*(uint32*)&G_send_packet.data[1]=cc_char->getGUIDL();
		*(uint32*)&G_send_packet.data[5]=cc_char->getGUIDH();
		memcpy(&G_send_packet.data[9],G_recv_packet.data,G_recv_packet.length);
		G_send_packet.length = G_recv_packet.length+9;
		G_maps[cc_char->map_id]->send_instant_msg_to_block(cc_char->prev_x,cc_char->prev_y,&G_send_packet,cc_char);
		//check if we changed cells
		//we only change location if we are alive
		G_maps[cc_char->map_id]->change_location(cc_char,cc_char->prev_x,cc_char->prev_y);
	}
	//creature *pcr=(creature*)(cc_char->selected_object_guid);
	//if(pcr)is_in_front(cc_char->pos_x,cc_char->pos_y,cc_char->orientation,pcr->pos_x,pcr->pos_y);
	//printf("current orinetation : %f",cc_char->orientation);
#ifdef _DEBUG
	LOG.outString ("WORLD: handle MSG_MOVE.");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_MSG_MOVE_FALL_LAND(GameClient *pClient)
{
	Character	*cc_char=pClient->mCurrentChar;
#ifdef VERSION_CHAR_MAKE_CREAUTURE_WPOINTS
	cc_char->fall_z = G_recv_packet.dataf[4];
	cc_char->state2 &= ~CHAR_STATE_TO_DO_CREATURE_CORDS_BEFORE_FALL;
	cc_char->state2 |= CHAR_STATE_TO_DO_CREATURE_CORDS_AFTER_FALL;
#else
	if(!(cc_char->state1 & (PLAYER_STATE_DEAD | PLAYER_STATE_SOFT_FALL)))
	{
		uint32 falltime = G_recv_packet.data32[6];
		if(falltime>1100)
		{
			float dmg =  (float)falltime / 100 - 10 + 2;//!! formula is not correct 
			//call interrupt in case we have some weapons
#ifdef USE_OBJECT_INTERRUPTS
			On_Player_Take_DMG(cc_char,dmg,DAMAGE_NON_BLOCKABLE);
#endif
			//this is non blockable dmg so we just substract the value
			cc_char->take_dmg(dmg,0,0,1,255);
			//send client that we received dmg
			G_send_packet.opcode = SMSG_ENVIRONMENTALDAMAGELOG;
			G_send_packet.data32[0] = cc_char->getGUIDL(); 
			G_send_packet.data32[1] = cc_char->getGUIDH(); 
			G_send_packet.data[8] = ENVIROMENTAL_DAMAGE_FALL;
			*(uint32*)&G_send_packet.data[9] = (uint32)dmg;
			G_send_packet.length = 13;
			pClient->SendMsg(&G_send_packet);
		}
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: handle MSG_MOVE_FALL_LAND.");
#endif
#endif 
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_MSG_MOVE_START_SWIM(GameClient *pClient)
{
#ifdef VERSION_CHAR_MAKE_CREAUTURE_WPOINTS
	Character	*cc_char=pClient->mCurrentChar;
	cc_char->fall_z = G_recv_packet.dataf[4];
	cc_char->state2 &= ~CHAR_STATE_TO_DO_CREATURE_CORDS_BEFORE_FALL;
	cc_char->state2 |= CHAR_STATE_TO_DO_CREATURE_CORDS_AFTER_FALL;
#else
	handle_move(pClient);
#endif
#ifdef _DEBUG
	LOG.outString ("WORLD: Send MSG_MOVE_START_SWIM");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_GMTICKET_GETTICKET(GameClient *pClient)
{
	pClient->gm_level = G_dbi_r->get_gm_ticket(pClient->mCurrentChar);
	G_send_packet.opcode = SMSG_GMTICKET_GETTICKET;
	if(pClient->gm_level)
	{
		G_send_packet.data32[0]=6; //we have open ticket
		memcpy(&G_send_packet.data[4],pClient->gm_text,strlen(pClient->gm_text)+1);
		G_send_packet.length = 4 + strlen(pClient->gm_text)+1;
		G_send_packet.data[G_send_packet.length++] = 0; //unk1
		G_send_packet.data[G_send_packet.length++] = 3; //unk2
	}
	else 
	{
		G_send_packet.data32[0]=1;//no ticket
		G_send_packet.data32[1]=0;//""
		G_send_packet.data[8]=0;//unk1
		G_send_packet.data[9]=0;//unk2
		G_send_packet.length = 10;
	}
	pClient->SendMsg(&G_send_packet);
#ifdef _DEBUG
	LOG.outString ("WORLD: Send SMSG_GMTICKET_GETTICKET");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_LOGOUT_REQUEST(GameClient *pClient)
{
	Character	*cc_char=pClient->mCurrentChar;
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_LOGOUT_REQUEST");
#endif
	//we cannot exit if we are in combat
	if(cc_char->state1 & PLAYER_STATE_IN_COMBAT)
	{
		WORLDSERVER.send_message("You are in combat.Enemy will chew on your bownes.Cannot logout",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,cc_char,NULL);
		return;
	}
	else if(cc_char->state1 & PLAYER_STATE_IN_WATER)
	{
		WORLDSERVER.send_message("You are in water.This ain't a swimming maraton.Cannot logout",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,cc_char,NULL);
		return;
	}
	if(cc_char->data32[UNIT_FIELD_FLAGS] & UNIT_FLAG_MOUNTED)
	{
		//						SystemMessage ("You're mounted, auto-unmounting you. Otherwise you may have problems next time you log in =)");
		//						GetPlayer()->SetUInt32Value(UNIT_FIELD_MOUNTDISPLAYID , 0);
		//						GetPlayer()->RemoveFlag( UNIT_FIELD_FLAGS, 0x002000 );
		//						// Remove the "player locked" flag, to allow movement
		//						if (GetPlayer()->GetUInt32Value(UNIT_FIELD_FLAGS) & UNIT_FLAG_LOCKED )
		//							GetPlayer()->RemoveFlag( UNIT_FIELD_FLAGS, UNIT_FLAG_LOCKED );
		//							// Make sure we're standing ;)
		//					      GetPlayer()->SetStandState (STANDSTATE_STAND);
	}
	//force char to sit. Send data to all block to update player state
	cc_char->set_stand_state(STANDSTATE_SIT);
	//	  				   G_maps[cc_char->map_id]->on_player_entered_block(cc_char,G_turn_id);
	//allow logout
	G_send_packet.opcode = SMSG_LOGOUT_RESPONSE;
	G_send_packet.data32[0] = 0;
	G_send_packet.data[4] = 0;
	G_send_packet.length = 5;
	pClient->SendMsg(&G_send_packet);
	//force player to not be able to nove
	cc_char->set_stand_state(STANDSTATE_SIT);
	G_send_packet.opcode = SMSG_FORCE_MOVE_ROOT;
	G_send_packet.data32[0] = cc_char->getGUIDL();
	G_send_packet.data32[1] = cc_char->getGUIDH();
	G_send_packet.length = 8;
	pClient->SendMsg(&G_send_packet);
	//request this client to logout
	pClient->LogoutRequest(time(NULL));
	//						GetPlayer()->LoseStealth();
	//					WorldSession::HandleCancelTradeOpcode(recv_data);
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_LOGOUT_CANCEL(GameClient *pClient)
{
	Character	*cc_char=pClient->mCurrentChar;
	if(!cc_char)
		return;
	//cancel login on server
	pClient->LogoutRequest(0);
	//inform client that we do not wish to exit anymore
	G_send_packet.opcode = SMSG_LOGOUT_CANCEL_ACK;
	G_send_packet.length = 0;
	pClient->SendMsg(&G_send_packet);
	//unroot player
	cc_char->Send_SMSG_FORCE_MOVE_UNROOT();
	// Stand Up
	cc_char->set_stand_state(STANDSTATE_STAND);
#ifdef _DEBUG
	LOG.outString ("WORLD: Send SMSG_LOGOUT_CANCEL_ACK");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_SET_SELECTION(GameClient *pClient)
{
	uint64		guid=G_recv_packet.data64[0];
	Character	*cc_char=pClient->mCurrentChar;
	if(!cc_char)
		return;
#ifdef _DEBUG
	//!!!!!!!!!!!!! only for debug
	WORLDSERVER.debug_guid = guid; 
	//printf("set selection to pointer %u\n",G_recv_packet.data32[0]);
#endif
	if(cc_char->selected_object_guid != guid)
	{
		//loose action points if we change target
		cc_char->SetUInt64Value(PLAYER__FIELD_COMBO_TARGET,guid);
		cc_char->SetComboPoints(0);
		if(cc_char->state1 & PLAYER_STATE_IN_COMBAT)
		{
			//exit combat
			cc_char->flag_clr(UNIT_FIELD_FLAGS, U_FIELD_FLAG_ATTACK_ANIMATION);
			cc_char->state1 &=~PLAYER_STATE_IN_COMBAT;
		}
		cc_char->selected_object_guid = guid;
		cc_char->target = (Base_Unit_Object*)guid;
	}
	cc_char->last_target_GUID = guid;
	//try to exit combat
	//cc_char->try_force_exit_combat();
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_SET_SELECTION.");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_MESSAGECHAT(GameClient *pClient)
{
	uint32 type;
	uint32 lang;
	type=G_recv_packet.data32[0];
	lang=G_recv_packet.data32[1];
	Character	*cc_char=pClient->mCurrentChar;
	switch(type)
	{
	case CHAT_MSG_SAY:
		{
			//if we have gm rights and first letter is "."
//			printf("gm rigths = %u, first char = %c(%u)\n",pClient->gm_level,G_recv_packet.data[8],G_recv_packet.data[8]);
			if(G_recv_packet.data[8]=='.' && pClient->gm_level>0)
			{
				WORLDSERVER.handle_chat_command(pClient,cc_char);
#ifdef SERVER_DOTA_COMPILATION
				WORLDSERVER.handle_chat_command_dota(pClient,cc_char);
#endif
			}
			else WORLDSERVER.send_message((char*)&G_recv_packet.data[8],SEND_MESSAGE_TO_BLOCK | SEND_MESSAGE_TO_ME,CHAT_MSG_SAY,G_recv_packet.data32[1],NULL,cc_char,NULL);
			//LOG.outString ("WORLD: CHAT: say %s", (char*)&G_recv_packet.data[8]);
		} break;
	case CHAT_MSG_CHANNEL:
		{
			uint32 i;
			char channel[50];
			for(i=8;i<G_recv_packet.length && G_recv_packet.data[i]!=0;i++)
				channel[i-8]=G_recv_packet.data[i];
			channel[i-8]=0; //the terminator
			WORLDSERVER.send_message((char*)&G_recv_packet.data[i+1],SEND_MESSAGE_TO_BLOCK,CHAT_MSG_SAY,lang,NULL,cc_char,NULL);
			//LOG.outString ("WORLD: CHAT: channel %s say %s",channel, (char*)&G_recv_packet.data[i+1]);
		} break;
	case CHAT_MSG_WHISPER: 
		{
			uint32 i;
			char target[50];
			Character *p_char;
			for(i=8;i<G_recv_packet.length && G_recv_packet.data[i]!=0;i++)
				target[i-8]=G_recv_packet.data[i];
			target[i-8]=0; //the terminator
			p_char=NULL;
			p_char=WORLDSERVER.get_character_by_name(target);
			if (!p_char)
			{
				WORLDSERVER.send_message("Online Player not found",SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,cc_char,NULL);
				break;
			}
			if(i+1>=G_recv_packet.length)break;//something is wrong or no msg to be sent
			// Send mssg to us 
			WORLDSERVER.send_message((char*)&G_recv_packet.data[i+1],SEND_MESSAGE_TO_ME,type,lang,NULL,cc_char,NULL);
			// send msg to target
			WORLDSERVER.send_message((char*)&G_recv_packet.data[i+1],SEND_MESSAGE_TO_ME,CHAT_MSG_WHISPER_INFORM,lang,NULL,p_char,NULL);
			//LOG.outString ("WORLD: CHAT: wisper to %s msg %s",target, (char*)&G_recv_packet.data[i+1]);
		} break;
	case CHAT_MSG_YELL:
	case CHAT_MSG_EMOTE:
		{
			WORLDSERVER.send_message((char*)&G_recv_packet.data[8],SEND_MESSAGE_TO_BLOCK | SEND_MESSAGE_TO_ME,type,lang,NULL,cc_char,NULL);
		} break;
	case CHAT_MSG_PARTY:
		{
			if(cc_char->group)  WORLDSERVER.send_message((char*)&G_recv_packet.data[8],SEND_MESSAGE_TO_GROUP,type,lang,NULL,cc_char,NULL);
			else WORLDSERVER.send_message((char*)&G_recv_packet.data[8],SEND_MESSAGE_TO_ME,type,lang,NULL,cc_char,NULL);
		}break;
	default:
		{
			LOG.outString ("WORLD: CHAT: unknown msg type %u, lang: %u", type, lang);
		}break;
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_MESSAGECHAT(type=%u)",type);
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_GAMEOBJ_USE(GameClient *pClient)
{
	//memo last used object(used for gm to delete objects)
	pClient->mCurrentChar->last_used_gameobject_guid=G_recv_packet.data64[0];
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_GAMEOBJ_USE");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_TEXT_EMOTE(GameClient *pClient)
{
	Character	*cc_char=pClient->mCurrentChar;
	//show emote to evrybody
	uint32 text_emote, emoteNum;
	text_emote = G_recv_packet.data32[0];
	emoteNum = G_recv_packet.data32[1];
	if(text_emote>G_max_emote_anim || !G_emote_anim[text_emote])
		return;
	G_send_packet.opcode = SMSG_EMOTE;
	G_send_packet.data32[0] = G_emote_anim[text_emote];
	*(uint64*)&G_send_packet.data32[1] = cc_char->getGUID();
	G_send_packet.length = 12;
	G_maps[cc_char->map_id]->send_instant_msg_to_block(cc_char->pos_x,cc_char->pos_y,&G_send_packet,NULL);

	//if it is a dedicated emote 
/*	if(!cc_char->selected_object_guid)
		return;
	char *name=NULL;
	//check if received guid is for a char or a creture
	if((uint32)(cc_char->selected_object_guid >> 32) & HIGHGUID_PLAYER)
		name = ((Character*)(cc_char->selected_object_guid))->name;
	else if((uint32)(cc_char->selected_object_guid >> 32) & HIGHGUID_UNIT)
		name = ((creature *)(cc_char->selected_object_guid))->name;
	else return;*/
	char *name=NULL;
	if(G_recv_packet.data32[2]!=0)
	{
		if(G_recv_packet.data32[3] & HIGHGUID_PLAYER)
			name = ((Character*)G_recv_packet.data32[2])->name;
		else if (G_recv_packet.data32[3] & HIGHGUID_UNIT)
			name = ((creature*)G_recv_packet.data32[2])->name;
		uint32 namelen= strlen(name)+1;
		G_send_packet.opcode = SMSG_TEXT_EMOTE;
		G_send_packet.data32[0] = cc_char->getGUIDL();
		G_send_packet.data32[1] = cc_char->getGUIDH();
		G_send_packet.data32[2] = text_emote;
		G_send_packet.data32[3] = emoteNum;
		G_send_packet.data32[4] = namelen;
		if(namelen>1)
			memcpy(&G_send_packet.data32[5],name,namelen);
		else G_send_packet.data[20]=0;
		G_send_packet.length = 20 + namelen;
		G_maps[cc_char->map_id]->send_instant_msg_to_block(cc_char->pos_x,cc_char->pos_y,&G_send_packet,NULL);
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_TEXT_EMOTE");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_STANDSTATECHANGE(GameClient *pClient)
{
	Character	*cc_char=pClient->mCurrentChar;
	cc_char->set_stand_state(G_recv_packet.data[0]);
	if(!(G_recv_packet.data[0] & STANDSTATE_SIT))
		cc_char->affect_list->on_game_interrupt(SPELL_AURA_INTERRUPT_FLAGS_TYPE_STANDSTATE_SIT);
	G_send_packet.opcode = SMSG_STANDSTATE_CHANGE_ACK;
	G_send_packet.data[0] = G_recv_packet.data[0];//or maybe what we received ? Have only 1 example for this
	G_send_packet.length = 1;
	pClient->SendMsg(&G_send_packet);
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_STANDSTATECHANGE");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_SET_ACTION_BUTTON(GameClient *pClient)
{
//    uint8 button, misc, type;  uint16 action;
//    recv_data >> button >> action >> misc >> type;
	pClient->mCurrentChar->actionbuttons[G_recv_packet.data[0]] = *(uint32*)&G_recv_packet.data[1];
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_SET_ACTION_BUTTON");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_CAST_SPELL(GameClient *pClient)
{
	Character	*cc_char=pClient->mCurrentChar;
#ifdef _DEBUG
	if(G_recv_packet.data32[0]>G_max_spell_id || G_spell_info[G_recv_packet.data32[0]]==NULL)
	{
		LOG.outString ("Unknown spell_id %u",G_recv_packet.data32[0]);
//		return; //just crash the server:P
	}
#endif
	cc_char->cur_spell.init(G_recv_packet.data32[0],cc_char->pos_x,cc_char->pos_y,cc_char->orientation,cc_char->map_id);
	uint32 cast_error = cc_char->can_cast(G_recv_packet.data32[0]);
	if(cast_error)
	{
		cc_char->cur_spell.msg_spell_can_cast_result(cast_error);
		return;
	}
	//we should prepare data so in the next char update, the spell will start casting
	cc_char->cur_spell.read_targets_from_src(&G_recv_packet.data[4]);
	//if it is a channled spell then we should start channeling it
	if(cc_char->cur_spell.prototype->channel_interrupt_flags!=0)
	{
		cc_char->cur_spell.msg_spell_channel_start();
		cc_char->SetUInt64Value(UNIT_FIELD_CHANNEL_OBJECT,cc_char->cur_spell.target_list[0].data[0]);
		cc_char->SetUInt32Value(UNIT_CHANNEL_SPELL,G_recv_packet.data32[0]);
	}	
	//start casting the spell
	cc_char->cur_spell.msg_spell_start_cast();
	cc_char->state1 &=~PLAYER_STATE_MOVED_SINCE_LAST_UPDATE; //remove "moved" flag
	//printf("t1 = %u, t2 = %u, t3 = %u, t4 = %u \n",cc_char->cur_spell.target_player1,cc_char->cur_spell.target_player2,cc_char->cur_spell.target_creature,cc_char->cur_spell.target_object,cc_char->cur_spell.target_item);
	//set player state to casting
	cc_char->start_cast();
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_CAST_SPELL");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_SETSHEATHED(GameClient *pClient)
{
	pClient->mCurrentChar->sheath_set(G_recv_packet.data32[0]);
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_SETSHEATHED");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_GROUP_INVITE(GameClient *pClient)
{
	//pClient(us) invited another player to join our group
	//he cannot be invited if :
	//- doesn't exist
	//- he is in a group
	//- group is full
	Character	*invited_char;
	Character	*cc_char=pClient->mCurrentChar;
	invited_char=WORLDSERVER.get_character_by_name((char*)G_recv_packet.data);
	if(!invited_char)
	{
		//no such name
		G_send_packet.opcode = SMSG_PARTY_COMMAND_RESULT;
		G_send_packet.data32[0] = 0; //sometimes it's 2 ?
		memcpy(&G_send_packet.data[4],(char*)G_recv_packet.data,strlen((char*)G_recv_packet.data)+1);
		G_send_packet.length = 4 + strlen((char*)G_recv_packet.data)+1;
		*(uint32*)&G_send_packet.data[G_send_packet.length] = GROUP_COMMAND_PLAYER_NOT_FOUND;
		G_send_packet.length +=4;
		pClient->SendMsg(&G_send_packet);
	}
	else if(invited_char->group_invitated_by == cc_char)
	{
		//if we already invited this char
	} 
	else if(cc_char->group && cc_char->group->member_count == MAX_GROUP_SIZE)
	{
		//group is full
		G_send_packet.opcode = SMSG_PARTY_COMMAND_RESULT;
		G_send_packet.data32[0] = 0;
		G_send_packet.data[4] = 0;
		*(uint32*)&G_send_packet.data[5] = GROUP_COMMAND_GROUP_IS_FULL;
		G_send_packet.length +=9;
		pClient->SendMsg(&G_send_packet);
	}
	else if(cc_char->group && cc_char->group->leader!=cc_char)
	{
		//if we are in a group and we are not the groupleader there
		G_send_packet.opcode = SMSG_PARTY_COMMAND_RESULT;
		G_send_packet.data32[0] = 0;
		G_send_packet.data[4] = 0;
		*(uint32*)&G_send_packet.data[5] = GROUP_COMMAND_YOU_MUST_BE_LEADER;
		G_send_packet.length +=9;
		pClient->SendMsg(&G_send_packet);
	}
	else if(invited_char->group)
	{
		//he is already in a group
		G_send_packet.opcode = SMSG_PARTY_COMMAND_RESULT;
		G_send_packet.data32[0] = 0;
		memcpy(&G_send_packet.data[4],(char*)G_recv_packet.data,strlen((char*)G_recv_packet.data)+1);
		G_send_packet.length = 4 + strlen((char*)G_recv_packet.data)+1;
		*(uint32*)&G_send_packet.data32[G_send_packet.length] = GROUP_COMMAND_ALREADY_IN_GROUP;
		G_send_packet.length +=4;
		pClient->SendMsg(&G_send_packet);
	}
	else
	{
		//we can invite character to the group
		G_send_packet.opcode = SMSG_GROUP_INVITE;
		memcpy(&G_send_packet.data[0],cc_char->name,strlen(cc_char->name)+1);
		G_send_packet.length = strlen(cc_char->name)+1;
		invited_char->pClient->SendMsg(&G_send_packet);
		//notice the inviter that the invite has been sent
		G_send_packet.opcode = SMSG_PARTY_COMMAND_RESULT;
		G_send_packet.data32[0] = 0;
		memcpy(&G_send_packet.data[4],(char*)G_recv_packet.data,strlen((char*)G_recv_packet.data)+1);
		G_send_packet.length = 4 + strlen((char*)G_recv_packet.data)+1;
		*(uint32*)&G_send_packet.data32[G_send_packet.length] = GROUP_COMMAND_OK;
		G_send_packet.length +=4;
		pClient->SendMsg(&G_send_packet);
		//set invited player flag to be invited
		invited_char->group_invitated_by = cc_char;
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_GROUP_INVITE");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_GROUP_ACCEPT(GameClient *pClient)
{
	//invited char accepted group invitation
	Character	*cc_char=pClient->mCurrentChar;
	if(cc_char->group_invitated_by)
	{
		//if we are a group leader we dispand the whole group
		if(cc_char->group && cc_char->group->leader == cc_char)
			cc_char->group->disband();
		//if we belong already to a group then we kick ourself from it
		if(cc_char->group)
			cc_char->group->del(cc_char);
		//if the inviter has a null group then we create 1 for him
		if(cc_char->group_invitated_by->group == NULL)
		{
			cc_char->group_invitated_by->group = new Group;
			cc_char->group_invitated_by->group->change_leader(cc_char->group_invitated_by);
			cc_char->group_invitated_by->group->add(cc_char->group_invitated_by);
		}
		//set this char that belongs to that group
		cc_char->group = cc_char->group_invitated_by->group;
		//add this char to his list
		cc_char->group->add(cc_char);
		//set char that he can be invited in other group
		cc_char->group_invitated_by = NULL;
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_GROUP_INVITE");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_GROUP_DECLINE(GameClient *pClient)
{
	Character	*cc_char=pClient->mCurrentChar;
	if(cc_char->group_invitated_by)
	{
		G_send_packet.opcode = SMSG_GROUP_DECLINE;
		memcpy(&G_send_packet.data[0],cc_char->name,strlen(cc_char->name)+1);
		G_send_packet.length = strlen(cc_char->name)+1;
		cc_char->group_invitated_by->pClient->SendMsg(&G_send_packet);
		cc_char->group_invitated_by = NULL;
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_GROUP_DECLINE");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_GROUP_UNINVITE(GameClient *pClient)
{
	Character *uninvited_char;
	Character	*cc_char=pClient->mCurrentChar;
	uninvited_char=WORLDSERVER.get_character_by_name((char*)G_recv_packet.data);
	if(!uninvited_char)
	{
		//if we wanna kick somebody who is not online
		G_send_packet.opcode = SMSG_PARTY_COMMAND_RESULT;
		G_send_packet.data32[0] = 0;
		memcpy(&G_send_packet.data[4],(char*)G_recv_packet.data,strlen((char*)G_recv_packet.data)+1);
		G_send_packet.length = 4 + strlen((char*)G_recv_packet.data)+1;
		*(uint32*)&G_send_packet.data32[G_send_packet.length] = 0x00000001;
		G_send_packet.length +=4;
		pClient->SendMsg(&G_send_packet);
	}
	else if(uninvited_char->group!=cc_char->group)
	{
		//cannot kick him if he is not in our group
		G_send_packet.opcode = SMSG_PARTY_COMMAND_RESULT;
		G_send_packet.data32[0] = 0;
		G_send_packet.data[4] = 0;
		*(uint32*)&G_send_packet.data[5] = 0x00000006;
		G_send_packet.length = 9;
		pClient->SendMsg(&G_send_packet);
	}
	if(!(cc_char->group))
	{
		//if we are not in a group
	}
	else if(cc_char->group->leader!=cc_char)
	{
		//we cannot kick somebody if we are not the leader
		G_send_packet.opcode = SMSG_PARTY_COMMAND_RESULT;
		G_send_packet.data32[0] = 0;
		memcpy(&G_send_packet.data[4],(char*)G_recv_packet.data,strlen((char*)G_recv_packet.data)+1);
		G_send_packet.length = 4 + strlen((char*)G_recv_packet.data)+1;
		*(uint32*)&G_send_packet.data32[G_send_packet.length] = 0x00000002;
		G_send_packet.length +=4;
		pClient->SendMsg(&G_send_packet);
	}
	else
	{
		//if he was the last one then we destroy the group
		if(cc_char->group->member_count==2)
			cc_char->group->disband();
		//kick him
		else cc_char->group->del(uninvited_char);
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_GROUP_UNINVITE");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_GROUP_SET_LEADER(GameClient *pClient)
{
	Character	*new_leader;
	Character	*cc_char=pClient->mCurrentChar;
//	new_leader=WORLDSERVER.get_character_by_name((char*)G_recv_packet.data);
	new_leader=(Character *)G_recv_packet.data32[0];
	if(!new_leader)
	{
		//he is not online
		G_send_packet.opcode = SMSG_PARTY_COMMAND_RESULT;
		G_send_packet.data32[0] = 0;
		memcpy(&G_send_packet.data[4],(char*)G_recv_packet.data,strlen((char*)G_recv_packet.data)+1);
		G_send_packet.length = 4 + strlen((char*)G_recv_packet.data)+1;
		*(uint32*)&G_send_packet.data32[G_send_packet.length] = GROUP_COMMAND_PLAYER_NOT_FOUND;
		G_send_packet.length +=4;
		pClient->SendMsg(&G_send_packet);
	}
	else if(!cc_char->group)
	{
		//we do not have a group
	}
	else if(cc_char->group->leader!=cc_char)
	{
		//we are not the leader to be able to promote him
	}
	else if(!cc_char->group->find(new_leader))
	{
		//he does not belong to our group
	}
	else cc_char->group->change_leader(new_leader);
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_GROUP_SET_LEADER");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_GROUP_DISBAND(GameClient *pClient)
{
	Character	*cc_char=pClient->mCurrentChar;
	if(!cc_char->group)
	{
		//not in a group
	}
	//not only leaders can dispband group. If he is the last one the client will send disband instead of kick
	else
	{
		Character *leader=cc_char->group->leader;
		leader->group->disband();
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_GROUP_DISBAND");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_LOOT_METHOD(GameClient *pClient)
{
	Character	*cc_char=pClient->mCurrentChar;
	if(cc_char->group)
	{
		//0 - loot_mode
		//1 - lootmaster
		//2 - 0 as guidhigh ?
		//3 - loot_treshold
		cc_char->group->loot_mode = (uint8)G_recv_packet.data32[0];
		cc_char->group->loot_master = (Character *)G_recv_packet.data32[1];
		cc_char->group->loot_treshold = (uint8)G_recv_packet.data32[3];
		cc_char->group->update_group();
	}
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_LOOT_METHOD");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_ATTACKSWING(GameClient *pClient)
{
	pClient->mCurrentChar->try_force_enter_combat(G_recv_packet.data64[0]);
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_ATTACKSWING");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_ATTACKSTOP(GameClient *pClient)
{
	pClient->mCurrentChar->try_force_exit_combat();
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_ATTACKSTOP");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_REPOP_REQUEST(GameClient *pClient)
{
	//we receive 1 byte but i have no idea what it is
	pClient->mCurrentChar->on_char_corpse();
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_REPOP_REQUEST");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_REQUEST_PARTY_MEMBER_STATS(GameClient *pClient)
{
	//!!! be carefull because we might get packets fro this even if char is not online!!!
	Character	*target_char=(Character	*)G_recv_packet.data32[0];
	G_send_packet.opcode = SMSG_PARTY_MEMBER_STATS;
	G_send_packet.data[0] = 0xFF;
	*(uint32*)(G_send_packet.data+1) = G_recv_packet.data32[0];
	*(uint32*)(G_send_packet.data+5) = G_recv_packet.data32[1];
	*(uint32*)(G_send_packet.data+9) = 0;
	G_send_packet.data[13] = 1;
	G_send_packet.length = 14;
	pClient->SendMsg(&G_send_packet);
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_REQUEST_PARTY_MEMBER_STATS");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_DUEL_ACCEPTED(GameClient *pClient)
{
	Character	*cc_char=pClient->mCurrentChar;
	//only duel target can accept duel
	//we receive the full guid of the duel arbiter
	if(!cc_char->duel_info.dual_arbiter 
		|| (cc_char->state1 & PLAYER_STATE_IN_DUEL)
		|| cc_char->duel_info.initiator==cc_char
		)
		return; //it seems that we received this packet at a wrong time
#define DUEL_PREPARATION_TIMER_VALUE	3000 //given in ms
	//if the other guy accepted it then we are ready to go
	G_send_packet.opcode = SMSG_DUEL_COUNTDOWN;
	G_send_packet.data32[0] = DUEL_PREPARATION_TIMER_VALUE;
	G_send_packet.length = 4;
	cc_char->SendMsg(&G_send_packet);
	cc_char->duel_info.target->SendMsg(&G_send_packet);

	cc_char->duel_info.atimer1 = G_cur_time_ms+DUEL_PREPARATION_TIMER_VALUE;
	cc_char->duel_info.target->duel_info.atimer1 = G_cur_time_ms+DUEL_PREPARATION_TIMER_VALUE;

	cc_char->state1 |= PLAYER_STATE_DUEL_PREPARE;
	cc_char->duel_info.target->state1 |= PLAYER_STATE_DUEL_PREPARE;

#undef DUEL_PREPARATION_TIMER_VALUE
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_DUEL_ACCEPTED");
#endif
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void handle_CMSG_DUEL_CANCELLED(GameClient *pClient)
{
	//destroy the arbiter
	Character	*cc_char=pClient->mCurrentChar;
	cc_char->finish_duel(0);
	cc_char->duel_info.target->finish_duel(0);
#ifdef _DEBUG
	LOG.outString ("WORLD: handle CMSG_DUEL_CANCELLED");
#endif
}
