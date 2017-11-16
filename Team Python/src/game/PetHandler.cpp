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

#define world WorldServer::getSingleton()


PetHandler::PetHandler()
{

}

PetHandler::~PetHandler()
{

}

void PetHandler::HandleMsg( wowWData & recv_data, GameClient *pClient )
{
	wowWData data;
	wowWData data2;
    char f[256];
    sprintf(f, "WORLD: Pet 0x%.4X", recv_data.opcode);
    Log::getSingleton( ).outString( f );
	switch (recv_data.opcode)
	{
	case CMSG_PET_ACTION:
			{
				uint64 pguid, petGUID, unitTarget;
				//LINA uint32 spell;
				uint16 flags, flags2;


				recv_data >> petGUID >> flags >> flags2;
				pguid = pClient->getCurrentChar()->getGUID();
/*
				SpellInformation spellInfo;
				DatabaseInterface *dbi = Database::getSingleton().createDatabaseInterface(); //get a hook for the DB
				spellInfo = dbi->GetSpellInformation ( spell ); //returns a SpellInformation object/struct
				Database::getSingleton().removeDatabaseInterface( dbi ); //clean up used resources
*/				
				printf("flags: %u\n", flags);
				printf("flags2: %u\n", flags2);
				printf("petGUID %u\n", petGUID);

				Unit* pet_caster = world.GetCreature(petGUID);
				if(pet_caster)
				{
					if(flags == 0x0002 && flags2 == 1792)
					{ // ATTACK
						pet_caster->m_follow = false;
						recv_data >> unitTarget;
						//printf("unitTarget %u\n", unitTarget);

						data.clear();
						data.Initialise(12, SMSG_AI_REACTION);
						data << petGUID << uint32(00000002);
						pClient->SendMsg(&data);
						
						pet_caster->AI_AttackReaction(world.GetCreature(unitTarget), 0);
					
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
						DatabaseInterface *dbi = Database::getSingleton().createDatabaseInterface(); //get a hook for the DB
						spellInfo = dbi->GetSpellInformation ( flags ); //returns a SpellInformation object/struct
						Database::getSingleton().removeDatabaseInterface( dbi ); //clean up used resources

						recv_data >> unitTarget;
						printf("recv_data >> flags: %u\n", flags);
						
						Unit* unit_target = world.GetCreature(unitTarget);
						if(unit_target)
						{
							if(spellInfo.race == 0 || unit_target->getRace() == spellInfo.race)
							{
								//if(  > spellInfo.Range ){
								data.clear();
								data.Initialise(36,SMSG_SPELL_START);
								data << petGUID << petGUID << uint32(0x00000C26) << uint16(0x0002);
								data << uint32(0x000007D0) << uint16(0x0002) << unitTarget;
								pet_caster->SendMessageToSet(&data,true);
								
								data.clear();
								data.Initialise(42,SMSG_SPELL_GO);
								data << petGUID << petGUID << uint32(0x00000C26) << uint16(0x0100);
								data << uint8(0x01) << unitTarget << uint8(0x00) << uint16(0x0002);
								data << unitTarget;
								pet_caster->SendMessageToSet(&data,true);

								uint32 damage = spellInfo.DmgPlus1+rand()%spellInfo.RandomPercentDmg;
								world.mCombatHandler.AttackerStateUpdate(pet_caster, world.getCreatureMap( )[ unitTarget ], damage);

								if(spellInfo.addDuration > 0)
								{
									Unit* cast_target = world.GetCreature(unitTarget);
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

			        			data.clear();		
			        			data.Initialise( 5, SMSG_CAST_RESULT );
			        			data << flags << uint8( 0x01);
			        			pet_caster->SendMessageToSet(&data,true);
							}
							else
							{
								data.clear();
			        			data.Initialise( 6, SMSG_CAST_RESULT );
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
						std::map<uint32, Unit*>::iterator itr = world.mCreatures.find(petGUID); 
						for( WorldServer::CharacterMap::iterator iter = world.mCharacters.begin( ); iter != world.mCharacters.end( ); ++ iter ) 
							iter->second->RemoveInRangeObject( itr->second ); 
    
						itr->second->setDeathState(DEAD);
						delete itr->second; 
   						world.mCreatures.erase(itr); 

						data.clear(); 
						data.Initialise(8, SMSG_DESTROY_OBJECT); 
						data << (uint32)petGUID << (uint32)pet_caster->getGUIDHigh(); 
						pClient->getCurrentChar()->SendMessageToSet(&data, true); 
    
						DatabaseInterface *dbi = Database::getSingleton( ).createDatabaseInterface( ); 
						char sql[512]; 
						sprintf(sql, "DELETE FROM creatures WHERE id=%u", petGUID); 
						dbi->doQuery(sql); 
						Database::getSingleton( ).removeDatabaseInterface(dbi); 
						
						pClient->getCurrentChar()->setUpdateValue(ITEM_FIELD_CONTAINED,0);
						pClient->getCurrentChar()->setUpdateValue(UNIT_FIELD_SUMMON,   0);
						pClient->getCurrentChar()->setUpdateValue(GAMEOBJECT_ROTATION, 0);
						pClient->getCurrentChar()->setUpdateValue(DYNAMICOBJECT_BYTES, 0);
						pClient->getCurrentChar()->setUpdateValue(CORPSE_FIELD_FACING, 0);
						pClient->getCurrentChar()->setUpdateValue(UNIT_FIELD_SUMMON+1, 0xf0001000);
						pClient->getCurrentChar()->setUpdateValue(GAMEOBJECT_ROTATION+1, 0xf0001000);
						pClient->getCurrentChar()->setUpdateValue(DYNAMICOBJECT_SPELLID, 0xf0001000);

						data.clear();
						data.Initialise(62, SMSG_PET_SPELLS);
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
