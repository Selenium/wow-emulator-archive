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
#include "GameObject.h"
#include "UpdateMask.h"
#include "Opcodes.h"
#include "WorldPacket.h"
#include "WorldSession.h"
#include "World.h"
#include "Quest.h"
#include "ObjectMgr.h"
#include "Database/DatabaseEnv.h"
#include "LootMgr.h"
#include "EventMgr.h"

GameObject::GameObject() : Object()
{
	m_objectType |= TYPE_GAMEOBJECT;
	m_objectTypeId = TYPEID_GAMEOBJECT;

	m_valuesCount = GAMEOBJECT_END;
	m_RespawnTimer = 0;


	sEventMgr.AddEvent(this, &GameObject::Update, (uint32)100, EVENT_GAMEOBJECT_UPDATE, 100, 0);
}
GameObject::~GameObject()
{
	sEventMgr.RemoveEvents(this);
}

void GameObject::Create(uint32 guidlow,uint32 mapid, float x, float y, float z, float ang)
{
	Object::_Create(guidlow, 0xF0007000, mapid, x, y, z, ang);

	SetFloatValue( GAMEOBJECT_POS_X, x);
	SetFloatValue( GAMEOBJECT_POS_Y, y );
	SetFloatValue( GAMEOBJECT_POS_Z, z );
	SetFloatValue( GAMEOBJECT_FACING, ang );
	SetUInt32Value( GAMEOBJECT_TIMESTAMP, (uint32)time(NULL));
}

void GameObject::Create( uint32 guidlow, uint32 display_id, uint8 state, uint32 obj_field_entry, float scale, uint16 type,
						uint16 faction, uint32 mapid, float x, float y, float z, float ang )
{
	printf("create game object\n");
	Object::_Create(guidlow, 0xF0007000, mapid, x, y, z, ang);

	SetUInt32Value( OBJECT_FIELD_ENTRY, obj_field_entry ); // no idea yet
	SetFloatValue( OBJECT_FIELD_SCALE_X, scale );
	SetUInt32Value( GAMEOBJECT_DISPLAYID, display_id );
	SetUInt32Value( GAMEOBJECT_STATE, state  );
	SetUInt32Value( GAMEOBJECT_TYPE_ID, type  );
	SetUInt32Value( GAMEOBJECT_TIMESTAMP, (uint32)time(NULL)); // ??
	SetFloatValue( GAMEOBJECT_POS_X, x);
	SetFloatValue( GAMEOBJECT_POS_Y, y );
	SetFloatValue( GAMEOBJECT_POS_Z, z );
	SetFloatValue( GAMEOBJECT_FACING, ang );
	SetFloatValue( GAMEOBJECT_FLAGS, 0 );
}

void GameObject::Update(uint32 p_time)
{
	WorldPacket data;
	// Respawn Timer
	if(m_RespawnTimer > 0){
		if(m_RespawnTimer > p_time)
			m_RespawnTimer -= p_time;
		else{
			if(!this->IsInWorld()){
				AddToWorld();
			}

			data.Initialize(SMSG_GAMEOBJECT_SPAWN_ANIM);
			data << GetGUID();
			SendMessageToSet(&data,true);

			SetUInt32Value(GAMEOBJECT_STATE,1);
			m_RespawnTimer = 0;
		}
	}
}

void GameObject::Despawn(uint32 time)
{
	WorldPacket data;
	RemoveFromWorld();

	data.Initialize(SMSG_GAMEOBJECT_DESPAWN_ANIM);
	data << GetGUID();
	SendMessageToSet(&data,true);

	m_RespawnTimer = time;
}

