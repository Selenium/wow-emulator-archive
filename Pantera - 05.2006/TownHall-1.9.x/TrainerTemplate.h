
#ifndef TRAINERTEMPLATE_H
#define TRAINERTEMPLATE_H


#include "stdafx.h"
#include "WoWObject.h"
#include <vector>

struct TrainerTemplateData
{
	unsigned long creaturetemplateguid;
	unsigned long skillline[20];
	unsigned long maxlvl;
	unsigned long trclass;
};

class CTrainerTemplate : public CWoWObject
{
public:
	CTrainerTemplate(void);
	~CTrainerTemplate(void);

	TrainerTemplateData Data;
	bool StoringData(ObjectStorage &Storage);
	bool LoadingData(ObjectStorage &Storage);
	unsigned long DataStorageSize() {return sizeof(TrainerTemplateData);};

	void Clear();
	void New();
};

#endif // TRAINERTEMPLATE_H
