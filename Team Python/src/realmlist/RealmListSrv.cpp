// Copyright (C) 2004 Team Python
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

// RealmListSrv.cpp: implementation of the RealmListSrv class.
//
//////////////////////////////////////////////////////////////////////

#include "RealmListSrv.h"
#include "Log.h"
#include "Singleton.h"
#include "Database.h"
#include "Sockets.h"
#include <sys/stat.h>
#include <string>
using namespace::std;



//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

createFileSingleton( RealmListSrv );


RealmListSrv::RealmListSrv( ) {
    FILE * patchini = fopen( "patch.ini", "r" );
    if( !patchini ) {
        printf( "WARNING: patch.ini not found -- no client patching will be performed!" );
    } else {
        char redline[256];
        uint32 buildnum; char * offset;
        uint8 counter; char tempbyte[3]; tempbyte[2]=0;
        while( fgets( redline, 256, patchini ) ) {
            if( offset = strchr( redline, '=' ) ) {
                buildnum = atoi( redline );
                mPatches[ buildnum ] = new Patch();//uint8[ 16 ];
                strncpy( mPatches[ buildnum ]->Platform, offset - 3, 3 );
                mPatches[ buildnum ]->Platform[ 3 ] = 0;
                offset++;
                for( counter = 0; counter < 16; counter ++, offset += 2 ) {
                    strncpy( tempbyte, offset, 2 );
                    mPatches[ buildnum ]->Hash[ counter ] = (uint8)strtoul( tempbyte, NULL, 16 );
                }
            }
        }
        fclose( patchini );
    }
}

RealmListSrv::~RealmListSrv( ) {
    for( RealmMap::iterator i = mRealms.begin( ); i != mRealms.end( ); ++ i ) {
        delete i->second;
    }
    mRealms.clear( );
    for( PatchMap::iterator i = mPatches.begin( ); i != mPatches.end( ); ++ i ) {
        delete i->second;
    }
    mPatches.clear( );
}

void RealmListSrv::addRealm( char * name, char * address, uint8 icon, uint8 color, uint32 players ) {
    removeRealm( name );
    mRealms[ name ] = new Realm( );
    mRealms[ name ]->address = address;
    mRealms[ name ]->players = players;
	mRealms[ name ]->icon = icon;
	mRealms[ name ]->color = color;
}

void RealmListSrv::setRealm( char * name, uint8 icon, uint8 color, uint32 players ) {
    if( mRealms.find( name ) != mRealms.end( ) )
        mRealms[ name ]->players = players;
		if (icon!=2) mRealms[ name ]->icon = icon;
		if (color!=2) mRealms[ name ]->color = color;
}

void RealmListSrv::removeRealm( char * name ) {
    if( mRealms.find( name ) != mRealms.end( ) ) {
        delete mRealms[ name ];
        mRealms.erase( name );
    }
}

/* method to print realmlist */
void RealmListSrv::printRealms()
{
	RealmMap::iterator i;
	for( i = mRealms.begin( ); i != mRealms.end( ); ++ i )
	{
		printf("%s %d\n",i->first.c_str(),i->second->players );
	}
}

enum opcode {
    LOGON_CHALLENGE = 0x00, 
    LOGON_PROOF = 0x01, 
    RECONNECT_CHALLENGE = 0x02, 
    RECONNECT_PROOF = 0x03, 
    REALMLIST = 0x10,
	UPDATESRV = 0x04	
};


void RealmListSrv::server_sockevent( nlink_server *cptr, uint16 revents, void *myNet ) {
	NetworkInterface * client;
	struct nlink_client *ncptr;
	if(revents & PF_READ)
	{
		client = ( ( NetworkInterface * ) myNet )->getConnection( );
		if (!client) 
			return;
		uint32 nonblockingstate = true;
		IOCTL_SOCKET( client->getSocketID(), IOCTL_NOBLOCK, &nonblockingstate );

		ncptr = new nlink_client;
		if(ncptr == NULL)
			return;
		memset(ncptr, 0, sizeof(*ncptr));
		ncptr->hdr.type = RCLIENT;
		ncptr->hdr.fd = client->getSocketID();
		
		nlink_insert((struct nlink *)ncptr);

		Client *pClient = new Client();
		pClient->BindNI(client);
		ncptr->pClient = pClient;
	}
}

