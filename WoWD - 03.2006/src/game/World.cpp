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

//
// World.cpp
//

#include "Common.h"
#include "Database/DatabaseEnv.h"
#include "Config/ConfigEnv.h"
#include "Log.h"
#include "Opcodes.h"
#include "WorldSocket.h"
#include "WorldSession.h"
#include "WorldPacket.h"
#include "World.h"
#include "MapMgr.h"
#include "ObjectMgr.h"
#include "Player.h"
#include "Group.h"
#include "QuestMgr.h"
#include "UpdateData.h"
#include "Chat.h"
#include "Database/DBCStores.h"
#include "ChannelMgr.h"
#include "Quest.h"
#include "ExplorationMgr.h"
#include "EventMgr.h"
#include "LootMgr.h"
#include "TemplateMgr.h"
#include "WorldCreator.h"

initialiseSingleton( World );


World::World()
{
    m_playerLimit = 0;
	m_allowMovement = true;
    m_gmTicketSystem = true;

    reqGmClient = false;
    GmClientChannel = "";
}

World::~World()
{
    sLog.outString("Deleting ObjectMgr...");
    delete ObjectMgr::getSingletonPtr();
    sLog.outString("Deleted ObjectMgr");

    sLog.outString("Deleting ChannelMgr...");
    delete ChannelMgr::getSingletonPtr();
    sLog.outString("Deleted ChannelMgr");

    sLog.outString("Deleting QuestMgr...");
    delete QuestMgr::getSingletonPtr();
    sLog.outString("Deleted QuestMgr");

    sLog.outString("Deleting ExplorationMgr...");
    delete ExplorationMgr::getSingletonPtr();
    sLog.outString("Deleted ExplorationMgr");

	mPrices.clear();

	for( AreaTriggerMap::iterator i = m_AreaTrigger.begin( ); i != m_AreaTrigger.end( ); ++ i ) {
        delete i->second;
    }
    m_AreaTrigger.clear();
}


WorldSession* World::FindSession(uint32 id) const
{
    SessionMap::const_iterator itr = m_sessions.find(id);

    if(itr != m_sessions.end())
        return itr->second;
    else
        return 0;
}

void World::RemoveSession(uint32 id)
{
    SessionMap::iterator itr = m_sessions.find(id);

    if(itr != m_sessions.end())
	{
		delete itr->second;
		m_sessions.erase(itr);
	}
}

void World::AddSession(WorldSession* s)
{
    ASSERT(s);
    m_sessions[s->GetAccountId()] = s;
}


