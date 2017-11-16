#include "QuestFunctions.h"
#include "Quest.h"
#include "Player.h"
#include "Client.h"
#include "Creature.h"
#include "Globals.h"
#include "UpdateBlock.h"
#include "Party.h"
#include "Spell.h"
#include "Packets.h"
#include "GameMechanics.h"
#include "MsgHandlers.h"
#include "DataManager.h"
#include "Quest.h"

void SendPOI(CClient *pClient, unsigned long X, unsigned long Y, char *name)
{
	CPacket pkg;
	pkg.Reset(SMSG_GOSSIP_POI);
	pkg << (unsigned long)99;	// flags
	pkg << (float)X;
	pkg << (float)Y;
	pkg << (unsigned long)6;	// icon
	pkg << (unsigned long)0;	// data
	pkg << name;

	pClient->Send(&pkg);
}
void SendGossipMenu(CClient *pClient, unsigned long CreatureGuid)
{
	CPacket pkg;
	pkg.Reset(SMSG_GOSSIP_MESSAGE);
	pkg << CreatureGuid << CREATUREGUID_HIGH;

	CCreature* pCreature = NULL;
	// pClient->Echo("Finding creature");
	if (!DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE,CreatureGuid)) {
		// pClient->Echo("couldn't find creature");
	} else {
		CCreatureTemplate *pCreatureTemplate = NULL;
		if (DataManager.RetrieveObject((CWoWObject**)&pCreatureTemplate, OBJ_CREATURETEMPLATE, pCreature->Data.Template))
		{
			// pClient->Echo("%i",pCreature->Data.Template);
		} else {
			// pClient->Echo("couldnt find templ");
		}
	}
	if (pCreature->pTemplate->guid == 0x0800195b)	// Spirit Healer
	{
		GameMechanics::SendSpiritHealerGossipMenu(pClient,pCreature);
		return;
	}
	if (strlen(pCreature->pTemplate->Data.QuestGiverText) > 2)
	{
		pkg << (unsigned long)pCreature->pTemplate->guid;
	} else {
		// npc text lookup here
		pkg << (unsigned long)999999;
	}

	/*pkg << (unsigned long)DataManager.GossipMenus[pCreature->guid].size();							// Number of menu items
	//pkg << (unsigned long)2;
	unsigned long j=0;
	for (std::list<_GossipItem>::iterator i=DataManager.GossipMenus[pCreature->guid].begin();i!=DataManager.GossipMenus[pCreature->guid].end();i++)
	{
	pkg << (unsigned long)j;
	pkg << (unsigned char)(*i).Icon;
	pkg << (unsigned char)(*i).Inputbox;
	pkg << (*i).Message;
	j++;
	}*/
	char filetoopen[128];
	sprintf(filetoopen, "data/gossipmenus/%s.txt", pCreature->pTemplate->Data.Name);
	FILE *file=NULL; // guess what? ifstream doesn't work in Linux, and it eats resources.
	if(_FileExists(filetoopen))
		file=fopen(filetoopen, "rt"); // open it *only if* we can find the file

	if (!file)
	{
		pkg << (unsigned long)0;
		Packets::DefaultGossipMenu(pClient,CreatureGuid);
		return;
	} else {
		char commandtext[256];
		std::list<string> GossipItems;
		while (fgets(commandtext,255,file))
		{
			commandtext[strlen(commandtext)-1]=0;
			char *itemtitle = strtok(commandtext,":");
			//char *itemtext = &commandtext[strlen(commandtext)+1];
			GossipItems.push_back(itemtitle);
		}
		fclose(file);

		pkg << (unsigned long)GossipItems.size()+1;
		int m=0;
		for(std::list<string>::iterator l=GossipItems.begin();l!=GossipItems.end();l++)
		{
			pkg << (unsigned long)m;
			pkg << (unsigned char)0;
			pkg << (unsigned char)0;
			pkg << (*l).c_str();
			m++;
		}
		GossipItems.clear();
	}
	pkg << (unsigned long)100;
	pkg << (unsigned char)0;
	pkg << (unsigned char)0;
	pkg << "I'm done talking to you.";
	pClient->Send(&pkg);
}

