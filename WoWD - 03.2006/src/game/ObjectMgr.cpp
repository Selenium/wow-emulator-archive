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
#include "Log.h"
#include "ObjectMgr.h"
#include "UpdateMask.h"
#include "World.h"
#include "WorldSession.h"
#include "Group.h"

initialiseSingleton( ObjectMgr );


ObjectMgr::ObjectMgr()
{
	m_hiCharGuid = 1;
	m_hiCreatureGuid = 1;
	m_hiItemGuid = 1;
	m_hiGoGuid = 1;
	m_hiDoGuid = 1;
	m_hiNameGuid = 1;
}


ObjectMgr::~ObjectMgr()
{
	sLog.outString("Deleting PlayerNames...");
	for( PlayerNameMap::iterator i = mPlayerNames.begin( ); i != mPlayerNames.end( ); ++ i ) {
		delete i->second;
	}
	mPlayerNames.clear();

	sLog.outString("Deleting CreatureNames...");
	for( CreatureNameMap::iterator i = mCreatureNames.begin( ); i != mCreatureNames.end( ); ++ i ) {
		delete i->second;
	}
	mCreatureNames.clear();

	sLog.outString("Deleting CreatureSpawnTemplates...");
	for( CreatureSpawnTemplateMap::iterator i = mCreatureSpawnTemplates.begin( ); i != mCreatureSpawnTemplates.end( ); ++ i ) {
		delete i->second;
	}
	mCreatureSpawnTemplates.clear( );

	sLog.outString("Deleting Creatures...");
	for( CreatureMap::iterator i = mCreatures.begin( ); i != mCreatures.end( ); ++ i ) {
		delete i->second;
	}
	mCreatures.clear( );

	sLog.outString("Deleting GameObjects...");
	for( GameObjectMap::iterator i = mGameObjects.begin( ); i != mGameObjects.end( ); ++ i ) {
		delete i->second;
	}
	mGameObjects.clear( );

	sLog.outString("Deleting DynamicObjects...");
	for( DynamicObjectMap::iterator i = mDynamicObjects.begin( ); i != mDynamicObjects.end( ); ++ i ) {
		delete i->second;
	}
	mDynamicObjects.clear( );

	sLog.outString("Deleting Corpses...");
	for( CorpseMap::iterator i = mCorpses.begin( ); i != mCorpses.end( ); ++ i ) {
		delete i->second;
	}
	mCorpses.clear( );

	sLog.outString("Deleting ItemPrototypes...");
	for( ItemPrototypeMap::iterator i = mItemPrototypes.begin( ); i != mItemPrototypes.end( ); ++ i ) {
		delete i->second;
	}
	mItemPrototypes.clear( );

	sLog.outString("Deleting TrainerSpells...");
	for( TrainerspellMap::iterator i = mTrainerspells.begin( ); i != mTrainerspells.end( ); ++ i ) {
		delete i->second;
	}
	mTrainerspells.clear( );

	sLog.outString("Deleting CreateInfo...");
	for( PlayerCreateInfoMap::iterator i = mPlayerCreateInfo.begin( ); i != mPlayerCreateInfo.end( ); ++ i ) {
		delete i->second;
	}
	mPlayerCreateInfo.clear( );

	sLog.outString("Deleting Guilds...");
	for ( GuildMap::iterator i = mGuild.begin(); i != mGuild.end(); ++i ) {
		delete i->second;
	}
	mGuild.clear();

	sLog.outString("Deleting GossipText...");
	for( GossipTextMap::iterator i = mGossipText.begin( ); i != mGossipText.end( ); ++ i ) {
		delete i->second;
	}
	mGossipText.clear( );

	GossipNpcMap::iterator iter, end;

	sLog.outString("Deleting GossipNpcs...");
	for( iter = mGossipNpc.begin(), end =  mGossipNpc.end(); iter != end; iter++ )
	{
		if(iter->second->pOptions)
		{
			delete[] iter->second->pOptions;
		}

		delete iter->second;
	}
	mGossipNpc.clear( );

	sLog.outString("Deleting Graveyards...");
	for( GraveyardMap::iterator i = mGraveyards.begin( ); i != mGraveyards.end( ); ++ i ) {
		delete i->second;
	}
	mGraveyards.clear( );

	sLog.outString("Deleting Taxi Nodes...");
	for( TaxiNodesMap::iterator i = mTaxiNodes.begin( ); i != mTaxiNodes.end( ); ++ i ) {
		delete i->second;
	}
	mTaxiNodes.clear( );

	sLog.outString("Deleting Taxi Paths...");
	for( TaxiPathMap::iterator i = mTaxiPath.begin( ); i != mTaxiPath.end( ); ++ i ) {
		delete i->second;
	}
	mTaxiPath.clear( );

	sLog.outString("Deleting Taxi Path Nodes...");
	std::vector<TaxiPathNodes*>::iterator VectorData;
	for(VectorData = vTaxiPathNodes.begin(); VectorData != vTaxiPathNodes.end(); VectorData++)
	{
		TaxiPathNodes *taxinode = *(VectorData);
		delete taxinode;
	}
	vTaxiPathNodes.clear();

	sLog.outString("Deleting GameObjectNames...");
	for( GameObjectNameMap::iterator i = mGameObjectNames.begin( ); i != mGameObjectNames.end( ); ++ i ) {
		delete i->second;
	}
	mGameObjectNames.clear();

	sLog.outString("Deleting Charters...");
	for( std::list<guildCharter*>::iterator i = Guild_CharterList.begin( ); i != Guild_CharterList.end( ); ++ i ) {
		delete *i;
	}
	Guild_CharterList.clear();

	sLog.outString("Deleting PvPAreas...");
	for( PvPAreaMap::iterator i = mPvPAreas.begin( ); i != mPvPAreas.end( ); ++ i ) {
		delete i->second;
	}
	mPvPAreas.clear();

}

//
// Groups
//

Group * ObjectMgr::GetGroupByLeader(const uint64 &guid) const
{
	GroupSet::const_iterator itr;
	for (itr = mGroupSet.begin(); itr != mGroupSet.end(); itr++)
	{
		if ((*itr)->GetLeaderGUID() == guid)
		{
			return *itr;
		}
	}

	return NULL;
}

//
// Raid
//

Raid * ObjectMgr::GetRaidByLeader(const uint64 &guid) const
{
	RaidSet::const_iterator itr;
	for (itr = mRaidSet.begin(); itr != mRaidSet.end(); itr++)
	{
		if ((*itr)->GetRaidLeaderGUID() == guid)
		{
			return *itr;
		}
	}

	return NULL;
}
//
// Player names
//
PlayerInfo *ObjectMgr::GetPlayerName( uint64 guid )
{
	PlayerNameMap::const_iterator itr = mPlayerNames.find( GUID_LOPART(guid) );
	if( itr != mPlayerNames.end( ) )
		return itr->second;

	//returning unknown player if no data found

	PlayerInfo *pn = new PlayerInfo;
	pn->guid = guid;
	pn->name = "Unknown Player";
	pn->race = 0;
	pn->gender = 0;
	pn->cl = 0;
	AddPlayerName(pn);
	return pn;
}

void ObjectMgr::AddPlayerName(PlayerInfo *pn)
{
	uint32 guidlow = GUID_LOPART(pn->guid);
	ASSERT( mPlayerNames.find(guidlow) == mPlayerNames.end() );
	//verifying if info for that creature already exists(need some cleaning here some time)
	PlayerNameMap::iterator itr = mPlayerNames.find( guidlow );
	//if found we delete the old creature info
	if( itr != mPlayerNames.end( ) )
		mPlayerNames.erase(itr);
	mPlayerNames[guidlow] = pn;
}

void ObjectMgr::RemovePlayerName( uint64 guid )
{
	uint32 guidlow = GUID_LOPART(guid);
	PlayerNameMap::iterator itr = mPlayerNames.find( guidlow );
	//if found we delete the old creature info
	if( itr != mPlayerNames.end( ) )
		mPlayerNames.erase(itr);
}
//
// Creature names
//
CreatureInfo *ObjectMgr::GetCreatureName(uint32 id)
{
	CreatureNameMap::const_iterator itr = mCreatureNames.find( id );
	if( itr != mCreatureNames.end( ) )
		return itr->second;

	//returning unknown creature if no data found


	CreatureInfo *ci=new CreatureInfo;
	ci->Name = "Unknown Being";
	ci->Id=id;
	ci->SubName = "";
	ci->Flags1 = 0;
	ci->Type = 0;
	ci->Family = 0;
	ci->Rank = 0;
	ci->Unknown1 = 0;
	ci->Unknown2 = 0;
	ci->DisplayID = 0;
	ci->Civilian = 0;
	ci->Unknown3 = 0;
	AddCreatureName(ci);
	return ci;
}

uint32 ObjectMgr::AddCreatureName(const char* name)
{
	for( CreatureNameMap::iterator i = mCreatureNames.begin( );
		i != mCreatureNames.end( ); ++ i )
	{
		if (strcmp(i->second->Name.c_str(),name) == 0)
			return i->second->Id;
	}

	uint32 id = m_hiNameGuid++;
	AddCreatureName(id, name);

	std::stringstream ss;
	ss << "INSERT INTO creature_names (name_id,creature_name) VALUES (" << id << ", '" << name << "')";
	sDatabase.Execute( ss.str( ).c_str( ) );

	return id;
}

