#include "StdAfx.h"

#include "../Shared/MersenneTwister.h"

#define MOB_LOOK_FOR_HELP_TIMER 500

//-----------------------------------------------------------------------------
Creature::Creature() : Unit()
{
    mQuestIds.clear();
    mInvolvedQuestIds.clear();

    m_corpseDelay = 60000;
    //m_respawnDelay = 10000;

    m_respawnTimer = 0;
    m_deathTimer = 0;
    m_moveTimer = 0;

	// how often mob in combat check place around for family
	m_lookForHelpTimer = MOB_LOOK_FOR_HELP_TIMER;

    m_valuesCount = UNIT_END;

    //itemcount = 0;
    //memset(item_list, 0, 8 * MAX_CREATURE_ITEMS);
	item_list.clear();

    //m_nWaypoints = 0;
    m_currentWaypoint = 0;
    //m_moveBackward = false;
    //m_moveRandom = false;
    m_moveRun = false;
    m_creatureState = AI_STATE_STOPPED;

    m_destinationX = m_destinationY = m_destinationZ = 0;
    m_moveSpeed = 0;
    m_timeToMove = 0;
    m_timeMoved = 0;

	m_movementType = FLAT_RANDOM_ROAM;
	m_spawnTime[0] = 10;
	m_spawnTime[1] = 10;
	m_spawnDist = 5;

	m_defaultNPCText = 0xffffff; // standard text

	m_flee = FLEE_STATE_NONE;
	//m_fleeFrom = NULL;
	
	m_creatureTemplate = NULL;
	
	m_alertAtWaypoint = -1;
	m_alertAtWaypointValue = 0;
}

//-----------------------------------------------------------------------------
Creature::~Creature()
{
    mQuestIds.clear( );
    mInvolvedQuestIds.clear();
}

//-----------------------------------------------------------------------------
void Creature::Flee (Unit *from, int seconds, int helpRadius)
{
	m_attackTimer = 1000 * seconds;
	m_flee = FLEE_STATE_FLEE;
	AI_ChangeState (AI_STATE_STOPPED);
	//m_fleeFrom = from;
	m_fleeHelpRadius = helpRadius;
	m_moveTimer = 0;
}

//-----------------------------------------------------------------------------
void Creature::UpdateMobMovement( int32 p_time)
{
	int32 timediff = 0;

	if(m_moveTimer > 0)
	{
		if(p_time >= m_moveTimer)
		{
			timediff = p_time - m_moveTimer;
			m_moveTimer = 0;
		}
		else
			m_moveTimer -= p_time;
	}

	if (m_timeToMove > 0) {
		if (m_timeToMove <= p_time + m_timeMoved) 
			m_timeMoved = m_timeToMove;
		else
			m_timeMoved += p_time;
	}

	//---------------------------------------------
	//  FLEEING IS QUITE SPECIAL
	//---------------------------------------------
	if (m_flee > FLEE_STATE_NONE)
	{
		// When fleeing and still have enemy, do search for friends around
		/*if (m_flee == FLEE_STATE_FLEE && isInCombat())
		{
			if ( SearchForHelpfulFamily ((float)m_fleeHelpRadius) )
			{
				//LookAt (m_fleeFrom);
				Emote (EMOTE_ONESHOT_SHOUT);

				// Attack too
				m_flee = FLEE_STATE_STRIKE_BACK;
				AI_ChangeState (AI_STATE_STOPPED);
				//AI_AttackReaction (m_fleeFrom, 1);
			}
		}*/

		if (!m_moveTimer)
		{
			// Need more flee! Pick next coordinate
			//
			if (m_timeMoved > m_timeToMove)
			{
				// Flee flee flee until timer goes out
				// TODO: Select direction to nearest friends
				float dx, dy;
				dx = ((float)(rand() % 12) - 6) * 5.0f;
				dy = ((float)(rand() % 12) - 6) * 5.0f;

				Log::getSingleton().outDebug ("AI: %X Fleeing, next random point (%.1f, %.1f)",
					GetGUIDLow(), dx, dy);

				AI_MoveTo (m_positionX + dx, m_positionY + dy, m_positionZ, true);
				return;
			}
		}

		// If timer already gone out, run to attack again
		//
		if (m_flee == FLEE_STATE_FLEE && m_attackTimer == 0)
		{
			m_flee = FLEE_STATE_NONE;
			AI_ChangeState (AI_STATE_STOPPED);

			// Still got some hate?
			if ( isInCombat() )
			{
				Log::getSingleton().outDebug ("AI: %X Flee timer finished, now attacking back", GetGUIDLow());
			} else {
				Log::getSingleton().outDebug ("AI: %X Flee timer finished, nobody to attack back", GetGUIDLow());
				return;
			}
		}
	}

	//---------------------------------------------
	//  NORMAL MOVEMENT AND PAUSES
	//---------------------------------------------
	if(m_creatureState == AI_STATE_MOVING)
	{
		if(!m_moveTimer)
		{
			if(m_timeMoved >= m_timeToMove)
			{
				if (m_creatureState == AI_STATE_MOVING)
				{
					m_creatureState = AI_STATE_STOPPED;

					// wait before next move
					uint8 wait1, wait2;
					if (m_movementType == FLAT_RANDOM_ROAM) {
						wait1 = 2;
						wait2 = 10;
					} else {
						wait1 = m_waypoints[m_currentWaypoint].Wait1;
						wait2 = m_waypoints[m_currentWaypoint].Wait2;
					}

					if (wait2 > wait1)
						m_moveTimer = 1000 * (wait1 + rand() % (wait2 - wait1));
					else
						m_moveTimer = 1000 * wait1;

					SetPosition (m_destinationX, m_destinationY, m_destinationZ, m_orientation);
					//AI_SendMoveToPacket (GetPositionX(), GetPositionY(), GetPositionZ(), 1, 1);
					//m_mapMgr->ChangeObjectLocation (this, m_destinationX, m_destinationY);

					m_positionX = m_destinationX;
					m_positionY = m_destinationY;
					m_positionZ = m_destinationZ;
					/*m_destinationX = m_positionX;
					m_destinationY = m_positionY;
					m_destinationZ = m_positionZ;*/

					//m_destinationX = m_destinationY = m_destinationZ = 0;
					m_timeMoved = 0;
					m_timeToMove = 0;
				}
			}
			else
			{
				float q = (float)m_timeMoved / (float)m_timeToMove;

				float newX = m_positionX + (m_destinationX - m_positionX) * q;
				float newY = m_positionY + (m_destinationY - m_positionY) * q;
				float newZ = m_positionZ + (m_destinationZ - m_positionZ) * q;
				
				SetPosition (newX, newY, newZ, m_orientation);
				//m_mapMgr->ChangeObjectLocation (this, GetPositionX(), GetPositionY());

				//uint32 moveTime = (uint32) ((moveDistance-destMoved) / m_moveSpeed);

				m_timeToMove -= m_timeMoved;
				if (timediff <= m_timeToMove) m_timeToMove -= timediff;
				m_timeMoved = 0;

				m_moveTimer = min (UNIT_MOVEMENT_INTERPOLATE_INTERVAL, m_timeToMove);
			}
		} // still moving
	}
	else
		if(m_creatureState == AI_STATE_STOPPED && !m_moveTimer && !m_timeMoved)
			//creature is stopped
		{
			if ((m_movementType == FLAT_RANDOM_ROAM) && GetUInt64Value(UNIT_FIELD_SUMMONEDBY) == 0)
			{
				if (m_spawnDist >= 1.0f) {
					float dx, dy;
					dx = (float)(rand() % (uint32)m_spawnDist) - m_spawnDist * 0.5f;
					dy = (float)(rand() % (uint32)m_spawnDist) - m_spawnDist * 0.5f;

					AI_MoveTo (respawn_cord[0] + dx, respawn_cord[1] + dy, respawn_cord[2], m_moveRun);
				} 
				else
				{
					if (GetPositionX() != respawn_cord[0] && GetPositionY() != respawn_cord[1] &&
						GetPositionZ() != respawn_cord[2]) 
					{
						// Run back to spawn
						// QUESTION?? Set Evade here?
						AI_MoveTo (respawn_cord[0], respawn_cord[1], respawn_cord[2], true);
					}
				}

				return;
			}

			if (m_waypoints.size() > 1) {
				if (m_movementType == FOLLOW_PATH_FORTH || m_movementType == LOOP_PATH_FORTH)
				{
					// going from 0..(n-1)
					m_currentWaypoint++;
				} else
					if (m_movementType == FOLLOW_PATH_BACK || m_movementType == LOOP_PATH_BACK)
					{
						// going (n-1)..0 back
						m_currentWaypoint--;
					}
					switch (m_movementType) 
					{
					case RANDOM_ROAM:
						m_currentWaypoint = rand() % m_waypoints.size();
						break;

					case FOLLOW_PATH_FORTH:
						if (m_currentWaypoint >= m_waypoints.size()) {
							m_movementType = FOLLOW_PATH_BACK; // Bounce and go back
							m_currentWaypoint = m_waypoints.size() - 2;
						}
						break;
					case FOLLOW_PATH_BACK:
						if ((int)m_currentWaypoint < 0) {
							m_movementType = FOLLOW_PATH_FORTH; // Bounce and go back
							m_currentWaypoint = 1;
						}
						break;
					case LOOP_PATH_FORTH:
						if (m_currentWaypoint >= m_waypoints.size()) {				
							m_currentWaypoint = 0;	// Loop
						}
						break;
					case LOOP_PATH_BACK:
						if ((int)m_currentWaypoint < 0) {
							m_currentWaypoint = m_waypoints.size() - 1;
						}
						break;
					}

					/*if (m_waypoints.size() != 0) 
					m_currentWaypoint = m_currentWaypoint % m_waypoints.size();
					else
					m_currentWaypoint = 0;
					*/

					if (m_alertAtWaypoint == m_currentWaypoint)
					{
						Call_Unit_OnWaypoint (this, m_alertAtWaypointValue);
					}

					AI_MoveTo (m_waypoints[m_currentWaypoint].x,
						m_waypoints[m_currentWaypoint].y,
						m_waypoints[m_currentWaypoint].z,
						m_moveRun);
			}
		}
}

