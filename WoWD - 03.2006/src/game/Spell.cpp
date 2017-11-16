// Copyright (C) 2004 WoW Daemon
// Copyright (C) 2005 Oxide
// Copyright (C) 2005 DK
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
#include "Duel.h"
#include "Pet.h"
#include "UpdateData.h"

#define SPELL_CHANNEL_UPDATE_INTERVAL 1000

void SpellCastTargets::read ( WorldPacket * data,uint64 caster )
{
	m_unitTarget = m_itemTarget = 0;m_srcX = m_srcY = m_srcZ = m_destX = m_destY = m_destZ = 0;
	m_strTarget = "";

	*data >> m_targetMask;
	WoWGuid guid;

	//if(m_targetMask & TARGET_FLAG_SELF)
	if(m_targetMask == TARGET_FLAG_SELF)
	{
		m_unitTarget = caster;
	}

	if(m_targetMask & TARGET_FLAG_UNIT)
	{
		*data >> guid;
		m_unitTarget = guid.GetOldGuid();
	}

	if(m_targetMask & TARGET_FLAG_OBJECT)
	{
		*data >> guid;
		m_unitTarget = guid.GetOldGuid();
	}

	if(m_targetMask & TARGET_FLAG_ITEM)
	{
		*data >> guid;
		m_itemTarget = guid.GetOldGuid();
	}

	if(m_targetMask & TARGET_FLAG_SOURCE_LOCATION)
	{
		*data >> m_srcX >> m_srcY >> m_srcZ;
	}

	if(m_targetMask & TARGET_FLAG_DEST_LOCATION)
	{
		*data >> m_destX >> m_destY >> m_destZ;
	}

	if(m_targetMask & TARGET_FLAG_STRING)
	{
		*data >> m_strTarget;
	}
}


void SpellCastTargets::write ( WorldPacket * data)
{
	*data << m_targetMask;
	WoWGuid newunit(m_unitTarget);
	WoWGuid newitem(m_itemTarget);

	//if(m_targetMask & TARGET_FLAG_SELF)
	if(m_targetMask == TARGET_FLAG_SELF)
		*data << newunit;

	if(m_targetMask & TARGET_FLAG_UNIT)
		*data << newunit;

	if(m_targetMask & TARGET_FLAG_OBJECT)
		*data << newunit;

	if(m_targetMask & TARGET_FLAG_ITEM)
		*data << newitem;

	if(m_targetMask & TARGET_FLAG_SOURCE_LOCATION)
		*data << m_srcX << m_srcY << m_srcZ;

	if(m_targetMask & TARGET_FLAG_DEST_LOCATION)
		*data << m_destX << m_destY << m_destZ;

	if(m_targetMask & TARGET_FLAG_STRING)
		*data << m_strTarget;
}


