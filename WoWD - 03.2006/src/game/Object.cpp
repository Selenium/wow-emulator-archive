// Copyright (C) 2004 WoW Daemon
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

#include "Common.h"
#include "WorldPacket.h"
#include "Opcodes.h"
#include "Log.h"
#include "World.h"
#include "Object.h"
#include "Player.h"
#include "ObjectMgr.h"
#include "WorldSession.h"
#include "UpdateData.h"
#include "MapMgr.h"
#include "Util.h"
#include "WorldCreator.h"
#include <math.h>

using namespace std;

//#define DEG2RAD (M_PI/180.0)
#define M_PI       3.14159265358979323846

Object::Object( )
{
    m_objectTypeId = TYPEID_OBJECT;
    m_objectType = TYPE_OBJECT;

    m_positionX = 0.0f;
    m_positionY = 0.0f;
    m_positionZ = 0.0f;
    m_orientation = 0.0f;
    m_spawnX = 0.0f;
    m_spawnY = 0.0f;
    m_spawnZ = 0.0f;

    m_mapId = 0;
    m_zoneId = 0;

    m_uint32Values = 0;
	m_baseUint32Values = 0;

    m_inWorld = false;

    m_minZ = -500;

    m_valuesCount = 0;

	//official Values
    m_walkSpeed = 2.5f;
    m_runSpeed = 6.0f;
    m_flySpeed = 30.0f;
    m_backWalkSpeed = 2.5f;
    m_swimSpeed = 4.722222f;
    m_backSwimSpeed = 2.5f;
    m_turnRate = 3.141593f;

    m_mapMgr = 0;
    m_mapCell = 0;
	
    mSemaphoreTeleport = false;
    sWorld.AddGlobalObject(this);
}


Object::~Object( )
{   
    sWorld.RemoveGlobalObject(this);
    if(m_uint32Values)
        delete [] m_uint32Values;

	if(m_baseUint32Values)
        delete [] m_baseUint32Values;
}


void Object::_Create( uint32 guidlow, uint32 guidhigh )
{
    _InitValues();

    SetUInt32Value( OBJECT_FIELD_GUID, guidlow );
    SetUInt32Value( OBJECT_FIELD_GUID+1, guidhigh );
    SetUInt32Value( OBJECT_FIELD_TYPE, m_objectType );

    m_wowGuid.Init(GetGUID());
}

void Object::_Create( uint32 guidlow, uint32 guidhigh, uint32 mapid, float x, float y, float z, float ang )
{
    _InitValues();

    SetUInt32Value( OBJECT_FIELD_GUID, guidlow );
    SetUInt32Value( OBJECT_FIELD_GUID+1, guidhigh );
    SetUInt32Value( OBJECT_FIELD_TYPE, m_objectType );

    m_wowGuid.Init(GetGUID());

    m_mapId = mapid;
    m_positionX = x;
    m_positionY = y;
    m_positionZ = z;
    m_spawnX = x;
    m_spawnY = y;
    m_spawnZ = z;
    m_orientation = ang;
}

void Object::BuildMovementUpdateBlock(UpdateData * data, uint32 flags ) const
{
    ByteBuffer buf(500);

    buf << uint8( UPDATETYPE_MOVEMENT );  // update type

    uint64 guidfields = GetGUID();
    uint8 guidmask = 0;

    //get the GUID in 1.9 form
    for(int i = 0; i < 8; i++)
    {
        if ((char)(guidfields >> (56 - i*8)) != 0)
        {
            guidmask |= 1 << (7 - i);
        }
    }
    buf << uint8( guidmask );

    guidfields = GetGUID();
    for(int i = 0; i < 8; i++)
    {
        if ((char)(guidfields >> (i*8)) != 0)
        {
            buf << uint8( (char)(guidfields >> (i*8)) );
        }
    }
	/* NOTE Flags2 is movment flags
		if this is a player and it is them self they should have a flag of 0x00002000 this is moveroot else client crashes on join
	*/

    switch(m_objectTypeId)
    {
    case TYPEID_OBJECT:
        break;
    case TYPEID_ITEM:
    case TYPEID_CONTAINER:
        {
            _BuildMovementUpdate( &buf, 0x10, 0);
        } break;
    case TYPEID_UNIT:
        {    
            _BuildMovementUpdate( &buf, 0x70, 0);
        } break;
    case TYPEID_PLAYER:
        {
            _BuildMovementUpdate( &buf, 0x71, 0);
        } break;
    case TYPEID_CORPSE:
    case TYPEID_GAMEOBJECT:
    case TYPEID_DYNAMICOBJECT:
        {
            _BuildMovementUpdate( &buf, 0x50, 0);
        } break;
    default:
        break;
    }

    data->AddUpdateBlock(buf);
}


