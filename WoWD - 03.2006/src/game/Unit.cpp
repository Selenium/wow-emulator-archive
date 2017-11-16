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
#include "Log.h"
#include "Opcodes.h"
#include "WorldPacket.h"
#include "WorldSession.h"
#include "World.h"
#include "ObjectMgr.h"
#include "Object.h"
#include "Unit.h"
#include "Quest.h"
#include "Player.h"
#include "Creature.h"
#include "AIInterface.h"
#include "Spell.h"
#include "Stats.h"
#include "Group.h"
#include "Affect.h"
#include "Duel.h"
#include "../script/Engine.h"


class LuaEngine;

Unit::Unit() : Object()
{
	m_objectType |= TYPE_UNIT;
	m_objectTypeId = TYPEID_UNIT;

	m_attackTimer = 0;
	m_lastDamage = 0;

	m_state = 0;
	m_deathState = ALIVE;
	m_currentSpell = NULL;
	m_meleeSpell = false;
	m_addDmgOnce = NULL;
	m_TotemSlot1 = m_TotemSlot2 = m_TotemSlot3 = m_TotemSlot4  = 0;
	m_aura = NULL;
	m_auraCheck = 2000;
	m_removeAuraTimer = 4;
	tmpAffect = NULL;
	m_silenced = false;
	hasAffects = false;
	m_meleespell = NULL;
	creature_info = NULL;

	// Pet
	m_pet_state = 0;
	m_Pet=false;

	//DK:modifiers
	m_damageImmune = 0;
    m_pacified = 0;
	m_manaShield = false;
	m_interruptRegen = 0;
	m_resistChance = 0;
	m_castedCurse = false;
    m_meleeDamageSplitPCT = 0;
    m_spellDamageSplitPCT = 0;
    m_powerRegenPCT = 0;
    m_damageTakenSpell = 0;
    m_meleeDamageTaken = 0;
    m_meleeDamageTakenPCT = 0;
    m_damageTakenPCT = 0;
    m_schoolAbsorb = 0;
    m_damageHeal = 0;
    m_stunned = 0;
    m_damageTakenPCT = 0;

	bool m_useAI = false;
	if(GetTypeId() == TYPEID_UNIT)
		bool m_useAI = true;

	
	PhysicalArmor = 0;
	MagicalArmor = 0;
	ActualArmor = 0;
//	if(GetTypeId() == TYPEID_PLAYER) //only player for now
//		CalculateActualArmor();

	m_aiInterface = new AIInterface();
	m_aiInterface->Init(this, AITYPE_AGRO, MOVEMENTTYPE_NONE, sLuaManager.getEngine(0));
}

void Unit::_setFaction()
{
	FactionTemplateDBC* factT = sFactionTmpStore.LookupEntry(GetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE));

	myFaction = 0;
	hostile = 0;
	combatSupport = 0;

	if(!factT)
	{
		return;
	}
	myFaction = factT->myFaction;
	if(GetTypeId() == TYPEID_PLAYER)
	{
		myFaction += 1;
	}
	else
	{
		FactionDBC* factB = sFactionStore.LookupEntry(factT->FactionId);
		if(factB->FactionGroup == 0)
		{
			myFaction += 8;
		}
	}

	hostile = factT->hostile;
	combatSupport = factT->fightSupport;
}


Unit::~Unit()
{
}


void Unit::Update( uint32 p_time )
{
	if(m_lastDamage > 0)
	{
		if(p_time > m_lastDamage)
		{
			m_lastDamage = 0;
		}else
		{
			m_lastDamage -= p_time;
		}
	}

	if(p_time > m_auraCheck){
		m_auraCheck = 2000;
		_UpdateAura();
	}else
		m_auraCheck -= p_time;

	_UpdateSpells( p_time );

	if(m_regenTimer > 0)       
	{
		if(p_time >= m_regenTimer)
			m_regenTimer = 0;
		else
			m_regenTimer -= p_time;     
	}

	if(m_attackTimer > 0)
	{
		if(p_time >= m_attackTimer)
			m_attackTimer = 0;
		else
			m_attackTimer -= p_time;
	}

	if(m_useAI == true)
		m_aiInterface->Update(p_time);

	//only players have stats
	if(this->GetTypeId() == TYPEID_PLAYER) StatListener();
}


void Unit::setAttackTimer(uint32 time)
{
	time ? m_attackTimer = time : m_attackTimer = GetUInt32Value(UNIT_FIELD_BASEATTACKTIME);
}


bool Unit::canReachWithAttack(Unit *pVictim)
{
	float targetreach = pVictim->GetFloatValue(UNIT_FIELD_COMBATREACH);
	float selfreach = GetFloatValue(UNIT_FIELD_COMBATREACH);
	float targetradius = pVictim->GetFloatValue(UNIT_FIELD_BOUNDINGRADIUS);
	float selfradius = GetFloatValue(UNIT_FIELD_BOUNDINGRADIUS);
	float targetscale = pVictim->GetFloatValue(OBJECT_FIELD_SCALE_X);
	float selfscale = GetFloatValue(OBJECT_FIELD_SCALE_X);

	float distance = sqrt(GetDistanceSq(pVictim));

	if (distance < (((pow(targetradius,2)*targetscale) + selfreach) + ((pow(selfradius,2)*selfscale)+1.50)))
		return true;

	return false;
}

void Unit::CalculateActualArmor()
{
	PhysicalArmor = 0;
	if(GetTypeId() == TYPEID_PLAYER)
	{
		Item* item;
		for(uint32 i = EQUIPMENT_SLOT_START;i<EQUIPMENT_SLOT_END;++i)
		{
			item = ((Player*)this)->GetItemBySlot(i);
			if(item)
			{
				if(item->GetProto())
				{
					PhysicalArmor += item->GetProto()->Armor;
				}
			}
		}

		// Armor (Formula from WowwoW)
		ActualArmor = 2 * GetUInt32Value(UNIT_FIELD_STAT1) + PhysicalArmor + MagicalArmor;
		//SetUInt32Value(UNIT_FIELD_RESISTANCES,PhysicalArmor + MagicalArmor);
	}
}
void Unit::DealDamage(Unit *pVictim, uint32 damage, uint32 procFlag, uint32 targetEvent, uint32 unitEvent)
{
	if(pVictim->IsDamageImmune())
	{
		//SMSG_SPELLORDAMAGE_IMMUNE
		damage = 0;
		/*
		data.Initialize(SMSG_CAST_RESULT);
		data << uint32(0);
		data << uint8(2);
		data << uint8(SPELL_FAILED_IMMUNE);
		SendPacket(&data,true);*/		
	}

	// Increase Rage
	if (pVictim->GetTypeId() == TYPEID_PLAYER)
	{
		if( getClass() == WARRIOR )
		{
			pVictim->CalcRage(damage, true);
		}
	}
	if(GetTypeId() == TYPEID_PLAYER)
	{
		if( getClass() == WARRIOR )
		{
			CalcRage(damage, false);
		}
	}

    // Add spell time
	if ((damage != 0) && (pVictim->m_currentSpell))
	{
		pVictim->m_currentSpell->AddTime();
	}

    // Skill Update
	if ((damage != 0) && (pVictim->GetTypeId() == TYPEID_PLAYER))
	{
		Player *pr = ((Player*)pVictim);
		if (pr->GetSkillAmt(95) < pr->GetSkillMax(95))
		{
			if (((float)(rand()%100)) < pr->GetSkillUpChance(95))
			{
				pr->ModSkillLine(95,1);
				pr->SetFloatValue(PLAYER_DODGE_PERCENTAGE,((pr->GetUInt32Value( UNIT_FIELD_STAT1) / 14.5) + (pr->GetSkillAmt(95)*.04)));
				pr->SetFloatValue(PLAYER_BLOCK_PERCENTAGE,pr->GetUInt32Value( UNIT_FIELD_STAT0) / 30.0);
				if (pr->GetItemBySlot(EQUIPMENT_SLOT_OFFHAND))
					pr->SetFloatValue(PLAYER_BLOCK_PERCENTAGE,((pr->GetUInt32Value( UNIT_FIELD_STAT0) / 30.0)+ pr->GetItemBySlot(EQUIPMENT_SLOT_OFFHAND)->GetProto()->Block));
				pr->SetFloatValue(PLAYER_PARRY_PERCENTAGE,(pr->GetSkillAmt(95)*.04));
			}
		}

	}

	//Log::getSingleton( ).outError("DealDamageStart");
	uint32 health = pVictim->GetUInt32Value(UNIT_FIELD_HEALTH );
	uint32 maxhealth = pVictim->GetUInt32Value(UNIT_FIELD_MAXHEALTH );
	if((pVictim->GetTypeId() == TYPEID_PLAYER) && (GetTypeId() == TYPEID_PLAYER)) //Both Players
	{
		if((health <= damage) && ((Player *)this)->DuelingWith != NULL)
		{
			//Player in Duel and Player Victim has lost
			uint32 NewHP = pVictim->GetUInt32Value(UNIT_FIELD_MAXHEALTH)/100;
			if(NewHP < 5) NewHP = 5;

			//Set there health to 1% or 5 if 1% is lower then 5
			pVictim->SetUInt32Value(UNIT_FIELD_HEALTH, NewHP);
			//End Duel
			sDuelHandler.EndDuel((Player *)this,DUEL_WINNER_KNOCKOUT);
			return;
		}
	}

	if (health <= damage && pVictim->isAlive())
	{
		pVictim->GetAIInterface()->OnDeath();
		//Log::getSingleton( ).outError("DealDamageDied");

		if(pVictim->GetTypeId() == TYPEID_UNIT)
        {
            if(GetTypeId() == TYPEID_PLAYER || IsPet())
            {
                ((Creature*)pVictim)->generateLoot();
            }
        }

		/*
		//FIXME: should we remove all equipment affects too
		if(pVictim->GetTypeId() == TYPEID_PLAYER)
		_RemoveAllItemMods();
		*/
		/* victim died! */
		pVictim->setDeathState(JUST_DIED);

		//Log::getSingleton( ).outError("DealDamageAffects");
		pVictim->RemoveAllAffects();

		/*
		Send SMSG_PARTYKILLLOG 0x1e6
		To everyone in the party?
		*/
		/* SMSG_ATTACKSTOP */
		uint64 attackerGuid, victimGuid;
		attackerGuid = GetGUID();
		victimGuid = pVictim->GetGUID();

		//Log::getSingleton( ).outError("DealDamageAttackStop");
		pVictim->smsg_AttackStop(attackerGuid);

		/* Send MSG_MOVE_ROOT   0xe7 */

		/*
		Set update values... try flags 917504
		health
		*/
		//Log::getSingleton( ).outError("DealDamageHealth1");
		//pVictim->SetUInt32Value(UNIT_FIELD_HEALTH, 0);

		/* then another update message, sets health to 0, maxhealth to 100, and dynamic flags */
		//Log::getSingleton( ).outError("DealDamageHealth2");
		pVictim->SetUInt32Value(UNIT_FIELD_HEALTH, 0);
		pVictim->RemoveFlag(UNIT_FIELD_FLAGS, U_FIELD_FLAG_ATTACK_ANIMATION);

		if (pVictim->GetTypeId() != TYPEID_PLAYER)
		{
			//Log::getSingleton( ).outError("DealDamageNotPlayer");
			pVictim->SetUInt32Value(UNIT_DYNAMIC_FLAGS, U_DYN_FLAG_LOOTABLE);
		}
        if(pVictim->GetTypeId() == TYPEID_PLAYER && pVictim->GetUInt64Value(UNIT_FIELD_SUMMON) > 0)
        {
            Creature *pet = objmgr.GetCreature(pVictim->GetUInt64Value(UNIT_FIELD_SUMMON));
            if(pet)
			{
				((Player *)pVictim)->SetPet(NULL);
				((Player *)pVictim)->SetPetName("");
				pVictim->SetUInt64Value(UNIT_FIELD_SUMMON, 0);
				//TODO:Add other things
				WorldPacket data;
				data.Initialize(SMSG_PET_SPELLS);
				data << uint64(0);
                ((Player *)pVictim)->GetSession()->SendPacket(&data);
		        pet->RemoveFromWorld();
		        objmgr.RemoveObject(pet);
		        delete pet;
			}
            else
            {
                pVictim->SetUInt64Value(UNIT_FIELD_SUMMON, 0);
            }
        }

		if (GetTypeId() == TYPEID_PLAYER)
		{
			sLog.outDebug("Calculate XP");
			uint32 xp = 0;
			xp = CalculateXpToGive(pVictim, this);
			sLog.outDebug("XP: %u",xp);

			if (pVictim->GetTypeId() != TYPEID_PLAYER)
				sQuestMgr.OnPlayerKill((Player*)this, (Creature*)pVictim);

			// Is this player part of a group?
            if(((Player*)this)->IsInGroup())
            {
			    Group *pGroup = objmgr.GetGroupByLeader(((Player*)this)->GetGroupLeader());
			    if (pGroup)
			    {
				    //Log::getSingleton( ).outError("DealDamageInGroup");
				    xp /= pGroup->GetMembersCount();
				    for (uint32 i = 0; i < pGroup->GetMembersCount(); i++)
				    {
					    Player *pGroupGuy = objmgr.GetObject<Player>(pGroup->GetMemberGUID(i));
					    pGroupGuy->GiveXP(xp, victimGuid);
				    }
			    }
                else
                {
				    Raid *pRaid = objmgr.GetRaidByLeader(((Player*)this)->GetGroupLeader());
				    if(pRaid)
				    {
					    xp /= pRaid->GetMembersCount(); //need better formula
					    pRaid->GiveXPToRaid(xp, victimGuid);
				    }
			    }
            }
            else
			{
			    //Log::getSingleton( ).outError("DealDamageNotInGroup");
			    // update experience
			   ((Player*)this)->GiveXP(xp, victimGuid);
		    }
		}
		else
		{
			//Log::getSingleton( ).outError("DealDamageIsCreature");
			smsg_AttackStop(victimGuid);
			RemoveFlag(UNIT_FIELD_FLAGS, U_FIELD_FLAG_ATTACK_ANIMATION);
			addStateFlag(UF_TARGET_DIED);
			if (pVictim->IsPet())
			{
				Player *petOwner = objmgr.GetPlayer(pVictim->GetUInt64Value(UNIT_FIELD_SUMMONEDBY));
				if(petOwner)
				{
					petOwner->SetPet(NULL);
					petOwner->SetPetName("");
					petOwner->SetUInt64Value(UNIT_FIELD_SUMMON, 0);
					//TODO:Add other things
					WorldPacket data;
					data.Initialize(SMSG_PET_SPELLS);
					data << uint64(0);
					petOwner->GetSession()->SendPacket(&data);
				}
				pVictim->RemoveFromWorld();
				objmgr.RemoveObject(((Creature *)pVictim));
				delete pVictim;
			}
		}
	}
	else
	{
		//Log::getSingleton( ).outError("DealDamageAlive");
        pVictim->SetUInt32Value(UNIT_FIELD_HEALTH , health - damage);
		// this need alot of work.
		addStateFlag(UF_ATTACKING); /* player is been attacked so they can't regen */
		if (GetTypeId() != TYPEID_PLAYER)
		{
			GetAIInterface()->AttackReaction(pVictim, damage, unitEvent + 0xFF);
		}
		if (pVictim->GetTypeId() != TYPEID_PLAYER)
		{
			pVictim->m_lastDamage = uint32(10000);
			((Creature*)pVictim)->GetAIInterface()->AttackReaction(this, damage, targetEvent);
		}
		else
		{
			//((Player*)pVictim)->addStateFlag(UF_ATTACKING); /* player is been attacked so they can't regen */

			pVictim->m_lastDamage = uint32(10000);
		}

		for(std::list<struct DamageShield>::iterator i = pVictim->m_damageShields.begin();i != pVictim->m_damageShields.end();i++)      // Deal Damage to Attacker
		{
			pVictim->SpellNonMeleeDamageLog(this,i->m_spellId,i->m_damage);
		}
		/*
		//Commented out as it is not doing any thing ? a few printf's maybe besides that nothing
		for(std::list<struct ProcTriggerSpell>::iterator itr = pVictim->m_procSpells.begin();itr != pVictim->m_procSpells.end();itr++)  // Proc Trigger Spells for Victim
		{
		printf("Proc Trigger spell: %u\n", itr->spellId);
		printf("proc: %u, %u, %u\n", itr->procChance,itr->procFlags,itr->procCharges);
		//            if(rand()%100 < itr->procChance);
		//pVictim->HandleProc(itr, procFlag);
		}

		for(std::list<struct ProcTriggerSpell>::iterator itr = m_procSpells.begin();itr != m_procSpells.end();itr++)  // Proc Trigger Spells for Attacker
		{
		printf("Proc Trigger spell: %u\n", itr->spellId);
		printf("proc: %u, %u, %u\n", itr->procChance,itr->procFlags,itr->procCharges);
		//            if(rand()%100 < itr->procChance);
		//HandleProc(itr, procFlag);
		}
		*/

	}
	//Log::getSingleton( ).outError("DealDamageEnd");
}
/*
void Unit::HandleProc(ProcTriggerSpell* pts, uint32 flag)
{
cast = false;
switch(procFlags)
{
case 1:{        // on hit melee
}break;
case 2:{        // on struck melee
}break;
case 4:{        // on kill xp giver
}break;
case 8:{        // unknown
}break;
case 16:{       // on dodge 
}break;
case 32:{       // unknown
}break;
case 64:
case 66:{       // on block    
}break;
case 112:{      // unknown      
}break;
case 128:
case 129:{      // on next melee attack
}break;
case 256:{      // on cast spell
}break;
case 1026:{     // on struck
}break;
case 1138:
case 1139:{     // unknown
}break;
case 2048:{     // on hit ranged
}break;
case 4096:{     // on hit critical
}break;
case 8192:{     // on struck critical melee
}break;
case 16384:{    // on cast spell
}break;
case 32768:{    // on take damage
}break;
case 65536:{    // on hit critical spell
}break;
case 69632:{    // on critical melee
}break;
case 131072:{   // on hit spell
}break;
case 270336:{   // on struck critical
}break;
case 1048578:{  // on struck in combat
}break;
case 1049602:{  // on struck melee/ranged
}break;
default:{
}break;
}
if(cast)
CastSpell(this, pVictim, itr->spellId, true);
}
*/