Spell::Spell( Unit* Caster, SpellEntry *info, bool triggered, Affect* aff, bool melee)
{
	load = false;
	ASSERT( Caster != NULL && info != NULL );

	m_spellInfo = info;
	m_caster = Caster;
	m_CastItem = NULL;

	m_spellState = SPELL_STATE_NULL;

	m_castPositionX = m_castPositionY = m_castPositionZ;
	TriggerSpellId = 0;
	m_targetCount = 0;
	m_triggeredSpell = triggered;
	m_AreaAura = false;
	m_melee = melee;

	m_triggeredByAffect = aff;
}
Spell::Spell( Unit* Caster, SpellEntry *info, bool triggered, Affect* aff, bool melee, bool load)
{
	ASSERT( Caster != NULL && info != NULL );

	m_spellInfo = info;
	m_caster = Caster;
	m_CastItem = NULL;

	m_spellState = SPELL_STATE_NULL;

	m_castPositionX = m_castPositionY = m_castPositionZ;
	TriggerSpellId = 0;
	m_targetCount = 0;
	m_triggeredSpell = triggered;
	m_AreaAura = false;
	m_melee = melee;

	m_triggeredByAffect = aff;

	this->load = load;

}
void Spell::FillTargetMap()
{
	Player* p_caster = (Player*)m_caster;
	std::list<uint64> tmpMap;
	uint32 cur = 0;
	if(m_spellInfo->spellLevel > 8)
		m_spellInfo->spellLevel -= 8;
	for(uint32 i=0;i<3;i++){
		for(uint32 j=0;j<2;j++){
			if(j==0)
				cur = m_spellInfo->EffectImplicitTargetA[i];
			if(j==1)
				cur = m_spellInfo->EffectImplicitTargetB[i];
			switch(cur){
				case 0:{
					if(m_targets.m_unitTarget && j != 1 && m_spellInfo->Effect[i] != 0)
						tmpMap.push_back(m_targets.m_unitTarget);
					else if(m_targets.m_itemTarget && j != 1 && m_spellInfo->Effect[i] != 0)
						tmpMap.push_back(m_targets.m_itemTarget);
					   }break;
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
				case 16:{ // All Enemies in Area of Effect instant (e.g. Flamestrike)
					std::set<Object*>::iterator itr;
					for( itr = m_caster->GetInRangeSetBegin(); itr != m_caster->GetInRangeSetEnd(); itr++ )
					{
						if( (*itr)->GetTypeId() != TYPEID_UNIT && (*itr)->GetTypeId() != TYPEID_PLAYER )
							continue;

						if(_CalcDistance(m_targets.m_destX,m_targets.m_destY,m_targets.m_destZ,(*itr)->GetPositionX(),(*itr)->GetPositionY(),(*itr)->GetPositionZ()) < GetRadius(sSpellRadius.LookupEntry(m_spellInfo->EffectRadiusIndex[i])))
                        {
                            if(m_caster->GetTypeId() == TYPEID_PLAYER && (*itr)->GetTypeId() == TYPEID_PLAYER)
                            {
                                if(((Player *)m_caster)->DuelingWith == ((Player *)(*itr)))
                                {
                                    tmpMap.push_back((*itr)->GetGUID());
                                }
                                else
                                {
                                    if(((Unit *)(*itr))->myFaction & m_caster->hostile)
							            tmpMap.push_back((*itr)->GetGUID());
                                }
                            }
                            else
                            {
                                if(((Unit *)(*itr))->myFaction & m_caster->hostile)
							        tmpMap.push_back((*itr)->GetGUID());
                            }
                        }
					}
						}break;
				case 18:{// Land under caster
					std::set<Object*>::iterator itr;
					for( itr = m_caster->GetInRangeSetBegin(); itr != m_caster->GetInRangeSetEnd(); itr++ )
					{
						if( (*itr)->GetTypeId() != TYPEID_UNIT && (*itr)->GetTypeId() != TYPEID_PLAYER )
							continue;

						if(_CalcDistance(m_caster->GetPositionX(),m_caster->GetPositionY(),m_caster->GetPositionZ(),(*itr)->GetPositionX(),(*itr)->GetPositionY(),(*itr)->GetPositionZ()) < GetRadius(sSpellRadius.LookupEntry(m_spellInfo->EffectRadiusIndex[i])))
                        {
                            if(m_caster->GetTypeId() == TYPEID_PLAYER && (*itr)->GetTypeId() == TYPEID_PLAYER)
                            {
                                if(((Player *)m_caster)->DuelingWith == ((Player *)(*itr)))
                                {
                                    tmpMap.push_back((*itr)->GetGUID());
                                }
                                else
                                {
                                    if(((Unit *)(*itr))->myFaction & m_caster->hostile)
							            tmpMap.push_back((*itr)->GetGUID());
                                }
                            }
                            else
                            {
                                if(((Unit *)(*itr))->myFaction & m_caster->hostile)
							        tmpMap.push_back((*itr)->GetGUID());
                            }
                        }
					}
						}break;
				case 20:{// All Party Members around the Caster
					Group* pGroup = objmgr.GetGroupByLeader(p_caster->GetGroupLeader());
                    if(pGroup)
                    {
						for(uint32 p=0;p<pGroup->GetMembersCount();p++)
                        {
							Unit* Target = objmgr.GetObject<Player>(pGroup->GetMemberGUID(p));
							if(!Target || Target->GetGUID() == m_caster->GetGUID())
								continue;
							if(Target->getLevel() >= (m_spellInfo->spellLevel) && _CalcDistance(m_caster->GetPositionX(),m_caster->GetPositionY(),m_caster->GetPositionZ(),Target->GetPositionX(),Target->GetPositionY(),Target->GetPositionZ()) < GetMaxRange(sSpellRange.LookupEntry(m_spellInfo->rangeIndex)))
								tmpMap.push_back(Target->GetGUID());
                        }
					}
                    else
                    {
                        Raid* pGroup = objmgr.GetRaidByLeader(p_caster->GetGroupLeader());
                        if(pGroup)
                        {
                            std::list<SubRaidMembers*>::iterator itr;
                            RaidGroup raidGroup = pGroup->GetRaidGroup(((Player *)m_caster)->GetRaidSubGroup());
                            for(itr = raidGroup.subGroup.begin();itr != raidGroup.subGroup.end();)
		                    {
                                Unit* Target = objmgr.GetObject<Player>((*itr)->memberGuid);
							    if(!Target || Target->GetGUID() == m_caster->GetGUID())
								    continue;
							    if(Target->getLevel() >= (m_spellInfo->spellLevel) && _CalcDistance(m_caster->GetPositionX(),m_caster->GetPositionY(),m_caster->GetPositionZ(),Target->GetPositionX(),Target->GetPositionY(),Target->GetPositionZ()) < GetMaxRange(sSpellRange.LookupEntry(m_spellInfo->rangeIndex)))
								    tmpMap.push_back(Target->GetGUID());
                                ++itr;
                            }
						}
					    else
                        {
						    tmpMap.push_back(m_caster->GetGUID());
                        }
                    }
						}break;
				case 21: {// Single Target Friend
					Unit* Target = objmgr.GetObject<Player>(m_targets.m_unitTarget);
					if(!Target)
						Target = objmgr.GetObject<Creature>(m_targets.m_unitTarget);
					if(!Target)
						continue;
					//if(_CalcDistance(m_caster->GetPositionX(),m_caster->GetPositionY(),m_caster->GetPositionZ(),Target->GetPositionX(),Target->GetPositionY(),Target->GetPositionZ()) < GetMaxRange(sSpellRange.LookupEntry(m_spellInfo->rangeIndex)))
					tmpMap.push_back(m_targets.m_unitTarget);
						 }break;
				case 22:{// Enemy Targets around the Caster
					std::set<Object*>::iterator itr;
					for( itr = m_caster->GetInRangeSetBegin(); itr != m_caster->GetInRangeSetEnd(); itr++ )
					{
						if( (*itr)->GetTypeId() != TYPEID_UNIT && (*itr)->GetTypeId() != TYPEID_PLAYER )
							continue;

						if(_CalcDistance(m_caster->GetPositionX(),m_caster->GetPositionY(),m_caster->GetPositionZ(),(*itr)->GetPositionX(),(*itr)->GetPositionY(),(*itr)->GetPositionZ()) < GetRadius(sSpellRadius.LookupEntry(m_spellInfo->EffectRadiusIndex[i])))
                        {
                            if(m_caster->GetTypeId() == TYPEID_PLAYER && (*itr)->GetTypeId() == TYPEID_PLAYER)
                            {
                                if(((Player *)m_caster)->DuelingWith == ((Player *)(*itr)))
                                {
                                    tmpMap.push_back((*itr)->GetGUID());
                                }
                                else
                                {
                                    if(((Unit *)(*itr))->myFaction & m_caster->hostile)
							            tmpMap.push_back((*itr)->GetGUID());
                                }
                            }
                            else
                            {
                                if(((Unit *)(*itr))->myFaction & m_caster->hostile)
							        tmpMap.push_back((*itr)->GetGUID());
                            }
                        }
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
						//is Creature in range
						if(m_caster->isInRange((Unit*)(*itr),GetRadius(sSpellRadius.LookupEntry(m_spellInfo->EffectRadiusIndex[i]))))
						{
							if(m_caster->isInFront((Unit*)(*itr)))
                            {
                                if(m_caster->GetTypeId() == TYPEID_PLAYER && (*itr)->GetTypeId() == TYPEID_PLAYER)
                                {
                                    if(((Player *)m_caster)->DuelingWith == ((Player *)(*itr)))
                                    {
                                        tmpMap.push_back((*itr)->GetGUID());
                                    }
                                    else
                                    {
                                        if(((Unit *)(*itr))->myFaction & m_caster->hostile)
							                tmpMap.push_back((*itr)->GetGUID());
                                    }
                                }
                                else
                                {
                                    if(((Unit *)(*itr))->myFaction & m_caster->hostile)
							            tmpMap.push_back((*itr)->GetGUID());
                                }
                            }
                        }
					}
						}break;
				case 25: {// Single Target Friend Used in Duel
					Unit* Target = objmgr.GetObject<Player>(m_targets.m_unitTarget);
					if(!Target)
						break;
					//if(_CalcDistance(m_caster->GetPositionX(),m_caster->GetPositionY(),m_caster->GetPositionZ(),Target->GetPositionX(),Target->GetPositionY(),Target->GetPositionZ()) < GetMaxRange(sSpellRange.LookupEntry(m_spellInfo->rangeIndex)))
					tmpMap.push_back(m_targets.m_unitTarget);
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
                        //Duel check
						if(_CalcDistance(m_targets.m_destX,m_targets.m_destY,m_targets.m_destZ,(*itr)->GetPositionX(),(*itr)->GetPositionY(),(*itr)->GetPositionZ()) < GetRadius(sSpellRadius.LookupEntry(m_spellInfo->EffectRadiusIndex[i])))
                        {
                            if(m_caster->GetTypeId() == TYPEID_PLAYER && (*itr)->GetTypeId() == TYPEID_PLAYER)
                            {
                                if(((Player *)m_caster)->DuelingWith == ((Player *)(*itr)))
                                {
                                    tmpMap.push_back((*itr)->GetGUID());
                                }
                                else
                                {
                                    if(((Unit *)(*itr))->myFaction & m_caster->hostile)
							            tmpMap.push_back((*itr)->GetGUID());
                                }
                            }
                            else
                            {
                                if(((Unit *)(*itr))->myFaction & m_caster->hostile)
							        tmpMap.push_back((*itr)->GetGUID());
                            }
                        }
					}
						}break;
				case 32:{// Minion Target
					    if(m_caster->GetUInt64Value(UNIT_FIELD_SUMMON) == 0)
	            			tmpMap.push_back(m_caster->GetGUID());
                        else
                            tmpMap.push_back(m_caster->GetUInt64Value(UNIT_FIELD_SUMMON));
						}break;
				case 35:{// Single Target Party Member
					Unit* Target = objmgr.GetObject<Player>(m_targets.m_unitTarget);
					if(!Target)
						break;
					if(Target->getLevel() >= (m_spellInfo->spellLevel) && _CalcDistance(m_caster->GetPositionX(),m_caster->GetPositionY(),m_caster->GetPositionZ(),Target->GetPositionX(),Target->GetPositionY(),Target->GetPositionZ()) < GetMaxRange(sSpellRange.LookupEntry(m_spellInfo->rangeIndex)))
						tmpMap.push_back(m_targets.m_unitTarget);
						}break;
				case 45:{// Chain
					//bool onlyParty = false;
					Unit* firstTarget;
					firstTarget = objmgr.GetObject<Player>(m_targets.m_unitTarget);
					if(!firstTarget)
						firstTarget = objmgr.GetObject<Creature>(m_targets.m_unitTarget);
					if(!firstTarget)
						break;
					Group* pGroup = objmgr.GetGroupByLeader(p_caster->GetGroupLeader());
					if(pGroup)
                    {
					    for(uint32 p=0;p<pGroup->GetMembersCount();p++)
                        {
						    Unit* Target = objmgr.GetObject<Player>(pGroup->GetMemberGUID(p));
						    if(!Target || Target->GetGUID() == m_caster->GetGUID())
							    continue;
						    if(_CalcDistance(Target->GetPositionX(),Target->GetPositionY(),Target->GetPositionZ(),m_caster->GetPositionX(),m_caster->GetPositionY(),m_caster->GetPositionZ()) < GetMaxRange(sSpellRange.LookupEntry(m_spellInfo->rangeIndex)))
							    tmpMap.push_back(Target->GetGUID());
					    }
                    }
                    else
                    {
                        Raid* pGroup = objmgr.GetRaidByLeader(p_caster->GetGroupLeader());
                        if(pGroup)
                        {                            
                            std::list<SubRaidMembers*>::iterator itr;
                            RaidGroup raidGroup = pGroup->GetRaidGroup(((Player *)m_caster)->GetRaidSubGroup());
                            for(itr = raidGroup.subGroup.begin();itr != raidGroup.subGroup.end();)
		                    {
                                Unit* Target = objmgr.GetObject<Player>((*itr)->memberGuid);
							    if(!Target || Target->GetGUID() == m_caster->GetGUID())
								    continue;
							    if(Target->getLevel() >= (m_spellInfo->spellLevel) && _CalcDistance(m_caster->GetPositionX(),m_caster->GetPositionY(),m_caster->GetPositionZ(),Target->GetPositionX(),Target->GetPositionY(),Target->GetPositionZ()) < GetMaxRange(sSpellRange.LookupEntry(m_spellInfo->rangeIndex)))
								    tmpMap.push_back(Target->GetGUID());
                                ++itr;
                            }
                        }
					    else
                        {
						    tmpMap.push_back(m_caster->GetGUID());
                        }
                    }                        
					/*for(uint32 p=0;p<pGroup->GetMembersCount();p++){
						if(firstTarget->GetGUID() == pGroup->GetMemberGUID(p))
							onlyParty = true;
					}*/
						}break;
                case 47:{// Portal
                    //FIXME: Not sure
                            tmpMap.push_back(m_caster->GetGUID());
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
						if(_CalcDistance(Target->GetPositionX(),Target->GetPositionY(),Target->GetPositionZ(),(*itr)->GetPositionX(),(*itr)->GetPositionY(),(*itr)->GetPositionZ()) < GetRadius(sSpellRadius.LookupEntry(m_spellInfo->EffectRadiusIndex[i])))
                        {
                            if(m_caster->GetTypeId() == TYPEID_PLAYER && (*itr)->GetTypeId() == TYPEID_PLAYER)
                            {
                                if(((Player *)m_caster)->DuelingWith == ((Player *)(*itr)))
                                {
                                    tmpMap.push_back((*itr)->GetGUID());
                                }
                                else
                                {
                                    if(((Unit *)(*itr))->myFaction & m_caster->hostile)
							            tmpMap.push_back((*itr)->GetGUID());
                                }
                            }
                            else
                            {
                                if(((Unit *)(*itr))->myFaction & m_caster->hostile)
							        tmpMap.push_back((*itr)->GetGUID());
                            }
                        }
					}
						}break;
                case 57:{// Targeted Party Member
                    //FIXME:Cannot be targeted for a time
                    //Power Word Shield
					Unit* Target = objmgr.GetObject<Player>(m_targets.m_unitTarget);
					if(!Target)
						break;
					if(Target->getLevel() >= (m_spellInfo->spellLevel) && _CalcDistance(m_caster->GetPositionX(),m_caster->GetPositionY(),m_caster->GetPositionZ(),Target->GetPositionX(),Target->GetPositionY(),Target->GetPositionZ()) < GetMaxRange(sSpellRange.LookupEntry(m_spellInfo->rangeIndex)))
						tmpMap.push_back(m_targets.m_unitTarget);
						}break;
				default:{
						}break;
			}
			if(m_spellInfo->EffectChainTarget[i] != 0){  // Add Chain Targets
				if(m_targets.m_unitTarget){
					Unit* target = objmgr.GetObject<Creature>(m_targets.m_unitTarget);
				}
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
	if (m_melee)
	{
		m_targets = *targets;
		melee();
	} else
	{
		int8 result;

		WorldPacket data;

		m_targets = *targets;


		SendSpellStart();
		m_timer = GetCastTime(sCastTime.LookupEntry(m_spellInfo->CastingTimeIndex));
		if (m_caster->GetTypeId() == TYPEID_PLAYER)
		{
			m_timer -= ((Player*)m_caster)->GetSpellTimeMod(m_spellInfo->Id);
		}
		/*		if ((m_spellInfo->Id == 2480) || (m_spellInfo->Id == 2480) || (m_spellInfo->Id == 7919) || (m_spellInfo->Id == 7918))
		{
		if (m_caster->GetTypeId() == TYPEID_PLAYER)
		{
		m_timer = ((Player*)m_caster)->GetItemBySlot(EQUIPMENT_SLOT_RANGED)->GetProto()->Delay;
		}
		}*/
		m_spellState = SPELL_STATE_PREPARING;

		m_castPositionX = m_caster->GetPositionX();
		m_castPositionY = m_caster->GetPositionY();
		m_castPositionZ = m_caster->GetPositionZ();

		result = CanCast();
		if(result != -1){
			if(m_triggeredByAffect){
				SendChannelUpdate(0);
				m_triggeredByAffect->SetDuration(0);
			}
			finish();
		}

		if(m_triggeredSpell || m_melee)
			cast();
		else
			m_caster->castSpell( this );
	}
}


void Spell::cancel()
{
	WorldPacket data;

	if(m_spellState == SPELL_STATE_PREPARING)
	{
		SendInterrupted(0);
		SendCastResult(SPELL_FAILED_INTERRUPTED);
	}
	else if(m_spellState = SPELL_STATE_CASTING)
	{
		m_caster->RemoveAffectById(m_spellInfo->Id);
		SendChannelUpdate(0);
	}

	m_spellState = SPELL_STATE_FINISHED;
}
void Spell::melee()
{
	FillTargetMap();
	SendCastResult(-1);
	SendSpellStart();
	SendSpellGo();
	std::list<uint64>::iterator i;
	uint32 cnt = 0;
	uint32 uniq = 0;
	for(i= m_targetUnits1.begin();i != m_targetUnits1.end();i++)
		HandleEffects((*i),0);
	for(i= m_targetUnits2.begin();i != m_targetUnits2.end();i++)
		HandleEffects((*i),1);
	for(i= m_targetUnits3.begin();i != m_targetUnits3.end();i++)
		HandleEffects((*i),2);
	for(i= UniqueTargets.begin();i != UniqueTargets.end();i++)
		HandleAddAffect((*i));
	finish();
}
void Spell::cast()
{
	printf("Spell::cast %u, Unit: %u\n", m_spellInfo->Id, m_caster->GetGUID());
	WorldPacket data;
	bool Instant = true;
	if (m_spellInfo->Attributes & 4)
		Instant = false;
	if (m_melee) Instant = false;
	int8 castResult = -1;
	castResult = CanCast();
	if(castResult == -1){
		TakePower();
		RemoveItems();
		FillTargetMap();
		SendCastResult(castResult);
		if(Instant){
			SendSpellGo();

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
			{
				//printf("effecting1 %u\n",(*i));
				HandleEffects((*i),0);
			}
			for(i= m_targetUnits2.begin();i != m_targetUnits2.end();i++)
			{
				//printf("effecting2 %u\n",(*i));
				HandleEffects((*i),1);
			}
			for(i= m_targetUnits3.begin();i != m_targetUnits3.end();i++)
			{
				//printf("effecting3 %u\n",(*i));
				HandleEffects((*i),2);
			}
			for(i= UniqueTargets.begin();i != UniqueTargets.end();i++)
			{
				//printf("adding affects %u\n",(*i));
				HandleAddAffect((*i));
			}
		} else {
			if (m_caster->GetOnMeleeSpell() != m_spellInfo->Id)
				m_caster->SetOnMeleeSpell(m_spellInfo->Id);
			finish();
			Log::getSingleton().outError("Adding spell to melee");
		}
		if (Instant)
		{
			if(m_spellState != SPELL_STATE_CASTING)
				finish();

			if(castResult == 0)
				TriggerSpell();
		}
	}
}

void Spell::AddTime()
{
	WorldPacket data;
	m_timer += 400;
	data.Initialize(SMSG_SPELL_DELAYED);
	data << m_caster->GetNewGUID();
	data << uint32(400);
	((Player*)m_caster)->SendMessageToSet(&data, true);
}
void Spell::update(uint32 difftime)
{
	if(m_castPositionX != m_caster->GetPositionX() ||
		m_castPositionY != m_caster->GetPositionY() ||
		m_castPositionZ != m_caster->GetPositionZ() )
	{
		SendInterrupted(0);
		SendCastResult(SPELL_FAILED_INTERRUPTED);
		if(m_spellState == SPELL_STATE_CASTING){
			m_caster->RemoveAffectById(m_spellInfo->Id);
			if(m_timer > 0)
			{
				if(m_caster->GetTypeId() == TYPEID_PLAYER)
				{
					Creature *pTarget = objmgr.GetCreature(((Player *)m_caster)->GetSelection());
					if(!pTarget)
						Player *pTarget = objmgr.GetPlayer(((Player *)m_caster)->GetSelection());

					if(pTarget)
					{
						pTarget->RemoveAffectByIdAndGuid(m_spellInfo->Id, m_caster->GetGUID());
					}
				}					
			}
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
	m_caster->m_canMove = true;
	/* Mana Regenerates while in combat but not for 5 seconds after each spell */
	m_caster->setRegenTimer(5000); /* 5 Seconds */
	if (m_CastItem)
	{
		if (m_CastItem->GetProto()->Class == 0)
		{
			if ((m_CastItem->GetUInt32Value(ITEM_FIELD_SPELL_CHARGES)-1) <= 0)
			{
				if (m_CastItem->GetUInt32Value(ITEM_FIELD_STACK_COUNT) <= 1)
				{
					Item* item = ((Player*)m_caster)->GetItemByGUID(m_CastItem->GetGUID(), true);
					item->DeleteFromDB();
					delete item;
					m_CastItem = NULL;
					//RemoveItemFromSlot(((Player*)m_caster)->GetSlotByItemGUID(m_CastItem->GetGUID()));
				}
				else
				{
					//m_CastItem->SetUInt32Value(ITEM_FIELD_SPELL_CHARGES,(m_CastItem->GetUInt32Value(ITEM_FIELD_SPELL_CHARGES)-1));
					m_CastItem->SetUInt32Value(ITEM_FIELD_SPELL_CHARGES,1);
					m_CastItem->SetUInt32Value(ITEM_FIELD_STACK_COUNT,m_CastItem->GetUInt32Value(ITEM_FIELD_STACK_COUNT)-1);
				}
			}
			else
			{
				m_CastItem->SetUInt32Value(ITEM_FIELD_SPELL_CHARGES,(m_CastItem->GetUInt32Value(ITEM_FIELD_SPELL_CHARGES)-1));
			}
		}
	}
	if (!m_melee)
		DetermineSkillUp();
}

void Spell::SendCastResult(int8 result)
{
	if (!load)
	{
		if (m_caster->GetTypeId() != TYPEID_PLAYER)
			return;

		WorldPacket data;

		data.Initialize(SMSG_CAST_RESULT);
		data << m_spellInfo->Id;
		if(result != -1){
			data << uint8(2);
			data << (uint8)result;
		}else
			data << uint8(0);
		((Player*)m_caster)->GetSession()->SendPacket(&data);
	}
}


void Spell::SendSpellStart()
{
	if (!load)
	{
		// Send Spell Start
		WorldPacket data;
		uint16 cast_flags;

		cast_flags = 2;

		data.Initialize(SMSG_SPELL_START);
		data << m_caster->GetNewGUID() << m_caster->GetNewGUID();
		data << m_spellInfo->Id;
		data << cast_flags;
		data << GetCastTime(sCastTime.LookupEntry(m_spellInfo->CastingTimeIndex));

		m_targets.write( &data );
		((Player*)m_caster)->SendMessageToSet(&data, true);
	}
}


void Spell::SendSpellGo()
{
	// Start Spell
	WorldPacket data;
	uint16 flags;

	flags = m_targets.m_targetMask;
	if(flags == 0)
		flags = 2;

	data.Initialize(SMSG_SPELL_GO);

	data << m_caster->GetNewGUID() << m_caster->GetNewGUID();
	data << m_spellInfo->Id;
	//data << flags;
	data << uint16(0x0500);
	writeSpellGoTargets(&data);

	data << (uint8)0;  // number of misses
	m_targets.write( &data );
	if (!load)
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

void Spell::SendLogExecute(uint32 damage)
{
	if (!load)
	{
		/*WorldPacket data;
		data.Initialize(SMSG_SPELLLOGEXECUTE);
		data << m_caster->GetNewGUID();
		data << m_spellInfo->Id;
		data << uint32(1);
		data << uint32(10);
		data << uint32(1);
		data << m_targets.m_unitTarget;
		data << damage;
		data << uint8(0);
		m_caster->SendMessageToSet(&data,true);*/
	}
}

void Spell::SendInterrupted(uint8 result)
{
	WorldPacket data;

	data.Initialize(SMSG_SPELL_FAILURE);

    data << m_caster->GetNewGUID();
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

void Spell::SendResurrectRequest(Player* target)
{
	WorldPacket data;
	data.Initialize(SMSG_RESURRECT_REQUEST);
    data << m_caster->GetNewGUID();
	data << uint32(0) << uint8(0);

	target->GetSession()->SendPacket(&data);
	return;
}

void Spell::TakePower()
{
	uint16 powerField;
	uint32 currentPower;

	//uint8 powerType  (uint8)(m_caster->GetUInt32Value(UNIT_FIELD_BYTES_0) >> 24);
/*	if(powerType == 0) // Mana
		powerField = UNIT_FIELD_POWER1;
	else if(powerType == 1) // Rage
		powerField = UNIT_FIELD_POWER2;
	else if(powerType == 3) // Energy
		powerField = UNIT_FIELD_POWER4;*/
	switch(m_spellInfo->powerType){
		case POWER_TYPE_HEALTH:{
			powerField = UNIT_FIELD_HEALTH;
		}break;
		case POWER_TYPE_MANA:{
			powerField = UNIT_FIELD_POWER1;
		}break;
		case POWER_TYPE_RAGE:{
			powerField = UNIT_FIELD_POWER2;
		}break;
        case POWER_TYPE_FOCUS:{
            powerField = UNIT_FIELD_POWER3;
        }break;
		case POWER_TYPE_ENERGY:{
			powerField = UNIT_FIELD_POWER4;
		}break;
		default:{
			sLog.outDebug("unknown power type");
		}break;
	}

	currentPower = m_caster->GetUInt32Value(powerField);
    int mod = 0;
    if(m_spellInfo->ManaCostPercentage > 0)
    {
	    printf("it costs %u percent mana \n",m_spellInfo->ManaCostPercentage);
	    if(m_spellInfo->ManaCostPercentage == 100)
		    m_caster->SetUInt32Value(powerField, 0);
	    else
		    m_caster->SetUInt32Value(powerField, currentPower - ((currentPower/100)*m_spellInfo->ManaCostPercentage));
    }
    else
    {	    
	    if (m_caster->GetTypeId() == TYPEID_PLAYER)
	    {
		    mod = (((Player*)m_caster)->GetSpellManaMod(m_spellInfo->Id) / 100.0f) * m_spellInfo->manaCost;
	    }
	    printf("it costs %u mana \n",m_spellInfo->manaCost + mod);
	    if(currentPower < (m_spellInfo->manaCost + mod))
		    m_caster->SetUInt32Value(powerField, 0);
	    else
		    m_caster->SetUInt32Value(powerField, currentPower - (m_spellInfo->manaCost + mod));
    }
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
    if(unitTarget && (m_caster->hostile & unitTarget->myFaction))
        unitTarget->GetAIInterface()->AttackReaction(m_caster,1,0);
    if(!unitTarget)
        unitTarget = objmgr.GetObject<Player>(guid);
    if(m_caster->GetTypeId() == TYPEID_PLAYER)
		itemTarget = ((Player*)m_caster)->GetItemByGUID(guid, false);
	    //itemTarget = ((Player*)m_caster)->GetItemBySlot(((Player*)m_caster)->GetSlotByItemGUID(guid));
    gameObjTarget = objmgr.GetObject<GameObject>(guid);
    playerTarget = objmgr.GetObject<Player>(guid);

    uint32 damage = 0;
    damage = CalculateDamage((uint8)i, unitTarget);
	SendLogExecute(damage);

	switch(m_spellInfo->Effect[i]){
            case SPELL_EFFECT_INSTANT_KILL:{
                }break;
            case SPELL_EFFECT_SCHOOL_DAMAGE:{    // School Damage
                if(!unitTarget)
                    break;
                if(!unitTarget->isAlive())
                    break;

				if (m_caster->GetTypeId() == TYPEID_PLAYER)
				{
					int mod = (((Player*)m_caster)->GetSpellDamageMod(m_spellInfo->Id) / 100.0f) * damage;
					damage += mod;

                    //FIXME: Find a way to remove all rank spells
                    //TODO: Add spellis casted to start of this function
                    /*if(spellId == 17962) // Conflagrate ( Removes immolate spell )
                    {
                        unitTarget->RemoveAffectByIdAndGuid();
                    }
                    */
				}
                m_caster->SpellNonMeleeDamageLog(unitTarget,m_spellInfo->Id, damage);
            }break;
            case SPELL_EFFECT_DUMMY:{    // Dummy(Scripted events)
				//curse of agony(18230) = periodic damage increased in 
				//flag 2031678
				uint32 spellId = m_spellInfo->Id;
				switch(spellId)
				{
                case 12472://Cold Snap
                    {
                        //clear cooldown of frost spells
                    }break;
				case 18280://Curse of agony
					{
						if(!unitTarget)
							break;
						if(!unitTarget->isAlive())
							break;
						Affect* aff = m_triggeredByAffect;
						if(!aff)
							break;
						Unit *caster = aff->GetCaster();
						if(!caster)
							break;
						if(aff->GetDuration() == 22000) //FIXME: find a better way todo it
							caster->SetCastedCurse(TRUE);
						damage = aff->GetDamagePerTick()*((2*((24000-aff->GetDuration())/1000))/24);
						if(damage == 0)
							damage = 2;
						caster->SpellNonMeleeDamageLog(unitTarget,m_spellInfo->Id, damage);
						if(aff->GetDuration() == 0)
							caster->SetCastedCurse(FALSE);
					}break;
				}						
            }break;
            case SPELL_EFFECT_PORTAL_TELEPORT:{
            }break;
			case SPELL_EFFECT_TELEPORT_UNITS:{	// Teleport Units
				if(!unitTarget)
					break;
				HandleTeleport(m_spellInfo->Id,unitTarget);
			}break;
            case SPELL_EFFECT_APPLY_AURA:{    // Apply Aura
                if(!unitTarget)
                    break;
                if(!unitTarget->isAlive())
                    break;

                if(unitTarget->tmpAffect == 0){
                    Affect* aff = new Affect(m_spellInfo,GetDuration(sSpellDuration.LookupEntry(m_spellInfo->DurationIndex)),m_caster->GetGUID(),m_caster);
                    unitTarget->tmpAffect = aff;
                }
                if(m_spellInfo->EffectBasePoints[0] < 0)
                    unitTarget->tmpAffect->SetNegative();

                uint32 type = 0;
                if(m_spellInfo->EffectBasePoints[i] < 0)
                    type = 1;

                switch(m_spellInfo->EffectApplyAuraName[i])
                {
                case SPELL_AURA_PERIODIC_DAMAGE:
                    {
                        unitTarget->tmpAffect->SetDamagePerTick(damage,(uint32)m_spellInfo->EffectAmplitude[i]);
                        unitTarget->tmpAffect->SetNegative();
                    }break;
                case SPELL_AURA_PERIODIC_HEAL:
                    {
                        unitTarget->tmpAffect->SetHealPerTick(damage,m_spellInfo->EffectAmplitude[i]);
                    }break;
                case SPELL_AURA_PERIODIC_TRIGGER_SPELL:
                    {
                        unitTarget->tmpAffect->SetPeriodicTriggerSpell(m_spellInfo->EffectTriggerSpell[i],m_spellInfo->EffectAmplitude[i],damage);
                    }break;
                case SPELL_AURA_PERIODIC_ENERGIZE:
                    {
                        unitTarget->tmpAffect->SetEnergizePerTick(damage,m_spellInfo->EffectAmplitude[i],m_spellInfo->EffectMiscValue[i]);
                    }break;
                case SPELL_AURA_PERIODIC_LEECH:
                    {
                        unitTarget->tmpAffect->SetLeechPerTick(damage, m_spellInfo->EffectAmplitude[i], SPELL_AURA_PERIODIC_LEECH);
                    }break;
                case SPELL_AURA_PERIODIC_MANA_LEECH:
                    {
					    unitTarget->tmpAffect->SetLeechPerTick(damage, m_spellInfo->EffectAmplitude[i], SPELL_AURA_PERIODIC_MANA_LEECH);
                    }break;
                case SPELL_AURA_CHANNEL_DEATH_ITEM:
                    {
					    unitTarget->tmpAffect->AddMod(m_spellInfo->EffectApplyAuraName[i],damage,m_spellInfo->EffectSpellGroupRelation[i],type);
                    }break;
                case SPELL_AURA_MOD_HEALTH_REGEN_IN_COMBAT:
                    {
                        unitTarget->tmpAffect->SetHealPerTick(damage, 5000);
                    }
                default:
                    {
					    //printf("applying aura %u\n",m_spellInfo->EffectApplyAuraName[i]);
                        unitTarget->tmpAffect->AddMod(m_spellInfo->EffectApplyAuraName[i],damage,m_spellInfo->EffectMiscValue[i],type);
                    }break;
                }
            }break;
            case SPELL_EFFECT_ENVIRONMENTAL_DAMAGE:{
            }break;
            case SPELL_EFFECT_POWER_DRAIN:{    // Power Drain
                if(!unitTarget)
                    break;
                if(!unitTarget->isAlive())
                    break;

                uint32 curPower = unitTarget->GetUInt32Value(UNIT_FIELD_POWER1);
                if(curPower < damage)
                    unitTarget->SetUInt32Value(UNIT_FIELD_POWER1,0);
                else
                    unitTarget->SetUInt32Value(UNIT_FIELD_POWER1,curPower-damage);
            }break;
            case SPELL_EFFECT_HEALTH_LEECH:{
                if(!unitTarget)
                    break;
                if(!unitTarget->isAlive())
                    break;

				uint32 curHealth = unitTarget->GetUInt32Value(UNIT_FIELD_HEALTH);
                unitTarget->SetUInt32Value(UNIT_FIELD_HEALTH,curHealth-damage);

				uint32 playerCurHealth = m_caster->GetUInt32Value(UNIT_FIELD_HEALTH);
                uint32 playerMaxHealth = m_caster->GetUInt32Value(UNIT_FIELD_MAXHEALTH);
                if(playerCurHealth+damage > playerMaxHealth)
                    m_caster->SetUInt32Value(UNIT_FIELD_HEALTH,playerMaxHealth);
                else
                    m_caster->SetUInt32Value(UNIT_FIELD_HEALTH,playerCurHealth+damage);                    
            }break;
            case SPELL_EFFECT_HEAL:{   // Heal
                if(!unitTarget)
                    break;
                if(!unitTarget->isAlive())
                    break;

                uint32 curHealth = unitTarget->GetUInt32Value(UNIT_FIELD_HEALTH);
                uint32 maxHealth = unitTarget->GetUInt32Value(UNIT_FIELD_MAXHEALTH);
                if(curHealth+damage > maxHealth)
                    unitTarget->SetUInt32Value(UNIT_FIELD_HEALTH,maxHealth);
                else
                    unitTarget->SetUInt32Value(UNIT_FIELD_HEALTH,curHealth+damage);
            }break;
            case SPELL_EFFECT_BIND:{
            }break;
            case SPELL_EFFECT_PORTAL:{
            }break;
            case SPELL_EFFECT_RITUAL_BASE:{
            }break;
            case SPELL_EFFECT_RITUAL_SPECIALIZE:{
            }break;
            case SPELL_EFFECT_RITUAL_ACTIVATE_PORTAL:{
            }break;
            case SPELL_EFFECT_QUEST_COMPLETE:{
            }break;
            case SPELL_EFFECT_WEAPON_DAMAGE_NOSCHOOL:{   // Weapon Damage + (no School)
                if(!unitTarget)
                    break;
                if(!unitTarget->isAlive())
                    break;

                uint32 minDmg,maxDmg;
                minDmg = maxDmg = 0;
                if(m_spellInfo->rangeIndex == 1 || m_spellInfo->rangeIndex == 2 || m_spellInfo->rangeIndex == 7){
                    minDmg = (uint32)m_caster->GetFloatValue(UNIT_FIELD_MINDAMAGE);
                    maxDmg = (uint32)m_caster->GetFloatValue(UNIT_FIELD_MAXDAMAGE);
                }else{
                    minDmg = (uint32)m_caster->GetFloatValue(UNIT_FIELD_MINRANGEDDAMAGE);
                    maxDmg = (uint32)m_caster->GetFloatValue(UNIT_FIELD_MAXRANGEDDAMAGE);
                }
                uint32 randDmg = maxDmg-minDmg;
                uint32 dmg = minDmg;
                if(randDmg > 1)
                    dmg += rand()%randDmg;
                dmg += damage;
                m_caster->SpellNonMeleeDamageLog(unitTarget,m_spellInfo->Id, dmg);
            }break;
            case SPELL_EFFECT_DUMMYMELEE:{   // Normalized Weapon Damage +
                if(!unitTarget)
                    break;
                if(!unitTarget->isAlive())
                    break;

                uint32 minDmg,maxDmg;
                minDmg = maxDmg = 0;
                minDmg = (uint32)m_caster->GetFloatValue(UNIT_FIELD_MINDAMAGE);
                maxDmg = (uint32)m_caster->GetFloatValue(UNIT_FIELD_MAXDAMAGE);
                uint32 randDmg = maxDmg-minDmg;
                uint32 dmg = minDmg;
                if(randDmg > 1)
                    dmg += rand()%randDmg;
				float mult = 0.0f;
				if (m_caster->GetTypeId()== TYPEID_PLAYER)
				{
					Player *pl = (Player*)m_caster;
					if (pl->GetItemBySlot(EQUIPMENT_SLOT_MAINHAND))
						if (pl->GetItemBySlot(EQUIPMENT_SLOT_MAINHAND)->GetProto()->InventoryType == INVTYPE_2HWEAPON)
							mult = 3.3f;
						else if (pl->GetItemBySlot(EQUIPMENT_SLOT_MAINHAND)->GetProto()->SubClass == 15)
							mult = 1.7f;
						else
							mult = 2.4f;
				}
				dmg *= mult;
				dmg *= 1.0f; // attack power / 14 todo: implement attack power
				dmg += damage;
                m_caster->SpellNonMeleeDamageLog(unitTarget,m_spellInfo->Id, dmg);
            }break;
            case SPELL_EFFECT_RESURRECT:{
            }break;
			case SPELL_EFFECT_ADD_EXTRA_ATTACKS:{
				for (uint32 n=0;n<rand()%((uint32)m_spellInfo->Effectunknown[i]);n++)
				{
					if(!unitTarget)
						break;
					if(!unitTarget->isAlive())
						break;

					uint32 minDmg,maxDmg;
					minDmg = maxDmg = 0;
					if(m_spellInfo->rangeIndex == 1 || m_spellInfo->rangeIndex == 2 || m_spellInfo->rangeIndex == 7){
						minDmg = (uint32)m_caster->GetFloatValue(UNIT_FIELD_MINDAMAGE);
						maxDmg = (uint32)m_caster->GetFloatValue(UNIT_FIELD_MAXDAMAGE);
					}else{
						minDmg = (uint32)m_caster->GetFloatValue(UNIT_FIELD_MINRANGEDDAMAGE);
						maxDmg = (uint32)m_caster->GetFloatValue(UNIT_FIELD_MAXRANGEDDAMAGE);
					}
					uint32 randDmg = maxDmg-minDmg;
					uint32 dmg = minDmg;
					if(randDmg > 1)
						dmg += rand()%randDmg;
					m_caster->SpellNonMeleeDamageLog(unitTarget,m_spellInfo->Id, dmg);
				}
			}break;
            case SPELL_EFFECT_DODGE:{
            }break;
            case SPELL_EFFECT_EVADE:{
            }break;
            case SPELL_EFFECT_PARRY:{
            }break;
            case SPELL_EFFECT_BLOCK:{
            }break;
            case SPELL_EFFECT_CREATE_ITEM:{   // Create item
                Player* pUnit = (Player*)m_caster;
                Item* newItem;
				Item *add;
				uint8 slot;
                for(i=0;i<3;i++){// now create the Items
                    if(m_spellInfo->EffectSpellGroupRelation[i] == 0)
                        continue;
					slot = 0;
					add = pUnit->FindItemLessMax(m_spellInfo->EffectSpellGroupRelation[i],1);
					if (!add)
					{
						slot = pUnit->FindFreeInvSlot();
					}
					if ((slot == INVENTORY_NO_SLOT_AVAILABLE) && (!add))
					{
						if (pUnit->FindBagWithFreeSlots())
							slot = pUnit->FindFreeBagSlot(pUnit->FindBagWithFreeSlots());
					}
					if ((slot == 0) && (!add))
					{
                        SendCastResult(0x18);
                        return;
                    }
					if (!add)
					{
						newItem = new Item();
						newItem->Create(objmgr.GenerateLowGuid(HIGHGUID_ITEM),m_spellInfo->EffectSpellGroupRelation[i],pUnit);
						pUnit->AddItemToSlot(slot,newItem);
						newItem->SetUInt64Value(ITEM_FIELD_CREATOR,m_caster->GetGUID());
						newItem = NULL;
					} else {
						add->SetUInt32Value(ITEM_FIELD_STACK_COUNT,add->GetUInt32Value(ITEM_FIELD_STACK_COUNT) + 1);
					}
                }
            }break;
            case SPELL_EFFECT_WEAPON:{
            }break;
            case SPELL_EFFECT_DEFENSE:{
            }break;
            case SPELL_EFFECT_PERSISTENT_AREA_AURA:{   // Persistent Area Aura
                if(m_AreaAura == true)
                    break;

				bool chck = true;
                m_AreaAura = true;
                // Spawn dyn GameObject
                DynamicObject* dynObj = new DynamicObject();
				switch(m_targets.m_targetMask){
					case TARGET_FLAG_SELF:
						{
							if(!unitTarget)
								break;
							if(!unitTarget->isAlive())
								break;
							dynObj->Create(objmgr.GenerateLowGuid(HIGHGUID_DYNAMICOBJECT), m_caster, m_spellInfo, m_caster->GetPositionX(), m_caster->GetPositionY(), m_caster->GetPositionZ(), GetDuration(sSpellDuration.LookupEntry(m_spellInfo->DurationIndex)),this);							
						}break;
					case TARGET_FLAG_UNIT:
						{
							if(!unitTarget)
								break;
							if(!unitTarget->isAlive())
								break;
							dynObj->Create(objmgr.GenerateLowGuid(HIGHGUID_DYNAMICOBJECT), m_caster, m_spellInfo, unitTarget->GetPositionX(), unitTarget->GetPositionY(), unitTarget->GetPositionZ(), GetDuration(sSpellDuration.LookupEntry(m_spellInfo->DurationIndex)),this);
						}break;
					case TARGET_FLAG_OBJECT:
						{
							if(!unitTarget)
								break;
							if(!unitTarget->isAlive())
								break;
							dynObj->Create(objmgr.GenerateLowGuid(HIGHGUID_DYNAMICOBJECT), m_caster, m_spellInfo, unitTarget->GetPositionX(), unitTarget->GetPositionY(), unitTarget->GetPositionZ(), GetDuration(sSpellDuration.LookupEntry(m_spellInfo->DurationIndex)),this);							
						}break;
					case TARGET_FLAG_ITEM:
						{
							delete dynObj;
							chck = false;
						}break;
					case TARGET_FLAG_SOURCE_LOCATION:
						{
							dynObj->Create(objmgr.GenerateLowGuid(HIGHGUID_DYNAMICOBJECT), m_caster, m_spellInfo, m_targets.m_srcX, m_targets.m_srcY, m_targets.m_srcZ, GetDuration(sSpellDuration.LookupEntry(m_spellInfo->DurationIndex)),this);
						}break;
					case TARGET_FLAG_DEST_LOCATION:
						{
							dynObj->Create(objmgr.GenerateLowGuid(HIGHGUID_DYNAMICOBJECT), m_caster, m_spellInfo, m_targets.m_destX, m_targets.m_destY, m_targets.m_destZ, GetDuration(sSpellDuration.LookupEntry(m_spellInfo->DurationIndex)),this);
						}break;
					case TARGET_FLAG_STRING:
						{
							delete dynObj;
							chck = false;
						}break;
					default:
						{
							delete dynObj;
							chck = false;
						}break;
				}
				if(chck)
				{
					dynObj->SetUInt32Value(OBJECT_FIELD_TYPE, 65);
					dynObj->SetUInt32Value(GAMEOBJECT_DISPLAYID, 368003);
					dynObj->SetUInt32Value(DYNAMICOBJECT_BYTES, 0x01eeeeee);
					dynObj->PeriodicTriggerDamage(damage, m_spellInfo->EffectAmplitude[i], GetRadius(sSpellRadius.LookupEntry(m_spellInfo->EffectRadiusIndex[i])));

					objmgr.AddObject(dynObj);
					dynObj->AddToWorld();

		            if(m_spellInfo->ChannelInterruptFlags != 0)
                    {
                        uint32 duration = GetDuration(sSpellDuration.LookupEntry(m_spellInfo->DurationIndex));
                        if (m_caster->GetTypeId() == TYPEID_PLAYER)
                        {
		                    // Send Channel Start
		                    WorldPacket data;
		                    data.Initialize( MSG_CHANNEL_START );
		                    data << m_spellInfo->Id;
		                    data << duration;
		                    ((Player*)m_caster)->GetSession()->SendPacket( &data );
	                    }

	                    m_timer = duration;

	                    m_caster->SetUInt32Value(UNIT_FIELD_CHANNEL_OBJECT,dynObj->GetGUIDLow());
	                    m_caster->SetUInt32Value(UNIT_FIELD_CHANNEL_OBJECT+1,dynObj->GetGUIDHigh());
	                    m_caster->SetUInt32Value(UNIT_CHANNEL_SPELL,m_spellInfo->Id);		            
                    }
				}
				else
				{
					m_AreaAura == false;
				}
            }break;
            case SPELL_EFFECT_SUMMON:{
            }break;
            case SPELL_EFFECT_LEAP:{
                float radius = GetRadius(sSpellRadius.LookupEntry(m_spellInfo->EffectRadiusIndex[i]));

                srand(time(NULL));
                float randomOr = (float)(rand());
                WorldPacket data;
                data.Initialize( MSG_MOVE_HEARTBEAT );
                
                float posX = m_caster->GetPositionX()+(radius*(cos(randomOr)));
                float posY = m_caster->GetPositionY()+(radius*(sin(randomOr)));
                data << m_caster->GetNewGUID();
                data << uint32(0) << uint32(0);
                data << posX;
                data << posY;
                data << m_caster->GetPositionZ()+150;
                data << m_caster->GetOrientation();
                m_caster->SendMessageToSet(&data, true);
           }break;
            case SPELL_EFFECT_ENERGIZE:{   // Energize
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
                if(POWER_TYPE == UNIT_FIELD_POWER2)
                    damage = damage*10;

                uint32 curEnergy = (uint32)unitTarget->GetUInt32Value(POWER_TYPE);
                uint32 maxEnergy = (uint32)unitTarget->GetUInt32Value(POWER_TYPE+6);
				uint32 totalEnergy = curEnergy+damage;
                if(totalEnergy > maxEnergy)
                    unitTarget->SetUInt32Value(POWER_TYPE,(uint32)maxEnergy);
                else
                    unitTarget->SetUInt32Value(POWER_TYPE,(uint32)totalEnergy);
            }break;
			case SPELL_EFFECT_WEAPON_PERCENT_DAMAGE:{
				if(!unitTarget)
					break;
				if(!unitTarget->isAlive())
					break;
				uint32 minDmg,maxDmg;
				minDmg = maxDmg = 0;
				if(m_spellInfo->rangeIndex == 1 || m_spellInfo->rangeIndex == 2 || m_spellInfo->rangeIndex == 7){
					minDmg = (uint32)m_caster->GetFloatValue(UNIT_FIELD_MINDAMAGE * (m_spellInfo->EffectBasePoints[i] / 100.0));
					maxDmg = (uint32)m_caster->GetFloatValue(UNIT_FIELD_MAXDAMAGE * (m_spellInfo->EffectBasePoints[i] / 100.0));
				}else{
					minDmg = (uint32)m_caster->GetFloatValue(UNIT_FIELD_MINRANGEDDAMAGE * (m_spellInfo->EffectBasePoints[i] / 100.0));
					maxDmg = (uint32)m_caster->GetFloatValue(UNIT_FIELD_MAXRANGEDDAMAGE * (m_spellInfo->EffectBasePoints[i] / 100.0));
				}
				uint32 randDmg = maxDmg-minDmg;
				uint32 dmg = minDmg;
				if(randDmg > 1)
					dmg += rand()%randDmg;
				m_caster->SpellNonMeleeDamageLog(unitTarget,m_spellInfo->Id, dmg);
			}break;
            case SPELL_EFFECT_TRIGGER_MISSILE:{
            }
            case SPELL_EFFECT_OPEN_LOCK:{   // Open Lock
                if(!gameObjTarget || !playerTarget)
                    break;

                data.clear();
                data.Initialize(SMSG_LOOT_RESPONSE);
                gameObjTarget->FillLoot(&data,(Player*)m_caster);
                playerTarget->SetLootGUID(m_targets.m_unitTarget);
                playerTarget->GetSession()->SendPacket(&data);
            }break;
            case SPELL_EFFECT_SUMMON_MOUNT_OBSOLETE:{
            }
            case SPELL_EFFECT_APPLY_AREA_AURA:{   // Apply Area Aura
                if(!unitTarget)
                    break;
                if(!unitTarget->isAlive())
                    break;

                Affect* aff = new Affect(m_spellInfo,6000,m_caster->GetGUID(), m_caster);
                aff->AddMod(m_spellInfo->EffectApplyAuraName[i],m_spellInfo->EffectBasePoints[i]+rand()%m_spellInfo->EffectDieSides[i]+1,m_spellInfo->EffectMiscValue[i],0);

                unitTarget->SetAura(aff);
            }break;
            case SPELL_EFFECT_LEARN_SPELL:{   // Learn Spell
                if(!playerTarget)
                    return;
                uint32 spellToLearn = m_spellInfo->EffectTriggerSpell[i];
                playerTarget->addSpell((uint16)spellToLearn);
                data.Initialize(SMSG_LEARNED_SPELL);
                data << spellToLearn;
                playerTarget->GetSession()->SendPacket(&data);
            }break;
            case SPELL_EFFECT_SPELL_DEFENSE:{
            }break;
			case SPELL_EFFECT_DISPEL:{	// dispel
				bool found = false;
				typedef std::list<Affect*> AffectList;
				AffectList::iterator k;
				Affect *aff;
				for(int j=0;j<damage;j++)
				{
					for (k = unitTarget->GetAffectBegin(); k != unitTarget->GetAffectEnd(); k++)
					{
						aff = (*k);
						if (aff->GetSpellProto()->field5 == m_spellInfo->EffectMiscValue[i])
						{
							if (((m_spellInfo->EffectImplicitTargetA[i] == 21 || m_spellInfo->EffectImplicitTargetB[i] == 21) && !aff->IsPositive())
								|| ((m_spellInfo->EffectImplicitTargetA[i] == 6 || m_spellInfo->EffectImplicitTargetB[i] == 6) && aff->IsPositive()))
							{
								unitTarget->RemoveAffect(aff);
								break;
							}
						}
					}					
				}
			}break;
            case SPELL_EFFECT_LANGUAGE:{
            }break;
            case SPELL_EFFECT_DUAL_WIELD:{
            }break;
            case SPELL_EFFECT_SUMMON_WILD:{   // Summon Wild
                if(!playerTarget)
                    return;

                CreatureInfo *ci;
                ci = objmgr.GetCreatureName(m_spellInfo->EffectMiscValue[i]);
                if(!ci){
                    printf("unknown entry ID. return\n");
                    return;
                }

                uint32 level = m_caster->getLevel();
                Creature* spawnCreature = new Creature();
                spawnCreature->Create(objmgr.GenerateLowGuid(HIGHGUID_UNIT),ci->Name.c_str(),m_caster->GetMapId(),m_caster->GetPositionX(),m_caster->GetPositionY(),m_caster->GetPositionZ(),m_caster->GetOrientation());
                spawnCreature->SetUInt32Value(UNIT_FIELD_DISPLAYID, ci->DisplayID);
                spawnCreature->SetUInt32Value(UNIT_NPC_FLAGS , 0);
                spawnCreature->SetUInt32Value(UNIT_FIELD_HEALTH, 28 + 30*level);
                spawnCreature->SetUInt32Value(UNIT_FIELD_MAXHEALTH, 28 + 30*level);
                spawnCreature->SetUInt32Value(UNIT_FIELD_LEVEL , level);
                spawnCreature->SetUInt32Value(OBJECT_FIELD_TYPE,ci->Type);

				//Log::getSingleton( ).outError("AddObject at Spell.cpp");
                objmgr.AddObject(spawnCreature);
                spawnCreature->AddToWorld();
            }break;
            case SPELL_EFFECT_SUMMON_GUARDIAN:{
            }break;
            case SPELL_EFFECT_TELEPORT_UNITS_FACE_CASTER:{
            }break;
            case SPELL_EFFECT_SKILL_STEP:{
            }break;
            case 45:{
            }break;
            case SPELL_EFFECT_SPAWN:{
            }break;
            case SPELL_EFFECT_TRADE_SKILL:{
            }break;
            case SPELL_EFFECT_STEALTH:{
            }break;
            case SPELL_EFFECT_DETECT:{
            }break;
            case SPELL_EFFECT_TRANS_DOOR:{
                //Ritual
            }break;
            case SPELL_EFFECT_FORCE_CRITICAL_HIT:{
            }break;
            case SPELL_EFFECT_GUARANTEE_HIT:{
            }break;
            case SPELL_EFFECT_ENCHANT_ITEM:{   // Enchant Item Permanent
				if (itemTarget->IsEnchanted())
				{
					itemTarget->RemoveEnchant(itemTarget->GetEnchant());
				}
				uint8 slot = ((Player*)m_caster)->GetSlotByItemGUID(guid);
				if(slot < EQUIPMENT_SLOT_END)
				{
					itemTarget->Enchant(true,m_spellInfo);
				} else
				{
					printf("enchanting spell id %u\n",m_spellInfo->Id);
					itemTarget->Enchant(false,m_spellInfo);
				}

/*
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
*/
            }break;
            case SPELL_EFFECT_ENCHANT_ITEM_TEMPORARY:{   // Enchant Item Temporary
				itemTarget = ((Player*)m_caster)->GetItemBySlot(EQUIPMENT_SLOT_MAINHAND);
				int VisibleBase = PLAYER_VISIBLE_ITEM_1_0 + (EQUIPMENT_SLOT_MAINHAND * 12);
				itemTarget->SetUInt32Value(ITEM_FIELD_ENCHANTMENT,m_spellInfo->EffectMiscValue[i]);
				m_caster->SetUInt32Value(VisibleBase + 1,m_spellInfo->EffectMiscValue[i]);
/*
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
*/
            }break;
            case SPELL_EFFECT_TAMECREATURE:
			{
/*				if(!unitTarget)
					break;
				if(!unitTarget->isAlive())
					break;
				if(unitTarget->GetCreatureName()->Family != BEAST)
					break;
                unitTarget->GetAIInterface()->Init(unitTarget,AITYPE_PET,MOVEMENTTYPE_NONE,m_caster);
                unitTarget->GetAIInterface()->SetUnitToFollow(m_caster);
                unitTarget->GetAIInterface()->SetFollowDistance(3.0f);
				unitTarget->SetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE,((Player *)m_caster)->myFaction);//m_caster->GetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE));
        //        NewSummon->GetAIInterface()->setCreatureState(MOVING);
                // NewSummon->GetAIInterface()->setUnitToFollow(m_caster);

//                ((Player *)m_caster)->SetPet(unitTarget);
				//get pet id
		        m_caster->SetUInt32Value(UNIT_FIELD_PETNUMBER, unitTarget->GetGUIDLow());
		//        sLog.outDebug("New Pet has guid %u", NewSummon->GetGUID());
                                        
		        //if(m_caster->isPlayer())
		        //{
		        //	data.clear();
		        //	data.Initialize(SMSG_PET_SPELLS);
		        //	data << (uint64)NewSummon->GetGUID() << uint32(0x00000101) << uint32(0x00000000) << uint32(0x07000001) << uint32(0x07000002);
		        //	data << uint32(0x02000000) << uint32(0x07000000) << uint32(0x04000000) << uint32(0x03000000) << uint32(0x06000002) << uint32(0x05000000);
		        //	data << uint32(0x06000000) << uint32(0x06000001) << uint8(0x02) << uint32(0x0c26) << uint32(0x18a3);
		        //	((Player*)m_caster)->GetSession()->SendPacket(&data);
		        //}
                if(m_caster->GetTypeId() == TYPEID_PLAYER)
		        {
			        data.clear();
			        data.Initialize(SMSG_PET_SPELLS);
			        data << (uint64)unitTarget->GetGUID() << uint32(0x00000000) << uint32(0x00001000)
				        << uint32(0x07000002) << uint32(0x07000001);
			        data << uint32(0x07000000) << uint32(0xC1002DF3) << uint32(0xC1002DF7) 
				        << uint32(0xC1002DFB) << uint32(0xC100119F) << uint32(0x06000002);
			        data << uint32(0x06000001) << uint32(0x06000000) << uint32(0x00492807) 
				        << uint32(0x00493101) << uint32(0x00493401) << uint32(0x00449F01);
			        data << uint32(0x002DF7C1) << uint32(0x002DFBC1) << uint32(0x002DF3C1) 
				        << uint32(0x119F02C1) << uint32(0x00000000) << uint32(0x00000000);
			        data << uint32(0x5CE88000) << uint32(0x000000) << uint32(0x00000000)<<uint16(0x0000); 
			        ((Player*)m_caster)->GetSession()->SendPacket(&data);
		        }*/

            }break;
            case SPELL_EFFECT_SUMMON_PET:{ //summon - pet
                WorldPacket data;
				uint32 entryId = m_spellInfo->EffectMiscValue[i];
				bool hasSpell = false;
				uint16 spell1,spell2,spell3,spell4;
				float size = 1.0f;
				//VoidWalker:torment, sacrifice, suffering, consume shadows
				//Succubus:lash of pain, soothing kiss, seduce , lesser invisibility
				//felhunter: 	Devour Magic,Paranoia,Spell Lock,	Tainted Blood
				switch(entryId)
				{
				//TODO: Insert here stats , life, mana, resistance, damage
				case 416: //Imp
					{
						spell1 = 3110;//Firebolt
						spell2 = 6307;//Blood Pact
						spell3 = 2947;//FireShield
						spell4 = 4511;//Phase Shift
						size = 0.3f;
						hasSpell = true;
					}break;
				case 417: //Felhunter
					{
						spell1 = 19505;
						spell2 = 19478;
						spell3 = 19480;
						spell4 = 19244;
						size = 0.7f;
						hasSpell = true;
					}break;
				case 1860: //VoidWalker
					{
						spell1 = 3716;
						spell2 = 7812;
						spell3 = 17735;
						spell4 = 17767;
						size = 0.75f;
						hasSpell = true;
					}break;
				case 1863: //Succubus
					{
						spell1 = 7814;
						spell2 = 6360;
						spell3 = 6358;
						spell4 = 7870;
						size = 1.0f;
						hasSpell = true;
					}break;
				default:
					{
						return;
					};
				}
						
	            if(m_caster->GetUInt64Value(UNIT_FIELD_SUMMON) != 0)
	            {
		            Creature *Summon;
		            Summon = objmgr.GetCreature(m_caster->GetUInt64Value(UNIT_FIELD_SUMMON));
		            if(Summon)
		            {
			            m_caster->SetUInt64Value(UNIT_FIELD_SUMMON, 0);
			            data.Initialize(SMSG_DESTROY_OBJECT);
			            data << Summon->GetGUID();
			            Summon->SendMessageToSet (&data, true);
			            
						//Remove from world
                        Summon->RemoveFromWorld();
                        objmgr.RemoveObject(Summon);
                        delete Summon;
		            }
	            }
	            Creature* NewSummon = new Creature();
                CreatureInfo *ci = objmgr.GetCreatureName(m_spellInfo->EffectMiscValue[i]);
	            if( NewSummon && ci)
	            {
					// Time stuff
					//uint32 ts = getMSTime();

					// Create
		            NewSummon->Create(objmgr.GenerateLowGuid(HIGHGUID_UNIT), ci->Name.c_str(), m_caster->GetMapId(), 
		            m_caster->GetPositionX(), m_caster->GetPositionY(), m_caster->GetPositionZ(), m_caster->GetOrientation());
		            //objmgr.AddCreatureTemplate(ci->Name.c_str(), ci->DisplayID));

					// Fields
		            NewSummon->SetUInt32Value(UNIT_FIELD_LEVEL,m_caster->GetUInt32Value(UNIT_FIELD_LEVEL));
		            NewSummon->SetUInt32Value(UNIT_FIELD_DISPLAYID,  ci->DisplayID);
		            NewSummon->SetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID, ci->DisplayID);
		            NewSummon->SetUInt64Value(UNIT_FIELD_SUMMONEDBY, m_caster->GetGUID());
					NewSummon->SetUInt64Value(UNIT_FIELD_CREATEDBY, m_caster->GetGUID());
		            NewSummon->SetUInt32Value(UNIT_NPC_FLAGS , 0);
		            NewSummon->SetUInt32Value(UNIT_FIELD_HEALTH , 28 + 30 * m_caster->GetUInt32Value(UNIT_FIELD_LEVEL));
		            NewSummon->SetUInt32Value(UNIT_FIELD_MAXHEALTH , 28 + 30 * m_caster->GetUInt32Value(UNIT_FIELD_LEVEL));
					NewSummon->SetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE,((Player *)m_caster)->getRace());//m_caster->GetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE));
		            NewSummon->SetFloatValue(OBJECT_FIELD_SCALE_X,size);//m_caster->GetFloatValue(OBJECT_FIELD_SCALE_X));
            		
		            NewSummon->SetUInt32Value(UNIT_FIELD_BYTES_0,2048); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_FLAGS,0);
		            NewSummon->SetUInt32Value(UNIT_FIELD_BASEATTACKTIME, 2000);//ci->baseattacktime); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_BASEATTACKTIME+1, 2000);//ci->rangeattacktime); 
		            NewSummon->SetFloatValue(UNIT_FIELD_BOUNDINGRADIUS, 0.1f);  
		            NewSummon->SetFloatValue(UNIT_FIELD_COMBATREACH,m_caster->GetFloatValue(UNIT_FIELD_COMBATREACH));            		

					NewSummon->SetUInt32Value(UNIT_FIELD_AURA,6307);
					NewSummon->SetUInt32Value(UNIT_FIELD_AURALEVELS,   0x6EEEEEE);
					NewSummon->SetUInt32Value(UNIT_FIELD_AURALEVELS+2, 0xeeeeeeee);
					NewSummon->SetUInt32Value(UNIT_FIELD_AURALEVELS+3, 0xeeeeeeee);
					NewSummon->SetUInt32Value(UNIT_FIELD_AURALEVELS+4, 0xeeeeeeee);
					NewSummon->SetUInt32Value(UNIT_FIELD_AURALEVELS+5, 0xeeeeeeee);
					NewSummon->SetUInt32Value(UNIT_FIELD_AURALEVELS+6, 0xeeeeeeee);
					NewSummon->SetUInt32Value(UNIT_FIELD_AURALEVELS+7, 0xeeeeeeee);
					NewSummon->SetUInt32Value(UNIT_FIELD_AURALEVELS+8, 0xeeeeeeee);
					NewSummon->SetUInt32Value(UNIT_FIELD_AURALEVELS+9, 0xeeeeeeee);
					NewSummon->SetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS,0xeeeeeeee);
					NewSummon->SetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS+1,0xeeeeeeee);
					NewSummon->SetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS+2,0xeeeeeeee);
					NewSummon->SetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS+3,0xeeeeeeee);
					NewSummon->SetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS+4,0xeeeeeeee);
					NewSummon->SetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS+5,0xeeeeeeee);
					NewSummon->SetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS+6,0xeeeeeeee);
					NewSummon->SetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS+7,0xeeeeeeee);
					NewSummon->SetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS+8,0xeeeeeeee);
					NewSummon->SetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS+9,0xeeeeeeee);
					NewSummon->SetUInt32Value(UNIT_FIELD_AURAFLAGS,8);
            		
		            NewSummon->SetUInt32Value(UNIT_FIELD_BYTES_1,0); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_PETNUMBER, NewSummon->GetGUIDLow());
		            NewSummon->SetUInt32Value(UNIT_FIELD_PET_NAME_TIMESTAMP,5); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_PETEXPERIENCE,0); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_PETNEXTLEVELEXP,1000); 
		            NewSummon->SetUInt32Value(UNIT_CREATED_BY_SPELL, m_spellInfo->Id); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_STAT0,22);
		            NewSummon->SetUInt32Value(UNIT_FIELD_STAT1,22); 
		            //NewSummon->SetUInt32Value(UNIT_FIELD_STAT2,25); 
		            //NewSummon->SetUInt32Value(UNIT_FIELD_STAT3,28);
		            NewSummon->SetUInt32Value(157,98440); 
		            NewSummon->SetUInt32Value(158,1114455494);
		            NewSummon->SetUInt32Value(UNIT_FIELD_STAT4,27); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_RESISTANCES+0,0); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_RESISTANCES+1,0); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_RESISTANCES+2,0); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_RESISTANCES+3,0); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_RESISTANCES+4,0); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_RESISTANCES+5,0); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_RESISTANCES+6,0); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_ATTACK_POWER,24);
		            NewSummon->SetUInt32Value(UNIT_FIELD_BASE_MANA, m_caster->GetUInt32Value(UNIT_FIELD_LEVEL)*30);//ci->maxmana); 
                    NewSummon->SetUInt32Value(OBJECT_FIELD_ENTRY, ci->Id);
		            NewSummon->SetZoneId(m_caster->GetZoneId());
					NewSummon->_LoadHealth();

					//Setting faction
					NewSummon->myFaction = m_caster->myFaction;
					NewSummon->hostile = m_caster->hostile;

					// Ai Init
                    NewSummon->GetAIInterface()->Init(NewSummon,AITYPE_PET,MOVEMENTTYPE_NONE,m_caster);
                    NewSummon->GetAIInterface()->SetUnitToFollow(m_caster);
                    NewSummon->GetAIInterface()->SetFollowDistance(4.0f);
                    NewSummon->SetCreatureName(ci);

					// Add To World
		            objmgr.AddObject(NewSummon);
                    NewSummon->AddToWorld();

					NewSummon->GetAIInterface()->HandleEvent(EVENT_FOLLOWOWNER, NewSummon, 0);

					// Player Stuff
                    ((Player *)m_caster)->SetPet(NewSummon);
					((Player *)m_caster)->SetPetName(ci->Name);
		            m_caster->SetUInt64Value(UNIT_FIELD_SUMMON, NewSummon->GetGUID());
