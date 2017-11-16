//////////////////////////////////////////////////////////////////////
// RealmListSrv.cpp: implementation of the RealmListSrv class.
//
//////////////////////////////////////////////////////////////////////

// Copyright (C) 2004 Team Python
// Copyright (C) 2004, 2005 Team WSD
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

#include "RealmListSrv.h"
#include "Log.h"
#include "Singleton.h"
#include "Sockets.h"
#include "Accounts.h"
#include "SrpRealm.h"
#include "UserHashes.h"
#include "Debug.h"
#include <sys/stat.h>
#include <string>
#include <math.h>

using namespace std;


//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

createFileSingleton (RealmListSrv);


RealmListSrv::RealmListSrv () {
	FILE * patchini = fopen ("patch.ini", "r");
	if (!patchini) {
		printf ("WARNING: patch.ini not found -- no client patching will be performed!\n");
	} else {
		char redline[256];
		uint32 buildnum; char * offset;
		uint8 counter; char tempbyte[3]; tempbyte[2]=0;
		while (fgets (redline, 256, patchini)) {
			if ((offset = strchr (redline, '='))) {
				buildnum = atoi (redline);
				mPatches [buildnum] = new Patch();//uint8 [16];
				strncpy (mPatches [buildnum]->Platform, offset - 3, 3);
				mPatches [buildnum]->Platform [3] = 0;
				offset++;
				for (counter = 0; counter < 16; counter ++, offset += 2) {
					strncpy (tempbyte, offset, 2);
					mPatches [buildnum]->Hash [counter] = (uint8)strtoul (tempbyte, NULL, 16);
				}
			}
		}
		fclose (patchini);
	}
	// clear logfile
	FILE *pFile = fopen("realmlog.txt", "w+");
	fclose(pFile);
}

RealmListSrv::~RealmListSrv () {
	for (RealmMap::iterator i = mRealms.begin (); i != mRealms.end (); ++ i) {
		delete i->second;
	}
	mRealms.clear ();
	for (PatchMap::iterator i = mPatches.begin (); i != mPatches.end (); ++ i) {
		delete i->second;
	}
	mPatches.clear ();
}

void RealmListSrv::addRealm (char * name, char * address, uint8 icon, uint8 color, uint32 players) {
	removeRealm (name);
	mRealms [name] = new Realm ();
	mRealms [name]->address = address;
	mRealms [name]->players = players;
	mRealms [name]->icon = icon;
	mRealms [name]->color = color;
}

	void RealmListSrv::setRealm (char * name, uint8 icon, uint8 color, uint32 players) {
		if (mRealms.find (name) != mRealms.end ())
			mRealms [name]->players = players;
		if (icon!=2) mRealms [name]->icon = icon;
		if (color!=2) mRealms [name]->color = color;
	}

void RealmListSrv::removeRealm (char * name) {
	if (mRealms.find (name) != mRealms.end ()) {
		delete mRealms [name];
		mRealms.erase (name);
	}
}

/* method to print realmlist */
void RealmListSrv::printRealms()
{
	RealmMap::iterator i;
	for (i = mRealms.begin (); i != mRealms.end(); ++ i)
		printf("\t%s %d\n",i->first.c_str(), i->second->players);
}

enum opcode {
	LOGON_CHALLENGE = 0x00, 
	LOGON_PROOF = 0x01, 
	RECONNECT_CHALLENGE = 0x02, 
	RECONNECT_PROOF = 0x03, 
	REALMLIST = 0x10
};


void RealmListSrv::server_sockevent (nlink *cptr, uint16 revents, void *myNet)
{
	(void)cptr;
	Socket * client;
	nlink *ncptr;
	if(revents & PF_READ)
	{
		client = ( (Socket *) myNet)->AcceptConnection ();
		if (!client) 
			return;
		ulong nonblockingstate = true;
		so_ioctl (client->GetHandle(), FIONBIO, &nonblockingstate);

		ncptr = new nlink;	// client one
		if(ncptr == NULL)
			return;
		memset(ncptr, 0, sizeof(*ncptr));
		ncptr->type = RCLIENT;
		ncptr->fd = client->GetHandle();

		nlink_insert(ncptr);

		RealmClient *pClient = new RealmClient();
		pClient->BindNI(client);
		ncptr->pClient = pClient;
		mClients.insert(pClient);
	}
}

