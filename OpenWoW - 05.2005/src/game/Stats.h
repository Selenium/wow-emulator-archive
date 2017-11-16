//////////////////////////////////////////////////////////////////////
//  Stats
//
//  Calulates XP and Damage
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

#ifndef WOWPYTHONSERVER_STATS_H
#define WOWPYTHONSERVER_STATS_H

#include "Common.h"
#include "Unit.h"
#include "UpdateMask.h"

/////////////////////////////////////////////////////////////////////////
//  CalculateXpToGive
//  
//  Calculates XP given out by pVictim upon death.
//  xp = (SUM(health,power1,power2,power3,power4) / 5) * (lvl_of_monster*2)
////////////////////////////////////////////////////////////////////////
uint32 CalculateXpToGive(Unit *pVictim, Unit *pAttacker)
{
    (void)pAttacker;
    uint32 xp = 1;
    uint32 total =  pVictim->getUpdateValue(UNIT_FIELD_MAXHEALTH) + 
                    pVictim->getUpdateValue(UNIT_FIELD_MAXPOWER1) + 
                    pVictim->getUpdateValue(UNIT_FIELD_MAXPOWER2) + 
                    pVictim->getUpdateValue(UNIT_FIELD_MAXPOWER3) +
                    pVictim->getUpdateValue(UNIT_FIELD_MAXPOWER4);

    xp = total / 5;
    xp *= pVictim->getUpdateValue(UNIT_FIELD_LEVEL)*2;
    
/*
    // Maybe implement some modifier depending on difference of levels, but that might not be necessary
    // in theory a higher lvl mob will give higher xp thanks to having higher stats

    int lvl_diff_mod = (pVictim->getUpdateValue(UNIT_FIELD_LEVEL) - pAttacker->getUpdateValue(UNIT_FIELD_LEVEL)) / 3;
    // level difference multiplier
    if (lvl_diff_mod < 0){
        // This monster is lower than the killer, reduce XP
        xp /= lvl_diff_mod;
    }
    else {
        // victim is higher level, increase XP
        xp *= lvl_diff_mod;
    }
*/
    return xp;
}

// TODO: Some awesome formula to determine how much damage to deal
uint32 CalculateDamage(const Unit *pAttacker)
{
//    uint32 attack_power = pAttacker->getUpdateValue(UNIT_FIELD_ATTACKPOWER);
//    attack_power += pAttacker->getUpdateValue(PLAYER_FIELD_ATTACKPOWERMODPOS);
//    attack_power -= pAttacker->getUpdateValue(PLAYER_FIELD_ATTACKPOWERMODNEG);

    uint32 min_damage = (uint32)pAttacker->getUpdateFloatValue(UNIT_FIELD_MINDAMAGE);
    uint32 max_damage = (uint32)pAttacker->getUpdateFloatValue(UNIT_FIELD_MAXDAMAGE);
    // Ehh, sometimes min is bigger than max!?!?
    if(min_damage > max_damage)
	{
        uint32 temp = max_damage;
        max_damage = min_damage;
        min_damage = temp;
    }

    uint32 diff = max_damage - min_damage + 1;
    uint32 dmg = rand()%diff + (uint32)min_damage;// + pAttacker->getUpdateValue(UNIT_FIELD_LEVEL);
    
	
	// BETTER DPS FORMULA
	
	
	
	
	return dmg;
}

#endif
