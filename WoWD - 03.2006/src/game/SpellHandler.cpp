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

#include "Database/DatabaseEnv.h"
#include "Common.h"
#include "WorldPacket.h"
#include "WorldSession.h"
#include "World.h"
#include "ObjectMgr.h"
#include "Log.h"
#include "Opcodes.h"
#include "Spell.h"
#include "Affect.h"

void WorldSession::HandleUseItemOpcode(WorldPacket& recvPacket)
{
	typedef std::list<Affect*> AffectList;
	WorldPacket data;
    Player* p_User = GetPlayer();
    Log::getSingleton( ).outDetail("WORLD: got use Item packet, data length = %i\n",recvPacket.size());
    uint8 tmp1,slot,tmp3;
    uint32 spellId;

    recvPacket >> tmp1 >> slot >> tmp3;
	Item* tmpItem;
	tmpItem = p_User->GetItemByLocation(tmp1,slot,false);
	if (!tmpItem)
		tmpItem = p_User->GetItemBySlot(slot);
	if (!tmpItem)
		return;
    ItemPrototype *itemProto = tmpItem->GetProto();
    spellId = itemProto->SpellId[0];

    // check for spell id
    SpellEntry *spellInfo = sSpellStore.LookupEntry( spellId );

    if(!spellInfo)
    {
        Log::getSingleton( ).outError("WORLD: unknown spell id %i\n", spellId);
        return;
    }
	if (spellInfo->AuraInterruptFlags & 262144)
	{
		if (p_User->isInCombat())
		{
			data.Initialize( SMSG_INVENTORY_CHANGE_FAILURE );
			data << uint8(INV_ERR_CANT_DO_IN_COMBAT);
			data << tmpItem->GetGUID();
			data << uint64(0);
			data << uint8(0);
			SendPacket(&data);
			return;
		}
		p_User->SetStandState(1);
		p_User->SetEating(spellInfo->Id);

		// loop through the affects and removing existing eating spells
		AffectList::iterator i;

		for (i = p_User->GetAffectBegin(); i != p_User->GetAffectEnd(); i++)
		{
			SpellEntry *nspell = sSpellStore.LookupEntry((*i)->GetSpellId());
			if (nspell->AuraInterruptFlags & 262144)
			{
				p_User->RemoveAffect(*i);
				break;
			}
		}
	}

    Spell *spell = new Spell(GetPlayer(), spellInfo,false, 0,false);
    WPAssert(spell);

    SpellCastTargets targets;
    targets.read(&recvPacket,GetPlayer()->GetGUID());
    spell->m_CastItem = tmpItem;
	//GetPlayer()->setCurrentSpell(spell);
    spell->prepare(&targets);

}

void WorldSession::HandleCastSpellOpcode(WorldPacket& recvPacket)
{
    uint32 spellId;

    recvPacket >> spellId;

    Log::getSingleton( ).outDetail("WORLD: got cast spell packet, spellId - %i, data length = %i\n",
        spellId, recvPacket.size());
	if (GetPlayer()->GetOnMeleeSpell() != spellId)
	{
		// check for spell id
		SpellEntry *spellInfo = sSpellStore.LookupEntry(spellId );

		if(!spellInfo)
		{
			Log::getSingleton( ).outError("WORLD: unknown spell id %i\n", spellId);
			return;
		}
		
		Spell *spell = new Spell(GetPlayer(), spellInfo, false, 0, false);
		WPAssert(spell);

		SpellCastTargets targets;
		targets.read(&recvPacket,GetPlayer()->GetGUID());
		//GetPlayer()->setCurrentSpell(spell);
		spell->prepare(&targets);
	}
}

void WorldSession::HandleCancelCastOpcode(WorldPacket& recvPacket){
    uint32 spellId;
    recvPacket >> spellId;

    if(GetPlayer()->m_currentSpell)
        GetPlayer()->m_currentSpell->cancel();
}

void WorldSession::HandleCancelAuraOpcode( WorldPacket& recvPacket){
    uint32 spellId;
    recvPacket >> spellId;
    GetPlayer()->RemoveAffectById(spellId);
	printf("removing aura %u\n",spellId);
}

void WorldSession::HandleCancelChannellingOpcode( WorldPacket& recvPacket)
{
    uint32 spellId;
    recvPacket >> spellId;

    Player *plyr = GetPlayer();
    if(!plyr)
        return;

    if(plyr->m_currentSpell)
    {
        Spell *spl = GetPlayer()->m_currentSpell;
        for(int i = 0; i < 3; i++)
        {
            if(spl->m_spellInfo->Effect[i] == SPELL_EFFECT_PERSISTENT_AREA_AURA)
            {
                DynamicObject *dObj = objmgr.GetObject<DynamicObject>(plyr->GetUInt64Value(UNIT_FIELD_CHANNEL_OBJECT));
                if(!dObj)
                    return;
                WorldPacket data;
				data.Initialize(SMSG_GAMEOBJECT_DESPAWN_ANIM);
				data << plyr->GetGUID();
				plyr->SendMessageToSet(&data,true);
				dObj->RemoveFromWorld();
				objmgr.RemoveObject(dObj);
                delete dObj;
                break;
            }
        }
        spl->cancel();
    }
}