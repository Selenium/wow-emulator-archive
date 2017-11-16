#include "Item.h"
#include "UpdateBlock.h"
#include "Player.h"
#include "Bag.h"
#include "Packets.h"

CItem::CItem(void):CWoWObject(OBJ_ITEM), CUpdateObject(16)
{
}

CItem::~CItem(void)
{
	CWoWObject::Delete();
}

void CItem::Clear()
{
	CWoWObject::Clear();
	memset(&Data,0,sizeof(ItemData));
	pTemplateData=NULL;
	Data.Count=1;
}

unsigned long CItem::AddCreateObjectData(char *buffer)
{
#define Add(datatype,data) *(datatype*)&buffer[c]=data;c+=sizeof(datatype);
#define Fill(size,value) memset(&buffer[c],value,size);c+=size;
	unsigned long c=0;
	// HEADER
	Add(unsigned long, guid);
	Add(unsigned long, ITEMGUID_HIGH);
	if (Data.Container)
	{
		Add(unsigned char, ID_CONTAINER);
	} else {
		Add(unsigned char, ID_ITEM); // Container and Item should be seperate
	}
	// I have not tested Containers yet but we will get to that. - Codemonkey
	Add(unsigned long, 0);
	CPlayer *pPlayer = NULL;
	DataManager.RetrieveObject((CWoWObject**)&pPlayer, Data.Owner);
	Add(_Location, pPlayer->Data.Loc);
	Add(float, pPlayer->Data.Facing);
	Add(unsigned long, 0);
	Add(float, 1.056579E-41f);
	Add(float, 1.258285E-33f);
	Add(float, -0.06248897f);
	Add(float, 8.82818E-44f);
	Add(unsigned long, 0);
	Add(unsigned long,1); // unknown
	Add(unsigned long, 0);
	Add(unsigned long, 0);
	Add(unsigned long, 0);
#undef Fill
#undef Add
	return c;
}

void CItem::PreCreateObject()
{
	AddUpdateVal(OBJECT_FIELD_GUID, guid, ITEMGUID_HIGH);
	AddUpdateVal(OBJECT_FIELD_TYPE, HIER_TYPE_ITEM);
	AddUpdateVal(OBJECT_FIELD_ENTRY, Data.nItemTemplate);
	AddUpdateVal(OBJECT_FIELD_SCALE_X, Data.Size);
	AddUpdateVal(ITEM_FIELD_OWNER, Data.Owner, PLAYERGUID_HIGH);
	AddUpdateVal(ITEM_FIELD_CONTAINED, Data.Container, CONTAINERGUID_HIGH);
	AddUpdateVal(ITEM_FIELD_STACK_COUNT, Data.Count);
	AddUpdateVal(ITEM_FIELD_DURABILITY, Data.Durability);
	AddUpdateVal(ITEM_FIELD_MAXDURABILITY, Data.MaxDurability);
}