void Unit::CastSpell(Unit* caster,Unit* Victim, uint32 spellId, bool triggered)
{
	// check for spell id
	SpellEntry *spellInfo = sSpellStore.LookupEntry(spellId );

	if(!spellInfo)
	{
		Log::getSingleton( ).outError("WORLD: unknown spell id %i\n", spellId);
		return;
	}

	Spell *spell = new Spell(caster, spellInfo, triggered, 0,false);
	WPAssert(spell);

	SpellCastTargets targets;
	targets.m_unitTarget = Victim->GetGUID();
	spell->prepare(&targets);
	m_canMove = false;
	//m_currentSpell = spell;
}

bool Unit::isCasting()
{
	return m_currentSpell == NULL ? false : true;
}

void Unit::CalcRage( uint32 damage, bool isVictim )
{
	/* Calculate Rage */
	uint32 oldRage = GetUInt32Value(UNIT_FIELD_POWER2);
	uint32 maxRage = GetUInt32Value(UNIT_FIELD_MAXPOWER2);
	
	double mod = 0.5;
	if(isVictim)
		mod = 1.5;
	else
		mod = 0.5;

	double addRage = (double(damage)/double(mod*getLevel()))*10;
	//sLog.outDebug("AddRage = %u\n",uint32(addRage));
    //addRage/= 2;
	//sLog.outDebug("AddRage = %u\n",uint32(addRage));
    if(addRage < 0 ) addRage = 1;
	uint32 Rage = oldRage + uint32(addRage); 
	if (Rage > maxRage) Rage = maxRage;

	/* set the new rage */
	SetUInt32Value(UNIT_FIELD_POWER2, Rage);
}

void Unit::RegenerateAll()
{

	/*
	Added so that every thing regenerates at the same time
	instead of one regenerating till full then other starting
	*/

	/* check if it's time to regen health */
	if (m_regenTimer != 0)
		return;

	uint32 regenDelay = 2000; 	/* Regenerate health, mana and energy if necessary. */
	if (m_lastDamage == 0) /* NOT in Combat */
	{
		Regenerate( UNIT_FIELD_HEALTH, UNIT_FIELD_MAXHEALTH, true );
		Regenerate( UNIT_FIELD_POWER2, UNIT_FIELD_MAXPOWER2, false );
	}
	/* Mana Regenerates while in combat but not for 5 seconds after each spell */
	Regenerate( UNIT_FIELD_POWER4, UNIT_FIELD_MAXPOWER4, true );
	Regenerate( UNIT_FIELD_POWER1, UNIT_FIELD_MAXPOWER1, true );//mana

	m_regenTimer = regenDelay; 

}

/// Regenerates the regenField's curValue to the maxValue
/// Right now, everything regenerates at the same rate
/// A possible mod is to add another parameter, the stat regeneration is based off of (Intelligence for mana, Strength for HP)
/// And build a regen rate based on that 
void Unit::Regenerate(uint16 field_cur, uint16 field_max, bool switch_)
{
	//DK:modifier
	if (m_interruptRegen)
		return;
	//finish

	uint32 curValue = GetUInt32Value(field_cur);
	uint32 maxValue = GetUInt32Value(field_max); 	if (switch_)
	{
		if (curValue >= maxValue)
			return;
	}
	else
	{
		if (curValue == 0)
			return;
	}

	float HealthIncreaseRate = sWorld.getRate(RATE_HEALTH);
	float ManaIncreaseRate = sWorld.getRate(RATE_POWER1);
	float RageIncreaseRate = sWorld.getRate(RATE_POWER2);
	float EnergyIncreaseRate = sWorld.getRate(RATE_POWER3);
	uint16 Spirit = GetUInt32Value(UNIT_FIELD_STAT4);
	uint16 Class = getClass();


	if( HealthIncreaseRate <= 0 ) HealthIncreaseRate = 1;
	if( ManaIncreaseRate <= 0 ) ManaIncreaseRate = 1;
	if( RageIncreaseRate <= 0 ) RageIncreaseRate = 1;
	if( EnergyIncreaseRate <= 0 ) EnergyIncreaseRate = 1;

    if(m_powerRegenPCT)
    {
        GetPowerRegenPCT(&HealthIncreaseRate, &ManaIncreaseRate, &RageIncreaseRate, &EnergyIncreaseRate);
    }



	/*
	//Log::getSingleton( ).outError("Regen Health Rate: %f\n", HealthIncreaseRate);
	//Log::getSingleton( ).outError("Regen Mana Rate: %f\n", ManaIncreaseRate);
	//Log::getSingleton( ).outError("Regen Rage Rate: %f\n", RageIncreaseRate);
	//Log::getSingleton( ).outError("Regen Energy Rate: %f\n", EnergyIncreaseRate);
	//Log::getSingleton( ).outError("Spirit: %i\n", Spirit);
	//Log::getSingleton( ).outError("CurrentValue: %i\n", curValue);
	//Log::getSingleton( ).outError("Class: %i\n", Class);
	*/

	uint32 oldCurValue = curValue;

	uint32 addvalue = 0;

	switch (field_cur)
	{

		/* mod by hann */
	case UNIT_FIELD_HEALTH:
		{

			switch (Class)
			{
			case 1: /* Warrior = 1 */
				{
					addvalue = uint32(((Spirit*0.80) * HealthIncreaseRate));
					break;
				}
			case 2: /* Paladin = 2 */
				{
					addvalue = uint32(((Spirit*0.25) * HealthIncreaseRate));
					break;
				}
			case 3: /* Hunter = 3 */
				{
					addvalue = uint32(((Spirit*0.25) * HealthIncreaseRate));
					break;
				}
			case 4: /* Rogue = 4 */
				{
					addvalue = uint32(((Spirit*0.50) * HealthIncreaseRate));
					break;
				}
			case 5: /* Priest = 5 */
				{
					addvalue = uint32(((Spirit*0.10) * HealthIncreaseRate));
					break;
				}
			case 7: /* Shaman = 7 */
				{
					addvalue = uint32((((Spirit*0.11)+9) * HealthIncreaseRate));
					break;
				}
			case 8: /* Mage = 8 */
				{
					curValue+=uint32(((Spirit*0.10) * HealthIncreaseRate));
					break;
				}
			case 9: /* Warlock = 9 */
				{
					addvalue = uint32(((Spirit*0.11) * HealthIncreaseRate));
					break;
				}
			case 11: /* Druid = 11 */
				{
					/* TODO: change this one, cause on wowwow's forums hp regen
					formula for druid was UNKNOWN */
					addvalue = uint32(((Spirit+10) * HealthIncreaseRate));
					break;
				}
			default: /* Poor Creatures got left out */
				{
					addvalue = uint32(((Spirit+10) * HealthIncreaseRate));
					break;
				}
			}
			break;
		}

		/* mod by hann */
	case UNIT_FIELD_POWER1: /* mana */
		{

			switch (Class)
			{		
			case 2: /* Paladin = 2 */
				{
					addvalue = uint32((((Spirit/4)+8) * ManaIncreaseRate));
					break;
				}
			case 3: /* Hunter = 3 */
				{
					addvalue = uint32((((Spirit/4)+11) * ManaIncreaseRate));
					break;
				}
			case 5: /* Priest = 5 */
				{
					addvalue = uint32((((Spirit/4)+13) * ManaIncreaseRate));
					break;
				}
			case 7: /* Shaman = 7 */
				{
					addvalue = uint32((((Spirit/5)+17) * ManaIncreaseRate));
					break;
				}
			case 8: /* Mage = 8 */
				{
					addvalue = uint32((((Spirit/4)+11) * ManaIncreaseRate));
					break;
				}
			case 9: /* Warlock = 9 */
				{
					addvalue = uint32((((Spirit/4)+8) * ManaIncreaseRate));
					break;
				}
			case 11: /* Druid = 11 */
				{
					addvalue = uint32((((Spirit/5)+15) * ManaIncreaseRate));
					break;
				}
			default: /* Poor Creatures got left out */
				{
					addvalue = uint32((Spirit * ManaIncreaseRate));
					break;	
				}
			}
			break;

		}

	case UNIT_FIELD_POWER2: /* rage */
		{
			/* formula for rage required */ //~5min to fully degen
			addvalue = uint32((24 * RageIncreaseRate));
			break;
		}


	case UNIT_FIELD_POWER4: /* energy */
		{

			addvalue = uint32(20);  
			break;
		}

	default:
		{
			break;
		}
	}

	if(addvalue == 0) addvalue = 1; /* min rate of 1 */

	if (switch_)
	{
		if((getStandState() == 1) || (getStandState() == 3))
		{
			/* we are sitting */
			addvalue *= 2;
		}

		curValue += addvalue;
		if (curValue > maxValue) curValue = maxValue;
		SetUInt32Value(field_cur, curValue);
	}
	else
	{
		curValue -= addvalue;
		if (curValue > maxValue) curValue = 0;
		SetUInt32Value(field_cur, curValue);
	}

}


//================================================================================================
//  AttackerStateUpdate
//  This function determines whether there is a hit, and the resultant damage
//================================================================================================
void Unit::SpellNonMeleeDamageLog(Unit *pVictim, uint32 spellID, uint32 damage)
{
	uint32 procFlag = 0;
	WorldPacket data;

	if(!this || !pVictim)
		return;
	if(!this->isAlive() || !pVictim->isAlive())
		return;

	//DK:Immune
	if(damage == 0 && m_damageImmune)
	{
		data.Initialize(SMSG_CAST_RESULT);
		data << spellID;
		data << uint8(2);
		data << uint8(SPELL_FAILED_IMMUNE);
		SendMessageToSet(&data,true);
		DealDamage(pVictim, 0, procFlag, 2, 0);
	}
	else
	{
		// Log::getSingleton( ).outDetail("SpellNonMeleeDamageLog: %u %X attacked %u %X for %u dmg inflicted by %u",
		//   GetGUIDLow(), GetGUIDHigh(), pVictim->GetGUIDLow(), pVictim->GetGUIDHigh(), damage, spellID);

        data.Initialize(SMSG_SPELLNONMELEEDAMAGELOG);
        data << pVictim->GetNewGUID();
        data << this->GetNewGUID();
        data << spellID;
        data << damage;
        data << uint32(0);
        data << uint32(0);
        data << uint32(0);
        data << uint16(0);
		data << uint8(0);
		data << uint8(5);
		data << uint32(0);
        SendMessageToSet(&data,true);

        if(pVictim->HasSpellDamageSplit())
            damage = pVictim->SplitDamagePCT(damage, 126);

        if(pVictim->HasDamageTakenSpell())
            damage = pVictim->GetDamageModTakenSpells(damage, false);

        if(pVictim->HasSchoolAbsorb() || pVictim->HasDamageTakenPCT())
        {
            SpellEntry *spellInfo = sSpellStore.LookupEntry( spellID );        

            if(pVictim->HasSchoolAbsorb())
            {
                if(spellInfo)
                {
                    damage = pVictim->GetSchoolAbsorb(damage,spellInfo->School);
                }
            }

            if(pVictim->HasDamageTakenPCT())
            {
                if(spellInfo)
                {
                    pVictim->GetDamageModTaken(damage, true, pow(double(2),int(spellInfo->School+1)));
                }
            }
        
        }
        if(pVictim->HasDamageHeal())
            pVictim->DamageHeal(damage);

        DealDamage(pVictim, damage, procFlag, 0, 0);
	}
}

void Unit::PeriodicAuraLog(Unit *pVictim, uint32 spellID, uint32 damage, uint32 damageType)
{
	uint32 procFlag = 0;
	if(!this || !pVictim)
		return;
	if(!this->isAlive() || !pVictim->isAlive())
		return;
	// Log::getSingleton( ).outDetail("PeriodicAuraLog: %u %X attacked %u %X for %u dmg inflicted by %u",
	//   GetGUIDLow(), GetGUIDHigh(), pVictim->GetGUIDLow(), pVictim->GetGUIDHigh(), damage, spellID);

	WorldPacket data;
	data.Initialize(SMSG_PERIODICAURALOG);
	data << pVictim->GetNewGUID();
	data << this->GetNewGUID();
	data << spellID;
	data << uint32(1);  // Target Count ?

	data << uint32(3);  // unknown if its somethine else then 3, then nothing shows up in CombatLog
	data << damage;
	data << damageType;
	data << uint32(0);
	SendMessageToSet(&data,true);

    if(pVictim->HasSpellDamageSplit())
        damage = pVictim->SplitDamagePCT(damage, 126);

    if(pVictim->HasDamageTakenSpell())
        damage = pVictim->GetDamageModTakenSpells(damage, false);

    if(pVictim->HasSchoolAbsorb() || pVictim->HasDamageTakenPCT())
    {
        SpellEntry *spellInfo = sSpellStore.LookupEntry( spellID );    

        if(pVictim->HasSchoolAbsorb())
        {
            if(spellInfo)
            {
                damage = pVictim->GetSchoolAbsorb(damage,spellInfo->School);
            }
        }

        if(pVictim->HasDamageTakenPCT())
        {
            if(spellInfo)
            {
                pVictim->GetDamageModTaken(damage, true, pow(double(2),int(spellInfo->School+1)));
            }
        }
    }

    if(pVictim->HasDamageHeal())
        pVictim->DamageHeal(damage);

	DealDamage(pVictim, damage, procFlag, 0, 0);
}
uint32 Unit::GetDamageModGiven(uint32 type)
{
	AffectList::iterator i;
	Affect::ModList::const_iterator j;
	Affect *aff;
	int in = 0;
    //We can fasten these by using updatefields
    //FIXME:Use update fields for players
    //PLAYER_FIELD_MOD_DAMAGE_DONE_POS
	for (i = m_affects.begin(); i != m_affects.end(); i++)
	{
		aff = *i;
		for (j = aff->GetModList().begin();j != aff->GetModList().end(); j++)
		{
			Modifier mod = (*j);
			if ((mod.GetType() == SPELL_AURA_MOD_DAMAGE_DONE) && (mod.GetMiscValue() == type))
			{
				SpellEntry *spellInfo = sSpellStore.LookupEntry(aff->GetSpellId());
				in += (spellInfo->EffectBasePoints[in] + 1);
			}
		}
	}
	return in;
}
uint32 Unit::GetDamageModGivenPercent(uint32 type)
{
	AffectList::iterator i;
	Affect::ModList::const_iterator j;
	Affect *aff;
	int in = 0;
	for (i = m_affects.begin(); i != m_affects.end(); i++)
	{
		aff = *i;
		for (j = aff->GetModList().begin();j != aff->GetModList().end(); j++)
		{
			Modifier mod = (*j);
			if ((mod.GetType() == SPELL_AURA_MOD_DAMAGE_PERCENT_DONE) && (mod.GetMiscValue() == type))
			{
				SpellEntry *spellInfo = sSpellStore.LookupEntry(aff->GetSpellId());
				in += (spellInfo->EffectBasePoints[in] + 1);
			}
		}
	}
	return in;
}

uint32 Unit::GetDamageModTakenSpells(uint32 damage, bool PCT)
{
	AffectList::iterator i;
	Affect::ModList::const_iterator j;
	Affect *aff;
	int in = 0;
    if(PCT)
    {
/*	    for (i = m_affects.begin(); i != m_affects.end(); i++)
	    {
		    aff = *i;
		    for (j = aff->GetModList().begin();j != aff->GetModList().end(); j++)
		    {
			    Modifier mod = (*j);
			    if (mod.GetType() == SPELL_AURA_MOD_DAMAGE_TAKEN_PCT)
			    {
                    damage = damage + mod.GetAmount()/100;
			    }
		    }
	    }*/
    }
    else
    {
	    for (i = m_affects.begin(); i != m_affects.end(); i++)
	    {
		    aff = *i;
		    for (j = aff->GetModList().begin();j != aff->GetModList().end(); j++)
		    {
			    Modifier mod = (*j);
			    if (mod.GetType() == SPELL_AURA_MOD_DAMAGE_TAKEN)
			    {
                    damage = damage + mod.GetAmount();
                    if(damage > 4294800000)
                        damage = 0;                  
			    }
		    }
	    }
    }
	return damage;
}

