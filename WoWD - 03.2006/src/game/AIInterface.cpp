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
#include "AIInterface.h"
#include "Creature.h"
#include "Log.h"
#include "ObjectMgr.h"
#include "Object.h"
#include "Unit.h"
#include "WorldPacket.h"
#include "UpdateData.h"
#include "Affect.h"
#include "../script/LuaEngine.h"

AIInterface::AIInterface()
{
	m_canMove = true;
	m_destinationX = m_destinationY = m_destinationZ = 0;
	UnitToFollow = NULL;
	FollowDistance = 0.0f;
	m_timeToMove = 0;
	m_timeMoved = 0;
	m_moveTimer = 0;
	m_nWaypoints = 0;
    m_WayPointsShowing = false;
    m_WayPointsShowBackwards = false;
	m_currentWaypoint = 0;
	m_moveBackward = false;
	m_moveRandom = false;
	m_moveRun = false;
    m_moveFly = false;
	m_creatureState = STOPPED;
	m_canCallForHelp = false;
	m_hasCalledForHelp = false;
	m_fleeTimer = 0;
	m_canFlee = false;
	m_hasFleed = false;
	m_canRangedAttack = false;
	m_AIState = STATE_IDLE;

	m_updateAssist = false;
	m_updateTargets = false;
	m_updateAssistTimer = 1;
	m_updateTargetsTimer = TARGET_UPDATE_INTERVAL;

	m_hasOnEnterCombatSpells = m_hasOnLeaveCombatSpells = m_hasOnDamageTakenSpells = m_hasOnTargetCastSpellSpells = m_hasOnTargetParryedSpells = m_hasOnTargetDodgedSpells = m_hasOnTargetBlockedSpells =
		m_hasOnTargetCritHitSpells = m_hasOnTargetDiedSpells = m_hasOnUnitParryedSpells = m_hasOnUnitDodgedSpells = m_hasOnUnitBlockedSpells = m_hasOnUnitCritHitSpells = m_hasOnUnitDiedSpells =
		m_hasOnAssistTargetDiedSpells = m_hasOnFollowOwnerSpells = m_hasCooldownOnEnterCombatSpells = m_hasCooldownOnLeaveCombatSpells = m_hasCooldownOnDamageTakenSpells = m_hasCooldownOnTargetCastSpellSpells = m_hasCooldownOnTargetParryedSpells =
		m_hasCooldownOnTargetDodgedSpells = m_hasCooldownOnTargetBlockedSpells = m_hasCooldownOnTargetCritHitSpells = m_hasCooldownOnTargetDiedSpells = m_hasCooldownOnUnitParryedSpells = m_hasCooldownOnUnitDodgedSpells =
		m_hasCooldownOnUnitBlockedSpells = m_hasCooldownOnUnitCritHitSpells = m_hasCooldownOnUnitDiedSpells = m_hasCooldownOnAssistTargetDiedSpells = m_hasCooldownOnFollowOwnerSpells = false;


	m_nextSpell = NULL;
	m_nextTarget = NULL;
}

void AIInterface::Init(Unit *un, AIType at, MovementType mt, LuaEngine *engine)
{
	ASSERT(at != AITYPE_PET);

	m_AIType = at;
	m_MovementType = mt;

	m_AIState = STATE_IDLE;
	m_MovementState = MOVEMENTSTATE_STOP;

	m_Unit = un;
	m_engine = engine;
	
	m_moveSpeed = m_Unit->m_runSpeed*0.001f;
}

void AIInterface::Init(Unit *un, AIType at, MovementType mt, Unit *owner, LuaEngine *engine)
{
	ASSERT(at == AITYPE_PET);

	m_AIType = at;
	m_MovementType = mt;

	m_AIState = STATE_IDLE;
	m_MovementState = MOVEMENTSTATE_STOP;

	m_Unit = un;
	m_PetOwner = owner;
	m_engine = engine;

	m_moveSpeed = m_Unit->m_runSpeed*0.001f;
}

void AIInterface::HandleEvent(uint32 event, Unit* pUnit, uint32 misc1)
{
	if(!pUnit || m_AIState == STATE_EVADE)
	{
		return;
	}

	switch(event)
	{
	case EVENT_ENTERCOMBAT:
		{
			m_AIState = STATE_ATTACKING;
			m_nextSpell = getSpellByEvent(event);
			m_nextTarget = FindTargetForSpell(m_nextSpell);
		}break;
	case EVENT_LEAVECOMBAT:
		{
            if(m_AIType == AITYPE_PET)
            {
                m_AIState = STATE_EVADE;
                if(!m_PetOwner)
                {
                    objmgr.RemoveObject(((Creature *)pUnit));
                    ((Creature *)pUnit)->RemoveFromWorld();
                    return;
                }
                UnitToFollow = m_PetOwner;
                MoveTo(((Player*)m_PetOwner)->GetPositionX(),((Player*)m_PetOwner)->GetPositionY(),((Player*)m_PetOwner)->GetPositionZ(),false);
                FollowDistance = 4.0f;
				m_creatureState = MOVING;
            }
            else
            {                
                m_AIState = STATE_EVADE;
                UnitToFollow = NULL;
                FollowDistance = 0.0f;
                if(m_nWaypoints > 0)
                {
                    WayPoint* wp = getWayPoint(m_currentWaypoint);
                    if(wp)
                    {
                        MoveTo(wp->x,wp->y, wp->z,0);
                    }
                    else
                    {
                        MoveTo(((Creature*)m_Unit)->respawn_cord[0],((Creature*)m_Unit)->respawn_cord[1],((Creature*)m_Unit)->respawn_cord[2],0);
                    }
                }
                else
                {
                    MoveTo(((Creature*)m_Unit)->respawn_cord[0],((Creature*)m_Unit)->respawn_cord[1],((Creature*)m_Unit)->respawn_cord[2],0);
                }
                m_Unit->SetUInt32Value(UNIT_FIELD_HEALTH,m_Unit->GetUInt32Value(UNIT_FIELD_MAXHEALTH));
                m_Unit->SetUInt32Value(UNIT_FIELD_BASE_HEALTH,m_Unit->GetUInt32Value(UNIT_FIELD_MAXHEALTH));
            }

            m_aiTargets.clear();            
			m_fleeTimer = 0;
			m_hasFleed = false;
			m_hasCalledForHelp = false;
			m_nextSpell = NULL;
			m_nextTarget = NULL;
			resetSpellCounter();
			/*SpellEntry* spell = getSpellEntry(2054);
			Affect* aff = new Affect(spell, 6000, m_Unit->GetGUID());
			aff->SetHealPerTick(uint16(m_Unit->GetUInt32Value(UNIT_FIELD_MAXHEALTH)/4), 2000);
			m_Unit->AddAffect(aff);*/
		}break;
	case EVENT_DAMAGETAKEN:
		{
			if(!modThreatByGUID(pUnit->GetGUID(), misc1))
			{
				AI_Target target;
				target.target = pUnit;
				target.threat = misc1;
				m_aiTargets.push_back(target);
			}
			m_nextSpell = getSpellByEvent(event);
			m_nextTarget = FindTargetForSpell(m_nextSpell);
		}break;
	case EVENT_TARGETCASTSPELL:
		{
			m_nextSpell = getSpellByEvent(event);
			m_nextTarget = FindTargetForSpell(m_nextSpell);
		}break;
	case EVENT_TARGETPARRYED:
		{
			m_nextSpell = getSpellByEvent(event);
			m_nextTarget = FindTargetForSpell(m_nextSpell);
		}break;
	case EVENT_TARGETDODGED:
		{
			m_nextSpell = getSpellByEvent(event);
			m_nextTarget = FindTargetForSpell(m_nextSpell);
		}break;
	case EVENT_TARGETBLOCKED:
		{
			m_nextSpell = getSpellByEvent(event);
			m_nextTarget = FindTargetForSpell(m_nextSpell);
		}break;
	case EVENT_TARGETCRITHIT:
		{
			m_nextSpell = getSpellByEvent(event);
			m_nextTarget = FindTargetForSpell(m_nextSpell);
		}break;
	case EVENT_TARGETDIED:
		{
			m_nextSpell = getSpellByEvent(event);
			m_nextTarget = FindTargetForSpell(m_nextSpell);
		}break;
	case EVENT_UNITPARRYED:
		{
			m_nextSpell = getSpellByEvent(event);
			m_nextTarget = FindTargetForSpell(m_nextSpell);
		}break;
	case EVENT_UNITDODGED:
		{
			m_nextSpell = getSpellByEvent(event);
			m_nextTarget = FindTargetForSpell(m_nextSpell);
		}break;
	case EVENT_UNITBLOCKED:
		{
			m_nextSpell = getSpellByEvent(event);
			m_nextTarget = FindTargetForSpell(m_nextSpell);
		}break;
	case EVENT_UNITCRITHIT:
		{
			m_nextSpell = getSpellByEvent(event);
			m_nextTarget = FindTargetForSpell(m_nextSpell);
		}break;
	case EVENT_UNITDIED:
		{
			m_AIState = STATE_IDLE;

			m_aiTargets.clear();
            UnitToFollow = NULL;
            FollowDistance = 0.0f;
			m_fleeTimer = 0;
			m_hasFleed = false;
			m_hasCalledForHelp = false;
			m_nextSpell = NULL;
			m_nextTarget = NULL;
			resetSpellCounter();
		}break;
	case EVENT_ASSISTTARGETDIED:
		{
			m_nextSpell = getSpellByEvent(event);
			m_nextTarget = FindTargetForSpell(m_nextSpell);
		}break;
    case EVENT_FOLLOWOWNER:
        {
            m_AIState = STATE_FOLLOWING;
            if(!m_PetOwner)
            {
                objmgr.RemoveObject(((Creature *)pUnit));
                ((Creature *)pUnit)->RemoveFromWorld();
                return;
            }
            UnitToFollow = m_PetOwner;
            MoveTo(((Player*)m_PetOwner)->GetPositionX(),((Player*)m_PetOwner)->GetPositionY(),((Player*)m_PetOwner)->GetPositionZ(),false);
            FollowDistance = 4.0f;
			m_creatureState = MOVING;
			m_nextSpell = getSpellByEvent(event);
			m_nextTarget = FindTargetForSpell(m_nextSpell);

            m_aiTargets.clear();            
            m_fleeTimer = 0;
            m_hasFleed = false;
            m_hasCalledForHelp = false;
            m_nextSpell = NULL;
            m_nextTarget = NULL;
            resetSpellCounter();
        }break;
	case EVENT_FEAR:
		{             
            m_AIState = STATE_FEAR;
            UnitToFollow = NULL;
            FollowDistance = 0.0f;

            m_aiTargets.clear();            
			m_fleeTimer = 0;
			m_hasFleed = false;
			m_hasCalledForHelp = false;
			m_nextSpell = NULL;
			m_nextTarget = NULL;
			resetSpellCounter();
        }break;
	default:
		{
		}break;
	}
}

void AIInterface::Update(uint32 p_time)
{
	_UpdateTimer(p_time);
	_UpdateTargets();
	if(m_Unit->isAlive() && m_AIState != STATE_IDLE 
        && m_AIState != STATE_FOLLOWING && m_AIState != STATE_FEAR)//add here passive check
		_UpdateCombat(p_time);
	_UpdateMovement(p_time);

	if(m_AIState == STATE_EVADE)
	{
		if(m_creatureState != MOVING)
        {
            if(m_AIType == AITYPE_PET)
                MoveTo(m_PetOwner->GetPositionX(),m_PetOwner->GetPositionY(),m_PetOwner->GetPositionZ(),m_PetOwner->GetOrientation());
            else
                MoveTo(((Creature*)m_Unit)->respawn_cord[0],((Creature*)m_Unit)->respawn_cord[1],((Creature*)m_Unit)->respawn_cord[2],false);
        }
        else
			if(_CalcDistanceFromHome() < 1.0f)
				m_AIState = STATE_IDLE;
	}

    if(m_AIState == STATE_FOLLOWING) // adding check of player movement here will be good
    {
        if(_CalcDistanceFromHome() < FollowDistance)
        {
            m_AIState = STATE_IDLE;
			//SendStopPacket();
			float or = m_PetOwner->GetOrientation();
            m_moveRun = false;
            MoveTo(m_PetOwner->GetPositionX()+(3*(cos((M_PI/2)+or))),m_PetOwner->GetPositionY()+(3*(sin((M_PI/2)+or))),m_PetOwner->GetPositionZ(),or);
        }
    }
}

