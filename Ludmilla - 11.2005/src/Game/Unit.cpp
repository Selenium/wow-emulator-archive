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

#define DEG2RAD (M_PI/180.0)
#define M_PI       3.14159265358979323846

//-----------------------------------------------------------------------------
Unit::Unit() : Object()
{
    m_objectType |= TYPE_UNIT;
    m_objectTypeId = TYPEID_UNIT;

    m_attackTimer = 0;

    m_state = 0;
    m_deathState = ALIVE;
    m_currentSpell = NULL;
    m_meleeSpell = false;
    
	m_addDmgOnce = 0;
	m_addDmgOnceSpell = 0;
	m_amplifyDmgOnce = 0.0f;
	m_amplifyDmgOnceSpell = 0;

    m_TotemSlot1 = m_TotemSlot2 = m_TotemSlot3 = m_TotemSlot4  = 0;
    m_aura = NULL;
    m_auraCheck = AURA_CHECK_EVERY_MSEC;
    tmpAffect = NULL;
    m_silenced = false;

	m_critChance = 0;
	m_critRangedChance = 0;
	m_dodgeChance = 0;
	m_parryChance = 0;
	m_blockChance = 0;
	m_minDamage = m_maxDamage = 0;
	m_blockValue = 0;

	m_nextThink = 0;
	m_nextThinkParam = 0;
	m_speedMod = 1.0f;
	m_tagger = NULL;	// who first attacked

	m_stealthLevel = 0;
	m_stealthDetectBonus = 0;
}

//-----------------------------------------------------------------------------
Unit::~Unit()
{
}

//-----------------------------------------------------------------------------
void Unit::Update( int32 p_time )
{
	_UpdateSpells (p_time);

    if (m_attackTimer > 0)
    {
        if (p_time >= m_attackTimer)
            m_attackTimer = 0;
        else
            m_attackTimer -= p_time;
    }
	
	if (m_nextThink > p_time)
		m_nextThink -= p_time;
	else
	{
		if (m_nextThink)
		{
			m_nextThink = 0;
			Call_Unit_OnThink (this, m_nextThinkParam);
		}
	}
}

//-----------------------------------------------------------------------------
void Unit::setAttackTimer()
{
    m_attackTimer = GetUInt32Value(UNIT_FIELD_BASEATTACKTIME);
}

//-----------------------------------------------------------------------------
bool Unit::CanReachWithAttack (Unit *pVictim)
{
    float attackRadius = min (GetFloatValue(UNIT_FIELD_COMBATREACH), 1.0f) +
						 min (GetFloatValue(UNIT_FIELD_BOUNDINGRADIUS), 0.5f) + 2.5f;

    if (GetDistanceSq (pVictim) > attackRadius * attackRadius)
        return false;

    return true;
}

//-----------------------------------------------------------------------------
void Unit::UnitDeath (Unit *pKiller, bool isCritterVictim)
{
	if (GetUInt64Value(UNIT_FIELD_SUMMONEDBY) != 0)
	{
		isCritterVictim = true;
	}

	// Critters generate no loot
	if (GetTypeId() == TYPEID_UNIT)
	{
		if (! isCritterVictim)
			((Creature*)this)->GenerateLoot();
		else
			((Creature*)this)->SetEmptyLoot (0);
	}


	// FIXME: should we remove all equipment affects too
	//        if(pVictim->GetTypeId() == TYPEID_PLAYER)
	//            _RemoveAllItemMods();

	RemoveAllAffects();
	SetUInt32Value (UNIT_FIELD_BYTES_1, 0);	// unstealth and undo other effects

	// victim died!
	setDeathState(JUST_DIED);

	ClearHate();
	SetUInt64Value (UNIT_FIELD_TARGET, 0);
	pKiller->SetUInt64Value (UNIT_FIELD_TARGET, 0);

	// Send SMSG_PARTYKILLLOG 0x1e6
	// To everyone in the party?

	// SMSG_ATTACKSTOP
	uint64 attackerGuid, victimGuid;
	attackerGuid = pKiller->GetGUID();
	victimGuid = GetGUID();

	smsg_AttackStop (attackerGuid);

	// Send MSG_MOVE_ROOT   0xe7

	// Set update values... try flags 917504
	// health
	//pVictim->SetUInt32Value(UNIT_FIELD_HEALTH, 0);

	// then another update message, sets health to 0, maxhealth to 100, and dynamic flags
	SetHealth (0);
	RemoveFlag(UNIT_FIELD_FLAGS, 0x00080000);

	// If killer was player - then he receives all bonuses
	if (pKiller->isPlayer())
	{
		// Reset combo target and combo points for rogues and roguish druids
		if (pKiller->GetPowerIndex() == POWER_TYPE_ENERGY)
		{
			pKiller->SetUInt64Value (PLAYER__FIELD_COMBO_TARGET, 0);
			//SetUInt32Value (PLAYER_FIELD_BYTES, GetUInt32Value (PLAYER_FIELD_BYTES) & ~(0xFF << 8));
			pKiller->SetComboPoints (0);
		}

		// Critters give no XP
		uint32 xp = isCritterVictim ? 0 : CalculateXpToGive(this, pKiller);

		// Activation of Reputation module in Functions.py
		Call_CalcReputation(pKiller, this);

		//-----------------------------------------------
		// Check initial tagger, who damaged first - gets
		// creature tag and awarded with XP and loot
		//-----------------------------------------------
		Unit * tagger = GetTagger();
		SetTagger (NULL);

		if (GetTagger() != NULL && pKiller->GetGUID() != GetTagger()->GetGUID())
		{
			Log::getSingleton().outDebug ("Killer GUID=%X is not an initial tagger GUID=%X "\
				"- Trying to pass XP to tagger", GetGUID(), tagger);
			pKiller = GetTagger();
		}

		// check running quests in case this monster belongs to it
		uint32 entry = 0;
		if (isPlayer())
		{
			//calculation of honor
			//if (pKiller->isAlliance() != pVictim->isAlliance )
			//pKiller->SetUInt32Value(PLAYER_FIELD_SESSION_KILLS, pKiller->GetUInt32Value(PLAYER_FIELD_SESSION_KILLS)+1);
			
			/*
			uint16 honorableKills = (uint16)(GetUInt32Value(PLAYER_FIELD_SESSION_KILLS));
			uint16 unhonorableKills = (uint16)((GetUInt32Value(PLAYER_FIELD_SESSION_KILLS) - honorableKills) / 65536);

			if ((pKiller->GetLevel() - GetLevel() ) >= 5 )
			{
				pKiller->SetUInt32Value(PLAYER_FIELD_SESSION_KILLS, (uint32)(honorableKills + ((unhonorableKills + 1) * 65536)) );
				pKiller->SetUInt32Value(PLAYER_FIELD_LIFETIME_DISHONORBALE_KILLS, pKiller->GetUInt32Value(PLAYER_FIELD_LIFETIME_DISHONORBALE_KILLS) + 1);
			}
			else
			{
				pKiller->SetUInt32Value(PLAYER_FIELD_SESSION_KILLS, (uint32)(honorableKills + 1 + ((unhonorableKills) * 65536)));
				pKiller->SetUInt32Value(PLAYER_FIELD_LIFETIME_HONORBALE_KILLS, pKiller->GetUInt32Value(PLAYER_FIELD_LIFETIME_HONORBALE_KILLS) + 1);
			}
			*/

			// HONOR SYSTEM (Python, executables.py)
			Call_CalcHonor (pKiller, this);

			((Player*)pKiller)->m_PVP_timer = 300000;
			if (!((Player*)pKiller)->HasFlag(UNIT_FIELD_FLAGS, UNIT_FLAG_WAR_PLAYER))
				((Player*)pKiller)->SetFlag(UNIT_FIELD_FLAGS, UNIT_FLAG_WAR_PLAYER);
			
		}
		else
		{
			entry = GetEntry();
		}

		// Is this player part of a group?
		Group *pGroup = objmgr.GetGroupByLeader(((Player*)pKiller)->GetGroupLeader());
		if (pGroup)
		{
			xp /= pGroup->GetMembersCount();
			for (uint32 i = 0; i < pGroup->GetMembersCount(); i++)
			{
				Player *pGroupGuy = objmgr.GetObject<Player>(pGroup->GetMemberGUID(i));
				pGroupGuy->GiveXP(xp, victimGuid);

				if (isNotPlayer())
					pGroupGuy->KilledMonster(entry, GetGUID());
			}
		}
		else
		{
			// update experience
			((Player*)pKiller)->GiveXP (xp, victimGuid);

			if (isNotPlayer())
				((Player*)pKiller)->KilledMonster(entry, victimGuid);
		}
	}
	else
	{
		smsg_AttackStop (victimGuid);
		RemoveFlag (UNIT_FIELD_FLAGS, 0x00080000);
		addStateFlag (UF_TARGET_DIED);
	}
}

