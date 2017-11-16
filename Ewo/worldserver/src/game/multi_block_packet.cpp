// Copyright (C) 2006 Team Evolution
#include "Log.h"
#include "multi_block_packet.h"
#include "zlib.h"
#include "Opcodes.h"
#include "constants.h"
#include "UpdateFields.h"

Compressed_Update_Block::Compressed_Update_Block()
{
    block_count=0;
	out_of_range=0;
	out_of_range_packet.length = 0;
	multi_block_packet.length = 0;
	multi_block_packet.resize_if_too_small(32000);
	compressed_packet.length = 0;
	compressed_packet.resize_if_too_small(32000);
	prepared_packet.length = 0;
	prepared_packet.resize_if_too_small(32000);
	is_prepared = 0;
}

Compressed_Update_Block::~Compressed_Update_Block()
{
}

// uses zlib with Z_BEST_SPEED method
// out: dst/dst_size
// *dst_size=0 if error
void Compressed_Update_Block::Compress(void* dst, uint32 *dst_size, void* src, int src_size)
{
   z_stream c_stream;
   c_stream.zalloc = (alloc_func)0;
   c_stream.zfree = (free_func)0;
   c_stream.opaque = (voidpf)0;
   if (Z_OK != deflateInit(&c_stream, Z_BEST_SPEED))
   {
      Log::getSingleton().outError("Can't compress update packet (zlib: deflateInit).");
      *dst_size = 0;
      return;
   }
   c_stream.next_out = (Bytef*)dst;
   c_stream.avail_out = *dst_size;
   c_stream.next_in = (Bytef*)src;
   c_stream.avail_in = (uInt)src_size;
   if (Z_OK != deflate(&c_stream, Z_NO_FLUSH))
   {
      Log::getSingleton().outError("Can't compress update packet (zlib: deflate)");
      *dst_size = 0;
      return;
   }
    if (c_stream.avail_in != 0)
   {
        Log::getSingleton().outError("Can't compress update packet (zlib: deflate not greedy)");
      *dst_size = 0;
      return;
    }
    if (Z_STREAM_END != deflate(&c_stream, Z_FINISH))
   {
        Log::getSingleton().outError("Can't compress update packet (zlib: deflate should report Z_STREAM_END)");
      *dst_size = 0;
      return;
    }
    if (Z_OK != deflateEnd(&c_stream))
   {
        Log::getSingleton().outError("Can't compress update packet (zlib: deflateEnd)");
      *dst_size = 0;
      return;
    }
   *dst_size = c_stream.total_out;
}

NetworkPacket* Compressed_Update_Block::build_packet()
{
	if(is_prepared==1)
		return p_prepared_packet;
	if(block_count==0)
		return NULL;
	if(out_of_range!=0)	prepared_packet.data32[0] = block_count + 1;
	else prepared_packet.data32[0] = block_count ;
	prepared_packet.data[4] = 0; //unknown
	prepared_packet.length = 5;
	prepared_packet.resize_if_too_small(out_of_range_packet.length + multi_block_packet.length + 10);
	if(out_of_range!=0)
	{
		prepared_packet.data[5] = UPDATETYPE_OUT_OF_RANGE_OBJECTS;
		*(uint32*)(&prepared_packet.data[6]) = out_of_range;
		memcpy(&prepared_packet.data[10],&out_of_range_packet.data[0],out_of_range_packet.length);
		prepared_packet.length += 5 + out_of_range_packet.length;
	}
	memcpy(&prepared_packet.data[prepared_packet.length],&multi_block_packet.data[0],multi_block_packet.length);
	prepared_packet.length += multi_block_packet.length;
    // do not compress small packets
//    if (prepared_packet.length > 100)
    if (prepared_packet.length > 100000) //when debuging, i use unpacked packets to see contents
    {
		compressed_packet.length = prepared_packet.length + prepared_packet.length/10 + 16;
		compressed_packet.resize_if_too_small(compressed_packet.length);
		compressed_packet.data32[0] = compressed_packet.length; //the uncompressed packet length 
		Compress((void*)&compressed_packet.data32[1],&compressed_packet.length,(void*)&prepared_packet.data[0],prepared_packet.length);
		if (compressed_packet.length == 0)
            return NULL; // Loged by Compress()
		compressed_packet.length += 4;//don't forget about the first four bytes ;)
		compressed_packet.opcode = SMSG_COMPRESSED_UPDATE_OBJECT;
		is_prepared = 1;
		p_prepared_packet = &compressed_packet;
		return &compressed_packet;
    }
    else
    {
		prepared_packet.opcode = SMSG_UPDATE_OBJECT;
		is_prepared = 1;
		p_prepared_packet = &prepared_packet;
		return &prepared_packet;
    }
	return NULL;
}

void Compressed_Update_Block::clear()
{
    block_count=0;
	out_of_range=0;
	out_of_range_packet.length = 0;
	multi_block_packet.length = 0;
	compressed_packet.length = 0;
	prepared_packet.length = 0;
	is_prepared = 0;
}
