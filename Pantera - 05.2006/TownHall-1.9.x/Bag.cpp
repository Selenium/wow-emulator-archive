#include "Item.h"
#include "UpdateBlock.h"
#include "Player.h"
#include "Bag.h"

CBag::CBag(void):CWoWObject(OBJ_CONTAINER), CUpdateObject(16)
{
}

CBag::~CBag(void)
{
	CWoWObject::Delete();
}

void CBag::Clear()
{
	CWoWObject::Clear();
	memset(&Data,0,sizeof(ItemData));
	pTemplateData=NULL;
	for(int i=0;i<20;i++)
		Data.Contents[i] = 0;
}

void CBag::New(ItemTemplateData *pTemplate, unsigned long Owner, unsigned long ItemGuid)
{
	Clear();
	CWoWObject::New();
	if(!pTemplate) return;
	Data.Owner = Owner;
	Data.ItemGuid = ItemGuid;
	EventsEligible=true;
	pTemplateData=pTemplate;
	Data.MaxItems = pTemplate->ContainerSlots;
}

bool CBag::Save(FILE *fout)
{
	fwrite(&(CWoWObject::guid), sizeof(unsigned long), 1, fout);
	long size = sizeof(BagData);
	fwrite(&Data, size, 1, fout);
	return true;
}

bool CBag::Load(FILE *fin, bool createflag)
{
	long size = sizeof(BagData);
	unsigned long newguid;
	char *buffer = (char*)malloc(size);
	if(buffer == NULL)
	{
		return false;
	}
	if (fread(&newguid, sizeof(unsigned long), 1, fin) != 1) {
		return false;
	}
	if (fread(buffer, size, 1, fin) != 1) {
		return false;
	}
	BagData *inData = (BagData *)buffer;
	memcpy(&Data,inData,size);

	EventsEligible=true;
	// Retreive parent item
	CItem *pItem;
	if(DataManager.RetrieveObject((CWoWObject**)&pItem, OBJ_ITEM, inData->ItemGuid))
	{
		// Parent item exists
		pTemplateData=pItem->pTemplateData;
	}else pTemplateData=NULL;
	// CItemTemplate *pTemplate;
	// if (DataManager.RetrieveObject((CWoWObject**)&pTemplate,OBJ_ITEMTEMPLATE,inData->nItemTemplate))
	// {
	//pTemplateData=&(pTemplate->Data);
	//}

	CWoWObject::guid=newguid;
	DataManager.SetNextIDIfGreater(newguid,OBJ_CONTAINER);
	if (createflag)
		DataManager.NewObject(*this);

	free(buffer);
	return true;
}

void CBag::SendBagContents()
{
	// Find owner
	CPlayer *pPlayer;
	CItem *pItem;
	if (!DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,Data.Owner))
		return;
	if (!DataManager.RetrieveObject((CWoWObject**)&pItem,OBJ_ITEM,Data.ItemGuid))
		return;
	pPlayer->pClient->UpdateKnownItem(*pItem);
}
