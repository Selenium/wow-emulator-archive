#include "StdAfx.h"

// Copyright (C) 2004 WoWD Team

#include "../Shared/Namespace.h"

//-----------------------------------------------------------------------------
Object::Object( )
{
    m_objectTypeId = TYPEID_OBJECT;
    m_objectType = TYPE_OBJECT;

    m_positionX = 0.0f;
    m_positionY = 0.0f;
    m_positionZ = 0.0f;
    m_orientation = 0.0f;

    m_mapId = 0;
    m_zoneId = 0;

    m_uint32Values = 0;

    m_inWorld = false;

    m_minZ = -500;

    m_valuesCount = 0;

    m_walkSpeed = 2.5f;
    m_runSpeed = 7.0f;
    m_backWalkSpeed = 2.5;
    (*((uint32*)&m_swimSpeed)) = 0x40971c72;
    m_backSwimSpeed = 4.5;
    (*((uint32*)&m_turnRate)) = 0x40490FDF;

    m_mapMgr = 0;
	m_mapCell = NULL;	// finally got you little buggy bastard! crash after world import
}

//-----------------------------------------------------------------------------
Object::~Object( )
{
    if(m_uint32Values)
        delete [] m_uint32Values;
}

//-----------------------------------------------------------------------------
void Object::_Create( uint32 guidlow, uint32 guidhigh )
{
    _InitValues();

    SetUInt32Value (OBJECT_FIELD_GUID, guidlow);
    SetUInt32Value (OBJECT_FIELD_GUID+1, guidhigh);
    SetUInt32Value (OBJECT_FIELD_TYPE, m_objectType);
}

//-----------------------------------------------------------------------------
void Object::_Create( uint32 guidlow, uint32 guidhigh, uint32 mapid, float x, float y, float z, float ang )
{
    _InitValues();

    SetUInt32Value( OBJECT_FIELD_GUID, guidlow );
    SetUInt32Value( OBJECT_FIELD_GUID+1, guidhigh );
    SetUInt32Value( OBJECT_FIELD_TYPE, m_objectType );

    m_mapId = mapid;
    m_positionX = x;
    m_positionY = y;
    m_positionZ = z;
    m_orientation = ang;
}

//-----------------------------------------------------------------------------
void Object::BuildMovementUpdateBlock(UpdateData * data, uint32 flags )
{
    ByteBuffer buf(500);

    buf << uint8( UPDATETYPE_MOVEMENT );  // update type
    buf << GetGUID();    // object GUID

    _BuildMovementUpdate(&buf, flags, 0x00000000);

    data->AddUpdateBlock(buf);
}

//-----------------------------------------------------------------------------
void Object::BuildCreateUpdateBlockForPlayer(UpdateData *data, Player *target)
{
    ByteBuffer buf(500);

    buf << uint8( UPDATETYPE_CREATE_OBJECT );// update type == creation
    buf << GetGUID() ;                       // object GUID
	buf << GetTypeId();                      // object type

    // build and add the movement update portion of the packet
    _BuildMovementUpdate( &buf, 0x00000000, 0x00000000 );

    buf << uint32( target == this ? 1 : 0 ); // 4 byte flags, 1 == active player
    buf << uint32( 0 );                      // uint32 attack cycle
    buf << uint32( 0 );                      // uint32 timer id
    buf << uint64( 0 );                      // GUID victim

    UpdateMask updateMask;
    updateMask.SetCount( m_valuesCount );
    _SetCreateBits( &updateMask, target );
    _BuildValuesUpdate( &buf, &updateMask );

    data->AddUpdateBlock(buf);
}

//-----------------------------------------------------------------------------
void Object::BuildValuesUpdateBlockForPlayer(UpdateData *data, Player *target)
{
    ByteBuffer buf(500);

    buf << (uint8) UPDATETYPE_VALUES;        // update type == creation
    buf << GetGUID() ;                       // object GUID

    UpdateMask updateMask;
    updateMask.SetCount( m_valuesCount );
    _SetUpdateBits( &updateMask, target );
    _BuildValuesUpdate( &buf, &updateMask );

    data->AddUpdateBlock(buf);
}

