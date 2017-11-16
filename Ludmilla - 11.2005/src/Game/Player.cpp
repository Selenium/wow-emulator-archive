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

#include "UpdateFields.h"
#include "../Shared/PacketBuilder.h"
#include "../Shared/Database/DBCStores.h"

// Interval between game checks players powers and regenerates them
#define PLAYER_POWER_REGEN_TIMER	2000

// Interval between game checks mobs around player and aggroes them
#define CHECK_AGGRO_MOBS_INTERVAL	500


//-----------------------------------------------------------------------------
Player::Player ( ): Unit()
{
    m_objectType |= TYPE_PLAYER;
    m_objectTypeId = TYPEID_PLAYER;

    m_valuesCount = PLAYER_END;

    m_session = 0;

    m_afk = 0;
    //m_curTarget = 0;
    m_curSelection = 0;
    m_lootGuid = 0;
    m_guildId = 0;
    m_petInfoId = 0;
    m_petLevel = 0;
    m_petFamilyId = 0;

    m_regenTimer = PLAYER_POWER_REGEN_TIMER;
	m_checkAggroTimer = CHECK_AGGRO_MOBS_INTERVAL;
	m_lastCastTime = 0;

	m_PVP_timer = 0;
    m_dismountTimer = 0;
    m_dismountCost = 0;
    m_mount_pos_x = 0;
    m_mount_pos_y = 0;
    m_mount_pos_z = 0;

    m_currentSpell = NULL;
	m_resurrectGUID = NULL;
	m_resurrectX = m_resurrectY = m_resurrectZ = NULL;
    m_resurrectHealth = m_resurrectMana = NULL;

    memset(m_items, 0, sizeof(Item *) * BANK_SLOT_BAG_END);

    m_groupLeader = 0;
    m_isInGroup = false;
    m_isInvited = false;

	m_falldetect_time = 0;
	m_falldetect_speed = 0;

	m_vendorBuybackSlot = NULL;

	SetPreviousGossipMenu( NULL, 0 );
	m_autoGossipTimer = 0;

	m_timedQuest = 0;

	for ( int aX = 0 ; aX < 8 ; aX++ )
		m_Tutorials[ aX ] = 0x00;

    _GossipMenu = new NPCGossipMenu();
	_QuestMenu  = new NPCQuestMenu();

	m_lastCombatError = 0;	// to slow down combat errors
}

//-----------------------------------------------------------------------------
Player::~Player ( )
{
    ASSERT(!IsInWorld());

    for(int i = 0; i < BANK_SLOT_BAG_END; i++)
    {
        if(m_items[i])	delete m_items[i];
    }

	CleanupChannels();

    delete _GossipMenu;
	delete _QuestMenu;
}

///====================================================================
///  Create
///  params: p_newChar
///  desc:   data from client to create a new character
//====================================================================
void Player::Create( uint32 guidlow, WorldPacket& data )
{
    int i;
    uint8 race,class_,gender,skin,face,hairStyle,hairColor,facialHair,outfitId;
    uint32 baseattacktime[2];

    Object::_Create(guidlow, HIGHGUID_PLAYER);

	for (i = 0; i < BANK_SLOT_BAG_END; i++) {
        m_items[i] = NULL;
	}

	// Read character name and make it capitalized as on official
	string name;
	data >> name;

	char name1[128];
	strncpy (name1, name.c_str(), sizeof (name1)-1);
	name1[sizeof(name1)-1] = '\x00';
	strlwr (name1);
	name1[0] = toupper (name1[0]);
	m_name = name1;

	// unpack data into member variables
    data >> race >> class_ >> gender >> skin >> face;
    data >> hairStyle >> hairColor >> facialHair >> outfitId;

    //////////  Constant for everyone  ////////////////
    // Starting Locs
    // Human(1): 0, -8949.95, -132.493, 83.5312
    // Orc(2): 1, -618.518, -4251.67, 38.718
    // Dwarf(3): 0, -6240.32, 331.033, 382.758
    // Night Elf(4): 1, 10311.3, 832.463, 1326.41
    // Undead(5): 0, 1676.35, 1677.45, 121.67
    // Tauren(6): 1, -2917.58, -257.98, 52.9968
    // Gnome(7): See Dwarf
    // Troll(8): See Orc

    // LEFT SIDE
    // Head        0
    // Neck        1
    // Shoulders   2
    // Back        14
    // Chest       4
    // Shirt       3
    // Tabard      18
    // Wrists      8

    // RIGHT SIDE
    // Hands       9
    // Waist       5
    // Legs        6
    // Feet        7
    // Finger A    10
    // Finger B    11
    // Trinket A   12
    // Trinket B   13

    // WIELDED
    // Main hand   15
    // Offhand     16
    // Ranged      17

    //PlayerCreateInfo *info = objmgr.GetPlayerCreateInfo(race, class_);
    //ASSERT(info);

    baseattacktime[0] = 2000;
    baseattacktime[1] = 2000;

	/*
	m_mapId = m_bindPointMap = info->mapId;
	m_positionX = m_bindPointX = info->positionX;
    m_positionY = m_bindPointY = info->positionY;
    m_positionZ = m_bindPointZ = info->positionZ;
	m_zoneId = m_bindPointArea = info->zoneId;
	*/

    memset(m_taximask, 0, sizeof(m_taximask));

    uint8 powertype = 0;
    switch(class_)
    {
    case CLASS_WARRIOR : powertype = 1; break; // Rage
    case CLASS_PALADIN : powertype = 0; break; // Mana
    case CLASS_HUNTER  : powertype = 0; break;
    case CLASS_ROGUE   : powertype = 3; break; // Energy
    case CLASS_PRIEST  : powertype = 0; break;
    case CLASS_SHAMAN  : powertype = 0; break;
    case CLASS_MAGE    : powertype = 0; break;
    case CLASS_WARLOCK : powertype = 0; break;
    case CLASS_DRUID   : powertype = 0; break;
    } // 2 = Focus (unused)

    // Set Starting stats for char
    SetFloatValue(OBJECT_FIELD_SCALE_X, 1.0f);
    SetUInt32Value(UNIT_FIELD_HEALTH, 0); //info->health);
    SetUInt32Value(UNIT_FIELD_POWER1, 0); //info->mana );
    SetUInt32Value(UNIT_FIELD_POWER2, 0 ); // this gets devided by 10
    SetUInt32Value(UNIT_FIELD_POWER3, 0); //info->focus );
    SetUInt32Value(UNIT_FIELD_POWER4, 0); //info->energy );
    //SetUInt32Value(UNIT_FIELD_POWER5, 0xEEEEEEEE );
    SetUInt32Value(UNIT_FIELD_MAXHEALTH, 0); //info->health);
    SetUInt32Value(UNIT_FIELD_MAXPOWER1, 0); //info->mana );
    SetUInt32Value(UNIT_FIELD_MAXPOWER2, 0); //info->rage );
    SetUInt32Value(UNIT_FIELD_MAXPOWER3, 0); //info->focus );
    SetUInt32Value(UNIT_FIELD_MAXPOWER4, 0); //info->energy );
    //SetUInt32Value(UNIT_FIELD_MAXPOWER5, 5 );
    //SetLevel (1);
	SetUInt32Value(UNIT_FIELD_LEVEL, 1);
    SetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE, 1 ); // Choose factions based on race
    SetUInt32Value(UNIT_FIELD_BYTES_0, ( ( race ) | ( class_ << 8 ) | ( gender << 16 ) | ( powertype << 24 ) ) );
    SetUInt32Value(UNIT_FIELD_BYTES_1, 0); // 0x0011EE00 ); // WTF ARE THESE VALUES ? I make them 0
    SetUInt32Value(UNIT_FIELD_BYTES_2, 0); // 0xEEEEEE00 );	// WTF ARE THESE VALUES ?
    SetUInt32Value(UNIT_FIELD_FLAGS , 0x00000008); // UNIT_FLAG_NON_PVP_PLAYER); //0x08 );
    SetUInt32Value(UNIT_FIELD_STAT0, 0); //info->strength );
    SetUInt32Value(UNIT_FIELD_STAT1, 0); //info->agility );
    SetUInt32Value(UNIT_FIELD_STAT2, 0); //info->stamina );
    SetUInt32Value(UNIT_FIELD_STAT3, 0); //info->intellect );
    SetUInt32Value(UNIT_FIELD_STAT4, 0); //info->spirit );
    SetUInt32Value(UNIT_FIELD_BASEATTACKTIME, 2500); //baseattacktime[0] );
    SetUInt32Value(UNIT_FIELD_BASEATTACKTIME+1, 2500); //baseattacktime[1]  );

	// Setting Ranged Attack Time
	if (GetClass() == CLASS_HUNTER || GetClass() == CLASS_ROGUE) SetUInt32Value(UNIT_FIELD_RANGEDATTACKTIME, 2200);

    SetFloatValue(UNIT_FIELD_BOUNDINGRADIUS, 0.372f );
    SetFloatValue(UNIT_FIELD_COMBATREACH, 1.5f   );
    SetUInt32Value(UNIT_FIELD_DISPLAYID, 53); //info->displayId + gender );
    SetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID, 53); //info->displayId + gender );
    SetMinDamage (0); //info->mindmg);
    SetMaxDamage (0); //info->maxdmg);
	SetAttackPower (0); //info->attackpower);
    SetUInt32Value(PLAYER_BYTES, ((skin) | (face << 8) | (hairStyle << 16) | (hairColor << 24)));
    SetUInt32Value(PLAYER_BYTES_2, (facialHair | (0xEE << 8) | (0x01 << 16) | (0x01 << 24)));
    SetUInt32Value(PLAYER_NEXT_LEVEL_XP, 400);
    SetUInt32Value(PLAYER_FIELD_BYTES, 0); // Crap 0xEEEE0000 ); WTF ARE THESE VALUES ? I make them 0

	SetUInt32Value(PLAYER__FIELD_COMBO_TARGET, 0xEEEEEEEEEEEEEEEE);
	SetUInt32Value(PLAYER_GUILD_TIMESTAMP, 0xEEEEEEEE);

	// HONOR INITIAL SETTINGS ///////////////////
    SetUInt32Value(PLAYER_FIELD_SESSION_KILLS, 0);
	SetUInt32Value(PLAYER_FIELD_YESTERDAY_KILLS, 0);
	SetUInt32Value(PLAYER_FIELD_LAST_WEEK_KILLS, 0);
	SetUInt32Value(PLAYER_FIELD_THIS_WEEK_KILLS, 0);
	SetUInt32Value(PLAYER_FIELD_THIS_WEEK_CONTRIBUTION, 0);
	SetUInt32Value(PLAYER_FIELD_LIFETIME_HONORBALE_KILLS, 0);
	SetUInt32Value(PLAYER_FIELD_LIFETIME_DISHONORBALE_KILLS, 0);
	SetUInt32Value(PLAYER_FIELD_YESTERDAY_CONTRIBUTION, 0);
	SetUInt32Value(PLAYER_FIELD_LAST_WEEK_CONTRIBUTION, 0);
	SetUInt32Value(PLAYER_FIELD_LAST_WEEK_RANK, 0);
	SetUInt32Value(PLAYER_FIELD_PVP_MEDALS, 0);
	//////////////////////////////////////////////

	// Reveal all world maps (temp fix before exploration starts working)
	//for (int i = 0; i < 64; i++)
	//	SetUInt32Value (PLAYER_EXPLORED_ZONES_1 + i, uint32(-1));

/*
    Item *item;
    for (i=0; i<10; i++)
    {
        if ( (info->item[i]!=0) && (info->item_slot[i]!=0) )
        {
            item = new Item();
            item->Create(objmgr.GenerateLowGuid(HIGHGUID_ITEM), info->item[i], this);
            AddItemToSlot(info->item_slot[i], item);
        }
    }

    for (i=0; i<10; i++)
    {
        if ( info->spell[i]!=0 )
        {
            AddSpell (info->spell[i], 0);
        }
    }
*/

	/*
	m_reputation[0] = 2;
	m_reputationValues[0] = (uint32)0 ; //1
	m_reputation[1] = 0;
	m_reputationValues[1] = (uint32)0 ; //2
	m_reputation[2] = 2;
	m_reputationValues[2] = (uint32)0 ; //3
	m_reputation[3] = 2;
	m_reputationValues[3] = (uint32)0 ; //4
	m_reputation[4] = 16;
	m_reputationValues[4] = (uint32)0 ; //5
	m_reputation[5] = 0;
	m_reputationValues[5] = (uint32)0 ; //6
	m_reputation[6] = 2;
	m_reputationValues[6] = (uint32)0 ; //7
	m_reputation[7] = 0;
	m_reputationValues[7] = (uint32)0 ; //8
	m_reputation[8] = 16;
	m_reputationValues[8] = (uint32)0 ; //9
	m_reputation[9] = 0;
	m_reputationValues[9] = (uint32)0 ; //10
	m_reputation[10] = 8;
	m_reputationValues[10] = (uint32)0 ; //11
	m_reputation[11] = 9;
	m_reputationValues[11] = (uint32)0 ; //12
	m_reputation[12] = 14;
	m_reputationValues[12] = (uint32)0 ; //13
	m_reputation[13] = 0;
	m_reputationValues[13] = (uint32)0 ; //14
	m_reputation[14] = 6;
	m_reputationValues[14] = (uint32)0 ; //15
	m_reputation[15] = 6;
	m_reputationValues[15] = (uint32)0 ; //16
	m_reputation[16] = 6;
	m_reputationValues[16] = (uint32)0 ; //17
	m_reputation[17] = 6;
	m_reputationValues[17] = (uint32)0 ; //18
	m_reputation[18] = 17;
	m_reputationValues[18] = (uint32)0 ; //19 Gnomereganverbannte
	m_reputation[19] = 17;
	m_reputationValues[19] = (uint32)330 ; //20	Stormwind
	m_reputation[20] = 17;
	m_reputationValues[20] = (uint32)0 ; //21 Ironforge
	m_reputation[21] = 17;
	m_reputationValues[21] = (uint32)0 ; //22 Darnassus
	m_reputation[22] = 4;
	m_reputationValues[22] = (uint32)0 ; //23
	m_reputation[23] = 4;
	m_reputationValues[23] = (uint32)0 ; //24
	m_reputation[24] = 4;
	m_reputationValues[24] = (uint32)0 ; //25
	m_reputation[25] = 4;
	m_reputationValues[25] = (uint32)0 ; //26
	m_reputation[26] = 4;
	m_reputationValues[26] = (uint32)0 ; //27
	m_reputation[27] = 0;
	m_reputationValues[27] = (uint32)0 ; //28
	m_reputation[28] = 0;
	m_reputationValues[28] = (uint32)0 ; //29
	m_reputation[29] = 4;
	m_reputationValues[29] = (uint32)0 ; //30
	m_reputation[30] = 4;
	m_reputationValues[30] = (uint32)0 ; //31
	m_reputation[31] = 4;
	m_reputationValues[31] = (uint32)0 ; //32
	m_reputation[32] = 4;
	m_reputationValues[32] = (uint32)0 ; //33
	m_reputation[33] = 4;
	m_reputationValues[33] = (uint32)0 ; //34
	m_reputation[34] = 4;
	m_reputationValues[34] = (uint32)0 ; //35
	m_reputation[35] = 2;
	m_reputationValues[35] = (uint32)0 ; //36
	m_reputation[36] = 0;
	m_reputationValues[36] = (uint32)0 ; //37
	m_reputation[37] = 0;
	m_reputationValues[37] = (uint32)0 ; //38
	m_reputation[38] = 2;
	m_reputationValues[38] = (uint32)0 ; //39
	m_reputation[39] = 20;
	m_reputationValues[39] = (uint32)0 ; //40
	m_reputation[40] = 16;
	m_reputationValues[40] = (uint32)0 ; //41
	m_reputation[41] = 2;
	m_reputationValues[41] = (uint32)0 ; //42
	m_reputation[42] = 0;
	m_reputationValues[42] = (uint32)0 ; //43
	m_reputation[43] = 16;
	m_reputationValues[43] = (uint32)0 ; //44
	m_reputation[44] = 16;
	m_reputationValues[44] = (uint32)0 ; //45
	m_reputation[45] = 16;
	m_reputationValues[45] = (uint32)0 ; //46
	m_reputation[46] = 6;
	m_reputationValues[46] = (uint32)0 ; //47
	m_reputation[47] = 24;
	m_reputationValues[47] = (uint32)0 ; //48
	m_reputation[48] = 14;
	m_reputationValues[48] = (uint32)0 ; //49
	m_reputation[49] = 6;
	m_reputationValues[49] = (uint32)0 ; //50
	m_reputation[50] = 0;
	m_reputationValues[50] = (uint32)0 ; //51
	m_reputation[51] = 0;
	m_reputationValues[51] = (uint32)0 ; //52
	m_reputation[52] = 0;
	m_reputationValues[52] = (uint32)0 ; //53
	m_reputation[53] = 0;
	m_reputationValues[53] = (uint32)0 ; //54
	m_reputation[54] = 0;
	m_reputationValues[54] = (uint32)0 ; //55
	m_reputation[55] = 0;
	m_reputationValues[55] = (uint32)0 ; //56
	m_reputation[56] = 0;
	m_reputationValues[56] = (uint32)0 ; //57
	m_reputation[57] = 0;
	m_reputationValues[57] = (uint32)0 ; //58
	m_reputation[58] = 0;
	m_reputationValues[58] = (uint32)0 ; //59
	m_reputation[59] = 0;
	m_reputationValues[59] = (uint32)0 ; //60
	m_reputation[60] = 0;
	m_reputationValues[60] = (uint32)0 ; //61
	m_reputation[61] = 0;
	m_reputationValues[61] = (uint32)0 ; //62
	m_reputation[62] = 0;
	m_reputationValues[62] = (uint32)0 ; //63
	m_reputation[63] = 0;
	m_reputationValues[63] = (uint32)0 ; //64
	*/

	// Call classes and races scripts
	//
	Call_PlayerStats_ByRace  (this, true);
	Call_PlayerStats_ByClass (this, true);

	// Recalculate level stats (even for level 1)
	_RecalculatePlayerStats();

	// Nullify RESTED XP
	SetRestStateXP((uint32)0);

	// do this after scripts calls
	m_zoneId = m_bindPointArea = objmgr.LookupZoneId (m_mapId, m_positionX, m_positionY);

    // Not worrying about this stuff for now
    m_guildId = 0;
    m_petInfoId = 0;
    m_petLevel = 0;
    m_petFamilyId = 0;
}

//-----------------------------------------------------------------------------
void Player::Update (int32 p_time)
{
    if(!IsInWorld())
        return;

    Unit::Update( p_time );

	uint32 now = (uint32)time (NULL);

	CheckExploreSystem();

	if (isDead() && now - m_autoGossipTimer > 15) {
		// Look for spirit healer close to player, and autoclick it
		//
		//ObjectSet::iterator itr;
		//for (itr = m_objectsInRange.begin(); itr != m_objectsInRange.end(); ++itr)
		Object *o;
		for (MapRangeIterator itr (this); o = itr.Advance(); )
		{
			if (o->isUnit()) 
			{
				Creature *cr = (Creature *)o;

				if (! cr->isSpiritHealer() || GetDistance2dSq (cr) > 4.0f * 4.0f) continue;
				m_autoGossipTimer = now;

				QuestScriptBackend::getSingleton().scriptCallGossipHello( this, cr );
				break;
			}
		}
	}

	// Check if we aggro mobs around
	//
	if (m_checkAggroTimer >= 0) 
	{
		if (p_time > m_checkAggroTimer)
			m_checkAggroTimer -= p_time;
		else
		{
			m_checkAggroTimer += CHECK_AGGRO_MOBS_INTERVAL;
			if (isAlive())
				CheckAggressiveMobsAround();
		}

		// Check if we have dead aggro (aggroed at dead creatures)
		//
		for (TargetMap::iterator aggr = m_targets.begin(); aggr != m_targets.end(); aggr++)
		{
			Unit * u = aggr->first;
			// Removing one dead aggro per turn is quite ok, so we break loop
			// after we modified structure, that we were looping over.
			if (u->isDead()) {
				RemoveHate_NR (u);
				break;
			}
		}
	}

	// Quest Timer !
	quest_status QS;

	Quest *pQuest;


	if ( m_timedQuest > 0 )
	{
		QS     = getQuestStatusStruct( m_timedQuest );
		pQuest = objmgr.GetQuest( m_timedQuest );

		if (pQuest)
			if ( !pQuest->HasBehavior( QUEST_BEHAVIOR_TIMED) ) pQuest = NULL;

		if (pQuest)
		{
			if ( QS.m_timer <= p_time)
			{
				QuestPacketHandler::getSingleton().SendQuestIncompleteToLog( GetSession(), pQuest );
				QuestPacketHandler::getSingleton().SendQuestUpdateFailedTimer( GetSession(), pQuest );
				sChatHandler.GMMessage( GetSession(), "GM: Timer failed !" );

				QS.status = QUEST_STATUS_INCOMPLETE;
				m_timedQuest = 0;
				QS.m_timer = 0;
				QS.m_timerrel = 0;
				loadExistingQuest(QS);
			} else	
			{
				QS.m_timer -= p_time;
				
				sChatHandler.GMMessage( GetSession(), "GM: Timer update : {%d}sec. left from {%d}sec.", (QS.m_timer / 1000), (pQuest->m_timeMinutes * 60));
				loadExistingQuest(QS);
			}
		}
	}


	// ----------------
	//////////////PVP timer///////////////// MasterM
	if (p_time < m_PVP_timer) 
		m_PVP_timer -= p_time;
	else if(m_PVP_timer > 0)
	{
		if(HasFlag(UNIT_FIELD_FLAGS, UNIT_FLAG_WAR_PLAYER))
			RemoveFlag(UNIT_FIELD_FLAGS, UNIT_FLAG_WAR_PLAYER);
		m_PVP_timer = 0;
	}
	//////////////PVP changes end/////////////

	//--------------------------------------------------
	// Regeneration timers and last cast time check
	// TODO: Add talents here allowing partial regen always
	//--------------------------------------------------
	if (m_regenTimer > p_time)
		m_regenTimer -= p_time;
	else
	{
		m_regenTimer += PLAYER_POWER_REGEN_TIMER;

		// only regenerate if NOT in combat, and if alive
		if (isAlive())
		{
			// Regenerate health, mana and energy if necessary.
			Regenerate();

			/*Regenerate (UNIT_FIELD_HEALTH, UNIT_FIELD_MAXHEALTH, true);
			Regenerate (UNIT_FIELD_POWER1, UNIT_FIELD_MAXPOWER1, true);
			Regenerate (UNIT_FIELD_POWER2, UNIT_FIELD_MAXPOWER2, false);
			Regenerate (UNIT_FIELD_POWER4, UNIT_FIELD_MAXPOWER4, true);*/
		}
	}

	if (m_state & UF_ATTACKING)
	{
		// In combat!
		if (isAttackReady())
		{
			Unit *pVictim = NULL;

			pVictim = objmgr.GetObject<Creature>(m_curSelection);
			if (!pVictim)
				pVictim = objmgr.GetObject<Player>(m_curSelection);

			if (!pVictim)
			{
				Log::getSingleton( ).outDetail("Player::Update:  No valid current selection to attack, stopping attack\n");
				clearStateFlag (UF_ATTACKING);
				smsg_AttackStop (m_curSelection);
			}
			else
			{
				bool  reachable = CanReachWithAttack (pVictim);
				float attackRadius = min (GetFloatValue(UNIT_FIELD_COMBATREACH), 1.0f) +
					min (GetFloatValue(UNIT_FIELD_BOUNDINGRADIUS), 0.5f);
				int	combatError = 0;

				if (reachable) 
				{
					if (isInFront(pVictim, attackRadius))
					{
						AttackerStateUpdate (pVictim, 0, false);
						setAttackTimer();
					} else
					{
						combatError = SMSG_ATTACKSWING_BADFACING;
					}
				} else
				{
					combatError = SMSG_ATTACKSWING_NOTINRANGE;
				}

				if (combatError != 0)
				{
					// Slow down combat error messages to 1 / 2sec
					PreciseTime pt_now = GetPreciseTime();
					if (pt_now - m_lastCombatError >= PTSECONDS(2))
					{
						WorldPacket data;
						data.Initialize (combatError);
						m_session->SendPacket(&data);
						m_lastCombatError = pt_now;
					}
				}
			}
		}
	}

    // Dead System
    if (m_deathState == JUST_DIED)
    {
        KillPlayer();
    }

    // Auto-Dismount after Taxiride
    if(m_dismountTimer > 0)
    {
        if(p_time >= m_dismountTimer)
        {
            m_dismountTimer = 0;

            SetUInt32Value( PLAYER_FIELD_COINAGE , m_dismountCost);
            m_dismountCost = 0;

            SetPosition( m_mount_pos_x,
						m_mount_pos_y,
						m_mount_pos_z, true );

            SetUInt32Value(UNIT_FIELD_MOUNTDISPLAYID , 0);
            RemoveFlag( UNIT_FIELD_FLAGS ,0x000004 );
            RemoveFlag( UNIT_FIELD_FLAGS, 0x002000 );

            SetPlayerSpeed(RUN,7.5f,false);
           
        }
        else
            m_dismountTimer -= p_time;
    }
}

