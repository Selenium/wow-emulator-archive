#include "SpellHandler.h"
#include "NetworkInterface.h"
#include "Opcodes.h"
#include "Log.h"
#include "Character.h"
#include "WorldServer.h"
#include "Database.h"
#include "UpdateMask.h"
#include "Unit.h"
#include "Spell.h" //angelic|999
#include "Character.h" //angelic|999
#include "math.h"
#include <time.h>
#include "Timer.h"

#define M_PI 3.14159265358979323846
#define world WorldServer::getSingleton()
#define DEG2RAD (M_PI/180.0)

SpellHandler::SpellHandler()
{

}

SpellHandler::~SpellHandler()
{

}

void SpellHandler::HandleMsg( wowWData & recv_data, GameClient *pClient )
{
	wowWData data;
	wowWData data2;
    char f[256];
    sprintf(f, "WORLD: Spell 0x%.4X", recv_data.opcode);
    Log::getSingleton( ).outString( f );
	switch (recv_data.opcode)
	{
		case CMSG_USE_ITEM:
			{
			//printf("ok got opcode here %u\n", recv_data.length);

				uint8 packslot,slot;
				uint16 targets;
				uint8 spell;

				int datalen = recv_data.length;
				recv_data >> packslot >> slot >> spell;
				recv_data >> targets;
				//if (targets == 0)
				//	return;
				uint32 spellid;
				//printf("recived data!\n");
				//printf("Item ID - %d\nItem GUID - %d\n",pClient->getCurrentChar()->getItemIdBySlot(slot),pClient->getCurrentChar()->getGuidBySlot(slot));
				Item *tmpItem = world.GetItem( pClient->getCurrentChar()->getItemIdBySlot(slot) );
				spellid = tmpItem->SpellID[spell - 1];
				for(int i = 0;i < 5;i++) 
				{
					//printf("spell number %d - %d\n",i,tmpItem->SpellID[i]);
				}

				data.clear();
				data.Initialise( datalen - 3 + 32, SMSG_SPELL_GO);
				data << uint32(pClient->getCurrentChar()->getGUID()) << uint32(pClient->getCurrentChar()->getGUIDHigh());
				data << uint32(pClient->getCurrentChar()->getGUID()) << uint32(pClient->getCurrentChar()->getGUIDHigh());
				data << uint32(spellid);
				data << uint8(0x00) << uint8(0x01);

				if( targets & 0x2 || targets & 0x800 || targets & 0x8000 ) 
				{
					uint64 unitTarget;
					recv_data >> unitTarget;
					data << uint8(0x01);
					data << uint64(unitTarget);
					data << uint8(0x00);
					data << uint16(targets);
					data << uint64(unitTarget);
				}

				SpellInformation spellInfo;
				DatabaseInterface *dbi = Database::getSingleton().createDatabaseInterface(); //get a hook for the DB
				spellInfo = dbi->GetSpellInformation ( tmpItem->SpellID[0] ); //returns a SpellInformation object/struct
				Database::getSingleton().removeDatabaseInterface( dbi ); //clean up used resources

			
				if(spellInfo.spell_type == (uint32)POTIONS)
					usePotion(pClient, tmpItem->SpellID[0], spellInfo, targets);

			}break;

		case CMSG_CAST_SPELL:
			{
				uint32 spell ,pguid ,target1 ,target2;
				uint16 flags;
				uint8 hitCount ,missCount;
				recv_data >> spell >> flags;
				pguid = pClient->getCurrentChar()->getGUID();

				SpellInformation spellInfo;
				DatabaseInterface *dbi = Database::getSingleton().createDatabaseInterface(); //get a hook for the DB
				spellInfo = dbi->GetSpellInformation ( spell ); //returns a SpellInformation object/struct
				Database::getSingleton().removeDatabaseInterface( dbi ); //clean up used resources

			//Catch Mana problems early/This should never happen except with a incorrect spell table 
			  if (pClient->getCurrentChar()->getUpdateValue( UNIT_FIELD_POWER1 ) < spellInfo.ManaCost) 
			   { 
				  data.clear(); 
				  data.Initialise( 6, SMSG_CAST_RESULT ); 
				  data << spell << uint8(0x02) << uint8(21); 
				  pClient->SendMsg(&data); 
			   } 

				//let's check spell type:
				if( spellInfo.spell_type == (uint32)SINGLE_TARGET) 
				{
					recv_data >> target1 >> target2;
					printf("recv_data >> spell: %u\n", spell);
					printf("recv_data >> flags: %u\n", flags);
					
					Unit* pUnit_target = world.GetCreature(target1);
					if(pUnit_target)
					{
						if(spellInfo.race == 0 || pUnit_target->getRace() == spellInfo.race)
						{
							//if(  > spellInfo.Range ){
							data.clear();
			        		data.Initialise( 36, SMSG_SPELL_START );
			        		data << pguid << uint32( 0 ) << pguid << uint32( 0 ) << spell;
			        		data << flags << uint32 ( 3500 ) << flags << target1 << target2;
			        		pClient->SendMsg( &data );

							hitCount = 1;
							missCount = 0;

			        		data2.clear();
			        		data2.Initialise( 42, SMSG_SPELL_GO );
			        		data2 << (uint64)pguid << (uint64)pguid;
			        		data2 << spell << uint16( 0x0100 ) << hitCount << target1 << target2;
			        		data2 << missCount << flags << target1 << target2;
							
							uint32 damage = spellInfo.DmgPlus1+rand()%spellInfo.RandomPercentDmg;
							world.mCombatHandler.AttackerStateUpdate(pClient->getCurrentChar( ), world.getCreatureMap( )[ target1 ], damage);

							if(spellInfo.addDuration > 0)
							{
								Unit* pCast_target = world.GetCreature(target1);
								if( pCast_target )
								{
									uint32 time = spellInfo.addDuration/1000;
									uint32 addDmg = (uint32)((float)spellInfo.addDmg/(float)time);
									if(addDmg == 0)
										addDmg = 1;

									pCast_target->m_damageDuration = spellInfo.addDuration/1000;
									pCast_target->m_damage = addDmg;
									pCast_target->m_Attacker = pClient->getCurrentChar()->getGUID();
								}
							}
							
							uint32 mana = pClient->getCurrentChar()->getUpdateValue( UNIT_FIELD_POWER1 );
							pClient->getCurrentChar( )->setUpdateValue( UNIT_FIELD_POWER1, mana-spellInfo.ManaCost );

			        		data.clear();		
			        		data.Initialise( 5, SMSG_CAST_RESULT );
			        		data << spell << uint8( 0x01);
			        		pClient->SendMsg( &data );

//							pClient->getCurrentChar()->SendMessageToSet(&data2, true);
			                world.SendAreaMessage(&data2, pClient, 1);
						}
						else
						{
							data.clear();
			        		data.Initialise( 6, SMSG_CAST_RESULT );
			        		data << spell << uint8( 0x02);
							data << uint8(9);
			        		pClient->SendMsg( &data );
						}
					}

				}
				else if( spellInfo.spell_type == (uint32)MULTI_TARGET ) 
				{
					int templen = 0;
					uint64 itemTarget,unitTarget;
					uint16 targets = flags;
					uint8 targetCount = 0;
					wowWData tmpData;
					float sourceLocationx, sourceLocationy, sourceLocationz;
					float destLocationx, destLocationy, destLocationz;
					float dist = 0;
					
					tmpData.Initialise(100, SMSG_SPELL_START);
					tmpData << pguid << uint32( 0 ) << pguid << uint32( 0 ) << spell;
					tmpData << flags << uint32 ( 0 ) << flags;

					if( targets & 0x2 || targets & 0x800 || targets & 0x8000 ) 
					{
						templen += 8;
						recv_data >> unitTarget;	// GUID
						tmpData << uint64(unitTarget);
						printf("unitTarget is: %u\n", unitTarget);
					}
					if( targets & 0x10 || targets & 0x1000 ) 
					{
						templen += 8;
						recv_data >> itemTarget;
						tmpData << uint64(itemTarget);
					}
					if( targets & 0x20 ) 
					{
						templen += 12;
						recv_data >> sourceLocationx >> sourceLocationy >> sourceLocationz;
						tmpData << sourceLocationx << sourceLocationy << sourceLocationz;
						dist = 0;
					}
					if( targets & 0x40 ) 
					{
						printf("OK recv destLocations now\n");
						templen += 12;
						recv_data >> destLocationx >> destLocationy >> destLocationz;
						tmpData << destLocationx << destLocationy << destLocationz;
						dist = world.CalcDistanceByPosition(pClient->getCurrentChar(),destLocationx,destLocationy,destLocationz);
					}
					if( targets & 0x2000 ) 
					{
						templen += 128;
					}
					
					data.Initialise(28 + templen,SMSG_SPELL_START);
					memcpy(data.data, tmpData.data,28+templen );
//                    pClient->getCurrentChar()->SendMessageToSet(&data, true);
	                world.SendAreaMessage(&data, pClient, 1);

					wowWData tmpSpellGo;

					data.clear();		
			        tmpSpellGo.Initialise( 500, SMSG_SPELL_GO );
					tmpSpellGo << pguid << uint32( 0 ) << pguid << uint32( 0 );
					tmpSpellGo << spell;
					tmpSpellGo << uint8(0) << uint8(1);
					//tmpSpellGo << uint16(0x0110);
					tmpSpellGo << uint8(targetCount);
					
					if(dist < spellInfo.Range)
					{
						WorldServer::CreatureMap::iterator itr;
						for (itr = world.mCreatures.begin(); itr != world.mCreatures.end(); ++itr)
						{
							if (( itr->second->isAlive() ) && (!itr->second->isPlayer()))
							{
								if (!( targets & 0x40 )) 
								{
									if ((world.CalcDistance((Unit*)pClient->getCurrentChar(), (itr->second)) < spellInfo.Radius) && (pClient->getCurrentChar()->getMapId() == itr->second->getMapId()  ))
									{
										if (itr->second->getZone() == pClient->getCurrentChar()->getZone())
										{
											if (applySpell(pClient, itr->second , spell , spellInfo))
											{												
												targetCount++;
												if(spellInfo.addDuration > 0)
												{
													itr->second->m_damage = spellInfo.addDmg*1000/spellInfo.addDuration;
													itr->second->m_damageDuration = spellInfo.addDuration/1000;		
													printf("damage amount is: %u\n", itr->second->m_damage);
													printf("damage duration is: %u\n", itr->second->m_damageDuration);
												}
												tmpSpellGo << itr->second->getGUID() << itr->second->getGUIDHigh();
											}												
										}
									}
								}
								else
								{
									if ((world.CalcDistanceByPosition((itr->second),destLocationx,destLocationy,destLocationz) < spellInfo.Radius) && (pClient->getCurrentChar()->getMapId() == itr->second->getMapId()  ))
									{
										if (itr->second->getZone() == pClient->getCurrentChar()->getZone()) 
										{
											//Do Something
											if (applySpell(pClient, itr->second , spell , spellInfo)) 
											{
												targetCount++;
												if(spellInfo.addDuration > 0)
												{
													itr->second->m_damage = spellInfo.addDmg*1000/spellInfo.addDuration;
													itr->second->m_damageDuration = spellInfo.addDuration/1000;		
													printf("damage amount is: %u\n", itr->second->m_damage);
													printf("damage duration is: %u\n", itr->second->m_damageDuration);
												}
													tmpSpellGo << itr->second->getGUID() << itr->second->getGUIDHigh();
											}													
										}
									}											
								}
							}
						}

						memcpy(tmpSpellGo.data + 22, &targetCount ,1);
						tmpSpellGo << uint8(0) << uint16(targets);
						if( targets & 0x2 || targets & 0x800 || targets & 0x8000 ) 
						{
							tmpSpellGo << uint64(unitTarget);
						}
						if( targets & 0x10 || targets & 0x1000 ) 
						{
							tmpSpellGo << uint64(itemTarget);
						}
						if( targets & 0x20 ) 
						{
							tmpSpellGo << float(sourceLocationx) << float(sourceLocationy) << float(sourceLocationz);
						}
						if( targets & 0x40 ) 
						{
							tmpSpellGo << float(destLocationx) << float(destLocationy) << float(destLocationz);
						}								
						data.Initialise(26 + 8*targetCount + templen,SMSG_SPELL_GO);
						memcpy(data.data, tmpSpellGo.data, 26 + 8*targetCount + templen);
//						pClient->getCurrentChar()->SendMessageToSet(&data, true);
		                world.SendAreaMessage(&data, pClient, 1);

						data.clear();
						data.Initialise(14, SMSG_SPELL_COOLDOWN);
						data << spell << (uint64)pguid << spellInfo.CoolDown;
						pClient->SendMsg(&data);

						uint32 mana = pClient->getCurrentChar()->getUpdateValue( UNIT_FIELD_POWER1 );
						pClient->getCurrentChar( )->setUpdateValue( UNIT_FIELD_POWER1, mana-spellInfo.ManaCost );

						data.clear();
						data.Initialise( 5, SMSG_CAST_RESULT );
						data << spell << uint8( 0x01);
						pClient->SendMsg( &data );
					}
					else
					{
						data.Initialise( 6, SMSG_CAST_RESULT );
						data << spell << uint8( 0x02);
						data << uint8( 71 );
						pClient->SendMsg( &data );
					}
				} 
				else if(spellInfo.spell_type == (uint32)SELF_HEAL) 
				{
					uint32 curr_health = pClient->getCurrentChar( )->getUpdateValue( UNIT_FIELD_HEALTH );
					uint32 max_health = pClient->getCurrentChar( )->getUpdateValue( UNIT_FIELD_MAXHEALTH );
					uint32 mana = pClient->getCurrentChar()->getUpdateValue( UNIT_FIELD_POWER1 );
					uint32 heal = spellInfo.DmgPlus1+rand()%spellInfo.RandomPercentDmg;
					if(curr_health==max_health)
					{
						data.clear();		
			        	data.Initialise( 6, SMSG_CAST_RESULT );
			        	data << spell << uint8( 0x02);
						data << uint8( 5 );
			        	pClient->SendMsg( &data );
						break;
					}
					else
					{
						if( heal+curr_health>max_health )
						{
							heal=max_health-curr_health;
						}
						data.Initialise(4, SMSG_HEALSPELL_ON_PLAYER );
						data << heal;
						pClient->SendMsg( &data );
						pClient->getCurrentChar( )->setUpdateValue( UNIT_FIELD_HEALTH, heal+curr_health );
						pClient->getCurrentChar( )->setUpdateValue( UNIT_FIELD_POWER1, mana-spellInfo.ManaCost );
					}

					data.clear();
					data.Initialise(14, SMSG_SPELL_COOLDOWN);
					data << spell << pguid << spellInfo.CoolDown;
					pClient->SendMsg(&data);

					data.clear();		
					data.Initialise( 13, SMSG_CAST_RESULT );
					data << spell << uint8( 0x01);
					pClient->SendMsg( &data );

				} 
				else if(spellInfo.spell_type == (uint32)TARGET_HEAL) 
				{
					uint64 target;
					uint64 pguid = pClient->getCurrentChar()->getGUID();
					recv_data >> target;

					Character * pChar_target = world.GetCharacter((uint32)target);
					if( pChar_target )
					{
						//pClient->getCurrentChar(target);

						uint32 curr_heal = pChar_target->getUpdateValue( UNIT_FIELD_HEALTH );
						uint32 max_heal = pChar_target->getUpdateValue( UNIT_FIELD_MAXHEALTH );
						uint32 heal = spellInfo.DmgPlus1+rand()%spellInfo.RandomPercentDmg;
						if(curr_heal == max_heal)
						{
							data.clear();		
			        		data.Initialise( 6, SMSG_CAST_RESULT );
			        		data << spell << uint8( 0x02);
							data << uint8( 13 );
			        		pClient->SendMsg( &data );
							break;
						}
						else
						{ 
							if( heal+curr_heal>max_heal )
								heal=max_heal-curr_heal;

							data.Initialise(4, SMSG_HEALSPELL_ON_PLAYER );
							data << heal;
//							pClient->getCurrentChar()->SendMessageToSet(&data,true);
			                world.SendAreaMessage(&data, pClient, 1);
							pChar_target->setUpdateValue( UNIT_FIELD_HEALTH, heal+curr_heal );
							if(spellInfo.addDuration > 0)
							{
								uint32 addDmg = spellInfo.addDmg*1000/spellInfo.addDuration;
								pChar_target->m_healingDuration  = spellInfo.addDuration/1000; // Set duration
								pChar_target->m_replenish_field  = 20; // Mana or Life ?
								pChar_target->m_replenish_value  = addDmg;
								pChar_target->m_spell			= spell;
								setAura(pChar_target, spell);
								pChar_target->m_auraDuration = spellInfo.addDuration/1000;
							}
						}

						uint32 mana = pClient->getCurrentChar()->getUpdateValue( UNIT_FIELD_POWER1 );
						pClient->getCurrentChar( )->setUpdateValue( UNIT_FIELD_POWER1, mana-spellInfo.ManaCost );
						data.clear();
						data.Initialise( 5, SMSG_CAST_RESULT );
						data << spell << uint8( 0x01);
						pClient->SendMsg( &data );

						data.clear();
						data.Initialise( 36 , SMSG_SPELL_START);
						data << pguid << pguid << spell << flags;
						data << spellInfo.CastTime << flags;
						data << (uint64)target;
//						pClient->getCurrentChar()->SendMessageToSet(&data, true);
		                world.SendAreaMessage(&data, pClient, 1);
					}
				} 
				else if(spellInfo.spell_type == (uint32)DAMAGE_ABSORB) 
				{
					// Damage Absorb
					uint64 target;
					uint64 pguid = pClient->getCurrentChar()->getGUID();
					recv_data >> target;
					Character * pChar_target = world.GetCharacter((uint32)target);
					if( pChar_target )
					{
						setAura(pChar_target, spell);
						pChar_target->m_auraDuration = spellInfo.Duration/1000;
						pChar_target->m_absorbDuration = spellInfo.Duration/1000;
						pChar_target->m_absorbspell = spell;
						uint32 mana = pClient->getCurrentChar()->getUpdateValue( UNIT_FIELD_POWER1 );
						pClient->getCurrentChar( )->setUpdateValue( UNIT_FIELD_POWER1, mana-spellInfo.ManaCost );


						data.clear();
						data.Initialise( 36 , SMSG_SPELL_START);
						data << pguid << pguid << spell << flags;
						data << spellInfo.CastTime << flags;
						data << (uint64)target;
//						pClient->getCurrentChar()->SendMessageToSet(&data, true);
		                world.SendAreaMessage(&data, pClient, 1);

						data.clear();		
						data.Initialise( 5, SMSG_CAST_RESULT );
						data << spell << uint8(0x01);
						pClient->SendMsg( &data );
						
						data.clear();
						data.Initialise( 42, SMSG_SPELL_GO);
						data << pguid << pguid << spell << flags;
						data << uint8( 0x01 );
						data << (uint64)target << uint8( 0 );
						data << flags << (uint64)target;
//						pClient->getCurrentChar()->SendMessageToSet(&data, true);
		                world.SendAreaMessage(&data, pClient, 1);
					}
					else
					{
						data.clear();		
						data.Initialise( 6, SMSG_CAST_RESULT );
						data << spell << uint8( 0x02);
						data << uint8( 5 );
						pClient->SendMsg( &data );
					}
				} 
				else if(spellInfo.spell_type == (uint32)MANA_SHIELD) 
				{
					// Mana Shield
					uint64 pguid = pClient->getCurrentChar()->getGUID();
					Character * pChar_target = world.GetCharacter((uint32)pguid);
					if( pChar_target )
					{
						setAura(pChar_target, spell);
						pChar_target->m_auraDuration = 10;
						pChar_target->m_shieldDuration = spellInfo.Duration/1000;
						pChar_target->m_shieldspell = spell;
						printf("shieldspell: %u\n", pChar_target->m_shieldspell);
						uint32 mana = pClient->getCurrentChar()->getUpdateValue( UNIT_FIELD_POWER1 );
						pClient->getCurrentChar( )->setUpdateValue( UNIT_FIELD_POWER1, mana-spellInfo.ManaCost );

						data.clear();
						data.Initialise( 28 , SMSG_SPELL_START);
						data << pguid << pguid << spell << flags;
						data << spellInfo.CastTime << uint16(0);
//						pClient->getCurrentChar()->SendMessageToSet(&data, true);
		                world.SendAreaMessage(&data, pClient, 1);

						data.clear();		
						data.Initialise( 5, SMSG_CAST_RESULT );
						data << spell << uint8( 0x01);
						pClient->SendMsg( &data );

						data.clear();
						data.Initialise( 34, SMSG_SPELL_GO);
						data << pguid << pguid << spell << flags;
						data << uint8( 0x01 );
						data << (uint64)pguid << uint8( 0 );
						data << uint16(0);
//						pClient->getCurrentChar()->SendMessageToSet(&data, true);
		                world.SendAreaMessage(&data, pClient, 1);
					}
					else
					{
						data.clear();		
						data.Initialise( 6, SMSG_CAST_RESULT );
						data << spell << uint8( 0x02);
						data << uint8( 5 );
						pClient->SendMsg( &data );
					}
				} 
				else if(spellInfo.spell_type == (uint32)SUMMON) 
				{ // Summons
					uint32 petGUID,guid,guid2;
					
					if(pClient->getCurrentChar()->getUpdateValue(UNIT_FIELD_SUMMON) != 0)
					{ 
						guid = pClient->getCurrentChar()->getUpdateValue(UNIT_FIELD_SUMMON); 
                        Unit* old_summon = world.GetCreature(guid); 
                        if( old_summon )
						{ 
							guid2 = old_summon->getUpdateValue(OBJECT_FIELD_GUID+1); 
							data.clear(); 
							data.Initialise(8, SMSG_DESTROY_OBJECT); 
							data << (uint32)guid << uint32(guid2); 
//							pClient->getCurrentChar()->SendMessageToSet(&data, true); 
			                world.SendAreaMessage(&data, pClient, 1);
    
							std::map<uint32, Unit*>::iterator itr = world.mCreatures.find(guid); 
							for( WorldServer::CharacterMap::iterator iter = world.mCharacters.begin( ); iter != world.mCharacters.end( ); ++ iter ) 
								iter->second->RemoveInRangeObject( itr->second ); 
    
                            delete itr->second; 
   							world.mCreatures.erase(itr); 
    
							DatabaseInterface *dbi = Database::getSingleton( ).createDatabaseInterface( ); 
							char sql[512]; 
							sprintf(sql, "DELETE FROM creatures WHERE id=%u", guid); 
							dbi->doQuery(sql); 
							Database::getSingleton( ).removeDatabaseInterface(dbi); 
						}
						else 
							pClient->getCurrentChar()->setUpdateValue(UNIT_FIELD_SUMMON, 0); 
					} 

					char* pName = "Imp";
					petGUID = PetCreature(pClient, pName);

					data.clear();
					data.Initialise(38, SMSG_SPELL_GO);
					data << (uint64)pguid << (uint64)pguid << spell;
					data << uint16(01) << uint8(0) << uint8(0);
					data << uint16(0040);
					data << (uint32)pClient->getCurrentChar()->getPositionX();
					data << (uint32)pClient->getCurrentChar()->getPositionY();
					data << (uint32)pClient->getCurrentChar()->getPositionZ();
					pClient->SendMsg(&data);

					data.clear();
					data.Initialise(5, SMSG_CAST_RESULT);
					data << spell << uint8(0x00);
					pClient->SendMsg(&data);

					data.clear();
					data.Initialise(24, SMSG_SPELLLOGEXECUTE);
					data << (uint64)pguid << spell;
					data << uint32(0x00000038) << uint32(0x00000001) << uint32(0x00000001);
					pClient->SendMsg(&data);

					pClient->getCurrentChar()->setUpdateValue(ITEM_FIELD_CONTAINED, petGUID);
					pClient->getCurrentChar()->setUpdateValue(UNIT_FIELD_SUMMON, petGUID);
					pClient->getCurrentChar()->setUpdateValue(GAMEOBJECT_ROTATION, petGUID);
					pClient->getCurrentChar()->setUpdateValue(DYNAMICOBJECT_BYTES, petGUID);
					pClient->getCurrentChar()->setUpdateValue(CORPSE_FIELD_FACING, petGUID);
					pClient->getCurrentChar()->setUpdateValue(UNIT_FIELD_SUMMON+1, 0xeeeeeeee);
					pClient->getCurrentChar()->setUpdateValue(GAMEOBJECT_ROTATION+1, 0xeeeeeeee);
					pClient->getCurrentChar()->setUpdateValue(DYNAMICOBJECT_SPELLID, 0xeeeeeeee);

					data.clear();
					data.Initialise(62, SMSG_PET_SPELLS);
					data << (uint64)petGUID << uint32(0x00000101) << uint32(0x00000000) << uint32(0x07000001) << uint32(0x07000002);
					data << uint32(0x02000000) << uint32(0x07000000) << uint32(0x04000000) << uint32(0x03000000) << uint32(0x06000002) << uint32(0x05000000);
					data << uint32(0x06000000) << uint32(0x06000001) << uint32(0xa30c2602) << uint16(0x0018);
					pClient->SendMsg(&data);
				}
				else if(spellInfo.spell_type == (uint32)POTIONS) 
				{ // Potions
							// USE THIS ONLY FOR DEBUGGING
				}
				else if(spell == 120 || spell == 8492)
				{ //
					float xM = pClient->getCurrentChar()->getPositionX();
					float yM = pClient->getCurrentChar()->getPositionY();
					float zM = pClient->getCurrentChar()->getPositionZ();
					float offnung = 180;
					float drehung = (pClient->getCurrentChar()->getOrientation()*60);

					int templen = 0;
					uint8 targetCount = 0;
					uint16 targets = flags;
					wowWData tmpData;
					float dist = 0;
					//char targetString[0x80];
					
					tmpData.Initialise(100, SMSG_SPELL_START);
					tmpData << pguid << uint32( 0 ) << pguid << uint32( 0 ) << spell;
					tmpData << flags << uint32 ( 0 ) << flags;

					data.Initialise(28 + templen,SMSG_SPELL_START);
					memcpy(data.data, tmpData.data,28+templen );
//					world.SendAreaMessage(&data,pClient,1);
                    pClient->getCurrentChar()->SendMessageToSet(&data, true);

					wowWData tmpSpellGo;

					data.clear();		
		   			tmpSpellGo.Initialise( 500, SMSG_SPELL_GO );
		       	    tmpSpellGo << pguid << uint32( 0 ) << pguid << uint32( 0 );
		       	    tmpSpellGo << spell;
					tmpSpellGo << uint8(0) << uint8(1);
					//tmpSpellGo << uint16(0x0110);
					tmpSpellGo << uint8(targetCount); //temp

					WorldServer::CreatureMap::iterator itr;
					for (itr = world.mCreatures.begin(); itr != world.mCreatures.end(); ++itr)
					{
						if (( itr->second->isAlive() ) && (!itr->second->isPlayer()))
						{
							float xP = itr->second->getPositionX();
							float yP = itr->second->getPositionY();
							float zP = itr->second->getPositionZ();
							if (inbogen( 10,  xM, yM, zM, offnung, drehung, xP, yP,zP ))
							{
								printf("target is in range\n");
								if (itr->second->getZone() == pClient->getCurrentChar()->getZone()) 
								{
									if (applySpell(pClient, itr->second , spell , spellInfo)) 
									{
										printf("target is in range\n");
										targetCount++;
										tmpSpellGo << itr->second->getGUID() << itr->second->getGUIDHigh();
									}
								}
							}
						}
					}
					memcpy(tmpSpellGo.data + 22, &targetCount ,1);
					tmpSpellGo << uint8(0) << uint16(targets);
					data.Initialise(26 + 8*targetCount + templen,SMSG_SPELL_GO);
					memcpy(data.data, tmpSpellGo.data, 26 + 8*targetCount + templen);
//					world.SendAreaMessage(&data,pClient,1);
                    pClient->getCurrentChar()->SendMessageToSet(&data, true);
					uint32 mana = pClient->getCurrentChar()->getUpdateValue( UNIT_FIELD_POWER1 );
					pClient->getCurrentChar( )->setUpdateValue( UNIT_FIELD_POWER1, mana-spellInfo.ManaCost );
					data.Initialise( 5, SMSG_CAST_RESULT );
			        data << spell << uint8( 0x01);
			        pClient->SendMsg( &data );		
				}
			}break;
	default: {}break;
    }
}

