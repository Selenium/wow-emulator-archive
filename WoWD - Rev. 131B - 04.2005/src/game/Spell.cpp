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
#include "WorldPacket.h"
#include "WorldSession.h"
#include "Opcodes.h"
#include "Log.h"
#include "UpdateMask.h"
#include "World.h"
#include "ObjectMgr.h"
#include "Player.h"
#include "Unit.h"
#include "Spell.h"
#include "DynamicObject.h"
#include "Affect.h"
#include "Group.h"

#define SPELL_CHANNEL_UPDATE_INTERVAL 1000

void SpellCastTargets::read ( WorldPacket * data,uint64 caster )
{
    m_unitTarget = m_itemTarget = 0;m_srcX = m_srcY = m_srcZ = m_destX = m_destY = m_destZ = 0;
    m_strTarget = "";

    *data >> m_targetMask;

    if(m_targetMask & TARGET_FLAG_SELF)
        m_unitTarget = caster;

    if(m_targetMask & TARGET_FLAG_UNIT)
        *data >> m_unitTarget;

    if(m_targetMask & TARGET_FLAG_OBJECT)
        *data >> m_unitTarget;

    if(m_targetMask & TARGET_FLAG_ITEM)
        *data >> m_itemTarget;

    if(m_targetMask & TARGET_FLAG_SOURCE_LOCATION)
        *data >> m_srcX >> m_srcY >> m_srcZ;

    if(m_targetMask & TARGET_FLAG_DEST_LOCATION)
        *data >> m_destX >> m_destY >> m_destZ;

    if(m_targetMask & TARGET_FLAG_STRING)
        *data >> m_strTarget;
}


void SpellCastTargets::write ( WorldPacket * data)
{
    *data << m_targetMask;

    if(m_targetMask & TARGET_FLAG_SELF)
        *data << m_unitTarget;

    if(m_targetMask & TARGET_FLAG_UNIT)
        *data << m_unitTarget;

    if(m_targetMask & TARGET_FLAG_OBJECT)
        *data << m_unitTarget;

    if(m_targetMask & TARGET_FLAG_ITEM)
        *data << m_itemTarget;

    if(m_targetMask & TARGET_FLAG_SOURCE_LOCATION)
        *data << m_srcX << m_srcY << m_srcZ;

    if(m_targetMask & TARGET_FLAG_DEST_LOCATION)
        *data << m_destX << m_destY << m_destZ;

    if(m_targetMask & TARGET_FLAG_STRING)
        *data << m_strTarget;
}


Spell::Spell( Unit* Caster, SpellEntry *info, bool triggered, Affect* aff )
{
    ASSERT( Caster != NULL && info != NULL );

    m_spellInfo = info;
    m_caster = Caster;

    m_spellState = SPELL_STATE_NULL;

    m_castPositionX = m_castPositionY = m_castPositionZ;
    TriggerSpellId = 0;
    m_targetCount = 0;
    m_triggeredSpell = triggered;
    m_AreaAura = false;

    m_triggeredByAffect = aff;
}

