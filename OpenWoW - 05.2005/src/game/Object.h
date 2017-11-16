//////////////////////////////////////////////////////////////////////
//  Object
//
//  ??
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

#ifndef WOWPYTHONSERVER_OBJECT_H
#define WOWPYTHONSERVER_OBJECT_H

#include "Common.h"
#include "UpdateMask.h"
#include "GameClient.h"

enum TYPE {
	TYPE_OBJECT             = 1,
	TYPE_ITEM               = 2,
	TYPE_CONTAINER          = 4,
	TYPE_UNIT               = 8,
	TYPE_PLAYER             = 16,
	TYPE_GAMEOBJECT	        = 32,
	TYPE_DYNAMICOBJECT      = 64,
	TYPE_CORPSE             = 128,
	TYPE_AIGROUP            = 256,
	TYPE_AREATRIGGER        = 512
};

/**
 * Every object in the world is given a unique identifier.
 * Structure size MUST be 8 bytes (e.g. 64 bits)
 */
struct guid
{
        /// Object serial number
        uint32 sno;
        /// Object type
        uint32 type;

	// Construct an unassigned guid
	guid ()
	{ Set (0, 0); }

	// Construct an guid with just a serial number
	guid (uint32 isno)
	{ Set (isno, 0); }

	// Construct an complete guid
	guid (uint32 isno, uint32 itype)
	{ Set (isno, itype); }

	inline void Set (uint32 isno, uint32 itype)
	{ sno = isno; type = itype; }

	inline bool Assigned ()
	{ return (sno != 0) || (type != 0); }

	inline bool operator == (guid &other)
	{ return (sno == other.sno) && (type == other.type); }
};

struct UpdateMask;
struct NetworkPacket;
class GameClient;
//====================================================================
//  Object
//  Base object for every item, unit, player, corpse, container, etc
//
//====================================================================
class Object
{
        friend class WorldServer;
public:
        Object ();
        virtual ~Object ();

        virtual void Update (float time) { (void)time; }

        virtual void Create (uint32 guidlow);
        virtual void Create (uint32 guidlow, float x, float y, float z, float ang);

        inline guid getGUID () { return *m_guid; }

        inline uint8 getObjectTypeId() { return m_objectTypeId; };

        // These functions send a specific type of A9 packet based on current state
        void UpdateObject (GameClient *pSelf = NULL);
        void CreateObject (uint32 flags, GameClient *pSelf = NULL);

        // These functions build a specific type of A9 packet
        virtual void UpdateObject(UpdateMask* updateMask, NetworkPacket * p_data);
        virtual void UpdateMovement(uint32 flags, NetworkPacket * p_data);
        virtual void CreateObject(UpdateMask* updateMask, NetworkPacket * p_data, uint32 flags);

        // These functions construct a specific block of a specific A9 packet
        virtual void BuildMoveUpdate (uint32 flags, uint32 flags2, uint8 * data, int* length);
        virtual void BuildUpdateBlock(UpdateMask *updateMask, uint8 * data, int* length);

        // fill UpdateValues with data from a space seperated string of uint32s
        virtual void LoadUpdateValues(uint8* data);

        void BuildHeartBeat(NetworkPacket *data);
        void TeleportAck(NetworkPacket *data, float x, float y, float z);

        bool setPosition (uint8 *data, bool allowPorting = false);
        bool setPosition (float newX, float newY, float newZ, float newOrientation, bool allowPorting = false);
        float getPositionX () const;
        float getPositionY () const;
        float getPositionZ () const;
        float getOrientation () const;
        void getPosition (uint8 *data) const;

        inline void setMapId(uint16 newMap) { m_mapId = newMap; }
        inline void setZone(uint16 newZone) { m_zoneId = newZone; }
        inline const uint16 & getMapId () const { return m_mapId; }
        inline const uint16 & getZone () const { return m_zoneId; }

