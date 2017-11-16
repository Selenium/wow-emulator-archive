#ifndef NPCTEXT_H
#define NPCTEXT_H

#include "stdafx.h"
#include "WoWObject.h"

#define TEXTID_0 0x00000000
#define TEXTID_1 0x00100000
#define TEXTID_2 0x00200000
#define TEXTID_3 0x00300000
#define TEXTID_4 0x00400000
#define TEXTID_5 0x00500000
#define TEXTID_6 0x00600000
#define TEXTID_7 0x00700000

#define TEXT_LEN 512

struct NPCTextData
{
	unsigned long nTexts;
	char text[TEXT_LEN];
	unsigned long lang;
	unsigned long prob;
	unsigned long em[3];
};

class CNPCText : public CWoWObject
{
public:
	CNPCText(void);
	~CNPCText(void);

	NPCTextData Data;
	bool StoringData(ObjectStorage &Storage);
	bool LoadingData(ObjectStorage &Storage);
	unsigned long DataStorageSize() {return sizeof(NPCTextData);};

	void Clear();
	void New();
};

// CPageText

struct PageTextData
{
	unsigned long NextPage;
	char Text[1024];
};

class CPageText : public CWoWObject
{
public:
	CPageText(void);
	~CPageText(void);

	PageTextData Data;
	bool StoringData(ObjectStorage &Storage);
	bool LoadingData(ObjectStorage &Storage);
	unsigned long DataStorageSize() {return sizeof(PageTextData);};

	void Clear();
	void New();
};

#endif // NPCTEXT_H
