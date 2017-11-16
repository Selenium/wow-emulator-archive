//////////////////////////////////////////////////////////////////////
//  Unit
//
//  ??
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

#include "Unit.h"
#include "UpdateMask.h"
#include "WorldServer.h"
#include "Quest.h"
#include "Character.h"
#include "Opcodes.h"
#include "SystemFun.h"
#include "math.h"

Unit::Unit() : Object()
{
	m_objectType |= TYPE_UNIT;
	m_objectTypeId = 3;
	m_updateValues[ OBJECT_FIELD_TYPE ] = m_objectType;

	setAnimFrequency (1, 5);

	mQuestIds.clear ();

	m_corpseDelay = 30000;
	m_respawnDelay = 10000;

	m_respawnTimer = 0;
	m_deathTimer = 0;
	m_attackTimer = 0;
	m_moveTimer = 0;

	itemcount = 0;
	memset (item_list, 0, sizeof (item_list));

	m_deathState = ALIVE;
	m_state = 0;

	m_nWaypoints = 0;
	m_currentWaypoint = 0;
	m_moveBackward = false;
	m_moveRandom = false;
	m_moveRun = false;
	m_creatureState = STOPPED;

	m_destinationX = m_destinationY = m_destinationZ = 0;
	m_moveSpeed = 0;

	m_damageDuration = 0;
	m_damageTimer = 1000;
	m_damage = 0;
	m_absorb = 0;
	m_absorbTimer = 0;
	m_absorbDuration = 0;
	m_auraDuration = 0;
	m_auraTimer = 0;
	m_shieldDuration = 0;
	m_shieldTimer = 0;
	m_shield = 0;
	m_follow=0;
	m_pet_state = 0;

	m_Pet=false;
}


Unit::~Unit()
{
	mQuestIds.clear ();
}


void Unit::setAnimFrequency (uint32 anim, float frequency)
{
	mAnimFrequencies [anim] = frequency;
}


void Unit::UpdateMobMovement (uint32 p_time)
{
	uint32 timediff = 0;

	if (m_moveTimer > 0)
	{
		if (p_time >= m_moveTimer)
		{
			timediff = p_time - m_moveTimer;
			m_moveTimer = 0;
		}
		else
			m_moveTimer -= p_time;
	}

	if (m_creatureState == MOVING)
	{
		if (!m_moveTimer)
		{
			float dx, dy, dz;
			float destMoved = m_moveSpeed*(UNIT_MOVEMENT_INTERPOLATE_INTERVAL + timediff); // moveTimer interval
			float moveDistance;

			dx = m_destinationX - m_positionX;
			dy = m_destinationY - m_positionY;
			dz = m_destinationZ - m_positionZ;

			if (!dx && !dy && !dz || (moveDistance = sqrt((dx*dx) + (dy*dy) + (dz*dz))) <= destMoved)
			{
				m_creatureState = STOPPED;
				m_moveTimer = rand() % (m_moveRun ? 5000 : 10000); // wait before next move

				m_positionX = m_destinationX;
				m_positionY = m_destinationY;
				m_positionZ = m_destinationZ;

				//uint8 pAnnounce[256];
				//sprintf((char*)pAnnounce, "%i done moving", m_guid->sno);   // Adds BROADCAST:
				//WORLDSERVER.SendWorldText((uint8*)pAnnounce); // send message

				m_destinationX = m_destinationY = m_destinationZ = 0;

				UpdateObject();
			}
			else
			{
				float q = destMoved/(moveDistance - destMoved);

				m_positionX = (m_positionX + m_destinationX*q)/(1+q);
				m_positionY = (m_positionY + m_destinationY*q)/(1+q);
				m_positionZ = (m_positionZ + m_destinationZ*q)/(1+q);

				uint32 moveTime = (uint32) ((moveDistance-destMoved) / m_moveSpeed);

				//printf("moving %f %f %f\n", m_positionX, m_positionY, m_positionZ);
				AI_SendMoveToPacket(m_destinationX, m_destinationY, m_destinationZ, moveTime, m_moveSpeed == 7.0*0.001);

				m_moveTimer = UNIT_MOVEMENT_INTERPOLATE_INTERVAL;
				//                UpdateObject();
			}
		} // still moving
	}
	else if (m_creatureState == STOPPED && !m_moveTimer && m_nWaypoints > 1) //creature is stoped
	{
		int destpoint;

		if (m_moveRandom)
			destpoint = rand() % m_nWaypoints;
		else
		{
			if (m_currentWaypoint == (m_nWaypoints-1))
				m_moveBackward = true;
			if (m_currentWaypoint == 0)
				m_moveBackward = false;
			if (!m_moveBackward) // going 0..n
				destpoint = ++m_currentWaypoint;
			else                // going (n-1)..0
				destpoint = --m_currentWaypoint;
		}

		AI_MoveTo(m_waypoints[destpoint][0], m_waypoints[destpoint][1], m_waypoints[destpoint][2], m_moveRun);
	}
}