uint32 ObjectMgr::AddCreatureName(const char* name, uint32 displayid)
{
	for( CreatureNameMap::iterator i = mCreatureNames.begin( );
		i != mCreatureNames.end( ); ++ i )
	{
		if (strcmp(i->second->Name.c_str(),name) == 0)
			return i->second->Id;
	}

	uint32 id = m_hiNameGuid++;
	AddCreatureName(id, name, displayid);

	std::stringstream ss;
	ss << "INSERT INTO creature_names (name_id,creature_name,displayid) VALUES (" << id << ", '" << name << "', '" << displayid << "')";
	sDatabase.Execute( ss.str( ).c_str( ) );

	return id;
}

uint32 ObjectMgr::AddCreatureSubName(const char* name, const char* subname, uint32 displayid)
{
	for( CreatureNameMap::iterator i = mCreatureNames.begin( );
		i != mCreatureNames.end( ); ++ i )
	{
		if (strcmp(i->second->Name.c_str(),name) == 0)
			if (i->second->DisplayID == displayid)
				if (strcmp(i->second->SubName.c_str(),subname) == 0)
					return i->second->Id;
	}

	uint32 id = m_hiNameGuid++;

	CreatureInfo *cInfo = new CreatureInfo;
	cInfo->DisplayID = displayid;
	cInfo->Id = id;
	cInfo->Name = name;
	cInfo->SubName = subname;
	cInfo->Flags1 = 0;
	cInfo->Type = 0;
	cInfo->Family = 0;
	cInfo->Rank = 0;
	cInfo->Unknown1 = 0;
	cInfo->Unknown2 = 0;
	cInfo->Civilian = 0;
	cInfo->Unknown3 = 0;

	AddCreatureName(cInfo);

	std::stringstream ss;
	ss << "INSERT INTO creature_names (name_id,creature_name,Subname,displayid) VALUES (" << id << ", '" << name;
	ss << "', '" << subname << "', '" << displayid << "')";
	sDatabase.Execute( ss.str( ).c_str( ) );

	return id;
}

void ObjectMgr::AddCreatureName(CreatureInfo *cinfo)
{
	ASSERT( mCreatureNames.find(cinfo->Id) == mCreatureNames.end() );
	//verifying if info for that creature already exists(need some cleaning here some time)
	CreatureNameMap::iterator itr = mCreatureNames.find( cinfo->Id );
	//if found we delete the old creature info
	if( itr != mCreatureNames.end( ) )
		mCreatureNames.erase(itr);
	mCreatureNames[cinfo->Id] = cinfo;
}

void ObjectMgr::AddCreatureName(uint32 id, const char* name)
{
	CreatureInfo *cinfo;
	cinfo = new CreatureInfo;
	cinfo->Id = id;
	cinfo->Name = name;
	cinfo->SubName = "";
	cinfo->Flags1 = 0;
	cinfo->Type = 0; 
	cinfo->Family = 0;
	cinfo->Rank = 0;
	cinfo->Unknown1 = 0;
	cinfo->Unknown2 = 0;
	cinfo->DisplayID = 0;
	cinfo->Civilian = 0;
	cinfo->Unknown3 = 0;

	ASSERT( name );
	ASSERT( mCreatureNames.find(id) == mCreatureNames.end() );
	mCreatureNames[id] = cinfo;
}
void ObjectMgr::LoadSpellSkills()
{
	uint32 i;

	for(i = 0; i < sSkillStore.GetNumRows(); i++)
	{
		skilllinespell *sp = sSkillStore.LookupEntry(i);
		if (sp)
		{
			mSpellSkills[sp->spell] = sp;
		}
	}
}
skilllinespell* ObjectMgr::GetSpellSkill(uint32 id)
{
	return mSpellSkills[id];
}
void ObjectMgr::AddCreatureName(uint32 id, const char* name, uint32 displayid)
{
	CreatureInfo *cinfo;
	cinfo = new CreatureInfo;
	cinfo->Id = id;
	cinfo->Name = name;
	cinfo->SubName = "";
	cinfo->Type = 0;
	cinfo->Flags1 = 0;
	cinfo->Family = 0;
	cinfo->Rank = 0;
	cinfo->Unknown1 = 0;
	cinfo->Unknown2 = 0;
	cinfo->DisplayID = displayid;
	cinfo->Civilian = 0;
	cinfo->Unknown3 = 0;

	ASSERT( name );
	ASSERT( mCreatureNames.find(id) == mCreatureNames.end() );
	mCreatureNames[id] = cinfo;
}

void ObjectMgr::LoadCreatureSpawnTemplates()
{
	CreatureSpawnTemplate *ct;
	QueryResult *result = sDatabase.Query( "SELECT * FROM creaturespawntemplate" );
	if(result)
	{
		do
		{
			Field *fields = result->Fetch();
			ct = new CreatureSpawnTemplate;
			int column = 0;
			ct->EntryID = fields[column].GetUInt32();
			column += 1;
			/*
			ct->ModelID = fields[column].GetUInt32();
			column += 1;
			ct->Name = fields[column].GetString();
			column += 1;
			ct->SubName = fields[column].GetString();
			column += 1;
			*/
			ct->MaxHealth = fields[column].GetUInt32();
			column += 1;
			ct->MaxMana = fields[column].GetUInt32();
			column += 1;
			ct->Armor = fields[column].GetUInt32();
			column += 1;
			ct->Level = fields[column].GetUInt32();
			column += 1;
			ct->Faction = fields[column].GetUInt32();
			column += 1;
			ct->Flag = fields[column].GetUInt32();
			column += 1;
			ct->Scale = fields[column].GetFloat();
			column += 1;
			ct->Speed = fields[column].GetFloat();
			column += 1;
			//ct->Rank = fields[column].GetUInt32();
			//column += 1;
			ct->MinDamage = fields[column].GetFloat();
			column += 1;
			ct->MaxDamage = fields[column].GetFloat();
			column += 1;
			ct->MinRangedDamage = fields[column].GetFloat();
			column += 1;
			ct->MaxRangedDamage = fields[column].GetFloat();
			column += 1;
			ct->BaseAttackTime = fields[column].GetUInt32();
			column += 1;
			ct->RangedAttackTime = fields[column].GetUInt32();
			column += 1;
			ct->BoundingRadius = fields[column].GetFloat();
			column += 1;
			ct->CombatReach = fields[column].GetFloat();
			column += 1;
			ct->Slot1Model = fields[column].GetUInt32();
			column += 1;
			ct->Slot1Info1 = fields[column].GetUInt8();
			column += 1;
			ct->Slot1Info2 = fields[column].GetUInt8();
			column += 1;
			ct->Slot1Info3 = fields[column].GetUInt8();
			column += 1;
			ct->Slot1Info4 = fields[column].GetUInt8();
			column += 1;
			ct->Slot1Info5 = fields[column].GetUInt8();
			column += 1;
			ct->Slot2Model = fields[column].GetUInt32();
			column += 1;
			ct->Slot2Info1 = fields[column].GetUInt8();
			column += 1;
			ct->Slot2Info2 = fields[column].GetUInt8();
			column += 1;
			ct->Slot2Info3 = fields[column].GetUInt8();
			column += 1;
			ct->Slot2Info4 = fields[column].GetUInt8();
			column += 1;
			ct->Slot2Info5 = fields[column].GetUInt8();
			column += 1;
			ct->Slot3Model = fields[column].GetUInt32();
			column += 1;
			ct->Slot3Info1 = fields[column].GetUInt8();
			column += 1;
			ct->Slot3Info2 = fields[column].GetUInt8();
			column += 1;
			ct->Slot3Info3 = fields[column].GetUInt8();
			column += 1;
			ct->Slot3Info4 = fields[column].GetUInt8();
			column += 1;
			ct->Slot3Info5 = fields[column].GetUInt8();
			column += 1;
			//ct->Type = fields[column].GetUInt32();
			//column += 1;
			ct->MountModelID = fields[column].GetUInt32();
			column += 1;


			AddCreatureSpawnTemplate(ct);
		} while( result->NextRow() );

		delete result;
	}
}

void ObjectMgr::LoadPlayerNames()
{
	PlayerInfo *pn;
	QueryResult *result = sDatabase.Query( "SELECT guid FROM characters" );
	if(result)
	{
		Player *plyr;
		do
		{
			Field *fields = result->Fetch();

			plyr = new Player;
			ASSERT(plyr);

			plyr->LoadNamesFromDB( fields[0].GetUInt32() );

			pn = new PlayerInfo;
			pn->guid = fields[0].GetUInt64();
			pn->name = plyr->GetName();
			pn->race = plyr->getRace();
			pn->cl = plyr->getClass();
			pn->gender = plyr->getGender();

			AddPlayerName(pn);

			delete plyr;
		} while( result->NextRow() );

		delete result;
	}
}

void ObjectMgr::LoadCreatureNames()
{
	CreatureInfo *cn;
	QueryResult *result = sDatabase.Query( "SELECT * FROM creature_names" );
	if(result)
	{
		do
		{
			Field *fields = result->Fetch();

			cn = new CreatureInfo;
			cn->Id = fields[0].GetUInt32();
			cn->Name = fields[1].GetString();
			cn->SubName = fields[2].GetString();
			cn->Flags1 = fields[3].GetUInt32();
			cn->Type = fields[4].GetUInt32();
			cn->Family = fields[5].GetUInt32();
			cn->Rank = fields[6].GetUInt32();
			cn->Unknown1 = fields[7].GetUInt32();
			cn->Unknown2 = fields[8].GetUInt32();
			cn->DisplayID = fields[9].GetUInt32();
			cn->Civilian = fields[10].GetUInt8();
			cn->Unknown3 = fields[11].GetUInt32();


			AddCreatureName( cn );
		} while( result->NextRow() );

		delete result;
	}

	result = sDatabase.Query( "SELECT MAX(name_id) FROM creature_names" );
	if(result)
	{
		m_hiNameGuid = (*result)[0].GetUInt32();

		delete result;
	}
}

