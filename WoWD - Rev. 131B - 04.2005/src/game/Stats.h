// Copyright (C) 2004 WoWD Team

#ifndef __STATS_H
#define __STATS_H

#include "Unit.h"
#include "UpdateMask.h"

/////////////////////////////////////////////////////////////////////////
//  CalculateXpToGive
//
//  Calculates XP given out by pVictim upon death.
//  xp = (SUM(health,power1,power2,power3,power4) / 5) * (lvl_of_monster*2)
////////////////////////////////////////////////////////////////////////
inline uint32 CalculateXpToGive(Unit *pVictim, Unit *pAttacker)
{
    uint32 xp = 1;
    uint32 total =  pVictim->GetUInt32Value(UNIT_FIELD_MAXHEALTH) +
                    pVictim->GetUInt32Value(UNIT_FIELD_MAXPOWER1) +
                    pVictim->GetUInt32Value(UNIT_FIELD_MAXPOWER2) +
                    pVictim->GetUInt32Value(UNIT_FIELD_MAXPOWER3) +
                    pVictim->GetUInt32Value(UNIT_FIELD_MAXPOWER4);

    xp = total / 5;
    xp *= pVictim->GetUInt32Value(UNIT_FIELD_LEVEL)*2;

/*
    // Maybe implement some modifier depending on difference of levels, but that might not be necessary
    // in theory a higher lvl mob will give higher xp thanks to having higher stats

    int lvl_diff_mod = (pVictim->GetUInt32Value(UNIT_FIELD_LEVEL) - pAttacker->GetUInt32Value(UNIT_FIELD_LEVEL)) / 3;
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
inline uint32 CalculateDamage(const Unit *pAttacker)
{
    uint32 attack_power = pAttacker->GetUInt32Value(UNIT_FIELD_ATTACKPOWER);
    
    /*if(pAttacker->GetTypeId() == TYPEID_PLAYER)
    {
       attack_power = pAttacker->GetUInt32Value(UNIT_FIELD_ATTACKPOWER);
       // attack_power += pAttacker->GetUInt32Value(PLAYER_FIELD_ATTACKPOWERMODPOS);
       // attack_power -= pAttacker->GetUInt32Value(PLAYER_FIELD_ATTACKPOWERMODNEG);

    }*/

    uint32 min_damage = (uint32)pAttacker->GetFloatValue(UNIT_FIELD_MINDAMAGE);
    uint32 max_damage = (uint32)pAttacker->GetFloatValue(UNIT_FIELD_MAXDAMAGE);
    // Ehh, sometimes min is bigger than max!?!?
    if (min_damage > max_damage){
        uint32 temp = max_damage;
        max_damage = min_damage;
        min_damage = temp;
    }

    uint32 diff = max_damage - min_damage + 1;
    uint32 dmg = rand()%diff + (uint32)min_damage + pAttacker->GetUInt32Value(UNIT_FIELD_LEVEL);
    return dmg;
}

#endif

