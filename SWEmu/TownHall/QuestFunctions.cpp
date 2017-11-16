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
	if (pCreature->pTemplate->guid == SPIRITHEALER_GUID)	// Spirit Healer
	{
		GameMechanics::SendSpiritHealerGossipMenu(pClient,pCreature);
		return;
	}
	if (strlen(pCreature->pTemplate->Data.QuestGiverText) > 2)
	{
		pkg << (unsigned long)pCreature->pTemplate->guid;
	} else {
		// npc text lookup here
		pkg << (unsigned long)pCreature->pTemplate->Data.TextID;//999999;
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

bool CanTakeQuest(CClient * pClient, guid_t QuestID)
{
	if (pClient->pPlayer->EnableAllQuests)
		return true;		// admin has enabled all quests
	// NOTICE: If you find that this function returns true all the time,
	// use !allquests ingame to disable. Thanks.

	CQuestInfo *pQuest;
	if (!DataManager.RetrieveObject((CWoWObject**)&pQuest, OBJ_QUESTINFO, QuestID))
		return false;

	// Check levels
	if (pClient->pPlayer->Data.Level < pQuest->Data.reqlevel)
		return false;
	if(pQuest->Data.questclass && !(pQuest->Data.questclass & (1<<pClient->pPlayer->Data.Class)))
		return false;
	if(pQuest->Data.questraces && !(pQuest->Data.questraces & (1<<pClient->pPlayer->Data.Race)))
		return false;
	// Check if Quest Status is taken Already
	if (GetQuestStatus(pClient, QuestID) != QUEST_STATUS_NONE) // used to be QUEST_STATUS_COMPLETED
		return false;
	// Check previous quests
	unsigned long i=0;
	for(i=0;i<4;i++)
	{
		if(!pQuest->Data.previousquest[i]) continue;
		if (!HasCompletedQuest(pClient, DataManager.QuestIDs(pQuest->Data.previousquest[i])))
			return false;
	}

	// todo: check factions, etc

	// Everything is fine, they can take the quest! :>
	return true;
}

bool HasCompletedQuest(CClient *pClient, guid_t QuestID)
{
	if (GetQuestStatus(pClient, QuestID) == QUEST_STATUS_COMPLETED)
		return true;
	return false;
}

unsigned long GetQuestStatus(CClient *pClient, guid_t QuestID)
{
	unsigned long i = 0;
	int exists = -1;
	QuestID=DataManager.QuestIDs(QuestID);
	for(i=0;i <= pClient->pPlayer->Data.QuestCounter;i++)
	{
		if (pClient->pPlayer->Data.Quests[i].QuestID == (QuestID))
		{
			exists = i;
			break;
		}
	}

	if (exists == -1)
	{
		return QUEST_STATUS_NONE;
	}
	return pClient->pPlayer->Data.Quests[i].State;
}

unsigned long GetDialogStatus(CCreature *pCreature, CClient *pClient, guid_t QuestID)
{
	for(std::list<unsigned long>::iterator i=DataManager.CreatureInvolvedRelation[pCreature->Data.Template].begin();i!=DataManager.CreatureInvolvedRelation[pCreature->Data.Template].end();i++)
	{
		// Check for involvers
		if (GetQuestStatus(pClient, (*i)) == QUEST_STATUS_COMPLETE)
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

void SendQuestComplete(CPlayer *pPlayer, guid_t QuestID)
{
	CPacket pkg;
	pkg.Reset(SMSG_QUESTUPDATE_COMPLETE);
	pkg << (unsigned long)QuestID;
	pPlayer->pClient->Send(&pkg);
	return;
}

void SetQuestStatus(CClient *pClient, guid_t QuestID, unsigned long newstatus)
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

bool CheckForQuestCompletion(CClient *pClient, CQuestInfo *pQuest)
{
	long QuestIndex = -1;
	for(long i=0;i<20;i++)
	{
		if(!pClient->pPlayer->Data.QuestLogSlots[i].QuestID) continue; // save some time by skipping unused slots
		if(pClient->pPlayer->Data.QuestLogSlots[i].QuestID==pQuest->guid)
		{
			QuestIndex=i;
			break;
		}
	}
	if(QuestIndex==-1) return false; // you're not even taking this quest; how do you complete it?
	_QuestLogSlot *PlayerQuest=&(pClient->pPlayer->Data.QuestLogSlots[QuestIndex]);
	for (int j=0;j<4;j++)
	{
		if (PlayerQuest->QuestMobCount[j] < (short)pQuest->Data.questmobcount[j])
			return false;
		if (PlayerQuest->QuestItemCount[j] < (short)pQuest->Data.questitemcount[j])
			return false;
		if (pQuest->Data.questarea[j] && !(PlayerQuest->QuestAreasExplored[j]))
			return false;
	}
	SetQuestStatus(pClient, pQuest->guid, QUEST_STATUS_COMPLETE);
	return true;
}

void AddItemLoot(CPlayer *pPlayer, guid_t itemtemplateguid, long stacked)
{
	unsigned long oldid=itemtemplateguid&0xFFFFFF;

	CQuestInfo *pQuest;

	// See if any of the quests the player is on have that item in them
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
			if (pQuest->Data.questitemid[j] == oldid)
			{
				// Match! Woot!
				pPlayer->Data.QuestLogSlots[i].QuestItemCount[j]+=(short)stacked;		// Add +1
				if(pPlayer->Data.QuestLogSlots[i].QuestItemCount[j] < 0)
					pPlayer->Data.QuestLogSlots[i].QuestItemCount[j]=0;
				else if(pPlayer->Data.QuestLogSlots[i].QuestItemCount[j] > (short)pQuest->Data.questitemcount[j])
					pPlayer->Data.QuestLogSlots[i].QuestItemCount[j]=(short)pQuest->Data.questitemcount[j];
				// Send this to player
				SendQuestItemAdd(pPlayer, itemtemplateguid, pPlayer->Data.QuestLogSlots[i].QuestItemCount[j]);
				// Now check if they've got the required number of items
				if (CheckForQuestCompletion(pPlayer->pClient,pQuest))
				{
					SendQuestComplete(pPlayer, pQuest->guid);
				}
				break; // impossible that a quest will have two same item objectives
			}
		}
	}
}

void AddCreatureKill(CPlayer *pPlayer, guid_t creatureid)
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
				if(pPlayer->Data.QuestLogSlots[i].QuestMobCount[j] > (short)pQuest->Data.questmobcount[j])
					pPlayer->Data.QuestLogSlots[i].QuestMobCount[j] = (short)pQuest->Data.questmobcount[j];
				// Send this to player
				SendQuestKillAdd(pPlayer, pQuest, j, pPlayer->Data.QuestLogSlots[i].QuestMobCount[j], creatureid);
				// Now check if they've got the required number of mobs
				if (CheckForQuestCompletion(pPlayer->pClient,pQuest))
				{
					SendQuestComplete(pPlayer, pQuest->guid);
				}
				break; // impossible that a quest will have two same mob objectives
			}
		}
	}
	return;
}

