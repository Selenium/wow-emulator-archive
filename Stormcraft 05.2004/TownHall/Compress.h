#pragma once
#include "stdafx.h"

class CCompress
{
public:
	CCompress(void);
	~CCompress(void);

	bool GetBuffer(void *yourmemory);
	unsigned long Inflate(void *inbuffer, unsigned long insize);
	unsigned long Deflate(void *inbuffer, unsigned long insize);

	char *outbuffer;
	unsigned long outsize;
	CSemaphore S; // manually lock this
};
