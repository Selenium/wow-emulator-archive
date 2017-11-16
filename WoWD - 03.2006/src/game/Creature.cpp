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
#include "Database/DatabaseEnv.h"
#include "WorldPacket.h"
#include "WorldSession.h"
#include "World.h"
#include "UpdateData.h"
#include "ObjectMgr.h"
#include "Creature.h"
#include "Quest.h"
#include "Player.h"
#include "Opcodes.h"
#include "Stats.h"
#include "Log.h"
#include "ZoneMapper.h"
#include "QuestMgr.h"
#include "LootMgr.h"
#include "EventMgr.h"

#define M_PI       3.14159265358979323846

Creature::Creature() : Unit()
{
	m_quests = NULL;

	m_corpseDelay = 45000;
	m_respawnDelay = 25000;

	m_respawnTimer = 0;
	m_deathTimer = 0;
	m_moveTimer = 0;

	m_valuesCount = UNIT_END;

	itemcount = 0;
	memset(item_list, 0, 8*128);

	m_regenTimer=0;

	sEventMgr.AddEvent(this, &Creature::Update, (uint32)100, EVENT_CREATURE_UPDATE, 100, 0);
}


Creature::~Creature()
{
	sEventMgr.RemoveEvents(this);
}

void Creature::Update( uint32 p_time )
{
	Unit::Update( p_time );

	// FIXME
	if (isAlive())
	{
		RegenerateAll();
		GetAIInterface()->Update(p_time);
	}
}

void Creature::OnJustDied()
{
	this->SetUInt32Value(UNIT_NPC_FLAGS , uint32(0));
	//		UpdateObject();

	// remove me as an attacker from the AttackMap
	GetAIInterface()->SetUnitToFollow(NULL);
	m_deathState = CORPSE;

	sEventMgr.AddEvent(this, &Creature::OnRemoveCorpse, EVENT_CREATURE_REMOVE_CORPSE, m_corpseDelay, 1);

	//TODO: remove all timers that should be removed on death
}

void Creature::OnRemoveCorpse()
{
	// time to respawn!
	Log::getSingleton( ).outDetail("Removing corpse...");

	RemoveFromWorld();
	sEventMgr.AddEvent(this, &Creature::OnRespawn, EVENT_CREATURE_RESPAWN, m_respawnDelay, 1);

	setDeathState(DEAD);

	m_positionX = respawn_cord[0];
	m_positionY = respawn_cord[1];
	m_positionZ = respawn_cord[2];
}

void Creature::OnRespawn()
{
	Log::getSingleton( ).outDetail("Respawning...");
	SetUInt32Value(UNIT_FIELD_HEALTH, GetUInt32Value(UNIT_FIELD_MAXHEALTH));
	SetUInt32Value(UNIT_DYNAMIC_FLAGS,0);
	AddToWorld();
	setDeathState(ALIVE);
	_LoadLoot();
	GetAIInterface()->setCreatureState(STOPPED); // after respawn monster can move
}

void Creature::Despawn()
{
	this->SetUInt32Value(UNIT_NPC_FLAGS , uint32(0));
	GetAIInterface()->SetUnitToFollow(NULL);
	RemoveFromWorld();
	sEventMgr.AddEvent(this, &Creature::OnRespawn, EVENT_CREATURE_RESPAWN, m_respawnDelay, 1);

	setDeathState(DEAD);

	m_positionX = respawn_cord[0];
	m_positionY = respawn_cord[1];
	m_positionZ = respawn_cord[2];    
}

void Creature::Create (uint32 guidlow, const char* name, uint32 mapid, float x, float y, float z, float ang)
{
	Object::_Create(guidlow, HIGHGUID_UNIT, mapid, x, y, z, ang);

	respawn_cord[0] = x;
	respawn_cord[1] = y;
	respawn_cord[2] = z;

	m_name = name;
}

void Creature::CreateWayPoint (uint32 WayPointID, uint32 mapid, float x, float y, float z, float ang)
{
	Object::_Create(WayPointID, HIGHGUID_WAYPOINT, mapid, x, y, z, ang);
}

///////////
/// Looting

