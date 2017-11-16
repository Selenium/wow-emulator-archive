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

#include "NetworkInterface.h"
#include "Sockets.h"
#include "Network.h"
#include <errno.h>

#define char2short(ch)  (*(ch)<<8)+*(ch+1)
#define RECVQEXCEED 131070//131070
#define SENDQEXCEED 131070//131070

void wowLData::Parse( ) {
    if( !length )
        return;
    type = (packetType) data[ 0 ];
    switch( type ) {
    case Login:
        ushort1 = char2short(data+1);
        ushort2 = char2short(data+3);
        string1 = new uint8[ushort2+1];
        strncpy( (char *) string1, (char *) data+5, ushort2 );
        string1[ ushort2 ] =0;
        break;
    }
}

NetworkInterface::NetworkInterface( ) {
	amountUsed = 0;
	pleasekillme = false;
	internalAddress = 0;
	mCallback = 0;
	mConnected = true;
	mRecvWaiting = 0;
	mSendWaiting = 0;
	mRecieving = 0;
	mSending = 0;
	sendqlen = 0;
	recvqlen = 0;
	sendqmax = 2048;
	recvqmax = 2048;
	sendq = (unsigned char *)malloc(sendqmax * sizeof(char));
	recvq = (unsigned char *)malloc(recvqmax * sizeof(char));
}

bool NetworkInterface::isConnected( ) const { 
    return mConnected; 
}

NetworkInterface::~NetworkInterface( ) 
{
    /// Inform all users that suicide is our goal
    pleasekillme = true;
    mConnected = false;

    /// Wait until everybody's done with this socket
    while( amountUsed );

    /// Close socket if needed
    if( mSocketID )
        closesocket( mSocketID );
    mSocketID = 0;

    /// Deallocate address if needed
    if( internalAddress ) delete ( SOCKADDR_IN * ) internalAddress;
}

NetworkInterface * NetworkInterface::getConnection( ) {
    SOCKLEN_T tempLen = sizeof( SOCKADDR_IN );
    SOCKADDR_IN tempAddr;
    uint32 tempSocket = ( uint32 ) accept( mSocketID, ( struct sockaddr * ) &tempAddr, &tempLen );
    if( tempSocket == SOCKET_ERROR && SOCK_LASTERR == SOCKERR(WOULDBLOCK) ) return NULL;
	
	//START OF LINA FIREWALL COMMAND PATCH
	DatabaseInterface *dbi = Database::getSingleton( ).createDatabaseInterface( );
	switch( dbi->Firewall(inet_ntoa(tempAddr.sin_addr)) )
	{
		case 3:
			printf("IP: %s FIREWALL OFF.\n",inet_ntoa(tempAddr.sin_addr));
			break;

		case 2:
			printf("IP: %s BANNED.\n",inet_ntoa(tempAddr.sin_addr));
			closesocket(tempSocket);
			return NULL;
			break;

		case 1:
			printf("IP: %s ACCEPTED.\n",inet_ntoa(tempAddr.sin_addr));
			break;

		case 0:
			printf("IP: %s NOT FOUND.\n",inet_ntoa(tempAddr.sin_addr));
			closesocket(tempSocket);
			return NULL;
			break;

		default:
			printf("IP: %s IMPOSSIBLE DISCONNECTED.\n",inet_ntoa(tempAddr.sin_addr));
			closesocket(tempSocket);
			return NULL;
			break;
	}
	Database::getSingleton( ).removeDatabaseInterface(dbi);
	//START OF LINA FIREWALL COMMAND PATCH

    Log::getSingleton( ).outString( "NETWORK: accepted connection" );
    NAssertRP( tempSocket );
    NetworkInterface * tempNI = new NetworkInterface( );
    tempNI->internalAddress = new SOCKADDR_IN( tempAddr );
    tempNI->mSocketID = tempSocket;
    Network::getSingleton( ).mInterfaces.insert( tempNI );
    return tempNI;
}

/*void NetworkInterface::getLData( wowLData * data ) {
    data->clear( );
    uint8 b1, b2;
    _NIrecv( &b1, 1 );
    _NIrecv( &b2, 1 );
    data->length = (b1<<8)+b2;
    WPAssert( data->length >= 0 );
    if( data->length == 0 ) return;
    data->data = new uint8[ data->length ];
    _NIrecv( data->data, data->length );
    data->Parse( );
}

void NetworkInterface::sendLData( wowLData * data ) {
    uint8 b1, b2;
    b1 = data->length >> 8;
    b2 = data->length & 255;
    _NIsend( &b1, 1 );
    _NIsend( &b2, 1 );
    _NIsend( data->data, data->length );
}
*/