//-----------------------------------------------------------------------------
/// Regenerates the regenField's curValue to the maxValue
/// Right now, everything regenerates at the same rate
/// A possible mod is to add another parameter, the stat regeneration is based off of (Intelligence for mana, Strength for HP)
/// And build a regen rate based on that
//void Player::Regenerate(uint16 field_cur, uint16 field_max, bool switch_)

// Kosuha:
// 
// MANA REGENERATION FORMULAS:
// http://www.wowwiki.com/Formulas:Mana_Regen
// Mage =		Spirit/4 + 11
// Priest =		Spirit/4 + 13 
// Warlock =	Spirit/4 + 8 
// Druid =		Spirit/5 + 15 
// Shaman =		Spirit/5 + 17 
// Hunter =		Spirit/4 + 11 
// Paladin =	Spirit/4 + 8 
//
// HEALTH REGENERATION FORMULAS:
// http://www.wowwiki.com/Formulas:Health_Regen
// Mage =		Spirit * 0.10 
// Priest =		Spirit * 0.10 
// Warlock =	Spirit * 0.11 
// Druid =		Unknown 
// Shaman =		Spirit * 0.11
// Rogue =		Spirit * 0.50 
// Warrior =	Spirit * 0.80 
// Hunter =		Spirit * 0.25 
// Paladin =	Spirit * 0.25

void Player::Regenerate()
{
	int32	t, maxt;
	float	regen_rate;
	uint32	cls = GetClass();
	
	regen_rate = 1.0f;	// Just incase we need to modify the rate of Health / Mana regeneration
						// If changing 1.10 = +10% an etc...

	if (! isInCombat() )
		switch (GetStandState())
		{
			case STANDSTATE_SIT_CHAIR:
			case STANDSTATE_SIT_LOW_CHAIR:
			case STANDSTATE_SIT_MEDIUM_CHAIR:
			case STANDSTATE_SIT_HIGH_CHAIR:
			case STANDSTATE_SIT:			regen_rate = 2.0f; break;

			case STANDSTATE_SLEEP:			regen_rate = 3.0f; break;

			case STANDSTATE_KNEEL:			regen_rate = 1.5f; break;
		}

	t = GetHealth();
	maxt = GetMaxHealth();
	//if ((t < maxt) && isInCombat()) t += maxt * 0.01f;
	if ((t < maxt) && (isInCombat() == false))
	{
		/*
		if (cls == CLASS_MAGE)		t += (GetSpirit() * 0.10f + 2.0f) * regen_rate; // Added 2.0 constant, otervise seems too low ?
		if (cls == CLASS_PRIEST)	t += (GetSpirit() * 0.10f + 2.0f) * regen_rate;
		if (cls == CLASS_WARLOCK)	t += (GetSpirit() * 0.11f + 2.0f) * regen_rate;
		if (cls == CLASS_DRUID)		t += (GetSpirit() * 0.11f + 2.0f) * regen_rate;
		if (cls == CLASS_SHAMAN)	t += (GetSpirit() * 0.11f + 2.0f) * regen_rate;
		if (cls == CLASS_ROGUE)		t += (GetSpirit() * 0.50f) * regen_rate;
		if (cls == CLASS_WARRIOR)	t += (GetSpirit() * 0.80f) * regen_rate;
		if (cls == CLASS_HUNTER)	t += (GetSpirit() * 0.25f) * regen_rate;
		if (cls == CLASS_PALADIN)	t += (GetSpirit() * 0.25f) * regen_rate;
		*/
		// HEALTH REGEN FORMULAS ARE WRONG, VERY WRONG
		t += int32 ((GetSpirit() / 10.0f + 7.0f) * regen_rate);
		if (t > maxt) t = maxt;
		SetHealth (t);
	}

	// MANA regeneration
	// Even in combat! But always continues after 5 second delay
	PreciseTime pt_now = GetPreciseTime();
	if ((cls != CLASS_ROGUE || cls != CLASS_WARRIOR) &&
		pt_now - m_lastCastTime > PTSECONDS(5))
	{
		t = GetMana();
		maxt = GetMaxMana();
		if (t < maxt)
		{
			/*
			if (cls == CLASS_MAGE)		t += (GetSpirit() / 4.0f + 11.0f) * regen_rate;
			if (cls == CLASS_PRIEST)	t += (GetSpirit() / 4.0f + 13.0f) * regen_rate;
			if (cls == CLASS_WARLOCK)	t += (GetSpirit() / 4.0f +  8.0f) * regen_rate;
			if (cls == CLASS_DRUID)		t += (GetSpirit() / 5.0f + 15.0f) * regen_rate;
			if (cls == CLASS_SHAMAN)	t += (GetSpirit() / 5.0f + 17.0f) * regen_rate;
			if (cls == CLASS_HUNTER)	t += (GetSpirit() / 4.0f + 11.0f) * regen_rate;
			if (cls == CLASS_MAGE)		t += (GetSpirit() / 4.0f +  8.0f) * regen_rate;
			*/
			// MANA REGEN FORMULAS ARE WRONG, VERY WRONG
			t += int32 ((GetSpirit() / 10.0f + 7.0f) * regen_rate);

			if (t > maxt) t = maxt;
			SetMana (t);
		}
	}

	// RAGE degradation
	if (GetPowerIndex() == POWER_TYPE_RAGE && isInCombat() == false)
	{
		t = GetRage();
		//maxt = GetMaxRage();
		if (t > 0) {
			t -= 17; // -1.6667 rage every 2 sec
			// maxt * 0.02f;	// -2 rage every 2 sec
			if (t < 0) t = 0;
			SetRage (t);
		}
	}

	// ENERGY regeneration
	if (GetPowerIndex() == POWER_TYPE_ENERGY)
	{
		t = GetEnergy();
		maxt = GetMaxEnergy();
		if (t < maxt) {
			t += maxt / 5;
			if (t > maxt) t = maxt;
			SetEnergy (t);
		}
	}
}

//-----------------------------------------------------------------------------
void Player::BuildEnumData( WorldPacket * p_data )
{
    *p_data << GetGUID();
    *p_data << m_name;

    uint32 bytes = GetUInt32Value(UNIT_FIELD_BYTES_0);
    *p_data << uint8(bytes & 0xff); // race
    *p_data << uint8((bytes >> 8) & 0xff); // class
    *p_data << uint8((bytes >> 16) & 0xff); // gender

    bytes = GetUInt32Value(PLAYER_BYTES);
    *p_data << uint8(bytes & 0xff); //skin
    *p_data << uint8((bytes >> 8) & 0xff); //face
    *p_data << uint8((bytes >> 16) & 0xff); //hairstyle
    *p_data << uint8((bytes >> 24) & 0xff); //haircolor

    bytes = GetUInt32Value(PLAYER_BYTES_2);
    *p_data << uint8(bytes & 0xff); //facialhair

    *p_data << uint8(GetLevel()); //level

    *p_data << GetZoneId();
    *p_data << GetMapId();

    *p_data << m_positionX;
    *p_data << m_positionY;
    *p_data << m_positionZ;

    *p_data << (uint32)0;				// guild
    *p_data << (uint32)0;				// unknown
	*p_data << (uint8)m_isRested;		// rest state

    *p_data << (uint32)m_petInfoId;		// pet info id
    *p_data << (uint32)m_petLevel;		// pet level
    *p_data << (uint32)m_petFamilyId;	// pet family id


    for (int i = 0; i < 20; i++)
    {
        if (m_items[i] != NULL)
        {
            *p_data << (uint32)m_items[i]->GetProto()->DisplayInfoID;
            *p_data << (uint8)m_items[i]->GetProto()->InventoryType;
        }
        else
        {
            *p_data << (uint32)0;
            *p_data << (uint8)0;
        }
    }

    //    assert( p_data->getLength() <= 176 );
}



/////////////////////////////////// QUESTS ////////////////////////////////////////////
void Player::finishExplorationQuest( Quest *pQuest )
{
	if ( getQuestStatus( pQuest->m_questId ) == QUEST_STATUS_INCOMPLETE )
	{
		quest_status qs = getQuestStatusStruct( pQuest->m_questId );

		if ( !qs.m_explored )
		{
			QuestPacketHandler::getSingleton().SendQuestUpdateComplete( GetSession(), pQuest );
			qs.m_explored = true;
			loadExistingQuest( qs );
		}

		if ( checkQuestStatus( pQuest->m_questId ) )
		{
			setQuestStatus( pQuest->m_questId, QUEST_STATUS_COMPLETE, false );
			QuestPacketHandler::getSingleton().SendQuestCompleteToLog( GetSession(), pQuest );
		}
	}
}

bool Player::isQuestComplete(uint32 quest_id, Creature *pCreature)
{
	Quest *pQuest = objmgr.GetQuest( quest_id );
	if (!pQuest) return false;

	if ( getQuestStatus( pQuest->m_questId ) == QUEST_STATUS_INCOMPLETE )
	{

		if ( pQuest->HasBehavior( QUEST_BEHAVIOR_SPEAKTO | QUEST_BEHAVIOR_DELIVER ) )
		{
			if ( pCreature->hasInvolvedQuest( pQuest->m_questId ) && 
				 HasItemInBackpack( pQuest->m_srcItem ) )
				return true; else
				return false;
		}

		if ( pQuest->HasBehavior( QUEST_BEHAVIOR_SPEAKTO ) )
		{
			if ( pCreature->hasInvolvedQuest( pQuest->m_questId ) )
				return true; else
				return false;
		}

		return false;
	}

	if ( getQuestStatus( pQuest->m_questId ) == QUEST_STATUS_COMPLETE )
	{
		return true;
	}

	return false;
}

bool Player::isQuestTakable(uint32 quest_id)
{
	Quest *pQuest = objmgr.GetQuest(quest_id);
	if (!pQuest) return false;

	uint32 status = getQuestStatus(quest_id);


	if ( pQuest->QuestIsTakable( this ) )
	{
		if ( status == QUEST_STATUS_NONE )
		{
			status = addNewQuest( quest_id );
		}

		if (status == QUEST_STATUS_AVAILABLE)
		{
			return true;
		}
	}

	return false;
}

quest_status Player::getQuestStatusStruct(uint32 quest_id)
{
    return mQuestStatus[quest_id];
}

uint32 Player::getQuestStatus(uint32 quest_id)
{
    if  ( mQuestStatus.find( quest_id ) == mQuestStatus.end( ) ) return QUEST_STATUS_NONE;
    return mQuestStatus[quest_id].status;
}

bool Player::getQuestRewardStatus(uint32 quest_id)
{
	if  ( mQuestStatus.find( quest_id ) == mQuestStatus.end( ) ) return false;
    return mQuestStatus[quest_id].rewarded;
}

//-----------------------------------------------------------------------------
uint32 Player::addNewQuest(uint32 quest_id, uint32 status)
{
    quest_status qs;
    qs.quest_id = quest_id;
    qs.status   = status;
	qs.rewarded = false;

    mQuestStatus[quest_id] = qs;
    return status;
};


//-----------------------------------------------------------------------------
void Player::loadExistingQuest(quest_status qs)
{
    mQuestStatus[qs.quest_id] = qs;
}

//-----------------------------------------------------------------------------
void Player::setQuestStatus(uint32 quest_id, uint32 new_status, bool new_rewarded)
{
	if ( new_status == QUEST_STATUS_AVAILABLE || new_status == QUEST_STATUS_INCOMPLETE )
	{
		m_timedQuest = 0;

		mQuestStatus[quest_id].m_questMobCount[0] = 0;
		mQuestStatus[quest_id].m_questMobCount[1] = 0;
		mQuestStatus[quest_id].m_questMobCount[2] = 0;
		mQuestStatus[quest_id].m_questMobCount[3] = 0;

		if ( new_status == QUEST_STATUS_INCOMPLETE )
		{
			Quest *pQuest = objmgr.GetQuest(quest_id);
			if (pQuest)
				if (pQuest->HasBehavior(QUEST_BEHAVIOR_TIMED))
				{
					// starting countdown !
					time_t kk = time(NULL);
					kk += pQuest->m_timeMinutes * 60;

					mQuestStatus[quest_id].m_timerrel = (int32)kk;
					mQuestStatus[quest_id].m_timer = pQuest->m_timeMinutes * 60 * 1000; // miliseconds

					m_timedQuest = quest_id;

					sChatHandler.GMMessage( GetSession(), "Timed Quest : {%d}", m_timedQuest);

					QuestPacketHandler::getSingleton().SendQuestUpdateSetTimer( GetSession(), pQuest, pQuest->m_timeMinutes );
				}
		}
	}
	

    mQuestStatus[quest_id].status     = new_status;
	mQuestStatus[quest_id].rewarded   = new_rewarded;
	mQuestStatus[quest_id].m_explored = false;
}

void Player::sendPreparedGossip( uint32 textid, QEmote em, uint64 guid )
{
	if ( _GossipMenu->m_ItemsNr == 0 )
	{
		if ( _QuestMenu->m_QuestsNr == 1 )
		{
			Quest *pQuest = objmgr.GetQuest( _QuestMenu->m_Items[0].iQuest );
			if (pQuest)
			{
				if ( _QuestMenu->m_Items[0].iIcon == DIALOG_STATUS_REWARD )
					QuestPacketHandler::getSingleton().SendRewardToPlayer( GetSession(), pQuest, guid );

				if ( _QuestMenu->m_Items[0].iIcon == DIALOG_STATUS_AVAILABLE )
					QuestPacketHandler::getSingleton().SendShortQuestDetailsToPlayer( GetSession(), pQuest, guid );

				if ( _QuestMenu->m_Items[0].iIcon == DIALOG_STATUS_INCOMPLETE )
				{
					Creature *pNPC = objmgr.GetObject<Creature>( guid );
					if ( isQuestComplete( pQuest->m_questId, pNPC ) )
						QuestPacketHandler::getSingleton().SendRewardToPlayer( GetSession(), pQuest, guid); else
						QuestPacketHandler::getSingleton().SendRequestItemsToPlayer( GetSession(), pQuest, guid, false);
				}
			}

			return;
		}

		if  (_QuestMenu->m_QuestsNr > 0 )
			QuestPacketHandler::getSingleton().SendQuestMenu( GetSession(), _QuestMenu, em, guid ); else
		    QuestPacketHandler::getSingleton().SendGossipMenu( GetSession(), _GossipMenu, NULL, textid, guid);

		return;
	}

	QuestPacketHandler::getSingleton().SendGossipMenu( GetSession(), _GossipMenu, _QuestMenu, textid, guid);
}

//-----------------------------------------------------------------------------
uint16 Player::getOpenQuestSlot()
{
    uint16 start = PLAYER_QUEST_LOG_1_1;
    uint16 end = PLAYER_QUEST_LOG_1_1 + 60;
    for (uint16 i = start; i <= end; i+=3)
        if (GetUInt32Value(i) == 0)
            return i;

    return 0;
}

//-----------------------------------------------------------------------------
uint16 Player::getQuestSlot(uint32 quest_id)
{
    uint16 start = PLAYER_QUEST_LOG_1_1;
    uint16 end = PLAYER_QUEST_LOG_1_1 + 60;
    for (uint16 i = start; i <= end; i+=3)
        if (GetUInt32Value(i) == quest_id)
            return i;

    return 0;
}

//-----------------------------------------------------------------------------
uint16 Player::getQuestSlotById(uint32 slot_id)
{
    uint16 start = PLAYER_QUEST_LOG_1_1;
    uint16 end   = PLAYER_QUEST_LOG_1_1 + 60;
	uint16 idx   = 0;

    for (uint16 i = start; i <= end; i+=3)
	{ 
		idx++; 
		if ( idx == slot_id )
			return i;
	}

    return 0;
}

//-----------------------------------------------------------------------------
void Player::KilledMonster(uint32 entry, uint64 guid)
{

    for( StatusMap::iterator i = mQuestStatus.begin( ); i != mQuestStatus.end( ); ++ i )
    {
        if (i->second.status == QUEST_STATUS_INCOMPLETE)
        {
            Quest *pQuest = objmgr.GetQuest(i->first);

			if (!pQuest) continue;

            for (int j = 0; j < 4; j++)
            {
                if (pQuest->m_questMobId[j] == entry)
                {
                    if (i->second.m_questMobCount[j] < pQuest->m_questMobCount[j])
                    {
                        i->second.m_questMobCount[j]++ ;

                        // Send Update quest update kills message
						QuestPacketHandler::getSingleton().
							  SendQuestUpdateAddKill( GetSession(), 
							                          pQuest, 
													  guid, 
													  i->second.m_questMobCount[j],
													  j
													 );
                    }

                    if (i->second.m_questMobCount[j] == pQuest->m_questMobCount[j])
					{
						QuestPacketHandler::getSingleton().SendQuestUpdateComplete( GetSession(), pQuest );
					}

					if (checkQuestStatus(i->second.quest_id) && (i->second.status == QUEST_STATUS_INCOMPLETE))
					{
						QuestPacketHandler::getSingleton().SendQuestCompleteToLog( GetSession(), pQuest );
						i->second.status = QUEST_STATUS_COMPLETE;
					}

					SaveToDB();
                    return;
                } // end if mobId == entry
            } // end for each mobId
        } // end if status == 3
    } // end for each quest
}

void Player::AddedItemToBackpack(uint32 entry, uint32 count)
{
    for( StatusMap::iterator i = mQuestStatus.begin( ); i != mQuestStatus.end( ); ++ i )
    {
        if (i->second.status == QUEST_STATUS_INCOMPLETE)
        {
            Quest *pQuest = objmgr.GetQuest(i->first);
            for (int j = 0; j < 4; j++)
            {
                if (pQuest->m_questItemId[j] == entry)
                {
					if ( !HasItemInBackpack( pQuest->m_questItemId[j], pQuest->m_questItemCount[j] ) )
                    {

						QuestPacketHandler::getSingleton().
							SendQuestUpdateAddItem( GetSession(), 
									                pQuest, 
													j, 
													count													
												   );

					}

					if ( HasItemInBackpack( pQuest->m_questItemId[j], pQuest->m_questItemCount[j] ) )
					{
						QuestPacketHandler::getSingleton().SendQuestUpdateComplete( GetSession(), pQuest );
					}

					if ( checkQuestStatus(i->second.quest_id) )
					{
						QuestPacketHandler::getSingleton().SendQuestCompleteToLog( GetSession(), pQuest );
						i->second.status = QUEST_STATUS_COMPLETE;
					}


					SaveToDB();
                    return;
                } // end if itemId == entry
            } // end for each itemId
        } // end if status == 3
    } // end for each quest
}

void Player::RemovedItemToBackpack(uint32 entry)
{
    for( StatusMap::iterator i = mQuestStatus.begin( ); i != mQuestStatus.end( ); ++ i )
    {
        if (i->second.status == QUEST_STATUS_COMPLETE)
        {
            Quest *pQuest = objmgr.GetQuest(i->first);
            for (int j = 0; j < 4; j++)
            {
                if (pQuest->m_questItemId[j] == entry)
                {
					if ( !HasItemInBackpack( pQuest->m_questItemId[j], pQuest->m_questItemCount[j] ) )
                    {
						i->second.status = QUEST_STATUS_INCOMPLETE;
					}

					SaveToDB();
                    return;
                } // end if itemId == entry
            } // end for each itemId
        } // end if status == 3
    } // end for each quest
}

