#pragma once
#include "stdafx.h"
#include "WoWObject.h"
#include "ItemTemplate.h"
#include "UpdateObject.h"

struct ItemData
{
	unsigned long nItemTemplate;

	unsigned long Count; // stack
	unsigned long Size;
	unsigned long Owner;
	unsigned long Container;

	unsigned long Creator;

	_Location Loc;
};

class CItem : public CWoWObject, CUpdateObject
{
	unsigned long AddCreateObjectData(char *buffer);
	void PreCreateObject();
	//void PostCreateObject();
public:
	CItem(void);
	~CItem(void);

	inline void CreateObject(bool reset = true) {CUpdateObject::CreateObject(guid, reset);};
	inline void UpdateObject(bool reset = true) {CUpdateObject::UpdateObject(guid, ITEMGUID_HIGH, reset);};
	ItemTemplateData TemplateData;
	ItemData Data;
	void Clear();
	void New(unsigned long nTemplate, unsigned long Owner);

	unsigned long GetItemInfoData(char *buffer, bool Create=true);
};
