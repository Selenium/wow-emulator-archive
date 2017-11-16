/*
   Copyright (C) 2004 Team Python
   Copyright (C) 2005 Team OpenWoW
   Copyright (C) 2006 Team Evolution

   This program is free software; you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation; either version 2 of the License, or
   (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program; if not, write to the Free Software
   Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.
*/

#ifndef __NETWORKINTERFACE_H__
#define __NETWORKINTERFACE_H__

//#include "Base.h"
#include "Sockets.h"
#include "SrpWorld.h"
#include "constants.h"

#define Packet_Standard_Size 32000 //32K aprox wow
#define SIZE_OF_PACKET_HEADER 6 //

class NetworkPacket
{
public:
   uint32 opcode;
   uint8 *buffer;//data is after the buffer start
   union
   {
		uint8 *data;
		uint32 *data32;
		uint64 *data64;
		float *dataf;
   };
   uint length,top,max_length;
   /// Constructor
   NetworkPacket ()
   {
		opcode=0;
		buffer = (uint8*)malloc(Packet_Standard_Size);
        data = buffer + SIZE_OF_PACKET_HEADER; //6 bytes is the opcode when we read it from socket. 2 extra bytes for future
		max_length = Packet_Standard_Size;
		length=0;
		top=0;
   }
   /// Destructor
   ~NetworkPacket ()
   { 
       delete buffer;
	   data = NULL;
   }
	//incase our send buffer is too small, we have to resize it to be able to fit all data
   inline uint8 resize_if_too_small(uint newlength)
   {
	   if(max_length<newlength)
	   {
		 max_length = 2*max_length;
 		 buffer = (uint8 *)realloc(buffer, max_length);
 		 data = buffer + SIZE_OF_PACKET_HEADER;
		 data32 = (uint32*)data;
 		 data64 = (uint64*)data;
    	 dataf = (float*)data;
		 return 1;
	   }
	   else return 0;
   }
   ////////////////////////////////////////////////////////////////////////////////////////
   //								Noob proof system									 //
   ////////////////////////////////////////////////////////////////////////////////////////
   inline void Initialize(uint32 p_opcode){opcode = p_opcode;length=0;}
   template < class type > inline NetworkPacket & operator<< (const type &newData)
   {
		memcpy (data + length, newData, sizeof(type));
		length += sizeof(type);
		return *this;
   }
   inline NetworkPacket & operator<< (const char * newData)
   {
		uint32 tlen=strlen(newData)+1;
		memcpy(data+length,newData,tlen);
		length+=tlen;
		return *this;
   }
};

struct WowData {
  uint16 length, pointer;
  uint32 opcode;
  uint8 * data;

  /// Constructor
 WowData( ):data( 0 ), length( 0 ), opcode( 0 ), pointer( 0 ) { }

  /// Destructor
  ~WowData( ) {
    clear( );
  }

  /// Clear packet and set length and opcode all in one mighty blow
  void Initialise( uint16 newLength, uint16 newOpcode ) {
    setLength( newLength );
    opcode = newOpcode;
  }

  void setLength( uint16 newlength )
  {
    if( (newlength > length) | (data==0) ) {
        clear( );
        data = new uint8[newlength];
    } else {
        pointer = 0; opcode = 0;
    }
    length=newlength;
  }
  void clear( ) {
    if( data )
      delete [] data;
    data = 0;
    length = pointer = 0;
    opcode = 0;
  }

  inline uint8 * getDataPointer( ) const { return data + pointer; }
  
  template < class type > inline WowData & operator<<( const type &newData  ) {
    writeData( newData );
    return *this;
  }
  template < class type > inline WowData & operator>>( type &newData ) {
    readData( newData );
    return *this;
  }
  
  inline WowData & operator<<( const char * newData ) {
    writeData( newData );
    return *this;
  }
  inline WowData & operator>>( char * newData ) {
    readData( newData );
    return *this;
  }
  
  inline uint16 & writeData( const void * newData, const uint16 datalength ) {
    return pointer = writeDataAt( pointer, newData, datalength );
  }
  inline uint16 & readData( void * newData, const uint16 datalength ) {
    return pointer = readDataAt( pointer, newData, datalength );
  }

