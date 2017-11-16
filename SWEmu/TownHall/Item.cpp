#include "Item.h"
#include "UpdateBlock.h"
#include "Player.h"
#include "Packets.h"

CItem::CItem(void):CWoWObject(OBJ_ITEM), CUpdateObject(CONTAINER_END)
{
}

CItem::~CItem(void)
{
	CWoWObject::Delete();
}

bool CItem::StoringData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	Storage.Allocate(sizeof(ItemData));
	memcpy(Storage.Data,&Data,sizeof(ItemData));
	return true;
}

bool CItem::LoadingData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	memcpy(&Data,Storage.Data,sizeof(ItemData));
	CItemTemplate *pTemplate=NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pTemplate,OBJ_ITEMTEMPLATE,Data.nItemTemplate))
	{
		Debug.Logf("WARNING: CItem::LoadingData(ObjectStorage&): Could not find item template 0x%08X!",Data.nItemTemplate);
	}
	else
		pTemplateData=&(pTemplate->Data);
	return true;
}

void CItem::Clear()
{
	CWoWObject::Clear();
	memset(&Data,0,sizeof(ItemData));
	pTemplateData=NULL;
	Data.Count=1;
}

unsigned long CItem::GetItemInfoData(unsigned char *buffer, bool Create)
{
#define Add(datatype,data) *(datatype*)&buffer[c]=data;c+=sizeof(datatype);
#define Skip(n) c+=n;
#define Fill(size,value) memset(&buffer[c],value,size);c+=size;
	int c=0;

	// HEADER
	if (pTemplateData && pTemplateData->ContainerSlots > 0)
	{
		Skip(Packets::PackGuidBuffer((char *)buffer,guid,CONTAINERGUID_HIGH));
	} else {
		Skip(Packets::PackGuidBuffer((char *)buffer,guid,ITEMGUID_HIGH));
	}
	unsigned long fieldcount = ITEM_END;
	if (pTemplateData && pTemplateData->ContainerSlots > 0)
	{
		Add(unsigned char, ID_CONTAINER);
		fieldcount = CONTAINER_END;
	} else {
		Add(unsigned char, ID_ITEM); // Container and Item should be seperate
	}
	Add(unsigned char, (unsigned char)(TBC?0x18:0x10));	// flags
#if TBC
		Add(guid_t, guid);
		Add(guidhigh_t, ITEMGUID_HIGH);
#else
		Add(unsigned long, (unsigned long)0x6297848C);
#endif

#undef Fill
#undef Skip
#undef Add

	// ITEM
	CUpdateBlock block(&buffer[c], fieldcount);
	if (pTemplateData && pTemplateData->ContainerSlots > 0)
	{
		block.Add(OBJECT_FIELD_GUID, guid, CONTAINERGUID_HIGH);
		block.Add(OBJECT_FIELD_TYPE, HIER_TYPE_CONTAINER);
	} else {
		block.Add(OBJECT_FIELD_GUID, guid, ITEMGUID_HIGH);
		block.Add(OBJECT_FIELD_TYPE, HIER_TYPE_ITEM);
	}
	block.Add(OBJECT_FIELD_ENTRY, Data.nItemTemplate);
	block.Add(OBJECT_FIELD_SCALE_X, 1.0f);
	block.Add(OBJECT_FIELD_PADDING, 0xeeeeeeee);// added padding ?
	block.Add(ITEM_FIELD_OWNER, Data.Owner);
	block.Add(ITEM_FIELD_OWNER + 1, 0);
	block.Add(ITEM_FIELD_CONTAINED, Data.Container);
	block.Add(ITEM_FIELD_CONTAINED + 1, 0);
	block.Add(ITEM_FIELD_STACK_COUNT, Data.Count);
	block.Add(ITEM_FIELD_FLAGS,pTemplateData?pTemplateData->Flags:0);
	block.Add(ITEM_FIELD_DURABILITY, Data.Durability);
	block.Add(ITEM_FIELD_MAXDURABILITY, Data.MaxDurability);

	if(pTemplateData && pTemplateData->ContainerSlots > 0)
	{
		// find that bag nigga!
//		if(DataManager.RetrieveObject((CWoWObject**)&bag,OBJ_CONTAINER,Data.BagGuid))
//		if(Data.Container == Data.Owner)  //not in bags - fast check to filtr some Retrieves
		{
			block.Add(CONTAINER_FIELD_NUM_SLOTS,pTemplateData->ContainerSlots);
			CPlayer *pPlayer;
			DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER, Data.Owner);
			const unsigned char bag = pPlayer->FindBag(this);
			if (bag != 0xFF)
			{
//				pPlayer->DataObject.SetItem(bag + SLOT_BAG1, this);
				unsigned short BagItemSlot = CPlayer::CPlayerDataObject::GetBagItemSlot(bag + SLOT_BAG1, 0);
				for(int slot=0;slot<20;slot++)//biggest bag have 20 slots
				{
					CItem *const pItem = pPlayer ? pPlayer->Items[BagItemSlot + slot] : NULL;
					const unsigned long ItemGuid = pItem ? pItem->guid : 0;
					block.Add(CONTAINER_FIELD_SLOT_1 + (slot * 2), ItemGuid, ITEMGUID_HIGH);
					if (pItem) {
						pPlayer->pClient->AddKnownItem(*pItem);
					}
				}
			}
		}
	}
	return block.GetSize() + c;
}

void CItem::New(guid_t nTemplate, guid_t Owner)
{
	Clear();
	CWoWObject::New();
	Data.nItemTemplate=nTemplate;
	Data.Size=1.0f;
	Data.Owner=Owner;
	Data.Container=Owner;
	EventsEligible=true;
	CItemTemplate *pTemplate;
	if (DataManager.RetrieveObject((CWoWObject**)&pTemplate,OBJ_ITEMTEMPLATE,nTemplate))
	{
		pTemplateData=&(pTemplate->Data);
		Data.Durability=pTemplate->Data.MaxDurability;
		Data.MaxDurability=pTemplate->Data.MaxDurability;
//		Data.BagGuid = 0;
	}
	else
	{
		Debug.Logf("WARNING: CItem::New(guid_t, guid_t): Could not find item template 0x%08X!",nTemplate);
		pTemplateData=NULL;
	}
}

void CItem::New(CItemTemplate *pTemplate, guid_t Owner)
{
	Clear();
	CWoWObject::New();
	if(!pTemplate) return;
	Data.nItemTemplate=pTemplate->guid;
	Data.Size=1.0f;
	Data.Owner=Owner;
	Data.Container=Owner;
	EventsEligible=true;
	Data.Durability=pTemplate->Data.MaxDurability;
	Data.MaxDurability=pTemplate->Data.MaxDurability;
	pTemplateData=&(pTemplate->Data);
//	Data.BagGuid = 0;
}

bool CItem::Save(FILE *fout)
{
	return DataManager.StoreObject(*this);
}

bool CItem::Load(FILE *fin, bool createflag)
{
	return false;
}