//-----------------------------------------------------------------------------
void Object::BuildOutOfRangeUpdateBlock(UpdateData * data)
{
    data->AddOutOfRangeGUID(GetGUID());
}

//-----------------------------------------------------------------------------
void Object::DestroyForPlayer(Player *target)
{
    ASSERT(target);

    WorldPacket data;
    data.Initialize( SMSG_DESTROY_OBJECT );
    data << GetGUID();

    target->GetSession()->SendPacket( &data );
}

//-----------------------------------------------------------------------------
/// Build the Movement Data portion of the update packet
/// Fills the data with this object's movement/speed info
/// TODO: rewrite this stuff, document unknown fields and flags
void Object::_BuildMovementUpdate(ByteBuffer * data, uint32 flags, uint32 flags2 )
{
    int spline_count = 0;

    *data << (uint32)flags;
    *data << (uint32)0;

    *data << (float)m_positionX;
    *data << (float)m_positionY;
    *data << (float)m_positionZ;
    *data << (float)m_orientation;
	*data << (float)0;
    if (flags & 0x20000000)
    {
        *data << (uint32)0; // uint64 Transport GUID
        *data << (uint32)0;
        *data << (float)0;  // Float32 TransportX
        *data << (float)0;  // Float32 TransportY
        *data << (float)0;  // Float32 TransportZ
        *data << (float)0;  // Float32 Transport Facing
    }

    if (flags & 0x1000000)
    {
        *data << (float)0;  // Float32
    }

    if (flags & 0x4000)
    {
        *data << (uint16)0; // uint16
        *data << (float)0;  // Float32 X
        *data << (float)0;  // Float32 Y
        *data << (float)0;  // Float32 Z
        *data << (float)0;  // Float32 Facing
    }

    *data << m_walkSpeed;     // walk speed
    *data << m_runSpeed;      // run speed
    *data << m_backWalkSpeed; // backwards walk speed
    *data << m_swimSpeed;     // swim speed
    *data << m_backSwimSpeed; // backwards swim speed
    *data << m_turnRate;      // turn rate

    if ((flags & 0x00200000) != 0)
    {
        *data << (uint32)flags2;

        if (flags2 & 0x10000)
        {
            *data << (float)0; // Float32
        }

        if (flags2 & 0x20000)
        {
            *data << (uint32)0; // uint64
            *data << (uint32)0;
        }

        if (flags2 & 0x40000)
        {
            *data << (float)0; // Float32
        }

        *data << (uint16)0; // int16?
        *data << (uint32)0; // int32

        *data << (uint16)spline_count; // uint16 Spline Count!?

        if (spline_count > 0)
        {
            for (int i = 0; i < spline_count; i++)
            {
                // 6 (wtf it's 8 :\) bytes per spline point
                *data << uint32(0); // uint64
                *data << uint32(0);
            }
        }
    } // end if flags2
}

//=======================================================================================
//  Creates an update block with the values of this object as
//  determined by the updateMask.
//=======================================================================================
void Object::_BuildValuesUpdate(ByteBuffer * data, UpdateMask *updateMask)
{
    WPAssert(updateMask && updateMask->GetCount() == m_valuesCount);

    *data << (uint8)updateMask->GetBlockCount();
    data->append( updateMask->GetMask(), updateMask->GetLength() );

    for( uint16 index = 0; index < m_valuesCount; index ++ )
    {
        if( updateMask->GetBit( index ) )
            *data << m_uint32Values[ index ];
    }
}

//-----------------------------------------------------------------------------
void Object::BuildHeartBeatMsg(WorldPacket *data)
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