//-----------------------------------------------------------------------------
//  Important function: Deals some damage to creature or player, checks death
//  condition, and processes rage regeneration, looting from creatures,
//  death for players, experience and PvP scoring for player kill.
//-----------------------------------------------------------------------------
void Unit::DealDamage(Unit *pVictim, uint32 damage)
{
	//----- Damage Reduction ---------------
	if (isUnit() && pVictim->isPlayer())
		damage = damage - CalcDamageReduction(pVictim, (Creature*)this);
	
	//----- Rage calculations --------------
	if (GetPowerIndex() == POWER_TYPE_RAGE)
	{
		int addRage = (damage * 10) / (GetLevel());	// maxrage = 1000 not 100!
		SetRage (min (GetMaxRage(), GetRage() + addRage));
	}
	if (pVictim->GetPowerIndex() == POWER_TYPE_RAGE)
	{
		int addRage = (damage * 10) / (2 * GetLevel());	// maxrage = 1000 not 100!
		SetRage (min (GetMaxRage(), GetRage() + addRage));
	}

	// If there was invisibility affect - go remove it
	if (m_stealthLevel > 0)
		LoseStealth();

	//----- Now health calculations --------
    uint32 health = pVictim->GetUInt32Value (UNIT_FIELD_HEALTH);

	// Kill critters in one hit!
	bool isCritterVictim = false;
	if (pVictim->GetTypeId() == TYPEID_UNIT) 
	{
		Creature * cVictim = (Creature *)pVictim;
		if (cVictim->GetCreatureTemplate()->Type == CREATURE_TYPE_CRITTER)
			isCritterVictim = true;
	}
	
	if (health <= damage || isCritterVictim)
	{
		pVictim->UnitDeath (this, isCritterVictim);
	}
	else
	{
		// this need alot of work.
		if (pVictim->isNotPlayer())
		{
			Creature *crVictim = ((Creature*)pVictim);

			// call OnAttacked only once
			int vstate = crVictim->AI_GetState();
			if ( crVictim->isInCombat() == false )
				Call_Unit_OnAttacked ((Unit *)pVictim, (Unit *)this);
			
			// ignore damage when fleeing
			if ( ! crVictim->isFleeing() )
			{
				pVictim->AddHate (this, (float)max (1, damage));
				//Log::getSingleton( ).outDetail("Attacking back");
				//crVictim->LookAt (this);
				//crVictim->AI_AttackReaction(this, (float)damage);
			}
		} 
		else
		{
			if (isPlayer())
			{
				((Player*)this)->m_PVP_timer = 300000;
				if (!((Player*)this)->HasFlag(UNIT_FIELD_FLAGS, UNIT_FLAG_WAR_PLAYER))
					((Player*)this)->SetFlag(UNIT_FIELD_FLAGS, UNIT_FLAG_WAR_PLAYER);
			}

			if (m_meleeSpell != 0 && pVictim->m_currentSpell != NULL)
			{
				WorldPacket data;
				data.Initialize (SMSG_SPELL_DELAYED);
				data << pVictim->GetGUID();
				data << uint32 (1000);
				((Player*)pVictim)->GetSession()->SendPacket (&data);
			}
		}

		if(pVictim->m_currentSpell != NULL)
		{
			pVictim->m_currentSpell->DelaySpell (1000);
		}

		pVictim->SetHealth (health - damage);
		pVictim->OnTakeDamage (this);
	}
}

//-----------------------------------------------------------------------------
void Unit::TakeDamage (uint32 damage)
{
	// TakeDamage calls with environmental and DoT damages, first is correct to have
	// self as killer. Second is wrong, server should always know who applied DoT and
	// killed victim, thus calling this function no more, and using DealDamage or
	// SpellNonMeleeDamageLog <-- FIXME.

	uint32 health = GetUInt32Value(UNIT_FIELD_HEALTH );
	
	if (health <= damage) {
		UnitDeath (this, false);
	} else {
		SetUInt32Value(UNIT_FIELD_HEALTH , health - damage);
		OnTakeDamage (NULL);
	}
}

//================================================================================================
//  AttackerStateUpdate
//  This function determines whether there is a hit, and the resultant damage
//================================================================================================
void Unit::SpellNonMeleeDamageLog(Unit *pVictim, uint32 spellID, uint32 damage)
{
    if(!this || !pVictim)
        return;
    if(!this->isAlive() || !pVictim->isAlive())
        return;
    Log::getSingleton( ).outDetail("AttackerStateUpdate: %u %X attacked %u %X for %u dmg infliced by %u",
        GetGUIDLow(), GetGUIDHigh(), pVictim->GetGUIDLow(), pVictim->GetGUIDHigh(), damage, spellID);
    WorldPacket data;
    data.Initialize(SMSG_SPELLNONMELEEDAMAGELOG);

    data << pVictim->GetGUID();  // 1 64
    data << this->GetGUID();	 // 2 64 
    data << spellID;			 // 4 32
    data << damage;				 // 5 32
    data << uint32(0);			 // 6 32
    data << uint32(0);			 // 7 32
    data << uint32(0);			 // 8 32 
    data << uint32(0);			 // 9 32  - Something goes here
	data << uint32(0);			 // 10 32 
    SendMessageToSet(&data,true);
    DealDamage(pVictim, damage);
}

//-----------------------------------------------------------------------------
void Unit::PeriodicAuraLog(Unit *pVictim, uint32 spellID, uint32 damage, uint32 damageType)
{
    if(!this || !pVictim)
        return;
    if(!this->isAlive() || !pVictim->isAlive())
        return;
    Log::getSingleton( ).outDetail("PeriodicAuraLog: %u %X attacked %u %X for %u dmg infliced by %u",
        GetGUIDLow(), GetGUIDHigh(), pVictim->GetGUIDLow(), pVictim->GetGUIDHigh(), damage, spellID);

    WorldPacket data;
    data.Initialize(SMSG_PERIODICAURALOG);
    data << pVictim->GetGUID();
    data << this->GetGUID();
    data << spellID;
    data << uint32(1);  // Target Count ?
    //data << damageType;
    data << damage;
    data << uint32(5);
    data << uint32(0);
    SendMessageToSet(&data,true);

    DealDamage(pVictim, damage);
}

