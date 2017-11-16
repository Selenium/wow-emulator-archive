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
	guid_t Owner;
	unsigned long Model;
	unsigned char Appearance[5];
	unsigned char Race;
	unsigned char Gender;
//	unsigned long Items[120];
	guid_t ItemGuids[120];
	_Location Loc;
	unsigned long Continent;
	float Facing;
};

class CCorpse: public CWoWObject, public CUpdateObject
{
public:
	CCorpse(void);
	~CCorpse(void);

	inline void UpdateObject(bool reset = true) {CUpdateObject::UpdateObject(guid, CORPSEGUID_HIGH, reset);};

	void New();
	void Clear();
	void Delete();

	CorpseData Data;
	CItem *Items[120];

	unsigned long GetCorpseInfoData(char *buffer, bool Create = true);
	void SpawnBones();
	void ProcessEvent(WoWEvent &Event);
	void SendRegion(IPacket *pkg);
};

#endif // CORPSE_H
