#include "Quest.h"

CQuestInfo::CQuestInfo(void):CWoWObject(OBJ_QUESTINFO)
{
	Clear();
}

CQuestInfo::~CQuestInfo(void)
{
}

void CQuestInfo::Clear()
{
	CWoWObject::Clear();
	memset(&Data,0,sizeof(QuestData));
}

void CQuestInfo::New()
{
	Clear();
	CWoWObject::New();
	// prevent buffer overflow
}

bool CQuestInfo::StoringData(ObjectStorage &Storage)
{
	Storage.Allocate(sizeof(QuestData));
	memcpy(Storage.Data,&Data,sizeof(QuestData));
	return true;
}

bool CQuestInfo::LoadingData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	memcpy(&Data,Storage.Data,sizeof(QuestData));
	return true;
}

CQuestRelation::CQuestRelation(void):CWoWObject(OBJ_QUESTRELATION)
{
	Clear();
}

CQuestRelation::~CQuestRelation(void)
{
}

void CQuestRelation::Clear()
{
	CWoWObject::Clear();
	memset(&Data,0,sizeof(QuestRelationData));
}

void CQuestRelation::New()
{
	Clear();
	CWoWObject::New();
}

bool CQuestRelation::StoringData(ObjectStorage &Storage)
{
	Storage.Allocate(sizeof(QuestRelationData));
	memcpy(Storage.Data,&Data,sizeof(QuestRelationData));
	return true;
}

bool CQuestRelation::LoadingData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	memcpy(&Data,Storage.Data,sizeof(QuestRelationData));
	return true;
}
