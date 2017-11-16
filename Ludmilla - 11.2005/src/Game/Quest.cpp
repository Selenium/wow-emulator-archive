/*
 *  **********  (c) 2005 PavkaM. Ludmilla Project *************
 */

#include "StdAfx.h"

//------------------------------------------------------------
// Returns true if a quest posseses such a behavior flag
bool Quest::HasBehavior( uint32 bhflag )
{
	return ((m_questBehavior & bhflag) == bhflag);
}

//------------------------------------------------------------
// Generates XP for player depending on his level and quest level.
// Also more data is getting into calculation.
uint32 Quest::GenerateQuestXP( Player *pPlayer )
{
   #define XP_INC 50
   #define XP_DEC 10
   #define XP_INC100 15
   #define XP_DEC100 5

	double xp, pxp, mxp, mmx;

	 xp  = m_questLevel * XP_INC;
	pxp  = xp + (xp / 100) * XP_INC100;

	xp   = pPlayer->GetLevel() * XP_DEC;
	mxp  = xp + (xp / 100) * XP_DEC100;

	mmx = pxp - mxp;

	
	if (HasBehavior( QUEST_BEHAVIOR_SPEAKTO    )) mmx *= 0.6;
	if (HasBehavior( QUEST_BEHAVIOR_TIMED      )) mmx *= 1.1;
	if (HasBehavior( QUEST_BEHAVIOR_REPEATABLE )) mmx *= 0.2;
	if (HasBehavior( QUEST_BEHAVIOR_EXPLORE    )) mmx *= 1.2;
	if ( this->m_questType != 0 ) mmx *= 2.3;

	return (int)mmx;
}

//------------------------------------------------------------
// True if player already finished the quest and got the reward.
// Use this func instead of Player::getQuestRewardStatus.
bool Quest::QuestRewardIsTaken( Player *pPlayer )
{
	bool bResult = false;
	if ( ( m_questBehavior & QUEST_BEHAVIOR_REPEATABLE ) != QUEST_BEHAVIOR_REPEATABLE ) 
		bResult = ( pPlayer->getQuestRewardStatus( m_questId ) );

	return bResult;
}

//------------------------------------------------------------
// Checks if a quest can be taken by player.
// It checks for PreRequs, for reward, and for compatibility.
bool Quest::QuestIsTakable( Player *pPlayer )
{
	bool result = ( !QuestRewardIsTaken( pPlayer ) && QuestIsCompatible( pPlayer ) && 
		     QuestPreReqSatisfied( pPlayer ) );

	Log::getSingleton().outDebug("QMCHECK: Quest '%u' can be taken.\n", this->m_questId );

	return result;
}

//------------------------------------------------------------
// Check for class/race/... compatibility of a player and quest
// 
bool Quest::QuestIsCompatible( Player *pPlayer )
{
	return ( QuestReputationSatisfied( pPlayer ) &&
		     QuestRaceSatisfied( pPlayer ) &&
			 QuestClassSatisfied( pPlayer ) &&
			 QuestTradeSkillSatisfied( pPlayer ) );
}

//------------------------------------------------------------
// Checks for Reputation satisfaction.
// 
bool Quest::QuestReputationSatisfied( Player *pPlayer )
{
	return true;
	// needs implementation
}

//------------------------------------------------------------
// Player-Quest TradeSkill compatibilty
// 
bool Quest::QuestTradeSkillSatisfied( Player *pPlayer )
{
	return true;
	// needs core implementation
}

//------------------------------------------------------------
// Player-Quest Race compatibilty
// 
bool Quest::QuestRaceSatisfied( Player *pPlayer )
{
	if ( m_questRaces == QUEST_RACE_NONE ) return true;
	return (((m_questRaces >> (pPlayer->GetRace() - 1)) & 0x01) == 0x01);
}

//------------------------------------------------------------
// Player-Quest Class compatibilty
// 
bool Quest::QuestClassSatisfied( Player *pPlayer )
{
	if ( m_questClass == QUEST_CLASS_NONE ) return true;
	return (m_questClass == pPlayer->GetClass());
}

//------------------------------------------------------------
// Player-Quest Lavel check.
// 
bool Quest::QuestLevelSatisfied( Player *pPlayer )
{
	return ( pPlayer->GetLevel() >= m_requiredLevel );
}

//------------------------------------------------------------
// Checks if a NPC can show yellow [!]. Level dep.
// 
bool Quest::QuestCanShowAvailable( Player *pPlayer )
{
	uint8 iPLevel;
	iPLevel = pPlayer->GetLevel();

	if ( iPLevel < m_requiredLevel ) return false;
	return ( (iPLevel - m_requiredLevel) <= 7 );
}

//------------------------------------------------------------
// Checks if a NPC can show gray [!]. Level dep.
// 
bool Quest::QuestCanShowUnsatified( Player *pPlayer )
{
	uint8 iPLevel;
	iPLevel = pPlayer->GetLevel();

	if ( iPLevel > m_requiredLevel ) return false;
	return ( (m_requiredLevel - iPLevel) <= 7 );
}

//------------------------------------------------------------
// Checks for prerequites. Note: it checks for Open, Require and Lock.
// 
bool Quest::QuestPreReqSatisfied( Player *pPlayer )
{
	//return true;
	bool bResult = true;

	if ( m_previousQuests > 0 )
	{
		bResult = false;
		for (uint32 iI = 0; iI < m_previousQuests; iI++ )
			bResult |= pPlayer->getQuestRewardStatus( m_previousQuest[iI] );
	}

	if (!bResult) return false;

	if ( m_previousQuests_Lock > 0 )
	{
		for (uint32 iI = 0; iI < m_previousQuests_Lock; iI++ )
			bResult &= pPlayer->getQuestRewardStatus( m_previousQuest[iI] );
	}

	if (!bResult) return false;

	if ( m_lockQuests > 0 )
	{
		for (uint32 iI = 0; iI < m_lockQuests; iI++ )
		{
			bResult &= (!pPlayer->getQuestRewardStatus( m_lockQuest[iI] ));
			bResult &= (pPlayer->getQuestStatus( m_lockQuest[iI] ) != QUEST_STATUS_COMPLETE);
			bResult &= (pPlayer->getQuestStatus( m_lockQuest[iI] ) != QUEST_STATUS_INCOMPLETE);
		}
	}

	return bResult;
}