//======================================================
///  Check the quest finishing status by a set of
///  rules made by the quest. In future there will
///  be more !
//======================================================
bool Player::checkQuestStatus(uint32 quest_id)
{
    quest_status qs = mQuestStatus[quest_id];
    Quest *pQuest = objmgr.GetQuest(quest_id);

	bool Result = true;

	if (pQuest->HasBehavior(QUEST_BEHAVIOR_REPUTATION))
	{
		if ( pQuest->m_repFaction[0] )
		{
			FactionEntry *pFact = sFactionStore.LookupEntry( pQuest->m_repFaction[0] );

			if (!pFact)
				return true;

			if ( HasReputationForFaction( pFact->Faction_Id ) )
			{
				if ( GetReputationForFaction( pFact->Faction_Id ) >= pQuest->m_repValue[0] )
				{
					Result &= true;
				} else Result &= false;
			} else Result &= false;
		} else Result &= true;
	}

	if (pQuest->HasBehavior( QUEST_BEHAVIOR_SPEAKTO))
		Result &= false;

	if (pQuest->HasBehavior(QUEST_BEHAVIOR_EXPLORE))
		Result &= qs.m_explored;

	if (pQuest->HasBehavior(QUEST_BEHAVIOR_TIMED))
		Result &= (qs.m_timer > 0);

	if (pQuest->HasBehavior(QUEST_BEHAVIOR_DELIVER))
		if (HasItemInBackpack( pQuest->m_questItemId[0], pQuest->m_questItemCount[0]) &&
			HasItemInBackpack( pQuest->m_questItemId[1], pQuest->m_questItemCount[1]) &&
			HasItemInBackpack( pQuest->m_questItemId[2], pQuest->m_questItemCount[2]) &&
			HasItemInBackpack( pQuest->m_questItemId[3], pQuest->m_questItemCount[3]))
				Result &= true; else
				Result &= false;

	if (pQuest->HasBehavior(QUEST_BEHAVIOR_KILL))
		if (qs.m_questMobCount[0] >= pQuest->m_questMobCount[0] &&
			qs.m_questMobCount[1] >= pQuest->m_questMobCount[1] &&
			qs.m_questMobCount[2] >= pQuest->m_questMobCount[2] &&
			qs.m_questMobCount[3] >= pQuest->m_questMobCount[3]) 
			Result &= true; else 
			Result &= false;

    return Result;
}

//-----------------------------------------------------------------------------
///  This function sends the message displaying the purple XP gain for the char
///  It assumes you will send out an UpdateObject packet at a later time.
void Player::GiveXP(uint32 xp, uint64 guid)
{
    if (xp == 0)
        return;

    WorldPacket data;
    if (guid != 0)
    {
        /*
		Send out purple XP gain message, but ONLY if a valid GUID was passed in
        This message appear to be only for gaining XP from a death
		
		0:04:07 - SERVER >>> OpCode=0x1D0 SMSG_LOG_XPGAIN, size=25

			0- 1- 2- 3- 4- 5- 6- 7- | 8- 9- A- B- C- D- E- F- | 01234567 89ABCDEF
		0000: 00#17#D0#01 0B 90 08 00 | 00 10 00 F0 32 00 00 00 | ........ ....2...
		0010: 00 32 00 00 00 00 00 80 | 3F                      | .2...... ? 
		*/

        data.Initialize( SMSG_LOG_XPGAIN );
        data << guid;
        data << uint32(xp) << uint8(0);
        data << uint16(xp) << uint8(0);
        data << uint8(0);
		data << uint8(0);
		data << uint8(0);
		data << uint8(0x80);
		data << uint8(0x3f);

		// !!! SMSG_LOG_XPGAIN - has different Packet Data if XP is gained from Exploration for instance.
		//                       Now it shows message in combat log - You loose -xxx experience.

        GetSession()->SendPacket(&data);
    }

    uint32 curXP = GetPlayerXP();
    uint32 nextLvlXP = GetNextLevelXP();
    uint32 newXP = curXP + xp;

    // Check for level-up
    if (newXP >= nextLvlXP)
    {
        uint32	oldHealth = GetMaxHealth(),
				oldMana = GetMaxMana();

        // Level-Up!
        newXP = newXP - nextLvlXP;  // reset XP to 0, but add extra from this xp add
        nextLvlXP += nextLvlXP / 2;   // set the new next level xp

        uint8 newLevel = (uint8)GetLevel();    // increment the level
		if (newLevel < 60) newLevel++;

        /*
		healthGain = GetStamina() / 2;
        newHealth = GetMaxHealth() + healthGain;

        if (GetMana() > 0)
        {
            manaGain = GetSpirit() / 2;
            newMana = GetMaxMana() + manaGain;
        }
		*/

        // TODO: UNEQUIP everything and remove affects

		SetPlayerXP (newXP);
        SetNextLevelXP (nextLvlXP);

        SetLevel (newLevel);

		uint32	healthGain = GetMaxHealth() - oldHealth,
				manaGain = GetMaxMana() - oldMana;

		SetMana (GetMaxMana());
		SetHealth (GetMaxHealth());

		// TODO: REEQUIP everything and add effects

        data.Initialize (SMSG_LEVELUP_INFO);

        data << uint32(newLevel);
        data << uint32(healthGain);     // health gain
        data << uint32(manaGain);       // mana gain
        data << uint32(0);
        data << uint32(0);
        data << uint32(0);

        // 6 new fields
        data << uint32(0);
        data << uint32(0);
        data << uint32(0);
        data << uint32(0);
        data << uint32(0);
        data << uint32(0);

        WPAssert(data.size() == 48);
        GetSession()->SendPacket(&data);
    }

    // Set the update bit
	SetPlayerXP (newXP);
	
	// TODO Later: Rest State and Rest XP
	//SetRestStateXP (50);	// if rested
}

//-----------------------------------------------------------------------------
void Player::SendInitialSpells()
{
    WorldPacket data;
    uint16 spellCount = m_spells.size();

    data.Initialize( SMSG_INITIAL_SPELLS );
    data << uint8(1); // not 0. i've got 1 in 171
    data << uint16(spellCount); // spell count

    //std::list<struct spells>::iterator itr;
	SpellMap::iterator itr;
    for (itr = m_spells.begin(); itr != m_spells.end(); ++itr)
    {
        data << uint16(itr->first); // spell id
		//data << uint16(itr->second > 0? itr->second: 0xEEEE); // slot
		data << uint16(itr->second); // wtf? 0 is valid value
    }
    data << uint16(0);

    WPAssert(data.size() == 5+(4*spellCount));

    GetSession()->SendPacket(&data);

    Log::getSingleton( ).outDetail( "CHARACTER: Sent Initial Spells" );
}

//-----------------------------------------------------------------------------
bidentry* Player::GetBid(uint32 id)
{
	std::list<bidentry*>::iterator itr;
    for (itr = m_bids.begin(); itr != m_bids.end();)
    {
		if ((*itr)->AuctionID == id)
		{
			return (*itr);
		}
		else
		{
			++itr;
		}
	}
	return NULL;

}

//-----------------------------------------------------------------------------
void Player::AddBid(bidentry *be)
{
	std::list<bidentry*>::iterator itr;
    for (itr = m_bids.begin(); itr != m_bids.end();)
    {
		if ((*itr)->AuctionID == be->AuctionID)
		{
			//std::list<bidentry*>::iterator iold = itr++;
			//bidentry* b = *iold;
			m_bids.erase(itr++);
			//delete b;
		}
		else
		{
			++itr;
		}
	}
	m_bids.push_back(be);

}

//-----------------------------------------------------------------------------
void Player::RemoveMail(uint32 id)
{
	std::list<Mail*>::iterator itr;
    for (itr = m_mail.begin(); itr != m_mail.end();)
    {
		if ((*itr)->messageID == id)
		{
			m_mail.erase(itr++);
		}
		else
		{
			++itr;
		}
	}
}

//-----------------------------------------------------------------------------
void Player::AddMail(Mail *m)
{
	std::list<Mail*>::iterator itr;
    for (itr = m_mail.begin(); itr != m_mail.end();)
    {
		if ((*itr)->messageID == m->messageID)
		{
			m_mail.erase(itr++);
		}
		else
		{
			++itr;
		}
	}
	m_mail.push_back(m);
}

//-----------------------------------------------------------------------------
void Player::_SaveAuctions()
{
		std::stringstream delinvq, del;
		delinvq << "DELETE FROM auctionhouse WHERE itemowner = " << GetGUIDLow(); // TODO: use full guids				
		sDatabase.Execute( delinvq.str().c_str( ) );
		ObjectMgr::AuctionEntryMap::iterator itr;
		for (itr = objmgr.GetAuctionsBegin();itr != objmgr.GetAuctionsEnd();itr++)
		{
			AuctionEntry *Aentry = itr->second;
			if ((Aentry) && (Aentry->owner == GetGUIDLow()))
			{
				Item *it = objmgr.GetAItem(Aentry->item);
				del<< "DELETE FROM auctioned_items WHERE guid = " << it->GetGUIDLow(); // TODO: use full guids
				sDatabase.Execute( del.str().c_str( ) );			
				
				std::stringstream invq;
				
				invq <<  "INSERT INTO auctionhouse (auctioneerguid, itemguid, "
					"itemowner, buyoutprice,time,buyguid,lastbid,Id) VALUES ( "
					<< Aentry->auctioneer << ", " << Aentry->item << ", " 
					<< Aentry->owner << ", " << Aentry->buyout << ", " 
					<< (uint32)Aentry->time << ", " << Aentry->bidder << ", " 
					<< Aentry->bid << ", " << Aentry->Id << " )";

				sDatabase.Execute( invq.str().c_str( ) );

				std::stringstream ss;
				
				ss << "INSERT INTO auctioned_items (guid, data) VALUES ("
					<< it->GetGUIDLow() << ", '"; // TODO: use full guids
				
				for(uint16 i = 0; i < it->GetValuesCount(); i++ )
				{
					ss << it->GetUInt32Value(i) << " ";
				}
				
				ss << "' )";
				sDatabase.Execute( ss.str().c_str() );
			}
		}
}

//-----------------------------------------------------------------------------
void Player::_SaveMail()
{
    std::stringstream delinvq;
    delinvq << "DELETE FROM mail WHERE reciever = " << GetGUIDLow(); // TODO: use full guids
    sDatabase.Execute( delinvq.str().c_str( ) );

	std::list<Mail*>::iterator itr;
    for (itr = m_mail.begin(); itr != m_mail.end(); itr++)
    {
		Mail *m = (*itr);
		std::stringstream invq;
        invq <<  "INSERT INTO mail (mailId,sender,reciever,subject,body,item,time,"
			"money,COD,checked) VALUES ( " << m->messageID << ", " << m->sender << ", "
			<< m->reciever << ", '" << m->subject.c_str() << "', '" << m->body.c_str()
			<< "', " << m->item << ", " << (uint32)m->time << ", " << m->money << ", "
			<< m->COD << ", " << m->checked << " )";

		sDatabase.Execute( invq.str().c_str( ) );
	}
}

//-----------------------------------------------------------------------------
void Player::_SaveBids()
{
    std::stringstream delinvq;
    delinvq << "DELETE FROM bids WHERE bidder = " << GetGUIDLow(); // TODO: use full guids
    sDatabase.Execute( delinvq.str().c_str( ) );
	std::list<bidentry*>::iterator itr;
    for (itr = m_bids.begin(); itr != m_bids.end(); itr++)
    {
		AuctionEntry *a = objmgr.GetAuction((*itr)->AuctionID);
		if (a)
		{
		    std::stringstream invq;
            invq <<  "INSERT INTO bids (bidder, Id, amt) VALUES ( " <<
                GetGUIDLow() << ", " << (*itr)->AuctionID << ", " << (*itr)->amt << " )";

			sDatabase.Execute( invq.str().c_str( ) );
		}
	}

}

//-----------------------------------------------------------------------------
void Player::_LoadMail()
{
    // Clear spell list
    m_mail.clear();

    // Mail
    std::stringstream query;
    query << "SELECT * FROM mail WHERE reciever=" << GetGUIDLow();

    QueryResult *result = sDatabase.Query( query.str().c_str() );
    if(result)
    {
        do
        {
            Field *fields = result->Fetch();
			Mail *be = new Mail;
			be->messageID = fields[0].GetUInt32();
			be->sender = fields[1].GetUInt32();
			be->reciever = fields[2].GetUInt32();
			be->subject = fields[3].GetString();
			be->body = fields[4].GetString();
			be->item = fields[5].GetUInt32();
			be->time = fields[6].GetUInt32();
			be->money = fields[7].GetUInt32();
			be->COD = fields[8].GetUInt32();
			be->checked = fields[9].GetUInt32();
			m_mail.push_back(be);
        }
        while( result->NextRow() );

        delete result;
    }

}

//-----------------------------------------------------------------------------
void Player::_LoadBids()
{
    // Clear spell list
    m_bids.clear();

    // Spells
    std::stringstream query;
    query << "SELECT Id,amt FROM bids WHERE bidder=" << GetGUIDLow();

    QueryResult *result = sDatabase.Query( query.str().c_str() );
    if(result)
    {
        do
        {
            Field *fields = result->Fetch();
			bidentry *be = new bidentry;
			be->AuctionID = fields[0].GetUInt32();
			be->amt = fields[1].GetUInt32();
			m_bids.push_back(be);
        }
        while( result->NextRow() );

        delete result;
    }

}

//-----------------------------------------------------------------------------
bool Player::AddSpell (uint32 spell_id, uint16 slot_id)
{
    /*struct spells newspell;
    newspell.spellId = spell_id;

	std::list<struct spells>::iterator itr;
	for (itr = m_spells.begin(); itr != m_spells.end(); ++itr) {
		if (itr->spellId == spell_id) {
		*/
	if (HasSpell (spell_id)) {
		Log::getSingleton( ).outDetail( "PLAYER: %s can't learn spell %d - already known", this->GetName(), spell_id );
		return false;
	}
	
	// Not sure why we need special slot id for all spells
    if (slot_id == 0xffff)
    {
        uint16 maxid = 0;
		for (SpellMap::iterator itr = m_spells.begin(); itr != m_spells.end(); ++itr) {
            if (itr->second > maxid) maxid = itr->second;
        }

        slot_id = maxid + 1;
    }

    //newspell.slotId = slot_id;
    //m_spells.push_back(newspell);
	
	m_spells[spell_id] = slot_id;
	return true;
}

//-----------------------------------------------------------------------------
bool Player::RemoveSpell (uint32 spell_id)
{
	if (! HasSpell (spell_id)) return false;

	m_spells.erase (spell_id);
	return true;

	/*
	std::list<struct spells>::iterator itr;
	for (itr = m_spells.begin(); itr != m_spells.end(); ++itr) {
		if (itr->spellId == spell_id) {
			m_spells.erase (itr);
			return 1;
		}
	}
	return 0;
	*/
}

//-----------------------------------------------------------------------------
bool Player::AddSkill (uint32 skill_id, uint16 skillLevel, uint16 maxSkill)
{
	/*if (HasSkill (skill_id)) {
		Log::getSingleton( ).outDetail( "PLAYER: %s can't learn skill %d - already known", this->GetName(), skill_id );
		return false;
	}*/

	// For default value maxSkill = -1 calculate correct maxSkill for every skill
	if (maxSkill == 0xFFFF)
	{
		maxSkill = 300;
		if (skill_id == SKILL_CLOTH || skill_id == SKILL_LEATHER ||
			skill_id == SKILL_MAIL || skill_id == SKILL_PLATE_MAIL ||
			skill_id == SKILL_SHIELD)
		{
			maxSkill = 1;
		}
	}

	m_skills[skill_id] = uint16(skillLevel) | uint32(maxSkill << 16);

	int16 slot = 0;
	for (SkillMap::iterator iter = m_skills.begin(); iter != m_skills.end(); iter++)
	{
		SetUInt32Value (PLAYER_SKILL_INFO_1_1 + slot*3, iter->first);
		SetUInt32Value (PLAYER_SKILL_INFO_1_1 + slot*3 + 1, iter->second);
		//SetUInt32Value (PLAYER_SKILL_INFO_1_1 + slot*3 + 2, 0)	;
		slot++;
	}

	for (; slot < 128; slot++)
	{
		SetUInt32Value (PLAYER_SKILL_INFO_1_1 + slot*3, 0);
		SetUInt32Value (PLAYER_SKILL_INFO_1_1 + slot*3 + 1, 0);
		//SetUInt32Value (PLAYER_SKILL_INFO_1_1 + slot*3 + 2, 0);
	}

	return true;
}

//-----------------------------------------------------------------------------
bool Player::RemoveSkill (uint32 skill_id)
{
	if (! HasSkill (skill_id)) return false;

	m_skills.erase (skill_id);

	int16 slot = 0;
	for (SkillMap::iterator iter = m_skills.begin(); iter != m_skills.end(); iter++)
	{
		SetUInt32Value (PLAYER_SKILL_INFO_1_1 + slot*3, iter->first);
		SetUInt32Value (PLAYER_SKILL_INFO_1_1 + slot*3 + 1, iter->second);
		//SetUInt32Value (PLAYER_SKILL_INFO_1_1 + slot*3 + 2, 0);
		slot++;
	}

	for (; slot < 128; slot++)
	{
		SetUInt32Value (PLAYER_SKILL_INFO_1_1 + slot*3, 0);
		SetUInt32Value (PLAYER_SKILL_INFO_1_1 + slot*3 + 1, 0);
		//SetUInt32Value (PLAYER_SKILL_INFO_1_1 + slot*3 + 2, 0);
	}

	return true;
}

//-----------------------------------------------------------------------------
Mail* Player::GetMail(uint32 id)
{
	std::list<Mail*>::iterator itr;
    for (itr = m_mail.begin(); itr != m_mail.end(); itr++)
    {
		if ((*itr)->messageID == id)
		{
			return (*itr);
		}
	}
	return NULL;
}

//===================================================================================================================
//  Set Create Player Bits -- Sets bits required for creating a player in the updateMask.
//  Note:  Doesn't set Quest or Inventory bits
//  updateMask - the updatemask to hold the set bits
//===================================================================================================================
void Player::_SetCreateBits(UpdateMask *updateMask, Player *target)
{
    if ((Object *)target == (Object *)this)
    {
        Object::_SetCreateBits(updateMask, target);
    }
    else
    {
        UpdateMask mask;
        mask.SetCount(m_valuesCount);
        _SetVisibleBits(&mask, target);

        for(uint16 index = 0; index < m_valuesCount; index++)
        {
            if(GetUInt32Value(index) != 0 && mask.GetBit(index))
                updateMask->SetBit(index);
        }
    }
}

//-----------------------------------------------------------------------------
void Player::_SetUpdateBits(UpdateMask *updateMask, Player *target)
{
    if ((Object *)target == (Object *)this)
    {
        Object::_SetUpdateBits(updateMask, target);
    }
    else
    {
        UpdateMask mask;
        mask.SetCount(m_valuesCount);
        _SetVisibleBits(&mask, target);

        Object::_SetUpdateBits(updateMask, target);
        *updateMask &= mask;
    }
}

//-----------------------------------------------------------------------------
void Player::_SetVisibleBits(UpdateMask *updateMask, Player *target)
{
    updateMask->SetBit(OBJECT_FIELD_GUID);
    updateMask->SetBit(OBJECT_FIELD_TYPE);
    updateMask->SetBit(OBJECT_FIELD_SCALE_X);

    updateMask->SetBit(UNIT_FIELD_SUMMON);
    updateMask->SetBit(UNIT_FIELD_SUMMON+1);

    updateMask->SetBit(UNIT_FIELD_TARGET);
    updateMask->SetBit(UNIT_FIELD_TARGET+1);

    updateMask->SetBit(UNIT_FIELD_HEALTH);
    updateMask->SetBit(UNIT_FIELD_POWER1);
    updateMask->SetBit(UNIT_FIELD_POWER2);
    updateMask->SetBit(UNIT_FIELD_POWER3);
    updateMask->SetBit(UNIT_FIELD_POWER4);
    updateMask->SetBit(UNIT_FIELD_POWER5);

    updateMask->SetBit(UNIT_FIELD_MAXHEALTH);
    updateMask->SetBit(UNIT_FIELD_MAXPOWER1);
    updateMask->SetBit(UNIT_FIELD_MAXPOWER2);
    updateMask->SetBit(UNIT_FIELD_MAXPOWER3);
    updateMask->SetBit(UNIT_FIELD_MAXPOWER4);
    updateMask->SetBit(UNIT_FIELD_MAXPOWER5);

    updateMask->SetBit(UNIT_FIELD_LEVEL);
    updateMask->SetBit(UNIT_FIELD_FACTIONTEMPLATE);
    updateMask->SetBit(UNIT_FIELD_BYTES_0);
    updateMask->SetBit(UNIT_FIELD_FLAGS);

    for(uint16 i = UNIT_FIELD_AURA; i < UNIT_FIELD_AURASTATE; i ++)
        updateMask->SetBit(i);

    updateMask->SetBit(UNIT_FIELD_BASEATTACKTIME);
    updateMask->SetBit(UNIT_FIELD_BASEATTACKTIME+1);
	if (target->GetClass() == CLASS_HUNTER || 
		target->GetClass() == CLASS_ROGUE) updateMask->SetBit(UNIT_FIELD_RANGEDATTACKTIME);

    updateMask->SetBit(UNIT_FIELD_BOUNDINGRADIUS);
    updateMask->SetBit(UNIT_FIELD_COMBATREACH);
    updateMask->SetBit(UNIT_FIELD_DISPLAYID);
    updateMask->SetBit(UNIT_FIELD_NATIVEDISPLAYID);
    updateMask->SetBit(UNIT_FIELD_MOUNTDISPLAYID);
    updateMask->SetBit(UNIT_FIELD_BYTES_1);
    updateMask->SetBit(UNIT_FIELD_MOUNTDISPLAYID);
    updateMask->SetBit(UNIT_FIELD_PETNUMBER);
    updateMask->SetBit(UNIT_FIELD_PET_NAME_TIMESTAMP);
    updateMask->SetBit(UNIT_DYNAMIC_FLAGS);

    updateMask->SetBit(PLAYER_BYTES);
    updateMask->SetBit(PLAYER_BYTES_2);
    updateMask->SetBit(PLAYER_BYTES_3);
    updateMask->SetBit(PLAYER_GUILD_TIMESTAMP);

    for(uint16 i = 0; IS_BODY_SLOT (i); i++)
    {
        updateMask->SetBit (PLAYER_FIELD_INV_SLOT_HEAD + i*2); // lowguid
        updateMask->SetBit (PLAYER_FIELD_INV_SLOT_HEAD + (i*2) + 1); // highguid
		updateMask->SetBit (PLAYER_VISIBLE_ITEM_1_0 + (i * PLAYER_VISIBLE_ITEM_SIZE)); // Equipped item entry
    }
}

