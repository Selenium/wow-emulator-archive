// Copyright (C) 2006 Team Evolution
#include "corpse.h"

corpse::corpse(Character *powner)
{
	int i;
	owner = powner;
	data32 = (uint32 *)malloc(CORPSE_END*4);
    ASSERT(data32);
    memset(data32,0,CORPSE_END*4);
	dataf = (float *)data32;
	data32[OBJECT_FIELD_GUID] = (uint32)this;
	data32[OBJECT_FIELD_GUID+1] = HIGHGUID_CORPSE;
	uint32 unitbytes = powner->data32[UNIT_FIELD_BYTES_0];
	uint32 playerbytes1 = powner->data32[PLAYER_BYTES];
	uint32 playerbytes2 = powner->data32[PLAYER_BYTES_2];
    uint8 race       = (uint8)(unitbytes);
    uint8 skin       = (uint8)(playerbytes1);
    uint8 face       = (uint8)(playerbytes1 >> 8);
    uint8 hairstyle  = (uint8)(playerbytes1 >> 16);
    uint8 haircolor  = (uint8)(playerbytes1 >> 24);
    uint8 facialhair = (uint8)(playerbytes2);
	data32[OBJECT_FIELD_TYPE] = OBJECT_TYPE_CORPSE;
	data32[OBJECT_FIELD_ENTRY] = owner->data32[UNIT_FIELD_BYTES_0]; //this contains race,gender..
	data32[OBJECT_FIELD_SCALE_X] = powner->data32[OBJECT_FIELD_SCALE_X];
	data32[OBJECT_FIELD_PADDING] = 0;
	*(uint64*)&data32[CORPSE_FIELD_OWNER] = powner->getGUID();
	dataf[CORPSE_FIELD_FACING] = powner->corpse_o;
	dataf[CORPSE_FIELD_POS_X] = powner->corpse_x;
	dataf[CORPSE_FIELD_POS_Y] = powner->corpse_y;
	dataf[CORPSE_FIELD_POS_Z] = powner->corpse_z;
	data32[CORPSE_FIELD_DISPLAY_ID] = powner->data32[UNIT_FIELD_DISPLAYID];
	uint32 ind=0;
	for ( i = PLAYER_FIELD_INV_SLOT_HEAD+0; i < PLAYER_FIELD_INV_SLOT_HEAD + 20*2; i +=2)
	{
	   if(powner->data32[i]!=0)
	   {
		   uint32 dipl_id = ((Item*)powner->data32[i])->item_data32[ITEM_DISPLAY_INFO_ID];
		   uint32 inv_type = ((Item*)powner->data32[i])->item_data32[ITEM_INVENTORY_TYPE];
		   data32[CORPSE_FIELD_ITEM+ind] = (inv_type << 24) | (uint16)dipl_id;
	   }
	   ind++;
	}
	data32[CORPSE_FIELD_BYTES_1] = ((0x00) | (race << 8) | (0x00 << 16) | (skin << 24));
	data32[CORPSE_FIELD_BYTES_2] = ((face) | (hairstyle << 8) | (haircolor << 16) | (facialhair << 24));
	data32[CORPSE_FIELD_GUILD] = powner->data32[PLAYER_GUILDID];
	data32[CORPSE_FIELD_FLAGS] = 4;
	data32[CORPSE_FIELD_DYNAMIC_FLAGS] = 0;
	data32[CORPSE_FIELD_PAD] = 0;
	map_id = powner->map_id;
	pos_x = powner->corpse_x;
	pos_y = powner->corpse_y;
	pos_z = powner->corpse_z;
	orientation = powner->corpse_o;
	packet_cache = NULL;
	packet_cache_len = 0;
	//add the corpse to the map
	G_maps[map_id]->add_corpse(this);
	//create the corpse for the block
	G_maps[map_id]->send_instant_msg_to_block(pos_x,pos_y,G_temp_compressed_packet.build_packet(),NULL);
	//note that while we are dead, our position in mapmanager is not updated so it's enough to create only once the corpse for us
	G_temp_compressed_packet.clear();
	build_create_block(&G_temp_compressed_packet,1,0);
	owner->pClient->SendMsg(G_temp_compressed_packet.build_packet());
	//now create a createpacket for others and send it to the block
	G_temp_compressed_packet.clear();
	build_create_block(&G_temp_compressed_packet,0,0);
	G_maps[map_id]->send_instant_msg_to_block(pos_x,pos_y,G_temp_compressed_packet.build_packet(),powner);
}

corpse::~corpse()
{
	//remove ourself from world
	G_maps[map_id]->del_corpse(this);
	//send destroy packet to block
	G_send_packet.opcode = SMSG_DESTROY_OBJECT;
	G_send_packet.data32[0] = data32[OBJECT_FIELD_GUID];
	G_send_packet.data32[1] = data32[OBJECT_FIELD_GUID+1];
	G_send_packet.length = 8;
	//it is sent to everybody inclusive us
	G_maps[map_id]->send_instant_msg_to_block(pos_x,pos_y,&G_send_packet,NULL);
	free(packet_cache);
	packet_cache = NULL;
}

void corpse::build_create_block(Compressed_Update_Block *packet,uint32 target_self,uint32 turn_id)
{
	if(packet_cache)
	{
      memcpy(packet->get_next_pointer(),packet_cache,packet_cache_len);
      packet->add_virtual_packet(packet_cache_len);
      return;
	}
	//create packet cache
	uint32	*packet32;
	uint8	*buffer8;
	float	*packetf;
	UpdateMask	update_mask;
    update_mask.SetCount(CORPSE_END);
    update_mask.Clear();
	buffer8=packet->get_next_pointer();
//   for ( i = CORPSE_FIELD_ITEM+0; i < CORPSE_FIELD_ITEM + EQUIPMENT_SLOT_END; i ++)
//	   if(data32[i]!=0) ((Item*)data32[i])->build_create_block(packet,0,turn_id);
    buffer8[0]=UPDATETYPE_CREATE_OBJECT; //type of the block
    buffer8[0]=UPDATETYPE_CREATE_OBJECT; //type of the block
    buffer8[1]=0xFF; //type of the block
	*(uint64*)(&buffer8[2])=*(uint64*)data32;
	buffer8[10]=TYPEID_CORPSE; 
	buffer8[11]=0x50; //flags1
	packetf=(float*)&buffer8[12];
	packet32=(uint32*)&buffer8[12];
    packetf[0]=dataf[CORPSE_FIELD_POS_X]; 
    packetf[1]=dataf[CORPSE_FIELD_POS_Y]; 
    packetf[2]=dataf[CORPSE_FIELD_POS_Z]; 
    packetf[3]=dataf[CORPSE_FIELD_FACING]; 
	packet32[4]=target_self; 
    //set bits and add values to packet
    buffer8[32]=(uint8)update_mask.GetBlockCount();
    uint32 len,pos;
    len = 33 + update_mask.GetBlockCount()*4;
    packet32 = (uint32*)&buffer8[len];
    pos = 0;
    for(int i=0; i<CORPSE_END; i++)
    if(data32[i]!=0)
	{
		update_mask.SetBit(i);
		packet32[pos++] = data32[i];
	}
    //add bitmask to packet
    memcpy(&buffer8[33],update_mask.GetMask(),update_mask.GetBlockCount()*4);
	packet->add_virtual_packet(len+pos*4);
	if(!target_self)
	{
		packet_cache_len = len+pos*4;
		packet_cache = (uint32*)malloc(packet_cache_len);
		memcpy(packet_cache,buffer8,packet_cache_len);
	}
}

