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

#include "Object.h"
#include "NetworkInterface.h"
#include "Opcodes.h"
#include "UpdateMask.h"
#include "Log.h"
#include "Character.h"
#include "WorldServer.h"

#include <time.h> // should be removed from here
#include "math.h"

Object::Object( )
{
    m_objectTypeId = 0;
    m_objectType = TYPE_OBJECT;

    clearUpdateMask();

    m_positionX = 0.0f;
    m_positionY = 0.0f;
    m_positionZ = 0.0f;
    m_orientation = 0.0f;

    m_zoneId = 0;
    m_mapId = 0;

//    m_lastUpdateTime = 0;
    m_minZ = -500;
//    m_maxHorizontalSpeed = 16;

    m_guid = m_updateValues;

    memset( m_updateValues, 0, sizeof( m_updateValues ) );
}


Object::~Object( )
{

}

void Object::Create( uint32 guidlow )
{
    m_guid[0] = guidlow;
    m_guid[1] = 0;

    setUpdateFloatValue( OBJECT_FIELD_SCALE_X, 1.0 );
    setUpdateValue( OBJECT_FIELD_GUID, m_guid[0] );
    setUpdateValue( OBJECT_FIELD_GUID+1, m_guid[1] );
    setUpdateValue( OBJECT_FIELD_TYPE, m_objectType );
}

void Object::Create(uint32 guidlow, float x, float y, float z, float ang)
{
    m_guid[0] = guidlow;
    m_guid[1] = 0;

    m_zoneId = 0;
    m_mapId = 0;

    m_positionX = x;
    m_positionY = y;
    m_positionZ = z;
    m_orientation= ang;
	
	// <WoW Chile Dev Team> Start Change
    respawn_cord[0][0] = x;
    respawn_cord[0][1] = y;
    respawn_cord[0][2] = z;
	// <WoW Chile Dev Team> Finish Change

    setUpdateFloatValue( OBJECT_FIELD_SCALE_X, 1.0 );
    setUpdateValue( OBJECT_FIELD_GUID, m_guid[0] );
    setUpdateValue( OBJECT_FIELD_GUID+1, m_guid[1] );
    setUpdateValue( OBJECT_FIELD_TYPE, m_objectType );
}


bool Object::setPosition( uint8 * data, bool allowPorting ) {
    return setPosition( ((float *) data)[0], ((float *) data)[1], ((float * ) data)[2], ((float * ) data)[3], allowPorting );
}

void Object::getPosition( uint8 * data ) const {
    ((float *) data)[ 0 ] = getPositionX( );
    ((float *) data)[ 1 ] = getPositionY( );
    ((float *) data)[ 2 ] = getPositionZ( );
    ((float *) data)[ 3 ] = getOrientation( );
}

bool Object::setPosition( float newX, float newY, float newZ, float newOrientation, bool allowPorting ) {
    if( allowPorting ) {
//        m_lastUpdateTime = (float) clock( ) / CLOCKS_PER_SEC;
        m_positionX = newX;
        m_positionY = newY;                 
        m_positionZ = newZ;        
        //    char f[256];
        //    sprintf( f, "setPosition: %f, %f, %f, %f", m_positionX, m_positionY, m_positionZ, m_orientation );
        //    Log::getSingleton( ).outString( f );
        return true;
    } else {
//        float timedif = (float) clock( ) / CLOCKS_PER_SEC - m_lastUpdateTime;
//        if( timedif < 0 ) timedif = 0;
//        float xD = newX - m_positionX;
//        float yD = newY - m_positionY;
//        float zD = newZ - m_positionZ;
//        float totalD = (float)sqrt( xD*xD + yD*yD );
//        float horizspeed = totalD / timedif;
//        m_lastUpdateTime += timedif;
        m_orientation = newOrientation;
        if( newZ < m_minZ ) {
            // This works now
            m_positionX = newX;
            m_positionY = newY;                 
            m_positionZ = 500;
            Log::getSingleton( ).outString( "setPosition: fell through map; height ported" );
            return false;
        } /*else if( horizspeed > m_maxHorizontalSpeed && ( timedif >= 0.5 || totalD > 100 ) ) {
          // this doesn't work, the speed is almost never calculated rightly it seems =S
          float multiplier = m_maxHorizontalSpeed / horizspeed;
          m_positionX += xD * multiplier;
          m_positionY += yD * multiplier;
          m_positionZ += zD * multiplier;
          Log::getSingleton( ).outString( "setPosition: speed capped" );
          return false;
          } */else {
        m_positionX = newX;
        m_positionY = newY;                 
        m_positionZ = newZ;        
        //      char f[256];
        //      sprintf( f, "setPosition: %f, %f, %f, %f; speed = %f; minZ = %f", m_positionX, m_positionY, m_positionZ, m_orientation, horizspeed, m_minZ );
        //      Log::getSingleton( ).outString( f );
        return true;
          }
          return false;
    }
}

