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
#include "DynamicObject.h"
#include "Object.h"
#include "Player.h"
#include "UpdateMask.h"
#include "Unit.h"
#include "Duel.h"

createFileSingleton( DuelHandler );

DuelHandler::DuelHandler(){ }

DuelHandler::~DuelHandler(){ }

void DuelHandler::RequestDuel(Player *player)
{
	WorldPacket data;
	printf("Duel packet received.");

	if (player->DuelingWith != NULL) return; // We Already Dueling or have Requested a Duel

	player->SetDuelState(DUEL_STATE_REQUESTED);

	//Setup Target
	Player *pTarget = objmgr.GetObject<Player>(player->GetSelection());
	if (!pTarget) return; // invalid Target
	if (!pTarget->isAlive()) return; // Target not alive
	if (pTarget->DuelingWith != NULL) return; // Already Dueling

	//Setup Duel
	pTarget->DuelingWith = player;
	player->DuelingWith = pTarget;

	//Get Flags position
	float dist = player->CalcDistance(pTarget);
	dist = dist/2; //half way
	float x = (player->GetPositionX() + pTarget->GetPositionX()*dist)/(1+dist);
	float y = (player->GetPositionY() + pTarget->GetPositionY()*dist)/(1+dist);
	float z = (player->GetPositionZ() + pTarget->GetPositionZ()*dist)/(1+dist);

	//Create flag/arbiter
	GameObject* pGameObj = new GameObject();
	pGameObj->Create(objmgr.GenerateLowGuid(HIGHGUID_GAMEOBJECT), player->GetMapId(), x, y, z, player->GetOrientation());

	//Spawn the Flag
	pGameObj->SetUInt32Value(OBJECT_FIELD_TYPE,33);
	pGameObj->SetUInt32Value(OBJECT_FIELD_ENTRY,21680);
	pGameObj->SetFloatValue(OBJECT_FIELD_SCALE_X,1);
	pGameObj->SetUInt64Value(OBJECT_FIELD_CREATED_BY,player->GetGUID());
	pGameObj->SetUInt32Value(GAMEOBJECT_DISPLAYID,787);
	pGameObj->SetUInt32Value(GAMEOBJECT_STATE,1);
	pGameObj->SetUInt32Value(GAMEOBJECT_FACTION,player->GetUInt32Value(UNIT_FIELD_FACTIONTEMPLATE));
	pGameObj->SetUInt32Value(GAMEOBJECT_TYPE_ID,16);
	pGameObj->SetUInt32Value(GAMEOBJECT_LEVEL,2);
	objmgr.AddObject(pGameObj);
	pGameObj->AddToWorld();

	//Show Spawn Animation
	data.Initialize(SMSG_GAMEOBJECT_SPAWN_ANIM);
	data << pGameObj->GetGUID();
	pGameObj->SendMessageToSet(&data,false);

	//Assign the Flag 
	player->SetUInt64Value(PLAYER_DUEL_ARBITER,pGameObj->GetGUID());
	pTarget->SetUInt64Value(PLAYER_DUEL_ARBITER,pGameObj->GetGUID());

	//Send Request
	data.clear();
	data.Initialize(SMSG_DUEL_REQUESTED);
	data << pGameObj->GetGUID();
	data << player->GetGUID();
	player->GetSession()->SendPacket(&data);
	pTarget->GetSession()->SendPacket(&data);
}

void DuelHandler::DuelBoundry(Player *player)
{
	//sLog.outDebug("Duel Boundry Test");
	WorldPacket data;

	if(player->GetDuelState() == DUEL_STATE_REQUESTED) return; //for the ones that accept while out of bounds and fuck everything up

	uint8 status;
	//check if in bounds
	GameObject * pGameObject = objmgr.GetObject<GameObject>(player->GetUInt64Value(PLAYER_DUEL_ARBITER));
	if(!pGameObject) return; //flag doesn't exist
	float Dist = player->CalcDistance((Object*)pGameObject);
	//if this player is to far away from flag
	if(Dist > 40) status = DUEL_STATUS_OUTOFBOUNDS;
	else status = DUEL_STATUS_INBOUNDS;

	if(status != player->GetDuelStatus()) //new status is not the same as old
	{
		player->SetDuelStatus(status);
		// Are they still within the Boundrys
		if(status == DUEL_STATUS_INBOUNDS)
		{
			data.Initialize(SMSG_DUEL_INBOUNDS);
		}
		else
		{
			data.Initialize(SMSG_DUEL_OUTOFBOUNDS);
			player->StartDuelTimer(9000); //9 sec
		}
		player->GetSession()->SendPacket(&data);
	}
}

