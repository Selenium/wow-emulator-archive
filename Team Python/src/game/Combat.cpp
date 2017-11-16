// Copyright (C) 2004 Team Python
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

#include "Combat.h"
#include "NetworkInterface.h"
#include "Log.h"
#include "GameClient.h"
#include "Opcodes.h"
#include "Character.h"
#include "WorldServer.h"
#include "UpdateMask.h"
#include "Stats.h"
#include "math.h"

#define world WorldServer::getSingleton()

void CombatHandler::HandleMsg( wowWData & recv_data, GameClient *pClient )
{
    wowWData data;
    char f[256];
    sprintf(f, "WORLD: Combat Opcode 0x%.4X from %u", recv_data.opcode, pClient->getCurrentChar()->getGUID());
    Log::getSingleton( ).outString( f );
    switch (recv_data.opcode)
    {
        case CMSG_ATTACKSWING:
	    {
            uint32 mguid[2], pguid;
		    pguid = pClient->getCurrentChar()->getGUID();
            recv_data >> mguid[0] >> mguid[1];

		    // AttackSwing
            Log::getSingleton( ).outString( "WORLD: Recvd CMSG_ATTACKSWING Message" );

            Unit *pEnemy;

            if(world.mCreatures.find(mguid[0]) == world.mCreatures.end() ||
                ((pEnemy = world.mCreatures[mguid[0]])->getGUIDHigh() != mguid[1]))
            {
                Log::getSingleton( ).outString( "WORLD: Can't attack character" );
                break; // we do not attack PCs for now
            }

            pClient->getCurrentChar()->addStateFlag(UF_ATTACKING);
            pClient->getCurrentChar()->setCombat(true);
            smsg_AttackStart(pClient->getCurrentChar(), pEnemy);
        }break;

    case CMSG_ATTACKSTOP:
	    {
		    uint32 mguid[2];
            mguid[0] = *(pClient->getCurrentChar()->getSelectionPtr());
            mguid[1] = *(pClient->getCurrentChar()->getSelectionPtr()+1);
            smsg_AttackStop((Unit*)pClient->getCurrentChar(), mguid);

            pClient->getCurrentChar()->setCombat(false);
            pClient->getCurrentChar()->clearStateFlag(UF_ATTACKING);
//            pClient->getCurrentChar()->removeUnitFlag(0x00080000);
	    }break;
    }
}


