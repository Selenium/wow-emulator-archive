#ifndef DYNAMICOBJECT_H
#define DYNAMICOBJECT_H

#include "WoWObject.h"
#include "Player.h"
#define DYNOBJ_AREA_DOT 1
struct DynamicObjectData
{
	_Location loc;
	float Radius;
	unsigned long SpellID;
	short count;
	unsigned long Effect;
	unsigned long Freq;
};

class CDynamicObject : public CWoWObject,public CUpdateObject
{
public:
	unsigned long AddCreateObjectData(char *buffer);
	inline void CreateObject(bool reset = true) {CUpdateObject::CreateObject(guid, reset);};
	inline void UpdateObject(bool reset = true) {CUpdateObject::UpdateObject(guid, GAMEOBJECTGUID_HIGH, reset);};
	unsigned long GetDynamicObjectInfoData(char *buffer, bool Create = true);
	CDynamicObject(void);
	~CDynamicObject(void);
	void Add(_Location Loc,CWoWObject *pCaster,CSpell *pSpell,unsigned long Effect);
	void Remove();
	CSpell *spell;
	void ProcessEvent(struct WoWEvent &Event);
	DynamicObjectData Data;
	CWoWObject* TargetMap[200];
	CWoWObject *caster;
	int GetTargets(_Location &Loc);
	short elapsed;
	void AddPeriodicAreaDmg(unsigned long freq,short count);
	bool CanBeHurt(CWoWObject *target);
	void SendSpellGo();
	void ClearTargets();
};

#endif // DYNAMICOBJECT_H
