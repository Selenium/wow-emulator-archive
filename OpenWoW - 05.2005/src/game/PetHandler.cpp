//////////////////////////////////////////////////////////////////////
//  Pet Handler
//
//  Handles Pet usage
//////////////////////////////////////////////////////////////////////

// Copyright (C) 2004 Team Python
// Copyright (C) 2004, 2005 Team WSD
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

#include "SpellHandler.h"
#include "NetworkInterface.h"
#include "Opcodes.h"
#include "Log.h"
#include "Character.h"
#include "WorldServer.h"
#include "Database.h"
#include "UpdateMask.h"
#include "Unit.h"
#include "Spell.h"
#include "Character.h"
#include "math.h"
#include "PetHandler.h"

PetHandler::PetHandler()
{

}

PetHandler::~PetHandler()
{

}

void PetHandler::HandleMsg( NetworkPacket & recv_data, GameClient *pClient )
{
	NetworkPacket data;
	NetworkPacket data2;
	char f[256];
	sprintf(f, "WORLD: Pet 0x%.4X", recv_data.opcode);
	LOG.outString( f );
	switch (recv_data.opcode)
	{
	case CMSG_PET_ACTION:
		{
			uint32 pguid, petGUID, unitTarget;
			//LINA uint32 spell;
			uint16 flags, flags2;

			recv_data >> petGUID >> flags >> flags2;
			pguid = pClient->getCurrentChar()->getGUID().sno;
			/*
			 SpellInformation spellInfo;
			 DatabaseInterface *dbi = DATABASE.createDatabaseInterface(); //get a hook for the DB
			 spellInfo = dbi->GetSpellInformation ( spell ); //returns a SpellInformation object/struct
			 DATABASE.removeDatabaseInterface( dbi ); //clean up used resources
			 */
			printf("flags: %u\n", flags);
			printf("flags2: %u\n", flags2);
			printf("petGUID %u\n", petGUID);

			Unit* pet_caster = WORLDSERVER.GetCreature (petGUID);
			if(pet_caster)
			{
				if(flags == 0x0002 && flags2 == 1792)
				{ // ATTACK
					pet_caster->m_follow = false;
					recv_data >> unitTarget;
					//printf("unitTarget %u\n", unitTarget);

					data.Clear();
					data.Initialize(12, SMSG_AI_REACTION);
					data << petGUID << uint32(00000002);
					pClient->SendMsg(&data);

					pet_caster->AI_AttackReaction (WORLDSERVER.GetCreature (unitTarget), 0);

				}
				else if(flags == 0x0001 && flags2 == 1792)
				{ // FOLLOW
					pet_caster->m_follow = true;

				}
				else if(flags == 0x0000 && flags2 == 1792)
				{ // STAY
					pet_caster->m_follow = false;

				}
				else if(flags2 == 256 || flags2 == 16640)
				{
					SpellInformation spellInfo;
					DatabaseInterface *dbi = DATABASE.createDatabaseInterface(); //get a hook for the DB
					spellInfo = dbi->GetSpellInformation ( flags ); //returns a SpellInformation object/struct
					DATABASE.removeDatabaseInterface( dbi ); //clean up used resources

					recv_data >> unitTarget;
					printf("recv_data >> flags: %u\n", flags);

					Unit* unit_target = WORLDSERVER.GetCreature(unitTarget);
					if(unit_target)
					{
						if(spellInfo.race == 0 || unit_target->getRace() == spellInfo.race)
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
					}
				}
				else if(flags == 0 && flags2 == 1536)
				{//passive
					pet_caster->m_pet_state = 0;
				}
				else if(flags == 1 && flags2 == 1536)
				{//defensive
					pet_caster->m_pet_state = 1;
					//pet_caster->m_creatureState = MOVING;
					//pet_caster->setUpdateValue(UNIT_FIELD_TARGET,205);
				}
				else if(flags == 2 && flags2 == 1536)
				{//aggressive
					pet_caster->m_pet_state = 2;

				}
				else if(flags == 0x0003 && flags2 == 1792)
				{
					std::map<uint32, Unit*>::iterator itr = WORLDSERVER.mCreatures.find(petGUID);
					for( WorldServer::CharacterMap::iterator iter = WORLDSERVER.mCharacters.begin( ); iter != WORLDSERVER.mCharacters.end( ); ++ iter )
						iter->second->RemoveInRangeObject( itr->second );

					itr->second->setDeathState(DEAD);
					delete itr->second;
					WORLDSERVER.mCreatures.erase(itr);

					data.Clear();
					data.Initialize(8, SMSG_DESTROY_OBJECT);
					data << (uint32)petGUID << pet_caster->getGUID ().type;
					pClient->getCurrentChar()->SendMessageToSet(&data, true);

					DatabaseInterface *dbi = DATABASE.createDatabaseInterface( );
					char sql[512];
					sprintf(sql, "DELETE FROM creatures WHERE id=%u", petGUID);
					dbi->doQuery(sql);
					DATABASE.removeDatabaseInterface(dbi);

					pClient->getCurrentChar()->setUpdateValue(ITEM_FIELD_CONTAINED,0);
					pClient->getCurrentChar()->setUpdateValue(UNIT_FIELD_SUMMON,   0);
					pClient->getCurrentChar()->setUpdateValue(GAMEOBJECT_ROTATION, 0);
					pClient->getCurrentChar()->setUpdateValue(DYNAMICOBJECT_BYTES, 0);
					pClient->getCurrentChar()->setUpdateValue(CORPSE_FIELD_FACING, 0);
					pClient->getCurrentChar()->setUpdateValue(UNIT_FIELD_SUMMON+1, 0xf0001000);
					pClient->getCurrentChar()->setUpdateValue(GAMEOBJECT_ROTATION+1, 0xf0001000);
					pClient->getCurrentChar()->setUpdateValue(DYNAMICOBJECT_SPELLID, 0xf0001000);

					data.Clear();
					data.Initialize(62, SMSG_PET_SPELLS);
					data << (uint64)0;
					pClient->SendMsg(&data);
				}
				else
				{
					printf("WRONG FLAGS\n");
				}
			}

		}
	}
}
