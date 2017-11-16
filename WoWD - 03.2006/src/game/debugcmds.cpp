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

/////////////////////////////////////////////////
//  Debug Chat Commands
//

#include "Common.h"
#include "Database/DatabaseEnv.h"
#include "WorldPacket.h"
#include "WorldSession.h"
#include "UpdateData.h"
#include "World.h"
#include "ObjectMgr.h"
#include "Player.h"
#include "Opcodes.h"
#include "Chat.h"
#include "Log.h"
#include "Unit.h"


bool ChatHandler::HandleDebugInFrontCommand(const char* args)
{
	WorldPacket data;
    Object *obj;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid != 0)
    {
        if(!(obj = (Object*)objmgr.GetObject<Player>(guid)) && !(obj = (Object*)objmgr.GetObject<Creature>(guid)))
        {
            FillSystemMessageData(&data, m_session, "You should select a character or a creature.");
            m_session->SendPacket( &data );
            return true;
        }
    }
    else
        obj = (Object*)m_session->GetPlayer();

    char buf[256];
    sprintf((char*)buf, "%d", m_session->GetPlayer()->isInFront((Unit *)obj));

    FillSystemMessageData(&data, m_session, buf);
    //m_session->SendPacket( &data );

	return true;
}

bool ChatHandler::HandleShowReactionCommand(const char* args)
{
	WorldPacket data;
	WorldPacket msgdata;
    Object *obj;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid != 0)
    {
		obj = (Object*)objmgr.GetObject<Creature>(guid);
	}

	if(!obj)
	{
		FillSystemMessageData(&msgdata, m_session, "You should select a creature.");
        m_session->SendPacket( &msgdata );
        return true;
	}


	char* pReaction = strtok((char*)args, " ");
    if (!pReaction)
		return false;

	uint32 Reaction  = atoi(pReaction);

	data.Initialize(SMSG_AI_REACTION);
	data << obj->GetGUIDLow() << uint32(Reaction);
	m_session->SendPacket( &data );

	std::stringstream sstext;
	sstext << "Sent Reaction of " << Reaction << " to " << obj->GetGUIDLow() << '\0';

	FillSystemMessageData(&msgdata, m_session, sstext.str().c_str());
    m_session->SendPacket( &msgdata );
	return true;
}

bool ChatHandler::HandleDistanceCommand(const char* args)
{
	WorldPacket data;
    Object *obj;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid != 0)
    {
        if(!(obj = (Object*)objmgr.GetObject<Player>(guid)) && !(obj = (Object*)objmgr.GetObject<Creature>(guid)))
        {
            FillSystemMessageData(&data, m_session, "You should select a character or a creature.");
            m_session->SendPacket( &data );
            return true;
        }
    }
    else
        obj = (Object*)m_session->GetPlayer();

	float dist = m_session->GetPlayer()->CalcDistance(obj);
	std::stringstream sstext;
	sstext << "Distance is: " << dist <<'\0';

	FillSystemMessageData(&data, m_session, sstext.str().c_str());
    m_session->SendPacket( &data );

	return true;
}

bool ChatHandler::HandleMoveInfoCommand(const char* args)
{
	WorldPacket data;
    Object *obj;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if(!(obj = (Object*)objmgr.GetObject<Creature>(guid)))
    {
		FillSystemMessageData(&data, m_session, "You should select a character or a creature.");
        m_session->SendPacket( &data );
        return true;
    }

	float dist = m_session->GetPlayer()->CalcDistance(obj);
	bool infront = ((Creature *)obj)->isInFront(m_session->GetPlayer());
	bool random = ((Creature *)obj)->GetAIInterface()->getMoveRandomFlag();
	bool run = ((Creature *)obj)->GetAIInterface()->getMoveRunFlag();
	uint32 attackerscount = ((Creature *)obj)->GetAIInterface()->getAITargetsCount();
    uint32 creatureState = ((Creature *)obj)->GetAIInterface()->m_creatureState;
	uint32 curwp = ((Creature *)obj)->GetAIInterface()->getCurrentWaypoint();
	Unit* unitToFollow = ((Creature *)obj)->GetAIInterface()->getUnitToFollow();
    uint32 aistate = ((Creature *)obj)->GetAIInterface()->getAIState();
	uint64 follow;
	if(unitToFollow == NULL)
	{
		follow = 0;
	}
	else
	{
		follow = unitToFollow->GetGUID();
	}

	std::stringstream sstext;
	sstext << "Distance is: " << dist << "\n";
	sstext << "Following Unit: " << follow << "\n";
	sstext << "IsInFront: " << infront << "\n";
	sstext << "MoveRandom: " << random << "\n";
	sstext << "Run: " << run << "\n";
	sstext << "Attackers Count: " << attackerscount << "\n";
    sstext << "Creature State: " << creatureState << "\n";
	sstext << "AI State: " << aistate << "\n";
	sstext << "Current Waypoint: " << curwp << "\n";

    SendMultilineMessage(sstext.str().c_str());
	//FillSystemMessageData(&data, m_session, sstext.str().c_str());
    //m_session->SendPacket( &data );

	return true;
}