int SpellHandler::setAura(Unit *pUnit, uint32 spell)
{
    //return 1;  // test
	uint8 tmpStore = 0x00;
	int found = -1,found2 = -1;
	uint32 auraValue;
	int i;
	for( i = 0; (i < 10) && (found == -1); i++) {
		if (!(pUnit->getUpdateValue(UNIT_FIELD_AURALEVELS + i) == 0xeeeeeeee)) {
			found = i;	
		}
	}
	if (found == -1)
		return 0;
	auraValue = pUnit->getUpdateValue(UNIT_FIELD_AURALEVELS + found);

	for( i = 0; (i < 4) && (found2 == -1); i++)
	{
		if ((uint8)*(&auraValue + i) != 0xee) {
			found2 = i;
			memcpy(&auraValue + i,&tmpStore,1);
		}
	}
	pUnit->setUpdateValue(UNIT_FIELD_AURALEVELS + found, auraValue);
	pUnit->setUpdateValue(UNIT_FIELD_AURAAPPLICATIONS + found, auraValue);
	pUnit->setUpdateValue(UNIT_FIELD_AURA + found*4 + found2, uint32(spell));
	pUnit->m_aura_found = found;
	pUnit->m_aura_found2 = found2;
	return 1;
}



int SpellHandler::applySpell( GameClient *pClient, Unit *target, uint32 spell, SpellInformation spellInfo)
{
	uint32 damage;
	uint32 absorb = 0;
	//freezetime = 1 + rand()%9;
	damage = spellInfo.DmgPlus1+rand()%spellInfo.RandomPercentDmg;
	world.mCombatHandler.AttackerStateUpdate(pClient->getCurrentChar( ), world.getCreatureMap( )[ target->getGUID() ], damage);

	//setAura(target, spell);
	return 1;
}




