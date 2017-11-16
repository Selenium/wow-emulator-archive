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

void SendGossipMenu(CClient *pClient, guid_t CreatureGuid);
void SendPOI(CClient *pClient, unsigned long X, unsigned long Y, char *name);
bool CanTakeQuest(CClient * pClient, guid_t QuestID);
unsigned long GetDialogStatus(CCreature *pCreature, CClient *pClient, guid_t QuestID);
unsigned long GetQuestStatus(CClient *pClient, guid_t QuestID);
void SetQuestStatus(CClient *pClient, guid_t QuestID, unsigned long newstatus);
bool CheckForQuestCompletion(CClient *pClient, CQuestInfo *pQuest);
bool HasCompletedQuest(CClient *pClient, guid_t QuestID);
void AddCreatureKill(CPlayer *pPlayer, guid_t creatureid);
void AddExploreArea(CPlayer *pPlayer, unsigned long AreaID);
void SendQuestItemAdd(CPlayer *pPlayer, unsigned long ItemID, unsigned long NewCount);
void SendQuestKillAdd(CPlayer *pPlayer, CQuestInfo *pQuest, unsigned long MobListID, unsigned long KillCount, guid_t CreatureGUID);
void AddItemLoot(CPlayer *pPlayer, guid_t itemtemplateguid, long stacked=1);
void ExpireQuest(CClient *pClient, unsigned long logslot);
void SendSmallQuestDetails(CClient *pClient, guid_t cguid, guid_t questid);

#endif
