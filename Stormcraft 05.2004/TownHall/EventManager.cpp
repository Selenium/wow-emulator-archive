#include "stdafx.h"
#include "EventManager.h"

CEventManager::CEventManager(void)
{
	pEvents=0;
}

CEventManager::~CEventManager(void)
{
	while(pEvents)
	{
		WoWEventNode *pNext=pEvents->pNext;
		if (pEvents->pEvent->pEventData)
			free(pEvents->pEvent->pEventData);
		delete pEvents->pEvent;
		delete pEvents;
		pEvents = pNext;
	}
}

void CEventManager::AddEvent(CWoWObject &Object, unsigned long msWait, unsigned long EventType, void *pEventData, unsigned long DataSize)
{
	static unsigned long NextID=0;
	if (!Object.EventsEligible)
		return; // not eligible to receive events

	// Create WoWEvent
	WoWEvent *pNew = new WoWEvent;
	memset(pNew,0,sizeof(WoWEvent));
	pNew->EventID=++NextID;
	
	_ftime(&pNew->EventTime);
	AddTime(pNew->EventTime,msWait);
	pNew->EventType=EventType;
	if (DataSize)
	{
		pNew->pEventData=malloc(DataSize);
		memcpy(pNew->pEventData,pEventData,DataSize);
	}
	pNew->pObject=&Object;

	// Add to main list
	InsertSorted(*pNew);
	// Add to object's list
	Object.AddEvent(*pNew);
/*
	char buf[256];
	sprintf(buf,"Added %d\n",EventType);
	OutputDebugString(buf);
*/
}

void CEventManager::ProcessReadyEvents()
{
	WoWEventNode *pCurrent=pEvents;
	if (!pCurrent)
		return;

	_timeb now;
	_ftime(&now);
	do
	{
		if (DiffTime(pCurrent->pEvent->EventTime,now)<=0)
		{
			// detach this event from the main linked list
			pEvents=pCurrent->pNext;
			if (pEvents)
				pEvents->pLast=0;
			EventMap[pCurrent->pEvent->EventID]=0;

			// and from the object's linked list
			pCurrent->pEvent->pObject->RemoveEvent(pCurrent->pEvent->EventID);

			if (pCurrent->pEvent->pObject->EventsEligible)
				pCurrent->pEvent->pObject->ProcessEvent(*pCurrent->pEvent);

/*
	char buf[256];
	sprintf(buf,"Removed %d\n",pCurrent->pEvent->EventType);
	OutputDebugString(buf);
*/
			// destroy the event and clean up our event node
			if (pCurrent->pEvent->pEventData)
				free(pCurrent->pEvent->pEventData);
			delete pCurrent->pEvent;
			delete pCurrent;
		}
		else
		{
			// no (more) ready events
			return;
		}
	} while(pCurrent=pEvents);
}