//-----------------------------------------------------------------------------
void Object::BuildTeleportAckMsg(WorldPacket *data, float x, float y, float z, float ang)
{
    ///////////////////////////////////////
    //Update player on the client with TELEPORT_ACK
    data->Initialize(MSG_MOVE_TELEPORT_ACK);

    *data << GetGUID();

    //First 4 bytes = no idea what it is
    //*data << uint32(0); // flags
    //*data << uint32(0); // mysterious value #1
	*data << uint32(0x80000000UL); // flags 0x80000000 = dont fall after teleport?
	
	static uint16 tele_count = 1;
	*data << tele_count++;
	*data << uint16(0xF78B);

    *data << x;
    *data << y;
    *data << z;
    *data << ang;
}

//-----------------------------------------------------------------------------
bool Object::SetPosition( float newX, float newY, float newZ, float newOrientation, bool allowPorting )
{
    m_orientation = newOrientation;

	bool updateMap = false, 
		result = true;

    if (m_positionX != newX || m_positionY != newY)
        updateMap = true;

	float oldX = m_positionX,	dx = newX - m_positionX;
	float oldY = m_positionY,	dy = newY - m_positionY;

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
	// Call ChangeObjectLocation not more often than each
    //if (IsInWorld() && (dx*dx)+(dy*dy) > 0.01f) // 0.1^2 units
	{
        m_mapMgr->ChangeObjectLocation (this, oldX, oldY);
	}

    return result;
}

//-----------------------------------------------------------------------------
void Object::SendMessageToSet(WorldPacket *data, bool bToSelf)
{
	/*if (bToSelf && isPlayer())
	{
		Player *plr = (Player*)this;

		//has to be a player to send to self
		plr->GetSession()->SendPacket(data);

		// if GM in invisible mode then don't send any updates to all around
		if (plr->m_gmInvisible) return;
	}*/

	// Now loop over surrounding players
	//
	//ObjectSet::iterator itr;
	//for (itr = m_objectsInRange.begin(); itr != m_objectsInRange.end(); ++itr)
	
	WorldSession	*session;
	Object			*o;

	if (bToSelf && isPlayer()) 
	{
		((Player *)this)->GetSession()->SendPacket (data);
	}

	for (MapRangeIterator itr (this); o = itr.Advance(); )
	{
		if (o->isNotPlayer()) continue;
		// implemented in Advance():
		// if ((Object *)this == o) continue;

		session = ((Player *)o)->GetSession();
		WPWarning( session, "Null client in message set!" );
		session->SendPacket(data);
	}
}