uint32 Unit::GetDamageModTakenMelee(uint32 damage, bool PCT)
{
	AffectList::iterator i;
	Affect::ModList::const_iterator j;
	Affect *aff;
	int in = 0;
    if(PCT)
    {
	    for (i = m_affects.begin(); i != m_affects.end(); i++)
	    {
		    aff = *i;
		    for (j = aff->GetModList().begin();j != aff->GetModList().end(); j++)
		    {
			    Modifier mod = (*j);
			    if (mod.GetType() == SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN_PCT)
			    {
                    damage = damage + (damage*mod.GetAmount())/100;
			    }
		    }
	    }
    }
    else
    {
	    for (i = m_affects.begin(); i != m_affects.end(); i++)
	    {
		    aff = *i;
		    for (j = aff->GetModList().begin();j != aff->GetModList().end(); j++)
		    {
			    Modifier mod = (*j);
			    if (mod.GetType() == SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN)
			    {
                    damage = damage + mod.GetAmount();
                    if(damage > 4294800000)
                        damage = 0;  
			    }
		    }
	    }
    }
	return damage;
}

uint32 Unit::GetDamageModTaken(uint32 damage, bool PCT, uint32 damageFlag)
{
	AffectList::iterator i;
	Affect::ModList::const_iterator j;
	Affect *aff;
	int in = 0;
    if(PCT)
    {
	    for (i = m_affects.begin(); i != m_affects.end(); i++)
	    {
		    aff = *i;
		    for (j = aff->GetModList().begin();j != aff->GetModList().end(); j++)
		    {
			    Modifier mod = (*j);
                if (mod.GetType() == SPELL_AURA_MOD_DAMAGE_PERCENT_TAKEN && (mod.GetMiscValue() & damageFlag))
			    {
                    damage = damage + (damage*mod.GetAmount())/100;
			    }
		    }
	    }
    }
/*    else
    {
	    for (i = m_affects.begin(); i != m_affects.end(); i++)
	    {
		    aff = *i;
		    for (j = aff->GetModList().begin();j != aff->GetModList().end(); j++)
		    {
			    Modifier mod = (*j);
			    if (mod.GetType() == SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN)
			    {
                    damage = damage + mod.GetAmount();
			    }
		    }
	    }
    }*/
	return damage;
}

uint32 Unit::SplitDamagePCT(uint32 damage, uint32 type)
{
	AffectList::iterator i;
	Affect::ModList::const_iterator j;
	Affect *aff;
	int in = 0;
	for (i = m_affects.begin(); i != m_affects.end(); i++)
	{
		aff = *i;
		for (j = aff->GetModList().begin();j != aff->GetModList().end(); j++)
		{
			Modifier mod = (*j);
			if ((mod.GetType() == SPELL_AURA_SPLIT_DAMAGE) && (mod.GetMiscValue() & type))
			{
                uint32 split = (damage*mod.GetAmount())/100;
                damage = damage - split;
                Unit *Caster = aff->GetCaster();
                if(!Caster)
                    continue;
                if(type & 126)
                {
                    Caster->SpellNonMeleeDamageLog(Caster,aff->GetSpellId(),split);
                }
                else if(type & 1)
                {
                    Caster->DealDamage(Caster,split,0,0,0);
                }
			}
		}
	}
	return damage;
}

void Unit::GetPowerRegenPCT(float *hr, float *mr, float *rr, float *er)
{
	AffectList::iterator i;
	Affect::ModList::const_iterator j;
	Affect *aff;
	int in = 0;
	for (i = m_affects.begin(); i != m_affects.end(); i++)
	{
		aff = *i;
		for (j = aff->GetModList().begin();j != aff->GetModList().end(); j++)
		{
			Modifier mod = (*j);
			if (mod.GetType() == SPELL_AURA_MOD_POWER_REGEN_PERCENT)
			{
                switch(aff->GetSpellProto()->powerType)
                {
		            case POWER_TYPE_MANA:{
			            *mr = *mr + mod.GetAmount()/100;
		            }break;
		            case POWER_TYPE_RAGE:{
                        *rr = *rr + mod.GetAmount()/100;
		            }break;
                    case POWER_TYPE_FOCUS:{
                        sLog.outDebug("Focus:Regen percent not supported");
                    }break;
		            case POWER_TYPE_ENERGY:{
			            *er = *er + mod.GetAmount()/100;
		            }break;
                }
			}
		}
	}
}

uint32 Unit::GetSchoolAbsorb(uint32 damage, uint32 school)
{
	AffectList::iterator i;
	Affect::ModList::const_iterator j;
	Affect *aff;
	int in = 0;
	for (i = m_affects.begin(); i != m_affects.end(); i++)
	{
		aff = *i;
		for (j = aff->GetModList().begin();j != aff->GetModList().end(); j++)
		{
			Modifier mod = (*j);
            if ((mod.GetType() == SPELL_AURA_SCHOOL_ABSORB) && ((mod.GetMiscValue() == school) || mod.GetMiscValue() == -2))
			{
                damage = damage - mod.GetAmount();
                if(damage > 4294800000)
                    damage = 0;
			}
		}
	}
	return damage;
}

//FIXME:Only supports Vampiric Embrace
void Unit::DamageHeal(uint32 damage)
{
	AffectList::iterator i;
	Affect::ModList::const_iterator j;
	Affect *aff;
	int in = 0;
    uint32 heal;
	for (i = m_affects.begin(); i != m_affects.end(); i++)
	{
		aff = *i;
		for (j = aff->GetModList().begin();j != aff->GetModList().end(); j++)
		{
			Modifier mod = (*j);
            if ((mod.GetType() == SPELL_AURA_DUMMY) && (aff->GetUInt32GBValue(0) == SCHOOL_SHADOW))
			{
                Player *pMember;
                heal = (damage*aff->GetUInt32GBValue(1))/100;
                Player *pCaster = (Player *)aff->GetCaster();
                if(!pCaster)
                    continue;
                uint32 curHealth = 0;
                uint32 maxHealth = 0;

                curHealth = pCaster->GetUInt32Value(UNIT_FIELD_HEALTH);
                maxHealth = pCaster->GetUInt32Value(UNIT_FIELD_MAXHEALTH);
                if(curHealth+heal > maxHealth)
                    pCaster->SetUInt32Value(UNIT_FIELD_HEALTH,maxHealth);
                else
                    pCaster->SetUInt32Value(UNIT_FIELD_HEALTH,curHealth+damage);

                Group *pGroup = objmgr.GetGroupByLeader(pCaster->GetGroupLeader());
                if(pGroup)
                {
					for(uint32 p=0;p<pGroup->GetMembersCount();p++)
                    {
						pMember = objmgr.GetPlayer(pGroup->GetMemberGUID(p));
						if(!pMember)
							continue;
                        curHealth = pCaster->GetUInt32Value(UNIT_FIELD_HEALTH);
                        maxHealth = pCaster->GetUInt32Value(UNIT_FIELD_MAXHEALTH);
                        if(curHealth+heal > maxHealth)
                            pMember->SetUInt32Value(UNIT_FIELD_HEALTH,maxHealth);
                        else
                            pMember->SetUInt32Value(UNIT_FIELD_HEALTH,curHealth+damage);
                    }
                }
                else
                {
                    Raid *pGroup = objmgr.GetRaidByLeader(pCaster->GetGroupLeader());
                    if(!pGroup)
                        continue;
                  	std::list<SubRaidMembers*>::iterator itr;
                    RaidGroup raidGroup = pGroup->GetRaidGroup(pCaster->GetRaidSubGroup());
                    for(itr = raidGroup.subGroup.begin();itr != raidGroup.subGroup.end();)
		            {
                        pMember = objmgr.GetPlayer((*itr)->memberGuid);
                        if(!pMember)
                            continue;
                        curHealth = pMember->GetUInt32Value(UNIT_FIELD_HEALTH);
                        maxHealth = pMember->GetUInt32Value(UNIT_FIELD_MAXHEALTH);
                        if(curHealth+heal > maxHealth)
                            pMember->SetUInt32Value(UNIT_FIELD_HEALTH,maxHealth);
                        else
                            pMember->SetUInt32Value(UNIT_FIELD_HEALTH,curHealth+damage);
                        ++itr;
                    }                    
                }
			}
		}
	}
}

bool Unit::GetManaShieldAbsorb(uint32 damage,Unit *pVictim)
{
	AffectList::iterator i;
	Affect::ModList::const_iterator j;
	Affect *aff;
	int in = 0;
	for (i = m_affects.begin(); i != m_affects.end(); i++)
	{
		aff = *i;
		for (j = aff->GetModList().begin();j != aff->GetModList().end(); j++)
		{
			Modifier mod = (*j);
			if (mod.GetType() == SPELL_AURA_MANA_SHIELD)
			{
		        uint32 mana = pVictim->GetUInt32Value(UNIT_FIELD_POWER1);
                if(damage < mod.GetAmount())
                {
                    if((mana <= (2*damage)))
		            {
		                pVictim->SetUInt32Value(UNIT_FIELD_POWER1 , 0);
                        damage = damage - (mana/2);
                        if(damage > 4294800000)
                            damage = 0;                        
		            }
		            else
		            {
		                pVictim->SetUInt32Value(UNIT_FIELD_POWER1 , mana - (2*damage));
                        damage = 0;
		            }
                }
                else
                {
                    damage = damage - mod.GetAmount();
                    if((mana <= (2*mod.GetAmount())))
		            {
		                pVictim->SetUInt32Value(UNIT_FIELD_POWER1 , 0);
                        damage = damage + (damage - (mana/2));
                        if(damage > 4294800000)
                            damage = 0;                        
		            }
		            else
		            {
                        pVictim->SetUInt32Value(UNIT_FIELD_POWER1 , mana - (2*mod.GetAmount()));
		            }
                }
			}
		}
	}
	return damage;
}

void Unit::AttackerStateUpdate(Unit *pVictim,uint32 damage)
{
	uint32 procFlag = 0;
	if (pVictim->GetUInt32Value(UNIT_FIELD_HEALTH) == 0 ||
        GetUInt32Value(UNIT_FIELD_HEALTH) == 0 || IsStunned() || IsPacified())
	{
		return;
	}

	WorldPacket data;
	uint32 targetEvent = 0;
	uint32 unitEvent = 0;
	uint32 flag = 0x62;
	uint32 rduration = 1;
	uint32 state = 0;
	uint32 addspell = 0;
	uint32 dmgabs = 0;
	uint32 dmgactual = 0;
	uint32 hit_status = 0x22;
	uint32 damageType = 0;
	float dodge = pVictim->GetUInt32Value( UNIT_FIELD_STAT1) / 14.5;
	float block = pVictim->GetUInt32Value( UNIT_FIELD_STAT0) / 30.0;
	float parry = 0.0f;
	if (pVictim->GetTypeId() == TYPEID_PLAYER)
	{
		dodge = pVictim->GetFloatValue(PLAYER_DODGE_PERCENTAGE);
		block = pVictim->GetFloatValue(PLAYER_BLOCK_PERCENTAGE);
		parry = pVictim->GetFloatValue(PLAYER_PARRY_PERCENTAGE);
	}
	if(damage == 0)
		damage = CalculateDamage(this);
	else
		damageType = 1;

	int mod = GetDamageModGiven(0);
	if (this->GetTypeId() == TYPEID_PLAYER)
		//printf("increasing damage by %u\n",mod);
	if (mod != 0)
		damage += (rand()%GetDamageModGiven(0));
	mod = GetDamageModGivenPercent(0);
	if (this->GetTypeId() == TYPEID_PLAYER)
		//printf("increasing damage by %u\n",mod);
	if (mod != 0)
		damage += (damage * ((rand()%GetDamageModGivenPercent(0)) / 100.0f));

	//Armor Calculation
	if(pVictim->GetTypeId() == TYPEID_PLAYER)
	{
		//printf("Actual Armor is %u\n",pVictim->ActualArmor);
		if(pVictim->ActualArmor > 0)
		{
			//Formula from WowwoW
			double Reduction = double(pVictim->ActualArmor) / double(pVictim->ActualArmor+400+(85*getLevel()));
			if(Reduction > 0.75) Reduction = 0.75;
			uint32 damagereduction = damage*(Reduction+0.005); //instead of rounding just adding 0.005
			//printf("reduced damage by %f from %u to %u \n",Reduction,damage,damage-damagereduction);
			damage = damage - damagereduction;
		}
	}

	if (((float)(rand()%100)) < dodge)
	{
		targetEvent = 1;
		hit_status = 0x22;
		damage = 0;
		rduration = 2;
		state = 0;
		addspell = 0;
		dmgactual = damage;
		Emote(EMOTE_ONESHOT_PARRYUNARMED);			// Animation
	}
	if (((float)(rand()%100)) < block)
	{
		targetEvent = 2;
		hit_status = 0x22;			
		dmgabs = damage;
		damage = 0;
		rduration = 5;
		state = 0;
		addspell = 0;
		dmgactual = damage;
		if (pVictim->GetTypeId() == TYPEID_PLAYER)
		{
			Player* pr = ((Player*)pVictim);
			if (pr->GetItemBySlot(EQUIPMENT_SLOT_OFFHAND))
			{
				Emote(EMOTE_ONESHOT_PARRYSHIELD);			// Animation
			}
			else
			{
				Emote(EMOTE_ONESHOT_PARRYUNARMED);			// Animation
			}
		}
	}
	if (((float)(rand()%100)) < parry)
	{
		targetEvent = 3;
		hit_status = 0x22;
		damage = 0;
		rduration = 3;
		state = 0;
		addspell = 0;
		dmgactual = damage;
		pVictim->Emote(EMOTE_ONESHOT_PARRYUNARMED);			// Animation
	}

	uint32 some_value = 0xffffffff;
	some_value = 0x0;


	data.Initialize(SMSG_ATTACKERSTATEUPDATE);
	data << (uint32)hit_status;   // Attack flags
	data << GetNewGUID();
	data << pVictim->GetNewGUID();
	data << (uint32)damage;
	data << (uint8)1;       // Damage type counter

	// for each...
	data << damageType;      // Damage type, // 0 - white font, 1 - yellow
	data << (float)damage;      // damage float
	data << (uint32)damage; // Damage amount
	data << (uint32)dmgabs;      // damage absorbed

	data << (uint32)0;      // new victim state
	data << (uint32)rduration;      // victim round duraction
	data << (uint32)0;      // additional spell damage amount
	data << (uint32)0;      // additional spell damage id
	data << (uint32)dmgabs;      // Damage amount blocked

	//assert is useless after 1.9 cause the guid size is no longer static - Doron
	//WPAssert(data.size() == 61);
	SendMessageToSet(&data, true);

	//Log::getSingleton( ).outDetail("AttackerStateUpdate: %u %X attacked %u %X for %u dmg.",
	//	GetGUIDLow(), GetGUIDHigh(), pVictim->GetGUIDLow(), pVictim->GetGUIDHigh(), damage);

    if(pVictim->HasMeleeDamageSplit())
        damage = pVictim->SplitDamagePCT(damage,1);

    if(pVictim->HasDamageTakenMelee())
        damage = pVictim->GetDamageModTakenMelee(damage, false);
    
    if(pVictim->HasDamageTakenMeleePCT())
        damage = pVictim->GetDamageModTakenMelee(damage, true);

    if(pVictim->HasManaShield())
        damage = pVictim->GetManaShieldAbsorb(damage, pVictim);

    if(pVictim->HasSchoolAbsorb())
        damage = pVictim->GetSchoolAbsorb(damage,-1);

    if(pVictim->HasDamageTakenPCT())
        damage = pVictim->GetDamageModTaken(damage, true, DAMAGE_FLAG_MELEE);

	
	DealDamage(pVictim, damage, procFlag, targetEvent, unitEvent);
	uint32 SubClassSkill = 0;
	if (this->GetTypeId() == TYPEID_PLAYER)
	{
		Player *pr = ((Player*)this);
		Item *it = pr->GetItemBySlot(EQUIPMENT_SLOT_MAINHAND);
		ItemPrototype* proto = NULL;
		if (!it)
			it = pr->GetItemBySlot(EQUIPMENT_SLOT_RANGED);
		if (it)
			proto = it->GetProto();
		if (proto)
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
		} else
		{
			SubClassSkill = 162;
		}
		// Skill Update
		if ((damage != 0))
		{
			if (pr->GetSkillAmt(SubClassSkill) < pr->GetSkillMax(SubClassSkill))
			{
				if (((float)(rand()%100)) < pr->GetSkillUpChance(SubClassSkill))
				{
					pr->ModSkillLine(SubClassSkill,1);
					pr->SetFloatValue(PLAYER_DODGE_PERCENTAGE,((pr->GetUInt32Value( UNIT_FIELD_STAT1) / 14.5) + (pr->GetSkillAmt(95)*.04)));
					pr->SetFloatValue(PLAYER_BLOCK_PERCENTAGE,pr->GetUInt32Value( UNIT_FIELD_STAT0) / 30.0);
					if (pr->GetItemBySlot(EQUIPMENT_SLOT_OFFHAND))
						pr->SetFloatValue(PLAYER_BLOCK_PERCENTAGE,((pr->GetUInt32Value( UNIT_FIELD_STAT0) / 30.0)+ pr->GetItemBySlot(EQUIPMENT_SLOT_OFFHAND)->GetProto()->Block));
					pr->SetFloatValue(PLAYER_PARRY_PERCENTAGE,(pr->GetSkillAmt(95)*.04));
				}
			}
		}
	}
}

void Unit::smsg_AttackStop(uint64 victimGuid)
{
	WoWGuid guid(victimGuid);
	WorldPacket data;
	data.Initialize( SMSG_ATTACKSTOP );
	data << GetNewGUID();
	data << guid;
	data << uint32( 0 );
	SendMessageToSet(&data, true);
	Log::getSingleton( ).outDetail("%u %X stopped attacking "I64FMT,
		GetGUIDLow(), GetGUIDHigh(), victimGuid);
}