//-----------------------------------------------------------------------------
void Player::BuildCreateUpdateBlockForPlayer( UpdateData *data, Player *target )
{
    for (int i = 0; IS_BODY_SLOT (i); i++)
    {
        if(m_items[i] != NULL)	m_items[i]->BuildCreateUpdateBlockForPlayer( data, target );
	}

    if (target == this)
    {
        for(int i = EQUIPMENT_SLOT_END; i < BANK_SLOT_BAG_END; i++)
        {
			if(m_items[i] != NULL) {
				m_items[i]->BuildCreateUpdateBlockForPlayer( data, target );
				//Log::getSingleton().outDebug ("UPDATE PACKET: SENT TO UPDATE M_ITEMS [%d]", i);
			}
		}
    }

	/*for (uint16 i = 0; i < INVENTORY_SLOT_ITEM_END; i++) {
		SetUInt32Value (PLAYER_._ITEM_1_0 + (i * 9),
			m_items[i]? m_items[i]->GetUInt32Value (OBJECT_FIELD_ENTRY): 0 );
	}*/

    Unit::BuildCreateUpdateBlockForPlayer ( data, target );
}

//-----------------------------------------------------------------------------
void Player::DestroyForPlayer( Player *target )
{
    Unit::DestroyForPlayer( target );

    for(int i = 0; IS_BODY_SLOT (i); i++)
    {
        if(m_items[i] == NULL)
            continue;

        m_items[i]->DestroyForPlayer( target );
    }

    if(target == this)
    {
        for(int i = EQUIPMENT_SLOT_END; i < BANK_SLOT_BAG_END; i++)
        {
            if(m_items[i] == NULL)
                continue;

            m_items[i]->DestroyForPlayer( target );
        }
    }
}

//-----------------------------------------------------------------------------
void Player::SaveToDB()
{
	// Store update bits state before saving to database
	//UpdateMask	saveMask;
	//memcpy (&saveMask, &m_updateMask, sizeof (UpdateMask));

	if (m_dismountTimer != 0)
    {
        SetUInt32Value(UNIT_FIELD_MOUNTDISPLAYID , 0);
        RemoveFlag( UNIT_FIELD_FLAGS ,0x000004 );
        RemoveFlag( UNIT_FIELD_FLAGS, 0x002000 );
    }

    bool inworld = IsInWorld();
    if (inworld)
        RemoveFromWorld();

    //_RemoveAllItemMods();
    //_RemoveAllAffectMods();

    std::stringstream ss;
    ss << "DELETE FROM characters WHERE guid = " << GetGUIDLow();
    sDatabase.Execute( ss.str( ).c_str( ) );

    ss.rdbuf()->str("");
    ss << "INSERT INTO characters (guid, acct, name, mapId, zoneId, "\
		"positionX, positionY, positionZ, orientation, data, reputation, taximask, "\
		"buybackSlot) VALUES ("
        << GetGUIDLow() << ", " // TODO: use full guids
        << GetSession()->GetAccountId() << ", '"
        << m_name << "', "
        << m_mapId << ", "
        << m_zoneId << ", "
        << m_positionX << ", "
        << m_positionY << ", "
        << m_positionZ << ", "
        << m_orientation << ", '";

    uint16 i;
    for( i = 0; i < m_valuesCount; i++ )
        ss << GetUInt32Value(i) << " ";

    ss << "', '";
	for( i = 0; i < 64; i++ )
	{
        ss << (uint16)m_reputation[i] << " ";
		ss << (uint32)m_reputationValues[i] << " ";
	}

	ss << "', '";

    for( i = 0; i < 8; i++ )
        ss << m_taximask[i] << " ";

	uint32 buybackSlot = m_vendorBuybackSlot != NULL? m_vendorBuybackSlot->GetGUIDLow(): 0;

	ss << "', '" << buybackSlot << "' )";

    //Log::getSingleton().outDebug ( ss.str().c_str() );
	sDatabase.Execute( ss.str().c_str() );
	

    // TODO: equip all items and apply affects


	//Mail
	_SaveMail();

	//bids
	_SaveBids();

	//Auctions
	_SaveAuctions();

    // inventory
    _SaveInventory();

    // save quest progress
    _SaveQuestStatus();

	// save tutorial status
	_SaveTutorials();

	// bind point
	_SaveBindpoint();

    // spells
    _SaveSpells();

    // affects
    _SaveAffects();

	// Action buttons
	_SaveActionButtons();

	// Honor
	_SaveHonorStatus();


    //_ApplyAllAffectMods();
    //_ApplyAllItemMods();

	// Avoid resending update in network every time we save
	//ClearUpdateMask();
	//memcpy (&m_updateMask, &saveMask, sizeof (UpdateMask));

    if (inworld)
        AddToWorld();
}

//-----------------------------------------------------------------------------
void Player::_SaveQuestStatus()
{
    std::stringstream ss;
    ss << "DELETE FROM queststatus WHERE playerId = " << GetGUIDLow();
    sDatabase.Execute( ss.str().c_str() );

    for( StatusMap::iterator i = mQuestStatus.begin( ); i != mQuestStatus.end( ); ++ i )
    {
        std::stringstream ss2;
        ss2 << "INSERT INTO queststatus (playerId,questId,status,rewarded,questMobCount1,questMobCount2,questMobCount3,questMobCount4,"
            << "questItemCount1,questItemCount2,questItemCount3,questItemCount4,timer,explored) VALUES "
            << "(" << GetGUIDLow() << ", "
            << i->first << ", "
            << i->second.status << ", "
			<< i->second.rewarded << ", "
            << i->second.m_questMobCount[0] << ", "
            << i->second.m_questMobCount[1] << ", "
            << i->second.m_questMobCount[2] << ", "
            << i->second.m_questMobCount[3] << ", "
            << i->second.m_questItemCount[0] << ", "
            << i->second.m_questItemCount[1] << ", "
            << i->second.m_questItemCount[2] << ", "
            << i->second.m_questItemCount[3] << ", "
            << i->second.m_timerrel << ", "
			<< i->second.m_explored
            << ")";

            sDatabase.Execute( ss2.str().c_str() );
    }
}

void Player::_SaveHonorStatus()
{
    std::stringstream ss;
    ss << "DELETE FROM honor WHERE guid = " << GetGUIDLow();
    sDatabase.Execute( ss.str().c_str() );
	
	ss.rdbuf()->str("");
	ss  << "INSERT INTO honor (guid, SESSION_KILLS, YESTERDAY_KILLS, LAST_WEEK_KILLS, "\
		"THIS_WEEK_KILLS, THIS_WEEK_CONTRIBUTION, LIFETIME_HONORBALE_KILLS, LIFETIME_DISHONORBALE_KILLS, "\
		"YESTERDAY_CONTRIBUTION, LAST_WEEK_CONTRIBUTION, LAST_WEEK_RANK) VALUES (" 
		<< GetGUIDLow() << ", "
		<< GetUInt32Value(PLAYER_FIELD_SESSION_KILLS) << ", "
		<< GetUInt32Value(PLAYER_FIELD_YESTERDAY_KILLS) << ", "
		<< GetUInt32Value(PLAYER_FIELD_LAST_WEEK_KILLS) << ", "
		<< GetUInt32Value(PLAYER_FIELD_THIS_WEEK_KILLS) << ", "
		<< GetUInt32Value(PLAYER_FIELD_THIS_WEEK_CONTRIBUTION) << ", "
		<< GetUInt32Value(PLAYER_FIELD_LIFETIME_HONORBALE_KILLS) << ", "
		<< GetUInt32Value(PLAYER_FIELD_LIFETIME_DISHONORBALE_KILLS) << ", "
		<< GetUInt32Value(PLAYER_FIELD_YESTERDAY_CONTRIBUTION) << ", "
		<< GetUInt32Value(PLAYER_FIELD_LAST_WEEK_CONTRIBUTION) << ", "
		<< GetUInt32Value(PLAYER_FIELD_LAST_WEEK_RANK) << ") ";

	sDatabase.Execute (ss.str().c_str());
}

//-----------------------------------------------------------------------------

void Player::_SaveTutorials()
{
    std::stringstream ss;
    ss << "DELETE FROM tutorials WHERE playerId = " << GetGUIDLow();
    sDatabase.Execute( ss.str().c_str() );

    std::stringstream ss2;
    ss2 << "INSERT INTO tutorials (playerId,tut0,tut1,tut2,tut3,tut4,tut5,tut6,tut7) VALUES "
            << "(" << GetGUIDLow() << ", "
            << m_Tutorials[0] << ", "
            << m_Tutorials[1] << ", "
			<< m_Tutorials[2] << ", "
            << m_Tutorials[3] << ", "
            << m_Tutorials[4] << ", "
            << m_Tutorials[5] << ", "
            << m_Tutorials[6] << ", "
            << m_Tutorials[7]
         << ")";

     sDatabase.Execute( ss2.str().c_str() );
}

void Player::_SaveActionButtons()
{
    std::stringstream ss;
    ss << "DELETE FROM actionbuttons WHERE playerId = " << GetGUIDLow();
    sDatabase.Execute( ss.str().c_str() );

    std::stringstream ss2;
    ss2 << "INSERT INTO actionbuttons (playerId, ";

    for (int i=0; i<119; i++)
		ss2 << "butt" << (i+1) << ", ";

	ss2 << "butt120) VALUES (" << GetGUIDLow() << ", ";

    for (int i=0; i<119; i++)
		ss2 << m_actionsButtons[i] << ", ";

	ss2 << m_actionsButtons[119] << ")";

    if (!sDatabase.Execute( ss2.str().c_str() ))
	{
		Log::getSingleton().outDebug("Saving of ActionButtons failed !");
	}
}

void Player::_SaveBindpoint()
{
    std::stringstream ss;
    ss << "DELETE FROM bindpoint WHERE playerId = " << GetGUIDLow();
    sDatabase.Execute( ss.str().c_str() );

    std::stringstream ss2;
    ss2 << "INSERT INTO bindpoint (playerId,positionX,positionY,positionZ,mapId,zoneId) VALUES "
            << "(" << GetGUIDLow() << ", "
			<< m_bindPointX << ", "
            << m_bindPointY << ", "
			<< m_bindPointZ << ", "
			<< m_bindPointMap << ", "
            << m_bindPointArea
         << ")";

     sDatabase.Execute( ss2.str().c_str() );
}

//-----------------------------------------------------------------------------
void Player::_SaveInventory()
{
    std::stringstream delinvq;
    delinvq << "DELETE FROM inventory WHERE player_guid = " << GetGUIDLow(); // TODO: use full guids
    sDatabase.Execute( delinvq.str().c_str( ) );

    for(unsigned int i = 0; i < BANK_SLOT_BAG_END; i++)
    {
        if (m_items[i] != 0)
        {
            m_items[i]->SaveToDB();

            std::stringstream invq;
            invq <<  "INSERT INTO inventory (player_guid, slot, item_guid) VALUES ( " <<
                GetGUIDLow() << ", " << i << ", " << m_items[i]->GetGUIDLow() << " )";

            sDatabase.Execute( invq.str().c_str( ) );
        }
    }
}

//-----------------------------------------------------------------------------
void Player::_SaveSpells()
{
    std::stringstream query;
    query << "DELETE FROM char_spells WHERE charId = " << GetGUIDLow(); // TODO: use full guids
    sDatabase.Execute( query.str().c_str() );

    //std::list<struct spells>::iterator itr;
	SpellMap::iterator itr;
    for (itr = m_spells.begin(); itr != m_spells.end(); ++itr)
    {
        query.rdbuf()->str("");
        query << "INSERT INTO char_spells (charId,spellId,slotId) VALUES ( "
            << GetGUIDLow() << ", " << itr->first << ", " << itr->second << " )";

        sDatabase.Execute( query.str().c_str() );
    }
}

//-----------------------------------------------------------------------------
void Player::_SaveAffects()
{
}

//-----------------------------------------------------------------------------
// NOTE: 32bit guids are only for compatibility with older bases.
void Player::LoadFromDB( uint32 guid )
{
    std::stringstream ss;
    ss << "SELECT guid, acct, data, name, positionX, positionY, positionZ, mapId, "\
		"zoneId, orientation, taximask, buybackSlot, reputation FROM characters WHERE guid=" << guid;

    QueryResult *result = sDatabase.Query( ss.str().c_str() );
    ASSERT(result);

    Field *fields = result->Fetch();

    Object::_Create( guid, HIGHGUID_PLAYER );

    LoadValues( fields[2].GetString() );
	LoadReputation( fields[12].GetString() );
    // TODO: check for overflow
    m_name = fields[3].GetString();

    m_positionX = fields[4].GetFloat();
    m_positionY = fields[5].GetFloat();
    m_positionZ = fields[6].GetFloat();
    m_mapId = fields[7].GetUInt32();
    m_zoneId = fields[8].GetUInt32();
    m_orientation = fields[9].GetFloat();

    if( HasFlag(PLAYER_FLAGS, 0x10) )
        m_deathState = DEAD;

    LoadTaxiMask( fields[10].GetString() );
	
	uint32 bbslot = fields[11].GetUInt32();
	if (bbslot != 0) {
		m_vendorBuybackSlot = new Item;
		m_vendorBuybackSlot->LoadFromDB (bbslot, 1);
		if (m_vendorBuybackSlot->GetProto() == 0)
		{
			Log::getSingleton().outError ("ERR Bugged item in vendor buyback slot skipped");
			delete m_vendorBuybackSlot;
			m_vendorBuybackSlot = NULL;
		}
	} else {
		m_vendorBuybackSlot = NULL;
	}

    delete result;

	// Load skills
	m_skills.clear();
	for (int i = 0; i < 128; i++)
	{
		uint32 skillId = GetUInt32Value (PLAYER_SKILL_INFO_1_1 + i * 3);
		uint16 skillLevel = GetUInt32Value (PLAYER_SKILL_INFO_1_1 + i * 3 + 1) >> 16;
		m_skills[skillId] = skillLevel;
	}

    /*
    m_outfitId = atoi( row[ 11 ] );
    m_guildId = atoi( row[ 17 ] );
    m_petInfoId = atoi( row[ 18 ] );
    m_petLevel = atoi( row[ 19 ] );
    m_petFamilyId = atoi( row[ 20 ] );
    */

	_LoadMail();
    _LoadInventory();
    _LoadSpells();
    _LoadQuestStatus();
	_LoadBids();
    _LoadAffects();
	_LoadTutorials();
	_LoadBindpoint();
	_LoadActionButtons();
	_LoadHonorStatus();

	// Reset aura icons and flags
	SetUInt32Value (UNIT_FIELD_BYTES_1, 0);

	for (int i = 0; i < 8; i++) 
		if (GetUInt32Value (UNIT_FIELD_AURAFLAGS + i) != 0)
		SetUInt32Value (UNIT_FIELD_AURAFLAGS + i, 0);

	for (int i = 0; i < 32; i++) 
		if (GetUInt32Value (UNIT_FIELD_AURA + i) != 0)
			SetUInt32Value (UNIT_FIELD_AURA + i, 0);

	//for (int i = 0; i < 16; i++) 
	//	if (GetUInt32Value (UNIT_FIELD_AURAAPPLICATIONS + i) != 0)
	//		SetUInt32Value (UNIT_FIELD_AURAAPPLICATIONS + i, 0);

	// Recalculate stats
	_RecalculatePlayerStats();

	// Setting REST STATE
	// To-do: rest in Inn and rest outside at rate 1/4 lower
	uint32 rested_time = ((uint32)time(NULL) - m_timeLogoff) / 3600;
	if (rested_time >= 8) {
		uint32 MaxRestedBonus = (GetNextLevelXP()+ (GetNextLevelXP()/2))/2;
		uint32 MaxBubbleValue = MaxRestedBonus/20;
		ModifyRestStateXP((rested_time / 8) * MaxBubbleValue);   // 1 Bubble per 8 hours
	}
	if (GetRestStateXP() >  0) m_isRested = 1;
	if (GetRestStateXP() == 0) m_isRested = 0;
}

//-----------------------------------------------------------------------------
void Player::_RecalculatePlayerStats()
{
	m_minDamage = 0.0f;
	m_maxDamage = 0.0f;

	r_minDamage = 0.0f;
	r_maxDamage = 0.0f;

	SetFloatValue (PLAYER_FIELD_MOD_DAMAGE_DONE_PCT + DMG_PHYSICAL, 1.0f);
	SetFloatValue (PLAYER_FIELD_MOD_DAMAGE_DONE_PCT + DMG_HOLY,		1.0f);
	SetFloatValue (PLAYER_FIELD_MOD_DAMAGE_DONE_PCT + DMG_FIRE,		1.0f);
	SetFloatValue (PLAYER_FIELD_MOD_DAMAGE_DONE_PCT + DMG_NATURE,	1.0f);
	SetFloatValue (PLAYER_FIELD_MOD_DAMAGE_DONE_PCT + DMG_SHADOW,	1.0f);
	SetFloatValue (PLAYER_FIELD_MOD_DAMAGE_DONE_PCT + DMG_ARCANE,	1.0f);

	SetUInt32Value (PLAYER_FIELD_MOD_DAMAGE_DONE_POS + DMG_PHYSICAL, 0);
	SetUInt32Value (PLAYER_FIELD_MOD_DAMAGE_DONE_POS + DMG_HOLY,	0);
	SetUInt32Value (PLAYER_FIELD_MOD_DAMAGE_DONE_POS + DMG_FIRE,	0);
	SetUInt32Value (PLAYER_FIELD_MOD_DAMAGE_DONE_POS + DMG_NATURE,	0);
	SetUInt32Value (PLAYER_FIELD_MOD_DAMAGE_DONE_POS + DMG_SHADOW,	0);
	SetUInt32Value (PLAYER_FIELD_MOD_DAMAGE_DONE_POS + DMG_ARCANE,	0);

	SetUInt32Value (PLAYER_FIELD_MOD_DAMAGE_DONE_NEG + DMG_PHYSICAL, 0);
	SetUInt32Value (PLAYER_FIELD_MOD_DAMAGE_DONE_NEG + DMG_HOLY,	0);
	SetUInt32Value (PLAYER_FIELD_MOD_DAMAGE_DONE_NEG + DMG_FIRE,	0);
	SetUInt32Value (PLAYER_FIELD_MOD_DAMAGE_DONE_NEG + DMG_NATURE,	0);
	SetUInt32Value (PLAYER_FIELD_MOD_DAMAGE_DONE_NEG + DMG_SHADOW,	0);
	SetUInt32Value (PLAYER_FIELD_MOD_DAMAGE_DONE_NEG + DMG_ARCANE,	0);

	_ResetBaseStats();
	
	_ApplyAllAffectMods();
	_ApplyAllItemMods();

	// Restore Health/Mana to their Maximum
	if (GetHealth() < GetMaxHealth()) SetHealth (GetMaxHealth());
	if (GetMana() < GetMaxMana()) SetMana (GetMaxMana());
}

//-----------------------------------------------------------------------------
void Player::_LoadInventory()
{
    // Clean current inventory
    for(uint16 i = 0; i < BANK_SLOT_BAG_END; i++)
    {
        if(m_items[i])
        {
            delete m_items[i];

            SetUInt64Value (PLAYER_FIELD_INV_SLOT_HEAD + i*2, 0);
            m_items[i] = 0;
        }
    }

    // Inventory
    std::stringstream invq;
    invq << "SELECT item_guid, slot FROM inventory WHERE player_guid=" << GetGUIDLow();

    QueryResult *result = sDatabase.Query( invq.str().c_str() );
    if(result)
    {
        do
        {
            Field *fields = result->Fetch();

			// Here we define whether we load Item or Container
			Item* item;
			if (IS_BAG_SLOT(fields[1].GetUInt32())) {
				//Log::getSingleton().outDebug("INVENTORY: CONTAINER - PREPARED TO LOAD");
				item = new Container;
			}
			else {
				//Log::getSingleton().outDebug("INVENTORY: ITEM - PREPARED TO LOAD");
				item = new Item;
			}
			//////////////////////////////////////////////////
		
			item->LoadFromDB(fields[0].GetUInt32(),1);

			if (item->GetProto() == NULL)
			{
				Log::getSingleton().outError ("ERR Bugged item in inventory skipped");
				delete item;
				continue;
			}

			AddItemToSlot( (uint8)fields[1].GetUInt16(), item);


        }
        while( result->NextRow() );

        delete result;
    }
}

//-----------------------------------------------------------------------------
/*bool Player::HasSpell(uint32 spell)
{
    std::list<struct spells>::iterator itr;
    for (itr = m_spells.begin(); itr != m_spells.end(); ++itr)
    {
		if (itr->spellId == spell)
		{
			return true;
		}
	}
	return false;
}*/

//-----------------------------------------------------------------------------
void Player::_LoadSpells()
{
    // Clear spell list
    m_spells.clear();

    // Spells
    std::stringstream query;
    query << "SELECT spellId, slotId FROM char_spells WHERE charId=" << GetGUIDLow();

    QueryResult *result = sDatabase.Query( query.str().c_str() );
    if(result)
    {
        do
        {
            Field *fields = result->Fetch();

            AddSpell (fields[0].GetUInt32(), fields[1].GetUInt16());
        }
        while( result->NextRow() );

        delete result;
    }
}