void AddExploreArea(CPlayer *pPlayer, unsigned long AreaID)
{
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
			if (pQuest->Data.questarea[j] == AreaID)
			{
				// Match! Woot!
				pPlayer->Data.QuestLogSlots[i].QuestAreasExplored[j]=1;
				// Now check if they've got the required number of areas
				if (CheckForQuestCompletion(pPlayer->pClient,pQuest))
				{
					SendQuestComplete(pPlayer, pQuest->guid);
					pPlayer->Data.QuestLogSlots[i].QuestMobKills|=0x01000000; // explored
					unsigned long field = (3 * i + 1) + PLAYER_QUEST_LOG_1_1;
					pPlayer->AddUpdateVal(field, pPlayer->Data.QuestLogSlots[i].QuestMobKills);
					pPlayer->UpdateObject();
				}
				break;
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
}

void SendQuestKillAdd(CPlayer *pPlayer, CQuestInfo *pQuest, unsigned long MobListID, unsigned long KillCount, unsigned long CreatureGUID)
{
	CPacket pkg;
	pkg.Reset(SMSG_QUESTUPDATE_ADD_KILL);
	// construct packet
	pkg << (unsigned long)pQuest->guid;
	pkg << (unsigned long)(DataManager.CreatureTemplates(pQuest->Data.questmobid[MobListID]));
	pkg << (unsigned long)KillCount;
	pkg << (unsigned long)pQuest->Data.questmobcount[MobListID];
	pkg << CreatureGUID << CREATUREGUID_HIGH;
	// send packet
	if(pPlayer->pClient) pPlayer->pClient->Send(&pkg);

	// update questlog fields
	for(unsigned long i=0;i<20;i++)
	{
		if (pPlayer->Data.QuestLogSlots[i].QuestID == pQuest->guid)
		{
			pPlayer->Data.QuestLogSlots[i].QuestMobKills+=(1 << ( 6 * MobListID ));
			unsigned long field = (3 * i + 1) + PLAYER_QUEST_LOG_1_1;
			if(pPlayer->pClient) 
			{
				pPlayer->AddUpdateVal(field, pPlayer->Data.QuestLogSlots[i].QuestMobKills);
				pPlayer->UpdateObject();
			}
			return;
		}
	}
}

void ExpireQuest(CClient *pClient, unsigned long logslot)
{
	CPacket pkg(SMSG_QUESTUPDATE_FAILEDTIMER);
	pkg << pClient->pPlayer->Data.QuestLogSlots[logslot].QuestID;
	pClient->Send(&pkg);

	pClient->pPlayer->timedQuestSlot=0;
	pClient->pPlayer->ClearQuestLogSlot(logslot);
	unsigned long logfield=logslot*3+PLAYER_QUEST_LOG_1_1;
	pClient->pPlayer->AddUpdateVal(logfield, 0);
	pClient->pPlayer->AddUpdateVal(logfield+1, 0);
	pClient->pPlayer->AddUpdateVal(logfield+2, 0);
	SetQuestStatus(pClient, pClient->pPlayer->Data.QuestLogSlots[logslot].QuestID, QUEST_STATUS_NONE); // should we?
}

void SendSmallQuestDetails(CClient *pClient, guid_t cguid, guid_t questid)
{
	CQuestInfo *pQuest;
	CCreature *pCreature;
	CItem *pItem;
	CGameObject *pGO;

	if (!DataManager.RetrieveObject((CWoWObject**)&pQuest,OBJ_QUESTINFO, questid))
	{
		pClient->Echo("couldn't find quest");
		return;
	}

	if (!DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE, cguid)
		&& !DataManager.RetrieveObject((CWoWObject**)&pItem,OBJ_ITEM, cguid)
		&& !DataManager.RetrieveObject((CWoWObject**)&pGO,OBJ_GAMEOBJECT, cguid))
	{
		pClient->Echo("couldn't find object");
		return;
	}

	CPacket pkg;
	pkg.Reset(SMSG_QUESTGIVER_QUEST_DETAILS);

	pkg << cguid << (pCreature?CREATUREGUID_HIGH:(pItem?ITEMGUID_HIGH:GAMEOBJECTGUID_HIGH));
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
	for (unsigned long i=0; i < 6; i++)
	{
		if(pQuest->Data.choiceitemid[i])
		{
			// todo: checking code - if (DataManager.RetrieveObject((CWoWObject**),OBJ_ITEM,
			unsigned long TemplateID=DataManager.ItemTemplates(pQuest->Data.choiceitemid[i]);
			pkg << (unsigned long)(TemplateID);
			pkg << (unsigned long)pQuest->Data.choiceitemcount[i];
			CItemTemplate *pTemplate=NULL;
			if(DataManager.RetrieveObject((CWoWObject**)&pTemplate,OBJ_ITEMTEMPLATE,TemplateID))
				pkg << (unsigned long)pTemplate->Data.DisplayID;
			else
				pkg << (unsigned long)0;
		}
		else pkg << 0 << 0 << 0;
	}

	pkg << (unsigned long)pQuest->Data.itemrewards;
	for (unsigned long i=0; i < 4; i++)
	{
		if(pQuest->Data.rewarditemid[i])
		{
			unsigned long TemplateID=DataManager.ItemTemplates(pQuest->Data.rewarditemid[i]);
			pkg << (unsigned long)(TemplateID);
			pkg << (unsigned long)pQuest->Data.rewarditemcount[i];
			CItemTemplate *pTemplate=NULL;
			if(DataManager.RetrieveObject((CWoWObject**)&pTemplate,OBJ_ITEMTEMPLATE,TemplateID))
				pkg << (unsigned long)pTemplate->Data.DisplayID;
			else
				pkg << (unsigned long)0;
		}
		else pkg << 0 << 0 << 0;
	}

	pkg << (unsigned long)pQuest->Data.rewardgold;

	unsigned long Nr = 0;

	for (unsigned long i = 0; i < 4; i++)
		if (pQuest->Data.questitemid[i]) Nr++;

	pkg << (unsigned long)Nr;

	for (unsigned long i = 0; i < 4; i++)
	{
		if (pQuest->Data.questitemid[i])
		{
			pkg << (unsigned long)DataManager.ItemTemplates(pQuest->Data.questitemid[i]);
			pkg << (unsigned long)pQuest->Data.questitemcount[i];
		}
		else pkg << (unsigned long)0 << (unsigned long)0;
	}

	Nr=0;

	for (unsigned long i = 0; i < 4; i++)
		if (pQuest->Data.questmobid[i]) Nr++;

	pkg << (unsigned long)Nr;

	for (unsigned long i = 0; i < 4; i++)
	{
		if (pQuest->Data.questmobid[i])
		{
			pkg << (unsigned long)(DataManager.CreatureTemplates(pQuest->Data.questmobid[i]));
			pkg << (unsigned long)pQuest->Data.questmobcount[i];
		}
		else pkg << (unsigned long)0 << (unsigned long)0;
	}
	pClient->Send(&pkg);
}