/*					m_caster->SetUInt32Value(ITEM_FIELD_CONTAINED, NewSummon->GetGUIDLow());
					m_caster->SetUInt32Value(GAMEOBJECT_ROTATION, NewSummon->GetGUIDLow());*/
					((Player *)m_caster)->SetUInt32Value(UNIT_FIELD_PET_NAME_TIMESTAMP,(uint32)time(NULL));
		            sLog.outDebug("New Pet has guid %u", NewSummon->GetGUID());

                    if(m_caster->GetTypeId() == TYPEID_PLAYER)
		            {
			            data.clear();
			            data.Initialize(SMSG_PET_SPELLS);
						data << (uint64)NewSummon->GetGUID();
						data << uint32(0x00000000);//unk1
						data << uint32(0x00001000);//unk2
						data << uint32(PET_SPELL_ATTACK);//32,uint32(0x07000002)
						data << uint32(PET_SPELL_FOLLOW);//32,uint32(0x07000001)
						data << uint32(PET_SPELL_STAY);//32,uint32(0x07000000)
						if(hasSpell)
						{
							data << uint16(spell1);
							data << uint16(0xC100); //unk3
							data << uint16(spell2);
							data << uint16(0xC100);
							data << uint16(spell3);
							data << uint16(0xC100);
							data << uint16(spell4);
							data << uint16(0xC100);							
						}
						data << uint32(PET_SPELL_AGRESSIVE);//32,uint32(0x06000002)
						data << uint32(PET_SPELL_DEFENSIVE);//32,uint32(0x06000001)
						data << uint32(PET_SPELL_PASSIVE);//32,uint32(0x06000000)
						/*data << uint8(0x00); //unk4
						data << spellpassive1;//16
						data << uint8(0x01); //unk5
						data << uint8(0x00); //unk4
						data << spellpassive2;//16
						data << uint8(0x01); //unk5
						data << uint8(0x00); //unk4
						data << spellpassive3;//16
						data << uint8(0x01); //unk5
						data << spellrelated1; //same with spell 4//16
						data << uint(0x02C1); //unk6*/
						/*data << uint32(0x00000000);//spellrelated + 0(unk6)
						data << uint32(0x00000000);//spellrelated + 0(unk6)
						data << uint16(0x5CE8); //master demonologist ? talent
						data << uint16(0x8000); // flags ?
						data << uint32(0x00000000); // talent + flag
						data << uint32(0x00000000); // talent + flag
						data << uint16(0x0000); // unk7*/
						((Player*)m_caster)->GetSession()->SendPacket(&data);

			            //data << (uint64)NewSummon->GetGUID() << uint32(0x00000000) << uint32(0x00001000)
				           // << uint32(0x07000002)/*attack*/ << uint32(0x07000001);/*follow*/
			            //data << uint32(0x07000000)/*stay*/ << uint32(0xC1002DF3)/*spell1*/ << uint32(0xC1002DF7)/*spell2*/ 
				           // << uint32(0xC1002DFB)/*spell3*/ << uint32(0xC100119F) /*spell4*/ << uint32(0x06000002);/*agressive*/
			            //data << uint32(0x06000001)/*defensive*/ << uint32(0x06000000)/*passive*/ << uint32(0x00492807) /*8,32,8*/
				           // << uint32(0x00493101) /*8,32,8*/<< uint32(0x00493401)/*8,32,8*/ << uint32(0x00449F01);/*uint8,32,8*/
			            //data << uint32(0x002DF7C1)/*8,32spell,8*/ << uint32(0x002DFBC1)/*8,32spell,8*/ << uint32(0x002DF3C1) /*8,32spell,8*/
				           // << uint32(0x119F02C1)/*32spell4,32unk*/ << uint32(0x00000000) << uint32(0x00000000);
			            //data << uint32(0x5CE88000) << uint32(0x000000) << uint32(0x00000000)<<uint16(0x0000); 
			            //((Player*)m_caster)->GetSession()->SendPacket(&data);
		            }
	            }
            }break;
            case SPELL_EFFECT_LEARN_PET_SPELL:{
            }break;
            case SPELL_EFFECT_WEAPON_DAMAGE:{   // Weapon damage +
                if(!unitTarget)
                    break;
                if(!unitTarget->isAlive())
                    break;

                uint32 minDmg,maxDmg;
                minDmg = maxDmg = 0;
                if(m_spellInfo->rangeIndex == 1 || m_spellInfo->rangeIndex == 2 || m_spellInfo->rangeIndex == 7){
                    minDmg = (uint32)m_caster->GetFloatValue(UNIT_FIELD_MINDAMAGE);
                    maxDmg = (uint32)m_caster->GetFloatValue(UNIT_FIELD_MAXDAMAGE);
                }else{
                    minDmg = (uint32)m_caster->GetFloatValue(UNIT_FIELD_MINRANGEDDAMAGE);
                    maxDmg = (uint32)m_caster->GetFloatValue(UNIT_FIELD_MAXRANGEDDAMAGE);
                }
                uint32 randDmg = maxDmg-minDmg;
                uint32 dmg = minDmg;
                if(randDmg > 1)
                    dmg += rand()%randDmg;
                dmg += damage;
				m_caster->SpellNonMeleeDamageLog(unitTarget,m_spellInfo->Id, damage);
            }break;
            case SPELL_EFFECT_OPEN_LOCK_ITEM:{
            }break;
            case SPELL_EFFECT_PROFICIENCY:{
            }break;
            case SPELL_EFFECT_SEND_EVENT:{
            }break;
			case SPELL_EFFECT_POWER_BURN:{	// power burn
				//if (unitTarget->GetUInt32Value(UNIT_FIELD_MAXPOWER1) > 0)
				//{
					if(!unitTarget)
						break;
					if(!unitTarget->isAlive())
						break;

					m_caster->SpellNonMeleeDamageLog(unitTarget,m_spellInfo->Id, (uint32)(damage * m_spellInfo->Effectunknown[i]));
				//}
			}break;
            case SPELL_EFFECT_THREAT:{   // Threat
                if(!unitTarget)
                    break;
                if(!unitTarget->isAlive())
                    break;

				bool chck = unitTarget->GetAIInterface()->modThreatByGUID(unitTarget->GetGUID(),m_spellInfo->EffectBasePoints[i]);
				if(chck == false)
					unitTarget->GetAIInterface()->AttackReaction(m_caster,1,0);
            }break;
            case SPELL_EFFECT_TRIGGER_SPELL:{   // Trigger Spell
                TriggerSpellId = m_spellInfo->EffectTriggerSpell[i];
            }break;
            case SPELL_EFFECT_HEALTH_FUNNEL:{
                if(!unitTarget)
                    break;
                if(!unitTarget->isAlive())
                    break;

				
            }break;
            case SPELL_EFFECT_POWER_FUNNEL:{
            }break;
            case SPELL_EFFECT_HEAL_MAX_HEALTH:{   // Heal Max Health
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
            case SPELL_EFFECT_INTERRUPT_CAST:{   // Interrupt Cast
                if(!unitTarget)
                    break;
                if(!unitTarget->isAlive())
                    break;

                // FIXME:This thing prevent target from spell casting too but cant find.
                unitTarget->InterruptSpell();
            }break;
            case SPELL_EFFECT_DISTRACT:{
                //spellId 1725 Distract:Throws a distraction attracting the all monsters for ten sec's
                if(!unitTarget)
                    break;
                if(!unitTarget->isAlive())
                    break;
                //unitTarget->GetAIInterface()->SendStopPacket()(unitTarget->GetPositionX(),unitTarget->GetPositionY(),unitTarget->GetPositionZ(),
            }break;
            case SPELL_EFFECT_PULL:{
            }break;
            case SPELL_EFFECT_PICKPOCKET:{
                //Show random loot based on roll,
            }break;
            case SPELL_EFFECT_ADD_FARSIGHT:{
            }break;
            case SPELL_EFFECT_SUMMON_POSSESSED:{// eye of kilrog
/*				uint32 entryId = m_spellInfo->EffectMiscValue[i];
				float size = 1.0f;				
	            if(m_caster->GetUInt64Value(UNIT_FIELD_CHARM) != 0)
	            {
                    break;
                    //Send Cast Result
	            }   
	            Creature* NewSummon = new Creature();
                CreatureInfo *ci = objmgr.GetCreatureName(m_spellInfo->EffectMiscValue[i]);
	            if( NewSummon && ci)
	            {
					// Create
		            NewSummon->Create(objmgr.GenerateLowGuid(HIGHGUID_UNIT), ci->Name.c_str(), m_caster->GetMapId(), 
		            m_caster->GetPositionX()+(3*(cos((M_PI/2)+m_caster->GetOrientation()))), m_caster->GetPositionY()+(3*(cos((M_PI/2)+m_caster->GetOrientation()))), m_caster->GetPositionZ(), m_caster->GetOrientation());
		            //objmgr.AddCreatureTemplate(ci->Name.c_str(), ci->DisplayID));

					// Fields
		            NewSummon->SetUInt32Value(UNIT_FIELD_LEVEL,m_caster->GetUInt32Value(UNIT_FIELD_LEVEL));
		            NewSummon->SetUInt32Value(UNIT_FIELD_DISPLAYID,  ci->DisplayID);
		            NewSummon->SetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID, ci->DisplayID);
		            NewSummon->SetUInt64Value(UNIT_FIELD_SUMMONEDBY, m_caster->GetGUID());
					NewSummon->SetUInt64Value(UNIT_FIELD_CREATEDBY, m_caster->GetGUID());
		            NewSummon->SetUInt32Value(UNIT_NPC_FLAGS , 0);
		            NewSummon->SetUInt32Value(UNIT_FIELD_HEALTH , 28 + 30 * m_caster->GetUInt32Value(UNIT_FIELD_LEVEL));
		            NewSummon->SetUInt32Value(UNIT_FIELD_MAXHEALTH , 28 + 30 * m_caster->GetUInt32Value(UNIT_FIELD_LEVEL));
					NewSummon->SetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE, 35);//((Player *)m_caster)->getRace());//m_caster->GetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE));
		            NewSummon->SetFloatValue(OBJECT_FIELD_SCALE_X,size);//m_caster->GetFloatValue(OBJECT_FIELD_SCALE_X));
            		
		            NewSummon->SetUInt32Value(UNIT_FIELD_BYTES_0,2048); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_FLAGS,0);
		            NewSummon->SetUInt32Value(UNIT_FIELD_BASEATTACKTIME, 2000);//ci->baseattacktime); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_BASEATTACKTIME+1, 2000);//ci->rangeattacktime); 
		            NewSummon->SetFloatValue(UNIT_FIELD_BOUNDINGRADIUS, 0.1f);  
		            NewSummon->SetFloatValue(UNIT_FIELD_COMBATREACH,m_caster->GetFloatValue(UNIT_FIELD_COMBATREACH));            		

                    NewSummon->SetUInt32Value(UNIT_FIELD_FLAGS, 768);
                    NewSummon->SetUInt32Value(UNIT_FIELD_AURA+0, 10848);
                    NewSummon->SetUInt32Value(UNIT_FIELD_AURALEVELS+0, 0xEEEEEE3C);
                    NewSummon->SetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS+0, 0xEEEEEE00);
                    NewSummon->SetUInt32Value(UNIT_FIELD_AURAFLAGS+0, 0x00000009);
            		
		            NewSummon->SetUInt32Value(UNIT_FIELD_BYTES_1,0); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_PETNUMBER, NewSummon->GetGUIDLow());
		            NewSummon->SetUInt32Value(UNIT_FIELD_PET_NAME_TIMESTAMP,5); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_PETEXPERIENCE,0); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_PETNEXTLEVELEXP,1000); 
		            NewSummon->SetUInt32Value(UNIT_CREATED_BY_SPELL, m_spellInfo->Id); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_STAT0,22);
		            NewSummon->SetUInt32Value(UNIT_FIELD_STAT1,22); 
		            //NewSummon->SetUInt32Value(UNIT_FIELD_STAT2,25); 
		            //NewSummon->SetUInt32Value(UNIT_FIELD_STAT3,28);
		            NewSummon->SetUInt32Value(157,98440); 
		            NewSummon->SetUInt32Value(158,1114455494);
		            NewSummon->SetUInt32Value(UNIT_FIELD_STAT4,27); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_RESISTANCES+0,0); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_RESISTANCES+1,0); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_RESISTANCES+2,0); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_RESISTANCES+3,0); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_RESISTANCES+4,0); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_RESISTANCES+5,0); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_RESISTANCES+6,0); 
		            NewSummon->SetUInt32Value(UNIT_FIELD_ATTACK_POWER,24);
		            NewSummon->SetUInt32Value(UNIT_FIELD_BASE_MANA, m_caster->GetUInt32Value(UNIT_FIELD_LEVEL)*30);//ci->maxmana); 
                    NewSummon->SetUInt32Value(OBJECT_FIELD_ENTRY, ci->Id);
		            NewSummon->SetZoneId(m_caster->GetZoneId());
					NewSummon->_LoadHealth();

					//Setting faction
					NewSummon->myFaction = 35;
					NewSummon->hostile = 35;

					// Add To World
		            objmgr.AddObject(NewSummon);
                    NewSummon->AddToWorld();

                    m_caster->SetUInt64Value(UNIT_FIELD_SUMMON, NewSummon->GetGUID());
                    m_caster->SetUInt64Value(PLAYER_FARSIGHT,NewSummon->GetGUID());
		            if(m_spellInfo->ChannelInterruptFlags != 0)
                    {
                        uint32 duration = GetDuration(sSpellDuration.LookupEntry(m_spellInfo->DurationIndex));
                        if (m_caster->GetTypeId() == TYPEID_PLAYER)
                        {
	                        // Send Channel Start
	                        WorldPacket data;
	                        data.Initialize( MSG_CHANNEL_START );
	                        data << m_spellInfo->Id;
	                        data << duration;
	                        ((Player*)m_caster)->GetSession()->SendPacket( &data );
                        }

                        m_timer = duration;


                        m_caster->SetUInt32Value(UNIT_FIELD_CHANNEL_OBJECT,NewSummon->GetGUIDLow());
                        m_caster->SetUInt32Value(UNIT_FIELD_CHANNEL_OBJECT+1,NewSummon->GetGUIDHigh());
                        m_caster->SetUInt32Value(UNIT_CHANNEL_SPELL,m_spellInfo->Id);                    
                    }

		            sLog.outDebug("New Possesed has guid %u", NewSummon->GetGUID());
                }*/
            }break;
            case SPELL_EFFECT_SUMMON_TOTEM:{
            }break;
            case SPELL_EFFECT_HEAL_MECHANICAL:{
            }break;
            case SPELL_EFFECT_SUMMON_OBJECT_WILD:{
            }break;
            case SPELL_EFFECT_SCRIPT_EFFECT:{   
				uint32 spellId = m_spellInfo->Id;
				switch(spellId)
				{
				case 635:
				case 639:
				case 647:
				case 1026:
				case 1042:
				case 3472:
				case 10348:// Holy Light
					{
						if(!unitTarget)
							break;
						if(!unitTarget->isAlive())
							break;

						if( unitTarget->getRace() == 5 )
						{
							uint32 curHealth = unitTarget->GetUInt32Value(UNIT_FIELD_HEALTH);
							uint32 maxHealth = unitTarget->GetUInt32Value(UNIT_FIELD_MAXHEALTH);
							m_caster->SpellNonMeleeDamageLog(unitTarget,m_spellInfo->Id,damage);
						}
						else
						{
							uint32 curHealth = unitTarget->GetUInt32Value(UNIT_FIELD_HEALTH);
							uint32 maxHealth = unitTarget->GetUInt32Value(UNIT_FIELD_MAXHEALTH);
							if(curHealth+damage > maxHealth)
								unitTarget->SetUInt32Value(UNIT_FIELD_HEALTH,maxHealth);
							else
								unitTarget->SetUInt32Value(UNIT_FIELD_HEALTH,curHealth+damage);
						}
					}break;
                /*Arcane Missiles*/
             /*   case 5143://Rank 1
                case 5144://Rank 2
                case 5145://Rank 3
                case 8416://Rank 4
                case 8417://Rank 5
                case 10211://Rank 6
                case 10212://Rank 7
                case 25345://Rank 8
                    {
                        if(m_caster->tmpAffect == 0){
                            Affect* aff = new Affect(m_spellInfo,GetDuration(sSpellDuration.LookupEntry(m_spellInfo->DurationIndex)),m_caster->GetGUID(),m_caster);
                            m_caster->tmpAffect = aff;
                        }
                        if(m_spellInfo->EffectBasePoints[0] < 0)
                            m_caster->tmpAffect->SetNegative();

                        m_caster->tmpAffect->SetPeriodicTriggerSpell(m_spellInfo->EffectTriggerSpell[0],m_spellInfo->EffectAmplitude[0],damage);
                    }break;*/                        
				/*
				Creates a Healthstone that can be used to instantly restore 500 health.
				Conjured items disappear if logged out for more than 15 minutes.*/
				//FIXME: Conjured items disappear if logged out for more than 15 minutes.
				//itemId's might be wrong
				case 6201://Create Healthstone (Minor)
					{
						CreateItem(442);
					}break;
				case 6202://Create Healthstone (Lesser)
					{
						CreateItem(5733);
					}break;
				case 5699://Create Healthstone
					{
						CreateItem(5509);//9286
					}break;
				case 11729://Create Healthstone (Greater)
					{
						CreateItem(11419);//5510?
					}break;
				case 11730://Create Healthstone (Major)
					{
						CreateItem(8370);//9421?
					}break;
				}
            }break;
            case SPELL_EFFECT_ATTACK:{
            }break;
            case SPELL_EFFECT_SANCTUARY:{
            }break;
            case SPELL_EFFECT_ADD_COMBO_POINTS:{   // Add Combo Points
                if(!unitTarget)
                    return;
                uint8 comboPoints = ((m_caster->GetUInt32Value(PLAYER_FIELD_BYTES) & 0xFF00) >> 8);
                if(m_caster->GetUInt64Value(PLAYER__FIELD_COMBO_TARGET) != unitTarget->GetGUID()){
                    m_caster->SetUInt64Value(PLAYER__FIELD_COMBO_TARGET,unitTarget->GetGUID());
                    m_caster->SetUInt32Value(PLAYER_FIELD_BYTES,((m_caster->GetUInt32Value(PLAYER_FIELD_BYTES) & ~(0xFF << 8)) | (0x01 << 8)));
                }else{
                    if(comboPoints < 5){
                        comboPoints += 1;
                        m_caster->SetUInt32Value(PLAYER_FIELD_BYTES,((m_caster->GetUInt32Value(PLAYER_FIELD_BYTES) & ~(0xFF << 8)) | (comboPoints << 8)));
                    }
                }
            }break;
            case SPELL_EFFECT_CREATE_HOUSE:{
            }break;
            case SPELL_EFFECT_BIND_SIGHT:{
            }break;
			case SPELL_EFFECT_DUEL: // Duel
			{
				if(!m_caster)
					break;

				if(m_caster->GetTypeId() != TYPEID_PLAYER)
					break;

				if(!m_caster->isAlive())
					break;

				sDuelHandler.RequestDuel((Player *)m_caster);
			}
			break;
            case SPELL_EFFECT_STUCK:{
            }break;
            case SPELL_EFFECT_SUMMON_PLAYER:{
            }break;
            case SPELL_EFFECT_ACTIVATE_OBJECT:{
            }break;
            case SPELL_EFFECT_SUMMON_TOTEM_SLOT1:    // Summon Totem (slot 1)
            case SPELL_EFFECT_SUMMON_TOTEM_SLOT2:    // Summon Totem (slot 2)
            case SPELL_EFFECT_SUMMON_TOTEM_SLOT3:    // Summon Totem (slot 3)
            case SPELL_EFFECT_SUMMON_TOTEM_SLOT4:{   // Summon Totem (slot 4)
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
                        Totem->RemoveFromWorld();
                        objmgr.RemoveObject(Totem);
                    }
                }

                // spawn a new one
                Creature* pTotem = new Creature();
                CreatureInfo* ci = objmgr.GetCreatureName(m_spellInfo->EffectMiscValue[i]);
                if(!ci){
                    printf("break: unknown CreatureEntry\n");
                    return;
                }
                char* name = (char*)ci->Name.c_str();

                // uint32 guidlow, uint16 display_id, uint8 state, uint32 obj_field_entry, uint8 scale, uint16 type, uint16 faction,  float x, float y, float z, float ang
                pTotem->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), name, m_caster->GetMapId(), m_caster->GetPositionX(), m_caster->GetPositionY(), m_caster->GetPositionZ(), m_caster->GetOrientation() );
                pTotem->SetUInt32Value(OBJECT_FIELD_TYPE,33);
                pTotem->SetUInt32Value(UNIT_FIELD_DISPLAYID,ci->DisplayID);
                pTotem->SetUInt32Value(UNIT_FIELD_LEVEL,m_caster->getLevel());
				//Log::getSingleton( ).outError("AddObject at Spell.cppl line 1040");
                objmgr.AddObject(pTotem);
                pTotem->AddToWorld();

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
            case SPELL_EFFECT_THREAT_ALL:{
            }break;
            case SPELL_EFFECT_ENCHANT_HELD_ITEM:{   // Enchant Held Item
            }break;
            case SPELL_EFFECT_SUMMON_PHANTASM:{
            }break;
            case SPELL_EFFECT_SELF_RESURRECT:{
            }break;
            case SPELL_EFFECT_SKINNING:{
            }break;
            case SPELL_EFFECT_CHARGE:{
            }break;
            case SPELL_EFFECT_SUMMON_CRITTER:{
            }break;
            case SPELL_EFFECT_KNOCK_BACK:{
            }break;
            case SPELL_EFFECT_DISENCHANT:{
            }break;
            case SPELL_EFFECT_INEBRIATE:{
            }break;
            case SPELL_EFFECT_FEED_PET:{  // Feed Pet
                TriggerSpellId = m_spellInfo->EffectTriggerSpell[i];
            }break;
            case SPELL_EFFECT_SUMMON_OBJECT_SLOT1:   // Summon Object (slot 1)
            case SPELL_EFFECT_SUMMON_OBJECT_SLOT2:   // Summon Object (slot 2)
            case SPELL_EFFECT_SUMMON_OBJECT_SLOT3:   // Summon Object (slot 3)
            case SPELL_EFFECT_SUMMON_OBJECT_SLOT4:{  // Summon Object (slot 4)

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
                        obj->RemoveFromWorld();
                        objmgr.RemoveObject(obj);
                    }
                }

                // spawn a new one
                GameObject* pGameObj = new GameObject();
                uint16 display_id = (uint16)m_spellInfo->EffectMiscValue[i];

                // uint32 guidlow, uint16 display_id, uint8 state, uint32 obj_field_entry, uint8 scale, uint16 type, uint16 faction,  float x, float y, float z, float ang
                pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), display_id, 1, m_spellInfo->EffectMiscValue[i], 1, 6, 6, m_caster->GetMapId(), m_caster->GetPositionX(), m_caster->GetPositionY(), m_caster->GetPositionZ(), m_caster->GetOrientation() );
                pGameObj->SetUInt32Value(OBJECT_FIELD_TYPE,33);
                pGameObj->SetUInt32Value(GAMEOBJECT_LEVEL,m_caster->getLevel());
				//Log::getSingleton( ).outError("AddObject at Spell.cpp 1100");
                objmgr.AddObject(pGameObj);
                pGameObj->AddToWorld();

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
            case SPELL_EFFECT_DISPEL_MECHANIC:{
            }break;
            case SPELL_EFFECT_SUMMON_DEAD_PET:{
            }break;
            case SPELL_EFFECT_DESTROY_ALL_TOTEMS:{
            }break;
            case SPELL_EFFECT_DURABILITY_DAMAGE:{
            }break;
            case SPELL_EFFECT_SUMMON_DEMON:{
            }break;
            case SPELL_EFFECT_RESURRECT_FLAT:{  // Resurrect (Flat)
                if(!playerTarget)
                    break;
                if(playerTarget->isAlive())
                    break;
                if(!playerTarget->IsInWorld())
                    break;

                uint32 health = m_spellInfo->EffectBasePoints[i];
                uint32 mana = m_spellInfo->EffectMiscValue[i];
                playerTarget->setResurrect(m_caster->GetGUID(), m_caster->GetPositionX(), m_caster->GetPositionY(), m_caster->GetPositionZ(), health, mana);
                SendResurrectRequest(playerTarget);
            }break;
            case SPELL_EFFECT_ATTACK_ME:{
                if(!unitTarget)
                    break;
                if(!unitTarget->isAlive())
                    break;

                unitTarget->GetAIInterface()->AttackReaction(m_caster,1,0);
            }break;
            case SPELL_EFFECT_DURABILITY_DAMAGE_PCT:{
            }break;
            case SPELL_EFFECT_SKIN_PLAYER_CORPSE:{
            }break;
            case SPELL_EFFECT_SPIRIT_HEAL:{
            }break;
            case SPELL_EFFECT_SKILL:{
            }break;
            case SPELL_EFFECT_APPLY_AURA_NEW:{
            }break;
            case SPELL_EFFECT_TELEPORT_GRAVEYARD:{
            }break;
			default:{
				//PLAYER_TRACK_CREATURES 2^X
				//printf("unknown effect\n");
					}break;
	}
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

		Spell *spell = new Spell(m_caster, spellInfo,false, 0,false);
		WPAssert(spell);

		SpellCastTargets targets;
		targets.m_unitTarget = m_targets.m_unitTarget;

		spell->prepare(&targets);
	}
}
void Spell::DetermineSkillUp()
{
	skilllinespell* skill = objmgr.GetSpellSkill(m_spellInfo->Id);
	if (m_caster->GetTypeId() == TYPEID_PLAYER)
	{
		if ((skill) && ((Player*)m_caster)->HasSkillLine(skill->skilline))
		{
			uint32 amt = ((Player*)m_caster)->GetSkillAmt(skill->skilline);
			uint32 max = ((Player*)m_caster)->GetSkillMax(skill->skilline);
			if (amt >= skill->grey)
			{
			} else if ((amt >= (((skill->grey - skill->green) / 2) + skill->green)) && (amt < max))
			{
				if (rand()%100 < 33)
					((Player*)m_caster)->ModSkillLine(skill->skilline,1);	

			} else if ((amt >= skill->green) && (amt < max))
			{
				if (rand()%100 < 66)
					((Player*)m_caster)->ModSkillLine(skill->skilline,1);		

			} else 
			{
				if (amt < max)
					((Player*)m_caster)->ModSkillLine(skill->skilline,1);
			}
		}
	}

}
int8 Spell::CanCast()
{
	int8 castResult = -1;
	Unit* target = objmgr.GetObject<Creature>(m_targets.m_unitTarget);
	if(!target)
		Unit* target = objmgr.GetObject<Player>(m_targets.m_unitTarget);
	if(target){
		if(!m_caster->isInFront(target) && m_caster != target)
            castResult = SPELL_FAILED_NOT_INFRONT;
		if(_CalcDistance(m_caster->GetPositionX(),m_caster->GetPositionY(),m_caster->GetPositionZ(),target->GetPositionX(),target->GetPositionY(),target->GetPositionZ()) > GetMaxRange(sSpellRange.LookupEntry(m_spellInfo->rangeIndex)))
			castResult = SPELL_FAILED_OUT_OF_RANGE;
	}

	if(m_targets.m_destX != 0 && m_targets.m_destY != 0  && m_targets.m_destZ != 0 ){
		if(_CalcDistance(m_caster->GetPositionX(),m_caster->GetPositionY(),m_caster->GetPositionZ(),m_targets.m_destX,m_targets.m_destY,m_targets.m_destZ) > GetMaxRange(sSpellRange.LookupEntry(m_spellInfo->rangeIndex)))
			castResult = SPELL_FAILED_OUT_OF_RANGE;
	}

    if(m_caster->m_silenced)
		castResult = SPELL_FAILED_SILENCED;

    if(m_caster->IsPacified())
        castResult = SPELL_FAILED_PACIFIED;

    if(m_caster->IsStunned())
        castResult = SPELL_FAILED_STUNNED;

 /*   if((m_spellInfo->new_field1 & 1048576) && (m_spellInfo->AttributesEx & 134218240))
    {
        if(m_caster->isInFront(target) && m_caster != target)
        {
            castResult = SPELL_FAILED_NOT_BEHIND;
        }
    }*/

	if(castResult == -1 && m_caster->GetTypeId() == TYPEID_PLAYER)
		castResult = CheckItems();
	/*    Cheat Detection, crashes somehow need to fix it
	if(m_caster->GetTypeId() == TYPEID_PLAYER && m_triggeredByAffect == 0)
	{
	std::list<struct spells>::iterator i;
	for(i = ((Player*)m_caster)->getSpellList().begin();i != ((Player*)m_caster)->getSpellList().end();i++)
	{
	if(i->spellId == m_spellInfo->Id)
	break;
	}
	if(i != ((Player*)m_caster)->getSpellList().end())
	{
	castResult = 0x1F;
	FILE *pFile = fopen("spells.log", "a+");
	fprintf(pFile,"Player: %u tried to use a not known spell: %u\n", m_caster->GetGUID(),m_spellInfo->Id);
	fclose(pFile);
	}
	}
	*/

	if(castResult != -1)
		SendCastResult(castResult);

	return castResult;
}

