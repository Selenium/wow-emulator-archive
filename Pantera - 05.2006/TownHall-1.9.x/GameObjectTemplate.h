#ifndef GAMEOBJECTTEMPLATE_H
#define GAMEOBJECTTEMPLATE_H

#include "stdafx.h"
#include "WoWObject.h"
#include "LootTable.h"
#include "GameObject.h"
#include <vector>

struct GameObjectTemplateData
{
	unsigned long	ObjectID;
	char	Name[64];
	unsigned long	Model;
	unsigned long	Sound0;
	unsigned long	Sound1;
	unsigned long	Sound2;
	unsigned long	Sound3;
	unsigned long	Sound4;
	unsigned long	Sound5;
	unsigned long	Sound6;
	unsigned long	Sound7;
	unsigned long	Sound8;
	unsigned long	Sound9;
	unsigned long	Sound10;
	unsigned long	Faction;
	unsigned long	Flags;
	unsigned long	GType;
	unsigned long   Type;
	float			Size;
	unsigned long  Level;
	// unsigned long LootTable; // GO LOOTING: TODO
};

class CGameObjectTemplate : public CWoWObject
{
public:
	CGameObjectTemplate(void);
	~CGameObjectTemplate(void);

	GameObjectTemplateData Data;
	bool StoringData(ObjectStorage &Storage);
	bool LoadingData(ObjectStorage &Storage);
	unsigned long DataStorageSize() {return sizeof(GameObjectTemplateData);};

	void Clear();
	void New(const char *Name);

	void GenerateLoot(CGameObject *pGameObject);

	bool Generated;
	std::vector<LootItem> LootTable;
};

#endif // GAMEOBJECTTEMPLATE_H