uint64 ObjectMgr::GetPlayerGUIDByName(const char *name) const
{
	uint64 guid = 0;
	std::stringstream query;
	query << "SELECT guid FROM characters WHERE name = '" << name << "'";

	QueryResult *result = sDatabase.Query( query.str().c_str() );
	if(result)
	{
		guid = (*result)[0].GetUInt32();

		delete result;
	}

	return guid;
}


bool ObjectMgr::GetPlayerNameByGUID(const uint64 &guid, std::string &name) const
{
	std::stringstream query;
	query << "SELECT name FROM characters WHERE guid=" << GUID_LOPART(guid);

	QueryResult *result = sDatabase.Query( query.str().c_str() );
	if(result)
	{
		name = (*result)[0].GetString();
		delete result;
		return true;
	}

	return false;
}

void ObjectMgr::LoadAuctions()
{
	QueryResult *result = sDatabase.Query( "SELECT * FROM auctionhouse" );

	if( !result )
		return;

	AuctionEntry *aItem;

	do
	{
		Field *fields = result->Fetch();

		aItem = new AuctionEntry;
		aItem->auctioneer = fields[0].GetUInt32();
		aItem->item = fields[1].GetUInt32();
		aItem->owner = fields[2].GetUInt32();
		aItem->buyout = fields[3].GetUInt32();
		aItem->time = fields[4].GetUInt32();
		aItem->bidder = fields[5].GetUInt32();
		aItem->bid = fields[6].GetUInt32();
		aItem->Id = fields[7].GetUInt32();
		AddAuction(aItem);
	} while (result->NextRow());
	delete result;

}
void ObjectMgr::LoadItemPrototypes()
{
	QueryResult *result = sDatabase.Query( "SELECT * FROM items" );

	if( !result )
		return;

	ItemPrototype *pItemPrototype;
	int i;

	if( result->GetFieldCount() < 113 )
	{
		Log::getSingleton().outError("DB: Items table has incorrect number of fields");
		delete result;
		return;
	}

	do
	{
		Field *fields = result->Fetch();

		if( !fields[0].GetUInt32() )
		{
			Log::getSingleton().outBasic("DB: Incorrect item id found");
			continue;
		}

		pItemPrototype = new ItemPrototype;

		pItemPrototype->ItemId = fields[0].GetUInt32();
		pItemPrototype->Class = fields[2].GetUInt32();
		pItemPrototype->SubClass = fields[3].GetUInt32();
		pItemPrototype->Name1 = fields[4].GetString();
		pItemPrototype->Name2 = fields[5].GetString();
		pItemPrototype->Name3 = fields[6].GetString();
		pItemPrototype->Name4 = fields[7].GetString();
		pItemPrototype->DisplayInfoID = fields[8].GetUInt32();
		pItemPrototype->Quality = fields[9].GetUInt32();
		pItemPrototype->Flags = fields[10].GetUInt32();
		pItemPrototype->BuyPrice = fields[11].GetUInt32();
		pItemPrototype->SellPrice = fields[12].GetUInt32();
		pItemPrototype->InventoryType = fields[13].GetUInt32();
		pItemPrototype->AllowableClass = fields[14].GetUInt32();
		pItemPrototype->AllowableRace = fields[15].GetUInt32();
		pItemPrototype->ItemLevel = fields[16].GetUInt32();
		pItemPrototype->RequiredLevel = fields[17].GetUInt32();
		pItemPrototype->RequiredSkill = fields[18].GetUInt32();
		pItemPrototype->RequiredSkillRank = fields[19].GetUInt32();
		pItemPrototype->RequiredSkillSubRank = fields[20].GetUInt32();
		pItemPrototype->RequiredPlayerRank1 = fields[21].GetUInt32();
		pItemPrototype->RequiredPlayerRank2 = fields[22].GetUInt32();
		pItemPrototype->RequiredFaction = fields[23].GetUInt32();
		pItemPrototype->RequiredFactionStanding = fields[24].GetUInt32();
		pItemPrototype->Unique = fields[25].GetUInt32();
		pItemPrototype->MaxCount = fields[26].GetUInt32();
		pItemPrototype->ContainerSlots = fields[27].GetUInt32();
		for(i = 0; i < 20; i+=2) {
			pItemPrototype->ItemStatType[i/2] = fields[28 + i].GetUInt32();
			pItemPrototype->ItemStatValue[i/2] = fields[29 + i].GetUInt32();
		}
		for(i = 0; i < 15; i+=3) {
			// Stupid items.sql
			int *a=(int *)malloc(sizeof(int)); *a=fields[48 + i].GetUInt32();
			int *b=(int *)malloc(sizeof(int)); *b=fields[49 + i].GetUInt32();

			pItemPrototype->DamageMin[i/3] = *(float *)a;
			pItemPrototype->DamageMax[i/3] = *(float *)b;
			/*
			*/	       
			//pItemPrototype->DamageMin[i/3] = fields[46 + +i].GetFloat();
			//pItemPrototype->DamageMax[i/3] = fields[47 +i].GetFloat();
			pItemPrototype->DamageType[i/3] = fields[50 + i].GetUInt32();

			free(a);free(b);
		}
		pItemPrototype->Armor = fields[63].GetUInt32();
		pItemPrototype->Field62 = fields[64].GetUInt32();
		pItemPrototype->FireRes = fields[65].GetUInt32();
		pItemPrototype->NatureRes = fields[66].GetUInt32();
		pItemPrototype->FrostRes = fields[67].GetUInt32();
		pItemPrototype->ShadowRes = fields[68].GetUInt32();
		pItemPrototype->ArcaneRes = fields[69].GetUInt32();
		pItemPrototype->Delay = fields[70].GetUInt32();
		pItemPrototype->Field69 = fields[71].GetUInt32();
		for(i = 0; i < 30; i+=6) {
			pItemPrototype->SpellId[i/6] = fields[72+i].GetUInt32();
			pItemPrototype->SpellTrigger[i/6] = fields[73+i].GetUInt32();
			pItemPrototype->SpellCharges[i/6] = fields[74+i].GetUInt32();
			pItemPrototype->SpellCooldown[i/6] = fields[75+i].GetUInt32();
			pItemPrototype->SpellCategory[i/6] = fields[76+i].GetUInt32();
			pItemPrototype->SpellCategoryCooldown[i/6] = fields[77+i].GetUInt32();
		}
		pItemPrototype->Bonding = fields[102].GetUInt32();
		pItemPrototype->Description = fields[103].GetString();
		pItemPrototype->Field102 = fields[104].GetUInt32();
		pItemPrototype->Field103 = fields[105].GetUInt32();
		pItemPrototype->Field104 = fields[106].GetUInt32();
		pItemPrototype->Field105 = fields[107].GetUInt32();
		pItemPrototype->Field106 = fields[108].GetUInt32();
		pItemPrototype->Field107 = fields[109].GetUInt32();
		pItemPrototype->Field108 = fields[110].GetUInt32();
		pItemPrototype->Field109 = fields[111].GetUInt32();
		pItemPrototype->Block = fields[112].GetUInt32();
		pItemPrototype->Field111 = fields[113].GetUInt32();
		pItemPrototype->MaxDurability = fields[114].GetUInt32();
		pItemPrototype->ZoneNameID = fields[115].GetUInt32();
		pItemPrototype->Field114 = fields[116].GetUInt32();


		AddItemPrototype(pItemPrototype);

	} while( result->NextRow() );

	delete result;
}

void ObjectMgr::LoadTrainerSpells()
{
	QueryResult *result = sDatabase.Query( "SELECT * FROM trainer" );

	if( !result )
		return;

	Trainerspell *TrainSpell;

	do
	{
		Field *fields = result->Fetch();

		TrainSpell = new Trainerspell;
		TrainSpell->Id = fields[0].GetUInt32();
		TrainSpell->skilline1 = fields[1].GetUInt32();
		TrainSpell->skilline2 = fields[2].GetUInt32();
		TrainSpell->skilline3 = fields[3].GetUInt32();
		TrainSpell->maxlvl = fields[4].GetUInt32();
		TrainSpell->charclass = fields[5].GetUInt32();
		AddTrainerspell(TrainSpell);
	} while (result->NextRow());
	delete result;

}
void ObjectMgr::LoadAuctionItems()
{
	bool chck = FALSE;
	QueryResult *result = sDatabase.Query( "SELECT * FROM auctioned_items" );

	if( !result )
		return;
	Field *fields;
	do
	{
		fields = result->Fetch();
		Item* item = new Item;
		chck = item->LoadFromDB(fields[0].GetUInt32(), 2);
		if(chck)
			AddAItem(item);
	}
	while( result->NextRow() );

	delete result;
}
void ObjectMgr::LoadMailedItems()
{
	QueryResult *result = sDatabase.Query( "SELECT * FROM mailed_items" );

	if( !result )
		return;
	Field *fields;
	do
	{
		fields = result->Fetch();
		Item* item = new Item;
		item->LoadFromDB(fields[0].GetUInt32(), 3);
		AddMItem(item);
	}
	while( result->NextRow() );

	delete result;
}
void ObjectMgr::LoadQuests()
{
//	FILE *f;
//	char str[512];
//	Quest *questPtr;

	sQuestMgr.LoadQuests("quests.tt");
}


