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
#include "Opcodes.h"
#include "ObjectMgr.h"
#include "World.h"
#include "WorldPacket.h"
#include "WorldSession.h"
#include "UpdateMask.h"
#include "Player.h"
#include "Quest.h"
#include "Spell.h"
#include "Stats.h"
#include "UpdateData.h"
#include "Channel.h"
#include "ZoneMapper.h"
#include "Affect.h"
#include "ExplorationMgr.h"
#include "Group.h"
#include "Trade.h"
#include "Duel.h"
#include "EventMgr.h"
#include "Map.h"

Player::Player ( ): Unit()
{
	m_objectType |= TYPE_PLAYER;
	m_objectTypeId = TYPEID_PLAYER;

	m_valuesCount = PLAYER_END;

	m_session = 0;

	m_runSpeed = 7.0f;
	m_afk = 0;
	m_curTarget = 0;
	m_curSelection = 0;
	m_lootGuid = 0;
    m_pet = NULL;
    m_petDisplayId = 0;
    m_petLevel = 0;
	m_petFamilyId = 0;
    m_petXp = 0;
	m_lastAttackTime = 0;
	m_regenTimer = 0;
	m_dismountTimer = 0;
	m_dismountCost = 0;
	m_mount_pos_x = 0;
	m_mount_pos_y = 0;
	m_mount_pos_z = 0;

	m_nextSave = 900000; /* 15 min after create */

	m_currentSpell = NULL;
	m_resurrectGUID = NULL;
	m_resurrectX = m_resurrectY = m_resurrectZ = NULL;
	m_resurrectHealth = m_resurrectMana = NULL;

	memset(m_items, 0, sizeof(Item*)*BANK_SLOT_BAG_END);
	memset(buyback, 0, sizeof(Item*)*12);

	m_groupLeader = 0;
	m_isInGroup = false;
	m_isInvited = false;

	m_invitersGuid = 0;

	m_raidSubGroup = 0;

	m_currentMovement = MOVE_UNROOT;

	//DK
	m_guildId = 0;
	m_guildRank = 0;
	m_guildLastOnline = 0;
	m_signedCharter = false;

	//Trade
	TradingWith = NULL;

	//Duel
	DuelingWith = NULL;
	m_duelTimer = 0;

    //WayPoint
    waypointunit = NULL;

	//PVP
	PvPTimeoutEnabled = false;

	//Tutorials
	for ( int aX = 0 ; aX < 8 ; aX++ )
		m_Tutorials[ aX ] = 0x00;

	sEventMgr.AddEvent(this, &Player::Update, (uint32)100, EVENT_PLAYER_UPDATE, 100, 0);
	sEventMgr.AddEvent(this, &Player::_EventExploration, EVENT_PLAYER_UPDATEEXPLORATION, 5000, 0);
}


Player::~Player ( )
{
	ASSERT(!IsInWorld());

	sEventMgr.RemoveEvents(this);

	for(int i = 0; i < BANK_SLOT_BAG_END; i++)
	{
		if(m_items[i])
		{
			if(m_items[i]->pContainer)
			{
				delete m_items[i]->pContainer;
			}
			delete m_items[i];
		}
	}

	CleanupChannels();
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

	for (i = 0; i < BANK_SLOT_BAG_END; i++)
		m_items[i] = NULL;

	// unpack data into member variables
	data >> m_name;
	data >> race >> class_ >> gender >> skin >> face;
	data >> hairStyle >> hairColor >> facialHair >> outfitId;

	PlayerCreateInfo *info = objmgr.GetPlayerCreateInfo(race, class_);
	ASSERT(info);

	baseattacktime[0] = 2000;
	baseattacktime[1] = 2000;

	m_mapId = info->mapId;
	m_zoneId = info->zoneId;
	m_positionX = info->positionX;
	m_positionY = info->positionY;
	m_positionZ = info->positionZ;
	m_bind_pos_x = info->positionX;
	m_bind_pos_y = info->positionY;
	m_bind_pos_z = info->positionZ;
	m_bind_mapid = info->mapId;
	m_bind_zoneid = info->zoneId;
	m_isResting = 0;
	m_restAmount = 0;
	m_restState = 0;

	memset(m_taximask, 0, sizeof(m_taximask));

	uint8 powertype = 0;
	switch(class_)
	{
	case WARRIOR : powertype = 1; break; // Rage
	case PALADIN : powertype = 0; break; // Mana
	case HUNTER  : powertype = 0; break;
	case ROGUE   : powertype = 3; break; // Energy
	case PRIEST  : powertype = 0; break;
	case SHAMAN  : powertype = 0; break;
	case MAGE    : powertype = 0; break;
	case WARLOCK : powertype = 0; break;
	case DRUID   : powertype = 0; break;
	} // 2 = Focus (unused)

	// Set Starting stats for char
	SetFloatValue(OBJECT_FIELD_SCALE_X, 1.0f);
	SetUInt32Value(UNIT_FIELD_HEALTH, info->health);
	SetUInt32Value(UNIT_FIELD_POWER1, info->mana );
	SetUInt32Value(UNIT_FIELD_POWER2, 0 ); // this gets devided by 10
	SetUInt32Value(UNIT_FIELD_POWER3, info->focus );
	SetUInt32Value(UNIT_FIELD_POWER4, info->energy );
	SetUInt32Value(UNIT_FIELD_MAXHEALTH, info->health);
	SetUInt32Value(UNIT_FIELD_MAXPOWER1, info->mana );
	SetUInt32Value(UNIT_FIELD_MAXPOWER2, info->rage );
	SetUInt32Value(UNIT_FIELD_MAXPOWER3, info->focus );
	SetUInt32Value(UNIT_FIELD_MAXPOWER4, info->energy );
	SetUInt32Value(UNIT_FIELD_LEVEL, 1 );
	if(race < 7)
		SetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE, race );
	else
		SetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE, (race+108));
	SetUInt32Value(UNIT_FIELD_BYTES_0, ( ( race ) | ( class_ << 8 ) | ( gender << 16 ) | ( powertype << 24 ) ) );
	SetUInt32Value(UNIT_FIELD_BYTES_1, 0x0011EE00 );
	SetUInt32Value(UNIT_FIELD_BYTES_2, 0xEEEEEE00 );
	SetFlag(UNIT_FIELD_FLAGS , U_FIELD_FLAG_PLAYER_CONTROLLED );
	SetUInt32Value(UNIT_FIELD_STAT0, info->strength );
	SetUInt32Value(UNIT_FIELD_STAT1, info->ability );
	SetUInt32Value(UNIT_FIELD_STAT2, info->stamina );
	SetUInt32Value(UNIT_FIELD_STAT3, info->intellect );
	SetUInt32Value(UNIT_FIELD_STAT4, info->spirit );
	SetUInt32Value(UNIT_FIELD_BASEATTACKTIME, baseattacktime[0] );
	SetUInt32Value(UNIT_FIELD_BASEATTACKTIME+1, baseattacktime[1]  );
	SetFloatValue(UNIT_FIELD_BOUNDINGRADIUS, 0.388999998569489f );
	SetFloatValue(UNIT_FIELD_COMBATREACH, 1.5f   );
	SetUInt32Value(UNIT_FIELD_DISPLAYID, info->displayId + gender );
	SetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID, info->displayId + gender );
	SetFloatValue(UNIT_FIELD_MINDAMAGE, info->mindmg );
	SetFloatValue(UNIT_FIELD_MAXDAMAGE, info->maxdmg );
	SetUInt32Value(UNIT_FIELD_ATTACK_POWER, info->attackpower );
	SetUInt32Value(PLAYER_BYTES, ((skin) | (face << 8) | (hairStyle << 16) | (hairColor << 24)));
	SetUInt32Value(PLAYER_BYTES_2, (facialHair | (0xEE << 8) | (0x01 << 16) | (0x02 << 24)));
	// uint32 tmp;
	// tmp = 0 | (GetUInt32Value(PLAYER_BYTES_2) <<
	SetUInt32Value(PLAYER_NEXT_LEVEL_XP, 400);
	SetUInt32Value(PLAYER_FIELD_BYTES, 0xEEEE0000 );

	SetFloatValue(PLAYER_FIELD_MOD_DAMAGE_DONE_PCT, 1.00);
	SetUInt32Value(PLAYER_FIELD_MOD_DAMAGE_DONE_NEG, 0);
	SetUInt32Value(PLAYER_FIELD_MOD_DAMAGE_DONE_POS, 0);


	Item *item;
	for (i=0; i<10; i++)
	{
		if ( (info->item[i]!=0) && (info->item_slot[i]!=0) )
		{
            ItemPrototype *it = objmgr.GetItemPrototype(info->item[i]);
            if(it)
            {
			    item = new Item();
			    item->Create(objmgr.GenerateLowGuid(HIGHGUID_ITEM), info->item[i], this);
			    AddItemToSlot(info->item_slot[i], item);
            }
            else sLog.outDebug("ItemCreate on player Failed for item %u",info->item[i]);
		}
	}

	for (i=0; i<10; i++)
	{
		if ( info->spell[i]!=0 )
		{
			addSpell(info->spell[i], 0);
		}
	}

	// Not worrying about this stuff for now
	m_guildId = 0;
	m_guildRank = 0;
	m_guildLastOnline = 0;
    m_petDisplayId = 0;
    m_petLevel = 0;
	m_petFamilyId = 0;

	// adding skilllines
	// TODO: Maybe add ids of skills in sql db ?
	switch(class_)
	{
	case WARRIOR : 
		AddSkillLine(413, 1, 1); // Mail
		AddSkillLine(414, 1, 1); // Leather
		AddSkillLine(415, 1, 1); // Cloth
		AddSkillLine(433, 1, 1); // Shields
		AddSkillLine(26, 1, 1);  // Arms
		AddSkillLine(256, 1, 1); // Fury
		AddSkillLine(257, 1, 1); // Protection
		switch (race)
		{
		case 1: // Human
			AddSkillLine(43, 1, 5); // Swords
			AddSkillLine(44, 1, 5); // Axes
			AddSkillLine(54, 1, 5); // Maces
			AddSkillLine(55, 1, 5); // Two-Handed Swords
			break;
		case 2: // Orc
			AddSkillLine(44, 1, 5); // Axes
			AddSkillLine(172, 1, 5); // Two-Handed Axes
			break;
		case 3: // Dwarf
			AddSkillLine(44, 1, 5); // Axes
			AddSkillLine(54, 1, 5); // Maces
			AddSkillLine(172, 1, 5); // Two-Handed Axes
			break;
		case 4: // Night Elf
			AddSkillLine(43, 1, 5); // Swords
			AddSkillLine(54, 1, 5); // Maces
			AddSkillLine(173, 1, 5); // Daggers
			break;
		case 5: // Undead
			AddSkillLine(43, 1, 5); // Swords
			AddSkillLine(55, 1, 5); // Two-Handed Swords
			AddSkillLine(173, 1, 5); // Daggers
			break;
		case 6: // Tauren
			AddSkillLine(44, 1, 5); // Axes
			AddSkillLine(54, 1, 5); // Maces
			AddSkillLine(160, 1, 5); // Two-Handed Maces
			break;
		case 7: // Gnome
			AddSkillLine(43, 1, 5); // Swords
			AddSkillLine(54, 1, 5); // Maces
			AddSkillLine(173, 1, 5); // Daggers
			break;
		case 8: // Troll
			AddSkillLine(44, 1, 5); // Axes
			AddSkillLine(173, 1, 5); // Daggers
			AddSkillLine(176, 1, 5); // Thrown
			break;
		}
		break;
	case PALADIN :
		AddSkillLine(413, 1, 1); // Mail
		AddSkillLine(414, 1, 1); // Leather
		AddSkillLine(415, 1, 1); // Cloth
		AddSkillLine(433, 1, 1); // Shields
		AddSkillLine(184, 1, 1); // Retribution
		AddSkillLine(267, 1, 1); // Protection
		AddSkillLine(594, 1, 1); // Holy
		switch (race)
		{
		case 1: // Human
			AddSkillLine(43, 1, 5); // Swords
			AddSkillLine(54, 1, 5); // Maces
			AddSkillLine(55, 1, 5); // Two-Handed Swords
			AddSkillLine(160, 1, 5); // Two-Handed Maces
			break;
		case 3: // Dwarf
			AddSkillLine(54, 1, 5); // Maces
			AddSkillLine(160, 1, 5); // Two-Handed Maces
			break;
		}
		break;
	case HUNTER  :
		AddSkillLine(414, 1, 1); // Leather
		AddSkillLine(415, 1, 1); // Cloth
		AddSkillLine(50, 1, 1); // Beast Mastery
		AddSkillLine(51, 1, 1); // Survival
		AddSkillLine(163, 1, 1); // Marksmanship
		switch (race)
		{
		case 2: // Orc
			AddSkillLine(44, 1, 5); // Axes
			AddSkillLine(45, 1, 5); // Bows
			break;
		case 3: // Dwarf
			AddSkillLine(44, 1, 5); // Axes
			AddSkillLine(46, 1, 5); // Guns
			break;
		case 4: // Night Elf
			AddSkillLine(44, 1, 5); // Axes
			AddSkillLine(45, 1, 5); // Bows
			AddSkillLine(137, 1, 5); // Daggers
			break;
		case 6: // Tauren
			AddSkillLine(44, 1, 5); // Axes
			AddSkillLine(46, 1, 5); // Guns
			break;
		case 8: // Troll
			AddSkillLine(44, 1, 5); // Axes
			AddSkillLine(45, 1, 5); // Bows
			break;
		}
		break;
	case ROGUE   :
		AddSkillLine(414, 1, 1); // Leather
		AddSkillLine(415, 1, 1); // Cloth
		AddSkillLine(38, 1, 1); // Combat
		AddSkillLine(39, 1, 1); // Subtlety
		AddSkillLine(253, 1, 1); // Assassination
		AddSkillLine(176, 1, 5); // Thrown
		AddSkillLine(173, 1, 1); // Daggers
		break;
	case PRIEST  :
		AddSkillLine(415, 1, 1); // Cloth
		AddSkillLine(56, 1, 1); // Holy
		AddSkillLine(78, 1, 1); // Shadow Magic
		AddSkillLine(613, 1, 1); // Discipline
		AddSkillLine(228, 1, 5); // Wands
		AddSkillLine(54, 1, 5); // Maces
		break;
	case SHAMAN  :
		AddSkillLine(414, 1, 1); // Leather
		AddSkillLine(415, 1, 1); // Cloth
		AddSkillLine(433, 1, 1); // Shields
		AddSkillLine(373, 1, 1); // Enhancement
		AddSkillLine(374, 1, 1); // Restoration
		AddSkillLine(375, 1, 1); // Elemental Combat
		switch (race)
		{
		case 2: // Orc
			AddSkillLine(44, 1, 5); // Axes
			AddSkillLine(54, 1, 5); // Maces
			AddSkillLine(136, 1, 5); // Staves
			AddSkillLine(172, 1, 5); // Two-Handed Axes
			break;
		case 6: // Tauren
			AddSkillLine(54, 1, 5); // Maces
			AddSkillLine(136, 1, 5); // Staves
			break;
		case 8: // Troll
			AddSkillLine(54, 1, 5); // Maces
			AddSkillLine(136, 1, 5); // Staves
			break;
		}
		break;
	case MAGE    :
		AddSkillLine(415, 1, 1); // Cloth
		AddSkillLine(6, 1, 1); // Frost
		AddSkillLine(8, 1, 1); // Fire
		AddSkillLine(237, 1, 1); // Arcane Magic
		AddSkillLine(228, 1, 5); // Wands
		AddSkillLine(136, 1, 5); // Staves
		break;
	case WARLOCK :
		AddSkillLine(415, 1, 1); // Cloth
		AddSkillLine(354, 1, 1); // Demonology
		AddSkillLine(355, 1, 1); // Affliction
		AddSkillLine(593, 1, 1); // Destruction
		AddSkillLine(228, 1, 5); // Wands
		AddSkillLine(173, 1, 5); // Daggers
		break;
	case DRUID   :
		AddSkillLine(414, 1, 1); // Leather
		AddSkillLine(415, 1, 1); // Cloth
		AddSkillLine(134, 1, 1); // Feral Combat
		AddSkillLine(573, 1, 1); // Restoration
		AddSkillLine(574, 1, 1); // Balance
		AddSkillLine(433, 1, 5); // Bows
		AddSkillLine(228, 1, 5); // Wands
		switch (race)
		{
		case 4: // Night Elf
			AddSkillLine(136, 1, 5); // Staves
			AddSkillLine(137, 1, 5); // Daggers
			break;
		case 6: // Tauren
			AddSkillLine(54, 1, 5); // Maces
			AddSkillLine(136, 1, 5); // Staves
			break;
		}
		break;
	}

	AddSkillLine(95, 1, 5); // Defense
	AddSkillLine(162, 1, 5); // Unarmed
	SetFloatValue(PLAYER_DODGE_PERCENTAGE,((info->ability / 14.5) + (GetSkillAmt(95)*.04)));
	SetFloatValue(PLAYER_BLOCK_PERCENTAGE,info->strength / 30.0);
	if (GetItemBySlot(EQUIPMENT_SLOT_OFFHAND))
		SetFloatValue(PLAYER_BLOCK_PERCENTAGE,(info->strength / 30.0 + GetItemBySlot(EQUIPMENT_SLOT_OFFHAND)->GetProto()->Block));
	SetFloatValue(PLAYER_PARRY_PERCENTAGE,(GetSkillAmt(95)*.04));

	switch (race)
	{
	case 1: // Human
		AddSkillLine(98, 300, 300); // Laguage: Common
		break;
	case 2: // Orc
		AddSkillLine(109, 300, 300); // Laguage: Orcish
		break;
	case 3: // Dwarf
		AddSkillLine(98, 300, 300); // Laguage: Common
		AddSkillLine(111, 300, 300); // Laguage: Dwarven
		break;
	case 4: // Night Elf
		AddSkillLine(98, 300, 300); // Laguage: Common
		AddSkillLine(113, 300, 300); // Laguage: Darnassian
		break;
	case 5: // Undead
		AddSkillLine(109, 300, 300); // Laguage: Orcish
		AddSkillLine(673, 300, 300); // Laguage: Gutterspeak
		break;
	case 6: // Tauren
		AddSkillLine(109, 300, 300); // Laguage: Orcish
		AddSkillLine(115, 300, 300); // Laguage: Taurane
		break;
	case 7: // Gnome
		AddSkillLine(98, 300, 300); // Laguage: Common
		AddSkillLine(313, 300, 300); // Laguage: Gnomish
		break;
	case 8: // Troll
		AddSkillLine(109, 300, 300); // Laguage: Orcish
		AddSkillLine(315, 300, 300); // Laguage: Trollish
		break;
	}

	std::stringstream query;
	query.rdbuf()->str("");
	query << "DELETE FROM char_reputation WHERE charId=" << GetGUIDLow();
	sDatabase.Execute( query.str().c_str() );

	for(i = 0; i < 46; i++)
	{
		uint8 flag = 0;
		if((race == 1 || race == 3 || race == 4 || race == 7) && (i == 18 || i == 19 || i == 20 || i == 21))
			flag = 1;   // Alliance Factions can see their Capital's Factions
		else if((race == 2 || race == 5 || race == 6 || race == 8) && (i == 14 || i == 15 || i == 16 || i == 17))
			flag = 1;   // Horde Factions can see their Capital's Factions
		query.rdbuf()->str("");
		query << "INSERT INTO char_reputation (charId,factionId,flag,standing) VALUES ( ";
		query << GetGUIDLow() << "," << int(i) << "," << int(flag);
		query << "," << int(0) << ")" << '\0';

		sDatabase.Execute( query.str().c_str() );
	}

	_LoadReputation();

	//Base Data filling
	memcpy(m_baseUint32Values, m_uint32Values,m_valuesCount*sizeof(uint32));
}