const uint8 * NetworkInterface::fillRecvQ() {
// I need more tests on huge servers with many players. r-o-n-n-y
	int templen;
	if (!isConnected())
		return NULL;

	int repeatit = 1;
	while (repeatit == 1)
	{
		repeatit = 0;

		NAssertRP( templen = recv(mSocketID, (char *)(recvq + recvqlen), recvqmax - recvqlen, 0) );
		if (templen == -1)
		{
			WPAssert(SOCK_LASTERR != SOCKERR(WOULDBLOCK));
		} else {
			if( !templen )
			{ 
				mConnected = false; 
				return NULL; 
			}
			if (templen == recvqmax)
			{
				repeatit = 1;
				recvq = (unsigned char *)realloc(recvq, 2 * recvqmax);
				recvqmax = 2 * recvqmax;
				if (recvqmax >= RECVQEXCEED) { //a nasty way to handle this :(
					printf("NETWORK: Overflow RECVQEXCEED\n");
					mConnected = false;
					return NULL;
				}
			} else {
				if (isConnected()) {
					recvqlen += templen;
				} else { 
					return NULL; 
				}
			}
		}
	}
	return recvq;
}

uint32 NetworkInterface::sendPendingSendq() {
	int status;
	uint32 written = 0;
	while(( written < uint32(getSendqLen())) && mConnected) {
		status = send(mSocketID,(char *)sendq + written, getSendqLen() - written, 0);
		if( !status ) {
			mConnected = false;
			break;
		}
		if( status == SOCKET_ERROR ) {
			if (SOCK_LASTERR == SOCKERR(WOULDBLOCK)) {
				return written;
			}
			else {
				mConnected = false;
				break;
			}
		}
		else {
			written += status;
		}
	}
	return written;
}

void NetworkInterface::updateSendq(uint32 written) {
	uint32 j;
	for(j = 0; j < sendqlen - written; j++)
	{
		*(sendq + j) = *(sendq + j + written);
	}
	sendqlen -= written;
}
void NetworkInterface::sendWData( wowWData * data ) {

	if (!isConnected())
		return;
    uint8 b[4];
    int packet_length = data->length + 2; 
    //Why did someone put this assert?
    //Sometime we need to sent more than 256 bytes
    //assert( packet_length < 256 );
    //I added an assert( packet_length < 65536 ); instead
    //assert( packet_length < 65536 );
    //data->length is a uint16 so that assert is never hit
    //I added the original assert to catch data corruption
    //changed to the following:
    assert( data->opcode >= 0 );
    //Munky - Blizzard went over 250 with the latest beta 3 patch (Auctions, etc.)

    // Log!
    if (Network::getSingleton().IsLoggingWorld())
	{
        FILE *pFile;
        pFile = fopen("packetlog.txt", "a");
        fprintf(pFile, "SERVER:\nSOCKET: %d\nLENGTH: %d\nOPCODE: %.4X\nDATA:\n", mSocketID, packet_length, data->opcode);
        int p=0;
        while (p < data->length) 
		{
            for (int j=0; j < 16 && p < data->length; j++)
               fprintf(pFile, "%.2X ", data->data[p++]);
            fprintf(pFile, "\n");
        }
        fprintf(pFile, "\n\n");
        fclose(pFile);
    }

    b[0] = packet_length >> 8;
    b[1] = packet_length & 255;
    _NIWsend( b, 2 );
	
	/*
    b[3] = uint8( data->opcode >> 24 );
    b[2] = uint8( ( data->opcode >> 16 ) & 255 );
    b[1] = uint8( ( data->opcode >> 8 ) & 255 );
    b[0] = uint8( data->opcode & 255 );
    _NIWsend( b, 4 );
	*/
	
	b[1] = uint8( ( data->opcode >> 8 ) & 255 );
    b[0] = uint8( data->opcode & 255 );
    _NIWsend( b, 2 );
	
    _NIWsend( data->data, data->length );

}

void NetworkInterface::sendData( int length, const void *data ) 
{
    _NIsend( data, length );
}

void NetworkInterface::getData( int length, void *data ) 
{
    _NIrecv( data, length );
}


void NetworkInterface::_NIsend( const void * data, int length ) 
{
    WPAssert( data != 0 );
    int status, clength = 0;
    while( (clength < length) & mConnected) 
	{
        NAssert( status = send( mSocketID, (char *)data + clength, length - clength, 0 ) );
        if( !status ) mConnected = false;
        if( status != SOCKET_ERROR )
            clength += status;
    }
}


void NetworkInterface::_NIWsend( unsigned char * data, int length ) 
{
    //WPAssert( data != 0 );
    int i;
	if (length == 0)
		return;

	while(length + sendqlen >= sendqmax)
	{
		sendqmax = sendqmax * 2;
		if (sendqmax > SENDQEXCEED)
		{
			sendqmax = SENDQEXCEED;
			while(length + sendqlen >= SENDQEXCEED)
			{
				uint32 status;
				status = sendPendingSendq();
				if (!mConnected) 
				{
					return;
				}
				updateSendq(status);
			}
		}
		sendq = (unsigned char *)realloc(sendq, sendqmax);
	}
	
	for(i = 0; i < length; i++)
	{
		*(sendq + sendqlen + i) = (char)data[i];
	}
	sendqlen += length;
}

void NetworkInterface::_NIrecv( void * data, int length ) 
{
    WPAssert( data != 0 );
    int status, clength = 0;
    while( ( clength < length ) && mConnected )
	{
        NAssert( status = recv( mSocketID, (char *)data + clength, length - clength, 0 ) );
        if( !status) mConnected = false;
		if( status != SOCKET_ERROR )
            clength += status;
	}
}