void Unit::Update (uint32 p_time)
{
	if (m_deathState == JUST_DIED)
	{
		// remove me as an attacker from the AttackMap
		m_attackers.clear();
		m_deathState = CORPSE;
	}

	if (m_state & UF_TARGET_DIED)
	{
		if (m_Pet == false)
			AI_MoveTo (respawn_cord[0][0], respawn_cord[0][1], respawn_cord[0][2], true);
	}

	if (m_attackTimer > 0)
	{
		if (p_time >= m_attackTimer)
			m_attackTimer = 0;
		else
			m_attackTimer -= p_time;
	}

	if (m_deathTimer > 0)
	{
		if (p_time >= m_deathTimer)
			m_deathTimer = 0;
		else
			m_deathTimer -= p_time;

		if (m_deathTimer <= 0)
		{
			// time to respawn!
			NetworkPacket data;
			data.Clear ();
			data.Initialize (8, SMSG_DESTROY_OBJECT);
			data << m_guid->sno << m_guid->type;
			SendMessageToSet(&data, false);
			m_respawnTimer = m_respawnDelay;
			setDeathState(DEAD);
			//set to spawn point
			m_positionX = respawn_cord[0][0];
			m_positionY = respawn_cord[0][1];
			m_positionZ = respawn_cord[0][2];
			//printf("PT %f, %f, %f \n", respawn_cord[0][0],respawn_cord[0][1],respawn_cord[0][2]);
			//printf("ACT MOV respawn coords--> Mob ID: %i - Nodo:X (x:%i, y:%i, z:%i)\n",m_guid->sno,(int)creature_cord[0][0],(int)creature_cord[0][1],(int)creature_cord[0][2]);

			//printf("Removing corpse...\n");
		}
	}
	else if (m_respawnTimer > 0)
	{
		if (p_time >= m_respawnTimer)
			m_respawnTimer = 0;
		else
			m_respawnTimer -= p_time;

		if (m_respawnTimer <= 0)
		{
			UpdateMask mask;
			NetworkPacket data;
			WorldServer::getSingletonPtr()->mObjectMgr.SetCreateUnitBits (mask);
			uint32 max_health = getUpdateValue (UNIT_FIELD_MAXHEALTH);
			setUpdateValue (UNIT_FIELD_HEALTH, max_health);

			CreateObject (&mask, &data, 0);
			SendMessageToSet (&data, false);
			setDeathState (ALIVE);
			//printf("Respawning...\n");
			// <WoW Chile Dev Team> Start Change
			m_creatureState = STOPPED; //after respawn monster can move
			// <WoW Chile Dev Team> Start Change
		}
	}

	if (isAlive ())
	{
		UpdateMobMovement (p_time);
		AI_Update ();
	}

	if (m_damageDuration > 0)
	{
		if (m_damageTimer > 0)
		{
			if (p_time >= m_damageTimer)
				m_damageTimer = 0;
			else
				m_damageTimer -= p_time;
		}

		if (m_damageTimer == 0)
		{
			m_damageDuration--;
			m_damageTimer = 1000;
			uint32 health = getUpdateValue (UNIT_FIELD_HEALTH);
			Unit *DamageAttacker;

			DamageAttacker = WORLDSERVER.GetCharacter (m_Attacker.sno);
			if (!DamageAttacker)
				DamageAttacker = WORLDSERVER.GetCreature (m_Attacker.sno);

			if (int (health - m_damage) < 0)
				m_damageDuration = 0;
			else
				WORLDSERVER.mCombatHandler.DealDamage (DamageAttacker, this, m_damage);
		}
	}

	if (m_absorbDuration > 0)
	{
		m_absorb = 1;

		if (m_absorbTimer > 0)
		{
			if (p_time >= m_absorbTimer)
				m_absorbTimer = 0;
			else
				m_absorbTimer -= p_time;
		}

		if (m_absorbTimer == 0)
		{
			m_absorbDuration--;
			m_absorbTimer = 1000;
			//printf("Absorb Time: %u\n", m_absorbDuration);
		}

		if (m_absorbDuration == 0)
		{
			m_absorb = 0;
			//printf("OK time is up for now :(\n");
		}
	}

	if (m_auraDuration > 0)
	{
		//printf("ok we got aura on now :)\n");

		if (m_auraTimer > 0)
		{
			if (p_time >= m_auraTimer)
				m_auraTimer = 0;
			else
				m_auraTimer -= p_time;
		}

		if (m_auraTimer == 0)
		{
			m_auraDuration--;
			m_auraTimer = 1000;
			//printf("Aura Time: %u\n", m_auraDuration);
		}

		if (m_auraDuration == 0)
		{
			setUpdateValue(UNIT_FIELD_AURALEVELS + m_aura_found, 0);
			setUpdateValue(UNIT_FIELD_AURAAPPLICATIONS + m_aura_found, 0);
			setUpdateValue(UNIT_FIELD_AURA + m_aura_found*4 + m_aura_found2, 0);
			//printf("OK time is up for now :(\n");
		}
	}

	if (m_shieldDuration > 0)
	{
		m_shield = 1;

		if (m_shieldTimer > 0)
		{
			if (p_time >= m_shieldTimer)
				m_shieldTimer = 0;
			else
				m_shieldTimer -= p_time;
		}

		if (m_shieldTimer == 0)
		{
			m_shieldDuration--;
			m_shieldTimer = 1000;
			//printf("Shield Time: %u\n", m_shieldDuration);
		}

		if (m_shieldDuration == 0)
		{
			m_shield = 0;
			//printf("OK shield time is up for now :(\n");
		}
	}

	if (m_follow)
	{
		if (m_creatureState != ATTACKING)
		{
			uint32 summID = getUpdateValue(UNIT_FIELD_SUMMONEDBY);
			Character * pChar = WORLDSERVER.GetCharacter(summID);
			if (pChar)
			{
				//printf("following\n");
				float dx = pChar->getPositionX();
				float dy = pChar->getPositionY();
				float dz = pChar->getPositionZ();
				AI_MoveTo(dx, dy, dz, true);
			}
		}
		//m_creatureState = MOVING;
	}

	// PET AGGRESSIVE MODE ATTACKS CREEPS IN RANGE(STATIC 20)
	if (m_pet_state == 2)
	{
		if (m_creatureState != ATTACKING)
		{
			Unit * pUnit = WORLDSERVER.GetClosestUnit(this);
			if (pUnit)
			{
				if (closest_dist < 20)
				{
					AI_MoveTo(pUnit->getPositionX(),pUnit->getPositionY(),pUnit->getPositionZ(), true);
					AI_AttackReaction(pUnit,1);
					AI_Update();
				}
			}
		}
	}

	// ATTACK ENEMYS IF THEY GET IN RANGE (CURRENTLY STATIC 20) SET m_aggressive to 1 to activate
	if (m_aggressive == 1 || m_aggressive == 3)
	{
		if (m_creatureState != ATTACKING)
		{
			Character * pChar = WORLDSERVER.GetClosestChar(this);
			if (pChar)
			{
				if (closest_dist < 20)
				{
					AI_MoveTo(pChar->getPositionX(),pChar->getPositionY(),pChar->getPositionZ(), true);
					AI_AttackReaction(pChar,1);
					AI_Update();
				}
			}
		}
	}

	// Clear the NPC flags bit so it doesn't get auto- updated each frame.
	// NPC flags are set per player and this would ruin is
	unsetUpdateMaskBit (UNIT_NPC_FLAGS);
	UpdateObject ();
}