/*
void Object::SendPacketListToSet(WorldSession::MessageList & msglist, bool bToSelf)
{
    if (bToSelf && GetTypeId() == TYPEID_PLAYER)
        ((Player*)this)->GetSession()->SendPacketList( msglist ); // has to be a player to send to self

    ObjectSet::iterator itr;
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


//-----------------------------------------------------------------------------
/// Fill the object's Update Values from a space delimited list of values.
//-----------------------------------------------------------------------------
void Object::LoadValues(const char* data)
{
    if(!m_uint32Values) _InitValues();

    vector<string> tokens = StrSplit(data, " ");

	vector<string>::iterator iter;
	int index;

	for (iter = tokens.begin(), index = 0;
        index < m_valuesCount && iter != tokens.end(); ++iter, ++index)
    {
        m_uint32Values[index] = atol((*iter).c_str());
    }
}

//-----------------------------------------------------------------------------
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

//-----------------------------------------------------------------------------
/// Load the objects reputation
//-----------------------------------------------------------------------------
void Object::LoadReputation(const char* data)
{
    vector<string> tokens = StrSplit(data, " ");

	vector<string>::iterator iter;
	int index;

	for (iter = tokens.begin(), index = 0;
        (index < 128) && (iter != tokens.end()); ++iter, ++index)
    {
		if (index%2 == 0)
		{
			m_reputation[(index/2)] = (uint8)atol((*iter).c_str());
		}
		else
		{
			m_reputationValues[(int)(index/2)] = atol((*iter).c_str());
		}
    }
}

//-----------------------------------------------------------------------------
void Object::_SetUpdateBits(UpdateMask *updateMask, Player *target)
{
    *updateMask = m_updateMask;
}

//-----------------------------------------------------------------------------
void Object::_SetCreateBits(UpdateMask *updateMask, Player *target) 
{
    for (uint32 index = 0; index < m_valuesCount; index++)
    {
        if(GetUInt32Value(index) != 0)
            updateMask->SetBit(index);
    }
}

//-----------------------------------------------------------------------------
void Object::PlaceOnMap()
{
    //ASSERT(!IsInWorld() && !m_mapMgr);

	if (!IsInWorld() && !m_mapMgr) {
		MapMgr* mapMgr = sWorld.GetMap(m_mapId);
		ASSERT(mapMgr);

		m_mapMgr = mapMgr;
		mapMgr->AddObject(this);
	}
}

//-----------------------------------------------------------------------------
void Object::RemoveFromMap()
{
    //ASSERT(IsInWorld());

	if (IsInWorld()) {
		m_mapMgr->RemoveObject(this);
		m_mapMgr = 0;
	}
}

//-----------------------------------------------------------------------------
//! Set uint32 property
void Object::SetUInt32Value (uint32 index, uint32 value)
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

//-----------------------------------------------------------------------------
void Object::ModifyUInt32Value (uint32 index, int32 change)
{
	int64	value = (int32)GetUInt32Value (index);
	if (value < 0) value = 0;
	
	value += change;
	if (value < 0) value = 0;
	
	SetUInt32Value (index, (uint32)value);
}

//-----------------------------------------------------------------------------
//! Set uint64 property
void Object::SetUInt64Value (uint32 index, uint64 value)
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

//-----------------------------------------------------------------------------
//! Set float property
void Object::SetFloatValue (uint32 index, float value)
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

//-----------------------------------------------------------------------------
void Object::ModifyUFloatValue (uint32 index, float change)
{
	float value = GetFloatValue (index);
	if (value < 0) value = 0;

	value += change;
	if (value < 0) value = 0;

	SetFloatValue (index, value);
}

//-----------------------------------------------------------------------------
void Object::SetFlag (uint32 index, uint32 newFlag)
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

//-----------------------------------------------------------------------------
void Object::RemoveFlag (uint32 index, uint32 oldFlag)
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

//-----------------------------------------------------------------------------
int Object::MapCellX()
{ 
	return (GetPositionX() - m_mapMgr->_minX) / m_mapMgr->_sizeX;
}

//-----------------------------------------------------------------------------
int Object::MapCellY()
{
	return (GetPositionY() - m_mapMgr->_minY) / m_mapMgr->_sizeY;
}

//-----------------------------------------------------------------------------
// Checks if there is reputation for faction
bool Object::HasReputationForFaction( uint8 FactId )
{
	for (int iI = 0; iI < 64; iI++ )
		if ( m_reputation[iI] == FactId ) return true;

	return false;
}

//-----------------------------------------------------------------------------
// Sets reputation for faction. Also adds it to new field
// if that faction is not declared. Result says if the setting
// was successeful of not.
bool Object::SetReputationForFaction( uint8 FactId, uint32 RepVal )
{
	int id = -1, free = -1;

	for (int iI = 0; iI < 64; iI++ )
	{
		if ( m_reputation[iI] == FactId )			   { id   = iI; break; }
		if (( m_reputation[iI] == 0 ) && (free == -1)) { free = iI;}
	}

	if (id == -1) 
	{
		if (free == -1)
			return false;

		id = free;
	}

	m_reputationValues[id] = RepVal;
	return true;
}

//-----------------------------------------------------------------------------
// Gets the reputation for a specified faction
uint32 Object::GetReputationForFaction( uint8 FactId )
{
	int id = -1;

	for (int iI = 0; iI < 64; iI++ )
		if ( m_reputation[iI] == FactId ) { id = iI; break; }

	if (id == -1) 
	{
		Log::getSingleton().outError( "Trying to retreive reputation for a non-existing faction '%d'.", FactId );
		return 0;
	}

	return m_reputationValues[id];
}

//--- END ---