void AIInterface::_UpdateTimer(uint32 p_time)
{
	if(m_updateAssistTimer > p_time)
	{
		m_updateAssistTimer -= p_time;
	}else
	{
		m_updateAssist = true;
		m_updateAssistTimer = TARGET_UPDATE_INTERVAL * 2 - m_updateAssistTimer - p_time;
	}

	if(m_updateTargetsTimer > p_time)
	{
		m_updateTargetsTimer -= p_time;
	}else
	{
		m_updateTargets = true;
		m_updateTargetsTimer = TARGET_UPDATE_INTERVAL * 2 - m_updateTargetsTimer - p_time;
	}

	_UpdateCooldownTimers(p_time);
}

void AIInterface::_UpdateCooldownTimers(uint32 p_time)
{
	std::list<AI_Spell*>::iterator i;
	bool changed;
	if(m_hasCooldownOnEnterCombatSpells)
	{
		changed = false;
		for(i = m_OnEnterCombatSpells.begin();i != m_OnEnterCombatSpells.end(); i++)
		{
			if((*i)->spellCooldownTimer > p_time)
			{
				changed = true;
				(*i)->spellCooldownTimer -= p_time;
			}else
			{
				(*i)->spellCooldownTimer = 0;
			}
		}
		m_hasCooldownOnEnterCombatSpells = changed;
	}
	if(m_hasCooldownOnLeaveCombatSpells)
	{
		changed = false;
		for(i = m_OnLeaveCombatSpells.begin();i != m_OnLeaveCombatSpells.end(); i++)
		{
			if((*i)->spellCooldownTimer > p_time)
			{
				changed = true;
				(*i)->spellCooldownTimer -= p_time;
			}else
			{
				(*i)->spellCooldownTimer = 0;
			}
		}
		m_hasCooldownOnLeaveCombatSpells = changed;
	}
	if(m_hasCooldownOnDamageTakenSpells)
	{
		changed = false;
		for(i = m_OnDamageTakenSpells.begin();i != m_OnDamageTakenSpells.end(); i++)
		{
			if((*i)->spellCooldownTimer > p_time)
			{
				changed = true;
				(*i)->spellCooldownTimer -= p_time;
			}else
			{
				(*i)->spellCooldownTimer = 0;
			}
		}
		m_hasCooldownOnDamageTakenSpells = changed;
	}
	if(m_hasCooldownOnTargetCastSpellSpells)
	{
		changed = false;
		for(i = m_OnTargetCastSpellSpells.begin();i != m_OnTargetCastSpellSpells.end(); i++)
		{
			if((*i)->spellCooldownTimer > p_time)
			{
				changed = true;
				(*i)->spellCooldownTimer -= p_time;
			}else
			{
				(*i)->spellCooldownTimer = 0;
			}
		}
		m_hasCooldownOnTargetCastSpellSpells = changed;
	}
	if(m_hasCooldownOnTargetParryedSpells)
	{
		changed = false;
		for(i = m_OnTargetParryedSpells.begin();i != m_OnTargetParryedSpells.end(); i++)
		{
			if((*i)->spellCooldownTimer > p_time)
			{
				changed = true;
				(*i)->spellCooldownTimer -= p_time;
			}else
			{
				(*i)->spellCooldownTimer = 0;
			}
		}
		m_hasCooldownOnTargetParryedSpells = changed;
	}
	if(m_hasCooldownOnTargetDodgedSpells)
	{
		changed = false;
		for(i = m_OnTargetDodgedSpells.begin();i != m_OnTargetDodgedSpells.end(); i++)
		{
			if((*i)->spellCooldownTimer > p_time)
			{
				changed = true;
				(*i)->spellCooldownTimer -= p_time;
			}else
			{
				(*i)->spellCooldownTimer = 0;
			}
		}
		m_hasCooldownOnTargetDodgedSpells = changed;
	}
	if(m_hasCooldownOnTargetBlockedSpells)
	{
		changed = false;
		for(i = m_OnTargetBlockedSpells.begin();i != m_OnTargetBlockedSpells.end(); i++)
		{
			if((*i)->spellCooldownTimer > p_time)
			{
				changed = true;
				(*i)->spellCooldownTimer -= p_time;
			}else
			{
				(*i)->spellCooldownTimer = 0;
			}
		}
		m_hasCooldownOnTargetBlockedSpells = changed;
	}
	if(m_hasCooldownOnTargetCritHitSpells)
	{
		changed = false;
		for(i = m_OnTargetCritHitSpells.begin();i != m_OnTargetCritHitSpells.end(); i++)
		{
			if((*i)->spellCooldownTimer > p_time)
			{
				changed = true;
				(*i)->spellCooldownTimer -= p_time;
			}else
			{
				(*i)->spellCooldownTimer = 0;
			}
		}
		m_hasCooldownOnTargetCritHitSpells = changed;
	}
	if(m_hasCooldownOnTargetDiedSpells)
	{
		changed = false;
		for(i = m_OnTargetDiedSpells.begin();i != m_OnTargetDiedSpells.end(); i++)
		{
			if((*i)->spellCooldownTimer > p_time)
			{
				changed = true;
				(*i)->spellCooldownTimer -= p_time;
			}else
			{
				(*i)->spellCooldownTimer = 0;
			}
		}
		m_hasCooldownOnTargetDiedSpells = changed;
	}
	if(m_hasCooldownOnUnitParryedSpells)
	{
		changed = false;
		for(i = m_OnUnitParryedSpells.begin();i != m_OnUnitParryedSpells.end(); i++)
		{
			if((*i)->spellCooldownTimer > p_time)
			{
				changed = true;
				(*i)->spellCooldownTimer -= p_time;
			}else
			{
				(*i)->spellCooldownTimer = 0;
			}
		}
		m_hasCooldownOnUnitParryedSpells = changed;
	}
	if(m_hasCooldownOnUnitDodgedSpells)
	{
		changed = false;
		for(i = m_OnUnitDodgedSpells.begin();i != m_OnUnitDodgedSpells.end(); i++)
		{
			if((*i)->spellCooldownTimer > p_time)
			{
				changed = true;
				(*i)->spellCooldownTimer -= p_time;
			}else
			{
				(*i)->spellCooldownTimer = 0;
			}
		}
		m_hasCooldownOnUnitDodgedSpells = changed;
	}
	if(m_hasCooldownOnUnitBlockedSpells)
	{
		changed = false;
		for(i = m_OnUnitBlockedSpells.begin();i != m_OnUnitBlockedSpells.end(); i++)
		{
			if((*i)->spellCooldownTimer > p_time)
			{
				changed = true;
				(*i)->spellCooldownTimer -= p_time;
			}else
			{
				(*i)->spellCooldownTimer = 0;
			}
		}
		m_hasCooldownOnUnitBlockedSpells = changed;
	}
	if(m_hasCooldownOnUnitCritHitSpells)
	{
		changed = false;
		for(i = m_OnUnitCritHitSpells.begin();i != m_OnUnitCritHitSpells.end(); i++)
		{
			if((*i)->spellCooldownTimer > p_time)
			{
				changed = true;
				(*i)->spellCooldownTimer -= p_time;
			}else
			{
				(*i)->spellCooldownTimer = 0;
			}
		}
		m_hasCooldownOnUnitCritHitSpells = changed;
	}
	if(m_hasCooldownOnUnitDiedSpells)
	{
		changed = false;
		for(i = m_OnUnitDiedSpells.begin();i != m_OnUnitDiedSpells.end(); i++)
		{
			if((*i)->spellCooldownTimer > p_time)
			{
				changed = true;
				(*i)->spellCooldownTimer -= p_time;
			}else
			{
				(*i)->spellCooldownTimer = 0;
			}
		}
		m_hasCooldownOnUnitDiedSpells = changed;
	}
	if(m_hasCooldownOnAssistTargetDiedSpells)
	{
		changed = false;
		for(i = m_OnAssistTargetDiedSpells.begin();i != m_OnAssistTargetDiedSpells.end(); i++)
		{
			if((*i)->spellCooldownTimer > p_time)
			{
				changed = true;
				(*i)->spellCooldownTimer -= p_time;
			}else
			{
				(*i)->spellCooldownTimer = 0;
			}
		}
		m_hasCooldownOnAssistTargetDiedSpells = changed;
	}
	if(m_hasCooldownOnFollowOwnerSpells)
	{
		changed = false;
		for(i = m_OnFollowOwnerSpells.begin();i != m_OnFollowOwnerSpells.end(); i++)
		{
			if((*i)->spellCooldownTimer > p_time)
			{
				changed = true;
				(*i)->spellCooldownTimer -= p_time;
			}else
			{
				(*i)->spellCooldownTimer = 0;
			}
		}
		m_hasCooldownOnFollowOwnerSpells = changed;
	}
}

void AIInterface::_UpdateTargets()
{

	if(m_Unit->GetCreatureName()->Type == CRITTER)
		return;
	std::list<Unit*>::iterator i;
	std::list<AI_Target>::iterator itr;

	// Find new Assist Targets and remove old ones
	if(m_AIState == STATE_FLEEING)
		FindFriends(10.0f);
	else if(m_AIState != STATE_IDLE)
	{
		FindFriends(10.0f);
	}
	
	if(m_updateAssist)
	{
		m_updateAssist = false;
		//modified for vs2005 compatibility
		for(i = m_assistTargets.begin(); i != m_assistTargets.end();)
		{
			if(m_Unit->CalcDistance((*i)) > 50.0f || !(*i)->isAlive())
			{
				i = m_assistTargets.erase(i);
			}
			else
			{
				++i;
			}
		}
	}

	if(m_updateTargets)
	{
		m_updateTargets = false;
		//modified for vs2005 compatibility
		for(itr = m_aiTargets.begin(); itr != m_aiTargets.end();)
		{
			if(!itr->target->isAlive() || m_Unit->CalcDistance(itr->target) >= 80.0f)
			{
				itr = m_aiTargets.erase(itr);
			}
			else
			{
				++itr;
			}
		}
		UnitToFollow = NULL;
		if(m_AIType == AITYPE_PET)//TODO: Add stop check here
			UnitToFollow = m_PetOwner;
		if(m_aiTargets.size() == 0 && m_AIState != STATE_IDLE && m_AIState != STATE_FOLLOWING 
            && m_AIState != STATE_EVADE && m_AIState != STATE_FEAR)
			HandleEvent(EVENT_LEAVECOMBAT, m_Unit, 0);
	}
	// Find new Targets when we are ooc
	if(m_AIState == STATE_IDLE && m_assistTargets.size() == 0)
	{
		Unit* target = FindTarget();
		if(target)
			AttackReaction(target, 1, 0);
	}
}