void RealmListSrv::client_sockevent (nlink *cptr, unsigned short revents){

	if(revents & PF_READ)
	{
		RealmClient *pClient = static_cast < RealmClient * > (cptr->pClient);
		Socket *net = pClient->getNetwork();
		uint8 opcode; 	

		if (!net->isConnected()) {
			disconnect_client(cptr);
			return;
		}

		net->getData (1, &opcode);

		if (!net->isConnected()) {
			disconnect_client(cptr);
			return;
		}

		// IMPOSSIBLE with this realm design
		/*
		   if (NETWORK.GetRealmLogging ())
		   {
		   FILE *pFile;
		   pFile = fopen("realmlog.txt", "a");
		   fprintf(pFile, "CLIENT:\nSOCKET: %d\nLENGTH: %d\nOPCODE: %.4X\nDATA:\n", ((GameClient *)(cptr->pClient))->getNetwork ()->GetHandle (), recv_data.length+4, recv_data.opcode);
		   int p=0;
		   while (p < recv_data.length) {
		   for (int j=0; j < 16 && p < recv_data.length; j++)
		   fprintf(pFile, "%.2X ", recv_data.data[p++]);
		   fprintf(pFile, "\n");
		   }

		   fprintf(pFile, "\n\n");
		   fclose(pFile);
		   }*/

		switch (opcode) {
			case LOGON_CHALLENGE:
				{
					LOG.outString ("REALMLIST: Recieved LOGON_CHALLENGE");
					uint8 error; uint16 length;
					char WoW[5]; uint8 byte1, byte2, byte3; uint16 client_version;
					char x86[5]; char Win[5]; char enUS[5];
					WoW[4] = x86[4] = Win[4] = enUS[4] = 0;
					uint8 wb1, wb2;
					int16 int1; uint32 int2; uint8 name_length; char name[256];


					net->getData (1, &error);
					net->getData (2, &length);
					net->getData (4, WoW);
					net->getData (1, &byte1); net->getData (1, &byte2); net->getData (1, &byte3);
					net->getData (2, &client_version);
					net->getData (4, x86); net->getData (4, Win); net->getData (4, enUS);
					net->getData (1, &wb1); net->getData (1, &wb2);
					net->getData (2, &int1); net->getData (4, &int2); net->getData (1, &name_length);
					if (!net->isConnected())
						break;
					net->getData (name_length, name);
					name [name_length] = 0;

					std::string cib;
					printf ("Username: %s\n", name);
					cib = WoW; std::reverse (cib.begin (), cib.end ());
					printf ("Game ID: %s\n", cib.c_str ());
					printf ("Build Version: %i\n", client_version);
					cib = x86; std::reverse (cib.begin (), cib.end ());
					printf ("Architecture: %s\n", cib.c_str ());
					cib = Win; std::reverse (cib.begin (), cib.end ());
					printf ("Platform: %s\n", cib.c_str ());
					cib = enUS; std::reverse (cib.begin (), cib.end ());
					printf ("Language: %s\n", cib.c_str ());
					printf ("Error Start Byte: %i \n", error);
					printf ("Client Version: %i.%i.%i \n", byte1, byte2, byte3);
					printf ("Unknown 2 Bytes: %i %i\n", wb1, wb2);
					printf ("Unknown 16bit Int: %i\n", int1);
					printf ("Unknown 32bit Int: %i\n", int2);

					// check if username and password exist
					char passwd[1024];
					switch (ACCOUNTS.login (name, passwd)) {
						case -1:   // bad password
							{
								uint8 tdata[] = { 0x01, 0x07 };
								net->sendData (sizeof (tdata) , tdata);
								LOG.outString ("REALMLIST: Sent LOGON_PROOF with rejection 'prepaid time used up'");
							}return;
						case -2:   // general failure
							{
								uint8 tdata[] = { 0x01, 0x08 };
								net->sendData (sizeof (tdata) , tdata);
								LOG.outString ("REALMLIST: Sent LOGON_PROOF with rejection 'could not log in'");
							}return;
						case -3:   // bad username
							{
								uint8 tdata[] = { 0x01, 0x03 };
								net->sendData (sizeof (tdata) , tdata);
								LOG.outString ("REALMLIST: Sent LOGON_PROOF with rejection 'account closed'");
							}return;
					}

					// got username & pass, let's start SRP

					pClient->challange(name, passwd);
					uint8 data[118];
					int doo=0;
					data [doo++] = LOGON_CHALLENGE; // 0
					data [doo++] = 0;
					data [doo++] = 0;
					memcpy(data+doo, pClient->BR, 32); doo+=32;
					data [doo++] = 1;
					data [doo++] = 7;
					data [doo++] = 32;
					memcpy(data+doo, pClient->N, 32); doo+=32;
					memcpy(data+doo, pClient->salt, 32); doo+=32;
					memset(data+doo, '\0', 16); doo+=16;
					net->sendData(doo, data);

					LOG.outString ("REALMLIST: Sent LOGON_CHALLENGE");

				}break;
			case LOGON_PROOF:
				{
					LOG.outString ("REALMLIST: Recieved LOGON_PROOF");
					// got
					char A[32];
					char M1[20];
					char crc[20];
					uint8 keys;

					//uint8 number_of_keys;
					net->getData(32, A);
					net->getData(20, M1);
					net->getData(20, crc);
					net->getData(1, &keys);

					pClient->proof(A);

					//printBytes(A, 32, "A");
					printBytes(M1,20, "M1");
					printBytes(pClient->M1, 20, "M1S");
					printBytes(pClient->M2, 20, "M2");
					//printBytes(crc,20, "crc");
					printBytes(pClient->SS_Hash, 40, "SS_Hash");

					if (memcmp(M1, pClient->M1, 20))		// if they differ, wrong pass
					{
						uint8 tdata[] = { 0x01, 0x07 };
						net->sendData (sizeof (tdata) , tdata);
						LOG.outString ("REALMLIST: Sent LOGON_PROOF with rejection 'prepaid time used up'");
						return;
					}

					USERHASHES.addHash (pClient->user, pClient->SS_Hash);

					uint8 data[26];
					int doo=0;
					data [doo++] = LOGON_PROOF;
					data [doo++] = 0;
					memcpy(data+doo, pClient->M2, 20); doo+=20;
					data [doo++] = 0;
					data [doo++] = 0;
					data [doo++] = 0;
					data [doo++] = 0;
					net->sendData(doo, data);
					LOG.outString ("REALMLIST: Sent LOGON_PROOF");
				}break;
			case RECONNECT_CHALLENGE:
				{
					LOG.outString ("REALMLIST: Recieved RECONNECT_CHALLENGE");

				}break;
			case RECONNECT_PROOF:
				{
					LOG.outString ("REALMLIST: Recieved RECONNECT_PROOF");

				}break;
			case REALMLIST:
				{
					LOG.outString ("REALMLIST: Recieved REALMLIST request");
					uint32 request; net->getData(4, &request);

					//format: uint16 datalen, uint32 request, uint8 numrealms
					//eachrealm: string name, string address, uint32 numplayers
					uint16 datalen = 7;
					RealmMap::iterator i;
					uint8 totalrealms = 0;
					for (i = mRealms.begin (); i != mRealms.end (); ++ i, ++totalrealms)
						datalen += i->first.length () + 1 + i->second->address.length () + 13;

					uint8 *data = new uint8 [datalen + 3];
					data [0] = REALMLIST;
					memcpy (data+1, &datalen, 2);
					memcpy (data+3, &request, 4);
					data[7]=totalrealms;
					int doo = 8;

					for (i = mRealms.begin (); i != mRealms.end (); ++ i) {
						data [doo++] = i->second->icon; 
						data [doo++] = 0x00;
						data [doo++] = 0x00;
						data [doo++] = 0x00;
						data [doo++] = i->second->color; 
						strcpy ((char *)data+doo, i->first.c_str ());
						doo+=i->first.length ()+1;
						strcpy ((char *)data+doo, i->second->address.c_str ());
						doo+=i->second->address.length ()+1;
						data [doo++] = (uint8)(i->second->players & 255);
						data [doo++] = (uint8)((i->second->players >> 8) & 255);
						data [doo++] = (uint8)((i->second->players >> 16)& 255);
						data [doo++] = (uint8)((i->second->players >> 24)& 255);
						data [doo++] = 0x64; // ping time (fake)
						data [doo++] = 0x01;
						data [doo++] = 0x02;
					}
					data [doo++] = 0x00;
					data [doo++] = 0x00;

					net->sendData (datalen + 3, data);
					LOG.outString ("REALMLIST: Sent REALMLIST");
					delete [] data;

				}break;
				/*
			case UPDATESRV:
				{
					char buf[256];
					char *realm;
					char *count;
					string rTemp = "";
					LOG.outString ("REALMLIST: Recieved UPDATESRV request");
					net->getData (256, buf);
					realm = strtok(buf,";");
					count = strtok(NULL,";");
					rTemp="";
					rTemp.append(realm);
					// 2, 2 stands for unchanged icon and color
					this->setRealm (const_cast<char *>(rTemp.c_str()), 2, 2, atoi(count));

				}break;
				*/
			default:
				{
					LOG.outString ("WORLDCOMMSRV: Recieved unknown opcode %i", opcode);
				}break;
		} //switch opcode

	} // if pfread

}

void RealmListSrv::disconnect_client (struct nlink *cptr)
{
	RealmClient * pClient = static_cast < RealmClient * > (cptr->pClient);
	printf("Erasing mClients pClient\n");
	mClients.erase (pClient);
	delete pClient;
	LOG.outString ("REALM: Socket Closed!");
	Server::disconnect_client (cptr);
}