//-----------------------------------------------------------------------------
void Unit::AttackerStateUpdate (Unit *pVictim, uint32 damage, bool DoT)
{
    uint32 spell = 0;

	// Can't attack while dead
	if (pVictim->isDead()) return;
	// Can't attack while casting long spell
	if ((m_currentSpell != NULL) && !m_meleeSpell) return;
	// Can't attack while stunned
	if (isStunned()) return;

    WorldPacket data;
	
	// 0x22 - bright hit splash
    uint32 hit_status = 0x22;
    
	uint32 damageType = 0;
	uint32 additionalSpellId = 0;	// CalculateDamage or other function sets this to additional spell Id
	uint32 additionalSpellDmg = 0;
	uint32 damage_blocked = 0;

    if(damage == 0) damage = CalculateDamage (additionalSpellId, additionalSpellDmg);
			   else damageType = 1;	

    if(DoT) hit_status = 0;

    if(m_meleeSpell == true)// if we are currently casting a melee spell then finish it now
    {
        if(m_currentSpell != NULL && m_currentSpell->getState() == SPELL_STATE_IDLE){
            spell = m_currentSpell->m_spellInfo->Id;
            m_currentSpell->SendCastResult(0);
            m_currentSpell->SendSpellGo();
            for(uint32 i=0;i<2;i++)
                m_currentSpell->HandleEffects(m_currentSpell->m_targets.m_unitTarget,i);
            m_currentSpell->finish();
        }
    }

	//--------------------------------------------------
	// Chances to hit, to crit, to parry and to block
	//--------------------------------------------------
	uint32	victim_state = 1;

	//uint32	myLvl = GetLevel(),
	//		victimLvl = pVictim->GetLevel();
	int32	mySkill = GetCurrentMeleeSkill(),
			victimSkill = pVictim->GetCurrentMeleeSkill();

	// here we get skill level for current weapon and compare to victim level
	float	chanceToHit = 100.0f;
	

	// if my skill lower, reduce chance and damage
	// Works only for Player vs. Environment, else chance always 100%
	// ---------------------------------------------------------------------------------
	if (isPlayer() && pVictim->isUnit())
	{
		if (mySkill <= victimSkill - 30) {	// 30 = 6 levels difference
			chanceToHit = 0;
		} else {
			if (mySkill <= victimSkill)
			{
				chanceToHit = 100.0f - (victimSkill - mySkill) * (100.0f / 30.0f);
			}
		}
		if (chanceToHit < 15.0f) chanceToHit = 15.0f; // lower cap on CTH
	}


	// In case we just miss
	// ---------------------------------------------------------------------------------
	if (chanceToHit * 655.36f >= (uint16)randomMT())
	{
		// in case we hit but our skill is lower, we reduce damage to
		// 30% for -4 levels and down and to 60% for -2 levels
		// works only for player against monster
		if (isPlayer() && pVictim->isUnit())
		{
			if (mySkill < victimSkill - 20) damage = (damage * 30) / 100;
			else
				if (mySkill < victimSkill - 10) damage = (damage * 60) / 100;
		}
	} else {
		// No chance to hit = miss
		//hit_status = 0x20;
		damage = 0;
	}


	// When we have DAMAGE
	// ---------------------------------------------------------------------------------
	if (damage)
	{
		// -- CRIT -------------------------------------------------------------------------------
		// Here we calculate crit chance for attacker
		if (GetCritChance() * 655.36f >= (uint16)randomMT())
		{
			hit_status = 0xEA;
			damage *= 2;
			//damageType = 1;

            pVictim->Emote(EMOTE_ONESHOT_WOUNDCRITICAL); // Animation

		}
		// -- PARRY -------------------------------------------------------------------------------
		// Here we calculate parry chance for victim
		if (pVictim->GetParryChance() * 655.36f >= (uint16)randomMT())
		{
			//hit_status = 0x20;
			damage = 0;
			victim_state = 2;

			Emote(EMOTE_ONESHOT_PARRYUNARMED);			// Animation
		}
		// -- DODGE -------------------------------------------------------------------------------
		// Here we calculate dodge chance for victim
		if (pVictim->GetDodgeChance() * 655.36f >= (uint16)randomMT())
		{
			//hit_status = 0x20;
			damage = 0;
			victim_state = 3;

			Emote(EMOTE_ONESHOT_PARRYUNARMED);			// Animation

		}
		// -- BLOCK -------------------------------------------------------------------------------
		// Here we calculate block chance for victim
		if (pVictim->GetBlockChance() * 655.36f >= (uint16)randomMT())  //  && pVictim->GetBlockValue()
		{
			//hit_status = 0x20;

			/*
			The ability of a shield to absorb melee damage in addition to its armor value. 
			When a shield is equipped, it has a certain chance to perform a block; shield-bearing 
			classes usually have a talent that improves this chance, sometimes the shield itself 
			improves the block chance. When a shield actually blocks, the shield's block value, 
			modified by the player's strength, is subtracted from the melee damage. 
			*/
			
			damage_blocked = (pVictim->GetBlockValue() * (pVictim->GetStrength() / 10));   // I used 10 as Devider (have no idea what value shall be)
			
			if (damage_blocked < damage) {damage = damage - damage_blocked;}
			else damage = 0;

			if (pVictim->isPlayer() && pVictim->GetBlockValue()) Emote(EMOTE_ONESHOT_PARRYSHIELD);  // Animation
			if (pVictim->isPlayer() && pVictim->GetBlockValue() == 0) Emote(EMOTE_ONESHOT_PARRYUNARMED);  // Animation

			victim_state = 4;
		}
		// ---------------------------------------------------------------------------------
	}
	
	// ---------------------------------------------------------------------------------
	if (additionalSpellId && additionalSpellDmg)
	{
		SpellNonMeleeDamageLog (pVictim, additionalSpellId, additionalSpellDmg);
		return;
		
		//additionalSpellDmg = 0;
		//damageType = 1;			// spell damage
		//damage = 0;
		hit_status = 0x250E2;	// strange hit status here
		//hit_status = 0x22;
		//victim_state = 0;
	}

	//--------------------------------------------------
	// hit_status = 0xEA - CRIT; 0xE2 - Normal (miss in 1.7.1?); 0x22...
	// 0x02 ?- Normal
	//
	// 0x02 = victim_round_duration xFFFFFFFF - victim's turn
	// 0x20 = normal damage done
	// 0xE2 = normal damage done?
	// 0xEA,EE = critical hit
	//
	// victim_round_duration = 0 - attacker hits, FFFFFFFF - victim hits back
	//
	// ???		- victim_state = 0, hit_status = 0x01
	// ABSORB	- victim_state = 1, damage_absorbed = damage
	// PARRY	- victim_state = 2, damage = 0
	// DODGE	- victim_state = 3, damage = 0
	// BLOCK	- victim_state = 4, damage = 0
	// IMMUNE	- victim_state = 5, damage = 0
	// DEFLECT	- victim_state = 6, damage = 0
	// MISS		- damage = 0
	// WEAPON PROC - Add Spell Damage = damage, Add Spell Id = 0x2378 - Hamstring
	// BLOCK    damage = damage - amount blocked
	// ?? CRITICAL - Total damage = uint32 damage + Add spell damage, Add spell id = 0

    uint32 some_value = 0xffffffff;
    some_value = 0x0;

    data.Initialize(SMSG_ATTACKERSTATEUPDATE);
    data << (uint32)hit_status;   // Attack flags
    data << GetGUID();
    data << pVictim->GetGUID();
    data << (uint32)damage;

    data << (uint8)1;					// Damage type counter

    // for each...
    data << damageType;					// Damage type, // 0 - white font, 1 - yellow
    data << (float)damage;				// damage float
    data << (uint32)damage;				// Damage amount
    data << (uint32)0;					// damage absorbed

	data << (uint32)0;					// some unknown field new in 1.7
    data << (uint32)victim_state;		// new victim state
	//data << (uint32)0;				// victim round duration
    
	data << (uint32)additionalSpellDmg;	// additional spell damage amount
    data << (uint32)additionalSpellId;	// additional spell damage id
    data << (uint32)damage_blocked;		// Damage amount blocked

    WPAssert(data.size() == 61);
    SendMessageToSet(&data, true);

    //Log::getSingleton( ).outDetail("AttackerStateUpdate: %u %X attacked %u %X for %u dmg.",
    //    GetGUIDLow(), GetGUIDHigh(), pVictim->GetGUIDLow(), pVictim->GetGUIDHigh(), damage);

    DealDamage(pVictim, damage);
}

//-----------------------------------------------------------------------------
void Unit::smsg_AttackStop(uint64 victimGuid)
{
    WorldPacket data;
    data.Initialize( SMSG_ATTACKSTOP );
    data << GetGUID();
    data << victimGuid;
    data << uint32( 0 );
    SendMessageToSet(&data, true);
	Log::getSingleton( ).outDebug( "WORLD: SMSG_ATTACKSTOP" );
    Log::getSingleton( ).outDetail("%u %X stopped attacking "I64FMT,
        GetGUIDLow(), GetGUIDHigh(), victimGuid);
}

//-----------------------------------------------------------------------------
void Unit::smsg_AttackStart(Unit* pVictim)
{
    // Prevent user from ignoring attack speed and stopping and start combat really really fast
    //todo: check "isInFront" also
    if (isAttackReady() && CanReachWithAttack(pVictim))
    {
        AttackerStateUpdate(pVictim,0,false);
        setAttackTimer();
    }

    // Send out ATTACKSTART
    WorldPacket data;
    data.Initialize( SMSG_ATTACKSTART );
    data << GetGUID();
    data << pVictim->GetGUID();
    SendMessageToSet(&data, true);
    Log::getSingleton( ).outDebug( "WORLD: SMSG_ATTACKSTART" );
}

//-----------------------------------------------------------------------------
bool Unit::AddAffect(Affect *aff, bool uniq)
{
    AffectList::const_iterator i;

    Log::getSingleton().outDetail("Unit::AddAffect() - adding affect");

    for (i = m_affects.begin(); i != m_affects.end(); i++)
    {
        if ((uniq || (*i)->GetCasterGUID() == aff->GetCasterGUID()) && (*i)->IsSameClassAffect (aff))
        {
            break;
        }
    }

    if (i != m_affects.end())
    {
        if(i != 0)
            (*i)->SetDuration(0);
        Log::getSingleton().outDetail("Unit::AddAffect() - overwriting Affect");
    }

    m_affects.push_back(aff);

    for (Affect::ModList::const_iterator j = aff->GetModList().begin();
        j != aff->GetModList().end(); j++)
    {
        ApplyModifier(&(*j), true, aff);
    }

    _AddAura(aff);

    Log::getSingleton().outDetail("Unit::AddAffect() - affect added");

    return true;
}

//-----------------------------------------------------------------------------
void Unit::RemoveAffect(Affect *aff)
{
    printf("Remove Affect: ");
    printf("%u\n",aff->GetId());
    AffectList::iterator i;

    for (i = m_affects.begin(); i != m_affects.end(); i++) {
        if (*i == aff)
            break;
    }

    //ASSERT(i != m_affects.end());
	// WARN! Potential "lost" spell affect bug is here, when affect not found
	// in list and not removed, while spell effect was actually active

	if(aff->GetCoAffect() != 0)
		RemoveAffect(aff->GetCoAffect());

	for (Affect::ModList::const_iterator j = aff->GetModList().begin();
		j != aff->GetModList().end(); j++)
	{
		ApplyModifier(&(*j), false, aff);
	}

	_RemoveAura(aff);

	if (i != m_affects.end())
		m_affects.erase(i);
}

//-----------------------------------------------------------------------------
void Unit::RemoveAffectById(uint32 spellId)
{
    if(m_aura != NULL)
        if(m_aura->GetId() == spellId){
            m_aura = NULL;
            return;
        }

        Affect* aff = FindAff(spellId);
        if(aff)
            aff->SetDuration(0);
}

//-----------------------------------------------------------------------------
bool Unit::SetAffDuration(uint32 spellId,Unit* caster,uint32 duration)
{
    AffectList::iterator i;

    for (i = m_affects.begin(); i != m_affects.end(); i++)
    {
        if ((*i)->GetId() == spellId && (*i)->GetCasterGUID() == caster->GetGUID()){
            (*i)->SetDuration(duration);
            return true;
        }
    }
    return false;
}

//-----------------------------------------------------------------------------
bool Unit::RemoveAffect(uint32 spellId)
{
    AffectList::iterator i, next;
    Affect *aff;
    bool result = false;

    for (i = m_affects.begin(); i != m_affects.end(); i = next)
    {
        next = i;
        next++;

        aff = *i;

        if (aff->GetSpellId() == spellId)
        {
            for (Affect::ModList::const_iterator j = aff->GetModList().begin();
                j != aff->GetModList().end(); i++)
            {
                ApplyModifier(&(*j), false, aff);
            }

            _RemoveAura(aff);

            m_affects.erase(i);

            delete aff;

            result = true;
        }
    }

    return result;
}

//-----------------------------------------------------------------------------
void Unit::RemoveAllAffects()
{
    Affect *aff;
    bool result = false;

	AffectList::iterator i;
	AffectList::iterator next = m_affects.end();

	for (i = m_affects.begin(); i != m_affects.end(); i = next)
	//while (!m_affects.empty())
    {
        next = i;
        next++;

        aff = *i;
		//aff = *(m_affects.begin());

        for (Affect::ModList::const_iterator j = aff->GetModList().begin();
            j != aff->GetModList().end(); j++)
        {
            ApplyModifier(&(*j), false, aff);
        }

        _RemoveAura(aff);
		
		m_affects.erase(i);
		//m_affects.pop_front();

        delete aff;
    }

    return;
}

