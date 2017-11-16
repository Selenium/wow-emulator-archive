#include "LootTable.h"
#include "Creature.h"
#include "Client.h"
#include "QuestFunctions.h"
#include "Quest.h"

CLootTable::CLootTable(void):CWoWObject(OBJ_LOOTTABLE)
{
}

CLootTable::~CLootTable(void)
{
}

void CLootTable::Clear()
{
	CWoWObject::Clear();
	memset(&Data,0,sizeof(LootTableData));
}

void CLootTable::New()
{
	Clear();
	CWoWObject::New();
}

bool CLootTable::StoringData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	Storage.Allocate(sizeof(LootTableData));
	memcpy(Storage.Data,&Data,sizeof(LootTableData));
	return true;
}

bool CLootTable::LoadingData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	memcpy(&Data,Storage.Data,sizeof(LootTableData));
	return true;
}

void CLootTable::GenerateLoot(CCreature *pCreature, CClient *pClient)
{
	CLootTable* pLootTable;
	CCreatureTemplate *pCreatureTemplate=pCreature->pTemplate;
	pCreature->LootedItems.clear();
	if(!pCreatureTemplate)
	{
		if(!DataManager.RetrieveObject((CWoWObject**)&pCreatureTemplate,OBJ_CREATURETEMPLATE,pCreature->Data.Template))
			return;
	}
	if(!DataManager.RetrieveObject((CWoWObject**)&pLootTable,OBJ_LOOTTABLE,pCreatureTemplate->Data.LootTable))
		return;
	CItemTemplate *pItemTemplate;
	char count=0;
	for(int i=0;i<MAXLOOTITEMS;i++)
	{
		if(!pLootTable->Data.Items[i].ItemTemplate) break;
		if(pCreature->LootedItems.size()>=16) break;
		if(rand()%10000 < (pLootTable->Data.Items[i].Rate*100)) // small rates may not appear otherwise
		{
			if(!DataManager.RetrieveObject((CWoWObject**)&pItemTemplate,OBJ_ITEMTEMPLATE,DataManager.ItemTemplates(pLootTable->Data.Items[i].ItemTemplate))) continue;
			if(pItemTemplate->Data.Class==ITEMTYPE_QUEST)
			{
				unsigned long oldid=(pItemTemplate->guid)&0xFFFFFF;

				CQuestInfo *pQuest;

				// See if any of the quests the player is on have that item in them
				unsigned long i;
				unsigned long j;

				for(i=0;i<20;i++)
				{
					if(!pClient->pPlayer->Data.QuestLogSlots[i].QuestID) continue; // save some time by skipping unused slots
					if (!DataManager.RetrieveObject((CWoWObject**)&pQuest, OBJ_QUESTINFO, pClient->pPlayer->Data.QuestLogSlots[i].QuestID))
						continue;
					for(j=0;j<4;j++)
					{
						if (pQuest->Data.questitemid[j] == oldid)
						{
							pCreature->LootedItems[count++]=pItemTemplate; // add that item
						}
					}
				}
				continue;
			}
			pCreature->LootedItems[count++]=pItemTemplate;
		}
	}
}
