
#ifndef QUESTTEMPLATE_H
#define QUESTTEMPLATE_H


#include "stdafx.h"
#include "WoWObject.h"
#include "LootTable.h"
#include <vector>

struct QuestData
{
	unsigned long questid;
	unsigned long zoneid;
	unsigned long questflags;
	char title[64];
	char details[1152];
	char objectives[512];
	char completedtext[1024];
	char incompletetext[512];
	char secondtext[128];
	char parttext1[128];
	char parttext2[128];
	char parttext3[128];
	char parttext4[128];
	unsigned long reqlevel;
	unsigned long questlevel;
	unsigned long prevquests;
	unsigned long previousquest[4];
	unsigned long questitemid[4];
	unsigned long questitemcount[4];
	unsigned long questmobid[4];
	unsigned long questmobcount[4];
	unsigned long questarea[4];
	unsigned long choicerewards;
	unsigned long choiceitemid[6];
	unsigned long choiceitemcount[6];
	unsigned long itemrewards;
	unsigned long rewarditemid[4];
	unsigned long rewarditemcount[4];
	unsigned long rewardgold;
	unsigned long rewardexp;
	unsigned long repfaction[2];
	unsigned long repvalue[2];
	unsigned long srcitem[4];
	unsigned long srcitemcount[4];
	unsigned long nextquest;
	unsigned long learnspell;
	unsigned long timeseconds;
	unsigned long questtype;
	unsigned long questraces;
	unsigned long questclass;
	unsigned long questtrskill;
	unsigned long questrepfaction;
	unsigned long questrepvalue;
	unsigned long questbehavior;
	unsigned long location[4];
	unsigned long repeatable;
};

class CQuestInfo : public CWoWObject
{
public:
	CQuestInfo(void);
	~CQuestInfo(void);

	QuestData Data;
	bool StoringData(ObjectStorage &Storage);
	bool LoadingData(ObjectStorage &Storage);

	void Clear();
	void New();
};


struct QuestRelationData
{
	guid_t templateguid;
	unsigned long involver; // bool, but it would take up the whole 4 bytes anyway :P
	guid_t questguid;
};

class CQuestRelation : public CWoWObject
{
public:
	CQuestRelation(void);
	~CQuestRelation(void);

	QuestRelationData Data;
	bool StoringData(ObjectStorage &Storage);
	bool LoadingData(ObjectStorage &Storage);

	void Clear();
	void New();
};

#endif // QUESTTEMPLATE_H