//-----------------------------------------------------------------------------
void Creature::ResetRespawnTimer (uint32 time1, uint32 time2)
{
	if (time1)
		m_spawnTime[0] = time1;
	
	if (time2)
		m_spawnTime[1] = time2;
	else
		if (time1) m_spawnTime[1] = time1;

	// Random respawn time between spawntime0 and spawntime1
	uint32 resp_t = m_spawnTime[0];

	if (m_spawnTime[1] > m_spawnTime[0])
	{
		resp_t += rand() % (m_spawnTime[1] - m_spawnTime[0]);
	}
	m_respawnTimer = resp_t * 1000;
}

//-----------------------------------------------------------------------------
void Creature::Update( int32 p_time )
{
    Unit::Update( p_time );

    if (m_deathState == JUST_DIED)
    {
        //unsetUpdateMaskBit(UNIT_NPC_FLAGS);
        //UpdateObject();


		// remove me as an attacker from the AttackMap
        //ClearHate();
		m_targets.clear();
		m_creatureState = AI_STATE_STOPPED;
		m_flee = FLEE_STATE_NONE;
		// TODO: Group death cleanup somewhere

        m_deathState = CORPSE;
    }

    if(m_deathTimer > 0)
    {
        if(p_time >= m_deathTimer)
            m_deathTimer = 0;
        else
            m_deathTimer -= p_time;

        if (m_deathTimer <= 0)
        {
            // time to respawn!
            Log::getSingleton( ).outDetail("Removing corpse...");

            RemoveFromMap();
			ResetRespawnTimer();
            setDeathState(DEAD);

            SetPosition (respawn_cord[0], respawn_cord[1], respawn_cord[2], respawn_angle);

			if (GetUInt64Value(UNIT_FIELD_SUMMONEDBY) != 0)
			{
				Unit *Summoner = objmgr.GetObject<Creature>(GetUInt64Value(UNIT_FIELD_SUMMONEDBY));
				if(Summoner == NULL)
					Summoner = objmgr.GetObject<Player>(GetUInt64Value(UNIT_FIELD_SUMMONEDBY));
				
				if(Summoner != NULL)
				{
					Summoner->SetUInt64Value(UNIT_FIELD_SUMMONEDBY, 0);
					if(Summoner->isPlayer())
					{
						WorldPacket data;
						data.Initialize(SMSG_PET_SPELLS);
						data << (uint64)0;
						((Player*)Summoner)->GetSession()->SendPacket(&data);
					}
				}
				RemoveFromWorld();
				DeleteFromDB();

				objmgr.RemoveObject_Free(this);
			}

            return;
        }
    }
    else if (m_respawnTimer > 0)
    {
        if(p_time >= m_respawnTimer)
            m_respawnTimer = 0;
        else
            m_respawnTimer -= p_time;

        if(m_respawnTimer <= 0)
        {
            WorldPacket data;

            //Log::getSingleton( ).outDetail("Respawning...");

            SetHealth (GetMaxHealth());

            PlaceOnMap();
			ResetRespawnTimer();

            setDeathState(ALIVE);
            m_creatureState = AI_STATE_STOPPED; // after respawn monster can move
        }
    }

	// If stunned (sapped) then don't look for allies and don't move
	//
	if (isStunned())
		return;

	// If in combat and timer allows, check around for brothers
	//
	if (isInCombat())
	{
		if (p_time < m_lookForHelpTimer)
			m_lookForHelpTimer -= p_time;
		else 
		{
			m_lookForHelpTimer = MOB_LOOK_FOR_HELP_TIMER;

			// Share hate with surrounding friends
			uint32 f = GetFaction();
			if (FACTION_ALL_HOSTILE(f) || FACTION_ALLIANCE_HOSTILE(f) || FACTION_HORDE_HOSTILE(f))
				SearchForHelpfulFamily (10.0f);
		}
	}

    // FIXME
    if (isAlive())
    {
        UpdateMobMovement( p_time );
        AI_Update();

        // Clear the NPC flags bit so it doesn't get auto- updated each frame. NPC flags are set per player and this would ruin is
        // Ignatich: do not understand this yet
        //unsetUpdateMaskBit(UNIT_NPC_FLAGS);
        //UpdateObject();
    }
}