void Player::Update( uint32 p_time )
{
	if(!IsInWorld())
		return;

	WorldPacket data;

	Unit::Update( p_time );

	// only regenerate if alive
	if (isAlive())
	{
		RegenerateAll();
	}

	// Dead System
	if (m_deathState == JUST_DIED)
	{
		KillPlayer();
	}

	/* Auto-Dismount after Taxiride */
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
			RemoveFlag( UNIT_FIELD_FLAGS, U_FIELD_FLAG_MOUNT_SIT );

			/* Remove the "player locked" flag, to allow movement */
			if (GetUInt32Value(UNIT_FIELD_FLAGS) & U_FIELD_FLAG_LOCK_PLAYER )	
				RemoveFlag( UNIT_FIELD_FLAGS, U_FIELD_FLAG_LOCK_PLAYER );

			SetPlayerSpeed(RUN,m_runSpeed,true);
			/* SetPlayerSpeed(RUN,7.5f,false); */

		}
		else
		{
			m_dismountTimer -= p_time;
		}
	}


	/* Auto-Save after 10min */
	if(m_nextSave > 0)
	{
		if(p_time >= m_nextSave)
		{ 
			m_nextSave = 600000; /* around about 10 min */
			SaveToDB();
			Log::getSingleton().outBasic("Player '%u' '%s' Saved", GetGUID(), GetName());
		}
		else
		{
			m_nextSave -= p_time;
		}
	}

	/* Duel Timer*/
	if(m_duelTimer > 0)
	{
		if(p_time >= m_duelTimer)
		{
			m_duelTimer = 0;
			if(GetDuelStatus() == DUEL_STATUS_OUTOFBOUNDS)
			{
				//Out of Bounds for too Long
				sDuelHandler.EndDuel(this,DUEL_WINNER_RETREAT);
			}
			else if(GetDuelState() == DUEL_STATE_REQUESTED)
			{
				sDuelHandler.StartDuel(this);
			}
		}
		else
		{
			m_duelTimer -= p_time;
		}
	}

	if(this->DuelingWith != NULL)
	{
		sDuelHandler.DuelBoundry(this);
	}
}

void Player::_EventAttack()
{
	if (m_currentSpell)
		return;

	WorldPacket data;

	Unit *pVictim = NULL;

	pVictim = objmgr.GetObject<Creature>(m_curSelection);
	if(!pVictim)
	{
		pVictim = objmgr.GetObject<Player>(m_curSelection);
	}
	//Can't find victim, stop attacking
	if (!pVictim)
	{
		Log::getSingleton( ).outDetail("Player::Update:  No valid current selection to attack, stopping attack\n");
		this->setRegenTimer(5000); //prevent clicking off creature for a quick heal
		clearStateFlag(UF_ATTACKING);
		EventAttackStop();
		smsg_AttackStop(m_curSelection);
	}
	else
	{
		if (!canReachWithAttack(pVictim))
		{
			data.Initialize(SMSG_CAST_RESULT);
			data << uint32(0);
			data << uint8(2);
			data << uint8(SPELL_FAILED_OUT_OF_RANGE);
			GetSession()->SendPacket(&data);
		}
		else if(!isInFront(pVictim))
		{
			data.Initialize(SMSG_CAST_RESULT);
			data << uint32(0);
			data << uint8(2);
			data << uint8(SPELL_FAILED_NOT_INFRONT);
			GetSession()->SendPacket(&data);
		}
		else
		{
			//pvp timeout reset
			if(pVictim->GetTypeId() == TYPEID_PLAYER)
			{
				if(((Player*)pVictim)->DuelingWith == NULL)  //Dueling doesn't trigger PVP
				{	
					if(PvPTimeoutEnabled == true)
					{
						sEventMgr.ModifyEventTimeLeft(this, EVENT_PLAYER_STOPPVP, 300000);
						//make sure that pvp is enabled
						if(!HasFlag(UNIT_FIELD_FLAGS,U_FIELD_FLAG_PVP))
							SetFlag(UNIT_FIELD_FLAGS, U_FIELD_FLAG_PVP);
					}
					else
					{
						//Add pvp timeout
						PvPTimeoutUpdate(false);
					}
				}
			}

			m_lastAttackTime = getMSTime();

			if (!GetOnMeleeSpell())
			{
				AttackerStateUpdate(pVictim, 0);
			} 
			else 
			{
				Log::getSingleton().outError("Casting spell on melee");	
				SpellEntry *spellInfo = sSpellStore.LookupEntry(GetOnMeleeSpell());
				SetOnMeleeSpell(0);
				Spell *spell = new Spell(this,spellInfo,false,0,true);
				WPAssert(spell);
				SpellCastTargets targets;
				targets.m_unitTarget = GetSelection();
				spell->prepare(&targets);
				//delete spell;
			}
		}
	}   
}

void Player::EventAttackStart()
{
	//Todo: formula for attack time
	sEventMgr.RemoveEvents(this, EVENT_PLAYER_UPDATEATTACK);
	uint32 time = (getMSTime() - m_lastAttackTime) > GetUInt32Value(UNIT_FIELD_BASEATTACKTIME) ?
		0 : getMSTime() - m_lastAttackTime;
	sEventMgr.AddEvent(this, &Player::_EventAttack, EVENT_PLAYER_UPDATEATTACK, GetUInt32Value(UNIT_FIELD_BASEATTACKTIME), 0);
	sEventMgr.ModifyEventTimeLeft(this, EVENT_PLAYER_UPDATEATTACK, time);
}

void Player::EventAttackStop()
{
	sEventMgr.RemoveEvents(this, EVENT_PLAYER_UPDATEATTACK);
}

void Player::_EventExploration()
{
	sExplorationMgr.Update(this);
}

void Player::EventDeath()
{
	if (m_state & UF_ATTACKING)
		EventAttackStop();

	//Todo: respawn
}

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

	*p_data << uint8(GetUInt32Value(UNIT_FIELD_LEVEL)); //level

	*p_data << GetZoneId();
	*p_data << GetMapId();

	*p_data << m_positionX;
	*p_data << m_positionY;
	*p_data << m_positionZ;

	*p_data << GetUInt32Value(PLAYER_GUILDID);// guild
	*p_data << m_banned;             // unknown //character ban try 7
	*p_data << (uint8)1;              // rest state
    *p_data << (uint32)m_petDisplayId;   // pet display id
    *p_data << (uint32)m_petLevel;    // pet level
	*p_data << (uint32)m_petFamilyId; // pet family id


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
}



///  This function sends the message displaying the purple XP gain for the char
///  It assumes you will send out an UpdateObject packet at a later time.

void Player::GiveXP(uint32 xp, const uint64 &guid)
{
	WorldPacket data;
	if (guid != 0)
	{
		// Send out purple XP gain message, but ONLY if a valid GUID was passed in
		// This message appear to be only for gaining XP from a death
		data.Initialize( SMSG_LOG_XPGAIN );
		data << guid;
		data << uint32(xp) << uint8(0);
		data << uint16(xp) << uint8(0);
		data << uint8(0);
		GetSession()->SendPacket(&data);
	}

	if ( xp < 1 )
		return;

	if(m_restState == RESTSTATE_RESTED)
		xp <<= 1;
	uint32 curXP = GetUInt32Value(PLAYER_XP);
	uint32 nextLvlXP = GetUInt32Value(PLAYER_NEXT_LEVEL_XP);
	uint32 newXP = curXP + xp;
	uint32 level = GetUInt32Value(UNIT_FIELD_LEVEL);
	bool levelup = false;
	this->SubtractRestXP(newXP);
	
	uint32 TotalHealthGain = 0, TotalManaGain = 0;
	uint32 manaGain = GetUInt32Value(UNIT_FIELD_STAT4) / 2;
	uint32 newMana = GetUInt32Value(UNIT_FIELD_MAXPOWER1);
	uint32 healthGain = GetUInt32Value(UNIT_FIELD_STAT2) / 2;
	uint32 newHealth = GetUInt32Value(UNIT_FIELD_MAXHEALTH);

	uint32 basemanaGain = GetBaseUInt32Value(UNIT_FIELD_STAT4) / 2;
	uint32 basenewMana = GetBaseUInt32Value(UNIT_FIELD_MAXPOWER1);
	uint32 basehealthGain = GetBaseUInt32Value(UNIT_FIELD_STAT2) / 2;
	uint32 basenewHealth = GetBaseUInt32Value(UNIT_FIELD_MAXHEALTH);

	// Check for level-up
	while (newXP >= nextLvlXP)
	{
		levelup = true;
		// Level-Up!
		newXP -= nextLvlXP;  // reset XP to 0, but add extra from this xp add

		level += 1;    // increment the level

		//nextlevel XP Formulas
		if( level > 0 && level <= 30 )
		{
			nextLvlXP = ((int)((((double)(8 * level * ((level * 5) + 45)))/100)+0.5))*100;
		}
		else if( level == 31 )
		{
			nextLvlXP = ((int)((((double)(((8 * level) + 3) * ((level * 5) + 45)))/100)+0.5))*100;
		}
		else if( level == 32 )
		{
			nextLvlXP = ((int)((((double)(((8 * level) + 6) * ((level * 5) + 45)))/100)+0.5))*100;
		}
		else
		{
			nextLvlXP = ((int)((((double)(((8 * level) + ((level - 30) * 5)) * ((level * 5) + 45)))/100)+0.5))*100;
		}

		newHealth += healthGain; // increment Health
		basenewHealth +=basehealthGain;

		if (newMana > 0)
		{
			newMana += manaGain; // increment Mana
			basenewMana += basemanaGain;
		}
		if( level > 9)
		{
			//Give Talent Point
			uint32 curTalentPoints = GetUInt32Value(PLAYER_CHARACTER_POINTS1);
			SetUInt32Value(PLAYER_CHARACTER_POINTS1,curTalentPoints+1);
			SetBaseUInt32Value(PLAYER_CHARACTER_POINTS1, curTalentPoints+1); //saving
		}


		TotalHealthGain += healthGain;
		TotalManaGain += manaGain;
	}

	if(levelup)
	{
		// TODO: UNEQUIP everything and remove affects

		SetUInt32Value(PLAYER_NEXT_LEVEL_XP, nextLvlXP);
		SetUInt32Value(UNIT_FIELD_LEVEL, level);
		SetUInt32Value(UNIT_FIELD_MAXHEALTH, newHealth);
		SetUInt32Value(UNIT_FIELD_HEALTH, newHealth);
		SetUInt32Value(UNIT_FIELD_POWER1, newMana);
		SetUInt32Value(UNIT_FIELD_MAXPOWER1, newMana);

		SetBaseUInt32Value(PLAYER_NEXT_LEVEL_XP, nextLvlXP);
		SetBaseUInt32Value(UNIT_FIELD_LEVEL, level);
		SetBaseUInt32Value(UNIT_FIELD_MAXHEALTH, basenewHealth);
		SetBaseUInt32Value(UNIT_FIELD_HEALTH, basenewHealth);
		SetBaseUInt32Value(UNIT_FIELD_POWER1, basenewMana);
		SetBaseUInt32Value(UNIT_FIELD_MAXPOWER1, basenewMana);

		//calculate stats gain
		uint32 str = GainStat(level, getClass(), STAT_STRENGTH);
		uint32 agi = GainStat(level, getClass(), STAT_AGILITY);
		uint32 sta = GainStat(level, getClass(), STAT_STAMINA);
		uint32 intel = GainStat(level, getClass(), STAT_INTELLECT);
		uint32 spi = GainStat(level, getClass(), STAT_SPIRIT);

		SetUInt32Value(UNIT_FIELD_STAT0, GetUInt32Value( UNIT_FIELD_STAT0) + str );
		SetUInt32Value(UNIT_FIELD_STAT1, GetUInt32Value( UNIT_FIELD_STAT1) + agi );
		SetUInt32Value(UNIT_FIELD_STAT2, GetUInt32Value( UNIT_FIELD_STAT2) + sta );
		SetUInt32Value(UNIT_FIELD_STAT3, GetUInt32Value( UNIT_FIELD_STAT3) + intel );
		SetUInt32Value(UNIT_FIELD_STAT4, GetUInt32Value( UNIT_FIELD_STAT4) + spi );

		SetBaseUInt32Value(UNIT_FIELD_STAT0, GetBaseUInt32Value( UNIT_FIELD_STAT0) + str );
		SetBaseUInt32Value(UNIT_FIELD_STAT1, GetBaseUInt32Value( UNIT_FIELD_STAT1) + agi );
		SetBaseUInt32Value(UNIT_FIELD_STAT2, GetBaseUInt32Value( UNIT_FIELD_STAT2) + sta );
		SetBaseUInt32Value(UNIT_FIELD_STAT3, GetBaseUInt32Value( UNIT_FIELD_STAT3) + intel );
		SetBaseUInt32Value(UNIT_FIELD_STAT4, GetBaseUInt32Value( UNIT_FIELD_STAT4) + spi );

		// TODO: REEQUIP everything and add effects
		SetFloatValue(PLAYER_DODGE_PERCENTAGE,((GetUInt32Value( UNIT_FIELD_STAT1) / 14.5) + (GetSkillAmt(95)*.04)));
		SetFloatValue(PLAYER_BLOCK_PERCENTAGE,GetUInt32Value( UNIT_FIELD_STAT0) / 30.0);
		
		SetBaseFloatValue(PLAYER_DODGE_PERCENTAGE,((GetBaseUInt32Value( UNIT_FIELD_STAT1) / 14.5) + (GetSkillAmt(95)*.04)));
		SetBaseFloatValue(PLAYER_BLOCK_PERCENTAGE,GetBaseUInt32Value( UNIT_FIELD_STAT0) / 30.0);

		if (GetItemBySlot(EQUIPMENT_SLOT_OFFHAND))
		{
			SetFloatValue(PLAYER_BLOCK_PERCENTAGE,((GetUInt32Value( UNIT_FIELD_STAT0) / 30.0)+ GetItemBySlot(EQUIPMENT_SLOT_OFFHAND)->GetProto()->Block));
			//SetBaseFloatValue(PLAYER_BLOCK_PERCENTAGE,((GetBaseUInt32Value( UNIT_FIELD_STAT0) / 30.0)); 'not saved due to this formula being wrong
		}

		SetFloatValue(PLAYER_PARRY_PERCENTAGE,(GetSkillAmt(95)*.04));
		SetBaseFloatValue(PLAYER_PARRY_PERCENTAGE,(GetSkillAmt(95)*.04));

		data.Initialize(SMSG_LEVELUP_INFO);

		data << uint32(level);
		data << uint32(TotalHealthGain); // health gain

		//mana gain only for those that have it
		if( (getClass() == WARRIOR) || (getClass() == ROGUE)) data << uint32(0); //no mana gain
		else data << uint32(TotalManaGain); // mana gain
	
		data << uint32(0); 
		data << uint32(0);
		data << uint32(0);

		// 6 new fields
		data << uint32(0);
		data << uint32(str); // Strength
		data << uint32(agi); // Agility
		data << uint32(sta); // Stamina
		data << uint32(intel); // Intellect
		data << uint32(spi); // Spirit

		WPAssert(data.size() == 48);
		GetSession()->SendPacket(&data);
		std::list<struct skilllines>::iterator itr;
		for (itr = m_skilllines.begin(); itr != m_skilllines.end(); ++itr)
		{
			skilllineentry * sp= sSkillLineStore.LookupEntry((*itr).lineId);
			if (sp->type == 6)
				ModSkillMax(sp->id,5*level);
		}
	}
	// Set the update bit
	SetUInt32Value(PLAYER_XP, newXP);
	SetBaseUInt32Value(PLAYER_XP, newXP);
	CalcBaseStats();
}


void Player::smsg_InitialSpells()
{
	WorldPacket data;
	uint16 spellCount = m_spells.size();

	data.Initialize( SMSG_INITIAL_SPELLS );
	data << uint8(0);
	data << uint16(spellCount); // spell count

	std::list<struct spells>::iterator itr;
	for (itr = m_spells.begin(); itr != m_spells.end(); ++itr)
	{
		data << uint16(itr->spellId); // spell id
		data << uint16(itr->slotId); // slot
	}
	data << uint16(0);

	WPAssert(data.size() == 5+(4*spellCount));

	GetSession()->SendPacket(&data);

	Log::getSingleton( ).outDetail( "CHARACTER: Sent Initial Spells" );
}

void Player::smsg_InitialFactions()
{
	WorldPacket data;
	std::list<struct Reputation>::iterator itr;

	data.Initialize(SMSG_INITIALIZE_FACTIONS);
	data << uint8(0x40) << uint8(0x00) << uint8(0x00) << uint8(0x00);
	for (itr = m_reputation.begin(); itr != m_reputation.end(); ++itr)
	{
		data << uint8(itr->flag) << uint32(itr->standing);
	}
	for(int i=0;i<18;i++)
		data << uint8(0x00) << uint32(0);// empty data

	GetSession()->SendPacket(&data);
}

void Player::modReputation(uint8 id, int32 mod)
{
	WorldPacket data;
	std::list<struct Reputation>::iterator itr;
	for (itr = m_reputation.begin(); itr != m_reputation.end(); ++itr)
	{
		if(itr->id == id){
			itr->standing += mod;// Add Reputation Mod
			break;
		}
	}
	// Send Reputation Packet
	data.Initialize(SMSG_SET_FACTION_STANDING);
	data << id;
	data << uint32(itr->standing);
	GetSession()->SendPacket(&data);

	if(itr->flag == 0)// If this Faction is not Visible yet, make it visible
	{
		data.clear();
		data.Initialize(SMSG_SET_FACTION_VISIBLE);
		data << id;
		GetSession()->SendPacket(&data);
		itr->flag = 1;
	}
}

void Player::SetFactionState(uint8 id, uint8 state)
{
	std::list<struct Reputation>::iterator itr;
	for (itr = m_reputation.begin(); itr != m_reputation.end(); ++itr)
	{
		if(itr->id == id)
			break;
	}
	if(itr == NULL)
		return;

	itr->flag = state;
}

uint8 Player::GetStandingById(uint8 id)
{
	std::list<struct Reputation>::iterator itr;
	uint8 state;
	uint32 standing;
	uint32 NumRep[8] = {36000, 3000, 3000, 3000, 6000, 12000, 21000, 1000}; // Reputation for each Reputation Level in Numbers


	// Get Faction Template
	Faction* factTemp = objmgr.GetFaction(getRace(), id);
	if(!factTemp){
		Log::getSingleton( ).outString( "Missing Faction Template for Race: %u, Id: %u -> return STANDING_NEUTRAL", getRace(), id );
		return STANDING_NEUTRAL;
	}

	// Get Reputation
	for (itr = m_reputation.begin(); itr != m_reputation.end(); ++itr)
	{
		if(itr->id == id)
			break;
	}

	if(itr->flag == 2)// At War
		return STANDING_HATED;

	state = factTemp->state;
	standing = itr->standing;

	// Calculate Standing based on FactionTemplate and Player's Reputation
	if(standing + factTemp->standing < NumRep[factTemp->state])
		return state;

	standing += factTemp->standing;
	while(standing >= NumRep[state])
	{
		standing -= NumRep[state];
		state++;
	}
	return state;
}

uint8 Player::GetStandingByFactionTemplate(uint32 fctTmp)
{
	FactionTemplateDBC *factionInfo = sFactionTmpStore.LookupEntry( fctTmp );

	if(!factionInfo)
	{
		Log::getSingleton( ).outError("WORLD: unknown factionTemplate id %i\n", fctTmp);
		return STANDING_NEUTRAL;
	}

	return GetStandingById(factionInfo->FactionId);
}


void Player::_LoadReputation()
{
	//Clear Reputation List
	m_reputation.clear();

	//Reputations
	std::stringstream query;
	query << "SELECT * FROM char_reputation WHERE charId=" << GetGUIDLow() << " ORDER BY factionId";
	QueryResult *result = sDatabase.Query( query.str().c_str() );
	if(result)
	{
		do
		{
			Field *fields = result->Fetch();

			Reputation *rep = new Reputation;
			rep->id = fields[1].GetUInt8();
			rep->flag = fields[2].GetUInt8();
			rep->standing = fields[3].GetUInt32();
			m_reputation.push_back((*rep));
		}
		while( result->NextRow() );

		delete result;
	}
}