//-----------------------------------------------------------------------------
void Unit::_RemoveAllAffectMods()
{
    AffectList::iterator i;
    Affect::ModList::const_iterator j;

    Affect *aff;

    for (i = m_affects.begin(); i != m_affects.end(); i++)
    {
        aff = *i;

        for (j = aff->GetModList().begin();
            j != aff->GetModList().end(); j++)
        {
            ApplyModifier(&(*j), false, aff);
        }

        _RemoveAura(aff);
    }
}

//-----------------------------------------------------------------------------
void Unit::_ApplyAllAffectMods()
{
    AffectList::iterator i;
    Affect::ModList::const_iterator j;

    Affect *aff;

    for (i = m_affects.begin(); i != m_affects.end(); i++)
    {
        aff = *i;

        for (j = aff->GetModList().begin();
            j != aff->GetModList().end(); j++)
        {
            ApplyModifier(&(*j), true, aff);
        }

        _AddAura(aff);
    }
}

//-----------------------------------------------------------------------------
void Unit::_UpdateAura()
{
    Player* pThis = objmgr.GetObject<Player>(GetGUID());
    if(!m_aura)
        return;

    m_aura->SetDuration(6000);
    Player* pGroupGuy;
    Group* pGroup;
    if(pThis)
        pGroup = objmgr.GetGroupByLeader(pThis->GetGroupLeader());
    else{
        if(!SetAffDuration(m_aura->GetId(),this,6000))
            AddAffect(m_aura);
         return;
    }
    if(!pGroup){
        if(!SetAffDuration(m_aura->GetId(),this,6000))
            AddAffect(m_aura);
        return;
    }else
        for(uint32 i=0;i<pGroup->GetMembersCount();i++){
            pGroupGuy = objmgr.GetObject<Player>(pGroup->GetMemberGUID(i));
            if(!pGroupGuy)
                continue;
            if(sqrt(
                (GetPositionX()-pGroupGuy->GetPositionX())*(GetPositionX()-pGroupGuy->GetPositionX())
               +(GetPositionY()-pGroupGuy->GetPositionY())*(GetPositionY()-pGroupGuy->GetPositionY())
               +(GetPositionZ()-pGroupGuy->GetPositionZ())*(GetPositionZ()-pGroupGuy->GetPositionZ())
               ) <=30)
                if(!pGroupGuy->SetAffDuration(m_aura->GetId(),this,6000))
                    pGroupGuy->AddAffect(m_aura);
        }
}

//-----------------------------------------------------------------------------
void Unit::_UpdateSpells( int32 time )
{
    if(m_currentSpell != NULL)
    {
        m_currentSpell->update(time);
        if(m_currentSpell->getState() == SPELL_STATE_FINISHED)
        {
            delete m_currentSpell;
            m_currentSpell = NULL;
        }
    }

	if (m_auraCheck > time) {
		m_auraCheck -= time;
		return;
	} else {
		m_auraCheck += AURA_CHECK_EVERY_MSEC;
	}

	//--- fixed: set time to aura update interval ---
	time = AURA_CHECK_EVERY_MSEC;
	//--- end

    Affect *aff;
    AffectList::iterator i, next;
	static std::vector<Affect *> tmp_aff;
	tmp_aff.clear();

	for (i = m_affects.begin(); i != m_affects.end(); i++)
		tmp_aff.push_back (*i);

	for (int j = 0; j < (int)tmp_aff.size(); j++)
	{
        aff = tmp_aff[j];

        uint8 AffResult = aff->Update( time );
        if( AffResult == 2 || AffResult == 6 )
        {
            Unit *attacker = (Unit*) objmgr.GetObject<Player>(aff->GetCasterGUID());
            if(!attacker)
                attacker = (Unit*) objmgr.GetObject<Creature>(aff->GetCasterGUID());

            // FIXME: we currently have a way to inflict damage w/o attacker, this should be changed
            if(attacker)
            {
                if(this->isAlive())
                    attacker->PeriodicAuraLog(this, aff->GetId(), aff->GetDamagePerTick(),aff->GetSpellProto()->School);
            }
        }
        if( AffResult == 4 || AffResult == 6 )
        {
            // Trigger Spell
            // check for spell id
            SpellEntry *spellInfo = sSpellStore.LookupEntry( aff->GetSpellPerTick() );

            if(!spellInfo)
            {
                Log::getSingleton( ).outError("WORLD: unknown spell id %i\n", aff->GetSpellPerTick());
                return;
            }

            Spell *spell = new Spell(this, spellInfo, true, aff);
            SpellCastTargets targets;
            WorldPacket dump;
            dump.Initialize(0);
            dump << uint16(2) << GetUInt32Value(UNIT_FIELD_CHANNEL_OBJECT) << GetUInt32Value(UNIT_FIELD_CHANNEL_OBJECT+1);
            targets.read(&dump,GetGUID());

            spell->prepare(&targets);

        }

        if ( !aff->GetDuration() )
        {
            printf("remove aff %u from player %u\n",aff->GetId(),GetGUID());
            RemoveAffect(aff);
        }
    }
}

//-----------------------------------------------------------------------------
void Unit::castSpell( Spell * pSpell )
{
    // check if we have a spell already casting etc
    if(m_currentSpell)
    {
        m_currentSpell->cancel();
        delete m_currentSpell;
    }

    m_currentSpell = pSpell;
}

//-----------------------------------------------------------------------------
void Unit::InterruptSpell()
{
    if(m_currentSpell){
        m_currentSpell->SendInterrupted(0x1f);
        m_currentSpell->cancel();
        m_currentSpell = NULL;
    }
}

//-----------------------------------------------------------------------------
void Unit::_AddAura(Affect *aff)
{
    ASSERT(aff);

    if (!aff->GetId())
    {
        Log::getSingleton().outDetail("Unit::_AddAura() - affect doesn't have id");
        return;
    }

    // UNIT_FIELD_AURAFLAGS		0-7;
	// UNIT_FIELD_AURAFLAGS+1	8-15;
	// UNIT_FIELD_AURAFLAGS+2 1	6-23 ... For each Aura 1 Byte

    WorldPacket data;

    int32 slot, i;

    slot = 0xFF;

    if (aff->IsPositive()) {
        for (i = 0; i < MAX_POSITIVE_AURAS; i++) {
            if (GetUInt32Value(UNIT_FIELD_AURA + i) == 0)
            {
                slot = i;
                break;
            }
        }
    } else {
        for (i = MAX_POSITIVE_AURAS; i < MAX_AURAS; i++) {
            if (GetUInt32Value(UNIT_FIELD_AURA + i) == 0) 
            {
                slot = i;
                break;
            }
        }
    }

    if (slot == 0xFF)
    {
        Log::getSingleton().outDetail("Unit::_AddAura() - no free aura slots found");
        return;
    }

    Log::getSingleton().outDetail("Unit::_AddAura() - found slot %u", (uint32)slot);

    SetUInt32Value(UNIT_FIELD_AURA + slot, aff->GetId());

    uint32 flagslot = slot >> 3; // flags take half byte, and 4 bytes there are in uint32 value // now flagslot is number of word, where flag must be
    uint32 value = GetUInt32Value (UNIT_FIELD_AURAFLAGS + flagslot);

    Log::getSingleton().outDetail("Unit::_AddAura() - old value: 0x%08X", value);
    
	uint32 offset = (slot & 7) << 2;    // now offset is (number of (4bits of flags)) multiplicated by (size of flags, in bits)
	value &= ~(uint32(0xF) << offset);  // set to zero flags with number (number of (4bits of flags))
	value |= (AFLAG_SET << offset);     // Setting AFLAG_SET at position (number of (4bits of flags))

    Log::getSingleton().outDetail("Unit::_AddAura() - new value: 0x%08X", value);
    SetUInt32Value(UNIT_FIELD_AURAFLAGS + flagslot, value);

//  0000 0000 original
//  0000 1001 AFLAG_SET
//  1111 1111 0xFF

    uint32 appslot = slot >> 1; // application needs 2 bytes
    value = GetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS + appslot);
    uint16 *dmg = ((uint16*)&value) + (slot & 1); // now *dmg==value or *dmg==value+2
    *dmg = 5; // FIXME: use correct value
    SetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS + appslot, value);

    if (isPlayer())
    {
        data.Initialize(SMSG_UPDATE_AURA_DURATION);
        
		uint32 _duration = max (aff->GetDuration(), 0);
		data << (uint8)slot << _duration;
        ((Player*)this)->GetSession()->SendPacket(&data);
    }

    aff->SetAuraSlot (uint8 (slot));

    return;
}

//-----------------------------------------------------------------------------
void Unit::_RemoveAura(Affect *aff)
{
    ASSERT(aff);

    // UNIT_FIELD_AURAFLAGS		0-7;
	// UNIT_FIELD_AURAFLAGS+1	8-15;
	// UNIT_FIELD_AURAFLAGS+2	16-23 ... For each Aura 1 Byte

    uint8 slot = aff->GetAuraSlot();

    SetUInt32Value(UNIT_FIELD_AURA + slot, 0);

    uint8 flagslot = slot >> 3;

    uint32 value = GetUInt32Value((uint16)(UNIT_FIELD_AURAFLAGS + flagslot));
    value &= 0xFFFFFFFF ^ (0xF << ((slot & 7) << 2));
    SetUInt32Value(UNIT_FIELD_AURAFLAGS + flagslot, value);

/*
    uint8 appslot = slot >> 1;
    value = GetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS + appslot);
    uint16 *dmg = ((uint16*)&value) + (slot & 1);
    *dmg = 0;
    SetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS + appslot, value);
*/

    aff->SetAuraSlot(0);

    return;
}

