#ifndef BAG_H
#define BAG_H

#include "stdafx.h"
#include "WoWObject.h"
#include "ItemTemplate.h"
#include "UpdateObject.h"
#include "Item.h"

struct BagData
{
	unsigned long nItemTemplate;

	unsigned long Owner;
	unsigned long Container;
	unsigned long MaxItems;
	unsigned long ItemGuid;
	unsigned long Contents[20];		// Bur: 20 items seems to be biggest bag, if any one wants to change this feel free.
};

class CBag : public CWoWObject, public CUpdateObject
{
public:
	CBag(void);
	~CBag(void);

	ItemTemplateData *pTemplateData;
	BagData Data;
	void Clear();

	void New(ItemTemplateData *pTemplate, unsigned long Owner, unsigned long ItemGuid);
	void SendBagContents();
	unsigned long FindFreeSlot();
	void SetSlotContents(unsigned long ItemGuid, unsigned long SlotNumber);
	unsigned long GetSlotContents(unsigned long SlotNumber);

	bool Save(FILE *fout);
	bool Load(FILE *fin, bool createflag = true);
};

#endif // BAG_H