float Object::getPositionX( ) const { return m_positionX; }
float Object::getPositionY( ) const { return m_positionY; }
float Object::getPositionZ( ) const { return m_positionZ; }
float Object::getOrientation( ) const { return m_orientation; }


void Object::CreateObject( uint32 flags, GameClient * pClient )
{
    wowWData data,fdata;

    data.Initialise( 1000, SMSG_UPDATE_OBJECT ); 

    data << uint32( 1 ); // 1 update
    data << uint8( 0 );
    data << uint8( 2 ); // update type == creation

    // object GUID        
    data << m_guid[ 0 ] << m_guid[ 1 ];

    data << getObjectTypeId( ); // object type

    // build and add the movement update portion of the packet
    uint8 pData[300];
    int length=0;
    BuildMoveUpdate(0x00000000, 0x00000000, (uint8*)pData, &length);
    data.writeData( pData, length );

    data << flags; // 4 byte flags, 1 == active player

    data << uint32( 1 ); // uint32 attack cycle
    data << uint32( 0 ); // uint32 timer id

    data << uint64( 0 ); // GUID victim

    // add the update mask data to the packet
    data << m_updateMaskBlockCount;
    data.writeData( m_updateMask, m_updateMaskBlockCount << 2 );

    for( uint16 index = 0; index < uint16(m_updateMaskBlockCount) << 5; index ++ )
        if( unsetUpdateMaskBit( index ) )
            data << m_updateValues[ index ];

    // create the actual packet, now that we know the length ( data.pointer is the length written )
    fdata.Initialise( data.pointer, SMSG_UPDATE_OBJECT ); //0xA9
    fdata.writeData( data.data, data.pointer );
    //memcpy( p_data->data, data.data, data.pointer );

    SendMessageToSet(&data, true);
//    WorldServer::getSingleton( ).SendZoneMessage(&fdata, pClient, 1);

    m_updateMaskBlockCount = 0;
    m_updateMaskSum = 0;
}

void Object::UpdateObject( GameClient * pSelf ) 
{
    if( m_updateMaskSum == 0) return;

    if (m_objectTypeId == 3) m_updateMaskBlockCount = UNIT_BLOCKS;
    if (m_objectTypeId == 4) m_updateMaskBlockCount = PLAYER_BLOCKS;

    wowWData data;
    data.Initialise( ((m_updateMaskSum+m_updateMaskBlockCount)<<2) + 15, SMSG_UPDATE_OBJECT );
    data << uint32( 1 ); // 1 update
    data << uint8( 0 );
    data << uint8( 0 ); // partial update
    data << m_guid[ 0 ] << m_guid[ 1 ];
    data << m_updateMaskBlockCount;
    data.writeData( m_updateMask, m_updateMaskBlockCount << 2 );

    for( uint16 index = 0; index < uint16(m_updateMaskBlockCount) << 5; index ++ )
        if( unsetUpdateMaskBit( index ) ){
            assert(m_updateValues[index] != 0x7FFFFFFF);
            data << m_updateValues[ index ];
        }

    m_updateMaskBlockCount = 0;
    m_updateMaskSum = 0;

    SendMessageToSet(&data, true);

/*
    if( pSelf )
        WorldServer::getSingleton( ).SendZoneMessage(&data, pSelf, 0);
    else
	{
        WorldServer::getSingleton( ).SendUnitZoneMessage(&data, m_zoneId , m_mapId);
	}
*/
}

