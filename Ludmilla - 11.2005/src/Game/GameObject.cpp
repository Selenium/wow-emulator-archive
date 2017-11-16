#include "StdAfx.h"

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

GameObject::GameObject() : Object()
{
    mQuestIds.clear();
    mInvolvedQuestIds.clear();

    m_objectType |= TYPE_GAMEOBJECT;
    m_objectTypeId = TYPEID_GAMEOBJECT;

    m_valuesCount = GAMEOBJECT_END;
    m_RespawnTimer = 0;
    m_gold = 0;
    m_ItemCount = 0;

	item_list.clear();
}


void GameObject::Create( uint32 guidlow, uint32 display_id, uint8 state, uint32 obj_field_entry, float scale, uint16 type,
    uint16 faction, uint32 mapid, float x, float y, float z, float ang )
{

	GameobjectTemplate *goT = objmgr.GetGameobjectTemplate (obj_field_entry);

    //printf("create game object\n");
    Object::_Create(guidlow, HIGHGUID_GAMEOBJECT, mapid, x, y, z, ang);

    SetUInt32Value (OBJECT_FIELD_ENTRY, obj_field_entry);
    SetFloatValue (OBJECT_FIELD_SCALE_X, goT->Size);
	//SetUInt32Value (OBJECT_FIELD_PADDING, 0xEEEEEEEE);

	SetUInt32Value (GAMEOBJECT_DISPLAYID, goT->Model);
    SetUInt32Value (GAMEOBJECT_STATE, state);
    SetUInt32Value (GAMEOBJECT_TYPE_ID, goT->GType);
    SetUInt32Value (GAMEOBJECT_TIMESTAMP, (uint32)0);
    
	SetFloatValue (GAMEOBJECT_POS_X, x);
    SetFloatValue (GAMEOBJECT_POS_Y, y );
    SetFloatValue (GAMEOBJECT_POS_Z, z );
	SetFloatValue (GAMEOBJECT_FACING, ang);
	
	SetUInt32Value (GAMEOBJECT_ROTATION, 0);
	SetUInt32Value (GAMEOBJECT_ROTATION+1, 0);
	SetUInt32Value (GAMEOBJECT_ROTATION+2, 0);
	SetUInt32Value (GAMEOBJECT_ROTATION+3, 0);

    SetFloatValue (GAMEOBJECT_FLAGS, goT->Flags);
	SetFloatValue (GAMEOBJECT_FACTION, goT->Faction);
	SetFloatValue (GAMEOBJECT_LEVEL, goT->Level);

}

void GameObject::Update (int32 p_time)
{
    // Respawn Timer
    if (m_RespawnTimer > 0)
	{
        if (m_RespawnTimer > p_time)
			m_RespawnTimer -= p_time;
        else
		{
            if(!this->IsInWorld())
			{
                PlaceOnMap();
			}

			WorldPacket data;
            data.Initialize(SMSG_GAMEOBJECT_SPAWN_ANIM);
            data << GetGUID();
            SendMessageToSet(&data,true);

            SetUInt32Value (GAMEOBJECT_STATE,1);
            m_RespawnTimer = 0;
        }
    }
}