bool CanTakeQuest(CClient * pClient, unsigned long QuestID)
{
	if (pClient->pPlayer->EnableAllQuests)
		return true;		// admin has enabled all quests

	CQuestInfo *pQuest;
	if (!DataManager.RetrieveObject((CWoWObject**)&pQuest, OBJ_QUESTINFO, QuestID))
		return false;

	// Check levels
	if (pClient->pPlayer->Data.Level < pQuest->Data.reqlevel)
		return false;

	// Check previous quests
	if (pQuest->Data.prevquests > 0)
	{
		unsigned long i=0;
		for(i=0;i<=pQuest->Data.prevquests;i++)
		{
			if (!HasCompletedQuest(pClient, pQuest->Data.previousquest[i]))
				return false;
		}
	}

	// todo: check factions, etc

	// Everything is fine, they can take the quest! :>
	return true;
}

bool HasCompletedQuest(CClient *pClient, unsigned long QuestID)
{
	if (GetQuestStatus(pClient, QuestID) != QUEST_STATUS_COMPLETED)
		return false;

	return true;
}
bool IsQuestAvailable(CClient *pClient, unsigned long QuestID)
{
	/*
	switch (pClient->pPlayer->Data.QuestStatus[QuestID])
	{
	case QUEST_STATUS_NONE:
	if (CanTakeQuest(pClient,QuestID))
	{
	SetQuestStatus(pClient,QuestID,QUEST_STATUS_AVAILABLE);
	return true;
	} else {
	return false;
	}
	case QUEST_STATUS_COMPLETE:
	return false;
	case QUEST_STATUS_INCOMPLETE:
	return false;
	case QUEST_STATUS_AVAILABLE:
	return true;
	case QUEST_STATUS_COMPLETED:
	return false;
	}*/
	return false;
}

unsigned long GetQuestStatus(CClient *pClient, unsigned long QuestID)
{
	unsigned long i = 0;
	int exists = 0;
	for(i=0;i <= pClient->pPlayer->Data.QuestCounter;i++)
	{
		if (pClient->pPlayer->Data.Quests[i].QuestID == QuestID)
		{
			exists = i;
			break;
		}
	}

	if (exists == 0)
	{
		return QUEST_STATUS_NONE;
	}
	return pClient->pPlayer->Data.Quests[i].State;
}

unsigned long GetDialogStatus(CCreature *pCreature, CClient *pClient, unsigned long QuestID)
{
	CQuestInfo *pQuest;

	if (!DataManager.RetrieveObject((CWoWObject**)&pQuest, OBJ_QUESTINFO, QuestID))
		return DIALOG_STATUS_NONE;

	unsigned long questguid;

	for(std::list<unsigned long>::iterator i=DataManager.CreatureInvolvedRelation[pCreature->Data.Template].begin();i!=DataManager.CreatureInvolvedRelation[pCreature->Data.Template].end();i++)
	{
		// Check for involvers
		questguid = (*i);
		if (GetQuestStatus(pClient, questguid) == QUEST_STATUS_COMPLETE)
			return DIALOG_STATUS_REWARD;
	}

	if (GetQuestStatus(pClient, QuestID) == QUEST_STATUS_INCOMPLETE)
		return DIALOG_STATUS_INCOMPLETE;

	if (GetQuestStatus(pClient, QuestID) == QUEST_STATUS_NONE)
		if (CanTakeQuest(pClient, QuestID) == true)
			return DIALOG_STATUS_AVAILABLE;
		else
			return DIALOG_STATUS_NONE;		// or UNAVAILABLE

	return DIALOG_STATUS_NONE;
}

void SendQuestComplete(CPlayer *pPlayer, unsigned long QuestID)
{
	CPacket pkg;
	pkg.Reset(SMSG_QUESTUPDATE_COMPLETE);
	pkg << (unsigned long)QuestID;
	pPlayer->pClient->Send(&pkg);
	return;
}
void SetQuestStatus(CClient *pClient, unsigned long QuestID, unsigned long newstatus)
{
	unsigned long i = 0;
	int exists = 0;
	for(i=0;i<=pClient->pPlayer->Data.QuestCounter;i++)
	{
		if (pClient->pPlayer->Data.Quests[i].QuestID == QuestID)
		{
			exists = i;
			break;
		}
	}

	if (exists == 0)
	{
		pClient->pPlayer->Data.QuestCounter++;
		exists = pClient->pPlayer->Data.QuestCounter;
		pClient->pPlayer->Data.Quests[exists].QuestID = QuestID;
	}

	pClient->pPlayer->Data.Quests[exists].State = (char)newstatus;
	return;
}