//-----------------------------------------------------------------------------
void Player::_LoadQuestStatus()
{
    // clear list

    mQuestStatus.clear();

    std::stringstream ss;
    ss << "SELECT * FROM queststatus WHERE playerId=" << GetGUIDLow();

    QueryResult *result = sDatabase.Query( ss.str().c_str() );
    if(result)
    {
        do
        {
            Field *fields = result->Fetch();

            quest_status qs;
            qs.quest_id            = fields[1].GetUInt32();
            qs.status              = fields[2].GetUInt32();
			qs.rewarded            = ( fields[3].GetUInt32() > 0 );
            qs.m_questMobCount[0]  = fields[4].GetUInt32();
            qs.m_questMobCount[1]  = fields[5].GetUInt32();
            qs.m_questMobCount[2]  = fields[6].GetUInt32();
            qs.m_questMobCount[3]  = fields[7].GetUInt32();
            qs.m_questItemCount[0] = fields[8].GetUInt32();
            qs.m_questItemCount[1] = fields[9].GetUInt32();
            qs.m_questItemCount[2] = fields[10].GetUInt32();
            qs.m_questItemCount[3] = fields[11].GetUInt32();
			qs.m_timerrel		   = fields[12].GetUInt32();
			qs.m_explored		   = ( fields[13].GetUInt32() > 0 );

			// Recalculating quest timers !

			time_t q_abs = time(NULL);
			Quest *pQuest = objmgr.GetQuest(qs.quest_id);

			if (pQuest && (pQuest->HasBehavior(QUEST_BEHAVIOR_TIMED)) )
			{
				Log::getSingleton().outDebug("Time now {%u}, then {%u} in quest {%u}!", q_abs, qs.m_timerrel, qs.quest_id);
				if  ( qs.m_timerrel > q_abs ) // still time to finish quest !
				{
					qs.m_timer = (qs.m_timerrel - q_abs) * 1000; // miliseconds
					Log::getSingleton().outDebug("Setup timer at {%u}msec. for quest {%u}!", qs.m_timer, qs.quest_id);
					loadExistingQuest(qs);
					m_timedQuest = qs.quest_id;

					continue;
				} else // timer has expired !
				{
					Log::getSingleton().outDebug("Timer expired for quest {%u}!", qs.quest_id);
					qs.m_timer    = 0;

					if ( qs.status == QUEST_STATUS_COMPLETE )
						qs.status     = QUEST_STATUS_INCOMPLETE;

					qs.m_timerrel = 0;
				}
			}

			Log::getSingleton().outDebug("Quest status is {%u} for quest {%u}", qs.status, qs.quest_id);
            loadExistingQuest(qs);

        }
        while( result->NextRow() );

        delete result;
    }
}

//-----------------------------------------------------------------------------
void Player::_LoadHonorStatus()
{
    std::stringstream ss;
    ss << "SELECT * FROM honor WHERE guid=" << GetGUIDLow();

    QueryResult *result = sDatabase.Query( ss.str().c_str() );

    if (result)
	{
		Field *fields = result->Fetch();

		SetUInt32Value(PLAYER_FIELD_SESSION_KILLS, fields[1].GetUInt32());
		SetUInt32Value(PLAYER_FIELD_YESTERDAY_KILLS, fields[2].GetUInt32());
		SetUInt32Value(PLAYER_FIELD_LAST_WEEK_KILLS, fields[3].GetUInt32());
		SetUInt32Value(PLAYER_FIELD_THIS_WEEK_KILLS, fields[4].GetUInt32());
		SetUInt32Value(PLAYER_FIELD_THIS_WEEK_CONTRIBUTION, fields[5].GetUInt32());
		SetUInt32Value(PLAYER_FIELD_LIFETIME_HONORBALE_KILLS, fields[6].GetUInt32());
		SetUInt32Value(PLAYER_FIELD_LIFETIME_DISHONORBALE_KILLS, fields[7].GetUInt32());
		SetUInt32Value(PLAYER_FIELD_YESTERDAY_CONTRIBUTION, fields[8].GetUInt32());
		SetUInt32Value(PLAYER_FIELD_LAST_WEEK_CONTRIBUTION, fields[9].GetUInt32());
		SetUInt32Value(PLAYER_FIELD_LAST_WEEK_RANK, fields[10].GetUInt32());
 
        delete result;
    }
}

//-----------------------------------------------------------------------------
void Player::_LoadActionButtons()
{
    // clear list

	for (int i=0; i<120;i++)
		m_actionsButtons[i] = 0;

    std::stringstream ss;
    ss << "SELECT * FROM actionbuttons WHERE playerId=" << GetGUIDLow();

    QueryResult *result = sDatabase.Query( ss.str().c_str() );
    if(result)
    {
        do
        {
            Field *fields = result->Fetch();

			for (int i=0; i<120; i++)
			{
				m_actionsButtons[i] = fields[i+1].GetUInt32();
			}

        }
        while( result->NextRow() );

        delete result;
    }
}

void Player::_LoadBindpoint()
{
    std::stringstream ss;
    ss << "SELECT * FROM bindpoint WHERE playerId=" << GetGUIDLow();

    QueryResult *result = sDatabase.Query( ss.str().c_str() );
    if(result)
    {
        do
        {
            Field *fields = result->Fetch();

			m_bindPointX    = fields[1].GetFloat();
			m_bindPointY    = fields[2].GetFloat();
			m_bindPointZ    = fields[3].GetFloat();
			m_bindPointMap  = fields[4].GetUInt32();
			m_bindPointArea = fields[5].GetUInt32();
        }
        while( result->NextRow() );

        delete result;
    }
}

//-----------------------------------------------------------------------------
void Player::_LoadTutorials()
{
    std::stringstream ss;
    ss << "SELECT * FROM tutorials WHERE playerId=" << GetGUIDLow();

    QueryResult *result = sDatabase.Query( ss.str().c_str() );
    if(result)
    {
        do
        {
            Field *fields = result->Fetch();

			for (int iI=0; iI<8; iI++) 
				m_Tutorials[iI] = fields[iI + 1].GetUInt32();

        }
        while( result->NextRow() );

        delete result;
    }
}

//-----------------------------------------------------------------------------
void Player::_LoadAffects()
{
}

//-----------------------------------------------------------------------------
void Player::DeleteFromDB()
{
    std::stringstream ss;

    ss << "DELETE FROM characters WHERE guid = " << GetGUIDLow();
    sDatabase.Execute( ss.str( ).c_str( ) );

    ss.rdbuf()->str("");
    ss << "DELETE FROM char_spells WHERE charid = " << GetGUIDLow();
    sDatabase.Execute( ss.str( ).c_str( ) );

    ss.rdbuf()->str("");
    ss << "DELETE FROM inventory WHERE player_guid = " << GetGUIDLow();
    sDatabase.Execute( ss.str( ).c_str( ) );

    for(int i = 0; IS_BODY_SLOT (i); i++)
    {
        if(m_items[i] == NULL)
            continue;

        m_items[i]->DeleteFromDB();
    }

    ss.rdbuf()->str("");
    ss << "DELETE FROM queststatus WHERE playerId = " << GetGUIDLow();
    sDatabase.Execute( ss.str( ).c_str( ) );

    ss.rdbuf()->str("");
    ss << "DELETE FROM tutorials WHERE playerId = " << GetGUIDLow();
    sDatabase.Execute( ss.str( ).c_str( ) );

	ss.rdbuf()->str("");
    ss << "DELETE FROM honor WHERE guid = " << GetGUIDLow();
    sDatabase.Execute( ss.str().c_str() );

}

//-----------------------------------------------------------------------------
uint8 Player::FindFreeItemSlot(uint32 type)
{
    switch(type)
    {
    case INVTYPE_NON_EQUIP:
        return INVENTORY_SLOT_ITEM_END; // ???
    case INVTYPE_HEAD:
        {
            if (!GetItemBySlot(EQUIPMENT_SLOT_HEAD))
                return EQUIPMENT_SLOT_HEAD;
            else
                return INVENTORY_SLOT_ITEM_END;
        }
    case INVTYPE_NECK:
        {
            if (!GetItemBySlot(EQUIPMENT_SLOT_NECK))
                return EQUIPMENT_SLOT_NECK;
            else
                return INVENTORY_SLOT_ITEM_END;
        }
    case INVTYPE_SHOULDERS:
        {
            if (!GetItemBySlot(EQUIPMENT_SLOT_SHOULDERS))
                return EQUIPMENT_SLOT_SHOULDERS;
            else
                return INVENTORY_SLOT_ITEM_END;
        }
    case INVTYPE_BODY:
        {
            if (!GetItemBySlot(EQUIPMENT_SLOT_BODY))
                return EQUIPMENT_SLOT_BODY;
            else
                return INVENTORY_SLOT_ITEM_END;
        }
    case INVTYPE_CHEST:
        {
            if (!GetItemBySlot(EQUIPMENT_SLOT_CHEST))
                return EQUIPMENT_SLOT_CHEST;
            else
                return INVENTORY_SLOT_ITEM_END;
        }
    case INVTYPE_ROBE:
        {
            if (!GetItemBySlot(EQUIPMENT_SLOT_CHEST))
                return EQUIPMENT_SLOT_CHEST;
            else
                return INVENTORY_SLOT_ITEM_END;
        }
    case INVTYPE_WAIST:
        {
            if (!GetItemBySlot(EQUIPMENT_SLOT_WAIST))
                return EQUIPMENT_SLOT_WAIST;
            else
                return INVENTORY_SLOT_ITEM_END;
        }
    case INVTYPE_LEGS:
        {
            if (!GetItemBySlot(EQUIPMENT_SLOT_LEGS))
                return EQUIPMENT_SLOT_LEGS;
            else
                return INVENTORY_SLOT_ITEM_END;
        }
    case INVTYPE_FEET:
        {
            if (!GetItemBySlot(EQUIPMENT_SLOT_FEET))
                return EQUIPMENT_SLOT_FEET;
            else
                return INVENTORY_SLOT_ITEM_END;
        }
    case INVTYPE_WRISTS:
        {
            if (!GetItemBySlot(EQUIPMENT_SLOT_WRISTS))
                return EQUIPMENT_SLOT_WRISTS;
            else
                return INVENTORY_SLOT_ITEM_END;
        }
    case INVTYPE_HANDS:
        {
            if (!GetItemBySlot(EQUIPMENT_SLOT_HANDS))
                return EQUIPMENT_SLOT_HANDS;
            else
                return INVENTORY_SLOT_ITEM_END;
        }
    case INVTYPE_FINGER:
        {
            if (!GetItemBySlot(EQUIPMENT_SLOT_FINGER1))
                return EQUIPMENT_SLOT_FINGER1;
            else if (!GetItemBySlot(EQUIPMENT_SLOT_FINGER2))
                return EQUIPMENT_SLOT_FINGER2;
            else
                return INVENTORY_SLOT_ITEM_END;
        }
    case INVTYPE_TRINKET:
        {
            if (!GetItemBySlot(EQUIPMENT_SLOT_TRINKET1))
                return EQUIPMENT_SLOT_TRINKET1;
            else if (!GetItemBySlot(EQUIPMENT_SLOT_TRINKET2))
                return EQUIPMENT_SLOT_TRINKET2;
            else
                return INVENTORY_SLOT_ITEM_END;
        }
    case INVTYPE_CLOAK:
        {
            if (!GetItemBySlot(EQUIPMENT_SLOT_BACK))
                return EQUIPMENT_SLOT_BACK;
            else
                return INVENTORY_SLOT_ITEM_END;
        }
    case INVTYPE_WEAPON:
        {
            if (!GetItemBySlot(EQUIPMENT_SLOT_MAINHAND) )
                return EQUIPMENT_SLOT_MAINHAND;
            else
                return INVENTORY_SLOT_ITEM_END;
        }
    case INVTYPE_SHIELD:
        {
            if (!GetItemBySlot(EQUIPMENT_SLOT_OFFHAND))
                return EQUIPMENT_SLOT_OFFHAND;
            else
                return INVENTORY_SLOT_ITEM_END;
        }
    case INVTYPE_RANGED:
        {
            if (!GetItemBySlot(EQUIPMENT_SLOT_RANGED))
                return EQUIPMENT_SLOT_RANGED;
            else
                return INVENTORY_SLOT_ITEM_END;
        }
    case INVTYPE_TWOHAND_WEAPON:
        {
            if (!GetItemBySlot(EQUIPMENT_SLOT_MAINHAND) && !GetItemBySlot(EQUIPMENT_SLOT_OFFHAND))
                return EQUIPMENT_SLOT_MAINHAND;
            else
                return INVENTORY_SLOT_ITEM_END;
        }
    case INVTYPE_TABARD:
        {
            if (!GetItemBySlot(EQUIPMENT_SLOT_TABARD))
                return EQUIPMENT_SLOT_TABARD;
            else
                return INVENTORY_SLOT_ITEM_END;
        }
    case INVTYPE_WEAPONMAINHAND:
        {
            if (!GetItemBySlot(EQUIPMENT_SLOT_MAINHAND))
                return EQUIPMENT_SLOT_MAINHAND;
            else
                return INVENTORY_SLOT_ITEM_END;
        }
    case INVTYPE_WEAPONOFFHAND:
        {
            if (!GetItemBySlot(EQUIPMENT_SLOT_OFFHAND))
                return EQUIPMENT_SLOT_OFFHAND;
            else
                return INVENTORY_SLOT_ITEM_END;
        }
    case INVTYPE_HOLDABLE:
        {
            if (!GetItemBySlot(EQUIPMENT_SLOT_MAINHAND))
                return EQUIPMENT_SLOT_MAINHAND;
            else
                return INVENTORY_SLOT_ITEM_END;
        }
    case INVTYPE_AMMO:
        return EQUIPMENT_SLOT_RANGED; // ?
    case INVTYPE_THROWN:
        return EQUIPMENT_SLOT_RANGED; // ?
    case INVTYPE_RANGEDRIGHT:
        return EQUIPMENT_SLOT_RANGED; // ?
    case INVTYPE_BAG:
        {
            for (uint8 i = INVENTORY_SLOT_BAG_START; i < INVENTORY_SLOT_BAG_END; i++)
            {
                if (!GetItemBySlot(i))
                    return i;
            }
            return INVENTORY_SLOT_ITEM_END;
        }
    default:
        ASSERT(0);
        return INVENTORY_SLOT_ITEM_END;
    }
}

//-----------------------------------------------------------------------------

bool Player::CanEquipItem (ItemPrototype * proto)
{
	uint8  error_code = EQUIP_ERR_OK;

	// Check if Required Level is satisfied
	if (GetLevel() < proto->RequiredLevel)	
		 {error_code = EQUIP_ERR_YOU_MUST_REACH_LEVEL_N;}
	else {error_code = EQUIP_ERR_OK;}
	// -------------------------------------
	
	// Check of Skill Requirements to use Inventory Type
	if (!error_code) {

	// Error Code is set, we are trying to drop it to OK if any match found
	error_code = EQUIP_ERR_NO_REQUIRED_PROFICIENCY;
	switch (proto->InventoryType)
	{
	// 1-Hand Weapon
	case INVTYPE_WEAPON:
	case INVTYPE_WEAPONMAINHAND:
		switch (proto->SubClass)
		{
		// 1-Hand Weapons
		case ITEM_SUBCLASS_MACE:			if (HasSpell (198)   && HasSkill (SKILL_MACES)		 ) error_code = EQUIP_ERR_OK; break;
		case ITEM_SUBCLASS_SWORD:			if (HasSpell (201)	 && HasSkill (SKILL_SWORDS)		 ) error_code = EQUIP_ERR_OK; break;
		case ITEM_SUBCLASS_DAGGER:			if (HasSpell (1180)	 && HasSkill (SKILL_DAGGERS)	 ) error_code = EQUIP_ERR_OK; break;
		case ITEM_SUBCLASS_AXE:				if (HasSpell (196)	 && HasSkill (SKILL_AXES)		 ) error_code = EQUIP_ERR_OK; break;
		case ITEM_SUBCLASS_FIST_WEAPON:		if (HasSpell (15590) && HasSkill (SKILL_FIST_WEAPONS)) error_code = EQUIP_ERR_OK; break;
		case ITEM_SUBCLASS_MISC_WEAPON:		error_code = EQUIP_ERR_OK; break;
		default: error_code = EQUIP_ERR_YOU_CAN_NEVER_USE_THAT_ITEM;
		}
		break;

	// 2-Hand Weapon	
	case INVTYPE_TWOHAND_WEAPON:
		switch (proto->SubClass)
		{
		// 2-Hand Weapons
		case ITEM_SUBCLASS_TWOHAND_SWORD:	if (HasSpell (202) && HasSkill (SKILL_TWO_HANDED_SWORDS)) error_code = EQUIP_ERR_OK; break;
		case ITEM_SUBCLASS_TWOHAND_AXE:		if (HasSpell (197) && HasSkill (SKILL_TWO_HANDED_AXES)	) error_code = EQUIP_ERR_OK; break;
		case ITEM_SUBCLASS_POLEARM:			if (HasSpell (200) && HasSkill (SKILL_POLEARMS)			) error_code = EQUIP_ERR_OK; break;
		case ITEM_SUBCLASS_TWOHAND_MACE:	if (HasSpell (199) && HasSkill (SKILL_TWO_HANDED_MACES)	) error_code = EQUIP_ERR_OK; break;
		case ITEM_SUBCLASS_STAFF:			if (HasSpell (227) && HasSkill (SKILL_STAVES)			) error_code = EQUIP_ERR_OK; break;
		case ITEM_SUBCLASS_FISHING_POLE:	if (HasSpell (7738) && HasSkill(SKILL_FISHING)			) error_code = EQUIP_ERR_OK; break;
		default: error_code = EQUIP_ERR_YOU_CAN_NEVER_USE_THAT_ITEM;
		}
		break;
	
	// Off Hand Weapon
	case INVTYPE_WEAPONOFFHAND:
		switch (proto->SubClass)
		{
		// 1-Hand Weapons
		case ITEM_SUBCLASS_DAGGER:			if (HasSpell (1180)	 && HasSkill (SKILL_DAGGERS)	 ) error_code = EQUIP_ERR_OK; break;
		case ITEM_SUBCLASS_SWORD:			if (HasSpell (201)	 && HasSkill (SKILL_SWORDS)		 ) error_code = EQUIP_ERR_OK; break;
		case ITEM_SUBCLASS_AXE:				if (HasSpell (196)	 && HasSkill (SKILL_AXES)		 ) error_code = EQUIP_ERR_OK; break;
		case ITEM_SUBCLASS_FIST_WEAPON:		if (HasSpell (15590) && HasSkill (SKILL_FIST_WEAPONS)) error_code = EQUIP_ERR_OK; break;
		case ITEM_SUBCLASS_MISC_WEAPON:		error_code = EQUIP_ERR_OK;
		default: error_code = EQUIP_ERR_YOU_CAN_NEVER_USE_THAT_ITEM;
		}
		break;

	// Ranged Weapon
	case INVTYPE_RANGED:
	case INVTYPE_RANGEDRIGHT:
		switch (proto->SubClass)
		{
		// Ranged Weapons
		case ITEM_SUBCLASS_BOW:				if (HasSpell (264)	&& HasSkill (SKILL_BOWS)		) error_code = EQUIP_ERR_OK; break;
		case ITEM_SUBCLASS_CROSSBOW:		if (HasSpell (5011)	&& HasSkill (SKILL_CROSSBOWS)	) error_code = EQUIP_ERR_OK; break;
		case ITEM_SUBCLASS_GUN:				if (HasSpell (266)	&& HasSkill (SKILL_GUNS)		) error_code = EQUIP_ERR_OK; break;
		case ITEM_SUBCLASS_WAND:			if (HasSpell (5009)	&& HasSkill (SKILL_WANDS)		) error_code = EQUIP_ERR_OK; break;
		case ITEM_SUBCLASS_THROWN:			if (HasSpell (2567)	&& HasSkill (SKILL_THROWN)		) error_code = EQUIP_ERR_OK; break;
		default: error_code = EQUIP_ERR_YOU_CAN_NEVER_USE_THAT_ITEM;
		}
		break;

	// Armor
	case INVTYPE_SHIELD:
	case INVTYPE_HEAD:
	case INVTYPE_SHOULDERS:
	case INVTYPE_CHEST:
	case INVTYPE_WAIST:
	case INVTYPE_LEGS:
	case INVTYPE_FEET:
	case INVTYPE_WRISTS:
	case INVTYPE_HANDS:
		// Armor
		switch (proto->SubClass)
		{
		case ITEM_SUBCLASS_CLOTH:			if (HasSkill (SKILL_CLOTH)		) error_code = EQUIP_ERR_OK;  break;
		case ITEM_SUBCLASS_LEATHER:			if (HasSkill (SKILL_LEATHER)	) error_code = EQUIP_ERR_OK;  break;
		case ITEM_SUBCLASS_MAIL:			if (HasSkill (SKILL_MAIL)		) error_code = EQUIP_ERR_OK;  break;
		case ITEM_SUBCLASS_PLATE_MAIL:		if (HasSkill (SKILL_PLATE_MAIL)	) error_code = EQUIP_ERR_OK;  break;
		case ITEM_SUBCLASS_SHIELD:			if (HasSkill (SKILL_SHIELD)		) error_code = EQUIP_ERR_OK;  break;
		case ITEM_SUBCLASS_MISC:			error_code = EQUIP_ERR_OK;  break;
		default: error_code = EQUIP_ERR_YOU_CAN_NEVER_USE_THAT_ITEM;
		}
		break;

	case INVTYPE_HOLDABLE:
		error_code = EQUIP_ERR_OK;
		break;

	case INVTYPE_BODY:
	case INVTYPE_TABARD:
	case INVTYPE_NECK:
	case INVTYPE_FINGER:
	case INVTYPE_TRINKET:
	case INVTYPE_CLOAK:
	case INVTYPE_ROBE:
		error_code = EQUIP_ERR_OK;
		break;
	default: error_code = EQUIP_ERR_YOU_CAN_NEVER_USE_THAT_ITEM;
	}
	}

	// Issue Error Code to Player and give FALSE to function if Error Code is not ZERO
	if (error_code) {
		WorldPacket	data;
    	Item* pItem = new Item();
		pItem->Create (objmgr.GenerateLowGuid (HIGHGUID_ITEM), proto->ItemId, this);
		Make_INVENTORY_CHANGE_FAILURE (&data, error_code, pItem, 0);
		GetSession()->SendPacket (&data);
		return false;
	}
	else return true;
	// ------------------------------------
}


