#ifndef QUESTFUNCTIONS_H
#define QUESTFUNCTIONS_H

#include <sys/timeb.h>
#include "stdafx.h"
#include "WoWObject.h"
#include "UpdateObject.h"
#include "Item.h"
#include <list>
#include <deque>
#include <map>

void SendGossipMenu(CClient *pClient, unsigned long CreatureGuid);
void SendPOI(CClient *pClient, unsigned long X, unsigned long Y, char *name);
bool CanTakeQuest(CClient * pClient, unsigned long QuestID);
bool IsQuestAvailable(CClient *pClient, unsigned long QuestID);
unsigned long GetDialogStatus(CCreature *pCreature, CClient *pClient, unsigned long QuestID);
unsigned long GetQuestStatus(CClient *pClient, unsigned long QuestID);
void SetQuestStatus(CClient *pClient, unsigned long QuestID, unsigned long newstatus);
bool IsOnQuest(CClient *pClient, unsigned long QuestID);
bool CheckForQuestCompletion(CClient *pClient, unsigned long QuestID);
bool CanTakeQuest(CClient * pClient, unsigned long QuestID);
bool HasCompletedQuest(CClient *pClient, unsigned long QuestID);
void AddCreatureKill(CPlayer *pPlayer, unsigned long creatureid);
void SendQuestItemAdd(CPlayer *pPlayer, unsigned long ItemID, unsigned long NewCount);
void SendQuestKillAdd(CPlayer *pPlayer, CQuestInfo *pQuest, unsigned long MobListID, unsigned long KillCount, unsigned long CreatureGUID);
void AddItemLoot(CPlayer *pPlayer, unsigned long itemtemplateguid);
void SendSmallQuestDetails(CClient *pClient, unsigned long cguid, unsigned long questid);

#endif