void Object::BuildCreateUpdateBlockForPlayer(UpdateData *data, Player *target) const
{
    ByteBuffer buf(1500);
    uint64 guidfields = GetGUID();
    uint8 guidmask = 0;

    if (target == this)
        buf << uint8( UPDATETYPE_CREATE_YOURSELF ); 
    else
        buf << uint8( UPDATETYPE_CREATE_OBJECT );// update type == creation

    //get the GUID in 1.9 form
    for(int i = 0; i < 8; i++)
    {
        if ((char)(guidfields >> (56 - i*8)) != 0)
        {
            guidmask |= 1 << (7 - i);
        }
    }
    buf << uint8( guidmask );

    guidfields = GetGUID();
    for(int i = 0; i < 8; i++)
    {
        if ((char)(guidfields >> (i*8)) != 0)
        {
            buf << uint8( (char)(guidfields >> (i*8)) );
        }
    }

    buf << GetTypeId();                      // object type

	/* NOTE Flags2 is movment flags
		if this is a player and it is them self they should have a flag of 0x00002000 this is moveroot else client crashes on join
	*/
    switch(m_objectTypeId)
    {
    case TYPEID_OBJECT:
        break;
    case TYPEID_ITEM:
    case TYPEID_CONTAINER:
        {
            _BuildMovementUpdate( &buf, 0x10, 0);
        } break;
    case TYPEID_UNIT:
        {    
            _BuildMovementUpdate( &buf, 0x70, 0);
        } break;
    case TYPEID_PLAYER:
        {
            if (target == this)
                _BuildMovementUpdate( &buf, 0x71, 0x00002000);
            else
                _BuildMovementUpdate( &buf, 0x70, 0);
        } break;
    case TYPEID_CORPSE:
    case TYPEID_GAMEOBJECT:
    case TYPEID_DYNAMICOBJECT:
        {
            _BuildMovementUpdate( &buf, 0x50, 0);
        } break;
    default:
        break;
    }
    
    buf << uint32(0x6294B48C); // unk
    
    UpdateMask updateMask;
    updateMask.SetCount( m_valuesCount );
    _SetCreateBits( &updateMask, target );
    _BuildValuesUpdate( &buf, &updateMask );

    data->AddUpdateBlock(buf);
}


void Object::BuildValuesUpdateBlockForPlayer(UpdateData *data, Player *target) const
{
    ByteBuffer buf(1500);
    uint64 guidfields = GetGUID();
    uint8 guidmask = 0;

    buf << (uint8) UPDATETYPE_VALUES;        // update type == update

    //get the GUID in 1.9 form
    for(int i = 0; i < 8; i++)
    {
        if ((char)(guidfields >> (56 - i*8)) != 0)
        {
            guidmask |= 1 << (7 - i);
        }
    }
    buf << uint8( guidmask );

    guidfields = GetGUID();
    for(int i = 0; i < 8; i++)
    {
        if ((char)(guidfields >> (i*8)) != 0)
        {
            buf << uint8( (char)(guidfields >> (i*8)) );
        }
    }

    UpdateMask updateMask;
    updateMask.SetCount( m_valuesCount );
    _SetUpdateBits( &updateMask, target );
    _BuildValuesUpdate( &buf, &updateMask );

    data->AddUpdateBlock(buf);
}


void Object::BuildOutOfRangeUpdateBlock(UpdateData * data) const
{
    data->AddOutOfRangeGUID(GetGUID());
}


