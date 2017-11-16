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

#ifndef WOWSERVER_GAMEOBJECT_H
#define WOWSERVER_GAMEOBJECT_H

#include "Object.h"

struct GameObjectInfo
{
	uint32 ID;
	uint32 Size;
	uint32 Type;
	uint32 DisplayID;
	std::string Name;
	uint32 sound0;
	uint32 sound1;
	uint32 sound2;
	uint32 sound3;
	uint32 sound4;
	uint32 sound5;
	uint32 sound6;
	uint32 sound7;
	uint32 sound8;
	uint32 sound9;
	uint32 Unknown1;
	uint32 Unknown2;
	uint32 Unknown3;
	uint32 Unknown4;
	uint32 Unknown5;
	uint32 Unknown6;
};

enum GAMEOBJECT_TYPES
{
    GAMEOBJECT_TYPE_DOOR               = 0,
    GAMEOBJECT_TYPE_BUTTON             = 1,
    GAMEOBJECT_TYPE_QUESTGIVER         = 2,
    GAMEOBJECT_TYPE_CHEST              = 3,
    GAMEOBJECT_TYPE_BINDER             = 4,
    GAMEOBJECT_TYPE_GENERIC            = 5,
    GAMEOBJECT_TYPE_TRAP               = 6,
    GAMEOBJECT_TYPE_CHAIR              = 7,
    GAMEOBJECT_TYPE_SPELL_FOCUS        = 8,
    GAMEOBJECT_TYPE_TEXT               = 9,
    GAMEOBJECT_TYPE_GOOBER             = 10,
    GAMEOBJECT_TYPE_TRANSPORT          = 11,
    GAMEOBJECT_TYPE_AREADAMAGE         = 12,
    GAMEOBJECT_TYPE_CAMERA             = 13,
    GAMEOBJECT_TYPE_MAP_OBJECT         = 14,
    GAMEOBJECT_TYPE_MO_TRANSPORT       = 15,
    GAMEOBJECT_TYPE_DUEL_ARBITER       = 16,
    GAMEOBJECT_TYPE_FISHINGNODE        = 17,
    GAMEOBJECT_TYPE_RITUAL             = 18,
    GAMEOBJECT_TYPE_MAILBOX            = 19,
    GAMEOBJECT_TYPE_AUCTIONHOUSE       = 20,
    GAMEOBJECT_TYPE_GUARDPOST          = 21,
    GAMEOBJECT_TYPE_SPELLCASTER        = 22,
    GAMEOBJECT_TYPE_MEETINGSTONE       = 23,
    GAMEOBJECT_TYPE_FLAGSTAND          = 24,
    GAMEOBJECT_TYPE_FISHINGHOLE        = 25,
    GAMEOBJECT_TYPE_FLAGDROP           = 26,
};

class GameObject : public Object
{
public:
    GameObject( );
    ~GameObject( );

    void Create ( uint32 guidlow, uint32 display_id, uint8 state, uint32 obj_field_entry, float scale, uint16 type, uint16 faction, uint32 mapid, float x, float y, float z, float ang );
	void Create (uint32 guidlow,uint32 mapid, float x, float y, float z, float ang);

    void Update(uint32 p_time);

    void Despawn(uint32 time);
    bool FillLoot(WorldPacket *data, Player* pl);
    void generateLoot();
    uint32 getLootMoney() { return m_lootMoney; }
    void setLootMoney(uint32 amount) { m_lootMoney = amount; }
	void setLootid(uint32 cnt, uint32 id) {lootSlots[cnt] = id;}
	uint32 getLootid(uint32 id) {return lootSlots[id];}
	std::map<uint32, uint32>::const_iterator getLootBegin() { return mItems.begin();}
	std::map<uint32, uint32>::const_iterator getLootEnd() { return mItems.end();}
	uint32 getLootAmt(uint32 id);
	uint32 getLootProp(uint32 id);
	void setLootAmt(uint32 id, uint32 amt);

    // Serialization
    void SaveToDB();
    void LoadFromDB(uint32 guid);
    void DeleteFromDB();

protected:

    uint32 m_RespawnTimer;
    /// Looting
    uint32 m_lootMoney;
	std::map<uint32,uint32>mItems;
	std::map<uint32,uint32>mProps;
	uint32 lootSlots[12];
    void _LoadLoot();
};

#endif

