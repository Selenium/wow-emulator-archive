#ifndef ITEM_H
#define ITEM_H

#include "stdafx.h"
#include "WoWObject.h"
#include "ItemTemplate.h"
#include "UpdateObject.h"

struct ItemData
{
	unsigned long nItemTemplate;

	unsigned long Count; // stack
	float Size;
	unsigned long Owner;
	unsigned long Container;
	unsigned long Durability;
	unsigned long MaxDurability;

	unsigned long Creator;

	_Location Loc;
	unsigned long BagGuid;
};

class CItem : public CWoWObject, public CUpdateObject
{
	unsigned long AddCreateObjectData(char *buffer);
	void PreCreateObject();
	//void PostCreateObject();
public:
	CItem(void);
	~CItem(void);

	inline void CreateObject(bool reset = true) {CUpdateObject::CreateObject(guid, reset);};
	inline void UpdateObject(bool reset = true) {CUpdateObject::UpdateObject(guid, ITEMGUID_HIGH, reset);};

	ItemTemplateData *pTemplateData;
	ItemData Data;
	void Clear();
	void New(unsigned long nTemplate, unsigned long Owner);
	void New(CItemTemplate *pTemplate, unsigned long Owner);
	void CreateBag();

	unsigned long GetItemInfoData(unsigned char *buffer, bool Create=true);
	inline void SetItemDurability(unsigned long newvalue)
	{
		// check if too big
		if (newvalue > Data.MaxDurability)
			Data.Durability = Data.MaxDurability;
		else
			Data.Durability = newvalue;
		AddUpdateVal(ITEM_FIELD_DURABILITY, Data.Durability);
	}

	inline void ReduceItemDurabilityByPercent(float newvalue)
	{
		// check if too big
		unsigned long reduceamount;
		reduceamount = long(Data.MaxDurability * newvalue);

		if ((Data.Durability - reduceamount) < 0)
			Data.Durability = 0;
		else
			Data.Durability = Data.Durability - reduceamount;

		AddUpdateVal(ITEM_FIELD_DURABILITY, Data.Durability);
	}

	inline void ReduceItemDurability(unsigned long newvalue)
	{
		// check if too big
		Data.Durability -= newvalue;
		if (Data.Durability < 0)
			Data.Durability = 0;

		AddUpdateVal(ITEM_FIELD_DURABILITY, Data.Durability);
	}

	inline void RepairItemDurability()
	{
		Data.Durability = Data.MaxDurability;
		AddUpdateVal(ITEM_FIELD_DURABILITY, Data.Durability);
	}

	bool Save(FILE *fout);
	bool Load(FILE *fin, bool createflag = true);

	inline void SetItemCount(const unsigned long newvalue)
	{
		Data.Count = newvalue;
		AddUpdateVal(ITEM_FIELD_STACK_COUNT, Data.Count);
	}
};

#endif // ITEM_H
