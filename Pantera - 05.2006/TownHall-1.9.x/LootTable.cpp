#include "LootTable.h"
#include "Creature.h"
#include "QuestFunctions.h"

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
	// dont store until we're actually ready.
	return false;
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

void CLootTable::GenerateLoot(CCreature *pCreature)
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
		if(rand()%100 < pLootTable->Data.Items[i].Rate)
		{
			if(!DataManager.RetrieveObject((CWoWObject**)&pItemTemplate,OBJ_ITEMTEMPLATE,DataManager.ItemTemplates[pLootTable->Data.Items[i].ItemTemplate])) continue;
			if(pItemTemplate->Data.Class==ITEMTYPE_QUEST) continue;
			pCreature->LootedItems[count++]=pItemTemplate;
		}
	}
}
