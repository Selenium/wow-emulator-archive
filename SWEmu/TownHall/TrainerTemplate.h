
#ifndef TRAINERTEMPLATE_H
#define TRAINERTEMPLATE_H


#include "stdafx.h"
#include "WoWObject.h"
#include <vector>

struct TrainerTemplateData
{
	guid_t creaturetemplateguid;
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

	void Clear();
	void New();
};

#endif // TRAINERTEMPLATE_H