void Unit::smsg_AttackStart(Unit* pVictim)
{
	WorldPacket data;
	Player* pThis = objmgr.GetObject<Player>(GetGUID());
	// Prevent user from ignoring attack speed and stopping and start combat really really fast
	if(!isAttackReady())
		setAttackTimer(uint32(0));
	else if(!canReachWithAttack(pVictim)){
		setAttackTimer(uint32(500));
		data.Initialize(SMSG_CAST_RESULT);
		data << uint32(0);
		data << uint8(2);
		data << uint8(SPELL_FAILED_OUT_OF_RANGE);
		if(pThis)
			pThis->GetSession()->SendPacket(&data);
	}else if(!isInFront(pVictim)){
		setAttackTimer(uint32(500));
		data.Initialize(SMSG_CAST_RESULT);
		data << uint32(0);
		data << uint8(2);
		data << uint8(SPELL_FAILED_NOT_INFRONT);
		if(pThis)
			pThis->GetSession()->SendPacket(&data);
	}

	// Send out ATTACKSTART
	data.Initialize( SMSG_ATTACKSTART );
	data << GetGUID();
	data << pVictim->GetGUID();
	SendMessageToSet(&data, true);
	Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_ATTACKSTART" );



	// FLAGS changed so other players see attack animation
	//    addUnitFlag(0x00080000);
	//    setUpdateMaskBit(UNIT_FIELD_FLAGS );
}


bool Unit::AddAffect(Affect *aff, bool uniq)
{
	AffectList::const_iterator i;
	for (i = m_affects.begin(); i != m_affects.end(); i++)
	{
		if ((*i)->GetSpellId() == aff->GetSpellId() &&
			(uniq || (*i)->GetCasterGUID() == aff->GetCasterGUID()))
		{
			break;
		}
	}

	if (i != m_affects.end())
	{
	if((*i))
			RemoveAffect((*i));
	}
	for (Affect::ModList::const_iterator j = aff->GetModList().begin();
		j != aff->GetModList().end(); j++)
	{
		AffectList::iterator x;
		Affect::ModList::const_iterator y;

		Affect *aff2;
		Modifier mod = (*j);
		for (x = m_affects.begin(); x != m_affects.end(); x++)
		{
			aff2 = *x;

			for (y = aff2->GetModList().begin();
				y != aff2->GetModList().end(); y++)
			{
				Modifier mod2 = (*y);
				if (this->GetTypeId() == TYPEID_PLAYER)
				{
					if ((mod2.GetType() == mod.GetType()) && (mod.GetMiscValue() == mod2.GetMiscValue()) && (((aff->GetDuration() > 0) && (aff2->GetDuration() > 0)) || ((((Player*)this)->isTalent(aff->GetSpellId())) && (((Player*)this)->isTalent(aff2->GetSpellId())))))
					{
						if (mod.GetAmount() > mod2.GetAmount())
						{
							RemoveAffect(aff2);
							ApplyModifier(&(*j), true, aff);
							m_affects.push_back(aff);
							_AddAura(aff);
							hasAffects = true;
							return true;
						}
						else
						{
							return false;
						}
					}
					else if ((mod2.GetType() == mod.GetType()) && (mod.GetMiscValue() == mod2.GetMiscValue()) && (((aff->GetDuration() > 0) && (aff2->GetDuration() > 0))))
					{
						if (mod.GetAmount() > mod2.GetAmount())
						{
							RemoveAffect(aff2);
							ApplyModifier(&(*j), true, aff);
							m_affects.push_back(aff);
							_AddAura(aff);
							hasAffects = true;
							return true;
						}
						else
						{
							return false;
						}
					}
				}
			}
		}
		ApplyModifier(&(*j),true,aff);
	}

	m_affects.push_back(aff);
	_AddAura(aff);

	hasAffects = true;
	return true;
}


void Unit::RemoveAffect(Affect *aff)
{
	if(hasAffects)
	{
		AffectList::iterator i;

		for (i = m_affects.begin(); i != m_affects.end(); i++)
		{
			if (*i == aff)
				break;
		}

		ASSERT(i != m_affects.end());


		if(aff->GetCoAffect() != 0)
			RemoveAffect(aff->GetCoAffect());
		for (Affect::ModList::const_iterator j = aff->GetModList().begin();
			j != aff->GetModList().end(); j++)
		{
			ApplyModifier(&(*j), false, aff);
		}

		_RemoveAura(aff);

		m_affects.erase(i);
		if(m_affects.size() == 0)
			hasAffects = false;
		delete aff;
	}
}

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

void Unit::RemoveAffectByIdAndGuid(uint32 spellId, uint64 guid)
{
	if(m_aura != NULL)
		if(m_aura->GetCasterGUID() == guid  && m_aura->GetId() == spellId){
			m_aura = NULL;
			return;
		}

		Affect* aff = FindAff(spellId, guid);
		if(aff)
			aff->SetDuration(0);
}

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

uint32 Unit::GetAffDuration(uint32 spellId,Unit* caster)
{
	AffectList::iterator i;

	for (i = m_affects.begin(); i != m_affects.end(); i++)
	{
		if ((*i)->GetId() == spellId && (*i)->GetCasterGUID() == caster->GetGUID()){
			return (*i)->GetDuration();
		}
	}
	return NULL;
}

bool Unit::RemoveAffect(uint32 spellId)
{
	printf("removing affect %u",spellId);
	AffectList::iterator i, next;
	Affect *aff;
	bool result = false;

	for (i = m_affects.begin(); i != m_affects.end(); i = next)
	{
		next = i;
		next++;

		aff = *i;

		if (aff->GetId() == spellId)
		{
			for (Affect::ModList::const_iterator j = aff->GetModList().begin();
				j != aff->GetModList().end(); j++)
			{
				ApplyModifier(&(*j), false, aff);
			}

			_RemoveAura(aff);

			m_affects.erase(i);

			delete aff;
			result = true;
		}
	}

	if(m_affects.size() == 0)
		hasAffects = false;
	return result;
}

void Unit::RemoveAllAffects()
{
	/* Changed Just testing: Please Feel Free to change back to teh other way but comment it this time :D */
	//Log::getSingleton( ).outError("RemoveAllAffects");
	AffectList::iterator i;
	Affect::ModList::const_iterator j;
	//    Affect *aff;

	for (i = m_affects.begin(); i != m_affects.end(); i++)
	{
		//Log::getSingleton( ).outError("First Loop");
		//Affect *aff = *i;
		//Log::getSingleton( ).outError("Affect set");
		for (j = (*i)->GetModList().begin(); j != (*i)->GetModList().end(); j++)
		{
			Log::getSingleton( ).outError("Second Loop");
			ApplyModifier(&(*j), false, (*i));
		}
		//Log::getSingleton( ).outError("Remove");
		_RemoveAura((*i));
	}
	//Log::getSingleton( ).outError("Erase");
	//for (i = m_affects.begin(); i != m_affects.end(); i++)
	//{
	//	m_affects.erase(i);
	//}
	m_affects.clear();
	if(m_affects.size() == 0)
		hasAffects = false;
	//delete aff;
	return;
}

/*
void Unit::RemoveAllAffects()
{
// FIXME SOME THING WRONG HERE
AffectList::iterator i, next;
Affect *aff;
bool result = false;
Log::getSingleton( ).outError("RemoveAllAffects: Start");
uint8 t = 0;
uint8 s = 0;
for (i = m_affects.begin(); i != m_affects.end(); i = next)
{
t+=1;
Log::getSingleton( ).outError("RemoveAllAffects: MainLoop");
next = i;
next++;

aff = *i;
s = 0;
for (Affect::ModList::const_iterator j = aff->GetModList().begin();
j != aff->GetModList().end(); i++)
{
s +=1;
Log::getSingleton( ).outError("RemoveAllAffects: Secondaryloop");
ApplyModifier(&(*j), false, aff);
if(s == 20)
{
Log::getSingleton( ).outError("RemoveAllAffects: Second Loop Reached Limit");
break;
}
}
Log::getSingleton( ).outError("RemoveAllAffects: RemoveAura");
_RemoveAura(aff);
Log::getSingleton( ).outError("RemoveAllAffects: Erase Affect");
m_affects.erase(i);

delete aff;
if(t == 80)
{
Log::getSingleton( ).outError("RemoveAllAffects: First Loop Reached Limit");
break;
}
}

return;
}
*/

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