void ObjectMgr::LoadCreatures()
{
	QueryResult *result = sDatabase.Query( "SELECT id FROM creatures" );

	if( !result )
	{
		// log no creatures error
		return;
	}

	Creature* unit;
	Field *fields;

	do
	{
		fields = result->Fetch();

		unit = new Creature;
		ASSERT(unit);

		unit->LoadFromDB(fields[0].GetUInt32());
		//Log::getSingleton( ).outError("AddObject at ObjectMgr.cpp line 600");
		AddObject(unit);
	}
	while( result->NextRow() );

	delete result;
}

Creature* ObjectMgr::LoadCreature(uint32 guid)
{
	Creature* unit;

	unit = new Creature;
	ASSERT(unit);

	unit->LoadFromDB(guid);
	AddObject(unit);
	unit->AddToWorld();

	return unit;
}

void ObjectMgr::LoadGameObjects()
{
	QueryResult *result = sDatabase.Query( "SELECT id FROM gameobjects" );

	if( !result )
	{
		// log no creatures error
		return;
	}

	GameObject* go;
	Field *fields;

	do
	{
		fields = result->Fetch();

		go = new GameObject;
		ASSERT(go);

		go->LoadFromDB(fields[0].GetUInt32());
		//Log::getSingleton( ).outError("AddObject at ObjectMgr.cpp line 629");
		AddObject(go);
	}
	while( result->NextRow() );

	delete result;
}

GameObject* ObjectMgr::LoadGameObject(uint32 guid)
{
	GameObject* go = new GameObject;
	ASSERT(go);

	go->LoadFromDB(guid);
	AddObject(go);
	go->AddToWorld();

	return go;
}

void ObjectMgr::LoadPlayerCreateInfo()
{
	QueryResult *result = sDatabase.Query( "SELECT * FROM playercreateinfo" );

	if( !result )
		return;

	PlayerCreateInfo *pPlayerCreateInfo;
	int i;

	do
	{
		Field *fields = result->Fetch();

		pPlayerCreateInfo = new PlayerCreateInfo;

		pPlayerCreateInfo->index = fields[0].GetUInt8();
		pPlayerCreateInfo->race = fields[1].GetUInt8();
		pPlayerCreateInfo->class_ = fields[2].GetUInt8();
		pPlayerCreateInfo->mapId = fields[3].GetUInt32();
		pPlayerCreateInfo->zoneId = fields[4].GetUInt32();
		pPlayerCreateInfo->positionX = fields[5].GetFloat();
		pPlayerCreateInfo->positionY = fields[6].GetFloat();
		pPlayerCreateInfo->positionZ = fields[7].GetFloat();
		pPlayerCreateInfo->displayId = fields[8].GetUInt16();
		pPlayerCreateInfo->strength = fields[9].GetUInt8();
		pPlayerCreateInfo->ability = fields[10].GetUInt8();
		pPlayerCreateInfo->stamina = fields[11].GetUInt8();
		pPlayerCreateInfo->intellect = fields[12].GetUInt8();
		pPlayerCreateInfo->spirit = fields[13].GetUInt8();
		pPlayerCreateInfo->health = fields[14].GetUInt32();
		pPlayerCreateInfo->mana = fields[15].GetUInt32();
		pPlayerCreateInfo->rage = fields[16].GetUInt32();
		pPlayerCreateInfo->focus = fields[17].GetUInt32();
		pPlayerCreateInfo->energy = fields[18].GetUInt32();
		pPlayerCreateInfo->attackpower = fields[19].GetUInt32();
		pPlayerCreateInfo->mindmg = fields[20].GetFloat();
		pPlayerCreateInfo->maxdmg = fields[21].GetFloat();
		for (i=0; i<10; i++)
		{
			pPlayerCreateInfo->item[i] = fields[22+i*2].GetUInt32();
			pPlayerCreateInfo->item_slot[i] = fields[23+i*2].GetUInt8();
		}
		for (i=0; i<10; i++)
		{
			pPlayerCreateInfo->spell[i] = fields[42+i].GetUInt16();
		}

		AddPlayerCreateInfo(pPlayerCreateInfo);

	} while( result->NextRow() );

	delete result;
}

// DK:LoadGuilds()
void ObjectMgr::LoadGuilds()
{
	std::stringstream query;
	QueryResult *result = sDatabase.Query( "SELECT * FROM guilds" );
	QueryResult *result2;	
	QueryResult *result3;

	if(!result)
		return;

	Guild *pGuild;
	guildMembers *gMember;
	struct RankInfo rankList;

	do
	{
		Field *fields = result->Fetch();

		pGuild = new Guild;

		pGuild->SetGuildId( fields[0].GetUInt32() );
		pGuild->SetGuildName( fields[1].GetString() );
		pGuild->SetGuildLeaderGuid(fields[2].GetUInt64() );
		pGuild->SetGuildEmblemStyle( fields[3].GetUInt32() );
		pGuild->SetGuildEmblemColor(fields[4].GetUInt32() );
		pGuild->SetGuildBorderStyle( fields[5].GetUInt32() );
		pGuild->SetGuildBorderColor( fields[6].GetUInt32() );
		pGuild->SetGuildBackgroundColor( fields[7].GetUInt32() );
		pGuild->SetGuildInfo( fields[8].GetString() );
		pGuild->SetGuildMotd( fields[9].GetString() );

		query.str("");
		query << "SELECT * FROM playerguilds WHERE guildId=" << pGuild->GetGuildId();
		result2 = sDatabase.Query( query.str().c_str() );
		if(result2)
		{
			do
			{
				Field *fields2 = result2->Fetch();
				gMember = new guildMembers;
				gMember->memberGuid = fields2[0].GetUInt32();
				gMember->memberName = fields2[2].GetString();
				gMember->Rank = fields2[3].GetUInt32();
				gMember->publicNote = fields2[4].GetString();
				gMember->officerNote = fields2[5].GetString();
				gMember->lastOnline = fields2[6].GetUInt32();
				gMember->lastClass = fields2[7].GetUInt32();
				gMember->lastLevel = fields2[8].GetUInt32();
				gMember->lastZone = fields2[9].GetUInt32();

				pGuild->AddGuildMember( gMember );
			}while( result2->NextRow() );
			delete result2;
		}

		query.str("");
		query << "SELECT * FROM guild_ranks WHERE guildId=" << pGuild->GetGuildId() << " ORDER BY rankId";
		result3 = sDatabase.Query( query.str().c_str() );
		if(result3)
		{ 
			do
			{
				Field *fields3 = result3->Fetch();

				rankList.name = fields3[2].GetString();
				rankList.rights = fields3[3].GetUInt32();

				pGuild->CreateRank(rankList.name, rankList.rights );
			}while( result3->NextRow() );
			delete result3;
		}
		pGuild->LoadGuildCreationDate();

		AddGuild(pGuild);

	}while( result->NextRow() );

	delete result;
}

void ObjectMgr::LoadCharters()
{
	int i = 0;
	std::stringstream query;
	QueryResult *result = sDatabase.Query( "SELECT * FROM charters" );

	if(!result)
		return;

	guildCharter *gc;

	do
	{
		Field *fields = result->Fetch();

		gc = new guildCharter;
		gc->leaderGuid = fields[0].GetUInt64();
		gc->guildName = fields[1].GetString();
		gc->itemGuid = fields[2].GetUInt32();
		gc->signCount = fields[3].GetUInt8();
		charterName *cn;
		for(i = 0;i<9;i++)
		{
			if(fields[i+4].GetUInt64() != 0)
			{
				cn = new charterName;
				cn->signer = fields[i+4].GetUInt64();                   
				gc->signList.push_back(*cn);
				delete cn;
			}
		}
		AddCharter(gc);

	} while( result->NextRow() );

	delete result;
}

void ObjectMgr::SaveCharters(uint64 leaderGuid)
{
	std::stringstream query;
	int i = 0, j = 0;
	query << "DELETE FROM charters WHERE leaderGuid = " << leaderGuid << ";";
	sDatabase.Execute(query.str( ).c_str( ));
	query.rdbuf()->str("");
	guildCharter* gc = GetGuildCharter(leaderGuid);
	if(!gc)
		return;

	int signCount = gc->signCount;

	query << "INSERT INTO charters VALUES(";
	query << gc->leaderGuid << ", '";
	query << gc->guildName << "', ";
	query << gc->itemGuid << ", ";
	query << signCount;
	std::list<charterName>::iterator itr;
	for(itr = gc->signList.begin(); itr != gc->signList.end(); itr++)
	{
		query << ", " << itr->signer;
		i++;
	}
	i=9-i;
	for(j=0;j<i;j++)
		query << ", 0";
	query << ")";
	sLog.outDebug(query.str( ).c_str( ));
	sDatabase.Execute(query.str( ).c_str( ));
}

void ObjectMgr::LoadFaction()
{
	QueryResult *result = sDatabase.Query( "SELECT * FROM factionTemplates" );

	if( !result )
		return;

	Faction *pFact;

	do
	{
		Field *fields = result->Fetch();

		pFact = new Faction;
		pFact->race = fields[0].GetUInt8();
		pFact->id = fields[1].GetUInt8();
		pFact->state = fields[2].GetUInt8();
		pFact->standing = fields[3].GetUInt32();

		AddFaction(pFact);

	} while( result->NextRow() );

	delete result;
}

