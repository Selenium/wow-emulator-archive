#pragma once
// Copyright (C) 2004 WoWD Team

#ifndef __STATS_H
#define __STATS_H

#include "Unit.h"
#include "UpdateMask.h"
#include "../Scripts/Scripts.h"

//-----------------------------------------------------------------------------
//  CalculateXpToGive
//-----------------------------------------------------------------------------
inline uint32 CalculateXpToGive(Unit *pVictim, Unit *pKiller)
{
	//-----------------------------------------------
	// Check initial tagger, who damaged first - gets
	// creature tag and awarded with XP and loot
	//-----------------------------------------------
	Unit * tagger = pVictim->GetTagger();
	if (tagger != NULL && pKiller->GetGUID() != tagger->GetGUID())
	{
		Log::getSingleton().outDebug ("CalculateXP: Killer GUID=%X is not an initial tagger GUID=%X",
			pKiller->GetGUIDLow(), tagger->GetGUIDLow());
		return 0;
	}

	// Using External XP function from Python scripts, functions.py file, CalcXP() function
	uint32 xp = Call_CalcXP (pKiller, pVictim);
	return xp;
}

// Calculates Damage Reduction
inline uint32 CalcDamageReduction (Unit *pVictim, Unit *pAttacker)
{
	// Using External XP function from Python scripts, functions.py file, CalcDamageReduction() function
	return Call_CalcDR(pVictim, pAttacker);
}

// Calculates Exploration XP
inline uint32 CalcExplorationXP (Unit *pUnit)
{
	return pUnit->GetLevel()*10 + 45;
}

#endif