bool ChatHandler::HandleAIMoveCommand(const char* args)
{
	WorldPacket data;
    Object *obj = NULL;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid != 0)
    {
		obj = (Object*)objmgr.GetObject<Creature>(guid);
	}

	if(obj == NULL)
	{
		FillSystemMessageData(&data, m_session, "You should select a creature.");
        m_session->SendPacket( &data );
        return true;
	}

	//m_session->GetPlayer()->GetOrientation();

	uint32 Move  = 1;
	uint32 Run  = 0;
	uint32 Time = 0;
	uint32 Meth = 0;

	char* pMove = strtok((char*)args, " ");
    if (pMove)
		Move  = atoi(pMove);

	char* pRun = strtok(NULL, " ");
    if (pRun)
		Run  = atoi(pRun);

	char* pTime = strtok(NULL, " ");
    if (pTime)
		Time  = atoi(pTime);

	char* pMeth = strtok(NULL, " ");
    if (pMeth)
		Meth  = atoi(pMeth);

	float x = m_session->GetPlayer()->GetPositionX();
	float y = m_session->GetPlayer()->GetPositionY();
	float z = m_session->GetPlayer()->GetPositionZ();
	float o = m_session->GetPlayer()->GetOrientation();
	((Creature *)obj)->GetAIInterface()->setMoveRunFlag(Run);
	float distance = ((Creature *)obj)->CalcDistance(x,y,z);
	if(Move == 1)
	{
		if(Meth == 1)
		{
			float q = distance-0.5;
			x = (((Creature *)obj)->GetPositionX()+x*q)/(1+q);
			y = (((Creature *)obj)->GetPositionY()+y*q)/(1+q);
			z = (((Creature *)obj)->GetPositionZ()+z*q)/(1+q);
		}
		else if(Meth == 2)
		{
			float q = distance-1;
			x = (((Creature *)obj)->GetPositionX()+x*q)/(1+q);
			y = (((Creature *)obj)->GetPositionY()+y*q)/(1+q);
			z = (((Creature *)obj)->GetPositionZ()+z*q)/(1+q);
		}
		else if(Meth == 3)
		{
			float q = distance-2;
			x = (((Creature *)obj)->GetPositionX()+x*q)/(1+q);
			y = (((Creature *)obj)->GetPositionY()+y*q)/(1+q);
			z = (((Creature *)obj)->GetPositionZ()+z*q)/(1+q);
		}
		else if(Meth == 4)
		{
			float q = distance-2.5;
			x = (((Creature *)obj)->GetPositionX()+x*q)/(1+q);
			y = (((Creature *)obj)->GetPositionY()+y*q)/(1+q);
			z = (((Creature *)obj)->GetPositionZ()+z*q)/(1+q);
		}
		else if(Meth == 5)
		{
			float q = distance-3;
			x = (((Creature *)obj)->GetPositionX()+x*q)/(1+q);
			y = (((Creature *)obj)->GetPositionY()+y*q)/(1+q);
			z = (((Creature *)obj)->GetPositionZ()+z*q)/(1+q);
		}
		else if(Meth == 6)
		{
			float q = distance-3.5;
			x = (((Creature *)obj)->GetPositionX()+x*q)/(1+q);
			y = (((Creature *)obj)->GetPositionY()+y*q)/(1+q);
			z = (((Creature *)obj)->GetPositionZ()+z*q)/(1+q);
		}
		else
		{
			float q = distance-4;
			x = (((Creature *)obj)->GetPositionX()+x*q)/(1+q);
			y = (((Creature *)obj)->GetPositionY()+y*q)/(1+q);
			z = (((Creature *)obj)->GetPositionZ()+z*q)/(1+q);
		}
		((Creature *)obj)->GetAIInterface()->MoveTo(x,y,z,0);
	}
	else
	{
		uint32 moveTime = 0;
		if(!Time)
		{
			//float dx = x - ((Creature *)obj)->GetPositionX();
			//float dy = y - ((Creature *)obj)->GetPositionY();
			//float dz = z - ((Creature *)obj)->GetPositionZ();

			//float distance = sqrt((dx*dx) + (dy*dy) + (dz*dz));
			if(!distance)
			{
				FillSystemMessageData(&data, m_session, "The Creature is already there.");
				m_session->SendPacket( &data );
				return true;
			}

			uint32 moveSpeed = 0;
			if(!Run)
			{
				moveSpeed = 2.5f*0.001f;
			}
			else
			{
				moveSpeed = 7.0f*0.001f;
			}

			moveTime = (uint32) (distance / moveSpeed);
		}
		else
		{
			moveTime = Time;
		}
		//((Creature *)obj)->setMovementState(MOVING);
		((Creature *)obj)->GetAIInterface()->SendMoveToPacket(x,y,z,o,moveTime,Run);
	}
	return true;
}

