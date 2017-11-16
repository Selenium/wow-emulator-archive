// (c) Abyss Group

#include "Base64.h"

namespace Base64
{

	// Function: Base64Encode.
	void Base64Encode(const char *str, unsigned int length, char *base64)
	{
		char *pa;
		char *pb;
		int mod;
		char *end;
		
		pa = (char *)str;
		pb = base64;
		mod = length % 3;
		end = (char *)str + length - mod;
		
		while (pa < end)
		{
			*pb = Base64EncodeTable[*pa >> 2];
			++pb;
			*pb = Base64EncodeTable[((*pa & 0x03) << 4) | (*++pa >> 4)];
			++pb;
			*pb = Base64EncodeTable[((*pa & 0x0f) << 2) | (*++pa >> 6)];
			++pb;
			*pb = Base64EncodeTable[*pa & 0x3f];
			++pb;
			++pa;
		}
		
		switch (mod)
		{
		case 1:
			*pb = Base64EncodeTable[*pa >> 2];
			++pb;
			*pb = Base64EncodeTable[(*pa & 0x03) << 4];
			++pb;
			*pb = Base64Pad;
			++pb;
			*pb = Base64Pad;
			++pb;
			break;
		case 2:
			*pb = Base64EncodeTable[*pa >> 2];
			++pb;
			*pb = Base64EncodeTable[((*pa & 0x03) << 4) | (*++pa >> 4)];
			++pb;
			*pb = Base64EncodeTable[(*pa & 0x0f) << 2];
			++pb;
			*pb = Base64Pad;
			++pb;
		default:
			;
		}
		*pb = '\0';
	}
	
	// Function: Base64Decode.
	void Base64Decode(const char *base64, char *str, unsigned int *length)
	{
		char *pa;
		char *pb;
		int mod;
		char *end;
		
		pa = (char *)base64;
		pb = str;
		end = strchr(base64, '\0');
		if (*(end - 2) == '=')
		{
			mod = 2;
			*(end - 2) = '\0';
			*(end - 1) = '\0';
		}
		else if (*(end - 1) == '\0')
		{
			mod = 1;
			*(end - 1) = '\0';
		}
		else
			mod = 0;
		
		*length = end - pa;
		*length -= *length / 4 - mod;
		
		while (pa < end)
		{
			*pb = (Base64DecodeTable[*pa] << 2) | (Base64DecodeTable[*++pa] >> 4);
			++pb;
			*pb = (Base64DecodeTable[*pa] << 4) | (Base64DecodeTable[*++pa] >> 2);
			++pb;
			*pb = (Base64DecodeTable[*pa] << 6) | (Base64DecodeTable[*++pa]);
			++pb;
			++pa;
		}
	}

}
