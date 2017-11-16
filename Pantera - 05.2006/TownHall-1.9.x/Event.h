#ifndef AURAEVENT_H
#define AURAEVENT_H

#include "stdafx.h"
#include "WoWObject.h"
#include "UpdateObject.h"
#define AURA_EVENT_DOT 1
#define AURA_EVENT_HOT 2
#define AURA_AREA_EVENT_DOT 3
#define AURA_AREA_EVENT_HOT 4
class AuraEvent: public CWoWObject, public CUpdateObject
{
public:
	AuraEvent(void);
	void ProcessEvent(struct WoWEvent &Event);
	unsigned long SpellID,power,EffectID,School,Freq,Slot;
	short calltime,timecall;float Radius;CSpell *pSpell;
	CWoWObject *pCaster,*pTarget;
	void GetHOTTargets(float radius);
	CWoWObject *targets[200];
	void ClearTargets();
	void SetEventData(unsigned long SpellID,unsigned long power,unsigned long EffectID,unsigned long School,CWoWObject *pCaster,CWoWObject *pTarget,short n,unsigned long freq,unsigned long slot,float radius,CSpell *spell);
};
#endif