void DuelHandler::EndDuel(Player *player, uint8 WinCondition)
{
	sLog.outDebug("Duel Finnished");
	WorldPacket data;
	Player *pTarget = player->DuelingWith;
	if(!pTarget) return;

	//Announce Winner
	data.Initialize(SMSG_DUEL_WINNER);
	data << uint8(WinCondition);
	if(WinCondition == DUEL_WINNER_RETREAT)
	{
		data << pTarget->GetName();
		data << player->GetName();
	}
	else if(WinCondition == DUEL_WINNER_KNOCKOUT)
	{
		data << player->GetName();
		data << pTarget->GetName();
		pTarget->Emote(EMOTE_ONESHOT_BEG);
		//	TEXTEMOTE_BEG
	}
	player->SendMessageToSet(&data,true);

	//get Arbiter
	uint64 arbiterGuid = player->GetUInt64Value(PLAYER_DUEL_ARBITER);

	//Clear Duel Related Stuff
	player->SetUInt64Value(PLAYER_DUEL_ARBITER, 0);
	pTarget->SetUInt64Value(PLAYER_DUEL_ARBITER, 0);
	player->SetUInt32Value(PLAYER_DUEL_TEAM, 0);
	pTarget->SetUInt32Value(PLAYER_DUEL_TEAM, 0);
	player->DuelingWith = NULL;
	pTarget->DuelingWith = NULL;

	//set state to Finnished
	player->SetDuelState(DUEL_STATE_FINISHED);
	pTarget->SetDuelState(DUEL_STATE_FINISHED);

	data.clear();
	//Send Duel Complete
	data.Initialize(SMSG_DUEL_COMPLETE);
	data << uint8(WinCondition);
	pTarget->GetSession()->SendPacket(&data);
	player->GetSession()->SendPacket(&data);

	GameObject * pGameObject = objmgr.GetObject<GameObject>(arbiterGuid);

	if(pGameObject)
	{
		data.clear();
		//Despawn Arbiter
		data.Initialize(SMSG_GAMEOBJECT_DESPAWN_ANIM);
		data << arbiterGuid;
		pGameObject->SendMessageToSet(&data,false);

		pGameObject->RemoveFromWorld();
		objmgr.RemoveObject(pGameObject);
		delete pGameObject;
	}

	//Stop Players attacking so they don't kill the other player
	data.clear();
	data.Initialize(SMSG_CANCEL_COMBAT);
	pTarget->GetSession()->SendPacket(&data);
	player->GetSession()->SendPacket(&data);
}

void DuelHandler::StartDuel(Player *player)
{
	sLog.outDebug("Duel Started");
	if(!player->DuelingWith) return;

	//Zero Rage
	player->SetUInt32Value(UNIT_FIELD_POWER2, 0);
	player->DuelingWith->SetUInt32Value(UNIT_FIELD_POWER2, 0);

	//Give the players a Team
	player->DuelingWith->SetUInt32Value(PLAYER_DUEL_TEAM, 1); // Duel Requester
	player->SetUInt32Value(PLAYER_DUEL_TEAM, 2);

	//set Selection
	player->SetUInt64Value(PLAYER_SELECTION, 0);
	player->DuelingWith->SetUInt64Value(PLAYER_SELECTION, 0);

	player->SetDuelState(DUEL_STATE_STARTED);
	player->DuelingWith->SetDuelState(DUEL_STATE_STARTED);
}

void WorldSession::HandleDuelAccepted(WorldPacket & recv_data)
{
	sLog.outDebug("Duel Accepted");
	WorldPacket data;

	/*
	uint64    Arbiter GUID
	*/

	Player* player = GetPlayer();

	if(player->GetDuelState() == DUEL_STATE_REQUESTED) return; //they have already accepted or requested a duel
	if(!player->DuelingWith) return; //if they do have a target
	if(player == player->DuelingWith) return; //if they not the same player

	player->SetDuelStatus(DUEL_STATUS_INBOUNDS);
	player->DuelingWith->SetDuelStatus(DUEL_STATUS_INBOUNDS);

	player->SetDuelState(DUEL_STATE_REQUESTED);

	//Start Timer
	player->StartDuelTimer(3000);

	data.Initialize(SMSG_DUEL_COUNTDOWN);
	data << uint32(3000); //3 sec
	player->DuelingWith->GetSession()->SendPacket(&data);
	player->GetSession()->SendPacket(&data);
}

void WorldSession::HandleDuelCancelled(WorldPacket & recv_data)
{
	sLog.outDebug("Duel Canceled");
	/*
	uint64    Arbiter GUID
	*/

	Player *player = GetPlayer();
	sDuelHandler.EndDuel(player, DUEL_WINNER_RETREAT);
}

/*
SMSG_DUEL_REQUESTED = 359,
SMSG_DUEL_OUTOFBOUNDS = 360,
SMSG_DUEL_INBOUNDS = 361,
MSG_DUEL_COMPLETE = 362,
SMSG_DUEL_WINNER = 363,
CMSG_DUEL_ACCEPTED = 364,
CMSG_DUEL_CANCELLED = 365,
SMSG_DUEL_COUNTDOWN = 695,

SPELL_FAILED_CANT_DUEL_WHILE_INVISIBLE = 14,
SPELL_FAILED_CANT_DUEL_WHILE_STEALTHED = 15,
SPELL_FAILED_NO_DUELING = 67,
SPELL_FAILED_TARGET_DUELING = 98,
*/