unsigned long CItem::GetItemInfoData(unsigned char *buffer, bool Create)
{
#define Add(datatype,data) *(datatype*)&buffer[c]=data;c+=sizeof(datatype);
#define Skip(n) c+=n;
#define Fill(size,value) memset(&buffer[c],value,size);c+=size;
	int c=0;

	// HEADER
	if (pTemplateData->ContainerSlots > 0)
	{
		Skip(Packets::PackGuidBuffer((char *)buffer,guid,CONTAINERGUID_HIGH));
	} else {
		Skip(Packets::PackGuidBuffer((char *)buffer,guid,ITEMGUID_HIGH));
	}
	/*
	Add(unsigned char, 0xFF);
	Add(unsigned long, guid); // 2
	if (pTemplateData->ContainerSlots > 0)
	{
	Add(unsigned long, CONTAINERGUID_HIGH); // 2
	} else {
	Add(unsigned long, ITEMGUID_HIGH); // 2
	}
	*/
	unsigned long fieldcount = NUM_ITEM_FIELDS;
	if (pTemplateData->ContainerSlots > 0)
	{
		Add(unsigned char, ID_CONTAINER);
		fieldcount = NUM_CONTAINER_FIELDS;
	} else {
		Add(unsigned char, ID_ITEM); // Container and Item should be seperate
	}
	Add(unsigned char, (unsigned char)0x10);	// flags
	Add(unsigned long, (unsigned long)0x6297848C);

	/*
	if (Create)
	{
	Add(unsigned char, 1);	// OBJECT TYPE id = 1
	// Container and Item should be seperate
	// I have not tested Containers yet but we will get to that. - Codemonkey
	Add(unsigned long, 0);  // movement flag
	Add(unsigned long, 0);  // extended movement flag

	// Add location and facing; 16 bytes
	CPlayer *pPlayer = NULL;
	DataManager.RetrieveObject((CWoWObject**)&pPlayer, Data.Owner);
	if (pPlayer != NULL) {
	Add(_Location, pPlayer->Data.Loc);  // 12
	}
	else {
	return 0;
	}

	Add(float, pPlayer->Data.Facing);   // 4
	Add(unsigned long, 0);

	Add(float,DEFAULT_PLAYER_WALK_SPEED);
	Add(float,DEFAULT_PLAYER_RUN_SPEED);
	Add(float,DEFAULT_PLAYER_RUN_SPEED/2);
	Add(float,DEFAULT_PLAYER_SWIM_SPEED);
	Add(float,DEFAULT_PLAYER_SWIM_SPEED);
	Add(float,DEFAULT_PLAYER_TURN_RATE);

	Add(unsigned long, 0);  // flags
	Add(unsigned long, 0);  // attack cycle
	Add(unsigned long, 0);	// timer id
	Add(unsigned long, 0);	// victims GUID (low)
	Add(unsigned long, 0);	// victims GUID (high)
	}*/
#undef Fill
#undef Skip
#undef Add

	// ITEM
	CUpdateBlock block(&buffer[c], fieldcount);
	if (pTemplateData->ContainerSlots > 0)
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
	block.Add(ITEM_FIELD_FLAGS,pTemplateData->Flags);
	block.Add(ITEM_FIELD_DURABILITY, Data.Durability);
	block.Add(ITEM_FIELD_MAXDURABILITY, Data.MaxDurability);

	if(pTemplateData->ContainerSlots > 0)
	{
		// find that bag nigga!
		CBag *bag;
		if(DataManager.RetrieveObject((CWoWObject**)&bag,OBJ_CONTAINER,Data.BagGuid))
		{
			block.Add(CONTAINER_FIELD_NUM_SLOTS,pTemplateData->ContainerSlots);
			int slot=0;
			for(int i=0;i<39;i+=2)
			{
				// block.Add(CONTAINER_FIELD_SLOT_1 + i, bag->Data.Contents[slot]);
				// block.Add(CONTAINER_FIELD_SLOT_1 + (i - 1), ITEMGUID_HIGH);
				block.Add(CONTAINER_FIELD_SLOT_1 + i,bag->Data.Contents[slot],ITEMGUID_HIGH);
				slot++;
				// block.Add(CONTAINER_FIELD_SLOT_1 + (i * 2), bag->Data.Contents[i]);
				// block.Add(CONTAINER_FIELD_SLOT_1 + (i * 2), 0);
			}
		}
	}


	return block.GetSize() + c;
}

void CItem::New(unsigned long nTemplate, unsigned long Owner)
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
		Data.BagGuid = 0;
	}
}

void CItem::New(CItemTemplate *pTemplate, unsigned long Owner)
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
	Data.BagGuid = 0;
}

void CItem::CreateBag()
{
	if(pTemplateData->ContainerSlots > 0)
	{
		CBag *bag;
		bag = new CBag;
		bag->New(pTemplateData,Data.Owner,guid);
		DataManager.NewObject(*bag);
		Data.BagGuid = bag->guid;
		CPlayer *pPlayer;
		if(DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,Data.Owner))
		{
			// Add bag to list!
			for(int i=0;i<20;i++)
			{
				if(!pPlayer->Data.Bags[i])
				{
					// Bag slot wooooot
					pPlayer->Data.Bags[i] = bag->guid;
					break;
				}
			}
		}
	}
}
bool CItem::Save(FILE *fout)
{
	fwrite(&(CWoWObject::guid), sizeof(unsigned long), 1, fout);
	long size = sizeof(ItemData);
	fwrite(&Data, size, 1, fout);
	return true;
}

bool CItem::Load(FILE *fin, bool createflag)
{
	long size = sizeof(ItemData);
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
	ItemData *inData = (ItemData *)buffer;
	memcpy(&Data,inData,size);

	EventsEligible=true;
	CItemTemplate *pTemplate;
	if (DataManager.RetrieveObject((CWoWObject**)&pTemplate,OBJ_ITEMTEMPLATE,inData->nItemTemplate))
	{
		pTemplateData=&(pTemplate->Data);
	}
	else pTemplateData=NULL;
	CWoWObject::guid=newguid;
	DataManager.SetNextIDIfGreater(newguid,OBJ_ITEM);
	if (createflag)
		DataManager.NewObject(*this);

	free(buffer);
	return true;
}

