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

#ifndef WOWPYTHONSERVER_REALMCLIENT_H
#define WOWPYTHONSERVER_REALMCLIENT_H

#include "Common.h"
#include "Client.h"
#include "opcodes_realm.h"
#include "BigNumber.h"
#include "Sha1.h"
//#include "Network/TcpSocket.h"
#include <openssl/md5.h> 

class RealmClient : public Client
{
public:
	sAuthLogonChallenge_C client_info;
	char username[25];
	char full_ip[16];
#define MD5_DIGEST_LENGTH 16
const static int N_BYTE_SIZE = 32;
const static int s_BYTE_SIZE = 32;
public:
	RealmClient();
    BigNumber N, s, g, v;
    BigNumber b, B;
    BigNumber rs;
    BigNumber unk3;
    BigNumber M;
    // mighty session key.
    // one should keep this in some other place,
    // we will use it from other AuthSocket object (upon reconnect)
	std::string sessionkey;
    BigNumber K;
    Sha1Hash sha;
    std::string password;
	void challange(const char *userName, char *passwd);
	void proof(char *p_A);
};

#endif