void Unit::ApplyModifier(const Modifier *mod, bool apply, Affect* parent)
{
	WorldPacket data;
	switch(mod->GetType())
	{
	case SPELL_AURA_NONE:
		{
		}break;
	case SPELL_AURA_BIND_SIGHT:
		{
            // MindVision
		}break;
	case SPELL_AURA_MOD_THREAT:
		{
		}break;
	case SPELL_AURA_AURAS_VISIBLE:
		{
            //Show positive spells on target
		}break;
	case SPELL_AURA_MOD_RESISTANCE_PCT:
		{
		}break;
	case SPELL_AURA_MOD_CREATURE_ATTACK_POWER:
		{
		}break;
	case SPELL_AURA_MOD_TOTAL_THREAT:
		{
			//stop attacking creatures
		}break;
	case SPELL_AURA_WATER_WALK:
		{
			apply ?
				data.Initialize(SMSG_MOVE_WATER_WALK)
				: data.Initialize(SMSG_MOVE_LAND_WALK);
			data << GetNewGUID();
			SendMessageToSet(&data,true);
		}break;
	case SPELL_AURA_FEATHER_FALL:
		{
			apply ?
				data.Initialize(SMSG_MOVE_FEATHER_FALL)
				: data.Initialize(SMSG_MOVE_NORMAL_FALL);
			data << GetNewGUID();
			SendMessageToSet(&data,true);
		}break;
	case SPELL_AURA_HOVER:
		{
            apply ?
	            data.Initialize(SMSG_MOVE_SET_HOVER)
                : data.Initialize(SMSG_MOVE_LAND_WALK);
            data << GetNewGUID();
	        SendMessageToSet(&data,true);
		}break;
	case SPELL_AURA_ADD_FLAT_MODIFIER:
		{
		}break;
	case SPELL_AURA_ADD_PCT_MODIFIER:
		{
            //Drops casting time
		}break;
	case SPELL_AURA_ADD_TARGET_TRIGGER:
		{
		}break;
	case SPELL_AURA_MOD_TAUNT:
		{
  			//moderate threat and force attacker to caster
            if(apply)
            {
                GetAIInterface()->modThreatByGUID(parent->GetCasterGUID(),mod->GetAmount());
                GetAIInterface()->AttackReaction(parent->GetCaster(),1,0);
            }
            else
            {
                GetAIInterface()->modThreatByGUID(parent->GetCasterGUID(),mod->GetAmount());
            }
		}break;
	case SPELL_AURA_MOD_POWER_REGEN_PERCENT:
		{
            apply ? m_powerRegenPCT++ : m_powerRegenPCT--;
            if(m_powerRegenPCT > 4294800000)
                m_powerRegenPCT = 0;
		}break;
	case SPELL_AURA_ADD_CASTER_HIT_TRIGGER:
		{
		}break;
	case SPELL_AURA_OVERRIDE_CLASS_SCRIPTS:
		{
		}break;
	case SPELL_AURA_MOD_RANGED_DAMAGE_TAKEN:
		{
		}break;
	case SPELL_AURA_MOD_RANGED_DAMAGE_TAKEN_PCT:
		{
		}break;
	case SPELL_AURA_MOD_HEALING:
		{
            //increases healing from healing spells 30
		}break;
	case SPELL_AURA_IGNORE_REGEN_INTERRUPT:
		{
		}break;
	case SPELL_AURA_MOD_MECHANIC_RESISTANCE:
		{
		}break;
	case SPELL_AURA_MOD_HEALING_PCT:
		{
		}break;
	case SPELL_AURA_SHARE_PET_TRACKING:
		{
		}break;
	case SPELL_AURA_MOD_STUN:
		{
			if(apply)
            {
				data.Initialize(SMSG_FORCE_MOVE_ROOT);
                data << GetNewGUID();
			    SendMessageToSet(&data,true);
                GetAIInterface()->m_canMove = false;
                m_stunned++;
            }
            else
            {
				data.Initialize(SMSG_FORCE_MOVE_UNROOT);
			    data << GetNewGUID();
			    SendMessageToSet(&data,true);
                GetAIInterface()->m_canMove = true;
                m_stunned--;
                if(m_stunned > 4294800000)
                    m_stunned = 0;
            }
		}break;
	case SPELL_AURA_UNTRACKABLE:
		{
		}break;
	case SPELL_AURA_EMPATHY:
		{
		}break;
	case SPELL_AURA_MOD_OFFHAND_DAMAGE_PCT:
		{
		}break;
	case SPELL_AURA_MOD_POWER_COST_PCT:
		{
		}break;
	case SPELL_AURA_MOD_RANGED_ATTACK_POWER:
		{
			apply ? SetUInt32Value(UNIT_FIELD_RANGED_ATTACK_POWER_MODS,GetUInt32Value(UNIT_FIELD_RANGED_ATTACK_POWER_MODS) + mod->GetAmount()) : SetUInt32Value(UNIT_FIELD_RANGED_ATTACK_POWER_MODS,GetUInt32Value(UNIT_FIELD_RANGED_ATTACK_POWER_MODS) - mod->GetAmount());
		}break;
	case SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN:
		{
            apply ? m_meleeDamageTaken++ : m_meleeDamageTaken--;
            if(m_meleeDamageTaken > 4294800000)
                m_meleeDamageTaken = 0;
		}break;
	case SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN_PCT:
		{
            apply ? m_meleeDamageTakenPCT++ : m_meleeDamageTakenPCT--;
		}break;
	case SPELL_AURA_RANGED_ATTACK_POWER_ATTACKER_BONUS:
		{
		}break;
	case SPELL_AURA_MOD_POSSESS_PET:
		{
		}break;
	case SPELL_AURA_MOD_INCREASE_SPEED_ALWAYS:
		{
			data.Initialize(MSG_MOVE_SET_RUN_SPEED);
			data << GetNewGUID();
			apply ? data << float(7.5+7.5/100*mod->GetAmount()) : data << float(7.5);
			SendMessageToSet(&data,true);
		}break;
	case SPELL_AURA_MOD_DAMAGE_DONE:
		{
			if(apply)
			{
                //FIXME:Use update fields for players
                //PLAYER_FIELD_MOD_DAMAGE_DONE_POS
				if(mod->GetMiscValue() == 1) //physical
				{
					parent->SetFloatGBValue(0, 0.0);
					parent->SetFloatGBValue(1, 0.0);
					uint32 mindamage = GetFloatValue(UNIT_FIELD_MINDAMAGE);
					uint32 maxdamage = GetFloatValue(UNIT_FIELD_MAXDAMAGE);
					uint32 plusValue = -1*mod->GetAmount();
					if(mindamage < plusValue)
					{
						parent->SetFloatGBValue(0, mindamage);
						SetFloatValue(UNIT_FIELD_MINDAMAGE,0);						
					}
					else
					{
						SetFloatValue(UNIT_FIELD_MINDAMAGE,mindamage + mod->GetAmount());
					}
					if(maxdamage < plusValue)
					{
						parent->SetFloatGBValue(1, maxdamage);
						SetFloatValue(UNIT_FIELD_MAXDAMAGE,0);						
					}
					else
					{
						SetFloatValue(UNIT_FIELD_MAXDAMAGE,maxdamage + mod->GetAmount());
					}
				}
			}
			else
			{
				if(mod->GetMiscValue() == 1) //physical
				{
					parent->SetFloatGBValue(0, 0);
					parent->SetFloatGBValue(1, 0);
					float mindamage = parent->GetFloatGBValue(0);
					float maxdamage = parent->GetFloatGBValue(1);
					if(mindamage > 0)
					{
						SetFloatValue(UNIT_FIELD_MINDAMAGE,GetFloatValue(UNIT_FIELD_MINDAMAGE) + mindamage);
					}
					else
					{
						SetFloatValue(UNIT_FIELD_MINDAMAGE,GetFloatValue(UNIT_FIELD_MINDAMAGE) - mod->GetAmount());
					}
					if(maxdamage > 0)
					{
						SetFloatValue(UNIT_FIELD_MINDAMAGE,GetFloatValue(UNIT_FIELD_MINDAMAGE) + maxdamage);
					}
					else
					{
						SetFloatValue(UNIT_FIELD_MAXDAMAGE,GetFloatValue(UNIT_FIELD_MAXDAMAGE) - mod->GetAmount());
					}
				}
			}					
		}break;
	case SPELL_AURA_MOD_MOUNTED_SPEED_ALWAYS:
		{
		}break;
	case SPELL_AURA_MOD_CREATURE_RANGED_ATTACK_POWER:
		{
		}break;
	case SPELL_AURA_MOD_INCREASE_ENERGY_PERCENT:
		{
			uint32 percent = mod->GetAmount();
			uint32 current = GetUInt32Value(UNIT_FIELD_POWER4);
			apply ? SetUInt32Value(UNIT_FIELD_POWER4,current+current/100*percent) : SetUInt32Value(UNIT_FIELD_POWER4,current-current/(100+percent)*100);
		}break;
	case SPELL_AURA_MOD_INCREASE_HEALTH_PERCENT:
		{
			uint32 percent = mod->GetAmount();
			uint32 current = GetUInt32Value(UNIT_FIELD_MAXHEALTH);
			apply ? SetUInt32Value(UNIT_FIELD_MAXHEALTH,current+current/100*percent) : SetUInt32Value(UNIT_FIELD_MAXHEALTH,current-current/(100+percent)*100);
		}break;
	case SPELL_AURA_MOD_MANA_REGEN_INTERRUPT:
		{
            //make regen always active
            // allows you to continue %30 of mana regen in combat
		}break;
	case SPELL_AURA_MOD_HEALING_DONE:
		{
		}break;
	case SPELL_AURA_MOD_HEALING_DONE_PERCENT:
		{
		}break;
	case SPELL_AURA_MOD_TOTAL_STAT_PERCENTAGE:
		{
		}break;
	case SPELL_AURA_MOD_HASTE:
		{
			//Attack speed %
            //FIXME: Check dual wielding and add UNIT_FIELD_BASEATTACKTIME_01 too
            uint32 speed = GetUInt32Value(UNIT_FIELD_BASEATTACKTIME);
            apply ? SetUInt32Value(UNIT_FIELD_BASEATTACKTIME,speed+((speed*mod->GetAmount())/100)) : SetUInt32Value(UNIT_FIELD_BASEATTACKTIME,speed-(speed/((100+mod->GetAmount())*100)));
		}break;
	case SPELL_AURA_FORCE_REACTION:
		{
		}break;
	case SPELL_AURA_MOD_DAMAGE_TAKEN:
		{
            apply ? m_damageTakenSpell++ : m_damageTakenSpell--;
            if(m_damageTakenSpell > 4294800000)
                m_damageTakenSpell = 0;
		}break;
	case SPELL_AURA_MOD_RANGED_HASTE:
		{
            //Attack speed %
            uint32 speed = GetUInt32Value(UNIT_FIELD_RANGEDATTACKTIME);
            apply ? SetUInt32Value(UNIT_FIELD_RANGEDATTACKTIME,speed+((speed*mod->GetAmount())/100)) : SetUInt32Value(UNIT_FIELD_RANGEDATTACKTIME,speed-(speed/((100+mod->GetAmount())*100)));
		}break;
	case SPELL_AURA_MOD_RANGED_AMMO_HASTE:
		{
		}break;
	case SPELL_AURA_MOD_BASE_RESISTANCE_PCT:
		{
		}break;
	case SPELL_AURA_MOD_RESISTANCE_EXCLUSIVE:
		{
			uint16 index = 0;
			uint16 index2 = 0;
			if (mod->GetMiscValue() == -1)
			{
				index = UNIT_FIELD_RESISTANCES+1;
				mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE+1 : index2 = PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE+1;
				for(uint32 i=0;i<5;i++)
				{
					if(apply){
						SetUInt32Value(index+i,GetUInt32Value(index+i)+mod->GetAmount());
						if(GetTypeId() == TYPEID_PLAYER)
							SetUInt32Value(index2+i,GetUInt32Value(index2+i)+mod->GetAmount());
					}else{
						SetUInt32Value(index+i,GetUInt32Value(index+i)-mod->GetAmount());
						if(GetTypeId() == TYPEID_PLAYER)
							SetUInt32Value(index2+i,GetUInt32Value(index2+i)-mod->GetAmount());
					}
				}
			} else {
				index = UNIT_FIELD_RESISTANCES + mod->GetMiscValue();
				mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE + mod->GetMiscValue() : index2 = PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE + mod->GetMiscValue();
			}
			index--;
			index2--;
			if(apply){
				SetUInt32Value(index,GetUInt32Value(index)+mod->GetAmount());
				if(GetTypeId() == TYPEID_PLAYER)
					SetUInt32Value(index2,GetUInt32Value(index2)+mod->GetAmount());
			}else{
				SetUInt32Value(index,GetUInt32Value(index)-mod->GetAmount());
				if(GetTypeId() == TYPEID_PLAYER)
					SetUInt32Value(index2,GetUInt32Value(index2)-mod->GetAmount());
			}
		}break;
	case SPELL_AURA_SAFE_FALL:
		{
			apply ? data.Initialize(SMSG_MOVE_FEATHER_FALL) : data.Initialize(SMSG_MOVE_NORMAL_FALL);
			data << GetNewGUID();
			SendMessageToSet(&data,true);
		}break;
	case SPELL_AURA_CHARISMA:
		{
		}break;
	case SPELL_AURA_PERSUADED:
		{
		}break;
	case SPELL_AURA_ADD_CREATURE_IMMUNITY:
		{
		}break;
	case SPELL_AURA_RETAIN_COMBO_POINTS:
		{
            //combo points
		}break;
	case SPELL_AURA_DAMAGE_SHIELD:
		{
			if(apply){
				DamageShield* ds = new DamageShield();
				ds->m_caster = parent->GetCasterGUID();
				ds->m_damage = mod->GetAmount();
				ds->m_spellId = parent->GetId();
				m_damageShields.push_back((*ds));
			}else{
				for(std::list<struct DamageShield>::iterator i = m_damageShields.begin();i != m_damageShields.end();i++)
					if(i->m_spellId == parent->GetId() && i->m_caster == parent->GetCasterGUID()){
						m_damageShields.erase(i);
						break;
					}
			}
		}break;
	case SPELL_AURA_MOD_STEALTH:
		{
		}break;
    case SPELL_AURA_MOD_HEALTH_REGEN_IN_COMBAT:
        {
            //Handled in Aura Handler
        }
	case SPELL_AURA_MOD_DETECT:
		{
		}break;
	case SPELL_AURA_MOD_INVISIBILITY:
		{
		}break;
	case SPELL_AURA_MOD_INVISIBILITY_DETECTION:
		{
            //Detect Traps spellId 2836
		}break;
	case SPELL_AURA_MOD_POSSESS:
		{
			//updatepacket
		}break;
	case SPELL_AURA_MOD_RESISTANCE:
		{
			uint16 index = 0;
			uint16 index2 = 0;
			if (mod->GetMiscValue() == -1)
			{
				index = UNIT_FIELD_RESISTANCES+1;
				mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE+1 : index2 = PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE+1;
				for(uint32 i=0;i<6;i++)
				{
					if(apply){
						SetUInt32Value(index+i,GetUInt32Value(index+i)+mod->GetAmount());
						if(GetTypeId() == TYPEID_PLAYER)
							SetUInt32Value(index2+i,GetUInt32Value(index2+i)+mod->GetAmount());
					}else{
						SetUInt32Value(index+i,GetUInt32Value(index+i)-mod->GetAmount());
						if(GetTypeId() == TYPEID_PLAYER)
							SetUInt32Value(index2+i,GetUInt32Value(index2+i)-mod->GetAmount());
					}
				}
			} else {
				index = UNIT_FIELD_RESISTANCES + mod->GetMiscValue();
				mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE + mod->GetMiscValue() : index2 = PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE + mod->GetMiscValue();
			}
			index--;
			index2--;
			if(apply){
				uint32 add = mod->GetAmount();
				SetUInt32Value(index, GetUInt32Value(index)+add);
				if(index == UNIT_FIELD_RESISTANCES) //Armor
				{
					if(GetTypeId() == TYPEID_PLAYER)
					{
						((Player*)this)->MagicalArmor += add;
						CalculateActualArmor();
					}
				}
				if(GetTypeId() == TYPEID_PLAYER) 
					SetUInt32Value(index2,GetUInt32Value(index2)+mod->GetAmount());
			}else{
				uint32 remove = mod->GetAmount();
				SetUInt32Value(index,GetUInt32Value(index)-remove);
				if(index == UNIT_FIELD_RESISTANCES) //Armor
				{
					if(GetTypeId() == TYPEID_PLAYER)
					{
						((Player*)this)->MagicalArmor -= remove;
						CalculateActualArmor();
					}
				}
				if(GetTypeId() == TYPEID_PLAYER)
					SetUInt32Value(index2,GetUInt32Value(index2)-mod->GetAmount());
			}
		}break;
	case SPELL_AURA_PERIODIC_TRIGGER_SPELL:
		{
			//Handled in aura handler
		}break;
	case SPELL_AURA_PERIODIC_ENERGIZE:
		{
            //Handled in aura handler
		}break;
	case SPELL_AURA_MOD_PACIFY:
		{
            // Cant Attack
            apply ? m_pacified++ : m_pacified--;
            if(m_pacified > 4294800000)
                m_pacified = 0;
		}break;
	case SPELL_AURA_MOD_ROOT:
		{
			apply ?
			data.Initialize(SMSG_FORCE_MOVE_ROOT)
				: data.Initialize(SMSG_FORCE_MOVE_UNROOT);
			data << GetNewGUID();
			SendMessageToSet(&data,true);
		}break;
	case SPELL_AURA_MOD_SILENCE:
		{
			apply ? m_silenced++ : m_silenced--;
            if(m_silenced > 4294800000)
                m_silenced = 0;
		}break;
	case SPELL_AURA_REFLECT_SPELLS:
		{
		}break;
	case SPELL_AURA_MOD_STAT:
		{
			uint16 index = 0;
			uint16 index2 = 0;
			if (mod->GetMiscValue() == -1)
			{
				index = UNIT_FIELD_STAT0;
				mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_POSSTAT0 : index2 = PLAYER_FIELD_NEGSTAT0;
				for(uint32 i=0;i<5;i++)
				{
					if(apply){
						SetUInt32Value(index+i,GetUInt32Value(index+i)+mod->GetAmount());
						if(GetTypeId() == TYPEID_PLAYER)
							SetUInt32Value(index2+i,GetUInt32Value(index2+i)+mod->GetAmount());
					}else{
						SetUInt32Value(index+i,GetUInt32Value(index+i)-mod->GetAmount());
						if(GetTypeId() == TYPEID_PLAYER)
							SetUInt32Value(index2+i,GetUInt32Value(index2+i)-mod->GetAmount());
					}
				}
			} else{
				index = UNIT_FIELD_STAT0 + mod->GetMiscValue();
				mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_POSSTAT0+ mod->GetMiscValue() : index2 = PLAYER_FIELD_NEGSTAT0+ mod->GetMiscValue();

			}
			if(apply){
				SetUInt32Value(index,GetUInt32Value(index)+mod->GetAmount());
				if(GetTypeId() == TYPEID_PLAYER)
					SetUInt32Value(index2,GetUInt32Value(index2)+mod->GetAmount());
			}else{
				SetUInt32Value(index,GetUInt32Value(index)-mod->GetAmount());
				if(GetTypeId() == TYPEID_PLAYER)
					SetUInt32Value(index2,GetUInt32Value(index2)-mod->GetAmount());
			}
		}break;
	case SPELL_AURA_PERIODIC_DAMAGE:
		{
            //Handled in aura handler
		}break;
	case SPELL_AURA_MOD_SKILL:
		{
		}break;
	case SPELL_AURA_MOD_INCREASE_SPEED:
		{
			m_speed = m_speed + 7.0f/100*mod->GetAmount();
			data.Initialize(SMSG_FORCE_RUN_SPEED_CHANGE);
			data << GetNewGUID();
			apply ? data << float(7.5+7.5/100*mod->GetAmount()) : data << float(7.5);
			SendMessageToSet(&data,true);
		}break;
	case SPELL_AURA_MOD_INCREASE_MOUNTED_SPEED:
		{
			data.Initialize(SMSG_FORCE_RUN_SPEED_CHANGE);
			data << GetNewGUID();
			apply ? data << float(7.5+7.5/100*mod->GetAmount()) : data << float(7.5);
			SendMessageToSet(&data,true);
		}break;
	case SPELL_AURA_MOD_DECREASE_SPEED:
		{
			printf("slowing to %u percent\n",mod->GetAmount());
			m_speed = 7.0f/100*mod->GetAmount();
			data.Initialize(SMSG_FORCE_RUN_SPEED_CHANGE);
			data << GetNewGUID();
			apply ? data << float(7.5/100*mod->GetAmount()) : data << float(7.5);
			SendMessageToSet(&data,true);
		}break;
	case SPELL_AURA_MOD_INCREASE_HEALTH:
		{
			uint32 newValue;
			newValue = GetUInt32Value(UNIT_FIELD_MAXHEALTH);
			apply ? newValue += mod->GetAmount() : newValue -= mod->GetAmount();
			SetUInt32Value(UNIT_FIELD_MAXHEALTH,newValue);
		}break;
	case SPELL_AURA_MOD_INCREASE_ENERGY:
		{
			uint32 powerField = 23;
			uint8 powerType = (uint8)(GetUInt32Value(UNIT_FIELD_BYTES_0) >> 24);
			if(powerType == 0) // Mana
				powerField = UNIT_FIELD_POWER1;
			else if(powerType == 1) // Rage
				powerField = UNIT_FIELD_POWER2;
			else if(powerType == 3) // Energy
				powerField = UNIT_FIELD_POWER4;

			uint32 newValue = GetUInt32Value(powerType);
			apply ? newValue += mod->GetAmount() : newValue -= mod->GetAmount();
			SetUInt32Value(powerType,newValue);
		}break;
	case SPELL_AURA_MOD_SHAPESHIFT:
		{
            //FIXME:Find true id's
			if (!apply)
				printf("removing shapeshift\n");
			Affect* tmpAff;
			uint32 spellId;
			uint8 powerType;
            uint32 modelId = GetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID);
			switch(mod->GetMiscValue())
			{
			case FORM_CAT: {
				spellId = 3025;
				powerType = 3;
                SetUInt32Value (UNIT_FIELD_BYTES_1, apply? 0x00010000: 0x0011EE00);
                modelId = 1008;
						   } break;
			case FORM_TREE:{
				spellId = 3122;
                powerType = parent->GetSpellProto()->powerType;
						   } break;
			case FORM_TRAVEL:{
				spellId = 5419;
                powerType = parent->GetSpellProto()->powerType;
                SetUInt32Value (UNIT_FIELD_BYTES_1, apply? 0x00030000: 0x0011EE00);
							 } break;
			case FORM_AQUA:{
				spellId = 5421;
                powerType = parent->GetSpellProto()->powerType;
                SetUInt32Value (UNIT_FIELD_BYTES_1, apply? 0x00040000: 0x0011EE00);
						   } break;
			case FORM_BEAR:{
				spellId = 1178;
				powerType = 1;
                SetUInt32Value (UNIT_FIELD_BYTES_1, apply? 0x00050000: 0x0011EE00);
                modelId = 5510;
						   } break;
			case FORM_AMBIENT:{
				spellId = 0;
                powerType = parent->GetSpellProto()->powerType;
							  } break;
			case FORM_GHOUL:{
				spellId = 0;
                powerType = parent->GetSpellProto()->powerType;
							} break;
			case FORM_DIREBEAR:{
				spellId = 9635;
				powerType = 1;
                SetUInt32Value (UNIT_FIELD_BYTES_1, apply? 0x00080000: 0x0011EE00);
                modelId = 9492;
							   } break;
			case FORM_CREATUREBEAR:{
				spellId = 2882;
				powerType = 1;
                modelId = 9492;
								   } break;
			case FORM_GHOSTWOLF:{
				spellId = 0;
                powerType = parent->GetSpellProto()->powerType;
                SetUInt32Value (UNIT_FIELD_BYTES_1, apply? 0x00100000: 0x0011EE00);
                modelId = 776;
								} break;
			case FORM_BATTLESTANCE:{
				spellId = 0;
			    SetUInt32Value (UNIT_FIELD_BYTES_1, apply? 0x00110000: 0x0011EE00);
                powerType = parent->GetSpellProto()->powerType;
								   } break;
			case FORM_DEFENSIVESTANCE:{
				spellId = 7376;
			    SetUInt32Value (UNIT_FIELD_BYTES_1, apply? 0x00120000: 0x0011EE00);
                powerType = parent->GetSpellProto()->powerType;
									  } break;
			case FORM_BERSERKERSTANCE:{
				spellId = 7381;
                SetUInt32Value (UNIT_FIELD_BYTES_1, apply? 0x00130000: 0x0011EE00);
                powerType = parent->GetSpellProto()->powerType;
									  } break;
			case FORM_SHADOW:{
				spellId = 0;
                powerType = parent->GetSpellProto()->powerType;
							 } break;
			case FORM_STEALTH:{
				spellId = 3025;
                powerType = parent->GetSpellProto()->powerType;
			    // Turn on Sneaky Stance, Switch stealth button to unstealth and switch spellbar
                // 02->standstate|1E(30)FORM_STEALTH
			    SetUInt32Value (UNIT_FIELD_BYTES_1, apply? 0x021E0000: 0x0011EE00);
                if (apply == false && GetTypeId() == TYPEID_PLAYER)
			    {
				    data.Initialize (SMSG_COOLDOWN_EVENT);
                    data << (uint32)parent->GetSpellId() << GetGUID();
				    ((Player*)this)->GetSession()->SendPacket (&data);
			    }
                return;
                            } break;
            case FORM_MOONKIN:{
                spellId = 0;
                powerType = parent->GetSpellProto()->powerType;
                SetUInt32Value (UNIT_FIELD_BYTES_1, apply? 0x001F0000: 0x0011EE00);
                              }break;
			default:{
				printf("Unknown Shapeshift Type\n");
					} break;
			}
			if (apply)
			{
                SetUInt32Value(UNIT_FIELD_DISPLAYID, modelId);

				// check for spell id
				SpellEntry *spellInfo = sSpellStore.LookupEntry( spellId );

				if(!spellInfo)
				{
					Log::getSingleton( ).outError("WORLD: unknown spell id %i\n", spellId);
					break;
				}
                tmpAff = new Affect(spellInfo,parent->GetDuration(),parent->GetCasterGUID(),parent->GetCaster());
				for(uint8 i=0;i<3;i++){
					if(spellInfo->Effect[i] == 6)
                    {
						uint32 value = 0;
						uint32 type = 0;
						uint32 damage = 0;
						if(spellInfo->EffectBasePoints[i] < 0)
                        {
							tmpAff->SetNegative();
							type = 1;
						}
						uint32 sBasePoints = (uint32)sqrt((float)(spellInfo->EffectBasePoints[i]*spellInfo->EffectBasePoints[i]));
						if(spellInfo->EffectApplyAuraName[i] == 3)
                        {       // Periodic Trigger Damage
							damage = spellInfo->EffectBasePoints[i]+rand()%spellInfo->EffectDieSides[i]+1;
							tmpAff->SetDamagePerTick((uint16)damage, spellInfo->EffectAmplitude[i]);
							tmpAff->SetNegative();
						}
                        else if(spellInfo->EffectApplyAuraName[i] == 23)// Periodic Trigger Spell
                            tmpAff->SetPeriodicTriggerSpell(spellInfo->EffectTriggerSpell[i],spellInfo->EffectAmplitude[i],0);
						else if(spellInfo->EffectApplyAuraName[i] == 8)   // Periodic Heal
							tmpAff->SetHealPerTick(damage,spellInfo->EffectAmplitude[i]);
						else
                        {
							if(spellInfo->EffectDieSides[i] != 0)
								value = sBasePoints+rand()%spellInfo->EffectDieSides[i];
							else
								value = sBasePoints;
							if(spellInfo->EffectDieSides[i] <= 1)
								value += 1;
							tmpAff->AddMod((uint8)spellInfo->EffectApplyAuraName[i],value,spellInfo->EffectMiscValue[i],type);
							tmpAff->SetPositive();
						}
					}
				}
				if(tmpAff){
					parent->SetCoAffect(tmpAff);
					AddAffect(tmpAff);
				}
				SetUInt32Value(UNIT_FIELD_BYTES_0, ( ( getRace() ) | ( getClass() << 8 ) | ( getGender() << 16 ) | ( powerType << 24 ) ) );
			}
			else 
			{
                SetUInt32Value(UNIT_FIELD_DISPLAYID, GetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID));                
				RemoveAffect(spellId);
				switch(getClass())
				{
				case WARRIOR : powerType = 1; break; // Rage
				case PALADIN : powerType = 0; break; // Mana
				case HUNTER  : powerType = 0; break;
				case ROGUE   : powerType = 3; break; // Energy
				case PRIEST  : powerType = 0; break;
				case SHAMAN  : powerType = 0; break;
				case MAGE    : powerType = 0; break;
				case WARLOCK : powerType = 0; break;
				case DRUID   : powerType = 0; break;
				} // 2 = Focus (unused)
				SetUInt32Value(UNIT_FIELD_BYTES_0, ( ( getRace() ) | ( getClass() << 8 ) | ( getGender() << 16 ) | ( powerType << 24 ) ) );
			}
		}break;
	case SPELL_AURA_EFFECT_IMMUNITY:
		{
		}break;
	case SPELL_AURA_STATE_IMMUNITY:
		{
            //%50 chance to dispel 1 magic effect on target
            //23922
		}break;
	case SPELL_AURA_SCHOOL_IMMUNITY:
		{
		}break;
	case SPELL_AURA_DUMMY:
		{
            switch(parent->GetSpellId())
            {
            case 126: //Eye of Killrog
                {
                    if(apply)
                    {
                        Unit *caster = parent->GetCaster();
                        if(!caster)
                            break;

                        m_useAI = false;

                        /*caster->SetUInt64Value(UNIT_FIELD_CHARM,parent->GetCasterGUID());
                        SetUInt64Value(UNIT_FIELD_CHARMEDBY,parent->GetCasterGUID());*/
                        //caster->SetUInt64Value(PLAYER_FARSIGHT,caster->GetUInt64Value(UNIT_FIELD_SUMMON));
                    }
                    else
                    {
                        Unit *caster = parent->GetCaster();
                        if(!caster)
                            break;

                     /*   caster->SetUInt64Value(UNIT_FIELD_CHARM,0);
                        SetUInt64Value(UNIT_FIELD_CHARMEDBY,0);*/
                        caster->SetUInt64Value(PLAYER_FARSIGHT,caster->GetGUID());
                        caster->SetUInt64Value(UNIT_FIELD_SUMMON,0);
                        this->RemoveFromWorld();
				        objmgr.RemoveObject(((Creature *)this));
                    }
                }break;
            case 2096:{//MindVision
                }break;
            case 15286://Vampiric Embrace
                {
                    if(apply)
                    {
                        m_damageHeal++;
                        parent->SetUInt32GBValue(0,SCHOOL_SHADOW);
                        parent->SetUInt32GBValue(1,20);
                    }
                    else
                    {
                        m_damageHeal--;
                        if(m_damageHeal > 4294800000)
                            m_damageHeal = 0;
                    }
                }break;
            }
		}break;
	case SPELL_AURA_DAMAGE_IMMUNITY:
		{
			apply ? m_damageImmune++ : m_damageImmune--;
            if(m_damageImmune > 4294800000)
                m_damageImmune = 0;
		}break;
	case SPELL_AURA_DISPEL_IMMUNITY:
		{
		}break;
	case SPELL_AURA_PROC_TRIGGER_SPELL:
		{
			uint32 i=0;
			for(i=0;i<2;i++)
				if(parent->GetSpellProto()->EffectApplyAuraName[i] == mod->GetType())
					break;
			if(apply){
				ProcTriggerSpell* pts = new ProcTriggerSpell();
				pts->caster = parent->GetCasterGUID();
				pts->spellId = parent->GetSpellProto()->EffectTriggerSpell[i];
				pts->trigger = parent->GetSpellProto()->EffectBasePoints[i];
				pts->procChance = parent->GetSpellProto()->procChance;
				pts->procFlags = parent->GetSpellProto()->procFlags;
				parent->GetSpellProto()->procCharges == 0 ? pts->procCharges = -1
					: pts->procCharges = parent->GetSpellProto()->procCharges;
				m_procSpells.push_back((*pts));
			}else{
				for(std::list<struct ProcTriggerSpell>::iterator itr = m_procSpells.begin();itr != m_procSpells.end();itr++)
					if(itr->spellId == parent->GetId() && itr->caster == parent->GetCasterGUID()){
						m_procSpells.erase(itr);
						break;
					}
			}
		}break;
	case SPELL_AURA_PROC_TRIGGER_DAMAGE:
		{
			if(apply){
				DamageShield* ds = new DamageShield();
				ds->m_caster = parent->GetCasterGUID();
				ds->m_damage = mod->GetAmount();
				ds->m_spellId = parent->GetId();
				m_damageShields.push_back((*ds));
			}else{
				for(std::list<struct DamageShield>::iterator i = m_damageShields.begin();i != m_damageShields.end();i++)
					if(i->m_spellId == parent->GetId() && i->m_caster == parent->GetCasterGUID()){
						m_damageShields.erase(i);
						break;
					}
			}
		}break;
	case SPELL_AURA_TRACK_CREATURES:
		{
			apply ? SetUInt32Value(PLAYER_TRACK_CREATURES,mod->GetMiscValue()) : SetUInt32Value(PLAYER_TRACK_CREATURES,0);
		}break;
	case SPELL_AURA_TRACK_RESOURCES:
		{
			apply ? SetUInt32Value(PLAYER_TRACK_RESOURCES,mod->GetMiscValue()) : SetUInt32Value(PLAYER_TRACK_RESOURCES,0);
		}break;
	case SPELL_AURA_MOD_PARRY_SKILL:
		{
		}break;
	case SPELL_AURA_MOD_PARRY_PERCENT:
		{
			uint32 current = GetUInt32Value(PLAYER_PARRY_PERCENTAGE);
			apply ? SetUInt32Value(PLAYER_PARRY_PERCENTAGE,current+mod->GetAmount()) : SetUInt32Value(PLAYER_PARRY_PERCENTAGE,current-mod->GetAmount());
		}break;
	case SPELL_AURA_MOD_DODGE_SKILL:
		{
		}break;
	case SPELL_AURA_MOD_DODGE_PERCENT:
		{
			uint32 current = GetUInt32Value(PLAYER_DODGE_PERCENTAGE);
			apply ? SetUInt32Value(PLAYER_DODGE_PERCENTAGE,current+mod->GetAmount()) : SetUInt32Value(PLAYER_DODGE_PERCENTAGE,current-mod->GetAmount());
		}break;
	case SPELL_AURA_MOD_CONFUSE:
		{
            //Wander around
		}break;
	case SPELL_AURA_MOD_BLOCK_SKILL:
		{
		}break;
	case SPELL_AURA_MOD_BLOCK_PERCENT:
		{
			uint32 current = GetUInt32Value(PLAYER_BLOCK_PERCENTAGE);
			apply ? SetUInt32Value(PLAYER_BLOCK_PERCENTAGE,current+mod->GetAmount()) : SetUInt32Value(PLAYER_BLOCK_PERCENTAGE,current-mod->GetAmount());
		}break;
	case SPELL_AURA_MOD_CRIT_PERCENT:
		{
			uint32 current = GetUInt32Value(PLAYER_CRIT_PERCENTAGE);
			apply ? SetUInt32Value(PLAYER_CRIT_PERCENTAGE,current+mod->GetAmount()) : SetUInt32Value(PLAYER_CRIT_PERCENTAGE,current-mod->GetAmount());
		}break;
	case SPELL_AURA_PERIODIC_LEECH:
		{
            //Handled in aura handler
		}break;
	case SPELL_AURA_MOD_HIT_CHANCE:
		{
		}break;
	case SPELL_AURA_MOD_SPELL_HIT_CHANCE:
		{
		}break;
	case SPELL_AURA_TRANSFORM:
		{
            switch(parent->GetId())
            {
                case 118:
                case 851:
                case 5254:
                case 12824:
                case 12825:
                case 12826:
                case 13323:
                case 15534:
                case 22274:
                case 23603:
                    {
                        if (apply) {
                            if(m_polymorphImmunity)
                            {
                                Unit *caster = parent->GetCaster();
                                if(!caster)
                                    return;
                                if (caster->GetTypeId() != TYPEID_PLAYER)
			                        return;

		                        WorldPacket data;

		                        data.Initialize(SMSG_CAST_RESULT);
                                data << (uint32)parent->GetSpellId();
			                    data << uint8(2);
			                    data << (uint8)SPELL_FAILED_IMMUNE;

		                        ((Player*)caster)->GetSession()->SendPacket(&data);
                                break;
                            }
                            m_pacified++;
					        //((Modifier *)mod)->SetValue1 (GetUInt32Value (UNIT_FIELD_DISPLAYID));
					        SetUInt32Value (UNIT_FIELD_DISPLAYID, 856);
				        } else {
                            m_pacified--;
                            if(m_pacified > 4294800000)
                                m_pacified = 0;
					        SetUInt32Value (UNIT_FIELD_DISPLAYID, GetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID));
				        }
                    }break;
                case 228:
                    {
				        if (apply) {
                            m_pacified++;
                            if(m_polymorphImmunity)
                            {
                                Unit *caster = parent->GetCaster();
                                if(!caster)
                                    break;
                                if (caster->GetTypeId() != TYPEID_PLAYER)
			                        break;

		                        WorldPacket data;

		                        data.Initialize(SMSG_CAST_RESULT);
                                data << (uint32)parent->GetSpellId();
			                    data << uint8(2);
			                    data << (uint8)SPELL_FAILED_IMMUNE;

		                        ((Player*)caster)->GetSession()->SendPacket(&data);
                                break;
                            }
					        //((Modifier *)mod)->SetValue1 (GetUInt32Value (UNIT_FIELD_DISPLAYID));
					        SetUInt32Value (UNIT_FIELD_DISPLAYID, 304);
				        } else {
                            m_pacified--;
                            if(m_pacified > 4294800000)
                                m_pacified = 0;
					        SetUInt32Value (UNIT_FIELD_DISPLAYID, GetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID));
				        }
			        }break;
                case 4060:
                    {
				        if (apply) {
					        //((Modifier *)mod)->SetValue1 (GetUInt32Value (UNIT_FIELD_DISPLAYID));
					        SetUInt32Value (UNIT_FIELD_DISPLAYID, 131);
				        } else {
					        SetUInt32Value (UNIT_FIELD_DISPLAYID, GetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID));
				        }
			        }break;
                case 17738:
                    {
				        if (apply) {
					        //((Modifier *)mod)->SetValue1 (GetUInt32Value (UNIT_FIELD_DISPLAYID));
					        SetUInt32Value (UNIT_FIELD_DISPLAYID, 1141);
				        } else {
					        SetUInt32Value (UNIT_FIELD_DISPLAYID, GetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID));
				        }
			        }break;
            };
        }break;
	case SPELL_AURA_MOD_SPELL_CRIT_CHANCE:
		{
		}break;
	case SPELL_AURA_MOD_INCREASE_SWIM_SPEED:
		{
		}break;
	case SPELL_AURA_MOD_DAMAGE_DONE_CREATURE:
		{
		}break;
	case SPELL_AURA_MOD_CHARM:
		{
		}break;
	case SPELL_AURA_MOD_PACIFY_SILENCE:
		{
		}break;
	case SPELL_AURA_MOD_SCALE:
		{
			float current = GetFloatValue(OBJECT_FIELD_SCALE_X);
			apply ? SetFloatValue(OBJECT_FIELD_SCALE_X,current+current/100*10) : SetFloatValue(OBJECT_FIELD_SCALE_X,current-current/110*100);
		}break;
	case SPELL_AURA_PERIODIC_HEALTH_FUNNEL:
		{
            // pet related
		}break;
	case SPELL_AURA_PERIODIC_MANA_FUNNEL:
		{
            // pet related
		}break;
	case SPELL_AURA_PERIODIC_MANA_LEECH:
		{
            // Handled in aura handler
		}break;
	case SPELL_AURA_MOD_CASTING_SPEED:
		{
			float current = GetUInt32Value(UNIT_MOD_CAST_SPEED);
			apply ? SetUInt32Value(UNIT_MOD_CAST_SPEED,current+current/100*10) : SetUInt32Value(UNIT_MOD_CAST_SPEED,current-current/110*100);
		}break;
	case SPELL_AURA_FEIGN_DEATH:
		{
            //Not sure
            apply ? SetFlag(UNIT_FIELD_FLAGS, U_FIELD_FLAG_DEAD) : RemoveFlag(UNIT_FIELD_FLAGS, U_FIELD_FLAG_DEAD);
		}break;
	case SPELL_AURA_MOD_DISARM:
		{
            //U_FIELD_FLAG_WEAPON_OFF
		}break;
	case SPELL_AURA_MOD_STALKED:
		{
		}break;
	case SPELL_AURA_SCHOOL_ABSORB:
		{
            //absorb add bool check and store absorb in unit.h
            // misc = 5 -> shadow damage
            // misc = 2 -> fire damage
            // misc = 4294967294 (-2 signed) all damage
            apply ? m_schoolAbsorb++ : m_schoolAbsorb--;
            if(m_schoolAbsorb > 4294800000)
                m_schoolAbsorb = 0;
		}break;
	case SPELL_AURA_MOD_FEAR:
		{
/*            if(apply)
            {
                GetAIInterface()->SetUnitToFear(parent->GetCaster());
                GetAIInterface()->HandleEvent(EVENT_FEAR, this, 0);
            }
            else
            {
                GetAIInterface()->SetUnitToFear(NULL);
                GetAIInterface()->HandleEvent(EVENT_LEAVECOMBAT, this, 0);
            }*/
		}break;
	case SPELL_AURA_EXTRA_ATTACKS:
		{
		}break;
	case SPELL_AURA_MOD_SPELL_CRIT_CHANCE_SCHOOL:
		{
		}break;
	case SPELL_AURA_MOD_POWER_COST:
		{
		}break;
	case SPELL_AURA_MOD_POWER_COST_SCHOOL:
		{
		}break;
	case SPELL_AURA_REFLECT_SPELLS_SCHOOL:
		{
		}break;
	case SPELL_AURA_MOD_LANGUAGE:
		{
		}break;
	case SPELL_AURA_FAR_SIGHT:
		{
		}break;
	case SPELL_AURA_MECHANIC_IMMUNITY:
		{
            apply ? m_polymorphImmunity++ : m_polymorphImmunity--;
            if(m_polymorphImmunity > 4294800000)
                m_polymorphImmunity = 0;
		}break;
	case SPELL_AURA_MOUNTED:
		{
			if(apply)
			{
				CreatureInfo* ci = objmgr.GetCreatureName(mod->GetMiscValue());
				if(!ci)
					break;
				uint32 displayId = ci->DisplayID;
				if(displayId != 0){
					SetUInt32Value( UNIT_FIELD_MOUNTDISPLAYID , displayId);
					SetFlag( UNIT_FIELD_FLAGS , U_FIELD_FLAG_MOUNT_SIT );
				}
			}else
			{
				SetUInt32Value(UNIT_FIELD_MOUNTDISPLAYID , 0);
				RemoveFlag( UNIT_FIELD_FLAGS, U_FIELD_FLAG_MOUNT_SIT );

				if (GetUInt32Value(UNIT_FIELD_FLAGS) & U_FIELD_FLAG_LOCK_PLAYER )
					RemoveFlag( UNIT_FIELD_FLAGS, U_FIELD_FLAG_LOCK_PLAYER );
			}
		}break;
	case SPELL_AURA_MOD_DAMAGE_PERCENT_DONE:
		{
            // FIXME:Use percent update field for players
		}break;
	case SPELL_AURA_PERIODIC_HEAL:
		{
			// Handled in aura handler
		}break;
	case SPELL_AURA_MOD_PERCENT_STAT:
		{
			uint16 index = 0;
			uint16 index2 = 0;
			if (mod->GetMiscValue() == -1)
			{
				index = UNIT_FIELD_STAT0;
				mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_POSSTAT0 : index2 = PLAYER_FIELD_NEGSTAT0;
				for(uint32 i=0;i<5;i++)
				{
					if(apply){
						SetUInt32Value(index+i,GetUInt32Value(index+i)+GetUInt32Value(index+i)/100*mod->GetAmount());
						SetUInt32Value(index2+1,GetUInt32Value(index2+i)+GetUInt32Value(index2+i)/100*mod->GetAmount());
					}else{
						SetUInt32Value(index+i,GetUInt32Value(index+i)-GetUInt32Value(index+1)/(100+mod->GetAmount())*100);
						SetUInt32Value(index2+i,GetUInt32Value(index2+i)-GetUInt32Value(index2+1)/(100+mod->GetAmount())*100);
					}
				}
			} else{
				index = UNIT_FIELD_STAT0 + mod->GetMiscValue();
				mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_POSSTAT0+ mod->GetMiscValue() : index2 = PLAYER_FIELD_NEGSTAT0+ mod->GetMiscValue();

			}
			if(apply){
				SetUInt32Value(index,GetUInt32Value(index)+GetUInt32Value(index)/100*mod->GetAmount());
				SetUInt32Value(index2,GetUInt32Value(index2)+GetUInt32Value(index2)/100*mod->GetAmount());
			}else{
				SetUInt32Value(index,GetUInt32Value(index)-GetUInt32Value(index)/(100+mod->GetAmount())*100);
				SetUInt32Value(index2,GetUInt32Value(index2)-GetUInt32Value(index2)/(100+mod->GetAmount())*100);
			}
		}break;
	case SPELL_AURA_SPLIT_DAMAGE:
		{
            //FIXME:Find the flat one id of this.
            //This one uses percent as modifier.
            //Splits damage to party member.
            //There are two spells
            //Uses flags 1=2^0 is physical, 127 = all, 126 = spells etc
            if(apply)
            {
                if(mod->GetMiscValue() == 1)
                {
                    m_meleeDamageSplitPCT++;
                }
                else if(mod->GetMiscValue() == 126)
                {
                    m_meleeDamageSplitPCT++;
                }
                else if(mod->GetMiscValue() == 127)
                {
                    m_meleeDamageSplitPCT++;
                    m_meleeDamageSplitPCT++;
                }                
            }
            else
            {
                if(mod->GetMiscValue() == 1)
                {
                    m_meleeDamageSplitPCT--;
                }
                else if(mod->GetMiscValue() == 126)
                {
                    m_meleeDamageSplitPCT--;
                }
                else if(mod->GetMiscValue() == 127)
                {
                    m_meleeDamageSplitPCT--;
                    m_meleeDamageSplitPCT--;
                }
                if(m_meleeDamageSplitPCT > 4294800000)
                    m_meleeDamageSplitPCT = 0;
            }
		}break;
	case SPELL_AURA_WATER_BREATHING:
		{
		}break;
	case SPELL_AURA_MOD_BASE_RESISTANCE:
		{
		}break;
	case SPELL_AURA_MOD_REGEN:
		{
		}break;
	case SPELL_AURA_MOD_POWER_REGEN:
		{
		}break;
	case SPELL_AURA_CHANNEL_DEATH_ITEM:
		{
			if(apply)
			{
				//dont need for now
			}
			else
			{
				if(getDeathState() == JUST_DIED)
				{
					Item* newItem;
					Item *add;
					uint8 slot = 0;
					Player *pCaster = objmgr.GetPlayer(parent->GetCasterGUID());
					if(!pCaster)
						break;
					add = pCaster->FindItemLessMax(mod->GetMiscValue(),1);
					if (!add)
					{
						slot = pCaster->FindFreeInvSlot();
					}
					if(slot == INVENTORY_NO_SLOT_AVAILABLE)
					{
						pCaster->BuildInventoryChangeError(NULL, NULL, INV_ERR_INVENTORY_FULL);
						break;
					}
					if (!add)
					{
                        sLog.outDebug("DeathItem UNIT");
						uint32 itemGuid = objmgr.GenerateLowGuid(HIGHGUID_ITEM);
						Item *item = new Item();
						item->Create(itemGuid, mod->GetMiscValue(), pCaster);
						item->SetUInt32Value(OBJECT_FIELD_TYPE, 3);
						item->SetUInt32Value(ITEM_FIELD_FLAGS, 0x00000001);
						item->SetUInt32Value(ITEM_FIELD_ENCHANTMENT, 11040);
						item->SetUInt32Value(ITEM_FIELD_PROPERTY_SEED, 760411200);
						pCaster->AddItemToSlot(slot, item);
						item->SetUInt64Value(ITEM_FIELD_CREATOR,pCaster->GetGUID());
					}
					else
					{
						add->SetUInt32Value(ITEM_FIELD_STACK_COUNT,add->GetUInt32Value(ITEM_FIELD_STACK_COUNT) + 1);
					}
				}
			}

		}break;
	case SPELL_AURA_MOD_DAMAGE_PERCENT_TAKEN:
		{
            apply ? m_damageTakenPCT++ : m_damageTakenPCT--;
            if(m_damageTakenPCT > 4294800000)
                m_damageTakenPCT = 0;
		}break;
	case SPELL_AURA_MOD_PERCENT_REGEN:
		{
		}break;
	case SPELL_AURA_PERIODIC_DAMAGE_PERCENT:
		{
		}break;
	case SPELL_AURA_MOD_ATTACKSPEED:
		{
			apply ? SetUInt32Value(UNIT_MOD_CAST_SPEED,GetUInt32Value(UNIT_MOD_CAST_SPEED) + mod->GetAmount()) : SetUInt32Value(UNIT_MOD_CAST_SPEED,GetUInt32Value(UNIT_MOD_CAST_SPEED) - mod->GetAmount());
		}break;
	case SPELL_AURA_MOD_RESIST_CHANCE:
		{
			apply ? m_resistChance = mod->GetAmount() : m_resistChance = 0;
		}break;
	case SPELL_AURA_MOD_DETECT_RANGE:
		{
			//reduce in range set
		}break;
	case SPELL_AURA_PREVENTS_FLEEING:
		{
			// Curse of Recklessness 
		}break;
	case SPELL_AURA_MOD_UNATTACKABLE:
		{
		}break;
	case SPELL_AURA_INTERRUPT_REGEN:
		{
			apply ? m_interruptRegen++ : m_interruptRegen--;
            if(m_interruptRegen > 4294800000)
                m_interruptRegen = 0;
		}break;
	case SPELL_AURA_GHOST:
		{
			//need to add ghost check to update
		}break;
	case SPELL_AURA_SPELL_MAGNET:
		{
			/*shaman got a totem called grounding totem
			if you cast it
			1 negative spell casted on you will be casted on that totem instead of you
			for example a damage spell
			so you wont get damage of that 1 spell
			next spell will deal damage on you of course*/
		}break;
	case SPELL_AURA_MANA_SHIELD:
		{
			apply ? m_manaShield = true : m_manaShield = false;
		}break;
	case SPELL_AURA_MOD_SKILL_TALENT:
		{
			//need talent system
		}break;
	case SPELL_AURA_MOD_ATTACK_POWER:
		{
			//apply ? SetUInt32Value(UNIT_FIELD_ATTACKPOWER,GetUInt32Value(UNIT_FIELD_ATTACKPOWER) + mod->GetAmount()) : SetUInt32Value(UNIT_FIELD_ATTACKPOWER,GetUInt32Value(UNIT_FIELD_ATTACKPOWER) - mod->GetAmount());
			apply ? SetUInt32Value(UNIT_FIELD_ATTACK_POWER_MODS,GetUInt32Value(UNIT_FIELD_ATTACK_POWER_MODS) + mod->GetAmount()) : SetUInt32Value(UNIT_FIELD_ATTACK_POWER_MODS,GetUInt32Value(UNIT_FIELD_ATTACK_POWER_MODS) - mod->GetAmount());
		}break;
	default:
		{
			Log::getSingleton().outError("Unknown affect id %u", (uint32)mod->GetType());
		}
	}
}