//-----------------------------------------------------------------------------
bool Player::CheckSlotSuitable(uint8 slot, uint32 type)
{
	uint8 error_code;

	switch(slot)
    {
    case EQUIPMENT_SLOT_HEAD:		return (type == INVTYPE_HEAD);
    case EQUIPMENT_SLOT_NECK:		return (type == INVTYPE_NECK);
    case EQUIPMENT_SLOT_SHOULDERS:	return (type == INVTYPE_SHOULDERS);
    case EQUIPMENT_SLOT_BODY:		return (type == INVTYPE_BODY);
    case EQUIPMENT_SLOT_CHEST:		return (type == INVTYPE_CHEST || 
											type == INVTYPE_ROBE);
    case EQUIPMENT_SLOT_WAIST:		return (type == INVTYPE_WAIST);
    case EQUIPMENT_SLOT_LEGS:		return (type == INVTYPE_LEGS);
    case EQUIPMENT_SLOT_FEET:		return (type == INVTYPE_FEET);
    case EQUIPMENT_SLOT_WRISTS:		return (type == INVTYPE_WRISTS);
    case EQUIPMENT_SLOT_HANDS:		return (type == INVTYPE_HANDS);

	case EQUIPMENT_SLOT_FINGER1:
    case EQUIPMENT_SLOT_FINGER2:	return (type == INVTYPE_FINGER);

    case EQUIPMENT_SLOT_TRINKET1:
    case EQUIPMENT_SLOT_TRINKET2:	return (type == INVTYPE_TRINKET);

    case EQUIPMENT_SLOT_BACK:		return (type == INVTYPE_CLOAK);

	case EQUIPMENT_SLOT_MAINHAND:
									return (type == INVTYPE_WEAPON ||
											type == INVTYPE_WEAPONMAINHAND ||
											type == INVTYPE_HOLDABLE ||
										   (type == INVTYPE_TWOHAND_WEAPON && !GetItemBySlot(EQUIPMENT_SLOT_OFFHAND)));

	case EQUIPMENT_SLOT_OFFHAND:
		if (GetItemBySlot(EQUIPMENT_SLOT_MAINHAND)) {
									return ((type == INVTYPE_WEAPON || 
											 type == INVTYPE_SHIELD || 
											 type == INVTYPE_WEAPONOFFHAND || 
											 type == INVTYPE_HOLDABLE) &&
											(GetItemBySlot(EQUIPMENT_SLOT_MAINHAND)->GetProto()->InventoryType != INVTYPE_TWOHAND_WEAPON));
		}
		else 
		{
									return ( type == INVTYPE_WEAPON || 
											 type == INVTYPE_SHIELD || 
											 type == INVTYPE_WEAPONOFFHAND || 
											 type == INVTYPE_HOLDABLE);
		}

	case EQUIPMENT_SLOT_RANGED:
									return (type == INVTYPE_AMMO || 
											type == INVTYPE_THROWN || 
											type == INVTYPE_RANGEDRIGHT ||
											type == INVTYPE_RANGED);

	case EQUIPMENT_SLOT_TABARD:		return (type == INVTYPE_TABARD);

    case INVENTORY_SLOT_BAG_1:
    case INVENTORY_SLOT_BAG_2:
    case INVENTORY_SLOT_BAG_3:
    case INVENTORY_SLOT_BAG_4:		return (type == INVTYPE_BAG);

    case INVENTORY_SLOT_ITEM_1:
    case INVENTORY_SLOT_ITEM_2:
    case INVENTORY_SLOT_ITEM_3:
    case INVENTORY_SLOT_ITEM_4:
    case INVENTORY_SLOT_ITEM_5:
    case INVENTORY_SLOT_ITEM_6:
    case INVENTORY_SLOT_ITEM_7:
    case INVENTORY_SLOT_ITEM_8:
    case INVENTORY_SLOT_ITEM_9:
    case INVENTORY_SLOT_ITEM_10:
    case INVENTORY_SLOT_ITEM_11:
    case INVENTORY_SLOT_ITEM_12:
    case INVENTORY_SLOT_ITEM_13:
    case INVENTORY_SLOT_ITEM_14:
    case INVENTORY_SLOT_ITEM_15:
    case INVENTORY_SLOT_ITEM_16:	return true;

	default: error_code = EQUIP_ERR_ITEM_DOESNT_GO_TO_SLOT;
    }

	// Issue Error Code and give FALSE
	WorldPacket	data;
	Make_INVENTORY_CHANGE_FAILURE (&data, error_code, 0, 0);
	GetSession()->SendPacket (&data);
	return false;
	// ------------------------------------
}

//--------------------------------------------------
void Player::SetPreviousGossipMenu( NPCGossipMenu *pMenu, int mMove )
{
	m_Menu = pMenu;
	m_Menu_Move = mMove;
}

//-----------------------------------------------------------------------------
NPCGossipMenu *Player::GetPreviousGossipMenu()
{
	return m_Menu;
}

//-----------------------------------------------------------------------------
int Player::GetPreviousGossipMenuMove()
{
	return m_Menu_Move;
}

//-----------------------------------------------------------------------------
// !!! SWAP IS BUGGED - WHEN ADDING ALL CONTAINERS TO CONTAINER SLOTS, 
// AFTER ADDING THE LEFT ONE, THE VERY RIGHT (19 slot) DISAPPEARS BUT VISUALLY
// AFTER RELOGIN IT SAY ON PLACE AS NORMAL (HAD NO TIME TO FIX)

bool Player::SwapItemSlots(uint8 srcslot, uint8 dstslot)
{
    ASSERT(srcslot < BANK_SLOT_BAG_END);
    ASSERT(dstslot < BANK_SLOT_BAG_END);
	
	WorldPacket	data;

	Log::getSingleton().outDebug("ack > INVENTORY: SWAP ITEM << SRC[%d]|[%d]DST >> ", srcslot, dstslot);

	// Dropped directly on bag icon - will not process it yet
	//
	if (IS_BAG_SLOT (dstslot) && m_items[srcslot]->GetProto()->InventoryType != INVTYPE_BAG ) {
		//dstslot = srcslot;
		Make_INVENTORY_CHANGE_FAILURE (&data, EQUIP_ERR_CANT_DO_RIGHT_NOW, m_items[srcslot], m_items[dstslot]);
		//GetSession()->SystemMessage("Inventory: (Swap.bagslot) EQUIP_ERR_CANT_DO_RIGHT_NOW");
		GetSession()->SendPacket( &data );
		return false;
	}

	if (IS_BANK_BAG_SLOT (dstslot)) {
		//dstslot = srcslot;
		Make_INVENTORY_CHANGE_FAILURE (&data, EQUIP_ERR_CANT_DO_RIGHT_NOW, m_items[srcslot], m_items[dstslot]);
		//GetSession()->SystemMessage("Inventory: (Swap.bankslot) EQUIP_ERR_CANT_DO_RIGHT_NOW");
		GetSession()->SendPacket( &data );
		return false;
	}

	// check to make sure items are not being put in wrong spots
	if ((srcslot >= INVENTORY_SLOT_ITEM_START && dstslot < INVENTORY_SLOT_ITEM_END) ||
		IS_BAG_SLOT(dstslot) || IS_BANK_BAG_SLOT (dstslot) || (srcslot >= BANK_SLOT_ITEM_START && dstslot < BANK_SLOT_ITEM_END) )
	{
		if (m_items[srcslot] == NULL ||
			CheckSlotSuitable (dstslot, m_items[srcslot]->GetProto()->InventoryType) == false)
		{
			Make_INVENTORY_CHANGE_FAILURE (&data, EQUIP_ERR_ITEM_DOESNT_GO_TO_SLOT, m_items[srcslot], m_items[dstslot]);
			//GetSession()->SystemMessage("Inventory: (Swap) EQUIP_ERR_ITEM_DOESNT_GO_TO_SLOT");
			GetSession()->SendPacket( &data );
			return false;
		}
	}

	// Check if both items can be equipped in those slots
	//
	if (IS_BODY_SLOT (srcslot) && NOT_BODY_SLOT (dstslot) &&
		m_items[dstslot] != NULL && CanEquipItem (m_items[dstslot]->GetProto()) == false) 
	{
		Make_INVENTORY_CHANGE_FAILURE (&data, EQUIP_ERR_ITEMS_CANT_BE_SWAPPED, m_items[srcslot], m_items[dstslot]);
		//GetSession()->SystemMessage("Inventory: (Swap) EQUIP_ERR_ITEMS_CANT_BE_SWAPPED");
		GetSession()->SendPacket( &data );
		return false;
	}

	if (NOT_BODY_SLOT (srcslot) && IS_BODY_SLOT (dstslot) &&
		m_items[srcslot] != NULL && CanEquipItem (m_items[srcslot]->GetProto()) == false) 
	{
		Make_INVENTORY_CHANGE_FAILURE (&data, EQUIP_ERR_ITEM_CANT_BE_EQUIPPED, m_items[srcslot], m_items[dstslot]);
		//GetSession()->SystemMessage("Inventory: (Swap) EQUIP_ERR_ITEM_CANT_BE_EQUIPPED");
		GetSession()->SendPacket( &data );
		return false;
	}
	
	// Check is not empty bag is moved
	//...........
	//...........
	//...........

	// Swap slots
    Item *temp;
	temp = m_items[srcslot];
	m_items[srcslot] = m_items[dstslot];

	/*
	Item* srcitem = RemoveItemFromSlot(srcslot);
    Item* dstitem = RemoveItemFromSlot(dstslot);
    if (dstitem != NULL) AddItemToSlot(srcslot, dstitem);
    if (srcitem != NULL) AddItemToSlot(dstslot, srcitem);
	*/

	
	if (srcslot < INVENTORY_SLOT_ITEM_END) 
	{
		SetUInt32Value( PLAYER_VISIBLE_ITEM_1_0 + (srcslot * PLAYER_VISIBLE_ITEM_SIZE),
						m_items[srcslot] != NULL? m_items[srcslot]->GetEntry() : 0 );
	}

	m_items[dstslot] = temp;

	if (dstslot < INVENTORY_SLOT_ITEM_END)
	{
		SetUInt32Value( PLAYER_VISIBLE_ITEM_1_0 + (dstslot * PLAYER_VISIBLE_ITEM_SIZE),
						m_items[dstslot] != NULL? m_items[dstslot]->GetEntry() : 0 );
	}
	

	//	APPLY BONUSES TO SWAPPED ITEMS //////////////////////////////////////////
	//
	// Apply item stats when equipping
	if (NOT_BODY_SLOT (srcslot) && IS_BODY_SLOT (dstslot))
	{
		if (m_items[srcslot] != NULL) _ApplyItemMods (m_items[srcslot], false);
		if (m_items[dstslot] != NULL) _ApplyItemMods (m_items[dstslot], true);
	}
	// Remove item bonus when dequipping
	if (NOT_BODY_SLOT (dstslot) && IS_BODY_SLOT (srcslot))
	{
		if (m_items[dstslot] != NULL) _ApplyItemMods (m_items[dstslot], false);
		if (m_items[srcslot] != NULL) _ApplyItemMods (m_items[srcslot], true);
	}

	// Apply item stats when equipping BAG (Bags also have stats)
	if (IS_NOT_BAG_SLOT (srcslot) && IS_BAG_SLOT (dstslot))
	{
		if (m_items[srcslot] != NULL) _ApplyItemMods (m_items[srcslot], false);
		if (m_items[dstslot] != NULL) _ApplyItemMods (m_items[dstslot], true);
	}
	// Remove item bonus when dequipping BAG (Bags also have stats)
	if (IS_NOT_BAG_SLOT (dstslot) && IS_BAG_SLOT (srcslot))
	{
		if (m_items[dstslot] != NULL) _ApplyItemMods (m_items[dstslot], false);
		if (m_items[srcslot] != NULL) _ApplyItemMods (m_items[srcslot], true);
	}
	/////////////////////////////////////////////////////////////////////////////

	// Send update packets
    if ( IsInWorld() )
    {
		Object *o;

		if ( IS_BODY_SLOT (srcslot) && NOT_BODY_SLOT (dstslot) )
        {

			Log::getSingleton().outDebug("ack > INVENTORY: upd > PACKET: SRC-BODY & DST-NOT_BODY");
			//for(ObjectSet::iterator i = GetInRangeSetBegin(); i != GetInRangeSetEnd(); i++)
			for (MapRangeIterator itr (this); o = itr.Advance(); )
            {
                if (o->isPlayer())
                    m_items[dstslot]->DestroyForPlayer( (Player*)o );
            }
			
        }
        else
		if ( NOT_BODY_SLOT (srcslot) && IS_BODY_SLOT (dstslot) )
        {
            UpdateData upd;
            WorldPacket packet;
			Log::getSingleton().outDebug("ack > INVENTORY: upd > PACKET: SRC-NOT_BODY & DST-BODY");
            //for(ObjectSet::iterator i = GetInRangeSetBegin(); i != GetInRangeSetEnd(); i++)
			for (MapRangeIterator itr (this); o = itr.Advance(); )
            {
                if (o->isPlayer())
                {
                    upd.Clear();
                    m_items[dstslot]->BuildCreateUpdateBlockForPlayer( &upd, (Player *)o );
                    upd.BuildPacket( &packet );
                    GetSession()->SendPacket( &packet );
                }
            }
        }
    }


    SetUInt64Value (PLAYER_FIELD_INV_SLOT_HEAD  + (dstslot*2),
		m_items[dstslot] ? m_items[dstslot]->GetGUID() : 0 );

    SetUInt64Value (PLAYER_FIELD_INV_SLOT_HEAD  + (srcslot*2),
		m_items[srcslot] ? m_items[srcslot]->GetGUID() : 0 );
	

	SaveToDB();

	return true;
}

//-----------------------------------------------------------------------------
uint32 Player::GetSlotByItemID(uint32 ID)
{
    for(uint32 i=INVENTORY_SLOT_ITEM_START;i<INVENTORY_SLOT_ITEM_END;i++){
        if(m_items[i] != 0)
            if(m_items[i]->GetProto()->ItemId == ID)
                return i;
    }
    return 0;
}

//-----------------------------------------------------------------------------
uint32 Player::GetSlotByItemGUID(uint64 guid)
{
    for(uint32 i=0;i<INVENTORY_SLOT_ITEM_END;i++){
        if(m_items[i] != 0)
            if(m_items[i]->GetGUID() == guid)
                return i;
    }
    return 0;
}

//-----------------------------------------------------------------------------
bool Player::AddItemToSlot (uint8 slot, uint32 itemId, uint32 count) 
{
	Item * pItem = GetItemBySlot (slot);
	bool result;

	if (pItem == NULL) {

		// Creating Item /////////
		if ( !objmgr.GetItemPrototype(itemId) ) 
		{
			if (GetSession() != NULL)
				sChatHandler.GMMessage(GetSession(), "err > INVENTORY: ERR adding item {%d}, prototype missing !", itemId);
			return false;
		}
		// Creating Item or Container
		CreateObjectItem (itemId, slot, count);
		//////////////////////////

		result = true;

	}
	else
	if (pItem->GetEntry() != itemId) {
		Log::getSingleton( ).outDebug ("err > INVENTORY: Can't add item - slot has another item");
		result = false;
	}
	else
	if (pItem->GetCount() <= pItem->GetProto()->MaxCount - count) {
		pItem->SetCount (pItem->GetCount() + count);
		pItem->SaveToDB();
		SaveToDB();
		AddedItemToBackpack( itemId, count );
		result = true;
	}
	else {
		Log::getSingleton( ).outDebug ("err > INVENTORY: Can't add item - slot is full");
		result = false;
	}

	return result;
}

//-----------------------------------------------------------------------------
void Player::AddItemToSlot(uint8 slot, Item *item)
{
    ASSERT(slot < BANK_SLOT_BAG_END);
    ASSERT(m_items[slot] == NULL);

    if ( IsInWorld() )
    {
        UpdateData upd;
        WorldPacket packet;

        // create for ourselves
        item->BuildCreateUpdateBlockForPlayer( &upd, this );
        upd.BuildPacket( &packet );
        GetSession()->SendPacket( &packet );

        if (IS_BODY_SLOT (slot))
        {
            //for(ObjectSet::iterator i = GetInRangeSetBegin(); i != GetInRangeSetEnd(); i++)
			Object *o;
			for (MapRangeIterator itr (this); o = itr.Advance(); )
            {
                if (o->isPlayer())
                {
                    upd.Clear();
                    item->BuildCreateUpdateBlockForPlayer( &upd, (Player *)o );
                    upd.BuildPacket( &packet );
                    GetSession()->SendPacket( &packet );
                }
            }
        }
    }

	item->SetOwner( this );
	item->PlaceOnMap();

    m_items[slot] = item;
    SetUInt64Value( PLAYER_FIELD_INV_SLOT_HEAD  + (slot * 2),
		m_items[slot] ? m_items[slot]->GetGUID() : 0 );

    if (IS_BODY_SLOT (slot))
	{
        int VisibleBase = PLAYER_VISIBLE_ITEM_1_0 + (slot * PLAYER_VISIBLE_ITEM_SIZE);
       	
		SetUInt32Value (VisibleBase, item->GetEntry());
       	SetUInt32Value (VisibleBase + 1, item->GetUInt32Value(ITEM_FIELD_ENCHANTMENT));
       	SetUInt32Value (VisibleBase + 2, item->GetUInt32Value(ITEM_FIELD_ENCHANTMENT + 3));
       	SetUInt32Value (VisibleBase + 3, item->GetUInt32Value(ITEM_FIELD_ENCHANTMENT + 6));
       	SetUInt32Value (VisibleBase + 4, item->GetUInt32Value(ITEM_FIELD_ENCHANTMENT + 9));
       	SetUInt32Value (VisibleBase + 5, item->GetUInt32Value(ITEM_FIELD_ENCHANTMENT + 12));
       	SetUInt32Value (VisibleBase + 6, item->GetUInt32Value(ITEM_FIELD_ENCHANTMENT + 15));
       	SetUInt32Value (VisibleBase + 7, item->GetUInt32Value(ITEM_FIELD_ENCHANTMENT + 18));
       	SetUInt32Value (VisibleBase + 8, item->GetUInt32Value(ITEM_FIELD_RANDOM_PROPERTIES_ID));
        
		_ApplyItemMods (item, true);
	}
	
	// I do not know if Enchantment applies to bags (if YES, please notify me). Kosuha.
	if (IS_BAG_SLOT (slot))	_ApplyItemMods (item, true);

	if (IS_BACKPACK_SLOT (slot))
		AddedItemToBackpack( item->GetProto()->ItemId , item->GetCount());
	
	item->SaveToDB();
	//SaveToDB();
}

//-----------------------------------------------------------------------------
Item* Player::RemoveItemFromSlot(uint8 slot)
{
    ASSERT(slot < BANK_SLOT_BAG_END);

	if (m_items[slot] == NULL) return NULL;

    Item *item = m_items[slot];
    m_items[slot] = NULL;

	SetUInt64Value( PLAYER_FIELD_INV_SLOT_HEAD  + (slot * 2), 0 );
    
	if (IS_BODY_SLOT (slot) || IS_BAG_SLOT (slot)) {
		SetUInt64Value( PLAYER_VISIBLE_ITEM_1_0 + (slot * PLAYER_VISIBLE_ITEM_SIZE), 0 );
        _ApplyItemMods( item, false );
	}

    item->SetOwner( NULL );

	if ( IsInWorld() )
    {
        item->RemoveFromMap();

        // create for ourselves
        item->DestroyForPlayer( this );

        if (IS_BODY_SLOT (slot))
        {
            //for(ObjectSet::iterator i = GetInRangeSetBegin(); i != GetInRangeSetEnd(); i++)
			Object *o;
			for (MapRangeIterator itr (this); o = itr.Advance(); )
            {
                if (o->isPlayer())
                    item->DestroyForPlayer ((Player *)o);
            }
        }
    }

	if (IS_BACKPACK_SLOT (slot))
		RemovedItemToBackpack( item->GetProto()->ItemId );

	//item->SaveToDB();
	SaveToDB();

	return item;
}

// ----------------------------------------------------------------------------
bool Player::RemoveItemFromBackpack (uint32 itemId, uint32 count)
{
	Item * pItem;

	for (uint8 i = INVENTORY_SLOT_ITEM_START; i < INVENTORY_SLOT_ITEM_END; i++)
	{
		pItem = GetItemBySlot(i);
		if (pItem == NULL) continue;

		if (pItem->GetProto()->ItemId == itemId)
		{
			if ( count >= pItem->GetCount() )
			{
				count -= pItem->GetCount();
				RemoveItemFromSlot(i);
			}
			else
			{
				pItem->SetCount( pItem->GetCount() - count );
				pItem->SaveToDB();
				count = 0;
			}
		}
	}

	SaveToDB();
	
	RemovedItemToBackpack( itemId );

	return ( count == 0 );
}

// ----------------------------------------------------------------------------
bool Player::HasItemInBackpack (uint32 itemId, uint32 count)
{
	Item * pItem;

	if ( itemId == 0 ) return true;

	// 1. Try to find if item is present in backpack
	for (uint8 i = INVENTORY_SLOT_ITEM_START; i < INVENTORY_SLOT_ITEM_END; i++)
	{
		pItem = GetItemBySlot(i);
		
		// -- ignore empty slots
		if (pItem == NULL) continue;

		if (pItem->GetProto()->ItemId == itemId)
		{
			if ( count > pItem->GetCount() )
				count -= pItem->GetCount(); else
                return true;
		}
	}

	return false;
}

//-----------------------------------------------------------------------------
bool Player::HasSpaceForItemInBackpack(uint32 itemId, uint32 count)
{
	uint8	playerslot = 0;
	Item * pItem;

	// Find free slot and break if inv full
	//
	// 1. Try to find similar slot for stackable items
	for (uint8 i = INVENTORY_SLOT_ITEM_START; i < INVENTORY_SLOT_ITEM_END; i++)
	{
		pItem = GetItemBySlot(i);
		
		// not this time we look for empty slot
		if (pItem == NULL) continue;

		if (pItem->GetProto()->ItemId == itemId && pItem->GetCount() < pItem->GetProto()->MaxCount)
		{
			playerslot = i;
			break;
		}
	}

	if (playerslot != 0) 
	{
		int addCount = count;
		if (pItem->GetCount() + count > pItem->GetProto()->MaxCount)
			addCount = pItem->GetProto()->MaxCount - pItem->GetCount();
		
		pItem->SetCount (pItem->GetCount() + addCount);

		count -= addCount;
		if (count) 
		{
			if (AddItemToBackpack (itemId, count)) 
			{
				pItem->SetCount (pItem->GetCount() - addCount);
				return true;
			}
			
			pItem->SetCount (pItem->GetCount() - addCount);
			return false;
		}

		pItem->SetCount (pItem->GetCount() - addCount);
		return true;
	}

	// 2. Try to find empty slot
	//
	playerslot = 0;

	// First search through backpack, then through bags
	for (uint8 i = INVENTORY_SLOT_ITEM_START; i < INVENTORY_SLOT_ITEM_END; i++) 
	{
		pItem = GetItemBySlot(i);
		if (pItem == NULL)
		{
			playerslot = i;
			break;
		}
	}

	if (playerslot == 0) 
		return false;

	return true;
}