void ObjectMgr::LoadTaxiNodes()
{
	QueryResult *result = sDatabase.Query( "SELECT * FROM taxinodes" );

	if( !result )
		return;

	TaxiNodes *pTaxiNodes;

	do
	{
		Field *fields = result->Fetch();

		pTaxiNodes = new TaxiNodes;
		pTaxiNodes->id = fields[0].GetUInt8();
		pTaxiNodes->continent = fields[1].GetUInt8();
		pTaxiNodes->x = fields[2].GetFloat();
		pTaxiNodes->y = fields[3].GetFloat();
		pTaxiNodes->z = fields[4].GetFloat();
		//pTaxiNodes->name = fields[5].GetString();
		//pTaxiNodes->flags = fields[6].GetUInt32();
		pTaxiNodes->mount = fields[7].GetUInt16();

		AddTaxiNodes(pTaxiNodes);

	} while( result->NextRow() );

	delete result;
}

void ObjectMgr::LoadTaxiPath()
{
	QueryResult *result = sDatabase.Query( "SELECT * FROM taxipath" );

	if( !result )
		return;

	TaxiPath *pTaxiPath;

	do
	{
		Field *fields = result->Fetch();

		pTaxiPath = new TaxiPath;
		pTaxiPath->id = fields[0].GetUInt16();
		pTaxiPath->source = fields[1].GetUInt8();
		pTaxiPath->destination = fields[2].GetUInt8();
		pTaxiPath->price = fields[3].GetUInt32();

		AddTaxiPath(pTaxiPath);

	} while( result->NextRow() );

	delete result;
}

void ObjectMgr::LoadTaxiPathNodes()
{
	QueryResult *result = sDatabase.Query( "SELECT * FROM taxipathnodes ORDER BY 'index'" );

	if( !result )
		return;

	TaxiPathNodes *pTaxiPathNodes;

	do
	{
		Field *fields = result->Fetch();

		pTaxiPathNodes = new TaxiPathNodes;
		pTaxiPathNodes->id = fields[0].GetUInt16();
		pTaxiPathNodes->path = fields[1].GetUInt16();
		pTaxiPathNodes->index = fields[2].GetUInt8();
		pTaxiPathNodes->continent = fields[3].GetUInt8();
		pTaxiPathNodes->x = fields[4].GetFloat();
		pTaxiPathNodes->y = fields[5].GetFloat();
		pTaxiPathNodes->z = fields[6].GetFloat();
		//pTaxiPathNodes->unkown1 = fields[7].GetUInt32();
		//pTaxiPathNodes->unkown2 = fields[8].GetUInt32();

		AddTaxiPathNodes(pTaxiPathNodes);

	} while( result->NextRow() );

	delete result;
}

bool ObjectMgr::GetGlobalTaxiNodeMask( uint32 curloc, uint32 *Mask )
{
	TaxiPathMap::const_iterator itr;
	TaxiPathNodesVec::iterator pathnodes_itr;
	uint8 field;

	for (itr = mTaxiPath.begin(); itr != mTaxiPath.end(); itr++)
	{
		if( itr->second->source == curloc )
		{
			for( pathnodes_itr = vTaxiPathNodes.begin();
				pathnodes_itr != vTaxiPathNodes.end(); ++pathnodes_itr )
			{
				if ((*pathnodes_itr)->path == itr->second->id)
				{
					field = (uint8)((itr->second->destination - 1) / 32);
					Mask[field] |= 1 << ( (itr->second->destination - 1 ) % 32 );
					break;
				}
			}
		}
	}

	return 1;
}

uint32 ObjectMgr::GetNearestTaxiNode( float x, float y, float z, uint32 mapid )
{
	uint32 nearest = 0;
	float distance = -1;
	float nx, ny, nz, nd;

	TaxiNodesMap::const_iterator nodes_itr;
	TaxiPathMap::const_iterator path_itr;
	TaxiPathNodesVec::iterator pathnodes_itr;

	for (nodes_itr = mTaxiNodes.begin(); nodes_itr != mTaxiNodes.end(); nodes_itr++)
	{
		if( nodes_itr->second->continent == mapid )
		{
			nx = nodes_itr->second->x - x;
			ny = nodes_itr->second->y - y;
			nz = nodes_itr->second->z - z;
			nd = nx * nx + ny * ny + nz * nz;
			if( nd < distance || distance < 0 )
			{
				for (path_itr = mTaxiPath.begin();
					path_itr != mTaxiPath.end();
					++path_itr)
				{
					if( path_itr->second->source == nodes_itr->second->id )
						break;
				}

				if( path_itr == mTaxiPath.end() )
					continue;

				for (pathnodes_itr = vTaxiPathNodes.begin();
					pathnodes_itr != vTaxiPathNodes.end();
					++pathnodes_itr)
				{
					if( (*pathnodes_itr)->path == path_itr->second->id &&
						(*pathnodes_itr)->continent == mapid &&
						(*pathnodes_itr)->index == 0)
					{
						distance = nd;
						nearest = nodes_itr->second->id;
						break;
					}
				}
			}
		}
	}

	return nearest;
}

void ObjectMgr::GetTaxiPath( uint32 source, uint32 destination, uint32 &path, uint32 &cost)
{
	TaxiPathMap::const_iterator itr;

	for (itr = mTaxiPath.begin(); itr != mTaxiPath.end(); itr++)
	{
		if( (itr->second->source == source) && (itr->second->destination == destination) )
			path = itr->second->id;
		cost = itr->second->price;
	}
}

uint16 ObjectMgr::GetTaxiMount( uint32 id )
{
	TaxiNodesMap::const_iterator itr;

	for (itr = mTaxiNodes.begin(); itr != mTaxiNodes.end(); itr++)
	{
		if( (itr->second->id == id) )
			return itr->second->mount;
	}

	return 0;
}

void ObjectMgr::GetTaxiPathNodes( uint32 path, Path *pathnodes )
{
	uint16 i = 0;

	for( TaxiPathNodesVec::iterator itr = vTaxiPathNodes.begin();
		itr != vTaxiPathNodes.end(); ++itr )
	{
		if ((*itr)->path == path)
		{
			i++;
		}
	}

	pathnodes->setLength( i );

	i = 0;
	for( TaxiPathNodesVec::iterator itr = vTaxiPathNodes.begin();
		itr != vTaxiPathNodes.end(); ++itr )
	{
		if ((*itr)->path == path)
		{
			pathnodes->getNodes( )[ i ].x = (*itr)->x;
			pathnodes->getNodes( )[ i ].y = (*itr)->y;
			pathnodes->getNodes( )[ i ].z = (*itr)->z;
			i++;
		}
	}
}
Corpse *ObjectMgr::GetCorpseByOwner(Player *pOwner)
{
	CorpseMap::const_iterator itr;
	for (itr = mCorpses.begin(); itr != mCorpses.end(); itr++)
	{
		if(!itr->second->GetUInt64Value(CORPSE_FIELD_OWNER))
			continue;
		if(itr->second->GetUInt64Value(CORPSE_FIELD_OWNER) == pOwner->GetGUID())
			return itr->second;
	}
	return NULL;
}

void ObjectMgr::LoadCorpses()
{
	Corpse *pCorpse;

	QueryResult *result = sDatabase.Query( "SELECT * FROM Corpses" );
	if( !result )
		return;
	do
	{
		pCorpse = new Corpse;
		Field *fields = result->Fetch();
		pCorpse->Create(fields[0].GetUInt32());

		pCorpse->SetPosition(fields[1].GetFloat(), fields[2].GetFloat(), fields[3].GetFloat(), fields[4].GetFloat());
		pCorpse->SetZoneId(fields[5].GetUInt32());
		pCorpse->SetMapId(fields[6].GetUInt32());
		pCorpse->LoadValues( fields[7].GetString());;
		AddObject(pCorpse);
	} while( result->NextRow() );

	delete result;
}

Corpse* ObjectMgr::LoadCorpse(uint32 guid)
{
	Corpse *pCorpse;
	std::stringstream query;
	query << "SELECT * FROM Corpses WHERE guid = " << guid;

	QueryResult *result = sDatabase.Query( query.str().c_str() );

	if( !result )
		return NULL;

	do
	{
		pCorpse = new Corpse;
		Field *fields = result->Fetch();
		pCorpse->Create(fields[0].GetUInt32());

		pCorpse->SetPosition(fields[1].GetFloat(), fields[2].GetFloat(), fields[3].GetFloat(), fields[4].GetFloat());
		pCorpse->SetZoneId(fields[5].GetUInt32());
		pCorpse->SetMapId(fields[6].GetUInt32());
		pCorpse->LoadValues( fields[7].GetString());;
		AddObject(pCorpse);
		pCorpse->AddToWorld();
	} while( result->NextRow() );

	delete result;

	return pCorpse;
}

void ObjectMgr::AddGossipText(GossipText *pGText)
{
	ASSERT( pGText->ID );
	ASSERT( mGossipText.find(pGText->ID) == mGossipText.end() );
	mGossipText[pGText->ID] = pGText;
}

GossipText *ObjectMgr::GetGossipText(uint32 ID)
{
	GossipTextMap::const_iterator itr;
	for (itr = mGossipText.begin(); itr != mGossipText.end(); itr++)
	{
		if(itr->second->ID == ID)
			return itr->second;
	}
	return NULL;
}