void Spell::FillTargetMap()
{
    Player* p_caster = (Player*)m_caster;
    std::list<uint64> tmpMap;
    uint32 cur = 0;
    for(uint32 i=0;i<3;i++){
        for(uint32 j=0;j<2;j++){
            if(j==0)
                cur = m_spellInfo->EffectImplicitTargetA[i];
            if(j==1)
                cur = m_spellInfo->EffectImplicitTargetB[i];
            switch(cur){
                case 1:{// Self Target
                    tmpMap.push_back(m_caster->GetGUID());
                    }break;
                case 5:{// Target: Pet
                    tmpMap.push_back(m_caster->GetUInt32Value(UNIT_FIELD_PETNUMBER));
                    }break;
                case 6:{// Single Target Enemy
                    tmpMap.push_back(m_targets.m_unitTarget);
                    }break;
                case 15: // All Enemies in Area of Effect (TEST) 
                case 16:{// All Enemies in Area of Effect instant (e.g. Flamestrike)
                    std::set<Object*>::iterator itr;
                    for( itr = m_caster->GetInRangeSetBegin(); itr != m_caster->GetInRangeSetEnd(); itr++ )
                    {
                        if( (*itr)->GetTypeId() != TYPEID_UNIT && (*itr)->GetTypeId() != TYPEID_PLAYER )
                            continue;

                        if(_CalcDistance(m_targets.m_destX,m_targets.m_destY,m_targets.m_destZ,(*itr)->GetPositionX(),(*itr)->GetPositionY(),(*itr)->GetPositionZ()) < GetRadius(sSpellRadius.LookupEntry(m_spellInfo->EffectRadiusIndex[i])) && (*itr)->GetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE) != m_caster->GetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE))
                            tmpMap.push_back((*itr)->GetGUID());
                    }
                    }break;
                case 20:{// All Party Members around the Caster
                    Group* pGroup = objmgr.GetGroupByLeader(p_caster->GetGroupLeader());
                    for(uint32 p=0;p<pGroup->GetMembersCount();p++){
                        Unit* Target = objmgr.GetObject<Player>(pGroup->GetMemberGUID(p));
                        if(!Target || Target->GetGUID() == m_caster->GetGUID())
                            continue;
                        if(_CalcDistance(m_caster->GetPositionX(),m_caster->GetPositionY(),m_caster->GetPositionZ(),Target->GetPositionX(),Target->GetPositionY(),Target->GetPositionZ()) < GetRadius(sSpellRadius.LookupEntry(m_spellInfo->EffectRadiusIndex[i])))
                            tmpMap.push_back(Target->GetGUID());
                    }
                    }break;
                case 21:{// Single Target Friend
                    tmpMap.push_back(m_targets.m_unitTarget);
                    }break;
                case 22:{// Enemy Targets around the Caster
                    std::set<Object*>::iterator itr;
                    for( itr = m_caster->GetInRangeSetBegin(); itr != m_caster->GetInRangeSetEnd(); itr++ )
                    {
                        if( (*itr)->GetTypeId() != TYPEID_UNIT && (*itr)->GetTypeId() != TYPEID_PLAYER )
                            continue;

                        if(_CalcDistance(m_caster->GetPositionX(),m_caster->GetPositionY(),m_caster->GetPositionZ(),(*itr)->GetPositionX(),(*itr)->GetPositionY(),(*itr)->GetPositionZ()) < GetRadius(sSpellRadius.LookupEntry(m_spellInfo->EffectRadiusIndex[i])) && (*itr)->GetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE) != m_caster->GetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE))
                            tmpMap.push_back((*itr)->GetGUID());
                    }
                    }break;
                case 23:{// Gameobject Target
                    tmpMap.push_back(m_targets.m_unitTarget);
                    }break;
                case 24:{// Targets in Front of the Caster
                    std::set<Object*>::iterator itr;
                    for( itr = m_caster->GetInRangeSetBegin(); itr != m_caster->GetInRangeSetEnd(); itr++ )
                    {
                        if( (*itr)->GetTypeId() != TYPEID_UNIT && (*itr)->GetTypeId() != TYPEID_PLAYER )
                            continue;

                        if(m_caster->isInFront((Unit*)(*itr),GetRadius(sSpellRadius.LookupEntry(m_spellInfo->EffectRadiusIndex[i]))) && (*itr)->GetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE) != m_caster->GetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE))
                            tmpMap.push_back((*itr)->GetGUID());
                    }
                    }break;
                case 26:{// Gameobject/Item Target
                    if(m_targets.m_unitTarget)
                        tmpMap.push_back(m_targets.m_unitTarget);
                    if(m_targets.m_itemTarget)
                        tmpMap.push_back(m_targets.m_itemTarget);
                    }break;
                case 28:{// All Enemies in Area of Effect(Blizzard/Rain of Fire/volley) channeled
                    std::set<Object*>::iterator itr;
                    for( itr = m_caster->GetInRangeSetBegin(); itr != m_caster->GetInRangeSetEnd(); itr++ )
                    {
                        if( (*itr)->GetTypeId() != TYPEID_UNIT && (*itr)->GetTypeId() != TYPEID_PLAYER )
                            continue;

                        if(!((Unit*)(*itr))->isAlive())
                            continue;

                        if(_CalcDistance(m_targets.m_destX,m_targets.m_destY,m_targets.m_destZ,(*itr)->GetPositionX(),(*itr)->GetPositionY(),(*itr)->GetPositionZ()) < GetRadius(sSpellRadius.LookupEntry(m_spellInfo->EffectRadiusIndex[i])) && (*itr)->GetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE) != m_caster->GetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE))
                            tmpMap.push_back((*itr)->GetGUID());
                    }
                    }break;
                case 32:{// Minion Target
                    }break;
                case 35:{// Single Target Party Member
                    tmpMap.push_back(m_targets.m_unitTarget);
                    }break;
                case 45:{// Chain
                    bool onlyParty = false;
                    Unit* firstTarget;
                    firstTarget = objmgr.GetObject<Player>(m_targets.m_unitTarget);
                    if(!firstTarget)
                        firstTarget = objmgr.GetObject<Creature>(m_targets.m_unitTarget);
                    if(!firstTarget)
                        break;
                    Group* pGroup = objmgr.GetGroupByLeader(p_caster->GetGroupLeader());
                    for(uint32 p=0;p<pGroup->GetMembersCount();p++){
                        if(firstTarget->GetGUID() == pGroup->GetMemberGUID(p))
                            onlyParty = true;
                    }
                    for(uint32 p=0;p<pGroup->GetMembersCount();p++){
                        Unit* Target = objmgr.GetObject<Player>(pGroup->GetMemberGUID(p));
                        if(!Target || Target->GetGUID() == m_caster->GetGUID())
                            continue;
                        if(_CalcDistance(Target->GetPositionX(),Target->GetPositionY(),Target->GetPositionZ(),m_caster->GetPositionX(),m_caster->GetPositionY(),m_caster->GetPositionZ()) < GetRadius(sSpellRadius.LookupEntry(m_spellInfo->EffectRadiusIndex[i])) && Target->GetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE) == m_caster->GetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE))
                            tmpMap.push_back(Target->GetGUID());
                    }
                    }break;
                case 53:{// Target Area by Players CurrentSelection()
                    std::set<Object*>::iterator itr;
                    Unit* Target = objmgr.GetObject<Creature>(p_caster->GetSelection());
                    if(!Target)
                        Target = objmgr.GetObject<Player>(p_caster->GetSelection());
                    if(!Target)
                        break;
                    for( itr = m_caster->GetInRangeSetBegin(); itr != m_caster->GetInRangeSetEnd(); itr++ )
                    {
                        if( (*itr)->GetTypeId() != TYPEID_UNIT && (*itr)->GetTypeId() != TYPEID_PLAYER )
                            continue;
                        if(_CalcDistance(Target->GetPositionX(),Target->GetPositionY(),Target->GetPositionZ(),(*itr)->GetPositionX(),(*itr)->GetPositionY(),(*itr)->GetPositionZ()) < GetRadius(sSpellRadius.LookupEntry(m_spellInfo->EffectRadiusIndex[i])) && (*itr)->GetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE) != m_caster->GetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE))
                            tmpMap.push_back((*itr)->GetGUID());
                    }
                    }break;
                default:{
                    }break;
            }
        }
        if(i == 0)
            m_targetUnits1 = tmpMap;
        else if(i == 1)
            m_targetUnits2 = tmpMap;
        else if(i == 2)
            m_targetUnits3 = tmpMap;
        tmpMap.clear();
    }
}