//================================================================================================
//  AttackerStateUpdate
//  This function determines whether there is a hit, and the resultant damage
//================================================================================================
void CombatHandler::AttackerStateUpdate(Unit *pAttacker, Unit *pVictim, int32 damage)
{
    if (pVictim->getUpdateValue(UNIT_FIELD_HEALTH) == 0 || 
        pAttacker->getUpdateValue(UNIT_FIELD_HEALTH) == 0 ) 
        return;
	pVictim->setCombat(true);
	pAttacker->setCombat(true);
    wowWData data;
	uint32 absorb = 0;
	uint32 shield = 0;
	uint32 mana_dmg = 0;
	uint32 critiq = 0;
    uint32 hit_status = 0xe2;

	if(damage == 0)
	{
		damage = CalculateDamage(pAttacker);

		// weaker attack for mobs lvl+ player
		if (pAttacker->getUpdateValue(PLAYER_NEXT_LEVEL_XP) != NULL && damage) {
			//printf("Ataque do PLAYER %u - Dmg: %u\n", pAttacker->getGUID() ,damage);
			int lvl_diff = (pVictim->getUpdateValue(UNIT_FIELD_LEVEL) - pAttacker->getUpdateValue(UNIT_FIELD_LEVEL));
			if (lvl_diff == 1) {
				damage -= 2;
			}
			else if (lvl_diff == 2) {
		        damage = damage/2;
			}
			else if (lvl_diff >=2) {
			damage = rand()%3;
			}
			// set player as mob 'owner'
			uint32 hp = pVictim->getUpdateValue(UNIT_FIELD_HEALTH);
			uint32 maxhp = pVictim->getUpdateValue(UNIT_FIELD_MAXHEALTH);
			if ((hp < maxhp*.8) && (hp > maxhp*.5))
				pVictim->setkillerGUID(pAttacker->getGUID());
//				printf("\n\nuhuuuuu!!! attackerGUID: %u\n\n", pAttacker->getGUID());
//		if (health < 80%) && (health > 50%) 
//		setkillerGUID(uint32 guid)

		}
		if (damage < 0) {
			damage = 0;
		}
			//printf("Damage changed to %u\n", damage);
	}// get absorb/shield stuff

	if(pAttacker->getGUIDHigh() == 0 ) //if player
	{
		uint8 agi = pAttacker->getUpdateValue(UNIT_FIELD_STAT1);
//		if( rand()%(agi) > (rand()%pAttacker->getLevel()+agi/2) ) critiq = pAttacker->getLevel()/2+1;
		if ((agi) && ( rand()%(agi) > (rand()%pAttacker->getLevel()+agi/2))) damage *= 1.5;
//		printf("Critical changed to %u\n", critiq);
	}
	if(pVictim->m_absorb == 1)
	{
		//printf("ok we will absorb some dmg\n");
		SpellInformation spellInfo;
		DatabaseInterface *dbi = Database::getSingleton().createDatabaseInterface(); //get a hook for the DB
		spellInfo = dbi->GetSpellInformation ( pVictim->m_absorbspell ); //returns a SpellInformation object/struct
		absorb = spellInfo.DmgPlus1;
		Database::getSingleton().removeDatabaseInterface( dbi ); //clean up used resources
	}
	if(pVictim->m_shield == 1)
	{
		//printf("ok we will shield some dmg\n");
		SpellInformation spellInfo;
		DatabaseInterface *dbi = Database::getSingleton().createDatabaseInterface(); //get a hook for the DB
		spellInfo = dbi->GetSpellInformation ( pVictim->m_shieldspell ); //returns a SpellInformation object/struct
		shield = spellInfo.DmgPlus1;
		Database::getSingleton().removeDatabaseInterface( dbi ); //clean up used resources
	}
	//START OF LINA
	if(pVictim->getUpdateValue(UNIT_FIELD_RESISTANCES)>0)
	{
		uint32 armor=pVictim->getUpdateValue(UNIT_FIELD_RESISTANCES);

		absorb += armor;
	}
	//END OF LINA

	// absorb damage if damage absorb is activated
	int32 absorbed=0;
	if( absorb > 0 )
	{
		//absorbed = (uint32)((float)damage/float(100)*(float(100)-(float)absorb));
		absorbed = (uint32)damage-absorb*absorb/2000;
		if(absorbed < 0) //if armor absorbe all damage
		{
			absorb = damage-1;	//absorb all - 1
			absorbed = 1;		//set receive damage to 1
		}
		else 
		{
			absorb = damage-absorbed; //set absorb to the correct value
		}
	}
	else //if no armor
	{
		absorbed=damage; //give full damage to user 
	}

	
	/*
	// absorb damage if damage absorb is activated
	uint32 absorbed = (float)damage/float(100)*(float(100)-(float)absorb);
	absorb = absorbed-damage;
	if(absorbed > damage)
		absorbed = 1;
	if(absorb < 0)
		absorb = 0;
	*/

	// use mana shield if activated
	if(pVictim->m_shield)
	{
		uint32 mana = pVictim->getUpdateValue(UNIT_FIELD_POWER1);
		if(mana < shield)
		shield = pVictim->getUpdateValue(UNIT_FIELD_POWER1);

		if(absorbed-shield > absorbed)
		{// happens if shield is bigger then absorbed and that would make a char unplayable
			mana_dmg = absorbed-1;
			absorbed = 1;
			absorb = mana_dmg;
		//printf("#1 mana_dmg is %u and absorbed is %u\n", mana_dmg,absorbed);
		}
		else
		{
			absorbed = absorbed-shield;
			mana_dmg = shield;
			absorb = mana_dmg;
			//printf("#2 mana_dmg is %u and absorbed is %u\n", mana_dmg,absorbed);
		}
		pVictim->setUpdateValue(UNIT_FIELD_POWER1,mana-mana_dmg);// if mana_dmg is >0 then absorb it or leave it as it is
	}
/*
    uint32 some_value = 0xffffffff;
    some_value = 0x0;
*/
    data.clear();
    data.Initialise(61, SMSG_ATTACKERSTATEUPDATE);
    data.writeData( hit_status );   // Attack flags
    data.writeData( pAttacker->getGUID() );
    data.writeData( pAttacker->getGUIDHigh() );
    data.writeData( pVictim->getGUID() );
    data.writeData( pVictim->getGUIDHigh() );
    data.writeData( absorbed );		// damage
    data.writeData( uint8(1) );     // Damage type counter
    // for each...
    data.writeData( uint32(0) );    // Damage type, // 0 - white font, 1 - yellow
    data.writeData( uint32(0x0) );  // damage float
    data.writeData( damage );       // Damage amount damage
    data.writeData( absorb );		// damage absorbed

    data.writeData( uint32(1) );    // new victim state
    data.writeData( uint32(0) );    // victim round duration
    data.writeData( uint32(0) );    // additional spell damage amount
    data.writeData( uint32(0) );    // additional spell damage id
    data.writeData( shield );    // Damage amount blocked

    pAttacker->SendMessageToSet(&data, true);
    //printf("AttackerStateUpdate:  %u attacked %u for %u dmg-%u absorb=%u absorbed (shield %u).\n", pAttacker->getGUID(), pVictim->getGUID(), damage, absorb, absorbed, shield);
    DealDamage(pAttacker, pVictim, absorbed);
}