void Object::UpdateObject(UpdateMask* updateMask, wowWData * p_data)
{
    wowWData data;
    uint8 b = 0;

    data.clear( );
    data.setLength(1000); // temp, huge storage...we find out exact data by end of this funct
    data.opcode		=	SMSG_UPDATE_OBJECT; //0xA9
    data.data[b++]	=	0x01; // 1 update
    data.data[b++]	=	0x00;
    data.data[b++]	=	0x00;
    data.data[b++]	=	0x00;
    data.data[b++]	=	0x00; // extra byte
    data.data[b++]	=	0x00; // update type == partial update

    // object GUID
    uint32 guid    =	getGUID( );
    memcpy( data.data + b, &guid, 4 );
    b+=4;
    guid = m_guid[1];
    memcpy( data.data + b, &guid, 4 );
    b+=4;


    // add the update mask data to the packet
    data.data[b++] = updateMask->count;
    memcpy(data.data+b, updateMask->updateMask, updateMask->length);
    b+=updateMask->length;

    // build the update block and add to the packet
    int length = 0;
    uint8 pUpdateData[300];
    BuildUpdateBlock(updateMask, (uint8*)pUpdateData, &length);
    memcpy(data.data+b, pUpdateData, length);
    b+=length;

    p_data->clear();
    p_data->setLength(b);
    p_data->opcode = SMSG_UPDATE_OBJECT; //0xA9
    memcpy(p_data->data, data.data, b);
    data.clear();	
}


void Object::UpdateMovement(uint32 flags, wowWData * p_data)
{
    wowWData t_data;  // temp storage
    t_data.clear( );
    t_data.setLength(110);
    t_data.opcode = SMSG_UPDATE_OBJECT; //0xA9 ^^
    t_data.data[0] = 0x01; // 1 update
    t_data.data[1] = 0x00;
    t_data.data[2] = 0x00;
    t_data.data[3] = 0x00;
    t_data.data[4] = 0x00; // extra byte
    t_data.data[5] = 0x01; // update type

    int b = 6, b2 = 0;
    uint32 flags2 = 0x00000000;
    char * guid = (char *)&getGUID( );

    memcpy( t_data.data + b, guid, 4 ); // object GUID
    b+=4;
    memcpy( t_data.data + b, m_guid+1, 4 );
    b+=4;


    uint8 pMoveblock[80];
    int length = 0; // filled in my BuildMoveUpdate()
    BuildMoveUpdate(flags, flags2, pMoveblock, &length);
    memcpy(t_data.data+b, pMoveblock, length);
    b+=length;

    // build final packet

    p_data->clear( );
    p_data->setLength(b);
    p_data->opcode = SMSG_UPDATE_OBJECT; //0xA9 ^^
    memcpy(p_data->data, t_data.data, b);
}


void Object::CreateObject(UpdateMask* updateMask, wowWData * p_data, uint32 flags)
{
    wowWData data;

    //data.opcode		=	SMSG_UPDATE_OBJECT; //0xA9
    data.Initialise( 1000, SMSG_UPDATE_OBJECT ); // temp, huge storage...we find out exact data by end of this funct

    data << uint32(1); // 1 update
    data << uint8(0);
    data << uint8(2); // update type == creation

    // object GUID        
    data << m_guid[0] << m_guid[1] ;

    data << getObjectTypeId( ); // object type

    // build and add the movement update portion of the packet
    uint8 pData[1000];
    int length=0;
    BuildMoveUpdate(0x00000000, 0x00000000, (uint8*)pData, &length);
    data.writeData( pData, length );

    data << flags; // 4 byte flags, 1 == active player

    data << uint32( 0 ); // uint32 attack cycle
    data << uint32( 0 ); // uint32 timer id

    data << uint64( 0 ); // GUID victim


    // add the update mask data to the packet
    data << updateMask->count;
    data.writeData( updateMask->updateMask, updateMask->length );
    // build the update block and add to the packet
    length = 0;
    uint8 pUpdateData[1000];
    BuildUpdateBlock(updateMask, (uint8*)pUpdateData, &length);
    data.writeData( pUpdateData, length );
    // create the actual packet, now that we know the length ( data.pointer is the length written )
    p_data->Initialise( data.pointer, SMSG_UPDATE_OBJECT ); //0xA9
    p_data->writeData( data.data, data.pointer );
    //memcpy( p_data->data, data.data, data.pointer );
}