void Player::_SaveReputation()
{
	std::stringstream query;
	query << "DELETE FROM char_reputation WHERE charId=" << GetGUIDLow();
	sDatabase.Execute( query.str().c_str() );

	std::list<struct Reputation>::iterator itr;
	for (itr = m_reputation.begin(); itr != m_reputation.end(); ++itr)
	{
		query.rdbuf()->str("");
		query << "INSERT INTO char_reputation (charId,factionId,flag,standing) VALUES ( ";
		query << GetGUIDLow() << "," << int(itr->id) << "," << int(itr->flag);
		query << "," << int(itr->standing) << ")" << '\0';

		sDatabase.Execute( query.str().c_str() );
	}
}


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

void Player::AddBid(bidentry *be)
{
	std::list<bidentry*>::iterator itr;
	for (itr = m_bids.begin(); itr != m_bids.end();)
	{
		if ((*itr)->AuctionID == be->AuctionID)
		{
			m_bids.erase(itr++);
		}
		else
		{
			++itr;
		}
	}
	m_bids.push_back(be);
}

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
			invq <<  "INSERT INTO auctionhouse (auctioneerguid, itemguid, itemowner,buyoutprice,time,buyguid,lastbid,Id) VALUES ( " <<
				Aentry->auctioneer << ", " << Aentry->item << ", " << Aentry->owner << ", " << Aentry->buyout << ", " << Aentry->time << ", " << Aentry->bidder << ", " << Aentry->bid << ", " << Aentry->Id << " )";
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
		invq <<  "INSERT INTO mail (mailId,sender,reciever,subject,body,item,time,money,COD,checked) VALUES ( " <<
			m->messageID << ", " << m->sender << ", " << m->reciever << ", '" << m->subject.c_str() << "', '" << m->body.c_str() << "', " << 
			m->item << ", " << m->time << ", " << m->money << ", " << m->COD << ", " << m->checked << " )";

		sDatabase.Execute( invq.str().c_str( ) );
	}
}
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
//DK:_SaveGuild
void Player::SaveGuild()
{
	std::stringstream query;

	query << "DELETE FROM `playerguilds` WHERE playerId = " << GetGUIDLow();
	sDatabase.Execute( query.str().c_str() );

    uint32 guildId = GetGuildId();
    if(guildId < 1) return;

	Guild *pGuild = objmgr.GetGuild( GetGuildId() );

	if(pGuild)
	{
		guildMembers *pMember;
		pMember = pGuild->GetGuildMember( GetGUID() );

		query.rdbuf()->str("");
		query << "INSERT INTO `playerguilds` VALUES (" << GetGUIDLow() << ", " << m_guildId << ", '" << GetName() << "', " << m_guildRank << ", '" << pMember->publicNote << "', '" << pMember->officerNote << "', " << pMember->lastOnline << ", " << uint32(getClass()) << ", " << uint32(getLevel()) << ", " << GetZoneId() << ")";
		sDatabase.Execute( query.str( ).c_str( ) );
	}
}

void Player::SaveCharters()
{
/*
std::stringstream query;
	query << "DELETE FROM playercharters WHERE playerId = " << GetGUIDLow(); // TODO: use full guids
	sDatabase.Execute( query.str().c_str( ) );

	std::list<Charter*>::iterator itr;
	for (itr = m_charterList.begin(); itr != m_charterList.end(); itr++)
	{
		query.rdbuf()->str("");
		query <<  "INSERT INTO `playercharters` VALUES (" << GetGUIDLow() << ", " << (*itr)->charterId << ")";
		sDatabase.Execute( query.str().c_str( ) );
	}
	m_charterList.clear();
	*/
}

void Player::_SaveFriendList()
{
	std::stringstream query;
	query << "DELETE FROM social WHERE guid = " << GetGUIDLow(); // TODO: use full guids
	sDatabase.Execute( query.str().c_str( ) );
	std::list<struct FriendStr>::iterator itr;
	for (itr = m_friendList.begin(); itr != m_friendList.end(); itr++)
	{
		std::stringstream invq;
		invq <<  "INSERT INTO `social` VALUES (" << GetGUID() << ", " << itr->PlayerGUID << ", 'FRIEND')" ;
		sDatabase.Execute( invq.str().c_str( ) );
	}
	m_friendList.clear();
}

/*void Player::_SavePet()
{*/

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
//DK: LoadGuild
void Player::_LoadGuild()
{
	std::stringstream query;
	query << "SELECT * FROM playerguilds WHERE playerid=" << GetGUIDLow();

	QueryResult *result = sDatabase.Query( query.str().c_str() );
	if(result)
	{
		Field *fields = result->Fetch();

		m_guildId = fields[1].GetUInt32();
		m_guildRank = fields[3].GetUInt32();
		m_guildLastOnline = fields[6].GetUInt32();
		SetUInt32Value(PLAYER_GUILDID,m_guildId);
		SetUInt32Value(PLAYER_GUILDRANK,m_guildRank);
		//SetUInt32Value(PLAYER_GUILD_TIMESTAMP,4008636142);
	}
    else
    {
        m_guildId = 0;
        m_guildRank = 0;
		m_guildLastOnline = 0;
		SetUInt32Value(PLAYER_GUILDID,0);
		SetUInt32Value(PLAYER_GUILDRANK,0);
		//SetUInt32Value(PLAYER_GUILD_TIMESTAMP,0);
    }
	delete result;
}

void Player::_LoadCharters()
{
	std::stringstream query;
	std::list<Charter*>::iterator i;
	query << "SELECT * FROM playercharters WHERE playerid=" << GetGUIDLow();

	QueryResult *result = sDatabase.Query( query.str().c_str() );
	if(result)
	{
		do
		{
			Field *fields = result->Fetch();
			Charter *chrt = new Charter;
			chrt->charterId = fields[1].GetUInt32();
			m_charterList.push_back(chrt);
		}
		while( result->NextRow() );
	}

	delete result;
}

void Player::_LoadFriendList()
{
	m_friendList.clear();

	std::stringstream query;
	struct FriendStr fList;

	query << "SELECT * FROM `social` where guid='" << GetGUID() << "'";
	QueryResult *result = sDatabase.Query( query.str().c_str() );
	if(result)
	{
		Field *fields = result->Fetch();
		fields = result->Fetch();
		fList.PlayerGUID = fields[1].GetUInt64();
		m_friendList.push_back(fList);

		while( result->NextRow() )
		{
			fList.PlayerGUID = fields[1].GetUInt64();
			m_friendList.push_back(fList);
		}
		delete result;
	}
}

void Player::_LoadPet()
{
/*    uint64 petGuid = 0;
    petGuid = GetUInt64Value(UNIT_FIELD_SUMMON);
    if(petGuid > 0)
    {
        SetPet(objmgr.GetCreature(petGuid));
    }*/
}

void Player::addLoadAff(uint16 id, uint32 dur)
{
	struct affloads aff;
	aff.id = id;
	aff.dur = dur;
	m_affloads.push_back(aff);
}
void Player::addSpell(uint16 spell_id, uint16 slot_id)
{
	struct spells newspell;
	newspell.spellId = spell_id;
	//talent impact  add by vendy
	// check for spell id
	SpellEntry *spellInfo = sSpellStore.LookupEntry(spell_id);
	uint8 op;
	uint16 val=0;
	int16 tmpval=0;
	uint16 mark=0;
	WorldPacket data;
	uint32 shiftdata=0x01;
	uint8  FlatId=0;
	uint32 EffectVal;
	uint32 Opcode=SMSG_SET_FLAT_SPELL_MODIFIER;

	if (slot_id == 0xffff)
	{
		uint16 maxid = 0;
		std::list<struct spells>::iterator itr;
		for (itr = m_spells.begin(); itr != m_spells.end(); ++itr)
		{
			if (itr->slotId > maxid) maxid = itr->slotId;
		}

		slot_id = maxid + 1;
	}

	if(spellInfo && m_session)
	{
		for(int i=0;i<3;i++)
		{
			if(spellInfo->EffectSpellGroupRelation[i]!=0)
			{
				EffectVal=spellInfo->EffectSpellGroupRelation[i];
				op=spellInfo->EffectMiscValue[i];
				tmpval = spellInfo->EffectBasePoints[i];

				if(tmpval != 0)
				{
					if(tmpval > 0){
						val =  tmpval+1;
						mark = 0x0;
					}else{
						val  = 0xFFFF + (tmpval+2);
						mark = 0xFFFF;
					}
				}

				switch(spellInfo->EffectApplyAuraName[i])
				{
				case 107:
					Opcode=SMSG_SET_FLAT_SPELL_MODIFIER; // FLOAT
					break;
				case 108:
					Opcode=SMSG_SET_PCT_SPELL_MODIFIER;  // PERCENT
					break;
				}

				for(int i=0;i<32;i++)
				{
					if ( EffectVal&shiftdata )
					{
						FlatId=i;

						data.Initialize(Opcode);
						data << uint8(FlatId);
						data << uint8(op);
						data << uint16(val);
						data << uint16(mark);
						m_session->SendPacket(&data);    
					}
					shiftdata=shiftdata<<1;
				}
			}
		}
	}
	newspell.slotId = slot_id;
	m_spells.push_back(newspell);
}
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
void Player::_SetCreateBits(UpdateMask *updateMask, Player *target) const
{
	if(target == this)
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


void Player::_SetUpdateBits(UpdateMask *updateMask, Player *target) const
{
	if(target == this)
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


void Player::_SetVisibleBits(UpdateMask *updateMask, Player *target) const
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

	updateMask->SetBit(PLAYER_FLAGS);
	updateMask->SetBit(PLAYER_BYTES);
	updateMask->SetBit(PLAYER_BYTES_2);
	updateMask->SetBit(PLAYER_BYTES_3);
	//updateMask->SetBit(PLAYER_GUILD_TIMESTAMP);
	updateMask->SetBit(PLAYER_DUEL_TEAM);
	updateMask->SetBit(PLAYER_DUEL_ARBITER);
	updateMask->SetBit(PLAYER_DUEL_ARBITER+1);
	updateMask->SetBit(PLAYER_GUILDID);
	updateMask->SetBit(PLAYER_GUILDRANK);

	for(uint16 i = 0; i < EQUIPMENT_SLOT_END; i++)
	{
		updateMask->SetBit((uint16)(PLAYER_VISIBLE_ITEM_1_0 + (i*12))); // visual items for other players
		updateMask->SetBit((uint16)(PLAYER_VISIBLE_ITEM_1_0_01 + (i*12))); // visual items for other players
	}
}


void Player::BuildCreateUpdateBlockForPlayer( UpdateData *data, Player *target ) const
{
	if(target == this)
	{
		for(int i = 0; i < BANK_SLOT_BAG_END; i++)
		{
			if(m_items[i] == NULL)
			{
				continue;
			}

			if(m_items[i]->pContainer)
			{
				m_items[i]->pContainer->BuildCreateUpdateBlockForPlayer( data, target );

				for(int e=0; e < m_items[i]->pContainer->GetProto()->ContainerSlots; e++)
				{
					Item *item = m_items[i]->pContainer->GetItem(e);
					if(item)
					{
						if(item->pContainer)
						{
							item->pContainer->BuildCreateUpdateBlockForPlayer( data, target );
						}
						else
						{
							item->BuildCreateUpdateBlockForPlayer( data, target );
						}
					}
				}
			}
			else
			{
				m_items[i]->BuildCreateUpdateBlockForPlayer( data, target );
			}
		}
	}

	Unit::BuildCreateUpdateBlockForPlayer( data, target );
}


void Player::DestroyForPlayer( Player *target ) const
{
	if(target == this)
	{
		for(int i = 0; i < BANK_SLOT_BAG_END; i++)
		{
			if(m_items[i] == NULL)
			{
				continue;
			}
			if(m_items[i]->pContainer)
			{
				for(int e=0; e < m_items[i]->pContainer->GetProto()->ContainerSlots; e++)
				{
					Item *item = m_items[i]->pContainer->GetItem(e);
					if(item)
					{
						if(item->pContainer)
						{
							item->pContainer->DestroyForPlayer( target );
						}
						else
						{
							item->DestroyForPlayer( target );
						}
					}
				}
				m_items[i]->pContainer->DestroyForPlayer( target );
			}
			else
			{
				m_items[i]->DestroyForPlayer( target );
			}
		}
	}
	Unit::DestroyForPlayer( target );
}


void Player::SaveToDB()
{
	//1.9.2 wowd new save system based on Base Object field system.
	//This object can be updated at anytime for specific savings :P

	_SaveAffects(); //affects saving so they are applyed later at login

	//SQL player data saving.
	//ToDo: Optimize Sql cpu usage before commiting

	std::stringstream ss;
	ss << "DELETE FROM characters WHERE guid = " << GetGUIDLow();
	sDatabase.Execute( ss.str( ).c_str( ) );
    
    SetBaseUInt32Value(PLAYER_FIELD_COINAGE,GetUInt32Value(PLAYER_FIELD_COINAGE));




	ss.rdbuf()->str("");
	ss << "INSERT INTO characters (guid, acct, name, mapId, zoneId, positionX, positionY, positionZ, orientation, data, taximask, banned,bindpositionX,bindpositionY,bindpositionZ,bindmapId,bindzoneId,isResting,restState,restTime) VALUES ("
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
		ss << GetBaseUInt32Value(i) << " ";

	ss << "', '";

	for( i = 0; i < 8; i++ )
		ss << m_taximask[i] << " ";

	ss << "', "; 

	ss << m_banned << ", "
		<< m_bind_pos_x << ", "
		<< m_bind_pos_y << ", "
		<< m_bind_pos_z << ", "
		<< m_bind_mapid << ","
		<< m_bind_zoneid << ", "
		<< uint32(m_isResting) << ", "
		<< uint32(m_restState) << ", "
		<< uint32(m_restAmount) << ")";

	sDatabase.Execute( ss.str().c_str() );

	//Save Other related player stuff

	// Mail
	_SaveMail();

	// bids
	_SaveBids();

	// Auctions
	_SaveAuctions();

	// Inventory
	_SaveInventory();

	// save quest progress
	_SaveQuestLogEntry();

	// save finished quests
	_SaveFinishedQuests();

	// Spells
	_SaveSpells();

	// Action bar
	_SaveActions();

	// Tutorials
	_SaveTutorials();

	// Reputation
	_SaveReputation();

	// GM Ticket
	objmgr.SaveGMTicket(GetGUID());

	// Charters //i find here most dynamic
	objmgr.SaveCharters(GetGUID());

	// Guild
	SaveGuild();

	// Charters
	SaveCharters();

	// Friendlist
	_SaveFriendList();
}

void Player::_SaveQuestLogEntry()
{
	std::stringstream query;
	int i;
	std::map<uint32, uint8>::iterator it2;
	std::map<uint32, QuestLogEntry *>::iterator it;

	query << "DELETE FROM questlog WHERE player_guid = " << GetGUIDLow();
	sDatabase.Execute( query.str().c_str( ) );

	for (it = m_questentry.begin(); it != m_questentry.end(); it++)
	{
		if ((it)->second)
		{
			uint32 quest_id = (it)->second->GetQuest()->GetID();
			uint64 questgiver_guid = (it)->second->GetQuestGiver();

			query.rdbuf()->str("");

			query <<  "INSERT INTO questlog (player_guid, quest_id, questgiver_guid, item_entry_1, " <<
				"item_picked_1, item_entry_2, item_picked_2, item_entry_3, item_picked_3, item_entry_4, item_picked_4, " <<
				"mob_entry_1, mob_killed_1, mob_entry_2, mob_killed_2, mob_entry_3, mob_killed_3, mob_entry_4, mob_killed_4)";

			query << " VALUES ( " << GetGUIDLow() << ", " << quest_id << ", " << questgiver_guid;

			i = 0;
			for(it2 = it->second->GetItemBegin(); it2 != it->second->GetItemEnd(); it2++)
			{
				i++;
				query << ", " << it2->first << ", " << uint32(it2->second);
			}

			while(i < 4)
			{
				query << ", 0, 0";
				i++;
			}

			i = 0;
			for(it2 = it->second->GetMobBegin(); it2 != it->second->GetMobEnd(); it2++)
			{
				i++;
				query << ", " << it2->first << ", " << uint32(it2->second);
			}

			while(i < 4)
			{
				query << ", 0, 0";
				i++;
			}

			query << " )";

			sDatabase.Execute( query.str().c_str( ) );
		}
	}
}

void Player::_SaveFinishedQuests()
{
	std::stringstream query;
	std::set<uint32>::iterator itr;

	query << "DELETE FROM finished_quests WHERE player_guid = " << GetGUIDLow();
	sDatabase.Execute( query.str().c_str( ) );

	for(itr = m_finishedQuests.begin(); itr != m_finishedQuests.end(); itr++)
	{
		query.rdbuf()->str("");
		query << "INSERT INTO finished_quests (player_guid, quest_id) VALUES (" <<
			GetGUIDLow() << ", " << (*itr) << ")";

		sDatabase.Execute( query.str().c_str( ) );
	}
}

void Player::_SaveInventory()
{
	std::stringstream delinvq;
	delinvq << "DELETE FROM inventory WHERE player_guid = " << GetGUIDLow(); // TODO: use full guids
	sDatabase.Execute( delinvq.str().c_str( ) );

	for(unsigned int i = 0; i < BANK_SLOT_BAG_END; i++)
	{
		if (m_items[i])
		{
			m_items[i]->SaveToDB();

			std::stringstream invq;
			invq <<  "INSERT INTO inventory (player_guid, slot, item_guid) VALUES ( " <<
				GetGUIDLow() << ", " << i << ", " << m_items[i]->GetGUIDLow() << " )";

			sDatabase.Execute( invq.str().c_str( ) );
			if(m_items[i]->pContainer)
			{
				m_items[i]->pContainer->SaveBagToDB(i);
			}
		}
	}
}


void Player::_SaveSpells()
{
	std::stringstream query;
	query << "DELETE FROM char_spells WHERE charId = " << GetGUIDLow(); // TODO: use full guids
	sDatabase.Execute( query.str().c_str() );

	std::list<struct spells>::iterator itr;
	for (itr = m_spells.begin(); itr != m_spells.end(); ++itr)
	{
		query.rdbuf()->str("");
		query << "INSERT INTO char_spells (charId,spellId,slotId) VALUES ( "
			<< GetGUIDLow() << ", " << itr->spellId << ", " << itr->slotId << " )";

		sDatabase.Execute( query.str().c_str() );
	}
}

void Player::_SaveActions()
{
	std::stringstream query;
	query << "DELETE FROM char_actions WHERE charId=" << GetGUIDLow();
	sDatabase.Execute( query.str().c_str() );

	std::list<struct actions>::iterator itr;
	for (itr = m_actions.begin(); itr != m_actions.end(); ++itr)
	{
		query.rdbuf()->str("");
		query << "INSERT INTO char_actions (charId,button,action,type,misc) VALUES ( ";
		query << GetGUIDLow() << "," << int(itr->button) << "," << int(itr->action);
		query << "," << int(itr->type) << "," << int(itr->misc) << ")" << '\0';

		sDatabase.Execute( query.str().c_str() );
	}
}


void Player::_SaveAffects()
{
	AffectList::iterator i;

	std::stringstream query1;
	query1 << "DELETE FROM affects WHERE charId=" << GetGUIDLow();
	sDatabase.Execute( query1.str().c_str() );

	for (i = m_affects.begin(); i != m_affects.end(); i++)
	{
		std::stringstream query;
		printf("saving spell %u\n",(*i)->GetId());
		query << "INSERT INTO affects (charId,spell,dur) VALUES ( ";
		query << GetGUIDLow() << "," << (*i)->GetId() << "," << (*i)->GetDuration();
		query <<  ")" << '\0';

		sDatabase.Execute( query.str().c_str() );
		query.clear();
	}
}


// NOTE: 32bit guids are only for compatibility with older bases.
void Player::LoadFromDB( uint32 guid )
{
	std::stringstream ss;
	ss << "SELECT * FROM characters WHERE guid=" << guid;

	QueryResult *result = sDatabase.Query( ss.str().c_str() );
	ASSERT(result);

	Field *fields = result->Fetch();

	Object::_Create( guid, HIGHGUID_PLAYER );

	LoadValues( fields[2].GetString() );

	// TODO: check for overflow
	m_name = fields[3].GetString();

	m_positionX = fields[4].GetFloat();
	m_positionY = fields[5].GetFloat();
	m_positionZ = fields[6].GetFloat();
	m_mapId = fields[7].GetUInt32();
	m_zoneId = fields[8].GetUInt32();
	m_orientation = fields[9].GetFloat();

	ZoneIDMap.SetZoneBitOn(m_zoneId);

	if( HasFlag(PLAYER_FLAGS, 0x10) )
		m_deathState = DEAD;

	LoadTaxiMask( fields[10].GetString() );

	m_banned = fields[11].GetUInt32(); //Character ban

	m_bind_pos_x = fields[14].GetFloat();
	m_bind_pos_y = fields[15].GetFloat();
	m_bind_pos_z = fields[16].GetFloat();
	m_bind_mapid = fields[17].GetUInt32();
	m_bind_zoneid = fields[18].GetUInt32();

	m_isResting = fields[19].GetUInt8();
	m_restState = fields[20].GetUInt8();
	m_restAmount = fields[21].GetUInt32();

	delete result;

	/*
	m_outfitId = atoi( row[ 11 ] );
	m_guildId = atoi( row[ 17 ] );
	m_petInfoId = atoi( row[ 18 ] );
	m_petLevel = atoi( row[ 19 ] );
	m_petFamilyId = atoi( row[ 20 ] );
	*/
}

void Player::LoadPropertiesFromDB()
{
	_LoadTutorials();
    
    _LoadMail();

    _LoadInventory();

    _LoadSpells();

	_LoadActions();

    _LoadQuestLogEntry();

    _LoadFinishedQuests();

    _LoadReputation();

	_LoadBids();

    _LoadAffects();

    _LoadGuild();

    _LoadCharters();

    _LoadFriendList();

    _LoadPet();

    _ApplyAllAffectMods();
    _ApplyAllItemMods();

    // init Stat Listener
    s_stats[0] = GetUInt32Value(UNIT_FIELD_STAT0);
    s_stats[1] = GetUInt32Value(UNIT_FIELD_STAT1);
    s_stats[2] = GetUInt32Value(UNIT_FIELD_STAT2);
    s_stats[3] = GetUInt32Value(UNIT_FIELD_STAT3);
    s_stats[4] = GetUInt32Value(UNIT_FIELD_STAT4);
    // init Faction
    _setFaction();
}

void Player::LoadEnumFromDB()
{
    _LoadInventory();

  //  _ApplyAllItemMods();
}

void Player::LoadNamesFromDB( uint32 guid )
{
	std::stringstream ss;
	ss << "SELECT * FROM characters WHERE guid=" << guid;

	QueryResult *result = sDatabase.Query( ss.str().c_str() );
	ASSERT(result);

	Field *fields = result->Fetch();

	Object::_Create( guid, HIGHGUID_PLAYER );

	LoadValues( fields[2].GetString() );

	// TODO: check for overflow
	m_name = fields[3].GetString();
}

void Player::_LoadBagInventory(uint32 playerguid, uint8 bagslot)
{
	bool chck = FALSE;
	std::stringstream invq;
	invq << "SELECT player_guid, bagslot, slot, item_guid FROM bag_inventory WHERE bagslot=" << (uint32)bagslot << " AND player_guid=" << playerguid;

	QueryResult *result = sDatabase.Query( invq.str().c_str() );
	if(result)
	{
		do
		{
			Field *fields = result->Fetch();
			Item* item = new Item;
			chck = item->LoadFromDB(fields[3].GetUInt32(),1);
			if(chck)
				m_items[bagslot]->pContainer->AddItem((uint8)fields[2].GetUInt16(), item);
		}
		while( result->NextRow() );

		delete result;
	}
}

void Player::_LoadInventory()
{
	bool chck = TRUE;
	uint8 slot;
	// Clean current inventory
	for(uint16 i = 0; i < BANK_SLOT_BAG_END; i++)
	{
		if(m_items[i])
		{
			delete m_items[i];
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

			Item* item = new Item;
			chck = item->LoadFromDB(fields[0].GetUInt32(),1);
			//item->SetUInt32Value(ITEM_FIELD_ENCHANTMENT,239);
			//item->SetUInt32Value(ITEM_FIELD_ENCHANTMENT_01,35);
			if (chck)
			{
				AddItemToSlot( (uint8)fields[1].GetUInt16(), item);
				slot = (uint8)fields[1].GetUInt16();
				_LoadBagInventory(GetGUIDLow(),slot);
			}
			else
			{
                std::stringstream query;
                query << "DELETE FROM inventory WHERE item_guid=" << fields[0].GetUInt32();
                sDatabase.Execute( query.str().c_str() );
                delete item;
				chck = TRUE;
			}

		}
		while( result->NextRow() );

		delete result;
	}
}
bool Player::HasSpell(uint32 spell)
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

}
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

			addSpell(fields[0].GetUInt16(), fields[1].GetUInt16());
		}
		while( result->NextRow() );

		delete result;
	}
}