  template < class type > inline uint16 & writeData( const type &newData ) {
    return pointer = writeDataAt( pointer, newData );
  }
  template < class type > inline uint16 & readData( type &newData ) {
    return pointer = readDataAt( pointer, newData );
  }

  inline uint16 & writeData( const char * newData ) {
    return pointer = writeDataAt( pointer, newData );
  }
  inline uint16 & readData( char * newData ) {
    return pointer = readDataAt( pointer, newData );
  }

  inline uint16 writeDataAt( const uint16 offset, const char * newData ) {
    uint16 dlen = strlen( newData ) + 1; // + 1 i.e. also write the trailing 0x00
    WPAssert( offset + dlen <= length );
    memcpy( data + offset, newData, dlen );
    return offset + dlen;
  }
  inline uint16 readDataAt( const uint16 offset, char * newData ) {
    // this method shouldn't really be used, too much danger of buffer overflow
    uint16 dlen = strlen( (char *)data + offset ) + 1; 
    WPAssert( offset + dlen <= length );
    memcpy( newData, data + offset, dlen );
    return offset + dlen;
  }

  template < class type > inline uint16 writeDataAt( const uint16 offset, const type &newData ) {
    WPAssert( offset + sizeof( type ) <= length );
    memcpy( data + offset, &newData, sizeof( type ) );
    return offset + sizeof( type );
  }
  template < class type > inline uint16 readDataAt( const uint16 offset, type &newData ) const {
    // if you die at this assert whilst reading a char array you may have forgotten to typecast it to a (char *); however, note that std::string's are much safer than char arrays.
    WPAssert( offset + sizeof( type ) <= length );
    memcpy( &newData, data + offset, sizeof( type ) );
    return offset + sizeof( type );
  }

  inline uint16 writeDataAt( const uint16 offset, const std::string &newData ) {
    uint16 dlen = newData.length( ) + 1; // trailing zero is included
    WPAssert( offset + dlen <= length );
    memcpy( data + offset, newData.c_str( ), dlen );
    return offset + dlen;
  }
  inline uint16 readDataAt( const uint16 offset, std::string &newData ) {
    newData = (char *) data + offset;
    uint16 dlen = newData.length( ) + 1;
    WPAssert( offset + dlen <= length );
    return offset + dlen;
  }
  
  inline uint16 writeDataAt( const uint16 offset, const void * newData, const uint16 datalength ) {
    WPAssert( offset + datalength <= length );
    memcpy( data + offset, newData, datalength );
    return offset + datalength;
  }
  inline uint16 readDataAt( const uint16 offset, void * newData, const uint16 datalength ) const {
    WPAssert( offset + datalength <= length );
    memcpy( newData, data + offset, datalength );
    return offset + datalength;
  }
};



/**
 * This class is used to encapsulate socket objects
 */
class Socket
{
   /// Handle of the socket encapsulated in this object
   socket_t handle;
   /// Network address of the socket
   sockaddr_in inaddr;
   /// Internal function to send raw data
   void _NIsend (const void *data, int length);
   /// Is this socket still connected?
   bool mConnected;
   /// Callback function on connect
   void (* mCallback) (Socket *);
   /// Private constructor & destructor, only createable via Network
   Socket (socket_t sh, sockaddr_in *sa);
   ~Socket ();
   friend class Network;
public:
   uint32 fillRecvQ(uint8 *buffer,uint32 max_buffer_len);
   void sendWData (NetworkPacket *data, SrpWorld* srp);
   void sendData (WowData *data, SrpWorld* srp);
   /// Accept an incoming connection request if one exists
   Socket *AcceptConnection ();
   /// Is this socket still connected?
   bool isConnected () const;
   socket_t GetHandle () { return handle; }
   inline char * getIP ()
   { return inet_ntoa (inaddr.sin_addr); }
#ifdef _DEBUG
	uint32	can_send_after_stamp;
#endif
};

#endif // __NETWORKINTERFACE_H__
