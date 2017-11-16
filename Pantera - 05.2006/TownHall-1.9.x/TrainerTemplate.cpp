#include "TrainerTemplate.h"

CTrainerTemplate::CTrainerTemplate(void):CWoWObject(OBJ_TRAINERTEMPLATE)
{
	Clear();
}

CTrainerTemplate::~CTrainerTemplate(void)
{
}

void CTrainerTemplate::Clear()
{
	CWoWObject::Clear();
	memset(&Data,0,sizeof(TrainerTemplateData));
}

void CTrainerTemplate::New()
{
	Clear();
	CWoWObject::New();
	// prevent buffer overflow
}

bool CTrainerTemplate::StoringData(ObjectStorage &Storage)
{
	Storage.Allocate(sizeof(TrainerTemplateData));
	memcpy(Storage.Data,&Data,sizeof(TrainerTemplateData));
	return true;
}

bool CTrainerTemplate::LoadingData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	memcpy(&Data,Storage.Data,sizeof(TrainerTemplateData));
	return true;
}
