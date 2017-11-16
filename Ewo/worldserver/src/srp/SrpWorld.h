//////////////////////////////////////////////////////////////////////
//  SrpWorld
//  
//  SrpWorld header
//////////////////////////////////////////////////////////////////////

// copyright (c) 2005 team wsd
// Copyright (C) 2006 Team Evolution
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

#ifndef SRPWORLD_H
#define SRPWORLD_H

class SrpWorld;

class SrpWorld
{
	public:
		char user[1024];
		char SS_Hash[85];//when we first time load it from db it is in hex-> 2*40
		unsigned char keypos, prevbyte;
		unsigned char keypos2, prevbyte2;
		bool firstSent;
		bool firstRecv;

		SrpWorld()
		{
			firstSent = false;
			firstRecv = false;
			keypos = 0; prevbyte = 0;
			keypos2 = 0; prevbyte2 = 0;
		}

		~SrpWorld() {}

		void start_encode_decode(){firstSent=firstRecv=true;keypos=prevbyte=keypos2=prevbyte2=0;}
		void decode(unsigned char *data);
		void encode(unsigned char *data);
};

#endif