void AIInterface::_UpdateCombat(uint32 p_time)
{
	uint16 agent = AGENT_NULL;


	if(m_fleeTimer != 0) // Creature is fleeing
	{
		if(m_fleeTimer > p_time)
			m_fleeTimer -= p_time;
		else
			m_fleeTimer = 0;

		if(m_creatureState != MOVING && m_fleeTimer != 0)
		{
			agent = AGENT_FLEE;
			m_nextTarget = m_Unit;
		}
	}

    if(m_AIType != AITYPE_PET)
    {
        if(m_Unit->CalcDistance(((Creature*)m_Unit)->respawn_cord[0],((Creature*)m_Unit)->respawn_cord[1],((Creature*)m_Unit)->respawn_cord[2]) > oocr && m_AIState != STATE_EVADE)
	    {
            HandleEvent(EVENT_LEAVECOMBAT, m_Unit, 0);
        }
	}

    if(!m_nextTarget && m_AIState != STATE_FOLLOWING)
	{
		m_nextTarget = FindTargetForSpell(m_nextSpell);
		if(!m_nextTarget)
		{
			HandleEvent(EVENT_LEAVECOMBAT, m_Unit, 0);
		}
	}
	if(m_nextTarget && m_AIState != STATE_EVADE && !m_Unit->isCasting())
	{
		if(agent == AGENT_NULL)
		{
			if(m_nextSpell)
			{
				if(m_nextSpell->agent != AGENT_NULL)
				{
					agent = m_nextSpell->agent;
				}else
				{
					agent = AGENT_MELEE;
				}
			}else
			{
				agent = AGENT_MELEE;
			}
		}
		if(agent == AGENT_RANGED || agent == AGENT_MELEE)
		{
			if(m_canRangedAttack)
			{
				agent = AGENT_MELEE;
				if(m_nextTarget->GetTypeId() == TYPEID_PLAYER)
				{
					float dist = m_Unit->CalcDistance(m_Unit, m_nextTarget);
					if(((Player*)m_nextTarget)->m_currentMovement == MOVE_ROOT || dist >= 8.0f)
					{
						agent =  AGENT_RANGED;
					}
				}else
				{
					if(m_nextTarget->m_canMove == false || m_Unit->CalcDistance(m_Unit, m_nextTarget) >= 8.0f)
					{
						agent = AGENT_RANGED;
					}
				}
			}else
			{
				agent = AGENT_MELEE;
			}
		}
		if(!m_nextTarget->isAlive())
		{
			m_nextTarget = NULL;
			return;
		}
		switch(agent)
		{
		case AGENT_MELEE: case AGENT_RANGED:
			{
				float combatReach[2]; // Calculate Combat Reach
				float distance = m_Unit->CalcDistance(m_nextTarget);

				if(agent == AGENT_MELEE)
				{
					combatReach[0] = 0.0f;
					combatReach[1] = _CalcCombatRange(m_nextTarget, false);
				}else if(agent == AGENT_RANGED)
				{
					combatReach[0] = 8.0f;
					combatReach[1] = 30.0f;
				}

				if(distance >= combatReach[0] && distance <= combatReach[1]) // Target is in Range -> Attack
				{
					UnitToFollow = NULL; //we shouldn't be following any one
					FollowDistance = 0.0f;
					m_creatureState = ATTACKING;
					if(m_Unit->isAttackReady())
					{
						if(!m_Unit->isInFront(m_nextTarget)) // set InFront
							setInFront(m_nextTarget);

						m_Unit->setAttackTimer(0);
						m_Unit->AttackerStateUpdate(m_nextTarget, 0);
					}
				}else // Target out of Range -> Run to it
				{
					//calculate next move
					float x, y, z;
					float dist = 1.0f;
					if(agent == AGENT_MELEE)
						dist = 4.5f;
					else
					{
						if(distance < combatReach[0])// Target is too near
							dist = 9.0f;
						else
							dist = 20.0f;
					}
					float* coords = _CalcDestination(m_nextTarget, dist);
					x = coords[0];
					y = coords[1];
					z = coords[2];

					m_moveRun = true;
					if(m_creatureState != MOVING)
						MoveTo(x, y, z,0);

					UnitToFollow = m_nextTarget;
					FollowDistance = dist;
				}
			}break;
		case AGENT_SPELL:
			{
				float distance = m_Unit->CalcDistance(m_nextTarget);
				if((distance <= m_nextSpell->maxrange  && distance >= m_nextSpell->minrange) || m_nextSpell->maxrange == 0) // Target is in Range -> Attack
				{
					uint32 spellId = m_nextSpell->spellId;
					SpellEntry* spellInfo = getSpellEntry(spellId);
					SpellCastTargets targets = setSpellTargets(spellInfo, m_nextTarget);
					CastSpell(m_Unit, spellInfo, targets);
					increaseProcCounter(m_nextSpell->procEvent, m_nextSpell);
					m_nextSpell = NULL;
				}else // Target out of Range -> Run to it
				{
					//calculate next move
					float x, y, z;
					float dist = m_nextSpell->maxrange - 5.0f;
					float* coords = _CalcDestination(m_nextTarget, dist);
					x = coords[0];
					y = coords[1];
					z = coords[2];

					m_moveRun = true;
					if(m_creatureState != MOVING)
						MoveTo(x, y, z,0);
				}
			}break;
		case AGENT_FLEE:
			{
				float x, y, z;
				float dist = 5.0f;
				float* coords = _CalcDestination(m_nextTarget, dist);

				x = coords[0];
				y = coords[1];
				z = coords[2];

				m_moveRun = false;
				if(m_fleeTimer == 0)
					m_fleeTimer = 10000;
				m_hasFleed = true;
				if(m_creatureState != MOVING)
					MoveTo(x, y, z,0);
				m_AIState = STATE_FLEEING;
			}break;
		case AGENT_CALLFORHELP:
			{
				FindFriends(20.0f);
				m_hasCalledForHelp = true; // We only want to call for Help once in a Fight.
			}break;
		}
	}
}

void AIInterface::AttackReaction(Unit* pUnit, uint32 damage_dealt, uint32 state)
{
    if(m_AIState == STATE_EVADE || m_fleeTimer != 0 || !pUnit 
        || m_Unit->IsPacified() || m_Unit->IsStunned())
		return;

	bool state_reduced = false;
	if(state >= 0xFF)
	{
		state -= 0xFF;
		state_reduced = true;
	}

	if(m_AIState == STATE_IDLE)
	{
		_SendLuaEvent(ON_UNIT_COMBAT_START);
		HandleEvent(EVENT_ENTERCOMBAT, pUnit, 0);
	}

	switch(state)
	{
	case 1: // Target dodged
		{
			HandleEvent(EVENT_TARGETDODGED, pUnit, 0);
		}break;
	case 2: // Target blocked
		{
			HandleEvent(EVENT_TARGETBLOCKED, pUnit, 0);
		}break;
	case 3: // Target parryed
		{
			HandleEvent(EVENT_TARGETPARRYED, pUnit, 0);
		}break;
	case 5: // Unit critted
		{
			HandleEvent(EVENT_UNITCRITHIT, pUnit, 0);
		}break;
	}
	if(!state_reduced)
		HandleEvent(EVENT_DAMAGETAKEN, pUnit, damage_dealt);
}

void AIInterface::OnDeath()
{
	HandleEvent(EVENT_UNITDIED, m_Unit, 0);
}

Unit* AIInterface::FindTarget()
{// find nearest hostile Target to attack
	CreatureInfo* ci = m_Unit->GetCreatureName();
	Unit* target = NULL;
	float distance = 0.0f;

	std::set<Object*>::iterator itr;

	/*Original code*/
	for( itr = m_Unit->GetInRangeSetBegin(); itr != m_Unit->GetInRangeSetEnd(); itr++ )
	{
		if((*itr)->GetTypeId() != TYPEID_PLAYER && (*itr)->GetTypeId() != TYPEID_UNIT)
			continue;

		CreatureInfo* ti = ((Unit*)(*itr))->GetCreatureName();;
		if(!ti)
			continue;

		if(!((Unit*)(*itr))->isAlive())
			continue;

		if(checkFaction(m_Unit, (Unit*)(*itr), 0) && ti->Family != CRITTER)// is hostile
		{
			float dist = m_Unit->CalcDistance(m_Unit, (*itr));
			if(distance > dist)
				continue;
			if(dist <= _CalcAggroRange((Unit*)(*itr)))
			{
				target = (Unit*)(*itr);
				distance = dist;
			}


		}
		if(ci->Family == BEAST && target == NULL)// Attack Critters if this is a Beast
		{
			if((*itr)->GetTypeId() == TYPEID_UNIT)
			{
				float dist = m_Unit->CalcDistance(m_Unit, (*itr));
				if(ti->Family == CRITTER && dist < distance && dist < 5.0f)
				{
					target = (Unit*)(*itr);
					distance = dist;
				}
			}
		}
	}
/*	for( itr = m_Unit->GetInRangeOppFactsSetBegin(); itr != m_Unit->GetInRangeOppFactsSetEnd(); itr++ )
	{
		CreatureInfo* ti = ((Unit*)(*itr))->GetCreatureName();;
		if(!ti)
			continue;

		if(!((Unit*)(*itr))->isAlive())
			continue;

		float dist = m_Unit->CalcDistance(m_Unit, (*itr));
		if(distance > dist)
			continue;
		if(dist <= _CalcAggroRange((Unit*)(*itr)))
		{
			target = (Unit*)(*itr);
			distance = dist;
		}

		if(ci->Family == BEAST && target == NULL)// Attack Critters if this is a Beast
		{
			if((*itr)->GetTypeId() == TYPEID_UNIT)
			{
				float dist = m_Unit->CalcDistance(m_Unit, (*itr));
				if(ti->Family == CRITTER && dist < distance && dist < 5.0f)
				{
					target = (Unit*)(*itr);
					distance = dist;
				}
			}
		}
	}*/

	if(target)
	{
		AttackReaction(target, 1, 0);
	}
	return target;
}

Unit* AIInterface::FindTargetForSpell(AI_Spell *sp)
{
	if(!sp)
		return NULL;

	std::list<AI_Target>::iterator itr;
	if(sp->spellType == STYPE_HEAL)
	{
		uint32 cur = m_Unit->GetUInt32Value(UNIT_FIELD_HEALTH);
		uint32 max = m_Unit->GetUInt32Value(UNIT_FIELD_MAXHEALTH);
		float healthPercent = float(long2float(cur) / long2float(max));
		if(healthPercent <= sp->floatMisc1) // Heal ourselves cause we got too low HP
		{
			return m_Unit;
		}
		for(std::list<Unit*>::iterator i = m_assistTargets.begin(); i != m_assistTargets.end(); i++)
		{
			if(!(*i)->isAlive())
				continue;
			cur = (*i)->GetUInt32Value(UNIT_FIELD_HEALTH);
			max = (*i)->GetUInt32Value(UNIT_FIELD_MAXHEALTH);
			healthPercent = float(long2float(cur) / long2float(max));
			if(healthPercent <= sp->floatMisc1) // Heal ourselves cause we got too low HP
			{
				return (*i); // heal Assist Target which has low HP
			}
		}
	}
	if(sp->spellType == STYPE_BUFF)
	{
		return m_Unit;
	}

	Unit* target = NULL;
	uint32 threat = 0;
	//modified for vs2005 compatibility
	for (itr = m_aiTargets.begin(); itr != m_aiTargets.end();) // Find Target and Cleanup Targetlist
	{
		if(itr->threat > threat)
		{
			if(itr->target->isAlive())
			{
				target = itr->target;
				threat = itr->threat;
				++itr;
			}else
			{
				itr = m_aiTargets.erase(itr);
			}
		}
		else
		{
			++itr;
		}
	}
	if(target)
		return target;

	return NULL;
}