void CombatHandler::smsg_AttackStop(Unit* pAttacker, uint32 victim_guid[2])
{
	uint32 attacker_guid[2];
	attacker_guid[0] = pAttacker->getGUID();
	attacker_guid[1] = pAttacker->getGUIDHigh();
	wowWData data;
    data.Initialise( 20, SMSG_ATTACKSTOP );
    data << attacker_guid[0] << attacker_guid[1] << victim_guid[0] << victim_guid[1] << uint32( 0 );
//    world.SendUnitAreaMessage(&data, pAttacker);
    pAttacker->SendMessageToSet(&data, true);
    printf("%u stopped attacking %u\n", attacker_guid[0], victim_guid[0]);

	// Changed by nothin
	if(pAttacker->getUpdateValue(UNIT_FIELD_SUMMONEDBY) != 0)
	{
		pAttacker->m_creatureState = STOPPED;
	}

}

void CombatHandler::smsg_AttackStart(Unit* pAttacker, Unit* pVictim)
{
	//check if victim is close to attacker
	float dx, dy, dz, length, reach, radius;

	dx = pVictim->getPositionX() - pAttacker->getPositionX();
    dy = pVictim->getPositionY() - pAttacker->getPositionY();
    dz = pVictim->getPositionZ() - pAttacker->getPositionZ();
	length = sqrt((dx*dx) + (dy*dy) + (dz*dz)); //distance between you and mob
	radius = pVictim->getUpdateFloatValue(UNIT_FIELD_BOUNDINGRADIUS);
	reach = pAttacker->getUpdateFloatValue(UNIT_FIELD_COMBATREACH);

	if (length < reach + radius)
	{
		// Prevent user from ignoring attack speed and stopping and start combat really really fast
    if (pAttacker->isAttackReady())
    {
        AttackerStateUpdate(pAttacker, pVictim, 0);
        pAttacker->setAttackTimer();
    }

    // Send out ATTACKSTART
    wowWData data;
    data.clear();
    data.Initialise( 16, SMSG_ATTACKSTART );
    data << pAttacker->getGUID() << pAttacker->getGUIDHigh() << pVictim->getGUID() << pVictim->getGUIDHigh();
//    world.SendUnitAreaMessage(&data, pAttacker);  //probably global
    pAttacker->SendMessageToSet(&data, true);
    Log::getSingleton( ).outString( "WORLD: Sent SMSG_ATTACKSTART" );
	}
	else
	{
		pAttacker->clearStateFlag(UF_ATTACKING);
		pAttacker->setCombat(false);
		pVictim->setCombat(false);
}

// FLAGS changed so other players see attack animation
//    pAttacker->addUnitFlag(0x00080000);
//    pAttacker->setUpdateMaskBit(UNIT_FIELD_FLAGS );
}