void Player::_LoadActions()
{
	//Clear Actions List
	m_actions.clear();

	//Actions
	std::stringstream query;
	query << "SELECT * FROM char_actions WHERE charId=" << GetGUIDLow() << " ORDER BY button";
	QueryResult *result = sDatabase.Query( query.str().c_str() );
	if(result)
	{
		do
		{
			Field *fields = result->Fetch();

			addAction(fields[1].GetUInt8(), fields[2].GetUInt16(), fields[3].GetUInt8(), fields[4].GetUInt8());
		}
		while( result->NextRow() );

		delete result;
	}
}

void Player::_LoadQuestLogEntry()
{
	// Quest Log Entry's
	std::map<uint32, uint8>::iterator itr;
	std::stringstream qle_query;
	qle_query << "SELECT * FROM questlog WHERE player_guid=" << GetGUIDLow();
	int i;
	uint32 update_value = 0;

	ResetQuestSlots();

	QueryResult *result = sDatabase.Query( qle_query.str().c_str() );

	if(result)
	{
		do
		{
			Field *fields = result->Fetch();
			QuestLogEntry *QLE = new QuestLogEntry();

			QLE->Init(sQuestMgr.FindQuest(fields[2].GetUInt32()),
				fields[3].GetUInt64());

			if(QLE->GetQuest() && QLE->GetQuestGiver())
			{

				for(i = 0; i < 4; i++)
				{
					QLE->AddItem( fields[4 + i].GetUInt32(), fields[8 + i].GetUInt8());
					QLE->AddMob( fields[12 + i].GetUInt32(), fields[16 + i].GetUInt8());
				}

				Add_QLE(QLE);

				uint16 log_slot = GetOpenQuestSlot();
				SetUInt32Value(log_slot, QLE->GetQuest()->GetID());

				i = 0;

				//Add mob questlog value
				for(itr = QLE->GetMobBegin(); itr != QLE->GetMobEnd(); itr++)
				{
					update_value += (itr->second) * (1 << (i*6));
					i++;
				}

				SetUInt32Value(log_slot + 1, update_value);
			}
			else
			{
				Log::getSingleton( ).outDebug( "WORLD: Bad QuestLogEntry!" );
				delete QLE;
			}
		}
		while( result->NextRow() );

		delete result;
	}
}

void Player::_LoadFinishedQuests()
{
	std::stringstream query;
	query << "SELECT * FROM finished_quests WHERE player_guid=" << GetGUIDLow();
	QueryResult *result = sDatabase.Query( query.str().c_str() );

	if (result)
	{
		do
		{
			Field *fields = result->Fetch();
			this->m_finishedQuests.insert(fields[1].GetUInt32());
		} while( result->NextRow() );

		delete result;
	}
}

void Player::_LoadAffects()
{
	//Affects
	std::stringstream query;
	query << "SELECT * FROM affects WHERE charId=" << GetGUIDLow();
	QueryResult *result = sDatabase.Query( query.str().c_str() );
	if(result)
	{
		do
		{
			Field *fields = result->Fetch();
			addLoadAff(fields[1].GetUInt32(),fields[2].GetUInt32());

		}
		while( result->NextRow() );

		delete result;
	}
}

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

	ss.rdbuf()->str("");
	ss << "DELETE FROM bag_inventory WHERE player_guid = " << GetGUIDLow();
	sDatabase.Execute( ss.str( ).c_str( ) );

	ss.rdbuf()->str("");
	ss << "DELETE FROM char_reputation WHERE charId=" << GetGUIDLow();
	sDatabase.Execute( ss.str().c_str() );


	for(int i = 0; i < BANK_SLOT_ITEM_END; i++)
	{
		if(m_items[i] == NULL)
			continue;

		m_items[i]->DeleteFromDB();
	}

	ss.rdbuf()->str("");
	ss << "DELETE FROM queststatus WHERE playerId = " << GetGUIDLow();
	sDatabase.Execute( ss.str( ).c_str( ) );

	ss.rdbuf()->str("");
	ss << "DELETE FROM char_actions WHERE charId = " << GetGUIDLow();
	sDatabase.Execute( ss.str( ).c_str( ) );

	ss.rdbuf()->str("");
	ss << "DELETE FROM playerguilds WHERE playerId = " << GetGUIDLow();
	sDatabase.Execute( ss.str( ).c_str( ) );

	ss.rdbuf()->str("");
	ss << "DELETE FROM playercharters WHERE playerId = " << GetGUIDLow();
	sDatabase.Execute( ss.str( ).c_str( ) );
}

uint8 Player::FindFreeBagSlot(uint8 BagSlot)
{
	Item *item = GetItemBySlot(BagSlot);
	if(item)
	{
		if(item->pContainer)
		{
			uint8 slot = item->pContainer->FindFreeSlot();
			if(slot != CONTAINER_NO_SLOT_AVAILABLE) { return slot; }
		}
	}
	return CONTAINER_NO_SLOT_AVAILABLE; //no slots available
}

Item* Player::FindItemLessMax(uint32 id, uint32 cnt)
{
	/* figured Id need to add a comment as the name is misleading
	basically just finds the iteim in yer inv that can have cnt many items added to its stack
	used for tradeskills, looting and stuff*/
	int i = 0;
	for(i = INVENTORY_SLOT_ITEM_START; i < INVENTORY_SLOT_ITEM_END; i++)
	{
		Item *item = GetItemBySlot(i);
		if (item)
		{
			if((item->GetProto()->ItemId == id) && (item->GetProto()->MaxCount >= (item->GetUInt32Value(ITEM_FIELD_STACK_COUNT) + cnt)))
			{
				return item; 
			}
		}
	}
	for(i = INVENTORY_SLOT_BAG_START; i < INVENTORY_SLOT_BAG_END; i++)
	{
		Item *item = GetItemBySlot(i);
		if(item)
		{
			if(item->pContainer)
			{
				for (int j =0; j < item->GetProto()->ContainerSlots;j++)
				{
					Item *item2 = item->pContainer->GetItem(j);
					if (item2)
					{
						if((item2->GetProto()->ItemId == id) && (item2->GetProto()->MaxCount >= (item2->GetUInt32Value(ITEM_FIELD_STACK_COUNT) + cnt)))
						{
							return item2;
						}
					}
				}
			}
		}
	}
	return 0;
}
uint8 Player::FindBagWithFreeSlots()
{
	for(int i = INVENTORY_SLOT_BAG_START; i < INVENTORY_SLOT_BAG_END; i++)
	{
		Item *item = GetItemBySlot(i);
		if(item)
		{
			if(item->pContainer)
			{
				uint8 slot = item->pContainer->FindFreeSlot();
				if(slot != CONTAINER_NO_SLOT_AVAILABLE) { return i; }
			}
		}
		//return NULL; //no slots available //more then 1 bag :P
	}
	return NULL;
}

uint8 Player::FindFreeInvSlot()
{
	//search for backpack slots
	for(int i = INVENTORY_SLOT_ITEM_START; i < INVENTORY_SLOT_ITEM_END; i++)
	{
		Item *item = GetItemBySlot(i);
		if(!item) { return i; }
	}

	return INVENTORY_NO_SLOT_AVAILABLE; //no slots available
}
void Player::RemoveBuyBackItem(uint32 index)
{
	int j = 0;
	for (j = index;j < 11;j++)
	{
		if (GetUInt64Value(PLAYER_FIELD_VENDORBUYBACK_SLOT_1 + (j*2)) != 0)
		{
			SetUInt64Value(PLAYER_FIELD_VENDORBUYBACK_SLOT_1 + (2*j),GetUInt64Value(PLAYER_FIELD_VENDORBUYBACK_SLOT_1 + ((j+1)*2)));
			SetUInt32Value(PLAYER_FIELD_BUYBACK_PRICE_1 + j,GetUInt32Value(PLAYER_FIELD_BUYBACK_PRICE_1 + j+1));
			SetUInt32Value(PLAYER_FIELD_BUYBACK_TIMESTAMP_1 + j,GetUInt32Value(PLAYER_FIELD_BUYBACK_TIMESTAMP_1 + j+1));
			if ((buyback[j+1] != NULL) && (GetUInt64Value(PLAYER_FIELD_VENDORBUYBACK_SLOT_1 + ((j+1)*2)) != 0))
			{
				buyback[j] = buyback[j+1];
			} else
			{
				buyback[j] = NULL;
				printf("nulling %u\n",(j));
			}
		}
		else
			return;
	}
	j = 11;
	SetUInt64Value(PLAYER_FIELD_VENDORBUYBACK_SLOT_1 + (2*j),GetUInt64Value(PLAYER_FIELD_VENDORBUYBACK_SLOT_1 + ((j+1)*2)));
	SetUInt32Value(PLAYER_FIELD_BUYBACK_PRICE_1 + j,GetUInt32Value(PLAYER_FIELD_BUYBACK_PRICE_1 + j+1));
	SetUInt32Value(PLAYER_FIELD_BUYBACK_TIMESTAMP_1 + j,GetUInt32Value(PLAYER_FIELD_BUYBACK_TIMESTAMP_1 + j+1));
	buyback[11] = NULL;
}
void Player::AddBuyBackItem(Item *it,uint32 price)
{
	int i;
	if ((buyback[11] != NULL) && (GetUInt64Value(PLAYER_FIELD_VENDORBUYBACK_SLOT_1 + 22) != 0))
	{
		if(buyback[0] != NULL)
		{
			buyback[0]->DeleteFromDB();
			buyback[0]->DestroyForPlayer(this);
			delete buyback[0];
		}

		for (int j = 0;j < 11;j++)
		{
			//SetUInt64Value(PLAYER_FIELD_VENDORBUYBACK_SLOT_1 + (2*j),buyback[j+1]->GetGUID());
			SetUInt64Value(PLAYER_FIELD_VENDORBUYBACK_SLOT_1 + (2*j),GetUInt64Value(PLAYER_FIELD_VENDORBUYBACK_SLOT_1 + ((j+1)*2) ) );
			SetUInt32Value(PLAYER_FIELD_BUYBACK_PRICE_1 + j,GetUInt32Value(PLAYER_FIELD_BUYBACK_PRICE_1 + j+1));
			SetUInt32Value(PLAYER_FIELD_BUYBACK_TIMESTAMP_1 + j,GetUInt32Value(PLAYER_FIELD_BUYBACK_TIMESTAMP_1 + j+1));
			buyback[j] = buyback[j+1];
		}
		buyback[11] = it;
		if(buyback[11]->pContainer)
			SetUInt64Value(PLAYER_FIELD_VENDORBUYBACK_SLOT_1 + (2*(11)),buyback[11]->pContainer->GetGUID());
		else
			SetUInt64Value(PLAYER_FIELD_VENDORBUYBACK_SLOT_1 + (2*(11)),buyback[11]->GetGUID());
		SetUInt32Value(PLAYER_FIELD_BUYBACK_PRICE_1 + 11,price);
		SetUInt32Value(PLAYER_FIELD_BUYBACK_TIMESTAMP_1 + 11,time(NULL));
		return;
	}
	for(i=0; i < 24;i+=2)
	{
		if((GetUInt32Value(PLAYER_FIELD_VENDORBUYBACK_SLOT_1 + i) == 0) || (buyback[i/2] == NULL))
		{
			printf("setting buybackslot %u\n",i/2);
			buyback[i/2] = it;
			if(buyback[i/2]->pContainer)
				SetUInt64Value(PLAYER_FIELD_VENDORBUYBACK_SLOT_1 + i,buyback[i/2]->pContainer->GetGUID());
			else
				SetUInt64Value(PLAYER_FIELD_VENDORBUYBACK_SLOT_1 + i,buyback[i/2]->GetGUID());
			//SetUInt64Value(PLAYER_FIELD_VENDORBUYBACK_SLOT_1 + i,it->GetGUID());
			SetUInt32Value(PLAYER_FIELD_BUYBACK_PRICE_1 + (i/2),price);
			SetUInt32Value(PLAYER_FIELD_BUYBACK_TIMESTAMP_1 + (i/2),time(NULL));
			return;
		}
	}
}
uint32 Player::GetItemCount(uint32 id)
{
	/* id of 0 returns Free Slots*/
	uint32 cnt = 0;
	int i = 0;
	for(i = INVENTORY_SLOT_ITEM_START; i < INVENTORY_SLOT_ITEM_END; i++)
	{
		Item *item = GetItemBySlot(i);
		if(id != 0)
		{
			if (item)
			{
				if(item->GetProto()->ItemId == id)
				{
					cnt += item->GetUInt32Value(ITEM_FIELD_STACK_COUNT); 
				}
			}
		}
		else
		{
			if (!item)
				cnt += 1;
		}
	}
	for(i = INVENTORY_SLOT_BAG_START; i < INVENTORY_SLOT_BAG_END; i++)
	{
		Item *item = GetItemBySlot(i);
		if(item)
		{
			if(item->pContainer)
			{
				for (int j =0; j < item->GetProto()->ContainerSlots;j++)
				{
					Item *item2 = item->pContainer->GetItem(j);
					if(id != 0)
					{
						if (item2)
						{
							if (item2->GetProto()->ItemId == id)
							{
								cnt += item2->GetUInt32Value(ITEM_FIELD_STACK_COUNT); 
							}
						}
					}
					else
					{
						if (!item2)
							cnt += 1;
					}
				}
			}
		}
	}
	return cnt;
}
bool Player::RemoveItemAmt(uint32 id, uint32 amt)
{
	if (GetItemCount(id) < amt)
	{
		return false;
	}
	int i = 0;
	for(i = INVENTORY_SLOT_ITEM_START; i < INVENTORY_SLOT_ITEM_END; i++)
	{
		Item *item = GetItemBySlot(i);
		if (item)
		{
			if(item->GetProto()->ItemId == id)
			{
				if (item->GetUInt32Value(ITEM_FIELD_STACK_COUNT) > amt)
				{
					item->SetUInt32Value(ITEM_FIELD_STACK_COUNT,item->GetUInt32Value(ITEM_FIELD_STACK_COUNT) - amt);
				}
				else if (item->GetUInt32Value(ITEM_FIELD_STACK_COUNT)== amt)
				{
					RemoveItemFromSlot(i);
					return true;
				} else
				{
					amt -= item->GetUInt32Value(ITEM_FIELD_STACK_COUNT);
					RemoveItemFromSlot(i);
				}
			}
		}
	}
	for(i = INVENTORY_SLOT_BAG_START; i < INVENTORY_SLOT_BAG_END; i++)
	{
		Item *item = GetItemBySlot(i);
		if(item)
		{
			if(item->pContainer)
			{
				for (int j =0; j < item->GetProto()->ContainerSlots;j++)
				{
					Item *item2 = item->pContainer->GetItem(j);
					if (item2)
					{
						if (item2->GetProto()->ItemId == id)
						{
							if (item2->GetUInt32Value(ITEM_FIELD_STACK_COUNT) > amt)
							{
								item2->SetUInt32Value(ITEM_FIELD_STACK_COUNT,item2->GetUInt32Value(ITEM_FIELD_STACK_COUNT) - amt);
							}
							else if (item2->GetUInt32Value(ITEM_FIELD_STACK_COUNT)== amt)
							{
								item->pContainer->RemoveItemFromSlot(j);
								return true;
							} else
							{
								amt -= item2->GetUInt32Value(ITEM_FIELD_STACK_COUNT);
								item->pContainer->RemoveItemFromSlot(j);
							}
						}
					}
				}
			}
		}
	}
	return false;
}
uint8 Player::GetItemSlotByType(uint32 type)
{
	switch(type)
	{
	case INVTYPE_NON_EQUIP:
		return INVENTORY_SLOT_ITEM_END; 
	case INVTYPE_HEAD:
		{
			return EQUIPMENT_SLOT_HEAD;
		}
	case INVTYPE_NECK:
		{
			return EQUIPMENT_SLOT_NECK;
		}
	case INVTYPE_SHOULDERS:
		{
			return EQUIPMENT_SLOT_SHOULDERS;
		}
	case INVTYPE_BODY:
		{
			return EQUIPMENT_SLOT_BODY;
		}
	case INVTYPE_CHEST:
		{
			return EQUIPMENT_SLOT_CHEST;
		}
	case INVTYPE_ROBE: // ???
		{
			return EQUIPMENT_SLOT_CHEST;
		}
	case INVTYPE_WAIST:
		{
			return EQUIPMENT_SLOT_WAIST;
		}
	case INVTYPE_LEGS:
		{
			return EQUIPMENT_SLOT_LEGS;
		}
	case INVTYPE_FEET:
		{
			return EQUIPMENT_SLOT_FEET;
		}
	case INVTYPE_WRISTS:
		{
			return EQUIPMENT_SLOT_WRISTS;
		}
	case INVTYPE_HANDS:
		{
			return EQUIPMENT_SLOT_HANDS;
		}
	case INVTYPE_FINGER:
		{
			if (!GetItemBySlot(EQUIPMENT_SLOT_FINGER1))
				return EQUIPMENT_SLOT_FINGER1;
			else if (!GetItemBySlot(EQUIPMENT_SLOT_FINGER2))
				return EQUIPMENT_SLOT_FINGER2;
			else
				return EQUIPMENT_SLOT_FINGER1; //auto equips always in finger 1
		}
	case INVTYPE_TRINKET:
		{
			if (!GetItemBySlot(EQUIPMENT_SLOT_TRINKET1))
				return EQUIPMENT_SLOT_TRINKET1;
			else if (!GetItemBySlot(EQUIPMENT_SLOT_TRINKET2))
				return EQUIPMENT_SLOT_TRINKET2;
			else
				return EQUIPMENT_SLOT_TRINKET1; //auto equips always on trinket 1
		}
	case INVTYPE_CLOAK:
		{
			return EQUIPMENT_SLOT_BACK;
		}
	case INVTYPE_WEAPON:
		{
			if (!GetItemBySlot(EQUIPMENT_SLOT_MAINHAND) )
				return EQUIPMENT_SLOT_MAINHAND;
			else if(!GetItemBySlot(EQUIPMENT_SLOT_OFFHAND))
				return EQUIPMENT_SLOT_OFFHAND;
			else
				return EQUIPMENT_SLOT_MAINHAND;
		}
	case INVTYPE_SHIELD:
		{
			return EQUIPMENT_SLOT_OFFHAND;
		}
	case INVTYPE_RANGED:
		{
			return EQUIPMENT_SLOT_RANGED;
		}
	case INVTYPE_2HWEAPON:
		{
			return EQUIPMENT_SLOT_MAINHAND;
		}
	case INVTYPE_TABARD:
		{
			return EQUIPMENT_SLOT_TABARD;
		}
	case INVTYPE_WEAPONMAINHAND:
		{
			return EQUIPMENT_SLOT_MAINHAND;
		}
	case INVTYPE_WEAPONOFFHAND:
		{
			return EQUIPMENT_SLOT_OFFHAND;
		}
	case INVTYPE_HOLDABLE:
		{
			return EQUIPMENT_SLOT_MAINHAND;
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
			return INVENTORY_NO_SLOT_AVAILABLE; //bags are not suposed to be auto-equiped when slots are not free
		}
	default:
		ASSERT(0);
		return INVENTORY_NO_SLOT_AVAILABLE;
	}
}


