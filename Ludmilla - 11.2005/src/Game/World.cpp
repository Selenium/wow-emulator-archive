#include "StdAfx.h"

#include "../Shared/FactionTemplates.h"

//
// World.cpp
//

initialiseSingleton( World );

//-----------------------------------------------------------------------------
World::World()
{
    m_playerLimit = 0;
}

//-----------------------------------------------------------------------------
World::~World()
{
	mPrices.clear();
}

//-----------------------------------------------------------------------------
WorldSession* World::FindSession(uint32 id)
{
	ZThread::Guard<ZThread::Mutex> guard(m_sessions_lock);

    SessionMap::const_iterator itr = m_sessions.find(id);

    if(itr != m_sessions.end())
        return itr->second;
    else
        return NULL;
}

//-----------------------------------------------------------------------------
/*WorldSession* World::FindSession(char *login_)
{
	char login[256];
	strcpy (login, login_);
	strlwr (login);

	SessionNameMap::const_iterator itr = m_namedSessions.find (login);

	if(itr != m_namedSessions.end())
		return itr->second;
	else
		return NULL;
}*/

//-----------------------------------------------------------------------------
void World::AddSession(WorldSession* s)
{
	ZThread::Guard<ZThread::Mutex> guard(m_sessions_lock);

    ASSERT(s);
    m_sessions[s->GetAccountId()] = s;
	
	/*char name[256];
	strcpy (name, s->GetPlayer()->GetName());
	strlwr (name);
	m_sessionsByName[name] = s;*/
}