int8 Spell::CheckItems()
{
	if (m_caster->GetTypeId() != TYPEID_PLAYER)
		return int8(-1);

	Player* p_caster = (Player*)m_caster;

	for(uint32 i=0;i<8;i++)
	{
		if((m_spellInfo->Reagent[i] == 0) || (m_spellInfo->ReagentCount[i] == 0))
			continue;
		if (p_caster->GetItemCount(m_spellInfo->Reagent[i]) < m_spellInfo->ReagentCount[i])
			return int8(SPELL_FAILED_ITEM_GONE);
	}

	/* // Check Totems
	uint32 totems = 2;
	for(uint32 i=0;i<2;i++)
	{
	if(m_spellInfo->Totem[i] != 0)
	{
	for(uint32 j=0;j<INVENTORY_SLOT_ITEM_END;j++)
	{
	itm = p_caster->GetItemBySlot(j);
	if(itm->GetProto()->ItemId == m_spellInfo->Totem[i])
	{
	totems -= 1;
	continue;
	}
	}
	}else
	totems -= 1;
	}
	if(totems != 0)
	return int8(SPELL_FAILED_TOTEMS);*/

	return int8(-1);
}

void Spell::RemoveItems()
{
	if (m_caster->GetTypeId() != TYPEID_PLAYER)
		return;

	Player* p_caster = (Player*)m_caster;
	Item* itm;

	for(uint32 i=0;i<8;i++)
	{
		if(m_spellInfo->Reagent[i] == 0)
			continue;
		p_caster->RemoveItemAmt(m_spellInfo->Reagent[i],m_spellInfo->ReagentCount[i]);
	}
}