void Unit::_UpdateAura()
{
	if(GetTypeId() != TYPEID_PLAYER || !m_aura)
		return;

	Player* pThis = objmgr.GetObject<Player>(GetGUID());

	Player* pGroupGuy;
	Group* pGroup;

	if(pThis)
		pGroup = objmgr.GetGroupByLeader(pThis->GetGroupLeader());

	if(!SetAffDuration(m_aura->GetId(),this,6000))
		AddAffect(m_aura);

	if(!pGroup)
		return;
	else{
		for(uint32 i=0;i<pGroup->GetMembersCount();i++){
			pGroupGuy = objmgr.GetObject<Player>(pGroup->GetMemberGUID(i));
			if(!pGroupGuy)
				continue;
			if(pGroupGuy->GetGUID() == GetGUID())
				continue;
			if(sqrt(
				(GetPositionX()-pGroupGuy->GetPositionX())*(GetPositionX()-pGroupGuy->GetPositionX())
				+(GetPositionY()-pGroupGuy->GetPositionY())*(GetPositionY()-pGroupGuy->GetPositionY())
				+(GetPositionZ()-pGroupGuy->GetPositionZ())*(GetPositionZ()-pGroupGuy->GetPositionZ())
				) <=30){
					if(!pGroupGuy->SetAffDuration(m_aura->GetId(),this,6000))
						pGroupGuy->AddAffect(m_aura);
				}else{
					if(m_removeAuraTimer == 0){
						printf("remove aura from %u\n", pGroupGuy->GetGUID());
						pGroupGuy->RemoveAffectById(m_aura->GetId());
						//pGroupGuy->SetAffDuration(m_aura->GetId(),this,0);
					}
				}
		}
	}
	if(m_removeAuraTimer > 0)
		m_removeAuraTimer -= 1;
	else
		m_removeAuraTimer = 4;
}
bool Unit::HasAffects()
{
	if (m_affects.size() == 0)
	{
		hasAffects = false;
		return false;
	}
	else
		return true;
}
void Unit::_UpdateSpells( uint32 time )
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

	if(HasAffects())
	{
		Affect *aff;
		AffectList::iterator i, next;
		for (i = m_affects.begin(); i != m_affects.end(); i = next)
		{
			if (HasAffects())
			{
				next = i;
				next++;

				aff = *i;

				uint32 AffResult = 0;
				AffResult =	aff->Update( time );
				//if( AffResult == 2 || AffResult == 6 || AffResult == 10 || AffResult == 14)
                if(AffResult & FLAG_PERIODIC_DAMAGE)
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
				//if( AffResult == 4 || AffResult == 6 || AffResult == 12 || AffResult == 14)
                if(AffResult & FLAG_PERIODIC_TRIGGER_SPELL)
				{
					// Trigger Spell
					// check for spell id
					SpellEntry *spellInfo = sSpellStore.LookupEntry( aff->GetSpellPerTick() );

					if(!spellInfo)
					{
						Log::getSingleton( ).outError("WORLD: unknown spell id %i\n", aff->GetSpellPerTick());
						return;
					}

					Spell *spell = new Spell(this, spellInfo, true, aff, false);
					SpellCastTargets targets;
					WorldPacket dump;
					dump.Initialize(0);
					dump << uint16(2) << GetUInt32Value(UNIT_FIELD_CHANNEL_OBJECT) << GetUInt32Value(UNIT_FIELD_CHANNEL_OBJECT+1);
					targets.read(&dump,GetGUID());

					spell->prepare(&targets);
					delete spell;
				}
				//if( AffResult == 8 || AffResult == 10 || AffResult == 12 || AffResult == 14)
                if(AffResult & FLAG_PERIODIC_HEAL)
				{
					Unit *attacker = (Unit*) objmgr.GetObject<Player>(aff->GetCasterGUID());
					if(!attacker)
						attacker = (Unit*) objmgr.GetObject<Creature>(aff->GetCasterGUID());

					// FIXME: we currently have a way to inflict damage w/o attacker, this should be changed
					if(attacker)
					{
						if(this->isAlive()){
							if(GetUInt32Value(UNIT_FIELD_HEALTH) + aff->GetHealPerTick() < GetUInt32Value(UNIT_FIELD_MAXHEALTH))
								SetUInt32Value(UNIT_FIELD_HEALTH,GetUInt32Value(UNIT_FIELD_HEALTH) + aff->GetHealPerTick());
							else
								SetUInt32Value(UNIT_FIELD_HEALTH,GetUInt32Value(UNIT_FIELD_MAXHEALTH));
							WorldPacket data;
							data.Initialize(SMSG_SPELLLOGEXECUTE);
							data << attacker->GetNewGUID();
							data << uint32(aff->GetSpellId());
							data << uint32(1);
							data << uint32(10);
							data << uint32(1);
							data << attacker;
							data << aff->GetHealPerTick();
							data << uint8(0);
							attacker->SendMessageToSet(&data,true);
						}
					}
				}
				//if( AffResult == 16 ) //|| AffResult == 10 || AffResult == 12 || AffResult == 14)
                if(AffResult & FLAG_PERIODIC_LEECH)
				{
					Unit *attacker = (Unit*) objmgr.GetObject<Player>(aff->GetCasterGUID());
					if(!attacker)
						attacker = (Unit*) objmgr.GetObject<Creature>(aff->GetCasterGUID());

					// FIXME: we currently have a way to inflict damage w/o attacker, this should be changed
					if(attacker)
					{
						if(this->isAlive())
						{
							switch(aff->GetLeechType())
							{
							case SPELL_AURA_PERIODIC_LEECH:
								{
									attacker->PeriodicAuraLog(this, aff->GetId(), aff->GetLeechPerTick(),aff->GetSpellProto()->School);
									if(attacker->GetUInt32Value(UNIT_FIELD_HEALTH) + aff->GetLeechPerTick() < attacker->GetUInt32Value(UNIT_FIELD_MAXHEALTH))
										attacker->SetUInt32Value(UNIT_FIELD_HEALTH,attacker->GetUInt32Value(UNIT_FIELD_HEALTH) + aff->GetLeechPerTick());
									else
										attacker->SetUInt32Value(UNIT_FIELD_HEALTH,attacker->GetUInt32Value(UNIT_FIELD_MAXHEALTH));
									WorldPacket data;
									data.Initialize(SMSG_SPELLLOGEXECUTE);
									data << attacker->GetNewGUID();
									data << uint32(aff->GetSpellId());
									data << uint32(1);
									data << uint32(10);
									data << uint32(1);
									data << attacker;
									data << aff->GetLeechPerTick();
									data << uint8(0);
									attacker->SendMessageToSet(&data,true);
								}
							case SPELL_AURA_PERIODIC_MANA_LEECH:
								{
									if(GetUInt32Value(UNIT_FIELD_POWER4) >= 0)
									{
										if(GetUInt32Value(UNIT_FIELD_POWER4) - aff->GetLeechPerTick() < 0)
											SetUInt32Value(UNIT_FIELD_POWER4,0);
										else
											SetUInt32Value(UNIT_FIELD_POWER4,GetUInt32Value(UNIT_FIELD_MAXPOWER4) - aff->GetLeechPerTick());

										if(attacker->GetUInt32Value(UNIT_FIELD_POWER4) + aff->GetLeechPerTick() < attacker->GetUInt32Value(UNIT_FIELD_MAXPOWER4))
											attacker->SetUInt32Value(UNIT_FIELD_POWER4,attacker->GetUInt32Value(UNIT_FIELD_POWER4) + aff->GetLeechPerTick());
										else
											attacker->SetUInt32Value(UNIT_FIELD_POWER4,attacker->GetUInt32Value(UNIT_FIELD_MAXPOWER4));
										WorldPacket data;
										data.Initialize(SMSG_SPELLLOGEXECUTE);
										data << attacker->GetNewGUID();
										data << uint32(aff->GetSpellId());
										data << uint32(1);
										data << uint32(10);
										data << uint32(1);
										data << attacker;
										data << aff->GetLeechPerTick();
										data << uint8(0);
										attacker->SendMessageToSet(&data,true);
									}
								}
							}
						}
						else
						{
							aff->SetDuration(0);
							attacker->m_currentSpell->cancel();
						}
					}
				}
                //if( AffResult == 32 ) //|| AffResult == 10 || AffResult == 12 || AffResult == 14)
                if(AffResult & FLAG_PERIODIC_ENERGIZE)
				{
					Unit *attacker = (Unit*) objmgr.GetObject<Player>(aff->GetCasterGUID());
					if(!attacker)
						attacker = (Unit*) objmgr.GetObject<Creature>(aff->GetCasterGUID());

					// FIXME: we currently have a way to inflict damage w/o attacker, this should be changed
					if(attacker)
					{
						if(this->isAlive())
						{
                            uint32 powerField;
                            uint32 currentPower;
                            switch(aff->GetSpellProto()->powerType){
		                        case POWER_TYPE_HEALTH:{
			                        powerField = UNIT_FIELD_HEALTH;
		                        }break;
		                        case POWER_TYPE_MANA:{
			                        powerField = UNIT_FIELD_POWER1;
		                        }break;
		                        case POWER_TYPE_RAGE:{
			                        powerField = UNIT_FIELD_POWER2;
		                        }break;
		                        case POWER_TYPE_ENERGY:{
			                        powerField = UNIT_FIELD_POWER4;
		                        }break;
		                        default:{
			                        sLog.outDebug("unknown power type");
                                    break;
		                        }break;
	                        }
                            int mod = 0;
                            currentPower = GetUInt32Value(powerField);
	                        if (GetTypeId() == TYPEID_PLAYER)
	                        {
		                        mod = (((Player*)this)->GetSpellManaMod(aff->GetSpellProto()->Id) / 100.0f) * aff->GetSpellProto()->manaCost;
	                        }
	                        
	                        if(currentPower < (aff->GetSpellProto()->manaCost + mod))
		                        SetUInt32Value(powerField, 0);
	                        else
                                SetUInt32Value(powerField, currentPower - (aff->GetSpellProto()->manaCost + mod));
                            switch(aff->GetEnergizeType())
							{
                                uint32 POWER_TYPE;
                                case 0:{
                                    POWER_TYPE = UNIT_FIELD_POWER1;
                                }break;
                                case 1:{
                                    POWER_TYPE = UNIT_FIELD_POWER2;
                                }break;
                                case 2:{
                                    POWER_TYPE = UNIT_FIELD_POWER3;
                                }break;
                                case 3:{
                                    POWER_TYPE = UNIT_FIELD_POWER4;
                                }break;
                                case 4:{
                                    POWER_TYPE = UNIT_FIELD_POWER5;
                                }break;
                                uint32 damage = aff->GetEnergizePerTick();
                                if(POWER_TYPE == UNIT_FIELD_POWER2)
                                    damage = damage*10;

                                uint32 curEnergy = (uint32)GetUInt32Value(POWER_TYPE);
                                uint32 maxEnergy = (uint32)GetUInt32Value(POWER_TYPE+6);
                                uint32 totalEnergy = curEnergy+damage;
                                if(totalEnergy > maxEnergy)
                                    SetUInt32Value(POWER_TYPE,(uint32)maxEnergy);
                                else
                                    SetUInt32Value(POWER_TYPE,(uint32)totalEnergy);
                            }
						}
						else
						{
							aff->SetDuration(0);
							attacker->m_currentSpell->cancel();
						}
					}
				}
				if (aff)
				{
					if ( !aff->GetDuration() &&  (aff->GetSpellProto()->DurationIndex != 0))
					{
							RemoveAffect(aff);
					}
				}
			}
			else break;
		}
	}
}


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