//-----------------------------------------------------------------------------
void Creature::Create (uint32 guidlow, const char* name, uint32 mapid, float x, float y, float z, float ang)
{
    Object::_Create(guidlow, HIGHGUID_UNIT, mapid, x, y, z, ang);
	UnitToFollow = NULL;

    respawn_cord[0] = x;
    respawn_cord[1] = y;
    respawn_cord[2] = z;
	respawn_angle = ang;

    m_name = name;

	// Equip NPC
	EquipNPC();
	////////////
}

//-----------------------------------------------------------------------------
/// Quests
uint32 Creature::getDialogStatus(Player *pPlayer, uint32 defstatus)
{
	bool wasReward  = false;
	bool wasRewardRep  = false;
	bool wasAvail   = false;
	bool wasIncompl = false;
	bool wasAnavail = false;

	bool wasAvailShow   = false;
	bool wasUnavailShow = false;

    uint32 quest_id;
    uint32 status;
    Quest *pQuest;

    for( list<uint32>::iterator i = mQuestIds.begin( ); i != mQuestIds.end( ); ++ i )
    {
        quest_id = *i;
        status = pPlayer->getQuestStatus(quest_id);
        pQuest = objmgr.GetQuest(quest_id);

		if ( pQuest == NULL ) continue;

		if ( !pQuest->QuestPreReqSatisfied( pPlayer ) || 
			 !pQuest->QuestIsCompatible( pPlayer ) ||
			  pQuest->QuestRewardIsTaken( pPlayer ) 
			) continue;

		if ( status == QUEST_STATUS_INCOMPLETE ) wasIncompl = true;

		if ( status == QUEST_STATUS_COMPLETE )
		{
			if (pQuest->HasBehavior( QUEST_BEHAVIOR_REPEATABLE ))			
				wasRewardRep = true; else
				wasReward  = true;
		}
		if ( status == QUEST_STATUS_AVAILABLE )
		{
			if ( pQuest->QuestCanShowAvailable( pPlayer ) ) wasAvailShow = true;

			wasAvail   = true;
		}

		if ( status == QUEST_STATUS_UNAVAILABLE )
		{
			wasAnavail = true;
			if ( pQuest->QuestCanShowUnsatified( pPlayer ) ) wasUnavailShow = true;

		}

        if ( status == QUEST_STATUS_NONE )
        {
			if (!pQuest->QuestLevelSatisfied( pPlayer ))
			{
                pPlayer->addNewQuest(quest_id, QUEST_STATUS_UNAVAILABLE );
				if ( pQuest->QuestCanShowUnsatified( pPlayer ) ) wasUnavailShow = true;

				wasAnavail = true;
			}
            else
			{
                pPlayer->addNewQuest(quest_id, QUEST_STATUS_AVAILABLE );
				if ( pQuest->QuestCanShowAvailable( pPlayer ) ) wasAvailShow = true;

				wasAvail = true;
			}
        }
    }

   // Involvers

   for( list<uint32>::iterator i = mInvolvedQuestIds.begin( ); i != mInvolvedQuestIds.end( ); ++ i )
    {
        quest_id = *i;
        status = pPlayer->getQuestStatus(quest_id);
        pQuest = objmgr.GetQuest(quest_id);

		if ( status == QUEST_STATUS_INCOMPLETE )
		{
			if ( pQuest->HasBehavior( QUEST_BEHAVIOR_SPEAKTO ) )
			    wasReward = true; else
				wasIncompl = true;
		}
    }

	if (wasReward) return DIALOG_STATUS_REWARD;
	if (wasRewardRep) return DIALOG_STATUS_REWARD_REP;

	if (wasAvail)    
	{
		if (wasAvailShow)
			return DIALOG_STATUS_AVAILABLE; else
			return DIALOG_STATUS_CHAT;
	}

	if (wasIncompl)  return DIALOG_STATUS_INCOMPLETE;

	if ( defstatus != DIALOG_STATUS_NONE )
		return defstatus;

	if (wasAnavail)  
	{
		if (wasUnavailShow)
			return DIALOG_STATUS_UNAVAILABLE;
	}

    return DIALOG_STATUS_NONE;
}


// ----------------------------------------------------------------------------
Quest *Creature::getNextAvailableQuest(Player *pPlayer, Quest *prevQuest)
{
    uint32 quest_id;
    uint32 status;
    Quest *pQuest, *lastQuest;

	int wasAvail = 0;

	for( list<uint32>::iterator i = mQuestIds.begin( ); i != mQuestIds.end( ); ++ i )
    {
        quest_id = *i;
        status = pPlayer->getQuestStatus(quest_id);
        pQuest = objmgr.GetQuest(quest_id);

		if ( !pQuest->QuestIsTakable( pPlayer ) ||
			  pQuest == NULL 
			) continue;

		wasAvail++;
		lastQuest = pQuest;
	}

	if ( wasAvail == 1 ) return lastQuest; else
	{
		pQuest = NULL;

		if (prevQuest->m_nextQuest != 0)
			pQuest = objmgr.GetQuest( prevQuest->m_nextQuest );

		if (pQuest)
			if (( pQuest->QuestIsTakable( pPlayer) ) && (this->hasQuest(pQuest->m_questId)))
				return pQuest;

		return NULL;
	}
						 
}



// ---------------------------------------------------------------------------------

