//////////////////////////////////////////////////////////////////////
//  Spell Handler
//
//  Receives all messages with spell management opcodes
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

#ifndef WOWPYTHONSERVER_SPELLHANDLER_H
#define WOWPYTHONSERVER_SPELLHANDLER_H

#include "MsgHandler.h"

#include "Spell.h" //angelic|999
#include "UpdateMask.h" //angelic|999
#include <iostream> 
#include <cstdlib> 


class Unit;
class GameClient;
class DatabaseInterface;

class SpellHandler : public MsgHandler
{
public:
	SpellHandler();
	~SpellHandler();
	void HandleMsg( NetworkPacket & recv_data, GameClient *pClient );
	int applySpell( GameClient *pClient, Unit* target, uint32 spell, SpellInformation spellInfo);
	int usePotion(GameClient *pClient, uint32 spell, SpellInformation spellInfo, uint32 targets);
	int setAura(Unit *pUnit, uint32 spell);
	float CalcDistance(float sx, float sy, float sz, float dx, float dy, float dz);

	guid PetCreature (GameClient *pClient, char* pName); 
    
	float lrand, rrand; 
	float abstand, winkel; 
	float CalcDistance2d( float xe, float ye, float xz, float yz ); 
	bool inbogen( float radius,  float xM, float yM,float zM, float offnung, float drehung, float xP, float yP,float zP ); 
	float geteinfachererwinkel( float winkel ); 
	float getwinkel( float xe, float ye, float xz, float yz ); 


protected:

};

#endif