uint32 Spell::CalculateDamage(uint8 i, Unit* unitTarget)
{
	uint32 value = 0;
	uint8 comboPoints = 0;
	float basePointsPerLevel = (float)sqrt(m_spellInfo->EffectRealPointsPerLevel[i]*m_spellInfo->EffectRealPointsPerLevel[i]);
	float randomPointsPerLevel = (float)sqrt(m_spellInfo->EffectDicePerLevel[i]*m_spellInfo->EffectDicePerLevel[i]);
	uint32 basePoints = (uint32)sqrt((float)(m_spellInfo->EffectBasePoints[i]*(float)m_spellInfo->EffectBasePoints[i]));//+(m_caster->getLevel()*basePointsPerLevel);
	uint32 randomPoints = (uint32)sqrt((float)(m_spellInfo->EffectDieSides[i]*(float)m_spellInfo->EffectDieSides[i]))+(m_caster->getLevel()*randomPointsPerLevel);
	uint32 comboDamage = (uint32)sqrt((float)m_spellInfo->EffectPointsPerComboPoint[i]*(float)m_spellInfo->EffectPointsPerComboPoint[i]);
	if(m_caster->GetTypeId() == TYPEID_PLAYER)
		comboPoints = (uint8)((m_caster->GetUInt32Value(PLAYER_FIELD_BYTES) & 0xFF00) >> 8);
	//DK:Unit resistance
	/*   uint32 resistanceType = m_spellInfo->School;
	uint32 resistanceModifier = 0; 
	uint32 resistChanceMod = 0;
	uint8 lvldiff;
	int resistChance;
	uint32 resistPercent;*/

	srand(time(NULL));

	if(randomPoints <= 1)
		value = basePoints+1;
	else
		value = basePoints+rand()%randomPoints;

	if(m_caster->GetTypeId() == TYPEID_PLAYER)
		if(comboDamage > 0)
		{
			for(uint32 j=0;j<comboPoints;j++)
				value += comboDamage;
			m_caster->SetUInt32Value(PLAYER_FIELD_BYTES,((m_caster->GetUInt32Value(PLAYER_FIELD_BYTES) & ~(0xFF << 8)) | (0x00 << 8)));
		}
		if ((m_spellInfo->Id == 2480) || (m_spellInfo->Id == 2480) || (m_spellInfo->Id == 7919) || (m_spellInfo->Id == 7918))
		{
			if (m_caster->GetTypeId() == TYPEID_PLAYER)
			{
				float base = ((Player*)m_caster)->GetItemBySlot(EQUIPMENT_SLOT_RANGED)->GetProto()->DamageMin[0];
				float diff = ((Player*)m_caster)->GetItemBySlot(EQUIPMENT_SLOT_RANGED)->GetProto()->DamageMax[0] - 
					((Player*)m_caster)->GetItemBySlot(EQUIPMENT_SLOT_RANGED)->GetProto()->DamageMin[0];
				base += rand()%((uint32)diff);
				ItemPrototype* ip = objmgr.GetItemPrototype(((Player*)m_caster)->GetUInt32Value(PLAYER_AMMO_ID));
				float add = ((ip->DamageMax[0] + 
					ip->DamageMin[0]) / 2.0)
					*  (((Player*)m_caster)->GetItemBySlot(EQUIPMENT_SLOT_RANGED)->GetProto()->Delay / 1000.0);
				printf("dmax=%f dmin=%f adps = %f rdps=%f add is %f\n",ip->DamageMax[0],ip->DamageMin[0],((ip->DamageMax[0] + ip->DamageMin[0]) / 2.0),((Player*)m_caster)->GetItemBySlot(EQUIPMENT_SLOT_RANGED)->GetProto()->Delay / 1000.0 ,add);
				base += add;
				value = base;
			}
		}
		//increase/decrease Damage by Talents etc.
		//for poison you got procChance and procCount as well
		//for example 30% chance to apply that affect
		//and it lasts for 30min or 55 applys
		/*   DK
		The general resistance data is as follows for PVE:
		Vs. +0 level mob (same level), old resist: 4% new resist: 4%
		Vs. +1 level mob, old resist: 5% new resist: 5%
		Vs. +2 level mob, old resist: 6% new resist: 6%
		Vs. +3 level mob, old resist: 37% new resist: 17%
		Vs. +4 level mob, old resist: 48% new resist: 28%
		Vs. +5 level mob, old resist: 59% new resist: 39%
		Vs. +6 level mob, old resist: 70% new resist: 50%
		…
		And so on (+11% for each additional level)*/
		/*	if(unitTarget->GetTypeId() == TYPEID_PLAYER)
		{
		resistanceModifier = unitTarget->GetUInt32Value(UNIT_FIELD_RESISTANCES+resistanceType);

		if(resistanceModifier != NULL)
		{
		resistChanceMod = unitTarget->GetResistChanceMod();
		if(resistChanceMod != NULL)
		{
		lvldiff = (m_caster->getLevel())-(unitTarget->getLevel());
		if(lvldiff < 0) //attacker is attacking target that has higher level from him
		{
		lvldiff = (unitTarget->getLevel()) - (m_caster->getLevel());

		if(lvldiff > 59)
		lvldiff = 59;

		resistChance = 50+(lvldiff)*49/59;
		resistChance = resistChance - resistChanceMod ;//modifier buff
		resistPercent = (resistanceModifier/(unitTarget->getLevel()*5))*75/100;
		if(rand()%100 <= resistChance)
		value=value-(value*resistPercent/100)
		//					value=value-(value/100);
		}
		else //attacker is attacking target that has lower level from him
		{
		if(lvldiff > 59)
		lvldiff = 59;

		resistChance = 50+(lvldiff)*49/59;
		resistChance = resistChance - resistChanceMod ;//modifier buff
		if(rand()%100 <= resistChance+lvldiff/2) //or lvldiff/4
		value=value-(value*resistanceModifier/320);
		}
		}
		}
		if(resistanceModifier < 0 || resistanceModifier > 320 || resistanceModifier == 320)
		{
		value=0;
		}
		return value;
		}
		else if(unitTarget->GetTypeId() == TYPEID_UNIT)
		{
		//Simple formula
		lvldiff=(m_caster->getLevel())-(unitTarget->getLevel());
		if(lvldiff < 0) //attacker is attacking target that has higher level from him
		{
		lvldiff = (unitTarget->getLevel()) - (m_caster->getLevel());

		if(lvldiff > 59)
		lvldiff = 59;
		resistChance = 50+(lvldiff)*49/59;
		if(rand()%100 <= resistChance)
		value=value-(value*lvldiff/320);
		}
		else //attacker is attacking target that has lower level from him
		{
		if(lvldiff > 59)
		lvldiff = 59;

		resistChance = 50+(lvldiff)*49/59;
		if(rand()%100 <= resistChance+lvldiff/2) //or lvldiff/4
		value=value-(value*lvldiff/60);
		}
		return value;
		}
		else
		{*/
		return value;
		//}
		/*Average Resistance = (Target's Resistance / (Caster's Level * 5)) * 0.75
		Average resistance may be no higher than 75%. Of course, what it takes to reach 
		75% average resistance depends on the spellcaster's level. Against a level 1 spellcaster, 
		it would take a resistance stat of 5. Level 20 would take 100 resistance. 
		Level 50 would take 250 resistance. Level 60 would take 300 resistance. Level 63 would take 315 resistance.*/
}

