// Copyright (C) 2006 Team Evolution
#include "WorldServer.h"

//send a message
void WorldServer::send_message(char *message,uint8 send_type,uint8 msg_type,uint32 lang,uint32 channel_id,Character *sender,Character *target)
{
	uint32 msg_len = (message ? (strlen(message)) : 0)+1;
	G_send_packet.opcode = SMSG_MESSAGECHAT;
	G_send_packet.data[0] = msg_type;
	*(uint32*)(&G_send_packet.data[1]) = lang;
	ClientSet::iterator itr;
	switch (msg_type) 
	{
      case CHAT_MSG_SYSTEM: 
		  {
			*(uint64*)(&G_send_packet.data[5]) = 0;
			G_send_packet.length = 13;
			break; 
		  }
      case CHAT_MSG_CHANNEL: 
		  {

/*         *data << channelName;
         senderGuid = session ? session->GetPlayer()->GetGUID() : 0;
         *data << senderGuid;*/
//      data.Initialize(SMSG_MESSAGECHAT);
//      data << (uint8)14; // CHAT_MESSAGE_CHANNEL
//      data << (uint32)0; // Universal lang
//      data << name.c_str();
//      data << (uint32)0;    
//      data << p->GetGUID();
//      data << messageLength;
//      data << what;
//      data << (uint8)0;
			break; 
		  }
      case CHAT_MSG_YELL:
      case CHAT_MSG_PARTY:
      case CHAT_MSG_SAY: 
		  {
			*(uint64*)(&G_send_packet.data[5]) = sender->getGUID();
			*(uint64*)(&G_send_packet.data[13]) = sender->getGUID();
			G_send_packet.length = 21;
			break; 
		  }
      case CHAT_MSG_WHISPER:
      case CHAT_MSG_WHISPER_INFORM: 
		{
			*(uint64*)(&G_send_packet.data[5]) = sender->getGUID();
			if(target)*(uint64*)(&G_send_packet.data[13]) = target->getGUID();
			else *(uint64*)(&G_send_packet.data[13]) = sender->getGUID();
			G_send_packet.length = 21;
			break;
		}
      case CHAT_MSG_EMOTE: 
		{
//printf("got an emote here\n");
			*(uint64*)(&G_send_packet.data[5]) = sender->getGUID();
			G_send_packet.length = 13;
			break; 
		}
      case CHAT_MSG_AFK: 
		{
			sender->flag_set(PLAYER_FLAGS,PLAYER_FLAG_AFK);
			sender->afk = 1 - sender->afk;
			G_send_packet.length = 5;
			break; 
		}
	  default:
		{
			G_send_packet.length = 5;
			break; 
		}
	}
	*(uint32*)(&G_send_packet.data[G_send_packet.length]) = msg_len;
	G_send_packet.length+=4;
	memcpy(&G_send_packet.data[G_send_packet.length],message,msg_len);
	G_send_packet.length+=msg_len;
	*(uint8*)(&G_send_packet.data[G_send_packet.length++]) = sender->afk;
	//finaly let's send the message
	if(send_type == SEND_MESSAGE_TO_EVRYBODY)
	{
		for (itr = mClients.begin(); itr != mClients.end(); itr++)
			if(((GameClient*)(*itr))->IsInWorld())
				((GameClient*)(*itr))->SendMsg(&G_send_packet);
	}
	else if(send_type == SEND_MESSAGE_TO_ME)
		sender->pClient->SendMsg(&G_send_packet);
	else if(send_type == SEND_MESSAGE_TO_BLOCK)
		G_maps[sender->map_id]->send_instant_msg_to_block(sender->pos_x,sender->pos_y,&G_send_packet,sender);
	else if(send_type == (SEND_MESSAGE_TO_BLOCK | SEND_MESSAGE_TO_ME))
		G_maps[sender->map_id]->send_instant_msg_to_block(sender->pos_x,sender->pos_y,&G_send_packet,NULL);
	else if(send_type == SEND_MESSAGE_TO_DEAD)
	{
		for (itr = mClients.begin(); itr != mClients.end(); itr++)
			if(((GameClient*)(*itr))->IsInWorld() && (((GameClient*)(*itr))->mCurrentChar->state1 & PLAYER_STATE_DEAD))
				((GameClient*)(*itr))->SendMsg(&G_send_packet);
	}
	else if(send_type == SEND_MESSAGE_TO_ALLIVE)
	{
		for (itr = mClients.begin(); itr != mClients.end(); itr++)
			if(((GameClient*)(*itr))->IsInWorld() && !(((GameClient*)(*itr))->mCurrentChar->state1 & PLAYER_STATE_DEAD))
				((GameClient*)(*itr))->SendMsg(&G_send_packet);
	}
	else if(send_type == SEND_MESSAGE_TO_OTHERS)
	{
		for (itr = mClients.begin(); itr != mClients.end(); itr++)
			if(((GameClient*)(*itr))->IsInWorld() && (((GameClient*)(*itr))->mCurrentChar!=sender))
				((GameClient*)(*itr))->SendMsg(&G_send_packet);
	}
	else if(send_type == SEND_MESSAGE_TO_GROUP)
	{
		Group_Node *group_iter;
		group_iter = ((Character*)sender)->group->first;
		while(group_iter)
		{
			group_iter->p_char->pClient->SendMsg(&G_send_packet);
			group_iter = group_iter->next;
		}
	}	
}