void Object::DestroyForPlayer(Player *target) const
{
    ASSERT(target);

    WorldPacket data;
    data.Initialize( SMSG_DESTROY_OBJECT );
    data << GetGUID();

    target->GetSession()->SendPacket( &data );
}


///////////////////////////////////////////////////////////////
/// Build the Movement Data portion of the update packet
/// Fills the data with this object's movement/speed info
/// TODO: rewrite this stuff, document unknown fields and flags
void Object::_BuildMovementUpdate(ByteBuffer * data, uint8 flags, uint32 flags2 ) const
{
    uint32 spline_count = 0;

    *data << (uint8)flags;

    if (flags & 0x20)
    {
		/*
        if(this->GetTypeId() == TYPEID_UNIT)
		{
			spline_count = ((Creature *)this)->GetAIInterface()->m_nWaypoints;
			if(spline_count > 0)
			{
				flags2 |= 0x00400000;
			}
		}
        */

		*data << (uint32)flags2;
        //*data << (uint32)0xC15B2E37; // unk
		*data << getMSTime(); // this appears to be time in ms but can be any thing
    }

    if (flags & 0x40)
    {
        *data << (float)m_positionX;
        *data << (float)m_positionY;
        *data << (float)m_positionZ;
        *data << (float)m_orientation;
    }

    if (flags & 0x20)
    {
        *data << (uint32)0;
    }

    if (flags & 0x01)
    {
        *data << (float)0;
        *data << (float)1.0;
        *data << (float)0;
        *data << (float)0;
    }

    if (flags & 0x20)
    {
        *data << m_walkSpeed;     // walk speed
        *data << m_runSpeed;      // run speed
        *data << m_backWalkSpeed; // backwards walk speed
        *data << m_swimSpeed;     // swim speed
        *data << m_backSwimSpeed; // backwards swim speed
        *data << m_turnRate;      // turn rate
    }
    /*
	if(spline_count > 0 )
	{
		*data << uint32(0); //SplineFlags
		*data << uint32(1200); //Time Passed (start Position) //should be generated/save 
		*data << uint32(5000); //Total Time //should be generated/save
		*data << uint32(0); //Unknown
		*data << uint32(spline_count-1); //Spline Count
		
		for (uint32 j = 0; j < spline_count; j++)
        {
			
			*data << float(((Creature *)this)->GetAIInterface()->m_waypoints[j][0]); //X
			*data << float(((Creature *)this)->GetAIInterface()->m_waypoints[j][1]); //Y
			*data << float(((Creature *)this)->GetAIInterface()->m_waypoints[j][2]); //Z
        }
	}
    */
}


//=======================================================================================
//  Creates an update block with the values of this object as
//  determined by the updateMask.
//=======================================================================================
void Object::_BuildValuesUpdate(ByteBuffer * data, UpdateMask *updateMask) const
{
    WPAssert(updateMask && updateMask->GetCount() == m_valuesCount);

    *data << (uint8)updateMask->GetBlockCount();

    data->append( updateMask->GetMask(), updateMask->GetLength() );
    //if ((blocktype == UPDATETYPE_VALUES) && (type_id != TYPEID_PLAYER))
    //    *data << uint32(0);

    for( uint16 index = 0; index < m_valuesCount; index ++ )
    {
        if( updateMask->GetBit( index ) )
            *data << m_uint32Values[ index ];
    }
}


void Object::BuildHeartBeatMsg(WorldPacket *data) const
{
    data->Initialize(MSG_MOVE_HEARTBEAT);

    *data << GetGUID();

    *data << uint32(0); // flags
    *data << uint32(0); // mysterious value #1

    *data << m_positionX;
    *data << m_positionY;
    *data << m_positionZ;

    *data << m_orientation;
}


void Object::BuildTeleportAckMsg(WorldPacket *data, float x, float y, float z, float ang) const
{
    ///////////////////////////////////////
    //Update player on the client with TELEPORT_ACK
    data->Initialize(MSG_MOVE_TELEPORT_ACK);

    *data << GetNewGUID();

    //First 4 bytes = no idea what it is
    *data << uint32(0); // flags
    *data << uint32(0); // mysterious value #1

    *data << x;
    *data << y;
    *data << z;
    *data << ang;
	*data<< uint32(0x0);
}