uint8 Player::CanEquipItemInSlot(uint8 slot, ItemPrototype *proto)
{
	uint32 type=proto->InventoryType;

	// Check to see if we have the correct race
	if(!(proto->AllowableRace& (1<<getRace())))
		return INV_ERR_YOU_CAN_NEVER_USE_THAT_ITEM;

	// Check to see if we have the correct class
	if(!(proto->AllowableClass& (1<<getClass())))
		return INV_ERR_YOU_CAN_NEVER_USE_THAT_ITEM2;

	// Check to see if we have the correct level.
	if(proto->RequiredLevel>GetUInt32Value(UNIT_FIELD_LEVEL))
		return INV_ERR_YOU_MUST_REACH_LEVEL_N;

	int SubClassSkill = 0;

	if(proto->Class == 4 && proto->SubClass < 7)
	{
		switch(proto->SubClass)
		{
		// Armors
		case 0:	// misc
			SubClassSkill = 0;
			break;
		case 1:	// cloth
			SubClassSkill = 415;
			break;		
		case 2:	// leather
			SubClassSkill = 414;
			break;
		case 3:	// mail
			SubClassSkill = 413;
			break;		
		case 4:	// plate mail
			SubClassSkill = 293;
			break;
		case 5:	// buckler
			SubClassSkill = 0;
			break;		
		case 6:	// shield
			SubClassSkill = 433;
			break;
		}
	} else if(proto->Class == 2 && proto->SubClass < 21)
	{
		switch(proto->SubClass)
		{
		// Weapons
		case 0:	// 1 handed axes
			SubClassSkill = 44;
			break;
		case 1:	// 2 handed axes
			SubClassSkill = 172;
			break;		
		case 2:	// bows
			SubClassSkill = 45;
			break;
		case 3:	// guns
			SubClassSkill = 46;
			break;		
		case 4:	// 1 handed mace
			SubClassSkill = 54;
			break;
		case 5:	// 2 handed mace
			SubClassSkill = 160;
			break;		
		case 6:	// polearms
			SubClassSkill = 229;
			break;
		case 7: // 1 handed sword
			SubClassSkill = 43;
			break;
		case 8: // 2 handed sword
			SubClassSkill = 55;
			break;
		case 9: // obsolete
			SubClassSkill = 136;
			break;
		case 10: //1 handed exotic
			SubClassSkill = 0;
			break;
		case 11: // 2 handed exotic
			SubClassSkill = 0;
			break;
		case 12: // fist
			SubClassSkill = 473;
			break;
		case 13: // misc
			SubClassSkill = 0;
			break;
		case 15: // daggers
			SubClassSkill = 173;
			break;
		case 16: // thrown
			SubClassSkill = 176;
			break;
		case 17: // spears
			SubClassSkill = 227;
			break;
		case 18: // crossbows
			SubClassSkill = 226;
			break;
		case 19: // wands
			SubClassSkill = 228;
			break;
		case 20: // fishing
			SubClassSkill = 356;
			break;
		}
	}
    // removed those loops, use the skill lookup functions
	if (proto->RequiredSkillRank < GetSkillAmt(proto->RequiredSkill))
		return INV_ERR_NO_REQUIRED_PROFICIENCY;
	if(SubClassSkill)
	{
		if(!GetSkillAmt(SubClassSkill))
			return INV_ERR_NO_REQUIRED_PROFICIENCY;
	}
	// You are dead !
	if(m_deathState == DEAD)
		return INV_ERR_YOU_ARE_DEAD;
	switch(slot)
	{
	case EQUIPMENT_SLOT_HEAD:
		{
			if(type == INVTYPE_HEAD)
				return 0;
			else
				return INV_ERR_ITEM_DOESNT_GO_TO_SLOT;
		}
	case EQUIPMENT_SLOT_NECK:
		{
			if(type == INVTYPE_NECK)
				return 0;
			else
				return INV_ERR_ITEM_DOESNT_GO_TO_SLOT;
		}
	case EQUIPMENT_SLOT_SHOULDERS:
		{
			if(type == INVTYPE_SHOULDERS)
				return 0;
			else
				return INV_ERR_ITEM_DOESNT_GO_TO_SLOT;
		}
	case EQUIPMENT_SLOT_BODY:
		{
			if(type == INVTYPE_BODY)
				return 0;
			else
				return INV_ERR_ITEM_DOESNT_GO_TO_SLOT;
		}
	case EQUIPMENT_SLOT_CHEST:
		{
			if(type == INVTYPE_CHEST || type == INVTYPE_ROBE)
				return 0;
			else
				return INV_ERR_ITEM_DOESNT_GO_TO_SLOT;
		}
	case EQUIPMENT_SLOT_WAIST:
		{
			if(type == INVTYPE_WAIST)
				return 0;
			else
				return INV_ERR_ITEM_DOESNT_GO_TO_SLOT;
		}
	case EQUIPMENT_SLOT_LEGS:
		{
			if(type == INVTYPE_LEGS)
				return 0;
			else
				return INV_ERR_ITEM_DOESNT_GO_TO_SLOT;
		}
	case EQUIPMENT_SLOT_FEET:
		{
			if(type == INVTYPE_FEET)
				return 0;
			else
				return INV_ERR_ITEM_DOESNT_GO_TO_SLOT;
		}
	case EQUIPMENT_SLOT_WRISTS:
		{
			if(type == INVTYPE_WRISTS)
				return 0;
			else
				return INV_ERR_ITEM_DOESNT_GO_TO_SLOT;
		}
	case EQUIPMENT_SLOT_HANDS:
		{
			if(type == INVTYPE_HANDS)
				return 0;
			else
				return INV_ERR_ITEM_DOESNT_GO_TO_SLOT;
		}
	case EQUIPMENT_SLOT_FINGER1:
	case EQUIPMENT_SLOT_FINGER2:
		{
			if(type == INVTYPE_FINGER)
				return 0;
			else
				return INV_ERR_ITEM_DOESNT_GO_TO_SLOT;
		}
	case EQUIPMENT_SLOT_TRINKET1:
	case EQUIPMENT_SLOT_TRINKET2:
		{
			if(type == INVTYPE_TRINKET)
				return 0;
			else
				return INV_ERR_ITEM_DOESNT_GO_TO_SLOT;
		}
	case EQUIPMENT_SLOT_BACK:
		{
			if(type == INVTYPE_CLOAK)
				return 0;
			else
				return INV_ERR_ITEM_DOESNT_GO_TO_SLOT;
		}
	case EQUIPMENT_SLOT_MAINHAND:
		{
			if(type == INVTYPE_WEAPON || type == INVTYPE_WEAPONMAINHAND || type == INVTYPE_HOLDABLE ||
				(type == INVTYPE_2HWEAPON && !GetItemBySlot(EQUIPMENT_SLOT_OFFHAND)))
				return 0;
			else
				return INV_ERR_ITEM_DOESNT_GO_TO_SLOT;
		}
	case EQUIPMENT_SLOT_OFFHAND:
		{
			if(type == INVTYPE_WEAPON || type == INVTYPE_SHIELD || type == INVTYPE_WEAPONOFFHAND)
			{
				Item* mainweapon = GetItemBySlot(EQUIPMENT_SLOT_MAINHAND);
				if(mainweapon) //item exists
				{
					// Check for dualWielding skill
					//                 Not Yet
					//		   if(getSkill(SKILL_DUAL_WIELDING))
					//		   else return 13;
				
					if(mainweapon->GetProto())
					{
						if(mainweapon->GetProto()->InventoryType != INVTYPE_2HWEAPON)
						{
							return 0;
						}
						else
							return INV_ERR_CANT_EQUIP_WITH_TWOHANDED;
					}
				}
				else
				{
					return 0;
				}
			}
			else
				return INV_ERR_ITEM_DOESNT_GO_TO_SLOT;
		}
	case EQUIPMENT_SLOT_RANGED:
		{
			if(type == INVTYPE_RANGED || type == INVTYPE_THROWN || type == INVTYPE_RANGEDRIGHT)
				return 0;
			else
				return INV_ERR_ITEM_DOESNT_GO_TO_SLOT;//6;
		}
	case EQUIPMENT_SLOT_TABARD:
		{
			if(type == INVTYPE_TABARD)
				return 0;
			else
				return INV_ERR_ITEM_DOESNT_GO_TO_SLOT; // 6;
		}
	case INVENTORY_SLOT_BAG_1:
	case INVENTORY_SLOT_BAG_2:
	case INVENTORY_SLOT_BAG_3:
	case INVENTORY_SLOT_BAG_4:
		{
			if(type == INVTYPE_BAG)
				return 0;
			else
				return INV_ERR_NOT_A_BAG;
		}
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
	case INVENTORY_SLOT_ITEM_16:
		{
			return 0;
		}
	default:
		return 0;
	}
}

void Player::SwapItemSlots(uint8 srcslot, uint8 dstslot)
{
	ASSERT(srcslot < BANK_SLOT_BAG_END);
	ASSERT(dstslot < BANK_SLOT_BAG_END);

	Item *temp;
	Item *temp2;
	temp2 = m_items[dstslot];
	temp = m_items[srcslot];

	if (temp2 && temp)
	{
		if ((temp->GetProto()->ItemId == temp2->GetProto()->ItemId) 
			&& (temp2->GetUInt32Value(ITEM_FIELD_STACK_COUNT) + temp->GetUInt32Value(ITEM_FIELD_STACK_COUNT) <= temp2->GetProto()->MaxCount))
		{
			RemoveItemFromSlot(srcslot);
			temp2->SetUInt32Value(ITEM_FIELD_STACK_COUNT,temp2->GetUInt32Value(ITEM_FIELD_STACK_COUNT) + temp->GetUInt32Value(ITEM_FIELD_STACK_COUNT));
			return;
		}
	}
	m_items[srcslot] = m_items[dstslot];
	m_items[dstslot] = temp;

	if( m_items[dstslot])
	{
		if((m_items[dstslot]->GetProto()->InventoryType == INVTYPE_BAG))
		{
			SetUInt64Value( (uint16)(PLAYER_FIELD_INV_SLOT_HEAD  + (dstslot*2)), m_items[dstslot]->pContainer->GetGUID());
		}
		else
		{
			SetUInt64Value( (uint16)(PLAYER_FIELD_INV_SLOT_HEAD  + (dstslot*2)),  m_items[dstslot]->GetGUID()  );
		}
	}
	else
	{
		SetUInt64Value( (uint16)(PLAYER_FIELD_INV_SLOT_HEAD  + (dstslot*2)), 0 );
	}

	if( m_items[srcslot])
	{
		if((m_items[srcslot]->GetProto()->InventoryType == INVTYPE_BAG))
		{
			SetUInt64Value( (uint16)(PLAYER_FIELD_INV_SLOT_HEAD  + (srcslot*2)),  m_items[srcslot]->pContainer->GetGUID()  );
		}
		else
		{
			SetUInt64Value( (uint16)(PLAYER_FIELD_INV_SLOT_HEAD  + (srcslot*2)), m_items[srcslot]->GetGUID() );

		}

	}
	else
	{
		SetUInt64Value( (uint16)(PLAYER_FIELD_INV_SLOT_HEAD  + (srcslot*2)), 0 );

	}

	if ( srcslot < EQUIPMENT_SLOT_END )
	{
		int VisibleBase = PLAYER_VISIBLE_ITEM_1_0 + (srcslot * 12);
		SetUInt32Value(VisibleBase, 0);
		SetUInt32Value(VisibleBase + 1, 0);
		SetUInt32Value(VisibleBase + 2, 0);
		SetUInt32Value(VisibleBase + 3, 0);
		SetUInt32Value(VisibleBase + 4, 0);
		SetUInt32Value(VisibleBase + 5, 0);
		SetUInt32Value(VisibleBase + 6, 0);
		SetUInt32Value(VisibleBase + 7, 0);
		SetUInt32Value(VisibleBase + 8, 0);
		_ApplyItemMods( m_items[dstslot], srcslot, false );
		CalculateActualArmor();
	}

	if ( dstslot < EQUIPMENT_SLOT_END )
	{
		int VisibleBase = PLAYER_VISIBLE_ITEM_1_0 + (dstslot * 12);
		SetUInt32Value(VisibleBase, m_items[dstslot]->GetUInt32Value(OBJECT_FIELD_ENTRY));
		SetUInt32Value(VisibleBase + 1, m_items[dstslot]->GetUInt32Value(ITEM_FIELD_ENCHANTMENT));
		SetUInt32Value(VisibleBase + 2, m_items[dstslot]->GetUInt32Value(ITEM_FIELD_ENCHANTMENT + 3));
		SetUInt32Value(VisibleBase + 3, m_items[dstslot]->GetUInt32Value(ITEM_FIELD_ENCHANTMENT + 6));
		SetUInt32Value(VisibleBase + 4, m_items[dstslot]->GetUInt32Value(ITEM_FIELD_ENCHANTMENT + 9));
		SetUInt32Value(VisibleBase + 5, m_items[dstslot]->GetUInt32Value(ITEM_FIELD_ENCHANTMENT + 12));
		SetUInt32Value(VisibleBase + 6, m_items[dstslot]->GetUInt32Value(ITEM_FIELD_ENCHANTMENT + 15));
		SetUInt32Value(VisibleBase + 7, m_items[dstslot]->GetUInt32Value(ITEM_FIELD_ENCHANTMENT + 18));
		SetUInt32Value(VisibleBase + 8, m_items[dstslot]->GetUInt32Value(ITEM_FIELD_RANDOM_PROPERTIES_ID));
        if (m_items[srcslot] && srcslot >= EQUIPMENT_SLOT_END)
            _ApplyItemMods(m_items[srcslot],srcslot, false);
		CalculateActualArmor();
	}

	if (srcslot >= EQUIPMENT_SLOT_END && dstslot < EQUIPMENT_SLOT_END)
		_ApplyItemMods(m_items[dstslot],dstslot, true);
}


