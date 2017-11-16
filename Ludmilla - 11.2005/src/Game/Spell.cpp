#include "StdAfx.h"

// Copyright (C) 2004 WoW Daemon

#include "../Shared/PacketBuilder.h"
#include "../Spells/Spells.h"

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


#define SPELL_CHANNEL_UPDATE_INTERVAL 1000

//-----------------------------------------------------------------------------
void SpellCastTargets::read ( WorldPacket * data,uint64 caster )
{
	m_unitTarget = m_itemTarget = 0;
	m_srcX = m_srcY = m_srcZ = m_destX = m_destY = m_destZ = 0;
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

//-----------------------------------------------------------------------------
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

//-----------------------------------------------------------------------------
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

//-----------------------------------------------------------------------------
void Spell::FillTargetMap()
{
	Player	*p_caster = (Player*)m_caster;
	std::list<uint64> tmpMap;
	ObjectSet::iterator itr;
	uint32	cur = 0;
	bool	onlyParty = false;
	Group	*pGroup;
	Unit	*firstTarget;
	uint32	HasTargets = 0;
	Object *o;

	for(uint32 i=0;i<3;i++)
	{
		for(uint32 j=0;j<2;j++)
		{
			if (j == 0) cur = m_spellInfo->EffectImplicitTargetA[i];
			if (j == 1) cur = m_spellInfo->EffectImplicitTargetB[i];

			HasTargets += cur;
			switch(cur)
			{
			case EFF_TARGET_SELF:
				tmpMap.push_back(m_caster->GetGUID());
				break;

			case EFF_TARGET_PET:
				tmpMap.push_back(m_caster->GetUInt32Value(UNIT_FIELD_PETNUMBER));
				break;

			case EFF_TARGET_SINGLE_ENEMY:
				tmpMap.push_back(m_targets.m_unitTarget);
				break;

			case EFF_TARGET_ALL_ENEMY_IN_AREA: // (TEST) 
			case EFF_TARGET_ALL_ENEMY_IN_AREA_INSTANT: // (e.g. Flamestrike)
				//for( itr = m_caster->GetInRangeSetBegin(); itr != m_caster->GetInRangeSetEnd(); itr++ )
				for (MapRangeIterator itr (m_caster); o = itr.Advance(); )
				{
					if (o->isNotUnit() && o->isNotPlayer()) 
						continue;

					float rad = GetRadius(sSpellRadius.LookupEntry(m_spellInfo->EffectRadiusIndex[i]));

					if (_SquareDistance (m_targets.m_destX, m_targets.m_destY, m_targets.m_destZ,
						o->GetPositionX(), o->GetPositionY(), o->GetPositionZ()) < rad * rad && 
						((Unit *)o)->GetFaction() != m_caster->GetFaction())
					{
						tmpMap.push_back (o->GetGUID());
					}
				}
				break;

			case EFF_TARGET_ALL_PARTY_AROUND_CASTER:
				pGroup = objmgr.GetGroupByLeader(p_caster->GetGroupLeader());
				for(uint32 p=0;p<pGroup->GetMembersCount();p++){
					Unit* Target = objmgr.GetObject<Player>(pGroup->GetMemberGUID(p));
					if(!Target || Target->GetGUID() == m_caster->GetGUID())
						continue;
					if (_CalcDistance (m_caster->GetPositionX(),
							m_caster->GetPositionY(),
							m_caster->GetPositionZ(),
							Target->GetPositionX(),
							Target->GetPositionY(),
							Target->GetPositionZ()) 
							< GetRadius(sSpellRadius.LookupEntry(m_spellInfo->EffectRadiusIndex[i])))
						tmpMap.push_back(Target->GetGUID());
				}
				break;

			case EFF_TARGET_SINGLE_FRIEND:
				tmpMap.push_back(m_targets.m_unitTarget);
				break;

			case EFF_TARGET_ALL_ENEMIES_AROUND_CASTER:
				//for( itr = m_caster->GetInRangeSetBegin(); itr != m_caster->GetInRangeSetEnd(); itr++ )
				for (MapRangeIterator itr (m_caster); o = itr.Advance(); )
				{
					if (o->isNotUnit() && o->isNotPlayer())
						continue;

					float rad = GetRadius (sSpellRadius.LookupEntry (m_spellInfo->EffectRadiusIndex[i]));

					if (_SquareDistance (m_caster->GetPositionX(), m_caster->GetPositionY(),
						m_caster->GetPositionZ(), o->GetPositionX(), o->GetPositionY(),
						o->GetPositionZ()) < rad * rad &&
						((Unit *)o)->GetFaction() != m_caster->GetFaction())
					{
						tmpMap.push_back (o->GetGUID());
					}
				}
				break;

			case EFF_TARGET_GAMEOBJECT:
				tmpMap.push_back (m_targets.m_unitTarget);
				break;

			case EFF_TARGET_IN_FRONT_OF_CASTER:
				Object *o;
				for (MapRangeIterator itr (m_caster); o = itr.Advance(); )
				{
					if (o->isNotUnit() && o->isNotPlayer())
						continue;

					if (m_caster->isInFront ((Unit *)o,
						GetRadius (sSpellRadius.LookupEntry (m_spellInfo->EffectRadiusIndex[i]))) &&
						((Unit *)o)->GetFaction() != m_caster->GetFaction())
					{
						tmpMap.push_back (o->GetGUID());
					}
				}
				break;

			case EFF_TARGET_DUEL:
				tmpMap.push_back(m_targets.m_unitTarget);
				break;

			case EFF_TARGET_GAMEOBJECT_ITEM:
				if(m_targets.m_unitTarget)
					tmpMap.push_back(m_targets.m_unitTarget);
				if(m_targets.m_itemTarget)
					tmpMap.push_back(m_targets.m_itemTarget);
				break;

			case EFF_TARGET_ALL_ENEMY_IN_AREA_CHANNELED: // (Blizzard/Rain of Fire/volley)
				//for( itr = m_caster->GetInRangeSetBegin(); itr != m_caster->GetInRangeSetEnd(); itr++ )
				for (MapRangeIterator itr (m_caster); o = itr.Advance(); )
				{
					if (o->isNotUnit() && o->isNotPlayer())
						continue;

					if (!((Unit*)o)->isAlive())
						continue;

					float rad = GetRadius(sSpellRadius.LookupEntry(m_spellInfo->EffectRadiusIndex[i]));

					if (_SquareDistance (m_targets.m_destX, m_targets.m_destY, m_targets.m_destZ,
						o->GetPositionX(), o->GetPositionY(), o->GetPositionZ()) < rad * rad &&
						((Unit *)o)->GetFaction() != m_caster->GetFaction())
					{
						tmpMap.push_back (o->GetGUID());
					}
				}
				break;

			case EFF_TARGET_MINION:
				{
					if(m_caster->GetUInt64Value(UNIT_FIELD_SUMMON) == 0)
					{
						tmpMap.push_back(m_caster->GetGUID());
					}
					else
					{
						tmpMap.push_back(m_caster->GetUInt64Value(UNIT_FIELD_SUMMON));
					}
				}
				break;

			case EFF_TARGET_SINGLE_PARTY:
				tmpMap.push_back(m_targets.m_unitTarget);
				break;

			case EFF_TARGET_CHAIN:
				firstTarget = objmgr.GetObject<Player>(m_targets.m_unitTarget);

				if(!firstTarget) firstTarget = objmgr.GetObject<Creature>(m_targets.m_unitTarget);
				if(!firstTarget) break;

				pGroup = objmgr.GetGroupByLeader(p_caster->GetGroupLeader());
				for(uint32 p=0;p<pGroup->GetMembersCount();p++){
					if(firstTarget->GetGUID() == pGroup->GetMemberGUID(p))
						onlyParty = true;
				}
				for(uint32 p=0;p<pGroup->GetMembersCount();p++) {
					Unit* Target = objmgr.GetObject<Player>(pGroup->GetMemberGUID(p));

					if(!Target || Target->GetGUID() == m_caster->GetGUID())
						continue;

					if (_CalcDistance (Target->GetPositionX(),
						Target->GetPositionY(),
						Target->GetPositionZ(),
						m_caster->GetPositionX(),
						m_caster->GetPositionY(),
						m_caster->GetPositionZ())
						< GetRadius(sSpellRadius.LookupEntry(m_spellInfo->EffectRadiusIndex[i])) &&
						Target->GetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE) == 
						m_caster->GetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE))
					{
						tmpMap.push_back(Target->GetGUID());
					}
				}
				break;

			case EFF_TARGET_CURRENT_SELECTION: // Target Area by Players CurrentSelection()
				Unit* Target = objmgr.GetObject<Creature>(p_caster->GetSelection());
				if(!Target)
					Target = objmgr.GetObject<Player>(p_caster->GetSelection());
				if(!Target)
					break;
				//for( itr = m_caster->GetInRangeSetBegin(); itr != m_caster->GetInRangeSetEnd(); itr++ )
				for (MapRangeIterator itr (m_caster); o = itr.Advance(); )
				{
					if (o->isNotUnit() && o->isNotPlayer())
						continue;

					float rad = GetRadius(sSpellRadius.LookupEntry(m_spellInfo->EffectRadiusIndex[i]));

					if (_SquareDistance (Target->GetPositionX(), Target->GetPositionY(),
						Target->GetPositionZ(), o->GetPositionX(), o->GetPositionY(),
						o->GetPositionZ()) < rad * rad &&
						((Unit *)o)->GetFaction() != m_caster->GetFaction())
					{
						tmpMap.push_back (o->GetGUID());
					}
				}
				break;
			}
		}
		if (i == 0) m_targetUnits1 = tmpMap;
		else if (i == 1) m_targetUnits2 = tmpMap;
		else if (i == 2) m_targetUnits3 = tmpMap;
		tmpMap.clear();
	}

	if (HasTargets == 0)
	{
		for(int k = 0; k < 3; k++)
		{
			if (m_spellInfo->Effect[k] == EFFECT_LEARN_SPELL)
			{
				tmpMap.push_back(m_targets.m_unitTarget);
				if (k == 0) m_targetUnits1 = tmpMap;
				else if (k == 1) m_targetUnits2 = tmpMap;
				else if (k == 2) m_targetUnits3 = tmpMap;
				tmpMap.clear();
			}
		}
	}
}