bool ChatHandler::HandleFaceCommand(const char* args)
{
	WorldPacket data;

	Object *obj = NULL;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid != 0)
    {
		obj = (Object*)objmgr.GetObject<Creature>(guid);
	}

	if(obj == NULL)
	{
		FillSystemMessageData(&data, m_session, "You should select a creature.");
        m_session->SendPacket( &data );
        return true;
	}

	uint32 Orentation = 0;
	char* pOrentation = strtok((char*)args, " ");
    if (pOrentation)
		Orentation  = atoi(pOrentation);

	/* Convert to Blizzards Format */
	float theOrientation = Orentation/(360/float(6.28));

	obj->SetPosition(obj->GetPositionX(), obj->GetPositionY(), obj->GetPositionZ(), theOrientation, false);

	/*
	data.Initialize( SMSG_MONSTER_MOVE );
	data << obj->GetGUID();
	data << obj->GetPositionX() << obj->GetPositionY() << obj->GetPositionZ() << obj->GetOrientation();
	data << uint8(1);
	///*
	data << uint32(0x100); //run
	data << uint32(0); //time
	data << uint32(2);
	data << obj->GetPositionX() << obj->GetPositionY() << obj->GetPositionZ() << theOrientation;
	*/
	UpdateData upd;

	// update movment for others
    obj->BuildMovementUpdateBlock(&upd,0);
    upd.BuildPacket( &data );
    //GetSession()->SendPacket( &packet );
	//obj->BuildMovementUpdateBlock(data,0)
	obj->SendMessageToSet(&data,false);
	printf("facing sent");
	return true;
	//((Creature *)obj)->AI_MoveTo(obj->GetPositionX()+0.1,obj->GetPositionY()+0.1,obj->GetPositionZ()+0.1,theOrientation);
}
/*

bool ChatHandler::HandleAIMoveCommand(const char* args)
{
	WorldPacket data;
	    Object *obj = NULL;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid != 0)
    {
		obj = (Object*)objmgr.GetObject<Creature>(guid);
	}

	if(obj == NULL)
	{
		FillSystemMessageData(&data, m_session, "You should select a creature.");
        m_session->SendPacket( &data );
        return true;
	}

	uint8 Value1  = 0;
	bool Run  = 0;
	uint32 Value2 = 1;
	uint32 Value3 = 0;
	bool ToFrom = 0;

	char* pValue1 = strtok((char*)args, " ");
    if (pValue1)
		Value1  = static_cast<uint8>(atol(pValue1));

	char* pRun = strtok(NULL, " ");
    if (pRun)
		Run  = atoi(pRun);

	char* pValue2 = strtok(NULL, " ");
    if (pValue2)
		Value2  = atoi(pValue2);

	char* pValue3 = strtok(NULL, " ");
    if (pValue3)
		Value3  = atoi(pValue3);

	char* pToFrom = strtok(NULL, " ");
    if (pToFrom)
		ToFrom  = atoi(pToFrom);

	float fromX = ((Creature *)obj)->GetPositionX();
	float fromY = ((Creature *)obj)->GetPositionY();
	float fromZ = ((Creature *)obj)->GetPositionZ();
	float fromO = ((Creature *)obj)->GetOrientation();
	float toX = m_session->GetPlayer()->GetPositionX();
	float toY = m_session->GetPlayer()->GetPositionY();
	float toZ = m_session->GetPlayer()->GetPositionZ();
	float toO = m_session->GetPlayer()->GetOrientation();

	float distance = ((Creature *)obj)->CalcDistance((Object *)m_session->GetPlayer());
	uint32 moveSpeed = 0;
	if(!Run)
	{
		moveSpeed = 2.5f*0.001f;
	}
	else
	{
		moveSpeed = 7.0f*0.001f;
	}
	uint32 moveTime = (uint32) (distance / moveSpeed);

	data.Initialize( SMSG_MONSTER_MOVE );
	data << guid;
	if(ToFrom)
	{
		data << toX << toY << toZ << toO;
	}
	else
	{
		data << fromX << fromY << fromZ << fromO;
	}
	data << uint8(Value1);
	if(Value1 != 1)
	{
		data << uint32(Run ? 0x00000100 : 0x00000000);
		data << moveTime;
		data << Value2;
		if(ToFrom)
		{
			data << fromX << fromY << fromZ;
			if(Value2 > 1)
			{
				data << fromO;
			}
		}
		else
		{
			data << toX << toY << toZ;
			if(Value2 > 1)
			{
				data << toO;
			}

		}
		if(Value2 > 2)
		{
			data << Value3;
		}
	}
	//((Creature *)obj)->m_m_timeToMove = moveTime;
	//m_moveTimer =  UNIT_MOVEMENT_INTERPOLATE_INTERVAL; // update every few msecs

	//	m_creatureState = MOVING;
	((Creature *)obj)->SendMessageToSet( &data, false );
	return true;
}
*/
bool ChatHandler::HandleSetBytesCommand(const char* args)
{
	WorldPacket data;
    Object *obj;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid != 0)
    {
        if(!(obj = (Object*)objmgr.GetObject<Player>(guid)) && !(obj = (Object*)objmgr.GetObject<Creature>(guid)))
        {
            FillSystemMessageData(&data, m_session, "You should select a character or a creature.");
            m_session->SendPacket( &data );
            return true;
        }
    }
    else
        obj = (Object*)m_session->GetPlayer();

	char* pBytesIndex = strtok((char*)args, " ");
    if (!pBytesIndex)
        return false;

	uint32 BytesIndex  = atoi(pBytesIndex);

    char* pValue1 = strtok(NULL, " ");
    if (!pValue1)
        return false;

	uint8 Value1  = static_cast<uint8>(atol(pValue1));

	char* pValue2 = strtok(NULL, " ");
    if (!pValue2)
        return false;

	uint8 Value2  = static_cast<uint8>(atol(pValue2));

	char* pValue3 = strtok(NULL, " ");
    if (!pValue3)
        return false;

	uint8 Value3  = static_cast<uint8>(atol(pValue3));

	char* pValue4 = strtok(NULL, " ");
    if (!pValue4)
        return false;

	uint8 Value4  = static_cast<uint8>(atol(pValue4));

	std::stringstream sstext;
	sstext << "Set Field " << BytesIndex << " bytes to " << uint16((uint8)Value1) << " " << uint16((uint8)Value2) << " " << uint16((uint8)Value3) << " " << uint16((uint8)Value4) << '\0';
	obj->SetUInt32Value(BytesIndex, ( ( Value1 ) | ( Value2 << 8 ) | ( Value3 << 16 ) | ( Value4 << 24 ) ) );
	//sstext << "Bytes " << Bytes << " Set to " << Value1 << " " << Value2 << " " << Value3 << " " << Value4 << '\0';
	/*
	switch (BytesIndex)
	{
		case 0:
			obj->SetUInt32Value(UNIT_FIELD_BYTES_0, ( ( Value1 ) | ( Value2 << 8 ) | ( Value3 << 16 ) | ( Value4 << 24 ) ) );
		break;
		case 1:
			obj->SetUInt32Value(UNIT_FIELD_BYTES_1, ( ( Value1 ) | ( Value2 << 8 ) | ( Value3 << 16 ) | ( Value4 << 24 ) ) );
		break;
		case 2:
			obj->SetUInt32Value(UNIT_FIELD_BYTES_2, ( ( Value1 ) | ( Value2 << 8 ) | ( Value3 << 16 ) | ( Value4 << 24 ) ) );
		break;
	}
	*/
	FillSystemMessageData(&data, m_session, sstext.str().c_str());
    m_session->SendPacket( &data );
    return true;
}

