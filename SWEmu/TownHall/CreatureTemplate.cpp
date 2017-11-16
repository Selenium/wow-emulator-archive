#include "CreatureTemplate.h"

CCreatureTemplate::CCreatureTemplate(void):CWoWObject(OBJ_CREATURETEMPLATE)
{
	Clear();
}

CCreatureTemplate::~CCreatureTemplate(void)
{
}

void CCreatureTemplate::Clear()
{
	CWoWObject::Clear();
	memset(&Data,0,sizeof(CreatureTemplateData));
	Generated=false;
}

void CCreatureTemplate::New(const char *Name)
{
	Clear();
	CWoWObject::New();
	// prevent buffer overflow
	strncpy(Data.Name,Name,63);
	Data.Name[63]=0;
	//	strcpy(Data.Name1,Data.Name);
	//	strcpy(Data.Name2,Data.Name);
	//	strcpy(Data.Name3,Data.Name);
	//	Data.Something1=0; // what are these? ;)
	//	Data.Something2=0;
	Data.Size = 1.0f;
	Generated=true;
}

bool CCreatureTemplate::StoringData(ObjectStorage &Storage)
{
	if (!guid || Generated)
		return false;
	Storage.Allocate(sizeof(CreatureTemplateData));
	memcpy(Storage.Data,&Data,sizeof(CreatureTemplateData));
	return true;
}

bool CCreatureTemplate::LoadingData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	memcpy(&Data,Storage.Data,sizeof(CreatureTemplateData));
	return true;
}