//-----------------------------------------------------------------------------
bool Player::AddItemToBackpack(uint32 itemId, uint32 count)
{
	uint8	playerslot = 0;
	uint8   count_taken_slot = INVENTORY_SLOT_ITEM_START;
	Item*	pItem;

	// Find free slot and break if inv full
	//
	// 1. Try to find similar slot for stackable items
	for (uint8 i = INVENTORY_SLOT_ITEM_START; i < INVENTORY_SLOT_ITEM_END; i++)
	{
		pItem = GetItemBySlot(i);
		
		// not this time we look for empty slot
		if (pItem == NULL) continue;

		if (pItem->GetProto()->ItemId == itemId && pItem->GetCount() < pItem->GetProto()->MaxCount)
		{
			playerslot = i;
			break;
		}
	count_taken_slot++;
	}

	Log::getSingleton( ).outDebug ("ack > BAGPACK: Slots taken in Bagpack: %d", count_taken_slot);
	
	// If BagPack is Full issue Error and return FALSE
	if (count_taken_slot >= INVENTORY_SLOT_ITEM_END) {
		WorldPacket	data;
		Make_INVENTORY_CHANGE_FAILURE (&data, EQUIP_ERR_BAG_FULL, 0, 0);
		GetSession()->SendPacket( &data );
		return false;
	}
	//////////////////////////////////////////////////

	if (playerslot != 0) {
		int addCount = count;
		if (pItem->GetCount() + count > pItem->GetProto()->MaxCount)
			addCount = pItem->GetProto()->MaxCount - pItem->GetCount();

		pItem->SetCount (pItem->GetCount() + addCount);
		pItem->SaveToDB();

		count -= addCount;

		if (count) {
			if (AddItemToBackpack (itemId, count)) return true;
			
			// Restore old backpack state
			pItem->SetCount (pItem->GetCount() - addCount);
			pItem->SaveToDB();
			return false;
		}

		SaveToDB();

		AddedItemToBackpack( itemId, addCount );
		return true;
	}

	// 2. Try to find empty slot
	//
	playerslot = 0;

	// First search through backpack, then through bags
	for (uint8 i = INVENTORY_SLOT_ITEM_START; i < INVENTORY_SLOT_ITEM_END; i++) 
	{
		pItem = GetItemBySlot(i);
		if (pItem == NULL)
		{
			playerslot = i;
			break;
		}
	}

	if (playerslot == 0) 
		return false;
	
	// Create item ///////////
	if ( !objmgr.GetItemPrototype(itemId) )
	{
		sChatHandler.GMMessage(GetSession(), "err > INVENTORY: Error adding item {%d}, prototype missing !", itemId);
		return false;
	}

	// Creating Item or Container
	CreateObjectItem (itemId, playerslot, count);
    //////////////////////////

	SaveToDB();

	return true;
}

//-----------------------------------------------------------------------------
void Player::AddToWorld()
{
    Object::AddToWorld();

    for(int i = 0; i < BANK_SLOT_BAG_END; i++)
    {
        if(m_items[i])
            m_items[i]->AddToWorld();
    }
}

//-----------------------------------------------------------------------------
void Player::RemoveFromWorld()
{
    for(int i = 0; i < BANK_SLOT_BAG_END; i++)
    {
        if(m_items[i])
            m_items[i]->RemoveFromWorld();
    }

    Object::RemoveFromWorld();
}

//-----------------------------------------------------------------------------
// TODO: perhaps item should just have a list of mods, that will simplify code
void Player::_ApplyItemMods(Item *item, bool apply)
{
    ASSERT(item);
    ItemPrototype *proto = item->GetProto();

	if (apply) {
		Log::getSingleton().outString("applying mods for item %X entry=%d", item->GetGUIDLow(), item->GetEntry());
	} else {
		Log::getSingleton().outString("removing mods for item %X entry=%d", item->GetGUIDLow(), item->GetEntry());
	}

	//----------------------------------------------
    // Calculate armor and resistances bonus
	//----------------------------------------------
	if (proto->Armor)		ModifyArmor (apply ? (int)proto->Armor : -(int)proto->Armor);
	if (proto->HolyRes)		ModifyHolyResist (apply ? (int)proto->HolyRes : -(int)proto->HolyRes);
    if (proto->FireRes)		ModifyFireResist (apply ? (int)proto->FireRes : -(int)proto->FireRes);
    if (proto->NatureRes)	ModifyNatureResist (apply ? (int)proto->NatureRes : -(int)proto->NatureRes);    
	if (proto->FrostRes)	ModifyFrostResist (apply ? (int)proto->FrostRes : -(int)proto->FrostRes);
    if (proto->ShadowRes)	ModifyShadowResist (apply ? (int)proto->ShadowRes : -(int)proto->ShadowRes);
	if (proto->ArcaneRes)	ModifyArcaneResist (apply ? (int)proto->ArcaneRes : -(int)proto->ArcaneRes);

	//----------------------------------------------
	// Modify stats
	//----------------------------------------------
	int32 v;

	for (int i = 0; i < 10; i++)
	{
		v = proto->ItemStatValue[i];

		switch (proto->ItemStatType[i])
		{
		case 3:	
			ModifyAgility (apply ? v : -v);
			if (v > 0) ModifyPosAgility (apply ? v : -v); else ModifyNegAgility (apply ? -v : v);
			break;
		case 4:
			ModifyStrength (apply ? v : -v);
			if (v > 0) ModifyPosStrength (apply ? v : -v); else ModifyNegStrength (apply ? -v : v);
			break;
		case 5:
			ModifyIntellect (apply ? v : -v);
			if (v > 0) ModifyPosIntellect (apply ? v : -v); else ModifyNegIntellect (apply ? -v : v);
			break;
		case 6:
			ModifySpirit (apply ? v : -v);
			if (v > 0) ModifyPosSpirit (apply ? v : -v); else ModifyNegSpirit (apply ? -v : v);
			break;
		case 7:
			ModifyStamina (apply ? v : -v);
			if (v > 0) ModifyPosStamina (apply ? v : -v); else ModifyNegStamina (apply ? -v : v);
			break;
		}
	}

	v = proto->Armor;
	if (v) ModifyArmor (apply ? v : -v);
	
	//----------------------------------------------
	// Calculate damage bonuses of all types
	//----------------------------------------------
	// Calculate visible damage
	for (int i = 0; i < 5; i++) {
		float mindmg = proto->DamageMin[i];
		float maxdmg = proto->DamageMax[i];

		if (mindmg) ModifyMinDamage (apply ? mindmg : -mindmg);
		if (maxdmg) ModifyMaxDamage (apply ? maxdmg : -maxdmg);

		if (mindmg >= 0 && maxdmg > 0)
		{
			if (apply)
				Log::getSingleton().outString("Adding %.1f..%.1f damage type %d - result %.1f..%.1f",
					mindmg, maxdmg, i, GetMinDamage(), GetMaxDamage());
			else
				Log::getSingleton().outString("Removing %.1f..%.1f damage type %d - result %.1f..%.1f",
					mindmg, maxdmg, i, GetMinDamage(), GetMaxDamage());
		}
	}
	
	// Modify Base & Ranged Attack Times
	if (proto->Delay && proto->InventoryType != INVTYPE_RANGED) {
		if (apply) {SetBaseAttackTime1 (proto->Delay); SetBaseAttackTime2 (proto->Delay);}
		else {SetBaseAttackTime1 (2000); SetBaseAttackTime2 (2000);}
		//SetUInt32Value(UNIT_FIELD_BASEATTACKTIME, apply ? proto->Delay : 2000);
		//SetUInt32Value(UNIT_FIELD_BASEATTACKTIME + 1, apply ? proto->Delay : 2000);
	}
	if (proto->Delay && proto->InventoryType == INVTYPE_RANGED) {
		if (apply) SetRangedAttackTime (proto->Delay);
		else SetRangedAttackTime (2000);
		//SetUInt32Value(UNIT_FIELD_RANGEDATTACKTIME, apply ? proto->Delay : 2000);
	}
	
	// Modify Block Value (Shileds,...)
	if (proto->Block) ModifyBlockValue (proto->Block);

}

//-----------------------------------------------------------------------------
void Player::_RemoveAllItemMods()
{
    for (int i = 0; IS_BODY_SLOT (i); i++)
    {
        if(m_items[i])
            _ApplyItemMods(m_items[i], false);
    }
}

//-----------------------------------------------------------------------------
void Player::_ApplyAllItemMods()
{
    for (int i = 0; IS_BODY_SLOT (i); i++)
    {
        if(m_items[i])
            _ApplyItemMods(m_items[i], true);
    }
}

//-----------------------------------------------------------------------------
void Player::SetMovement(uint8 pType)
{
    WorldPacket data;

    switch(pType)
    {
    case MOVE_ROOT:
        {
            data.Initialize(SMSG_FORCE_MOVE_ROOT);
            data << GetGUID();
            GetSession()->SendPacket( &data );
        }break;
    case MOVE_UNROOT:
        {
            data.Initialize(SMSG_FORCE_MOVE_UNROOT);
            data << GetGUID();
            GetSession()->SendPacket( &data );
        }break;
    case MOVE_WATER_WALK:
        {
            data.Initialize(SMSG_MOVE_WATER_WALK);
            data << GetGUID();
            GetSession()->SendPacket( &data );
        }break;
    case MOVE_LAND_WALK:
        {
            data.Initialize(SMSG_MOVE_LAND_WALK);
            data << GetUInt32Value( OBJECT_FIELD_GUID );
            GetSession()->SendPacket( &data );
        }break;
    default:break;
    }
}

//-----------------------------------------------------------------------------
void Player::SetPlayerSpeed(uint8 SpeedType, float value, bool forced)
{
     WorldPacket data;

     switch(SpeedType)
     {
     case RUN:
         {
             if(forced) { data.Initialize(SMSG_FORCE_RUN_SPEED_CHANGE); }
             else { data.Initialize(MSG_MOVE_SET_RUN_SPEED); }
             data << GetGUID();
             data << float(value);
             GetSession()->SendPacket( &data );
         }break;
     case RUNBACK:
         {
             if(forced) { data.Initialize(SMSG_FORCE_RUN_BACK_SPEED_CHANGE); }
             else { data.Initialize(MSG_MOVE_SET_RUN_BACK_SPEED); }
             data << GetGUID();
             data << float(value);
             GetSession()->SendPacket( &data );
         }break;
     case SWIM:
         {
             if(forced) { data.Initialize(SMSG_FORCE_SWIM_SPEED_CHANGE); }
             else { data.Initialize(MSG_MOVE_SET_SWIM_SPEED); }
             data << GetGUID();
             data << float(value);
             GetSession()->SendPacket( &data );
         }break;
     case SWIMBACK:
         {
             data.Initialize(MSG_MOVE_SET_SWIM_BACK_SPEED);
             data << GetGUID();
             data << float(value);
             GetSession()->SendPacket( &data );
         }break;
     default:break;
     }
}

//-----------------------------------------------------------------------------
void Player::BuildPlayerRepop()
{
    WorldPacket data;
    //1.1.1
    SetUInt32Value( UNIT_FIELD_HEALTH, 1 );

    SetMovement(MOVE_UNROOT);
    SetMovement(MOVE_WATER_WALK);

	if (GetRace() == RACE_NIGHT_ELF)
			SetSpeedMod (1.5f);
	else	SetSpeedMod (1.133f);
    //SetPlayerSpeed(RUN, (float)8.5, true);
    //SetPlayerSpeed(SWIM, (float)5.9, true);

    data.Initialize (SMSG_CORPSE_RECLAIM_DELAY);
    data << uint8(0x30) << uint8(0x75) << uint8(0x00) << uint8(0x00);
    GetSession()->SendPacket( &data );

    data.Initialize (SMSG_SPELL_START);
    data << GetGUID() << GetGUID() << uint32(8326);
    data << uint16(0) << uint32(0) << uint16(0x02) << uint32(0) << uint32(0);
    GetSession()->SendPacket( &data );

    data.Initialize (SMSG_UPDATE_AURA_DURATION);
    data << uint8(32);
    data << uint32(0);
    GetSession()->SendPacket( &data );

    data.Initialize (SMSG_CAST_RESULT);
    data << uint32(8326);
    data << uint8(0x00);
    GetSession()->SendPacket( &data );

    data.Initialize (SMSG_SPELL_GO);
    data << GetGUID() << GetGUID() << uint32(8326);
    data << uint16(01) << uint8(0) << uint8(0);
    data << uint16(0040); // ?? why 0040? 0x40?
    data << GetPositionX();
    data << GetPositionY();
    data << GetPositionZ();
    GetSession()->SendPacket( &data );

    data.Initialize (SMSG_SPELLLOGEXECUTE);
    data << (uint32)GetGUID() << (uint32)GetGUID();
    data << uint32(8326);
    data << uint32(1);
    data << uint32(0x24);
    data << uint32(1);
    data << GetGUID();
    GetSession()->SendPacket( &data );

	//----------------
    data.Initialize (SMSG_STOP_MIRROR_TIMER);
    data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
    GetSession()->SendPacket( &data );

    data.Initialize (SMSG_STOP_MIRROR_TIMER);
    data << uint8(0x01) << uint8(0x00) << uint8(0x00) << uint8(0x00);
    GetSession()->SendPacket( &data );

    data.Initialize(SMSG_STOP_MIRROR_TIMER);
    data << uint8(0x02) << uint8(0x00) << uint8(0x00) << uint8(0x00);
    GetSession()->SendPacket( &data );

	// Cast Ghost aura on player
    SetUInt32Value(CONTAINER_FIELD_SLOT_1+29, 8326);
    SetUInt32Value(UNIT_FIELD_AURA+32, 8326);
    SetUInt32Value(UNIT_FIELD_AURALEVELS+8, 0xeeeeee00);
    SetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS+8, 0xeeeeee00);
    SetUInt32Value(UNIT_FIELD_AURAFLAGS+4, 12);
    SetUInt32Value(UNIT_FIELD_AURASTATE, 2);

    SetFlag(PLAYER_FLAGS, PLAYER_FLAG_DEAD);

    //spawn Corpse
    SpawnCorpseBody();
}

//-----------------------------------------------------------------------------
void Player::ResurrectPlayer()
{
	SetMovement (MOVE_LAND_WALK);
	//SetPlayerSpeed (RUN, 7.5f, true);
	//SetPlayerSpeed (SWIM, 4.9f, true);
	SetSpeedMod (1.0f);

	SetUInt32Value (CONTAINER_FIELD_SLOT_1+29, 0);
	SetUInt32Value (UNIT_FIELD_AURA+32, 0);
	SetUInt32Value (UNIT_FIELD_AURALEVELS+8, 0xEEEEEEEE);
	SetUInt32Value (UNIT_FIELD_AURAAPPLICATIONS+8, 0xEEEEEEEE);
	SetUInt32Value (UNIT_FIELD_AURAFLAGS+4, 0);
	SetUInt32Value (UNIT_FIELD_AURASTATE, 0);

	SetUInt32Value (UNIT_FIELD_FLAGS, (0xFFFFFFFF - 65536) & GetUInt32Value (UNIT_FIELD_FLAGS));
	SetUInt32Value (PLAYER_BYTES_2, (0xFFFFFFFF - 0x10) & GetUInt32Value (PLAYER_BYTES_2));

	SetHealth ((uint32)(GetMaxHealth() / 2));
	SpawnCorpseBones();

    RemoveFlag (PLAYER_FLAGS, PLAYER_FLAG_DEAD);
	ClearHate(); // some fix to get out of battle after rez
    setDeathState(ALIVE); 


	// Here we want to hide all spirit healers and dead people, showing living objects instead
	//
	ObjectSet::iterator itr;
	UpdateData updata;
	WorldPacket pkt;

	/*for (itr = m_objectsInRange.begin(); itr != m_objectsInRange.end(); ++itr)
	{
		Object *o = *itr;
		ASSERT (o);
		//o->BuildCreateUpdateBlockForPlayer (&updata, this);
		if (o->isUnit() || o->isPlayer()) {
			o->BuildOutOfRangeUpdateBlock (&updata);
		}
	}*/

	BuildCreateUpdateBlockForPlayer (&updata, this);
	updata.BuildPacket (&pkt);
	GetSession()->SendPacket (&pkt);

	RemoveFromMap();
	PlaceOnMap();
}

//-----------------------------------------------------------------------------
void Player::KillPlayer()
{
    WorldPacket data;

	SetMovement(MOVE_ROOT);

    data.Initialize(SMSG_STOP_MIRROR_TIMER);
    data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
    GetSession()->SendPacket( &data );

    data.Initialize(SMSG_STOP_MIRROR_TIMER);
    data << uint8(0x01) << uint8(0x00) << uint8(0x00) << uint8(0x00);
    GetSession()->SendPacket( &data );

    data.Initialize(SMSG_STOP_MIRROR_TIMER);
    data << uint8(0x02) << uint8(0x00) << uint8(0x00) << uint8(0x00);
    GetSession()->SendPacket( &data );

    setDeathState(CORPSE);
    SetFlag( UNIT_FIELD_FLAGS, 0x08 ); //player death animation, also can be used with DYNAMIC_FLAGS
    SetFlag( UNIT_DYNAMIC_FLAGS, 0x00 );
    CreateCorpse();
}

//-----------------------------------------------------------------------------
void Player::CreateCorpse()
{
    Corpse *pCorpse;
    uint32 _uf, _pb, _pb2, _cfb1, _cfb2;

    pCorpse = objmgr.GetCorpseByOwner(this);
    if(!pCorpse)
    {
        pCorpse = new Corpse();
        pCorpse->Create(objmgr.GenerateLowGuid(HIGHGUID_CORPSE), this, GetMapId(), GetPositionX(),
            GetPositionY(), GetPositionZ(), GetOrientation());

        _uf = GetUInt32Value(UNIT_FIELD_BYTES_0);
        _pb = GetUInt32Value(PLAYER_BYTES);
        _pb2 = GetUInt32Value(PLAYER_BYTES_2);

        uint8 race       = (uint8)(_uf);
        uint8 skin       = (uint8)(_pb);
        uint8 face       = (uint8)(_pb >> 8);
        uint8 hairstyle  = (uint8)(_pb >> 16);
        uint8 haircolor  = (uint8)(_pb >> 24);
        uint8 facialhair = (uint8)(_pb2);

        _cfb1 = ((0x00) | (race << 8) | (0x00 << 16) | (skin << 24));
        _cfb2 = ((face) | (hairstyle << 8) | (haircolor << 16) | (facialhair << 24));

        pCorpse->SetZoneId( GetZoneId() );
        pCorpse->SetUInt32Value( CORPSE_FIELD_BYTES_1, _cfb1 );
        pCorpse->SetUInt32Value( CORPSE_FIELD_BYTES_2, _cfb2 );
        pCorpse->SetUInt32Value( CORPSE_FIELD_FLAGS, 4 );
        pCorpse->SetUInt32Value( CORPSE_FIELD_DISPLAY_ID, GetUInt32Value(UNIT_FIELD_DISPLAYID) );

        uint32 iDisplayID;
        uint16 iIventoryType;
        uint32 _cfi;
        for (int i = 0; IS_BODY_SLOT (i); i++)
        {
            if(m_items[i])
            {
                iDisplayID = m_items[i]->GetProto()->DisplayInfoID;
                iIventoryType = (uint16)m_items[i]->GetProto()->InventoryType;

                _cfi =  (uint16(iDisplayID)) | (iIventoryType)<< 24;
                pCorpse->SetUInt32Value(CORPSE_FIELD_ITEM + i,_cfi);
            }
        }
        //save corpse in db for future use
        pCorpse->SaveToDB();
        objmgr.AddObject(pCorpse);
    }
    else //Corpse already exist in world, update it
    {
        pCorpse->SetPosition(GetPositionX(), GetPositionY(), GetPositionZ(), GetOrientation());
    }
}

//-----------------------------------------------------------------------------
void Player::SpawnCorpseBody()
{
    Corpse *pCorpse;

    pCorpse = objmgr.GetCorpseByOwner(this);
    if(pCorpse && !pCorpse->IsInWorld())
        pCorpse->PlaceOnMap();
}

//-----------------------------------------------------------------------------
void Player::SpawnCorpseBones()
{
    Corpse *pCorpse;
    pCorpse = objmgr.GetCorpseByOwner(this);
    if(pCorpse)
    {
        pCorpse->SetUInt32Value(CORPSE_FIELD_FLAGS, 5);
        pCorpse->SetUInt64Value(CORPSE_FIELD_OWNER, 0); // remove corpse owner association
        //remove item association
        for (int i = 0; IS_BODY_SLOT (i); i++)
        {
            if(pCorpse->GetUInt32Value(CORPSE_FIELD_ITEM + i))
                pCorpse->SetUInt32Value(CORPSE_FIELD_ITEM + i, 0);
        }
        pCorpse->DeleteFromDB();
    }
}

//-----------------------------------------------------------------------------
void Player::DeathDurabilityLoss(double percent)
{
    uint32 pDurability, pNewDurability;

    for (int i = 0; IS_BODY_SLOT (i); i++)
    {
        if(m_items[i])
        {
            pDurability =  m_items[i]->GetUInt32Value(ITEM_FIELD_DURABILITY);
            if(pDurability)
            {
                pNewDurability = (uint32)(pDurability * percent);
                pNewDurability = (pDurability - pNewDurability);
                if(pNewDurability < 0) { pNewDurability = 0; }

                m_items[i]->SetUInt32Value(ITEM_FIELD_DURABILITY, pNewDurability);
            }
        }
    }
}

