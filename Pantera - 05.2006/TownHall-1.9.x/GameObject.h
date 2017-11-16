#ifndef GAMEOBJECT_H
#define GAMEOBJECT_H

#include <sys/timeb.h>
#include "stdafx.h"
#include "WoWObject.h"
#include "UpdateObject.h"
#include "GameObjectTemplate.h"
#include "Packet.h"
#include <map>

struct GameObjectData
{
	// unsigned long Owner;
	unsigned long Faction;
	// unsigned long Model;
	unsigned long Continent;
	// unsigned long Flags;
	// unsigned long Type;
	unsigned long ObjectID;
	float Size;
	float Facing;
	_Location Loc;
	// _timeb TimeStamp;
	unsigned long TemplateID;
	float Rotation[4];
};

struct GameObjectSaveData
{
	unsigned long TemplateID;
	unsigned long Type;
	unsigned long GType;

	unsigned long Continent;
	_Location Loc;
	float Facing;

	float Rotation[4];
};

class CGameObject :	public CWoWObject, public CUpdateObject
{
	unsigned long AddCreateObjectData(char *buffer);
	void PreCreateObject();
public:
	CGameObject(void);
	~CGameObject(void);

	inline void CreateObject(bool reset = true) {CUpdateObject::CreateObject(guid, reset);};
	inline void UpdateObject(bool reset = true) {CUpdateObject::UpdateObject(guid, GAMEOBJECTGUID_HIGH, reset);};
	unsigned long GetGameObjectInfoData(char *buffer, bool Create = true);

	void ProcessEvent(struct WoWEvent &Event);

	void New(CPlayer *pPlayer,unsigned long model, unsigned long flags, unsigned long type);
	void New(CPlayer *pPlayer,unsigned long model, unsigned long flags, unsigned long type,char * name,float x,float y,int objid);
	void New(unsigned long TemplateID);
	void Clear();
	void Delete();

	GameObjectData Data;
	CGameObjectTemplate *pTemplate;
	bool bLooted;
	std::map<char,CItemTemplate *> LootedItems; //slot, item

	void SendRegion(IPacket *pkg);
};

#endif // GAMEOBJECT_H