////////////////////////////// heal / mana potions and eating (lasts over time) - by nothin ///////
int SpellHandler::usePotion(GameClient *pClient, uint32 spell, SpellInformation spellInfo, uint32 targets){

	wowWData data;
	uint32 update_rep,max_rep,add_rep;
			        	    
	data.clear();
	data.Initialise( 5, SMSG_READ_ITEM_OK );
	data << spell << uint8( 0x01);
	pClient->SendMsg( &data );
	uint32 pguid = pClient->getCurrentChar()->getGUID();

	update_rep = pClient->getCurrentChar( )->getUpdateValue( spellInfo.replenish_type );	// get needed data
	max_rep = pClient->getCurrentChar( )->getUpdateValue( spellInfo.replenish_type+6 );		// get needed data
		if(spellInfo.EQ == 196608 ){ // Im using this for looking if its a mana/healing potion

			add_rep = spellInfo.DmgPlus1+rand()%spellInfo.RandomPercentDmg;							// get needed data
			if(update_rep==max_rep)
			{
				data.clear();	
  				data.Initialise( 6, SMSG_CAST_RESULT );
  				data << spell << uint8( 0x02);
				data << uint8( 4 );
  				pClient->SendMsg( &data );
			}else{
			if( update_rep+add_rep>max_rep )
			{
				add_rep=max_rep-update_rep;
			}

			pClient->getCurrentChar( )->setUpdateValue( spellInfo.replenish_type, update_rep+add_rep ); // Add the value

			data.clear();		
  			data.Initialise( 5, SMSG_CAST_RESULT );
  			data << spell << uint8( 0x01);
  			pClient->SendMsg( &data );
			}
		}
		else if(spellInfo.EQ == 65538){ // Im using this for looking if its a drink/eat stuff which needs sitting
			if ((pClient->getCurrentChar()->getUpdateValue(UNIT_FIELD_BYTES_1) & 0xff) == 1) // check if player is sitting
			{
				if(update_rep == max_rep && spellInfo.replenish_type == 20)
				{

					data.clear();	
  					data.Initialise( 6, SMSG_CAST_RESULT );
  					data << spell << uint8( 0x02);
					data << uint8( 17 );
  			 		pClient->SendMsg( &data );

				}else if(update_rep == max_rep && spellInfo.replenish_type == 21)
				{
					data.clear();
  			 		data.Initialise( 6, SMSG_CAST_RESULT );
  			 		data << spell << uint8( 0x02);
					data << uint8( 42 );
  			 		pClient->SendMsg( &data );
				}else
				{
					uint32 rep_value = spellInfo.DmgPlus1+rand()%spellInfo.RandomPercentDmg/spellInfo.Duration;

					pClient->getCurrentChar()->m_healingDuration = spellInfo.Duration; // Set duration
					pClient->getCurrentChar()->m_replenish_field = spellInfo.replenish_type; // Mana or Life ?
					pClient->getCurrentChar()->m_replenish_value = rep_value; // How much to replenish ?
					pClient->getCurrentChar()->m_spell			 = spell;

					data.clear();	
  			 		data.Initialise( 5, SMSG_CAST_RESULT );
  			 		data << spell << uint8( 0x01);
  			 		pClient->SendMsg( &data );
				}
			}

		}
	return 1;
}
///////////////////////////////////////////////////////////////////////////////////////////////////


