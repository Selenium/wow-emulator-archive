//////////////////////////////////////////////////////////////////////
//  SrpRealm 
//  
//  SrpRealm stuff
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

#include "bigint.h"
#include "SrpRealm.h"
#include <stdlib.h>
#include <stdio.h>
#include <ctype.h>
#include <string.h>
#include <openssl/sha.h>
#include <openssl/ssl.h>
#include <openssl/rand.h>

void reverse(char *d, char *s, int l)
{
	int i;
	for(i=0; i<l; i++)
		d[i]=s[l-i-1];
}

int toInt(char c)
{
	if(48<=c && c<=57)
		return c-48;
	if(97<=c && c<=102)
		return c-87;
	if(65<=c && c<=70)
		return c-55;
	return 0;
}

void fromHex(char *d, char *s, int l)
{
	int i;
	for(i=0; i<l*2; i+=2)
		d[(int)i/2] = toInt(s[i])*16 + toInt(s[i+1]);
}

void getOdd(char *d, char *s, int l)
{
	int i;
	for(i=0; i<l; i+=2)
		d[i/2]=s[i];
}

void getEven(char *d, char *s, int l)
{
	int i;
	for(i=0; i<l; i+=2)
		d[i/2]=s[i+1];
}

void merge(char *d, char *s1, char *s2, int l)
{
	int i;
	for(i=0; i<l*2; i+=2)
	{
		d[i]=s1[i/2];
		d[i+1]=s2[i/2];
	}
}

void xorMerge(char *d, char *s1, char *s2, int l)
{
	int i;
	for(i=0; i<l; i++)
		d[i]=s1[i] ^ s2[i];
}

void printBigInteger(BigInteger BN, char *name)
{
	char temp[1024];
	BigIntegerToHex(BN, temp, 1024);
	printf("%s: %s\n", name, temp);
}

int SrpRealm::BigIntegerToBytes2(BigInteger src, unsigned char * dest, int destlen)
{
	int shift = destlen - BigIntegerByteLen(src);
	printf("	SHIFT: %d %d %d\n", shift, destlen, BigIntegerByteLen(src));
	return BigIntegerToBytes(src, dest+shift, destlen);
}

void SrpRealm::challange(const char *userName, char *passwd)
{
	// init
	char dest[1024];
	char dest2[1024];

	strcpy(user, userName);
	fromHex(N, "894B645E89E1535BBDAD5B8B290650530801B18EBFBF5E8FAB3C82872A3E9BB7", 32);
	char NR[32];
	reverse(NR, N, 32);
	BigInteger NR_BN = BigIntegerFromBytes((const unsigned char*)NR,32);

	char bR[20];
	RAND_bytes((unsigned char*)b, 20);
//	fromHex(b, "8692E3A6BA48B5B1004CEF76825127B7EB7D1AEF", 20);
	reverse(bR, b, 20);
	BigInteger bR_BN = BigIntegerFromBytes((const unsigned char*)bR, 20);

	RAND_bytes((unsigned char*)salt, 32);
//	fromHex(salt, "33f140d46cb66e631fdbbbc9f029ad8898e05ee533876118185e56dde843674f", 32);

	BigInteger G_BN = BigIntegerFromInt(7);
	BigInteger K_BN = BigIntegerFromInt(3);

	char userPass[1024];
	strcpy(userPass, user);
	strcat(userPass, ":");
	strcat(userPass, passwd);

	// x
	SHA1((const unsigned char*)userPass, strlen(userPass), (unsigned char*)dest);
	memcpy(dest2, salt, 32);
	memcpy(dest2+32, dest, 20);
	SHA1((const unsigned char*)dest2, 52, (unsigned char*)dest);
//	printBytes(dest, 20, "x");
	char xR[20];
	reverse(xR, dest, 20);

	// v	
	BigInteger xR_BN = BigIntegerFromBytes((const unsigned char*)xR,20);
	BigInteger v_BN = BigIntegerFromInt(0);
	BigIntegerModExp(v_BN, G_BN, xR_BN, NR_BN, NULL, NULL);
	BigIntegerToBytes2(v_BN, (unsigned char*)v, 32);
//	printBigInteger(v_BN, "v");

	// BR
	BigInteger B_BN = BigIntegerFromInt(0);
	BigIntegerMul(B_BN, K_BN, v_BN, NULL);
	BigIntegerModExp(K_BN, G_BN, bR_BN, NR_BN, NULL, NULL);
	BigIntegerAdd(K_BN, K_BN, B_BN);
	BigIntegerMod(B_BN, K_BN, NR_BN, NULL);
	BigIntegerToBytes2(B_BN, (unsigned char*)dest, 32);
	reverse(BR, dest, 32);
//	printBytes(BR, 32, "BR");

	BigIntegerFree(NR_BN);
	BigIntegerFree(bR_BN);
	BigIntegerFree(K_BN);
	BigIntegerFree(G_BN);
	BigIntegerFree(xR_BN);
	BigIntegerFree(v_BN);
	BigIntegerFree(B_BN);

}