void Unit::Create (uint32 guidlow)
{
	Object::Create(guidlow);
	m_guid->type = 0xF0001000;
}


void Unit::Create (uint32 guidlow, uint8* creature_name, float x, float y, float z, float ang)
{
	strcpy((char*)m_creatureName, (char*)creature_name);
	Object::Create(guidlow, x,y,z,ang);
	m_guid->type = 0xF0001000;
}


void Unit::BuildUpdateBlock(UpdateMask *updateMask, uint8 *data, int *length)
{
	m_updateValues[ UNIT_NPC_EMOTESTATE ] = m_emoteState;

	Object::BuildUpdateBlock(updateMask, data, length);
}


/////////////////////////////////// QUESTS ////////////////////////////////////////////
uint32 Unit::getQuestStatus(Character *pPlayer)
{
	for (std::list<uint32>::iterator i = mQuestIds.begin (); i != mQuestIds.end (); ++ i) {
		uint32 quest_id = *i;
		uint32 status = pPlayer->getQuestStatus(quest_id);

		if (status == 0 || status == QUEST_STATUS_UNAVAILABLE) {
			Quest *pQuest = WORLDSERVER.getQuest(quest_id);
			// if 0, then the player has never been offered this before
			// Add it to the player with a new quest value of 4
			if (pQuest->m_requiredLevel >= pPlayer->getUpdateValue(UNIT_FIELD_LEVEL))
				status = pPlayer->addNewQuest(quest_id,2);
			else
				status = pPlayer->addNewQuest(quest_id);
		}

		if (status != QUEST_STATUS_COMPLETE)
			return status;
	}

	return 0;
}