void GameObject::Despawn(uint32 time)
{
    RemoveFromMap();

	WorldPacket data;
    data.Initialize(SMSG_GAMEOBJECT_DESPAWN_ANIM);
    data << GetGUID();
    SendMessageToSet(&data,true);

    m_RespawnTimer = time;
    m_ItemCount = 0;
	SetUInt32Value (GAMEOBJECT_STATE, 0);
}
// --- GO LOOTING --------------------------------------------------------------------
void GameObject::_generateLoot()
{
    //gold = 10;
	item_list.clear();
    uint32 go_entry = GetEntry();

	LootGOTemplateVectorMap::iterator iter = objmgr.m_lootGOTemplates.find (go_entry);
	if (iter == objmgr.m_lootGOTemplates.end()) {
		Log::getSingleton().outDebug ("GO LOOTGEN: No loot template for GO %d", go_entry);
		return;
	}
	
	LootGOTemplateVector * pvec = iter->second;
	uint32	itemId, lootCount = 0;
	float	chance;
	MT		randomizer;
	ItemPrototype * itemProto;

	for (uint32 i = 0; i < pvec->size(); i++)
	{
		itemId = (*pvec)[i].ItemId;
		chance = (*pvec)[i].Chance;

		itemProto = objmgr.GetItemPrototype (itemId);

		// Skip quest items completely! Need to check quest number and
		// make personal quest items list in loot for every group member
		if (itemProto->Class == 12) {
			Log::getSingleton().outDebug ("GO LOOTGEN: Item=%d Chance=%.6f GO=%d - skipped quest item", itemId, chance, go_entry);
			continue;
		}
		///////////////////////////////

		int count = 1;
				
		if (chance == 0.0f) continue;

		while (chance > 100.0f) {
			count++;
			chance -= 100.0f;
		}

		if (randomizer.randf() < chance / 100.0f) {
			uint32 displayId = itemProto->DisplayInfoID;
			addItem (itemId, (uint32)1, displayId);
			Log::getSingleton().outDebug ("GO LOOTGEN: Item=%d Model=%d Chance=%.6f Object=%d - ADDED To Loot", itemId, displayId, chance, go_entry);
			lootCount++;
		} else {
			//Log::getSingleton().outDebug ("LOOTGEN: Item=%d Chance=%.6f Creature=%d - skip", itemId, chance, GetEntry());
		}
	}
}
// -- FILLING GO LOOT ----------------------------------------------------------------
bool GameObject::FillLoot(WorldPacket *data)
{

	/*
	0:18:42 - SERVER >>> OpCode=0x160 SMSG_LOOT_RESPONSE, size=62

      0- 1- 2- 3- 4- 5- 6- 7- | 8- 9- A- B- C- D- E- F- | 01234567 89ABCDEF
0000: 00#3C#60#01 AE A8 07 00 | 00 40 00 F0 01 00 00 00 | .<`..... .@......
0010: 00 02 00 11 03 00 00 03 | 00 00 00 AD 1C 00 00 00 | ........ ........
0020: 00 00 00 00 00 00 00 00 | 01 94 09 00 00 02 00 00 | ........ ........
0030: 00 49 1C 00 00 00 00 00 | 00 00 00 00 00 00       | .I...... ......  
*/

    uint32 gold = 10;
	GameobjectTemplate *goT = objmgr.GetGameobjectTemplate (GetEntry());

    if( goT->Faction == 94 )
    {
		// Loot generation
		_generateLoot();

		Log::getSingleton().outDebug ("GO LOOTGEN: Sending data ...");
		Log::getSingleton().outDebug ("GO LOOTGEN: Items to send: %d, Guid: %d", item_list.size(), GetGUID());

		*data << GetGUID();
		*data << uint8(0x01);
		*data << uint32(gold);			  // Loot Money
		*data << uint8(item_list.size()); // item Count
		
		for(uint8 i = 0; i < item_list.size(); i++)
		{
			if (item_list[i].amount > 0) 
			{
			*data << uint8(i);						  // slot, must be greater than zero
			*data << uint32(item_list[i].itemid);     // item id
			*data << uint32(item_list[i].amount);	  // quantity
			*data << uint32(item_list[i].display_id); // iconid
			*data << uint8(0) << uint32(0) << uint32(0);
			
			Log::getSingleton().outDebug ("GO LOOTGEN: Sent to Player: Slot=%d Item=%d Count=%d Model=%d", i, item_list[i].itemid, item_list[i].amount, item_list[i].display_id);
			}
		}
	
	return true;
    }
    return false;
}
// -----------------------------------------------------------------------------

void GameObject::SaveToDB()
{
    std::stringstream ss;
    ss << "DELETE FROM gameobjects WHERE guid=" << GetGUIDLow();
    sDatabase.Execute(ss.str().c_str());

    ss.rdbuf()->str("");
    ss << "INSERT INTO gameobjects (guid, entry, zoneId, mapId, "
		"positionX, positionY, positionZ, orientation, data) VALUES ( "
        << GetGUIDLow() << ", " << GetEntry() << ", "
        << GetZoneId() << ", " << GetMapId() << ", "
        << m_positionX << ", "
        << m_positionY << ", "
        << m_positionZ << ", "
        << m_orientation << ", '";

    for( uint16 index = 0; index < m_valuesCount; index ++ )
        ss << GetUInt32Value(index) << " ";

    ss << "' )";

    sDatabase.Execute( ss.str( ).c_str( ) );
}

void GameObject::LoadFromDB(uint32 lowguid)
{
    std::stringstream ss;
	ss << "SELECT positionX, positionY, positionZ, orientation, "
		"zoneId, mapId, entry FROM gameobjects "
		"WHERE guid=" << lowguid;

    QueryResult *result = sDatabase.Query( ss.str().c_str() );
    ASSERT(result);

    Field *fields = result->Fetch();
	
	int Entry = fields[6].GetUInt32();
	GameobjectTemplate *goT = objmgr.GetGameobjectTemplate (Entry);
	if (goT == NULL) return;

	int		MapId = fields[5].GetUInt32();
	float	X = fields[0].GetFloat();
	float	Y = fields[1].GetFloat();
	float	Z = fields[2].GetFloat();
	float	Orient = fields[3].GetFloat();

    Create (lowguid, goT->Model, 1,	// lowguid, display_id, state
		goT->Entry, 1.0f,			// obj_field_entry, scale
		(uint16)goT->GType, (uint16)goT->Faction,	// gtype, faction
		MapId, X, Y, Z, Orient);

	m_name = goT->Name;
    m_zoneId = fields[4].GetUInt32();

	//std::string data = fields[7].GetString();
    //LoadValues (data.c_str());

	delete result;

	_LoadQuests();
}