void Spell::HandleTeleport(uint32 id, Unit* Target)
{
	Player* pTarget;
	pTarget = objmgr.GetObject<Player>(Target->GetGUID());
	TeleportCoords* TC = new TeleportCoords;
	WorldPacket data;
	if (m_spellInfo->Id == 8690)
	{
		TC->x = pTarget->GetBindPositionX();
		TC->y = pTarget->GetBindPositionY();
		TC->z = pTarget->GetBindPositionZ();
		TC->mapId = pTarget->GetBindMapId();
	} else
	{
		TC = objmgr.GetTeleportCoords(id);
	}
	if(!TC)
		return;

	data.Initialize(SMSG_TRANSFER_PENDING);
	data << uint32(0);
	if(pTarget)
		pTarget->GetSession()->SendPacket(&data);

	pTarget->RemoveFromWorld();

	// Build a NEW WORLD packet
	data.Initialize(SMSG_NEW_WORLD);
	data << TC->mapId << TC->x << TC->y << TC->z << (float)0.0f;
	if(pTarget)
		pTarget->GetSession()->SendPacket(&data);

	// TODO: clear attack list

	pTarget->SetMapId(TC->mapId);
	pTarget->SetPosition(TC->x, TC->y, TC->z, 0);

}

void Spell::CreateItem(uint32 itemId)
{
	Player* caster = (Player*)m_caster;
    Item* newItem;
	Item *add;
	uint8 slot;
	slot = 0;
	add = caster->FindItemLessMax(itemId,1);
	if (!add)
	{
		slot = caster->FindFreeInvSlot();
	}
	if ((slot == INVENTORY_NO_SLOT_AVAILABLE) && (!add))
	{
		if (caster->FindBagWithFreeSlots())
			slot = caster->FindFreeBagSlot(caster->FindBagWithFreeSlots());
	}
	if ((slot == 0) && (!add))
	{
        SendCastResult(0x18);
        return;
    }
	if (!add)
	{
        sLog.outDebug("CreateItem Func");
		newItem = new Item;
		newItem->Create(objmgr.GenerateLowGuid(HIGHGUID_ITEM),itemId,caster);
		caster->AddItemToSlot(slot,newItem);
		newItem->SetUInt64Value(ITEM_FIELD_CREATOR,m_caster->GetGUID());
		newItem = NULL;
	} else {
		add->SetUInt32Value(ITEM_FIELD_STACK_COUNT,add->GetUInt32Value(ITEM_FIELD_STACK_COUNT) + 1);
	}
}


