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

#ifndef WOWPYTHONSERVER_NETWORKINTERFACE_H
#define WOWPYTHONSERVER_NETWORKINTERFACE_H

//#include "Common.h"

#include "Database.h"
#include "Sockets.h" //LINA ADD

class packet {
protected:
  uint16 length;
  int8 * data;
  uint16 datapointer;
  packet( ) : data( 0 ) { clear( ); }
  virtual void Serialise( ) { }
  virtual void Deserialise( ) { }
  void clear( ) { if( data ) delete [] data; data = 0; length = datapointer = 0; }
  void Deserialise( uint16 *val ) {
    *val = ( data[ datapointer ] << 8 ) + data[ datapointer + 1 ];
    datapointer += 2;
  }
  void Deserialise( uint32 *val ) {
    *val = ( data[ datapointer ] << 24 ) + ( data[ datapointer ] << 16 ) + ( data[ datapointer ] << 8 ) + data[ datapointer ];
    datapointer += 4;
  }
  void Serialise( uint16 val ) {
    data[ datapointer++ ] = int8 ( val >> 8 );
    data[ datapointer++ ] = int8 ( val % 0xff );
  }
  ~packet( ) { clear( ); }
};

struct wowWData {
  uint16 length, pointer;
  uint16 opcode;
  uint8 * data;

  /// Constructor
  wowWData( ):data( 0 ), length( 0 ), opcode( 0 ), pointer( 0 ) { }

  /// Destructor
  ~wowWData( ) {
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
  
  template < class type > inline wowWData & operator<<( const type &newData  ) {
    writeData( newData );
    return *this;
  }
  template < class type > inline wowWData & operator>>( type &newData ) {
    readData( newData );
    return *this;
  }
  
  inline wowWData & operator<<( const char * newData ) {
    writeData( newData );
    return *this;
  }
  inline wowWData & operator>>( char * newData ) {
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

struct wowLData {
  uint16 length;
  uint8 * data;
  enum packetType { Login = 2, Validate = 3, Realmlist = 0x10 } type;
  uint8 *string1;
  uint16 ushort1,ushort2;
  wowLData( ):data( 0 ), length( 0 ), string1( 0 ) { }
  ~wowLData( ) {
    clear( );
  }
  void clear( ) {
    if( data )
      delete [] data;
    data = 0;
    if( string1 )
      delete [] string1;
    string1 = 0;
  }
  void Parse( );
};

/// NetworkInterface == socket object
class NetworkInterface {
  friend class Network;
public:
  const uint8 * fillRecvQ( );
  void sendWData( wowWData *data );
  //void getLData( wowLData *data );
  //void sendLData( wowLData *data );
  void sendData( int length, const void * data );
  void getData( int length, void *data );

  int getSendqLen() { return sendqlen; }
  int getRecvqLen() { return recvqlen; }
  void * customData;

  /// Get a connected network interface if one exists
  NetworkInterface * getConnection( );

  /// Is this socket still connected?
  bool isConnected( ) const;
  uint32 getSocketID() { return mSocketID; }

  uint8 * getSendq() { return sendq; }
  uint8 * getRecvq() { return recvq; }

  void NullSendq() {
	  sendqlen = 0;
	  sendq[0] = 0;
  }
  void NullRecvq() {
	  recvqlen = 0;
	  recvq[0] = 0;
  }

  void updateSendq(uint32 written);
  uint32 sendPendingSendq();

  inline char * getIP() {return inet_ntoa( ((SOCKADDR_IN*)internalAddress)->sin_addr); }//LINA ADD FOR @BAN COMMAND

private:
  /// Private constructor & destructor, only createable via Network
  NetworkInterface( );
  ~NetworkInterface( );

  //RecvQ and SendQ
  uint8 * recvq;
  uint8 * sendq;

  //RecvQ and SendQ sizes
  int recvqlen;
  int sendqlen;
  
  //RecvQ and SendQ max size
  int recvqmax;
  int sendqmax;

  /// Handle to the socket represented by this class
  uint32 mSocketID;
  
  /// Network address of the socket
  void * internalAddress;

  /// Internal function to send raw data
  void _NIsend( const void *data, int length );
  void _NIWsend( unsigned char * data, int length );
  /// Internal function to recieve raw data
  void _NIrecv( void *data, int length );

  /// Number of extra threads using this socket
  int amountUsed;

  /// Is this socket still connected?
  bool mConnected;

  /// Is this socket about to removed?
  bool pleasekillme;

  /// Callback function on connect
  void ( * mCallback ) ( NetworkInterface * );

  /// Current error code
  uint32 Ncerr;

  /// How many threads are waiting to recieve or send a packet?
  uint32 mRecvWaiting, mSendWaiting;

  /// How many threads are currently sending or recieving a packet? (should never be over 1!)
  uint32 mRecieving, mSending;
};

#endif