void ObjectMgr::LoadGossipText()
{
	GossipText *pGText;

	QueryResult *result = sDatabase.Query( "SELECT * FROM npc_text" );
	if( !result )
		return;

	do
	{
		Field *fields = result->Fetch();
		pGText = new GossipText;
		pGText->ID = fields[0].GetUInt32();
		pGText->Text = fields[2].GetString();
		AddGossipText(pGText);

	}while( result->NextRow() );

	delete result;
}

void ObjectMgr::AddGossip(GossipNpc *pGossip)
{
	ASSERT( pGossip->ID );
	mGossipNpc[pGossip->ID] = pGossip;
}

GossipNpc *ObjectMgr::GetGossipByGuid(uint32 guid)
{
	GossipNpcMap::iterator iter, end;
	for( iter = mGossipNpc.begin(), end = mGossipNpc.end(); iter != end; iter++ )
	{
		GossipNpc *pObj = iter->second;
		if(pObj->Guid == guid)
			return pObj;
	}
	return NULL;
}

void ObjectMgr::LoadGossips()
{
	GossipNpc *pGossip;

	QueryResult *result = sDatabase.Query( "SELECT * FROM npc_gossip" );
	if( !result )
		return;

	do
	{
		Field *fields = result->Fetch();
		pGossip = new GossipNpc;
		pGossip->ID = fields[0].GetUInt32();
		pGossip->Guid = fields[1].GetUInt32();
		pGossip->TextID = fields[3].GetUInt32();
		pGossip->OptionCount = fields[4].GetUInt32();
		if(pGossip->OptionCount > 0)
		{
			pGossip->pOptions = new GossipOptions[pGossip->OptionCount];

			std::stringstream query;
			query << "SELECT * FROM npc_options WHERE GOSSIP_ID=" << pGossip->ID;
			QueryResult *result2 = sDatabase.Query( query.str().c_str() );
			if( result2 )
			{
				for(uint32 i=0; i<pGossip->OptionCount; i++)
				{
					Field *fields1 = result2->Fetch();

					pGossip->pOptions[i].ID = fields1[0].GetUInt32();
					pGossip->pOptions[i].GossipID = fields1[1].GetUInt32();
					pGossip->pOptions[i].Icon = fields1[2].GetUInt32();
					pGossip->pOptions[i].OptionText = fields1[3].GetString();
					pGossip->pOptions[i].NextTextID = fields1[4].GetUInt32();
					pGossip->pOptions[i].Special = fields1[5].GetUInt32();

					result2->NextRow();
				}
				delete result2;
			}
		}
		AddGossip(pGossip);

	} while( result->NextRow() );

	delete result;
}

void ObjectMgr::AddGraveyard(GraveyardTeleport *pgrave)
{
	ASSERT( pgrave );
	ASSERT( mGraveyards.find(pgrave->ID) == mGraveyards.end() );
	mGraveyards[pgrave->ID] = pgrave;
}

void ObjectMgr::LoadGraveyards()
{
	GraveyardTeleport *pgrave;
	QueryResult *result = sDatabase.Query( "SELECT * FROM graveyards" );
	if( !result )
		return;

	do
	{
		Field *fields = result->Fetch();
		pgrave = new GraveyardTeleport;
		pgrave->ID = fields[0].GetUInt32();
		pgrave->X = fields[1].GetFloat();
		pgrave->Y = fields[2].GetFloat();
		pgrave->Z = fields[3].GetFloat();
		pgrave->O = fields[4].GetFloat();
		pgrave->ZoneId = fields[5].GetUInt32();
		pgrave->MapId = fields[6].GetUInt32();
		pgrave->FactionID = fields[7].GetUInt32();

		AddGraveyard(pgrave);

	}while( result->NextRow() );

	delete result;
}

void ObjectMgr::LoadGMTickets()
{
	QueryResult *result = sDatabase.Query( "SELECT * FROM gm_tickets" );

	if( !result )
		return;

	GM_Ticket *ticket;

	do
	{
		Field *fields = result->Fetch();

		ticket = new GM_Ticket;
		ticket->guid = fields[0].GetUInt32();
		ticket->name = fields[1].GetString();
		ticket->level = fields[2].GetUInt32();
		ticket->type = fields[3].GetUInt32();
		ticket->posX = fields[4].GetFloat();
		ticket->posY = fields[5].GetFloat();
		ticket->posZ = fields[6].GetFloat();
		ticket->message = fields[7].GetString();
		ticket->timestamp = fields[8].GetUInt32();

		AddGMTicket(ticket);

	} while( result->NextRow() );

	delete result;
}

void ObjectMgr::SaveGMTicket(uint64 guid)
{
	std::stringstream ss1;
	std::stringstream ss2;
	ss1 << "DELETE FROM gm_tickets WHERE guid = " << guid << ";";
	sDatabase.Execute(ss1.str( ).c_str( ));
	GM_Ticket* ticket = GetGMTicket(guid);
	if(!ticket)
	{
		return;
	}

	ss2 << "INSERT INTO gm_tickets (guid, name, level, type, posX, posY, posZ, message, timestamp) VALUES(";
	ss2 << ticket->guid << ", ";
	ss2 << ticket->name << ", ";
	ss2 << ticket->level << ", ";
	ss2 << ticket->type << ", ";
	ss2 << ticket->posX << ", ";
	ss2 << ticket->posY << ", ";
	ss2 << ticket->posZ << ", '";
	ss2 << ticket->message << "', ";
	ss2 << ticket->timestamp << ");";
	sDatabase.Execute(ss2.str( ).c_str( ));
}

void ObjectMgr::SetHighestGuids()
{
	QueryResult *result;
	uint32 corpseshi=0;
	uint32 gameobjectshi=0;

	result = sDatabase.Query( "SELECT MAX(guid) FROM characters" );
	if( result )
	{
		m_hiCharGuid = (*result)[0].GetUInt32()+1;

		delete result;
	}

	result = sDatabase.Query( "SELECT MAX(id) FROM creatures" );
	if( result )
	{
		m_hiCreatureGuid = (*result)[0].GetUInt32()+1;

		delete result;
	}

	result = sDatabase.Query( "SELECT MAX(guid) FROM item_instances" );
	if( result )
	{
		m_hiItemGuid = (*result)[0].GetUInt32()+1;

		delete result;
	}

	result = sDatabase.Query( "SELECT MAX(name_id) FROM creature_names" );
	if( result )
	{
		m_hiNameGuid = (*result)[0].GetUInt32()+1;

		delete result;
	}

	result = sDatabase.Query( "SELECT MAX(name_id) FROM gameobject_names" );
	if( result )
	{
		m_hiGoNameGuid = (*result)[0].GetUInt32()+1;

		delete result;
	}

	result = sDatabase.Query( "SELECT MAX(id) FROM gameobjects" );
	if( result )
	{
		gameobjectshi = (*result)[0].GetUInt32()+1;

		delete result;
	}

	result = sDatabase.Query( "SELECT MAX(Id) FROM auctionhouse" );
	if( result )
	{
		m_auctionid = (*result)[0].GetUInt32()+1;

		delete result;
	}
	else
	{
		m_auctionid = 0;
	}
	result = sDatabase.Query( "SELECT MAX(mailId) FROM mail" );
	if( result )
	{
		m_mailid = (*result)[0].GetUInt32()+1;

		delete result;
	}
	else
	{
		m_mailid = 0;
	}
	//FIXME: Corpses are Gameobjects. IF we add other gameobjects we need a unified table
	result = sDatabase.Query( "SELECT MAX(guid) FROM corpses" );
	if( result )
	{
		corpseshi = (*result)[0].GetUInt32()+1;

		delete result;
	}
	if(corpseshi > gameobjectshi )
	{
		m_hiGoGuid = corpseshi;
	}
	else
	{
		m_hiGoGuid = gameobjectshi;
	}
}
uint32 ObjectMgr::GenerateAuctionID()
{
	objmgr.m_auctionid++;
	return objmgr.m_auctionid;
}
uint32 ObjectMgr::GenerateMailID()
{
	objmgr.m_mailid++;
	return objmgr.m_mailid;
}
uint32 ObjectMgr::GenerateLowGuid(uint32 guidhigh)
{
	uint32 guidlow = 0;

	switch(guidhigh)
	{
	case HIGHGUID_ITEM          : guidlow = objmgr.m_hiItemGuid++;     break;
		//case HIGHGUID_CONTAINER   : guidlow = objmgr.m_hiItemGuid++;     break;
	case HIGHGUID_UNIT          : guidlow = objmgr.m_hiCreatureGuid++; break;
	case HIGHGUID_PLAYER        : guidlow = objmgr.m_hiCharGuid++;     break;
	case HIGHGUID_GAMEOBJECT    : guidlow = objmgr.m_hiGoGuid++;       break;
		//case HIGHGUID_CORPSE      : guidlow = objmgr.m_hiGoGuid++;       break;
	case HIGHGUID_DYNAMICOBJECT : guidlow = objmgr.m_hiDoGuid++;       break;
	default                     : ASSERT(guidlow);
	}

	return guidlow;
}