void World::SetInitialWorldSettings()
{
    // clear logfile
    if (sConfig.GetBoolDefault("LogWorld", false))
    {
        FILE *pFile = fopen("world.log", "w+");
        fclose(pFile);
    }

    reqGmClient = sConfig.GetBoolDefault("reqGmClient", false);
    if(!sConfig.GetString("GmClientChannel", &GmClientChannel))
    {
        GmClientChannel = "";
    }

    srand((unsigned int)time(NULL));

    m_lastTick = time(NULL);

    // TODO: clean this
    time_t tiempo;
    char hour[3];
    char minute[3];
    char second[3];
    struct tm *tmPtr;
    tiempo = time(NULL);
    tmPtr = localtime(&tiempo);
    strftime( hour, 3, "%H", tmPtr );
    strftime( minute, 3, "%M", tmPtr );
    strftime( second, 3, "%S", tmPtr );
    m_gameTime = (3600*atoi(hour))+(atoi(minute)*60)+(atoi(second)); // server starts at noon

    // TODO: clean this
    // fill in emotes table
    // it appears not every emote has an animation
	mPrices[1] = 10;
	mPrices[4] = 80;
	mPrices[6] = 150;
	mPrices[8] = 200;
	mPrices[10] = 300;
	mPrices[12] = 800;
	mPrices[14] = 900;
	mPrices[16] = 1800;
	mPrices[18] = 2200;
	mPrices[20] = 2300;
	mPrices[22] = 3600;
	mPrices[24] = 4200;
	mPrices[26] = 6700;
	mPrices[28] = 7200;
	mPrices[30] = 8000;
	mPrices[32] = 11000;
	mPrices[34] = 14000;
	mPrices[36] = 16000;
	mPrices[38] = 18000;
	mPrices[40] = 20000;
	mPrices[42] = 27000;
	mPrices[44] = 32000;
	mPrices[46] = 37000;
	mPrices[48] = 42000;
	mPrices[50] = 47000;
	mPrices[52] = 52000;
	mPrices[54] = 57000;
	mPrices[56] = 62000;
	mPrices[58] = 67000;
	mPrices[60] = 7200;

    sLog.outString("Loading DBC files...");

	new SkillStore("DBC/SkillLineAbility.dbc");
	new EmoteStore("DBC/EmotesText.dbc");
	new SpellStore("DBC/Spell.dbc");
	new RangeStore("DBC/SpellRange.dbc");
	new CastTimeStore("DBC/SpellCastTimes.dbc");
	new DurationStore("DBC/SpellDuration.dbc");
	new RadiusStore("DBC/SpellRadius.dbc");
	new TalentStore("DBC/Talent.dbc");
    new FactionTmpStore("DBC/FactionTemplate.dbc");
    new FactionStore("DBC/Faction.dbc");
	new EnchantStore("DBC/SpellItemEnchantment.dbc");
    new WorldMapAreaStore("DBC/WorldMapArea.dbc");
    new WorldMapOverlayStore("DBC/WorldMapOverlay.dbc");
    new AreaStore("DBC/AreaTable.dbc");
	new SkillLineStore("DBC/SkillLine.dbc");
	new RandomPropStore("DBC/ItemRandomProperties.dbc");

    sLog.outString("Initializing ObjectMgr...");
    new ObjectMgr;
    sLog.outString("Initializing ChannelMgr...");
	new ChannelMgr;
    sLog.outString("Initializing QuestMgr...");
    new QuestMgr;
    sLog.outString("Initializing ExplorationMgr...");
    new ExplorationMgr;
    sLog.outString("Initializing LootMgr...");
    new LootMgr;
    sLog.outString("Initializing EventMgr...");
    new EventMgr;

    // Load quests
    Log::getSingleton( ).outString( "Loading Quests..." );
    objmgr.LoadQuests();

    // Load items
    Log::getSingleton( ).outString( "Loading Items..." );
    objmgr.LoadItemPrototypes();
	objmgr.LoadAuctions();
	objmgr.LoadAuctionItems();
	objmgr.LoadMailedItems();

    // Load Player name queries
    Log::getSingleton( ).outString( "Loading PlayerNames..." );
    objmgr.LoadPlayerNames();

    // Load initial creaturenames
    Log::getSingleton( ).outString( "Loading CreatureNames..." );
    objmgr.LoadCreatureNames();

	Log::getSingleton( ).outString( "Loading GameObjectNames..." );
    objmgr.LoadGameObjectNames();

#ifndef DYNAMIC_LOADING
    // Load creatures
    Log::getSingleton( ).outString( "Loading Creatures..." );
    objmgr.LoadCreatures();

	// Load initial GameObjects
    Log::getSingleton( ).outString( "Loading Gameobjects..." );
    objmgr.LoadGameObjects();

    // Load Corpses
    Log::getSingleton( ).outString( "Loading Corpses..." );
    objmgr.LoadCorpses();
#endif

	// Load Creature Spawn Templates
	Log::getSingleton( ).outString( "Loading CreatureSpawnTemplates..." );
	objmgr.LoadCreatureSpawnTemplates();

    // Load player create info
    Log::getSingleton( ).outString( "Loading Environment..." );
    objmgr.LoadPlayerCreateInfo();

    // DK:Load guild
    Log::getSingleton( ).outString( "Loading Guilds..." );
    objmgr.LoadGuilds();
    objmgr.LoadCharters();

    // Load taxi info
    Log::getSingleton( ).outString( "Loading TaxiPaths..." );
    objmgr.LoadTaxiNodes();
    objmgr.LoadTaxiPath();
    objmgr.LoadTaxiPathNodes();

    // Load Gossip
    Log::getSingleton( ).outString( "Loading Gossip Text..." );
    objmgr.LoadGossipText();
    Log::getSingleton( ).outString( "Loading Gossip Npc..." );
    objmgr.LoadGossips();

    //Load graveyards
    Log::getSingleton( ).outString( "Loading Graveyards..." );
    objmgr.LoadGraveyards();
	Log::getSingleton( ).outString( "Loading Trainers..." );
	objmgr.LoadTrainerSpells();

	//Load Teleport Coords
	Log::getSingleton( ).outString( "Loading AreaTriggers..." );
	LoadAreaTriggerInformation();

	//Load PvP Areas
	Log::getSingleton( ).outString( "Loading PvPAreas..." );
    objmgr.LoadPvPAreas();

    //Load FactionTemplates
    Log::getSingleton( ).outString( "Loading Faction Templates..." );
    objmgr.LoadFaction();

    //Load GMTickets
    Log::getSingleton( ).outString( "Loading GM Tickets..." );
    objmgr.LoadGMTickets();

    //Set Highest GUIDs
    Log::getSingleton( ).outString( "Setting Highest GUIDs" );
    objmgr.SetHighestGuids();

	objmgr.LoadSpellSkills();
    
	// set timers
    /*
    m_timers[WUPDATE_OBJECTS].SetInterval(100);
    m_timers[WUPDATE_SESSIONS].SetInterval(100);
    m_timers[WUPDATE_AUCTIONS].SetInterval(1000);
    */

    // add initial events
    sEventMgr.AddEvent(this, &World::UpdateAuctions, EVENT_WORLD_UPDATEAUCTIONS, 1000, 0);
    sEventMgr.AddEvent(this, &World::UpdateSessions, (uint32)10, EVENT_WORLD_UPDATESESSIONS, 10, 0);	// 10ms updates

    sLog.outString("Creating World...");
    new WorldCreator;

#ifndef DYNAMIC_LOADING
    for(ObjectMgr::CreatureMap::const_iterator i = objmgr.Begin<Creature>();
        i != objmgr.End<Creature>(); i++)
    {
        i->second->PlaceOnMap();
    }

	for(ObjectMgr::GameObjectMap::const_iterator i = objmgr.Begin<GameObject>();
		i != objmgr.End<GameObject>(); i++)
	{
		i->second->PlaceOnMap();
	}

    for(ObjectMgr::CorpseMap::const_iterator i = objmgr.Begin<Corpse>();
        i != objmgr.End<Corpse>(); i++)
    {
        i->second->PlaceOnMap();
    }
#endif
    
    Log::getSingleton( ).outString( "WORLD: SetInitialWorldSettings done" );
}