bool GameObject::FillLoot(WorldPacket *data, Player* pl)
{
	uint64 guid;
	uint16 tmpDataLen;
	uint8 i, tmpItemsCount = 0;

	guid = this->GetUInt64Value(OBJECT_FIELD_ENTRY);

	GameObject* pCreature = objmgr.GetObject<GameObject>(guid);
	if (!pCreature)
		return false;

	pl->SetLootGUID(guid);
	std::map<uint32, QuestLogEntry *>::iterator q;
	std::map<uint32, uint32>::const_iterator lootitr, propitr;
	for(lootitr = pCreature->getLootBegin(); lootitr != pCreature->getLootEnd(); lootitr++)
	{
		if (lootitr->second > 0)
		{
			ItemPrototype* itemProto = objmgr.GetItemPrototype(lootitr->first);
			if (itemProto)
			{
				if (itemProto->Class == 12)
				{
					for( q = pl->QuestsBegin(); q != pl->QuestsEnd();q++)
					{
						std::map<uint32, uint8>::const_iterator it;
						for (it = q->second->GetQuest()->GetTurninItemsBegin(); it != q->second->GetQuest()->GetTurninItemsEnd();it++)
						{
							if ((it->first == itemProto->ItemId) && (pl->Find_QLE(q->second->GetQuest()->GetID())) && (lootitr->second < it->second))
							{
								pCreature->setLootid(tmpItemsCount,lootitr->first);
								tmpItemsCount++;
							}
						}

					}
				}
				else
				{	
					printf("setting loot id %u to %u\n",tmpItemsCount,lootitr->first);
					pCreature->setLootid(tmpItemsCount,lootitr->first);
					tmpItemsCount++;
				}
			}
			else
				printf("item id %u not found\n",lootitr->first);
		}
	}

	tmpDataLen = 14 + tmpItemsCount*22;

	data->Initialize( SMSG_LOOT_RESPONSE );

	uint32 id = 0;
	uint32 amt = 0;
	*data << guid;
	// 0 =  Premission Deined | 1 = 4 = 5 = 2 = Death | 3 = Fishing
	*data << uint8(1); //loot Type
	*data << uint32(pCreature->getLootMoney());
	*data << uint8(tmpItemsCount);
	for(i = 0; i < tmpItemsCount; i++)
	{
		id = pCreature->getLootid(i);
		amt = pCreature->getLootAmt(id);
		if (amt > 0)
		{
			ItemPrototype* itemProto = objmgr.GetItemPrototype(id);
			if (itemProto)
			{
				if (itemProto->Class == 12)
				{
					for( q = pl->QuestsBegin(); q != pl->QuestsEnd();q++)
					{
						std::map<uint32, uint8>::const_iterator it;
						for (it = q->second->GetQuest()->GetTurninItemsBegin(); it != q->second->GetQuest()->GetTurninItemsEnd();it++)
						{
							if ((it->first == itemProto->ItemId) && (pl->Find_QLE(q->second->GetQuest()->GetID())) && (lootitr->second < it->second))
							{
								*data << uint8(i+1); //Item Slot, must be > 0
								*data << uint32(id); //item ID
								*data << uint32(amt); //quantity
								*data << uint32(itemProto->DisplayInfoID); //Display IconID
								*data << uint32(0) << uint32(pCreature->getLootProp(id)) << uint8(0);
							}
						}

					}
				}
				else
				{	
					*data << uint8(i+1); //Item Slot, must be > 0
					*data << uint32(id); //item ID
					*data << uint32(amt); //quantity
					*data << uint32(itemProto->DisplayInfoID); //Display IconID
					*data << uint32(0) << uint32(pCreature->getLootProp(id)) << uint8(0);
				}
			}
			else
				printf("item id %u not found\n",lootitr->first);
		}
	}
	return true;
}
void GameObject::_LoadLoot()
{
	LootTable* tb = lootmgr.getLoot(GetUInt32Value(OBJECT_FIELD_ENTRY));
	if (!tb)
		lootmgr.loadLoot(GetUInt32Value(OBJECT_FIELD_ENTRY));

}
void GameObject::generateLoot()
{
	uint32 cnt = 1;
	mItems.clear();
	mProps.clear();
	LootTable* tb = lootmgr.getLoot(GetUInt32Value(OBJECT_FIELD_ENTRY));
	if (tb)
	{
		list<uint32>::iterator i,k;
		list<float>::iterator j,m;
		j = tb->mChance.begin();
		for(i = tb->mItems.begin(); i != tb->mItems.end(); i++)
		{
			cnt = 1;
			if ((*j) > 100)
			{
				cnt = (*j) / 100;
				(*j) -= cnt*100;
				if ((*j) == 0)
					(*j) = 100;
			}
			if (((float)(rand()%10000)) < ((*j)* 100.0f))
			{
				mItems[(*i)] = cnt;
				ItemPrototype *it = objmgr.GetItemPrototype(*i);
				if (it->Field109 > 0)
				{
					LootPropTable * props = lootmgr.getLootProp(*i);
					if (props)
					{
						m = props->mChance.begin();
						for (k = props->mProps.begin(); k != props->mProps.end();k++)
						{
							if (((float)(rand()%10000)) < ((*m)* 100.0f))
							{
								mProps[*i] = (*k);
								break;
							}
							else
							{
								mProps[*i] = 0;
							}
							m++;
						}
					}
				}
				else
				{
					mProps[*i] = 0;
				}
			}
			j++;
		}
	}
	m_lootMoney = 5;
}

void GameObject::SaveToDB()
{
	std::stringstream ss;
	ss << "DELETE FROM gameobjects WHERE id=" << GetGUIDLow();
	sDatabase.Execute(ss.str().c_str());

	ss.rdbuf()->str("");
	ss << "INSERT INTO gameobjects (id, zoneid, mapId, positionX, positionY, positionZ, orientation, data) VALUES ( "
		<< GetGUIDLow() << ", "
		<< GetZoneId() << ", "
		<< GetMapId() << ", "
		<< m_positionX << ", "
		<< m_positionY << ", "
		<< m_positionZ << ", "
		<< m_orientation << ", '";

	for( uint16 index = 0; index < m_valuesCount; index ++ )
		ss << GetUInt32Value(index) << " ";

	ss << "' )";

	sDatabase.Execute( ss.str( ).c_str( ) );
}


void GameObject::LoadFromDB(uint32 guid)
{
	std::stringstream ss;
	ss << "SELECT * FROM gameobjects WHERE id=" << guid;

	QueryResult *result = sDatabase.Query( ss.str().c_str() );
	ASSERT(result);

	Field *fields = result->Fetch();

	Create(fields[0].GetUInt32(),fields[6].GetUInt32(), fields[1].GetFloat(), fields[2].GetFloat(), fields[3].GetFloat(), fields[4].GetFloat());

	m_zoneId = fields[5].GetUInt32();

	LoadValues(fields[7].GetString());

	delete result;
}

void GameObject::DeleteFromDB()
{
	char sql[256];

	sprintf(sql, "DELETE FROM gameobjects WHERE id=%u", GetGUIDLow());
	sDatabase.Execute(sql);
}

uint32 GameObject::getLootAmt(uint32 id) {
	std::map<uint32, uint32>::const_iterator itr = mItems.find( id );
	if( itr != mItems.end( ) )
		return itr->second;
	return NULL;
}

uint32 GameObject::getLootProp(uint32 id) {
	std::map<uint32, uint32>::const_iterator itr = mProps.find( id );
	if( itr != mProps.end( ) )
		return itr->second;
	return NULL;
}

void GameObject::setLootAmt(uint32 id, uint32 amt) {
	std::map<uint32, uint32>::iterator itr = mItems.find( id );
	if( itr != mItems.end( ) )
		itr->second = amt;
}