void Unit::InterruptSpell()
{
	if(m_currentSpell){
		m_currentSpell->SendInterrupted(0x1f);
		m_currentSpell->cancel();
		m_currentSpell = NULL;
	}
}


void Unit::_AddAura(Affect *aff)
{
	ASSERT(aff);

	if (!aff->GetId())
	{
		return;
	}
	SpellEntry *spell = sSpellStore.LookupEntry(aff->GetSpellId());
	if (spell->Attributes & 64)
		return;

	//UNIT_FIELD_AURAFLAGS 0-7;UNIT_FIELD_AURAFLAGS+1 8-15;UNIT_FIELD_AURAFLAGS+2 16-23 ... For each Aura 1 Byte

	WorldPacket data;

	uint8 slot, i;

	slot = 0xFF;

	if (aff->IsPositive())
	{
		for (i = 0; i < MAX_POSITIVE_AURAS; i++)
		{
			if (GetUInt32Value((uint16)(UNIT_FIELD_AURA + i)) == 0)
			{
				slot = i;
				break;
			}
		}
	}
	else
	{
		for (i = MAX_POSITIVE_AURAS; i < MAX_AURAS; i++)
		{
			if (GetUInt32Value((uint16)(UNIT_FIELD_AURA + i)) == 0)
			{
				slot = i;
				break;
			}
		}
	}

	if (slot == 0xFF)
	{
		return;
	}

	SetUInt32Value((uint16)(UNIT_FIELD_AURA + slot), aff->GetId());

	uint8 flagslot = slot >> 3;
	uint32 value = GetUInt32Value((uint16)(UNIT_FIELD_AURAFLAGS + flagslot));
	value |= 0xFFFFFFFF & (AFLAG_SET << ((slot & 7) << 2));
	SetUInt32Value((uint16)(UNIT_FIELD_AURAFLAGS + flagslot), value);

	//  0000 0000 original
	//  0000 1001 AFLAG_SET
	//  1111 1111 0xFF

	uint8 appslot = slot >> 1;

	/*
	value = GetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS + appslot);
	uint16 *dmg = ((uint16*)&value) + (slot & 1);
	*dmg = 5; // FIXME: use correct value
	SetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS + appslot, value);
	*/

	if( GetTypeId() == TYPEID_PLAYER )
	{
		data.Initialize(SMSG_UPDATE_AURA_DURATION);
		data << (uint8)slot << (uint32)aff->GetDuration();
		((Player*)this)->GetSession()->SendPacket(&data);
	}

	aff->SetAuraSlot( slot );

	return;
}