void Creature::prepareQuestMenu( Player *pPlayer, NPCQuestMenu *qMenu )
{
    uint32 quest_id;
    uint32 status;
    Quest *pQuest;

    for( list<uint32>::iterator i = mQuestIds.begin( ); i != mQuestIds.end( ); ++ i )
    {
        quest_id = *i;
        status = pPlayer->getQuestStatus(quest_id);
        pQuest = objmgr.GetQuest(quest_id);

		// Adding uncompleted quests.
		if ( status == QUEST_STATUS_INCOMPLETE )
		{
			qMenu->AddCurrentQuest( pQuest, DIALOG_STATUS_INCOMPLETE );
		}

		// Adding available quests
		if ( ( status == QUEST_STATUS_AVAILABLE ) && ( pQuest->QuestIsTakable(pPlayer) ) )
		{
			qMenu->AddAvailableQuest( pQuest, DIALOG_STATUS_AVAILABLE );
		}
	}

	for( list<uint32>::iterator i = mInvolvedQuestIds.begin( ); i != mInvolvedQuestIds.end( ); ++ i )
    {
        quest_id = *i;
        status = pPlayer->getQuestStatus(quest_id);
        pQuest = objmgr.GetQuest(quest_id);

		// Adding uncompleted quests.
		if ( status == QUEST_STATUS_INCOMPLETE )
		{
			qMenu->AddCurrentQuest( pQuest, DIALOG_STATUS_INCOMPLETE );
		}

		// Adding completed quests
		if ( status == QUEST_STATUS_COMPLETE )
		{
			qMenu->AddCurrentQuest( pQuest, DIALOG_STATUS_REWARD );
		}
	}
}

bool Creature::hasQuest(uint32 quest_id)
{
    for( list<uint32>::iterator i = mQuestIds.begin( ); i != mQuestIds.end( ); ++ i )
    {
        if (*i == quest_id)
            return true;
    }

    return false;
}

bool Creature::hasInvolvedQuest(uint32 quest_id)
{
    for( list<uint32>::iterator i = mInvolvedQuestIds.begin( ); i != mInvolvedQuestIds.end( ); ++ i )
    {
        if (*i == quest_id)
            return true;
    }

    return false;
}

//-----------------------------------------------------------------------------
/// Looting
void Creature::SetEmptyLoot (uint32 loot_sparkles)
{
	item_list.clear();
	m_lootMoney = 0;
	// Killer always sees loot sparkles even if loot is empty
	SetUInt32Value (UNIT_DYNAMIC_FLAGS, loot_sparkles);
}

void Creature::GenerateLoot()
{
    //itemcount = 0;
	//memset (item_list, 0, MAX_CREATURE_ITEMS * sizeof (CreatureItem));

	item_list.clear();

    m_lootMoney = GetLevel() * (rand() % 3 + 4);

	LootTemplateVectorMap::iterator	iter = objmgr.m_lootTemplates.find (GetEntry());
	if (iter == objmgr.m_lootTemplates.end()) {
		Log::getSingleton().outDebug ("LOOTGEN: No loot template for creature %d", GetEntry());
		return;
	}

	LootTemplateVector * pvec = iter->second;
	uint32	itemId, lootCount = 0;
	float	chance;
	MT		randomizer;
	ItemPrototype * itemProto;

	for (uint32 i = 0; i < pvec->size(); i++)
	{
		itemId = (*pvec)[i].ItemId;
		chance = (*pvec)[i].Chance;

		itemProto = objmgr.GetItemPrototype (itemId);
		if (itemProto->Class == 12) {
			// Skip quest items completely! Need to check quest number and
			// make personal quest items list in loot for every group member
			Log::getSingleton().outDebug ("LOOTGEN: Item=%d Chance=%.6f Creature=%d - skipped quest item", itemId, chance, GetEntry());
			continue;
		}

		int count = 1;
				
		if (chance == 0.0f) continue;

		while (chance > 100.0f) {
			count++;
			chance -= 100.0f;
		}

		if (randomizer.randf() < chance / 100.0f) {
			Log::getSingleton().outDebug ("LOOTGEN: Item=%d Chance=%.6f Creature=%d - ADDED To Loot", itemId, chance, GetEntry());
			addItem (itemId, count);
			lootCount++;
		} else {
			//Log::getSingleton().outDebug ("LOOTGEN: Item=%d Chance=%.6f Creature=%d - skip", itemId, chance, GetEntry());
		}
	}

	// Add WORLD DROP (LOOT) to loot table
	GenerateWorldLoot();

	// All players can see Skinnable after loot was emptied or
	// empty loot was opened once by looter
	//
	/*if(this->GetCreatureTemplate()->Type == CREATURE_TYPE_BEAST)
	{
		SetUInt32Value (UNIT_FIELD_FLAGS, (0x4004000));// set skinnable
	}*/

	// Killer always sees loot sparkles even if loot is empty
	// TODO: Show only to killer or group member who has loot rights now
	SetUInt32Value (UNIT_DYNAMIC_FLAGS, 1);

	/*if (lootCount > 0 || m_lootMoney > 0)
	{
		// Loot sparkles? Check player rights here
	 	SetUInt32Value (UNIT_DYNAMIC_FLAGS, 1);
	} else {
		// TODO: Check no loots left on the body, and only after that set skinnable
		SetUInt32Value (UNIT_DYNAMIC_FLAGS, 0);//Not sure yet what's needed to skin the mob
	}*/
}

//-----------------------------------------------------------------------------
/// Creature AI
//-----------------------------------------------------------------------------

// This Creature has just been attacked by someone
// Reaction:  Add this Creature to the list of current attackers
void Creature::AI_AttackReaction (Unit *pAttacker, float damage_dealt)
{
    WPAssert(pAttacker);

	// TODO: Check attacker for threat reduction auras
	// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

	AddHate (pAttacker, damage_dealt);

	// Remember who tagged creature to award XP to him and his group
	// If creature attacked another creature - reset tagger to it. No loot then
	if (GetTagger() == NULL || pAttacker->GetTypeId() == TYPEID_UNIT) {
		WorldPacket	data;
		UpdateData	udata;

		SetTagger (pAttacker);

		// This does not work??? But it should!
		// Code below sends update: DynamicFlags for attacked creature = 0
		// (normal title color) to first attacker and DynamicFlags = UNIT_DYNFLAG_OTHER_TAGGER (4)
		// to all other players, so they see grey title, meaning no loot and XP will 
		// be awarded for this creature
		/*
		for (ObjectSet::iterator itr = GetInRangeSetBegin(); itr != GetInRangeSetEnd(); itr++)
		{
			Player * pl = (Player *)(*itr);

			if ((Unit *)pAttacker != (Unit *)pl)
			{
				SetUInt32Value (UNIT_DYNAMIC_FLAGS, UNIT_DYNFLAG_OTHER_TAGGER);
			} else
			{
				SetUInt32Value (UNIT_DYNAMIC_FLAGS, 0);
			}

			udata.Clear();
			BuildValuesUpdateBlockForPlayer (&udata, pl);
			udata.BuildPacket (&data);
			pl->GetSession()->SendPacket (&data);
		}
		*/
	}
}