bool AIInterface::FindFriends(float dist)
{
	bool result = false;
	std::list<Unit*>::iterator i;
	std::list<AI_Target>::iterator it;
	std::set<Object*>::iterator itr;
	for( itr = m_Unit->GetInRangeSetBegin(); itr != m_Unit->GetInRangeSetEnd(); itr++ )
	{
		if((*itr)->GetTypeId() != TYPEID_PLAYER && (*itr)->GetTypeId() != TYPEID_UNIT)
			continue;
		if(!((Unit*)(*itr))->isAlive())
			continue;
		if(checkFaction((Unit*)(*itr), m_Unit, 1) && ((Unit*)(*itr))->GetAIInterface()->getAIState() == STATE_IDLE)
			if(m_Unit->CalcDistance((*itr)) < dist)
			{
				for(i = m_assistTargets.begin(); i != m_assistTargets.end(); i++)
					if((*i)->GetGUID() == (*itr)->GetGUID())
						break;
				if(i == m_assistTargets.end())
				{
					result = true;
					m_assistTargets.push_back(((Unit*)(*itr)));
					for(it = m_aiTargets.begin(); it != m_aiTargets.end(); it++)
						((Unit*)(*itr))->GetAIInterface()->AttackReaction(it->target, 1, 0);
				}
			}
	}
	return result;
}

float AIInterface::_CalcAggroRange(Unit* target)
{
	float baseAR = 15.0f; // Base Aggro Range
	uint8 lvlDiff = target->getLevel() - m_Unit->getLevel();
	if(lvlDiff >= (target->getLevel() *0.2)) // Target is more then 20% higher then Mob
		baseAR = 5.0f;

	return baseAR;
}

float* AIInterface::_CalcDestination(Unit* target, float dist)
{
	float coords[3];
    if(target->GetTypeId() == TYPEID_UNIT || target->GetTypeId() == TYPEID_PLAYER)
    {
        float angle = m_Unit->calcAngle(m_Unit->GetPositionX(), m_Unit->GetPositionY(), target->GetPositionX(), target->GetPositionY()) * M_PI / 180.0f;
        float x = cos(angle) * (dist - _CalcCombatRange(target, false));
        float y = sin(angle) * (dist - _CalcCombatRange(target, false));
        coords[0] = target->GetPositionX() - x;
        coords[1] = target->GetPositionY() - y;
        coords[2] = target->GetPositionZ();
        return coords;
    }
    else
    {
        target = NULL;
        coords[0] = m_Unit->GetPositionX();
        coords[1] = m_Unit->GetPositionY();
        coords[2] = m_Unit->GetPositionZ();
        return coords;
    }
}

float AIInterface::_CalcCombatRange(Unit* target, bool ranged)
{
	if(!target)
		return 0;
	float range = 0.0f;
	float rang = 1.5f;
	if(ranged)
		rang = 5.0f;
	float targetreach = target->GetFloatValue(UNIT_FIELD_COMBATREACH);
	float selfreach = m_Unit->GetFloatValue(UNIT_FIELD_COMBATREACH);
	float targetradius = target->GetFloatValue(UNIT_FIELD_BOUNDINGRADIUS);
	float selfradius = m_Unit->GetFloatValue(UNIT_FIELD_BOUNDINGRADIUS);
	float targetscale = target->GetFloatValue(OBJECT_FIELD_SCALE_X);
	float selfscale = m_Unit->GetFloatValue(OBJECT_FIELD_SCALE_X);

	range = (((pow(targetradius,2)*targetscale) + selfreach) + ((pow(selfradius,2)*selfscale) + rang));
	return range;
}

float AIInterface::_CalcDistanceFromHome()
{
	if (m_AIType == AITYPE_PET)
		return m_Unit->CalcDistance(m_PetOwner);
	else if(m_Unit->GetTypeId() == TYPEID_UNIT)
		return m_Unit->CalcDistance(((Creature*)m_Unit)->respawn_cord[0], ((Creature*)m_Unit)->respawn_cord[1], ((Creature*)m_Unit)->respawn_cord[2]);

	return 0.0f;
}

void AIInterface::SendMoveToPacket(float toX, float toY, float toZ, float toO, uint32 time, uint32 MoveFlags)
{
	if(!m_canMove)
		return;

    /*
    Move Flags
    0x00000000 - Walk
    0x00000100 - Run
    0x00000300 - Fly
    */
	WorldPacket data;

	uint8 DontMove = 0;
	data.Initialize( SMSG_MONSTER_MOVE );
	data << m_Unit->GetNewGUID();
	data << m_Unit->GetPositionX() << m_Unit->GetPositionY() << m_Unit->GetPositionZ();
	data << getMSTime();
	data << uint8(DontMove);
	if(DontMove != 1)
	{
		//data << uint32(run ? 0x00000100 : 0x00000000);
        data << uint32(MoveFlags);
		data << time;
		/*
		if(toO != 0.0f)
		{
			data << uint32(2);
		}
		else
		{*/
			data << uint32(1); //Number of Waypoints
		//}
		data << toX << toY << toZ;
		/*if(toO != 0.0f)
		{
			data << toO;
		}*/

	}
	m_Unit->SendMessageToSet( &data, false );
}

void AIInterface::SendMoveToSplinesPacket(std::list<Waypoint> wp, bool run)
{
	if(!m_canMove)
		return;

	WorldPacket data;

	uint8 DontMove = 0;
	uint32 travelTime = 0;
	for(std::list<Waypoint>::iterator i = wp.begin(); i != wp.end(); i++)
	{
		travelTime += i->time;
	}

	data.Initialize( SMSG_MONSTER_MOVE );
	data << m_Unit->GetNewGUID();
	data << m_Unit->GetPositionX() << m_Unit->GetPositionY() << m_Unit->GetPositionZ();
	data << getMSTime();
	data << uint8(DontMove);
	data << uint32(run ? 0x00000100 : 0x00000000);
	data << travelTime;
	data << (uint32)wp.size();
	for(std::list<Waypoint>::iterator i = wp.begin(); i != wp.end(); i++)
	{
		data << i->x;
		data << i->y;
		data << i->z;
	}

	m_Unit->SendMessageToSet( &data, false );
}

void AIInterface::SendStopPacket()
{
	if(!m_canMove)
		return;

	WorldPacket data;

	uint8 DontMove = 1;
	data.Initialize( SMSG_MONSTER_MOVE );
	data << m_Unit->GetNewGUID();
	data << m_Unit->GetPositionX() << m_Unit->GetPositionY() << m_Unit->GetPositionZ();
	data << getMSTime();
	data << uint8(DontMove);
	m_Unit->SendMessageToSet( &data, false );
}

void AIInterface::MoveTo(float x, float y, float z, float o)
{
	if(!m_canMove)
		return;

	float distance = m_Unit->CalcDistance(x,y,z);

	m_destinationX = x;
	m_destinationY = y;
	m_destinationZ = z;

	//if(m_AIState == STATE_IDLE)
    //    m_moveRun = false;

    uint32 MoveFlags = 0;
    if(m_moveFly == true) //Fly
    {
        m_moveSpeed = m_Unit->m_flySpeed*0.001f;
        MoveFlags = 0x300;
    }
    else if(m_moveRun == true) //Run
    {
        m_moveSpeed = m_Unit->m_runSpeed*0.001f;
        MoveFlags = 0x100;
    }
    else //Walk
    {
        m_moveSpeed = m_Unit->m_walkSpeed*0.001f;
        MoveFlags = 0x000;
    }
    
    uint32 moveTime = (uint32) (distance / m_moveSpeed);
    
    SendMoveToPacket(x, y, z, o, moveTime,MoveFlags);

	m_timeToMove = moveTime;
	m_timeMoved = 0;
	if(m_moveTimer == 0)
		m_moveTimer =  UNIT_MOVEMENT_INTERPOLATE_INTERVAL; /* update every few msecs */

	m_creatureState = MOVING;
}

bool AIInterface::setInFront(Unit* target) // not the best way to do it, though
{
	//angle the object has to face
	float angle = m_Unit->calcAngle(m_Unit->GetPositionX(), m_Unit->GetPositionY(), target->GetPositionX(), target->GetPositionY() ); 
	//Change angle slowly 2000ms to turn 180 deg around
	if(angle > 180) angle + 9;
	else angle - 9; //angle < 180
	m_Unit->getEasyAngle(angle);
	//Convert to Blizzards Format
	float orientation = angle / (360 / float(2 * M_PI));
	//Update Orentation Server Side
	m_Unit->SetPosition(m_Unit->GetPositionX(), m_Unit->GetPositionY(), m_Unit->GetPositionZ(), orientation);
	//Update Orentation Client Side
	bool Send = m_Unit->isInFront(target);
	//the above code works just havn't found a way to update the clients visual look
	/*
	if(Send) //Sending it multiple times doesn't update it any more then sending it once at the end
	{
		// update orentation for others
		WorldPacket data;
		UpdateData upd;
		m_Unit->BuildMovementUpdateBlock(&upd,0);
		upd.BuildPacket( &data );
		m_Unit->SendMessageToSet(&data,false);
	}
	return Send;
	*/
	return true;
}


bool AIInterface::addWayPoint(WayPoint* wp)
{
    if(!wp) return false;
    if(wp->id <= 0) return false; //not valid id

    if(m_waypoints.find( wp->id ) == m_waypoints.end( ))
    {
        m_waypoints[wp->id] = wp;
        m_nWaypoints = m_waypoints.size();
        return true;
    }
    return false;
}

void AIInterface::changeWayPointID(uint32 oldwpid, uint32 newwpid)
{
    if(newwpid <= 0) return; //not valid id
    if(newwpid > m_waypoints.size()) return; //not valid id
    if(newwpid == oldwpid) return; //same spot
    
    //already wp with that id ?
    WayPoint* originalwp = getWayPoint(newwpid);
    if(!originalwp) return;
    WayPoint* oldwp = getWayPoint(oldwpid);
    if(!oldwp) return;
    uint32 startsize = m_waypoints.size();

    //we have valid wps in the positions
    WayPoint* wpnext = NULL;
    WayPoint* wp = NULL;
    uint32 i = 0;
    uint32 endat = 0;
    //reorder freeing newwpid's spot
    if((oldwpid+1 == newwpid) || (newwpid+1 == oldwpid))
    {
        //within 1 place of eachother just swap
        oldwp->id = newwpid;
        originalwp->id = oldwpid;
        m_waypoints[newwpid] = oldwp;
        m_waypoints[oldwpid] = originalwp;
    }
    //        4          2
    else if(oldwpid > newwpid) // move others up
    {
        //2       4         2
        endat = (oldwpid-newwpid);
        
        for(i = 0; i < endat;i++)
        {
            //                  2
            wpnext = getWayPoint(newwpid+i+1); //waypoint 3
                //m_waypoints[newwpid+i+1]; //waypoint 3

            if(i == 0)
            {
                //First move
                oldwp->id = newwpid;
                m_waypoints[newwpid] = oldwp; //position 2

                originalwp->id = newwpid+1;
                m_waypoints[newwpid+1] = originalwp; //position 3
            }
            else //i > 0
            {
                if(wp)
                {
                    wp->id = newwpid+1+i;
                    m_waypoints[newwpid+1+i] = wp;
                }
            }
            wp = wpnext;
        }
    }
    //        2          4
    else if(oldwpid < newwpid) //move others down
    {
        //2       4         2
        endat = (newwpid-oldwpid);
        
        for(i = 0; i < endat;i++)
        {
            //                  2
            wp = getWayPoint(oldwpid+i+1); //waypoint 3
            if(wp)
            {
                wp->id = oldwpid+i;
                m_waypoints[oldwpid+i] = wp; //position 2
            }
            if(i == endat-1)
            {
                oldwp->id = newwpid;
                m_waypoints[newwpid] = oldwp; //position 4
            }
        }
    }

    //SaveAll to db
    saveWayPoints(NULL);
}

