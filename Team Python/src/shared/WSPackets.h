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

#ifndef WOWPYTHONSERVER_WSPACKETS_H
#define WOWPYTHONSERVER_WSPACKETS_H

#include "NetworkInterface.h"

/*
0x01DF CMSG_AUTH_SESSION 
Int32 Client version 
Int32 Session ID 
String Username 
Int32 Client salt 
Byte[20] Encrypted password 
*/

class WSPacket : public packet {
  uint16 opcode;
  void Serialise( ) {
  }
  void Deserialise( ) {
  }
}


/*#define WSPACKET_PACKETNAMES ( prefix, midfix, postfix )  \
  prefix##CMSG_AUTH_SESSION##midfix 0x01df postfix \

#define WSPACKET_PACKETCONTENTS ( prefix, prepfix, tweenfix, twockfix, twiddlefix, postfix ) \
  prefix CMSG_AUTH_SESSION prepfix \
    Int32 tweenfix##Client version##twockfix 1 twiddlefix \
    Int32 tweenfix##Session ID##twockfix 1 twiddlefix \
    String tweenfix##Username##twockfix 1 twiddlefix \
    Int32 tweenfix##Client salt##twockfix 1 twiddlefix \
    Byte tweenfix##Encrypted Password##twockfix 20 postfix \


class WSPacket : public packet {
protected:
  enum packetType {
    WSPACKET_PACKETNAMES( , = , MACRO_COMMA )
    //CMSG_AUTH_SESSION = 0x01df,
  } opcode;

  WSPacket( uint32 opcode ) : opcode( opcode ) { }

  enum itemType { Int32, String, Byte };

  std::list < item * > items;

  void Serialise( ) {
    switch( opcode ) {
      WSPACKET_PACKETCONTENTS( case, :
          items.push_back MACRO_OPENPAREN , MACRO_COMMA MACRO_DOUBLEQUOTE , MACRO_DOUBLEQUOTE MACRO_COMMA , MACRO_CLOSEPAREN ;
          items.push_back MACRO_OPENPAREN , MACRO_CLOSEPAREN ;
          break; )
      );
    }
  }

  void Deserialise( ) {

  }

  void clearItems( ) {
    for( std::list< item * >::iterator i = items.begin( ); i != items.end( ); ++ i )
      delete (item *)*i;
    items.clear( );
  }

  struct item {
    itemType type;
    void * data;
    std::string name;
    item( itemType type, char * name, int parameter ) : type( type ), name( name ) {
      switch( type ) {
        case Int32:
          data = new int32;
          break;
        case String:
          data = new std::string;
          break;
        case Bytes:
          data = new uint8[ parameter ];
          break;
      }
    }
    ~item( itemType type, inte parameter ) : type( type ) {
      switch( type ) {
        case Int32:
          delete ( int32 * ) data;
          break;
        case String:
          delete ( std::string * ) data;
          break;
        case Bytes:
          delete ( uint8 * ) data;
          break;
      }
    }
  };
};


class packet_CMSG_AUTH_SESSION : public WSPacket {
public:
  packet_CMSG_AUTH_SESSION(  ): WSPacket( 0x1df ) { }
private:
  
}*/

#endif
