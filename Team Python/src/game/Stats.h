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

#ifndef WOWPYTHONSERVER_STATS_H
#define WOWPYTHONSERVER_STATS_H

#include "Common.h"
#include "Unit.h"
#include "UpdateMask.h"

/////////////////////////////////////////////////////////////////////////
//  CalculateXpToGive
//  
//  Calculates XP given out by pVictim upon death.
//  [ xp = (SUM(health,power1,power2,power3,power4) / 5) * (lvl_of_monster*2) ]
//  New Formula by {MAL1C3}
////////////////////////////////////////////////////////////////////////
uint32 CalculateXpToGive (Unit *pVictim, Unit *pAttacker){
	
	uint32 xp;
	uint32 total;
	
	uint32 pLevel = pAttacker->getUpdateValue(UNIT_FIELD_LEVEL);
	uint32 vLevel = pVictim->getUpdateValue(UNIT_FIELD_LEVEL);
	uint32 dLevel = pLevel - (vLevel + 4);

	if ( pLevel <= vLevel )
	{
		if (pLevel <= 3)
			{
				total = (vLevel * 10 + 40);
			}
		else if (pLevel > 3 && pLevel <= 9)
			{
				total = ((vLevel * 10 + 40) * 2);
			}
		else if (pLevel > 9 && pLevel <= 20)
			{
				total = ((vLevel * 10 + 40) * 4);
			}
		else if (pLevel > 20 && pLevel <=40)
			{
				total = ((vLevel * 10 + 40) * 6);
			}
		else if (pLevel > 40 && pLevel <= 60)
			{
				total = ((vLevel * 10 + 40) * 8);
			}
		else if (pLevel > 60 && pLevel <= 90)
			{
				total = ((vLevel * 10 + 40) * 10);
			}
		else if (pLevel > 90 && pLevel <= 120)
			{
				total = ((vLevel * 10 + 40) * 12);
			}
		else if (pLevel > 120 && pLevel <= 150)
			{
				total = ((vLevel * 10 + 40) * 14);
			}
		else if (pLevel > 150 && pLevel <= 180)
			{
				total = ((vLevel * 10 + 40) * 16);
			}
		else if (pLevel > 180 && pLevel <= 210)
			{
				total = ((vLevel * 10 + 40) * 18);
			}
		else if (pLevel > 180)
			{
				total = ((vLevel * 10 + 40) * 20);
			}
	}
		else
	{
		if (vLevel <= 3)
			{
				total = (vLevel * 6 + 40) - pLevel;
			}
		else if (vLevel > 3 && vLevel <= 9)
			{
				total = ((vLevel * 6 + 40) * 2) - pLevel;
			}
		else if (vLevel > 9 && vLevel <= 20)
			{
				total = ((vLevel * 6 + 40) * 4) - pLevel;
			}
		else if (vLevel > 20 && vLevel <=40)
			{
				total = ((vLevel * 6 + 40) * 6) - pLevel;
			}
		else if (vLevel > 40 && vLevel <= 60)
			{
				total = ((vLevel * 6 + 40) * 8) - pLevel;
			}
		else if (vLevel > 60 && vLevel <= 90)
			{
				total = ((vLevel * 6 + 40) * 10) - pLevel;
			}
		else if (vLevel > 90 && vLevel <= 120)
			{
				total = ((vLevel * 6 + 40) * 12) - pLevel;
			}
		else if (vLevel > 120 && vLevel <= 150)
			{
				total = ((vLevel * 6 + 40) * 14) - pLevel;
			}
		else if (vLevel > 150 && vLevel <= 180)
			{
				total = ((vLevel * 6 + 40) * 16) - pLevel;
			}
		else if (vLevel > 180 && vLevel <= 210)
			{
				total = ((vLevel * 6 + 40) * 18) - pLevel;
			}
		else if (vLevel > 180)
			{
				total = ((vLevel * 6 + 40) * 20) - pLevel;
			}
	}
	
	if ((dLevel < 0) && (dLevel <= -4))
	{
		xp = total / 1.5;
	}
	else if ((dLevel < -4) && (dLevel <= -10))
	{
		xp = total / 2;
	}
	else if (dLevel < -10)
	{
		xp = 0;
	}
	else
	{
		xp = total;
	}
	//xp *= pVictim->getUpdateValue(UNIT_FIELD_LEVEL)*2;
	return xp;
}


/*	
	uint32 xp;
	uint32 total;
	
	uint32 pLevel = pAttacker->getUpdateValue(UNIT_FIELD_LEVEL);
	uint32 vLevel = pVictim->getUpdateValue(UNIT_FIELD_LEVEL);
	uint32 dLevel = pLevel - vLevel;
	
	if (pLevel < (vLevel + 5) )
	{
		total = pVictim->getUpdateValue(UNIT_FIELD_MAXHEALTH) + 
                    pVictim->getUpdateValue(UNIT_FIELD_MAXPOWER1) + 
                    pVictim->getUpdateValue(UNIT_FIELD_MAXPOWER2) + 
                    pVictim->getUpdateValue(UNIT_FIELD_MAXPOWER3) +
                    pVictim->getUpdateValue(UNIT_FIELD_MAXPOWER4);
	}

	else 
	{
		total =  ((pVictim->getUpdateValue(UNIT_FIELD_MAXHEALTH) + 
                 pVictim->getUpdateValue(UNIT_FIELD_MAXPOWER1) + 
                 pVictim->getUpdateValue(UNIT_FIELD_MAXPOWER2) + 
                 pVictim->getUpdateValue(UNIT_FIELD_MAXPOWER3) +
                 pVictim->getUpdateValue(UNIT_FIELD_MAXPOWER4)) / 2);
	}


	xp = total / 3;
    xp *= pVictim->getUpdateValue(UNIT_FIELD_LEVEL)*2;

	return xp;
}
*/
/*
uint32 CalculateXpToGive(Unit *pVictim, Unit *pAttacker)
{
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
///*
    return xp;
}
*/

// TODO: Some awesome formula to determine how much damage to deal
uint32 CalculateDamage(const Unit *pAttacker)
{
	uint32 min_damage, max_damage, mob=0;
	if (pAttacker->getUpdateValue(PLAYER_NEXT_LEVEL_XP) != NULL) {
		min_damage = (uint32)pAttacker->getUpdateFloatValue(UNIT_FIELD_MINDAMAGE);

		max_damage = (uint32)pAttacker->getUpdateFloatValue(UNIT_FIELD_MAXDAMAGE);
	}

	else {
		uint32 level = 	pAttacker->getUpdateValue(UNIT_FIELD_LEVEL);

		min_damage = (uint32)(20 + 30*level)*0.05;

		max_damage = (uint32)(20 + 30*level)*0.10;

		mob = 1;
	}

    // Ehh, sometimes min is bigger than max!?!?


    if(min_damage > max_damage)
	{

		uint32 temp = max_damage;
		max_damage = min_damage;

		min_damage = temp;

	}

	uint32 diff = max_damage - min_damage;

	if (diff<=0) diff = 1;
    int dmg = 1;

	if (rand()%100>85) {  // 15% miss

	dmg = 0;
	}

	else if (rand()%100>90 && mob) { // 10% crit

		dmg = (rand()%diff + max_damage) *1.5;

	}

	else {  // 75% normal dmg

		dmg = rand()%diff + min_damage;

	}

    return dmg;


}


#endif