void Spell::prepare(SpellCastTargets * targets)
{
    uint8 result;

    WorldPacket data;

    m_targets = *targets;


    SendSpellStart();

    m_timer = GetCastTime(sCastTime.LookupEntry(m_spellInfo->CastingTimeIndex));
    m_spellState = SPELL_STATE_PREPARING;

    m_castPositionX = m_caster->GetPositionX();
    m_castPositionY = m_caster->GetPositionY();
    m_castPositionZ = m_caster->GetPositionZ();

    result = CanCast();
    if(result != 0){
        if(m_triggeredByAffect){
            SendChannelUpdate(0);
            m_triggeredByAffect->SetDuration(0);
        }
        finish();
    }

    if(m_triggeredSpell)
        cast();
    else
        m_caster->castSpell( this );
}


void Spell::cancel()
{
    WorldPacket data;

    if(m_spellState == SPELL_STATE_PREPARING)
    {
        SendInterrupted(0);
        SendCastResult(0x1F);   // Interrupted
    }
    else if(m_spellState = SPELL_STATE_CASTING)
    {
        m_caster->RemoveAffectById(m_spellInfo->Id);
        SendChannelUpdate(0);
    }

    m_spellState = SPELL_STATE_FINISHED;
}


void Spell::cast()
{
    WorldPacket data;

    bool Instant = true;
    for(uint32 i=0;i<=2;i++){
        if(m_spellInfo->Effect[i] == 17 || m_spellInfo->Effect[i] == 58)
            Instant = false;
    }

    if(Instant){
        uint8 castResult = 0;
        castResult = CanCast();
        if(castResult == 0){
            FillTargetMap();
            SendCastResult(castResult);
            SendSpellGo();
            SendLogExecute();

            if(m_spellInfo->ChannelInterruptFlags != 0){
                m_spellState = SPELL_STATE_CASTING;
                SendChannelStart(GetDuration(sSpellDuration.LookupEntry(m_spellInfo->DurationIndex)));
            }

            for(uint32 j = 0;j<3;j++){
                if(m_spellInfo->Effect[j] == 27)    // Area Aura
                    HandleEffects(m_caster->GetGUID(),j);
            }
            std::list<uint64>::iterator i;
            for(i= m_targetUnits1.begin();i != m_targetUnits1.end();i++)
                HandleEffects((*i),0);
            for(i= m_targetUnits2.begin();i != m_targetUnits2.end();i++)
                HandleEffects((*i),1);
            for(i= m_targetUnits3.begin();i != m_targetUnits3.end();i++)
                HandleEffects((*i),2);
            for(i= UniqueTargets.begin();i != UniqueTargets.end();i++)
                HandleAddAffect((*i));
        }

        if(m_spellState != SPELL_STATE_CASTING)
            finish();

        if(castResult == 0)
            TriggerSpell();
    }else{
        m_caster->m_meleeSpell = true;
        m_spellState = SPELL_STATE_IDLE;
    }
}


void Spell::update(uint32 difftime)
{
    if(m_castPositionX != m_caster->GetPositionX() ||
       m_castPositionY != m_caster->GetPositionY() ||
       m_castPositionZ != m_caster->GetPositionZ() )
    {
        SendInterrupted(0);
        SendCastResult(0x1F);   // Interrupted
        if(m_spellState == SPELL_STATE_CASTING){
            m_caster->RemoveAffectById(m_spellInfo->Id);
            SendChannelUpdate(0);
        }
        m_spellState = SPELL_STATE_FINISHED;
    }
    switch(m_spellState)
    {
        case SPELL_STATE_PREPARING:
        {
            if(m_timer)
            {
                if(difftime >= m_timer)
                    m_timer = 0;
                else
                    m_timer -= difftime;
            }

            if(m_timer == 0)
                cast();
        } break;

        case SPELL_STATE_CASTING:
        {
            if(m_timer > 0)
            {
                if(difftime >= m_timer)
                    m_timer = 0;
                else
                    m_timer -= difftime;

                m_intervalTimer += difftime;
            }

            if(m_timer == 0){
                SendChannelUpdate(0);
                finish();
            }
        } break;

        default:
        { } break;
    }
}


void Spell::finish()
{
    WorldPacket data;

    m_spellState = SPELL_STATE_FINISHED;
    m_caster->m_meleeSpell = false;
}

void Spell::SendCastResult(uint8 result)
{
    if (m_caster->GetTypeId() != TYPEID_PLAYER)
        return;

    WorldPacket data;

    data.Initialize(SMSG_CAST_RESULT);
    data << m_spellInfo->Id;
    if(result != 0)
        data << uint8(2);
    data << result;
    ((Player*)m_caster)->GetSession()->SendPacket(&data);
}


void Spell::SendSpellStart()
{
    // Send Spell Start
    WorldPacket data;
    uint16 cast_flags;

    cast_flags = 2;

    data.Initialize(SMSG_SPELL_START);
    data << m_caster->GetGUID() << m_caster->GetGUID();
    data << m_spellInfo->Id;
    data << cast_flags;
    data << GetCastTime(sCastTime.LookupEntry(m_spellInfo->CastingTimeIndex));

    m_targets.write( &data );
    ((Player*)m_caster)->SendMessageToSet(&data, true);

}


