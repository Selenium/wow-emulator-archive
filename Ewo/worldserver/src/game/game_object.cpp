// Copyright (C) 2006 Team Evolution
#include "game_object.h"

gameobject::gameobject()
{
	data32 = (uint32 *)malloc(GAMEOBJECT_END*4);
    ASSERT(data32);
    memset(data32,0,GAMEOBJECT_END*4);
	data32[OBJECT_FIELD_TYPE] = OBJECT_TYPE_GO;
	data32[GAMEOBJECT_TYPE_ID] = TYPEID_GAMEOBJECT;
    update_mask.SetCount(GAMEOBJECT_END);
    update_mask.Clear();
	data32[OBJECT_FIELD_GUID]=(uint32)(this); //id is set when making an instnace
	data32[OBJECT_FIELD_GUID+1]=HIGHGUID_GAMEOBJECT; //
	respawn_delay=GO_RESPAWN_DELAY;
	strcpy(name,"");
	db_id = 0;
/*
   //SetUInt32Value (OBJECT_FIELD_PADDING, 0xEEEEEEEE);
   SetFloatValue (GAMEOBJECT_POS_X, x);
   SetFloatValue (GAMEOBJECT_POS_Y, y );
   SetFloatValue (GAMEOBJECT_POS_Z, z );
   SetFloatValue (GAMEOBJECT_FACING, ang);
   
   SetUInt32Value (GAMEOBJECT_ROTATION, 0);
   SetUInt32Value (GAMEOBJECT_ROTATION+1, 0);
   SetUInt32Value (GAMEOBJECT_ROTATION+2, 0);
   SetUInt32Value (GAMEOBJECT_ROTATION+3, 0);
*/
}

gameobject::~gameobject()
{
   free(data32);
   data32 = NULL;
}

void gameobject_instance::init_from_template(gameobject *gotemplate)
{
	prototype = gotemplate;
}

gameobject_instance::gameobject_instance()
{
	prototype = NULL;
	state1 = GAMEOBJECT_WAITING;
	pos_x = (float)-8931.65; //dump uninitilised cretures in a place where we can see them
	pos_y = (float)-114.644;
	pos_z = (float)82.4876;
	orientation = 1;
	atimter1_ms_limit = 0;
	db_id = 0;
	map_id = 0;
	respawn_delay = 15000;
}

gameobject_instance::~gameobject_instance()
{
}

void gameobject_instance::spawn()
{
	//we have to generate loot items for it
	respawn();
#ifdef USE_OBJECT_INTERRUPTS
	//add actions here when spawning, like waypoints and items
	On_GO_spawn(this);
#endif
}

void gameobject_instance::respawn()
{
	//add actions here when spawning, like position and state
	G_temp_compressed_packet.clear();
	build_create_block(&G_temp_compressed_packet,0);
//	printf("sending createpacket to map %d %f %f \n",map_id,pos_x,pos_y);
	G_maps[map_id]->send_instant_msg_to_block(pos_x,pos_y,G_temp_compressed_packet.build_packet(),NULL);
#ifdef USE_OBJECT_INTERRUPTS
	On_GO_respawn(this);
#endif
}

 //play despawn animation by desgtroying object
void gameobject_instance::despawn()
{
	G_send_packet.opcode = SMSG_DESTROY_OBJECT;
    G_send_packet.data32[0] = getGUIDL();
    G_send_packet.data32[1] = getGUIDH();
    G_send_packet.length = 8;
    G_maps[map_id]->send_instant_msg_to_block(pos_x,pos_y,&G_send_packet,NULL);
}

void gameobject_instance::build_create_block(Compressed_Update_Block *packet,uint32 target_self)
{
	uint8 *data=packet->get_next_pointer();
	float *packetf;
	uint32 *packet32;
	uint32 i;
	prototype->data32[0]= (uint32)this;
    data[0]=UPDATETYPE_CREATE_OBJECT; //type of the block
    data[1]=0xFF; //guid mask
	*(uint32*)(data+2)=getGUIDL();
	*(uint32*)(data+6)=getGUIDH();
	data[10]=TYPEID_GAMEOBJECT; 
	data[11]=0x50; //flags1
	packetf=(float*)&data[12];
	packet32=(uint32*)&data[12];
	packetf[0]=pos_x; 
	packetf[1]=pos_y; 
	packetf[2]=pos_z; 
	packetf[3]=orientation; 
	packet32[4]=0; //1 = active player, 0 else
	G_gameobject_create_mask.Clear();
	//set bits and add values to packet
	data[32]=(uint8)G_gameobject_create_mask.GetBlockCount();
	uint32 len,pos;
	len = 33 + G_gameobject_create_mask.GetBlockCount()*4;
	packet32 = (uint32*)&data[len];
	pos = 0;
	for( i=0; i<GAMEOBJECT_END; i++)
	if(prototype->data32[i]!=0)
	{
		G_gameobject_create_mask.SetBit(i);
		packet32[pos++] = prototype->data32[i];
	}
	//add bitmask to packet
	memcpy(&data[33],G_gameobject_create_mask.GetMask(),G_gameobject_create_mask.GetBlockCount()*4);
	packet->add_virtual_packet(len+pos*4);
}

void gameobject_instance::build_update_block(Compressed_Update_Block *packet,uint32 target_self,uint8 clear_mask)
{
/*	uint8 *data=packet->get_next_pointer();
	uint32 *packet32;
	uint32 i;
	data[0]=UPDATETYPE_VALUES; //type of the block
	*(uint32*)(&data[1])=prototype->data32[0];			//the guid
	prototype->data32[1]= (uint32)this;							//the guid
	*(uint32*)(&data[5])=data32[OBJECT_FIELD_GUID];					//the guid
	//set bits and add values to packet
	data[9]=(uint8)prototype->update_mask.GetBlockCount();
	uint32 len,pos;
	len = 10 + (prototype->update_mask.GetBlockCount()+0)*4;
	packet32 = (uint32*)&data[len];
	pos = 0;
	for( i=0; i<GAMEOBJECT_END; i++)
	if(prototype->update_mask.GetBit(i))
		packet32[pos++] = prototype->data32[i];
	//add bitmask to packet
	memcpy(&data[10],prototype->update_mask.GetMask(),prototype->update_mask.GetBlockCount()*4);
	packet->add_virtual_packet(len+pos*4);
	if(clear_mask)
		prototype->update_mask.Clear();*/
}

void gameobject_instance::update()
{
/*	if(state1 != GAMEOBJECT_WAITING)
	{
		timer1+=time_diff;
	}*/
}

uint8 gameobject_instance::On_GO_spawn(gameobject_instance *p_go)
{return 0;}

uint8 gameobject_instance::On_GO_respawn(gameobject_instance *p_go)
{return 0;}