//-----------------------------------------------------------------------------
void Creature::AI_Update()
{
	// We don't want to spend CPU thinking in areas without live players
	/*ASSERT (m_mapCell->m_playersHere >= 0);
	if (m_mapCell->m_playersHere == 0) return;*/

	bool	wasInCombat = isInCombat(); // to check later if combat turned off

	// Temporary Code (may stay here forever though) to detect hostile NPCs and
	// players and add aggro to them (attack them)
	uint32 faction = GetFaction();
	if (faction == 11 || faction == 79)
	{
		GuardCheckForViolators();
	}

	// Cycle through hated units - remove hate for those out of range
	//
	TargetMap::iterator nextitr;
    for (TargetMap::iterator itr = m_targets.begin(); itr != m_targets.end(); )
    {
		nextitr = itr;
		nextitr++;

        Unit * pVictim = itr->first;
        WPAssert(pVictim);

		float lengthSq = 0;

        if (! pVictim->isAlive())
		{
			Log::getSingleton().outDebug ("AI-Hate: %X hated %X, but its dead, stopped hate",
				this->GetGUIDLow(), pVictim->GetGUIDLow());
            RemoveHate (pVictim);
			pVictim->RemoveHate (this);
            goto continuehere;
        }

        lengthSq = this->GetDistanceSq(pVictim);

		// must be greater than the max range of spells
        /*if (lengthSq > 30.0f * 30.0f)
		{
            // stop attacking because the target is too far
			Log::getSingleton().outDebug ("AI-Hate: %X hated %X, but its too far, stopped hate",
				this->GetGUIDLow(), pVictim->GetGUIDLow());
            RemoveHate (pVictim);
			pVictim->RemoveHate (this);
			goto continuehere;
        }*/

        /*if (lengthSq < targetDistanceSq)
		{
            closestTarget = pVictim;
            targetDistanceSq = lengthSq;
        }*/
continuehere:
        itr = nextitr;
    }

	// If somehow finished combat
	if ( wasInCombat && ! isInCombat() ) 
	{
		Log::getSingleton().outDebug ("AI: Finished combat, restoring self");
		OnExitCombat();
	}

	Unit *mostHated = GetMostHated();

	if (m_hateDegradeCounter > -1 && GetDistanceSq (mostHated) > 9.0f) {
		m_hateDegradeCounter--;

		if (wasInCombat && m_hateDegradeCounter < 0)
		{
			// FIXME: This counter must be used for every hated creature, not for all
			//
			Log::getSingleton().outDebug ("AI-Hate: %X most hated victim ran away, stopped hate",
				this->GetGUIDLow());
			//ClearHate();
			
			// Remove most hated and start hating next one again
			RemoveHate (mostHated);
			if (isInCombat())
				m_hateDegradeCounter = UNIT_HATE_DEGRADE_COUNTER;
		}
	}

	// Attack if there is most hated target and we are not in panic
	//
	if (mostHated != NULL && ! isFleeing())
    {
		float reach = GetFloatValue(UNIT_FIELD_COMBATREACH);
        float radius = GetFloatValue(UNIT_FIELD_BOUNDINGRADIUS);
        float targetDistance = sqrt (GetDistanceSq (mostHated));

		// If distance is more than can reach by attack - should run closer
		//
		if (!CanReachWithAttack(mostHated) )
        //if (targetDistance > (reach + radius) /*&& m_movementState != AI_STATE_MOVING*/)
        {
            /*float q = (targetDistance - radius)/targetDistance;

            float x = (m_positionX + mostHated->GetPositionX()*q) / (1+q);
            float y = (m_positionY + mostHated->GetPositionY()*q) / (1+q);
            float z = (m_positionZ + mostHated->GetPositionZ()*q) / (1+q);

            AI_MoveTo(x, y, z, true);*/

			//m_movementState = AI_STATE_STOPPED;
			//AI_MoveTo (mostHated, true, radius);//too close!
			
			PreciseTime pt_now = GetPreciseTime();
			if (pt_now - m_lastMoveTo > PTSECONDS(1))
			{
				AI_MoveTo (mostHated, true, (radius + reach) * 0.667f);
				m_lastMoveTo = pt_now;
			}

			//Log::getSingleton().outDebug ("AI: %X hates %X but needs to run closer",
			//	this->GetGUIDLow(), mostHated->GetGUIDLow());
            
			return;
        }

		// Else just start attacking
		//
        else
        {
            if(m_creatureState != AI_STATE_ATTACKING)
            {
                /*
                if(m_creatureState == MOVING)
                {
                    WorldPacket data;
                    BuildUpdateMsgHeader( &data );
                    BuildMovementUpdateBlock( &data );
                    SendMessageToSet( &data, false );
                }*/
				//Log::getSingleton().outDebug ("AI: %X hates %X and starts attacking",
				//	this->GetGUIDLow(), mostHated->GetGUIDLow());

                AI_ChangeState(AI_STATE_ATTACKING);
				
				//if (m_movementState != AI_STATE_MOVING && ! isInFront (mostHated, reach + radius))
				//	LookAt (mostHated);
            }
            if (isAttackReady())
            {
				// If facing wrong direction
				//if (m_movementState != AI_STATE_MOVING && ! isInFront (mostHated, reach + radius))
				//	LookAt (mostHated);

				AttackerStateUpdate (mostHated, 0, false);
                setAttackTimer();
            }
        }
    }
	else if(UnitToFollow != NULL)
	{
		float BoundingRadiusSq = 0.0f;
		BoundingRadiusSq = max(UnitToFollow->GetFloatValue(UNIT_FIELD_BOUNDINGRADIUS) * UnitToFollow->GetFloatValue(UNIT_FIELD_BOUNDINGRADIUS), 5.0f);

		if(GetDistanceSq(UnitToFollow) > BoundingRadiusSq)
		{
			AI_MoveTo(UnitToFollow, true, BoundingRadiusSq);
		}
	}
}

//-----------------------------------------------------------------------------
void Creature::AI_SendMoveToPacket(float x, float y, float z, uint32 time, bool run)
{
	if (isStunned()) return;

	WorldPacket data;
	static uint32 move_serial = 0x08000001;

    data.Initialize( SMSG_MONSTER_MOVE );
    data << GetGUID();
    
	//data << GetPositionX() << GetPositionY() << GetPositionZ() << GetOrientation();
	data << GetPositionX() << GetPositionY() << GetPositionZ();
	data << move_serial++;

    data << uint8(0);
	data << uint32(run ? 0x00000100 : 0x00000000);
    data << time;
	data << uint32(1);
   	data << x << y << z;
	
    WPAssert( data.size() == 49 );
    SendMessageToSet( &data, false );
}