void Spell::SendSpellGo()
{
    // Start Spell
    WorldPacket data;
    uint16 flags;

    // FIXME: not sure about that, check disasm
    flags = m_targets.m_targetMask;
    if(flags == 0)
        flags = 2;

    data.Initialize(SMSG_SPELL_GO);

    data << m_caster->GetGUID() << m_caster->GetGUID();
    data << m_spellInfo->Id;
    //data << flags;
    data << uint16(0x0500);
    writeSpellGoTargets(&data);

    data << (uint8)0;  // number of misses
    m_targets.write( &data );
    m_caster->SendMessageToSet(&data, true);
}

void Spell::writeSpellGoTargets( WorldPacket * data )
{
    bool add = true;
    for ( std::list<uint64>::iterator i = m_targetUnits1.begin(); i != m_targetUnits1.end(); i++ ){
        for(std::list<uint64>::iterator j = UniqueTargets.begin(); j != UniqueTargets.end(); j++ ){
            if((*j) == (*i))
                add = false;
        }
        if(add)
            UniqueTargets.push_back((*i));
        add = true;
    }
    for ( std::list<uint64>::iterator i = m_targetUnits2.begin(); i != m_targetUnits2.end(); i++ ){
        for(std::list<uint64>::iterator j = UniqueTargets.begin(); j != UniqueTargets.end(); j++ ){
            if((*j) == (*i))
                add = false;
        }
        if(add)
            UniqueTargets.push_back((*i));
        add = true;
    }
    for ( std::list<uint64>::iterator i = m_targetUnits3.begin(); i != m_targetUnits3.end(); i++ ){
        for(std::list<uint64>::iterator j = UniqueTargets.begin(); j != UniqueTargets.end(); j++ ){
            if((*j) == (*i))
                add = false;
        }
        if(add)
            UniqueTargets.push_back((*i));
        add = true;
    }
    m_targetCount = UniqueTargets.size();

    *data << m_targetCount;
    for ( std::list<uint64>::iterator i = UniqueTargets.begin(); i != UniqueTargets.end(); i++ )
        *data << (*i);
}

void Spell::SendLogExecute()
{
    WorldPacket data;
    data.Initialize(SMSG_SPELLLOGEXECUTE);
    data << m_caster->GetGUID();
    data << m_spellInfo->Id << uint32(0x00000001);
    data << uint64(0x0000000100000021LL); /*needs LL at the end */
    data << m_targets.m_unitTarget;
    m_caster->SendMessageToSet(&data,true);
};
// TODO: make result flag list
void Spell::SendInterrupted(uint8 result)
{
    WorldPacket data;

    data.Initialize(SMSG_SPELL_FAILURE);

    data << m_caster->GetGUID();
    data << m_spellInfo->Id;
    data << result;

    m_caster->SendMessageToSet(&data, true);
}


void Spell::SendChannelUpdate(uint32 time)
{
    if (m_caster->GetTypeId() != TYPEID_PLAYER)
        return;

    WorldPacket data;

    data.Initialize( MSG_CHANNEL_UPDATE );
    data << time;

    ((Player*)m_caster)->GetSession()->SendPacket( &data );

    if(time == 0){
        m_caster->SetUInt32Value(UNIT_FIELD_CHANNEL_OBJECT,0);
        m_caster->SetUInt32Value(UNIT_FIELD_CHANNEL_OBJECT+1,0);
        m_caster->SetUInt32Value(UNIT_CHANNEL_SPELL,0);
    }
}


void Spell::SendChannelStart(uint32 duration)
{
    Unit* target = objmgr.GetObject<Creature>(((Player*)m_caster)->GetSelection());
    if(!target)
        target = objmgr.GetObject<Player>(((Player*)m_caster)->GetSelection());
    if(!target)
        return;
    if (m_caster->GetTypeId() == TYPEID_PLAYER){
        // Send Channel Start
        WorldPacket data;
        data.Initialize( MSG_CHANNEL_START );
        data << m_spellInfo->Id;
        data << duration;
        ((Player*)m_caster)->GetSession()->SendPacket( &data );
    }

    m_timer = duration;


    m_caster->SetUInt32Value(UNIT_FIELD_CHANNEL_OBJECT,target->GetGUIDLow());
    m_caster->SetUInt32Value(UNIT_FIELD_CHANNEL_OBJECT+1,target->GetGUIDHigh());
    m_caster->SetUInt32Value(UNIT_CHANNEL_SPELL,m_spellInfo->Id);
}


void Spell::TakePower()
{
    uint16 powerField;
    uint32 currentPower;

    uint8 powerType = (uint8)(m_caster->GetUInt32Value(UNIT_FIELD_BYTES_0) >> 24);
    if(powerType == 0) // Mana
        powerField = UNIT_FIELD_POWER1;
    else if(powerType == 1) // Rage
        powerField = UNIT_FIELD_POWER2;
    else if(powerType == 3) // Energy
        powerField = UNIT_FIELD_POWER4;


    currentPower = m_caster->GetUInt32Value(powerField);

    if(currentPower < m_spellInfo->manaCost)
        m_caster->SetUInt32Value(powerField, 0);
    else
        m_caster->SetUInt32Value(powerField, currentPower - m_spellInfo->manaCost);
}