//-----------------------------------------------------------------------------
Affect* Unit::FindAff(uint32 spellId)
{
    AffectList::iterator i;
    for (i = m_affects.begin(); i != m_affects.end(); i++)
        if((*i)->GetId() == spellId)
            return (*i);
    return NULL;
}

//-----------------------------------------------------------------------------
float GetDistance (float xe, float ye, float xz, float yz)
{
	return sqrt( ( xe - xz ) * ( xe - xz ) + ( ye - yz ) * ( ye - yz ) );
}

//-----------------------------------------------------------------------------
float GetDistanceSq (float xe, float ye, float xz, float yz)
{
	return  ( xe - xz ) * ( xe - xz ) + ( ye - yz ) * ( ye - yz );
}

//-----------------------------------------------------------------------------
float GetAngle (float xe, float ye, float xz, float yz)
{
        float w;
        w = atan( ( yz - ye ) / ( xz - xe ) );
        w = ( w / (float)DEG2RAD );
        if (xz>=xe) {
                w = 90+w;
        } else {
                w = 270+w;
        }
        return w;
}

//-----------------------------------------------------------------------------
float GetEasyAngle (float angle)
{
        while ( angle < 0 ) {
                angle = angle + 360;
        }
        while ( angle >= 360 ) {
                angle = angle - 360;
        }
        return angle;
}

//-----------------------------------------------------------------------------
bool InArc( float radius,  float xM, float yM, float offnung, float orientation, float xP, float yP )
{
	float distanceSq = GetDistanceSq (xM, yM, xP, yP);
	float angle = GetAngle (xM, yM, xP, yP);
	float lborder = GetEasyAngle (( orientation - (offnung/2) ));
	float rborder = GetEasyAngle (( orientation + (offnung/2) ));

	if (radius * radius >= distanceSq &&
		( ( angle >= lborder ) && ( angle <= rborder ) ||
		( lborder > rborder && ( angle < rborder || angle > lborder ) ) ) )
	{
		return true;
	}

	return false;
} 

//-----------------------------------------------------------------------------
bool Unit::isInFront(Unit* target,float distance)
{
    float orientation = GetOrientation()/float(2*M_PI)*360;
    orientation += 90.0f;
	distance += 2.5f;//temp only!
    return InArc (distance, GetPositionX(), GetPositionY(), float(180),
		orientation, target->GetPositionX(), target->GetPositionY());
}

//-----------------------------------------------------------------------------
bool Unit::isStunned() 
{
	for (AffectList::iterator i = m_affects.begin(); i != m_affects.end(); i++)
	{
		Affect *aff = *i;
		for (Affect::ModList::const_iterator j = aff->GetModList().begin();
			j != aff->GetModList().end(); j++)
		{
			const Modifier	&mod = *j;
			switch (j->GetType()) {
				case SPELL_AURA_MOD_CONFUSE:
				case SPELL_AURA_MOD_STUN:
					return true;
			}
		}
	}

	return false;
}

//-----------------------------------------------------------------------------
void Unit::OnTakeDamage (Unit *attacker) 
{
	// Check if we were rooted, polymorphed or whatever else
	//
	// TODO: Add different chances to unmorph on damage - on crit, on hit, on parry
	SpellEntry *sp_proto;

	for (AffectList::iterator i = m_affects.begin(); i != m_affects.end(); i++)
	{
		Affect *aff = *i;
		for (Affect::ModList::const_iterator j = aff->GetModList().begin();
			j != aff->GetModList().end(); j++)
		{
			const Modifier	&mod = *j;
			switch (j->GetType()) {
				case SPELL_AURA_TRANSFORM:
					RemoveAffect (aff);
					Log::getSingleton().outDetail("UNIT: Taken damage, transform removed");
					return;
				case SPELL_AURA_MOD_STUN:
					sp_proto = aff->GetSpellProto();
					// Assume here that non dispelable stuns are breaked by damage
					if (sp_proto != NULL && sp_proto->isDispelable == false)
					{
						RemoveAffect (aff);
						Log::getSingleton().outDetail("UNIT: Taken damage, stun removed");
						return;
					} 
					break;
			}
		}
	}

	//----- Stealthed unit should unstealth on damage taken -----
	// If there was invisibility affect - go remove it
	if (m_stealthLevel > 0)
		LoseStealth();

	// Some NPC classes can run away, cast heal on self, or call for help
	//
	Call_Unit_OnTakeDamage ((Unit *)this, (Unit *)attacker);
}

//-----------------------------------------------------------------------------
void Unit::LoseStealth()
{
	RemoveAffectById (1784); // Stealth (rank 1)
	RemoveAffectById (1785); // Stealth (rank 2)
	RemoveAffectById (1786); // Stealth (rank 3)
	RemoveAffectById (1787); // Stealth (rank 4)

	RemoveAffectById (8152); // Prowl (rank 1)
	RemoveAffectById (6783); // Prowl (rank 2)
	RemoveAffectById (9913); // Prowl (rank 3)

	RemoveAffectById (24450); // Pet Prowl (rank 1)
	RemoveAffectById (24452); // Pet Prowl (rank 2)
	RemoveAffectById (24453); // Pet Prowl (rank 3)
}

//-----------------------------------------------------------------------------
// Resets base player stats based on known formulas, and then player is ready
// to have item mods applied.
//-----------------------------------------------------------------------------
void Unit::_ResetBaseStats()
{
	uint8	cls = GetClass();
	if (cls == 0) return;

	//PlayerCreateInfo *info = objmgr.GetPlayerCreateInfo (GetRace(), cls);
	//if (info == NULL) return;

	// Set default: STR, AGI, STA, INT, SPI and later apply their real startup values
	SetUInt32Value (UNIT_FIELD_STAT0, 0);
	SetUInt32Value (UNIT_FIELD_STAT1, 0);
	SetUInt32Value (UNIT_FIELD_STAT2, 0);
	SetUInt32Value (UNIT_FIELD_STAT3, 0);
	SetUInt32Value (UNIT_FIELD_STAT4, 0);

	if (isPlayer()) {
		SetUInt32Value (PLAYER_FIELD_POSSTAT0, 0);
		SetUInt32Value (PLAYER_FIELD_POSSTAT1, 0);
		SetUInt32Value (PLAYER_FIELD_POSSTAT2, 0);
		SetUInt32Value (PLAYER_FIELD_POSSTAT3, 0);
		SetUInt32Value (PLAYER_FIELD_POSSTAT4, 0);

		SetUInt32Value (PLAYER_FIELD_NEGSTAT0, 0);
		SetUInt32Value (PLAYER_FIELD_NEGSTAT1, 0);
		SetUInt32Value (PLAYER_FIELD_NEGSTAT2, 0);
		SetUInt32Value (PLAYER_FIELD_NEGSTAT3, 0);
		SetUInt32Value (PLAYER_FIELD_NEGSTAT4, 0);
	}

	SetArmor		(0);
	SetHolyResist	(0);
	SetFireResist	(0);
	SetNatureResist (0);
	SetFrostResist	(0);
	SetShadowResist (0);
	SetArcaneResist (0);

	//SetRangedAttackPower(0);
	//SetAttackPower		(0);
	SetUInt32Value (UNIT_FIELD_ATTACKPOWER, 0);
	SetUInt32Value (UNIT_FIELD_RANGEDATTACKPOWER, 0);

	m_critChance =		4.0f;
	m_dodgeChance =		0.0f;
	m_parryChance =		4.0f;
	m_blockChance =		0.0f;

	m_stealthDetectBonus = 0;
	m_stealthLevel = 0;
	
	// Set default: ATTACK and all powers
	SetUInt32Value (UNIT_FIELD_MAXHEALTH, 0); //info->health);
	SetUInt32Value (UNIT_FIELD_MAXPOWER1, 0); //info->mana);

	SetUInt32Value (UNIT_FIELD_MAXPOWER2, 0); //info->rage);	// always 100 for rage consumers
	SetUInt32Value (UNIT_FIELD_MAXPOWER3, 0); //info->focus);	// always 0
	SetUInt32Value (UNIT_FIELD_MAXPOWER4, 0); //info->energy);	// always 100 for energy consumers

	// +++ Call init scripts
	Call_PlayerStats_ByRace		(this, false);			// Player_class.py Python scr. call
	Call_PlayerStats_ByClass	(this, false);			// Player_class.py Python scr. call
	
	// +++ Call Recalculation of stats according Player Level 
	if (GetLevel() > 1)									// 1-st Level gets all data from Player_class already 
	{
 	_ApplyLevelUpAttributes		(GetLevel(), true);		// STA, INT, AGI, STR recalc. & modifying Health/Mana by STA, INT settings
	}

	// Now apply attribute values
	//SetStrength (info->strength);
	//SetAgility (info->agility);
	//SetStamina (info->stamina);
	//SetIntellect (info->intellect);
	//SetSpirit (info->spirit);

	// Now consider strength and agility bonuses already applied
	// Let's add missing components
	// ---------------------------------------------------------------------------------------

	// ++++ Modifying ATTACK POWER
	// Bonuses from STR and AGI are applied already ! We add only missing part.
	// To-do:
	// + Character Level * 3 (in Bear Form)
    // + Character Level * 2 + Agility (in Cat Form)
	switch (cls)
	{
	case CLASS_WARRIOR:		// CharacterLevel*3+Strength*2-20 
		ModifyAttackPower (GetLevel() * 3 - 20);
		break;

	case CLASS_PALADIN:		// CharacterLevel*3+Strength*2-20
		ModifyAttackPower (GetLevel() * 3 - 20);
		break;

	case CLASS_ROGUE:		// CharacterLevel*2+Strength+Agility-20 
		ModifyAttackPower (GetLevel() * 2 - 20);
		break;

	case CLASS_HUNTER:		// CharacterLevel*2+Strength+Agility-20 
		ModifyAttackPower (GetLevel() * 2 - 20);
		break;

	case CLASS_SHAMAN:		// CharacterLevel*2+Strength*2-20 
		ModifyAttackPower (GetLevel() * 2 - 20);
		break;

	case CLASS_DRUID:		// Strength*2-20 
		ModifyAttackPower (- 20);
		break;

	case CLASS_MAGE:		// Strength-10 
		ModifyAttackPower (- 10);
		break;

	case CLASS_PRIEST:		// Strength-10 
		ModifyAttackPower (- 10);
		break;

	case CLASS_WARLOCK:		// Strength-10 
		ModifyAttackPower (- 10);
		break;
	}

	// +++ Modifying Ranged Attack Power for all Classes

    // Ranged Attack Power = Character Level * 2 + Agility * 2 - 20 
    // 14 Attack Power = 1 Damage per Second 
	ModifyRangedAttackPower (GetLevel() * 2 - 20);

	// +++ Applying Bonuses gained from Defense Skill
	// Each point of +Defense skill adds 0.04% to Parry, Dodge, and Block. 
    // This means +25 Defense will grant you an extra 1% Parry, Dodge, and Block. The formula has been tested to be the same for both Hunters and Paladins. It's probably constant across all classes. Rogues are most likely to have a differing formula. 
    // Defense has additional rumored effects: The following four effects of Defense were supposedly posted by a CM on WoW's European forums.(A link to the official post would be nice). 
    // Increases the chance of being missed by an attack. 
    // Increases the chance to dodge, parry, and block. 
    // Decreases the chance of being affected by a critical hit. 
    // Decreases the chance of being affected by a "crushing blow". Creatures that are higher level than your character can land crushing blows that deal increased melee damage. The chance of a crushing blow increases as the level difference between you and the opposing creature increases. Players never deal "crushing blows", only creatures 

	if (isPlayer()) {

		Player *player = (Player *)this;

		if (player->HasSkill(SKILL_DEFENSE)) // We check if Player has Defense skill and apply bonuses then 
		{
			player->ModifyDodgeChance ((float)player->GetSkill(SKILL_DEFENSE) * 0.04f);
			player->ModifyParryChance ((float)player->GetSkill(SKILL_DEFENSE) * 0.04f);
			player->ModifyBlockChance ((float)player->GetSkill(SKILL_DEFENSE) * 0.04f);
		}
	}
	
	// Moved from SetLevel (info according Kvakvs's notice)
	ModifyCritChance		((-1.0f) * (float)GetLevel() * 0.04f);
	ModifyRangedCritChance	((-1.0f) * (float)GetLevel() * 0.04f);
	ModifyDodgeChance		((-1.0f) * (float)GetLevel() * 0.04f);
}