void Unit::_RemoveAura(Affect *aff)
{
	ASSERT(aff);

	//UNIT_FIELD_AURAFLAGS 0-7;UNIT_FIELD_AURAFLAGS+1 8-15;UNIT_FIELD_AURAFLAGS+2 16-23 ... For each Aura 1 Byte

	uint8 slot = aff->GetAuraSlot();

	SetUInt32Value((uint16)(UNIT_FIELD_AURA + slot), 0);

	uint8 flagslot = slot >> 3;

	uint32 value = GetUInt32Value((uint16)(UNIT_FIELD_AURAFLAGS + flagslot));
	value &= 0xFFFFFFFF ^ (0xF << ((slot & 7) << 2));
	SetUInt32Value((uint16)(UNIT_FIELD_AURAFLAGS + flagslot), value);

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

Affect* Unit::FindAff(uint32 spellId)
{
	AffectList::iterator i;
	for (i = m_affects.begin(); i != m_affects.end(); i++)
		if((*i)->GetId() == spellId)
			return (*i);
	return NULL;
}

Affect* Unit::FindAff(uint32 spellId, uint64 guid)
{
	AffectList::iterator i;
	for (i = m_affects.begin(); i != m_affects.end(); i++)
		if((*i)->GetId() == spellId && (*i)->GetCasterGUID() == guid)
			return (*i);
	return NULL;
}
/*
float Unit::getDistance( float Position1X, float Position1Y, float Position2X, float Position2Y )
{
return sqrt( ( Position1X - Position2X ) * ( Position1X - Position2X ) + ( Position1Y - Position2Y ) * ( Position1Y - Position2Y ) );
}
*/
void Unit::DeMorph()
{
	// hope it solves it :)
	uint32 displayid = this->GetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID);
	this->SetUInt32Value(UNIT_FIELD_DISPLAYID, displayid);
}
void Unit::Emote (EmoteType emote)
{
	WorldPacket data;
	data.Initialize (SMSG_EMOTE);
	data << uint32(emote);
	data << this->GetGUID();
	SendMessageToSet (&data, true);
}

void Unit::StatListener()
{
	for(uint16 i = 0; i < 5; i++)
	{
		if(s_stats[i] != GetUInt32Value(UNIT_FIELD_STAT0 + i)) // Stat has changed
		{
			CalculateStat(UNIT_FIELD_STAT0 + i, GetUInt32Value(UNIT_FIELD_STAT0 + i) - s_stats[i]);
			s_stats[i] = GetUInt32Value(UNIT_FIELD_STAT0 + i);
			if(i == AGILITY) //Stat 1 AGI
			{
				CalculateActualArmor(); //Update Armor
			}
		}
	}
}

void Unit::CalculateStat(uint16 field, int16 mod)
{
	// modify Stat
	switch(field)
	{
	case UNIT_FIELD_STAT0: // Strength
		{
			// Attackpower
			if(GetTypeId() == TYPEID_PLAYER)
			{
				if(((Player*)this)->getClass() == HUNTER ||((Player*)this)->getClass() == ROGUE)
				{
					SetUInt32Value(UNIT_FIELD_ATTACK_POWER, GetUInt32Value(UNIT_FIELD_ATTACK_POWER) + mod);
				}else
				{
					SetUInt32Value(UNIT_FIELD_ATTACK_POWER, GetUInt32Value(UNIT_FIELD_ATTACK_POWER) + mod * 2);
				}
			}
			else
			{
				SetUInt32Value(UNIT_FIELD_ATTACK_POWER, GetUInt32Value(UNIT_FIELD_ATTACK_POWER) + mod * 2);
			}
		}break;
	case UNIT_FIELD_STAT1: // Agility
		{
			SetUInt32Value(UNIT_FIELD_RESISTANCES, GetUInt32Value(UNIT_FIELD_RESISTANCES) + mod * 2);
			if(GetTypeId() == TYPEID_PLAYER)
			{
				// Crit Chance
				if(((Player*)this)->getClass() == ROGUE)
				{
					SetFloatValue(PLAYER_CRIT_PERCENTAGE, GetFloatValue(PLAYER_CRIT_PERCENTAGE) + mod * 0.042f);
				}else if(((Player*)this)->getClass() == HUNTER)
				{
					SetFloatValue(PLAYER_CRIT_PERCENTAGE, GetFloatValue(PLAYER_CRIT_PERCENTAGE) + mod * 0.018f);
				}else
				{
					SetFloatValue(PLAYER_CRIT_PERCENTAGE, GetFloatValue(PLAYER_CRIT_PERCENTAGE) + mod * 0.05f);
				}
				// Dodge Chance
				if(((Player*)this)->getClass() == ROGUE)
				{
					SetFloatValue(PLAYER_DODGE_PERCENTAGE, GetFloatValue(PLAYER_DODGE_PERCENTAGE) + mod * 0.056f);
				}else if(((Player*)this)->getClass() == HUNTER)
				{
					SetFloatValue(PLAYER_DODGE_PERCENTAGE, GetFloatValue(PLAYER_DODGE_PERCENTAGE) + mod * 0.038f);
				}else
				{
					SetFloatValue(PLAYER_DODGE_PERCENTAGE, GetFloatValue(PLAYER_DODGE_PERCENTAGE) + mod * 0.05f);
				}
				// Attack Power
				if(((Player*)this)->getClass() == HUNTER ||((Player*)this)->getClass() == ROGUE)
				{// Todo: Increase Attackpower for Druids in Catform
					SetUInt32Value(UNIT_FIELD_ATTACK_POWER, GetUInt32Value(UNIT_FIELD_ATTACK_POWER) + mod);
				}
			}else
			{
				// Increase Crit/Dodge Chance for Creatures
			}
		}break;
	case UNIT_FIELD_STAT2: // Stamina
		{
			// Health
			SetUInt32Value(UNIT_FIELD_MAXHEALTH, GetUInt32Value(UNIT_FIELD_MAXHEALTH) + mod * 10);
			if(GetUInt32Value(UNIT_FIELD_MAXHEALTH) < GetUInt32Value(UNIT_FIELD_HEALTH))
				SetUInt32Value(UNIT_FIELD_HEALTH, GetUInt32Value(UNIT_FIELD_MAXHEALTH));
		}break;
	case UNIT_FIELD_STAT3: // Intellect
		{ // Todo: Calculate Spell Crit Chance, Increase the rate at which you learn weapon skills
			// Mana
			SetUInt32Value(UNIT_FIELD_MAXPOWER1, GetUInt32Value(UNIT_FIELD_MAXPOWER1) + mod * 15);
			if(GetUInt32Value(UNIT_FIELD_MAXPOWER1) < GetUInt32Value(UNIT_FIELD_POWER1))
				SetUInt32Value(UNIT_FIELD_POWER1, GetUInt32Value(UNIT_FIELD_MAXPOWER1));
		}break;
	case UNIT_FIELD_STAT4: // Spirit
		{
			// Todo: Modify Regenaration Rate for Life and Mana
		}break;
	default:
		{
			// Todo: nothing
		}break;
	}
}

void Unit::SendChatMessage(uint8 type, uint32 lang, const char *msg)
{
	WorldPacket data;
	uint32 UnitNameLength = 0, MessageLength = 0;
	const char *UnitName = "";
	CreatureInfo *ci;

	ci = objmgr.GetCreatureName(GetUInt32Value(OBJECT_FIELD_ENTRY));

	UnitName = ci->Name.c_str();
	UnitNameLength = strlen((char*)UnitName) + 1;
	MessageLength = strlen((char*)msg) + 1;

	switch(type)
	{
	case CHAT_MSG_MONSTER_SAY:
		{
			for(Object::InRangeSet::iterator i = GetInRangeSetBegin(); i != GetInRangeSetEnd(); i++)
			{
				if((*i)->GetTypeId() == TYPEID_PLAYER)
				{
					data.clear();
					data.Initialize(SMSG_MESSAGECHAT);
					data << type;
					data << lang;
					data << GetGUID();
					data << UnitNameLength;
					data << UnitName;
					data << ((Player*)(*i))->GetGUID();
					data << MessageLength;
					data << msg;
					data << uint8(0x00);

					WorldSession *session = ((Player*)(*i))->GetSession();
					session->SendPacket(&data);
				}
			}
		}break;
	case CHAT_MSG_MONSTER_YELL:
		{
			for(Object::InRangeSet::iterator i = GetInRangeSetBegin(); i != GetInRangeSetEnd(); i++)
			{
				if((*i)->GetTypeId() == TYPEID_PLAYER)
				{
					data.clear();
					data.Initialize(SMSG_MESSAGECHAT);
					data << type;
					data << lang;
					data << GetGUID();
					data << UnitNameLength;
					data << UnitName;
					data << ((Player*)(*i))->GetGUID();
					data << MessageLength;
					data << msg;
					data << uint8(0x00);

					WorldSession *session = ((Player*)(*i))->GetSession();
					session->SendPacket(&data);
				}
			}
		}break;

	case CHAT_MSG_MONSTER_EMOTE:
		{
			for(Object::InRangeSet::iterator i = GetInRangeSetBegin(); i != GetInRangeSetEnd(); i++)
			{
				if((*i)->GetTypeId() == TYPEID_PLAYER)
				{
					data.clear();
					data.Initialize(SMSG_MESSAGECHAT);
					data << type;
					data << lang;
					data << GetGUID();
					data << UnitNameLength;
					data << UnitName;
					data << ((Player*)(*i))->GetGUID();
					data << MessageLength;
					data << msg;
					data << uint8(0x00);

					WorldSession *session = ((Player*)(*i))->GetSession();
					session->SendPacket(&data);
				}
			}
		}break;
	default:break;
	}
}

void Unit::LoadAIAgents()
{
	std::stringstream ss;
	ss << "SELECT * FROM ai_agents where entryId=" << GetUInt32Value(OBJECT_FIELD_ENTRY);
	QueryResult *result = sDatabase.Query( ss.str().c_str() );

	if( !result )
		return;

	AI_Spell *sp;

	do
	{
		Field *fields = result->Fetch();

		sp = new AI_Spell;
		sp->entryId = fields[0].GetUInt32();
		sp->agent = fields[1].GetUInt16();
		sp->procEvent = fields[2].GetUInt32();
		sp->procChance = fields[3].GetUInt32();
		sp->procCount = fields[4].GetUInt32();
		sp->spellId = fields[5].GetUInt32();
		sp->spellType = fields[6].GetUInt32();;
		sp->spelltargetType = fields[7].GetUInt32();
		sp->spellCooldown = fields[8].GetUInt32();
		sp->floatMisc1 = fields[9].GetFloat();
		sp->Misc2 = fields[10].GetUInt32();
		sp->spellCooldownTimer = 0;
		sp->procCounter = 0;
		sp->minrange = GetMinRange(sSpellRange.LookupEntry(sSpellStore.LookupEntry(sp->spellId)->rangeIndex));
		sp->maxrange = GetMaxRange(sSpellRange.LookupEntry(sSpellStore.LookupEntry(sp->spellId)->rangeIndex));

		if(sp->agent == AGENT_RANGED)
		{
			GetAIInterface()->m_canRangedAttack = true;
		}else if(sp->agent == AGENT_FLEE)
		{
			GetAIInterface()->m_canFlee = true;
		}else if(sp->agent == AGENT_CALLFORHELP)
		{
			GetAIInterface()->m_canCallForHelp = true;
		}else
		{
			GetAIInterface()->addSpellToList(sp);
		}


	} while( result->NextRow() );

	delete result;
}

void Unit::RemoveInRangeObject(Object* pObj)
{
	Object::RemoveInRangeObject(pObj);
/*	if(GetTypeId() == TYPEID_UNIT && (pObj->GetTypeId() == TYPEID_UNIT || pObj->GetTypeId() == TYPEID_PLAYER)
		&& (myFaction & ((Unit *)pObj)->hostile))
	{
		Object::RemoveInRangeOppFactObject(pObj);
	}*/
}

CreatureInfo *Unit::GetCreatureName() { 
	if(creature_info)
	{
		return creature_info; 
	}
	else
	{
		creature_info = objmgr.GetCreatureName(GetUInt32Value(OBJECT_FIELD_ENTRY));
        return creature_info;
	}
}

uint32 Unit::CalculateDamageExt()
{
    uint32 damage = 0;
    damage = CalculateDamage(this);

    return damage;
}

void Unit::WipeHateList() { GetAIInterface()->WipeHateList(); }
void Unit::WipeTargetList() { GetAIInterface()->WipeTargetList(); }
