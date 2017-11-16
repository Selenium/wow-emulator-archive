//////////////////////////////////////////////////////////////////////
//  SrpRealm 
//  
//  SrpRealm headers
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

#ifndef SRPREALM_H
#define SRPREALM_H

#include "bigint.h"
#include <stdlib.h>
#include <stdio.h>
#include <ctype.h>
#include <string.h>

void reverse(char *d, char *s, int l);
int toInt(char c);
void fromHex(char *d, char *s, int l);
void getOdd(char *d, char *s, int l);
void getEven(char *d, char *s, int l);
void merge(char *d, char *s1, char *s2, int l);
void xorMerge(char *d, char *s1, char *s2, int l);
void printBigInteger(BigInteger BN, char *name);
void printBytes(char* bytes, int l, char *name);

class SrpRealm
{
	protected:
		char b[32];
		char v[32];
	public:
		char user[1024];
		char BR[32];
		char N[32];
		char M1[20];
		char M2[20];
		char SS_Hash[40];
		char salt[32];

		void challange(const char *userName, char *passwd);
		void proof(char *A);
		int BigIntegerToBytes2(BigInteger src, unsigned char * dest, int destlen);
};

#endif