//-----------------------------------------------------------------------------
void Unit::SetLevel (uint32 value)
{ 
	// Setting Level
	SetUInt32Value (UNIT_FIELD_LEVEL, value);

	//_ResetBaseStats();
	
	// Restore Health/Mana to their Maximum
	if (GetHealth() < GetMaxHealth()) SetHealth (GetMaxHealth());
	if (GetMana() < GetMaxMana()) SetMana (GetMaxMana());

	//uint8	cls = GetClass();
	//PlayerCreateInfo *info = objmgr.GetPlayerCreateInfo (GetRace(), cls);
	//if (info == NULL) return;
};

//-----------------------------------------------------------------------------
inline float cubicPolynome (int level, float a3, float a2, float a1, float a0) 
{
	return a3 * (level*level*level) + a2 * (level*level) + a1 * level + a0;
}

//-----------------------------------------------------------------------------
//	Recalculation of STR, AGI, STA, INT, SPI
//	
//
void Unit::_ApplyLevelUpAttributes (int32 level, bool apply)
{
	uint8	cls = GetClass();
	float	str_on_level = 0,
			agi_on_level = 0,
			sta_on_level = 0,
			int_on_level = 0,
			spi_on_level = 0;
	//int32	health_on_level = 0,
	//		mana_on_level = 0;

	switch (cls) {
		case CLASS_DRUID:
			str_on_level = cubicPolynome (level, 0.000021f, 0.003009f, 0.486493f, -0.400003f);
			agi_on_level = cubicPolynome (level, 0.000041f, 0.000440f, 0.512076f, -1.000317f);
			sta_on_level = cubicPolynome (level, 0.000023f, 0.003345f, 0.560050f, -0.562058f);
			int_on_level = cubicPolynome (level, 0.000038f, 0.005145f, 0.871006f, -0.832029f);
			spi_on_level = cubicPolynome (level, 0.000059f, 0.004044f, 1.040000f, -1.488504f);
			//health_on_level = level <= 17 ? 17 : level;
			//mana_on_level = level <= 25 ? level + 20 : 45;
			break;
		case CLASS_HUNTER:
			str_on_level = cubicPolynome (level, 0.000022f, 0.001800f, 0.407867f, -0.550889f);
			agi_on_level = cubicPolynome (level, 0.000040f, 0.007416f, 1.125108f, -1.003045f);
			sta_on_level = cubicPolynome (level, 0.000031f, 0.004480f, 0.780040f, -0.800471f);
			int_on_level = cubicPolynome (level, 0.000020f, 0.003007f, 0.505215f, -0.500642f);
			spi_on_level = cubicPolynome (level, 0.000017f, 0.003803f, 0.536846f, -0.490026f);
			//health_on_level = level <= 13 ? 17 : level + 4;
			//mana_on_level = level <= 27 ? level + 18 : 45;
			break;
		case CLASS_MAGE:
			str_on_level = cubicPolynome (level, 0.000002f, 0.001003f, 0.100890f, -0.076055f);
			agi_on_level = cubicPolynome (level, 0.000008f, 0.001001f, 0.163190f, -0.064280f);
			sta_on_level = cubicPolynome (level, 0.000006f, 0.002031f, 0.278360f, -0.340077f);
			int_on_level = cubicPolynome (level, 0.000040f, 0.007416f, 1.125108f, -1.003045f);
			spi_on_level = cubicPolynome (level, 0.000039f, 0.006981f, 1.090090f, -1.006070f);
			//health_on_level = level <= 25 ? 15 : level - 8;
			//mana_on_level = level <= 27 ? level + 23 : 51;
			break;
		case CLASS_PALADIN:
			str_on_level = cubicPolynome (level, 0.000037f, 0.005455f, 0.940039f, -1.000090f);
			agi_on_level = cubicPolynome (level, 0.000020f, 0.003007f, 0.505215f, -0.500642f);
			sta_on_level = cubicPolynome (level, 0.000038f, 0.005145f, 0.871006f, -0.832029f);
			int_on_level = cubicPolynome (level, 0.000023f, 0.003345f, 0.560050f, -0.562058f);
			spi_on_level = cubicPolynome (level, 0.000032f, 0.003025f, 0.615890f, -0.640307f);
			//health_on_level = level <= 14 ? 18 : level + 4;
			//mana_on_level = level <= 25 ? level + 17 : 42;
			break;
		case CLASS_PRIEST:
			str_on_level = cubicPolynome (level, 0.000008f, 0.001001f, 0.163190f, -0.064280f);
			agi_on_level = cubicPolynome (level, 0.000022f, 0.000022f, 0.260756f, -0.494000f);
			sta_on_level = cubicPolynome (level, 0.000024f, 0.000981f, 0.364935f, -0.570900f);
			int_on_level = cubicPolynome (level, 0.000039f, 0.006981f, 1.090090f, -1.006070f);
			spi_on_level = cubicPolynome (level, 0.000040f, 0.007416f, 1.125108f, -1.003045f);
			//health_on_level = level <= 22 ? 15 : level - 6;
			//mana_on_level = level <= 33 ? level + 22 : 54;
			//if (level == 34) mana_on_level += 15;
			break;
		case CLASS_ROGUE:
			str_on_level = cubicPolynome (level, 0.000025f, 0.004170f, 0.654096f, -0.601491f);
			agi_on_level = cubicPolynome (level, 0.000038f, 0.007834f, 1.191028f, -1.203940f);
			sta_on_level = cubicPolynome (level, 0.000032f, 0.003025f, 0.615890f, -0.640307f);
			int_on_level = cubicPolynome (level, 0.000008f, 0.001001f, 0.163190f, -0.064280f);
			spi_on_level = cubicPolynome (level, 0.000024f, 0.000981f, 0.364935f, -0.570900f);
			//health_on_level = level <= 15 ? 17 : level + 2;
			break;
		case CLASS_SHAMAN:
			str_on_level = cubicPolynome (level, 0.000035f, 0.003641f, 0.734310f, -0.800626f);
			agi_on_level = cubicPolynome (level, 0.000022f, 0.001800f, 0.407867f, -0.550889f);
			sta_on_level = cubicPolynome (level, 0.000020f, 0.006030f, 0.809570f, -0.809220f);
			int_on_level = cubicPolynome (level, 0.000031f, 0.004480f, 0.780040f, -0.800471f);
			spi_on_level = cubicPolynome (level, 0.000038f, 0.005145f, 0.871006f, -0.832029f);
			//health_on_level = level <= 16 ? 17 : level + 1;
			//mana_on_level = level <= 32 ? level + 19 : 52;
			break;
		case CLASS_WARLOCK:
			str_on_level = cubicPolynome (level, 0.000006f, 0.002031f, 0.278360f, -0.340077f);
			agi_on_level = cubicPolynome (level, 0.000024f, 0.000981f, 0.364935f, -0.570900f);
			sta_on_level = cubicPolynome (level, 0.000021f, 0.003009f, 0.486493f, -0.400003f);
			int_on_level = cubicPolynome (level, 0.000059f, 0.004044f, 1.040000f, -1.488504f);
			spi_on_level = cubicPolynome (level, 0.000040f, 0.006404f, 1.038791f, -1.039076f);
			//health_on_level = level <= 17 ? 15 : level - 2;
			//mana_on_level = level <= 30 ? level + 21 : 51;
			break;
		case CLASS_WARRIOR:
			str_on_level = cubicPolynome (level, 0.000039f, 0.006902f, 1.080040f, -1.051701f);
			agi_on_level = cubicPolynome (level, 0.000022f, 0.004600f, 0.655333f, -0.600356f);
			sta_on_level = cubicPolynome (level, 0.000059f, 0.004044f, 1.040000f, -1.488504f);
			int_on_level = cubicPolynome (level, 0.000002f, 0.001003f, 0.100890f, -0.076055f);
			spi_on_level = cubicPolynome (level, 0.000006f, 0.002031f, 0.278360f, -0.340077f);
			//health_on_level = level < 14 ? 19 : level + 10;
			break;
	}
	
	//float mag = apply ? 1.0f : -1.0f;
	if (apply) {
		ModifyStrength	(int32 (str_on_level));
		ModifyAgility	(int32 (agi_on_level));
		ModifyStamina	(int32 (sta_on_level));
		ModifyIntellect (int32 (int_on_level));
		ModifySpirit	(int32 (spi_on_level));
	//ModifyMaxHealth (int32 (mag * health_on_level));
	//ModifyMaxMana	(int32 (mag * mana_on_level));
	}
}