bool ChatHandler::HandleGetBytesCommand(const char* args)
{
	WorldPacket data;
    Object *obj;

    uint64 guid = m_session->GetPlayer()->GetSelection();
    if (guid != 0)
    {
        if(!(obj = (Object*)objmgr.GetObject<Player>(guid)) && !(obj = (Object*)objmgr.GetObject<Creature>(guid)))
        {
            FillSystemMessageData(&data, m_session, "You should select a character or a creature.");
            m_session->SendPacket( &data );
            return true;
        }
    }
    else
        obj = (Object*)m_session->GetPlayer();

    char* pBytesIndex = strtok((char*)args, " ");
    if (!pBytesIndex)
        return false;

	uint32 BytesIndex  = atoi(pBytesIndex);
	uint32 theBytes = obj->GetUInt32Value(BytesIndex);
	/*
	switch (Bytes)
	{
		case 0:
			theBytes = obj->GetUInt32Value(UNIT_FIELD_BYTES_0);
		break;
		case 1:
			theBytes = obj->GetUInt32Value(UNIT_FIELD_BYTES_1);
		break;
		case 2:
			theBytes = obj->GetUInt32Value(UNIT_FIELD_BYTES_2);
		break;
	}
	*/
	std::stringstream sstext;
	sstext << "bytes for Field " << BytesIndex << " are " << uint16((uint8)theBytes & 0xFF) << " " << uint16((uint8)(theBytes >> 8) & 0xFF) << " ";
	sstext << uint16((uint8)(theBytes >> 16) & 0xFF) << " " << uint16((uint8)(theBytes >> 24) & 0xFF) << '\0';

	FillSystemMessageData(&data, m_session, sstext.str().c_str());
    m_session->SendPacket( &data );
    return true;
}
bool ChatHandler::HandleDebugLandWalk(const char* args)
{
    WorldPacket data;
    Player *chr = getSelectedChar(m_session);
    char buf[256];

    if (chr == NULL) // Ignatich: what should NOT happen but just in case...
    {
        FillSystemMessageData(&data, m_session, "No character selected.");
        m_session->SendPacket( &data );
        return false;
    }
    chr->SetMovement(MOVE_LAND_WALK);
    sprintf((char*)buf,"Land Walk Test Ran.");
    FillSystemMessageData(&data, m_session, buf);
    m_session->SendPacket( &data );
    return true;
}