void AIInterface::deleteWayPoint(uint32 wpid)
{
    if(wpid <= 0) return; //not valid id
    if(wpid > m_waypoints.size()) return; //not valid id

    uint32 startsize = m_waypoints.size();
    //Delete Waypoint
    if( m_waypoints.find( wpid ) != m_waypoints.end( ) )
    {
        delete m_waypoints[ wpid ];
        m_waypoints.erase( wpid );
    }

    WayPoint* wp = NULL;
    //Reorginise the rest
    if(wpid <= m_waypoints.size()) //non existant wp
    {
        uint32 i = 0;
        for(i = 0; i < startsize-wpid;i++)
        {
            wp = m_waypoints[wpid+i+1];
            if(wp)
            {
                wp->id = wpid+i;
                m_waypoints[wpid+i] = wp;
            }
        }
        m_waypoints.erase( wpid+i );
    }

    m_nWaypoints = m_waypoints.size();
    //SaveAll to db
    saveWayPoints(NULL);
}

bool AIInterface::showWayPoints(uint32 wpid, Player* pPlayer, bool Backwards)
{
    if(wpid < 0) return false; //not valid id
    if(wpid > m_waypoints.size()) return false; //not valid id
    
    //wpid of 0 == all
    WayPointMap::const_iterator itr;
    if((m_WayPointsShowing == true) && (wpid == 0)) return false;
    m_WayPointsShowing = true;
    
    WayPoint* wp = NULL;
    for (itr = m_waypoints.begin(); itr != m_waypoints.end(); itr++)
    {
        if( (itr->second->id == wpid) || (wpid == 0) )
        {
            wp = itr->second;

            //Create
            Creature* pWayPoint = new Creature();
            pWayPoint->CreateWayPoint(wp->id,pPlayer->GetMapId(),wp->x,wp->y,wp->z,0);
            pWayPoint->SetUInt32Value(OBJECT_FIELD_ENTRY, 300000);
            pWayPoint->SetFloatValue(OBJECT_FIELD_SCALE_X, 0.5f);
            if(Backwards)
            {
                uint32 DisplayID = (wp->backwardskinid == 0)? GetUnit()->GetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID) : wp->backwardskinid;
                pWayPoint->SetUInt32Value(UNIT_FIELD_DISPLAYID, DisplayID);
                pWayPoint->SetUInt32Value(UNIT_NPC_EMOTESTATE, wp->backwardemoteid);
            }
            else
            {
                uint32 DisplayID = (wp->forwardskinid == 0)? GetUnit()->GetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID) : wp->forwardskinid;
                pWayPoint->SetUInt32Value(UNIT_FIELD_DISPLAYID, DisplayID);
                pWayPoint->SetUInt32Value(UNIT_NPC_EMOTESTATE, wp->forwardemoteid);
            }
            pWayPoint->SetUInt32Value(UNIT_FIELD_LEVEL, wp->id);
            pWayPoint->SetUInt32Value(UNIT_NPC_FLAGS, 0);
            pWayPoint->SetUInt32Value(UNIT_FIELD_AURA+32, 8326); //invisable & deathworld look
            pWayPoint->SetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE , pPlayer->GetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE));
            pWayPoint->SetUInt32Value(UNIT_FIELD_HEALTH, 1);
            pWayPoint->SetUInt32Value(UNIT_FIELD_MAXHEALTH, 1);

            //Create on client
            UpdateData *data;
            WorldPacket packet;
            data = new UpdateData;
            pWayPoint->BuildCreateUpdateBlockForPlayer(data,pPlayer);
            data->BuildPacket( &packet );
            pPlayer->GetSession()->SendPacket( &packet );
        
            //root the object
            WorldPacket data1;
            data1.Initialize(SMSG_FORCE_MOVE_ROOT);
            data1 << pWayPoint->GetNewGUID();
            pPlayer->GetSession()->SendPacket( &data1 );

            //Cleanup
            delete data;
            delete pWayPoint;
            if(wpid != 0) return true;
        }
    }
    return true;
}

bool AIInterface::hideWayPoints(uint32 wpid, Player* pPlayer)
{
    if(wpid < 0) return false; //not valid id
    if(wpid > m_waypoints.size()) return false; //not valid id

    //wpid of 0 == all
    if(m_WayPointsShowing != true) return false;
    m_WayPointsShowing = false;
    WorldPacket data;
    WayPointMap::const_iterator itr;

    for (itr = m_waypoints.begin(); itr != m_waypoints.end(); itr++)
    {
        if( (itr->second->id == wpid) || (wpid == 0) )
        {
            data.clear();
            data.Initialize( SMSG_DESTROY_OBJECT );
            data << uint32(itr->second->id);
            data << uint32(HIGHGUID_WAYPOINT);
            pPlayer->GetSession()->SendPacket( &data );
            if(wpid != 0) return true;
        }
    }
    return true;
}

bool AIInterface::saveWayPoints(uint32 wpid)
{
    if(wpid < 0) return false; //not valid id
    if(wpid > m_waypoints.size()) return false; //not valid id

    //wpid of 0 == all
    std::stringstream ss;
    if(wpid == 0)
    {
        //Delete
        ss << "DELETE FROM creature_waypoints WHERE creatureid = " << GetUnit()->GetGUIDLow() << "\0";
        sDatabase.Query( ss.str().c_str() );
    }

    WayPointMap::const_iterator itr;

    WayPoint* wp = NULL;
    for (itr = m_waypoints.begin(); itr != m_waypoints.end(); itr++)
    {
        if( (itr->second->id == wpid) || (wpid == 0) )
        {
            wp = itr->second;

            if(wpid != 0)
            {
                //Delete
                ss.str("");
                ss << "DELETE FROM creature_waypoints WHERE creatureid = " << GetUnit()->GetGUIDLow() << " and waypointid = " << wp->id << "\0";
                sDatabase.Query( ss.str().c_str() );
            }

            //Save
            ss.str("");
            ss << "INSERT INTO creature_waypoints ";
            ss << "(creatureid,waypointid,x,y,z,waittime,flags,forwardemoteoneshot,forwardemoteid,backwardemoteoneshot,backwardemoteid,forwardskinid,backwardskinid) VALUES (";
            ss << GetUnit()->GetGUIDLow() << ", ";
            ss << wp->id << ", ";
            ss << wp->x << ", ";
            ss << wp->y << ", ";
            ss << wp->z << ", ";
            ss << wp->waittime << ", ";
            ss << wp->flags << ", ";
            ss << wp->forwardemoteoneshot << ", ";
            ss << wp->forwardemoteid << ", ";
            ss << wp->backwardemoteoneshot << ", ";
            ss << wp->backwardemoteid << ", ";
            ss << wp->forwardskinid << ", ";
            ss << wp->backwardskinid << ")\0";
            sDatabase.Query( ss.str().c_str() );
            
            if(wpid != 0) return true;
        }
    }
    return false;
}

WayPoint* AIInterface::getWayPoint(uint32 wpid)
{
    if(wpid < 0) return NULL; //not valid id
    if(wpid > m_waypoints.size()) return NULL; //not valid id

    WayPointMap::const_iterator itr = m_waypoints.find( wpid );
    if( itr != m_waypoints.end( ) )
        return itr->second;
    return NULL;
}

void AIInterface::_UpdateMovement(uint32 p_time)
{
    if(!m_canMove)
		return;

	uint32 timediff = 0;

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

	if(m_timeToMove > 0)
		m_timeMoved = m_timeToMove <= p_time + m_timeMoved ? m_timeToMove : p_time + m_timeMoved;

    if(m_creatureState == MOVING)
    {
	    if((!m_moveTimer) || (m_AIState == STATE_ATTACKING )) // if we attacking the rules don't apply to us
	    {
		    if(m_timeMoved == m_timeToMove) //reached destination
		    {
                if((m_nWaypoints != 0) && (m_AIState != STATE_ATTACKING )) //if we attacking don't use wps
                {
                    WayPoint* wp = getWayPoint(getCurrentWaypoint());
                    if(wp)
                    {
                        m_moveTimer = wp->waittime; //wait before next move
                        if(!m_moveBackward)
                        {
                            if(wp->forwardemoteoneshot)
                            {
                                GetUnit()->Emote(EmoteType(wp->forwardemoteid));
                            }
                            else
                            {
                                if(GetUnit()->GetUInt32Value(UNIT_NPC_EMOTESTATE) != wp->forwardemoteid)
                                {
                                    GetUnit()->SetUInt32Value(UNIT_NPC_EMOTESTATE, wp->forwardemoteid);
                                }
                            }
                        }
                        else
                        {
                            if(wp->backwardemoteoneshot)
                            {
                                GetUnit()->Emote(EmoteType(wp->backwardemoteid));
                            }
                            else
                            {
                                if(GetUnit()->GetUInt32Value(UNIT_NPC_EMOTESTATE) != wp->backwardemoteid)
                                {
                                    GetUnit()->SetUInt32Value(UNIT_NPC_EMOTESTATE, wp->backwardemoteid);
                                }
                            }
                        }
                    }
                    else
                        m_moveTimer = rand() % (m_moveRun ? 5000 : 10000); // wait before next move
                }
                else
                    m_moveTimer = 1000; //short pause after stopping
				
                m_creatureState = STOPPED;
				
				if(m_fleeTimer != 0)
					m_moveTimer = 0;

				m_Unit->SetPosition(m_destinationX, m_destinationY, m_destinationZ, true);

                // Set health to full if they at there respawn location
       		    if((m_Unit->GetPositionX() == ((Creature*)m_Unit)->respawn_cord[0]) && (m_Unit->GetPositionY() == ((Creature*)m_Unit)->respawn_cord[1])&& (m_Unit->GetPositionZ() == ((Creature*)m_Unit)->respawn_cord[2]))
	    		    m_Unit->SetUInt32Value(UNIT_FIELD_HEALTH,m_Unit->GetUInt32Value(UNIT_FIELD_MAXHEALTH));
                
				m_destinationX = m_destinationY = m_destinationZ = 0;
				m_timeMoved = 0;
				m_timeToMove = 0;
			}
			else
			{
				float q = (float)m_timeMoved / (float)m_timeToMove;
				float x = m_Unit->GetPositionX() + (m_destinationX - m_Unit->GetPositionX()) * q;
				float y = m_Unit->GetPositionY() + (m_destinationY - m_Unit->GetPositionY()) * q;
				float z = m_Unit->GetPositionZ() + (m_destinationZ - m_Unit->GetPositionZ()) * q;
				m_Unit->SetPosition(x, y, z, m_Unit->GetOrientation());

				m_timeToMove -= m_timeMoved;
				m_timeMoved = 0;
    			m_moveTimer = (UNIT_MOVEMENT_INTERPOLATE_INTERVAL < m_timeToMove) ? UNIT_MOVEMENT_INTERPOLATE_INTERVAL : m_timeToMove;
			}
			//stuff that has to be done after a movment update (keeps client and server in sync)
			if(UnitToFollow != NULL && m_AIState != STATE_EVADE) //follow Unit Code
			{
				float dist = m_Unit->CalcDistance(UnitToFollow);
				float radius = m_Unit->GetFloatValue(UNIT_FIELD_BOUNDINGRADIUS);
				if (dist > FollowDistance) //if out of range
				{
					//calculate next move
					float x, y, z;
					float* coords = _CalcDestination(UnitToFollow, FollowDistance);
					x = coords[0];
					y = coords[1];
					z = coords[2];

					m_moveRun = true;
					MoveTo(x, y, z,0);
				}
			}
		}
	}
    else if(m_AIType == AITYPE_PET && m_AIState == STATE_IDLE && UnitToFollow != NULL
		&& m_AIState != STATE_STOPPED)
    {
		if(m_Unit->GetPositionX() == (m_PetOwner->GetPositionX()-2.0))
			return;
        float dist = m_Unit->CalcDistance(UnitToFollow);
        float radius = m_Unit->GetFloatValue(UNIT_FIELD_BOUNDINGRADIUS);
        if (dist > FollowDistance) //if out of range
        {
            m_creatureState = MOVING;
            m_AIState = STATE_FOLLOWING;
			//calculate next move
            float x, y, z;
            float* coords = _CalcDestination(UnitToFollow, FollowDistance);
            x = coords[0];
            y = coords[1];
            z = coords[2];
            
            m_moveRun = true;
            MoveTo(x, y, z,0);
        }
        return;
    }
    else if(m_AIState == STATE_FEAR && UnitToFear != NULL)
    {
        float or = UnitToFear->GetOrientation();
        MoveTo(m_Unit->GetPositionX() + (cos(or) * 10),m_Unit->GetPositionY() + (sin(or) * 10),m_Unit->GetPositionZ(),or);
        m_creatureState = MOVING;
    }
	else if(m_creatureState == STOPPED && m_AIState == STATE_IDLE && !m_moveTimer && !m_timeToMove) //creature is stopped and out of Combat
	{
		if(UnitToFollow != NULL) //if we following some one
			return;

		if(sWorld.getAllowMovement() == false) //is creature movement enabled?
			return;

		if(m_Unit->GetUInt32Value(UNIT_FIELD_DISPLAYID) == 5233) //if Spirit Healer don't move
			return;


		int destpoint;
		
		// If creature has no waypoints just wander aimlessly around spawnpoint
		if(m_nWaypoints==0) //no waypoints
		{
		/*	if(m_moveRandom)
			{
				if((rand()%10)==0)                                                                                                                                    
				{                                                                                                                                                                  
					float wanderDistance = rand()%4 + 2;
					float wanderX = ((wanderDistance*rand()) / RAND_MAX) - wanderDistance / 2;                                                                                                               
					float wanderY = ((wanderDistance*rand()) / RAND_MAX) - wanderDistance / 2;                                                                                                               
					float wanderZ = 0; // FIX ME ( i dont know how to get apropriate Z coord, maybe use client height map data)                                                                                                             

					if(m_Unit->CalcDistance(m_Unit->GetPositionX(), m_Unit->GetPositionY(), m_Unit->GetPositionZ(), ((Creature*)m_Unit)->respawn_cord[0], ((Creature*)m_Unit)->respawn_cord[1], ((Creature*)m_Unit)->respawn_cord[2])>15)                                                                           
					{   
						//return home                                                                                                                                                 
						MoveTo(((Creature*)m_Unit)->respawn_cord[0],((Creature*)m_Unit)->respawn_cord[1],((Creature*)m_Unit)->respawn_cord[2],false);
					}   
					else
					{
						MoveTo(m_Unit->GetPositionX() + wanderX, m_Unit->GetPositionY() + wanderY, m_Unit->GetPositionZ() + wanderZ,false);
					}    
				}    
			}
		*/	return;                                                                                                                                                   
		}                                                                                                                                                          
		else //we do have waypoints
		{
			if(m_moveRandom) //is random move on if so move to a random waypoint
			{
				if(m_nWaypoints > 1)
				    destpoint = rand() % m_nWaypoints;
			}
			else //random move is not on lets follow the path
			{
				if (m_currentWaypoint > m_nWaypoints) m_currentWaypoint = 1; //Happens when you delete last wp seems to continue ticking
                if (m_currentWaypoint == (m_nWaypoints)) // Are we on the last waypoint? if so walk back
					m_moveBackward = true;
				if (m_currentWaypoint == 1) // Are we on the first waypoint? if so lets goto the second waypoint
					m_moveBackward = false;
				if (!m_moveBackward) // going 1..n
					destpoint = ++m_currentWaypoint;
				else                // going n..1
					destpoint = --m_currentWaypoint;

				WayPoint* wp = getWayPoint(destpoint);
				if(wp)
				{
					if(!m_moveBackward)
					{
						if((wp->forwardskinid != 0) && (GetUnit()->GetUInt32Value(UNIT_FIELD_DISPLAYID) != wp->forwardskinid))
						{
							GetUnit()->SetUInt32Value(UNIT_FIELD_DISPLAYID, wp->forwardskinid);
						}
					}
					else
					{
						if((wp->backwardskinid != 0) && (GetUnit()->GetUInt32Value(UNIT_FIELD_DISPLAYID) != wp->backwardskinid))
						{
							GetUnit()->SetUInt32Value(UNIT_FIELD_DISPLAYID, wp->backwardskinid);
						}
					}
                    m_moveFly = (wp->flags == 768) ? 1 : 0;
                    m_moveRun = (wp->flags == 256) ? 1 : 0;
					MoveTo(wp->x, wp->y, wp->z, 0);
				}
            }
		}
	}
    else if(m_creatureState == STOPPED && m_timeToMove > 0) // Happens some times and stops wps from been used
    {
        //shouldn't get here lets fix it up
        //this happens when the state is changed to stopped and the creature was moving
        // Only affects waypoints
        m_timeToMove = 0;
    }
}