float SpellHandler::CalcDistance(float sx, float sy, float sz, float dx, float dy, float dz)
{
	float dist = sqrt((dx-sx)*(dx-sx)+(dy-sy)*(dy-sy)+(dz-sz)*(dz-sz));
	return dist;
}

float SpellHandler::CalcDistance2d( float xe, float ye, float xz, float yz )
{
	return sqrt( ( xe - xz ) * ( xe - xz ) + ( ye - yz ) * ( ye - yz ) );
}

float SpellHandler::getwinkel( float xe, float ye, float xz, float yz )
{
	float w;
	w = atan( ( yz - ye ) / ( xz - xe ) );
	w = ( w / DEG2RAD );
	if (xz>=xe) {
		w = 90+w;
	} else {
		w = 270+w;
	}
	return w;
}

float SpellHandler::geteinfachererwinkel( float winkel )
{
	while ( winkel < 0 ) {
		winkel = winkel + 360;
	}
	while ( winkel >= 360 ) {
		winkel = winkel - 360;
    }
	return winkel;
}

bool SpellHandler::inbogen( float radius,  float xM, float yM, float zM,float offnung, float drehung, float xP, float yP, float zP )
// <radius> <xPositionCaster> <yPositionCaster> <angleFromNULLAxisToRadius> <Angle> <xPositionTarget> <yPositionTarget>
{
	abstand = CalcDistance(xM,yM,zM,xP,yP,zP);
	winkel = getwinkel( xM, zM, xP, zP );
	lrand = geteinfachererwinkel( ( drehung - (offnung/2) ) );
	rrand = geteinfachererwinkel( ( drehung + (offnung/2) ) );

	if(radius>=abstand &&( ( winkel >= lrand ) &&
						( winkel <= rrand ) ||
						( lrand > rrand && ( winkel < rrand || winkel > lrand ) ) ) ) {
		return true;
	} else {
		return false;
	}
}