void WorldServer::send_message(uint8 send_type,cr_yell_node *yell_node,creature *sender,Character *target)
{
	uint32 msg_len = strlen(yell_node->text)+1;
	G_send_packet.opcode = SMSG_MESSAGECHAT;
	G_send_packet.data[0] = yell_node->type;
	*(uint32*)(&G_send_packet.data[1]) = yell_node->lang;
	ClientSet::iterator itr;
	switch (yell_node->type) 
	{
	  case CHAT_MSG_MONSTER_EMOTE: //maybe this is not emote at all
		{
			G_send_packet.length = 5;
			break; 
		}
	  default:
	  case CHAT_MSG_MONSTER_SAY:
	  case CHAT_MSG_MONSTER_YELL:
		{
			*(uint64*)(&G_send_packet.data[5]) = sender->getGUID();
			G_send_packet.length = 13;
			break; 
		}
	}
	uint32 name_len=strlen(sender->name)+1;
	*(uint32*)(&G_send_packet.data[G_send_packet.length]) = name_len;
	G_send_packet.length+=4;
	memcpy(&G_send_packet.data[G_send_packet.length],sender->name,name_len);
	G_send_packet.length+=name_len;
	*(uint32*)(&G_send_packet.data[G_send_packet.length]) = target->getGUIDL();
	G_send_packet.length+=4;
	*(uint32*)(&G_send_packet.data[G_send_packet.length]) = target->getGUIDH();
	G_send_packet.length+=4;
	*(uint32*)(&G_send_packet.data[G_send_packet.length]) = msg_len;
	G_send_packet.length+=4;
	memcpy(&G_send_packet.data[G_send_packet.length],yell_node->text,msg_len);
	G_send_packet.length+=msg_len;
	*(uint8*)(&G_send_packet.data[G_send_packet.length++]) = 0; //afk ?
	//finaly let's send the message
	if(send_type == SEND_MESSAGE_TO_TARGET)
		target->SendMsg(&G_send_packet);
	else if(send_type == SEND_MESSAGE_TO_BLOCK)
		G_maps[sender->map_id]->send_instant_msg_to_block(sender->pos_x,sender->pos_y,&G_send_packet,(Character*)sender);
	else if(send_type == SEND_MESSAGE_TO_GROUP && sender->folowed_char)
	{
		Group_Node *group_iter;
		group_iter = sender->folowed_char->group->first;
		while(group_iter)
		{
			group_iter->p_char->pClient->SendMsg(&G_send_packet);
			group_iter = group_iter->next;
		}
	}	
}
//we wake only to read events
//we initilised socket buffer so read/write operations should be macro operations
//this is teoreticaly very wrong. We risk it anyway :)
void WorldServer::client_sockevent(nlink *cptr, unsigned short revents)
{	
#ifdef _DEBUG
	if(revents==PF_WRITE)
		printf("write event has occured ?????????????????\n");
	if(revents==PF_EXCEPT)
		printf("exception event has occured ?????????????????\n");
#endif
////////////////////////////////////////// get the packet /////////////////////////////////
	GameClient *pClient = static_cast < GameClient * > (cptr->pClient);
	Socket *net = pClient->getNetwork();
	while(1)
	{
		int read_len;
		if (!net->isConnected())
		{
			disconnect_client(cptr);
			return;
		}
		//read data from socket for this client
			//read header
		read_len = net->fillRecvQ(G_recv_packet.buffer,6);
		if(read_len<=0)
			return; //no more data to read
		pClient->decode(G_recv_packet.buffer);	// let's decrypt it
		G_recv_packet.length = ((uint32)(G_recv_packet.buffer[0])<<8)+G_recv_packet.buffer[1] - 4;
		G_recv_packet.opcode = *(uint32*)&G_recv_packet.buffer[2];
			//read body
		if(G_recv_packet.length!=0) 
			read_len = net->fillRecvQ(G_recv_packet.data,G_recv_packet.length);
#ifdef _DEBUG
		if(read_len!=G_recv_packet.length && G_recv_packet.length!=0)
			printf("!!!!!!!OMG didn't read the whole packet.This is very bad \n");
#endif
	/////////////////////////////////// log the packet //////////////////////////////////////////
		// World Logger
#ifdef _DEBUG
		if (NETWORK.GetWorldLogging ())
		{
			FILE *pFile;
			pFile = fopen("worldlog.txt", "a");
			fprintf(pFile, "CLIENT:\nSOCKET: %d\nLENGTH: %d\nOPCODE: %.4X = %s\nDATA:\n", ((GameClient *)(cptr->pClient))->getNetwork ()->GetHandle (), G_recv_packet.length+4, G_recv_packet.opcode,LookupName(G_recv_packet.opcode, g_worldOpcodeNames));
			DebugDump (pFile, G_recv_packet.data, G_recv_packet.length);
			fprintf(pFile, "\n\n");
			fclose(pFile);
		}
#endif
	////////////////////////////////// treat the packet ///////////////////////////////////////
		if(G_recv_packet.opcode<G_max_handled_opcode) G_packet_handlers[G_recv_packet.opcode](pClient);
		else unhandled_opcode(pClient);
	}//end while
}//end function
