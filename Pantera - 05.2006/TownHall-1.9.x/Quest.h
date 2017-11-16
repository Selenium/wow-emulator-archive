
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
	char details[512];
	char objectives[128];
	char completedtext[128];
	char incompletetext[128];
	char secondtext[128];
	char parttext1[128];
	char parttext2[128];
	char parttext3[128];
	char parttext4[128];
	unsigned long reqlevel;
	unsigned long questlevel;
	unsigned long prevquests;
	unsigned long previousquest[9];
	unsigned long questitemid[3];
	unsigned long questitemcount[3];
	unsigned long questmobid[3];
	unsigned long questmobcount[3];
	unsigned long choicerewards;
	unsigned long choiceitemid[5];
	unsigned long choiceitemcount[5];
	unsigned long itemrewards;
	unsigned long rewarditemid[3];
	unsigned long rewarditemcount[3];
	unsigned long rewardgold;
	unsigned long repfaction[1];
	unsigned long repvalue[1];
	unsigned long srcitem;
	unsigned long nextquest;
	unsigned long learnspell;
	unsigned long timeminutes;
	unsigned long questtype;
	unsigned long questraces;
	unsigned long questclass;
	unsigned long questtrskill;
	unsigned long questbehavior;
	unsigned long location[4];
};

class CQuestInfo : public CWoWObject
{
public:
	CQuestInfo(void);
	~CQuestInfo(void);

	QuestData Data;
	bool StoringData(ObjectStorage &Storage);
	bool LoadingData(ObjectStorage &Storage);
	unsigned long DataStorageSize() {return sizeof(QuestData);};

	void Clear();
	void New();
};


struct QuestRelationData
{
	unsigned long templateguid;
	bool involver;
	unsigned long questguid;
};

class CQuestRelation : public CWoWObject
{
public:
	CQuestRelation(void);
	~CQuestRelation(void);

	QuestRelationData Data;
	bool StoringData(ObjectStorage &Storage);
	bool LoadingData(ObjectStorage &Storage);
	unsigned long DataStorageSize() {return sizeof(QuestRelationData);};

	void Clear();
	void New();
};

#endif // QUESTTEMPLATE_H
