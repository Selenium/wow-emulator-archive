/************************************************************************************
 * Place Holder for Realm Client data(for stuff like password checking etc.) - tmm` *
 ************************************************************************************/

// Copyright (C) 2004 Team Python
// Copyright (C) 2004, 2005 Team WSD
// Copyright (C) 2006 Team Evolution
//  
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software 
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.
 
 
#include <stdlib.h>
#include <stdio.h>
#include <ctype.h>
#include <string.h>
#include <openssl/sha.h>
#include <openssl/ssl.h>
#include <openssl/rand.h>
#include "RealmClient.h"

RealmClient::RealmClient()
{
    N.SetHexStr("894B645E89E1535BBDAD5B8B290650530801B18EBFBF5E8FAB3C82872A3E9BB7");
    g.SetDword(7);
    s.SetRand(s_BYTE_SIZE * 8);
}

void RealmClient::challange(const char *userName, char *passwd)
{

	Sha1Hash I;
	char authstr[100];
	sprintf( authstr,"%s:%s",userName,passwd);
printf("preparring proof for '%s'\n",authstr);
    I.UpdateData((const uint8*)authstr,strlen(authstr));
    I.Finalize();

    Sha1Hash sha;
    sha.UpdateData(s.AsByteArray(), s_BYTE_SIZE);
    sha.UpdateData(I.GetDigest(), 20);
    sha.Finalize();

    BigNumber x;
    x.SetBinary(sha.GetDigest(), sha.GetLength());
    
    v = g.ModExp(x, N);
    b.SetRand(19 * 8);

    BigNumber gmod = g.ModExp(b, N);
    B = ((v * 3) + gmod) % N;

    unk3.SetRand(16*8);
}

void RealmClient::proof(char *p_A)
{
    BigNumber A;
    A.SetBinary((const uint8*)p_A, 32);

    sha.UpdateBigNumbers(&A, &B, NULL);
    sha.Finalize();
    BigNumber u;
    u.SetBinary(sha.GetDigest(), 20);
    BigNumber S = (A * (v.ModExp(u, N))).ModExp(b, N);

    uint8 t[32];
    uint8 t1[16];
    uint8 vK[40];
    memcpy(t, S.AsByteArray(), 32);
    for (int i = 0; i < 16; i++)
        t1[i] = t[i*2];
    sha.Initialize();
    sha.UpdateData(t1, 16);
    sha.Finalize();
    for (int i = 0; i < 20; i++)
        vK[i*2] = sha.GetDigest()[i];
    for (int i = 0; i < 16; i++)
        t1[i] = t[i*2+1];
    sha.Initialize();
    sha.UpdateData(t1, 16);
    sha.Finalize();
    for (int i = 0; i < 20; i++)
        vK[i*2+1] = sha.GetDigest()[i];
    K.SetBinary(vK, 40);

    uint8 hash[20];

    sha.Initialize();
    sha.UpdateBigNumbers(&N, NULL);
    sha.Finalize();
    memcpy(hash, sha.GetDigest(), 20);
    sha.Initialize();
    sha.UpdateBigNumbers(&g, NULL);
    sha.Finalize();
    for (int i = 0; i < 20; i++)
        hash[i] ^= sha.GetDigest()[i];
    BigNumber t3;
    t3.SetBinary(hash, 20);

    sha.Initialize();
    sha.UpdateData(username);
    sha.Finalize();
    BigNumber t4;
    t4.SetBinary(sha.GetDigest(), 20);

    sha.Initialize();
    sha.UpdateBigNumbers(&t3, &t4, &s, &A, &B, &K, NULL);
    sha.Finalize();
    M.SetBinary(sha.GetDigest(), 20);
	sessionkey = K.AsHexStr();

    sha.Initialize();
    sha.UpdateBigNumbers(&A, &M, &K, NULL);
    sha.Finalize();

}
