#include "NPCText.h"

CNPCText::CNPCText(void):CWoWObject(OBJ_NPCTEXT)
{
	Clear();
}

CNPCText::~CNPCText(void)
{
}

void CNPCText::Clear()
{
	CWoWObject::Clear();
	memset(&Data,0,sizeof(NPCTextData));
}

void CNPCText::New()
{
	Clear();
	CWoWObject::New();
}

bool CNPCText::StoringData(ObjectStorage &Storage)
{
	Storage.Allocate(sizeof(NPCTextData));
	memcpy(Storage.Data,&Data,sizeof(NPCTextData));
	return true;
}

bool CNPCText::LoadingData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	memcpy(&Data,Storage.Data,sizeof(NPCTextData));
	return true;
}

// CPageText

CPageText::CPageText(void):CWoWObject(OBJ_PAGETEXT)
{
	Clear();
}

CPageText::~CPageText(void)
{
}

void CPageText::Clear()
{
	CWoWObject::Clear();
	memset(&Data,0,sizeof(PageTextData));
}

void CPageText::New()
{
	Clear();
	CWoWObject::New();
}

bool CPageText::StoringData(ObjectStorage &Storage)
{
	Storage.Allocate(sizeof(PageTextData));
	memcpy(Storage.Data,&Data,sizeof(PageTextData));
	return true;
}

bool CPageText::LoadingData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	memcpy(&Data,Storage.Data,sizeof(PageTextData));
	return true;
}

