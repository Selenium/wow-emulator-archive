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
#include "Unit.h"
#include "Quest.h"
#include "Player.h"
#include "Creature.h"
#include "Spell.h"
#include "Stats.h"
#include "Group.h"
#include "Affect.h"
#include <math.h>

#define DEG2RAD (M_PI/180.0)
#define M_PI       3.14159265358979323846


Unit::Unit() : Object()
{
    m_objectType |= TYPE_UNIT;
    m_objectTypeId = TYPEID_UNIT;

    m_attackTimer = 0;

    m_state = 0;
    m_deathState = ALIVE;
    m_currentSpell = NULL;
    m_meleeSpell = false;
    m_addDmgOnce = NULL;
    m_TotemSlot1 = m_TotemSlot2 = m_TotemSlot3 = m_TotemSlot4  = 0;
    m_aura = NULL;
    m_auraCheck = 2000;
    tmpAffect = NULL;
    m_silenced = false;
}


Unit::~Unit()
{
}


void Unit::Update( uint32 p_time )
{
    _UpdateSpells( p_time );

    if(m_attackTimer > 0)
    {
        if(p_time >= m_attackTimer)
            m_attackTimer = 0;
        else
            m_attackTimer -= p_time;
    }
}


void Unit::setAttackTimer()
{
    m_attackTimer = GetUInt32Value(UNIT_FIELD_BASEATTACKTIME);
}


bool Unit::canReachWithAttack(Unit *pVictim) const
{
    float reach = GetFloatValue(UNIT_FIELD_COMBATREACH);
    float radius = GetFloatValue(UNIT_FIELD_BOUNDINGRADIUS);

    if (GetDistanceSq(pVictim) > (reach + radius)*(reach + radius))
        return false;

    return true;
}


