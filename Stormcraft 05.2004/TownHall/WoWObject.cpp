#include "stdafx.h"
#include "WoWObject.h"
#include "Globals.h"
#include "EventManager.h"

CWoWObject::CWoWObject(unsigned long xType)
{
	type=xType;
	guid=0;
	pEvents=0;
	EventsEligible=false;
}

CWoWObject::~CWoWObject(void)
{
	EventsEligible=false;
	while(pEvents)
	{
		WoWEventNode *pNext=pEvents->pNext;
		delete pEvents;
		pEvents = pNext;
	}
}

void CWoWObject::New()
{
	guid=DataManager.GetFreeID(type);
}

void CWoWObject::Clear()
{
	ClearEvents();
	guid=0;
	EventsEligible=false;
}

void CWoWObject::ClearEvents()
{
	WoWEventNode *pNode = pEvents;
	while(pNode)
	{
		WoWEventNode *pNext = pNode->pNext;
		EventManager.RemoveEvent(pNode->pEvent->EventID);
		delete pNode;
		pNode=pNext;
	}
	pEvents=0;
}

void CWoWObject::ClearEvents(unsigned long EventType)
{
	WoWEventNode *pNode = pEvents;
	while(pNode)
	{
		WoWEventNode *pNext = pNode->pNext;
		if (pNode->pEvent->EventType==EventType)
		{
			EventManager.RemoveEvent(pNode->pEvent->EventID);
			if (pNext)
				pNext->pLast=pNode->pLast;
			if (pNode->pLast)
				pNode->pLast->pNext=pNode->pNext;
			else
				pEvents=pNode->pNext;

			delete pNode;
		}
		pNode=pNext;
	}
}

void CWoWObject::Delete()
{
	// remove from database
	DataManager.UnCacheObjectNoFree(*this);
	Clear();
}

void CWoWObject::RemoveEvent(unsigned long EventID)
{
	WoWEventNode *pNode = pEvents;
	while(pNode)
	{
		if (pNode->pEvent->EventID==EventID)
		{
			if (pNode->pLast)
				pNode->pLast->pNext=pNode->pNext;
			else
				pEvents=pNode->pNext;
			if (pNode->pNext)
				pNode->pNext->pLast=pNode->pLast;
			delete pNode;
			return;
		}
		pNode=pNode->pNext;
	}
	Debug.Logf("CWoWObject::RemoveEvent Cannot remove event #%u\n",EventID);
	return;
}

void CWoWObject::AddEvent(struct WoWEvent &Event)
{
	WoWEventNode *pNode = new WoWEventNode;
	pNode->pEvent=&Event;
	pNode->pLast=0;
	pNode->pNext=pEvents;
	if (pEvents)
		pEvents->pLast=pNode;
	pEvents=pNode;
}