        inline bool setUpdateMaskBit (const uint16 &index)
	{
                if (!getUpdateMaskBit (index))
		{
                        m_updateMask [index >> 3] |= 1 << (index & 0x7);
                        m_updateMaskSum ++;
                        if ((index >> 5) + 1 > m_updateMaskBlockCount)
                                m_updateMaskBlockCount = ((index >> 5) + 1);
                        return true;
                }
                return false;
        }
        inline bool unsetUpdateMaskBit (const uint16 &index)
	{
                if (getUpdateMaskBit (index))
		{
                        m_updateMaskSum --;
                        m_updateMask [index >> 3] ^= 1 << (index & 0x7);
                        return true;
                }
                return false;
        }

        inline void clearUpdateMask ()
	{
                m_updateMaskBlockCount = 0;
                m_updateMaskSum = 0;
                memset (m_updateMaskBlocks, 0, sizeof (m_updateMaskBlocks));
        }

        inline void setUpdateValue (const uint16 &index, const uint32 &value)
	{
                m_updateValues[ index ] = value;
                setUpdateMaskBit (index);
        }
        inline void setUpdateValue (const uint16 &index, const uint32 &value, void * updatemask)
	{
                m_updateValues[ index ] = value;
                setUpdate (index, updatemask);
        }

        inline void setUpdateFloatValue (const uint16 &index, const float &value)
	{
                m_updateFloats[ index ] = value;
                setUpdateMaskBit (index);
        }

        inline void setUpdateFloatValue (const uint16 &index, const float &value, void * updatemask)
	{
                m_updateFloats[ index ] = value;
                setUpdate (index, updatemask);
        }


        inline void setUpdate (const uint16 &index, void * updatemask)
	{
                ((uint8 *)updatemask)[ index >> 3 ] |= 1 << (index & 0x7);
        }

        inline const bool getUpdateMaskBit (const uint16 &index) const
	{
                return (m_updateMask[ index >> 3 ] & (1 << (index & 0x7)))!=0;
        }
        inline const uint32 getUpdateValue (const uint16 &index) const
	{ return m_updateValues[ index ]; }
        inline const float getUpdateFloatValue (const uint16 &index) const
	{ return m_updateFloats[ index ]; }

        inline float getDistanceSq(Object* pObj)
	{
                float x  = pObj->getPositionX() - getPositionX();
                float y  = pObj->getPositionY() - getPositionY();
                float z  = pObj->getPositionZ() - getPositionZ();
                return ((x*x) + (y*y) + (z*z));
        };

        // In Range Object management
        void UpdateInRangeSet();    // checks if objects in the set are no longer in range
        inline bool IsInRangeSet(Object* pObj) { return !(m_objectsInRange.find(pObj) == m_objectsInRange.end()); }
        inline void AddInRangeObject(Object* pObj) { m_objectsInRange.insert(pObj); }
        inline void RemoveInRangeObject(Object* pObj) { m_objectsInRange.erase(pObj); }
        inline void ClearInRangeSet() { m_objectsInRange.clear(); }
        void SendMessageToSet(NetworkPacket *data, bool pToSelf);

protected:

        // <WoW Chile Dev Team> Start Change
        // Respawn Coordenates,Yum...
        float respawn_cord[3][3];
        // <WoW Chile Dev Team> Finish Change

        // pretty much just guessing what would be common in all objects
        uint16 m_objectType;		// Types.  Bitmasked together by subclasses
        uint8 m_objectTypeId;	// 4 = player

        guid *m_guid; // now references m_updateValues;

        uint16 m_zoneId;
        uint16 m_mapId;

        float m_positionX;
        float m_positionY;
        float m_positionZ;

        float m_orientation;

        float m_lastUpdateTime;
        //    float m_maxHorizontalSpeed;
        float m_minZ;

        union
        {
                uint32 m_updateValues [UPDATE_BLOCKS];
                float m_updateFloats [UPDATE_BLOCKS];
        };
        union
        {
                uint32 m_updateMaskBlocks [PLAYER_BLOCKS];
                uint8 m_updateMask [PLAYER_BLOCKS * 4];
        };
        uint8 m_updateMaskBlockCount;
        uint16 m_updateMaskSum;

        // Set of Objects receiving updates from this object
        std::set<Object*> m_objectsInRange;
};

#endif