void AIInterface::CastSpell(Unit* caster, SpellEntry *spellInfo, SpellCastTargets targets)
{
	// check for spell id
	//printf("Spell: %u cast by "I64FMT"\n", spellInfo->Id, caster->GetGUID());
	m_AIState = STATE_CASTING;
	Spell *spell = new Spell(caster, spellInfo, false, 0,false);
	WPAssert(spell);

	spell->prepare(&targets);
}

SpellEntry *AIInterface::getSpellEntry(uint32 spellId)
{
	SpellEntry *spellInfo = sSpellStore.LookupEntry(spellId );

	if(!spellInfo)
	{
		Log::getSingleton( ).outError("WORLD: unknown spell id %i\n", spellId);
		return NULL;
	}

	return spellInfo;
}

SpellCastTargets AIInterface::setSpellTargets(SpellEntry *spellInfo, Unit* target)
{
	SpellCastTargets targets;
	targets.m_unitTarget = 0;
	targets.m_itemTarget = 0;
	targets.m_srcX = 0;
	targets.m_srcY = 0;
	targets.m_srcZ = 0;
	targets.m_destX = 0;
	targets.m_destY = 0;
	targets.m_destZ = 0;

	if(m_nextSpell->spelltargetType == TTYPE_SINGLETARGET)
	{
		targets.m_targetMask = 2;
		targets.m_unitTarget = target->GetGUID();
	}else if(m_nextSpell->spelltargetType == TTYPE_SOURCE)
	{
		targets.m_targetMask = 32;
		targets.m_srcX = m_Unit->GetPositionX();
		targets.m_srcY = m_Unit->GetPositionY();
		targets.m_srcZ = m_Unit->GetPositionZ();
	}else if(m_nextSpell->spelltargetType == TTYPE_DESTINATION)
	{
		targets.m_targetMask = 64;
		targets.m_destX = target->GetPositionX();
		targets.m_destY = target->GetPositionY();
		targets.m_destZ = target->GetPositionZ();
	}

	return targets;
}

