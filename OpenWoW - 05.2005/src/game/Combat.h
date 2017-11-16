//////////////////////////////////////////////////////////////////////
//  Combat
//
//  Provides basic Combat functions
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

#ifndef WOWPYTHONSERVER_COMBATHANDLER_H
#define WOWPYTHONSERVER_COMBATHANDLER_H

#include "MsgHandler.h"
#include "Object.h"

class Unit;
class GameClient;
struct NetworkPacket;
struct UpdateMask;
class CombatHandler
{
public:
	CombatHandler() {};
	virtual ~CombatHandler() {};

	void HandleMsg (NetworkPacket & recv_data, GameClient *pClient);

	/////////////////////////////////////////////////////////////////////////
	//  Deals damage from pAttacker to pVictim
	//  Does checks for death and lots of other keen things
	void DealDamage (Unit *pAttacker, Unit *pVictim, uint32 damage);

	void smsg_AttackStart (Unit* pAttacker, Unit* pVictim);
	void smsg_AttackStop (Unit* pAttacker, guid victim_guid);

	void AttackerStateUpdate (Unit *pAttacker, Unit *pVictim, uint32 damage);
	void Heal (Unit *pAttacker, Unit *pVictim, uint32 damage);

	uint32 petGUID;

};

#endif
