#include "Compress.h"
#include "zlib/zlib.h"

CCompress::CCompress(void)
{
	outbuffer=0;
	outsize=0;
}

CCompress::~CCompress(void)
{
	if (outbuffer)
	{
		free(outbuffer);
		outsize=0;
		outbuffer=0;
	}
}

unsigned long CCompress::Inflate(void *inbuffer, unsigned long insize)
{
	if (outbuffer)
	{
		free(outbuffer);
		outsize=0;
		outbuffer=0;
	}
	z_stream z;
	memset(&z,0,sizeof(z_stream));
	unsigned long result=inflateInit(&z);
	if (result!=Z_OK)
	{
		return 0;
	}
	
	outbuffer=(char*)malloc(65535);
	z.avail_in=insize;
	z.next_in=(Bytef*)inbuffer;
	z.next_out=(Bytef*)outbuffer;
	z.avail_out=65535;

	result=inflate(&z,Z_FINISH);
	if (result!=Z_OK && result!=Z_STREAM_END)
	{
		inflateEnd(&z);
		return 0;
	}
	inflateEnd(&z);
	outsize=z.total_out;
	return outsize;
}

unsigned long CCompress::Deflate(void *inbuffer, unsigned long insize)
{
	if (outbuffer)
	{
		free(outbuffer);
		outsize=0;
		outbuffer=0;
	}
	z_stream z;
	memset(&z,0,sizeof(z_stream));
	unsigned long result=deflateInit(&z,1);
	if (result!=Z_OK)
	{
		return 0;
	}
	
	outbuffer=(char*)malloc(65535);
	z.avail_in=insize;
	z.next_in=(Bytef*)inbuffer;
	z.next_out=(Bytef*)outbuffer;
	z.avail_out=65535;

	result=deflate(&z,Z_FINISH);
	if (result!=Z_OK && result!=Z_STREAM_END)
	{
		inflateEnd(&z);
		return 0;
	}
	deflateEnd(&z);
	outsize=z.total_out;
	return outsize;
}

bool CCompress::GetBuffer(void *yourmemory)
{
	if (!yourmemory || !outbuffer || outsize==0)
		return false;
	memcpy(yourmemory,&outbuffer[0],outsize);
	free(outbuffer);
	outbuffer=0;
	return true;
}
