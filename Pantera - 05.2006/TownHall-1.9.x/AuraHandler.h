#ifndef AURAHANDLER_H
#define AURAHANDLER_H

#include "Client.h"

class AuraHandler
{
public:
	static long ApplyAura(CWoWObject *pPlayer, unsigned long SpellID, unsigned long AuraTime,bool positive);	// returns aura slot
	static long RemoveAura(CWoWObject *pPlayer);
	static void ApplyModifier(unsigned long auraslot, unsigned long ModID, unsigned long SpellID, bool apply, unsigned long Effect,long power, unsigned long time, unsigned long type,CWoWObject *pCaster,CWoWObject *pPlayer);
	static long ModStat(CWoWObject* pTarget,long power,int id,bool pos);
	static long ModResist(CWoWObject* pTarget,long power,int id,bool pos);
	static long ModStatPct(CWoWObject* pTarget,long power,int id,bool pos);
	static void ModForm(CWoWObject* pTarget,int id,bool apply);
};

#endif // SPELLHANDLER_H