bool ChatHandler::HandleDebugWaterWalk(const char* args)
{
    WorldPacket data;
    Player *chr = getSelectedChar(m_session);
    char buf[256];

    if (chr == NULL) // Ignatich: what should NOT happen but just in case...
    {
        FillSystemMessageData(&data, m_session, "No character selected.");
        m_session->SendPacket( &data );
        return false;
    }
    chr->SetMovement(MOVE_WATER_WALK);
    sprintf((char*)buf,"Water Walk Test Ran.");
    FillSystemMessageData(&data, m_session, buf);
    m_session->SendPacket( &data );
    return true;
}

bool ChatHandler::HandleDebugUnroot(const char* args)
{
    WorldPacket data;
    Player *chr = getSelectedChar(m_session);
    char buf[256];

    if (chr == NULL) // Ignatich: what should NOT happen but just in case...
    {
        FillSystemMessageData(&data, m_session, "No character selected.");
        m_session->SendPacket( &data );
        return false;
    }

    chr->SetMovement(MOVE_UNROOT);

    sprintf((char*)buf,"UnRoot Test Ran.");
    FillSystemMessageData(&data, m_session, buf);
    m_session->SendPacket( &data );
    return true;
}

bool ChatHandler::HandleDebugRoot(const char* args)
{
    WorldPacket data;
    Player *chr = getSelectedChar(m_session);
    char buf[256];

    if (chr == NULL) // Ignatich: what should NOT happen but just in case...
    {
        FillSystemMessageData(&data, m_session, "No character selected.");
        m_session->SendPacket( &data );
        return true;
    }
    chr->SetMovement(MOVE_ROOT);
    sprintf((char*)buf,"Root Test Ran.");
    FillSystemMessageData(&data, m_session, buf);
    m_session->SendPacket( &data );
    return true;
}