void SrpRealm::proof(char *A)
{
	// init
	char dest[1024];
	char dest2[1024];

	// we got it over net
//	fromHex(M1, "eeb4adca80f4de02f9a9fe8d000d682e3ddfad6f", 20);
	char AR[32];
//	fromHex(A, "232fb1b88529643d95b8dce78f2750c75b2df37acba873eb31073839eda0738d", 32);
	reverse(AR, A, 32);
	BigInteger AR_BN = BigIntegerFromBytes((const unsigned char*)AR, 32);
	char NR[32];
	reverse(NR, N, 32);
	BigInteger NR_BN = BigIntegerFromBytes((const unsigned char*)NR, 32);
	char bR[20];
	reverse(bR, b, 20);
	BigInteger bR_BN = BigIntegerFromBytes((const unsigned char*)bR, 20);
	BigInteger v_BN = BigIntegerFromBytes((const unsigned char*)v, 32);
	BigInteger G_BN = BigIntegerFromInt(7);

	// U
	memcpy(dest2, A, 32);
	memcpy(dest2+32, BR, 32);
	SHA1((const unsigned char*)dest2, 32+32, (unsigned char*)dest);
//	printBytes(dest, 20, "U");
	char UR[20];
	reverse(UR, dest, 20);
	BigInteger UR_BN = BigIntegerFromBytes((const unsigned char*)UR, 20);

	// S
	BigInteger S_BN = BigIntegerFromInt(0);
	BigIntegerModExp(S_BN, v_BN, UR_BN, NR_BN, NULL, NULL);
	BigIntegerMul(S_BN, S_BN, AR_BN, NULL);
	BigIntegerModExp(S_BN, S_BN, bR_BN, NR_BN, NULL, NULL);
//	printBigInteger(S_BN, "S");

	BigIntegerToBytes2(S_BN, (unsigned char*)dest, 32);
	char SR[32], odd[16], even[16];
	reverse(SR, dest, 32);
	getOdd(odd, SR, 32);
	getEven(even, SR, 32);

	SHA1((const unsigned char*)odd, 16, (unsigned char*)dest);
	SHA1((const unsigned char*)even, 16, (unsigned char*)dest2);
	merge(SS_Hash, dest, dest2, 20);

	BigIntegerToBytes2(G_BN, (unsigned char*)dest, 1);
	SHA1((const unsigned char*)dest, 1, (unsigned char*)dest2); 		// G_Hash
	SHA1((const unsigned char*)N, 32, (unsigned char*)dest);		// N_Hash
	char NG_Hash[20];
	xorMerge(NG_Hash, dest, dest2, 20);					// NG_Hash
	SHA1((const unsigned char*)user, strlen(user), (unsigned char*)dest);	// User_Hash

	memcpy(dest2, NG_Hash, 20);
	memcpy(dest2+20, dest, 20);
	memcpy(dest2+20+20, salt, 32);
	memcpy(dest2+20+20+32, A, 32);
	memcpy(dest2+20+20+32+32, BR, 32);
	memcpy(dest2+20+20+32+32+32, SS_Hash, 40);

	SHA1((const unsigned char*)dest2, 20+20+32+32+32+40, (unsigned char*)M1);
//	printBytes(M1, 20, "M1");

	memcpy(dest2, A, 32);
	memcpy(dest2+32, M1, 20);
	memcpy(dest2+32+20, SS_Hash, 40);

	SHA1((const unsigned char*)dest2, 32+20+40, (unsigned char*)M2);

//	printBytes(M2, 20, "M2");

	BigIntegerFree(AR_BN);
	BigIntegerFree(NR_BN);
	BigIntegerFree(bR_BN);
	BigIntegerFree(v_BN);
	BigIntegerFree(G_BN);
	BigIntegerFree(UR_BN);
	BigIntegerFree(S_BN);
}