bool Object::SetPosition( float newX, float newY, float newZ, float newOrientation, bool allowPorting )
{
    m_orientation = newOrientation;
    bool updateMap = false, result = true;

    if (m_positionX != newX || m_positionY != newY)
        updateMap = true;

    m_positionX = newX;
    m_positionY = newY;
    m_positionZ = newZ;

    if (!allowPorting && newZ < m_minZ)
    {
        m_positionZ = 500;
        sLog.outError( "setPosition: fell through map; height ported" );

        result = false;
    }

    if (IsInWorld() && updateMap)
        if (this->m_mapMgr)
            m_mapMgr->ChangeObjectLocation(this);

    return result;
}


void Object::SendMessageToSet(WorldPacket *data, bool bToSelf)
{
    if (bToSelf && GetTypeId() == TYPEID_PLAYER)
    {
        //has to be a player to send to self
        ((Player*)this)->GetSession()->SendPacket(data);
    }

    std::set<Object*>::iterator itr;
    for (itr = m_objectsInRange.begin(); itr != m_objectsInRange.end(); ++itr)
    {
        ASSERT(*itr);

        if ((*itr)->GetTypeId() == TYPEID_PLAYER)
        {
            WorldSession *session = ((Player*)(*itr))->GetSession();
            WPWarning( session, "Null client in message set!" );
            session->SendPacket(data);
        }
    }
}

/*
void Object::SendPacketListToSet(WorldSession::MessageList & msglist, bool bToSelf)
{
    if (bToSelf && GetTypeId() == TYPEID_PLAYER)
        ((Player*)this)->GetSession()->SendPacketList( msglist ); // has to be a player to send to self

    std::set<Object*>::iterator itr;
    for (itr = m_objectsInRange.begin(); itr != m_objectsInRange.end(); ++itr)
    {
        WPWarning((*itr), "Warning:  NULL Iterator in Set, skipping.");
        if (!(*itr))
            continue;

        if ((*itr)->GetTypeId() == TYPEID_PLAYER)
        {
            WorldSession *session = ((Player*)(*itr))->GetSession();
            WPWarning( session, "Null client in message set!" );
            if (session && session->IsInWorld() && session->GetPlayer())
                session->SendPacketList( msglist );
        }
    }
}
*/


////////////////////////////////////////////////////////////////////////////
/// Fill the object's Update Values from a space deliminated list of values.
void Object::LoadValues(const char* data)
{
    if(!m_uint32Values || !m_baseUint32Values) _InitValues();

    vector<string> tokens = StrSplit(data, " ");

	vector<string>::iterator iter;
	int index;

	for (iter = tokens.begin(), index = 0;
        index < m_valuesCount && iter != tokens.end(); ++iter, ++index)
    {
        m_uint32Values[index] = atol((*iter).c_str());
		m_baseUint32Values[index] = atol((*iter).c_str());
    }
}

void Object::LoadTaxiMask(const char* data)
{
    vector<string> tokens = StrSplit(data, " ");

	int index;
	vector<string>::iterator iter;

	for (iter = tokens.begin(), index = 0;
        (index < 8) && (iter != tokens.end()); ++iter, ++index)
    {
        m_taximask[index] = atol((*iter).c_str());
    }
}

void Object::_SetUpdateBits(UpdateMask *updateMask, Player *target) const
{
    *updateMask = m_updateMask;
}


void Object::_SetCreateBits(UpdateMask *updateMask, Player *target) const
{
    for( uint16 index = 0; index < m_valuesCount; index++ )
    {
        if(GetUInt32Value(index) != 0)
            updateMask->SetBit(index);
    }
}

void Object::AddToWorld()
{
	if (((this->GetTypeId() == TYPEID_ITEM) && (m_inWorld)) || ((this->GetTypeId() == TYPEID_CONTAINER) && (m_inWorld)))
    {
        m_inWorld = true;
        return;
    }

    ASSERT(!m_inWorld);

    m_inWorld = true;

    _PlaceOnMap();
}

