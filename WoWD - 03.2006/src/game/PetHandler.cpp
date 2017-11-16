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

#include "WorldPacket.h"
#include "WorldSession.h"
#include "Opcodes.h"
#include "Log.h"
#include "World.h"
#include "ObjectMgr.h"
#include "Player.h"
#include "UpdateMask.h"
#include "Unit.h"
#include "Pet.h"
#include "Spell.h"

void WorldSession::HandlePetAction(WorldPacket & recv_data)
{
    WorldPacket data;
    uint64 plyrGuid, petGuid, target;//pet guid 64
    uint16 flags, flags2;
    
    Player * player = GetPlayer();

    recv_data >> petGuid >> flags >> flags2;

    plyrGuid = player->GetGUIDLow();

    sLog.outDebug("flags: %u", flags);
    sLog.outDebug("flags2: %u", flags2);
    sLog.outDebug("petGuid: %u", petGuid);

    
    Unit *pet = player->GetPet();

    if(pet)
    {
        if(flags2 == 1792)
        {
			switch(flags)
			{
			case PET_ACTION_ATTACK:
				{// ATTACK
					recv_data >> target;
					Unit *pTarget = objmgr.GetCreature(target);
					if(!pTarget)
						return;

					pet->GetAIInterface()->SetUnitToFollow(NULL);

					pet->GetAIInterface()->AttackReaction(pTarget,1,0);
				}break;
			case PET_ACTION_FOLLOW:
				{
				/*	if(pet->GetAIInterface()->getAIState() == STATE_ATTACKING)
					{
						pet->GetAIInterface()->HandleEvent(EVENT_LEAVECOMBAT, pet, 0);
					}
					else
					{*/
						pet->GetAIInterface()->HandleEvent(EVENT_FOLLOWOWNER, pet, 0);
					//}
				}break;
			case PET_ACTION_STAY:
				{
					pet->GetAIInterface()->SetUnitToFollow(NULL);
					//pet->GetAIInterface()->HandleEvent(EVENT_STAY, pet, 0);
				}break;
			case PET_ACTION_DISMISS:
				{
					player->SetPet(NULL);
					player->SetPetName("");
					pet->RemoveFromWorld();
					objmgr.RemoveObject(((Creature *)pet));
					delete pet;

					//Check hunter pet or not
					player->SetUInt64Value(UNIT_FIELD_SUMMON, 0);			

					data.clear();
					data.Initialize(SMSG_DESTROY_OBJECT);
					data << (uint32)petGuid << plyrGuid;
					player->SendMessageToSet(&data, true);

					data.clear();
					data.Initialize(SMSG_PET_SPELLS);
					data << (uint64)0;
					player->GetSession()->SendPacket(&data);
				}break;
			}
		}
		else if(flags2 == 49408)//spells
		{//TODO: Spells
			// check for spell id
/*			SpellEntry *spellInfo = sSpellStore.LookupEntry( flags );

			if(!spellInfo)
			{
				Log::getSingleton( ).outError("WORLD: unknown spell id %i\n", flags);
				return;
			}
			
			Spell *spell = new Spell(GetPlayer(), spellInfo, false, 0, false);
			WPAssert(spell);

			SpellCastTargets targets;
            targets.read(&recv_data,pet->GetGUID());
			//GetPlayer()->setCurrentSpell(spell);
			spell->prepare(&targets);*/
/*			SpellEntry *spellInfo = sSpellStore.LookupEntry( flags );
            
			recv_data >> target;
			printf("recv_data >> flags: %u\n", flags);

			Unit* pTarget = objmgr.GetCreature(target);
			if(pTarget)
			{
				if(spellInfo-> == 0 || unit_target->getRace() == spellInfo.race)
				{
					//if(  > spellInfo.Range ){
					data.Clear();
					data.Initialize(36,SMSG_SPELL_START);
					data << petGUID << petGUID << uint32(0x00000C26) << uint16(0x0002);
					data << uint32(0x000007D0) << uint16(0x0002) << unitTarget;
					pet_caster->SendMessageToSet(&data,true);

					data.Clear();
					data.Initialize(42,SMSG_SPELL_GO);
					data << petGUID << petGUID << uint32(0x00000C26) << uint16(0x0100);
					data << uint8(0x01) << unitTarget << uint8(0x00) << uint16(0x0002);
					data << unitTarget;
					pet_caster->SendMessageToSet(&data,true);

					uint32 damage = spellInfo.DmgPlus1+rand()%spellInfo.RandomPercentDmg;
					WORLDSERVER.mCombatHandler.AttackerStateUpdate(pet_caster, WORLDSERVER.getCreatureMap( )[ unitTarget ], damage);

					if(spellInfo.addDuration > 0)
					{
						Unit* cast_target = WORLDSERVER.GetCreature(unitTarget);
						if( cast_target )
						{
							uint32 time = spellInfo.addDuration/1000;
							uint32 addDmg = (uint32)((float)spellInfo.addDmg/(float)time);
							if(addDmg == 0)
								addDmg = 1;

							cast_target->m_damageDuration = spellInfo.addDuration/1000;
							cast_target->m_damage = addDmg;
							cast_target->m_Attacker = petGUID;
						}
					}

					uint32 mana = pet_caster->getUpdateValue( UNIT_FIELD_POWER1 );
					pet_caster->setUpdateValue( UNIT_FIELD_POWER1, mana-spellInfo.ManaCost );

					data.Clear();
					data.Initialize( 5, SMSG_CAST_RESULT );
					data << flags << uint8( 0x01);
					pet_caster->SendMessageToSet(&data,true);
				}
				else
				{
					data.Clear();
					data.Initialize( 6, SMSG_CAST_RESULT );
					data << flags << uint8( 0x02);
					data << uint8(9);
					pet_caster->SendMessageToSet(&data,true);
				}
			}*/
		}		
		else if(flags2 == 1536)
		{
			/*switch(flags)
			{
			case PET_STATE_PASSIVE:
				{
				}break;
			case PET_STATE_DEFENSIVE:
				{
				}break;
			case PET_STATE_AGGRESSIVE:
				{
				}break;*/
		}
		else
		{
			sLog.outError("WRONG FLAGS\n");
		}
	}
}