void Creature::generateLoot()
{
	if (this->GetCreatureName()->Family == CRITTER)
		return;
	uint32 cnt = 1;
	mItems.clear();
	mProps.clear();
	LootTable* tb = lootmgr.getLoot(GetUInt32Value(OBJECT_FIELD_ENTRY));
	int itc = 2+((this->GetCreatureName()->Family == HUMANOID)?(1):(0));
	itc = (rand()%itc);
	if ((this->GetCreatureName()->Rank == 2) || (this->GetCreatureName()->Rank == 1))
		itc++;
	else if (this->GetCreatureName()->Rank == 3)
		itc+=2;

	if (tb)
	{
		list<uint32>::iterator i,k;
		list<float>::iterator j,m;
		j = tb->mChance.begin();
		lootcount = 0;
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
				lootcount++;
				if (lootcount >= itc)
					break;
				ItemPrototype *it = objmgr.GetItemPrototype(*i);
				if(it)
				{
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
			}
			j++;
		}
	}
	if (this->GetCreatureName()->Family == HUMANOID)
		m_lootMoney = getLevel() * (rand()%5 + 1)*sWorld.getRate(RATE_DROP); //generate copper
}

void Creature::SaveToDB()
{
	std::stringstream ss;
	ss << "DELETE FROM creatures WHERE id=" << GetGUIDLow();
	sDatabase.Execute(ss.str().c_str());

	ss.rdbuf()->str("");
	ss << "INSERT INTO creatures (id, mapId, zoneId, name_id, positionX, positionY, positionZ, orientation, moverandom, running, data) VALUES ( "
		<< GetGUIDLow() << ", "
		<< GetMapId() << ", "
		<< GetZoneId() << ", "
		<< GetUInt32Value(OBJECT_FIELD_ENTRY) << ", "
		<< m_positionX << ", "
		<< m_positionY << ", "
		<< m_positionZ << ", "
		<< m_orientation << ", "
		<< GetAIInterface()->getMoveRandomFlag() << ", "
		<< GetAIInterface()->getMoveRunFlag() << ", '";
	for( uint16 index = 0; index < m_valuesCount; index ++ )
		ss << GetUInt32Value(index) << " ";

	ss << "' )";

	sDatabase.Execute( ss.str( ).c_str( ) );

	// TODO: save vendor items etc?
}


// TODO: use full guids
void Creature::LoadFromDB(uint32 guid)
{
	std::stringstream ss;
	ss << "SELECT * FROM creatures WHERE id=" << guid;

	QueryResult *result = sDatabase.Query( ss.str().c_str() );
	ASSERT(result);

	Field *fields = result->Fetch();

	//    _Create( guid, 0 );

	Create(fields[0].GetUInt32(), objmgr.GetCreatureName(fields[8].GetUInt32())->Name.c_str(), fields[6].GetUInt32(),
		fields[1].GetFloat(), fields[2].GetFloat(), fields[3].GetFloat(), fields[4].GetFloat());

	m_sqlid = fields[0].GetUInt32();
	m_zoneId = fields[5].GetUInt32();
	m_nameEntry = fields[8].GetUInt32();
	GetAIInterface()->setMoveRandomFlag(fields[9].GetBool());
	GetAIInterface()->setMoveRunFlag(fields[10].GetBool());

	LoadValues(fields[7].GetString());

	delete result;

	if ( HasFlag( UNIT_NPC_FLAGS, UNIT_NPC_FLAG_VENDOR ) )
		_LoadGoods();

	if ( HasFlag( UNIT_NPC_FLAGS, UNIT_NPC_FLAG_QUESTGIVER ) )
		_LoadQuests();


	// Temp:LoadHealth
	_LoadHealth();

	//DK:LoadLoot, LoadSpells
	_LoadLoot();
	_LoadSpells();
	//Finish

	_LoadMovement();

	LoadAIAgents();
	creature_info = objmgr.GetCreatureName(GetUInt32Value(OBJECT_FIELD_ENTRY));

	// init Stat Listener
	s_stats[0] = GetUInt32Value(UNIT_FIELD_STAT0);
	s_stats[1] = GetUInt32Value(UNIT_FIELD_STAT1);
	s_stats[2] = GetUInt32Value(UNIT_FIELD_STAT2);
	s_stats[3] = GetUInt32Value(UNIT_FIELD_STAT3);
	s_stats[4] = GetUInt32Value(UNIT_FIELD_STAT4);
	// init Faction
	_setFaction();
}

