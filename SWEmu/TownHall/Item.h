#ifndef ITEM_H
#define ITEM_H

#include "stdafx.h"
#include "WoWObject.h"
#include "ItemTemplate.h"
#include "UpdateObject.h"
#include "UpdateFields.h"

struct ItemData
{
	guid_t nItemTemplate;
	_Location Loc;

	unsigned long Count; // stack
	float Size;
	guid_t Owner;
	guid_t Container;
	unsigned long Durability;
	unsigned long MaxDurability;

	guid_t Creator;

//	unsigned long BagGuid;

};


extern int InvTypeToInvSlot[WORN_NUM_TYPES];

class CItem : public CWoWObject, public CUpdateObject
{
public:
	CItem(void);
	~CItem(void);

	inline void UpdateObject(bool reset = true) {CUpdateObject::UpdateObject(guid, ITEMGUID_HIGH, reset);};

	ItemTemplateData *pTemplateData;
	ItemData Data;
	bool StoringData(ObjectStorage &Storage);
	bool LoadingData(ObjectStorage &Storage);

	void Clear();
	void New(guid_t nTemplate, guid_t Owner);
	void New(CItemTemplate *pTemplate, guid_t Owner);
//	void CreateBag();

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
			Data.Durability -= reduceamount;

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