uint32 Unit::getCurrentQuest(Character *pPlayer)
{
	for (std::list<uint32>::iterator i = mQuestIds.begin (); i != mQuestIds.end (); ++ i) {
		uint32 quest_id = *i;
		uint32 status = pPlayer->getQuestStatus(quest_id);

		if (status == 0)
			// if 0, then the player has never been offered this before
			// Add it to the player with a new quest value of 4
			status = pPlayer->addNewQuest(quest_id);

		if (status != QUEST_STATUS_COMPLETE) // if quest is not completed yet, then this is the active quest to return
			return quest_id;
	}

	return 0;
}


char* Unit::getQuestTitle(uint32 quest_id)
{
	Quest *pQuest = WORLDSERVER.getQuest(quest_id);
	return (char*)pQuest->m_title.c_str();
}

char* Unit::getQuestDetails(uint32 quest_id)
{
	Quest *pQuest = WORLDSERVER.getQuest(quest_id);
	return (char*)pQuest->m_details.c_str();
}

char* Unit::getQuestObjectives(uint32 quest_id)
{
	Quest *pQuest = WORLDSERVER.getQuest(quest_id);
	return (char*)pQuest->m_objectives.c_str();
}

char* Unit::getQuestCompleteText(uint32 quest_id)
{
	Quest *pQuest = WORLDSERVER.getQuest(quest_id);
	return (char*)pQuest->m_completedText.c_str();
}

char* Unit::getQuestIncompleteText(uint32 quest_id)
{
	Quest *pQuest = WORLDSERVER.getQuest(quest_id);
	return (char*)pQuest->m_incompleteText.c_str();
}

bool Unit::hasQuest(uint32 quest_id)
{
	for (std::list<uint32>::iterator i = mQuestIds.begin (); i != mQuestIds.end (); ++ i) {
		if (*i == quest_id)
			return true;
	}

	return false;
}