void ObjectMgr::LoadCellObjects(uint32 x, uint32 y, uint32 sizeX, uint32 sizeY, int32 minX, int32 minY, uint32 map)
{
	int32 startX = minX + (x*sizeX);
	int32 endX = startX + sizeX;
	int32 startY = minY + (y*sizeY);
	int32 endY = startY + sizeY;

	//Load Creatures
	LoadCreatures(startX, endX, startY, endY, map);
	//Load GameObjects
	LoadGameObjects(startX, endX, startY, endY, map);
	//Load Corpses
	LoadCorpses(startX, endX, startY, endY, map);
}

void ObjectMgr::LoadCreatures(int32 startX, int32 endX, int32 startY, int32 endY, int32 map)
{
	std::stringstream query;
	uint32 count = 0;

	query << "SELECT id FROM creatures where ((positionX >= " << startX \
		<< ") AND (positionX < " << endX << ")) AND ((positionY >= " << startY \
		<< ") AND (positionY < " << endY << ")) AND (mapId = " << map << ")";

	QueryResult *result = sDatabase.Query( query.str( ).c_str( ) );

	if( !result )
	{
		Log::getSingleton( ).outDebug("0 Creatures Loaded.");
		return;
	}

	Creature* unit;
	Field *fields;

	do
	{
		count++;

		fields = result->Fetch();

		unit = new Creature;
		ASSERT(unit);

		unit->LoadFromDB(fields[0].GetUInt32());
		//Log::getSingleton( ).outError("AddObject at ObjectMgr.cpp line 600");
		AddObject(unit);
		unit->AddToWorld();
	}
	while( result->NextRow() );

	Log::getSingleton( ).outDebug("%d Creatures Loaded.", count);

	delete result;
}

void ObjectMgr::LoadCorpses(int32 startX, int32 endX, int32 startY, int32 endY, int32 map)
{
	std::stringstream query;
	uint32 count = 0;

	query << "SELECT * FROM corpses where ((positionX >= " << startX \
		<< ") AND (positionX < " << endX << ")) AND ((positionY >= " << startY \
		<< ") AND (positionY < " << endY << ")) AND (mapId = " << map << ")";

	QueryResult *result = sDatabase.Query( query.str( ).c_str( ) );

	if( !result )
	{
		Log::getSingleton( ).outDebug("0 Corpses Loaded.");    
		return;
	}

	Corpse *pCorpse;

	do
	{
		count++;

		pCorpse = new Corpse;
		Field *fields = result->Fetch();
		pCorpse->Create(fields[0].GetUInt32());

		pCorpse->SetPosition(fields[1].GetFloat(), fields[2].GetFloat(), fields[3].GetFloat(), fields[4].GetFloat());
		pCorpse->SetZoneId(fields[5].GetUInt32());
		pCorpse->SetMapId(fields[6].GetUInt32());
		pCorpse->LoadValues( fields[7].GetString());;
		//Log::getSingleton( ).outError("AddObject at ObjectMgr.cpp line 940");
		AddObject(pCorpse);
		pCorpse->AddToWorld();
	} while( result->NextRow() );

	Log::getSingleton( ).outDebug("%d Corpses Loaded.", count);

	delete result;
}

void ObjectMgr::LoadGameObjects(int32 startX, int32 endX, int32 startY, int32 endY, int32 map)
{
	std::stringstream query;
	uint32 count = 0;

	query << "SELECT id FROM gameobjects where ((positionX >= " << startX \
		<< ") AND (positionX < " << endX << ")) AND ((positionY >= " << startY \
		<< ") AND (positionY < " << endY << ")) AND (mapId = " << map << ")";

	QueryResult *result = sDatabase.Query( query.str( ).c_str( ) );

	if( !result )
	{
		Log::getSingleton( ).outDebug("0 GameObjects Loaded.");
		return;
	}

	GameObject* go;
	Field *fields;

	do
	{
		count++;

		fields = result->Fetch();

		go = new GameObject;
		ASSERT(go);

		go->LoadFromDB(fields[0].GetUInt32());
		//Log::getSingleton( ).outError("AddObject at ObjectMgr.cpp line 629");
		AddObject(go);
		go->AddToWorld();
	}
	while( result->NextRow() );

	Log::getSingleton( ).outDebug("%d GameObjects Loaded.", count);

	delete result;
}

void ObjectMgr::AddGameObjectName(GameObjectInfo *goinfo)
{
	ASSERT( mGameObjectNames.find(goinfo->ID) == mGameObjectNames.end() );
	//verifying if info for that gameobject already exists(need some cleaning here some time)
	GameObjectNameMap::iterator itr = mGameObjectNames.find( goinfo->ID );
	//if found we delete the old gameobject info
	if( itr != mGameObjectNames.end( ) )
		mGameObjectNames.erase(itr);
	mGameObjectNames[goinfo->ID] = goinfo;
}

GameObjectInfo *ObjectMgr::GetGameObjectName(uint32 ID)
{
	GameObjectNameMap::const_iterator itr = mGameObjectNames.find( ID );
	if( itr != mGameObjectNames.end( ) )
		return itr->second;

	GameObjectInfo *goi;
	goi = new GameObjectInfo;
	memset(goi,0,sizeof(GameObjectInfo));
	goi->ID = ID;
	goi->Name = "";
	goi->DisplayID = 0;
	return goi;
}

void ObjectMgr::LoadGameObjectNames()
{
	GameObjectInfo *gon;
	QueryResult *result = sDatabase.Query( "SELECT * FROM gameobject_names" );
	if(result)
	{
		do
		{
			Field *fields = result->Fetch();

			gon = new GameObjectInfo;

			gon->ID = fields[0].GetUInt32();
			gon->Type =  fields[1].GetUInt32();
			gon->DisplayID =  fields[2].GetUInt32();
			gon->Name =  fields[3].GetString();
			gon->sound0 =  fields[4].GetUInt32();
			gon->sound1 =  fields[5].GetUInt32();
			gon->sound2 = fields[6].GetUInt32();
			gon->sound3 = fields[7].GetUInt32();
			gon->sound4 =  fields[8].GetUInt32();
			gon->sound5 =  fields[9].GetUInt32();
			gon->sound6 =  fields[10].GetUInt32();
			gon->sound7 =   fields[11].GetUInt32();
			gon->sound8 =  fields[12].GetUInt32();
			gon->sound9 =  fields[13].GetUInt32();
			gon->Unknown1 =  fields[14].GetUInt32();
			gon->Unknown2 =  fields[15].GetUInt32();
			gon->Unknown3 =  fields[16].GetUInt32();
			gon->Unknown4 =  fields[17].GetUInt32();
			gon->Unknown5 =  fields[18].GetUInt32();
			gon->Unknown6 =  fields[19].GetUInt32();

			AddGameObjectName(gon);
		} while( result->NextRow() );

		delete result;
	}

	result = sDatabase.Query( "SELECT MAX(name_id) FROM gameobject_names" );
	if(result)
	{
		m_hiGoNameGuid = (*result)[0].GetUInt32();

		delete result;
	}
}

void ObjectMgr::LoadPvPAreas()
{
	std::stringstream query;
	QueryResult *result = sDatabase.Query( "SELECT * FROM pvpareas" );

	if(!result)
		return;

	PvPArea *pPvPArea;

	do
	{
		Field *fields = result->Fetch();

		pPvPArea = new PvPArea;

		pPvPArea->AreaId = fields[0].GetUInt32();
		pPvPArea->AreaName = fields[1].GetString();
		pPvPArea->PvPType = fields[2].GetUInt16();

		AddPvPArea(pPvPArea);
	}while( result->NextRow() );

	delete result;
}

Player* ObjectMgr::GetPlayer(const char* name)
{
	PlayerMap::const_iterator itr;
	for (itr = mPlayers.begin(); itr != mPlayers.end(); itr++)
	{
		if(strcmp(itr->second->GetName(), name) == 0)
			return itr->second;
	}

	return NULL;
}

Player* ObjectMgr::GetPlayer(uint64 guid)
{
	PlayerMap::const_iterator itr = mPlayers.find(GUID_LOPART(guid));
	if (itr != mPlayers.end())
		return itr->second;
	return NULL;
}

Creature* ObjectMgr::GetCreature(uint64 guid)
{
	CreatureMap::const_iterator itr = mCreatures.find(GUID_LOPART(guid));
	if (itr != mCreatures.end())
		return itr->second;
	return NULL;
}

void ObjectMgr::AddCreatureSpawnTemplate(CreatureSpawnTemplate *ct)
{
	ASSERT( ct );
	ASSERT( mCreatureSpawnTemplates.find(ct->EntryID) == mCreatureSpawnTemplates.end() );
	mCreatureSpawnTemplates[ct->EntryID] = ct;
}

CreatureSpawnTemplate* ObjectMgr::GetCreatureSpawnTemplate(uint32 entryid) const
{
	CreatureSpawnTemplateMap::const_iterator itr = mCreatureSpawnTemplates.find( entryid );
	if( itr != mCreatureSpawnTemplates.end( ) )
		return itr->second;
	return NULL;
}

bool ObjectMgr::RemoveCreatureSpawnTemplate(uint32 entryid)
{
	CreatureSpawnTemplateMap::iterator i = mCreatureSpawnTemplates.find( entryid );
	if (i == mCreatureSpawnTemplates.end())
	{
		return false;
	}
	mCreatureSpawnTemplates.erase(i);
	return true;
}

void ObjectMgr::AddAuction(AuctionEntry *ah)
{
	ASSERT( ah );
	ASSERT( mAuctions.find(ah->Id) == mAuctions.end() );
	mAuctions[ah->Id] = ah;
}