uint32 SpellHandler::PetCreature(GameClient *pClient, char* pName) 
{ 
    wowWData data; 
   uint32 level = 20; 
    // Create the requested monster 

    Character *chr = pClient->getCurrentChar(); 
    float x = chr->getPositionX(); 
    float y = chr->getPositionY(); 
    float z = chr->getPositionZ(); 
    float o = chr->getOrientation(); 

   //# 
   // Boog test to set creature lvl better 
   uint32 p_level = chr->getUpdateValue(UNIT_FIELD_LEVEL); 
   uint32 c_level = p_level*1.25; 
   uint32 c_name = 416; //set default name to Imp; 
   uint32 c_displayid = 4449; //set Pet to be an Imp by default; 
    uint32 p_class = chr->getClass(); 
   if(p_class==HUNTER){ 
         c_displayid=247; //display as Brown Dire Wolf 
         c_name=5449;// set name to Tamed Wolf 
      } 
   if(p_class==DRUID) 
      { 
         c_displayid=2289; //display as Tauren Druid Bear 
         c_name=5433;// set name to Tamed Bear 
      } 
   if(p_class==MAGE) 
      { 
         c_displayid=1130; //display as VoidWalker 
         c_name=5676;// set name to Summoned VoidWalker 
      } 


   level=c_level; 

    Unit* pUnit = new Unit(); 
   pUnit->setPet(); 
    UpdateMask unitMask; 
    WorldServer::getSingletonPtr()->mObjectMgr.SetCreateUnitBits(unitMask); 

    pUnit->Create(world.m_hiCreatureGuid++, (uint8*)pName, x, y, z, o); 
    pUnit->setMapId(chr->getMapId()); 
    pUnit->setZone(chr->getZone()); 
   data.clear(); 
   pUnit->setUpdateValue(GAMEOBJECT_TYPE_ID,28); 
   pUnit->setUpdateValue(OBJECT_FIELD_ENTRY, world.addCreatureName((uint8*)pUnit->getCreatureName())); 
    pUnit->setUpdateValue(OBJECT_FIELD_TYPE,9); 
    pUnit->setUpdateValue(OBJECT_FIELD_ENTRY,c_name); 
    pUnit->setUpdateValue(OBJECT_FIELD_PADDING,0xeeeeeeee); 
    pUnit->setUpdateValue(UNIT_FIELD_SUMMONEDBY,pClient->getCurrentChar()->getGUID()); 
    pUnit->setUpdateValue(UNIT_FIELD_SUMMONEDBY+1,0); 
    pUnit->setUpdateValue(UNIT_FIELD_CREATEDBY,pClient->getCurrentChar()->getGUID()); 
    pUnit->setUpdateValue(UNIT_FIELD_HEALTH,30+20*level); 
    pUnit->setUpdateValue(UNIT_FIELD_POWER1,1100); 
    pUnit->setUpdateValue(UNIT_FIELD_POWER5,460000); 
    pUnit->setUpdateValue(UNIT_FIELD_MAXHEALTH,100+30*level); 
    pUnit->setUpdateValue(UNIT_FIELD_MAXPOWER1,110); 
    pUnit->setUpdateValue(UNIT_FIELD_MAXPOWER5,460000); 
    pUnit->setUpdateValue(UNIT_FIELD_LEVEL,level); 
    pUnit->setUpdateValue(UNIT_FIELD_FACTIONTEMPLATE,1); 
   pUnit->setUpdateValue(UNIT_NPC_FLAGS , 0); 
   pUnit->setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 0.5f); 
    pUnit->setUpdateValue(UNIT_FIELD_BYTES_0,2048); 
    pUnit->setUpdateValue(UNIT_FIELD_FLAGS,0); 
    
    pUnit->setUpdateValue(UNIT_FIELD_AURA,6307); 
    pUnit->setUpdateValue(UNIT_FIELD_AURALEVELS,   0x6EEEEEE); 
    pUnit->setUpdateValue(UNIT_FIELD_AURALEVELS+2, 0xeeeeeeee); 
    pUnit->setUpdateValue(UNIT_FIELD_AURALEVELS+3, 0xeeeeeeee); 
    pUnit->setUpdateValue(UNIT_FIELD_AURALEVELS+4, 0xeeeeeeee); 
    pUnit->setUpdateValue(UNIT_FIELD_AURALEVELS+5, 0xeeeeeeee); 
    pUnit->setUpdateValue(UNIT_FIELD_AURALEVELS+6, 0xeeeeeeee); 
    pUnit->setUpdateValue(UNIT_FIELD_AURALEVELS+7, 0xeeeeeeee); 
    pUnit->setUpdateValue(UNIT_FIELD_AURALEVELS+8, 0xeeeeeeee); 
    pUnit->setUpdateValue(UNIT_FIELD_AURALEVELS+9, 0xeeeeeeee); 
    pUnit->setUpdateValue(UNIT_FIELD_AURAAPPLICATIONS,0xeeeeeeee); 
    pUnit->setUpdateValue(UNIT_FIELD_AURAAPPLICATIONS+1,0xeeeeeeee); 
    pUnit->setUpdateValue(UNIT_FIELD_AURAAPPLICATIONS+2,0xeeeeeeee); 
    pUnit->setUpdateValue(UNIT_FIELD_AURAAPPLICATIONS+3,0xeeeeeeee); 
    pUnit->setUpdateValue(UNIT_FIELD_AURAAPPLICATIONS+4,0xeeeeeeee); 
    pUnit->setUpdateValue(UNIT_FIELD_AURAAPPLICATIONS+5,0xeeeeeeee); 
    pUnit->setUpdateValue(UNIT_FIELD_AURAAPPLICATIONS+6,0xeeeeeeee); 
    pUnit->setUpdateValue(UNIT_FIELD_AURAAPPLICATIONS+7,0xeeeeeeee); 
    pUnit->setUpdateValue(UNIT_FIELD_AURAAPPLICATIONS+8,0xeeeeeeee); 
    pUnit->setUpdateValue(UNIT_FIELD_AURAAPPLICATIONS+9,0xeeeeeeee); 
    pUnit->setUpdateValue(UNIT_FIELD_AURAFLAGS,8); 
    
    pUnit->setUpdateValue(UNIT_FIELD_BASEATTACKTIME,2000); 
    pUnit->setUpdateValue(UNIT_FIELD_BASEATTACKTIME+1,2000); 
    pUnit->setUpdateFloatValue(UNIT_FIELD_BOUNDINGRADIUS,1.0f); 
    pUnit->setUpdateFloatValue(UNIT_FIELD_COMBATREACH,1.0f); 
    pUnit->setUpdateValue(UNIT_FIELD_DISPLAYID,c_displayid); // Changed to be set based on summoning class 
    pUnit->setUpdateFloatValue(UNIT_FIELD_MINDAMAGE,7.0f); 
    pUnit->setUpdateFloatValue(UNIT_FIELD_MAXDAMAGE,10.0f); 
    
    pUnit->setUpdateValue(UNIT_FIELD_BYTES_1,0); 
    pUnit->setUpdateValue(UNIT_FIELD_PETNUMBER,14791); 
    pUnit->setUpdateValue(UNIT_FIELD_PET_NAME_TIMESTAMP,5); 
    pUnit->setUpdateValue(UNIT_FIELD_PETEXPERIENCE,0); 
    pUnit->setUpdateValue(UNIT_FIELD_PETNEXTLEVELEXP,1000); 
    pUnit->setUpdateValue(UNIT_CREATED_BY_SPELL,688); 
    
    pUnit->setUpdateValue(UNIT_FIELD_STAT0,22); 
    pUnit->setUpdateValue(UNIT_FIELD_STAT1,22); 
    pUnit->setUpdateValue(UNIT_FIELD_STAT2,25); 
    pUnit->setUpdateValue(UNIT_FIELD_STAT3,28); 
    pUnit->setUpdateValue(UNIT_FIELD_STAT4,27); 
    pUnit->setUpdateValue(UNIT_FIELD_RESISTANCES+0,0); 
    pUnit->setUpdateValue(UNIT_FIELD_RESISTANCES+1,0); 
    pUnit->setUpdateValue(UNIT_FIELD_RESISTANCES+2,0); 
    pUnit->setUpdateValue(UNIT_FIELD_RESISTANCES+3,0); 
    pUnit->setUpdateValue(UNIT_FIELD_RESISTANCES+4,0); 
    pUnit->setUpdateValue(UNIT_FIELD_RESISTANCES+5,0); 
    pUnit->setUpdateValue(UNIT_FIELD_RESISTANCES+6,0); 
    pUnit->setUpdateValue(UNIT_FIELD_ATTACKPOWER,24); 
    pUnit->setUpdateValue(UNIT_FIELD_BASE_MANA,140); 
    
   pUnit->m_pet_state = 1; 
   pUnit->CreateObject(&unitMask, &data, 0); 
    // add to the world list of creatures 
    WPAssert( pUnit->getGUID() != 0 ); 
    world.mCreatures[pUnit->getGUID()] = pUnit; 

    // send create message to everyone 
//    world.SendGlobalMessage(&data); 
   world.SendUnitAreaMessage(&data, pUnit); 

    DatabaseInterface *dbi = Database::getSingleton( ).createDatabaseInterface( ); 
    dbi->saveCreature(pUnit);                    
    Database::getSingleton( ).removeDatabaseInterface(dbi); 

   return pUnit->getUpdateValue(OBJECT_FIELD_GUID); 
} 