//-----------------------------------------------------------------------------
void Spell::prepare(SpellCastTargets * targets)
{
	uint32 uCastTime = 0;
	for(uint32 i = 0; i < sCastTime.GetNumRows(); i++)
	{
		if(sCastTime.LookupEntry(i)->ID == m_spellInfo->CastingTimeIndex)
		{
			uCastTime = sCastTime.LookupEntry(i)->CastTime;
			break;
		}
	}
	/*if(!uCastTime)
	{
		uCastTime = 0;
	}*/
	uint8 result = 0;

	WorldPacket data;

	m_targets = *targets;


	SendSpellStart();

	// Rename attribute isDispelable to isInstant?
	//if (m_spellInfo->isDispelable == 0)
	m_timer = uCastTime;
	//else
	//	m_timer = 0;

	m_spellState = SPELL_STATE_PREPARING;

	m_castPositionX = m_caster->GetPositionX();
	m_castPositionY = m_caster->GetPositionY();
	m_castPositionZ = m_caster->GetPositionZ();

	result = CanCast();

	if (result == 0)
		result = (uint8)Call_Spell_CanCast (m_spellInfo->Id, m_caster, m_caster);

	if (result != 0){
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

//-----------------------------------------------------------------------------
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

//-----------------------------------------------------------------------------
void Spell::cast()
{
	WorldPacket data;

	//bool Instant = true;
	bool meleeSpell = false;

	// Quite strange way to detect instant spells indeed :) Should redo this crap. /kvak
	for(uint32 i=0;i<=2;i++){
		if(m_spellInfo->Effect[i] == EFFECT_WEAPON_DAMAGE_ADD_NOSCHOOL ||
			m_spellInfo->Effect[i] == EFFECT_WEAPON_DAMAGE_ADD)
			meleeSpell = true;
	}

	if (!meleeSpell)
	{
		uint8 castResult = CanCast();
		//if (castResult == 0)
		//	castResult = Call_Spell_CanCast (m_spellInfo->Id, m_caster, m_caster);

		if (castResult == 0)
		{
			FillTargetMap();
			SendCastResult(castResult);
			SendSpellGo();
			SendLogExecute();

			if(m_spellInfo->ChannelInterruptFlags != 0){
				int32	duration;
				for (int i=0; i < (int)sSpellDuration.GetNumRows(); i++)
				{
					if(sSpellDuration.LookupEntry(i)->ID == m_spellInfo->DurationIndex)
					{
						duration = sSpellDuration.LookupEntry(i)->Duration1;
						i = sSpellDuration.GetNumRows();
					}
				}
				if(duration == NULL) duration = 0;
				m_spellState = SPELL_STATE_CASTING;
				SendChannelStart(duration);
			}

			for(uint32 j = 0;j<3;j++){
				if(m_spellInfo->Effect[j] == EFFECT_PERSISTENT_AREA_AURA)
					HandleEffects(m_caster->GetGUID(),j);
			}
			
			std::list<uint64>::iterator i;
			bool	tryScript = true;

			for (i = m_targetUnits1.begin(); i != m_targetUnits1.end(); i++)
			{
				//if (tryScript)
				//	tryScript &= Call_Spell_SpellEffect (m_spellInfo->Id, m_caster, Unit::WorldGetUnit (*i));
				HandleEffects ((*i), 0);
			}
			for (i = m_targetUnits2.begin(); i != m_targetUnits2.end(); i++)
			{
				//if (tryScript)
				//	tryScript &= Call_Spell_SpellEffect (m_spellInfo->Id, m_caster, Unit::WorldGetUnit (*i));
				HandleEffects ((*i), 1);
			}
			for (i = m_targetUnits3.begin(); i != m_targetUnits3.end(); i++)
			{
				//if (tryScript)
				//	tryScript &= Call_Spell_SpellEffect (m_spellInfo->Id, m_caster, Unit::WorldGetUnit (*i));
				HandleEffects ((*i), 2);
			}
			for (i = UniqueTargets.begin(); i != UniqueTargets.end(); i++)
			{
				if (tryScript)
					tryScript &= Call_Spell_SpellEffect (m_spellInfo->Id, m_caster, Unit::WorldGetUnit (*i));
				HandleAddAffect ((*i));
			}

			//TakePower();
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

//-----------------------------------------------------------------------------
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
			for(int i = 0; i < 3; i++)
			{
				if(m_spellInfo->Effect[i] == EFFECT_PERSISTENT_AREA_AURA)
				{
					if(m_spellInfo->Id == m_caster->GetUInt32Value(UNIT_CHANNEL_SPELL))
					{
						DynamicObject* dynObj = objmgr.GetObject<DynamicObject>(m_caster->GetUInt64Value(UNIT_FIELD_CHANNEL_OBJECT));
						if(dynObj)
						{
							dynObj->RemoveFromMap();
							objmgr.RemoveObject_Free(dynObj);
						}
						else
						{
							Log::getSingleton().outDebug("Dynamic Spellobject could not be found!");
						}
					}
				}
			}
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

//-----------------------------------------------------------------------------
void Spell::finish()
{
	WorldPacket data;

	m_spellState = SPELL_STATE_FINISHED;
	m_caster->m_meleeSpell = false;
}

//-----------------------------------------------------------------------------
void Spell::SendCastResult(uint8 result)
{
	if (m_caster->isNotPlayer())
		return;

	WorldPacket data;

	data.Initialize(SMSG_CAST_RESULT);
	data << m_spellInfo->Id;
	if(result != 0)
		data << uint8(2);
	data << result;
	((Player*)m_caster)->GetSession()->SendPacket(&data);
}

//-----------------------------------------------------------------------------
void Spell::SendSpellStart()
{
	uint32 uCastTime = 0;
	for(uint32 i = 0; i < sCastTime.GetNumRows(); i++)
	{
		if(sCastTime.LookupEntry(i)->ID == m_spellInfo->CastingTimeIndex)
		{
			uCastTime = sCastTime.LookupEntry(i)->CastTime;
			break;
		}
	}
	/*if(!uCastTime)
	{
		uCastTime = 0;
	}*/
	// Send Spell Start
	WorldPacket data;
	uint16 cast_flags;

	cast_flags = 2;

	data.Initialize(SMSG_SPELL_START);
	data << m_caster->GetGUID() << m_caster->GetGUID();
	data << m_spellInfo->Id;
	data << cast_flags;
	data << uCastTime;

	m_targets.write( &data );
	((Player*)m_caster)->SendMessageToSet(&data, true);

	/*
	data.Initialize(SMSG_SPELL_START);
	data << m_caster->GetGUID();
	data << uint32 (5000);
	((Player*)m_caster)->SendMessageToSet(&data, true);
	*/
}

//-----------------------------------------------------------------------------
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
	data << flags;
	//data << uint16(0x0500);
	writeSpellGoTargets(&data);

	data << (uint8)0;  // number of misses
	m_targets.write( &data );
	m_caster->SendMessageToSet(&data, true);
}

//-----------------------------------------------------------------------------
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

//-----------------------------------------------------------------------------
void Spell::SendLogExecute()
{
	WorldPacket data;
	data.Initialize(SMSG_SPELLLOGEXECUTE);
	data << m_caster->GetGUID();
	data << m_spellInfo->Id << uint32(0x00000001);
	data << uint64(0x0000000100000021LL); /*needs LL at the end */
	data << m_targets.m_unitTarget;
	m_caster->SendMessageToSet(&data,true);

	TakePower();
	if (m_caster->isPlayer()) {
		// After successful cast reset last cast time to NOW
		((Player *)m_caster)->m_lastCastTime = GetPreciseTime();
	}
};

//-----------------------------------------------------------------------------
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

//-----------------------------------------------------------------------------
void Spell::SendChannelUpdate(uint32 time)
{
	if (m_caster->isNotPlayer())
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

//-----------------------------------------------------------------------------
void Spell::SendChannelStart(uint32 duration)
{
	Unit* target = objmgr.GetObject<Creature>(((Player*)m_caster)->GetSelection());
	if(!target)
	{
		for(int i = 0; i < 3; i++)
		{
			if(m_spellInfo->Effect[i] == EFFECT_PERSISTENT_AREA_AURA)
			{
				target = objmgr.GetObject<Player>(((Player*)m_caster)->GetSelection());
				if(!target)
					target = m_caster;
			}
		}
	}
	if(!target)
		return;
	if (m_caster->isPlayer()){
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

//-----------------------------------------------------------------------------

void Spell::SendResurrectRequest(Player* target)
{
    WorldPacket data;
    data.Initialize(SMSG_RESURRECT_REQUEST);
    data << m_caster->GetGUID();
    data << uint32(0) << uint8(0);

    target->GetSession()->SendPacket(&data);
    return;
}

void Spell::TakePower()
{
	uint32 currentPower;

	uint8 powerType = m_caster->GetPowerIndex();
	uint16 powerField = UNIT_FIELD_POWER1 + powerType;

	currentPower = m_caster->GetUInt32Value(powerField);

	if(currentPower < m_spellInfo->manaCost)
		m_caster->SetUInt32Value (powerField, 0);
	else
		m_caster->SetUInt32Value (powerField, currentPower - m_spellInfo->manaCost);
}

//-----------------------------------------------------------------------------
void Spell::HandleEffects(uint64 guid,uint32 i)
{
	//Item* itemTarget;
	Unit		* unitTarget;
	GameObject	* gameObjTarget;
	Player		* playerTarget;
	WorldPacket	data;
	int32		duration;
	for (int i=0; i < (int)sSpellDuration.GetNumRows(); i++)
	{
		if(sSpellDuration.LookupEntry(i)->ID == m_spellInfo->DurationIndex)
		{
			duration = sSpellDuration.LookupEntry(i)->Duration1;
			i = sSpellDuration.GetNumRows();
		}
	}

	data.clear();

	unitTarget = objmgr.GetObject<Creature>(guid);

	if(!unitTarget)
		unitTarget = objmgr.GetObject<Player>(guid);

	//itemTarget = objmgr.GetObject<Item>(guid);
	gameObjTarget = objmgr.GetObject<GameObject>(guid);
	playerTarget = objmgr.GetObject<Player>(guid);

	//
	//--- Check some personal target requirements ------------
	//

	if (RequiresCasterBehindTarget (m_spellInfo->Id))
	{
		// Should be not in front, and not targeted by victim
		if (unitTarget != NULL && (unitTarget->isInFront (m_caster, 99) || 
			unitTarget->GetTarget() == m_caster->GetGUID()))
		{
			SendCastResult (CAST_FAIL_NOT_BEHIND_TARGET);
			return;
		}
		// Should be not in front, and not targeted by victim
		if (playerTarget != NULL && (playerTarget->isInFront (m_caster, 99) || 
			playerTarget->GetTarget() == m_caster->GetGUID()))
		{
			SendCastResult (CAST_FAIL_NOT_BEHIND_TARGET);
			return;
		}
	}

	//
	//--- Start processing effects ---------------------------
	//
	switch(m_spellInfo->Effect[i])
	{
	case EFFECT_SCHOOL_DAMAGE: {
		if(!unitTarget) break;
		if(!unitTarget->isAlive()) break;

		uint32 baseDamage = m_spellInfo->EffectBasePoints[i];

		if (m_caster->GetPowerIndex() == POWER_TYPE_ENERGY && // Energy
			AbilityRequiresComboPoints (m_spellInfo->Id) &&
			m_caster->GetUInt64Value (PLAYER__FIELD_COMBO_TARGET) != 0)
		{
			baseDamage = int32 (m_spellInfo->Effectunknown2[i] * m_caster->GetComboPoints());
			
			m_caster->SetComboPoints(0);
			m_caster->SetUInt64Value (PLAYER__FIELD_COMBO_TARGET, 0);
		} 
		//else break;

		uint32 randomDamage = rand()%m_spellInfo->EffectDieSides[i];
		uint32 damage = baseDamage+randomDamage;

		m_caster->SpellNonMeleeDamageLog(unitTarget, m_spellInfo->Id, damage);
		break; }

	case EFFECT_DUMMY:   // Dummy
		break;

	case EFFECT_TELEPORT_UNITS:
		 // Hearthstone !
		 if (( m_spellInfo->Id == 8690 ) && (playerTarget) )
		 {
			 if ( playerTarget->GetMapId() == playerTarget->m_bindPointMap )
				 playerTarget->TeleportNear(
					 playerTarget->m_bindPointX,
					 playerTarget->m_bindPointY,
					 playerTarget->m_bindPointZ ); else
				playerTarget->TeleportFar( playerTarget->m_bindPointMap, 
					 playerTarget->m_bindPointX,
					 playerTarget->m_bindPointY,
					 playerTarget->m_bindPointZ );
		 }

		break;
	case EFFECT_APPLY_AURA: {  // Apply Aura
		if(!unitTarget)
			break;
		if(!unitTarget->isAlive())
			break;

		if(unitTarget->tmpAffect == 0){
			//duration = GetDuration(sSpellDuration.LookupEntry(m_spellInfo->DurationIndex));
			Affect* aff = new Affect (m_spellInfo, duration, m_caster->GetGUID());
			unitTarget->tmpAffect = aff;
		}

		uint32 value = 0;
		uint32 type = 0;
		uint32 damage = 0;
		
		if(m_spellInfo->EffectBasePoints[i] < 0){
			unitTarget->tmpAffect->SetNegative();
			type = 1;
		}

		uint32 sBasePoints = (uint32)fabs ( (float)m_spellInfo->EffectBasePoints[i] +
			m_caster->GetLevel() * m_spellInfo->EffectRealPointsPerLevel[i] );

		// Periodic Trigger Damage
		if(m_spellInfo->EffectApplyAuraName[i] == SPELL_AURA_PERIODIC_DAMAGE) {
			damage = m_spellInfo->EffectBasePoints[i]+rand()%m_spellInfo->EffectDieSides[i]+1;
			
			unitTarget->tmpAffect->SetDamagePerTick ((uint16)damage, m_spellInfo->EffectAmplitude[i]);
			unitTarget->tmpAffect->SetNegative();
		}
		else 
		// Periodic Trigger Spell
		if(m_spellInfo->EffectApplyAuraName[i] == SPELL_AURA_PERIODIC_TRIGGER_SPELL)
			unitTarget->tmpAffect->SetPeriodicTriggerSpell(m_spellInfo->EffectTriggerSpell[i],m_spellInfo->EffectAmplitude[i]);
		else{
			if(m_spellInfo->EffectDieSides[i] != 0)
				value = sBasePoints+rand()%m_spellInfo->EffectDieSides[i];
			else
				value = sBasePoints;
			if(m_spellInfo->EffectDieSides[i] <= 1)
				value += 1;
			unitTarget->tmpAffect->AddMod ((uint8)m_spellInfo->EffectApplyAuraName[i],
				value, m_spellInfo->EffectMiscValue[i] ,type);
		}
		break; }

	case EFFECT_POWER_DRAIN: {
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
		break; }

	case EFFECT_HEAL: {
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
		break; }

	case EFFECT_WEAPON_DAMAGE_ADD_NOSCHOOL: {
		if(!unitTarget) break;
		if(!unitTarget->isAlive()) break;

		uint32 baseDamage = m_spellInfo->EffectBasePoints[i];
		uint32 randomDamage = rand()%m_spellInfo->EffectDieSides[i];
		uint32 damage = baseDamage+randomDamage;
		
		m_caster->m_addDmgOnce = damage;
		m_caster->m_addDmgOnceSpell = m_spellInfo->Id;
		break; }

	case EFFECT_WEAPON_DMG_PERCENT: {
		if(!unitTarget) break;
		if(!unitTarget->isAlive()) break;

		m_caster->m_amplifyDmgOnce = float(m_spellInfo->EffectBasePoints[i]) * 0.01f;
		m_caster->m_amplifyDmgOnceSpell = m_spellInfo->Id;
		break; }

	case EFFECT_CREATE_ITEM: { 
		// NEEDS TO BE REDONE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		Player* pUnit = (Player*)m_caster;
		uint8 slot = 0;
		for(uint8 i=INVENTORY_SLOT_ITEM_START;i<INVENTORY_SLOT_ITEM_END;i++){// check if there is a free slot for the item to conjure
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
				curSlot = (uint8)pUnit->GetSlotByItemID(m_spellInfo->Reagent[i]);
				if(curSlot == 0)
					continue;
				pItem = new Item;
				pItem = pUnit->GetItemBySlot(curSlot);
				
				// if there are more then 1 in stack then just reduce it by 1
				if(pItem->GetUInt32Value(ITEM_FIELD_STACK_COUNT) > 1){ 
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
			// check if there is a free slot for the item to conjure
			for (uint8 i = INVENTORY_SLOT_ITEM_START; i<INVENTORY_SLOT_ITEM_END;i++){
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
		break; }

	case EFFECT_PERSISTENT_AREA_AURA: { // Persistent Area Aura
		if(m_AreaAura == true)
			break;

		m_AreaAura = true;
		// Spawn dyn GameObject
		DynamicObject* dynObj = new DynamicObject();
		dynObj->Create(objmgr.GenerateLowGuid(HIGHGUID_DYNAMICOBJECT), m_caster,
			m_spellInfo, m_targets.m_destX, m_targets.m_destY, m_targets.m_destZ,
			duration);
		uint32 damage = m_spellInfo->EffectBasePoints[i]+1;

		dynObj->PeriodicTriggerDamage (damage, m_spellInfo->EffectAmplitude[i],
			GetRadius(sSpellRadius.LookupEntry(m_spellInfo->EffectRadiusIndex[i])));

		objmgr.AddObject(dynObj);
		dynObj->PlaceOnMap();
		m_caster->SetUInt64Value(UNIT_FIELD_CHANNEL_OBJECT, dynObj->GetGUID());
		m_caster->SetUInt32Value(UNIT_CHANNEL_SPELL, m_spellInfo->Id);
		break; }

	case EFFECT_SUMMON_PET: {
		if(m_caster->GetUInt64Value(UNIT_FIELD_SUMMON) != 0)//If there is already a summon
		{
			Creature *OldSummon = objmgr.GetObject<Creature>(m_caster->GetUInt64Value(UNIT_FIELD_SUMMON));
			if(!OldSummon)
			{
				m_caster->SetUInt64Value(UNIT_FIELD_SUMMON, 0);
				Log::getSingleton().outError("Warning!Old Summon could not be found!");
			}
			else
			{
				data.clear();
				data.Initialize(SMSG_DESTROY_OBJECT);
				data << OldSummon->GetGUID();
				OldSummon->SendMessageToSet (&data, true);

				//for (ObjectSet::iterator it = OldSummon->GetInRangeSetBegin(); it != OldSummon->GetInRangeSetEnd(); it++)
				//Object *o;
				//for (MapRangeIterator itr (m_caster); o = itr.Advance(); )
				//	o->RemoveInRangeObject (OldSummon);

				if (OldSummon->GetMapCell()) 
				{
					OldSummon->GetMapCell()->RemoveObject (OldSummon);
//					OldSummon->GetMapCell()->RemoveInactive (OldSummon);
				}

				OldSummon->RemoveFromMap();
				OldSummon->RemoveFromWorld();
				OldSummon->DeleteFromDB();

				objmgr.RemoveObject_Free(OldSummon);
			}
		}
		//Create new summon
		Creature *NewSummon = new Creature();
		CreatureTemplate *SummonInfo = objmgr.GetCreatureTemplate(m_spellInfo->EffectMiscValue[i]);
		if(SummonInfo == NULL)
		{
			Log::getSingleton().outError("No Minion found for CreatureTemplate %u", m_spellInfo->EffectMiscValue[i]);
			break;
		}
		NewSummon->Create(objmgr.GenerateLowGuid(HIGHGUID_UNIT), SummonInfo->Name.c_str(), m_caster->GetMapId(), m_caster->GetPositionX(), m_caster->GetPositionY(), m_caster->GetPositionZ(), m_caster->GetOrientation());
		NewSummon->SetLevel(m_caster->GetLevel());
		NewSummon->SetUInt32Value(UNIT_FIELD_DISPLAYID, SummonInfo->Model);
		NewSummon->SetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID, SummonInfo->Model);
		NewSummon->SetUInt64Value(UNIT_FIELD_SUMMONEDBY, m_caster->GetGUID());
		NewSummon->SetUInt32Value(UNIT_NPC_FLAGS , 0);
		NewSummon->SetUInt32Value(UNIT_FIELD_HEALTH , 28 + 30 * m_caster->GetLevel());
		NewSummon->SetUInt32Value(UNIT_FIELD_MAXHEALTH , 28 + 30 * m_caster->GetLevel());
		NewSummon->SetFaction(m_caster->GetFaction());
		NewSummon->SetScale( SummonInfo->Size );
		NewSummon->SetUInt32Value(UNIT_FIELD_BYTES_0,2048); 
		NewSummon->SetUInt32Value(UNIT_FIELD_FLAGS,0);
		NewSummon->SetUInt32Value(UNIT_FIELD_BASEATTACKTIME, SummonInfo->Attack[0]); 
		NewSummon->SetUInt32Value(UNIT_FIELD_BASEATTACKTIME+1, SummonInfo->Attack[1]); 
		NewSummon->SetUInt32Value(UNIT_FIELD_BOUNDINGRADIUS, SummonInfo->BoundingRadius); 
		NewSummon->SetUInt32Value(UNIT_FIELD_COMBATREACH, SummonInfo->CombatReach); 
		NewSummon->SetMinDamage((float)SummonInfo->Damage[0]); 
		NewSummon->SetMaxDamage((float)SummonInfo->Damage[1]);
		NewSummon->SetUInt32Value(UNIT_FIELD_BYTES_1,0); 
		NewSummon->SetUInt32Value(UNIT_FIELD_PETNUMBER, NewSummon->GetGUIDLow()); 
		NewSummon->SetUInt32Value(UNIT_FIELD_PET_NAME_TIMESTAMP,5); 
		NewSummon->SetUInt32Value(UNIT_FIELD_PETEXPERIENCE,0); 
		NewSummon->SetUInt32Value(UNIT_FIELD_PETNEXTLEVELEXP,1000); 
		NewSummon->SetUInt32Value(UNIT_CREATED_BY_SPELL, m_spellInfo->Id); 
		NewSummon->SetUInt32Value(UNIT_FIELD_STAT0,22);
	    NewSummon->SetUInt32Value(UNIT_FIELD_STAT1,22); //////////TODO: GET THE RIGHT INFORMATIONS FOR THIS!!!
	    NewSummon->SetUInt32Value(UNIT_FIELD_STAT2,25); 
	    NewSummon->SetUInt32Value(UNIT_FIELD_STAT3,28); 
	    NewSummon->SetUInt32Value(UNIT_FIELD_STAT4,27); 
	    NewSummon->SetUInt32Value(UNIT_FIELD_RESISTANCES+0,0); 
	    NewSummon->SetUInt32Value(UNIT_FIELD_RESISTANCES+1,0); 
	    NewSummon->SetUInt32Value(UNIT_FIELD_RESISTANCES+2,0); 
	    NewSummon->SetUInt32Value(UNIT_FIELD_RESISTANCES+3,0); 
	    NewSummon->SetUInt32Value(UNIT_FIELD_RESISTANCES+4,0); 
	    NewSummon->SetUInt32Value(UNIT_FIELD_RESISTANCES+5,0); 
	    NewSummon->SetUInt32Value(UNIT_FIELD_RESISTANCES+6,0); 
	    NewSummon->SetUInt32Value(UNIT_FIELD_ATTACKPOWER,24);
		NewSummon->SetUInt32Value(UNIT_FIELD_BASE_MANA, SummonInfo->MaxMana); 
		NewSummon->SetUInt32Value(OBJECT_FIELD_ENTRY, SummonInfo->Entry);
		NewSummon->SetPosition(m_caster->GetPositionX(), m_caster->GetPositionY(), m_caster->GetPositionZ(), m_caster->GetOrientation());
		NewSummon->SetZoneId(m_caster->GetZoneId());

		NewSummon->SaveToDB();

		objmgr.AddObject( NewSummon );
		NewSummon->PlaceOnMap();
		NewSummon->AddToWorld();

		m_caster->SetUInt64Value(UNIT_FIELD_SUMMON, NewSummon->GetGUID());
		Log::getSingleton().outDebug("New Pet has guid %u", NewSummon->GetGUID());

		if(objmgr.GetObject<Player>(m_caster->GetGUID()) )//if the caster is a player
		{
			data.clear();
			data.Initialize(SMSG_PET_SPELLS);
			data << (uint64)NewSummon->GetGUID() << uint32(0x00000101) << uint32(0x00000000) << uint32(0x07000001) << uint32(0x07000002);
			data << uint32(0x02000000) << uint32(0x07000000) << uint32(0x04000000) << uint32(0x03000000) << uint32(0x06000002) << uint32(0x05000000);
			data << uint32(0x06000000) << uint32(0x06000001) << uint8(0x02)/*Number of spells*/ << uint32(0x0c26)/*SpellID1*/ << uint32(0x18a3)/*SpellID2*/;
			((Player*)m_caster)->GetSession()->SendPacket(&data);
		}
		break; }

	case EFFECT_ENERGIZE: {  // Energize
		if(!unitTarget)
			break;
		if(!unitTarget->isAlive())
			break;
		uint32 POWER_TYPE;

		switch(m_spellInfo->EffectMiscValue[i])
		{
		case 0: POWER_TYPE = UNIT_FIELD_POWER1; break;
		case 1: POWER_TYPE = UNIT_FIELD_POWER2; break;
		case 2: POWER_TYPE = UNIT_FIELD_POWER3; break;
		case 3: POWER_TYPE = UNIT_FIELD_POWER4; break;
		case 4: POWER_TYPE = UNIT_FIELD_POWER5; break;
		}

		uint32 energize;
		uint32 baseEnergize = m_spellInfo->EffectBasePoints[i];
		uint32 randomEnergize = rand()%m_spellInfo->EffectDieSides[i];
		energize = baseEnergize+randomEnergize;
		if(POWER_TYPE == UNIT_FIELD_POWER2)
			energize = energize*10;

		uint32 curEnergy = unitTarget->GetUInt32Value (POWER_TYPE);
		uint32 maxEnergy = unitTarget->GetUInt32Value (POWER_TYPE+6);
		
		if(curEnergy+energize > maxEnergy)
			unitTarget->SetUInt32Value (POWER_TYPE, maxEnergy);
		else
			unitTarget->SetUInt32Value (POWER_TYPE, curEnergy+energize);
		break; }

	case EFFECT_OPEN_LOCK: {
		if(!gameObjTarget || !playerTarget)
			break;

		data.clear();
		data.Initialize(SMSG_LOOT_RESPONSE);
		gameObjTarget->FillLoot(&data);
		playerTarget->SetLootGUID(m_targets.m_unitTarget);
		playerTarget->GetSession()->SendPacket(&data);
		break; }

	case EFFECT_APPLY_AREA_AURA: {
		if(!unitTarget)
			break;
		if(!unitTarget->isAlive())
			break;

		if(m_spellInfo->Attributes == 0x09050000){   // Pally Auras
			Affect* aff = new Affect(m_spellInfo,6000,m_caster->GetGUID());
			
			aff->AddMod ((uint8)m_spellInfo->EffectApplyAuraName[i],
				m_spellInfo->EffectBasePoints[i]+rand()%m_spellInfo->EffectDieSides[i],
				m_spellInfo->EffectMiscValue[i], 0);

			unitTarget->SetAura(aff);
		}
		break; }

	case EFFECT_LEARN_SPELL: {
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
		///////////Learn animation start//////////////
		if(playerTarget->AddSpell(spellToLearn))
		{
			data.Initialize (SMSG_LEARNED_SPELL);
			data << (uint32)spellToLearn;
			playerTarget->GetSession()->SendPacket( &data );
	
			Make_SMSG_SPELL_GO (&data, 476, m_caster, playerTarget);
			m_caster->SendMessageToSet (&data, true);
		}
		///////////Learn animation end////////////////
		break; }

	case EFFECT_SUMMON_WILD: {
		if(!playerTarget)
	            return;

	        CreatureTemplate *ct;
        	ct = objmgr.GetCreatureTemplate(m_spellInfo->EffectMiscValue[i]);
	        if(!ct){
	            printf("unknown entry ID. return\n");
	            return;
	        }
	
	        uint32 level = m_caster->GetLevel();
	        Creature* spawnCreature = new Creature();
	        spawnCreature->Create(objmgr.GenerateLowGuid(HIGHGUID_UNIT),ct->Name.c_str(),m_caster->GetMapId(),m_caster->GetPositionX(),m_caster->GetPositionY(),m_caster->GetPositionZ(),m_caster->GetOrientation());
	        spawnCreature->SetUInt32Value(UNIT_FIELD_DISPLAYID, ct->Model);
			spawnCreature->SetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID, ct->Model);
	        spawnCreature->SetUInt32Value(UNIT_NPC_FLAGS , 0);
	        spawnCreature->SetUInt32Value(UNIT_FIELD_HEALTH, 28 + 30*level);
	        spawnCreature->SetUInt32Value(UNIT_FIELD_MAXHEALTH, 28 + 30*level);
	        spawnCreature->SetUInt32Value(UNIT_FIELD_LEVEL , level);
	        spawnCreature->SetUInt32Value(OBJECT_FIELD_TYPE, ct->Type);
	
	        objmgr.AddObject(spawnCreature);
	        spawnCreature->PlaceOnMap();
		break; }
	
	case EFFECT_ENCHANT_ITEM_PERMANENT: {
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
		break; }

	case EFFECT_ENCHANT_ITEM_TEMPORARY: {
		Player* p_caster = (Player*)m_caster;
		//uint32 duration = GetDuration(sSpellDuration.LookupEntry(m_spellInfo->DurationIndex));
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
		break; }

	case EFFECT_WEAPON_DAMAGE_ADD: {
		if(!unitTarget)
			break;
		if(!unitTarget->isAlive())
			break;

		uint32 baseDamage = m_spellInfo->EffectBasePoints[i];
		uint32 randomDamage = rand() % m_spellInfo->EffectDieSides[i];
		uint32 damage = baseDamage + randomDamage;
		unitTarget->m_addDmgOnce = damage;
		break; }

	case EFFECT_TRIGGER_SPELL:
		TriggerSpellId = m_spellInfo->EffectTriggerSpell[i];
		break;

	case EFFECT_HEAL_MAX_HEALTH: {
		if(!unitTarget) break;
		if(!unitTarget->isAlive()) break;

		uint32 heal;
		heal = m_caster->GetUInt32Value(UNIT_FIELD_MAXHEALTH);

		uint32 curHealth = unitTarget->GetUInt32Value(UNIT_FIELD_HEALTH);
		uint32 maxHealth = unitTarget->GetUInt32Value(UNIT_FIELD_MAXHEALTH);
		if(curHealth+heal > maxHealth)
			unitTarget->SetUInt32Value(UNIT_FIELD_HEALTH,maxHealth);
		else
			unitTarget->SetUInt32Value(UNIT_FIELD_HEALTH,curHealth+heal);
		break; }

	case EFFECT_INTERRUPT_CAST: {
		if(!unitTarget) break;
		if(!unitTarget->isAlive()) break;

		unitTarget->InterruptSpell();
		break; }

	case EFFECT_ADD_COMBO_POINTS: {
		if(!unitTarget)
	            return;
        	uint8 comboPoints = m_caster->GetComboPoints(); //((m_caster->GetUInt32Value(PLAYER_FIELD_BYTES) & 0xFF00) >> 8);
	        if(m_caster->GetUInt64Value(PLAYER__FIELD_COMBO_TARGET) != unitTarget->GetGUID()){
	            m_caster->SetUInt64Value(PLAYER__FIELD_COMBO_TARGET,unitTarget->GetGUID());
	            //m_caster->SetUInt32Value(PLAYER_FIELD_BYTES,((m_caster->GetUInt32Value(PLAYER_FIELD_BYTES) & ~(0xFF << 8)) | (0x01 << 8)));
				m_caster->SetComboPoints (1);
	        }else{
	            if(comboPoints < 5){
	                comboPoints += 1;
	                //m_caster->SetUInt32Value(PLAYER_FIELD_BYTES,((m_caster->GetUInt32Value(PLAYER_FIELD_BYTES) & ~(0xFF << 8)) | (comboPoints << 8)));
					m_caster->SetComboPoints (comboPoints);
	            }
	        }
		break; }

	case EFFECT_DUEL: {
		Log::getSingleton().outDebug("Duel requested");
		if(m_caster->isNotPlayer())
			return;
		Log::getSingleton().outDebug("Duel caster is a player");
		if(!playerTarget)
			return;
		Log::getSingleton().outDebug("Duel target is a player");

		GameObject* pDuelArbiter = new GameObject();
		pDuelArbiter->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT),
		787,
		1,					// uint8 state
		21680,				// uint32 obj_field_entry
		1,				// uint8 scale
		16,				// uint16 type
		0,			// uint16 faction
		m_caster->GetMapId(), m_caster->GetPositionX(), m_caster->GetPositionY(), m_caster->GetPositionZ(), m_caster->GetOrientation());
		objmgr.AddObject(pDuelArbiter);
		pDuelArbiter->PlaceOnMap();
		Log::getSingleton().outDebug("Duel Arbiter created");

		data.clear();
		data.Initialize(SMSG_DUEL_REQUESTED);
		data << pDuelArbiter->GetGUID();
		data << m_caster->GetGUID();
		((Player*)m_caster)->GetSession()->SendPacket(&data);
		((Player*)m_caster)->SetUInt64Value(PLAYER_DUEL_ARBITER, pDuelArbiter->GetGUID());
		Log::getSingleton().outDebug("Duel Request sent to caster");

		data.clear();
		data.Initialize(SMSG_DUEL_REQUESTED);
		data << pDuelArbiter->GetGUID();
		data << m_caster->GetGUID();
		playerTarget->GetSession()->SendPacket(&data);
		playerTarget->SetUInt64Value(PLAYER_DUEL_ARBITER, pDuelArbiter->GetGUID());
		Log::getSingleton().outDebug("Duel Request sent to target");


		data.clear();
		data.Initialize(SMSG_GAMEOBJECT_SPAWN_ANIM);
		data << pDuelArbiter->GetGUID();
		((Player*)m_caster)->SendMessageToSet(&data,true);
		Log::getSingleton().outDebug("Duel Arbiter spawn animation sent");
		break; }

	case EFFECT_SUMMON_TOTEM_SLOT1:
	case EFFECT_SUMMON_TOTEM_SLOT2:
	case EFFECT_SUMMON_TOTEM_SLOT3:
	case EFFECT_SUMMON_TOTEM_SLOT4: {
		uint64 guid = 0;
		// delete old summoned object
		if(m_spellInfo->Effect[i] == EFFECT_SUMMON_TOTEM_SLOT1){
			guid = m_caster->m_TotemSlot1;
			m_caster->m_TotemSlot1 = 0;
		}else if(m_spellInfo->Effect[i] == EFFECT_SUMMON_TOTEM_SLOT2){
			guid = m_caster->m_TotemSlot2;
			m_caster->m_TotemSlot2 = 0;
		}else if(m_spellInfo->Effect[i] == EFFECT_SUMMON_TOTEM_SLOT3){
			guid = m_caster->m_TotemSlot3;
			m_caster->m_TotemSlot3 = 0;
		}else if(m_spellInfo->Effect[i] == EFFECT_SUMMON_TOTEM_SLOT4){
			guid = m_caster->m_TotemSlot4;
			m_caster->m_TotemSlot4 = 0;
		}
		if(guid != 0)
		{
			Creature* Totem;
			Totem = objmgr.GetObject<Creature>(guid);
			if(Totem){
				Totem->RemoveFromMap();
				objmgr.RemoveObject_Free(Totem);	// Check if here bug with that _Free or not ?
			}
		}

		// spawn a new one
		Creature* pTotem = new Creature();
		
		// need to set it via m_spellInfo
		uint16 display_id = (uint16)m_spellInfo->EffectMiscValue[i];
		char* name = "need to fix this";

		// uint32 guidlow, uint16 display_id, uint8 state, uint32 obj_field_entry, uint8 scale, uint16 type, uint16 faction,  float x, float y, float z, float ang
		pTotem->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), name, m_caster->GetMapId(), m_caster->GetPositionX(), m_caster->GetPositionY(), m_caster->GetPositionZ(), m_caster->GetOrientation() );
		pTotem->SetUInt32Value(OBJECT_FIELD_TYPE,33);
		pTotem->SetLevel (m_caster->GetLevel());
		objmgr.AddObject(pTotem);
		pTotem->PlaceOnMap();

		data.Initialize(SMSG_GAMEOBJECT_SPAWN_ANIM);
		data << pTotem->GetGUID();
		m_caster->SendMessageToSet(&data,true);

		if(m_spellInfo->Effect[i] == EFFECT_SUMMON_TOTEM_SLOT1)
			m_caster->m_TotemSlot1 = pTotem->GetGUID();
		else if(m_spellInfo->Effect[i] == EFFECT_SUMMON_TOTEM_SLOT2)
			m_caster->m_TotemSlot2 = pTotem->GetGUID();
		else if(m_spellInfo->Effect[i] == EFFECT_SUMMON_TOTEM_SLOT3)
			m_caster->m_TotemSlot3 = pTotem->GetGUID();
		else if(m_spellInfo->Effect[i] == EFFECT_SUMMON_TOTEM_SLOT4)
			m_caster->m_TotemSlot4 = pTotem->GetGUID();
		break; }

	case EFFECT_ENCHANT_HELD_ITEM:
		break;

	case EFFECT_FEED_PET:
		TriggerSpellId = m_spellInfo->EffectTriggerSpell[i];
		break;

	case EFFECT_SUMMON_OBJECT_SLOT1:
	case EFFECT_SUMMON_OBJECT_SLOT2:
	case EFFECT_SUMMON_OBJECT_SLOT3:
	case EFFECT_SUMMON_OBJECT_SLOT4: {
		uint64 guid = 0;
		// delete old summoned object
		if(m_spellInfo->Effect[i] == EFFECT_SUMMON_OBJECT_SLOT1){
			guid = m_caster->m_TotemSlot1;
			m_caster->m_TotemSlot1 = 0;
		}else if(m_spellInfo->Effect[i] == EFFECT_SUMMON_OBJECT_SLOT2){
			guid = m_caster->m_TotemSlot2;
			m_caster->m_TotemSlot2 = 0;
		}else if(m_spellInfo->Effect[i] == EFFECT_SUMMON_OBJECT_SLOT3){
			guid = m_caster->m_TotemSlot3;
			m_caster->m_TotemSlot3 = 0;
		}else if(m_spellInfo->Effect[i] == EFFECT_SUMMON_OBJECT_SLOT4){
			guid = m_caster->m_TotemSlot4;
			m_caster->m_TotemSlot4 = 0;
		}
		if(guid != 0)
		{
			GameObject* obj;
			obj = objmgr.GetObject<GameObject>(guid);
			if(obj){
				obj->RemoveFromMap();
				objmgr.RemoveObject_Free(obj);	// check for possible bug with _Free()
			}
		}

		// spawn a new one
		GameObject* pGameObj = new GameObject();
		uint16 display_id = (uint16)m_spellInfo->EffectMiscValue[i];

		// uint32 guidlow, uint16 display_id, uint8 state, uint32 obj_field_entry, uint8 scale, uint16 type, uint16 faction,  float x, float y, float z, float ang
		pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), display_id, 1, m_spellInfo->EffectMiscValue[i], 1, 6, 6, m_caster->GetMapId(), m_caster->GetPositionX(), m_caster->GetPositionY(), m_caster->GetPositionZ(), m_caster->GetOrientation() );
		pGameObj->SetUInt32Value(OBJECT_FIELD_TYPE,33);
		pGameObj->SetUInt32Value(GAMEOBJECT_LEVEL,m_caster->GetLevel());
		objmgr.AddObject(pGameObj);
		pGameObj->PlaceOnMap();

		data.Initialize(SMSG_GAMEOBJECT_SPAWN_ANIM);
		data << pGameObj->GetGUID();
		m_caster->SendMessageToSet(&data,true);

		if(m_spellInfo->Effect[i] == EFFECT_SUMMON_OBJECT_SLOT1)
			m_caster->m_TotemSlot1 = pGameObj->GetGUID();
		else if(m_spellInfo->Effect[i] == EFFECT_SUMMON_OBJECT_SLOT2)
			m_caster->m_TotemSlot2 = pGameObj->GetGUID();
		else if(m_spellInfo->Effect[i] == EFFECT_SUMMON_OBJECT_SLOT3)
			m_caster->m_TotemSlot3 = pGameObj->GetGUID();
		else if(m_spellInfo->Effect[i] == EFFECT_SUMMON_OBJECT_SLOT4)
			m_caster->m_TotemSlot4 = pGameObj->GetGUID();
		break; }

	case EFFECT_RESURRECT_FLAT: {
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
		break; }
	
	default:
		//PLAYER_TRACK_CREATURES 2^X
		Log::getSingleton( ).outError("SPELL: unknown effect %d spell id %i\n",
		m_spellInfo->Effect[i], m_spellInfo->Id);
		break;
	}
}

//-----------------------------------------------------------------------------
void Spell::HandleAddAffect(uint64 guid)
{
	Unit* Target = objmgr.GetObject<Creature>(guid);
	
	if (Target == NULL)
		Target = objmgr.GetObject<Player>(guid);
	
	if (Target == NULL) 
		return;
	
	if (Target->isDead())
		return;

	if(Target->tmpAffect != 0)
	{
		Target->AddAffect (Target->tmpAffect);
		Target->tmpAffect = 0;
	}
}

//-----------------------------------------------------------------------------
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

		Spell *spell = new Spell(m_caster, spellInfo, false, 0);
		WPAssert(spell);

		SpellCastTargets targets;
		targets.m_unitTarget = m_targets.m_unitTarget;

		spell->prepare(&targets);
	}
}