//-----------------------------------------------------------------------------
void World::SetInitialWorldSettings()
{
    // clear logfile
    if (sConfig.GetBoolDefault ("WorldServLogFile", false))
    {
        FILE *pFile = fopen("world.log", "w+");
        fclose(pFile);
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

	new ChannelMgr;

	initMT();	// init random generator
	initFactionTemplates();

	// Load creature templates
	// DO NOT CHANGE order of loading, they depend each on another
	//
	Log::getSingleton( ).outString( "SERVER::  << Yeah its loading time! ----" );
	Log::getSingleton( ).outString( "");
	Log::getSingleton( ).outString ("SERVER:: Opening DBC storages...");
	Log::getSingleton( ).outString( "------------------- DBC --------------------------");
	Log::getSingleton( ).outString( ">> SkillLineAbility.dbc");
	new SkillStore("dbc/SkillLineAbility.dbc");
	Log::getSingleton( ).outString( ">> EmotesText.dbc");
	new EmoteStore("dbc/EmotesText.dbc");
	Log::getSingleton( ).outString( ">> Spell.dbc");
	new SpellStore("dbc/Spell.dbc");
	Log::getSingleton( ).outString( ">> SpellRange.dbc");
	new RangeStore("dbc/SpellRange.dbc");
	Log::getSingleton( ).outString( ">> SpellCastTimes.dbc");
	new CastTimeStore("dbc/SpellCastTimes.dbc");
	Log::getSingleton( ).outString( ">> SpellDuration.dbc");
	new DurationStore("dbc/SpellDuration.dbc");
	Log::getSingleton( ).outString( ">> SpellRadius.dbc");
	new RadiusStore("dbc/SpellRadius.dbc");
	Log::getSingleton( ).outString( ">> Talent.dbc");
	new TalentStore("dbc/Talent.dbc");
	Log::getSingleton( ).outString( ">> AreaTable.dbc");
	new AreaTableStore("dbc/AreaTable.dbc");
	Log::getSingleton( ).outString( ">> WorldMapArea.dbc");
	new WorldMapAreaStore ("dbc/WorldMapArea.dbc");
	objmgr.LoadWorldMapArea();
	Log::getSingleton( ).outString( ">> WorldMapOverlay.dbc");
	new WorldMapOverlayStore("dbc/WorldMapOverlay.dbc");
	Log::getSingleton( ).outString( ">> ItemRandomProperties.dbc");
	new ItemRandomPropertiesStore("dbc/ItemRandomProperties.dbc");
	Log::getSingleton( ).outString( ">> SpellItemEnchantment.dbc");
	new SpellItemEnchantmentStore("dbc/SpellItemEnchantment.dbc");
	Log::getSingleton( ).outString( ">> Faction.dbc");
	new FactionStore("dbc/Faction.dbc");
	Log::getSingleton( ).outString( "--------------------------------------------------");
	Log::getSingleton( ).outString( "SERVER:: DBC storages: Done!" );
	Log::getSingleton( ).outString( "");
	Log::getSingleton( ).outString( "SERVER:: Precaching MySQL DB tables..." );
	Log::getSingleton( ).outString( "-------------------  Items -----------------------");
	objmgr.LoadItemPrototypes();
	Log::getSingleton( ).outString( "");
	Log::getSingleton( ).outString( "-------------------  Creatures -------------------");
	objmgr.LoadCreatureTemplates();
	objmgr.LoadTrainerSpells();
	objmgr.LoadSellTemplates();
	objmgr.LoadWorldLoots();
	objmgr.LoadLootTemplates();
	objmgr.LoadStaticLootTemplates();
	Log::getSingleton( ).outString( "");
	Log::getSingleton( ).outString( "-------------------  Gameobjects -----------------");
	objmgr.LoadGameobjectTemplates();
	objmgr.LoadGOLootTemplates();
	Log::getSingleton( ).outString( "--------------------------------------------------");
	Log::getSingleton( ).outString( "SERVER:: MySQL DB tables: Done!" );
	Log::getSingleton( ).outString( "");

	// Load items
	//
	Log::getSingleton( ).outString( "SERVER:: Precaching ITEM Instances..." );
	objmgr.LoadAuctions();
	objmgr.LoadAuctionItems();
	objmgr.LoadMailedItems();

	// Load quests
	Log::getSingleton( ).outString( "SERVER:: Precaching Quests..." );
	objmgr.LoadQuests();

	// Load world spawns
	Log::getSingleton( ).outString( "SERVER:: Precaching World..." );
	objmgr.LoadWorldSpawns();
	objmgr.LoadGameobjects();

	// Load Corpses
    Log::getSingleton( ).outString( "SERVER:: Loading Corpses..." );
    objmgr.LoadCorpses();

	// Load Gossip
    Log::getSingleton( ).outString( "SERVER:: Precaching NPC Texts..." );
    objmgr.LoadGossipText();

	// Load Pages
    Log::getSingleton( ).outString( "SERVER:: Precaching Item Pages..." );
    objmgr.LoadItemPageText();


	// Load player create info
	//Log::getSingleton( ).outString( "SERVER:: Precaching Environment..." );
	//objmgr.LoadPlayerCreateInfo();

    // Load graveyards
    Log::getSingleton( ).outString( "SERVER:: Precaching Graveyards..." );
    objmgr.LoadGraveyards();

    // Load area triggers
    Log::getSingleton( ).outString( "SERVER:: Precaching Quest Area points" );
	objmgr.LoadAreaTriggerPoints();

	// Load taxi info
	Log::getSingleton( ).outString( "SERVER:: Precaching Taxi..." );
	objmgr.LoadTaxiNodes();
	objmgr.LoadTaxiPath();
	objmgr.LoadTaxiPathNodes();

	Log::getSingleton( ).outString( "SERVER:: Analysing Spells for Trainers..." );
	objmgr.LoadTrainerTeachSpells();

    objmgr.SetHighestGuids();
	Log::getSingleton( ).outString ("SERVER::  ---- Finished >>");
	Log::getSingleton( ).outString ("");

	// set timers
    m_timers[WUPDATE_OBJECTS].SetInterval (400);
    m_timers[WUPDATE_SESSIONS].SetInterval (250);
	m_timers[WUPDATE_AUCTIONS].SetInterval (3000);

	//-----------------------------------------------------------------
	Log::getSingleton( ).outString ("Populating world with stuff...");

	std::list<Creature *> crlist;
	for (ObjectMgr::CreatureMap::const_iterator i = objmgr.Begin<Creature>(); i != objmgr.End<Creature>(); i++)
    {
		crlist.push_back (i->second);
	}

	uint32 progressPos = 0;
	for (std::list<Creature *>::const_iterator cr = crlist.begin(); cr != crlist.end(); cr++)
	//for (ObjectMgr::CreatureMap::const_iterator i = objmgr.Begin<Creature>(); i != objmgr.End<Creature>(); i++)
	{
        (*cr)->PlaceOnMap();
		//i->second->PlaceOnMap();
		progressPos++;
		ProgressBarShow (progressPos, crlist.size(), "Placing Creatures");
		//ProgressBarShow (progressPos, objmgr.GetCreaturesCount(), "Placing Creatures");
    }
	ProgressBarHide();

	// Place Corpses
	Log::getSingleton( ).outString( "WORLD: Placing player corpses" );
    for (ObjectMgr::CorpseMap::const_iterator i = objmgr.Begin<Corpse>(); i != objmgr.End<Corpse>(); i++)
        i->second->PlaceOnMap();

	// Place Gameobjects
	Log::getSingleton( ).outString( "WORLD: Placing gameobjects" );
	for (ObjectMgr::GameObjectMap::const_iterator i = objmgr.Begin<GameObject>(); i != objmgr.End<GameObject>(); i++)
		i->second->PlaceOnMap();

    Log::getSingleton( ).outString( "WORLD: SetInitialWorldSettings done" );
}

/*bool g_needScriptRestart = false;
extern void RestartScripting();*/

//-----------------------------------------------------------------------------
void World::Update(time_t diff)
{
    for(int i = 0; i < WUPDATE_COUNT; i++)
        m_timers[i].Update(diff);

    _UpdateGameTime();

	// TODO: make sure that all objects get their updates, not just characters and creatures
    if (m_timers[WUPDATE_OBJECTS].Passed())
    {
        m_timers[WUPDATE_OBJECTS].Reset();

		//
		//
		ObjectMgr::PlayerMap::iterator chriter;
        for( chriter = objmgr.Begin<Player>(); chriter != objmgr.End<Player>( ); ++ chriter )
            chriter->second->Update( (uint32)diff );

		// Update creatures and gameobjects in active map cells
		//
		MapMgr	*mapm;
		for (int mapid = 0; mapid <= 1; mapid++) 
		{
			mapm = sWorld.GetMap (mapid);
			if (mapm->HasActiveObjects()) 
				mapm->UpdateActiveObjects ((uint32)diff);
		}

		// Update gameobjects
		// COMMENTED: Should work together with update active maps
		//
		/*
		ObjectMgr::GameObjectMap::iterator giter;
		for( giter = objmgr.Begin<GameObject>(); giter != objmgr.End<GameObject>( ); ++ giter )
            giter->second->Update( (uint32)diff );

		objmgr.WipeRecycles();
		*/

		// Update dynamic objects (spell visual effects)
		//
		ObjectMgr::DynamicObjectMap::iterator diter;
        for( diter = objmgr.Begin<DynamicObject>(); diter != objmgr.End<DynamicObject>( ); ++ diter )
            diter->second->Update( (uint32)diff );
    }


	if (m_timers[WUPDATE_SESSIONS].Passed())
	{
		m_timers[WUPDATE_SESSIONS].Reset();

		SessionMap::iterator itr, next;
		for (itr = m_sessions.begin(); itr != m_sessions.end(); itr = next)
		{
			next = itr;
			next++;

			if(!itr->second->Update((uint32)diff))
			{
				/*SessionNamedMap::iterator itr2;
				itr2 = m_namedSessions.find (itr->second->GetAccountId());
				if (itr2 != m_namedSessions.end())
					m_namedSessions.erase (itr2);
				*/

				{
					ZThread::Guard<ZThread::Mutex> guard(m_sessions_lock);
					delete itr->second;
					m_sessions.erase(itr);
				}
			}
		}
	}


	if (m_timers[WUPDATE_AUCTIONS].Passed())
	{
		m_timers[WUPDATE_AUCTIONS].Reset();
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
					mi << "INSERT INTO mail (mailId,sender,reciever,subject,body,item,"
						"time,money,COD,checked) VALUES ( " << m->messageID << ", "
						<< m->sender << ", " << m->reciever << ",' " << m->subject.c_str()
						<< "' ,' " << m->body.c_str() << "', " << m->item << ", "
						<< (uint32)m->time << ", " << m->money << ", " << 0 << ", "
						<< m->checked << " )";
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
					mi << "INSERT INTO mail (mailId,sender,reciever,subject,body,item,"
						"time,money,COD,checked) VALUES ( " << m->messageID << ", " << m->sender
						<< ", " << m->reciever << ",' " << m->subject.c_str() << "' ,' "
						<< m->body.c_str() << "', " << m->item << ", " << (uint32)m->time
						<< ", " << m->money << ", " << 0 << ", " << m->checked << " )";
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

					min << "INSERT INTO mail (mailId,sender,reciever,subject,body,"
						"item,time,money,COD,checked) VALUES ( "
						<< mn->messageID << ", " << mn->sender << ", " << mn->reciever
						<< ",' " << mn->subject.c_str() << "' ,' " << mn->body.c_str()
						<< "', " << mn->item << ", " << (uint32)mn->time << ", "
						<< mn->money << ", " << 0 << ", " << mn->checked << " )";

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

	for (MapMgrMap::iterator iter = m_maps.begin(); iter != m_maps.end(); iter++)
	{
		iter->second->Update(diff);
	}

	// When everything safe, wipe recycles
	objmgr.WipeRecycles();
}

//-----------------------------------------------------------------------------
void World::SendGlobalMessage(WorldPacket *packet, WorldSession *self)
{
	ZThread::Guard<ZThread::Mutex> guard(m_sessions_lock);

    SessionMap::iterator itr;
    for (itr = m_sessions.begin(); itr != m_sessions.end(); itr++)
    {
        if (itr->second->GetPlayer() &&
            itr->second->GetPlayer()->IsInWorld()
            && itr->second != self)  // dont send to self! (why not?)
        {
            itr->second->SendPacket(packet);
        }
    }
}

//-----------------------------------------------------------------------------
void World::SendWorldText(const char* text, WorldSession *self)
{
    WorldPacket data;
    sChatHandler.FillSystemMessageData(&data, 0, text);
    SendGlobalMessage(&data, self);
}

//-----------------------------------------------------------------------------
MapMgr* World::GetMap(uint32 id)
{
    MapMgrMap::iterator iter = m_maps.find(id);
    if (iter != m_maps.end())
        return iter->second;

    MapMgr *newMap = new MapMgr(id);
    ASSERT(newMap);

    m_maps[id] = newMap;

    return newMap;
}

//--- END ---