// Copyright (C) 2006 Team Evolution
#include "group.h"

Group::Group()
{
	first = NULL;
	looter = NULL;
	leader = NULL;
	loot_master = NULL;
	member_count = 0;
	loot_mode = 0;
	loot_treshold = 2;
}

Group::~Group()
{
	Group_Node *kur=first,*prev;
	while(kur)
	{
		prev=kur;
		kur=kur->next;
		delete prev;
	}
}
void Group::add(Character *p_char)
{
	//check to see if already in list, if so then we exit
	if(find(p_char))return;
	//create a new node and add it to the list
	Group_Node *new_node;
	new_node = new Group_Node;
	new_node->p_char = p_char;
	new_node->next = first;
	if(first)first->prev = new_node;
	first = new_node;
	member_count++;
	if(member_count>1)update_group();
}

void Group::del(Character *p_char)
{
	Group_Node *p_node;
	p_node = find(p_char);
	if(!p_node)return;
	if(leader==p_char || member_count==2)
	{
		disband();
		return;
	}
	//tell the client we kicked him
	G_send_packet.opcode = SMSG_GROUP_UNINVITE;
	G_send_packet.length = 0;
	p_char->pClient->SendMsg(&G_send_packet);
	if(p_node->prev)p_node->prev->next = p_node->next;
	if(p_node->next)p_node->next->prev = p_node->prev;
	delete p_node;
	if(p_node == first)first = NULL;
	p_char->group = NULL;
	member_count--;
	update_group();
}

void Group::update_group()
{
	//we have to update the list evry time the group changes
	Group_Node *kur=first,*kur2;
	uint32 datalen;
	while(kur)
	{
		G_send_packet.opcode = SMSG_GROUP_LIST;
		G_send_packet.data[0] = 0; //grouptype
		G_send_packet.data[1] = 0; //myflags
		G_send_packet.data[2] = 0; //unk
		*(uint32*)(G_send_packet.data+3) = member_count-1;//self not included
		kur2=first;
		datalen=7;
		while(kur2)
		{
			if(kur2->p_char!=kur->p_char)
			{
				memcpy(&G_send_packet.data[datalen],kur2->p_char->name,strlen(kur2->p_char->name)+1);
				datalen += strlen(kur2->p_char->name)+1;
				*(uint32*)&G_send_packet.data[datalen] = kur2->p_char->getGUIDL();
				datalen+=4;
				*(uint32*)&G_send_packet.data[datalen] = kur2->p_char->getGUIDH(); 
				datalen+=4;
				G_send_packet.data[datalen++] = 1;//still online(available) always since we remove player as soon as he goes offline
				if(leader==kur2->p_char)
					G_send_packet.data[datalen++] = 0x80;//leader
				else G_send_packet.data[datalen++] = 0;//asistant
			}
			kur2 = kur2->next;
		}
		*(uint32*)&G_send_packet.data[datalen] = leader->getGUIDL();
		datalen +=4;
		*(uint32*)&G_send_packet.data[datalen] = leader->getGUIDH();
		datalen +=4;
		G_send_packet.data[datalen++] = loot_mode;
		if(loot_master)
		{
			*(uint32*)&G_send_packet.data[datalen] = loot_master->getGUIDL();
			datalen +=4;
			*(uint32*)&G_send_packet.data[datalen] = loot_master->getGUIDH();
			datalen +=4;
		}
		else
		{
			*(uint32*)&G_send_packet.data[datalen] = 0;
			datalen +=4;
			*(uint32*)&G_send_packet.data[datalen] = 0;
			datalen +=4;
		}
		G_send_packet.data[datalen++] = loot_treshold;
		*(uint32*)(G_send_packet.data+datalen) = 0;
		*(uint32*)(G_send_packet.data+datalen+4) = 0;
		*(uint32*)(G_send_packet.data+datalen+8) = 0;
		*(uint32*)(G_send_packet.data+datalen+12) = 0;
		G_send_packet.length = datalen+16;
		kur->p_char->pClient->SendMsg(&G_send_packet);
		kur = kur->next;
	}
}

void Group::disband()
{
	//we kick evrybody out of the group
	Group_Node *kur=first;
	G_send_packet.opcode = SMSG_GROUP_DESTROYED;
	G_send_packet.length =0;
	leader->flag_clr(PLAYER_FLAGS,PLAYER_FLAG_GROUP_LEADER);
	while(kur)
	{
		kur->p_char->pClient->SendMsg(&G_send_packet);
		kur = kur->next;
	}
	//tell them that they were kicked out. They just don't wanna leave when they heard group got destroyed
	kur=first;
	G_send_packet.opcode = SMSG_GROUP_UNINVITE;
	G_send_packet.length =0;
	while(kur)
	{
		kur->p_char->pClient->SendMsg(&G_send_packet);
		kur->p_char->group = NULL;
		kur = kur->next;
	}
	delete this;
}

void Group::change_leader(Character *new_leader)
{
	Group_Node *kur=first;
	//when we created group the leader is not set yet
	if(leader)
	{
		leader->flag_clr(PLAYER_FLAGS,PLAYER_FLAG_GROUP_LEADER);
		G_send_packet.opcode = SMSG_GROUP_SET_LEADER;
		memcpy(&G_send_packet.data[0],new_leader->name,strlen(new_leader->name)+1);
		G_send_packet.length = strlen(new_leader->name)+1;
		while(kur)
		{
			//del(kur->prev->p_char);
			kur->p_char->pClient->SendMsg(&G_send_packet);
			kur = kur->next;
		}
	}
	leader = new_leader;
	leader->flag_set(PLAYER_FLAGS,PLAYER_FLAG_GROUP_LEADER);
	update_group();
}