//-----------------------------------------------------------------------------
void Unit::SetStrength (int32 value)
{
	//Log::getSingleton().outDetail ("Setting Strength to %d", value);
	int32 d = value - GetStrength();
	SetUInt32Value (UNIT_FIELD_STAT0, value);
	OnModifyStrength (d);
}

//-----------------------------------------------------------------------------
void Unit::OnModifyStrength (int32 d)
{
	switch (GetClass()) 
	{
	case CLASS_WARRIOR:
	case CLASS_PALADIN:
	case CLASS_SHAMAN:
	case CLASS_DRUID:
		ModifyAttackPower (d * 2);
		break;

	default:
		ModifyAttackPower (d);
	}

	 // +++ Modifying Block Chance

     //Block chance doesn't mean fully blocking the damage of that hit, but a partial absorbtion of a quantity of damage, as follows: 
     //X = [(Shield block value) + (Strength / 30)]. 
     // Therefor, the warrior is favored here, because of the natural increased strength. 
        
     ModifyBlockChance (GetBlockChance() + (float)d / 30.0f);  // How to get Shield block value ?
}

//-----------------------------------------------------------------------------
void Unit::SetAgility (int32 value) 
{
	//Log::getSingleton().outDetail ("Setting Agility to %d", value);
	int32 d = value - GetAgility();
	SetUInt32Value (UNIT_FIELD_STAT1, value);
	OnModifyAgility (d);
}

//-----------------------------------------------------------------------------
void Unit::OnModifyAgility (int32 d)
{
	uint8	cls = GetClass();
	if (cls == CLASS_ROGUE || cls == CLASS_HUNTER)
	{
		ModifyAttackPower (d);
	}

	// Do increase/decrease armor
	// Increases Armor Class by 2 for every point of AGI. 
	ModifyArmor (2 * d);

	// Do critical hit chance recalculation
	/*
	Increases the chance of a critical hit with melee and ranged attacks. The amount
	of the increase is dependant on both class and level. For most level 60
	character classes, approximately 20 points of AGI will increase your critical
	hit chance by approximately 1%. Rogues require 29 AGI for an additional 1%
	critical hit chance, and Hunters require 53 AGI for an additional 1% critical
	hit chance, but both of these classes also gain attack power from agility and
	the items available to them typically have much higher amounts of AGI.
	*/
	// Do dodge chance recalculation
	/*
	Increases the chance to dodge an attack. The amount increased is dependant on
	both class and level. For most level 60 character classes, approximately 20
	points of AGI will increase your chance to dodge by approximately 1%. Rogues
	only require 14.5 AGI for an additional 1% dodge chance. Hunters require 26.5
	AGI for an additional 1% dodge chance, but Hunters typically have a high amount
	of agility, as well as an Aspect spell that further increases their chance to
	dodge attacks.
	*/
	switch (cls)
	{
	case CLASS_ROGUE:
		ModifyCritChance ((float)d / 29.0f);
		ModifyDodgeChance ((float)d / 14.5f);
		break;
	
	case CLASS_HUNTER:
		ModifyCritChance ((float)d / 53.0f);
		ModifyDodgeChance ((float)d / 26.5f);
		break;

	default:
		ModifyCritChance ((float)d / 20.0f);
		ModifyDodgeChance ((float)d / 20.0f);
	}

	/*
	Attack Power (Ranged) = (Level*2 + Agility*2)-20 
	*/
	ModifyRangedAttackPower (d*2);
}

//-----------------------------------------------------------------------------
void Unit::SetStamina (int32 value)
{
	//Log::getSingleton().outDetail ("Setting Stamina to %d", value);
	int32	d = value - GetStamina();
	SetUInt32Value (UNIT_FIELD_STAT2, value);
	OnModifyStamina(d);
}

//-----------------------------------------------------------------------------
void Unit::OnModifyStamina (int32 d)
{
	int32	oldStamina = GetStamina();
	/*
		If Stamina is < 20:		Health = BaseHealth + (Stamina - 20)
		If Stamina is >= 20:	Health = BaseHealth + 10 * (Stamina - 20)
	*/
	if (d > 0)
	{
		for (int i = 0; i < d; i++)
		{
			if (oldStamina + i < 20)
				ModifyMaxHealth (1);
			else
				ModifyMaxHealth (10);
		}
	} else
	{
		for (int i = d; i < 0; i++)
		{
			if (oldStamina + i < 20)
				ModifyMaxHealth (-1);
			else
				ModifyMaxHealth (-10);
		}
	}
}

//-----------------------------------------------------------------------------
void Unit::SetIntellect (int32 value)
{
	//Log::getSingleton().outDetail ("Setting Intellect to %d", value);
	
	int32	d = value - GetIntellect();
	SetUInt32Value (UNIT_FIELD_STAT3, value);
	OnModifyIntellect (d);
}

//-----------------------------------------------------------------------------
void Unit::OnModifyIntellect (int32 d)
{
	int32	oldIntel = GetIntellect();
	/*
	If Stamina is < 20:		Health = BaseHealth + (Stamina - 20)
	If Stamina is >= 20:	Health = BaseHealth + 10 * (Stamina - 20)
	*/
	if (d > 0)
	{
		for (int i = 0; i < d; i++)
		{
			if (oldIntel + i < 20)
				ModifyMaxMana (1);
			else
				ModifyMaxMana (15);
		}
	} else
	{
		for (int i = d; i < 0; i++)
		{
			if (oldIntel + i < 20)
				ModifyMaxMana (-1);
			else
				ModifyMaxMana (-15);
		}
	}
}

//-----------------------------------------------------------------------------
//void Unit::SetSpirit (int32 value) {}
//void Unit::SetHealth (int32 value) {}
//void Unit::SetMana (int32 value) {}
//void Unit::SetRage (int32 value) {}
//void Unit::SetFocus (int32 value) {}
//void Unit::SetEnergy (int32 value) {}
//void Unit::SetMaxHealth (int32 value) {}
//void Unit::SetMaxMana (int32 value) {}
//void Unit::SetMaxRage (int32 value) {}
//void Unit::SetMaxFocus (int32 value) {}
//void Unit::SetMaxEnergy (int32 value) {}