void Spell::HandleEffects(uint64 guid,uint32 i)
{
    Unit* unitTarget;
    Item* itemTarget;
    GameObject* gameObjTarget;
    Player* playerTarget;
    WorldPacket data;
    data.clear();
    unitTarget = objmgr.GetObject<Creature>(guid);
    if(!unitTarget)
        unitTarget = objmgr.GetObject<Player>(guid);
    //itemTarget = objmgr.GetObject<Item>(guid);
    gameObjTarget = objmgr.GetObject<GameObject>(guid);
    playerTarget = objmgr.GetObject<Player>(guid);

        switch(m_spellInfo->Effect[i]){
            case 2:{    // School Damage
                if(!unitTarget)
                    break;
                if(!unitTarget->isAlive())
                    break;

                uint32 baseDamage = m_spellInfo->EffectBasePoints[i];
                uint32 randomDamage = rand()%m_spellInfo->EffectDieSides[i];
                uint32 damage = baseDamage+randomDamage;

                m_caster->SpellNonMeleeDamageLog(unitTarget,m_spellInfo->Id, damage);
            }break;
            case 3:{    // Dummy
            }break;
            case 6:{    // Apply Aura
                if(!unitTarget)
                    break;
                if(!unitTarget->isAlive())
                    break;

                if(unitTarget->tmpAffect == 0){
                    Affect* aff = new Affect(m_spellInfo,GetDuration(sSpellDuration.LookupEntry(m_spellInfo->DurationIndex)),m_caster->GetGUID());
                    unitTarget->tmpAffect = aff;
                }

                uint32 value = 0;
                uint32 type = 0;
                uint32 damage = 0;
                if(m_spellInfo->EffectBasePoints[i] < 0){
                    unitTarget->tmpAffect->SetNegative();
                    type = 1;
                }
                uint32 sBasePoints = sqrt((float)(m_spellInfo->EffectBasePoints[i]*(float)m_spellInfo->EffectBasePoints[i]));

                if(m_spellInfo->EffectApplyAuraName[i] == 3){       // Periodic Trigger Damage
                    damage = m_spellInfo->EffectBasePoints[i]+rand()%m_spellInfo->EffectDieSides[i]+1;
                    unitTarget->tmpAffect->SetDamagePerTick(damage,m_spellInfo->EffectAmplitude[i]);
                    unitTarget->tmpAffect->SetNegative();
                }else if(m_spellInfo->EffectApplyAuraName[i] == 23)// Periodic Trigger Spell
                    unitTarget->tmpAffect->SetPeriodicTriggerSpell(m_spellInfo->EffectTriggerSpell[i],m_spellInfo->EffectAmplitude[i]);
                else{
                    if(m_spellInfo->EffectDieSides[i] != 0)
                        value = sBasePoints+rand()%m_spellInfo->EffectDieSides[i];
                    else
                        value = sBasePoints;
                    if(m_spellInfo->EffectDieSides[i] <= 1)
                            value += 1;
                    unitTarget->tmpAffect->AddMod(m_spellInfo->EffectApplyAuraName[i],value,m_spellInfo->EffectMiscValue[i],type);
                }
            }break;
            case 8:{    // Power Drain
                if(!unitTarget)
                    break;
                if(!unitTarget->isAlive())
                    break;

                uint32 Drain;
                uint32 baseDrain = m_spellInfo->EffectBasePoints[i];
                uint32 randomDrain = rand()%m_spellInfo->EffectDieSides[i];
                Drain = baseDrain+randomDrain;

                uint32 curPower = unitTarget->GetUInt32Value(UNIT_FIELD_POWER1);
                if(curPower < Drain)
                    unitTarget->SetUInt32Value(UNIT_FIELD_POWER1,0);
                else
                    unitTarget->SetUInt32Value(UNIT_FIELD_POWER1,curPower-Drain);
            }break;
            case 10:{   // Heal
                if(!unitTarget)
                    break;
                if(!unitTarget->isAlive())
                    break;

                uint32 heal;
                uint32 baseHealing = m_spellInfo->EffectBasePoints[i];
                uint32 randomHealing = rand()%m_spellInfo->EffectDieSides[i];
                heal = baseHealing+randomHealing;

                uint32 curHealth = unitTarget->GetUInt32Value(UNIT_FIELD_HEALTH);
                uint32 maxHealth = unitTarget->GetUInt32Value(UNIT_FIELD_MAXHEALTH);
                if(curHealth+heal > maxHealth)
                    unitTarget->SetUInt32Value(UNIT_FIELD_HEALTH,maxHealth);
                else
                    unitTarget->SetUInt32Value(UNIT_FIELD_HEALTH,curHealth+heal);
            }break;
            case 17:{   // Weapon Damage + (no School)
                if(!unitTarget)
                    break;
                if(!unitTarget->isAlive())
                    break;

                uint32 baseDamage = m_spellInfo->EffectBasePoints[i];
                uint32 randomDamage = rand()%m_spellInfo->EffectDieSides[i];
                uint32 damage = baseDamage+randomDamage;
                unitTarget->m_addDmgOnce = damage;
            }break;
            case 24:{   // Create item      // NEEDS TO BE REDONE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                Player* pUnit = (Player*)m_caster;
                uint8 slot = 0;
                for(uint32 i=INVENTORY_SLOT_ITEM_START;i<INVENTORY_SLOT_ITEM_END;i++){// check if there is a free slot for the item to conjure
                    if(pUnit->GetItemBySlot(i) == 0)
                        slot = i;
                }
                if(slot == 0){
                    SendCastResult(0x18);
                    return;
                }

                Item* pItem;
                uint8 curSlot;
                for(uint32 i=0;i<8;i++){
                    for(uint32 j=0;j<m_spellInfo->ReagentCount[i];j++){
                        if(j>10)// little protection to prevent loops in here
                            break;
                        if(m_spellInfo->Reagent[i] == 0)
                            continue;
                        curSlot = pUnit->GetSlotByItemID(m_spellInfo->Reagent[i]);
                        if(curSlot == 0)
                            continue;
                        pItem = new Item;
                        pItem = pUnit->GetItemBySlot(curSlot);
                        if(pItem->GetUInt32Value(ITEM_FIELD_STACK_COUNT)>1){ // if there are more then 1 in stack then just reduce it by 1{
                            pItem->SetUInt32Value(ITEM_FIELD_STACK_COUNT,pItem->GetUInt32Value(ITEM_FIELD_STACK_COUNT)-1);
                        }else{// otherwise delete it from player and db
                            pUnit->RemoveItemFromSlot(curSlot);
                            pItem->DeleteFromDB();
                        }
                        pItem = NULL;
                        curSlot = 0;
                    }
                }

                pItem = NULL;
                Item* newItem;
                for(i=0;i<2;i++){// now create the Items
                    if(m_spellInfo->EffectItemType[i] == 0)
                        continue;

                    slot = 0;
                    for(uint32 i=INVENTORY_SLOT_ITEM_START;i<INVENTORY_SLOT_ITEM_END;i++){// check if there is a free slot for the item to conjure
                        if(pUnit->GetItemBySlot(i) == 0)
                            slot = i;
                    }
                    if(slot == 0){
                        SendCastResult(0x18);
                        return;
                    }
                    newItem = new Item;
                    newItem->Create(objmgr.GenerateLowGuid(HIGHGUID_ITEM),m_spellInfo->EffectItemType[i],pUnit);
                    pUnit->AddItemToSlot(slot,newItem);
                    newItem = NULL;
                }
            }break;
            case 27:{   // Persistent Area Aura
                if(m_AreaAura == true)
                    break;

                m_AreaAura = true;
                // Spawn dyn GameObject
                DynamicObject* dynObj = new DynamicObject();
                dynObj->Create(objmgr.GenerateLowGuid(HIGHGUID_DYNAMICOBJECT), m_caster, m_spellInfo, m_targets.m_destX, m_targets.m_destY, m_targets.m_destZ, GetDuration(sSpellDuration.LookupEntry(m_spellInfo->DurationIndex)));
                uint32 damage = m_spellInfo->EffectBasePoints[i]+1;
                dynObj->PeriodicTriggerDamage(damage, m_spellInfo->EffectAmplitude[i], GetRadius(sSpellRadius.LookupEntry(m_spellInfo->EffectRadiusIndex[i])));

                objmgr.AddObject(dynObj);
                dynObj->PlaceOnMap();
            }break;
            case 30:{   // Energize
                if(!unitTarget)
                    break;
                if(!unitTarget->isAlive())
                    break;
                uint32 POWER_TYPE;

                switch(m_spellInfo->EffectMiscValue[i]){
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
                }

                uint32 energize;
                uint32 baseEnergize = m_spellInfo->EffectBasePoints[i];
                uint32 randomEnergize = rand()%m_spellInfo->EffectDieSides[i];
                energize = baseEnergize+randomEnergize;
                if(POWER_TYPE == UNIT_FIELD_POWER2)
                    energize = energize*10;

                uint32 curEnergy = unitTarget->GetUInt32Value(POWER_TYPE);
                uint32 maxEnergy = unitTarget->GetUInt32Value(POWER_TYPE+6);
                if(curEnergy+energize > maxEnergy)
                    unitTarget->SetUInt32Value(POWER_TYPE,maxEnergy);
                else
                    unitTarget->SetUInt32Value(POWER_TYPE,curEnergy+energize);
            }break;
            case 33:{   // Open Lock
                if(!gameObjTarget || !playerTarget)
                    break;

                data.clear();
                data.Initialize(SMSG_LOOT_RESPONSE);
                gameObjTarget->FillLoot(&data);
                playerTarget->SetLootGUID(m_targets.m_unitTarget);
                playerTarget->GetSession()->SendPacket(&data);
            }break;
            case 35:{   // Apply Area Aura
                if(!unitTarget)
                    break;
                if(!unitTarget->isAlive())
                    break;

                if(m_spellInfo->Attributes == 151322624){   // Pally Auras
                    Affect* aff = new Affect(m_spellInfo,6000,m_caster->GetGUID());
                    aff->AddMod(m_spellInfo->EffectApplyAuraName[i],m_spellInfo->EffectBasePoints[i]+rand()%m_spellInfo->EffectDieSides[i],m_spellInfo->EffectMiscValue[i],0);

                    unitTarget->SetAura(aff);
                }
            }break;
            case 36:{   // Learn Spell
                if(!playerTarget)
                    return;
                uint32 spellToLearn = m_spellInfo->EffectTriggerSpell[i];
/*  Crashes needs to be fixed
                std::list<spells>::iterator iter;
                for(iter = playerTarget->getSpellList().begin();iter != playerTarget->getSpellList().end();++iter){
                    if((*iter).spellId == spellToLearn)
                        break;
                }
                if(iter != playerTarget->getSpellList().end())
                    return;
*/
                playerTarget->addSpell((uint16)spellToLearn);
            }break;
            case 53:{   // Enchant Item Permanent
                Player* p_caster = (Player*)m_caster;
                uint32 field = 99;
                if(m_CastItem)
                    field = 1;
                else
                    field = 3;
                if(!m_CastItem){
                    for(uint8 i=0;i<INVENTORY_SLOT_ITEM_END;i++){
                        if(p_caster->GetItemBySlot(i) != 0)
                            if(p_caster->GetItemBySlot(i)->GetProto()->ItemId == m_targets.m_itemTarget)
                                m_CastItem = p_caster->GetItemBySlot(i);
                    }
                }
                //m_CastItem->Enchant(m_spellInfo->EffectMiscValue[i],0);
            }break;
            case 54:{   // Enchant Item Temporary
                Player* p_caster = (Player*)m_caster;
                uint32 duration = GetDuration(sSpellDuration.LookupEntry(m_spellInfo->DurationIndex));
                uint32 field = 99;
                if(m_CastItem)
                    field = 1;
                else
                    field = 3;
                if(!m_CastItem){
                    for(uint8 i=0;i<INVENTORY_SLOT_ITEM_END;i++){
                        if(p_caster->GetItemBySlot(i) != 0)
                            if(p_caster->GetItemBySlot(i)->GetProto()->ItemId == m_targets.m_itemTarget)
                                m_CastItem = p_caster->GetItemBySlot(i);
                    }
                }

                //m_CastItem->Enchant(m_spellInfo->EffectMiscValue[i],duration,field);
            }break;
            case 58:{   // Weapon damage +
                if(!unitTarget)
                    break;
                if(!unitTarget->isAlive())
                    break;

                uint32 baseDamage = m_spellInfo->EffectBasePoints[i];
                uint32 randomDamage = rand()%m_spellInfo->EffectDieSides[i];
                uint32 damage = baseDamage+randomDamage;
                unitTarget->m_addDmgOnce = damage;
            }break;
            case 64:{   // Trigger Spell
                TriggerSpellId = m_spellInfo->EffectTriggerSpell[i];
            }break;
            case 67:{   // Heal Max Health
                if(!unitTarget)
                    break;
                if(!unitTarget->isAlive())
                    break;

                uint32 heal;
                heal = m_caster->GetUInt32Value(UNIT_FIELD_MAXHEALTH);

                uint32 curHealth = unitTarget->GetUInt32Value(UNIT_FIELD_HEALTH);
                uint32 maxHealth = unitTarget->GetUInt32Value(UNIT_FIELD_MAXHEALTH);
                if(curHealth+heal > maxHealth)
                    unitTarget->SetUInt32Value(UNIT_FIELD_HEALTH,maxHealth);
                else
                    unitTarget->SetUInt32Value(UNIT_FIELD_HEALTH,curHealth+heal);
            }break;
            case 68:{   // Interrupt Cast
                if(!unitTarget)
                    break;
                if(!unitTarget->isAlive())
                    break;

                unitTarget->InterruptSpell();
            }break;
            case 87:    // Summon Totem (slot 1)
            case 88:    // Summon Totem (slot 2)
            case 89:    // Summon Totem (slot 3)
            case 90:{   // Summon Totem (slot 4)
                uint64 guid = 0;
                // delete old summoned object
                if(m_spellInfo->Effect[i] == 87){
                    guid = m_caster->m_TotemSlot1;
                    m_caster->m_TotemSlot1 = 0;
                }else if(m_spellInfo->Effect[i] == 88){
                    guid = m_caster->m_TotemSlot2;
                    m_caster->m_TotemSlot2 = 0;
                }else if(m_spellInfo->Effect[i] == 89){
                    guid = m_caster->m_TotemSlot3;
                    m_caster->m_TotemSlot3 = 0;
                }else if(m_spellInfo->Effect[i] == 90){
                    guid = m_caster->m_TotemSlot4;
                    m_caster->m_TotemSlot4 = 0;
                }
                if(guid != 0)
                {
                    Creature* Totem;
                    Totem = objmgr.GetObject<Creature>(guid);
                    if(Totem){
                        Totem->RemoveFromMap();
                        objmgr.RemoveObject(Totem);
                    }
                }

                // spawn a new one
                Creature* pTotem = new Creature();
                uint16 display_id = m_spellInfo->EffectMiscValue[i]; // need to set it via m_spellInfo
                char* name = "need to fix this";

                // uint32 guidlow, uint16 display_id, uint8 state, uint32 obj_field_entry, uint8 scale, uint16 type, uint16 faction,  float x, float y, float z, float ang
                pTotem->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), name, m_caster->GetMapId(), m_caster->GetPositionX(), m_caster->GetPositionY(), m_caster->GetPositionZ(), m_caster->GetOrientation() );
                pTotem->SetUInt32Value(OBJECT_FIELD_TYPE,33);
                pTotem->SetUInt32Value(UNIT_FIELD_LEVEL,m_caster->getLevel());
                objmgr.AddObject(pTotem);
                pTotem->PlaceOnMap();

                data.Initialize(SMSG_GAMEOBJECT_SPAWN_ANIM);
                data << pTotem->GetGUID();
                m_caster->SendMessageToSet(&data,true);

                if(m_spellInfo->Effect[i] == 87)
                    m_caster->m_TotemSlot1 = pTotem->GetGUID();
                else if(m_spellInfo->Effect[i] == 88)
                    m_caster->m_TotemSlot2 = pTotem->GetGUID();
                else if(m_spellInfo->Effect[i] == 89)
                    m_caster->m_TotemSlot3 = pTotem->GetGUID();
                else if(m_spellInfo->Effect[i] == 90)
                    m_caster->m_TotemSlot4 = pTotem->GetGUID();
            }break;
            case 92:{   // Enchant Held Item

            }break;
            case 101:{  // Feed Pet
                TriggerSpellId = m_spellInfo->EffectTriggerSpell[i];
            }break;
            case 104:   // Summon Object (slot 1)
            case 105:   // Summon Object (slot 2)
            case 106:   // Summon Object (slot 3)
            case 107:{  // Summon Object (slot 4)

                uint64 guid = 0;
                // delete old summoned object
                if(m_spellInfo->Effect[i] == 104){
                    guid = m_caster->m_TotemSlot1;
                    m_caster->m_TotemSlot1 = 0;
                }else if(m_spellInfo->Effect[i] == 105){
                    guid = m_caster->m_TotemSlot2;
                    m_caster->m_TotemSlot2 = 0;
                }else if(m_spellInfo->Effect[i] == 106){
                    guid = m_caster->m_TotemSlot3;
                    m_caster->m_TotemSlot3 = 0;
                }else if(m_spellInfo->Effect[i] == 107){
                    guid = m_caster->m_TotemSlot4;
                    m_caster->m_TotemSlot4 = 0;
                }
                if(guid != 0)
                {
                    GameObject* obj;
                    obj = objmgr.GetObject<GameObject>(guid);
                    if(obj){
                        obj->RemoveFromMap();
                        objmgr.RemoveObject(obj);
                    }
                }

                // spawn a new one
                GameObject* pGameObj = new GameObject();
                uint16 display_id = m_spellInfo->EffectMiscValue[i];

                // uint32 guidlow, uint16 display_id, uint8 state, uint32 obj_field_entry, uint8 scale, uint16 type, uint16 faction,  float x, float y, float z, float ang
                pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), display_id, 1, m_spellInfo->EffectMiscValue[i], 1, 6, 6, m_caster->GetMapId(), m_caster->GetPositionX(), m_caster->GetPositionY(), m_caster->GetPositionZ(), m_caster->GetOrientation() );
                pGameObj->SetUInt32Value(OBJECT_FIELD_TYPE,33);
                pGameObj->SetUInt32Value(GAMEOBJECT_LEVEL,m_caster->getLevel());
                objmgr.AddObject(pGameObj);
                pGameObj->PlaceOnMap();

                data.Initialize(SMSG_GAMEOBJECT_SPAWN_ANIM);
                data << pGameObj->GetGUID();
                m_caster->SendMessageToSet(&data,true);

                if(m_spellInfo->Effect[i] == 104)
                    m_caster->m_TotemSlot1 = pGameObj->GetGUID();
                else if(m_spellInfo->Effect[i] == 105)
                    m_caster->m_TotemSlot2 = pGameObj->GetGUID();
                else if(m_spellInfo->Effect[i] == 106)
                    m_caster->m_TotemSlot3 = pGameObj->GetGUID();
                else if(m_spellInfo->Effect[i] == 107)
                    m_caster->m_TotemSlot4 = pGameObj->GetGUID();
            }break;
            default:{
                //PLAYER_TRACK_CREATURES 2^X
                printf("unknown effect\n");
            }break;
        }
    TakePower();
}