void GameObject::DeleteFromDB()
{
	std::stringstream ss;
    ss << "DELETE FROM gameobjects WHERE guid=" << GetGUIDLow();
    sDatabase.Execute(ss.str().c_str());
}

void GameObject::_LoadQuests()
{
    // clean quests

    mQuestIds.clear();
	mInvolvedQuestIds.clear();

    std::stringstream query;
    query << "SELECT * FROM objectquestrelation WHERE objectId=" << GetUInt32Value(OBJECT_FIELD_ENTRY) << " ORDER BY questId";

    QueryResult *result = sDatabase.Query( query.str().c_str() );
    if(result)
    {
        do
        {
            Field *fields = result->Fetch();
            addQuest (fields[1].GetUInt32());
        }
        while( result->NextRow() );

        delete result;
    }

	// -------------------- Involved quests ----------
	//
    std::stringstream query1;					    
	query1 << "SELECT * FROM objectinvolvedrelation WHERE objectId=" << GetUInt32Value (OBJECT_FIELD_ENTRY) << " ORDER BY questId";

    result = sDatabase.Query( query1.str().c_str() );
    if(result)
    {
        do
        {
            Field *fields = result->Fetch();
			uint32 inv = fields[1].GetUInt32();

			Quest *pQuest = objmgr.GetQuest( inv );
			if (!pQuest) continue;
			//
			// Here be something?
			//
        }
        while( result->NextRow() );

        delete result;
    }
}

bool GameObject::hasQuest(uint32 quest_id)
{
    for( std::list<uint32>::iterator i = mQuestIds.begin( ); i != mQuestIds.end( ); ++ i )
    {
        if (*i == quest_id)
            return true;
    }

    return false;
}

bool GameObject::hasInvolvedQuest(uint32 quest_id)
{
    for( std::list<uint32>::iterator i = mInvolvedQuestIds.begin( ); i != mInvolvedQuestIds.end( ); ++ i )
    {
        if (*i == quest_id)
            return true;
    }

    return false;
}

void GameObject::managePlayerQuests(Player *pPlayer)
{
    uint32 quest_id;
    uint32 status;
    Quest *pQuest;

    for( std::list<uint32>::iterator i = mQuestIds.begin( ); i != mQuestIds.end( ); ++ i )
    {
        quest_id = *i;
        status = pPlayer->getQuestStatus(quest_id);
        pQuest = objmgr.GetQuest(quest_id);

		if ( pQuest == NULL ) continue;

		if ( !pQuest->QuestPreReqSatisfied( pPlayer ) || 
			 !pQuest->QuestIsCompatible( pPlayer ) ||
			  pQuest->QuestRewardIsTaken( pPlayer ) 
			) continue;


		if ( status == QUEST_STATUS_COMPLETE ) 
		{
			QuestPacketHandler::getSingleton().SendRewardToPlayer( pPlayer->GetSession(), pQuest, GetGUID() );
			return;
		}

		if ( status == QUEST_STATUS_AVAILABLE )
		{
			QuestPacketHandler::getSingleton().SendShortQuestDetailsToPlayer( pPlayer->GetSession(), pQuest, GetGUID() );
			return;
		}


        if ( status == QUEST_STATUS_NONE )
        {
			if (!pQuest->QuestLevelSatisfied( pPlayer ))
			{
                pPlayer->addNewQuest(quest_id, QUEST_STATUS_UNAVAILABLE );
			}
            else
			{
                pPlayer->addNewQuest(quest_id, QUEST_STATUS_AVAILABLE );
				QuestPacketHandler::getSingleton().SendShortQuestDetailsToPlayer( pPlayer->GetSession(), pQuest, GetGUID() );
				return;
			}
        }
    }

   // Involvers

   for( std::list<uint32>::iterator i = mInvolvedQuestIds.begin( ); i != mInvolvedQuestIds.end( ); ++ i )
    {
        quest_id = *i;
        status = pPlayer->getQuestStatus(quest_id);
        pQuest = objmgr.GetQuest(quest_id);

		if ( status == QUEST_STATUS_INCOMPLETE )
		{
			if ( pQuest->HasBehavior( QUEST_BEHAVIOR_DELIVER | QUEST_BEHAVIOR_SPEAKTO ) &&
				(pPlayer->HasItemInBackpack(pQuest->m_srcItem)) )
			{
				QuestPacketHandler::getSingleton().SendRewardToPlayer( pPlayer->GetSession(), pQuest, GetGUID() );
				return;
			} else
			if ( pQuest->HasBehavior( QUEST_BEHAVIOR_SPEAKTO) )
			{
				QuestPacketHandler::getSingleton().SendRewardToPlayer( pPlayer->GetSession(), pQuest, GetGUID() );
				return;
			} else
			{
				QuestPacketHandler::getSingleton().SendRequestItemsToPlayer( pPlayer->GetSession(), pQuest, GetGUID(), false);
				return;
			}
		}
	}
}