void Object::RemoveFromWorld()
{
	if (((this->GetTypeId() == TYPEID_ITEM) && (!m_inWorld)) || ((this->GetTypeId() == TYPEID_CONTAINER) && (!m_inWorld)))
    {
        m_inWorld = false;
        return;
    }

    ASSERT(m_inWorld);

    m_inWorld = false;

    _RemoveFromMap();
}

void Object::_PlaceOnMap()
{
    ASSERT(!m_mapMgr);

    MapMgr* mapMgr = sWorldCreator.GetInstance(m_mapId, this);
    ASSERT(mapMgr);
    
    sWorld.RemoveGlobalObject(this);

#ifndef DYNAMIC_LOADING
	Log::getSingleton( ).outError("AddObject at Object.cpp");
#endif

    mapMgr->AddObject(this);
    m_mapMgr = mapMgr;
	mSemaphoreTeleport = false;
}


void Object::_RemoveFromMap()
{
    ASSERT(m_mapMgr);

	mSemaphoreTeleport = true;

    m_mapMgr->RemoveObject(this);
    m_mapMgr = 0;
    m_mapCell = 0;
    
    sWorld.AddGlobalObject(this);
}


//! Set uint32 property
void Object::SetUInt32Value( const uint16 &index, const uint32 &value )
{
    ASSERT( index < m_valuesCount );
    m_uint32Values[ index ] = value;

    if(m_inWorld)
    {
        m_updateMask.SetBit( index );

        if(!m_objectUpdated)
        {
            m_mapMgr->ObjectUpdated(this);
            m_objectUpdated = true;
        }
    }
}

//! Set uint64 property
void Object::SetUInt64Value( const uint16 &index, const uint64 &value )
{
    ASSERT( index + 1 < m_valuesCount );
    m_uint32Values[ index ] = *((uint32*)&value);
    m_uint32Values[ index + 1 ] = *(((uint32*)&value) + 1);

    if(m_inWorld)
    {
        m_updateMask.SetBit( index );
        m_updateMask.SetBit( index + 1 );

        if(!m_objectUpdated)
        {
            m_mapMgr->ObjectUpdated(this);
            m_objectUpdated = true;
        }
    }
}

//! Set float property
void Object::SetFloatValue( const uint16 &index, const float &value )
{
    ASSERT( index < m_valuesCount );
    m_floatValues[ index ] = value;

    if(m_inWorld)
    {
        m_updateMask.SetBit( index );

        if(!m_objectUpdated)
        {
            m_mapMgr->ObjectUpdated(this);
            m_objectUpdated = true;
        }
    }
}


void Object::SetFlag( const uint16 &index, uint32 newFlag )
{
    ASSERT( index < m_valuesCount );
    m_uint32Values[ index ] |= newFlag;

    if(m_inWorld)
    {
        m_updateMask.SetBit( index );

        if(!m_objectUpdated)
        {
            m_mapMgr->ObjectUpdated(this);
            m_objectUpdated = true;
        }
    }
}


void Object::RemoveFlag( const uint16 &index, uint32 oldFlag )
{
    ASSERT( index < m_valuesCount );
    m_uint32Values[ index ] &= ~oldFlag;

    if(m_inWorld)
    {
        m_updateMask.SetBit( index );

        if(!m_objectUpdated)
        {
            m_mapMgr->ObjectUpdated(this);
            m_objectUpdated = true;
        }
    }
}

//Base update field functions for saving purposes and maybe other stuff :P
//////////////////////////////////////////////////////////////////////////
void Object::SetBaseUInt32Value( const uint16 &index, const uint32 &value )
{
    ASSERT( index < m_valuesCount );
    m_baseUint32Values[ index ] = value;
}

//! Set uint64 property
void Object::SetBaseUInt64Value( const uint16 &index, const uint64 &value )
{
    ASSERT( index + 1 < m_valuesCount );
    m_baseUint32Values[ index ] = *((uint32*)&value);
    m_baseUint32Values[ index + 1 ] = *(((uint32*)&value) + 1);
}

//! Set float property
void Object::SetBaseFloatValue( const uint16 &index, const float &value )
{
    ASSERT( index < m_valuesCount );
    m_baseFloatValues[ index ] = value;
}


