//////////////////////////////////////////////////////////////////////
//  SrpWorld
//  
//  SrpWorld stuff
//////////////////////////////////////////////////////////////////////

// copyright (c) 2005 team wsd
//
// this program is free software; you can redistribute it and/or modify
// it under the terms of the gnu general public license as published by
// the free software foundation; either version 2 of the license, or
// (at your option) any later version.
//
// this program is distributed in the hope that it will be useful,
// but without any warranty; without even the implied warranty of
// merchantability or fitness for a particular purpose.  see the
// gnu general public license for more details.
//
// you should have received a copy of the gnu general public license
// along with this program; if not, write to the free software
// foundation, inc., 59 temple place - suite 330, boston, ma 02111-1307, usa.

#include "SrpWorld.h"

void SrpWorld::decode( unsigned char *data )
{ 
	if(firstRecv && encrypt)
	{
		unsigned char* K = (unsigned char*)SS_Hash;
		for(int i = 0; i < 6; i++ )
		{       
			unsigned char a = prevbyte;
			prevbyte = data[i];
			data[i] = K[keypos] ^ (data[i] - a);
			keypos++;
			keypos %= 40;
		} 
	}
	else
		firstRecv = true;
} 

void SrpWorld::encode( unsigned char *data )
{          
	if(firstSent && encrypt)
	{
		unsigned char* K = (unsigned char*)SS_Hash;
		for(int i = 0;i < 4; i++ )
		{
			data[i] = (K[keypos2] ^ data[i]) + prevbyte2;
			prevbyte2 = data[i];
			keypos2++;
			keypos2 %= 40;
		}
	}
	else
		firstSent = true;
}