//-----------------------------------------------------------------------------
void Unit::SetAttackPower (int32 value)
{
	int32	d = value - GetAttackPower();
	SetUInt32Value (UNIT_FIELD_ATTACKPOWER, value);
	
	// Nullify Min/Max damage on given ZERO (value = 0)
	if (value == 0) {
		SetMinDamage(0);
		SetMaxDamage(0);
		return;
	}
	
	// multiply attack power change by attack delay
	// then divide by 14 AP points per 1 damage point/second
	uint32 attack = GetBaseAttackTime1() > 0? GetBaseAttackTime1() : 2500;
	float sec_per_hit = attack / 1000.0f;
	float dmg_boost = d * sec_per_hit / 14.0f;

	ModifyMinDamage (dmg_boost);
	ModifyMaxDamage (dmg_boost);

	//Log::getSingleton().outDebug ("SetAttackPower (value=%d): Boosted damages by %.1f (attack speed %d) - result %.1f..%.1f",
	//	value, dmg_boost, GetBaseAttackTime1(), GetMinDamage(), GetMaxDamage());
}
//-----------------------------------------------------------------------------
//void Unit::SetRangedAttackPower
//-----------------------------------------------------------------------------
void Unit::SetRangedAttackPower (int32 value)
{
	int32	d = value - GetRangedAttackPower();
	SetUInt32Value (UNIT_FIELD_RANGEDATTACKPOWER, value);

	// Nullify Min/Max damage on given ZERO (value = 0)
	if (value == 0) {
		SetRangedMinDamage(0);
		SetRangedMaxDamage(0);
		return;
	}
	
	// multiply attack power change by attack delay
	// then divide by 14 AP points per 1 damage point/second
	uint32 attack = GetRangedAttackTime() > 0? GetRangedAttackTime() : 2200;
	float sec_per_hit = attack / 1000.0f;
	float dmg_boost = d * sec_per_hit / 14.0f;

	ModifyRangedMinDamage (dmg_boost);
	ModifyRangedMaxDamage (dmg_boost);

	Log::getSingleton().outDebug ("SetRangedAttackPower (value=%d): Boosted damages by %.1f (attack speed %d) - result %.1f..%.1f",
		value, dmg_boost, GetRangedAttackTime(), GetRangedMinDamage(), GetRangedMaxDamage());
}

//-----------------------------------------------------------------------------
//void Unit::SetArmor (uint32 value) 
//-----------------------------------------------------------------------------
bool Unit::CanSee (Object *o)
{
	int32	is_player = isPlayer();
	int32	is_unit = isUnit();

	// Units and players always see gameobjects
	if (is_unit || is_player) {
		if (o->isNotUnit() && o->isNotPlayer())
			return true;
	}

	Unit *npc = (Unit *)o;
	uint32 tid = npc->GetTypeId();

	// Dead players see other dead players
	if (isDead() && is_player && npc->isDead() && npc->isPlayer())
		return true;

	// Dead units never can see spirit healers. Live units never see them
	if (npc->isSpiritHealer() != isDead())
		return false;

	if (npc->isStealth()) {
		// Use visibility value as visibility range
		// Can safely approach mobs 2 levels higher (10 stealth points)
		//
		int32 detectionLevel = npc->GetStealthLevel() - GetStealthDetect();
		if (detectionLevel < 0) return true;

		float mobRadius = GetFloatValue(UNIT_FIELD_BOUNDINGRADIUS);
		float visRange = min (0, (1.0f + 0.15f * detectionLevel) * mobRadius);

		if (GetDistance2dSq (o) <= visRange * visRange)
			return true;
		return false;
	}

	return true;
}

//-----------------------------------------------------------------------------
void Unit::VirtualEquip (uint8 count, uint32 slot, uint32 model, uint32 data )
{
	/* We use this part if there is necessity to Equip REAL Item to NPC
	// Create Item for NPC
	Item *item = new Item();
	item->Create (objmgr.GenerateLowGuid (HIGHGUID_ITEM), model, this);
	item->SetCount (1);
	item->PlaceOnMap();
    
	// Equip Item to NPC
	if (slot <= 3) {
		SetUInt32Value (UNIT_VIRTUAL_ITEM_SLOT_DISPLAY + slot, item->GetProto()->DisplayInfoID);
		SetUInt32Value (UNIT_VIRTUAL_ITEM_INFO + slot * 2, item->GetGUIDLow());
		SetUInt32Value (UNIT_VIRTUAL_ITEM_INFO + slot * 2 + 1, item->GetProto()->Sheath);
	}
	*/

	// Equip Item to NPC
	if (count <= 3) {
		SetUInt32Value (UNIT_VIRTUAL_ITEM_SLOT_DISPLAY + count, model);
		SetUInt32Value (UNIT_VIRTUAL_ITEM_INFO + count * 2, data);
		SetUInt32Value (UNIT_VIRTUAL_ITEM_INFO + ((count * 2) + 1), slot);
	}

}

//-----------------------------------------------------------------------------
void Unit::OnExitCombat()
{
	// TODO: Add 100% evade here and make everything
	// regenerate in the last second of run
	SetHealth (GetMaxHealth());
	SetMana (GetMaxMana());
	SetEnergy (GetMaxEnergy());
	SetRage (0);
	SetUInt64Value (UNIT_FIELD_TARGET, 0);

	smsg_AttackStop (GetTarget());
	RemoveFlag (UNIT_FIELD_FLAGS, 0x80000);
}

//-----------------------------------------------------------------------------
Unit * Unit::WorldGetUnit (uint64 guid)
{
	Creature * cr = objmgr.GetObject<Creature> (guid);
	if (cr != NULL) return (Unit *)cr;

	Player * pl = objmgr.GetObject<Player> (guid);
	return pl;
}

//-----------------------------------------------------------------------------
uint32 Unit::CalculateDamage (uint32 &additionalSpellId, uint32 &additionalSpellDmg)
{
	uint32 attack_power = GetAttackPower();

	/*if(GetTypeId() == TYPEID_PLAYER)
	{
	attack_power = GetUInt32Value(UNIT_FIELD_ATTACKPOWER);
	// attack_power += GetUInt32Value(PLAYER_FIELD_ATTACKPOWERMODPOS);
	// attack_power -= GetUInt32Value(PLAYER_FIELD_ATTACKPOWERMODNEG);

	}*/

	// FIXME: This code is for pure physical damage
	//
	float min_damage = GetMinDamage() + 0.5f;
	float max_damage = GetMaxDamage() + 0.5f;

	ASSERT (min_damage <= max_damage);
	// Ehh, sometimes min is bigger than max!?!? (wowd)
	/*if (min_damage > max_damage)
	{
	float temp = max_damage;
	max_damage = min_damage;
	min_damage = temp;
	}*/

	float dmg;
	if (min_damage != max_damage) {
		int32 diff = int32 (100 * (max_damage - min_damage));
		dmg = min_damage + (randomMT() % diff) * 0.01f;
	} 
	else {
		dmg = min_damage;
	}

	int32 dmgResult = int32 (0.5f + CalculateDamageMods (dmg));

	//Log::getSingleton().outDebug ("CalculateDamage: min = %.1f, max = %.1f, result = %d",
	//	min_damage, max_damage, dmgResult);

	if (m_addDmgOnce) {
		if (m_addDmgOnceSpell != 0) {
			additionalSpellId = m_addDmgOnceSpell;
			dmgResult += m_addDmgOnce;
			additionalSpellDmg = dmgResult;
		} else {
			dmgResult += m_addDmgOnce;
		}

		m_addDmgOnce = 0;
		m_addDmgOnceSpell = 0;
	}
	else
	if (m_amplifyDmgOnce) {
		if (m_amplifyDmgOnceSpell != 0) {
			additionalSpellId = m_amplifyDmgOnceSpell;
			dmgResult *= m_amplifyDmgOnce;
			additionalSpellDmg = dmgResult;
		} else {
			dmgResult *= m_amplifyDmgOnce;
		}

		m_amplifyDmgOnce = 0.0f;
		m_amplifyDmgOnceSpell = 0;
	}

	return dmgResult;
}

//-----------------------------------------------------------------------------
void Unit::Say (Unit *receiver, const char *text, Language language)
{
	WorldPacket		data;

	data.Initialize (SMSG_MESSAGECHAT);
	data << (uint8)0x0B;
	data << (uint32)language;
	data << this->GetGUID();

	if (GetTypeId() == TYPE_UNIT)
	{
		CreatureTemplate * cr = objmgr.GetCreatureTemplate (GetEntry(), false);
		if (cr == NULL) return;

		data << uint32(cr->Name.size()+1);
		data.append (cr->Name.c_str(), cr->Name.size());
		data << (uint8)0x00;
	} else 
	if (GetTypeId() == TYPE_PLAYER)
	{
		Player *player = (Player *)this;
		data << uint32(strlen (player->GetName()) + 1);
		data.append (player->GetName(), strlen (player->GetName()));
		data << (uint8)0x00;
	}

	data << receiver->GetGUID();

	data << uint32(strlen (text)+1);
	data.append (text, strlen (text));
	data << (uint16)0x00;

	SendMessageToSet (&data, true);
}

//-----------------------------------------------------------------------------
void Unit::Emote (EmoteType emote)
{
	WorldPacket		data;
	data.Initialize (SMSG_EMOTE);
	data << uint32(emote);
	data << this->GetGUID();
	SendMessageToSet (&data, true);
}
//-----------------------------------------------------------------------------
// Minimap Tracking status On or Off
void Unit::MinimapTrackingStatus( bool bEnabled )
{
	uint32 dynflags = GetUInt32Value( UNIT_DYNAMIC_FLAGS );

	if ( ( dynflags & UNIT_DYNFLAG_TRACK_UNIT ) == UNIT_DYNFLAG_TRACK_UNIT )
	{
		if (!bEnabled) 
		{
			dynflags = dynflags - UNIT_DYNFLAG_TRACK_UNIT;
			SetUInt32Value( UNIT_DYNAMIC_FLAGS, UNIT_DYNFLAG_TRACK_UNIT);
		}

		return;
	} else
	{
		if (bEnabled) 
		{
			dynflags = dynflags + UNIT_DYNFLAG_TRACK_UNIT;
			SetUInt32Value( UNIT_DYNAMIC_FLAGS, UNIT_DYNFLAG_TRACK_UNIT);
		}
	}
}

//--- END ---