void RealmListSrv::client_sockevent(struct nlink_client *cptr, unsigned short revents){

	if(revents & PF_READ)
	{
		RealmClient *pClient = static_cast < RealmClient * > ( cptr->pClient );
		NetworkInterface *net = pClient->getNetwork();
		uint8 opcode; 	

		if (!net->isConnected()) {
			disconnect_client(cptr);
			return;
		}

		net->getData( 1, &opcode );
		if (!net->isConnected()) {
			disconnect_client(cptr);
			return;
		}
		switch( opcode ) {
			case LOGON_CHALLENGE:
			{
			Log::getSingleton( ).outString( "REALMLIST: Recieved LOGON_CHALLENGE" );
			uint8 unknown; uint16 length;
			char WoW[5]; uint8 byte1, byte2, byte3; uint16 client_version;
			char x86[5]; char Win[5]; char enUS[5];
			WoW[4] = x86[4] = Win[4] = enUS[4] = 0;
			uint8 wb1, wb2;
			int16 int1; uint32 int2; uint8 name_length; char name[256];

			net->getData( 1, &unknown );
			net->getData( 2, &length );
			net->getData( 4, WoW );
			net->getData( 1, &byte1 ); net->getData( 1, &byte2 ); net->getData( 1, &byte3 );
			net->getData( 2, &client_version );
			net->getData( 4, x86 ); net->getData( 4, Win ); net->getData( 4, enUS );
			net->getData( 1, &wb1 ); net->getData( 1, &wb2 );
			net->getData( 2, &int1 ); net->getData( 4, &int2 ); net->getData( 1, &name_length );
			if (!net->isConnected())
				break;
			net->getData( name_length, name );
			name[ name_length ] = 0;

			std::string cib;
			//printf( "Username: %s\n", name );
			cib = WoW; std::reverse( cib.begin( ), cib.end( ) );
			//printf( "Game ID: %s\n", cib.c_str( ) );
			//printf( "Version: %i\n", client_version );
			cib = x86; std::reverse( cib.begin( ), cib.end( ) );
			//printf( "Architecture: %s\n", cib.c_str( ) );
			cib = Win; std::reverse( cib.begin( ), cib.end( ) );
			//printf( "Platform: %s\n", cib.c_str( ) );
			cib = enUS; std::reverse( cib.begin( ), cib.end( ) );
			//printf( "Language: %s\n", cib.c_str( ) );
			//printf( "Unknown Start Byte: %i \n", unknown );
			//printf( "Unknown 3 Game Bytes: %i %i %i \n", byte1, byte2, byte3 );
			//printf( "Unknown 2 Bytes: %i %i\n", wb1, wb2 );
			//printf( "Unknown 16bit Int: %i\n", int1 );
			//printf( "Unknown 32bit Int: %i\n", int2 );

                    
			if( client_version != EXPECTED_WOW_CLIENT_BUILD ) {
				if( client_version < EXPECTED_WOW_CLIENT_BUILD ) {
					if( mPatches.find( client_version ) != mPatches.end( ) ) {
						char filnam[64]; 
						sprintf( filnam, "%i%s.mpq", client_version, mPatches[ client_version ]->Platform );
						FILE * patchfil = fopen( filnam, "rb" );
						if( patchfil ) {
							{
							uint8 newopcode = LOGON_PROOF;
							uint8 data[2] = { newopcode, 0x0a };
							net->sendData( 2, data );
							Log::getSingleton( ).outString( "REALMLIST: Sent LOGON_PROOF" );
							}
										{
											uint8 newopcode = '0';
											char * stringy = "Patch";
											uint8 stringling = strlen( stringy );
											//uint8 hash[] = { 0x7e, 0xf1, 0x34, 0x33, 0xf8, 0xd6, 0xe6, 0xc5, 0x58, 0x92, 0x72, 0x01, 0xae, 0xe8, 0x82, 0x39 };
											//uint8 hash[] = { 0x5b, 0x75, 0x24, 0x2d, 0x24, 0x5b, 0x0b, 0xa2, 0x74, 0xac, 0x92, 0xc5, 0xb3, 0xcc, 0x97, 0xfc };
											struct stat filestats;
											fstat( fileno( patchfil ), &filestats );
											uint64 filesize = filestats.st_size;
											net->sendData( 1, &newopcode );
											net->sendData( 1, &stringling );
											net->sendData( stringling, stringy );
											net->sendData( 8, &filesize );
											net->sendData( 16, mPatches[ client_version ]->Hash );
											Log::getSingleton( ).outString( "REALMLIST: Sent patch initialization" );
										}
										{
											uint8 newopcode;
											net->getData( 1, &newopcode );
											if( newopcode == '2' )
												Log::getSingleton( ).outString( "REALMLIST: Got patch acknowledgement" );
											else
												printf( "WEIRD PATCH RESPOnSE: '%c'\n", newopcode );
										}
										{
											uint8 datablock[1500];
											uint16 datalen;
											uint8 newopcode = '1';
											Log::getSingleton( ).outString( "REALMLIST: Sending patch data...." );
											while( !feof( patchfil ) && net->isConnected( ) ) {
												datalen = fread( datablock, 1, 1500, patchfil );
												net->sendData( 1, &newopcode );
												net->sendData( 2, &datalen );
												net->sendData( datalen, datablock );
											}
											Log::getSingleton( ).outString( "REALMLIST: Done sending patch data." );
										}
										fclose( patchfil );
									} else {
										Log::getSingleton( ).outString( "REALMLIST: Error -- Failed to load patch mpq!" );
									}
								} else {
									Log::getSingleton( ).outString( "REALMLIST: Error -- No patch found to satisfy client version!" );
								}
							}

							uint8 tdata[] = { 0x01, 0x09 };
							net->sendData( sizeof( tdata ) , tdata );
							Log::getSingleton( ).outString( "REALMLIST: Sent LOGON_PROOF with rejection 'bad client version'" );
							break;
						} 



						// check if username and password exist
						DatabaseInterface *dbi = Database::getSingleton( ).createDatabaseInterface( );
						switch( dbi->Login( name, "BETA3", net->getIP() ) ) {
							case -1:   // bad password
								{
									uint8 tdata[] = { 0x01, 0x07 };
									net->sendData( sizeof( tdata ) , tdata );
									Log::getSingleton( ).outString( "REALMLIST: Sent LOGON_PROOF with rejection 'prepaid time used up'" );
								}break;
							case -2:   // general failure
								{
									uint8 tdata[] = { 0x01, 0x08 };
									net->sendData( sizeof( tdata ) , tdata );
									Log::getSingleton( ).outString( "REALMLIST: Sent LOGON_PROOF with rejection 'could not log in'" );
								}break;
							case -3:   // bad username
								{
									uint8 tdata[] = { 0x01, 0x03 };
									net->sendData( sizeof( tdata ) , tdata );
									Log::getSingleton( ).outString( "REALMLIST: Sent LOGON_PROOF with rejection 'account closed'" );
								}break;
							default:
								{
									uint8 newopcode = RECONNECT_PROOF;
									uint8 newdata = 0;
									uint8 data[2] = { newopcode, newdata };
									net->sendData(2, data);
									Log::getSingleton( ).outString( "REALMLIST: Sent RECONNECT_PROOF" );
								}break;
						}
						Database::getSingleton( ).removeDatabaseInterface( dbi );


					}break;
				case LOGON_PROOF:
					{
						Log::getSingleton( ).outString( "REALMLIST: Recieved LOGON_PROOF" );
						uint8 databuf[ 16*6+7 ];
						net->getData( 16*6+7, databuf );
						for( int i = 0; i < 16*6+7; i ++ ) {
							if( i % 16 == 0 )
								printf( "\n" );
							printf( "%.2X ", databuf[i] );
						}
						printf ("\n");



	                    
						uint8 newopcode = RECONNECT_PROOF;
						uint8 newdata = 0;
						uint8 data[2] = { newopcode, newdata };
						net->sendData(2, data);
						Log::getSingleton( ).outString( "REALMLIST: Sent RECONNECT_PROOF" );

					}break;
				case RECONNECT_CHALLENGE:
					{
						Log::getSingleton( ).outString( "REALMLIST: Recieved RECONNECT_CHALLENGE" );
						uint8 unknownbyte; uint16 datalen; 
						char WoW[5];  uint8 byte1, byte2, byte3; uint16 clientversion; char x86[5];
						char Win[5]; char enUS[5]; 
						uint8 ubyte1, ubyte2; int16 int1; uint32 int2;
						uint8 namelen; char name[256];
						net->getData( 1, &unknownbyte );
						net->getData( 2, &datalen );
						net->getData( 4, WoW ); WoW[4]=0;
						net->getData( 1, &byte1 ); net->getData( 1, &byte2 ); net->getData( 1, &byte3 );
						net->getData( 2, &clientversion );
						net->getData( 4, x86 ); x86[4]=0;
						net->getData( 4, Win ); Win[4]=0;
						net->getData( 4, enUS ); enUS[4]=0;
						//net->getData( 13, preuserdata );// ARGH
						net->getData( 1, &ubyte1 ); net->getData( 1, &ubyte2 ); net->getData( 2, &int1 );
						net->getData( 4, &int2 );
						net->getData( 1, &namelen );
						net->getData( namelen, name );
						name[ namelen ] = 0;
						//printf( "Username: %s\n", name );
						std::string cib = WoW; std::reverse( cib.begin( ), cib.end( ) );
						//printf( "Game ID: %s\n", cib.c_str( ) );
						//printf( "Version: %i\n", clientversion );
						cib = x86; std::reverse( cib.begin( ), cib.end( ) );
						//printf( "Architecture: %s\n", cib.c_str( ) );
						cib = Win; std::reverse( cib.begin( ), cib.end( ) );
						//printf( "Platform: %s\n", cib.c_str( ) );
						cib = enUS; std::reverse( cib.begin( ), cib.end( ) );
						//printf( "Language: %s\n", cib.c_str( ) );
						//printf( "Unknown start byte: %i\n", unknownbyte );
						//printf( "3 game bytes: %i %i %i\n", byte1, byte2, byte3 );
						//printf( "Unknown 2 bytes: %i %i\n", ubyte1, ubyte2 );
						//printf( "Unknown 16bit int: %i\n", int1 );
						//printf( "Unknown 32bit int: %i\n", int2 );
	/*
						net->sendData( 1, &opcode );
						uint8 zerobyte = 0;
						for( int a = 0; a < 0x21; a ++ )
							net->sendData( 1, &zerobyte );
	*/
						uint8 newopcode = RECONNECT_PROOF;
						uint8 newdata = 0;
						uint8 data[2] = { newopcode, newdata };
						net->sendData(2, data);
	/*
						// I tried this first, I could get to char screen but couldnt change realmlist.
						// For shits and giggles I changed it to just send RECONNECT_PROOF and it seemed to work perfect!
						// -- DC
						uint8 data2[35];
						memset(data2, 0, 35);
						data2[0] = opcode;
						net->sendData(35, data2);                  
	*/
						Log::getSingleton( ).outString( "REALMLIST: Sent RECONNECT_CHALLENGE" );

					}break;
				case RECONNECT_PROOF:
					{
						Log::getSingleton( ).outString( "REALMLIST: Recieved RECONNECT_PROOF" );

						uint8 buf[5*16+7];
						net->getData( sizeof( buf), buf );

						uint8 newopcode = RECONNECT_PROOF;
						uint8 newdata = 0;
						uint8 data[2] = { newopcode, newdata };
						net->sendData(2, data);
	//                    net->sendData( 1, &newopcode );
	//                    net->sendData( 1, &newdata );
						Log::getSingleton( ).outString( "REALMLIST: Sent RECONNECT_PROOF" );
					}break;
				case REALMLIST:
					{
						Log::getSingleton( ).outString( "REALMLIST: Recieved REALMLIST request" );
						uint32 request; net->getData(4, &request );


						//format: uint16 datalen, uint32 request, uint8 numrealms
						//eachrealm: string name, string address, uint32 numplayers
		uint16 datalen = 7;
		RealmMap::iterator i;
		uint8 totalrealms = 0;
		for( i = mRealms.begin( ); i != mRealms.end( ); ++ i, ++totalrealms )
		datalen += i->first.length( ) + 1 + i->second->address.length( ) + 13;

			uint8 *data = new uint8[ datalen + 3 ];
			data[ 0 ] = REALMLIST;
			memcpy( data+1, &datalen, 2 );
			memcpy( data+3, &request, 4 );
			data[7]=totalrealms;
			int doo = 8;

			for( i = mRealms.begin( ); i != mRealms.end( ); ++ i ) {
				data[ doo++ ] = i->second->icon; 
				data[ doo++ ] = 0x00;
				data[ doo++ ] = 0x00;
				data[ doo++ ] = 0x00;
				data[ doo++ ] = i->second->color; 
				strcpy( (char *)data+doo, i->first.c_str( ) );
				doo+=i->first.length( )+1;
				strcpy( (char *)data+doo, i->second->address.c_str( ) );
				doo+=i->second->address.length( )+1;
				data[ doo++ ] = (uint8)(i->second->players & 255);
				data[ doo++ ] = (uint8)((i->second->players >> 8) & 255);
				data[ doo++ ] = (uint8)((i->second->players >> 16)& 255);
				data[ doo++ ] = (uint8)((i->second->players >> 24)& 255);
				data[ doo++ ] = 0x64; // ping time (fake)
				data[ doo++ ] = 0x01;
				data[ doo++ ] = 0x02;
			}
			data[ doo++ ] = 0x00;
			data[ doo++ ] = 0x00;

			net->sendData( datalen + 3, data );
			Log::getSingleton( ).outString( "REALMLIST: Sent REALMLIST" );

			delete [] data;

					}break;
				case UPDATESRV:
					{
						char buf[256];
						char *realm;
						char *count;
						string rTemp = "";
						Log::getSingleton( ).outString( "REALMLIST: Recieved UPDATESRV request" );
						net->getData( 256, buf );
						realm = strtok(buf,";");
						count = strtok(0,";");
						rTemp="";
						rTemp.append(realm);
						// 2, 2 stands for unchanged icon and color
						this->setRealm( const_cast<char *>(rTemp.c_str()), 2, 2, atoi(count) );
						
					}break;
				default:
					{
						char debugchararray[256];
						sprintf( debugchararray, "REALMLIST: Recieved unknown opcode %i", opcode );
						Log::getSingleton( ).outString( debugchararray );

					}break;
			}
		
	}
			
}

void RealmListSrv::disconnect_client(	struct nlink_client *cptr )
{
	RealmClient * pClient = static_cast < RealmClient * > ( cptr->pClient );
	mClients.erase( pClient );
	delete pClient;
	Log::getSingleton( ).outString( "REALM: Socket Closed!" );
	Server::disconnect_client( cptr );
}