uint32 Player::GetSlotByItemID(uint32 ID)
{
	for(uint32 i=INVENTORY_SLOT_ITEM_START;i<INVENTORY_SLOT_ITEM_END;i++){
		if(m_items[i] != 0)
			if(m_items[i]->GetProto()->ItemId == ID)
				return i;
	}
	return 0;
}
uint32 Player::GetSlotByItemGUID(uint64 guid)
{
	for(uint32 i=0;i<INVENTORY_SLOT_ITEM_END;i++){
		if(m_items[i] != 0)
			if(m_items[i]->GetGUID() == guid)
				return i;
	}
	return INVENTORY_NO_SLOT_AVAILABLE; //was changed from 0 cuz 0 is the slot for head
}
void Player::EmptyBuyBack()
{
	for (int j = 0;j < 12;j++)
	{
		if (buyback[j] != NULL)
		{
			buyback[j]->DeleteFromDB();
			buyback[j]->DestroyForPlayer(this);
			delete buyback[j];
		}
		SetUInt64Value(PLAYER_FIELD_VENDORBUYBACK_SLOT_1 + (2*j),0);
		SetUInt32Value(PLAYER_FIELD_BUYBACK_PRICE_1 + j,0);
		SetUInt32Value(PLAYER_FIELD_BUYBACK_TIMESTAMP_1 + j,0);
	}
}
void Player::AddItemToSlot(uint8 slot, Item *item)
{
	//Log::getSingleton().outError("AddItemtoSlot");
	ASSERT(slot < BANK_SLOT_BAG_END);
	ASSERT(m_items[slot] == NULL);

	UpdateData upd;
	WorldPacket packet;

	if( IsInWorld() )
	{
		//the item is a container
		if(item->GetProto()->InventoryType == INVTYPE_BAG)
		{
			if(!m_items[slot]) //container not available, create new one
			{
				//creates the container
				m_items[slot] = item; //->place the item in the iventory
				m_items[slot]->pContainer = new Container();
				m_items[slot]->pContainer->Create(objmgr.GenerateLowGuid(HIGHGUID_CONTAINER),item->GetProto()->ItemId,this);

				upd.Clear();
				m_items[slot]->pContainer->BuildCreateUpdateBlockForPlayer( &upd, this );
				upd.BuildPacket( &packet );
				GetSession()->SendPacket( &packet );

				m_items[slot]->pContainer->SetOwner(this);
				m_items[slot]->pContainer->AddToWorld();

				item->SetOwner( this );
				item->AddToWorld();
				//save the item in the bag slots for future usage :)
				SetUInt64Value( (uint16)(PLAYER_FIELD_INV_SLOT_HEAD  + (slot*2)), m_items[slot]->pContainer->GetGUID() );

			}
			else if(m_items[slot]) //container already exist -> add item to the container
			{
				uint8 pslot = m_items[slot]->pContainer->FindFreeSlot();

				/*upd.Clear();
				item->BuildCreateUpdateBlockForPlayer( &upd, this );
				upd.BuildPacket( &packet );
				GetSession()->SendPacket( &packet );*/

				m_items[slot]->pContainer->AddItem(pslot, item);
			}
		}
		else
		{
			//this item is not a container or it wont be added to containers
			item->BuildCreateUpdateBlockForPlayer( &upd, this );
			upd.BuildPacket( &packet );
			GetSession()->SendPacket( &packet );

			m_items[slot] = item;
			SetUInt64Value( (uint16)(PLAYER_FIELD_INV_SLOT_HEAD  + (slot*2)), m_items[slot] ? m_items[slot]->GetGUID() : 0 );

			item->SetOwner( this );

			item->AddToWorld();
		}
		/*//internal checks, update other players inrange(seems this is not working)
		if ( slot < EQUIPMENT_SLOT_END )
		{
		for(Object::InRangeSet::iterator i = GetInRangeSetBegin(); i != GetInRangeSetEnd(); i++)
		{
		if((*i)->GetTypeId() == TYPEID_PLAYER)
		{
		upd.Clear();
		item->BuildCreateUpdateBlockForPlayer( &upd, (Player*)*i );
		upd.BuildPacket( &packet );
		WorldSession *session = ((Player*)(*i))->GetSession();
		session->SendPacket(&packet);
		}
		}
		}*/
		//end if checks
	}
	else
	{
		if(item->GetProto())
		{
			//player not in world
			if(item->GetProto()->InventoryType == INVTYPE_BAG)
			{
				if(!m_items[slot]) //container not available, create new one
				{
					//creates the container
					m_items[slot] = item; //->place the item in the iventory
					m_items[slot]->pContainer = new Container();
					m_items[slot]->pContainer->Create(objmgr.GenerateLowGuid(HIGHGUID_CONTAINER),item->GetProto()->ItemId,this);

					m_items[slot]->pContainer->SetOwner(this);

					item->SetOwner( this );
					//save the item in the bag slots for future usage :)
					SetUInt64Value( (uint16)(PLAYER_FIELD_INV_SLOT_HEAD  + (slot*2)), m_items[slot]->pContainer->GetGUID() );
				}
			}
			else
			{
				m_items[slot] = item;
				SetUInt64Value( (uint16)(PLAYER_FIELD_INV_SLOT_HEAD  + (slot*2)), m_items[slot] ? m_items[slot]->GetGUID() : 0 );

				item->SetOwner( this );
			}
		}
		else
			return;
	}

	if ( slot < EQUIPMENT_SLOT_END )
	{
		int VisibleBase = PLAYER_VISIBLE_ITEM_1_0 + (slot * 12);
		SetUInt32Value(VisibleBase, item->GetUInt32Value(OBJECT_FIELD_ENTRY));
		SetUInt32Value(VisibleBase + 1, item->GetUInt32Value(ITEM_FIELD_ENCHANTMENT));
		SetUInt32Value(VisibleBase + 2, item->GetUInt32Value(ITEM_FIELD_ENCHANTMENT + 3));
		SetUInt32Value(VisibleBase + 3, item->GetUInt32Value(ITEM_FIELD_ENCHANTMENT + 6));
		SetUInt32Value(VisibleBase + 4, item->GetUInt32Value(ITEM_FIELD_ENCHANTMENT + 9));
		SetUInt32Value(VisibleBase + 5, item->GetUInt32Value(ITEM_FIELD_ENCHANTMENT + 12));
		SetUInt32Value(VisibleBase + 6, item->GetUInt32Value(ITEM_FIELD_ENCHANTMENT + 15));
		SetUInt32Value(VisibleBase + 7, item->GetUInt32Value(ITEM_FIELD_ENCHANTMENT + 18));
		SetUInt32Value(VisibleBase + 8, item->GetUInt32Value(ITEM_FIELD_RANDOM_PROPERTIES_ID));
        if( IsInWorld() )
		{
			_ApplyItemMods( item,slot, true );
			CalculateActualArmor();
		}
	}
}

Item* Player::GetItemByGUID(uint64 itemGuid, bool Remove, bool DestoryForPlayer)
{
	uint32 i = 0;
	Item* item = NULL;
	
	//EQUIPMENT
	for(i=EQUIPMENT_SLOT_START;i<EQUIPMENT_SLOT_END;i++)
	{
		
		if(m_items[i] != 0)
		{
			if(m_items[i]->GetGUID() == itemGuid)
			{
				if(Remove)
					item = RemoveItemFromSlot(i,DestoryForPlayer);
				else
					item = m_items[i];
				break;
			}
		}
	}
	
	//INVENTORY BAGS
	if(!item)
	{
		for(i=INVENTORY_SLOT_BAG_START;i<INVENTORY_SLOT_BAG_END;i++)
		{
			
			if(m_items[i] != NULL)
			{
				if(m_items[i]->pContainer != NULL)
				{
					for (int j =0; j < m_items[i]->GetProto()->ContainerSlots;j++)
					{
						Item *item2 = m_items[i]->pContainer->GetItem(j);
						if (item2)
						{
							if (item2->GetGUID() == itemGuid)
							{
								if(Remove)
									item = m_items[i]->pContainer->RemoveItemFromSlot(j,DestoryForPlayer);
								else
									item = item2;
								break;
							}
							else if(item2->pContainer)
							{
								if(item2->pContainer->GetGUID() == itemGuid)
								{
									if(Remove)
										item = m_items[i]->pContainer->RemoveItemFromSlot(j,DestoryForPlayer);
									else
										item = item2;
									break;
								}
							}
						}
					}
				}
			}
		}
	}
	
	//INVENTORY
	if(!item)
	{
		for(i=INVENTORY_SLOT_ITEM_START;i<INVENTORY_SLOT_ITEM_END;i++)
		{
			
			if(m_items[i] != 0)
			{
				if(m_items[i]->GetGUID() == itemGuid)
				{
					if(Remove)
						item = RemoveItemFromSlot(i,DestoryForPlayer);
					else
						item = m_items[i];
					break;
				}
				else if(m_items[i]->pContainer)
				{
					if(m_items[i]->pContainer->GetGUID() == itemGuid)
					{
						if(Remove)
							item = RemoveItemFromSlot(i,DestoryForPlayer);
						else
							item = m_items[i];
						break;
					}
				}
			}
		}
	}
	/*
	if(!item)
	{
		for(i=BANK_SLOT_ITEM_START;i<BANK_SLOT_ITEM_END;i++)
		{
			//INVENTORY
			if(m_items[i] != 0)
				if(m_items[i]->GetGUID() == itemGuid)
				{
					item = m_items[i];
					break;
				}
		}
	}
	if(!item)
	{
		for(i=BANK_SLOT_BAG_START;i<BANK_SLOT_BAG_END;i++)
		{
			//INVENTORY
			if(m_items[i] != 0)
				if(m_items[i]->GetGUID() == itemGuid)
				{
					item = m_items[i];
					break;
				}
		}
	}	
*/
	return item;
}

Item* Player::GetItemByLocation(uint8 bag, uint8 slot, bool Remove)
{
	sLog.outDebug("GetItemByLocation: BagSlot %u, ItemSlot %u, Remove? %u",bag,slot,Remove);

	Item* item = NULL;
	if( (bag >= INVENTORY_SLOT_BAG_START) && (bag < INVENTORY_SLOT_BAG_END) ) //IN BAG
	{
		if(m_items[bag] != 0)
		{
			if(m_items[bag]->pContainer)
			{
				if(slot < m_items[bag]->GetProto()->ContainerSlots)
				{
					Item *item2 = m_items[bag]->pContainer->GetItem(slot);
					if (item2)
					{
						if(Remove)
							item = m_items[bag]->pContainer->RemoveItemFromSlot(slot);
						else
							item = item2;
					}
				}
			}
		}
	}
	else //INVENTORY
	{
		if((slot >= INVENTORY_SLOT_ITEM_START) && (slot < INVENTORY_SLOT_ITEM_END))
		{
			if(m_items[slot] != NULL)
			{
				if(Remove)
					item = RemoveItemFromSlot(slot);
				else
					item = m_items[slot];
			}
		}
	}
	return item;
}

void Player::AddItemToFreeSlot(Item *item)
{
	uint32 i = 0;
	
	//INVENTORY
	for(i=INVENTORY_SLOT_ITEM_START;i<INVENTORY_SLOT_ITEM_END;i++)
	{
		if(m_items[i] == NULL)
		{
			sLog.outDebug("AddItemToFreeSlot: BagSlot 0xFF, ItemSlot %u",i);
			AddItemToSlot(i, item);
			return;
		}
	}

	//INVENTORY BAGS
	for(i=INVENTORY_SLOT_BAG_START;i<INVENTORY_SLOT_BAG_END;i++)
	{
		if(m_items[i] != NULL)
		{
			if(m_items[i]->pContainer)
			{
				for (int j =0; j < m_items[i]->GetProto()->ContainerSlots;j++)
				{
					Item *item2 = m_items[i]->pContainer->GetItem(j);
					if (item2 == NULL)
					{
						sLog.outDebug("AddItemToFreeSlot: BagSlot %u, ItemSlot %u",i,j);
						m_items[i]->pContainer->AddItem(j, item);
						return;
					}
				}
			}
		}
	}
}

Item* Player::RemoveItemFromSlot(uint8 slot, bool DestroyForPlayer)
{
	ASSERT(slot < BANK_SLOT_BAG_END);

	Item *item = m_items[slot];
	if (item == NULL) return NULL;

	m_items[slot] = NULL;
	SetUInt64Value( (uint16)(PLAYER_FIELD_INV_SLOT_HEAD  + (slot*2)), 0 );

	if ( slot < EQUIPMENT_SLOT_END )
	{
		_ApplyItemMods( item,slot, false );
		int VisibleBase = PLAYER_VISIBLE_ITEM_1_0 + (slot * 12);
		for (int i = VisibleBase; i < VisibleBase + 12; ++i)
			SetUInt32Value(i, 0);
		CalculateActualArmor();
	}

	item->SetOwner( NULL );

	if ( IsInWorld() )
	{
		//check for container slots
		if(item->GetProto()->InventoryType == INVTYPE_BAG)
		{
			item->pContainer->SetOwner(NULL);
			item->pContainer->RemoveFromWorld();
			if(DestroyForPlayer)
				item->pContainer->DestroyForPlayer(this);
			item->RemoveFromWorld();
		}
		else
		{
			item->RemoveFromWorld();
			if(DestroyForPlayer)
				item->DestroyForPlayer( this );
		}

		/*if ( slot < EQUIPMENT_SLOT_END )
		{
		for(Object::InRangeSet::iterator i = GetInRangeSetBegin();
		i != GetInRangeSetEnd(); i++)
		{
		if((*i)->GetTypeId() == TYPEID_PLAYER)
		item->DestroyForPlayer( (Player*)*i );
		}
		}*/
	}
	return item;
}

void Player::AddToWorld()
{
    for(int i = 0; i < BANK_SLOT_BAG_END; i++)
	{
		if(m_items[i])
		{
			if(m_items[i]->pContainer)
			{
				for(int e=0; e < m_items[i]->pContainer->GetProto()->ContainerSlots; e++)
				{
					Item *item = m_items[i]->pContainer->GetItem(e);
					if(item)
					{
						if(item->pContainer)
						{
							item->pContainer->AddToWorld();
						}
						else
						{
							item->AddToWorld();
						}
					}
				}
				m_items[i]->pContainer->AddToWorld();

			}
			else
			{
				m_items[i]->AddToWorld();
			}
		}
	}
	Object::AddToWorld();
}

void Player::RemoveFromWorld()
{
	for(int i = 0; i < BANK_SLOT_BAG_END; i++)
	{
		if(m_items[i])
		{
			if(m_items[i]->pContainer)
			{
				for(int e=0; e < m_items[i]->pContainer->GetProto()->ContainerSlots; e++)
				{
					Item *item = m_items[i]->pContainer->GetItem(e);
					if(item)
					{
						if(item->pContainer)
						{
							item->pContainer->RemoveFromWorld();
						}
						else
						{
							item->RemoveFromWorld();
						}
					}
				}
				m_items[i]->pContainer->RemoveFromWorld();

			}
			else
			{
				m_items[i]->RemoveFromWorld();
			}
		}
	}

	Object::RemoveFromWorld();
}

bool Player::isTalent(uint32 id)
{
	std::list<uint32>::const_iterator itr;
	for (itr = m_talents.begin(); itr != m_talents.end();itr++)
	{
		if ((*itr) == id)
			return true;
	}
	return false;
}
int Player::GetSpellDamageMod(uint32 id)
{
	AffectList::iterator i;
	Affect::ModList::const_iterator j;
	SpellEntry *spellInfo2 = sSpellStore.LookupEntry(id);
	Affect *aff;
	int in = 0;
	for (i = m_affects.begin(); i != m_affects.end(); i++)
	{
		aff = *i;
		in = 0;
		for (j = aff->GetModList().begin();j != aff->GetModList().end(); j++)
		{
			Modifier mod = (*j);
			if ((mod.GetType() == SPELL_AURA_ADD_PCT_MODIFIER) && (mod.GetMiscValue() == 14))
			{
				SpellEntry *spellInfo = sSpellStore.LookupEntry(aff->GetSpellId());
				if (spellInfo2->SpellGroupType & spellInfo->EffectSpellGroupRelation[in])
				{
					printf("returning %f \n",spellInfo->EffectBasePoints[in] + 1);
					return spellInfo->EffectBasePoints[in] + 1;
				}
			}
			in++;
		}
	}
	return 0;

}
int Player::GetSpellManaMod(uint32 id)
{
	AffectList::iterator i;
	Affect::ModList::const_iterator j;
	SpellEntry *spellInfo2 = sSpellStore.LookupEntry(id);
	Affect *aff;
	int in = 0;
	for (i = m_affects.begin(); i != m_affects.end(); i++)
	{
		aff = *i;
		in = 0;
		for (j = aff->GetModList().begin();j != aff->GetModList().end(); j++)
		{
			Modifier mod = (*j);
			if ((mod.GetType() == SPELL_AURA_ADD_PCT_MODIFIER) && (mod.GetMiscValue() == 14))
			{
				SpellEntry *spellInfo = sSpellStore.LookupEntry(aff->GetSpellId());
				if (spellInfo2->SpellGroupType & spellInfo->EffectSpellGroupRelation[in])
				{
					printf("returning %f \n",spellInfo->EffectBasePoints[in] + 1);
					return spellInfo->EffectBasePoints[in] + 1;
				}
			}
			in++;
		}
	}
	return 0;

}
float Player::GetSpellTimeMod(uint32 id)
{
	AffectList::iterator i;
	Affect::ModList::const_iterator j;
	SpellEntry *spellInfo2 = sSpellStore.LookupEntry(id);
	Affect *aff;
	int in = 0;
	for (i = m_affects.begin(); i != m_affects.end(); i++)
	{
		aff = *i;
		in = 0;
		for (j = aff->GetModList().begin();j != aff->GetModList().end(); j++)
		{
			Modifier mod = (*j);
			if ((mod.GetType() == SPELL_AURA_ADD_FLAT_MODIFIER) && (mod.GetMiscValue() == 10))
			{
				SpellEntry *spellInfo = sSpellStore.LookupEntry(aff->GetSpellId());
				if (spellInfo2->SpellGroupType & spellInfo->EffectSpellGroupRelation[in])
				{
					printf("returning %f \n",(0.0f-(spellInfo->EffectBasePoints[in] + 1)));
					return (0.0f-(spellInfo->EffectBasePoints[in] + 1));
				}
			}
			in++;
		}
	}

	return 0.0f;

}
// TODO: perhaps item should just have a list of mods, that will simplify code
void Player::_ApplyItemMods(Item *item, uint8 slot,bool apply)
{
	ASSERT(item);
	ItemPrototype *proto = item->GetProto();
	// FIXME: just an example
	if (proto->Armor)
	{
		SetUInt32Value(UNIT_FIELD_RESISTANCES, GetUInt32Value(UNIT_FIELD_RESISTANCES+0) +
			(apply ? proto->Armor : -(int32)proto->Armor));
	}
	if (proto->FireRes)
		SetUInt32Value(UNIT_FIELD_RESISTANCES+SCHOOL_FIRE, GetUInt32Value(UNIT_FIELD_RESISTANCES+1) +
		(apply ? proto->FireRes : -(int32)proto->FireRes));
	if (proto->NatureRes)
		SetUInt32Value(UNIT_FIELD_RESISTANCES+SCHOOL_NATURE, GetUInt32Value(UNIT_FIELD_RESISTANCES+2) +
		(apply ? proto->NatureRes : -(int32)proto->NatureRes));
	if (proto->FrostRes)
		SetUInt32Value(UNIT_FIELD_RESISTANCES+SCHOOL_FROST, GetUInt32Value(UNIT_FIELD_RESISTANCES+3) +
		(apply ? proto->FrostRes : -(int32)proto->FrostRes));
	if (proto->ShadowRes)
		SetUInt32Value(UNIT_FIELD_RESISTANCES+SCHOOL_SHADOW, GetUInt32Value(UNIT_FIELD_RESISTANCES+4) +
		(apply ? proto->ShadowRes : -(int32)proto->ShadowRes));
	if (proto->ArcaneRes)
		SetUInt32Value(UNIT_FIELD_RESISTANCES+SCHOOL_ARCANE, GetUInt32Value(UNIT_FIELD_RESISTANCES+0) +
		(apply ? proto->ArcaneRes : -(int32)proto->ArcaneRes));


	uint8 MINDAMAGEFIELD=(slot==EQUIPMENT_SLOT_OFFHAND)?UNIT_FIELD_MINOFFHANDDAMAGE:UNIT_FIELD_MINDAMAGE;
	uint8 MAXDAMAGEFIELD=(slot==EQUIPMENT_SLOT_OFFHAND)?UNIT_FIELD_MAXOFFHANDDAMAGE:UNIT_FIELD_MAXDAMAGE;

	if (proto->DamageMin[0])
	{
		SetFloatValue(MINDAMAGEFIELD, GetFloatValue(MINDAMAGEFIELD) +
			(apply ? proto->DamageMin[0] : -proto->DamageMin[0]));

	}
	if (proto->DamageMax[0])
	{
		SetFloatValue(MAXDAMAGEFIELD, GetFloatValue(MAXDAMAGEFIELD) +
			(apply ? proto->DamageMax[0] : -proto->DamageMax[0]));
	}
	if (proto->Delay)
	{
		if(slot!=EQUIPMENT_SLOT_OFFHAND)
			SetUInt32Value(UNIT_FIELD_BASEATTACKTIME, apply ? proto->Delay : 2000);
		else SetUInt32Value(UNIT_FIELD_BASEATTACKTIME + 1, apply ? proto->Delay : 2000);
	}
	SetFloatValue(PLAYER_DODGE_PERCENTAGE,((GetUInt32Value( UNIT_FIELD_STAT1) / 14.5) + (GetSkillAmt(95)*.04)));
	SetFloatValue(PLAYER_BLOCK_PERCENTAGE,(GetUInt32Value( UNIT_FIELD_STAT0) / 30.0));
	if (GetItemBySlot(EQUIPMENT_SLOT_OFFHAND))
		SetFloatValue(PLAYER_BLOCK_PERCENTAGE,GetFloatValue(PLAYER_BLOCK_PERCENTAGE) + GetItemBySlot(EQUIPMENT_SLOT_OFFHAND)->GetProto()->Block);
	SetFloatValue(PLAYER_PARRY_PERCENTAGE,(GetSkillAmt(95)*.04));
	if (apply)
	{
		for (int i = 0; i < 12;i++)
		{
			if (item->GetUInt32Value(ITEM_FIELD_ENCHANTMENT + i) != 0)
			{
				EnchantEntry * ee = sEnchantStore.LookupEntry(item->GetUInt32Value(ITEM_FIELD_ENCHANTMENT + i));
				item->addEnchantBonus(ee);
			}
		}
	}
	else
	{
		for (int j=0; j < 12;j++)
		{
			if (item->GetUInt32Value(ITEM_FIELD_ENCHANTMENT + j) != 0)
			{
				item->RemoveEnchantBonus(item->GetUInt32Value(ITEM_FIELD_ENCHANTMENT + j));
			}
		}
	}

}