void Spell::HandleAddAffect(uint64 guid)
{
    Unit* Target = objmgr.GetObject<Creature>(guid);
    if(!Target)
        Target = objmgr.GetObject<Player>(guid);
    if(!Target)
        return;
    if(!Target->isAlive())
        return;

    if(Target->tmpAffect != 0){
        Target->AddAffect(Target->tmpAffect);
        Target->tmpAffect = 0;
    }
}

void Spell::TriggerSpell()
{
    if(TriggerSpellId != 0){
        // check for spell id
        SpellEntry *spellInfo = sSpellStore.LookupEntry(TriggerSpellId );

        if(!spellInfo)
        {
            Log::getSingleton( ).outError("WORLD: unknown spell id %i\n", TriggerSpellId);
            return;
        }

        Spell *spell = new Spell(m_caster, spellInfo,false, 0);
        WPAssert(spell);

        SpellCastTargets targets;
        targets.m_unitTarget = m_targets.m_unitTarget;

        spell->prepare(&targets);
    }
}

uint8 Spell::CanCast()
{
    uint8 castResult = 0;
    Unit* target = objmgr.GetObject<Creature>(m_targets.m_unitTarget);
    if(!target)
        Unit* target = objmgr.GetObject<Player>(m_targets.m_unitTarget);
    if(target){
        if(!m_caster->isInFront(target,GetRange(sSpellRange.LookupEntry(m_spellInfo->rangeIndex))))
            castResult = 0x74;    // Target needs to be in Front of you
        if(_CalcDistance(m_caster->GetPositionX(),m_caster->GetPositionY(),m_caster->GetPositionZ(),target->GetPositionX(),target->GetPositionY(),target->GetPositionZ()) > GetRange(sSpellRange.LookupEntry(m_spellInfo->rangeIndex)))
            castResult = 0x51;    // Target out of Range
    }

    if(m_targets.m_destX != 0 && m_targets.m_destY != 0  && m_targets.m_destZ != 0 ){
        if(_CalcDistance(m_caster->GetPositionX(),m_caster->GetPositionY(),m_caster->GetPositionZ(),m_targets.m_destX,m_targets.m_destY,m_targets.m_destZ) > GetRange(sSpellRange.LookupEntry(m_spellInfo->rangeIndex)))
            castResult = 0x51;    // Target out of Range
    }

    if(m_caster->m_silenced)
        castResult = 0x58;
    if(castResult != 0)
        SendCastResult(castResult);

    return castResult;
}