/*
 void Unit::SendCreateWithTempNpcFlags(UpdateMask *updateMask, GameClient *pClient)
 {
 if (m_deathState == DEAD) return;

 // for each quest this creature has,
 //   if player->getStatus != 0
 //     if quest->targetGuid != 0 && quest->targetGuid != thisCreature->guid and status==3
 //       thisCreature->npcflags = 0
 //     else if quest->targetGuid == thisCreature->guid && quest->status == 1||3
 //       thisCreature->npc_flags = 2
 Character *pPlayer = pClient->getCurrentChar();
 NetworkPacket data;
 for (std::list<uint32>::iterator i = mQuestIds.begin (); i != mQuestIds.end (); ++ i) {
 uint32 quest_id = *i;
 uint32 status = pPlayer->getQuestStatus(quest_id);
 Quest *pQuest = WORLDSERVER.getQuest(quest_id);
 if (status != 0)
 {
 if (pQuest->m_targetGuid != 0 && pQuest->m_targetGuid != m_guid->sno && status==QUEST_STATUS_INCOMPLETE)
 {
 // If this is a talk to quest, and the target NPC is not THIS npc, and the status is Incomplete,...
 // Set NPC_FLAGS to 0 so it doesn't offer a quest to this player
 setUpdateValue(UNIT_NPC_FLAGS, 0);
 CreateObject(updateMask, &data, 0);
 pClient->SendMsg(&data);
 setUpdateValue(UNIT_NPC_FLAGS, 2);
 return;
 }
 else if (pQuest->m_targetGuid == m_guid->sno && (status == QUEST_STATUS_COMPLETE || status == QUEST_STATUS_INCOMPLETE))
 {
 // If this creature has a Talk To quest, and it is the target of the quest, and the quest is either complete or currently
 // underway, then allow this creature to have quest flags
 setUpdateValue(UNIT_NPC_FLAGS, 2);
 CreateObject(updateMask, &data, 0);
 pClient->SendMsg(&data);
 setUpdateValue(UNIT_NPC_FLAGS, 0);
 return;
 }
 else if (pQuest->m_targetGuid == m_guid->sno && status == QUEST_STATUS_AVAILABLE)
 {
 // If this Creature has a Talk to quest, and is the target of the quest, and the quest is currently available,
 // Remove Questgiver flags
 setUpdateValue(UNIT_NPC_FLAGS, 0);
 CreateObject(updateMask, &data, 0);
 pClient->SendMsg(&data);
 setUpdateValue(UNIT_NPC_FLAGS, 2);
 return;
 }
 }
 }

 CreateObject(updateMask, &data, 0);
 pClient->SendMsg(&data);
 }
 */

int Unit::CheckQuestgiverFlag(Character *pPlayer, UpdateMask *unitMask, NetworkPacket * data)
{
	for (std::list<uint32>::iterator i = mQuestIds.begin (); i != mQuestIds.end (); ++ i)
	{
		uint32 quest_id = *i;
		uint32 status = pPlayer->getQuestStatus(quest_id);
		Quest *pQuest = WORLDSERVER.getQuest(quest_id);
		//        if (status != 0)
		//        {
		if (pQuest->m_targetGuid != 0 && pQuest->m_targetGuid != m_guid->sno && status==QUEST_STATUS_INCOMPLETE)
		{
			// If this is a talk to quest, and the target NPC is not THIS npc, and the status is Incomplete,...
			// Set NPC_FLAGS to 0 so it doesn't offer a quest to this player
			setUpdateValue(UNIT_NPC_FLAGS, 0);
			CreateObject(unitMask, data, 0);
			setUpdateValue(UNIT_NPC_FLAGS, 2);
			return 1;
		}
		else if (pQuest->m_targetGuid == m_guid->sno && (status == QUEST_STATUS_COMPLETE || status == QUEST_STATUS_INCOMPLETE))
		{
			// If this creature has a Talk To quest, and it is the target of the quest, and the quest is either complete or currently
			// underway, then allow this creature to have quest flags
			setUpdateValue(UNIT_NPC_FLAGS, 2);
			CreateObject(unitMask, data, 0);
			setUpdateValue(UNIT_NPC_FLAGS, 0);
			return 1;
		}
		else if (pQuest->m_targetGuid == m_guid->sno && (status == QUEST_STATUS_AVAILABLE || status == 0))
		{
			// If this Creature has a Talk to quest, and is the target of the quest, and the quest is currently available,
			// Remove Questgiver flags
			setUpdateValue(UNIT_NPC_FLAGS, 0);
			CreateObject(unitMask, data, 0);
			setUpdateValue(UNIT_NPC_FLAGS, 2);
			return 1;
		}
		//        }
	}

	return 0;
}


void Unit::setAttackTimer()
{
	m_attackTimer = getUpdateValue(UNIT_FIELD_BASEATTACKTIME);
}