//Temp:LoadHealth()
void Creature::_LoadHealth()
{
	uint32 creatureEntry = GetUInt32Value(OBJECT_FIELD_ENTRY);
	std::stringstream ss;
	ss << "SELECT * FROM tempdamhe WHERE entryid=" << creatureEntry;

	QueryResult *result = sDatabase.Query( ss.str().c_str() );

	Field *fields;
	if(result)
	{
		fields = result->Fetch();

		SetFloatValue(UNIT_FIELD_MINDAMAGE,fields[1].GetFloat());
		SetFloatValue(UNIT_FIELD_MAXDAMAGE,fields[2].GetFloat());
		SetUInt32Value(UNIT_FIELD_HEALTH,fields[3].GetUInt32());
		SetUInt32Value(UNIT_FIELD_MAXHEALTH,fields[3].GetUInt32());
		SetUInt32Value(UNIT_FIELD_BASE_HEALTH,fields[3].GetUInt32());
	}

	delete result;
}

//DK:LootLoad
void Creature::_LoadLoot()
{
	LootTable* tb = lootmgr.getLoot(GetUInt32Value(OBJECT_FIELD_ENTRY));
	if (!tb)
		lootmgr.loadLoot(GetUInt32Value(OBJECT_FIELD_ENTRY));

}

//DK:LoadSpells()
void Creature::_LoadSpells()
{
	spellcount=0;
	//get creatures nameid
	uint32 creatureEntry = GetUInt32Value(OBJECT_FIELD_ENTRY);

	std::stringstream ss;
	ss << "SELECT * FROM creaturespells WHERE entryid=" << creatureEntry;

	QueryResult *result = sDatabase.Query( ss.str().c_str() );

	Field *fields;
	if(result)
	{
		do
		{
			fields = result->Fetch();

			if (getSpellCount() >= MAX_CREATURE_SPELL)
			{
				Log::getSingleton( ).outError( "Creature %u has too many spells!Check your DB.", GetGUIDLow() );
				break;
			}
			setSpellId(getSpellCount() , fields[1].GetUInt32());
			increaseSpellCount();
		}
		while( result->NextRow() );
	}

	delete result;
}

void Creature::_LoadGoods()
{
	// remove items from vendor
	itemcount = 0;

	// load his goods
	std::stringstream query;
	query << "SELECT * FROM vendors WHERE vendorGuid=" << GetUInt32Value(OBJECT_FIELD_ENTRY);

	QueryResult *result = sDatabase.Query( query.str().c_str() );
	if(result)
	{
		do
		{
			Field *fields = result->Fetch();

			if (getItemCount() >= MAX_CREATURE_ITEMS)
			{
				// this should never happen unless someone has been fucking with the dbs
				// complain and break :P
				Log::getSingleton( ).outError( "Vendor %u has too many items. Check the DB!", GetGUIDLow() );
				break;
			}

			setItemId(getItemCount() , fields[1].GetUInt32());
			setItemAmount(getItemCount() , fields[2].GetUInt32());
			increaseItemCount();

		}
		while( result->NextRow() );

		delete result;
	}
}


void Creature::_LoadMovement()
{
	std::stringstream query;
	query << "SELECT * FROM creature_waypoints WHERE creatureid=" << GetGUIDLow();

	QueryResult *result = sDatabase.Query( query.str().c_str() );
	if(result)
	{
		do
		{
          Field *fields = result->Fetch();

          WayPoint* wp = new WayPoint;
          wp->id = fields[1].GetUInt32();
          wp->x = fields[2].GetFloat();
          wp->y = fields[3].GetFloat();
          wp->z = fields[4].GetFloat();
          wp->waittime = fields[5].GetUInt32();
          wp->flags = fields[6].GetUInt32();
          wp->forwardemoteoneshot = fields[7].GetBool();
          wp->forwardemoteid = fields[8].GetUInt32();
          wp->forwardemoteoneshot = fields[9].GetBool();
          wp->backwardemoteid = fields[10].GetUInt32();
          wp->forwardskinid = fields[11].GetUInt32();
          wp->backwardskinid = fields[12].GetUInt32();

          GetAIInterface()->addWayPoint(wp);
			//addWaypoint( fields[0].GetFloat(), fields[1].GetFloat(), fields[2].GetFloat());
		}
		while( result->NextRow() );

		delete result;
	}
}