void Object::SetBaseFlag( const uint16 &index, uint32 newFlag )
{
    ASSERT( index < m_valuesCount );
    m_baseUint32Values[ index ] |= newFlag;
}


void Object::RemoveBaseFlag( const uint16 &index, uint32 oldFlag )
{
    ASSERT( index < m_valuesCount );
    m_baseUint32Values[ index ] &= ~oldFlag;
}
////////////////////////////////////////////////////////////

float Object::CalcDistance(Object *Ob)
{
	return CalcDistance(this->GetPositionX(), this->GetPositionY(), this->GetPositionZ(), Ob->GetPositionX(), Ob->GetPositionY(), Ob->GetPositionZ());
}
float Object::CalcDistance(float ObX, float ObY, float ObZ)
{
	return CalcDistance(this->GetPositionX(), this->GetPositionY(), this->GetPositionZ(), ObX, ObY, ObZ);
}

float Object::CalcDistance(Object *Oa, Object *Ob)
{
	return CalcDistance(Oa->GetPositionX(), Oa->GetPositionY(), Oa->GetPositionZ(), Ob->GetPositionX(), Ob->GetPositionY(), Ob->GetPositionZ());
}

float Object::CalcDistance(Object *Oa, float ObX, float ObY, float ObZ)
{
	return CalcDistance(Oa->GetPositionX(), Oa->GetPositionY(), Oa->GetPositionZ(), ObX, ObY, ObZ);
}

float Object::CalcDistance(float OaX, float OaY, float OaZ, float ObX, float ObY, float ObZ)
{
	float xdest = OaX - ObX;
	float ydest = OaY - ObY;
	float zdest = OaZ - ObZ;
	return sqrt(zdest*zdest + ydest*ydest + xdest*xdest);
}

float Object::calcAngle( float Position1X, float Position1Y, float Position2X, float Position2Y )
{
		float dx = Position2X-Position1X;
		float dy = Position2Y-Position1Y;
		float angle=0.0f;

		// Calculate angle
		if (dx == 0.0)
		{
		    if (dy == 0.0)
				angle = 0.0;
			else if (dy > 0.0)
				angle = M_PI / 2.0;
			else
				angle = M_PI * 3.0 / 2.0;
		}
		else if (dy == 0.0)
		{
		    if (dx > 0.0)
				angle = 0.0;
		    else
				angle = M_PI;
		}
		else
		{
			if (dx < 0.0)
				angle = atan(dy/dx) + M_PI;
			else if (dy < 0.0)
				angle = atan(dy/dx) + (2*M_PI);
			else
				angle = atan(dy/dx);
		}

		// Convert to degrees
		angle = angle * 180 / M_PI;

		// Return
		return angle;
}

float Object::getEasyAngle( float angle )
{
        while ( angle < 0 ) {
                angle = angle + 360;
        }
        while ( angle >= 360 ) {
                angle = angle - 360;
        }
        return angle;
}

bool Object::inArc(float Position1X, float Position1Y, float FOV, float Orientation, float Position2X, float Position2Y )
{
	float angle = calcAngle( Position1X, Position1Y, Position2X, Position2Y );
	float lborder = getEasyAngle( ( Orientation - (FOV/2) ) );
	float rborder = getEasyAngle( ( Orientation + (FOV/2) ) );
	//Log::getSingleton().outDebug("Orientation: %f Angle: %f LeftBorder: %f RightBorder %f",Orientation,angle,lborder,rborder);
	if(((angle >= lborder) && (angle <= rborder)) || ((lborder > rborder) && ((angle < rborder) || (angle > lborder))))
	{
		return true;
	}
	else
	{
		return false;
	}
} 

bool Object::isInFront(Object* target)
{
	float orientation = (360/float(2*M_PI))*GetOrientation(); //convert to 360 degrees
	float FOV = 90;
	return inArc(GetPositionX(),GetPositionY(),FOV,orientation,target->GetPositionX(),target->GetPositionY());
}

bool Object::isInRange(Object* target, float range)
{
	float dist = CalcDistance(target);
	return (dist <= range);
}

