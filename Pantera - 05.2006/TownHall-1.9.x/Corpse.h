#ifndef CORPSE_H
#define CORPSE_H

#include "stdafx.h"
#include "WoWObject.h"
#include "UpdateObject.h"
#include "Player.h"
#include "Packet.h"

struct CorpseData
{
	char Name[15];
	unsigned long Owner;
	unsigned long Model;
	unsigned char Appearance[5];
	unsigned char Race;
	unsigned char Gender;
//	unsigned long Items[120];
	CItem *Items[120];
	_Location Loc;
	unsigned long Continent;
	float Facing;
};

class CCorpse: public CWoWObject, public CUpdateObject
{
	unsigned long AddCreateObjectData(char *buffer);
	void PreCreateObject();
public:
	CCorpse(void);
	~CCorpse(void);

	inline void CreateObject(bool reset = true) {CUpdateObject::CreateObject(guid, reset);};
	inline void UpdateObject(bool reset = true) {CUpdateObject::UpdateObject(guid, CORPSEGUID_HIGH, reset);};

	void New();
	void Clear();
	void Delete();

	CorpseData Data;

	unsigned long GetCorpseInfoData(char *buffer, bool Create = true);
	void SpawnBones();
	void ProcessEvent(WoWEvent &Event);
	void SendRegion(IPacket *pkg);
};

#endif // CORPSE_H