AuctionEntry* ObjectMgr::GetAuction(uint32 id) const
{
	AuctionEntryMap::const_iterator itr = mAuctions.find( id );
	if( itr != mAuctions.end( ) )
		return itr->second;
	return NULL;
}

bool ObjectMgr::RemoveAuction(uint32 id)
{
	AuctionEntryMap::iterator i = mAuctions.find(id);
	if (i == mAuctions.end())
	{
		return false;
	}
	mAuctions.erase(i);
	return true;
}

ItemPrototype* ObjectMgr::GetItemPrototype(uint32 id) const
{
	ItemPrototypeMap::const_iterator itr = mItemPrototypes.find( id );
	if( itr != mItemPrototypes.end( ) )
		return itr->second;
	return NULL;
}

void ObjectMgr::AddItemPrototype(ItemPrototype *itemProto)
{
	ASSERT( itemProto );
	ASSERT( mItemPrototypes.find(itemProto->ItemId) == mItemPrototypes.end() );
	mItemPrototypes[itemProto->ItemId] = itemProto;
}

Item* ObjectMgr::GetMItem(uint32 id)
{
	ItemMap::const_iterator itr = mMitems.find(id);
	if (itr != mMitems.end())
	{
		return itr->second;
	}
	return NULL;
}

void ObjectMgr::AddMItem(Item* it)
{
	ASSERT( it );
	ASSERT( mMitems.find(it->GetGUIDLow()) == mMitems.end());
	mMitems[it->GetGUIDLow()] = it;
}

bool ObjectMgr::RemoveMItem(uint32 id)
{
	ItemMap::iterator i = mMitems.find(id);
	if (i == mMitems.end())
	{
		return false;
	}
	mMitems.erase(i);
	return true;
}

Item* ObjectMgr::GetAItem(uint32 id)
{
	ItemMap::const_iterator itr = mAitems.find(id);
	if (itr != mAitems.end())
	{
		return itr->second;
	}
	return NULL;
}

void ObjectMgr::AddAItem(Item* it)
{
	ASSERT( it );
	ASSERT( mAitems.find(it->GetGUIDLow()) == mAitems.end());
	mAitems[it->GetGUIDLow()] = it;
}

bool ObjectMgr::RemoveAItem(uint32 id)
{
	ItemMap::iterator i = mAitems.find(id);
	if (i == mAitems.end())
	{
		return false;
	}
	mAitems.erase(i);
	return true;
}

Trainerspell* ObjectMgr::GetTrainerspell(uint32 id) const
{
	TrainerspellMap::const_iterator itr = mTrainerspells.find( id );
	if( itr != mTrainerspells.end( ) )
		return itr->second;
	return NULL;
}

void ObjectMgr::AddTrainerspell(Trainerspell *trainspell)
{
	ASSERT( trainspell );
	ASSERT( mTrainerspells.find(trainspell->Id) == mTrainerspells.end() );
	mTrainerspells[trainspell->Id] = trainspell;
}

void ObjectMgr::AddPlayerCreateInfo(PlayerCreateInfo *playerCreate)
{
	ASSERT( playerCreate );
	mPlayerCreateInfo[playerCreate->index] = playerCreate;
}

PlayerCreateInfo* ObjectMgr::GetPlayerCreateInfo(uint8 race, uint8 class_) const
{
	PlayerCreateInfoMap::const_iterator itr;
	for (itr = mPlayerCreateInfo.begin(); itr != mPlayerCreateInfo.end(); itr++)
	{
		if( (itr->second->race == race) && (itr->second->class_ == class_) )
			return itr->second;
	}
	return NULL;
}

void ObjectMgr::AddGuild(Guild *pGuild)
{
	ASSERT( pGuild );
	mGuild[pGuild->GetGuildId()] = pGuild;
}

uint32 ObjectMgr::GetTotalGuildCount()
{
	uint32 count=0;
	GuildMap::const_iterator itr;
	for (itr = mGuild.begin();itr != mGuild.end(); itr++)
	{
		count++;
	}
	return count;
}

bool ObjectMgr::RemoveGuild(uint32 guildId)
{
	GuildMap::iterator i = mGuild.find(guildId);
	if (i == mGuild.end())
	{
		return false;
	}
	
	i->second->RemoveFromDb();
	
	mGuild.erase(i);

	//Guild *pGuild = GetGuild(guildId);
	//pGuild->RemoveFromDb();

	return true;
}

Guild* ObjectMgr::GetGuild(uint32 guildId)
{
	GuildMap::const_iterator itr;
	Log::getSingleton().outError("guildId: %d",guildId);
	for (itr = mGuild.begin();itr != mGuild.end(); itr++)
	{
		if( itr->second->GetGuildId() == guildId )
			return itr->second;
	}
	return NULL;
}

Guild* ObjectMgr::GetGuildByLeaderGuid(uint64 leaderGuid)
{
	GuildMap::const_iterator itr;
	Log::getSingleton().outError("leaderGuid: %d",leaderGuid);
	for (itr = mGuild.begin();itr != mGuild.end(); itr++)
	{
		if( itr->second->GetGuildLeaderGuid() == leaderGuid )
			return itr->second;
	}
	return NULL;
}

Guild* ObjectMgr::GetGuildByGuildName(std::string guildName)
{
	GuildMap::const_iterator itr;
	Log::getSingleton().outError("guildname: %s",guildName.c_str());
	for (itr = mGuild.begin();itr != mGuild.end(); itr++)
	{
		if( itr->second->GetGuildName() == guildName )
			return itr->second;
	}
	return NULL;
}

void ObjectMgr::AddCharter(guildCharter* gc)
{
	ASSERT( gc );
	Guild_CharterList.push_back((gc));
}

void ObjectMgr::DeleteCharter(uint64 leaderGuid)
{
	std::list<guildCharter*>::iterator i;
	for(i = Guild_CharterList.begin(); i != Guild_CharterList.end(); i++)
	{
		if((*i)->leaderGuid == leaderGuid)
		{
			Guild_CharterList.erase(i);
			break;
		}
	}
}

guildCharter *ObjectMgr::GetGuildCharter(uint64 leaderGuid)
{
	std::list<guildCharter*>::iterator i;
	for(i = Guild_CharterList.begin(); i != Guild_CharterList.end(); i++)
	{
		if((*i)->leaderGuid == leaderGuid)
		{
			return (*i);
		}
	}
	return NULL;
}

guildCharter *ObjectMgr::GetGuildCharterByCharterGuid(uint32 itemGuid)
{
	std::list<guildCharter*>::iterator i;
	for(i = Guild_CharterList.begin(); i != Guild_CharterList.end(); i++)
	{
		if((*i)->itemGuid == itemGuid)
		{
			return (*i);
		}
	}
	return NULL;
}

void ObjectMgr::AddFaction(Faction* fact)
{
	mFactions[m_highest_fact++] = fact;
}

Faction* ObjectMgr::GetFaction(uint8 race, uint8 id)
{
	FactionMap::const_iterator itr;
	for (itr = mFactions.begin();itr != mFactions.end(); itr++)
	{
		if( itr->second->race == race && itr->second->id == id)
			return itr->second;
	}
	return NULL;
}

void ObjectMgr::AddTaxiNodes(TaxiNodes *taxiNodes)
{
	ASSERT( taxiNodes );
	mTaxiNodes[taxiNodes->id] = taxiNodes;
}

void ObjectMgr::AddTaxiPath(TaxiPath *taxiPath)
{
	ASSERT( taxiPath );
	mTaxiPath[taxiPath->id] = taxiPath;
}

void ObjectMgr::AddTaxiPathNodes(TaxiPathNodes *taxiPathNodes)
{
	ASSERT( taxiPathNodes );
	vTaxiPathNodes.push_back(taxiPathNodes);
}

void ObjectMgr::AddTeleportCoords(TeleportCoords* TC)
{
	ASSERT( TC );
	mTeleports[TC->id] = TC;  
}

TeleportCoords* ObjectMgr::GetTeleportCoords(uint32 id) const
{
	TeleportMap::const_iterator itr = mTeleports.find( id );
	if( itr != mTeleports.end( ) )
		return itr->second;
	return NULL;
}

void ObjectMgr::AddGMTicket(GM_Ticket *ticket)
{
	ASSERT( ticket );
	GM_TicketList.push_back(ticket);
}

//modified for vs2005 compatibility
void ObjectMgr::remGMTicket(uint64 guid)
{
	for(std::list<GM_Ticket*>::iterator i = GM_TicketList.begin(); i != GM_TicketList.end();)
	{
		if((*i)->guid == guid)
		{
			i = GM_TicketList.erase(i);
		}
		else
		{
			++i;
		}
	}
}

GM_Ticket* ObjectMgr::GetGMTicket(uint64 guid)
{
	for(std::list<GM_Ticket*>::iterator i = GM_TicketList.begin(); i != GM_TicketList.end(); i++)
	{
		if((*i)->guid == guid)
		{
			return (*i);
		}
	}
	return NULL;
}

void ObjectMgr::AddPvPArea(PvPArea* pvparea)
{
	ASSERT( pvparea );
	mPvPAreas[pvparea->AreaId] = pvparea;
}

PvPArea* ObjectMgr::GetPvPArea(uint32 AreaId)
{
	PvPAreaMap::const_iterator itr;
	for (itr = mPvPAreas.begin();itr != mPvPAreas.end(); itr++)
	{
		if( itr->second->AreaId == AreaId )
			return itr->second;
	}
	return NULL;
}