bool CheckForQuestCompletion(CClient *pClient, unsigned long QuestID)
{
	CQuestInfo *pQuest;
	if (!DataManager.RetrieveObject((CWoWObject**)&pQuest, OBJ_QUESTINFO, QuestID))
		return false;

	if (pQuest->Data.questmobid[0] == 0)
	{
		SetQuestStatus(pClient, QuestID, QUEST_STATUS_COMPLETE);
		// pClient->Echo("Congratulations, you completed the %s quest! Go speak to the questgiver to collect your reward.", pQuest->Data.title);
		return true;
	}

	if (pQuest->Data.questitemid[0] == 0)
	{
		SetQuestStatus(pClient, QuestID, QUEST_STATUS_COMPLETE);
		// pClient->Echo("Congratulations, you completed the %s quest! Go speak to the questgiver to collect your reward.", pQuest->Data.title);
		return true;
	}

	return false;
}
bool IsOnQuest(CClient *pClient, unsigned long QuestID)
{
	//	if (pClient->pPlayer->GetQuestStatus(QuestID) == QUEST_STATUS_INCOMPLETE)
	//{
	//		return true;
	//	}
	return false;
}
void AddItemLoot(CPlayer *pPlayer, unsigned long itemtemplateguid)
{

}
void AddCreatureKill(CPlayer *pPlayer, unsigned long creatureid)
{
	CCreature *pCreature;
	unsigned long oldid;
	if (DataManager.RetrieveObject((CWoWObject**)&pCreature, OBJ_CREATURE, creatureid))
	{
		oldid = (pCreature->Data.Template & 0xFFFFFF); // Template is GUID, this nulls out the type segment of the guid
		if(!oldid)
		{
			Debug.Logf("Creature %X has no oldid!",pCreature->guid);
			return;
		}
	}
	CQuestInfo *pQuest;

	// See if any of the quests the player is on have that creature in them
	unsigned long i;
	unsigned long j;

	for(i=0;i<20;i++)
	{
		if(!pPlayer->Data.QuestLogSlots[i].QuestID) continue; // save some time by skipping unused slots
		if (!DataManager.RetrieveObject((CWoWObject**)&pQuest, OBJ_QUESTINFO, pPlayer->Data.QuestLogSlots[i].QuestID))
		{
			Debug.Log("Player is on quest that's not in storage!");
			continue;
		}
		for(j=0;j<4;j++)
		{
			if (pQuest->Data.questmobid[j] == oldid)
			{
				// Match! Woot!
				pPlayer->Data.QuestLogSlots[i].QuestMobCount[j]++;		// Add +1
				// Send this to player
				SendQuestKillAdd(pPlayer, pQuest, j, pPlayer->Data.QuestLogSlots[i].QuestMobCount[j], creatureid);
				// Now check if they've got the required number of mobs
				if ( pPlayer->Data.QuestLogSlots[i].QuestMobCount[j] >= (short)pQuest->Data.questmobcount[j])
				{
					SendQuestComplete(pPlayer, pQuest->guid);
				}
				break; // impossible that a quest will have two same mob objectives
			}
		}
	}
	return;
}

void SendQuestItemAdd(CPlayer *pPlayer, unsigned long ItemID, unsigned long NewCount)
{
	CPacket pkg;
	pkg.Reset(SMSG_QUESTUPDATE_ADD_ITEM);
	pkg << (unsigned long)ItemID;
	pkg << (unsigned long)NewCount;
	pPlayer->pClient->Send(&pkg);
	return;
}