////////////////////////////////////////////////////////////////////////////////
//  Fill the object's Update Values from a space deliminated list of values.
////////////////////////////////////////////////////////////////////////////////
void Unit::LoadUpdateValues(uint8* data)
{
	char* next = strtok((char*)data, " ");
	m_updateValues[0] = atol(next);
	for (uint16 index = 1; index < UNIT_END; index++)
	{
		char* next = strtok(NULL, " ");

		if (next == NULL)
			continue;
		m_updateValues[index] = atol(next);
	}

}


///////////////////////////////////////////////////////////////////////////////////////////////////
//    Looting
///////////////////////////////////////////////////////////////////////////////////////////////////

void Unit::generateLoot()
{
	int retryCount = 0;
	itemcount = 0;
	memset(item_list, 0, 8*128);

	int itemCount,i,randItem,found = 0,tempLevel;
	this->m_lootMoney = this->getLevel() * (rand()%5 + 1);

	// added in only a 20% chance of finding an item - NISHAVEN
	if (rand()%100 > 20)
	{
		itemcount = 0;
		return;
	}

	itemCount = (this->getLevel() + rand()%7) / 5;
	if (itemCount > 3)
		itemCount = 3;
	//itemCount = 2; //temp
	for(i = 0; i < itemCount; i++) {
		//This is an ugly way to do it
		//I may implement a 'baskets' system later - tmm`
		retryCount = 0;
		while(!found && (retryCount <= 150)) {
			retryCount++;
			randItem = rand()%7000;
			if (WORLDSERVER.GetItem(randItem) != NULL) {
				tempLevel = WORLDSERVER.GetItem(randItem)->ItemLevel;
				//if ((tempLevel < this->getLevel() +2) && (tempLevel > this->getLevel() -2)) {
				// items far too overpowered with --^^  - NISHAVEN
				if ((tempLevel < this->getLevel()) && (tempLevel > this->getLevel() -2)) {
					if ((WORLDSERVER.GetItem(randItem)->Class == 2) || (WORLDSERVER.GetItem(randItem)->Class == 4)) {
						found = 1;
					}
				}
			}
		}
		if (found == 0)
		{
			//this is getting dangerous, we don't want an infinite loop :/
			//lets just not give him any items
			itemcount = 0;
			return;
		}
		this->addItem(randItem,1);
		found = 0;
	}
}

///////////////////////////////////////////////////////////////////////////////////////////////////
//    Unit AI
///////////////////////////////////////////////////////////////////////////////////////////////////

// This Unit has just been attacked by someone
// Reaction:  Add this Unit to the list of current attackers
void Unit::AI_AttackReaction(Unit *pAttacker, uint32 damage_dealt)
{
	(void)damage_dealt;
	std::list<Unit*>::iterator itr;
	for (itr = m_attackers.begin(); itr != m_attackers.end(); ++itr)
		if (*itr == pAttacker)
		{
			// Attacker already in list
			return;
		}
	m_attackers.push_back(pAttacker);
}

void Unit::AI_Update()
{
	// Cycle through attackers
	// If one is out of range, remove from the map
	std::list<Unit*>::iterator itr;
	for (itr = m_attackers.begin(); itr != m_attackers.end(); ++itr)
	{
		Unit *pVictim = *itr;
		if (!pVictim || !pVictim->isAlive())
		{
			if (m_Pet == false) AI_MoveTo(respawn_cord[0][0], respawn_cord[0][1], respawn_cord[0][2], true); //LINA, force mobs to return to there respawn
			itr = m_attackers.erase(itr);
			continue;
		}
		//LINA TEST
		if (pVictim->getGUID ().type == 0) //if victim was a player
		{
			if (!((Character*)pVictim)->pClient->IsInWorld()) //test if in world
			{
				if (m_Pet == false) AI_MoveTo(respawn_cord[0][0], respawn_cord[0][1], respawn_cord[0][2], true); //LINA, force mobs to return to there respawn
				itr = m_attackers.erase(itr);
				continue;
			}
		}

		float dx, dy, dz;
		dx = pVictim->getPositionX() - getPositionX();
		dy = pVictim->getPositionY() - getPositionY();
		dz = pVictim->getPositionZ() - getPositionZ();

		float length = sqrt((dx*dx) + (dy*dy) + (dz*dz));
		float reach = getUpdateFloatValue(UNIT_FIELD_COMBATREACH);
		float radius = getUpdateFloatValue(UNIT_FIELD_BOUNDINGRADIUS);

		if (length > 30.0f) // must be greater then the max range of spells
		{
			// stop attacking because the target is too far
			if (m_Pet == false) AI_MoveTo(respawn_cord[0][0], respawn_cord[0][1], respawn_cord[0][2], true); //LINA, force mobs to return to there respawn
			itr = m_attackers.erase(itr);
			continue;
		}

		if (length > reach + radius)
		{
			float q = (length - radius)/length;

			float x = (m_positionX + pVictim->getPositionX()*q)/(1+q);
			float y = (m_positionY + pVictim->getPositionY()*q)/(1+q);
			float z = (m_positionZ + pVictim->getPositionZ()*q)/(1+q);

			AI_MoveTo(x, y, z, true);
		}
		else
		{
			AI_ChangeState(ATTACKING);
			if (isAttackReady())
			{
				WORLDSERVER.mCombatHandler.AttackerStateUpdate((Unit*)this, pVictim, 0);
				setAttackTimer();
			}
		}
		//lina
		if (m_creatureState == ATTACKING)
		{
			if (m_aggressive==2 || m_aggressive==3)
			{
				WORLDSERVER.setAttackGroupUnit(this, pVictim);
			}
		}
	}
}


