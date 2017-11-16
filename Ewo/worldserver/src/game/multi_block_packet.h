// Copyright (C) 2006 Team Evolution
#pragma once
//#include <stdio.h>
//#include <stdlib.h>
//#include <windows.h>
#include "Network.h"
#include "UpdateFields.h"

class Compressed_Update_Block
{
public:
    Compressed_Update_Block(); //the constructor
	~Compressed_Update_Block(); //destructor (we do not alocate anything. the destructors of other objects will take care of theirself
	inline void add_out_of_range_id(const uint64 object_id)
	{
		out_of_range_packet.resize_if_too_small(out_of_range_packet.length+8);
		out_of_range_packet.data64[out_of_range++]=object_id;
		out_of_range_packet.length+=8;
	}
	inline void add_raw_info_as_block(const uint8 *src,uint32 length)
	{
		multi_block_packet.resize_if_too_small(multi_block_packet.length + length);
		memcpy(multi_block_packet.data+multi_block_packet.length,src,length);
		multi_block_packet.length+=length;
		block_count++;
	}
	inline uint8* get_next_pointer()//use this combined with add_virtual_packet
	{
		//make sure next block will fit in here
		multi_block_packet.resize_if_too_small(multi_block_packet.length + PLAYER_END*4);
		//return the first free position in our buffer
		return &multi_block_packet.data[multi_block_packet.length];
	}
	inline void add_virtual_packet(uint32 length)//incase we used the get_next_pointer function we set the length 2 for the last packet
	{
		multi_block_packet.length+=length;
	    block_count++;
	}
	void clear();
	NetworkPacket* build_packet(); //the hear of this class
	inline void add_blocks_from_other_packet(Compressed_Update_Block *packet)
	{
		multi_block_packet.resize_if_too_small(multi_block_packet.length + packet->multi_block_packet.length);
		memcpy(&multi_block_packet.data[multi_block_packet.length],packet->multi_block_packet.data,packet->multi_block_packet.length);
		multi_block_packet.length+=packet->multi_block_packet.length;
		block_count+=packet->block_count;
	}
	inline uint32 get_length()
	{
		return multi_block_packet.length;
	}
	NetworkPacket multi_block_packet,out_of_range_packet,prepared_packet,compressed_packet;
    uint32 block_count,out_of_range,is_prepared;
	NetworkPacket *p_prepared_packet;

	void Compress(void* dst, uint32 *dst_size, void* src, int src_size);
};
