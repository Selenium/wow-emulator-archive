#include "Item.h"
#include "UpdateBlock.h"
#include "Player.h"
CItem::CItem(void):CWoWObject(OBJ_ITEM), CUpdateObject(ITEM_MAX_BITS)
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
}

unsigned long CItem::AddCreateObjectData(char *buffer)
{
#define Add(datatype,data) *(datatype*)&buffer[c]=data;c+=sizeof(datatype);
#define Fill(size,value) memset(&buffer[c],value,size);c+=size;
	unsigned long c=0;
	// HEADER
	Add(unsigned long,guid);
	Add(unsigned long,ITEMGUID_HIGH);
	Add(unsigned char,ID_ITEM); // Container and Item should be seperate
							  // I have not tested Containers yet but we will get to that. - Codemonkey
	Add(unsigned long, 0);
	CPlayer *pPlayer = NULL;
	DataManager.RetrieveObject((CWoWObject**)&pPlayer, Data.Owner);
	Add(_Location, pPlayer->Data.Loc);
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
	AddUpdateVal(OBJECT_GUID, guid);
	AddUpdateVal(OBJECT_GUID_HIGH, ITEMGUID_HIGH);
	AddUpdateVal(OBJECT_HIER_TYPE, HIER_TYPE_ITEM);
	AddUpdateVal(OBJECT_ENTRY, Data.nItemTemplate);
	AddUpdateVal(OBJECT_SCALE, Data.Size);
	AddUpdateVal(ITEM_OWNER, Data.Owner);
	AddUpdateVal(ITEM_CONTAINED, Data.Container);
}