//-----------------------------------------------------------------------------
void Creature::AI_MoveTo(float x, float y, float z, bool run, float stopDistance)
{
	if (isStunned()) return;

	float dx = x - m_positionX;
    float dy = y - m_positionY;
    float dz = z - m_positionZ;

    float distance = sqrt((dx*dx) + (dy*dy) + (dz*dz));

	//if (distance < 0.1) // || distance <= stopDistance) 
    //    return;

    //if (m_creatureState != AI_STATE_MOVING)
    //{

	//if(!run) m_moveSpeed = UNIT_NORMAL_WALK_SPEED * m_speedMod * 0.001f;
	//else	 m_moveSpeed = UNIT_NORMAL_RUN_SPEED * m_speedMod * 0.001f;
	//uint32 moveTime = (uint32) ((distance - stopDistance) / m_moveSpeed);

	if(!run) m_moveSpeed = UNIT_NORMAL_WALK_SPEED * m_speedMod;
	else	 m_moveSpeed = UNIT_NORMAL_RUN_SPEED * m_speedMod;
	uint32 moveTime = (uint32) ((distance - stopDistance) * 1000 / m_moveSpeed);

	if (moveTime < 1) moveTime = 1;

	m_creatureState = AI_STATE_MOVING;

	// Calculate coordinates to stop at, to have stopDistance units left to target
	//
	/*float q = 1.0f - (stopDistance / distance);

	m_destinationX = m_positionX + dx * q;
	m_destinationY = m_positionY + dy * q;
	m_destinationZ = m_positionZ + dz * q;
	*/
	m_destinationX = x;
	m_destinationY = y;
	m_destinationZ = z;

	//Log::getSingleton().outDebug ("AI_MoveTo: from (%.1f,%.1f) to (%.1f,%.1f), move time %d ticks, "
	//	"move speed %.2f", m_positionX, m_positionY, m_destinationX, m_destinationY,
	//	moveTime, m_moveSpeed * 1000.0f);

	m_timeToMove = moveTime;
	//m_moveTimer = moveTime / 2;
	m_moveTimer = UNIT_MOVEMENT_INTERPOLATE_INTERVAL; // update every 300 ms

	AI_SendMoveToPacket (m_destinationX, m_destinationY, m_destinationZ, moveTime, run);
}

//-----------------------------------------------------------------------------
void Creature::AI_MoveTo (Unit *npc, bool run, float stopDistance)
{
	AI_MoveTo (npc->GetPositionX(), npc->GetPositionY(), npc->GetPositionZ(), run, stopDistance);
}

//-----------------------------------------------------------------------------
void Creature::AI_Follow (Unit *target)
{
	UnitToFollow = target;
}

//-----------------------------------------------------------------------------
void Creature::AI_StopFollow ()
{
	UnitToFollow = NULL;
}

//-----------------------------------------------------------------------------
bool Creature::addWaypoint(float x, float y, float z, uint8 wait1, uint8 wait2)
{
	if(m_waypoints.size() + 1 >= MAX_CREATURE_WAYPOINTS) {
		sChatHandler.m_session->SystemMessage ("Can't add waypoint, current mob is maxed out %d points",
			MAX_CREATURE_WAYPOINTS);
        return false;
	}

	uint32	sz = m_waypoints.size();
	if (sz + 1 >= m_waypoints.capacity()) m_waypoints.reserve (sz * 3 / 2);
	m_waypoints.resize (sz + 1);

    m_waypoints[sz].x = x;
    m_waypoints[sz].y = y;
    m_waypoints[sz].z = z;
	m_waypoints[sz].Wait1 = wait1;
	m_waypoints[sz].Wait1 = wait2;

    return true;
}

//-----------------------------------------------------------------------------
bool Creature::insertWaypoint (float x, float y, float z, int pos, uint8 wait1, uint8 wait2)
{
	if(m_waypoints.size() + 1 >= MAX_CREATURE_WAYPOINTS) {
		sChatHandler.m_session->SystemMessage ("Can't insert waypoint, current mob is maxed out %d points",
			MAX_CREATURE_WAYPOINTS);
		return false;
	}

	uint32	sz = m_waypoints.size();
	if (sz + 1 >= m_waypoints.capacity()) m_waypoints.reserve (sz * 3 / 2);
	m_waypoints.resize (sz + 1);

	for (int i = m_waypoints.size(); i > pos; i--)
	{
		m_waypoints[i] = m_waypoints[i-1];
	}

	m_waypoints[pos].x = x;
	m_waypoints[pos].y = y;
	m_waypoints[pos].z = z;
	m_waypoints[sz].Wait1 = wait1;
	m_waypoints[sz].Wait1 = wait2;

	//m_session->SystemMessage ("Waypoint wait times changed to %d..%d", wait1, wait2);
	return true;
}

//-----------------------------------------------------------------------------
void Creature::SaveToDB()
{
	stringstream ss;
	ss << "DELETE FROM creatures WHERE id=" << GetGUIDLow();
	sDatabase.Execute(ss.str().c_str());

	char ss1[1024];
	sprintf ((char *)ss1,
		"INSERT INTO creatures (id, mapId, zoneId, name_id, positionX, positionY, "\
		"positionZ, orientation, spawnX, spawnY, spawnZ, spawnOrient, moveType, "\
		"running, spawnTime1, spawnTime2, spawnDist, currentWaypoint, data) VALUES "\
		"(%lu, %lu, %lu, %lu, %.1f, %.1f, %.1f, %.1f, %.1f, %.1f, %.1f, %.1f, "\
		"%d, %d, %d, %d, %.1f, %d, \"", GetGUIDLow(), GetMapId(), GetZoneId(),
		GetUInt32Value(OBJECT_FIELD_ENTRY), m_positionX, m_positionY, m_positionZ, m_orientation,
		respawn_cord[0], respawn_cord[1], respawn_cord[2], respawn_angle, (uint32)m_movementType,
		(uint32)m_moveRun, m_spawnTime[0], m_spawnTime[1], m_spawnDist, m_currentWaypoint);

	ss.rdbuf()->str("");
	ss << ss1;

	// add Data part to query
	for (uint32 index = 0; index < m_valuesCount; index++)
		ss << GetUInt32Value(index) << " ";

	// finish building and execute query
	ss << "\")";

	sDatabase.Execute( ss.str( ).c_str( ) );

	m_creatureTemplate = objmgr.GetCreatureTemplate(GetEntry());
}

