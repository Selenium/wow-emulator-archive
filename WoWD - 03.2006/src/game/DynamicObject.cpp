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
#include "GameObject.h"
#include "UpdateMask.h"
#include "Opcodes.h"
#include "WorldPacket.h"
#include "WorldSession.h"
#include "World.h"
#include "ObjectMgr.h"
#include "Database/DatabaseEnv.h"
#include "Spell.h"

/*[20:28] <@> lets say u need it to deal damage 10 times, with 10 seconds between them
[20:28] <@> so u just do
[20:29] <@> sEventMgr.AddEvent(this, &DynamicObject::DealDamage, EVENT_GAMEOBJECT_DEALDMG, 10000, 10);
[20:29] <@> as simple as that
[20:29] <@> and if u want the object to die after 1 minute
[20:29] <@> u do
[20:29] <@> sEventMgr.AddEvent(this, &DynamicObject::OnExpire, EVENT_GAMEOBJECT_EXPIRED, 6000, 1);*/

DynamicObject::DynamicObject() : Object()
{
	m_objectType |= TYPE_DYNAMICOBJECT;
	m_objectTypeId = TYPEID_DYNAMICOBJECT;

	m_valuesCount = DYNAMICOBJECT_END;

	sEventMgr.AddEvent(this, &DynamicObject::Update, (uint32)100, EVENT_GAMEOBJECT_UPDATE, 100, 0);
}

DynamicObject::~DynamicObject()
{
	sEventMgr.RemoveEvents(this);
}

void DynamicObject::Create( uint32 guidlow, Unit *caster, SpellEntry * spell, float x, float y, float z, uint32 duration, Spell *sp)
{
	Object::_Create(guidlow, 0xF0007000, caster->GetMapId(), x, y, z, 0);
	m_spell = spell;
	m_caster = caster;
	m_castspell = sp;

	SetUInt32Value( OBJECT_FIELD_ENTRY, spell->Id );
	SetFloatValue( OBJECT_FIELD_SCALE_X, 1 );
	SetUInt64Value( DYNAMICOBJECT_CASTER, caster->GetGUID() );
	SetUInt32Value( DYNAMICOBJECT_BYTES, 0x00000001 );
	SetUInt32Value( DYNAMICOBJECT_SPELLID, spell->Id );
	SetFloatValue( DYNAMICOBJECT_RADIUS, (float)GetRadius(sSpellRadius.LookupEntry(spell->EffectRadiusIndex[0] )));
	SetFloatValue( DYNAMICOBJECT_POS_X, x );
	SetFloatValue( DYNAMICOBJECT_POS_Y, y );
	SetFloatValue( DYNAMICOBJECT_POS_Z, z );

	m_aliveDuration = duration;
}

void DynamicObject::Update(uint32 p_time)
{
	bool deleteThis = false;
	WorldPacket data;
	// Delete Timer
	if(m_aliveDuration > 0){
		if(m_aliveDuration > p_time)
			m_aliveDuration -= p_time;
		else{
			deleteThis = true;
			if(this->IsInWorld()){
				WorldPacket data;
				data.Initialize(SMSG_GAMEOBJECT_DESPAWN_ANIM);
				data << GetGUID();
				SendMessageToSet(&data,true);
				this->RemoveFromWorld();
				objmgr.RemoveObject(this);
			}
		}
	}

	if(GetUInt32Value(OBJECT_FIELD_TYPE ) == 65){   // Persistent Area Aura
		if(m_PeriodicDamageCurrentTick > p_time)
			m_PeriodicDamageCurrentTick -= p_time;
		else{
			m_PeriodicDamageCurrentTick = m_PeriodicDamageTick;
			DealDamage();
		}
	}

	if(deleteThis){
		m_PeriodicDamage = 0;
		m_PeriodicDamageTick = 0;
		//RemoveFromMap();
		//RemoveFromWorld();
		//objmgr.RemoveObject(this);
		delete this;
	}
}

void DynamicObject::DealDamage()
{
	std::set<Object*>::iterator itr;
	for( itr = m_caster->GetInRangeSetBegin(); itr != m_caster->GetInRangeSetEnd(); itr++ )
	{
		if( (*itr)->GetTypeId() != TYPEID_UNIT && (*itr)->GetTypeId() != TYPEID_PLAYER )
			continue;
		if(!((Unit*)(*itr))->isAlive())
			continue;
		if(_CalcDistance(GetPositionX(),GetPositionY(),GetPositionZ(),(*itr)->GetPositionX(),(*itr)->GetPositionY(),(*itr)->GetPositionZ()) < m_PeriodicDamageRadius && (*itr)->GetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE) != m_caster->GetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE))
		{
			if (m_castspell->getState() == SPELL_STATE_CASTING)
				m_castspell->SendSpellGo();
			m_caster->PeriodicAuraLog((Unit*)(*itr),m_spell->Id,m_PeriodicDamage,m_spell->School);
		}
	}
}

void DynamicObject::PeriodicTriggerDamage(uint32 damage, uint32 tick, float radius)
{
	m_PeriodicDamage = damage;
	m_PeriodicDamageTick = tick;
	m_PeriodicDamageCurrentTick = tick;
	m_PeriodicDamageRadius = radius;
}

float DynamicObject::_CalcDistance(float sX, float sY, float sZ, float dX, float dY, float dZ)
{
	return sqrt((dX-sX)*(dX-sX)+(dY-sY)*(dY-sY)+(dZ-sZ)*(dZ-sZ));
}