unsigned long CItem::GetItemInfoData(char *buffer, bool Create)
{
	
	
#define Add(datatype,data) *(datatype*)&buffer[c]=data;c+=sizeof(datatype);
#define Skip(n) c+=n;
#define Fill(size,value) memset(&buffer[c],value,size);c+=size;
	int c=0;
	// HEADER
	Add(unsigned long,guid);
	Add(unsigned long,0x40000000);
	if (Create)
	{
		Add(unsigned char,1); // Container and Item should be seperate
							  // I have not tested Containers yet but we will get to that. - Codemonkey
		//Skip(72);
		//Skip(0x24);
		Add(unsigned long, 0);
		CPlayer *pPlayer = NULL;
		DataManager.RetrieveObject((CWoWObject**)&pPlayer, Data.Owner);
		Add(_Location, pPlayer->Data.Loc);
		Add(unsigned long, 0);
		Add(float, 1.056579E-41f);
		Add(float, 1.258285E-33f);
		Add(float, -0.06248897f);
		Add(float, 8.82818E-44f);
		Add(unsigned long, 0);
		Add(unsigned long,1); // unknown
		Skip(0x0C);
	}
#undef Fill
#undef Skip
#undef Add

	// ITEM
	CUpdateBlock block(&buffer[c], ITEM_MAX_BITS);
	block.Add(OBJECT_GUID, guid);
	block.Add(OBJECT_GUID_HIGH, ITEMGUID_HIGH);
	block.Add(OBJECT_HIER_TYPE, HIER_TYPE_ITEM);
	block.Add(OBJECT_ENTRY, Data.nItemTemplate);
	block.Add(OBJECT_SCALE, Data.Size);
	block.Add(ITEM_OWNER, Data.Owner);
	block.Add(ITEM_CONTAINED, Data.Container);
	// since count isn't used yet it's no use adding it. - Codemonkey
	// whats the point in not adding it? its zlib compressed anyway - Lax
	return block.GetSize() + c;
/*
#define Add(datatype,data) *(datatype*)&buffer[c]=data;c+=sizeof(datatype);
#define Skip(n) c+=n;
#define Fill(size,value) memset(&buffer[c],value,size);c+=size;
	
	unsigned char buf[]={
// header
 0x09,0x00,0x00,0x00,0x02,
//  id              |  id continued     |type|
 0x75,0xAE,0x23,0x00,0x00,0x00,0x00,0x40,0x01
,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00
// would be loc     |                   |                   |
,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00
// loc              |                   |                   | facing
,0x39,0x03,0xD0,0x44,0xB7,0xC4,0xD1,0x44,0x42,0x90,0xF1,0x42,0x00,0x00,0x00,0x00
//                  |                   |                   |
,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00
//  id              | id continued      |                   |
,0x75,0xAE,0x23,0x00,0x00,0x00,0x00,0x40
// dunno            | dunno             |                   |  1
,0x1C,0x58,0x02,0x81,0xC4,0xF5,0xBF,0xBD,0x00,0x00,0x00,0x00,0x01,0x00,0x00,0x00
//                  |  dunno            |dunno              |dunno
,0x00,0x00,0x00,0x00,0x74,0xF4,0xBF,0xBD,0xA4,0xA3,0x38,0x08,0x02,0x7F,0x11,0x40
//                  |                   |                   |
,0x92,0x04,0x00,0x00,0x00
//  id              | id continued      | dunno             | template
,0x75,0xAE,0x23,0x00,0x00,0x00,0x00,0x40,0x03,0x00,0x00,0x00,0x35,0x00,0x00,0x00
//                  |                   |                   |
,0x00,0x00,0x80,0x3F,0xEE,0xEE,0xEE,0xEE,0xCB,0x79,0x01,0x00,0xCB,0x79,0x01,0x00
// count
,0x01,0x00,0x00,0x00

,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE
,0xEE,0xEE,0xEE,0xEE
	};
	/**/
/*	int c=0;
	Add(unsigned long,guid);
	Add(unsigned long,0x40000000);
	if (Create)
	{
		Add(unsigned char,0x01+(TemplateData.Type==1));
		Skip(8);

		// TODO: presumably items on the ground will have location right here
		Skip(0x10);// loc

		// owner's location. is this important?
		Skip(0x10);// loc

		Skip(0x0c);
		Add(unsigned long,guid);
		Add(unsigned long,0x40000000);
	//,0x1C,0x58,0x02,0x81,0xC4,0xF5,0xBF,0xBD,0x00,0x00,0x00,0x00,0x01,0x00,0x00,0x00
		Add(unsigned long,0x8102581C);
		Add(unsigned long,0xBDBFF5C4);
		Skip(0x04);
		Add(unsigned long,0x01);
		Skip(0x04);
		Add(unsigned long,0xBDBFF474);
		Add(unsigned long,0x0838A3A4);
		Add(unsigned long,0x40117F02);
	}


,0x00,0x00,0x00,0x00,0x74,0xF4,0xBF,0xBD,0xA4,0xA3,0x38,0x08,0x02,0x7F,0x11,0x40
//                  |                   |                   |
,0x92,0x04,0x00,0x00,0x00
//  id              | id continued      | dunno             | template
,0x75,0xAE,0x23,0x00,0x00,0x00,0x00,0x40,0x03,0x00,0x00,0x00,0x35,0x00,0x00,0x00
//                  |                   |                   |
,0x00,0x00,0x80,0x3F,0xEE,0xEE,0xEE,0xEE,0xCB,0x79,0x01,0x00,0xCB,0x79,0x01,0x00
// count
,0x01,0x00,0x00,0x00

,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE
,0xEE,0xEE,0xEE,0xEE

	Add(unsigned long,0x0492);
	Skip(0x01);

	Add(unsigned long,guid);
	Add(unsigned long,0x40000000);
	Add(unsigned long,0x03);
	Add(unsigned long,Data.nItemTemplate);
	Add(unsigned long,Data.Size);
	Add(unsigned long,0xEEEEEEEE);
	Add(unsigned long,Data.Owner);
	Add(unsigned long,Data.Container);
	Add(unsigned long,Data.Count);
	Fill(0x14,0xEE);


	return c;
#undef Add
#undef Skip
#undef Fill*/
}

void CItem::New(unsigned long nTemplate, unsigned long Owner)
{
	Clear();
	CWoWObject::New();
	Data.nItemTemplate=nTemplate;
	Data.Size=0x3F800000;
	Data.Owner=Owner;
	Data.Container=Owner;
	EventsEligible=true;
	CItemTemplate *pTemplate;
	if (DataManager.RetrieveObject((CWoWObject**)&pTemplate,OBJ_ITEMTEMPLATE,nTemplate))
	{
		TemplateData=pTemplate->Data;
	}
}