//-----------------------------------------------------------------------------
uint8 Spell::CanCast()
{
	uint8 castResult = 0;
	float fSpellRange=0;
	for (int i=0; i < (int)sSpellRange.GetNumRows(); i++)
	{
		if(sSpellRange.LookupEntry(i)->ID == m_spellInfo->rangeIndex)
		{
			fSpellRange = sSpellRange.LookupEntry(i)->Range;
			i = sSpellRange.GetNumRows();
		}
	}
	//static uint8 _reply = CAST_FAIL_FAILED_ATTEMPT;
	Unit* target = objmgr.GetObject<Creature>(m_targets.m_unitTarget);
	
	if (!target)
		target = objmgr.GetObject<Player>(m_targets.m_unitTarget);
	
	if (target){
		//if (m_spellInfo->CheckFlags & FLAG_CHECK_HIGH_LEVEL) {
		//	if (m_caster->GetUInt32Value (UNIT_FIELD_LEVEL) + 4 < target->GetUInt32Value (UNIT_FIELD_LEVEL)) {
		//		castResult = CAST_FAIL_TARGET_IS_TOO_HIGH;
		//	}
		//}

		//if (m_spellInfo->CheckFlags & FLAG_CHECK_TARGET_TYPE) {
			//if (1 << target->GetUInt32Value (UNIT_FIELD_))
		//}

		if (!castResult && m_caster != target && 
			!m_caster->isInFront (target, fSpellRange))
		{	// Target needs to be in Front of you
			castResult = CAST_FAIL_TARGET_NEED_TO_BE_INFRONT;
		}

		if (!castResult && _CalcDistance (m_caster->GetPositionX(),
			m_caster->GetPositionY(),
			m_caster->GetPositionZ(),
			target->GetPositionX(),
			target->GetPositionY(),
			target->GetPositionZ()) > fSpellRange) 
		{	// Target out of Range
			castResult = CAST_FAIL_OUT_OF_RANGE;
		}
	}

	if (!castResult && m_targets.m_destX != 0 && m_targets.m_destY != 0  && m_targets.m_destZ != 0 ){
		if (_CalcDistance (m_caster->GetPositionX(),
			m_caster->GetPositionY(),
			m_caster->GetPositionZ(),
			m_targets.m_destX,
			m_targets.m_destY,
			m_targets.m_destZ) > fSpellRange)
		{	// Target out of Range
			castResult = CAST_FAIL_OUT_OF_RANGE;
		}
	}

	if (m_caster->m_silenced) castResult = CAST_FAIL_SILENCED;
	if (m_caster->isStunned()) castResult = CAST_FAIL_CANT_DO_WHILE_STUNNED;

	if((castResult != 0) && //Look if this is a Trainer teaching a player a spell:
		m_spellInfo->Effect[0] == EFFECT_LEARN_SPELL && 
			(m_spellInfo->EffectImplicitTargetA[0] == 0 &&
			m_spellInfo->EffectImplicitTargetA[1] == 0 &&
			m_spellInfo->EffectImplicitTargetA[2] == 0 &&
			m_spellInfo->EffectImplicitTargetB[0] == 0 &&
			m_spellInfo->EffectImplicitTargetB[1] == 0 &&
			m_spellInfo->EffectImplicitTargetB[2] == 0
			)
		)
	{
		castResult = 0;
	}

	if (castResult != 0) 
		SendCastResult(castResult);

	return castResult;
}

//-----------------------------------------------------------------------------
void Spell::DelaySpell(uint32 delay)
{
	if((m_spellState == SPELL_STATE_PREPARING) && (m_timer) && (m_timer > 0))
	{
		m_timer += delay;
	}
}

//--- END ---