void World::UpdateAuctions()
{
		ObjectMgr::AuctionEntryMap::iterator itr,next;
		for (itr = objmgr.GetAuctionsBegin(); itr != objmgr.GetAuctionsEnd();itr = next)
		{
			next = itr;
			next++;
			if (time(NULL) > (itr->second->time))
			{
				if (itr->second->bidder == 0)
				{
					Mail *m = new Mail;
					m->reciever = itr->second->owner;
					m->body = "";
					m->sender = itr->second->owner;
					m->checked = 0;
					m->COD = 0;
					m->messageID = objmgr.GenerateMailID();
					m->money = 0;
					m->time = time(NULL) + (29 * 3600);
					m->subject = "Your item failed to sell";
					m->item = itr->second->item;
					Item *it = objmgr.GetAItem(m->item);
					objmgr.AddMItem(it);

					std::stringstream ss;
					ss << "INSERT INTO mailed_items (guid, data) VALUES ("
						<< it->GetGUIDLow() << ", '"; // TODO: use full guids
					for(uint16 i = 0; i < it->GetValuesCount(); i++ )
					{
						ss << it->GetUInt32Value(i) << " ";
					}
					ss << "' )";
					sDatabase.Execute( ss.str().c_str() );

					std::stringstream md;
					md << "DELETE FROM mail WHERE mailID = " << m->messageID; // TODO: use full guids
					sDatabase.Execute( md.str().c_str( ) );

					std::stringstream mi;
					mi << "INSERT INTO mail (mailId,sender,reciever,subject,body,item,time,money,COD,checked) VALUES ( " <<
								m->messageID << ", " << m->sender << ", " << m->reciever << ",' " << m->subject.c_str() << "' ,' " <<
								m->body.c_str() << "', " << m->item << ", " << m->time << ", " << m->money << ", " << 0 << ", " << m->checked << " )";
					sDatabase.Execute( mi.str().c_str( ) );

					uint64 rcpl;
					GUID_LOPART(rcpl) = m->reciever;
					GUID_HIPART(rcpl) = 0;
					std::string pname;
					objmgr.GetPlayerNameByGUID(rcpl,pname);
					Player *rpl = objmgr.GetPlayer(pname.c_str());
					if (rpl)
					{
						rpl->AddMail(m);
					}
					std::stringstream delinvq;
					std::stringstream id;
					std::stringstream bd;
					delinvq << "DELETE FROM auctionhouse WHERE itemowner = " << m->reciever; // TODO: use full guids				
					sDatabase.Execute( delinvq.str().c_str( ) );

					id << "DELETE FROM auctioned_items WHERE guid = " << m->item; // TODO: use full guids				
					sDatabase.Execute( id.str().c_str( ) );

					bd << "DELETE FROM bids WHERE Id = " << itr->second->Id; // TODO: use full guids				
					sDatabase.Execute( bd.str().c_str( ) );

					objmgr.RemoveAuction(itr->second->Id);
				}
				else
				{
					Mail *m = new Mail;
					m->reciever = itr->second->owner;
					m->body = "";
					m->sender = itr->second->bidder;
					m->checked = 0;
					m->COD = 0;
					m->messageID = objmgr.GenerateMailID();
					m->money = itr->second->bid;
					m->time = time(NULL) + (29 * 3600);
					m->subject = "Your item sold!";
					m->item = 0;
					std::stringstream md;
					md << "DELETE FROM mail WHERE mailID = " << m->messageID; // TODO: use full guids
					sDatabase.Execute( md.str().c_str( ) );
					std::stringstream mi;
					mi << "INSERT INTO mail (mailId,sender,reciever,subject,body,item,time,money,COD,checked) VALUES ( " <<
								m->messageID << ", " << m->sender << ", " << m->reciever << ",' " << m->subject.c_str() << "' ,' " <<
								m->body.c_str() << "', " << m->item << ", " << m->time << ", " << m->money << ", " << 0 << ", " << m->checked << " )";
					sDatabase.Execute( mi.str().c_str( ) );
					uint64 rcpl;
					GUID_LOPART(rcpl) = m->reciever;
					GUID_HIPART(rcpl) = 0;
					std::string pname;
					objmgr.GetPlayerNameByGUID(rcpl,pname);
					Player *rpl = objmgr.GetPlayer(pname.c_str());
					if (rpl)
					{
						rpl->AddMail(m);
					}

					Mail *mn = new Mail;
					mn->reciever = itr->second->bidder;
					mn->body = "";
					mn->sender = itr->second->owner;
					mn->checked = 0;
					mn->COD = 0;
					mn->messageID = objmgr.GenerateMailID();
					mn->money = 0;
					mn->time = time(NULL) + (29 * 3600);
					mn->subject = "Your won an item!";
					mn->item = itr->second->item;
					Item *it = objmgr.GetAItem(itr->second->item);
					objmgr.AddMItem(it);

					std::stringstream ss;
					ss << "INSERT INTO mailed_items (guid, data) VALUES ("
						<< it->GetGUIDLow() << ", '"; // TODO: use full guids
					for(uint16 i = 0; i < it->GetValuesCount(); i++ )
					{
						ss << it->GetUInt32Value(i) << " ";
					}
					ss << "' )";
					sDatabase.Execute( ss.str().c_str() );

					std::stringstream mdn;
					mdn << "DELETE FROM mail WHERE mailID = " << mn->messageID; // TODO: use full guids
					sDatabase.Execute( mdn.str().c_str( ) );
					std::stringstream min;
					min << "INSERT INTO mail (mailId,sender,reciever,subject,body,item,time,money,COD,checked) VALUES ( " <<
								mn->messageID << ", " << mn->sender << ", " << mn->reciever << ",' " << mn->subject.c_str() << "' ,' " <<
								mn->body.c_str() << "', " << mn->item << ", " << mn->time << ", " << mn->money << ", " << 0 << ", " << mn->checked << " )";
					sDatabase.Execute( min.str().c_str( ) );
					uint64 rcpl1;
					GUID_LOPART(rcpl1) = mn->reciever;
					GUID_HIPART(rcpl1) = 0;
					std::string pname1;
					objmgr.GetPlayerNameByGUID(rcpl1,pname1);
					Player *rpl1 = objmgr.GetPlayer(pname1.c_str());
					if (rpl1)
					{
						rpl1->AddMail(mn);
					}
					objmgr.RemoveAItem(itr->second->item);
					objmgr.RemoveAuction(itr->second->Id);
				}
			}
		}
}
void World::Update(time_t diff)
{
    sEventMgr.Update(diff);
    _UpdateGameTime();
}


