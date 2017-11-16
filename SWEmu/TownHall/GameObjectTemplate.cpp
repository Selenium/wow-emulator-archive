#include "GameObjectTemplate.h"
#include "ItemTemplate.h"
#include "Quest.h"
#include "Client.h"

CGameObjectTemplate::CGameObjectTemplate(void):CWoWObject(OBJ_GAMEOBJECTTEMPLATE)
{
	Clear();
}

CGameObjectTemplate::~CGameObjectTemplate(void)
{
	LootTable.clear();
}

void CGameObjectTemplate::Clear()
{
	LootTable.clear();
	CWoWObject::Clear();
	memset(&Data,0,sizeof(GameObjectTemplateData));
	Generated=false;
}

void CGameObjectTemplate::New(const char *Name)
{
	Clear();
	CWoWObject::New();
	// prevent buffer overflow
	strncpy(Data.Name,Name,63);
	Data.Name[63]=0;

	Generated=true;
}

bool CGameObjectTemplate::StoringData(ObjectStorage &Storage)
{
	if (!guid || Generated)
		return false;
	Storage.Allocate(sizeof(GameObjectTemplateData));
	memcpy(Storage.Data,&Data,sizeof(GameObjectTemplateData));
	return true;
}

bool CGameObjectTemplate::LoadingData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	memcpy(&Data,Storage.Data,sizeof(GameObjectTemplateData));
	LootTable.clear();
	Generated=false;
	return true;
}

void CGameObjectTemplate::GenerateLoot(CGameObject *pGameObject, CClient *pClient)
{
	if(LootTable.empty()) return;
	pGameObject->LootedItems.clear();
	CItemTemplate *pItemTemplate;
	char count=0;
	for(std::vector<LootItem>::iterator i=LootTable.begin();i!=LootTable.end();i++)
	{
		if(pGameObject->LootedItems.size()>=16) break;
		if(rand()%100 < (*i).Rate)
		{
			if(!DataManager.RetrieveObject((CWoWObject**)&pItemTemplate,OBJ_ITEMTEMPLATE,DataManager.ItemTemplates((*i).ItemTemplate))) continue;
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
							pGameObject->LootedItems[count++]=pItemTemplate; // add that item
						}
					}
				}
				continue;
			}
			pGameObject->LootedItems[count++]=pItemTemplate;
		}
	}
}
