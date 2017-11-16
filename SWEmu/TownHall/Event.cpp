#include "stdafx.h"
#include "WoWObject.h"
#include "CreatureTemplate.h"
#include "ItemTemplate.h"
#include <sys/timeb.h>
#include "FlyPath.h"
#include <list>
#include <map>
#include "UpdateObject.h"
#include "Player.h"
#include "Creature.h"
#include "Event.h"
#include "EventManager.h"
#include "Spell.h"
AuraEvent::AuraEvent(void):CWoWObject(OBJ_NONE), CUpdateObject(0)
{
	EventsEligible = true;
}
void AuraEvent::ProcessEvent(struct WoWEvent &Event)
{
	switch(Event.EventType)
	{
	case AURA_EVENT_DOT:
		{

			if(pTarget->type == OBJ_PLAYER)
			{
				timecall++;
				((CPlayer*)pTarget)->DataObject.AddHP(-(long)power);
				((CPlayer*)pTarget)->UpdateObject();
				((CPlayer*)pTarget)->SendPeriodicLog(power,SpellID,EffectID,School,pCaster,pTarget);
				if(calltime<calltime)
					EventManager.AddEvent(*this,Freq, AURA_EVENT_DOT, 0,0);
			}
			else
			{
				((CCreature*)pTarget)->SendPeriodicLog(power,SpellID,EffectID,School,pCaster,pTarget);
				((CCreature*)pTarget)->DataObject.AddHP(-(long)power);
				((CCreature*)pTarget)->UpdateObject();
				((CCreature*)pTarget)->AddToHitList((CPlayer *)pCaster,power);
				if (((CCreature*)pTarget)->Data.CurrentStats.HitPoints <= 0 && !((CCreature*)pTarget)->dead)
				{
					((CCreature*)pTarget)->Death();
				}
				else
				{
					if (!((CCreature*)pTarget)->bAttacking)
					{
						((CCreature*)pTarget)->TargetID = pCaster->guid;
						((CCreature*)pTarget)->Attack();
					}
					if(timecall<calltime)
						EventManager.AddEvent(*this,Freq, AURA_EVENT_DOT, 0,0);
				}
			}
		}break;
	case AURA_EVENT_HOT:
		{

			if(pTarget->type == OBJ_PLAYER)
			{
				timecall++;
				if(((CPlayer*)pTarget)->Data.CurrentStats.HitPoints + (long)power >((CPlayer*)pTarget)->Data.NormalStats.HitPoints)
				{
					((CPlayer*)pTarget)->DataObject.AddHP(((CPlayer*)pTarget)->Data.NormalStats.HitPoints - ((CPlayer*)pTarget)->Data.CurrentStats.HitPoints);
				}
				else ((CPlayer*)pTarget)->DataObject.AddHP(power);
				((CPlayer*)pTarget)->UpdateObject();
				((CPlayer*)pTarget)->SendPeriodicLog(power,SpellID,EffectID,School,pCaster,pTarget);
				if(timecall<calltime+1)
					EventManager.AddEvent(*this,Freq, AURA_EVENT_HOT, 0, 0);
				else if(timecall==calltime+1) ((CPlayer*)pTarget)->RemoveAura(Slot);
			}
			else
			{
				timecall++;
				if(((CCreature*)pTarget)->Data.CurrentStats.HitPoints + (long)power >((CCreature*)pTarget)->pTemplate->Data.NormalStats.HitPoints)
				{
					((CCreature*)pTarget)->DataObject.AddHP(((CCreature*)pTarget)->pTemplate->Data.NormalStats.HitPoints - ((CCreature*)pTarget)->Data.CurrentStats.HitPoints);
				}
				else ((CCreature*)pTarget)->DataObject.AddHP(power);
				((CCreature*)pTarget)->UpdateObject();
				((CCreature*)pTarget)->SendPeriodicLog(power,SpellID,EffectID,School,pCaster,pTarget);
				if(timecall<calltime+1)
					EventManager.AddEvent(*this,Freq, AURA_EVENT_HOT, 0, 0);
				else if(timecall==calltime+1) ((CCreature*)pTarget)->RemoveAura(Slot);
			}
		}break;
	case AURA_AREA_EVENT_HOT:
		{
			GetHOTTargets(Radius);
			timecall++;
			for(int i=0;i<200;i++)
			{
				if(targets[i]&&!(((CPlayer*)targets[i])->dead))
				{
					if(((CPlayer*)targets[i])->Distance(*((CPlayer*)pCaster)) < Radius)
				if(((CPlayer*)targets[i])->Data.CurrentStats.HitPoints + (long)power >((CPlayer*)targets[i])->Data.NormalStats.HitPoints)
				{
					((CPlayer*)targets[i])->DataObject.AddHP(((CPlayer*)targets[i])->Data.NormalStats.HitPoints - ((CPlayer*)targets[i])->Data.CurrentStats.HitPoints);
				}
				else ((CPlayer*)targets[i])->DataObject.AddHP(power);
				((CPlayer*)targets[i])->UpdateObject();
				((CPlayer*)targets[i])->SendPeriodicLog(power,SpellID,0x8,School,pCaster,targets[i]);
				pSpell->SendSpellGo();
				}
			}
			if(timecall<calltime+1)
			EventManager.AddEvent(*this,Freq, AURA_AREA_EVENT_HOT, 0, 0);
			else if(timecall==calltime+1) ((CPlayer*)pCaster)->StopChannel(SpellID);
		}break;
	}
}
void AuraEvent::SetEventData(unsigned long spellID,unsigned long Power,unsigned long effectID,unsigned long school,CWoWObject *pcaster,CWoWObject *ptarget,short n,unsigned long freq,unsigned long slot,float radius,CSpell *spell)
{
	SpellID = spellID;power = Power;EffectID = effectID;School = school;pCaster = pcaster;pTarget = ptarget;calltime =n;Freq = freq;
	timecall=0;Slot = slot;Radius=radius;pSpell=spell;
}
void AuraEvent::ClearTargets()
{
	for(int i=0;i<200;i++) targets[i]=NULL;
}
void AuraEvent::GetHOTTargets(float radius)
{
	int c=0;
	ClearTargets();
	CRegion *pPlayerRegion=RegionManager.ObjectRegions[pCaster->guid];
	if(!pPlayerRegion) return;
	for (int i = 0 ; i < 3 ; i++)
	{
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if(pNode->pObject->type==OBJ_PLAYER && ((CPlayer*)pNode->pObject)->FTeam==((CPlayer*)pCaster)->FTeam )
					{
						if (((CPlayer *)pNode->pObject)->Distance(*((CPlayer*)pCaster)) < Radius)
						{
							targets[c] = pNode->pObject;
							c+=1;
						}
					}
					pNode=pNode->pNext;
				}
			}
		}
	}
}