AI_Spell *AIInterface::getSpellByEvent(uint32 event)
{
	std::list<AI_Spell*>::iterator i;
	switch(event)
	{
	case EVENT_ENTERCOMBAT:
		{
			if(!m_hasOnEnterCombatSpells) // has Spells for that Event -- used to reduce iterations
				break;
			for(i = m_OnEnterCombatSpells.begin();i != m_OnEnterCombatSpells.end(); i++)
			{
				if((*i)->procCount == 0 || (*i)->procCounter < (*i)->procCount) // procCount for that spell isnt expired yet
				{
					if((*i)->spellCooldownTimer == 0) // there is no Cooldown for that Spell
					{
						if(rand()%100 <= (*i)->procChance) // proc this Spell
						{
							return (*i);
						}
					}
				}
			}
		}break;
	case EVENT_LEAVECOMBAT:
		{
			if(!m_hasOnLeaveCombatSpells) // has Spells for that Event -- used to reduce iterations
				break;
			for(i = m_OnLeaveCombatSpells.begin();i != m_OnLeaveCombatSpells.end(); i++)
			{
				if((*i)->procCount == 0 || (*i)->procCounter < (*i)->procCount) // procCount for that spell isnt expired yet
				{
					if((*i)->spellCooldownTimer == 0) // there is no Cooldown for that Spell
					{
						if(rand()%100 <= (*i)->procChance) // proc this Spell
						{
							return (*i);
						}
					}
				}
			}
		}break;
	case EVENT_DAMAGETAKEN:
		{
			if(!m_hasOnDamageTakenSpells) // has Spells for that Event -- used to reduce iterations
				break;
			for(i = m_OnDamageTakenSpells.begin();i != m_OnDamageTakenSpells.end(); i++)
			{
				if((*i)->procCount == 0 || (*i)->procCounter < (*i)->procCount) // procCount for that spell isnt expired yet
				{
					if((*i)->spellCooldownTimer == 0) // there is no Cooldown for that Spell
					{
						if(rand()%100 <= (*i)->procChance) // proc this Spell
						{
							return (*i);
						}
					}
				}
			}
		}break;
	case EVENT_TARGETCASTSPELL:
		{
			if(!m_hasOnTargetCastSpellSpells) // has Spells for that Event -- used to reduce iterations
				break;
			for(i = m_OnTargetCastSpellSpells.begin();i != m_OnTargetCastSpellSpells.end(); i++)
			{
				if((*i)->procCount == 0 || (*i)->procCounter < (*i)->procCount) // procCount for that spell isnt expired yet
				{
					if((*i)->spellCooldownTimer == 0) // there is no Cooldown for that Spell
					{
						if(rand()%100 <= (*i)->procChance) // proc this Spell
						{
							return (*i);
						}
					}
				}
			}
		}break;
	case EVENT_TARGETPARRYED:
		{
			if(!m_hasOnTargetParryedSpells) // has Spells for that Event -- used to reduce iterations
				break;
			for(i = m_OnTargetParryedSpells.begin();i != m_OnTargetParryedSpells.end(); i++)
			{
				if((*i)->procCount == 0 || (*i)->procCounter < (*i)->procCount) // procCount for that spell isnt expired yet
				{
					if((*i)->spellCooldownTimer == 0) // there is no Cooldown for that Spell
					{
						if(rand()%100 <= (*i)->procChance) // proc this Spell
						{
							return (*i);
						}
					}
				}
			}
		}break;
	case EVENT_TARGETDODGED:
		{
			if(!m_hasOnTargetDodgedSpells) // has Spells for that Event -- used to reduce iterations
				break;
			for(i = m_OnTargetDodgedSpells.begin();i != m_OnTargetDodgedSpells.end(); i++)
			{
				if((*i)->procCount == 0 || (*i)->procCounter < (*i)->procCount) // procCount for that spell isnt expired yet
				{
					if((*i)->spellCooldownTimer == 0) // there is no Cooldown for that Spell
					{
						if(rand()%100 <= (*i)->procChance) // proc this Spell
						{
							return (*i);
						}
					}
				}
			}
		}break;
	case EVENT_TARGETBLOCKED:
		{
			if(!m_hasOnTargetBlockedSpells) // has Spells for that Event -- used to reduce iterations
				break;
			for(i = m_OnTargetBlockedSpells.begin();i != m_OnTargetBlockedSpells.end(); i++)
			{
				if((*i)->procCount == 0 || (*i)->procCounter < (*i)->procCount) // procCount for that spell isnt expired yet
				{
					if((*i)->spellCooldownTimer == 0) // there is no Cooldown for that Spell
					{
						if(rand()%100 <= (*i)->procChance) // proc this Spell
						{
							return (*i);
						}
					}
				}
			}
		}break;
	case EVENT_TARGETCRITHIT:
		{
			if(!m_hasOnTargetCritHitSpells) // has Spells for that Event -- used to reduce iterations
				break;
			for(i = m_OnTargetCritHitSpells.begin();i != m_OnTargetCritHitSpells.end(); i++)
			{
				if((*i)->procCount == 0 || (*i)->procCounter < (*i)->procCount) // procCount for that spell isnt expired yet
				{
					if((*i)->spellCooldownTimer == 0) // there is no Cooldown for that Spell
					{
						if(rand()%100 <= (*i)->procChance) // proc this Spell
						{
							(*i)->spellCooldownTimer = 500;
							return (*i);
						}
					}
				}
			}
		}break;
	case EVENT_TARGETDIED:
		{
			if(!m_hasOnTargetDiedSpells) // has Spells for that Event -- used to reduce iterations
				break;
			for(i = m_OnTargetDiedSpells.begin();i != m_OnTargetDiedSpells.end(); i++)
			{
				if((*i)->procCount == 0 || (*i)->procCounter < (*i)->procCount) // procCount for that spell isnt expired yet
				{
					if((*i)->spellCooldownTimer == 0) // there is no Cooldown for that Spell
					{
						if(rand()%100 <= (*i)->procChance) // proc this Spell
						{
							return (*i);
						}
					}
				}
			}
		}break;
	case EVENT_UNITPARRYED:
		{
			if(!m_hasOnUnitParryedSpells) // has Spells for that Event -- used to reduce iterations
				break;
			for(i = m_OnUnitParryedSpells.begin();i != m_OnUnitParryedSpells.end(); i++)
			{
				if((*i)->procCount == 0 || (*i)->procCounter < (*i)->procCount) // procCount for that spell isnt expired yet
				{
					if((*i)->spellCooldownTimer == 0) // there is no Cooldown for that Spell
					{
						if(rand()%100 <= (*i)->procChance) // proc this Spell
						{
							return (*i);
						}
					}
				}
			}
		}break;
	case EVENT_UNITDODGED:
		{
			if(!m_hasOnUnitDodgedSpells) // has Spells for that Event -- used to reduce iterations
				break;
			for(i = m_OnUnitDodgedSpells.begin();i != m_OnUnitDodgedSpells.end(); i++)
			{
				if((*i)->procCount == 0 || (*i)->procCounter < (*i)->procCount) // procCount for that spell isnt expired yet
				{
					if((*i)->spellCooldownTimer == 0) // there is no Cooldown for that Spell
					{
						if(rand()%100 <= (*i)->procChance) // proc this Spell
						{
							return (*i);
						}
					}
				}
			}
		}break;
	case EVENT_UNITBLOCKED:
		{
			if(!m_hasOnUnitBlockedSpells) // has Spells for that Event -- used to reduce iterations
				break;
			for(i = m_OnUnitBlockedSpells.begin();i != m_OnUnitBlockedSpells.end(); i++)
			{
				if((*i)->procCount == 0 || (*i)->procCounter < (*i)->procCount) // procCount for that spell isnt expired yet
				{
					if((*i)->spellCooldownTimer == 0) // there is no Cooldown for that Spell
					{
						if(rand()%100 <= (*i)->procChance) // proc this Spell
						{
							return (*i);
						}
					}
				}
			}
		}break;
	case EVENT_UNITCRITHIT:
		{
			if(!m_hasOnUnitCritHitSpells) // has Spells for that Event -- used to reduce iterations
				break;
			for(i = m_OnUnitCritHitSpells.begin();i != m_OnUnitCritHitSpells.end(); i++)
			{
				if((*i)->procCount == 0 || (*i)->procCounter < (*i)->procCount) // procCount for that spell isnt expired yet
				{
					if((*i)->spellCooldownTimer == 0) // there is no Cooldown for that Spell
					{
						if(rand()%100 <= (*i)->procChance) // proc this Spell
						{
							return (*i);
						}
					}
				}
			}
		}break;
	case EVENT_UNITDIED:
		{
			if(!m_hasOnUnitDiedSpells) // has Spells for that Event -- used to reduce iterations
				break;
			for(i = m_OnUnitDiedSpells.begin();i != m_OnUnitDiedSpells.end(); i++)
			{
				if((*i)->procCount == 0 || (*i)->procCounter < (*i)->procCount) // procCount for that spell isnt expired yet
				{
					if((*i)->spellCooldownTimer == 0) // there is no Cooldown for that Spell
					{
						if(rand()%100 <= (*i)->procChance) // proc this Spell
						{
							return (*i);
						}
					}
				}
			}
		}break;
	case EVENT_ASSISTTARGETDIED:
		{
			if(!m_hasOnAssistTargetDiedSpells) // has Spells for that Event -- used to reduce iterations
				break;
			for(i = m_OnAssistTargetDiedSpells.begin();i != m_OnAssistTargetDiedSpells.end(); i++)
			{
				if((*i)->procCount == 0 || (*i)->procCounter < (*i)->procCount) // procCount for that spell isnt expired yet
				{
					if((*i)->spellCooldownTimer == 0) // there is no Cooldown for that Spell
					{
						if(rand()%100 <= (*i)->procChance) // proc this Spell
						{
							return (*i);
						}
					}
				}
			}
		}break;
	case EVENT_FOLLOWOWNER:
		{
			if(!m_hasOnFollowOwnerSpells) // has Spells for that Event -- used to reduce iterations
				break;
			for(i = m_OnFollowOwnerSpells.begin();i != m_OnFollowOwnerSpells.end(); i++)
			{
				if((*i)->procCount == 0 || (*i)->procCounter < (*i)->procCount) // procCount for that spell isnt expired yet
				{
					if((*i)->spellCooldownTimer == 0) // there is no Cooldown for that Spell
					{
						if(rand()%100 <= (*i)->procChance) // proc this Spell
						{
							return (*i);
						}
					}
				}
			}
		}break;
	}

	AI_Spell *sp = new AI_Spell;
	sp->agent = AGENT_MELEE;
	return sp;
}

void AIInterface::resetSpellCounter()
{
	std::list<AI_Spell*>::iterator i;
	if(m_hasCooldownOnEnterCombatSpells == true)
	{
		m_hasCooldownOnEnterCombatSpells = false;
		for(i = m_OnEnterCombatSpells.begin();i != m_OnEnterCombatSpells.end(); i++)
		{
			(*i)->spellCooldownTimer = 0;
		}
	}
	if(m_hasCooldownOnLeaveCombatSpells == true)
	{
		m_hasCooldownOnLeaveCombatSpells = false;
		for(i = m_OnLeaveCombatSpells.begin();i != m_OnLeaveCombatSpells.end(); i++)
		{
			(*i)->spellCooldownTimer = 0;
		}
	}
	if(m_hasCooldownOnDamageTakenSpells == true)
	{
		m_hasCooldownOnDamageTakenSpells = false;
		for(i = m_OnDamageTakenSpells.begin();i != m_OnDamageTakenSpells.end(); i++)
		{
			(*i)->spellCooldownTimer = 0;
		}
	}
	if(m_hasCooldownOnTargetCastSpellSpells == true)
	{
		m_hasCooldownOnTargetCastSpellSpells = false;
		for(i = m_OnTargetCastSpellSpells.begin();i != m_OnTargetCastSpellSpells.end(); i++)
		{
			(*i)->spellCooldownTimer = 0;
		}
	}
	if(m_hasCooldownOnTargetParryedSpells == true)
	{
		m_hasCooldownOnTargetParryedSpells = false;
		for(i = m_OnTargetParryedSpells.begin();i != m_OnTargetParryedSpells.end(); i++)
		{
			(*i)->spellCooldownTimer = 0;
		}
	}
	if(m_hasCooldownOnTargetDodgedSpells == true)
	{
		m_hasCooldownOnTargetDodgedSpells = false;
		for(i = m_OnTargetDodgedSpells.begin();i != m_OnTargetDodgedSpells.end(); i++)
		{
			(*i)->spellCooldownTimer = 0;
		}
	}
	if(m_hasCooldownOnTargetBlockedSpells == true)
	{
		m_hasCooldownOnTargetBlockedSpells = false;
		for(i = m_OnTargetBlockedSpells.begin();i != m_OnTargetBlockedSpells.end(); i++)
		{
			(*i)->spellCooldownTimer = 0;
		}
	}
	if(m_hasCooldownOnTargetCritHitSpells == true)
	{
		m_hasCooldownOnTargetCritHitSpells = false;
		for(i = m_OnTargetCritHitSpells.begin();i != m_OnTargetCritHitSpells.end(); i++)
		{
			(*i)->spellCooldownTimer = 0;
		}
	}
	if(m_hasCooldownOnTargetDiedSpells == true)
	{
		m_hasCooldownOnTargetDiedSpells = false;
		for(i = m_OnTargetDiedSpells.begin();i != m_OnTargetDiedSpells.end(); i++)
		{
			(*i)->spellCooldownTimer = 0;
		}
	}
	if(m_hasCooldownOnUnitParryedSpells == true)
	{
		m_hasCooldownOnUnitParryedSpells = false;
		for(i = m_OnUnitParryedSpells.begin();i != m_OnUnitParryedSpells.end(); i++)
		{
			(*i)->spellCooldownTimer = 0;
		}
	}
	if(m_hasCooldownOnUnitDodgedSpells == true)
	{
		m_hasCooldownOnUnitDodgedSpells = false;
		for(i = m_OnUnitDodgedSpells.begin();i != m_OnUnitDodgedSpells.end(); i++)
		{
			(*i)->spellCooldownTimer = 0;
		}
	}
	if(m_hasCooldownOnUnitBlockedSpells == true)
	{
		m_hasCooldownOnUnitBlockedSpells = false;
		for(i = m_OnUnitBlockedSpells.begin();i != m_OnUnitBlockedSpells.end(); i++)
		{
			(*i)->spellCooldownTimer = 0;
		}
	}
	if(m_hasCooldownOnUnitCritHitSpells == true)
	{
		m_hasCooldownOnUnitCritHitSpells = false;
		for(i = m_OnUnitCritHitSpells.begin();i != m_OnUnitCritHitSpells.end(); i++)
		{
			(*i)->spellCooldownTimer = 0;
		}
	}
	if(m_hasCooldownOnUnitDiedSpells == true)
	{
		m_hasCooldownOnUnitDiedSpells = false;
		for(i = m_OnUnitDiedSpells.begin();i != m_OnUnitDiedSpells.end(); i++)
		{
			(*i)->spellCooldownTimer = 0;
		}
	}
	if(m_hasCooldownOnAssistTargetDiedSpells == true)
	{
		m_hasCooldownOnAssistTargetDiedSpells = false;
		for(i = m_OnAssistTargetDiedSpells.begin();i != m_OnAssistTargetDiedSpells.end(); i++)
		{
			(*i)->spellCooldownTimer = 0;
		}
	}
	if(m_hasCooldownOnFollowOwnerSpells == true)
	{
		m_hasCooldownOnFollowOwnerSpells = false;
		for(i = m_OnFollowOwnerSpells.begin();i != m_OnFollowOwnerSpells.end(); i++)
		{
			(*i)->spellCooldownTimer = 0;
		}
	}
}