//-----------------------------------------------------------------------------
// TODO: use full guids
void Creature::LoadFromDB (uint32 guid, WaypointVectorMap *precache)
{
	stringstream ss;
    ss << "SELECT `id`, positionX, positionY, positionZ, orientation, "\
		"zoneId, mapId, `data`, name_id, moveType, running, spawnTime1, spawnTime2, "\
		"spawnDist, currentWaypoint, spawnX, spawnY, spawnZ, spawnOrient "\
		"FROM creatures WHERE id=" << guid;

    QueryResult *result = sDatabase.Query( ss.str().c_str() );
    ASSERT (result != NULL);

    Field *fields = result->Fetch();

	CreatureTemplate *ct = objmgr.GetCreatureTemplate (fields[8].GetUInt32());

    //Create (fields[8].GetUInt32(), ct->Name.c_str(), fields[6].GetUInt32(),
    //    fields[1].GetFloat(), fields[2].GetFloat(), fields[3].GetFloat(), fields[4].GetFloat());
	Create (objmgr.GenerateLowGuid (HIGHGUID_UNIT),
		ct->Name.c_str(), fields[6].GetUInt32(), fields[1].GetFloat(),
		fields[2].GetFloat(), fields[3].GetFloat(), fields[4].GetFloat());

    m_zoneId = fields[5].GetUInt32();
	LoadValues(fields[7].GetString());
	
	m_movementType = (Creature::MovementType)fields[9].GetUInt8();
    m_moveRun = fields[10].GetBool();

	m_spawnTime[0] = fields[11].GetUInt32();
	m_spawnTime[1] = fields[12].GetUInt32();
	m_spawnDist = fields[13].GetFloat();
	m_currentWaypoint = fields[14].GetUInt32();

	m_destinationX = respawn_cord[0] = fields[15].GetFloat();
	m_destinationY = respawn_cord[1] = fields[16].GetFloat();
	m_destinationZ = respawn_cord[2] = fields[17].GetFloat();
	m_orientation = respawn_angle = fields[18].GetFloat();
	SetPosition (m_destinationX, m_destinationY, m_destinationZ, m_orientation);

	m_creatureTemplate = objmgr.GetCreatureTemplate (GetEntry());

    delete result;

    if ( HasFlag( UNIT_NPC_FLAGS, UNIT_NPC_FLAG_VENDOR ) )
        _LoadGoods();

    if ( HasFlag( UNIT_NPC_FLAGS, UNIT_NPC_FLAG_QUESTGIVER ) )
		_LoadQuests();

	if(GetUInt64Value(UNIT_FIELD_SUMMONEDBY) == 0)
	{
		_LoadMovement (precache);
		_ResetBaseStats();
	}

	m_minDamage = GetFloatValue (UNIT_FIELD_MINDAMAGE);
	m_maxDamage = GetFloatValue (UNIT_FIELD_MAXDAMAGE);

	uint32 f = GetFaction();
	if (f == 11)
		_SetRace (RACE_HUMAN);
	if (f == 79)
		_SetRace (RACE_NIGHT_ELF);
	
	// Equip NPC
	EquipNPC();
	////////////	
	
	// Set Flags
	SetUInt32Value(UNIT_FIELD_FLAGS, m_creatureTemplate->Flags1);

}

//-----------------------------------------------------------------------------
void Creature::_LoadGoods()
{
	/*
    // remove items from vendor
    itemcount = 0;

    // load his goods
    stringstream query;
    query << "SELECT * FROM vendors WHERE vendorGuid=" << GetGUIDLow();

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
	*/
}

//-----------------------------------------------------------------------------
void Creature::_LoadQuests()
{
    // clean quests

    mQuestIds.clear();
	mInvolvedQuestIds.clear();

    stringstream query;
    query << "SELECT * FROM creaturequestrelation WHERE creatureId=" << GetUInt32Value(OBJECT_FIELD_ENTRY) << " ORDER BY questId";

    QueryResult *result = sDatabase.Query( query.str().c_str() );
    if(result)
    {
        do
        {
            Field *fields = result->Fetch();
            addQuest(fields[1].GetUInt32());
        }
        while( result->NextRow() );

        delete result;
    }

	// -------------------- Involved quests

    stringstream query1;					    
	query1 << "SELECT * FROM creatureinvolvedrelation WHERE creatureId=" << GetUInt32Value (OBJECT_FIELD_ENTRY) << " ORDER BY questId";

    result = sDatabase.Query( query1.str().c_str() );
    if(result)
    {
        do
        {
            Field *fields = result->Fetch();
			uint32 inv = fields[1].GetUInt32();

			Quest *pQuest = objmgr.GetQuest( inv );
			if (!pQuest) continue;

            addInvolvedQuest(inv);
        }
        while( result->NextRow() );

        delete result;
    }
}

//-----------------------------------------------------------------------------
void Creature::_LoadMovement (WaypointVectorMap *precache)
{
	// clean waypoint list
	//m_nWaypoints = 0;
	m_waypoints.clear();
	//m_waypoints.reserve (OPTIMAL_CREATURE_WAYPOINTS_RESERVE);

	if (precache != NULL) 
	{
		// Precached available, search there or give up
		//
		WaypointVectorMap::iterator	wpvi = precache->find (GetGUIDLow());

		if (wpvi != precache->end()) {
			WaypointVector * way = wpvi->second;
			for (uint32 i = 0; i < way->size(); i++) {
				m_waypoints.push_back ((*way)[i]);
			}
		}
	} else 
	{
		// No precached waypoints available, going to request database
		//
		stringstream query;
		query << "SELECT X,Y,Z,WaitTime1,WaitTime2 FROM creatures_mov WHERE creatureId=" << GetGUIDLow();

		QueryResult *result = sDatabase.Query( query.str().c_str() );
		if (result) {
			do {
				Field *fields = result->Fetch();

				float	X = fields[0].GetFloat();
				float	Y = fields[1].GetFloat();
				float	Z = fields[2].GetFloat();

				uint8	Wait1 = fields[3].GetUInt8();
				uint8	Wait2 = fields[4].GetUInt8();

				addWaypoint (X, Y, Z, Wait1, Wait2);

			}
			while( result->NextRow() );
			delete result;
		}
	}

	if (m_currentWaypoint >= m_waypoints.size())
		m_currentWaypoint = m_waypoints.size() - 1;
}

//-----------------------------------------------------------------------------
void Creature::DeleteFromDB()
{
    char sql[256];

    sprintf(sql, "DELETE FROM creatures WHERE id=%u", GetGUIDLow());
    sDatabase.Execute(sql);

	sprintf(sql, "DELETE FROM creatures_mov WHERE creatureId=%u", GetGUIDLow());
	sDatabase.Execute(sql);

	//sprintf(sql, "DELETE FROM vendors WHERE vendorGuid=%u", GetGUIDLow());
    //sDatabase.Execute(sql);
    //sprintf(sql, "DELETE FROM trainers WHERE trainerGuid=%u", GetGUIDLow());
    //sDatabase.Execute(sql);
    //sprintf(sql, "DELETE FROM creaturequestrelation WHERE creatureId=%u", GetGUIDLow());
    //sDatabase.Execute(sql);
}

//-----------------------------------------------------------------------------
void Creature::LookAt (Unit *target)
{
	float px = GetPositionX();
	float py = GetPositionY();
	float angle = GetEasyAngle (GetAngle (target->GetPositionX(), target->GetPositionY(),
		px, py) + 90.0f) * 3.14159f / 180.0f;
	WorldPacket pkt;

	if (fabs (m_orientation - angle) > 0.1) {
		m_orientation = angle;
		BuildTeleportAckMsg (&pkt, GetPositionX(), GetPositionY(), GetPositionZ(), angle);
		SendMessageToSet (&pkt, true);
	}
}

