// Copyright (C) 2004 WoW Daemon
// Copyright (C) 2005 Oxide
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

#ifndef __STATS_H
#define __STATS_H

#include "Unit.h"
#include "UpdateMask.h"

enum Stats
{
	STAT_STRENGTH,
	STAT_AGILITY,
	STAT_STAMINA,
	STAT_INTELLECT,
	STAT_SPIRIT,
};

/*ZD = 5, when Char Level = 1 - 7
ZD = 6, when Char Level = 8 - 9
ZD = 7, when Char Level = 10 - 11
ZD = 8, when Char Level = 12 - 14
ZD = 9, when Char Level = 16 - 19 (15-19?)
ZD = 11, when Char Level = 20 - 29
ZD = 12, when Char Level = 30 - 39
ZD = 13, when Char Level = 40 - 44
ZD = 14, when Char Level = 45 - 49
ZD = 15, when Char Level = 50 - 53 (50-54?)
ZD = 16, when Char Level = 55 - 59 (guessed) 
ZD = 17, when Char Level = 60 (guessed) */

/////////////////////////////////////////////////////////////////////////		  30
//  CalculateXpToGive
//
//  Calculates XP given out by pVictim upon death.
//  XP=(MOB_LEVEL*5+45)*(1+0.05*(MOB_LEVEL-PLAYER_LEVEL)) 
//  from http://wowwow.game-host.org/viewtopic.php?t=857&sid=07e3a117e26e43358dd23cf260c0c7ad
//
//
//old formula xp = (SUM(health,power1,power2,power3,power4) / 5) * (lvl_of_monster*2)
////////////////////////////////////////////////////////////////////////
inline uint32 CalculateXpToGive(Unit *pVictim, Unit *pAttacker)
{
	CreatureInfo *victimI = pVictim->GetCreatureName();
	if(victimI)
	{
		if(victimI->Type == CRITTER)
			return 0;
	}
	if(pVictim->GetTypeId() == TYPEID_PLAYER)
		return 0;
	if(pAttacker->getLevel() >= 60)
		return 0;
	uint16 VictimLvl = pVictim->GetUInt32Value(UNIT_FIELD_LEVEL);
	uint16 AttackerLvl = pAttacker->GetUInt32Value(UNIT_FIELD_LEVEL);
	int xp = 0;
	int greylvl = 0;
	int ZD[61] = {1,5,5,5,5,5,5,5,6,6,7,7,8,8,8,9,9,9,9,9,11,11,11,11,11,11,11,11,11,11,12,12,12,12,12,12,12,12,12,12,13,13,13,13,13,14,14,14,14,14,15,15,15,15,15,16,16,16,16,16,17};	
	if( VictimLvl > AttackerLvl )
		//		xp = (VictimLvl*5+45)*(1+0.05*(VictimLvl-AttackerLvl));
		xp = (AttackerLvl*5+45)*(1+0.05*(VictimLvl-AttackerLvl));
	else if( VictimLvl = AttackerLvl )
		xp = AttackerLvl*5+45;
	else
	{
		//		xp = (VictimLvl*5+45)*(1-((VictimLvl-AttackerLvl)/ZD[AttackerLvl]));
		if( AttackerLvl < 6 )
			greylvl = 0;
		else if( AttackerLvl > 5 && VictimLvl < 40 )
			greylvl = AttackerLvl - 5 - (VictimLvl/10);
		else
			greylvl = AttackerLvl - 1 - (VictimLvl/5);
		if( VictimLvl > greylvl )
			xp = (AttackerLvl*5+45)*(1-((VictimLvl-AttackerLvl)/ZD[AttackerLvl]));
		else
			xp = 0;
	}	
	if( xp < 0 ) //|| ((VictimLvl<(AttackerLvl * 0.8)) && (AttackerLvl > 5)) )
		xp = 0;
	else
		xp *= sWorld.getRate(RATE_XP);

	//Rest
	/*	if( pAttacker->HasFlag(PLAYER_FLAGS, 0x1000)
	|| pAttacker->HasFlag(PLAYER_FLAGS, 0x2000) )
	xp *= 2;*/


	/*

	uint32 xp = 1;
	uint32 total =  pVictim->GetUInt32Value(UNIT_FIELD_MAXHEALTH) +
	pVictim->GetUInt32Value(UNIT_FIELD_MAXPOWER1) +
	pVictim->GetUInt32Value(UNIT_FIELD_MAXPOWER2) +
	pVictim->GetUInt32Value(UNIT_FIELD_MAXPOWER3) +
	pVictim->GetUInt32Value(UNIT_FIELD_MAXPOWER4);

	xp = total / 5;
	xp *= pVictim->GetUInt32Value(UNIT_FIELD_LEVEL)*2*sWorld.getRate(RATE_XP);
	*/
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

//Taken from WoWWoW Source
/*
Author: pionere

Calculate the stat increase. Using 3rd grade polynome.

Parameter level The level the character reached.
Parameter a3 The factor for x^3.
Parameter a2 The factor for x^2.
Parameter a1 The factor for x^1.
Parameter a0 The constant factor for the polynome.
Return stat gain
*/
inline uint32 CalculateStat(uint16 level,double a3, double a2, double a1, double a0)
{
	int result1;
	int result2;
	int diff;

	result1 =	(a3*level*level*level +
		a2*level*level +
		a1*level +
		a0);

	result2 =	(a3*(level-1)*(level-1)*(level-1) +
		a2*(level-1)*(level-1) +
		a1*(level-1) +
		a0);

	//get diffrence
	diff = result1-result2;
	return diff;
}
//Partialy taken from WoWWoW Source
inline uint32 GainStat(uint16 level, uint8 playerclass,uint8 Stat)
{
	uint32 gain = 0;
	switch(playerclass)
	{
	case WARRIOR:
		{
			if(Stat == STAT_STRENGTH) gain = CalculateStat(level, 0.000039, 0.006902, 1.080040, -1.051701);
			if(Stat == STAT_AGILITY) gain = CalculateStat(level, 0.000022, 0.004600, 0.655333, -0.600356);
			if(Stat == STAT_STAMINA) gain = CalculateStat(level, 0.000059, 0.004044, 1.040000, -1.488504);
			if(Stat == STAT_INTELLECT) gain = CalculateStat(level, 0.000002, 0.001003, 0.100890, -0.076055);
			if(Stat == STAT_SPIRIT) gain = CalculateStat(level, 0.000006, 0.002031, 0.278360, -0.340077);
		}break;

	case PALADIN:
		{
			if(Stat == STAT_STRENGTH) gain = CalculateStat(level, 0.000037, 0.005455, 0.940039, -1.000090);
			if(Stat == STAT_AGILITY) gain = CalculateStat(level, 0.000020, 0.003007, 0.505215, -0.500642);
			if(Stat == STAT_STAMINA) gain = CalculateStat(level, 0.000038, 0.005145, 0.871006, -0.832029);
			if(Stat == STAT_INTELLECT) gain = CalculateStat(level, 0.000023, 0.003345, 0.560050, -0.562058);
			if(Stat == STAT_SPIRIT) gain = CalculateStat(level, 0.000032, 0.003025, 0.615890, -0.640307);
		}break;

	case HUNTER:
		{
			if(Stat == STAT_STRENGTH) gain = CalculateStat(level, 0.000022, 0.001800, 0.407867, -0.550889);
			if(Stat == STAT_AGILITY) gain = CalculateStat(level, 0.000040, 0.007416, 1.125108, -1.003045);
			if(Stat == STAT_STAMINA) gain = CalculateStat(level, 0.000031, 0.004480, 0.780040, -0.800471);
			if(Stat == STAT_INTELLECT) gain = CalculateStat(level, 0.000020, 0.003007, 0.505215, -0.500642);
			if(Stat == STAT_SPIRIT) gain = CalculateStat(level, 0.000017, 0.003803, 0.536846, -0.490026);
		}break;

	case ROGUE:
		{
			if(Stat == STAT_STRENGTH) gain = CalculateStat(level, 0.000025, 0.004170, 0.654096, -0.601491);
			if(Stat == STAT_AGILITY) gain = CalculateStat(level, 0.000038, 0.007834, 1.191028, -1.203940);
			if(Stat == STAT_STAMINA) gain = CalculateStat(level, 0.000032, 0.003025, 0.615890, -0.640307);
			if(Stat == STAT_INTELLECT) gain = CalculateStat(level, 0.000008, 0.001001, 0.163190, -0.064280);
			if(Stat == STAT_SPIRIT) gain = CalculateStat(level, 0.000024, 0.000981, 0.364935, -0.570900);
		}break;

	case PRIEST:
		{
			if(Stat == STAT_STRENGTH) gain = CalculateStat(level, 0.000008, 0.001001, 0.163190, -0.064280);
			if(Stat == STAT_AGILITY) gain = CalculateStat(level, 0.000022, 0.000022, 0.260756, -0.494000);
			if(Stat == STAT_STAMINA) gain = CalculateStat(level, 0.000024, 0.000981, 0.364935, -0.570900);
			if(Stat == STAT_INTELLECT) gain = CalculateStat(level, 0.000039, 0.006981, 1.090090, -1.006070);
			if(Stat == STAT_SPIRIT) gain = CalculateStat(level, 0.000040, 0.007416, 1.125108, -1.003045);
		}break;

	case SHAMAN:
		{
			if(Stat == STAT_STRENGTH) gain = CalculateStat(level, 0.000035, 0.003641, 0.734310, -0.800626);
			if(Stat == STAT_AGILITY) gain = CalculateStat(level, 0.000022, 0.001800, 0.407867, -0.550889);
			if(Stat == STAT_STAMINA) gain = CalculateStat(level, 0.000020, 0.006030, 0.809570, -0.809220);
			if(Stat == STAT_INTELLECT) gain = CalculateStat(level, 0.000031, 0.004480, 0.780040, -0.800471);
			if(Stat == STAT_SPIRIT) gain = CalculateStat(level, 0.000038, 0.005145, 0.871006, -0.832029);
		}break;

	case MAGE:
		{
			if(Stat == STAT_STRENGTH) gain = CalculateStat(level, 0.000002, 0.001003, 0.100890, -0.076055);
			if(Stat == STAT_AGILITY) gain = CalculateStat(level, 0.000008, 0.001001, 0.163190, -0.064280);
			if(Stat == STAT_STAMINA) gain = CalculateStat(level, 0.000006, 0.002031, 0.278360, -0.340077);
			if(Stat == STAT_INTELLECT) gain = CalculateStat(level, 0.000040, 0.007416, 1.125108, -1.003045);
			if(Stat == STAT_SPIRIT) gain = CalculateStat(level, 0.000039, 0.006981, 1.090090, -1.006070);
		}break;

	case WARLOCK:
		{
			if(Stat == STAT_STRENGTH) gain = CalculateStat(level, 0.000006, 0.002031, 0.278360, -0.340077);
			if(Stat == STAT_AGILITY) gain = CalculateStat(level, 0.000024, 0.000981, 0.364935, -0.570900);
			if(Stat == STAT_STAMINA) gain = CalculateStat(level, 0.000021, 0.003009, 0.486493, -0.400003);
			if(Stat == STAT_INTELLECT) gain = CalculateStat(level, 0.000059, 0.004044, 1.040000, -1.488504);
			if(Stat == STAT_SPIRIT) gain = CalculateStat(level, 0.000040, 0.006404, 1.038791, -1.039076);
		}break;

	case DRUID:
		{
			if(Stat == STAT_STRENGTH) gain = CalculateStat(level, 0.000021, 0.003009, 0.486493, -0.400003);
			if(Stat == STAT_AGILITY) gain = CalculateStat(level, 0.000041, 0.000440, 0.512076, -1.000317);
			if(Stat == STAT_STAMINA) gain = CalculateStat(level, 0.000023, 0.003345, 0.560050, -0.562058);
			if(Stat == STAT_INTELLECT) gain = CalculateStat(level, 0.000038, 0.005145, 0.871006, -0.832029);
			if(Stat == STAT_SPIRIT) gain = CalculateStat(level, 0.000059, 0.004044, 1.040000, -1.488504);
		}break;
	}
	return gain;
}

// TODO: Some awesome formula to determine how much damage to deal
inline uint32 CalculateDamage(const Unit *pAttacker)
{
	uint32 attack_power = pAttacker->GetUInt32Value(UNIT_FIELD_ATTACK_POWER);

	/*if(pAttacker->GetTypeId() == TYPEID_PLAYER)
	{
	attack_power = pAttacker->GetUInt32Value(UNIT_FIELD_ATTACKPOWER);
	// attack_power += pAttacker->GetUInt32Value(PLAYER_FIELD_ATTACKPOWERMODPOS);
	// attack_power -= pAttacker->GetUInt32Value(PLAYER_FIELD_ATTACKPOWERMODNEG);

	}*/

	uint32 min_damage = pAttacker->GetFloatValue(UNIT_FIELD_MINDAMAGE);
	uint32 max_damage = pAttacker->GetFloatValue(UNIT_FIELD_MAXDAMAGE);
	// Ehh, sometimes min is bigger than max!?!?
	if (min_damage > max_damage){
		uint32 temp = max_damage;
		max_damage = min_damage;
		min_damage = temp;
	}

	// Fix creatures that have no base attack damage.    
	if(max_damage==0)
		max_damage=5;

	uint32 diff = max_damage - min_damage + 1;
	uint32 dmg = rand()%diff + (uint32)min_damage;
	return dmg;
}

inline bool isEven (int num)
{
	if ((num%2)==0) 
	{
		return true;
	}
	return false;
}

#endif

