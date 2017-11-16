#include "stdafx.h"
#include "EventManager.h"

CEventManager::CEventManager(void)
{
}

CEventManager::~CEventManager(void)
{
	multimap<UINT64, WoWEvent*>::iterator itr = EventTimeMap.begin();
	while(itr != EventTimeMap.end())
	{
		delete itr->second;
		itr++;
	}
	EventTimeMap.clear();

}

void CEventManager::AddEvent(CWoWObject &Object, unsigned long msWait, unsigned long EventType
							 ,void *pEventData, unsigned long DataSize, unsigned long RepeatTime, unsigned char RepeatCount)
{
	if (this == NULL)
		return;
	if (!Object.EventsEligible)
		return; // not eligible to receive events

	// Create WoWEvent
	WoWEvent *pNew = new WoWEvent;
	memset(pNew,0,sizeof(WoWEvent));

	_timeb Now;
	_ftime(&Now);
	UINT64 now = timebtoms(Now);
	now += msWait;
	pNew->EventTime = now;
	pNew->EventType=EventType;
	if (DataSize)
	{
		pNew->pEventData=malloc(DataSize);
		memcpy(pNew->pEventData,pEventData,DataSize);
	}
	pNew->RepeatTime = RepeatTime;
	pNew->RepeatCount = RepeatCount;
	pNew->pObject=&Object;

	// Add to main list
	InsertSorted(*pNew);
	// Add to object's list
	Object.AddEvent(*pNew);
}


void CEventManager::ProcessReadyEvents()
{
	UINT64 timems = nowinms();

	while(EventTimeMap.begin() != EventTimeMap.end())
	{
		multimap<UINT64, WoWEvent*>::iterator itr = EventTimeMap.begin();
		if (itr->first <=timems)
		{
			// detach this event from the main linked list
			WoWEvent* actEvent = itr->second;
			EventTimeMap.erase(itr);

			// and from the object's linked list
			actEvent->pObject->RemoveEvent(actEvent,true);

			if (actEvent->pObject->EventsEligible)
				actEvent->pObject->ProcessEvent(*actEvent); //posible iterator invalidation
			if (actEvent->RepeatCount)
			{
				//reshedule event and decrease repeat count
				actEvent->EventTime += actEvent->RepeatTime;
				actEvent->RepeatCount--;
				InsertSorted(*actEvent);
			}
			else
			{
				// destroy the event and clean up our event node
				if (actEvent->pEventData)
					free(actEvent->pEventData);
				delete actEvent;
			}
		}
		else
		{
			// no (more) ready events
			break;
		}
	}
}
UINT64 timebtoms(_timeb &intime)
{
	UINT64 timems = intime.time;
	timems *= 1000;
	timems += intime.millitm;
	return timems;
}

UINT64 nowinms(void)
{
	_timeb now;
	_ftime(&now);
	return timebtoms(now);
}

void CEventManager::ChangeEventTime(WoWEvent *const Event, const long timems)
{
	multimap<UINT64, WoWEvent*>::iterator itr = FindInTimeList(Event);
	WoWEvent* actEvent = itr->second;
	EventTimeMap.erase(itr);
	actEvent->EventTime += timems;
	InsertSorted(*actEvent);
}