void Unit::DealDamage(Unit *pVictim, uint32 damage)
{
    uint32 health = pVictim->GetUInt32Value(UNIT_FIELD_HEALTH );
    if (health <= damage)
    {
        if(pVictim->GetTypeId() == TYPEID_UNIT)
            ((Creature*)pVictim)->generateLoot();

        // FIXME: should we remove all equipment affects too
//        if(pVictim->GetTypeId() == TYPEID_PLAYER)
//            _RemoveAllItemMods();

        pVictim->RemoveAllAffects();

        // victim died!
        pVictim->setDeathState(JUST_DIED);

        // Send SMSG_PARTYKILLLOG 0x1e6
        // To everyone in the party?

        // SMSG_ATTACKSTOP
        uint64 attackerGuid, victimGuid;
        attackerGuid = GetGUID();
        victimGuid = pVictim->GetGUID();

        pVictim->smsg_AttackStop(attackerGuid);

        // Send MSG_MOVE_ROOT   0xe7

        // Set update values... try flags 917504
        // health
        pVictim->SetUInt32Value(UNIT_FIELD_HEALTH, 0);

        // then another update message, sets health to 0, maxhealth to 100, and dynamic flags
        pVictim->SetUInt32Value(UNIT_FIELD_HEALTH, 0);
        pVictim->RemoveFlag(UNIT_FIELD_FLAGS, 0x00080000);

        if (pVictim->GetTypeId() != TYPEID_PLAYER)
            pVictim->SetUInt32Value(UNIT_DYNAMIC_FLAGS, 1);

        if (GetTypeId() == TYPEID_PLAYER)
        {
            uint32 xp = CalculateXpToGive(pVictim, this);

            // check running quests in case this monster belongs to it
            uint32 entry = 0;
            if (pVictim->GetTypeId() != TYPEID_PLAYER)
                entry = pVictim->GetUInt32Value(OBJECT_FIELD_ENTRY );

            // Is this player part of a group?
            Group *pGroup = objmgr.GetGroupByLeader(((Player*)this)->GetGroupLeader());
            if (pGroup)
            {
                xp /= pGroup->GetMembersCount();
                for (uint32 i = 0; i < pGroup->GetMembersCount(); i++)
                {
                    Player *pGroupGuy = objmgr.GetObject<Player>(pGroup->GetMemberGUID(i));
                    pGroupGuy->GiveXP(xp, victimGuid);

                    if (pVictim->GetTypeId() != TYPEID_PLAYER)
                        pGroupGuy->KilledMonster(entry, victimGuid);
                }
            }
            else
            {
                // update experience
                ((Player*)this)->GiveXP(xp, victimGuid);

                if (pVictim->GetTypeId() != TYPEID_PLAYER)
                    ((Player*)this)->KilledMonster(entry, victimGuid);
            }
        }
        else
        {
            smsg_AttackStop(victimGuid);
            RemoveFlag(UNIT_FIELD_FLAGS, 0x00080000);
            addStateFlag(UF_TARGET_DIED);
        }
    }
    else
    {
        pVictim->SetUInt32Value(UNIT_FIELD_HEALTH , health - damage);

         // this need alot of work.
        if (pVictim->GetTypeId() != TYPEID_PLAYER)
        {

           Log::getSingleton( ).outDetail("Attacking back");
            ((Creature*)pVictim)->AI_ChangeState(ATTACKING); // when attacked mobs stop moving around
            ((Creature*)pVictim)->AI_AttackReaction(this, damage);
            /*
            //uint32 max_health = GetUInt32Value(UNIT_FIELD_MAXHEALTH);
            //uint32 health_porcent = (max_health*10)/100; // this if for know 10% of total healt,need changes about mobs lvls
            pVictim->AI_ChangeState(3); //if mob are attack then they stop moving around
            pVictim->AI_AttackReaction(pAttacker, damage);

            //well mobs scape if have a movement assignet atm
            //if(health<=health_porcent)
            {}
            */

        }
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
    data << pVictim->GetGUID();
    data << this->GetGUID();
    data << spellID;
    data << damage;
    data << uint32(0);
    data << uint32(0);
    data << uint32(0);
    data << uint32(0);
    SendMessageToSet(&data,true);
    DealDamage(pVictim, damage);
}

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

void Unit::AttackerStateUpdate(Unit *pVictim,uint32 damage,bool DoT)
{
    uint32 spell = 0;
    if (pVictim->GetUInt32Value(UNIT_FIELD_HEALTH) == 0 ||
        GetUInt32Value(UNIT_FIELD_HEALTH) == 0 )
        return;

    WorldPacket data;
    uint32 hit_status = 0xe2;
    uint32 damageType = 0;

    if(damage == 0)
        damage = CalculateDamage(this);
    else
        damageType = 1;

    if(DoT)
        hit_status = 0;

    if(m_meleeSpell == true)// if we are currently casting a melee spell then finish it now
    {
        if(m_currentSpell->getState() == SPELL_STATE_IDLE){
            spell = m_currentSpell->m_spellInfo->Id;
            m_currentSpell->SendCastResult(0);
            m_currentSpell->SendSpellGo();
            for(uint32 i=0;i<2;i++)
                m_currentSpell->HandleEffects(m_currentSpell->m_targets.m_unitTarget,i);
            m_currentSpell->finish();
        }
    }

    uint32 some_value = 0xffffffff;
    some_value = 0x0;

    data.Initialize(SMSG_ATTACKERSTATEUPDATE);
    data << (uint32)hit_status;   // Attack flags
    data << GetGUID();
    data << pVictim->GetGUID();
    data << (uint32)damage;
    data << (uint8)1;       // Damage type counter

    // for each...
    data << damageType;      // Damage type, // 0 - white font, 1 - yellow
    data << (uint32)0;      // damage float
    data << (uint32)damage; // Damage amount
    data << (uint32)0;      // damage absorbed

    data << (uint32)1;      // new victim state
    data << (uint32)0;      // victim round duraction
    data << (uint32)0;      // additional spell damage amount
    data << (uint32)0;      // additional spell damage id
    data << (uint32)0;      // Damage amount blocked

    WPAssert(data.size() == 61);
    SendMessageToSet(&data, true);

    Log::getSingleton( ).outDetail("AttackerStateUpdate: %u %X attacked %u %X for %u dmg.",
        GetGUIDLow(), GetGUIDHigh(), pVictim->GetGUIDLow(), pVictim->GetGUIDHigh(), damage);

    DealDamage(pVictim, damage);
}

void Unit::smsg_AttackStop(uint64 victimGuid)
{
    WorldPacket data;
    data.Initialize( SMSG_ATTACKSTOP );
    data << GetGUID();
    data << victimGuid;
    data << uint32( 0 );
    SendMessageToSet(&data, true);
    Log::getSingleton( ).outDetail("%u %X stopped attacking "I64FMT,
        GetGUIDLow(), GetGUIDHigh(), victimGuid);
}


void Unit::smsg_AttackStart(Unit* pVictim)
{
    // Prevent user from ignoring attack speed and stopping and start combat really really fast
    if (isAttackReady() && canReachWithAttack(pVictim))
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
    Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_ATTACKSTART" );

// FLAGS changed so other players see attack animation
//    addUnitFlag(0x00080000);
//    setUpdateMaskBit(UNIT_FIELD_FLAGS );
}


bool Unit::AddAffect(Affect *aff, bool uniq)
{
    AffectList::const_iterator i;

    Log::getSingleton().outDetail("Unit::AddAffect() - adding affect");

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


void Unit::RemoveAffect(Affect *aff)
{
    printf("Remove Affect: ");
    printf("%u\n",aff->GetId());
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


void Unit::RemoveAllAffects()
{
    AffectList::iterator i, next;
    Affect *aff;
    bool result = false;

    for (i = m_affects.begin(); i != m_affects.end(); i = next)
    {
        next = i;
        next++;

        aff = *i;

        for (Affect::ModList::const_iterator j = aff->GetModList().begin();
            j != aff->GetModList().end(); i++)
        {
            ApplyModifier(&(*j), false, aff);
        }

        _RemoveAura(aff);

        m_affects.erase(i);

        delete aff;
    }

    return;
}


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
        }break;
        case SPELL_AURA_MOD_THREAT:
        {
        }break;
        case SPELL_AURA_AURAS_VISIBLE:
        {
        }break;
        case SPELL_AURA_MOD_RESISTANCE_PCT:
        {
        }break;
        case SPELL_AURA_MOD_CREATURE_ATTACK_POWER:
        {
        }break;
        case SPELL_AURA_MOD_TOTAL_THREAT:
        {
        }break;
        case SPELL_AURA_WATER_WALK:
        {
            apply ?
            data.Initialize(SMSG_MOVE_WATER_WALK)
            : data.Initialize(SMSG_MOVE_LAND_WALK);
            data << GetGUID();
            SendMessageToSet(&data,true);
        }break;
        case SPELL_AURA_FEATHER_FALL:
        {
            apply ?
            data.Initialize(SMSG_MOVE_FEATHER_FALL)
            : data.Initialize(SMSG_MOVE_NORMAL_FALL);
            data << GetGUID();
            SendMessageToSet(&data,true);
        }break;
        case SPELL_AURA_HOVER:
        {
        }break;
        case SPELL_AURA_ADD_FLAT_MODIFIER:
        {
        }break;
        case SPELL_AURA_ADD_PCT_MODIFIER:
        {
        }break;
        case SPELL_AURA_ADD_TARGET_TRIGGER:
        {
        }break;
        case SPELL_AURA_MOD_TAUNT:
        {
        }break;
        case SPELL_AURA_MOD_POWER_REGEN_PERCENT:
        {
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
        }break;
        case SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN:
        {
        }break;
        case SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN_PCT:
        {
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
            data << GetGUID();
            apply ? data << float(7.5+7.5/100*mod->GetAmount()) : data << float(7.5);
            SendMessageToSet(&data,true);
        }break;
        case SPELL_AURA_MOD_DAMAGE_DONE:
        {
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
        }break;
        case SPELL_AURA_FORCE_REACTION:
        {
        }break;
        case SPELL_AURA_MOD_DAMAGE_TAKEN:
        {
        }break;
        case SPELL_AURA_MOD_RANGED_HASTE:
        {
        }break;
        case SPELL_AURA_MOD_RANGED_AMMO_HASTE:
        {
        }break;
        case SPELL_AURA_MOD_BASE_RESISTANCE_PCT:
        {
        }break;
        case SPELL_AURA_MOD_RESISTANCE_EXCLUSIVE:
        {
        }break;
        case SPELL_AURA_SAFE_FALL:
        {
            apply ? data.Initialize(SMSG_MOVE_FEATHER_FALL) : data.Initialize(SMSG_MOVE_NORMAL_FALL);
            data << GetGUID();
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
        }break;
        case SPELL_AURA_DAMAGE_SHIELD:
        {
        }break;
        case SPELL_AURA_MOD_STEALTH:
        {
        }break;
        case SPELL_AURA_MOD_DETECT:
        {
        }break;
        case SPELL_AURA_MOD_INVISIBILITY:
        {
        }break;
        case SPELL_AURA_MOD_INVISIBILITY_DETECTION:
        {
        }break;
        case SPELL_AURA_MOD_POSSESS:
        {
        }break;
        case SPELL_AURA_MOD_RESISTANCE:
        {
            uint16 index = 0;
            uint16 index2 = 0;
            switch(mod->GetMiscValue())
            {
                case 0:{
                    index = UNIT_FIELD_RESISTANCES;
                    mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE : index2 = PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE;
                }break;
                case 1:{
                    index = UNIT_FIELD_RESISTANCES+1;
                    mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE+1 : index2 = PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE+1;
                }break;
                case 2:{
                    index = UNIT_FIELD_RESISTANCES+2;
                    mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE+2 : index2 = PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE+2;
                }break;
                case 3:{
                    index = UNIT_FIELD_RESISTANCES+3;
                    mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE+3 : index2 = PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE+3;
                }break;
                case 4:{
                    index = UNIT_FIELD_RESISTANCES+4;
                    mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE+4 : index2 = PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE+4;
                }break;
                case 5:{
                    index = UNIT_FIELD_RESISTANCES+5;
                    mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE+5 : index2 = PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE+5;
                }break;
                default:{
                    printf("WARNING: Misc Value for SPELL_AURA_MOD_STAT not valid\n");
                    return;
                }break;
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
        case SPELL_AURA_PERIODIC_TRIGGER_SPELL:
        {
        }break;
        case SPELL_AURA_PERIODIC_ENERGIZE:
        {
        }break;
        case SPELL_AURA_MOD_PACIFY:
        {
        }break;
        case SPELL_AURA_MOD_ROOT:
        {
            apply ?
            data.Initialize(MSG_MOVE_ROOT)
            : data.Initialize(MSG_MOVE_UNROOT);
            data << GetGUID();
            SendMessageToSet(&data,true);
        }break;
        case SPELL_AURA_MOD_SILENCE:
        {
            apply ? m_silenced = true : m_silenced = false;
        }break;
        case SPELL_AURA_REFLECT_SPELLS:
        {
        }break;
        case SPELL_AURA_MOD_STAT:
        {
            uint16 index = 0;
            uint16 index2 = 0;
            switch(mod->GetMiscValue())
            {
                case 0:{
                    index = UNIT_FIELD_STAT0;
                    mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_POSSTAT0 : index2 = PLAYER_FIELD_NEGSTAT0;
                }break;
                case 1:{
                    index = UNIT_FIELD_STAT1;
                    mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_POSSTAT1 : index2 = PLAYER_FIELD_NEGSTAT1;
                }break;
                case 2:{
                    index = UNIT_FIELD_STAT2;
                    mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_POSSTAT2 : index2 = PLAYER_FIELD_NEGSTAT2;
                }break;
                case 3:{
                    index = UNIT_FIELD_STAT3;
                    mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_POSSTAT3 : index2 = PLAYER_FIELD_NEGSTAT3;
                }break;
                case 4:{
                    index = UNIT_FIELD_STAT4;
                    mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_POSSTAT4 : index2 = PLAYER_FIELD_NEGSTAT4;
                }break;
                default:{
                    printf("WARNING: Misc Value for SPELL_AURA_MOD_STAT not valid\n");
                    return;
                }break;
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
        }break;
        case SPELL_AURA_MOD_SKILL:
        {
        }break;
        case SPELL_AURA_MOD_INCREASE_SPEED:
        {
        }break;
        case SPELL_AURA_MOD_INCREASE_MOUNTED_SPEED:
        {
        }break;
        case SPELL_AURA_MOD_DECREASE_SPEED:
        {
            data.Initialize(MSG_MOVE_SET_RUN_SPEED);
            data << GetGUID();
            apply ? data << float(7.5-7.5/100*mod->GetAmount()) : data << float(7.5);
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
            Affect* tmpAff;
            uint32 spellId;
            switch(mod->GetMiscValue())
            {
                case FORM_CAT: {
                    spellId = 3025;
                } break;
                case FORM_TREE:{
                    spellId = 3122;
                } break;
                case FORM_TRAVEL:{
                    spellId = 5419;
                } break;
                case FORM_AQUA:{
                    spellId = 5421;
                } break;
                case FORM_BEAR:{
                    spellId = 1178;
                } break;
                case FORM_AMBIENT:{
                    spellId = 0;
                } break;
                case FORM_GHOUL:{
                    spellId = 0;
                } break;
                case FORM_DIREBEAR:{
                    spellId = 9635;
                } break;
                case FORM_CREATUREBEAR:{
                    spellId = 2882;
                } break;
                case FORM_GHOSTWOLF:{
                    spellId = 0;
                } break;
                case FORM_BATTLESTANCE:{
                    spellId = 0;
                } break;
                case FORM_DEFENSIVESTANCE:{
                    spellId = 7376;
                } break;
                case FORM_BERSERKERSTANCE:{
                    spellId = 7381;
                } break;
                case FORM_SHADOW:{
                    spellId = 0;
                } break;
                case FORM_STEALTH:{
                    spellId = 3025;
                } break;
                default:{
                    printf("Unknown Shapeshift Type\n");
                } break;
            }
            // check for spell id
            SpellEntry *spellInfo = sSpellStore.LookupEntry( spellId );

            if(!spellInfo)
            {
                Log::getSingleton( ).outError("WORLD: unknown spell id %i\n", spellId);
                break;
            }
            tmpAff = new Affect(spellInfo,parent->GetDuration(),parent->GetCasterGUID());
            for(uint8 i=0;i<3;i++){
                if(spellInfo->Effect[i] == 6){
                    uint32 value = 0;
                    uint32 type = 0;
                    uint32 damage = 0;
                    if(spellInfo->EffectBasePoints[i] < 0){
                        tmpAff->SetNegative();
                        type = 1;
                    }
                    uint32 sBasePoints = (uint32)sqrt((float)(spellInfo->EffectBasePoints[i]*spellInfo->EffectBasePoints[i]));
                    if(spellInfo->EffectApplyAuraName[i] == 3){       // Periodic Trigger Damage
                        damage = spellInfo->EffectBasePoints[i]+rand()%spellInfo->EffectDieSides[i]+1;
						//TODO: why the hell it takes uint16?
                        tmpAff->SetDamagePerTick((uint16)damage, spellInfo->EffectAmplitude[i]);
                        tmpAff->SetNegative();
                    }else if(spellInfo->EffectApplyAuraName[i] == 23)// Periodic Trigger Spell
                        tmpAff->SetPeriodicTriggerSpell(spellInfo->EffectTriggerSpell[i],spellInfo->EffectAmplitude[i]);
                    else{
                        if(spellInfo->EffectDieSides[i] != 0)
                            value = sBasePoints+rand()%spellInfo->EffectDieSides[i];
                        else
                            value = sBasePoints;
                        if(spellInfo->EffectDieSides[i] <= 1)
                                value += 1;
						//TODO: why the hell it takes uint8? 
                        tmpAff->AddMod((uint8)spellInfo->EffectApplyAuraName[i],value,spellInfo->EffectMiscValue[i],type);
                    }
                }
            }
            if(tmpAff){
                parent->SetCoAffect(tmpAff);
                AddAffect(tmpAff);
            }
        }break;
        case SPELL_AURA_EFFECT_IMMUNITY:
        {
        }break;
        case SPELL_AURA_STATE_IMMUNITY:
        {
        }break;
        case SPELL_AURA_SCHOOL_IMMUNITY:
        {
        }break;
        case SPELL_AURA_DAMAGE_IMMUNITY:
        {
        }break;
        case SPELL_AURA_DISPEL_IMMUNITY:
        {
        }break;
        case SPELL_AURA_PROC_TRIGGER_SPELL:
        {
            apply ? m_triggerSpell = mod->GetAmount() : m_triggerSpell = 0;
        }break;
        case SPELL_AURA_PROC_TRIGGER_DAMAGE:
        {
            apply ? m_triggerDamage = mod->GetAmount() : m_triggerDamage = 0;
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
        }break;
        case SPELL_AURA_MOD_HIT_CHANCE:
        {
        }break;
        case SPELL_AURA_MOD_SPELL_HIT_CHANCE:
        {
        }break;
        case SPELL_AURA_TRANSFORM:
        {
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
        }break;
        case SPELL_AURA_PERIODIC_MANA_FUNNEL:
        {
        }break;
        case SPELL_AURA_PERIODIC_MANA_LEECH:
        {
        }break;
        case SPELL_AURA_MOD_CASTING_SPEED:
        {
        }break;
        case SPELL_AURA_FEIGN_DEATH:
        {
        }break;
        case SPELL_AURA_MOD_DISARM:
        {
        }break;
        case SPELL_AURA_MOD_STALKED:
        {
        }break;
        case SPELL_AURA_SCHOOL_ABSORB:
        {
        }break;
        case SPELL_AURA_MOD_FEAR:
        {
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
        }break;
        case SPELL_AURA_MOUNTED:
        {
        }break;
        case SPELL_AURA_MOD_DAMAGE_PERCENT_DONE:
        {
        }break;
        case SPELL_AURA_PERIODIC_HEAL:
        {
        }break;
        case SPELL_AURA_MOD_PERCENT_STAT:
        {
        }break;
        case SPELL_AURA_SPLIT_DAMAGE:
        {
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
        }break;
        case SPELL_AURA_MOD_DAMAGE_PERCENT_TAKEN:
        {
        }break;
        case SPELL_AURA_MOD_PERCENT_REGEN:
        {
        }break;
        case SPELL_AURA_PERIODIC_DAMAGE_PERCENT:
        {
        }break;
        case SPELL_AURA_MOD_ATTACKSPEED:
        {
        }break;
        case SPELL_AURA_MOD_RESIST_CHANCE:
        {
        }break;
        case SPELL_AURA_MOD_DETECT_RANGE:
        {
        }break;
        case SPELL_AURA_PREVENTS_FLEEING:
        {
        }break;
        case SPELL_AURA_MOD_UNATTACKABLE:
        {
        }break;
        case SPELL_AURA_INTERRUPT_REGEN:
        {
        }break;
        case SPELL_AURA_GHOST:
        {
        }break;
        case SPELL_AURA_SPELL_MAGNET:
        {
        }break;
        case SPELL_AURA_MANA_SHIELD:
        {
        }break;
        case SPELL_AURA_MOD_SKILL_TALENT:
        {
        }break;
        case SPELL_AURA_MOD_ATTACK_POWER:
        {
        }break;
        default:
        {
            Log::getSingleton().outError("Unknown affect id %u", (uint32)mod->GetType());
        }
    }
}

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

    Affect *aff;
    AffectList::iterator i, next;
    for (i = m_affects.begin(); i != m_affects.end(); i = next)
    {
        next = i;
        next++;

        aff = *i;

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
        Log::getSingleton().outDetail("Unit::_AddAura() - affect doesn't have id");
        return;
    }

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
        Log::getSingleton().outDetail("Unit::_AddAura() - no free aura slots found");
        return;
    }

    Log::getSingleton().outDetail("Unit::_AddAura() - found slot %u", (uint32)slot);

    SetUInt32Value((uint16)(UNIT_FIELD_AURA + slot), aff->GetId());

    uint8 flagslot = slot >> 3;
    uint32 value = GetUInt32Value((uint16)(UNIT_FIELD_AURAFLAGS + flagslot));
    Log::getSingleton().outDetail("Unit::_AddAura() - val: %X", value);
    value |= 0xFFFFFFFF & (AFLAG_SET << ((slot & 7) << 2));
    Log::getSingleton().outDetail("Unit::_AddAura() - new val: %X", value);
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

float Unit::getdistance( float xe, float ye, float xz, float yz )
{
        return sqrt( ( xe - xz ) * ( xe - xz ) + ( ye - yz ) * ( ye - yz ) );
}

float Unit::getangle( float xe, float ye, float xz, float yz )
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

float Unit::geteasyangle( float angle )
{
        while ( angle < 0 ) {
                angle = angle + 360;
        }
        while ( angle >= 360 ) {
                angle = angle - 360;
        }
        return angle;
}

bool Unit::inarc( float radius,  float xM, float yM, float offnung, float orientation, float xP, float yP )
{
        float distance = getdistance( xM, yM, xP, yP );
        float angle = getangle( xM, yM, xP, yP );
        float lborder = geteasyangle( ( orientation - (offnung/2) ) );
        float rborder = geteasyangle( ( orientation + (offnung/2) ) );
        if(radius>=distance &&( ( angle >= lborder ) &&
                               ( angle <= rborder ) ||
                               ( lborder > rborder && ( angle < rborder || angle > lborder ) ) ) ) {
                return true;
        } else {
                return false;
        }
} 

bool Unit::isInFront(Unit* target,float distance)
{
    float orientation = GetOrientation()/float(2*M_PI)*360;
    orientation += 90.0f;
    return inarc(distance,GetPositionX(),GetPositionY(),float(180),orientation,target->GetPositionX(),target->GetPositionY());
}