void World::SendGlobalMessage(WorldPacket *packet, WorldSession *self)
{
    SessionMap::iterator itr;
    for (itr = m_sessions.begin(); itr != m_sessions.end(); itr++)
    {
        if (itr->second->GetPlayer() &&
            itr->second->GetPlayer()->IsInWorld()
            && itr->second != self)  // dont send to self!
        {
            itr->second->SendPacket(packet);
        }
    }
}


void World::SendWorldText(const char* text, WorldSession *self)
{
    WorldPacket data;
    sChatHandler.FillSystemMessageData(&data, 0, text);
    SendGlobalMessage(&data, self);
}

void World::AddGlobalObject(Object *obj)
{
    ObjectSet::iterator itr = m_globalObjects.find(obj);
    
    //ASSERT(itr == m_globalObjects.end());
    if (itr == m_globalObjects.end())
        m_globalObjects.insert(obj);
}
void World::RemoveGlobalObject(Object *obj)
{
    ObjectSet::iterator itr = m_globalObjects.find(obj);
    
    //ASSERT(itr != m_globalObjects.end());
    if (itr != m_globalObjects.end())
        m_globalObjects.erase(obj);
}

void World::UpdateSessions(uint32 diff)
{
    SessionMap::iterator itr, next;
    for (itr = m_sessions.begin(); itr != m_sessions.end(); itr = next)
    {
        next = itr;
        next++;

        if(!itr->second->Update(diff))
        {
            delete itr->second;
            m_sessions.erase(itr);
        }
    }
}

