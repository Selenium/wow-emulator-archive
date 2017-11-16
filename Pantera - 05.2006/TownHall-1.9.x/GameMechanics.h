#ifndef GAMEMECHANICS_H
#define GAMEMECHANICS_H

class GameMechanics
{
public:
	static long CalculateKillXP(CCreature *pCreature, CPlayer *pPlayer, long *OrigExp=NULL);
	static long GenerateQuestXP(CPlayer *pPlayer, CQuestInfo *pQuest);
	static float CalculateDamage(CWoWObject *pAttacker, CWoWObject *pVictim, long &flags, long &victimflags, float &absorbed);
	static void GiveXP(CPlayer *pPlayer, long exp);
	static void RageForGettingHit(CPlayer *pPlayer, CWoWObject *pAttacker, unsigned long dmg);
	static void RageForHitting(CPlayer *pPlayer, CWoWObject *pAttacker, unsigned long dmg);
	static void SendSpiritHealerGossipMenu(CClient *pClient, CCreature *pCreature);
	static void HandleSpiritHealerGossipSelect(CClient *pClient, CCreature *pCreature);
	static void SpiritHealerTextQuery(CClient *pClient, CCreature *pCreature);
	static void AttackSwing(CWoWObject *pAttacker, CWoWObject *pVictim);
};

#endif