//-----------------------------------------------------------------------------
void Player::RepopAtGraveyard()
{
	//PlayerCreateInfo *info = objmgr.GetPlayerCreateInfo (GetRace(), GetClass());
	
	float   closestX = m_bindPointX,
			closestY = m_bindPointY,
			closestZ = m_bindPointZ,
			closestO = 0;

    float curX, curY, curZ;
    bool first = true;

    ObjectMgr::GraveyardMap::const_iterator itr;
    for (itr = objmgr.GetGraveyardListBegin(); itr != objmgr.GetGraveyardListEnd(); itr++)
    {
        GraveyardTeleport *pGrave = itr->second;
        if(objmgr.LookupZoneId (pGrave->MapId, pGrave->X, pGrave->Y) == GetZoneId())
        {
            curX = pGrave->X;
            curY = pGrave->Y;
            curZ = pGrave->Z;
            
			if (pow (m_positionX - curX, 2) + pow (m_positionY - curY, 2) < 
				pow (m_positionX - closestX, 2) + pow (m_positionY - closestY, 2) )
            {
                first = false;

                closestX = curX;
                closestY = curY;
                closestZ = curZ;
                closestO = GetOrientation(); //pGrave->O;
            }
        }
    }

    if (first == false)
	{
        // SetPosition (closestX, closestY, closestZ, closestO, true);
		//TeleportNear (closestX, closestY, closestZ);
		Log::getSingleton( ).outDebug ("Teleporting ghost to coord (%.1f, %.1f, %.1f)",
			closestX, closestY, closestZ);
		TeleportFar (GetMapId(), closestX, closestY, closestZ);
	} else {
		// do nothing for now;
		// No graveyard found for current MapId - Sorry man, hearth home
		//if (m_bindPointMap == GetMapId())
		//	TeleportNear (m_bindPointX, m_bindPointY, m_bindPointZ);
		Log::getSingleton( ).outDebug ("Teleporting ghost to mapid %d, coord (%.1f, %.1f, %.1f)",
			m_bindPointMap, m_bindPointX, m_bindPointY, m_bindPointZ);
		TeleportFar (m_bindPointMap, m_bindPointX, m_bindPointY, m_bindPointZ);
	}

	// Hide living and show dead people
	RemoveFromMap();
	PlaceOnMap();

	// Here we want to hide everything around and reveal spirit healers and dead people
	//
	/*ObjectSet::iterator itr;
	UpdateData updata;

	for (itr = m_objectsInRange.begin(); itr != m_objectsInRange.end(); ++itr)
	{
		Object *o = *itr;
		ASSERT (o);
		//o->BuildCreateUpdateBlockForPlayer (&updata, this);
		if (o->isUnit() || o->isPlayer()) {
			o->BuildOutOfRangeUpdateBlock (&updata);
		}
	}

	if (updata.HasData()) {
		WorldPacket pkt;
		updata.BuildPacket (&pkt);
		GetSession()->SendPacket (&pkt);
	}*/
}

//-----------------------------------------------------------------------------
void Player::JoinedChannel(Channel *c)
{
	m_channels.push_back(c);
}

//-----------------------------------------------------------------------------
void Player::LeftChannel(Channel *c)
{
	m_channels.remove(c);
}

//-----------------------------------------------------------------------------
void Player::CleanupChannels()
{
	list<Channel *>::iterator i;
	for(i = m_channels.begin(); i != m_channels.end(); i++)
		(*i)->Leave(this,false);
}

//-----------------------------------------------------------------------------
void Player::HideFromPlayers()
{
	//ObjectSet::iterator itr;
	//for (itr = m_objectsInRange.begin(); itr != m_objectsInRange.end(); ++itr)
	Object *o;
	for (MapRangeIterator itr (this); o = itr.Advance(); )
	{
		if (o->isPlayer() && (Player *)o != this)
			DestroyForPlayer ((Player *)o);
	}
}

//-----------------------------------------------------------------------------
void Player::SetVendorBuybackSlot (Item *i, uint64 npcGuid)
{

/* something was changed in 1.8.0. No PLAYER_FIELD_BUYBACK_NPC in 180.
	m_vendorBuybackSlot = i;
	if (i != NULL) {
		SetUInt64Value (PLAYER_FIELD_VENDORBUYBACK_SLOT, i->GetGUID());
		SetUInt64Value (PLAYER_FIELD_BUYBACK_NPC, npcGuid);
		SetUInt32Value (PLAYER_FIELD_BUYBACK_ITEM_ID, i->GetEntry());
		SetUInt32Value (PLAYER_FIELD_BUYBACK_RANDOM_PROPERTIES_ID, 0);
		SetUInt32Value (PLAYER_FIELD_BUYBACK_SEED, 0);
		SetUInt32Value (PLAYER_FIELD_BUYBACK_PRICE, i->GetProto()->SellPrice * i->GetCount());
		SetUInt32Value (PLAYER_FIELD_BUYBACK_DURABILITY, i->GetProto()->MaxDurability);
		SetUInt32Value (PLAYER_FIELD_BUYBACK_COUNT, i->GetCount());
	} else {
		SetUInt64Value (PLAYER_FIELD_VENDORBUYBACK_SLOT, 0);
		SetUInt64Value (PLAYER_FIELD_BUYBACK_NPC, 0);
		SetUInt32Value (PLAYER_FIELD_BUYBACK_ITEM_ID, 0);
		SetUInt32Value (PLAYER_FIELD_BUYBACK_COUNT, 0);
	}
*/
}

//-----------------------------------------------------------------------------
void Player::TeleportNear (float x, float y, float z)
{
	WorldPacket data;

	// Output new position to the console
	Log::getSingleton( ).outDetail( "Player: TeleportNear to (%f, %f, %f)", x, y, z );

	// Send new position to client via MSG_MOVE_TELEPORT_ACK
	BuildTeleportAckMsg (&data, x, y, z, 0);
	GetSession()->SendPacket (&data);

	// Set actual position and update in-range lists
	RemoveFromMap();
	SetPosition (x, y, z, 0);
	PlaceOnMap();

	//////////////////////////////////
	// Now send new position of this player to clients using MSG_MOVE_HEARTBEAT
	BuildHeartBeatMsg (&data);
	SendMessageToSet (&data, true);
	//GetSession()->SystemMessage ("You have been moved to (%f, %f, %f)")
}

//-----------------------------------------------------------------------------
void Player::TeleportFar (uint32 mapId, float x, float y, float z)
{
	if (GetMapId() == mapId) {
		TeleportNear (x, y, z);
		return;
	}

	WorldPacket data;

	// Output new position to the console
	Log::getSingleton( ).outDetail( "Player: TeleportFar to (%d, %f, %f, %f)", mapId, x, y, z );

	// Packet #1 - SMSG_TRANSFER_PENDING
	//
	data.Initialize (SMSG_TRANSFER_PENDING);
	data << uint32(0);
	GetSession()->SendPacket(&data);

	RemoveFromMap();

	// Packet #2 - SMSG_NEW_WORLD
	//
	data.Initialize (SMSG_NEW_WORLD);
	data << (uint32)mapId << (float)x << (float)y << (float)z << (float)0.0f;
	GetSession()->SendPacket( &data );

	// TODO: clear attack list

	SetMapId (mapId);
	PlaceOnMap();
	SetPosition (x, y, z, 0);
}

//-----------------------------------------------------------------------------
void Player::CheckAggressiveMobsAround ()
{
	//ObjectSet::iterator itr;
	bool	gotHelp = false;
	uint8	myLevel = GetLevel();

	//for (itr = GetInRangeSetBegin(); itr != GetInRangeSetEnd(); itr++)
	Object *o;
	for (MapRangeIterator itr (this); o = itr.Advance(); )
	{
		ASSERT (o != NULL);
		//Creature * cr = dynamic_cast<Creature *>(*itr);

		if (o->isUnit())
		//if (cr != NULL)
		{
			Creature * cr = (Creature *)o;
			if (! cr->CanSee (this)) continue;

			// We won't worry our combating enemies. Only idle enemies will get aggro.
			if (cr->isInCombat()) continue;

			// TODO: Add here ignoring invisible player for mob or
			//		 triggering some script reaction

			// ignore self
			if ((Object *)this == (Object *)cr) continue;

			uint8	mobLevel = cr->GetLevel();
			float	aggroRadius = myLevel < mobLevel?
										min(18.0f, 12.0f + mobLevel - myLevel):
										max(3.0f, 12.0f + mobLevel - myLevel);
			float	distSq = GetDistanceSq (cr);

			// Check if helpful family member can hear me
			if (distSq > aggroRadius * aggroRadius) continue;

			// Check faction templates if creature is able to attack me
			// Even some hostiles
			//if (! CanFightMe (cr)) continue;
			if (! isHostileToMe (cr)) continue;

			// And finally add hate
			/*Log::getSingleton().outDebug ("AI: Player %X touched aggro radius of %X",
				GetGUIDLow(), cr->GetGUIDLow());*/

			cr->AddHate ((Unit *)this, 1.0f);
		}
	}
}

//-----------------------------------------------------------------------------
void Player::OnEnterCombat()
{
	Unit::OnEnterCombat();
	// TODO: Send in combat flag
	smsg_AttackStart (GetMostHated());
	SetFlag (UNIT_FIELD_FLAGS, 0x80000);
}

//-----------------------------------------------------------------------------
void Player::OnExitCombat()
{
	//Unit::OnExitCombat();
	// TODO: Clear in combat flag
	smsg_AttackStop (GetSelection());
	RemoveFlag (UNIT_FIELD_FLAGS, 0x80000);
}

//-----------------------------------------------------------------------------
void Player::SetSpeedMod (float value)
{
	WorldPacket data;
	float runvalue, runbackvalue, swimvalue;
	m_speedMod = value;

	data.Initialize (SMSG_FORCE_RUN_SPEED_CHANGE);
	data << GetGUID();
	data << (runvalue = value * UNIT_NORMAL_RUN_SPEED);
	SendMessageToSet (&data, true);

	data.Initialize (SMSG_FORCE_RUN_BACK_SPEED_CHANGE);
	data << GetGUID();
	data << (runbackvalue = value * UNIT_NORMAL_RUN_BACK_SPEED);
	SendMessageToSet (&data, true);

	data.Initialize (SMSG_FORCE_SWIM_SPEED_CHANGE);
	data << GetGUID();
	data << (swimvalue = value * UNIT_NORMAL_SWIM_SPEED);
	SendMessageToSet (&data, true);

	Log::getSingleton().outDebug ("Changed player speed to %.1f units/sec (run %.1f, run back %.1f, swim %.1f)",
		value, runvalue, runbackvalue, swimvalue);
}
//---------------------
// SetLevel for Player (inherited from Unit::SetLevel)
//---------------------
void Player::SetLevel (uint32 value)
{ 
	//uint8	cls = GetClass();
	//PlayerCreateInfo *info = objmgr.GetPlayerCreateInfo (GetRace(), cls);
	//if (info == NULL) return;
	
	uint32 oldLevel = GetUInt32Value (UNIT_FIELD_LEVEL);

	Unit::SetLevel (value); // Call to Main SetLevel() in Unit.cpp

	_RecalculatePlayerStats();

	// ADDING TALLENT POINTS IS LVL > 9, IF NEW LEVEL IS LESS THAN OLD NO TALENTS ARE ADDED
	if(value > 9 && oldLevel < value)
    {
		// Give Talent Point
		uint32 curTalentPoints = GetUInt32Value(PLAYER_CHARACTER_POINTS1);
		uint32 newTalentPoints;
		if (oldLevel < 9) {
			newTalentPoints = curTalentPoints + (value - oldLevel)-(9-oldLevel);
		}
		else {
			newTalentPoints = curTalentPoints + (value - oldLevel);
		}
		SetUInt32Value(PLAYER_CHARACTER_POINTS1, newTalentPoints);
		GetSession()->SystemMessage("You have gained %d talent point.", newTalentPoints - curTalentPoints);
	}
	
	// Restore Health/Mana to their Maximum
	if (GetHealth() < GetMaxHealth()) SetHealth (GetMaxHealth());
	if (GetMana() < GetMaxMana()) SetMana (GetMaxMana());

};

//-----------------------------------------------------------------------------
bool Player::CanUseItem (ItemPrototype * proto)
{
	uint32 reqSpell		= proto->RequiredSpell;
	uint32 reqSkill		= proto->RequiredSkill;
	uint32 reqSkillRank = proto->RequiredSkillRank;
	uint8  error_code	= EQUIP_ERR_OK;

	// Check if Required Level is satisfied
	if (GetLevel() < proto->RequiredLevel) error_code = EQUIP_ERR_YOU_MUST_REACH_LEVEL_N;
	// -------------------------------------

	// Checking required Spells & Skills
	if (reqSpell && reqSkill) {
		if (HasSpell(reqSpell) && HasSkill(reqSkill))
			if (GetSkill(reqSkill) < reqSkillRank) error_code = EQUIP_ITEM_RANK_NOT_ENOUGH;
		else error_code = EQUIP_ERR_NO_REQUIRED_PROFICIENCY;
	}
	else if (reqSpell && !reqSkill) {

		if (HasSpell(reqSpell)) error_code = EQUIP_ERR_OK;
		else error_code = EQUIP_ERR_NO_REQUIRED_PROFICIENCY;
	}
	else if (!reqSpell && reqSkill) {
		
		if (HasSkill(reqSkill))
			if (GetSkill(reqSkill) < reqSkillRank) error_code = EQUIP_ITEM_RANK_NOT_ENOUGH;
		else error_code = EQUIP_ERR_NO_REQUIRED_PROFICIENCY;
	}
	// ------------------------------------

	// Issue Error Code and give FALSE
	if (error_code) {
		WorldPacket	data;
		Item* pItem = new Item();
		pItem->Create (objmgr.GenerateLowGuid (HIGHGUID_ITEM), proto->ItemId, this);
		Make_INVENTORY_CHANGE_FAILURE (&data, error_code, pItem, 0);
		GetSession()->SendPacket (&data);
		delete pItem;
		return false;
	}
	else return true;
	// ------------------------------------
}

//-----------------------------------------------------------------------------
void Player::CheckExploreSystem(void)
{
    WorldPacket data;

    for(std::list<Areas>::iterator itr = areas.begin(); itr != areas.end(); ++itr)
    {
        if( m_positionX <= itr->x1 && m_positionX >= itr->x2 && 
            m_positionY <= itr->y1 && m_positionY >= itr->y2)
        {
            //Discover a new area!
            int offset = itr->areaFlag / 32;
            uint32 val = (uint32)(1 << (itr->areaFlag % 32));
            uint32 currFields = GetUInt32Value(PLAYER_EXPLORED_ZONES_1 + offset);
            //If area was not disvovered
            if( !(currFields & val) )
            {
                //Set the new area into the player's field
                SetUInt32Value(PLAYER_EXPLORED_ZONES_1 + offset, (uint32)(currFields | val));

				// We have 1 value for just created characters
				if (m_timeLogoff != 1) {

				//Get Player's level
				uint32 XP = CalcExplorationXP(this);
				//Set XP gain
				GiveXP((uint32)XP, GetGUID());

				//Send a MSG to client
				data.Initialize( SMSG_EXPLORATION_EXPERIENCE );
				data << (uint32)itr->areaID; //Area ID
				data << (uint32)XP;          //XP
				m_session->SendPacket(&data);
				}
				else { m_timeLogoff = (uint32)time(NULL);}

				Log::getSingleton( ).outDetail("ack > EXPLORATION: PLAYER [%d] NEW AREA: [%d]", GetGUID(), itr->areaID);
            }
            //Log::getSingleton( ).outDetail("Player %u are into area %u at zone %u.", GetGUID(), itr->areaFlag, itr->zone);
        }
    }

}

//-----------------------------------------------------------------------------
void Player::InitExploreSystem(void)
{
    Areas newArea;
    areas.clear();

    Log::getSingleton( ).outDetail("ack > EXPLORATION: INIT");

    for(unsigned int i = 0; i < sWorldMapOverlayStore.GetNumRows(); i++)
    {
        //Load data from WorldMapOverlay.dbc
        WorldMapOverlayEntry *overlay = sWorldMapOverlayStore.LookupEntry(i);

        if( overlay )
        {
            //Load data of the zone
            WorldMapArea *zone = sWorldMapArea.LookupEntry( overlay->worldMapAreaID );
            if(!zone) continue;    
            //Do not add an area out of zone
            if(zone->zoneId != GetZoneId()) continue;
            //Load data of the area
            AreaTableEntry *area = sAreaTableStore.LookupEntry( overlay->areaTableID );
            if(!area) continue;    

            //Insert a new area into the areas list
            newArea.areaID = area->ID;
            newArea.areaFlag = area->exploreFlag;
            
            //TODO: I am not sure about this formula, but is something near it.
            float ry = abs((zone->y2 - zone->y1)/1024); //maybe 1000
            float rx = abs((zone->x2 - zone->x1)/768);  //maybe 660
            
            newArea.x2 = zone->x1 - (overlay->drawX * rx);
            newArea.y2 = zone->y1 - (overlay->drawY * ry);
            newArea.x1 = newArea.x2 + ((overlay->areaH/2)*rx);
            newArea.y1 = newArea.y2 + ((overlay->areaW/2)*ry);
            
            areas.push_back(newArea);

            //Log::getSingleton( ).outDetail("ack > EXPLORATION: +NEW AREA %u (%f, %f) (%f, %f)", newArea.areaID, newArea.x1, newArea.y1, newArea.x2, newArea.y2);
            Log::getSingleton( ).outDetail("ack > EXPLORATION: +NEW AREA %u ", newArea.areaID);

		}
    }
}
// ------------------------------------------------------------------------------------------
bool Player::IsGroupMember(Player *plyr)
{
	if(!plyr->IsInGroup())
		return false;
	Group *grp = objmgr.GetGroupByLeader(plyr->GetGroupLeader());
	if(grp->GroupCheck(plyr->GetGUID()))
	{
		return true;
	}
	return false;
}
// ------------------------------------------------------------------------------------------
void Player::ModifySheath (uint32 sheath_type)
{
	Item *item;

	if (sheath_type) {

		if (GetItemBySlot(EQUIPMENT_SLOT_MAINHAND)) {

			item = GetItemBySlot(EQUIPMENT_SLOT_MAINHAND);

			SetUInt32Value (UNIT_VIRTUAL_ITEM_SLOT_DISPLAY + 0, item->GetProto()->DisplayInfoID);
			SetUInt32Value (UNIT_VIRTUAL_ITEM_INFO + 0, item->GetGUIDLow());
			SetUInt32Value (UNIT_VIRTUAL_ITEM_INFO + 1, item->GetProto()->Sheath);
		}
		
		if (GetItemBySlot(EQUIPMENT_SLOT_OFFHAND)) {
		
			item = GetItemBySlot(EQUIPMENT_SLOT_OFFHAND);

			SetUInt32Value (UNIT_VIRTUAL_ITEM_SLOT_DISPLAY + 1, item->GetProto()->DisplayInfoID);
			SetUInt32Value (UNIT_VIRTUAL_ITEM_INFO + 2, item->GetGUIDLow());
			SetUInt32Value (UNIT_VIRTUAL_ITEM_INFO + 3, item->GetProto()->Sheath);
		}

		if (GetItemBySlot(EQUIPMENT_SLOT_RANGED)) {

			item = GetItemBySlot(EQUIPMENT_SLOT_RANGED);

			SetUInt32Value (UNIT_VIRTUAL_ITEM_SLOT_DISPLAY + 2, item->GetProto()->DisplayInfoID);
			SetUInt32Value (UNIT_VIRTUAL_ITEM_INFO + 4, item->GetGUIDLow());
			SetUInt32Value (UNIT_VIRTUAL_ITEM_INFO + 5, item->GetProto()->Sheath);
		}
	}
	else {

		if (GetUInt32Value (UNIT_VIRTUAL_ITEM_SLOT_DISPLAY + 0)) {
		SetUInt32Value (UNIT_VIRTUAL_ITEM_SLOT_DISPLAY + 0, (uint32)0);
		SetUInt32Value (UNIT_VIRTUAL_ITEM_INFO + 0, (uint32)0);
		SetUInt32Value (UNIT_VIRTUAL_ITEM_INFO + 1, (uint32)0);
		}

		if (GetUInt32Value (UNIT_VIRTUAL_ITEM_SLOT_DISPLAY + 1)) {
		SetUInt32Value (UNIT_VIRTUAL_ITEM_SLOT_DISPLAY + 1, (uint32)0);
		SetUInt32Value (UNIT_VIRTUAL_ITEM_INFO + 2, (uint32)0);
		SetUInt32Value (UNIT_VIRTUAL_ITEM_INFO + 3, (uint32)0);
		}

		if (GetUInt32Value (UNIT_VIRTUAL_ITEM_SLOT_DISPLAY + 2)) {
		SetUInt32Value (UNIT_VIRTUAL_ITEM_SLOT_DISPLAY + 2, (uint32)0);
		SetUInt32Value (UNIT_VIRTUAL_ITEM_INFO + 4, (uint32)0);
		SetUInt32Value (UNIT_VIRTUAL_ITEM_INFO + 5, (uint32)0);
		}

	}

}
// ------------------------------------------------------------------------------------------
void Player::CreateObjectItem (uint32 itemId, uint8 playerslot, uint8 count)
{
	// CONTAINER - ITEM SELECTION
	ItemPrototype *proto = objmgr.GetItemPrototype(itemId);
	if (proto->InventoryType == INVTYPE_BAG) {
		// Adding Container
		Log::getSingleton( ).outDebug ("ack > INVENTORY: CONTAINER FOUND ID[%d] SLOTS[%d] >> ADDING TO SLOT [%d]", itemId, proto->ContainerSlots, playerslot);
		Container* pContainer = new Container();
		pContainer->Create (objmgr.GenerateLowGuid (HIGHGUID_CONTAINER), itemId, this);
		pContainer->SetCount (count);
		AddItemToSlot(playerslot, pContainer);
		pContainer->SaveToDB();
	}
	else {
		// Adding Item
		Log::getSingleton( ).outDebug ("ack > INVENTORY: ITEM FOUND ID[%d] ", itemId);
		Item* item = new Item();
		item->Create (objmgr.GenerateLowGuid (HIGHGUID_ITEM), itemId, this);
		item->SetCount (count);
		AddItemToSlot (playerslot, item);
		item->SaveToDB();
	}
	//////////////////////////////////////////////////////
}

//--- END ---