void CombatHandler::DealDamage(Unit *pAttacker, Unit *pVictim, uint32 damage)
{
	Unit * pPetMaster;

    uint32 health = pVictim->getUpdateValue(UNIT_FIELD_HEALTH );
	pAttacker->setCombat(true);
	pVictim->setCombat(true);
    if (health <= damage)
    {
//		printf("ok now he is dead\n");

		pVictim->generateLoot();
        // victim died!
        pVictim->setDeathState(JUST_DIED);

        // Send SMSG_PARTYKILLLOG 0x1e6
        // To everyone in the party?

        // SMSG_ATTACKSTOP
        uint32 aguid[2], vguid[2];
        aguid[0] = pAttacker->getGUID();
        aguid[1] = pAttacker->getGUIDHigh();
        vguid[0] = pVictim->getGUID();
        vguid[1] = pVictim->getGUIDHigh();
        smsg_AttackStop(pVictim, aguid);

        // Send MSG_MOVE_ROOT   0xe7
		// if player, dismount
		if (pVictim->isPlayer()) {
			wowWData data;
			pVictim->setUpdateValue(UNIT_FIELD_MOUNTDISPLAYID , 0);
			pVictim->removeUnitFlag( 0x003000 );
			float dmspeed = 7.5; // Exact value of normal player speed
			data.Initialise( 12, SMSG_FORCE_SPEED_CHANGE );
	        data << pVictim->getUpdateValue( OBJECT_FIELD_GUID );
			data << pVictim->getUpdateValue( OBJECT_FIELD_GUID + 1 );
		    data << dmspeed;
	        pVictim->SendMessageToSet( &data, true );
		}

        // Set update values... try flags 917504
        // health
        pVictim->setUpdateValue(UNIT_FIELD_HEALTH, 0);
//        pVictim->setUpdateValue(UNIT_FIELD_POWER1, 0);

        // then another update message, sets health to 0, maxhealth to 100, and dynamic flags
        pVictim->setUpdateMaskBit(UNIT_FIELD_MAXHEALTH);
//		pVictim->setUpdateMaskBit(UNIT_FIELD_MAXPOWER1);
        pVictim->removeUnitFlag(0x00080000);

	
        if ( !pVictim->isPlayer() )
			pVictim->setUpdateValue(UNIT_DYNAMIC_FLAGS, 1);
        
		//LINA
		if( pAttacker->isPet() ) //if pet kill someone, give xp to summoner
		{
			printf("It's a PET, master %u!\n", pAttacker->getUpdateValue(UNIT_FIELD_SUMMONEDBY) );
			pPetMaster = world.GetCharacter( pAttacker->getUpdateValue(UNIT_FIELD_SUMMONEDBY) );
			if(!pPetMaster) 
			{
				pPetMaster=pAttacker;
			}

			smsg_AttackStop(pAttacker, vguid);
            pAttacker->removeUnitFlag(0x00080000);
            pAttacker->setUpdateMaskBit(UNIT_FIELD_FLAGS );
            pAttacker->addStateFlag(UF_TARGET_DIED);
		}
		else
			pPetMaster=pAttacker;
		uint32 killerGUID = pVictim->getkillerGUID();
		if ((killerGUID != pPetMaster->getGUID()) && killerGUID) {
			//printf("Roubo de XP!! Quem ganha eh: %u, nao %u!\n",  killerGUID, pPetMaster->getGUID());

			WorldServer::ClientSet::iterator itr;
			for (itr = world.mClients.begin(); itr != world.mClients.end(); itr++)
			{
				if (((GameClient*)(*itr))->IsInWorld()) {
					if (((GameClient*)(*itr))->getCurrentChar()->getGUID() == killerGUID)
						pPetMaster = ((GameClient*)(*itr))->getCurrentChar();
					continue;
					}
				}
			}

        if (pPetMaster->isPlayer())
		{
            uint32 xp = CalculateXpToGive(pVictim, pPetMaster);
            // check running quests in case this monster belongs to it
            uint32 entry = 0;
            if (!pVictim->isPlayer())
                entry = pVictim->getUpdateValue(OBJECT_FIELD_ENTRY );
            // Is this player part of a group? new by LeMMiNGS: only share xp with near party members, also no xp steal by group invite
			if (((Character*)pPetMaster)->IsInGroup()) {
				Group *pGroup = world.GetGroupByLeader(((Character*)pPetMaster)->GetGroupLeader());
				uint32 higherlvl=pPetMaster->getLevel(), num=0;
                for (uint32 c=0; c < pGroup->count; c++){
                    Character *pGroupGuy = world.mCharacters[pGroup->members[c].guid];
					if ( (world.CalcDistance( (Unit *)pPetMaster, (Unit *)pGroupGuy) < UPDATE_DISTANCE) && 
						(pPetMaster->getMapId() == (pGroupGuy->getMapId()))) {
						if (pGroupGuy->getLevel()>higherlvl) {
							higherlvl = pGroupGuy->getLevel();
				            xp = CalculateXpToGive(pVictim, pGroupGuy);
						}
					num++;
					}
				}
                //xp /= pGroup->count;
                xp /= num;
				if (num >1)
				  xp *= 1.2;

                for (uint32 c=0; c < pGroup->count; c++){
                    Character *pGroupGuy = world.mCharacters[pGroup->members[c].guid];
					if ( (world.CalcDistance( (Unit *)pPetMaster, (Unit *)pGroupGuy) < UPDATE_DISTANCE) && 
						(pPetMaster->getMapId() == (pGroupGuy->getMapId()  ))) {
		                    pGroupGuy->giveXP(xp, pVictim->getGUID(), pVictim->getGUIDHigh());
						}
					if (!pVictim->isPlayer())
                        pGroupGuy->KilledMonster(entry, pVictim->getGUID());
					pGroupGuy->setCombat(false);
				}
            }
            else
            {
                // update experience
                ((Character*)pPetMaster)->giveXP(xp, pVictim->getGUID(), pVictim->getGUIDHigh());
                if (!pVictim->isPlayer())
                    ((Character*)pPetMaster)->KilledMonster(entry, pVictim->getGUID());
				pPetMaster->setCombat(false);
            }
        }
        else
        {
            smsg_AttackStop(pAttacker, vguid);
            pAttacker->removeUnitFlag(0x00080000);
            pAttacker->setUpdateMaskBit(UNIT_FIELD_FLAGS );
            pAttacker->addStateFlag(UF_TARGET_DIED);

			//LINA
			if( pVictim->isPet() )//if npc kill a pet, attack summoner
			{
				pPetMaster = world.GetCharacter( pVictim->getUpdateValue(UNIT_FIELD_SUMMONEDBY) );
				if(pPetMaster) 
				{
					pAttacker->AI_ChangeState(ATTACKING); // when attacked mobs stop moving around
					pAttacker->AI_AttackReaction(pPetMaster, damage);
				}
			}
        }
    } 
	else 
	{
        pVictim->setUpdateValue(UNIT_FIELD_HEALTH , health - damage);

		// <WoW Chile Dev Team> Start Change
		// this need alot of work.

		///////////////// PET ATTACK THE ONE WHO ATTACKS ITS MASTER by nothin/////////
		if(pVictim->isPlayer())
		{
			if(pVictim->getUpdateValue(UNIT_FIELD_SUMMON) != 0)
			{
				petGUID = pVictim->getUpdateValue(UNIT_FIELD_SUMMON);
				Unit * pPet=world.GetCreature(petGUID);
				if(pPet)
				{
					if(pPet->m_pet_state != 0)
					{
						pPet->AI_ChangeState(ATTACKING);
						pPet->AI_AttackReaction(pAttacker, damage);
					}
				}
			}
		}
		/////////////////////////////////////////////////////////////////////////////
        else
		{	
				pVictim->AI_ChangeState(ATTACKING); // when attacked mobs stop moving around
				pVictim->AI_AttackReaction(pAttacker, damage);
			/*
			//uint32 max_health = getUpdateValue(UNIT_FIELD_MAXHEALTH);
			//uint32 health_porcent = (max_health*10)/100; // this if for know 10% of total healt,need changes about mobs lvls
			pVictim->AI_ChangeState(3); //if mob are attack then they stop moving around
            pVictim->AI_AttackReaction(pAttacker, damage);
						
			//well mobs scape if have a movement assignet atm
			//if(health<=health_porcent)
			{}
			*/
			
		}
		// <WoW Chile Dev Team> Start Change
    }
}
/*
void CombatHandler::Heal(Unit *pAttacker, Unit *pVictim, uint32 damage)
{
    uint32 health = pVictim->getUpdateValue(UNIT_FIELD_HEALTH );
    if (health <= damage)
    {
		pVictim->generateLoot();
        // victim died!
        pVictim->setDeathState(JUST_DIED);

        // Send SMSG_PARTYKILLLOG 0x1e6
        // To everyone in the party?

        // SMSG_ATTACKSTOP
        uint32 aguid[2], vguid[2];
        aguid[0] = pAttacker->getGUID();
        aguid[1] = pAttacker->getGUIDHigh();
        vguid[0] = pVictim->getGUID();
        vguid[1] = pVictim->getGUIDHigh();
        smsg_AttackStop(pVictim, aguid);

        // Send MSG_MOVE_ROOT   0xe7

        // Set update values... try flags 917504
        // health
        pVictim->setUpdateValue(UNIT_FIELD_HEALTH, 0);

        // then another update message, sets health to 0, maxhealth to 100, and dynamic flags
        pVictim->setUpdateValue(UNIT_FIELD_HEALTH, 0);
        pVictim->setUpdateMaskBit(UNIT_FIELD_MAXHEALTH);
        pVictim->removeUnitFlag(0x00080000);

        if (!pVictim->isPlayer())
			pVictim->setUpdateValue(UNIT_DYNAMIC_FLAGS, 1);

        if (pAttacker->isPlayer()){
            uint32 xp = CalculateXpToGive(pVictim, pAttacker);

            // check running quests in case this monster belongs to it
            uint32 entry = pVictim->getUpdateValue(OBJECT_FIELD_ENTRY );

            // Is this player part of a group?
            Group *pGroup = WorldServer::getSingleton().GetGroupByLeader(((Character*)pAttacker)->GetGroupLeader());
            if (pGroup){
                xp /= pGroup->count;
                for (uint32 c=0; c < pGroup->count; c++){
                    Character *pGroupGuy = world.mCharacters[pGroup->members[c].guid];
                    pGroupGuy->giveXP(xp, pVictim->getGUID(), pVictim->getGUIDHigh());
                    pGroupGuy->KilledMonster(entry, pVictim->getGUID());
                }
            }
            else
            {
                // update experience
                ((Character*)pAttacker)->giveXP(xp, pVictim->getGUID(), pVictim->getGUIDHigh());
                ((Character*)pAttacker)->KilledMonster(entry, pVictim->getGUID());
            }
        }
        else
        {
            smsg_AttackStop(pAttacker, vguid);
            pAttacker->removeUnitFlag(0x00080000);
            pAttacker->setUpdateMaskBit(UNIT_FIELD_FLAGS );
            pAttacker->addStateFlag(UF_TARGET_DIED);
        }
    } else {
        pVictim->setUpdateValue(UNIT_FIELD_HEALTH , health + damage);

    }
}
*/