void Player::_RemoveAllItemMods()
{
	for (int i = 0; i < INVENTORY_SLOT_BAG_END; i++)
	{
		if(m_items[i])
		{
			_ApplyItemMods(m_items[i],i, false);
		}
	}
}

void Player::_ApplyAllItemMods()
{
	for (int i = 0; i < INVENTORY_SLOT_BAG_END; i++)
	{
		if(m_items[i])
			_ApplyItemMods(m_items[i],i, true);
	}
}

void Player::SetMovement(uint8 pType)
{
	WorldPacket data;

	switch(pType)
	{
	case MOVE_ROOT:
		{
			data.Initialize(SMSG_FORCE_MOVE_ROOT);
			data << GetNewGUID();
			GetSession()->SendPacket( &data );
			m_currentMovement = MOVE_ROOT;
		}break;
	case MOVE_UNROOT:
		{
			data.Initialize(SMSG_FORCE_MOVE_UNROOT);
			data << GetNewGUID();
			GetSession()->SendPacket( &data );
			m_currentMovement = MOVE_UNROOT;
		}break;
	case MOVE_WATER_WALK:
		{
			data.Initialize(SMSG_MOVE_WATER_WALK);
			data << GetNewGUID();
			GetSession()->SendPacket( &data );
		}break;
	case MOVE_LAND_WALK:
		{
			data.Initialize(SMSG_MOVE_LAND_WALK);
			data << GetNewGUID();
			GetSession()->SendPacket( &data );
		}break;
	default:break;
	}
}

void Player::SetPlayerSpeed(uint8 SpeedType, float value, bool forced)
{
	WorldPacket data;

	switch(SpeedType)
	{
	case RUN:
		{
			if(forced) { data.Initialize(SMSG_FORCE_RUN_SPEED_CHANGE); }
			else { data.Initialize(MSG_MOVE_SET_RUN_SPEED); }
			data << GetNewGUID();
			data << float(value);
			m_runSpeed = value;
			//GetSession()->SendPacket( &data );
		}break;
	case RUNBACK:
		{
			if(forced) { data.Initialize(SMSG_FORCE_RUN_BACK_SPEED_CHANGE); }
			else { data.Initialize(MSG_MOVE_SET_RUN_BACK_SPEED); }
			data << GetNewGUID();
			data << float(value);
			m_backWalkSpeed = value;
			//GetSession()->SendPacket( &data );
		}break;
	case SWIM:
		{
			if(forced) { data.Initialize(SMSG_FORCE_SWIM_SPEED_CHANGE); }
			else { data.Initialize(MSG_MOVE_SET_SWIM_SPEED); }
			data << GetNewGUID();
			data << float(value);
			m_swimSpeed = value;
			//GetSession()->SendPacket( &data );
		}break;
	case SWIMBACK:
		{
			data.Initialize(MSG_MOVE_SET_SWIM_BACK_SPEED);
			data << GetNewGUID();
			data << float(value);
			m_backSwimSpeed = value;
			//GetSession()->SendPacket( &data );
		}break;
	default:break;
	}
	//should prob set players default speed to the above speed so updates recived on create packet
	SendMessageToSet(&data , true);
}

void Player::BuildPlayerRepop()
{
	WorldPacket data;
	//1.1.1
	SetUInt32Value( UNIT_FIELD_HEALTH, 1 );

	SetMovement(MOVE_UNROOT);
	SetMovement(MOVE_WATER_WALK);

	SetPlayerSpeed(RUN, (float)8.5, true);
	SetPlayerSpeed(SWIM, (float)5.9, true);

	uint32 reclaim_delay = 30000;
	data.Initialize(SMSG_CORPSE_RECLAIM_DELAY );
	data << reclaim_delay;
	GetSession()->SendPacket( &data );

	data.Initialize(SMSG_SPELL_START );
	data << GetNewGUID() << GetNewGUID() << uint32(8326);
	data << uint16(0) << uint32(0) << uint16(0x02) << uint32(0) << uint32(0);
	GetSession()->SendPacket( &data );

	data.Initialize(SMSG_UPDATE_AURA_DURATION);
	data << uint8(32);
	data << uint32(0);
	GetSession()->SendPacket( &data );

	data.Initialize(SMSG_CAST_RESULT);
	data << uint32(8326);
	data << uint8(0x00);
	GetSession()->SendPacket( &data );

	data.Initialize(SMSG_SPELL_GO);
	data << GetNewGUID() << GetNewGUID() << uint32(8326);
	data << uint16(01) << uint8(0) << uint8(0);
	data << uint16(0040);
	data << GetPositionX();
	data << GetPositionY();
	data << GetPositionZ();
	GetSession()->SendPacket( &data );

	data.Initialize(SMSG_SPELLLOGEXECUTE);
	data << GetNewGUID() << GetNewGUID();
	data << uint32(8326);
	data << uint32(1);
	data << uint32(0x24);
	data << uint32(1);
	data << GetGUID();
	GetSession()->SendPacket( &data );

	data.Initialize(SMSG_STOP_MIRROR_TIMER);
	data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
	GetSession()->SendPacket( &data );

	data.Initialize(SMSG_STOP_MIRROR_TIMER);
	data << uint8(0x01) << uint8(0x00) << uint8(0x00) << uint8(0x00);
	GetSession()->SendPacket( &data );

	data.Initialize(SMSG_STOP_MIRROR_TIMER);
	data << uint8(0x02) << uint8(0x00) << uint8(0x00) << uint8(0x00);
	GetSession()->SendPacket( &data );

	SetUInt32Value(CONTAINER_FIELD_SLOT_1+29, 8326);
	SetUInt32Value(UNIT_FIELD_AURA+32, 8326);
	SetUInt32Value(UNIT_FIELD_AURALEVELS+8, 0xeeeeee00);
	SetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS+8, 0xeeeeee00);
	SetUInt32Value(UNIT_FIELD_AURAFLAGS+4, 12);
	SetUInt32Value(UNIT_FIELD_AURASTATE, 2);

	SetFlag(PLAYER_FLAGS, 0x10);

	//spawn Corpse
	SpawnCorpseBody();
}

void Player::ResurrectPlayer()
{
	RemoveFlag(PLAYER_FLAGS, 0x10);
	setDeathState(ALIVE);
	if(getRace() == 4) { // NEs to turn back from Wisp.
		DeMorph();
	}
}

void Player::KillPlayer()
{
	WorldPacket data;

	EventDeath();
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

	if(getRace() == 4) { // NEs
		this->SetUInt32Value(UNIT_FIELD_DISPLAYID, 10045);
	}
}

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
		for (int i = 0; i < EQUIPMENT_SLOT_END; i++)
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
		//Log::getSingleton( ).outError("AddObject at Player.cpp");
		objmgr.AddObject(pCorpse);
	}
	else //Corpse already exist in world, update it
	{
		pCorpse->SetPosition(GetPositionX(), GetPositionY(), GetPositionZ(), GetOrientation());
	}
}

void Player::SpawnCorpseBody()
{
	Corpse *pCorpse;

	pCorpse = objmgr.GetCorpseByOwner(this);
	if(pCorpse && !pCorpse->IsInWorld())
	{
		pCorpse->AddToWorld();
        pCorpse->GetMapMgr()->GetBaseMap()->GetTemplate()->AddIndex<Corpse>(pCorpse);
	}
}

void Player::SpawnCorpseBones()
{
	Corpse *pCorpse;
	pCorpse = objmgr.GetCorpseByOwner(this);
	if(pCorpse)
	{
		pCorpse->SetUInt32Value(CORPSE_FIELD_FLAGS, 5);
		pCorpse->SetUInt64Value(CORPSE_FIELD_OWNER, 0); // remove corpse owner association
		//remove item association
		for (int i = 0; i < EQUIPMENT_SLOT_END; i++)
		{
			if(pCorpse->GetUInt32Value(CORPSE_FIELD_ITEM + i))
				pCorpse->SetUInt32Value(CORPSE_FIELD_ITEM + i, 0);
		}
		pCorpse->GetMapMgr()->GetBaseMap()->GetTemplate()->RemoveIndex<Corpse>(pCorpse);
		pCorpse->DeleteFromDB();
	}
}

void Player::DeathDurabilityLoss(double percent)
{
	uint32 pDurability, pNewDurability;

	for (int i = 0; i < EQUIPMENT_SLOT_END; i++)
	{
		if(m_items[i])
		{
			pDurability =  m_items[i]->GetUInt32Value(ITEM_FIELD_DURABILITY);
			if(pDurability)
			{
				pNewDurability = (uint32)(pDurability*percent);
				pNewDurability = (pDurability - pNewDurability);
				if(pNewDurability < 0) { pNewDurability = 0; }

				m_items[i]->SetUInt32Value(ITEM_FIELD_DURABILITY, pNewDurability);
			}
		}
	}
}

void Player::RepopAtGraveyard()
{
	float closestX = 0, closestY = 0, closestZ = 0, closestO = 0;
	WorldPacket data;
	float curX, curY, curZ;
	bool first = true;

	ObjectMgr::GraveyardMap::const_iterator itr;
	for (itr = objmgr.GetGraveyardListBegin(); itr != objmgr.GetGraveyardListEnd(); itr++)
	{
		GraveyardTeleport *pGrave = itr->second;
		if(pGrave->MapId == GetMapId() && pGrave->ZoneId == GetZoneId())
		{
			curX = pGrave->X;
			curY = pGrave->Y;
			curZ = pGrave->Z;
			if( first || pow(m_positionX-curX,2) + pow(m_positionY-curY,2) <
				pow(m_positionX-closestX,2) + pow(m_positionY-closestY,2) )
			{
				first = false;

				closestX = curX;
				closestY = curY;
				closestZ = curZ;
				closestO = pGrave->O;
			}
		}
	}

	if(closestX != 0 && closestY != 0 && closestZ != 0) {
		WorldPacket data;

		// Send new position to client via MSG_MOVE_TELEPORT_ACK
		BuildTeleportAckMsg(&data, closestX, closestY, closestZ, 0);
		GetSession()->SendPacket(&data);

		// Set actual position and update in-range lists
		SetPosition(closestX, closestY, closestZ, 0);

		//////////////////////////////////
		// Now send new position of this player to clients using MSG_MOVE_HEARTBEAT
		BuildHeartBeatMsg(&data);
		SendMessageToSet(&data, true);
	}
}

void Player::JoinedChannel(Channel *c)
{
	m_channels.push_back(c);
}

void Player::LeftChannel(Channel *c)
{
	m_channels.remove(c);
}

void Player::CleanupChannels()
{
	list<Channel *>::iterator i;
	for(i = m_channels.begin(); i != m_channels.end(); i++)
		(*i)->Leave(this,false);
}

// skilllines
bool Player::HasSkillLine(uint32 id)
{
	std::list<struct skilllines>::iterator itr;
	for (itr = m_skilllines.begin(); itr != m_skilllines.end(); ++itr)
	{
		if (itr->lineId == id)
		{
			return true;
		}
	}
	return false;
}

float Player::GetSkillUpChance(uint32 id)
{
	if (HasSkillLine(id))
	{
		float diff = GetSkillMax(id) - GetSkillAmt(id);
		diff /= 2.5;
		if (diff < .5)
			diff = .5;
		return diff;
	}
	return 0.0;
}

uint32 Player::GetSkillPlace(uint32 id)
{
	uint32 cnt = 0;
	std::list<struct skilllines>::iterator itr;
	for (itr = m_skilllines.begin(); itr != m_skilllines.end(); ++itr)
	{
		if (itr->lineId == id)
		{
			return cnt;
		}
		cnt++;
	}
	return 0;
}

uint32 Player::GetSkillMax(uint32 id)
{
	std::list<struct skilllines>::iterator itr;
	for (itr = m_skilllines.begin(); itr != m_skilllines.end(); ++itr)
	{
		if (itr->lineId == id)
		{
			return itr->maxVal;
		}
	}
	return 0;
}

uint32 Player::GetSkillAmt(uint32 id)
{
	std::list<struct skilllines>::iterator itr;
	for (itr = m_skilllines.begin(); itr != m_skilllines.end(); ++itr)
	{
		if (itr->lineId == id)
		{
			return itr->currVal;
		}
	}
	return 0;
}

void Player::ModSkillLine(uint32 id, uint32 amt)
{
	std::list<struct skilllines>::iterator itr;
	for (itr = m_skilllines.begin(); itr != m_skilllines.end(); ++itr)
	{
		if (itr->lineId == id)
		{
			itr->currVal += amt;
			uint32 CurMax = 0;
			CurMax |= ((uint32)(itr->maxVal << 16)) | itr->currVal;
			uint16 LineBase = PLAYER_SKILL_INFO_1_1 + (itr->place * 3);
			SetUInt32Value(LineBase, id);
			SetUInt32Value(LineBase + 1, CurMax);
			SetUInt32Value(LineBase + 2, 0);

			//base skillline saving
			SetBaseUInt32Value(LineBase, id);
			SetBaseUInt32Value(LineBase + 1, CurMax);
			SetBaseUInt32Value(LineBase + 2, 0);
		}
	}
}

void Player::ModSkillMax(uint32 id, uint32 amt)
{
	std::list<struct skilllines>::iterator itr;
	for (itr = m_skilllines.begin(); itr != m_skilllines.end(); ++itr)
	{
		if (itr->lineId == id)
		{
			itr->maxVal = amt;
			uint32 CurMax = 0;
			CurMax |= ((uint32)(itr->maxVal << 16)) | itr->currVal;
			uint16 LineBase = PLAYER_SKILL_INFO_1_1 + (itr->place * 3);
			SetUInt32Value(LineBase, id);
			SetUInt32Value(LineBase + 1, CurMax);
			SetUInt32Value(LineBase + 2, 0);

			//base skillline saving
			SetBaseUInt32Value(LineBase, id);
			SetBaseUInt32Value(LineBase + 1, CurMax);
			SetBaseUInt32Value(LineBase + 2, 0);
		}
	}
}

void Player::AddSkillLine(uint32 id, uint16 currVal, uint16 maxVal)
{
	AddSkillLine(id, currVal, maxVal, true);
}

void Player::AddSkillLine(uint32 id, uint16 currVal, uint16 maxVal, bool sendUpdate)
{
	struct skilllines newline;
	newline.lineId = id;
	newline.currVal = currVal;
	newline.maxVal = maxVal;
	newline.posStatCurrVal = 0;
	newline.posstatMaxVal = 0;

	uint32 CurMax = 0;
	CurMax |= ((uint32)(maxVal << 16)) | currVal;

	if (!HasSkillLine(id))
	{
		newline.place = m_skilllines.size()+1;
		m_skilllines.push_back(newline);
	}

	if (sendUpdate)
	{
		uint16 LineBase = PLAYER_SKILL_INFO_1_1 + (m_skilllines.size() * 3);

		SetUInt32Value(LineBase, id);
		SetUInt32Value(LineBase + 1, CurMax);
		SetUInt32Value(LineBase + 2, 0);

		//save base skillline
		SetBaseUInt32Value(LineBase, id);
		SetBaseUInt32Value(LineBase + 1, CurMax);
		SetBaseUInt32Value(LineBase + 2, 0);
	}
}
void Player::RemoveSkillLine(uint32 id)
{
}

void Player::smsg_InitialActions()
{
	//Log::getSingleton( ).outString( "Initializing Action Buttons for '%u'", GetGUID() );
	WorldPacket data;
	uint16 actionCount = m_actions.size();
	uint16 button=0;

	std::list<struct actions>::iterator itr;
	data.Initialize(SMSG_ACTION_BUTTONS);
	for (itr = m_actions.begin(); itr != m_actions.end();)
	{
		if (itr->button == button)
		{
			data << uint16(itr->action);
			data << uint8(itr->type);
			data << uint8(itr->misc);
			++itr;
		}
		else
		{
			data << uint32(0);
		}
		button++;
	}

	if (button < 120 )
	{
		for (int temp_counter=(120-button); temp_counter>0; temp_counter--)
		{
			data << uint32(0);
		}
	}
	GetSession()->SendPacket( &data );
	//Log::getSingleton( ).outString( "Action Buttons for '%u' Initialized", GetGUID() );
}

void Player::addAction(const uint8 button, const uint16 action, const uint8 type, const uint8 misc)
{
	bool ButtonExists = false;
	std::list<struct actions>::iterator itr;
	for (itr = m_actions.begin(); itr != m_actions.end(); ++itr)
	{
		if (itr->button == button)
		{
			itr->button=button;
			itr->action=action;
			itr->type=type;
			itr->misc=misc;
			ButtonExists = true;
			break;
		}
	}
	if (!ButtonExists)
	{
		struct actions newaction;
		newaction.button=button;
		newaction.action=action;
		newaction.type=type;
		newaction.misc=misc;
		m_actions.push_back(newaction);
	}
	//Log::getSingleton( ).outString( "Player '%u' Added Action '%u' to Button '%u'", GetGUID(), action, button );
}

void Player::removeAction(uint8 button)
{
	std::list<struct actions>::iterator itr;
	for (itr = m_actions.begin(); itr != m_actions.end(); ++itr)
	{
		if (itr->button == button)
		{
			m_actions.erase(itr);
			break;
		}
	}
	Log::getSingleton( ).outString( "Action Button '%u' Removed from Player '%u'", button, GetGUID() );
}

//Groupcheck
bool Player::IsGroupMember(Player *plyr)
{
	if(!plyr || !plyr->IsInGroup())
		return false;
	Group *grp = objmgr.GetGroupByLeader(plyr->GetGroupLeader());
	if(grp->GroupCheck(plyr->GetGUID()))
	{
		return true;
	}
	return false;
}


uint16 Player::GetOpenQuestSlot()
{
	uint16 start = PLAYER_QUEST_LOG_1_1;
	uint16 end = PLAYER_QUEST_LOG_1_1 + 60;
	for (uint16 i = start; i <= end; i+=3)
		if (GetUInt32Value(i) == 0)
			return i;

	return 0;
}

uint16 Player::GetQuestSlotForEntry(uint32 quest_entry)
{
	uint16 start = PLAYER_QUEST_LOG_1_1;
	uint16 end = PLAYER_QUEST_LOG_1_1 + 60;
	for (uint16 i = start; i <= end; i+=3)
		if (GetUInt32Value(i) == quest_entry)
			return i;

	return 0;
}

uint32 Player::GetQuestEntryInSlot(uint8 slot)
{
	return GetUInt32Value(PLAYER_QUEST_LOG_1_1 + slot*3);
}

void Player::ResetQuestSlots()
{
	uint16 start = PLAYER_QUEST_LOG_1_1;
	uint16 end = PLAYER_QUEST_LOG_1_1 + 60;
	for (uint16 i = start; i < end; i++)
		SetUInt32Value(i, 0);
}

void Player::Add_QLE(QuestLogEntry* quest_entry)
{
	m_questentry[quest_entry->GetQuest()->GetID()] = quest_entry;
}

void Player::Del_QLE(uint32 quest_entry)
{
	std::map<uint32, QuestLogEntry *>::const_iterator itr = m_questentry.find(quest_entry);
	if(itr == m_questentry.end())
		return;
	else
	{
		delete itr->second;
		m_questentry.erase(quest_entry);
		return;
	}
}

QuestLogEntry* Player::Find_QLE(uint32 quest_entry)
{
	std::map<uint32, QuestLogEntry *>::const_iterator itr = m_questentry.find(quest_entry);
	if(itr == m_questentry.end())
		return NULL;
	else
		return itr->second;
}

void Player::AddToFinishedQuests(uint32 quest_id)
{
	//maybe that shouldn't be an assert, but i'll leave it for now
	ASSERT(m_finishedQuests.find(quest_id) == m_finishedQuests.end());

	m_finishedQuests.insert(quest_id);
}