void AIInterface::increaseProcCounter(uint32 event, AI_Spell *sp)
{
	std::list<AI_Spell*>::iterator i;
	switch(event)
	{
	case EVENT_ENTERCOMBAT:
		{
			for(i = m_OnEnterCombatSpells.begin();i != m_OnEnterCombatSpells.end(); i++)
			{
				if((*i)->spellId == sp->spellId)
				{
					(*i)->spellCooldownTimer = (*i)->spellCooldown;
					if((*i)->spellCooldown > 0)
					{
						m_hasCooldownOnEnterCombatSpells = true;
					}
					(*i)->procCounter++;
				}
			}
		}break;
	case EVENT_LEAVECOMBAT:
		{
			for(i = m_OnLeaveCombatSpells.begin();i != m_OnLeaveCombatSpells.end(); i++)
			{
				if((*i)->spellId == sp->spellId)
				{
					(*i)->spellCooldownTimer = (*i)->spellCooldown;
					if((*i)->spellCooldown > 0)
					{
						m_hasCooldownOnLeaveCombatSpells = true;
					}
					(*i)->procCounter++;
				}
			}
		}break;
	case EVENT_DAMAGETAKEN:
		{
			for(i = m_OnDamageTakenSpells.begin();i != m_OnDamageTakenSpells.end(); i++)
			{
				if((*i)->spellId == sp->spellId)
				{
					(*i)->spellCooldownTimer = (*i)->spellCooldown;
					if((*i)->spellCooldown > 0)
					{
						m_hasCooldownOnDamageTakenSpells = true;
					}
					(*i)->procCounter++;
				}
			}
		}break;
	case EVENT_TARGETCASTSPELL:
		{
			for(i = m_OnTargetCastSpellSpells.begin();i != m_OnTargetCastSpellSpells.end(); i++)
			{
				if((*i)->spellId == sp->spellId)
				{
					(*i)->spellCooldownTimer = (*i)->spellCooldown;
					if((*i)->spellCooldown > 0)
					{
						m_hasCooldownOnTargetCastSpellSpells = true;
					}
					(*i)->procCounter++;
				}
			}
		}break;
	case EVENT_TARGETPARRYED:
		{
			for(i = m_OnTargetParryedSpells.begin();i != m_OnTargetParryedSpells.end(); i++)
			{
				if((*i)->spellId == sp->spellId)
				{
					(*i)->spellCooldownTimer = (*i)->spellCooldown;
					if((*i)->spellCooldown > 0)
					{
						m_hasCooldownOnTargetParryedSpells = true;
					}
					(*i)->procCounter++;
				}
			}
		}break;
	case EVENT_TARGETDODGED:
		{
			for(i = m_OnTargetDodgedSpells.begin();i != m_OnTargetDodgedSpells.end(); i++)
			{
				if((*i)->spellId == sp->spellId)
				{
					(*i)->spellCooldownTimer = (*i)->spellCooldown;
					if((*i)->spellCooldown > 0)
					{
						m_hasCooldownOnTargetDodgedSpells = true;
					}
					(*i)->procCounter++;
				}
			}
		}break;
	case EVENT_TARGETBLOCKED:
		{
			for(i = m_OnTargetBlockedSpells.begin();i != m_OnTargetBlockedSpells.end(); i++)
			{
				if((*i)->spellId == sp->spellId)
				{
					(*i)->spellCooldownTimer = (*i)->spellCooldown;
					if((*i)->spellCooldown > 0)
					{
						m_hasCooldownOnTargetBlockedSpells = true;
					}
					(*i)->procCounter++;
				}
			}
		}break;
	case EVENT_TARGETCRITHIT:
		{
			for(i = m_OnTargetCritHitSpells.begin();i != m_OnTargetCritHitSpells.end(); i++)
			{
				if((*i)->spellId == sp->spellId)
				{
					(*i)->spellCooldownTimer = (*i)->spellCooldown;
					if((*i)->spellCooldown > 0)
					{
						m_hasCooldownOnTargetCritHitSpells = true;
					}
					(*i)->procCounter++;
				}
			}
		}break;
	case EVENT_TARGETDIED:
		{
			for(i = m_OnTargetDiedSpells.begin();i != m_OnTargetDiedSpells.end(); i++)
			{
				if((*i)->spellId == sp->spellId)
				{
					(*i)->spellCooldownTimer = (*i)->spellCooldown;
					if((*i)->spellCooldown > 0)
					{
						m_hasCooldownOnTargetDiedSpells = true;
					}
					(*i)->procCounter++;
				}
			}
		}break;
	case EVENT_UNITPARRYED:
		{
			for(i = m_OnUnitParryedSpells.begin();i != m_OnUnitParryedSpells.end(); i++)
			{
				if((*i)->spellId == sp->spellId)
				{
					(*i)->spellCooldownTimer = (*i)->spellCooldown;
					if((*i)->spellCooldown > 0)
					{
						m_hasCooldownOnUnitParryedSpells = true;
					}
					(*i)->procCounter++;
				}
			}
		}break;
	case EVENT_UNITDODGED:
		{
			for(i = m_OnUnitDodgedSpells.begin();i != m_OnUnitDodgedSpells.end(); i++)
			{
				if((*i)->spellId == sp->spellId)
				{
					(*i)->spellCooldownTimer = (*i)->spellCooldown;
					if((*i)->spellCooldown > 0)
					{
						m_hasCooldownOnUnitDodgedSpells = true;
					}
					(*i)->procCounter++;
				}
			}
		}break;
	case EVENT_UNITBLOCKED:
		{
			for(i = m_OnUnitBlockedSpells.begin();i != m_OnUnitBlockedSpells.end(); i++)
			{
				if((*i)->spellId == sp->spellId)
				{
					(*i)->spellCooldownTimer = (*i)->spellCooldown;
					if((*i)->spellCooldown > 0)
					{
						m_hasCooldownOnUnitBlockedSpells = true;
					}
					(*i)->procCounter++;
				}
			}
		}break;
	case EVENT_UNITCRITHIT:
		{
			for(i = m_OnUnitCritHitSpells.begin();i != m_OnUnitCritHitSpells.end(); i++)
			{
				if((*i)->spellId == sp->spellId)
				{
					(*i)->spellCooldownTimer = (*i)->spellCooldown;
					if((*i)->spellCooldown > 0)
					{
						m_hasCooldownOnUnitCritHitSpells = true;
					}
					(*i)->procCounter++;
				}
			}
		}break;
	case EVENT_UNITDIED:
		{
			for(i = m_OnUnitDiedSpells.begin();i != m_OnUnitDiedSpells.end(); i++)
			{
				if((*i)->spellId == sp->spellId)
				{
					(*i)->spellCooldownTimer = (*i)->spellCooldown;
					if((*i)->spellCooldown > 0)
					{
						m_hasCooldownOnUnitDiedSpells = true;
					}
					(*i)->procCounter++;
				}
			}
		}break;
	case EVENT_ASSISTTARGETDIED:
		{
			for(i = m_OnAssistTargetDiedSpells.begin();i != m_OnAssistTargetDiedSpells.end(); i++)
			{
				if((*i)->spellId == sp->spellId)
				{
					(*i)->spellCooldownTimer = (*i)->spellCooldown;
					if((*i)->spellCooldown > 0)
					{
						m_hasCooldownOnAssistTargetDiedSpells = true;
					}
					(*i)->procCounter++;
				}
			}
		}break;
	case EVENT_FOLLOWOWNER:
		{
			for(i = m_OnFollowOwnerSpells.begin();i != m_OnFollowOwnerSpells.end(); i++)
			{
				if((*i)->spellId == sp->spellId)
				{
					(*i)->spellCooldownTimer = (*i)->spellCooldown;
					if((*i)->spellCooldown > 0)
					{
						m_hasCooldownOnFollowOwnerSpells = true;
					}
					(*i)->procCounter++;
				}
			}
		}break;
	}
}

void AIInterface::addSpellToList(AI_Spell *sp)
{
	switch(sp->procEvent)
	{
	case EVENT_ENTERCOMBAT:
		{
			m_OnEnterCombatSpells.push_back(sp);
			m_hasOnEnterCombatSpells = true;
		}break;
	case EVENT_LEAVECOMBAT:
		{
			m_OnLeaveCombatSpells.push_back(sp);
			m_hasOnLeaveCombatSpells = true;
		}break;
	case EVENT_DAMAGETAKEN:
		{
			m_OnDamageTakenSpells.push_back(sp);
			m_hasOnDamageTakenSpells = true;
		}break;
	case EVENT_TARGETCASTSPELL:
		{
			m_OnTargetCastSpellSpells.push_back(sp);
			m_hasOnTargetCastSpellSpells = true;
		}break;
	case EVENT_TARGETPARRYED:
		{
			m_OnTargetParryedSpells.push_back(sp);
			m_hasOnTargetParryedSpells = true;
		}break;
	case EVENT_TARGETDODGED:
		{
			m_OnTargetDodgedSpells.push_back(sp);
			m_hasOnTargetDodgedSpells = true;
		}break;
	case EVENT_TARGETBLOCKED:
		{
			m_OnTargetBlockedSpells.push_back(sp);
			m_hasOnTargetBlockedSpells = true;
		}break;
	case EVENT_TARGETCRITHIT:
		{
			m_OnTargetCritHitSpells.push_back(sp);
			m_hasOnTargetCritHitSpells = true;
		}break;
	case EVENT_TARGETDIED:
		{
			m_OnTargetDiedSpells.push_back(sp);
			m_hasOnTargetDiedSpells = true;
		}break;
	case EVENT_UNITPARRYED:
		{
			m_OnUnitParryedSpells.push_back(sp);
			m_hasOnUnitParryedSpells = true;
		}break;
	case EVENT_UNITDODGED:
		{
			m_OnUnitDodgedSpells.push_back(sp);
			m_hasOnUnitDodgedSpells = true;
		}break;
	case EVENT_UNITBLOCKED:
		{
			m_OnUnitBlockedSpells.push_back(sp);
			m_hasOnUnitBlockedSpells = true;
		}break;
	case EVENT_UNITCRITHIT:
		{
			m_OnUnitCritHitSpells.push_back(sp);
			m_hasOnUnitCritHitSpells = true;
		}break;
	case EVENT_UNITDIED:
		{
			m_OnUnitDiedSpells.push_back(sp);
			m_hasOnUnitDiedSpells = true;
		}break;
	case EVENT_ASSISTTARGETDIED:
		{
			m_OnAssistTargetDiedSpells.push_back(sp);
			m_hasOnAssistTargetDiedSpells = true;
		}break;
	case EVENT_FOLLOWOWNER:
		{
			m_OnFollowOwnerSpells.push_back(sp);
			m_hasOnFollowOwnerSpells = true;
		}break;
	}
}

uint32 AIInterface::getThreatByGUID(uint64 guid)
{
	std::list<AI_Target>::iterator i;
	for(i = m_aiTargets.begin(); i != m_aiTargets.end(); i++)
	{
		if(i->target->GetGUID() == guid)
			return i->threat;
	}
	return 0;
}

bool AIInterface::modThreatByGUID(uint64 guid, int32 mod)
{
	std::list<AI_Target>::iterator i;
	for(i = m_aiTargets.begin(); i != m_aiTargets.end(); i++)
	{
		if(i->target->GetGUID() == guid)
		{
			i->threat += mod;
			return true;
		}
	}
	return false;
}

bool AIInterface::checkFaction(Unit* objA, Unit* objB, uint8 type)
{
	if(!objA || !objB)
		return false;

	uint32 myFaction = objB->myFaction;

	if(type == 0)// B is hostile for A?
	{
		uint32 hostile = objA->hostile;

		if(myFaction & hostile)
			return true;
	}else if(type == 1)// A combat supports B?
	{
		uint32 fSupport = objA->combatSupport;

		if(myFaction & fSupport)
			return true;
	}
	return false;
}

void AIInterface::addAssistTargets(Unit* Friend)
{
	m_assistTargets.push_back(Friend);
}

void AIInterface::_SendLuaEvent(WOWD_SCRIPTEVENT event)
{
	if(!m_engine)
		return;
	m_engine->addSupportForEntry(m_Unit->GetUInt32Value(OBJECT_FIELD_ENTRY));
	m_engine->handleEvent(this->m_Unit,this->m_Unit->GetUInt32Value(OBJECT_FIELD_ENTRY), event);
}

void AIInterface::WipeHateList()
{
	std::list<AI_Target>::iterator itr;
	for(itr = m_aiTargets.begin(); itr != m_aiTargets.end(); itr++)
	{
		itr->threat = 0;
	}
}

void AIInterface::WipeTargetList()
{
	m_nextTarget = NULL;
	m_nextSpell = NULL;
	m_aiTargets.clear();
}