void Unit::AI_SendMoveToPacket(float x, float y, float z, uint32 time, bool run)
{
	NetworkPacket data;
	data.Initialize(49, SMSG_MONSTER_MOVE);
	data << m_guid->sno << m_guid->type;
	data << getPositionX() << getPositionY() << getPositionZ() << getOrientation();
	data << uint8(0);
	data << uint32(run ? 0x00000100 : 0x00000000);
	data << time;
	data << uint32(1);
	data << x << y << z;
	WORLDSERVER.SendGlobalMessage(&data);
}


void Unit::AI_MoveTo(float x, float y, float z, bool run)
{
	float dx = x - m_positionX;
	float dy = y - m_positionY;
	float dz = z - m_positionZ;

	float distance = sqrt((dx*dx) + (dy*dy) + (dz*dz));
	if (!distance)
		return;

	m_destinationX = x;
	m_destinationY = y;
	m_destinationZ = z;

	if (m_creatureState != MOVING)
	{
		m_creatureState = MOVING;

		if (!run)
			m_moveSpeed = float(2.5*0.001);
		else
			m_moveSpeed = float(7.0*0.001);

		uint32 moveTime = (uint32) (distance / m_moveSpeed);

		AI_SendMoveToPacket(x, y, z, moveTime, run);

		//uint8 pAnnounce[256];
		//sprintf((char*)pAnnounce, "%i started moving from %f %f %f to %f %f %f should get there in %i msecs, distance is %f\n",
		//    m_guid->sno, m_positionX, m_positionY, m_positionZ,
		//    m_destinationX, m_destinationY, m_destinationZ, moveTime, distance);
		//WORLDSERVER.SendWorldText((uint8*)pAnnounce); // send message

		m_moveTimer = UNIT_MOVEMENT_INTERPOLATE_INTERVAL; // update every 300 msecs

		UpdateObject();
	}
}

bool Unit::addWaypoint(float x, float y, float z)
{
	if (m_nWaypoints+1 >= MAX_CREATURE_WAYPOINTS)
		return false;

	m_waypoints[m_nWaypoints][0] = x;
	m_waypoints[m_nWaypoints][1] = y;
	m_waypoints[m_nWaypoints][2] = z;

	m_nWaypoints++;

	return true;
}


bool Unit::canReachWithAttack(Unit *pVictim)
{
	float dx, dy, dz;
	float reach = getUpdateFloatValue(UNIT_FIELD_COMBATREACH);
	float radius = getUpdateFloatValue(UNIT_FIELD_BOUNDINGRADIUS);

	dx = m_positionX - pVictim->getPositionX();
	dy = m_positionY - pVictim->getPositionY();
	dz = m_positionZ - pVictim->getPositionZ();

	float length = sqrt((dx*dx) + (dy*dy) + (dz*dz));

	if (length > reach + radius)
		return false;

	return true;
}


void Unit::setCreatureName(char* CreatureName)
{
	strcpy((char*)m_creatureName, CreatureName);
}