bool Player::HasFinishedQuest(uint32 quest_id)
{
	return (m_finishedQuests.find(quest_id) != m_finishedQuests.end());
}

//DK: FriendList
void Player::SendFriendListData()
{
	WorldPacket data;

	unsigned char Counter=0;

	Player* pFriend = NULL;

	std::list<struct FriendStr>::iterator i;

	Counter=(unsigned char)(m_friendList.size());

	data.Initialize( SMSG_FRIEND_LIST );
	data << Counter;

	for (i = m_friendList.begin(); i != m_friendList.end(); i++) 
	{
		// adding friend
		pFriend = objmgr.GetObject<Player>(i->PlayerGUID);
		if(pFriend)
		{
			i->Status = 1;
			i->Area = pFriend->GetZoneId();
			i->Level = pFriend->getLevel();
			i->Class = pFriend->getClass();
		}
		else
		{
			i->Status = 0;
			i->Area = 0;
			i->Level = 0;
			i->Class = 0;
		}
		//		Log::getSingleton( ).outDetail( "WORLD: Adding Friend - Guid:%ld, Status:%d, Area:%d, Level:%d Class:%d",i->PlayerGUID, i->Status, i->Area,i->Level,i->Class  );

		data << i->PlayerGUID << i->Status ;
		if (i->Status != 0)
			data << i->Area << i->Level << i->Class;
	}

	GetSession()->SendPacket( &data );
}

void Player::DeleteFriend(uint64 FriendGuid)
{
	std::list<FriendStr>::iterator i;
	for (i = m_friendList.begin(); i != m_friendList.end();) 
	{
		if (i->PlayerGUID == FriendGuid)
		{
			m_friendList.erase(i++);
		}
		else
		{
			++i;
		}
	}
}

//Trade
void Player::DelTradeItem(uint8 slot)
{
	std::list<TradeItem*>::iterator itr;
	for (itr = m_tradeitems.begin(); itr != m_tradeitems.end();)
	{
		if ((*itr)->TradeSlot == slot)
		{
			m_tradeitems.erase(itr++);
		}
		else
		{
			++itr;
		}
	}
}

void Player::AddTradeItem(TradeItem *ti)
{
	std::list<TradeItem*>::iterator itr;
	for (itr = m_tradeitems.begin(); itr != m_tradeitems.end();)
	{
		if ((*itr)->TradeSlot == ti->TradeSlot)
		{
			m_tradeitems.erase(itr++);
		}
		else
		{
			++itr;
		}
	}
	//>::iterator insert 
	m_tradeitems.push_back(ti);
	//m_tradeitems.insert(ti->TradeSlot,ti);
}

TradeItem* Player::GetTradeItem(uint8 slot)
{
	std::list<TradeItem*>::iterator itr;
	for (itr = m_tradeitems.begin(); itr != m_tradeitems.end();)
	{
		if ((*itr)->TradeSlot == slot)
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

void Player::PlaceItemsOnMap()
{
	//only to execute when player is not In world
	for(uint16 i = 0; i < BANK_SLOT_BAG_END; i++)
	{
		if(m_items[i] && m_items[i]->IsInWorld() == false)
		{
			m_items[i]->AddToWorld();
			if(m_items[i]->pContainer && m_items[i]->pContainer->IsInWorld() == false)
			{
				m_items[i]->pContainer->AddToWorld();
			}
		}
	}
}

void Player::BuildInventoryChangeError(Item *SrcItem, Item *DstItem, uint8 Error)
{
	WorldPacket data;

	data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
	data << Error;

	if(Error == 1) 
	{
		if(SrcItem)
		{
			data << SrcItem->GetProto()->RequiredLevel;
		}
	}

	if(SrcItem)
	{
		if(SrcItem->GetProto()->InventoryType == INVTYPE_BAG)
		{
			data << (SrcItem->pContainer ? SrcItem->pContainer->GetGUID() : uint64(0));
		}
		else
		{
			data << (SrcItem ? SrcItem->GetGUID() : uint64(0));
		}
	}
	else
	{
		data << (SrcItem ? SrcItem->GetGUID() : uint64(0));
	}

	if(DstItem)
	{
		if( DstItem->GetProto()->InventoryType == INVTYPE_BAG)
		{
			data << (DstItem->pContainer ? DstItem->pContainer->GetGUID() : uint64(0));
		}
		else
		{
			data << (DstItem ? DstItem->GetGUID() : uint64(0));
		}
	}
	else
	{
		data << (DstItem ? DstItem->GetGUID() : uint64(0));
	}
	data << uint8(0);

	GetSession()->SendPacket( &data );
}

// Charter
void Player::AddSignedCharter(uint32 charterId)
{
	Charter *c = new Charter;
	c->charterId = charterId;
	m_charterList.push_back(c);
}

// if chartermaster deletes charter
void Player::DeleteSignedCharter(uint32 charterId)
{
	std::list<Charter*>::iterator i;
	for(i = m_charterList.begin(); i != m_charterList.end(); i++)
	{
		if((*i)->charterId == charterId)
		{
			m_charterList.erase(i);
		}
	}
}

// if user deletes player or joins guild we ll use that
void Player::DeleteFromSignedCharters(uint32 charterId)
{
	uint64 guid = GetGUID();

	std::list<Charter*>::iterator i;
	for(i = m_charterList.begin(); i != m_charterList.end(); i++)
	{
		if((*i)->charterId != charterId)
		{
			guildCharter *gc = objmgr.GetGuildCharterByCharterGuid( (*i)->charterId );
			std::list<charterName>::iterator nameItr;
			for(nameItr = gc->signList.begin(); nameItr != gc->signList.end(); nameItr++)
			{
				if(nameItr->signer == guid)
					gc->signList.erase(nameItr);
			}
		}
	}
}

// If player joins to a guild we will delete
void Player::DeleteAllCharterData()
{
	std::list<Charter*>::iterator i;
	for(i = m_charterList.begin(); i != m_charterList.end();)
	{
		i = m_charterList.erase(i);
	}    
}

void Player::UpdatePVPStatus(uint32 AreaID)
{
	PvPArea * pvparea = objmgr.GetPvPArea(AreaID);
	uint8 race = getRace();
	if(pvparea != NULL)
	{
		//sLog.outDebug("Got PVP Area Info for Area %s(%u) with a type of %u", pvparea->AreaName.c_str(), pvparea->AreaId, pvparea->PvPType);
		switch(pvparea->PvPType)
		{
		case AREA_ALLIANCE:
			{
				if(race == RACE_ORC || race == RACE_UNDEAD || race == RACE_TAUREN || race == RACE_TROLL) //Horde
				{
					if(!HasFlag(UNIT_FIELD_FLAGS,U_FIELD_FLAG_PVP))
						SetFlag(UNIT_FIELD_FLAGS,U_FIELD_FLAG_PVP);
					
					if(HasFlag(PLAYER_FLAGS,PLAYER_FLAG_FREE_FOR_ALL_PVP))
						RemoveFlag(PLAYER_FLAGS,PLAYER_FLAG_FREE_FOR_ALL_PVP);

					PvPTimeoutUpdate(true);
				}
				else if(HasFlag(UNIT_FIELD_FLAGS,U_FIELD_FLAG_PVP) && PvPTimeoutEnabled == false)
				{
					PvPTimeoutUpdate(false);
				}
			}break;
		case AREA_HORDE:
			{
				if(race == RACE_HUMAN || race == RACE_DWARF || race == RACE_NIGHTELF || race == RACE_GNOME) //Alliance
				{
					if(!HasFlag(UNIT_FIELD_FLAGS,U_FIELD_FLAG_PVP))
						SetFlag(UNIT_FIELD_FLAGS,U_FIELD_FLAG_PVP);
					
					if(HasFlag(PLAYER_FLAGS,PLAYER_FLAG_FREE_FOR_ALL_PVP))
						RemoveFlag(PLAYER_FLAGS,PLAYER_FLAG_FREE_FOR_ALL_PVP);

					PvPTimeoutUpdate(true);
				}
				else if(HasFlag(UNIT_FIELD_FLAGS,U_FIELD_FLAG_PVP) && PvPTimeoutEnabled == false)
				{
					PvPTimeoutUpdate(false);
				}
			}break;
		case AREA_CONTESTED:
			{
				if(!HasFlag(UNIT_FIELD_FLAGS,U_FIELD_FLAG_PVP))
					SetFlag(UNIT_FIELD_FLAGS,U_FIELD_FLAG_PVP);
					
				if(HasFlag(PLAYER_FLAGS,PLAYER_FLAG_FREE_FOR_ALL_PVP))
					RemoveFlag(PLAYER_FLAGS,PLAYER_FLAG_FREE_FOR_ALL_PVP);

				PvPTimeoutUpdate(true);
			}break;
		case AREA_PVPARENA:
			{
				if(!HasFlag(UNIT_FIELD_FLAGS,U_FIELD_FLAG_PVP))
					SetFlag(UNIT_FIELD_FLAGS,U_FIELD_FLAG_PVP);
					
				if(!HasFlag(PLAYER_FLAGS,PLAYER_FLAG_FREE_FOR_ALL_PVP))
					SetFlag(PLAYER_FLAGS,PLAYER_FLAG_FREE_FOR_ALL_PVP);
				
				PvPTimeoutUpdate(true);
			}break;
		}
	}
	else
	{
		//sLog.outDebug("PVPArea Information for AreaID '%u' was not found", AreaID);
	}
}

void Player::EventStopPvP()
{
	PvPTimeoutEnabled = false;
	sLog.outDebug("Removing PVP Flags");
	if(HasFlag(UNIT_FIELD_FLAGS,U_FIELD_FLAG_PVP))
		RemoveFlag(UNIT_FIELD_FLAGS,U_FIELD_FLAG_PVP);
	
	if(HasFlag(PLAYER_FLAGS,PLAYER_FLAG_FREE_FOR_ALL_PVP))
		RemoveFlag(PLAYER_FLAGS,PLAYER_FLAG_FREE_FOR_ALL_PVP);
}

void Player::PvPTimeoutUpdate(bool Remove)
{
	if(Remove == true)
	{
		if(PvPTimeoutEnabled == true)
		{
			sLog.outDebug("Removing PVP Timeout Event");
			sEventMgr.RemoveEvents(this, EVENT_PLAYER_STOPPVP);
			PvPTimeoutEnabled = false;
		}
	}
	else
	{
		if(PvPTimeoutEnabled == false)
		{
			sLog.outDebug("Adding PVP Timeout Event");
			sEventMgr.AddEvent(this, &Player::EventStopPvP, EVENT_PLAYER_STOPPVP, 300000, 0);
			PvPTimeoutEnabled = true;
		}
	}
}

//From Mangos Project
void Player::_LoadTutorials()
{	
	std::stringstream query;
	query << "SELECT * FROM tutorials WHERE playerId=" << GetGUIDLow();
	QueryResult *result = sDatabase.Query( query.str().c_str() );

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

void Player::_SaveTutorials()
{		
	std::stringstream query;
	std::stringstream query2;
	query << "DELETE FROM tutorials WHERE playerId = " << GetGUIDLow();
	sDatabase.Execute( query.str().c_str() );

	query2 << "INSERT INTO tutorials (playerId,tut0,tut1,tut2,tut3,tut4,tut5,tut6,tut7) VALUES ('" << GetGUIDLow() << "','" << m_Tutorials[0] << "','" << m_Tutorials[1] << "','" << m_Tutorials[2] <<"','" << m_Tutorials[3] << "','" << m_Tutorials[4] << "','" << m_Tutorials[5] << "','" << m_Tutorials[6] << "','" << m_Tutorials[7] << "');";
	sDatabase.Execute( query2.str().c_str() );
}

uint32 Player::GetTutorialInt(uint32 intId )
{
	ASSERT( (intId < 8) );
	return m_Tutorials[intId];
}

void Player::SetTutorialInt(uint32 intId, uint32 value)
{
	ASSERT( (intId < 8) );
	m_Tutorials[intId] = value;
}

//Player stats calculation for saving at lvl up, etc
void Player::CalcBaseStats()
{//((Player*)this)->getClass() == HUNTER ||
	//TODO take into account base stats at create
	uint32 AP, RAP;
	//Save AttAck power
	if(getClass() == ROGUE || getClass() == HUNTER)
	{
		AP = GetBaseUInt32Value(UNIT_FIELD_STAT0) + GetBaseUInt32Value(UNIT_FIELD_STAT1);
		RAP = (GetBaseUInt32Value(UNIT_FIELD_STAT1) * 2);
		SetBaseUInt32Value(UNIT_FIELD_ATTACK_POWER, AP);
		SetBaseUInt32Value(UNIT_FIELD_RANGED_ATTACK_POWER, RAP);
	}
	else
	{
		AP = (GetBaseUInt32Value(UNIT_FIELD_STAT0) * 2);
		RAP = (GetBaseUInt32Value(UNIT_FIELD_STAT1) * 2);
		SetBaseUInt32Value(UNIT_FIELD_ATTACK_POWER, AP);
		SetBaseUInt32Value(UNIT_FIELD_RANGED_ATTACK_POWER, RAP);
	}

}
void Player::EnterInn()
{
	sEventMgr.RemoveEvents(this, EVENT_PLAYER_RESTSTART);
	sEventMgr.AddEvent(this, &Player::EventPlayerRestStart, EVENT_PLAYER_RESTSTART, (uint32)6000, 1);
}

void Player::ExitInn()
{
	this->m_isResting = false;
	this->RemoveFlag(PLAYER_FLAGS,PLAYER_FLAG_RESTING);	//remove zzz icon
	sEventMgr.RemoveEvents(this, EVENT_PLAYER_REST);
	UpdateRestState();
}

void Player::AddRestXP(uint32 amount)
{
	uint32 CurrentXP = GetUInt32Value(PLAYER_REST_STATE_EXPERIENCE);
	CurrentXP += amount;
	// Figure out max xp of current level

	int level = (GetUInt32Value(UNIT_FIELD_LEVEL) - 1);
	int nextLvlXP = 0;
	if( level >= 0 && level <= 30 )
	{
		nextLvlXP = ((int)((((double)(8 * level * ((level * 5) + 45)))/100)+0.5))*100;
	}
	else if( level == 31 )
	{
		nextLvlXP = ((int)((((double)(((8 * level) + 3) * ((level * 5) + 45)))/100)+0.5))*100;
	}
	else if( level == 32 )
	{
		nextLvlXP = ((int)((((double)(((8 * level) + 6) * ((level * 5) + 45)))/100)+0.5))*100;
	}
	else
	{
		nextLvlXP = ((int)((((double)(((8 * level) + ((level - 30) * 5)) * ((level * 5) + 45)))/100)+0.5))*100;
	}
	if(CurrentXP > nextLvlXP)		// this needs formula
		CurrentXP = nextLvlXP;
	
    SetUInt32Value(PLAYER_REST_STATE_EXPERIENCE, CurrentXP);
	if(GetUInt32Value(PLAYER_REST_STATE_EXPERIENCE) > GetUInt32Value(PLAYER_XP) && m_restState != RESTSTATE_RESTED) {
		if(m_restState != RESTSTATE_NORMAL) {
		m_restState = RESTSTATE_NORMAL;
		this->UpdateRestState(); }
	} else {
		if(m_restState != RESTSTATE_RESTED) {
			m_restState = RESTSTATE_RESTED;
			this->UpdateRestState();
		}
	}
	Update(0);
}

void Player::SubtractRestXP(uint32 amount)
{
	uint32 CurrentXP = GetUInt32Value(PLAYER_REST_STATE_EXPERIENCE);
	if (amount >= CurrentXP)
	{
		// We've reached our rest xp barrier, kill it.
		if(m_restState != RESTSTATE_NORMAL) {
		m_restState = RESTSTATE_NORMAL;
		this->UpdateRestState(); }
	} else {
		if(m_restState != RESTSTATE_RESTED) {
			m_restState = RESTSTATE_RESTED;
			this->UpdateRestState(); }
	}
}

uint32 Player::CalculateRestXP(uint32 seconds)
{
	if(seconds < 60)
	{
		return (uint32)1;
	} else {
		return (uint32)seconds/60;
	}
	//float minutes = seconds;
	// minutes*=10;
	//return (uint32)minutes;
}

void Player::EventPlayerRest()
{
	// Rest timer
	float diff = difftime(time(NULL),m_lastRestUpdate);
	m_lastRestUpdate = time(NULL);
	uint32 RestXP = this->CalculateRestXP((uint32)diff);
	Log::getSingleton( ).outDebug("REST: Adding %d rest XP for %.0f seconds of rest time", RestXP, diff);
	this->AddRestXP(RestXP);
}

void Player::UpdateRestState()
{
	uint32 CurrentFlags;
	uint8 facialhair;
	CurrentFlags = GetUInt32Value(PLAYER_BYTES_2);
	facialhair = uint8(CurrentFlags & 0xff);
	SetUInt32Value(PLAYER_BYTES_2, (facialhair | (0xEE << 8) | (0x01 << 16) | ((m_restState) << 24)));
}

void Player::EventBreathReduce()
{
	if(GetUInt32Value(UNIT_FIELD_HEALTH) <= 0) return;		// no point continuing if no health
	if(m_Breath == 0)
	{
		// Start loosing health oh noes!
		m_Breath = 0;
		WorldPacket pkt;
		pkt.Initialize(SMSG_ENVIRONMENTALDAMAGELOG);
		pkt << GetGUID();
		pkt << (uint8)1;	// breath
		pkt << (uint32)20;	// amount
		pkt << (uint32)0;	// unk
		pkt << (uint32)0;	// unk
		GetSession()->SendPacket(&pkt);
		DealDamage(this,20,0,0,0);
		if(GetUInt32Value(UNIT_FIELD_HEALTH) == 0)
		{
			sEventMgr.RemoveEvents(this,EVENT_PLAYER_UNDERWATER);
			sEventMgr.RemoveEvents(this,EVENT_PLAYER_REGENBREATH);
			return;
		}
		/*uint32 HP = 0;
		HP = GetUInt32Value(UNIT_FIELD_HEALTH);
		HP -= 20;
		if(HP<=0)
		{
			SetUInt32Value(UNIT_FIELD_HEALTH,0);
			setDeathState(JUST_DIED);
			RemoveAllAffects();
			return;
		} else {
			SetUInt32Value(UNIT_FIELD_HEALTH,HP);
		}*/
	} else {
		m_Breath -= 1000;
	}
	sEventMgr.AddEvent(this,&Player::EventBreathReduce,EVENT_PLAYER_UNDERWATER,1000,1);	
}

void Player::EventBreathRegen()
{
	m_Breath += 5000;
	if(m_Breath >= 30000)
	{
		m_Breath = 30000;
		sEventMgr.RemoveEvents(this, EVENT_PLAYER_REGENBREATH);
		WorldPacket pkt;
		pkt.Initialize(SMSG_STOP_MIRROR_TIMER);
		pkt << (uint32)1;
		GetSession()->SendPacket(&pkt);
	} else {
		sEventMgr.AddEvent(this,&Player::EventBreathRegen,EVENT_PLAYER_REGENBREATH,1000,1);
	}
}

void Player::EventPlayerRestStart()
{
	m_restState = RESTSTATE_RESTED;
	m_isResting = true;

	this->SetFlag(PLAYER_FLAGS, PLAYER_FLAG_RESTING);	//put zzz icon
	// this->SetUInt32Value(PLAYER_REST_STATE_EXPERIENCE,400);
	uint32 CurrentFlags;
	uint8 facialhair;
	CurrentFlags = GetUInt32Value(PLAYER_BYTES_2);
	facialhair = uint8(CurrentFlags & 0xff);
	SetUInt32Value(PLAYER_BYTES_2, (facialhair | (0xEE << 8) | (0x01 << 16) | (0x01 << 24)));
	// sEventMgr.AddEvent(this, &Player::Update, (uint32)100, EVENT_PLAYER_UPDATE, 100, 0);
	m_lastRestUpdate = (uint32)time(NULL);
	sEventMgr.AddEvent(this, &Player::EventPlayerRest, EVENT_PLAYER_REST, (uint32)60000, 0);
	UpdateRestState();
	sEventMgr.RemoveEvents(this, EVENT_PLAYER_RESTSTART);
}