//-----------------------------------------------------------------------------
bool Creature::RelatedByFirstName (Creature *cr)
{
	CreatureTemplate	* ctemp;
	char	name1[256],
			name2[256];

	ctemp = GetCreatureTemplate();
	if (ctemp == NULL) return 0;

	strcpy (name1, ctemp->Name.c_str());
	char	*p = strchr (name1, ' ');
	if (p != NULL) *p = '\x00';
	
	ctemp = cr->GetCreatureTemplate();
	if (ctemp == NULL) return 0;

	strcpy (name2, ctemp->Name.c_str());
	p = strchr (name2, ' ');
	if (p != NULL) *p = '\x00';

	return (strcmpi (name1, name2) == 0);
}

//-----------------------------------------------------------------------------
bool Creature::SearchForHelpfulFamily (float senseRadius)
{
	if (m_mapCell == NULL) return false;
	if (isDead()) return false;

	// Check for brothers around to ask for help
	//
	ObjectSet::iterator itr;
	Creature * cr = NULL;
	float helpRadiusSq = senseRadius * senseRadius;
	bool gotHelp = false;

	for (itr = m_mapCell->Begin(); itr != m_mapCell->End(); ++itr)
	{
		ASSERT(*itr);

		if ((*itr)->GetTypeId() == TYPEID_UNIT)
		{
			cr = (Creature *)(*itr);
			
			// We don't want to share with self
			if (cr == this) continue;

			// Check if helpful family member can hear me
			if (GetDistance2dSq (cr) > helpRadiusSq) continue;

			// Check if first word of creature name is like my
			if (RelatedByFirstName (cr) == false) continue;

			// Family member must have my faction, to be useful
			if (GetFaction() != cr->GetFaction()) continue;

			// We won't worry our combating family. Only free members will get share of hate.
			if (cr->isInCombat()) continue;

			// And finally share hate
			//Log::getSingleton().outDebug ("AI: Sharing hate with helpful family member %X",
			//	cr->GetGUIDLow());
			
			ShareHateWith (cr);
			cr->m_creatureState = AI_STATE_STOPPED;
			gotHelp = true;
		}
	}

	if (gotHelp) {
		//Log::getSingleton().outDebug ("AI: Phew looks like I got some helpful friends");
	}

	return gotHelp;
}

//-----------------------------------------------------------------------------
void Creature::GuardCheckForViolators()
{
	if (m_mapCell == NULL) return;

	ObjectSet::iterator itr;
	bool	gotHelp = false;
	uint8	myLevel = GetLevel();

	//for (itr = GetInRangeSetBegin(); itr != GetInRangeSetEnd(); itr++)
	for (itr = m_mapCell->Begin(); itr != m_mapCell->End(); itr++)
	{
		ASSERT(*itr);
		if ((*itr)->GetTypeId() == TYPEID_UNIT)
			//if (cr != NULL)
		{
			Creature * cr = (Creature *)(*itr);

			// ignore self
			if ((Object *)this == (Object *)cr) continue;

			// ignore dead
			if (cr->isDead()) continue;

			//uint8	mobLevel = cr->GetLevel();
			float	aggroRadius = 20.0f;
			float	distSq = GetDistanceSq (cr);

			// Check if something is nearby
			if (distSq > aggroRadius * aggroRadius) continue;

			// We don't care if we or thing in combat. We hate everyone :)
			// But let's wait combat end to hate next one
			if (this->isInCombat()) continue;

			// Check faction templates if creature is able to attack me
			// Even some hostiles
			//if (! CanFightMe (cr)) continue;
			if (! isHostileToMe (cr)) continue;

			// And finally add hate
			/*Log::getSingleton().outDebug ("AI: Thing %X touched aggro radius of guard %X",
				cr->GetGUIDLow(), GetGUIDLow());*/

			AddHate ((Unit *)cr, 1.0f);
		}
	}
}

//-----------------------------------------------------------------------------
void Creature::OnExitCombat()
{
	Unit::OnExitCombat();

	if (! isDead())
	{
		// Move to respawn point
		AI_MoveTo (respawn_cord[0], respawn_cord[1], respawn_cord[2], true, 0);
	}
}

//-----------------------------------------------------------------------------
void Creature::GenerateWorldLoot()
{

	for (WorldLootTemplateVectorMap::iterator iter = objmgr.m_WorldLootTemplates.begin(); iter != objmgr.m_WorldLootTemplates.end(); ++iter)
	{
	WorldLootTemplateVector * pvec = iter->second;

	uint32	item_id, elite, monster_level, lootCount = 0;
	float	chance;
	MT		randomizer;
	ItemPrototype * itemProto;

	WorldLootTemplate worldloot;
	
    for (uint32 i = 0; i < pvec->size(); i++)
	{
		item_id =		(*pvec)[i].item_id;
		chance =		(*pvec)[i].chance;
		elite =			(*pvec)[i].elite;
		monster_level = (*pvec)[i].monster_level;

		// SKIP QUEST ITEMS
		itemProto = objmgr.GetItemPrototype (item_id);
		if (itemProto->Class == 12) {
			Log::getSingleton().outDebug ("WORLDLOOT: SKIP QUEST ITEM Item=%d Chance=%.6f Creature=%d", item_id, chance, GetEntry());
			continue;
		}
		///////////////////

		if (monster_level <= GetLevel()) {
			// Checking for ELITE type, 
			// checking if Level difference between Creature and required Level for WL is less than 10 Levela
			if ((GetLevel() - monster_level) < 5 && GetElite() == elite) {
			
				int count = 1;
					
				if (chance == 0.0f) continue;

				while (chance > 100.0f) {
					count++;
					chance -= 100.0f;
				}

				if (randomizer.randf() < chance / 100.0f) {
					Log::getSingleton().outDebug ("WORLDLOOT: ADD Item=%d ReqLevel=%d Chance=%.6f CrID=%d Elite=%d", item_id, monster_level, chance, GetEntry(), elite);
					addItem (item_id, count);
					lootCount++;
				} else {
					//Log::getSingleton().outDebug ("LOOTGEN: Item=%d Chance=%.6f Creature=%d - skip", itemId, chance, GetEntry());
				}
			
			}
		}
	}
	}
}
// -- EQUIP NPC ----------------------------------------
void Creature::EquipNPC()
{
	if (m_creatureTemplate != NULL) {
		for (uint8 i = 0; i < 3; i++) {
		if (m_creatureTemplate->EquipModel[i]) VirtualEquip (i, m_creatureTemplate->EquipSlot[i], m_creatureTemplate->EquipModel[i], m_creatureTemplate->EquipData[i]);
		}
	}
}
//--- END ---