////////////////////////////////////////////////////////////////////////////////
//  Fill the object's Update Values from a space deliminated list of values.
////////////////////////////////////////////////////////////////////////////////
void Object::LoadUpdateValues(uint8* data)
{
    char* next = strtok((char*)data, " ");
    m_updateValues[0] = atol(next);
    for( uint16 index = 1; index < OBJECT_END; index++)
    {
        char* next = strtok(NULL, " ");
        m_updateValues[index] = atol(next);
    }
}


////////////////////////////////////////////////////////////////////////////////
//  Build the Movement Data portion of the update packet
//  Fills the data with this object's movement/speed info
////////////////////////////////////////////////////////////////////////////////
void Object::BuildMoveUpdate(uint32 flags, uint32 flags2, uint8 *data, int* length)
{
    int b = 0, b2 = 0;
    int spline_count = 0;
    uint8 * pSplineData = NULL;


    memcpy(data+b, &flags, 4);
    b+=4;

    data[b++] = 0x00;
    data[b++] = 0x00;
    data[b++] = 0x00;
    data[b++] = 0x00;

    memcpy(data+b, &m_positionX, 4);
    b+=4;

    memcpy(data+b, &m_positionY, 4);
    b+=4;

    memcpy(data+b, &m_positionZ, 4);
    b+=4;

    memcpy(data+b, &m_orientation, 4);
    b+=4;

    if (flags & 0x20000000)
    {
        data[b++] = 0x00; // uint64 Transport GUID
        data[b++] = 0x00;
        data[b++] = 0x00;
        data[b++] = 0x00;
        data[b++] = 0x00;
        data[b++] = 0x00;
        data[b++] = 0x00;
        data[b++] = 0x00;
        data[b++] = 0x00; // Float32 TransportX
        data[b++] = 0x00;
        data[b++] = 0x00;
        data[b++] = 0x00;
        data[b++] = 0x00; // Float32 TransportY
        data[b++] = 0x00;
        data[b++] = 0x00;
        data[b++] = 0x00;
        data[b++] = 0x00; // Float32 TransportZ
        data[b++] = 0x00;
        data[b++] = 0x00;
        data[b++] = 0x00;
        data[b++] = 0x00; // Float32 Transport Facing
        data[b++] = 0x00;
        data[b++] = 0x00;
        data[b++] = 0x00;
    }

    if (flags & 0x1000000)
    {
        data[b++] = 0x00; // Float32
        data[b++] = 0x00;
        data[b++] = 0x00;
        data[b++] = 0x00;
    }

    if (flags & 0x4000)
    {
        data[b++] = 0x00; // uint16
        data[b++] = 0x00;
        data[b++] = 0x00; // Float32 x
        data[b++] = 0x00;
        data[b++] = 0x00;
        data[b++] = 0x00;
        data[b++] = 0x00; // Float32 y
        data[b++] = 0x00;
        data[b++] = 0x00;
        data[b++] = 0x00;
        data[b++] = 0x00; // Float32 z
        data[b++] = 0x00;
        data[b++] = 0x00;
        data[b++] = 0x00;
        data[b++] = 0x00; // Float32 orientation
        data[b++] = 0x00;
        data[b++] = 0x00;
        data[b++] = 0x00;
    }

    data[b++] = 0x00; // Float32 walk speed
    data[b++] = 0x00;
    data[b++] = 0x20;
    data[b++] = 0x40;

    data[b++] = 0x00; // run speed
    data[b++] = 0x00;
    data[b++] = 0xE0;
    data[b++] = 0x40;

    data[b++] = 0x00; // Float32 backwards walk speed
    data[b++] = 0x00;
    data[b++] = 0x20;
    data[b++] = 0x40;

    data[b++] = 0x72; // Float32 swim speed
    data[b++] = 0x1c;
    data[b++] = 0x97;
    data[b++] = 0x40;

    // BETA3:  some new field, value: 4.5 // backwards swim speed?
    data[b++] = 0x00; 
    data[b++] = 0x00;
    data[b++] = 0x90;
    data[b++] = 0x40;  

    data[b++] = 0xDB; // Float32 turn rate
    data[b++] = 0x0F;
    data[b++] = 0x49;
    data[b++] = 0x40;

    if ((flags & 0x00200000) != 0)
    {
        memcpy(&data[b], &flags2, 4);  // flags 2
        b+=4;

        if (flags2 & 0x10000)
        {
            data[b++] = 0x00; // Float32
            data[b++] = 0x00;
            data[b++] = 0x00;
            data[b++] = 0x00;
        }

        if (flags2 & 0x20000)
        {
            data[b++] = 0x00; // uint64
            data[b++] = 0x00;
            data[b++] = 0x00;
            data[b++] = 0x00;
            data[b++] = 0x00;
            data[b++] = 0x00;
            data[b++] = 0x00;
            data[b++] = 0x00;
        }

        if (flags2 & 0x40000)
        {
            data[b++] = 0x00; // Float32
            data[b++] = 0x00;
            data[b++] = 0x00;
            data[b++] = 0x00;
        }

        data[b++] = 0x00; // int
        data[b++] = 0x00;
        data[b++] = 0x00; // uint32
        data[b++] = 0x00;
        data[b++] = 0x00;
        data[b++] = 0x00;


        memcpy(&data[b], &spline_count, 2);  // uint16 Spline Count!?
        b+=2;

        if (spline_count > 0)
        {
            pSplineData = new uint8[spline_count*6]; // number of splines at 6 bytes each

            for (int i = 0; i < spline_count; i++)
            {
                // 6 bytes per spline point
                pSplineData[b2++] = 0x00; // uint64
                pSplineData[b2++] = 0x00;
                pSplineData[b2++] = 0x00;
                pSplineData[b2++] = 0x00;
                pSplineData[b2++] = 0x00;
                pSplineData[b2++] = 0x00;
                pSplineData[b2++] = 0x00;
                pSplineData[b2++] = 0x00;
            }

            memcpy(data+b, pSplineData, b2);
        }
    } // end if flags2

    *length = b + b2;
}