void SendQuestKillAdd(CPlayer *pPlayer, CQuestInfo *pQuest, unsigned long MobListID, unsigned long KillCount, unsigned long CreatureGUID)
{
	CPacket pkg;
	pkg.Reset(SMSG_QUESTUPDATE_ADD_KILL);
	// construct packet
	pkg << (unsigned long)pQuest->guid;
	pkg << (unsigned long)(pQuest->Data.questmobid[MobListID] | 0x08000000);
	pkg << (unsigned long)KillCount;
	pkg << (unsigned long)pQuest->Data.questmobcount[MobListID];
	pkg << CreatureGUID << CREATUREGUID_HIGH;
	// send packet
	pPlayer->pClient->Send(&pkg);

	// update questlog fields
	for(unsigned long i=0;i<20;i++)
	{
		if (pPlayer->Data.QuestLogSlots[i].QuestID = pQuest->guid)
		{
			/*
			uint16 log_slot   = Wrld->GetPlayer()->getQuestSlot( pQuest->m_questId );
			uint32 kills      = Wrld->GetPlayer()->GetUInt32Value( log_slot + 1 );
			kills             = kills + (1 << ( 6 * iLogMob ));
			Wrld->GetPlayer()->SetUInt32Value( log_slot + 1, kills );
			*/
			unsigned long kills = pPlayer->Data.QuestLogSlots[i].QuestMobKills[MobListID];
			kills = kills + (1 << ( 6 * MobListID ));
			pPlayer->Data.QuestLogSlots[i].QuestMobKills[MobListID] = kills;
			unsigned long field = (3 * (i + 1) - 2) + PLAYER_QUEST_LOG_1_1;
			pPlayer->AddUpdateVal(field, kills);
			pPlayer->UpdateObject();
			return;
		}
	}
}

void SendSmallQuestDetails(CClient *pClient, unsigned long cguid, unsigned long questid)
{
	CQuestInfo *pQuest;
	CCreature *pCreature;

	if (!DataManager.RetrieveObject((CWoWObject**)&pQuest,OBJ_QUESTINFO, questid))
	{
		questid = 455;				// insert bogus quest here
		pClient->Echo("couldn't find quest");
		DataManager.RetrieveObject((CWoWObject**)&pQuest,OBJ_QUESTINFO, questid);
		return;
	}

	if (!DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE, cguid))
	{
		pClient->Echo("couldn't find creature");
		return;
	}

	CPacket pkg;
	pkg.Reset(SMSG_QUESTGIVER_QUEST_DETAILS);

	pkg << cguid << (unsigned long)0;
	// pkg << pQuest->Data.questid;
	pkg << (unsigned long)questid;
	string temp;
	temp = pQuest->Data.title;
	pkg << temp;
	temp = pQuest->Data.objectives;
	pkg << temp;
	temp = pQuest->Data.details;
	pkg << temp;

	pkg << (unsigned long)1;		// 0 - can hit accept, 1 - cannot

	pkg << (unsigned long)pQuest->Data.choicerewards;
	for (unsigned long i=0; i < pQuest->Data.choicerewards; i++)
	{
		// todo: checking code - if (DataManager.RetrieveObject((CWoWObject**),OBJ_ITEM,
		pkg << (unsigned long)(DataManager.ItemTemplates[pQuest->Data.choiceitemid[i]]);
		pkg << (unsigned long)pQuest->Data.choiceitemcount[i];
		pkg << (unsigned long)0;
	}

	pkg << (unsigned long)pQuest->Data.itemrewards;
	for (unsigned long i=0; i < pQuest->Data.itemrewards; i++)
	{
		// todo: checking code - if (DataManager.RetrieveObject((CWoWObject**),OBJ_ITEM,
		pkg << (unsigned long)(DataManager.ItemTemplates[pQuest->Data.rewarditemid[i]]);
		pkg << (unsigned long)pQuest->Data.rewarditemcount[i];
		pkg << (unsigned long)0;
	}

	pkg << (unsigned long)pQuest->Data.rewardgold;
	pkg << (unsigned long)0;

	unsigned long Nr = 0;

	for (unsigned long i = 0; i < 3; i++)
		if (pQuest->Data.questmobid[i]) Nr++;

	pkg << (unsigned long)Nr;

	for (unsigned long i = 0; i < 3; i++)
		if (pQuest->Data.questmobid[i])
		{
			pkg << (unsigned long)(pQuest->Data.questmobid[i] | 0x08000000);
			pkg << (unsigned long)pQuest->Data.questmobcount[i];
		}
		pClient->Send(&pkg);
}