void Creature::DeleteFromDB()
{
	char sql[256];

	sprintf(sql, "DELETE FROM creatures WHERE id=%u", GetGUIDLow());
	sDatabase.Execute(sql);
	sprintf(sql, "DELETE FROM vendors WHERE vendorGuid=%u", GetGUIDLow());
	sDatabase.Execute(sql);
	sprintf(sql, "DELETE FROM trainer WHERE GUID=%u", GetGUIDLow());
	sDatabase.Execute(sql);
	sprintf(sql, "DELETE FROM creaturequestrelation WHERE creatureId=%u", GetGUIDLow());
	sDatabase.Execute(sql);
    sprintf(sql, "DELETE FROM creature_waypoints WHERE creatureid=%u", GetGUIDLow());
	sDatabase.Execute(sql);
}


/////////////
/// Quests

void Creature::AddQuest(QuestRelation *Q)
{
	m_quests->push_back(Q);
}

void Creature::DeleteQuest(QuestRelation *Q)
{
	list<QuestRelation *>::iterator it;
	for ( it = m_quests->begin(); it != m_quests->end(); it++ )
	{
		if (((*it)->type == Q->type) && ((*it)->qst == Q->qst ))
		{
			delete (*it);
			m_quests->erase(it);
			break;
		}
	}
}

Quest* Creature::FindQuest(uint32 quest_id, uint8 quest_relation)
{   
	list<QuestRelation *>::iterator it;
	for (it = m_quests->begin(); it != m_quests->end(); it++)
	{
		QuestRelation *ptr = (*it);

		if ((ptr->qst->GetID() == quest_id) && (ptr->type & quest_relation))
		{
			return ptr->qst;
		}
	}
	return NULL;
}

uint16 Creature::GetQuestRelation(uint32 quest_id)
{
	uint16 quest_relation = 0;
	list<QuestRelation *>::iterator it;

	for (it = m_quests->begin(); it != m_quests->end(); it++)
	{
		if ((*it)->qst->GetID() == quest_id)
		{
			quest_relation |= (*it)->type;
		}
	}
	return quest_relation;
}

uint32 Creature::NumOfQuests()
{
	return m_quests->size();
}

void Creature::_LoadQuests()
{
	sQuestMgr.LoadNPCQuests(this);
}

void Creature::setItemAmountById(uint32 tempitemid, int tempamount)
{
	int i;
	for(i=0;i<itemcount;i++)
	{
		if(item_list[i].itemid == tempitemid)
			item_list[i].amount = tempamount;
	}
}

void Creature::addItem(uint32 itemid, uint32 amount)
{
	item_list[itemcount].amount = amount;
	item_list[itemcount].itemid = itemid;
	itemcount++;
}

int Creature::getItemSlotById(uint32 itemid)
{
	int i;
	for(i=0;i<itemcount;i++)
	{
		if(item_list[i].itemid == itemid)
			return i;
	}
	return -1;
}

uint32 Creature::getLootAmt(uint32 id) {
	std::map<uint32, uint32>::const_iterator itr = mItems.find( id );
	if( itr != mItems.end( ) )
		return itr->second;
	return NULL;
}

uint32 Creature::getLootProp(uint32 id) {
	std::map<uint32, uint32>::const_iterator itr = mProps.find( id );
	if( itr != mProps.end( ) )
		return itr->second;
	return NULL;
}

void Creature::setLootAmt(uint32 id, uint32 amt) {
	std::map<uint32, uint32>::iterator itr = mItems.find( id );
	if( itr != mItems.end( ) )
		itr->second = amt;
}

void Creature::setDeathState(DeathState s) {
	m_deathState = s;
	if(s == JUST_DIED) 
	{
		//dunno why, but it was on next cycle, so i just left it that way
		sEventMgr.AddEvent(this, &Creature::OnJustDied, EVENT_CREATURE_JUSTDIED, 1, 1);
	}
}