//=======================================================================================
//	Creates an UpdateBlock with the values of this object as 
//	determined by the updateMask.
//
//=======================================================================================
void Object::BuildUpdateBlock(UpdateMask *updateMask,uint8 *data, int *length)
{
    uint32 b = 0;
    uint32 curcount, curbit, updateoffset = 0;

    for( curcount = 0; curcount < updateMask->count; curcount ++ )
        for( curbit = 0; curbit < 32; curbit ++, updateoffset ++ )
            if( updateMask->updateMask[ curcount ] & ( 1 << curbit ) ) {
                memcpy( data+b, m_updateValues + updateoffset, 4 );
                b += 4;
            }

            *length = b;
}

void Object::BuildHeartBeat(wowWData *data)
{
    data->clear();
    data->setLength(32);
    data->opcode = MSG_MOVE_HEARTBEAT;

    uint32 guid = getGUID();
    *data << uint32(m_guid[0]);
    *data << uint32(m_guid[1]);

    *data << uint32(0); // flags
    *data << uint32(0); // mysterious value #1

    *data << m_positionX;
    *data << m_positionY;
    *data << m_positionZ;

    *data << m_orientation;


}

void Object::TeleportAck(wowWData *data, float x, float y, float z)
{
    setPosition(x,y,z,0,true);

    ///////////////////////////////////////
    //Update player on the client with TELEPORT_ACK
    data->Initialise(32, MSG_MOVE_TELEPORT_ACK);

    *data << uint32(m_guid[0]);
    *data << uint32(m_guid[1]);

    //First 4 bytes = no idea what it is
    *data << uint32(0); // flags
    *data << uint32(0); // mysterious value #1

    *data << x;
    *data << y;
    *data << z;
    *data << m_orientation;
}