void WorldSession::HandlePetInfo(WorldPacket & recv_data)
{
	//nothing
}
void WorldSession::HandlePetNameQuery(WorldPacket & recv_data)
{
	/*cmsg
	uint32 petnumber
	uint64 petGuid
	define
	smsg
	uint32 petnumber
	string petname
	uimt32 nametimestamp
	*/
	WorldPacket data;
	uint32 petNumber;
	uint64 petGuid;
	Player *plyr;

	plyr = GetPlayer();
	if(!plyr)
		return;
	
	recv_data >> petNumber;
	recv_data >> petGuid;

	Creature *pet = objmgr.GetCreature(petGuid);
	if(!pet)
		return;

	plyr->SetUInt32Value(UNIT_FIELD_PET_NAME_TIMESTAMP, pet->GetUInt32Value(UNIT_FIELD_PET_NAME_TIMESTAMP));

	data.Initialize(SMSG_PET_NAME_QUERY_RESPONSE);
	data << petNumber;
	data <<	plyr->GetPetName().c_str();
//	data << uint32(0x42ECC745);
	data << pet->GetUInt32Value(UNIT_FIELD_PET_NAME_TIMESTAMP);
	plyr->GetSession()->SendPacket(&data);
}

void WorldSession::HandleStablePet(WorldPacket & recv_data)
{
	/*cmsg
	  uint64 npcGuid;

	  SMSG_STABLE_RESULT ->08

	  petspells 0

	  destroy object
	*/
}

void WorldSession::HandleUnstablePet(WorldPacket & recv_data)
{
	/*cmsg
	uint64 npcguid
	uint32 petnumber

	SMSG_STABLE_RESULT ->09
	pet spells
	create object*/
}

void WorldSession::HandleStabledPetList(WorldPacket & recv_data)
{
	/*
	  MSG_LIST_STABLED_PETS
	  cmsg
	  uint64 npcguid

	  smsg
	  uint64 npcguid
	  uint8 totalcount
	  uint8 count
	  uint32 petNumber
	  uint32 entryid
	  uint32 unk3 ->level?
	  string petname
	  uint32 unk4
	  uint8 slot
	*/
}

//CMSG_PET_SET_ACTION
