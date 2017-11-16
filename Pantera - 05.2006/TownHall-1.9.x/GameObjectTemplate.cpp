#include "GameObjectTemplate.h"
#include "ItemTemplate.h"

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

void CGameObjectTemplate::GenerateLoot(CGameObject *pGameObject)
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
			if(!DataManager.RetrieveObject((CWoWObject**)&pItemTemplate,OBJ_ITEMTEMPLATE,DataManager.ItemTemplates[(*i).ItemTemplate])) continue;
			if(pItemTemplate->Data.Class==ITEMTYPE_QUEST) continue;
			pGameObject->LootedItems[count++]=pItemTemplate;
		}
	}
}