void Object::UpdateInRangeSet()
{
    wowWData tmpData, smsgOutOfRangeObjects;
    int count = 0;
    int size1 = 0;

    std::set<Object*>::iterator itr;
    for (itr = m_objectsInRange.begin(); itr != m_objectsInRange.end();)
    {  
        size1 = m_objectsInRange.size();

        // only allocate message memory if this is a player
        // TODO: This length should be calculated correctly !!
        if (m_objectTypeId == 4)
            tmpData.Initialise(1000, SMSG_UPDATE_OBJECT);

        while (count < 60 && itr != m_objectsInRange.end())
        {
            if ( (*itr)->getObjectTypeId() == 3 || (*itr)->getObjectTypeId() == 4 )
            {
                if (getMapId() != (*itr)->getMapId() ||
                    getDistanceSq((*itr)) > UPDATE_DISTANCE*UPDATE_DISTANCE)
                {
                    // Object is out of range

                    // only add to tmpBuffer if this is a player
                    if (m_objectTypeId == 4){
                        tmpData << (*itr)->getGUID() << (*itr)->getGUIDHigh();
                        count++;

                        //add the Unit's items
                        if ((*itr)->getObjectTypeId() == 4)
                        {
                            for (int item=0; item < 39; item++){
                                uint32 itemguid;
                                if (itemguid = ((Character*)(*itr))->getGuidBySlot(item) != 0){
                                    tmpData << itemguid << 0x00000040;
                                    count++;
                                }
                            }
                        }
                    }

                    if ((*itr)->getObjectTypeId() == 3)
                        Log::getSingleton( ).outString("Removed %s from In Range Set.\n", ((Unit*)(*itr))->getCreatureName());
                    if ((*itr)->getObjectTypeId() == 4)
                        Log::getSingleton( ).outString("Removed %s from In Range Set.\n", ((Character*)(*itr))->getName());

                    // remove from set
                    Object* pObj = *itr;
                    ++itr;
                    m_objectsInRange.erase(pObj);
                    continue;
                }
            } // end player or unit and is in range

            ++itr;
        } // end while count < 60

        if (count > 0 && m_objectTypeId == 4)
        {
            smsgOutOfRangeObjects.Initialise(10 + count*8, SMSG_UPDATE_OBJECT);
            smsgOutOfRangeObjects << uint32(1) << uint8(0) << uint8(3) << uint32(count);
            memcpy(smsgOutOfRangeObjects.data+10, tmpData.data, count*8);
            WorldServer::getSingletonPtr()->SendMessageToPlayer(&smsgOutOfRangeObjects, m_guid[0]);
            printf("Sending %d updates...\n", count);
        }

        count = 0;
    }

}
    
void Object::SendMessageToSet(wowWData *data, bool bToSelf)
{
    if (bToSelf && getObjectTypeId() == 4){
        //has to be a player to send to self
        ((Character*)this)->pClient->SendMsg(data);
    }

    std::set<Object*>::iterator itr;
    for (itr = m_objectsInRange.begin(); itr != m_objectsInRange.end(); ++itr)
    {
        WPWarning((*itr), "Warning:  NULL Iterator in Set, skipping.");
        if (!(*itr))
            continue;

        if ((*itr)->getObjectTypeId() == 4) // if player
        {
            GameClient *pClient = ((Character*)(*itr))->pClient;
            WPWarning( pClient, "Null client in message set!" );
            if ( pClient )
            if (pClient->IsInWorld() && pClient->getCurrentChar())
                pClient->SendMsg(data);
		}
    }
}
